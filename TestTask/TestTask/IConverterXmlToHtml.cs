using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestTask
{
    interface IConverterXmlToHtml
    {
        void ConverUsingXsl(string inputXml, string xsltString, string outputHtml);
    }
}
