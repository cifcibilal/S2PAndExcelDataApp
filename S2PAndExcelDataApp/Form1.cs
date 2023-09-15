using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using OfficeOpenXml;
using OfficeOpenXml.Drawing.Chart;

namespace S2PAndExcelDataApp
{
    public partial class Form1 : Form
    {
        S2PManager s2pManager = new S2PManager();
        ExcelManager excelManager = new ExcelManager();
        DataFilter filter = new DataFilter();
        ChartProcessor processor = new ChartProcessor();

        DataTable excelDataTable;
        DataTable S2PDataTable;
        DataTable filteredTable;

        ExcelLineChart excelLineChart;

        string selectedS2POpenFolderPath;
        string selectedS2PSaveFolderPath;

        string selectedS2POpenFilePath;
        string selectedS2PSaveFilePath;

        string selectedExcelOpenFilePath;
        string selectedExcelSaveFilePath;

        string limitLineName;
        public Form1()
        {
            InitializeComponent();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnS2PConverter.Enabled = false;
            btnS2PSaveFileSelect.Enabled = false;
            btnS2PFileConverter.Enabled = false;
            btnSave.Enabled = false;
            checkBox1.Enabled = false;
            comboBoxSheetNames.Enabled = false;
            btnS2PFileSheetConverter.Enabled = false;
            btnLimitlineEkle.Enabled = false;
            groupBoxLimitLine.Enabled = false;
        }

        private void btnS2POpen_Click(object sender, EventArgs e)
        {
            comboBoxSheetNames.SelectedItem = null;
            comboBoxSheetNames.Items.Clear();
            comboBoxSheetNames.Enabled = false;
            dataGridViewQueriedData.Columns.Clear();
            this.selectedS2POpenFilePath = s2pManager.openDialog();

            if (selectedS2POpenFilePath != null)
            {
                this.S2PDataTable = s2pManager.readFile(selectedS2POpenFilePath);
            }
            dataGridViewData.Columns.Clear();
            dataGridViewData.DataSource = this.S2PDataTable;

            UIHelper helper = new UIHelper(dataGridViewData);
            helper.dataGridSutunDuzenle();
            if (S2PDataTable!= null)
            {
                processor.createChart(this.S2PDataTable, chartData);

                groupBoxLimitLine.Enabled = true;
                btnS2PConverter.Enabled = true;
                checkBox1.Checked = false;
                checkBox1.Enabled = true;
                checkBox1.Checked = true;
                checkBox1.Checked = false;
                btnS2PFileConverter.Enabled = false;
                btnS2PFileSheetConverter.Enabled = false;
                btnS2PSaveFileSelect.Enabled = false;
                btnLimitlineEkle.Enabled = true;

                btnSave.Enabled = false;
            }
            
        }

        private void btnS2PConverter_Click(object sender, EventArgs e)
        {
            FilePathManager filePathManager = new FilePathManager();
            string saveName = filePathManager.pathName(this.selectedS2POpenFilePath);
            string filePath;
            if (this.filteredTable != null)
            {
                filePath = excelManager.S2PtoExcelSave(this.filteredTable, saveName);

                if (chartData != null)
                {
                    using (ExcelPackage package = new ExcelPackage(new System.IO.FileInfo(filePath)))
                    {
                        processor.saveChart(package, chartData, saveName);
                        this.excelLineChart=processor.createExcelChart(this.filteredTable, package, saveName);
                        //processor.limitLineEkleExcelChart(limitLineName, saveName, package, this.excelLineChart, Convert.ToDouble(textBox_LimitLine_MinMHz.Text), Convert.ToDouble(textBox_LimitLine_MaxMHz.Text), Convert.ToDouble(textBox_LimitLine_dB.Text));
                        //processor.limitLineEkleExcelChart(limitLineName, saveName, package, this.excelLineChart,400,2000,-30);
                        if (!excelManager.IsFileInUse(filePath))
                        {
                            package.Save();
                        }
                        else
                        {
                            MessageBox.Show("Önce dosyayı kapatın");
                        }            
                        
                    }
                    MessageBox.Show("Başarıyla kaydedildi.");
                }
            }
            else
            {
                filePath = excelManager.S2PtoExcelSave(this.S2PDataTable, saveName);

                if (chartData != null && filePath != null)
                {
                    using (ExcelPackage package = new ExcelPackage(new System.IO.FileInfo(filePath)))
                    {
                        processor.saveChart(package, chartData, saveName);
                        this.excelLineChart=processor.createExcelChart(S2PDataTable, package, saveName);
                        //processor.limitLineEkleExcelChart("ssss", saveName, package, this.excelLineChart, 400, 2000, -30);
                        package.Save();
                    }
                    MessageBox.Show("Başarıyla kaydedildi.");
                }
            }

        }

