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
	public class BD_TarrifsElecWaterData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ2107870576";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of BD_TarrifsElecWater 
			/// </summary>
			public BD_TarrifsElecWaterData(string objectID): base(objectID) {}  

			public BD_TarrifsElecWaterData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field id 
			/// </summary>
			public string id { 
				get { return GetValue("COL21078705761"); } 
				set { SetValue("COL21078705761", value); } 
			}

			/// <summary>
			/// Gets field Comment 
			/// </summary>
			public string Comment { 
				get { return GetValue("COL210787057610"); } 
				set { SetValue("COL210787057610", value); } 
			}

			/// <summary>
			/// Gets field CreatedBy 
			/// </summary>
			public string CreatedBy { 
				get { return GetValue("COL210787057612"); } 
				set { SetValue("COL210787057612", value); } 
			}

			/// <summary>
			/// Gets field FeeGroup 
			/// </summary>
			public string FeeGroup { 
				get { return GetValue("COL21078705764"); } 
				set { SetValue("COL21078705764", value); } 
			}

			/// <summary>
			/// Gets field BuildingId 
			/// </summary>
			public string BuildingId { 
				get { return GetValue("COL21078705763"); } 
				set { SetValue("COL21078705763", value); } 
			}

			/// <summary>
			/// Gets field ModifiedBy 
			/// </summary>
			public string ModifiedBy { 
				get { return GetValue("COL210787057614"); } 
				set { SetValue("COL210787057614", value); } 
			}

			/// <summary>
			/// Gets field DelFlag 
			/// </summary>
			public string DelFlag { 
				get { return GetValue("COL210787057615"); } 
				set { SetValue("COL210787057615", value); } 
			}

			/// <summary>
			/// Gets field PriceVND 
			/// </summary>
			public string PriceVND { 
				get { return GetValue("COL21078705766"); } 
				set { SetValue("COL21078705766", value); } 
			}

			/// <summary>
			/// Gets field Created 
			/// </summary>
			public string Created { 
				get { return GetValue("COL210787057611"); } 
				set { SetValue("COL210787057611", value); } 
			}

			/// <summary>
			/// Gets field DateFrom 
			/// </summary>
			public string DateFrom { 
				get { return GetValue("COL21078705768"); } 
				set { SetValue("COL21078705768", value); } 
			}

			/// <summary>
			/// Gets field IndexFrom 
			/// </summary>
			public string IndexFrom { 
				get { return GetValue("COL21078705765"); } 
				set { SetValue("COL21078705765", value); } 
			}

			/// <summary>
			/// Gets field Modified 
			/// </summary>
			public string Modified { 
				get { return GetValue("COL210787057613"); } 
				set { SetValue("COL210787057613", value); } 
			}

			/// <summary>
			/// Gets field PriceUSD 
			/// </summary>
			public string PriceUSD { 
				get { return GetValue("COL21078705767"); } 
				set { SetValue("COL21078705767", value); } 
			}

			/// <summary>
			/// Gets field Name 
			/// </summary>
			public string Name { 
				get { return GetValue("COL21078705762"); } 
				set { SetValue("COL21078705762", value); } 
			}

			/// <summary>
			/// Gets field DateTo 
			/// </summary>
			public string DateTo { 
				get { return GetValue("COL21078705769"); } 
				set { SetValue("COL21078705769", value); } 
			}


			/// <summary>
			/// Gets id attribute data 
			/// </summary>
			public AttributeData GetidAttributeData() { 
				return GetAttributeData("COL21078705761"); 
			}

			/// <summary>
			/// Gets Comment attribute data 
			/// </summary>
			public AttributeData GetCommentAttributeData() { 
				return GetAttributeData("COL210787057610"); 
			}

			/// <summary>
			/// Gets CreatedBy attribute data 
			/// </summary>
			public AttributeData GetCreatedByAttributeData() { 
				return GetAttributeData("COL210787057612"); 
			}

			/// <summary>
			/// Gets FeeGroup attribute data 
			/// </summary>
			public AttributeData GetFeeGroupAttributeData() { 
				return GetAttributeData("COL21078705764"); 
			}

			/// <summary>
			/// Gets BuildingId attribute data 
			/// </summary>
			public AttributeData GetBuildingIdAttributeData() { 
				return GetAttributeData("COL21078705763"); 
			}

			/// <summary>
			/// Gets ModifiedBy attribute data 
			/// </summary>
			public AttributeData GetModifiedByAttributeData() { 
				return GetAttributeData("COL210787057614"); 
			}

			/// <summary>
			/// Gets DelFlag attribute data 
			/// </summary>
			public AttributeData GetDelFlagAttributeData() { 
				return GetAttributeData("COL210787057615"); 
			}

			/// <summary>
			/// Gets PriceVND attribute data 
			/// </summary>
			public AttributeData GetPriceVNDAttributeData() { 
				return GetAttributeData("COL21078705766"); 
			}

			/// <summary>
			/// Gets Created attribute data 
			/// </summary>
			public AttributeData GetCreatedAttributeData() { 
				return GetAttributeData("COL210787057611"); 
			}

			/// <summary>
			/// Gets DateFrom attribute data 
			/// </summary>
			public AttributeData GetDateFromAttributeData() { 
				return GetAttributeData("COL21078705768"); 
			}

			/// <summary>
			/// Gets IndexFrom attribute data 
			/// </summary>
			public AttributeData GetIndexFromAttributeData() { 
				return GetAttributeData("COL21078705765"); 
			}

			/// <summary>
			/// Gets Modified attribute data 
			/// </summary>
			public AttributeData GetModifiedAttributeData() { 
				return GetAttributeData("COL210787057613"); 
			}

			/// <summary>
			/// Gets PriceUSD attribute data 
			/// </summary>
			public AttributeData GetPriceUSDAttributeData() { 
				return GetAttributeData("COL21078705767"); 
			}

			/// <summary>
			/// Gets Name attribute data 
			/// </summary>
			public AttributeData GetNameAttributeData() { 
				return GetAttributeData("COL21078705762"); 
			}

			/// <summary>
			/// Gets DateTo attribute data 
			/// </summary>
			public AttributeData GetDateToAttributeData() { 
				return GetAttributeData("COL21078705769"); 
			}


			/// <summary>
			/// Gets column id with alias  
			/// </summary>
			public string Colid { 
				get { return GetColumnName("COL21078705761"); } 
			}

			/// <summary>
			/// Gets column Comment with alias  
			/// </summary>
			public string ColComment { 
				get { return GetColumnName("COL210787057610"); } 
			}

			/// <summary>
			/// Gets column CreatedBy with alias  
			/// </summary>
			public string ColCreatedBy { 
				get { return GetColumnName("COL210787057612"); } 
			}

			/// <summary>
			/// Gets column FeeGroup with alias  
			/// </summary>
			public string ColFeeGroup { 
				get { return GetColumnName("COL21078705764"); } 
			}

			/// <summary>
			/// Gets column BuildingId with alias  
			/// </summary>
			public string ColBuildingId { 
				get { return GetColumnName("COL21078705763"); } 
			}

			/// <summary>
			/// Gets column ModifiedBy with alias  
			/// </summary>
			public string ColModifiedBy { 
				get { return GetColumnName("COL210787057614"); } 
			}

			/// <summary>
			/// Gets column DelFlag with alias  
			/// </summary>
			public string ColDelFlag { 
				get { return GetColumnName("COL210787057615"); } 
			}

			/// <summary>
			/// Gets column PriceVND with alias  
			/// </summary>
			public string ColPriceVND { 
				get { return GetColumnName("COL21078705766"); } 
			}

			/// <summary>
			/// Gets column Created with alias  
			/// </summary>
			public string ColCreated { 
				get { return GetColumnName("COL210787057611"); } 
			}

			/// <summary>
			/// Gets column DateFrom with alias  
			/// </summary>
			public string ColDateFrom { 
				get { return GetColumnName("COL21078705768"); } 
			}

			/// <summary>
			/// Gets column IndexFrom with alias  
			/// </summary>
			public string ColIndexFrom { 
				get { return GetColumnName("COL21078705765"); } 
			}

			/// <summary>
			/// Gets column Modified with alias  
			/// </summary>
			public string ColModified { 
				get { return GetColumnName("COL210787057613"); } 
			}

			/// <summary>
			/// Gets column PriceUSD with alias  
			/// </summary>
			public string ColPriceUSD { 
				get { return GetColumnName("COL21078705767"); } 
			}

			/// <summary>
			/// Gets column Name with alias  
			/// </summary>
			public string ColName { 
				get { return GetColumnName("COL21078705762"); } 
			}

			/// <summary>
			/// Gets column DateTo with alias  
			/// </summary>
			public string ColDateTo { 
				get { return GetColumnName("COL21078705769"); } 
			}


			/// <summary>
			/// Checks whether column id is added in select statement 
			/// </summary>
			public bool IsSelectid { 
				get { return IsSelect("COL21078705761"); } 
				set { SetSelect("COL21078705761", value); } 
			}

			/// <summary>
			/// Checks whether column Comment is added in select statement 
			/// </summary>
			public bool IsSelectComment { 
				get { return IsSelect("COL210787057610"); } 
				set { SetSelect("COL210787057610", value); } 
			}

			/// <summary>
			/// Checks whether column CreatedBy is added in select statement 
			/// </summary>
			public bool IsSelectCreatedBy { 
				get { return IsSelect("COL210787057612"); } 
				set { SetSelect("COL210787057612", value); } 
			}

			/// <summary>
			/// Checks whether column FeeGroup is added in select statement 
			/// </summary>
			public bool IsSelectFeeGroup { 
				get { return IsSelect("COL21078705764"); } 
				set { SetSelect("COL21078705764", value); } 
			}

			/// <summary>
			/// Checks whether column BuildingId is added in select statement 
			/// </summary>
			public bool IsSelectBuildingId { 
				get { return IsSelect("COL21078705763"); } 
				set { SetSelect("COL21078705763", value); } 
			}

			/// <summary>
			/// Checks whether column ModifiedBy is added in select statement 
			/// </summary>
			public bool IsSelectModifiedBy { 
				get { return IsSelect("COL210787057614"); } 
				set { SetSelect("COL210787057614", value); } 
			}

			/// <summary>
			/// Checks whether column DelFlag is added in select statement 
			/// </summary>
			public bool IsSelectDelFlag { 
				get { return IsSelect("COL210787057615"); } 
				set { SetSelect("COL210787057615", value); } 
			}

			/// <summary>
			/// Checks whether column PriceVND is added in select statement 
			/// </summary>
			public bool IsSelectPriceVND { 
				get { return IsSelect("COL21078705766"); } 
				set { SetSelect("COL21078705766", value); } 
			}

			/// <summary>
			/// Checks whether column Created is added in select statement 
			/// </summary>
			public bool IsSelectCreated { 
				get { return IsSelect("COL210787057611"); } 
				set { SetSelect("COL210787057611", value); } 
			}

			/// <summary>
			/// Checks whether column DateFrom is added in select statement 
			/// </summary>
			public bool IsSelectDateFrom { 
				get { return IsSelect("COL21078705768"); } 
				set { SetSelect("COL21078705768", value); } 
			}

			/// <summary>
			/// Checks whether column IndexFrom is added in select statement 
			/// </summary>
			public bool IsSelectIndexFrom { 
				get { return IsSelect("COL21078705765"); } 
				set { SetSelect("COL21078705765", value); } 
			}

			/// <summary>
			/// Checks whether column Modified is added in select statement 
			/// </summary>
			public bool IsSelectModified { 
				get { return IsSelect("COL210787057613"); } 
				set { SetSelect("COL210787057613", value); } 
			}

			/// <summary>
			/// Checks whether column PriceUSD is added in select statement 
			/// </summary>
			public bool IsSelectPriceUSD { 
				get { return IsSelect("COL21078705767"); } 
				set { SetSelect("COL21078705767", value); } 
			}

			/// <summary>
			/// Checks whether column Name is added in select statement 
			/// </summary>
			public bool IsSelectName { 
				get { return IsSelect("COL21078705762"); } 
				set { SetSelect("COL21078705762", value); } 
			}

			/// <summary>
			/// Checks whether column DateTo is added in select statement 
			/// </summary>
			public bool IsSelectDateTo { 
				get { return IsSelect("COL21078705769"); } 
				set { SetSelect("COL21078705769", value); } 
			}



	}
}