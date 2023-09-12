using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace HemlockLibrarianStaffClient
{
    public partial class UserManagerForm : Form
    {
        private bool SearchActive = false;
        private bool FirstTimeLoaded = false;
        private string SearchString = "";

        public UserManagerForm()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            HashSet<long> selectedUserIDs = new HashSet<long>();
            // Remember which row was selected if refreshing
            if (FirstTimeLoaded)
            {
                foreach (DataGridViewRow row in UserDataGridView.SelectedRows)
                {
                    selectedUserIDs.Add(Convert.ToInt64(row.Cells["User ID"].Value));
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
                            sqlCmd.CommandText = "SELECT UserID AS 'User ID', UserName, Email, Phone, PIN, Balance FROM Users WHERE (UserID LIKE '%' + @Search + '%' OR UserName LIKE '%' + @Search + '%' OR Email LIKE '%' + @Search + '%' OR Phone LIKE '%' + @Search + '%' OR PIN LIKE '%' + @Search + '%') ORDER BY UserName;";
                            sqlCmd.Parameters.AddWithValue("@Search", "%" + SearchString + "%");
                            SqlDataAdapter sqlDataAdap = new SqlDataAdapter(sqlCmd);

                            DataTable dtRecord = new DataTable();
                            sqlDataAdap.Fill(dtRecord);
                            UserDataGridView.DataSource = dtRecord;
                        }
                    }
                    // default to selecting everything
                    else
                    {
                        using (SqlCommand sqlCmd = new SqlCommand())
                        {
                            sqlCmd.Connection = conn;
                            sqlCmd.CommandType = CommandType.Text;
                            sqlCmd.CommandText = "SELECT UserID AS 'User ID', UserName, Email, Phone, PIN, Balance FROM Users ORDER BY UserName;";
                            SqlDataAdapter sqlDataAdap = new SqlDataAdapter(sqlCmd);

                            DataTable dtRecord = new DataTable();
                            sqlDataAdap.Fill(dtRecord);
                            UserDataGridView.DataSource = dtRecord;
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
            UserDataGridView.ClearSelection();
            if (FirstTimeLoaded)
            {
                foreach (DataGridViewRow row in UserDataGridView.Rows)
                {
                    if (selectedUserIDs.Contains(Convert.ToInt64(row.Cells["User ID"].Value)))
                    {
                        row.Selected = true;
                        if (!firstRowSelected)
                        {
                            UserDataGridView.CurrentCell = row.Cells[0];
                            firstRowSelected = true;
                        }
                    }
                }
            }
            UserDataGridView.Columns["Balance"].DefaultCellStyle.Format = "0.00#########";
            FirstTimeLoaded = true;
        }

        private void UserManagerForm_Load(object sender, EventArgs e)
        {
            // Enable double buffering to reduce the lag when scrolling the DataGridView
            ControlDoubleBuffering.SetDoubleBuffered(UserDataGridView);

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

        private void NewUserButton_Click(object sender, EventArgs e)
        {
            UserEditorForm uef = new UserEditorForm();
            uef.ShowDialog();
            RefreshButton.PerformClick();
        }

        // Edit a user when the row in the DataGridView is double-clicked
        private void EditSelectedRow()
        {
            if (UserDataGridView.SelectedRows.Count == 0)
                return;

            long userID = Convert.ToInt64(UserDataGridView.SelectedRows[0].Cells["User ID"].Value);
            string userName = UserDataGridView.SelectedRows[0].Cells["UserName"].Value.ToString();
            string email = UserDataGridView.SelectedRows[0].Cells["Email"].Value.ToString();
            string phone = UserDataGridView.SelectedRows[0].Cells["Phone"].Value.ToString();
            string pin = UserDataGridView.SelectedRows[0].Cells["PIN"].Value.ToString();
            decimal balance = Convert.ToDecimal(UserDataGridView.SelectedRows[0].Cells["Balance"].Value);

            UserEditorForm uef = new UserEditorForm(userID, userName, email, phone, pin, balance);
            uef.ShowDialog();
            RefreshButton.PerformClick();
        }

        private void UserDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            this.EditSelectedRow();
        }

        private void UserDataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                this.EditSelectedRow();
            }
        }

        private void DeleteSelectedButton_Click(object sender, EventArgs e)
        {
            // Loop through the selected users to gather a list of users that will be deleted
            if (UserDataGridView.SelectedRows.Count == 0)
                return;
            StringBuilder userListOfNamesToDelete = new StringBuilder();
            foreach (DataGridViewRow row in UserDataGridView.SelectedRows)
            {
                userListOfNamesToDelete.Append(row.Cells["User ID"].Value);
                userListOfNamesToDelete.Append(": ");
                userListOfNamesToDelete.Append(row.Cells["UserName"].Value);
                userListOfNamesToDelete.Append("\r\n");
            }

            // Ask the user if they are sure that they want to delete the selected rows
            DialogResult result = MessageBox.Show("Are you sure you want to delete the following users?\r\n\r\n" + userListOfNamesToDelete.ToString() + "\r\nThis action cannot be undone!", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
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
                    foreach (DataGridViewRow row in UserDataGridView.SelectedRows)
                    {
                        using (SqlCommand deleteCommand = new SqlCommand())
                        {
                            deleteCommand.Connection = conn;
                            deleteCommand.CommandType = CommandType.Text;
                            deleteCommand.CommandText = "DELETE FROM Users WHERE UserID = @DeletingUserID;";
                            deleteCommand.Parameters.AddWithValue("@DeletingUserID", row.Cells["User ID"].Value);

                            try
                            {
                                deleteCommand.ExecuteNonQuery();
                            }
                            catch (SqlException se)
                            {
                                MessageBox.Show("An error occurred when deleting the user from the database. The following error #" + se.Number + " occurred:\r\n" + se.Message, "Error Deleting User", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }
                }
            }
            RefreshButton.PerformClick();
        }

        // Keyboard shortcuts
        private void UserManagerForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.N)
            {
                NewUserButton.PerformClick();
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
