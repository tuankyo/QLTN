// ==========================================
//  Author : GNT Data Object Generator Tool
//  Created   : 2014-10-21 16:06:45
//  Copyright GNT INC.  All rights reserved.
// ==========================================
using System;
using System.Collections;
using Gnt.Data.Meta;
using Gnt.Data;

namespace BusinessObjects
{

	[Serializable]
	public class PaymentExtraTimeData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ1803869493";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of PaymentExtraTime 
			/// </summary>
			public PaymentExtraTimeData(string objectID): base(objectID) {}  

			public PaymentExtraTimeData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field Modified 
			/// </summary>
			public string Modified { 
				get { return GetValue("COL180386949339"); } 
				set { SetValue("COL180386949339", value); } 
			}

			/// <summary>
			/// Gets field BuildingId 
			/// </summary>
			public string BuildingId { 
				get { return GetValue("COL18038694933"); } 
				set { SetValue("COL18038694933", value); } 
			}

			/// <summary>
			/// Gets field SumVndArea 
			/// </summary>
			public string SumVndArea { 
				get { return GetValue("COL180386949325"); } 
				set { SetValue("COL180386949325", value); } 
			}

			/// <summary>
			/// Gets field RoomExtraTimeId 
			/// </summary>
			public string RoomExtraTimeId { 
				get { return GetValue("COL18038694936"); } 
				set { SetValue("COL18038694936", value); } 
			}

			/// <summary>
			/// Gets field MinPriceUSD 
			/// </summary>
			public string MinPriceUSD { 
				get { return GetValue("COL180386949344"); } 
				set { SetValue("COL180386949344", value); } 
			}

			/// <summary>
			/// Gets field LastPriceUSD 
			/// </summary>
			public string LastPriceUSD { 
				get { return GetValue("COL180386949318"); } 
				set { SetValue("COL180386949318", value); } 
			}

			/// <summary>
			/// Gets field DelFlag 
			/// </summary>
			public string DelFlag { 
				get { return GetValue("COL180386949341"); } 
				set { SetValue("COL180386949341", value); } 
			}

			/// <summary>
			/// Gets field CreatedBy 
			/// </summary>
			public string CreatedBy { 
				get { return GetValue("COL180386949338"); } 
				set { SetValue("COL180386949338", value); } 
			}

			/// <summary>
			/// Gets field SumVND 
			/// </summary>
			public string SumVND { 
				get { return GetValue("COL180386949317"); } 
				set { SetValue("COL180386949317", value); } 
			}

			/// <summary>
			/// Gets field SumUsdArea 
			/// </summary>
			public string SumUsdArea { 
				get { return GetValue("COL180386949324"); } 
				set { SetValue("COL180386949324", value); } 
			}

			/// <summary>
			/// Gets field ExtraHour 
			/// </summary>
			public string ExtraHour { 
				get { return GetValue("COL18038694938"); } 
				set { SetValue("COL18038694938", value); } 
			}

			/// <summary>
			/// Gets field PriceVndArea 
			/// </summary>
			public string PriceVndArea { 
				get { return GetValue("COL180386949321"); } 
				set { SetValue("COL180386949321", value); } 
			}

			/// <summary>
			/// Gets field SumUSD 
			/// </summary>
			public string SumUSD { 
				get { return GetValue("COL180386949316"); } 
				set { SetValue("COL180386949316", value); } 
			}

			/// <summary>
			/// Gets field CustomerId 
			/// </summary>
			public string CustomerId { 
				get { return GetValue("COL18038694934"); } 
				set { SetValue("COL18038694934", value); } 
			}

			/// <summary>
			/// Gets field WorkingDate 
			/// </summary>
			public string WorkingDate { 
				get { return GetValue("COL18038694937"); } 
				set { SetValue("COL18038694937", value); } 
			}

			/// <summary>
			/// Gets field FromWD 
			/// </summary>
			public string FromWD { 
				get { return GetValue("COL180386949346"); } 
				set { SetValue("COL180386949346", value); } 
			}

			/// <summary>
			/// Gets field PriceVND 
			/// </summary>
			public string PriceVND { 
				get { return GetValue("COL180386949313"); } 
				set { SetValue("COL180386949313", value); } 
			}

			/// <summary>
			/// Gets field YearMonth 
			/// </summary>
			public string YearMonth { 
				get { return GetValue("COL18038694932"); } 
				set { SetValue("COL18038694932", value); } 
			}

			/// <summary>
			/// Gets field Created 
			/// </summary>
			public string Created { 
				get { return GetValue("COL180386949337"); } 
				set { SetValue("COL180386949337", value); } 
			}

			/// <summary>
			/// Gets field SumUsdM2 
			/// </summary>
			public string SumUsdM2 { 
				get { return GetValue("COL180386949332"); } 
				set { SetValue("COL180386949332", value); } 
			}

			/// <summary>
			/// Gets field PriceVndM2 
			/// </summary>
			public string PriceVndM2 { 
				get { return GetValue("COL180386949329"); } 
				set { SetValue("COL180386949329", value); } 
			}

