﻿namespace RecipeWinForms
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblCaptionRecipeName = new System.Windows.Forms.Label();
            this.lblCaptionUserName = new System.Windows.Forms.Label();
            this.lblCaptionCalories = new System.Windows.Forms.Label();
            this.lblCaptionDateDraft = new System.Windows.Forms.Label();
            this.lblCaptionDatePublished = new System.Windows.Forms.Label();
            this.lblCaptionDateArchived = new System.Windows.Forms.Label();
            this.txtRecipeName = new System.Windows.Forms.TextBox();
            this.txtCalories = new System.Windows.Forms.TextBox();
            this.txtDatePublished = new System.Windows.Forms.TextBox();
            this.txtDateArchived = new System.Windows.Forms.TextBox();
            this.lblCaptionCuisine = new System.Windows.Forms.Label();
            this.lblCaptionCurrentStatus = new System.Windows.Forms.Label();
            this.txtCurrentStatus = new System.Windows.Forms.TextBox();
            this.lstCuisineType = new System.Windows.Forms.ComboBox();
            this.lstUserName = new System.Windows.Forms.ComboBox();
            this.dtpDateDraft = new System.Windows.Forms.DateTimePicker();
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tableLayoutPanel1.SuspendLayout();
            this.tsMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.50193F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 69.49807F));
            this.tableLayoutPanel1.Controls.Add(this.lblCaptionRecipeName, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblCaptionUserName, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblCaptionCalories, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblCaptionDateDraft, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblCaptionDatePublished, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.lblCaptionDateArchived, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.txtRecipeName, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtCalories, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtDatePublished, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.txtDateArchived, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.lblCaptionCuisine, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblCaptionCurrentStatus, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.txtCurrentStatus, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.lstCuisineType, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lstUserName, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.dtpDateDraft, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.tsMain, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(518, 359);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblCaptionRecipeName
            // 
            this.lblCaptionRecipeName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCaptionRecipeName.AutoSize = true;
            this.lblCaptionRecipeName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCaptionRecipeName.Location = new System.Drawing.Point(3, 83);
            this.lblCaptionRecipeName.Name = "lblCaptionRecipeName";
            this.lblCaptionRecipeName.Size = new System.Drawing.Size(126, 28);
            this.lblCaptionRecipeName.TabIndex = 1;
            this.lblCaptionRecipeName.Text = "Recipe Name";
            // 
            // lblCaptionUserName
            // 
            this.lblCaptionUserName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCaptionUserName.AutoSize = true;
            this.lblCaptionUserName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCaptionUserName.Location = new System.Drawing.Point(3, 122);
            this.lblCaptionUserName.Name = "lblCaptionUserName";
            this.lblCaptionUserName.Size = new System.Drawing.Size(108, 28);
            this.lblCaptionUserName.TabIndex = 2;
            this.lblCaptionUserName.Text = "User Name";
            // 
            // lblCaptionCalories
            // 
            this.lblCaptionCalories.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCaptionCalories.AutoSize = true;
            this.lblCaptionCalories.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCaptionCalories.Location = new System.Drawing.Point(3, 161);
            this.lblCaptionCalories.Name = "lblCaptionCalories";
            this.lblCaptionCalories.Size = new System.Drawing.Size(81, 28);
            this.lblCaptionCalories.TabIndex = 4;
            this.lblCaptionCalories.Text = "Calories";
            // 
            // lblCaptionDateDraft
            // 
            this.lblCaptionDateDraft.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCaptionDateDraft.AutoSize = true;
            this.lblCaptionDateDraft.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCaptionDateDraft.Location = new System.Drawing.Point(3, 200);
            this.lblCaptionDateDraft.Name = "lblCaptionDateDraft";
            this.lblCaptionDateDraft.Size = new System.Drawing.Size(102, 28);
            this.lblCaptionDateDraft.TabIndex = 5;
            this.lblCaptionDateDraft.Text = "Date Draft";
            // 
            // lblCaptionDatePublished
            // 
            this.lblCaptionDatePublished.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCaptionDatePublished.AutoSize = true;
            this.lblCaptionDatePublished.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCaptionDatePublished.Location = new System.Drawing.Point(3, 239);
            this.lblCaptionDatePublished.Name = "lblCaptionDatePublished";
            this.lblCaptionDatePublished.Size = new System.Drawing.Size(143, 28);
            this.lblCaptionDatePublished.TabIndex = 6;
            this.lblCaptionDatePublished.Text = "Date Published";
            // 
            // lblCaptionDateArchived
            // 
            this.lblCaptionDateArchived.AutoSize = true;
            this.lblCaptionDateArchived.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCaptionDateArchived.Location = new System.Drawing.Point(3, 280);
            this.lblCaptionDateArchived.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.lblCaptionDateArchived.Name = "lblCaptionDateArchived";
            this.lblCaptionDateArchived.Size = new System.Drawing.Size(135, 28);
            this.lblCaptionDateArchived.TabIndex = 7;
            this.lblCaptionDateArchived.Text = "Date Archived";
            // 
            // txtRecipeName
            // 
            this.txtRecipeName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRecipeName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtRecipeName.Location = new System.Drawing.Point(161, 81);
            this.txtRecipeName.Name = "txtRecipeName";
            this.txtRecipeName.Size = new System.Drawing.Size(354, 34);
            this.txtRecipeName.TabIndex = 9;
            // 
            // txtCalories
            // 
            this.txtCalories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCalories.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtCalories.Location = new System.Drawing.Point(161, 159);
            this.txtCalories.Name = "txtCalories";
            this.txtCalories.Size = new System.Drawing.Size(354, 34);
            this.txtCalories.TabIndex = 12;
            // 
            // txtDatePublished
            // 
            this.txtDatePublished.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDatePublished.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtDatePublished.Location = new System.Drawing.Point(161, 237);
            this.txtDatePublished.Name = "txtDatePublished";
            this.txtDatePublished.Size = new System.Drawing.Size(354, 34);
            this.txtDatePublished.TabIndex = 14;
            // 
            // txtDateArchived
            // 
            this.txtDateArchived.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDateArchived.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtDateArchived.Location = new System.Drawing.Point(161, 276);
            this.txtDateArchived.Name = "txtDateArchived";
            this.txtDateArchived.Size = new System.Drawing.Size(354, 34);
            this.txtDateArchived.TabIndex = 15;
            // 
            // lblCaptionCuisine
            // 
            this.lblCaptionCuisine.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCaptionCuisine.AutoSize = true;
            this.lblCaptionCuisine.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCaptionCuisine.Location = new System.Drawing.Point(3, 48);
            this.lblCaptionCuisine.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.lblCaptionCuisine.Name = "lblCaptionCuisine";
            this.lblCaptionCuisine.Size = new System.Drawing.Size(74, 28);
            this.lblCaptionCuisine.TabIndex = 0;
            this.lblCaptionCuisine.Text = "Cuisine";
            // 
            // lblCaptionCurrentStatus
            // 
            this.lblCaptionCurrentStatus.AutoSize = true;
            this.lblCaptionCurrentStatus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCaptionCurrentStatus.Location = new System.Drawing.Point(3, 319);
            this.lblCaptionCurrentStatus.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.lblCaptionCurrentStatus.Name = "lblCaptionCurrentStatus";
            this.lblCaptionCurrentStatus.Size = new System.Drawing.Size(135, 28);
            this.lblCaptionCurrentStatus.TabIndex = 8;
            this.lblCaptionCurrentStatus.Text = "Current Status";
            // 
            // txtCurrentStatus
            // 
            this.txtCurrentStatus.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtCurrentStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCurrentStatus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtCurrentStatus.Location = new System.Drawing.Point(161, 315);
            this.txtCurrentStatus.Name = "txtCurrentStatus";
            this.txtCurrentStatus.ReadOnly = true;
            this.txtCurrentStatus.Size = new System.Drawing.Size(354, 34);
            this.txtCurrentStatus.TabIndex = 16;
            // 
            // lstCuisineType
            // 
            this.lstCuisineType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lstCuisineType.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lstCuisineType.FormattingEnabled = true;
            this.lstCuisineType.Location = new System.Drawing.Point(161, 42);
            this.lstCuisineType.Name = "lstCuisineType";
            this.lstCuisineType.Size = new System.Drawing.Size(182, 33);
            this.lstCuisineType.TabIndex = 17;
            // 
            // lstUserName
            // 
            this.lstUserName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lstUserName.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lstUserName.FormattingEnabled = true;
            this.lstUserName.Location = new System.Drawing.Point(161, 120);
            this.lstUserName.Name = "lstUserName";
            this.lstUserName.Size = new System.Drawing.Size(182, 33);
            this.lstUserName.TabIndex = 18;
            // 
            // dtpDateDraft
            // 
            this.dtpDateDraft.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpDateDraft.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtpDateDraft.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateDraft.Location = new System.Drawing.Point(161, 199);
            this.dtpDateDraft.Name = "dtpDateDraft";
            this.dtpDateDraft.Size = new System.Drawing.Size(182, 31);
            this.dtpDateDraft.TabIndex = 19;
            // 
            // tsMain
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.tsMain, 2);
            this.tsMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tsMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSave,
            this.toolStripSeparator1,
            this.btnDelete,
            this.toolStripSeparator2});
            this.tsMain.Location = new System.Drawing.Point(0, 0);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(518, 39);
            this.tsMain.TabIndex = 1;
            this.tsMain.Text = "toolStrip1";
            // 
            // btnSave
            // 
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(57, 36);
            this.btnSave.Text = "Save";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // btnDelete
            // 
            this.btnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(72, 36);
            this.btnDelete.Text = "Delete";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // frmRecipe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 359);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmRecipe";
            this.Text = "frmRecipe";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
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