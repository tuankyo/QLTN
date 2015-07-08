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
	public class BD_SuppliesData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ802101898";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of BD_Supplies 
			/// </summary>
			public BD_SuppliesData(string objectID): base(objectID) {}  

			public BD_SuppliesData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field JobType 
			/// </summary>
			public string JobType { 
				get { return GetValue("COL8021018984"); } 
				set { SetValue("COL8021018984", value); } 
			}

			/// <summary>
			/// Gets field Name 
			/// </summary>
			public string Name { 
				get { return GetValue("COL8021018987"); } 
				set { SetValue("COL8021018987", value); } 
			}

			/// <summary>
			/// Gets field ItemId 
			/// </summary>
			public string ItemId { 
				get { return GetValue("COL8021018986"); } 
				set { SetValue("COL8021018986", value); } 
			}

			/// <summary>
			/// Gets field id 
			/// </summary>
			public string id { 
				get { return GetValue("COL8021018981"); } 
				set { SetValue("COL8021018981", value); } 
			}

			/// <summary>
			/// Gets field BuildingId 
			/// </summary>
			public string BuildingId { 
				get { return GetValue("COL8021018983"); } 
				set { SetValue("COL8021018983", value); } 
			}

			/// <summary>
			/// Gets field CreatedId 
			/// </summary>
			public string CreatedId { 
				get { return GetValue("COL8021018982"); } 
				set { SetValue("COL8021018982", value); } 
			}

			/// <summary>
			/// Gets field CreatedBy 
			/// </summary>
			public string CreatedBy { 
				get { return GetValue("COL80210189812"); } 
				set { SetValue("COL80210189812", value); } 
			}

			/// <summary>
			/// Gets field Regional 
			/// </summary>
			public string Regional { 
				get { return GetValue("COL80210189819"); } 
				set { SetValue("COL80210189819", value); } 
			}

			/// <summary>
			/// Gets field DelFlag 
			/// </summary>
			public string DelFlag { 
				get { return GetValue("COL80210189815"); } 
				set { SetValue("COL80210189815", value); } 
			}

			/// <summary>
			/// Gets field ModifiedBy 
			/// </summary>
			public string ModifiedBy { 
				get { return GetValue("COL80210189814"); } 
				set { SetValue("COL80210189814", value); } 
			}

			/// <summary>
			/// Gets field RefId 
			/// </summary>
			public string RefId { 
				get { return GetValue("COL80210189820"); } 
				set { SetValue("COL80210189820", value); } 
			}

			/// <summary>
			/// Gets field Comment 
			/// </summary>
			public string Comment { 
				get { return GetValue("COL80210189810"); } 
				set { SetValue("COL80210189810", value); } 
			}

			/// <summary>
			/// Gets field Label 
			/// </summary>
			public string Label { 
				get { return GetValue("COL80210189818"); } 
				set { SetValue("COL80210189818", value); } 
			}

			/// <summary>
			/// Gets field Modified 
			/// </summary>
			public string Modified { 
				get { return GetValue("COL80210189813"); } 
				set { SetValue("COL80210189813", value); } 
			}

			/// <summary>
			/// Gets field Model 
			/// </summary>
			public string Model { 
				get { return GetValue("COL80210189816"); } 
				set { SetValue("COL80210189816", value); } 
			}

			/// <summary>
			/// Gets field Created 
			/// </summary>
			public string Created { 
				get { return GetValue("COL80210189811"); } 
				set { SetValue("COL80210189811", value); } 
			}

			/// <summary>
			/// Gets field ProductOf 
			/// </summary>
			public string ProductOf { 
				get { return GetValue("COL8021018989"); } 
				set { SetValue("COL8021018989", value); } 
			}

			/// <summary>
			/// Gets field Description 
			/// </summary>
			public string Description { 
				get { return GetValue("COL8021018988"); } 
				set { SetValue("COL8021018988", value); } 
			}

			/// <summary>
			/// Gets field SuppliesType 
			/// </summary>
			public string SuppliesType { 
				get { return GetValue("COL8021018985"); } 
				set { SetValue("COL8021018985", value); } 
			}


			/// <summary>
			/// Gets JobType attribute data 
			/// </summary>
			public AttributeData GetJobTypeAttributeData() { 
				return GetAttributeData("COL8021018984"); 
			}

			/// <summary>
			/// Gets Name attribute data 
			/// </summary>
			public AttributeData GetNameAttributeData() { 
				return GetAttributeData("COL8021018987"); 
			}

			/// <summary>
			/// Gets ItemId attribute data 
			/// </summary>
			public AttributeData GetItemIdAttributeData() { 
				return GetAttributeData("COL8021018986"); 
			}

			/// <summary>
			/// Gets id attribute data 
			/// </summary>
			public AttributeData GetidAttributeData() { 
				return GetAttributeData("COL8021018981"); 
			}

			/// <summary>
			/// Gets BuildingId attribute data 
			/// </summary>
			public AttributeData GetBuildingIdAttributeData() { 
				return GetAttributeData("COL8021018983"); 
			}

			/// <summary>
			/// Gets CreatedId attribute data 
			/// </summary>
			public AttributeData GetCreatedIdAttributeData() { 
				return GetAttributeData("COL8021018982"); 
			}

			/// <summary>
			/// Gets CreatedBy attribute data 
			/// </summary>
			public AttributeData GetCreatedByAttributeData() { 
				return GetAttributeData("COL80210189812"); 
			}

			/// <summary>
			/// Gets Regional attribute data 
			/// </summary>
			public AttributeData GetRegionalAttributeData() { 
				return GetAttributeData("COL80210189819"); 
			}

			/// <summary>
			/// Gets DelFlag attribute data 
			/// </summary>
			public AttributeData GetDelFlagAttributeData() { 
				return GetAttributeData("COL80210189815"); 
			}

			/// <summary>
			/// Gets ModifiedBy attribute data 
			/// </summary>
			public AttributeData GetModifiedByAttributeData() { 
				return GetAttributeData("COL80210189814"); 
			}

			/// <summary>
			/// Gets RefId attribute data 
			/// </summary>
			public AttributeData GetRefIdAttributeData() { 
				return GetAttributeData("COL80210189820"); 
			}

			/// <summary>
			/// Gets Comment attribute data 
			/// </summary>
			public AttributeData GetCommentAttributeData() { 
				return GetAttributeData("COL80210189810"); 
			}

			/// <summary>
			/// Gets Label attribute data 
			/// </summary>
			public AttributeData GetLabelAttributeData() { 
				return GetAttributeData("COL80210189818"); 
			}

			/// <summary>
			/// Gets Modified attribute data 
			/// </summary>
			public AttributeData GetModifiedAttributeData() { 
				return GetAttributeData("COL80210189813"); 
			}

			/// <summary>
			/// Gets Model attribute data 
			/// </summary>
			public AttributeData GetModelAttributeData() { 
				return GetAttributeData("COL80210189816"); 
			}

			/// <summary>
			/// Gets Created attribute data 
			/// </summary>
			public AttributeData GetCreatedAttributeData() { 
				return GetAttributeData("COL80210189811"); 
			}

			/// <summary>
			/// Gets ProductOf attribute data 
			/// </summary>
			public AttributeData GetProductOfAttributeData() { 
				return GetAttributeData("COL8021018989"); 
			}

			/// <summary>
			/// Gets Description attribute data 
			/// </summary>
			public AttributeData GetDescriptionAttributeData() { 
				return GetAttributeData("COL8021018988"); 
			}

			/// <summary>
			/// Gets SuppliesType attribute data 
			/// </summary>
			public AttributeData GetSuppliesTypeAttributeData() { 
				return GetAttributeData("COL8021018985"); 
			}


			/// <summary>
			/// Gets column JobType with alias  
			/// </summary>
			public string ColJobType { 
				get { return GetColumnName("COL8021018984"); } 
			}

			/// <summary>
			/// Gets column Name with alias  
			/// </summary>
			public string ColName { 
				get { return GetColumnName("COL8021018987"); } 
			}

			/// <summary>
			/// Gets column ItemId with alias  
			/// </summary>
			public string ColItemId { 
				get { return GetColumnName("COL8021018986"); } 
			}

			/// <summary>
			/// Gets column id with alias  
			/// </summary>
			public string Colid { 
				get { return GetColumnName("COL8021018981"); } 
			}

			/// <summary>
			/// Gets column BuildingId with alias  
			/// </summary>
			public string ColBuildingId { 
				get { return GetColumnName("COL8021018983"); } 
			}

			/// <summary>
			/// Gets column CreatedId with alias  
			/// </summary>
			public string ColCreatedId { 
				get { return GetColumnName("COL8021018982"); } 
			}

			/// <summary>
			/// Gets column CreatedBy with alias  
			/// </summary>
			public string ColCreatedBy { 
				get { return GetColumnName("COL80210189812"); } 
			}

			/// <summary>
			/// Gets column Regional with alias  
			/// </summary>
			public string ColRegional { 
				get { return GetColumnName("COL80210189819"); } 
			}

			/// <summary>
			/// Gets column DelFlag with alias  
			/// </summary>
			public string ColDelFlag { 
				get { return GetColumnName("COL80210189815"); } 
			}

			/// <summary>
			/// Gets column ModifiedBy with alias  
			/// </summary>
			public string ColModifiedBy { 
				get { return GetColumnName("COL80210189814"); } 
			}

			/// <summary>
			/// Gets column RefId with alias  
			/// </summary>
			public string ColRefId { 
				get { return GetColumnName("COL80210189820"); } 
			}

			/// <summary>
			/// Gets column Comment with alias  
			/// </summary>
			public string ColComment { 
				get { return GetColumnName("COL80210189810"); } 
			}

			/// <summary>
			/// Gets column Label with alias  
			/// </summary>
			public string ColLabel { 
				get { return GetColumnName("COL80210189818"); } 
			}

			/// <summary>
			/// Gets column Modified with alias  
			/// </summary>
			public string ColModified { 
				get { return GetColumnName("COL80210189813"); } 
			}

			/// <summary>
			/// Gets column Model with alias  
			/// </summary>
			public string ColModel { 
				get { return GetColumnName("COL80210189816"); } 
			}

			/// <summary>
			/// Gets column Created with alias  
			/// </summary>
			public string ColCreated { 
				get { return GetColumnName("COL80210189811"); } 
			}

			/// <summary>
			/// Gets column ProductOf with alias  
			/// </summary>
			public string ColProductOf { 
				get { return GetColumnName("COL8021018989"); } 
			}

			/// <summary>
			/// Gets column Description with alias  
			/// </summary>
			public string ColDescription { 
				get { return GetColumnName("COL8021018988"); } 
			}

			/// <summary>
			/// Gets column SuppliesType with alias  
			/// </summary>
			public string ColSuppliesType { 
				get { return GetColumnName("COL8021018985"); } 
			}


			/// <summary>
			/// Checks whether column JobType is added in select statement 
			/// </summary>
			public bool IsSelectJobType { 
				get { return IsSelect("COL8021018984"); } 
				set { SetSelect("COL8021018984", value); } 
			}

			/// <summary>
			/// Checks whether column Name is added in select statement 
			/// </summary>
			public bool IsSelectName { 
				get { return IsSelect("COL8021018987"); } 
				set { SetSelect("COL8021018987", value); } 
			}

			/// <summary>
			/// Checks whether column ItemId is added in select statement 
			/// </summary>
			public bool IsSelectItemId { 
				get { return IsSelect("COL8021018986"); } 
				set { SetSelect("COL8021018986", value); } 
			}

			/// <summary>
			/// Checks whether column id is added in select statement 
			/// </summary>
			public bool IsSelectid { 
				get { return IsSelect("COL8021018981"); } 
				set { SetSelect("COL8021018981", value); } 
			}

			/// <summary>
			/// Checks whether column BuildingId is added in select statement 
			/// </summary>
			public bool IsSelectBuildingId { 
				get { return IsSelect("COL8021018983"); } 
				set { SetSelect("COL8021018983", value); } 
			}

			/// <summary>
			/// Checks whether column CreatedId is added in select statement 
			/// </summary>
			public bool IsSelectCreatedId { 
				get { return IsSelect("COL8021018982"); } 
				set { SetSelect("COL8021018982", value); } 
			}

			/// <summary>
			/// Checks whether column CreatedBy is added in select statement 
			/// </summary>
			public bool IsSelectCreatedBy { 
				get { return IsSelect("COL80210189812"); } 
				set { SetSelect("COL80210189812", value); } 
			}

			/// <summary>
			/// Checks whether column Regional is added in select statement 
			/// </summary>
			public bool IsSelectRegional { 
				get { return IsSelect("COL80210189819"); } 
				set { SetSelect("COL80210189819", value); } 
			}

			/// <summary>
			/// Checks whether column DelFlag is added in select statement 
			/// </summary>
			public bool IsSelectDelFlag { 
				get { return IsSelect("COL80210189815"); } 
				set { SetSelect("COL80210189815", value); } 
			}

			/// <summary>
			/// Checks whether column ModifiedBy is added in select statement 
			/// </summary>
			public bool IsSelectModifiedBy { 
				get { return IsSelect("COL80210189814"); } 
				set { SetSelect("COL80210189814", value); } 
			}

			/// <summary>
			/// Checks whether column RefId is added in select statement 
			/// </summary>
			public bool IsSelectRefId { 
				get { return IsSelect("COL80210189820"); } 
				set { SetSelect("COL80210189820", value); } 
			}

			/// <summary>
			/// Checks whether column Comment is added in select statement 
			/// </summary>
			public bool IsSelectComment { 
				get { return IsSelect("COL80210189810"); } 
				set { SetSelect("COL80210189810", value); } 
			}

			/// <summary>
			/// Checks whether column Label is added in select statement 
			/// </summary>
			public bool IsSelectLabel { 
				get { return IsSelect("COL80210189818"); } 
				set { SetSelect("COL80210189818", value); } 
			}

			/// <summary>
			/// Checks whether column Modified is added in select statement 
			/// </summary>
			public bool IsSelectModified { 
				get { return IsSelect("COL80210189813"); } 
				set { SetSelect("COL80210189813", value); } 
			}

			/// <summary>
			/// Checks whether column Model is added in select statement 
			/// </summary>
			public bool IsSelectModel { 
				get { return IsSelect("COL80210189816"); } 
				set { SetSelect("COL80210189816", value); } 
			}

			/// <summary>
			/// Checks whether column Created is added in select statement 
			/// </summary>
			public bool IsSelectCreated { 
				get { return IsSelect("COL80210189811"); } 
				set { SetSelect("COL80210189811", value); } 
			}

			/// <summary>
			/// Checks whether column ProductOf is added in select statement 
			/// </summary>
			public bool IsSelectProductOf { 
				get { return IsSelect("COL8021018989"); } 
				set { SetSelect("COL8021018989", value); } 
			}

			/// <summary>
			/// Checks whether column Description is added in select statement 
			/// </summary>
			public bool IsSelectDescription { 
				get { return IsSelect("COL8021018988"); } 
				set { SetSelect("COL8021018988", value); } 
			}

			/// <summary>
			/// Checks whether column SuppliesType is added in select statement 
			/// </summary>
			public bool IsSelectSuppliesType { 
				get { return IsSelect("COL8021018985"); } 
				set { SetSelect("COL8021018985", value); } 
			}



	}
}