			/// <summary>
			/// Gets field ModifiedBy 
			/// </summary>
			public string ModifiedBy { 
				get { return GetValue("COL180386949340"); } 
				set { SetValue("COL180386949340", value); } 
			}

			/// <summary>
			/// Gets field VatVND 
			/// </summary>
			public string VatVND { 
				get { return GetValue("COL180386949315"); } 
				set { SetValue("COL180386949315", value); } 
			}

			/// <summary>
			/// Gets field LastPriceVndM2 
			/// </summary>
			public string LastPriceVndM2 { 
				get { return GetValue("COL180386949335"); } 
				set { SetValue("COL180386949335", value); } 
			}

			/// <summary>
			/// Gets field EndWD 
			/// </summary>
			public string EndWD { 
				get { return GetValue("COL180386949347"); } 
				set { SetValue("COL180386949347", value); } 
			}

			/// <summary>
			/// Gets field OtherFee02 
			/// </summary>
			public string OtherFee02 { 
				get { return GetValue("COL180386949311"); } 
				set { SetValue("COL180386949311", value); } 
			}

			/// <summary>
			/// Gets field PriceUSD 
			/// </summary>
			public string PriceUSD { 
				get { return GetValue("COL180386949312"); } 
				set { SetValue("COL180386949312", value); } 
			}

			/// <summary>
			/// Gets field PriceUsdM2 
			/// </summary>
			public string PriceUsdM2 { 
				get { return GetValue("COL180386949328"); } 
				set { SetValue("COL180386949328", value); } 
			}

			/// <summary>
			/// Gets field Comment 
			/// </summary>
			public string Comment { 
				get { return GetValue("COL180386949336"); } 
				set { SetValue("COL180386949336", value); } 
			}

			/// <summary>
			/// Gets field id 
			/// </summary>
			public string id { 
				get { return GetValue("COL18038694931"); } 
				set { SetValue("COL18038694931", value); } 
			}

			/// <summary>
			/// Gets field LastPriceVndArea 
			/// </summary>
			public string LastPriceVndArea { 
				get { return GetValue("COL180386949327"); } 
				set { SetValue("COL180386949327", value); } 
			}

			/// <summary>
			/// Gets field PriceUsdArea 
			/// </summary>
			public string PriceUsdArea { 
				get { return GetValue("COL180386949320"); } 
				set { SetValue("COL180386949320", value); } 
			}

			/// <summary>
			/// Gets field LastPriceUsdM2 
			/// </summary>
			public string LastPriceUsdM2 { 
				get { return GetValue("COL180386949334"); } 
				set { SetValue("COL180386949334", value); } 
			}

			/// <summary>
			/// Gets field VAT 
			/// </summary>
			public string VAT { 
				get { return GetValue("COL18038694939"); } 
				set { SetValue("COL18038694939", value); } 
			}

			/// <summary>
			/// Gets field VatVndM2 
			/// </summary>
			public string VatVndM2 { 
				get { return GetValue("COL180386949331"); } 
				set { SetValue("COL180386949331", value); } 
			}

			/// <summary>
			/// Gets field MinPriceVND 
			/// </summary>
			public string MinPriceVND { 
				get { return GetValue("COL180386949343"); } 
				set { SetValue("COL180386949343", value); } 
			}

			/// <summary>
			/// Gets field VatUSD 
			/// </summary>
			public string VatUSD { 
				get { return GetValue("COL180386949314"); } 
				set { SetValue("COL180386949314", value); } 
			}

			/// <summary>
			/// Gets field RoomId 
			/// </summary>
			public string RoomId { 
				get { return GetValue("COL18038694935"); } 
				set { SetValue("COL18038694935", value); } 
			}

			/// <summary>
			/// Gets field LastPriceUsdArea 
			/// </summary>
			public string LastPriceUsdArea { 
				get { return GetValue("COL180386949326"); } 
				set { SetValue("COL180386949326", value); } 
			}

			/// <summary>
			/// Gets field OtherFee01 
			/// </summary>
			public string OtherFee01 { 
				get { return GetValue("COL180386949310"); } 
				set { SetValue("COL180386949310", value); } 
			}

			/// <summary>
			/// Gets field SumVndM2 
			/// </summary>
			public string SumVndM2 { 
				get { return GetValue("COL180386949333"); } 
				set { SetValue("COL180386949333", value); } 
			}

			/// <summary>
			/// Gets field VatUsdM2 
			/// </summary>
			public string VatUsdM2 { 
				get { return GetValue("COL180386949330"); } 
				set { SetValue("COL180386949330", value); } 
			}

			/// <summary>
			/// Gets field RentArea 
			/// </summary>
			public string RentArea { 
				get { return GetValue("COL180386949342"); } 
				set { SetValue("COL180386949342", value); } 
			}

			/// <summary>
			/// Gets field VatVndArea 
			/// </summary>
			public string VatVndArea { 
				get { return GetValue("COL180386949323"); } 
				set { SetValue("COL180386949323", value); } 
			}

			/// <summary>
			/// Gets field VatUsdArea 
			/// </summary>
			public string VatUsdArea { 
				get { return GetValue("COL180386949322"); } 
				set { SetValue("COL180386949322", value); } 
			}

