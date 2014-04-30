using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestTask
{
    class Ecologist
    {
        public Ecologist()
        {
            this.Probes = new List<Probe>();
        }
        public Ecologist(string name, List<Probe> probes)
        {
            this.Name = name;
            this.Probes = probes;
        }
        public string Name { get; set; }
        public List<Probe> Probes { get; set; }
    }
}
