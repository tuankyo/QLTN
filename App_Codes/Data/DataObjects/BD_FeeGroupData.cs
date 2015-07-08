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
	public class BD_FeeGroupData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ1186103266";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of BD_FeeGroup 
			/// </summary>
			public BD_FeeGroupData(string objectID): base(objectID) {}  

			public BD_FeeGroupData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field BuildingId 
			/// </summary>
			public string BuildingId { 
				get { return GetValue("COL11861032662"); } 
				set { SetValue("COL11861032662", value); } 
			}

			/// <summary>
			/// Gets field OtherFee02 
			/// </summary>
			public string OtherFee02 { 
				get { return GetValue("COL118610326613"); } 
				set { SetValue("COL118610326613", value); } 
			}

			/// <summary>
			/// Gets field Modified 
			/// </summary>
			public string Modified { 
				get { return GetValue("COL11861032668"); } 
				set { SetValue("COL11861032668", value); } 
			}

			/// <summary>
			/// Gets field Comment 
			/// </summary>
			public string Comment { 
				get { return GetValue("COL11861032665"); } 
				set { SetValue("COL11861032665", value); } 
			}

			/// <summary>
			/// Gets field Created 
			/// </summary>
			public string Created { 
				get { return GetValue("COL11861032666"); } 
				set { SetValue("COL11861032666", value); } 
			}

			/// <summary>
			/// Gets field FeeGroup 
			/// </summary>
			public string FeeGroup { 
				get { return GetValue("COL11861032663"); } 
				set { SetValue("COL11861032663", value); } 
			}

			/// <summary>
			/// Gets field Name 
			/// </summary>
			public string Name { 
				get { return GetValue("COL11861032664"); } 
				set { SetValue("COL11861032664", value); } 
			}

			/// <summary>
			/// Gets field id 
			/// </summary>
			public string id { 
				get { return GetValue("COL11861032661"); } 
				set { SetValue("COL11861032661", value); } 
			}

			/// <summary>
			/// Gets field DelFlag 
			/// </summary>
			public string DelFlag { 
				get { return GetValue("COL118610326610"); } 
				set { SetValue("COL118610326610", value); } 
			}

			/// <summary>
			/// Gets field ModifiedBy 
			/// </summary>
			public string ModifiedBy { 
				get { return GetValue("COL11861032669"); } 
				set { SetValue("COL11861032669", value); } 
			}

			/// <summary>
			/// Gets field VAT 
			/// </summary>
			public string VAT { 
				get { return GetValue("COL118610326611"); } 
				set { SetValue("COL118610326611", value); } 
			}

			/// <summary>
			/// Gets field OtherFee01 
			/// </summary>
			public string OtherFee01 { 
				get { return GetValue("COL118610326612"); } 
				set { SetValue("COL118610326612", value); } 
			}

			/// <summary>
			/// Gets field CreatedBy 
			/// </summary>
			public string CreatedBy { 
				get { return GetValue("COL11861032667"); } 
				set { SetValue("COL11861032667", value); } 
			}


			/// <summary>
			/// Gets BuildingId attribute data 
			/// </summary>
			public AttributeData GetBuildingIdAttributeData() { 
				return GetAttributeData("COL11861032662"); 
			}

			/// <summary>
			/// Gets OtherFee02 attribute data 
			/// </summary>
			public AttributeData GetOtherFee02AttributeData() { 
				return GetAttributeData("COL118610326613"); 
			}

			/// <summary>
			/// Gets Modified attribute data 
			/// </summary>
			public AttributeData GetModifiedAttributeData() { 
				return GetAttributeData("COL11861032668"); 
			}

			/// <summary>
			/// Gets Comment attribute data 
			/// </summary>
			public AttributeData GetCommentAttributeData() { 
				return GetAttributeData("COL11861032665"); 
			}

			/// <summary>
			/// Gets Created attribute data 
			/// </summary>
			public AttributeData GetCreatedAttributeData() { 
				return GetAttributeData("COL11861032666"); 
			}

			/// <summary>
			/// Gets FeeGroup attribute data 
			/// </summary>
			public AttributeData GetFeeGroupAttributeData() { 
				return GetAttributeData("COL11861032663"); 
			}

			/// <summary>
			/// Gets Name attribute data 
			/// </summary>
			public AttributeData GetNameAttributeData() { 
				return GetAttributeData("COL11861032664"); 
			}

			/// <summary>
			/// Gets id attribute data 
			/// </summary>
			public AttributeData GetidAttributeData() { 
				return GetAttributeData("COL11861032661"); 
			}

			/// <summary>
			/// Gets DelFlag attribute data 
			/// </summary>
			public AttributeData GetDelFlagAttributeData() { 
				return GetAttributeData("COL118610326610"); 
			}

			/// <summary>
			/// Gets ModifiedBy attribute data 
			/// </summary>
			public AttributeData GetModifiedByAttributeData() { 
				return GetAttributeData("COL11861032669"); 
			}

			/// <summary>
			/// Gets VAT attribute data 
			/// </summary>
			public AttributeData GetVATAttributeData() { 
				return GetAttributeData("COL118610326611"); 
			}

			/// <summary>
			/// Gets OtherFee01 attribute data 
			/// </summary>
			public AttributeData GetOtherFee01AttributeData() { 
				return GetAttributeData("COL118610326612"); 
			}

			/// <summary>
			/// Gets CreatedBy attribute data 
			/// </summary>
			public AttributeData GetCreatedByAttributeData() { 
				return GetAttributeData("COL11861032667"); 
			}


			/// <summary>
			/// Gets column BuildingId with alias  
			/// </summary>
			public string ColBuildingId { 
				get { return GetColumnName("COL11861032662"); } 
			}

			/// <summary>
			/// Gets column OtherFee02 with alias  
			/// </summary>
			public string ColOtherFee02 { 
				get { return GetColumnName("COL118610326613"); } 
			}

			/// <summary>
			/// Gets column Modified with alias  
			/// </summary>
			public string ColModified { 
				get { return GetColumnName("COL11861032668"); } 
			}

			/// <summary>
			/// Gets column Comment with alias  
			/// </summary>
			public string ColComment { 
				get { return GetColumnName("COL11861032665"); } 
			}

			/// <summary>
			/// Gets column Created with alias  
			/// </summary>
			public string ColCreated { 
				get { return GetColumnName("COL11861032666"); } 
			}

			/// <summary>
			/// Gets column FeeGroup with alias  
			/// </summary>
			public string ColFeeGroup { 
				get { return GetColumnName("COL11861032663"); } 
			}

			/// <summary>
			/// Gets column Name with alias  
			/// </summary>
			public string ColName { 
				get { return GetColumnName("COL11861032664"); } 
			}

			/// <summary>
			/// Gets column id with alias  
			/// </summary>
			public string Colid { 
				get { return GetColumnName("COL11861032661"); } 
			}

			/// <summary>
			/// Gets column DelFlag with alias  
			/// </summary>
			public string ColDelFlag { 
				get { return GetColumnName("COL118610326610"); } 
			}

			/// <summary>
			/// Gets column ModifiedBy with alias  
			/// </summary>
			public string ColModifiedBy { 
				get { return GetColumnName("COL11861032669"); } 
			}

			/// <summary>
			/// Gets column VAT with alias  
			/// </summary>
			public string ColVAT { 
				get { return GetColumnName("COL118610326611"); } 
			}

			/// <summary>
			/// Gets column OtherFee01 with alias  
			/// </summary>
			public string ColOtherFee01 { 
				get { return GetColumnName("COL118610326612"); } 
			}

			/// <summary>
			/// Gets column CreatedBy with alias  
			/// </summary>
			public string ColCreatedBy { 
				get { return GetColumnName("COL11861032667"); } 
			}


			/// <summary>
			/// Checks whether column BuildingId is added in select statement 
			/// </summary>
			public bool IsSelectBuildingId { 
				get { return IsSelect("COL11861032662"); } 
				set { SetSelect("COL11861032662", value); } 
			}

			/// <summary>
			/// Checks whether column OtherFee02 is added in select statement 
			/// </summary>
			public bool IsSelectOtherFee02 { 
				get { return IsSelect("COL118610326613"); } 
				set { SetSelect("COL118610326613", value); } 
			}

			/// <summary>
			/// Checks whether column Modified is added in select statement 
			/// </summary>
			public bool IsSelectModified { 
				get { return IsSelect("COL11861032668"); } 
				set { SetSelect("COL11861032668", value); } 
			}

			/// <summary>
			/// Checks whether column Comment is added in select statement 
			/// </summary>
			public bool IsSelectComment { 
				get { return IsSelect("COL11861032665"); } 
				set { SetSelect("COL11861032665", value); } 
			}

			/// <summary>
			/// Checks whether column Created is added in select statement 
			/// </summary>
			public bool IsSelectCreated { 
				get { return IsSelect("COL11861032666"); } 
				set { SetSelect("COL11861032666", value); } 
			}

			/// <summary>
			/// Checks whether column FeeGroup is added in select statement 
			/// </summary>
			public bool IsSelectFeeGroup { 
				get { return IsSelect("COL11861032663"); } 
				set { SetSelect("COL11861032663", value); } 
			}

			/// <summary>
			/// Checks whether column Name is added in select statement 
			/// </summary>
			public bool IsSelectName { 
				get { return IsSelect("COL11861032664"); } 
				set { SetSelect("COL11861032664", value); } 
			}

			/// <summary>
			/// Checks whether column id is added in select statement 
			/// </summary>
			public bool IsSelectid { 
				get { return IsSelect("COL11861032661"); } 
				set { SetSelect("COL11861032661", value); } 
			}

			/// <summary>
			/// Checks whether column DelFlag is added in select statement 
			/// </summary>
			public bool IsSelectDelFlag { 
				get { return IsSelect("COL118610326610"); } 
				set { SetSelect("COL118610326610", value); } 
			}

			/// <summary>
			/// Checks whether column ModifiedBy is added in select statement 
			/// </summary>
			public bool IsSelectModifiedBy { 
				get { return IsSelect("COL11861032669"); } 
				set { SetSelect("COL11861032669", value); } 
			}

			/// <summary>
			/// Checks whether column VAT is added in select statement 
			/// </summary>
			public bool IsSelectVAT { 
				get { return IsSelect("COL118610326611"); } 
				set { SetSelect("COL118610326611", value); } 
			}

			/// <summary>
			/// Checks whether column OtherFee01 is added in select statement 
			/// </summary>
			public bool IsSelectOtherFee01 { 
				get { return IsSelect("COL118610326612"); } 
				set { SetSelect("COL118610326612", value); } 
			}

			/// <summary>
			/// Checks whether column CreatedBy is added in select statement 
			/// </summary>
			public bool IsSelectCreatedBy { 
				get { return IsSelect("COL11861032667"); } 
				set { SetSelect("COL11861032667", value); } 
			}



	}
}