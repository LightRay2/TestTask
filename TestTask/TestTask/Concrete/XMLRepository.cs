using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace TestTask
{
    class XMLRepository:IRepository
    {
        #region reading

        //все проверки на соответствие формату включены

        void Exc()
        {
            throw new Exception("Неверный формат xml");
        }

        public List<Ecologist> ReadAllEcologists(string file)
        {
            List<Ecologist> res = new List<Ecologist>();
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.Load(file);
            } 
            catch{
                Exc();
            }

            XmlElement root = doc.DocumentElement;
            if (root.LocalName != "company") Exc();

            foreach (XmlNode ecologist in root.ChildNodes)
            {
                if (ecologist.LocalName != "ecologist" ||
                    ecologist.ChildNodes.Count < 1)
                {
                    Exc();
                }
                XmlNode name = ecologist.ChildNodes[0];
                if (name.LocalName != "name") Exc();
                Ecologist eco = new Ecologist();
                eco.Name = name.InnerText;
                for(int i = 1; i < ecologist.ChildNodes.Count; i++)
                {

                    //Проверка пробы громоздкая, поэтому вынесена в отдельную фнкцию
                    Probe newProbe = ParseProbe(ecologist.ChildNodes[i]);
                    
                    if ( newProbe== null) Exc();
                    eco.Probes.Add(newProbe);
                }
                res.Add(eco);
            }

            return res;

        }

        Probe ParseProbe(XmlNode probe)
        {

            if (probe.LocalName != "probe") return null;

            if (probe.ChildNodes.Count != 4) return null;
            XmlNode place = probe.ChildNodes[0],
                day = probe.ChildNodes[1],
                month = probe.ChildNodes[2],
                year = probe.ChildNodes[3];

            if (place.LocalName != "place"
                || day.LocalName != "day"
                || month.LocalName != "month"
                || year.LocalName != "year")
            {
                return null;
            }

            Probe pr = new Probe();
            pr.Place = place.InnerText;
            pr.Day = Int32.Parse(day.InnerText);
            pr.Month = Int32.Parse(month.InnerText);
            pr.Year = Int32.Parse(year.InnerText);

            return pr;
        }
        #endregion

        #region writing
        public void WriteAllEcologists(string file, List<Ecologist> ecologists)
        {
            using (XmlTextWriter writer = new XmlTextWriter(file,Encoding.UTF8))
            {
                writer.Formatting = Formatting.Indented;
                writer.Indentation = 1;
                writer.IndentChar = '\t';

                writer.WriteStartDocument();
                writer.WriteStartElement("company");
                foreach(var eco in ecologists){

                    writer.WriteStartElement("ecologist");
                    writer.WriteElementString("name", eco.Name);
                    foreach(var probe in eco.Probes)
                    {
                        writer.WriteStartElement("probe");

                        writer.WriteElementString("place", probe.Place);
                        writer.WriteElementString("day", probe.Day.ToString("D2"));
                        writer.WriteElementString("month", probe.Month.ToString("D2"));
                        writer.WriteElementString("year", probe.Year.ToString("D4"));

                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }

        }
        #endregion
    }
}
