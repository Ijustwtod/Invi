using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Invi.Views.Authorization
{
    /// <summary>
    /// Логика взаимодействия для WebBrowserWindow.xaml
    /// </summary>
    public partial class WebBrowserWindow : Window
    {
        public string Sourse;
        public WebBrowserWindow()
        {
            InitializeComponent();
            WebBrowser.Navigate("https://oauth.yandex.ru/authorize?response_type=token&client_id=1ad1b5820bb1496793a868032e95493d");
        }

        private void WebBrowser_LoadCompleted(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            if (WebBrowser.Source.ToString().Contains("https://oauth.yandex.ru/verification_code"))
            {
                Sourse = WebBrowser.Source.ToString();
                this.Close();
            }
        }
    }
}
