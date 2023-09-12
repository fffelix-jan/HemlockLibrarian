using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Security;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HemlockLibrarianStaffClient
{
    public partial class LoginForm : Form
    {
        public bool LoginSuccess { get; private set; }

        public LoginForm()
        {
            InitializeComponent();

            // Load the saved login info
            if (Properties.Settings.Default.RememberLoginInfo)
            {
                RememberCheckBox.Checked = true;
                ServerBox.Text = Properties.Settings.Default.ServerAddress;
                UsernameBox.Text = Properties.Settings.Default.Username;
                UseWinAuthCheckBox.Checked = Properties.Settings.Default.UseWindowsAuth;
                this.ActiveControl = PasswordBox;
            }

            // Add a handler to the textbox to detect when Enter is pressed
            this.ServerBox.KeyPress += new KeyPressEventHandler(CheckEnterKeyPress);
            this.UsernameBox.KeyPress += new KeyPressEventHandler(CheckEnterKeyPress);
            this.PasswordBox.KeyPress += new KeyPressEventHandler(CheckEnterKeyPress);

            if (UseWinAuthCheckBox.Checked)
            {
                this.ActiveControl = LoginButton;
            }
        }

        // Exit when exit button is clicked
        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Click the Login button if Enter is pressed while the text boxes are selected
        private void CheckEnterKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                LoginButton.PerformClick();
            }
        }

        // Login button action
        private async void LoginButton_Click(object sender, EventArgs e)
        {
            Control previous = this.ActiveControl;

            // Grey out the boxes and make it look busy
            ServerBox.Enabled = false;
            UsernameBox.Enabled = false;
            PasswordBox.Enabled = false;
            RememberCheckBox.Enabled = false;
            UseWinAuthCheckBox.Enabled = false;
            LoginButton.Enabled = false;
            this.UseWaitCursor = true;

            // Remember or forget the login info based on the user's choice
            if (RememberCheckBox.Checked)
            {
                Properties.Settings.Default.RememberLoginInfo = true;
                Properties.Settings.Default.ServerAddress = ServerBox.Text;
                Properties.Settings.Default.Username = UseWinAuthCheckBox.Checked ? "" : UsernameBox.Text;
                Properties.Settings.Default.UseWindowsAuth = UseWinAuthCheckBox.Checked;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.RememberLoginInfo = false;
                Properties.Settings.Default.ServerAddress = "";
                Properties.Settings.Default.Username = "";
                Properties.Settings.Default.Save();
            }

            await TryLogin();

            if (!LoginSuccess)
            {
                // If it got here, it failed, so re-enable everything
                this.UseWaitCursor = false;
                ServerBox.Enabled = true;
                RememberCheckBox.Enabled = true;
                UseWinAuthCheckBox.Enabled = true;
                LoginButton.Enabled = true;
                RestoreUsernamePasswordBoxState();

                this.ActiveControl = previous;
            }
        }

        private async Task TryLogin()
        {
            string exceptionMessage = "";
            bool success = false;
            await Task.Run(() =>
            {
                SqlConnectionInfo.UsingWindowsAuthentication = UseWinAuthCheckBox.Checked;

                // Build the SQL connection string and store it
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
                {
                    ["Server"] = ServerBox.Text,
                    ["Database"] = "librarymanagement",  // hard coded name of database
                    ["Trusted_Connection"] = UseWinAuthCheckBox.Checked ? "true" : "false",
                    ["Connection Timeout"] = 5
                };
                SqlConnectionInfo.ConnectionString = builder.ToString();

                if (SqlConnectionInfo.UsingWindowsAuthentication)
                {
                    SqlConnectionInfo.Credentials = null;
                }
                else
                {
                    // Turn the string in the PasswordBox into a SecureString
                    // (this is bad practice, but I don't know
                    // how else to get the password)
                    SqlConnectionInfo.SecurePassword = new SecureString();
                    foreach (char ch in PasswordBox.Text)
                    {
                        SqlConnectionInfo.SecurePassword.AppendChar(ch);
                    }
                    SqlConnectionInfo.SecurePassword.MakeReadOnly();

                    SqlConnectionInfo.Credentials = new SqlCredential(UsernameBox.Text, SqlConnectionInfo.SecurePassword);
                }

                // Test the connection
                using (SqlConnection conn = new SqlConnection(SqlConnectionInfo.ConnectionString))
                {
                    try
                    {
                        if (!SqlConnectionInfo.UsingWindowsAuthentication)
                        {
                            conn.Credential = SqlConnectionInfo.Credentials;
                        }
                        conn.Open();
                        conn.Close();
                        success = true;
                    }
                    catch (Exception ex)
                    {
                        exceptionMessage = ex.Message;
                    }
                }
            });

            if (success)
            {
                LoginSuccess = true;
                Close();
            }
            else
            {
                MessageBox.Show("Login failed. The following error occured:\r\n" + exceptionMessage, "Connection Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UseWinAuthCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            RestoreUsernamePasswordBoxState();
        }

        private void RestoreUsernamePasswordBoxState()
        {
            if (UseWinAuthCheckBox.Checked)
            {
                UsernameBox.Enabled = false;
                PasswordBox.Enabled = false;
            }
            else
            {
                UsernameBox.Enabled = true;
                PasswordBox.Enabled = true;
            }
        }
    }
}
