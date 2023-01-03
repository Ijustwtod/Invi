using Invi.Abilities.Querys;
using Invi.Models;
using Invi.Views;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace Invi.ViewModels
{
    public class NavigationViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
        #endregion

        private Page _currentPage;
        public Page currentPage
        {
            get
            {
                return _currentPage;
            }
            set
            {
                _currentPage = value;
                OnPropertyChanged("currentPage");
            }
        }

        public NavigationViewModel()
        {

            if (!string.IsNullOrWhiteSpace(Properties.Settings.Default.userToken))
            {
                var isAuth = YandexGetQuery.GetTrueAuth(Properties.Settings.Default.userToken, Constants.getUserAuth, "OAuth");
                if (isAuth) 
                {
                    currentPage = new MainWindowView();
                }
                else
                {
                    currentPage = new Views.Authorization.AuthorizationView();
                }
            }
            else
            {
                currentPage = new Views.Authorization.AuthorizationView();
            }
        }
    }
}
