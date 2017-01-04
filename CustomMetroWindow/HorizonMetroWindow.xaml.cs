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
using MahApps.Metro.Controls;

namespace CustomMetroWindow
{
    public partial class HorizonMetroWindow<T> : MetroWindow where T : class
    {
        public HDataGrid DisplayGrid;
        public HDataGrid SearchDataGrid;
        public HTextBox txtSearch;
        public Grid AddDataGrid;
        public Button cmdSave;
        public TabItem AddData;

        public object ScreenDataSource = Activator.CreateInstance(typeof(T));
        public NameIdListObjList DispGridData = new NameIdListObjList();
        public WindowControlFlow WinCntrl = new WindowControlFlow();
        public HUtil Util = new HUtil();
        public FetchData GetData = new FetchData("GeneralFunctions");
        public SaveData Save = new SaveData();
        public string LstName = "";
        protected string UserAccessLevel = "FULLRIGHTS";


        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            DisplayGrid = (HDataGrid)FindName("DisplayGrid");
            SearchDataGrid = (HDataGrid)FindName("SearchDataGrid");
            txtSearch = (HTextBox)FindName("txtSearch");
            AddDataGrid = (Grid)FindName("AddDataGrid");
            cmdSave = (Button)FindName("cmdSave");
            AddData = (TabItem)FindName("AddData");
        }

