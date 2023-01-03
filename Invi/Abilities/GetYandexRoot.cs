using Invi.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Invi.Abilities
{
    internal static class GetYandexRoot
    {
        private static YandexSmartHomeRoot.Root yRoot;
        public static YandexSmartHomeRoot.Root GetRoot()
        {
            var json = Querys.YandexGetQuery.GetString(Properties.Settings.Default.userToken, Constants.getYandexSmartHomeRoot, "Bearer");
            yRoot = JsonConvert.DeserializeObject<YandexSmartHomeRoot.Root>(json);
            FillDevice();
            FillRoom();
            return yRoot;
        }
        private static void FillRoom() 
        {
            foreach (var room in yRoot.rooms)
            {
                room.richdevices = new List<YandexSmartHomeRoot.Device>();
                foreach (var deviceId in room.devices)
                    room.richdevices.Add(yRoot.devices.FirstOrDefault(d => d.id == deviceId));
            }
        }
        private static void FillDevice()
        {
            foreach (var device in yRoot.devices)
            {
                var deviceCopy = device;
                if (device.capabilities.Count == 1)
                    continue;

                var newCabap = new List<YandexSmartHomeRoot.Capability>();
                newCabap.Add(device.capabilities.FirstOrDefault(c => c.type.Contains("devices.capabilities.on_off")));
                device.capabilities.Remove(deviceCopy.capabilities.FirstOrDefault(c => c.type.Contains("devices.capabilities.on_off")));
                newCabap.AddRange(device.capabilities.OrderBy(x => x.type.Substring(21)).ToList());
                device.capabilities.Clear();
                device.capabilities.AddRange(newCabap);
                device.icon = $"/Icons/Device/{device.type}.png";
                device.online_status = GetOnlineStatus(device);
            }
        }
        private static YandexSmartHomeRoot.OnlineStatus GetOnlineStatus(YandexSmartHomeRoot.Device device)
        {
            var status = Querys.YandexGetQuery.GetString(Properties.Settings.Default.userToken, Constants.getFullInfoDevice + device.id, "Bearer");
            if (status.Contains("state\":\"online"))
            {
                return new YandexSmartHomeRoot.OnlineStatus
                {
                    visibility = System.Windows.Visibility.Hidden,
                    stateDisplay = false,
                    state = true,
                };
            }
            if (status.Contains("state\":\"offline"))
            {
                return new YandexSmartHomeRoot.OnlineStatus
                {
                    visibility = System.Windows.Visibility.Visible,
                    stateDisplay = true,
                    state = false,
                    status = "Offline"
                };
            }
            if (status.Contains("state\":\"unknown"))
            {
                return new YandexSmartHomeRoot.OnlineStatus
                {
                    visibility = System.Windows.Visibility.Visible,
                    stateDisplay = true,
                    state = false,
                    status = "Unknown"
                };
            }
            return null;
        }
    }
}
