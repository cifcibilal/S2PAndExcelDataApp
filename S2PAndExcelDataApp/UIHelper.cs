using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace S2PAndExcelDataApp
{
    public class UIHelper
    {
        DataGridView dataGridView;
        public UIHelper()
        {
                
        }
        public UIHelper(DataGridView dataGridView)
        {
            this.dataGridView = dataGridView;
        }

        /**
         * @brief : Ang(F2) sütunlarını gizler.
         * 
         * @param :
         * 
         * @return : void
         */
        public void dataGridSutunDuzenle()
        {
            for (int i = 2; i < dataGridView.Columns.Count; i += 2)
            {
                dataGridView.Columns[i].Visible = false;
            }
        }

        public List<string> getSheetNames(string filePath)
        {
            List<string> sheetNames = new List<string>();
            try
            {
                using(var package = new ExcelPackage(filePath))
                {
                    if (package != null)
                    {
                        foreach (var sheet in package.Workbook.Worksheets)
                        {
                            sheetNames.Add(sheet.Name);
                        }
                    }
                }
                return sheetNames;
            }
            catch (Exception e)
            {
                MessageBox.Show("GetSheetNames içerisinde hata oluştu: " + e.Message);
                return null;
            }
        }
        public void textBoxKarakterKontrol(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }
            if (e.KeyChar == ',' && (sender as TextBox).Text.Contains(","))
            {
                e.Handled = true;
            }
        }

    }
}
