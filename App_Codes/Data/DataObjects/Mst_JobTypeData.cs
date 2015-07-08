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
	public class Mst_JobTypeData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ162099618";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of Mst_JobType 
			/// </summary>
			public Mst_JobTypeData(string objectID): base(objectID) {}  

			public Mst_JobTypeData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field ModifiedBy 
			/// </summary>
			public string ModifiedBy { 
				get { return GetValue("COL1620996187"); } 
				set { SetValue("COL1620996187", value); } 
			}

			/// <summary>
			/// Gets field Modified 
			/// </summary>
			public string Modified { 
				get { return GetValue("COL1620996186"); } 
				set { SetValue("COL1620996186", value); } 
			}

			/// <summary>
			/// Gets field CreatedBy 
			/// </summary>
			public string CreatedBy { 
				get { return GetValue("COL1620996185"); } 
				set { SetValue("COL1620996185", value); } 
			}

			/// <summary>
			/// Gets field Created 
			/// </summary>
			public string Created { 
				get { return GetValue("COL1620996184"); } 
				set { SetValue("COL1620996184", value); } 
			}

			/// <summary>
			/// Gets field DelFlag 
			/// </summary>
			public string DelFlag { 
				get { return GetValue("COL1620996188"); } 
				set { SetValue("COL1620996188", value); } 
			}

			/// <summary>
			/// Gets field Comment 
			/// </summary>
			public string Comment { 
				get { return GetValue("COL1620996183"); } 
				set { SetValue("COL1620996183", value); } 
			}

			/// <summary>
			/// Gets field Name 
			/// </summary>
			public string Name { 
				get { return GetValue("COL1620996182"); } 
				set { SetValue("COL1620996182", value); } 
			}

			/// <summary>
			/// Gets field id 
			/// </summary>
			public string id { 
				get { return GetValue("COL1620996181"); } 
				set { SetValue("COL1620996181", value); } 
			}


			/// <summary>
			/// Gets ModifiedBy attribute data 
			/// </summary>
			public AttributeData GetModifiedByAttributeData() { 
				return GetAttributeData("COL1620996187"); 
			}

			/// <summary>
			/// Gets Modified attribute data 
			/// </summary>
			public AttributeData GetModifiedAttributeData() { 
				return GetAttributeData("COL1620996186"); 
			}

			/// <summary>
			/// Gets CreatedBy attribute data 
			/// </summary>
			public AttributeData GetCreatedByAttributeData() { 
				return GetAttributeData("COL1620996185"); 
			}

			/// <summary>
			/// Gets Created attribute data 
			/// </summary>
			public AttributeData GetCreatedAttributeData() { 
				return GetAttributeData("COL1620996184"); 
			}

			/// <summary>
			/// Gets DelFlag attribute data 
			/// </summary>
			public AttributeData GetDelFlagAttributeData() { 
				return GetAttributeData("COL1620996188"); 
			}

			/// <summary>
			/// Gets Comment attribute data 
			/// </summary>
			public AttributeData GetCommentAttributeData() { 
				return GetAttributeData("COL1620996183"); 
			}

			/// <summary>
			/// Gets Name attribute data 
			/// </summary>
			public AttributeData GetNameAttributeData() { 
				return GetAttributeData("COL1620996182"); 
			}

			/// <summary>
			/// Gets id attribute data 
			/// </summary>
			public AttributeData GetidAttributeData() { 
				return GetAttributeData("COL1620996181"); 
			}


			/// <summary>
			/// Gets column ModifiedBy with alias  
			/// </summary>
			public string ColModifiedBy { 
				get { return GetColumnName("COL1620996187"); } 
			}

			/// <summary>
			/// Gets column Modified with alias  
			/// </summary>
			public string ColModified { 
				get { return GetColumnName("COL1620996186"); } 
			}

			/// <summary>
			/// Gets column CreatedBy with alias  
			/// </summary>
			public string ColCreatedBy { 
				get { return GetColumnName("COL1620996185"); } 
			}

			/// <summary>
			/// Gets column Created with alias  
			/// </summary>
			public string ColCreated { 
				get { return GetColumnName("COL1620996184"); } 
			}

			/// <summary>
			/// Gets column DelFlag with alias  
			/// </summary>
			public string ColDelFlag { 
				get { return GetColumnName("COL1620996188"); } 
			}

			/// <summary>
			/// Gets column Comment with alias  
			/// </summary>
			public string ColComment { 
				get { return GetColumnName("COL1620996183"); } 
			}

			/// <summary>
			/// Gets column Name with alias  
			/// </summary>
			public string ColName { 
				get { return GetColumnName("COL1620996182"); } 
			}

			/// <summary>
			/// Gets column id with alias  
			/// </summary>
			public string Colid { 
				get { return GetColumnName("COL1620996181"); } 
			}


			/// <summary>
			/// Checks whether column ModifiedBy is added in select statement 
			/// </summary>
			public bool IsSelectModifiedBy { 
				get { return IsSelect("COL1620996187"); } 
				set { SetSelect("COL1620996187", value); } 
			}

			/// <summary>
			/// Checks whether column Modified is added in select statement 
			/// </summary>
			public bool IsSelectModified { 
				get { return IsSelect("COL1620996186"); } 
				set { SetSelect("COL1620996186", value); } 
			}

			/// <summary>
			/// Checks whether column CreatedBy is added in select statement 
			/// </summary>
			public bool IsSelectCreatedBy { 
				get { return IsSelect("COL1620996185"); } 
				set { SetSelect("COL1620996185", value); } 
			}

			/// <summary>
			/// Checks whether column Created is added in select statement 
			/// </summary>
			public bool IsSelectCreated { 
				get { return IsSelect("COL1620996184"); } 
				set { SetSelect("COL1620996184", value); } 
			}

			/// <summary>
			/// Checks whether column DelFlag is added in select statement 
			/// </summary>
			public bool IsSelectDelFlag { 
				get { return IsSelect("COL1620996188"); } 
				set { SetSelect("COL1620996188", value); } 
			}

			/// <summary>
			/// Checks whether column Comment is added in select statement 
			/// </summary>
			public bool IsSelectComment { 
				get { return IsSelect("COL1620996183"); } 
				set { SetSelect("COL1620996183", value); } 
			}

			/// <summary>
			/// Checks whether column Name is added in select statement 
			/// </summary>
			public bool IsSelectName { 
				get { return IsSelect("COL1620996182"); } 
				set { SetSelect("COL1620996182", value); } 
			}

			/// <summary>
			/// Checks whether column id is added in select statement 
			/// </summary>
			public bool IsSelectid { 
				get { return IsSelect("COL1620996181"); } 
				set { SetSelect("COL1620996181", value); } 
			}



	}
}