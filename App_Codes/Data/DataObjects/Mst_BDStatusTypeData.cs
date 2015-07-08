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
	public class Mst_BDStatusTypeData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ575341114";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of Mst_BDStatusType 
			/// </summary>
			public Mst_BDStatusTypeData(string objectID): base(objectID) {}  

			public Mst_BDStatusTypeData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field id 
			/// </summary>
			public string id { 
				get { return GetValue("COL5753411141"); } 
				set { SetValue("COL5753411141", value); } 
			}

			/// <summary>
			/// Gets field Type 
			/// </summary>
			public string Type { 
				get { return GetValue("COL5753411142"); } 
				set { SetValue("COL5753411142", value); } 
			}

			/// <summary>
			/// Gets field Name 
			/// </summary>
			public string Name { 
				get { return GetValue("COL5753411143"); } 
				set { SetValue("COL5753411143", value); } 
			}


			/// <summary>
			/// Gets id attribute data 
			/// </summary>
			public AttributeData GetidAttributeData() { 
				return GetAttributeData("COL5753411141"); 
			}

			/// <summary>
			/// Gets Type attribute data 
			/// </summary>
			public AttributeData GetTypeAttributeData() { 
				return GetAttributeData("COL5753411142"); 
			}

			/// <summary>
			/// Gets Name attribute data 
			/// </summary>
			public AttributeData GetNameAttributeData() { 
				return GetAttributeData("COL5753411143"); 
			}


			/// <summary>
			/// Gets column id with alias  
			/// </summary>
			public string Colid { 
				get { return GetColumnName("COL5753411141"); } 
			}

			/// <summary>
			/// Gets column Type with alias  
			/// </summary>
			public string ColType { 
				get { return GetColumnName("COL5753411142"); } 
			}

			/// <summary>
			/// Gets column Name with alias  
			/// </summary>
			public string ColName { 
				get { return GetColumnName("COL5753411143"); } 
			}


			/// <summary>
			/// Checks whether column id is added in select statement 
			/// </summary>
			public bool IsSelectid { 
				get { return IsSelect("COL5753411141"); } 
				set { SetSelect("COL5753411141", value); } 
			}

			/// <summary>
			/// Checks whether column Type is added in select statement 
			/// </summary>
			public bool IsSelectType { 
				get { return IsSelect("COL5753411142"); } 
				set { SetSelect("COL5753411142", value); } 
			}

			/// <summary>
			/// Checks whether column Name is added in select statement 
			/// </summary>
			public bool IsSelectName { 
				get { return IsSelect("COL5753411143"); } 
				set { SetSelect("COL5753411143", value); } 
			}



	}
}