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
using sims.Notification.Stock_notification;
using System.IO;
using MySql.Data.MySqlClient;

namespace sims.Staff_Side.Stocks
{
    public partial class Manage_Stocks_Staff : Form
    {
        private Inventory_Dashboard_Staff _inventoryDashboard;
        private Add_Stocks_Staff _addStock;

        public Manage_Stocks_Staff(Inventory_Dashboard_Staff inventoryDashboard, Add_Stock _addStock)
        {
            InitializeComponent();
            _inventoryDashboard = inventoryDashboard;
            itemStockDgv.CellFormatting += itemStockDgv_CellFormatting;
        }
        public DataGridView ItemsStockDgv
        {
            get { return itemStockDgv; }
        }

        public void Alert(string msg)
        {
            Stock_Deleted frm = new Stock_Deleted();
            frm.showalert(msg);
        }

        private byte[] ImageToByteArray(System.Drawing.Image image)
        {
            if (image == null)
                throw new ArgumentNullException(nameof(image), "Image cannot be null.");

            using (var ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }

        private void Manage_Stocks_Staff_Load(object sender, EventArgs e)
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
                cmd.CommandText = "SELECT * FROM stocks";

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

        private void previewStock()
        {
            if (_inventoryDashboard != null)
            {
                _inventoryDashboard.StockPreview();
            }
            else
            {
                MessageBox.Show("Inventory Dashboard is not available.");
            }
        }

        private void TotalSales()
        {
            if (_inventoryDashboard != null)
            {
                _inventoryDashboard.TotalSalesItems();
            }
            else
            {
                MessageBox.Show("Inventory Dashboard is not available.");
            }
        }

        private DataTable SearchInDatabase(string searchTerm)
        {
            DataTable dataTable = new DataTable();
            dbModule db = new dbModule();

            using (MySqlConnection conn = db.GetConnection())
            {
                conn.Open();

                string query = "SELECT Stock_ID, Item_ID, Item_Name, Stock_In, Unit_Type, Date_Added, Item_Price, Item_Total, Item_Image " +
                               "FROM stocks WHERE Item_Name LIKE @SearchTerm";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@SearchTerm", "%" + searchTerm + "%");

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }

            return dataTable;
        }

        private void searchCategoryTxt_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = searchCategoryTxt.Text.Trim();

            // Search for results in the database
            DataTable searchResultDataTable = SearchInDatabase(searchTerm);

            // Bind the search results to the DataGridView
            itemStockDgv.DataSource = searchResultDataTable;

            // Clear selection in the DataGridView
            itemStockDgv.ClearSelection();
        }

        private void DeleteStockBtn_Click(object sender, EventArgs e)
        {
            removeStock();
        }

