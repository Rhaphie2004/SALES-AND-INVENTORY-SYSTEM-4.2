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

namespace sims.Admin_Side.Inventory_Report
{
    public partial class Inventory_Reportt : Form
    {
        public Inventory_Reportt()
        {
            InitializeComponent();
        }

        private void Inventory_Reportt_Load(object sender, EventArgs e)
        {
            PopulateStocks();
        }

        public void PopulateStocks()
        {
            dbModule db = new dbModule();
            MySqlDataAdapter adapter = db.GetAdapter();
            using (MySqlConnection conn = db.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM stocks";
                    MySqlCommand command = new MySqlCommand(query, conn);
                    adapter.SelectCommand = command;

                    // Fill the DataTable with data from the "stocks" table
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Use the embedded Crystal Report
                    sims.Stocks_Report stocksReport = new sims.Stocks_Report();

                    // Set the DataTable as the data source for the report
                    stocksReport.SetDataSource(dt);

                    // Assign the report to the CrystalReportViewer
                    crystalReportViewer1.ReportSource = stocksReport;
                    crystalReportViewer1.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
