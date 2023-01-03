using Invi.Models;
using Invi.Views.MainDevices.DevicePropertiesViews.DevicePropertiesModules;
using Invi.Views.MainDevices.DevicePropertiesViews.DevicePropertiesModules.Light;
using System.Collections.Generic;
using System.Windows.Controls;
using static Invi.Models.YandexSmartHomeRoot;

namespace Invi.Abilities
{
    public class DevicePropertiesViewBuilder
    {
        private Device device;
        public DevicePropertiesViewBuilder(object sender)
        {
            device = (Device)sender;
        }
        public List<Page> GetDeviceProperties()
        {
            var propList = new List<Page>();
            propList.Add(new DevicePropertiesModulName(device));
            foreach (var capability in device.capabilities)
            {
                switch (capability.type)
                {
                    case DevicePropertiesConstants.on_off:
                        propList.Add(new DevicePropertiesModul_On_off(device));
                        break;
                    case DevicePropertiesConstants.color_setting:
                        propList.Add(GetProperties_color_setting_Type(capability));
                        break;
                }
            }
            return propList;
        }
        private Page GetProperties_color_setting_Type(Capability capability)
        {
            if (capability.parameters.temperature_k != null && capability.parameters.color_model != null)
                return new DevicePropertiesModulLightColorAndTemperature_k();

            return null;
        }
    }
}
