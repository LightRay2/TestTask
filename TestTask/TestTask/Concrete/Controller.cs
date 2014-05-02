using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Threading;

namespace TestTask
{
    class Controller
    {
        /* Задача публичных методов контроллера:
         * 1. Выполнить манипуляции с данными (экологами и пробами)
         * 2. Отобразить изменения на форме, вызвав соответствующий метод формы
         * 3. Кидать сообщения ползователю об успешности\не успешности операции
         * 4. Менять поле _thereIsNotSavedData
         * 5. Сохранять поле _lastXmlFile в методах, которые затрагивают работу с файлами
         */ 

        #region init
        //внешние объекты
        IRepository _repo;
        IConverterXmlToHtml _converterXmlTohtml;
        FormMain _form;

        //данные
        List<Ecologist> _ecos;

        //вспомогательные:
        readonly string CONFIG_FILE  = Path.GetDirectoryName(Application.ExecutablePath)+ "//config.cfg";
        string _lastXmlFile = "";
        bool _thereIsNotSavedData = false;

        public Controller(FormMain form, IRepository repo, IConverterXmlToHtml conv)
        {
            this._form = form;
            this._repo = repo;
            this._converterXmlTohtml = conv;

            //пробуем загрузить последний проект
            _lastXmlFile = LastSavedXmlFile();
            if (_lastXmlFile != "")
            {
                 ReadFromXMLFile(_lastXmlFile);
            }

            if (_ecos != null) 
                _form.StatusMessage("Загружено из " + _lastXmlFile);
            else 
                StartNewProject();
            
        }

        #endregion



        #region public load-save-new methods

        //свойство, чтобы в файловых диалогах сразу показывать последний файл
        public string LastXmlFile { get { return _lastXmlFile; } }
        //свойство, чтобы спросить пользователя в случае выхода, не забыл ли он сохранить данные
        public bool TherIsNotSavedData { get { return _thereIsNotSavedData && _ecos.Count != 0; } }

        //новый проект
        public void StartNewProject()
        {
            _ecos = new List<Ecologist>();
            _form.FillEcologists(new List<string>());
            _form.FillProbes(new List<string>(), new List<string>());
            _lastXmlFile = ""; //чтобы предотвратить сохранение нового проекта в предыдущий
            _form.StatusMessage("Создан новый проект");
            _thereIsNotSavedData = true;
        }

        //сохранить
        public void SaveToXmlFile()
        {
            if (_lastXmlFile == "")
                _form.ErrorMessage("Не удалось сохранить в файл. Воспользуйтесь \"Сохранить как ...\" ");
            else
            {
                SaveToXmlFile(_lastXmlFile);
            }
            
        }
        //сохранить как
        public void SaveToXmlFile(string file)
        {
            try
            {
                _repo.WriteAllEcologists(file, _ecos);
                SetLastUsedXmlFile(file);
                _form.StatusMessage("Сохранено");
                _thereIsNotSavedData = false;
            }
            catch { _form.ErrorMessage("Ошибка при сохранении файла"); } 
        }

        //загрузить
        public void ReadFromXMLFile(string file)
        {
            try
            {
                _ecos = _repo.ReadAllEcologists(file);
                _form.FillEcologists(EcologistNames());
                if (_ecos.Count > 0)
                    _form.FillProbes(ProbePlaces(0), ProbeDates(0));
                else
                    _form.FillProbes(new List<string>(), new List<string>());

                SetLastUsedXmlFile(file);
                _form.StatusMessage("Загружено");
                _thereIsNotSavedData = false;
            }
            catch { _form.ErrorMessage("Файл не найден или имеет неверный формат"); }
        }

        #endregion

        #region public ecologists grid edit

        public void DeleteEcologists(List<int> indexes)
        {
            List<Ecologist> ecosToDelete = new List<Ecologist>();
            foreach (int index in indexes)
            {
                ecosToDelete.Add(_ecos[index]);
                _form.DeleteEcologist(index);
            }
            foreach (Ecologist eco in ecosToDelete)
            {
                _ecos.Remove(eco);
            }

            if (ecosToDelete.Count > 0)
            {
                _form.StatusMessage("Записи удалены");
                _thereIsNotSavedData = true;
            }
        }

        public void ChangeEcologist(int index, string newName)
        {
            _ecos[index].Name = newName;
            _form.ChangeEcologist(index, newName);
            _form.StatusMessage("Запись изменена");
            _thereIsNotSavedData = true;
        }

        public void AddEcologist(string newName)
        {
            _ecos.Add(new Ecologist(newName, new List<Probe>()));
            _form.AddEcologist(newName);
            _form.StatusMessage("Запись добавлена");
            _thereIsNotSavedData = true;
        }
        #endregion

        #region public probes grid edit

        public void DeleteProbes(int ecoIndex, List<int> indexes)
        {
            List<Probe> probesToDelete = new List<Probe>();
            foreach (int index in indexes)
            {
                probesToDelete.Add(_ecos[ecoIndex].Probes[index]);
                _form.DeleteProbe(index);
            }
            foreach (Probe probe in probesToDelete)
            {
                _ecos[ecoIndex].Probes.Remove(probe);
            }
            if (probesToDelete.Count > 0)
            {
                _form.StatusMessage("Записи удалены");
                _thereIsNotSavedData = true;
            }
        }

