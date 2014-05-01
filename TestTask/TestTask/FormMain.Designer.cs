﻿namespace TestTask
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MenuMain = new System.Windows.Forms.MenuStrip();
            this.данныеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MILoadData = new System.Windows.Forms.ToolStripMenuItem();
            this.MISaveData = new System.Windows.Forms.ToolStripMenuItem();
            this.MISaveDataAs = new System.Windows.Forms.ToolStripMenuItem();
            this.отчетToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MIFormSimpleReport = new System.Windows.Forms.ToolStripMenuItem();
            this.MIFormExtendedReport = new System.Windows.Forms.ToolStripMenuItem();
            this.GridEcologists = new System.Windows.Forms.DataGridView();
            this.GridProbes = new System.Windows.Forms.DataGridView();
            this.LEcologists = new System.Windows.Forms.Label();
            this.LProbes = new System.Windows.Forms.Label();
            this.BDeleteEcologist = new System.Windows.Forms.Button();
            this.BChangeEcologist = new System.Windows.Forms.Button();
            this.BDeleteProbe = new System.Windows.Forms.Button();
            this.BChangeProbe = new System.Windows.Forms.Button();
            this.TBEcoName = new System.Windows.Forms.TextBox();
            this.BEcoOK = new System.Windows.Forms.Button();
            this.BProbeOK = new System.Windows.Forms.Button();
            this.TBProbePlace = new System.Windows.Forms.TextBox();
            this.LEcoName = new System.Windows.Forms.Label();
            this.LProbePlace = new System.Windows.Forms.Label();
            this.CBProbeDay = new System.Windows.Forms.ComboBox();
            this.CBProbeMonth = new System.Windows.Forms.ComboBox();
            this.CBProbeYear = new System.Windows.Forms.ComboBox();
            this.LProbeDay = new System.Windows.Forms.Label();
            this.LProbeMonth = new System.Windows.Forms.Label();
            this.LProbeYear = new System.Windows.Forms.Label();
            this.BAddEcologist = new System.Windows.Forms.Button();
            this.BAddProbe = new System.Windows.Forms.Button();
            this.GroupChangeEco = new System.Windows.Forms.GroupBox();
            this.GroupChangeProbe = new System.Windows.Forms.GroupBox();
            this.DialogSaveFile = new System.Windows.Forms.SaveFileDialog();
            this.DialogOpenFile = new System.Windows.Forms.OpenFileDialog();
            this.EcoName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Place = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.MenuMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridEcologists)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridProbes)).BeginInit();
            this.GroupChangeEco.SuspendLayout();
            this.GroupChangeProbe.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuMain
            // 
            this.MenuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.данныеToolStripMenuItem,
            this.отчетToolStripMenuItem});
            this.MenuMain.Location = new System.Drawing.Point(0, 0);
            this.MenuMain.Name = "MenuMain";
            this.MenuMain.Size = new System.Drawing.Size(923, 29);
            this.MenuMain.TabIndex = 0;
            this.MenuMain.Text = "Главное меню";
            // 
            // данныеToolStripMenuItem
            // 
            this.данныеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MILoadData,
            this.MISaveData,
            this.MISaveDataAs});
            this.данныеToolStripMenuItem.Name = "данныеToolStripMenuItem";
            this.данныеToolStripMenuItem.Size = new System.Drawing.Size(84, 25);
            this.данныеToolStripMenuItem.Text = "Данные";
            // 
            // MILoadData
            // 
            this.MILoadData.Name = "MILoadData";
            this.MILoadData.Size = new System.Drawing.Size(229, 26);
            this.MILoadData.Text = "Загрузить";
            this.MILoadData.Click += new System.EventHandler(this.MILoadData_Click);
            // 
            // MISaveData
            // 
            this.MISaveData.Name = "MISaveData";
            this.MISaveData.Size = new System.Drawing.Size(229, 26);
            this.MISaveData.Text = "Сохранить";
            this.MISaveData.Click += new System.EventHandler(this.MISaveData_Click);
            // 
            // MISaveDataAs
            // 
            this.MISaveDataAs.Name = "MISaveDataAs";
            this.MISaveDataAs.Size = new System.Drawing.Size(229, 26);
            this.MISaveDataAs.Text = "Сохранить как ...";
            this.MISaveDataAs.Click += new System.EventHandler(this.MISaveDataAs_Click);
            // 
            // отчетToolStripMenuItem
            // 
            this.отчетToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MIFormSimpleReport,
            this.MIFormExtendedReport});
            this.отчетToolStripMenuItem.Name = "отчетToolStripMenuItem";
            this.отчетToolStripMenuItem.Size = new System.Drawing.Size(68, 25);
            this.отчетToolStripMenuItem.Text = "Отчет";
            // 
            // MIFormSimpleReport
            // 
            this.MIFormSimpleReport.Name = "MIFormSimpleReport";
            this.MIFormSimpleReport.Size = new System.Drawing.Size(374, 26);
            this.MIFormSimpleReport.Text = "Сформировать простой отчет";
            // 
            // MIFormExtendedReport
            // 
            this.MIFormExtendedReport.Name = "MIFormExtendedReport";
            this.MIFormExtendedReport.Size = new System.Drawing.Size(374, 26);
            this.MIFormExtendedReport.Text = "Сформировать расширенный отчет";
            // 
            // GridEcologists
            // 
            this.GridEcologists.AllowUserToAddRows = false;
            this.GridEcologists.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridEcologists.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EcoName});
            this.GridEcologists.Location = new System.Drawing.Point(64, 81);
            this.GridEcologists.Name = "GridEcologists";
            this.GridEcologists.RowHeadersVisible = false;
            this.GridEcologists.RowTemplate.Height = 28;
            this.GridEcologists.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridEcologists.Size = new System.Drawing.Size(221, 170);
            this.GridEcologists.TabIndex = 1;
            // 
            // GridProbes
            // 
            this.GridProbes.AllowUserToAddRows = false;
            this.GridProbes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridProbes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Place,
            this.Date});
            this.GridProbes.Location = new System.Drawing.Point(420, 77);
            this.GridProbes.Name = "GridProbes";
            this.GridProbes.RowHeadersVisible = false;
            this.GridProbes.RowTemplate.Height = 28;
            this.GridProbes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridProbes.Size = new System.Drawing.Size(428, 174);
            this.GridProbes.TabIndex = 2;
            // 
            // LEcologists
            // 
            this.LEcologists.AutoSize = true;
            this.LEcologists.Location = new System.Drawing.Point(67, 45);
            this.LEcologists.Name = "LEcologists";
            this.LEcologists.Size = new System.Drawing.Size(77, 20);
            this.LEcologists.TabIndex = 3;
            this.LEcologists.Text = "Экологи:";
            // 
            // LProbes
            // 
            this.LProbes.AutoSize = true;
            this.LProbes.Location = new System.Drawing.Point(425, 46);
            this.LProbes.Name = "LProbes";
            this.LProbes.Size = new System.Drawing.Size(63, 20);
            this.LProbes.TabIndex = 4;
            this.LProbes.Text = "Пробы:";
            // 
            // BDeleteEcologist
            // 
            this.BDeleteEcologist.Location = new System.Drawing.Point(61, 252);
            this.BDeleteEcologist.Name = "BDeleteEcologist";
            this.BDeleteEcologist.Size = new System.Drawing.Size(224, 33);
            this.BDeleteEcologist.TabIndex = 5;
            this.BDeleteEcologist.Text = "Удалить запись";
            this.BDeleteEcologist.UseVisualStyleBackColor = true;
            this.BDeleteEcologist.Click += new System.EventHandler(this.BDeleteEcologist_Click);
            // 
            // BChangeEcologist
            // 
            this.BChangeEcologist.Location = new System.Drawing.Point(61, 305);
            this.BChangeEcologist.Name = "BChangeEcologist";
            this.BChangeEcologist.Size = new System.Drawing.Size(207, 30);
            this.BChangeEcologist.TabIndex = 6;
            this.BChangeEcologist.Text = "Изменить запись";
            this.BChangeEcologist.UseVisualStyleBackColor = true;
            this.BChangeEcologist.Click += new System.EventHandler(this.BChangeEcologist_Click);
            // 
            // BDeleteProbe
            // 
            this.BDeleteProbe.Location = new System.Drawing.Point(416, 257);
            this.BDeleteProbe.Name = "BDeleteProbe";
            this.BDeleteProbe.Size = new System.Drawing.Size(159, 28);
            this.BDeleteProbe.TabIndex = 7;
            this.BDeleteProbe.Text = "Удалить запись";
            this.BDeleteProbe.UseVisualStyleBackColor = true;
            // 
            // BChangeProbe
            // 
            this.BChangeProbe.Location = new System.Drawing.Point(413, 291);
            this.BChangeProbe.Name = "BChangeProbe";
            this.BChangeProbe.Size = new System.Drawing.Size(162, 36);
            this.BChangeProbe.TabIndex = 8;
            this.BChangeProbe.Text = "Изменить запись";
            this.BChangeProbe.UseVisualStyleBackColor = true;
            // 
            // TBEcoName
            // 
            this.TBEcoName.Location = new System.Drawing.Point(16, 38);
            this.TBEcoName.Name = "TBEcoName";
            this.TBEcoName.Size = new System.Drawing.Size(126, 26);
            this.TBEcoName.TabIndex = 9;
            // 
            // BEcoOK
            // 
            this.BEcoOK.Location = new System.Drawing.Point(185, 39);
            this.BEcoOK.Name = "BEcoOK";
            this.BEcoOK.Size = new System.Drawing.Size(75, 25);
            this.BEcoOK.TabIndex = 10;
            this.BEcoOK.Text = "ОК";
            this.BEcoOK.UseVisualStyleBackColor = true;
            this.BEcoOK.Click += new System.EventHandler(this.BEcoOK_Click);
            // 
            // BProbeOK
            // 
            this.BProbeOK.Location = new System.Drawing.Point(318, 98);
            this.BProbeOK.Name = "BProbeOK";
            this.BProbeOK.Size = new System.Drawing.Size(75, 25);
            this.BProbeOK.TabIndex = 12;
            this.BProbeOK.Text = "ОК";
            this.BProbeOK.UseVisualStyleBackColor = true;
            // 
            // TBProbePlace
            // 
            this.TBProbePlace.Location = new System.Drawing.Point(4, 28);
            this.TBProbePlace.Name = "TBProbePlace";
            this.TBProbePlace.Size = new System.Drawing.Size(126, 26);
            this.TBProbePlace.TabIndex = 11;
            // 
            // LEcoName
            // 
            this.LEcoName.AutoSize = true;
            this.LEcoName.Location = new System.Drawing.Point(15, 15);
            this.LEcoName.Name = "LEcoName";
            this.LEcoName.Size = new System.Drawing.Size(51, 20);
            this.LEcoName.TabIndex = 13;
            this.LEcoName.Text = "ФИО:";
            // 
            // LProbePlace
            // 
            this.LProbePlace.AutoSize = true;
            this.LProbePlace.Location = new System.Drawing.Point(8, 3);
            this.LProbePlace.Name = "LProbePlace";
            this.LProbePlace.Size = new System.Drawing.Size(61, 20);
            this.LProbePlace.TabIndex = 14;
            this.LProbePlace.Text = "Место:";
            // 
            // CBProbeDay
            // 
            this.CBProbeDay.FormattingEnabled = true;
            this.CBProbeDay.Location = new System.Drawing.Point(2, 97);
            this.CBProbeDay.Name = "CBProbeDay";
            this.CBProbeDay.Size = new System.Drawing.Size(68, 28);
            this.CBProbeDay.TabIndex = 15;
            // 
            // CBProbeMonth
            // 
            this.CBProbeMonth.FormattingEnabled = true;
            this.CBProbeMonth.Location = new System.Drawing.Point(89, 97);
            this.CBProbeMonth.Name = "CBProbeMonth";
            this.CBProbeMonth.Size = new System.Drawing.Size(61, 28);
            this.CBProbeMonth.TabIndex = 16;
            // 
            // CBProbeYear
            // 
            this.CBProbeYear.FormattingEnabled = true;
            this.CBProbeYear.Location = new System.Drawing.Point(177, 95);
            this.CBProbeYear.Name = "CBProbeYear";
            this.CBProbeYear.Size = new System.Drawing.Size(102, 28);
            this.CBProbeYear.TabIndex = 17;
            // 
            // LProbeDay
            // 
            this.LProbeDay.AutoSize = true;
            this.LProbeDay.Location = new System.Drawing.Point(2, 63);
            this.LProbeDay.Name = "LProbeDay";
            this.LProbeDay.Size = new System.Drawing.Size(52, 20);
            this.LProbeDay.TabIndex = 18;
            this.LProbeDay.Text = "День:";
            // 
            // LProbeMonth
            // 
            this.LProbeMonth.AutoSize = true;
            this.LProbeMonth.Location = new System.Drawing.Point(85, 63);
            this.LProbeMonth.Name = "LProbeMonth";
            this.LProbeMonth.Size = new System.Drawing.Size(61, 20);
            this.LProbeMonth.TabIndex = 19;
            this.LProbeMonth.Text = "Месяц:";
            // 
            // LProbeYear
            // 
            this.LProbeYear.AutoSize = true;
            this.LProbeYear.Location = new System.Drawing.Point(173, 63);
            this.LProbeYear.Name = "LProbeYear";
            this.LProbeYear.Size = new System.Drawing.Size(42, 20);
            this.LProbeYear.TabIndex = 20;
            this.LProbeYear.Text = "Год:";
            // 
            // BAddEcologist
            // 
            this.BAddEcologist.Location = new System.Drawing.Point(64, 350);
            this.BAddEcologist.Name = "BAddEcologist";
            this.BAddEcologist.Size = new System.Drawing.Size(177, 30);
            this.BAddEcologist.TabIndex = 21;
            this.BAddEcologist.Text = "Добавить запись";
            this.BAddEcologist.UseVisualStyleBackColor = true;
            this.BAddEcologist.Click += new System.EventHandler(this.BAddEcologist_Click);
            // 
            // BAddProbe
            // 
            this.BAddProbe.Location = new System.Drawing.Point(416, 350);
            this.BAddProbe.Name = "BAddProbe";
            this.BAddProbe.Size = new System.Drawing.Size(163, 30);
            this.BAddProbe.TabIndex = 22;
            this.BAddProbe.Text = "Добавить запись";
            this.BAddProbe.UseVisualStyleBackColor = true;
            this.BAddProbe.Click += new System.EventHandler(this.BAddProbe_Click);
            // 
            // GroupChangeEco
            // 
            this.GroupChangeEco.Controls.Add(this.BEcoOK);
            this.GroupChangeEco.Controls.Add(this.TBEcoName);
            this.GroupChangeEco.Controls.Add(this.LEcoName);
            this.GroupChangeEco.Location = new System.Drawing.Point(61, 397);
            this.GroupChangeEco.Name = "GroupChangeEco";
            this.GroupChangeEco.Size = new System.Drawing.Size(266, 86);
            this.GroupChangeEco.TabIndex = 23;
            this.GroupChangeEco.TabStop = false;
            // 
            // GroupChangeProbe
            // 
            this.GroupChangeProbe.Controls.Add(this.LProbeYear);
            this.GroupChangeProbe.Controls.Add(this.LProbeMonth);
            this.GroupChangeProbe.Controls.Add(this.LProbeDay);
            this.GroupChangeProbe.Controls.Add(this.CBProbeYear);
            this.GroupChangeProbe.Controls.Add(this.CBProbeMonth);
            this.GroupChangeProbe.Controls.Add(this.CBProbeDay);
            this.GroupChangeProbe.Controls.Add(this.LProbePlace);
            this.GroupChangeProbe.Controls.Add(this.BProbeOK);
            this.GroupChangeProbe.Controls.Add(this.TBProbePlace);
            this.GroupChangeProbe.Location = new System.Drawing.Point(414, 385);
            this.GroupChangeProbe.Name = "GroupChangeProbe";
            this.GroupChangeProbe.Size = new System.Drawing.Size(404, 141);
            this.GroupChangeProbe.TabIndex = 24;
            this.GroupChangeProbe.TabStop = false;
            // 
            // DialogOpenFile
            // 
            this.DialogOpenFile.FileName = "openFileDialog1";
            // 
            // EcoName
            // 
            this.EcoName.HeaderText = "ФИО";
            this.EcoName.Name = "EcoName";
            this.EcoName.ReadOnly = true;
            this.EcoName.Width = 200;
            // 
            // Place
            // 
            this.Place.HeaderText = "Место";
            this.Place.Name = "Place";
            this.Place.ReadOnly = true;
            this.Place.Width = 300;
            // 
            // Date
            // 
            this.Date.HeaderText = "Время";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            // 
            // StatusStrip
            // 
            this.StatusStrip.Location = new System.Drawing.Point(0, 600);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Size = new System.Drawing.Size(923, 22);
            this.StatusStrip.TabIndex = 25;
            this.StatusStrip.Text = "готово";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 622);
            this.Controls.Add(this.StatusStrip);
            this.Controls.Add(this.GroupChangeProbe);
            this.Controls.Add(this.GroupChangeEco);
            this.Controls.Add(this.BAddProbe);
            this.Controls.Add(this.BAddEcologist);
            this.Controls.Add(this.BChangeProbe);
            this.Controls.Add(this.BDeleteProbe);
            this.Controls.Add(this.BChangeEcologist);
            this.Controls.Add(this.BDeleteEcologist);
            this.Controls.Add(this.LProbes);
            this.Controls.Add(this.LEcologists);
            this.Controls.Add(this.GridProbes);
            this.Controls.Add(this.GridEcologists);
            this.Controls.Add(this.MenuMain);
            this.MainMenuStrip = this.MenuMain;
            this.Name = "FormMain";
            this.Text = "FormMain";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.MenuMain.ResumeLayout(false);
            this.MenuMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridEcologists)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridProbes)).EndInit();
            this.GroupChangeEco.ResumeLayout(false);
            this.GroupChangeEco.PerformLayout();
            this.GroupChangeProbe.ResumeLayout(false);
            this.GroupChangeProbe.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuMain;
        private System.Windows.Forms.ToolStripMenuItem данныеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MILoadData;
        private System.Windows.Forms.ToolStripMenuItem MISaveData;
        private System.Windows.Forms.DataGridView GridEcologists;
        private System.Windows.Forms.DataGridView GridProbes;
        private System.Windows.Forms.Label LEcologists;
        private System.Windows.Forms.Label LProbes;
        private System.Windows.Forms.Button BDeleteEcologist;
        private System.Windows.Forms.Button BChangeEcologist;
        private System.Windows.Forms.Button BDeleteProbe;
        private System.Windows.Forms.Button BChangeProbe;
        private System.Windows.Forms.TextBox TBEcoName;
        private System.Windows.Forms.Button BEcoOK;
        private System.Windows.Forms.Button BProbeOK;
        private System.Windows.Forms.TextBox TBProbePlace;
        private System.Windows.Forms.Label LEcoName;
        private System.Windows.Forms.Label LProbePlace;
        private System.Windows.Forms.ComboBox CBProbeDay;
        private System.Windows.Forms.ComboBox CBProbeMonth;
        private System.Windows.Forms.ComboBox CBProbeYear;
        private System.Windows.Forms.Label LProbeDay;
        private System.Windows.Forms.Label LProbeMonth;
        private System.Windows.Forms.Label LProbeYear;
        private System.Windows.Forms.ToolStripMenuItem MISaveDataAs;
        private System.Windows.Forms.ToolStripMenuItem отчетToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MIFormSimpleReport;
        private System.Windows.Forms.ToolStripMenuItem MIFormExtendedReport;
        private System.Windows.Forms.Button BAddEcologist;
        private System.Windows.Forms.Button BAddProbe;
        private System.Windows.Forms.GroupBox GroupChangeEco;
        private System.Windows.Forms.GroupBox GroupChangeProbe;
        private System.Windows.Forms.SaveFileDialog DialogSaveFile;
        private System.Windows.Forms.OpenFileDialog DialogOpenFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn EcoName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Place;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.StatusStrip StatusStrip;

    }
}
