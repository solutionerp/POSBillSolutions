using POSBill.Domain.Models;
using POSBill.EntityFramework;
using RestaurantRetailPOSBill.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
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
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace RestaurantRetailPOSBill.WPF.Views
{
    /// <summary>
    /// Interaction logic for POSBillView.xaml
    /// </summary>
    public partial class POSBillView : UserControl
    {
        DataTable dataTable = new DataTable("MyTable");
        public POSBillView()
        {
            InitializeComponent();
           // LoadgridPos();

        }
        #region LoadgridPos
        //public void LoadgridPos()
        //{
        //    try
        //    {
        //        dataTable.Columns.Clear();
        //        dataTable.Columns.Add("ItemName", typeof(string));
        //        dataTable.Columns.Add("Quantity", typeof(int));
        //        dataTable.Columns.Add("Price", typeof(int));
        //        dataTable.Columns.Add("Discount", typeof(int));
        //        dataTable.Columns.Add("Total", typeof(int));
        //        //dataSet.Tables.Add(dataTable);
        //        myDataGrid.ItemsSource = dataTable.DefaultView;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("An Exception Occured", ex);
        //    }
      //  }
        #endregion

        #region AutoCompleteTextBox_PreviewKeyDown
        private void AutoCompleteTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            var viewModel = DataContext as POSBIllViewModel;
            var popup = SuggestionsPopup;
            if (e.Key == Key.Escape)
            {
                SuggestionsPopup.IsOpen = false;
                e.Handled = true;
            }
            else
            {
                if (viewModel != null && popup != null)
                {
                    if (e.Key == Key.Down)
                    {

                        if (popup.IsOpen == false && viewModel.Suggestions.Count > 0)
                        {
                            popup.IsOpen = true;
                            Keyboard.Focus(popup.Child as ListBox);
                        }
                        else if (popup.IsOpen == true)
                        {
                            var listBox = popup.Child as ListBox;
                            if (listBox != null && listBox.SelectedIndex < viewModel.Suggestions.Count - 1)
                            {
                                listBox.SelectedIndex++;
                            }
                        }
                        e.Handled = true;
                    }
                    else if (e.Key == Key.Up)
                    {
                        if (popup.IsOpen == true)
                        {
                            var listBox = popup.Child as ListBox;
                            if (listBox != null && listBox.SelectedIndex > 0)
                            {
                                listBox.SelectedIndex--;
                            }
                            else if (listBox != null && listBox.SelectedIndex == 0)
                            {
                                popup.IsOpen = false;
                                Keyboard.Focus(sender as TextBox);
                            }
                        }
                        e.Handled = true;
                    }
                    else if (e.Key == Key.Enter)
                    {
                        e.Handled = false;
                        viewModel.LoadGridData();
                        if (popup.IsOpen == true && viewModel.SelectedSuggestion != null)
                        {
                            e.Handled = true;
                            viewModel.Query = viewModel.SelectedSuggestion;
                            popup.IsOpen = false;
                            Keyboard.Focus(sender as TextBox);
                        }
                       
                    }
                }
            }
        } 
        #endregion

        #region AutoCompleteTextBox_TextChanged
        private async void AutoCompleteTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var ViewModel = DataContext as POSBIllViewModel;
            if (string.IsNullOrEmpty(AutoCompleteTextBox.Text))
            {
                SuggestionsPopup.IsOpen = false;
            }
            else
            {
                string strsearchData = AutoCompleteTextBox.Text;
                DataSet datasetuggestion =  ViewModel.loadSearchData(strsearchData);
                if (null != datasetuggestion.Tables[0].Rows)
                {
                    ViewModel.FilteredSuggestions.Clear();
                }
                if (datasetuggestion.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in datasetuggestion.Tables[0].Rows)
                    {
                        string strSuggestion = row["item_code"].ToString() + "- " + row["description"].ToString();
                        if (!ViewModel.FilteredSuggestions.Contains(strSuggestion))
                        {
                            ViewModel.FilteredSuggestions.Add(strSuggestion);
                        }
                    }
                }
                //var filteredSuggestions = ViewModel.Suggestions.Where(s => s.StartsWith(AutoCompleteTextBox.Text, StringComparison.OrdinalIgnoreCase)).ToList();
                //foreach (var item in filteredSuggestions)
                //{
                //    ViewModel.FilteredSuggestions.Add(item);
                //}
                // Open the popup if there are any filtered suggestions
                ViewModel.AutoCompleteTextBoxText = AutoCompleteTextBox.Text;
                SuggestionsPopup.IsOpen = ViewModel.FilteredSuggestions.Any();
            }
        }
        #endregion

       
        private void DataGrid_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            var viewModel = DataContext as POSBIllViewModel;
            if (e.Row.IsSelected)
            {
                viewModel._rowSelected = true;
                viewModel._currentColum = e.Column.Header.ToString();
                viewModel._rowIndex = e.Row.GetIndex();
            }
        }

        private void POSBillDataGrid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            var viewModel = DataContext as POSBIllViewModel;
            int count = 0;

            if (e.Key == Key.Back)
            {
                viewModel.BackSpaceEvent();
            }
        }

        //private void myDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        //{

        //}

        //private void KeyboardClick(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        DataRowView selectedRow = myDataGrid.SelectedItem as DataRowView;
        //        if (selectedRow != null)
        //        {
        //            int quantity = 2; // You can modify this value as needed
        //            selectedRow["Quantity"] = quantity;
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        throw new Exception("An Exception Occured", ex);
        //    }
        //} 


    }
}
