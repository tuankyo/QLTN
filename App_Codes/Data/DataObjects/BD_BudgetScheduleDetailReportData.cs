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
	public class BD_BudgetScheduleDetailReportData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ1775345389";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of BD_BudgetScheduleDetailReport 
			/// </summary>
			public BD_BudgetScheduleDetailReportData(string objectID): base(objectID) {}  

			public BD_BudgetScheduleDetailReportData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field PaymentType 
			/// </summary>
			public string PaymentType { 
				get { return GetValue("COL17753453893"); } 
				set { SetValue("COL17753453893", value); } 
			}

			/// <summary>
			/// Gets field Created 
			/// </summary>
			public string Created { 
				get { return GetValue("COL177534538914"); } 
				set { SetValue("COL177534538914", value); } 
			}

			/// <summary>
			/// Gets field InVND 
			/// </summary>
			public string InVND { 
				get { return GetValue("COL17753453896"); } 
				set { SetValue("COL17753453896", value); } 
			}

			/// <summary>
			/// Gets field ModifiedBy 
			/// </summary>
			public string ModifiedBy { 
				get { return GetValue("COL177534538917"); } 
				set { SetValue("COL177534538917", value); } 
			}

			/// <summary>
			/// Gets field id 
			/// </summary>
			public string id { 
				get { return GetValue("COL17753453891"); } 
				set { SetValue("COL17753453891", value); } 
			}

			/// <summary>
			/// Gets field ItemLevel 
			/// </summary>
			public string ItemLevel { 
				get { return GetValue("COL177534538919"); } 
				set { SetValue("COL177534538919", value); } 
			}

			/// <summary>
			/// Gets field OutUSD 
			/// </summary>
			public string OutUSD { 
				get { return GetValue("COL17753453899"); } 
				set { SetValue("COL17753453899", value); } 
			}

			/// <summary>
			/// Gets field PaymentId 
			/// </summary>
			public string PaymentId { 
				get { return GetValue("COL17753453894"); } 
				set { SetValue("COL17753453894", value); } 
			}

			/// <summary>
			/// Gets field colNo 
			/// </summary>
			public string colNo { 
				get { return GetValue("COL177534538910"); } 
				set { SetValue("COL177534538910", value); } 
			}

			/// <summary>
			/// Gets field bold 
			/// </summary>
			public string bold { 
				get { return GetValue("COL177534538911"); } 
				set { SetValue("COL177534538911", value); } 
			}

			/// <summary>
			/// Gets field InUSD 
			/// </summary>
			public string InUSD { 
				get { return GetValue("COL17753453897"); } 
				set { SetValue("COL17753453897", value); } 
			}

			/// <summary>
			/// Gets field DelFlag 
			/// </summary>
			public string DelFlag { 
				get { return GetValue("COL177534538913"); } 
				set { SetValue("COL177534538913", value); } 
			}

			/// <summary>
			/// Gets field CreatedBy 
			/// </summary>
			public string CreatedBy { 
				get { return GetValue("COL177534538915"); } 
				set { SetValue("COL177534538915", value); } 
			}

			/// <summary>
			/// Gets field BuggetScheduleId 
			/// </summary>
			public string BuggetScheduleId { 
				get { return GetValue("COL17753453892"); } 
				set { SetValue("COL17753453892", value); } 
			}

			/// <summary>
			/// Gets field Modified 
			/// </summary>
			public string Modified { 
				get { return GetValue("COL177534538916"); } 
				set { SetValue("COL177534538916", value); } 
			}

			/// <summary>
			/// Gets field ParentId 
			/// </summary>
			public string ParentId { 
				get { return GetValue("COL17753453895"); } 
				set { SetValue("COL17753453895", value); } 
			}

			/// <summary>
			/// Gets field SessionId 
			/// </summary>
			public string SessionId { 
				get { return GetValue("COL177534538918"); } 
				set { SetValue("COL177534538918", value); } 
			}

			/// <summary>
			/// Gets field Comment 
			/// </summary>
			public string Comment { 
				get { return GetValue("COL177534538920"); } 
				set { SetValue("COL177534538920", value); } 
			}

			/// <summary>
			/// Gets field PaidType 
			/// </summary>
			public string PaidType { 
				get { return GetValue("COL177534538912"); } 
				set { SetValue("COL177534538912", value); } 
			}

			/// <summary>
			/// Gets field OutVND 
			/// </summary>
			public string OutVND { 
				get { return GetValue("COL17753453898"); } 
				set { SetValue("COL17753453898", value); } 
			}


			/// <summary>
			/// Gets PaymentType attribute data 
			/// </summary>
			public AttributeData GetPaymentTypeAttributeData() { 
				return GetAttributeData("COL17753453893"); 
			}

			/// <summary>
			/// Gets Created attribute data 
			/// </summary>
			public AttributeData GetCreatedAttributeData() { 
				return GetAttributeData("COL177534538914"); 
			}

			/// <summary>
			/// Gets InVND attribute data 
			/// </summary>
			public AttributeData GetInVNDAttributeData() { 
				return GetAttributeData("COL17753453896"); 
			}

			/// <summary>
			/// Gets ModifiedBy attribute data 
			/// </summary>
			public AttributeData GetModifiedByAttributeData() { 
				return GetAttributeData("COL177534538917"); 
			}

			/// <summary>
			/// Gets id attribute data 
			/// </summary>
			public AttributeData GetidAttributeData() { 
				return GetAttributeData("COL17753453891"); 
			}

			/// <summary>
			/// Gets ItemLevel attribute data 
			/// </summary>
			public AttributeData GetItemLevelAttributeData() { 
				return GetAttributeData("COL177534538919"); 
			}

			/// <summary>
			/// Gets OutUSD attribute data 
			/// </summary>
			public AttributeData GetOutUSDAttributeData() { 
				return GetAttributeData("COL17753453899"); 
			}

			/// <summary>
			/// Gets PaymentId attribute data 
			/// </summary>
			public AttributeData GetPaymentIdAttributeData() { 
				return GetAttributeData("COL17753453894"); 
			}

			/// <summary>
			/// Gets colNo attribute data 
			/// </summary>
			public AttributeData GetcolNoAttributeData() { 
				return GetAttributeData("COL177534538910"); 
			}

			/// <summary>
			/// Gets bold attribute data 
			/// </summary>
			public AttributeData GetboldAttributeData() { 
				return GetAttributeData("COL177534538911"); 
			}

			/// <summary>
			/// Gets InUSD attribute data 
			/// </summary>
			public AttributeData GetInUSDAttributeData() { 
				return GetAttributeData("COL17753453897"); 
			}

			/// <summary>
			/// Gets DelFlag attribute data 
			/// </summary>
			public AttributeData GetDelFlagAttributeData() { 
				return GetAttributeData("COL177534538913"); 
			}

			/// <summary>
			/// Gets CreatedBy attribute data 
			/// </summary>
			public AttributeData GetCreatedByAttributeData() { 
				return GetAttributeData("COL177534538915"); 
			}

			/// <summary>
			/// Gets BuggetScheduleId attribute data 
			/// </summary>
			public AttributeData GetBuggetScheduleIdAttributeData() { 
				return GetAttributeData("COL17753453892"); 
			}

			/// <summary>
			/// Gets Modified attribute data 
			/// </summary>
			public AttributeData GetModifiedAttributeData() { 
				return GetAttributeData("COL177534538916"); 
			}

			/// <summary>
			/// Gets ParentId attribute data 
			/// </summary>
			public AttributeData GetParentIdAttributeData() { 
				return GetAttributeData("COL17753453895"); 
			}

			/// <summary>
			/// Gets SessionId attribute data 
			/// </summary>
			public AttributeData GetSessionIdAttributeData() { 
				return GetAttributeData("COL177534538918"); 
			}

			/// <summary>
			/// Gets Comment attribute data 
			/// </summary>
			public AttributeData GetCommentAttributeData() { 
				return GetAttributeData("COL177534538920"); 
			}

			/// <summary>
			/// Gets PaidType attribute data 
			/// </summary>
			public AttributeData GetPaidTypeAttributeData() { 
				return GetAttributeData("COL177534538912"); 
			}

			/// <summary>
			/// Gets OutVND attribute data 
			/// </summary>
			public AttributeData GetOutVNDAttributeData() { 
				return GetAttributeData("COL17753453898"); 
			}


			/// <summary>
			/// Gets column PaymentType with alias  
			/// </summary>
			public string ColPaymentType { 
				get { return GetColumnName("COL17753453893"); } 
			}

			/// <summary>
			/// Gets column Created with alias  
			/// </summary>
			public string ColCreated { 
				get { return GetColumnName("COL177534538914"); } 
			}

			/// <summary>
			/// Gets column InVND with alias  
			/// </summary>
			public string ColInVND { 
				get { return GetColumnName("COL17753453896"); } 
			}

			/// <summary>
			/// Gets column ModifiedBy with alias  
			/// </summary>
			public string ColModifiedBy { 
				get { return GetColumnName("COL177534538917"); } 
			}

			/// <summary>
			/// Gets column id with alias  
			/// </summary>
			public string Colid { 
				get { return GetColumnName("COL17753453891"); } 
			}

			/// <summary>
			/// Gets column ItemLevel with alias  
			/// </summary>
			public string ColItemLevel { 
				get { return GetColumnName("COL177534538919"); } 
			}

			/// <summary>
			/// Gets column OutUSD with alias  
			/// </summary>
			public string ColOutUSD { 
				get { return GetColumnName("COL17753453899"); } 
			}

			/// <summary>
			/// Gets column PaymentId with alias  
			/// </summary>
			public string ColPaymentId { 
				get { return GetColumnName("COL17753453894"); } 
			}

			/// <summary>
			/// Gets column colNo with alias  
			/// </summary>
			public string ColcolNo { 
				get { return GetColumnName("COL177534538910"); } 
			}

			/// <summary>
			/// Gets column bold with alias  
			/// </summary>
			public string Colbold { 
				get { return GetColumnName("COL177534538911"); } 
			}

			/// <summary>
			/// Gets column InUSD with alias  
			/// </summary>
			public string ColInUSD { 
				get { return GetColumnName("COL17753453897"); } 
			}

			/// <summary>
			/// Gets column DelFlag with alias  
			/// </summary>
			public string ColDelFlag { 
				get { return GetColumnName("COL177534538913"); } 
			}

			/// <summary>
			/// Gets column CreatedBy with alias  
			/// </summary>
			public string ColCreatedBy { 
				get { return GetColumnName("COL177534538915"); } 
			}

			/// <summary>
			/// Gets column BuggetScheduleId with alias  
			/// </summary>
			public string ColBuggetScheduleId { 
				get { return GetColumnName("COL17753453892"); } 
			}

			/// <summary>
			/// Gets column Modified with alias  
			/// </summary>
			public string ColModified { 
				get { return GetColumnName("COL177534538916"); } 
			}

			/// <summary>
			/// Gets column ParentId with alias  
			/// </summary>
			public string ColParentId { 
				get { return GetColumnName("COL17753453895"); } 
			}

			/// <summary>
			/// Gets column SessionId with alias  
			/// </summary>
			public string ColSessionId { 
				get { return GetColumnName("COL177534538918"); } 
			}

			/// <summary>
			/// Gets column Comment with alias  
			/// </summary>
			public string ColComment { 
				get { return GetColumnName("COL177534538920"); } 
			}

			/// <summary>
			/// Gets column PaidType with alias  
			/// </summary>
			public string ColPaidType { 
				get { return GetColumnName("COL177534538912"); } 
			}

			/// <summary>
			/// Gets column OutVND with alias  
			/// </summary>
			public string ColOutVND { 
				get { return GetColumnName("COL17753453898"); } 
			}


			/// <summary>
			/// Checks whether column PaymentType is added in select statement 
			/// </summary>
			public bool IsSelectPaymentType { 
				get { return IsSelect("COL17753453893"); } 
				set { SetSelect("COL17753453893", value); } 
			}

			/// <summary>
			/// Checks whether column Created is added in select statement 
			/// </summary>
			public bool IsSelectCreated { 
				get { return IsSelect("COL177534538914"); } 
				set { SetSelect("COL177534538914", value); } 
			}

			/// <summary>
			/// Checks whether column InVND is added in select statement 
			/// </summary>
			public bool IsSelectInVND { 
				get { return IsSelect("COL17753453896"); } 
				set { SetSelect("COL17753453896", value); } 
			}

			/// <summary>
			/// Checks whether column ModifiedBy is added in select statement 
			/// </summary>
			public bool IsSelectModifiedBy { 
				get { return IsSelect("COL177534538917"); } 
				set { SetSelect("COL177534538917", value); } 
			}

			/// <summary>
			/// Checks whether column id is added in select statement 
			/// </summary>
			public bool IsSelectid { 
				get { return IsSelect("COL17753453891"); } 
				set { SetSelect("COL17753453891", value); } 
			}

			/// <summary>
			/// Checks whether column ItemLevel is added in select statement 
			/// </summary>
			public bool IsSelectItemLevel { 
				get { return IsSelect("COL177534538919"); } 
				set { SetSelect("COL177534538919", value); } 
			}

			/// <summary>
			/// Checks whether column OutUSD is added in select statement 
			/// </summary>
			public bool IsSelectOutUSD { 
				get { return IsSelect("COL17753453899"); } 
				set { SetSelect("COL17753453899", value); } 
			}

			/// <summary>
			/// Checks whether column PaymentId is added in select statement 
			/// </summary>
			public bool IsSelectPaymentId { 
				get { return IsSelect("COL17753453894"); } 
				set { SetSelect("COL17753453894", value); } 
			}

			/// <summary>
			/// Checks whether column colNo is added in select statement 
			/// </summary>
			public bool IsSelectcolNo { 
				get { return IsSelect("COL177534538910"); } 
				set { SetSelect("COL177534538910", value); } 
			}

			/// <summary>
			/// Checks whether column bold is added in select statement 
			/// </summary>
			public bool IsSelectbold { 
				get { return IsSelect("COL177534538911"); } 
				set { SetSelect("COL177534538911", value); } 
			}

			/// <summary>
			/// Checks whether column InUSD is added in select statement 
			/// </summary>
			public bool IsSelectInUSD { 
				get { return IsSelect("COL17753453897"); } 
				set { SetSelect("COL17753453897", value); } 
			}

			/// <summary>
			/// Checks whether column DelFlag is added in select statement 
			/// </summary>
			public bool IsSelectDelFlag { 
				get { return IsSelect("COL177534538913"); } 
				set { SetSelect("COL177534538913", value); } 
			}

			/// <summary>
			/// Checks whether column CreatedBy is added in select statement 
			/// </summary>
			public bool IsSelectCreatedBy { 
				get { return IsSelect("COL177534538915"); } 
				set { SetSelect("COL177534538915", value); } 
			}

			/// <summary>
			/// Checks whether column BuggetScheduleId is added in select statement 
			/// </summary>
			public bool IsSelectBuggetScheduleId { 
				get { return IsSelect("COL17753453892"); } 
				set { SetSelect("COL17753453892", value); } 
			}

			/// <summary>
			/// Checks whether column Modified is added in select statement 
			/// </summary>
			public bool IsSelectModified { 
				get { return IsSelect("COL177534538916"); } 
				set { SetSelect("COL177534538916", value); } 
			}

			/// <summary>
			/// Checks whether column ParentId is added in select statement 
			/// </summary>
			public bool IsSelectParentId { 
				get { return IsSelect("COL17753453895"); } 
				set { SetSelect("COL17753453895", value); } 
			}

			/// <summary>
			/// Checks whether column SessionId is added in select statement 
			/// </summary>
			public bool IsSelectSessionId { 
				get { return IsSelect("COL177534538918"); } 
				set { SetSelect("COL177534538918", value); } 
			}

			/// <summary>
			/// Checks whether column Comment is added in select statement 
			/// </summary>
			public bool IsSelectComment { 
				get { return IsSelect("COL177534538920"); } 
				set { SetSelect("COL177534538920", value); } 
			}

			/// <summary>
			/// Checks whether column PaidType is added in select statement 
			/// </summary>
			public bool IsSelectPaidType { 
				get { return IsSelect("COL177534538912"); } 
				set { SetSelect("COL177534538912", value); } 
			}

			/// <summary>
			/// Checks whether column OutVND is added in select statement 
			/// </summary>
			public bool IsSelectOutVND { 
				get { return IsSelect("COL17753453898"); } 
				set { SetSelect("COL17753453898", value); } 
			}



	}
}