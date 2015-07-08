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
	public class Mst_UnitData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ24387156";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of Mst_Unit 
			/// </summary>
			public Mst_UnitData(string objectID): base(objectID) {}  

			public Mst_UnitData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field unit_en 
			/// </summary>
			public string unit_en { 
				get { return GetValue("COL243871563"); } 
				set { SetValue("COL243871563", value); } 
			}

			/// <summary>
			/// Gets field id 
			/// </summary>
			public string id { 
				get { return GetValue("COL243871561"); } 
				set { SetValue("COL243871561", value); } 
			}

			/// <summary>
			/// Gets field unit_vn 
			/// </summary>
			public string unit_vn { 
				get { return GetValue("COL243871562"); } 
				set { SetValue("COL243871562", value); } 
			}


			/// <summary>
			/// Gets unit_en attribute data 
			/// </summary>
			public AttributeData Getunit_enAttributeData() { 
				return GetAttributeData("COL243871563"); 
			}

			/// <summary>
			/// Gets id attribute data 
			/// </summary>
			public AttributeData GetidAttributeData() { 
				return GetAttributeData("COL243871561"); 
			}

			/// <summary>
			/// Gets unit_vn attribute data 
			/// </summary>
			public AttributeData Getunit_vnAttributeData() { 
				return GetAttributeData("COL243871562"); 
			}


			/// <summary>
			/// Gets column unit_en with alias  
			/// </summary>
			public string Colunit_en { 
				get { return GetColumnName("COL243871563"); } 
			}

			/// <summary>
			/// Gets column id with alias  
			/// </summary>
			public string Colid { 
				get { return GetColumnName("COL243871561"); } 
			}

			/// <summary>
			/// Gets column unit_vn with alias  
			/// </summary>
			public string Colunit_vn { 
				get { return GetColumnName("COL243871562"); } 
			}


			/// <summary>
			/// Checks whether column unit_en is added in select statement 
			/// </summary>
			public bool IsSelectunit_en { 
				get { return IsSelect("COL243871563"); } 
				set { SetSelect("COL243871563", value); } 
			}

			/// <summary>
			/// Checks whether column id is added in select statement 
			/// </summary>
			public bool IsSelectid { 
				get { return IsSelect("COL243871561"); } 
				set { SetSelect("COL243871561", value); } 
			}

			/// <summary>
			/// Checks whether column unit_vn is added in select statement 
			/// </summary>
			public bool IsSelectunit_vn { 
				get { return IsSelect("COL243871562"); } 
				set { SetSelect("COL243871562", value); } 
			}



	}
}