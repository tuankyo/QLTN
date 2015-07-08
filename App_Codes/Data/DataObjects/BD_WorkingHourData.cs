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
	public class BD_WorkingHourData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ546100986";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of BD_WorkingHour 
			/// </summary>
			public BD_WorkingHourData(string objectID): base(objectID) {}  

			public BD_WorkingHourData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field DelFlag 
			/// </summary>
			public string DelFlag { 
				get { return GetValue("COL5461009869"); } 
				set { SetValue("COL5461009869", value); } 
			}

			/// <summary>
			/// Gets field WorkingHourId 
			/// </summary>
			public string WorkingHourId { 
				get { return GetValue("COL5461009862"); } 
				set { SetValue("COL5461009862", value); } 
			}

			/// <summary>
			/// Gets field BuildingId 
			/// </summary>
			public string BuildingId { 
				get { return GetValue("COL5461009863"); } 
				set { SetValue("COL5461009863", value); } 
			}

			/// <summary>
			/// Gets field id 
			/// </summary>
			public string id { 
				get { return GetValue("COL5461009861"); } 
				set { SetValue("COL5461009861", value); } 
			}

			/// <summary>
			/// Gets field CreatedBy 
			/// </summary>
			public string CreatedBy { 
				get { return GetValue("COL5461009866"); } 
				set { SetValue("COL5461009866", value); } 
			}

			/// <summary>
			/// Gets field Modified 
			/// </summary>
			public string Modified { 
				get { return GetValue("COL5461009867"); } 
				set { SetValue("COL5461009867", value); } 
			}

			/// <summary>
			/// Gets field Comment 
			/// </summary>
			public string Comment { 
				get { return GetValue("COL5461009864"); } 
				set { SetValue("COL5461009864", value); } 
			}

			/// <summary>
			/// Gets field Created 
			/// </summary>
			public string Created { 
				get { return GetValue("COL5461009865"); } 
				set { SetValue("COL5461009865", value); } 
			}

			/// <summary>
			/// Gets field Name 
			/// </summary>
			public string Name { 
				get { return GetValue("COL54610098610"); } 
				set { SetValue("COL54610098610", value); } 
			}

			/// <summary>
			/// Gets field JobTypeId 
			/// </summary>
			public string JobTypeId { 
				get { return GetValue("COL54610098611"); } 
				set { SetValue("COL54610098611", value); } 
			}

			/// <summary>
			/// Gets field ModifiedBy 
			/// </summary>
			public string ModifiedBy { 
				get { return GetValue("COL5461009868"); } 
				set { SetValue("COL5461009868", value); } 
			}


			/// <summary>
			/// Gets DelFlag attribute data 
			/// </summary>
			public AttributeData GetDelFlagAttributeData() { 
				return GetAttributeData("COL5461009869"); 
			}

			/// <summary>
			/// Gets WorkingHourId attribute data 
			/// </summary>
			public AttributeData GetWorkingHourIdAttributeData() { 
				return GetAttributeData("COL5461009862"); 
			}

			/// <summary>
			/// Gets BuildingId attribute data 
			/// </summary>
			public AttributeData GetBuildingIdAttributeData() { 
				return GetAttributeData("COL5461009863"); 
			}

			/// <summary>
			/// Gets id attribute data 
			/// </summary>
			public AttributeData GetidAttributeData() { 
				return GetAttributeData("COL5461009861"); 
			}

			/// <summary>
			/// Gets CreatedBy attribute data 
			/// </summary>
			public AttributeData GetCreatedByAttributeData() { 
				return GetAttributeData("COL5461009866"); 
			}

			/// <summary>
			/// Gets Modified attribute data 
			/// </summary>
			public AttributeData GetModifiedAttributeData() { 
				return GetAttributeData("COL5461009867"); 
			}

			/// <summary>
			/// Gets Comment attribute data 
			/// </summary>
			public AttributeData GetCommentAttributeData() { 
				return GetAttributeData("COL5461009864"); 
			}

			/// <summary>
			/// Gets Created attribute data 
			/// </summary>
			public AttributeData GetCreatedAttributeData() { 
				return GetAttributeData("COL5461009865"); 
			}

			/// <summary>
			/// Gets Name attribute data 
			/// </summary>
			public AttributeData GetNameAttributeData() { 
				return GetAttributeData("COL54610098610"); 
			}

			/// <summary>
			/// Gets JobTypeId attribute data 
			/// </summary>
			public AttributeData GetJobTypeIdAttributeData() { 
				return GetAttributeData("COL54610098611"); 
			}

			/// <summary>
			/// Gets ModifiedBy attribute data 
			/// </summary>
			public AttributeData GetModifiedByAttributeData() { 
				return GetAttributeData("COL5461009868"); 
			}


			/// <summary>
			/// Gets column DelFlag with alias  
			/// </summary>
			public string ColDelFlag { 
				get { return GetColumnName("COL5461009869"); } 
			}

			/// <summary>
			/// Gets column WorkingHourId with alias  
			/// </summary>
			public string ColWorkingHourId { 
				get { return GetColumnName("COL5461009862"); } 
			}

			/// <summary>
			/// Gets column BuildingId with alias  
			/// </summary>
			public string ColBuildingId { 
				get { return GetColumnName("COL5461009863"); } 
			}

			/// <summary>
			/// Gets column id with alias  
			/// </summary>
			public string Colid { 
				get { return GetColumnName("COL5461009861"); } 
			}

			/// <summary>
			/// Gets column CreatedBy with alias  
			/// </summary>
			public string ColCreatedBy { 
				get { return GetColumnName("COL5461009866"); } 
			}

			/// <summary>
			/// Gets column Modified with alias  
			/// </summary>
			public string ColModified { 
				get { return GetColumnName("COL5461009867"); } 
			}

			/// <summary>
			/// Gets column Comment with alias  
			/// </summary>
			public string ColComment { 
				get { return GetColumnName("COL5461009864"); } 
			}

			/// <summary>
			/// Gets column Created with alias  
			/// </summary>
			public string ColCreated { 
				get { return GetColumnName("COL5461009865"); } 
			}

			/// <summary>
			/// Gets column Name with alias  
			/// </summary>
			public string ColName { 
				get { return GetColumnName("COL54610098610"); } 
			}

			/// <summary>
			/// Gets column JobTypeId with alias  
			/// </summary>
			public string ColJobTypeId { 
				get { return GetColumnName("COL54610098611"); } 
			}

			/// <summary>
			/// Gets column ModifiedBy with alias  
			/// </summary>
			public string ColModifiedBy { 
				get { return GetColumnName("COL5461009868"); } 
			}


			/// <summary>
			/// Checks whether column DelFlag is added in select statement 
			/// </summary>
			public bool IsSelectDelFlag { 
				get { return IsSelect("COL5461009869"); } 
				set { SetSelect("COL5461009869", value); } 
			}

			/// <summary>
			/// Checks whether column WorkingHourId is added in select statement 
			/// </summary>
			public bool IsSelectWorkingHourId { 
				get { return IsSelect("COL5461009862"); } 
				set { SetSelect("COL5461009862", value); } 
			}

			/// <summary>
			/// Checks whether column BuildingId is added in select statement 
			/// </summary>
			public bool IsSelectBuildingId { 
				get { return IsSelect("COL5461009863"); } 
				set { SetSelect("COL5461009863", value); } 
			}

			/// <summary>
			/// Checks whether column id is added in select statement 
			/// </summary>
			public bool IsSelectid { 
				get { return IsSelect("COL5461009861"); } 
				set { SetSelect("COL5461009861", value); } 
			}

			/// <summary>
			/// Checks whether column CreatedBy is added in select statement 
			/// </summary>
			public bool IsSelectCreatedBy { 
				get { return IsSelect("COL5461009866"); } 
				set { SetSelect("COL5461009866", value); } 
			}

			/// <summary>
			/// Checks whether column Modified is added in select statement 
			/// </summary>
			public bool IsSelectModified { 
				get { return IsSelect("COL5461009867"); } 
				set { SetSelect("COL5461009867", value); } 
			}

			/// <summary>
			/// Checks whether column Comment is added in select statement 
			/// </summary>
			public bool IsSelectComment { 
				get { return IsSelect("COL5461009864"); } 
				set { SetSelect("COL5461009864", value); } 
			}

			/// <summary>
			/// Checks whether column Created is added in select statement 
			/// </summary>
			public bool IsSelectCreated { 
				get { return IsSelect("COL5461009865"); } 
				set { SetSelect("COL5461009865", value); } 
			}

			/// <summary>
			/// Checks whether column Name is added in select statement 
			/// </summary>
			public bool IsSelectName { 
				get { return IsSelect("COL54610098610"); } 
				set { SetSelect("COL54610098610", value); } 
			}

			/// <summary>
			/// Checks whether column JobTypeId is added in select statement 
			/// </summary>
			public bool IsSelectJobTypeId { 
				get { return IsSelect("COL54610098611"); } 
				set { SetSelect("COL54610098611", value); } 
			}

			/// <summary>
			/// Checks whether column ModifiedBy is added in select statement 
			/// </summary>
			public bool IsSelectModifiedBy { 
				get { return IsSelect("COL5461009868"); } 
				set { SetSelect("COL5461009868", value); } 
			}



	}
}