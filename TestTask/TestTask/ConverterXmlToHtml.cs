using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Xsl;
using System.Xml;
using System.IO;

namespace TestTask
{
    class ConverterXmlToHtml:IConverterXmlToHtml
    {
        public void ConverUsingXsl(string inputXml, string xsltString, string outputHtml)
        {
            // Load the style sheet.
            XslCompiledTransform xslt = new XslCompiledTransform();
            using (XmlReader reader = XmlReader.Create(new StringReader(xsltString)))
            {
                xslt.Load(reader);
            }

            // Execute the transform and output the results to a file.
            xslt.Transform(inputXml, outputHtml);
            
        }
    }
}
