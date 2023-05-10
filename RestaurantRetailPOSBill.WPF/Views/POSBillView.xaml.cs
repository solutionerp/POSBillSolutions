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
            LoadgridPos();

        }
        #region LoadgridPos
        public void LoadgridPos()
        {
            try
            {
                dataTable.Columns.Clear();
                dataTable.Columns.Add("ItemName", typeof(string));
                dataTable.Columns.Add("Quantity", typeof(int));
                dataTable.Columns.Add("Price", typeof(int));
                dataTable.Columns.Add("Discount", typeof(int));
                dataTable.Columns.Add("Total", typeof(int));
                //dataSet.Tables.Add(dataTable);
                myDataGrid.ItemsSource = dataTable.DefaultView;
            }
            catch (Exception ex)
            {
                throw new Exception("An Exception Occured", ex);
            }
        }
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
                            try
                            {
                            POSBillDbManager pOSBillDbManager = new POSBillDbManager();
                            string strSelectedData =viewModel._selectedSuggestion;
                            string[] parts = strSelectedData.Split('-');
                            string strItemName = parts[1];
                            decimal dPrice =0;
                            int iQuantity = 0;
                            int iDiscount = 0;
                            int iTotal = 0;
                            string iItemcode = parts[0];
                            string strCurrency = "";
                            decimal dFactor = 0;
                            int iSalesTypeId = 0;
                            DateTime date = DateTime.Now;
                            bool std = false;
                            User user = new User();
                            string strUsername = ViewModelBase.strUsernameVM;
                            string strPassweord = ViewModelBase.strPasswordVM;
                            string strPos = user.strPos;
                            //DataSet dataSet = viewModel.loadSearchData(iItemcode);
                            DataSet dataSet = new DataSet();
                             DataSet datSetCurr = pOSBillDbManager.GetCompanyCurrency();
                            if(datSetCurr != null) 
                            {
                                strCurrency = datSetCurr.Tables[0].Rows[0]["value"].ToString();
                            }
                            DataSet dataSetSalesTypeId = pOSBillDbManager.GetSalesTypeId(strPos);
                            if (dataSetSalesTypeId.Tables[0].Rows.Count > 0 ) 
                            {
                                iSalesTypeId = Convert.ToInt16(dataSetSalesTypeId.Tables[0].Rows[0]["price_list"]);
                            }
                            else
                            {
                                DataSet datasetSalesTypeIdDeptMaster = pOSBillDbManager.GetSalesTypeIdDeoptMaster(strPos);
                                if (datasetSalesTypeIdDeptMaster.Tables[0].Rows.Count > 0)
                                {
                                    iSalesTypeId = Convert.ToInt16(datasetSalesTypeIdDeptMaster.Tables[0].Rows[0]["sales_type"]);
                                }
                            }
                           dPrice = viewModel.GetKitPrice(iItemcode, strCurrency, iSalesTypeId, dFactor, date, std);
                            dataTable.Rows.Add(strItemName, iQuantity, dPrice, iDiscount, iTotal);
                            myDataGrid.ItemsSource = dataTable.DefaultView;
                            }
                            catch (Exception ex)
                            {
                                throw new Exception("An Exception Occured", ex);
                            }
                        
                        if (popup.IsOpen == true && viewModel.SelectedSuggestion != null)
                        {
                            viewModel.Query = viewModel.SelectedSuggestion;
                            popup.IsOpen = false;
                            Keyboard.Focus(sender as TextBox);
                        }
                        e.Handled = true;
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
                SuggestionsPopup.IsOpen = ViewModel.FilteredSuggestions.Any();
            }
        }
        #endregion

        #region PosDataGridLoaded
        private void PosDataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                myDataGrid.Columns[0].Width = new DataGridLength(30, DataGridLengthUnitType.Star); // 30% of available space for first column
                myDataGrid.Columns[1].Width = new DataGridLength(20, DataGridLengthUnitType.Star); // 20% of available space for second column
                myDataGrid.Columns[2].Width = new DataGridLength(20, DataGridLengthUnitType.Star); // 20% of available space for third column
                myDataGrid.Columns[3].Width = new DataGridLength(15, DataGridLengthUnitType.Star); // 15% of available space for fourth column
                myDataGrid.Columns[4].Width = new DataGridLength(15, DataGridLengthUnitType.Star); // 15% of available space for fifth column
                myDataGrid.RowHeight = 30;
            }
            catch (Exception ex)
            {
                throw new Exception("An Exception Occured", ex);
            }
        } 
        #endregion
    }
}
