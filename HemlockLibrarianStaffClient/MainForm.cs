using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HemlockLibrarianStaffClient
{
    public partial class MainForm : Form
    {
        Form FormInPanel;
        public const string AppTitle = "HemlockLibrarian";

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SwitchManageBooksForm();
        }

        private void SwitchManageBooksForm()
        {
            FormInPanel = new BookManagerForm();
            FormInPanel.TopLevel = false;
            FormInPanel.AutoScroll = true;
            FormInPanel.Dock = DockStyle.Fill;
            FormPanel.Controls.Add(FormInPanel);
            FormInPanel.Show();
            this.Text = AppTitle + ": Manage Books";
        }
        private void SwitchManageItemsForm()
        {
            FormInPanel = new ItemManagerForm();
            FormInPanel.TopLevel = false;
            FormInPanel.AutoScroll = true;
            FormInPanel.Dock = DockStyle.Fill;
            FormPanel.Controls.Add(FormInPanel);
            FormInPanel.Show();
            this.Text = AppTitle + ": Manage Items";
        }

        private void SwitchManageBranchesForm()
        {
            FormInPanel = new BranchManagerForm();
            FormInPanel.TopLevel = false;
            FormInPanel.AutoScroll = true;
            FormInPanel.Dock = DockStyle.Fill;
            FormPanel.Controls.Add(FormInPanel);
            FormInPanel.Show();
            this.Text = AppTitle + ": Manage Branches";
        }

        private void SwitchManageUsersForm()
        {
            FormInPanel = new UserManagerForm();
            FormInPanel.TopLevel = false;
            FormInPanel.AutoScroll = true;
            FormInPanel.Dock = DockStyle.Fill;
            FormPanel.Controls.Add(FormInPanel);
            FormInPanel.Show();
            this.Text = AppTitle + ": Manage Users";
        }

        private void SwitchManageHoldsForm()
        {
            FormInPanel = new HoldManagerForm();
            FormInPanel.TopLevel = false;
            FormInPanel.AutoScroll = true;
            FormInPanel.Dock = DockStyle.Fill;
            FormPanel.Controls.Add(FormInPanel);
            FormInPanel.Show();
            this.Text = AppTitle + ": Manage Holds";
        }

        private void SwitchManageTransactionsForm()
        {
            FormInPanel = new TransactionManagerForm();
            FormInPanel.TopLevel = false;
            FormInPanel.AutoScroll = true;
            FormInPanel.Dock = DockStyle.Fill;
            FormPanel.Controls.Add(FormInPanel);
            FormInPanel.Show();
            this.Text = AppTitle + ": Manage Transactions";
        }

        private void ManageBooksButton_Click(object sender, EventArgs e)
        {
            FormInPanel.Close();
            SwitchManageBooksForm();
        }

        private void ManageItemsButton_Click(object sender, EventArgs e)
        {
            FormInPanel.Close();
            SwitchManageItemsForm();
        }

        private void ManageBranchesButton_Click(object sender, EventArgs e)
        {
            FormInPanel.Close();
            SwitchManageBranchesForm();
        }

        private void ManageUsersButton_Click(object sender, EventArgs e)
        {
            FormInPanel.Close();
            SwitchManageUsersForm();
        }

        private void ManageHoldsButton_Click(object sender, EventArgs e)
        {
            FormInPanel.Close();
            SwitchManageHoldsForm();
        }

        private void ManageTransactionsButton_Click(object sender, EventArgs e)
        {
            FormInPanel.Close();
            SwitchManageTransactionsForm();
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
