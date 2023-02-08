using Invi.Abilities.Actions;
using Invi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Invi.Models.YandexSmartHomeRoot;

namespace Invi.ViewModels.Actions
{
    public class CommandAddViewModel : INProp
    {
        private InviCommand _command;
        public InviCommand Command
        {
            get => _command;
            set
            {
                _command = value;
                OnPropertyChanged("Command");
            }
        }

        private List<InviDevice> _deviceList;
        public List<InviDevice> deviceList
        {
            get => _deviceList;
            set { _deviceList = value; OnPropertyChanged("deviceList"); }
        }
        private List<CommandBody> _commandBody;
        public List<CommandBody> commandBody { get => _commandBody; set { _commandBody = value; OnPropertyChanged("commandBody"); } }
        private InviDevice _currentDevice;
        public InviDevice CurrentDevice
        {
            get => _currentDevice;
            set
            {
                _currentDevice = value;
                OnPropertyChanged("CurrentDevice");
            }
        }
        private CommandBody _currentcommandBody;
        public CommandBody CurrentCommandBody
        {
            get => _currentcommandBody;
            set
            {
                _currentcommandBody = value;
                OnPropertyChanged("CurrentCommandBody");
            }
        }
        InviContext _context;
        public CommandAddViewModel(object sender)
        {
            _context = sender as InviContext;
            commandBody = _context.CommandBodies ?? FillCommandBody.FillCommandBodies();

            deviceList = _context.InviDevices;
            OnPropertyChanged("deviceList");
            OnPropertyChanged("commandBody");
        }
    }
}
