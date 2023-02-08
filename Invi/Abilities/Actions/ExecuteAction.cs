using Invi.Abilities.Querys;
using Invi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invi.Abilities.Actions
{
    internal static class ExecuteAction
    {
        public static void ExecAction(InviAction action)
        {
            var allCommands = action.Commands;
            foreach (var command in allCommands)
            {
                switch (command.CommandBody.Body)
                {
                    case ("CommandOff"):
                        YandexPostQuery.ExecCommand(CommandBuilder.GetCommand(command.DeviceId, CommandsType.On_Off, "false"));
                        break;
                    case ("CommandOn"):
                        YandexPostQuery.ExecCommand(CommandBuilder.GetCommand(command.DeviceId, CommandsType.On_Off, "true"));
                        break;
                }    
            }
        }
    }
}
