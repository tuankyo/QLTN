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
	public class MST_FlagData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ1640392913";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of MST_Flag 
			/// </summary>
			public MST_FlagData(string objectID): base(objectID) {}  

			public MST_FlagData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field Flag 
			/// </summary>
			public string Flag { 
				get { return GetValue("COL16403929132"); } 
				set { SetValue("COL16403929132", value); } 
			}

			/// <summary>
			/// Gets field FlagId 
			/// </summary>
			public string FlagId { 
				get { return GetValue("COL16403929131"); } 
				set { SetValue("COL16403929131", value); } 
			}


			/// <summary>
			/// Gets Flag attribute data 
			/// </summary>
			public AttributeData GetFlagAttributeData() { 
				return GetAttributeData("COL16403929132"); 
			}

			/// <summary>
			/// Gets FlagId attribute data 
			/// </summary>
			public AttributeData GetFlagIdAttributeData() { 
				return GetAttributeData("COL16403929131"); 
			}


			/// <summary>
			/// Gets column Flag with alias  
			/// </summary>
			public string ColFlag { 
				get { return GetColumnName("COL16403929132"); } 
			}

			/// <summary>
			/// Gets column FlagId with alias  
			/// </summary>
			public string ColFlagId { 
				get { return GetColumnName("COL16403929131"); } 
			}


			/// <summary>
			/// Checks whether column Flag is added in select statement 
			/// </summary>
			public bool IsSelectFlag { 
				get { return IsSelect("COL16403929132"); } 
				set { SetSelect("COL16403929132", value); } 
			}

			/// <summary>
			/// Checks whether column FlagId is added in select statement 
			/// </summary>
			public bool IsSelectFlagId { 
				get { return IsSelect("COL16403929131"); } 
				set { SetSelect("COL16403929131", value); } 
			}



	}
}