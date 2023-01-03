using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;


namespace Invi.Abilities.Updater
{
    internal static class CheckLastVersion
    {
        public static bool IsNeedUpdate()
        {
            if (!String.IsNullOrWhiteSpace(Properties.Settings.Default.Version))
                if (Convert.ToDouble(GetLastBuilds()) > Convert.ToDouble(Properties.Settings.Default.Version))
                    return true;
            return false;
        }
        private static string GetLastBuilds()
        {
            var prop = Properties.Settings.Default;
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
                        return builds.Max().Substring(0, builds.Max().Length - 4);
                    else return "nope";
                }
            }
        }
    }
}
