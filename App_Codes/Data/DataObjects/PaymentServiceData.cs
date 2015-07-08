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
	public class PaymentServiceData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ88387384";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of PaymentService 
			/// </summary>
			public PaymentServiceData(string objectID): base(objectID) {}  

			public PaymentServiceData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field PriceUSD 
			/// </summary>
			public string PriceUSD { 
				get { return GetValue("COL8838738413"); } 
				set { SetValue("COL8838738413", value); } 
			}

			/// <summary>
			/// Gets field OtherFee02 
			/// </summary>
			public string OtherFee02 { 
				get { return GetValue("COL8838738412"); } 
				set { SetValue("COL8838738412", value); } 
			}

			/// <summary>
			/// Gets field OtherFee01 
			/// </summary>
			public string OtherFee01 { 
				get { return GetValue("COL8838738411"); } 
				set { SetValue("COL8838738411", value); } 
			}

			/// <summary>
			/// Gets field VAT 
			/// </summary>
			public string VAT { 
				get { return GetValue("COL8838738410"); } 
				set { SetValue("COL8838738410", value); } 
			}

			/// <summary>
			/// Gets field SumUSD 
			/// </summary>
			public string SumUSD { 
				get { return GetValue("COL8838738417"); } 
				set { SetValue("COL8838738417", value); } 
			}

			/// <summary>
			/// Gets field VatVND 
			/// </summary>
			public string VatVND { 
				get { return GetValue("COL8838738416"); } 
				set { SetValue("COL8838738416", value); } 
			}

			/// <summary>
			/// Gets field VatUSD 
			/// </summary>
			public string VatUSD { 
				get { return GetValue("COL8838738415"); } 
				set { SetValue("COL8838738415", value); } 
			}

			/// <summary>
			/// Gets field Comment 
			/// </summary>
			public string Comment { 
				get { return GetValue("COL8838738423"); } 
				set { SetValue("COL8838738423", value); } 
			}

			/// <summary>
			/// Gets field ServiceDateTo 
			/// </summary>
			public string ServiceDateTo { 
				get { return GetValue("COL8838738422"); } 
				set { SetValue("COL8838738422", value); } 
			}

			/// <summary>
			/// Gets field ServiceDateFrom 
			/// </summary>
			public string ServiceDateFrom { 
				get { return GetValue("COL8838738421"); } 
				set { SetValue("COL8838738421", value); } 
			}

			/// <summary>
			/// Gets field LastPriceUSD 
			/// </summary>
			public string LastPriceUSD { 
				get { return GetValue("COL8838738419"); } 
				set { SetValue("COL8838738419", value); } 
			}

			/// <summary>
			/// Gets field ModifiedBy 
			/// </summary>
			public string ModifiedBy { 
				get { return GetValue("COL8838738427"); } 
				set { SetValue("COL8838738427", value); } 
			}

			/// <summary>
			/// Gets field Modified 
			/// </summary>
			public string Modified { 
				get { return GetValue("COL8838738426"); } 
				set { SetValue("COL8838738426", value); } 
			}

			/// <summary>
			/// Gets field CreatedBy 
			/// </summary>
			public string CreatedBy { 
				get { return GetValue("COL8838738425"); } 
				set { SetValue("COL8838738425", value); } 
			}

			/// <summary>
			/// Gets field Created 
			/// </summary>
			public string Created { 
				get { return GetValue("COL8838738424"); } 
				set { SetValue("COL8838738424", value); } 
			}

			/// <summary>
			/// Gets field LastPriceVND 
			/// </summary>
			public string LastPriceVND { 
				get { return GetValue("COL8838738420"); } 
				set { SetValue("COL8838738420", value); } 
			}

			/// <summary>
			/// Gets field SumVND 
			/// </summary>
			public string SumVND { 
				get { return GetValue("COL8838738418"); } 
				set { SetValue("COL8838738418", value); } 
			}

			/// <summary>
			/// Gets field DelFlag 
			/// </summary>
			public string DelFlag { 
				get { return GetValue("COL8838738428"); } 
				set { SetValue("COL8838738428", value); } 
			}

			/// <summary>
			/// Gets field PriceVND 
			/// </summary>
			public string PriceVND { 
				get { return GetValue("COL8838738414"); } 
				set { SetValue("COL8838738414", value); } 
			}

			/// <summary>
			/// Gets field CustomerId 
			/// </summary>
			public string CustomerId { 
				get { return GetValue("COL883873844"); } 
				set { SetValue("COL883873844", value); } 
			}

			/// <summary>
			/// Gets field id 
			/// </summary>
			public string id { 
				get { return GetValue("COL883873841"); } 
				set { SetValue("COL883873841", value); } 
			}

			/// <summary>
			/// Gets field YearMonth 
			/// </summary>
			public string YearMonth { 
				get { return GetValue("COL883873842"); } 
				set { SetValue("COL883873842", value); } 
			}

			/// <summary>
			/// Gets field BuildingId 
			/// </summary>
			public string BuildingId { 
				get { return GetValue("COL883873843"); } 
				set { SetValue("COL883873843", value); } 
			}

			/// <summary>
			/// Gets field ServiceId 
			/// </summary>
			public string ServiceId { 
				get { return GetValue("COL883873846"); } 
				set { SetValue("COL883873846", value); } 
			}

			/// <summary>
			/// Gets field Service 
			/// </summary>
			public string Service { 
				get { return GetValue("COL883873845"); } 
				set { SetValue("COL883873845", value); } 
			}

			/// <summary>
			/// Gets field Unit 
			/// </summary>
			public string Unit { 
				get { return GetValue("COL883873849"); } 
				set { SetValue("COL883873849", value); } 
			}

			/// <summary>
			/// Gets field Mount 
			/// </summary>
			public string Mount { 
				get { return GetValue("COL883873848"); } 
				set { SetValue("COL883873848", value); } 
			}

			/// <summary>
			/// Gets field ServiceDate 
			/// </summary>
			public string ServiceDate { 
				get { return GetValue("COL883873847"); } 
				set { SetValue("COL883873847", value); } 
			}


			/// <summary>
			/// Gets PriceUSD attribute data 
			/// </summary>
			public AttributeData GetPriceUSDAttributeData() { 
				return GetAttributeData("COL8838738413"); 
			}

			/// <summary>
			/// Gets OtherFee02 attribute data 
			/// </summary>
			public AttributeData GetOtherFee02AttributeData() { 
				return GetAttributeData("COL8838738412"); 
			}

			/// <summary>
			/// Gets OtherFee01 attribute data 
			/// </summary>
			public AttributeData GetOtherFee01AttributeData() { 
				return GetAttributeData("COL8838738411"); 
			}

			/// <summary>
			/// Gets VAT attribute data 
			/// </summary>
			public AttributeData GetVATAttributeData() { 
				return GetAttributeData("COL8838738410"); 
			}

			/// <summary>
			/// Gets SumUSD attribute data 
			/// </summary>
			public AttributeData GetSumUSDAttributeData() { 
				return GetAttributeData("COL8838738417"); 
			}

			/// <summary>
			/// Gets VatVND attribute data 
			/// </summary>
			public AttributeData GetVatVNDAttributeData() { 
				return GetAttributeData("COL8838738416"); 
			}

			/// <summary>
			/// Gets VatUSD attribute data 
			/// </summary>
			public AttributeData GetVatUSDAttributeData() { 
				return GetAttributeData("COL8838738415"); 
			}

			/// <summary>
			/// Gets Comment attribute data 
			/// </summary>
			public AttributeData GetCommentAttributeData() { 
				return GetAttributeData("COL8838738423"); 
			}

			/// <summary>
			/// Gets ServiceDateTo attribute data 
			/// </summary>
			public AttributeData GetServiceDateToAttributeData() { 
				return GetAttributeData("COL8838738422"); 
			}

			/// <summary>
			/// Gets ServiceDateFrom attribute data 
			/// </summary>
			public AttributeData GetServiceDateFromAttributeData() { 
				return GetAttributeData("COL8838738421"); 
			}

			/// <summary>
			/// Gets LastPriceUSD attribute data 
			/// </summary>
			public AttributeData GetLastPriceUSDAttributeData() { 
				return GetAttributeData("COL8838738419"); 
			}

			/// <summary>
			/// Gets ModifiedBy attribute data 
			/// </summary>
			public AttributeData GetModifiedByAttributeData() { 
				return GetAttributeData("COL8838738427"); 
			}

			/// <summary>
			/// Gets Modified attribute data 
			/// </summary>
			public AttributeData GetModifiedAttributeData() { 
				return GetAttributeData("COL8838738426"); 
			}

			/// <summary>
			/// Gets CreatedBy attribute data 
			/// </summary>
			public AttributeData GetCreatedByAttributeData() { 
				return GetAttributeData("COL8838738425"); 
			}

			/// <summary>
			/// Gets Created attribute data 
			/// </summary>
			public AttributeData GetCreatedAttributeData() { 
				return GetAttributeData("COL8838738424"); 
			}

			/// <summary>
			/// Gets LastPriceVND attribute data 
			/// </summary>
			public AttributeData GetLastPriceVNDAttributeData() { 
				return GetAttributeData("COL8838738420"); 
			}

			/// <summary>
			/// Gets SumVND attribute data 
			/// </summary>
			public AttributeData GetSumVNDAttributeData() { 
				return GetAttributeData("COL8838738418"); 
			}

			/// <summary>
			/// Gets DelFlag attribute data 
			/// </summary>
			public AttributeData GetDelFlagAttributeData() { 
				return GetAttributeData("COL8838738428"); 
			}

			/// <summary>
			/// Gets PriceVND attribute data 
			/// </summary>
			public AttributeData GetPriceVNDAttributeData() { 
				return GetAttributeData("COL8838738414"); 
			}

			/// <summary>
			/// Gets CustomerId attribute data 
			/// </summary>
			public AttributeData GetCustomerIdAttributeData() { 
				return GetAttributeData("COL883873844"); 
			}

			/// <summary>
			/// Gets id attribute data 
			/// </summary>
			public AttributeData GetidAttributeData() { 
				return GetAttributeData("COL883873841"); 
			}

			/// <summary>
			/// Gets YearMonth attribute data 
			/// </summary>
			public AttributeData GetYearMonthAttributeData() { 
				return GetAttributeData("COL883873842"); 
			}

			/// <summary>
			/// Gets BuildingId attribute data 
			/// </summary>
			public AttributeData GetBuildingIdAttributeData() { 
				return GetAttributeData("COL883873843"); 
			}

			/// <summary>
			/// Gets ServiceId attribute data 
			/// </summary>
			public AttributeData GetServiceIdAttributeData() { 
				return GetAttributeData("COL883873846"); 
			}

			/// <summary>
			/// Gets Service attribute data 
			/// </summary>
			public AttributeData GetServiceAttributeData() { 
				return GetAttributeData("COL883873845"); 
			}

			/// <summary>
			/// Gets Unit attribute data 
			/// </summary>
			public AttributeData GetUnitAttributeData() { 
				return GetAttributeData("COL883873849"); 
			}

			/// <summary>
			/// Gets Mount attribute data 
			/// </summary>
			public AttributeData GetMountAttributeData() { 
				return GetAttributeData("COL883873848"); 
			}

			/// <summary>
			/// Gets ServiceDate attribute data 
			/// </summary>
			public AttributeData GetServiceDateAttributeData() { 
				return GetAttributeData("COL883873847"); 
			}


			/// <summary>
			/// Gets column PriceUSD with alias  
			/// </summary>
			public string ColPriceUSD { 
				get { return GetColumnName("COL8838738413"); } 
			}

			/// <summary>
			/// Gets column OtherFee02 with alias  
			/// </summary>
			public string ColOtherFee02 { 
				get { return GetColumnName("COL8838738412"); } 
			}

			/// <summary>
			/// Gets column OtherFee01 with alias  
			/// </summary>
			public string ColOtherFee01 { 
				get { return GetColumnName("COL8838738411"); } 
			}

			/// <summary>
			/// Gets column VAT with alias  
			/// </summary>
			public string ColVAT { 
				get { return GetColumnName("COL8838738410"); } 
			}

			/// <summary>
			/// Gets column SumUSD with alias  
			/// </summary>
			public string ColSumUSD { 
				get { return GetColumnName("COL8838738417"); } 
			}

			/// <summary>
			/// Gets column VatVND with alias  
			/// </summary>
			public string ColVatVND { 
				get { return GetColumnName("COL8838738416"); } 
			}

			/// <summary>
			/// Gets column VatUSD with alias  
			/// </summary>
			public string ColVatUSD { 
				get { return GetColumnName("COL8838738415"); } 
			}

			/// <summary>
			/// Gets column Comment with alias  
			/// </summary>
			public string ColComment { 
				get { return GetColumnName("COL8838738423"); } 
			}

			/// <summary>
			/// Gets column ServiceDateTo with alias  
			/// </summary>
			public string ColServiceDateTo { 
				get { return GetColumnName("COL8838738422"); } 
			}

			/// <summary>
			/// Gets column ServiceDateFrom with alias  
			/// </summary>
			public string ColServiceDateFrom { 
				get { return GetColumnName("COL8838738421"); } 
			}

			/// <summary>
			/// Gets column LastPriceUSD with alias  
			/// </summary>
			public string ColLastPriceUSD { 
				get { return GetColumnName("COL8838738419"); } 
			}

			/// <summary>
			/// Gets column ModifiedBy with alias  
			/// </summary>
			public string ColModifiedBy { 
				get { return GetColumnName("COL8838738427"); } 
			}

			/// <summary>
			/// Gets column Modified with alias  
			/// </summary>
			public string ColModified { 
				get { return GetColumnName("COL8838738426"); } 
			}

			/// <summary>
			/// Gets column CreatedBy with alias  
			/// </summary>
			public string ColCreatedBy { 
				get { return GetColumnName("COL8838738425"); } 
			}

			/// <summary>
			/// Gets column Created with alias  
			/// </summary>
			public string ColCreated { 
				get { return GetColumnName("COL8838738424"); } 
			}

			/// <summary>
			/// Gets column LastPriceVND with alias  
			/// </summary>
			public string ColLastPriceVND { 
				get { return GetColumnName("COL8838738420"); } 
			}

			/// <summary>
			/// Gets column SumVND with alias  
			/// </summary>
			public string ColSumVND { 
				get { return GetColumnName("COL8838738418"); } 
			}

			/// <summary>
			/// Gets column DelFlag with alias  
			/// </summary>
			public string ColDelFlag { 
				get { return GetColumnName("COL8838738428"); } 
			}

			/// <summary>
			/// Gets column PriceVND with alias  
			/// </summary>
			public string ColPriceVND { 
				get { return GetColumnName("COL8838738414"); } 
			}

			/// <summary>
			/// Gets column CustomerId with alias  
			/// </summary>
			public string ColCustomerId { 
				get { return GetColumnName("COL883873844"); } 
			}

			/// <summary>
			/// Gets column id with alias  
			/// </summary>
			public string Colid { 
				get { return GetColumnName("COL883873841"); } 
			}

			/// <summary>
			/// Gets column YearMonth with alias  
			/// </summary>
			public string ColYearMonth { 
				get { return GetColumnName("COL883873842"); } 
			}

			/// <summary>
			/// Gets column BuildingId with alias  
			/// </summary>
			public string ColBuildingId { 
				get { return GetColumnName("COL883873843"); } 
			}

			/// <summary>
			/// Gets column ServiceId with alias  
			/// </summary>
			public string ColServiceId { 
				get { return GetColumnName("COL883873846"); } 
			}

			/// <summary>
			/// Gets column Service with alias  
			/// </summary>
			public string ColService { 
				get { return GetColumnName("COL883873845"); } 
			}

			/// <summary>
			/// Gets column Unit with alias  
			/// </summary>
			public string ColUnit { 
				get { return GetColumnName("COL883873849"); } 
			}

			/// <summary>
			/// Gets column Mount with alias  
			/// </summary>
			public string ColMount { 
				get { return GetColumnName("COL883873848"); } 
			}

			/// <summary>
			/// Gets column ServiceDate with alias  
			/// </summary>
			public string ColServiceDate { 
				get { return GetColumnName("COL883873847"); } 
			}


			/// <summary>
			/// Checks whether column PriceUSD is added in select statement 
			/// </summary>
			public bool IsSelectPriceUSD { 
				get { return IsSelect("COL8838738413"); } 
				set { SetSelect("COL8838738413", value); } 
			}

			/// <summary>
			/// Checks whether column OtherFee02 is added in select statement 
			/// </summary>
			public bool IsSelectOtherFee02 { 
				get { return IsSelect("COL8838738412"); } 
				set { SetSelect("COL8838738412", value); } 
			}

			/// <summary>
			/// Checks whether column OtherFee01 is added in select statement 
			/// </summary>
			public bool IsSelectOtherFee01 { 
				get { return IsSelect("COL8838738411"); } 
				set { SetSelect("COL8838738411", value); } 
			}

			/// <summary>
			/// Checks whether column VAT is added in select statement 
			/// </summary>
			public bool IsSelectVAT { 
				get { return IsSelect("COL8838738410"); } 
				set { SetSelect("COL8838738410", value); } 
			}

			/// <summary>
			/// Checks whether column SumUSD is added in select statement 
			/// </summary>
			public bool IsSelectSumUSD { 
				get { return IsSelect("COL8838738417"); } 
				set { SetSelect("COL8838738417", value); } 
			}

			/// <summary>
			/// Checks whether column VatVND is added in select statement 
			/// </summary>
			public bool IsSelectVatVND { 
				get { return IsSelect("COL8838738416"); } 
				set { SetSelect("COL8838738416", value); } 
			}

			/// <summary>
			/// Checks whether column VatUSD is added in select statement 
			/// </summary>
			public bool IsSelectVatUSD { 
				get { return IsSelect("COL8838738415"); } 
				set { SetSelect("COL8838738415", value); } 
			}

			/// <summary>
			/// Checks whether column Comment is added in select statement 
			/// </summary>
			public bool IsSelectComment { 
				get { return IsSelect("COL8838738423"); } 
				set { SetSelect("COL8838738423", value); } 
			}

			/// <summary>
			/// Checks whether column ServiceDateTo is added in select statement 
			/// </summary>
			public bool IsSelectServiceDateTo { 
				get { return IsSelect("COL8838738422"); } 
				set { SetSelect("COL8838738422", value); } 
			}

			/// <summary>
			/// Checks whether column ServiceDateFrom is added in select statement 
			/// </summary>
			public bool IsSelectServiceDateFrom { 
				get { return IsSelect("COL8838738421"); } 
				set { SetSelect("COL8838738421", value); } 
			}

			/// <summary>
			/// Checks whether column LastPriceUSD is added in select statement 
			/// </summary>
			public bool IsSelectLastPriceUSD { 
				get { return IsSelect("COL8838738419"); } 
				set { SetSelect("COL8838738419", value); } 
			}

			/// <summary>
			/// Checks whether column ModifiedBy is added in select statement 
			/// </summary>
			public bool IsSelectModifiedBy { 
				get { return IsSelect("COL8838738427"); } 
				set { SetSelect("COL8838738427", value); } 
			}

			/// <summary>
			/// Checks whether column Modified is added in select statement 
			/// </summary>
			public bool IsSelectModified { 
				get { return IsSelect("COL8838738426"); } 
				set { SetSelect("COL8838738426", value); } 
			}

			/// <summary>
			/// Checks whether column CreatedBy is added in select statement 
			/// </summary>
			public bool IsSelectCreatedBy { 
				get { return IsSelect("COL8838738425"); } 
				set { SetSelect("COL8838738425", value); } 
			}

			/// <summary>
			/// Checks whether column Created is added in select statement 
			/// </summary>
			public bool IsSelectCreated { 
				get { return IsSelect("COL8838738424"); } 
				set { SetSelect("COL8838738424", value); } 
			}

			/// <summary>
			/// Checks whether column LastPriceVND is added in select statement 
			/// </summary>
			public bool IsSelectLastPriceVND { 
				get { return IsSelect("COL8838738420"); } 
				set { SetSelect("COL8838738420", value); } 
			}

			/// <summary>
			/// Checks whether column SumVND is added in select statement 
			/// </summary>
			public bool IsSelectSumVND { 
				get { return IsSelect("COL8838738418"); } 
				set { SetSelect("COL8838738418", value); } 
			}

			/// <summary>
			/// Checks whether column DelFlag is added in select statement 
			/// </summary>
			public bool IsSelectDelFlag { 
				get { return IsSelect("COL8838738428"); } 
				set { SetSelect("COL8838738428", value); } 
			}

			/// <summary>
			/// Checks whether column PriceVND is added in select statement 
			/// </summary>
			public bool IsSelectPriceVND { 
				get { return IsSelect("COL8838738414"); } 
				set { SetSelect("COL8838738414", value); } 
			}

			/// <summary>
			/// Checks whether column CustomerId is added in select statement 
			/// </summary>
			public bool IsSelectCustomerId { 
				get { return IsSelect("COL883873844"); } 
				set { SetSelect("COL883873844", value); } 
			}

			/// <summary>
			/// Checks whether column id is added in select statement 
			/// </summary>
			public bool IsSelectid { 
				get { return IsSelect("COL883873841"); } 
				set { SetSelect("COL883873841", value); } 
			}

			/// <summary>
			/// Checks whether column YearMonth is added in select statement 
			/// </summary>
			public bool IsSelectYearMonth { 
				get { return IsSelect("COL883873842"); } 
				set { SetSelect("COL883873842", value); } 
			}

			/// <summary>
			/// Checks whether column BuildingId is added in select statement 
			/// </summary>
			public bool IsSelectBuildingId { 
				get { return IsSelect("COL883873843"); } 
				set { SetSelect("COL883873843", value); } 
			}

			/// <summary>
			/// Checks whether column ServiceId is added in select statement 
			/// </summary>
			public bool IsSelectServiceId { 
				get { return IsSelect("COL883873846"); } 
				set { SetSelect("COL883873846", value); } 
			}

			/// <summary>
			/// Checks whether column Service is added in select statement 
			/// </summary>
			public bool IsSelectService { 
				get { return IsSelect("COL883873845"); } 
				set { SetSelect("COL883873845", value); } 
			}

			/// <summary>
			/// Checks whether column Unit is added in select statement 
			/// </summary>
			public bool IsSelectUnit { 
				get { return IsSelect("COL883873849"); } 
				set { SetSelect("COL883873849", value); } 
			}

			/// <summary>
			/// Checks whether column Mount is added in select statement 
			/// </summary>
			public bool IsSelectMount { 
				get { return IsSelect("COL883873848"); } 
				set { SetSelect("COL883873848", value); } 
			}

			/// <summary>
			/// Checks whether column ServiceDate is added in select statement 
			/// </summary>
			public bool IsSelectServiceDate { 
				get { return IsSelect("COL883873847"); } 
				set { SetSelect("COL883873847", value); } 
			}



	}
}