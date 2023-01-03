using Invi.Abilities.Base;
using Invi.Views.Actions;
using Invi.Views.MainDevices;
using Invi.Views.Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Invi.ViewModels
{
    internal class MainWindowViewModel : INotifyPropertyChanged
    {
        private Page _currentPage;
        public Page CurrentPage
        {
            get
            {
                return _currentPage;
            }
            set
            {
                _currentPage = value;
                OnPropertyChanged("CurrentPage");
            }
        }

        private Page _mainDeviceList;
        private Page _actionsView;

        private Visibility _buttonUpdateVisibility;
        public Visibility buttonUpdateVisibility { get { return _buttonUpdateVisibility; } set { _buttonUpdateVisibility = value; OnPropertyChanged("buttonUpdateVisibility"); } }

        public MainWindowViewModel()
        {
            _actionsView = new ActionsView();
            _mainDeviceList = new ListDevicePage();
            CurrentPage = _mainDeviceList;
            Task.Factory.StartNew(() => TryUpdate());
        }
        private void TryUpdate() 
        {
          var isNeedUpdate = Task.Factory.StartNew(() => Abilities.Updater.CheckLastVersion.IsNeedUpdate());
          isNeedUpdate.Wait();
            if (isNeedUpdate.Result) 
            {
                buttonUpdateVisibility = Visibility.Visible;
            }
            else 
            {
                buttonUpdateVisibility = Visibility.Hidden;
            }

        }
        public ICommand LoadAllDevicePage
        {
            get
            {
                return new DelegateСommand(async (obj) =>
                {
                    //CurrentPage = AllDevicePage;
                });
            }
        }

        public ICommand StartUpdate
        {
            get
            {
                return new DelegateСommand(async (obj) =>
                {
                    var mainDir = new DirectoryInfo(Directory.GetCurrentDirectory());
                    var mainFiles = mainDir.GetFiles().ToList();
                    var updater = mainFiles.SingleOrDefault(f => f.Name == "InviUpdate.exe");
                    if (updater.Exists)
                    {
                        Process.Start(updater.FullName);
                        Application.Current.Shutdown();
                    }
                });
            }
        }

        public ICommand LoadAllActionsPage
        {
            get
            {
                return new DelegateСommand(async (obj) =>
                {
                    if (!(CurrentPage is ActionsView))
                        CurrentPage = _actionsView;
                });
            }
        }


        public ICommand LoadAllMainDevicePage
        {
            get
            {
                return new DelegateСommand(async (obj) =>
                {
                    if (!(CurrentPage is ListDevicePage))
                        CurrentPage = _mainDeviceList;
                });
            }
        }

        public ICommand LoadSettings
        {
            get
            {
                return new DelegateСommand(async (obj) =>
                {
                    if (!(CurrentPage is SettingsView))
                    CurrentPage = new SettingsView();
                });
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
    }
}
