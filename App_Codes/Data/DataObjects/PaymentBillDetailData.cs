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
	public class PaymentBillDetailData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ843866073";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of PaymentBillDetail 
			/// </summary>
			public PaymentBillDetailData(string objectID): base(objectID) {}  

			public PaymentBillDetailData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field YearMonth 
			/// </summary>
			public string YearMonth { 
				get { return GetValue("COL8438660734"); } 
				set { SetValue("COL8438660734", value); } 
			}

			/// <summary>
			/// Gets field BillDate 
			/// </summary>
			public string BillDate { 
				get { return GetValue("COL8438660735"); } 
				set { SetValue("COL8438660735", value); } 
			}

			/// <summary>
			/// Gets field UsdExchangeDate 
			/// </summary>
			public string UsdExchangeDate { 
				get { return GetValue("COL8438660736"); } 
				set { SetValue("COL8438660736", value); } 
			}

			/// <summary>
			/// Gets field UsdExchange 
			/// </summary>
			public string UsdExchange { 
				get { return GetValue("COL8438660737"); } 
				set { SetValue("COL8438660737", value); } 
			}

			/// <summary>
			/// Gets field PaidUSD 
			/// </summary>
			public string PaidUSD { 
				get { return GetValue("COL84386607313"); } 
				set { SetValue("COL84386607313", value); } 
			}

			/// <summary>
			/// Gets field BuildingId 
			/// </summary>
			public string BuildingId { 
				get { return GetValue("COL8438660732"); } 
				set { SetValue("COL8438660732", value); } 
			}

			/// <summary>
			/// Gets field CustomerId 
			/// </summary>
			public string CustomerId { 
				get { return GetValue("COL8438660733"); } 
				set { SetValue("COL8438660733", value); } 
			}

			/// <summary>
			/// Gets field PaidVND 
			/// </summary>
			public string PaidVND { 
				get { return GetValue("COL84386607314"); } 
				set { SetValue("COL84386607314", value); } 
			}

			/// <summary>
			/// Gets field ModifiedBy 
			/// </summary>
			public string ModifiedBy { 
				get { return GetValue("COL84386607319"); } 
				set { SetValue("COL84386607319", value); } 
			}

			/// <summary>
			/// Gets field MoneyVND 
			/// </summary>
			public string MoneyVND { 
				get { return GetValue("COL84386607311"); } 
				set { SetValue("COL84386607311", value); } 
			}

			/// <summary>
			/// Gets field BillYearMonth 
			/// </summary>
			public string BillYearMonth { 
				get { return GetValue("COL84386607321"); } 
				set { SetValue("COL84386607321", value); } 
			}

			/// <summary>
			/// Gets field ExchangeMoneyVND 
			/// </summary>
			public string ExchangeMoneyVND { 
				get { return GetValue("COL84386607312"); } 
				set { SetValue("COL84386607312", value); } 
			}

			/// <summary>
			/// Gets field CreatedBy 
			/// </summary>
			public string CreatedBy { 
				get { return GetValue("COL84386607317"); } 
				set { SetValue("COL84386607317", value); } 
			}

			/// <summary>
			/// Gets field Modified 
			/// </summary>
			public string Modified { 
				get { return GetValue("COL84386607318"); } 
				set { SetValue("COL84386607318", value); } 
			}

			/// <summary>
			/// Gets field MoneyUSD 
			/// </summary>
			public string MoneyUSD { 
				get { return GetValue("COL84386607310"); } 
				set { SetValue("COL84386607310", value); } 
			}

			/// <summary>
			/// Gets field DelFlag 
			/// </summary>
			public string DelFlag { 
				get { return GetValue("COL84386607320"); } 
				set { SetValue("COL84386607320", value); } 
			}

			/// <summary>
			/// Gets field Comment 
			/// </summary>
			public string Comment { 
				get { return GetValue("COL84386607315"); } 
				set { SetValue("COL84386607315", value); } 
			}

			/// <summary>
			/// Gets field id 
			/// </summary>
			public string id { 
				get { return GetValue("COL8438660731"); } 
				set { SetValue("COL8438660731", value); } 
			}

			/// <summary>
			/// Gets field PaymentType 
			/// </summary>
			public string PaymentType { 
				get { return GetValue("COL8438660738"); } 
				set { SetValue("COL8438660738", value); } 
			}

			/// <summary>
			/// Gets field ExchangeType 
			/// </summary>
			public string ExchangeType { 
				get { return GetValue("COL8438660739"); } 
				set { SetValue("COL8438660739", value); } 
			}

			/// <summary>
			/// Gets field Created 
			/// </summary>
			public string Created { 
				get { return GetValue("COL84386607316"); } 
				set { SetValue("COL84386607316", value); } 
			}


			/// <summary>
			/// Gets YearMonth attribute data 
			/// </summary>
			public AttributeData GetYearMonthAttributeData() { 
				return GetAttributeData("COL8438660734"); 
			}

			/// <summary>
			/// Gets BillDate attribute data 
			/// </summary>
			public AttributeData GetBillDateAttributeData() { 
				return GetAttributeData("COL8438660735"); 
			}

			/// <summary>
			/// Gets UsdExchangeDate attribute data 
			/// </summary>
			public AttributeData GetUsdExchangeDateAttributeData() { 
				return GetAttributeData("COL8438660736"); 
			}

			/// <summary>
			/// Gets UsdExchange attribute data 
			/// </summary>
			public AttributeData GetUsdExchangeAttributeData() { 
				return GetAttributeData("COL8438660737"); 
			}

			/// <summary>
			/// Gets PaidUSD attribute data 
			/// </summary>
			public AttributeData GetPaidUSDAttributeData() { 
				return GetAttributeData("COL84386607313"); 
			}

			/// <summary>
			/// Gets BuildingId attribute data 
			/// </summary>
			public AttributeData GetBuildingIdAttributeData() { 
				return GetAttributeData("COL8438660732"); 
			}

			/// <summary>
			/// Gets CustomerId attribute data 
			/// </summary>
			public AttributeData GetCustomerIdAttributeData() { 
				return GetAttributeData("COL8438660733"); 
			}

			/// <summary>
			/// Gets PaidVND attribute data 
			/// </summary>
			public AttributeData GetPaidVNDAttributeData() { 
				return GetAttributeData("COL84386607314"); 
			}

			/// <summary>
			/// Gets ModifiedBy attribute data 
			/// </summary>
			public AttributeData GetModifiedByAttributeData() { 
				return GetAttributeData("COL84386607319"); 
			}

			/// <summary>
			/// Gets MoneyVND attribute data 
			/// </summary>
			public AttributeData GetMoneyVNDAttributeData() { 
				return GetAttributeData("COL84386607311"); 
			}

			/// <summary>
			/// Gets BillYearMonth attribute data 
			/// </summary>
			public AttributeData GetBillYearMonthAttributeData() { 
				return GetAttributeData("COL84386607321"); 
			}

			/// <summary>
			/// Gets ExchangeMoneyVND attribute data 
			/// </summary>
			public AttributeData GetExchangeMoneyVNDAttributeData() { 
				return GetAttributeData("COL84386607312"); 
			}

			/// <summary>
			/// Gets CreatedBy attribute data 
			/// </summary>
			public AttributeData GetCreatedByAttributeData() { 
				return GetAttributeData("COL84386607317"); 
			}

			/// <summary>
			/// Gets Modified attribute data 
			/// </summary>
			public AttributeData GetModifiedAttributeData() { 
				return GetAttributeData("COL84386607318"); 
			}

			/// <summary>
			/// Gets MoneyUSD attribute data 
			/// </summary>
			public AttributeData GetMoneyUSDAttributeData() { 
				return GetAttributeData("COL84386607310"); 
			}

			/// <summary>
			/// Gets DelFlag attribute data 
			/// </summary>
			public AttributeData GetDelFlagAttributeData() { 
				return GetAttributeData("COL84386607320"); 
			}

			/// <summary>
			/// Gets Comment attribute data 
			/// </summary>
			public AttributeData GetCommentAttributeData() { 
				return GetAttributeData("COL84386607315"); 
			}

			/// <summary>
			/// Gets id attribute data 
			/// </summary>
			public AttributeData GetidAttributeData() { 
				return GetAttributeData("COL8438660731"); 
			}

			/// <summary>
			/// Gets PaymentType attribute data 
			/// </summary>
			public AttributeData GetPaymentTypeAttributeData() { 
				return GetAttributeData("COL8438660738"); 
			}

			/// <summary>
			/// Gets ExchangeType attribute data 
			/// </summary>
			public AttributeData GetExchangeTypeAttributeData() { 
				return GetAttributeData("COL8438660739"); 
			}

			/// <summary>
			/// Gets Created attribute data 
			/// </summary>
			public AttributeData GetCreatedAttributeData() { 
				return GetAttributeData("COL84386607316"); 
			}


			/// <summary>
			/// Gets column YearMonth with alias  
			/// </summary>
			public string ColYearMonth { 
				get { return GetColumnName("COL8438660734"); } 
			}

			/// <summary>
			/// Gets column BillDate with alias  
			/// </summary>
			public string ColBillDate { 
				get { return GetColumnName("COL8438660735"); } 
			}

			/// <summary>
			/// Gets column UsdExchangeDate with alias  
			/// </summary>
			public string ColUsdExchangeDate { 
				get { return GetColumnName("COL8438660736"); } 
			}

			/// <summary>
			/// Gets column UsdExchange with alias  
			/// </summary>
			public string ColUsdExchange { 
				get { return GetColumnName("COL8438660737"); } 
			}

			/// <summary>
			/// Gets column PaidUSD with alias  
			/// </summary>
			public string ColPaidUSD { 
				get { return GetColumnName("COL84386607313"); } 
			}

			/// <summary>
			/// Gets column BuildingId with alias  
			/// </summary>
			public string ColBuildingId { 
				get { return GetColumnName("COL8438660732"); } 
			}

			/// <summary>
			/// Gets column CustomerId with alias  
			/// </summary>
			public string ColCustomerId { 
				get { return GetColumnName("COL8438660733"); } 
			}

			/// <summary>
			/// Gets column PaidVND with alias  
			/// </summary>
			public string ColPaidVND { 
				get { return GetColumnName("COL84386607314"); } 
			}

			/// <summary>
			/// Gets column ModifiedBy with alias  
			/// </summary>
			public string ColModifiedBy { 
				get { return GetColumnName("COL84386607319"); } 
			}

			/// <summary>
			/// Gets column MoneyVND with alias  
			/// </summary>
			public string ColMoneyVND { 
				get { return GetColumnName("COL84386607311"); } 
			}

			/// <summary>
			/// Gets column BillYearMonth with alias  
			/// </summary>
			public string ColBillYearMonth { 
				get { return GetColumnName("COL84386607321"); } 
			}

			/// <summary>
			/// Gets column ExchangeMoneyVND with alias  
			/// </summary>
			public string ColExchangeMoneyVND { 
				get { return GetColumnName("COL84386607312"); } 
			}

			/// <summary>
			/// Gets column CreatedBy with alias  
			/// </summary>
			public string ColCreatedBy { 
				get { return GetColumnName("COL84386607317"); } 
			}

			/// <summary>
			/// Gets column Modified with alias  
			/// </summary>
			public string ColModified { 
				get { return GetColumnName("COL84386607318"); } 
			}

			/// <summary>
			/// Gets column MoneyUSD with alias  
			/// </summary>
			public string ColMoneyUSD { 
				get { return GetColumnName("COL84386607310"); } 
			}

			/// <summary>
			/// Gets column DelFlag with alias  
			/// </summary>
			public string ColDelFlag { 
				get { return GetColumnName("COL84386607320"); } 
			}

			/// <summary>
			/// Gets column Comment with alias  
			/// </summary>
			public string ColComment { 
				get { return GetColumnName("COL84386607315"); } 
			}

			/// <summary>
			/// Gets column id with alias  
			/// </summary>
			public string Colid { 
				get { return GetColumnName("COL8438660731"); } 
			}

			/// <summary>
			/// Gets column PaymentType with alias  
			/// </summary>
			public string ColPaymentType { 
				get { return GetColumnName("COL8438660738"); } 
			}

			/// <summary>
			/// Gets column ExchangeType with alias  
			/// </summary>
			public string ColExchangeType { 
				get { return GetColumnName("COL8438660739"); } 
			}

			/// <summary>
			/// Gets column Created with alias  
			/// </summary>
			public string ColCreated { 
				get { return GetColumnName("COL84386607316"); } 
			}


			/// <summary>
			/// Checks whether column YearMonth is added in select statement 
			/// </summary>
			public bool IsSelectYearMonth { 
				get { return IsSelect("COL8438660734"); } 
				set { SetSelect("COL8438660734", value); } 
			}

			/// <summary>
			/// Checks whether column BillDate is added in select statement 
			/// </summary>
			public bool IsSelectBillDate { 
				get { return IsSelect("COL8438660735"); } 
				set { SetSelect("COL8438660735", value); } 
			}

			/// <summary>
			/// Checks whether column UsdExchangeDate is added in select statement 
			/// </summary>
			public bool IsSelectUsdExchangeDate { 
				get { return IsSelect("COL8438660736"); } 
				set { SetSelect("COL8438660736", value); } 
			}

			/// <summary>
			/// Checks whether column UsdExchange is added in select statement 
			/// </summary>
			public bool IsSelectUsdExchange { 
				get { return IsSelect("COL8438660737"); } 
				set { SetSelect("COL8438660737", value); } 
			}

			/// <summary>
			/// Checks whether column PaidUSD is added in select statement 
			/// </summary>
			public bool IsSelectPaidUSD { 
				get { return IsSelect("COL84386607313"); } 
				set { SetSelect("COL84386607313", value); } 
			}

			/// <summary>
			/// Checks whether column BuildingId is added in select statement 
			/// </summary>
			public bool IsSelectBuildingId { 
				get { return IsSelect("COL8438660732"); } 
				set { SetSelect("COL8438660732", value); } 
			}

			/// <summary>
			/// Checks whether column CustomerId is added in select statement 
			/// </summary>
			public bool IsSelectCustomerId { 
				get { return IsSelect("COL8438660733"); } 
				set { SetSelect("COL8438660733", value); } 
			}

			/// <summary>
			/// Checks whether column PaidVND is added in select statement 
			/// </summary>
			public bool IsSelectPaidVND { 
				get { return IsSelect("COL84386607314"); } 
				set { SetSelect("COL84386607314", value); } 
			}

			/// <summary>
			/// Checks whether column ModifiedBy is added in select statement 
			/// </summary>
			public bool IsSelectModifiedBy { 
				get { return IsSelect("COL84386607319"); } 
				set { SetSelect("COL84386607319", value); } 
			}

			/// <summary>
			/// Checks whether column MoneyVND is added in select statement 
			/// </summary>
			public bool IsSelectMoneyVND { 
				get { return IsSelect("COL84386607311"); } 
				set { SetSelect("COL84386607311", value); } 
			}

			/// <summary>
			/// Checks whether column BillYearMonth is added in select statement 
			/// </summary>
			public bool IsSelectBillYearMonth { 
				get { return IsSelect("COL84386607321"); } 
				set { SetSelect("COL84386607321", value); } 
			}

			/// <summary>
			/// Checks whether column ExchangeMoneyVND is added in select statement 
			/// </summary>
			public bool IsSelectExchangeMoneyVND { 
				get { return IsSelect("COL84386607312"); } 
				set { SetSelect("COL84386607312", value); } 
			}

			/// <summary>
			/// Checks whether column CreatedBy is added in select statement 
			/// </summary>
			public bool IsSelectCreatedBy { 
				get { return IsSelect("COL84386607317"); } 
				set { SetSelect("COL84386607317", value); } 
			}

			/// <summary>
			/// Checks whether column Modified is added in select statement 
			/// </summary>
			public bool IsSelectModified { 
				get { return IsSelect("COL84386607318"); } 
				set { SetSelect("COL84386607318", value); } 
			}

			/// <summary>
			/// Checks whether column MoneyUSD is added in select statement 
			/// </summary>
			public bool IsSelectMoneyUSD { 
				get { return IsSelect("COL84386607310"); } 
				set { SetSelect("COL84386607310", value); } 
			}

			/// <summary>
			/// Checks whether column DelFlag is added in select statement 
			/// </summary>
			public bool IsSelectDelFlag { 
				get { return IsSelect("COL84386607320"); } 
				set { SetSelect("COL84386607320", value); } 
			}

			/// <summary>
			/// Checks whether column Comment is added in select statement 
			/// </summary>
			public bool IsSelectComment { 
				get { return IsSelect("COL84386607315"); } 
				set { SetSelect("COL84386607315", value); } 
			}

			/// <summary>
			/// Checks whether column id is added in select statement 
			/// </summary>
			public bool IsSelectid { 
				get { return IsSelect("COL8438660731"); } 
				set { SetSelect("COL8438660731", value); } 
			}

			/// <summary>
			/// Checks whether column PaymentType is added in select statement 
			/// </summary>
			public bool IsSelectPaymentType { 
				get { return IsSelect("COL8438660738"); } 
				set { SetSelect("COL8438660738", value); } 
			}

			/// <summary>
			/// Checks whether column ExchangeType is added in select statement 
			/// </summary>
			public bool IsSelectExchangeType { 
				get { return IsSelect("COL8438660739"); } 
				set { SetSelect("COL8438660739", value); } 
			}

			/// <summary>
			/// Checks whether column Created is added in select statement 
			/// </summary>
			public bool IsSelectCreated { 
				get { return IsSelect("COL84386607316"); } 
				set { SetSelect("COL84386607316", value); } 
			}



	}
}