using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Invi.Abilities
{
    internal class CheckLastVersionAbility
    {
        internal static void NeedUpdate() 
        {
            var prop = Properties.Settings.Default;
            var serverLastVersion = GetLastBuilds(prop);
            var substr = serverLastVersion.Substring(0, serverLastVersion.Length - 4).Replace(".", ",");
            if (Convert.ToDouble(substr) > Convert.ToDouble(Properties.Settings.Default.Version))
            {
                Properties.Settings.Default.NeedUpdate = true;
                Properties.Settings.Default.Save();
            }
        }

        private static string GetLastBuilds(Properties.Settings prop)
        {
           
            var request = (FtpWebRequest)WebRequest.Create(prop.ftpUrl);
            request.Method = WebRequestMethods.Ftp.ListDirectory;
            request.Credentials = new NetworkCredential(prop.ftpLogin, prop.ftpPassword);
            request.UsePassive = false;
            using (var response = (FtpWebResponse)request.GetResponse())
            {
                var responseStream = response.GetResponseStream();
                using (var streamReader = new StreamReader(responseStream))
                {
                    var builds = new List<string>();
                    string line = streamReader.ReadLine();
                    while (!string.IsNullOrEmpty(line))
                    {
                        builds.Add(line);
                        line = streamReader.ReadLine();
                    }
                    if (builds.Count > 0)
                        return builds.Max();
                    else return "nope";
                }
            }
        }
    }
}