			/// <summary>
			/// Gets field ExtratimeType 
			/// </summary>
			public string ExtratimeType { 
				get { return GetValue("COL180386949345"); } 
				set { SetValue("COL180386949345", value); } 
			}

			/// <summary>
			/// Gets field LastPriceVND 
			/// </summary>
			public string LastPriceVND { 
				get { return GetValue("COL180386949319"); } 
				set { SetValue("COL180386949319", value); } 
			}


			/// <summary>
			/// Gets Modified attribute data 
			/// </summary>
			public AttributeData GetModifiedAttributeData() { 
				return GetAttributeData("COL180386949339"); 
			}

			/// <summary>
			/// Gets BuildingId attribute data 
			/// </summary>
			public AttributeData GetBuildingIdAttributeData() { 
				return GetAttributeData("COL18038694933"); 
			}

			/// <summary>
			/// Gets SumVndArea attribute data 
			/// </summary>
			public AttributeData GetSumVndAreaAttributeData() { 
				return GetAttributeData("COL180386949325"); 
			}

			/// <summary>
			/// Gets RoomExtraTimeId attribute data 
			/// </summary>
			public AttributeData GetRoomExtraTimeIdAttributeData() { 
				return GetAttributeData("COL18038694936"); 
			}

			/// <summary>
			/// Gets MinPriceUSD attribute data 
			/// </summary>
			public AttributeData GetMinPriceUSDAttributeData() { 
				return GetAttributeData("COL180386949344"); 
			}

			/// <summary>
			/// Gets LastPriceUSD attribute data 
			/// </summary>
			public AttributeData GetLastPriceUSDAttributeData() { 
				return GetAttributeData("COL180386949318"); 
			}

			/// <summary>
			/// Gets DelFlag attribute data 
			/// </summary>
			public AttributeData GetDelFlagAttributeData() { 
				return GetAttributeData("COL180386949341"); 
			}

			/// <summary>
			/// Gets CreatedBy attribute data 
			/// </summary>
			public AttributeData GetCreatedByAttributeData() { 
				return GetAttributeData("COL180386949338"); 
			}

			/// <summary>
			/// Gets SumVND attribute data 
			/// </summary>
			public AttributeData GetSumVNDAttributeData() { 
				return GetAttributeData("COL180386949317"); 
			}

			/// <summary>
			/// Gets SumUsdArea attribute data 
			/// </summary>
			public AttributeData GetSumUsdAreaAttributeData() { 
				return GetAttributeData("COL180386949324"); 
			}

			/// <summary>
			/// Gets ExtraHour attribute data 
			/// </summary>
			public AttributeData GetExtraHourAttributeData() { 
				return GetAttributeData("COL18038694938"); 
			}

			/// <summary>
			/// Gets PriceVndArea attribute data 
			/// </summary>
			public AttributeData GetPriceVndAreaAttributeData() { 
				return GetAttributeData("COL180386949321"); 
			}

			/// <summary>
			/// Gets SumUSD attribute data 
			/// </summary>
			public AttributeData GetSumUSDAttributeData() { 
				return GetAttributeData("COL180386949316"); 
			}

			/// <summary>
			/// Gets CustomerId attribute data 
			/// </summary>
			public AttributeData GetCustomerIdAttributeData() { 
				return GetAttributeData("COL18038694934"); 
			}

			/// <summary>
			/// Gets WorkingDate attribute data 
			/// </summary>
			public AttributeData GetWorkingDateAttributeData() { 
				return GetAttributeData("COL18038694937"); 
			}

			/// <summary>
			/// Gets FromWD attribute data 
			/// </summary>
			public AttributeData GetFromWDAttributeData() { 
				return GetAttributeData("COL180386949346"); 
			}

			/// <summary>
			/// Gets PriceVND attribute data 
			/// </summary>
			public AttributeData GetPriceVNDAttributeData() { 
				return GetAttributeData("COL180386949313"); 
			}

			/// <summary>
			/// Gets YearMonth attribute data 
			/// </summary>
			public AttributeData GetYearMonthAttributeData() { 
				return GetAttributeData("COL18038694932"); 
			}

			/// <summary>
			/// Gets Created attribute data 
			/// </summary>
			public AttributeData GetCreatedAttributeData() { 
				return GetAttributeData("COL180386949337"); 
			}

			/// <summary>
			/// Gets SumUsdM2 attribute data 
			/// </summary>
			public AttributeData GetSumUsdM2AttributeData() { 
				return GetAttributeData("COL180386949332"); 
			}

			/// <summary>
			/// Gets PriceVndM2 attribute data 
			/// </summary>
			public AttributeData GetPriceVndM2AttributeData() { 
				return GetAttributeData("COL180386949329"); 
			}

			/// <summary>
			/// Gets ModifiedBy attribute data 
			/// </summary>
			public AttributeData GetModifiedByAttributeData() { 
				return GetAttributeData("COL180386949340"); 
			}

			/// <summary>
			/// Gets VatVND attribute data 
			/// </summary>
			public AttributeData GetVatVNDAttributeData() { 
				return GetAttributeData("COL180386949315"); 
			}

