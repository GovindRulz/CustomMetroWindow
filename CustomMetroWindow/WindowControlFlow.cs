using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.ComponentModel;
using System.Data;

namespace CustomMetroWindow
{
    public class WindowControlFlow
    {
        HUtil Util = new HUtil();
        public void SendTab()
        {
            KeyEventArgs e1 = new KeyEventArgs(Keyboard.PrimaryDevice, Keyboard.PrimaryDevice.ActiveSource, 0, Key.Tab);
            e1.RoutedEvent = Keyboard.KeyDownEvent;
            InputManager.Current.ProcessInput(e1);
        }
        public bool RadioButtonVal(RadioButton  Cntrl)
        {
            bool Result;
            if (Cntrl.IsChecked == true)
            {
                Result = true;
            }
            else
            {
                Result = false;
            }
            return Result;
        }
        public bool ChkBoxVal(CheckBox Cntrl)
        {
            bool Result;
            if (Cntrl.IsChecked == true)
            {
                Result = true;
            }
            else
            {
                Result = false;
            }
            return Result;
        }

        public IEnumerable<string> GetNames<T>(T obj) where T : struct
        {
            var properties = typeof(T).GetProperties();
            foreach (var propertyInfo in properties)
            {
                yield return propertyInfo.Name;
                //MessageBox.Show(propertyInfo.Name);
            }
        }
        public void ApplyDefaults(object o)
        {
            if (o.GetType() == typeof(HTextBox))
            {
                HTextBox txt = (HTextBox)o;

                if (txt.DefaultValue != string.Empty)
                {
                    if (txt.IsNumeric == true | txt.IsInteger == true)
                    {
                        if (txt.Text != txt.DefaultValue)
                        {
                            txt.Text = txt.DefaultValue;
                            txt.Tag = 0;
                        }
                    }
                    else
                    {
                        if (txt.Text != txt.DefaultValue)
                        {
                            txt.Text = txt.DefaultValue;
                            txt.Tag = txt.DefaultTagValue;
                        }
                    }
                }
                else
                {
                    if (txt.IsNumeric == false)
                    {
                        //txt.Text = "";
                        txt.Text = (txt.DefaultValue == string.Empty) ? "" : txt.DefaultValue;
                        txt.Tag = txt.DefaultTagValue;
                    }
                    else
                    {
                        txt.Text = "0.00";
                        txt.Tag = 0;
                    }
                }
            }
            else if (o.GetType() == typeof(HCheckBox))
            {
                HCheckBox chk = (HCheckBox)o;
                chk.IsChecked = chk.DefaultState;
            }
            else if (o.GetType() == typeof(HRadioButton))
            {
                HRadioButton chk = (HRadioButton)o;
                chk.IsChecked = chk.DefaultRadioState;
            }
        }
        public HTextBox GetSourceTextbox(Visual ParentCtrl, string GridDataName)
        {
            HTextBox txt = new HTextBox();
            GetChildControlsList ccChildren = new GetChildControlsList();
            foreach (object o in ccChildren.GetChildren(ParentCtrl, 5))
            {
                if (o.GetType() == typeof(HTextBox))
                {
                    HTextBox Chktxt = (HTextBox)o;
                    if (Chktxt.GridDataName == GridDataName)
                    {
                        txt = Chktxt;
                        break;
                    }
                }
            }
            return txt;
        }
        public void FilterDTableData(HTextBox Input, HDataGrid DisplayGrid, DataTable DispGridData, string FilterStr = "")
        {
            try
            {
                DisplayGrid.GridRowCount = 0;
                IBindingListView Flt = DispGridData.DefaultView;
                if (FilterStr == "")
                {
                    if (HorizonMainClass.CompanyConfig.DISABLEFUZZYSEARCH == false)
                    {
                        Flt.Filter = "ListName like '%" + Util.Listname(Input.Text) + "%' Or Code Like '" + Input.Text + "%'";
                    }
                    else
                    {
                        Flt.Filter = "ListName like '" + Util.Listname(Input.Text) + "%' Or Code Like '" + Input.Text + "%'";
                    }
                }
                else
                {
                    Flt.Filter = FilterStr;
                }

                DisplayGrid.GridRowCount = (Flt.Count);
            }
            catch (Exception Ex)
            {
                Util.ErrLogger(Ex.Message.ToString(), this.GetType().FullName.ToString() + ":" + System.Reflection.MethodBase.GetCurrentMethod().Name); //, "HUtil.FilterDTableData");
            }
        }

        public void FilterDTableDataPaySlip(HTextBox Input, HDataGrid DisplayGrid, DataTable DispGridData, string FilterStr = "")
        {
            try
            {
                DisplayGrid.GridRowCount = 0;
                IBindingListView Flt = DispGridData.DefaultView;
                if (FilterStr == "")
                {
                    if (HorizonMainClass.CompanyConfig.DISABLEFUZZYSEARCH == false)
                    {
                        Flt.Filter = "DepName like '%" + Util.Listname(Input.Text) + "%' Or LocationName Like '" + Input.Text + "%'";
                    }
                    else
                    {
                        Flt.Filter = "DepName like '" + Util.Listname(Input.Text) + "%' Or LocationName Like '" + Input.Text + "%'";
                    }
                }
                else
                {
                    Flt.Filter = FilterStr;
                }

                DisplayGrid.GridRowCount = (Flt.Count);
            }
            catch (Exception Ex)
            {
                Util.ErrLogger(Ex.Message.ToString(), this.GetType().FullName.ToString() + ":" + System.Reflection.MethodBase.GetCurrentMethod().Name); //, "HUtil.FilterDTableData");
            }
        }

