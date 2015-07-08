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
	public class BD_WeekReportData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ1976394110";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of BD_WeekReport 
			/// </summary>
			public BD_WeekReportData(string objectID): base(objectID) {}  

			public BD_WeekReportData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field Executor 
			/// </summary>
			public string Executor { 
				get { return GetValue("COL197639411010"); } 
				set { SetValue("COL197639411010", value); } 
			}

			/// <summary>
			/// Gets field Numerical 
			/// </summary>
			public string Numerical { 
				get { return GetValue("COL19763941106"); } 
				set { SetValue("COL19763941106", value); } 
			}

			/// <summary>
			/// Gets field CreatedBy 
			/// </summary>
			public string CreatedBy { 
				get { return GetValue("COL197639411013"); } 
				set { SetValue("COL197639411013", value); } 
			}

			/// <summary>
			/// Gets field Created 
			/// </summary>
			public string Created { 
				get { return GetValue("COL197639411012"); } 
				set { SetValue("COL197639411012", value); } 
			}

			/// <summary>
			/// Gets field DateFrom 
			/// </summary>
			public string DateFrom { 
				get { return GetValue("COL19763941104"); } 
				set { SetValue("COL19763941104", value); } 
			}

			/// <summary>
			/// Gets field Comment 
			/// </summary>
			public string Comment { 
				get { return GetValue("COL197639411011"); } 
				set { SetValue("COL197639411011", value); } 
			}

			/// <summary>
			/// Gets field id 
			/// </summary>
			public string id { 
				get { return GetValue("COL19763941101"); } 
				set { SetValue("COL19763941101", value); } 
			}

			/// <summary>
			/// Gets field DelFlag 
			/// </summary>
			public string DelFlag { 
				get { return GetValue("COL197639411016"); } 
				set { SetValue("COL197639411016", value); } 
			}

			/// <summary>
			/// Gets field Week 
			/// </summary>
			public string Week { 
				get { return GetValue("COL19763941103"); } 
				set { SetValue("COL19763941103", value); } 
			}

			/// <summary>
			/// Gets field FinishPercent 
			/// </summary>
			public string FinishPercent { 
				get { return GetValue("COL19763941109"); } 
				set { SetValue("COL19763941109", value); } 
			}

			/// <summary>
			/// Gets field BuildingId 
			/// </summary>
			public string BuildingId { 
				get { return GetValue("COL19763941102"); } 
				set { SetValue("COL19763941102", value); } 
			}

			/// <summary>
			/// Gets field TargetID 
			/// </summary>
			public string TargetID { 
				get { return GetValue("COL19763941107"); } 
				set { SetValue("COL19763941107", value); } 
			}

			/// <summary>
			/// Gets field Modified 
			/// </summary>
			public string Modified { 
				get { return GetValue("COL197639411014"); } 
				set { SetValue("COL197639411014", value); } 
			}

			/// <summary>
			/// Gets field ModifiedBy 
			/// </summary>
			public string ModifiedBy { 
				get { return GetValue("COL197639411015"); } 
				set { SetValue("COL197639411015", value); } 
			}

			/// <summary>
			/// Gets field DateTo 
			/// </summary>
			public string DateTo { 
				get { return GetValue("COL19763941105"); } 
				set { SetValue("COL19763941105", value); } 
			}

			/// <summary>
			/// Gets field Description 
			/// </summary>
			public string Description { 
				get { return GetValue("COL19763941108"); } 
				set { SetValue("COL19763941108", value); } 
			}


			/// <summary>
			/// Gets Executor attribute data 
			/// </summary>
			public AttributeData GetExecutorAttributeData() { 
				return GetAttributeData("COL197639411010"); 
			}

			/// <summary>
			/// Gets Numerical attribute data 
			/// </summary>
			public AttributeData GetNumericalAttributeData() { 
				return GetAttributeData("COL19763941106"); 
			}

			/// <summary>
			/// Gets CreatedBy attribute data 
			/// </summary>
			public AttributeData GetCreatedByAttributeData() { 
				return GetAttributeData("COL197639411013"); 
			}

			/// <summary>
			/// Gets Created attribute data 
			/// </summary>
			public AttributeData GetCreatedAttributeData() { 
				return GetAttributeData("COL197639411012"); 
			}

			/// <summary>
			/// Gets DateFrom attribute data 
			/// </summary>
			public AttributeData GetDateFromAttributeData() { 
				return GetAttributeData("COL19763941104"); 
			}

			/// <summary>
			/// Gets Comment attribute data 
			/// </summary>
			public AttributeData GetCommentAttributeData() { 
				return GetAttributeData("COL197639411011"); 
			}

			/// <summary>
			/// Gets id attribute data 
			/// </summary>
			public AttributeData GetidAttributeData() { 
				return GetAttributeData("COL19763941101"); 
			}

			/// <summary>
			/// Gets DelFlag attribute data 
			/// </summary>
			public AttributeData GetDelFlagAttributeData() { 
				return GetAttributeData("COL197639411016"); 
			}

			/// <summary>
			/// Gets Week attribute data 
			/// </summary>
			public AttributeData GetWeekAttributeData() { 
				return GetAttributeData("COL19763941103"); 
			}

			/// <summary>
			/// Gets FinishPercent attribute data 
			/// </summary>
			public AttributeData GetFinishPercentAttributeData() { 
				return GetAttributeData("COL19763941109"); 
			}

			/// <summary>
			/// Gets BuildingId attribute data 
			/// </summary>
			public AttributeData GetBuildingIdAttributeData() { 
				return GetAttributeData("COL19763941102"); 
			}

			/// <summary>
			/// Gets TargetID attribute data 
			/// </summary>
			public AttributeData GetTargetIDAttributeData() { 
				return GetAttributeData("COL19763941107"); 
			}

			/// <summary>
			/// Gets Modified attribute data 
			/// </summary>
			public AttributeData GetModifiedAttributeData() { 
				return GetAttributeData("COL197639411014"); 
			}

			/// <summary>
			/// Gets ModifiedBy attribute data 
			/// </summary>
			public AttributeData GetModifiedByAttributeData() { 
				return GetAttributeData("COL197639411015"); 
			}

			/// <summary>
			/// Gets DateTo attribute data 
			/// </summary>
			public AttributeData GetDateToAttributeData() { 
				return GetAttributeData("COL19763941105"); 
			}

			/// <summary>
			/// Gets Description attribute data 
			/// </summary>
			public AttributeData GetDescriptionAttributeData() { 
				return GetAttributeData("COL19763941108"); 
			}


			/// <summary>
			/// Gets column Executor with alias  
			/// </summary>
			public string ColExecutor { 
				get { return GetColumnName("COL197639411010"); } 
			}

			/// <summary>
			/// Gets column Numerical with alias  
			/// </summary>
			public string ColNumerical { 
				get { return GetColumnName("COL19763941106"); } 
			}

			/// <summary>
			/// Gets column CreatedBy with alias  
			/// </summary>
			public string ColCreatedBy { 
				get { return GetColumnName("COL197639411013"); } 
			}

			/// <summary>
			/// Gets column Created with alias  
			/// </summary>
			public string ColCreated { 
				get { return GetColumnName("COL197639411012"); } 
			}

			/// <summary>
			/// Gets column DateFrom with alias  
			/// </summary>
			public string ColDateFrom { 
				get { return GetColumnName("COL19763941104"); } 
			}

			/// <summary>
			/// Gets column Comment with alias  
			/// </summary>
			public string ColComment { 
				get { return GetColumnName("COL197639411011"); } 
			}

			/// <summary>
			/// Gets column id with alias  
			/// </summary>
			public string Colid { 
				get { return GetColumnName("COL19763941101"); } 
			}

			/// <summary>
			/// Gets column DelFlag with alias  
			/// </summary>
			public string ColDelFlag { 
				get { return GetColumnName("COL197639411016"); } 
			}

			/// <summary>
			/// Gets column Week with alias  
			/// </summary>
			public string ColWeek { 
				get { return GetColumnName("COL19763941103"); } 
			}

			/// <summary>
			/// Gets column FinishPercent with alias  
			/// </summary>
			public string ColFinishPercent { 
				get { return GetColumnName("COL19763941109"); } 
			}

			/// <summary>
			/// Gets column BuildingId with alias  
			/// </summary>
			public string ColBuildingId { 
				get { return GetColumnName("COL19763941102"); } 
			}

			/// <summary>
			/// Gets column TargetID with alias  
			/// </summary>
			public string ColTargetID { 
				get { return GetColumnName("COL19763941107"); } 
			}

			/// <summary>
			/// Gets column Modified with alias  
			/// </summary>
			public string ColModified { 
				get { return GetColumnName("COL197639411014"); } 
			}

			/// <summary>
			/// Gets column ModifiedBy with alias  
			/// </summary>
			public string ColModifiedBy { 
				get { return GetColumnName("COL197639411015"); } 
			}

			/// <summary>
			/// Gets column DateTo with alias  
			/// </summary>
			public string ColDateTo { 
				get { return GetColumnName("COL19763941105"); } 
			}

			/// <summary>
			/// Gets column Description with alias  
			/// </summary>
			public string ColDescription { 
				get { return GetColumnName("COL19763941108"); } 
			}


			/// <summary>
			/// Checks whether column Executor is added in select statement 
			/// </summary>
			public bool IsSelectExecutor { 
				get { return IsSelect("COL197639411010"); } 
				set { SetSelect("COL197639411010", value); } 
			}

			/// <summary>
			/// Checks whether column Numerical is added in select statement 
			/// </summary>
			public bool IsSelectNumerical { 
				get { return IsSelect("COL19763941106"); } 
				set { SetSelect("COL19763941106", value); } 
			}

			/// <summary>
			/// Checks whether column CreatedBy is added in select statement 
			/// </summary>
			public bool IsSelectCreatedBy { 
				get { return IsSelect("COL197639411013"); } 
				set { SetSelect("COL197639411013", value); } 
			}

			/// <summary>
			/// Checks whether column Created is added in select statement 
			/// </summary>
			public bool IsSelectCreated { 
				get { return IsSelect("COL197639411012"); } 
				set { SetSelect("COL197639411012", value); } 
			}

			/// <summary>
			/// Checks whether column DateFrom is added in select statement 
			/// </summary>
			public bool IsSelectDateFrom { 
				get { return IsSelect("COL19763941104"); } 
				set { SetSelect("COL19763941104", value); } 
			}

			/// <summary>
			/// Checks whether column Comment is added in select statement 
			/// </summary>
			public bool IsSelectComment { 
				get { return IsSelect("COL197639411011"); } 
				set { SetSelect("COL197639411011", value); } 
			}

			/// <summary>
			/// Checks whether column id is added in select statement 
			/// </summary>
			public bool IsSelectid { 
				get { return IsSelect("COL19763941101"); } 
				set { SetSelect("COL19763941101", value); } 
			}

			/// <summary>
			/// Checks whether column DelFlag is added in select statement 
			/// </summary>
			public bool IsSelectDelFlag { 
				get { return IsSelect("COL197639411016"); } 
				set { SetSelect("COL197639411016", value); } 
			}

			/// <summary>
			/// Checks whether column Week is added in select statement 
			/// </summary>
			public bool IsSelectWeek { 
				get { return IsSelect("COL19763941103"); } 
				set { SetSelect("COL19763941103", value); } 
			}

			/// <summary>
			/// Checks whether column FinishPercent is added in select statement 
			/// </summary>
			public bool IsSelectFinishPercent { 
				get { return IsSelect("COL19763941109"); } 
				set { SetSelect("COL19763941109", value); } 
			}

			/// <summary>
			/// Checks whether column BuildingId is added in select statement 
			/// </summary>
			public bool IsSelectBuildingId { 
				get { return IsSelect("COL19763941102"); } 
				set { SetSelect("COL19763941102", value); } 
			}

			/// <summary>
			/// Checks whether column TargetID is added in select statement 
			/// </summary>
			public bool IsSelectTargetID { 
				get { return IsSelect("COL19763941107"); } 
				set { SetSelect("COL19763941107", value); } 
			}

			/// <summary>
			/// Checks whether column Modified is added in select statement 
			/// </summary>
			public bool IsSelectModified { 
				get { return IsSelect("COL197639411014"); } 
				set { SetSelect("COL197639411014", value); } 
			}

			/// <summary>
			/// Checks whether column ModifiedBy is added in select statement 
			/// </summary>
			public bool IsSelectModifiedBy { 
				get { return IsSelect("COL197639411015"); } 
				set { SetSelect("COL197639411015", value); } 
			}

			/// <summary>
			/// Checks whether column DateTo is added in select statement 
			/// </summary>
			public bool IsSelectDateTo { 
				get { return IsSelect("COL19763941105"); } 
				set { SetSelect("COL19763941105", value); } 
			}

			/// <summary>
			/// Checks whether column Description is added in select statement 
			/// </summary>
			public bool IsSelectDescription { 
				get { return IsSelect("COL19763941108"); } 
				set { SetSelect("COL19763941108", value); } 
			}



	}
}