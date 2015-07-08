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
	public class BD_DocSubjectData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ1963870063";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of BD_DocSubject 
			/// </summary>
			public BD_DocSubjectData(string objectID): base(objectID) {}  

			public BD_DocSubjectData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field ParentId 
			/// </summary>
			public string ParentId { 
				get { return GetValue("COL19638700636"); } 
				set { SetValue("COL19638700636", value); } 
			}

			/// <summary>
			/// Gets field id 
			/// </summary>
			public string id { 
				get { return GetValue("COL19638700631"); } 
				set { SetValue("COL19638700631", value); } 
			}

			/// <summary>
			/// Gets field Modified 
			/// </summary>
			public string Modified { 
				get { return GetValue("COL19638700639"); } 
				set { SetValue("COL19638700639", value); } 
			}

			/// <summary>
			/// Gets field DocSubject 
			/// </summary>
			public string DocSubject { 
				get { return GetValue("COL19638700634"); } 
				set { SetValue("COL19638700634", value); } 
			}

			/// <summary>
			/// Gets field Created 
			/// </summary>
			public string Created { 
				get { return GetValue("COL19638700637"); } 
				set { SetValue("COL19638700637", value); } 
			}

			/// <summary>
			/// Gets field BuildingId 
			/// </summary>
			public string BuildingId { 
				get { return GetValue("COL19638700632"); } 
				set { SetValue("COL19638700632", value); } 
			}

			/// <summary>
			/// Gets field DelFlag 
			/// </summary>
			public string DelFlag { 
				get { return GetValue("COL196387006311"); } 
				set { SetValue("COL196387006311", value); } 
			}

			/// <summary>
			/// Gets field Comment 
			/// </summary>
			public string Comment { 
				get { return GetValue("COL19638700635"); } 
				set { SetValue("COL19638700635", value); } 
			}

			/// <summary>
			/// Gets field ModifiedBy 
			/// </summary>
			public string ModifiedBy { 
				get { return GetValue("COL196387006310"); } 
				set { SetValue("COL196387006310", value); } 
			}

			/// <summary>
			/// Gets field CreatedBy 
			/// </summary>
			public string CreatedBy { 
				get { return GetValue("COL19638700638"); } 
				set { SetValue("COL19638700638", value); } 
			}

			/// <summary>
			/// Gets field DocType 
			/// </summary>
			public string DocType { 
				get { return GetValue("COL19638700633"); } 
				set { SetValue("COL19638700633", value); } 
			}


			/// <summary>
			/// Gets ParentId attribute data 
			/// </summary>
			public AttributeData GetParentIdAttributeData() { 
				return GetAttributeData("COL19638700636"); 
			}

			/// <summary>
			/// Gets id attribute data 
			/// </summary>
			public AttributeData GetidAttributeData() { 
				return GetAttributeData("COL19638700631"); 
			}

			/// <summary>
			/// Gets Modified attribute data 
			/// </summary>
			public AttributeData GetModifiedAttributeData() { 
				return GetAttributeData("COL19638700639"); 
			}

			/// <summary>
			/// Gets DocSubject attribute data 
			/// </summary>
			public AttributeData GetDocSubjectAttributeData() { 
				return GetAttributeData("COL19638700634"); 
			}

			/// <summary>
			/// Gets Created attribute data 
			/// </summary>
			public AttributeData GetCreatedAttributeData() { 
				return GetAttributeData("COL19638700637"); 
			}

			/// <summary>
			/// Gets BuildingId attribute data 
			/// </summary>
			public AttributeData GetBuildingIdAttributeData() { 
				return GetAttributeData("COL19638700632"); 
			}

			/// <summary>
			/// Gets DelFlag attribute data 
			/// </summary>
			public AttributeData GetDelFlagAttributeData() { 
				return GetAttributeData("COL196387006311"); 
			}

			/// <summary>
			/// Gets Comment attribute data 
			/// </summary>
			public AttributeData GetCommentAttributeData() { 
				return GetAttributeData("COL19638700635"); 
			}

			/// <summary>
			/// Gets ModifiedBy attribute data 
			/// </summary>
			public AttributeData GetModifiedByAttributeData() { 
				return GetAttributeData("COL196387006310"); 
			}

			/// <summary>
			/// Gets CreatedBy attribute data 
			/// </summary>
			public AttributeData GetCreatedByAttributeData() { 
				return GetAttributeData("COL19638700638"); 
			}

			/// <summary>
			/// Gets DocType attribute data 
			/// </summary>
			public AttributeData GetDocTypeAttributeData() { 
				return GetAttributeData("COL19638700633"); 
			}


			/// <summary>
			/// Gets column ParentId with alias  
			/// </summary>
			public string ColParentId { 
				get { return GetColumnName("COL19638700636"); } 
			}

			/// <summary>
			/// Gets column id with alias  
			/// </summary>
			public string Colid { 
				get { return GetColumnName("COL19638700631"); } 
			}

			/// <summary>
			/// Gets column Modified with alias  
			/// </summary>
			public string ColModified { 
				get { return GetColumnName("COL19638700639"); } 
			}

			/// <summary>
			/// Gets column DocSubject with alias  
			/// </summary>
			public string ColDocSubject { 
				get { return GetColumnName("COL19638700634"); } 
			}

			/// <summary>
			/// Gets column Created with alias  
			/// </summary>
			public string ColCreated { 
				get { return GetColumnName("COL19638700637"); } 
			}

			/// <summary>
			/// Gets column BuildingId with alias  
			/// </summary>
			public string ColBuildingId { 
				get { return GetColumnName("COL19638700632"); } 
			}

			/// <summary>
			/// Gets column DelFlag with alias  
			/// </summary>
			public string ColDelFlag { 
				get { return GetColumnName("COL196387006311"); } 
			}

			/// <summary>
			/// Gets column Comment with alias  
			/// </summary>
			public string ColComment { 
				get { return GetColumnName("COL19638700635"); } 
			}

			/// <summary>
			/// Gets column ModifiedBy with alias  
			/// </summary>
			public string ColModifiedBy { 
				get { return GetColumnName("COL196387006310"); } 
			}

			/// <summary>
			/// Gets column CreatedBy with alias  
			/// </summary>
			public string ColCreatedBy { 
				get { return GetColumnName("COL19638700638"); } 
			}

			/// <summary>
			/// Gets column DocType with alias  
			/// </summary>
			public string ColDocType { 
				get { return GetColumnName("COL19638700633"); } 
			}


			/// <summary>
			/// Checks whether column ParentId is added in select statement 
			/// </summary>
			public bool IsSelectParentId { 
				get { return IsSelect("COL19638700636"); } 
				set { SetSelect("COL19638700636", value); } 
			}

			/// <summary>
			/// Checks whether column id is added in select statement 
			/// </summary>
			public bool IsSelectid { 
				get { return IsSelect("COL19638700631"); } 
				set { SetSelect("COL19638700631", value); } 
			}

			/// <summary>
			/// Checks whether column Modified is added in select statement 
			/// </summary>
			public bool IsSelectModified { 
				get { return IsSelect("COL19638700639"); } 
				set { SetSelect("COL19638700639", value); } 
			}

			/// <summary>
			/// Checks whether column DocSubject is added in select statement 
			/// </summary>
			public bool IsSelectDocSubject { 
				get { return IsSelect("COL19638700634"); } 
				set { SetSelect("COL19638700634", value); } 
			}

			/// <summary>
			/// Checks whether column Created is added in select statement 
			/// </summary>
			public bool IsSelectCreated { 
				get { return IsSelect("COL19638700637"); } 
				set { SetSelect("COL19638700637", value); } 
			}

			/// <summary>
			/// Checks whether column BuildingId is added in select statement 
			/// </summary>
			public bool IsSelectBuildingId { 
				get { return IsSelect("COL19638700632"); } 
				set { SetSelect("COL19638700632", value); } 
			}

			/// <summary>
			/// Checks whether column DelFlag is added in select statement 
			/// </summary>
			public bool IsSelectDelFlag { 
				get { return IsSelect("COL196387006311"); } 
				set { SetSelect("COL196387006311", value); } 
			}

			/// <summary>
			/// Checks whether column Comment is added in select statement 
			/// </summary>
			public bool IsSelectComment { 
				get { return IsSelect("COL19638700635"); } 
				set { SetSelect("COL19638700635", value); } 
			}

			/// <summary>
			/// Checks whether column ModifiedBy is added in select statement 
			/// </summary>
			public bool IsSelectModifiedBy { 
				get { return IsSelect("COL196387006310"); } 
				set { SetSelect("COL196387006310", value); } 
			}

			/// <summary>
			/// Checks whether column CreatedBy is added in select statement 
			/// </summary>
			public bool IsSelectCreatedBy { 
				get { return IsSelect("COL19638700638"); } 
				set { SetSelect("COL19638700638", value); } 
			}

			/// <summary>
			/// Checks whether column DocType is added in select statement 
			/// </summary>
			public bool IsSelectDocType { 
				get { return IsSelect("COL19638700633"); } 
				set { SetSelect("COL19638700633", value); } 
			}



	}
}