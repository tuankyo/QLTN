// ==========================================
//  Author : GNT Data Object Generator Tool
//  Created   : 2014-10-21 16:06:45
//  Copyright GNT INC.  All rights reserved.
// ==========================================
using System;
using System.Collections;
using Gnt.Data.Meta;
using Gnt.Data;

namespace BusinessObjects
{

	[Serializable]
	public class BD_PaymentTypeData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ1647344933";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of BD_PaymentType 
			/// </summary>
			public BD_PaymentTypeData(string objectID): base(objectID) {}  

			public BD_PaymentTypeData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field CreatedBy 
			/// </summary>
			public string CreatedBy { 
				get { return GetValue("COL164734493310"); } 
				set { SetValue("COL164734493310", value); } 
			}

			/// <summary>
			/// Gets field ModifiedBy 
			/// </summary>
			public string ModifiedBy { 
				get { return GetValue("COL164734493312"); } 
				set { SetValue("COL164734493312", value); } 
			}

			/// <summary>
			/// Gets field DeleteAllowFlg 
			/// </summary>
			public string DeleteAllowFlg { 
				get { return GetValue("COL16473449337"); } 
				set { SetValue("COL16473449337", value); } 
			}

			/// <summary>
			/// Gets field BuildingId 
			/// </summary>
			public string BuildingId { 
				get { return GetValue("COL16473449332"); } 
				set { SetValue("COL16473449332", value); } 
			}

			/// <summary>
			/// Gets field Created 
			/// </summary>
			public string Created { 
				get { return GetValue("COL16473449339"); } 
				set { SetValue("COL16473449339", value); } 
			}

			/// <summary>
			/// Gets field id 
			/// </summary>
			public string id { 
				get { return GetValue("COL16473449331"); } 
				set { SetValue("COL16473449331", value); } 
			}

			/// <summary>
			/// Gets field Modified 
			/// </summary>
			public string Modified { 
				get { return GetValue("COL164734493311"); } 
				set { SetValue("COL164734493311", value); } 
			}

			/// <summary>
			/// Gets field PaidType 
			/// </summary>
			public string PaidType { 
				get { return GetValue("COL16473449334"); } 
				set { SetValue("COL16473449334", value); } 
			}

			/// <summary>
			/// Gets field Name 
			/// </summary>
			public string Name { 
				get { return GetValue("COL16473449333"); } 
				set { SetValue("COL16473449333", value); } 
			}

			/// <summary>
			/// Gets field DelFlag 
			/// </summary>
			public string DelFlag { 
				get { return GetValue("COL164734493313"); } 
				set { SetValue("COL164734493313", value); } 
			}

			/// <summary>
			/// Gets field ItemLevel 
			/// </summary>
			public string ItemLevel { 
				get { return GetValue("COL16473449336"); } 
				set { SetValue("COL16473449336", value); } 
			}

			/// <summary>
			/// Gets field Comment 
			/// </summary>
			public string Comment { 
				get { return GetValue("COL164734493314"); } 
				set { SetValue("COL164734493314", value); } 
			}

			/// <summary>
			/// Gets field specialPay 
			/// </summary>
			public string specialPay { 
				get { return GetValue("COL16473449338"); } 
				set { SetValue("COL16473449338", value); } 
			}

			/// <summary>
			/// Gets field ParentId 
			/// </summary>
			public string ParentId { 
				get { return GetValue("COL16473449335"); } 
				set { SetValue("COL16473449335", value); } 
			}


			/// <summary>
			/// Gets CreatedBy attribute data 
			/// </summary>
			public AttributeData GetCreatedByAttributeData() { 
				return GetAttributeData("COL164734493310"); 
			}

			/// <summary>
			/// Gets ModifiedBy attribute data 
			/// </summary>
			public AttributeData GetModifiedByAttributeData() { 
				return GetAttributeData("COL164734493312"); 
			}

			/// <summary>
			/// Gets DeleteAllowFlg attribute data 
			/// </summary>
			public AttributeData GetDeleteAllowFlgAttributeData() { 
				return GetAttributeData("COL16473449337"); 
			}

