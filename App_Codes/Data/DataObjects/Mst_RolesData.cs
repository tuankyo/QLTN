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
	public class Mst_RolesData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ66099276";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of Mst_Roles 
			/// </summary>
			public Mst_RolesData(string objectID): base(objectID) {}  

			public Mst_RolesData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field Created 
			/// </summary>
			public string Created { 
				get { return GetValue("COL660992765"); } 
				set { SetValue("COL660992765", value); } 
			}

			/// <summary>
			/// Gets field ModifiedBy 
			/// </summary>
			public string ModifiedBy { 
				get { return GetValue("COL660992768"); } 
				set { SetValue("COL660992768", value); } 
			}

			/// <summary>
			/// Gets field RoleName 
			/// </summary>
			public string RoleName { 
				get { return GetValue("COL660992763"); } 
				set { SetValue("COL660992763", value); } 
			}

			/// <summary>
			/// Gets field CreatedBy 
			/// </summary>
			public string CreatedBy { 
				get { return GetValue("COL660992766"); } 
				set { SetValue("COL660992766", value); } 
			}

			/// <summary>
			/// Gets field id 
			/// </summary>
			public string id { 
				get { return GetValue("COL660992761"); } 
				set { SetValue("COL660992761", value); } 
			}

			/// <summary>
			/// Gets field DelFlag 
			/// </summary>
			public string DelFlag { 
				get { return GetValue("COL660992769"); } 
				set { SetValue("COL660992769", value); } 
			}

			/// <summary>
			/// Gets field Comment 
			/// </summary>
			public string Comment { 
				get { return GetValue("COL660992764"); } 
				set { SetValue("COL660992764", value); } 
			}

			/// <summary>
			/// Gets field Modified 
			/// </summary>
			public string Modified { 
				get { return GetValue("COL660992767"); } 
				set { SetValue("COL660992767", value); } 
			}

			/// <summary>
			/// Gets field RoleId 
			/// </summary>
			public string RoleId { 
				get { return GetValue("COL660992762"); } 
				set { SetValue("COL660992762", value); } 
			}


			/// <summary>
			/// Gets Created attribute data 
			/// </summary>
			public AttributeData GetCreatedAttributeData() { 
				return GetAttributeData("COL660992765"); 
			}

			/// <summary>
			/// Gets ModifiedBy attribute data 
			/// </summary>
			public AttributeData GetModifiedByAttributeData() { 
				return GetAttributeData("COL660992768"); 
			}

			/// <summary>
			/// Gets RoleName attribute data 
			/// </summary>
			public AttributeData GetRoleNameAttributeData() { 
				return GetAttributeData("COL660992763"); 
			}

			/// <summary>
			/// Gets CreatedBy attribute data 
			/// </summary>
			public AttributeData GetCreatedByAttributeData() { 
				return GetAttributeData("COL660992766"); 
			}

			/// <summary>
			/// Gets id attribute data 
			/// </summary>
			public AttributeData GetidAttributeData() { 
				return GetAttributeData("COL660992761"); 
			}

			/// <summary>
			/// Gets DelFlag attribute data 
			/// </summary>
			public AttributeData GetDelFlagAttributeData() { 
				return GetAttributeData("COL660992769"); 
			}

			/// <summary>
			/// Gets Comment attribute data 
			/// </summary>
			public AttributeData GetCommentAttributeData() { 
				return GetAttributeData("COL660992764"); 
			}

			/// <summary>
			/// Gets Modified attribute data 
			/// </summary>
			public AttributeData GetModifiedAttributeData() { 
				return GetAttributeData("COL660992767"); 
			}

			/// <summary>
			/// Gets RoleId attribute data 
			/// </summary>
			public AttributeData GetRoleIdAttributeData() { 
				return GetAttributeData("COL660992762"); 
			}


			/// <summary>
			/// Gets column Created with alias  
			/// </summary>
			public string ColCreated { 
				get { return GetColumnName("COL660992765"); } 
			}

			/// <summary>
			/// Gets column ModifiedBy with alias  
			/// </summary>
			public string ColModifiedBy { 
				get { return GetColumnName("COL660992768"); } 
			}

			/// <summary>
			/// Gets column RoleName with alias  
			/// </summary>
			public string ColRoleName { 
				get { return GetColumnName("COL660992763"); } 
			}

			/// <summary>
			/// Gets column CreatedBy with alias  
			/// </summary>
			public string ColCreatedBy { 
				get { return GetColumnName("COL660992766"); } 
			}

			/// <summary>
			/// Gets column id with alias  
			/// </summary>
			public string Colid { 
				get { return GetColumnName("COL660992761"); } 
			}

			/// <summary>
			/// Gets column DelFlag with alias  
			/// </summary>
			public string ColDelFlag { 
				get { return GetColumnName("COL660992769"); } 
			}

			/// <summary>
			/// Gets column Comment with alias  
			/// </summary>
			public string ColComment { 
				get { return GetColumnName("COL660992764"); } 
			}

			/// <summary>
			/// Gets column Modified with alias  
			/// </summary>
			public string ColModified { 
				get { return GetColumnName("COL660992767"); } 
			}

			/// <summary>
			/// Gets column RoleId with alias  
			/// </summary>
			public string ColRoleId { 
				get { return GetColumnName("COL660992762"); } 
			}


			/// <summary>
			/// Checks whether column Created is added in select statement 
			/// </summary>
			public bool IsSelectCreated { 
				get { return IsSelect("COL660992765"); } 
				set { SetSelect("COL660992765", value); } 
			}

			/// <summary>
			/// Checks whether column ModifiedBy is added in select statement 
			/// </summary>
			public bool IsSelectModifiedBy { 
				get { return IsSelect("COL660992768"); } 
				set { SetSelect("COL660992768", value); } 
			}

			/// <summary>
			/// Checks whether column RoleName is added in select statement 
			/// </summary>
			public bool IsSelectRoleName { 
				get { return IsSelect("COL660992763"); } 
				set { SetSelect("COL660992763", value); } 
			}

			/// <summary>
			/// Checks whether column CreatedBy is added in select statement 
			/// </summary>
			public bool IsSelectCreatedBy { 
				get { return IsSelect("COL660992766"); } 
				set { SetSelect("COL660992766", value); } 
			}

			/// <summary>
			/// Checks whether column id is added in select statement 
			/// </summary>
			public bool IsSelectid { 
				get { return IsSelect("COL660992761"); } 
				set { SetSelect("COL660992761", value); } 
			}

			/// <summary>
			/// Checks whether column DelFlag is added in select statement 
			/// </summary>
			public bool IsSelectDelFlag { 
				get { return IsSelect("COL660992769"); } 
				set { SetSelect("COL660992769", value); } 
			}

			/// <summary>
			/// Checks whether column Comment is added in select statement 
			/// </summary>
			public bool IsSelectComment { 
				get { return IsSelect("COL660992764"); } 
				set { SetSelect("COL660992764", value); } 
			}

			/// <summary>
			/// Checks whether column Modified is added in select statement 
			/// </summary>
			public bool IsSelectModified { 
				get { return IsSelect("COL660992767"); } 
				set { SetSelect("COL660992767", value); } 
			}

			/// <summary>
			/// Checks whether column RoleId is added in select statement 
			/// </summary>
			public bool IsSelectRoleId { 
				get { return IsSelect("COL660992762"); } 
				set { SetSelect("COL660992762", value); } 
			}



	}
}