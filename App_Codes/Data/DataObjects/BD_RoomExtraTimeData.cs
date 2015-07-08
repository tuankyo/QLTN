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
	public class BD_RoomExtraTimeData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ1259867555";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of BD_RoomExtraTime 
			/// </summary>
			public BD_RoomExtraTimeData(string objectID): base(objectID) {}  

			public BD_RoomExtraTimeData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field BuildingId 
			/// </summary>
			public string BuildingId { 
				get { return GetValue("COL12598675552"); } 
				set { SetValue("COL12598675552", value); } 
			}

			/// <summary>
			/// Gets field Created 
			/// </summary>
			public string Created { 
				get { return GetValue("COL125986755514"); } 
				set { SetValue("COL125986755514", value); } 
			}

			/// <summary>
			/// Gets field PriceUSD 
			/// </summary>
			public string PriceUSD { 
				get { return GetValue("COL125986755512"); } 
				set { SetValue("COL125986755512", value); } 
			}

			/// <summary>
			/// Gets field WorkingDate 
			/// </summary>
			public string WorkingDate { 
				get { return GetValue("COL12598675555"); } 
				set { SetValue("COL12598675555", value); } 
			}

			/// <summary>
			/// Gets field YearMonth 
			/// </summary>
			public string YearMonth { 
				get { return GetValue("COL12598675558"); } 
				set { SetValue("COL12598675558", value); } 
			}

			/// <summary>
			/// Gets field PriceVND 
			/// </summary>
			public string PriceVND { 
				get { return GetValue("COL125986755513"); } 
				set { SetValue("COL125986755513", value); } 
			}

			/// <summary>
			/// Gets field Vat 
			/// </summary>
			public string Vat { 
				get { return GetValue("COL125986755511"); } 
				set { SetValue("COL125986755511", value); } 
			}

			/// <summary>
			/// Gets field RoomId 
			/// </summary>
			public string RoomId { 
				get { return GetValue("COL12598675553"); } 
				set { SetValue("COL12598675553", value); } 
			}

			/// <summary>
			/// Gets field Modified 
			/// </summary>
			public string Modified { 
				get { return GetValue("COL125986755516"); } 
				set { SetValue("COL125986755516", value); } 
			}

			/// <summary>
			/// Gets field FromWD 
			/// </summary>
			public string FromWD { 
				get { return GetValue("COL12598675556"); } 
				set { SetValue("COL12598675556", value); } 
			}

			/// <summary>
			/// Gets field ExtraHour 
			/// </summary>
			public string ExtraHour { 
				get { return GetValue("COL12598675559"); } 
				set { SetValue("COL12598675559", value); } 
			}

			/// <summary>
			/// Gets field CreatedBy 
			/// </summary>
			public string CreatedBy { 
				get { return GetValue("COL125986755515"); } 
				set { SetValue("COL125986755515", value); } 
			}

			/// <summary>
			/// Gets field id 
			/// </summary>
			public string id { 
				get { return GetValue("COL12598675551"); } 
				set { SetValue("COL12598675551", value); } 
			}

			/// <summary>
			/// Gets field DelFlag 
			/// </summary>
			public string DelFlag { 
				get { return GetValue("COL125986755518"); } 
				set { SetValue("COL125986755518", value); } 
			}

			/// <summary>
			/// Gets field Comment 
			/// </summary>
			public string Comment { 
				get { return GetValue("COL125986755510"); } 
				set { SetValue("COL125986755510", value); } 
			}

			/// <summary>
			/// Gets field CustomerId 
			/// </summary>
			public string CustomerId { 
				get { return GetValue("COL12598675554"); } 
				set { SetValue("COL12598675554", value); } 
			}

			/// <summary>
			/// Gets field ModifiedBy 
			/// </summary>
			public string ModifiedBy { 
				get { return GetValue("COL125986755517"); } 
				set { SetValue("COL125986755517", value); } 
			}

			/// <summary>
			/// Gets field EndWD 
			/// </summary>
			public string EndWD { 
				get { return GetValue("COL12598675557"); } 
				set { SetValue("COL12598675557", value); } 
			}


			/// <summary>
			/// Gets BuildingId attribute data 
			/// </summary>
			public AttributeData GetBuildingIdAttributeData() { 
				return GetAttributeData("COL12598675552"); 
			}

			/// <summary>
			/// Gets Created attribute data 
			/// </summary>
			public AttributeData GetCreatedAttributeData() { 
				return GetAttributeData("COL125986755514"); 
			}

			/// <summary>
			/// Gets PriceUSD attribute data 
			/// </summary>
			public AttributeData GetPriceUSDAttributeData() { 
				return GetAttributeData("COL125986755512"); 
			}

			/// <summary>
			/// Gets WorkingDate attribute data 
			/// </summary>
			public AttributeData GetWorkingDateAttributeData() { 
				return GetAttributeData("COL12598675555"); 
			}

			/// <summary>
			/// Gets YearMonth attribute data 
			/// </summary>
			public AttributeData GetYearMonthAttributeData() { 
				return GetAttributeData("COL12598675558"); 
			}

			/// <summary>
			/// Gets PriceVND attribute data 
			/// </summary>
			public AttributeData GetPriceVNDAttributeData() { 
				return GetAttributeData("COL125986755513"); 
			}

			/// <summary>
			/// Gets Vat attribute data 
			/// </summary>
			public AttributeData GetVatAttributeData() { 
				return GetAttributeData("COL125986755511"); 
			}

			/// <summary>
			/// Gets RoomId attribute data 
			/// </summary>
			public AttributeData GetRoomIdAttributeData() { 
				return GetAttributeData("COL12598675553"); 
			}

			/// <summary>
			/// Gets Modified attribute data 
			/// </summary>
			public AttributeData GetModifiedAttributeData() { 
				return GetAttributeData("COL125986755516"); 
			}

			/// <summary>
			/// Gets FromWD attribute data 
			/// </summary>
			public AttributeData GetFromWDAttributeData() { 
				return GetAttributeData("COL12598675556"); 
			}

			/// <summary>
			/// Gets ExtraHour attribute data 
			/// </summary>
			public AttributeData GetExtraHourAttributeData() { 
				return GetAttributeData("COL12598675559"); 
			}

			/// <summary>
			/// Gets CreatedBy attribute data 
			/// </summary>
			public AttributeData GetCreatedByAttributeData() { 
				return GetAttributeData("COL125986755515"); 
			}

			/// <summary>
			/// Gets id attribute data 
			/// </summary>
			public AttributeData GetidAttributeData() { 
				return GetAttributeData("COL12598675551"); 
			}

			/// <summary>
			/// Gets DelFlag attribute data 
			/// </summary>
			public AttributeData GetDelFlagAttributeData() { 
				return GetAttributeData("COL125986755518"); 
			}

			/// <summary>
			/// Gets Comment attribute data 
			/// </summary>
			public AttributeData GetCommentAttributeData() { 
				return GetAttributeData("COL125986755510"); 
			}

			/// <summary>
			/// Gets CustomerId attribute data 
			/// </summary>
			public AttributeData GetCustomerIdAttributeData() { 
				return GetAttributeData("COL12598675554"); 
			}

			/// <summary>
			/// Gets ModifiedBy attribute data 
			/// </summary>
			public AttributeData GetModifiedByAttributeData() { 
				return GetAttributeData("COL125986755517"); 
			}

			/// <summary>
			/// Gets EndWD attribute data 
			/// </summary>
			public AttributeData GetEndWDAttributeData() { 
				return GetAttributeData("COL12598675557"); 
			}


			/// <summary>
			/// Gets column BuildingId with alias  
			/// </summary>
			public string ColBuildingId { 
				get { return GetColumnName("COL12598675552"); } 
			}

			/// <summary>
			/// Gets column Created with alias  
			/// </summary>
			public string ColCreated { 
				get { return GetColumnName("COL125986755514"); } 
			}

			/// <summary>
			/// Gets column PriceUSD with alias  
			/// </summary>
			public string ColPriceUSD { 
				get { return GetColumnName("COL125986755512"); } 
			}

			/// <summary>
			/// Gets column WorkingDate with alias  
			/// </summary>
			public string ColWorkingDate { 
				get { return GetColumnName("COL12598675555"); } 
			}

			/// <summary>
			/// Gets column YearMonth with alias  
			/// </summary>
			public string ColYearMonth { 
				get { return GetColumnName("COL12598675558"); } 
			}

			/// <summary>
			/// Gets column PriceVND with alias  
			/// </summary>
			public string ColPriceVND { 
				get { return GetColumnName("COL125986755513"); } 
			}

			/// <summary>
			/// Gets column Vat with alias  
			/// </summary>
			public string ColVat { 
				get { return GetColumnName("COL125986755511"); } 
			}

			/// <summary>
			/// Gets column RoomId with alias  
			/// </summary>
			public string ColRoomId { 
				get { return GetColumnName("COL12598675553"); } 
			}

			/// <summary>
			/// Gets column Modified with alias  
			/// </summary>
			public string ColModified { 
				get { return GetColumnName("COL125986755516"); } 
			}

			/// <summary>
			/// Gets column FromWD with alias  
			/// </summary>
			public string ColFromWD { 
				get { return GetColumnName("COL12598675556"); } 
			}

			/// <summary>
			/// Gets column ExtraHour with alias  
			/// </summary>
			public string ColExtraHour { 
				get { return GetColumnName("COL12598675559"); } 
			}

			/// <summary>
			/// Gets column CreatedBy with alias  
			/// </summary>
			public string ColCreatedBy { 
				get { return GetColumnName("COL125986755515"); } 
			}

			/// <summary>
			/// Gets column id with alias  
			/// </summary>
			public string Colid { 
				get { return GetColumnName("COL12598675551"); } 
			}

			/// <summary>
			/// Gets column DelFlag with alias  
			/// </summary>
			public string ColDelFlag { 
				get { return GetColumnName("COL125986755518"); } 
			}

			/// <summary>
			/// Gets column Comment with alias  
			/// </summary>
			public string ColComment { 
				get { return GetColumnName("COL125986755510"); } 
			}

			/// <summary>
			/// Gets column CustomerId with alias  
			/// </summary>
			public string ColCustomerId { 
				get { return GetColumnName("COL12598675554"); } 
			}

			/// <summary>
			/// Gets column ModifiedBy with alias  
			/// </summary>
			public string ColModifiedBy { 
				get { return GetColumnName("COL125986755517"); } 
			}

			/// <summary>
			/// Gets column EndWD with alias  
			/// </summary>
			public string ColEndWD { 
				get { return GetColumnName("COL12598675557"); } 
			}


			/// <summary>
			/// Checks whether column BuildingId is added in select statement 
			/// </summary>
			public bool IsSelectBuildingId { 
				get { return IsSelect("COL12598675552"); } 
				set { SetSelect("COL12598675552", value); } 
			}

			/// <summary>
			/// Checks whether column Created is added in select statement 
			/// </summary>
			public bool IsSelectCreated { 
				get { return IsSelect("COL125986755514"); } 
				set { SetSelect("COL125986755514", value); } 
			}

			/// <summary>
			/// Checks whether column PriceUSD is added in select statement 
			/// </summary>
			public bool IsSelectPriceUSD { 
				get { return IsSelect("COL125986755512"); } 
				set { SetSelect("COL125986755512", value); } 
			}

			/// <summary>
			/// Checks whether column WorkingDate is added in select statement 
			/// </summary>
			public bool IsSelectWorkingDate { 
				get { return IsSelect("COL12598675555"); } 
				set { SetSelect("COL12598675555", value); } 
			}

			/// <summary>
			/// Checks whether column YearMonth is added in select statement 
			/// </summary>
			public bool IsSelectYearMonth { 
				get { return IsSelect("COL12598675558"); } 
				set { SetSelect("COL12598675558", value); } 
			}

			/// <summary>
			/// Checks whether column PriceVND is added in select statement 
			/// </summary>
			public bool IsSelectPriceVND { 
				get { return IsSelect("COL125986755513"); } 
				set { SetSelect("COL125986755513", value); } 
			}

			/// <summary>
			/// Checks whether column Vat is added in select statement 
			/// </summary>
			public bool IsSelectVat { 
				get { return IsSelect("COL125986755511"); } 
				set { SetSelect("COL125986755511", value); } 
			}

			/// <summary>
			/// Checks whether column RoomId is added in select statement 
			/// </summary>
			public bool IsSelectRoomId { 
				get { return IsSelect("COL12598675553"); } 
				set { SetSelect("COL12598675553", value); } 
			}

			/// <summary>
			/// Checks whether column Modified is added in select statement 
			/// </summary>
			public bool IsSelectModified { 
				get { return IsSelect("COL125986755516"); } 
				set { SetSelect("COL125986755516", value); } 
			}

			/// <summary>
			/// Checks whether column FromWD is added in select statement 
			/// </summary>
			public bool IsSelectFromWD { 
				get { return IsSelect("COL12598675556"); } 
				set { SetSelect("COL12598675556", value); } 
			}

			/// <summary>
			/// Checks whether column ExtraHour is added in select statement 
			/// </summary>
			public bool IsSelectExtraHour { 
				get { return IsSelect("COL12598675559"); } 
				set { SetSelect("COL12598675559", value); } 
			}

			/// <summary>
			/// Checks whether column CreatedBy is added in select statement 
			/// </summary>
			public bool IsSelectCreatedBy { 
				get { return IsSelect("COL125986755515"); } 
				set { SetSelect("COL125986755515", value); } 
			}

			/// <summary>
			/// Checks whether column id is added in select statement 
			/// </summary>
			public bool IsSelectid { 
				get { return IsSelect("COL12598675551"); } 
				set { SetSelect("COL12598675551", value); } 
			}

			/// <summary>
			/// Checks whether column DelFlag is added in select statement 
			/// </summary>
			public bool IsSelectDelFlag { 
				get { return IsSelect("COL125986755518"); } 
				set { SetSelect("COL125986755518", value); } 
			}

			/// <summary>
			/// Checks whether column Comment is added in select statement 
			/// </summary>
			public bool IsSelectComment { 
				get { return IsSelect("COL125986755510"); } 
				set { SetSelect("COL125986755510", value); } 
			}

			/// <summary>
			/// Checks whether column CustomerId is added in select statement 
			/// </summary>
			public bool IsSelectCustomerId { 
				get { return IsSelect("COL12598675554"); } 
				set { SetSelect("COL12598675554", value); } 
			}

			/// <summary>
			/// Checks whether column ModifiedBy is added in select statement 
			/// </summary>
			public bool IsSelectModifiedBy { 
				get { return IsSelect("COL125986755517"); } 
				set { SetSelect("COL125986755517", value); } 
			}

			/// <summary>
			/// Checks whether column EndWD is added in select statement 
			/// </summary>
			public bool IsSelectEndWD { 
				get { return IsSelect("COL12598675557"); } 
				set { SetSelect("COL12598675557", value); } 
			}



	}
}