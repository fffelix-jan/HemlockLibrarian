using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace HemlockLibrarianStaffClient
{
    public partial class BookEditorForm : Form
    {
        public bool EditingExisting = false;

        // Makes an empty form for making a new book
        public BookEditorForm()
        {
            InitializeComponent();
            YearSelector.Value = DateTime.Now.Year;
            try
            {
                SetGeneratedBookID();
            }
            catch
            {
                // Do nothing if failed
            }
        }

        // Makes a filled-in form for editing an existing book
        public BookEditorForm(long bookID, string title, string author, string isbn, int publicationYear, decimal dewey, string description)
        {
            EditingExisting = true;
            InitializeComponent();

            this.Text = "Edit Book";
            TitleLabel.Text = "Edit Book";

            // Disable editing in the Book ID selector and grey it out
            BookIDSelector.ReadOnly = true;
            BookIDSelector.Enabled = false;
            GenerateBookIDButton.Enabled = false;

            // Fill in all the information
            BookIDSelector.Value = bookID;
            TitleTextBox.Text = title;
            AuthorTextBox.Text = author;
            ISBNTextBox.Text = isbn;
            YearSelector.Value = publicationYear;
            DeweySelector.Value = dewey;
            BookDescriptionTextBox.Text = description;
        }

        private void SetGeneratedBookID()
        {
            using (SqlConnection conn = new SqlConnection(SqlConnectionInfo.ConnectionString))
            {
                conn.Credential = SqlConnectionInfo.Credentials;
                try
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand("SELECT dbo.GenerateBookID()", conn))
                    {
                        long generatedBookID = (long)command.ExecuteScalar();
                        BookIDSelector.Value = generatedBookID;
                    }
                }
                catch (SqlException se)
                {
                    MessageBox.Show("An error occurred while generating the book ID. The following error #" + se.Number + " occurred:\r\n" + se.Message, "Error Generating Book ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void GenerateBookIDButton_Click(object sender, EventArgs e)
        {
            SetGeneratedBookID();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(SqlConnectionInfo.ConnectionString))
            {
                conn.Credential = SqlConnectionInfo.Credentials;

                // If we are editing an existing book, use UPDATE instead of INSERT
                if (EditingExisting)
                {
                    // Make the update command and update the data
                    using (SqlCommand updateCommand = new SqlCommand())
                    {
                        updateCommand.Connection = conn;
                        updateCommand.CommandType = CommandType.Text;
                        updateCommand.CommandText = "UPDATE Books SET Title = @NewTitle, Author = @NewAuthor, ISBN = @NewISBN, PublicationYear = @NewPublicationYear, DeweyClassification = @NewDeweyClassification, BookDescription = @NewBookDescription WHERE BookID = @CurBookID;";
                        updateCommand.Parameters.AddWithValue("@NewTitle", TitleTextBox.Text);
                        updateCommand.Parameters.AddWithValue("@NewAuthor", AuthorTextBox.Text);
                        updateCommand.Parameters.AddWithValue("@NewISBN", ISBNTextBox.Text);
                        updateCommand.Parameters.AddWithValue("@NewPublicationYear", YearSelector.Value);
                        updateCommand.Parameters.AddWithValue("@NewDeweyClassification", DeweySelector.Value);
                        updateCommand.Parameters.AddWithValue("@NewBookDescription", BookDescriptionTextBox.Text);
                        updateCommand.Parameters.AddWithValue("@CurBookID", BookIDSelector.Value);

                        // Try it, and if it fails, show the error message
                        try
                        {
                            conn.Open();
                            updateCommand.ExecuteNonQuery();
                            conn.Close();
                            this.Close();
                            return;
                        }
                        catch (SqlException se)
                        {
                            MessageBox.Show("An error occured when updating the book into the database. The following error #" + se.Number + " occurred:\r\n" + se.Message, "Error Updating Book", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
                else
                {
                    // Make the insert command and insert the data
                    using (SqlCommand insertCommand = new SqlCommand())
                    {
                        insertCommand.Connection = conn;
                        insertCommand.CommandType = CommandType.Text;
                        insertCommand.CommandText = "INSERT INTO Books (BookID, Title, Author, ISBN, PublicationYear, DeweyClassification, BookDescription) VALUES (@NewBookID, @NewTitle, @NewAuthor, @NewISBN, @NewPublicationYear, @NewDeweyClassification, @NewBookDescription);";
                        insertCommand.Parameters.AddWithValue("@NewBookID", BookIDSelector.Value);
                        insertCommand.Parameters.AddWithValue("@NewTitle", TitleTextBox.Text);
                        insertCommand.Parameters.AddWithValue("@NewAuthor", AuthorTextBox.Text);
                        insertCommand.Parameters.AddWithValue("@NewISBN", ISBNTextBox.Text);
                        insertCommand.Parameters.AddWithValue("@NewPublicationYear", YearSelector.Value);
                        insertCommand.Parameters.AddWithValue("@NewDeweyClassification", DeweySelector.Value);
                        insertCommand.Parameters.AddWithValue("@NewBookDescription", BookDescriptionTextBox.Text);

                        // Try it, and if it fails, show the error message
                        try
                        {
                            conn.Open();
                            insertCommand.ExecuteNonQuery();
                            this.Close();
                            return;
                        }
                        catch (SqlException se)
                        {
                            // If it's the violation of the primary key constraint, show the error that tells the user that a book already exists
                            if (se.Number == 2627)
                            {
                                MessageBox.Show("A book with this book ID already exists in the database.", "Book Already Exists", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                MessageBox.Show("An error occured when inserting the book into the database. The following error #" + se.Number + " occurred:\r\n" + se.Message, "Error Inserting Book", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            return;
                        }
                    }
                }
            }
        }

        // Keyboard shortcuts
        private void BookEditorForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                SaveButton.PerformClick();
            }
        }
    }
}
