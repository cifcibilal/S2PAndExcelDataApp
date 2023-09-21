using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace S2PAndExcelDataApp
{
 
    public class DataFilter
    {
        ExcelManager excelOpenAndClose = new ExcelManager();
        /**
         * @brief Verilen veri tablosunu belirli MHz aralığına göre filtreler.
         * 
         * @param originalTable:DataTable, Filtrelenmek istenen orijinal veri tablosu.
         * @param minMHz:double, Minimum MHz değeri (dahil) ile filtreleme işlemi yapar.
         * @param maxMHz:double, Maximum MHz değeri (dahil) ile filtreleme işlemi yapar.
         * 
         * @return: Filtrelenmiş veri tablosu. (DataTable)
         */
        public DataTable filterByMHz(DataTable originalData, double minMHz, double maxMHz)
        {
            if (originalData!=null)
            {
                DataTable filteredTable = originalData.Clone();

                string mhzColumnName = filteredTable.Columns[0].ColumnName;
                DataColumn mhzColumn = originalData.Columns[mhzColumnName];

                if (mhzColumn != null)
                {
                    foreach (DataRow row in originalData.Rows)
                    {
                        
                       
                            string mhzValue = row[mhzColumn].ToString();
                            if (double.TryParse(mhzValue, out double MHz))
                            {
                                if (MHz >= minMHz && MHz <= maxMHz)
                                {
                                    filteredTable.ImportRow(row);
                                }
                            }
                        
                    }
                    return filteredTable;
                }
                else
                {
                    return null;
                }
            }
            
            else
            {
                MessageBox.Show("Uyarı : Önce dosya açın.");
                return null;
            }
        }

        public bool saveFilteredData(DataTable filteredTable, string filePath, string saveSheetName)
        {
            bool saveKontrol;
            if (filePath != null)
            {
                using (var package = new ExcelPackage(new System.IO.FileInfo(filePath)))
                {
                    ExcelWorksheet excelWorksheet = package.Workbook.Worksheets[saveSheetName];

                    if (excelWorksheet != null)
                    {
                        DialogResult dialogResult = MessageBox.Show("Girilen sayfa adında bir sayfa zaten var. Verileri üzerine yazmak istiyor musunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dialogResult == DialogResult.Yes)
                        {
                            
                            if (!excelOpenAndClose.IsFileInUse(filePath))
                            {
                                package.Workbook.Worksheets.Delete(excelWorksheet);
                                saveFilteredDataToWorksheet(package, filteredTable, saveSheetName);
                                package.Save();
                                MessageBox.Show("Sorgulanmış veriler sayfaya kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                saveKontrol = true;
                            }
                            else
                            {
                                MessageBox.Show("Önce dosyayı kapatın");
                                saveKontrol = false;
                            }
                            
                        }
                        else
                        {
                            MessageBox.Show("veriler sayfaya kaydedilmedi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            saveKontrol = false;
                        }
                    }
                    else
                    {
                        if (!excelOpenAndClose.IsFileInUse(filePath))
                        {
                            saveFilteredDataToWorksheet(package, filteredTable, saveSheetName);
                            package.Save();
                            MessageBox.Show("Sorgulanmış veriler sayfaya kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            saveKontrol = true;
                        }
                        else
                        {
                            MessageBox.Show("Önce dosyayı kapatın.");
                            saveKontrol = false;
                        }
                        
                    }
                }
            }
            else
            {
                MessageBox.Show("Excele Dönüştür butonunu kullanın.");
                saveKontrol = false;
            }
            return saveKontrol;
        }

        private void saveFilteredDataToWorksheet(ExcelPackage package, DataTable filteredTable, string saveSheetName)
        {
            if (!saveSheetName.Equals(""))
            {
                ExcelWorksheet excelWorksheet = package.Workbook.Worksheets.Add(saveSheetName);
                for (int columnIndex = 1; columnIndex <= filteredTable.Columns.Count; columnIndex++)
                {
                    excelWorksheet.Cells[1, columnIndex].Value = filteredTable.Columns[columnIndex - 1].ToString();
                }
                for (int rowIndex = 0; rowIndex < filteredTable.Rows.Count; rowIndex++)
                {
                    for (int columnIndex = 0; columnIndex < filteredTable.Columns.Count; columnIndex++)
                    {
                        excelWorksheet.Cells[rowIndex + 2, columnIndex + 1].Value = Convert.ToDouble(filteredTable.Rows[rowIndex][columnIndex]);
                    }
                }
                for (int i = 3; i <= filteredTable.Columns.Count; i += 2)
                {
                    excelWorksheet.Column(i).Hidden = true;
                }
            }
            else
            {
                MessageBox.Show("Sayfa adı girin.");
            }
        }

        internal void Swap(ref double minMHz, ref double maxMHz)
        {
            double temp = minMHz;
            minMHz = maxMHz;
            maxMHz = temp;
        }
    }
}
