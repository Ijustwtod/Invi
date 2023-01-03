using Invi.ViewModels.MainDevices.DevicePropertiesViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Invi.Views.MainDevices.DevicePropertiesViews
{
    public partial class DeviceLightPropertiesView : Page
    {
        public DeviceLightPropertiesView(object sender)
        {
            InitializeComponent();
            DataContext = new DevicePropertiesViewModel(sender);
        }
    }
}
