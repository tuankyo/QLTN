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
	public class Mst_StatusData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ2082822482";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of Mst_Status 
			/// </summary>
			public Mst_StatusData(string objectID): base(objectID) {}  

			public Mst_StatusData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field Status 
			/// </summary>
			public string Status { 
				get { return GetValue("COL20828224822"); } 
				set { SetValue("COL20828224822", value); } 
			}

			/// <summary>
			/// Gets field id 
			/// </summary>
			public string id { 
				get { return GetValue("COL20828224821"); } 
				set { SetValue("COL20828224821", value); } 
			}


			/// <summary>
			/// Gets Status attribute data 
			/// </summary>
			public AttributeData GetStatusAttributeData() { 
				return GetAttributeData("COL20828224822"); 
			}

			/// <summary>
			/// Gets id attribute data 
			/// </summary>
			public AttributeData GetidAttributeData() { 
				return GetAttributeData("COL20828224821"); 
			}


			/// <summary>
			/// Gets column Status with alias  
			/// </summary>
			public string ColStatus { 
				get { return GetColumnName("COL20828224822"); } 
			}

			/// <summary>
			/// Gets column id with alias  
			/// </summary>
			public string Colid { 
				get { return GetColumnName("COL20828224821"); } 
			}


			/// <summary>
			/// Checks whether column Status is added in select statement 
			/// </summary>
			public bool IsSelectStatus { 
				get { return IsSelect("COL20828224822"); } 
				set { SetSelect("COL20828224822", value); } 
			}

			/// <summary>
			/// Checks whether column id is added in select statement 
			/// </summary>
			public bool IsSelectid { 
				get { return IsSelect("COL20828224821"); } 
				set { SetSelect("COL20828224821", value); } 
			}



	}
}