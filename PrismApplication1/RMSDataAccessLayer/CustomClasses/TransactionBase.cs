using System;
using System.Collections.Generic;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace RMSDataAccessLayer
{
    public abstract partial class TransactionBase: ISearchItem, IDataErrorInfo
    {
        public TransactionBase()
        {
            TenderEntryEx.AssociationChanged += TenderEntryEx_AssociationChanged;
            ValidationErrorMsg = "Transaction has Errors";
            PropertyChanged += TransactionBase_PropertyChanged;
            
        }

        void TransactionBase_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "StationId") OnPropertyChanged("Station");
            if (e.PropertyName == "CashierId") OnPropertyChanged("Cashier");
            if (e.PropertyName == "CustomerId") OnPropertyChanged("Customer");
            if (e.PropertyName == "BatchId") OnPropertyChanged("Batch");

        }





        void TenderEntryEx_AssociationChanged(object sender, System.ComponentModel.CollectionChangeEventArgs e)
        {
            OnPropertyChanged("TotalTender");
            OnPropertyChanged("TotalChange");

        }
   

        public double TotalTender
        {
            get
            {
                double tx =(double) (from t in TenderEntryEx
                                       select t.CashAmount).Sum();
                return tx;
            }
            set
            {
                OnPropertyChanged("TotalTender");
                OnPropertyChanged("TotalChange");

            }
        }

        public double TotalChange => TotalTender - TotalSales;

        public double TotalSales
        {
            get
            {
                if (TransactionEntry != null)
                {
                    double t = TransactionEntry.Amount;
                    return t;
                }
                return 0;
            }
            set {
                RefreshData();
            }
        }

        public void RefreshData()
        {
            OnPropertyChanged("TotalSales");
            OnPropertyChanged("TotalTax");
            OnPropertyChanged("TotalDiscount");
            OnPropertyChanged("TotalTender");
            OnPropertyChanged("TotalChange");
            TransactionEntry.RefreshData();
        }

        public double TotalTax
        {
            get
            {
                if (TransactionEntry?.SalesTax != null) return (double) TransactionEntry?.SalesTax;
                return 0;
            }
        }

        public double TotalDiscount
        {
            get
            {
                var valueOrDefault = TransactionEntry?.Discount.GetValueOrDefault();
                if (valueOrDefault != null)
                    return (double) valueOrDefault;
                return 0;
            }
        }


       
       public string SearchCriteria
        {
            get { return TransactionNumber ; }
            set
            {
            }
        }

        public string DisplayName
        {
            get { return "TransactionList"; }
        }

        public string Key
        {
            get { return "TransactionList"; }
        }


        #region "Validation"
        Dictionary<string, string> m_validationErrors = new Dictionary<string, string>();
        public void AddError(string col, string msg)
        {
            if (!m_validationErrors.ContainsKey(col))
            {
                m_validationErrors.Add(col, msg);
            }
        }
        public void RemoveError(string col)
        {
            if (m_validationErrors.ContainsKey(col))
            {
                m_validationErrors.Remove(col);
            }
        }
        public string ValidationErrorMsg { get; set; }
        public virtual string Error
        {
            get 
            {
                if (m_validationErrors.Count > 0)
                {
                    return ValidationErrorMsg;
                }
                else
                {
                    return null;
                }
            }
        }

        public string this[string columnName]
        {
            get 
            {
                if (m_validationErrors.ContainsKey(columnName))
                {
                    return m_validationErrors[columnName];
                }
                else
                {
                    return null;
                }
            }
        }

        #endregion

    }

}
