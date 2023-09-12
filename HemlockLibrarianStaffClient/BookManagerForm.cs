// Note: This code is based on https://github.com/NorthTorontoChristianSchool/NTCS-Attendance-Staff-Client/blob/main/ManageStudentsForm.cs
// (taken from my old high school project)

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;

namespace HemlockLibrarianStaffClient
{
    public partial class BookManagerForm : Form
    {
        private bool SearchActive = false;
        private bool FirstTimeLoaded = false;
        private string SearchString = "";

        public BookManagerForm()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            HashSet<string> selectedBookIDs = new HashSet<string>();
            // Remember which row was selected if refreshing
            if (FirstTimeLoaded)
            {
                foreach (DataGridViewRow row in BookDataGridView.SelectedRows)
                {
                    selectedBookIDs.Add(row.Cells["Book ID"].ToString());
                }
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(SqlConnectionInfo.ConnectionString))
                {
                    // supply the credentials to the connection
                    conn.Credential = SqlConnectionInfo.Credentials;

                    // use parameterized query if searching
                    if (SearchActive)
                    {
                        using (SqlCommand sqlCmd = new SqlCommand())
                        {
                            sqlCmd.Connection = conn;
                            sqlCmd.CommandType = CommandType.Text;
                            sqlCmd.CommandText = "SELECT BookID AS 'Book ID', Title, Author, ISBN, PublicationYear AS 'Publication Year', DeweyClassification AS 'Dewey Classification', BookDescription AS 'Book Description' FROM Books WHERE (BookID LIKE '%' + @Search + '%' OR Title LIKE '%' + @Search + '%' OR Author LIKE '%' + @Search + '%' OR ISBN LIKE '%' + @Search + '%' OR BookDescription LIKE '%' + @Search + '%') ORDER BY Title;";
                            sqlCmd.Parameters.AddWithValue("@Search", "%" + SearchString + "%");
                            SqlDataAdapter sqlDataAdap = new SqlDataAdapter(sqlCmd);

                            DataTable dtRecord = new DataTable();
                            sqlDataAdap.Fill(dtRecord);
                            BookDataGridView.DataSource = dtRecord;
                        }
                    }
                    // default to selecting everything
                    else
                    {
                        using (SqlCommand sqlCmd = new SqlCommand())
                        {
                            sqlCmd.Connection = conn;
                            sqlCmd.CommandType = CommandType.Text;
                            sqlCmd.CommandText = "SELECT BookID AS 'Book ID', Title, Author, ISBN, PublicationYear AS 'Publication Year', DeweyClassification AS 'Dewey Classification', BookDescription AS 'Book Description' FROM Books ORDER BY Title;";
                            SqlDataAdapter sqlDataAdap = new SqlDataAdapter(sqlCmd);

                            DataTable dtRecord = new DataTable();
                            sqlDataAdap.Fill(dtRecord);
                            BookDataGridView.DataSource = dtRecord;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                SqlErrorDialog.ShowRuntimeConnectionErrorMessage(ex.Message);
            }


            // Re-select the previously selected rows
            bool firstRowSelected = false;
            BookDataGridView.ClearSelection();
            if (FirstTimeLoaded)
            {
                foreach (DataGridViewRow row in BookDataGridView.Rows)
                {
                    if (selectedBookIDs.Contains(row.Cells["Book ID"].ToString()))
                    {
                        row.Selected = true;
                        if (!firstRowSelected)
                        {
                            BookDataGridView.CurrentCell = row.Cells[0];
                            firstRowSelected = true;
                        }
                    }
                }
            }
            BookDataGridView.Columns["Dewey Classification"].DefaultCellStyle.Format = "0.0##########";
            FirstTimeLoaded = true;
        }

        private void BookManagerForm_Load(object sender, EventArgs e)
        {
            // Enable double buffering to reduce the lag when scrolling the DataGridView
            ControlDoubleBuffering.SetDoubleBuffered(BookDataGridView);

            // Load the data
            this.LoadData();
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            SearchBox.Text = SearchString;
            this.LoadData();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            SearchActive = true;
            SearchActiveLabel.Show();
            SearchString = SearchBox.Text;
            this.LoadData();
        }

        private void SearchBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchButton.PerformClick();
            }
        }

