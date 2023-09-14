using OfficeOpenXml;
using OfficeOpenXml.Drawing;
using OfficeOpenXml.Drawing.Chart;
using OfficeOpenXml.Drawing.Vml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static OfficeOpenXml.ExcelErrorValue;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace S2PAndExcelDataApp
{
    public class ChartProcessor
    {
        public ChartProcessor() { }


        public void createChart(DataTable dataTable, Chart chart)
        {
            if (dataTable != null)
            {
                chart.Series.Clear();

                chartProperties(dataTable, chart);

                Series series1 = new Series("S11:dB");
                Series series2 = new Series("S21:dB");
                Series series3 = new Series("S12:dB");
                Series series4 = new Series("S22:dB");

                chart.Series.Add(series1);
                chart.Series.Add(series2);
                chart.Series.Add(series3);
                chart.Series.Add(series4);

                series1.ChartType = SeriesChartType.Line;
                series1.BorderWidth = 2;
                series1.XValueType = ChartValueType.Double;

                series2.ChartType = SeriesChartType.Line;
                series2.BorderWidth = 2;
                series2.XValueType = ChartValueType.Double;

                series3.ChartType = SeriesChartType.Line;
                series3.BorderWidth = 2;
                series3.XValueType = ChartValueType.Double;

                series4.ChartType = SeriesChartType.Line;
                series4.BorderWidth = 2;
                series4.XValueType = ChartValueType.Double;

                for (int rowIndex = 0; rowIndex < dataTable.Rows.Count; rowIndex++)
                {
                    double.TryParse(dataTable.Rows[rowIndex][dataTable.Columns[0].ColumnName].ToString(), out double xValue);
                    for (int columnIndex = 1; columnIndex < dataTable.Columns.Count; columnIndex += 2)
                    {
                        double yValue = 0;
                        if (dataTable.Rows[rowIndex][dataTable.Columns[columnIndex].ColumnName] != DBNull.Value)
                        {
                            double.TryParse(dataTable.Rows[rowIndex][dataTable.Columns[columnIndex].ColumnName].ToString(), out yValue);
                        }
                        switch (columnIndex)
                        {
                            case 1:
                                series1.Points.AddXY(xValue, yValue);
                                break;
                            case 3:
                                series2.Points.AddXY(xValue, yValue);
                                break;
                            case 5:
                                series3.Points.AddXY(xValue, yValue);
                                break;
                            case 7:
                                series4.Points.AddXY(xValue, yValue);
                                break;
                            default:
                                break;
                        }
                    }
                }

            }
        }

        public void LimitLineEkle(string limitLineName, Chart chartData, double textBox_LimitLine_MinMHz, double textBox_LimitLine_MaxMHz, double textBox_LimitLine_dB)
        {
            double x1 = double.Parse(textBox_LimitLine_MinMHz.ToString());
            double x2 = double.Parse(textBox_LimitLine_MaxMHz.ToString());
            double y = double.Parse(textBox_LimitLine_dB.ToString());

            Series existingSeries = chartData.Series.FindByName(limitLineName);
            if (existingSeries != null)
            {
                chartData.Series.Remove(existingSeries);
            }
            Series series = new Series();
            series.Name = limitLineName;
            series.ChartType = SeriesChartType.Line;
            series.BorderWidth = 1;

            if (series.Name.Equals("S11_Limitline"))
            {
                series.Color = Color.Black;
            }
            else if (series.Name.Equals("S21_Limitline"))
            {
                series.Color = Color.MidnightBlue;
            }
            else if (series.Name.Equals("S12_Limitline"))
            {
                series.Color = Color.DarkRed;
            }
            else if (series.Name.Equals("S22_Limitline"))
            {
                series.Color = Color.DarkGreen;
            }
            series.BorderDashStyle = ChartDashStyle.Dash;
            series.Points.AddXY(x1, y);
            series.Points.AddXY(x2, y);

            chartData.Series.Add(series);

            chartData.Invalidate();
        }

        private void chartProperties(DataTable dataTable, Chart chart)
        {
            double minX = double.MinValue;
            double minY = double.MinValue;
            double maxX = double.MaxValue;
            double maxY = double.MaxValue;

            if (dataTable != null)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    double.TryParse(row[dataTable.Columns[0].ColumnName].ToString(), out double xValue);
                    if (xValue > minX)
                    {
                        minX = xValue;
                    }
                    if (xValue < maxX)
                    {
                        maxX = xValue;
                    }

                    for (int columnIndex = 1; columnIndex < dataTable.Columns.Count; columnIndex += 2)
                    {
                        if (row[dataTable.Columns[columnIndex].ColumnName] != DBNull.Value)
                        {
                            double.TryParse(row[dataTable.Columns[columnIndex].ColumnName].ToString(), out double parsedValue);
                            double yValue = parsedValue;
                            if (true)
                            {
                                if (yValue > minY)
                                {
                                    minY = yValue;
                                }

                                if (yValue < maxY)
                                {
                                    maxY = yValue;
                                }
                            }
                        }
                    }
                }
                chart.ChartAreas[0].AxisX.Title = dataTable.Columns[0].ColumnName;
                chart.ChartAreas[0].AxisX.Minimum = maxX - 5;
                chart.ChartAreas[0].AxisX.Maximum = minX + 5;
                chart.ChartAreas[0].AxisY.Maximum = minY + 5;
                chart.ChartAreas[0].AxisY.Minimum = maxY - 5;
                chart.ChartAreas[0].AxisY.Title = "dB";
                chart.ChartAreas[0].AxisX.LabelStyle.Format = "N2";
                chart.ChartAreas[0].AxisY.LabelStyle.Format = "N2";
            }

            
        }
        public void saveChart(ExcelPackage excelPackage, Chart chart, string sheetName)
        {
            var worksheet = excelPackage.Workbook.Worksheets[sheetName];
            int rowIndex = 30;
            int colIndex = 13;
            using (MemoryStream stream = new MemoryStream())
            {
                chart.SaveImage(stream, ChartImageFormat.Png);
                var picture = worksheet.Drawings.AddPicture(sheetName, stream);
                picture.SetPosition(rowIndex, 0, colIndex, 0);
                picture.SetSize(800, 375);
            }
        }

        internal ExcelLineChart createExcelChart(DataTable dataTable, ExcelPackage package, string saveSheetName)
        {
            var worksheet = package.Workbook.Worksheets[saveSheetName];
            var chart = worksheet.Drawings.AddChart("Cizgisel", eChartType.Line) as ExcelLineChart;
            chart.SetPosition(5, 0, 13, 0);
            chart.SetSize(800, 375);
            chart.XAxis.Title.Text = "MHz";
            chart.YAxis.Title.Text = "dB";
            chart.XAxis.LabelPosition = eTickLabelPosition.High;

            chart.XAxis.Fill.Style = eFillStyle.NoFill;
            
            Color[] lineColors = { Color.DarkBlue, Color.DarkRed, Color.DarkGreen, Color.DarkOrange };
            int j = 1;
            for (int i = 1; i < dataTable.Columns.Count; i += 2)
            {

                var series = chart.Series.Add(worksheet.Cells[2, i + 1, dataTable.Rows.Count + 1, i + 1], worksheet.Cells[2, 1, dataTable.Rows.Count + 1, 1]);
                series.Header = dataTable.Columns[i].ColumnName;
                series.LineColor = lineColors[i - (j)];
                series.Fill.Style = OfficeOpenXml.Drawing.eFillStyle.SolidFill;
                j++;
            }
            //package.Save();
            return chart;
        }
      /*
        public void limitLineEkleExcelChart(string limitLineName,string sheetName,ExcelPackage package, ExcelLineChart chart, double MinMHz, double MaxMHz, double dB)
        {
            var worksheet = package.Workbook.Worksheets[sheetName];

            double startX = MinMHz;
            double endX = MaxMHz;
            double constantY = dB;

            var series = chart.Series.Add(worksheet.Cells[1, 1, 600, 1], worksheet.Cells[1, 1, 100, 1]);

            for (int i = 0; i < 600; i++)
            {
                double x = double.NaN;
                if (i>=startX && i<= endX)
                {
                    x = constantY;
                }
                series.DataPoints.Add(i, x);
            }

            series.Header = limitLineName;
            series.LineColor = Color.Black;
            series.Fill.Style = eFillStyle.SolidFill;
            
        }*/
        public void limitLineEkleExcelChart(string limitLineName, string sheetName, ExcelPackage package, ExcelLineChart chart, double MinMHz, double MaxMHz, double dB)
        {
            var worksheet = package.Workbook.Worksheets[sheetName];

            double startX = MinMHz;
            double endX = MaxMHz;
            double constantY = dB;

            // X ve Y değerlerini iki dizi olarak oluştur
            var rangeX = new double[600];
            var rangeY = new double[600];

            for (int i = 0; i < 600; i++)
            {
                // X değerlerini 0 ile 599 arasında artan şekilde doldur
                rangeX[i] =(double)i;

                // Y değerlerini belirli bir aralıkta sabit, diğerlerinde NaN olarak doldur
                if (i >= startX && i <= endX)
                {
                    rangeY[i] = constantY;
                }
                else
                {
                    rangeY[i] = double.NaN;
                }
            }
            //var line = worksheet.Drawings.AddLineChart("s", 2, 2, 2, 10);

            ExcelLineChartSerie series = chart.Series.Add(worksheet.Cells["2,1,1000,1"], worksheet.Cells["2,3,1000,3"]);

            // X ve Y değerlerini grafiğe ekle
           // //var series = chart.Series.Add(worksheet.Cells["A2:A1000"], worksheet.Cells["K2:H1000"]);
           //
           // Serinin başlığını, rengini ve stilini ayarla
            series.Header = limitLineName;
            series.LineColor = Color.Black;
            series.Border.LineStyle = eLineStyle.Dash; // Noktalı çizgi olması için bu satırı ekle
        }

    }

}
