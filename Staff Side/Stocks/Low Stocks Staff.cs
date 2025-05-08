using sims.Admin_Side.Stocks;
using sims.Admin_Side;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace sims.Staff_Side.Stocks
{
    public partial class Low_Stocks_Staff : Form
    {
        private Inventory_Dashboard_Staff _inventoryDashboard;
        private Manage_Stocks_Staff dashboard;

        public Low_Stocks_Staff(Inventory_Dashboard_Staff _inventoryDashboard, Manage_Stocks_Staff dashboard)
        {
            InitializeComponent();
            this.dashboard = dashboard;
        }

        public DataGridView ItemsLowStockDgv
        {
            get { return itemStockDgv; }
        }

        private void Low_Stocks_Staff_Load(object sender, EventArgs e)
        {
            ViewStock();
        }

        public void ViewStock()
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
                cmd.CommandText = "SELECT * FROM lowstocks";

                adapter.SelectCommand = cmd;
                adapter.Fill(dataTable);

                itemStockDgv.DataSource = dataTable;
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

        private void DeleteStockBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
