using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestTask
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            IRepository repo = new XMLRepository();
            /*Ecologist[] ecos = new Ecologist[]{
                new Ecologist{
                    Probes = new ListProbe[]{
                        new Probe("колхоз светлый путь", 9,6,2012),
                        new Probe("колхоз светлый путь", 12,7,2011)
                    }
                },
                new Ecologist{
                    Probes = new Probe[]{
                        
                        new Probe("водоочистные сооружения", 11,9,2013),
                        new Probe("водоочистные сооружения", 11,2,2014)
                    }}
            };

            repo.WriteEcologistsToXML("company.xml", ecos);*/

            List<Ecologist> ecos = repo.ReadAllEcologists("company.xml");
            repo.WriteAllEcologists("company2.xml", ecos);
        }
    }
}
