using Invi.Abilities.JsonAbilities;
using Invi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Invi.Models.YandexSmartHomeRoot;

namespace Invi.Abilities.Sync
{
    public static class DeviceSync
    {
        public static void DevicesSync(List<Device> devices) 
        {
            var config = JsonConvert.DeserializeObject<InviContext>(JsonAbilities.JsonReader.Read(Models.Path.Commands));
            if (config == null) 
            {
                config = new InviContext();
                config.InviDevices = new List<InviDevice>();
            }
            foreach (var item in devices)
            {
                if (config.InviDevices.Any(d => d.Id == item.id))
                    continue;

                config.InviDevices.Add(new InviDevice()
                {
                    Name = item.name,
                    Id = item.id,
                    ExternalId = item.external_id
                });
            }
            string data = JsonConvert.SerializeObject(config);
            using (StreamWriter writer = new StreamWriter(Models.Path.Commands, false))
            {
                writer.WriteLine(data);
            }
        }
    }
}
