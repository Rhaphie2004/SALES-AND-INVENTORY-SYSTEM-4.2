using MySql.Data.MySqlClient;
using sims.Notification;
using System;
using System.Data;
using System.Windows.Forms;

namespace sims.Admin_Side.Category
{
    public partial class New_Category : Form
    {
        private Manage_Categoryy dashboardForm;
        private Dashboard_Inventory _inventoryDashboard;

        public New_Category(Manage_Categoryy dashboardForm, Dashboard_Inventory inventoryDashboard)
        {
            InitializeComponent();
            this.dashboardForm = dashboardForm;

            _inventoryDashboard = inventoryDashboard;
        }

        public class Categories
        {
            public int CategoryID { get; set; }
            public string Category { get; set; }
        }

        public void Alert(string msg)
        {
            Category_Added frm = new Category_Added();
            frm.showalert(msg);
        }

        private void New_Category_Load(object sender, EventArgs e)
        {
            GenerateRandomItemID();
            Populate();
            CategoryCount();
        }

        private void CategoryCount()
        {
            if (_inventoryDashboard != null)
            {
                _inventoryDashboard.CategoriesCount();
            }
            else
            {
                MessageBox.Show("Inventory Dashboard is not available.");
            }
        }

        private void GenerateRandomItemID()
        {
            Random random = new Random();
            int randomNumber = random.Next(10000000, 99999999);
            categoryIDTxt.Text = randomNumber.ToString();
        }

        private void Populate()
        {
            dbModule db = new dbModule();
            MySqlDataAdapter adapter = db.GetAdapter();
            using (MySqlConnection conn = db.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM categories";
                    MySqlCommand command = new MySqlCommand(query, conn);
                    adapter.SelectCommand = command;
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dashboardForm.RecentlyAddedDgv.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void addCategoryBtn_Click(object sender, EventArgs e)
        {
            addCategory();
        }

        private void addCategory()
        {
            dbModule db = new dbModule();

            string categoryID = categoryIDTxt.Text.Trim();
            string categoryName = categoryNameTxt.Text.Trim();
            string categoryDescription = categoryDescriptionTxt.Text.Trim();

            if (string.IsNullOrEmpty(categoryName) || string.IsNullOrEmpty(categoryDescription))
            {
                new Messages_Boxes.Field_Required().Show();
                return;
            }

            using (MySqlConnection conn = db.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO categories (Category_ID, Category_Name, Category_Description) VALUES (@Category_ID, @Category_Name, @Category_Description)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Category_ID", categoryID);
                        cmd.Parameters.AddWithValue("@Category_Name", categoryName);
                        cmd.Parameters.AddWithValue("@Category_Description", categoryDescription);
                        cmd.ExecuteNonQuery();

                        this.Close();
                        categoryNameTxt.Clear();
                        categoryDescriptionTxt.Clear();
                        GenerateRandomItemID();
                        this.Alert("Category Added Successfully");
                        Populate();
                        CategoryCount();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error adding category: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void backNewCatBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void categoryNameTxt_TextChanged(object sender, EventArgs e)
        {
            string newText = categoryNameTxt.Text;

            if (System.Text.RegularExpressions.Regex.IsMatch(newText, @"\d"))
            {
                MessageBox.Show("Numbers are not allowed!", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                categoryNameTxt.Text = System.Text.RegularExpressions.Regex.Replace(newText, @"\d", "");
                categoryNameTxt.SelectionStart = categoryNameTxt.Text.Length;
            }
        }
    }
}
