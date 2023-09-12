using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace HemlockLibrarianStaffClient
{
    public partial class HoldManagerForm : Form
    {
        private bool SearchActive = false;
        private bool FirstTimeLoaded = false;
        private string SearchString = "";

        public HoldManagerForm()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            HashSet<string> selectedHoldIDs = new HashSet<string>();
            // Remember which row was selected if refreshing
            if (FirstTimeLoaded)
            {
                foreach (DataGridViewRow row in BookDataGridView.SelectedRows)
                {
                    selectedHoldIDs.Add(row.Cells["Hold ID"].ToString());
                }
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(SqlConnectionInfo.ConnectionString))
                {
                    // Supply the credentials to the connection
                    conn.Credential = SqlConnectionInfo.Credentials;

                    // Use parameterized query if searching
                    if (SearchActive)
                    {
                        using (SqlCommand sqlCmd = new SqlCommand())
                        {
                            sqlCmd.Connection = conn;
                            sqlCmd.CommandType = CommandType.Text;
                            sqlCmd.CommandText = "SELECT Holds.HoldID AS 'Hold ID', Holds.UserID AS 'User ID', Holds.BookID AS 'Book ID', Books.Title AS 'Book Title', Holds.HoldDate FROM Holds JOIN Books ON Holds.BookID = Books.BookID WHERE (Holds.HoldID LIKE '%' + @Search + '%' OR Holds.UserID LIKE '%' + @Search + '%' OR Holds.BookID LIKE '%' + @Search + '%') ORDER BY Holds.HoldID;";
                            SqlDataAdapter sqlDataAdap = new SqlDataAdapter(sqlCmd);
                            DataTable dtRecord = new DataTable();
                            sqlDataAdap.Fill(dtRecord);
                            BookDataGridView.DataSource = dtRecord;
                        }
                    }
                    // Default to selecting everything
                    else
                    {
                        using (SqlCommand sqlCmd = new SqlCommand())
                        {
                            sqlCmd.Connection = conn;
                            sqlCmd.CommandType = CommandType.Text;
                            sqlCmd.CommandText = "SELECT Holds.HoldID AS 'Hold ID', Holds.UserID AS 'User ID', Holds.BookID AS 'Book ID', Books.Title AS 'Book Title', Holds.HoldDate FROM Holds JOIN Books ON Holds.BookID = Books.BookID ORDER BY Holds.HoldID;";
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
                    if (selectedHoldIDs.Contains(row.Cells["Hold ID"].ToString()))
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
            FirstTimeLoaded = true;
        }

        private void HoldManagerForm_Load(object sender, EventArgs e)
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

        private void NewHoldButton_Click(object sender, EventArgs e)
        {
            HoldEditorForm hef = new HoldEditorForm();
            hef.ShowDialog();
            RefreshButton.PerformClick();
        }

        // Edit a hold when the row in the DataGridView is double-clicked
        private void EditSelectedRow()
        {
            if (BookDataGridView.SelectedRows.Count == 0)
                return;

            long holdID = Convert.ToInt64(BookDataGridView.SelectedRows[0].Cells["Hold ID"].Value);
            long userID = Convert.ToInt64(BookDataGridView.SelectedRows[0].Cells["User ID"].Value);
            long bookID = Convert.ToInt64(BookDataGridView.SelectedRows[0].Cells["Book ID"].Value);
            DateTime holdDate = Convert.ToDateTime(BookDataGridView.SelectedRows[0].Cells["HoldDate"].Value);

            HoldEditorForm hef = new HoldEditorForm(holdID, userID, bookID, holdDate);
            hef.ShowDialog();
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
            // Ask the user if they are sure that they want to delete the selected rows
            DialogResult result = MessageBox.Show("Are you sure you want to delete the selected holds?\r\nThis action cannot be undone!", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
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
                            deleteCommand.CommandText = "DELETE FROM Holds WHERE HoldID = @DeletingHoldID;";
                            deleteCommand.Parameters.AddWithValue("@DeletingHoldID", row.Cells["Hold ID"].Value);

                            try
                            {
                                deleteCommand.ExecuteNonQuery();
                            }
                            catch (SqlException se)
                            {
                                MessageBox.Show("An error occurred when deleting the hold from the database. The following error #" + se.Number + " occurred:\r\n" + se.Message, "Error Deleting Hold", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }
                }

            }
            RefreshButton.PerformClick();
        }

        // Keyboard shortcuts
        private void HoldManagerForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.N)
            {
                NewHoldButton.PerformClick();
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
