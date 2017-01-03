using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CustomMetroWindow
{
    class HDataGridTextColumn : DataGridTextColumn
    {
        public static RoutedCommand cmdOpenSales = new RoutedCommand();

        private void InitCommands()
        {
            cmdOpenSales.InputGestures.Add(new KeyGesture(Key.S, ModifierKeys.Control));
            //this.
        }
        private void cmdOpenSalesExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Hello");
            //ShowWindow("frmSales");
        }
    }
}
