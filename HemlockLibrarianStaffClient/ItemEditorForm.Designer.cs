namespace HemlockLibrarianStaffClient
{
    partial class ItemEditorForm
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
            this.TitleLabel = new System.Windows.Forms.Label();
            this.ItemIDLabel = new System.Windows.Forms.Label();
            this.BookIDLabel = new System.Windows.Forms.Label();
            this.BranchIDLabel = new System.Windows.Forms.Label();
            this.CheckoutStatusComboBox = new System.Windows.Forms.ComboBox();
            this.CheckoutStatusLabel = new System.Windows.Forms.Label();
            this.CurrentBranchIDLabel = new System.Windows.Forms.Label();
            this.CancelFormButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.BookIDSelector = new System.Windows.Forms.NumericUpDown();
            this.BranchIDSelector = new System.Windows.Forms.NumericUpDown();
            this.CurrentBranchIDSelector = new System.Windows.Forms.NumericUpDown();
            this.ItemIDSelector = new System.Windows.Forms.NumericUpDown();
            this.GenerateItemIDButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.BookIDSelector)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BranchIDSelector)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CurrentBranchIDSelector)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemIDSelector)).BeginInit();
            this.SuspendLayout();
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.Location = new System.Drawing.Point(9, 7);
            this.TitleLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(97, 24);
            this.TitleLabel.TabIndex = 0;
            this.TitleLabel.Text = "New Item";
            // 
            // ItemIDLabel
            // 
            this.ItemIDLabel.AutoSize = true;
            this.ItemIDLabel.Location = new System.Drawing.Point(31, 46);
            this.ItemIDLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ItemIDLabel.Name = "ItemIDLabel";
            this.ItemIDLabel.Size = new System.Drawing.Size(41, 13);
            this.ItemIDLabel.TabIndex = 1;
            this.ItemIDLabel.Text = "Item ID";
            // 
            // BookIDLabel
            // 
            this.BookIDLabel.AutoSize = true;
            this.BookIDLabel.Location = new System.Drawing.Point(26, 69);
            this.BookIDLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.BookIDLabel.Name = "BookIDLabel";
            this.BookIDLabel.Size = new System.Drawing.Size(46, 13);
            this.BookIDLabel.TabIndex = 3;
            this.BookIDLabel.Text = "Book ID";
            // 
            // BranchIDLabel
            // 
            this.BranchIDLabel.AutoSize = true;
            this.BranchIDLabel.Location = new System.Drawing.Point(17, 93);
            this.BranchIDLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.BranchIDLabel.Name = "BranchIDLabel";
            this.BranchIDLabel.Size = new System.Drawing.Size(55, 13);
            this.BranchIDLabel.TabIndex = 5;
            this.BranchIDLabel.Text = "Branch ID";
            // 
            // CheckoutStatusComboBox
            // 
            this.CheckoutStatusComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CheckoutStatusComboBox.FormattingEnabled = true;
            this.CheckoutStatusComboBox.Items.AddRange(new object[] {
            "In Library",
            "On Loan",
            "In Transit",
            "On Hold Shelf",
            "Missing"});
            this.CheckoutStatusComboBox.Location = new System.Drawing.Point(119, 117);
            this.CheckoutStatusComboBox.Name = "CheckoutStatusComboBox";
            this.CheckoutStatusComboBox.Size = new System.Drawing.Size(121, 21);
            this.CheckoutStatusComboBox.TabIndex = 8;
            // 
            // CheckoutStatusLabel
            // 
            this.CheckoutStatusLabel.AutoSize = true;
            this.CheckoutStatusLabel.Location = new System.Drawing.Point(15, 120);
            this.CheckoutStatusLabel.Name = "CheckoutStatusLabel";
            this.CheckoutStatusLabel.Size = new System.Drawing.Size(86, 13);
            this.CheckoutStatusLabel.TabIndex = 7;
            this.CheckoutStatusLabel.Text = "Checkout Status";
            // 
            // CurrentBranchIDLabel
            // 
            this.CurrentBranchIDLabel.AutoSize = true;
            this.CurrentBranchIDLabel.Location = new System.Drawing.Point(13, 147);
            this.CurrentBranchIDLabel.Name = "CurrentBranchIDLabel";
            this.CurrentBranchIDLabel.Size = new System.Drawing.Size(92, 13);
            this.CurrentBranchIDLabel.TabIndex = 9;
            this.CurrentBranchIDLabel.Text = "Current Branch ID";
            // 
            // CancelFormButton
            // 
            this.CancelFormButton.BackColor = System.Drawing.Color.Red;
            this.CancelFormButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelFormButton.Location = new System.Drawing.Point(11, 185);
            this.CancelFormButton.Margin = new System.Windows.Forms.Padding(2);
            this.CancelFormButton.Name = "CancelFormButton";
            this.CancelFormButton.Size = new System.Drawing.Size(84, 24);
            this.CancelFormButton.TabIndex = 20;
            this.CancelFormButton.Text = "Cancel [Esc]";
            this.CancelFormButton.UseVisualStyleBackColor = false;
            this.CancelFormButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.SaveButton.Location = new System.Drawing.Point(166, 185);
            this.SaveButton.Margin = new System.Windows.Forms.Padding(2);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(79, 24);
            this.SaveButton.TabIndex = 21;
            this.SaveButton.Text = "Save [Ctrl+S]";
            this.SaveButton.UseVisualStyleBackColor = false;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // BookIDSelector
            // 
            this.BookIDSelector.Location = new System.Drawing.Point(77, 67);
            this.BookIDSelector.Maximum = new decimal(new int[] {
            -1,
            2147483647,
            0,
            0});
            this.BookIDSelector.Name = "BookIDSelector";
            this.BookIDSelector.Size = new System.Drawing.Size(162, 20);
            this.BookIDSelector.TabIndex = 22;
            // 
            // BranchIDSelector
            // 
            this.BranchIDSelector.Location = new System.Drawing.Point(77, 91);
            this.BranchIDSelector.Maximum = new decimal(new int[] {
            -1,
            2147483647,
            0,
            0});
            this.BranchIDSelector.Name = "BranchIDSelector";
            this.BranchIDSelector.Size = new System.Drawing.Size(162, 20);
            this.BranchIDSelector.TabIndex = 23;
            // 
            // CurrentBranchIDSelector
            // 
            this.CurrentBranchIDSelector.Location = new System.Drawing.Point(119, 145);
            this.CurrentBranchIDSelector.Maximum = new decimal(new int[] {
            -1,
            2147483647,
            0,
            0});
            this.CurrentBranchIDSelector.Name = "CurrentBranchIDSelector";
            this.CurrentBranchIDSelector.Size = new System.Drawing.Size(120, 20);
            this.CurrentBranchIDSelector.TabIndex = 24;
            // 
            // ItemIDSelector
            // 
            this.ItemIDSelector.Location = new System.Drawing.Point(77, 44);
            this.ItemIDSelector.Maximum = new decimal(new int[] {
            -1,
            2147483647,
            0,
            0});
            this.ItemIDSelector.Name = "ItemIDSelector";
            this.ItemIDSelector.Size = new System.Drawing.Size(124, 20);
            this.ItemIDSelector.TabIndex = 25;
            // 
            // GenerateItemIDButton
            // 
            this.GenerateItemIDButton.Location = new System.Drawing.Point(201, 42);
            this.GenerateItemIDButton.Name = "GenerateItemIDButton";
            this.GenerateItemIDButton.Size = new System.Drawing.Size(38, 23);
            this.GenerateItemIDButton.TabIndex = 26;
            this.GenerateItemIDButton.Text = "Auto";
            this.GenerateItemIDButton.UseVisualStyleBackColor = true;
            this.GenerateItemIDButton.Click += new System.EventHandler(this.GenerateItemIDButton_Click);
            // 
            // ItemEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelFormButton;
            this.ClientSize = new System.Drawing.Size(255, 221);
            this.Controls.Add(this.GenerateItemIDButton);
            this.Controls.Add(this.ItemIDSelector);
            this.Controls.Add(this.CurrentBranchIDSelector);
            this.Controls.Add(this.BranchIDSelector);
            this.Controls.Add(this.BookIDSelector);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.CancelFormButton);
            this.Controls.Add(this.CurrentBranchIDLabel);
            this.Controls.Add(this.CheckoutStatusLabel);
            this.Controls.Add(this.CheckoutStatusComboBox);
            this.Controls.Add(this.BranchIDLabel);
            this.Controls.Add(this.BookIDLabel);
            this.Controls.Add(this.ItemIDLabel);
            this.Controls.Add(this.TitleLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ItemEditorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Item";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ItemEditorForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.BookIDSelector)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BranchIDSelector)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CurrentBranchIDSelector)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemIDSelector)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Label ItemIDLabel;
        private System.Windows.Forms.Label BookIDLabel;
        private System.Windows.Forms.Label BranchIDLabel;
        private System.Windows.Forms.ComboBox CheckoutStatusComboBox;
        private System.Windows.Forms.Label CheckoutStatusLabel;
        private System.Windows.Forms.Label CurrentBranchIDLabel;
        private System.Windows.Forms.Button CancelFormButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.NumericUpDown BookIDSelector;
        private System.Windows.Forms.NumericUpDown BranchIDSelector;
        private System.Windows.Forms.NumericUpDown CurrentBranchIDSelector;
        private System.Windows.Forms.NumericUpDown ItemIDSelector;
        private System.Windows.Forms.Button GenerateItemIDButton;
    }
}