        public void KeyPressHandler(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Return)
                {
                    WinCntrl.ControlEnterKeyFlowHandler(sender, DisplayGrid);
                }
                else if (e.Key == Key.Back)
                {
                    WinCntrl.ControlBackKeyFlowHandler(sender, DisplayGrid, DispGridData);
                }
                else if (e.Key == Key.Down)
                {
                    WinCntrl.ControlDownArrowFlowHandler(sender, DisplayGrid);
                }
                else
                {
                    if (sender is HTextBox)
                    {
                        HTextBox cntrl = (HTextBox)sender;
                        if (cntrl.BoundToDataGrid == true)
                        {
                            //WinCntrl.FilterDTableData(cntrl, DisplayGrid, DispGridData);
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                Util.ErrLogger(Ex.Message.ToString(), this.GetType().FullName.ToString() + ":" + System.Reflection.MethodBase.GetCurrentMethod().Name); //, "frmEmployee.KeyPressHandler");
            }
        }
        public void GotFocusHandler(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender is HTextBox)
                {
                    DisplayGrid.GridRowCount = 0;
                    HTextBox Cntrl = (HTextBox)sender;
                    Cntrl.IsEmpty = false;
                    Cntrl.SelectAll();
                    if (Cntrl.BoundToDataGrid == true)
                    {
                        DispGridData.Clear();
                        DisplayGrid.GridContentName = Cntrl.GridDataName;
                        DispGridData = GetData.GetInv_Name_Id_List(Cntrl.GridDataName);
                        DisplayGrid.ItemsSource = DispGridData;
                        WinCntrl.FormatDisplayGrid(DisplayGrid);
                        //WinCntrl.FilterDTableData(Cntrl, DisplayGrid, DispGridData);
                    }
                    else
                    {
                        DispGridData.Clear();
                    }
                }
            }
            catch (Exception Ex)
            {
                Util.ErrLogger(Ex.Message.ToString(), this.GetType().FullName.ToString() + ":" + System.Reflection.MethodBase.GetCurrentMethod().Name); //, "frmEmployee.GotFocusHandler");
            }

        }
        public void SearChTexBoxKeyPressHandler(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Return)
                {
                    WinCntrl.ControlEnterKeyFlowHandler(sender, SearchDataGrid);
                }
                else if (e.Key == Key.Back)
                {
                    WinCntrl.ControlBackKeyFlowHandler(sender, SearchDataGrid, DispGridData, GetFilterStr((HTextBox)sender));
                }
                else if (e.Key == Key.Down)
                {
                    WinCntrl.ControlDownArrowFlowHandler(sender, SearchDataGrid);
                }
                else
                {
                    if (sender is HTextBox)
                    {
                        HTextBox cntrl = (HTextBox)sender;
                        if (cntrl.BoundToDataGrid == true)
                        {
                            //WinCntrl.FilterDTableData(cntrl, SearchDataGrid, DispGridData, GetFilterStr(cntrl));
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                Util.ErrLogger(Ex.Message.ToString(), this.GetType().FullName.ToString() + ":" + System.Reflection.MethodBase.GetCurrentMethod().Name); //, "frmEmployee.SearChTexBoxKeyPressHandler");
            }
        }
        public void SearchTxtBoxGotFocusHandler(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender is HTextBox)
                {
                    SearchDataGrid.GridRowCount = 0;
                    HTextBox Cntrl = (HTextBox)sender;
                    Cntrl.IsEmpty = false;
                    Cntrl.SelectAll();
                    if (Cntrl.BoundToDataGrid == true)
                    {
                        DispGridData.Clear();
                        SearchDataGrid.GridContentName = Cntrl.GridDataName;
                        //DispGridData = GetData.GetItemSearchList(Cntrl.GridDataName);
                        SearchDataGrid.ItemsSource = DispGridData;
                        SearchTxtBoxFormatDisplayGrid();
                        //WinCntrl.FilterDTableData(Cntrl, SearchDataGrid,DispGridData, GetFilterStr(Cntrl));

                    }
                    else
                    {
                        DispGridData.Clear();
                    }
                }
            }
            catch (Exception Ex)
            {
                Util.ErrLogger(Ex.Message.ToString(), this.GetType().FullName.ToString() + ":" + System.Reflection.MethodBase.GetCurrentMethod().Name); //, "frmEmployee.GotFocusHandler");
            }
        }
        public void SearchTxtBoxFormatDisplayGrid()
        {
            try
            {
                SearchDataGrid.Columns[0].Visibility = System.Windows.Visibility.Collapsed;
                SearchDataGrid.Columns[1].Visibility = System.Windows.Visibility.Collapsed;
                SearchDataGrid.Columns[2].Width = 198;
                SearchDataGrid.Columns[3].Visibility = System.Windows.Visibility.Collapsed;
                SearchDataGrid.Columns[4].Width = 198;           //Visibility = System.Windows.Visibility.Collapsed;
                SearchDataGrid.Columns[5].Visibility = System.Windows.Visibility.Collapsed;
                SearchDataGrid.Columns[6].Width = 198;          //Visibility= System.Windows.Visibility.Collapsed;


            }
            catch (Exception Ex)
            {
                Util.ErrLogger(Ex.Message.ToString(), this.GetType().FullName.ToString() + ":" + System.Reflection.MethodBase.GetCurrentMethod().Name); //, "frmEmployee.SearchTxtBoxFormatDisplayGrid");
            }
        }
        public void KeyPressHandlerDataGrid(object sender, KeyEventArgs e)
        {
            try
            {
                HTextBox txt = WinCntrl.GetSourceTextbox(AddDataGrid, DisplayGrid.GridContentName);
                if (e.Key == Key.Return)
                {
                    int PriamryDataId = 0;
                    e.Handled = true;
                    PriamryDataId = WinCntrl.DataGridEnterKeyFlowHandler(txt, DisplayGrid);
                    if (PriamryDataId != 0)
                    {
                        ReFreshScreen();
                        LoadScreenData(Convert.ToInt32(PriamryDataId), DisplayGrid.GridContentName);
                        cmdSave.Content = "Update";
                        DisplayGrid.GridContentName = string.Empty;
                        ((UIElement)txt).MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                    }
                }
                else if (e.Key == Key.Back)
                {
                    e.Handled = true;
                    DisplayGrid.IsEnterKeyPressed = true;
                    txt.Focus();
                }
            }
            catch (Exception Ex)
            {
                Util.ErrLogger(Ex.Message.ToString(), this.GetType().FullName.ToString() + ":" + System.Reflection.MethodBase.GetCurrentMethod().Name); //, "frmEmployee.KeyPressHandlerDataGrid");
            }
        }
        public void LoadScreenData(int Id, string GridContent)
        {
            //CustomerClass vm = new CustomerClass();
            FetchDataWeb GetData = new FetchDataWeb("Customer");
            ScreenDataSource = GetData.FetchService<T>("GetCustomer", Id.ToString());
            this.DataContext = ScreenDataSource;
        }
        private string GetFilterStr(HTextBox Input)
        {
            string RetStr = "";
            RetStr = "ListName like '%" + Util.Listname(Input.Text) + "%' Or Code Like '" + Input.Text + "%'";
            return RetStr;

        }
        public void KeyPressHandlerSearchDataGrid(object sender, KeyEventArgs e)
        {
            try
            {
                HTextBox txt = txtSearch;  //Util.GetSourceTextbox(SearchGrid, SearchDataGrid.GridContentName);
                if (e.Key == Key.Return)
                {
                    int PriamryDataId = 0;
                    e.Handled = true;
                    SearchDataGrid.GridContentName = "EMPLOYEE";
                    PriamryDataId = WinCntrl.DataGridEnterKeyFlowHandler(txt, SearchDataGrid);
                    if (PriamryDataId != 0)
                    {
                        LoadScreenData(Convert.ToInt32(PriamryDataId), "EMPLOYEE");
                        cmdSave.Content = "Update";
                        SearchDataGrid.GridContentName = string.Empty;
                        AddData.Focus();
                    }
                }
                else if (e.Key == Key.Back)
                {
                    e.Handled = true;
                    SearchDataGrid.IsEnterKeyPressed = true;
                    txt.Focus();
                }
            }
            catch (Exception Ex)
            {
                Util.ErrLogger(Ex.Message.ToString(), this.GetType().FullName.ToString() + ":" + System.Reflection.MethodBase.GetCurrentMethod().Name); //, "frmEmployee.KeyPressHandlerSearchDataGrid");
            }
        }
        public void ReFreshScreen()
        {
            try
            {
                ScreenDataSource = Activator.CreateInstance(typeof(T)); ;
                this.DataContext = ScreenDataSource;
            }
            catch (Exception Ex)
            {
                Util.ErrLogger(Ex.Message.ToString(), this.GetType().FullName.ToString() + ":" + System.Reflection.MethodBase.GetCurrentMethod().Name); //, "frmEmployee.ReFreshScreen");
            }
        }
        public void SaveData(object sender, RoutedEventArgs e)
        {
            object result = ScreenDataSource.GetType().GetMethod("Save").Invoke(ScreenDataSource, null);
            if (Convert.ToBoolean(result) == true) { ReFreshScreen(); };
        }
        public void CloseWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
