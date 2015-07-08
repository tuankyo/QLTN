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
	public class PaymentBillDetailTmp20120904Data : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ152387612";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of PaymentBillDetailTmp20120904 
			/// </summary>
			public PaymentBillDetailTmp20120904Data(string objectID): base(objectID) {}  

			public PaymentBillDetailTmp20120904Data() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field Comment 
			/// </summary>
			public string Comment { 
				get { return GetValue("COL15238761215"); } 
				set { SetValue("COL15238761215", value); } 
			}

			/// <summary>
			/// Gets field Modified 
			/// </summary>
			public string Modified { 
				get { return GetValue("COL15238761218"); } 
				set { SetValue("COL15238761218", value); } 
			}

			/// <summary>
			/// Gets field MoneyUSD 
			/// </summary>
			public string MoneyUSD { 
				get { return GetValue("COL15238761210"); } 
				set { SetValue("COL15238761210", value); } 
			}

			/// <summary>
			/// Gets field DelFlag 
			/// </summary>
			public string DelFlag { 
				get { return GetValue("COL15238761220"); } 
				set { SetValue("COL15238761220", value); } 
			}

			/// <summary>
			/// Gets field MoneyVND 
			/// </summary>
			public string MoneyVND { 
				get { return GetValue("COL15238761211"); } 
				set { SetValue("COL15238761211", value); } 
			}

			/// <summary>
			/// Gets field CreatedBy 
			/// </summary>
			public string CreatedBy { 
				get { return GetValue("COL15238761217"); } 
				set { SetValue("COL15238761217", value); } 
			}

			/// <summary>
			/// Gets field PaymentType 
			/// </summary>
			public string PaymentType { 
				get { return GetValue("COL1523876128"); } 
				set { SetValue("COL1523876128", value); } 
			}

			/// <summary>
			/// Gets field ExchangeType 
			/// </summary>
			public string ExchangeType { 
				get { return GetValue("COL1523876129"); } 
				set { SetValue("COL1523876129", value); } 
			}

			/// <summary>
			/// Gets field ExchangeMoneyVND 
			/// </summary>
			public string ExchangeMoneyVND { 
				get { return GetValue("COL15238761212"); } 
				set { SetValue("COL15238761212", value); } 
			}

			/// <summary>
			/// Gets field YearMonth 
			/// </summary>
			public string YearMonth { 
				get { return GetValue("COL1523876124"); } 
				set { SetValue("COL1523876124", value); } 
			}

			/// <summary>
			/// Gets field BillDate 
			/// </summary>
			public string BillDate { 
				get { return GetValue("COL1523876125"); } 
				set { SetValue("COL1523876125", value); } 
			}

			/// <summary>
			/// Gets field UsdExchangeDate 
			/// </summary>
			public string UsdExchangeDate { 
				get { return GetValue("COL1523876126"); } 
				set { SetValue("COL1523876126", value); } 
			}

			/// <summary>
			/// Gets field UsdExchange 
			/// </summary>
			public string UsdExchange { 
				get { return GetValue("COL1523876127"); } 
				set { SetValue("COL1523876127", value); } 
			}

			/// <summary>
			/// Gets field id 
			/// </summary>
			public string id { 
				get { return GetValue("COL1523876121"); } 
				set { SetValue("COL1523876121", value); } 
			}

			/// <summary>
			/// Gets field BuildingId 
			/// </summary>
			public string BuildingId { 
				get { return GetValue("COL1523876122"); } 
				set { SetValue("COL1523876122", value); } 
			}

			/// <summary>
			/// Gets field CustomerId 
			/// </summary>
			public string CustomerId { 
				get { return GetValue("COL1523876123"); } 
				set { SetValue("COL1523876123", value); } 
			}

			/// <summary>
			/// Gets field PaidVND 
			/// </summary>
			public string PaidVND { 
				get { return GetValue("COL15238761214"); } 
				set { SetValue("COL15238761214", value); } 
			}

			/// <summary>
			/// Gets field PaidUSD 
			/// </summary>
			public string PaidUSD { 
				get { return GetValue("COL15238761213"); } 
				set { SetValue("COL15238761213", value); } 
			}

			/// <summary>
			/// Gets field Created 
			/// </summary>
			public string Created { 
				get { return GetValue("COL15238761216"); } 
				set { SetValue("COL15238761216", value); } 
			}

			/// <summary>
			/// Gets field ModifiedBy 
			/// </summary>
			public string ModifiedBy { 
				get { return GetValue("COL15238761219"); } 
				set { SetValue("COL15238761219", value); } 
			}


			/// <summary>
			/// Gets Comment attribute data 
			/// </summary>
			public AttributeData GetCommentAttributeData() { 
				return GetAttributeData("COL15238761215"); 
			}

			/// <summary>
			/// Gets Modified attribute data 
			/// </summary>
			public AttributeData GetModifiedAttributeData() { 
				return GetAttributeData("COL15238761218"); 
			}

			/// <summary>
			/// Gets MoneyUSD attribute data 
			/// </summary>
			public AttributeData GetMoneyUSDAttributeData() { 
				return GetAttributeData("COL15238761210"); 
			}

			/// <summary>
			/// Gets DelFlag attribute data 
			/// </summary>
			public AttributeData GetDelFlagAttributeData() { 
				return GetAttributeData("COL15238761220"); 
			}

			/// <summary>
			/// Gets MoneyVND attribute data 
			/// </summary>
			public AttributeData GetMoneyVNDAttributeData() { 
				return GetAttributeData("COL15238761211"); 
			}

			/// <summary>
			/// Gets CreatedBy attribute data 
			/// </summary>
			public AttributeData GetCreatedByAttributeData() { 
				return GetAttributeData("COL15238761217"); 
			}

			/// <summary>
			/// Gets PaymentType attribute data 
			/// </summary>
			public AttributeData GetPaymentTypeAttributeData() { 
				return GetAttributeData("COL1523876128"); 
			}

			/// <summary>
			/// Gets ExchangeType attribute data 
			/// </summary>
			public AttributeData GetExchangeTypeAttributeData() { 
				return GetAttributeData("COL1523876129"); 
			}

			/// <summary>
			/// Gets ExchangeMoneyVND attribute data 
			/// </summary>
			public AttributeData GetExchangeMoneyVNDAttributeData() { 
				return GetAttributeData("COL15238761212"); 
			}

			/// <summary>
			/// Gets YearMonth attribute data 
			/// </summary>
			public AttributeData GetYearMonthAttributeData() { 
				return GetAttributeData("COL1523876124"); 
			}

			/// <summary>
			/// Gets BillDate attribute data 
			/// </summary>
			public AttributeData GetBillDateAttributeData() { 
				return GetAttributeData("COL1523876125"); 
			}

			/// <summary>
			/// Gets UsdExchangeDate attribute data 
			/// </summary>
			public AttributeData GetUsdExchangeDateAttributeData() { 
				return GetAttributeData("COL1523876126"); 
			}

			/// <summary>
			/// Gets UsdExchange attribute data 
			/// </summary>
			public AttributeData GetUsdExchangeAttributeData() { 
				return GetAttributeData("COL1523876127"); 
			}

			/// <summary>
			/// Gets id attribute data 
			/// </summary>
			public AttributeData GetidAttributeData() { 
				return GetAttributeData("COL1523876121"); 
			}

			/// <summary>
			/// Gets BuildingId attribute data 
			/// </summary>
			public AttributeData GetBuildingIdAttributeData() { 
				return GetAttributeData("COL1523876122"); 
			}

			/// <summary>
			/// Gets CustomerId attribute data 
			/// </summary>
			public AttributeData GetCustomerIdAttributeData() { 
				return GetAttributeData("COL1523876123"); 
			}

			/// <summary>
			/// Gets PaidVND attribute data 
			/// </summary>
			public AttributeData GetPaidVNDAttributeData() { 
				return GetAttributeData("COL15238761214"); 
			}

			/// <summary>
			/// Gets PaidUSD attribute data 
			/// </summary>
			public AttributeData GetPaidUSDAttributeData() { 
				return GetAttributeData("COL15238761213"); 
			}

			/// <summary>
			/// Gets Created attribute data 
			/// </summary>
			public AttributeData GetCreatedAttributeData() { 
				return GetAttributeData("COL15238761216"); 
			}

			/// <summary>
			/// Gets ModifiedBy attribute data 
			/// </summary>
			public AttributeData GetModifiedByAttributeData() { 
				return GetAttributeData("COL15238761219"); 
			}


			/// <summary>
			/// Gets column Comment with alias  
			/// </summary>
			public string ColComment { 
				get { return GetColumnName("COL15238761215"); } 
			}

			/// <summary>
			/// Gets column Modified with alias  
			/// </summary>
			public string ColModified { 
				get { return GetColumnName("COL15238761218"); } 
			}

			/// <summary>
			/// Gets column MoneyUSD with alias  
			/// </summary>
			public string ColMoneyUSD { 
				get { return GetColumnName("COL15238761210"); } 
			}

			/// <summary>
			/// Gets column DelFlag with alias  
			/// </summary>
			public string ColDelFlag { 
				get { return GetColumnName("COL15238761220"); } 
			}

			/// <summary>
			/// Gets column MoneyVND with alias  
			/// </summary>
			public string ColMoneyVND { 
				get { return GetColumnName("COL15238761211"); } 
			}

			/// <summary>
			/// Gets column CreatedBy with alias  
			/// </summary>
			public string ColCreatedBy { 
				get { return GetColumnName("COL15238761217"); } 
			}

			/// <summary>
			/// Gets column PaymentType with alias  
			/// </summary>
			public string ColPaymentType { 
				get { return GetColumnName("COL1523876128"); } 
			}

			/// <summary>
			/// Gets column ExchangeType with alias  
			/// </summary>
			public string ColExchangeType { 
				get { return GetColumnName("COL1523876129"); } 
			}

			/// <summary>
			/// Gets column ExchangeMoneyVND with alias  
			/// </summary>
			public string ColExchangeMoneyVND { 
				get { return GetColumnName("COL15238761212"); } 
			}

			/// <summary>
			/// Gets column YearMonth with alias  
			/// </summary>
			public string ColYearMonth { 
				get { return GetColumnName("COL1523876124"); } 
			}

			/// <summary>
			/// Gets column BillDate with alias  
			/// </summary>
			public string ColBillDate { 
				get { return GetColumnName("COL1523876125"); } 
			}

			/// <summary>
			/// Gets column UsdExchangeDate with alias  
			/// </summary>
			public string ColUsdExchangeDate { 
				get { return GetColumnName("COL1523876126"); } 
			}

			/// <summary>
			/// Gets column UsdExchange with alias  
			/// </summary>
			public string ColUsdExchange { 
				get { return GetColumnName("COL1523876127"); } 
			}

			/// <summary>
			/// Gets column id with alias  
			/// </summary>
			public string Colid { 
				get { return GetColumnName("COL1523876121"); } 
			}

			/// <summary>
			/// Gets column BuildingId with alias  
			/// </summary>
			public string ColBuildingId { 
				get { return GetColumnName("COL1523876122"); } 
			}

			/// <summary>
			/// Gets column CustomerId with alias  
			/// </summary>
			public string ColCustomerId { 
				get { return GetColumnName("COL1523876123"); } 
			}

			/// <summary>
			/// Gets column PaidVND with alias  
			/// </summary>
			public string ColPaidVND { 
				get { return GetColumnName("COL15238761214"); } 
			}

			/// <summary>
			/// Gets column PaidUSD with alias  
			/// </summary>
			public string ColPaidUSD { 
				get { return GetColumnName("COL15238761213"); } 
			}

			/// <summary>
			/// Gets column Created with alias  
			/// </summary>
			public string ColCreated { 
				get { return GetColumnName("COL15238761216"); } 
			}

			/// <summary>
			/// Gets column ModifiedBy with alias  
			/// </summary>
			public string ColModifiedBy { 
				get { return GetColumnName("COL15238761219"); } 
			}


			/// <summary>
			/// Checks whether column Comment is added in select statement 
			/// </summary>
			public bool IsSelectComment { 
				get { return IsSelect("COL15238761215"); } 
				set { SetSelect("COL15238761215", value); } 
			}

			/// <summary>
			/// Checks whether column Modified is added in select statement 
			/// </summary>
			public bool IsSelectModified { 
				get { return IsSelect("COL15238761218"); } 
				set { SetSelect("COL15238761218", value); } 
			}

			/// <summary>
			/// Checks whether column MoneyUSD is added in select statement 
			/// </summary>
			public bool IsSelectMoneyUSD { 
				get { return IsSelect("COL15238761210"); } 
				set { SetSelect("COL15238761210", value); } 
			}

			/// <summary>
			/// Checks whether column DelFlag is added in select statement 
			/// </summary>
			public bool IsSelectDelFlag { 
				get { return IsSelect("COL15238761220"); } 
				set { SetSelect("COL15238761220", value); } 
			}

			/// <summary>
			/// Checks whether column MoneyVND is added in select statement 
			/// </summary>
			public bool IsSelectMoneyVND { 
				get { return IsSelect("COL15238761211"); } 
				set { SetSelect("COL15238761211", value); } 
			}

			/// <summary>
			/// Checks whether column CreatedBy is added in select statement 
			/// </summary>
			public bool IsSelectCreatedBy { 
				get { return IsSelect("COL15238761217"); } 
				set { SetSelect("COL15238761217", value); } 
			}

			/// <summary>
			/// Checks whether column PaymentType is added in select statement 
			/// </summary>
			public bool IsSelectPaymentType { 
				get { return IsSelect("COL1523876128"); } 
				set { SetSelect("COL1523876128", value); } 
			}

			/// <summary>
			/// Checks whether column ExchangeType is added in select statement 
			/// </summary>
			public bool IsSelectExchangeType { 
				get { return IsSelect("COL1523876129"); } 
				set { SetSelect("COL1523876129", value); } 
			}

			/// <summary>
			/// Checks whether column ExchangeMoneyVND is added in select statement 
			/// </summary>
			public bool IsSelectExchangeMoneyVND { 
				get { return IsSelect("COL15238761212"); } 
				set { SetSelect("COL15238761212", value); } 
			}

			/// <summary>
			/// Checks whether column YearMonth is added in select statement 
			/// </summary>
			public bool IsSelectYearMonth { 
				get { return IsSelect("COL1523876124"); } 
				set { SetSelect("COL1523876124", value); } 
			}

			/// <summary>
			/// Checks whether column BillDate is added in select statement 
			/// </summary>
			public bool IsSelectBillDate { 
				get { return IsSelect("COL1523876125"); } 
				set { SetSelect("COL1523876125", value); } 
			}

			/// <summary>
			/// Checks whether column UsdExchangeDate is added in select statement 
			/// </summary>
			public bool IsSelectUsdExchangeDate { 
				get { return IsSelect("COL1523876126"); } 
				set { SetSelect("COL1523876126", value); } 
			}

			/// <summary>
			/// Checks whether column UsdExchange is added in select statement 
			/// </summary>
			public bool IsSelectUsdExchange { 
				get { return IsSelect("COL1523876127"); } 
				set { SetSelect("COL1523876127", value); } 
			}

			/// <summary>
			/// Checks whether column id is added in select statement 
			/// </summary>
			public bool IsSelectid { 
				get { return IsSelect("COL1523876121"); } 
				set { SetSelect("COL1523876121", value); } 
			}

			/// <summary>
			/// Checks whether column BuildingId is added in select statement 
			/// </summary>
			public bool IsSelectBuildingId { 
				get { return IsSelect("COL1523876122"); } 
				set { SetSelect("COL1523876122", value); } 
			}

			/// <summary>
			/// Checks whether column CustomerId is added in select statement 
			/// </summary>
			public bool IsSelectCustomerId { 
				get { return IsSelect("COL1523876123"); } 
				set { SetSelect("COL1523876123", value); } 
			}

			/// <summary>
			/// Checks whether column PaidVND is added in select statement 
			/// </summary>
			public bool IsSelectPaidVND { 
				get { return IsSelect("COL15238761214"); } 
				set { SetSelect("COL15238761214", value); } 
			}

			/// <summary>
			/// Checks whether column PaidUSD is added in select statement 
			/// </summary>
			public bool IsSelectPaidUSD { 
				get { return IsSelect("COL15238761213"); } 
				set { SetSelect("COL15238761213", value); } 
			}

			/// <summary>
			/// Checks whether column Created is added in select statement 
			/// </summary>
			public bool IsSelectCreated { 
				get { return IsSelect("COL15238761216"); } 
				set { SetSelect("COL15238761216", value); } 
			}

			/// <summary>
			/// Checks whether column ModifiedBy is added in select statement 
			/// </summary>
			public bool IsSelectModifiedBy { 
				get { return IsSelect("COL15238761219"); } 
				set { SetSelect("COL15238761219", value); } 
			}



	}
}