        public void FormatDisplayGrid(DataGrid DisplayGrid)
        {
            try
            {

                //DisplayGrid.Columns[0].Width = 270;
                //DisplayGrid.Columns[1].Visibility = System.Windows.Visibility.Collapsed;
                //DisplayGrid.Columns[2].Visibility = System.Windows.Visibility.Collapsed;
                //DisplayGrid.Columns[3].Visibility = System.Windows.Visibility.Collapsed;
            }
            catch (Exception Ex)
            {
                Util.ErrLogger(Ex.Message.ToString(), this.GetType().FullName.ToString() + ":" + System.Reflection.MethodBase.GetCurrentMethod().Name); //, "HUtil.FormatDisplayGrid");
            }
        }

        public void ControlEnterKeyFlowHandler(Object sender, HDataGrid DisplayGrid)
        {
            if (DisplayGrid.IsEnterKeyPressed == false)
            {
                if (sender is HTextBox)
                {
                    HTextBox cntrl = (HTextBox)sender;
                    if (cntrl.IsPrimaryData != true)
                    {
                        if (cntrl.BoundToDataGrid != true)
                        {
                            if (cntrl.Text != "")
                            {
                                SendTab();
                            }
                        }
                        else
                        {
                            if (cntrl.Text != "")
                            {
                                if (DisplayGrid.GridRowCount > 0)
                                {
                                    DisplayGrid.Focus();
                                    DisplayGrid.CurrentCell = new DataGridCellInfo(DisplayGrid.Items[0], DisplayGrid.Columns[0]);
                                }
                            }
                        }
                    }
                    else
                    {
                        if (cntrl.Text != "")
                        {
                            SendTab();
                        }
                    }
                }
                else
                {
                    SendTab();
                }
            }
            else
            {
                DisplayGrid.IsEnterKeyPressed = false;
            }
        }
        public void ControlBackKeyFlowHandler(Object sender, HDataGrid DisplayGrid, NameIdListObjList DispGridData, string FilterStr = "")
        {
            if (DisplayGrid.IsBackKeyPressed == false)
            {
                if (sender is HTextBox)
                {
                    HTextBox cntrl = (HTextBox)sender;
                    if (cntrl.Text == "")
                    {
                        if (cntrl.IsEmpty == true)
                        {
                            HorizonMainClass.sendShiftTab();
                            cntrl.IsEmpty = false;
                        }
                        else
                        {
                            cntrl.IsEmpty = true;
                            if (cntrl.BoundToDataGrid == true)
                            {
                                //FilterDTableData(cntrl, DisplayGrid, DispGridData, FilterStr);
                            }
                        }
                    }
                    else
                    {
                        if (cntrl.BoundToDataGrid == true)
                        {
                            //FilterDTableData(cntrl, DisplayGrid, DispGridData, FilterStr);
                        }
                    }
                }
                else
                {
                    if (sender is DatePicker == false)
                    {
                        HorizonMainClass.sendShiftTab();
                    }
                }
            }
            else
            {
                DisplayGrid.IsBackKeyPressed = false;
            }
        }
        public void ControlDownArrowFlowHandler(Object sender, HDataGrid DisplayGrid)
        {
            if (sender is HTextBox)
            {
                if (DisplayGrid.Items.Count > 0)
                {
                    HTextBox cntrl = (HTextBox)sender;
                    if (cntrl.BoundToDataGrid == true)
                    {
                        DisplayGrid.Focus();
                        DisplayGrid.CurrentCell = new DataGridCellInfo(DisplayGrid.Items[0], DisplayGrid.Columns[0]);
                    }
                }
            }
        }
        public int DataGridEnterKeyFlowHandler(HTextBox txt, HDataGrid DisplayGrid)
        {
            int PrimaryDataId = 0;
            DisplayGrid.IsEnterKeyPressed = true;
            if (txt.IsPrimaryData == false)
            {
                NameIdListObj Dat = (NameIdListObj)DisplayGrid.SelectedItem;
                if (Dat != null)
                {
                    txt.Text = Dat.Name;
                    txt.Tag = Dat.Id;
                    DisplayGrid.GridContentName = string.Empty;
                    ((UIElement)txt).MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                }
            }
            else
            {
                if (txt.PrimaryDataName == DisplayGrid.GridContentName)
                {
                    NameIdListObj Dat = (NameIdListObj)DisplayGrid.SelectedItem;
                    if (Dat != null)
                    {
                        PrimaryDataId = Dat.Id;
                    }
                }
            }
            return PrimaryDataId;
        }
    }
}
