    using FontAwesome.Sharp;
using Guna.UI.WinForms;
using MySql.Data.MySqlClient;
using sims.Admin_Side;
using sims.Admin_Side.Items;
using sims.Admin_Side.Stocks;
using sims.Staff_Side.Items;
using sims.Staff_Side.Stocks;
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
    public partial class Dashboard_Staff : Form
    {
        private IconButton currentBtn;
        private GunaPanel leftBorderBtn;

        private Inventory_Dashboard_Staff dashboardInventoryInstance;
        private Manage_Items_Staff manageItemsStaffInstance;
        private Manage_Stocks_Staff manageStocksStaffInstance;
        private Add_Stock addStockInstance;

        public Dashboard_Staff()
        {
            InitializeComponent();
            leftBorderBtn = new GunaPanel
            {
                Size = new Size(10, 58)
            };
            PanelMenu.Controls.Add(leftBorderBtn);
        }

        private void Dashboard_Staff_Load(object sender, EventArgs e)
        {
            ShowUsernameWithGreeting();

            dashboardInventoryInstance = new Inventory_Dashboard_Staff();
            manageItemsStaffInstance = new Manage_Items_Staff(dashboardInventoryInstance);
            manageStocksStaffInstance = new Manage_Stocks_Staff(dashboardInventoryInstance, addStockInstance);

            LoadView(dashboardInventoryInstance);
            ActivateButton(DashboardBtn, Color.White);
        }

        private void ShowUsernameWithGreeting()
        {
            dbModule db = new dbModule();
            string query = "SELECT Staff_Name FROM staff LIMIT 1";

            using (MySqlConnection conn = db.GetConnection())
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        object result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            string username = result.ToString();
                            greetingNameTxt.Text = $"HI! {username},";
                        }
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
        private void LoadView(object viewInstance)
        {
            foreach (Control control in DashboardPanel.Controls)
            {
                control.Visible = false;
            }

            if (viewInstance is UserControl uc)
            {
                if (!DashboardPanel.Controls.Contains(uc))
                {
                    uc.Dock = DockStyle.Fill;
                    DashboardPanel.Controls.Add(uc);
                }
                uc.Visible = true;
                uc.BringToFront();
            }
            else if (viewInstance is Form form)
            {
                if (!DashboardPanel.Controls.Contains(form))
                {
                    form.TopLevel = false;
                    form.FormBorderStyle = FormBorderStyle.None;
                    form.Dock = DockStyle.Fill;
                    DashboardPanel.Controls.Add(form);
                }
                form.Visible = true;
                form.BringToFront();
            }
            else
            {
                throw new InvalidOperationException("Unsupported type. Only UserControl and Form are allowed.");
            }
        }

        private void ActivateButton(object senderBtn, Color customColor)
        {
            if (senderBtn == null) return;
            DisableBtn();
            currentBtn = (IconButton)senderBtn;
            currentBtn.BackColor = Color.FromArgb(222, 196, 125);
            currentBtn.ForeColor = customColor;
            currentBtn.IconColor = customColor;
            currentBtn.TextAlign = ContentAlignment.MiddleCenter;
            currentBtn.ImageAlign = ContentAlignment.MiddleRight;
            currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
            leftBorderBtn.BackColor = customColor;
            leftBorderBtn.Size = new Size(7, currentBtn.Height);
            leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
            leftBorderBtn.Visible = true;
            leftBorderBtn.BringToFront();
        }

        private void OpeninPanel(object formOpen)
        {
            foreach (Control control in DashboardPanel.Controls)
            {
                control.Visible = false;
            }

            if (formOpen is UserControl uc)
            {
                if (!DashboardPanel.Controls.Contains(uc))
                {
                    uc.Dock = DockStyle.Fill;
                    DashboardPanel.Controls.Add(uc);
                    DashboardPanel.Tag = uc;
                }

                uc.Visible = true;
                uc.BringToFront();
            }
            else if (formOpen is Form dh)
            {
                if (!DashboardPanel.Controls.Contains(dh))
                {
                    dh.TopLevel = false;
                    dh.FormBorderStyle = FormBorderStyle.None;
                    dh.Dock = DockStyle.Fill;
                    DashboardPanel.Controls.Add(dh);
                    DashboardPanel.Tag = dh;
                }

                dh.Visible = true;
                dh.BringToFront();
            }
        }

        private void DisableBtn()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(255, 255, 255);
                currentBtn.ForeColor = Color.Black;
                currentBtn.IconColor = Color.Black;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            }
        }

        private void DashboardBtn_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.White);
            foreach (Control control in DashboardPanel.Controls)
            {
                control.Visible = false;
            }
            dashboardInventoryInstance.Visible = true;
            dashboardInventoryInstance.BringToFront();
        }

        private void ItemsBtn_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.FromArgb(255, 255, 255));
            OpeninPanel(manageItemsStaffInstance);
        }

        private void StocksBtn_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.FromArgb(255, 255, 255));
            OpeninPanel(manageStocksStaffInstance);
        }

        private void inventoryReport_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.FromArgb(255, 255, 255));
        }

        private void productSalesBtn_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.FromArgb(255, 255, 255));
        }

        private void salesReportBtn_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.FromArgb(255, 255, 255));
        }

        private void SignoutBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to logout?",
                "Logout?",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning
            );
            if (result == DialogResult.OK)
            {
                this.Hide();
                new Login_Form().Show();
            }
        }

    }
}