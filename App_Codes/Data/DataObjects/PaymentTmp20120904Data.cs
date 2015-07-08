// ==========================================
//  Author : GNT Data Object Generator Tool
//  Created   : 2015-03-26 14:38:52
//  Copyright GNT INC.  All rights reserved.
// ==========================================
using System;
using System.Collections;
using Gnt.Data.Meta;
using Gnt.Data;

namespace BusinessObjects
{

	[Serializable]
	public class PaymentTmp20120904Data : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ136387555";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of PaymentTmp20120904 
			/// </summary>
			public PaymentTmp20120904Data(string objectID): base(objectID) {}  

			public PaymentTmp20120904Data() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field RateChange 
			/// </summary>
			public string RateChange { 
				get { return GetValue("COL13638755512"); } 
				set { SetValue("COL13638755512", value); } 
			}

			/// <summary>
			/// Gets field ModifiedBy 
			/// </summary>
			public string ModifiedBy { 
				get { return GetValue("COL13638755517"); } 
				set { SetValue("COL13638755517", value); } 
			}

			/// <summary>
			/// Gets field PaymentType 
			/// </summary>
			public string PaymentType { 
				get { return GetValue("COL1363875556"); } 
				set { SetValue("COL1363875556", value); } 
			}

			/// <summary>
			/// Gets field PaidType 
			/// </summary>
			public string PaidType { 
				get { return GetValue("COL1363875557"); } 
				set { SetValue("COL1363875557", value); } 
			}

			/// <summary>
			/// Gets field PaymentDate 
			/// </summary>
			public string PaymentDate { 
				get { return GetValue("COL1363875554"); } 
				set { SetValue("COL1363875554", value); } 
			}

			/// <summary>
			/// Gets field CustomerId 
			/// </summary>
			public string CustomerId { 
				get { return GetValue("COL1363875555"); } 
				set { SetValue("COL1363875555", value); } 
			}

			/// <summary>
			/// Gets field BuildingId 
			/// </summary>
			public string BuildingId { 
				get { return GetValue("COL1363875552"); } 
				set { SetValue("COL1363875552", value); } 
			}

			/// <summary>
			/// Gets field YearMonth 
			/// </summary>
			public string YearMonth { 
				get { return GetValue("COL1363875553"); } 
				set { SetValue("COL1363875553", value); } 
			}

			/// <summary>
			/// Gets field id 
			/// </summary>
			public string id { 
				get { return GetValue("COL1363875551"); } 
				set { SetValue("COL1363875551", value); } 
			}

			/// <summary>
			/// Gets field MoneyUSD 
			/// </summary>
			public string MoneyUSD { 
				get { return GetValue("COL13638755510"); } 
				set { SetValue("COL13638755510", value); } 
			}

			/// <summary>
			/// Gets field Modified 
			/// </summary>
			public string Modified { 
				get { return GetValue("COL13638755516"); } 
				set { SetValue("COL13638755516", value); } 
			}

			/// <summary>
			/// Gets field Paymenter 
			/// </summary>
			public string Paymenter { 
				get { return GetValue("COL1363875558"); } 
				set { SetValue("COL1363875558", value); } 
			}

			/// <summary>
			/// Gets field Receiver 
			/// </summary>
			public string Receiver { 
				get { return GetValue("COL1363875559"); } 
				set { SetValue("COL1363875559", value); } 
			}

			/// <summary>
			/// Gets field Comment 
			/// </summary>
			public string Comment { 
				get { return GetValue("COL13638755513"); } 
				set { SetValue("COL13638755513", value); } 
			}

			/// <summary>
			/// Gets field DelFlag 
			/// </summary>
			public string DelFlag { 
				get { return GetValue("COL13638755518"); } 
				set { SetValue("COL13638755518", value); } 
			}

			/// <summary>
			/// Gets field Created 
			/// </summary>
			public string Created { 
				get { return GetValue("COL13638755514"); } 
				set { SetValue("COL13638755514", value); } 
			}

			/// <summary>
			/// Gets field MoneyVND 
			/// </summary>
			public string MoneyVND { 
				get { return GetValue("COL13638755511"); } 
				set { SetValue("COL13638755511", value); } 
			}

