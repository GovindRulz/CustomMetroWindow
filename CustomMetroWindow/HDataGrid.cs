using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CustomMetroWindow
{
    public class HDataGrid:DataGrid 
    {
        public string GridContentName
        {
            get { return (string)this.GetValue(GridContentNameProperty); }
            set { this.SetValue(GridContentNameProperty, value); }
        }

        public int GridRowCount
        {
            get { return (int)this.GetValue(GridRowCountProperty); }
            set { this.SetValue(GridRowCountProperty, value); }
        }

        public bool IsEnterKeyPressed
        {
            get { return (bool)this.GetValue(IsEnterKeyPressedProperty); }
            set { this.SetValue(IsEnterKeyPressedProperty, value); }
        }

        public bool IsBackKeyPressed
        {
            get { return (bool)this.GetValue(IsBackKeyPressedProperty); }
            set { this.SetValue(IsBackKeyPressedProperty, value); }
        }

        public static readonly DependencyProperty IsBackKeyPressedProperty =
        DependencyProperty.Register(
        "IsBackKeyPressed",
        typeof(bool),
        typeof(HDataGrid),
        new UIPropertyMetadata(false)
        );

        public static readonly DependencyProperty IsEnterKeyPressedProperty =
        DependencyProperty.Register(
        "IsEnterKeyPressed",
        typeof(bool),
        typeof(HDataGrid),
        new UIPropertyMetadata(false)
        );

        public static readonly DependencyProperty GridContentNameProperty =
        DependencyProperty.Register(
        "GridContentName",
        typeof(string),
        typeof(HDataGrid),
        new UIPropertyMetadata(string.Empty)
        );

        public static readonly DependencyProperty GridRowCountProperty =
        DependencyProperty.Register(
        "GridRowCount",
        typeof(int),
        typeof(HDataGrid),
        new UIPropertyMetadata(0)
        );
    }
}
