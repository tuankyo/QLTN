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
	public class aspnet_PathsData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ1461580245";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of aspnet_Paths 
			/// </summary>
			public aspnet_PathsData(string objectID): base(objectID) {}  

			public aspnet_PathsData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field LoweredPath 
			/// </summary>
			public string LoweredPath { 
				get { return GetValue("COL14615802454"); } 
				set { SetValue("COL14615802454", value); } 
			}

			/// <summary>
			/// Gets field Path 
			/// </summary>
			public string Path { 
				get { return GetValue("COL14615802453"); } 
				set { SetValue("COL14615802453", value); } 
			}

			/// <summary>
			/// Gets field PathId 
			/// </summary>
			public string PathId { 
				get { return GetValue("COL14615802452"); } 
				set { SetValue("COL14615802452", value); } 
			}

			/// <summary>
			/// Gets field ApplicationId 
			/// </summary>
			public string ApplicationId { 
				get { return GetValue("COL14615802451"); } 
				set { SetValue("COL14615802451", value); } 
			}


			/// <summary>
			/// Gets LoweredPath attribute data 
			/// </summary>
			public AttributeData GetLoweredPathAttributeData() { 
				return GetAttributeData("COL14615802454"); 
			}

			/// <summary>
			/// Gets Path attribute data 
			/// </summary>
			public AttributeData GetPathAttributeData() { 
				return GetAttributeData("COL14615802453"); 
			}

			/// <summary>
			/// Gets PathId attribute data 
			/// </summary>
			public AttributeData GetPathIdAttributeData() { 
				return GetAttributeData("COL14615802452"); 
			}

			/// <summary>
			/// Gets ApplicationId attribute data 
			/// </summary>
			public AttributeData GetApplicationIdAttributeData() { 
				return GetAttributeData("COL14615802451"); 
			}


			/// <summary>
			/// Gets column LoweredPath with alias  
			/// </summary>
			public string ColLoweredPath { 
				get { return GetColumnName("COL14615802454"); } 
			}

			/// <summary>
			/// Gets column Path with alias  
			/// </summary>
			public string ColPath { 
				get { return GetColumnName("COL14615802453"); } 
			}

			/// <summary>
			/// Gets column PathId with alias  
			/// </summary>
			public string ColPathId { 
				get { return GetColumnName("COL14615802452"); } 
			}

			/// <summary>
			/// Gets column ApplicationId with alias  
			/// </summary>
			public string ColApplicationId { 
				get { return GetColumnName("COL14615802451"); } 
			}


			/// <summary>
			/// Checks whether column LoweredPath is added in select statement 
			/// </summary>
			public bool IsSelectLoweredPath { 
				get { return IsSelect("COL14615802454"); } 
				set { SetSelect("COL14615802454", value); } 
			}

			/// <summary>
			/// Checks whether column Path is added in select statement 
			/// </summary>
			public bool IsSelectPath { 
				get { return IsSelect("COL14615802453"); } 
				set { SetSelect("COL14615802453", value); } 
			}

			/// <summary>
			/// Checks whether column PathId is added in select statement 
			/// </summary>
			public bool IsSelectPathId { 
				get { return IsSelect("COL14615802452"); } 
				set { SetSelect("COL14615802452", value); } 
			}

			/// <summary>
			/// Checks whether column ApplicationId is added in select statement 
			/// </summary>
			public bool IsSelectApplicationId { 
				get { return IsSelect("COL14615802451"); } 
				set { SetSelect("COL14615802451", value); } 
			}



	}
}