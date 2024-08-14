namespace RecipeWinForms
{
    partial class frmRecipe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRecipe));
            tblMain = new TableLayoutPanel();
            lblCaptionRecipeName = new Label();
            lblCaptionUserName = new Label();
            lblCaptionCalories = new Label();
            lblCaptionDateDraft = new Label();
            lblCaptionDatePublished = new Label();
            lblCaptionDateArchived = new Label();
            txtRecipeName = new TextBox();
            txtCalories = new TextBox();
            txtDatePublished = new TextBox();
            txtDateArchived = new TextBox();
            lblCaptionCuisine = new Label();
            lblCaptionCurrentStatus = new Label();
            txtCurrentStatus = new TextBox();
            lstCuisineType = new ComboBox();
            lstUserName = new ComboBox();
            dtpDateDraft = new DateTimePicker();
            tsMain = new ToolStrip();
            btnSave = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            btnDelete = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            tblMain.SuspendLayout();
            tsMain.SuspendLayout();
            SuspendLayout();
            // 
            // tblMain
            // 
            tblMain.ColumnCount = 2;
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 32.10332F));
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 67.89668F));
            tblMain.Controls.Add(lblCaptionRecipeName, 0, 2);
            tblMain.Controls.Add(lblCaptionUserName, 0, 3);
            tblMain.Controls.Add(lblCaptionCalories, 0, 4);
            tblMain.Controls.Add(lblCaptionDateDraft, 0, 5);
            tblMain.Controls.Add(lblCaptionDatePublished, 0, 6);
            tblMain.Controls.Add(lblCaptionDateArchived, 0, 7);
            tblMain.Controls.Add(txtRecipeName, 1, 2);
            tblMain.Controls.Add(txtCalories, 1, 4);
            tblMain.Controls.Add(txtDatePublished, 1, 6);
            tblMain.Controls.Add(txtDateArchived, 1, 7);
            tblMain.Controls.Add(lblCaptionCuisine, 0, 1);
            tblMain.Controls.Add(lblCaptionCurrentStatus, 0, 8);
            tblMain.Controls.Add(txtCurrentStatus, 1, 8);
            tblMain.Controls.Add(lstCuisineType, 1, 1);
            tblMain.Controls.Add(lstUserName, 1, 3);
            tblMain.Controls.Add(dtpDateDraft, 1, 5);
            tblMain.Controls.Add(tsMain, 0, 0);
            tblMain.Dock = DockStyle.Fill;
            tblMain.Location = new Point(0, 0);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 9;
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.Size = new Size(518, 359);
            tblMain.TabIndex = 0;
            // 
            // lblCaptionRecipeName
            // 
            lblCaptionRecipeName.Anchor = AnchorStyles.Left;
            lblCaptionRecipeName.AutoSize = true;
            lblCaptionRecipeName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblCaptionRecipeName.Location = new Point(3, 80);
            lblCaptionRecipeName.Name = "lblCaptionRecipeName";
            lblCaptionRecipeName.Size = new Size(126, 28);
            lblCaptionRecipeName.TabIndex = 1;
            lblCaptionRecipeName.Text = "Recipe Name";
            // 
            // lblCaptionUserName
            // 
            lblCaptionUserName.Anchor = AnchorStyles.Left;
            lblCaptionUserName.AutoSize = true;
            lblCaptionUserName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblCaptionUserName.Location = new Point(3, 119);
            lblCaptionUserName.Name = "lblCaptionUserName";
            lblCaptionUserName.Size = new Size(108, 28);
            lblCaptionUserName.TabIndex = 2;
            lblCaptionUserName.Text = "User Name";
            // 
            // lblCaptionCalories
            // 
            lblCaptionCalories.Anchor = AnchorStyles.Left;
            lblCaptionCalories.AutoSize = true;
            lblCaptionCalories.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblCaptionCalories.Location = new Point(3, 159);
            lblCaptionCalories.Name = "lblCaptionCalories";
            lblCaptionCalories.Size = new Size(81, 28);
            lblCaptionCalories.TabIndex = 4;
            lblCaptionCalories.Text = "Calories";
            // 
            // lblCaptionDateDraft
            // 
            lblCaptionDateDraft.Anchor = AnchorStyles.Left;
            lblCaptionDateDraft.AutoSize = true;
            lblCaptionDateDraft.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblCaptionDateDraft.Location = new Point(3, 197);
            lblCaptionDateDraft.Name = "lblCaptionDateDraft";
            lblCaptionDateDraft.Size = new Size(102, 28);
            lblCaptionDateDraft.TabIndex = 5;
            lblCaptionDateDraft.Text = "Date Draft";
            // 
            // lblCaptionDatePublished
            // 
            lblCaptionDatePublished.Anchor = AnchorStyles.Left;
            lblCaptionDatePublished.AutoSize = true;
            lblCaptionDatePublished.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblCaptionDatePublished.Location = new Point(3, 236);
            lblCaptionDatePublished.Name = "lblCaptionDatePublished";
            lblCaptionDatePublished.Size = new Size(143, 28);
            lblCaptionDatePublished.TabIndex = 6;
            lblCaptionDatePublished.Text = "Date Published";
            // 
            // lblCaptionDateArchived
            // 
            lblCaptionDateArchived.AutoSize = true;
            lblCaptionDateArchived.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblCaptionDateArchived.Location = new Point(3, 277);
            lblCaptionDateArchived.Margin = new Padding(3, 7, 3, 0);
            lblCaptionDateArchived.Name = "lblCaptionDateArchived";
            lblCaptionDateArchived.Size = new Size(135, 28);
            lblCaptionDateArchived.TabIndex = 7;
            lblCaptionDateArchived.Text = "Date Archived";
            // 
            // txtRecipeName
            // 
            txtRecipeName.Dock = DockStyle.Fill;
            txtRecipeName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtRecipeName.Location = new Point(169, 77);
            txtRecipeName.Name = "txtRecipeName";
            txtRecipeName.Size = new Size(346, 34);
            txtRecipeName.TabIndex = 9;
            // 
            // txtCalories
            // 
            txtCalories.Dock = DockStyle.Fill;
            txtCalories.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtCalories.Location = new Point(169, 156);
            txtCalories.Name = "txtCalories";
            txtCalories.Size = new Size(346, 34);
            txtCalories.TabIndex = 12;
            // 
            // txtDatePublished
            // 
            txtDatePublished.BackColor = SystemColors.ButtonHighlight;
            txtDatePublished.Dock = DockStyle.Fill;
            txtDatePublished.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtDatePublished.Location = new Point(169, 233);
            txtDatePublished.Name = "txtDatePublished";
            txtDatePublished.ReadOnly = true;
            txtDatePublished.Size = new Size(346, 34);
            txtDatePublished.TabIndex = 14;
            // 
            // txtDateArchived
            // 
            txtDateArchived.BackColor = SystemColors.ButtonHighlight;
            txtDateArchived.Dock = DockStyle.Fill;
            txtDateArchived.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtDateArchived.Location = new Point(169, 273);
            txtDateArchived.Name = "txtDateArchived";
            txtDateArchived.ReadOnly = true;
            txtDateArchived.Size = new Size(346, 34);
            txtDateArchived.TabIndex = 15;
            // 
            // lblCaptionCuisine
            // 
            lblCaptionCuisine.Anchor = AnchorStyles.Left;
            lblCaptionCuisine.AutoSize = true;
            lblCaptionCuisine.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblCaptionCuisine.Location = new Point(3, 44);
            lblCaptionCuisine.Margin = new Padding(3, 7, 3, 0);
            lblCaptionCuisine.Name = "lblCaptionCuisine";
            lblCaptionCuisine.Size = new Size(74, 28);
            lblCaptionCuisine.TabIndex = 0;
            lblCaptionCuisine.Text = "Cuisine";
            // 
            // lblCaptionCurrentStatus
            // 
            lblCaptionCurrentStatus.AutoSize = true;
            lblCaptionCurrentStatus.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblCaptionCurrentStatus.Location = new Point(3, 317);
            lblCaptionCurrentStatus.Margin = new Padding(3, 7, 3, 0);
            lblCaptionCurrentStatus.Name = "lblCaptionCurrentStatus";
            lblCaptionCurrentStatus.Size = new Size(135, 28);
            lblCaptionCurrentStatus.TabIndex = 8;
            lblCaptionCurrentStatus.Text = "Current Status";
            // 
            // txtCurrentStatus
            // 
            txtCurrentStatus.BackColor = SystemColors.ButtonHighlight;
            txtCurrentStatus.Dock = DockStyle.Fill;
            txtCurrentStatus.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtCurrentStatus.Location = new Point(169, 313);
            txtCurrentStatus.Name = "txtCurrentStatus";
            txtCurrentStatus.ReadOnly = true;
            txtCurrentStatus.Size = new Size(346, 34);
            txtCurrentStatus.TabIndex = 16;
            // 
            // lstCuisineType
            // 
            lstCuisineType.Anchor = AnchorStyles.Left;
            lstCuisineType.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            lstCuisineType.FormattingEnabled = true;
            lstCuisineType.Location = new Point(169, 38);
            lstCuisineType.Name = "lstCuisineType";
            lstCuisineType.Size = new Size(182, 33);
            lstCuisineType.TabIndex = 17;
            // 
            // lstUserName
            // 
            lstUserName.Anchor = AnchorStyles.Left;
            lstUserName.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            lstUserName.FormattingEnabled = true;
            lstUserName.Location = new Point(169, 117);
            lstUserName.Name = "lstUserName";
            lstUserName.Size = new Size(182, 33);
            lstUserName.TabIndex = 18;
            // 
            // dtpDateDraft
            // 
            dtpDateDraft.Anchor = AnchorStyles.Left;
            dtpDateDraft.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            dtpDateDraft.Format = DateTimePickerFormat.Short;
            dtpDateDraft.Location = new Point(169, 196);
            dtpDateDraft.Name = "dtpDateDraft";
            dtpDateDraft.Size = new Size(182, 31);
            dtpDateDraft.TabIndex = 19;
            // 
            // tsMain
            // 
            tblMain.SetColumnSpan(tsMain, 2);
            tsMain.Dock = DockStyle.Fill;
            tsMain.ImageScalingSize = new Size(20, 20);
            tsMain.Items.AddRange(new ToolStripItem[] { btnSave, toolStripSeparator1, btnDelete, toolStripSeparator2 });
            tsMain.Location = new Point(0, 0);
            tsMain.Name = "tsMain";
            tsMain.Size = new Size(518, 35);
            tsMain.TabIndex = 20;
            tsMain.Text = "toolStrip1";
            // 
            // btnSave
            // 
            btnSave.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnSave.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnSave.Image = (Image)resources.GetObject("btnSave.Image");
            btnSave.ImageTransparentColor = Color.Magenta;
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(57, 32);
            btnSave.Text = "Save";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 35);
            // 
            // btnDelete
            // 
            btnDelete.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnDelete.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnDelete.Image = (Image)resources.GetObject("btnDelete.Image");
            btnDelete.ImageTransparentColor = Color.Magenta;
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(72, 32);
            btnDelete.Text = "Delete";
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 35);
            // 
            // frmRecipe
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(518, 359);
            Controls.Add(tblMain);
            Name = "frmRecipe";
            Text = "frmRecipe";
            tblMain.ResumeLayout(false);
            tblMain.PerformLayout();
            tsMain.ResumeLayout(false);
            tsMain.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblMain;
        private Label lblCaptionRecipeName;
        private Label lblCaptionUserName;
        private Label lblCaptionCalories;
        private Label lblCaptionDateDraft;
        private Label lblCaptionDatePublished;
        private Label lblCaptionDateArchived;
        private TextBox txtRecipeName;
        private TextBox txtCalories;
        private TextBox txtDatePublished;
        private TextBox txtDateArchived;
        private Label lblCaptionCuisine;
        private Label lblCaptionCurrentStatus;
        private TextBox txtCurrentStatus;
        private ComboBox lstCuisineType;
        private ComboBox lstUserName;
        private DateTimePicker dtpDateDraft;
        private ToolStrip tsMain;
        private ToolStripButton btnSave;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton btnDelete;
        private ToolStripSeparator toolStripSeparator2;
    }
}