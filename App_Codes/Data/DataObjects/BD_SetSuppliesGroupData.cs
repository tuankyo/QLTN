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
	public class BD_SetSuppliesGroupData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ351340316";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of BD_SetSuppliesGroup 
			/// </summary>
			public BD_SetSuppliesGroupData(string objectID): base(objectID) {}  

			public BD_SetSuppliesGroupData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field Modified 
			/// </summary>
			public string Modified { 
				get { return GetValue("COL3513403167"); } 
				set { SetValue("COL3513403167", value); } 
			}

			/// <summary>
			/// Gets field CreatedBy 
			/// </summary>
			public string CreatedBy { 
				get { return GetValue("COL3513403166"); } 
				set { SetValue("COL3513403166", value); } 
			}

			/// <summary>
			/// Gets field DelFlag 
			/// </summary>
			public string DelFlag { 
				get { return GetValue("COL3513403169"); } 
				set { SetValue("COL3513403169", value); } 
			}

			/// <summary>
			/// Gets field ModifiedBy 
			/// </summary>
			public string ModifiedBy { 
				get { return GetValue("COL3513403168"); } 
				set { SetValue("COL3513403168", value); } 
			}

			/// <summary>
			/// Gets field id 
			/// </summary>
			public string id { 
				get { return GetValue("COL3513403161"); } 
				set { SetValue("COL3513403161", value); } 
			}

			/// <summary>
			/// Gets field SuppliesGroupId 
			/// </summary>
			public string SuppliesGroupId { 
				get { return GetValue("COL3513403163"); } 
				set { SetValue("COL3513403163", value); } 
			}

			/// <summary>
			/// Gets field SuppliesId 
			/// </summary>
			public string SuppliesId { 
				get { return GetValue("COL3513403162"); } 
				set { SetValue("COL3513403162", value); } 
			}

			/// <summary>
			/// Gets field Created 
			/// </summary>
			public string Created { 
				get { return GetValue("COL3513403165"); } 
				set { SetValue("COL3513403165", value); } 
			}

			/// <summary>
			/// Gets field Comment 
			/// </summary>
			public string Comment { 
				get { return GetValue("COL3513403164"); } 
				set { SetValue("COL3513403164", value); } 
			}


			/// <summary>
			/// Gets Modified attribute data 
			/// </summary>
			public AttributeData GetModifiedAttributeData() { 
				return GetAttributeData("COL3513403167"); 
			}

			/// <summary>
			/// Gets CreatedBy attribute data 
			/// </summary>
			public AttributeData GetCreatedByAttributeData() { 
				return GetAttributeData("COL3513403166"); 
			}

			/// <summary>
			/// Gets DelFlag attribute data 
			/// </summary>
			public AttributeData GetDelFlagAttributeData() { 
				return GetAttributeData("COL3513403169"); 
			}

			/// <summary>
			/// Gets ModifiedBy attribute data 
			/// </summary>
			public AttributeData GetModifiedByAttributeData() { 
				return GetAttributeData("COL3513403168"); 
			}

			/// <summary>
			/// Gets id attribute data 
			/// </summary>
			public AttributeData GetidAttributeData() { 
				return GetAttributeData("COL3513403161"); 
			}

			/// <summary>
			/// Gets SuppliesGroupId attribute data 
			/// </summary>
			public AttributeData GetSuppliesGroupIdAttributeData() { 
				return GetAttributeData("COL3513403163"); 
			}

			/// <summary>
			/// Gets SuppliesId attribute data 
			/// </summary>
			public AttributeData GetSuppliesIdAttributeData() { 
				return GetAttributeData("COL3513403162"); 
			}

			/// <summary>
			/// Gets Created attribute data 
			/// </summary>
			public AttributeData GetCreatedAttributeData() { 
				return GetAttributeData("COL3513403165"); 
			}

			/// <summary>
			/// Gets Comment attribute data 
			/// </summary>
			public AttributeData GetCommentAttributeData() { 
				return GetAttributeData("COL3513403164"); 
			}


			/// <summary>
			/// Gets column Modified with alias  
			/// </summary>
			public string ColModified { 
				get { return GetColumnName("COL3513403167"); } 
			}

			/// <summary>
			/// Gets column CreatedBy with alias  
			/// </summary>
			public string ColCreatedBy { 
				get { return GetColumnName("COL3513403166"); } 
			}

			/// <summary>
			/// Gets column DelFlag with alias  
			/// </summary>
			public string ColDelFlag { 
				get { return GetColumnName("COL3513403169"); } 
			}

			/// <summary>
			/// Gets column ModifiedBy with alias  
			/// </summary>
			public string ColModifiedBy { 
				get { return GetColumnName("COL3513403168"); } 
			}

			/// <summary>
			/// Gets column id with alias  
			/// </summary>
			public string Colid { 
				get { return GetColumnName("COL3513403161"); } 
			}

			/// <summary>
			/// Gets column SuppliesGroupId with alias  
			/// </summary>
			public string ColSuppliesGroupId { 
				get { return GetColumnName("COL3513403163"); } 
			}

			/// <summary>
			/// Gets column SuppliesId with alias  
			/// </summary>
			public string ColSuppliesId { 
				get { return GetColumnName("COL3513403162"); } 
			}

			/// <summary>
			/// Gets column Created with alias  
			/// </summary>
			public string ColCreated { 
				get { return GetColumnName("COL3513403165"); } 
			}

			/// <summary>
			/// Gets column Comment with alias  
			/// </summary>
			public string ColComment { 
				get { return GetColumnName("COL3513403164"); } 
			}


			/// <summary>
			/// Checks whether column Modified is added in select statement 
			/// </summary>
			public bool IsSelectModified { 
				get { return IsSelect("COL3513403167"); } 
				set { SetSelect("COL3513403167", value); } 
			}

			/// <summary>
			/// Checks whether column CreatedBy is added in select statement 
			/// </summary>
			public bool IsSelectCreatedBy { 
				get { return IsSelect("COL3513403166"); } 
				set { SetSelect("COL3513403166", value); } 
			}

			/// <summary>
			/// Checks whether column DelFlag is added in select statement 
			/// </summary>
			public bool IsSelectDelFlag { 
				get { return IsSelect("COL3513403169"); } 
				set { SetSelect("COL3513403169", value); } 
			}

			/// <summary>
			/// Checks whether column ModifiedBy is added in select statement 
			/// </summary>
			public bool IsSelectModifiedBy { 
				get { return IsSelect("COL3513403168"); } 
				set { SetSelect("COL3513403168", value); } 
			}

			/// <summary>
			/// Checks whether column id is added in select statement 
			/// </summary>
			public bool IsSelectid { 
				get { return IsSelect("COL3513403161"); } 
				set { SetSelect("COL3513403161", value); } 
			}

			/// <summary>
			/// Checks whether column SuppliesGroupId is added in select statement 
			/// </summary>
			public bool IsSelectSuppliesGroupId { 
				get { return IsSelect("COL3513403163"); } 
				set { SetSelect("COL3513403163", value); } 
			}

			/// <summary>
			/// Checks whether column SuppliesId is added in select statement 
			/// </summary>
			public bool IsSelectSuppliesId { 
				get { return IsSelect("COL3513403162"); } 
				set { SetSelect("COL3513403162", value); } 
			}

			/// <summary>
			/// Checks whether column Created is added in select statement 
			/// </summary>
			public bool IsSelectCreated { 
				get { return IsSelect("COL3513403165"); } 
				set { SetSelect("COL3513403165", value); } 
			}

			/// <summary>
			/// Checks whether column Comment is added in select statement 
			/// </summary>
			public bool IsSelectComment { 
				get { return IsSelect("COL3513403164"); } 
				set { SetSelect("COL3513403164", value); } 
			}



	}
}