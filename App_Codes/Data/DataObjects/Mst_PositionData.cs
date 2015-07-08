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
	public class Mst_PositionData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ1986822140";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of Mst_Position 
			/// </summary>
			public Mst_PositionData(string objectID): base(objectID) {}  

			public Mst_PositionData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field JobType 
			/// </summary>
			public string JobType { 
				get { return GetValue("COL19868221403"); } 
				set { SetValue("COL19868221403", value); } 
			}

			/// <summary>
			/// Gets field Position 
			/// </summary>
			public string Position { 
				get { return GetValue("COL19868221402"); } 
				set { SetValue("COL19868221402", value); } 
			}

			/// <summary>
			/// Gets field id 
			/// </summary>
			public string id { 
				get { return GetValue("COL19868221401"); } 
				set { SetValue("COL19868221401", value); } 
			}


			/// <summary>
			/// Gets JobType attribute data 
			/// </summary>
			public AttributeData GetJobTypeAttributeData() { 
				return GetAttributeData("COL19868221403"); 
			}

			/// <summary>
			/// Gets Position attribute data 
			/// </summary>
			public AttributeData GetPositionAttributeData() { 
				return GetAttributeData("COL19868221402"); 
			}

			/// <summary>
			/// Gets id attribute data 
			/// </summary>
			public AttributeData GetidAttributeData() { 
				return GetAttributeData("COL19868221401"); 
			}


			/// <summary>
			/// Gets column JobType with alias  
			/// </summary>
			public string ColJobType { 
				get { return GetColumnName("COL19868221403"); } 
			}

			/// <summary>
			/// Gets column Position with alias  
			/// </summary>
			public string ColPosition { 
				get { return GetColumnName("COL19868221402"); } 
			}

			/// <summary>
			/// Gets column id with alias  
			/// </summary>
			public string Colid { 
				get { return GetColumnName("COL19868221401"); } 
			}


			/// <summary>
			/// Checks whether column JobType is added in select statement 
			/// </summary>
			public bool IsSelectJobType { 
				get { return IsSelect("COL19868221403"); } 
				set { SetSelect("COL19868221403", value); } 
			}

			/// <summary>
			/// Checks whether column Position is added in select statement 
			/// </summary>
			public bool IsSelectPosition { 
				get { return IsSelect("COL19868221402"); } 
				set { SetSelect("COL19868221402", value); } 
			}

			/// <summary>
			/// Checks whether column id is added in select statement 
			/// </summary>
			public bool IsSelectid { 
				get { return IsSelect("COL19868221401"); } 
				set { SetSelect("COL19868221401", value); } 
			}



	}
}