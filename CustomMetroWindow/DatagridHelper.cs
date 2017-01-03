using System;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Data;
using System.ComponentModel;

namespace CustomMetroWindow
{
    public class DataGridHelper
    {
        public DataGridCell GetCell(DataGridCellInfo dataGridCellInfo)
        {
            if (!dataGridCellInfo.IsValid)
            {
                return null;
            }

            var cellContent = dataGridCellInfo.Column.GetCellContent(dataGridCellInfo.Item);
            if (cellContent != null)
            {
                return (DataGridCell)cellContent.Parent;
            }
            else
            {
                return null;
            }
        }
        public int GetRowIndex(DataGridCell dataGridCell)
        {
            // Use reflection to get DataGridCell.RowDataItem property value.
            PropertyInfo rowDataItemProperty = dataGridCell.GetType().GetProperty("RowDataItem", BindingFlags.Instance | BindingFlags.NonPublic);

            DataGrid dataGrid = GetDataGridFromChild(dataGridCell);

            return dataGrid.Items.IndexOf(rowDataItemProperty.GetValue(dataGridCell, null));
        }
        public DataGrid GetDataGridFromChild(DependencyObject dataGridPart)
        {
            if (VisualTreeHelper.GetParent(dataGridPart) == null)
            {
                throw new NullReferenceException("Control is null.");
            }
            if (VisualTreeHelper.GetParent(dataGridPart) is DataGrid)
            {
                return (DataGrid)VisualTreeHelper.GetParent(dataGridPart);
            }
            else
            {
                return GetDataGridFromChild(VisualTreeHelper.GetParent(dataGridPart));
            }
        }
        public DataGridCell GetCell(int row, int column, DataGrid DataGrid_Standard)
        {
            DataGridRow rowContainer = GetRow(row, DataGrid_Standard);

            if (rowContainer != null)
            {
                DataGridCellsPresenter presenter = GetVisualChild<DataGridCellsPresenter>(rowContainer);

                // try to get the cell but it may possibly be virtualized
                DataGridCell cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(column);
                if (cell == null)
                {
                    // now try to bring into view and retreive the cell
                    DataGrid_Standard.ScrollIntoView(rowContainer, DataGrid_Standard.Columns[column]);
                    cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(column);
                }
                return cell;
            }
            return null;
        }

        public DataGridRow GetRow(int index, DataGrid DataGrid_Standard)
        {
            DataGridRow row = (DataGridRow)DataGrid_Standard.ItemContainerGenerator.ContainerFromIndex(index);
            if (row == null)
            {
                // may be virtualized, bring into view and try again
                DataGrid_Standard.ScrollIntoView(DataGrid_Standard.Items[index]);
                row = (DataGridRow)DataGrid_Standard.ItemContainerGenerator.ContainerFromIndex(index);
            }
            return row;
        }

        public DataGridRow GetSelectedRow(DataGrid grid)
        {
            return (DataGridRow)grid.ItemContainerGenerator.ContainerFromItem(grid.SelectedItem);
        }

        public DataGridRow GetRow(DataGrid grid, int index)
        {
            DataGridRow row = (DataGridRow)grid.ItemContainerGenerator.ContainerFromIndex(index);
            if (row == null)
            {
                // May be virtualized, bring into view and try again.
                grid.UpdateLayout();
                grid.ScrollIntoView(grid.Items[index]);
                row = (DataGridRow)grid.ItemContainerGenerator.ContainerFromIndex(index);
            }
            return row;
        }

        ////public static DataGridRow GetSelectedRow(this DataGrid grid)
        ////{
        ////    return (DataGridRow)grid.ItemContainerGenerator.ContainerFromItem(grid.SelectedItem);
        ////}

        public int GetFocusCell(object sender, KeyEventArgs e)
        {
            int colindex = 0;
            DependencyObject dep = (DependencyObject)e.OriginalSource;

            //Stepping through the visual tree
            while ((dep != null) && !(dep is System.Windows.Controls.DataGridCell))
            {
                dep = VisualTreeHelper.GetParent(dep);

            }

            //Is the dep a cell or outside the bounds of Window1?
            if (dep == null | !(dep is System.Windows.Controls.DataGridCell))
            {
                return 0;
            }
            else
            {
                System.Windows.Controls.DataGridCell cell = new System.Windows.Controls.DataGridCell();
                cell = (System.Windows.Controls.DataGridCell)dep;
                while ((dep != null) && !(dep is DataGridRow))
                {
                    dep = VisualTreeHelper.GetParent(dep);
                }

                if (dep == null)
                {
                    return 0;
                }
                colindex = cell.Column.DisplayIndex;  //this returns COLUMN INDEX
            }
            return colindex;
        }