			/// <summary>
			/// Gets field CreatedBy 
			/// </summary>
			public string CreatedBy { 
				get { return GetValue("COL13638755515"); } 
				set { SetValue("COL13638755515", value); } 
			}

			/// <summary>
			/// Gets field BookingId 
			/// </summary>
			public string BookingId { 
				get { return GetValue("COL13638755519"); } 
				set { SetValue("COL13638755519", value); } 
			}


			/// <summary>
			/// Gets RateChange attribute data 
			/// </summary>
			public AttributeData GetRateChangeAttributeData() { 
				return GetAttributeData("COL13638755512"); 
			}

			/// <summary>
			/// Gets ModifiedBy attribute data 
			/// </summary>
			public AttributeData GetModifiedByAttributeData() { 
				return GetAttributeData("COL13638755517"); 
			}

			/// <summary>
			/// Gets PaymentType attribute data 
			/// </summary>
			public AttributeData GetPaymentTypeAttributeData() { 
				return GetAttributeData("COL1363875556"); 
			}

			/// <summary>
			/// Gets PaidType attribute data 
			/// </summary>
			public AttributeData GetPaidTypeAttributeData() { 
				return GetAttributeData("COL1363875557"); 
			}

			/// <summary>
			/// Gets PaymentDate attribute data 
			/// </summary>
			public AttributeData GetPaymentDateAttributeData() { 
				return GetAttributeData("COL1363875554"); 
			}

			/// <summary>
			/// Gets CustomerId attribute data 
			/// </summary>
			public AttributeData GetCustomerIdAttributeData() { 
				return GetAttributeData("COL1363875555"); 
			}

			/// <summary>
			/// Gets BuildingId attribute data 
			/// </summary>
			public AttributeData GetBuildingIdAttributeData() { 
				return GetAttributeData("COL1363875552"); 
			}

			/// <summary>
			/// Gets YearMonth attribute data 
			/// </summary>
			public AttributeData GetYearMonthAttributeData() { 
				return GetAttributeData("COL1363875553"); 
			}

			/// <summary>
			/// Gets id attribute data 
			/// </summary>
			public AttributeData GetidAttributeData() { 
				return GetAttributeData("COL1363875551"); 
			}

			/// <summary>
			/// Gets MoneyUSD attribute data 
			/// </summary>
			public AttributeData GetMoneyUSDAttributeData() { 
				return GetAttributeData("COL13638755510"); 
			}

			/// <summary>
			/// Gets Modified attribute data 
			/// </summary>
			public AttributeData GetModifiedAttributeData() { 
				return GetAttributeData("COL13638755516"); 
			}

			/// <summary>
			/// Gets Paymenter attribute data 
			/// </summary>
			public AttributeData GetPaymenterAttributeData() { 
				return GetAttributeData("COL1363875558"); 
			}

			/// <summary>
			/// Gets Receiver attribute data 
			/// </summary>
			public AttributeData GetReceiverAttributeData() { 
				return GetAttributeData("COL1363875559"); 
			}

			/// <summary>
			/// Gets Comment attribute data 
			/// </summary>
			public AttributeData GetCommentAttributeData() { 
				return GetAttributeData("COL13638755513"); 
			}

			/// <summary>
			/// Gets DelFlag attribute data 
			/// </summary>
			public AttributeData GetDelFlagAttributeData() { 
				return GetAttributeData("COL13638755518"); 
			}

			/// <summary>
			/// Gets Created attribute data 
			/// </summary>
			public AttributeData GetCreatedAttributeData() { 
				return GetAttributeData("COL13638755514"); 
			}

			/// <summary>
			/// Gets MoneyVND attribute data 
			/// </summary>
			public AttributeData GetMoneyVNDAttributeData() { 
				return GetAttributeData("COL13638755511"); 
			}

			/// <summary>
			/// Gets CreatedBy attribute data 
			/// </summary>
			public AttributeData GetCreatedByAttributeData() { 
				return GetAttributeData("COL13638755515"); 
			}

