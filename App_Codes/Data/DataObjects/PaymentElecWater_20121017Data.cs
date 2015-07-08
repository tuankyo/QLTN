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
	public class PaymentElecWater_20121017Data : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ936390405";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of PaymentElecWater_20121017 
			/// </summary>
			public PaymentElecWater_20121017Data(string objectID): base(objectID) {}  

			public PaymentElecWater_20121017Data() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field OtherFee02 
			/// </summary>
			public string OtherFee02 { 
				get { return GetValue("COL93639040516"); } 
				set { SetValue("COL93639040516", value); } 
			}

			/// <summary>
			/// Gets field YearMonth 
			/// </summary>
			public string YearMonth { 
				get { return GetValue("COL9363904052"); } 
				set { SetValue("COL9363904052", value); } 
			}

			/// <summary>
			/// Gets field LastPriceUSD 
			/// </summary>
			public string LastPriceUSD { 
				get { return GetValue("COL93639040521"); } 
				set { SetValue("COL93639040521", value); } 
			}

			/// <summary>
			/// Gets field OldIndex 
			/// </summary>
			public string OldIndex { 
				get { return GetValue("COL93639040511"); } 
				set { SetValue("COL93639040511", value); } 
			}

			/// <summary>
			/// Gets field SumUSD 
			/// </summary>
			public string SumUSD { 
				get { return GetValue("COL93639040519"); } 
				set { SetValue("COL93639040519", value); } 
			}

			/// <summary>
			/// Gets field DetailType 
			/// </summary>
			public string DetailType { 
				get { return GetValue("COL93639040529"); } 
				set { SetValue("COL93639040529", value); } 
			}

			/// <summary>
			/// Gets field DateFrom 
			/// </summary>
			public string DateFrom { 
				get { return GetValue("COL9363904059"); } 
				set { SetValue("COL9363904059", value); } 
			}

			/// <summary>
			/// Gets field TarrifsOfWaterId 
			/// </summary>
			public string TarrifsOfWaterId { 
				get { return GetValue("COL9363904058"); } 
				set { SetValue("COL9363904058", value); } 
			}

			/// <summary>
			/// Gets field TarrifsOfElecId 
			/// </summary>
			public string TarrifsOfElecId { 
				get { return GetValue("COL9363904057"); } 
				set { SetValue("COL9363904057", value); } 
			}

			/// <summary>
			/// Gets field UsedElecWaterId 
			/// </summary>
			public string UsedElecWaterId { 
				get { return GetValue("COL9363904056"); } 
				set { SetValue("COL9363904056", value); } 
			}

			/// <summary>
			/// Gets field RoomId 
			/// </summary>
			public string RoomId { 
				get { return GetValue("COL9363904055"); } 
				set { SetValue("COL9363904055", value); } 
			}

			/// <summary>
			/// Gets field CustomerId 
			/// </summary>
			public string CustomerId { 
				get { return GetValue("COL9363904054"); } 
				set { SetValue("COL9363904054", value); } 
			}

			/// <summary>
			/// Gets field BuildingId 
			/// </summary>
			public string BuildingId { 
				get { return GetValue("COL9363904053"); } 
				set { SetValue("COL9363904053", value); } 
			}

			/// <summary>
			/// Gets field ModifiedBy 
			/// </summary>
			public string ModifiedBy { 
				get { return GetValue("COL93639040527"); } 
				set { SetValue("COL93639040527", value); } 
			}

			/// <summary>
			/// Gets field VatUSD 
			/// </summary>
			public string VatUSD { 
				get { return GetValue("COL93639040517"); } 
				set { SetValue("COL93639040517", value); } 
			}

			/// <summary>
			/// Gets field Created 
			/// </summary>
			public string Created { 
				get { return GetValue("COL93639040524"); } 
				set { SetValue("COL93639040524", value); } 
			}

			/// <summary>
			/// Gets field VAT 
			/// </summary>
			public string VAT { 
				get { return GetValue("COL93639040514"); } 
				set { SetValue("COL93639040514", value); } 
			}

			/// <summary>
			/// Gets field LastPriceVND 
			/// </summary>
			public string LastPriceVND { 
				get { return GetValue("COL93639040522"); } 
				set { SetValue("COL93639040522", value); } 
			}

			/// <summary>
			/// Gets field NewIndex 
			/// </summary>
			public string NewIndex { 
				get { return GetValue("COL93639040512"); } 
				set { SetValue("COL93639040512", value); } 
			}

			/// <summary>
			/// Gets field CreatedBy 
			/// </summary>
			public string CreatedBy { 
				get { return GetValue("COL93639040525"); } 
				set { SetValue("COL93639040525", value); } 
			}

			/// <summary>
			/// Gets field OtherFee01 
			/// </summary>
			public string OtherFee01 { 
				get { return GetValue("COL93639040515"); } 
				set { SetValue("COL93639040515", value); } 
			}

			/// <summary>
			/// Gets field SumVND 
			/// </summary>
			public string SumVND { 
				get { return GetValue("COL93639040520"); } 
				set { SetValue("COL93639040520", value); } 
			}

			/// <summary>
			/// Gets field DateTo 
			/// </summary>
			public string DateTo { 
				get { return GetValue("COL93639040510"); } 
				set { SetValue("COL93639040510", value); } 
			}

			/// <summary>
			/// Gets field DelFlag 
			/// </summary>
			public string DelFlag { 
				get { return GetValue("COL93639040528"); } 
				set { SetValue("COL93639040528", value); } 
			}

			/// <summary>
			/// Gets field VatVND 
			/// </summary>
			public string VatVND { 
				get { return GetValue("COL93639040518"); } 
				set { SetValue("COL93639040518", value); } 
			}

			/// <summary>
			/// Gets field id 
			/// </summary>
			public string id { 
				get { return GetValue("COL9363904051"); } 
				set { SetValue("COL9363904051", value); } 
			}

			/// <summary>
			/// Gets field Comment 
			/// </summary>
			public string Comment { 
				get { return GetValue("COL93639040523"); } 
				set { SetValue("COL93639040523", value); } 
			}

			/// <summary>
			/// Gets field Mount 
			/// </summary>
			public string Mount { 
				get { return GetValue("COL93639040513"); } 
				set { SetValue("COL93639040513", value); } 
			}

			/// <summary>
			/// Gets field Modified 
			/// </summary>
			public string Modified { 
				get { return GetValue("COL93639040526"); } 
				set { SetValue("COL93639040526", value); } 
			}


			/// <summary>
			/// Gets OtherFee02 attribute data 
			/// </summary>
			public AttributeData GetOtherFee02AttributeData() { 
				return GetAttributeData("COL93639040516"); 
			}

			/// <summary>
			/// Gets YearMonth attribute data 
			/// </summary>
			public AttributeData GetYearMonthAttributeData() { 
				return GetAttributeData("COL9363904052"); 
			}

			/// <summary>
			/// Gets LastPriceUSD attribute data 
			/// </summary>
			public AttributeData GetLastPriceUSDAttributeData() { 
				return GetAttributeData("COL93639040521"); 
			}

			/// <summary>
			/// Gets OldIndex attribute data 
			/// </summary>
			public AttributeData GetOldIndexAttributeData() { 
				return GetAttributeData("COL93639040511"); 
			}

			/// <summary>
			/// Gets SumUSD attribute data 
			/// </summary>
			public AttributeData GetSumUSDAttributeData() { 
				return GetAttributeData("COL93639040519"); 
			}

			/// <summary>
			/// Gets DetailType attribute data 
			/// </summary>
			public AttributeData GetDetailTypeAttributeData() { 
				return GetAttributeData("COL93639040529"); 
			}

			/// <summary>
			/// Gets DateFrom attribute data 
			/// </summary>
			public AttributeData GetDateFromAttributeData() { 
				return GetAttributeData("COL9363904059"); 
			}

			/// <summary>
			/// Gets TarrifsOfWaterId attribute data 
			/// </summary>
			public AttributeData GetTarrifsOfWaterIdAttributeData() { 
				return GetAttributeData("COL9363904058"); 
			}

			/// <summary>
			/// Gets TarrifsOfElecId attribute data 
			/// </summary>
			public AttributeData GetTarrifsOfElecIdAttributeData() { 
				return GetAttributeData("COL9363904057"); 
			}

			/// <summary>
			/// Gets UsedElecWaterId attribute data 
			/// </summary>
			public AttributeData GetUsedElecWaterIdAttributeData() { 
				return GetAttributeData("COL9363904056"); 
			}

			/// <summary>
			/// Gets RoomId attribute data 
			/// </summary>
			public AttributeData GetRoomIdAttributeData() { 
				return GetAttributeData("COL9363904055"); 
			}

			/// <summary>
			/// Gets CustomerId attribute data 
			/// </summary>
			public AttributeData GetCustomerIdAttributeData() { 
				return GetAttributeData("COL9363904054"); 
			}

			/// <summary>
			/// Gets BuildingId attribute data 
			/// </summary>
			public AttributeData GetBuildingIdAttributeData() { 
				return GetAttributeData("COL9363904053"); 
			}

			/// <summary>
			/// Gets ModifiedBy attribute data 
			/// </summary>
			public AttributeData GetModifiedByAttributeData() { 
				return GetAttributeData("COL93639040527"); 
			}

			/// <summary>
			/// Gets VatUSD attribute data 
			/// </summary>
			public AttributeData GetVatUSDAttributeData() { 
				return GetAttributeData("COL93639040517"); 
			}

			/// <summary>
			/// Gets Created attribute data 
			/// </summary>
			public AttributeData GetCreatedAttributeData() { 
				return GetAttributeData("COL93639040524"); 
			}

			/// <summary>
			/// Gets VAT attribute data 
			/// </summary>
			public AttributeData GetVATAttributeData() { 
				return GetAttributeData("COL93639040514"); 
			}

			/// <summary>
			/// Gets LastPriceVND attribute data 
			/// </summary>
			public AttributeData GetLastPriceVNDAttributeData() { 
				return GetAttributeData("COL93639040522"); 
			}

			/// <summary>
			/// Gets NewIndex attribute data 
			/// </summary>
			public AttributeData GetNewIndexAttributeData() { 
				return GetAttributeData("COL93639040512"); 
			}

			/// <summary>
			/// Gets CreatedBy attribute data 
			/// </summary>
			public AttributeData GetCreatedByAttributeData() { 
				return GetAttributeData("COL93639040525"); 
			}

			/// <summary>
			/// Gets OtherFee01 attribute data 
			/// </summary>
			public AttributeData GetOtherFee01AttributeData() { 
				return GetAttributeData("COL93639040515"); 
			}

			/// <summary>
			/// Gets SumVND attribute data 
			/// </summary>
			public AttributeData GetSumVNDAttributeData() { 
				return GetAttributeData("COL93639040520"); 
			}

			/// <summary>
			/// Gets DateTo attribute data 
			/// </summary>
			public AttributeData GetDateToAttributeData() { 
				return GetAttributeData("COL93639040510"); 
			}

			/// <summary>
			/// Gets DelFlag attribute data 
			/// </summary>
			public AttributeData GetDelFlagAttributeData() { 
				return GetAttributeData("COL93639040528"); 
			}

			/// <summary>
			/// Gets VatVND attribute data 
			/// </summary>
			public AttributeData GetVatVNDAttributeData() { 
				return GetAttributeData("COL93639040518"); 
			}

			/// <summary>
			/// Gets id attribute data 
			/// </summary>
			public AttributeData GetidAttributeData() { 
				return GetAttributeData("COL9363904051"); 
			}

			/// <summary>
			/// Gets Comment attribute data 
			/// </summary>
			public AttributeData GetCommentAttributeData() { 
				return GetAttributeData("COL93639040523"); 
			}

			/// <summary>
			/// Gets Mount attribute data 
			/// </summary>
			public AttributeData GetMountAttributeData() { 
				return GetAttributeData("COL93639040513"); 
			}

			/// <summary>
			/// Gets Modified attribute data 
			/// </summary>
			public AttributeData GetModifiedAttributeData() { 
				return GetAttributeData("COL93639040526"); 
			}


			/// <summary>
			/// Gets column OtherFee02 with alias  
			/// </summary>
			public string ColOtherFee02 { 
				get { return GetColumnName("COL93639040516"); } 
			}

			/// <summary>
			/// Gets column YearMonth with alias  
			/// </summary>
			public string ColYearMonth { 
				get { return GetColumnName("COL9363904052"); } 
			}

			/// <summary>
			/// Gets column LastPriceUSD with alias  
			/// </summary>
			public string ColLastPriceUSD { 
				get { return GetColumnName("COL93639040521"); } 
			}

			/// <summary>
			/// Gets column OldIndex with alias  
			/// </summary>
			public string ColOldIndex { 
				get { return GetColumnName("COL93639040511"); } 
			}

			/// <summary>
			/// Gets column SumUSD with alias  
			/// </summary>
			public string ColSumUSD { 
				get { return GetColumnName("COL93639040519"); } 
			}

			/// <summary>
			/// Gets column DetailType with alias  
			/// </summary>
			public string ColDetailType { 
				get { return GetColumnName("COL93639040529"); } 
			}

			/// <summary>
			/// Gets column DateFrom with alias  
			/// </summary>
			public string ColDateFrom { 
				get { return GetColumnName("COL9363904059"); } 
			}

			/// <summary>
			/// Gets column TarrifsOfWaterId with alias  
			/// </summary>
			public string ColTarrifsOfWaterId { 
				get { return GetColumnName("COL9363904058"); } 
			}

			/// <summary>
			/// Gets column TarrifsOfElecId with alias  
			/// </summary>
			public string ColTarrifsOfElecId { 
				get { return GetColumnName("COL9363904057"); } 
			}

			/// <summary>
			/// Gets column UsedElecWaterId with alias  
			/// </summary>
			public string ColUsedElecWaterId { 
				get { return GetColumnName("COL9363904056"); } 
			}

			/// <summary>
			/// Gets column RoomId with alias  
			/// </summary>
			public string ColRoomId { 
				get { return GetColumnName("COL9363904055"); } 
			}

			/// <summary>
			/// Gets column CustomerId with alias  
			/// </summary>
			public string ColCustomerId { 
				get { return GetColumnName("COL9363904054"); } 
			}

			/// <summary>
			/// Gets column BuildingId with alias  
			/// </summary>
			public string ColBuildingId { 
				get { return GetColumnName("COL9363904053"); } 
			}

			/// <summary>
			/// Gets column ModifiedBy with alias  
			/// </summary>
			public string ColModifiedBy { 
				get { return GetColumnName("COL93639040527"); } 
			}

			/// <summary>
			/// Gets column VatUSD with alias  
			/// </summary>
			public string ColVatUSD { 
				get { return GetColumnName("COL93639040517"); } 
			}

			/// <summary>
			/// Gets column Created with alias  
			/// </summary>
			public string ColCreated { 
				get { return GetColumnName("COL93639040524"); } 
			}

			/// <summary>
			/// Gets column VAT with alias  
			/// </summary>
			public string ColVAT { 
				get { return GetColumnName("COL93639040514"); } 
			}

			/// <summary>
			/// Gets column LastPriceVND with alias  
			/// </summary>
			public string ColLastPriceVND { 
				get { return GetColumnName("COL93639040522"); } 
			}

			/// <summary>
			/// Gets column NewIndex with alias  
			/// </summary>
			public string ColNewIndex { 
				get { return GetColumnName("COL93639040512"); } 
			}

			/// <summary>
			/// Gets column CreatedBy with alias  
			/// </summary>
			public string ColCreatedBy { 
				get { return GetColumnName("COL93639040525"); } 
			}

			/// <summary>
			/// Gets column OtherFee01 with alias  
			/// </summary>
			public string ColOtherFee01 { 
				get { return GetColumnName("COL93639040515"); } 
			}

			/// <summary>
			/// Gets column SumVND with alias  
			/// </summary>
			public string ColSumVND { 
				get { return GetColumnName("COL93639040520"); } 
			}

			/// <summary>
			/// Gets column DateTo with alias  
			/// </summary>
			public string ColDateTo { 
				get { return GetColumnName("COL93639040510"); } 
			}

			/// <summary>
			/// Gets column DelFlag with alias  
			/// </summary>
			public string ColDelFlag { 
				get { return GetColumnName("COL93639040528"); } 
			}

			/// <summary>
			/// Gets column VatVND with alias  
			/// </summary>
			public string ColVatVND { 
				get { return GetColumnName("COL93639040518"); } 
			}

			/// <summary>
			/// Gets column id with alias  
			/// </summary>
			public string Colid { 
				get { return GetColumnName("COL9363904051"); } 
			}

			/// <summary>
			/// Gets column Comment with alias  
			/// </summary>
			public string ColComment { 
				get { return GetColumnName("COL93639040523"); } 
			}

			/// <summary>
			/// Gets column Mount with alias  
			/// </summary>
			public string ColMount { 
				get { return GetColumnName("COL93639040513"); } 
			}

			/// <summary>
			/// Gets column Modified with alias  
			/// </summary>
			public string ColModified { 
				get { return GetColumnName("COL93639040526"); } 
			}


			/// <summary>
			/// Checks whether column OtherFee02 is added in select statement 
			/// </summary>
			public bool IsSelectOtherFee02 { 
				get { return IsSelect("COL93639040516"); } 
				set { SetSelect("COL93639040516", value); } 
			}

			/// <summary>
			/// Checks whether column YearMonth is added in select statement 
			/// </summary>
			public bool IsSelectYearMonth { 
				get { return IsSelect("COL9363904052"); } 
				set { SetSelect("COL9363904052", value); } 
			}

			/// <summary>
			/// Checks whether column LastPriceUSD is added in select statement 
			/// </summary>
			public bool IsSelectLastPriceUSD { 
				get { return IsSelect("COL93639040521"); } 
				set { SetSelect("COL93639040521", value); } 
			}

			/// <summary>
			/// Checks whether column OldIndex is added in select statement 
			/// </summary>
			public bool IsSelectOldIndex { 
				get { return IsSelect("COL93639040511"); } 
				set { SetSelect("COL93639040511", value); } 
			}

			/// <summary>
			/// Checks whether column SumUSD is added in select statement 
			/// </summary>
			public bool IsSelectSumUSD { 
				get { return IsSelect("COL93639040519"); } 
				set { SetSelect("COL93639040519", value); } 
			}

			/// <summary>
			/// Checks whether column DetailType is added in select statement 
			/// </summary>
			public bool IsSelectDetailType { 
				get { return IsSelect("COL93639040529"); } 
				set { SetSelect("COL93639040529", value); } 
			}

			/// <summary>
			/// Checks whether column DateFrom is added in select statement 
			/// </summary>
			public bool IsSelectDateFrom { 
				get { return IsSelect("COL9363904059"); } 
				set { SetSelect("COL9363904059", value); } 
			}

			/// <summary>
			/// Checks whether column TarrifsOfWaterId is added in select statement 
			/// </summary>
			public bool IsSelectTarrifsOfWaterId { 
				get { return IsSelect("COL9363904058"); } 
				set { SetSelect("COL9363904058", value); } 
			}

			/// <summary>
			/// Checks whether column TarrifsOfElecId is added in select statement 
			/// </summary>
			public bool IsSelectTarrifsOfElecId { 
				get { return IsSelect("COL9363904057"); } 
				set { SetSelect("COL9363904057", value); } 
			}

			/// <summary>
			/// Checks whether column UsedElecWaterId is added in select statement 
			/// </summary>
			public bool IsSelectUsedElecWaterId { 
				get { return IsSelect("COL9363904056"); } 
				set { SetSelect("COL9363904056", value); } 
			}

			/// <summary>
			/// Checks whether column RoomId is added in select statement 
			/// </summary>
			public bool IsSelectRoomId { 
				get { return IsSelect("COL9363904055"); } 
				set { SetSelect("COL9363904055", value); } 
			}

			/// <summary>
			/// Checks whether column CustomerId is added in select statement 
			/// </summary>
			public bool IsSelectCustomerId { 
				get { return IsSelect("COL9363904054"); } 
				set { SetSelect("COL9363904054", value); } 
			}

			/// <summary>
			/// Checks whether column BuildingId is added in select statement 
			/// </summary>
			public bool IsSelectBuildingId { 
				get { return IsSelect("COL9363904053"); } 
				set { SetSelect("COL9363904053", value); } 
			}

			/// <summary>
			/// Checks whether column ModifiedBy is added in select statement 
			/// </summary>
			public bool IsSelectModifiedBy { 
				get { return IsSelect("COL93639040527"); } 
				set { SetSelect("COL93639040527", value); } 
			}

			/// <summary>
			/// Checks whether column VatUSD is added in select statement 
			/// </summary>
			public bool IsSelectVatUSD { 
				get { return IsSelect("COL93639040517"); } 
				set { SetSelect("COL93639040517", value); } 
			}

			/// <summary>
			/// Checks whether column Created is added in select statement 
			/// </summary>
			public bool IsSelectCreated { 
				get { return IsSelect("COL93639040524"); } 
				set { SetSelect("COL93639040524", value); } 
			}

			/// <summary>
			/// Checks whether column VAT is added in select statement 
			/// </summary>
			public bool IsSelectVAT { 
				get { return IsSelect("COL93639040514"); } 
				set { SetSelect("COL93639040514", value); } 
			}

			/// <summary>
			/// Checks whether column LastPriceVND is added in select statement 
			/// </summary>
			public bool IsSelectLastPriceVND { 
				get { return IsSelect("COL93639040522"); } 
				set { SetSelect("COL93639040522", value); } 
			}

			/// <summary>
			/// Checks whether column NewIndex is added in select statement 
			/// </summary>
			public bool IsSelectNewIndex { 
				get { return IsSelect("COL93639040512"); } 
				set { SetSelect("COL93639040512", value); } 
			}

			/// <summary>
			/// Checks whether column CreatedBy is added in select statement 
			/// </summary>
			public bool IsSelectCreatedBy { 
				get { return IsSelect("COL93639040525"); } 
				set { SetSelect("COL93639040525", value); } 
			}

			/// <summary>
			/// Checks whether column OtherFee01 is added in select statement 
			/// </summary>
			public bool IsSelectOtherFee01 { 
				get { return IsSelect("COL93639040515"); } 
				set { SetSelect("COL93639040515", value); } 
			}

			/// <summary>
			/// Checks whether column SumVND is added in select statement 
			/// </summary>
			public bool IsSelectSumVND { 
				get { return IsSelect("COL93639040520"); } 
				set { SetSelect("COL93639040520", value); } 
			}

			/// <summary>
			/// Checks whether column DateTo is added in select statement 
			/// </summary>
			public bool IsSelectDateTo { 
				get { return IsSelect("COL93639040510"); } 
				set { SetSelect("COL93639040510", value); } 
			}

			/// <summary>
			/// Checks whether column DelFlag is added in select statement 
			/// </summary>
			public bool IsSelectDelFlag { 
				get { return IsSelect("COL93639040528"); } 
				set { SetSelect("COL93639040528", value); } 
			}

			/// <summary>
			/// Checks whether column VatVND is added in select statement 
			/// </summary>
			public bool IsSelectVatVND { 
				get { return IsSelect("COL93639040518"); } 
				set { SetSelect("COL93639040518", value); } 
			}

			/// <summary>
			/// Checks whether column id is added in select statement 
			/// </summary>
			public bool IsSelectid { 
				get { return IsSelect("COL9363904051"); } 
				set { SetSelect("COL9363904051", value); } 
			}

			/// <summary>
			/// Checks whether column Comment is added in select statement 
			/// </summary>
			public bool IsSelectComment { 
				get { return IsSelect("COL93639040523"); } 
				set { SetSelect("COL93639040523", value); } 
			}

			/// <summary>
			/// Checks whether column Mount is added in select statement 
			/// </summary>
			public bool IsSelectMount { 
				get { return IsSelect("COL93639040513"); } 
				set { SetSelect("COL93639040513", value); } 
			}

			/// <summary>
			/// Checks whether column Modified is added in select statement 
			/// </summary>
			public bool IsSelectModified { 
				get { return IsSelect("COL93639040526"); } 
				set { SetSelect("COL93639040526", value); } 
			}



	}
}