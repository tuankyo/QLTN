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
	public class BD_DocumentDownloadData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ904390291";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of BD_DocumentDownload 
			/// </summary>
			public BD_DocumentDownloadData(string objectID): base(objectID) {}  

			public BD_DocumentDownloadData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field DocId 
			/// </summary>
			public string DocId { 
				get { return GetValue("COL9043902912"); } 
				set { SetValue("COL9043902912", value); } 
			}

			/// <summary>
			/// Gets field Created 
			/// </summary>
			public string Created { 
				get { return GetValue("COL9043902913"); } 
				set { SetValue("COL9043902913", value); } 
			}

			/// <summary>
			/// Gets field id 
			/// </summary>
			public string id { 
				get { return GetValue("COL9043902911"); } 
				set { SetValue("COL9043902911", value); } 
			}

			/// <summary>
			/// Gets field ModifiedBy 
			/// </summary>
			public string ModifiedBy { 
				get { return GetValue("COL9043902916"); } 
				set { SetValue("COL9043902916", value); } 
			}

			/// <summary>
			/// Gets field DelFlag 
			/// </summary>
			public string DelFlag { 
				get { return GetValue("COL9043902917"); } 
				set { SetValue("COL9043902917", value); } 
			}

			/// <summary>
			/// Gets field CreatedBy 
			/// </summary>
			public string CreatedBy { 
				get { return GetValue("COL9043902914"); } 
				set { SetValue("COL9043902914", value); } 
			}

			/// <summary>
			/// Gets field Modified 
			/// </summary>
			public string Modified { 
				get { return GetValue("COL9043902915"); } 
				set { SetValue("COL9043902915", value); } 
			}


			/// <summary>
			/// Gets DocId attribute data 
			/// </summary>
			public AttributeData GetDocIdAttributeData() { 
				return GetAttributeData("COL9043902912"); 
			}

			/// <summary>
			/// Gets Created attribute data 
			/// </summary>
			public AttributeData GetCreatedAttributeData() { 
				return GetAttributeData("COL9043902913"); 
			}

			/// <summary>
			/// Gets id attribute data 
			/// </summary>
			public AttributeData GetidAttributeData() { 
				return GetAttributeData("COL9043902911"); 
			}

			/// <summary>
			/// Gets ModifiedBy attribute data 
			/// </summary>
			public AttributeData GetModifiedByAttributeData() { 
				return GetAttributeData("COL9043902916"); 
			}

			/// <summary>
			/// Gets DelFlag attribute data 
			/// </summary>
			public AttributeData GetDelFlagAttributeData() { 
				return GetAttributeData("COL9043902917"); 
			}

			/// <summary>
			/// Gets CreatedBy attribute data 
			/// </summary>
			public AttributeData GetCreatedByAttributeData() { 
				return GetAttributeData("COL9043902914"); 
			}

			/// <summary>
			/// Gets Modified attribute data 
			/// </summary>
			public AttributeData GetModifiedAttributeData() { 
				return GetAttributeData("COL9043902915"); 
			}


			/// <summary>
			/// Gets column DocId with alias  
			/// </summary>
			public string ColDocId { 
				get { return GetColumnName("COL9043902912"); } 
			}

			/// <summary>
			/// Gets column Created with alias  
			/// </summary>
			public string ColCreated { 
				get { return GetColumnName("COL9043902913"); } 
			}

			/// <summary>
			/// Gets column id with alias  
			/// </summary>
			public string Colid { 
				get { return GetColumnName("COL9043902911"); } 
			}

			/// <summary>
			/// Gets column ModifiedBy with alias  
			/// </summary>
			public string ColModifiedBy { 
				get { return GetColumnName("COL9043902916"); } 
			}

			/// <summary>
			/// Gets column DelFlag with alias  
			/// </summary>
			public string ColDelFlag { 
				get { return GetColumnName("COL9043902917"); } 
			}

			/// <summary>
			/// Gets column CreatedBy with alias  
			/// </summary>
			public string ColCreatedBy { 
				get { return GetColumnName("COL9043902914"); } 
			}

			/// <summary>
			/// Gets column Modified with alias  
			/// </summary>
			public string ColModified { 
				get { return GetColumnName("COL9043902915"); } 
			}


			/// <summary>
			/// Checks whether column DocId is added in select statement 
			/// </summary>
			public bool IsSelectDocId { 
				get { return IsSelect("COL9043902912"); } 
				set { SetSelect("COL9043902912", value); } 
			}

			/// <summary>
			/// Checks whether column Created is added in select statement 
			/// </summary>
			public bool IsSelectCreated { 
				get { return IsSelect("COL9043902913"); } 
				set { SetSelect("COL9043902913", value); } 
			}

			/// <summary>
			/// Checks whether column id is added in select statement 
			/// </summary>
			public bool IsSelectid { 
				get { return IsSelect("COL9043902911"); } 
				set { SetSelect("COL9043902911", value); } 
			}

			/// <summary>
			/// Checks whether column ModifiedBy is added in select statement 
			/// </summary>
			public bool IsSelectModifiedBy { 
				get { return IsSelect("COL9043902916"); } 
				set { SetSelect("COL9043902916", value); } 
			}

			/// <summary>
			/// Checks whether column DelFlag is added in select statement 
			/// </summary>
			public bool IsSelectDelFlag { 
				get { return IsSelect("COL9043902917"); } 
				set { SetSelect("COL9043902917", value); } 
			}

			/// <summary>
			/// Checks whether column CreatedBy is added in select statement 
			/// </summary>
			public bool IsSelectCreatedBy { 
				get { return IsSelect("COL9043902914"); } 
				set { SetSelect("COL9043902914", value); } 
			}

			/// <summary>
			/// Checks whether column Modified is added in select statement 
			/// </summary>
			public bool IsSelectModified { 
				get { return IsSelect("COL9043902915"); } 
				set { SetSelect("COL9043902915", value); } 
			}



	}
}