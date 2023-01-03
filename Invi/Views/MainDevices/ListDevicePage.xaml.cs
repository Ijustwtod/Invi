using Invi.ViewModels.MainDevices;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Invi.Views.MainDevices
{
    public partial class ListDevicePage : Page
    {
        public ListDevicePage()
        {
            InitializeComponent();
            
        }
        void OnMouseEnter(object sender, MouseEventArgs e)
        {
            var b = (FrameworkElement)sender;
            var item = b.DataContext;
            Console.WriteLine($"Mouse entered: {item}");
        }

        void OnMouseLeave(object sender, MouseEventArgs e)
        {
            var b = (FrameworkElement)sender;
            var item = b.DataContext;
            Console.WriteLine($"Mouse left: {item}");
        }
    }
}
