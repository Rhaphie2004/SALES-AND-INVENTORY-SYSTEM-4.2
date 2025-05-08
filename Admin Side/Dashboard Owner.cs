using FontAwesome.Sharp;
using Guna.UI.WinForms;
using MySql.Data.MySqlClient;
using sims.Admin_Side;
using sims.Admin_Side.Category;
using sims.Admin_Side.Database;
using sims.Admin_Side.Inventory_Report;
using sims.Admin_Side.Items;
using sims.Admin_Side.Sales;
using sims.Admin_Side.Sales_Report;
using sims.Admin_Side.Stocks;
using sims.Admin_Side.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sims
{
    public partial class DashboardOwner : Form
    {
        private IconButton currentBtn;
        private GunaPanel leftBorderBtn;

        private string _category;
        private Dashboard_Inventory dashboardInventoryInstance;
        private Manage_Categoryy manageCategoryInstance;
        private Manage_Items manageItemsInstance;
        private Manage_Stockk manageStockInstance;
        private Inventory_Reportt inventoryReportInstance;
        private Product_Saless productSalesInstance;
        private Sales_Report manageSalesReportInstance;
        private Manage_User_Staff manageUserStaffInstance;
        private Database_Backup databaseBackupInstance;
        private Add_Stock addStockInstance;

        public DashboardOwner()
        {
            InitializeComponent();
            ShowUsernameWithGreeting();
            customizeDesign();
            leftBorderBtn = new GunaPanel
            {
                Size = new Size(10, 58)
            };
            PanelMenu.Controls.Add(leftBorderBtn);
        }

        private void DashboardOwner_Load(object sender, EventArgs e)
        {
            dashboardInventoryInstance = new Dashboard_Inventory(_category);
            manageCategoryInstance = new Manage_Categoryy(dashboardInventoryInstance);
            manageItemsInstance = new Manage_Items(dashboardInventoryInstance);
            manageStockInstance = new Manage_Stockk(dashboardInventoryInstance, addStockInstance, inventoryReportInstance);
            inventoryReportInstance = new Inventory_Reportt();
            productSalesInstance = new Product_Saless(dashboardInventoryInstance, manageStockInstance, addStockInstance, inventoryReportInstance);
            manageSalesReportInstance = new Sales_Report();
            manageUserStaffInstance = new Manage_User_Staff();
            databaseBackupInstance = new Database_Backup();

            LoadView(dashboardInventoryInstance);
            ActivateButton(DashboardBtn, Color.White);

            ShowUsernameWithGreeting();
        }

        private void ShowUsernameWithGreeting()
        {
            dbModule db = new dbModule();
            string query = "SELECT username FROM users LIMIT 1";

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

        private void customizeDesign()
        {
            InventoryPanelSubMenu.Visible = false;
            salesPanelSubMenu.Visible = false;
        }

        private void hideSubMenu()
        {
            if (InventoryPanelSubMenu.Visible == true)
                InventoryPanelSubMenu.Visible = false;
        }

        private void hideSubMenu2()
        {
            if (salesPanelSubMenu.Visible == true)
                salesPanelSubMenu.Visible = false;
        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                hideSubMenu2();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
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
            leftBorderBtn.Visible = false;
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
            customizeDesign();
        }

        private void CategoriesBtn_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.FromArgb(255, 255, 255));
            OpeninPanel(manageCategoryInstance);
            customizeDesign();
        }

        private void inventoryBtn_Click(object sender, EventArgs e)
        {
            showSubMenu(InventoryPanelSubMenu);
        }

        private void ItemsBtn_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.FromArgb(255, 255, 255));
            OpeninPanel(manageItemsInstance);

        }

        private void StocksBtn_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.FromArgb(255, 255, 255));
            OpeninPanel(manageStockInstance);

        }

        private void inventoryReport_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.FromArgb(255, 255, 255));
            OpeninPanel(inventoryReportInstance);
        }

        private void SalesBtn_Click(object sender, EventArgs e)
        {
            showSubMenu(salesPanelSubMenu);
        }

        private void productSalesBtn_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.FromArgb(255, 255, 255));
            OpeninPanel(productSalesInstance);
        }

        private void salesReportBtn_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.FromArgb(255, 255, 255));
            OpeninPanel(manageSalesReportInstance);
        }

        private void UserBtn_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.FromArgb(255, 255, 255));
            OpeninPanel(manageUserStaffInstance);
            customizeDesign();
        }

        private void backupDbBtn_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.FromArgb(255, 255, 255));
            OpeninPanel(databaseBackupInstance);
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