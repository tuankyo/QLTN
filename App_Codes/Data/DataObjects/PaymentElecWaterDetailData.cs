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
	public class PaymentElecWaterDetailData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ1755869322";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of PaymentElecWaterDetail 
			/// </summary>
			public PaymentElecWaterDetailData(string objectID): base(objectID) {}  

			public PaymentElecWaterDetailData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field Created 
			/// </summary>
			public string Created { 
				get { return GetValue("COL175586932223"); } 
				set { SetValue("COL175586932223", value); } 
			}

			/// <summary>
			/// Gets field ElecPricePercent 
			/// </summary>
			public string ElecPricePercent { 
				get { return GetValue("COL175586932228"); } 
				set { SetValue("COL175586932228", value); } 
			}

			/// <summary>
			/// Gets field LastPriceVND 
			/// </summary>
			public string LastPriceVND { 
				get { return GetValue("COL175586932216"); } 
				set { SetValue("COL175586932216", value); } 
			}

			/// <summary>
			/// Gets field DetailType 
			/// </summary>
			public string DetailType { 
				get { return GetValue("COL175586932230"); } 
				set { SetValue("COL175586932230", value); } 
			}

			/// <summary>
			/// Gets field Name 
			/// </summary>
			public string Name { 
				get { return GetValue("COL17558693223"); } 
				set { SetValue("COL17558693223", value); } 
			}

			/// <summary>
			/// Gets field YearMonth 
			/// </summary>
			public string YearMonth { 
				get { return GetValue("COL175586932218"); } 
				set { SetValue("COL175586932218", value); } 
			}

			/// <summary>
			/// Gets field RoomId 
			/// </summary>
			public string RoomId { 
				get { return GetValue("COL175586932221"); } 
				set { SetValue("COL175586932221", value); } 
			}

			/// <summary>
			/// Gets field OtherFee01 
			/// </summary>
			public string OtherFee01 { 
				get { return GetValue("COL17558693227"); } 
				set { SetValue("COL17558693227", value); } 
			}

			/// <summary>
			/// Gets field ModifiedBy 
			/// </summary>
			public string ModifiedBy { 
				get { return GetValue("COL175586932226"); } 
				set { SetValue("COL175586932226", value); } 
			}

			/// <summary>
			/// Gets field VAT 
			/// </summary>
			public string VAT { 
				get { return GetValue("COL17558693226"); } 
				set { SetValue("COL17558693226", value); } 
			}

			/// <summary>
			/// Gets field VatUSD 
			/// </summary>
			public string VatUSD { 
				get { return GetValue("COL175586932211"); } 
				set { SetValue("COL175586932211", value); } 
			}

			/// <summary>
			/// Gets field CreatedBy 
			/// </summary>
			public string CreatedBy { 
				get { return GetValue("COL175586932224"); } 
				set { SetValue("COL175586932224", value); } 
			}

			/// <summary>
			/// Gets field id 
			/// </summary>
			public string id { 
				get { return GetValue("COL17558693221"); } 
				set { SetValue("COL17558693221", value); } 
			}

			/// <summary>
			/// Gets field WaterPricePercent 
			/// </summary>
			public string WaterPricePercent { 
				get { return GetValue("COL175586932229"); } 
				set { SetValue("COL175586932229", value); } 
			}

			/// <summary>
			/// Gets field DelFlag 
			/// </summary>
			public string DelFlag { 
				get { return GetValue("COL175586932227"); } 
				set { SetValue("COL175586932227", value); } 
			}

			/// <summary>
			/// Gets field Modified 
			/// </summary>
			public string Modified { 
				get { return GetValue("COL175586932225"); } 
				set { SetValue("COL175586932225", value); } 
			}

			/// <summary>
			/// Gets field OtherFee02 
			/// </summary>
			public string OtherFee02 { 
				get { return GetValue("COL17558693228"); } 
				set { SetValue("COL17558693228", value); } 
			}

			/// <summary>
			/// Gets field SumUSD 
			/// </summary>
			public string SumUSD { 
				get { return GetValue("COL175586932213"); } 
				set { SetValue("COL175586932213", value); } 
			}

			/// <summary>
			/// Gets field Mount 
			/// </summary>
			public string Mount { 
				get { return GetValue("COL175586932217"); } 
				set { SetValue("COL175586932217", value); } 
			}

			/// <summary>
			/// Gets field CustomerId 
			/// </summary>
			public string CustomerId { 
				get { return GetValue("COL175586932220"); } 
				set { SetValue("COL175586932220", value); } 
			}

			/// <summary>
			/// Gets field PriceUSD 
			/// </summary>
			public string PriceUSD { 
				get { return GetValue("COL17558693229"); } 
				set { SetValue("COL17558693229", value); } 
			}

			/// <summary>
			/// Gets field ToIndex 
			/// </summary>
			public string ToIndex { 
				get { return GetValue("COL17558693225"); } 
				set { SetValue("COL17558693225", value); } 
			}

			/// <summary>
			/// Gets field Comment 
			/// </summary>
			public string Comment { 
				get { return GetValue("COL175586932222"); } 
				set { SetValue("COL175586932222", value); } 
			}

			/// <summary>
			/// Gets field SumVND 
			/// </summary>
			public string SumVND { 
				get { return GetValue("COL175586932214"); } 
				set { SetValue("COL175586932214", value); } 
			}

			/// <summary>
			/// Gets field BuildingId 
			/// </summary>
			public string BuildingId { 
				get { return GetValue("COL175586932219"); } 
				set { SetValue("COL175586932219", value); } 
			}

			/// <summary>
			/// Gets field PriceVND 
			/// </summary>
			public string PriceVND { 
				get { return GetValue("COL175586932210"); } 
				set { SetValue("COL175586932210", value); } 
			}

			/// <summary>
			/// Gets field VatVND 
			/// </summary>
			public string VatVND { 
				get { return GetValue("COL175586932212"); } 
				set { SetValue("COL175586932212", value); } 
			}

			/// <summary>
			/// Gets field LastPriceUSD 
			/// </summary>
			public string LastPriceUSD { 
				get { return GetValue("COL175586932215"); } 
				set { SetValue("COL175586932215", value); } 
			}

			/// <summary>
			/// Gets field UsedElecWaterId 
			/// </summary>
			public string UsedElecWaterId { 
				get { return GetValue("COL17558693222"); } 
				set { SetValue("COL17558693222", value); } 
			}

			/// <summary>
			/// Gets field FromIndex 
			/// </summary>
			public string FromIndex { 
				get { return GetValue("COL17558693224"); } 
				set { SetValue("COL17558693224", value); } 
			}


			/// <summary>
			/// Gets Created attribute data 
			/// </summary>
			public AttributeData GetCreatedAttributeData() { 
				return GetAttributeData("COL175586932223"); 
			}

			/// <summary>
			/// Gets ElecPricePercent attribute data 
			/// </summary>
			public AttributeData GetElecPricePercentAttributeData() { 
				return GetAttributeData("COL175586932228"); 
			}

			/// <summary>
			/// Gets LastPriceVND attribute data 
			/// </summary>
			public AttributeData GetLastPriceVNDAttributeData() { 
				return GetAttributeData("COL175586932216"); 
			}

			/// <summary>
			/// Gets DetailType attribute data 
			/// </summary>
			public AttributeData GetDetailTypeAttributeData() { 
				return GetAttributeData("COL175586932230"); 
			}

			/// <summary>
			/// Gets Name attribute data 
			/// </summary>
			public AttributeData GetNameAttributeData() { 
				return GetAttributeData("COL17558693223"); 
			}

			/// <summary>
			/// Gets YearMonth attribute data 
			/// </summary>
			public AttributeData GetYearMonthAttributeData() { 
				return GetAttributeData("COL175586932218"); 
			}

			/// <summary>
			/// Gets RoomId attribute data 
			/// </summary>
			public AttributeData GetRoomIdAttributeData() { 
				return GetAttributeData("COL175586932221"); 
			}

			/// <summary>
			/// Gets OtherFee01 attribute data 
			/// </summary>
			public AttributeData GetOtherFee01AttributeData() { 
				return GetAttributeData("COL17558693227"); 
			}

			/// <summary>
			/// Gets ModifiedBy attribute data 
			/// </summary>
			public AttributeData GetModifiedByAttributeData() { 
				return GetAttributeData("COL175586932226"); 
			}

			/// <summary>
			/// Gets VAT attribute data 
			/// </summary>
			public AttributeData GetVATAttributeData() { 
				return GetAttributeData("COL17558693226"); 
			}

			/// <summary>
			/// Gets VatUSD attribute data 
			/// </summary>
			public AttributeData GetVatUSDAttributeData() { 
				return GetAttributeData("COL175586932211"); 
			}

			/// <summary>
			/// Gets CreatedBy attribute data 
			/// </summary>
			public AttributeData GetCreatedByAttributeData() { 
				return GetAttributeData("COL175586932224"); 
			}

			/// <summary>
			/// Gets id attribute data 
			/// </summary>
			public AttributeData GetidAttributeData() { 
				return GetAttributeData("COL17558693221"); 
			}

			/// <summary>
			/// Gets WaterPricePercent attribute data 
			/// </summary>
			public AttributeData GetWaterPricePercentAttributeData() { 
				return GetAttributeData("COL175586932229"); 
			}

			/// <summary>
			/// Gets DelFlag attribute data 
			/// </summary>
			public AttributeData GetDelFlagAttributeData() { 
				return GetAttributeData("COL175586932227"); 
			}

			/// <summary>
			/// Gets Modified attribute data 
			/// </summary>
			public AttributeData GetModifiedAttributeData() { 
				return GetAttributeData("COL175586932225"); 
			}

			/// <summary>
			/// Gets OtherFee02 attribute data 
			/// </summary>
			public AttributeData GetOtherFee02AttributeData() { 
				return GetAttributeData("COL17558693228"); 
			}

			/// <summary>
			/// Gets SumUSD attribute data 
			/// </summary>
			public AttributeData GetSumUSDAttributeData() { 
				return GetAttributeData("COL175586932213"); 
			}

			/// <summary>
			/// Gets Mount attribute data 
			/// </summary>
			public AttributeData GetMountAttributeData() { 
				return GetAttributeData("COL175586932217"); 
			}

			/// <summary>
			/// Gets CustomerId attribute data 
			/// </summary>
			public AttributeData GetCustomerIdAttributeData() { 
				return GetAttributeData("COL175586932220"); 
			}

			/// <summary>
			/// Gets PriceUSD attribute data 
			/// </summary>
			public AttributeData GetPriceUSDAttributeData() { 
				return GetAttributeData("COL17558693229"); 
			}

			/// <summary>
			/// Gets ToIndex attribute data 
			/// </summary>
			public AttributeData GetToIndexAttributeData() { 
				return GetAttributeData("COL17558693225"); 
			}

			/// <summary>
			/// Gets Comment attribute data 
			/// </summary>
			public AttributeData GetCommentAttributeData() { 
				return GetAttributeData("COL175586932222"); 
			}

			/// <summary>
			/// Gets SumVND attribute data 
			/// </summary>
			public AttributeData GetSumVNDAttributeData() { 
				return GetAttributeData("COL175586932214"); 
			}

			/// <summary>
			/// Gets BuildingId attribute data 
			/// </summary>
			public AttributeData GetBuildingIdAttributeData() { 
				return GetAttributeData("COL175586932219"); 
			}

			/// <summary>
			/// Gets PriceVND attribute data 
			/// </summary>
			public AttributeData GetPriceVNDAttributeData() { 
				return GetAttributeData("COL175586932210"); 
			}

			/// <summary>
			/// Gets VatVND attribute data 
			/// </summary>
			public AttributeData GetVatVNDAttributeData() { 
				return GetAttributeData("COL175586932212"); 
			}

			/// <summary>
			/// Gets LastPriceUSD attribute data 
			/// </summary>
			public AttributeData GetLastPriceUSDAttributeData() { 
				return GetAttributeData("COL175586932215"); 
			}

			/// <summary>
			/// Gets UsedElecWaterId attribute data 
			/// </summary>
			public AttributeData GetUsedElecWaterIdAttributeData() { 
				return GetAttributeData("COL17558693222"); 
			}

			/// <summary>
			/// Gets FromIndex attribute data 
			/// </summary>
			public AttributeData GetFromIndexAttributeData() { 
				return GetAttributeData("COL17558693224"); 
			}


			/// <summary>
			/// Gets column Created with alias  
			/// </summary>
			public string ColCreated { 
				get { return GetColumnName("COL175586932223"); } 
			}

			/// <summary>
			/// Gets column ElecPricePercent with alias  
			/// </summary>
			public string ColElecPricePercent { 
				get { return GetColumnName("COL175586932228"); } 
			}

			/// <summary>
			/// Gets column LastPriceVND with alias  
			/// </summary>
			public string ColLastPriceVND { 
				get { return GetColumnName("COL175586932216"); } 
			}

			/// <summary>
			/// Gets column DetailType with alias  
			/// </summary>
			public string ColDetailType { 
				get { return GetColumnName("COL175586932230"); } 
			}

			/// <summary>
			/// Gets column Name with alias  
			/// </summary>
			public string ColName { 
				get { return GetColumnName("COL17558693223"); } 
			}

			/// <summary>
			/// Gets column YearMonth with alias  
			/// </summary>
			public string ColYearMonth { 
				get { return GetColumnName("COL175586932218"); } 
			}

			/// <summary>
			/// Gets column RoomId with alias  
			/// </summary>
			public string ColRoomId { 
				get { return GetColumnName("COL175586932221"); } 
			}

			/// <summary>
			/// Gets column OtherFee01 with alias  
			/// </summary>
			public string ColOtherFee01 { 
				get { return GetColumnName("COL17558693227"); } 
			}

			/// <summary>
			/// Gets column ModifiedBy with alias  
			/// </summary>
			public string ColModifiedBy { 
				get { return GetColumnName("COL175586932226"); } 
			}

			/// <summary>
			/// Gets column VAT with alias  
			/// </summary>
			public string ColVAT { 
				get { return GetColumnName("COL17558693226"); } 
			}

			/// <summary>
			/// Gets column VatUSD with alias  
			/// </summary>
			public string ColVatUSD { 
				get { return GetColumnName("COL175586932211"); } 
			}

			/// <summary>
			/// Gets column CreatedBy with alias  
			/// </summary>
			public string ColCreatedBy { 
				get { return GetColumnName("COL175586932224"); } 
			}

			/// <summary>
			/// Gets column id with alias  
			/// </summary>
			public string Colid { 
				get { return GetColumnName("COL17558693221"); } 
			}

			/// <summary>
			/// Gets column WaterPricePercent with alias  
			/// </summary>
			public string ColWaterPricePercent { 
				get { return GetColumnName("COL175586932229"); } 
			}

			/// <summary>
			/// Gets column DelFlag with alias  
			/// </summary>
			public string ColDelFlag { 
				get { return GetColumnName("COL175586932227"); } 
			}

			/// <summary>
			/// Gets column Modified with alias  
			/// </summary>
			public string ColModified { 
				get { return GetColumnName("COL175586932225"); } 
			}

			/// <summary>
			/// Gets column OtherFee02 with alias  
			/// </summary>
			public string ColOtherFee02 { 
				get { return GetColumnName("COL17558693228"); } 
			}

			/// <summary>
			/// Gets column SumUSD with alias  
			/// </summary>
			public string ColSumUSD { 
				get { return GetColumnName("COL175586932213"); } 
			}

			/// <summary>
			/// Gets column Mount with alias  
			/// </summary>
			public string ColMount { 
				get { return GetColumnName("COL175586932217"); } 
			}

			/// <summary>
			/// Gets column CustomerId with alias  
			/// </summary>
			public string ColCustomerId { 
				get { return GetColumnName("COL175586932220"); } 
			}

			/// <summary>
			/// Gets column PriceUSD with alias  
			/// </summary>
			public string ColPriceUSD { 
				get { return GetColumnName("COL17558693229"); } 
			}

			/// <summary>
			/// Gets column ToIndex with alias  
			/// </summary>
			public string ColToIndex { 
				get { return GetColumnName("COL17558693225"); } 
			}

			/// <summary>
			/// Gets column Comment with alias  
			/// </summary>
			public string ColComment { 
				get { return GetColumnName("COL175586932222"); } 
			}

			/// <summary>
			/// Gets column SumVND with alias  
			/// </summary>
			public string ColSumVND { 
				get { return GetColumnName("COL175586932214"); } 
			}

			/// <summary>
			/// Gets column BuildingId with alias  
			/// </summary>
			public string ColBuildingId { 
				get { return GetColumnName("COL175586932219"); } 
			}

			/// <summary>
			/// Gets column PriceVND with alias  
			/// </summary>
			public string ColPriceVND { 
				get { return GetColumnName("COL175586932210"); } 
			}

			/// <summary>
			/// Gets column VatVND with alias  
			/// </summary>
			public string ColVatVND { 
				get { return GetColumnName("COL175586932212"); } 
			}

			/// <summary>
			/// Gets column LastPriceUSD with alias  
			/// </summary>
			public string ColLastPriceUSD { 
				get { return GetColumnName("COL175586932215"); } 
			}

			/// <summary>
			/// Gets column UsedElecWaterId with alias  
			/// </summary>
			public string ColUsedElecWaterId { 
				get { return GetColumnName("COL17558693222"); } 
			}

			/// <summary>
			/// Gets column FromIndex with alias  
			/// </summary>
			public string ColFromIndex { 
				get { return GetColumnName("COL17558693224"); } 
			}


			/// <summary>
			/// Checks whether column Created is added in select statement 
			/// </summary>
			public bool IsSelectCreated { 
				get { return IsSelect("COL175586932223"); } 
				set { SetSelect("COL175586932223", value); } 
			}

			/// <summary>
			/// Checks whether column ElecPricePercent is added in select statement 
			/// </summary>
			public bool IsSelectElecPricePercent { 
				get { return IsSelect("COL175586932228"); } 
				set { SetSelect("COL175586932228", value); } 
			}

			/// <summary>
			/// Checks whether column LastPriceVND is added in select statement 
			/// </summary>
			public bool IsSelectLastPriceVND { 
				get { return IsSelect("COL175586932216"); } 
				set { SetSelect("COL175586932216", value); } 
			}

			/// <summary>
			/// Checks whether column DetailType is added in select statement 
			/// </summary>
			public bool IsSelectDetailType { 
				get { return IsSelect("COL175586932230"); } 
				set { SetSelect("COL175586932230", value); } 
			}

			/// <summary>
			/// Checks whether column Name is added in select statement 
			/// </summary>
			public bool IsSelectName { 
				get { return IsSelect("COL17558693223"); } 
				set { SetSelect("COL17558693223", value); } 
			}

			/// <summary>
			/// Checks whether column YearMonth is added in select statement 
			/// </summary>
			public bool IsSelectYearMonth { 
				get { return IsSelect("COL175586932218"); } 
				set { SetSelect("COL175586932218", value); } 
			}

			/// <summary>
			/// Checks whether column RoomId is added in select statement 
			/// </summary>
			public bool IsSelectRoomId { 
				get { return IsSelect("COL175586932221"); } 
				set { SetSelect("COL175586932221", value); } 
			}

			/// <summary>
			/// Checks whether column OtherFee01 is added in select statement 
			/// </summary>
			public bool IsSelectOtherFee01 { 
				get { return IsSelect("COL17558693227"); } 
				set { SetSelect("COL17558693227", value); } 
			}

			/// <summary>
			/// Checks whether column ModifiedBy is added in select statement 
			/// </summary>
			public bool IsSelectModifiedBy { 
				get { return IsSelect("COL175586932226"); } 
				set { SetSelect("COL175586932226", value); } 
			}

			/// <summary>
			/// Checks whether column VAT is added in select statement 
			/// </summary>
			public bool IsSelectVAT { 
				get { return IsSelect("COL17558693226"); } 
				set { SetSelect("COL17558693226", value); } 
			}

			/// <summary>
			/// Checks whether column VatUSD is added in select statement 
			/// </summary>
			public bool IsSelectVatUSD { 
				get { return IsSelect("COL175586932211"); } 
				set { SetSelect("COL175586932211", value); } 
			}

			/// <summary>
			/// Checks whether column CreatedBy is added in select statement 
			/// </summary>
			public bool IsSelectCreatedBy { 
				get { return IsSelect("COL175586932224"); } 
				set { SetSelect("COL175586932224", value); } 
			}

			/// <summary>
			/// Checks whether column id is added in select statement 
			/// </summary>
			public bool IsSelectid { 
				get { return IsSelect("COL17558693221"); } 
				set { SetSelect("COL17558693221", value); } 
			}

			/// <summary>
			/// Checks whether column WaterPricePercent is added in select statement 
			/// </summary>
			public bool IsSelectWaterPricePercent { 
				get { return IsSelect("COL175586932229"); } 
				set { SetSelect("COL175586932229", value); } 
			}

			/// <summary>
			/// Checks whether column DelFlag is added in select statement 
			/// </summary>
			public bool IsSelectDelFlag { 
				get { return IsSelect("COL175586932227"); } 
				set { SetSelect("COL175586932227", value); } 
			}

			/// <summary>
			/// Checks whether column Modified is added in select statement 
			/// </summary>
			public bool IsSelectModified { 
				get { return IsSelect("COL175586932225"); } 
				set { SetSelect("COL175586932225", value); } 
			}

			/// <summary>
			/// Checks whether column OtherFee02 is added in select statement 
			/// </summary>
			public bool IsSelectOtherFee02 { 
				get { return IsSelect("COL17558693228"); } 
				set { SetSelect("COL17558693228", value); } 
			}

			/// <summary>
			/// Checks whether column SumUSD is added in select statement 
			/// </summary>
			public bool IsSelectSumUSD { 
				get { return IsSelect("COL175586932213"); } 
				set { SetSelect("COL175586932213", value); } 
			}

			/// <summary>
			/// Checks whether column Mount is added in select statement 
			/// </summary>
			public bool IsSelectMount { 
				get { return IsSelect("COL175586932217"); } 
				set { SetSelect("COL175586932217", value); } 
			}

			/// <summary>
			/// Checks whether column CustomerId is added in select statement 
			/// </summary>
			public bool IsSelectCustomerId { 
				get { return IsSelect("COL175586932220"); } 
				set { SetSelect("COL175586932220", value); } 
			}

			/// <summary>
			/// Checks whether column PriceUSD is added in select statement 
			/// </summary>
			public bool IsSelectPriceUSD { 
				get { return IsSelect("COL17558693229"); } 
				set { SetSelect("COL17558693229", value); } 
			}

			/// <summary>
			/// Checks whether column ToIndex is added in select statement 
			/// </summary>
			public bool IsSelectToIndex { 
				get { return IsSelect("COL17558693225"); } 
				set { SetSelect("COL17558693225", value); } 
			}

			/// <summary>
			/// Checks whether column Comment is added in select statement 
			/// </summary>
			public bool IsSelectComment { 
				get { return IsSelect("COL175586932222"); } 
				set { SetSelect("COL175586932222", value); } 
			}

			/// <summary>
			/// Checks whether column SumVND is added in select statement 
			/// </summary>
			public bool IsSelectSumVND { 
				get { return IsSelect("COL175586932214"); } 
				set { SetSelect("COL175586932214", value); } 
			}

			/// <summary>
			/// Checks whether column BuildingId is added in select statement 
			/// </summary>
			public bool IsSelectBuildingId { 
				get { return IsSelect("COL175586932219"); } 
				set { SetSelect("COL175586932219", value); } 
			}

			/// <summary>
			/// Checks whether column PriceVND is added in select statement 
			/// </summary>
			public bool IsSelectPriceVND { 
				get { return IsSelect("COL175586932210"); } 
				set { SetSelect("COL175586932210", value); } 
			}

			/// <summary>
			/// Checks whether column VatVND is added in select statement 
			/// </summary>
			public bool IsSelectVatVND { 
				get { return IsSelect("COL175586932212"); } 
				set { SetSelect("COL175586932212", value); } 
			}

			/// <summary>
			/// Checks whether column LastPriceUSD is added in select statement 
			/// </summary>
			public bool IsSelectLastPriceUSD { 
				get { return IsSelect("COL175586932215"); } 
				set { SetSelect("COL175586932215", value); } 
			}

			/// <summary>
			/// Checks whether column UsedElecWaterId is added in select statement 
			/// </summary>
			public bool IsSelectUsedElecWaterId { 
				get { return IsSelect("COL17558693222"); } 
				set { SetSelect("COL17558693222", value); } 
			}

			/// <summary>
			/// Checks whether column FromIndex is added in select statement 
			/// </summary>
			public bool IsSelectFromIndex { 
				get { return IsSelect("COL17558693224"); } 
				set { SetSelect("COL17558693224", value); } 
			}



	}
}