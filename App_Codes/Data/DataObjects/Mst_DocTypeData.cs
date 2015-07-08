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
	public class Mst_DocTypeData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ258099960";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of Mst_DocType 
			/// </summary>
			public Mst_DocTypeData(string objectID): base(objectID) {}  

			public Mst_DocTypeData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field DocType 
			/// </summary>
			public string DocType { 
				get { return GetValue("COL2580999602"); } 
				set { SetValue("COL2580999602", value); } 
			}

			/// <summary>
			/// Gets field Comment 
			/// </summary>
			public string Comment { 
				get { return GetValue("COL2580999603"); } 
				set { SetValue("COL2580999603", value); } 
			}

			/// <summary>
			/// Gets field id 
			/// </summary>
			public string id { 
				get { return GetValue("COL2580999601"); } 
				set { SetValue("COL2580999601", value); } 
			}


			/// <summary>
			/// Gets DocType attribute data 
			/// </summary>
			public AttributeData GetDocTypeAttributeData() { 
				return GetAttributeData("COL2580999602"); 
			}

			/// <summary>
			/// Gets Comment attribute data 
			/// </summary>
			public AttributeData GetCommentAttributeData() { 
				return GetAttributeData("COL2580999603"); 
			}

			/// <summary>
			/// Gets id attribute data 
			/// </summary>
			public AttributeData GetidAttributeData() { 
				return GetAttributeData("COL2580999601"); 
			}


			/// <summary>
			/// Gets column DocType with alias  
			/// </summary>
			public string ColDocType { 
				get { return GetColumnName("COL2580999602"); } 
			}

			/// <summary>
			/// Gets column Comment with alias  
			/// </summary>
			public string ColComment { 
				get { return GetColumnName("COL2580999603"); } 
			}

			/// <summary>
			/// Gets column id with alias  
			/// </summary>
			public string Colid { 
				get { return GetColumnName("COL2580999601"); } 
			}


			/// <summary>
			/// Checks whether column DocType is added in select statement 
			/// </summary>
			public bool IsSelectDocType { 
				get { return IsSelect("COL2580999602"); } 
				set { SetSelect("COL2580999602", value); } 
			}

			/// <summary>
			/// Checks whether column Comment is added in select statement 
			/// </summary>
			public bool IsSelectComment { 
				get { return IsSelect("COL2580999603"); } 
				set { SetSelect("COL2580999603", value); } 
			}

			/// <summary>
			/// Checks whether column id is added in select statement 
			/// </summary>
			public bool IsSelectid { 
				get { return IsSelect("COL2580999601"); } 
				set { SetSelect("COL2580999601", value); } 
			}



	}
}