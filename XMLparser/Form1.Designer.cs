namespace XMLparser
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.gMapControl1 = new GMap.NET.WindowsForms.GMapControl();
            this.ChooseMapBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TubeBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CrossedListBox = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ExportBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // gMapControl1
            // 
            this.gMapControl1.Bearing = 0F;
            this.gMapControl1.CanDragMap = true;
            this.gMapControl1.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gMapControl1.GrayScaleMode = false;
            this.gMapControl1.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapControl1.LevelsKeepInMemmory = 5;
            this.gMapControl1.Location = new System.Drawing.Point(12, 96);
            this.gMapControl1.MarkersEnabled = true;
            this.gMapControl1.MaxZoom = 2;
            this.gMapControl1.MinZoom = 2;
            this.gMapControl1.MouseWheelZoomEnabled = true;
            this.gMapControl1.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapControl1.Name = "gMapControl1";
            this.gMapControl1.NegativeMode = false;
            this.gMapControl1.PolygonsEnabled = true;
            this.gMapControl1.RetryLoadTile = 0;
            this.gMapControl1.RoutesEnabled = true;
            this.gMapControl1.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapControl1.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapControl1.ShowTileGridLines = false;
            this.gMapControl1.Size = new System.Drawing.Size(1400, 800);
            this.gMapControl1.TabIndex = 2;
            this.gMapControl1.Zoom = 0D;
            this.gMapControl1.OnPolygonClick += new GMap.NET.WindowsForms.PolygonClick(this.gMapControl1_OnPolygonClick);
            this.gMapControl1.OnMapZoomChanged += new GMap.NET.MapZoomChanged(this.gMapControl1_OnMapZoomChanged);
            // 
            // ChooseMapBox
            // 
            this.ChooseMapBox.FormattingEnabled = true;
            this.ChooseMapBox.Items.AddRange(new object[] {
            "Arcgis_Topo_Map",
            "Google_Satellite",
            "Google_Map",
            "Yandex_Map"});
            this.ChooseMapBox.Location = new System.Drawing.Point(12, 41);
            this.ChooseMapBox.Name = "ChooseMapBox";
            this.ChooseMapBox.Size = new System.Drawing.Size(283, 28);
            this.ChooseMapBox.TabIndex = 3;
            this.ChooseMapBox.Text = "Arcgis_Topo_Map";
            this.ChooseMapBox.SelectedIndexChanged += new System.EventHandler(this.ChooseMapBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 29);
            this.label1.TabIndex = 4;
            this.label1.Text = "Выбор карты";
            // 
            // TubeBox
            // 
            this.TubeBox.FormattingEnabled = true;
            this.TubeBox.Items.AddRange(new object[] {
            "Газораспределение 2 м.",
            "Подземное газораспределение (ПЭТ + медный провод) 2.5 м",
            "Воздушная линия 10 КилоВольт 10 м.",
            "Магистральный газопровод 25 м.",
            "Охранная зона 50 м."});
            this.TubeBox.Location = new System.Drawing.Point(336, 41);
            this.TubeBox.Name = "TubeBox";
            this.TubeBox.Size = new System.Drawing.Size(505, 28);
            this.TubeBox.TabIndex = 5;
            this.TubeBox.Text = "Газораспределение 2 м.";
            this.TubeBox.SelectedIndexChanged += new System.EventHandler(this.TubeBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(331, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(270, 29);
            this.label2.TabIndex = 6;
            this.label2.Text = "Выбор охранной зоны";
            // 
            // CrossedListBox
            // 
            this.CrossedListBox.FormattingEnabled = true;
            this.CrossedListBox.ItemHeight = 20;
            this.CrossedListBox.Location = new System.Drawing.Point(1434, 135);
            this.CrossedListBox.Name = "CrossedListBox";
            this.CrossedListBox.Size = new System.Drawing.Size(184, 404);
            this.CrossedListBox.TabIndex = 7;
            this.CrossedListBox.SelectedIndexChanged += new System.EventHandler(this.CrossedListBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(1430, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(282, 29);
            this.label3.TabIndex = 8;
            this.label3.Text = "Пересеченные участки";
            // 
            // ExportBtn
            // 
            this.ExportBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ExportBtn.Location = new System.Drawing.Point(1435, 559);
            this.ExportBtn.Name = "ExportBtn";
            this.ExportBtn.Size = new System.Drawing.Size(183, 61);
            this.ExportBtn.TabIndex = 9;
            this.ExportBtn.Text = "Экспорт в Word";
            this.ExportBtn.UseVisualStyleBackColor = true;
            this.ExportBtn.Click += new System.EventHandler(this.ExportBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1641, 981);
            this.Controls.Add(this.ExportBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CrossedListBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TubeBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ChooseMapBox);
            this.Controls.Add(this.gMapControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "SinerGIS";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private GMap.NET.WindowsForms.GMapControl gMapControl1;
        private System.Windows.Forms.ComboBox ChooseMapBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox TubeBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox CrossedListBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ExportBtn;
    }
}