        private void btnS2PFileSelect_Click(object sender, EventArgs e)
        {
            this.selectedS2POpenFolderPath = s2pManager.S2PFolderOpen();
            if (selectedS2POpenFolderPath!=null)
            {
                groupBoxLimitLine.Enabled = false;
                btnLimitlineEkle.Enabled = false;
                btnS2PSaveFileSelect.Enabled = true;
                dataGridViewData.Columns.Clear();
                dataGridViewQueriedData.Columns.Clear();
            }
            
        }

        private void btnS2PSaveFileSelect_Click(object sender, EventArgs e)
        {
            this.selectedS2PSaveFolderPath = s2pManager.S2PFolderOpen();
            if (selectedS2PSaveFolderPath!= null)
            {
                btnS2PFileConverter.Enabled = true;
                btnS2PFileSheetConverter.Enabled = true;
            }
        }

        private void btnS2PFileConverter_Click(object sender, EventArgs e)
        {
            dataGridViewQueriedData.Columns.Clear();
            string sourceFolder = this.selectedS2POpenFolderPath;
            string outputFolder = this.selectedS2PSaveFolderPath;

            excelManager.folderInS2PFileToExcel(sourceFolder, outputFolder, progressBar1, chartData);

            btnS2PFileConverter.Enabled = false;
            btnS2PSaveFileSelect.Enabled=false;
            textBoxMaxMHz.Text = string.Empty;
            textBoxMinMHz.Text = string.Empty;
            btnSorgula.Enabled = false;
            btnSave.Enabled = false;
            checkBox1.Checked = false;
            checkBox1.Enabled = false;
            comboBoxSheetNames.Items.Clear();
            comboBoxSheetNames.Enabled = false;
            btnS2PFileSheetConverter.Enabled=false;
            progressBar1.Value = 0;
            progressBar1.Maximum = 0;
            progressBar1.Minimum = 0;

        }

        private void btnExcelOpen_Click(object sender, EventArgs e)
        {
            dataGridViewQueriedData.Columns.Clear();
            if (comboBoxSheetNames.Items != null)
            {
                comboBoxSheetNames.Items.Clear();
            }

            this.selectedExcelOpenFilePath = excelManager.openDialog();

            if (selectedExcelOpenFilePath != null)
            {
                this.excelDataTable = excelManager.readFile(selectedExcelOpenFilePath, "0");
            }
            dataGridViewData.Columns.Clear();
            dataGridViewData.DataSource = this.excelDataTable;
            UIHelper helper = new UIHelper(dataGridViewData);
            helper.dataGridSutunDuzenle();
            if (this.excelDataTable != null)
            {
                processor.createChart(this.excelDataTable, chartData);
                
            }
            if (this.selectedExcelOpenFilePath != null)
            {
                foreach (var item in helper.getSheetNames(selectedExcelOpenFilePath))
                {
                    comboBoxSheetNames.Items.Add(item);
                }
                comboBoxSheetNames.SelectedIndex = 0;
                groupBoxLimitLine.Enabled = false;
                checkBox1.Enabled = true;
                checkBox1.Checked = true;
                checkBox1.Checked = false;
                comboBoxSheetNames.Enabled = true;
                btnS2PConverter.Enabled = false;
                btnS2PFileConverter.Enabled = false;
                btnS2PFileSheetConverter.Enabled = false;
                btnS2PSaveFileSelect.Enabled = false;
                btnSorgula.Enabled = true;
            }
            
        }

        private void comboBoxSheetNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedSheetName;
            if (comboBoxSheetNames.SelectedItem !=null)
            {
                selectedSheetName = comboBoxSheetNames.SelectedItem.ToString();
            }
            else
            {
                selectedSheetName = null;
            }
            
