
namespace HemlockLibrarianStaffClient
{
    partial class UserEditorForm
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
            this.UserIDLabel = new System.Windows.Forms.Label();
            this.UserNameLabel = new System.Windows.Forms.Label();
            this.UserNameTextBox = new System.Windows.Forms.TextBox();
            this.CancelFormButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.GenerateUserIDButton = new System.Windows.Forms.Button();
            this.UserIDSelector = new System.Windows.Forms.NumericUpDown();
            this.EmailLabel = new System.Windows.Forms.Label();
            this.EmailTextBox = new System.Windows.Forms.TextBox();
            this.PhoneTextBox = new System.Windows.Forms.TextBox();
            this.PinTextBox = new System.Windows.Forms.TextBox();
            this.BalanceSelector = new System.Windows.Forms.NumericUpDown();
            this.PhoneLabel = new System.Windows.Forms.Label();
            this.PinLabel = new System.Windows.Forms.Label();
            this.BalanceLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.UserIDSelector)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BalanceSelector)).BeginInit();
            this.SuspendLayout();
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.Location = new System.Drawing.Point(9, 7);
            this.TitleLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(101, 24);
            this.TitleLabel.TabIndex = 0;
            this.TitleLabel.Text = "New User";
            // 
            // UserIDLabel
            // 
            this.UserIDLabel.AutoSize = true;
            this.UserIDLabel.Location = new System.Drawing.Point(31, 47);
            this.UserIDLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.UserIDLabel.Name = "UserIDLabel";
            this.UserIDLabel.Size = new System.Drawing.Size(43, 13);
            this.UserIDLabel.TabIndex = 1;
            this.UserIDLabel.Text = "User ID";
            // 
            // UserNameLabel
            // 
            this.UserNameLabel.AutoSize = true;
            this.UserNameLabel.Location = new System.Drawing.Point(14, 69);
            this.UserNameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.UserNameLabel.Name = "UserNameLabel";
            this.UserNameLabel.Size = new System.Drawing.Size(60, 13);
            this.UserNameLabel.TabIndex = 4;
            this.UserNameLabel.Text = "User Name";
            // 
            // UserNameTextBox
            // 
            this.UserNameTextBox.Location = new System.Drawing.Point(80, 66);
            this.UserNameTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.UserNameTextBox.MaxLength = 200;
            this.UserNameTextBox.Name = "UserNameTextBox";
            this.UserNameTextBox.Size = new System.Drawing.Size(160, 20);
            this.UserNameTextBox.TabIndex = 5;
            // 
            // CancelFormButton
            // 
            this.CancelFormButton.BackColor = System.Drawing.Color.Red;
            this.CancelFormButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelFormButton.Location = new System.Drawing.Point(13, 188);
            this.CancelFormButton.Margin = new System.Windows.Forms.Padding(2);
            this.CancelFormButton.Name = "CancelFormButton";
            this.CancelFormButton.Size = new System.Drawing.Size(84, 24);
            this.CancelFormButton.TabIndex = 18;
            this.CancelFormButton.Text = "Cancel [Esc]";
            this.CancelFormButton.UseVisualStyleBackColor = false;
            this.CancelFormButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.SaveButton.Location = new System.Drawing.Point(165, 188);
            this.SaveButton.Margin = new System.Windows.Forms.Padding(2);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(79, 24);
            this.SaveButton.TabIndex = 19;
            this.SaveButton.Text = "Save [Ctrl+S]";
            this.SaveButton.UseVisualStyleBackColor = false;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // GenerateUserIDButton
            // 
            this.GenerateUserIDButton.Location = new System.Drawing.Point(202, 42);
            this.GenerateUserIDButton.Name = "GenerateUserIDButton";
            this.GenerateUserIDButton.Size = new System.Drawing.Size(38, 23);
            this.GenerateUserIDButton.TabIndex = 3;
            this.GenerateUserIDButton.Text = "Auto";
            this.GenerateUserIDButton.UseVisualStyleBackColor = true;
            this.GenerateUserIDButton.Click += new System.EventHandler(this.GenerateUserIDButton_Click);
            // 
            // UserIDSelector
            // 
            this.UserIDSelector.Location = new System.Drawing.Point(81, 44);
            this.UserIDSelector.Maximum = new decimal(new int[] {
            -1,
            2147483647,
            0,
            0});
            this.UserIDSelector.Name = "UserIDSelector";
            this.UserIDSelector.Size = new System.Drawing.Size(120, 20);
            this.UserIDSelector.TabIndex = 2;
            // 
            // EmailLabel
            // 
            this.EmailLabel.AutoSize = true;
            this.EmailLabel.Location = new System.Drawing.Point(42, 93);
            this.EmailLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.EmailLabel.Name = "EmailLabel";
            this.EmailLabel.Size = new System.Drawing.Size(32, 13);
            this.EmailLabel.TabIndex = 20;
            this.EmailLabel.Text = "Email";
            // 
            // EmailTextBox
            // 
            this.EmailTextBox.Location = new System.Drawing.Point(80, 90);
            this.EmailTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.EmailTextBox.MaxLength = 200;
            this.EmailTextBox.Name = "EmailTextBox";
            this.EmailTextBox.Size = new System.Drawing.Size(160, 20);
            this.EmailTextBox.TabIndex = 21;
            // 
            // PhoneTextBox
            // 
            this.PhoneTextBox.Location = new System.Drawing.Point(80, 114);
            this.PhoneTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.PhoneTextBox.MaxLength = 200;
            this.PhoneTextBox.Name = "PhoneTextBox";
            this.PhoneTextBox.Size = new System.Drawing.Size(160, 20);
            this.PhoneTextBox.TabIndex = 22;
            // 
            // PinTextBox
            // 
            this.PinTextBox.Location = new System.Drawing.Point(80, 138);
            this.PinTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.PinTextBox.MaxLength = 20;
            this.PinTextBox.Name = "PinTextBox";
            this.PinTextBox.Size = new System.Drawing.Size(160, 20);
            this.PinTextBox.TabIndex = 23;
            // 
            // BalanceSelector
            // 
            this.BalanceSelector.DecimalPlaces = 2;
            this.BalanceSelector.Location = new System.Drawing.Point(80, 163);
            this.BalanceSelector.Maximum = new decimal(new int[] {
            -1,
            2147483647,
            0,
            262144});
            this.BalanceSelector.Minimum = new decimal(new int[] {
            0,
            -2147483648,
            0,
            -2147221504});
            this.BalanceSelector.Name = "BalanceSelector";
            this.BalanceSelector.Size = new System.Drawing.Size(159, 20);
            this.BalanceSelector.TabIndex = 24;
            // 
            // PhoneLabel
            // 
            this.PhoneLabel.AutoSize = true;
            this.PhoneLabel.Location = new System.Drawing.Point(36, 117);
            this.PhoneLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.PhoneLabel.Name = "PhoneLabel";
            this.PhoneLabel.Size = new System.Drawing.Size(38, 13);
            this.PhoneLabel.TabIndex = 25;
            this.PhoneLabel.Text = "Phone";
            // 
            // PinLabel
            // 
            this.PinLabel.AutoSize = true;
            this.PinLabel.Location = new System.Drawing.Point(49, 141);
            this.PinLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.PinLabel.Name = "PinLabel";
            this.PinLabel.Size = new System.Drawing.Size(25, 13);
            this.PinLabel.TabIndex = 26;
            this.PinLabel.Text = "PIN";
            // 
            // BalanceLabel
            // 
            this.BalanceLabel.AutoSize = true;
            this.BalanceLabel.Location = new System.Drawing.Point(28, 165);
            this.BalanceLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.BalanceLabel.Name = "BalanceLabel";
            this.BalanceLabel.Size = new System.Drawing.Size(46, 13);
            this.BalanceLabel.TabIndex = 27;
            this.BalanceLabel.Text = "Balance";
            // 
            // UserEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelFormButton;
            this.ClientSize = new System.Drawing.Size(255, 224);
            this.Controls.Add(this.BalanceLabel);
            this.Controls.Add(this.PinLabel);
            this.Controls.Add(this.PhoneLabel);
            this.Controls.Add(this.BalanceSelector);
            this.Controls.Add(this.PinTextBox);
            this.Controls.Add(this.PhoneTextBox);
            this.Controls.Add(this.EmailTextBox);
            this.Controls.Add(this.EmailLabel);
            this.Controls.Add(this.GenerateUserIDButton);
            this.Controls.Add(this.UserIDSelector);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.CancelFormButton);
            this.Controls.Add(this.UserNameTextBox);
            this.Controls.Add(this.UserNameLabel);
            this.Controls.Add(this.UserIDLabel);
            this.Controls.Add(this.TitleLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserEditorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New User";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UserEditorForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.UserIDSelector)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BalanceSelector)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Label UserIDLabel;
        private System.Windows.Forms.Label UserNameLabel;
        private System.Windows.Forms.TextBox UserNameTextBox;
        private System.Windows.Forms.Button CancelFormButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button GenerateUserIDButton;
        private System.Windows.Forms.NumericUpDown UserIDSelector;
        private System.Windows.Forms.Label EmailLabel;
        private System.Windows.Forms.TextBox EmailTextBox;
        private System.Windows.Forms.TextBox PhoneTextBox;
        private System.Windows.Forms.TextBox PinTextBox;
        private System.Windows.Forms.NumericUpDown BalanceSelector;
        private System.Windows.Forms.Label PhoneLabel;
        private System.Windows.Forms.Label PinLabel;
        private System.Windows.Forms.Label BalanceLabel;
    }
}