			/// <summary>
			/// Gets LastPriceVndM2 attribute data 
			/// </summary>
			public AttributeData GetLastPriceVndM2AttributeData() { 
				return GetAttributeData("COL180386949335"); 
			}

			/// <summary>
			/// Gets EndWD attribute data 
			/// </summary>
			public AttributeData GetEndWDAttributeData() { 
				return GetAttributeData("COL180386949347"); 
			}

			/// <summary>
			/// Gets OtherFee02 attribute data 
			/// </summary>
			public AttributeData GetOtherFee02AttributeData() { 
				return GetAttributeData("COL180386949311"); 
			}

			/// <summary>
			/// Gets PriceUSD attribute data 
			/// </summary>
			public AttributeData GetPriceUSDAttributeData() { 
				return GetAttributeData("COL180386949312"); 
			}

			/// <summary>
			/// Gets PriceUsdM2 attribute data 
			/// </summary>
			public AttributeData GetPriceUsdM2AttributeData() { 
				return GetAttributeData("COL180386949328"); 
			}

			/// <summary>
			/// Gets Comment attribute data 
			/// </summary>
			public AttributeData GetCommentAttributeData() { 
				return GetAttributeData("COL180386949336"); 
			}

			/// <summary>
			/// Gets id attribute data 
			/// </summary>
			public AttributeData GetidAttributeData() { 
				return GetAttributeData("COL18038694931"); 
			}

			/// <summary>
			/// Gets LastPriceVndArea attribute data 
			/// </summary>
			public AttributeData GetLastPriceVndAreaAttributeData() { 
				return GetAttributeData("COL180386949327"); 
			}

			/// <summary>
			/// Gets PriceUsdArea attribute data 
			/// </summary>
			public AttributeData GetPriceUsdAreaAttributeData() { 
				return GetAttributeData("COL180386949320"); 
			}

			/// <summary>
			/// Gets LastPriceUsdM2 attribute data 
			/// </summary>
			public AttributeData GetLastPriceUsdM2AttributeData() { 
				return GetAttributeData("COL180386949334"); 
			}

			/// <summary>
			/// Gets VAT attribute data 
			/// </summary>
			public AttributeData GetVATAttributeData() { 
				return GetAttributeData("COL18038694939"); 
			}

			/// <summary>
			/// Gets VatVndM2 attribute data 
			/// </summary>
			public AttributeData GetVatVndM2AttributeData() { 
				return GetAttributeData("COL180386949331"); 
			}

			/// <summary>
			/// Gets MinPriceVND attribute data 
			/// </summary>
			public AttributeData GetMinPriceVNDAttributeData() { 
				return GetAttributeData("COL180386949343"); 
			}

			/// <summary>
			/// Gets VatUSD attribute data 
			/// </summary>
			public AttributeData GetVatUSDAttributeData() { 
				return GetAttributeData("COL180386949314"); 
			}

			/// <summary>
			/// Gets RoomId attribute data 
			/// </summary>
			public AttributeData GetRoomIdAttributeData() { 
				return GetAttributeData("COL18038694935"); 
			}

			/// <summary>
			/// Gets LastPriceUsdArea attribute data 
			/// </summary>
			public AttributeData GetLastPriceUsdAreaAttributeData() { 
				return GetAttributeData("COL180386949326"); 
			}

			/// <summary>
			/// Gets OtherFee01 attribute data 
			/// </summary>
			public AttributeData GetOtherFee01AttributeData() { 
				return GetAttributeData("COL180386949310"); 
			}

			/// <summary>
			/// Gets SumVndM2 attribute data 
			/// </summary>
			public AttributeData GetSumVndM2AttributeData() { 
				return GetAttributeData("COL180386949333"); 
			}

			/// <summary>
			/// Gets VatUsdM2 attribute data 
			/// </summary>
			public AttributeData GetVatUsdM2AttributeData() { 
				return GetAttributeData("COL180386949330"); 
			}

			/// <summary>
			/// Gets RentArea attribute data 
			/// </summary>
			public AttributeData GetRentAreaAttributeData() { 
				return GetAttributeData("COL180386949342"); 
			}

			/// <summary>
			/// Gets VatVndArea attribute data 
			/// </summary>
			public AttributeData GetVatVndAreaAttributeData() { 
				return GetAttributeData("COL180386949323"); 
			}

			/// <summary>
			/// Gets VatUsdArea attribute data 
			/// </summary>
			public AttributeData GetVatUsdAreaAttributeData() { 
				return GetAttributeData("COL180386949322"); 
			}

			/// <summary>
			/// Gets ExtratimeType attribute data 
			/// </summary>
			public AttributeData GetExtratimeTypeAttributeData() { 
				return GetAttributeData("COL180386949345"); 
			}

			/// <summary>
			/// Gets LastPriceVND attribute data 
			/// </summary>
			public AttributeData GetLastPriceVNDAttributeData() { 
				return GetAttributeData("COL180386949319"); 
			}


			/// <summary>
			/// Gets column Modified with alias  
			/// </summary>
			public string ColModified { 
				get { return GetColumnName("COL180386949339"); } 
			}

