using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invi.Models
{
    internal class Constants
    {
        public const string getYandexSmartHomeRoot = "https://api.iot.yandex.net/v1.0/user/info";
        public const string getUserAuth = "https://login.yandex.ru/info?";
        public const string getFullInfoDevice = "https://api.iot.yandex.net/v1.0/devices/";


        public const string lightSocketDevice = "devices.types.light.socket";
    }

    internal class DeviceTypes
    {
        public const string lightDevice = "devices.types.light";
        public const string lightSocketDevice = "devices.types.light.socket";
        public const string cookingKettleDevice = "devices.types.cooking.kettle";
    }
    internal class DevicePropertiesConstants
    {
        public const string on_off = "devices.capabilities.on_off";
        public const string color_setting = "devices.capabilities.color_setting";
        public const string mode = "mode";
        public const string range = "devices.capabilities.range";
        public const string toggle = "toggle";
    }

    internal class CommandsType
    {
        public const string On_Off = "On_Off";
        public const string LightColorChange = "LightColorChange";
        public const string LightTemperatureChange = "LightTemperatureChange";
    }
}