			/// <summary>
			/// Gets BuildingId attribute data 
			/// </summary>
			public AttributeData GetBuildingIdAttributeData() { 
				return GetAttributeData("COL16473449332"); 
			}

			/// <summary>
			/// Gets Created attribute data 
			/// </summary>
			public AttributeData GetCreatedAttributeData() { 
				return GetAttributeData("COL16473449339"); 
			}

			/// <summary>
			/// Gets id attribute data 
			/// </summary>
			public AttributeData GetidAttributeData() { 
				return GetAttributeData("COL16473449331"); 
			}

			/// <summary>
			/// Gets Modified attribute data 
			/// </summary>
			public AttributeData GetModifiedAttributeData() { 
				return GetAttributeData("COL164734493311"); 
			}

			/// <summary>
			/// Gets PaidType attribute data 
			/// </summary>
			public AttributeData GetPaidTypeAttributeData() { 
				return GetAttributeData("COL16473449334"); 
			}

			/// <summary>
			/// Gets Name attribute data 
			/// </summary>
			public AttributeData GetNameAttributeData() { 
				return GetAttributeData("COL16473449333"); 
			}

			/// <summary>
			/// Gets DelFlag attribute data 
			/// </summary>
			public AttributeData GetDelFlagAttributeData() { 
				return GetAttributeData("COL164734493313"); 
			}

			/// <summary>
			/// Gets ItemLevel attribute data 
			/// </summary>
			public AttributeData GetItemLevelAttributeData() { 
				return GetAttributeData("COL16473449336"); 
			}

			/// <summary>
			/// Gets Comment attribute data 
			/// </summary>
			public AttributeData GetCommentAttributeData() { 
				return GetAttributeData("COL164734493314"); 
			}

			/// <summary>
			/// Gets specialPay attribute data 
			/// </summary>
			public AttributeData GetspecialPayAttributeData() { 
				return GetAttributeData("COL16473449338"); 
			}

			/// <summary>
			/// Gets ParentId attribute data 
			/// </summary>
			public AttributeData GetParentIdAttributeData() { 
				return GetAttributeData("COL16473449335"); 
			}


			/// <summary>
			/// Gets column CreatedBy with alias  
			/// </summary>
			public string ColCreatedBy { 
				get { return GetColumnName("COL164734493310"); } 
			}

			/// <summary>
			/// Gets column ModifiedBy with alias  
			/// </summary>
			public string ColModifiedBy { 
				get { return GetColumnName("COL164734493312"); } 
			}

			/// <summary>
			/// Gets column DeleteAllowFlg with alias  
			/// </summary>
			public string ColDeleteAllowFlg { 
				get { return GetColumnName("COL16473449337"); } 
			}

			/// <summary>
			/// Gets column BuildingId with alias  
			/// </summary>
			public string ColBuildingId { 
				get { return GetColumnName("COL16473449332"); } 
			}

			/// <summary>
			/// Gets column Created with alias  
			/// </summary>
			public string ColCreated { 
				get { return GetColumnName("COL16473449339"); } 
			}

			/// <summary>
			/// Gets column id with alias  
			/// </summary>
			public string Colid { 
				get { return GetColumnName("COL16473449331"); } 
			}

			/// <summary>
			/// Gets column Modified with alias  
			/// </summary>
			public string ColModified { 
				get { return GetColumnName("COL164734493311"); } 
			}

			/// <summary>
			/// Gets column PaidType with alias  
			/// </summary>
			public string ColPaidType { 
				get { return GetColumnName("COL16473449334"); } 
			}

			/// <summary>
			/// Gets column Name with alias  
			/// </summary>
			public string ColName { 
				get { return GetColumnName("COL16473449333"); } 
			}

			/// <summary>
			/// Gets column DelFlag with alias  
			/// </summary>
			public string ColDelFlag { 
				get { return GetColumnName("COL164734493313"); } 
			}

			/// <summary>
			/// Gets column ItemLevel with alias  
			/// </summary>
			public string ColItemLevel { 
				get { return GetColumnName("COL16473449336"); } 
			}

