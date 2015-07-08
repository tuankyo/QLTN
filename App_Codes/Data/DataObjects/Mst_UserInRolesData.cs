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
	public class Mst_UserInRolesData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ2085582468";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of Mst_UserInRoles 
			/// </summary>
			public Mst_UserInRolesData(string objectID): base(objectID) {}  

			public Mst_UserInRolesData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field ModifiedBy 
			/// </summary>
			public string ModifiedBy { 
				get { return GetValue("COL20855824688"); } 
				set { SetValue("COL20855824688", value); } 
			}

			/// <summary>
			/// Gets field RoleId 
			/// </summary>
			public string RoleId { 
				get { return GetValue("COL20855824683"); } 
				set { SetValue("COL20855824683", value); } 
			}

			/// <summary>
			/// Gets field CreatedBy 
			/// </summary>
			public string CreatedBy { 
				get { return GetValue("COL20855824686"); } 
				set { SetValue("COL20855824686", value); } 
			}

			/// <summary>
			/// Gets field id 
			/// </summary>
			public string id { 
				get { return GetValue("COL20855824681"); } 
				set { SetValue("COL20855824681", value); } 
			}

			/// <summary>
			/// Gets field DelFlag 
			/// </summary>
			public string DelFlag { 
				get { return GetValue("COL20855824689"); } 
				set { SetValue("COL20855824689", value); } 
			}

			/// <summary>
			/// Gets field Comment 
			/// </summary>
			public string Comment { 
				get { return GetValue("COL20855824684"); } 
				set { SetValue("COL20855824684", value); } 
			}

			/// <summary>
			/// Gets field Modified 
			/// </summary>
			public string Modified { 
				get { return GetValue("COL20855824687"); } 
				set { SetValue("COL20855824687", value); } 
			}

			/// <summary>
			/// Gets field UserName 
			/// </summary>
			public string UserName { 
				get { return GetValue("COL20855824682"); } 
				set { SetValue("COL20855824682", value); } 
			}

			/// <summary>
			/// Gets field Created 
			/// </summary>
			public string Created { 
				get { return GetValue("COL20855824685"); } 
				set { SetValue("COL20855824685", value); } 
			}


			/// <summary>
			/// Gets ModifiedBy attribute data 
			/// </summary>
			public AttributeData GetModifiedByAttributeData() { 
				return GetAttributeData("COL20855824688"); 
			}

			/// <summary>
			/// Gets RoleId attribute data 
			/// </summary>
			public AttributeData GetRoleIdAttributeData() { 
				return GetAttributeData("COL20855824683"); 
			}

			/// <summary>
			/// Gets CreatedBy attribute data 
			/// </summary>
			public AttributeData GetCreatedByAttributeData() { 
				return GetAttributeData("COL20855824686"); 
			}

			/// <summary>
			/// Gets id attribute data 
			/// </summary>
			public AttributeData GetidAttributeData() { 
				return GetAttributeData("COL20855824681"); 
			}

			/// <summary>
			/// Gets DelFlag attribute data 
			/// </summary>
			public AttributeData GetDelFlagAttributeData() { 
				return GetAttributeData("COL20855824689"); 
			}

			/// <summary>
			/// Gets Comment attribute data 
			/// </summary>
			public AttributeData GetCommentAttributeData() { 
				return GetAttributeData("COL20855824684"); 
			}

			/// <summary>
			/// Gets Modified attribute data 
			/// </summary>
			public AttributeData GetModifiedAttributeData() { 
				return GetAttributeData("COL20855824687"); 
			}

			/// <summary>
			/// Gets UserName attribute data 
			/// </summary>
			public AttributeData GetUserNameAttributeData() { 
				return GetAttributeData("COL20855824682"); 
			}

			/// <summary>
			/// Gets Created attribute data 
			/// </summary>
			public AttributeData GetCreatedAttributeData() { 
				return GetAttributeData("COL20855824685"); 
			}


			/// <summary>
			/// Gets column ModifiedBy with alias  
			/// </summary>
			public string ColModifiedBy { 
				get { return GetColumnName("COL20855824688"); } 
			}

			/// <summary>
			/// Gets column RoleId with alias  
			/// </summary>
			public string ColRoleId { 
				get { return GetColumnName("COL20855824683"); } 
			}

			/// <summary>
			/// Gets column CreatedBy with alias  
			/// </summary>
			public string ColCreatedBy { 
				get { return GetColumnName("COL20855824686"); } 
			}

			/// <summary>
			/// Gets column id with alias  
			/// </summary>
			public string Colid { 
				get { return GetColumnName("COL20855824681"); } 
			}

			/// <summary>
			/// Gets column DelFlag with alias  
			/// </summary>
			public string ColDelFlag { 
				get { return GetColumnName("COL20855824689"); } 
			}

			/// <summary>
			/// Gets column Comment with alias  
			/// </summary>
			public string ColComment { 
				get { return GetColumnName("COL20855824684"); } 
			}

			/// <summary>
			/// Gets column Modified with alias  
			/// </summary>
			public string ColModified { 
				get { return GetColumnName("COL20855824687"); } 
			}

			/// <summary>
			/// Gets column UserName with alias  
			/// </summary>
			public string ColUserName { 
				get { return GetColumnName("COL20855824682"); } 
			}

			/// <summary>
			/// Gets column Created with alias  
			/// </summary>
			public string ColCreated { 
				get { return GetColumnName("COL20855824685"); } 
			}


			/// <summary>
			/// Checks whether column ModifiedBy is added in select statement 
			/// </summary>
			public bool IsSelectModifiedBy { 
				get { return IsSelect("COL20855824688"); } 
				set { SetSelect("COL20855824688", value); } 
			}

			/// <summary>
			/// Checks whether column RoleId is added in select statement 
			/// </summary>
			public bool IsSelectRoleId { 
				get { return IsSelect("COL20855824683"); } 
				set { SetSelect("COL20855824683", value); } 
			}

			/// <summary>
			/// Checks whether column CreatedBy is added in select statement 
			/// </summary>
			public bool IsSelectCreatedBy { 
				get { return IsSelect("COL20855824686"); } 
				set { SetSelect("COL20855824686", value); } 
			}

			/// <summary>
			/// Checks whether column id is added in select statement 
			/// </summary>
			public bool IsSelectid { 
				get { return IsSelect("COL20855824681"); } 
				set { SetSelect("COL20855824681", value); } 
			}

			/// <summary>
			/// Checks whether column DelFlag is added in select statement 
			/// </summary>
			public bool IsSelectDelFlag { 
				get { return IsSelect("COL20855824689"); } 
				set { SetSelect("COL20855824689", value); } 
			}

			/// <summary>
			/// Checks whether column Comment is added in select statement 
			/// </summary>
			public bool IsSelectComment { 
				get { return IsSelect("COL20855824684"); } 
				set { SetSelect("COL20855824684", value); } 
			}

			/// <summary>
			/// Checks whether column Modified is added in select statement 
			/// </summary>
			public bool IsSelectModified { 
				get { return IsSelect("COL20855824687"); } 
				set { SetSelect("COL20855824687", value); } 
			}

			/// <summary>
			/// Checks whether column UserName is added in select statement 
			/// </summary>
			public bool IsSelectUserName { 
				get { return IsSelect("COL20855824682"); } 
				set { SetSelect("COL20855824682", value); } 
			}

			/// <summary>
			/// Checks whether column Created is added in select statement 
			/// </summary>
			public bool IsSelectCreated { 
				get { return IsSelect("COL20855824685"); } 
				set { SetSelect("COL20855824685", value); } 
			}



	}
}