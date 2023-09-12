// Note: This code is based on https://github.com/NorthTorontoChristianSchool/NTCS-Attendance-Staff-Client/blob/main/ManageStudentsForm.cs
// (taken from my old high school project)

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace HemlockLibrarianStaffClient
{
    public partial class ItemManagerForm : Form
    {
        private bool SearchActive = false;
        private bool FirstTimeLoaded = false;
        private string SearchString = "";

        public ItemManagerForm()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            HashSet<string> selectedItemIDs = new HashSet<string>();
            // Remember which row was selected if refreshing
            if (FirstTimeLoaded)
            {
                foreach (DataGridViewRow row in ItemDataGridView.SelectedRows)
                {
                    selectedItemIDs.Add(row.Cells["Item ID"].ToString());
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
                            sqlCmd.CommandText = @"SELECT i.ItemID AS 'Item ID',i.BookID AS 'Book ID',b.Title AS 'Book Title',i.BranchID AS 'Branch ID',br.BranchName AS 'Branch Name',CASE i.CheckoutStatus WHEN 0 THEN 'In Library' WHEN 1 THEN 'On Loan' WHEN 2 THEN 'In Transit' WHEN 3 THEN 'On Hold Shelf' WHEN 4 THEN 'Missing' ELSE 'Unknown' END AS 'Checkout Status',i.CheckoutStatus AS 'Status ID',i.CurrentBranchID AS 'Current Branch ID',currBranch.BranchName AS 'Current Branch Name' FROM Items i LEFT JOIN Books b ON i.BookID = b.BookID LEFT JOIN Branches br ON i.BranchID = br.BranchID LEFT JOIN Branches currBranch ON i.CurrentBranchID = currBranch.BranchID WHERE (i.ItemID LIKE '%' + @Search + '%' OR i.BookID LIKE '%' + @Search + '%' OR i.BranchID LIKE '%' + @Search + '%' OR b.Title LIKE '%' + @Search + '%') ORDER BY b.Title;";
                            sqlCmd.Parameters.AddWithValue("@Search", "%" + SearchString + "%");
                            SqlDataAdapter sqlDataAdap = new SqlDataAdapter(sqlCmd);

                            DataTable dtRecord = new DataTable();
                            sqlDataAdap.Fill(dtRecord);
                            ItemDataGridView.DataSource = dtRecord;
                        }
                    }
                    // default to selecting everything
                    else
                    {
                        using (SqlCommand sqlCmd = new SqlCommand())
                        {
                            sqlCmd.Connection = conn;
                            sqlCmd.CommandType = CommandType.Text;
                            sqlCmd.CommandText = @"SELECT i.ItemID AS 'Item ID',i.BookID AS 'Book ID',b.Title AS 'Book Title',i.BranchID AS 'Branch ID',br.BranchName AS 'Branch Name',CASE i.CheckoutStatus WHEN 0 THEN 'In Library' WHEN 1 THEN 'On Loan' WHEN 2 THEN 'In Transit' WHEN 3 THEN 'On Hold Shelf' WHEN 4 THEN 'Missing' ELSE 'Unknown' END AS 'Checkout Status',i.CheckoutStatus AS 'Status ID',i.CurrentBranchID AS 'Current Branch ID',currBranch.BranchName AS 'Current Branch Name' FROM Items i LEFT JOIN Books b ON i.BookID = b.BookID LEFT JOIN Branches br ON i.BranchID = br.BranchID LEFT JOIN Branches currBranch ON i.CurrentBranchID = currBranch.BranchID ORDER BY b.Title;";
                            SqlDataAdapter sqlDataAdap = new SqlDataAdapter(sqlCmd);

                            DataTable dtRecord = new DataTable();
                            sqlDataAdap.Fill(dtRecord);
                            ItemDataGridView.DataSource = dtRecord;
                        }
                    }

                    // Hide the 'Status ID' column
                    ItemDataGridView.Columns["Status ID"].Visible = false;
                }
            }
            catch (SqlException ex)
            {
                SqlErrorDialog.ShowRuntimeConnectionErrorMessage(ex.Message);
            }

            // Re-select the previously selected rows
            bool firstRowSelected = false;
            ItemDataGridView.ClearSelection();
            if (FirstTimeLoaded)
            {
                foreach (DataGridViewRow row in ItemDataGridView.Rows)
                {
                    if (selectedItemIDs.Contains(row.Cells["Item ID"].ToString()))
                    {
                        row.Selected = true;
                        if (!firstRowSelected)
                        {
                            ItemDataGridView.CurrentCell = row.Cells[0];
                            firstRowSelected = true;
                        }
                    }
                }
            }
            FirstTimeLoaded = true;
        }

        private void BookManagerForm_Load(object sender, EventArgs e)
        {
            // Enable double buffering to reduce the lag when scrolling the DataGridView
            ControlDoubleBuffering.SetDoubleBuffered(ItemDataGridView);

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

        private void NewItemButton_Click(object sender, EventArgs e)
        {
            ItemEditorForm ief = new ItemEditorForm();
            ief.ShowDialog();
            RefreshButton.PerformClick();
        }

        // Edit an item when the row in the DataGridView is double-clicked
        private void EditSelectedRow()
        {
            if (ItemDataGridView.SelectedRows.Count == 0)
                return;

            long itemID = Convert.ToInt64(ItemDataGridView.SelectedRows[0].Cells["Item ID"].Value);
            long bookID = Convert.ToInt64(ItemDataGridView.SelectedRows[0].Cells["Book ID"].Value);
            long branchID = Convert.ToInt64(ItemDataGridView.SelectedRows[0].Cells["Branch ID"].Value);
            int checkoutStatus = Convert.ToInt32(ItemDataGridView.SelectedRows[0].Cells["Status ID"].Value);
            long currentBranchID = Convert.ToInt64(ItemDataGridView.SelectedRows[0].Cells["Current Branch ID"].Value);

            ItemEditorForm ief = new ItemEditorForm(itemID, bookID, branchID, checkoutStatus, currentBranchID);
            ief.ShowDialog();
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
            if (ItemDataGridView.SelectedRows.Count == 0)
                return;
            StringBuilder userListOfNamesToDelete = new StringBuilder();
            foreach (DataGridViewRow row in ItemDataGridView.SelectedRows)
            {
                userListOfNamesToDelete.Append(row.Cells["Item ID"].Value);
                userListOfNamesToDelete.Append(": ");
                userListOfNamesToDelete.Append(row.Cells["Book ID"].Value);
                userListOfNamesToDelete.Append(", ");
                userListOfNamesToDelete.Append(row.Cells["Branch ID"].Value);
                userListOfNamesToDelete.Append("\r\n");
            }

            // Ask the user if they are sure that they want to delete the selected rows
            DialogResult result = MessageBox.Show("Are you sure you want to delete the following items?\r\n\r\n" + userListOfNamesToDelete.ToString() + "\r\nThis action cannot be undone!", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
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
                    foreach (DataGridViewRow row in ItemDataGridView.SelectedRows)
                    {
                        using (SqlCommand deleteCommand = new SqlCommand())
                        {
                            deleteCommand.Connection = conn;
                            deleteCommand.CommandType = CommandType.Text;
                            deleteCommand.CommandText = "DELETE FROM Items WHERE ItemID = @DeletingItemID;";
                            deleteCommand.Parameters.AddWithValue("@DeletingItemID", row.Cells["Item ID"].Value);

                            try
                            {
                                deleteCommand.ExecuteNonQuery();
                            }
                            catch (SqlException se)
                            {
                                if (se.Number == 547)
                                {
                                    // This means that the item is associated with an action in the library and cannot be deleted.
                                    MessageBox.Show(row.Cells["Item ID"].Value + ": " + row.Cells["Book ID"].Value + ", " + row.Cells["Branch ID"].Value + "\r\nThis item cannot be deleted because it is associated with an action in the library. Please remove all associated actions before deleting the item.", "Item Cannot Be Deleted", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    MessageBox.Show("An error occured when deleting the item from the database. The following error #" + se.Number + " occurred:\r\n" + se.Message, "Error Deleting Item", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void ManageItemsForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.N)
            {
                NewItemButton.PerformClick();
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
    }
}
