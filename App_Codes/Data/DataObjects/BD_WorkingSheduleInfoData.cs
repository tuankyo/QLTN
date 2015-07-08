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
	public class BD_WorkingSheduleInfoData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ907866301";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of BD_WorkingSheduleInfo 
			/// </summary>
			public BD_WorkingSheduleInfoData(string objectID): base(objectID) {}  

			public BD_WorkingSheduleInfoData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field YearMonth 
			/// </summary>
			public string YearMonth { 
				get { return GetValue("COL9078663019"); } 
				set { SetValue("COL9078663019", value); } 
			}

			/// <summary>
			/// Gets field DelFlag 
			/// </summary>
			public string DelFlag { 
				get { return GetValue("COL90786630115"); } 
				set { SetValue("COL90786630115", value); } 
			}

			/// <summary>
			/// Gets field Comment 
			/// </summary>
			public string Comment { 
				get { return GetValue("COL90786630110"); } 
				set { SetValue("COL90786630110", value); } 
			}

			/// <summary>
			/// Gets field CreatedBy 
			/// </summary>
			public string CreatedBy { 
				get { return GetValue("COL90786630112"); } 
				set { SetValue("COL90786630112", value); } 
			}

			/// <summary>
			/// Gets field id 
			/// </summary>
			public string id { 
				get { return GetValue("COL9078663011"); } 
				set { SetValue("COL9078663011", value); } 
			}

			/// <summary>
			/// Gets field BuildingId 
			/// </summary>
			public string BuildingId { 
				get { return GetValue("COL9078663012"); } 
				set { SetValue("COL9078663012", value); } 
			}

			/// <summary>
			/// Gets field StaffId 
			/// </summary>
			public string StaffId { 
				get { return GetValue("COL9078663013"); } 
				set { SetValue("COL9078663013", value); } 
			}

			/// <summary>
			/// Gets field Created 
			/// </summary>
			public string Created { 
				get { return GetValue("COL90786630111"); } 
				set { SetValue("COL90786630111", value); } 
			}

			/// <summary>
			/// Gets field WorkingHourId 
			/// </summary>
			public string WorkingHourId { 
				get { return GetValue("COL9078663015"); } 
				set { SetValue("COL9078663015", value); } 
			}

			/// <summary>
			/// Gets field JobContent 
			/// </summary>
			public string JobContent { 
				get { return GetValue("COL9078663016"); } 
				set { SetValue("COL9078663016", value); } 
			}

			/// <summary>
			/// Gets field JobTypeId 
			/// </summary>
			public string JobTypeId { 
				get { return GetValue("COL9078663017"); } 
				set { SetValue("COL9078663017", value); } 
			}

			/// <summary>
			/// Gets field ModifiedBy 
			/// </summary>
			public string ModifiedBy { 
				get { return GetValue("COL90786630114"); } 
				set { SetValue("COL90786630114", value); } 
			}

			/// <summary>
			/// Gets field Modified 
			/// </summary>
			public string Modified { 
				get { return GetValue("COL90786630113"); } 
				set { SetValue("COL90786630113", value); } 
			}

			/// <summary>
			/// Gets field WorkingPlaceId 
			/// </summary>
			public string WorkingPlaceId { 
				get { return GetValue("COL9078663014"); } 
				set { SetValue("COL9078663014", value); } 
			}

			/// <summary>
			/// Gets field WorkingDate 
			/// </summary>
			public string WorkingDate { 
				get { return GetValue("COL9078663018"); } 
				set { SetValue("COL9078663018", value); } 
			}


			/// <summary>
			/// Gets YearMonth attribute data 
			/// </summary>
			public AttributeData GetYearMonthAttributeData() { 
				return GetAttributeData("COL9078663019"); 
			}

			/// <summary>
			/// Gets DelFlag attribute data 
			/// </summary>
			public AttributeData GetDelFlagAttributeData() { 
				return GetAttributeData("COL90786630115"); 
			}

			/// <summary>
			/// Gets Comment attribute data 
			/// </summary>
			public AttributeData GetCommentAttributeData() { 
				return GetAttributeData("COL90786630110"); 
			}

			/// <summary>
			/// Gets CreatedBy attribute data 
			/// </summary>
			public AttributeData GetCreatedByAttributeData() { 
				return GetAttributeData("COL90786630112"); 
			}

			/// <summary>
			/// Gets id attribute data 
			/// </summary>
			public AttributeData GetidAttributeData() { 
				return GetAttributeData("COL9078663011"); 
			}

			/// <summary>
			/// Gets BuildingId attribute data 
			/// </summary>
			public AttributeData GetBuildingIdAttributeData() { 
				return GetAttributeData("COL9078663012"); 
			}

			/// <summary>
			/// Gets StaffId attribute data 
			/// </summary>
			public AttributeData GetStaffIdAttributeData() { 
				return GetAttributeData("COL9078663013"); 
			}

			/// <summary>
			/// Gets Created attribute data 
			/// </summary>
			public AttributeData GetCreatedAttributeData() { 
				return GetAttributeData("COL90786630111"); 
			}

			/// <summary>
			/// Gets WorkingHourId attribute data 
			/// </summary>
			public AttributeData GetWorkingHourIdAttributeData() { 
				return GetAttributeData("COL9078663015"); 
			}

			/// <summary>
			/// Gets JobContent attribute data 
			/// </summary>
			public AttributeData GetJobContentAttributeData() { 
				return GetAttributeData("COL9078663016"); 
			}

			/// <summary>
			/// Gets JobTypeId attribute data 
			/// </summary>
			public AttributeData GetJobTypeIdAttributeData() { 
				return GetAttributeData("COL9078663017"); 
			}

			/// <summary>
			/// Gets ModifiedBy attribute data 
			/// </summary>
			public AttributeData GetModifiedByAttributeData() { 
				return GetAttributeData("COL90786630114"); 
			}

			/// <summary>
			/// Gets Modified attribute data 
			/// </summary>
			public AttributeData GetModifiedAttributeData() { 
				return GetAttributeData("COL90786630113"); 
			}

			/// <summary>
			/// Gets WorkingPlaceId attribute data 
			/// </summary>
			public AttributeData GetWorkingPlaceIdAttributeData() { 
				return GetAttributeData("COL9078663014"); 
			}

			/// <summary>
			/// Gets WorkingDate attribute data 
			/// </summary>
			public AttributeData GetWorkingDateAttributeData() { 
				return GetAttributeData("COL9078663018"); 
			}


			/// <summary>
			/// Gets column YearMonth with alias  
			/// </summary>
			public string ColYearMonth { 
				get { return GetColumnName("COL9078663019"); } 
			}

			/// <summary>
			/// Gets column DelFlag with alias  
			/// </summary>
			public string ColDelFlag { 
				get { return GetColumnName("COL90786630115"); } 
			}

			/// <summary>
			/// Gets column Comment with alias  
			/// </summary>
			public string ColComment { 
				get { return GetColumnName("COL90786630110"); } 
			}

			/// <summary>
			/// Gets column CreatedBy with alias  
			/// </summary>
			public string ColCreatedBy { 
				get { return GetColumnName("COL90786630112"); } 
			}

			/// <summary>
			/// Gets column id with alias  
			/// </summary>
			public string Colid { 
				get { return GetColumnName("COL9078663011"); } 
			}

			/// <summary>
			/// Gets column BuildingId with alias  
			/// </summary>
			public string ColBuildingId { 
				get { return GetColumnName("COL9078663012"); } 
			}

			/// <summary>
			/// Gets column StaffId with alias  
			/// </summary>
			public string ColStaffId { 
				get { return GetColumnName("COL9078663013"); } 
			}

			/// <summary>
			/// Gets column Created with alias  
			/// </summary>
			public string ColCreated { 
				get { return GetColumnName("COL90786630111"); } 
			}

			/// <summary>
			/// Gets column WorkingHourId with alias  
			/// </summary>
			public string ColWorkingHourId { 
				get { return GetColumnName("COL9078663015"); } 
			}

			/// <summary>
			/// Gets column JobContent with alias  
			/// </summary>
			public string ColJobContent { 
				get { return GetColumnName("COL9078663016"); } 
			}

			/// <summary>
			/// Gets column JobTypeId with alias  
			/// </summary>
			public string ColJobTypeId { 
				get { return GetColumnName("COL9078663017"); } 
			}

			/// <summary>
			/// Gets column ModifiedBy with alias  
			/// </summary>
			public string ColModifiedBy { 
				get { return GetColumnName("COL90786630114"); } 
			}

			/// <summary>
			/// Gets column Modified with alias  
			/// </summary>
			public string ColModified { 
				get { return GetColumnName("COL90786630113"); } 
			}

			/// <summary>
			/// Gets column WorkingPlaceId with alias  
			/// </summary>
			public string ColWorkingPlaceId { 
				get { return GetColumnName("COL9078663014"); } 
			}

			/// <summary>
			/// Gets column WorkingDate with alias  
			/// </summary>
			public string ColWorkingDate { 
				get { return GetColumnName("COL9078663018"); } 
			}


			/// <summary>
			/// Checks whether column YearMonth is added in select statement 
			/// </summary>
			public bool IsSelectYearMonth { 
				get { return IsSelect("COL9078663019"); } 
				set { SetSelect("COL9078663019", value); } 
			}

			/// <summary>
			/// Checks whether column DelFlag is added in select statement 
			/// </summary>
			public bool IsSelectDelFlag { 
				get { return IsSelect("COL90786630115"); } 
				set { SetSelect("COL90786630115", value); } 
			}

			/// <summary>
			/// Checks whether column Comment is added in select statement 
			/// </summary>
			public bool IsSelectComment { 
				get { return IsSelect("COL90786630110"); } 
				set { SetSelect("COL90786630110", value); } 
			}

			/// <summary>
			/// Checks whether column CreatedBy is added in select statement 
			/// </summary>
			public bool IsSelectCreatedBy { 
				get { return IsSelect("COL90786630112"); } 
				set { SetSelect("COL90786630112", value); } 
			}

			/// <summary>
			/// Checks whether column id is added in select statement 
			/// </summary>
			public bool IsSelectid { 
				get { return IsSelect("COL9078663011"); } 
				set { SetSelect("COL9078663011", value); } 
			}

			/// <summary>
			/// Checks whether column BuildingId is added in select statement 
			/// </summary>
			public bool IsSelectBuildingId { 
				get { return IsSelect("COL9078663012"); } 
				set { SetSelect("COL9078663012", value); } 
			}

			/// <summary>
			/// Checks whether column StaffId is added in select statement 
			/// </summary>
			public bool IsSelectStaffId { 
				get { return IsSelect("COL9078663013"); } 
				set { SetSelect("COL9078663013", value); } 
			}

			/// <summary>
			/// Checks whether column Created is added in select statement 
			/// </summary>
			public bool IsSelectCreated { 
				get { return IsSelect("COL90786630111"); } 
				set { SetSelect("COL90786630111", value); } 
			}

			/// <summary>
			/// Checks whether column WorkingHourId is added in select statement 
			/// </summary>
			public bool IsSelectWorkingHourId { 
				get { return IsSelect("COL9078663015"); } 
				set { SetSelect("COL9078663015", value); } 
			}

			/// <summary>
			/// Checks whether column JobContent is added in select statement 
			/// </summary>
			public bool IsSelectJobContent { 
				get { return IsSelect("COL9078663016"); } 
				set { SetSelect("COL9078663016", value); } 
			}

			/// <summary>
			/// Checks whether column JobTypeId is added in select statement 
			/// </summary>
			public bool IsSelectJobTypeId { 
				get { return IsSelect("COL9078663017"); } 
				set { SetSelect("COL9078663017", value); } 
			}

			/// <summary>
			/// Checks whether column ModifiedBy is added in select statement 
			/// </summary>
			public bool IsSelectModifiedBy { 
				get { return IsSelect("COL90786630114"); } 
				set { SetSelect("COL90786630114", value); } 
			}

			/// <summary>
			/// Checks whether column Modified is added in select statement 
			/// </summary>
			public bool IsSelectModified { 
				get { return IsSelect("COL90786630113"); } 
				set { SetSelect("COL90786630113", value); } 
			}

			/// <summary>
			/// Checks whether column WorkingPlaceId is added in select statement 
			/// </summary>
			public bool IsSelectWorkingPlaceId { 
				get { return IsSelect("COL9078663014"); } 
				set { SetSelect("COL9078663014", value); } 
			}

			/// <summary>
			/// Checks whether column WorkingDate is added in select statement 
			/// </summary>
			public bool IsSelectWorkingDate { 
				get { return IsSelect("COL9078663018"); } 
				set { SetSelect("COL9078663018", value); } 
			}



	}
}