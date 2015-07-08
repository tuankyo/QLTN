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
	public class BD_ProviderData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ1122103038";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of BD_Provider 
			/// </summary>
			public BD_ProviderData(string objectID): base(objectID) {}  

			public BD_ProviderData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field CreatedBy 
			/// </summary>
			public string CreatedBy { 
				get { return GetValue("COL112210303810"); } 
				set { SetValue("COL112210303810", value); } 
			}

			/// <summary>
			/// Gets field Created 
			/// </summary>
			public string Created { 
				get { return GetValue("COL11221030389"); } 
				set { SetValue("COL11221030389", value); } 
			}

			/// <summary>
			/// Gets field Modified 
			/// </summary>
			public string Modified { 
				get { return GetValue("COL112210303811"); } 
				set { SetValue("COL112210303811", value); } 
			}

			/// <summary>
			/// Gets field id 
			/// </summary>
			public string id { 
				get { return GetValue("COL11221030381"); } 
				set { SetValue("COL11221030381", value); } 
			}

			/// <summary>
			/// Gets field Contact 
			/// </summary>
			public string Contact { 
				get { return GetValue("COL11221030386"); } 
				set { SetValue("COL11221030386", value); } 
			}

			/// <summary>
			/// Gets field Dept 
			/// </summary>
			public string Dept { 
				get { return GetValue("COL112210303814"); } 
				set { SetValue("COL112210303814", value); } 
			}

			/// <summary>
			/// Gets field Name 
			/// </summary>
			public string Name { 
				get { return GetValue("COL11221030383"); } 
				set { SetValue("COL11221030383", value); } 
			}

			/// <summary>
			/// Gets field Comment 
			/// </summary>
			public string Comment { 
				get { return GetValue("COL11221030388"); } 
				set { SetValue("COL11221030388", value); } 
			}

			/// <summary>
			/// Gets field Address 
			/// </summary>
			public string Address { 
				get { return GetValue("COL11221030384"); } 
				set { SetValue("COL11221030384", value); } 
			}

			/// <summary>
			/// Gets field Phone 
			/// </summary>
			public string Phone { 
				get { return GetValue("COL11221030385"); } 
				set { SetValue("COL11221030385", value); } 
			}

			/// <summary>
			/// Gets field ModifiedBy 
			/// </summary>
			public string ModifiedBy { 
				get { return GetValue("COL112210303812"); } 
				set { SetValue("COL112210303812", value); } 
			}

			/// <summary>
			/// Gets field BuildingId 
			/// </summary>
			public string BuildingId { 
				get { return GetValue("COL11221030382"); } 
				set { SetValue("COL11221030382", value); } 
			}

			/// <summary>
			/// Gets field GoodsProvider 
			/// </summary>
			public string GoodsProvider { 
				get { return GetValue("COL11221030387"); } 
				set { SetValue("COL11221030387", value); } 
			}

			/// <summary>
			/// Gets field DelFlag 
			/// </summary>
			public string DelFlag { 
				get { return GetValue("COL112210303813"); } 
				set { SetValue("COL112210303813", value); } 
			}


			/// <summary>
			/// Gets CreatedBy attribute data 
			/// </summary>
			public AttributeData GetCreatedByAttributeData() { 
				return GetAttributeData("COL112210303810"); 
			}

			/// <summary>
			/// Gets Created attribute data 
			/// </summary>
			public AttributeData GetCreatedAttributeData() { 
				return GetAttributeData("COL11221030389"); 
			}

			/// <summary>
			/// Gets Modified attribute data 
			/// </summary>
			public AttributeData GetModifiedAttributeData() { 
				return GetAttributeData("COL112210303811"); 
			}

			/// <summary>
			/// Gets id attribute data 
			/// </summary>
			public AttributeData GetidAttributeData() { 
				return GetAttributeData("COL11221030381"); 
			}

			/// <summary>
			/// Gets Contact attribute data 
			/// </summary>
			public AttributeData GetContactAttributeData() { 
				return GetAttributeData("COL11221030386"); 
			}

			/// <summary>
			/// Gets Dept attribute data 
			/// </summary>
			public AttributeData GetDeptAttributeData() { 
				return GetAttributeData("COL112210303814"); 
			}

			/// <summary>
			/// Gets Name attribute data 
			/// </summary>
			public AttributeData GetNameAttributeData() { 
				return GetAttributeData("COL11221030383"); 
			}

			/// <summary>
			/// Gets Comment attribute data 
			/// </summary>
			public AttributeData GetCommentAttributeData() { 
				return GetAttributeData("COL11221030388"); 
			}

			/// <summary>
			/// Gets Address attribute data 
			/// </summary>
			public AttributeData GetAddressAttributeData() { 
				return GetAttributeData("COL11221030384"); 
			}

			/// <summary>
			/// Gets Phone attribute data 
			/// </summary>
			public AttributeData GetPhoneAttributeData() { 
				return GetAttributeData("COL11221030385"); 
			}

			/// <summary>
			/// Gets ModifiedBy attribute data 
			/// </summary>
			public AttributeData GetModifiedByAttributeData() { 
				return GetAttributeData("COL112210303812"); 
			}

			/// <summary>
			/// Gets BuildingId attribute data 
			/// </summary>
			public AttributeData GetBuildingIdAttributeData() { 
				return GetAttributeData("COL11221030382"); 
			}

			/// <summary>
			/// Gets GoodsProvider attribute data 
			/// </summary>
			public AttributeData GetGoodsProviderAttributeData() { 
				return GetAttributeData("COL11221030387"); 
			}

			/// <summary>
			/// Gets DelFlag attribute data 
			/// </summary>
			public AttributeData GetDelFlagAttributeData() { 
				return GetAttributeData("COL112210303813"); 
			}


			/// <summary>
			/// Gets column CreatedBy with alias  
			/// </summary>
			public string ColCreatedBy { 
				get { return GetColumnName("COL112210303810"); } 
			}

			/// <summary>
			/// Gets column Created with alias  
			/// </summary>
			public string ColCreated { 
				get { return GetColumnName("COL11221030389"); } 
			}

			/// <summary>
			/// Gets column Modified with alias  
			/// </summary>
			public string ColModified { 
				get { return GetColumnName("COL112210303811"); } 
			}

			/// <summary>
			/// Gets column id with alias  
			/// </summary>
			public string Colid { 
				get { return GetColumnName("COL11221030381"); } 
			}

			/// <summary>
			/// Gets column Contact with alias  
			/// </summary>
			public string ColContact { 
				get { return GetColumnName("COL11221030386"); } 
			}

			/// <summary>
			/// Gets column Dept with alias  
			/// </summary>
			public string ColDept { 
				get { return GetColumnName("COL112210303814"); } 
			}

			/// <summary>
			/// Gets column Name with alias  
			/// </summary>
			public string ColName { 
				get { return GetColumnName("COL11221030383"); } 
			}

			/// <summary>
			/// Gets column Comment with alias  
			/// </summary>
			public string ColComment { 
				get { return GetColumnName("COL11221030388"); } 
			}

			/// <summary>
			/// Gets column Address with alias  
			/// </summary>
			public string ColAddress { 
				get { return GetColumnName("COL11221030384"); } 
			}

			/// <summary>
			/// Gets column Phone with alias  
			/// </summary>
			public string ColPhone { 
				get { return GetColumnName("COL11221030385"); } 
			}

			/// <summary>
			/// Gets column ModifiedBy with alias  
			/// </summary>
			public string ColModifiedBy { 
				get { return GetColumnName("COL112210303812"); } 
			}

			/// <summary>
			/// Gets column BuildingId with alias  
			/// </summary>
			public string ColBuildingId { 
				get { return GetColumnName("COL11221030382"); } 
			}

			/// <summary>
			/// Gets column GoodsProvider with alias  
			/// </summary>
			public string ColGoodsProvider { 
				get { return GetColumnName("COL11221030387"); } 
			}

			/// <summary>
			/// Gets column DelFlag with alias  
			/// </summary>
			public string ColDelFlag { 
				get { return GetColumnName("COL112210303813"); } 
			}


			/// <summary>
			/// Checks whether column CreatedBy is added in select statement 
			/// </summary>
			public bool IsSelectCreatedBy { 
				get { return IsSelect("COL112210303810"); } 
				set { SetSelect("COL112210303810", value); } 
			}

			/// <summary>
			/// Checks whether column Created is added in select statement 
			/// </summary>
			public bool IsSelectCreated { 
				get { return IsSelect("COL11221030389"); } 
				set { SetSelect("COL11221030389", value); } 
			}

			/// <summary>
			/// Checks whether column Modified is added in select statement 
			/// </summary>
			public bool IsSelectModified { 
				get { return IsSelect("COL112210303811"); } 
				set { SetSelect("COL112210303811", value); } 
			}

			/// <summary>
			/// Checks whether column id is added in select statement 
			/// </summary>
			public bool IsSelectid { 
				get { return IsSelect("COL11221030381"); } 
				set { SetSelect("COL11221030381", value); } 
			}

			/// <summary>
			/// Checks whether column Contact is added in select statement 
			/// </summary>
			public bool IsSelectContact { 
				get { return IsSelect("COL11221030386"); } 
				set { SetSelect("COL11221030386", value); } 
			}

			/// <summary>
			/// Checks whether column Dept is added in select statement 
			/// </summary>
			public bool IsSelectDept { 
				get { return IsSelect("COL112210303814"); } 
				set { SetSelect("COL112210303814", value); } 
			}

			/// <summary>
			/// Checks whether column Name is added in select statement 
			/// </summary>
			public bool IsSelectName { 
				get { return IsSelect("COL11221030383"); } 
				set { SetSelect("COL11221030383", value); } 
			}

			/// <summary>
			/// Checks whether column Comment is added in select statement 
			/// </summary>
			public bool IsSelectComment { 
				get { return IsSelect("COL11221030388"); } 
				set { SetSelect("COL11221030388", value); } 
			}

			/// <summary>
			/// Checks whether column Address is added in select statement 
			/// </summary>
			public bool IsSelectAddress { 
				get { return IsSelect("COL11221030384"); } 
				set { SetSelect("COL11221030384", value); } 
			}

			/// <summary>
			/// Checks whether column Phone is added in select statement 
			/// </summary>
			public bool IsSelectPhone { 
				get { return IsSelect("COL11221030385"); } 
				set { SetSelect("COL11221030385", value); } 
			}

			/// <summary>
			/// Checks whether column ModifiedBy is added in select statement 
			/// </summary>
			public bool IsSelectModifiedBy { 
				get { return IsSelect("COL112210303812"); } 
				set { SetSelect("COL112210303812", value); } 
			}

			/// <summary>
			/// Checks whether column BuildingId is added in select statement 
			/// </summary>
			public bool IsSelectBuildingId { 
				get { return IsSelect("COL11221030382"); } 
				set { SetSelect("COL11221030382", value); } 
			}

			/// <summary>
			/// Checks whether column GoodsProvider is added in select statement 
			/// </summary>
			public bool IsSelectGoodsProvider { 
				get { return IsSelect("COL11221030387"); } 
				set { SetSelect("COL11221030387", value); } 
			}

			/// <summary>
			/// Checks whether column DelFlag is added in select statement 
			/// </summary>
			public bool IsSelectDelFlag { 
				get { return IsSelect("COL112210303813"); } 
				set { SetSelect("COL112210303813", value); } 
			}



	}
}