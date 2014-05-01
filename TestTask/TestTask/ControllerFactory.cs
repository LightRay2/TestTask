using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestTask
{
    static class ControllerFactory
    {
        public static Controller CreateController(FormMain form)
        {
            return new Controller(form, new XMLRepository(), new ConverterXmlToHtml());
        }
    }
}