        public void ChangeProbe(int ecoIndex, int index, string place,
            int day, int month, int year)
        {
            Probe editing = _ecos[ecoIndex].Probes[index];
            editing.Place = place;
            editing.Day = day;
            editing.Month = month;
            editing.Year = year;
            _form.ChangeProbe(index, place, ConstructDateString(day,month,year));
            _form.StatusMessage("Запись изменена");
            _thereIsNotSavedData = true;
        }

        public void AddProbe(int ecoIndex, string place, int day, int month, int year)
        {
            _ecos[ecoIndex].Probes.Add(new Probe(place, day, month, year));
            _form.AddProbe( place, ConstructDateString(day,month,year));
            _form.StatusMessage("Запись добавлена");
            _thereIsNotSavedData = true;
        }
        #endregion

        #region public eco selected method
        //меняем содержимое таблицы проб
        public void EcologistSelected(int index)
        {
            _form.FillProbes(ProbePlaces(index), ProbeDates(index));
        }
        #endregion

        #region public create reports in another thread
        //вложенный класс для выноса процесса создания отчета в отдельный поток 
        //конструктор сохраняет данные и запускает в новом потоке метод,
        //отвечающий за создание отчета и общение с формой
        class ReportThreadWithData
        {
            FormMain _form;
            IConverterXmlToHtml _conv;
            string _xmlFileIn, _htmlFileOut, _xslString;

            public ReportThreadWithData(FormMain form,
                IConverterXmlToHtml conv,
                string xmlFileIn, string htmlFileOut, string xslString)
            {
                _form = form;
                _conv = conv;
                _xmlFileIn = xmlFileIn;
                _htmlFileOut = htmlFileOut;
                _xslString = xslString;
                new Thread(new ThreadStart(StartConversionThread)).Start();
            }

            public void StartConversionThread()
            {
                //имитируем долгую операцию
                for (int i = 0; i < 100; i += 5)
                {
                    _form.Invoke((MethodInvoker)delegate { _form.SetReportProgressBar(i); });
                    Thread.Sleep(100);
                }

                //осуществляем конвертацию
                try
                { 
                    _conv.ConverUsingXsl(_xmlFileIn, _xslString, _htmlFileOut);
                    _form.Invoke((MethodInvoker)delegate { _form.StatusMessage("Отчет создан"); });
                }
                catch
                {
                    _form.Invoke((MethodInvoker)delegate { _form.StatusMessage("Ошибка при создании отчета"); });
                }
                finally
                {
                    _form.Invoke((MethodInvoker)delegate { _form.HideReportProgressBar(); });
                    //если есть файл в темпе, удалим его
                    try
                    {
                        File.Delete(Path.GetTempPath() + "temp.xml");
                    } catch{}
                }
                
            }
        }

        //Делается в 2 этапа: Если есть несохраненные изменения, 
        //сохраняем xml файл в папку temp. Если все уже сохранено,
        //берем сохраненный файл. Затем преобразуем xml в html
        //с помощью одного из двух xsl файлов, которые лежат в ресурсах
        public void CreateSimpleReport(string file)
        {
            string xmlFileIn = _thereIsNotSavedData ?
                SaveXmlFileToTemp() :
                _lastXmlFile;

            new ReportThreadWithData(_form, _converterXmlTohtml,
                xmlFileIn, file, TestTask.Properties.Resources.simpleReport);

        }

        public void CreateExtendedReport(string file)
        {
            string xmlFileIn = _thereIsNotSavedData ?
                SaveXmlFileToTemp() :
                _lastXmlFile;

            new ReportThreadWithData(_form, _converterXmlTohtml,
                xmlFileIn, file, TestTask.Properties.Resources.ExtendedReport);

        }

        string SaveXmlFileToTemp()
        {
            string file = Path.GetTempPath() + "temp.xml";
            _repo.WriteAllEcologists(file, _ecos);
            return file;
        }

        #endregion


        #region work with config.cfg

        string LastSavedXmlFile()
        {
            try
            {
                using (StreamReader reader = new StreamReader(CONFIG_FILE))
                {
                    return reader.ReadLine();
                }
            }
            catch { return ""; }
        }

        void SetLastUsedXmlFile(string file)
        {
            _lastXmlFile = file;
            try
            {
                using (StreamWriter writer = new StreamWriter(CONFIG_FILE))
                {
                    writer.WriteLine(file);
                }
            }
            catch { }
        }
        #endregion

        #region auxiliary methods
        string ConstructDateString(int day, int month, int year)
        {
            return day.ToString("D2") + "."
                    + month.ToString("D2") + "."
                    + year.ToString("D4");
        }

        List<string> EcologistNames()
        {
            List<string> res = new List<string>();
            foreach (Ecologist eco in _ecos) res.Add(eco.Name);
            return res;
        }

        List<string> ProbePlaces(int ecologistIndex)
        {
            List<string> res = new List<string>();
            if(ecologistIndex< _ecos.Count && ecologistIndex>=0)
            {
                {
                    foreach (Probe probe in _ecos[ecologistIndex].Probes)
                        res.Add(probe.Place);
                }
            }
            return res;
        }

        List<string> ProbeDates(int ecologistIndex)
        {
            List<string> res = new List<string>();
            if (ecologistIndex < _ecos.Count && ecologistIndex >= 0)
            {
                foreach (Probe probe in _ecos[ecologistIndex].Probes)
                {
                    res.Add(ConstructDateString(probe.Day, probe.Month, probe.Year));
                }
            }
            return res;
        }
        #endregion

        
    }
}
