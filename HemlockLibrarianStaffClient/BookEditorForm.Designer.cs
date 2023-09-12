
namespace HemlockLibrarianStaffClient
{
    partial class BookEditorForm
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
            this.BookIDLabel = new System.Windows.Forms.Label();
            this.BookTitleLabel = new System.Windows.Forms.Label();
            this.TitleTextBox = new System.Windows.Forms.TextBox();
            this.AuthorLabel = new System.Windows.Forms.Label();
            this.AuthorTextBox = new System.Windows.Forms.TextBox();
            this.ISBNTextBox = new System.Windows.Forms.TextBox();
            this.ISBNLabel = new System.Windows.Forms.Label();
            this.YearLabel = new System.Windows.Forms.Label();
            this.EmailLabel = new System.Windows.Forms.Label();
            this.BookDescriptionLabel = new System.Windows.Forms.Label();
            this.BookDescriptionTextBox = new System.Windows.Forms.TextBox();
            this.CancelFormButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.BookIDSelector = new System.Windows.Forms.NumericUpDown();
            this.GenerateBookIDButton = new System.Windows.Forms.Button();
            this.YearSelector = new System.Windows.Forms.NumericUpDown();
            this.DeweySelector = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.BookIDSelector)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YearSelector)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeweySelector)).BeginInit();
            this.SuspendLayout();
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.Location = new System.Drawing.Point(9, 7);
            this.TitleLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(105, 24);
            this.TitleLabel.TabIndex = 0;
            this.TitleLabel.Text = "New Book";
            // 
            // BookIDLabel
            // 
            this.BookIDLabel.AutoSize = true;
            this.BookIDLabel.Location = new System.Drawing.Point(30, 43);
            this.BookIDLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.BookIDLabel.Name = "BookIDLabel";
            this.BookIDLabel.Size = new System.Drawing.Size(46, 13);
            this.BookIDLabel.TabIndex = 1;
            this.BookIDLabel.Text = "Book ID";
            // 
            // BookTitleLabel
            // 
            this.BookTitleLabel.AutoSize = true;
            this.BookTitleLabel.Location = new System.Drawing.Point(49, 69);
            this.BookTitleLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.BookTitleLabel.Name = "BookTitleLabel";
            this.BookTitleLabel.Size = new System.Drawing.Size(27, 13);
            this.BookTitleLabel.TabIndex = 4;
            this.BookTitleLabel.Text = "Title";
            // 
            // TitleTextBox
            // 
            this.TitleTextBox.Location = new System.Drawing.Point(80, 66);
            this.TitleTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.TitleTextBox.MaxLength = 900;
            this.TitleTextBox.Name = "TitleTextBox";
            this.TitleTextBox.Size = new System.Drawing.Size(160, 20);
            this.TitleTextBox.TabIndex = 5;
            // 
            // AuthorLabel
            // 
            this.AuthorLabel.AutoSize = true;
            this.AuthorLabel.Location = new System.Drawing.Point(38, 93);
            this.AuthorLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.AuthorLabel.Name = "AuthorLabel";
            this.AuthorLabel.Size = new System.Drawing.Size(38, 13);
            this.AuthorLabel.TabIndex = 6;
            this.AuthorLabel.Text = "Author";
            // 
            // AuthorTextBox
            // 
            this.AuthorTextBox.Location = new System.Drawing.Point(80, 90);
            this.AuthorTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.AuthorTextBox.MaxLength = 4000;
            this.AuthorTextBox.Name = "AuthorTextBox";
            this.AuthorTextBox.Size = new System.Drawing.Size(160, 20);
            this.AuthorTextBox.TabIndex = 7;
            // 
            // ISBNTextBox
            // 
            this.ISBNTextBox.Location = new System.Drawing.Point(80, 114);
            this.ISBNTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.ISBNTextBox.MaxLength = 4000;
            this.ISBNTextBox.Name = "ISBNTextBox";
            this.ISBNTextBox.Size = new System.Drawing.Size(160, 20);
            this.ISBNTextBox.TabIndex = 9;
            // 
            // ISBNLabel
            // 
            this.ISBNLabel.AutoSize = true;
            this.ISBNLabel.Location = new System.Drawing.Point(44, 117);
            this.ISBNLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ISBNLabel.Name = "ISBNLabel";
            this.ISBNLabel.Size = new System.Drawing.Size(32, 13);
            this.ISBNLabel.TabIndex = 8;
            this.ISBNLabel.Text = "ISBN";
            // 
            // YearLabel
            // 
            this.YearLabel.AutoSize = true;
            this.YearLabel.Location = new System.Drawing.Point(22, 141);
            this.YearLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.YearLabel.Name = "YearLabel";
            this.YearLabel.Size = new System.Drawing.Size(54, 13);
            this.YearLabel.TabIndex = 10;
            this.YearLabel.Text = "Pub. Year";
            // 
            // EmailLabel
            // 
            this.EmailLabel.AutoSize = true;
            this.EmailLabel.Location = new System.Drawing.Point(4, 165);
            this.EmailLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.EmailLabel.Name = "EmailLabel";
            this.EmailLabel.Size = new System.Drawing.Size(76, 13);
            this.EmailLabel.TabIndex = 12;
            this.EmailLabel.Text = "Dewey Classif.";
            // 
            // BookDescriptionLabel
            // 
            this.BookDescriptionLabel.AutoSize = true;
            this.BookDescriptionLabel.Location = new System.Drawing.Point(10, 193);
            this.BookDescriptionLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.BookDescriptionLabel.Name = "BookDescriptionLabel";
            this.BookDescriptionLabel.Size = new System.Drawing.Size(88, 13);
            this.BookDescriptionLabel.TabIndex = 14;
            this.BookDescriptionLabel.Text = "Book Description";
            // 
            // BookDescriptionTextBox
            // 
            this.BookDescriptionTextBox.AcceptsReturn = true;
            this.BookDescriptionTextBox.Location = new System.Drawing.Point(12, 209);
            this.BookDescriptionTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.BookDescriptionTextBox.MaxLength = 4000;
            this.BookDescriptionTextBox.Multiline = true;
            this.BookDescriptionTextBox.Name = "BookDescriptionTextBox";
            this.BookDescriptionTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.BookDescriptionTextBox.Size = new System.Drawing.Size(228, 116);
            this.BookDescriptionTextBox.TabIndex = 15;
            // 
            // CancelFormButton
            // 
            this.CancelFormButton.BackColor = System.Drawing.Color.Red;
            this.CancelFormButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelFormButton.Location = new System.Drawing.Point(7, 329);
            this.CancelFormButton.Margin = new System.Windows.Forms.Padding(2);
            this.CancelFormButton.Name = "CancelFormButton";
            this.CancelFormButton.Size = new System.Drawing.Size(84, 24);
            this.CancelFormButton.TabIndex = 16;
            this.CancelFormButton.Text = "Cancel [Esc]";
            this.CancelFormButton.UseVisualStyleBackColor = false;
            this.CancelFormButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.SaveButton.Location = new System.Drawing.Point(165, 329);
            this.SaveButton.Margin = new System.Windows.Forms.Padding(2);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(79, 24);
            this.SaveButton.TabIndex = 17;
            this.SaveButton.Text = "Save [Ctrl+S]";
            this.SaveButton.UseVisualStyleBackColor = false;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // BookIDSelector
            // 
            this.BookIDSelector.Location = new System.Drawing.Point(81, 40);
            this.BookIDSelector.Maximum = new decimal(new int[] {
            -1,
            2147483647,
            0,
            0});
            this.BookIDSelector.Name = "BookIDSelector";
            this.BookIDSelector.Size = new System.Drawing.Size(120, 20);
            this.BookIDSelector.TabIndex = 2;
            // 
            // GenerateBookIDButton
            // 
            this.GenerateBookIDButton.Location = new System.Drawing.Point(202, 38);
            this.GenerateBookIDButton.Name = "GenerateBookIDButton";
            this.GenerateBookIDButton.Size = new System.Drawing.Size(38, 23);
            this.GenerateBookIDButton.TabIndex = 3;
            this.GenerateBookIDButton.Text = "Auto";
            this.GenerateBookIDButton.UseVisualStyleBackColor = true;
            this.GenerateBookIDButton.Click += new System.EventHandler(this.GenerateBookIDButton_Click);
            // 
            // YearSelector
            // 
            this.YearSelector.Location = new System.Drawing.Point(81, 139);
            this.YearSelector.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.YearSelector.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.YearSelector.Name = "YearSelector";
            this.YearSelector.Size = new System.Drawing.Size(159, 20);
            this.YearSelector.TabIndex = 11;
            // 
            // DeweySelector
            // 
            this.DeweySelector.DecimalPlaces = 7;
            this.DeweySelector.Location = new System.Drawing.Point(81, 163);
            this.DeweySelector.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            458752});
            this.DeweySelector.Name = "DeweySelector";
            this.DeweySelector.Size = new System.Drawing.Size(159, 20);
            this.DeweySelector.TabIndex = 13;
            // 
            // BookEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelFormButton;
            this.ClientSize = new System.Drawing.Size(255, 360);
            this.Controls.Add(this.DeweySelector);
            this.Controls.Add(this.YearSelector);
            this.Controls.Add(this.GenerateBookIDButton);
            this.Controls.Add(this.BookIDSelector);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.CancelFormButton);
            this.Controls.Add(this.BookDescriptionTextBox);
            this.Controls.Add(this.BookDescriptionLabel);
            this.Controls.Add(this.EmailLabel);
            this.Controls.Add(this.YearLabel);
            this.Controls.Add(this.ISBNLabel);
            this.Controls.Add(this.ISBNTextBox);
            this.Controls.Add(this.AuthorTextBox);
            this.Controls.Add(this.AuthorLabel);
            this.Controls.Add(this.TitleTextBox);
            this.Controls.Add(this.BookTitleLabel);
            this.Controls.Add(this.BookIDLabel);
            this.Controls.Add(this.TitleLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BookEditorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Book";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BookEditorForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.BookIDSelector)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YearSelector)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeweySelector)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Label BookIDLabel;
        private System.Windows.Forms.Label BookTitleLabel;
        private System.Windows.Forms.TextBox TitleTextBox;
        private System.Windows.Forms.Label AuthorLabel;
        private System.Windows.Forms.TextBox AuthorTextBox;
        private System.Windows.Forms.TextBox ISBNTextBox;
        private System.Windows.Forms.Label ISBNLabel;
        private System.Windows.Forms.Label YearLabel;
        private System.Windows.Forms.Label EmailLabel;
        private System.Windows.Forms.Label BookDescriptionLabel;
        private System.Windows.Forms.TextBox BookDescriptionTextBox;
        private System.Windows.Forms.Button CancelFormButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.NumericUpDown BookIDSelector;
        private System.Windows.Forms.Button GenerateBookIDButton;
        private System.Windows.Forms.NumericUpDown YearSelector;
        private System.Windows.Forms.NumericUpDown DeweySelector;
    }
}