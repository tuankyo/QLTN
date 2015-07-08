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
	public class BD_StatusInfoData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ1176391260";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of BD_StatusInfo 
			/// </summary>
			public BD_StatusInfoData(string objectID): base(objectID) {}  

			public BD_StatusInfoData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field Solution 
			/// </summary>
			public string Solution { 
				get { return GetValue("COL11763912609"); } 
				set { SetValue("COL11763912609", value); } 
			}

			/// <summary>
			/// Gets field Solutioner 
			/// </summary>
			public string Solutioner { 
				get { return GetValue("COL117639126010"); } 
				set { SetValue("COL117639126010", value); } 
			}

			/// <summary>
			/// Gets field Created 
			/// </summary>
			public string Created { 
				get { return GetValue("COL117639126012"); } 
				set { SetValue("COL117639126012", value); } 
			}

			/// <summary>
			/// Gets field Floor 
			/// </summary>
			public string Floor { 
				get { return GetValue("COL11763912604"); } 
				set { SetValue("COL11763912604", value); } 
			}

			/// <summary>
			/// Gets field CreatedBy 
			/// </summary>
			public string CreatedBy { 
				get { return GetValue("COL117639126013"); } 
				set { SetValue("COL117639126013", value); } 
			}

			/// <summary>
			/// Gets field StatusDate 
			/// </summary>
			public string StatusDate { 
				get { return GetValue("COL11763912607"); } 
				set { SetValue("COL11763912607", value); } 
			}

			/// <summary>
			/// Gets field Modified 
			/// </summary>
			public string Modified { 
				get { return GetValue("COL117639126014"); } 
				set { SetValue("COL117639126014", value); } 
			}

			/// <summary>
			/// Gets field ModifiedBy 
			/// </summary>
			public string ModifiedBy { 
				get { return GetValue("COL117639126015"); } 
				set { SetValue("COL117639126015", value); } 
			}

			/// <summary>
			/// Gets field Type 
			/// </summary>
			public string Type { 
				get { return GetValue("COL117639126018"); } 
				set { SetValue("COL117639126018", value); } 
			}

			/// <summary>
			/// Gets field DelFlag 
			/// </summary>
			public string DelFlag { 
				get { return GetValue("COL117639126016"); } 
				set { SetValue("COL117639126016", value); } 
			}

			/// <summary>
			/// Gets field Room 
			/// </summary>
			public string Room { 
				get { return GetValue("COL11763912605"); } 
				set { SetValue("COL11763912605", value); } 
			}

			/// <summary>
			/// Gets field Comment 
			/// </summary>
			public string Comment { 
				get { return GetValue("COL117639126011"); } 
				set { SetValue("COL117639126011", value); } 
			}

			/// <summary>
			/// Gets field Description 
			/// </summary>
			public string Description { 
				get { return GetValue("COL11763912608"); } 
				set { SetValue("COL11763912608", value); } 
			}

			/// <summary>
			/// Gets field BuildingId 
			/// </summary>
			public string BuildingId { 
				get { return GetValue("COL11763912602"); } 
				set { SetValue("COL11763912602", value); } 
			}

			/// <summary>
			/// Gets field Region 
			/// </summary>
			public string Region { 
				get { return GetValue("COL11763912603"); } 
				set { SetValue("COL11763912603", value); } 
			}

			/// <summary>
			/// Gets field Status 
			/// </summary>
			public string Status { 
				get { return GetValue("COL11763912606"); } 
				set { SetValue("COL11763912606", value); } 
			}

			/// <summary>
			/// Gets field System 
			/// </summary>
			public string System { 
				get { return GetValue("COL117639126017"); } 
				set { SetValue("COL117639126017", value); } 
			}

			/// <summary>
			/// Gets field id 
			/// </summary>
			public string id { 
				get { return GetValue("COL11763912601"); } 
				set { SetValue("COL11763912601", value); } 
			}


			/// <summary>
			/// Gets Solution attribute data 
			/// </summary>
			public AttributeData GetSolutionAttributeData() { 
				return GetAttributeData("COL11763912609"); 
			}

			/// <summary>
			/// Gets Solutioner attribute data 
			/// </summary>
			public AttributeData GetSolutionerAttributeData() { 
				return GetAttributeData("COL117639126010"); 
			}

			/// <summary>
			/// Gets Created attribute data 
			/// </summary>
			public AttributeData GetCreatedAttributeData() { 
				return GetAttributeData("COL117639126012"); 
			}

			/// <summary>
			/// Gets Floor attribute data 
			/// </summary>
			public AttributeData GetFloorAttributeData() { 
				return GetAttributeData("COL11763912604"); 
			}

			/// <summary>
			/// Gets CreatedBy attribute data 
			/// </summary>
			public AttributeData GetCreatedByAttributeData() { 
				return GetAttributeData("COL117639126013"); 
			}

			/// <summary>
			/// Gets StatusDate attribute data 
			/// </summary>
			public AttributeData GetStatusDateAttributeData() { 
				return GetAttributeData("COL11763912607"); 
			}

			/// <summary>
			/// Gets Modified attribute data 
			/// </summary>
			public AttributeData GetModifiedAttributeData() { 
				return GetAttributeData("COL117639126014"); 
			}

			/// <summary>
			/// Gets ModifiedBy attribute data 
			/// </summary>
			public AttributeData GetModifiedByAttributeData() { 
				return GetAttributeData("COL117639126015"); 
			}

			/// <summary>
			/// Gets Type attribute data 
			/// </summary>
			public AttributeData GetTypeAttributeData() { 
				return GetAttributeData("COL117639126018"); 
			}

			/// <summary>
			/// Gets DelFlag attribute data 
			/// </summary>
			public AttributeData GetDelFlagAttributeData() { 
				return GetAttributeData("COL117639126016"); 
			}

			/// <summary>
			/// Gets Room attribute data 
			/// </summary>
			public AttributeData GetRoomAttributeData() { 
				return GetAttributeData("COL11763912605"); 
			}

			/// <summary>
			/// Gets Comment attribute data 
			/// </summary>
			public AttributeData GetCommentAttributeData() { 
				return GetAttributeData("COL117639126011"); 
			}

			/// <summary>
			/// Gets Description attribute data 
			/// </summary>
			public AttributeData GetDescriptionAttributeData() { 
				return GetAttributeData("COL11763912608"); 
			}

			/// <summary>
			/// Gets BuildingId attribute data 
			/// </summary>
			public AttributeData GetBuildingIdAttributeData() { 
				return GetAttributeData("COL11763912602"); 
			}

			/// <summary>
			/// Gets Region attribute data 
			/// </summary>
			public AttributeData GetRegionAttributeData() { 
				return GetAttributeData("COL11763912603"); 
			}

			/// <summary>
			/// Gets Status attribute data 
			/// </summary>
			public AttributeData GetStatusAttributeData() { 
				return GetAttributeData("COL11763912606"); 
			}

			/// <summary>
			/// Gets System attribute data 
			/// </summary>
			public AttributeData GetSystemAttributeData() { 
				return GetAttributeData("COL117639126017"); 
			}

			/// <summary>
			/// Gets id attribute data 
			/// </summary>
			public AttributeData GetidAttributeData() { 
				return GetAttributeData("COL11763912601"); 
			}


			/// <summary>
			/// Gets column Solution with alias  
			/// </summary>
			public string ColSolution { 
				get { return GetColumnName("COL11763912609"); } 
			}

			/// <summary>
			/// Gets column Solutioner with alias  
			/// </summary>
			public string ColSolutioner { 
				get { return GetColumnName("COL117639126010"); } 
			}

			/// <summary>
			/// Gets column Created with alias  
			/// </summary>
			public string ColCreated { 
				get { return GetColumnName("COL117639126012"); } 
			}

			/// <summary>
			/// Gets column Floor with alias  
			/// </summary>
			public string ColFloor { 
				get { return GetColumnName("COL11763912604"); } 
			}

			/// <summary>
			/// Gets column CreatedBy with alias  
			/// </summary>
			public string ColCreatedBy { 
				get { return GetColumnName("COL117639126013"); } 
			}

			/// <summary>
			/// Gets column StatusDate with alias  
			/// </summary>
			public string ColStatusDate { 
				get { return GetColumnName("COL11763912607"); } 
			}

			/// <summary>
			/// Gets column Modified with alias  
			/// </summary>
			public string ColModified { 
				get { return GetColumnName("COL117639126014"); } 
			}

			/// <summary>
			/// Gets column ModifiedBy with alias  
			/// </summary>
			public string ColModifiedBy { 
				get { return GetColumnName("COL117639126015"); } 
			}

			/// <summary>
			/// Gets column Type with alias  
			/// </summary>
			public string ColType { 
				get { return GetColumnName("COL117639126018"); } 
			}

			/// <summary>
			/// Gets column DelFlag with alias  
			/// </summary>
			public string ColDelFlag { 
				get { return GetColumnName("COL117639126016"); } 
			}

			/// <summary>
			/// Gets column Room with alias  
			/// </summary>
			public string ColRoom { 
				get { return GetColumnName("COL11763912605"); } 
			}

			/// <summary>
			/// Gets column Comment with alias  
			/// </summary>
			public string ColComment { 
				get { return GetColumnName("COL117639126011"); } 
			}

			/// <summary>
			/// Gets column Description with alias  
			/// </summary>
			public string ColDescription { 
				get { return GetColumnName("COL11763912608"); } 
			}

			/// <summary>
			/// Gets column BuildingId with alias  
			/// </summary>
			public string ColBuildingId { 
				get { return GetColumnName("COL11763912602"); } 
			}

			/// <summary>
			/// Gets column Region with alias  
			/// </summary>
			public string ColRegion { 
				get { return GetColumnName("COL11763912603"); } 
			}

			/// <summary>
			/// Gets column Status with alias  
			/// </summary>
			public string ColStatus { 
				get { return GetColumnName("COL11763912606"); } 
			}

			/// <summary>
			/// Gets column System with alias  
			/// </summary>
			public string ColSystem { 
				get { return GetColumnName("COL117639126017"); } 
			}

			/// <summary>
			/// Gets column id with alias  
			/// </summary>
			public string Colid { 
				get { return GetColumnName("COL11763912601"); } 
			}


			/// <summary>
			/// Checks whether column Solution is added in select statement 
			/// </summary>
			public bool IsSelectSolution { 
				get { return IsSelect("COL11763912609"); } 
				set { SetSelect("COL11763912609", value); } 
			}

			/// <summary>
			/// Checks whether column Solutioner is added in select statement 
			/// </summary>
			public bool IsSelectSolutioner { 
				get { return IsSelect("COL117639126010"); } 
				set { SetSelect("COL117639126010", value); } 
			}

			/// <summary>
			/// Checks whether column Created is added in select statement 
			/// </summary>
			public bool IsSelectCreated { 
				get { return IsSelect("COL117639126012"); } 
				set { SetSelect("COL117639126012", value); } 
			}

			/// <summary>
			/// Checks whether column Floor is added in select statement 
			/// </summary>
			public bool IsSelectFloor { 
				get { return IsSelect("COL11763912604"); } 
				set { SetSelect("COL11763912604", value); } 
			}

			/// <summary>
			/// Checks whether column CreatedBy is added in select statement 
			/// </summary>
			public bool IsSelectCreatedBy { 
				get { return IsSelect("COL117639126013"); } 
				set { SetSelect("COL117639126013", value); } 
			}

			/// <summary>
			/// Checks whether column StatusDate is added in select statement 
			/// </summary>
			public bool IsSelectStatusDate { 
				get { return IsSelect("COL11763912607"); } 
				set { SetSelect("COL11763912607", value); } 
			}

			/// <summary>
			/// Checks whether column Modified is added in select statement 
			/// </summary>
			public bool IsSelectModified { 
				get { return IsSelect("COL117639126014"); } 
				set { SetSelect("COL117639126014", value); } 
			}

			/// <summary>
			/// Checks whether column ModifiedBy is added in select statement 
			/// </summary>
			public bool IsSelectModifiedBy { 
				get { return IsSelect("COL117639126015"); } 
				set { SetSelect("COL117639126015", value); } 
			}

			/// <summary>
			/// Checks whether column Type is added in select statement 
			/// </summary>
			public bool IsSelectType { 
				get { return IsSelect("COL117639126018"); } 
				set { SetSelect("COL117639126018", value); } 
			}

			/// <summary>
			/// Checks whether column DelFlag is added in select statement 
			/// </summary>
			public bool IsSelectDelFlag { 
				get { return IsSelect("COL117639126016"); } 
				set { SetSelect("COL117639126016", value); } 
			}

			/// <summary>
			/// Checks whether column Room is added in select statement 
			/// </summary>
			public bool IsSelectRoom { 
				get { return IsSelect("COL11763912605"); } 
				set { SetSelect("COL11763912605", value); } 
			}

			/// <summary>
			/// Checks whether column Comment is added in select statement 
			/// </summary>
			public bool IsSelectComment { 
				get { return IsSelect("COL117639126011"); } 
				set { SetSelect("COL117639126011", value); } 
			}

			/// <summary>
			/// Checks whether column Description is added in select statement 
			/// </summary>
			public bool IsSelectDescription { 
				get { return IsSelect("COL11763912608"); } 
				set { SetSelect("COL11763912608", value); } 
			}

			/// <summary>
			/// Checks whether column BuildingId is added in select statement 
			/// </summary>
			public bool IsSelectBuildingId { 
				get { return IsSelect("COL11763912602"); } 
				set { SetSelect("COL11763912602", value); } 
			}

			/// <summary>
			/// Checks whether column Region is added in select statement 
			/// </summary>
			public bool IsSelectRegion { 
				get { return IsSelect("COL11763912603"); } 
				set { SetSelect("COL11763912603", value); } 
			}

			/// <summary>
			/// Checks whether column Status is added in select statement 
			/// </summary>
			public bool IsSelectStatus { 
				get { return IsSelect("COL11763912606"); } 
				set { SetSelect("COL11763912606", value); } 
			}

			/// <summary>
			/// Checks whether column System is added in select statement 
			/// </summary>
			public bool IsSelectSystem { 
				get { return IsSelect("COL117639126017"); } 
				set { SetSelect("COL117639126017", value); } 
			}

			/// <summary>
			/// Checks whether column id is added in select statement 
			/// </summary>
			public bool IsSelectid { 
				get { return IsSelect("COL11763912601"); } 
				set { SetSelect("COL11763912601", value); } 
			}



	}
}