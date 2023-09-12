using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace HemlockLibrarianStaffClient
{
    public partial class BranchManagerForm : Form
    {
        private bool searchActive = false;
        private bool firstTimeLoaded = false;
        private string searchString = "";

        public BranchManagerForm()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            HashSet<string> selectedBranchIDs = new HashSet<string>();

            // Remember which row was selected if refreshing
            if (firstTimeLoaded)
            {
                foreach (DataGridViewRow row in BranchDataGridView.SelectedRows)
                {
                    selectedBranchIDs.Add(row.Cells["Branch ID"].Value.ToString());
                }
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(SqlConnectionInfo.ConnectionString))
                {
                    // supply the credentials to the connection
                    conn.Credential = SqlConnectionInfo.Credentials;

                    // use parameterized query if searching
                    if (searchActive)
                    {
                        using (SqlCommand sqlCmd = new SqlCommand())
                        {
                            sqlCmd.Connection = conn;
                            sqlCmd.CommandType = CommandType.Text;
                            sqlCmd.CommandText = @"SELECT BranchID AS 'Branch ID', BranchName AS 'Branch Name', PhoneNumber AS 'Phone Number', Address, City, State, PostalCode AS 'Postal Code', Country FROM Branches WHERE (BranchID LIKE '%' + @Search + '%' OR BranchName LIKE '%' + @Search + '%' OR PhoneNumber LIKE '%' + @Search + '%' OR Address LIKE '%' + @Search + '%' OR City LIKE '%' + @Search + '%' OR State LIKE '%' + @Search + '%' OR PostalCode LIKE '%' + @Search + '%' OR Country LIKE '%' + @Search + '%')";
                            sqlCmd.Parameters.AddWithValue("@Search", "%" + searchString + "%");
                            SqlDataAdapter sqlDataAdap = new SqlDataAdapter(sqlCmd);

                            DataTable dtRecord = new DataTable();
                            sqlDataAdap.Fill(dtRecord);
                            BranchDataGridView.DataSource = dtRecord;
                        }
                    }
                    // default to selecting everything
                    else
                    {
                        using (SqlCommand sqlCmd = new SqlCommand())
                        {
                            sqlCmd.Connection = conn;
                            sqlCmd.CommandType = CommandType.Text;
                            sqlCmd.CommandText = @"SELECT BranchID AS 'Branch ID', BranchName AS 'Branch Name', PhoneNumber AS 'Phone Number', Address, City, State, PostalCode AS 'Postal Code', Country FROM Branches";
                            SqlDataAdapter sqlDataAdap = new SqlDataAdapter(sqlCmd);

                            DataTable dtRecord = new DataTable();
                            sqlDataAdap.Fill(dtRecord);
                            BranchDataGridView.DataSource = dtRecord;
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
            BranchDataGridView.ClearSelection();
            if (firstTimeLoaded)
            {
                foreach (DataGridViewRow row in BranchDataGridView.Rows)
                {
                    if (selectedBranchIDs.Contains(row.Cells["Branch ID"].Value.ToString()))
                    {
                        row.Selected = true;
                        if (!firstRowSelected)
                        {
                            BranchDataGridView.CurrentCell = row.Cells[0];
                            firstRowSelected = true;
                        }
                    }
                }
            }
            firstTimeLoaded = true;
        }

        private void BranchManagerForm_Load(object sender, EventArgs e)
        {
            // Enable double buffering to reduce the lag when scrolling the DataGridView
            ControlDoubleBuffering.SetDoubleBuffered(BranchDataGridView);

            // Load the data
            LoadData();
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            SearchBox.Text = searchString;
            LoadData();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            searchActive = true;
            SearchActiveLabel.Show();
            searchString = SearchBox.Text;
            LoadData();
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
            searchActive = false;
            SearchActiveLabel.Hide();
            searchString = "";
            SearchBox.Text = "";
            LoadData();
        }

        private void NewBranchButton_Click(object sender, EventArgs e)
        {
            BranchEditorForm bef = new BranchEditorForm();
            bef.ShowDialog();
            RefreshButton.PerformClick();
        }

        // Edit a branch when the row in the DataGridView is double-clicked
        private void EditSelectedRow()
        {
            if (BranchDataGridView.SelectedRows.Count == 0)
                return;

            long branchID = Convert.ToInt64(BranchDataGridView.SelectedRows[0].Cells["Branch ID"].Value);
            string branchName = BranchDataGridView.SelectedRows[0].Cells["Branch Name"].Value.ToString();
            string phoneNumber = BranchDataGridView.SelectedRows[0].Cells["Phone Number"].Value.ToString();
            string address = BranchDataGridView.SelectedRows[0].Cells["Address"].Value.ToString();
            string city = BranchDataGridView.SelectedRows[0].Cells["City"].Value.ToString();
            string state = BranchDataGridView.SelectedRows[0].Cells["State"].Value.ToString();
            string postalCode = BranchDataGridView.SelectedRows[0].Cells["Postal Code"].Value.ToString();
            string country = BranchDataGridView.SelectedRows[0].Cells["Country"].Value.ToString();

            BranchEditorForm bef = new BranchEditorForm(branchID, branchName, phoneNumber, address, city, state, postalCode, country);
            bef.ShowDialog();
            RefreshButton.PerformClick();
        }

        private void BranchDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            EditSelectedRow();
        }

        private void BranchDataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                EditSelectedRow();
            }
        }

        private void DeleteSelectedButton_Click(object sender, EventArgs e)
        {
            // Loop through the selected branches to gather a list of names that will be deleted
            if (BranchDataGridView.SelectedRows.Count == 0)
                return;

            StringBuilder branchListToDelete = new StringBuilder();
            foreach (DataGridViewRow row in BranchDataGridView.SelectedRows)
            {
                branchListToDelete.Append(row.Cells["Branch ID"].Value);
                branchListToDelete.Append(": ");
                branchListToDelete.Append(row.Cells["Branch Name"].Value);
                branchListToDelete.Append("\r\n");
            }

            // Ask the user if they are sure that they want to delete the selected rows
            DialogResult result = MessageBox.Show("Are you sure you want to delete the following branches?\r\n\r\n" + branchListToDelete.ToString() + "\r\nThis action cannot be undone!", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
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
                    foreach (DataGridViewRow row in BranchDataGridView.SelectedRows)
                    {
                        using (SqlCommand deleteCommand = new SqlCommand())
                        {
                            deleteCommand.Connection = conn;
                            deleteCommand.CommandType = CommandType.Text;
                            deleteCommand.CommandText = "DELETE FROM Branches WHERE BranchID = @DeletingBranchID;";
                            deleteCommand.Parameters.AddWithValue("@DeletingBranchID", row.Cells["Branch ID"].Value);

                            try
                            {
                                deleteCommand.ExecuteNonQuery();
                            }
                            catch (SqlException se)
                            {
                                if (se.Number == 547)
                                {
                                    // This means that the branch is associated with other data in the library and cannot be deleted.
                                    MessageBox.Show(row.Cells["Branch ID"].Value + ": " + row.Cells["Branch Name"].Value + "\r\nThis branch cannot be deleted because it is associated with other data in the library. Please remove all associated data before deleting the branch.", "Branch Cannot Be Deleted", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    MessageBox.Show("An error occurred when deleting the branch from the database. The following error #" + se.Number + " occurred:\r\n" + se.Message, "Error Deleting Branch", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void BranchManagerForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.N)
            {
                NewBranchButton.PerformClick();
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
