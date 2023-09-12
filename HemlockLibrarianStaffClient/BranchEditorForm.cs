using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace HemlockLibrarianStaffClient
{
    public partial class BranchEditorForm : Form
    {
        public bool EditingExisting = false;

        // Makes an empty form for creating a new branch
        public BranchEditorForm()
        {
            InitializeComponent();
        }

        // Makes a filled-in form for editing an existing branch
        public BranchEditorForm(long curBranchID, string curBranchName, string curPhoneNumber, string curAddress, string curCity, string curState, string curPostalCode, string curCountry)
        {
            EditingExisting = true;
            InitializeComponent();

            this.Text = "Edit Branch";

            // Disable editing in the Branch ID text box and grey it out
            BranchIDSelector.Enabled = false;
            GenerateBranchIDButton.Enabled = false;

            // Fill in all the information
            TitleLabel.Text = "Edit Branch";
            BranchIDSelector.Value = curBranchID;
            BranchNameTextBox.Text = curBranchName;
            PhoneNumberTextBox.Text = curPhoneNumber;
            AddressTextBox.Text = curAddress;
            CityTextBox.Text = curCity;
            StateTextBox.Text = curState;
            PostalCodeTextBox.Text = curPostalCode;
            CountryTextBox.Text = curCountry;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            // Check if the Branch ID box is empty (it shouldn't be) and show an error message if it is
            if (BranchIDSelector.Value == 0)
            {
                MessageBox.Show("You must enter a Branch ID.", "Branch ID Missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection conn = new SqlConnection(SqlConnectionInfo.ConnectionString))
            {
                conn.Credential = SqlConnectionInfo.Credentials;

                // If we are editing an existing branch, use UPDATE instead of INSERT
                if (EditingExisting)
                {
                    // Make the update command and update the data
                    using (SqlCommand updateCommand = new SqlCommand())
                    {
                        updateCommand.Connection = conn;
                        updateCommand.CommandType = CommandType.Text;
                        updateCommand.CommandText = "UPDATE Branches SET BranchName = @NewBranchName, PhoneNumber = @NewPhoneNumber, Address = @NewAddress, City = @NewCity, State = @NewState, PostalCode = @NewPostalCode, Country = @NewCountry WHERE BranchID = @NewBranchID";
                        updateCommand.Parameters.AddWithValue("@NewBranchID", BranchIDSelector.Value);
                        updateCommand.Parameters.AddWithValue("@NewBranchName", BranchNameTextBox.Text);
                        updateCommand.Parameters.AddWithValue("@NewPhoneNumber", PhoneNumberTextBox.Text);
                        updateCommand.Parameters.AddWithValue("@NewAddress", AddressTextBox.Text);
                        updateCommand.Parameters.AddWithValue("@NewCity", CityTextBox.Text);
                        updateCommand.Parameters.AddWithValue("@NewState", StateTextBox.Text);
                        updateCommand.Parameters.AddWithValue("@NewPostalCode", PostalCodeTextBox.Text);
                        updateCommand.Parameters.AddWithValue("@NewCountry", CountryTextBox.Text);

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
                            MessageBox.Show("An error occurred when updating the branch in the database. The following error occurred:\r\n" + se.Message, "Error Updating Branch", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        insertCommand.CommandText = "INSERT INTO Branches (BranchID, BranchName, PhoneNumber, Address, City, State, PostalCode, Country) VALUES (@NewBranchID, @NewBranchName, @NewPhoneNumber, @NewAddress, @NewCity, @NewState, @NewPostalCode, @NewCountry)";
                        insertCommand.Parameters.AddWithValue("@NewBranchID", BranchIDSelector.Value);
                        insertCommand.Parameters.AddWithValue("@NewBranchName", BranchNameTextBox.Text);
                        insertCommand.Parameters.AddWithValue("@NewPhoneNumber", PhoneNumberTextBox.Text);
                        insertCommand.Parameters.AddWithValue("@NewAddress", AddressTextBox.Text);
                        insertCommand.Parameters.AddWithValue("@NewCity", CityTextBox.Text);
                        insertCommand.Parameters.AddWithValue("@NewState", StateTextBox.Text);
                        insertCommand.Parameters.AddWithValue("@NewPostalCode", PostalCodeTextBox.Text);
                        insertCommand.Parameters.AddWithValue("@NewCountry", CountryTextBox.Text);

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
                            // If it's the violation of the primary key constraint, show the error that tells the user that a branch already exists
                            if (se.Number == 2627)
                            {
                                MessageBox.Show("A branch with this branch ID already exists in the database.", "Branch Already Exists", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                MessageBox.Show("An error occurred when inserting the branch into the database. The following error occurred:\r\n" + se.Message, "Error Inserting Branch", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            return;
                        }
                    }
                }
            }
        }

        private void SetGeneratedBranchID()
        {
            using (SqlConnection conn = new SqlConnection(SqlConnectionInfo.ConnectionString))
            {
                conn.Credential = SqlConnectionInfo.Credentials;
                try
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand("SELECT dbo.GenerateBranchID()", conn))
                    {
                        long generatedBranchID = (long)command.ExecuteScalar();
                        BranchIDSelector.Value = generatedBranchID;
                    }
                }
                catch (SqlException se)
                {
                    MessageBox.Show("An error occurred while generating the branch ID. The following error #" + se.Number + " occurred:\r\n" + se.Message, "Error Generating Branch ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void GenerateBranchIDButton_Click(object sender, EventArgs e)
        {
            SetGeneratedBranchID();
        }

        // Keyboard shortcuts
        private void BranchEditorForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                SaveButton.PerformClick();
            }
        }
    }
}
