// ==========================================
//  Author : GNT Data Object Generator Tool
//  Created   : 2014-10-20 13:46:19
//  Copyright GNT INC.  All rights reserved.
// ==========================================
using System;
using System.Collections;
using Gnt.Data.Meta;
using Gnt.Data;

namespace BusinessObjects
{

	[Serializable]
	public class CustomerParkingData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ386100416";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of CustomerParking 
			/// </summary>
			public CustomerParkingData(string objectID): base(objectID) {}  

			public CustomerParkingData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field Comment 
			/// </summary>
			public string Comment { 
				get { return GetValue("COL38610041610"); } 
				set { SetValue("COL38610041610", value); } 
			}

			/// <summary>
			/// Gets field BuildingId 
			/// </summary>
			public string BuildingId { 
				get { return GetValue("COL38610041616"); } 
				set { SetValue("COL38610041616", value); } 
			}

			/// <summary>
			/// Gets field Created 
			/// </summary>
			public string Created { 
				get { return GetValue("COL38610041611"); } 
				set { SetValue("COL38610041611", value); } 
			}

			/// <summary>
			/// Gets field ModifiedBy 
			/// </summary>
			public string ModifiedBy { 
				get { return GetValue("COL38610041614"); } 
				set { SetValue("COL38610041614", value); } 
			}

			/// <summary>
			/// Gets field ParkingBegin 
			/// </summary>
			public string ParkingBegin { 
				get { return GetValue("COL3861004168"); } 
				set { SetValue("COL3861004168", value); } 
			}

			/// <summary>
			/// Gets field ParkingEnd 
			/// </summary>
			public string ParkingEnd { 
				get { return GetValue("COL3861004169"); } 
				set { SetValue("COL3861004169", value); } 
			}

			/// <summary>
			/// Gets field CreatedBy 
			/// </summary>
			public string CreatedBy { 
				get { return GetValue("COL38610041612"); } 
				set { SetValue("COL38610041612", value); } 
			}

			/// <summary>
			/// Gets field DelFlag 
			/// </summary>
			public string DelFlag { 
				get { return GetValue("COL38610041615"); } 
				set { SetValue("COL38610041615", value); } 
			}

			/// <summary>
			/// Gets field OwnerName 
			/// </summary>
			public string OwnerName { 
				get { return GetValue("COL3861004166"); } 
				set { SetValue("COL3861004166", value); } 
			}

			/// <summary>
			/// Gets field OwnerPhone 
			/// </summary>
			public string OwnerPhone { 
				get { return GetValue("COL3861004167"); } 
				set { SetValue("COL3861004167", value); } 
			}

			/// <summary>
			/// Gets field VehicleCode 
			/// </summary>
			public string VehicleCode { 
				get { return GetValue("COL3861004164"); } 
				set { SetValue("COL3861004164", value); } 
			}

			/// <summary>
			/// Gets field VehicleName 
			/// </summary>
			public string VehicleName { 
				get { return GetValue("COL3861004165"); } 
				set { SetValue("COL3861004165", value); } 
			}

			/// <summary>
			/// Gets field TariffsParkingId 
			/// </summary>
			public string TariffsParkingId { 
				get { return GetValue("COL3861004162"); } 
				set { SetValue("COL3861004162", value); } 
			}

			/// <summary>
			/// Gets field CustomerId 
			/// </summary>
			public string CustomerId { 
				get { return GetValue("COL3861004163"); } 
				set { SetValue("COL3861004163", value); } 
			}

			/// <summary>
			/// Gets field Modified 
			/// </summary>
			public string Modified { 
				get { return GetValue("COL38610041613"); } 
				set { SetValue("COL38610041613", value); } 
			}

			/// <summary>
			/// Gets field id 
			/// </summary>
			public string id { 
				get { return GetValue("COL3861004161"); } 
				set { SetValue("COL3861004161", value); } 
			}


			/// <summary>
			/// Gets Comment attribute data 
			/// </summary>
			public AttributeData GetCommentAttributeData() { 
				return GetAttributeData("COL38610041610"); 
			}

			/// <summary>
			/// Gets BuildingId attribute data 
			/// </summary>
			public AttributeData GetBuildingIdAttributeData() { 
				return GetAttributeData("COL38610041616"); 
			}

			/// <summary>
			/// Gets Created attribute data 
			/// </summary>
			public AttributeData GetCreatedAttributeData() { 
				return GetAttributeData("COL38610041611"); 
			}

			/// <summary>
			/// Gets ModifiedBy attribute data 
			/// </summary>
			public AttributeData GetModifiedByAttributeData() { 
				return GetAttributeData("COL38610041614"); 
			}

