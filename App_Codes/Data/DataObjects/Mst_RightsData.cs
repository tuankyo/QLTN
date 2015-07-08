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
	public class Mst_RightsData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ98099390";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of Mst_Rights 
			/// </summary>
			public Mst_RightsData(string objectID): base(objectID) {}  

			public Mst_RightsData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field CreatedBy 
			/// </summary>
			public string CreatedBy { 
				get { return GetValue("COL980993906"); } 
				set { SetValue("COL980993906", value); } 
			}

			/// <summary>
			/// Gets field RoleId 
			/// </summary>
			public string RoleId { 
				get { return GetValue("COL980993903"); } 
				set { SetValue("COL980993903", value); } 
			}

			/// <summary>
			/// Gets field ModifiedBy 
			/// </summary>
			public string ModifiedBy { 
				get { return GetValue("COL980993908"); } 
				set { SetValue("COL980993908", value); } 
			}

			/// <summary>
			/// Gets field Comment 
			/// </summary>
			public string Comment { 
				get { return GetValue("COL980993904"); } 
				set { SetValue("COL980993904", value); } 
			}

			/// <summary>
			/// Gets field id 
			/// </summary>
			public string id { 
				get { return GetValue("COL980993901"); } 
				set { SetValue("COL980993901", value); } 
			}

			/// <summary>
			/// Gets field FunctionId 
			/// </summary>
			public string FunctionId { 
				get { return GetValue("COL980993902"); } 
				set { SetValue("COL980993902", value); } 
			}

			/// <summary>
			/// Gets field Modified 
			/// </summary>
			public string Modified { 
				get { return GetValue("COL980993907"); } 
				set { SetValue("COL980993907", value); } 
			}

			/// <summary>
			/// Gets field DelFlag 
			/// </summary>
			public string DelFlag { 
				get { return GetValue("COL980993909"); } 
				set { SetValue("COL980993909", value); } 
			}

			/// <summary>
			/// Gets field Created 
			/// </summary>
			public string Created { 
				get { return GetValue("COL980993905"); } 
				set { SetValue("COL980993905", value); } 
			}


			/// <summary>
			/// Gets CreatedBy attribute data 
			/// </summary>
			public AttributeData GetCreatedByAttributeData() { 
				return GetAttributeData("COL980993906"); 
			}

			/// <summary>
			/// Gets RoleId attribute data 
			/// </summary>
			public AttributeData GetRoleIdAttributeData() { 
				return GetAttributeData("COL980993903"); 
			}

			/// <summary>
			/// Gets ModifiedBy attribute data 
			/// </summary>
			public AttributeData GetModifiedByAttributeData() { 
				return GetAttributeData("COL980993908"); 
			}

			/// <summary>
			/// Gets Comment attribute data 
			/// </summary>
			public AttributeData GetCommentAttributeData() { 
				return GetAttributeData("COL980993904"); 
			}

			/// <summary>
			/// Gets id attribute data 
			/// </summary>
			public AttributeData GetidAttributeData() { 
				return GetAttributeData("COL980993901"); 
			}

			/// <summary>
			/// Gets FunctionId attribute data 
			/// </summary>
			public AttributeData GetFunctionIdAttributeData() { 
				return GetAttributeData("COL980993902"); 
			}

			/// <summary>
			/// Gets Modified attribute data 
			/// </summary>
			public AttributeData GetModifiedAttributeData() { 
				return GetAttributeData("COL980993907"); 
			}

			/// <summary>
			/// Gets DelFlag attribute data 
			/// </summary>
			public AttributeData GetDelFlagAttributeData() { 
				return GetAttributeData("COL980993909"); 
			}

			/// <summary>
			/// Gets Created attribute data 
			/// </summary>
			public AttributeData GetCreatedAttributeData() { 
				return GetAttributeData("COL980993905"); 
			}


			/// <summary>
			/// Gets column CreatedBy with alias  
			/// </summary>
			public string ColCreatedBy { 
				get { return GetColumnName("COL980993906"); } 
			}

			/// <summary>
			/// Gets column RoleId with alias  
			/// </summary>
			public string ColRoleId { 
				get { return GetColumnName("COL980993903"); } 
			}

			/// <summary>
			/// Gets column ModifiedBy with alias  
			/// </summary>
			public string ColModifiedBy { 
				get { return GetColumnName("COL980993908"); } 
			}

			/// <summary>
			/// Gets column Comment with alias  
			/// </summary>
			public string ColComment { 
				get { return GetColumnName("COL980993904"); } 
			}

			/// <summary>
			/// Gets column id with alias  
			/// </summary>
			public string Colid { 
				get { return GetColumnName("COL980993901"); } 
			}

			/// <summary>
			/// Gets column FunctionId with alias  
			/// </summary>
			public string ColFunctionId { 
				get { return GetColumnName("COL980993902"); } 
			}

			/// <summary>
			/// Gets column Modified with alias  
			/// </summary>
			public string ColModified { 
				get { return GetColumnName("COL980993907"); } 
			}

			/// <summary>
			/// Gets column DelFlag with alias  
			/// </summary>
			public string ColDelFlag { 
				get { return GetColumnName("COL980993909"); } 
			}

			/// <summary>
			/// Gets column Created with alias  
			/// </summary>
			public string ColCreated { 
				get { return GetColumnName("COL980993905"); } 
			}


			/// <summary>
			/// Checks whether column CreatedBy is added in select statement 
			/// </summary>
			public bool IsSelectCreatedBy { 
				get { return IsSelect("COL980993906"); } 
				set { SetSelect("COL980993906", value); } 
			}

			/// <summary>
			/// Checks whether column RoleId is added in select statement 
			/// </summary>
			public bool IsSelectRoleId { 
				get { return IsSelect("COL980993903"); } 
				set { SetSelect("COL980993903", value); } 
			}

			/// <summary>
			/// Checks whether column ModifiedBy is added in select statement 
			/// </summary>
			public bool IsSelectModifiedBy { 
				get { return IsSelect("COL980993908"); } 
				set { SetSelect("COL980993908", value); } 
			}

			/// <summary>
			/// Checks whether column Comment is added in select statement 
			/// </summary>
			public bool IsSelectComment { 
				get { return IsSelect("COL980993904"); } 
				set { SetSelect("COL980993904", value); } 
			}

			/// <summary>
			/// Checks whether column id is added in select statement 
			/// </summary>
			public bool IsSelectid { 
				get { return IsSelect("COL980993901"); } 
				set { SetSelect("COL980993901", value); } 
			}

			/// <summary>
			/// Checks whether column FunctionId is added in select statement 
			/// </summary>
			public bool IsSelectFunctionId { 
				get { return IsSelect("COL980993902"); } 
				set { SetSelect("COL980993902", value); } 
			}

			/// <summary>
			/// Checks whether column Modified is added in select statement 
			/// </summary>
			public bool IsSelectModified { 
				get { return IsSelect("COL980993907"); } 
				set { SetSelect("COL980993907", value); } 
			}

			/// <summary>
			/// Checks whether column DelFlag is added in select statement 
			/// </summary>
			public bool IsSelectDelFlag { 
				get { return IsSelect("COL980993909"); } 
				set { SetSelect("COL980993909", value); } 
			}

			/// <summary>
			/// Checks whether column Created is added in select statement 
			/// </summary>
			public bool IsSelectCreated { 
				get { return IsSelect("COL980993905"); } 
				set { SetSelect("COL980993905", value); } 
			}



	}
}