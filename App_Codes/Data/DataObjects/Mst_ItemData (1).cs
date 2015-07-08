// ==========================================
//  Author : GNT Data Object Generator Tool
//  Created   : 2014-10-21 15:33:03
//  Copyright GNT INC.  All rights reserved.
// ==========================================
using System;
using System.Collections;
using Gnt.Data.Meta;
using Gnt.Data;

namespace BusinessObjects
{

	[Serializable]
	public class Mst_ItemData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ194099732";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of Mst_Item 
			/// </summary>
			public Mst_ItemData(string objectID): base(objectID) {}  

			public Mst_ItemData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field id 
			/// </summary>
			public string id { 
				get { return GetValue("COL1940997321"); } 
				set { SetValue("COL1940997321", value); } 
			}

			/// <summary>
			/// Gets field Item 
			/// </summary>
			public string Item { 
				get { return GetValue("COL1940997322"); } 
				set { SetValue("COL1940997322", value); } 
			}


			/// <summary>
			/// Gets id attribute data 
			/// </summary>
			public AttributeData GetidAttributeData() { 
				return GetAttributeData("COL1940997321"); 
			}

			/// <summary>
			/// Gets Item attribute data 
			/// </summary>
			public AttributeData GetItemAttributeData() { 
				return GetAttributeData("COL1940997322"); 
			}


			/// <summary>
			/// Gets column id with alias  
			/// </summary>
			public string Colid { 
				get { return GetColumnName("COL1940997321"); } 
			}

			/// <summary>
			/// Gets column Item with alias  
			/// </summary>
			public string ColItem { 
				get { return GetColumnName("COL1940997322"); } 
			}


			/// <summary>
			/// Checks whether column id is added in select statement 
			/// </summary>
			public bool IsSelectid { 
				get { return IsSelect("COL1940997321"); } 
				set { SetSelect("COL1940997321", value); } 
			}

			/// <summary>
			/// Checks whether column Item is added in select statement 
			/// </summary>
			public bool IsSelectItem { 
				get { return IsSelect("COL1940997322"); } 
				set { SetSelect("COL1940997322", value); } 
			}



	}
}