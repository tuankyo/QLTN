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
	public class PaymentBookingServiceData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ328388239";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of PaymentBookingService 
			/// </summary>
			public PaymentBookingServiceData(string objectID): base(objectID) {}  

			public PaymentBookingServiceData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field PriceVND 
			/// </summary>
			public string PriceVND { 
				get { return GetValue("COL32838823914"); } 
				set { SetValue("COL32838823914", value); } 
			}

			/// <summary>
			/// Gets field CreatedBy 
			/// </summary>
			public string CreatedBy { 
				get { return GetValue("COL32838823924"); } 
				set { SetValue("COL32838823924", value); } 
			}

			/// <summary>
			/// Gets field CustomerId 
			/// </summary>
			public string CustomerId { 
				get { return GetValue("COL3283882394"); } 
				set { SetValue("COL3283882394", value); } 
			}

			/// <summary>
			/// Gets field BookingId 
			/// </summary>
			public string BookingId { 
				get { return GetValue("COL3283882395"); } 
				set { SetValue("COL3283882395", value); } 
			}

			/// <summary>
			/// Gets field id 
			/// </summary>
			public string id { 
				get { return GetValue("COL3283882391"); } 
				set { SetValue("COL3283882391", value); } 
			}

			/// <summary>
			/// Gets field YearMonth 
			/// </summary>
			public string YearMonth { 
				get { return GetValue("COL3283882392"); } 
				set { SetValue("COL3283882392", value); } 
			}

			/// <summary>
			/// Gets field BuildingId 
			/// </summary>
			public string BuildingId { 
				get { return GetValue("COL3283882393"); } 
				set { SetValue("COL3283882393", value); } 
			}

			/// <summary>
			/// Gets field SumUSD 
			/// </summary>
			public string SumUSD { 
				get { return GetValue("COL32838823917"); } 
				set { SetValue("COL32838823917", value); } 
			}

			/// <summary>
			/// Gets field DelFlag 
			/// </summary>
			public string DelFlag { 
				get { return GetValue("COL32838823927"); } 
				set { SetValue("COL32838823927", value); } 
			}

			/// <summary>
			/// Gets field ServiceId 
			/// </summary>
			public string ServiceId { 
				get { return GetValue("COL3283882396"); } 
				set { SetValue("COL3283882396", value); } 
			}

			/// <summary>
			/// Gets field ServiceDate 
			/// </summary>
			public string ServiceDate { 
				get { return GetValue("COL3283882397"); } 
				set { SetValue("COL3283882397", value); } 
			}

			/// <summary>
			/// Gets field OtherFee02 
			/// </summary>
			public string OtherFee02 { 
				get { return GetValue("COL32838823912"); } 
				set { SetValue("COL32838823912", value); } 
			}

			/// <summary>
			/// Gets field Comment 
			/// </summary>
			public string Comment { 
				get { return GetValue("COL32838823922"); } 
				set { SetValue("COL32838823922", value); } 
			}

			/// <summary>
			/// Gets field VatUSD 
			/// </summary>
			public string VatUSD { 
				get { return GetValue("COL32838823915"); } 
				set { SetValue("COL32838823915", value); } 
			}

			/// <summary>
			/// Gets field Modified 
			/// </summary>
			public string Modified { 
				get { return GetValue("COL32838823925"); } 
				set { SetValue("COL32838823925", value); } 
			}

			/// <summary>
			/// Gets field VAT 
			/// </summary>
			public string VAT { 
				get { return GetValue("COL32838823910"); } 
				set { SetValue("COL32838823910", value); } 
			}

			/// <summary>
			/// Gets field LastPriceVND 
			/// </summary>
			public string LastPriceVND { 
				get { return GetValue("COL32838823920"); } 
				set { SetValue("COL32838823920", value); } 
			}

			/// <summary>
			/// Gets field SumVND 
			/// </summary>
			public string SumVND { 
				get { return GetValue("COL32838823918"); } 
				set { SetValue("COL32838823918", value); } 
			}

			/// <summary>
			/// Gets field PriceUSD 
			/// </summary>
			public string PriceUSD { 
				get { return GetValue("COL32838823913"); } 
				set { SetValue("COL32838823913", value); } 
			}

			/// <summary>
			/// Gets field Created 
			/// </summary>
			public string Created { 
				get { return GetValue("COL32838823923"); } 
				set { SetValue("COL32838823923", value); } 
			}

			/// <summary>
			/// Gets field VatVND 
			/// </summary>
			public string VatVND { 
				get { return GetValue("COL32838823916"); } 
				set { SetValue("COL32838823916", value); } 
			}

			/// <summary>
			/// Gets field ModifiedBy 
			/// </summary>
			public string ModifiedBy { 
				get { return GetValue("COL32838823926"); } 
				set { SetValue("COL32838823926", value); } 
			}

			/// <summary>
			/// Gets field Mount 
			/// </summary>
			public string Mount { 
				get { return GetValue("COL3283882399"); } 
				set { SetValue("COL3283882399", value); } 
			}

			/// <summary>
			/// Gets field OtherFee01 
			/// </summary>
			public string OtherFee01 { 
				get { return GetValue("COL32838823911"); } 
				set { SetValue("COL32838823911", value); } 
			}

			/// <summary>
			/// Gets field Unit 
			/// </summary>
			public string Unit { 
				get { return GetValue("COL32838823921"); } 
				set { SetValue("COL32838823921", value); } 
			}

			/// <summary>
			/// Gets field Service 
			/// </summary>
			public string Service { 
				get { return GetValue("COL3283882398"); } 
				set { SetValue("COL3283882398", value); } 
			}

			/// <summary>
			/// Gets field LastPriceUSD 
			/// </summary>
			public string LastPriceUSD { 
				get { return GetValue("COL32838823919"); } 
				set { SetValue("COL32838823919", value); } 
			}


			/// <summary>
			/// Gets PriceVND attribute data 
			/// </summary>
			public AttributeData GetPriceVNDAttributeData() { 
				return GetAttributeData("COL32838823914"); 
			}

			/// <summary>
			/// Gets CreatedBy attribute data 
			/// </summary>
			public AttributeData GetCreatedByAttributeData() { 
				return GetAttributeData("COL32838823924"); 
			}

			/// <summary>
			/// Gets CustomerId attribute data 
			/// </summary>
			public AttributeData GetCustomerIdAttributeData() { 
				return GetAttributeData("COL3283882394"); 
			}

			/// <summary>
			/// Gets BookingId attribute data 
			/// </summary>
			public AttributeData GetBookingIdAttributeData() { 
				return GetAttributeData("COL3283882395"); 
			}

			/// <summary>
			/// Gets id attribute data 
			/// </summary>
			public AttributeData GetidAttributeData() { 
				return GetAttributeData("COL3283882391"); 
			}

			/// <summary>
			/// Gets YearMonth attribute data 
			/// </summary>
			public AttributeData GetYearMonthAttributeData() { 
				return GetAttributeData("COL3283882392"); 
			}

			/// <summary>
			/// Gets BuildingId attribute data 
			/// </summary>
			public AttributeData GetBuildingIdAttributeData() { 
				return GetAttributeData("COL3283882393"); 
			}

			/// <summary>
			/// Gets SumUSD attribute data 
			/// </summary>
			public AttributeData GetSumUSDAttributeData() { 
				return GetAttributeData("COL32838823917"); 
			}

			/// <summary>
			/// Gets DelFlag attribute data 
			/// </summary>
			public AttributeData GetDelFlagAttributeData() { 
				return GetAttributeData("COL32838823927"); 
			}

			/// <summary>
			/// Gets ServiceId attribute data 
			/// </summary>
			public AttributeData GetServiceIdAttributeData() { 
				return GetAttributeData("COL3283882396"); 
			}

			/// <summary>
			/// Gets ServiceDate attribute data 
			/// </summary>
			public AttributeData GetServiceDateAttributeData() { 
				return GetAttributeData("COL3283882397"); 
			}

			/// <summary>
			/// Gets OtherFee02 attribute data 
			/// </summary>
			public AttributeData GetOtherFee02AttributeData() { 
				return GetAttributeData("COL32838823912"); 
			}

			/// <summary>
			/// Gets Comment attribute data 
			/// </summary>
			public AttributeData GetCommentAttributeData() { 
				return GetAttributeData("COL32838823922"); 
			}

			/// <summary>
			/// Gets VatUSD attribute data 
			/// </summary>
			public AttributeData GetVatUSDAttributeData() { 
				return GetAttributeData("COL32838823915"); 
			}

			/// <summary>
			/// Gets Modified attribute data 
			/// </summary>
			public AttributeData GetModifiedAttributeData() { 
				return GetAttributeData("COL32838823925"); 
			}

			/// <summary>
			/// Gets VAT attribute data 
			/// </summary>
			public AttributeData GetVATAttributeData() { 
				return GetAttributeData("COL32838823910"); 
			}

			/// <summary>
			/// Gets LastPriceVND attribute data 
			/// </summary>
			public AttributeData GetLastPriceVNDAttributeData() { 
				return GetAttributeData("COL32838823920"); 
			}

			/// <summary>
			/// Gets SumVND attribute data 
			/// </summary>
			public AttributeData GetSumVNDAttributeData() { 
				return GetAttributeData("COL32838823918"); 
			}

			/// <summary>
			/// Gets PriceUSD attribute data 
			/// </summary>
			public AttributeData GetPriceUSDAttributeData() { 
				return GetAttributeData("COL32838823913"); 
			}

			/// <summary>
			/// Gets Created attribute data 
			/// </summary>
			public AttributeData GetCreatedAttributeData() { 
				return GetAttributeData("COL32838823923"); 
			}

			/// <summary>
			/// Gets VatVND attribute data 
			/// </summary>
			public AttributeData GetVatVNDAttributeData() { 
				return GetAttributeData("COL32838823916"); 
			}

			/// <summary>
			/// Gets ModifiedBy attribute data 
			/// </summary>
			public AttributeData GetModifiedByAttributeData() { 
				return GetAttributeData("COL32838823926"); 
			}

			/// <summary>
			/// Gets Mount attribute data 
			/// </summary>
			public AttributeData GetMountAttributeData() { 
				return GetAttributeData("COL3283882399"); 
			}

			/// <summary>
			/// Gets OtherFee01 attribute data 
			/// </summary>
			public AttributeData GetOtherFee01AttributeData() { 
				return GetAttributeData("COL32838823911"); 
			}

			/// <summary>
			/// Gets Unit attribute data 
			/// </summary>
			public AttributeData GetUnitAttributeData() { 
				return GetAttributeData("COL32838823921"); 
			}

			/// <summary>
			/// Gets Service attribute data 
			/// </summary>
			public AttributeData GetServiceAttributeData() { 
				return GetAttributeData("COL3283882398"); 
			}

			/// <summary>
			/// Gets LastPriceUSD attribute data 
			/// </summary>
			public AttributeData GetLastPriceUSDAttributeData() { 
				return GetAttributeData("COL32838823919"); 
			}


			/// <summary>
			/// Gets column PriceVND with alias  
			/// </summary>
			public string ColPriceVND { 
				get { return GetColumnName("COL32838823914"); } 
			}

			/// <summary>
			/// Gets column CreatedBy with alias  
			/// </summary>
			public string ColCreatedBy { 
				get { return GetColumnName("COL32838823924"); } 
			}

			/// <summary>
			/// Gets column CustomerId with alias  
			/// </summary>
			public string ColCustomerId { 
				get { return GetColumnName("COL3283882394"); } 
			}

			/// <summary>
			/// Gets column BookingId with alias  
			/// </summary>
			public string ColBookingId { 
				get { return GetColumnName("COL3283882395"); } 
			}

			/// <summary>
			/// Gets column id with alias  
			/// </summary>
			public string Colid { 
				get { return GetColumnName("COL3283882391"); } 
			}

			/// <summary>
			/// Gets column YearMonth with alias  
			/// </summary>
			public string ColYearMonth { 
				get { return GetColumnName("COL3283882392"); } 
			}

			/// <summary>
			/// Gets column BuildingId with alias  
			/// </summary>
			public string ColBuildingId { 
				get { return GetColumnName("COL3283882393"); } 
			}

			/// <summary>
			/// Gets column SumUSD with alias  
			/// </summary>
			public string ColSumUSD { 
				get { return GetColumnName("COL32838823917"); } 
			}

			/// <summary>
			/// Gets column DelFlag with alias  
			/// </summary>
			public string ColDelFlag { 
				get { return GetColumnName("COL32838823927"); } 
			}

			/// <summary>
			/// Gets column ServiceId with alias  
			/// </summary>
			public string ColServiceId { 
				get { return GetColumnName("COL3283882396"); } 
			}

			/// <summary>
			/// Gets column ServiceDate with alias  
			/// </summary>
			public string ColServiceDate { 
				get { return GetColumnName("COL3283882397"); } 
			}

			/// <summary>
			/// Gets column OtherFee02 with alias  
			/// </summary>
			public string ColOtherFee02 { 
				get { return GetColumnName("COL32838823912"); } 
			}

			/// <summary>
			/// Gets column Comment with alias  
			/// </summary>
			public string ColComment { 
				get { return GetColumnName("COL32838823922"); } 
			}

			/// <summary>
			/// Gets column VatUSD with alias  
			/// </summary>
			public string ColVatUSD { 
				get { return GetColumnName("COL32838823915"); } 
			}

			/// <summary>
			/// Gets column Modified with alias  
			/// </summary>
			public string ColModified { 
				get { return GetColumnName("COL32838823925"); } 
			}

			/// <summary>
			/// Gets column VAT with alias  
			/// </summary>
			public string ColVAT { 
				get { return GetColumnName("COL32838823910"); } 
			}

			/// <summary>
			/// Gets column LastPriceVND with alias  
			/// </summary>
			public string ColLastPriceVND { 
				get { return GetColumnName("COL32838823920"); } 
			}

			/// <summary>
			/// Gets column SumVND with alias  
			/// </summary>
			public string ColSumVND { 
				get { return GetColumnName("COL32838823918"); } 
			}

			/// <summary>
			/// Gets column PriceUSD with alias  
			/// </summary>
			public string ColPriceUSD { 
				get { return GetColumnName("COL32838823913"); } 
			}

			/// <summary>
			/// Gets column Created with alias  
			/// </summary>
			public string ColCreated { 
				get { return GetColumnName("COL32838823923"); } 
			}

			/// <summary>
			/// Gets column VatVND with alias  
			/// </summary>
			public string ColVatVND { 
				get { return GetColumnName("COL32838823916"); } 
			}

			/// <summary>
			/// Gets column ModifiedBy with alias  
			/// </summary>
			public string ColModifiedBy { 
				get { return GetColumnName("COL32838823926"); } 
			}

			/// <summary>
			/// Gets column Mount with alias  
			/// </summary>
			public string ColMount { 
				get { return GetColumnName("COL3283882399"); } 
			}

			/// <summary>
			/// Gets column OtherFee01 with alias  
			/// </summary>
			public string ColOtherFee01 { 
				get { return GetColumnName("COL32838823911"); } 
			}

			/// <summary>
			/// Gets column Unit with alias  
			/// </summary>
			public string ColUnit { 
				get { return GetColumnName("COL32838823921"); } 
			}

			/// <summary>
			/// Gets column Service with alias  
			/// </summary>
			public string ColService { 
				get { return GetColumnName("COL3283882398"); } 
			}

			/// <summary>
			/// Gets column LastPriceUSD with alias  
			/// </summary>
			public string ColLastPriceUSD { 
				get { return GetColumnName("COL32838823919"); } 
			}


			/// <summary>
			/// Checks whether column PriceVND is added in select statement 
			/// </summary>
			public bool IsSelectPriceVND { 
				get { return IsSelect("COL32838823914"); } 
				set { SetSelect("COL32838823914", value); } 
			}

			/// <summary>
			/// Checks whether column CreatedBy is added in select statement 
			/// </summary>
			public bool IsSelectCreatedBy { 
				get { return IsSelect("COL32838823924"); } 
				set { SetSelect("COL32838823924", value); } 
			}

			/// <summary>
			/// Checks whether column CustomerId is added in select statement 
			/// </summary>
			public bool IsSelectCustomerId { 
				get { return IsSelect("COL3283882394"); } 
				set { SetSelect("COL3283882394", value); } 
			}

			/// <summary>
			/// Checks whether column BookingId is added in select statement 
			/// </summary>
			public bool IsSelectBookingId { 
				get { return IsSelect("COL3283882395"); } 
				set { SetSelect("COL3283882395", value); } 
			}

			/// <summary>
			/// Checks whether column id is added in select statement 
			/// </summary>
			public bool IsSelectid { 
				get { return IsSelect("COL3283882391"); } 
				set { SetSelect("COL3283882391", value); } 
			}

			/// <summary>
			/// Checks whether column YearMonth is added in select statement 
			/// </summary>
			public bool IsSelectYearMonth { 
				get { return IsSelect("COL3283882392"); } 
				set { SetSelect("COL3283882392", value); } 
			}

			/// <summary>
			/// Checks whether column BuildingId is added in select statement 
			/// </summary>
			public bool IsSelectBuildingId { 
				get { return IsSelect("COL3283882393"); } 
				set { SetSelect("COL3283882393", value); } 
			}

			/// <summary>
			/// Checks whether column SumUSD is added in select statement 
			/// </summary>
			public bool IsSelectSumUSD { 
				get { return IsSelect("COL32838823917"); } 
				set { SetSelect("COL32838823917", value); } 
			}

			/// <summary>
			/// Checks whether column DelFlag is added in select statement 
			/// </summary>
			public bool IsSelectDelFlag { 
				get { return IsSelect("COL32838823927"); } 
				set { SetSelect("COL32838823927", value); } 
			}

			/// <summary>
			/// Checks whether column ServiceId is added in select statement 
			/// </summary>
			public bool IsSelectServiceId { 
				get { return IsSelect("COL3283882396"); } 
				set { SetSelect("COL3283882396", value); } 
			}

			/// <summary>
			/// Checks whether column ServiceDate is added in select statement 
			/// </summary>
			public bool IsSelectServiceDate { 
				get { return IsSelect("COL3283882397"); } 
				set { SetSelect("COL3283882397", value); } 
			}

			/// <summary>
			/// Checks whether column OtherFee02 is added in select statement 
			/// </summary>
			public bool IsSelectOtherFee02 { 
				get { return IsSelect("COL32838823912"); } 
				set { SetSelect("COL32838823912", value); } 
			}

			/// <summary>
			/// Checks whether column Comment is added in select statement 
			/// </summary>
			public bool IsSelectComment { 
				get { return IsSelect("COL32838823922"); } 
				set { SetSelect("COL32838823922", value); } 
			}

			/// <summary>
			/// Checks whether column VatUSD is added in select statement 
			/// </summary>
			public bool IsSelectVatUSD { 
				get { return IsSelect("COL32838823915"); } 
				set { SetSelect("COL32838823915", value); } 
			}

			/// <summary>
			/// Checks whether column Modified is added in select statement 
			/// </summary>
			public bool IsSelectModified { 
				get { return IsSelect("COL32838823925"); } 
				set { SetSelect("COL32838823925", value); } 
			}

			/// <summary>
			/// Checks whether column VAT is added in select statement 
			/// </summary>
			public bool IsSelectVAT { 
				get { return IsSelect("COL32838823910"); } 
				set { SetSelect("COL32838823910", value); } 
			}

			/// <summary>
			/// Checks whether column LastPriceVND is added in select statement 
			/// </summary>
			public bool IsSelectLastPriceVND { 
				get { return IsSelect("COL32838823920"); } 
				set { SetSelect("COL32838823920", value); } 
			}

			/// <summary>
			/// Checks whether column SumVND is added in select statement 
			/// </summary>
			public bool IsSelectSumVND { 
				get { return IsSelect("COL32838823918"); } 
				set { SetSelect("COL32838823918", value); } 
			}

			/// <summary>
			/// Checks whether column PriceUSD is added in select statement 
			/// </summary>
			public bool IsSelectPriceUSD { 
				get { return IsSelect("COL32838823913"); } 
				set { SetSelect("COL32838823913", value); } 
			}

			/// <summary>
			/// Checks whether column Created is added in select statement 
			/// </summary>
			public bool IsSelectCreated { 
				get { return IsSelect("COL32838823923"); } 
				set { SetSelect("COL32838823923", value); } 
			}

			/// <summary>
			/// Checks whether column VatVND is added in select statement 
			/// </summary>
			public bool IsSelectVatVND { 
				get { return IsSelect("COL32838823916"); } 
				set { SetSelect("COL32838823916", value); } 
			}

			/// <summary>
			/// Checks whether column ModifiedBy is added in select statement 
			/// </summary>
			public bool IsSelectModifiedBy { 
				get { return IsSelect("COL32838823926"); } 
				set { SetSelect("COL32838823926", value); } 
			}

			/// <summary>
			/// Checks whether column Mount is added in select statement 
			/// </summary>
			public bool IsSelectMount { 
				get { return IsSelect("COL3283882399"); } 
				set { SetSelect("COL3283882399", value); } 
			}

			/// <summary>
			/// Checks whether column OtherFee01 is added in select statement 
			/// </summary>
			public bool IsSelectOtherFee01 { 
				get { return IsSelect("COL32838823911"); } 
				set { SetSelect("COL32838823911", value); } 
			}

			/// <summary>
			/// Checks whether column Unit is added in select statement 
			/// </summary>
			public bool IsSelectUnit { 
				get { return IsSelect("COL32838823921"); } 
				set { SetSelect("COL32838823921", value); } 
			}

			/// <summary>
			/// Checks whether column Service is added in select statement 
			/// </summary>
			public bool IsSelectService { 
				get { return IsSelect("COL3283882398"); } 
				set { SetSelect("COL3283882398", value); } 
			}

			/// <summary>
			/// Checks whether column LastPriceUSD is added in select statement 
			/// </summary>
			public bool IsSelectLastPriceUSD { 
				get { return IsSelect("COL32838823919"); } 
				set { SetSelect("COL32838823919", value); } 
			}



	}
}