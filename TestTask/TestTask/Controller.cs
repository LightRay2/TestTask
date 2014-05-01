using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace TestTask
{
    class Controller
    {
        IRepository _repo;
        List<Ecologist> _ecos;
        FormMain _form;

        string _configFile  = Path.GetDirectoryName(Application.ExecutablePath)+ "//config.cfg";
        string _lastXmlFile = "";

        public Controller(FormMain form, IRepository repo)
        {
            this._form = form;
            this._repo = repo;

            
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

        #region public load-save methods

        public string LastXmlFile { get { return _lastXmlFile; } }

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
            if(_ecos.Count > 0)
                _form.FillProbes(ProbePlaces(0), ProbeDates(0));

            SetLastUsedXmlFile(file);
        }

        #endregion

        #region auxiliary methods
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
                res.Add(probe.Day.ToString("D2") + "."
                    + probe.Month.ToString("D2") + "."
                    + probe.Year.ToString("D4"));
            }
            return res;
        }
        #endregion

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

    }
}
