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
	public class Mst_SuppliesStatusData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ34099162";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of Mst_SuppliesStatus 
			/// </summary>
			public Mst_SuppliesStatusData(string objectID): base(objectID) {}  

			public Mst_SuppliesStatusData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field SuppliesStatus 
			/// </summary>
			public string SuppliesStatus { 
				get { return GetValue("COL3409916217"); } 
				set { SetValue("COL3409916217", value); } 
			}

			/// <summary>
			/// Gets field SuppliesType 
			/// </summary>
			public string SuppliesType { 
				get { return GetValue("COL3409916216"); } 
				set { SetValue("COL3409916216", value); } 
			}

			/// <summary>
			/// Gets field id 
			/// </summary>
			public string id { 
				get { return GetValue("COL340991621"); } 
				set { SetValue("COL340991621", value); } 
			}


			/// <summary>
			/// Gets SuppliesStatus attribute data 
			/// </summary>
			public AttributeData GetSuppliesStatusAttributeData() { 
				return GetAttributeData("COL3409916217"); 
			}

			/// <summary>
			/// Gets SuppliesType attribute data 
			/// </summary>
			public AttributeData GetSuppliesTypeAttributeData() { 
				return GetAttributeData("COL3409916216"); 
			}

			/// <summary>
			/// Gets id attribute data 
			/// </summary>
			public AttributeData GetidAttributeData() { 
				return GetAttributeData("COL340991621"); 
			}


			/// <summary>
			/// Gets column SuppliesStatus with alias  
			/// </summary>
			public string ColSuppliesStatus { 
				get { return GetColumnName("COL3409916217"); } 
			}

			/// <summary>
			/// Gets column SuppliesType with alias  
			/// </summary>
			public string ColSuppliesType { 
				get { return GetColumnName("COL3409916216"); } 
			}

			/// <summary>
			/// Gets column id with alias  
			/// </summary>
			public string Colid { 
				get { return GetColumnName("COL340991621"); } 
			}


			/// <summary>
			/// Checks whether column SuppliesStatus is added in select statement 
			/// </summary>
			public bool IsSelectSuppliesStatus { 
				get { return IsSelect("COL3409916217"); } 
				set { SetSelect("COL3409916217", value); } 
			}

			/// <summary>
			/// Checks whether column SuppliesType is added in select statement 
			/// </summary>
			public bool IsSelectSuppliesType { 
				get { return IsSelect("COL3409916216"); } 
				set { SetSelect("COL3409916216", value); } 
			}

			/// <summary>
			/// Checks whether column id is added in select statement 
			/// </summary>
			public bool IsSelectid { 
				get { return IsSelect("COL340991621"); } 
				set { SetSelect("COL340991621", value); } 
			}



	}
}