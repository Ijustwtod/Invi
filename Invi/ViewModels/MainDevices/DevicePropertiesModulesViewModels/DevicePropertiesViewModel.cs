using Invi.Abilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Invi.ViewModels.MainDevices.DevicePropertiesViewModels
{
    public class DevicePropertiesViewModel : INProp
    {
        private List<CustomView> _propertiesList;
        public List<CustomView> propertiesList 
        {
            get
            {
                return _propertiesList;
            }
            set
            {
                _propertiesList = value;
                OnPropertyChanged("propertiesList");

            }
        }
        
        public DevicePropertiesViewModel(object sender) 
        {
            propertiesList = new List<CustomView>();
            var obj = sender as ListDeviceViewModel;
            var device = obj.SelectedDevice;
            var builder = new DevicePropertiesViewBuilder(device);
            var propertiesListp = builder.GetDeviceProperties();
            foreach (var item in propertiesListp)
            {
                propertiesList.Add(new CustomView() {Name = "",page = item});
                OnPropertyChanged("propertiesList");
            }
            OnPropertyChanged("propertiesList");
        }
    }
    public class CustomView 
    {
      public string Name { get; set; }
      public Page page { get; set; }

    }
}
