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
	public class PaymentBillInfoData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ1304391716";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of PaymentBillInfo 
			/// </summary>
			public PaymentBillInfoData(string objectID): base(objectID) {}  

			public PaymentBillInfoData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field Bank 
			/// </summary>
			public string Bank { 
				get { return GetValue("COL13043917169"); } 
				set { SetValue("COL13043917169", value); } 
			}

			/// <summary>
			/// Gets field Modified 
			/// </summary>
			public string Modified { 
				get { return GetValue("COL130439171622"); } 
				set { SetValue("COL130439171622", value); } 
			}

			/// <summary>
			/// Gets field id 
			/// </summary>
			public string id { 
				get { return GetValue("COL13043917161"); } 
				set { SetValue("COL13043917161", value); } 
			}

			/// <summary>
			/// Gets field Created 
			/// </summary>
			public string Created { 
				get { return GetValue("COL130439171620"); } 
				set { SetValue("COL130439171620", value); } 
			}

			/// <summary>
			/// Gets field UsdExchange 
			/// </summary>
			public string UsdExchange { 
				get { return GetValue("COL130439171617"); } 
				set { SetValue("COL130439171617", value); } 
			}

			/// <summary>
			/// Gets field OfficePhone 
			/// </summary>
			public string OfficePhone { 
				get { return GetValue("COL130439171614"); } 
				set { SetValue("COL130439171614", value); } 
			}

			/// <summary>
			/// Gets field YearMonth 
			/// </summary>
			public string YearMonth { 
				get { return GetValue("COL13043917164"); } 
				set { SetValue("COL13043917164", value); } 
			}

			/// <summary>
			/// Gets field ContactName 
			/// </summary>
			public string ContactName { 
				get { return GetValue("COL13043917168"); } 
				set { SetValue("COL13043917168", value); } 
			}

			/// <summary>
			/// Gets field BillNo 
			/// </summary>
			public string BillNo { 
				get { return GetValue("COL130439171625"); } 
				set { SetValue("COL130439171625", value); } 
			}

			/// <summary>
			/// Gets field Phone 
			/// </summary>
			public string Phone { 
				get { return GetValue("COL13043917166"); } 
				set { SetValue("COL13043917166", value); } 
			}

			/// <summary>
			/// Gets field Comment 
			/// </summary>
			public string Comment { 
				get { return GetValue("COL130439171619"); } 
				set { SetValue("COL130439171619", value); } 
			}

			/// <summary>
			/// Gets field ExchangeType 
			/// </summary>
			public string ExchangeType { 
				get { return GetValue("COL130439171618"); } 
				set { SetValue("COL130439171618", value); } 
			}

			/// <summary>
			/// Gets field Office 
			/// </summary>
			public string Office { 
				get { return GetValue("COL130439171612"); } 
				set { SetValue("COL130439171612", value); } 
			}

			/// <summary>
			/// Gets field Account 
			/// </summary>
			public string Account { 
				get { return GetValue("COL130439171610"); } 
				set { SetValue("COL130439171610", value); } 
			}

			/// <summary>
			/// Gets field ModifiedBy 
			/// </summary>
			public string ModifiedBy { 
				get { return GetValue("COL130439171623"); } 
				set { SetValue("COL130439171623", value); } 
			}

			/// <summary>
			/// Gets field CreatedBy 
			/// </summary>
			public string CreatedBy { 
				get { return GetValue("COL130439171621"); } 
				set { SetValue("COL130439171621", value); } 
			}

			/// <summary>
			/// Gets field Name 
			/// </summary>
			public string Name { 
				get { return GetValue("COL13043917165"); } 
				set { SetValue("COL13043917165", value); } 
			}

			/// <summary>
			/// Gets field BillDate 
			/// </summary>
			public string BillDate { 
				get { return GetValue("COL130439171615"); } 
				set { SetValue("COL130439171615", value); } 
			}

			/// <summary>
			/// Gets field CustomerId 
			/// </summary>
			public string CustomerId { 
				get { return GetValue("COL13043917162"); } 
				set { SetValue("COL13043917162", value); } 
			}

			/// <summary>
			/// Gets field YearMonths 
			/// </summary>
			public string YearMonths { 
				get { return GetValue("COL130439171626"); } 
				set { SetValue("COL130439171626", value); } 
			}

			/// <summary>
			/// Gets field BuildingId 
			/// </summary>
			public string BuildingId { 
				get { return GetValue("COL13043917163"); } 
				set { SetValue("COL13043917163", value); } 
			}

			/// <summary>
			/// Gets field DelFlag 
			/// </summary>
			public string DelFlag { 
				get { return GetValue("COL130439171624"); } 
				set { SetValue("COL130439171624", value); } 
			}

			/// <summary>
			/// Gets field Email 
			/// </summary>
			public string Email { 
				get { return GetValue("COL13043917167"); } 
				set { SetValue("COL13043917167", value); } 
			}

			/// <summary>
			/// Gets field OfficeAddress 
			/// </summary>
			public string OfficeAddress { 
				get { return GetValue("COL130439171613"); } 
				set { SetValue("COL130439171613", value); } 
			}

			/// <summary>
			/// Gets field AccountName 
			/// </summary>
			public string AccountName { 
				get { return GetValue("COL130439171611"); } 
				set { SetValue("COL130439171611", value); } 
			}

			/// <summary>
			/// Gets field UsdExchangeDate 
			/// </summary>
			public string UsdExchangeDate { 
				get { return GetValue("COL130439171616"); } 
				set { SetValue("COL130439171616", value); } 
			}


			/// <summary>
			/// Gets Bank attribute data 
			/// </summary>
			public AttributeData GetBankAttributeData() { 
				return GetAttributeData("COL13043917169"); 
			}

			/// <summary>
			/// Gets Modified attribute data 
			/// </summary>
			public AttributeData GetModifiedAttributeData() { 
				return GetAttributeData("COL130439171622"); 
			}

			/// <summary>
			/// Gets id attribute data 
			/// </summary>
			public AttributeData GetidAttributeData() { 
				return GetAttributeData("COL13043917161"); 
			}

			/// <summary>
			/// Gets Created attribute data 
			/// </summary>
			public AttributeData GetCreatedAttributeData() { 
				return GetAttributeData("COL130439171620"); 
			}

			/// <summary>
			/// Gets UsdExchange attribute data 
			/// </summary>
			public AttributeData GetUsdExchangeAttributeData() { 
				return GetAttributeData("COL130439171617"); 
			}

			/// <summary>
			/// Gets OfficePhone attribute data 
			/// </summary>
			public AttributeData GetOfficePhoneAttributeData() { 
				return GetAttributeData("COL130439171614"); 
			}

			/// <summary>
			/// Gets YearMonth attribute data 
			/// </summary>
			public AttributeData GetYearMonthAttributeData() { 
				return GetAttributeData("COL13043917164"); 
			}

			/// <summary>
			/// Gets ContactName attribute data 
			/// </summary>
			public AttributeData GetContactNameAttributeData() { 
				return GetAttributeData("COL13043917168"); 
			}

			/// <summary>
			/// Gets BillNo attribute data 
			/// </summary>
			public AttributeData GetBillNoAttributeData() { 
				return GetAttributeData("COL130439171625"); 
			}

			/// <summary>
			/// Gets Phone attribute data 
			/// </summary>
			public AttributeData GetPhoneAttributeData() { 
				return GetAttributeData("COL13043917166"); 
			}

			/// <summary>
			/// Gets Comment attribute data 
			/// </summary>
			public AttributeData GetCommentAttributeData() { 
				return GetAttributeData("COL130439171619"); 
			}

			/// <summary>
			/// Gets ExchangeType attribute data 
			/// </summary>
			public AttributeData GetExchangeTypeAttributeData() { 
				return GetAttributeData("COL130439171618"); 
			}

			/// <summary>
			/// Gets Office attribute data 
			/// </summary>
			public AttributeData GetOfficeAttributeData() { 
				return GetAttributeData("COL130439171612"); 
			}

			/// <summary>
			/// Gets Account attribute data 
			/// </summary>
			public AttributeData GetAccountAttributeData() { 
				return GetAttributeData("COL130439171610"); 
			}

			/// <summary>
			/// Gets ModifiedBy attribute data 
			/// </summary>
			public AttributeData GetModifiedByAttributeData() { 
				return GetAttributeData("COL130439171623"); 
			}

			/// <summary>
			/// Gets CreatedBy attribute data 
			/// </summary>
			public AttributeData GetCreatedByAttributeData() { 
				return GetAttributeData("COL130439171621"); 
			}

			/// <summary>
			/// Gets Name attribute data 
			/// </summary>
			public AttributeData GetNameAttributeData() { 
				return GetAttributeData("COL13043917165"); 
			}

			/// <summary>
			/// Gets BillDate attribute data 
			/// </summary>
			public AttributeData GetBillDateAttributeData() { 
				return GetAttributeData("COL130439171615"); 
			}

			/// <summary>
			/// Gets CustomerId attribute data 
			/// </summary>
			public AttributeData GetCustomerIdAttributeData() { 
				return GetAttributeData("COL13043917162"); 
			}

			/// <summary>
			/// Gets YearMonths attribute data 
			/// </summary>
			public AttributeData GetYearMonthsAttributeData() { 
				return GetAttributeData("COL130439171626"); 
			}

			/// <summary>
			/// Gets BuildingId attribute data 
			/// </summary>
			public AttributeData GetBuildingIdAttributeData() { 
				return GetAttributeData("COL13043917163"); 
			}

			/// <summary>
			/// Gets DelFlag attribute data 
			/// </summary>
			public AttributeData GetDelFlagAttributeData() { 
				return GetAttributeData("COL130439171624"); 
			}

			/// <summary>
			/// Gets Email attribute data 
			/// </summary>
			public AttributeData GetEmailAttributeData() { 
				return GetAttributeData("COL13043917167"); 
			}

			/// <summary>
			/// Gets OfficeAddress attribute data 
			/// </summary>
			public AttributeData GetOfficeAddressAttributeData() { 
				return GetAttributeData("COL130439171613"); 
			}

			/// <summary>
			/// Gets AccountName attribute data 
			/// </summary>
			public AttributeData GetAccountNameAttributeData() { 
				return GetAttributeData("COL130439171611"); 
			}

			/// <summary>
			/// Gets UsdExchangeDate attribute data 
			/// </summary>
			public AttributeData GetUsdExchangeDateAttributeData() { 
				return GetAttributeData("COL130439171616"); 
			}


			/// <summary>
			/// Gets column Bank with alias  
			/// </summary>
			public string ColBank { 
				get { return GetColumnName("COL13043917169"); } 
			}

			/// <summary>
			/// Gets column Modified with alias  
			/// </summary>
			public string ColModified { 
				get { return GetColumnName("COL130439171622"); } 
			}

			/// <summary>
			/// Gets column id with alias  
			/// </summary>
			public string Colid { 
				get { return GetColumnName("COL13043917161"); } 
			}

			/// <summary>
			/// Gets column Created with alias  
			/// </summary>
			public string ColCreated { 
				get { return GetColumnName("COL130439171620"); } 
			}

			/// <summary>
			/// Gets column UsdExchange with alias  
			/// </summary>
			public string ColUsdExchange { 
				get { return GetColumnName("COL130439171617"); } 
			}

			/// <summary>
			/// Gets column OfficePhone with alias  
			/// </summary>
			public string ColOfficePhone { 
				get { return GetColumnName("COL130439171614"); } 
			}

			/// <summary>
			/// Gets column YearMonth with alias  
			/// </summary>
			public string ColYearMonth { 
				get { return GetColumnName("COL13043917164"); } 
			}

			/// <summary>
			/// Gets column ContactName with alias  
			/// </summary>
			public string ColContactName { 
				get { return GetColumnName("COL13043917168"); } 
			}

			/// <summary>
			/// Gets column BillNo with alias  
			/// </summary>
			public string ColBillNo { 
				get { return GetColumnName("COL130439171625"); } 
			}

			/// <summary>
			/// Gets column Phone with alias  
			/// </summary>
			public string ColPhone { 
				get { return GetColumnName("COL13043917166"); } 
			}

			/// <summary>
			/// Gets column Comment with alias  
			/// </summary>
			public string ColComment { 
				get { return GetColumnName("COL130439171619"); } 
			}

			/// <summary>
			/// Gets column ExchangeType with alias  
			/// </summary>
			public string ColExchangeType { 
				get { return GetColumnName("COL130439171618"); } 
			}

			/// <summary>
			/// Gets column Office with alias  
			/// </summary>
			public string ColOffice { 
				get { return GetColumnName("COL130439171612"); } 
			}

			/// <summary>
			/// Gets column Account with alias  
			/// </summary>
			public string ColAccount { 
				get { return GetColumnName("COL130439171610"); } 
			}

			/// <summary>
			/// Gets column ModifiedBy with alias  
			/// </summary>
			public string ColModifiedBy { 
				get { return GetColumnName("COL130439171623"); } 
			}

			/// <summary>
			/// Gets column CreatedBy with alias  
			/// </summary>
			public string ColCreatedBy { 
				get { return GetColumnName("COL130439171621"); } 
			}

			/// <summary>
			/// Gets column Name with alias  
			/// </summary>
			public string ColName { 
				get { return GetColumnName("COL13043917165"); } 
			}

			/// <summary>
			/// Gets column BillDate with alias  
			/// </summary>
			public string ColBillDate { 
				get { return GetColumnName("COL130439171615"); } 
			}

			/// <summary>
			/// Gets column CustomerId with alias  
			/// </summary>
			public string ColCustomerId { 
				get { return GetColumnName("COL13043917162"); } 
			}

			/// <summary>
			/// Gets column YearMonths with alias  
			/// </summary>
			public string ColYearMonths { 
				get { return GetColumnName("COL130439171626"); } 
			}

			/// <summary>
			/// Gets column BuildingId with alias  
			/// </summary>
			public string ColBuildingId { 
				get { return GetColumnName("COL13043917163"); } 
			}

			/// <summary>
			/// Gets column DelFlag with alias  
			/// </summary>
			public string ColDelFlag { 
				get { return GetColumnName("COL130439171624"); } 
			}

			/// <summary>
			/// Gets column Email with alias  
			/// </summary>
			public string ColEmail { 
				get { return GetColumnName("COL13043917167"); } 
			}

			/// <summary>
			/// Gets column OfficeAddress with alias  
			/// </summary>
			public string ColOfficeAddress { 
				get { return GetColumnName("COL130439171613"); } 
			}

			/// <summary>
			/// Gets column AccountName with alias  
			/// </summary>
			public string ColAccountName { 
				get { return GetColumnName("COL130439171611"); } 
			}

			/// <summary>
			/// Gets column UsdExchangeDate with alias  
			/// </summary>
			public string ColUsdExchangeDate { 
				get { return GetColumnName("COL130439171616"); } 
			}


			/// <summary>
			/// Checks whether column Bank is added in select statement 
			/// </summary>
			public bool IsSelectBank { 
				get { return IsSelect("COL13043917169"); } 
				set { SetSelect("COL13043917169", value); } 
			}

			/// <summary>
			/// Checks whether column Modified is added in select statement 
			/// </summary>
			public bool IsSelectModified { 
				get { return IsSelect("COL130439171622"); } 
				set { SetSelect("COL130439171622", value); } 
			}

			/// <summary>
			/// Checks whether column id is added in select statement 
			/// </summary>
			public bool IsSelectid { 
				get { return IsSelect("COL13043917161"); } 
				set { SetSelect("COL13043917161", value); } 
			}

			/// <summary>
			/// Checks whether column Created is added in select statement 
			/// </summary>
			public bool IsSelectCreated { 
				get { return IsSelect("COL130439171620"); } 
				set { SetSelect("COL130439171620", value); } 
			}

			/// <summary>
			/// Checks whether column UsdExchange is added in select statement 
			/// </summary>
			public bool IsSelectUsdExchange { 
				get { return IsSelect("COL130439171617"); } 
				set { SetSelect("COL130439171617", value); } 
			}

			/// <summary>
			/// Checks whether column OfficePhone is added in select statement 
			/// </summary>
			public bool IsSelectOfficePhone { 
				get { return IsSelect("COL130439171614"); } 
				set { SetSelect("COL130439171614", value); } 
			}

			/// <summary>
			/// Checks whether column YearMonth is added in select statement 
			/// </summary>
			public bool IsSelectYearMonth { 
				get { return IsSelect("COL13043917164"); } 
				set { SetSelect("COL13043917164", value); } 
			}

			/// <summary>
			/// Checks whether column ContactName is added in select statement 
			/// </summary>
			public bool IsSelectContactName { 
				get { return IsSelect("COL13043917168"); } 
				set { SetSelect("COL13043917168", value); } 
			}

			/// <summary>
			/// Checks whether column BillNo is added in select statement 
			/// </summary>
			public bool IsSelectBillNo { 
				get { return IsSelect("COL130439171625"); } 
				set { SetSelect("COL130439171625", value); } 
			}

			/// <summary>
			/// Checks whether column Phone is added in select statement 
			/// </summary>
			public bool IsSelectPhone { 
				get { return IsSelect("COL13043917166"); } 
				set { SetSelect("COL13043917166", value); } 
			}

			/// <summary>
			/// Checks whether column Comment is added in select statement 
			/// </summary>
			public bool IsSelectComment { 
				get { return IsSelect("COL130439171619"); } 
				set { SetSelect("COL130439171619", value); } 
			}

			/// <summary>
			/// Checks whether column ExchangeType is added in select statement 
			/// </summary>
			public bool IsSelectExchangeType { 
				get { return IsSelect("COL130439171618"); } 
				set { SetSelect("COL130439171618", value); } 
			}

			/// <summary>
			/// Checks whether column Office is added in select statement 
			/// </summary>
			public bool IsSelectOffice { 
				get { return IsSelect("COL130439171612"); } 
				set { SetSelect("COL130439171612", value); } 
			}

			/// <summary>
			/// Checks whether column Account is added in select statement 
			/// </summary>
			public bool IsSelectAccount { 
				get { return IsSelect("COL130439171610"); } 
				set { SetSelect("COL130439171610", value); } 
			}

			/// <summary>
			/// Checks whether column ModifiedBy is added in select statement 
			/// </summary>
			public bool IsSelectModifiedBy { 
				get { return IsSelect("COL130439171623"); } 
				set { SetSelect("COL130439171623", value); } 
			}

			/// <summary>
			/// Checks whether column CreatedBy is added in select statement 
			/// </summary>
			public bool IsSelectCreatedBy { 
				get { return IsSelect("COL130439171621"); } 
				set { SetSelect("COL130439171621", value); } 
			}

			/// <summary>
			/// Checks whether column Name is added in select statement 
			/// </summary>
			public bool IsSelectName { 
				get { return IsSelect("COL13043917165"); } 
				set { SetSelect("COL13043917165", value); } 
			}

			/// <summary>
			/// Checks whether column BillDate is added in select statement 
			/// </summary>
			public bool IsSelectBillDate { 
				get { return IsSelect("COL130439171615"); } 
				set { SetSelect("COL130439171615", value); } 
			}

			/// <summary>
			/// Checks whether column CustomerId is added in select statement 
			/// </summary>
			public bool IsSelectCustomerId { 
				get { return IsSelect("COL13043917162"); } 
				set { SetSelect("COL13043917162", value); } 
			}

			/// <summary>
			/// Checks whether column YearMonths is added in select statement 
			/// </summary>
			public bool IsSelectYearMonths { 
				get { return IsSelect("COL130439171626"); } 
				set { SetSelect("COL130439171626", value); } 
			}

			/// <summary>
			/// Checks whether column BuildingId is added in select statement 
			/// </summary>
			public bool IsSelectBuildingId { 
				get { return IsSelect("COL13043917163"); } 
				set { SetSelect("COL13043917163", value); } 
			}

			/// <summary>
			/// Checks whether column DelFlag is added in select statement 
			/// </summary>
			public bool IsSelectDelFlag { 
				get { return IsSelect("COL130439171624"); } 
				set { SetSelect("COL130439171624", value); } 
			}

			/// <summary>
			/// Checks whether column Email is added in select statement 
			/// </summary>
			public bool IsSelectEmail { 
				get { return IsSelect("COL13043917167"); } 
				set { SetSelect("COL13043917167", value); } 
			}

			/// <summary>
			/// Checks whether column OfficeAddress is added in select statement 
			/// </summary>
			public bool IsSelectOfficeAddress { 
				get { return IsSelect("COL130439171613"); } 
				set { SetSelect("COL130439171613", value); } 
			}

			/// <summary>
			/// Checks whether column AccountName is added in select statement 
			/// </summary>
			public bool IsSelectAccountName { 
				get { return IsSelect("COL130439171611"); } 
				set { SetSelect("COL130439171611", value); } 
			}

			/// <summary>
			/// Checks whether column UsdExchangeDate is added in select statement 
			/// </summary>
			public bool IsSelectUsdExchangeDate { 
				get { return IsSelect("COL130439171616"); } 
				set { SetSelect("COL130439171616", value); } 
			}



	}
}