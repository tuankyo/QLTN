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
	public class Mst_FunctionsData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ226099846";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of Mst_Functions 
			/// </summary>
			public Mst_FunctionsData(string objectID): base(objectID) {}  

			public Mst_FunctionsData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field Modified 
			/// </summary>
			public string Modified { 
				get { return GetValue("COL2260998467"); } 
				set { SetValue("COL2260998467", value); } 
			}

			/// <summary>
			/// Gets field CreatedBy 
			/// </summary>
			public string CreatedBy { 
				get { return GetValue("COL2260998466"); } 
				set { SetValue("COL2260998466", value); } 
			}

			/// <summary>
			/// Gets field Created 
			/// </summary>
			public string Created { 
				get { return GetValue("COL2260998465"); } 
				set { SetValue("COL2260998465", value); } 
			}

			/// <summary>
			/// Gets field Comment 
			/// </summary>
			public string Comment { 
				get { return GetValue("COL2260998464"); } 
				set { SetValue("COL2260998464", value); } 
			}

			/// <summary>
			/// Gets field FunctionName 
			/// </summary>
			public string FunctionName { 
				get { return GetValue("COL2260998463"); } 
				set { SetValue("COL2260998463", value); } 
			}

			/// <summary>
			/// Gets field FunctionId 
			/// </summary>
			public string FunctionId { 
				get { return GetValue("COL2260998462"); } 
				set { SetValue("COL2260998462", value); } 
			}

			/// <summary>
			/// Gets field id 
			/// </summary>
			public string id { 
				get { return GetValue("COL2260998461"); } 
				set { SetValue("COL2260998461", value); } 
			}

			/// <summary>
			/// Gets field DelFlag 
			/// </summary>
			public string DelFlag { 
				get { return GetValue("COL2260998469"); } 
				set { SetValue("COL2260998469", value); } 
			}

			/// <summary>
			/// Gets field ModifiedBy 
			/// </summary>
			public string ModifiedBy { 
				get { return GetValue("COL2260998468"); } 
				set { SetValue("COL2260998468", value); } 
			}


			/// <summary>
			/// Gets Modified attribute data 
			/// </summary>
			public AttributeData GetModifiedAttributeData() { 
				return GetAttributeData("COL2260998467"); 
			}

			/// <summary>
			/// Gets CreatedBy attribute data 
			/// </summary>
			public AttributeData GetCreatedByAttributeData() { 
				return GetAttributeData("COL2260998466"); 
			}

			/// <summary>
			/// Gets Created attribute data 
			/// </summary>
			public AttributeData GetCreatedAttributeData() { 
				return GetAttributeData("COL2260998465"); 
			}

			/// <summary>
			/// Gets Comment attribute data 
			/// </summary>
			public AttributeData GetCommentAttributeData() { 
				return GetAttributeData("COL2260998464"); 
			}

			/// <summary>
			/// Gets FunctionName attribute data 
			/// </summary>
			public AttributeData GetFunctionNameAttributeData() { 
				return GetAttributeData("COL2260998463"); 
			}

			/// <summary>
			/// Gets FunctionId attribute data 
			/// </summary>
			public AttributeData GetFunctionIdAttributeData() { 
				return GetAttributeData("COL2260998462"); 
			}

			/// <summary>
			/// Gets id attribute data 
			/// </summary>
			public AttributeData GetidAttributeData() { 
				return GetAttributeData("COL2260998461"); 
			}

			/// <summary>
			/// Gets DelFlag attribute data 
			/// </summary>
			public AttributeData GetDelFlagAttributeData() { 
				return GetAttributeData("COL2260998469"); 
			}

			/// <summary>
			/// Gets ModifiedBy attribute data 
			/// </summary>
			public AttributeData GetModifiedByAttributeData() { 
				return GetAttributeData("COL2260998468"); 
			}


			/// <summary>
			/// Gets column Modified with alias  
			/// </summary>
			public string ColModified { 
				get { return GetColumnName("COL2260998467"); } 
			}

			/// <summary>
			/// Gets column CreatedBy with alias  
			/// </summary>
			public string ColCreatedBy { 
				get { return GetColumnName("COL2260998466"); } 
			}

			/// <summary>
			/// Gets column Created with alias  
			/// </summary>
			public string ColCreated { 
				get { return GetColumnName("COL2260998465"); } 
			}

			/// <summary>
			/// Gets column Comment with alias  
			/// </summary>
			public string ColComment { 
				get { return GetColumnName("COL2260998464"); } 
			}

			/// <summary>
			/// Gets column FunctionName with alias  
			/// </summary>
			public string ColFunctionName { 
				get { return GetColumnName("COL2260998463"); } 
			}

			/// <summary>
			/// Gets column FunctionId with alias  
			/// </summary>
			public string ColFunctionId { 
				get { return GetColumnName("COL2260998462"); } 
			}

			/// <summary>
			/// Gets column id with alias  
			/// </summary>
			public string Colid { 
				get { return GetColumnName("COL2260998461"); } 
			}

			/// <summary>
			/// Gets column DelFlag with alias  
			/// </summary>
			public string ColDelFlag { 
				get { return GetColumnName("COL2260998469"); } 
			}

			/// <summary>
			/// Gets column ModifiedBy with alias  
			/// </summary>
			public string ColModifiedBy { 
				get { return GetColumnName("COL2260998468"); } 
			}


			/// <summary>
			/// Checks whether column Modified is added in select statement 
			/// </summary>
			public bool IsSelectModified { 
				get { return IsSelect("COL2260998467"); } 
				set { SetSelect("COL2260998467", value); } 
			}

			/// <summary>
			/// Checks whether column CreatedBy is added in select statement 
			/// </summary>
			public bool IsSelectCreatedBy { 
				get { return IsSelect("COL2260998466"); } 
				set { SetSelect("COL2260998466", value); } 
			}

			/// <summary>
			/// Checks whether column Created is added in select statement 
			/// </summary>
			public bool IsSelectCreated { 
				get { return IsSelect("COL2260998465"); } 
				set { SetSelect("COL2260998465", value); } 
			}

			/// <summary>
			/// Checks whether column Comment is added in select statement 
			/// </summary>
			public bool IsSelectComment { 
				get { return IsSelect("COL2260998464"); } 
				set { SetSelect("COL2260998464", value); } 
			}

			/// <summary>
			/// Checks whether column FunctionName is added in select statement 
			/// </summary>
			public bool IsSelectFunctionName { 
				get { return IsSelect("COL2260998463"); } 
				set { SetSelect("COL2260998463", value); } 
			}

			/// <summary>
			/// Checks whether column FunctionId is added in select statement 
			/// </summary>
			public bool IsSelectFunctionId { 
				get { return IsSelect("COL2260998462"); } 
				set { SetSelect("COL2260998462", value); } 
			}

			/// <summary>
			/// Checks whether column id is added in select statement 
			/// </summary>
			public bool IsSelectid { 
				get { return IsSelect("COL2260998461"); } 
				set { SetSelect("COL2260998461", value); } 
			}

			/// <summary>
			/// Checks whether column DelFlag is added in select statement 
			/// </summary>
			public bool IsSelectDelFlag { 
				get { return IsSelect("COL2260998469"); } 
				set { SetSelect("COL2260998469", value); } 
			}

			/// <summary>
			/// Checks whether column ModifiedBy is added in select statement 
			/// </summary>
			public bool IsSelectModifiedBy { 
				get { return IsSelect("COL2260998468"); } 
				set { SetSelect("COL2260998468", value); } 
			}



	}
}