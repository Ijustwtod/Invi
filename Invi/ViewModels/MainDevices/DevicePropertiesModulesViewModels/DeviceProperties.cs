using Invi.Abilities.Base;
using Invi.Abilities.Querys;
using Invi.Models;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using static Invi.Models.YandexSmartHomeRoot;
using ColorMine.ColorSpaces;
using Invi.Abilities;
using System.Linq;

namespace Invi.ViewModels.MainDevices.DevicePropertiesViewModels
{
    public class DeviceProperties : INProp
    {
        public Device _currentDevice;
        public Device currentDevice
        {
            get
            {
                return _currentDevice;
            }
            set
            {
                _currentDevice = value;
                OnPropertyChanged("currentDevice");

            }
        }

        private SolidColorBrush _currentDeviceColor;
        public SolidColorBrush currentDeviceColor
        {
            get
            {
                return _currentDeviceColor;
            }
            set
            {
                _currentDeviceColor = value;
                OnPropertyChanged("currentDeviceColor");

            }
        }

        public DeviceProperties(object sender)
        {
            currentDevice = (Device)sender;
            if(currentDevice.capabilities.FirstOrDefault(c => c.type.Contains(DevicePropertiesConstants.color_setting)).state?.instance == "hsv")
            currentDeviceColor = ColorsUtils.GetColorFromJson(currentDevice.capabilities.FirstOrDefault(c => c.type.Contains(DevicePropertiesConstants.color_setting)).state.value.ToString());
        }

        public ICommand OnOffDevice
        {
            get
            {
                return new DelegateСommand(async (obj) =>
                {
                    if (currentDevice != null)
                        if (!(bool)currentDevice.capabilities[0].state.value)
                        {
                            await Task.Factory.StartNew(() =>
                            {
                                YandexPostQuery.ExecCommand(currentDevice.id, CommandsType.On_Off, "false");
                                OnPropertyChanged("yandexRoot");
                            });
                        }
                        else
                        {
                            await Task.Factory.StartNew(() =>
                            {
                                YandexPostQuery.ExecCommand(currentDevice.id, CommandsType.On_Off, "true");
                                OnPropertyChanged("yandexRoot");
                            });
                        }
                });
            }
        }

        public ICommand ChangheColor
        {
            get
            {
                return new DelegateСommand(async (obj) =>
                {
                    var rgb = new Rgb { R = currentDeviceColor.Color.R, G = currentDeviceColor.Color.G, B = currentDeviceColor.Color.B };
                    var hsv = rgb.To<Hsv>();
                });
            }
        }
    }
}
