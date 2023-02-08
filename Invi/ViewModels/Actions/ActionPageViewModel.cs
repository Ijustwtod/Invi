using HandyControl.Controls;
using Invi.Abilities.Actions;
using Invi.Abilities.Base;
using Invi.Models;
using Invi.Views.Actions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Invi.ViewModels.Actions
{
    public class ActionPageViewModel : INProp
    {

        private List<InviAction> _iaction;
        public List<InviAction> iAction
        {
            get
            {
                return _iaction;
            }
            set
            {
                _iaction = value;
                OnPropertyChanged("iAction");
            }
        }

        private List<InviAction> _favoriteIAction;
        public List<InviAction> favoriteIAction
        {
            get
            {
                return _favoriteIAction;
            }
            set
            {
                _favoriteIAction = value;
                OnPropertyChanged("favoriteIAction");
            }
        }

        private InviAction _selectedAction;
        public InviAction selectedAction
        {
            get
            {
                return _selectedAction;
            }
            set
            {
                _selectedAction = value;
                OnPropertyChanged("selectedAction");
            }
        }


        private InviAction _currentAction;
        public InviAction CurrentAction
        {
            get
            {
                return _currentAction;
            }
            set
            {
                _currentAction = value;
                OnPropertyChanged("CurrentAction");
            }
        }

        private List<InviCommand> _command;
        public List<InviCommand> Command
        {
            get
            {
                return _command;
            }
            set
            {
                _command = value;
                OnPropertyChanged("Command");
            }
        }

        private bool _isFavorite { get; set; }
        public bool isFavorite
        {
            get
            {
                return _isFavorite;
            }
            set
            {
                _isFavorite = value;
                OnPropertyChanged("isFavorite");
            }
        }

        private string _actionName;
        public string ActionName
        {
            get
            {
                return _actionName;
            }
            set
            {
                _actionName = value;
                OnPropertyChanged("ActionName");
            }
        }

        public int commansCount;
        private InviContext _context;
        public ActionPageViewModel()
        {
            commansCount = 1;
            _commandCollection = new ObservableCollection<VisualInviCommandClass>();
            _context = JsonConvert.DeserializeObject<InviContext>(Abilities.JsonAbilities.JsonReader.Read(Path.Commands));
            if (_context.InviActions == null)
                _context.InviActions = new List<InviAction>();

            commandCollection.Add(new VisualInviCommandClass { name = $"Команда {commansCount}", page = new NewCommandView(_context) });

            favoriteIAction = _context.InviActions.Where(q => q.IsFavorite == true).ToList();
            iAction = _context.InviActions.ToList();

            OnPropertyChanged("commandBodys");
            OnPropertyChanged("devices");
        }

        private ObservableCollection<VisualInviCommandClass> _commandCollection;
        public ObservableCollection<VisualInviCommandClass> commandCollection
        {
            get { return _commandCollection; }
            set { _commandCollection = value; OnPropertyChanged("CommandCollection"); }
        }

        public ICommand AddMoreCommand
        {
            get
            {
                return new DelegateСommand((obj) =>
                {
                    commansCount++;
                     commandCollection.Add(new VisualInviCommandClass { name = $"Команда {commansCount}", page = new NewCommandView(_context) });
                    OnPropertyChanged("CommandCollection");
                });
            }
        }

        public ICommand ExecuteActions
        {
            get
            {
                return new DelegateСommand(async (obj) =>
                {
                    await Task.Factory.StartNew(() =>
                    {
                        try
                        {
                           ExecuteAction.ExecAction(selectedAction);
                        }
                        catch (Exception)
                        {
                            Growl.Error("Ошибка");
                        }
                    });
                });
            }
        }


        public ICommand SaveAction
        {
            get
            {
                return new DelegateСommand((obj) =>
                {
                    var isReady = CreateActions.Add(new InviAction { Name = ActionName, IsFavorite = isFavorite }, commandCollection);
                    if (isReady)
                        Growl.Success("Готово");
                    else
                        Growl.Error("Ошибка");

                   // iAction = new InviAction { Name = ActionName,}
                    OnPropertyChanged("iAction");
                });
            }
        }
    }
}
