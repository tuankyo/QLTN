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
	public class PaymentDeleteLogData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ1634104862";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of PaymentDeleteLog 
			/// </summary>
			public PaymentDeleteLogData(string objectID): base(objectID) {}  

			public PaymentDeleteLogData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field CreatedBy 
			/// </summary>
			public string CreatedBy { 
				get { return GetValue("COL163410486214"); } 
				set { SetValue("COL163410486214", value); } 
			}

			/// <summary>
			/// Gets field ModifiedBy 
			/// </summary>
			public string ModifiedBy { 
				get { return GetValue("COL163410486216"); } 
				set { SetValue("COL163410486216", value); } 
			}

			/// <summary>
			/// Gets field PaidType 
			/// </summary>
			public string PaidType { 
				get { return GetValue("COL16341048627"); } 
				set { SetValue("COL16341048627", value); } 
			}

			/// <summary>
			/// Gets field Paymenter 
			/// </summary>
			public string Paymenter { 
				get { return GetValue("COL16341048628"); } 
				set { SetValue("COL16341048628", value); } 
			}

			/// <summary>
			/// Gets field DelFlag 
			/// </summary>
			public string DelFlag { 
				get { return GetValue("COL163410486217"); } 
				set { SetValue("COL163410486217", value); } 
			}

			/// <summary>
			/// Gets field CustomerId 
			/// </summary>
			public string CustomerId { 
				get { return GetValue("COL16341048625"); } 
				set { SetValue("COL16341048625", value); } 
			}

			/// <summary>
			/// Gets field Comment 
			/// </summary>
			public string Comment { 
				get { return GetValue("COL163410486212"); } 
				set { SetValue("COL163410486212", value); } 
			}

			/// <summary>
			/// Gets field DeleteTime 
			/// </summary>
			public string DeleteTime { 
				get { return GetValue("COL163410486218"); } 
				set { SetValue("COL163410486218", value); } 
			}

			/// <summary>
			/// Gets field PaymentType 
			/// </summary>
			public string PaymentType { 
				get { return GetValue("COL16341048626"); } 
				set { SetValue("COL16341048626", value); } 
			}

			/// <summary>
			/// Gets field MoneyUSD 
			/// </summary>
			public string MoneyUSD { 
				get { return GetValue("COL163410486210"); } 
				set { SetValue("COL163410486210", value); } 
			}

			/// <summary>
			/// Gets field Modified 
			/// </summary>
			public string Modified { 
				get { return GetValue("COL163410486215"); } 
				set { SetValue("COL163410486215", value); } 
			}

			/// <summary>
			/// Gets field YearMonth 
			/// </summary>
			public string YearMonth { 
				get { return GetValue("COL16341048623"); } 
				set { SetValue("COL16341048623", value); } 
			}

			/// <summary>
			/// Gets field PaymentDate 
			/// </summary>
			public string PaymentDate { 
				get { return GetValue("COL16341048624"); } 
				set { SetValue("COL16341048624", value); } 
			}

			/// <summary>
			/// Gets field Receiver 
			/// </summary>
			public string Receiver { 
				get { return GetValue("COL16341048629"); } 
				set { SetValue("COL16341048629", value); } 
			}

			/// <summary>
			/// Gets field id 
			/// </summary>
			public string id { 
				get { return GetValue("COL16341048621"); } 
				set { SetValue("COL16341048621", value); } 
			}

			/// <summary>
			/// Gets field MoneyVND 
			/// </summary>
			public string MoneyVND { 
				get { return GetValue("COL163410486211"); } 
				set { SetValue("COL163410486211", value); } 
			}

			/// <summary>
			/// Gets field Created 
			/// </summary>
			public string Created { 
				get { return GetValue("COL163410486213"); } 
				set { SetValue("COL163410486213", value); } 
			}

			/// <summary>
			/// Gets field BuildingId 
			/// </summary>
			public string BuildingId { 
				get { return GetValue("COL16341048622"); } 
				set { SetValue("COL16341048622", value); } 
			}


			/// <summary>
			/// Gets CreatedBy attribute data 
			/// </summary>
			public AttributeData GetCreatedByAttributeData() { 
				return GetAttributeData("COL163410486214"); 
			}

			/// <summary>
			/// Gets ModifiedBy attribute data 
			/// </summary>
			public AttributeData GetModifiedByAttributeData() { 
				return GetAttributeData("COL163410486216"); 
			}

			/// <summary>
			/// Gets PaidType attribute data 
			/// </summary>
			public AttributeData GetPaidTypeAttributeData() { 
				return GetAttributeData("COL16341048627"); 
			}

			/// <summary>
			/// Gets Paymenter attribute data 
			/// </summary>
			public AttributeData GetPaymenterAttributeData() { 
				return GetAttributeData("COL16341048628"); 
			}

			/// <summary>
			/// Gets DelFlag attribute data 
			/// </summary>
			public AttributeData GetDelFlagAttributeData() { 
				return GetAttributeData("COL163410486217"); 
			}

			/// <summary>
			/// Gets CustomerId attribute data 
			/// </summary>
			public AttributeData GetCustomerIdAttributeData() { 
				return GetAttributeData("COL16341048625"); 
			}

			/// <summary>
			/// Gets Comment attribute data 
			/// </summary>
			public AttributeData GetCommentAttributeData() { 
				return GetAttributeData("COL163410486212"); 
			}

			/// <summary>
			/// Gets DeleteTime attribute data 
			/// </summary>
			public AttributeData GetDeleteTimeAttributeData() { 
				return GetAttributeData("COL163410486218"); 
			}

			/// <summary>
			/// Gets PaymentType attribute data 
			/// </summary>
			public AttributeData GetPaymentTypeAttributeData() { 
				return GetAttributeData("COL16341048626"); 
			}

			/// <summary>
			/// Gets MoneyUSD attribute data 
			/// </summary>
			public AttributeData GetMoneyUSDAttributeData() { 
				return GetAttributeData("COL163410486210"); 
			}

			/// <summary>
			/// Gets Modified attribute data 
			/// </summary>
			public AttributeData GetModifiedAttributeData() { 
				return GetAttributeData("COL163410486215"); 
			}

			/// <summary>
			/// Gets YearMonth attribute data 
			/// </summary>
			public AttributeData GetYearMonthAttributeData() { 
				return GetAttributeData("COL16341048623"); 
			}

			/// <summary>
			/// Gets PaymentDate attribute data 
			/// </summary>
			public AttributeData GetPaymentDateAttributeData() { 
				return GetAttributeData("COL16341048624"); 
			}

			/// <summary>
			/// Gets Receiver attribute data 
			/// </summary>
			public AttributeData GetReceiverAttributeData() { 
				return GetAttributeData("COL16341048629"); 
			}

			/// <summary>
			/// Gets id attribute data 
			/// </summary>
			public AttributeData GetidAttributeData() { 
				return GetAttributeData("COL16341048621"); 
			}

			/// <summary>
			/// Gets MoneyVND attribute data 
			/// </summary>
			public AttributeData GetMoneyVNDAttributeData() { 
				return GetAttributeData("COL163410486211"); 
			}

			/// <summary>
			/// Gets Created attribute data 
			/// </summary>
			public AttributeData GetCreatedAttributeData() { 
				return GetAttributeData("COL163410486213"); 
			}

			/// <summary>
			/// Gets BuildingId attribute data 
			/// </summary>
			public AttributeData GetBuildingIdAttributeData() { 
				return GetAttributeData("COL16341048622"); 
			}


			/// <summary>
			/// Gets column CreatedBy with alias  
			/// </summary>
			public string ColCreatedBy { 
				get { return GetColumnName("COL163410486214"); } 
			}

			/// <summary>
			/// Gets column ModifiedBy with alias  
			/// </summary>
			public string ColModifiedBy { 
				get { return GetColumnName("COL163410486216"); } 
			}

			/// <summary>
			/// Gets column PaidType with alias  
			/// </summary>
			public string ColPaidType { 
				get { return GetColumnName("COL16341048627"); } 
			}

			/// <summary>
			/// Gets column Paymenter with alias  
			/// </summary>
			public string ColPaymenter { 
				get { return GetColumnName("COL16341048628"); } 
			}

			/// <summary>
			/// Gets column DelFlag with alias  
			/// </summary>
			public string ColDelFlag { 
				get { return GetColumnName("COL163410486217"); } 
			}

			/// <summary>
			/// Gets column CustomerId with alias  
			/// </summary>
			public string ColCustomerId { 
				get { return GetColumnName("COL16341048625"); } 
			}

			/// <summary>
			/// Gets column Comment with alias  
			/// </summary>
			public string ColComment { 
				get { return GetColumnName("COL163410486212"); } 
			}

			/// <summary>
			/// Gets column DeleteTime with alias  
			/// </summary>
			public string ColDeleteTime { 
				get { return GetColumnName("COL163410486218"); } 
			}

			/// <summary>
			/// Gets column PaymentType with alias  
			/// </summary>
			public string ColPaymentType { 
				get { return GetColumnName("COL16341048626"); } 
			}

			/// <summary>
			/// Gets column MoneyUSD with alias  
			/// </summary>
			public string ColMoneyUSD { 
				get { return GetColumnName("COL163410486210"); } 
			}

			/// <summary>
			/// Gets column Modified with alias  
			/// </summary>
			public string ColModified { 
				get { return GetColumnName("COL163410486215"); } 
			}

			/// <summary>
			/// Gets column YearMonth with alias  
			/// </summary>
			public string ColYearMonth { 
				get { return GetColumnName("COL16341048623"); } 
			}

			/// <summary>
			/// Gets column PaymentDate with alias  
			/// </summary>
			public string ColPaymentDate { 
				get { return GetColumnName("COL16341048624"); } 
			}

			/// <summary>
			/// Gets column Receiver with alias  
			/// </summary>
			public string ColReceiver { 
				get { return GetColumnName("COL16341048629"); } 
			}

			/// <summary>
			/// Gets column id with alias  
			/// </summary>
			public string Colid { 
				get { return GetColumnName("COL16341048621"); } 
			}

			/// <summary>
			/// Gets column MoneyVND with alias  
			/// </summary>
			public string ColMoneyVND { 
				get { return GetColumnName("COL163410486211"); } 
			}

			/// <summary>
			/// Gets column Created with alias  
			/// </summary>
			public string ColCreated { 
				get { return GetColumnName("COL163410486213"); } 
			}

			/// <summary>
			/// Gets column BuildingId with alias  
			/// </summary>
			public string ColBuildingId { 
				get { return GetColumnName("COL16341048622"); } 
			}


			/// <summary>
			/// Checks whether column CreatedBy is added in select statement 
			/// </summary>
			public bool IsSelectCreatedBy { 
				get { return IsSelect("COL163410486214"); } 
				set { SetSelect("COL163410486214", value); } 
			}

			/// <summary>
			/// Checks whether column ModifiedBy is added in select statement 
			/// </summary>
			public bool IsSelectModifiedBy { 
				get { return IsSelect("COL163410486216"); } 
				set { SetSelect("COL163410486216", value); } 
			}

			/// <summary>
			/// Checks whether column PaidType is added in select statement 
			/// </summary>
			public bool IsSelectPaidType { 
				get { return IsSelect("COL16341048627"); } 
				set { SetSelect("COL16341048627", value); } 
			}

			/// <summary>
			/// Checks whether column Paymenter is added in select statement 
			/// </summary>
			public bool IsSelectPaymenter { 
				get { return IsSelect("COL16341048628"); } 
				set { SetSelect("COL16341048628", value); } 
			}

			/// <summary>
			/// Checks whether column DelFlag is added in select statement 
			/// </summary>
			public bool IsSelectDelFlag { 
				get { return IsSelect("COL163410486217"); } 
				set { SetSelect("COL163410486217", value); } 
			}

			/// <summary>
			/// Checks whether column CustomerId is added in select statement 
			/// </summary>
			public bool IsSelectCustomerId { 
				get { return IsSelect("COL16341048625"); } 
				set { SetSelect("COL16341048625", value); } 
			}

			/// <summary>
			/// Checks whether column Comment is added in select statement 
			/// </summary>
			public bool IsSelectComment { 
				get { return IsSelect("COL163410486212"); } 
				set { SetSelect("COL163410486212", value); } 
			}

			/// <summary>
			/// Checks whether column DeleteTime is added in select statement 
			/// </summary>
			public bool IsSelectDeleteTime { 
				get { return IsSelect("COL163410486218"); } 
				set { SetSelect("COL163410486218", value); } 
			}

			/// <summary>
			/// Checks whether column PaymentType is added in select statement 
			/// </summary>
			public bool IsSelectPaymentType { 
				get { return IsSelect("COL16341048626"); } 
				set { SetSelect("COL16341048626", value); } 
			}

			/// <summary>
			/// Checks whether column MoneyUSD is added in select statement 
			/// </summary>
			public bool IsSelectMoneyUSD { 
				get { return IsSelect("COL163410486210"); } 
				set { SetSelect("COL163410486210", value); } 
			}

			/// <summary>
			/// Checks whether column Modified is added in select statement 
			/// </summary>
			public bool IsSelectModified { 
				get { return IsSelect("COL163410486215"); } 
				set { SetSelect("COL163410486215", value); } 
			}

			/// <summary>
			/// Checks whether column YearMonth is added in select statement 
			/// </summary>
			public bool IsSelectYearMonth { 
				get { return IsSelect("COL16341048623"); } 
				set { SetSelect("COL16341048623", value); } 
			}

			/// <summary>
			/// Checks whether column PaymentDate is added in select statement 
			/// </summary>
			public bool IsSelectPaymentDate { 
				get { return IsSelect("COL16341048624"); } 
				set { SetSelect("COL16341048624", value); } 
			}

			/// <summary>
			/// Checks whether column Receiver is added in select statement 
			/// </summary>
			public bool IsSelectReceiver { 
				get { return IsSelect("COL16341048629"); } 
				set { SetSelect("COL16341048629", value); } 
			}

			/// <summary>
			/// Checks whether column id is added in select statement 
			/// </summary>
			public bool IsSelectid { 
				get { return IsSelect("COL16341048621"); } 
				set { SetSelect("COL16341048621", value); } 
			}

			/// <summary>
			/// Checks whether column MoneyVND is added in select statement 
			/// </summary>
			public bool IsSelectMoneyVND { 
				get { return IsSelect("COL163410486211"); } 
				set { SetSelect("COL163410486211", value); } 
			}

			/// <summary>
			/// Checks whether column Created is added in select statement 
			/// </summary>
			public bool IsSelectCreated { 
				get { return IsSelect("COL163410486213"); } 
				set { SetSelect("COL163410486213", value); } 
			}

			/// <summary>
			/// Checks whether column BuildingId is added in select statement 
			/// </summary>
			public bool IsSelectBuildingId { 
				get { return IsSelect("COL16341048622"); } 
				set { SetSelect("COL16341048622", value); } 
			}



	}
}