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
	public class BD_WorkingWorkedInfoData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ939866415";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of BD_WorkingWorkedInfo 
			/// </summary>
			public BD_WorkingWorkedInfoData(string objectID): base(objectID) {}  

			public BD_WorkingWorkedInfoData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field Modified 
			/// </summary>
			public string Modified { 
				get { return GetValue("COL93986641513"); } 
				set { SetValue("COL93986641513", value); } 
			}

			/// <summary>
			/// Gets field ModifiedBy 
			/// </summary>
			public string ModifiedBy { 
				get { return GetValue("COL93986641514"); } 
				set { SetValue("COL93986641514", value); } 
			}

			/// <summary>
			/// Gets field Comment 
			/// </summary>
			public string Comment { 
				get { return GetValue("COL93986641510"); } 
				set { SetValue("COL93986641510", value); } 
			}

			/// <summary>
			/// Gets field DelFlag 
			/// </summary>
			public string DelFlag { 
				get { return GetValue("COL93986641515"); } 
				set { SetValue("COL93986641515", value); } 
			}

			/// <summary>
			/// Gets field WorkingPlaceId 
			/// </summary>
			public string WorkingPlaceId { 
				get { return GetValue("COL9398664154"); } 
				set { SetValue("COL9398664154", value); } 
			}

			/// <summary>
			/// Gets field JobTypeId 
			/// </summary>
			public string JobTypeId { 
				get { return GetValue("COL9398664157"); } 
				set { SetValue("COL9398664157", value); } 
			}

			/// <summary>
			/// Gets field JobContent 
			/// </summary>
			public string JobContent { 
				get { return GetValue("COL9398664156"); } 
				set { SetValue("COL9398664156", value); } 
			}

			/// <summary>
			/// Gets field id 
			/// </summary>
			public string id { 
				get { return GetValue("COL9398664151"); } 
				set { SetValue("COL9398664151", value); } 
			}

			/// <summary>
			/// Gets field CreatedBy 
			/// </summary>
			public string CreatedBy { 
				get { return GetValue("COL93986641512"); } 
				set { SetValue("COL93986641512", value); } 
			}

			/// <summary>
			/// Gets field StaffId 
			/// </summary>
			public string StaffId { 
				get { return GetValue("COL9398664153"); } 
				set { SetValue("COL9398664153", value); } 
			}

			/// <summary>
			/// Gets field BuildingId 
			/// </summary>
			public string BuildingId { 
				get { return GetValue("COL9398664152"); } 
				set { SetValue("COL9398664152", value); } 
			}

			/// <summary>
			/// Gets field WorkingHourId 
			/// </summary>
			public string WorkingHourId { 
				get { return GetValue("COL9398664155"); } 
				set { SetValue("COL9398664155", value); } 
			}

			/// <summary>
			/// Gets field WorkingDate 
			/// </summary>
			public string WorkingDate { 
				get { return GetValue("COL9398664158"); } 
				set { SetValue("COL9398664158", value); } 
			}

			/// <summary>
			/// Gets field YearMonth 
			/// </summary>
			public string YearMonth { 
				get { return GetValue("COL9398664159"); } 
				set { SetValue("COL9398664159", value); } 
			}

			/// <summary>
			/// Gets field Created 
			/// </summary>
			public string Created { 
				get { return GetValue("COL93986641511"); } 
				set { SetValue("COL93986641511", value); } 
			}


			/// <summary>
			/// Gets Modified attribute data 
			/// </summary>
			public AttributeData GetModifiedAttributeData() { 
				return GetAttributeData("COL93986641513"); 
			}

			/// <summary>
			/// Gets ModifiedBy attribute data 
			/// </summary>
			public AttributeData GetModifiedByAttributeData() { 
				return GetAttributeData("COL93986641514"); 
			}

			/// <summary>
			/// Gets Comment attribute data 
			/// </summary>
			public AttributeData GetCommentAttributeData() { 
				return GetAttributeData("COL93986641510"); 
			}

			/// <summary>
			/// Gets DelFlag attribute data 
			/// </summary>
			public AttributeData GetDelFlagAttributeData() { 
				return GetAttributeData("COL93986641515"); 
			}

			/// <summary>
			/// Gets WorkingPlaceId attribute data 
			/// </summary>
			public AttributeData GetWorkingPlaceIdAttributeData() { 
				return GetAttributeData("COL9398664154"); 
			}

			/// <summary>
			/// Gets JobTypeId attribute data 
			/// </summary>
			public AttributeData GetJobTypeIdAttributeData() { 
				return GetAttributeData("COL9398664157"); 
			}

			/// <summary>
			/// Gets JobContent attribute data 
			/// </summary>
			public AttributeData GetJobContentAttributeData() { 
				return GetAttributeData("COL9398664156"); 
			}

			/// <summary>
			/// Gets id attribute data 
			/// </summary>
			public AttributeData GetidAttributeData() { 
				return GetAttributeData("COL9398664151"); 
			}

			/// <summary>
			/// Gets CreatedBy attribute data 
			/// </summary>
			public AttributeData GetCreatedByAttributeData() { 
				return GetAttributeData("COL93986641512"); 
			}

			/// <summary>
			/// Gets StaffId attribute data 
			/// </summary>
			public AttributeData GetStaffIdAttributeData() { 
				return GetAttributeData("COL9398664153"); 
			}

			/// <summary>
			/// Gets BuildingId attribute data 
			/// </summary>
			public AttributeData GetBuildingIdAttributeData() { 
				return GetAttributeData("COL9398664152"); 
			}

			/// <summary>
			/// Gets WorkingHourId attribute data 
			/// </summary>
			public AttributeData GetWorkingHourIdAttributeData() { 
				return GetAttributeData("COL9398664155"); 
			}

			/// <summary>
			/// Gets WorkingDate attribute data 
			/// </summary>
			public AttributeData GetWorkingDateAttributeData() { 
				return GetAttributeData("COL9398664158"); 
			}

			/// <summary>
			/// Gets YearMonth attribute data 
			/// </summary>
			public AttributeData GetYearMonthAttributeData() { 
				return GetAttributeData("COL9398664159"); 
			}

			/// <summary>
			/// Gets Created attribute data 
			/// </summary>
			public AttributeData GetCreatedAttributeData() { 
				return GetAttributeData("COL93986641511"); 
			}


			/// <summary>
			/// Gets column Modified with alias  
			/// </summary>
			public string ColModified { 
				get { return GetColumnName("COL93986641513"); } 
			}

			/// <summary>
			/// Gets column ModifiedBy with alias  
			/// </summary>
			public string ColModifiedBy { 
				get { return GetColumnName("COL93986641514"); } 
			}

			/// <summary>
			/// Gets column Comment with alias  
			/// </summary>
			public string ColComment { 
				get { return GetColumnName("COL93986641510"); } 
			}

			/// <summary>
			/// Gets column DelFlag with alias  
			/// </summary>
			public string ColDelFlag { 
				get { return GetColumnName("COL93986641515"); } 
			}

			/// <summary>
			/// Gets column WorkingPlaceId with alias  
			/// </summary>
			public string ColWorkingPlaceId { 
				get { return GetColumnName("COL9398664154"); } 
			}

			/// <summary>
			/// Gets column JobTypeId with alias  
			/// </summary>
			public string ColJobTypeId { 
				get { return GetColumnName("COL9398664157"); } 
			}

			/// <summary>
			/// Gets column JobContent with alias  
			/// </summary>
			public string ColJobContent { 
				get { return GetColumnName("COL9398664156"); } 
			}

			/// <summary>
			/// Gets column id with alias  
			/// </summary>
			public string Colid { 
				get { return GetColumnName("COL9398664151"); } 
			}

			/// <summary>
			/// Gets column CreatedBy with alias  
			/// </summary>
			public string ColCreatedBy { 
				get { return GetColumnName("COL93986641512"); } 
			}

			/// <summary>
			/// Gets column StaffId with alias  
			/// </summary>
			public string ColStaffId { 
				get { return GetColumnName("COL9398664153"); } 
			}

			/// <summary>
			/// Gets column BuildingId with alias  
			/// </summary>
			public string ColBuildingId { 
				get { return GetColumnName("COL9398664152"); } 
			}

			/// <summary>
			/// Gets column WorkingHourId with alias  
			/// </summary>
			public string ColWorkingHourId { 
				get { return GetColumnName("COL9398664155"); } 
			}

			/// <summary>
			/// Gets column WorkingDate with alias  
			/// </summary>
			public string ColWorkingDate { 
				get { return GetColumnName("COL9398664158"); } 
			}

			/// <summary>
			/// Gets column YearMonth with alias  
			/// </summary>
			public string ColYearMonth { 
				get { return GetColumnName("COL9398664159"); } 
			}

			/// <summary>
			/// Gets column Created with alias  
			/// </summary>
			public string ColCreated { 
				get { return GetColumnName("COL93986641511"); } 
			}


			/// <summary>
			/// Checks whether column Modified is added in select statement 
			/// </summary>
			public bool IsSelectModified { 
				get { return IsSelect("COL93986641513"); } 
				set { SetSelect("COL93986641513", value); } 
			}

			/// <summary>
			/// Checks whether column ModifiedBy is added in select statement 
			/// </summary>
			public bool IsSelectModifiedBy { 
				get { return IsSelect("COL93986641514"); } 
				set { SetSelect("COL93986641514", value); } 
			}

			/// <summary>
			/// Checks whether column Comment is added in select statement 
			/// </summary>
			public bool IsSelectComment { 
				get { return IsSelect("COL93986641510"); } 
				set { SetSelect("COL93986641510", value); } 
			}

			/// <summary>
			/// Checks whether column DelFlag is added in select statement 
			/// </summary>
			public bool IsSelectDelFlag { 
				get { return IsSelect("COL93986641515"); } 
				set { SetSelect("COL93986641515", value); } 
			}

			/// <summary>
			/// Checks whether column WorkingPlaceId is added in select statement 
			/// </summary>
			public bool IsSelectWorkingPlaceId { 
				get { return IsSelect("COL9398664154"); } 
				set { SetSelect("COL9398664154", value); } 
			}

			/// <summary>
			/// Checks whether column JobTypeId is added in select statement 
			/// </summary>
			public bool IsSelectJobTypeId { 
				get { return IsSelect("COL9398664157"); } 
				set { SetSelect("COL9398664157", value); } 
			}

			/// <summary>
			/// Checks whether column JobContent is added in select statement 
			/// </summary>
			public bool IsSelectJobContent { 
				get { return IsSelect("COL9398664156"); } 
				set { SetSelect("COL9398664156", value); } 
			}

			/// <summary>
			/// Checks whether column id is added in select statement 
			/// </summary>
			public bool IsSelectid { 
				get { return IsSelect("COL9398664151"); } 
				set { SetSelect("COL9398664151", value); } 
			}

			/// <summary>
			/// Checks whether column CreatedBy is added in select statement 
			/// </summary>
			public bool IsSelectCreatedBy { 
				get { return IsSelect("COL93986641512"); } 
				set { SetSelect("COL93986641512", value); } 
			}

			/// <summary>
			/// Checks whether column StaffId is added in select statement 
			/// </summary>
			public bool IsSelectStaffId { 
				get { return IsSelect("COL9398664153"); } 
				set { SetSelect("COL9398664153", value); } 
			}

			/// <summary>
			/// Checks whether column BuildingId is added in select statement 
			/// </summary>
			public bool IsSelectBuildingId { 
				get { return IsSelect("COL9398664152"); } 
				set { SetSelect("COL9398664152", value); } 
			}

			/// <summary>
			/// Checks whether column WorkingHourId is added in select statement 
			/// </summary>
			public bool IsSelectWorkingHourId { 
				get { return IsSelect("COL9398664155"); } 
				set { SetSelect("COL9398664155", value); } 
			}

			/// <summary>
			/// Checks whether column WorkingDate is added in select statement 
			/// </summary>
			public bool IsSelectWorkingDate { 
				get { return IsSelect("COL9398664158"); } 
				set { SetSelect("COL9398664158", value); } 
			}

			/// <summary>
			/// Checks whether column YearMonth is added in select statement 
			/// </summary>
			public bool IsSelectYearMonth { 
				get { return IsSelect("COL9398664159"); } 
				set { SetSelect("COL9398664159", value); } 
			}

			/// <summary>
			/// Checks whether column Created is added in select statement 
			/// </summary>
			public bool IsSelectCreated { 
				get { return IsSelect("COL93986641511"); } 
				set { SetSelect("COL93986641511", value); } 
			}



	}
}