			/// <summary>
			/// Gets ParkingBegin attribute data 
			/// </summary>
			public AttributeData GetParkingBeginAttributeData() { 
				return GetAttributeData("COL3861004168"); 
			}

			/// <summary>
			/// Gets ParkingEnd attribute data 
			/// </summary>
			public AttributeData GetParkingEndAttributeData() { 
				return GetAttributeData("COL3861004169"); 
			}

			/// <summary>
			/// Gets CreatedBy attribute data 
			/// </summary>
			public AttributeData GetCreatedByAttributeData() { 
				return GetAttributeData("COL38610041612"); 
			}

			/// <summary>
			/// Gets DelFlag attribute data 
			/// </summary>
			public AttributeData GetDelFlagAttributeData() { 
				return GetAttributeData("COL38610041615"); 
			}

			/// <summary>
			/// Gets OwnerName attribute data 
			/// </summary>
			public AttributeData GetOwnerNameAttributeData() { 
				return GetAttributeData("COL3861004166"); 
			}

			/// <summary>
			/// Gets OwnerPhone attribute data 
			/// </summary>
			public AttributeData GetOwnerPhoneAttributeData() { 
				return GetAttributeData("COL3861004167"); 
			}

			/// <summary>
			/// Gets VehicleCode attribute data 
			/// </summary>
			public AttributeData GetVehicleCodeAttributeData() { 
				return GetAttributeData("COL3861004164"); 
			}

			/// <summary>
			/// Gets VehicleName attribute data 
			/// </summary>
			public AttributeData GetVehicleNameAttributeData() { 
				return GetAttributeData("COL3861004165"); 
			}

			/// <summary>
			/// Gets TariffsParkingId attribute data 
			/// </summary>
			public AttributeData GetTariffsParkingIdAttributeData() { 
				return GetAttributeData("COL3861004162"); 
			}

			/// <summary>
			/// Gets CustomerId attribute data 
			/// </summary>
			public AttributeData GetCustomerIdAttributeData() { 
				return GetAttributeData("COL3861004163"); 
			}

			/// <summary>
			/// Gets Modified attribute data 
			/// </summary>
			public AttributeData GetModifiedAttributeData() { 
				return GetAttributeData("COL38610041613"); 
			}

			/// <summary>
			/// Gets id attribute data 
			/// </summary>
			public AttributeData GetidAttributeData() { 
				return GetAttributeData("COL3861004161"); 
			}


			/// <summary>
			/// Gets column Comment with alias  
			/// </summary>
			public string ColComment { 
				get { return GetColumnName("COL38610041610"); } 
			}

			/// <summary>
			/// Gets column BuildingId with alias  
			/// </summary>
			public string ColBuildingId { 
				get { return GetColumnName("COL38610041616"); } 
			}

			/// <summary>
			/// Gets column Created with alias  
			/// </summary>
			public string ColCreated { 
				get { return GetColumnName("COL38610041611"); } 
			}

			/// <summary>
			/// Gets column ModifiedBy with alias  
			/// </summary>
			public string ColModifiedBy { 
				get { return GetColumnName("COL38610041614"); } 
			}

			/// <summary>
			/// Gets column ParkingBegin with alias  
			/// </summary>
			public string ColParkingBegin { 
				get { return GetColumnName("COL3861004168"); } 
			}

			/// <summary>
			/// Gets column ParkingEnd with alias  
			/// </summary>
			public string ColParkingEnd { 
				get { return GetColumnName("COL3861004169"); } 
			}

			/// <summary>
			/// Gets column CreatedBy with alias  
			/// </summary>
			public string ColCreatedBy { 
				get { return GetColumnName("COL38610041612"); } 
			}

			/// <summary>
			/// Gets column DelFlag with alias  
			/// </summary>
			public string ColDelFlag { 
				get { return GetColumnName("COL38610041615"); } 
			}

			/// <summary>
			/// Gets column OwnerName with alias  
			/// </summary>
			public string ColOwnerName { 
				get { return GetColumnName("COL3861004166"); } 
			}

			/// <summary>
			/// Gets column OwnerPhone with alias  
			/// </summary>
			public string ColOwnerPhone { 
				get { return GetColumnName("COL3861004167"); } 
			}

			/// <summary>
			/// Gets column VehicleCode with alias  
			/// </summary>
			public string ColVehicleCode { 
				get { return GetColumnName("COL3861004164"); } 
			}

			/// <summary>
			/// Gets column VehicleName with alias  
			/// </summary>
			public string ColVehicleName { 
				get { return GetColumnName("COL3861004165"); } 
			}