            if (selectedSheetName != null)
            {
                this.excelDataTable = excelManager.readFile(selectedExcelOpenFilePath, selectedSheetName);
            }
            else
            {
                excelDataTable = null;
            }
            dataGridViewData.Columns.Clear();
            dataGridViewData.DataSource = this.excelDataTable;
            UIHelper helper = new UIHelper(dataGridViewData);
            helper.dataGridSutunDuzenle();
            processor.createChart(this.excelDataTable, chartData);

            checkBox1.Checked = false;
            checkBox1.Checked = true;
            checkBox1.Checked = false;

        }

        private void btnSorgula_Click(object sender, EventArgs e)
        {
            dataGridViewQueriedData.Columns.Clear();
            DataTable originalData = (DataTable)dataGridViewData.DataSource;

            string selectedMinValue = textBoxMinMHz.Text;
            string selectedMaxValue = textBoxMaxMHz.Text;

            double minMHz = string.IsNullOrEmpty(selectedMinValue) ? 0 : double.Parse(selectedMinValue);
            double maxMHz = string.IsNullOrEmpty(selectedMaxValue) ? 0 : double.Parse(selectedMaxValue);

            if (minMHz > maxMHz)
            {
                filter.Swap(ref minMHz, ref maxMHz);
            }
            try
            {
                this.filteredTable = filter.filterByMHz(originalData, minMHz, maxMHz);

                dataGridViewQueriedData.Columns.Clear();
                dataGridViewQueriedData.DataSource = filteredTable;

                UIHelper helper = new UIHelper(dataGridViewQueriedData);
                helper.dataGridSutunDuzenle();

                processor.createChart(this.filteredTable, chartData);
                if (filteredTable!=null&&this.excelDataTable != null)
                {
                    groupBoxLimitLine.Enabled = true;
                    btnSave.Enabled = true;
                    btnLimitlineEkle.Enabled = true;
                }
               

            }
            catch (Exception ex)
            {
                MessageBox.Show("sorgula butonu hata" + ex.Message);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            string saveSheetName = textBoxSaveName.Text;

            string filePath = this.selectedExcelOpenFilePath;

            string selectedMinValue = textBoxMinMHz.Text;
            string selectedMaxValue = textBoxMaxMHz.Text;

            double minMHz = string.IsNullOrEmpty(selectedMinValue) ? 0 : double.Parse(selectedMinValue);
            double maxMHz = string.IsNullOrEmpty(selectedMaxValue) ? 0 : double.Parse(selectedMaxValue);
            if (!saveSheetName.Equals("") && filteredTable != null && !filePath.Equals(""))
            {
                filter.saveFilteredData(filteredTable, filePath, saveSheetName);

                using (ExcelPackage package = new ExcelPackage(new System.IO.FileInfo(filePath)))
                {
                    if (!excelManager.IsFileInUse(filePath))
                    {
                        processor.saveChart(package, chartData, saveSheetName);
                        this.excelLineChart = processor.createExcelChart(filteredTable, package, saveSheetName);
                        //processor.limitLineEkleExcelChart("saas",saveSheetName,package,excelLineChart,8,7,7);
                        package.Save();
                    }
                    
                }

                comboBoxSheetNames.Items.Clear();
                UIHelper helper = new UIHelper();
                foreach (var item in helper.getSheetNames(filePath))
                {
                    comboBoxSheetNames.Items.Add(item);
                }
                btnSave.Enabled = false;
            }
            else
            {
                MessageBox.Show("Sayfa adı boş veya sorgulama işlemi yapılamadı.");
            }        
        }
        private void btnLimitlineEkle_Click(object sender, EventArgs e)
        {
            if (!textBox_LimitLine_MinMHz.Text.Equals("") && !textBox_LimitLine_MaxMHz.Text.Equals("") && !textBox_LimitLine_dB.Text.Equals(""))
            {
                double minMHz = double.Parse(textBox_LimitLine_MinMHz.Text);
                double maxMHz = double.Parse(textBox_LimitLine_MaxMHz.Text);
                double dB = double.Parse(textBox_LimitLine_dB.Text);
                processor.LimitLineEkle(lblLimitLineName.Text, chartData, minMHz, maxMHz, dB);
            }
            //processor.limitLineEkleExcelChart(lblLimitLineName.Text,this.excelLineChart,minMHz,maxMHz, dB);
        }
        private void radioButtonS11_CheckedChanged(object sender, EventArgs e)
        {
            textBox_LimitLine_dB.Text = "0";
            textBox_LimitLine_MinMHz.Text = "0";
            textBox_LimitLine_MaxMHz.Text = "0";
            lblLimitLineName.Text = "S11_Limitline";
            this.limitLineName = "S11_Limitline";
            btnLimitlineEkle.Enabled = true;
        }

        private void radioButtonS21_CheckedChanged(object sender, EventArgs e)
        {
            textBox_LimitLine_dB.Text = "0";
            textBox_LimitLine_MinMHz.Text = "0";
            textBox_LimitLine_MaxMHz.Text = "0";
            lblLimitLineName.Text = "S21_Limitline";
            this.limitLineName = "S21_Limitline";
            btnLimitlineEkle.Enabled = true;
        }

        private void radioButtons12_CheckedChanged(object sender, EventArgs e)
        {
            textBox_LimitLine_dB.Text = "0";
            textBox_LimitLine_MinMHz.Text = "0";
            textBox_LimitLine_MaxMHz.Text = "0";
            lblLimitLineName.Text = "S12_Limitline";
            this.limitLineName = "S12_Limitline";
            btnLimitlineEkle.Enabled = true;
        }

        private void radioButtonS22_CheckedChanged(object sender, EventArgs e)
        {
            textBox_LimitLine_dB.Text = "0";
            textBox_LimitLine_MinMHz.Text = "0";
            textBox_LimitLine_MaxMHz.Text = "0";
            lblLimitLineName.Text = "S22_Limitline";
            this.limitLineName = "S21_Limitline";
            btnLimitlineEkle.Enabled = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                double minMhz = double.MinValue;
                double maxMhz = double.MaxValue;
                DataTable data = (DataTable)dataGridViewData.DataSource;
                if (data != null)
                {
                    foreach (DataRow row in data.Rows)
                    {
                        double value = Convert.ToDouble(row[0]);
                        if (value > minMhz)
                        {
                            minMhz = value;
                        }

                        if (value < maxMhz)
                        {
                            maxMhz = value;
                        }
                    }
                    textBoxMinMHz.Text = maxMhz.ToString();
                    textBoxMaxMHz.Text = minMhz.ToString();
                }
            }
            
        }

