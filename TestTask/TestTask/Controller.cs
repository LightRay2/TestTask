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
        IRepository _repo;
        IConverterXmlToHtml _converterXmlTohtml;
        List<Ecologist> _ecos;
        FormMain _form;

        string _configFile  = Path.GetDirectoryName(Application.ExecutablePath)+ "//config.cfg";
        string _lastXmlFile = "";

        //delegate void SetProgressBar

        public Controller(FormMain form, IRepository repo, IConverterXmlToHtml conv)
        {
            this._form = form;
            this._repo = repo;
            this._converterXmlTohtml = conv;

            
            string lastXml = LastSavedXmlFile();
            if(lastXml != "")
                ReadFromXMLFile(lastXml);
            else
                _ecos = new List<Ecologist>();
            
        }

        #region work with config.cfg


        string LastSavedXmlFile()
        {
            try
            {
                using (StreamReader reader = new StreamReader(_configFile))
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
                using (StreamWriter writer = new StreamWriter(_configFile))
                {
                    writer.WriteLine(file);
                }
            }
            catch { }
        }
        #endregion

        #region public load-save-new methods

        public string LastXmlFile { get { return _lastXmlFile; } }

        public void StartNewProject()
        {
            _ecos = new List<Ecologist>();
            _form.FillEcologists(new List<string>());
            _form.FillProbes(new List<string>(), new List<string>());
            _lastXmlFile = ""; //чтобы предотвратить сохранение нового проекта в предыдущий
        }

        public void SaveToXmlFile()
        {
            string lastFile;
            try
            {
                lastFile = LastSavedXmlFile();
            }
            catch
            {
                throw new Exception("Не удалось сохранить файл. Воспользуйтесь \"Сохранить как ...\" ");
            }
            SaveToXmlFile(lastFile);
        }

        public void SaveToXmlFile(string file)
        {
            _repo.WriteAllEcologists(file, _ecos);
            SetLastUsedXmlFile(file);
        }

        public void ReadFromXMLFile(string file)
        {
            _ecos = _repo.ReadAllEcologists(file);
            _form.FillEcologists(EcologistNames());
            if (_ecos.Count > 0)
                _form.FillProbes(ProbePlaces(0), ProbeDates(0));
            else
                _form.FillProbes(new List<string>(), new List<string>());

            SetLastUsedXmlFile(file);
        }

        #endregion

        #region EcologistEdit

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
        }

        public void ChangeEcologist(int index, string newName)
        {
            _ecos[index].Name = newName;
            _form.ChangeEcologist(index, newName);
        }

        public void AddEcologist(string newName)
        {
            _ecos.Add(new Ecologist(newName, new List<Probe>()));
            _form.AddEcologist(newName);
        }
        #endregion

        #region ProbesEdit

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
        }

        public void AddProbe(int ecoIndex, string place, int day, int month, int year)
        {
            _ecos[ecoIndex].Probes.Add(new Probe(place, day, month, year));
            _form.AddProbe( place, ConstructDateString(day,month,year));
        }
        #endregion

        #region Eco selected method
        public void EcologistSelected(int index)
        {
            _form.FillProbes(ProbePlaces(index), ProbeDates(index));
        }
        #endregion

        //Свои данные для каждого потока
        [ThreadStaticAttribute]
        static string _xmlInFile;
        [ThreadStaticAttribute]
        static string _htmlOutFile;
        [ThreadStaticAttribute]
        static string _xslString;
        public void CreateSimpleReport(string file)
        {
            SaveToXmlFile();
            _xmlInFile = _lastXmlFile;
            _htmlOutFile = file;
            _xslString = TestTask.Properties.Resources.simpleReport;

            Thread convertion = new Thread(new ThreadStart(StartConversionThread));
            convertion.SetApartmentState(ApartmentState.STA);
            convertion.Start();
        }

        public void CreateExtendedReport(string file)
        {
            SaveToXmlFile();
            _xmlInFile = _lastXmlFile;
            _htmlOutFile = file;
            _xslString = TestTask.Properties.Resources.ExtendedReport;
            //http://msdn.microsoft.com/en-us/library/ts553s52(v=vs.90).aspx
            ThreadW
            Thread convertion = new Thread(new ThreadStart(StartConversionThread));
            convertion.SetApartmentState(ApartmentState.STA);
            convertion.ThreadState.
            convertion.Start();
        }

        void SetConvertionData(string xmlFile, string htmlOutFile, string xslString)
        {

        }

        void StartConversionThread()
        {
            for (int i = 0; i < 100; i += 5)
            {
                _form.Invoke((MethodInvoker)delegate{ _form.SetReportProgressBar(i);});
                Thread.Sleep(100);
            }
            _converterXmlTohtml.ConverUsingXsl(_xmlInFile, _xslString, _htmlOutFile);
            _form.HideReportProgressBar();
        }


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
            foreach (Probe probe in _ecos[ecologistIndex].Probes)
                res.Add(probe.Place);
            return res;
        }

        List<string> ProbeDates(int ecologistIndex)
        {
            List<string> res = new List<string>();
            foreach (Probe probe in _ecos[ecologistIndex].Probes)
            {
                res.Add(ConstructDateString(probe.Day, probe.Month, probe.Year));
            }
            return res;
        }
        #endregion

        
    }
}
