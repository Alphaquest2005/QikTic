using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace RMSDataAccessLayer
{
   public abstract partial class TransactionEntryBase:IDataErrorInfo
    {
       public  TransactionEntryBase()
       {
           PropertyChanged += TransactionEntryBase__propertyChanged;
           ValidationErrorMsg = "Entry has Errors";
            
   }

       void TransactionEntryBase__propertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
       {
           if (e.PropertyName == "Quantity" || e.PropertyName == "Price" || e.PropertyName == "Discount" || e.PropertyName == "SalesTaxPercent" || e.PropertyName == "Taxable")
           {
               Transaction?.RefreshData();
           }

           if (e.PropertyName == "ItemId")
           {
               OnPropertyChanged("Item");
           }
       
        
       }

       public void RefreshData()
       {
           OnPropertyChanged("SalesTax");
           OnPropertyChanged("Amount");
       }

       public virtual int Quantity => 1;
       public virtual double Amount
        {
            get
            {
                var d = Quantity*Price - Discount.GetValueOrDefault();
                if (d != null) return (double) d;
                return 0;
            }
        }

       decimal salestax = 0;
       //if tax is not manually set return calculated tax
        public double SalesTax
        {
            get
            {

                if (Amount != 0 && SalesTaxPercent != 0 && Taxable == true)
                {
                    return Amount - (Amount / (1 + SalesTaxPercent));
                }
                else
                {
                     return 0;
                }
               
              
            }
            set
            {
                SalesTaxPercent = value;
            }
        }

        RMSModel db = new RMSModel();

        public string DiscountCodeEx
        {
            get
            {
                return DiscountCode;
            }
            set
            {
                DiscountCode = value;

                // find existing discountcode
                DiscountCoupon coup = (from c in db.DiscountCoupons
                                       where c.DiscountCode == DiscountCode
                                       select c).FirstOrDefault();
                if (coup == null)
                {
                    coup = (from c in db.DiscountCoupons
                            where c.Default == true
                            select c).FirstOrDefault();
                }

                if (coup != null)
                {
                    Discount = coup.Amount;
                }
                OnPropertyChanged("DiscountCodeEx");
            }
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

        string IDataErrorInfo.this[string columnName]
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