			/// <summary>
			/// Gets column BuildingId with alias  
			/// </summary>
			public string ColBuildingId { 
				get { return GetColumnName("COL18038694933"); } 
			}

			/// <summary>
			/// Gets column SumVndArea with alias  
			/// </summary>
			public string ColSumVndArea { 
				get { return GetColumnName("COL180386949325"); } 
			}

			/// <summary>
			/// Gets column RoomExtraTimeId with alias  
			/// </summary>
			public string ColRoomExtraTimeId { 
				get { return GetColumnName("COL18038694936"); } 
			}

			/// <summary>
			/// Gets column MinPriceUSD with alias  
			/// </summary>
			public string ColMinPriceUSD { 
				get { return GetColumnName("COL180386949344"); } 
			}

			/// <summary>
			/// Gets column LastPriceUSD with alias  
			/// </summary>
			public string ColLastPriceUSD { 
				get { return GetColumnName("COL180386949318"); } 
			}

			/// <summary>
			/// Gets column DelFlag with alias  
			/// </summary>
			public string ColDelFlag { 
				get { return GetColumnName("COL180386949341"); } 
			}

			/// <summary>
			/// Gets column CreatedBy with alias  
			/// </summary>
			public string ColCreatedBy { 
				get { return GetColumnName("COL180386949338"); } 
			}

			/// <summary>
			/// Gets column SumVND with alias  
			/// </summary>
			public string ColSumVND { 
				get { return GetColumnName("COL180386949317"); } 
			}

			/// <summary>
			/// Gets column SumUsdArea with alias  
			/// </summary>
			public string ColSumUsdArea { 
				get { return GetColumnName("COL180386949324"); } 
			}

			/// <summary>
			/// Gets column ExtraHour with alias  
			/// </summary>
			public string ColExtraHour { 
				get { return GetColumnName("COL18038694938"); } 
			}

			/// <summary>
			/// Gets column PriceVndArea with alias  
			/// </summary>
			public string ColPriceVndArea { 
				get { return GetColumnName("COL180386949321"); } 
			}

			/// <summary>
			/// Gets column SumUSD with alias  
			/// </summary>
			public string ColSumUSD { 
				get { return GetColumnName("COL180386949316"); } 
			}

			/// <summary>
			/// Gets column CustomerId with alias  
			/// </summary>
			public string ColCustomerId { 
				get { return GetColumnName("COL18038694934"); } 
			}

			/// <summary>
			/// Gets column WorkingDate with alias  
			/// </summary>
			public string ColWorkingDate { 
				get { return GetColumnName("COL18038694937"); } 
			}

			/// <summary>
			/// Gets column FromWD with alias  
			/// </summary>
			public string ColFromWD { 
				get { return GetColumnName("COL180386949346"); } 
			}

			/// <summary>
			/// Gets column PriceVND with alias  
			/// </summary>
			public string ColPriceVND { 
				get { return GetColumnName("COL180386949313"); } 
			}

			/// <summary>
			/// Gets column YearMonth with alias  
			/// </summary>
			public string ColYearMonth { 
				get { return GetColumnName("COL18038694932"); } 
			}

			/// <summary>
			/// Gets column Created with alias  
			/// </summary>
			public string ColCreated { 
				get { return GetColumnName("COL180386949337"); } 
			}

			/// <summary>
			/// Gets column SumUsdM2 with alias  
			/// </summary>
			public string ColSumUsdM2 { 
				get { return GetColumnName("COL180386949332"); } 
			}

			/// <summary>
			/// Gets column PriceVndM2 with alias  
			/// </summary>
			public string ColPriceVndM2 { 
				get { return GetColumnName("COL180386949329"); } 
			}

			/// <summary>
			/// Gets column ModifiedBy with alias  
			/// </summary>
			public string ColModifiedBy { 
				get { return GetColumnName("COL180386949340"); } 
			}

			/// <summary>
			/// Gets column VatVND with alias  
			/// </summary>
			public string ColVatVND { 
				get { return GetColumnName("COL180386949315"); } 
			}

			/// <summary>
			/// Gets column LastPriceVndM2 with alias  
			/// </summary>
			public string ColLastPriceVndM2 { 
				get { return GetColumnName("COL180386949335"); } 
			}

			/// <summary>
			/// Gets column EndWD with alias  
			/// </summary>
			public string ColEndWD { 
				get { return GetColumnName("COL180386949347"); } 
			}

			/// <summary>
			/// Gets column OtherFee02 with alias  
			/// </summary>
			public string ColOtherFee02 { 
				get { return GetColumnName("COL180386949311"); } 
			}

			/// <summary>
			/// Gets column PriceUSD with alias  
			/// </summary>
			public string ColPriceUSD { 
				get { return GetColumnName("COL180386949312"); } 
			}

			/// <summary>
			/// Gets column PriceUsdM2 with alias  
			/// </summary>
			public string ColPriceUsdM2 { 
				get { return GetColumnName("COL180386949328"); } 
			}

			/// <summary>
			/// Gets column Comment with alias  
			/// </summary>
			public string ColComment { 
				get { return GetColumnName("COL180386949336"); } 
			}

