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
	public class Mst_DocSubjectData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ847342083";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of Mst_DocSubject 
			/// </summary>
			public Mst_DocSubjectData(string objectID): base(objectID) {}  

			public Mst_DocSubjectData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field id 
			/// </summary>
			public string id { 
				get { return GetValue("COL8473420831"); } 
				set { SetValue("COL8473420831", value); } 
			}

			/// <summary>
			/// Gets field DocSubject 
			/// </summary>
			public string DocSubject { 
				get { return GetValue("COL8473420832"); } 
				set { SetValue("COL8473420832", value); } 
			}

			/// <summary>
			/// Gets field DocType 
			/// </summary>
			public string DocType { 
				get { return GetValue("COL8473420833"); } 
				set { SetValue("COL8473420833", value); } 
			}


			/// <summary>
			/// Gets id attribute data 
			/// </summary>
			public AttributeData GetidAttributeData() { 
				return GetAttributeData("COL8473420831"); 
			}

			/// <summary>
			/// Gets DocSubject attribute data 
			/// </summary>
			public AttributeData GetDocSubjectAttributeData() { 
				return GetAttributeData("COL8473420832"); 
			}

			/// <summary>
			/// Gets DocType attribute data 
			/// </summary>
			public AttributeData GetDocTypeAttributeData() { 
				return GetAttributeData("COL8473420833"); 
			}


			/// <summary>
			/// Gets column id with alias  
			/// </summary>
			public string Colid { 
				get { return GetColumnName("COL8473420831"); } 
			}

			/// <summary>
			/// Gets column DocSubject with alias  
			/// </summary>
			public string ColDocSubject { 
				get { return GetColumnName("COL8473420832"); } 
			}

			/// <summary>
			/// Gets column DocType with alias  
			/// </summary>
			public string ColDocType { 
				get { return GetColumnName("COL8473420833"); } 
			}


			/// <summary>
			/// Checks whether column id is added in select statement 
			/// </summary>
			public bool IsSelectid { 
				get { return IsSelect("COL8473420831"); } 
				set { SetSelect("COL8473420831", value); } 
			}

			/// <summary>
			/// Checks whether column DocSubject is added in select statement 
			/// </summary>
			public bool IsSelectDocSubject { 
				get { return IsSelect("COL8473420832"); } 
				set { SetSelect("COL8473420832", value); } 
			}

			/// <summary>
			/// Checks whether column DocType is added in select statement 
			/// </summary>
			public bool IsSelectDocType { 
				get { return IsSelect("COL8473420833"); } 
				set { SetSelect("COL8473420833", value); } 
			}



	}
}