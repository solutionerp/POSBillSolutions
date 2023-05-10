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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace RestaurantRetailPOSBill.WPF.ViewModels
{
    public class POSBIllViewModel : ViewModelBase
    {
        #region MemberVarible
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand ScanQRCodeCommand { get; }
        private string _qrCodeText;
        private POSBillDbManager _pOSBillDbManager;
        private string _deliverChargeText = "0.00";
        private string _SubTotalText = "0.00";
        private string _taxTotal = "0.00";
        private string _discountText = "0.00";
        private string _totalOrderText = "0.00";
        private string _tenderText = "0.00";
        public decimal Number { get; set; }
        public ICommand NumberButtonCommand { get; set; }
        public ICommand DecimalButtonCommand { get; set; }
        public ICommand ClearButtonCommand { get; set; }
        private string _query;
        public ObservableCollection<string> _suggestions;
        public ObservableCollection<string> _FilteredSuggestions;
        public string _strSelectedSuggestion;
        public string _selectedSuggestion;
        private DataTable _mgridData;
        //public DataTable PosBillGrid 
        //{
        //    get
        //    {
        //        return _mgridData;
        //    }
        //    set
        //    {
        //        _mgridData = value;
        //    }
        //}
       
        #endregion

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
                OnPropertyChanged(TenderText);
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
                OnPropertyChanged(TotalOrderText);
            }
        }
        public string DiscountText
        {
            get { return _discountText; }
            set
            {
                _discountText = value;
                OnPropertyChanged(DiscountText);
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
                OnPropertyChanged(TaxText);
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

        #region Construtor
        public POSBIllViewModel()
        {
            _pOSBillDbManager = new POSBillDbManager();
            // FilteredSuggestions = new ObservableCollection<string>();
            FilteredSuggestions = new ObservableCollection<string>();
            Suggestions = new ObservableCollection<string>();
           // PosBillGrid = LoadGridData();
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
        //public DataTable LoadGridData()
        //{
        //    try
        //    {
        //        DataSet dataSet = new DataSet();
        //        // Create a new table
        //        DataTable dataTable = new DataTable("MyTable");

        //        // Add columns to the table
        //        dataTable.Columns.Add("ItemName", typeof(string));
        //        dataTable.Columns.Add("Quantity", typeof(string));
        //        dataTable.Columns.Add("Price", typeof(int));
        //        dataTable.Columns.Add("Discount", typeof(int));
        //        dataTable.Columns.Add("Total", typeof(int));

        //        // Add rows to the table

        //        dataTable.Rows.Add("MedicalGloves", 0, 0, 0, 0);
        //        dataTable.Rows.Add("Trailor Hire Charges", 0, 0, 0, 0);


        //        // Add the table to the dataset
        //        // dataSet.Tables.Add(dataTable);
        //        return dataTable;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("An Exception Occured", ex);
        //    }
        //} 
        #endregion

        #region OnPropertyChanged
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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
        
        public string saveSelectedSuggestion(string strSelectedSiggestion)
        {
            try
            {
                _strSelectedSuggestion = strSelectedSiggestion;
                return _strSelectedSuggestion;
            }
           catch(Exception ex) 
            {
                throw new Exception("An Exception Occured", ex);
            }
        }
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
                if (date == null)
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

                        foreach (DataRow row in dataSetRoundToCompanyPref.Tables[0].Rows)
                        {

                            int isalesTypeId = Convert.ToInt32(row["sales_type_id"]);
                            string currAbrev = Convert.ToString(row["curr_abrev"]);
                            decimal dprice = Convert.ToDecimal(row["price"]);

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
                        }
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

    }
}
