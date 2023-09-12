using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace HemlockLibrarianStaffClient
{
    public partial class ItemEditorForm : Form
    {
        public bool EditingExisting = false;

        // Makes an empty form for making a new item
        public ItemEditorForm()
        {
            InitializeComponent();
            CheckoutStatusComboBox.SelectedIndex = 0;
            SetGeneratedItemID();
        }

        // Makes a filled-in form for editing an existing item
        public ItemEditorForm(long itemID, long bookID, long branchID, int checkoutStatus, long currentBranchID)
        {
            EditingExisting = true;
            InitializeComponent();

            this.Text = "Edit Item";

            // Disable editing in the Item ID text box and grey it out
            ItemIDSelector.ReadOnly = true;
            ItemIDSelector.BackColor = SystemColors.Control;
            GenerateItemIDButton.Enabled = false;

            // Fill in all the information
            TitleLabel.Text = "Edit Item";
            ItemIDSelector.Value = itemID;
            BookIDSelector.Value = bookID;
            BranchIDSelector.Value = branchID;
            CheckoutStatusComboBox.SelectedIndex = checkoutStatus;
            CurrentBranchIDSelector.Value = currentBranchID;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            // Check if the item ID box is empty (it shouldn't be) and show an error message if it is
            if (ItemIDSelector.Value == 0)
            {
                MessageBox.Show("You must enter an Item ID.", "Item ID Missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection conn = new SqlConnection(SqlConnectionInfo.ConnectionString))
            {
                conn.Credential = SqlConnectionInfo.Credentials;

                // If we are editing an existing item, use UPDATE instead of INSERT
                if (EditingExisting)
                {
                    // Make the update command and update the data
                    using (SqlCommand updateCommand = new SqlCommand())
                    {
                        updateCommand.Connection = conn;
                        updateCommand.CommandType = CommandType.Text;
                        updateCommand.CommandText = "UPDATE Items SET BookID = @NewBookID, BranchID = @NewBranchID, CheckoutStatus = @NewCheckoutStatus, CurrentBranchID = @NewCurrentBranchID WHERE ItemID = @NewItemID";
                        updateCommand.Parameters.AddWithValue("@NewItemID", ItemIDSelector.Value);
                        updateCommand.Parameters.AddWithValue("@NewBookID", BookIDSelector.Value);
                        updateCommand.Parameters.AddWithValue("@NewBranchID", BranchIDSelector.Value);
                        updateCommand.Parameters.AddWithValue("@NewCheckoutStatus", CheckoutStatusComboBox.SelectedIndex);
                        updateCommand.Parameters.AddWithValue("@NewCurrentBranchID", CurrentBranchIDSelector.Value);

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
                            MessageBox.Show("An error occured when updating the item into the database. The following error occured:\r\n" + se.Message, "Error Updating Item", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        insertCommand.CommandText = "INSERT INTO Items (ItemID, BookID, BranchID, CheckoutStatus, CurrentBranchID) VALUES (@NewItemID, @NewBookID, @NewBranchID, @NewCheckoutStatus, @NewCurrentBranchID)";
                        insertCommand.Parameters.AddWithValue("@NewItemID", ItemIDSelector.Value);
                        insertCommand.Parameters.AddWithValue("@NewBookID", BookIDSelector.Value);
                        insertCommand.Parameters.AddWithValue("@NewBranchID", BranchIDSelector.Value);
                        insertCommand.Parameters.AddWithValue("@NewCheckoutStatus", CheckoutStatusComboBox.SelectedIndex);
                        insertCommand.Parameters.AddWithValue("@NewCurrentBranchID", CurrentBranchIDSelector.Value);

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
                            // If it's the violation of the primary key constraint, show the error that tells the user that an item already exists
                            if (se.Number == 2627)
                            {
                                MessageBox.Show("An item with this item ID already exists in the database.", "Item Already Exists", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                MessageBox.Show("An error occured when inserting the item into the database. The following error occured:\r\n" + se.Message, "Error Inserting Item", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            return;
                        }
                    }
                }
            }
        }

        // Keyboard shortcuts
        private void ItemEditorForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                SaveButton.PerformClick();
            }
        }

        private void SetGeneratedItemID()
        {
            using (SqlConnection conn = new SqlConnection(SqlConnectionInfo.ConnectionString))
            {
                conn.Credential = SqlConnectionInfo.Credentials;
                try
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand("SELECT dbo.GenerateItemID()", conn))
                    {
                        long generatedItemID = (long)command.ExecuteScalar();
                        ItemIDSelector.Value = generatedItemID;
                    }
                }
                catch (SqlException se)
                {
                    MessageBox.Show("An error occurred while generating the book ID. The following error #" + se.Number + " occurred:\r\n" + se.Message, "Error Generating Book ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void GenerateItemIDButton_Click(object sender, EventArgs e)
        {
            SetGeneratedItemID();
        }
    }
}