        private void ClearSearchButton_Click(object sender, EventArgs e)
        {
            SearchActive = false;
            SearchActiveLabel.Hide();
            SearchString = "";
            SearchBox.Text = "";
            this.LoadData();
        }

        private void NewBookButton_Click(object sender, EventArgs e)
        {
            BookEditorForm bef = new BookEditorForm();
            bef.ShowDialog();
            RefreshButton.PerformClick();
        }

        // Edit a student when the row in the DataGridView is double-clicked
        private void EditSelectedRow()
        {
            if (BookDataGridView.SelectedRows.Count == 0)
                return;

            long bookID = Convert.ToInt64(BookDataGridView.SelectedRows[0].Cells["Book ID"].Value);
            string title = BookDataGridView.SelectedRows[0].Cells["Title"].Value.ToString();
            string author = BookDataGridView.SelectedRows[0].Cells["Author"].Value.ToString();
            string isbn = BookDataGridView.SelectedRows[0].Cells["ISBN"].Value.ToString();
            int publicationYear = Convert.ToInt32(BookDataGridView.SelectedRows[0].Cells["Publication Year"].Value);
            decimal dewey = Convert.ToDecimal(BookDataGridView.SelectedRows[0].Cells["Dewey Classification"].Value);
            string description = BookDataGridView.SelectedRows[0].Cells["Book Description"].Value.ToString();

            BookEditorForm bef = new BookEditorForm(bookID, title, author, isbn, publicationYear, dewey, description);
            bef.ShowDialog();
            RefreshButton.PerformClick();
        }