			/// <summary>
			/// Gets BookingId attribute data 
			/// </summary>
			public AttributeData GetBookingIdAttributeData() { 
				return GetAttributeData("COL13638755519"); 
			}


			/// <summary>
			/// Gets column RateChange with alias  
			/// </summary>
			public string ColRateChange { 
				get { return GetColumnName("COL13638755512"); } 
			}

			/// <summary>
			/// Gets column ModifiedBy with alias  
			/// </summary>
			public string ColModifiedBy { 
				get { return GetColumnName("COL13638755517"); } 
			}

			/// <summary>
			/// Gets column PaymentType with alias  
			/// </summary>
			public string ColPaymentType { 
				get { return GetColumnName("COL1363875556"); } 
			}

			/// <summary>
			/// Gets column PaidType with alias  
			/// </summary>
			public string ColPaidType { 
				get { return GetColumnName("COL1363875557"); } 
			}

			/// <summary>
			/// Gets column PaymentDate with alias  
			/// </summary>
			public string ColPaymentDate { 
				get { return GetColumnName("COL1363875554"); } 
			}

			/// <summary>
			/// Gets column CustomerId with alias  
			/// </summary>
			public string ColCustomerId { 
				get { return GetColumnName("COL1363875555"); } 
			}

			/// <summary>
			/// Gets column BuildingId with alias  
			/// </summary>
			public string ColBuildingId { 
				get { return GetColumnName("COL1363875552"); } 
			}

			/// <summary>
			/// Gets column YearMonth with alias  
			/// </summary>
			public string ColYearMonth { 
				get { return GetColumnName("COL1363875553"); } 
			}

			/// <summary>
			/// Gets column id with alias  
			/// </summary>
			public string Colid { 
				get { return GetColumnName("COL1363875551"); } 
			}

			/// <summary>
			/// Gets column MoneyUSD with alias  
			/// </summary>
			public string ColMoneyUSD { 
				get { return GetColumnName("COL13638755510"); } 
			}

			/// <summary>
			/// Gets column Modified with alias  
			/// </summary>
			public string ColModified { 
				get { return GetColumnName("COL13638755516"); } 
			}

			/// <summary>
			/// Gets column Paymenter with alias  
			/// </summary>
			public string ColPaymenter { 
				get { return GetColumnName("COL1363875558"); } 
			}

			/// <summary>
			/// Gets column Receiver with alias  
			/// </summary>
			public string ColReceiver { 
				get { return GetColumnName("COL1363875559"); } 
			}

			/// <summary>
			/// Gets column Comment with alias  
			/// </summary>
			public string ColComment { 
				get { return GetColumnName("COL13638755513"); } 
			}

			/// <summary>
			/// Gets column DelFlag with alias  
			/// </summary>
			public string ColDelFlag { 
				get { return GetColumnName("COL13638755518"); } 
			}

			/// <summary>
			/// Gets column Created with alias  
			/// </summary>
			public string ColCreated { 
				get { return GetColumnName("COL13638755514"); } 
			}

			/// <summary>
			/// Gets column MoneyVND with alias  
			/// </summary>
			public string ColMoneyVND { 
				get { return GetColumnName("COL13638755511"); } 
			}

			/// <summary>
			/// Gets column CreatedBy with alias  
			/// </summary>
			public string ColCreatedBy { 
				get { return GetColumnName("COL13638755515"); } 
			}

			/// <summary>
			/// Gets column BookingId with alias  
			/// </summary>
			public string ColBookingId { 
				get { return GetColumnName("COL13638755519"); } 
			}


			/// <summary>
			/// Checks whether column RateChange is added in select statement 
			/// </summary>
			public bool IsSelectRateChange { 
				get { return IsSelect("COL13638755512"); } 
				set { SetSelect("COL13638755512", value); } 
			}

			/// <summary>
			/// Checks whether column ModifiedBy is added in select statement 
			/// </summary>
			public bool IsSelectModifiedBy { 
				get { return IsSelect("COL13638755517"); } 
				set { SetSelect("COL13638755517", value); } 
			}

