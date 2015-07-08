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
	public class BD_ParkingTicketInfoData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ1154103152";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of BD_ParkingTicketInfo 
			/// </summary>
			public BD_ParkingTicketInfoData(string objectID): base(objectID) {}  

			public BD_ParkingTicketInfoData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field TicketId 
			/// </summary>
			public string TicketId { 
				get { return GetValue("COL11541031523"); } 
				set { SetValue("COL11541031523", value); } 
			}

			/// <summary>
			/// Gets field Mount 
			/// </summary>
			public string Mount { 
				get { return GetValue("COL11541031526"); } 
				set { SetValue("COL11541031526", value); } 
			}

			/// <summary>
			/// Gets field Modified 
			/// </summary>
			public string Modified { 
				get { return GetValue("COL115410315212"); } 
				set { SetValue("COL115410315212", value); } 
			}

			/// <summary>
			/// Gets field Created 
			/// </summary>
			public string Created { 
				get { return GetValue("COL115410315210"); } 
				set { SetValue("COL115410315210", value); } 
			}

			/// <summary>
			/// Gets field id 
			/// </summary>
			public string id { 
				get { return GetValue("COL11541031521"); } 
				set { SetValue("COL11541031521", value); } 
			}

			/// <summary>
			/// Gets field SerialNoFrom 
			/// </summary>
			public string SerialNoFrom { 
				get { return GetValue("COL11541031524"); } 
				set { SetValue("COL11541031524", value); } 
			}

			/// <summary>
			/// Gets field ModifiedBy 
			/// </summary>
			public string ModifiedBy { 
				get { return GetValue("COL115410315213"); } 
				set { SetValue("COL115410315213", value); } 
			}

			/// <summary>
			/// Gets field Comment 
			/// </summary>
			public string Comment { 
				get { return GetValue("COL11541031529"); } 
				set { SetValue("COL11541031529", value); } 
			}

			/// <summary>
			/// Gets field DelFlag 
			/// </summary>
			public string DelFlag { 
				get { return GetValue("COL115410315214"); } 
				set { SetValue("COL115410315214", value); } 
			}

			/// <summary>
			/// Gets field CreatedBy 
			/// </summary>
			public string CreatedBy { 
				get { return GetValue("COL115410315211"); } 
				set { SetValue("COL115410315211", value); } 
			}

			/// <summary>
			/// Gets field SerialNoTo 
			/// </summary>
			public string SerialNoTo { 
				get { return GetValue("COL11541031525"); } 
				set { SetValue("COL11541031525", value); } 
			}

			/// <summary>
			/// Gets field BuildingId 
			/// </summary>
			public string BuildingId { 
				get { return GetValue("COL11541031522"); } 
				set { SetValue("COL11541031522", value); } 
			}

			/// <summary>
			/// Gets field Price 
			/// </summary>
			public string Price { 
				get { return GetValue("COL11541031527"); } 
				set { SetValue("COL11541031527", value); } 
			}

			/// <summary>
			/// Gets field UsedMount 
			/// </summary>
			public string UsedMount { 
				get { return GetValue("COL11541031528"); } 
				set { SetValue("COL11541031528", value); } 
			}


			/// <summary>
			/// Gets TicketId attribute data 
			/// </summary>
			public AttributeData GetTicketIdAttributeData() { 
				return GetAttributeData("COL11541031523"); 
			}

			/// <summary>
			/// Gets Mount attribute data 
			/// </summary>
			public AttributeData GetMountAttributeData() { 
				return GetAttributeData("COL11541031526"); 
			}

			/// <summary>
			/// Gets Modified attribute data 
			/// </summary>
			public AttributeData GetModifiedAttributeData() { 
				return GetAttributeData("COL115410315212"); 
			}

			/// <summary>
			/// Gets Created attribute data 
			/// </summary>
			public AttributeData GetCreatedAttributeData() { 
				return GetAttributeData("COL115410315210"); 
			}

			/// <summary>
			/// Gets id attribute data 
			/// </summary>
			public AttributeData GetidAttributeData() { 
				return GetAttributeData("COL11541031521"); 
			}

			/// <summary>
			/// Gets SerialNoFrom attribute data 
			/// </summary>
			public AttributeData GetSerialNoFromAttributeData() { 
				return GetAttributeData("COL11541031524"); 
			}

			/// <summary>
			/// Gets ModifiedBy attribute data 
			/// </summary>
			public AttributeData GetModifiedByAttributeData() { 
				return GetAttributeData("COL115410315213"); 
			}

			/// <summary>
			/// Gets Comment attribute data 
			/// </summary>
			public AttributeData GetCommentAttributeData() { 
				return GetAttributeData("COL11541031529"); 
			}

			/// <summary>
			/// Gets DelFlag attribute data 
			/// </summary>
			public AttributeData GetDelFlagAttributeData() { 
				return GetAttributeData("COL115410315214"); 
			}

			/// <summary>
			/// Gets CreatedBy attribute data 
			/// </summary>
			public AttributeData GetCreatedByAttributeData() { 
				return GetAttributeData("COL115410315211"); 
			}

			/// <summary>
			/// Gets SerialNoTo attribute data 
			/// </summary>
			public AttributeData GetSerialNoToAttributeData() { 
				return GetAttributeData("COL11541031525"); 
			}

			/// <summary>
			/// Gets BuildingId attribute data 
			/// </summary>
			public AttributeData GetBuildingIdAttributeData() { 
				return GetAttributeData("COL11541031522"); 
			}

			/// <summary>
			/// Gets Price attribute data 
			/// </summary>
			public AttributeData GetPriceAttributeData() { 
				return GetAttributeData("COL11541031527"); 
			}

			/// <summary>
			/// Gets UsedMount attribute data 
			/// </summary>
			public AttributeData GetUsedMountAttributeData() { 
				return GetAttributeData("COL11541031528"); 
			}


			/// <summary>
			/// Gets column TicketId with alias  
			/// </summary>
			public string ColTicketId { 
				get { return GetColumnName("COL11541031523"); } 
			}

			/// <summary>
			/// Gets column Mount with alias  
			/// </summary>
			public string ColMount { 
				get { return GetColumnName("COL11541031526"); } 
			}

			/// <summary>
			/// Gets column Modified with alias  
			/// </summary>
			public string ColModified { 
				get { return GetColumnName("COL115410315212"); } 
			}

			/// <summary>
			/// Gets column Created with alias  
			/// </summary>
			public string ColCreated { 
				get { return GetColumnName("COL115410315210"); } 
			}

			/// <summary>
			/// Gets column id with alias  
			/// </summary>
			public string Colid { 
				get { return GetColumnName("COL11541031521"); } 
			}

			/// <summary>
			/// Gets column SerialNoFrom with alias  
			/// </summary>
			public string ColSerialNoFrom { 
				get { return GetColumnName("COL11541031524"); } 
			}

			/// <summary>
			/// Gets column ModifiedBy with alias  
			/// </summary>
			public string ColModifiedBy { 
				get { return GetColumnName("COL115410315213"); } 
			}

			/// <summary>
			/// Gets column Comment with alias  
			/// </summary>
			public string ColComment { 
				get { return GetColumnName("COL11541031529"); } 
			}

			/// <summary>
			/// Gets column DelFlag with alias  
			/// </summary>
			public string ColDelFlag { 
				get { return GetColumnName("COL115410315214"); } 
			}

			/// <summary>
			/// Gets column CreatedBy with alias  
			/// </summary>
			public string ColCreatedBy { 
				get { return GetColumnName("COL115410315211"); } 
			}

			/// <summary>
			/// Gets column SerialNoTo with alias  
			/// </summary>
			public string ColSerialNoTo { 
				get { return GetColumnName("COL11541031525"); } 
			}

			/// <summary>
			/// Gets column BuildingId with alias  
			/// </summary>
			public string ColBuildingId { 
				get { return GetColumnName("COL11541031522"); } 
			}

			/// <summary>
			/// Gets column Price with alias  
			/// </summary>
			public string ColPrice { 
				get { return GetColumnName("COL11541031527"); } 
			}

			/// <summary>
			/// Gets column UsedMount with alias  
			/// </summary>
			public string ColUsedMount { 
				get { return GetColumnName("COL11541031528"); } 
			}


			/// <summary>
			/// Checks whether column TicketId is added in select statement 
			/// </summary>
			public bool IsSelectTicketId { 
				get { return IsSelect("COL11541031523"); } 
				set { SetSelect("COL11541031523", value); } 
			}

			/// <summary>
			/// Checks whether column Mount is added in select statement 
			/// </summary>
			public bool IsSelectMount { 
				get { return IsSelect("COL11541031526"); } 
				set { SetSelect("COL11541031526", value); } 
			}

			/// <summary>
			/// Checks whether column Modified is added in select statement 
			/// </summary>
			public bool IsSelectModified { 
				get { return IsSelect("COL115410315212"); } 
				set { SetSelect("COL115410315212", value); } 
			}

			/// <summary>
			/// Checks whether column Created is added in select statement 
			/// </summary>
			public bool IsSelectCreated { 
				get { return IsSelect("COL115410315210"); } 
				set { SetSelect("COL115410315210", value); } 
			}

			/// <summary>
			/// Checks whether column id is added in select statement 
			/// </summary>
			public bool IsSelectid { 
				get { return IsSelect("COL11541031521"); } 
				set { SetSelect("COL11541031521", value); } 
			}

			/// <summary>
			/// Checks whether column SerialNoFrom is added in select statement 
			/// </summary>
			public bool IsSelectSerialNoFrom { 
				get { return IsSelect("COL11541031524"); } 
				set { SetSelect("COL11541031524", value); } 
			}

			/// <summary>
			/// Checks whether column ModifiedBy is added in select statement 
			/// </summary>
			public bool IsSelectModifiedBy { 
				get { return IsSelect("COL115410315213"); } 
				set { SetSelect("COL115410315213", value); } 
			}

			/// <summary>
			/// Checks whether column Comment is added in select statement 
			/// </summary>
			public bool IsSelectComment { 
				get { return IsSelect("COL11541031529"); } 
				set { SetSelect("COL11541031529", value); } 
			}

			/// <summary>
			/// Checks whether column DelFlag is added in select statement 
			/// </summary>
			public bool IsSelectDelFlag { 
				get { return IsSelect("COL115410315214"); } 
				set { SetSelect("COL115410315214", value); } 
			}

			/// <summary>
			/// Checks whether column CreatedBy is added in select statement 
			/// </summary>
			public bool IsSelectCreatedBy { 
				get { return IsSelect("COL115410315211"); } 
				set { SetSelect("COL115410315211", value); } 
			}

			/// <summary>
			/// Checks whether column SerialNoTo is added in select statement 
			/// </summary>
			public bool IsSelectSerialNoTo { 
				get { return IsSelect("COL11541031525"); } 
				set { SetSelect("COL11541031525", value); } 
			}

			/// <summary>
			/// Checks whether column BuildingId is added in select statement 
			/// </summary>
			public bool IsSelectBuildingId { 
				get { return IsSelect("COL11541031522"); } 
				set { SetSelect("COL11541031522", value); } 
			}

			/// <summary>
			/// Checks whether column Price is added in select statement 
			/// </summary>
			public bool IsSelectPrice { 
				get { return IsSelect("COL11541031527"); } 
				set { SetSelect("COL11541031527", value); } 
			}

			/// <summary>
			/// Checks whether column UsedMount is added in select statement 
			/// </summary>
			public bool IsSelectUsedMount { 
				get { return IsSelect("COL11541031528"); } 
				set { SetSelect("COL11541031528", value); } 
			}



	}
}