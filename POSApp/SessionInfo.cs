    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSApp
{
    internal class SessionInfo
    {
        public static int UserID { get; set; }
        public static string Role { get; set; }
        public static string Username { get; set; }  // Add this to store the username
        public static void Clear()
        {
            Username = string.Empty;
        }
    }
}
