using System;
using System.Collections.Generic;
using System.IO;
using LumenWorks.Framework.IO.Csv;
using System.Net;
using System.Text;

namespace VPNGateAPI
{
    public static class API
    {
        public static List<VPN> GetConfigs()
        {
            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;
            File.WriteAllText("data.csv", client.DownloadString("http://www.vpngate.net/api/iphone/").Replace("*vpn_servers", ""));

            List<VPN> vpns = new List<VPN>();

            using (var csv = new CachedCsvReader(new StreamReader("data.csv"), true))
            {
                try
                {
                    while (csv.ReadNextRecord())
                    {
                        vpns.Add(new VPN { Config = Helpers.Decode(csv[14]), Location = csv[5], Ping = Convert.ToInt32(csv[4]) });
                    }
                }
                catch
                {

                }
            }

            return vpns;
        }
    }
}