        private void BookDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            this.EditSelectedRow();
        }

        private void BookDataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                this.EditSelectedRow();
            }
        }

        private void DeleteSelectedButton_Click(object sender, EventArgs e)
        {
            // Loop through the selected names to gather a list of names that will be deleted
            if (BookDataGridView.SelectedRows.Count == 0)
                return;
            StringBuilder userListOfNamesToDelete = new StringBuilder();
            foreach (DataGridViewRow row in BookDataGridView.SelectedRows)
            {
                userListOfNamesToDelete.Append(row.Cells["Book ID"].Value);
                userListOfNamesToDelete.Append(": ");
                userListOfNamesToDelete.Append(row.Cells["Title"].Value);
                userListOfNamesToDelete.Append("\r\n");
            }

            // Ask the user if they are sure that they want to delete the selected rows
            DialogResult result = MessageBox.Show("Are you sure you want to delete the following books?\r\n\r\n" + userListOfNamesToDelete.ToString() + "\r\nThis action cannot be undone!", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(SqlConnectionInfo.ConnectionString))
                {
                    conn.Credential = SqlConnectionInfo.Credentials;
                    try
                    {
                        conn.Open();
                    }
                    catch (SqlException se)
                    {
                        SqlErrorDialog.ShowRuntimeConnectionErrorMessage(se.Message);
                    }

                    // Loop through the selected rows and delete each one
                    foreach (DataGridViewRow row in BookDataGridView.SelectedRows)
                    {
                        using (SqlCommand deleteCommand = new SqlCommand())
                        {
                            deleteCommand.Connection = conn;
                            deleteCommand.CommandType = CommandType.Text;
                            deleteCommand.CommandText = "DELETE FROM Books WHERE BookID = @DeletingBookID;";
                            deleteCommand.Parameters.AddWithValue("@DeletingBookID", row.Cells["Book ID"].Value);

                            try
                            {
                                deleteCommand.ExecuteNonQuery();
                            }
                            catch (SqlException se)
                            {
                                if (se.Number == 547)
                                {
                                    // This means that there is an item of this book that currently exists, so it can't be deleted.
                                    MessageBox.Show(row.Cells["Book ID"].Value + ": " + row.Cells["Title"].Value + "\r\nThis book cannot be deleted because it is associated with an item in the library. Please remove all associated items before deleting the book.", "Book Cannot Be Deleted", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    MessageBox.Show("An error occured when deleting the book from the database. The following error #" + se.Number + " occurred:\r\n" + se.Message, "Error Deleting Book", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }
                        }
                    }
                }

            }
            RefreshButton.PerformClick();
        }

        // Keyboard shortcuts
        private void ManageStudentsForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.N)
            {
                NewBookButton.PerformClick();
            }
            else if (e.Control && e.KeyCode == Keys.I)
            {
                ImportBooksButton.PerformClick();
            }
            else if (e.KeyCode == Keys.F3)
            {
                this.ActiveControl = SearchBox;
            }
            else if (e.KeyCode == Keys.F5)
            {
                RefreshButton.PerformClick();
            }
            else if (e.KeyCode == Keys.Delete)
            {
                DeleteSelectedButton.PerformClick();
            }
        }

        
        private void ImportBooksButton_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show("The Import Books feature requires that your books be in a CSV file of the following format:\r\nTitle,Author,ISBN,PublicationYear,DeweyClassification,BookDescription\r\nThe Book ID will be generated automatically.\r\nAre you sure you want to begin?", "Import Books", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dialogResult != DialogResult.Yes)
            {
                return;
            }

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            ofd.Title = "Import Books CSV File";
            ofd.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            ofd.Multiselect = false;

            if (ofd.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            using (TextFieldParser parser = new TextFieldParser(ofd.FileName, Encoding.UTF8))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                while (!parser.EndOfData)
                {
                    // Process row
                    string[] fields = parser.ReadFields();
                    //MessageBox.Show(string.Join(",", fields));
                    int publicationYearInt;
                    if (!int.TryParse(fields[3], out publicationYearInt))
                    {
                        MessageBox.Show("The publication year of " + fields[0] + " is not a valid integer! Press OK to skip and continue.");
                        continue;
                    }
                    decimal deweyDecimal;
                    if (!decimal.TryParse(fields[4], out deweyDecimal))
                    {
                        MessageBox.Show("The Dewey decimal classification of " + fields[0] + " is not a valid decimal! Press OK to skip and continue.");
                        continue;
                    }

                    using (SqlConnection conn = new SqlConnection(SqlConnectionInfo.ConnectionString))
                    {
                        conn.Credential = SqlConnectionInfo.Credentials;

                        // Make the insert command and insert the data
                        using (SqlCommand insertCommand = new SqlCommand())
                        {
                            insertCommand.Connection = conn;
                            insertCommand.CommandType = CommandType.Text;
                            insertCommand.CommandText = "INSERT INTO Books (BookID, Title, Author, ISBN, PublicationYear, DeweyClassification, BookDescription) VALUES (dbo.GenerateBookID(), @NewTitle, @NewAuthor, @NewISBN, @NewPublicationYear, @NewDeweyClassification, @NewBookDescription);";
                            insertCommand.Parameters.AddWithValue("@NewTitle", fields[0]);
                            insertCommand.Parameters.AddWithValue("@NewAuthor", fields[1]);
                            insertCommand.Parameters.AddWithValue("@NewISBN", fields[2]);
                            insertCommand.Parameters.AddWithValue("@NewPublicationYear", publicationYearInt);
                            insertCommand.Parameters.AddWithValue("@NewDeweyClassification", deweyDecimal);
                            insertCommand.Parameters.AddWithValue("@NewBookDescription", fields[5]);

                            // Try it, and if it fails, show the error message
                            try
                            {
                                conn.Open();
                                insertCommand.ExecuteNonQuery();
                            }
                            catch (SqlException se)
                            {
                                // If it's the violation of the primary key constraint, show the error that tells the user that a book already exists
                                if (se.Number == 2627)
                                {
                                    MessageBox.Show("The generated book ID already exists in the database. You should never see this error message. If you see this, this means that the GenerateBookID() function is not working properly.", "Book Already Exists", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                //MessageBox.Show("End");
            }
            RefreshButton.PerformClick();
        }
    }
}
