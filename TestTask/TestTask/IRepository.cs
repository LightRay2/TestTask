using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestTask
{
    interface IRepository
    {
        List<Ecologist> ReadAllEcologists(string file);
        void WriteAllEcologists(string file, List<Ecologist> ecologists);
    }
}
