using Invi.Abilities;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Invi.Models
{
    public class YandexSmartHomeRoot
    {
        #region Entity
        public class Room
        {
            public string id { get; set; }
            public string name { get; set; }
            public string household_id { get; set; }
            public List<string> devices { get; set; }
            public List<Device> richdevices { get; set; }
        }

        public class TemperatureK
        {
            public int min { get; set; }
            public int max { get; set; }
        }

        public class Range
        {
            public int min { get; set; }
            public int max { get; set; }
            public int precision { get; set; }
        }

        public class Parameters
        {
            public string color_model { get; set; }
            public TemperatureK temperature_k { get; set; }
            public bool? split { get; set; }
            public string instance { get; set; }
            public string unit { get; set; }
            public bool? random_access { get; set; }
            public bool? looped { get; set; }
            public Range range { get; set; }
        }

        public class State
        {
            public string instance { get; set; }
            public object value { get; set; }
        }

        public class Capability
        {
            public bool reportable { get; set; }
            public bool retrievable { get; set; }
            public string type { get; set; }
            public Parameters parameters { get; set; }
            public State state { get; set; }
            public double last_updated { get; set; }
        }

        public class Device
        {
            public string id { get; set; }
            public string name { get; set; }
            public List<object> aliases { get; set; }
            public string type { get; set; }
            public string external_id { get; set; }
            public string skill_id { get; set; }
            public string household_id { get; set; }
            public string room { get; set; }
            public List<object> groups { get; set; }
            public List<Capability> capabilities { get; set; }
            public List<object> properties { get; set; }
            public string icon { get; set; }
            public OnlineStatus online_status { get; set; }
        }
        public class OnlineStatus
        {
            public string status { get; set; }
            public System.Windows.Visibility visibility { get; set; }
            public bool stateDisplay { get; set; }
            public bool state { get; set; }
        }
        public class Scenario
        {
            public string id { get; set; }
            public string name { get; set; }
            public bool is_active { get; set; }
        }

        public class Household
        {
            public string id { get; set; }
            public string name { get; set; }
        }

        public class Root
        {
            public string status { get; set; }
            public string request_id { get; set; }
            public List<Room> rooms { get; set; }
            public List<object> groups { get; set; }
            public List<Device> devices { get; set; }
            public List<Scenario> scenarios { get; set; }
            public List<Household> households { get; set; }
        }
        #endregion
    }
}