			/// <summary>
			/// Gets column id with alias  
			/// </summary>
			public string Colid { 
				get { return GetColumnName("COL18038694931"); } 
			}

			/// <summary>
			/// Gets column LastPriceVndArea with alias  
			/// </summary>
			public string ColLastPriceVndArea { 
				get { return GetColumnName("COL180386949327"); } 
			}

			/// <summary>
			/// Gets column PriceUsdArea with alias  
			/// </summary>
			public string ColPriceUsdArea { 
				get { return GetColumnName("COL180386949320"); } 
			}

			/// <summary>
			/// Gets column LastPriceUsdM2 with alias  
			/// </summary>
			public string ColLastPriceUsdM2 { 
				get { return GetColumnName("COL180386949334"); } 
			}

			/// <summary>
			/// Gets column VAT with alias  
			/// </summary>
			public string ColVAT { 
				get { return GetColumnName("COL18038694939"); } 
			}

			/// <summary>
			/// Gets column VatVndM2 with alias  
			/// </summary>
			public string ColVatVndM2 { 
				get { return GetColumnName("COL180386949331"); } 
			}

			/// <summary>
			/// Gets column MinPriceVND with alias  
			/// </summary>
			public string ColMinPriceVND { 
				get { return GetColumnName("COL180386949343"); } 
			}

			/// <summary>
			/// Gets column VatUSD with alias  
			/// </summary>
			public string ColVatUSD { 
				get { return GetColumnName("COL180386949314"); } 
			}

			/// <summary>
			/// Gets column RoomId with alias  
			/// </summary>
			public string ColRoomId { 
				get { return GetColumnName("COL18038694935"); } 
			}

			/// <summary>
			/// Gets column LastPriceUsdArea with alias  
			/// </summary>
			public string ColLastPriceUsdArea { 
				get { return GetColumnName("COL180386949326"); } 
			}

			/// <summary>
			/// Gets column OtherFee01 with alias  
			/// </summary>
			public string ColOtherFee01 { 
				get { return GetColumnName("COL180386949310"); } 
			}

			/// <summary>
			/// Gets column SumVndM2 with alias  
			/// </summary>
			public string ColSumVndM2 { 
				get { return GetColumnName("COL180386949333"); } 
			}

			/// <summary>
			/// Gets column VatUsdM2 with alias  
			/// </summary>
			public string ColVatUsdM2 { 
				get { return GetColumnName("COL180386949330"); } 
			}

			/// <summary>
			/// Gets column RentArea with alias  
			/// </summary>
			public string ColRentArea { 
				get { return GetColumnName("COL180386949342"); } 
			}

			/// <summary>
			/// Gets column VatVndArea with alias  
			/// </summary>
			public string ColVatVndArea { 
				get { return GetColumnName("COL180386949323"); } 
			}

			/// <summary>
			/// Gets column VatUsdArea with alias  
			/// </summary>
			public string ColVatUsdArea { 
				get { return GetColumnName("COL180386949322"); } 
			}

			/// <summary>
			/// Gets column ExtratimeType with alias  
			/// </summary>
			public string ColExtratimeType { 
				get { return GetColumnName("COL180386949345"); } 
			}

			/// <summary>
			/// Gets column LastPriceVND with alias  
			/// </summary>
			public string ColLastPriceVND { 
				get { return GetColumnName("COL180386949319"); } 
			}


			/// <summary>
			/// Checks whether column Modified is added in select statement 
			/// </summary>
			public bool IsSelectModified { 
				get { return IsSelect("COL180386949339"); } 
				set { SetSelect("COL180386949339", value); } 
			}

			/// <summary>
			/// Checks whether column BuildingId is added in select statement 
			/// </summary>
			public bool IsSelectBuildingId { 
				get { return IsSelect("COL18038694933"); } 
				set { SetSelect("COL18038694933", value); } 
			}

			/// <summary>
			/// Checks whether column SumVndArea is added in select statement 
			/// </summary>
			public bool IsSelectSumVndArea { 
				get { return IsSelect("COL180386949325"); } 
				set { SetSelect("COL180386949325", value); } 
			}

			/// <summary>
			/// Checks whether column RoomExtraTimeId is added in select statement 
			/// </summary>
			public bool IsSelectRoomExtraTimeId { 
				get { return IsSelect("COL18038694936"); } 
				set { SetSelect("COL18038694936", value); } 
			}

			/// <summary>
			/// Checks whether column MinPriceUSD is added in select statement 
			/// </summary>
			public bool IsSelectMinPriceUSD { 
				get { return IsSelect("COL180386949344"); } 
				set { SetSelect("COL180386949344", value); } 
			}

			/// <summary>
			/// Checks whether column LastPriceUSD is added in select statement 
			/// </summary>
			public bool IsSelectLastPriceUSD { 
				get { return IsSelect("COL180386949318"); } 
				set { SetSelect("COL180386949318", value); } 
			}

			/// <summary>
			/// Checks whether column DelFlag is added in select statement 
			/// </summary>
			public bool IsSelectDelFlag { 
				get { return IsSelect("COL180386949341"); } 
				set { SetSelect("COL180386949341", value); } 
			}