			/// <summary>
			/// Checks whether column PaymentType is added in select statement 
			/// </summary>
			public bool IsSelectPaymentType { 
				get { return IsSelect("COL1363875556"); } 
				set { SetSelect("COL1363875556", value); } 
			}

			/// <summary>
			/// Checks whether column PaidType is added in select statement 
			/// </summary>
			public bool IsSelectPaidType { 
				get { return IsSelect("COL1363875557"); } 
				set { SetSelect("COL1363875557", value); } 
			}

			/// <summary>
			/// Checks whether column PaymentDate is added in select statement 
			/// </summary>
			public bool IsSelectPaymentDate { 
				get { return IsSelect("COL1363875554"); } 
				set { SetSelect("COL1363875554", value); } 
			}

			/// <summary>
			/// Checks whether column CustomerId is added in select statement 
			/// </summary>
			public bool IsSelectCustomerId { 
				get { return IsSelect("COL1363875555"); } 
				set { SetSelect("COL1363875555", value); } 
			}

			/// <summary>
			/// Checks whether column BuildingId is added in select statement 
			/// </summary>
			public bool IsSelectBuildingId { 
				get { return IsSelect("COL1363875552"); } 
				set { SetSelect("COL1363875552", value); } 
			}

			/// <summary>
			/// Checks whether column YearMonth is added in select statement 
			/// </summary>
			public bool IsSelectYearMonth { 
				get { return IsSelect("COL1363875553"); } 
				set { SetSelect("COL1363875553", value); } 
			}

			/// <summary>
			/// Checks whether column id is added in select statement 
			/// </summary>
			public bool IsSelectid { 
				get { return IsSelect("COL1363875551"); } 
				set { SetSelect("COL1363875551", value); } 
			}

			/// <summary>
			/// Checks whether column MoneyUSD is added in select statement 
			/// </summary>
			public bool IsSelectMoneyUSD { 
				get { return IsSelect("COL13638755510"); } 
				set { SetSelect("COL13638755510", value); } 
			}

			/// <summary>
			/// Checks whether column Modified is added in select statement 
			/// </summary>
			public bool IsSelectModified { 
				get { return IsSelect("COL13638755516"); } 
				set { SetSelect("COL13638755516", value); } 
			}

			/// <summary>
			/// Checks whether column Paymenter is added in select statement 
			/// </summary>
			public bool IsSelectPaymenter { 
				get { return IsSelect("COL1363875558"); } 
				set { SetSelect("COL1363875558", value); } 
			}

			/// <summary>
			/// Checks whether column Receiver is added in select statement 
			/// </summary>
			public bool IsSelectReceiver { 
				get { return IsSelect("COL1363875559"); } 
				set { SetSelect("COL1363875559", value); } 
			}

			/// <summary>
			/// Checks whether column Comment is added in select statement 
			/// </summary>
			public bool IsSelectComment { 
				get { return IsSelect("COL13638755513"); } 
				set { SetSelect("COL13638755513", value); } 
			}

			/// <summary>
			/// Checks whether column DelFlag is added in select statement 
			/// </summary>
			public bool IsSelectDelFlag { 
				get { return IsSelect("COL13638755518"); } 
				set { SetSelect("COL13638755518", value); } 
			}

			/// <summary>
			/// Checks whether column Created is added in select statement 
			/// </summary>
			public bool IsSelectCreated { 
				get { return IsSelect("COL13638755514"); } 
				set { SetSelect("COL13638755514", value); } 
			}

			/// <summary>
			/// Checks whether column MoneyVND is added in select statement 
			/// </summary>
			public bool IsSelectMoneyVND { 
				get { return IsSelect("COL13638755511"); } 
				set { SetSelect("COL13638755511", value); } 
			}

			/// <summary>
			/// Checks whether column CreatedBy is added in select statement 
			/// </summary>
			public bool IsSelectCreatedBy { 
				get { return IsSelect("COL13638755515"); } 
				set { SetSelect("COL13638755515", value); } 
			}

			/// <summary>
			/// Checks whether column BookingId is added in select statement 
			/// </summary>
			public bool IsSelectBookingId { 
				get { return IsSelect("COL13638755519"); } 
				set { SetSelect("COL13638755519", value); } 
			}



	}
}