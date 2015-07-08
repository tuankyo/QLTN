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
	public class BD_RoomData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ824390006";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of BD_Room 
			/// </summary>
			public BD_RoomData(string objectID): base(objectID) {}  

			public BD_RoomData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field HourManagerPriceVND 
			/// </summary>
			public string HourManagerPriceVND { 
				get { return GetValue("COL82439000610"); } 
				set { SetValue("COL82439000610", value); } 
			}

			/// <summary>
			/// Gets field Comment 
			/// </summary>
			public string Comment { 
				get { return GetValue("COL82439000620"); } 
				set { SetValue("COL82439000620", value); } 
			}

			/// <summary>
			/// Gets field ExtraTimeMinPriceVND 
			/// </summary>
			public string ExtraTimeMinPriceVND { 
				get { return GetValue("COL82439000630"); } 
				set { SetValue("COL82439000630", value); } 
			}

			/// <summary>
			/// Gets field MonthManagerPriceUSD 
			/// </summary>
			public string MonthManagerPriceUSD { 
				get { return GetValue("COL82439000617"); } 
				set { SetValue("COL82439000617", value); } 
			}

			/// <summary>
			/// Gets field OtherFee01 
			/// </summary>
			public string OtherFee01 { 
				get { return GetValue("COL82439000627"); } 
				set { SetValue("COL82439000627", value); } 
			}

			/// <summary>
			/// Gets field id 
			/// </summary>
			public string id { 
				get { return GetValue("COL8243900061"); } 
				set { SetValue("COL8243900061", value); } 
			}

			/// <summary>
			/// Gets field Floor 
			/// </summary>
			public string Floor { 
				get { return GetValue("COL8243900065"); } 
				set { SetValue("COL8243900065", value); } 
			}

			/// <summary>
			/// Gets field HourExtraTimePriceVND 
			/// </summary>
			public string HourExtraTimePriceVND { 
				get { return GetValue("COL82439000612"); } 
				set { SetValue("COL82439000612", value); } 
			}

			/// <summary>
			/// Gets field CreatedBy 
			/// </summary>
			public string CreatedBy { 
				get { return GetValue("COL82439000622"); } 
				set { SetValue("COL82439000622", value); } 
			}

			/// <summary>
			/// Gets field BuildingId 
			/// </summary>
			public string BuildingId { 
				get { return GetValue("COL8243900062"); } 
				set { SetValue("COL8243900062", value); } 
			}

			/// <summary>
			/// Gets field Area 
			/// </summary>
			public string Area { 
				get { return GetValue("COL8243900066"); } 
				set { SetValue("COL8243900066", value); } 
			}

			/// <summary>
			/// Gets field MonthExtraTimePriceUsd 
			/// </summary>
			public string MonthExtraTimePriceUsd { 
				get { return GetValue("COL82439000619"); } 
				set { SetValue("COL82439000619", value); } 
			}

			/// <summary>
			/// Gets field Description 
			/// </summary>
			public string Description { 
				get { return GetValue("COL82439000629"); } 
				set { SetValue("COL82439000629", value); } 
			}

			/// <summary>
			/// Gets field Name 
			/// </summary>
			public string Name { 
				get { return GetValue("COL8243900063"); } 
				set { SetValue("COL8243900063", value); } 
			}

			/// <summary>
			/// Gets field HourManagerPriceUSD 
			/// </summary>
			public string HourManagerPriceUSD { 
				get { return GetValue("COL82439000611"); } 
				set { SetValue("COL82439000611", value); } 
			}

			/// <summary>
			/// Gets field Created 
			/// </summary>
			public string Created { 
				get { return GetValue("COL82439000621"); } 
				set { SetValue("COL82439000621", value); } 
			}

			/// <summary>
			/// Gets field ExtraTimeMinPriceUSD 
			/// </summary>
			public string ExtraTimeMinPriceUSD { 
				get { return GetValue("COL82439000631"); } 
				set { SetValue("COL82439000631", value); } 
			}

			/// <summary>
			/// Gets field Regional 
			/// </summary>
			public string Regional { 
				get { return GetValue("COL8243900064"); } 
				set { SetValue("COL8243900064", value); } 
			}

			/// <summary>
			/// Gets field MonthRentPriceVND 
			/// </summary>
			public string MonthRentPriceVND { 
				get { return GetValue("COL82439000614"); } 
				set { SetValue("COL82439000614", value); } 
			}

			/// <summary>
			/// Gets field ModifiedBy 
			/// </summary>
			public string ModifiedBy { 
				get { return GetValue("COL82439000624"); } 
				set { SetValue("COL82439000624", value); } 
			}

			/// <summary>
			/// Gets field IsMeetingRoom 
			/// </summary>
			public string IsMeetingRoom { 
				get { return GetValue("COL8243900067"); } 
				set { SetValue("COL8243900067", value); } 
			}

			/// <summary>
			/// Gets field HourRentPriceVND 
			/// </summary>
			public string HourRentPriceVND { 
				get { return GetValue("COL8243900068"); } 
				set { SetValue("COL8243900068", value); } 
			}

			/// <summary>
			/// Gets field HourRentPriceUSD 
			/// </summary>
			public string HourRentPriceUSD { 
				get { return GetValue("COL8243900069"); } 
				set { SetValue("COL8243900069", value); } 
			}

			/// <summary>
			/// Gets field HourExtraTimePriceUsd 
			/// </summary>
			public string HourExtraTimePriceUsd { 
				get { return GetValue("COL82439000613"); } 
				set { SetValue("COL82439000613", value); } 
			}

			/// <summary>
			/// Gets field Modified 
			/// </summary>
			public string Modified { 
				get { return GetValue("COL82439000623"); } 
				set { SetValue("COL82439000623", value); } 
			}

			/// <summary>
			/// Gets field MonthManagerPriceVND 
			/// </summary>
			public string MonthManagerPriceVND { 
				get { return GetValue("COL82439000616"); } 
				set { SetValue("COL82439000616", value); } 
			}

			/// <summary>
			/// Gets field Vat 
			/// </summary>
			public string Vat { 
				get { return GetValue("COL82439000626"); } 
				set { SetValue("COL82439000626", value); } 
			}

			/// <summary>
			/// Gets field MonthRentPriceUSD 
			/// </summary>
			public string MonthRentPriceUSD { 
				get { return GetValue("COL82439000615"); } 
				set { SetValue("COL82439000615", value); } 
			}

			/// <summary>
			/// Gets field DelFlag 
			/// </summary>
			public string DelFlag { 
				get { return GetValue("COL82439000625"); } 
				set { SetValue("COL82439000625", value); } 
			}

			/// <summary>
			/// Gets field MonthExtraTimePriceVND 
			/// </summary>
			public string MonthExtraTimePriceVND { 
				get { return GetValue("COL82439000618"); } 
				set { SetValue("COL82439000618", value); } 
			}

			/// <summary>
			/// Gets field OtherFee02 
			/// </summary>
			public string OtherFee02 { 
				get { return GetValue("COL82439000628"); } 
				set { SetValue("COL82439000628", value); } 
			}


			/// <summary>
			/// Gets HourManagerPriceVND attribute data 
			/// </summary>
			public AttributeData GetHourManagerPriceVNDAttributeData() { 
				return GetAttributeData("COL82439000610"); 
			}

			/// <summary>
			/// Gets Comment attribute data 
			/// </summary>
			public AttributeData GetCommentAttributeData() { 
				return GetAttributeData("COL82439000620"); 
			}

			/// <summary>
			/// Gets ExtraTimeMinPriceVND attribute data 
			/// </summary>
			public AttributeData GetExtraTimeMinPriceVNDAttributeData() { 
				return GetAttributeData("COL82439000630"); 
			}

			/// <summary>
			/// Gets MonthManagerPriceUSD attribute data 
			/// </summary>
			public AttributeData GetMonthManagerPriceUSDAttributeData() { 
				return GetAttributeData("COL82439000617"); 
			}

			/// <summary>
			/// Gets OtherFee01 attribute data 
			/// </summary>
			public AttributeData GetOtherFee01AttributeData() { 
				return GetAttributeData("COL82439000627"); 
			}

			/// <summary>
			/// Gets id attribute data 
			/// </summary>
			public AttributeData GetidAttributeData() { 
				return GetAttributeData("COL8243900061"); 
			}

			/// <summary>
			/// Gets Floor attribute data 
			/// </summary>
			public AttributeData GetFloorAttributeData() { 
				return GetAttributeData("COL8243900065"); 
			}

			/// <summary>
			/// Gets HourExtraTimePriceVND attribute data 
			/// </summary>
			public AttributeData GetHourExtraTimePriceVNDAttributeData() { 
				return GetAttributeData("COL82439000612"); 
			}

			/// <summary>
			/// Gets CreatedBy attribute data 
			/// </summary>
			public AttributeData GetCreatedByAttributeData() { 
				return GetAttributeData("COL82439000622"); 
			}

			/// <summary>
			/// Gets BuildingId attribute data 
			/// </summary>
			public AttributeData GetBuildingIdAttributeData() { 
				return GetAttributeData("COL8243900062"); 
			}

			/// <summary>
			/// Gets Area attribute data 
			/// </summary>
			public AttributeData GetAreaAttributeData() { 
				return GetAttributeData("COL8243900066"); 
			}

			/// <summary>
			/// Gets MonthExtraTimePriceUsd attribute data 
			/// </summary>
			public AttributeData GetMonthExtraTimePriceUsdAttributeData() { 
				return GetAttributeData("COL82439000619"); 
			}

			/// <summary>
			/// Gets Description attribute data 
			/// </summary>
			public AttributeData GetDescriptionAttributeData() { 
				return GetAttributeData("COL82439000629"); 
			}

			/// <summary>
			/// Gets Name attribute data 
			/// </summary>
			public AttributeData GetNameAttributeData() { 
				return GetAttributeData("COL8243900063"); 
			}

			/// <summary>
			/// Gets HourManagerPriceUSD attribute data 
			/// </summary>
			public AttributeData GetHourManagerPriceUSDAttributeData() { 
				return GetAttributeData("COL82439000611"); 
			}

			/// <summary>
			/// Gets Created attribute data 
			/// </summary>
			public AttributeData GetCreatedAttributeData() { 
				return GetAttributeData("COL82439000621"); 
			}

			/// <summary>
			/// Gets ExtraTimeMinPriceUSD attribute data 
			/// </summary>
			public AttributeData GetExtraTimeMinPriceUSDAttributeData() { 
				return GetAttributeData("COL82439000631"); 
			}

			/// <summary>
			/// Gets Regional attribute data 
			/// </summary>
			public AttributeData GetRegionalAttributeData() { 
				return GetAttributeData("COL8243900064"); 
			}

			/// <summary>
			/// Gets MonthRentPriceVND attribute data 
			/// </summary>
			public AttributeData GetMonthRentPriceVNDAttributeData() { 
				return GetAttributeData("COL82439000614"); 
			}

			/// <summary>
			/// Gets ModifiedBy attribute data 
			/// </summary>
			public AttributeData GetModifiedByAttributeData() { 
				return GetAttributeData("COL82439000624"); 
			}

			/// <summary>
			/// Gets IsMeetingRoom attribute data 
			/// </summary>
			public AttributeData GetIsMeetingRoomAttributeData() { 
				return GetAttributeData("COL8243900067"); 
			}

			/// <summary>
			/// Gets HourRentPriceVND attribute data 
			/// </summary>
			public AttributeData GetHourRentPriceVNDAttributeData() { 
				return GetAttributeData("COL8243900068"); 
			}

			/// <summary>
			/// Gets HourRentPriceUSD attribute data 
			/// </summary>
			public AttributeData GetHourRentPriceUSDAttributeData() { 
				return GetAttributeData("COL8243900069"); 
			}

			/// <summary>
			/// Gets HourExtraTimePriceUsd attribute data 
			/// </summary>
			public AttributeData GetHourExtraTimePriceUsdAttributeData() { 
				return GetAttributeData("COL82439000613"); 
			}

			/// <summary>
			/// Gets Modified attribute data 
			/// </summary>
			public AttributeData GetModifiedAttributeData() { 
				return GetAttributeData("COL82439000623"); 
			}

			/// <summary>
			/// Gets MonthManagerPriceVND attribute data 
			/// </summary>
			public AttributeData GetMonthManagerPriceVNDAttributeData() { 
				return GetAttributeData("COL82439000616"); 
			}

			/// <summary>
			/// Gets Vat attribute data 
			/// </summary>
			public AttributeData GetVatAttributeData() { 
				return GetAttributeData("COL82439000626"); 
			}

			/// <summary>
			/// Gets MonthRentPriceUSD attribute data 
			/// </summary>
			public AttributeData GetMonthRentPriceUSDAttributeData() { 
				return GetAttributeData("COL82439000615"); 
			}

			/// <summary>
			/// Gets DelFlag attribute data 
			/// </summary>
			public AttributeData GetDelFlagAttributeData() { 
				return GetAttributeData("COL82439000625"); 
			}

			/// <summary>
			/// Gets MonthExtraTimePriceVND attribute data 
			/// </summary>
			public AttributeData GetMonthExtraTimePriceVNDAttributeData() { 
				return GetAttributeData("COL82439000618"); 
			}

			/// <summary>
			/// Gets OtherFee02 attribute data 
			/// </summary>
			public AttributeData GetOtherFee02AttributeData() { 
				return GetAttributeData("COL82439000628"); 
			}


			/// <summary>
			/// Gets column HourManagerPriceVND with alias  
			/// </summary>
			public string ColHourManagerPriceVND { 
				get { return GetColumnName("COL82439000610"); } 
			}

			/// <summary>
			/// Gets column Comment with alias  
			/// </summary>
			public string ColComment { 
				get { return GetColumnName("COL82439000620"); } 
			}

			/// <summary>
			/// Gets column ExtraTimeMinPriceVND with alias  
			/// </summary>
			public string ColExtraTimeMinPriceVND { 
				get { return GetColumnName("COL82439000630"); } 
			}

			/// <summary>
			/// Gets column MonthManagerPriceUSD with alias  
			/// </summary>
			public string ColMonthManagerPriceUSD { 
				get { return GetColumnName("COL82439000617"); } 
			}

			/// <summary>
			/// Gets column OtherFee01 with alias  
			/// </summary>
			public string ColOtherFee01 { 
				get { return GetColumnName("COL82439000627"); } 
			}

			/// <summary>
			/// Gets column id with alias  
			/// </summary>
			public string Colid { 
				get { return GetColumnName("COL8243900061"); } 
			}

			/// <summary>
			/// Gets column Floor with alias  
			/// </summary>
			public string ColFloor { 
				get { return GetColumnName("COL8243900065"); } 
			}

			/// <summary>
			/// Gets column HourExtraTimePriceVND with alias  
			/// </summary>
			public string ColHourExtraTimePriceVND { 
				get { return GetColumnName("COL82439000612"); } 
			}

			/// <summary>
			/// Gets column CreatedBy with alias  
			/// </summary>
			public string ColCreatedBy { 
				get { return GetColumnName("COL82439000622"); } 
			}

			/// <summary>
			/// Gets column BuildingId with alias  
			/// </summary>
			public string ColBuildingId { 
				get { return GetColumnName("COL8243900062"); } 
			}

			/// <summary>
			/// Gets column Area with alias  
			/// </summary>
			public string ColArea { 
				get { return GetColumnName("COL8243900066"); } 
			}

			/// <summary>
			/// Gets column MonthExtraTimePriceUsd with alias  
			/// </summary>
			public string ColMonthExtraTimePriceUsd { 
				get { return GetColumnName("COL82439000619"); } 
			}

			/// <summary>
			/// Gets column Description with alias  
			/// </summary>
			public string ColDescription { 
				get { return GetColumnName("COL82439000629"); } 
			}

			/// <summary>
			/// Gets column Name with alias  
			/// </summary>
			public string ColName { 
				get { return GetColumnName("COL8243900063"); } 
			}

			/// <summary>
			/// Gets column HourManagerPriceUSD with alias  
			/// </summary>
			public string ColHourManagerPriceUSD { 
				get { return GetColumnName("COL82439000611"); } 
			}

			/// <summary>
			/// Gets column Created with alias  
			/// </summary>
			public string ColCreated { 
				get { return GetColumnName("COL82439000621"); } 
			}

			/// <summary>
			/// Gets column ExtraTimeMinPriceUSD with alias  
			/// </summary>
			public string ColExtraTimeMinPriceUSD { 
				get { return GetColumnName("COL82439000631"); } 
			}

			/// <summary>
			/// Gets column Regional with alias  
			/// </summary>
			public string ColRegional { 
				get { return GetColumnName("COL8243900064"); } 
			}

			/// <summary>
			/// Gets column MonthRentPriceVND with alias  
			/// </summary>
			public string ColMonthRentPriceVND { 
				get { return GetColumnName("COL82439000614"); } 
			}

			/// <summary>
			/// Gets column ModifiedBy with alias  
			/// </summary>
			public string ColModifiedBy { 
				get { return GetColumnName("COL82439000624"); } 
			}

			/// <summary>
			/// Gets column IsMeetingRoom with alias  
			/// </summary>
			public string ColIsMeetingRoom { 
				get { return GetColumnName("COL8243900067"); } 
			}

			/// <summary>
			/// Gets column HourRentPriceVND with alias  
			/// </summary>
			public string ColHourRentPriceVND { 
				get { return GetColumnName("COL8243900068"); } 
			}

			/// <summary>
			/// Gets column HourRentPriceUSD with alias  
			/// </summary>
			public string ColHourRentPriceUSD { 
				get { return GetColumnName("COL8243900069"); } 
			}

			/// <summary>
			/// Gets column HourExtraTimePriceUsd with alias  
			/// </summary>
			public string ColHourExtraTimePriceUsd { 
				get { return GetColumnName("COL82439000613"); } 
			}

			/// <summary>
			/// Gets column Modified with alias  
			/// </summary>
			public string ColModified { 
				get { return GetColumnName("COL82439000623"); } 
			}

			/// <summary>
			/// Gets column MonthManagerPriceVND with alias  
			/// </summary>
			public string ColMonthManagerPriceVND { 
				get { return GetColumnName("COL82439000616"); } 
			}

			/// <summary>
			/// Gets column Vat with alias  
			/// </summary>
			public string ColVat { 
				get { return GetColumnName("COL82439000626"); } 
			}

			/// <summary>
			/// Gets column MonthRentPriceUSD with alias  
			/// </summary>
			public string ColMonthRentPriceUSD { 
				get { return GetColumnName("COL82439000615"); } 
			}

			/// <summary>
			/// Gets column DelFlag with alias  
			/// </summary>
			public string ColDelFlag { 
				get { return GetColumnName("COL82439000625"); } 
			}

			/// <summary>
			/// Gets column MonthExtraTimePriceVND with alias  
			/// </summary>
			public string ColMonthExtraTimePriceVND { 
				get { return GetColumnName("COL82439000618"); } 
			}

			/// <summary>
			/// Gets column OtherFee02 with alias  
			/// </summary>
			public string ColOtherFee02 { 
				get { return GetColumnName("COL82439000628"); } 
			}


			/// <summary>
			/// Checks whether column HourManagerPriceVND is added in select statement 
			/// </summary>
			public bool IsSelectHourManagerPriceVND { 
				get { return IsSelect("COL82439000610"); } 
				set { SetSelect("COL82439000610", value); } 
			}

			/// <summary>
			/// Checks whether column Comment is added in select statement 
			/// </summary>
			public bool IsSelectComment { 
				get { return IsSelect("COL82439000620"); } 
				set { SetSelect("COL82439000620", value); } 
			}

			/// <summary>
			/// Checks whether column ExtraTimeMinPriceVND is added in select statement 
			/// </summary>
			public bool IsSelectExtraTimeMinPriceVND { 
				get { return IsSelect("COL82439000630"); } 
				set { SetSelect("COL82439000630", value); } 
			}

			/// <summary>
			/// Checks whether column MonthManagerPriceUSD is added in select statement 
			/// </summary>
			public bool IsSelectMonthManagerPriceUSD { 
				get { return IsSelect("COL82439000617"); } 
				set { SetSelect("COL82439000617", value); } 
			}

			/// <summary>
			/// Checks whether column OtherFee01 is added in select statement 
			/// </summary>
			public bool IsSelectOtherFee01 { 
				get { return IsSelect("COL82439000627"); } 
				set { SetSelect("COL82439000627", value); } 
			}

			/// <summary>
			/// Checks whether column id is added in select statement 
			/// </summary>
			public bool IsSelectid { 
				get { return IsSelect("COL8243900061"); } 
				set { SetSelect("COL8243900061", value); } 
			}

			/// <summary>
			/// Checks whether column Floor is added in select statement 
			/// </summary>
			public bool IsSelectFloor { 
				get { return IsSelect("COL8243900065"); } 
				set { SetSelect("COL8243900065", value); } 
			}

			/// <summary>
			/// Checks whether column HourExtraTimePriceVND is added in select statement 
			/// </summary>
			public bool IsSelectHourExtraTimePriceVND { 
				get { return IsSelect("COL82439000612"); } 
				set { SetSelect("COL82439000612", value); } 
			}

			/// <summary>
			/// Checks whether column CreatedBy is added in select statement 
			/// </summary>
			public bool IsSelectCreatedBy { 
				get { return IsSelect("COL82439000622"); } 
				set { SetSelect("COL82439000622", value); } 
			}

			/// <summary>
			/// Checks whether column BuildingId is added in select statement 
			/// </summary>
			public bool IsSelectBuildingId { 
				get { return IsSelect("COL8243900062"); } 
				set { SetSelect("COL8243900062", value); } 
			}

			/// <summary>
			/// Checks whether column Area is added in select statement 
			/// </summary>
			public bool IsSelectArea { 
				get { return IsSelect("COL8243900066"); } 
				set { SetSelect("COL8243900066", value); } 
			}

			/// <summary>
			/// Checks whether column MonthExtraTimePriceUsd is added in select statement 
			/// </summary>
			public bool IsSelectMonthExtraTimePriceUsd { 
				get { return IsSelect("COL82439000619"); } 
				set { SetSelect("COL82439000619", value); } 
			}

			/// <summary>
			/// Checks whether column Description is added in select statement 
			/// </summary>
			public bool IsSelectDescription { 
				get { return IsSelect("COL82439000629"); } 
				set { SetSelect("COL82439000629", value); } 
			}

			/// <summary>
			/// Checks whether column Name is added in select statement 
			/// </summary>
			public bool IsSelectName { 
				get { return IsSelect("COL8243900063"); } 
				set { SetSelect("COL8243900063", value); } 
			}

			/// <summary>
			/// Checks whether column HourManagerPriceUSD is added in select statement 
			/// </summary>
			public bool IsSelectHourManagerPriceUSD { 
				get { return IsSelect("COL82439000611"); } 
				set { SetSelect("COL82439000611", value); } 
			}

			/// <summary>
			/// Checks whether column Created is added in select statement 
			/// </summary>
			public bool IsSelectCreated { 
				get { return IsSelect("COL82439000621"); } 
				set { SetSelect("COL82439000621", value); } 
			}

			/// <summary>
			/// Checks whether column ExtraTimeMinPriceUSD is added in select statement 
			/// </summary>
			public bool IsSelectExtraTimeMinPriceUSD { 
				get { return IsSelect("COL82439000631"); } 
				set { SetSelect("COL82439000631", value); } 
			}

			/// <summary>
			/// Checks whether column Regional is added in select statement 
			/// </summary>
			public bool IsSelectRegional { 
				get { return IsSelect("COL8243900064"); } 
				set { SetSelect("COL8243900064", value); } 
			}

			/// <summary>
			/// Checks whether column MonthRentPriceVND is added in select statement 
			/// </summary>
			public bool IsSelectMonthRentPriceVND { 
				get { return IsSelect("COL82439000614"); } 
				set { SetSelect("COL82439000614", value); } 
			}

			/// <summary>
			/// Checks whether column ModifiedBy is added in select statement 
			/// </summary>
			public bool IsSelectModifiedBy { 
				get { return IsSelect("COL82439000624"); } 
				set { SetSelect("COL82439000624", value); } 
			}

			/// <summary>
			/// Checks whether column IsMeetingRoom is added in select statement 
			/// </summary>
			public bool IsSelectIsMeetingRoom { 
				get { return IsSelect("COL8243900067"); } 
				set { SetSelect("COL8243900067", value); } 
			}

			/// <summary>
			/// Checks whether column HourRentPriceVND is added in select statement 
			/// </summary>
			public bool IsSelectHourRentPriceVND { 
				get { return IsSelect("COL8243900068"); } 
				set { SetSelect("COL8243900068", value); } 
			}

			/// <summary>
			/// Checks whether column HourRentPriceUSD is added in select statement 
			/// </summary>
			public bool IsSelectHourRentPriceUSD { 
				get { return IsSelect("COL8243900069"); } 
				set { SetSelect("COL8243900069", value); } 
			}

			/// <summary>
			/// Checks whether column HourExtraTimePriceUsd is added in select statement 
			/// </summary>
			public bool IsSelectHourExtraTimePriceUsd { 
				get { return IsSelect("COL82439000613"); } 
				set { SetSelect("COL82439000613", value); } 
			}

			/// <summary>
			/// Checks whether column Modified is added in select statement 
			/// </summary>
			public bool IsSelectModified { 
				get { return IsSelect("COL82439000623"); } 
				set { SetSelect("COL82439000623", value); } 
			}

			/// <summary>
			/// Checks whether column MonthManagerPriceVND is added in select statement 
			/// </summary>
			public bool IsSelectMonthManagerPriceVND { 
				get { return IsSelect("COL82439000616"); } 
				set { SetSelect("COL82439000616", value); } 
			}

			/// <summary>
			/// Checks whether column Vat is added in select statement 
			/// </summary>
			public bool IsSelectVat { 
				get { return IsSelect("COL82439000626"); } 
				set { SetSelect("COL82439000626", value); } 
			}

			/// <summary>
			/// Checks whether column MonthRentPriceUSD is added in select statement 
			/// </summary>
			public bool IsSelectMonthRentPriceUSD { 
				get { return IsSelect("COL82439000615"); } 
				set { SetSelect("COL82439000615", value); } 
			}

			/// <summary>
			/// Checks whether column DelFlag is added in select statement 
			/// </summary>
			public bool IsSelectDelFlag { 
				get { return IsSelect("COL82439000625"); } 
				set { SetSelect("COL82439000625", value); } 
			}

			/// <summary>
			/// Checks whether column MonthExtraTimePriceVND is added in select statement 
			/// </summary>
			public bool IsSelectMonthExtraTimePriceVND { 
				get { return IsSelect("COL82439000618"); } 
				set { SetSelect("COL82439000618", value); } 
			}

			/// <summary>
			/// Checks whether column OtherFee02 is added in select statement 
			/// </summary>
			public bool IsSelectOtherFee02 { 
				get { return IsSelect("COL82439000628"); } 
				set { SetSelect("COL82439000628", value); } 
			}



	}
}