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
	public class aspnet_ProfileData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ885578193";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of aspnet_Profile 
			/// </summary>
			public aspnet_ProfileData(string objectID): base(objectID) {}  

			public aspnet_ProfileData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field PropertyValuesString 
			/// </summary>
			public string PropertyValuesString { 
				get { return GetValue("COL8855781933"); } 
				set { SetValue("COL8855781933", value); } 
			}

			/// <summary>
			/// Gets field UserId 
			/// </summary>
			public string UserId { 
				get { return GetValue("COL8855781931"); } 
				set { SetValue("COL8855781931", value); } 
			}

			/// <summary>
			/// Gets field PropertyValuesBinary 
			/// </summary>
			public string PropertyValuesBinary { 
				get { return GetValue("COL8855781934"); } 
				set { SetValue("COL8855781934", value); } 
			}

			/// <summary>
			/// Gets field LastUpdatedDate 
			/// </summary>
			public string LastUpdatedDate { 
				get { return GetValue("COL8855781935"); } 
				set { SetValue("COL8855781935", value); } 
			}

			/// <summary>
			/// Gets field PropertyNames 
			/// </summary>
			public string PropertyNames { 
				get { return GetValue("COL8855781932"); } 
				set { SetValue("COL8855781932", value); } 
			}


			/// <summary>
			/// Gets PropertyValuesString attribute data 
			/// </summary>
			public AttributeData GetPropertyValuesStringAttributeData() { 
				return GetAttributeData("COL8855781933"); 
			}

			/// <summary>
			/// Gets UserId attribute data 
			/// </summary>
			public AttributeData GetUserIdAttributeData() { 
				return GetAttributeData("COL8855781931"); 
			}

			/// <summary>
			/// Gets PropertyValuesBinary attribute data 
			/// </summary>
			public AttributeData GetPropertyValuesBinaryAttributeData() { 
				return GetAttributeData("COL8855781934"); 
			}

			/// <summary>
			/// Gets LastUpdatedDate attribute data 
			/// </summary>
			public AttributeData GetLastUpdatedDateAttributeData() { 
				return GetAttributeData("COL8855781935"); 
			}

			/// <summary>
			/// Gets PropertyNames attribute data 
			/// </summary>
			public AttributeData GetPropertyNamesAttributeData() { 
				return GetAttributeData("COL8855781932"); 
			}


			/// <summary>
			/// Gets column PropertyValuesString with alias  
			/// </summary>
			public string ColPropertyValuesString { 
				get { return GetColumnName("COL8855781933"); } 
			}

			/// <summary>
			/// Gets column UserId with alias  
			/// </summary>
			public string ColUserId { 
				get { return GetColumnName("COL8855781931"); } 
			}

			/// <summary>
			/// Gets column PropertyValuesBinary with alias  
			/// </summary>
			public string ColPropertyValuesBinary { 
				get { return GetColumnName("COL8855781934"); } 
			}

			/// <summary>
			/// Gets column LastUpdatedDate with alias  
			/// </summary>
			public string ColLastUpdatedDate { 
				get { return GetColumnName("COL8855781935"); } 
			}

			/// <summary>
			/// Gets column PropertyNames with alias  
			/// </summary>
			public string ColPropertyNames { 
				get { return GetColumnName("COL8855781932"); } 
			}


			/// <summary>
			/// Checks whether column PropertyValuesString is added in select statement 
			/// </summary>
			public bool IsSelectPropertyValuesString { 
				get { return IsSelect("COL8855781933"); } 
				set { SetSelect("COL8855781933", value); } 
			}

			/// <summary>
			/// Checks whether column UserId is added in select statement 
			/// </summary>
			public bool IsSelectUserId { 
				get { return IsSelect("COL8855781931"); } 
				set { SetSelect("COL8855781931", value); } 
			}

			/// <summary>
			/// Checks whether column PropertyValuesBinary is added in select statement 
			/// </summary>
			public bool IsSelectPropertyValuesBinary { 
				get { return IsSelect("COL8855781934"); } 
				set { SetSelect("COL8855781934", value); } 
			}

			/// <summary>
			/// Checks whether column LastUpdatedDate is added in select statement 
			/// </summary>
			public bool IsSelectLastUpdatedDate { 
				get { return IsSelect("COL8855781935"); } 
				set { SetSelect("COL8855781935", value); } 
			}

			/// <summary>
			/// Checks whether column PropertyNames is added in select statement 
			/// </summary>
			public bool IsSelectPropertyNames { 
				get { return IsSelect("COL8855781932"); } 
				set { SetSelect("COL8855781932", value); } 
			}



	}
}