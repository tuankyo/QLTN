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
	public class PaymentExtraTimeMonthData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ1835869607";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of PaymentExtraTimeMonth 
			/// </summary>
			public PaymentExtraTimeMonthData(string objectID): base(objectID) {}  

			public PaymentExtraTimeMonthData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field VatVndArea 
			/// </summary>
			public string VatVndArea { 
				get { return GetValue("COL183586960721"); } 
				set { SetValue("COL183586960721", value); } 
			}

			/// <summary>
			/// Gets field Modified 
			/// </summary>
			public string Modified { 
				get { return GetValue("COL183586960737"); } 
				set { SetValue("COL183586960737", value); } 
			}

			/// <summary>
			/// Gets field SumVndArea 
			/// </summary>
			public string SumVndArea { 
				get { return GetValue("COL183586960723"); } 
				set { SetValue("COL183586960723", value); } 
			}

			/// <summary>
			/// Gets field MinPriceVND 
			/// </summary>
			public string MinPriceVND { 
				get { return GetValue("COL183586960741"); } 
				set { SetValue("COL183586960741", value); } 
			}

			/// <summary>
			/// Gets field LastPriceVndM2 
			/// </summary>
			public string LastPriceVndM2 { 
				get { return GetValue("COL183586960733"); } 
				set { SetValue("COL183586960733", value); } 
			}

			/// <summary>
			/// Gets field VatVND 
			/// </summary>
			public string VatVND { 
				get { return GetValue("COL183586960713"); } 
				set { SetValue("COL183586960713", value); } 
			}

			/// <summary>
			/// Gets field VatUsdArea 
			/// </summary>
			public string VatUsdArea { 
				get { return GetValue("COL183586960720"); } 
				set { SetValue("COL183586960720", value); } 
			}

			/// <summary>
			/// Gets field LastPriceVndArea 
			/// </summary>
			public string LastPriceVndArea { 
				get { return GetValue("COL183586960725"); } 
				set { SetValue("COL183586960725", value); } 
			}

			/// <summary>
			/// Gets field DelFlag 
			/// </summary>
			public string DelFlag { 
				get { return GetValue("COL183586960739"); } 
				set { SetValue("COL183586960739", value); } 
			}

			/// <summary>
			/// Gets field OtherFee02 
			/// </summary>
			public string OtherFee02 { 
				get { return GetValue("COL18358696079"); } 
				set { SetValue("COL18358696079", value); } 
			}

			/// <summary>
			/// Gets field RentArea 
			/// </summary>
			public string RentArea { 
				get { return GetValue("COL183586960740"); } 
				set { SetValue("COL183586960740", value); } 
			}

			/// <summary>
			/// Gets field LastPriceUsdM2 
			/// </summary>
			public string LastPriceUsdM2 { 
				get { return GetValue("COL183586960732"); } 
				set { SetValue("COL183586960732", value); } 
			}

			/// <summary>
			/// Gets field EndWD 
			/// </summary>
			public string EndWD { 
				get { return GetValue("COL183586960745"); } 
				set { SetValue("COL183586960745", value); } 
			}

			/// <summary>
			/// Gets field VatUSD 
			/// </summary>
			public string VatUSD { 
				get { return GetValue("COL183586960712"); } 
				set { SetValue("COL183586960712", value); } 
			}

			/// <summary>
			/// Gets field LastPriceUsdArea 
			/// </summary>
			public string LastPriceUsdArea { 
				get { return GetValue("COL183586960724"); } 
				set { SetValue("COL183586960724", value); } 
			}

			/// <summary>
			/// Gets field BuildingId 
			/// </summary>
			public string BuildingId { 
				get { return GetValue("COL18358696073"); } 
				set { SetValue("COL18358696073", value); } 
			}

			/// <summary>
			/// Gets field id 
			/// </summary>
			public string id { 
				get { return GetValue("COL18358696071"); } 
				set { SetValue("COL18358696071", value); } 
			}

			/// <summary>
			/// Gets field VAT 
			/// </summary>
			public string VAT { 
				get { return GetValue("COL18358696077"); } 
				set { SetValue("COL18358696077", value); } 
			}

			/// <summary>
			/// Gets field FromWD 
			/// </summary>
			public string FromWD { 
				get { return GetValue("COL183586960744"); } 
				set { SetValue("COL183586960744", value); } 
			}

			/// <summary>
			/// Gets field CreatedBy 
			/// </summary>
			public string CreatedBy { 
				get { return GetValue("COL183586960736"); } 
				set { SetValue("COL183586960736", value); } 
			}

			/// <summary>
			/// Gets field Created 
			/// </summary>
			public string Created { 
				get { return GetValue("COL183586960735"); } 
				set { SetValue("COL183586960735", value); } 
			}

			/// <summary>
			/// Gets field ModifiedBy 
			/// </summary>
			public string ModifiedBy { 
				get { return GetValue("COL183586960738"); } 
				set { SetValue("COL183586960738", value); } 
			}

			/// <summary>
			/// Gets field PriceVndM2 
			/// </summary>
			public string PriceVndM2 { 
				get { return GetValue("COL183586960727"); } 
				set { SetValue("COL183586960727", value); } 
			}

			/// <summary>
			/// Gets field RoomId 
			/// </summary>
			public string RoomId { 
				get { return GetValue("COL18358696075"); } 
				set { SetValue("COL18358696075", value); } 
			}

			/// <summary>
			/// Gets field PriceVndArea 
			/// </summary>
			public string PriceVndArea { 
				get { return GetValue("COL183586960719"); } 
				set { SetValue("COL183586960719", value); } 
			}

			/// <summary>
			/// Gets field SumVndM2 
			/// </summary>
			public string SumVndM2 { 
				get { return GetValue("COL183586960731"); } 
				set { SetValue("COL183586960731", value); } 
			}

			/// <summary>
			/// Gets field PriceVND 
			/// </summary>
			public string PriceVND { 
				get { return GetValue("COL183586960711"); } 
				set { SetValue("COL183586960711", value); } 
			}

			/// <summary>
			/// Gets field CustomerId 
			/// </summary>
			public string CustomerId { 
				get { return GetValue("COL18358696074"); } 
				set { SetValue("COL18358696074", value); } 
			}

			/// <summary>
			/// Gets field SumUsdM2 
			/// </summary>
			public string SumUsdM2 { 
				get { return GetValue("COL183586960730"); } 
				set { SetValue("COL183586960730", value); } 
			}

			/// <summary>
			/// Gets field PriceUSD 
			/// </summary>
			public string PriceUSD { 
				get { return GetValue("COL183586960710"); } 
				set { SetValue("COL183586960710", value); } 
			}

			/// <summary>
			/// Gets field LastPriceUSD 
			/// </summary>
			public string LastPriceUSD { 
				get { return GetValue("COL183586960716"); } 
				set { SetValue("COL183586960716", value); } 
			}

			/// <summary>
			/// Gets field SumVND 
			/// </summary>
			public string SumVND { 
				get { return GetValue("COL183586960715"); } 
				set { SetValue("COL183586960715", value); } 
			}

			/// <summary>
			/// Gets field ExtratimeType 
			/// </summary>
			public string ExtratimeType { 
				get { return GetValue("COL183586960743"); } 
				set { SetValue("COL183586960743", value); } 
			}

			/// <summary>
			/// Gets field VatVndM2 
			/// </summary>
			public string VatVndM2 { 
				get { return GetValue("COL183586960729"); } 
				set { SetValue("COL183586960729", value); } 
			}

			/// <summary>
			/// Gets field OtherFee01 
			/// </summary>
			public string OtherFee01 { 
				get { return GetValue("COL18358696078"); } 
				set { SetValue("COL18358696078", value); } 
			}

			/// <summary>
			/// Gets field SumUsdArea 
			/// </summary>
			public string SumUsdArea { 
				get { return GetValue("COL183586960722"); } 
				set { SetValue("COL183586960722", value); } 
			}

			/// <summary>
			/// Gets field Comment 
			/// </summary>
			public string Comment { 
				get { return GetValue("COL183586960734"); } 
				set { SetValue("COL183586960734", value); } 
			}

			/// <summary>
			/// Gets field PriceUsdArea 
			/// </summary>
			public string PriceUsdArea { 
				get { return GetValue("COL183586960718"); } 
				set { SetValue("COL183586960718", value); } 
			}

			/// <summary>
			/// Gets field SumUSD 
			/// </summary>
			public string SumUSD { 
				get { return GetValue("COL183586960714"); } 
				set { SetValue("COL183586960714", value); } 
			}

			/// <summary>
			/// Gets field YearMonth 
			/// </summary>
			public string YearMonth { 
				get { return GetValue("COL18358696072"); } 
				set { SetValue("COL18358696072", value); } 
			}

			/// <summary>
			/// Gets field MinPriceUSD 
			/// </summary>
			public string MinPriceUSD { 
				get { return GetValue("COL183586960742"); } 
				set { SetValue("COL183586960742", value); } 
			}

			/// <summary>
			/// Gets field VatUsdM2 
			/// </summary>
			public string VatUsdM2 { 
				get { return GetValue("COL183586960728"); } 
				set { SetValue("COL183586960728", value); } 
			}

			/// <summary>
			/// Gets field ExtraHour 
			/// </summary>
			public string ExtraHour { 
				get { return GetValue("COL18358696076"); } 
				set { SetValue("COL18358696076", value); } 
			}

			/// <summary>
			/// Gets field PriceUsdM2 
			/// </summary>
			public string PriceUsdM2 { 
				get { return GetValue("COL183586960726"); } 
				set { SetValue("COL183586960726", value); } 
			}

			/// <summary>
			/// Gets field LastPriceVND 
			/// </summary>
			public string LastPriceVND { 
				get { return GetValue("COL183586960717"); } 
				set { SetValue("COL183586960717", value); } 
			}


			/// <summary>
			/// Gets VatVndArea attribute data 
			/// </summary>
			public AttributeData GetVatVndAreaAttributeData() { 
				return GetAttributeData("COL183586960721"); 
			}

			/// <summary>
			/// Gets Modified attribute data 
			/// </summary>
			public AttributeData GetModifiedAttributeData() { 
				return GetAttributeData("COL183586960737"); 
			}

			/// <summary>
			/// Gets SumVndArea attribute data 
			/// </summary>
			public AttributeData GetSumVndAreaAttributeData() { 
				return GetAttributeData("COL183586960723"); 
			}

			/// <summary>
			/// Gets MinPriceVND attribute data 
			/// </summary>
			public AttributeData GetMinPriceVNDAttributeData() { 
				return GetAttributeData("COL183586960741"); 
			}

			/// <summary>
			/// Gets LastPriceVndM2 attribute data 
			/// </summary>
			public AttributeData GetLastPriceVndM2AttributeData() { 
				return GetAttributeData("COL183586960733"); 
			}

			/// <summary>
			/// Gets VatVND attribute data 
			/// </summary>
			public AttributeData GetVatVNDAttributeData() { 
				return GetAttributeData("COL183586960713"); 
			}

			/// <summary>
			/// Gets VatUsdArea attribute data 
			/// </summary>
			public AttributeData GetVatUsdAreaAttributeData() { 
				return GetAttributeData("COL183586960720"); 
			}

			/// <summary>
			/// Gets LastPriceVndArea attribute data 
			/// </summary>
			public AttributeData GetLastPriceVndAreaAttributeData() { 
				return GetAttributeData("COL183586960725"); 
			}

			/// <summary>
			/// Gets DelFlag attribute data 
			/// </summary>
			public AttributeData GetDelFlagAttributeData() { 
				return GetAttributeData("COL183586960739"); 
			}

			/// <summary>
			/// Gets OtherFee02 attribute data 
			/// </summary>
			public AttributeData GetOtherFee02AttributeData() { 
				return GetAttributeData("COL18358696079"); 
			}

			/// <summary>
			/// Gets RentArea attribute data 
			/// </summary>
			public AttributeData GetRentAreaAttributeData() { 
				return GetAttributeData("COL183586960740"); 
			}

			/// <summary>
			/// Gets LastPriceUsdM2 attribute data 
			/// </summary>
			public AttributeData GetLastPriceUsdM2AttributeData() { 
				return GetAttributeData("COL183586960732"); 
			}

			/// <summary>
			/// Gets EndWD attribute data 
			/// </summary>
			public AttributeData GetEndWDAttributeData() { 
				return GetAttributeData("COL183586960745"); 
			}

			/// <summary>
			/// Gets VatUSD attribute data 
			/// </summary>
			public AttributeData GetVatUSDAttributeData() { 
				return GetAttributeData("COL183586960712"); 
			}

			/// <summary>
			/// Gets LastPriceUsdArea attribute data 
			/// </summary>
			public AttributeData GetLastPriceUsdAreaAttributeData() { 
				return GetAttributeData("COL183586960724"); 
			}

			/// <summary>
			/// Gets BuildingId attribute data 
			/// </summary>
			public AttributeData GetBuildingIdAttributeData() { 
				return GetAttributeData("COL18358696073"); 
			}

			/// <summary>
			/// Gets id attribute data 
			/// </summary>
			public AttributeData GetidAttributeData() { 
				return GetAttributeData("COL18358696071"); 
			}

			/// <summary>
			/// Gets VAT attribute data 
			/// </summary>
			public AttributeData GetVATAttributeData() { 
				return GetAttributeData("COL18358696077"); 
			}

			/// <summary>
			/// Gets FromWD attribute data 
			/// </summary>
			public AttributeData GetFromWDAttributeData() { 
				return GetAttributeData("COL183586960744"); 
			}

			/// <summary>
			/// Gets CreatedBy attribute data 
			/// </summary>
			public AttributeData GetCreatedByAttributeData() { 
				return GetAttributeData("COL183586960736"); 
			}

			/// <summary>
			/// Gets Created attribute data 
			/// </summary>
			public AttributeData GetCreatedAttributeData() { 
				return GetAttributeData("COL183586960735"); 
			}

			/// <summary>
			/// Gets ModifiedBy attribute data 
			/// </summary>
			public AttributeData GetModifiedByAttributeData() { 
				return GetAttributeData("COL183586960738"); 
			}

			/// <summary>
			/// Gets PriceVndM2 attribute data 
			/// </summary>
			public AttributeData GetPriceVndM2AttributeData() { 
				return GetAttributeData("COL183586960727"); 
			}

			/// <summary>
			/// Gets RoomId attribute data 
			/// </summary>
			public AttributeData GetRoomIdAttributeData() { 
				return GetAttributeData("COL18358696075"); 
			}

			/// <summary>
			/// Gets PriceVndArea attribute data 
			/// </summary>
			public AttributeData GetPriceVndAreaAttributeData() { 
				return GetAttributeData("COL183586960719"); 
			}

			/// <summary>
			/// Gets SumVndM2 attribute data 
			/// </summary>
			public AttributeData GetSumVndM2AttributeData() { 
				return GetAttributeData("COL183586960731"); 
			}

			/// <summary>
			/// Gets PriceVND attribute data 
			/// </summary>
			public AttributeData GetPriceVNDAttributeData() { 
				return GetAttributeData("COL183586960711"); 
			}

			/// <summary>
			/// Gets CustomerId attribute data 
			/// </summary>
			public AttributeData GetCustomerIdAttributeData() { 
				return GetAttributeData("COL18358696074"); 
			}

			/// <summary>
			/// Gets SumUsdM2 attribute data 
			/// </summary>
			public AttributeData GetSumUsdM2AttributeData() { 
				return GetAttributeData("COL183586960730"); 
			}

			/// <summary>
			/// Gets PriceUSD attribute data 
			/// </summary>
			public AttributeData GetPriceUSDAttributeData() { 
				return GetAttributeData("COL183586960710"); 
			}

			/// <summary>
			/// Gets LastPriceUSD attribute data 
			/// </summary>
			public AttributeData GetLastPriceUSDAttributeData() { 
				return GetAttributeData("COL183586960716"); 
			}

			/// <summary>
			/// Gets SumVND attribute data 
			/// </summary>
			public AttributeData GetSumVNDAttributeData() { 
				return GetAttributeData("COL183586960715"); 
			}

			/// <summary>
			/// Gets ExtratimeType attribute data 
			/// </summary>
			public AttributeData GetExtratimeTypeAttributeData() { 
				return GetAttributeData("COL183586960743"); 
			}

			/// <summary>
			/// Gets VatVndM2 attribute data 
			/// </summary>
			public AttributeData GetVatVndM2AttributeData() { 
				return GetAttributeData("COL183586960729"); 
			}

			/// <summary>
			/// Gets OtherFee01 attribute data 
			/// </summary>
			public AttributeData GetOtherFee01AttributeData() { 
				return GetAttributeData("COL18358696078"); 
			}

			/// <summary>
			/// Gets SumUsdArea attribute data 
			/// </summary>
			public AttributeData GetSumUsdAreaAttributeData() { 
				return GetAttributeData("COL183586960722"); 
			}

			/// <summary>
			/// Gets Comment attribute data 
			/// </summary>
			public AttributeData GetCommentAttributeData() { 
				return GetAttributeData("COL183586960734"); 
			}

			/// <summary>
			/// Gets PriceUsdArea attribute data 
			/// </summary>
			public AttributeData GetPriceUsdAreaAttributeData() { 
				return GetAttributeData("COL183586960718"); 
			}

			/// <summary>
			/// Gets SumUSD attribute data 
			/// </summary>
			public AttributeData GetSumUSDAttributeData() { 
				return GetAttributeData("COL183586960714"); 
			}

			/// <summary>
			/// Gets YearMonth attribute data 
			/// </summary>
			public AttributeData GetYearMonthAttributeData() { 
				return GetAttributeData("COL18358696072"); 
			}

			/// <summary>
			/// Gets MinPriceUSD attribute data 
			/// </summary>
			public AttributeData GetMinPriceUSDAttributeData() { 
				return GetAttributeData("COL183586960742"); 
			}

			/// <summary>
			/// Gets VatUsdM2 attribute data 
			/// </summary>
			public AttributeData GetVatUsdM2AttributeData() { 
				return GetAttributeData("COL183586960728"); 
			}

			/// <summary>
			/// Gets ExtraHour attribute data 
			/// </summary>
			public AttributeData GetExtraHourAttributeData() { 
				return GetAttributeData("COL18358696076"); 
			}

			/// <summary>
			/// Gets PriceUsdM2 attribute data 
			/// </summary>
			public AttributeData GetPriceUsdM2AttributeData() { 
				return GetAttributeData("COL183586960726"); 
			}

			/// <summary>
			/// Gets LastPriceVND attribute data 
			/// </summary>
			public AttributeData GetLastPriceVNDAttributeData() { 
				return GetAttributeData("COL183586960717"); 
			}


			/// <summary>
			/// Gets column VatVndArea with alias  
			/// </summary>
			public string ColVatVndArea { 
				get { return GetColumnName("COL183586960721"); } 
			}

			/// <summary>
			/// Gets column Modified with alias  
			/// </summary>
			public string ColModified { 
				get { return GetColumnName("COL183586960737"); } 
			}

			/// <summary>
			/// Gets column SumVndArea with alias  
			/// </summary>
			public string ColSumVndArea { 
				get { return GetColumnName("COL183586960723"); } 
			}

			/// <summary>
			/// Gets column MinPriceVND with alias  
			/// </summary>
			public string ColMinPriceVND { 
				get { return GetColumnName("COL183586960741"); } 
			}

			/// <summary>
			/// Gets column LastPriceVndM2 with alias  
			/// </summary>
			public string ColLastPriceVndM2 { 
				get { return GetColumnName("COL183586960733"); } 
			}

			/// <summary>
			/// Gets column VatVND with alias  
			/// </summary>
			public string ColVatVND { 
				get { return GetColumnName("COL183586960713"); } 
			}

			/// <summary>
			/// Gets column VatUsdArea with alias  
			/// </summary>
			public string ColVatUsdArea { 
				get { return GetColumnName("COL183586960720"); } 
			}

			/// <summary>
			/// Gets column LastPriceVndArea with alias  
			/// </summary>
			public string ColLastPriceVndArea { 
				get { return GetColumnName("COL183586960725"); } 
			}

			/// <summary>
			/// Gets column DelFlag with alias  
			/// </summary>
			public string ColDelFlag { 
				get { return GetColumnName("COL183586960739"); } 
			}

			/// <summary>
			/// Gets column OtherFee02 with alias  
			/// </summary>
			public string ColOtherFee02 { 
				get { return GetColumnName("COL18358696079"); } 
			}

			/// <summary>
			/// Gets column RentArea with alias  
			/// </summary>
			public string ColRentArea { 
				get { return GetColumnName("COL183586960740"); } 
			}

			/// <summary>
			/// Gets column LastPriceUsdM2 with alias  
			/// </summary>
			public string ColLastPriceUsdM2 { 
				get { return GetColumnName("COL183586960732"); } 
			}

			/// <summary>
			/// Gets column EndWD with alias  
			/// </summary>
			public string ColEndWD { 
				get { return GetColumnName("COL183586960745"); } 
			}

			/// <summary>
			/// Gets column VatUSD with alias  
			/// </summary>
			public string ColVatUSD { 
				get { return GetColumnName("COL183586960712"); } 
			}

			/// <summary>
			/// Gets column LastPriceUsdArea with alias  
			/// </summary>
			public string ColLastPriceUsdArea { 
				get { return GetColumnName("COL183586960724"); } 
			}

			/// <summary>
			/// Gets column BuildingId with alias  
			/// </summary>
			public string ColBuildingId { 
				get { return GetColumnName("COL18358696073"); } 
			}

			/// <summary>
			/// Gets column id with alias  
			/// </summary>
			public string Colid { 
				get { return GetColumnName("COL18358696071"); } 
			}

			/// <summary>
			/// Gets column VAT with alias  
			/// </summary>
			public string ColVAT { 
				get { return GetColumnName("COL18358696077"); } 
			}

			/// <summary>
			/// Gets column FromWD with alias  
			/// </summary>
			public string ColFromWD { 
				get { return GetColumnName("COL183586960744"); } 
			}

			/// <summary>
			/// Gets column CreatedBy with alias  
			/// </summary>
			public string ColCreatedBy { 
				get { return GetColumnName("COL183586960736"); } 
			}

			/// <summary>
			/// Gets column Created with alias  
			/// </summary>
			public string ColCreated { 
				get { return GetColumnName("COL183586960735"); } 
			}

			/// <summary>
			/// Gets column ModifiedBy with alias  
			/// </summary>
			public string ColModifiedBy { 
				get { return GetColumnName("COL183586960738"); } 
			}

			/// <summary>
			/// Gets column PriceVndM2 with alias  
			/// </summary>
			public string ColPriceVndM2 { 
				get { return GetColumnName("COL183586960727"); } 
			}

			/// <summary>
			/// Gets column RoomId with alias  
			/// </summary>
			public string ColRoomId { 
				get { return GetColumnName("COL18358696075"); } 
			}

			/// <summary>
			/// Gets column PriceVndArea with alias  
			/// </summary>
			public string ColPriceVndArea { 
				get { return GetColumnName("COL183586960719"); } 
			}

			/// <summary>
			/// Gets column SumVndM2 with alias  
			/// </summary>
			public string ColSumVndM2 { 
				get { return GetColumnName("COL183586960731"); } 
			}

			/// <summary>
			/// Gets column PriceVND with alias  
			/// </summary>
			public string ColPriceVND { 
				get { return GetColumnName("COL183586960711"); } 
			}

			/// <summary>
			/// Gets column CustomerId with alias  
			/// </summary>
			public string ColCustomerId { 
				get { return GetColumnName("COL18358696074"); } 
			}

			/// <summary>
			/// Gets column SumUsdM2 with alias  
			/// </summary>
			public string ColSumUsdM2 { 
				get { return GetColumnName("COL183586960730"); } 
			}

			/// <summary>
			/// Gets column PriceUSD with alias  
			/// </summary>
			public string ColPriceUSD { 
				get { return GetColumnName("COL183586960710"); } 
			}

			/// <summary>
			/// Gets column LastPriceUSD with alias  
			/// </summary>
			public string ColLastPriceUSD { 
				get { return GetColumnName("COL183586960716"); } 
			}

			/// <summary>
			/// Gets column SumVND with alias  
			/// </summary>
			public string ColSumVND { 
				get { return GetColumnName("COL183586960715"); } 
			}

			/// <summary>
			/// Gets column ExtratimeType with alias  
			/// </summary>
			public string ColExtratimeType { 
				get { return GetColumnName("COL183586960743"); } 
			}

			/// <summary>
			/// Gets column VatVndM2 with alias  
			/// </summary>
			public string ColVatVndM2 { 
				get { return GetColumnName("COL183586960729"); } 
			}

			/// <summary>
			/// Gets column OtherFee01 with alias  
			/// </summary>
			public string ColOtherFee01 { 
				get { return GetColumnName("COL18358696078"); } 
			}

			/// <summary>
			/// Gets column SumUsdArea with alias  
			/// </summary>
			public string ColSumUsdArea { 
				get { return GetColumnName("COL183586960722"); } 
			}

			/// <summary>
			/// Gets column Comment with alias  
			/// </summary>
			public string ColComment { 
				get { return GetColumnName("COL183586960734"); } 
			}

			/// <summary>
			/// Gets column PriceUsdArea with alias  
			/// </summary>
			public string ColPriceUsdArea { 
				get { return GetColumnName("COL183586960718"); } 
			}

			/// <summary>
			/// Gets column SumUSD with alias  
			/// </summary>
			public string ColSumUSD { 
				get { return GetColumnName("COL183586960714"); } 
			}

			/// <summary>
			/// Gets column YearMonth with alias  
			/// </summary>
			public string ColYearMonth { 
				get { return GetColumnName("COL18358696072"); } 
			}

			/// <summary>
			/// Gets column MinPriceUSD with alias  
			/// </summary>
			public string ColMinPriceUSD { 
				get { return GetColumnName("COL183586960742"); } 
			}

			/// <summary>
			/// Gets column VatUsdM2 with alias  
			/// </summary>
			public string ColVatUsdM2 { 
				get { return GetColumnName("COL183586960728"); } 
			}

			/// <summary>
			/// Gets column ExtraHour with alias  
			/// </summary>
			public string ColExtraHour { 
				get { return GetColumnName("COL18358696076"); } 
			}

			/// <summary>
			/// Gets column PriceUsdM2 with alias  
			/// </summary>
			public string ColPriceUsdM2 { 
				get { return GetColumnName("COL183586960726"); } 
			}

			/// <summary>
			/// Gets column LastPriceVND with alias  
			/// </summary>
			public string ColLastPriceVND { 
				get { return GetColumnName("COL183586960717"); } 
			}


			/// <summary>
			/// Checks whether column VatVndArea is added in select statement 
			/// </summary>
			public bool IsSelectVatVndArea { 
				get { return IsSelect("COL183586960721"); } 
				set { SetSelect("COL183586960721", value); } 
			}

			/// <summary>
			/// Checks whether column Modified is added in select statement 
			/// </summary>
			public bool IsSelectModified { 
				get { return IsSelect("COL183586960737"); } 
				set { SetSelect("COL183586960737", value); } 
			}

			/// <summary>
			/// Checks whether column SumVndArea is added in select statement 
			/// </summary>
			public bool IsSelectSumVndArea { 
				get { return IsSelect("COL183586960723"); } 
				set { SetSelect("COL183586960723", value); } 
			}

			/// <summary>
			/// Checks whether column MinPriceVND is added in select statement 
			/// </summary>
			public bool IsSelectMinPriceVND { 
				get { return IsSelect("COL183586960741"); } 
				set { SetSelect("COL183586960741", value); } 
			}

			/// <summary>
			/// Checks whether column LastPriceVndM2 is added in select statement 
			/// </summary>
			public bool IsSelectLastPriceVndM2 { 
				get { return IsSelect("COL183586960733"); } 
				set { SetSelect("COL183586960733", value); } 
			}

			/// <summary>
			/// Checks whether column VatVND is added in select statement 
			/// </summary>
			public bool IsSelectVatVND { 
				get { return IsSelect("COL183586960713"); } 
				set { SetSelect("COL183586960713", value); } 
			}

			/// <summary>
			/// Checks whether column VatUsdArea is added in select statement 
			/// </summary>
			public bool IsSelectVatUsdArea { 
				get { return IsSelect("COL183586960720"); } 
				set { SetSelect("COL183586960720", value); } 
			}

			/// <summary>
			/// Checks whether column LastPriceVndArea is added in select statement 
			/// </summary>
			public bool IsSelectLastPriceVndArea { 
				get { return IsSelect("COL183586960725"); } 
				set { SetSelect("COL183586960725", value); } 
			}

			/// <summary>
			/// Checks whether column DelFlag is added in select statement 
			/// </summary>
			public bool IsSelectDelFlag { 
				get { return IsSelect("COL183586960739"); } 
				set { SetSelect("COL183586960739", value); } 
			}

			/// <summary>
			/// Checks whether column OtherFee02 is added in select statement 
			/// </summary>
			public bool IsSelectOtherFee02 { 
				get { return IsSelect("COL18358696079"); } 
				set { SetSelect("COL18358696079", value); } 
			}

			/// <summary>
			/// Checks whether column RentArea is added in select statement 
			/// </summary>
			public bool IsSelectRentArea { 
				get { return IsSelect("COL183586960740"); } 
				set { SetSelect("COL183586960740", value); } 
			}

			/// <summary>
			/// Checks whether column LastPriceUsdM2 is added in select statement 
			/// </summary>
			public bool IsSelectLastPriceUsdM2 { 
				get { return IsSelect("COL183586960732"); } 
				set { SetSelect("COL183586960732", value); } 
			}

			/// <summary>
			/// Checks whether column EndWD is added in select statement 
			/// </summary>
			public bool IsSelectEndWD { 
				get { return IsSelect("COL183586960745"); } 
				set { SetSelect("COL183586960745", value); } 
			}

			/// <summary>
			/// Checks whether column VatUSD is added in select statement 
			/// </summary>
			public bool IsSelectVatUSD { 
				get { return IsSelect("COL183586960712"); } 
				set { SetSelect("COL183586960712", value); } 
			}

			/// <summary>
			/// Checks whether column LastPriceUsdArea is added in select statement 
			/// </summary>
			public bool IsSelectLastPriceUsdArea { 
				get { return IsSelect("COL183586960724"); } 
				set { SetSelect("COL183586960724", value); } 
			}

			/// <summary>
			/// Checks whether column BuildingId is added in select statement 
			/// </summary>
			public bool IsSelectBuildingId { 
				get { return IsSelect("COL18358696073"); } 
				set { SetSelect("COL18358696073", value); } 
			}

			/// <summary>
			/// Checks whether column id is added in select statement 
			/// </summary>
			public bool IsSelectid { 
				get { return IsSelect("COL18358696071"); } 
				set { SetSelect("COL18358696071", value); } 
			}

			/// <summary>
			/// Checks whether column VAT is added in select statement 
			/// </summary>
			public bool IsSelectVAT { 
				get { return IsSelect("COL18358696077"); } 
				set { SetSelect("COL18358696077", value); } 
			}

			/// <summary>
			/// Checks whether column FromWD is added in select statement 
			/// </summary>
			public bool IsSelectFromWD { 
				get { return IsSelect("COL183586960744"); } 
				set { SetSelect("COL183586960744", value); } 
			}

			/// <summary>
			/// Checks whether column CreatedBy is added in select statement 
			/// </summary>
			public bool IsSelectCreatedBy { 
				get { return IsSelect("COL183586960736"); } 
				set { SetSelect("COL183586960736", value); } 
			}

			/// <summary>
			/// Checks whether column Created is added in select statement 
			/// </summary>
			public bool IsSelectCreated { 
				get { return IsSelect("COL183586960735"); } 
				set { SetSelect("COL183586960735", value); } 
			}

			/// <summary>
			/// Checks whether column ModifiedBy is added in select statement 
			/// </summary>
			public bool IsSelectModifiedBy { 
				get { return IsSelect("COL183586960738"); } 
				set { SetSelect("COL183586960738", value); } 
			}

			/// <summary>
			/// Checks whether column PriceVndM2 is added in select statement 
			/// </summary>
			public bool IsSelectPriceVndM2 { 
				get { return IsSelect("COL183586960727"); } 
				set { SetSelect("COL183586960727", value); } 
			}

			/// <summary>
			/// Checks whether column RoomId is added in select statement 
			/// </summary>
			public bool IsSelectRoomId { 
				get { return IsSelect("COL18358696075"); } 
				set { SetSelect("COL18358696075", value); } 
			}

			/// <summary>
			/// Checks whether column PriceVndArea is added in select statement 
			/// </summary>
			public bool IsSelectPriceVndArea { 
				get { return IsSelect("COL183586960719"); } 
				set { SetSelect("COL183586960719", value); } 
			}

			/// <summary>
			/// Checks whether column SumVndM2 is added in select statement 
			/// </summary>
			public bool IsSelectSumVndM2 { 
				get { return IsSelect("COL183586960731"); } 
				set { SetSelect("COL183586960731", value); } 
			}

			/// <summary>
			/// Checks whether column PriceVND is added in select statement 
			/// </summary>
			public bool IsSelectPriceVND { 
				get { return IsSelect("COL183586960711"); } 
				set { SetSelect("COL183586960711", value); } 
			}

			/// <summary>
			/// Checks whether column CustomerId is added in select statement 
			/// </summary>
			public bool IsSelectCustomerId { 
				get { return IsSelect("COL18358696074"); } 
				set { SetSelect("COL18358696074", value); } 
			}

			/// <summary>
			/// Checks whether column SumUsdM2 is added in select statement 
			/// </summary>
			public bool IsSelectSumUsdM2 { 
				get { return IsSelect("COL183586960730"); } 
				set { SetSelect("COL183586960730", value); } 
			}

			/// <summary>
			/// Checks whether column PriceUSD is added in select statement 
			/// </summary>
			public bool IsSelectPriceUSD { 
				get { return IsSelect("COL183586960710"); } 
				set { SetSelect("COL183586960710", value); } 
			}

			/// <summary>
			/// Checks whether column LastPriceUSD is added in select statement 
			/// </summary>
			public bool IsSelectLastPriceUSD { 
				get { return IsSelect("COL183586960716"); } 
				set { SetSelect("COL183586960716", value); } 
			}

			/// <summary>
			/// Checks whether column SumVND is added in select statement 
			/// </summary>
			public bool IsSelectSumVND { 
				get { return IsSelect("COL183586960715"); } 
				set { SetSelect("COL183586960715", value); } 
			}

			/// <summary>
			/// Checks whether column ExtratimeType is added in select statement 
			/// </summary>
			public bool IsSelectExtratimeType { 
				get { return IsSelect("COL183586960743"); } 
				set { SetSelect("COL183586960743", value); } 
			}

			/// <summary>
			/// Checks whether column VatVndM2 is added in select statement 
			/// </summary>
			public bool IsSelectVatVndM2 { 
				get { return IsSelect("COL183586960729"); } 
				set { SetSelect("COL183586960729", value); } 
			}

			/// <summary>
			/// Checks whether column OtherFee01 is added in select statement 
			/// </summary>
			public bool IsSelectOtherFee01 { 
				get { return IsSelect("COL18358696078"); } 
				set { SetSelect("COL18358696078", value); } 
			}

			/// <summary>
			/// Checks whether column SumUsdArea is added in select statement 
			/// </summary>
			public bool IsSelectSumUsdArea { 
				get { return IsSelect("COL183586960722"); } 
				set { SetSelect("COL183586960722", value); } 
			}

			/// <summary>
			/// Checks whether column Comment is added in select statement 
			/// </summary>
			public bool IsSelectComment { 
				get { return IsSelect("COL183586960734"); } 
				set { SetSelect("COL183586960734", value); } 
			}

			/// <summary>
			/// Checks whether column PriceUsdArea is added in select statement 
			/// </summary>
			public bool IsSelectPriceUsdArea { 
				get { return IsSelect("COL183586960718"); } 
				set { SetSelect("COL183586960718", value); } 
			}

			/// <summary>
			/// Checks whether column SumUSD is added in select statement 
			/// </summary>
			public bool IsSelectSumUSD { 
				get { return IsSelect("COL183586960714"); } 
				set { SetSelect("COL183586960714", value); } 
			}

			/// <summary>
			/// Checks whether column YearMonth is added in select statement 
			/// </summary>
			public bool IsSelectYearMonth { 
				get { return IsSelect("COL18358696072"); } 
				set { SetSelect("COL18358696072", value); } 
			}

			/// <summary>
			/// Checks whether column MinPriceUSD is added in select statement 
			/// </summary>
			public bool IsSelectMinPriceUSD { 
				get { return IsSelect("COL183586960742"); } 
				set { SetSelect("COL183586960742", value); } 
			}

			/// <summary>
			/// Checks whether column VatUsdM2 is added in select statement 
			/// </summary>
			public bool IsSelectVatUsdM2 { 
				get { return IsSelect("COL183586960728"); } 
				set { SetSelect("COL183586960728", value); } 
			}

			/// <summary>
			/// Checks whether column ExtraHour is added in select statement 
			/// </summary>
			public bool IsSelectExtraHour { 
				get { return IsSelect("COL18358696076"); } 
				set { SetSelect("COL18358696076", value); } 
			}

			/// <summary>
			/// Checks whether column PriceUsdM2 is added in select statement 
			/// </summary>
			public bool IsSelectPriceUsdM2 { 
				get { return IsSelect("COL183586960726"); } 
				set { SetSelect("COL183586960726", value); } 
			}

			/// <summary>
			/// Checks whether column LastPriceVND is added in select statement 
			/// </summary>
			public bool IsSelectLastPriceVND { 
				get { return IsSelect("COL183586960717"); } 
				set { SetSelect("COL183586960717", value); } 
			}



	}
}