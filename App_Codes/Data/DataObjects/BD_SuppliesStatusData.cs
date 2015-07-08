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
	public class BD_SuppliesStatusData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ1483868353";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of BD_SuppliesStatus 
			/// </summary>
			public BD_SuppliesStatusData(string objectID): base(objectID) {}  

			public BD_SuppliesStatusData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field DelFlag 
			/// </summary>
			public string DelFlag { 
				get { return GetValue("COL148386835313"); } 
				set { SetValue("COL148386835313", value); } 
			}

			/// <summary>
			/// Gets field CreatedBy 
			/// </summary>
			public string CreatedBy { 
				get { return GetValue("COL148386835310"); } 
				set { SetValue("COL148386835310", value); } 
			}

			/// <summary>
			/// Gets field Room 
			/// </summary>
			public string Room { 
				get { return GetValue("COL148386835317"); } 
				set { SetValue("COL148386835317", value); } 
			}

			/// <summary>
			/// Gets field Solution 
			/// </summary>
			public string Solution { 
				get { return GetValue("COL14838683536"); } 
				set { SetValue("COL14838683536", value); } 
			}

			/// <summary>
			/// Gets field Floor 
			/// </summary>
			public string Floor { 
				get { return GetValue("COL148386835316"); } 
				set { SetValue("COL148386835316", value); } 
			}

			/// <summary>
			/// Gets field Description 
			/// </summary>
			public string Description { 
				get { return GetValue("COL14838683535"); } 
				set { SetValue("COL14838683535", value); } 
			}

			/// <summary>
			/// Gets field Region 
			/// </summary>
			public string Region { 
				get { return GetValue("COL148386835315"); } 
				set { SetValue("COL148386835315", value); } 
			}

			/// <summary>
			/// Gets field ModifiedBy 
			/// </summary>
			public string ModifiedBy { 
				get { return GetValue("COL148386835312"); } 
				set { SetValue("COL148386835312", value); } 
			}

			/// <summary>
			/// Gets field Solutioner 
			/// </summary>
			public string Solutioner { 
				get { return GetValue("COL14838683537"); } 
				set { SetValue("COL14838683537", value); } 
			}

			/// <summary>
			/// Gets field SuppliesId 
			/// </summary>
			public string SuppliesId { 
				get { return GetValue("COL14838683532"); } 
				set { SetValue("COL14838683532", value); } 
			}

			/// <summary>
			/// Gets field Modified 
			/// </summary>
			public string Modified { 
				get { return GetValue("COL148386835311"); } 
				set { SetValue("COL148386835311", value); } 
			}

			/// <summary>
			/// Gets field Comment 
			/// </summary>
			public string Comment { 
				get { return GetValue("COL14838683538"); } 
				set { SetValue("COL14838683538", value); } 
			}

			/// <summary>
			/// Gets field Created 
			/// </summary>
			public string Created { 
				get { return GetValue("COL14838683539"); } 
				set { SetValue("COL14838683539", value); } 
			}

			/// <summary>
			/// Gets field id 
			/// </summary>
			public string id { 
				get { return GetValue("COL14838683531"); } 
				set { SetValue("COL14838683531", value); } 
			}

			/// <summary>
			/// Gets field System 
			/// </summary>
			public string System { 
				get { return GetValue("COL148386835314"); } 
				set { SetValue("COL148386835314", value); } 
			}

			/// <summary>
			/// Gets field SuppliesStatus 
			/// </summary>
			public string SuppliesStatus { 
				get { return GetValue("COL14838683534"); } 
				set { SetValue("COL14838683534", value); } 
			}

			/// <summary>
			/// Gets field ProcessDate 
			/// </summary>
			public string ProcessDate { 
				get { return GetValue("COL14838683533"); } 
				set { SetValue("COL14838683533", value); } 
			}


			/// <summary>
			/// Gets DelFlag attribute data 
			/// </summary>
			public AttributeData GetDelFlagAttributeData() { 
				return GetAttributeData("COL148386835313"); 
			}

			/// <summary>
			/// Gets CreatedBy attribute data 
			/// </summary>
			public AttributeData GetCreatedByAttributeData() { 
				return GetAttributeData("COL148386835310"); 
			}

			/// <summary>
			/// Gets Room attribute data 
			/// </summary>
			public AttributeData GetRoomAttributeData() { 
				return GetAttributeData("COL148386835317"); 
			}

			/// <summary>
			/// Gets Solution attribute data 
			/// </summary>
			public AttributeData GetSolutionAttributeData() { 
				return GetAttributeData("COL14838683536"); 
			}

			/// <summary>
			/// Gets Floor attribute data 
			/// </summary>
			public AttributeData GetFloorAttributeData() { 
				return GetAttributeData("COL148386835316"); 
			}

			/// <summary>
			/// Gets Description attribute data 
			/// </summary>
			public AttributeData GetDescriptionAttributeData() { 
				return GetAttributeData("COL14838683535"); 
			}

			/// <summary>
			/// Gets Region attribute data 
			/// </summary>
			public AttributeData GetRegionAttributeData() { 
				return GetAttributeData("COL148386835315"); 
			}

			/// <summary>
			/// Gets ModifiedBy attribute data 
			/// </summary>
			public AttributeData GetModifiedByAttributeData() { 
				return GetAttributeData("COL148386835312"); 
			}

			/// <summary>
			/// Gets Solutioner attribute data 
			/// </summary>
			public AttributeData GetSolutionerAttributeData() { 
				return GetAttributeData("COL14838683537"); 
			}

			/// <summary>
			/// Gets SuppliesId attribute data 
			/// </summary>
			public AttributeData GetSuppliesIdAttributeData() { 
				return GetAttributeData("COL14838683532"); 
			}

			/// <summary>
			/// Gets Modified attribute data 
			/// </summary>
			public AttributeData GetModifiedAttributeData() { 
				return GetAttributeData("COL148386835311"); 
			}

			/// <summary>
			/// Gets Comment attribute data 
			/// </summary>
			public AttributeData GetCommentAttributeData() { 
				return GetAttributeData("COL14838683538"); 
			}

			/// <summary>
			/// Gets Created attribute data 
			/// </summary>
			public AttributeData GetCreatedAttributeData() { 
				return GetAttributeData("COL14838683539"); 
			}

			/// <summary>
			/// Gets id attribute data 
			/// </summary>
			public AttributeData GetidAttributeData() { 
				return GetAttributeData("COL14838683531"); 
			}

			/// <summary>
			/// Gets System attribute data 
			/// </summary>
			public AttributeData GetSystemAttributeData() { 
				return GetAttributeData("COL148386835314"); 
			}

			/// <summary>
			/// Gets SuppliesStatus attribute data 
			/// </summary>
			public AttributeData GetSuppliesStatusAttributeData() { 
				return GetAttributeData("COL14838683534"); 
			}

			/// <summary>
			/// Gets ProcessDate attribute data 
			/// </summary>
			public AttributeData GetProcessDateAttributeData() { 
				return GetAttributeData("COL14838683533"); 
			}


			/// <summary>
			/// Gets column DelFlag with alias  
			/// </summary>
			public string ColDelFlag { 
				get { return GetColumnName("COL148386835313"); } 
			}

			/// <summary>
			/// Gets column CreatedBy with alias  
			/// </summary>
			public string ColCreatedBy { 
				get { return GetColumnName("COL148386835310"); } 
			}

			/// <summary>
			/// Gets column Room with alias  
			/// </summary>
			public string ColRoom { 
				get { return GetColumnName("COL148386835317"); } 
			}

			/// <summary>
			/// Gets column Solution with alias  
			/// </summary>
			public string ColSolution { 
				get { return GetColumnName("COL14838683536"); } 
			}

			/// <summary>
			/// Gets column Floor with alias  
			/// </summary>
			public string ColFloor { 
				get { return GetColumnName("COL148386835316"); } 
			}

			/// <summary>
			/// Gets column Description with alias  
			/// </summary>
			public string ColDescription { 
				get { return GetColumnName("COL14838683535"); } 
			}

			/// <summary>
			/// Gets column Region with alias  
			/// </summary>
			public string ColRegion { 
				get { return GetColumnName("COL148386835315"); } 
			}

			/// <summary>
			/// Gets column ModifiedBy with alias  
			/// </summary>
			public string ColModifiedBy { 
				get { return GetColumnName("COL148386835312"); } 
			}

			/// <summary>
			/// Gets column Solutioner with alias  
			/// </summary>
			public string ColSolutioner { 
				get { return GetColumnName("COL14838683537"); } 
			}

			/// <summary>
			/// Gets column SuppliesId with alias  
			/// </summary>
			public string ColSuppliesId { 
				get { return GetColumnName("COL14838683532"); } 
			}

			/// <summary>
			/// Gets column Modified with alias  
			/// </summary>
			public string ColModified { 
				get { return GetColumnName("COL148386835311"); } 
			}

			/// <summary>
			/// Gets column Comment with alias  
			/// </summary>
			public string ColComment { 
				get { return GetColumnName("COL14838683538"); } 
			}

			/// <summary>
			/// Gets column Created with alias  
			/// </summary>
			public string ColCreated { 
				get { return GetColumnName("COL14838683539"); } 
			}

			/// <summary>
			/// Gets column id with alias  
			/// </summary>
			public string Colid { 
				get { return GetColumnName("COL14838683531"); } 
			}

			/// <summary>
			/// Gets column System with alias  
			/// </summary>
			public string ColSystem { 
				get { return GetColumnName("COL148386835314"); } 
			}

			/// <summary>
			/// Gets column SuppliesStatus with alias  
			/// </summary>
			public string ColSuppliesStatus { 
				get { return GetColumnName("COL14838683534"); } 
			}

			/// <summary>
			/// Gets column ProcessDate with alias  
			/// </summary>
			public string ColProcessDate { 
				get { return GetColumnName("COL14838683533"); } 
			}


			/// <summary>
			/// Checks whether column DelFlag is added in select statement 
			/// </summary>
			public bool IsSelectDelFlag { 
				get { return IsSelect("COL148386835313"); } 
				set { SetSelect("COL148386835313", value); } 
			}

			/// <summary>
			/// Checks whether column CreatedBy is added in select statement 
			/// </summary>
			public bool IsSelectCreatedBy { 
				get { return IsSelect("COL148386835310"); } 
				set { SetSelect("COL148386835310", value); } 
			}

			/// <summary>
			/// Checks whether column Room is added in select statement 
			/// </summary>
			public bool IsSelectRoom { 
				get { return IsSelect("COL148386835317"); } 
				set { SetSelect("COL148386835317", value); } 
			}

			/// <summary>
			/// Checks whether column Solution is added in select statement 
			/// </summary>
			public bool IsSelectSolution { 
				get { return IsSelect("COL14838683536"); } 
				set { SetSelect("COL14838683536", value); } 
			}

			/// <summary>
			/// Checks whether column Floor is added in select statement 
			/// </summary>
			public bool IsSelectFloor { 
				get { return IsSelect("COL148386835316"); } 
				set { SetSelect("COL148386835316", value); } 
			}

			/// <summary>
			/// Checks whether column Description is added in select statement 
			/// </summary>
			public bool IsSelectDescription { 
				get { return IsSelect("COL14838683535"); } 
				set { SetSelect("COL14838683535", value); } 
			}

			/// <summary>
			/// Checks whether column Region is added in select statement 
			/// </summary>
			public bool IsSelectRegion { 
				get { return IsSelect("COL148386835315"); } 
				set { SetSelect("COL148386835315", value); } 
			}

			/// <summary>
			/// Checks whether column ModifiedBy is added in select statement 
			/// </summary>
			public bool IsSelectModifiedBy { 
				get { return IsSelect("COL148386835312"); } 
				set { SetSelect("COL148386835312", value); } 
			}

			/// <summary>
			/// Checks whether column Solutioner is added in select statement 
			/// </summary>
			public bool IsSelectSolutioner { 
				get { return IsSelect("COL14838683537"); } 
				set { SetSelect("COL14838683537", value); } 
			}

			/// <summary>
			/// Checks whether column SuppliesId is added in select statement 
			/// </summary>
			public bool IsSelectSuppliesId { 
				get { return IsSelect("COL14838683532"); } 
				set { SetSelect("COL14838683532", value); } 
			}

			/// <summary>
			/// Checks whether column Modified is added in select statement 
			/// </summary>
			public bool IsSelectModified { 
				get { return IsSelect("COL148386835311"); } 
				set { SetSelect("COL148386835311", value); } 
			}

			/// <summary>
			/// Checks whether column Comment is added in select statement 
			/// </summary>
			public bool IsSelectComment { 
				get { return IsSelect("COL14838683538"); } 
				set { SetSelect("COL14838683538", value); } 
			}

			/// <summary>
			/// Checks whether column Created is added in select statement 
			/// </summary>
			public bool IsSelectCreated { 
				get { return IsSelect("COL14838683539"); } 
				set { SetSelect("COL14838683539", value); } 
			}

			/// <summary>
			/// Checks whether column id is added in select statement 
			/// </summary>
			public bool IsSelectid { 
				get { return IsSelect("COL14838683531"); } 
				set { SetSelect("COL14838683531", value); } 
			}

			/// <summary>
			/// Checks whether column System is added in select statement 
			/// </summary>
			public bool IsSelectSystem { 
				get { return IsSelect("COL148386835314"); } 
				set { SetSelect("COL148386835314", value); } 
			}

			/// <summary>
			/// Checks whether column SuppliesStatus is added in select statement 
			/// </summary>
			public bool IsSelectSuppliesStatus { 
				get { return IsSelect("COL14838683534"); } 
				set { SetSelect("COL14838683534", value); } 
			}

			/// <summary>
			/// Checks whether column ProcessDate is added in select statement 
			/// </summary>
			public bool IsSelectProcessDate { 
				get { return IsSelect("COL14838683533"); } 
				set { SetSelect("COL14838683533", value); } 
			}



	}
}