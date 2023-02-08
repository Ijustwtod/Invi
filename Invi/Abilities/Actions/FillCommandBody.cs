using Invi.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Invi.Abilities.Actions
{
    internal static class FillCommandBody
    {
        public static List<CommandBody> FillCommandBodies()
        {
            var config = JsonConvert.DeserializeObject<InviContext>(JsonAbilities.JsonReader.Read(Models.Path.Commands));
            if (config == null)
                config = new InviContext();

            if (config.CommandBodies == null)
                config.CommandBodies = new List<CommandBody>();

            config.CommandBodies.Add(new CommandBody() { Id = 0, Name = "Включить", Body = "CommandOn" });
            config.CommandBodies.Add(new CommandBody() { Id = 1, Name = "Выключить", Body = "CommandOff" });
            config.CommandBodies.Add(new CommandBody() { Id = 2, Name = "Изменить цвет", Body = "CommandChangeColor" });

            string data = JsonConvert.SerializeObject(config);
            using (StreamWriter writer = new StreamWriter(Models.Path.Commands, false))
            {
                writer.WriteLine(data);
            }

            return config.CommandBodies;
        }
    }
}
