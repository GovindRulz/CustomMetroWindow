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
using System.ComponentModel;
using System.Data;
using System.Reflection;
using MahApps.Metro.Controls;

namespace CustomMetroWindow
{
    /// <summary>
    /// Interaction logic for frmItem.xaml
    /// </summary>
    public partial class frmCategory : HorizonMetroWindow<CustomerClass>
    {
        public frmCategory(string _UserAccessLevel)
        {
            InitializeComponent();
           
            UserAccessLevel = _UserAccessLevel;
            ReFreshScreen();
            //base.  = new CustomerClass();
            //this.DataContext = CustData;

            //this.UserAccessLevel = UserAccessLevel;
        }
        public frmCategory()
        {
            InitializeComponent();
            ReFreshScreen();
            //CustData = new CustomerClass();
            //this.DataContext = CustData;

            // this.UserAccessLevel = UserAccessLevel;
        }

        
    }
}
