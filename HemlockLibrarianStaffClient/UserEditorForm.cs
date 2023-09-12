using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace HemlockLibrarianStaffClient
{
    public partial class UserEditorForm : Form
    {
        public bool EditingExisting = false;

        // Makes an empty form for creating a new user
        public UserEditorForm()
        {
            InitializeComponent();
        }

        // Makes a filled-in form for editing an existing user
        public UserEditorForm(long curUserID, string curUserName, string curEmail, string curPhone, string curPIN, decimal curBalance)
        {
            EditingExisting = true;
            InitializeComponent();

            this.Text = "Edit User";

            // Disable editing in the User ID text box and grey it out
            UserIDSelector.Enabled = false;
            GenerateUserIDButton.Enabled = false;

            // Fill in all the information
            TitleLabel.Text = "Edit User";
            UserIDSelector.Value = curUserID;
            UserNameTextBox.Text = curUserName;
            EmailTextBox.Text = curEmail;
            PhoneTextBox.Text = curPhone;
            PinTextBox.Text = curPIN;
            BalanceSelector.Value = curBalance;
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

                // If we are editing an existing user, use UPDATE instead of INSERT
                if (EditingExisting)
                {
                    // Make the update command and update the data
                    using (SqlCommand updateCommand = new SqlCommand())
                    {
                        updateCommand.Connection = conn;
                        updateCommand.CommandType = CommandType.Text;
                        updateCommand.CommandText = "UPDATE Users SET UserName = @NewUserName, Email = @NewEmail, Phone = @NewPhone, PIN = @NewPIN, Balance = @NewBalance WHERE UserID = @UserID";
                        updateCommand.Parameters.AddWithValue("@UserID", UserIDSelector.Value);
                        updateCommand.Parameters.AddWithValue("@NewUserName", UserNameTextBox.Text);
                        updateCommand.Parameters.AddWithValue("@NewEmail", EmailTextBox.Text);
                        updateCommand.Parameters.AddWithValue("@NewPhone", PhoneTextBox.Text);
                        updateCommand.Parameters.AddWithValue("@NewPIN", PinTextBox.Text);
                        updateCommand.Parameters.AddWithValue("@NewBalance", BalanceSelector.Value);

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
                            MessageBox.Show("An error occurred when updating the user in the database. The following error occurred:\r\n" + se.Message, "Error Updating User", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        insertCommand.CommandText = "INSERT INTO Users (UserID, UserName, Email, Phone, PIN, Balance) VALUES (@UserID, @NewUserName, @NewEmail, @NewPhone, @NewPIN, @NewBalance)";
                        insertCommand.Parameters.AddWithValue("@UserID", UserIDSelector.Value);
                        insertCommand.Parameters.AddWithValue("@NewUserName", UserNameTextBox.Text);
                        insertCommand.Parameters.AddWithValue("@NewEmail", EmailTextBox.Text);
                        insertCommand.Parameters.AddWithValue("@NewPhone", PhoneTextBox.Text);
                        insertCommand.Parameters.AddWithValue("@NewPIN", PinTextBox.Text);
                        insertCommand.Parameters.AddWithValue("@NewBalance", BalanceSelector.Value);

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
                            // If it's the violation of the primary key constraint, show the error that tells the user that a user already exists
                            if (se.Number == 2627)
                            {
                                MessageBox.Show("A user with this User ID already exists in the database.", "User Already Exists", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                MessageBox.Show("An error occurred when inserting the user into the database. The following error occurred:\r\n" + se.Message, "Error Inserting User", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            return;
                        }
                    }
                }
            }
        }

        // Keyboard shortcuts
        private void UserEditorForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                SaveButton.PerformClick();
            }
        }

        private void GenerateUserIDButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(SqlConnectionInfo.ConnectionString))
            {
                conn.Credential = SqlConnectionInfo.Credentials;
                try
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand("SELECT dbo.GenerateUserID()", conn))
                    {
                        long generatedUserID = (long)command.ExecuteScalar();
                        UserIDSelector.Value = generatedUserID;
                    }
                }
                catch (SqlException se)
                {
                    MessageBox.Show("An error occurred while generating the user ID. The following error #" + se.Number + " occurred:\r\n" + se.Message, "Error Generating User ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
