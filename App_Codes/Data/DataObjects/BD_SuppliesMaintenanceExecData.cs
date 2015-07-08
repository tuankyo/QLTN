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
	public class BD_SuppliesMaintenanceExecData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ2127346643";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of BD_SuppliesMaintenanceExec 
			/// </summary>
			public BD_SuppliesMaintenanceExecData(string objectID): base(objectID) {}  

			public BD_SuppliesMaintenanceExecData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field Modified 
			/// </summary>
			public string Modified { 
				get { return GetValue("COL21273466438"); } 
				set { SetValue("COL21273466438", value); } 
			}

			/// <summary>
			/// Gets field Comment 
			/// </summary>
			public string Comment { 
				get { return GetValue("COL21273466435"); } 
				set { SetValue("COL21273466435", value); } 
			}

			/// <summary>
			/// Gets field CreatedBy 
			/// </summary>
			public string CreatedBy { 
				get { return GetValue("COL21273466437"); } 
				set { SetValue("COL21273466437", value); } 
			}

			/// <summary>
			/// Gets field MaintenanceItemId 
			/// </summary>
			public string MaintenanceItemId { 
				get { return GetValue("COL21273466432"); } 
				set { SetValue("COL21273466432", value); } 
			}

			/// <summary>
			/// Gets field ModifiedBy 
			/// </summary>
			public string ModifiedBy { 
				get { return GetValue("COL21273466439"); } 
				set { SetValue("COL21273466439", value); } 
			}

			/// <summary>
			/// Gets field id 
			/// </summary>
			public string id { 
				get { return GetValue("COL21273466431"); } 
				set { SetValue("COL21273466431", value); } 
			}

			/// <summary>
			/// Gets field DelFlag 
			/// </summary>
			public string DelFlag { 
				get { return GetValue("COL212734664310"); } 
				set { SetValue("COL212734664310", value); } 
			}

			/// <summary>
			/// Gets field RealDate 
			/// </summary>
			public string RealDate { 
				get { return GetValue("COL21273466434"); } 
				set { SetValue("COL21273466434", value); } 
			}

			/// <summary>
			/// Gets field ScheduleDate 
			/// </summary>
			public string ScheduleDate { 
				get { return GetValue("COL21273466433"); } 
				set { SetValue("COL21273466433", value); } 
			}

			/// <summary>
			/// Gets field Created 
			/// </summary>
			public string Created { 
				get { return GetValue("COL21273466436"); } 
				set { SetValue("COL21273466436", value); } 
			}


			/// <summary>
			/// Gets Modified attribute data 
			/// </summary>
			public AttributeData GetModifiedAttributeData() { 
				return GetAttributeData("COL21273466438"); 
			}

			/// <summary>
			/// Gets Comment attribute data 
			/// </summary>
			public AttributeData GetCommentAttributeData() { 
				return GetAttributeData("COL21273466435"); 
			}

			/// <summary>
			/// Gets CreatedBy attribute data 
			/// </summary>
			public AttributeData GetCreatedByAttributeData() { 
				return GetAttributeData("COL21273466437"); 
			}

			/// <summary>
			/// Gets MaintenanceItemId attribute data 
			/// </summary>
			public AttributeData GetMaintenanceItemIdAttributeData() { 
				return GetAttributeData("COL21273466432"); 
			}

			/// <summary>
			/// Gets ModifiedBy attribute data 
			/// </summary>
			public AttributeData GetModifiedByAttributeData() { 
				return GetAttributeData("COL21273466439"); 
			}

			/// <summary>
			/// Gets id attribute data 
			/// </summary>
			public AttributeData GetidAttributeData() { 
				return GetAttributeData("COL21273466431"); 
			}

			/// <summary>
			/// Gets DelFlag attribute data 
			/// </summary>
			public AttributeData GetDelFlagAttributeData() { 
				return GetAttributeData("COL212734664310"); 
			}

			/// <summary>
			/// Gets RealDate attribute data 
			/// </summary>
			public AttributeData GetRealDateAttributeData() { 
				return GetAttributeData("COL21273466434"); 
			}

			/// <summary>
			/// Gets ScheduleDate attribute data 
			/// </summary>
			public AttributeData GetScheduleDateAttributeData() { 
				return GetAttributeData("COL21273466433"); 
			}

			/// <summary>
			/// Gets Created attribute data 
			/// </summary>
			public AttributeData GetCreatedAttributeData() { 
				return GetAttributeData("COL21273466436"); 
			}


			/// <summary>
			/// Gets column Modified with alias  
			/// </summary>
			public string ColModified { 
				get { return GetColumnName("COL21273466438"); } 
			}

			/// <summary>
			/// Gets column Comment with alias  
			/// </summary>
			public string ColComment { 
				get { return GetColumnName("COL21273466435"); } 
			}

			/// <summary>
			/// Gets column CreatedBy with alias  
			/// </summary>
			public string ColCreatedBy { 
				get { return GetColumnName("COL21273466437"); } 
			}

			/// <summary>
			/// Gets column MaintenanceItemId with alias  
			/// </summary>
			public string ColMaintenanceItemId { 
				get { return GetColumnName("COL21273466432"); } 
			}

			/// <summary>
			/// Gets column ModifiedBy with alias  
			/// </summary>
			public string ColModifiedBy { 
				get { return GetColumnName("COL21273466439"); } 
			}

			/// <summary>
			/// Gets column id with alias  
			/// </summary>
			public string Colid { 
				get { return GetColumnName("COL21273466431"); } 
			}

			/// <summary>
			/// Gets column DelFlag with alias  
			/// </summary>
			public string ColDelFlag { 
				get { return GetColumnName("COL212734664310"); } 
			}

			/// <summary>
			/// Gets column RealDate with alias  
			/// </summary>
			public string ColRealDate { 
				get { return GetColumnName("COL21273466434"); } 
			}

			/// <summary>
			/// Gets column ScheduleDate with alias  
			/// </summary>
			public string ColScheduleDate { 
				get { return GetColumnName("COL21273466433"); } 
			}

			/// <summary>
			/// Gets column Created with alias  
			/// </summary>
			public string ColCreated { 
				get { return GetColumnName("COL21273466436"); } 
			}


			/// <summary>
			/// Checks whether column Modified is added in select statement 
			/// </summary>
			public bool IsSelectModified { 
				get { return IsSelect("COL21273466438"); } 
				set { SetSelect("COL21273466438", value); } 
			}

			/// <summary>
			/// Checks whether column Comment is added in select statement 
			/// </summary>
			public bool IsSelectComment { 
				get { return IsSelect("COL21273466435"); } 
				set { SetSelect("COL21273466435", value); } 
			}

			/// <summary>
			/// Checks whether column CreatedBy is added in select statement 
			/// </summary>
			public bool IsSelectCreatedBy { 
				get { return IsSelect("COL21273466437"); } 
				set { SetSelect("COL21273466437", value); } 
			}

			/// <summary>
			/// Checks whether column MaintenanceItemId is added in select statement 
			/// </summary>
			public bool IsSelectMaintenanceItemId { 
				get { return IsSelect("COL21273466432"); } 
				set { SetSelect("COL21273466432", value); } 
			}

			/// <summary>
			/// Checks whether column ModifiedBy is added in select statement 
			/// </summary>
			public bool IsSelectModifiedBy { 
				get { return IsSelect("COL21273466439"); } 
				set { SetSelect("COL21273466439", value); } 
			}

			/// <summary>
			/// Checks whether column id is added in select statement 
			/// </summary>
			public bool IsSelectid { 
				get { return IsSelect("COL21273466431"); } 
				set { SetSelect("COL21273466431", value); } 
			}

			/// <summary>
			/// Checks whether column DelFlag is added in select statement 
			/// </summary>
			public bool IsSelectDelFlag { 
				get { return IsSelect("COL212734664310"); } 
				set { SetSelect("COL212734664310", value); } 
			}

			/// <summary>
			/// Checks whether column RealDate is added in select statement 
			/// </summary>
			public bool IsSelectRealDate { 
				get { return IsSelect("COL21273466434"); } 
				set { SetSelect("COL21273466434", value); } 
			}

			/// <summary>
			/// Checks whether column ScheduleDate is added in select statement 
			/// </summary>
			public bool IsSelectScheduleDate { 
				get { return IsSelect("COL21273466433"); } 
				set { SetSelect("COL21273466433", value); } 
			}

			/// <summary>
			/// Checks whether column Created is added in select statement 
			/// </summary>
			public bool IsSelectCreated { 
				get { return IsSelect("COL21273466436"); } 
				set { SetSelect("COL21273466436", value); } 
			}



	}
}