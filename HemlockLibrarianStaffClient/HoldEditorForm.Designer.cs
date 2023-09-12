
namespace HemlockLibrarianStaffClient
{
    partial class HoldEditorForm
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
            this.HoldIDLabel = new System.Windows.Forms.Label();
            this.CancelFormButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.GenerateHoldIDButton = new System.Windows.Forms.Button();
            this.HoldIDSelector = new System.Windows.Forms.NumericUpDown();
            this.HoldDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.UserIDLabel = new System.Windows.Forms.Label();
            this.UserIDSelector = new System.Windows.Forms.NumericUpDown();
            this.BookIDSelector = new System.Windows.Forms.NumericUpDown();
            this.BookIDLabel = new System.Windows.Forms.Label();
            this.HoldDateLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.HoldIDSelector)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserIDSelector)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BookIDSelector)).BeginInit();
            this.SuspendLayout();
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.Location = new System.Drawing.Point(9, 7);
            this.TitleLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(102, 24);
            this.TitleLabel.TabIndex = 0;
            this.TitleLabel.Text = "New Hold";
            // 
            // HoldIDLabel
            // 
            this.HoldIDLabel.AutoSize = true;
            this.HoldIDLabel.Location = new System.Drawing.Point(31, 47);
            this.HoldIDLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.HoldIDLabel.Name = "HoldIDLabel";
            this.HoldIDLabel.Size = new System.Drawing.Size(43, 13);
            this.HoldIDLabel.TabIndex = 1;
            this.HoldIDLabel.Text = "Hold ID";
            // 
            // CancelFormButton
            // 
            this.CancelFormButton.BackColor = System.Drawing.Color.Red;
            this.CancelFormButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelFormButton.Location = new System.Drawing.Point(11, 149);
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
            this.SaveButton.Location = new System.Drawing.Point(165, 149);
            this.SaveButton.Margin = new System.Windows.Forms.Padding(2);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(79, 24);
            this.SaveButton.TabIndex = 19;
            this.SaveButton.Text = "Save [Ctrl+S]";
            this.SaveButton.UseVisualStyleBackColor = false;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // GenerateHoldIDButton
            // 
            this.GenerateHoldIDButton.Location = new System.Drawing.Point(202, 42);
            this.GenerateHoldIDButton.Name = "GenerateHoldIDButton";
            this.GenerateHoldIDButton.Size = new System.Drawing.Size(38, 23);
            this.GenerateHoldIDButton.TabIndex = 3;
            this.GenerateHoldIDButton.Text = "Auto";
            this.GenerateHoldIDButton.UseVisualStyleBackColor = true;
            this.GenerateHoldIDButton.Click += new System.EventHandler(this.GenerateHoldIDButton_Click);
            // 
            // HoldIDSelector
            // 
            this.HoldIDSelector.Location = new System.Drawing.Point(81, 44);
            this.HoldIDSelector.Maximum = new decimal(new int[] {
            -1,
            2147483647,
            0,
            0});
            this.HoldIDSelector.Name = "HoldIDSelector";
            this.HoldIDSelector.Size = new System.Drawing.Size(120, 20);
            this.HoldIDSelector.TabIndex = 2;
            // 
            // HoldDateTimePicker
            // 
            this.HoldDateTimePicker.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.HoldDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.HoldDateTimePicker.Location = new System.Drawing.Point(81, 124);
            this.HoldDateTimePicker.Name = "HoldDateTimePicker";
            this.HoldDateTimePicker.Size = new System.Drawing.Size(159, 20);
            this.HoldDateTimePicker.TabIndex = 20;
            // 
            // UserIDLabel
            // 
            this.UserIDLabel.AutoSize = true;
            this.UserIDLabel.Location = new System.Drawing.Point(31, 72);
            this.UserIDLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.UserIDLabel.Name = "UserIDLabel";
            this.UserIDLabel.Size = new System.Drawing.Size(43, 13);
            this.UserIDLabel.TabIndex = 21;
            this.UserIDLabel.Text = "User ID";
            // 
            // UserIDSelector
            // 
            this.UserIDSelector.Location = new System.Drawing.Point(81, 70);
            this.UserIDSelector.Maximum = new decimal(new int[] {
            -1,
            2147483647,
            0,
            0});
            this.UserIDSelector.Name = "UserIDSelector";
            this.UserIDSelector.Size = new System.Drawing.Size(159, 20);
            this.UserIDSelector.TabIndex = 22;
            // 
            // BookIDSelector
            // 
            this.BookIDSelector.Location = new System.Drawing.Point(81, 96);
            this.BookIDSelector.Maximum = new decimal(new int[] {
            -1,
            2147483647,
            0,
            0});
            this.BookIDSelector.Name = "BookIDSelector";
            this.BookIDSelector.Size = new System.Drawing.Size(159, 20);
            this.BookIDSelector.TabIndex = 23;
            // 
            // BookIDLabel
            // 
            this.BookIDLabel.AutoSize = true;
            this.BookIDLabel.Location = new System.Drawing.Point(28, 98);
            this.BookIDLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.BookIDLabel.Name = "BookIDLabel";
            this.BookIDLabel.Size = new System.Drawing.Size(46, 13);
            this.BookIDLabel.TabIndex = 24;
            this.BookIDLabel.Text = "Book ID";
            // 
            // HoldDateLabel
            // 
            this.HoldDateLabel.AutoSize = true;
            this.HoldDateLabel.Location = new System.Drawing.Point(11, 124);
            this.HoldDateLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.HoldDateLabel.Name = "HoldDateLabel";
            this.HoldDateLabel.Size = new System.Drawing.Size(55, 13);
            this.HoldDateLabel.TabIndex = 25;
            this.HoldDateLabel.Text = "Hold Date";
            // 
            // HoldEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelFormButton;
            this.ClientSize = new System.Drawing.Size(255, 182);
            this.Controls.Add(this.HoldDateLabel);
            this.Controls.Add(this.BookIDLabel);
            this.Controls.Add(this.BookIDSelector);
            this.Controls.Add(this.UserIDSelector);
            this.Controls.Add(this.UserIDLabel);
            this.Controls.Add(this.HoldDateTimePicker);
            this.Controls.Add(this.GenerateHoldIDButton);
            this.Controls.Add(this.HoldIDSelector);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.CancelFormButton);
            this.Controls.Add(this.HoldIDLabel);
            this.Controls.Add(this.TitleLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HoldEditorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Hold";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.HoldEditorForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.HoldIDSelector)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserIDSelector)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BookIDSelector)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Label HoldIDLabel;
        private System.Windows.Forms.Button CancelFormButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button GenerateHoldIDButton;
        private System.Windows.Forms.NumericUpDown HoldIDSelector;
        private System.Windows.Forms.DateTimePicker HoldDateTimePicker;
        private System.Windows.Forms.Label UserIDLabel;
        private System.Windows.Forms.NumericUpDown UserIDSelector;
        private System.Windows.Forms.NumericUpDown BookIDSelector;
        private System.Windows.Forms.Label BookIDLabel;
        private System.Windows.Forms.Label HoldDateLabel;
    }
}
