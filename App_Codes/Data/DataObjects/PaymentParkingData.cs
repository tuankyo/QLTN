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
	public class PaymentParkingData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ779865845";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of PaymentParking 
			/// </summary>
			public PaymentParkingData(string objectID): base(objectID) {}  

			public PaymentParkingData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field YearMonth 
			/// </summary>
			public string YearMonth { 
				get { return GetValue("COL7798658452"); } 
				set { SetValue("COL7798658452", value); } 
			}

			/// <summary>
			/// Gets field BuildingId 
			/// </summary>
			public string BuildingId { 
				get { return GetValue("COL7798658453"); } 
				set { SetValue("COL7798658453", value); } 
			}

			/// <summary>
			/// Gets field CustomerId 
			/// </summary>
			public string CustomerId { 
				get { return GetValue("COL7798658454"); } 
				set { SetValue("COL7798658454", value); } 
			}

			/// <summary>
			/// Gets field ParkingId 
			/// </summary>
			public string ParkingId { 
				get { return GetValue("COL7798658455"); } 
				set { SetValue("COL7798658455", value); } 
			}

			/// <summary>
			/// Gets field TariffsParkingName 
			/// </summary>
			public string TariffsParkingName { 
				get { return GetValue("COL7798658456"); } 
				set { SetValue("COL7798658456", value); } 
			}

			/// <summary>
			/// Gets field VehicleCode 
			/// </summary>
			public string VehicleCode { 
				get { return GetValue("COL7798658457"); } 
				set { SetValue("COL7798658457", value); } 
			}

			/// <summary>
			/// Gets field OtherFee01 
			/// </summary>
			public string OtherFee01 { 
				get { return GetValue("COL77986584514"); } 
				set { SetValue("COL77986584514", value); } 
			}

			/// <summary>
			/// Gets field Comment 
			/// </summary>
			public string Comment { 
				get { return GetValue("COL77986584524"); } 
				set { SetValue("COL77986584524", value); } 
			}

			/// <summary>
			/// Gets field DelFlag 
			/// </summary>
			public string DelFlag { 
				get { return GetValue("COL77986584529"); } 
				set { SetValue("COL77986584529", value); } 
			}

			/// <summary>
			/// Gets field OwnerName 
			/// </summary>
			public string OwnerName { 
				get { return GetValue("COL7798658459"); } 
				set { SetValue("COL7798658459", value); } 
			}

			/// <summary>
			/// Gets field Modified 
			/// </summary>
			public string Modified { 
				get { return GetValue("COL77986584527"); } 
				set { SetValue("COL77986584527", value); } 
			}

			/// <summary>
			/// Gets field daysparking 
			/// </summary>
			public string daysparking { 
				get { return GetValue("COL77986584531"); } 
				set { SetValue("COL77986584531", value); } 
			}

			/// <summary>
			/// Gets field PriceUSD 
			/// </summary>
			public string PriceUSD { 
				get { return GetValue("COL77986584516"); } 
				set { SetValue("COL77986584516", value); } 
			}

			/// <summary>
			/// Gets field CreatedBy 
			/// </summary>
			public string CreatedBy { 
				get { return GetValue("COL77986584526"); } 
				set { SetValue("COL77986584526", value); } 
			}

			/// <summary>
			/// Gets field VAT 
			/// </summary>
			public string VAT { 
				get { return GetValue("COL77986584513"); } 
				set { SetValue("COL77986584513", value); } 
			}

			/// <summary>
			/// Gets field LastPriceVND 
			/// </summary>
			public string LastPriceVND { 
				get { return GetValue("COL77986584523"); } 
				set { SetValue("COL77986584523", value); } 
			}

			/// <summary>
			/// Gets field MonthPaymentType 
			/// </summary>
			public string MonthPaymentType { 
				get { return GetValue("COL77986584533"); } 
				set { SetValue("COL77986584533", value); } 
			}

			/// <summary>
			/// Gets field VatUSD 
			/// </summary>
			public string VatUSD { 
				get { return GetValue("COL77986584518"); } 
				set { SetValue("COL77986584518", value); } 
			}

			/// <summary>
			/// Gets field ModifiedBy 
			/// </summary>
			public string ModifiedBy { 
				get { return GetValue("COL77986584528"); } 
				set { SetValue("COL77986584528", value); } 
			}

			/// <summary>
			/// Gets field OwnerPhone 
			/// </summary>
			public string OwnerPhone { 
				get { return GetValue("COL77986584510"); } 
				set { SetValue("COL77986584510", value); } 
			}

			/// <summary>
			/// Gets field SumUSD 
			/// </summary>
			public string SumUSD { 
				get { return GetValue("COL77986584520"); } 
				set { SetValue("COL77986584520", value); } 
			}

			/// <summary>
			/// Gets field days 
			/// </summary>
			public string days { 
				get { return GetValue("COL77986584530"); } 
				set { SetValue("COL77986584530", value); } 
			}

			/// <summary>
			/// Gets field ParkingBegin 
			/// </summary>
			public string ParkingBegin { 
				get { return GetValue("COL77986584511"); } 
				set { SetValue("COL77986584511", value); } 
			}

			/// <summary>
			/// Gets field PriceVND 
			/// </summary>
			public string PriceVND { 
				get { return GetValue("COL77986584517"); } 
				set { SetValue("COL77986584517", value); } 
			}

			/// <summary>
			/// Gets field OtherFee02 
			/// </summary>
			public string OtherFee02 { 
				get { return GetValue("COL77986584515"); } 
				set { SetValue("COL77986584515", value); } 
			}

			/// <summary>
			/// Gets field Created 
			/// </summary>
			public string Created { 
				get { return GetValue("COL77986584525"); } 
				set { SetValue("COL77986584525", value); } 
			}

			/// <summary>
			/// Gets field VehicleName 
			/// </summary>
			public string VehicleName { 
				get { return GetValue("COL7798658458"); } 
				set { SetValue("COL7798658458", value); } 
			}

			/// <summary>
			/// Gets field VatVND 
			/// </summary>
			public string VatVND { 
				get { return GetValue("COL77986584519"); } 
				set { SetValue("COL77986584519", value); } 
			}

			/// <summary>
			/// Gets field ParkingEnd 
			/// </summary>
			public string ParkingEnd { 
				get { return GetValue("COL77986584512"); } 
				set { SetValue("COL77986584512", value); } 
			}

			/// <summary>
			/// Gets field LastPriceUSD 
			/// </summary>
			public string LastPriceUSD { 
				get { return GetValue("COL77986584522"); } 
				set { SetValue("COL77986584522", value); } 
			}

			/// <summary>
			/// Gets field DeptYearMonth 
			/// </summary>
			public string DeptYearMonth { 
				get { return GetValue("COL77986584532"); } 
				set { SetValue("COL77986584532", value); } 
			}

			/// <summary>
			/// Gets field SumVND 
			/// </summary>
			public string SumVND { 
				get { return GetValue("COL77986584521"); } 
				set { SetValue("COL77986584521", value); } 
			}

			/// <summary>
			/// Gets field id 
			/// </summary>
			public string id { 
				get { return GetValue("COL7798658451"); } 
				set { SetValue("COL7798658451", value); } 
			}


			/// <summary>
			/// Gets YearMonth attribute data 
			/// </summary>
			public AttributeData GetYearMonthAttributeData() { 
				return GetAttributeData("COL7798658452"); 
			}

			/// <summary>
			/// Gets BuildingId attribute data 
			/// </summary>
			public AttributeData GetBuildingIdAttributeData() { 
				return GetAttributeData("COL7798658453"); 
			}

			/// <summary>
			/// Gets CustomerId attribute data 
			/// </summary>
			public AttributeData GetCustomerIdAttributeData() { 
				return GetAttributeData("COL7798658454"); 
			}

			/// <summary>
			/// Gets ParkingId attribute data 
			/// </summary>
			public AttributeData GetParkingIdAttributeData() { 
				return GetAttributeData("COL7798658455"); 
			}

			/// <summary>
			/// Gets TariffsParkingName attribute data 
			/// </summary>
			public AttributeData GetTariffsParkingNameAttributeData() { 
				return GetAttributeData("COL7798658456"); 
			}

			/// <summary>
			/// Gets VehicleCode attribute data 
			/// </summary>
			public AttributeData GetVehicleCodeAttributeData() { 
				return GetAttributeData("COL7798658457"); 
			}

			/// <summary>
			/// Gets OtherFee01 attribute data 
			/// </summary>
			public AttributeData GetOtherFee01AttributeData() { 
				return GetAttributeData("COL77986584514"); 
			}

			/// <summary>
			/// Gets Comment attribute data 
			/// </summary>
			public AttributeData GetCommentAttributeData() { 
				return GetAttributeData("COL77986584524"); 
			}

			/// <summary>
			/// Gets DelFlag attribute data 
			/// </summary>
			public AttributeData GetDelFlagAttributeData() { 
				return GetAttributeData("COL77986584529"); 
			}

			/// <summary>
			/// Gets OwnerName attribute data 
			/// </summary>
			public AttributeData GetOwnerNameAttributeData() { 
				return GetAttributeData("COL7798658459"); 
			}

			/// <summary>
			/// Gets Modified attribute data 
			/// </summary>
			public AttributeData GetModifiedAttributeData() { 
				return GetAttributeData("COL77986584527"); 
			}

			/// <summary>
			/// Gets daysparking attribute data 
			/// </summary>
			public AttributeData GetdaysparkingAttributeData() { 
				return GetAttributeData("COL77986584531"); 
			}

			/// <summary>
			/// Gets PriceUSD attribute data 
			/// </summary>
			public AttributeData GetPriceUSDAttributeData() { 
				return GetAttributeData("COL77986584516"); 
			}

			/// <summary>
			/// Gets CreatedBy attribute data 
			/// </summary>
			public AttributeData GetCreatedByAttributeData() { 
				return GetAttributeData("COL77986584526"); 
			}

			/// <summary>
			/// Gets VAT attribute data 
			/// </summary>
			public AttributeData GetVATAttributeData() { 
				return GetAttributeData("COL77986584513"); 
			}

			/// <summary>
			/// Gets LastPriceVND attribute data 
			/// </summary>
			public AttributeData GetLastPriceVNDAttributeData() { 
				return GetAttributeData("COL77986584523"); 
			}

			/// <summary>
			/// Gets MonthPaymentType attribute data 
			/// </summary>
			public AttributeData GetMonthPaymentTypeAttributeData() { 
				return GetAttributeData("COL77986584533"); 
			}

			/// <summary>
			/// Gets VatUSD attribute data 
			/// </summary>
			public AttributeData GetVatUSDAttributeData() { 
				return GetAttributeData("COL77986584518"); 
			}

			/// <summary>
			/// Gets ModifiedBy attribute data 
			/// </summary>
			public AttributeData GetModifiedByAttributeData() { 
				return GetAttributeData("COL77986584528"); 
			}

			/// <summary>
			/// Gets OwnerPhone attribute data 
			/// </summary>
			public AttributeData GetOwnerPhoneAttributeData() { 
				return GetAttributeData("COL77986584510"); 
			}

			/// <summary>
			/// Gets SumUSD attribute data 
			/// </summary>
			public AttributeData GetSumUSDAttributeData() { 
				return GetAttributeData("COL77986584520"); 
			}

			/// <summary>
			/// Gets days attribute data 
			/// </summary>
			public AttributeData GetdaysAttributeData() { 
				return GetAttributeData("COL77986584530"); 
			}

			/// <summary>
			/// Gets ParkingBegin attribute data 
			/// </summary>
			public AttributeData GetParkingBeginAttributeData() { 
				return GetAttributeData("COL77986584511"); 
			}

			/// <summary>
			/// Gets PriceVND attribute data 
			/// </summary>
			public AttributeData GetPriceVNDAttributeData() { 
				return GetAttributeData("COL77986584517"); 
			}

			/// <summary>
			/// Gets OtherFee02 attribute data 
			/// </summary>
			public AttributeData GetOtherFee02AttributeData() { 
				return GetAttributeData("COL77986584515"); 
			}

			/// <summary>
			/// Gets Created attribute data 
			/// </summary>
			public AttributeData GetCreatedAttributeData() { 
				return GetAttributeData("COL77986584525"); 
			}

			/// <summary>
			/// Gets VehicleName attribute data 
			/// </summary>
			public AttributeData GetVehicleNameAttributeData() { 
				return GetAttributeData("COL7798658458"); 
			}

			/// <summary>
			/// Gets VatVND attribute data 
			/// </summary>
			public AttributeData GetVatVNDAttributeData() { 
				return GetAttributeData("COL77986584519"); 
			}

			/// <summary>
			/// Gets ParkingEnd attribute data 
			/// </summary>
			public AttributeData GetParkingEndAttributeData() { 
				return GetAttributeData("COL77986584512"); 
			}

			/// <summary>
			/// Gets LastPriceUSD attribute data 
			/// </summary>
			public AttributeData GetLastPriceUSDAttributeData() { 
				return GetAttributeData("COL77986584522"); 
			}

			/// <summary>
			/// Gets DeptYearMonth attribute data 
			/// </summary>
			public AttributeData GetDeptYearMonthAttributeData() { 
				return GetAttributeData("COL77986584532"); 
			}

			/// <summary>
			/// Gets SumVND attribute data 
			/// </summary>
			public AttributeData GetSumVNDAttributeData() { 
				return GetAttributeData("COL77986584521"); 
			}

			/// <summary>
			/// Gets id attribute data 
			/// </summary>
			public AttributeData GetidAttributeData() { 
				return GetAttributeData("COL7798658451"); 
			}


			/// <summary>
			/// Gets column YearMonth with alias  
			/// </summary>
			public string ColYearMonth { 
				get { return GetColumnName("COL7798658452"); } 
			}

			/// <summary>
			/// Gets column BuildingId with alias  
			/// </summary>
			public string ColBuildingId { 
				get { return GetColumnName("COL7798658453"); } 
			}

			/// <summary>
			/// Gets column CustomerId with alias  
			/// </summary>
			public string ColCustomerId { 
				get { return GetColumnName("COL7798658454"); } 
			}

			/// <summary>
			/// Gets column ParkingId with alias  
			/// </summary>
			public string ColParkingId { 
				get { return GetColumnName("COL7798658455"); } 
			}

			/// <summary>
			/// Gets column TariffsParkingName with alias  
			/// </summary>
			public string ColTariffsParkingName { 
				get { return GetColumnName("COL7798658456"); } 
			}

			/// <summary>
			/// Gets column VehicleCode with alias  
			/// </summary>
			public string ColVehicleCode { 
				get { return GetColumnName("COL7798658457"); } 
			}

			/// <summary>
			/// Gets column OtherFee01 with alias  
			/// </summary>
			public string ColOtherFee01 { 
				get { return GetColumnName("COL77986584514"); } 
			}

			/// <summary>
			/// Gets column Comment with alias  
			/// </summary>
			public string ColComment { 
				get { return GetColumnName("COL77986584524"); } 
			}

			/// <summary>
			/// Gets column DelFlag with alias  
			/// </summary>
			public string ColDelFlag { 
				get { return GetColumnName("COL77986584529"); } 
			}

			/// <summary>
			/// Gets column OwnerName with alias  
			/// </summary>
			public string ColOwnerName { 
				get { return GetColumnName("COL7798658459"); } 
			}

			/// <summary>
			/// Gets column Modified with alias  
			/// </summary>
			public string ColModified { 
				get { return GetColumnName("COL77986584527"); } 
			}

			/// <summary>
			/// Gets column daysparking with alias  
			/// </summary>
			public string Coldaysparking { 
				get { return GetColumnName("COL77986584531"); } 
			}

			/// <summary>
			/// Gets column PriceUSD with alias  
			/// </summary>
			public string ColPriceUSD { 
				get { return GetColumnName("COL77986584516"); } 
			}

			/// <summary>
			/// Gets column CreatedBy with alias  
			/// </summary>
			public string ColCreatedBy { 
				get { return GetColumnName("COL77986584526"); } 
			}

			/// <summary>
			/// Gets column VAT with alias  
			/// </summary>
			public string ColVAT { 
				get { return GetColumnName("COL77986584513"); } 
			}

			/// <summary>
			/// Gets column LastPriceVND with alias  
			/// </summary>
			public string ColLastPriceVND { 
				get { return GetColumnName("COL77986584523"); } 
			}

			/// <summary>
			/// Gets column MonthPaymentType with alias  
			/// </summary>
			public string ColMonthPaymentType { 
				get { return GetColumnName("COL77986584533"); } 
			}

			/// <summary>
			/// Gets column VatUSD with alias  
			/// </summary>
			public string ColVatUSD { 
				get { return GetColumnName("COL77986584518"); } 
			}

			/// <summary>
			/// Gets column ModifiedBy with alias  
			/// </summary>
			public string ColModifiedBy { 
				get { return GetColumnName("COL77986584528"); } 
			}

			/// <summary>
			/// Gets column OwnerPhone with alias  
			/// </summary>
			public string ColOwnerPhone { 
				get { return GetColumnName("COL77986584510"); } 
			}

			/// <summary>
			/// Gets column SumUSD with alias  
			/// </summary>
			public string ColSumUSD { 
				get { return GetColumnName("COL77986584520"); } 
			}

			/// <summary>
			/// Gets column days with alias  
			/// </summary>
			public string Coldays { 
				get { return GetColumnName("COL77986584530"); } 
			}

			/// <summary>
			/// Gets column ParkingBegin with alias  
			/// </summary>
			public string ColParkingBegin { 
				get { return GetColumnName("COL77986584511"); } 
			}

			/// <summary>
			/// Gets column PriceVND with alias  
			/// </summary>
			public string ColPriceVND { 
				get { return GetColumnName("COL77986584517"); } 
			}

			/// <summary>
			/// Gets column OtherFee02 with alias  
			/// </summary>
			public string ColOtherFee02 { 
				get { return GetColumnName("COL77986584515"); } 
			}

			/// <summary>
			/// Gets column Created with alias  
			/// </summary>
			public string ColCreated { 
				get { return GetColumnName("COL77986584525"); } 
			}

			/// <summary>
			/// Gets column VehicleName with alias  
			/// </summary>
			public string ColVehicleName { 
				get { return GetColumnName("COL7798658458"); } 
			}

			/// <summary>
			/// Gets column VatVND with alias  
			/// </summary>
			public string ColVatVND { 
				get { return GetColumnName("COL77986584519"); } 
			}

			/// <summary>
			/// Gets column ParkingEnd with alias  
			/// </summary>
			public string ColParkingEnd { 
				get { return GetColumnName("COL77986584512"); } 
			}

			/// <summary>
			/// Gets column LastPriceUSD with alias  
			/// </summary>
			public string ColLastPriceUSD { 
				get { return GetColumnName("COL77986584522"); } 
			}

			/// <summary>
			/// Gets column DeptYearMonth with alias  
			/// </summary>
			public string ColDeptYearMonth { 
				get { return GetColumnName("COL77986584532"); } 
			}

			/// <summary>
			/// Gets column SumVND with alias  
			/// </summary>
			public string ColSumVND { 
				get { return GetColumnName("COL77986584521"); } 
			}

			/// <summary>
			/// Gets column id with alias  
			/// </summary>
			public string Colid { 
				get { return GetColumnName("COL7798658451"); } 
			}


			/// <summary>
			/// Checks whether column YearMonth is added in select statement 
			/// </summary>
			public bool IsSelectYearMonth { 
				get { return IsSelect("COL7798658452"); } 
				set { SetSelect("COL7798658452", value); } 
			}

			/// <summary>
			/// Checks whether column BuildingId is added in select statement 
			/// </summary>
			public bool IsSelectBuildingId { 
				get { return IsSelect("COL7798658453"); } 
				set { SetSelect("COL7798658453", value); } 
			}

			/// <summary>
			/// Checks whether column CustomerId is added in select statement 
			/// </summary>
			public bool IsSelectCustomerId { 
				get { return IsSelect("COL7798658454"); } 
				set { SetSelect("COL7798658454", value); } 
			}

			/// <summary>
			/// Checks whether column ParkingId is added in select statement 
			/// </summary>
			public bool IsSelectParkingId { 
				get { return IsSelect("COL7798658455"); } 
				set { SetSelect("COL7798658455", value); } 
			}

			/// <summary>
			/// Checks whether column TariffsParkingName is added in select statement 
			/// </summary>
			public bool IsSelectTariffsParkingName { 
				get { return IsSelect("COL7798658456"); } 
				set { SetSelect("COL7798658456", value); } 
			}

			/// <summary>
			/// Checks whether column VehicleCode is added in select statement 
			/// </summary>
			public bool IsSelectVehicleCode { 
				get { return IsSelect("COL7798658457"); } 
				set { SetSelect("COL7798658457", value); } 
			}

			/// <summary>
			/// Checks whether column OtherFee01 is added in select statement 
			/// </summary>
			public bool IsSelectOtherFee01 { 
				get { return IsSelect("COL77986584514"); } 
				set { SetSelect("COL77986584514", value); } 
			}

			/// <summary>
			/// Checks whether column Comment is added in select statement 
			/// </summary>
			public bool IsSelectComment { 
				get { return IsSelect("COL77986584524"); } 
				set { SetSelect("COL77986584524", value); } 
			}

			/// <summary>
			/// Checks whether column DelFlag is added in select statement 
			/// </summary>
			public bool IsSelectDelFlag { 
				get { return IsSelect("COL77986584529"); } 
				set { SetSelect("COL77986584529", value); } 
			}

			/// <summary>
			/// Checks whether column OwnerName is added in select statement 
			/// </summary>
			public bool IsSelectOwnerName { 
				get { return IsSelect("COL7798658459"); } 
				set { SetSelect("COL7798658459", value); } 
			}

			/// <summary>
			/// Checks whether column Modified is added in select statement 
			/// </summary>
			public bool IsSelectModified { 
				get { return IsSelect("COL77986584527"); } 
				set { SetSelect("COL77986584527", value); } 
			}

			/// <summary>
			/// Checks whether column daysparking is added in select statement 
			/// </summary>
			public bool IsSelectdaysparking { 
				get { return IsSelect("COL77986584531"); } 
				set { SetSelect("COL77986584531", value); } 
			}

			/// <summary>
			/// Checks whether column PriceUSD is added in select statement 
			/// </summary>
			public bool IsSelectPriceUSD { 
				get { return IsSelect("COL77986584516"); } 
				set { SetSelect("COL77986584516", value); } 
			}

			/// <summary>
			/// Checks whether column CreatedBy is added in select statement 
			/// </summary>
			public bool IsSelectCreatedBy { 
				get { return IsSelect("COL77986584526"); } 
				set { SetSelect("COL77986584526", value); } 
			}

			/// <summary>
			/// Checks whether column VAT is added in select statement 
			/// </summary>
			public bool IsSelectVAT { 
				get { return IsSelect("COL77986584513"); } 
				set { SetSelect("COL77986584513", value); } 
			}

			/// <summary>
			/// Checks whether column LastPriceVND is added in select statement 
			/// </summary>
			public bool IsSelectLastPriceVND { 
				get { return IsSelect("COL77986584523"); } 
				set { SetSelect("COL77986584523", value); } 
			}

			/// <summary>
			/// Checks whether column MonthPaymentType is added in select statement 
			/// </summary>
			public bool IsSelectMonthPaymentType { 
				get { return IsSelect("COL77986584533"); } 
				set { SetSelect("COL77986584533", value); } 
			}

			/// <summary>
			/// Checks whether column VatUSD is added in select statement 
			/// </summary>
			public bool IsSelectVatUSD { 
				get { return IsSelect("COL77986584518"); } 
				set { SetSelect("COL77986584518", value); } 
			}

			/// <summary>
			/// Checks whether column ModifiedBy is added in select statement 
			/// </summary>
			public bool IsSelectModifiedBy { 
				get { return IsSelect("COL77986584528"); } 
				set { SetSelect("COL77986584528", value); } 
			}

			/// <summary>
			/// Checks whether column OwnerPhone is added in select statement 
			/// </summary>
			public bool IsSelectOwnerPhone { 
				get { return IsSelect("COL77986584510"); } 
				set { SetSelect("COL77986584510", value); } 
			}

			/// <summary>
			/// Checks whether column SumUSD is added in select statement 
			/// </summary>
			public bool IsSelectSumUSD { 
				get { return IsSelect("COL77986584520"); } 
				set { SetSelect("COL77986584520", value); } 
			}

			/// <summary>
			/// Checks whether column days is added in select statement 
			/// </summary>
			public bool IsSelectdays { 
				get { return IsSelect("COL77986584530"); } 
				set { SetSelect("COL77986584530", value); } 
			}

			/// <summary>
			/// Checks whether column ParkingBegin is added in select statement 
			/// </summary>
			public bool IsSelectParkingBegin { 
				get { return IsSelect("COL77986584511"); } 
				set { SetSelect("COL77986584511", value); } 
			}

			/// <summary>
			/// Checks whether column PriceVND is added in select statement 
			/// </summary>
			public bool IsSelectPriceVND { 
				get { return IsSelect("COL77986584517"); } 
				set { SetSelect("COL77986584517", value); } 
			}

			/// <summary>
			/// Checks whether column OtherFee02 is added in select statement 
			/// </summary>
			public bool IsSelectOtherFee02 { 
				get { return IsSelect("COL77986584515"); } 
				set { SetSelect("COL77986584515", value); } 
			}

			/// <summary>
			/// Checks whether column Created is added in select statement 
			/// </summary>
			public bool IsSelectCreated { 
				get { return IsSelect("COL77986584525"); } 
				set { SetSelect("COL77986584525", value); } 
			}

			/// <summary>
			/// Checks whether column VehicleName is added in select statement 
			/// </summary>
			public bool IsSelectVehicleName { 
				get { return IsSelect("COL7798658458"); } 
				set { SetSelect("COL7798658458", value); } 
			}

			/// <summary>
			/// Checks whether column VatVND is added in select statement 
			/// </summary>
			public bool IsSelectVatVND { 
				get { return IsSelect("COL77986584519"); } 
				set { SetSelect("COL77986584519", value); } 
			}

			/// <summary>
			/// Checks whether column ParkingEnd is added in select statement 
			/// </summary>
			public bool IsSelectParkingEnd { 
				get { return IsSelect("COL77986584512"); } 
				set { SetSelect("COL77986584512", value); } 
			}

			/// <summary>
			/// Checks whether column LastPriceUSD is added in select statement 
			/// </summary>
			public bool IsSelectLastPriceUSD { 
				get { return IsSelect("COL77986584522"); } 
				set { SetSelect("COL77986584522", value); } 
			}

			/// <summary>
			/// Checks whether column DeptYearMonth is added in select statement 
			/// </summary>
			public bool IsSelectDeptYearMonth { 
				get { return IsSelect("COL77986584532"); } 
				set { SetSelect("COL77986584532", value); } 
			}

			/// <summary>
			/// Checks whether column SumVND is added in select statement 
			/// </summary>
			public bool IsSelectSumVND { 
				get { return IsSelect("COL77986584521"); } 
				set { SetSelect("COL77986584521", value); } 
			}

			/// <summary>
			/// Checks whether column id is added in select statement 
			/// </summary>
			public bool IsSelectid { 
				get { return IsSelect("COL7798658451"); } 
				set { SetSelect("COL7798658451", value); } 
			}



	}
}