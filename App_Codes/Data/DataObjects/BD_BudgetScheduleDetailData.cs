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
	public class BD_BudgetScheduleDetailData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ1919345902";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of BD_BudgetScheduleDetail 
			/// </summary>
			public BD_BudgetScheduleDetailData(string objectID): base(objectID) {}  

			public BD_BudgetScheduleDetailData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field InVND 
			/// </summary>
			public string InVND { 
				get { return GetValue("COL19193459024"); } 
				set { SetValue("COL19193459024", value); } 
			}

			/// <summary>
			/// Gets field InUSD 
			/// </summary>
			public string InUSD { 
				get { return GetValue("COL19193459025"); } 
				set { SetValue("COL19193459025", value); } 
			}

			/// <summary>
			/// Gets field ItemLevel 
			/// </summary>
			public string ItemLevel { 
				get { return GetValue("COL191934590218"); } 
				set { SetValue("COL191934590218", value); } 
			}

			/// <summary>
			/// Gets field PaymentType 
			/// </summary>
			public string PaymentType { 
				get { return GetValue("COL19193459023"); } 
				set { SetValue("COL19193459023", value); } 
			}

			/// <summary>
			/// Gets field ParentId 
			/// </summary>
			public string ParentId { 
				get { return GetValue("COL191934590213"); } 
				set { SetValue("COL191934590213", value); } 
			}

			/// <summary>
			/// Gets field OutVND 
			/// </summary>
			public string OutVND { 
				get { return GetValue("COL19193459026"); } 
				set { SetValue("COL19193459026", value); } 
			}

			/// <summary>
			/// Gets field PaidType 
			/// </summary>
			public string PaidType { 
				get { return GetValue("COL191934590216"); } 
				set { SetValue("COL191934590216", value); } 
			}

			/// <summary>
			/// Gets field CreatedBy 
			/// </summary>
			public string CreatedBy { 
				get { return GetValue("COL19193459029"); } 
				set { SetValue("COL19193459029", value); } 
			}

			/// <summary>
			/// Gets field colNo 
			/// </summary>
			public string colNo { 
				get { return GetValue("COL191934590214"); } 
				set { SetValue("COL191934590214", value); } 
			}

			/// <summary>
			/// Gets field Created 
			/// </summary>
			public string Created { 
				get { return GetValue("COL19193459028"); } 
				set { SetValue("COL19193459028", value); } 
			}

			/// <summary>
			/// Gets field bold 
			/// </summary>
			public string bold { 
				get { return GetValue("COL191934590215"); } 
				set { SetValue("COL191934590215", value); } 
			}

			/// <summary>
			/// Gets field OutUSD 
			/// </summary>
			public string OutUSD { 
				get { return GetValue("COL19193459027"); } 
				set { SetValue("COL19193459027", value); } 
			}

			/// <summary>
			/// Gets field id 
			/// </summary>
			public string id { 
				get { return GetValue("COL19193459021"); } 
				set { SetValue("COL19193459021", value); } 
			}

			/// <summary>
			/// Gets field PaymentId 
			/// </summary>
			public string PaymentId { 
				get { return GetValue("COL191934590212"); } 
				set { SetValue("COL191934590212", value); } 
			}

			/// <summary>
			/// Gets field Modified 
			/// </summary>
			public string Modified { 
				get { return GetValue("COL191934590210"); } 
				set { SetValue("COL191934590210", value); } 
			}

			/// <summary>
			/// Gets field BuggetScheduleId 
			/// </summary>
			public string BuggetScheduleId { 
				get { return GetValue("COL19193459022"); } 
				set { SetValue("COL19193459022", value); } 
			}

			/// <summary>
			/// Gets field ModifiedBy 
			/// </summary>
			public string ModifiedBy { 
				get { return GetValue("COL191934590211"); } 
				set { SetValue("COL191934590211", value); } 
			}

			/// <summary>
			/// Gets field DelFlag 
			/// </summary>
			public string DelFlag { 
				get { return GetValue("COL191934590217"); } 
				set { SetValue("COL191934590217", value); } 
			}

			/// <summary>
			/// Gets field Comment 
			/// </summary>
			public string Comment { 
				get { return GetValue("COL191934590219"); } 
				set { SetValue("COL191934590219", value); } 
			}


			/// <summary>
			/// Gets InVND attribute data 
			/// </summary>
			public AttributeData GetInVNDAttributeData() { 
				return GetAttributeData("COL19193459024"); 
			}

			/// <summary>
			/// Gets InUSD attribute data 
			/// </summary>
			public AttributeData GetInUSDAttributeData() { 
				return GetAttributeData("COL19193459025"); 
			}

			/// <summary>
			/// Gets ItemLevel attribute data 
			/// </summary>
			public AttributeData GetItemLevelAttributeData() { 
				return GetAttributeData("COL191934590218"); 
			}

			/// <summary>
			/// Gets PaymentType attribute data 
			/// </summary>
			public AttributeData GetPaymentTypeAttributeData() { 
				return GetAttributeData("COL19193459023"); 
			}

			/// <summary>
			/// Gets ParentId attribute data 
			/// </summary>
			public AttributeData GetParentIdAttributeData() { 
				return GetAttributeData("COL191934590213"); 
			}

			/// <summary>
			/// Gets OutVND attribute data 
			/// </summary>
			public AttributeData GetOutVNDAttributeData() { 
				return GetAttributeData("COL19193459026"); 
			}

			/// <summary>
			/// Gets PaidType attribute data 
			/// </summary>
			public AttributeData GetPaidTypeAttributeData() { 
				return GetAttributeData("COL191934590216"); 
			}

			/// <summary>
			/// Gets CreatedBy attribute data 
			/// </summary>
			public AttributeData GetCreatedByAttributeData() { 
				return GetAttributeData("COL19193459029"); 
			}

			/// <summary>
			/// Gets colNo attribute data 
			/// </summary>
			public AttributeData GetcolNoAttributeData() { 
				return GetAttributeData("COL191934590214"); 
			}

			/// <summary>
			/// Gets Created attribute data 
			/// </summary>
			public AttributeData GetCreatedAttributeData() { 
				return GetAttributeData("COL19193459028"); 
			}

			/// <summary>
			/// Gets bold attribute data 
			/// </summary>
			public AttributeData GetboldAttributeData() { 
				return GetAttributeData("COL191934590215"); 
			}

			/// <summary>
			/// Gets OutUSD attribute data 
			/// </summary>
			public AttributeData GetOutUSDAttributeData() { 
				return GetAttributeData("COL19193459027"); 
			}

			/// <summary>
			/// Gets id attribute data 
			/// </summary>
			public AttributeData GetidAttributeData() { 
				return GetAttributeData("COL19193459021"); 
			}

			/// <summary>
			/// Gets PaymentId attribute data 
			/// </summary>
			public AttributeData GetPaymentIdAttributeData() { 
				return GetAttributeData("COL191934590212"); 
			}

			/// <summary>
			/// Gets Modified attribute data 
			/// </summary>
			public AttributeData GetModifiedAttributeData() { 
				return GetAttributeData("COL191934590210"); 
			}

			/// <summary>
			/// Gets BuggetScheduleId attribute data 
			/// </summary>
			public AttributeData GetBuggetScheduleIdAttributeData() { 
				return GetAttributeData("COL19193459022"); 
			}

			/// <summary>
			/// Gets ModifiedBy attribute data 
			/// </summary>
			public AttributeData GetModifiedByAttributeData() { 
				return GetAttributeData("COL191934590211"); 
			}

			/// <summary>
			/// Gets DelFlag attribute data 
			/// </summary>
			public AttributeData GetDelFlagAttributeData() { 
				return GetAttributeData("COL191934590217"); 
			}

			/// <summary>
			/// Gets Comment attribute data 
			/// </summary>
			public AttributeData GetCommentAttributeData() { 
				return GetAttributeData("COL191934590219"); 
			}


			/// <summary>
			/// Gets column InVND with alias  
			/// </summary>
			public string ColInVND { 
				get { return GetColumnName("COL19193459024"); } 
			}

			/// <summary>
			/// Gets column InUSD with alias  
			/// </summary>
			public string ColInUSD { 
				get { return GetColumnName("COL19193459025"); } 
			}

			/// <summary>
			/// Gets column ItemLevel with alias  
			/// </summary>
			public string ColItemLevel { 
				get { return GetColumnName("COL191934590218"); } 
			}

			/// <summary>
			/// Gets column PaymentType with alias  
			/// </summary>
			public string ColPaymentType { 
				get { return GetColumnName("COL19193459023"); } 
			}

			/// <summary>
			/// Gets column ParentId with alias  
			/// </summary>
			public string ColParentId { 
				get { return GetColumnName("COL191934590213"); } 
			}

			/// <summary>
			/// Gets column OutVND with alias  
			/// </summary>
			public string ColOutVND { 
				get { return GetColumnName("COL19193459026"); } 
			}

			/// <summary>
			/// Gets column PaidType with alias  
			/// </summary>
			public string ColPaidType { 
				get { return GetColumnName("COL191934590216"); } 
			}

			/// <summary>
			/// Gets column CreatedBy with alias  
			/// </summary>
			public string ColCreatedBy { 
				get { return GetColumnName("COL19193459029"); } 
			}

			/// <summary>
			/// Gets column colNo with alias  
			/// </summary>
			public string ColcolNo { 
				get { return GetColumnName("COL191934590214"); } 
			}

			/// <summary>
			/// Gets column Created with alias  
			/// </summary>
			public string ColCreated { 
				get { return GetColumnName("COL19193459028"); } 
			}

			/// <summary>
			/// Gets column bold with alias  
			/// </summary>
			public string Colbold { 
				get { return GetColumnName("COL191934590215"); } 
			}

			/// <summary>
			/// Gets column OutUSD with alias  
			/// </summary>
			public string ColOutUSD { 
				get { return GetColumnName("COL19193459027"); } 
			}

			/// <summary>
			/// Gets column id with alias  
			/// </summary>
			public string Colid { 
				get { return GetColumnName("COL19193459021"); } 
			}

			/// <summary>
			/// Gets column PaymentId with alias  
			/// </summary>
			public string ColPaymentId { 
				get { return GetColumnName("COL191934590212"); } 
			}

			/// <summary>
			/// Gets column Modified with alias  
			/// </summary>
			public string ColModified { 
				get { return GetColumnName("COL191934590210"); } 
			}

			/// <summary>
			/// Gets column BuggetScheduleId with alias  
			/// </summary>
			public string ColBuggetScheduleId { 
				get { return GetColumnName("COL19193459022"); } 
			}

			/// <summary>
			/// Gets column ModifiedBy with alias  
			/// </summary>
			public string ColModifiedBy { 
				get { return GetColumnName("COL191934590211"); } 
			}

			/// <summary>
			/// Gets column DelFlag with alias  
			/// </summary>
			public string ColDelFlag { 
				get { return GetColumnName("COL191934590217"); } 
			}

			/// <summary>
			/// Gets column Comment with alias  
			/// </summary>
			public string ColComment { 
				get { return GetColumnName("COL191934590219"); } 
			}


			/// <summary>
			/// Checks whether column InVND is added in select statement 
			/// </summary>
			public bool IsSelectInVND { 
				get { return IsSelect("COL19193459024"); } 
				set { SetSelect("COL19193459024", value); } 
			}

			/// <summary>
			/// Checks whether column InUSD is added in select statement 
			/// </summary>
			public bool IsSelectInUSD { 
				get { return IsSelect("COL19193459025"); } 
				set { SetSelect("COL19193459025", value); } 
			}

			/// <summary>
			/// Checks whether column ItemLevel is added in select statement 
			/// </summary>
			public bool IsSelectItemLevel { 
				get { return IsSelect("COL191934590218"); } 
				set { SetSelect("COL191934590218", value); } 
			}

			/// <summary>
			/// Checks whether column PaymentType is added in select statement 
			/// </summary>
			public bool IsSelectPaymentType { 
				get { return IsSelect("COL19193459023"); } 
				set { SetSelect("COL19193459023", value); } 
			}

			/// <summary>
			/// Checks whether column ParentId is added in select statement 
			/// </summary>
			public bool IsSelectParentId { 
				get { return IsSelect("COL191934590213"); } 
				set { SetSelect("COL191934590213", value); } 
			}

			/// <summary>
			/// Checks whether column OutVND is added in select statement 
			/// </summary>
			public bool IsSelectOutVND { 
				get { return IsSelect("COL19193459026"); } 
				set { SetSelect("COL19193459026", value); } 
			}

			/// <summary>
			/// Checks whether column PaidType is added in select statement 
			/// </summary>
			public bool IsSelectPaidType { 
				get { return IsSelect("COL191934590216"); } 
				set { SetSelect("COL191934590216", value); } 
			}

			/// <summary>
			/// Checks whether column CreatedBy is added in select statement 
			/// </summary>
			public bool IsSelectCreatedBy { 
				get { return IsSelect("COL19193459029"); } 
				set { SetSelect("COL19193459029", value); } 
			}

			/// <summary>
			/// Checks whether column colNo is added in select statement 
			/// </summary>
			public bool IsSelectcolNo { 
				get { return IsSelect("COL191934590214"); } 
				set { SetSelect("COL191934590214", value); } 
			}

			/// <summary>
			/// Checks whether column Created is added in select statement 
			/// </summary>
			public bool IsSelectCreated { 
				get { return IsSelect("COL19193459028"); } 
				set { SetSelect("COL19193459028", value); } 
			}

			/// <summary>
			/// Checks whether column bold is added in select statement 
			/// </summary>
			public bool IsSelectbold { 
				get { return IsSelect("COL191934590215"); } 
				set { SetSelect("COL191934590215", value); } 
			}

			/// <summary>
			/// Checks whether column OutUSD is added in select statement 
			/// </summary>
			public bool IsSelectOutUSD { 
				get { return IsSelect("COL19193459027"); } 
				set { SetSelect("COL19193459027", value); } 
			}

			/// <summary>
			/// Checks whether column id is added in select statement 
			/// </summary>
			public bool IsSelectid { 
				get { return IsSelect("COL19193459021"); } 
				set { SetSelect("COL19193459021", value); } 
			}

			/// <summary>
			/// Checks whether column PaymentId is added in select statement 
			/// </summary>
			public bool IsSelectPaymentId { 
				get { return IsSelect("COL191934590212"); } 
				set { SetSelect("COL191934590212", value); } 
			}

			/// <summary>
			/// Checks whether column Modified is added in select statement 
			/// </summary>
			public bool IsSelectModified { 
				get { return IsSelect("COL191934590210"); } 
				set { SetSelect("COL191934590210", value); } 
			}

			/// <summary>
			/// Checks whether column BuggetScheduleId is added in select statement 
			/// </summary>
			public bool IsSelectBuggetScheduleId { 
				get { return IsSelect("COL19193459022"); } 
				set { SetSelect("COL19193459022", value); } 
			}

			/// <summary>
			/// Checks whether column ModifiedBy is added in select statement 
			/// </summary>
			public bool IsSelectModifiedBy { 
				get { return IsSelect("COL191934590211"); } 
				set { SetSelect("COL191934590211", value); } 
			}

			/// <summary>
			/// Checks whether column DelFlag is added in select statement 
			/// </summary>
			public bool IsSelectDelFlag { 
				get { return IsSelect("COL191934590217"); } 
				set { SetSelect("COL191934590217", value); } 
			}

			/// <summary>
			/// Checks whether column Comment is added in select statement 
			/// </summary>
			public bool IsSelectComment { 
				get { return IsSelect("COL191934590219"); } 
				set { SetSelect("COL191934590219", value); } 
			}



	}
}