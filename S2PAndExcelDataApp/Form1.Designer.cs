namespace S2PAndExcelDataApp
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend7 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.comboBoxSheetNames = new System.Windows.Forms.ComboBox();
            this.btnExcelOpen = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btnS2PFileSheetConverter = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnS2PSaveFileSelect = new System.Windows.Forms.Button();
            this.btnS2PFileSelect = new System.Windows.Forms.Button();
            this.btnS2PFileConverter = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnS2POpen = new System.Windows.Forms.Button();
            this.btnS2PConverter = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxMaxMHz = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxMinMHz = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSorgula = new System.Windows.Forms.Button();
            this.textBoxSaveName = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridViewData = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridViewQueriedData = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBoxLimitLine = new System.Windows.Forms.GroupBox();
            this.lblLimitLineName = new System.Windows.Forms.Label();
            this.radioButtonS22 = new System.Windows.Forms.RadioButton();
            this.radioButtons12 = new System.Windows.Forms.RadioButton();
            this.radioButtonS21 = new System.Windows.Forms.RadioButton();
            this.radioButtonS11 = new System.Windows.Forms.RadioButton();
            this.btnLimitlineEkle = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox_LimitLine_MaxMHz = new System.Windows.Forms.TextBox();
            this.textBox_LimitLine_MinMHz = new System.Windows.Forms.TextBox();
            this.textBox_LimitLine_dB = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.chartData = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewData)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewQueriedData)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBoxLimitLine.SuspendLayout();
            this.groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartData)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1524, 823);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox7);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1516, 794);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "File Operators";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.comboBoxSheetNames);
            this.groupBox4.Controls.Add(this.btnExcelOpen);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox4.Location = new System.Drawing.Point(6, 570);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(339, 224);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Excel İşlemleri";
            // 
            // comboBoxSheetNames
            // 
            this.comboBoxSheetNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSheetNames.FormattingEnabled = true;
            this.comboBoxSheetNames.Location = new System.Drawing.Point(9, 117);
            this.comboBoxSheetNames.Name = "comboBoxSheetNames";
            this.comboBoxSheetNames.Size = new System.Drawing.Size(288, 28);
            this.comboBoxSheetNames.TabIndex = 6;
            this.comboBoxSheetNames.SelectedIndexChanged += new System.EventHandler(this.comboBoxSheetNames_SelectedIndexChanged);
            // 
            // btnExcelOpen
            // 
            this.btnExcelOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnExcelOpen.Location = new System.Drawing.Point(166, 40);
            this.btnExcelOpen.Name = "btnExcelOpen";
            this.btnExcelOpen.Size = new System.Drawing.Size(125, 52);
            this.btnExcelOpen.TabIndex = 4;
            this.btnExcelOpen.Text = "Excel Aç";
            this.btnExcelOpen.UseVisualStyleBackColor = true;
            this.btnExcelOpen.Click += new System.EventHandler(this.btnExcelOpen_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox6);
            this.groupBox3.Controls.Add(this.groupBox5);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox3.Location = new System.Drawing.Point(814, 570);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(695, 223);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "S2P To Excel";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btnS2PFileSheetConverter);
            this.groupBox6.Controls.Add(this.progressBar1);
            this.groupBox6.Controls.Add(this.btnS2PSaveFileSelect);
            this.groupBox6.Controls.Add(this.btnS2PFileSelect);
            this.groupBox6.Controls.Add(this.btnS2PFileConverter);
            this.groupBox6.Location = new System.Drawing.Point(254, 27);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(435, 191);
            this.groupBox6.TabIndex = 3;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Tüm S2P Dosyaları";
            // 
            // btnS2PFileSheetConverter
            // 
            this.btnS2PFileSheetConverter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnS2PFileSheetConverter.Location = new System.Drawing.Point(287, 32);
            this.btnS2PFileSheetConverter.Name = "btnS2PFileSheetConverter";
            this.btnS2PFileSheetConverter.Size = new System.Drawing.Size(125, 107);
            this.btnS2PFileSheetConverter.TabIndex = 4;
            this.btnS2PFileSheetConverter.Text = "Tek Excel Dosyasına \r\nDönüştür";
            this.btnS2PFileSheetConverter.UseVisualStyleBackColor = true;
            this.btnS2PFileSheetConverter.Click += new System.EventHandler(this.btnS2PFileSheetConverter_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(6, 153);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(423, 23);
            this.progressBar1.TabIndex = 3;
            // 
            // btnS2PSaveFileSelect
            // 
            this.btnS2PSaveFileSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnS2PSaveFileSelect.Location = new System.Drawing.Point(6, 95);
            this.btnS2PSaveFileSelect.Name = "btnS2PSaveFileSelect";
            this.btnS2PSaveFileSelect.Size = new System.Drawing.Size(125, 52);
            this.btnS2PSaveFileSelect.TabIndex = 2;
            this.btnS2PSaveFileSelect.Text = "S2P Kayıt \r\nKlasör Seç";
            this.btnS2PSaveFileSelect.UseVisualStyleBackColor = true;
            this.btnS2PSaveFileSelect.Click += new System.EventHandler(this.btnS2PSaveFileSelect_Click);
            // 
            // btnS2PFileSelect
            // 
            this.btnS2PFileSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnS2PFileSelect.Location = new System.Drawing.Point(6, 32);
            this.btnS2PFileSelect.Name = "btnS2PFileSelect";
            this.btnS2PFileSelect.Size = new System.Drawing.Size(125, 52);
            this.btnS2PFileSelect.TabIndex = 0;
            this.btnS2PFileSelect.Text = "S2P Klasör Seç";
            this.btnS2PFileSelect.UseVisualStyleBackColor = true;
            this.btnS2PFileSelect.Click += new System.EventHandler(this.btnS2PFileSelect_Click);
            // 
            // btnS2PFileConverter
            // 
            this.btnS2PFileConverter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnS2PFileConverter.Location = new System.Drawing.Point(156, 32);
            this.btnS2PFileConverter.Name = "btnS2PFileConverter";
            this.btnS2PFileConverter.Size = new System.Drawing.Size(125, 107);
            this.btnS2PFileConverter.TabIndex = 1;
            this.btnS2PFileConverter.Text = "Ayrı Excel Dosyalarına \r\nDönüştür";
            this.btnS2PFileConverter.UseVisualStyleBackColor = true;
            this.btnS2PFileConverter.Click += new System.EventHandler(this.btnS2PFileConverter_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnS2POpen);
            this.groupBox5.Controls.Add(this.btnS2PConverter);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox5.Location = new System.Drawing.Point(52, 27);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(152, 191);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Tek Dosya";
            // 
            // btnS2POpen
            // 
            this.btnS2POpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnS2POpen.Location = new System.Drawing.Point(14, 32);
            this.btnS2POpen.Name = "btnS2POpen";
            this.btnS2POpen.Size = new System.Drawing.Size(125, 52);
            this.btnS2POpen.TabIndex = 0;
            this.btnS2POpen.Text = "S2P Dosya Seç";
            this.btnS2POpen.UseVisualStyleBackColor = true;
            this.btnS2POpen.Click += new System.EventHandler(this.btnS2POpen_Click);
            // 
            // btnS2PConverter
            // 
            this.btnS2PConverter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnS2PConverter.Location = new System.Drawing.Point(14, 115);
            this.btnS2PConverter.Name = "btnS2PConverter";
            this.btnS2PConverter.Size = new System.Drawing.Size(125, 52);
            this.btnS2PConverter.TabIndex = 1;
            this.btnS2PConverter.Text = "Excele Dönüştür";
            this.btnS2PConverter.UseVisualStyleBackColor = true;
            this.btnS2PConverter.Click += new System.EventHandler(this.btnS2PConverter_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.checkBox1);
            this.groupBox7.Controls.Add(this.btnSave);
            this.groupBox7.Controls.Add(this.label3);
            this.groupBox7.Controls.Add(this.textBoxMaxMHz);
            this.groupBox7.Controls.Add(this.label4);
            this.groupBox7.Controls.Add(this.textBoxMinMHz);
            this.groupBox7.Controls.Add(this.label5);
            this.groupBox7.Controls.Add(this.label6);
            this.groupBox7.Controls.Add(this.btnSorgula);
            this.groupBox7.Controls.Add(this.textBoxSaveName);
            this.groupBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox7.Location = new System.Drawing.Point(351, 571);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(457, 223);
            this.groupBox7.TabIndex = 31;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "MHz Aralığı seçin:";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(12, 103);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(107, 24);
            this.checkBox1.TabIndex = 28;
            this.checkBox1.Text = "Tüm veriler";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(311, 154);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(125, 52);
            this.btnSave.TabIndex = 23;
            this.btnSave.Text = "Kaydet";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 20);
            this.label3.TabIndex = 19;
            this.label3.Text = "Min";
            // 
            // textBoxMaxMHz
            // 
            this.textBoxMaxMHz.Location = new System.Drawing.Point(161, 53);
            this.textBoxMaxMHz.Name = "textBoxMaxMHz";
            this.textBoxMaxMHz.Size = new System.Drawing.Size(121, 25);
            this.textBoxMaxMHz.TabIndex = 27;
            this.textBoxMaxMHz.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxMaxMHz_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(158, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 20);
            this.label4.TabIndex = 20;
            this.label4.Text = "Max";
            // 
            // textBoxMinMHz
            // 
            this.textBoxMinMHz.Location = new System.Drawing.Point(11, 53);
            this.textBoxMinMHz.Name = "textBoxMinMHz";
            this.textBoxMinMHz.Size = new System.Drawing.Size(117, 25);
            this.textBoxMinMHz.TabIndex = 26;
            this.textBoxMinMHz.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxMinMHz_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(134, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 29);
            this.label5.TabIndex = 21;
            this.label5.Text = "||";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.4F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(8, 144);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(249, 20);
            this.label6.TabIndex = 25;
            this.label6.Text = "Kaydedilecek sayfa adını belirleyin:";
            // 
            // btnSorgula
            // 
            this.btnSorgula.Location = new System.Drawing.Point(311, 40);
            this.btnSorgula.Name = "btnSorgula";
            this.btnSorgula.Size = new System.Drawing.Size(125, 52);
            this.btnSorgula.TabIndex = 22;
            this.btnSorgula.Text = "Sorgula";
            this.btnSorgula.UseVisualStyleBackColor = true;
            this.btnSorgula.Click += new System.EventHandler(this.btnSorgula_Click);
            // 
            // textBoxSaveName
            // 
            this.textBoxSaveName.Location = new System.Drawing.Point(12, 167);
            this.textBoxSaveName.Name = "textBoxSaveName";
            this.textBoxSaveName.Size = new System.Drawing.Size(270, 25);
            this.textBoxSaveName.TabIndex = 24;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridViewData);
            this.groupBox1.Location = new System.Drawing.Point(3, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(750, 564);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tüm Veriler";
            // 
            // dataGridViewData
            // 
            this.dataGridViewData.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewData.Location = new System.Drawing.Point(3, 18);
            this.dataGridViewData.Name = "dataGridViewData";
            this.dataGridViewData.RowHeadersWidth = 51;
            this.dataGridViewData.RowTemplate.Height = 24;
            this.dataGridViewData.Size = new System.Drawing.Size(744, 543);
            this.dataGridViewData.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridViewQueriedData);
            this.groupBox2.Location = new System.Drawing.Point(759, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(750, 564);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sorgulanan Veriler";
            // 
            // dataGridViewQueriedData
            // 
            this.dataGridViewQueriedData.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewQueriedData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewQueriedData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewQueriedData.Location = new System.Drawing.Point(3, 18);
            this.dataGridViewQueriedData.Name = "dataGridViewQueriedData";
            this.dataGridViewQueriedData.RowHeadersWidth = 51;
            this.dataGridViewQueriedData.RowTemplate.Height = 24;
            this.dataGridViewQueriedData.Size = new System.Drawing.Size(744, 543);
            this.dataGridViewQueriedData.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBoxLimitLine);
            this.tabPage2.Controls.Add(this.groupBox9);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1516, 794);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Data Chart";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBoxLimitLine
            // 
            this.groupBoxLimitLine.Controls.Add(this.lblLimitLineName);
            this.groupBoxLimitLine.Controls.Add(this.radioButtonS22);
            this.groupBoxLimitLine.Controls.Add(this.radioButtons12);
            this.groupBoxLimitLine.Controls.Add(this.radioButtonS21);
            this.groupBoxLimitLine.Controls.Add(this.radioButtonS11);
            this.groupBoxLimitLine.Controls.Add(this.btnLimitlineEkle);
            this.groupBoxLimitLine.Controls.Add(this.label9);
            this.groupBoxLimitLine.Controls.Add(this.textBox_LimitLine_MaxMHz);
            this.groupBoxLimitLine.Controls.Add(this.textBox_LimitLine_MinMHz);
            this.groupBoxLimitLine.Controls.Add(this.textBox_LimitLine_dB);
            this.groupBoxLimitLine.Controls.Add(this.label8);
            this.groupBoxLimitLine.Controls.Add(this.label2);
            this.groupBoxLimitLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBoxLimitLine.Location = new System.Drawing.Point(1280, -2);
            this.groupBoxLimitLine.Name = "groupBoxLimitLine";
            this.groupBoxLimitLine.Size = new System.Drawing.Size(231, 414);
            this.groupBoxLimitLine.TabIndex = 34;
            this.groupBoxLimitLine.TabStop = false;
            this.groupBoxLimitLine.Text = "Limitline Ekle";
            // 
            // lblLimitLineName
            // 
            this.lblLimitLineName.AutoSize = true;
            this.lblLimitLineName.Location = new System.Drawing.Point(84, 380);
            this.lblLimitLineName.Name = "lblLimitLineName";
            this.lblLimitLineName.Size = new System.Drawing.Size(62, 20);
            this.lblLimitLineName.TabIndex = 37;
            this.lblLimitLineName.Text = "label10";
            this.lblLimitLineName.Visible = false;
            // 
            // radioButtonS22
            // 
            this.radioButtonS22.AutoSize = true;
            this.radioButtonS22.Location = new System.Drawing.Point(24, 137);
            this.radioButtonS22.Name = "radioButtonS22";
            this.radioButtonS22.Size = new System.Drawing.Size(131, 24);
            this.radioButtonS22.TabIndex = 36;
            this.radioButtonS22.TabStop = true;
            this.radioButtonS22.Text = "S22_Limitline";
            this.radioButtonS22.UseVisualStyleBackColor = true;
            this.radioButtonS22.CheckedChanged += new System.EventHandler(this.radioButtonS22_CheckedChanged);
            // 
            // radioButtons12
            // 
            this.radioButtons12.AutoSize = true;
            this.radioButtons12.Location = new System.Drawing.Point(24, 107);
            this.radioButtons12.Name = "radioButtons12";
            this.radioButtons12.Size = new System.Drawing.Size(131, 24);
            this.radioButtons12.TabIndex = 35;
            this.radioButtons12.TabStop = true;
            this.radioButtons12.Text = "S12_Limitline";
            this.radioButtons12.UseVisualStyleBackColor = true;
            this.radioButtons12.CheckedChanged += new System.EventHandler(this.radioButtons12_CheckedChanged);
            // 
            // radioButtonS21
            // 
            this.radioButtonS21.AutoSize = true;
            this.radioButtonS21.Location = new System.Drawing.Point(24, 77);
            this.radioButtonS21.Name = "radioButtonS21";
            this.radioButtonS21.Size = new System.Drawing.Size(131, 24);
            this.radioButtonS21.TabIndex = 34;
            this.radioButtonS21.TabStop = true;
            this.radioButtonS21.Text = "S21_Limitline";
            this.radioButtonS21.UseVisualStyleBackColor = true;
            this.radioButtonS21.CheckedChanged += new System.EventHandler(this.radioButtonS21_CheckedChanged);
            // 
            // radioButtonS11
            // 
            this.radioButtonS11.AutoSize = true;
            this.radioButtonS11.Location = new System.Drawing.Point(24, 47);
            this.radioButtonS11.Name = "radioButtonS11";
            this.radioButtonS11.Size = new System.Drawing.Size(131, 24);
            this.radioButtonS11.TabIndex = 33;
            this.radioButtonS11.TabStop = true;
            this.radioButtonS11.Text = "S11_Limitline";
            this.radioButtonS11.UseVisualStyleBackColor = true;
            this.radioButtonS11.CheckedChanged += new System.EventHandler(this.radioButtonS11_CheckedChanged);
            // 
            // btnLimitlineEkle
            // 
            this.btnLimitlineEkle.Location = new System.Drawing.Point(63, 322);
            this.btnLimitlineEkle.Name = "btnLimitlineEkle";
            this.btnLimitlineEkle.Size = new System.Drawing.Size(116, 43);
            this.btnLimitlineEkle.TabIndex = 28;
            this.btnLimitlineEkle.Text = "Ekle";
            this.btnLimitlineEkle.UseVisualStyleBackColor = true;
            this.btnLimitlineEkle.Click += new System.EventHandler(this.btnLimitlineEkle_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.Location = new System.Drawing.Point(103, 270);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(27, 29);
            this.label9.TabIndex = 28;
            this.label9.Text = "||";
            // 
            // textBox_LimitLine_MaxMHz
            // 
            this.textBox_LimitLine_MaxMHz.Location = new System.Drawing.Point(134, 273);
            this.textBox_LimitLine_MaxMHz.Name = "textBox_LimitLine_MaxMHz";
            this.textBox_LimitLine_MaxMHz.Size = new System.Drawing.Size(76, 26);
            this.textBox_LimitLine_MaxMHz.TabIndex = 4;
            this.textBox_LimitLine_MaxMHz.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_LimitLine_MaxMHz_KeyPress);
            // 
            // textBox_LimitLine_MinMHz
            // 
            this.textBox_LimitLine_MinMHz.Location = new System.Drawing.Point(24, 273);
            this.textBox_LimitLine_MinMHz.Name = "textBox_LimitLine_MinMHz";
            this.textBox_LimitLine_MinMHz.Size = new System.Drawing.Size(76, 26);
            this.textBox_LimitLine_MinMHz.TabIndex = 3;
            this.textBox_LimitLine_MinMHz.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_LimitLine_MinMHz_KeyPress);
            // 
            // textBox_LimitLine_dB
            // 
            this.textBox_LimitLine_dB.Location = new System.Drawing.Point(24, 201);
            this.textBox_LimitLine_dB.Name = "textBox_LimitLine_dB";
            this.textBox_LimitLine_dB.Size = new System.Drawing.Size(186, 26);
            this.textBox_LimitLine_dB.TabIndex = 2;
            this.textBox_LimitLine_dB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_LimitLine_dB_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 250);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 20);
            this.label8.TabIndex = 1;
            this.label8.Text = "MHz Aralığı :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 178);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "dB Değeri :";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.chartData);
            this.groupBox9.Location = new System.Drawing.Point(0, 0);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(1276, 794);
            this.groupBox9.TabIndex = 0;
            this.groupBox9.TabStop = false;
            // 
            // chartData
            // 
            chartArea7.Name = "ChartArea1";
            this.chartData.ChartAreas.Add(chartArea7);
            this.chartData.Dock = System.Windows.Forms.DockStyle.Fill;
            legend7.Name = "Legend1";
            this.chartData.Legends.Add(legend7);
            this.chartData.Location = new System.Drawing.Point(3, 18);
            this.chartData.Name = "chartData";
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series7.Legend = "Legend1";
            series7.Name = "Series1";
            this.chartData.Series.Add(series7);
            this.chartData.Size = new System.Drawing.Size(1270, 773);
            this.chartData.TabIndex = 0;
            this.chartData.Text = "chart1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Sayfa değiştir";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1524, 823);
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "S2P And Excel";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewData)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewQueriedData)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.groupBoxLimitLine.ResumeLayout(false);
            this.groupBoxLimitLine.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox comboBoxSheetNames;
        private System.Windows.Forms.Button btnExcelOpen;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox textBoxMaxMHz;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox textBoxMinMHz;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSorgula;
        private System.Windows.Forms.TextBox textBoxSaveName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridViewData;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnS2PSaveFileSelect;
        private System.Windows.Forms.Button btnS2PFileSelect;
        private System.Windows.Forms.Button btnS2PFileConverter;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnS2POpen;
        private System.Windows.Forms.Button btnS2PConverter;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridViewQueriedData;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartData;
        private System.Windows.Forms.GroupBox groupBoxLimitLine;
        private System.Windows.Forms.Label lblLimitLineName;
        private System.Windows.Forms.RadioButton radioButtonS22;
        private System.Windows.Forms.RadioButton radioButtons12;
        private System.Windows.Forms.RadioButton radioButtonS21;
        private System.Windows.Forms.RadioButton radioButtonS11;
        public System.Windows.Forms.Button btnLimitlineEkle;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox_LimitLine_MaxMHz;
        private System.Windows.Forms.TextBox textBox_LimitLine_MinMHz;
        private System.Windows.Forms.TextBox textBox_LimitLine_dB;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button btnS2PFileSheetConverter;
        private System.Windows.Forms.Label label1;
    }
}

