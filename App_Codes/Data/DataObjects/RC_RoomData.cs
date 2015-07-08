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
	public class RC_RoomData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ1195867327";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of RC_Room 
			/// </summary>
			public RC_RoomData(string objectID): base(objectID) {}  

			public RC_RoomData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field ManagerType 
			/// </summary>
			public string ManagerType { 
				get { return GetValue("COL119586732732"); } 
				set { SetValue("COL119586732732", value); } 
			}

			/// <summary>
			/// Gets field FitoutWater 
			/// </summary>
			public string FitoutWater { 
				get { return GetValue("COL119586732736"); } 
				set { SetValue("COL119586732736", value); } 
			}

			/// <summary>
			/// Gets field WaterPricePercent 
			/// </summary>
			public string WaterPricePercent { 
				get { return GetValue("COL119586732725"); } 
				set { SetValue("COL119586732725", value); } 
			}

			/// <summary>
			/// Gets field FitoutEnd 
			/// </summary>
			public string FitoutEnd { 
				get { return GetValue("COL119586732734"); } 
				set { SetValue("COL119586732734", value); } 
			}

			/// <summary>
			/// Gets field DelFlag 
			/// </summary>
			public string DelFlag { 
				get { return GetValue("COL119586732720"); } 
				set { SetValue("COL119586732720", value); } 
			}

			/// <summary>
			/// Gets field FitoutElec 
			/// </summary>
			public string FitoutElec { 
				get { return GetValue("COL119586732737"); } 
				set { SetValue("COL119586732737", value); } 
			}

			/// <summary>
			/// Gets field FitoutExtraTime 
			/// </summary>
			public string FitoutExtraTime { 
				get { return GetValue("COL119586732740"); } 
				set { SetValue("COL119586732740", value); } 
			}

			/// <summary>
			/// Gets field CreatedBy 
			/// </summary>
			public string CreatedBy { 
				get { return GetValue("COL119586732717"); } 
				set { SetValue("COL119586732717", value); } 
			}

			/// <summary>
			/// Gets field HourExtraTimePriceVND 
			/// </summary>
			public string HourExtraTimePriceVND { 
				get { return GetValue("COL119586732721"); } 
				set { SetValue("COL119586732721", value); } 
			}

			/// <summary>
			/// Gets field MonthRentPriceVND 
			/// </summary>
			public string MonthRentPriceVND { 
				get { return GetValue("COL11958673279"); } 
				set { SetValue("COL11958673279", value); } 
			}

			/// <summary>
			/// Gets field FitoutParking 
			/// </summary>
			public string FitoutParking { 
				get { return GetValue("COL119586732738"); } 
				set { SetValue("COL119586732738", value); } 
			}

			/// <summary>
			/// Gets field Modified 
			/// </summary>
			public string Modified { 
				get { return GetValue("COL119586732718"); } 
				set { SetValue("COL119586732718", value); } 
			}

			/// <summary>
			/// Gets field RoomId 
			/// </summary>
			public string RoomId { 
				get { return GetValue("COL11958673273"); } 
				set { SetValue("COL11958673273", value); } 
			}

			/// <summary>
			/// Gets field BeginContract 
			/// </summary>
			public string BeginContract { 
				get { return GetValue("COL119586732713"); } 
				set { SetValue("COL119586732713", value); } 
			}

			/// <summary>
			/// Gets field id 
			/// </summary>
			public string id { 
				get { return GetValue("COL11958673271"); } 
				set { SetValue("COL11958673271", value); } 
			}

			/// <summary>
			/// Gets field TariffsOfElecId 
			/// </summary>
			public string TariffsOfElecId { 
				get { return GetValue("COL11958673277"); } 
				set { SetValue("COL11958673277", value); } 
			}

			/// <summary>
			/// Gets field FitoutService 
			/// </summary>
			public string FitoutService { 
				get { return GetValue("COL119586732739"); } 
				set { SetValue("COL119586732739", value); } 
			}

			/// <summary>
			/// Gets field OtherFee01 
			/// </summary>
			public string OtherFee01 { 
				get { return GetValue("COL11958673275"); } 
				set { SetValue("COL11958673275", value); } 
			}

			/// <summary>
			/// Gets field ModifiedBy 
			/// </summary>
			public string ModifiedBy { 
				get { return GetValue("COL119586732719"); } 
				set { SetValue("COL119586732719", value); } 
			}

			/// <summary>
			/// Gets field EndContract 
			/// </summary>
			public string EndContract { 
				get { return GetValue("COL119586732714"); } 
				set { SetValue("COL119586732714", value); } 
			}

			/// <summary>
			/// Gets field Comment 
			/// </summary>
			public string Comment { 
				get { return GetValue("COL119586732715"); } 
				set { SetValue("COL119586732715", value); } 
			}

			/// <summary>
			/// Gets field RentArea 
			/// </summary>
			public string RentArea { 
				get { return GetValue("COL119586732726"); } 
				set { SetValue("COL119586732726", value); } 
			}

			/// <summary>
			/// Gets field FitoutBegin 
			/// </summary>
			public string FitoutBegin { 
				get { return GetValue("COL119586732733"); } 
				set { SetValue("COL119586732733", value); } 
			}

			/// <summary>
			/// Gets field MonthExtraTimePriceUsd 
			/// </summary>
			public string MonthExtraTimePriceUsd { 
				get { return GetValue("COL119586732730"); } 
				set { SetValue("COL119586732730", value); } 
			}

			/// <summary>
			/// Gets field MonthRentPriceUSD 
			/// </summary>
			public string MonthRentPriceUSD { 
				get { return GetValue("COL119586732710"); } 
				set { SetValue("COL119586732710", value); } 
			}

			/// <summary>
			/// Gets field FitoutManager 
			/// </summary>
			public string FitoutManager { 
				get { return GetValue("COL119586732735"); } 
				set { SetValue("COL119586732735", value); } 
			}

			/// <summary>
			/// Gets field ExtraTimeMinPriceVND 
			/// </summary>
			public string ExtraTimeMinPriceVND { 
				get { return GetValue("COL119586732727"); } 
				set { SetValue("COL119586732727", value); } 
			}

			/// <summary>
			/// Gets field Created 
			/// </summary>
			public string Created { 
				get { return GetValue("COL119586732716"); } 
				set { SetValue("COL119586732716", value); } 
			}

			/// <summary>
			/// Gets field HourExtraTimePriceUsd 
			/// </summary>
			public string HourExtraTimePriceUsd { 
				get { return GetValue("COL119586732722"); } 
				set { SetValue("COL119586732722", value); } 
			}

			/// <summary>
			/// Gets field MonthManagerPriceVND 
			/// </summary>
			public string MonthManagerPriceVND { 
				get { return GetValue("COL119586732711"); } 
				set { SetValue("COL119586732711", value); } 
			}

			/// <summary>
			/// Gets field MonthManagerPriceUSD 
			/// </summary>
			public string MonthManagerPriceUSD { 
				get { return GetValue("COL119586732712"); } 
				set { SetValue("COL119586732712", value); } 
			}

			/// <summary>
			/// Gets field TariffsOfWaterId 
			/// </summary>
			public string TariffsOfWaterId { 
				get { return GetValue("COL11958673278"); } 
				set { SetValue("COL11958673278", value); } 
			}

			/// <summary>
			/// Gets field ExtraTimeMinPriceUSD 
			/// </summary>
			public string ExtraTimeMinPriceUSD { 
				get { return GetValue("COL119586732728"); } 
				set { SetValue("COL119586732728", value); } 
			}

			/// <summary>
			/// Gets field RentType 
			/// </summary>
			public string RentType { 
				get { return GetValue("COL119586732723"); } 
				set { SetValue("COL119586732723", value); } 
			}

			/// <summary>
			/// Gets field ContractId 
			/// </summary>
			public string ContractId { 
				get { return GetValue("COL11958673272"); } 
				set { SetValue("COL11958673272", value); } 
			}

			/// <summary>
			/// Gets field ExtratimeType 
			/// </summary>
			public string ExtratimeType { 
				get { return GetValue("COL119586732731"); } 
				set { SetValue("COL119586732731", value); } 
			}

			/// <summary>
			/// Gets field OtherFee02 
			/// </summary>
			public string OtherFee02 { 
				get { return GetValue("COL11958673276"); } 
				set { SetValue("COL11958673276", value); } 
			}

			/// <summary>
			/// Gets field MonthExtraTimePriceVND 
			/// </summary>
			public string MonthExtraTimePriceVND { 
				get { return GetValue("COL119586732729"); } 
				set { SetValue("COL119586732729", value); } 
			}

			/// <summary>
			/// Gets field VAT 
			/// </summary>
			public string VAT { 
				get { return GetValue("COL11958673274"); } 
				set { SetValue("COL11958673274", value); } 
			}

			/// <summary>
			/// Gets field ElecPricePercent 
			/// </summary>
			public string ElecPricePercent { 
				get { return GetValue("COL119586732724"); } 
				set { SetValue("COL119586732724", value); } 
			}


			/// <summary>
			/// Gets ManagerType attribute data 
			/// </summary>
			public AttributeData GetManagerTypeAttributeData() { 
				return GetAttributeData("COL119586732732"); 
			}

			/// <summary>
			/// Gets FitoutWater attribute data 
			/// </summary>
			public AttributeData GetFitoutWaterAttributeData() { 
				return GetAttributeData("COL119586732736"); 
			}

			/// <summary>
			/// Gets WaterPricePercent attribute data 
			/// </summary>
			public AttributeData GetWaterPricePercentAttributeData() { 
				return GetAttributeData("COL119586732725"); 
			}

			/// <summary>
			/// Gets FitoutEnd attribute data 
			/// </summary>
			public AttributeData GetFitoutEndAttributeData() { 
				return GetAttributeData("COL119586732734"); 
			}

			/// <summary>
			/// Gets DelFlag attribute data 
			/// </summary>
			public AttributeData GetDelFlagAttributeData() { 
				return GetAttributeData("COL119586732720"); 
			}

			/// <summary>
			/// Gets FitoutElec attribute data 
			/// </summary>
			public AttributeData GetFitoutElecAttributeData() { 
				return GetAttributeData("COL119586732737"); 
			}

			/// <summary>
			/// Gets FitoutExtraTime attribute data 
			/// </summary>
			public AttributeData GetFitoutExtraTimeAttributeData() { 
				return GetAttributeData("COL119586732740"); 
			}

			/// <summary>
			/// Gets CreatedBy attribute data 
			/// </summary>
			public AttributeData GetCreatedByAttributeData() { 
				return GetAttributeData("COL119586732717"); 
			}

			/// <summary>
			/// Gets HourExtraTimePriceVND attribute data 
			/// </summary>
			public AttributeData GetHourExtraTimePriceVNDAttributeData() { 
				return GetAttributeData("COL119586732721"); 
			}

			/// <summary>
			/// Gets MonthRentPriceVND attribute data 
			/// </summary>
			public AttributeData GetMonthRentPriceVNDAttributeData() { 
				return GetAttributeData("COL11958673279"); 
			}

			/// <summary>
			/// Gets FitoutParking attribute data 
			/// </summary>
			public AttributeData GetFitoutParkingAttributeData() { 
				return GetAttributeData("COL119586732738"); 
			}

			/// <summary>
			/// Gets Modified attribute data 
			/// </summary>
			public AttributeData GetModifiedAttributeData() { 
				return GetAttributeData("COL119586732718"); 
			}

			/// <summary>
			/// Gets RoomId attribute data 
			/// </summary>
			public AttributeData GetRoomIdAttributeData() { 
				return GetAttributeData("COL11958673273"); 
			}

			/// <summary>
			/// Gets BeginContract attribute data 
			/// </summary>
			public AttributeData GetBeginContractAttributeData() { 
				return GetAttributeData("COL119586732713"); 
			}

			/// <summary>
			/// Gets id attribute data 
			/// </summary>
			public AttributeData GetidAttributeData() { 
				return GetAttributeData("COL11958673271"); 
			}

			/// <summary>
			/// Gets TariffsOfElecId attribute data 
			/// </summary>
			public AttributeData GetTariffsOfElecIdAttributeData() { 
				return GetAttributeData("COL11958673277"); 
			}

			/// <summary>
			/// Gets FitoutService attribute data 
			/// </summary>
			public AttributeData GetFitoutServiceAttributeData() { 
				return GetAttributeData("COL119586732739"); 
			}

			/// <summary>
			/// Gets OtherFee01 attribute data 
			/// </summary>
			public AttributeData GetOtherFee01AttributeData() { 
				return GetAttributeData("COL11958673275"); 
			}

			/// <summary>
			/// Gets ModifiedBy attribute data 
			/// </summary>
			public AttributeData GetModifiedByAttributeData() { 
				return GetAttributeData("COL119586732719"); 
			}

			/// <summary>
			/// Gets EndContract attribute data 
			/// </summary>
			public AttributeData GetEndContractAttributeData() { 
				return GetAttributeData("COL119586732714"); 
			}

			/// <summary>
			/// Gets Comment attribute data 
			/// </summary>
			public AttributeData GetCommentAttributeData() { 
				return GetAttributeData("COL119586732715"); 
			}

			/// <summary>
			/// Gets RentArea attribute data 
			/// </summary>
			public AttributeData GetRentAreaAttributeData() { 
				return GetAttributeData("COL119586732726"); 
			}

			/// <summary>
			/// Gets FitoutBegin attribute data 
			/// </summary>
			public AttributeData GetFitoutBeginAttributeData() { 
				return GetAttributeData("COL119586732733"); 
			}

			/// <summary>
			/// Gets MonthExtraTimePriceUsd attribute data 
			/// </summary>
			public AttributeData GetMonthExtraTimePriceUsdAttributeData() { 
				return GetAttributeData("COL119586732730"); 
			}

			/// <summary>
			/// Gets MonthRentPriceUSD attribute data 
			/// </summary>
			public AttributeData GetMonthRentPriceUSDAttributeData() { 
				return GetAttributeData("COL119586732710"); 
			}

			/// <summary>
			/// Gets FitoutManager attribute data 
			/// </summary>
			public AttributeData GetFitoutManagerAttributeData() { 
				return GetAttributeData("COL119586732735"); 
			}

			/// <summary>
			/// Gets ExtraTimeMinPriceVND attribute data 
			/// </summary>
			public AttributeData GetExtraTimeMinPriceVNDAttributeData() { 
				return GetAttributeData("COL119586732727"); 
			}

			/// <summary>
			/// Gets Created attribute data 
			/// </summary>
			public AttributeData GetCreatedAttributeData() { 
				return GetAttributeData("COL119586732716"); 
			}

			/// <summary>
			/// Gets HourExtraTimePriceUsd attribute data 
			/// </summary>
			public AttributeData GetHourExtraTimePriceUsdAttributeData() { 
				return GetAttributeData("COL119586732722"); 
			}

			/// <summary>
			/// Gets MonthManagerPriceVND attribute data 
			/// </summary>
			public AttributeData GetMonthManagerPriceVNDAttributeData() { 
				return GetAttributeData("COL119586732711"); 
			}

			/// <summary>
			/// Gets MonthManagerPriceUSD attribute data 
			/// </summary>
			public AttributeData GetMonthManagerPriceUSDAttributeData() { 
				return GetAttributeData("COL119586732712"); 
			}

			/// <summary>
			/// Gets TariffsOfWaterId attribute data 
			/// </summary>
			public AttributeData GetTariffsOfWaterIdAttributeData() { 
				return GetAttributeData("COL11958673278"); 
			}

			/// <summary>
			/// Gets ExtraTimeMinPriceUSD attribute data 
			/// </summary>
			public AttributeData GetExtraTimeMinPriceUSDAttributeData() { 
				return GetAttributeData("COL119586732728"); 
			}

			/// <summary>
			/// Gets RentType attribute data 
			/// </summary>
			public AttributeData GetRentTypeAttributeData() { 
				return GetAttributeData("COL119586732723"); 
			}

			/// <summary>
			/// Gets ContractId attribute data 
			/// </summary>
			public AttributeData GetContractIdAttributeData() { 
				return GetAttributeData("COL11958673272"); 
			}

			/// <summary>
			/// Gets ExtratimeType attribute data 
			/// </summary>
			public AttributeData GetExtratimeTypeAttributeData() { 
				return GetAttributeData("COL119586732731"); 
			}

			/// <summary>
			/// Gets OtherFee02 attribute data 
			/// </summary>
			public AttributeData GetOtherFee02AttributeData() { 
				return GetAttributeData("COL11958673276"); 
			}

			/// <summary>
			/// Gets MonthExtraTimePriceVND attribute data 
			/// </summary>
			public AttributeData GetMonthExtraTimePriceVNDAttributeData() { 
				return GetAttributeData("COL119586732729"); 
			}

			/// <summary>
			/// Gets VAT attribute data 
			/// </summary>
			public AttributeData GetVATAttributeData() { 
				return GetAttributeData("COL11958673274"); 
			}

			/// <summary>
			/// Gets ElecPricePercent attribute data 
			/// </summary>
			public AttributeData GetElecPricePercentAttributeData() { 
				return GetAttributeData("COL119586732724"); 
			}


			/// <summary>
			/// Gets column ManagerType with alias  
			/// </summary>
			public string ColManagerType { 
				get { return GetColumnName("COL119586732732"); } 
			}

			/// <summary>
			/// Gets column FitoutWater with alias  
			/// </summary>
			public string ColFitoutWater { 
				get { return GetColumnName("COL119586732736"); } 
			}

			/// <summary>
			/// Gets column WaterPricePercent with alias  
			/// </summary>
			public string ColWaterPricePercent { 
				get { return GetColumnName("COL119586732725"); } 
			}

			/// <summary>
			/// Gets column FitoutEnd with alias  
			/// </summary>
			public string ColFitoutEnd { 
				get { return GetColumnName("COL119586732734"); } 
			}

			/// <summary>
			/// Gets column DelFlag with alias  
			/// </summary>
			public string ColDelFlag { 
				get { return GetColumnName("COL119586732720"); } 
			}

			/// <summary>
			/// Gets column FitoutElec with alias  
			/// </summary>
			public string ColFitoutElec { 
				get { return GetColumnName("COL119586732737"); } 
			}

			/// <summary>
			/// Gets column FitoutExtraTime with alias  
			/// </summary>
			public string ColFitoutExtraTime { 
				get { return GetColumnName("COL119586732740"); } 
			}

			/// <summary>
			/// Gets column CreatedBy with alias  
			/// </summary>
			public string ColCreatedBy { 
				get { return GetColumnName("COL119586732717"); } 
			}

			/// <summary>
			/// Gets column HourExtraTimePriceVND with alias  
			/// </summary>
			public string ColHourExtraTimePriceVND { 
				get { return GetColumnName("COL119586732721"); } 
			}

			/// <summary>
			/// Gets column MonthRentPriceVND with alias  
			/// </summary>
			public string ColMonthRentPriceVND { 
				get { return GetColumnName("COL11958673279"); } 
			}

			/// <summary>
			/// Gets column FitoutParking with alias  
			/// </summary>
			public string ColFitoutParking { 
				get { return GetColumnName("COL119586732738"); } 
			}

			/// <summary>
			/// Gets column Modified with alias  
			/// </summary>
			public string ColModified { 
				get { return GetColumnName("COL119586732718"); } 
			}

			/// <summary>
			/// Gets column RoomId with alias  
			/// </summary>
			public string ColRoomId { 
				get { return GetColumnName("COL11958673273"); } 
			}

			/// <summary>
			/// Gets column BeginContract with alias  
			/// </summary>
			public string ColBeginContract { 
				get { return GetColumnName("COL119586732713"); } 
			}

			/// <summary>
			/// Gets column id with alias  
			/// </summary>
			public string Colid { 
				get { return GetColumnName("COL11958673271"); } 
			}

			/// <summary>
			/// Gets column TariffsOfElecId with alias  
			/// </summary>
			public string ColTariffsOfElecId { 
				get { return GetColumnName("COL11958673277"); } 
			}

			/// <summary>
			/// Gets column FitoutService with alias  
			/// </summary>
			public string ColFitoutService { 
				get { return GetColumnName("COL119586732739"); } 
			}

			/// <summary>
			/// Gets column OtherFee01 with alias  
			/// </summary>
			public string ColOtherFee01 { 
				get { return GetColumnName("COL11958673275"); } 
			}

			/// <summary>
			/// Gets column ModifiedBy with alias  
			/// </summary>
			public string ColModifiedBy { 
				get { return GetColumnName("COL119586732719"); } 
			}

			/// <summary>
			/// Gets column EndContract with alias  
			/// </summary>
			public string ColEndContract { 
				get { return GetColumnName("COL119586732714"); } 
			}

			/// <summary>
			/// Gets column Comment with alias  
			/// </summary>
			public string ColComment { 
				get { return GetColumnName("COL119586732715"); } 
			}

			/// <summary>
			/// Gets column RentArea with alias  
			/// </summary>
			public string ColRentArea { 
				get { return GetColumnName("COL119586732726"); } 
			}

			/// <summary>
			/// Gets column FitoutBegin with alias  
			/// </summary>
			public string ColFitoutBegin { 
				get { return GetColumnName("COL119586732733"); } 
			}

			/// <summary>
			/// Gets column MonthExtraTimePriceUsd with alias  
			/// </summary>
			public string ColMonthExtraTimePriceUsd { 
				get { return GetColumnName("COL119586732730"); } 
			}

			/// <summary>
			/// Gets column MonthRentPriceUSD with alias  
			/// </summary>
			public string ColMonthRentPriceUSD { 
				get { return GetColumnName("COL119586732710"); } 
			}

			/// <summary>
			/// Gets column FitoutManager with alias  
			/// </summary>
			public string ColFitoutManager { 
				get { return GetColumnName("COL119586732735"); } 
			}

			/// <summary>
			/// Gets column ExtraTimeMinPriceVND with alias  
			/// </summary>
			public string ColExtraTimeMinPriceVND { 
				get { return GetColumnName("COL119586732727"); } 
			}

			/// <summary>
			/// Gets column Created with alias  
			/// </summary>
			public string ColCreated { 
				get { return GetColumnName("COL119586732716"); } 
			}

			/// <summary>
			/// Gets column HourExtraTimePriceUsd with alias  
			/// </summary>
			public string ColHourExtraTimePriceUsd { 
				get { return GetColumnName("COL119586732722"); } 
			}

			/// <summary>
			/// Gets column MonthManagerPriceVND with alias  
			/// </summary>
			public string ColMonthManagerPriceVND { 
				get { return GetColumnName("COL119586732711"); } 
			}

			/// <summary>
			/// Gets column MonthManagerPriceUSD with alias  
			/// </summary>
			public string ColMonthManagerPriceUSD { 
				get { return GetColumnName("COL119586732712"); } 
			}

			/// <summary>
			/// Gets column TariffsOfWaterId with alias  
			/// </summary>
			public string ColTariffsOfWaterId { 
				get { return GetColumnName("COL11958673278"); } 
			}

			/// <summary>
			/// Gets column ExtraTimeMinPriceUSD with alias  
			/// </summary>
			public string ColExtraTimeMinPriceUSD { 
				get { return GetColumnName("COL119586732728"); } 
			}

			/// <summary>
			/// Gets column RentType with alias  
			/// </summary>
			public string ColRentType { 
				get { return GetColumnName("COL119586732723"); } 
			}

			/// <summary>
			/// Gets column ContractId with alias  
			/// </summary>
			public string ColContractId { 
				get { return GetColumnName("COL11958673272"); } 
			}

			/// <summary>
			/// Gets column ExtratimeType with alias  
			/// </summary>
			public string ColExtratimeType { 
				get { return GetColumnName("COL119586732731"); } 
			}

			/// <summary>
			/// Gets column OtherFee02 with alias  
			/// </summary>
			public string ColOtherFee02 { 
				get { return GetColumnName("COL11958673276"); } 
			}

			/// <summary>
			/// Gets column MonthExtraTimePriceVND with alias  
			/// </summary>
			public string ColMonthExtraTimePriceVND { 
				get { return GetColumnName("COL119586732729"); } 
			}

			/// <summary>
			/// Gets column VAT with alias  
			/// </summary>
			public string ColVAT { 
				get { return GetColumnName("COL11958673274"); } 
			}

			/// <summary>
			/// Gets column ElecPricePercent with alias  
			/// </summary>
			public string ColElecPricePercent { 
				get { return GetColumnName("COL119586732724"); } 
			}


			/// <summary>
			/// Checks whether column ManagerType is added in select statement 
			/// </summary>
			public bool IsSelectManagerType { 
				get { return IsSelect("COL119586732732"); } 
				set { SetSelect("COL119586732732", value); } 
			}

			/// <summary>
			/// Checks whether column FitoutWater is added in select statement 
			/// </summary>
			public bool IsSelectFitoutWater { 
				get { return IsSelect("COL119586732736"); } 
				set { SetSelect("COL119586732736", value); } 
			}

			/// <summary>
			/// Checks whether column WaterPricePercent is added in select statement 
			/// </summary>
			public bool IsSelectWaterPricePercent { 
				get { return IsSelect("COL119586732725"); } 
				set { SetSelect("COL119586732725", value); } 
			}

			/// <summary>
			/// Checks whether column FitoutEnd is added in select statement 
			/// </summary>
			public bool IsSelectFitoutEnd { 
				get { return IsSelect("COL119586732734"); } 
				set { SetSelect("COL119586732734", value); } 
			}

			/// <summary>
			/// Checks whether column DelFlag is added in select statement 
			/// </summary>
			public bool IsSelectDelFlag { 
				get { return IsSelect("COL119586732720"); } 
				set { SetSelect("COL119586732720", value); } 
			}

			/// <summary>
			/// Checks whether column FitoutElec is added in select statement 
			/// </summary>
			public bool IsSelectFitoutElec { 
				get { return IsSelect("COL119586732737"); } 
				set { SetSelect("COL119586732737", value); } 
			}

			/// <summary>
			/// Checks whether column FitoutExtraTime is added in select statement 
			/// </summary>
			public bool IsSelectFitoutExtraTime { 
				get { return IsSelect("COL119586732740"); } 
				set { SetSelect("COL119586732740", value); } 
			}

			/// <summary>
			/// Checks whether column CreatedBy is added in select statement 
			/// </summary>
			public bool IsSelectCreatedBy { 
				get { return IsSelect("COL119586732717"); } 
				set { SetSelect("COL119586732717", value); } 
			}

			/// <summary>
			/// Checks whether column HourExtraTimePriceVND is added in select statement 
			/// </summary>
			public bool IsSelectHourExtraTimePriceVND { 
				get { return IsSelect("COL119586732721"); } 
				set { SetSelect("COL119586732721", value); } 
			}

			/// <summary>
			/// Checks whether column MonthRentPriceVND is added in select statement 
			/// </summary>
			public bool IsSelectMonthRentPriceVND { 
				get { return IsSelect("COL11958673279"); } 
				set { SetSelect("COL11958673279", value); } 
			}

			/// <summary>
			/// Checks whether column FitoutParking is added in select statement 
			/// </summary>
			public bool IsSelectFitoutParking { 
				get { return IsSelect("COL119586732738"); } 
				set { SetSelect("COL119586732738", value); } 
			}

			/// <summary>
			/// Checks whether column Modified is added in select statement 
			/// </summary>
			public bool IsSelectModified { 
				get { return IsSelect("COL119586732718"); } 
				set { SetSelect("COL119586732718", value); } 
			}

			/// <summary>
			/// Checks whether column RoomId is added in select statement 
			/// </summary>
			public bool IsSelectRoomId { 
				get { return IsSelect("COL11958673273"); } 
				set { SetSelect("COL11958673273", value); } 
			}

			/// <summary>
			/// Checks whether column BeginContract is added in select statement 
			/// </summary>
			public bool IsSelectBeginContract { 
				get { return IsSelect("COL119586732713"); } 
				set { SetSelect("COL119586732713", value); } 
			}

			/// <summary>
			/// Checks whether column id is added in select statement 
			/// </summary>
			public bool IsSelectid { 
				get { return IsSelect("COL11958673271"); } 
				set { SetSelect("COL11958673271", value); } 
			}

			/// <summary>
			/// Checks whether column TariffsOfElecId is added in select statement 
			/// </summary>
			public bool IsSelectTariffsOfElecId { 
				get { return IsSelect("COL11958673277"); } 
				set { SetSelect("COL11958673277", value); } 
			}

			/// <summary>
			/// Checks whether column FitoutService is added in select statement 
			/// </summary>
			public bool IsSelectFitoutService { 
				get { return IsSelect("COL119586732739"); } 
				set { SetSelect("COL119586732739", value); } 
			}

			/// <summary>
			/// Checks whether column OtherFee01 is added in select statement 
			/// </summary>
			public bool IsSelectOtherFee01 { 
				get { return IsSelect("COL11958673275"); } 
				set { SetSelect("COL11958673275", value); } 
			}

			/// <summary>
			/// Checks whether column ModifiedBy is added in select statement 
			/// </summary>
			public bool IsSelectModifiedBy { 
				get { return IsSelect("COL119586732719"); } 
				set { SetSelect("COL119586732719", value); } 
			}

			/// <summary>
			/// Checks whether column EndContract is added in select statement 
			/// </summary>
			public bool IsSelectEndContract { 
				get { return IsSelect("COL119586732714"); } 
				set { SetSelect("COL119586732714", value); } 
			}

			/// <summary>
			/// Checks whether column Comment is added in select statement 
			/// </summary>
			public bool IsSelectComment { 
				get { return IsSelect("COL119586732715"); } 
				set { SetSelect("COL119586732715", value); } 
			}

			/// <summary>
			/// Checks whether column RentArea is added in select statement 
			/// </summary>
			public bool IsSelectRentArea { 
				get { return IsSelect("COL119586732726"); } 
				set { SetSelect("COL119586732726", value); } 
			}

			/// <summary>
			/// Checks whether column FitoutBegin is added in select statement 
			/// </summary>
			public bool IsSelectFitoutBegin { 
				get { return IsSelect("COL119586732733"); } 
				set { SetSelect("COL119586732733", value); } 
			}

			/// <summary>
			/// Checks whether column MonthExtraTimePriceUsd is added in select statement 
			/// </summary>
			public bool IsSelectMonthExtraTimePriceUsd { 
				get { return IsSelect("COL119586732730"); } 
				set { SetSelect("COL119586732730", value); } 
			}

			/// <summary>
			/// Checks whether column MonthRentPriceUSD is added in select statement 
			/// </summary>
			public bool IsSelectMonthRentPriceUSD { 
				get { return IsSelect("COL119586732710"); } 
				set { SetSelect("COL119586732710", value); } 
			}

			/// <summary>
			/// Checks whether column FitoutManager is added in select statement 
			/// </summary>
			public bool IsSelectFitoutManager { 
				get { return IsSelect("COL119586732735"); } 
				set { SetSelect("COL119586732735", value); } 
			}

			/// <summary>
			/// Checks whether column ExtraTimeMinPriceVND is added in select statement 
			/// </summary>
			public bool IsSelectExtraTimeMinPriceVND { 
				get { return IsSelect("COL119586732727"); } 
				set { SetSelect("COL119586732727", value); } 
			}

			/// <summary>
			/// Checks whether column Created is added in select statement 
			/// </summary>
			public bool IsSelectCreated { 
				get { return IsSelect("COL119586732716"); } 
				set { SetSelect("COL119586732716", value); } 
			}

			/// <summary>
			/// Checks whether column HourExtraTimePriceUsd is added in select statement 
			/// </summary>
			public bool IsSelectHourExtraTimePriceUsd { 
				get { return IsSelect("COL119586732722"); } 
				set { SetSelect("COL119586732722", value); } 
			}

			/// <summary>
			/// Checks whether column MonthManagerPriceVND is added in select statement 
			/// </summary>
			public bool IsSelectMonthManagerPriceVND { 
				get { return IsSelect("COL119586732711"); } 
				set { SetSelect("COL119586732711", value); } 
			}

			/// <summary>
			/// Checks whether column MonthManagerPriceUSD is added in select statement 
			/// </summary>
			public bool IsSelectMonthManagerPriceUSD { 
				get { return IsSelect("COL119586732712"); } 
				set { SetSelect("COL119586732712", value); } 
			}

			/// <summary>
			/// Checks whether column TariffsOfWaterId is added in select statement 
			/// </summary>
			public bool IsSelectTariffsOfWaterId { 
				get { return IsSelect("COL11958673278"); } 
				set { SetSelect("COL11958673278", value); } 
			}

			/// <summary>
			/// Checks whether column ExtraTimeMinPriceUSD is added in select statement 
			/// </summary>
			public bool IsSelectExtraTimeMinPriceUSD { 
				get { return IsSelect("COL119586732728"); } 
				set { SetSelect("COL119586732728", value); } 
			}

			/// <summary>
			/// Checks whether column RentType is added in select statement 
			/// </summary>
			public bool IsSelectRentType { 
				get { return IsSelect("COL119586732723"); } 
				set { SetSelect("COL119586732723", value); } 
			}

			/// <summary>
			/// Checks whether column ContractId is added in select statement 
			/// </summary>
			public bool IsSelectContractId { 
				get { return IsSelect("COL11958673272"); } 
				set { SetSelect("COL11958673272", value); } 
			}

			/// <summary>
			/// Checks whether column ExtratimeType is added in select statement 
			/// </summary>
			public bool IsSelectExtratimeType { 
				get { return IsSelect("COL119586732731"); } 
				set { SetSelect("COL119586732731", value); } 
			}

			/// <summary>
			/// Checks whether column OtherFee02 is added in select statement 
			/// </summary>
			public bool IsSelectOtherFee02 { 
				get { return IsSelect("COL11958673276"); } 
				set { SetSelect("COL11958673276", value); } 
			}

			/// <summary>
			/// Checks whether column MonthExtraTimePriceVND is added in select statement 
			/// </summary>
			public bool IsSelectMonthExtraTimePriceVND { 
				get { return IsSelect("COL119586732729"); } 
				set { SetSelect("COL119586732729", value); } 
			}

			/// <summary>
			/// Checks whether column VAT is added in select statement 
			/// </summary>
			public bool IsSelectVAT { 
				get { return IsSelect("COL11958673274"); } 
				set { SetSelect("COL11958673274", value); } 
			}

			/// <summary>
			/// Checks whether column ElecPricePercent is added in select statement 
			/// </summary>
			public bool IsSelectElecPricePercent { 
				get { return IsSelect("COL119586732724"); } 
				set { SetSelect("COL119586732724", value); } 
			}



	}
}