			/// <summary>
			/// Checks whether column CreatedBy is added in select statement 
			/// </summary>
			public bool IsSelectCreatedBy { 
				get { return IsSelect("COL180386949338"); } 
				set { SetSelect("COL180386949338", value); } 
			}

			/// <summary>
			/// Checks whether column SumVND is added in select statement 
			/// </summary>
			public bool IsSelectSumVND { 
				get { return IsSelect("COL180386949317"); } 
				set { SetSelect("COL180386949317", value); } 
			}

			/// <summary>
			/// Checks whether column SumUsdArea is added in select statement 
			/// </summary>
			public bool IsSelectSumUsdArea { 
				get { return IsSelect("COL180386949324"); } 
				set { SetSelect("COL180386949324", value); } 
			}

			/// <summary>
			/// Checks whether column ExtraHour is added in select statement 
			/// </summary>
			public bool IsSelectExtraHour { 
				get { return IsSelect("COL18038694938"); } 
				set { SetSelect("COL18038694938", value); } 
			}

			/// <summary>
			/// Checks whether column PriceVndArea is added in select statement 
			/// </summary>
			public bool IsSelectPriceVndArea { 
				get { return IsSelect("COL180386949321"); } 
				set { SetSelect("COL180386949321", value); } 
			}

			/// <summary>
			/// Checks whether column SumUSD is added in select statement 
			/// </summary>
			public bool IsSelectSumUSD { 
				get { return IsSelect("COL180386949316"); } 
				set { SetSelect("COL180386949316", value); } 
			}

			/// <summary>
			/// Checks whether column CustomerId is added in select statement 
			/// </summary>
			public bool IsSelectCustomerId { 
				get { return IsSelect("COL18038694934"); } 
				set { SetSelect("COL18038694934", value); } 
			}

			/// <summary>
			/// Checks whether column WorkingDate is added in select statement 
			/// </summary>
			public bool IsSelectWorkingDate { 
				get { return IsSelect("COL18038694937"); } 
				set { SetSelect("COL18038694937", value); } 
			}

			/// <summary>
			/// Checks whether column FromWD is added in select statement 
			/// </summary>
			public bool IsSelectFromWD { 
				get { return IsSelect("COL180386949346"); } 
				set { SetSelect("COL180386949346", value); } 
			}

			/// <summary>
			/// Checks whether column PriceVND is added in select statement 
			/// </summary>
			public bool IsSelectPriceVND { 
				get { return IsSelect("COL180386949313"); } 
				set { SetSelect("COL180386949313", value); } 
			}

			/// <summary>
			/// Checks whether column YearMonth is added in select statement 
			/// </summary>
			public bool IsSelectYearMonth { 
				get { return IsSelect("COL18038694932"); } 
				set { SetSelect("COL18038694932", value); } 
			}

			/// <summary>
			/// Checks whether column Created is added in select statement 
			/// </summary>
			public bool IsSelectCreated { 
				get { return IsSelect("COL180386949337"); } 
				set { SetSelect("COL180386949337", value); } 
			}

			/// <summary>
			/// Checks whether column SumUsdM2 is added in select statement 
			/// </summary>
			public bool IsSelectSumUsdM2 { 
				get { return IsSelect("COL180386949332"); } 
				set { SetSelect("COL180386949332", value); } 
			}

			/// <summary>
			/// Checks whether column PriceVndM2 is added in select statement 
			/// </summary>
			public bool IsSelectPriceVndM2 { 
				get { return IsSelect("COL180386949329"); } 
				set { SetSelect("COL180386949329", value); } 
			}

			/// <summary>
			/// Checks whether column ModifiedBy is added in select statement 
			/// </summary>
			public bool IsSelectModifiedBy { 
				get { return IsSelect("COL180386949340"); } 
				set { SetSelect("COL180386949340", value); } 
			}

			/// <summary>
			/// Checks whether column VatVND is added in select statement 
			/// </summary>
			public bool IsSelectVatVND { 
				get { return IsSelect("COL180386949315"); } 
				set { SetSelect("COL180386949315", value); } 
			}

			/// <summary>
			/// Checks whether column LastPriceVndM2 is added in select statement 
			/// </summary>
			public bool IsSelectLastPriceVndM2 { 
				get { return IsSelect("COL180386949335"); } 
				set { SetSelect("COL180386949335", value); } 
			}

			/// <summary>
			/// Checks whether column EndWD is added in select statement 
			/// </summary>
			public bool IsSelectEndWD { 
				get { return IsSelect("COL180386949347"); } 
				set { SetSelect("COL180386949347", value); } 
			}

			/// <summary>
			/// Checks whether column OtherFee02 is added in select statement 
			/// </summary>
			public bool IsSelectOtherFee02 { 
				get { return IsSelect("COL180386949311"); } 
				set { SetSelect("COL180386949311", value); } 
			}

			/// <summary>
			/// Checks whether column PriceUSD is added in select statement 
			/// </summary>
			public bool IsSelectPriceUSD { 
				get { return IsSelect("COL180386949312"); } 
				set { SetSelect("COL180386949312", value); } 
			}

