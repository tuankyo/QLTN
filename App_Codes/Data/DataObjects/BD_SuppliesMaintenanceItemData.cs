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
	public class BD_SuppliesMaintenanceItemData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ139863565";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of BD_SuppliesMaintenanceItem 
			/// </summary>
			public BD_SuppliesMaintenanceItemData(string objectID): base(objectID) {}  

			public BD_SuppliesMaintenanceItemData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field CreatedBy 
			/// </summary>
			public string CreatedBy { 
				get { return GetValue("COL13986356513"); } 
				set { SetValue("COL13986356513", value); } 
			}

			/// <summary>
			/// Gets field DelFlag 
			/// </summary>
			public string DelFlag { 
				get { return GetValue("COL13986356516"); } 
				set { SetValue("COL13986356516", value); } 
			}

			/// <summary>
			/// Gets field ExecConfirmer 
			/// </summary>
			public string ExecConfirmer { 
				get { return GetValue("COL13986356511"); } 
				set { SetValue("COL13986356511", value); } 
			}

			/// <summary>
			/// Gets field Modified 
			/// </summary>
			public string Modified { 
				get { return GetValue("COL13986356514"); } 
				set { SetValue("COL13986356514", value); } 
			}

			/// <summary>
			/// Gets field ModifiedBy 
			/// </summary>
			public string ModifiedBy { 
				get { return GetValue("COL13986356515"); } 
				set { SetValue("COL13986356515", value); } 
			}

			/// <summary>
			/// Gets field ExecComment 
			/// </summary>
			public string ExecComment { 
				get { return GetValue("COL1398635659"); } 
				set { SetValue("COL1398635659", value); } 
			}

			/// <summary>
			/// Gets field ExecCompany 
			/// </summary>
			public string ExecCompany { 
				get { return GetValue("COL13986356510"); } 
				set { SetValue("COL13986356510", value); } 
			}

			/// <summary>
			/// Gets field SuppliesId 
			/// </summary>
			public string SuppliesId { 
				get { return GetValue("COL1398635652"); } 
				set { SetValue("COL1398635652", value); } 
			}

			/// <summary>
			/// Gets field MaintenanceItem 
			/// </summary>
			public string MaintenanceItem { 
				get { return GetValue("COL1398635653"); } 
				set { SetValue("COL1398635653", value); } 
			}

			/// <summary>
			/// Gets field Created 
			/// </summary>
			public string Created { 
				get { return GetValue("COL13986356512"); } 
				set { SetValue("COL13986356512", value); } 
			}

			/// <summary>
			/// Gets field id 
			/// </summary>
			public string id { 
				get { return GetValue("COL1398635651"); } 
				set { SetValue("COL1398635651", value); } 
			}

			/// <summary>
			/// Gets field Comment 
			/// </summary>
			public string Comment { 
				get { return GetValue("COL1398635656"); } 
				set { SetValue("COL1398635656", value); } 
			}

			/// <summary>
			/// Gets field ExecDate 
			/// </summary>
			public string ExecDate { 
				get { return GetValue("COL1398635657"); } 
				set { SetValue("COL1398635657", value); } 
			}

			/// <summary>
			/// Gets field ScheduleDate 
			/// </summary>
			public string ScheduleDate { 
				get { return GetValue("COL1398635654"); } 
				set { SetValue("COL1398635654", value); } 
			}

			/// <summary>
			/// Gets field Description 
			/// </summary>
			public string Description { 
				get { return GetValue("COL1398635655"); } 
				set { SetValue("COL1398635655", value); } 
			}

			/// <summary>
			/// Gets field ExecDescription 
			/// </summary>
			public string ExecDescription { 
				get { return GetValue("COL1398635658"); } 
				set { SetValue("COL1398635658", value); } 
			}


			/// <summary>
			/// Gets CreatedBy attribute data 
			/// </summary>
			public AttributeData GetCreatedByAttributeData() { 
				return GetAttributeData("COL13986356513"); 
			}

			/// <summary>
			/// Gets DelFlag attribute data 
			/// </summary>
			public AttributeData GetDelFlagAttributeData() { 
				return GetAttributeData("COL13986356516"); 
			}

			/// <summary>
			/// Gets ExecConfirmer attribute data 
			/// </summary>
			public AttributeData GetExecConfirmerAttributeData() { 
				return GetAttributeData("COL13986356511"); 
			}

			/// <summary>
			/// Gets Modified attribute data 
			/// </summary>
			public AttributeData GetModifiedAttributeData() { 
				return GetAttributeData("COL13986356514"); 
			}

			/// <summary>
			/// Gets ModifiedBy attribute data 
			/// </summary>
			public AttributeData GetModifiedByAttributeData() { 
				return GetAttributeData("COL13986356515"); 
			}

			/// <summary>
			/// Gets ExecComment attribute data 
			/// </summary>
			public AttributeData GetExecCommentAttributeData() { 
				return GetAttributeData("COL1398635659"); 
			}

			/// <summary>
			/// Gets ExecCompany attribute data 
			/// </summary>
			public AttributeData GetExecCompanyAttributeData() { 
				return GetAttributeData("COL13986356510"); 
			}

			/// <summary>
			/// Gets SuppliesId attribute data 
			/// </summary>
			public AttributeData GetSuppliesIdAttributeData() { 
				return GetAttributeData("COL1398635652"); 
			}

			/// <summary>
			/// Gets MaintenanceItem attribute data 
			/// </summary>
			public AttributeData GetMaintenanceItemAttributeData() { 
				return GetAttributeData("COL1398635653"); 
			}

			/// <summary>
			/// Gets Created attribute data 
			/// </summary>
			public AttributeData GetCreatedAttributeData() { 
				return GetAttributeData("COL13986356512"); 
			}

			/// <summary>
			/// Gets id attribute data 
			/// </summary>
			public AttributeData GetidAttributeData() { 
				return GetAttributeData("COL1398635651"); 
			}

			/// <summary>
			/// Gets Comment attribute data 
			/// </summary>
			public AttributeData GetCommentAttributeData() { 
				return GetAttributeData("COL1398635656"); 
			}

			/// <summary>
			/// Gets ExecDate attribute data 
			/// </summary>
			public AttributeData GetExecDateAttributeData() { 
				return GetAttributeData("COL1398635657"); 
			}

			/// <summary>
			/// Gets ScheduleDate attribute data 
			/// </summary>
			public AttributeData GetScheduleDateAttributeData() { 
				return GetAttributeData("COL1398635654"); 
			}

			/// <summary>
			/// Gets Description attribute data 
			/// </summary>
			public AttributeData GetDescriptionAttributeData() { 
				return GetAttributeData("COL1398635655"); 
			}

			/// <summary>
			/// Gets ExecDescription attribute data 
			/// </summary>
			public AttributeData GetExecDescriptionAttributeData() { 
				return GetAttributeData("COL1398635658"); 
			}


			/// <summary>
			/// Gets column CreatedBy with alias  
			/// </summary>
			public string ColCreatedBy { 
				get { return GetColumnName("COL13986356513"); } 
			}

			/// <summary>
			/// Gets column DelFlag with alias  
			/// </summary>
			public string ColDelFlag { 
				get { return GetColumnName("COL13986356516"); } 
			}

			/// <summary>
			/// Gets column ExecConfirmer with alias  
			/// </summary>
			public string ColExecConfirmer { 
				get { return GetColumnName("COL13986356511"); } 
			}

			/// <summary>
			/// Gets column Modified with alias  
			/// </summary>
			public string ColModified { 
				get { return GetColumnName("COL13986356514"); } 
			}

			/// <summary>
			/// Gets column ModifiedBy with alias  
			/// </summary>
			public string ColModifiedBy { 
				get { return GetColumnName("COL13986356515"); } 
			}

			/// <summary>
			/// Gets column ExecComment with alias  
			/// </summary>
			public string ColExecComment { 
				get { return GetColumnName("COL1398635659"); } 
			}

			/// <summary>
			/// Gets column ExecCompany with alias  
			/// </summary>
			public string ColExecCompany { 
				get { return GetColumnName("COL13986356510"); } 
			}

			/// <summary>
			/// Gets column SuppliesId with alias  
			/// </summary>
			public string ColSuppliesId { 
				get { return GetColumnName("COL1398635652"); } 
			}

			/// <summary>
			/// Gets column MaintenanceItem with alias  
			/// </summary>
			public string ColMaintenanceItem { 
				get { return GetColumnName("COL1398635653"); } 
			}

			/// <summary>
			/// Gets column Created with alias  
			/// </summary>
			public string ColCreated { 
				get { return GetColumnName("COL13986356512"); } 
			}

			/// <summary>
			/// Gets column id with alias  
			/// </summary>
			public string Colid { 
				get { return GetColumnName("COL1398635651"); } 
			}

			/// <summary>
			/// Gets column Comment with alias  
			/// </summary>
			public string ColComment { 
				get { return GetColumnName("COL1398635656"); } 
			}

			/// <summary>
			/// Gets column ExecDate with alias  
			/// </summary>
			public string ColExecDate { 
				get { return GetColumnName("COL1398635657"); } 
			}

			/// <summary>
			/// Gets column ScheduleDate with alias  
			/// </summary>
			public string ColScheduleDate { 
				get { return GetColumnName("COL1398635654"); } 
			}

			/// <summary>
			/// Gets column Description with alias  
			/// </summary>
			public string ColDescription { 
				get { return GetColumnName("COL1398635655"); } 
			}

			/// <summary>
			/// Gets column ExecDescription with alias  
			/// </summary>
			public string ColExecDescription { 
				get { return GetColumnName("COL1398635658"); } 
			}


			/// <summary>
			/// Checks whether column CreatedBy is added in select statement 
			/// </summary>
			public bool IsSelectCreatedBy { 
				get { return IsSelect("COL13986356513"); } 
				set { SetSelect("COL13986356513", value); } 
			}

			/// <summary>
			/// Checks whether column DelFlag is added in select statement 
			/// </summary>
			public bool IsSelectDelFlag { 
				get { return IsSelect("COL13986356516"); } 
				set { SetSelect("COL13986356516", value); } 
			}

			/// <summary>
			/// Checks whether column ExecConfirmer is added in select statement 
			/// </summary>
			public bool IsSelectExecConfirmer { 
				get { return IsSelect("COL13986356511"); } 
				set { SetSelect("COL13986356511", value); } 
			}

			/// <summary>
			/// Checks whether column Modified is added in select statement 
			/// </summary>
			public bool IsSelectModified { 
				get { return IsSelect("COL13986356514"); } 
				set { SetSelect("COL13986356514", value); } 
			}

			/// <summary>
			/// Checks whether column ModifiedBy is added in select statement 
			/// </summary>
			public bool IsSelectModifiedBy { 
				get { return IsSelect("COL13986356515"); } 
				set { SetSelect("COL13986356515", value); } 
			}

			/// <summary>
			/// Checks whether column ExecComment is added in select statement 
			/// </summary>
			public bool IsSelectExecComment { 
				get { return IsSelect("COL1398635659"); } 
				set { SetSelect("COL1398635659", value); } 
			}

			/// <summary>
			/// Checks whether column ExecCompany is added in select statement 
			/// </summary>
			public bool IsSelectExecCompany { 
				get { return IsSelect("COL13986356510"); } 
				set { SetSelect("COL13986356510", value); } 
			}

			/// <summary>
			/// Checks whether column SuppliesId is added in select statement 
			/// </summary>
			public bool IsSelectSuppliesId { 
				get { return IsSelect("COL1398635652"); } 
				set { SetSelect("COL1398635652", value); } 
			}

			/// <summary>
			/// Checks whether column MaintenanceItem is added in select statement 
			/// </summary>
			public bool IsSelectMaintenanceItem { 
				get { return IsSelect("COL1398635653"); } 
				set { SetSelect("COL1398635653", value); } 
			}

			/// <summary>
			/// Checks whether column Created is added in select statement 
			/// </summary>
			public bool IsSelectCreated { 
				get { return IsSelect("COL13986356512"); } 
				set { SetSelect("COL13986356512", value); } 
			}

			/// <summary>
			/// Checks whether column id is added in select statement 
			/// </summary>
			public bool IsSelectid { 
				get { return IsSelect("COL1398635651"); } 
				set { SetSelect("COL1398635651", value); } 
			}

			/// <summary>
			/// Checks whether column Comment is added in select statement 
			/// </summary>
			public bool IsSelectComment { 
				get { return IsSelect("COL1398635656"); } 
				set { SetSelect("COL1398635656", value); } 
			}

			/// <summary>
			/// Checks whether column ExecDate is added in select statement 
			/// </summary>
			public bool IsSelectExecDate { 
				get { return IsSelect("COL1398635657"); } 
				set { SetSelect("COL1398635657", value); } 
			}

			/// <summary>
			/// Checks whether column ScheduleDate is added in select statement 
			/// </summary>
			public bool IsSelectScheduleDate { 
				get { return IsSelect("COL1398635654"); } 
				set { SetSelect("COL1398635654", value); } 
			}

			/// <summary>
			/// Checks whether column Description is added in select statement 
			/// </summary>
			public bool IsSelectDescription { 
				get { return IsSelect("COL1398635655"); } 
				set { SetSelect("COL1398635655", value); } 
			}

			/// <summary>
			/// Checks whether column ExecDescription is added in select statement 
			/// </summary>
			public bool IsSelectExecDescription { 
				get { return IsSelect("COL1398635658"); } 
				set { SetSelect("COL1398635658", value); } 
			}



	}
}