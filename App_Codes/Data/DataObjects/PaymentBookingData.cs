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
	public class PaymentBookingData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ1208391374";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of PaymentBooking 
			/// </summary>
			public PaymentBookingData(string objectID): base(objectID) {}  

			public PaymentBookingData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field RentHourTo 
			/// </summary>
			public string RentHourTo { 
				get { return GetValue("COL120839137415"); } 
				set { SetValue("COL120839137415", value); } 
			}

			/// <summary>
			/// Gets field ServiceVAT 
			/// </summary>
			public string ServiceVAT { 
				get { return GetValue("COL120839137438"); } 
				set { SetValue("COL120839137438", value); } 
			}

			/// <summary>
			/// Gets field SumUSD 
			/// </summary>
			public string SumUSD { 
				get { return GetValue("COL120839137426"); } 
				set { SetValue("COL120839137426", value); } 
			}

			/// <summary>
			/// Gets field OtherFee02 
			/// </summary>
			public string OtherFee02 { 
				get { return GetValue("COL120839137421"); } 
				set { SetValue("COL120839137421", value); } 
			}

			/// <summary>
			/// Gets field PriceVND 
			/// </summary>
			public string PriceVND { 
				get { return GetValue("COL120839137423"); } 
				set { SetValue("COL120839137423", value); } 
			}

			/// <summary>
			/// Gets field PaidUSD 
			/// </summary>
			public string PaidUSD { 
				get { return GetValue("COL120839137451"); } 
				set { SetValue("COL120839137451", value); } 
			}

			/// <summary>
			/// Gets field RentMinuteFrom 
			/// </summary>
			public string RentMinuteFrom { 
				get { return GetValue("COL120839137414"); } 
				set { SetValue("COL120839137414", value); } 
			}

			/// <summary>
			/// Gets field BookingHourTo 
			/// </summary>
			public string BookingHourTo { 
				get { return GetValue("COL120839137411"); } 
				set { SetValue("COL120839137411", value); } 
			}

			/// <summary>
			/// Gets field Comment 
			/// </summary>
			public string Comment { 
				get { return GetValue("COL120839137431"); } 
				set { SetValue("COL120839137431", value); } 
			}

			/// <summary>
			/// Gets field ContractNo 
			/// </summary>
			public string ContractNo { 
				get { return GetValue("COL120839137450"); } 
				set { SetValue("COL120839137450", value); } 
			}

			/// <summary>
			/// Gets field RoomId 
			/// </summary>
			public string RoomId { 
				get { return GetValue("COL12083913745"); } 
				set { SetValue("COL12083913745", value); } 
			}

			/// <summary>
			/// Gets field DelFlag 
			/// </summary>
			public string DelFlag { 
				get { return GetValue("COL120839137436"); } 
				set { SetValue("COL120839137436", value); } 
			}

			/// <summary>
			/// Gets field VatVND 
			/// </summary>
			public string VatVND { 
				get { return GetValue("COL120839137425"); } 
				set { SetValue("COL120839137425", value); } 
			}

			/// <summary>
			/// Gets field BookingMinuteFrom 
			/// </summary>
			public string BookingMinuteFrom { 
				get { return GetValue("COL120839137410"); } 
				set { SetValue("COL120839137410", value); } 
			}

			/// <summary>
			/// Gets field RateDate 
			/// </summary>
			public string RateDate { 
				get { return GetValue("COL120839137449"); } 
				set { SetValue("COL120839137449", value); } 
			}

			/// <summary>
			/// Gets field id 
			/// </summary>
			public string id { 
				get { return GetValue("COL12083913741"); } 
				set { SetValue("COL12083913741", value); } 
			}

			/// <summary>
			/// Gets field Hour 
			/// </summary>
			public string Hour { 
				get { return GetValue("COL120839137430"); } 
				set { SetValue("COL120839137430", value); } 
			}

			/// <summary>
			/// Gets field BuildingId 
			/// </summary>
			public string BuildingId { 
				get { return GetValue("COL12083913743"); } 
				set { SetValue("COL12083913743", value); } 
			}

			/// <summary>
			/// Gets field ServiceSumUSD 
			/// </summary>
			public string ServiceSumUSD { 
				get { return GetValue("COL120839137443"); } 
				set { SetValue("COL120839137443", value); } 
			}

			/// <summary>
			/// Gets field LastPriceVND 
			/// </summary>
			public string LastPriceVND { 
				get { return GetValue("COL120839137429"); } 
				set { SetValue("COL120839137429", value); } 
			}

			/// <summary>
			/// Gets field HourExtraPriceVND 
			/// </summary>
			public string HourExtraPriceVND { 
				get { return GetValue("COL120839137417"); } 
				set { SetValue("COL120839137417", value); } 
			}

			/// <summary>
			/// Gets field BookingHourFrom 
			/// </summary>
			public string BookingHourFrom { 
				get { return GetValue("COL12083913749"); } 
				set { SetValue("COL12083913749", value); } 
			}

			/// <summary>
			/// Gets field Status 
			/// </summary>
			public string Status { 
				get { return GetValue("COL120839137437"); } 
				set { SetValue("COL120839137437", value); } 
			}

			/// <summary>
			/// Gets field ServiceLastPriceUSD 
			/// </summary>
			public string ServiceLastPriceUSD { 
				get { return GetValue("COL120839137445"); } 
				set { SetValue("COL120839137445", value); } 
			}

			/// <summary>
			/// Gets field ModifiedBy 
			/// </summary>
			public string ModifiedBy { 
				get { return GetValue("COL120839137435"); } 
				set { SetValue("COL120839137435", value); } 
			}

			/// <summary>
			/// Gets field LastPriceUSD 
			/// </summary>
			public string LastPriceUSD { 
				get { return GetValue("COL120839137428"); } 
				set { SetValue("COL120839137428", value); } 
			}

			/// <summary>
			/// Gets field RentMinuteTo 
			/// </summary>
			public string RentMinuteTo { 
				get { return GetValue("COL120839137416"); } 
				set { SetValue("COL120839137416", value); } 
			}

			/// <summary>
			/// Gets field RentHourFrom 
			/// </summary>
			public string RentHourFrom { 
				get { return GetValue("COL120839137413"); } 
				set { SetValue("COL120839137413", value); } 
			}

			/// <summary>
			/// Gets field ServiceSumVND 
			/// </summary>
			public string ServiceSumVND { 
				get { return GetValue("COL120839137444"); } 
				set { SetValue("COL120839137444", value); } 
			}

			/// <summary>
			/// Gets field CreatedBy 
			/// </summary>
			public string CreatedBy { 
				get { return GetValue("COL120839137433"); } 
				set { SetValue("COL120839137433", value); } 
			}

			/// <summary>
			/// Gets field ServiceVatUSD 
			/// </summary>
			public string ServiceVatUSD { 
				get { return GetValue("COL120839137441"); } 
				set { SetValue("COL120839137441", value); } 
			}

			/// <summary>
			/// Gets field PaidVND 
			/// </summary>
			public string PaidVND { 
				get { return GetValue("COL120839137452"); } 
				set { SetValue("COL120839137452", value); } 
			}

			/// <summary>
			/// Gets field VatUSD 
			/// </summary>
			public string VatUSD { 
				get { return GetValue("COL120839137424"); } 
				set { SetValue("COL120839137424", value); } 
			}

			/// <summary>
			/// Gets field BookingMinuteTo 
			/// </summary>
			public string BookingMinuteTo { 
				get { return GetValue("COL120839137412"); } 
				set { SetValue("COL120839137412", value); } 
			}

			/// <summary>
			/// Gets field ServiceVatVND 
			/// </summary>
			public string ServiceVatVND { 
				get { return GetValue("COL120839137442"); } 
				set { SetValue("COL120839137442", value); } 
			}

			/// <summary>
			/// Gets field Created 
			/// </summary>
			public string Created { 
				get { return GetValue("COL120839137432"); } 
				set { SetValue("COL120839137432", value); } 
			}

			/// <summary>
			/// Gets field ServiceOtherFee02 
			/// </summary>
			public string ServiceOtherFee02 { 
				get { return GetValue("COL120839137440"); } 
				set { SetValue("COL120839137440", value); } 
			}

			/// <summary>
			/// Gets field CustomerId 
			/// </summary>
			public string CustomerId { 
				get { return GetValue("COL12083913744"); } 
				set { SetValue("COL12083913744", value); } 
			}

			/// <summary>
			/// Gets field BookingId 
			/// </summary>
			public string BookingId { 
				get { return GetValue("COL12083913746"); } 
				set { SetValue("COL12083913746", value); } 
			}

			/// <summary>
			/// Gets field OtherFee01 
			/// </summary>
			public string OtherFee01 { 
				get { return GetValue("COL120839137420"); } 
				set { SetValue("COL120839137420", value); } 
			}

			/// <summary>
			/// Gets field Modified 
			/// </summary>
			public string Modified { 
				get { return GetValue("COL120839137434"); } 
				set { SetValue("COL120839137434", value); } 
			}

			/// <summary>
			/// Gets field YearMonth 
			/// </summary>
			public string YearMonth { 
				get { return GetValue("COL12083913742"); } 
				set { SetValue("COL12083913742", value); } 
			}

			/// <summary>
			/// Gets field ContractDate 
			/// </summary>
			public string ContractDate { 
				get { return GetValue("COL120839137447"); } 
				set { SetValue("COL120839137447", value); } 
			}

			/// <summary>
			/// Gets field PriceUSD 
			/// </summary>
			public string PriceUSD { 
				get { return GetValue("COL120839137422"); } 
				set { SetValue("COL120839137422", value); } 
			}

			/// <summary>
			/// Gets field BookingDate 
			/// </summary>
			public string BookingDate { 
				get { return GetValue("COL12083913747"); } 
				set { SetValue("COL12083913747", value); } 
			}

			/// <summary>
			/// Gets field VAT 
			/// </summary>
			public string VAT { 
				get { return GetValue("COL120839137419"); } 
				set { SetValue("COL120839137419", value); } 
			}

			/// <summary>
			/// Gets field ServiceOtherFee01 
			/// </summary>
			public string ServiceOtherFee01 { 
				get { return GetValue("COL120839137439"); } 
				set { SetValue("COL120839137439", value); } 
			}

			/// <summary>
			/// Gets field BookingType 
			/// </summary>
			public string BookingType { 
				get { return GetValue("COL12083913748"); } 
				set { SetValue("COL12083913748", value); } 
			}

			/// <summary>
			/// Gets field SumVND 
			/// </summary>
			public string SumVND { 
				get { return GetValue("COL120839137427"); } 
				set { SetValue("COL120839137427", value); } 
			}

			/// <summary>
			/// Gets field Rate 
			/// </summary>
			public string Rate { 
				get { return GetValue("COL120839137448"); } 
				set { SetValue("COL120839137448", value); } 
			}

			/// <summary>
			/// Gets field ServiceLastPriceVND 
			/// </summary>
			public string ServiceLastPriceVND { 
				get { return GetValue("COL120839137446"); } 
				set { SetValue("COL120839137446", value); } 
			}

			/// <summary>
			/// Gets field HourExtraPriceUSD 
			/// </summary>
			public string HourExtraPriceUSD { 
				get { return GetValue("COL120839137418"); } 
				set { SetValue("COL120839137418", value); } 
			}


			/// <summary>
			/// Gets RentHourTo attribute data 
			/// </summary>
			public AttributeData GetRentHourToAttributeData() { 
				return GetAttributeData("COL120839137415"); 
			}

			/// <summary>
			/// Gets ServiceVAT attribute data 
			/// </summary>
			public AttributeData GetServiceVATAttributeData() { 
				return GetAttributeData("COL120839137438"); 
			}

			/// <summary>
			/// Gets SumUSD attribute data 
			/// </summary>
			public AttributeData GetSumUSDAttributeData() { 
				return GetAttributeData("COL120839137426"); 
			}

			/// <summary>
			/// Gets OtherFee02 attribute data 
			/// </summary>
			public AttributeData GetOtherFee02AttributeData() { 
				return GetAttributeData("COL120839137421"); 
			}

			/// <summary>
			/// Gets PriceVND attribute data 
			/// </summary>
			public AttributeData GetPriceVNDAttributeData() { 
				return GetAttributeData("COL120839137423"); 
			}

			/// <summary>
			/// Gets PaidUSD attribute data 
			/// </summary>
			public AttributeData GetPaidUSDAttributeData() { 
				return GetAttributeData("COL120839137451"); 
			}

			/// <summary>
			/// Gets RentMinuteFrom attribute data 
			/// </summary>
			public AttributeData GetRentMinuteFromAttributeData() { 
				return GetAttributeData("COL120839137414"); 
			}

			/// <summary>
			/// Gets BookingHourTo attribute data 
			/// </summary>
			public AttributeData GetBookingHourToAttributeData() { 
				return GetAttributeData("COL120839137411"); 
			}

			/// <summary>
			/// Gets Comment attribute data 
			/// </summary>
			public AttributeData GetCommentAttributeData() { 
				return GetAttributeData("COL120839137431"); 
			}

			/// <summary>
			/// Gets ContractNo attribute data 
			/// </summary>
			public AttributeData GetContractNoAttributeData() { 
				return GetAttributeData("COL120839137450"); 
			}

			/// <summary>
			/// Gets RoomId attribute data 
			/// </summary>
			public AttributeData GetRoomIdAttributeData() { 
				return GetAttributeData("COL12083913745"); 
			}

			/// <summary>
			/// Gets DelFlag attribute data 
			/// </summary>
			public AttributeData GetDelFlagAttributeData() { 
				return GetAttributeData("COL120839137436"); 
			}

			/// <summary>
			/// Gets VatVND attribute data 
			/// </summary>
			public AttributeData GetVatVNDAttributeData() { 
				return GetAttributeData("COL120839137425"); 
			}

			/// <summary>
			/// Gets BookingMinuteFrom attribute data 
			/// </summary>
			public AttributeData GetBookingMinuteFromAttributeData() { 
				return GetAttributeData("COL120839137410"); 
			}

			/// <summary>
			/// Gets RateDate attribute data 
			/// </summary>
			public AttributeData GetRateDateAttributeData() { 
				return GetAttributeData("COL120839137449"); 
			}

			/// <summary>
			/// Gets id attribute data 
			/// </summary>
			public AttributeData GetidAttributeData() { 
				return GetAttributeData("COL12083913741"); 
			}

			/// <summary>
			/// Gets Hour attribute data 
			/// </summary>
			public AttributeData GetHourAttributeData() { 
				return GetAttributeData("COL120839137430"); 
			}

			/// <summary>
			/// Gets BuildingId attribute data 
			/// </summary>
			public AttributeData GetBuildingIdAttributeData() { 
				return GetAttributeData("COL12083913743"); 
			}

			/// <summary>
			/// Gets ServiceSumUSD attribute data 
			/// </summary>
			public AttributeData GetServiceSumUSDAttributeData() { 
				return GetAttributeData("COL120839137443"); 
			}

			/// <summary>
			/// Gets LastPriceVND attribute data 
			/// </summary>
			public AttributeData GetLastPriceVNDAttributeData() { 
				return GetAttributeData("COL120839137429"); 
			}

			/// <summary>
			/// Gets HourExtraPriceVND attribute data 
			/// </summary>
			public AttributeData GetHourExtraPriceVNDAttributeData() { 
				return GetAttributeData("COL120839137417"); 
			}

			/// <summary>
			/// Gets BookingHourFrom attribute data 
			/// </summary>
			public AttributeData GetBookingHourFromAttributeData() { 
				return GetAttributeData("COL12083913749"); 
			}

			/// <summary>
			/// Gets Status attribute data 
			/// </summary>
			public AttributeData GetStatusAttributeData() { 
				return GetAttributeData("COL120839137437"); 
			}

			/// <summary>
			/// Gets ServiceLastPriceUSD attribute data 
			/// </summary>
			public AttributeData GetServiceLastPriceUSDAttributeData() { 
				return GetAttributeData("COL120839137445"); 
			}

			/// <summary>
			/// Gets ModifiedBy attribute data 
			/// </summary>
			public AttributeData GetModifiedByAttributeData() { 
				return GetAttributeData("COL120839137435"); 
			}

			/// <summary>
			/// Gets LastPriceUSD attribute data 
			/// </summary>
			public AttributeData GetLastPriceUSDAttributeData() { 
				return GetAttributeData("COL120839137428"); 
			}

			/// <summary>
			/// Gets RentMinuteTo attribute data 
			/// </summary>
			public AttributeData GetRentMinuteToAttributeData() { 
				return GetAttributeData("COL120839137416"); 
			}

			/// <summary>
			/// Gets RentHourFrom attribute data 
			/// </summary>
			public AttributeData GetRentHourFromAttributeData() { 
				return GetAttributeData("COL120839137413"); 
			}

			/// <summary>
			/// Gets ServiceSumVND attribute data 
			/// </summary>
			public AttributeData GetServiceSumVNDAttributeData() { 
				return GetAttributeData("COL120839137444"); 
			}

			/// <summary>
			/// Gets CreatedBy attribute data 
			/// </summary>
			public AttributeData GetCreatedByAttributeData() { 
				return GetAttributeData("COL120839137433"); 
			}

			/// <summary>
			/// Gets ServiceVatUSD attribute data 
			/// </summary>
			public AttributeData GetServiceVatUSDAttributeData() { 
				return GetAttributeData("COL120839137441"); 
			}

			/// <summary>
			/// Gets PaidVND attribute data 
			/// </summary>
			public AttributeData GetPaidVNDAttributeData() { 
				return GetAttributeData("COL120839137452"); 
			}

			/// <summary>
			/// Gets VatUSD attribute data 
			/// </summary>
			public AttributeData GetVatUSDAttributeData() { 
				return GetAttributeData("COL120839137424"); 
			}

			/// <summary>
			/// Gets BookingMinuteTo attribute data 
			/// </summary>
			public AttributeData GetBookingMinuteToAttributeData() { 
				return GetAttributeData("COL120839137412"); 
			}

			/// <summary>
			/// Gets ServiceVatVND attribute data 
			/// </summary>
			public AttributeData GetServiceVatVNDAttributeData() { 
				return GetAttributeData("COL120839137442"); 
			}

			/// <summary>
			/// Gets Created attribute data 
			/// </summary>
			public AttributeData GetCreatedAttributeData() { 
				return GetAttributeData("COL120839137432"); 
			}

			/// <summary>
			/// Gets ServiceOtherFee02 attribute data 
			/// </summary>
			public AttributeData GetServiceOtherFee02AttributeData() { 
				return GetAttributeData("COL120839137440"); 
			}

			/// <summary>
			/// Gets CustomerId attribute data 
			/// </summary>
			public AttributeData GetCustomerIdAttributeData() { 
				return GetAttributeData("COL12083913744"); 
			}

			/// <summary>
			/// Gets BookingId attribute data 
			/// </summary>
			public AttributeData GetBookingIdAttributeData() { 
				return GetAttributeData("COL12083913746"); 
			}

			/// <summary>
			/// Gets OtherFee01 attribute data 
			/// </summary>
			public AttributeData GetOtherFee01AttributeData() { 
				return GetAttributeData("COL120839137420"); 
			}

			/// <summary>
			/// Gets Modified attribute data 
			/// </summary>
			public AttributeData GetModifiedAttributeData() { 
				return GetAttributeData("COL120839137434"); 
			}

			/// <summary>
			/// Gets YearMonth attribute data 
			/// </summary>
			public AttributeData GetYearMonthAttributeData() { 
				return GetAttributeData("COL12083913742"); 
			}

			/// <summary>
			/// Gets ContractDate attribute data 
			/// </summary>
			public AttributeData GetContractDateAttributeData() { 
				return GetAttributeData("COL120839137447"); 
			}

			/// <summary>
			/// Gets PriceUSD attribute data 
			/// </summary>
			public AttributeData GetPriceUSDAttributeData() { 
				return GetAttributeData("COL120839137422"); 
			}

			/// <summary>
			/// Gets BookingDate attribute data 
			/// </summary>
			public AttributeData GetBookingDateAttributeData() { 
				return GetAttributeData("COL12083913747"); 
			}

			/// <summary>
			/// Gets VAT attribute data 
			/// </summary>
			public AttributeData GetVATAttributeData() { 
				return GetAttributeData("COL120839137419"); 
			}

			/// <summary>
			/// Gets ServiceOtherFee01 attribute data 
			/// </summary>
			public AttributeData GetServiceOtherFee01AttributeData() { 
				return GetAttributeData("COL120839137439"); 
			}

			/// <summary>
			/// Gets BookingType attribute data 
			/// </summary>
			public AttributeData GetBookingTypeAttributeData() { 
				return GetAttributeData("COL12083913748"); 
			}

			/// <summary>
			/// Gets SumVND attribute data 
			/// </summary>
			public AttributeData GetSumVNDAttributeData() { 
				return GetAttributeData("COL120839137427"); 
			}

			/// <summary>
			/// Gets Rate attribute data 
			/// </summary>
			public AttributeData GetRateAttributeData() { 
				return GetAttributeData("COL120839137448"); 
			}

			/// <summary>
			/// Gets ServiceLastPriceVND attribute data 
			/// </summary>
			public AttributeData GetServiceLastPriceVNDAttributeData() { 
				return GetAttributeData("COL120839137446"); 
			}

			/// <summary>
			/// Gets HourExtraPriceUSD attribute data 
			/// </summary>
			public AttributeData GetHourExtraPriceUSDAttributeData() { 
				return GetAttributeData("COL120839137418"); 
			}


			/// <summary>
			/// Gets column RentHourTo with alias  
			/// </summary>
			public string ColRentHourTo { 
				get { return GetColumnName("COL120839137415"); } 
			}

			/// <summary>
			/// Gets column ServiceVAT with alias  
			/// </summary>
			public string ColServiceVAT { 
				get { return GetColumnName("COL120839137438"); } 
			}

			/// <summary>
			/// Gets column SumUSD with alias  
			/// </summary>
			public string ColSumUSD { 
				get { return GetColumnName("COL120839137426"); } 
			}

			/// <summary>
			/// Gets column OtherFee02 with alias  
			/// </summary>
			public string ColOtherFee02 { 
				get { return GetColumnName("COL120839137421"); } 
			}

			/// <summary>
			/// Gets column PriceVND with alias  
			/// </summary>
			public string ColPriceVND { 
				get { return GetColumnName("COL120839137423"); } 
			}

			/// <summary>
			/// Gets column PaidUSD with alias  
			/// </summary>
			public string ColPaidUSD { 
				get { return GetColumnName("COL120839137451"); } 
			}

			/// <summary>
			/// Gets column RentMinuteFrom with alias  
			/// </summary>
			public string ColRentMinuteFrom { 
				get { return GetColumnName("COL120839137414"); } 
			}

			/// <summary>
			/// Gets column BookingHourTo with alias  
			/// </summary>
			public string ColBookingHourTo { 
				get { return GetColumnName("COL120839137411"); } 
			}

			/// <summary>
			/// Gets column Comment with alias  
			/// </summary>
			public string ColComment { 
				get { return GetColumnName("COL120839137431"); } 
			}

			/// <summary>
			/// Gets column ContractNo with alias  
			/// </summary>
			public string ColContractNo { 
				get { return GetColumnName("COL120839137450"); } 
			}

			/// <summary>
			/// Gets column RoomId with alias  
			/// </summary>
			public string ColRoomId { 
				get { return GetColumnName("COL12083913745"); } 
			}

			/// <summary>
			/// Gets column DelFlag with alias  
			/// </summary>
			public string ColDelFlag { 
				get { return GetColumnName("COL120839137436"); } 
			}

			/// <summary>
			/// Gets column VatVND with alias  
			/// </summary>
			public string ColVatVND { 
				get { return GetColumnName("COL120839137425"); } 
			}

			/// <summary>
			/// Gets column BookingMinuteFrom with alias  
			/// </summary>
			public string ColBookingMinuteFrom { 
				get { return GetColumnName("COL120839137410"); } 
			}

			/// <summary>
			/// Gets column RateDate with alias  
			/// </summary>
			public string ColRateDate { 
				get { return GetColumnName("COL120839137449"); } 
			}

			/// <summary>
			/// Gets column id with alias  
			/// </summary>
			public string Colid { 
				get { return GetColumnName("COL12083913741"); } 
			}

			/// <summary>
			/// Gets column Hour with alias  
			/// </summary>
			public string ColHour { 
				get { return GetColumnName("COL120839137430"); } 
			}

			/// <summary>
			/// Gets column BuildingId with alias  
			/// </summary>
			public string ColBuildingId { 
				get { return GetColumnName("COL12083913743"); } 
			}

			/// <summary>
			/// Gets column ServiceSumUSD with alias  
			/// </summary>
			public string ColServiceSumUSD { 
				get { return GetColumnName("COL120839137443"); } 
			}

			/// <summary>
			/// Gets column LastPriceVND with alias  
			/// </summary>
			public string ColLastPriceVND { 
				get { return GetColumnName("COL120839137429"); } 
			}

			/// <summary>
			/// Gets column HourExtraPriceVND with alias  
			/// </summary>
			public string ColHourExtraPriceVND { 
				get { return GetColumnName("COL120839137417"); } 
			}

			/// <summary>
			/// Gets column BookingHourFrom with alias  
			/// </summary>
			public string ColBookingHourFrom { 
				get { return GetColumnName("COL12083913749"); } 
			}

			/// <summary>
			/// Gets column Status with alias  
			/// </summary>
			public string ColStatus { 
				get { return GetColumnName("COL120839137437"); } 
			}

			/// <summary>
			/// Gets column ServiceLastPriceUSD with alias  
			/// </summary>
			public string ColServiceLastPriceUSD { 
				get { return GetColumnName("COL120839137445"); } 
			}

			/// <summary>
			/// Gets column ModifiedBy with alias  
			/// </summary>
			public string ColModifiedBy { 
				get { return GetColumnName("COL120839137435"); } 
			}

			/// <summary>
			/// Gets column LastPriceUSD with alias  
			/// </summary>
			public string ColLastPriceUSD { 
				get { return GetColumnName("COL120839137428"); } 
			}

			/// <summary>
			/// Gets column RentMinuteTo with alias  
			/// </summary>
			public string ColRentMinuteTo { 
				get { return GetColumnName("COL120839137416"); } 
			}

			/// <summary>
			/// Gets column RentHourFrom with alias  
			/// </summary>
			public string ColRentHourFrom { 
				get { return GetColumnName("COL120839137413"); } 
			}

			/// <summary>
			/// Gets column ServiceSumVND with alias  
			/// </summary>
			public string ColServiceSumVND { 
				get { return GetColumnName("COL120839137444"); } 
			}

			/// <summary>
			/// Gets column CreatedBy with alias  
			/// </summary>
			public string ColCreatedBy { 
				get { return GetColumnName("COL120839137433"); } 
			}

			/// <summary>
			/// Gets column ServiceVatUSD with alias  
			/// </summary>
			public string ColServiceVatUSD { 
				get { return GetColumnName("COL120839137441"); } 
			}

			/// <summary>
			/// Gets column PaidVND with alias  
			/// </summary>
			public string ColPaidVND { 
				get { return GetColumnName("COL120839137452"); } 
			}

			/// <summary>
			/// Gets column VatUSD with alias  
			/// </summary>
			public string ColVatUSD { 
				get { return GetColumnName("COL120839137424"); } 
			}

			/// <summary>
			/// Gets column BookingMinuteTo with alias  
			/// </summary>
			public string ColBookingMinuteTo { 
				get { return GetColumnName("COL120839137412"); } 
			}

			/// <summary>
			/// Gets column ServiceVatVND with alias  
			/// </summary>
			public string ColServiceVatVND { 
				get { return GetColumnName("COL120839137442"); } 
			}

			/// <summary>
			/// Gets column Created with alias  
			/// </summary>
			public string ColCreated { 
				get { return GetColumnName("COL120839137432"); } 
			}

			/// <summary>
			/// Gets column ServiceOtherFee02 with alias  
			/// </summary>
			public string ColServiceOtherFee02 { 
				get { return GetColumnName("COL120839137440"); } 
			}

			/// <summary>
			/// Gets column CustomerId with alias  
			/// </summary>
			public string ColCustomerId { 
				get { return GetColumnName("COL12083913744"); } 
			}

			/// <summary>
			/// Gets column BookingId with alias  
			/// </summary>
			public string ColBookingId { 
				get { return GetColumnName("COL12083913746"); } 
			}

			/// <summary>
			/// Gets column OtherFee01 with alias  
			/// </summary>
			public string ColOtherFee01 { 
				get { return GetColumnName("COL120839137420"); } 
			}

			/// <summary>
			/// Gets column Modified with alias  
			/// </summary>
			public string ColModified { 
				get { return GetColumnName("COL120839137434"); } 
			}

			/// <summary>
			/// Gets column YearMonth with alias  
			/// </summary>
			public string ColYearMonth { 
				get { return GetColumnName("COL12083913742"); } 
			}

			/// <summary>
			/// Gets column ContractDate with alias  
			/// </summary>
			public string ColContractDate { 
				get { return GetColumnName("COL120839137447"); } 
			}

			/// <summary>
			/// Gets column PriceUSD with alias  
			/// </summary>
			public string ColPriceUSD { 
				get { return GetColumnName("COL120839137422"); } 
			}

			/// <summary>
			/// Gets column BookingDate with alias  
			/// </summary>
			public string ColBookingDate { 
				get { return GetColumnName("COL12083913747"); } 
			}

			/// <summary>
			/// Gets column VAT with alias  
			/// </summary>
			public string ColVAT { 
				get { return GetColumnName("COL120839137419"); } 
			}

			/// <summary>
			/// Gets column ServiceOtherFee01 with alias  
			/// </summary>
			public string ColServiceOtherFee01 { 
				get { return GetColumnName("COL120839137439"); } 
			}

			/// <summary>
			/// Gets column BookingType with alias  
			/// </summary>
			public string ColBookingType { 
				get { return GetColumnName("COL12083913748"); } 
			}

			/// <summary>
			/// Gets column SumVND with alias  
			/// </summary>
			public string ColSumVND { 
				get { return GetColumnName("COL120839137427"); } 
			}

			/// <summary>
			/// Gets column Rate with alias  
			/// </summary>
			public string ColRate { 
				get { return GetColumnName("COL120839137448"); } 
			}

			/// <summary>
			/// Gets column ServiceLastPriceVND with alias  
			/// </summary>
			public string ColServiceLastPriceVND { 
				get { return GetColumnName("COL120839137446"); } 
			}

			/// <summary>
			/// Gets column HourExtraPriceUSD with alias  
			/// </summary>
			public string ColHourExtraPriceUSD { 
				get { return GetColumnName("COL120839137418"); } 
			}


			/// <summary>
			/// Checks whether column RentHourTo is added in select statement 
			/// </summary>
			public bool IsSelectRentHourTo { 
				get { return IsSelect("COL120839137415"); } 
				set { SetSelect("COL120839137415", value); } 
			}

			/// <summary>
			/// Checks whether column ServiceVAT is added in select statement 
			/// </summary>
			public bool IsSelectServiceVAT { 
				get { return IsSelect("COL120839137438"); } 
				set { SetSelect("COL120839137438", value); } 
			}

			/// <summary>
			/// Checks whether column SumUSD is added in select statement 
			/// </summary>
			public bool IsSelectSumUSD { 
				get { return IsSelect("COL120839137426"); } 
				set { SetSelect("COL120839137426", value); } 
			}

			/// <summary>
			/// Checks whether column OtherFee02 is added in select statement 
			/// </summary>
			public bool IsSelectOtherFee02 { 
				get { return IsSelect("COL120839137421"); } 
				set { SetSelect("COL120839137421", value); } 
			}

			/// <summary>
			/// Checks whether column PriceVND is added in select statement 
			/// </summary>
			public bool IsSelectPriceVND { 
				get { return IsSelect("COL120839137423"); } 
				set { SetSelect("COL120839137423", value); } 
			}

			/// <summary>
			/// Checks whether column PaidUSD is added in select statement 
			/// </summary>
			public bool IsSelectPaidUSD { 
				get { return IsSelect("COL120839137451"); } 
				set { SetSelect("COL120839137451", value); } 
			}

			/// <summary>
			/// Checks whether column RentMinuteFrom is added in select statement 
			/// </summary>
			public bool IsSelectRentMinuteFrom { 
				get { return IsSelect("COL120839137414"); } 
				set { SetSelect("COL120839137414", value); } 
			}

			/// <summary>
			/// Checks whether column BookingHourTo is added in select statement 
			/// </summary>
			public bool IsSelectBookingHourTo { 
				get { return IsSelect("COL120839137411"); } 
				set { SetSelect("COL120839137411", value); } 
			}

			/// <summary>
			/// Checks whether column Comment is added in select statement 
			/// </summary>
			public bool IsSelectComment { 
				get { return IsSelect("COL120839137431"); } 
				set { SetSelect("COL120839137431", value); } 
			}

			/// <summary>
			/// Checks whether column ContractNo is added in select statement 
			/// </summary>
			public bool IsSelectContractNo { 
				get { return IsSelect("COL120839137450"); } 
				set { SetSelect("COL120839137450", value); } 
			}

			/// <summary>
			/// Checks whether column RoomId is added in select statement 
			/// </summary>
			public bool IsSelectRoomId { 
				get { return IsSelect("COL12083913745"); } 
				set { SetSelect("COL12083913745", value); } 
			}

			/// <summary>
			/// Checks whether column DelFlag is added in select statement 
			/// </summary>
			public bool IsSelectDelFlag { 
				get { return IsSelect("COL120839137436"); } 
				set { SetSelect("COL120839137436", value); } 
			}

			/// <summary>
			/// Checks whether column VatVND is added in select statement 
			/// </summary>
			public bool IsSelectVatVND { 
				get { return IsSelect("COL120839137425"); } 
				set { SetSelect("COL120839137425", value); } 
			}

			/// <summary>
			/// Checks whether column BookingMinuteFrom is added in select statement 
			/// </summary>
			public bool IsSelectBookingMinuteFrom { 
				get { return IsSelect("COL120839137410"); } 
				set { SetSelect("COL120839137410", value); } 
			}

			/// <summary>
			/// Checks whether column RateDate is added in select statement 
			/// </summary>
			public bool IsSelectRateDate { 
				get { return IsSelect("COL120839137449"); } 
				set { SetSelect("COL120839137449", value); } 
			}

			/// <summary>
			/// Checks whether column id is added in select statement 
			/// </summary>
			public bool IsSelectid { 
				get { return IsSelect("COL12083913741"); } 
				set { SetSelect("COL12083913741", value); } 
			}

			/// <summary>
			/// Checks whether column Hour is added in select statement 
			/// </summary>
			public bool IsSelectHour { 
				get { return IsSelect("COL120839137430"); } 
				set { SetSelect("COL120839137430", value); } 
			}

			/// <summary>
			/// Checks whether column BuildingId is added in select statement 
			/// </summary>
			public bool IsSelectBuildingId { 
				get { return IsSelect("COL12083913743"); } 
				set { SetSelect("COL12083913743", value); } 
			}

			/// <summary>
			/// Checks whether column ServiceSumUSD is added in select statement 
			/// </summary>
			public bool IsSelectServiceSumUSD { 
				get { return IsSelect("COL120839137443"); } 
				set { SetSelect("COL120839137443", value); } 
			}

			/// <summary>
			/// Checks whether column LastPriceVND is added in select statement 
			/// </summary>
			public bool IsSelectLastPriceVND { 
				get { return IsSelect("COL120839137429"); } 
				set { SetSelect("COL120839137429", value); } 
			}

			/// <summary>
			/// Checks whether column HourExtraPriceVND is added in select statement 
			/// </summary>
			public bool IsSelectHourExtraPriceVND { 
				get { return IsSelect("COL120839137417"); } 
				set { SetSelect("COL120839137417", value); } 
			}

			/// <summary>
			/// Checks whether column BookingHourFrom is added in select statement 
			/// </summary>
			public bool IsSelectBookingHourFrom { 
				get { return IsSelect("COL12083913749"); } 
				set { SetSelect("COL12083913749", value); } 
			}

			/// <summary>
			/// Checks whether column Status is added in select statement 
			/// </summary>
			public bool IsSelectStatus { 
				get { return IsSelect("COL120839137437"); } 
				set { SetSelect("COL120839137437", value); } 
			}

			/// <summary>
			/// Checks whether column ServiceLastPriceUSD is added in select statement 
			/// </summary>
			public bool IsSelectServiceLastPriceUSD { 
				get { return IsSelect("COL120839137445"); } 
				set { SetSelect("COL120839137445", value); } 
			}

			/// <summary>
			/// Checks whether column ModifiedBy is added in select statement 
			/// </summary>
			public bool IsSelectModifiedBy { 
				get { return IsSelect("COL120839137435"); } 
				set { SetSelect("COL120839137435", value); } 
			}

			/// <summary>
			/// Checks whether column LastPriceUSD is added in select statement 
			/// </summary>
			public bool IsSelectLastPriceUSD { 
				get { return IsSelect("COL120839137428"); } 
				set { SetSelect("COL120839137428", value); } 
			}

			/// <summary>
			/// Checks whether column RentMinuteTo is added in select statement 
			/// </summary>
			public bool IsSelectRentMinuteTo { 
				get { return IsSelect("COL120839137416"); } 
				set { SetSelect("COL120839137416", value); } 
			}

			/// <summary>
			/// Checks whether column RentHourFrom is added in select statement 
			/// </summary>
			public bool IsSelectRentHourFrom { 
				get { return IsSelect("COL120839137413"); } 
				set { SetSelect("COL120839137413", value); } 
			}

			/// <summary>
			/// Checks whether column ServiceSumVND is added in select statement 
			/// </summary>
			public bool IsSelectServiceSumVND { 
				get { return IsSelect("COL120839137444"); } 
				set { SetSelect("COL120839137444", value); } 
			}

			/// <summary>
			/// Checks whether column CreatedBy is added in select statement 
			/// </summary>
			public bool IsSelectCreatedBy { 
				get { return IsSelect("COL120839137433"); } 
				set { SetSelect("COL120839137433", value); } 
			}

			/// <summary>
			/// Checks whether column ServiceVatUSD is added in select statement 
			/// </summary>
			public bool IsSelectServiceVatUSD { 
				get { return IsSelect("COL120839137441"); } 
				set { SetSelect("COL120839137441", value); } 
			}

			/// <summary>
			/// Checks whether column PaidVND is added in select statement 
			/// </summary>
			public bool IsSelectPaidVND { 
				get { return IsSelect("COL120839137452"); } 
				set { SetSelect("COL120839137452", value); } 
			}

			/// <summary>
			/// Checks whether column VatUSD is added in select statement 
			/// </summary>
			public bool IsSelectVatUSD { 
				get { return IsSelect("COL120839137424"); } 
				set { SetSelect("COL120839137424", value); } 
			}

			/// <summary>
			/// Checks whether column BookingMinuteTo is added in select statement 
			/// </summary>
			public bool IsSelectBookingMinuteTo { 
				get { return IsSelect("COL120839137412"); } 
				set { SetSelect("COL120839137412", value); } 
			}

			/// <summary>
			/// Checks whether column ServiceVatVND is added in select statement 
			/// </summary>
			public bool IsSelectServiceVatVND { 
				get { return IsSelect("COL120839137442"); } 
				set { SetSelect("COL120839137442", value); } 
			}

			/// <summary>
			/// Checks whether column Created is added in select statement 
			/// </summary>
			public bool IsSelectCreated { 
				get { return IsSelect("COL120839137432"); } 
				set { SetSelect("COL120839137432", value); } 
			}

			/// <summary>
			/// Checks whether column ServiceOtherFee02 is added in select statement 
			/// </summary>
			public bool IsSelectServiceOtherFee02 { 
				get { return IsSelect("COL120839137440"); } 
				set { SetSelect("COL120839137440", value); } 
			}

			/// <summary>
			/// Checks whether column CustomerId is added in select statement 
			/// </summary>
			public bool IsSelectCustomerId { 
				get { return IsSelect("COL12083913744"); } 
				set { SetSelect("COL12083913744", value); } 
			}

			/// <summary>
			/// Checks whether column BookingId is added in select statement 
			/// </summary>
			public bool IsSelectBookingId { 
				get { return IsSelect("COL12083913746"); } 
				set { SetSelect("COL12083913746", value); } 
			}

			/// <summary>
			/// Checks whether column OtherFee01 is added in select statement 
			/// </summary>
			public bool IsSelectOtherFee01 { 
				get { return IsSelect("COL120839137420"); } 
				set { SetSelect("COL120839137420", value); } 
			}

			/// <summary>
			/// Checks whether column Modified is added in select statement 
			/// </summary>
			public bool IsSelectModified { 
				get { return IsSelect("COL120839137434"); } 
				set { SetSelect("COL120839137434", value); } 
			}

			/// <summary>
			/// Checks whether column YearMonth is added in select statement 
			/// </summary>
			public bool IsSelectYearMonth { 
				get { return IsSelect("COL12083913742"); } 
				set { SetSelect("COL12083913742", value); } 
			}

			/// <summary>
			/// Checks whether column ContractDate is added in select statement 
			/// </summary>
			public bool IsSelectContractDate { 
				get { return IsSelect("COL120839137447"); } 
				set { SetSelect("COL120839137447", value); } 
			}

			/// <summary>
			/// Checks whether column PriceUSD is added in select statement 
			/// </summary>
			public bool IsSelectPriceUSD { 
				get { return IsSelect("COL120839137422"); } 
				set { SetSelect("COL120839137422", value); } 
			}

			/// <summary>
			/// Checks whether column BookingDate is added in select statement 
			/// </summary>
			public bool IsSelectBookingDate { 
				get { return IsSelect("COL12083913747"); } 
				set { SetSelect("COL12083913747", value); } 
			}

			/// <summary>
			/// Checks whether column VAT is added in select statement 
			/// </summary>
			public bool IsSelectVAT { 
				get { return IsSelect("COL120839137419"); } 
				set { SetSelect("COL120839137419", value); } 
			}

			/// <summary>
			/// Checks whether column ServiceOtherFee01 is added in select statement 
			/// </summary>
			public bool IsSelectServiceOtherFee01 { 
				get { return IsSelect("COL120839137439"); } 
				set { SetSelect("COL120839137439", value); } 
			}

			/// <summary>
			/// Checks whether column BookingType is added in select statement 
			/// </summary>
			public bool IsSelectBookingType { 
				get { return IsSelect("COL12083913748"); } 
				set { SetSelect("COL12083913748", value); } 
			}

			/// <summary>
			/// Checks whether column SumVND is added in select statement 
			/// </summary>
			public bool IsSelectSumVND { 
				get { return IsSelect("COL120839137427"); } 
				set { SetSelect("COL120839137427", value); } 
			}

			/// <summary>
			/// Checks whether column Rate is added in select statement 
			/// </summary>
			public bool IsSelectRate { 
				get { return IsSelect("COL120839137448"); } 
				set { SetSelect("COL120839137448", value); } 
			}

			/// <summary>
			/// Checks whether column ServiceLastPriceVND is added in select statement 
			/// </summary>
			public bool IsSelectServiceLastPriceVND { 
				get { return IsSelect("COL120839137446"); } 
				set { SetSelect("COL120839137446", value); } 
			}

			/// <summary>
			/// Checks whether column HourExtraPriceUSD is added in select statement 
			/// </summary>
			public bool IsSelectHourExtraPriceUSD { 
				get { return IsSelect("COL120839137418"); } 
				set { SetSelect("COL120839137418", value); } 
			}



	}
}