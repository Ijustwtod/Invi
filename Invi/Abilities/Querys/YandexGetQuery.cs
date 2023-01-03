using System;
using System.IO;
using System.Net;

namespace Invi.Abilities.Querys
{
    public static class YandexGetQuery
    {
        private static string GetBase(string userToken, string link, string headerParam)
        {
            string answer = "";
            var wrGetUrl = WebRequest.Create(new Uri(link));
            wrGetUrl.Headers.Add("Authorization", $"{headerParam} {userToken}");
            Stream objStream;
            objStream = wrGetUrl.GetResponse().GetResponseStream();
            StreamReader objReader = new StreamReader(objStream);
            string sLine = "";
            while (sLine != null)
            {
                sLine = objReader.ReadLine();
                if (sLine != null)
                    answer = sLine.ToString();
            }
            return answer;
        }

        public static string GetString(string userToken, string link, string headerParam)
        {
            return GetBase(userToken, link, headerParam);
        }

        public static bool GetTrueAuth(string userToken, string link, string headerParam)
        {
            if (GetBase(userToken, link, headerParam).Contains(Properties.Settings.Default.AppId)) return true;
            else return false;
        }
    }
}
