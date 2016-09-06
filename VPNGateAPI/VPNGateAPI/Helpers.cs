using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VPNGateAPI
{
    static class Helpers
    {
        public static string Decode(string str)
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(str));
        }

        public static int GetPort(string config)
        {
            string[] lines = config.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

            string port = lines[61].Replace("remote ", "");
            if (port.IndexOf(" ") > 0) port = port.Substring(port.IndexOf(" ") + 1);
            return Convert.ToInt32(port);
        }

        public static string GetProtocol(string config)
        {
            string[] lines = config.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

            string protocol = lines[40].Substring(6, 3);
            
            return protocol;
        }
    }
}