        public int GetFocusColIndex(object sender, RoutedEventArgs e)
        {
            int colindex = 0;
            DependencyObject dep = (DependencyObject)e.OriginalSource;

            //Stepping through the visual tree
            while ((dep != null) && !(dep is System.Windows.Controls.DataGridCell))
            {
                dep = VisualTreeHelper.GetParent(dep);

            }

            //Is the dep a cell or outside the bounds of Window1?
            if (dep == null | !(dep is System.Windows.Controls.DataGridCell))
            {
                return 0;
            }
            else
            {
                System.Windows.Controls.DataGridCell cell = new System.Windows.Controls.DataGridCell();
                cell = (System.Windows.Controls.DataGridCell)dep;
                while ((dep != null) && !(dep is DataGridRow))
                {
                    dep = VisualTreeHelper.GetParent(dep);
                }

                if (dep == null)
                {
                    return 0;
                }
                colindex = cell.Column.DisplayIndex;  //this returns COLUMN INDEX
            }
            return colindex;
        }

        public int GetFocusRowIndex(object sender, RoutedEventArgs e)
        {
            int Rowindex = 0;
            DependencyObject dep = (DependencyObject)e.OriginalSource;

            //Stepping through the visual tree
            while ((dep != null) && !(dep is System.Windows.Controls.DataGridCell))
            {
                dep = VisualTreeHelper.GetParent(dep);

            }

            //Is the dep a cell or outside the bounds of Window1?
            if (dep == null | !(dep is System.Windows.Controls.DataGridCell))
            {
                return 0;
            }
            else
            {
                System.Windows.Controls.DataGridCell cell = new System.Windows.Controls.DataGridCell();
                cell = (System.Windows.Controls.DataGridCell)dep;
                while ((dep != null) && !(dep is DataGridRow))
                {
                    dep = VisualTreeHelper.GetParent(dep);
                }

                if (dep == null)
                {
                    return 0;
                }

                DataGridRow row = dep as DataGridRow;
                System.Windows.Controls.DataGrid dataGrid = ItemsControl.ItemsControlFromItemContainer(row) as System.Windows.Controls.DataGrid;

                Rowindex = dataGrid.ItemContainerGenerator.IndexFromContainer(row); //this returns ROW INDEX
            }
            return Rowindex;
        }

        public int FindRowIndex(DataGridRow row)
        {
            DataGrid dataGrid =
                ItemsControl.ItemsControlFromItemContainer(row)
                as DataGrid;

            int index = dataGrid.ItemContainerGenerator.
                IndexFromContainer(row);

            return index;
        }

        public int FindColIndex(DataGridColumn col)
        {

            int index = col.DisplayIndex;

            return index;
        }

        private object ExtractBoundValue(DataGridRow row, DataGridCell cell)
        {
            // find the column that this cell belongs to
            DataGridBoundColumn col =
               cell.Column as DataGridBoundColumn;

            // find the property that this column is bound to
            Binding binding = col.Binding as Binding;
            string boundPropertyName = binding.Path.Path;

            // find the object that is related to this row
            object data = row.Item;

            // extract the property value
            PropertyDescriptorCollection properties =
                TypeDescriptor.GetProperties(data);

            PropertyDescriptor property = properties[boundPropertyName];
            object value = property.GetValue(data);

            return value;
        }

        static T GetVisualChild<T>(Visual parent) where T : Visual
        {
            T child = default(T);
            int numVisuals = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < numVisuals; i++)
            {
                Visual v = (Visual)VisualTreeHelper.GetChild(parent, i);
                child = v as T;
                if (child == null)
                {
                    child = GetVisualChild<T>(v);
                }
                if (child != null)
                {
                    break;
                }
            }
            return child;
        }

        public int GetFocusCellm(object sender, MouseEventArgs e)
        {
            int colindex = 0;
            DependencyObject dep = (DependencyObject)e.OriginalSource;

            //Stepping through the visual tree
            while ((dep != null) && !(dep is System.Windows.Controls.DataGridCell))
            {
                dep = VisualTreeHelper.GetParent(dep);

            }

            //Is the dep a cell or outside the bounds of Window1?
            if (dep == null | !(dep is System.Windows.Controls.DataGridCell))
            {
                return 0;
            }
            else
            {
                System.Windows.Controls.DataGridCell cell = new System.Windows.Controls.DataGridCell();
                cell = (System.Windows.Controls.DataGridCell)dep;
                while ((dep != null) && !(dep is DataGridRow))
                {
                    dep = VisualTreeHelper.GetParent(dep);
                }

                if (dep == null)
                {
                    return 0;
                }
                colindex = cell.Column.DisplayIndex;  //this returns COLUMN INDEX
            }
            return colindex;
        }
    }
}
