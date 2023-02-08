using Invi.Models;

namespace Invi.Abilities
{
    public static class CommandBuilder
    {
        /// <summary>
        /// Конструктор комманд
        /// </summary>
        /// <param name="deviceId">Индефикатор устройста</param>
        /// <param name="commandType"> Тип комманды</param>
        /// <param name="value"> Значение</param>
        /// <returns>Строку комманды </returns>
        public static string GetCommand(string deviceId, string commandType, string value)
        {
            switch (commandType)
            {
                case CommandsType.On_Off:
                    return BuildOn_OffCommand(deviceId, value);
                case CommandsType.LightColorChange:
                    return BuildLightColorChangeCommand(deviceId, value);
                case CommandsType.LightTemperatureChange:
                    return BuildLightTemperatureChangeCommand(deviceId, value);
                case CommandsType.LightBrightnessChange:
                    return BuildLightBrightnessChangeCommand(deviceId, value);
            }
            return null;
        }

        private static string CommandBase(string deviceId)
        {
            return "{\"devices\":[{\"id\":\"" + deviceId + "\",\"actions\":[{\"type\"";
        }

        private static string BuildOn_OffCommand(string deviceId, string value)
        {
            return CommandBase(deviceId) + ":\"devices.capabilities.on_off\",\"state\":{\"instance\":\"on\",\"value\":" + value + "}}]}]}";
        }

        private static string BuildLightColorChangeCommand(string deviceId, string value)
        {
            var hsvValues = value.Split(';');
            string color = $"\"h\": {hsvValues[0]} , \"s\": {hsvValues[1]} , \"v\": {hsvValues[2]}";
            return CommandBase(deviceId) + ":\"devices.capabilities.color_setting\",\"state\":{\"instance\":\"hsv\",\"value\":{" + color + " } }}]}]}";
        }

        private static string BuildLightTemperatureChangeCommand(string deviceId, string value)
        {
            return CommandBase(deviceId) + ":\"devices.capabilities.color_setting\",\"state\":{\"instance\":\"temperature_k\",\"value\":" + value + "  }}]}]}";
        }

        private static string BuildLightBrightnessChangeCommand(string deviceId, string value)
        {
            return CommandBase(deviceId) + ":\"devices.capabilities.range\",\"state\":{\"instance\":\"brightness\",\"value\":" + value + "  }}]}]}";
        }
    }
}