			/// <summary>
			/// Gets column Comment with alias  
			/// </summary>
			public string ColComment { 
				get { return GetColumnName("COL164734493314"); } 
			}

			/// <summary>
			/// Gets column specialPay with alias  
			/// </summary>
			public string ColspecialPay { 
				get { return GetColumnName("COL16473449338"); } 
			}

			/// <summary>
			/// Gets column ParentId with alias  
			/// </summary>
			public string ColParentId { 
				get { return GetColumnName("COL16473449335"); } 
			}


			/// <summary>
			/// Checks whether column CreatedBy is added in select statement 
			/// </summary>
			public bool IsSelectCreatedBy { 
				get { return IsSelect("COL164734493310"); } 
				set { SetSelect("COL164734493310", value); } 
			}

			/// <summary>
			/// Checks whether column ModifiedBy is added in select statement 
			/// </summary>
			public bool IsSelectModifiedBy { 
				get { return IsSelect("COL164734493312"); } 
				set { SetSelect("COL164734493312", value); } 
			}

			/// <summary>
			/// Checks whether column DeleteAllowFlg is added in select statement 
			/// </summary>
			public bool IsSelectDeleteAllowFlg { 
				get { return IsSelect("COL16473449337"); } 
				set { SetSelect("COL16473449337", value); } 
			}

			/// <summary>
			/// Checks whether column BuildingId is added in select statement 
			/// </summary>
			public bool IsSelectBuildingId { 
				get { return IsSelect("COL16473449332"); } 
				set { SetSelect("COL16473449332", value); } 
			}

			/// <summary>
			/// Checks whether column Created is added in select statement 
			/// </summary>
			public bool IsSelectCreated { 
				get { return IsSelect("COL16473449339"); } 
				set { SetSelect("COL16473449339", value); } 
			}

			/// <summary>
			/// Checks whether column id is added in select statement 
			/// </summary>
			public bool IsSelectid { 
				get { return IsSelect("COL16473449331"); } 
				set { SetSelect("COL16473449331", value); } 
			}

			/// <summary>
			/// Checks whether column Modified is added in select statement 
			/// </summary>
			public bool IsSelectModified { 
				get { return IsSelect("COL164734493311"); } 
				set { SetSelect("COL164734493311", value); } 
			}

			/// <summary>
			/// Checks whether column PaidType is added in select statement 
			/// </summary>
			public bool IsSelectPaidType { 
				get { return IsSelect("COL16473449334"); } 
				set { SetSelect("COL16473449334", value); } 
			}

			/// <summary>
			/// Checks whether column Name is added in select statement 
			/// </summary>
			public bool IsSelectName { 
				get { return IsSelect("COL16473449333"); } 
				set { SetSelect("COL16473449333", value); } 
			}

			/// <summary>
			/// Checks whether column DelFlag is added in select statement 
			/// </summary>
			public bool IsSelectDelFlag { 
				get { return IsSelect("COL164734493313"); } 
				set { SetSelect("COL164734493313", value); } 
			}

			/// <summary>
			/// Checks whether column ItemLevel is added in select statement 
			/// </summary>
			public bool IsSelectItemLevel { 
				get { return IsSelect("COL16473449336"); } 
				set { SetSelect("COL16473449336", value); } 
			}

			/// <summary>
			/// Checks whether column Comment is added in select statement 
			/// </summary>
			public bool IsSelectComment { 
				get { return IsSelect("COL164734493314"); } 
				set { SetSelect("COL164734493314", value); } 
			}

			/// <summary>
			/// Checks whether column specialPay is added in select statement 
			/// </summary>
			public bool IsSelectspecialPay { 
				get { return IsSelect("COL16473449338"); } 
				set { SetSelect("COL16473449338", value); } 
			}

			/// <summary>
			/// Checks whether column ParentId is added in select statement 
			/// </summary>
			public bool IsSelectParentId { 
				get { return IsSelect("COL16473449335"); } 
				set { SetSelect("COL16473449335", value); } 
			}



	}
}