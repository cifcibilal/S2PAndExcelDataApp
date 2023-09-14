using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace S2PAndExcelDataApp
{
    public class ExcelManager : FileManager
    {
        public ExcelManager()
        {

        }
        /**
        * @brief : Excel dosyasını openFileDialog ile açar. 
        * 
        * @param :
        * 
        * @return : filePath or null.
        */
        public override string openDialog()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            openFileDialog.Filter = "Excel Files|*.xlsx";
            string path;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                path = openFileDialog.FileName;
            }
            else
            {
                path = null;
            }
            return path;
        }
        /**
         * @brief : Excel dosyasını bir datatable'a aktarır.
         * 
         * @param : path:String, okunacak dosyanın dizini
         * @param : selectedSheetName:string, okunacak sayfa adı, default 0
         * 
         * @return : DataTable or null
         */
        public override DataTable readFile(string path, string selectedSheetName = "0")
        {
            DataTable dataTable = new DataTable();
            try
            {
                using(var package = new ExcelPackage(new FileInfo(path)))
                {
                    ExcelWorksheet excelWorksheet;
                    if (selectedSheetName.Equals("0"))
                    {
                        excelWorksheet = package.Workbook.Worksheets[0];
                    }
                    else
                    {
                        excelWorksheet = package.Workbook.Worksheets[selectedSheetName];
                    }

                    int startRow = 1;
                    int endRow = excelWorksheet.Dimension.Rows;
                    int endColumn = excelWorksheet.Dimension.Columns;

                    string columnHeader;

                    for (int columnIndex = 1; columnIndex <= endColumn; columnIndex++)
                    {
                        columnHeader = excelWorksheet.Cells[startRow, columnIndex].Text;
                        dataTable.Columns.Add(columnHeader);
                    }
                    for (int rowNumber = (startRow+1); rowNumber <= endRow; rowNumber++)
                    {
                        var row = excelWorksheet.Cells[rowNumber, 1, rowNumber, endColumn];
                        var newRow = dataTable.NewRow();

                        foreach (var cell in row)
                        {
                            if (double.TryParse(cell.Text,out double numericValue))
                            {
                                newRow[cell.Start.Column - 1] = numericValue;
                            }
                            else
                            {
                                newRow[cell.Start.Column - 1] = cell.Text;
                            }
                        }
                        dataTable.Rows.Add(newRow);
                    }
                }
                return dataTable;
            }
            catch (Exception e)
            {
                MessageBox.Show("ReaderExcelFile içerisinde hata oluştu: " + e.Message);
                return null;
            }
        }
        /**
         * @brief : DataTable verilerini Excel olarak kaydeder.
         * 
         * @param : S2PDataTable:DataTable, S2P verilerini içeren DataTable
         * @param : saveSheetName:string, Kaydedilecek excel sayfa adı
         * 
         * @rreturn : savePath
         */
        public string S2PtoExcelSave(DataTable S2PDataTable, string saveSheetName)
        {
            string dataTableValue;
            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add(saveSheetName);

                for (int columnIndex = 0; columnIndex < S2PDataTable.Columns.Count; columnIndex++)
                {
                    worksheet.Cells[1, columnIndex + 1].Value = S2PDataTable.Columns[columnIndex].ColumnName;
                }

                for (int rowIndex = 0; rowIndex < S2PDataTable.Rows.Count; rowIndex++)
                {
                    for (int columnIndex = 0; columnIndex < S2PDataTable.Columns.Count; columnIndex++)
                    {
                        dataTableValue = S2PDataTable.Rows[rowIndex][columnIndex].ToString();
                        if (double.TryParse(dataTableValue, out double doubleValue))
                        {
                            worksheet.Cells[rowIndex + 2, columnIndex + 1].Value = doubleValue;
                        }
                    }
                }
                for (int AngF2 = 3; AngF2 <= worksheet.Columns.Count(); AngF2 += 2)
                {
                    worksheet.Column(AngF2).Hidden = true;
                }

                string savePath = excelSaveFileDialog(saveSheetName);
                if (savePath != null)
                {
                    excelPackage.SaveAs(new System.IO.FileInfo(savePath));
                    
                }      
                return savePath;

            }
        }
        /**
         * @brief : DataTable verilerini Excel olarak kaydeder.
         * 
         * @param : S2PDataTable:DataTable, S2P verilerini içeren DataTable
         * @param : saveSheetName:string, Kaydedilecek excel sayfa adı
         * @param : savePath:string, Kaydedilecek dizin
         * 
         * @rreturn : savePath
         */
        public string S2PtoExcelFileSave(DataTable S2PDataTable, string saveSheetName, string savePath)
        {
            string dataTableValue;
            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add(saveSheetName);

                for (int columnIndex = 0; columnIndex < S2PDataTable.Columns.Count; columnIndex++)
                {
                    worksheet.Cells[1, columnIndex + 1].Value = S2PDataTable.Columns[columnIndex].ColumnName;
                }

                for (int rowIndex = 0; rowIndex < S2PDataTable.Rows.Count; rowIndex++)
                {
                    for (int columnIndex = 0; columnIndex < S2PDataTable.Columns.Count; columnIndex++)
                    {
                        dataTableValue = S2PDataTable.Rows[rowIndex][columnIndex].ToString();
                        if (double.TryParse(dataTableValue, out double doubleValue))
                        {
                            worksheet.Cells[rowIndex + 2, columnIndex + 1].Value = doubleValue;
                        }
                    }
                }
                for (int AngF2 = 3; AngF2 <= worksheet.Columns.Count(); AngF2 += 2)
                {
                    worksheet.Column(AngF2).Hidden = true;
                }

                excelPackage.SaveAs(new System.IO.FileInfo(savePath));
                return savePath;

            }
        }
        public string S2PtoExcelSheetSave(DataTable S2PDataTable, string saveSheetName, string savePath,string S2PFileName,ProgressBar progressBar)
        {
            string dataTableValue;
            if (S2PFileName == saveSheetName)
            {
                using(var package = new ExcelPackage())
                {
                    package.Workbook.Worksheets.Add(S2PFileName);

                    var worksheet = package.Workbook.Worksheets[saveSheetName];

                    for (int columnIndex = 0; columnIndex < S2PDataTable.Columns.Count; columnIndex++)
                    {
                        worksheet.Cells[1, columnIndex + 1].Value = S2PDataTable.Columns[columnIndex].ColumnName;
                    }

                    for (int rowIndex = 0; rowIndex < S2PDataTable.Rows.Count; rowIndex++)
                    {
                        for (int columnIndex = 0; columnIndex < S2PDataTable.Columns.Count; columnIndex++)
                        {
                            dataTableValue = S2PDataTable.Rows[rowIndex][columnIndex].ToString();
                            if (double.TryParse(dataTableValue, out double doubleValue))
                            {
                                worksheet.Cells[rowIndex + 2, columnIndex + 1].Value = doubleValue;
                            }
                        }
                    }
                    for (int AngF2 = 3; AngF2 <= worksheet.Columns.Count(); AngF2 += 2)
                    {
                        worksheet.Column(AngF2).Hidden = true;
                    }
                    var excelSaveFile = new FileInfo(savePath);

                    package.SaveAs(excelSaveFile);
                    
                }
            }
            else
            {
                using(var package = new ExcelPackage(savePath))
                {

                    if (saveSheetName.Length >=30)
                    {
                        saveSheetName =new string(saveSheetName.Take(26).ToArray());
                        saveSheetName = saveSheetName +"_"+ progressBar.Value.ToString();

                        package.Workbook.Worksheets.Add(saveSheetName);
                    }
                    else
                    {
                        package.Workbook.Worksheets.Add(saveSheetName);
                    }

                    var worksheet = package.Workbook.Worksheets[saveSheetName];

                    for (int columnIndex = 0; columnIndex < S2PDataTable.Columns.Count; columnIndex++)
                    {
                        worksheet.Cells[1, columnIndex + 1].Value = S2PDataTable.Columns[columnIndex].ColumnName;
                    }

                    for (int rowIndex = 0; rowIndex < S2PDataTable.Rows.Count; rowIndex++)
                    {
                        for (int columnIndex = 0; columnIndex < S2PDataTable.Columns.Count; columnIndex++)
                        {
                            dataTableValue = S2PDataTable.Rows[rowIndex][columnIndex].ToString();
                            if (double.TryParse(dataTableValue, out double doubleValue))
                            {
                                worksheet.Cells[rowIndex + 2, columnIndex + 1].Value = doubleValue;
                            }
                        }
                    }
                    for (int AngF2 = 3; AngF2 <= worksheet.Columns.Count(); AngF2 += 2)
                    {
                        worksheet.Column(AngF2).Hidden = true;
                    }
                    package.Save();
                }
            }
            return saveSheetName;
        }
        /**
         * @brief : Excele çevrilmiş S2P Dosyasının kaydedileceği dizin seçilir
         * 
         * @param : defaultSaveName : string, S2P Dosya adı
         * 
         * @return : void
         */
        private string excelSaveFileDialog(string defaultSaveName)
        {
            string savePath;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Dosya Kayıt|*.xlsx";
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            saveFileDialog.FileName = defaultSaveName + ".xlsx";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                savePath = saveFileDialog.FileName;
                return savePath;
            }
            else
            {
                return null;
            }
        }
        /**
         * @brief : Bir klasör içerisindeki tüm S2P dosyalarını istenilen klasöre kaydeder.
         * 
         * @param : sourceFolder:string, S2P Dosyalarının bulunduğu klasör
         * @param : outputFolder:string, Excele çevirilen S2P dosyalarının kaydedileceği klasör
         * @param : progressBar:ProgressBar, İşlemin ilerleyişini gösterir.
         * 
         * @return : void
         */
        public void folderInS2PFileToExcel(string sourceFolder, string outputFolder, ProgressBar progressBar,Chart chart)
        {
            FilePathManager filePathManager = new FilePathManager();
            S2PManager S2PManager = new S2PManager();
            ChartProcessor processor = new ChartProcessor();
            DataTable S2P_DataTable;
            string S2PFileName;
            string excelFileName;
            string excelFilePath;
            try
            {
               // string mainFileDirectory = Path.GetDirectoryName(sourceFolder);
                string[] S2P_Files = Directory.GetFiles(sourceFolder, "*.s2p");

                progressBar.Minimum = 0;
                progressBar.Maximum = S2P_Files.Length;

                foreach (string S2P_File in S2P_Files)
                {
                    progressBar.Value += 1;
                    S2PFileName = filePathManager.pathName(S2P_File);
                    excelFileName = S2PFileName + ".xlsx";
                    excelFilePath = Path.Combine(outputFolder, excelFileName);

                    S2P_DataTable = S2PManager.readFile(S2P_File);

                    string filePath = S2PtoExcelFileSave(S2P_DataTable, S2PFileName,excelFilePath);
                    
                    if (chart != null)
                    {
                        using (ExcelPackage package = new ExcelPackage(new FileInfo(filePath)))
                        {
                            //processor.saveChart(package, chart, S2PFileName);
                            processor.createChart(S2P_DataTable, chart);
                            processor.createExcelChart(S2P_DataTable,package,S2PFileName);
                            package.Save();
                        }
                    }


                }
                MessageBox.Show("Klasör içerisindeki S2P dosyaları excele kaydedildi");
            }
            catch (Exception e)
            {
                MessageBox.Show("folderInS2PFileToExcel içinde hata oluştu" + e.Message);
            }
        }
        public void folderInS2PSheetToExcel(string sourceFolder, string outputFolder, ProgressBar progressBar, Chart chart)
        {
            FilePathManager filePathManager = new FilePathManager();
            S2PManager S2PManager = new S2PManager();
            ChartProcessor processor = new ChartProcessor();
            Random random = new Random();
            DataTable S2P_DataTable;
            string S2PSheetName;
            string excelFileName;
            string excelFilePath;
            int S2PFileNameKontrol = 0;
            string S2PWorkBookName;
            string packagePathKontrol;
            string hataSayfaIsmiKontrol;
            
            try
            {
                string[] S2P_Files = Directory.GetFiles(sourceFolder, "*.s2p");

                progressBar.Minimum = 0;
                progressBar.Maximum = S2P_Files.Length;


                foreach (string S2P_File in S2P_Files)
                {
                    int random1 = random.Next(1, 101);
                    int random2 = random.Next(1, 101);
                    hataSayfaIsmiKontrol = $"Sayfa_{random1.ToString()}_{random2.ToString()}";
                    S2PWorkBookName = filePathManager.pathName(S2P_Files[S2PFileNameKontrol]);
                    packagePathKontrol = Path.Combine(outputFolder, S2PWorkBookName)+".xlsx";
                    progressBar.Value += 1;
                    S2PSheetName = filePathManager.pathName(S2P_File);
                    S2P_DataTable = S2PManager.readFile(S2P_File);
                    

                    hataSayfaIsmiKontrol=S2PtoExcelSheetSave(S2P_DataTable, S2PSheetName, packagePathKontrol, S2PWorkBookName, progressBar);
                   
                    

                    if (chart != null)
                    {
                        using (ExcelPackage package = new ExcelPackage(new FileInfo(packagePathKontrol)))
                        {
                            if (progressBar.Value == 1)
                            {
                                processor.createChart(S2P_DataTable, chart);
                                processor.createExcelChart(S2P_DataTable, package, S2PWorkBookName);
                                package.Save();
                                
                                
                            }
                            else
                            {
                                processor.createChart(S2P_DataTable, chart);
                                processor.createExcelChart(S2P_DataTable, package, hataSayfaIsmiKontrol);
                                package.Save();
                            }
                        }
                    }
                }
                
                MessageBox.Show("Klasör içerisindeki S2P dosyaları excele kaydedildi");
            }
            catch (Exception e)
            {
                MessageBox.Show("folderInS2PFileToExcel içinde hata oluştu" + e.Message);
            }
        }
        public bool IsFileInUse(string path)
        {
            try
            {
                using (var stream = new FileStream(path, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                {
                    stream.Close();
                    return false;
                }
            }
            catch
            {
                return true;
            }
        }
    }
}
