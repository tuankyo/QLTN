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
	public class PaymentElecWaterData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ683865503";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of PaymentElecWater 
			/// </summary>
			public PaymentElecWaterData(string objectID): base(objectID) {}  

			public PaymentElecWaterData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field Comment 
			/// </summary>
			public string Comment { 
				get { return GetValue("COL68386550323"); } 
				set { SetValue("COL68386550323", value); } 
			}

			/// <summary>
			/// Gets field OtherFee02 
			/// </summary>
			public string OtherFee02 { 
				get { return GetValue("COL68386550316"); } 
				set { SetValue("COL68386550316", value); } 
			}

			/// <summary>
			/// Gets field SumUSD 
			/// </summary>
			public string SumUSD { 
				get { return GetValue("COL68386550319"); } 
				set { SetValue("COL68386550319", value); } 
			}

			/// <summary>
			/// Gets field Modified 
			/// </summary>
			public string Modified { 
				get { return GetValue("COL68386550326"); } 
				set { SetValue("COL68386550326", value); } 
			}

			/// <summary>
			/// Gets field OldIndex 
			/// </summary>
			public string OldIndex { 
				get { return GetValue("COL68386550311"); } 
				set { SetValue("COL68386550311", value); } 
			}

			/// <summary>
			/// Gets field LastPriceUSD 
			/// </summary>
			public string LastPriceUSD { 
				get { return GetValue("COL68386550321"); } 
				set { SetValue("COL68386550321", value); } 
			}

			/// <summary>
			/// Gets field VAT 
			/// </summary>
			public string VAT { 
				get { return GetValue("COL68386550314"); } 
				set { SetValue("COL68386550314", value); } 
			}

			/// <summary>
			/// Gets field YearMonth 
			/// </summary>
			public string YearMonth { 
				get { return GetValue("COL6838655032"); } 
				set { SetValue("COL6838655032", value); } 
			}

			/// <summary>
			/// Gets field DetailType 
			/// </summary>
			public string DetailType { 
				get { return GetValue("COL68386550329"); } 
				set { SetValue("COL68386550329", value); } 
			}

			/// <summary>
			/// Gets field Created 
			/// </summary>
			public string Created { 
				get { return GetValue("COL68386550324"); } 
				set { SetValue("COL68386550324", value); } 
			}

			/// <summary>
			/// Gets field ModifiedBy 
			/// </summary>
			public string ModifiedBy { 
				get { return GetValue("COL68386550327"); } 
				set { SetValue("COL68386550327", value); } 
			}

			/// <summary>
			/// Gets field CreatedBy 
			/// </summary>
			public string CreatedBy { 
				get { return GetValue("COL68386550325"); } 
				set { SetValue("COL68386550325", value); } 
			}

			/// <summary>
			/// Gets field VatUSD 
			/// </summary>
			public string VatUSD { 
				get { return GetValue("COL68386550317"); } 
				set { SetValue("COL68386550317", value); } 
			}

			/// <summary>
			/// Gets field OtherFee01 
			/// </summary>
			public string OtherFee01 { 
				get { return GetValue("COL68386550315"); } 
				set { SetValue("COL68386550315", value); } 
			}

			/// <summary>
			/// Gets field TarrifsOfWaterId 
			/// </summary>
			public string TarrifsOfWaterId { 
				get { return GetValue("COL6838655038"); } 
				set { SetValue("COL6838655038", value); } 
			}

			/// <summary>
			/// Gets field NewIndex 
			/// </summary>
			public string NewIndex { 
				get { return GetValue("COL68386550312"); } 
				set { SetValue("COL68386550312", value); } 
			}

			/// <summary>
			/// Gets field TarrifsOfElecId 
			/// </summary>
			public string TarrifsOfElecId { 
				get { return GetValue("COL6838655037"); } 
				set { SetValue("COL6838655037", value); } 
			}

			/// <summary>
			/// Gets field LastPriceVND 
			/// </summary>
			public string LastPriceVND { 
				get { return GetValue("COL68386550322"); } 
				set { SetValue("COL68386550322", value); } 
			}

			/// <summary>
			/// Gets field id 
			/// </summary>
			public string id { 
				get { return GetValue("COL6838655031"); } 
				set { SetValue("COL6838655031", value); } 
			}

			/// <summary>
			/// Gets field BuildingId 
			/// </summary>
			public string BuildingId { 
				get { return GetValue("COL6838655033"); } 
				set { SetValue("COL6838655033", value); } 
			}

			/// <summary>
			/// Gets field VatVND 
			/// </summary>
			public string VatVND { 
				get { return GetValue("COL68386550318"); } 
				set { SetValue("COL68386550318", value); } 
			}

			/// <summary>
			/// Gets field RoomId 
			/// </summary>
			public string RoomId { 
				get { return GetValue("COL6838655035"); } 
				set { SetValue("COL6838655035", value); } 
			}

			/// <summary>
			/// Gets field CustomerId 
			/// </summary>
			public string CustomerId { 
				get { return GetValue("COL6838655034"); } 
				set { SetValue("COL6838655034", value); } 
			}

			/// <summary>
			/// Gets field DateTo 
			/// </summary>
			public string DateTo { 
				get { return GetValue("COL68386550310"); } 
				set { SetValue("COL68386550310", value); } 
			}

			/// <summary>
			/// Gets field UsedElecWaterId 
			/// </summary>
			public string UsedElecWaterId { 
				get { return GetValue("COL6838655036"); } 
				set { SetValue("COL6838655036", value); } 
			}

			/// <summary>
			/// Gets field DateFrom 
			/// </summary>
			public string DateFrom { 
				get { return GetValue("COL6838655039"); } 
				set { SetValue("COL6838655039", value); } 
			}

			/// <summary>
			/// Gets field SumVND 
			/// </summary>
			public string SumVND { 
				get { return GetValue("COL68386550320"); } 
				set { SetValue("COL68386550320", value); } 
			}

			/// <summary>
			/// Gets field DelFlag 
			/// </summary>
			public string DelFlag { 
				get { return GetValue("COL68386550328"); } 
				set { SetValue("COL68386550328", value); } 
			}

			/// <summary>
			/// Gets field Mount 
			/// </summary>
			public string Mount { 
				get { return GetValue("COL68386550313"); } 
				set { SetValue("COL68386550313", value); } 
			}


			/// <summary>
			/// Gets Comment attribute data 
			/// </summary>
			public AttributeData GetCommentAttributeData() { 
				return GetAttributeData("COL68386550323"); 
			}

			/// <summary>
			/// Gets OtherFee02 attribute data 
			/// </summary>
			public AttributeData GetOtherFee02AttributeData() { 
				return GetAttributeData("COL68386550316"); 
			}

			/// <summary>
			/// Gets SumUSD attribute data 
			/// </summary>
			public AttributeData GetSumUSDAttributeData() { 
				return GetAttributeData("COL68386550319"); 
			}

			/// <summary>
			/// Gets Modified attribute data 
			/// </summary>
			public AttributeData GetModifiedAttributeData() { 
				return GetAttributeData("COL68386550326"); 
			}

			/// <summary>
			/// Gets OldIndex attribute data 
			/// </summary>
			public AttributeData GetOldIndexAttributeData() { 
				return GetAttributeData("COL68386550311"); 
			}

			/// <summary>
			/// Gets LastPriceUSD attribute data 
			/// </summary>
			public AttributeData GetLastPriceUSDAttributeData() { 
				return GetAttributeData("COL68386550321"); 
			}

			/// <summary>
			/// Gets VAT attribute data 
			/// </summary>
			public AttributeData GetVATAttributeData() { 
				return GetAttributeData("COL68386550314"); 
			}

			/// <summary>
			/// Gets YearMonth attribute data 
			/// </summary>
			public AttributeData GetYearMonthAttributeData() { 
				return GetAttributeData("COL6838655032"); 
			}

			/// <summary>
			/// Gets DetailType attribute data 
			/// </summary>
			public AttributeData GetDetailTypeAttributeData() { 
				return GetAttributeData("COL68386550329"); 
			}

			/// <summary>
			/// Gets Created attribute data 
			/// </summary>
			public AttributeData GetCreatedAttributeData() { 
				return GetAttributeData("COL68386550324"); 
			}

			/// <summary>
			/// Gets ModifiedBy attribute data 
			/// </summary>
			public AttributeData GetModifiedByAttributeData() { 
				return GetAttributeData("COL68386550327"); 
			}

			/// <summary>
			/// Gets CreatedBy attribute data 
			/// </summary>
			public AttributeData GetCreatedByAttributeData() { 
				return GetAttributeData("COL68386550325"); 
			}

			/// <summary>
			/// Gets VatUSD attribute data 
			/// </summary>
			public AttributeData GetVatUSDAttributeData() { 
				return GetAttributeData("COL68386550317"); 
			}

			/// <summary>
			/// Gets OtherFee01 attribute data 
			/// </summary>
			public AttributeData GetOtherFee01AttributeData() { 
				return GetAttributeData("COL68386550315"); 
			}

			/// <summary>
			/// Gets TarrifsOfWaterId attribute data 
			/// </summary>
			public AttributeData GetTarrifsOfWaterIdAttributeData() { 
				return GetAttributeData("COL6838655038"); 
			}

			/// <summary>
			/// Gets NewIndex attribute data 
			/// </summary>
			public AttributeData GetNewIndexAttributeData() { 
				return GetAttributeData("COL68386550312"); 
			}

			/// <summary>
			/// Gets TarrifsOfElecId attribute data 
			/// </summary>
			public AttributeData GetTarrifsOfElecIdAttributeData() { 
				return GetAttributeData("COL6838655037"); 
			}

			/// <summary>
			/// Gets LastPriceVND attribute data 
			/// </summary>
			public AttributeData GetLastPriceVNDAttributeData() { 
				return GetAttributeData("COL68386550322"); 
			}

			/// <summary>
			/// Gets id attribute data 
			/// </summary>
			public AttributeData GetidAttributeData() { 
				return GetAttributeData("COL6838655031"); 
			}

			/// <summary>
			/// Gets BuildingId attribute data 
			/// </summary>
			public AttributeData GetBuildingIdAttributeData() { 
				return GetAttributeData("COL6838655033"); 
			}

			/// <summary>
			/// Gets VatVND attribute data 
			/// </summary>
			public AttributeData GetVatVNDAttributeData() { 
				return GetAttributeData("COL68386550318"); 
			}

			/// <summary>
			/// Gets RoomId attribute data 
			/// </summary>
			public AttributeData GetRoomIdAttributeData() { 
				return GetAttributeData("COL6838655035"); 
			}

			/// <summary>
			/// Gets CustomerId attribute data 
			/// </summary>
			public AttributeData GetCustomerIdAttributeData() { 
				return GetAttributeData("COL6838655034"); 
			}

			/// <summary>
			/// Gets DateTo attribute data 
			/// </summary>
			public AttributeData GetDateToAttributeData() { 
				return GetAttributeData("COL68386550310"); 
			}

			/// <summary>
			/// Gets UsedElecWaterId attribute data 
			/// </summary>
			public AttributeData GetUsedElecWaterIdAttributeData() { 
				return GetAttributeData("COL6838655036"); 
			}

			/// <summary>
			/// Gets DateFrom attribute data 
			/// </summary>
			public AttributeData GetDateFromAttributeData() { 
				return GetAttributeData("COL6838655039"); 
			}

			/// <summary>
			/// Gets SumVND attribute data 
			/// </summary>
			public AttributeData GetSumVNDAttributeData() { 
				return GetAttributeData("COL68386550320"); 
			}

			/// <summary>
			/// Gets DelFlag attribute data 
			/// </summary>
			public AttributeData GetDelFlagAttributeData() { 
				return GetAttributeData("COL68386550328"); 
			}

			/// <summary>
			/// Gets Mount attribute data 
			/// </summary>
			public AttributeData GetMountAttributeData() { 
				return GetAttributeData("COL68386550313"); 
			}


			/// <summary>
			/// Gets column Comment with alias  
			/// </summary>
			public string ColComment { 
				get { return GetColumnName("COL68386550323"); } 
			}

			/// <summary>
			/// Gets column OtherFee02 with alias  
			/// </summary>
			public string ColOtherFee02 { 
				get { return GetColumnName("COL68386550316"); } 
			}

			/// <summary>
			/// Gets column SumUSD with alias  
			/// </summary>
			public string ColSumUSD { 
				get { return GetColumnName("COL68386550319"); } 
			}

			/// <summary>
			/// Gets column Modified with alias  
			/// </summary>
			public string ColModified { 
				get { return GetColumnName("COL68386550326"); } 
			}

			/// <summary>
			/// Gets column OldIndex with alias  
			/// </summary>
			public string ColOldIndex { 
				get { return GetColumnName("COL68386550311"); } 
			}

			/// <summary>
			/// Gets column LastPriceUSD with alias  
			/// </summary>
			public string ColLastPriceUSD { 
				get { return GetColumnName("COL68386550321"); } 
			}

			/// <summary>
			/// Gets column VAT with alias  
			/// </summary>
			public string ColVAT { 
				get { return GetColumnName("COL68386550314"); } 
			}

			/// <summary>
			/// Gets column YearMonth with alias  
			/// </summary>
			public string ColYearMonth { 
				get { return GetColumnName("COL6838655032"); } 
			}

			/// <summary>
			/// Gets column DetailType with alias  
			/// </summary>
			public string ColDetailType { 
				get { return GetColumnName("COL68386550329"); } 
			}

			/// <summary>
			/// Gets column Created with alias  
			/// </summary>
			public string ColCreated { 
				get { return GetColumnName("COL68386550324"); } 
			}

			/// <summary>
			/// Gets column ModifiedBy with alias  
			/// </summary>
			public string ColModifiedBy { 
				get { return GetColumnName("COL68386550327"); } 
			}

			/// <summary>
			/// Gets column CreatedBy with alias  
			/// </summary>
			public string ColCreatedBy { 
				get { return GetColumnName("COL68386550325"); } 
			}

			/// <summary>
			/// Gets column VatUSD with alias  
			/// </summary>
			public string ColVatUSD { 
				get { return GetColumnName("COL68386550317"); } 
			}

			/// <summary>
			/// Gets column OtherFee01 with alias  
			/// </summary>
			public string ColOtherFee01 { 
				get { return GetColumnName("COL68386550315"); } 
			}

			/// <summary>
			/// Gets column TarrifsOfWaterId with alias  
			/// </summary>
			public string ColTarrifsOfWaterId { 
				get { return GetColumnName("COL6838655038"); } 
			}

			/// <summary>
			/// Gets column NewIndex with alias  
			/// </summary>
			public string ColNewIndex { 
				get { return GetColumnName("COL68386550312"); } 
			}

			/// <summary>
			/// Gets column TarrifsOfElecId with alias  
			/// </summary>
			public string ColTarrifsOfElecId { 
				get { return GetColumnName("COL6838655037"); } 
			}

			/// <summary>
			/// Gets column LastPriceVND with alias  
			/// </summary>
			public string ColLastPriceVND { 
				get { return GetColumnName("COL68386550322"); } 
			}

			/// <summary>
			/// Gets column id with alias  
			/// </summary>
			public string Colid { 
				get { return GetColumnName("COL6838655031"); } 
			}

			/// <summary>
			/// Gets column BuildingId with alias  
			/// </summary>
			public string ColBuildingId { 
				get { return GetColumnName("COL6838655033"); } 
			}

			/// <summary>
			/// Gets column VatVND with alias  
			/// </summary>
			public string ColVatVND { 
				get { return GetColumnName("COL68386550318"); } 
			}

			/// <summary>
			/// Gets column RoomId with alias  
			/// </summary>
			public string ColRoomId { 
				get { return GetColumnName("COL6838655035"); } 
			}

			/// <summary>
			/// Gets column CustomerId with alias  
			/// </summary>
			public string ColCustomerId { 
				get { return GetColumnName("COL6838655034"); } 
			}

			/// <summary>
			/// Gets column DateTo with alias  
			/// </summary>
			public string ColDateTo { 
				get { return GetColumnName("COL68386550310"); } 
			}

			/// <summary>
			/// Gets column UsedElecWaterId with alias  
			/// </summary>
			public string ColUsedElecWaterId { 
				get { return GetColumnName("COL6838655036"); } 
			}

			/// <summary>
			/// Gets column DateFrom with alias  
			/// </summary>
			public string ColDateFrom { 
				get { return GetColumnName("COL6838655039"); } 
			}

			/// <summary>
			/// Gets column SumVND with alias  
			/// </summary>
			public string ColSumVND { 
				get { return GetColumnName("COL68386550320"); } 
			}

			/// <summary>
			/// Gets column DelFlag with alias  
			/// </summary>
			public string ColDelFlag { 
				get { return GetColumnName("COL68386550328"); } 
			}

			/// <summary>
			/// Gets column Mount with alias  
			/// </summary>
			public string ColMount { 
				get { return GetColumnName("COL68386550313"); } 
			}


			/// <summary>
			/// Checks whether column Comment is added in select statement 
			/// </summary>
			public bool IsSelectComment { 
				get { return IsSelect("COL68386550323"); } 
				set { SetSelect("COL68386550323", value); } 
			}

			/// <summary>
			/// Checks whether column OtherFee02 is added in select statement 
			/// </summary>
			public bool IsSelectOtherFee02 { 
				get { return IsSelect("COL68386550316"); } 
				set { SetSelect("COL68386550316", value); } 
			}

			/// <summary>
			/// Checks whether column SumUSD is added in select statement 
			/// </summary>
			public bool IsSelectSumUSD { 
				get { return IsSelect("COL68386550319"); } 
				set { SetSelect("COL68386550319", value); } 
			}

			/// <summary>
			/// Checks whether column Modified is added in select statement 
			/// </summary>
			public bool IsSelectModified { 
				get { return IsSelect("COL68386550326"); } 
				set { SetSelect("COL68386550326", value); } 
			}

			/// <summary>
			/// Checks whether column OldIndex is added in select statement 
			/// </summary>
			public bool IsSelectOldIndex { 
				get { return IsSelect("COL68386550311"); } 
				set { SetSelect("COL68386550311", value); } 
			}

			/// <summary>
			/// Checks whether column LastPriceUSD is added in select statement 
			/// </summary>
			public bool IsSelectLastPriceUSD { 
				get { return IsSelect("COL68386550321"); } 
				set { SetSelect("COL68386550321", value); } 
			}

			/// <summary>
			/// Checks whether column VAT is added in select statement 
			/// </summary>
			public bool IsSelectVAT { 
				get { return IsSelect("COL68386550314"); } 
				set { SetSelect("COL68386550314", value); } 
			}

			/// <summary>
			/// Checks whether column YearMonth is added in select statement 
			/// </summary>
			public bool IsSelectYearMonth { 
				get { return IsSelect("COL6838655032"); } 
				set { SetSelect("COL6838655032", value); } 
			}

			/// <summary>
			/// Checks whether column DetailType is added in select statement 
			/// </summary>
			public bool IsSelectDetailType { 
				get { return IsSelect("COL68386550329"); } 
				set { SetSelect("COL68386550329", value); } 
			}

			/// <summary>
			/// Checks whether column Created is added in select statement 
			/// </summary>
			public bool IsSelectCreated { 
				get { return IsSelect("COL68386550324"); } 
				set { SetSelect("COL68386550324", value); } 
			}

			/// <summary>
			/// Checks whether column ModifiedBy is added in select statement 
			/// </summary>
			public bool IsSelectModifiedBy { 
				get { return IsSelect("COL68386550327"); } 
				set { SetSelect("COL68386550327", value); } 
			}

			/// <summary>
			/// Checks whether column CreatedBy is added in select statement 
			/// </summary>
			public bool IsSelectCreatedBy { 
				get { return IsSelect("COL68386550325"); } 
				set { SetSelect("COL68386550325", value); } 
			}

			/// <summary>
			/// Checks whether column VatUSD is added in select statement 
			/// </summary>
			public bool IsSelectVatUSD { 
				get { return IsSelect("COL68386550317"); } 
				set { SetSelect("COL68386550317", value); } 
			}

			/// <summary>
			/// Checks whether column OtherFee01 is added in select statement 
			/// </summary>
			public bool IsSelectOtherFee01 { 
				get { return IsSelect("COL68386550315"); } 
				set { SetSelect("COL68386550315", value); } 
			}

			/// <summary>
			/// Checks whether column TarrifsOfWaterId is added in select statement 
			/// </summary>
			public bool IsSelectTarrifsOfWaterId { 
				get { return IsSelect("COL6838655038"); } 
				set { SetSelect("COL6838655038", value); } 
			}

			/// <summary>
			/// Checks whether column NewIndex is added in select statement 
			/// </summary>
			public bool IsSelectNewIndex { 
				get { return IsSelect("COL68386550312"); } 
				set { SetSelect("COL68386550312", value); } 
			}

			/// <summary>
			/// Checks whether column TarrifsOfElecId is added in select statement 
			/// </summary>
			public bool IsSelectTarrifsOfElecId { 
				get { return IsSelect("COL6838655037"); } 
				set { SetSelect("COL6838655037", value); } 
			}

			/// <summary>
			/// Checks whether column LastPriceVND is added in select statement 
			/// </summary>
			public bool IsSelectLastPriceVND { 
				get { return IsSelect("COL68386550322"); } 
				set { SetSelect("COL68386550322", value); } 
			}

			/// <summary>
			/// Checks whether column id is added in select statement 
			/// </summary>
			public bool IsSelectid { 
				get { return IsSelect("COL6838655031"); } 
				set { SetSelect("COL6838655031", value); } 
			}

			/// <summary>
			/// Checks whether column BuildingId is added in select statement 
			/// </summary>
			public bool IsSelectBuildingId { 
				get { return IsSelect("COL6838655033"); } 
				set { SetSelect("COL6838655033", value); } 
			}

			/// <summary>
			/// Checks whether column VatVND is added in select statement 
			/// </summary>
			public bool IsSelectVatVND { 
				get { return IsSelect("COL68386550318"); } 
				set { SetSelect("COL68386550318", value); } 
			}

			/// <summary>
			/// Checks whether column RoomId is added in select statement 
			/// </summary>
			public bool IsSelectRoomId { 
				get { return IsSelect("COL6838655035"); } 
				set { SetSelect("COL6838655035", value); } 
			}

			/// <summary>
			/// Checks whether column CustomerId is added in select statement 
			/// </summary>
			public bool IsSelectCustomerId { 
				get { return IsSelect("COL6838655034"); } 
				set { SetSelect("COL6838655034", value); } 
			}

			/// <summary>
			/// Checks whether column DateTo is added in select statement 
			/// </summary>
			public bool IsSelectDateTo { 
				get { return IsSelect("COL68386550310"); } 
				set { SetSelect("COL68386550310", value); } 
			}

			/// <summary>
			/// Checks whether column UsedElecWaterId is added in select statement 
			/// </summary>
			public bool IsSelectUsedElecWaterId { 
				get { return IsSelect("COL6838655036"); } 
				set { SetSelect("COL6838655036", value); } 
			}

			/// <summary>
			/// Checks whether column DateFrom is added in select statement 
			/// </summary>
			public bool IsSelectDateFrom { 
				get { return IsSelect("COL6838655039"); } 
				set { SetSelect("COL6838655039", value); } 
			}

			/// <summary>
			/// Checks whether column SumVND is added in select statement 
			/// </summary>
			public bool IsSelectSumVND { 
				get { return IsSelect("COL68386550320"); } 
				set { SetSelect("COL68386550320", value); } 
			}

			/// <summary>
			/// Checks whether column DelFlag is added in select statement 
			/// </summary>
			public bool IsSelectDelFlag { 
				get { return IsSelect("COL68386550328"); } 
				set { SetSelect("COL68386550328", value); } 
			}

			/// <summary>
			/// Checks whether column Mount is added in select statement 
			/// </summary>
			public bool IsSelectMount { 
				get { return IsSelect("COL68386550313"); } 
				set { SetSelect("COL68386550313", value); } 
			}



	}
}