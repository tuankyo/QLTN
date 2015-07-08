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
	public class BD_RoomBookingService20120910Data : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ536388980";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of BD_RoomBookingService20120910 
			/// </summary>
			public BD_RoomBookingService20120910Data(string objectID): base(objectID) {}  

			public BD_RoomBookingService20120910Data() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field OtherFee01 
			/// </summary>
			public string OtherFee01 { 
				get { return GetValue("COL53638898014"); } 
				set { SetValue("COL53638898014", value); } 
			}

			/// <summary>
			/// Gets field PriceVND 
			/// </summary>
			public string PriceVND { 
				get { return GetValue("COL5363889804"); } 
				set { SetValue("COL5363889804", value); } 
			}

			/// <summary>
			/// Gets field Service 
			/// </summary>
			public string Service { 
				get { return GetValue("COL5363889803"); } 
				set { SetValue("COL5363889803", value); } 
			}

			/// <summary>
			/// Gets field BookingId 
			/// </summary>
			public string BookingId { 
				get { return GetValue("COL5363889802"); } 
				set { SetValue("COL5363889802", value); } 
			}

			/// <summary>
			/// Gets field id 
			/// </summary>
			public string id { 
				get { return GetValue("COL5363889801"); } 
				set { SetValue("COL5363889801", value); } 
			}

			/// <summary>
			/// Gets field DelFlag 
			/// </summary>
			public string DelFlag { 
				get { return GetValue("COL53638898012"); } 
				set { SetValue("COL53638898012", value); } 
			}

			/// <summary>
			/// Gets field ModifiedBy 
			/// </summary>
			public string ModifiedBy { 
				get { return GetValue("COL53638898011"); } 
				set { SetValue("COL53638898011", value); } 
			}

			/// <summary>
			/// Gets field Modified 
			/// </summary>
			public string Modified { 
				get { return GetValue("COL53638898010"); } 
				set { SetValue("COL53638898010", value); } 
			}

			/// <summary>
			/// Gets field CreatedBy 
			/// </summary>
			public string CreatedBy { 
				get { return GetValue("COL5363889809"); } 
				set { SetValue("COL5363889809", value); } 
			}

			/// <summary>
			/// Gets field Created 
			/// </summary>
			public string Created { 
				get { return GetValue("COL5363889808"); } 
				set { SetValue("COL5363889808", value); } 
			}

			/// <summary>
			/// Gets field OtherFee02 
			/// </summary>
			public string OtherFee02 { 
				get { return GetValue("COL53638898015"); } 
				set { SetValue("COL53638898015", value); } 
			}

			/// <summary>
			/// Gets field PriceUSD 
			/// </summary>
			public string PriceUSD { 
				get { return GetValue("COL5363889805"); } 
				set { SetValue("COL5363889805", value); } 
			}

			/// <summary>
			/// Gets field Unit 
			/// </summary>
			public string Unit { 
				get { return GetValue("COL53638898016"); } 
				set { SetValue("COL53638898016", value); } 
			}

			/// <summary>
			/// Gets field VAT 
			/// </summary>
			public string VAT { 
				get { return GetValue("COL53638898013"); } 
				set { SetValue("COL53638898013", value); } 
			}

			/// <summary>
			/// Gets field Comment 
			/// </summary>
			public string Comment { 
				get { return GetValue("COL5363889807"); } 
				set { SetValue("COL5363889807", value); } 
			}

			/// <summary>
			/// Gets field Mount 
			/// </summary>
			public string Mount { 
				get { return GetValue("COL5363889806"); } 
				set { SetValue("COL5363889806", value); } 
			}


			/// <summary>
			/// Gets OtherFee01 attribute data 
			/// </summary>
			public AttributeData GetOtherFee01AttributeData() { 
				return GetAttributeData("COL53638898014"); 
			}

			/// <summary>
			/// Gets PriceVND attribute data 
			/// </summary>
			public AttributeData GetPriceVNDAttributeData() { 
				return GetAttributeData("COL5363889804"); 
			}

			/// <summary>
			/// Gets Service attribute data 
			/// </summary>
			public AttributeData GetServiceAttributeData() { 
				return GetAttributeData("COL5363889803"); 
			}

			/// <summary>
			/// Gets BookingId attribute data 
			/// </summary>
			public AttributeData GetBookingIdAttributeData() { 
				return GetAttributeData("COL5363889802"); 
			}

			/// <summary>
			/// Gets id attribute data 
			/// </summary>
			public AttributeData GetidAttributeData() { 
				return GetAttributeData("COL5363889801"); 
			}

			/// <summary>
			/// Gets DelFlag attribute data 
			/// </summary>
			public AttributeData GetDelFlagAttributeData() { 
				return GetAttributeData("COL53638898012"); 
			}

			/// <summary>
			/// Gets ModifiedBy attribute data 
			/// </summary>
			public AttributeData GetModifiedByAttributeData() { 
				return GetAttributeData("COL53638898011"); 
			}

			/// <summary>
			/// Gets Modified attribute data 
			/// </summary>
			public AttributeData GetModifiedAttributeData() { 
				return GetAttributeData("COL53638898010"); 
			}

			/// <summary>
			/// Gets CreatedBy attribute data 
			/// </summary>
			public AttributeData GetCreatedByAttributeData() { 
				return GetAttributeData("COL5363889809"); 
			}

			/// <summary>
			/// Gets Created attribute data 
			/// </summary>
			public AttributeData GetCreatedAttributeData() { 
				return GetAttributeData("COL5363889808"); 
			}

			/// <summary>
			/// Gets OtherFee02 attribute data 
			/// </summary>
			public AttributeData GetOtherFee02AttributeData() { 
				return GetAttributeData("COL53638898015"); 
			}

			/// <summary>
			/// Gets PriceUSD attribute data 
			/// </summary>
			public AttributeData GetPriceUSDAttributeData() { 
				return GetAttributeData("COL5363889805"); 
			}

			/// <summary>
			/// Gets Unit attribute data 
			/// </summary>
			public AttributeData GetUnitAttributeData() { 
				return GetAttributeData("COL53638898016"); 
			}

			/// <summary>
			/// Gets VAT attribute data 
			/// </summary>
			public AttributeData GetVATAttributeData() { 
				return GetAttributeData("COL53638898013"); 
			}

			/// <summary>
			/// Gets Comment attribute data 
			/// </summary>
			public AttributeData GetCommentAttributeData() { 
				return GetAttributeData("COL5363889807"); 
			}

			/// <summary>
			/// Gets Mount attribute data 
			/// </summary>
			public AttributeData GetMountAttributeData() { 
				return GetAttributeData("COL5363889806"); 
			}


			/// <summary>
			/// Gets column OtherFee01 with alias  
			/// </summary>
			public string ColOtherFee01 { 
				get { return GetColumnName("COL53638898014"); } 
			}

			/// <summary>
			/// Gets column PriceVND with alias  
			/// </summary>
			public string ColPriceVND { 
				get { return GetColumnName("COL5363889804"); } 
			}

			/// <summary>
			/// Gets column Service with alias  
			/// </summary>
			public string ColService { 
				get { return GetColumnName("COL5363889803"); } 
			}

			/// <summary>
			/// Gets column BookingId with alias  
			/// </summary>
			public string ColBookingId { 
				get { return GetColumnName("COL5363889802"); } 
			}

			/// <summary>
			/// Gets column id with alias  
			/// </summary>
			public string Colid { 
				get { return GetColumnName("COL5363889801"); } 
			}

			/// <summary>
			/// Gets column DelFlag with alias  
			/// </summary>
			public string ColDelFlag { 
				get { return GetColumnName("COL53638898012"); } 
			}

			/// <summary>
			/// Gets column ModifiedBy with alias  
			/// </summary>
			public string ColModifiedBy { 
				get { return GetColumnName("COL53638898011"); } 
			}

			/// <summary>
			/// Gets column Modified with alias  
			/// </summary>
			public string ColModified { 
				get { return GetColumnName("COL53638898010"); } 
			}

			/// <summary>
			/// Gets column CreatedBy with alias  
			/// </summary>
			public string ColCreatedBy { 
				get { return GetColumnName("COL5363889809"); } 
			}

			/// <summary>
			/// Gets column Created with alias  
			/// </summary>
			public string ColCreated { 
				get { return GetColumnName("COL5363889808"); } 
			}

			/// <summary>
			/// Gets column OtherFee02 with alias  
			/// </summary>
			public string ColOtherFee02 { 
				get { return GetColumnName("COL53638898015"); } 
			}

			/// <summary>
			/// Gets column PriceUSD with alias  
			/// </summary>
			public string ColPriceUSD { 
				get { return GetColumnName("COL5363889805"); } 
			}

			/// <summary>
			/// Gets column Unit with alias  
			/// </summary>
			public string ColUnit { 
				get { return GetColumnName("COL53638898016"); } 
			}

			/// <summary>
			/// Gets column VAT with alias  
			/// </summary>
			public string ColVAT { 
				get { return GetColumnName("COL53638898013"); } 
			}

			/// <summary>
			/// Gets column Comment with alias  
			/// </summary>
			public string ColComment { 
				get { return GetColumnName("COL5363889807"); } 
			}

			/// <summary>
			/// Gets column Mount with alias  
			/// </summary>
			public string ColMount { 
				get { return GetColumnName("COL5363889806"); } 
			}


			/// <summary>
			/// Checks whether column OtherFee01 is added in select statement 
			/// </summary>
			public bool IsSelectOtherFee01 { 
				get { return IsSelect("COL53638898014"); } 
				set { SetSelect("COL53638898014", value); } 
			}

			/// <summary>
			/// Checks whether column PriceVND is added in select statement 
			/// </summary>
			public bool IsSelectPriceVND { 
				get { return IsSelect("COL5363889804"); } 
				set { SetSelect("COL5363889804", value); } 
			}

			/// <summary>
			/// Checks whether column Service is added in select statement 
			/// </summary>
			public bool IsSelectService { 
				get { return IsSelect("COL5363889803"); } 
				set { SetSelect("COL5363889803", value); } 
			}

			/// <summary>
			/// Checks whether column BookingId is added in select statement 
			/// </summary>
			public bool IsSelectBookingId { 
				get { return IsSelect("COL5363889802"); } 
				set { SetSelect("COL5363889802", value); } 
			}

			/// <summary>
			/// Checks whether column id is added in select statement 
			/// </summary>
			public bool IsSelectid { 
				get { return IsSelect("COL5363889801"); } 
				set { SetSelect("COL5363889801", value); } 
			}

			/// <summary>
			/// Checks whether column DelFlag is added in select statement 
			/// </summary>
			public bool IsSelectDelFlag { 
				get { return IsSelect("COL53638898012"); } 
				set { SetSelect("COL53638898012", value); } 
			}

			/// <summary>
			/// Checks whether column ModifiedBy is added in select statement 
			/// </summary>
			public bool IsSelectModifiedBy { 
				get { return IsSelect("COL53638898011"); } 
				set { SetSelect("COL53638898011", value); } 
			}

			/// <summary>
			/// Checks whether column Modified is added in select statement 
			/// </summary>
			public bool IsSelectModified { 
				get { return IsSelect("COL53638898010"); } 
				set { SetSelect("COL53638898010", value); } 
			}

			/// <summary>
			/// Checks whether column CreatedBy is added in select statement 
			/// </summary>
			public bool IsSelectCreatedBy { 
				get { return IsSelect("COL5363889809"); } 
				set { SetSelect("COL5363889809", value); } 
			}

			/// <summary>
			/// Checks whether column Created is added in select statement 
			/// </summary>
			public bool IsSelectCreated { 
				get { return IsSelect("COL5363889808"); } 
				set { SetSelect("COL5363889808", value); } 
			}

			/// <summary>
			/// Checks whether column OtherFee02 is added in select statement 
			/// </summary>
			public bool IsSelectOtherFee02 { 
				get { return IsSelect("COL53638898015"); } 
				set { SetSelect("COL53638898015", value); } 
			}

			/// <summary>
			/// Checks whether column PriceUSD is added in select statement 
			/// </summary>
			public bool IsSelectPriceUSD { 
				get { return IsSelect("COL5363889805"); } 
				set { SetSelect("COL5363889805", value); } 
			}

			/// <summary>
			/// Checks whether column Unit is added in select statement 
			/// </summary>
			public bool IsSelectUnit { 
				get { return IsSelect("COL53638898016"); } 
				set { SetSelect("COL53638898016", value); } 
			}

			/// <summary>
			/// Checks whether column VAT is added in select statement 
			/// </summary>
			public bool IsSelectVAT { 
				get { return IsSelect("COL53638898013"); } 
				set { SetSelect("COL53638898013", value); } 
			}

			/// <summary>
			/// Checks whether column Comment is added in select statement 
			/// </summary>
			public bool IsSelectComment { 
				get { return IsSelect("COL5363889807"); } 
				set { SetSelect("COL5363889807", value); } 
			}

			/// <summary>
			/// Checks whether column Mount is added in select statement 
			/// </summary>
			public bool IsSelectMount { 
				get { return IsSelect("COL5363889806"); } 
				set { SetSelect("COL5363889806", value); } 
			}



	}
}