using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;

namespace Invi.Models
{
    public class InviContext
    {
        public virtual List<InviDevice> InviDevices { get; set; }
        public virtual List<InviAction> InviActions { get; set; }
        public virtual List<DeviceInGroup> InviGroups { get; }
        public virtual List<CommandBody> CommandBodies { get; set; }    
        public virtual List<InviCommand> InviCommands { get; set; }
        public virtual List<SolidColorBrush> InviColors { get; set; }
    }

    public class InviDevice
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ExternalId { get; set; }
    }

    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class DeviceInGroup
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public virtual List<string> DevicesId { get; set; }
        public string Name { get; set; }
    }

    public class InviAction
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayCommand { get; set; }
        public bool IsFavorite { get; set; }
        public string Owner { get; set; }
        public string ExternalId { get; set; }
        public virtual List<InviCommand> Commands { get; set; }
    }

    public class InviCommand
    {
        public int Id { get; set; }

        public string DeviceId { get; set; }
        public virtual CommandBody CommandBody { get; set; }
        public string Value;
    }

    public class CommandBody
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public string Name { get; set; }
    }

    public class VisualInviCommandClass
    {
        public string name { get; set; }
        public Page page { get; set; }
    }
}
