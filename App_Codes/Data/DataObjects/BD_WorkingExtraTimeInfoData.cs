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
	public class BD_WorkingExtraTimeInfoData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ984390576";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of BD_WorkingExtraTimeInfo 
			/// </summary>
			public BD_WorkingExtraTimeInfoData(string objectID): base(objectID) {}  

			public BD_WorkingExtraTimeInfoData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field ModifiedBy 
			/// </summary>
			public string ModifiedBy { 
				get { return GetValue("COL98439057617"); } 
				set { SetValue("COL98439057617", value); } 
			}

			/// <summary>
			/// Gets field Created 
			/// </summary>
			public string Created { 
				get { return GetValue("COL98439057614"); } 
				set { SetValue("COL98439057614", value); } 
			}

			/// <summary>
			/// Gets field WorkingMinuteTo 
			/// </summary>
			public string WorkingMinuteTo { 
				get { return GetValue("COL98439057611"); } 
				set { SetValue("COL98439057611", value); } 
			}

			/// <summary>
			/// Gets field JobContent 
			/// </summary>
			public string JobContent { 
				get { return GetValue("COL9843905766"); } 
				set { SetValue("COL9843905766", value); } 
			}

			/// <summary>
			/// Gets field WorkingDate 
			/// </summary>
			public string WorkingDate { 
				get { return GetValue("COL9843905767"); } 
				set { SetValue("COL9843905767", value); } 
			}

			/// <summary>
			/// Gets field Modified 
			/// </summary>
			public string Modified { 
				get { return GetValue("COL98439057616"); } 
				set { SetValue("COL98439057616", value); } 
			}

			/// <summary>
			/// Gets field WorkingHour 
			/// </summary>
			public string WorkingHour { 
				get { return GetValue("COL9843905765"); } 
				set { SetValue("COL9843905765", value); } 
			}

			/// <summary>
			/// Gets field BuildingId 
			/// </summary>
			public string BuildingId { 
				get { return GetValue("COL9843905762"); } 
				set { SetValue("COL9843905762", value); } 
			}

			/// <summary>
			/// Gets field StaffId 
			/// </summary>
			public string StaffId { 
				get { return GetValue("COL9843905763"); } 
				set { SetValue("COL9843905763", value); } 
			}

			/// <summary>
			/// Gets field Comment 
			/// </summary>
			public string Comment { 
				get { return GetValue("COL98439057613"); } 
				set { SetValue("COL98439057613", value); } 
			}

			/// <summary>
			/// Gets field id 
			/// </summary>
			public string id { 
				get { return GetValue("COL9843905761"); } 
				set { SetValue("COL9843905761", value); } 
			}

			/// <summary>
			/// Gets field DelFlag 
			/// </summary>
			public string DelFlag { 
				get { return GetValue("COL98439057618"); } 
				set { SetValue("COL98439057618", value); } 
			}

			/// <summary>
			/// Gets field WorkingMinuteFrom 
			/// </summary>
			public string WorkingMinuteFrom { 
				get { return GetValue("COL98439057610"); } 
				set { SetValue("COL98439057610", value); } 
			}

			/// <summary>
			/// Gets field WorkingHourFrom 
			/// </summary>
			public string WorkingHourFrom { 
				get { return GetValue("COL9843905768"); } 
				set { SetValue("COL9843905768", value); } 
			}

			/// <summary>
			/// Gets field WorkingHourTo 
			/// </summary>
			public string WorkingHourTo { 
				get { return GetValue("COL9843905769"); } 
				set { SetValue("COL9843905769", value); } 
			}

			/// <summary>
			/// Gets field WorkingPlace 
			/// </summary>
			public string WorkingPlace { 
				get { return GetValue("COL9843905764"); } 
				set { SetValue("COL9843905764", value); } 
			}

			/// <summary>
			/// Gets field CreatedBy 
			/// </summary>
			public string CreatedBy { 
				get { return GetValue("COL98439057615"); } 
				set { SetValue("COL98439057615", value); } 
			}

			/// <summary>
			/// Gets field ExtraHour 
			/// </summary>
			public string ExtraHour { 
				get { return GetValue("COL98439057612"); } 
				set { SetValue("COL98439057612", value); } 
			}


			/// <summary>
			/// Gets ModifiedBy attribute data 
			/// </summary>
			public AttributeData GetModifiedByAttributeData() { 
				return GetAttributeData("COL98439057617"); 
			}

			/// <summary>
			/// Gets Created attribute data 
			/// </summary>
			public AttributeData GetCreatedAttributeData() { 
				return GetAttributeData("COL98439057614"); 
			}

			/// <summary>
			/// Gets WorkingMinuteTo attribute data 
			/// </summary>
			public AttributeData GetWorkingMinuteToAttributeData() { 
				return GetAttributeData("COL98439057611"); 
			}

			/// <summary>
			/// Gets JobContent attribute data 
			/// </summary>
			public AttributeData GetJobContentAttributeData() { 
				return GetAttributeData("COL9843905766"); 
			}

			/// <summary>
			/// Gets WorkingDate attribute data 
			/// </summary>
			public AttributeData GetWorkingDateAttributeData() { 
				return GetAttributeData("COL9843905767"); 
			}

			/// <summary>
			/// Gets Modified attribute data 
			/// </summary>
			public AttributeData GetModifiedAttributeData() { 
				return GetAttributeData("COL98439057616"); 
			}

			/// <summary>
			/// Gets WorkingHour attribute data 
			/// </summary>
			public AttributeData GetWorkingHourAttributeData() { 
				return GetAttributeData("COL9843905765"); 
			}

			/// <summary>
			/// Gets BuildingId attribute data 
			/// </summary>
			public AttributeData GetBuildingIdAttributeData() { 
				return GetAttributeData("COL9843905762"); 
			}

			/// <summary>
			/// Gets StaffId attribute data 
			/// </summary>
			public AttributeData GetStaffIdAttributeData() { 
				return GetAttributeData("COL9843905763"); 
			}

			/// <summary>
			/// Gets Comment attribute data 
			/// </summary>
			public AttributeData GetCommentAttributeData() { 
				return GetAttributeData("COL98439057613"); 
			}

			/// <summary>
			/// Gets id attribute data 
			/// </summary>
			public AttributeData GetidAttributeData() { 
				return GetAttributeData("COL9843905761"); 
			}

			/// <summary>
			/// Gets DelFlag attribute data 
			/// </summary>
			public AttributeData GetDelFlagAttributeData() { 
				return GetAttributeData("COL98439057618"); 
			}

			/// <summary>
			/// Gets WorkingMinuteFrom attribute data 
			/// </summary>
			public AttributeData GetWorkingMinuteFromAttributeData() { 
				return GetAttributeData("COL98439057610"); 
			}

			/// <summary>
			/// Gets WorkingHourFrom attribute data 
			/// </summary>
			public AttributeData GetWorkingHourFromAttributeData() { 
				return GetAttributeData("COL9843905768"); 
			}

			/// <summary>
			/// Gets WorkingHourTo attribute data 
			/// </summary>
			public AttributeData GetWorkingHourToAttributeData() { 
				return GetAttributeData("COL9843905769"); 
			}

			/// <summary>
			/// Gets WorkingPlace attribute data 
			/// </summary>
			public AttributeData GetWorkingPlaceAttributeData() { 
				return GetAttributeData("COL9843905764"); 
			}

			/// <summary>
			/// Gets CreatedBy attribute data 
			/// </summary>
			public AttributeData GetCreatedByAttributeData() { 
				return GetAttributeData("COL98439057615"); 
			}

			/// <summary>
			/// Gets ExtraHour attribute data 
			/// </summary>
			public AttributeData GetExtraHourAttributeData() { 
				return GetAttributeData("COL98439057612"); 
			}


			/// <summary>
			/// Gets column ModifiedBy with alias  
			/// </summary>
			public string ColModifiedBy { 
				get { return GetColumnName("COL98439057617"); } 
			}

			/// <summary>
			/// Gets column Created with alias  
			/// </summary>
			public string ColCreated { 
				get { return GetColumnName("COL98439057614"); } 
			}

			/// <summary>
			/// Gets column WorkingMinuteTo with alias  
			/// </summary>
			public string ColWorkingMinuteTo { 
				get { return GetColumnName("COL98439057611"); } 
			}

			/// <summary>
			/// Gets column JobContent with alias  
			/// </summary>
			public string ColJobContent { 
				get { return GetColumnName("COL9843905766"); } 
			}

			/// <summary>
			/// Gets column WorkingDate with alias  
			/// </summary>
			public string ColWorkingDate { 
				get { return GetColumnName("COL9843905767"); } 
			}

			/// <summary>
			/// Gets column Modified with alias  
			/// </summary>
			public string ColModified { 
				get { return GetColumnName("COL98439057616"); } 
			}

			/// <summary>
			/// Gets column WorkingHour with alias  
			/// </summary>
			public string ColWorkingHour { 
				get { return GetColumnName("COL9843905765"); } 
			}

			/// <summary>
			/// Gets column BuildingId with alias  
			/// </summary>
			public string ColBuildingId { 
				get { return GetColumnName("COL9843905762"); } 
			}

			/// <summary>
			/// Gets column StaffId with alias  
			/// </summary>
			public string ColStaffId { 
				get { return GetColumnName("COL9843905763"); } 
			}

			/// <summary>
			/// Gets column Comment with alias  
			/// </summary>
			public string ColComment { 
				get { return GetColumnName("COL98439057613"); } 
			}

			/// <summary>
			/// Gets column id with alias  
			/// </summary>
			public string Colid { 
				get { return GetColumnName("COL9843905761"); } 
			}

			/// <summary>
			/// Gets column DelFlag with alias  
			/// </summary>
			public string ColDelFlag { 
				get { return GetColumnName("COL98439057618"); } 
			}

			/// <summary>
			/// Gets column WorkingMinuteFrom with alias  
			/// </summary>
			public string ColWorkingMinuteFrom { 
				get { return GetColumnName("COL98439057610"); } 
			}

			/// <summary>
			/// Gets column WorkingHourFrom with alias  
			/// </summary>
			public string ColWorkingHourFrom { 
				get { return GetColumnName("COL9843905768"); } 
			}

			/// <summary>
			/// Gets column WorkingHourTo with alias  
			/// </summary>
			public string ColWorkingHourTo { 
				get { return GetColumnName("COL9843905769"); } 
			}

			/// <summary>
			/// Gets column WorkingPlace with alias  
			/// </summary>
			public string ColWorkingPlace { 
				get { return GetColumnName("COL9843905764"); } 
			}

			/// <summary>
			/// Gets column CreatedBy with alias  
			/// </summary>
			public string ColCreatedBy { 
				get { return GetColumnName("COL98439057615"); } 
			}

			/// <summary>
			/// Gets column ExtraHour with alias  
			/// </summary>
			public string ColExtraHour { 
				get { return GetColumnName("COL98439057612"); } 
			}


			/// <summary>
			/// Checks whether column ModifiedBy is added in select statement 
			/// </summary>
			public bool IsSelectModifiedBy { 
				get { return IsSelect("COL98439057617"); } 
				set { SetSelect("COL98439057617", value); } 
			}

			/// <summary>
			/// Checks whether column Created is added in select statement 
			/// </summary>
			public bool IsSelectCreated { 
				get { return IsSelect("COL98439057614"); } 
				set { SetSelect("COL98439057614", value); } 
			}

			/// <summary>
			/// Checks whether column WorkingMinuteTo is added in select statement 
			/// </summary>
			public bool IsSelectWorkingMinuteTo { 
				get { return IsSelect("COL98439057611"); } 
				set { SetSelect("COL98439057611", value); } 
			}

			/// <summary>
			/// Checks whether column JobContent is added in select statement 
			/// </summary>
			public bool IsSelectJobContent { 
				get { return IsSelect("COL9843905766"); } 
				set { SetSelect("COL9843905766", value); } 
			}

			/// <summary>
			/// Checks whether column WorkingDate is added in select statement 
			/// </summary>
			public bool IsSelectWorkingDate { 
				get { return IsSelect("COL9843905767"); } 
				set { SetSelect("COL9843905767", value); } 
			}

			/// <summary>
			/// Checks whether column Modified is added in select statement 
			/// </summary>
			public bool IsSelectModified { 
				get { return IsSelect("COL98439057616"); } 
				set { SetSelect("COL98439057616", value); } 
			}

			/// <summary>
			/// Checks whether column WorkingHour is added in select statement 
			/// </summary>
			public bool IsSelectWorkingHour { 
				get { return IsSelect("COL9843905765"); } 
				set { SetSelect("COL9843905765", value); } 
			}

			/// <summary>
			/// Checks whether column BuildingId is added in select statement 
			/// </summary>
			public bool IsSelectBuildingId { 
				get { return IsSelect("COL9843905762"); } 
				set { SetSelect("COL9843905762", value); } 
			}

			/// <summary>
			/// Checks whether column StaffId is added in select statement 
			/// </summary>
			public bool IsSelectStaffId { 
				get { return IsSelect("COL9843905763"); } 
				set { SetSelect("COL9843905763", value); } 
			}

			/// <summary>
			/// Checks whether column Comment is added in select statement 
			/// </summary>
			public bool IsSelectComment { 
				get { return IsSelect("COL98439057613"); } 
				set { SetSelect("COL98439057613", value); } 
			}

			/// <summary>
			/// Checks whether column id is added in select statement 
			/// </summary>
			public bool IsSelectid { 
				get { return IsSelect("COL9843905761"); } 
				set { SetSelect("COL9843905761", value); } 
			}

			/// <summary>
			/// Checks whether column DelFlag is added in select statement 
			/// </summary>
			public bool IsSelectDelFlag { 
				get { return IsSelect("COL98439057618"); } 
				set { SetSelect("COL98439057618", value); } 
			}

			/// <summary>
			/// Checks whether column WorkingMinuteFrom is added in select statement 
			/// </summary>
			public bool IsSelectWorkingMinuteFrom { 
				get { return IsSelect("COL98439057610"); } 
				set { SetSelect("COL98439057610", value); } 
			}

			/// <summary>
			/// Checks whether column WorkingHourFrom is added in select statement 
			/// </summary>
			public bool IsSelectWorkingHourFrom { 
				get { return IsSelect("COL9843905768"); } 
				set { SetSelect("COL9843905768", value); } 
			}

			/// <summary>
			/// Checks whether column WorkingHourTo is added in select statement 
			/// </summary>
			public bool IsSelectWorkingHourTo { 
				get { return IsSelect("COL9843905769"); } 
				set { SetSelect("COL9843905769", value); } 
			}

			/// <summary>
			/// Checks whether column WorkingPlace is added in select statement 
			/// </summary>
			public bool IsSelectWorkingPlace { 
				get { return IsSelect("COL9843905764"); } 
				set { SetSelect("COL9843905764", value); } 
			}

			/// <summary>
			/// Checks whether column CreatedBy is added in select statement 
			/// </summary>
			public bool IsSelectCreatedBy { 
				get { return IsSelect("COL98439057615"); } 
				set { SetSelect("COL98439057615", value); } 
			}

			/// <summary>
			/// Checks whether column ExtraHour is added in select statement 
			/// </summary>
			public bool IsSelectExtraHour { 
				get { return IsSelect("COL98439057612"); } 
				set { SetSelect("COL98439057612", value); } 
			}



	}
}