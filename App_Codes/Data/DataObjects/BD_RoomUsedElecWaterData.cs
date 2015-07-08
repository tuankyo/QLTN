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
	public class BD_RoomUsedElecWaterData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ930102354";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of BD_RoomUsedElecWater 
			/// </summary>
			public BD_RoomUsedElecWaterData(string objectID): base(objectID) {}  

			public BD_RoomUsedElecWaterData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field YearMonth 
			/// </summary>
			public string YearMonth { 
				get { return GetValue("COL9301023544"); } 
				set { SetValue("COL9301023544", value); } 
			}

			/// <summary>
			/// Gets field Comment 
			/// </summary>
			public string Comment { 
				get { return GetValue("COL9301023547"); } 
				set { SetValue("COL9301023547", value); } 
			}

			/// <summary>
			/// Gets field NewIndex 
			/// </summary>
			public string NewIndex { 
				get { return GetValue("COL9301023546"); } 
				set { SetValue("COL9301023546", value); } 
			}

			/// <summary>
			/// Gets field CreatedBy 
			/// </summary>
			public string CreatedBy { 
				get { return GetValue("COL9301023549"); } 
				set { SetValue("COL9301023549", value); } 
			}

			/// <summary>
			/// Gets field WaterPricePercent 
			/// </summary>
			public string WaterPricePercent { 
				get { return GetValue("COL93010235418"); } 
				set { SetValue("COL93010235418", value); } 
			}

			/// <summary>
			/// Gets field CustomerId 
			/// </summary>
			public string CustomerId { 
				get { return GetValue("COL93010235415"); } 
				set { SetValue("COL93010235415", value); } 
			}

			/// <summary>
			/// Gets field Modified 
			/// </summary>
			public string Modified { 
				get { return GetValue("COL93010235410"); } 
				set { SetValue("COL93010235410", value); } 
			}

			/// <summary>
			/// Gets field OtherFee01 
			/// </summary>
			public string OtherFee01 { 
				get { return GetValue("COL93010235420"); } 
				set { SetValue("COL93010235420", value); } 
			}

			/// <summary>
			/// Gets field TarrifsType 
			/// </summary>
			public string TarrifsType { 
				get { return GetValue("COL93010235416"); } 
				set { SetValue("COL93010235416", value); } 
			}

			/// <summary>
			/// Gets field DateFrom 
			/// </summary>
			public string DateFrom { 
				get { return GetValue("COL93010235413"); } 
				set { SetValue("COL93010235413", value); } 
			}

			/// <summary>
			/// Gets field TariffsOfWaterId 
			/// </summary>
			public string TariffsOfWaterId { 
				get { return GetValue("COL93010235423"); } 
				set { SetValue("COL93010235423", value); } 
			}

			/// <summary>
			/// Gets field DateTo 
			/// </summary>
			public string DateTo { 
				get { return GetValue("COL93010235414"); } 
				set { SetValue("COL93010235414", value); } 
			}

			/// <summary>
			/// Gets field VAT 
			/// </summary>
			public string VAT { 
				get { return GetValue("COL93010235419"); } 
				set { SetValue("COL93010235419", value); } 
			}

			/// <summary>
			/// Gets field Created 
			/// </summary>
			public string Created { 
				get { return GetValue("COL9301023548"); } 
				set { SetValue("COL9301023548", value); } 
			}

			/// <summary>
			/// Gets field ModifiedBy 
			/// </summary>
			public string ModifiedBy { 
				get { return GetValue("COL93010235411"); } 
				set { SetValue("COL93010235411", value); } 
			}

			/// <summary>
			/// Gets field OtherFee02 
			/// </summary>
			public string OtherFee02 { 
				get { return GetValue("COL93010235421"); } 
				set { SetValue("COL93010235421", value); } 
			}

			/// <summary>
			/// Gets field ElecPricePercent 
			/// </summary>
			public string ElecPricePercent { 
				get { return GetValue("COL93010235417"); } 
				set { SetValue("COL93010235417", value); } 
			}

			/// <summary>
			/// Gets field DelFlag 
			/// </summary>
			public string DelFlag { 
				get { return GetValue("COL93010235412"); } 
				set { SetValue("COL93010235412", value); } 
			}

			/// <summary>
			/// Gets field TariffsOfElecId 
			/// </summary>
			public string TariffsOfElecId { 
				get { return GetValue("COL93010235422"); } 
				set { SetValue("COL93010235422", value); } 
			}

			/// <summary>
			/// Gets field id 
			/// </summary>
			public string id { 
				get { return GetValue("COL9301023541"); } 
				set { SetValue("COL9301023541", value); } 
			}

			/// <summary>
			/// Gets field RoomId 
			/// </summary>
			public string RoomId { 
				get { return GetValue("COL9301023543"); } 
				set { SetValue("COL9301023543", value); } 
			}

			/// <summary>
			/// Gets field BuildingId 
			/// </summary>
			public string BuildingId { 
				get { return GetValue("COL9301023542"); } 
				set { SetValue("COL9301023542", value); } 
			}

			/// <summary>
			/// Gets field OldIndex 
			/// </summary>
			public string OldIndex { 
				get { return GetValue("COL9301023545"); } 
				set { SetValue("COL9301023545", value); } 
			}


			/// <summary>
			/// Gets YearMonth attribute data 
			/// </summary>
			public AttributeData GetYearMonthAttributeData() { 
				return GetAttributeData("COL9301023544"); 
			}

			/// <summary>
			/// Gets Comment attribute data 
			/// </summary>
			public AttributeData GetCommentAttributeData() { 
				return GetAttributeData("COL9301023547"); 
			}

			/// <summary>
			/// Gets NewIndex attribute data 
			/// </summary>
			public AttributeData GetNewIndexAttributeData() { 
				return GetAttributeData("COL9301023546"); 
			}

			/// <summary>
			/// Gets CreatedBy attribute data 
			/// </summary>
			public AttributeData GetCreatedByAttributeData() { 
				return GetAttributeData("COL9301023549"); 
			}

			/// <summary>
			/// Gets WaterPricePercent attribute data 
			/// </summary>
			public AttributeData GetWaterPricePercentAttributeData() { 
				return GetAttributeData("COL93010235418"); 
			}

			/// <summary>
			/// Gets CustomerId attribute data 
			/// </summary>
			public AttributeData GetCustomerIdAttributeData() { 
				return GetAttributeData("COL93010235415"); 
			}

			/// <summary>
			/// Gets Modified attribute data 
			/// </summary>
			public AttributeData GetModifiedAttributeData() { 
				return GetAttributeData("COL93010235410"); 
			}

			/// <summary>
			/// Gets OtherFee01 attribute data 
			/// </summary>
			public AttributeData GetOtherFee01AttributeData() { 
				return GetAttributeData("COL93010235420"); 
			}

			/// <summary>
			/// Gets TarrifsType attribute data 
			/// </summary>
			public AttributeData GetTarrifsTypeAttributeData() { 
				return GetAttributeData("COL93010235416"); 
			}

			/// <summary>
			/// Gets DateFrom attribute data 
			/// </summary>
			public AttributeData GetDateFromAttributeData() { 
				return GetAttributeData("COL93010235413"); 
			}

			/// <summary>
			/// Gets TariffsOfWaterId attribute data 
			/// </summary>
			public AttributeData GetTariffsOfWaterIdAttributeData() { 
				return GetAttributeData("COL93010235423"); 
			}

			/// <summary>
			/// Gets DateTo attribute data 
			/// </summary>
			public AttributeData GetDateToAttributeData() { 
				return GetAttributeData("COL93010235414"); 
			}

			/// <summary>
			/// Gets VAT attribute data 
			/// </summary>
			public AttributeData GetVATAttributeData() { 
				return GetAttributeData("COL93010235419"); 
			}

			/// <summary>
			/// Gets Created attribute data 
			/// </summary>
			public AttributeData GetCreatedAttributeData() { 
				return GetAttributeData("COL9301023548"); 
			}

			/// <summary>
			/// Gets ModifiedBy attribute data 
			/// </summary>
			public AttributeData GetModifiedByAttributeData() { 
				return GetAttributeData("COL93010235411"); 
			}

			/// <summary>
			/// Gets OtherFee02 attribute data 
			/// </summary>
			public AttributeData GetOtherFee02AttributeData() { 
				return GetAttributeData("COL93010235421"); 
			}

			/// <summary>
			/// Gets ElecPricePercent attribute data 
			/// </summary>
			public AttributeData GetElecPricePercentAttributeData() { 
				return GetAttributeData("COL93010235417"); 
			}

			/// <summary>
			/// Gets DelFlag attribute data 
			/// </summary>
			public AttributeData GetDelFlagAttributeData() { 
				return GetAttributeData("COL93010235412"); 
			}

			/// <summary>
			/// Gets TariffsOfElecId attribute data 
			/// </summary>
			public AttributeData GetTariffsOfElecIdAttributeData() { 
				return GetAttributeData("COL93010235422"); 
			}

			/// <summary>
			/// Gets id attribute data 
			/// </summary>
			public AttributeData GetidAttributeData() { 
				return GetAttributeData("COL9301023541"); 
			}

			/// <summary>
			/// Gets RoomId attribute data 
			/// </summary>
			public AttributeData GetRoomIdAttributeData() { 
				return GetAttributeData("COL9301023543"); 
			}

			/// <summary>
			/// Gets BuildingId attribute data 
			/// </summary>
			public AttributeData GetBuildingIdAttributeData() { 
				return GetAttributeData("COL9301023542"); 
			}

			/// <summary>
			/// Gets OldIndex attribute data 
			/// </summary>
			public AttributeData GetOldIndexAttributeData() { 
				return GetAttributeData("COL9301023545"); 
			}


			/// <summary>
			/// Gets column YearMonth with alias  
			/// </summary>
			public string ColYearMonth { 
				get { return GetColumnName("COL9301023544"); } 
			}

			/// <summary>
			/// Gets column Comment with alias  
			/// </summary>
			public string ColComment { 
				get { return GetColumnName("COL9301023547"); } 
			}

			/// <summary>
			/// Gets column NewIndex with alias  
			/// </summary>
			public string ColNewIndex { 
				get { return GetColumnName("COL9301023546"); } 
			}

			/// <summary>
			/// Gets column CreatedBy with alias  
			/// </summary>
			public string ColCreatedBy { 
				get { return GetColumnName("COL9301023549"); } 
			}

			/// <summary>
			/// Gets column WaterPricePercent with alias  
			/// </summary>
			public string ColWaterPricePercent { 
				get { return GetColumnName("COL93010235418"); } 
			}

			/// <summary>
			/// Gets column CustomerId with alias  
			/// </summary>
			public string ColCustomerId { 
				get { return GetColumnName("COL93010235415"); } 
			}

			/// <summary>
			/// Gets column Modified with alias  
			/// </summary>
			public string ColModified { 
				get { return GetColumnName("COL93010235410"); } 
			}

			/// <summary>
			/// Gets column OtherFee01 with alias  
			/// </summary>
			public string ColOtherFee01 { 
				get { return GetColumnName("COL93010235420"); } 
			}

			/// <summary>
			/// Gets column TarrifsType with alias  
			/// </summary>
			public string ColTarrifsType { 
				get { return GetColumnName("COL93010235416"); } 
			}

			/// <summary>
			/// Gets column DateFrom with alias  
			/// </summary>
			public string ColDateFrom { 
				get { return GetColumnName("COL93010235413"); } 
			}

			/// <summary>
			/// Gets column TariffsOfWaterId with alias  
			/// </summary>
			public string ColTariffsOfWaterId { 
				get { return GetColumnName("COL93010235423"); } 
			}

			/// <summary>
			/// Gets column DateTo with alias  
			/// </summary>
			public string ColDateTo { 
				get { return GetColumnName("COL93010235414"); } 
			}

			/// <summary>
			/// Gets column VAT with alias  
			/// </summary>
			public string ColVAT { 
				get { return GetColumnName("COL93010235419"); } 
			}

			/// <summary>
			/// Gets column Created with alias  
			/// </summary>
			public string ColCreated { 
				get { return GetColumnName("COL9301023548"); } 
			}

			/// <summary>
			/// Gets column ModifiedBy with alias  
			/// </summary>
			public string ColModifiedBy { 
				get { return GetColumnName("COL93010235411"); } 
			}

			/// <summary>
			/// Gets column OtherFee02 with alias  
			/// </summary>
			public string ColOtherFee02 { 
				get { return GetColumnName("COL93010235421"); } 
			}

			/// <summary>
			/// Gets column ElecPricePercent with alias  
			/// </summary>
			public string ColElecPricePercent { 
				get { return GetColumnName("COL93010235417"); } 
			}

			/// <summary>
			/// Gets column DelFlag with alias  
			/// </summary>
			public string ColDelFlag { 
				get { return GetColumnName("COL93010235412"); } 
			}

			/// <summary>
			/// Gets column TariffsOfElecId with alias  
			/// </summary>
			public string ColTariffsOfElecId { 
				get { return GetColumnName("COL93010235422"); } 
			}

			/// <summary>
			/// Gets column id with alias  
			/// </summary>
			public string Colid { 
				get { return GetColumnName("COL9301023541"); } 
			}

			/// <summary>
			/// Gets column RoomId with alias  
			/// </summary>
			public string ColRoomId { 
				get { return GetColumnName("COL9301023543"); } 
			}

			/// <summary>
			/// Gets column BuildingId with alias  
			/// </summary>
			public string ColBuildingId { 
				get { return GetColumnName("COL9301023542"); } 
			}

			/// <summary>
			/// Gets column OldIndex with alias  
			/// </summary>
			public string ColOldIndex { 
				get { return GetColumnName("COL9301023545"); } 
			}


			/// <summary>
			/// Checks whether column YearMonth is added in select statement 
			/// </summary>
			public bool IsSelectYearMonth { 
				get { return IsSelect("COL9301023544"); } 
				set { SetSelect("COL9301023544", value); } 
			}

			/// <summary>
			/// Checks whether column Comment is added in select statement 
			/// </summary>
			public bool IsSelectComment { 
				get { return IsSelect("COL9301023547"); } 
				set { SetSelect("COL9301023547", value); } 
			}

			/// <summary>
			/// Checks whether column NewIndex is added in select statement 
			/// </summary>
			public bool IsSelectNewIndex { 
				get { return IsSelect("COL9301023546"); } 
				set { SetSelect("COL9301023546", value); } 
			}

			/// <summary>
			/// Checks whether column CreatedBy is added in select statement 
			/// </summary>
			public bool IsSelectCreatedBy { 
				get { return IsSelect("COL9301023549"); } 
				set { SetSelect("COL9301023549", value); } 
			}

			/// <summary>
			/// Checks whether column WaterPricePercent is added in select statement 
			/// </summary>
			public bool IsSelectWaterPricePercent { 
				get { return IsSelect("COL93010235418"); } 
				set { SetSelect("COL93010235418", value); } 
			}

			/// <summary>
			/// Checks whether column CustomerId is added in select statement 
			/// </summary>
			public bool IsSelectCustomerId { 
				get { return IsSelect("COL93010235415"); } 
				set { SetSelect("COL93010235415", value); } 
			}

			/// <summary>
			/// Checks whether column Modified is added in select statement 
			/// </summary>
			public bool IsSelectModified { 
				get { return IsSelect("COL93010235410"); } 
				set { SetSelect("COL93010235410", value); } 
			}

			/// <summary>
			/// Checks whether column OtherFee01 is added in select statement 
			/// </summary>
			public bool IsSelectOtherFee01 { 
				get { return IsSelect("COL93010235420"); } 
				set { SetSelect("COL93010235420", value); } 
			}

			/// <summary>
			/// Checks whether column TarrifsType is added in select statement 
			/// </summary>
			public bool IsSelectTarrifsType { 
				get { return IsSelect("COL93010235416"); } 
				set { SetSelect("COL93010235416", value); } 
			}

			/// <summary>
			/// Checks whether column DateFrom is added in select statement 
			/// </summary>
			public bool IsSelectDateFrom { 
				get { return IsSelect("COL93010235413"); } 
				set { SetSelect("COL93010235413", value); } 
			}

			/// <summary>
			/// Checks whether column TariffsOfWaterId is added in select statement 
			/// </summary>
			public bool IsSelectTariffsOfWaterId { 
				get { return IsSelect("COL93010235423"); } 
				set { SetSelect("COL93010235423", value); } 
			}

			/// <summary>
			/// Checks whether column DateTo is added in select statement 
			/// </summary>
			public bool IsSelectDateTo { 
				get { return IsSelect("COL93010235414"); } 
				set { SetSelect("COL93010235414", value); } 
			}

			/// <summary>
			/// Checks whether column VAT is added in select statement 
			/// </summary>
			public bool IsSelectVAT { 
				get { return IsSelect("COL93010235419"); } 
				set { SetSelect("COL93010235419", value); } 
			}

			/// <summary>
			/// Checks whether column Created is added in select statement 
			/// </summary>
			public bool IsSelectCreated { 
				get { return IsSelect("COL9301023548"); } 
				set { SetSelect("COL9301023548", value); } 
			}

			/// <summary>
			/// Checks whether column ModifiedBy is added in select statement 
			/// </summary>
			public bool IsSelectModifiedBy { 
				get { return IsSelect("COL93010235411"); } 
				set { SetSelect("COL93010235411", value); } 
			}

			/// <summary>
			/// Checks whether column OtherFee02 is added in select statement 
			/// </summary>
			public bool IsSelectOtherFee02 { 
				get { return IsSelect("COL93010235421"); } 
				set { SetSelect("COL93010235421", value); } 
			}

			/// <summary>
			/// Checks whether column ElecPricePercent is added in select statement 
			/// </summary>
			public bool IsSelectElecPricePercent { 
				get { return IsSelect("COL93010235417"); } 
				set { SetSelect("COL93010235417", value); } 
			}

			/// <summary>
			/// Checks whether column DelFlag is added in select statement 
			/// </summary>
			public bool IsSelectDelFlag { 
				get { return IsSelect("COL93010235412"); } 
				set { SetSelect("COL93010235412", value); } 
			}

			/// <summary>
			/// Checks whether column TariffsOfElecId is added in select statement 
			/// </summary>
			public bool IsSelectTariffsOfElecId { 
				get { return IsSelect("COL93010235422"); } 
				set { SetSelect("COL93010235422", value); } 
			}

			/// <summary>
			/// Checks whether column id is added in select statement 
			/// </summary>
			public bool IsSelectid { 
				get { return IsSelect("COL9301023541"); } 
				set { SetSelect("COL9301023541", value); } 
			}

			/// <summary>
			/// Checks whether column RoomId is added in select statement 
			/// </summary>
			public bool IsSelectRoomId { 
				get { return IsSelect("COL9301023543"); } 
				set { SetSelect("COL9301023543", value); } 
			}

			/// <summary>
			/// Checks whether column BuildingId is added in select statement 
			/// </summary>
			public bool IsSelectBuildingId { 
				get { return IsSelect("COL9301023542"); } 
				set { SetSelect("COL9301023542", value); } 
			}

			/// <summary>
			/// Checks whether column OldIndex is added in select statement 
			/// </summary>
			public bool IsSelectOldIndex { 
				get { return IsSelect("COL9301023545"); } 
				set { SetSelect("COL9301023545", value); } 
			}



	}
}