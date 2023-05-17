using Microsoft.EntityFrameworkCore.Query.Internal;
using POSBill.Domain.Models;
using POSBill.EntityFramework;
using RestaurantRetailPOSBill.WPF.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace RestaurantRetailPOSBill.WPF.ViewModels
{
    public class POSBIllViewModel : ViewModelBase
    {
        #region MemberVarible
        
        public ICommand ScanQRCodeCommand { get; }
        private string _qrCodeText;
        private POSBillDbManager _pOSBillDbManager;
        private string _deliverChargeText = "0.00";
        private string _SubTotalText;
        private string _taxTotal = "0.00";
        private string _discountText;
        private string _totalOrderText = "0.00";
        private string _tenderText = "0.00";
        public decimal Number { get; set; }
        public RelayCommand NumberButtonCommand { get;  set; }
        public RelayCommand CashInCommand { get; set; }
        public RelayCommand NumberButtonCommandTwo { get; set; }
        public RelayCommand NumberButtonCommandThree { get; set; }
        public RelayCommand NumberButtonCommandFour { get; set; }
        public RelayCommand NumberButtonCommandFive { get; set; }
        public RelayCommand NumberButtonCommandSix { get; set; }
        public RelayCommand NumberButtonCommandSeven { get; set; }
        public RelayCommand NumberButtonCommandEight { get; set; }
        public RelayCommand NumberButtonCommandNine { get; set; }
        public RelayCommand NumberButtonCommandZero { get; set; }
        public RelayCommand DecimalButtonCommandDoubleZero { get; set; }
        public ICommand DecimalButtonCommand { get; set; }
        public ICommand ClearButtonCommand { get; set; }
        private string _query;
        public ObservableCollection<string> _suggestions;
        public ObservableCollection<string> _FilteredSuggestions;
        public string _strSelectedSuggestion;
        public string _selectedSuggestion;
        public string _autoCompeleteTextBox;
        public string _currentColum;
        public bool _rowSelected = false;
        public int _rowIndex;
        public double _mPrice;
        public bool KeyBackSpace = false;
        public string _textBoxGridData;
        public string _itemName;
        public string _quantity;
        public string _discount;
        public string _Total;
        public string m_subTotal;
        #endregion


        public ObservableCollection<POSBillGrid> GridData { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get;set; }
        public int Price { get; set; }
        public string Discount { get;set; }
        public int Total { get; set; }

        public string AutoCompleteTextBoxText
        {
            get
            {
                return _autoCompeleteTextBox;
            }
            set
            {
                _autoCompeleteTextBox = value;
                OnPropertyChanged(nameof(AutoCompleteTextBoxText));
            }
        }

        #region TextBlockTextProperties
        public string TenderText
        {
            get
            {
                return _tenderText;

            }
            set
            {
                _tenderText = value;
                OnPropertyChanged(nameof(TenderText));
            }
        }
        public string TotalOrderText
        {
            get
            {
                return _totalOrderText;
            }
            set
            {
                _totalOrderText = value;
                OnPropertyChanged(nameof(TotalOrderText));
            }
        }
        public string DiscountText
        {
            get { return _discountText; }
            set
            {
                _discountText = value;
                OnPropertyChanged(nameof(DiscountText));
            }
        }
        public string TaxText
        {
            get
            {
                return _taxTotal;
            }
            set
            {
                _taxTotal = value;
                OnPropertyChanged(nameof(TaxText));
            }
        }

        public string SubTotalText
        {
            get { return _SubTotalText; }
            set
            {
                _SubTotalText = value;
                OnPropertyChanged(nameof(SubTotalText));
            }
        }
        public string DeliverChargeText
        {
            get { return _deliverChargeText; }
            set
            {
                _deliverChargeText = value;
                OnPropertyChanged(nameof(DeliverChargeText));
            }
        }
        public string SearchText
        {
            get { return _qrCodeText; }
            set
            {
                _qrCodeText = value;
                OnPropertyChanged(nameof(SearchText));
            }
        }
        #endregion

        private int _selectedItem;
        public int SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
               // OnPropertyChanged();
            }
        }

        public string GridTextBoxDataProperty
        {
            get
            {
                return _textBoxGridData;
            }
            set
            {
                _textBoxGridData = value;
            }
        }


        #region Construtor
        public POSBIllViewModel()
        {
            try
            {
                _pOSBillDbManager = new POSBillDbManager();
                // FilteredSuggestions = new ObservableCollection<string>();
                FilteredSuggestions = new ObservableCollection<string>();
                Suggestions = new ObservableCollection<string>();
                NumberButtonCommand = new RelayCommand(NumberButtonCommandOne);
                NumberButtonCommandTwo = new RelayCommand(NumberButtonTwo);
                NumberButtonCommandThree = new RelayCommand(NumberButtonThree);
                NumberButtonCommandFour = new RelayCommand(NumberButtonFour);
                NumberButtonCommandFive = new RelayCommand(NumberButtonFive);
                NumberButtonCommandSix = new RelayCommand(NumberButtonSix);
                NumberButtonCommandSeven = new RelayCommand(NumberButtonSeven);
                NumberButtonCommandEight = new RelayCommand(NumberButtonEight);
                NumberButtonCommandNine = new RelayCommand(NumberButtonNine);
                NumberButtonCommandZero = new RelayCommand(NumberButtonZero);
                DecimalButtonCommandDoubleZero = new RelayCommand(NumberButtonDoubleZero);
                CashInCommand = new RelayCommand(ButtonCashIn);
                SubTotalText = "0.0";
                DiscountText = "0.00";
                GridData = new ObservableCollection<POSBillGrid>();
            }
          
            catch(Exception ex)
            {
                throw new Exception("An Exception Occured", ex);
            }
            // PosBillGrid = LoadGridData();
        }
        #endregion

        #region ButtonCashIn
        public void ButtonCashIn()
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw new Exception("An Exception Occured", ex);
            }
        } 
        #endregion

        #region BackSpaceEvent
        public void BackSpaceEvent()
        {
            try
            {
                if (_currentColum == "ItemName")
                {

                }
                else if (_currentColum == "Quantity")
                {
                    

                }
                else if (_currentColum == "Price")
                {
                    double price = GridData[_rowIndex].Price;
                    string priceString = price.ToString();
                    string updatedPriceString = priceString.Substring(0, priceString.Length - 1);
                    if(updatedPriceString  != "")
                    {
                        double updatedPrice = double.Parse(updatedPriceString);
                        // Assign the updated price to the GridData
                        GridData[_rowIndex].Price = updatedPrice;
                        price = updatedPrice;
                        
                    }
                    else
                    {
                        GridData[_rowIndex].Price = 0;
                        price = GridData[_rowIndex].Price;
                    }
                    int iquantity = GridData[_rowIndex].Quantity;
                    int iRowTotal = Convert.ToInt16(iquantity * price);
                    string strDisCount = GridData[_rowIndex].Discount;
                    strDisCount = strDisCount.Replace("%", "");
                    double dicountValue = Convert.ToDouble(strDisCount);
                    double discountedPrice = iRowTotal * (1 - dicountValue / 100);
                    int total = Convert.ToInt32(iquantity * discountedPrice);
                    GridData[_rowIndex].Total = total;
                    iRowTotal = GridData[_rowIndex].Total;

                }
                else if (_currentColum == "Discount")
                {
                    //double dDisCount = GridData[_rowIndex].Discount;
                    string dDisCount = GridData[_rowIndex].Discount; ;
                    if (dDisCount.Contains("%"))
                    {
                        dDisCount = dDisCount.Replace("%", "");
                    }
                    string updatedPriceString = dDisCount.Substring(0, dDisCount.Length - 1);
                    if (updatedPriceString != "")
                    {
                        double updatedDiscound= double.Parse(updatedPriceString);
                        // Assign the updated price to the GridData
                        GridData[_rowIndex].Discount = updatedDiscound.ToString();
                        dDisCount = updatedDiscound.ToString();

                    }
                    else
                    {
                        GridData[_rowIndex].Discount = "";
                        dDisCount = GridData[_rowIndex].Discount;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An Exception Occured", ex);
            }
        } 
        #endregion

        #region loadGridColums
        //public void loadGridColums()
        //{
        //    GridData.Columns.Add("ItemName", typeof(string));
        //    GridData.Columns.Add("Quantity", typeof(int));
        //    GridData.Columns.Add("Price", typeof(int));
        //    GridData.Columns.Add("Discount", typeof(int));
        //    GridData.Columns.Add("Total", typeof(int));
        //}
        #endregion

        #region POSBillCalculation
        public void POSBillCalculation(int iqty)
        {
            try
            {
                POSBillGrid pOSBillGrid = new POSBillGrid();
                double iPrice = 0;
                double strSubTotal = GridData[_rowIndex].Total;
                int iquantity = GridData[_rowIndex].Quantity;
                int iRowTotal = GridData[_rowIndex].Total;

                double isubtotal = Convert.ToDouble(SubTotalText);
                isubtotal = isubtotal - iRowTotal;
                SubTotalText = isubtotal.ToString();
                if (_currentColum == "ItemName")
                {

                }
                else if (_currentColum == "Quantity")
                {
                    
                    iPrice = GridData[_rowIndex].Price;
                    iquantity = iqty;
                    GridData[_rowIndex].Quantity = iquantity;
                    string strDisCount = GridData[_rowIndex].Discount;
                    if(strDisCount != null)
                    {
                        strDisCount = strDisCount.Replace("%", "");
                    }
                    double dicountValue = Convert.ToDouble(strDisCount);
                   //double dicountValue = Convert.ToDouble(GridData[_rowIndex].Discount);
                    double discountedPrice = iRowTotal * (1 - dicountValue / 100);
                    int total = Convert.ToInt32(iquantity * discountedPrice);
                    GridData[_rowIndex].Total = total;
                    iRowTotal = GridData[_rowIndex].Total;
                    strSubTotal = iRowTotal;
                }
                else if (_currentColum == "Price")
                {

                    iPrice = GridData[_rowIndex].Price;
                    int iNewPrice = iqty;
                    string strPriceGrid = iPrice.ToString();
                    string steNewPrice = iNewPrice.ToString();
                    string strNewPriceGrid = strPriceGrid + steNewPrice;
                    GridData[_rowIndex].Price =Convert.ToDouble(strNewPriceGrid);
                    iPrice = GridData[_rowIndex].Price;
                    iRowTotal = Convert.ToInt32(iquantity * iPrice);
                    string strDisCount = GridData[_rowIndex].Discount;
                    if (strDisCount != null)
                    {
                        strDisCount = strDisCount.Replace("%", "");
                    }
                 //   strDisCount = strDisCount.Replace("%", "");
                    double dicountValue = Convert.ToDouble(strDisCount);
                    double discountedPrice = iRowTotal * (1 - dicountValue / 100);
                    int total = Convert.ToInt32(iquantity * discountedPrice);
                    GridData[_rowIndex].Total = total;
                    iRowTotal = GridData[_rowIndex].Total;
                    double i_subTotal = Convert.ToDouble(m_subTotal);

                    if (i_subTotal != 0)
                    {
                        iRowTotal = GridData[_rowIndex].Total;
                        isubtotal = Convert.ToDouble(SubTotalText);
                        i_subTotal = iRowTotal;
                        strSubTotal = i_subTotal ;
                    }


                } 
                else if (_currentColum == "Discount")
                {
                   
                    string strDisCountNew = iqty.ToString();
                    string strDisCount = GridData[_rowIndex].Discount;
                    if(strDisCount.Contains("%"))
                    {
                        strDisCount = strDisCount.Replace("%", "");
                    }
                    if(strDisCount != "")
                    {
                        Double idiscountROw = Convert.ToDouble(strDisCount);
                        if (idiscountROw == 0)
                        {
                            strDisCount = "";
                        }
                    }
                    strDisCount = strDisCount+  strDisCountNew ;
                    GridData[_rowIndex].Discount = strDisCount;
                   // strDisCount = GridData[_rowIndex].Discount;
                    double dicountValue =Convert.ToDouble(strDisCount);
                    iquantity = GridData[_rowIndex].Quantity;
                    double discountedPrice = iRowTotal * (1 - dicountValue / 100);
                    int total = Convert.ToInt32(iquantity * discountedPrice);
                    GridData[_rowIndex].Total = total;
                    iRowTotal = GridData[_rowIndex].Total;
                    double discount = (dicountValue / iRowTotal) * 100;
                    string discountPercentage = strDisCount + "%"; 
                    GridData[_rowIndex].Discount = discountPercentage;

                    iPrice = GridData[_rowIndex].Price;
                    double ddisCountAmount = iPrice - iRowTotal;
                    double dDiscountTxt = Convert.ToDouble(DiscountText);
                    double dDiscountNewText = ddisCountAmount + dDiscountTxt;
                    DiscountText = dDiscountNewText.ToString();
                    strSubTotal =  total;
                }
                int strRowTotalGrid = 0;
                double im_subTotal = Convert.ToDouble(m_subTotal);
               // string strDisCountRowtxt = GridData[_rowIndex].Discount;
                double dDiscountText = Convert.ToDouble(DiscountText);
                double ddDiscountNewText = dDiscountText;
                //if (strDisCountRowtxt != null)
                //{
                //    strDisCountRowtxt = strDisCountRowtxt.Replace("%", "");
                //    double dDicount = Convert.ToDouble(strDisCountRowtxt);
                //}


                if (im_subTotal == 0)
                {
                    SubTotalText = GridData[_rowIndex].Total.ToString();
                    DiscountText = ddDiscountNewText.ToString();
                }
                else
                {
                    isubtotal = Convert.ToDouble(SubTotalText);
                    if (GridData.Count == 1)
                    {
                        isubtotal = 0;
                    }
                    strSubTotal = strSubTotal + isubtotal;
                    SubTotalText = strSubTotal.ToString();
                }
               
            }
            catch (Exception ex)
            {
                throw new Exception("An Exception Occured", ex);
            }
           
        } 
        #endregion

        #region NumberPadEvennts
        public void NumberButtonCommandOne()
        {
            try
            {
                int iquantity = 1;
                if(_rowSelected == true)
                {
                    POSBillCalculation(iquantity);
                }
                //SubTotalText = "200Ax";
            }
            catch (Exception ex)
            {
                throw new Exception("An Exception Occured", ex);
            }
        }
        public void NumberButtonTwo()
        {
            try
            {
                int iquantity = 2;
                if (_rowSelected == true)
                {
                    POSBillCalculation(iquantity);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An Exception Occured", ex);
            }
        }

        public void NumberButtonThree()
        {
            try
            {
                int iquantity = 3;
                if (_rowSelected == true)
                {
                    POSBillCalculation(iquantity);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An Exception Occured", ex);
            }
        }

        public void NumberButtonFour()
        {
            try
            {
                int iquantity = 4;
                if (_rowSelected == true)
                {
                    POSBillCalculation(iquantity);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An Exception Occured", ex);
            }
        }
        public void NumberButtonFive()
        {
            try
            {
                int iquantity = 5;
                if (_rowSelected == true)
                {
                    POSBillCalculation(iquantity);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An Exception Occured", ex);
            }
        }
        public void NumberButtonSix()
        {
            try
            {
                int iquantity = 6;
                if (_rowSelected == true)
                {
                    POSBillCalculation(iquantity);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An Exception Occured", ex);
            }
        }
        public void NumberButtonSeven()
        {
            try
            {
                int iquantity = 7;
                if (_rowSelected == true)
                {
                    POSBillCalculation(iquantity);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An Exception Occured", ex);
            }
        }
        public void NumberButtonEight()
        {
            try
            {
                int iquantity = 8;
                if (_rowSelected == true)
                {
                    POSBillCalculation(iquantity);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An Exception Occured", ex);
            }
        }
        public void NumberButtonNine()
        {
            try
            {
                int iquantity = 9;
                if (_rowSelected == true)
                {
                    POSBillCalculation(iquantity);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An Exception Occured", ex);
            }
        } 

        public void NumberButtonZero()
        {
            try
            {
                int iquantity = 0;
                if (_rowSelected == true)
                {
                    POSBillCalculation(iquantity);
                }
            }
            catch(Exception ex)
            {
                throw new Exception("An Exception Occured", ex);
            }
        }

        public void NumberButtonDoubleZero()
        {
            try
            {
                string strFirstZero = "0";
                string strSecondZero = "0";
                string strDoubleZero = strFirstZero + strSecondZero;
                int iquantity =Convert.ToInt16(strDoubleZero);
                //if (_currentColum == "ItemName")
                //{

                //}
                //else if (_currentColum == "Quantity")
                //{

                //}
                //else if (_currentColum == "Price")
                //{
                //    GridData[_rowIndex].Price = strDoubleZero
                //}
                //else if (_currentColum == "Discount")
                //{

                //}

                if (_rowSelected == true)
                {
                    POSBillCalculation(iquantity);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An Exception Occured", ex);
            }
        }
        #endregion

        #region loadSearchData
        public DataSet loadSearchData(string strSearchdata)
        {
            try
            {
                DataSet datasetsuggestion = _pOSBillDbManager.SelectStockItems(strSearchdata);
                if (datasetsuggestion.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in datasetsuggestion.Tables[0].Rows)
                    {
                        string strSuggestion = row["item_code"].ToString() +"- "+ row["description"].ToString();
                        Suggestions = new ObservableCollection<string>();
                        _suggestions.Add(strSuggestion);
                        Suggestions.CollectionChanged += OnSuggestionsChanged;
                    }
                }
                return datasetsuggestion;
            }
            catch (Exception ex)
            {
                throw new Exception("An Exception Occured", ex);
            }
        }
        #endregion

        #region LoadGridDataegion
        public void LoadGridData()
        {
            try
            {
              //  DataTable dataTable = new DataTable("MyTable");
                POSBillDbManager pOSBillDbManager = new POSBillDbManager();
                POSBillGrid pOSBillGrid = new POSBillGrid();
                string strSelectedData = _selectedSuggestion;
                string strtext = AutoCompleteTextBoxText;
                string[] parts = new string[0];
                decimal dPrice = 0;
                int iQuantity = 1;
                int iDiscount = 0;
                int iTotal = 0;
                string strCurrency = "";
                decimal dFactor = 0;
                int iSalesTypeId = 0;
                DateTime date = DateTime.Now;
                bool std = false;
                string strItemName = "";
                string iItemcode = "";
                if (strSelectedData != null)
                {
                    if (strSelectedData.Contains("-"))
                    {
                        parts = strSelectedData.Split('-');
                        strItemName = parts[1];
                        iItemcode = parts[0];
                    }
                }
                else
                {
                    if (strtext != "")
                    {
                        iItemcode = strtext;
                        DataSet dataSetItemName = pOSBillDbManager.GetItemNameByItemCode(iItemcode);
                        if (dataSetItemName.Tables[0].Rows.Count > 0)
                        {
                            strItemName = dataSetItemName.Tables[0].Rows[0]["description"].ToString();
                        }
                    }
                }
                string strPos = ViewModelBase.userVm.strPos;
                //DataSet dataSet = viewModel.loadSearchData(iItemcode);
                DataSet dataSet = new DataSet();
                DataSet datSetCurr = pOSBillDbManager.GetCompanyCurrency();
                if (datSetCurr != null)
                {
                    strCurrency = datSetCurr.Tables[0].Rows[0]["value"].ToString();
                }
                DataSet dataSetSalesTypeId = pOSBillDbManager.GetSalesTypeId(strPos);
                if (dataSetSalesTypeId.Tables[0].Rows.Count > 0)
                {
                    int iPriceList = Convert.ToInt16(dataSetSalesTypeId.Tables[0].Rows[0]["price_list"]);
                    if (iPriceList != 0)
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
                }
                dPrice = GetKitPrice(iItemcode, strCurrency, iSalesTypeId, dFactor, date, std);
                pOSBillGrid.ItemName = strItemName;
                pOSBillGrid.Quantity = iQuantity;
                pOSBillGrid.Price = Convert.ToDouble(dPrice);
                pOSBillGrid.Discount = iDiscount.ToString();
                pOSBillGrid.Total = Convert.ToInt32(dPrice);
                GridData.Add(pOSBillGrid);
                //  _SubTotalText = GridData[_rowIndex].Total + _SubTotalText;
                if (pOSBillGrid.Total !=0 )
                {
                    int strRowTotalGrid = pOSBillGrid.Total;
                    string strSubTotaltxt = SubTotalText;
                    double iSubTotaltxt = Convert.ToDouble(strSubTotaltxt);
                    double iSubTotal = strRowTotalGrid + iSubTotaltxt;
                    string strSubTotal = iSubTotal.ToString();
                    SubTotalText = strSubTotal;
                }
                m_subTotal = SubTotalText;
                double dDiscount =Convert.ToDouble(pOSBillGrid.Discount);
                double dDiscountTxt = Convert.ToDouble(DiscountText);
                double ddDiscountText = dDiscountTxt + dDiscount;
                DiscountText = ddDiscountText.ToString();
                int rowCount = GridData.Count;
                TotalOrderText = rowCount.ToString();
                AutoCompleteTextBoxText = "";
            }
            catch (Exception ex)
            {
                throw new Exception("An Exception Occured", ex);
            }
        }

        #endregion


        #region ObservableCollection
        public ObservableCollection<string> FilteredSuggestions
        {
            get => _FilteredSuggestions;
            set
            {
                _FilteredSuggestions = value;
                OnPropertyChanged(nameof(Suggestions));
            }
        }
        public ObservableCollection<string> Suggestions
        {
            get => _suggestions;
            set
            {
                _suggestions = value;
                OnPropertyChanged(nameof(Suggestions));
            }
        }
        #endregion 

        #region OnSuggestionsChanged
        private void OnSuggestionsChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (Suggestions.Count == 1)
            {
                SelectedSuggestion = Suggestions[0];
            }
        } 
        #endregion

        #region SelectedSuggestion
        public string SelectedSuggestion
        {
            get => _selectedSuggestion;
            set
            {
                _selectedSuggestion = value;
                saveSelectedSuggestion(_selectedSuggestion);
                OnPropertyChanged(nameof(SelectedSuggestion));
            }
        }
        #endregion

        #region saveSelectedSuggestion
        public string saveSelectedSuggestion(string strSelectedSiggestion)
        {
            try
            {
                _strSelectedSuggestion = strSelectedSiggestion;
                return _strSelectedSuggestion;
            }
            catch (Exception ex)
            {
                throw new Exception("An Exception Occured", ex);
            }
        } 
        #endregion

        #region UpdateSuggestions
        private void UpdateSuggestions()
        {
            // Here you would query your data source for suggestions based on the current Query value
            // In this sample code, we just generate some random suggestions
            var suggestions = Enumerable.Range(1, 10).Select(i => $"Suggestion {i} for {Query}").ToList();
            Suggestions.Clear();
            foreach (var suggestion in suggestions)
            {
                Suggestions.Add(suggestion);
            }
        }
        #endregion

        #region Query
        public string Query
        {
            get => _query;
            set
            {
                _query = value;
                OnPropertyChanged(nameof(Query));
                UpdateSuggestions();
            }
        }
        #endregion

        #region GetKitPrice
        public decimal GetKitPrice(string itemCode, string currency, int salesTypeId, decimal? factor = null,
                        DateTime? date = null, bool std = false)
        {
            try
            {
                decimal kitPrice = 0.00m;
                if (!std)
                {
                    kitPrice = GetPrice(itemCode, currency, salesTypeId, factor, date);

                    if (kitPrice != 0)
                    {
                        return kitPrice;
                    }
                }
                // no price for kit found, get total value of all items
                DataSet kit = _pOSBillDbManager.GetItemKit(itemCode);
                if (kit != null)
                {
                    if (kit.Tables[0].Rows.Count > 0)
                    {
                        //while (kit.Read())
                        //{
                        if (kit.Tables[0].Rows[0]["item_code"].ToString() != kit.Tables[0].Rows[0]["stock_id"].ToString())
                        {
                            // foreign/kit code
                            string strStckId = kit.Tables[0].Rows[0]["stock_id"].ToString();
                            kitPrice += decimal.Parse(kit.Tables[0].Rows[0]["quantity"].ToString()) * GetKitPrice(strStckId,
                                                                                                    currency, salesTypeId, factor, date, std);
                        }
                        else
                        {
                            // stock item
                            string iStckId = kit.Tables[0].Rows[0]["stock_id"].ToString();
                            kitPrice += decimal.Parse(kit.Tables[0].Rows[0]["quantity"].ToString()) * GetPrice(iStckId,
                                                                                                       currency, salesTypeId, factor, date);
                        }
                        //}
                    }
                }
                return kitPrice;
            }
            catch(Exception ex)
            {
                throw new Exception("An Exception Occured", ex);
            }
            
        }
        #endregion

        #region GetPrice
        public decimal GetPrice(string stockId, string currency, int salesTypeId, decimal? factor = null, DateTime? date = null)
        {
            try
            {
                int add_pct = 0;
                int base_id = 0;
                int round_to = 0;
                decimal bprice = 0;
                string home_curr = "";
                int isalesTypeId = 0;
                string currAbrev = "";
                decimal dprice = 0;
                {
                    date = DateTime.Now;
                }
                if (factor == null)
                {
                    DataSet datsetmyrow = _pOSBillDbManager.GetSalesType(salesTypeId);
                    if (datsetmyrow != null)
                    {
                        if (datsetmyrow.Tables[0].Rows.Count > 0)
                        {
                            factor = Convert.ToDecimal(datsetmyrow.Tables[0].Rows[0]["factor"]);
                        }
                    }
                }
                DataSet dataSetAddPct = _pOSBillDbManager.GetCompanyPref("add_pct");
                if (dataSetAddPct != null)
                {
                    if (dataSetAddPct.Tables[0].Rows.Count > 0)
                    {
                        add_pct = Convert.ToInt32(dataSetAddPct.Tables[0].Rows[0]["value"]);
                    }
                }
                DataSet dataSetBaseId = _pOSBillDbManager.GetBaseSalesType();
                if (dataSetBaseId != null)
                {
                    if (dataSetBaseId.Tables[0].Rows.Count > 0)
                    {
                        base_id = Convert.ToInt32(dataSetBaseId.Tables[0].Rows[0]["id"]);
                    }
                }
                DataSet datSetHomeCurr = _pOSBillDbManager.GetCompanyCurrency();
                if (datSetHomeCurr != null)
                {
                    if (datSetHomeCurr.Tables[0].Rows.Count > 0)
                    {
                        home_curr = datSetHomeCurr.Tables[0].Rows[0]["value"].ToString();
                    }
                }
                DataSet dataSetSql = _pOSBillDbManager.GetItemPrice(stockId, currency, home_curr);
                int num_rows = dataSetSql.Tables[0].Rows.Count;
                int irate = 1;

                DataSet dataSetRoundToCompanyPref = _pOSBillDbManager.GetCompanyPrefRounTo("round_to");
                Dictionary<int, Dictionary<string, decimal>> prices = new Dictionary<int, Dictionary<string, decimal>>();
                if (dataSetRoundToCompanyPref != null)
                {
                    if (dataSetRoundToCompanyPref.Tables[0].Rows.Count > 0)
                    {
                        round_to = Convert.ToInt16(dataSetRoundToCompanyPref.Tables[0].Rows[0]["value"]);
                    }
                }
                    if (dataSetSql.Tables[0].Rows.Count > 0)
                    { 
                        foreach (DataRow row in dataSetSql.Tables[0].Rows)
                        {

                             isalesTypeId = Convert.ToInt32(row["sales_type_id"]);
                             currAbrev = Convert.ToString(row["curr_abrev"]);
                             dprice = Convert.ToDecimal(row["price"]);
                        }
                    }
                         if (!prices.ContainsKey(salesTypeId))
                            {
                                prices.Add(isalesTypeId, new Dictionary<string, decimal>());
                            }
                            prices[isalesTypeId][currAbrev] = dprice;


                            if (prices.ContainsKey(salesTypeId) && prices[salesTypeId].ContainsKey(currency))
                            {
                                bprice = prices[isalesTypeId][currency];
                            }
                            else if (prices.ContainsKey(base_id) && prices[base_id].ContainsKey(currency))
                            {
                                bprice = Convert.ToDecimal(prices[base_id][currency] * factor);
                            }
                            else if (prices.ContainsKey(salesTypeId) && prices[salesTypeId].ContainsKey(home_curr))
                            {
                                bprice = prices[isalesTypeId][home_curr] / irate;
                            }
                            else if (prices.ContainsKey(base_id) && prices[base_id].ContainsKey(home_curr))
                            {
                                bprice = Convert.ToDecimal(prices[base_id][home_curr] * factor / irate);
                            }
                            else if (num_rows == 0 && add_pct != -1)
                            {
                                bprice = GetCalculatedPrice(stockId, add_pct);
                                if (currency != home_curr)
                                    bprice /= irate;
                                if (factor != 0)
                                    bprice *= Convert.ToDecimal(factor);
                            }
                      
                    if (bprice == 0)
                    {
                        return 0;
                    }
                    else if (round_to != 1)
                    {

                    }
                    else
                    {
                        const int DecimalPlaces = 2;
                        decimal roundedPrice = Math.Round(bprice, DecimalPlaces, MidpointRounding.AwayFromZero);
                        bprice = roundedPrice;
                    }
                
                return bprice;
            }
            catch (Exception ex)
            {
                throw new Exception("An Exception Occured", ex);
            }
        }
        #endregion

        #region GetCalculatedPrice
        public decimal GetCalculatedPrice(string iStockId, int iaddPct)
        {
            try
            {
                decimal dAvg = _pOSBillDbManager.GetUnitCost(iStockId);
                if (dAvg == 0)
                {
                    return 0;
                }
                decimal dPrice = dAvg * (1 + (decimal)iaddPct / 100);
                const int DecimalPlaces = 2; // round to 2 decimal places
                decimal roundedPrice = Math.Round(dPrice, DecimalPlaces, MidpointRounding.AwayFromZero);
                return roundedPrice;
            }
            catch (Exception ex)
            {
                throw new Exception("An Exception Occured", ex);
            }

        } 
        #endregion

        private decimal round2(decimal value, int decimalPlaces)
        {
            decimal power = (decimal)Math.Pow(10, decimalPlaces);
            return Math.Round(value * power, MidpointRounding.AwayFromZero) / power;
        }

       // public event PropertyChangedEventHandler PropertyChanged;
       
    }
}
