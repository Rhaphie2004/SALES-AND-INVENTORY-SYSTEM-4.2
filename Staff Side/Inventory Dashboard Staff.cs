using LiveCharts;
using LiveCharts.Wpf;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sims.Staff_Side
{
    public partial class Inventory_Dashboard_Staff : Form
    {
        public Inventory_Dashboard_Staff()
        {
            InitializeComponent();

        }

        private void Inventory_Dashboard_Staff_Load(object sender, EventArgs e)
        {
            ItemsCount();
            ProductsCount();
            StockPreview();
            TotalSalesItems();

            TotalSalesPreview("Coffee");
        }

        public void ItemsCount()
        {
            dbModule db = new dbModule();
            string query = "SELECT COUNT(*) FROM items";

            using (MySqlConnection conn = db.GetConnection())
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        int itemCount = Convert.ToInt32(cmd.ExecuteScalar());
                        itemsCountTxt.Text = itemCount.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public void ProductsCount()
        {
            dbModule db = new dbModule();
            string query = "SELECT COUNT(*) FROM products";

            using (MySqlConnection conn = db.GetConnection())
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        int itemCount = Convert.ToInt32(cmd.ExecuteScalar());
                        productsCountTxt.Text = itemCount.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        public void TotalSalesItems()
        {
            dbModule db = new dbModule();
            MySqlConnection conn = db.GetConnection();
            MySqlCommand cmd = db.GetCommand();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable dataTable = new DataTable();

            try
            {
                conn.Open();
                cmd.Connection = conn;

                // Query to get all stocks and calculate the total of Item_Total
                cmd.CommandText = "SELECT *, SUM(Item_Total) AS TotalSales FROM stocks";

                adapter.SelectCommand = cmd;
                adapter.Fill(dataTable);

                //activityLogsBtn.DataSource = dataTable;

                // Check if the TotalSales column is present in the result
                if (dataTable.Rows.Count > 0 && dataTable.Columns.Contains("TotalSales"))
                {
                    object totalSalesValue = dataTable.Rows[0]["TotalSales"];
                    if (decimal.TryParse(totalSalesValue?.ToString(), out decimal totalSales))
                    {
                        // Format the total sales value with a peso sign
                        totalSalesLbl.Text = $"₱ {totalSales:0.00}";
                    }
                    else
                    {
                        totalSalesLbl.Text = "₱ 0.00";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to populate stock data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                cmd.Dispose();
                conn.Dispose();
            }
        }

        public void StockPreview()
        {
            dbModule db = new dbModule();
            SeriesCollection series = new SeriesCollection();
            List<string> itemNames = new List<string>();

            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT Item_Name, Stock_In FROM stocks";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        ChartValues<int> values = new ChartValues<int>();

                        while (reader.Read())
                        {
                            string itemName = reader["Item_Name"]?.ToString() ?? string.Empty;
                            if (int.TryParse(reader["Stock_In"]?.ToString(), out int itemQuantity))
                            {
                                itemNames.Add(itemName);
                                values.Add(itemQuantity);
                            }
                        }

                        series.Add(new ColumnSeries
                        {
                            Title = "Items",
                            Values = values,
                            DataLabels = true
                        });
                    }
                }

                if (stockPreviewChart != null)
                {
                    // Clear existing chart data
                    stockPreviewChart.Series.Clear();
                    stockPreviewChart.Series = series;

                    stockPreviewChart.AxisX.Clear();
                    stockPreviewChart.AxisX.Add(new Axis
                    {
                        Title = "Item Name",
                        Labels = itemNames,
                        Separator = new Separator
                        {
                            Step = 1 // Step controls the interval of labels shown
                        }
                    });

                    stockPreviewChart.AxisY.Clear();
                    stockPreviewChart.AxisY.Add(new Axis
                    {
                        Title = "Item Stocks"
                    });

                    // Set dynamic range for X-axis
                    stockPreviewChart.AxisX[0].MinValue = 0;
                    stockPreviewChart.AxisX[0].MaxValue = 10; // Initially display 10 items

                    // Attach event to dynamically update MinValue and MaxValue during scroll/zoom
                    stockPreviewChart.DataClick += (sender, args) =>
                    {
                        double viewWidth = stockPreviewChart.AxisX[0].MaxValue - stockPreviewChart.AxisX[0].MinValue;
                        double totalItems = itemNames.Count;

                        if (totalItems > viewWidth)
                        {
                            stockPreviewChart.AxisX[0].MinValue = Math.Max(0, stockPreviewChart.AxisX[0].MinValue);
                            stockPreviewChart.AxisX[0].MaxValue = Math.Min(totalItems, stockPreviewChart.AxisX[0].MaxValue);
                        }
                    };

                    // Update the chart
                    stockPreviewChart.Update(true, true);
                }
                else
                {
                    MessageBox.Show("Cartesian chart is not initialized!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        public void TotalSalesPreview(string category)
        {
            dbModule db = new dbModule();
            SeriesCollection series = new SeriesCollection();
            decimal totalSales = 0;

            try
            {
                // Determine the table name based on the category
                string tableName = DetermineTableName(category);
                if (string.IsNullOrEmpty(tableName))
                {
                    MessageBox.Show($"Invalid category: {category}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    // Get total sales for the category
                    string totalSalesQuery = $"SELECT SUM(Total_Product_Sale) AS TotalSales FROM {tableName}";
                    MySqlCommand totalSalesCmd = new MySqlCommand(totalSalesQuery, conn);
                    totalSales = Convert.ToDecimal(totalSalesCmd.ExecuteScalar());

                    // Get sales per product
                    string query = $"SELECT Product_Name, SUM(Total_Product_Sale) AS TotalSales FROM {tableName} GROUP BY Product_Name";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string productName = reader["Product_Name"]?.ToString() ?? "Unknown Product";
                            if (decimal.TryParse(reader["TotalSales"]?.ToString(), out decimal productSales))
                            {
                                series.Add(new PieSeries
                                {
                                    Title = productName,
                                    Values = new ChartValues<decimal> { productSales },
                                    DataLabels = true
                                });
                            }
                        }
                    }
                }

                if (DailySalesChart != null)
                {
                    // Clear and set the pie chart series
                    DailySalesChart.Series.Clear();
                    DailySalesChart.Series = series;

                    // Update chart properties
                    DailySalesChart.LegendLocation = LegendLocation.Bottom;
                    DailySalesChart.Update(true, true);

                    // Update the title label
                    chartTitleLabel.Text = $"{category} Sales";
                    chartTitleLabel.Font = new Font("Poppins", 11);
                    chartTitleLabel.TextAlign = ContentAlignment.MiddleCenter;
                }
                else
                {
                    MessageBox.Show("Pie chart is not initialized!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string DetermineTableName(string category)
        {
            if (category.Equals("Coffee", StringComparison.OrdinalIgnoreCase))
            {
                return "productsales_coffee";
            }
            else if (category.Equals("Non-Coffee", StringComparison.OrdinalIgnoreCase))
            {
                return "productsales_noncoffee";
            }
            else if (category.Equals("Hot Coffee", StringComparison.OrdinalIgnoreCase))
            {
                return "productsales_hotcoffee";
            }

            return string.Empty;
        }

        private void CoffeeMenuItem_Click(object sender, EventArgs e)
        {
            TotalSalesPreview("Coffee");
        }

        private void NonCoffeeMenuItem_Click(object sender, EventArgs e)
        {
            TotalSalesPreview("Non-Coffee");
        }

        private void HotCoffeeMenuItem_Click(object sender, EventArgs e)
        {
            TotalSalesPreview("Hot Coffee");
        }
    }
}
