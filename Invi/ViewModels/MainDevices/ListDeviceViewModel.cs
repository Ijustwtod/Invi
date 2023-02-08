using Invi.Abilities;
using Invi.Abilities.Base;
using Invi.Abilities.Querys;
using Invi.Models;
using Invi.Views.MainDevices.DevicePropertiesViews;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using static Invi.Models.YandexSmartHomeRoot;

namespace Invi.ViewModels.MainDevices
{
    public class ListDeviceViewModel : Context
    {
        private Device _selectedDevice;
        public Device SelectedDevice
        {
            get
            {
                return _selectedDevice;
            }
            set
            {
                _selectedDevice = value;
                OnPropertyChanged("SelectedDevice");
            }
        }
        private Page _currentPropertiesDevicePage;
        public Page CurrentPropertiesDevicePage
        {
            get
            {
                return _currentPropertiesDevicePage;
            }
            set
            {
                _currentPropertiesDevicePage = value;
                OnPropertyChanged("CurrentPropertiesDevicePage");
            }
        }
        public ICommand OpenSettingsDevice
        {
            get
            {
                return new DelegateСommand(async (obj) =>
                {
                    if (SelectedDevice != null)
                    {
                        CurrentPropertiesDevicePage = new DeviceLightPropertiesView(this);
                        OnPropertyChanged("CurrentDevicePage");
                    }
                });
            }
        }

        public ICommand OnOffLamp
        {
            get
            {
                return new DelegateСommand(async (obj) =>
                {

                    if (SelectedDevice != null)
                        if (!(bool)SelectedDevice.capabilities[0].state.value)
                        {
                            await Task.Factory.StartNew(() =>
                            {
                                string postData = CommandBuilder.GetCommand(SelectedDevice.id, CommandsType.On_Off, "true");
                                YandexPostQuery.ExecCommand(postData);
                                OnPropertyChanged("yandexRoot");
                            });
                        }
                        else
                        {
                            await Task.Factory.StartNew(() =>
                            {
                                string postData = CommandBuilder.GetCommand(SelectedDevice.id, CommandsType.On_Off, "false");
                                YandexPostQuery.ExecCommand(postData);
                                OnPropertyChanged("yandexRoot");
                            });
                        }
                });
            }
        }

    }
}
