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
	public class BD_MaintenanceData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ1659868980";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of BD_Maintenance 
			/// </summary>
			public BD_MaintenanceData(string objectID): base(objectID) {}  

			public BD_MaintenanceData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field Month 
			/// </summary>
			public string Month { 
				get { return GetValue("COL16598689804"); } 
				set { SetValue("COL16598689804", value); } 
			}

			/// <summary>
			/// Gets field ExecDate 
			/// </summary>
			public string ExecDate { 
				get { return GetValue("COL165986898011"); } 
				set { SetValue("COL165986898011", value); } 
			}

			/// <summary>
			/// Gets field CreatedBy 
			/// </summary>
			public string CreatedBy { 
				get { return GetValue("COL165986898017"); } 
				set { SetValue("COL165986898017", value); } 
			}

			/// <summary>
			/// Gets field ModifiedBy 
			/// </summary>
			public string ModifiedBy { 
				get { return GetValue("COL165986898019"); } 
				set { SetValue("COL165986898019", value); } 
			}

			/// <summary>
			/// Gets field id 
			/// </summary>
			public string id { 
				get { return GetValue("COL16598689801"); } 
				set { SetValue("COL16598689801", value); } 
			}

			/// <summary>
			/// Gets field Description 
			/// </summary>
			public string Description { 
				get { return GetValue("COL16598689809"); } 
				set { SetValue("COL16598689809", value); } 
			}

			/// <summary>
			/// Gets field MainName 
			/// </summary>
			public string MainName { 
				get { return GetValue("COL16598689806"); } 
				set { SetValue("COL16598689806", value); } 
			}

			/// <summary>
			/// Gets field Year 
			/// </summary>
			public string Year { 
				get { return GetValue("COL16598689803"); } 
				set { SetValue("COL16598689803", value); } 
			}

			/// <summary>
			/// Gets field ExecComment 
			/// </summary>
			public string ExecComment { 
				get { return GetValue("COL165986898013"); } 
				set { SetValue("COL165986898013", value); } 
			}

			/// <summary>
			/// Gets field Created 
			/// </summary>
			public string Created { 
				get { return GetValue("COL165986898016"); } 
				set { SetValue("COL165986898016", value); } 
			}

			/// <summary>
			/// Gets field Modified 
			/// </summary>
			public string Modified { 
				get { return GetValue("COL165986898018"); } 
				set { SetValue("COL165986898018", value); } 
			}

			/// <summary>
			/// Gets field IsMaintenance 
			/// </summary>
			public string IsMaintenance { 
				get { return GetValue("COL16598689808"); } 
				set { SetValue("COL16598689808", value); } 
			}

			/// <summary>
			/// Gets field Week 
			/// </summary>
			public string Week { 
				get { return GetValue("COL16598689805"); } 
				set { SetValue("COL16598689805", value); } 
			}

			/// <summary>
			/// Gets field DelFlag 
			/// </summary>
			public string DelFlag { 
				get { return GetValue("COL165986898020"); } 
				set { SetValue("COL165986898020", value); } 
			}

			/// <summary>
			/// Gets field ExecConfirmer 
			/// </summary>
			public string ExecConfirmer { 
				get { return GetValue("COL165986898015"); } 
				set { SetValue("COL165986898015", value); } 
			}

			/// <summary>
			/// Gets field BuildingId 
			/// </summary>
			public string BuildingId { 
				get { return GetValue("COL16598689802"); } 
				set { SetValue("COL16598689802", value); } 
			}

			/// <summary>
			/// Gets field SubName 
			/// </summary>
			public string SubName { 
				get { return GetValue("COL16598689807"); } 
				set { SetValue("COL16598689807", value); } 
			}

			/// <summary>
			/// Gets field ExecDescription 
			/// </summary>
			public string ExecDescription { 
				get { return GetValue("COL165986898012"); } 
				set { SetValue("COL165986898012", value); } 
			}

			/// <summary>
			/// Gets field ExecCompany 
			/// </summary>
			public string ExecCompany { 
				get { return GetValue("COL165986898014"); } 
				set { SetValue("COL165986898014", value); } 
			}

			/// <summary>
			/// Gets field Comment 
			/// </summary>
			public string Comment { 
				get { return GetValue("COL165986898010"); } 
				set { SetValue("COL165986898010", value); } 
			}


			/// <summary>
			/// Gets Month attribute data 
			/// </summary>
			public AttributeData GetMonthAttributeData() { 
				return GetAttributeData("COL16598689804"); 
			}

			/// <summary>
			/// Gets ExecDate attribute data 
			/// </summary>
			public AttributeData GetExecDateAttributeData() { 
				return GetAttributeData("COL165986898011"); 
			}

			/// <summary>
			/// Gets CreatedBy attribute data 
			/// </summary>
			public AttributeData GetCreatedByAttributeData() { 
				return GetAttributeData("COL165986898017"); 
			}

			/// <summary>
			/// Gets ModifiedBy attribute data 
			/// </summary>
			public AttributeData GetModifiedByAttributeData() { 
				return GetAttributeData("COL165986898019"); 
			}

			/// <summary>
			/// Gets id attribute data 
			/// </summary>
			public AttributeData GetidAttributeData() { 
				return GetAttributeData("COL16598689801"); 
			}

			/// <summary>
			/// Gets Description attribute data 
			/// </summary>
			public AttributeData GetDescriptionAttributeData() { 
				return GetAttributeData("COL16598689809"); 
			}

			/// <summary>
			/// Gets MainName attribute data 
			/// </summary>
			public AttributeData GetMainNameAttributeData() { 
				return GetAttributeData("COL16598689806"); 
			}

			/// <summary>
			/// Gets Year attribute data 
			/// </summary>
			public AttributeData GetYearAttributeData() { 
				return GetAttributeData("COL16598689803"); 
			}

			/// <summary>
			/// Gets ExecComment attribute data 
			/// </summary>
			public AttributeData GetExecCommentAttributeData() { 
				return GetAttributeData("COL165986898013"); 
			}

			/// <summary>
			/// Gets Created attribute data 
			/// </summary>
			public AttributeData GetCreatedAttributeData() { 
				return GetAttributeData("COL165986898016"); 
			}

			/// <summary>
			/// Gets Modified attribute data 
			/// </summary>
			public AttributeData GetModifiedAttributeData() { 
				return GetAttributeData("COL165986898018"); 
			}

			/// <summary>
			/// Gets IsMaintenance attribute data 
			/// </summary>
			public AttributeData GetIsMaintenanceAttributeData() { 
				return GetAttributeData("COL16598689808"); 
			}

			/// <summary>
			/// Gets Week attribute data 
			/// </summary>
			public AttributeData GetWeekAttributeData() { 
				return GetAttributeData("COL16598689805"); 
			}

			/// <summary>
			/// Gets DelFlag attribute data 
			/// </summary>
			public AttributeData GetDelFlagAttributeData() { 
				return GetAttributeData("COL165986898020"); 
			}

			/// <summary>
			/// Gets ExecConfirmer attribute data 
			/// </summary>
			public AttributeData GetExecConfirmerAttributeData() { 
				return GetAttributeData("COL165986898015"); 
			}

			/// <summary>
			/// Gets BuildingId attribute data 
			/// </summary>
			public AttributeData GetBuildingIdAttributeData() { 
				return GetAttributeData("COL16598689802"); 
			}

			/// <summary>
			/// Gets SubName attribute data 
			/// </summary>
			public AttributeData GetSubNameAttributeData() { 
				return GetAttributeData("COL16598689807"); 
			}

			/// <summary>
			/// Gets ExecDescription attribute data 
			/// </summary>
			public AttributeData GetExecDescriptionAttributeData() { 
				return GetAttributeData("COL165986898012"); 
			}

			/// <summary>
			/// Gets ExecCompany attribute data 
			/// </summary>
			public AttributeData GetExecCompanyAttributeData() { 
				return GetAttributeData("COL165986898014"); 
			}

			/// <summary>
			/// Gets Comment attribute data 
			/// </summary>
			public AttributeData GetCommentAttributeData() { 
				return GetAttributeData("COL165986898010"); 
			}


			/// <summary>
			/// Gets column Month with alias  
			/// </summary>
			public string ColMonth { 
				get { return GetColumnName("COL16598689804"); } 
			}

			/// <summary>
			/// Gets column ExecDate with alias  
			/// </summary>
			public string ColExecDate { 
				get { return GetColumnName("COL165986898011"); } 
			}

			/// <summary>
			/// Gets column CreatedBy with alias  
			/// </summary>
			public string ColCreatedBy { 
				get { return GetColumnName("COL165986898017"); } 
			}

			/// <summary>
			/// Gets column ModifiedBy with alias  
			/// </summary>
			public string ColModifiedBy { 
				get { return GetColumnName("COL165986898019"); } 
			}

			/// <summary>
			/// Gets column id with alias  
			/// </summary>
			public string Colid { 
				get { return GetColumnName("COL16598689801"); } 
			}

			/// <summary>
			/// Gets column Description with alias  
			/// </summary>
			public string ColDescription { 
				get { return GetColumnName("COL16598689809"); } 
			}

			/// <summary>
			/// Gets column MainName with alias  
			/// </summary>
			public string ColMainName { 
				get { return GetColumnName("COL16598689806"); } 
			}

			/// <summary>
			/// Gets column Year with alias  
			/// </summary>
			public string ColYear { 
				get { return GetColumnName("COL16598689803"); } 
			}

			/// <summary>
			/// Gets column ExecComment with alias  
			/// </summary>
			public string ColExecComment { 
				get { return GetColumnName("COL165986898013"); } 
			}

			/// <summary>
			/// Gets column Created with alias  
			/// </summary>
			public string ColCreated { 
				get { return GetColumnName("COL165986898016"); } 
			}

			/// <summary>
			/// Gets column Modified with alias  
			/// </summary>
			public string ColModified { 
				get { return GetColumnName("COL165986898018"); } 
			}

			/// <summary>
			/// Gets column IsMaintenance with alias  
			/// </summary>
			public string ColIsMaintenance { 
				get { return GetColumnName("COL16598689808"); } 
			}

			/// <summary>
			/// Gets column Week with alias  
			/// </summary>
			public string ColWeek { 
				get { return GetColumnName("COL16598689805"); } 
			}

			/// <summary>
			/// Gets column DelFlag with alias  
			/// </summary>
			public string ColDelFlag { 
				get { return GetColumnName("COL165986898020"); } 
			}

			/// <summary>
			/// Gets column ExecConfirmer with alias  
			/// </summary>
			public string ColExecConfirmer { 
				get { return GetColumnName("COL165986898015"); } 
			}

			/// <summary>
			/// Gets column BuildingId with alias  
			/// </summary>
			public string ColBuildingId { 
				get { return GetColumnName("COL16598689802"); } 
			}

			/// <summary>
			/// Gets column SubName with alias  
			/// </summary>
			public string ColSubName { 
				get { return GetColumnName("COL16598689807"); } 
			}

			/// <summary>
			/// Gets column ExecDescription with alias  
			/// </summary>
			public string ColExecDescription { 
				get { return GetColumnName("COL165986898012"); } 
			}

			/// <summary>
			/// Gets column ExecCompany with alias  
			/// </summary>
			public string ColExecCompany { 
				get { return GetColumnName("COL165986898014"); } 
			}

			/// <summary>
			/// Gets column Comment with alias  
			/// </summary>
			public string ColComment { 
				get { return GetColumnName("COL165986898010"); } 
			}


			/// <summary>
			/// Checks whether column Month is added in select statement 
			/// </summary>
			public bool IsSelectMonth { 
				get { return IsSelect("COL16598689804"); } 
				set { SetSelect("COL16598689804", value); } 
			}

			/// <summary>
			/// Checks whether column ExecDate is added in select statement 
			/// </summary>
			public bool IsSelectExecDate { 
				get { return IsSelect("COL165986898011"); } 
				set { SetSelect("COL165986898011", value); } 
			}

			/// <summary>
			/// Checks whether column CreatedBy is added in select statement 
			/// </summary>
			public bool IsSelectCreatedBy { 
				get { return IsSelect("COL165986898017"); } 
				set { SetSelect("COL165986898017", value); } 
			}

			/// <summary>
			/// Checks whether column ModifiedBy is added in select statement 
			/// </summary>
			public bool IsSelectModifiedBy { 
				get { return IsSelect("COL165986898019"); } 
				set { SetSelect("COL165986898019", value); } 
			}

			/// <summary>
			/// Checks whether column id is added in select statement 
			/// </summary>
			public bool IsSelectid { 
				get { return IsSelect("COL16598689801"); } 
				set { SetSelect("COL16598689801", value); } 
			}

			/// <summary>
			/// Checks whether column Description is added in select statement 
			/// </summary>
			public bool IsSelectDescription { 
				get { return IsSelect("COL16598689809"); } 
				set { SetSelect("COL16598689809", value); } 
			}

			/// <summary>
			/// Checks whether column MainName is added in select statement 
			/// </summary>
			public bool IsSelectMainName { 
				get { return IsSelect("COL16598689806"); } 
				set { SetSelect("COL16598689806", value); } 
			}

			/// <summary>
			/// Checks whether column Year is added in select statement 
			/// </summary>
			public bool IsSelectYear { 
				get { return IsSelect("COL16598689803"); } 
				set { SetSelect("COL16598689803", value); } 
			}

			/// <summary>
			/// Checks whether column ExecComment is added in select statement 
			/// </summary>
			public bool IsSelectExecComment { 
				get { return IsSelect("COL165986898013"); } 
				set { SetSelect("COL165986898013", value); } 
			}

			/// <summary>
			/// Checks whether column Created is added in select statement 
			/// </summary>
			public bool IsSelectCreated { 
				get { return IsSelect("COL165986898016"); } 
				set { SetSelect("COL165986898016", value); } 
			}

			/// <summary>
			/// Checks whether column Modified is added in select statement 
			/// </summary>
			public bool IsSelectModified { 
				get { return IsSelect("COL165986898018"); } 
				set { SetSelect("COL165986898018", value); } 
			}

			/// <summary>
			/// Checks whether column IsMaintenance is added in select statement 
			/// </summary>
			public bool IsSelectIsMaintenance { 
				get { return IsSelect("COL16598689808"); } 
				set { SetSelect("COL16598689808", value); } 
			}

			/// <summary>
			/// Checks whether column Week is added in select statement 
			/// </summary>
			public bool IsSelectWeek { 
				get { return IsSelect("COL16598689805"); } 
				set { SetSelect("COL16598689805", value); } 
			}

			/// <summary>
			/// Checks whether column DelFlag is added in select statement 
			/// </summary>
			public bool IsSelectDelFlag { 
				get { return IsSelect("COL165986898020"); } 
				set { SetSelect("COL165986898020", value); } 
			}

			/// <summary>
			/// Checks whether column ExecConfirmer is added in select statement 
			/// </summary>
			public bool IsSelectExecConfirmer { 
				get { return IsSelect("COL165986898015"); } 
				set { SetSelect("COL165986898015", value); } 
			}

			/// <summary>
			/// Checks whether column BuildingId is added in select statement 
			/// </summary>
			public bool IsSelectBuildingId { 
				get { return IsSelect("COL16598689802"); } 
				set { SetSelect("COL16598689802", value); } 
			}

			/// <summary>
			/// Checks whether column SubName is added in select statement 
			/// </summary>
			public bool IsSelectSubName { 
				get { return IsSelect("COL16598689807"); } 
				set { SetSelect("COL16598689807", value); } 
			}

			/// <summary>
			/// Checks whether column ExecDescription is added in select statement 
			/// </summary>
			public bool IsSelectExecDescription { 
				get { return IsSelect("COL165986898012"); } 
				set { SetSelect("COL165986898012", value); } 
			}

			/// <summary>
			/// Checks whether column ExecCompany is added in select statement 
			/// </summary>
			public bool IsSelectExecCompany { 
				get { return IsSelect("COL165986898014"); } 
				set { SetSelect("COL165986898014", value); } 
			}

			/// <summary>
			/// Checks whether column Comment is added in select statement 
			/// </summary>
			public bool IsSelectComment { 
				get { return IsSelect("COL165986898010"); } 
				set { SetSelect("COL165986898010", value); } 
			}



	}
}