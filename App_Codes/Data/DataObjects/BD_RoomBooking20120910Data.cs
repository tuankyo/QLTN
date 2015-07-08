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
	public class BD_RoomBooking20120910Data : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ520388923";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of BD_RoomBooking20120910 
			/// </summary>
			public BD_RoomBooking20120910Data(string objectID): base(objectID) {}  

			public BD_RoomBooking20120910Data() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field Status 
			/// </summary>
			public string Status { 
				get { return GetValue("COL52038892314"); } 
				set { SetValue("COL52038892314", value); } 
			}

			/// <summary>
			/// Gets field Comment 
			/// </summary>
			public string Comment { 
				get { return GetValue("COL52038892324"); } 
				set { SetValue("COL52038892324", value); } 
			}

			/// <summary>
			/// Gets field PaidMoneyType 
			/// </summary>
			public string PaidMoneyType { 
				get { return GetValue("COL52038892334"); } 
				set { SetValue("COL52038892334", value); } 
			}

			/// <summary>
			/// Gets field OtherFee01 
			/// </summary>
			public string OtherFee01 { 
				get { return GetValue("COL52038892316"); } 
				set { SetValue("COL52038892316", value); } 
			}

			/// <summary>
			/// Gets field CreatedBy 
			/// </summary>
			public string CreatedBy { 
				get { return GetValue("COL52038892326"); } 
				set { SetValue("COL52038892326", value); } 
			}

			/// <summary>
			/// Gets field RentHourFrom 
			/// </summary>
			public string RentHourFrom { 
				get { return GetValue("COL52038892310"); } 
				set { SetValue("COL52038892310", value); } 
			}

			/// <summary>
			/// Gets field PriceVND 
			/// </summary>
			public string PriceVND { 
				get { return GetValue("COL52038892320"); } 
				set { SetValue("COL52038892320", value); } 
			}

			/// <summary>
			/// Gets field ContractDate 
			/// </summary>
			public string ContractDate { 
				get { return GetValue("COL52038892330"); } 
				set { SetValue("COL52038892330", value); } 
			}

			/// <summary>
			/// Gets field RentHourTo 
			/// </summary>
			public string RentHourTo { 
				get { return GetValue("COL52038892312"); } 
				set { SetValue("COL52038892312", value); } 
			}

			/// <summary>
			/// Gets field HourExtraPriceVND 
			/// </summary>
			public string HourExtraPriceVND { 
				get { return GetValue("COL52038892322"); } 
				set { SetValue("COL52038892322", value); } 
			}

			/// <summary>
			/// Gets field RateDate 
			/// </summary>
			public string RateDate { 
				get { return GetValue("COL52038892332"); } 
				set { SetValue("COL52038892332", value); } 
			}

			/// <summary>
			/// Gets field BookingType 
			/// </summary>
			public string BookingType { 
				get { return GetValue("COL52038892319"); } 
				set { SetValue("COL52038892319", value); } 
			}

			/// <summary>
			/// Gets field DelFlag 
			/// </summary>
			public string DelFlag { 
				get { return GetValue("COL52038892329"); } 
				set { SetValue("COL52038892329", value); } 
			}

			/// <summary>
			/// Gets field VAT 
			/// </summary>
			public string VAT { 
				get { return GetValue("COL52038892315"); } 
				set { SetValue("COL52038892315", value); } 
			}

			/// <summary>
			/// Gets field Created 
			/// </summary>
			public string Created { 
				get { return GetValue("COL52038892325"); } 
				set { SetValue("COL52038892325", value); } 
			}

			/// <summary>
			/// Gets field OtherFee02 
			/// </summary>
			public string OtherFee02 { 
				get { return GetValue("COL52038892317"); } 
				set { SetValue("COL52038892317", value); } 
			}

			/// <summary>
			/// Gets field Modified 
			/// </summary>
			public string Modified { 
				get { return GetValue("COL52038892327"); } 
				set { SetValue("COL52038892327", value); } 
			}

			/// <summary>
			/// Gets field RentMinuteFrom 
			/// </summary>
			public string RentMinuteFrom { 
				get { return GetValue("COL52038892311"); } 
				set { SetValue("COL52038892311", value); } 
			}

			/// <summary>
			/// Gets field PriceUSD 
			/// </summary>
			public string PriceUSD { 
				get { return GetValue("COL52038892321"); } 
				set { SetValue("COL52038892321", value); } 
			}

			/// <summary>
			/// Gets field Rate 
			/// </summary>
			public string Rate { 
				get { return GetValue("COL52038892331"); } 
				set { SetValue("COL52038892331", value); } 
			}

			/// <summary>
			/// Gets field RentMinuteTo 
			/// </summary>
			public string RentMinuteTo { 
				get { return GetValue("COL52038892313"); } 
				set { SetValue("COL52038892313", value); } 
			}

			/// <summary>
			/// Gets field HourExtraPriceUSD 
			/// </summary>
			public string HourExtraPriceUSD { 
				get { return GetValue("COL52038892323"); } 
				set { SetValue("COL52038892323", value); } 
			}

			/// <summary>
			/// Gets field ContractNo 
			/// </summary>
			public string ContractNo { 
				get { return GetValue("COL52038892333"); } 
				set { SetValue("COL52038892333", value); } 
			}

			/// <summary>
			/// Gets field BookingHourTo 
			/// </summary>
			public string BookingHourTo { 
				get { return GetValue("COL5203889238"); } 
				set { SetValue("COL5203889238", value); } 
			}

			/// <summary>
			/// Gets field BookingMinuteTo 
			/// </summary>
			public string BookingMinuteTo { 
				get { return GetValue("COL5203889239"); } 
				set { SetValue("COL5203889239", value); } 
			}

			/// <summary>
			/// Gets field id 
			/// </summary>
			public string id { 
				get { return GetValue("COL5203889231"); } 
				set { SetValue("COL5203889231", value); } 
			}

			/// <summary>
			/// Gets field BuildingId 
			/// </summary>
			public string BuildingId { 
				get { return GetValue("COL5203889232"); } 
				set { SetValue("COL5203889232", value); } 
			}

			/// <summary>
			/// Gets field CustomerId 
			/// </summary>
			public string CustomerId { 
				get { return GetValue("COL5203889233"); } 
				set { SetValue("COL5203889233", value); } 
			}

			/// <summary>
			/// Gets field RoomId 
			/// </summary>
			public string RoomId { 
				get { return GetValue("COL5203889234"); } 
				set { SetValue("COL5203889234", value); } 
			}

			/// <summary>
			/// Gets field BookingDate 
			/// </summary>
			public string BookingDate { 
				get { return GetValue("COL5203889235"); } 
				set { SetValue("COL5203889235", value); } 
			}

			/// <summary>
			/// Gets field BookingHourFrom 
			/// </summary>
			public string BookingHourFrom { 
				get { return GetValue("COL5203889236"); } 
				set { SetValue("COL5203889236", value); } 
			}

			/// <summary>
			/// Gets field BookingMinuteFrom 
			/// </summary>
			public string BookingMinuteFrom { 
				get { return GetValue("COL5203889237"); } 
				set { SetValue("COL5203889237", value); } 
			}

			/// <summary>
			/// Gets field Hour 
			/// </summary>
			public string Hour { 
				get { return GetValue("COL52038892318"); } 
				set { SetValue("COL52038892318", value); } 
			}

			/// <summary>
			/// Gets field ModifiedBy 
			/// </summary>
			public string ModifiedBy { 
				get { return GetValue("COL52038892328"); } 
				set { SetValue("COL52038892328", value); } 
			}


			/// <summary>
			/// Gets Status attribute data 
			/// </summary>
			public AttributeData GetStatusAttributeData() { 
				return GetAttributeData("COL52038892314"); 
			}

			/// <summary>
			/// Gets Comment attribute data 
			/// </summary>
			public AttributeData GetCommentAttributeData() { 
				return GetAttributeData("COL52038892324"); 
			}

			/// <summary>
			/// Gets PaidMoneyType attribute data 
			/// </summary>
			public AttributeData GetPaidMoneyTypeAttributeData() { 
				return GetAttributeData("COL52038892334"); 
			}

			/// <summary>
			/// Gets OtherFee01 attribute data 
			/// </summary>
			public AttributeData GetOtherFee01AttributeData() { 
				return GetAttributeData("COL52038892316"); 
			}

			/// <summary>
			/// Gets CreatedBy attribute data 
			/// </summary>
			public AttributeData GetCreatedByAttributeData() { 
				return GetAttributeData("COL52038892326"); 
			}

			/// <summary>
			/// Gets RentHourFrom attribute data 
			/// </summary>
			public AttributeData GetRentHourFromAttributeData() { 
				return GetAttributeData("COL52038892310"); 
			}

			/// <summary>
			/// Gets PriceVND attribute data 
			/// </summary>
			public AttributeData GetPriceVNDAttributeData() { 
				return GetAttributeData("COL52038892320"); 
			}

			/// <summary>
			/// Gets ContractDate attribute data 
			/// </summary>
			public AttributeData GetContractDateAttributeData() { 
				return GetAttributeData("COL52038892330"); 
			}

			/// <summary>
			/// Gets RentHourTo attribute data 
			/// </summary>
			public AttributeData GetRentHourToAttributeData() { 
				return GetAttributeData("COL52038892312"); 
			}

			/// <summary>
			/// Gets HourExtraPriceVND attribute data 
			/// </summary>
			public AttributeData GetHourExtraPriceVNDAttributeData() { 
				return GetAttributeData("COL52038892322"); 
			}

			/// <summary>
			/// Gets RateDate attribute data 
			/// </summary>
			public AttributeData GetRateDateAttributeData() { 
				return GetAttributeData("COL52038892332"); 
			}

			/// <summary>
			/// Gets BookingType attribute data 
			/// </summary>
			public AttributeData GetBookingTypeAttributeData() { 
				return GetAttributeData("COL52038892319"); 
			}

			/// <summary>
			/// Gets DelFlag attribute data 
			/// </summary>
			public AttributeData GetDelFlagAttributeData() { 
				return GetAttributeData("COL52038892329"); 
			}

			/// <summary>
			/// Gets VAT attribute data 
			/// </summary>
			public AttributeData GetVATAttributeData() { 
				return GetAttributeData("COL52038892315"); 
			}

			/// <summary>
			/// Gets Created attribute data 
			/// </summary>
			public AttributeData GetCreatedAttributeData() { 
				return GetAttributeData("COL52038892325"); 
			}

			/// <summary>
			/// Gets OtherFee02 attribute data 
			/// </summary>
			public AttributeData GetOtherFee02AttributeData() { 
				return GetAttributeData("COL52038892317"); 
			}

			/// <summary>
			/// Gets Modified attribute data 
			/// </summary>
			public AttributeData GetModifiedAttributeData() { 
				return GetAttributeData("COL52038892327"); 
			}

			/// <summary>
			/// Gets RentMinuteFrom attribute data 
			/// </summary>
			public AttributeData GetRentMinuteFromAttributeData() { 
				return GetAttributeData("COL52038892311"); 
			}

			/// <summary>
			/// Gets PriceUSD attribute data 
			/// </summary>
			public AttributeData GetPriceUSDAttributeData() { 
				return GetAttributeData("COL52038892321"); 
			}

			/// <summary>
			/// Gets Rate attribute data 
			/// </summary>
			public AttributeData GetRateAttributeData() { 
				return GetAttributeData("COL52038892331"); 
			}

			/// <summary>
			/// Gets RentMinuteTo attribute data 
			/// </summary>
			public AttributeData GetRentMinuteToAttributeData() { 
				return GetAttributeData("COL52038892313"); 
			}

			/// <summary>
			/// Gets HourExtraPriceUSD attribute data 
			/// </summary>
			public AttributeData GetHourExtraPriceUSDAttributeData() { 
				return GetAttributeData("COL52038892323"); 
			}

			/// <summary>
			/// Gets ContractNo attribute data 
			/// </summary>
			public AttributeData GetContractNoAttributeData() { 
				return GetAttributeData("COL52038892333"); 
			}

			/// <summary>
			/// Gets BookingHourTo attribute data 
			/// </summary>
			public AttributeData GetBookingHourToAttributeData() { 
				return GetAttributeData("COL5203889238"); 
			}

			/// <summary>
			/// Gets BookingMinuteTo attribute data 
			/// </summary>
			public AttributeData GetBookingMinuteToAttributeData() { 
				return GetAttributeData("COL5203889239"); 
			}

			/// <summary>
			/// Gets id attribute data 
			/// </summary>
			public AttributeData GetidAttributeData() { 
				return GetAttributeData("COL5203889231"); 
			}

			/// <summary>
			/// Gets BuildingId attribute data 
			/// </summary>
			public AttributeData GetBuildingIdAttributeData() { 
				return GetAttributeData("COL5203889232"); 
			}

			/// <summary>
			/// Gets CustomerId attribute data 
			/// </summary>
			public AttributeData GetCustomerIdAttributeData() { 
				return GetAttributeData("COL5203889233"); 
			}

			/// <summary>
			/// Gets RoomId attribute data 
			/// </summary>
			public AttributeData GetRoomIdAttributeData() { 
				return GetAttributeData("COL5203889234"); 
			}

			/// <summary>
			/// Gets BookingDate attribute data 
			/// </summary>
			public AttributeData GetBookingDateAttributeData() { 
				return GetAttributeData("COL5203889235"); 
			}

			/// <summary>
			/// Gets BookingHourFrom attribute data 
			/// </summary>
			public AttributeData GetBookingHourFromAttributeData() { 
				return GetAttributeData("COL5203889236"); 
			}

			/// <summary>
			/// Gets BookingMinuteFrom attribute data 
			/// </summary>
			public AttributeData GetBookingMinuteFromAttributeData() { 
				return GetAttributeData("COL5203889237"); 
			}

			/// <summary>
			/// Gets Hour attribute data 
			/// </summary>
			public AttributeData GetHourAttributeData() { 
				return GetAttributeData("COL52038892318"); 
			}

			/// <summary>
			/// Gets ModifiedBy attribute data 
			/// </summary>
			public AttributeData GetModifiedByAttributeData() { 
				return GetAttributeData("COL52038892328"); 
			}


			/// <summary>
			/// Gets column Status with alias  
			/// </summary>
			public string ColStatus { 
				get { return GetColumnName("COL52038892314"); } 
			}

			/// <summary>
			/// Gets column Comment with alias  
			/// </summary>
			public string ColComment { 
				get { return GetColumnName("COL52038892324"); } 
			}

			/// <summary>
			/// Gets column PaidMoneyType with alias  
			/// </summary>
			public string ColPaidMoneyType { 
				get { return GetColumnName("COL52038892334"); } 
			}

			/// <summary>
			/// Gets column OtherFee01 with alias  
			/// </summary>
			public string ColOtherFee01 { 
				get { return GetColumnName("COL52038892316"); } 
			}

			/// <summary>
			/// Gets column CreatedBy with alias  
			/// </summary>
			public string ColCreatedBy { 
				get { return GetColumnName("COL52038892326"); } 
			}

			/// <summary>
			/// Gets column RentHourFrom with alias  
			/// </summary>
			public string ColRentHourFrom { 
				get { return GetColumnName("COL52038892310"); } 
			}

			/// <summary>
			/// Gets column PriceVND with alias  
			/// </summary>
			public string ColPriceVND { 
				get { return GetColumnName("COL52038892320"); } 
			}

			/// <summary>
			/// Gets column ContractDate with alias  
			/// </summary>
			public string ColContractDate { 
				get { return GetColumnName("COL52038892330"); } 
			}

			/// <summary>
			/// Gets column RentHourTo with alias  
			/// </summary>
			public string ColRentHourTo { 
				get { return GetColumnName("COL52038892312"); } 
			}

			/// <summary>
			/// Gets column HourExtraPriceVND with alias  
			/// </summary>
			public string ColHourExtraPriceVND { 
				get { return GetColumnName("COL52038892322"); } 
			}

			/// <summary>
			/// Gets column RateDate with alias  
			/// </summary>
			public string ColRateDate { 
				get { return GetColumnName("COL52038892332"); } 
			}

			/// <summary>
			/// Gets column BookingType with alias  
			/// </summary>
			public string ColBookingType { 
				get { return GetColumnName("COL52038892319"); } 
			}

			/// <summary>
			/// Gets column DelFlag with alias  
			/// </summary>
			public string ColDelFlag { 
				get { return GetColumnName("COL52038892329"); } 
			}

			/// <summary>
			/// Gets column VAT with alias  
			/// </summary>
			public string ColVAT { 
				get { return GetColumnName("COL52038892315"); } 
			}

			/// <summary>
			/// Gets column Created with alias  
			/// </summary>
			public string ColCreated { 
				get { return GetColumnName("COL52038892325"); } 
			}

			/// <summary>
			/// Gets column OtherFee02 with alias  
			/// </summary>
			public string ColOtherFee02 { 
				get { return GetColumnName("COL52038892317"); } 
			}

			/// <summary>
			/// Gets column Modified with alias  
			/// </summary>
			public string ColModified { 
				get { return GetColumnName("COL52038892327"); } 
			}

			/// <summary>
			/// Gets column RentMinuteFrom with alias  
			/// </summary>
			public string ColRentMinuteFrom { 
				get { return GetColumnName("COL52038892311"); } 
			}

			/// <summary>
			/// Gets column PriceUSD with alias  
			/// </summary>
			public string ColPriceUSD { 
				get { return GetColumnName("COL52038892321"); } 
			}

			/// <summary>
			/// Gets column Rate with alias  
			/// </summary>
			public string ColRate { 
				get { return GetColumnName("COL52038892331"); } 
			}

			/// <summary>
			/// Gets column RentMinuteTo with alias  
			/// </summary>
			public string ColRentMinuteTo { 
				get { return GetColumnName("COL52038892313"); } 
			}

			/// <summary>
			/// Gets column HourExtraPriceUSD with alias  
			/// </summary>
			public string ColHourExtraPriceUSD { 
				get { return GetColumnName("COL52038892323"); } 
			}

			/// <summary>
			/// Gets column ContractNo with alias  
			/// </summary>
			public string ColContractNo { 
				get { return GetColumnName("COL52038892333"); } 
			}

			/// <summary>
			/// Gets column BookingHourTo with alias  
			/// </summary>
			public string ColBookingHourTo { 
				get { return GetColumnName("COL5203889238"); } 
			}

			/// <summary>
			/// Gets column BookingMinuteTo with alias  
			/// </summary>
			public string ColBookingMinuteTo { 
				get { return GetColumnName("COL5203889239"); } 
			}

			/// <summary>
			/// Gets column id with alias  
			/// </summary>
			public string Colid { 
				get { return GetColumnName("COL5203889231"); } 
			}

			/// <summary>
			/// Gets column BuildingId with alias  
			/// </summary>
			public string ColBuildingId { 
				get { return GetColumnName("COL5203889232"); } 
			}

			/// <summary>
			/// Gets column CustomerId with alias  
			/// </summary>
			public string ColCustomerId { 
				get { return GetColumnName("COL5203889233"); } 
			}

			/// <summary>
			/// Gets column RoomId with alias  
			/// </summary>
			public string ColRoomId { 
				get { return GetColumnName("COL5203889234"); } 
			}

			/// <summary>
			/// Gets column BookingDate with alias  
			/// </summary>
			public string ColBookingDate { 
				get { return GetColumnName("COL5203889235"); } 
			}

			/// <summary>
			/// Gets column BookingHourFrom with alias  
			/// </summary>
			public string ColBookingHourFrom { 
				get { return GetColumnName("COL5203889236"); } 
			}

			/// <summary>
			/// Gets column BookingMinuteFrom with alias  
			/// </summary>
			public string ColBookingMinuteFrom { 
				get { return GetColumnName("COL5203889237"); } 
			}

			/// <summary>
			/// Gets column Hour with alias  
			/// </summary>
			public string ColHour { 
				get { return GetColumnName("COL52038892318"); } 
			}

			/// <summary>
			/// Gets column ModifiedBy with alias  
			/// </summary>
			public string ColModifiedBy { 
				get { return GetColumnName("COL52038892328"); } 
			}


			/// <summary>
			/// Checks whether column Status is added in select statement 
			/// </summary>
			public bool IsSelectStatus { 
				get { return IsSelect("COL52038892314"); } 
				set { SetSelect("COL52038892314", value); } 
			}

			/// <summary>
			/// Checks whether column Comment is added in select statement 
			/// </summary>
			public bool IsSelectComment { 
				get { return IsSelect("COL52038892324"); } 
				set { SetSelect("COL52038892324", value); } 
			}

			/// <summary>
			/// Checks whether column PaidMoneyType is added in select statement 
			/// </summary>
			public bool IsSelectPaidMoneyType { 
				get { return IsSelect("COL52038892334"); } 
				set { SetSelect("COL52038892334", value); } 
			}

			/// <summary>
			/// Checks whether column OtherFee01 is added in select statement 
			/// </summary>
			public bool IsSelectOtherFee01 { 
				get { return IsSelect("COL52038892316"); } 
				set { SetSelect("COL52038892316", value); } 
			}

			/// <summary>
			/// Checks whether column CreatedBy is added in select statement 
			/// </summary>
			public bool IsSelectCreatedBy { 
				get { return IsSelect("COL52038892326"); } 
				set { SetSelect("COL52038892326", value); } 
			}

			/// <summary>
			/// Checks whether column RentHourFrom is added in select statement 
			/// </summary>
			public bool IsSelectRentHourFrom { 
				get { return IsSelect("COL52038892310"); } 
				set { SetSelect("COL52038892310", value); } 
			}

			/// <summary>
			/// Checks whether column PriceVND is added in select statement 
			/// </summary>
			public bool IsSelectPriceVND { 
				get { return IsSelect("COL52038892320"); } 
				set { SetSelect("COL52038892320", value); } 
			}

			/// <summary>
			/// Checks whether column ContractDate is added in select statement 
			/// </summary>
			public bool IsSelectContractDate { 
				get { return IsSelect("COL52038892330"); } 
				set { SetSelect("COL52038892330", value); } 
			}

			/// <summary>
			/// Checks whether column RentHourTo is added in select statement 
			/// </summary>
			public bool IsSelectRentHourTo { 
				get { return IsSelect("COL52038892312"); } 
				set { SetSelect("COL52038892312", value); } 
			}

			/// <summary>
			/// Checks whether column HourExtraPriceVND is added in select statement 
			/// </summary>
			public bool IsSelectHourExtraPriceVND { 
				get { return IsSelect("COL52038892322"); } 
				set { SetSelect("COL52038892322", value); } 
			}

			/// <summary>
			/// Checks whether column RateDate is added in select statement 
			/// </summary>
			public bool IsSelectRateDate { 
				get { return IsSelect("COL52038892332"); } 
				set { SetSelect("COL52038892332", value); } 
			}

			/// <summary>
			/// Checks whether column BookingType is added in select statement 
			/// </summary>
			public bool IsSelectBookingType { 
				get { return IsSelect("COL52038892319"); } 
				set { SetSelect("COL52038892319", value); } 
			}

			/// <summary>
			/// Checks whether column DelFlag is added in select statement 
			/// </summary>
			public bool IsSelectDelFlag { 
				get { return IsSelect("COL52038892329"); } 
				set { SetSelect("COL52038892329", value); } 
			}

			/// <summary>
			/// Checks whether column VAT is added in select statement 
			/// </summary>
			public bool IsSelectVAT { 
				get { return IsSelect("COL52038892315"); } 
				set { SetSelect("COL52038892315", value); } 
			}

			/// <summary>
			/// Checks whether column Created is added in select statement 
			/// </summary>
			public bool IsSelectCreated { 
				get { return IsSelect("COL52038892325"); } 
				set { SetSelect("COL52038892325", value); } 
			}

			/// <summary>
			/// Checks whether column OtherFee02 is added in select statement 
			/// </summary>
			public bool IsSelectOtherFee02 { 
				get { return IsSelect("COL52038892317"); } 
				set { SetSelect("COL52038892317", value); } 
			}

			/// <summary>
			/// Checks whether column Modified is added in select statement 
			/// </summary>
			public bool IsSelectModified { 
				get { return IsSelect("COL52038892327"); } 
				set { SetSelect("COL52038892327", value); } 
			}

			/// <summary>
			/// Checks whether column RentMinuteFrom is added in select statement 
			/// </summary>
			public bool IsSelectRentMinuteFrom { 
				get { return IsSelect("COL52038892311"); } 
				set { SetSelect("COL52038892311", value); } 
			}

			/// <summary>
			/// Checks whether column PriceUSD is added in select statement 
			/// </summary>
			public bool IsSelectPriceUSD { 
				get { return IsSelect("COL52038892321"); } 
				set { SetSelect("COL52038892321", value); } 
			}

			/// <summary>
			/// Checks whether column Rate is added in select statement 
			/// </summary>
			public bool IsSelectRate { 
				get { return IsSelect("COL52038892331"); } 
				set { SetSelect("COL52038892331", value); } 
			}

			/// <summary>
			/// Checks whether column RentMinuteTo is added in select statement 
			/// </summary>
			public bool IsSelectRentMinuteTo { 
				get { return IsSelect("COL52038892313"); } 
				set { SetSelect("COL52038892313", value); } 
			}

			/// <summary>
			/// Checks whether column HourExtraPriceUSD is added in select statement 
			/// </summary>
			public bool IsSelectHourExtraPriceUSD { 
				get { return IsSelect("COL52038892323"); } 
				set { SetSelect("COL52038892323", value); } 
			}

			/// <summary>
			/// Checks whether column ContractNo is added in select statement 
			/// </summary>
			public bool IsSelectContractNo { 
				get { return IsSelect("COL52038892333"); } 
				set { SetSelect("COL52038892333", value); } 
			}

			/// <summary>
			/// Checks whether column BookingHourTo is added in select statement 
			/// </summary>
			public bool IsSelectBookingHourTo { 
				get { return IsSelect("COL5203889238"); } 
				set { SetSelect("COL5203889238", value); } 
			}

			/// <summary>
			/// Checks whether column BookingMinuteTo is added in select statement 
			/// </summary>
			public bool IsSelectBookingMinuteTo { 
				get { return IsSelect("COL5203889239"); } 
				set { SetSelect("COL5203889239", value); } 
			}

			/// <summary>
			/// Checks whether column id is added in select statement 
			/// </summary>
			public bool IsSelectid { 
				get { return IsSelect("COL5203889231"); } 
				set { SetSelect("COL5203889231", value); } 
			}

			/// <summary>
			/// Checks whether column BuildingId is added in select statement 
			/// </summary>
			public bool IsSelectBuildingId { 
				get { return IsSelect("COL5203889232"); } 
				set { SetSelect("COL5203889232", value); } 
			}

			/// <summary>
			/// Checks whether column CustomerId is added in select statement 
			/// </summary>
			public bool IsSelectCustomerId { 
				get { return IsSelect("COL5203889233"); } 
				set { SetSelect("COL5203889233", value); } 
			}

			/// <summary>
			/// Checks whether column RoomId is added in select statement 
			/// </summary>
			public bool IsSelectRoomId { 
				get { return IsSelect("COL5203889234"); } 
				set { SetSelect("COL5203889234", value); } 
			}

			/// <summary>
			/// Checks whether column BookingDate is added in select statement 
			/// </summary>
			public bool IsSelectBookingDate { 
				get { return IsSelect("COL5203889235"); } 
				set { SetSelect("COL5203889235", value); } 
			}

			/// <summary>
			/// Checks whether column BookingHourFrom is added in select statement 
			/// </summary>
			public bool IsSelectBookingHourFrom { 
				get { return IsSelect("COL5203889236"); } 
				set { SetSelect("COL5203889236", value); } 
			}

			/// <summary>
			/// Checks whether column BookingMinuteFrom is added in select statement 
			/// </summary>
			public bool IsSelectBookingMinuteFrom { 
				get { return IsSelect("COL5203889237"); } 
				set { SetSelect("COL5203889237", value); } 
			}

			/// <summary>
			/// Checks whether column Hour is added in select statement 
			/// </summary>
			public bool IsSelectHour { 
				get { return IsSelect("COL52038892318"); } 
				set { SetSelect("COL52038892318", value); } 
			}

			/// <summary>
			/// Checks whether column ModifiedBy is added in select statement 
			/// </summary>
			public bool IsSelectModifiedBy { 
				get { return IsSelect("COL52038892328"); } 
				set { SetSelect("COL52038892328", value); } 
			}



	}
}