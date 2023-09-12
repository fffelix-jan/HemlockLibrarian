
namespace HemlockLibrarianStaffClient
{
    partial class TransactionManagerForm
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
            this.TransactionDataGridView = new System.Windows.Forms.DataGridView();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.SearchBox = new System.Windows.Forms.TextBox();
            this.SearchButton = new System.Windows.Forms.Button();
            this.ClearSearchButton = new System.Windows.Forms.Button();
            this.SearchActiveLabel = new System.Windows.Forms.Label();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.UpsellLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.TransactionDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // TransactionDataGridView
            // 
            this.TransactionDataGridView.AllowUserToAddRows = false;
            this.TransactionDataGridView.AllowUserToDeleteRows = false;
            this.TransactionDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TransactionDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.TransactionDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TransactionDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.TransactionDataGridView.Location = new System.Drawing.Point(9, 104);
            this.TransactionDataGridView.Margin = new System.Windows.Forms.Padding(2);
            this.TransactionDataGridView.Name = "TransactionDataGridView";
            this.TransactionDataGridView.RowHeadersWidth = 51;
            this.TransactionDataGridView.RowTemplate.Height = 24;
            this.TransactionDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.TransactionDataGridView.Size = new System.Drawing.Size(734, 472);
            this.TransactionDataGridView.TabIndex = 7;
            this.TransactionDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TransactionDataGridView_CellDoubleClick);
            this.TransactionDataGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TransactionDataGridView_KeyDown);
            // 
            // RefreshButton
            // 
            this.RefreshButton.Location = new System.Drawing.Point(11, 70);
            this.RefreshButton.Margin = new System.Windows.Forms.Padding(2);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(81, 24);
            this.RefreshButton.TabIndex = 3;
            this.RefreshButton.Text = "Refresh [F5]";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // SearchBox
            // 
            this.SearchBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchBox.Location = new System.Drawing.Point(11, 42);
            this.SearchBox.Margin = new System.Windows.Forms.Padding(2);
            this.SearchBox.Name = "SearchBox";
            this.SearchBox.Size = new System.Drawing.Size(140, 23);
            this.SearchBox.TabIndex = 0;
            this.SearchBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SearchBox_KeyDown);
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(155, 42);
            this.SearchButton.Margin = new System.Windows.Forms.Padding(2);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(56, 24);
            this.SearchButton.TabIndex = 1;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // ClearSearchButton
            // 
            this.ClearSearchButton.Location = new System.Drawing.Point(215, 42);
            this.ClearSearchButton.Margin = new System.Windows.Forms.Padding(2);
            this.ClearSearchButton.Name = "ClearSearchButton";
            this.ClearSearchButton.Size = new System.Drawing.Size(80, 24);
            this.ClearSearchButton.TabIndex = 2;
            this.ClearSearchButton.Text = "Clear Search";
            this.ClearSearchButton.UseVisualStyleBackColor = true;
            this.ClearSearchButton.Click += new System.EventHandler(this.ClearSearchButton_Click);
            // 
            // SearchActiveLabel
            // 
            this.SearchActiveLabel.AutoSize = true;
            this.SearchActiveLabel.Location = new System.Drawing.Point(299, 48);
            this.SearchActiveLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SearchActiveLabel.Name = "SearchActiveLabel";
            this.SearchActiveLabel.Size = new System.Drawing.Size(74, 13);
            this.SearchActiveLabel.TabIndex = 8;
            this.SearchActiveLabel.Text = "Search Active";
            this.SearchActiveLabel.Visible = false;
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.Location = new System.Drawing.Point(11, 9);
            this.TitleLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(210, 24);
            this.TitleLabel.TabIndex = 9;
            this.TitleLabel.Text = "Manage Transactions";
            // 
            // UpsellLabel
            // 
            this.UpsellLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UpsellLabel.AutoSize = true;
            this.UpsellLabel.Location = new System.Drawing.Point(345, 76);
            this.UpsellLabel.Name = "UpsellLabel";
            this.UpsellLabel.Size = new System.Drawing.Size(397, 13);
            this.UpsellLabel.TabIndex = 10;
            this.UpsellLabel.Text = "Use the HemlockPOS program (sold separately) to make and manage transactions.";
            // 
            // TransactionManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 586);
            this.Controls.Add(this.UpsellLabel);
            this.Controls.Add(this.TitleLabel);
            this.Controls.Add(this.SearchActiveLabel);
            this.Controls.Add(this.ClearSearchButton);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.SearchBox);
            this.Controls.Add(this.RefreshButton);
            this.Controls.Add(this.TransactionDataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "TransactionManagerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manage Books";
            this.Load += new System.EventHandler(this.TransactionManagerForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ManageStudentsForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.TransactionDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView TransactionDataGridView;
        private System.Windows.Forms.Button RefreshButton;
        private System.Windows.Forms.TextBox SearchBox;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.Button ClearSearchButton;
        private System.Windows.Forms.Label SearchActiveLabel;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Label UpsellLabel;
    }
}