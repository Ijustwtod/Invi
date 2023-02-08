using Invi.Models;
using Invi.ViewModels.Actions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invi.Abilities.Actions
{
    internal class CreateActions
    {
        private static InviContext _inviContext;
        public static bool Add(InviAction action, ObservableCollection<VisualInviCommandClass> commands)
        {
            try
            {
                _inviContext = JsonConvert.DeserializeObject<InviContext>(JsonAbilities.JsonReader.Read(Models.Path.Commands));

                action.Owner = "Invi";
                action.ExternalId = ExternalIdGen();
                if (_inviContext.InviActions == null)
                    _inviContext.InviActions = new List<InviAction>();

                _inviContext.InviActions.Add(action);
                CommandsAdd(commands, action);

                string data = JsonConvert.SerializeObject(_inviContext);
                using (StreamWriter writer = new StreamWriter(Models.Path.Commands, false))
                {
                    writer.WriteLine(data);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static string ExternalIdGen()
        {
            InviContext context = new InviContext();
            Random random = new Random();
            bool isSingle = true;
            string word = "";
            word = "";
            char[] letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890".ToCharArray();

            for (int j = 1; j <= 10; j++)
            {
                int letter_num = random.Next(0, letters.Length - 1);
                word += letters[letter_num];
            }
            return word;
        }
        public static void CommandsAdd(ObservableCollection<VisualInviCommandClass> commands, InviAction action)
        {
            action.Commands = new List<InviCommand>();
            foreach (var item in commands)
            {
                var dataContext = item.page.DataContext as CommandAddViewModel;

                action.Commands.Add(new InviCommand
                {
                    CommandBody = dataContext.CurrentCommandBody,
                    DeviceId = dataContext.CurrentDevice.Id,
                });
            }
        }

    }
}
