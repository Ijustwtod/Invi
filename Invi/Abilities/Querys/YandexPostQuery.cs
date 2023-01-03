using HandyControl.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Invi.Abilities.Querys
{
    public static class YandexPostQuery
    {
        public static void ExecCommand(string device_id, string command, string commandBody)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(Properties.Settings.Default.userToken))
                    return;
                if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
                {
                    Growl.Error($"Отсутствует или ограниченно физическое подключение к сети\nПроверьте настройки вашего сетевого подключения");
                    return;
                }

                WebRequest request = WebRequest.Create("https://api.iot.yandex.net/v1.0/devices/actions");
                request.Method = "POST";
                request.Headers.Add("Authorization", $"Bearer {Properties.Settings.Default.userToken}");
                request.ContentType = "application/json";

                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    string postData = CommandBuilder.GetCommand(device_id, command, commandBody);
                    streamWriter.Write(postData);
                    streamWriter.Flush();
                    streamWriter.Close();
                }

                var httpResponse = (HttpWebResponse)request.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    if (result.Contains("DEVICE_UNREACHABLE"))
                    {
                        Growl.Error("Устройсво недоступно");
                    }
                }
            }
            catch (Exception e)
            {
                Growl.Error($"Error! {e.Message}");
            }
        }
    }
}