        private void btnS2PFileSheetConverter_Click(object sender, EventArgs e)
        {
            dataGridViewQueriedData.Columns.Clear();
            string sourceFolder = this.selectedS2POpenFolderPath;
            string outputFolder = this.selectedS2PSaveFolderPath;
            //ExcelPackage package;
            excelManager.folderInS2PSheetToExcel(sourceFolder, outputFolder, progressBar1, chartData);

            btnS2PFileConverter.Enabled = false;
            btnS2PSaveFileSelect.Enabled = false;
            textBoxMaxMHz.Text = string.Empty;
            textBoxMinMHz.Text = string.Empty;
            btnSorgula.Enabled = false;
            btnSave.Enabled = false;
            checkBox1.Checked = false;
            checkBox1.Enabled = false;
            comboBoxSheetNames.Items.Clear();
            progressBar1.Value = 0;
            progressBar1.Maximum = 0;
            progressBar1.Minimum = 0;
            comboBoxSheetNames.Enabled = false;
            btnS2PFileConverter.Enabled = false;
            btnS2PFileSheetConverter.Enabled = false;

        }

        private void textBoxMinMHz_KeyPress(object sender, KeyPressEventArgs e)
        {
            UIHelper uIHelper = new UIHelper();
            uIHelper.textBoxKarakterKontrol(sender, e);
        }

        private void textBoxMaxMHz_KeyPress(object sender, KeyPressEventArgs e)
        {
            UIHelper uIHelper = new UIHelper();
            uIHelper.textBoxKarakterKontrol(sender, e);
        }

        private void textBox_LimitLine_dB_KeyPress(object sender, KeyPressEventArgs e)
        {
            UIHelper uIHelper = new UIHelper();
            uIHelper.textBoxKarakterKontrol(sender, e);
        }

        private void textBox_LimitLine_MinMHz_KeyPress(object sender, KeyPressEventArgs e)
        {
            UIHelper uIHelper = new UIHelper();
            uIHelper.textBoxKarakterKontrol(sender, e);
        }

        private void textBox_LimitLine_MaxMHz_KeyPress(object sender, KeyPressEventArgs e)
        {
            UIHelper uIHelper = new UIHelper();
            uIHelper.textBoxKarakterKontrol(sender, e);
        }
    }
}
