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
	public class aspnet_RolesData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ1077578877";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of aspnet_Roles 
			/// </summary>
			public aspnet_RolesData(string objectID): base(objectID) {}  

			public aspnet_RolesData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field Description 
			/// </summary>
			public string Description { 
				get { return GetValue("COL10775788775"); } 
				set { SetValue("COL10775788775", value); } 
			}

			/// <summary>
			/// Gets field RoleId 
			/// </summary>
			public string RoleId { 
				get { return GetValue("COL10775788772"); } 
				set { SetValue("COL10775788772", value); } 
			}

			/// <summary>
			/// Gets field RoleName 
			/// </summary>
			public string RoleName { 
				get { return GetValue("COL10775788773"); } 
				set { SetValue("COL10775788773", value); } 
			}

			/// <summary>
			/// Gets field ApplicationId 
			/// </summary>
			public string ApplicationId { 
				get { return GetValue("COL10775788771"); } 
				set { SetValue("COL10775788771", value); } 
			}

			/// <summary>
			/// Gets field LoweredRoleName 
			/// </summary>
			public string LoweredRoleName { 
				get { return GetValue("COL10775788774"); } 
				set { SetValue("COL10775788774", value); } 
			}


			/// <summary>
			/// Gets Description attribute data 
			/// </summary>
			public AttributeData GetDescriptionAttributeData() { 
				return GetAttributeData("COL10775788775"); 
			}

			/// <summary>
			/// Gets RoleId attribute data 
			/// </summary>
			public AttributeData GetRoleIdAttributeData() { 
				return GetAttributeData("COL10775788772"); 
			}

			/// <summary>
			/// Gets RoleName attribute data 
			/// </summary>
			public AttributeData GetRoleNameAttributeData() { 
				return GetAttributeData("COL10775788773"); 
			}

			/// <summary>
			/// Gets ApplicationId attribute data 
			/// </summary>
			public AttributeData GetApplicationIdAttributeData() { 
				return GetAttributeData("COL10775788771"); 
			}

			/// <summary>
			/// Gets LoweredRoleName attribute data 
			/// </summary>
			public AttributeData GetLoweredRoleNameAttributeData() { 
				return GetAttributeData("COL10775788774"); 
			}


			/// <summary>
			/// Gets column Description with alias  
			/// </summary>
			public string ColDescription { 
				get { return GetColumnName("COL10775788775"); } 
			}

			/// <summary>
			/// Gets column RoleId with alias  
			/// </summary>
			public string ColRoleId { 
				get { return GetColumnName("COL10775788772"); } 
			}

			/// <summary>
			/// Gets column RoleName with alias  
			/// </summary>
			public string ColRoleName { 
				get { return GetColumnName("COL10775788773"); } 
			}

			/// <summary>
			/// Gets column ApplicationId with alias  
			/// </summary>
			public string ColApplicationId { 
				get { return GetColumnName("COL10775788771"); } 
			}

			/// <summary>
			/// Gets column LoweredRoleName with alias  
			/// </summary>
			public string ColLoweredRoleName { 
				get { return GetColumnName("COL10775788774"); } 
			}


			/// <summary>
			/// Checks whether column Description is added in select statement 
			/// </summary>
			public bool IsSelectDescription { 
				get { return IsSelect("COL10775788775"); } 
				set { SetSelect("COL10775788775", value); } 
			}

			/// <summary>
			/// Checks whether column RoleId is added in select statement 
			/// </summary>
			public bool IsSelectRoleId { 
				get { return IsSelect("COL10775788772"); } 
				set { SetSelect("COL10775788772", value); } 
			}

			/// <summary>
			/// Checks whether column RoleName is added in select statement 
			/// </summary>
			public bool IsSelectRoleName { 
				get { return IsSelect("COL10775788773"); } 
				set { SetSelect("COL10775788773", value); } 
			}

			/// <summary>
			/// Checks whether column ApplicationId is added in select statement 
			/// </summary>
			public bool IsSelectApplicationId { 
				get { return IsSelect("COL10775788771"); } 
				set { SetSelect("COL10775788771", value); } 
			}

			/// <summary>
			/// Checks whether column LoweredRoleName is added in select statement 
			/// </summary>
			public bool IsSelectLoweredRoleName { 
				get { return IsSelect("COL10775788774"); } 
				set { SetSelect("COL10775788774", value); } 
			}



	}
}