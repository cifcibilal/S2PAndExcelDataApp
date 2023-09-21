using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace S2PAndExcelDataApp
{
    public class S2PManager : FileManager
    {

        public S2PManager()
        {

        }
        /**
          * @brief : S2P dosyasını openFileDialog ile açar. 
         * 
         * @param :
         * 
         * @return : filePath or null.
         */
        public override string openDialog()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            openFileDialog.Filter = "S2P Files|*.s2p";
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
         * @brief : S2P dosyasındaki verileri bir datatable aktarır.
         * 
         * @param : s2pFilePath:string, dosya yolu
         * 
         * @return : DataTable or null
         */
        public override DataTable readFile(string s2pFilePath)
        {
            string[] columnHeaderNames = { "MHz", "S11:dB", "S11_Ang(F2)", "S21:dB", "S21_Ang(F2)", "S12:dB", "S12_Ang(F2)", "S22:dB", "S22_Ang(F2)" };
            try
            {

                DataTable dataTable = new DataTable();
                using (StreamReader stream = new StreamReader(s2pFilePath))
                {
                    for (int i = 0; i < 5; i++)
                    {
                        stream.ReadLine();//s2p dosyasındaki ilk 4 satırı atlıyoruz.
                    }

                    for (int i = 0; i < columnHeaderNames.Length; i++)
                    {
                        dataTable.Columns.Add(columnHeaderNames[i]);
                        dataTable.Columns[i].ColumnName = columnHeaderNames[i];
                    }
                    string line;
                    while ((line = stream.ReadLine()) != null)
                    {
                        string[] values = line.Split('\t');
                        for (int i = 0; i < values.Length; i++)
                        {
                            if (i == 0)
                            {
                                if (double.TryParse(values[i].ToString(), NumberStyles.Float, CultureInfo.InvariantCulture, out double doubleValue))
                                {
                                    //!freq sütununu MHz'ye çevirir.
                                    values[i] = (doubleValue / 1_000_000).ToString();
                                }
                            }
                            else
                            {
                                if (double.TryParse(values[i].ToString(), NumberStyles.Float, CultureInfo.InvariantCulture, out double doubleValue))
                                {
                                    values[i] = doubleValue.ToString();
                                }
                            }

                        }
                        dataTable.Rows.Add(values);
                    }
                }
                return dataTable;
            }
            catch (Exception e)
            {
                MessageBox.Show("S2PManager,readFile içerisinde hata oluştu." + e.Message);
                return null;
            }
        }
        public string S2PFolderOpen()
        {


            string S2PFolderPath;
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                S2PFolderPath = dialog.SelectedPath;
            }
            else
            {
                S2PFolderPath = null;
            }
            return S2PFolderPath;
        }
    }
}
