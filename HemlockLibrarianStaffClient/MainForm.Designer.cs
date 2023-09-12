
namespace HemlockLibrarianStaffClient
{
    partial class MainForm
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
            this.FormPanel = new System.Windows.Forms.Panel();
            this.ManageBooksButton = new System.Windows.Forms.Button();
            this.ManageItemsButton = new System.Windows.Forms.Button();
            this.ManageBranchesButton = new System.Windows.Forms.Button();
            this.ManageUsersButton = new System.Windows.Forms.Button();
            this.ProgramTitleLabel = new System.Windows.Forms.Label();
            this.QuitButton = new System.Windows.Forms.Button();
            this.ManageHoldsButton = new System.Windows.Forms.Button();
            this.ManageTransactionsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // FormPanel
            // 
            this.FormPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FormPanel.BackColor = System.Drawing.SystemColors.Control;
            this.FormPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FormPanel.Location = new System.Drawing.Point(231, 12);
            this.FormPanel.Name = "FormPanel";
            this.FormPanel.Size = new System.Drawing.Size(676, 589);
            this.FormPanel.TabIndex = 0;
            // 
            // ManageBooksButton
            // 
            this.ManageBooksButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ManageBooksButton.Location = new System.Drawing.Point(13, 13);
            this.ManageBooksButton.Name = "ManageBooksButton";
            this.ManageBooksButton.Size = new System.Drawing.Size(212, 61);
            this.ManageBooksButton.TabIndex = 1;
            this.ManageBooksButton.Text = "Manage Books";
            this.ManageBooksButton.UseVisualStyleBackColor = true;
            this.ManageBooksButton.Click += new System.EventHandler(this.ManageBooksButton_Click);
            // 
            // ManageItemsButton
            // 
            this.ManageItemsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ManageItemsButton.Location = new System.Drawing.Point(13, 80);
            this.ManageItemsButton.Name = "ManageItemsButton";
            this.ManageItemsButton.Size = new System.Drawing.Size(212, 61);
            this.ManageItemsButton.TabIndex = 2;
            this.ManageItemsButton.Text = "Manage Items";
            this.ManageItemsButton.UseVisualStyleBackColor = true;
            this.ManageItemsButton.Click += new System.EventHandler(this.ManageItemsButton_Click);
            // 
            // ManageBranchesButton
            // 
            this.ManageBranchesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ManageBranchesButton.Location = new System.Drawing.Point(13, 147);
            this.ManageBranchesButton.Name = "ManageBranchesButton";
            this.ManageBranchesButton.Size = new System.Drawing.Size(212, 61);
            this.ManageBranchesButton.TabIndex = 3;
            this.ManageBranchesButton.Text = "Manage Branches";
            this.ManageBranchesButton.UseVisualStyleBackColor = true;
            this.ManageBranchesButton.Click += new System.EventHandler(this.ManageBranchesButton_Click);
            // 
            // ManageUsersButton
            // 
            this.ManageUsersButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ManageUsersButton.Location = new System.Drawing.Point(12, 214);
            this.ManageUsersButton.Name = "ManageUsersButton";
            this.ManageUsersButton.Size = new System.Drawing.Size(212, 61);
            this.ManageUsersButton.TabIndex = 4;
            this.ManageUsersButton.Text = "Manage Users";
            this.ManageUsersButton.UseVisualStyleBackColor = true;
            this.ManageUsersButton.Click += new System.EventHandler(this.ManageUsersButton_Click);
            // 
            // ProgramTitleLabel
            // 
            this.ProgramTitleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ProgramTitleLabel.AutoSize = true;
            this.ProgramTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProgramTitleLabel.Location = new System.Drawing.Point(25, 576);
            this.ProgramTitleLabel.Name = "ProgramTitleLabel";
            this.ProgramTitleLabel.Size = new System.Drawing.Size(179, 25);
            this.ProgramTitleLabel.TabIndex = 5;
            this.ProgramTitleLabel.Text = "HemlockLibrarian";
            // 
            // QuitButton
            // 
            this.QuitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.QuitButton.BackColor = System.Drawing.Color.Red;
            this.QuitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuitButton.Location = new System.Drawing.Point(30, 550);
            this.QuitButton.Name = "QuitButton";
            this.QuitButton.Size = new System.Drawing.Size(174, 23);
            this.QuitButton.TabIndex = 6;
            this.QuitButton.Text = "Quit";
            this.QuitButton.UseVisualStyleBackColor = false;
            this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
            // 
            // ManageHoldsButton
            // 
            this.ManageHoldsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ManageHoldsButton.Location = new System.Drawing.Point(13, 281);
            this.ManageHoldsButton.Name = "ManageHoldsButton";
            this.ManageHoldsButton.Size = new System.Drawing.Size(212, 61);
            this.ManageHoldsButton.TabIndex = 7;
            this.ManageHoldsButton.Text = "Manage Holds";
            this.ManageHoldsButton.UseVisualStyleBackColor = true;
            this.ManageHoldsButton.Click += new System.EventHandler(this.ManageHoldsButton_Click);
            // 
            // ManageTransactionsButton
            // 
            this.ManageTransactionsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ManageTransactionsButton.Location = new System.Drawing.Point(13, 348);
            this.ManageTransactionsButton.Name = "ManageTransactionsButton";
            this.ManageTransactionsButton.Size = new System.Drawing.Size(212, 61);
            this.ManageTransactionsButton.TabIndex = 8;
            this.ManageTransactionsButton.Text = "Manage Transactions";
            this.ManageTransactionsButton.UseVisualStyleBackColor = true;
            this.ManageTransactionsButton.Click += new System.EventHandler(this.ManageTransactionsButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(919, 613);
            this.Controls.Add(this.ManageTransactionsButton);
            this.Controls.Add(this.ManageHoldsButton);
            this.Controls.Add(this.QuitButton);
            this.Controls.Add(this.ProgramTitleLabel);
            this.Controls.Add(this.ManageUsersButton);
            this.Controls.Add(this.ManageBranchesButton);
            this.Controls.Add(this.ManageItemsButton);
            this.Controls.Add(this.ManageBooksButton);
            this.Controls.Add(this.FormPanel);
            this.Name = "MainForm";
            this.Text = "HemlockLibrarian";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel FormPanel;
        private System.Windows.Forms.Button ManageBooksButton;
        private System.Windows.Forms.Button ManageItemsButton;
        private System.Windows.Forms.Button ManageBranchesButton;
        private System.Windows.Forms.Button ManageUsersButton;
        private System.Windows.Forms.Label ProgramTitleLabel;
        private System.Windows.Forms.Button QuitButton;
        private System.Windows.Forms.Button ManageHoldsButton;
        private System.Windows.Forms.Button ManageTransactionsButton;
    }
}

