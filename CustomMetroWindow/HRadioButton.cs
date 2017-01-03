using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CustomMetroWindow
{
    class HRadioButton:RadioButton 
    {
        static bool m_bIsChanging = false;

        public HRadioButton()
        {
            this.Checked += new RoutedEventHandler(RadioButtonExtended_Checked);
            this.Unchecked += new RoutedEventHandler(RadioButtonExtended_Unchecked);
        }

        public bool DefaultRadioState
        {
            get { return (bool)this.GetValue(DefaultRadioStateProperty); }
            set { this.SetValue(DefaultRadioStateProperty, value); }
        }

        void RadioButtonExtended_Unchecked(object sender, RoutedEventArgs e)
        {
            if (!m_bIsChanging)
                this.IsCheckedReal = false;
        }

        void RadioButtonExtended_Checked(object sender, RoutedEventArgs e)
        {
            if (!m_bIsChanging)
                this.IsCheckedReal = true;
        }

        public bool? IsCheckedReal
        {
            get { return (bool?)GetValue(IsCheckedRealProperty); }
            set
            {
                SetValue(IsCheckedRealProperty, value);
            }
        }

        public static readonly DependencyProperty DefaultRadioStateProperty =
                DependencyProperty.Register(
                "DefaultRadioState",
                typeof(bool),
                typeof(HRadioButton),
                new UIPropertyMetadata(false)
                );
        public static readonly DependencyProperty IsCheckedRealProperty =
                DependencyProperty.Register("IsCheckedReal", 
                typeof(bool?), 
                typeof(HRadioButton),
                new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.Journal |
                FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                IsCheckedRealChanged));
        
        public static void IsCheckedRealChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            m_bIsChanging = true;
            ((HRadioButton)d).IsChecked = (bool)e.NewValue;
            m_bIsChanging = false;
        }
    }
}