			/// <summary>
			/// Gets column TariffsParkingId with alias  
			/// </summary>
			public string ColTariffsParkingId { 
				get { return GetColumnName("COL3861004162"); } 
			}

			/// <summary>
			/// Gets column CustomerId with alias  
			/// </summary>
			public string ColCustomerId { 
				get { return GetColumnName("COL3861004163"); } 
			}

			/// <summary>
			/// Gets column Modified with alias  
			/// </summary>
			public string ColModified { 
				get { return GetColumnName("COL38610041613"); } 
			}

			/// <summary>
			/// Gets column id with alias  
			/// </summary>
			public string Colid { 
				get { return GetColumnName("COL3861004161"); } 
			}


			/// <summary>
			/// Checks whether column Comment is added in select statement 
			/// </summary>
			public bool IsSelectComment { 
				get { return IsSelect("COL38610041610"); } 
				set { SetSelect("COL38610041610", value); } 
			}

			/// <summary>
			/// Checks whether column BuildingId is added in select statement 
			/// </summary>
			public bool IsSelectBuildingId { 
				get { return IsSelect("COL38610041616"); } 
				set { SetSelect("COL38610041616", value); } 
			}

			/// <summary>
			/// Checks whether column Created is added in select statement 
			/// </summary>
			public bool IsSelectCreated { 
				get { return IsSelect("COL38610041611"); } 
				set { SetSelect("COL38610041611", value); } 
			}

			/// <summary>
			/// Checks whether column ModifiedBy is added in select statement 
			/// </summary>
			public bool IsSelectModifiedBy { 
				get { return IsSelect("COL38610041614"); } 
				set { SetSelect("COL38610041614", value); } 
			}

			/// <summary>
			/// Checks whether column ParkingBegin is added in select statement 
			/// </summary>
			public bool IsSelectParkingBegin { 
				get { return IsSelect("COL3861004168"); } 
				set { SetSelect("COL3861004168", value); } 
			}

			/// <summary>
			/// Checks whether column ParkingEnd is added in select statement 
			/// </summary>
			public bool IsSelectParkingEnd { 
				get { return IsSelect("COL3861004169"); } 
				set { SetSelect("COL3861004169", value); } 
			}

			/// <summary>
			/// Checks whether column CreatedBy is added in select statement 
			/// </summary>
			public bool IsSelectCreatedBy { 
				get { return IsSelect("COL38610041612"); } 
				set { SetSelect("COL38610041612", value); } 
			}

			/// <summary>
			/// Checks whether column DelFlag is added in select statement 
			/// </summary>
			public bool IsSelectDelFlag { 
				get { return IsSelect("COL38610041615"); } 
				set { SetSelect("COL38610041615", value); } 
			}

			/// <summary>
			/// Checks whether column OwnerName is added in select statement 
			/// </summary>
			public bool IsSelectOwnerName { 
				get { return IsSelect("COL3861004166"); } 
				set { SetSelect("COL3861004166", value); } 
			}

			/// <summary>
			/// Checks whether column OwnerPhone is added in select statement 
			/// </summary>
			public bool IsSelectOwnerPhone { 
				get { return IsSelect("COL3861004167"); } 
				set { SetSelect("COL3861004167", value); } 
			}

			/// <summary>
			/// Checks whether column VehicleCode is added in select statement 
			/// </summary>
			public bool IsSelectVehicleCode { 
				get { return IsSelect("COL3861004164"); } 
				set { SetSelect("COL3861004164", value); } 
			}

			/// <summary>
			/// Checks whether column VehicleName is added in select statement 
			/// </summary>
			public bool IsSelectVehicleName { 
				get { return IsSelect("COL3861004165"); } 
				set { SetSelect("COL3861004165", value); } 
			}

			/// <summary>
			/// Checks whether column TariffsParkingId is added in select statement 
			/// </summary>
			public bool IsSelectTariffsParkingId { 
				get { return IsSelect("COL3861004162"); } 
				set { SetSelect("COL3861004162", value); } 
			}

			/// <summary>
			/// Checks whether column CustomerId is added in select statement 
			/// </summary>
			public bool IsSelectCustomerId { 
				get { return IsSelect("COL3861004163"); } 
				set { SetSelect("COL3861004163", value); } 
			}

			/// <summary>
			/// Checks whether column Modified is added in select statement 
			/// </summary>
			public bool IsSelectModified { 
				get { return IsSelect("COL38610041613"); } 
				set { SetSelect("COL38610041613", value); } 
			}

			/// <summary>
			/// Checks whether column id is added in select statement 
			/// </summary>
			public bool IsSelectid { 
				get { return IsSelect("COL3861004161"); } 
				set { SetSelect("COL3861004161", value); } 
			}



	}
}