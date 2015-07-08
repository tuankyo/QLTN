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
	public class BD_RoomBookingServiceData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ360388353";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of BD_RoomBookingService 
			/// </summary>
			public BD_RoomBookingServiceData(string objectID): base(objectID) {}  

			public BD_RoomBookingServiceData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field DelFlag 
			/// </summary>
			public string DelFlag { 
				get { return GetValue("COL36038835312"); } 
				set { SetValue("COL36038835312", value); } 
			}

			/// <summary>
			/// Gets field BookingId 
			/// </summary>
			public string BookingId { 
				get { return GetValue("COL3603883532"); } 
				set { SetValue("COL3603883532", value); } 
			}

			/// <summary>
			/// Gets field OtherFee01 
			/// </summary>
			public string OtherFee01 { 
				get { return GetValue("COL36038835314"); } 
				set { SetValue("COL36038835314", value); } 
			}

			/// <summary>
			/// Gets field Created 
			/// </summary>
			public string Created { 
				get { return GetValue("COL3603883538"); } 
				set { SetValue("COL3603883538", value); } 
			}

			/// <summary>
			/// Gets field CreatedBy 
			/// </summary>
			public string CreatedBy { 
				get { return GetValue("COL3603883539"); } 
				set { SetValue("COL3603883539", value); } 
			}

			/// <summary>
			/// Gets field OtherFee02 
			/// </summary>
			public string OtherFee02 { 
				get { return GetValue("COL36038835315"); } 
				set { SetValue("COL36038835315", value); } 
			}

			/// <summary>
			/// Gets field PriceVND 
			/// </summary>
			public string PriceVND { 
				get { return GetValue("COL3603883534"); } 
				set { SetValue("COL3603883534", value); } 
			}

			/// <summary>
			/// Gets field Modified 
			/// </summary>
			public string Modified { 
				get { return GetValue("COL36038835310"); } 
				set { SetValue("COL36038835310", value); } 
			}

			/// <summary>
			/// Gets field Unit 
			/// </summary>
			public string Unit { 
				get { return GetValue("COL36038835316"); } 
				set { SetValue("COL36038835316", value); } 
			}

			/// <summary>
			/// Gets field VAT 
			/// </summary>
			public string VAT { 
				get { return GetValue("COL36038835313"); } 
				set { SetValue("COL36038835313", value); } 
			}

			/// <summary>
			/// Gets field Service 
			/// </summary>
			public string Service { 
				get { return GetValue("COL3603883533"); } 
				set { SetValue("COL3603883533", value); } 
			}

			/// <summary>
			/// Gets field ModifiedBy 
			/// </summary>
			public string ModifiedBy { 
				get { return GetValue("COL36038835311"); } 
				set { SetValue("COL36038835311", value); } 
			}

			/// <summary>
			/// Gets field PriceUSD 
			/// </summary>
			public string PriceUSD { 
				get { return GetValue("COL3603883535"); } 
				set { SetValue("COL3603883535", value); } 
			}

			/// <summary>
			/// Gets field Mount 
			/// </summary>
			public string Mount { 
				get { return GetValue("COL3603883536"); } 
				set { SetValue("COL3603883536", value); } 
			}

			/// <summary>
			/// Gets field Comment 
			/// </summary>
			public string Comment { 
				get { return GetValue("COL3603883537"); } 
				set { SetValue("COL3603883537", value); } 
			}

			/// <summary>
			/// Gets field id 
			/// </summary>
			public string id { 
				get { return GetValue("COL3603883531"); } 
				set { SetValue("COL3603883531", value); } 
			}


			/// <summary>
			/// Gets DelFlag attribute data 
			/// </summary>
			public AttributeData GetDelFlagAttributeData() { 
				return GetAttributeData("COL36038835312"); 
			}

			/// <summary>
			/// Gets BookingId attribute data 
			/// </summary>
			public AttributeData GetBookingIdAttributeData() { 
				return GetAttributeData("COL3603883532"); 
			}

			/// <summary>
			/// Gets OtherFee01 attribute data 
			/// </summary>
			public AttributeData GetOtherFee01AttributeData() { 
				return GetAttributeData("COL36038835314"); 
			}

			/// <summary>
			/// Gets Created attribute data 
			/// </summary>
			public AttributeData GetCreatedAttributeData() { 
				return GetAttributeData("COL3603883538"); 
			}

			/// <summary>
			/// Gets CreatedBy attribute data 
			/// </summary>
			public AttributeData GetCreatedByAttributeData() { 
				return GetAttributeData("COL3603883539"); 
			}

			/// <summary>
			/// Gets OtherFee02 attribute data 
			/// </summary>
			public AttributeData GetOtherFee02AttributeData() { 
				return GetAttributeData("COL36038835315"); 
			}

			/// <summary>
			/// Gets PriceVND attribute data 
			/// </summary>
			public AttributeData GetPriceVNDAttributeData() { 
				return GetAttributeData("COL3603883534"); 
			}

			/// <summary>
			/// Gets Modified attribute data 
			/// </summary>
			public AttributeData GetModifiedAttributeData() { 
				return GetAttributeData("COL36038835310"); 
			}

			/// <summary>
			/// Gets Unit attribute data 
			/// </summary>
			public AttributeData GetUnitAttributeData() { 
				return GetAttributeData("COL36038835316"); 
			}

			/// <summary>
			/// Gets VAT attribute data 
			/// </summary>
			public AttributeData GetVATAttributeData() { 
				return GetAttributeData("COL36038835313"); 
			}

			/// <summary>
			/// Gets Service attribute data 
			/// </summary>
			public AttributeData GetServiceAttributeData() { 
				return GetAttributeData("COL3603883533"); 
			}

			/// <summary>
			/// Gets ModifiedBy attribute data 
			/// </summary>
			public AttributeData GetModifiedByAttributeData() { 
				return GetAttributeData("COL36038835311"); 
			}

			/// <summary>
			/// Gets PriceUSD attribute data 
			/// </summary>
			public AttributeData GetPriceUSDAttributeData() { 
				return GetAttributeData("COL3603883535"); 
			}

			/// <summary>
			/// Gets Mount attribute data 
			/// </summary>
			public AttributeData GetMountAttributeData() { 
				return GetAttributeData("COL3603883536"); 
			}

			/// <summary>
			/// Gets Comment attribute data 
			/// </summary>
			public AttributeData GetCommentAttributeData() { 
				return GetAttributeData("COL3603883537"); 
			}

			/// <summary>
			/// Gets id attribute data 
			/// </summary>
			public AttributeData GetidAttributeData() { 
				return GetAttributeData("COL3603883531"); 
			}


			/// <summary>
			/// Gets column DelFlag with alias  
			/// </summary>
			public string ColDelFlag { 
				get { return GetColumnName("COL36038835312"); } 
			}

			/// <summary>
			/// Gets column BookingId with alias  
			/// </summary>
			public string ColBookingId { 
				get { return GetColumnName("COL3603883532"); } 
			}

			/// <summary>
			/// Gets column OtherFee01 with alias  
			/// </summary>
			public string ColOtherFee01 { 
				get { return GetColumnName("COL36038835314"); } 
			}

			/// <summary>
			/// Gets column Created with alias  
			/// </summary>
			public string ColCreated { 
				get { return GetColumnName("COL3603883538"); } 
			}

			/// <summary>
			/// Gets column CreatedBy with alias  
			/// </summary>
			public string ColCreatedBy { 
				get { return GetColumnName("COL3603883539"); } 
			}

			/// <summary>
			/// Gets column OtherFee02 with alias  
			/// </summary>
			public string ColOtherFee02 { 
				get { return GetColumnName("COL36038835315"); } 
			}

			/// <summary>
			/// Gets column PriceVND with alias  
			/// </summary>
			public string ColPriceVND { 
				get { return GetColumnName("COL3603883534"); } 
			}

			/// <summary>
			/// Gets column Modified with alias  
			/// </summary>
			public string ColModified { 
				get { return GetColumnName("COL36038835310"); } 
			}

			/// <summary>
			/// Gets column Unit with alias  
			/// </summary>
			public string ColUnit { 
				get { return GetColumnName("COL36038835316"); } 
			}

			/// <summary>
			/// Gets column VAT with alias  
			/// </summary>
			public string ColVAT { 
				get { return GetColumnName("COL36038835313"); } 
			}

			/// <summary>
			/// Gets column Service with alias  
			/// </summary>
			public string ColService { 
				get { return GetColumnName("COL3603883533"); } 
			}

			/// <summary>
			/// Gets column ModifiedBy with alias  
			/// </summary>
			public string ColModifiedBy { 
				get { return GetColumnName("COL36038835311"); } 
			}

			/// <summary>
			/// Gets column PriceUSD with alias  
			/// </summary>
			public string ColPriceUSD { 
				get { return GetColumnName("COL3603883535"); } 
			}

			/// <summary>
			/// Gets column Mount with alias  
			/// </summary>
			public string ColMount { 
				get { return GetColumnName("COL3603883536"); } 
			}

			/// <summary>
			/// Gets column Comment with alias  
			/// </summary>
			public string ColComment { 
				get { return GetColumnName("COL3603883537"); } 
			}

			/// <summary>
			/// Gets column id with alias  
			/// </summary>
			public string Colid { 
				get { return GetColumnName("COL3603883531"); } 
			}


			/// <summary>
			/// Checks whether column DelFlag is added in select statement 
			/// </summary>
			public bool IsSelectDelFlag { 
				get { return IsSelect("COL36038835312"); } 
				set { SetSelect("COL36038835312", value); } 
			}

			/// <summary>
			/// Checks whether column BookingId is added in select statement 
			/// </summary>
			public bool IsSelectBookingId { 
				get { return IsSelect("COL3603883532"); } 
				set { SetSelect("COL3603883532", value); } 
			}

			/// <summary>
			/// Checks whether column OtherFee01 is added in select statement 
			/// </summary>
			public bool IsSelectOtherFee01 { 
				get { return IsSelect("COL36038835314"); } 
				set { SetSelect("COL36038835314", value); } 
			}

			/// <summary>
			/// Checks whether column Created is added in select statement 
			/// </summary>
			public bool IsSelectCreated { 
				get { return IsSelect("COL3603883538"); } 
				set { SetSelect("COL3603883538", value); } 
			}

			/// <summary>
			/// Checks whether column CreatedBy is added in select statement 
			/// </summary>
			public bool IsSelectCreatedBy { 
				get { return IsSelect("COL3603883539"); } 
				set { SetSelect("COL3603883539", value); } 
			}

			/// <summary>
			/// Checks whether column OtherFee02 is added in select statement 
			/// </summary>
			public bool IsSelectOtherFee02 { 
				get { return IsSelect("COL36038835315"); } 
				set { SetSelect("COL36038835315", value); } 
			}

			/// <summary>
			/// Checks whether column PriceVND is added in select statement 
			/// </summary>
			public bool IsSelectPriceVND { 
				get { return IsSelect("COL3603883534"); } 
				set { SetSelect("COL3603883534", value); } 
			}

			/// <summary>
			/// Checks whether column Modified is added in select statement 
			/// </summary>
			public bool IsSelectModified { 
				get { return IsSelect("COL36038835310"); } 
				set { SetSelect("COL36038835310", value); } 
			}

			/// <summary>
			/// Checks whether column Unit is added in select statement 
			/// </summary>
			public bool IsSelectUnit { 
				get { return IsSelect("COL36038835316"); } 
				set { SetSelect("COL36038835316", value); } 
			}

			/// <summary>
			/// Checks whether column VAT is added in select statement 
			/// </summary>
			public bool IsSelectVAT { 
				get { return IsSelect("COL36038835313"); } 
				set { SetSelect("COL36038835313", value); } 
			}

			/// <summary>
			/// Checks whether column Service is added in select statement 
			/// </summary>
			public bool IsSelectService { 
				get { return IsSelect("COL3603883533"); } 
				set { SetSelect("COL3603883533", value); } 
			}

			/// <summary>
			/// Checks whether column ModifiedBy is added in select statement 
			/// </summary>
			public bool IsSelectModifiedBy { 
				get { return IsSelect("COL36038835311"); } 
				set { SetSelect("COL36038835311", value); } 
			}

			/// <summary>
			/// Checks whether column PriceUSD is added in select statement 
			/// </summary>
			public bool IsSelectPriceUSD { 
				get { return IsSelect("COL3603883535"); } 
				set { SetSelect("COL3603883535", value); } 
			}

			/// <summary>
			/// Checks whether column Mount is added in select statement 
			/// </summary>
			public bool IsSelectMount { 
				get { return IsSelect("COL3603883536"); } 
				set { SetSelect("COL3603883536", value); } 
			}

			/// <summary>
			/// Checks whether column Comment is added in select statement 
			/// </summary>
			public bool IsSelectComment { 
				get { return IsSelect("COL3603883537"); } 
				set { SetSelect("COL3603883537", value); } 
			}

			/// <summary>
			/// Checks whether column id is added in select statement 
			/// </summary>
			public bool IsSelectid { 
				get { return IsSelect("COL3603883531"); } 
				set { SetSelect("COL3603883531", value); } 
			}



	}
}