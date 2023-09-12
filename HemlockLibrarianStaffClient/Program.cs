using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace HemlockLibrarianStaffClient
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // make a mutex and detect if another instance of the program is running
            Mutex mutex = new Mutex(true, "HemlockLibrarianMutex", out bool mutexResult);

            // Prevent the mutex from being released by the GC
            GC.KeepAlive(mutex);

            if (!mutexResult)
            {
                MessageBox.Show("Another instance of the Library Mangement Client is already open.", "Already Running", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Make a new login form and run it
            LoginForm login = new LoginForm();
            Application.Run(login);

            // After the user has logged in successfully, run the main menu
            if (login.LoginSuccess)
            {
                MainForm form = new MainForm();
                Application.Run(form);
            }
        }
    }
}
