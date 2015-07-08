// ==========================================
//  Author : GNT Data Object Generator Tool
//  Created   : 2014-10-21 15:25:20
//  Copyright GNT INC.  All rights reserved.
// ==========================================
using System;
using System.Collections;
using Gnt.Data.Meta;
using Gnt.Data;

namespace BusinessObjects
{

	[Serializable]
	public class aspnet_UsersData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ165575628";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of aspnet_Users 
			/// </summary>
			public aspnet_UsersData(string objectID): base(objectID) {}  

			public aspnet_UsersData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field ApplicationId 
			/// </summary>
			public string ApplicationId { 
				get { return GetValue("COL1655756281"); } 
				set { SetValue("COL1655756281", value); } 
			}

			/// <summary>
			/// Gets field LastActivityDate 
			/// </summary>
			public string LastActivityDate { 
				get { return GetValue("COL1655756287"); } 
				set { SetValue("COL1655756287", value); } 
			}

			/// <summary>
			/// Gets field IsAnonymous 
			/// </summary>
			public string IsAnonymous { 
				get { return GetValue("COL1655756286"); } 
				set { SetValue("COL1655756286", value); } 
			}

			/// <summary>
			/// Gets field MobileAlias 
			/// </summary>
			public string MobileAlias { 
				get { return GetValue("COL1655756285"); } 
				set { SetValue("COL1655756285", value); } 
			}

			/// <summary>
			/// Gets field LoweredUserName 
			/// </summary>
			public string LoweredUserName { 
				get { return GetValue("COL1655756284"); } 
				set { SetValue("COL1655756284", value); } 
			}

			/// <summary>
			/// Gets field UserName 
			/// </summary>
			public string UserName { 
				get { return GetValue("COL1655756283"); } 
				set { SetValue("COL1655756283", value); } 
			}

			/// <summary>
			/// Gets field UserId 
			/// </summary>
			public string UserId { 
				get { return GetValue("COL1655756282"); } 
				set { SetValue("COL1655756282", value); } 
			}


			/// <summary>
			/// Gets ApplicationId attribute data 
			/// </summary>
			public AttributeData GetApplicationIdAttributeData() { 
				return GetAttributeData("COL1655756281"); 
			}

			/// <summary>
			/// Gets LastActivityDate attribute data 
			/// </summary>
			public AttributeData GetLastActivityDateAttributeData() { 
				return GetAttributeData("COL1655756287"); 
			}

			/// <summary>
			/// Gets IsAnonymous attribute data 
			/// </summary>
			public AttributeData GetIsAnonymousAttributeData() { 
				return GetAttributeData("COL1655756286"); 
			}

			/// <summary>
			/// Gets MobileAlias attribute data 
			/// </summary>
			public AttributeData GetMobileAliasAttributeData() { 
				return GetAttributeData("COL1655756285"); 
			}

			/// <summary>
			/// Gets LoweredUserName attribute data 
			/// </summary>
			public AttributeData GetLoweredUserNameAttributeData() { 
				return GetAttributeData("COL1655756284"); 
			}

			/// <summary>
			/// Gets UserName attribute data 
			/// </summary>
			public AttributeData GetUserNameAttributeData() { 
				return GetAttributeData("COL1655756283"); 
			}

			/// <summary>
			/// Gets UserId attribute data 
			/// </summary>
			public AttributeData GetUserIdAttributeData() { 
				return GetAttributeData("COL1655756282"); 
			}


			/// <summary>
			/// Gets column ApplicationId with alias  
			/// </summary>
			public string ColApplicationId { 
				get { return GetColumnName("COL1655756281"); } 
			}

			/// <summary>
			/// Gets column LastActivityDate with alias  
			/// </summary>
			public string ColLastActivityDate { 
				get { return GetColumnName("COL1655756287"); } 
			}

			/// <summary>
			/// Gets column IsAnonymous with alias  
			/// </summary>
			public string ColIsAnonymous { 
				get { return GetColumnName("COL1655756286"); } 
			}

			/// <summary>
			/// Gets column MobileAlias with alias  
			/// </summary>
			public string ColMobileAlias { 
				get { return GetColumnName("COL1655756285"); } 
			}

			/// <summary>
			/// Gets column LoweredUserName with alias  
			/// </summary>
			public string ColLoweredUserName { 
				get { return GetColumnName("COL1655756284"); } 
			}

			/// <summary>
			/// Gets column UserName with alias  
			/// </summary>
			public string ColUserName { 
				get { return GetColumnName("COL1655756283"); } 
			}

			/// <summary>
			/// Gets column UserId with alias  
			/// </summary>
			public string ColUserId { 
				get { return GetColumnName("COL1655756282"); } 
			}


			/// <summary>
			/// Checks whether column ApplicationId is added in select statement 
			/// </summary>
			public bool IsSelectApplicationId { 
				get { return IsSelect("COL1655756281"); } 
				set { SetSelect("COL1655756281", value); } 
			}

			/// <summary>
			/// Checks whether column LastActivityDate is added in select statement 
			/// </summary>
			public bool IsSelectLastActivityDate { 
				get { return IsSelect("COL1655756287"); } 
				set { SetSelect("COL1655756287", value); } 
			}

			/// <summary>
			/// Checks whether column IsAnonymous is added in select statement 
			/// </summary>
			public bool IsSelectIsAnonymous { 
				get { return IsSelect("COL1655756286"); } 
				set { SetSelect("COL1655756286", value); } 
			}

			/// <summary>
			/// Checks whether column MobileAlias is added in select statement 
			/// </summary>
			public bool IsSelectMobileAlias { 
				get { return IsSelect("COL1655756285"); } 
				set { SetSelect("COL1655756285", value); } 
			}

			/// <summary>
			/// Checks whether column LoweredUserName is added in select statement 
			/// </summary>
			public bool IsSelectLoweredUserName { 
				get { return IsSelect("COL1655756284"); } 
				set { SetSelect("COL1655756284", value); } 
			}

			/// <summary>
			/// Checks whether column UserName is added in select statement 
			/// </summary>
			public bool IsSelectUserName { 
				get { return IsSelect("COL1655756283"); } 
				set { SetSelect("COL1655756283", value); } 
			}

			/// <summary>
			/// Checks whether column UserId is added in select statement 
			/// </summary>
			public bool IsSelectUserId { 
				get { return IsSelect("COL1655756282"); } 
				set { SetSelect("COL1655756282", value); } 
			}



	}
}