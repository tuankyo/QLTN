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
	public class Mst_DeptData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ543341000";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of Mst_Dept 
			/// </summary>
			public Mst_DeptData(string objectID): base(objectID) {}  

			public Mst_DeptData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field Dept 
			/// </summary>
			public string Dept { 
				get { return GetValue("COL5433410002"); } 
				set { SetValue("COL5433410002", value); } 
			}

			/// <summary>
			/// Gets field id 
			/// </summary>
			public string id { 
				get { return GetValue("COL5433410001"); } 
				set { SetValue("COL5433410001", value); } 
			}


			/// <summary>
			/// Gets Dept attribute data 
			/// </summary>
			public AttributeData GetDeptAttributeData() { 
				return GetAttributeData("COL5433410002"); 
			}

			/// <summary>
			/// Gets id attribute data 
			/// </summary>
			public AttributeData GetidAttributeData() { 
				return GetAttributeData("COL5433410001"); 
			}


			/// <summary>
			/// Gets column Dept with alias  
			/// </summary>
			public string ColDept { 
				get { return GetColumnName("COL5433410002"); } 
			}

			/// <summary>
			/// Gets column id with alias  
			/// </summary>
			public string Colid { 
				get { return GetColumnName("COL5433410001"); } 
			}


			/// <summary>
			/// Checks whether column Dept is added in select statement 
			/// </summary>
			public bool IsSelectDept { 
				get { return IsSelect("COL5433410002"); } 
				set { SetSelect("COL5433410002", value); } 
			}

			/// <summary>
			/// Checks whether column id is added in select statement 
			/// </summary>
			public bool IsSelectid { 
				get { return IsSelect("COL5433410001"); } 
				set { SetSelect("COL5433410001", value); } 
			}



	}
}