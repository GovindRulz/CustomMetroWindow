using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MahApps.Metro;
using MahApps.Metro.Controls;

namespace CustomMetroWindow
{
     public class HTextBox : TextBox
    {
        public HTextBox() : base() { }
        
        public bool BoundToDataGrid
        {
            get { return (bool)this.GetValue(BoundToDataGridProperty); }
            set { this.SetValue(BoundToDataGridProperty, value); }
        }

        public string GridDataName
        {
            get { return (string)this.GetValue(GridDataNameProperty); }
            set { this.SetValue(GridDataNameProperty, value); }
        }

        public bool IsPrimaryData
        {
            get { return (bool)this.GetValue(IsPrimaryDataProperty); }
            set { this.SetValue(IsPrimaryDataProperty, value); }
        }

        public string PrimaryDataName
        {
            get { return (string)this.GetValue(PrimaryDataProperty); }
            set { this.SetValue(PrimaryDataProperty, value); }
        }

        public bool IsNumeric
        {
            get { return (bool)this.GetValue(IsNumericProperty); }
            set { this.SetValue(IsNumericProperty, value); }
        }

        public bool IsInteger
        {
            get { return (bool)this.GetValue(IsNumericProperty); }
            set { this.SetValue(IsNumericProperty, value); }
        }

        public string DefaultValue
        {
            get { return (string)this.GetValue(DefaultValueProperty); }
            set { this.SetValue(DefaultValueProperty, value); }
        }

        public int DefaultTagValue
        {
            get { return (int)this.GetValue(DefaultTagValueProperty); }
            set { this.SetValue(DefaultTagValueProperty, value); }
        }

        public bool IsEmpty
        {
            get { return (bool)this.GetValue(IsEmptyProperty); }
            set { this.SetValue(IsEmptyProperty, value); }
        }

        public static readonly DependencyProperty IsEmptyProperty =
        DependencyProperty.Register(
        "IsEmpty",
        typeof(bool),
        typeof(HTextBox),
        new UIPropertyMetadata(false)
        );
        //DefaultTagValue
        public static readonly DependencyProperty DefaultTagValueProperty =
        DependencyProperty.Register(
        "DefaultTagValue",
        typeof(int),
        typeof(HTextBox),
        new UIPropertyMetadata(1)
        );

        public static readonly DependencyProperty DefaultValueProperty =
        DependencyProperty.Register(
        "DefaultValue",
        typeof(string),
        typeof(HTextBox),
        new UIPropertyMetadata(string.Empty)
        );

        public static readonly DependencyProperty IsIntegerProperty =
        DependencyProperty.Register(
        "IsInteger",
        typeof(bool),
        typeof(HTextBox),
        new UIPropertyMetadata(false)
        );

        public static readonly DependencyProperty IsNumericProperty =
        DependencyProperty.Register(
        "IsNumeric",
        typeof(bool),
        typeof(HTextBox),
        new UIPropertyMetadata(false)
        );

        public static readonly DependencyProperty BoundToDataGridProperty =
        DependencyProperty.Register(
        "BoundToDataGrid",
        typeof(bool),
        typeof(HTextBox),
        new UIPropertyMetadata(false)
        );

        public static readonly DependencyProperty IsPrimaryDataProperty =
        DependencyProperty.Register(
        "IsPrimaryData",
        typeof(bool),
        typeof(HTextBox),
        new UIPropertyMetadata(false)
        );

        public static readonly DependencyProperty GridDataNameProperty =
        DependencyProperty.Register(
        "GridDataName",
        typeof(string),
        typeof(HTextBox),
        new UIPropertyMetadata(string.Empty)
        );

        public static readonly DependencyProperty PrimaryDataProperty =
        DependencyProperty.Register(
        "PrimaryDataName",
        typeof(string),
        typeof(HTextBox),
        new UIPropertyMetadata(string.Empty)
        );

        ////protected override void TextChanged(System.Windows.Controls.TextChangedEventArgs e)
        ////{
        ////    base.Text = LeaveOnlyNumbers(Text);
        ////}

        protected override void OnPreviewTextInput(System.Windows.Input.TextCompositionEventArgs e)
        {
            if (this.IsNumeric == true)
            {
                e.Handled = !AreAllValidNumericChars(e.Text);
                base.OnPreviewTextInput(e);
            }
        }

        bool AreAllValidNumericChars(string str)
        {
            bool ret = true;
            if (this.IsNumeric == true)
            {
                if (str == System.Globalization.NumberFormatInfo.CurrentInfo.CurrencyDecimalSeparator |
                    str == System.Globalization.NumberFormatInfo.CurrentInfo.CurrencyGroupSeparator |
                    str == System.Globalization.NumberFormatInfo.CurrentInfo.CurrencySymbol |
                    str == System.Globalization.NumberFormatInfo.CurrentInfo.NegativeSign |
                    str == System.Globalization.NumberFormatInfo.CurrentInfo.NegativeInfinitySymbol |
                    str == System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator |
                    str == System.Globalization.NumberFormatInfo.CurrentInfo.NumberGroupSeparator |
                    str == System.Globalization.NumberFormatInfo.CurrentInfo.PercentDecimalSeparator |
                    str == System.Globalization.NumberFormatInfo.CurrentInfo.PercentGroupSeparator |
                    str == System.Globalization.NumberFormatInfo.CurrentInfo.PercentSymbol |
                    str == System.Globalization.NumberFormatInfo.CurrentInfo.PerMilleSymbol |
                    str == System.Globalization.NumberFormatInfo.CurrentInfo.PositiveInfinitySymbol |
                    str == System.Globalization.NumberFormatInfo.CurrentInfo.PositiveSign)
                    return ret;
            }

            int l = str.Length;
            for (int i = 0; i < l; i++)
            {
                char ch = str[i];
                ret &= Char.IsDigit(ch);
            }

            return ret;
        }

        ////new public String Text
        ////{
        ////    get { return base.Text; }
        ////    set
        ////    {
        ////        base.Text = LeaveOnlyNumbers(value);
        ////    }
        ////}
        
        ////private bool IsNumberKey(Key inKey)
        ////{
        ////    if (inKey < Key.D0 || inKey > Key.D9)
        ////    {
        ////        if (inKey < Key.NumPad0 || inKey > Key.NumPad9)
        ////        {
        ////            return false;
        ////        }
        ////    }
        ////    return true;
        ////}
 
        ////private bool IsActionKey(Key inKey)
        ////{
        ////    return inKey == Key.Delete || inKey == Key.Back || inKey == Key.Tab || inKey == Key.Return || Keyboard.Modifiers.HasFlag(ModifierKeys.Alt);
        ////}
 
        ////private string LeaveOnlyNumbers(String inString)
        ////{
        ////    String tmp = inString;
        ////    foreach (char c in inString.ToCharArray())
        ////    {
        ////        if (!IsDigit(c))
        ////        {
        ////            tmp = tmp.Replace(c.ToString(), "");
        ////        }
        ////    }
        ////    return tmp;
        ////}
 
        ////public bool IsDigit(char c)
        ////{
        ////    return (c >= '0' && c <= '9');
        ////}

    }
}
