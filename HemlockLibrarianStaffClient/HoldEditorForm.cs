using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace HemlockLibrarianStaffClient
{
    public partial class HoldEditorForm : Form
    {
        public bool EditingExisting = false;

        // Makes an empty form for creating a new hold
        public HoldEditorForm()
        {
            InitializeComponent();
        }

        // Makes a filled-in form for editing an existing hold
        public HoldEditorForm(long curHoldID, long curUserID, long curBookID, DateTime curHoldDate)
        {
            EditingExisting = true;
            InitializeComponent();

            this.Text = "Edit Hold";

            // Disable editing in the Hold ID text box and grey it out
            HoldIDSelector.Enabled = false;
            GenerateHoldIDButton.Enabled = false;

            // Fill in all the information
            TitleLabel.Text = "Edit Hold";
            HoldIDSelector.Value = curHoldID;
            UserIDSelector.Value = curUserID;
            BookIDSelector.Value = curBookID;
            HoldDateTimePicker.Value = curHoldDate;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            // Check if the Hold ID box is empty (it shouldn't be) and show an error message if it is
            if (HoldIDSelector.Value == 0)
            {
                MessageBox.Show("You must enter a Hold ID.", "Hold ID Missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection conn = new SqlConnection(SqlConnectionInfo.ConnectionString))
            {
                conn.Credential = SqlConnectionInfo.Credentials;

                // If we are editing an existing hold, use UPDATE instead of INSERT
                if (EditingExisting)
                {
                    // Make the update command and update the data
                    using (SqlCommand updateCommand = new SqlCommand())
                    {
                        updateCommand.Connection = conn;
                        updateCommand.CommandType = CommandType.Text;
                        updateCommand.CommandText = "UPDATE Holds SET UserID = @NewUserID, BookID = @NewBookID, HoldDate = @NewHoldDate WHERE HoldID = @NewHoldID";
                        updateCommand.Parameters.AddWithValue("@NewHoldID", HoldIDSelector.Value);
                        updateCommand.Parameters.AddWithValue("@NewUserID", UserIDSelector.Value);
                        updateCommand.Parameters.AddWithValue("@NewBookID", BookIDSelector.Value);
                        updateCommand.Parameters.AddWithValue("@NewHoldDate", HoldDateTimePicker.Value);

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
                            MessageBox.Show("An error occurred when updating the hold in the database. The following error occurred:\r\n" + se.Message, "Error Updating Hold", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        insertCommand.CommandText = "INSERT INTO Holds (HoldID, UserID, BookID, HoldDate) VALUES (@NewHoldID, @NewUserID, @NewBookID, @NewHoldDate)";
                        insertCommand.Parameters.AddWithValue("@NewHoldID", HoldIDSelector.Value);
                        insertCommand.Parameters.AddWithValue("@NewUserID", UserIDSelector.Value);
                        insertCommand.Parameters.AddWithValue("@NewBookID", BookIDSelector.Value);
                        insertCommand.Parameters.AddWithValue("@NewHoldDate", HoldDateTimePicker.Value);

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
                            // If it's the violation of the primary key constraint, show the error that tells the user that a hold already exists
                            if (se.Number == 2627)
                            {
                                MessageBox.Show("A hold with this hold ID already exists in the database.", "Hold Already Exists", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                MessageBox.Show("An error occurred when inserting the hold into the database. The following error occurred:\r\n" + se.Message, "Error Inserting Hold", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            return;
                        }
                    }
                }
            }
        }

        private void SetGeneratedHoldID()
        {
            using (SqlConnection conn = new SqlConnection(SqlConnectionInfo.ConnectionString))
            {
                conn.Credential = SqlConnectionInfo.Credentials;
                try
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand("SELECT dbo.GenerateHoldID()", conn))
                    {
                        long generatedHoldID = (long)command.ExecuteScalar();
                        HoldIDSelector.Value = generatedHoldID;
                    }
                }
                catch (SqlException se)
                {
                    MessageBox.Show("An error occurred while generating the hold ID. The following error #" + se.Number + " occurred:\r\n" + se.Message, "Error Generating Hold ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void GenerateHoldIDButton_Click(object sender, EventArgs e)
        {
            SetGeneratedHoldID();
        }

        // Keyboard shortcuts
        private void HoldEditorForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                SaveButton.PerformClick();
            }
        }
    }
}
