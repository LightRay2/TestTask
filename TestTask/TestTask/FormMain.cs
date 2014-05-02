using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using TestTask.Properties;

namespace TestTask
{
    public partial class FormMain : Form
    {
        /* Как все работает:
         * У формы есть только ссылка на контроллер. В ответ на любое действие пользователя
         * форма вызывает соответствующий public-метод контроллера. Контроллер, в свою очередь, изменяет 
         * данные и вызывает один из публичных методов формы для отображения изменений. Для общения с 
         * пользователем контроллер вызывает один из методов - StatusMessage(для вывода в статус бар) или
         * ErrorMessage - для вывода сообщения в отдельном окошке.
         * 
         * Контроллеру в конструктор передается 2 класса-помощника - класс для работы с xml файлами и
         * класс для формирования html отчета с использованием xsl. (сами xsl-файлы лежат в ресурсах проекта) 
         


         */
        #region init
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
        #endregion



        #region user clicks data menu (to controller)

        private void MINewProject_Click(object sender, EventArgs e)
        {
            if (_cont.TherIsNotSavedData) OfferUserToSaveData();
            _cont.StartNewProject();
        }

        private void MILoadData_Click(object sender, EventArgs e)
        {
            if (_cont.TherIsNotSavedData) OfferUserToSaveData();
            DialogOpenFile.Filter = "xml|*.xml";
            DialogOpenFile.FileName = _cont.LastXmlFile;
            if (DialogOpenFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _cont.ReadFromXMLFile(DialogOpenFile.FileName);
            }
        }

        private void MISaveDataAs_Click(object sender, EventArgs e)
        {
            DialogSaveFile.Filter = "xml|*.xml";
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
            if(GridEcologists.SelectedRows.Count==0)
                _cont.EcologistSelected(-1);
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
            if (SelectedEco() == -1) return;
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
            if (SelectedEco() == -1) return;
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

        #region user selects ecologist (to controller)
        private void GridEcologists_SelectionChanged(object sender, EventArgs e)
        {
            if (GridEcologists.SelectedRows.Count > 0)
            {
                _cont.EcologistSelected(SelectedEco());
            }
        }
        #endregion

        #region user wants to create report (to controller)
        private void MIFormSimpleReport_Click(object sender, EventArgs e)
        {
            DialogSaveFile.Filter = "html|*.html";
            if (_cont.LastXmlFile.Length > 3)
            {
                DialogSaveFile.FileName = _cont.LastXmlFile.Substring(0
                    , _cont.LastXmlFile.Length - 3) + "html";
            }
            else
            {
                DialogSaveFile.FileName = "Report.html";
            }
            if (DialogSaveFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _cont.CreateSimpleReport(DialogSaveFile.FileName);
            }
        }

        private void MIFormExtendedReport_Click(object sender, EventArgs e)
        {
            DialogSaveFile.Filter = "html|*.html";
            if (_cont.LastXmlFile.Length > 4)
            {
                DialogSaveFile.FileName = _cont.LastXmlFile.Substring(0
                    , _cont.LastXmlFile.Length - 4) + "ExtendedReport.html";
            }
            else
            {
                DialogSaveFile.FileName = "ExtendedReport.html";
            }
            if (DialogSaveFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _cont.CreateExtendedReport(DialogSaveFile.FileName);
            }
        }
        #endregion

        #region form closing
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_cont.TherIsNotSavedData) OfferUserToSaveData();
        }
        #endregion



        #region public fill data grids methods (for controller)
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

        #region public methods for progress bar (for controller)
        public void SetReportProgressBar(int percent)
        {
            PBReport.Visible = true;
            PBReport.Value = percent;
        }

        public void HideReportProgressBar()
        {
            PBReport.Visible = false;
        }
        #endregion

        #region public methods - messages for user (for controller)
        public void StatusMessage(string text)
        {
            StatusStrip.Text = text;
        }

        public void ErrorMessage(string text)
        {
            MessageBox.Show(text);
        }
        #endregion



        #region auxuliary methods 

        void OfferUserToSaveData()
        {
            DialogResult dr = MessageBox.Show(
                "У вас есть несохраненные данные. Сохранить?", 
                "Предупреждение", MessageBoxButtons.YesNo);
            if (dr == System.Windows.Forms.DialogResult.Yes)
            {
                MISaveDataAs_Click(this, new EventArgs());
            }
        }

        int SelectedEco()
        {
            if (GridEcologists.SelectedRows.Count > 0)
            {
                DataGridViewRow row = GridEcologists.SelectedRows[0];
                return GridEcologists.Rows.IndexOf(row);
            }
            else return -1;
        }

        int SelectedProbe()
        {
            if (GridProbes.SelectedRows.Count > 0)
            {
                DataGridViewRow row = GridProbes.SelectedRows[0];
                return GridProbes.Rows.IndexOf(row);
            }
            else return -1;
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


    }
}
