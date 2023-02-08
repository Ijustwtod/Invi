using ColorMine.ColorSpaces;
using HandyControl.Controls;
using Invi.Abilities;
using Invi.Abilities.Base;
using Invi.Abilities.Querys;
using Invi.Models;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using static Invi.Models.YandexSmartHomeRoot;

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

        private int _currentTemp;
        public int currentTemp
        {
            get
            {
                return _currentTemp;
            }
            set
            {
                _currentTemp = value;
                OnPropertyChanged("currentTemp");
            }
        }

        private int _currentBri;
        public int currentBri
        {
            get
            {
                return _currentBri;
            }
            set
            {
                _currentBri = value;
                OnPropertyChanged("currentBri");
            }
        }

        private SolidColorBrush _selectedColor;
        public SolidColorBrush selectedColor
        {
            get
            {
                return _selectedColor;
            }
            set
            {
                _selectedColor = value;
                OnPropertyChanged("selectedColor");
            }
        }

        public DeviceProperties(object sender)
        {
            try
            {
                currentDevice = (Device)sender;
                //if (currentDevice.capabilities.FirstOrDefault(c => c.type.Contains(DevicePropertiesConstants.color_setting)).state?.instance == "hsv")
                //    currentDeviceColor = ColorsUtils.GetColorFromJson(currentDevice.capabilities.FirstOrDefault(c => c.type.Contains(DevicePropertiesConstants.color_setting)).state.value.ToString());
            }
            catch (System.Exception e)
            {

                Growl.Error($"Error! {e.Message}");
            }
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
                                string postData = CommandBuilder.GetCommand(currentDevice.id, CommandsType.On_Off, "false");
                                YandexPostQuery.ExecCommand(postData);
                                OnPropertyChanged("yandexRoot");
                            });
                        }
                        else
                        {
                            await Task.Factory.StartNew(() =>
                            {
                                string postData = CommandBuilder.GetCommand(currentDevice.id, CommandsType.On_Off, "true");
                                YandexPostQuery.ExecCommand(postData);
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
                    await Task.Factory.StartNew(() =>
                    {
                        var rgb = new Rgb { R = selectedColor.Color.R, G = selectedColor.Color.G, B = selectedColor.Color.B };
                        var hsv = rgb.To<Hsv>();
                        string postData = CommandBuilder.GetCommand(currentDevice.id, CommandsType.LightColorChange, $"{Convert.ToInt32(hsv.H)};{Convert.ToInt32(hsv.S * 100)};{Convert.ToInt32(hsv.V * 100)}");
                        YandexPostQuery.ExecCommand(postData);
                        OnPropertyChanged("yandexRoot");
                    });

                });
            }
        }

        public ICommand ChangheTemp
        {
            get
            {
                return new DelegateСommand(async (obj) =>
                {
                    if (currentTemp > 0)
                    {
                        await Task.Factory.StartNew(() =>
                        {
                            string postData = CommandBuilder.GetCommand(currentDevice.id, CommandsType.LightTemperatureChange, $"{currentTemp}");
                            YandexPostQuery.ExecCommand(postData);
                            OnPropertyChanged("yandexRoot");
                        });
                    }
                    if (currentBri > 0)
                    {
                        await Task.Factory.StartNew(() =>
                        {
                            string postData = CommandBuilder.GetCommand(currentDevice.id, CommandsType.LightBrightnessChange, $"{currentBri}");
                            YandexPostQuery.ExecCommand(postData);
                            OnPropertyChanged("yandexRoot");
                        });
                    }
                });
            }
        }

    }
}
