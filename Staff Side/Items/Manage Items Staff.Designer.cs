namespace sims.Staff_Side.Items
{
    partial class Manage_Items_Staff
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Manage_Items_Staff));
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties5 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties6 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties7 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties8 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            this.Item_Image = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Item_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemsDgv = new Guna.UI.WinForms.GunaDataGridView();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeleteItemBtn = new Guna.UI.WinForms.GunaButton();
            this.UpdateItemBtn = new Guna.UI.WinForms.GunaButton();
            this.panel5 = new System.Windows.Forms.Panel();
            this.gunaGroupBox2 = new Guna.UI.WinForms.GunaGroupBox();
            this.NewItemBtn = new Guna.UI.WinForms.GunaButton();
            this.refreshBtn = new FontAwesome.Sharp.IconButton();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.searchItemTxt = new Bunifu.UI.WinForms.BunifuTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.searchCategoryCmb = new Guna.UI.WinForms.GunaComboBox();
            this.gunaGroupBox3 = new Guna.UI.WinForms.GunaGroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.GunaPictureBox3 = new Guna.UI.WinForms.GunaPictureBox();
            this.itemCountTxt = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.GunaGroupBox1 = new Guna.UI.WinForms.GunaGroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.gunaElipsePanel2 = new Guna.UI.WinForms.GunaElipsePanel();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.itemsDgv)).BeginInit();
            this.panel5.SuspendLayout();
            this.gunaGroupBox2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.gunaGroupBox3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GunaPictureBox3)).BeginInit();
            this.GunaGroupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.gunaElipsePanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Item_Image
            // 
            this.Item_Image.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Item_Image.DataPropertyName = "Item_Image";
            this.Item_Image.HeaderText = "Item Image";
            this.Item_Image.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Item_Image.Name = "Item_Image";
            this.Item_Image.ReadOnly = true;
            this.Item_Image.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Item_Image.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Item_Image.Width = 127;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Category";
            this.Column3.HeaderText = "Category";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Item_Name";
            this.Column2.HeaderText = "Item Name";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Item_ID
            // 
            this.Item_ID.DataPropertyName = "Item_ID";
            this.Item_ID.HeaderText = "Item ID";
            this.Item_ID.Name = "Item_ID";
            this.Item_ID.ReadOnly = true;
            this.Item_ID.Visible = false;
            // 
            // itemsDgv
            // 
            this.itemsDgv.AllowUserToAddRows = false;
            this.itemsDgv.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.itemsDgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.itemsDgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.itemsDgv.BackgroundColor = System.Drawing.Color.White;
            this.itemsDgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.itemsDgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.itemsDgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(178)))), ((int)(((byte)(84)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(178)))), ((int)(((byte)(84)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.itemsDgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.itemsDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.itemsDgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Item_ID,
            this.Column2,
            this.Column3,
            this.Column7,
            this.Item_Image});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.itemsDgv.DefaultCellStyle = dataGridViewCellStyle6;
            this.itemsDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemsDgv.EnableHeadersVisualStyles = false;
            this.itemsDgv.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.itemsDgv.Location = new System.Drawing.Point(0, 0);
            this.itemsDgv.Name = "itemsDgv";
            this.itemsDgv.ReadOnly = true;
            this.itemsDgv.RowHeadersVisible = false;
            this.itemsDgv.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.itemsDgv.RowTemplate.Height = 100;
            this.itemsDgv.RowTemplate.ReadOnly = true;
            this.itemsDgv.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.itemsDgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.itemsDgv.Size = new System.Drawing.Size(1147, 351);
            this.itemsDgv.TabIndex = 3;
            this.itemsDgv.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.Guna;
            this.itemsDgv.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.itemsDgv.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.itemsDgv.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.itemsDgv.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.itemsDgv.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.itemsDgv.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.itemsDgv.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.itemsDgv.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(178)))), ((int)(((byte)(84)))));
            this.itemsDgv.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.itemsDgv.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemsDgv.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.itemsDgv.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.itemsDgv.ThemeStyle.HeaderStyle.Height = 30;
            this.itemsDgv.ThemeStyle.ReadOnly = true;
            this.itemsDgv.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.itemsDgv.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.itemsDgv.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemsDgv.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.itemsDgv.ThemeStyle.RowsStyle.Height = 100;
            this.itemsDgv.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.itemsDgv.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "Item_Description";
            this.Column7.HeaderText = "Item Description";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // DeleteItemBtn
            // 
            this.DeleteItemBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DeleteItemBtn.AnimationHoverSpeed = 0.07F;
            this.DeleteItemBtn.AnimationSpeed = 0.03F;
            this.DeleteItemBtn.BackColor = System.Drawing.Color.Transparent;
            this.DeleteItemBtn.BaseColor = System.Drawing.Color.Transparent;
            this.DeleteItemBtn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(178)))), ((int)(((byte)(84)))));
            this.DeleteItemBtn.BorderSize = 2;
            this.DeleteItemBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DeleteItemBtn.DialogResult = System.Windows.Forms.DialogResult.None;
            this.DeleteItemBtn.FocusedColor = System.Drawing.Color.Empty;
            this.DeleteItemBtn.Font = new System.Drawing.Font("Poppins", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteItemBtn.ForeColor = System.Drawing.Color.Black;
            this.DeleteItemBtn.Image = null;
            this.DeleteItemBtn.ImageSize = new System.Drawing.Size(20, 20);
            this.DeleteItemBtn.Location = new System.Drawing.Point(1011, 426);
            this.DeleteItemBtn.Name = "DeleteItemBtn";
            this.DeleteItemBtn.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(178)))), ((int)(((byte)(84)))));
            this.DeleteItemBtn.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(178)))), ((int)(((byte)(84)))));
            this.DeleteItemBtn.OnHoverForeColor = System.Drawing.Color.White;
            this.DeleteItemBtn.OnHoverImage = null;
            this.DeleteItemBtn.OnPressedColor = System.Drawing.Color.White;
            this.DeleteItemBtn.Radius = 6;
            this.DeleteItemBtn.Size = new System.Drawing.Size(147, 35);
            this.DeleteItemBtn.TabIndex = 33;
            this.DeleteItemBtn.Text = "Delete Item";
            this.DeleteItemBtn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.DeleteItemBtn.TextRenderingHint = Guna.UI.WinForms.DrawingTextRenderingHint.AntiAlias;
            this.DeleteItemBtn.Click += new System.EventHandler(this.DeleteItemBtn_Click);
            // 
            // UpdateItemBtn
            // 
            this.UpdateItemBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.UpdateItemBtn.AnimationHoverSpeed = 0.07F;
            this.UpdateItemBtn.AnimationSpeed = 0.03F;
            this.UpdateItemBtn.BackColor = System.Drawing.Color.Transparent;
            this.UpdateItemBtn.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(178)))), ((int)(((byte)(84)))));
            this.UpdateItemBtn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(178)))), ((int)(((byte)(84)))));
            this.UpdateItemBtn.BorderSize = 2;
            this.UpdateItemBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.UpdateItemBtn.DialogResult = System.Windows.Forms.DialogResult.None;
            this.UpdateItemBtn.FocusedColor = System.Drawing.Color.Empty;
            this.UpdateItemBtn.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateItemBtn.ForeColor = System.Drawing.Color.White;
            this.UpdateItemBtn.Image = null;
            this.UpdateItemBtn.ImageSize = new System.Drawing.Size(20, 20);
            this.UpdateItemBtn.Location = new System.Drawing.Point(858, 426);
            this.UpdateItemBtn.Name = "UpdateItemBtn";
            this.UpdateItemBtn.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(178)))), ((int)(((byte)(84)))));
            this.UpdateItemBtn.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(178)))), ((int)(((byte)(84)))));
            this.UpdateItemBtn.OnHoverForeColor = System.Drawing.Color.White;
            this.UpdateItemBtn.OnHoverImage = null;
            this.UpdateItemBtn.OnPressedColor = System.Drawing.Color.White;
            this.UpdateItemBtn.Radius = 4;
            this.UpdateItemBtn.Size = new System.Drawing.Size(147, 35);
            this.UpdateItemBtn.TabIndex = 32;
            this.UpdateItemBtn.Text = "Edit Item";
            this.UpdateItemBtn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.UpdateItemBtn.TextRenderingHint = Guna.UI.WinForms.DrawingTextRenderingHint.AntiAlias;
            this.UpdateItemBtn.Click += new System.EventHandler(this.UpdateItemBtn_Click);
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.itemsDgv);
            this.panel5.Location = new System.Drawing.Point(9, 56);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1149, 353);
            this.panel5.TabIndex = 30;
            // 
            // gunaGroupBox2
            // 
            this.gunaGroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gunaGroupBox2.BackColor = System.Drawing.Color.Transparent;
            this.gunaGroupBox2.BaseColor = System.Drawing.Color.White;
            this.gunaGroupBox2.BorderColor = System.Drawing.Color.Gainsboro;
            this.gunaGroupBox2.Controls.Add(this.DeleteItemBtn);
            this.gunaGroupBox2.Controls.Add(this.UpdateItemBtn);
            this.gunaGroupBox2.Controls.Add(this.NewItemBtn);
            this.gunaGroupBox2.Controls.Add(this.panel5);
            this.gunaGroupBox2.Font = new System.Drawing.Font("Poppins", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaGroupBox2.LineColor = System.Drawing.Color.White;
            this.gunaGroupBox2.LineTop = 0;
            this.gunaGroupBox2.Location = new System.Drawing.Point(11, 208);
            this.gunaGroupBox2.Name = "gunaGroupBox2";
            this.gunaGroupBox2.Radius = 10;
            this.gunaGroupBox2.Size = new System.Drawing.Size(1170, 476);
            this.gunaGroupBox2.TabIndex = 51;
            this.gunaGroupBox2.Text = "Soothing Café Items";
            this.gunaGroupBox2.TextLocation = new System.Drawing.Point(10, 13);
            this.gunaGroupBox2.TextRenderingHint = Guna.UI.WinForms.DrawingTextRenderingHint.AntiAlias;
            // 
            // NewItemBtn
            // 
            this.NewItemBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.NewItemBtn.AnimationHoverSpeed = 0.07F;
            this.NewItemBtn.AnimationSpeed = 0.03F;
            this.NewItemBtn.BackColor = System.Drawing.Color.Transparent;
            this.NewItemBtn.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(178)))), ((int)(((byte)(84)))));
            this.NewItemBtn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(178)))), ((int)(((byte)(84)))));
            this.NewItemBtn.BorderSize = 2;
            this.NewItemBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.NewItemBtn.DialogResult = System.Windows.Forms.DialogResult.None;
            this.NewItemBtn.FocusedColor = System.Drawing.Color.Empty;
            this.NewItemBtn.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewItemBtn.ForeColor = System.Drawing.Color.White;
            this.NewItemBtn.Image = null;
            this.NewItemBtn.ImageSize = new System.Drawing.Size(20, 20);
            this.NewItemBtn.Location = new System.Drawing.Point(705, 426);
            this.NewItemBtn.Name = "NewItemBtn";
            this.NewItemBtn.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(178)))), ((int)(((byte)(84)))));
            this.NewItemBtn.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(178)))), ((int)(((byte)(84)))));
            this.NewItemBtn.OnHoverForeColor = System.Drawing.Color.White;
            this.NewItemBtn.OnHoverImage = null;
            this.NewItemBtn.OnPressedColor = System.Drawing.Color.White;
            this.NewItemBtn.Radius = 5;
            this.NewItemBtn.Size = new System.Drawing.Size(147, 35);
            this.NewItemBtn.TabIndex = 32;
            this.NewItemBtn.Text = "New Item";
            this.NewItemBtn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NewItemBtn.TextRenderingHint = Guna.UI.WinForms.DrawingTextRenderingHint.AntiAlias;
            this.NewItemBtn.Click += new System.EventHandler(this.NewItemBtn_Click);
            // 
            // refreshBtn
            // 
            this.refreshBtn.BackColor = System.Drawing.Color.White;
            this.refreshBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(178)))), ((int)(((byte)(84)))));
            this.refreshBtn.FlatAppearance.BorderSize = 2;
            this.refreshBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.refreshBtn.IconChar = FontAwesome.Sharp.IconChar.Redo;
            this.refreshBtn.IconColor = System.Drawing.Color.Black;
            this.refreshBtn.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.refreshBtn.IconSize = 20;
            this.refreshBtn.Location = new System.Drawing.Point(279, 24);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(28, 26);
            this.refreshBtn.TabIndex = 74;
            this.refreshBtn.UseVisualStyleBackColor = false;
            this.refreshBtn.Click += new System.EventHandler(this.refreshBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(371, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 28);
            this.label1.TabIndex = 73;
            this.label1.Text = "Search by Item Name";
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Location = new System.Drawing.Point(10, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(786, 118);
            this.panel4.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.refreshBtn);
            this.panel6.Controls.Add(this.label1);
            this.panel6.Controls.Add(this.searchItemTxt);
            this.panel6.Controls.Add(this.label3);
            this.panel6.Controls.Add(this.searchCategoryCmb);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(786, 118);
            this.panel6.TabIndex = 1;
            // 
            // searchItemTxt
            // 
            this.searchItemTxt.AcceptsReturn = false;
            this.searchItemTxt.AcceptsTab = false;
            this.searchItemTxt.AnimationSpeed = 200;
            this.searchItemTxt.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.searchItemTxt.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.searchItemTxt.BackColor = System.Drawing.Color.Transparent;
            this.searchItemTxt.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("searchItemTxt.BackgroundImage")));
            this.searchItemTxt.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(178)))), ((int)(((byte)(84)))));
            this.searchItemTxt.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.searchItemTxt.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(178)))), ((int)(((byte)(84)))));
            this.searchItemTxt.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(178)))), ((int)(((byte)(84)))));
            this.searchItemTxt.BorderRadius = 10;
            this.searchItemTxt.BorderThickness = 2;
            this.searchItemTxt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.searchItemTxt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.searchItemTxt.DefaultFont = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchItemTxt.DefaultText = "";
            this.searchItemTxt.FillColor = System.Drawing.Color.White;
            this.searchItemTxt.HideSelection = true;
            this.searchItemTxt.IconLeft = null;
            this.searchItemTxt.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.searchItemTxt.IconPadding = 10;
            this.searchItemTxt.IconRight = null;
            this.searchItemTxt.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.searchItemTxt.Lines = new string[0];
            this.searchItemTxt.Location = new System.Drawing.Point(376, 53);
            this.searchItemTxt.MaximumSize = new System.Drawing.Size(233, 40);
            this.searchItemTxt.MaxLength = 32767;
            this.searchItemTxt.MinimumSize = new System.Drawing.Size(233, 40);
            this.searchItemTxt.Modified = false;
            this.searchItemTxt.Multiline = false;
            this.searchItemTxt.Name = "searchItemTxt";
            stateProperties5.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(178)))), ((int)(((byte)(84)))));
            stateProperties5.FillColor = System.Drawing.Color.Empty;
            stateProperties5.ForeColor = System.Drawing.Color.Empty;
            stateProperties5.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.searchItemTxt.OnActiveState = stateProperties5;
            stateProperties6.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            stateProperties6.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            stateProperties6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            stateProperties6.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.searchItemTxt.OnDisabledState = stateProperties6;
            stateProperties7.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(178)))), ((int)(((byte)(84)))));
            stateProperties7.FillColor = System.Drawing.Color.Empty;
            stateProperties7.ForeColor = System.Drawing.Color.Empty;
            stateProperties7.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.searchItemTxt.OnHoverState = stateProperties7;
            stateProperties8.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(178)))), ((int)(((byte)(84)))));
            stateProperties8.FillColor = System.Drawing.Color.White;
            stateProperties8.ForeColor = System.Drawing.Color.Empty;
            stateProperties8.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.searchItemTxt.OnIdleState = stateProperties8;
            this.searchItemTxt.Padding = new System.Windows.Forms.Padding(3);
            this.searchItemTxt.PasswordChar = '\0';
            this.searchItemTxt.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.searchItemTxt.PlaceholderText = "Search by Item Name";
            this.searchItemTxt.ReadOnly = false;
            this.searchItemTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.searchItemTxt.SelectedText = "";
            this.searchItemTxt.SelectionLength = 0;
            this.searchItemTxt.SelectionStart = 0;
            this.searchItemTxt.ShortcutsEnabled = true;
            this.searchItemTxt.Size = new System.Drawing.Size(233, 40);
            this.searchItemTxt.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
            this.searchItemTxt.TabIndex = 71;
            this.searchItemTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.searchItemTxt.TextMarginBottom = 0;
            this.searchItemTxt.TextMarginLeft = 3;
            this.searchItemTxt.TextMarginTop = 0;
            this.searchItemTxt.TextPlaceholder = "Search by Item Name";
            this.searchItemTxt.UseSystemPasswordChar = false;
            this.searchItemTxt.WordWrap = true;
            this.searchItemTxt.TextChanged += new System.EventHandler(this.searchItemTxt_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(106, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(171, 28);
            this.label3.TabIndex = 73;
            this.label3.Text = "Search by Category";
            // 
            // searchCategoryCmb
            // 
            this.searchCategoryCmb.BackColor = System.Drawing.Color.Transparent;
            this.searchCategoryCmb.BaseColor = System.Drawing.Color.White;
            this.searchCategoryCmb.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(178)))), ((int)(((byte)(84)))));
            this.searchCategoryCmb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.searchCategoryCmb.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.searchCategoryCmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.searchCategoryCmb.FocusedColor = System.Drawing.Color.Empty;
            this.searchCategoryCmb.Font = new System.Drawing.Font("Poppins", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchCategoryCmb.ForeColor = System.Drawing.Color.Black;
            this.searchCategoryCmb.FormattingEnabled = true;
            this.searchCategoryCmb.Location = new System.Drawing.Point(111, 55);
            this.searchCategoryCmb.MaximumSize = new System.Drawing.Size(233, 0);
            this.searchCategoryCmb.MinimumSize = new System.Drawing.Size(233, 0);
            this.searchCategoryCmb.Name = "searchCategoryCmb";
            this.searchCategoryCmb.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(196)))), ((int)(((byte)(125)))));
            this.searchCategoryCmb.OnHoverItemForeColor = System.Drawing.Color.White;
            this.searchCategoryCmb.Radius = 4;
            this.searchCategoryCmb.Size = new System.Drawing.Size(233, 37);
            this.searchCategoryCmb.TabIndex = 72;
            this.searchCategoryCmb.TextRenderingHint = Guna.UI.WinForms.DrawingTextRenderingHint.AntiAlias;
            this.searchCategoryCmb.SelectedIndexChanged += new System.EventHandler(this.searchCategoryCmb_SelectedIndexChanged);
            // 
            // gunaGroupBox3
            // 
            this.gunaGroupBox3.BackColor = System.Drawing.Color.Transparent;
            this.gunaGroupBox3.BaseColor = System.Drawing.Color.White;
            this.gunaGroupBox3.BorderColor = System.Drawing.Color.Gainsboro;
            this.gunaGroupBox3.Controls.Add(this.panel4);
            this.gunaGroupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gunaGroupBox3.Font = new System.Drawing.Font("Poppins", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaGroupBox3.LineColor = System.Drawing.Color.White;
            this.gunaGroupBox3.LineTop = 0;
            this.gunaGroupBox3.Location = new System.Drawing.Point(0, 0);
            this.gunaGroupBox3.Name = "gunaGroupBox3";
            this.gunaGroupBox3.Radius = 10;
            this.gunaGroupBox3.Size = new System.Drawing.Size(819, 118);
            this.gunaGroupBox3.TabIndex = 50;
            this.gunaGroupBox3.TextLocation = new System.Drawing.Point(10, 13);
            this.gunaGroupBox3.TextRenderingHint = Guna.UI.WinForms.DrawingTextRenderingHint.AntiAlias;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.gunaGroupBox3);
            this.panel2.Location = new System.Drawing.Point(362, 77);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(819, 118);
            this.panel2.TabIndex = 52;
            // 
            // GunaPictureBox3
            // 
            this.GunaPictureBox3.BaseColor = System.Drawing.Color.White;
            this.GunaPictureBox3.Image = global::sims.Properties.Resources.grocery_bag;
            this.GunaPictureBox3.Location = new System.Drawing.Point(31, 15);
            this.GunaPictureBox3.Name = "GunaPictureBox3";
            this.GunaPictureBox3.Size = new System.Drawing.Size(50, 50);
            this.GunaPictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.GunaPictureBox3.TabIndex = 4;
            this.GunaPictureBox3.TabStop = false;
            // 
            // itemCountTxt
            // 
            this.itemCountTxt.AutoSize = true;
            this.itemCountTxt.Font = new System.Drawing.Font("Poppins", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemCountTxt.Location = new System.Drawing.Point(181, 55);
            this.itemCountTxt.Name = "itemCountTxt";
            this.itemCountTxt.Size = new System.Drawing.Size(52, 51);
            this.itemCountTxt.TabIndex = 3;
            this.itemCountTxt.Text = "10";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Poppins", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(97, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(215, 34);
            this.label5.TabIndex = 3;
            this.label5.Text = "Soothing Café Items";
            // 
            // GunaGroupBox1
            // 
            this.GunaGroupBox1.BackColor = System.Drawing.Color.Transparent;
            this.GunaGroupBox1.BaseColor = System.Drawing.Color.White;
            this.GunaGroupBox1.BorderColor = System.Drawing.Color.Gainsboro;
            this.GunaGroupBox1.Controls.Add(this.GunaPictureBox3);
            this.GunaGroupBox1.Controls.Add(this.itemCountTxt);
            this.GunaGroupBox1.Controls.Add(this.label5);
            this.GunaGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GunaGroupBox1.Font = new System.Drawing.Font("Poppins", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GunaGroupBox1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(93)))), ((int)(((byte)(212)))));
            this.GunaGroupBox1.LineTop = 0;
            this.GunaGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.GunaGroupBox1.Name = "GunaGroupBox1";
            this.GunaGroupBox1.Radius = 10;
            this.GunaGroupBox1.Size = new System.Drawing.Size(340, 118);
            this.GunaGroupBox1.TabIndex = 48;
            this.GunaGroupBox1.TextLocation = new System.Drawing.Point(10, 8);
            this.GunaGroupBox1.TextRenderingHint = Guna.UI.WinForms.DrawingTextRenderingHint.AntiAliasGridFit;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.GunaGroupBox1);
            this.panel3.Location = new System.Drawing.Point(11, 77);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(340, 118);
            this.panel3.TabIndex = 50;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Poppins", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(10, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(278, 34);
            this.label4.TabIndex = 21;
            this.label4.Text = "Dashboard / Manage Items\r\n";
            // 
            // gunaElipsePanel2
            // 
            this.gunaElipsePanel2.BackColor = System.Drawing.Color.Transparent;
            this.gunaElipsePanel2.BaseColor = System.Drawing.Color.White;
            this.gunaElipsePanel2.Controls.Add(this.label4);
            this.gunaElipsePanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gunaElipsePanel2.Location = new System.Drawing.Point(0, 0);
            this.gunaElipsePanel2.Margin = new System.Windows.Forms.Padding(0);
            this.gunaElipsePanel2.Name = "gunaElipsePanel2";
            this.gunaElipsePanel2.Radius = 7;
            this.gunaElipsePanel2.Size = new System.Drawing.Size(1170, 53);
            this.gunaElipsePanel2.TabIndex = 46;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.gunaElipsePanel2);
            this.panel1.Location = new System.Drawing.Point(11, 10);
            this.panel1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1170, 53);
            this.panel1.TabIndex = 49;
            // 
            // Manage_Items_Staff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(196)))), ((int)(((byte)(125)))));
            this.ClientSize = new System.Drawing.Size(1194, 700);
            this.Controls.Add(this.gunaGroupBox2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Manage_Items_Staff";
            this.Text = "Manage_Items_Staff";
            this.Load += new System.EventHandler(this.Manage_Items_Staff_Load);
            ((System.ComponentModel.ISupportInitialize)(this.itemsDgv)).EndInit();
            this.panel5.ResumeLayout(false);
            this.gunaGroupBox2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.gunaGroupBox3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GunaPictureBox3)).EndInit();
            this.GunaGroupBox1.ResumeLayout(false);
            this.GunaGroupBox1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.gunaElipsePanel2.ResumeLayout(false);
            this.gunaElipsePanel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridViewImageColumn Item_Image;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item_ID;
        private Guna.UI.WinForms.GunaDataGridView itemsDgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private Guna.UI.WinForms.GunaButton DeleteItemBtn;
        private Guna.UI.WinForms.GunaButton UpdateItemBtn;
        private System.Windows.Forms.Panel panel5;
        private Guna.UI.WinForms.GunaGroupBox gunaGroupBox2;
        private Guna.UI.WinForms.GunaButton NewItemBtn;
        private FontAwesome.Sharp.IconButton refreshBtn;
        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel6;
        private Bunifu.UI.WinForms.BunifuTextBox searchItemTxt;
        internal System.Windows.Forms.Label label3;
        private Guna.UI.WinForms.GunaComboBox searchCategoryCmb;
        private Guna.UI.WinForms.GunaGroupBox gunaGroupBox3;
        private System.Windows.Forms.Panel panel2;
        internal Guna.UI.WinForms.GunaPictureBox GunaPictureBox3;
        internal System.Windows.Forms.Label itemCountTxt;
        internal System.Windows.Forms.Label label5;
        internal Guna.UI.WinForms.GunaGroupBox GunaGroupBox1;
        private System.Windows.Forms.Panel panel3;
        internal System.Windows.Forms.Label label4;
        private Guna.UI.WinForms.GunaElipsePanel gunaElipsePanel2;
        private System.Windows.Forms.Panel panel1;
    }
}