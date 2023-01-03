using Invi.Abilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using static Invi.Models.YandexSmartHomeRoot;

namespace Invi.Models
{
    public class Context : INotifyPropertyChanged
    {
        #region INPC
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
        #endregion
        private YandexSmartHomeRoot yandexClass;

        private Root _yandexRoot;
        public Root yandexRoot 
        {
            get
            {
                return _yandexRoot;
            }
            set
            {
                _yandexRoot = value;
                OnPropertyChanged("yandexRoot");
            }
        }

        private List<Device> _devices;
        public List<Device> Devices
        {
            get
            {
                return _devices;
            }
            set
            {
                _devices = value;
                OnPropertyChanged("Devices");
            }
        }

        private Visibility _isLoaded;
        public Visibility isLoaded { get { return _isLoaded; } set { _isLoaded = value; OnPropertyChanged("isLoaded");}}

        public Context() 
        {
            yandexClass = new YandexSmartHomeRoot();
           
            var yandexRootUpdaterThread = new Thread(UpdateRoot);
            yandexRootUpdaterThread.IsBackground = true;
            yandexRootUpdaterThread.Start();
        }
        private void UpdateRoot()
        {
            while (true)
            {
                isLoaded = Visibility.Visible;
                yandexRoot = GetYandexRoot.GetRoot();
                UpdateDevices();
                isLoaded = Visibility.Hidden;
                Thread.Sleep(60000);
            }
        }
        private void UpdateDevices() 
        {
            Devices = yandexRoot.devices;
        }
    }
}
