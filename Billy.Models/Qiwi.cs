using System;
using System.Collections.Generic;
using System.Text;

namespace Billy.Models
{
    public class Qiwi
    {

        public class Commission
        {
            public class Post
            {
                public string account { get; set; }
                public PaymentMethod paymentMethod { get; set; }
                public PurchaseTotals purchaseTotals { get; set; }

                public class PaymentMethod
                {
                    public string type { get; set; }
                    public string accountId { get; set; }
                }

                public class PurchaseTotals
                {
                    public Total total { get; set; }

                    public class Total
                    {
                        public long amount { get; set; }
                        public string currency { get; set;}
                    }
                }
            }
        }


        public class Balance
        {
            public List<Account> accounts { get; set; }

            public class Account
            {
                public string alias { get; set; }
                public string fsAlias { get; set; }
                public string title { get; set; }
                public bool hasBalance { get; set; }
                public long currency { get; set; }
                public TypeAccount type { get; set; }
                public Balance balance { get; set; }

                public class Balance
                {
                    public long amount { get; set; }
                    public long currency { get; set; }
                }

                public class TypeAccount
                {
                    public string id { get; set; }
                    public string title { get; set; }

                }
            }
        }

        public class Payment
        {
            public List<Pay> data { get; set; }

            public class Pay
            {
                public long txnId { get; set; }
                public long personId { get; set; }
                public string date { get; set; }
                public long errorCode { get; set; }
                public string error { get; set; }
                public string type { get; set; }
                public string status { get; set; }
                public string statusText { get; set; }
                public string trmTxnId { get; set; }
                public string account { get; set; }
                public Sum sum { get; set; }
                public Commission commission { get; set; }
                public Total total { get; set; }
                public Provider provider { get; set; }
                public string comment { get; set; }
                public decimal currencyRate { get; set; }
                public object extras { get; set; }
                public bool chequeReady { get; set; }
                public bool bankDocumentAvailable { get; set; }
                public bool bankDocumentReady { get; set; }
                public bool repeatPaymentEnabled { get; set; }
                public bool favoritePaymentEnabled { get; set; }
                public bool regularPaymentEnabled { get; set; }
                public long nextTxnId { get; set; }
                public string nextTxnDate { get; set; }

                public class Total
                {
                    public decimal amount { get; set; }
                    public string currency { get; set; }

                }
                public class Provider
                {
                    public long id { get; set; }
                    public string shortName { get; set; }
                    public string longName { get; set; }
                    public string logoUrl { get; set; }
                    public string description { get; set; }
                    public string keys { get; set; }
                    public string siteUrl { get; set; }
                }

                public class Sum
                {
                    public decimal amount { get; set; }
                    public string currency { get; set; }

                }

                public class Commission
                {
                    public decimal amount { get; set; }
                    public string currency { get; set; }
                }
            }
        }

        public class Profile
        {
            public AuthInfo authInfo { get; set; }
            public ContractInfo contractInfo { get; set; }
            public UserInfo userInfo { get; set; }

            

            public class AuthInfo
            {
                public long personId { get; set; }
                public string registrationDate { get; set; }
                public string boundEmail { get; set; }
                public string ip { get; set; }
                public string lastLoginDate { get; set; }
                public MobilePinInfo mobilePinInfo { get; set; }
                public PassInfo passInfo { get; set; }
                public PinInfo pinInfo { get; set; }

                public class MobilePinInfo
                {
                    public bool mobilePinUsed { get; set; }
                    public string lastMobilePinChange { get; set; }
                    public string nextMobilePinChange { get; set; }
                }

                public class PassInfo
                {
                    public bool passwordUsed { get; set; }
                    public string lastPassChange { get; set; }
                    public string nextPassChange { get; set; }
                }

                public class PinInfo
                {
                    public bool pinUsed { get; set; }
                }
            }

            public class ContractInfo
            {
                public bool blocked { get; set; }
                public long contractId { get; set; }
                public string creationDate { get; set; }
                public List<object> features { get; set; }
                public List<object> identificationInfo { get; set; }
            }

            public class UserInfo
            {
                public long defaultPayCurrency { get; set; }
                public long defaultPaySource { get; set; }
                public string email { get; set; }
                public long firstTxnId { get; set; }
                public string language { get; set; }
                public string @operator { get; set; }
                public string phoneHash { get; set; }
                public string promoEnabled { get; set; }
            }
        }
    }
}
