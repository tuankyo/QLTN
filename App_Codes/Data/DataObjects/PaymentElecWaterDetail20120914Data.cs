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
	public class PaymentElecWaterDetail20120914Data : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ648389379";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of PaymentElecWaterDetail20120914 
			/// </summary>
			public PaymentElecWaterDetail20120914Data(string objectID): base(objectID) {}  

			public PaymentElecWaterDetail20120914Data() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field VAT 
			/// </summary>
			public string VAT { 
				get { return GetValue("COL6483893796"); } 
				set { SetValue("COL6483893796", value); } 
			}

			/// <summary>
			/// Gets field SumVND 
			/// </summary>
			public string SumVND { 
				get { return GetValue("COL64838937914"); } 
				set { SetValue("COL64838937914", value); } 
			}

			/// <summary>
			/// Gets field CreatedBy 
			/// </summary>
			public string CreatedBy { 
				get { return GetValue("COL64838937924"); } 
				set { SetValue("COL64838937924", value); } 
			}

			/// <summary>
			/// Gets field VatUSD 
			/// </summary>
			public string VatUSD { 
				get { return GetValue("COL64838937911"); } 
				set { SetValue("COL64838937911", value); } 
			}

			/// <summary>
			/// Gets field Modified 
			/// </summary>
			public string Modified { 
				get { return GetValue("COL64838937925"); } 
				set { SetValue("COL64838937925", value); } 
			}

			/// <summary>
			/// Gets field RoomId 
			/// </summary>
			public string RoomId { 
				get { return GetValue("COL64838937921"); } 
				set { SetValue("COL64838937921", value); } 
			}

			/// <summary>
			/// Gets field WaterPricePercent 
			/// </summary>
			public string WaterPricePercent { 
				get { return GetValue("COL64838937929"); } 
				set { SetValue("COL64838937929", value); } 
			}

			/// <summary>
			/// Gets field VatVND 
			/// </summary>
			public string VatVND { 
				get { return GetValue("COL64838937912"); } 
				set { SetValue("COL64838937912", value); } 
			}

			/// <summary>
			/// Gets field Comment 
			/// </summary>
			public string Comment { 
				get { return GetValue("COL64838937922"); } 
				set { SetValue("COL64838937922", value); } 
			}

			/// <summary>
			/// Gets field Mount 
			/// </summary>
			public string Mount { 
				get { return GetValue("COL64838937917"); } 
				set { SetValue("COL64838937917", value); } 
			}

			/// <summary>
			/// Gets field DelFlag 
			/// </summary>
			public string DelFlag { 
				get { return GetValue("COL64838937927"); } 
				set { SetValue("COL64838937927", value); } 
			}

			/// <summary>
			/// Gets field PriceVND 
			/// </summary>
			public string PriceVND { 
				get { return GetValue("COL64838937910"); } 
				set { SetValue("COL64838937910", value); } 
			}

			/// <summary>
			/// Gets field DetailType 
			/// </summary>
			public string DetailType { 
				get { return GetValue("COL64838937930"); } 
				set { SetValue("COL64838937930", value); } 
			}

			/// <summary>
			/// Gets field YearMonth 
			/// </summary>
			public string YearMonth { 
				get { return GetValue("COL64838937918"); } 
				set { SetValue("COL64838937918", value); } 
			}

			/// <summary>
			/// Gets field id 
			/// </summary>
			public string id { 
				get { return GetValue("COL6483893791"); } 
				set { SetValue("COL6483893791", value); } 
			}

			/// <summary>
			/// Gets field LastPriceUSD 
			/// </summary>
			public string LastPriceUSD { 
				get { return GetValue("COL64838937915"); } 
				set { SetValue("COL64838937915", value); } 
			}

			/// <summary>
			/// Gets field Name 
			/// </summary>
			public string Name { 
				get { return GetValue("COL6483893793"); } 
				set { SetValue("COL6483893793", value); } 
			}

			/// <summary>
			/// Gets field BuildingId 
			/// </summary>
			public string BuildingId { 
				get { return GetValue("COL64838937919"); } 
				set { SetValue("COL64838937919", value); } 
			}

			/// <summary>
			/// Gets field ToIndex 
			/// </summary>
			public string ToIndex { 
				get { return GetValue("COL6483893795"); } 
				set { SetValue("COL6483893795", value); } 
			}

			/// <summary>
			/// Gets field FromIndex 
			/// </summary>
			public string FromIndex { 
				get { return GetValue("COL6483893794"); } 
				set { SetValue("COL6483893794", value); } 
			}

			/// <summary>
			/// Gets field OtherFee01 
			/// </summary>
			public string OtherFee01 { 
				get { return GetValue("COL6483893797"); } 
				set { SetValue("COL6483893797", value); } 
			}

			/// <summary>
			/// Gets field LastPriceVND 
			/// </summary>
			public string LastPriceVND { 
				get { return GetValue("COL64838937916"); } 
				set { SetValue("COL64838937916", value); } 
			}

			/// <summary>
			/// Gets field PriceUSD 
			/// </summary>
			public string PriceUSD { 
				get { return GetValue("COL6483893799"); } 
				set { SetValue("COL6483893799", value); } 
			}

			/// <summary>
			/// Gets field OtherFee02 
			/// </summary>
			public string OtherFee02 { 
				get { return GetValue("COL6483893798"); } 
				set { SetValue("COL6483893798", value); } 
			}

			/// <summary>
			/// Gets field ElecPricePercent 
			/// </summary>
			public string ElecPricePercent { 
				get { return GetValue("COL64838937928"); } 
				set { SetValue("COL64838937928", value); } 
			}

			/// <summary>
			/// Gets field ModifiedBy 
			/// </summary>
			public string ModifiedBy { 
				get { return GetValue("COL64838937926"); } 
				set { SetValue("COL64838937926", value); } 
			}

			/// <summary>
			/// Gets field SumUSD 
			/// </summary>
			public string SumUSD { 
				get { return GetValue("COL64838937913"); } 
				set { SetValue("COL64838937913", value); } 
			}

			/// <summary>
			/// Gets field UsedElecWaterId 
			/// </summary>
			public string UsedElecWaterId { 
				get { return GetValue("COL6483893792"); } 
				set { SetValue("COL6483893792", value); } 
			}

			/// <summary>
			/// Gets field Created 
			/// </summary>
			public string Created { 
				get { return GetValue("COL64838937923"); } 
				set { SetValue("COL64838937923", value); } 
			}

			/// <summary>
			/// Gets field CustomerId 
			/// </summary>
			public string CustomerId { 
				get { return GetValue("COL64838937920"); } 
				set { SetValue("COL64838937920", value); } 
			}


			/// <summary>
			/// Gets VAT attribute data 
			/// </summary>
			public AttributeData GetVATAttributeData() { 
				return GetAttributeData("COL6483893796"); 
			}

			/// <summary>
			/// Gets SumVND attribute data 
			/// </summary>
			public AttributeData GetSumVNDAttributeData() { 
				return GetAttributeData("COL64838937914"); 
			}

			/// <summary>
			/// Gets CreatedBy attribute data 
			/// </summary>
			public AttributeData GetCreatedByAttributeData() { 
				return GetAttributeData("COL64838937924"); 
			}

			/// <summary>
			/// Gets VatUSD attribute data 
			/// </summary>
			public AttributeData GetVatUSDAttributeData() { 
				return GetAttributeData("COL64838937911"); 
			}

			/// <summary>
			/// Gets Modified attribute data 
			/// </summary>
			public AttributeData GetModifiedAttributeData() { 
				return GetAttributeData("COL64838937925"); 
			}

			/// <summary>
			/// Gets RoomId attribute data 
			/// </summary>
			public AttributeData GetRoomIdAttributeData() { 
				return GetAttributeData("COL64838937921"); 
			}

			/// <summary>
			/// Gets WaterPricePercent attribute data 
			/// </summary>
			public AttributeData GetWaterPricePercentAttributeData() { 
				return GetAttributeData("COL64838937929"); 
			}

			/// <summary>
			/// Gets VatVND attribute data 
			/// </summary>
			public AttributeData GetVatVNDAttributeData() { 
				return GetAttributeData("COL64838937912"); 
			}

			/// <summary>
			/// Gets Comment attribute data 
			/// </summary>
			public AttributeData GetCommentAttributeData() { 
				return GetAttributeData("COL64838937922"); 
			}

			/// <summary>
			/// Gets Mount attribute data 
			/// </summary>
			public AttributeData GetMountAttributeData() { 
				return GetAttributeData("COL64838937917"); 
			}

			/// <summary>
			/// Gets DelFlag attribute data 
			/// </summary>
			public AttributeData GetDelFlagAttributeData() { 
				return GetAttributeData("COL64838937927"); 
			}

			/// <summary>
			/// Gets PriceVND attribute data 
			/// </summary>
			public AttributeData GetPriceVNDAttributeData() { 
				return GetAttributeData("COL64838937910"); 
			}

			/// <summary>
			/// Gets DetailType attribute data 
			/// </summary>
			public AttributeData GetDetailTypeAttributeData() { 
				return GetAttributeData("COL64838937930"); 
			}

			/// <summary>
			/// Gets YearMonth attribute data 
			/// </summary>
			public AttributeData GetYearMonthAttributeData() { 
				return GetAttributeData("COL64838937918"); 
			}

			/// <summary>
			/// Gets id attribute data 
			/// </summary>
			public AttributeData GetidAttributeData() { 
				return GetAttributeData("COL6483893791"); 
			}

			/// <summary>
			/// Gets LastPriceUSD attribute data 
			/// </summary>
			public AttributeData GetLastPriceUSDAttributeData() { 
				return GetAttributeData("COL64838937915"); 
			}

			/// <summary>
			/// Gets Name attribute data 
			/// </summary>
			public AttributeData GetNameAttributeData() { 
				return GetAttributeData("COL6483893793"); 
			}

			/// <summary>
			/// Gets BuildingId attribute data 
			/// </summary>
			public AttributeData GetBuildingIdAttributeData() { 
				return GetAttributeData("COL64838937919"); 
			}

			/// <summary>
			/// Gets ToIndex attribute data 
			/// </summary>
			public AttributeData GetToIndexAttributeData() { 
				return GetAttributeData("COL6483893795"); 
			}

			/// <summary>
			/// Gets FromIndex attribute data 
			/// </summary>
			public AttributeData GetFromIndexAttributeData() { 
				return GetAttributeData("COL6483893794"); 
			}

			/// <summary>
			/// Gets OtherFee01 attribute data 
			/// </summary>
			public AttributeData GetOtherFee01AttributeData() { 
				return GetAttributeData("COL6483893797"); 
			}

			/// <summary>
			/// Gets LastPriceVND attribute data 
			/// </summary>
			public AttributeData GetLastPriceVNDAttributeData() { 
				return GetAttributeData("COL64838937916"); 
			}

			/// <summary>
			/// Gets PriceUSD attribute data 
			/// </summary>
			public AttributeData GetPriceUSDAttributeData() { 
				return GetAttributeData("COL6483893799"); 
			}

			/// <summary>
			/// Gets OtherFee02 attribute data 
			/// </summary>
			public AttributeData GetOtherFee02AttributeData() { 
				return GetAttributeData("COL6483893798"); 
			}

			/// <summary>
			/// Gets ElecPricePercent attribute data 
			/// </summary>
			public AttributeData GetElecPricePercentAttributeData() { 
				return GetAttributeData("COL64838937928"); 
			}

			/// <summary>
			/// Gets ModifiedBy attribute data 
			/// </summary>
			public AttributeData GetModifiedByAttributeData() { 
				return GetAttributeData("COL64838937926"); 
			}

			/// <summary>
			/// Gets SumUSD attribute data 
			/// </summary>
			public AttributeData GetSumUSDAttributeData() { 
				return GetAttributeData("COL64838937913"); 
			}

			/// <summary>
			/// Gets UsedElecWaterId attribute data 
			/// </summary>
			public AttributeData GetUsedElecWaterIdAttributeData() { 
				return GetAttributeData("COL6483893792"); 
			}

			/// <summary>
			/// Gets Created attribute data 
			/// </summary>
			public AttributeData GetCreatedAttributeData() { 
				return GetAttributeData("COL64838937923"); 
			}

			/// <summary>
			/// Gets CustomerId attribute data 
			/// </summary>
			public AttributeData GetCustomerIdAttributeData() { 
				return GetAttributeData("COL64838937920"); 
			}


			/// <summary>
			/// Gets column VAT with alias  
			/// </summary>
			public string ColVAT { 
				get { return GetColumnName("COL6483893796"); } 
			}

			/// <summary>
			/// Gets column SumVND with alias  
			/// </summary>
			public string ColSumVND { 
				get { return GetColumnName("COL64838937914"); } 
			}

			/// <summary>
			/// Gets column CreatedBy with alias  
			/// </summary>
			public string ColCreatedBy { 
				get { return GetColumnName("COL64838937924"); } 
			}

			/// <summary>
			/// Gets column VatUSD with alias  
			/// </summary>
			public string ColVatUSD { 
				get { return GetColumnName("COL64838937911"); } 
			}

			/// <summary>
			/// Gets column Modified with alias  
			/// </summary>
			public string ColModified { 
				get { return GetColumnName("COL64838937925"); } 
			}

			/// <summary>
			/// Gets column RoomId with alias  
			/// </summary>
			public string ColRoomId { 
				get { return GetColumnName("COL64838937921"); } 
			}

			/// <summary>
			/// Gets column WaterPricePercent with alias  
			/// </summary>
			public string ColWaterPricePercent { 
				get { return GetColumnName("COL64838937929"); } 
			}

			/// <summary>
			/// Gets column VatVND with alias  
			/// </summary>
			public string ColVatVND { 
				get { return GetColumnName("COL64838937912"); } 
			}

			/// <summary>
			/// Gets column Comment with alias  
			/// </summary>
			public string ColComment { 
				get { return GetColumnName("COL64838937922"); } 
			}

			/// <summary>
			/// Gets column Mount with alias  
			/// </summary>
			public string ColMount { 
				get { return GetColumnName("COL64838937917"); } 
			}

			/// <summary>
			/// Gets column DelFlag with alias  
			/// </summary>
			public string ColDelFlag { 
				get { return GetColumnName("COL64838937927"); } 
			}

			/// <summary>
			/// Gets column PriceVND with alias  
			/// </summary>
			public string ColPriceVND { 
				get { return GetColumnName("COL64838937910"); } 
			}

			/// <summary>
			/// Gets column DetailType with alias  
			/// </summary>
			public string ColDetailType { 
				get { return GetColumnName("COL64838937930"); } 
			}

			/// <summary>
			/// Gets column YearMonth with alias  
			/// </summary>
			public string ColYearMonth { 
				get { return GetColumnName("COL64838937918"); } 
			}

			/// <summary>
			/// Gets column id with alias  
			/// </summary>
			public string Colid { 
				get { return GetColumnName("COL6483893791"); } 
			}

			/// <summary>
			/// Gets column LastPriceUSD with alias  
			/// </summary>
			public string ColLastPriceUSD { 
				get { return GetColumnName("COL64838937915"); } 
			}

			/// <summary>
			/// Gets column Name with alias  
			/// </summary>
			public string ColName { 
				get { return GetColumnName("COL6483893793"); } 
			}

			/// <summary>
			/// Gets column BuildingId with alias  
			/// </summary>
			public string ColBuildingId { 
				get { return GetColumnName("COL64838937919"); } 
			}

			/// <summary>
			/// Gets column ToIndex with alias  
			/// </summary>
			public string ColToIndex { 
				get { return GetColumnName("COL6483893795"); } 
			}

			/// <summary>
			/// Gets column FromIndex with alias  
			/// </summary>
			public string ColFromIndex { 
				get { return GetColumnName("COL6483893794"); } 
			}

			/// <summary>
			/// Gets column OtherFee01 with alias  
			/// </summary>
			public string ColOtherFee01 { 
				get { return GetColumnName("COL6483893797"); } 
			}

			/// <summary>
			/// Gets column LastPriceVND with alias  
			/// </summary>
			public string ColLastPriceVND { 
				get { return GetColumnName("COL64838937916"); } 
			}

			/// <summary>
			/// Gets column PriceUSD with alias  
			/// </summary>
			public string ColPriceUSD { 
				get { return GetColumnName("COL6483893799"); } 
			}

			/// <summary>
			/// Gets column OtherFee02 with alias  
			/// </summary>
			public string ColOtherFee02 { 
				get { return GetColumnName("COL6483893798"); } 
			}

			/// <summary>
			/// Gets column ElecPricePercent with alias  
			/// </summary>
			public string ColElecPricePercent { 
				get { return GetColumnName("COL64838937928"); } 
			}

			/// <summary>
			/// Gets column ModifiedBy with alias  
			/// </summary>
			public string ColModifiedBy { 
				get { return GetColumnName("COL64838937926"); } 
			}

			/// <summary>
			/// Gets column SumUSD with alias  
			/// </summary>
			public string ColSumUSD { 
				get { return GetColumnName("COL64838937913"); } 
			}

			/// <summary>
			/// Gets column UsedElecWaterId with alias  
			/// </summary>
			public string ColUsedElecWaterId { 
				get { return GetColumnName("COL6483893792"); } 
			}

			/// <summary>
			/// Gets column Created with alias  
			/// </summary>
			public string ColCreated { 
				get { return GetColumnName("COL64838937923"); } 
			}

			/// <summary>
			/// Gets column CustomerId with alias  
			/// </summary>
			public string ColCustomerId { 
				get { return GetColumnName("COL64838937920"); } 
			}


			/// <summary>
			/// Checks whether column VAT is added in select statement 
			/// </summary>
			public bool IsSelectVAT { 
				get { return IsSelect("COL6483893796"); } 
				set { SetSelect("COL6483893796", value); } 
			}

			/// <summary>
			/// Checks whether column SumVND is added in select statement 
			/// </summary>
			public bool IsSelectSumVND { 
				get { return IsSelect("COL64838937914"); } 
				set { SetSelect("COL64838937914", value); } 
			}

			/// <summary>
			/// Checks whether column CreatedBy is added in select statement 
			/// </summary>
			public bool IsSelectCreatedBy { 
				get { return IsSelect("COL64838937924"); } 
				set { SetSelect("COL64838937924", value); } 
			}

			/// <summary>
			/// Checks whether column VatUSD is added in select statement 
			/// </summary>
			public bool IsSelectVatUSD { 
				get { return IsSelect("COL64838937911"); } 
				set { SetSelect("COL64838937911", value); } 
			}

			/// <summary>
			/// Checks whether column Modified is added in select statement 
			/// </summary>
			public bool IsSelectModified { 
				get { return IsSelect("COL64838937925"); } 
				set { SetSelect("COL64838937925", value); } 
			}

			/// <summary>
			/// Checks whether column RoomId is added in select statement 
			/// </summary>
			public bool IsSelectRoomId { 
				get { return IsSelect("COL64838937921"); } 
				set { SetSelect("COL64838937921", value); } 
			}

			/// <summary>
			/// Checks whether column WaterPricePercent is added in select statement 
			/// </summary>
			public bool IsSelectWaterPricePercent { 
				get { return IsSelect("COL64838937929"); } 
				set { SetSelect("COL64838937929", value); } 
			}

			/// <summary>
			/// Checks whether column VatVND is added in select statement 
			/// </summary>
			public bool IsSelectVatVND { 
				get { return IsSelect("COL64838937912"); } 
				set { SetSelect("COL64838937912", value); } 
			}

			/// <summary>
			/// Checks whether column Comment is added in select statement 
			/// </summary>
			public bool IsSelectComment { 
				get { return IsSelect("COL64838937922"); } 
				set { SetSelect("COL64838937922", value); } 
			}

			/// <summary>
			/// Checks whether column Mount is added in select statement 
			/// </summary>
			public bool IsSelectMount { 
				get { return IsSelect("COL64838937917"); } 
				set { SetSelect("COL64838937917", value); } 
			}

			/// <summary>
			/// Checks whether column DelFlag is added in select statement 
			/// </summary>
			public bool IsSelectDelFlag { 
				get { return IsSelect("COL64838937927"); } 
				set { SetSelect("COL64838937927", value); } 
			}

			/// <summary>
			/// Checks whether column PriceVND is added in select statement 
			/// </summary>
			public bool IsSelectPriceVND { 
				get { return IsSelect("COL64838937910"); } 
				set { SetSelect("COL64838937910", value); } 
			}

			/// <summary>
			/// Checks whether column DetailType is added in select statement 
			/// </summary>
			public bool IsSelectDetailType { 
				get { return IsSelect("COL64838937930"); } 
				set { SetSelect("COL64838937930", value); } 
			}

			/// <summary>
			/// Checks whether column YearMonth is added in select statement 
			/// </summary>
			public bool IsSelectYearMonth { 
				get { return IsSelect("COL64838937918"); } 
				set { SetSelect("COL64838937918", value); } 
			}

			/// <summary>
			/// Checks whether column id is added in select statement 
			/// </summary>
			public bool IsSelectid { 
				get { return IsSelect("COL6483893791"); } 
				set { SetSelect("COL6483893791", value); } 
			}

			/// <summary>
			/// Checks whether column LastPriceUSD is added in select statement 
			/// </summary>
			public bool IsSelectLastPriceUSD { 
				get { return IsSelect("COL64838937915"); } 
				set { SetSelect("COL64838937915", value); } 
			}

			/// <summary>
			/// Checks whether column Name is added in select statement 
			/// </summary>
			public bool IsSelectName { 
				get { return IsSelect("COL6483893793"); } 
				set { SetSelect("COL6483893793", value); } 
			}

			/// <summary>
			/// Checks whether column BuildingId is added in select statement 
			/// </summary>
			public bool IsSelectBuildingId { 
				get { return IsSelect("COL64838937919"); } 
				set { SetSelect("COL64838937919", value); } 
			}

			/// <summary>
			/// Checks whether column ToIndex is added in select statement 
			/// </summary>
			public bool IsSelectToIndex { 
				get { return IsSelect("COL6483893795"); } 
				set { SetSelect("COL6483893795", value); } 
			}

			/// <summary>
			/// Checks whether column FromIndex is added in select statement 
			/// </summary>
			public bool IsSelectFromIndex { 
				get { return IsSelect("COL6483893794"); } 
				set { SetSelect("COL6483893794", value); } 
			}

			/// <summary>
			/// Checks whether column OtherFee01 is added in select statement 
			/// </summary>
			public bool IsSelectOtherFee01 { 
				get { return IsSelect("COL6483893797"); } 
				set { SetSelect("COL6483893797", value); } 
			}

			/// <summary>
			/// Checks whether column LastPriceVND is added in select statement 
			/// </summary>
			public bool IsSelectLastPriceVND { 
				get { return IsSelect("COL64838937916"); } 
				set { SetSelect("COL64838937916", value); } 
			}

			/// <summary>
			/// Checks whether column PriceUSD is added in select statement 
			/// </summary>
			public bool IsSelectPriceUSD { 
				get { return IsSelect("COL6483893799"); } 
				set { SetSelect("COL6483893799", value); } 
			}

			/// <summary>
			/// Checks whether column OtherFee02 is added in select statement 
			/// </summary>
			public bool IsSelectOtherFee02 { 
				get { return IsSelect("COL6483893798"); } 
				set { SetSelect("COL6483893798", value); } 
			}

			/// <summary>
			/// Checks whether column ElecPricePercent is added in select statement 
			/// </summary>
			public bool IsSelectElecPricePercent { 
				get { return IsSelect("COL64838937928"); } 
				set { SetSelect("COL64838937928", value); } 
			}

			/// <summary>
			/// Checks whether column ModifiedBy is added in select statement 
			/// </summary>
			public bool IsSelectModifiedBy { 
				get { return IsSelect("COL64838937926"); } 
				set { SetSelect("COL64838937926", value); } 
			}

			/// <summary>
			/// Checks whether column SumUSD is added in select statement 
			/// </summary>
			public bool IsSelectSumUSD { 
				get { return IsSelect("COL64838937913"); } 
				set { SetSelect("COL64838937913", value); } 
			}

			/// <summary>
			/// Checks whether column UsedElecWaterId is added in select statement 
			/// </summary>
			public bool IsSelectUsedElecWaterId { 
				get { return IsSelect("COL6483893792"); } 
				set { SetSelect("COL6483893792", value); } 
			}

			/// <summary>
			/// Checks whether column Created is added in select statement 
			/// </summary>
			public bool IsSelectCreated { 
				get { return IsSelect("COL64838937923"); } 
				set { SetSelect("COL64838937923", value); } 
			}

			/// <summary>
			/// Checks whether column CustomerId is added in select statement 
			/// </summary>
			public bool IsSelectCustomerId { 
				get { return IsSelect("COL64838937920"); } 
				set { SetSelect("COL64838937920", value); } 
			}



	}
}