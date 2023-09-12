// Note: This code is based on https://github.com/NorthTorontoChristianSchool/NTCS-Attendance-Staff-Client/blob/main/ManageStudentsForm.cs
// (taken from my old high school project)

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HemlockLibrarianStaffClient
{
    public partial class TransactionManagerForm : Form
    {
        private bool SearchActive = false;
        private bool FirstTimeLoaded = false;
        private string SearchString = "";

        public TransactionManagerForm()
        {
            InitializeComponent();
        }

        // Upsell the HemlockPOS to the user (sold separately) which allows them to make or manage transactions.
        // You can't edit without purchasing the HemlockPOS software, so upsell the HemlockPOS software to the user
        // This allows a more dedicated interface and also increases revenue for me :)
        private void UpsellPOS()
        {
            MessageBox.Show("To make or manage transactions, please use the HemlockPOS software (sold separately).", "HemlockPOS Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LoadData()
        {
            HashSet<string> selectedTransactionIDs = new HashSet<string>();
            if (FirstTimeLoaded)
            {
                foreach (DataGridViewRow row in TransactionDataGridView.SelectedRows)
                {
                    selectedTransactionIDs.Add(row.Cells["Transaction ID"].ToString());
                }
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(SqlConnectionInfo.ConnectionString))
                {
                    conn.Credential = SqlConnectionInfo.Credentials;

                    if (SearchActive)
                    {
                        using (SqlCommand sqlCmd = new SqlCommand())
                        {
                            sqlCmd.Connection = conn;
                            sqlCmd.CommandType = CommandType.Text;
                            sqlCmd.CommandText = "SELECT Transactions.TransactionID AS 'Transaction ID', Users.UserID AS 'User ID', Items.ItemID AS 'Item ID', Books.Title AS 'Book Title', Transactions.CheckoutDate AS 'Checkout Date', Transactions.ReturnDate AS 'Return Date', Transactions.Fine FROM Transactions INNER JOIN Users ON Transactions.UserID = Users.UserID INNER JOIN Items ON Transactions.ItemID = Items.ItemID INNER JOIN Books ON Items.BookID = Books.BookID WHERE (Transactions.TransactionID LIKE '%' + @Search + '%' OR Users.UserID LIKE '%' + @Search + '%' OR Items.ItemID LIKE '%' + @Search + '%' OR Books.Title LIKE '%' + @Search + '%') ORDER BY Transactions.TransactionID;";
                            sqlCmd.Parameters.AddWithValue("@Search", "%" + SearchString + "%");
                            SqlDataAdapter sqlDataAdap = new SqlDataAdapter(sqlCmd);

                            DataTable dtRecord = new DataTable();
                            sqlDataAdap.Fill(dtRecord);
                            TransactionDataGridView.DataSource = dtRecord;
                        }
                    }
                    else
                    {
                        using (SqlCommand sqlCmd = new SqlCommand())
                        {
                            sqlCmd.Connection = conn;
                            sqlCmd.CommandType = CommandType.Text;
                            sqlCmd.CommandText = "SELECT Transactions.TransactionID AS 'Transaction ID', Users.UserID AS 'User ID', Items.ItemID AS 'Item ID', Books.Title AS 'Book Title', Transactions.CheckoutDate AS 'Checkout Date', Transactions.ReturnDate AS 'Return Date', Transactions.Fine FROM Transactions INNER JOIN Users ON Transactions.UserID = Users.UserID INNER JOIN Items ON Transactions.ItemID = Items.ItemID INNER JOIN Books ON Items.BookID = Books.BookID ORDER BY Transactions.TransactionID;";
                            SqlDataAdapter sqlDataAdap = new SqlDataAdapter(sqlCmd);

                            DataTable dtRecord = new DataTable();
                            sqlDataAdap.Fill(dtRecord);
                            TransactionDataGridView.DataSource = dtRecord;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                SqlErrorDialog.ShowRuntimeConnectionErrorMessage(ex.Message);
            }

            bool firstRowSelected = false;
            TransactionDataGridView.ClearSelection();
            if (FirstTimeLoaded)
            {
                foreach (DataGridViewRow row in TransactionDataGridView.Rows)
                {
                    if (selectedTransactionIDs.Contains(row.Cells["Transaction ID"].ToString()))
                    {
                        row.Selected = true;
                        if (!firstRowSelected)
                        {
                            TransactionDataGridView.CurrentCell = row.Cells[0];
                            firstRowSelected = true;
                        }
                    }
                }
            }
            FirstTimeLoaded = true;
            TransactionDataGridView.Columns["Fine"].DefaultCellStyle.Format = "0.00#########";
        }

        private void TransactionManagerForm_Load(object sender, EventArgs e)
        {
            // Enable double buffering to reduce the lag when scrolling the DataGridView
            ControlDoubleBuffering.SetDoubleBuffered(TransactionDataGridView);

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

        // You can't edit without purchasing the HemlockPOS software, so upsell the HemlockPOS software to the user
        // This allows a more dedicated interface and also increases revenue for me :)
        private void EditSelectedRow()
        {
            UpsellPOS();
        }

        private void TransactionDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            this.EditSelectedRow();
        }

        private void TransactionDataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                this.EditSelectedRow();
            }
        }

        // Keyboard shortcuts
        private void ManageStudentsForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.N)
            {
                UpsellPOS();
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
                UpsellPOS();
            }
        }
    }
}
