using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invi.Abilities.JsonAbilities
{
    public static class JsonBuilder
    {
        public static string JsonFromSave(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}
