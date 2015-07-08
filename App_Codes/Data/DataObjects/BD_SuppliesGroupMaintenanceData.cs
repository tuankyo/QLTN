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
	public class BD_SuppliesGroupMaintenanceData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ1995870177";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of BD_SuppliesGroupMaintenance 
			/// </summary>
			public BD_SuppliesGroupMaintenanceData(string objectID): base(objectID) {}  

			public BD_SuppliesGroupMaintenanceData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field ExecDateTo 
			/// </summary>
			public string ExecDateTo { 
				get { return GetValue("COL19958701778"); } 
				set { SetValue("COL19958701778", value); } 
			}

			/// <summary>
			/// Gets field Modified 
			/// </summary>
			public string Modified { 
				get { return GetValue("COL199587017715"); } 
				set { SetValue("COL199587017715", value); } 
			}

			/// <summary>
			/// Gets field Description 
			/// </summary>
			public string Description { 
				get { return GetValue("COL19958701775"); } 
				set { SetValue("COL19958701775", value); } 
			}

			/// <summary>
			/// Gets field DelFlag 
			/// </summary>
			public string DelFlag { 
				get { return GetValue("COL199587017717"); } 
				set { SetValue("COL199587017717", value); } 
			}

			/// <summary>
			/// Gets field SuppliesGroupId 
			/// </summary>
			public string SuppliesGroupId { 
				get { return GetValue("COL19958701772"); } 
				set { SetValue("COL19958701772", value); } 
			}

			/// <summary>
			/// Gets field ExecConfirmer 
			/// </summary>
			public string ExecConfirmer { 
				get { return GetValue("COL199587017712"); } 
				set { SetValue("COL199587017712", value); } 
			}

			/// <summary>
			/// Gets field ExecComment 
			/// </summary>
			public string ExecComment { 
				get { return GetValue("COL199587017710"); } 
				set { SetValue("COL199587017710", value); } 
			}

			/// <summary>
			/// Gets field ExecDateFrom 
			/// </summary>
			public string ExecDateFrom { 
				get { return GetValue("COL19958701777"); } 
				set { SetValue("COL19958701777", value); } 
			}

			/// <summary>
			/// Gets field ExecCompany 
			/// </summary>
			public string ExecCompany { 
				get { return GetValue("COL199587017711"); } 
				set { SetValue("COL199587017711", value); } 
			}

			/// <summary>
			/// Gets field ScheduleDate 
			/// </summary>
			public string ScheduleDate { 
				get { return GetValue("COL19958701774"); } 
				set { SetValue("COL19958701774", value); } 
			}

			/// <summary>
			/// Gets field id 
			/// </summary>
			public string id { 
				get { return GetValue("COL19958701771"); } 
				set { SetValue("COL19958701771", value); } 
			}

			/// <summary>
			/// Gets field Created 
			/// </summary>
			public string Created { 
				get { return GetValue("COL199587017713"); } 
				set { SetValue("COL199587017713", value); } 
			}

			/// <summary>
			/// Gets field ModifiedBy 
			/// </summary>
			public string ModifiedBy { 
				get { return GetValue("COL199587017716"); } 
				set { SetValue("COL199587017716", value); } 
			}

			/// <summary>
			/// Gets field ExecDescription 
			/// </summary>
			public string ExecDescription { 
				get { return GetValue("COL19958701779"); } 
				set { SetValue("COL19958701779", value); } 
			}

			/// <summary>
			/// Gets field CreatedBy 
			/// </summary>
			public string CreatedBy { 
				get { return GetValue("COL199587017714"); } 
				set { SetValue("COL199587017714", value); } 
			}

			/// <summary>
			/// Gets field Comment 
			/// </summary>
			public string Comment { 
				get { return GetValue("COL19958701776"); } 
				set { SetValue("COL19958701776", value); } 
			}

			/// <summary>
			/// Gets field MaintenanceItem 
			/// </summary>
			public string MaintenanceItem { 
				get { return GetValue("COL19958701773"); } 
				set { SetValue("COL19958701773", value); } 
			}


			/// <summary>
			/// Gets ExecDateTo attribute data 
			/// </summary>
			public AttributeData GetExecDateToAttributeData() { 
				return GetAttributeData("COL19958701778"); 
			}

			/// <summary>
			/// Gets Modified attribute data 
			/// </summary>
			public AttributeData GetModifiedAttributeData() { 
				return GetAttributeData("COL199587017715"); 
			}

			/// <summary>
			/// Gets Description attribute data 
			/// </summary>
			public AttributeData GetDescriptionAttributeData() { 
				return GetAttributeData("COL19958701775"); 
			}

			/// <summary>
			/// Gets DelFlag attribute data 
			/// </summary>
			public AttributeData GetDelFlagAttributeData() { 
				return GetAttributeData("COL199587017717"); 
			}

			/// <summary>
			/// Gets SuppliesGroupId attribute data 
			/// </summary>
			public AttributeData GetSuppliesGroupIdAttributeData() { 
				return GetAttributeData("COL19958701772"); 
			}

			/// <summary>
			/// Gets ExecConfirmer attribute data 
			/// </summary>
			public AttributeData GetExecConfirmerAttributeData() { 
				return GetAttributeData("COL199587017712"); 
			}

			/// <summary>
			/// Gets ExecComment attribute data 
			/// </summary>
			public AttributeData GetExecCommentAttributeData() { 
				return GetAttributeData("COL199587017710"); 
			}

			/// <summary>
			/// Gets ExecDateFrom attribute data 
			/// </summary>
			public AttributeData GetExecDateFromAttributeData() { 
				return GetAttributeData("COL19958701777"); 
			}

			/// <summary>
			/// Gets ExecCompany attribute data 
			/// </summary>
			public AttributeData GetExecCompanyAttributeData() { 
				return GetAttributeData("COL199587017711"); 
			}

			/// <summary>
			/// Gets ScheduleDate attribute data 
			/// </summary>
			public AttributeData GetScheduleDateAttributeData() { 
				return GetAttributeData("COL19958701774"); 
			}

			/// <summary>
			/// Gets id attribute data 
			/// </summary>
			public AttributeData GetidAttributeData() { 
				return GetAttributeData("COL19958701771"); 
			}

			/// <summary>
			/// Gets Created attribute data 
			/// </summary>
			public AttributeData GetCreatedAttributeData() { 
				return GetAttributeData("COL199587017713"); 
			}

			/// <summary>
			/// Gets ModifiedBy attribute data 
			/// </summary>
			public AttributeData GetModifiedByAttributeData() { 
				return GetAttributeData("COL199587017716"); 
			}

			/// <summary>
			/// Gets ExecDescription attribute data 
			/// </summary>
			public AttributeData GetExecDescriptionAttributeData() { 
				return GetAttributeData("COL19958701779"); 
			}

			/// <summary>
			/// Gets CreatedBy attribute data 
			/// </summary>
			public AttributeData GetCreatedByAttributeData() { 
				return GetAttributeData("COL199587017714"); 
			}

			/// <summary>
			/// Gets Comment attribute data 
			/// </summary>
			public AttributeData GetCommentAttributeData() { 
				return GetAttributeData("COL19958701776"); 
			}

			/// <summary>
			/// Gets MaintenanceItem attribute data 
			/// </summary>
			public AttributeData GetMaintenanceItemAttributeData() { 
				return GetAttributeData("COL19958701773"); 
			}


			/// <summary>
			/// Gets column ExecDateTo with alias  
			/// </summary>
			public string ColExecDateTo { 
				get { return GetColumnName("COL19958701778"); } 
			}

			/// <summary>
			/// Gets column Modified with alias  
			/// </summary>
			public string ColModified { 
				get { return GetColumnName("COL199587017715"); } 
			}

			/// <summary>
			/// Gets column Description with alias  
			/// </summary>
			public string ColDescription { 
				get { return GetColumnName("COL19958701775"); } 
			}

			/// <summary>
			/// Gets column DelFlag with alias  
			/// </summary>
			public string ColDelFlag { 
				get { return GetColumnName("COL199587017717"); } 
			}

			/// <summary>
			/// Gets column SuppliesGroupId with alias  
			/// </summary>
			public string ColSuppliesGroupId { 
				get { return GetColumnName("COL19958701772"); } 
			}

			/// <summary>
			/// Gets column ExecConfirmer with alias  
			/// </summary>
			public string ColExecConfirmer { 
				get { return GetColumnName("COL199587017712"); } 
			}

			/// <summary>
			/// Gets column ExecComment with alias  
			/// </summary>
			public string ColExecComment { 
				get { return GetColumnName("COL199587017710"); } 
			}

			/// <summary>
			/// Gets column ExecDateFrom with alias  
			/// </summary>
			public string ColExecDateFrom { 
				get { return GetColumnName("COL19958701777"); } 
			}

			/// <summary>
			/// Gets column ExecCompany with alias  
			/// </summary>
			public string ColExecCompany { 
				get { return GetColumnName("COL199587017711"); } 
			}

			/// <summary>
			/// Gets column ScheduleDate with alias  
			/// </summary>
			public string ColScheduleDate { 
				get { return GetColumnName("COL19958701774"); } 
			}

			/// <summary>
			/// Gets column id with alias  
			/// </summary>
			public string Colid { 
				get { return GetColumnName("COL19958701771"); } 
			}

			/// <summary>
			/// Gets column Created with alias  
			/// </summary>
			public string ColCreated { 
				get { return GetColumnName("COL199587017713"); } 
			}

			/// <summary>
			/// Gets column ModifiedBy with alias  
			/// </summary>
			public string ColModifiedBy { 
				get { return GetColumnName("COL199587017716"); } 
			}

			/// <summary>
			/// Gets column ExecDescription with alias  
			/// </summary>
			public string ColExecDescription { 
				get { return GetColumnName("COL19958701779"); } 
			}

			/// <summary>
			/// Gets column CreatedBy with alias  
			/// </summary>
			public string ColCreatedBy { 
				get { return GetColumnName("COL199587017714"); } 
			}

			/// <summary>
			/// Gets column Comment with alias  
			/// </summary>
			public string ColComment { 
				get { return GetColumnName("COL19958701776"); } 
			}

			/// <summary>
			/// Gets column MaintenanceItem with alias  
			/// </summary>
			public string ColMaintenanceItem { 
				get { return GetColumnName("COL19958701773"); } 
			}


			/// <summary>
			/// Checks whether column ExecDateTo is added in select statement 
			/// </summary>
			public bool IsSelectExecDateTo { 
				get { return IsSelect("COL19958701778"); } 
				set { SetSelect("COL19958701778", value); } 
			}

			/// <summary>
			/// Checks whether column Modified is added in select statement 
			/// </summary>
			public bool IsSelectModified { 
				get { return IsSelect("COL199587017715"); } 
				set { SetSelect("COL199587017715", value); } 
			}

			/// <summary>
			/// Checks whether column Description is added in select statement 
			/// </summary>
			public bool IsSelectDescription { 
				get { return IsSelect("COL19958701775"); } 
				set { SetSelect("COL19958701775", value); } 
			}

			/// <summary>
			/// Checks whether column DelFlag is added in select statement 
			/// </summary>
			public bool IsSelectDelFlag { 
				get { return IsSelect("COL199587017717"); } 
				set { SetSelect("COL199587017717", value); } 
			}

			/// <summary>
			/// Checks whether column SuppliesGroupId is added in select statement 
			/// </summary>
			public bool IsSelectSuppliesGroupId { 
				get { return IsSelect("COL19958701772"); } 
				set { SetSelect("COL19958701772", value); } 
			}

			/// <summary>
			/// Checks whether column ExecConfirmer is added in select statement 
			/// </summary>
			public bool IsSelectExecConfirmer { 
				get { return IsSelect("COL199587017712"); } 
				set { SetSelect("COL199587017712", value); } 
			}

			/// <summary>
			/// Checks whether column ExecComment is added in select statement 
			/// </summary>
			public bool IsSelectExecComment { 
				get { return IsSelect("COL199587017710"); } 
				set { SetSelect("COL199587017710", value); } 
			}

			/// <summary>
			/// Checks whether column ExecDateFrom is added in select statement 
			/// </summary>
			public bool IsSelectExecDateFrom { 
				get { return IsSelect("COL19958701777"); } 
				set { SetSelect("COL19958701777", value); } 
			}

			/// <summary>
			/// Checks whether column ExecCompany is added in select statement 
			/// </summary>
			public bool IsSelectExecCompany { 
				get { return IsSelect("COL199587017711"); } 
				set { SetSelect("COL199587017711", value); } 
			}

			/// <summary>
			/// Checks whether column ScheduleDate is added in select statement 
			/// </summary>
			public bool IsSelectScheduleDate { 
				get { return IsSelect("COL19958701774"); } 
				set { SetSelect("COL19958701774", value); } 
			}

			/// <summary>
			/// Checks whether column id is added in select statement 
			/// </summary>
			public bool IsSelectid { 
				get { return IsSelect("COL19958701771"); } 
				set { SetSelect("COL19958701771", value); } 
			}

			/// <summary>
			/// Checks whether column Created is added in select statement 
			/// </summary>
			public bool IsSelectCreated { 
				get { return IsSelect("COL199587017713"); } 
				set { SetSelect("COL199587017713", value); } 
			}

			/// <summary>
			/// Checks whether column ModifiedBy is added in select statement 
			/// </summary>
			public bool IsSelectModifiedBy { 
				get { return IsSelect("COL199587017716"); } 
				set { SetSelect("COL199587017716", value); } 
			}

			/// <summary>
			/// Checks whether column ExecDescription is added in select statement 
			/// </summary>
			public bool IsSelectExecDescription { 
				get { return IsSelect("COL19958701779"); } 
				set { SetSelect("COL19958701779", value); } 
			}

			/// <summary>
			/// Checks whether column CreatedBy is added in select statement 
			/// </summary>
			public bool IsSelectCreatedBy { 
				get { return IsSelect("COL199587017714"); } 
				set { SetSelect("COL199587017714", value); } 
			}

			/// <summary>
			/// Checks whether column Comment is added in select statement 
			/// </summary>
			public bool IsSelectComment { 
				get { return IsSelect("COL19958701776"); } 
				set { SetSelect("COL19958701776", value); } 
			}

			/// <summary>
			/// Checks whether column MaintenanceItem is added in select statement 
			/// </summary>
			public bool IsSelectMaintenanceItem { 
				get { return IsSelect("COL19958701773"); } 
				set { SetSelect("COL19958701773", value); } 
			}



	}
}