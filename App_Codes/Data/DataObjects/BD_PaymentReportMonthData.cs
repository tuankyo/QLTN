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
	public class BD_PaymentReportMonthData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ1983346130";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of BD_PaymentReportMonth 
			/// </summary>
			public BD_PaymentReportMonthData(string objectID): base(objectID) {}  

			public BD_PaymentReportMonthData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field PaymentId 
			/// </summary>
			public string PaymentId { 
				get { return GetValue("COL198334613013"); } 
				set { SetValue("COL198334613013", value); } 
			}

			/// <summary>
			/// Gets field OutVND 
			/// </summary>
			public string OutVND { 
				get { return GetValue("COL19833461307"); } 
				set { SetValue("COL19833461307", value); } 
			}

			/// <summary>
			/// Gets field YearMonth 
			/// </summary>
			public string YearMonth { 
				get { return GetValue("COL19833461302"); } 
				set { SetValue("COL19833461302", value); } 
			}

			/// <summary>
			/// Gets field colNo 
			/// </summary>
			public string colNo { 
				get { return GetValue("COL198334613014"); } 
				set { SetValue("COL198334613014", value); } 
			}

			/// <summary>
			/// Gets field ItemLevel 
			/// </summary>
			public string ItemLevel { 
				get { return GetValue("COL198334613016"); } 
				set { SetValue("COL198334613016", value); } 
			}

			/// <summary>
			/// Gets field id 
			/// </summary>
			public string id { 
				get { return GetValue("COL19833461301"); } 
				set { SetValue("COL19833461301", value); } 
			}

			/// <summary>
			/// Gets field ParentId 
			/// </summary>
			public string ParentId { 
				get { return GetValue("COL198334613017"); } 
				set { SetValue("COL198334613017", value); } 
			}

			/// <summary>
			/// Gets field InUSD 
			/// </summary>
			public string InUSD { 
				get { return GetValue("COL19833461306"); } 
				set { SetValue("COL19833461306", value); } 
			}

			/// <summary>
			/// Gets field Modified 
			/// </summary>
			public string Modified { 
				get { return GetValue("COL198334613011"); } 
				set { SetValue("COL198334613011", value); } 
			}

			/// <summary>
			/// Gets field OutUSD 
			/// </summary>
			public string OutUSD { 
				get { return GetValue("COL19833461308"); } 
				set { SetValue("COL19833461308", value); } 
			}

			/// <summary>
			/// Gets field ModifiedBy 
			/// </summary>
			public string ModifiedBy { 
				get { return GetValue("COL198334613012"); } 
				set { SetValue("COL198334613012", value); } 
			}

			/// <summary>
			/// Gets field BuildingId 
			/// </summary>
			public string BuildingId { 
				get { return GetValue("COL19833461303"); } 
				set { SetValue("COL19833461303", value); } 
			}

			/// <summary>
			/// Gets field InVND 
			/// </summary>
			public string InVND { 
				get { return GetValue("COL19833461305"); } 
				set { SetValue("COL19833461305", value); } 
			}

			/// <summary>
			/// Gets field bold 
			/// </summary>
			public string bold { 
				get { return GetValue("COL198334613015"); } 
				set { SetValue("COL198334613015", value); } 
			}

			/// <summary>
			/// Gets field CreatedBy 
			/// </summary>
			public string CreatedBy { 
				get { return GetValue("COL198334613010"); } 
				set { SetValue("COL198334613010", value); } 
			}

			/// <summary>
			/// Gets field Created 
			/// </summary>
			public string Created { 
				get { return GetValue("COL19833461309"); } 
				set { SetValue("COL19833461309", value); } 
			}

			/// <summary>
			/// Gets field PaymentType 
			/// </summary>
			public string PaymentType { 
				get { return GetValue("COL19833461304"); } 
				set { SetValue("COL19833461304", value); } 
			}


			/// <summary>
			/// Gets PaymentId attribute data 
			/// </summary>
			public AttributeData GetPaymentIdAttributeData() { 
				return GetAttributeData("COL198334613013"); 
			}

			/// <summary>
			/// Gets OutVND attribute data 
			/// </summary>
			public AttributeData GetOutVNDAttributeData() { 
				return GetAttributeData("COL19833461307"); 
			}

			/// <summary>
			/// Gets YearMonth attribute data 
			/// </summary>
			public AttributeData GetYearMonthAttributeData() { 
				return GetAttributeData("COL19833461302"); 
			}

			/// <summary>
			/// Gets colNo attribute data 
			/// </summary>
			public AttributeData GetcolNoAttributeData() { 
				return GetAttributeData("COL198334613014"); 
			}

			/// <summary>
			/// Gets ItemLevel attribute data 
			/// </summary>
			public AttributeData GetItemLevelAttributeData() { 
				return GetAttributeData("COL198334613016"); 
			}

			/// <summary>
			/// Gets id attribute data 
			/// </summary>
			public AttributeData GetidAttributeData() { 
				return GetAttributeData("COL19833461301"); 
			}

			/// <summary>
			/// Gets ParentId attribute data 
			/// </summary>
			public AttributeData GetParentIdAttributeData() { 
				return GetAttributeData("COL198334613017"); 
			}

			/// <summary>
			/// Gets InUSD attribute data 
			/// </summary>
			public AttributeData GetInUSDAttributeData() { 
				return GetAttributeData("COL19833461306"); 
			}

			/// <summary>
			/// Gets Modified attribute data 
			/// </summary>
			public AttributeData GetModifiedAttributeData() { 
				return GetAttributeData("COL198334613011"); 
			}

			/// <summary>
			/// Gets OutUSD attribute data 
			/// </summary>
			public AttributeData GetOutUSDAttributeData() { 
				return GetAttributeData("COL19833461308"); 
			}

			/// <summary>
			/// Gets ModifiedBy attribute data 
			/// </summary>
			public AttributeData GetModifiedByAttributeData() { 
				return GetAttributeData("COL198334613012"); 
			}

			/// <summary>
			/// Gets BuildingId attribute data 
			/// </summary>
			public AttributeData GetBuildingIdAttributeData() { 
				return GetAttributeData("COL19833461303"); 
			}

			/// <summary>
			/// Gets InVND attribute data 
			/// </summary>
			public AttributeData GetInVNDAttributeData() { 
				return GetAttributeData("COL19833461305"); 
			}

			/// <summary>
			/// Gets bold attribute data 
			/// </summary>
			public AttributeData GetboldAttributeData() { 
				return GetAttributeData("COL198334613015"); 
			}

			/// <summary>
			/// Gets CreatedBy attribute data 
			/// </summary>
			public AttributeData GetCreatedByAttributeData() { 
				return GetAttributeData("COL198334613010"); 
			}

			/// <summary>
			/// Gets Created attribute data 
			/// </summary>
			public AttributeData GetCreatedAttributeData() { 
				return GetAttributeData("COL19833461309"); 
			}

			/// <summary>
			/// Gets PaymentType attribute data 
			/// </summary>
			public AttributeData GetPaymentTypeAttributeData() { 
				return GetAttributeData("COL19833461304"); 
			}


			/// <summary>
			/// Gets column PaymentId with alias  
			/// </summary>
			public string ColPaymentId { 
				get { return GetColumnName("COL198334613013"); } 
			}

			/// <summary>
			/// Gets column OutVND with alias  
			/// </summary>
			public string ColOutVND { 
				get { return GetColumnName("COL19833461307"); } 
			}

			/// <summary>
			/// Gets column YearMonth with alias  
			/// </summary>
			public string ColYearMonth { 
				get { return GetColumnName("COL19833461302"); } 
			}

			/// <summary>
			/// Gets column colNo with alias  
			/// </summary>
			public string ColcolNo { 
				get { return GetColumnName("COL198334613014"); } 
			}

			/// <summary>
			/// Gets column ItemLevel with alias  
			/// </summary>
			public string ColItemLevel { 
				get { return GetColumnName("COL198334613016"); } 
			}

			/// <summary>
			/// Gets column id with alias  
			/// </summary>
			public string Colid { 
				get { return GetColumnName("COL19833461301"); } 
			}

			/// <summary>
			/// Gets column ParentId with alias  
			/// </summary>
			public string ColParentId { 
				get { return GetColumnName("COL198334613017"); } 
			}

			/// <summary>
			/// Gets column InUSD with alias  
			/// </summary>
			public string ColInUSD { 
				get { return GetColumnName("COL19833461306"); } 
			}

			/// <summary>
			/// Gets column Modified with alias  
			/// </summary>
			public string ColModified { 
				get { return GetColumnName("COL198334613011"); } 
			}

			/// <summary>
			/// Gets column OutUSD with alias  
			/// </summary>
			public string ColOutUSD { 
				get { return GetColumnName("COL19833461308"); } 
			}

			/// <summary>
			/// Gets column ModifiedBy with alias  
			/// </summary>
			public string ColModifiedBy { 
				get { return GetColumnName("COL198334613012"); } 
			}

			/// <summary>
			/// Gets column BuildingId with alias  
			/// </summary>
			public string ColBuildingId { 
				get { return GetColumnName("COL19833461303"); } 
			}

			/// <summary>
			/// Gets column InVND with alias  
			/// </summary>
			public string ColInVND { 
				get { return GetColumnName("COL19833461305"); } 
			}

			/// <summary>
			/// Gets column bold with alias  
			/// </summary>
			public string Colbold { 
				get { return GetColumnName("COL198334613015"); } 
			}

			/// <summary>
			/// Gets column CreatedBy with alias  
			/// </summary>
			public string ColCreatedBy { 
				get { return GetColumnName("COL198334613010"); } 
			}

			/// <summary>
			/// Gets column Created with alias  
			/// </summary>
			public string ColCreated { 
				get { return GetColumnName("COL19833461309"); } 
			}

			/// <summary>
			/// Gets column PaymentType with alias  
			/// </summary>
			public string ColPaymentType { 
				get { return GetColumnName("COL19833461304"); } 
			}


			/// <summary>
			/// Checks whether column PaymentId is added in select statement 
			/// </summary>
			public bool IsSelectPaymentId { 
				get { return IsSelect("COL198334613013"); } 
				set { SetSelect("COL198334613013", value); } 
			}

			/// <summary>
			/// Checks whether column OutVND is added in select statement 
			/// </summary>
			public bool IsSelectOutVND { 
				get { return IsSelect("COL19833461307"); } 
				set { SetSelect("COL19833461307", value); } 
			}

			/// <summary>
			/// Checks whether column YearMonth is added in select statement 
			/// </summary>
			public bool IsSelectYearMonth { 
				get { return IsSelect("COL19833461302"); } 
				set { SetSelect("COL19833461302", value); } 
			}

			/// <summary>
			/// Checks whether column colNo is added in select statement 
			/// </summary>
			public bool IsSelectcolNo { 
				get { return IsSelect("COL198334613014"); } 
				set { SetSelect("COL198334613014", value); } 
			}

			/// <summary>
			/// Checks whether column ItemLevel is added in select statement 
			/// </summary>
			public bool IsSelectItemLevel { 
				get { return IsSelect("COL198334613016"); } 
				set { SetSelect("COL198334613016", value); } 
			}

			/// <summary>
			/// Checks whether column id is added in select statement 
			/// </summary>
			public bool IsSelectid { 
				get { return IsSelect("COL19833461301"); } 
				set { SetSelect("COL19833461301", value); } 
			}

			/// <summary>
			/// Checks whether column ParentId is added in select statement 
			/// </summary>
			public bool IsSelectParentId { 
				get { return IsSelect("COL198334613017"); } 
				set { SetSelect("COL198334613017", value); } 
			}

			/// <summary>
			/// Checks whether column InUSD is added in select statement 
			/// </summary>
			public bool IsSelectInUSD { 
				get { return IsSelect("COL19833461306"); } 
				set { SetSelect("COL19833461306", value); } 
			}

			/// <summary>
			/// Checks whether column Modified is added in select statement 
			/// </summary>
			public bool IsSelectModified { 
				get { return IsSelect("COL198334613011"); } 
				set { SetSelect("COL198334613011", value); } 
			}

			/// <summary>
			/// Checks whether column OutUSD is added in select statement 
			/// </summary>
			public bool IsSelectOutUSD { 
				get { return IsSelect("COL19833461308"); } 
				set { SetSelect("COL19833461308", value); } 
			}

			/// <summary>
			/// Checks whether column ModifiedBy is added in select statement 
			/// </summary>
			public bool IsSelectModifiedBy { 
				get { return IsSelect("COL198334613012"); } 
				set { SetSelect("COL198334613012", value); } 
			}

			/// <summary>
			/// Checks whether column BuildingId is added in select statement 
			/// </summary>
			public bool IsSelectBuildingId { 
				get { return IsSelect("COL19833461303"); } 
				set { SetSelect("COL19833461303", value); } 
			}

			/// <summary>
			/// Checks whether column InVND is added in select statement 
			/// </summary>
			public bool IsSelectInVND { 
				get { return IsSelect("COL19833461305"); } 
				set { SetSelect("COL19833461305", value); } 
			}

			/// <summary>
			/// Checks whether column bold is added in select statement 
			/// </summary>
			public bool IsSelectbold { 
				get { return IsSelect("COL198334613015"); } 
				set { SetSelect("COL198334613015", value); } 
			}

			/// <summary>
			/// Checks whether column CreatedBy is added in select statement 
			/// </summary>
			public bool IsSelectCreatedBy { 
				get { return IsSelect("COL198334613010"); } 
				set { SetSelect("COL198334613010", value); } 
			}

			/// <summary>
			/// Checks whether column Created is added in select statement 
			/// </summary>
			public bool IsSelectCreated { 
				get { return IsSelect("COL19833461309"); } 
				set { SetSelect("COL19833461309", value); } 
			}

			/// <summary>
			/// Checks whether column PaymentType is added in select statement 
			/// </summary>
			public bool IsSelectPaymentType { 
				get { return IsSelect("COL19833461304"); } 
				set { SetSelect("COL19833461304", value); } 
			}



	}
}