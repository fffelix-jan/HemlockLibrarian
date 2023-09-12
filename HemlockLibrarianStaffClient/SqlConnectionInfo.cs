using System.Data.SqlClient;
using System.Security;

namespace HemlockLibrarianStaffClient
{
    public static class SqlConnectionInfo
    {
        public static SecureString SecurePassword { get; set; }
        public static SqlCredential Credentials { get; set; }
        public static string ConnectionString { get; set; }
        public static bool UsingWindowsAuthentication { get; set; }
    }
}
