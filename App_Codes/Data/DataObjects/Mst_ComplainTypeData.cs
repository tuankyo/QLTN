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
	public class Mst_ComplainTypeData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ290100074";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of Mst_ComplainType 
			/// </summary>
			public Mst_ComplainTypeData(string objectID): base(objectID) {}  

			public Mst_ComplainTypeData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field Name 
			/// </summary>
			public string Name { 
				get { return GetValue("COL2901000743"); } 
				set { SetValue("COL2901000743", value); } 
			}

			/// <summary>
			/// Gets field ComplainType 
			/// </summary>
			public string ComplainType { 
				get { return GetValue("COL2901000742"); } 
				set { SetValue("COL2901000742", value); } 
			}

			/// <summary>
			/// Gets field id 
			/// </summary>
			public string id { 
				get { return GetValue("COL2901000741"); } 
				set { SetValue("COL2901000741", value); } 
			}


			/// <summary>
			/// Gets Name attribute data 
			/// </summary>
			public AttributeData GetNameAttributeData() { 
				return GetAttributeData("COL2901000743"); 
			}

			/// <summary>
			/// Gets ComplainType attribute data 
			/// </summary>
			public AttributeData GetComplainTypeAttributeData() { 
				return GetAttributeData("COL2901000742"); 
			}

			/// <summary>
			/// Gets id attribute data 
			/// </summary>
			public AttributeData GetidAttributeData() { 
				return GetAttributeData("COL2901000741"); 
			}


			/// <summary>
			/// Gets column Name with alias  
			/// </summary>
			public string ColName { 
				get { return GetColumnName("COL2901000743"); } 
			}

			/// <summary>
			/// Gets column ComplainType with alias  
			/// </summary>
			public string ColComplainType { 
				get { return GetColumnName("COL2901000742"); } 
			}

			/// <summary>
			/// Gets column id with alias  
			/// </summary>
			public string Colid { 
				get { return GetColumnName("COL2901000741"); } 
			}


			/// <summary>
			/// Checks whether column Name is added in select statement 
			/// </summary>
			public bool IsSelectName { 
				get { return IsSelect("COL2901000743"); } 
				set { SetSelect("COL2901000743", value); } 
			}

			/// <summary>
			/// Checks whether column ComplainType is added in select statement 
			/// </summary>
			public bool IsSelectComplainType { 
				get { return IsSelect("COL2901000742"); } 
				set { SetSelect("COL2901000742", value); } 
			}

			/// <summary>
			/// Checks whether column id is added in select statement 
			/// </summary>
			public bool IsSelectid { 
				get { return IsSelect("COL2901000741"); } 
				set { SetSelect("COL2901000741", value); } 
			}



	}
}