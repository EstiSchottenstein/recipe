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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblCaptionRecipeName = new System.Windows.Forms.Label();
            this.lblCaptionUserLastName = new System.Windows.Forms.Label();
            this.lblCaptionUserFirstName = new System.Windows.Forms.Label();
            this.lblCaptionCalories = new System.Windows.Forms.Label();
            this.lblCaptionDateDraft = new System.Windows.Forms.Label();
            this.lblCaptionDatePublished = new System.Windows.Forms.Label();
            this.lblCaptionDateArchived = new System.Windows.Forms.Label();
            this.txtRecipeName = new System.Windows.Forms.TextBox();
            this.txtUserLastName = new System.Windows.Forms.TextBox();
            this.txtUserFirstName = new System.Windows.Forms.TextBox();
            this.txtCalories = new System.Windows.Forms.TextBox();
            this.txtDateDraft = new System.Windows.Forms.TextBox();
            this.txtDatePublished = new System.Windows.Forms.TextBox();
            this.txtDateArchived = new System.Windows.Forms.TextBox();
            this.lblCaptionCuisine = new System.Windows.Forms.Label();
            this.lblCaptionCurrentStatus = new System.Windows.Forms.Label();
            this.txtCurrentStatus = new System.Windows.Forms.TextBox();
            this.lblCuisine = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.10332F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67.89668F));
            this.tableLayoutPanel1.Controls.Add(this.lblCaptionRecipeName, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblCaptionUserLastName, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblCaptionUserFirstName, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblCaptionCalories, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblCaptionDateDraft, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblCaptionDatePublished, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.lblCaptionDateArchived, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.txtRecipeName, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtUserLastName, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtUserFirstName, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtCalories, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtDateDraft, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtDatePublished, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.txtDateArchived, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.lblCaptionCuisine, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblCaptionCurrentStatus, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.txtCurrentStatus, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.lblCuisine, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(491, 357);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblCaptionRecipeName
            // 
            this.lblCaptionRecipeName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCaptionRecipeName.AutoSize = true;
            this.lblCaptionRecipeName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCaptionRecipeName.Location = new System.Drawing.Point(3, 41);
            this.lblCaptionRecipeName.Name = "lblCaptionRecipeName";
            this.lblCaptionRecipeName.Size = new System.Drawing.Size(126, 28);
            this.lblCaptionRecipeName.TabIndex = 1;
            this.lblCaptionRecipeName.Text = "Recipe Name";
            // 
            // lblCaptionUserLastName
            // 
            this.lblCaptionUserLastName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCaptionUserLastName.AutoSize = true;
            this.lblCaptionUserLastName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCaptionUserLastName.Location = new System.Drawing.Point(3, 81);
            this.lblCaptionUserLastName.Name = "lblCaptionUserLastName";
            this.lblCaptionUserLastName.Size = new System.Drawing.Size(147, 28);
            this.lblCaptionUserLastName.TabIndex = 2;
            this.lblCaptionUserLastName.Text = "User Last Name";
            // 
            // lblCaptionUserFirstName
            // 
            this.lblCaptionUserFirstName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCaptionUserFirstName.AutoSize = true;
            this.lblCaptionUserFirstName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCaptionUserFirstName.Location = new System.Drawing.Point(3, 121);
            this.lblCaptionUserFirstName.Name = "lblCaptionUserFirstName";
            this.lblCaptionUserFirstName.Size = new System.Drawing.Size(150, 28);
            this.lblCaptionUserFirstName.TabIndex = 3;
            this.lblCaptionUserFirstName.Text = "User First Name";
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
            this.lblCaptionDateDraft.Location = new System.Drawing.Point(3, 201);
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
            this.lblCaptionDatePublished.Location = new System.Drawing.Point(3, 241);
            this.lblCaptionDatePublished.Name = "lblCaptionDatePublished";
            this.lblCaptionDatePublished.Size = new System.Drawing.Size(143, 28);
            this.lblCaptionDatePublished.TabIndex = 6;
            this.lblCaptionDatePublished.Text = "Date Published";
            // 
            // lblCaptionDateArchived
            // 
            this.lblCaptionDateArchived.AutoSize = true;
            this.lblCaptionDateArchived.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCaptionDateArchived.Location = new System.Drawing.Point(3, 282);
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
            this.txtRecipeName.Location = new System.Drawing.Point(160, 38);
            this.txtRecipeName.Name = "txtRecipeName";
            this.txtRecipeName.Size = new System.Drawing.Size(328, 34);
            this.txtRecipeName.TabIndex = 9;
            // 
            // txtUserLastName
            // 
            this.txtUserLastName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUserLastName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtUserLastName.Location = new System.Drawing.Point(160, 78);
            this.txtUserLastName.Name = "txtUserLastName";
            this.txtUserLastName.Size = new System.Drawing.Size(328, 34);
            this.txtUserLastName.TabIndex = 10;
            // 
            // txtUserFirstName
            // 
            this.txtUserFirstName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUserFirstName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtUserFirstName.Location = new System.Drawing.Point(160, 118);
            this.txtUserFirstName.Name = "txtUserFirstName";
            this.txtUserFirstName.Size = new System.Drawing.Size(328, 34);
            this.txtUserFirstName.TabIndex = 11;
            // 
            // txtCalories
            // 
            this.txtCalories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCalories.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtCalories.Location = new System.Drawing.Point(160, 158);
            this.txtCalories.Name = "txtCalories";
            this.txtCalories.Size = new System.Drawing.Size(328, 34);
            this.txtCalories.TabIndex = 12;
            // 
            // txtDateDraft
            // 
            this.txtDateDraft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDateDraft.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtDateDraft.Location = new System.Drawing.Point(160, 198);
            this.txtDateDraft.Name = "txtDateDraft";
            this.txtDateDraft.Size = new System.Drawing.Size(328, 34);
            this.txtDateDraft.TabIndex = 13;
            // 
            // txtDatePublished
            // 
            this.txtDatePublished.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDatePublished.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtDatePublished.Location = new System.Drawing.Point(160, 238);
            this.txtDatePublished.Name = "txtDatePublished";
            this.txtDatePublished.Size = new System.Drawing.Size(328, 34);
            this.txtDatePublished.TabIndex = 14;
            // 
            // txtDateArchived
            // 
            this.txtDateArchived.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDateArchived.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtDateArchived.Location = new System.Drawing.Point(160, 278);
            this.txtDateArchived.Name = "txtDateArchived";
            this.txtDateArchived.Size = new System.Drawing.Size(328, 34);
            this.txtDateArchived.TabIndex = 15;
            // 
            // lblCaptionCuisine
            // 
            this.lblCaptionCuisine.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCaptionCuisine.AutoSize = true;
            this.lblCaptionCuisine.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCaptionCuisine.Location = new System.Drawing.Point(3, 7);
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
            this.lblCaptionCurrentStatus.Location = new System.Drawing.Point(3, 322);
            this.lblCaptionCurrentStatus.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.lblCaptionCurrentStatus.Name = "lblCaptionCurrentStatus";
            this.lblCaptionCurrentStatus.Size = new System.Drawing.Size(135, 28);
            this.lblCaptionCurrentStatus.TabIndex = 8;
            this.lblCaptionCurrentStatus.Text = "Current Status";
            // 
            // txtCurrentStatus
            // 
            this.txtCurrentStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCurrentStatus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtCurrentStatus.Location = new System.Drawing.Point(160, 318);
            this.txtCurrentStatus.Name = "txtCurrentStatus";
            this.txtCurrentStatus.Size = new System.Drawing.Size(328, 34);
            this.txtCurrentStatus.TabIndex = 16;
            // 
            // lblCuisine
            // 
            this.lblCuisine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCuisine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCuisine.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCuisine.Location = new System.Drawing.Point(160, 7);
            this.lblCuisine.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.lblCuisine.Name = "lblCuisine";
            this.lblCuisine.Size = new System.Drawing.Size(328, 28);
            this.lblCuisine.TabIndex = 17;
            // 
            // frmRecipe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 357);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmRecipe";
            this.Text = "frmRecipe";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label lblCaptionRecipeName;
        private Label lblCaptionUserLastName;
        private Label lblCaptionUserFirstName;
        private Label lblCaptionCalories;
        private Label lblCaptionDateDraft;
        private Label lblCaptionDatePublished;
        private Label lblCaptionDateArchived;
        private TextBox txtRecipeName;
        private TextBox txtUserLastName;
        private TextBox txtUserFirstName;
        private TextBox txtCalories;
        private TextBox txtDateDraft;
        private TextBox txtDatePublished;
        private TextBox txtDateArchived;
        private Label lblCaptionCuisine;
        private Label lblCaptionCurrentStatus;
        private TextBox txtCurrentStatus;
        private Label lblCuisine;
    }
}