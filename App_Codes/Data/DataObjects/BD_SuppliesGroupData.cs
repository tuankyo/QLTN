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
	public class BD_SuppliesGroupData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ319340202";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of BD_SuppliesGroup 
			/// </summary>
			public BD_SuppliesGroupData(string objectID): base(objectID) {}  

			public BD_SuppliesGroupData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field GroupName 
			/// </summary>
			public string GroupName { 
				get { return GetValue("COL3193402022"); } 
				set { SetValue("COL3193402022", value); } 
			}

			/// <summary>
			/// Gets field RefId 
			/// </summary>
			public string RefId { 
				get { return GetValue("COL3193402025"); } 
				set { SetValue("COL3193402025", value); } 
			}

			/// <summary>
			/// Gets field BuildingId 
			/// </summary>
			public string BuildingId { 
				get { return GetValue("COL3193402024"); } 
				set { SetValue("COL3193402024", value); } 
			}

			/// <summary>
			/// Gets field id 
			/// </summary>
			public string id { 
				get { return GetValue("COL3193402021"); } 
				set { SetValue("COL3193402021", value); } 
			}

			/// <summary>
			/// Gets field SuppliesType 
			/// </summary>
			public string SuppliesType { 
				get { return GetValue("COL3193402023"); } 
				set { SetValue("COL3193402023", value); } 
			}


			/// <summary>
			/// Gets GroupName attribute data 
			/// </summary>
			public AttributeData GetGroupNameAttributeData() { 
				return GetAttributeData("COL3193402022"); 
			}

			/// <summary>
			/// Gets RefId attribute data 
			/// </summary>
			public AttributeData GetRefIdAttributeData() { 
				return GetAttributeData("COL3193402025"); 
			}

			/// <summary>
			/// Gets BuildingId attribute data 
			/// </summary>
			public AttributeData GetBuildingIdAttributeData() { 
				return GetAttributeData("COL3193402024"); 
			}

			/// <summary>
			/// Gets id attribute data 
			/// </summary>
			public AttributeData GetidAttributeData() { 
				return GetAttributeData("COL3193402021"); 
			}

			/// <summary>
			/// Gets SuppliesType attribute data 
			/// </summary>
			public AttributeData GetSuppliesTypeAttributeData() { 
				return GetAttributeData("COL3193402023"); 
			}


			/// <summary>
			/// Gets column GroupName with alias  
			/// </summary>
			public string ColGroupName { 
				get { return GetColumnName("COL3193402022"); } 
			}

			/// <summary>
			/// Gets column RefId with alias  
			/// </summary>
			public string ColRefId { 
				get { return GetColumnName("COL3193402025"); } 
			}

			/// <summary>
			/// Gets column BuildingId with alias  
			/// </summary>
			public string ColBuildingId { 
				get { return GetColumnName("COL3193402024"); } 
			}

			/// <summary>
			/// Gets column id with alias  
			/// </summary>
			public string Colid { 
				get { return GetColumnName("COL3193402021"); } 
			}

			/// <summary>
			/// Gets column SuppliesType with alias  
			/// </summary>
			public string ColSuppliesType { 
				get { return GetColumnName("COL3193402023"); } 
			}


			/// <summary>
			/// Checks whether column GroupName is added in select statement 
			/// </summary>
			public bool IsSelectGroupName { 
				get { return IsSelect("COL3193402022"); } 
				set { SetSelect("COL3193402022", value); } 
			}

			/// <summary>
			/// Checks whether column RefId is added in select statement 
			/// </summary>
			public bool IsSelectRefId { 
				get { return IsSelect("COL3193402025"); } 
				set { SetSelect("COL3193402025", value); } 
			}

			/// <summary>
			/// Checks whether column BuildingId is added in select statement 
			/// </summary>
			public bool IsSelectBuildingId { 
				get { return IsSelect("COL3193402024"); } 
				set { SetSelect("COL3193402024", value); } 
			}

			/// <summary>
			/// Checks whether column id is added in select statement 
			/// </summary>
			public bool IsSelectid { 
				get { return IsSelect("COL3193402021"); } 
				set { SetSelect("COL3193402021", value); } 
			}

			/// <summary>
			/// Checks whether column SuppliesType is added in select statement 
			/// </summary>
			public bool IsSelectSuppliesType { 
				get { return IsSelect("COL3193402023"); } 
				set { SetSelect("COL3193402023", value); } 
			}



	}
}