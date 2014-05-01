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

            //форма не должна знать, как создавать контроллер
            _cont = ControllerFactory.CreateController(this);
        }

        

        private void FormMain_Load(object sender, EventArgs e)
        {
            GroupChangeEco.Visible = false;
            GroupChangeProbe.Visible = false;
            PBReport.Visible = false;
            FillProbeComboBoxes();
            this.Size = new Size(
                GroupChangeProbe.Location.X + GroupChangeProbe.Size.Width + 200,
                GroupChangeProbe.Location.Y + GroupChangeProbe.Size.Height + 200
                );
        }

        

        #region Main menu - data(to controller)
        private void MINewProject_Click(object sender, EventArgs e)
        {
            _cont.StartNewProject();
        }

        private void MILoadData_Click(object sender, EventArgs e)
        {
            DialogOpenFile.Filter = "*.xml";
            DialogOpenFile.FileName = _cont.LastXmlFile;
            if (DialogOpenFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _cont.ReadFromXMLFile(DialogOpenFile.FileName);
            }
        }

        private void MISaveDataAs_Click(object sender, EventArgs e)
        {
            DialogSaveFile.Filter = "*.xml";
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

        #region user events editing ecologistGrid (to controller)
        private void BDeleteEcologist_Click(object sender, EventArgs e)
        {
            List<int> indexes = new List<int>();
            foreach (DataGridViewRow row in GridEcologists.SelectedRows)
            {
                indexes.Add(GridEcologists.Rows.IndexOf(row));
            }
            _cont.DeleteEcologists(indexes);
        }

        private void BChangeEcologist_Click(object sender, EventArgs e)
        {
            if (GridEcologists.SelectedRows.Count > 0)
            {
                TBEcoName.Text = GridEcologists.SelectedRows[0].Cells[0].Value.ToString();
                GroupChangeEco.Visible = _addNewEcologist || !GroupChangeEco.Visible;
                _addNewEcologist = false;
            }
        }


        private void BAddEcologist_Click(object sender, EventArgs e)
        {
            GroupChangeEco.Visible = !_addNewEcologist || !GroupChangeEco.Visible;
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
                if (GridEcologists.SelectedRows.Count > 0)
                {
                    _cont.ChangeEcologist(SelectedEco(), TBEcoName.Text);
                }
                GroupChangeEco.Visible = false;
            }
        }
        #endregion

        #region user events editing probes (to controller)

        private void BDeleteProbe_Click(object sender, EventArgs e)
        {
            List<int> indexes = new List<int>();
            foreach (DataGridViewRow row in GridProbes.SelectedRows)
            {
                indexes.Add(GridProbes.Rows.IndexOf(row));
            }
            _cont.DeleteProbes(SelectedEco(), indexes);
        }

        private void BChangeProbe_Click(object sender, EventArgs e)
        {
            if (GridProbes.SelectedRows.Count > 0)
            {
                TBProbePlace.Text = GridProbes.SelectedRows[0].Cells[0].Value.ToString();
                string date = GridProbes.SelectedRows[0].Cells[1].Value.ToString();
                CBProbeDay.SelectedItem = date.Substring(0, 2);
                CBProbeMonth.SelectedItem = date.Substring(3, 2);
                CBProbeYear.SelectedItem = date.Substring(6, 4);

                GroupChangeProbe.Visible = _addNewProbe || !GroupChangeProbe.Visible;
                _addNewProbe = false;
            }
        }

        private void BAddProbe_Click(object sender, EventArgs e)
        {
            TBProbePlace.Text = "место" + GridProbes.Rows.Count.ToString();
            CBProbeDay.SelectedIndex = 0;
            CBProbeMonth.SelectedIndex = 0;
            CBProbeYear.SelectedIndex = 0;

            GroupChangeProbe.Visible = !_addNewProbe || !GroupChangeProbe.Visible;
            _addNewProbe = true;
        }

        private void BProbeOK_Click(object sender, EventArgs e)
        {
            if (_addNewProbe)
            {
                _cont.AddProbe(SelectedEco(), TBProbePlace.Text,
                    Int32.Parse(CBProbeDay.SelectedItem.ToString()),
                    Int32.Parse(CBProbeMonth.SelectedItem.ToString()),
                    Int32.Parse(CBProbeYear.SelectedItem.ToString()));
                GroupChangeProbe.Visible = false;
                GridProbes.ClearSelection();
                GridProbes.Rows[GridProbes.Rows.Count - 1].Selected = true;
            }
            else
            {
                if (GridProbes.SelectedRows.Count > 0)
                {
                    _cont.ChangeProbe(SelectedEco(), SelectedProbe(), TBProbePlace.Text,
                        Int32.Parse(CBProbeDay.SelectedItem.ToString()),
                        Int32.Parse(CBProbeMonth.SelectedItem.ToString()),
                        Int32.Parse(CBProbeYear.SelectedItem.ToString()));
                }
                GroupChangeProbe.Visible = false;
            }
        }
        #endregion

        #region user selects ecologist
        private void GridEcologists_SelectionChanged(object sender, EventArgs e)
        {
            if (GridEcologists.SelectedRows.Count > 0)
            {
                _cont.EcologistSelected(SelectedEco());
            }
        }
        #endregion

        #region public fill methods (for controller)
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

        #region public methods editing ecologists (for controller)
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

        #endregion

        #region public methods editing probes (for controller)
        public void DeleteProbe(int index)
        {
            GridProbes.Rows.RemoveAt(index);
        }
        public void ChangeProbe(int index, string newPlace, string newDate)
        {
            GridProbes.Rows[index].SetValues(newPlace, newDate);
        }
        public void AddProbe(string newPlace, string newDate)
        {
            GridProbes.Rows.Add(newPlace, newDate);
        }

        #endregion



        public void SetReportProgressBar(int percent)
        {
            PBReport.Visible = true;
            PBReport.Value = percent;
        }

        public void HideReportProgressBar()
        {
            PBReport.Visible = false;
        }

        

        #region auxuliary methods
        void Message(string text)
        {
            StatusStrip.Text = text;
        }

        int SelectedEco()
        {
            DataGridViewRow row = GridEcologists.SelectedRows[0];
            return GridEcologists.Rows.IndexOf(row);
        }

        int SelectedProbe()
        {
            DataGridViewRow row = GridProbes.SelectedRows[0];
            return GridProbes.Rows.IndexOf(row);
        }
        void FillProbeComboBoxes()
        {
            for (int i = 1; i <= 31; i++)
                CBProbeDay.Items.Add(i.ToString("D2"));
            for (int i = 1; i <= 12; i++)
                CBProbeMonth.Items.Add(i.ToString("D2"));
            for (int i = 2000; i <= 2050; i++)
                CBProbeYear.Items.Add(i.ToString("D4"));
        }
        #endregion

        private void MIFormSimpleReport_Click(object sender, EventArgs e)
        {
            DialogSaveFile.Filter = "html|*.html";
            DialogSaveFile.FileName = _cont.LastXmlFile.Substring(0
                ,_cont.LastXmlFile.Length-3) + "html";
            if (DialogSaveFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _cont.CreateSimpleReport(DialogSaveFile.FileName);
            }
        }

        private void MIFormExtendedReport_Click(object sender, EventArgs e)
        {
            DialogSaveFile.Filter = "*.html";
            DialogSaveFile.FileName = _cont.LastXmlFile.Substring(0
                , _cont.LastXmlFile.Length - 3) + "html";
            if (DialogSaveFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _cont.CreateExtendedReport(DialogSaveFile.FileName);
            }
        }

    }
}
