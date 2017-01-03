using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CustomMetroWindow
{
    class HCheckBox:CheckBox 
    {
        public bool DefaultState
        {
            get { return (bool)this.GetValue(DefaultStateProperty); }
            set { this.SetValue(DefaultStateProperty, value); }
        }

        public static readonly DependencyProperty DefaultStateProperty =
                DependencyProperty.Register(
                "DefaultState",
                typeof(bool),
                typeof(HCheckBox),
                new UIPropertyMetadata(false)
                );
    }
}
