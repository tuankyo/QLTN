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
	public class aspnet_ApplicationsData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ2137058649";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of aspnet_Applications 
			/// </summary>
			public aspnet_ApplicationsData(string objectID): base(objectID) {}  

			public aspnet_ApplicationsData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field LoweredApplicationName 
			/// </summary>
			public string LoweredApplicationName { 
				get { return GetValue("COL21370586492"); } 
				set { SetValue("COL21370586492", value); } 
			}

			/// <summary>
			/// Gets field Description 
			/// </summary>
			public string Description { 
				get { return GetValue("COL21370586494"); } 
				set { SetValue("COL21370586494", value); } 
			}

			/// <summary>
			/// Gets field ApplicationId 
			/// </summary>
			public string ApplicationId { 
				get { return GetValue("COL21370586493"); } 
				set { SetValue("COL21370586493", value); } 
			}

			/// <summary>
			/// Gets field ApplicationName 
			/// </summary>
			public string ApplicationName { 
				get { return GetValue("COL21370586491"); } 
				set { SetValue("COL21370586491", value); } 
			}


			/// <summary>
			/// Gets LoweredApplicationName attribute data 
			/// </summary>
			public AttributeData GetLoweredApplicationNameAttributeData() { 
				return GetAttributeData("COL21370586492"); 
			}

			/// <summary>
			/// Gets Description attribute data 
			/// </summary>
			public AttributeData GetDescriptionAttributeData() { 
				return GetAttributeData("COL21370586494"); 
			}

			/// <summary>
			/// Gets ApplicationId attribute data 
			/// </summary>
			public AttributeData GetApplicationIdAttributeData() { 
				return GetAttributeData("COL21370586493"); 
			}

			/// <summary>
			/// Gets ApplicationName attribute data 
			/// </summary>
			public AttributeData GetApplicationNameAttributeData() { 
				return GetAttributeData("COL21370586491"); 
			}


			/// <summary>
			/// Gets column LoweredApplicationName with alias  
			/// </summary>
			public string ColLoweredApplicationName { 
				get { return GetColumnName("COL21370586492"); } 
			}

			/// <summary>
			/// Gets column Description with alias  
			/// </summary>
			public string ColDescription { 
				get { return GetColumnName("COL21370586494"); } 
			}

			/// <summary>
			/// Gets column ApplicationId with alias  
			/// </summary>
			public string ColApplicationId { 
				get { return GetColumnName("COL21370586493"); } 
			}

			/// <summary>
			/// Gets column ApplicationName with alias  
			/// </summary>
			public string ColApplicationName { 
				get { return GetColumnName("COL21370586491"); } 
			}


			/// <summary>
			/// Checks whether column LoweredApplicationName is added in select statement 
			/// </summary>
			public bool IsSelectLoweredApplicationName { 
				get { return IsSelect("COL21370586492"); } 
				set { SetSelect("COL21370586492", value); } 
			}

			/// <summary>
			/// Checks whether column Description is added in select statement 
			/// </summary>
			public bool IsSelectDescription { 
				get { return IsSelect("COL21370586494"); } 
				set { SetSelect("COL21370586494", value); } 
			}

			/// <summary>
			/// Checks whether column ApplicationId is added in select statement 
			/// </summary>
			public bool IsSelectApplicationId { 
				get { return IsSelect("COL21370586493"); } 
				set { SetSelect("COL21370586493", value); } 
			}

			/// <summary>
			/// Checks whether column ApplicationName is added in select statement 
			/// </summary>
			public bool IsSelectApplicationName { 
				get { return IsSelect("COL21370586491"); } 
				set { SetSelect("COL21370586491", value); } 
			}



	}
}