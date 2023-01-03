using System;
using System.Net.Http;

namespace YandexAbilities
{
    public class GetRootData
    {
        public string GetRoot(string userToken)
        {
            string answer = "";
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = (new Uri("https://api.iot.yandex.net/v1.0/user/info"));
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {userToken}");

            }
            //var wrGetUrl = WebRequest.Create();
            //wrGetUrl.Headers.Add("Authorization", $"Bearer {userToken}");
            //Stream objStream;
            //objStream = wrGetUrl.GetResponse().GetResponseStream();
            //StreamReader objReader = new StreamReader(objStream);

            //string sLine = "";

            //while (sLine != null)
            //{
            //    sLine = objReader.ReadLine();
            //    if (sLine != null)
            //        answer = sLine.ToString();
            //}
            return answer;
        }
    }
}
