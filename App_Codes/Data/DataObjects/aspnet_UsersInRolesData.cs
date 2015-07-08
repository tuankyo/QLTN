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
	public class aspnet_UsersInRolesData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ1173579219";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of aspnet_UsersInRoles 
			/// </summary>
			public aspnet_UsersInRolesData(string objectID): base(objectID) {}  

			public aspnet_UsersInRolesData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field UserId 
			/// </summary>
			public string UserId { 
				get { return GetValue("COL11735792191"); } 
				set { SetValue("COL11735792191", value); } 
			}

			/// <summary>
			/// Gets field RoleId 
			/// </summary>
			public string RoleId { 
				get { return GetValue("COL11735792192"); } 
				set { SetValue("COL11735792192", value); } 
			}


			/// <summary>
			/// Gets UserId attribute data 
			/// </summary>
			public AttributeData GetUserIdAttributeData() { 
				return GetAttributeData("COL11735792191"); 
			}

			/// <summary>
			/// Gets RoleId attribute data 
			/// </summary>
			public AttributeData GetRoleIdAttributeData() { 
				return GetAttributeData("COL11735792192"); 
			}


			/// <summary>
			/// Gets column UserId with alias  
			/// </summary>
			public string ColUserId { 
				get { return GetColumnName("COL11735792191"); } 
			}

			/// <summary>
			/// Gets column RoleId with alias  
			/// </summary>
			public string ColRoleId { 
				get { return GetColumnName("COL11735792192"); } 
			}


			/// <summary>
			/// Checks whether column UserId is added in select statement 
			/// </summary>
			public bool IsSelectUserId { 
				get { return IsSelect("COL11735792191"); } 
				set { SetSelect("COL11735792191", value); } 
			}

			/// <summary>
			/// Checks whether column RoleId is added in select statement 
			/// </summary>
			public bool IsSelectRoleId { 
				get { return IsSelect("COL11735792192"); } 
				set { SetSelect("COL11735792192", value); } 
			}



	}
}