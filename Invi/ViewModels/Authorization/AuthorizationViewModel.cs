using Invi.Abilities.Base;
using Invi.Views.Authorization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Invi.ViewModels.Authorization
{
    public class AuthorizationViewModel
    {
        private WebBrowserWindow webBrowserWindow = new WebBrowserWindow();
        public ICommand YandexLogin
        {
            get
            {
                return new DelegateСommand((obj) =>
                {
                    webBrowserWindow.ShowDialog();
                    SaveAuthToken(GetAuthToken());
                    RestartApp();
                });
            }
        }

        private void SaveAuthToken(string token)
        {
            token = token.Substring(55);
            token = token.Substring(0, token.Length - 38);
            Properties.Settings.Default.userToken = token;
            Properties.Settings.Default.Save();
        }
        private void RestartApp() 
        {
            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }

        private string GetAuthToken()
        {
            while (true)
            {
                if (webBrowserWindow.Sourse.Contains("https://oauth.yandex.ru/verification_code"))
                {
                    return webBrowserWindow.Sourse;
                }
            }
        }
    }
}
