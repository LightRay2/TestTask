using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using TestTask.Properties;

namespace TestTask
{
    public partial class FormMain : Form
    {
        Controller _cont;


        //Используя одни и те же компоненты,
        //можно изменять и добавлять новую запись. Это переключатели.
        //true - добавляем новую, false - изменяем выделенную
        bool _addNewEcologist;
        bool _addNewProbe;

        public FormMain()
        {
            InitializeComponent();

            IRepository repo = new XMLRepository();
            _cont = new Controller(this,repo);

            /*
            List<Ecologist> ecos = repo.ReadAllEcologists("company.xml");
            repo.WriteAllEcologists("company2.xml", ecos);

            ConverterXmlToHtml conv = new ConverterXmlToHtml();
            conv.ConverUsingXsl("company.xml", Resources.simpleReport, "companySimple.html");
            conv.ConverUsingXsl("company.xml", Resources.ExtendedReport, "companyExtended.html");
            */
        }

        void Message(string text)
        {
            StatusStrip.Text = text;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            GroupChangeEco.Visible = false;
            GroupChangeProbe.Visible = false;
        }

        #region methods for edit panel


        private void BAddProbe_Click(object sender, EventArgs e)
        {
            GroupChangeProbe.Visible = !GroupChangeProbe.Visible;
        }
        #endregion

        #region Main menu - data
        private void MILoadData_Click(object sender, EventArgs e)
        {
            DialogOpenFile.FileName = _cont.LastXmlFile;
            if (DialogOpenFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _cont.ReadFromXMLFile(DialogOpenFile.FileName);
            }
        }

        private void MISaveDataAs_Click(object sender, EventArgs e)
        {
            DialogSaveFile.FileName = _cont.LastXmlFile;
            if (DialogSaveFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _cont.SaveToXmlFile(DialogSaveFile.FileName);
            }
        }

        private void MISaveData_Click(object sender, EventArgs e)
        {
            _cont.SaveToXmlFile();
        }
        #endregion

        #region public methods for controller
        public void FillEcologists(List<string> ecoNames)
        {
            GridEcologists.Rows.Clear();
            GridEcologists.ClearSelection();
            foreach (string name in ecoNames)
            {
                GridEcologists.Rows.Add(name);
            }
        }

        public void FillProbes(List<string> probePlaces, List<string> probeDates)
        {
            GridProbes.Rows.Clear();
            GridProbes.ClearSelection();

            for (int i = 0; i < probePlaces.Count; i++)
            {
                GridProbes.Rows.Add(probePlaces[i], probeDates[i]);
            }
            if (probePlaces.Count > 0) GridProbes.Rows[0].Selected = true;
        }
        #endregion

        public void DeleteEcologist(int index)
        {
            GridEcologists.Rows.RemoveAt(index);
        }
        public void ChangeEcologist(int index, string newName)
        {
            GridEcologists.Rows[index].SetValues(newName);
        }
        public void AddEcologist(string newName)
        {
            GridEcologists.Rows.Add(newName);
        }

        private void BDeleteEcologist_Click(object sender, EventArgs e)
        {
            List<int> indexes = new List<int>();
            
            foreach(DataGridViewRow row in GridEcologists.SelectedRows)
            {
                indexes.Add(GridEcologists.Rows.IndexOf(row));
            }

            _cont.DeleteEcologists(indexes);
            
        }

        private void BChangeEcologist_Click(object sender, EventArgs e)
        {
            GroupChangeEco.Visible = !GroupChangeEco.Visible;
            _addNewEcologist = false;
            if (GridEcologists.SelectedRows.Count > 0)
                TBEcoName.Text = GridEcologists.SelectedRows[0].Cells[0].Value.ToString();
        }


        private void BAddEcologist_Click(object sender, EventArgs e)
        {
            GroupChangeEco.Visible = !GroupChangeEco.Visible;
            _addNewEcologist = true;
            TBEcoName.Text = "эколог" + GridEcologists.Rows.Count.ToString();
        }

        private void BEcoOK_Click(object sender, EventArgs e)
        {
            if (_addNewEcologist)
            {
                _cont.AddEcologist(TBEcoName.Text);
                GroupChangeEco.Visible = false;
                GridEcologists.ClearSelection();
                GridEcologists.Rows[GridEcologists.Rows.Count - 1].Selected = true;
            }
            else
            {
                if(GridEcologists.SelectedRows.Count>0)
                {
                    DataGridViewRow row = GridEcologists.SelectedRows[0];
                    _cont.ChangeEcologist(GridEcologists.Rows.IndexOf(row),
                        TBEcoName.Text);
                }
                GroupChangeEco.Visible = false;
            }
        }

    }
}