        private void removeStock()
        {
            if (itemStockDgv.SelectedCells.Count == 0)
            {
                MessageBox.Show("Please select a record to delete.", "Notice!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to delete stock?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                try
                {
                    int selectedRowIndex = itemStockDgv.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = itemStockDgv.Rows[selectedRowIndex];
                    string selectedItemID = selectedRow.Cells["Stock_ID"]?.Value?.ToString();

                    if (!string.IsNullOrEmpty(selectedItemID))
                    {
                        DeleteRecord(selectedItemID);
                        itemStockDgv.Rows.RemoveAt(selectedRowIndex);
                        this.Alert("Stock successfully deleted.");
                        ViewStock();
                        previewStock();
                        TotalSales();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Stock ID. Unable to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DeleteRecord(string stockID)
        {
            dbModule db = new dbModule();
            string query = "DELETE FROM stocks WHERE Stock_ID = @Stock_ID";

            using (MySqlConnection conn = db.GetConnection())
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Stock_ID", stockID);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected == 0)
                        {
                            MessageBox.Show("No record found to delete.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error while deleting the record: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void itemStockDgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            int stockColumnIndex = itemStockDgv.Columns["Stock_In"].Index;

            if (e.ColumnIndex == stockColumnIndex && e.Value != null)
            {
                int stockLevel = Convert.ToInt32(e.Value);

                // Define stock level thresholds
                int lowStockThreshold = 0;    // Stock is low if ≤ 0
                int normalStockThreshold = 30; // Stock is normal if > 5 and ≤ 30

                // Set the background color based on stock level
                if (stockLevel <= lowStockThreshold)
                {
                    e.CellStyle.BackColor = Color.Red;
                    e.CellStyle.ForeColor = Color.White;

                    // Get the item details from the DataGridView
                    int itemID = Convert.ToInt32(itemStockDgv.Rows[e.RowIndex].Cells["Item_ID"].Value);
                    string itemName = itemStockDgv.Rows[e.RowIndex].Cells["Item_Name"].Value.ToString();
                    string unitType = itemStockDgv.Rows[e.RowIndex].Cells["Unit_Type"].Value.ToString();
                    decimal itemPrice = Convert.ToDecimal(itemStockDgv.Rows[e.RowIndex].Cells["Item_Price"].Value);
                    decimal itemTotal = Convert.ToDecimal(itemStockDgv.Rows[e.RowIndex].Cells["Item_Total"].Value);

                    // Convert byte[] to Image for Item_Image
                    byte[] imageBytes = (byte[])itemStockDgv.Rows[e.RowIndex].Cells["Item_Image"].Value;
                    System.Drawing.Image itemImage = null;

                    if (imageBytes != null && imageBytes.Length > 0)
                    {
                        using (var ms = new MemoryStream(imageBytes))
                        {
                            itemImage = System.Drawing.Image.FromStream(ms);
                        }
                    }

                    // Insert the low stock data into the lowstocks table
                    InsertLowStockItem(itemID, itemName, stockLevel, unitType, itemPrice, itemTotal, itemImage);
                }
                else if (stockLevel <= normalStockThreshold)
                {
                    e.CellStyle.BackColor = Color.Green;
                    e.CellStyle.ForeColor = Color.White;
                }
                else
                {
                    e.CellStyle.BackColor = Color.Orange;
                    e.CellStyle.ForeColor = Color.Black;
                }
            }
        }
        private void InsertLowStockItem(int itemID, string itemName, int stockLevel, string unitType, decimal itemPrice, decimal itemTotal, System.Drawing.Image itemImage)
        {
            dbModule db = new dbModule();
            MySqlConnection conn = db.GetConnection();
            MySqlCommand cmd = db.GetCommand();

            try
            {
                conn.Open();
                cmd.Connection = conn;

                // Check if the item already exists in the lowstocks table
                cmd.CommandText = "SELECT COUNT(*) FROM lowstocks WHERE Item_Name = @Item_Name";
                cmd.Parameters.AddWithValue("@Item_Name", itemName);
                int count = Convert.ToInt32(cmd.ExecuteScalar());

                if (count == 0)
                {
                    // Insert the low stock item into the lowstocks table
                    cmd.CommandText = "INSERT INTO lowstocks (Item_ID, Item_Name, Stock_In, Unit_Type, Item_Price, Item_Total, Item_Image, Date_Added) " +
                                      "VALUES (@Item_ID, @Item_Name, @Stock_In, @Unit_Type, @Item_Price, @Item_Total, @Item_Image, @Date_Added)";

                    cmd.Parameters.Clear(); // Clear parameters to avoid conflicts
                    cmd.Parameters.AddWithValue("@Item_ID", itemID);
                    cmd.Parameters.AddWithValue("@Item_Name", itemName);
                    cmd.Parameters.AddWithValue("@Stock_In", stockLevel);
                    cmd.Parameters.AddWithValue("@Unit_Type", unitType);
                    cmd.Parameters.AddWithValue("@Item_Price", itemPrice);
                    cmd.Parameters.AddWithValue("@Item_Total", itemTotal);

                    // Convert the image to a byte array
                    byte[] imageBytes = itemImage != null ? ImageToByteArray(ResizeImage(itemImage, 300, 300)) : null;
                    cmd.Parameters.AddWithValue("@Item_Image", imageBytes ?? (object)DBNull.Value);

                    cmd.Parameters.AddWithValue("@Date_Added", DateTime.Now.ToString("yyyy-MM-dd"));

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        // Successfully added to lowstocks, delete from stocks table
                        cmd.CommandText = "DELETE FROM stocks WHERE Item_ID = @Item_ID";
                        cmd.Parameters.Clear(); // Clear parameters to avoid conflicts
                        cmd.Parameters.AddWithValue("@Item_ID", itemID);

                        int deleteRows = cmd.ExecuteNonQuery();

                        if (deleteRows > 0)
                        {
                            MessageBox.Show($"Item '{itemName}' moved to low stocks and removed from stocks.",
                                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ViewStock();
                        }
                        else
                        {
                            MessageBox.Show($"Failed to delete item '{itemName}' from stocks.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to process low stock item: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private System.Drawing.Image ResizeImage(System.Drawing.Image image, int width, int height)
        {
            var destRect = new System.Drawing.Rectangle(0, 0, width, height);
            var destImage = new System.Drawing.Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = System.Drawing.Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

                using (var wrapMode = new System.Drawing.Imaging.ImageAttributes())
                {
                    wrapMode.SetWrapMode(System.Drawing.Drawing2D.WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, System.Drawing.GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        private void lowStocksBtn_Click(object sender, EventArgs e)
        {
            var lowStock = new Low_Stocks_Staff(_inventoryDashboard, this);
            lowStock.Show();
        }

        private void NewStockBtn_Click(object sender, EventArgs e)
        {
            // Check if the form is already open
            if (_addStock == null || _addStock.IsDisposed)
            {
                _addStock = new Add_Stocks_Staff(this, _inventoryDashboard);
                _addStock.Show();
            }
            else
            {
                // If the form is already open, bring it to the front
                _addStock.BringToFront();
            }
        }

        private void UpdateStockBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to update this record?", "Update Item!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                try
                {
                    int selectedRowIndex = itemStockDgv.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = itemStockDgv.Rows[selectedRowIndex];
                    string itemID = selectedRow.Cells["Stock_ID"]?.Value?.ToString();
                    if (!string.IsNullOrEmpty(itemID))
                    {
                        var updateProductForm = new Edit_Stocks_Staff(itemID, _inventoryDashboard, this);
                        updateProductForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Item_ID. Unable to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
