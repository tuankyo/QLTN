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
	public class BD_WorkingPlaceData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ514100872";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of BD_WorkingPlace 
			/// </summary>
			public BD_WorkingPlaceData(string objectID): base(objectID) {}  

			public BD_WorkingPlaceData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field ModifiedBy 
			/// </summary>
			public string ModifiedBy { 
				get { return GetValue("COL5141008729"); } 
				set { SetValue("COL5141008729", value); } 
			}

			/// <summary>
			/// Gets field Modified 
			/// </summary>
			public string Modified { 
				get { return GetValue("COL5141008728"); } 
				set { SetValue("COL5141008728", value); } 
			}

			/// <summary>
			/// Gets field DelFlag 
			/// </summary>
			public string DelFlag { 
				get { return GetValue("COL51410087210"); } 
				set { SetValue("COL51410087210", value); } 
			}

			/// <summary>
			/// Gets field Comment 
			/// </summary>
			public string Comment { 
				get { return GetValue("COL5141008725"); } 
				set { SetValue("COL5141008725", value); } 
			}

			/// <summary>
			/// Gets field Name 
			/// </summary>
			public string Name { 
				get { return GetValue("COL5141008724"); } 
				set { SetValue("COL5141008724", value); } 
			}

			/// <summary>
			/// Gets field CreatedBy 
			/// </summary>
			public string CreatedBy { 
				get { return GetValue("COL5141008727"); } 
				set { SetValue("COL5141008727", value); } 
			}

			/// <summary>
			/// Gets field Created 
			/// </summary>
			public string Created { 
				get { return GetValue("COL5141008726"); } 
				set { SetValue("COL5141008726", value); } 
			}

			/// <summary>
			/// Gets field id 
			/// </summary>
			public string id { 
				get { return GetValue("COL5141008721"); } 
				set { SetValue("COL5141008721", value); } 
			}

			/// <summary>
			/// Gets field BuildingId 
			/// </summary>
			public string BuildingId { 
				get { return GetValue("COL5141008723"); } 
				set { SetValue("COL5141008723", value); } 
			}

			/// <summary>
			/// Gets field WorkingPlaceId 
			/// </summary>
			public string WorkingPlaceId { 
				get { return GetValue("COL5141008722"); } 
				set { SetValue("COL5141008722", value); } 
			}

			/// <summary>
			/// Gets field JobTypeId 
			/// </summary>
			public string JobTypeId { 
				get { return GetValue("COL51410087211"); } 
				set { SetValue("COL51410087211", value); } 
			}


			/// <summary>
			/// Gets ModifiedBy attribute data 
			/// </summary>
			public AttributeData GetModifiedByAttributeData() { 
				return GetAttributeData("COL5141008729"); 
			}

			/// <summary>
			/// Gets Modified attribute data 
			/// </summary>
			public AttributeData GetModifiedAttributeData() { 
				return GetAttributeData("COL5141008728"); 
			}

			/// <summary>
			/// Gets DelFlag attribute data 
			/// </summary>
			public AttributeData GetDelFlagAttributeData() { 
				return GetAttributeData("COL51410087210"); 
			}

			/// <summary>
			/// Gets Comment attribute data 
			/// </summary>
			public AttributeData GetCommentAttributeData() { 
				return GetAttributeData("COL5141008725"); 
			}

			/// <summary>
			/// Gets Name attribute data 
			/// </summary>
			public AttributeData GetNameAttributeData() { 
				return GetAttributeData("COL5141008724"); 
			}

			/// <summary>
			/// Gets CreatedBy attribute data 
			/// </summary>
			public AttributeData GetCreatedByAttributeData() { 
				return GetAttributeData("COL5141008727"); 
			}

			/// <summary>
			/// Gets Created attribute data 
			/// </summary>
			public AttributeData GetCreatedAttributeData() { 
				return GetAttributeData("COL5141008726"); 
			}

			/// <summary>
			/// Gets id attribute data 
			/// </summary>
			public AttributeData GetidAttributeData() { 
				return GetAttributeData("COL5141008721"); 
			}

			/// <summary>
			/// Gets BuildingId attribute data 
			/// </summary>
			public AttributeData GetBuildingIdAttributeData() { 
				return GetAttributeData("COL5141008723"); 
			}

			/// <summary>
			/// Gets WorkingPlaceId attribute data 
			/// </summary>
			public AttributeData GetWorkingPlaceIdAttributeData() { 
				return GetAttributeData("COL5141008722"); 
			}

			/// <summary>
			/// Gets JobTypeId attribute data 
			/// </summary>
			public AttributeData GetJobTypeIdAttributeData() { 
				return GetAttributeData("COL51410087211"); 
			}


			/// <summary>
			/// Gets column ModifiedBy with alias  
			/// </summary>
			public string ColModifiedBy { 
				get { return GetColumnName("COL5141008729"); } 
			}

			/// <summary>
			/// Gets column Modified with alias  
			/// </summary>
			public string ColModified { 
				get { return GetColumnName("COL5141008728"); } 
			}

			/// <summary>
			/// Gets column DelFlag with alias  
			/// </summary>
			public string ColDelFlag { 
				get { return GetColumnName("COL51410087210"); } 
			}

			/// <summary>
			/// Gets column Comment with alias  
			/// </summary>
			public string ColComment { 
				get { return GetColumnName("COL5141008725"); } 
			}

			/// <summary>
			/// Gets column Name with alias  
			/// </summary>
			public string ColName { 
				get { return GetColumnName("COL5141008724"); } 
			}

			/// <summary>
			/// Gets column CreatedBy with alias  
			/// </summary>
			public string ColCreatedBy { 
				get { return GetColumnName("COL5141008727"); } 
			}

			/// <summary>
			/// Gets column Created with alias  
			/// </summary>
			public string ColCreated { 
				get { return GetColumnName("COL5141008726"); } 
			}

			/// <summary>
			/// Gets column id with alias  
			/// </summary>
			public string Colid { 
				get { return GetColumnName("COL5141008721"); } 
			}

			/// <summary>
			/// Gets column BuildingId with alias  
			/// </summary>
			public string ColBuildingId { 
				get { return GetColumnName("COL5141008723"); } 
			}

			/// <summary>
			/// Gets column WorkingPlaceId with alias  
			/// </summary>
			public string ColWorkingPlaceId { 
				get { return GetColumnName("COL5141008722"); } 
			}

			/// <summary>
			/// Gets column JobTypeId with alias  
			/// </summary>
			public string ColJobTypeId { 
				get { return GetColumnName("COL51410087211"); } 
			}


			/// <summary>
			/// Checks whether column ModifiedBy is added in select statement 
			/// </summary>
			public bool IsSelectModifiedBy { 
				get { return IsSelect("COL5141008729"); } 
				set { SetSelect("COL5141008729", value); } 
			}

			/// <summary>
			/// Checks whether column Modified is added in select statement 
			/// </summary>
			public bool IsSelectModified { 
				get { return IsSelect("COL5141008728"); } 
				set { SetSelect("COL5141008728", value); } 
			}

			/// <summary>
			/// Checks whether column DelFlag is added in select statement 
			/// </summary>
			public bool IsSelectDelFlag { 
				get { return IsSelect("COL51410087210"); } 
				set { SetSelect("COL51410087210", value); } 
			}

			/// <summary>
			/// Checks whether column Comment is added in select statement 
			/// </summary>
			public bool IsSelectComment { 
				get { return IsSelect("COL5141008725"); } 
				set { SetSelect("COL5141008725", value); } 
			}

			/// <summary>
			/// Checks whether column Name is added in select statement 
			/// </summary>
			public bool IsSelectName { 
				get { return IsSelect("COL5141008724"); } 
				set { SetSelect("COL5141008724", value); } 
			}

			/// <summary>
			/// Checks whether column CreatedBy is added in select statement 
			/// </summary>
			public bool IsSelectCreatedBy { 
				get { return IsSelect("COL5141008727"); } 
				set { SetSelect("COL5141008727", value); } 
			}

			/// <summary>
			/// Checks whether column Created is added in select statement 
			/// </summary>
			public bool IsSelectCreated { 
				get { return IsSelect("COL5141008726"); } 
				set { SetSelect("COL5141008726", value); } 
			}

			/// <summary>
			/// Checks whether column id is added in select statement 
			/// </summary>
			public bool IsSelectid { 
				get { return IsSelect("COL5141008721"); } 
				set { SetSelect("COL5141008721", value); } 
			}

			/// <summary>
			/// Checks whether column BuildingId is added in select statement 
			/// </summary>
			public bool IsSelectBuildingId { 
				get { return IsSelect("COL5141008723"); } 
				set { SetSelect("COL5141008723", value); } 
			}

			/// <summary>
			/// Checks whether column WorkingPlaceId is added in select statement 
			/// </summary>
			public bool IsSelectWorkingPlaceId { 
				get { return IsSelect("COL5141008722"); } 
				set { SetSelect("COL5141008722", value); } 
			}

			/// <summary>
			/// Checks whether column JobTypeId is added in select statement 
			/// </summary>
			public bool IsSelectJobTypeId { 
				get { return IsSelect("COL51410087211"); } 
				set { SetSelect("COL51410087211", value); } 
			}



	}
}