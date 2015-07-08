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
	public class BD_ConstructionData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ616389265";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of BD_Construction 
			/// </summary>
			public BD_ConstructionData(string objectID): base(objectID) {}  

			public BD_ConstructionData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field Regional 
			/// </summary>
			public string Regional { 
				get { return GetValue("COL6163892653"); } 
				set { SetValue("COL6163892653", value); } 
			}

			/// <summary>
			/// Gets field CreatedBy 
			/// </summary>
			public string CreatedBy { 
				get { return GetValue("COL61638926510"); } 
				set { SetValue("COL61638926510", value); } 
			}

			/// <summary>
			/// Gets field ModifiedBy 
			/// </summary>
			public string ModifiedBy { 
				get { return GetValue("COL61638926512"); } 
				set { SetValue("COL61638926512", value); } 
			}

			/// <summary>
			/// Gets field Modified 
			/// </summary>
			public string Modified { 
				get { return GetValue("COL61638926511"); } 
				set { SetValue("COL61638926511", value); } 
			}

			/// <summary>
			/// Gets field Comment 
			/// </summary>
			public string Comment { 
				get { return GetValue("COL6163892658"); } 
				set { SetValue("COL6163892658", value); } 
			}

			/// <summary>
			/// Gets field Created 
			/// </summary>
			public string Created { 
				get { return GetValue("COL6163892659"); } 
				set { SetValue("COL6163892659", value); } 
			}

			/// <summary>
			/// Gets field DelFlag 
			/// </summary>
			public string DelFlag { 
				get { return GetValue("COL61638926513"); } 
				set { SetValue("COL61638926513", value); } 
			}

			/// <summary>
			/// Gets field id 
			/// </summary>
			public string id { 
				get { return GetValue("COL6163892651"); } 
				set { SetValue("COL6163892651", value); } 
			}

			/// <summary>
			/// Gets field ConstructContent 
			/// </summary>
			public string ConstructContent { 
				get { return GetValue("COL6163892656"); } 
				set { SetValue("COL6163892656", value); } 
			}

			/// <summary>
			/// Gets field ConstructCompany 
			/// </summary>
			public string ConstructCompany { 
				get { return GetValue("COL6163892657"); } 
				set { SetValue("COL6163892657", value); } 
			}

			/// <summary>
			/// Gets field ConstructDate 
			/// </summary>
			public string ConstructDate { 
				get { return GetValue("COL6163892654"); } 
				set { SetValue("COL6163892654", value); } 
			}

			/// <summary>
			/// Gets field Duration 
			/// </summary>
			public string Duration { 
				get { return GetValue("COL6163892655"); } 
				set { SetValue("COL6163892655", value); } 
			}

			/// <summary>
			/// Gets field BuildingId 
			/// </summary>
			public string BuildingId { 
				get { return GetValue("COL6163892652"); } 
				set { SetValue("COL6163892652", value); } 
			}


			/// <summary>
			/// Gets Regional attribute data 
			/// </summary>
			public AttributeData GetRegionalAttributeData() { 
				return GetAttributeData("COL6163892653"); 
			}

			/// <summary>
			/// Gets CreatedBy attribute data 
			/// </summary>
			public AttributeData GetCreatedByAttributeData() { 
				return GetAttributeData("COL61638926510"); 
			}

			/// <summary>
			/// Gets ModifiedBy attribute data 
			/// </summary>
			public AttributeData GetModifiedByAttributeData() { 
				return GetAttributeData("COL61638926512"); 
			}

			/// <summary>
			/// Gets Modified attribute data 
			/// </summary>
			public AttributeData GetModifiedAttributeData() { 
				return GetAttributeData("COL61638926511"); 
			}

			/// <summary>
			/// Gets Comment attribute data 
			/// </summary>
			public AttributeData GetCommentAttributeData() { 
				return GetAttributeData("COL6163892658"); 
			}

			/// <summary>
			/// Gets Created attribute data 
			/// </summary>
			public AttributeData GetCreatedAttributeData() { 
				return GetAttributeData("COL6163892659"); 
			}

			/// <summary>
			/// Gets DelFlag attribute data 
			/// </summary>
			public AttributeData GetDelFlagAttributeData() { 
				return GetAttributeData("COL61638926513"); 
			}

			/// <summary>
			/// Gets id attribute data 
			/// </summary>
			public AttributeData GetidAttributeData() { 
				return GetAttributeData("COL6163892651"); 
			}

			/// <summary>
			/// Gets ConstructContent attribute data 
			/// </summary>
			public AttributeData GetConstructContentAttributeData() { 
				return GetAttributeData("COL6163892656"); 
			}

			/// <summary>
			/// Gets ConstructCompany attribute data 
			/// </summary>
			public AttributeData GetConstructCompanyAttributeData() { 
				return GetAttributeData("COL6163892657"); 
			}

			/// <summary>
			/// Gets ConstructDate attribute data 
			/// </summary>
			public AttributeData GetConstructDateAttributeData() { 
				return GetAttributeData("COL6163892654"); 
			}

			/// <summary>
			/// Gets Duration attribute data 
			/// </summary>
			public AttributeData GetDurationAttributeData() { 
				return GetAttributeData("COL6163892655"); 
			}

			/// <summary>
			/// Gets BuildingId attribute data 
			/// </summary>
			public AttributeData GetBuildingIdAttributeData() { 
				return GetAttributeData("COL6163892652"); 
			}


			/// <summary>
			/// Gets column Regional with alias  
			/// </summary>
			public string ColRegional { 
				get { return GetColumnName("COL6163892653"); } 
			}

			/// <summary>
			/// Gets column CreatedBy with alias  
			/// </summary>
			public string ColCreatedBy { 
				get { return GetColumnName("COL61638926510"); } 
			}

			/// <summary>
			/// Gets column ModifiedBy with alias  
			/// </summary>
			public string ColModifiedBy { 
				get { return GetColumnName("COL61638926512"); } 
			}

			/// <summary>
			/// Gets column Modified with alias  
			/// </summary>
			public string ColModified { 
				get { return GetColumnName("COL61638926511"); } 
			}

			/// <summary>
			/// Gets column Comment with alias  
			/// </summary>
			public string ColComment { 
				get { return GetColumnName("COL6163892658"); } 
			}

			/// <summary>
			/// Gets column Created with alias  
			/// </summary>
			public string ColCreated { 
				get { return GetColumnName("COL6163892659"); } 
			}

			/// <summary>
			/// Gets column DelFlag with alias  
			/// </summary>
			public string ColDelFlag { 
				get { return GetColumnName("COL61638926513"); } 
			}

			/// <summary>
			/// Gets column id with alias  
			/// </summary>
			public string Colid { 
				get { return GetColumnName("COL6163892651"); } 
			}

			/// <summary>
			/// Gets column ConstructContent with alias  
			/// </summary>
			public string ColConstructContent { 
				get { return GetColumnName("COL6163892656"); } 
			}

			/// <summary>
			/// Gets column ConstructCompany with alias  
			/// </summary>
			public string ColConstructCompany { 
				get { return GetColumnName("COL6163892657"); } 
			}

			/// <summary>
			/// Gets column ConstructDate with alias  
			/// </summary>
			public string ColConstructDate { 
				get { return GetColumnName("COL6163892654"); } 
			}

			/// <summary>
			/// Gets column Duration with alias  
			/// </summary>
			public string ColDuration { 
				get { return GetColumnName("COL6163892655"); } 
			}

			/// <summary>
			/// Gets column BuildingId with alias  
			/// </summary>
			public string ColBuildingId { 
				get { return GetColumnName("COL6163892652"); } 
			}


			/// <summary>
			/// Checks whether column Regional is added in select statement 
			/// </summary>
			public bool IsSelectRegional { 
				get { return IsSelect("COL6163892653"); } 
				set { SetSelect("COL6163892653", value); } 
			}

			/// <summary>
			/// Checks whether column CreatedBy is added in select statement 
			/// </summary>
			public bool IsSelectCreatedBy { 
				get { return IsSelect("COL61638926510"); } 
				set { SetSelect("COL61638926510", value); } 
			}

			/// <summary>
			/// Checks whether column ModifiedBy is added in select statement 
			/// </summary>
			public bool IsSelectModifiedBy { 
				get { return IsSelect("COL61638926512"); } 
				set { SetSelect("COL61638926512", value); } 
			}

			/// <summary>
			/// Checks whether column Modified is added in select statement 
			/// </summary>
			public bool IsSelectModified { 
				get { return IsSelect("COL61638926511"); } 
				set { SetSelect("COL61638926511", value); } 
			}

			/// <summary>
			/// Checks whether column Comment is added in select statement 
			/// </summary>
			public bool IsSelectComment { 
				get { return IsSelect("COL6163892658"); } 
				set { SetSelect("COL6163892658", value); } 
			}

			/// <summary>
			/// Checks whether column Created is added in select statement 
			/// </summary>
			public bool IsSelectCreated { 
				get { return IsSelect("COL6163892659"); } 
				set { SetSelect("COL6163892659", value); } 
			}

			/// <summary>
			/// Checks whether column DelFlag is added in select statement 
			/// </summary>
			public bool IsSelectDelFlag { 
				get { return IsSelect("COL61638926513"); } 
				set { SetSelect("COL61638926513", value); } 
			}

			/// <summary>
			/// Checks whether column id is added in select statement 
			/// </summary>
			public bool IsSelectid { 
				get { return IsSelect("COL6163892651"); } 
				set { SetSelect("COL6163892651", value); } 
			}

			/// <summary>
			/// Checks whether column ConstructContent is added in select statement 
			/// </summary>
			public bool IsSelectConstructContent { 
				get { return IsSelect("COL6163892656"); } 
				set { SetSelect("COL6163892656", value); } 
			}

			/// <summary>
			/// Checks whether column ConstructCompany is added in select statement 
			/// </summary>
			public bool IsSelectConstructCompany { 
				get { return IsSelect("COL6163892657"); } 
				set { SetSelect("COL6163892657", value); } 
			}

			/// <summary>
			/// Checks whether column ConstructDate is added in select statement 
			/// </summary>
			public bool IsSelectConstructDate { 
				get { return IsSelect("COL6163892654"); } 
				set { SetSelect("COL6163892654", value); } 
			}

			/// <summary>
			/// Checks whether column Duration is added in select statement 
			/// </summary>
			public bool IsSelectDuration { 
				get { return IsSelect("COL6163892655"); } 
				set { SetSelect("COL6163892655", value); } 
			}

			/// <summary>
			/// Checks whether column BuildingId is added in select statement 
			/// </summary>
			public bool IsSelectBuildingId { 
				get { return IsSelect("COL6163892652"); } 
				set { SetSelect("COL6163892652", value); } 
			}



	}
}