			/// <summary>
			/// Checks whether column PriceUsdM2 is added in select statement 
			/// </summary>
			public bool IsSelectPriceUsdM2 { 
				get { return IsSelect("COL180386949328"); } 
				set { SetSelect("COL180386949328", value); } 
			}

			/// <summary>
			/// Checks whether column Comment is added in select statement 
			/// </summary>
			public bool IsSelectComment { 
				get { return IsSelect("COL180386949336"); } 
				set { SetSelect("COL180386949336", value); } 
			}

			/// <summary>
			/// Checks whether column id is added in select statement 
			/// </summary>
			public bool IsSelectid { 
				get { return IsSelect("COL18038694931"); } 
				set { SetSelect("COL18038694931", value); } 
			}

			/// <summary>
			/// Checks whether column LastPriceVndArea is added in select statement 
			/// </summary>
			public bool IsSelectLastPriceVndArea { 
				get { return IsSelect("COL180386949327"); } 
				set { SetSelect("COL180386949327", value); } 
			}

			/// <summary>
			/// Checks whether column PriceUsdArea is added in select statement 
			/// </summary>
			public bool IsSelectPriceUsdArea { 
				get { return IsSelect("COL180386949320"); } 
				set { SetSelect("COL180386949320", value); } 
			}

			/// <summary>
			/// Checks whether column LastPriceUsdM2 is added in select statement 
			/// </summary>
			public bool IsSelectLastPriceUsdM2 { 
				get { return IsSelect("COL180386949334"); } 
				set { SetSelect("COL180386949334", value); } 
			}

			/// <summary>
			/// Checks whether column VAT is added in select statement 
			/// </summary>
			public bool IsSelectVAT { 
				get { return IsSelect("COL18038694939"); } 
				set { SetSelect("COL18038694939", value); } 
			}

			/// <summary>
			/// Checks whether column VatVndM2 is added in select statement 
			/// </summary>
			public bool IsSelectVatVndM2 { 
				get { return IsSelect("COL180386949331"); } 
				set { SetSelect("COL180386949331", value); } 
			}

			/// <summary>
			/// Checks whether column MinPriceVND is added in select statement 
			/// </summary>
			public bool IsSelectMinPriceVND { 
				get { return IsSelect("COL180386949343"); } 
				set { SetSelect("COL180386949343", value); } 
			}

			/// <summary>
			/// Checks whether column VatUSD is added in select statement 
			/// </summary>
			public bool IsSelectVatUSD { 
				get { return IsSelect("COL180386949314"); } 
				set { SetSelect("COL180386949314", value); } 
			}

			/// <summary>
			/// Checks whether column RoomId is added in select statement 
			/// </summary>
			public bool IsSelectRoomId { 
				get { return IsSelect("COL18038694935"); } 
				set { SetSelect("COL18038694935", value); } 
			}

			/// <summary>
			/// Checks whether column LastPriceUsdArea is added in select statement 
			/// </summary>
			public bool IsSelectLastPriceUsdArea { 
				get { return IsSelect("COL180386949326"); } 
				set { SetSelect("COL180386949326", value); } 
			}

			/// <summary>
			/// Checks whether column OtherFee01 is added in select statement 
			/// </summary>
			public bool IsSelectOtherFee01 { 
				get { return IsSelect("COL180386949310"); } 
				set { SetSelect("COL180386949310", value); } 
			}

			/// <summary>
			/// Checks whether column SumVndM2 is added in select statement 
			/// </summary>
			public bool IsSelectSumVndM2 { 
				get { return IsSelect("COL180386949333"); } 
				set { SetSelect("COL180386949333", value); } 
			}

			/// <summary>
			/// Checks whether column VatUsdM2 is added in select statement 
			/// </summary>
			public bool IsSelectVatUsdM2 { 
				get { return IsSelect("COL180386949330"); } 
				set { SetSelect("COL180386949330", value); } 
			}

			/// <summary>
			/// Checks whether column RentArea is added in select statement 
			/// </summary>
			public bool IsSelectRentArea { 
				get { return IsSelect("COL180386949342"); } 
				set { SetSelect("COL180386949342", value); } 
			}

			/// <summary>
			/// Checks whether column VatVndArea is added in select statement 
			/// </summary>
			public bool IsSelectVatVndArea { 
				get { return IsSelect("COL180386949323"); } 
				set { SetSelect("COL180386949323", value); } 
			}

			/// <summary>
			/// Checks whether column VatUsdArea is added in select statement 
			/// </summary>
			public bool IsSelectVatUsdArea { 
				get { return IsSelect("COL180386949322"); } 
				set { SetSelect("COL180386949322", value); } 
			}

			/// <summary>
			/// Checks whether column ExtratimeType is added in select statement 
			/// </summary>
			public bool IsSelectExtratimeType { 
				get { return IsSelect("COL180386949345"); } 
				set { SetSelect("COL180386949345", value); } 
			}

			/// <summary>
			/// Checks whether column LastPriceVND is added in select statement 
			/// </summary>
			public bool IsSelectLastPriceVND { 
				get { return IsSelect("COL180386949319"); } 
				set { SetSelect("COL180386949319", value); } 
			}



	}
}