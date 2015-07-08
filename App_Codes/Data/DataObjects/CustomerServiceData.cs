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
	public class CustomerServiceData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ56387270";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of CustomerService 
			/// </summary>
			public CustomerServiceData(string objectID): base(objectID) {}  

			public CustomerServiceData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field ServiceDateFrom 
			/// </summary>
			public string ServiceDateFrom { 
				get { return GetValue("COL563872706"); } 
				set { SetValue("COL563872706", value); } 
			}

			/// <summary>
			/// Gets field Unit 
			/// </summary>
			public string Unit { 
				get { return GetValue("COL563872705"); } 
				set { SetValue("COL563872705", value); } 
			}

			/// <summary>
			/// Gets field PriceVND 
			/// </summary>
			public string PriceVND { 
				get { return GetValue("COL563872709"); } 
				set { SetValue("COL563872709", value); } 
			}

			/// <summary>
			/// Gets field Service 
			/// </summary>
			public string Service { 
				get { return GetValue("COL563872703"); } 
				set { SetValue("COL563872703", value); } 
			}

			/// <summary>
			/// Gets field Mount 
			/// </summary>
			public string Mount { 
				get { return GetValue("COL563872704"); } 
				set { SetValue("COL563872704", value); } 
			}

			/// <summary>
			/// Gets field CustomerId 
			/// </summary>
			public string CustomerId { 
				get { return GetValue("COL563872702"); } 
				set { SetValue("COL563872702", value); } 
			}

			/// <summary>
			/// Gets field YearMonth 
			/// </summary>
			public string YearMonth { 
				get { return GetValue("COL563872708"); } 
				set { SetValue("COL563872708", value); } 
			}

			/// <summary>
			/// Gets field id 
			/// </summary>
			public string id { 
				get { return GetValue("COL563872701"); } 
				set { SetValue("COL563872701", value); } 
			}

			/// <summary>
			/// Gets field ModifiedBy 
			/// </summary>
			public string ModifiedBy { 
				get { return GetValue("COL5638727018"); } 
				set { SetValue("COL5638727018", value); } 
			}

			/// <summary>
			/// Gets field DelFlag 
			/// </summary>
			public string DelFlag { 
				get { return GetValue("COL5638727019"); } 
				set { SetValue("COL5638727019", value); } 
			}

			/// <summary>
			/// Gets field CreatedBy 
			/// </summary>
			public string CreatedBy { 
				get { return GetValue("COL5638727016"); } 
				set { SetValue("COL5638727016", value); } 
			}

			/// <summary>
			/// Gets field Modified 
			/// </summary>
			public string Modified { 
				get { return GetValue("COL5638727017"); } 
				set { SetValue("COL5638727017", value); } 
			}

			/// <summary>
			/// Gets field Comment 
			/// </summary>
			public string Comment { 
				get { return GetValue("COL5638727014"); } 
				set { SetValue("COL5638727014", value); } 
			}

			/// <summary>
			/// Gets field Created 
			/// </summary>
			public string Created { 
				get { return GetValue("COL5638727015"); } 
				set { SetValue("COL5638727015", value); } 
			}

			/// <summary>
			/// Gets field OtherFee01 
			/// </summary>
			public string OtherFee01 { 
				get { return GetValue("COL5638727012"); } 
				set { SetValue("COL5638727012", value); } 
			}

			/// <summary>
			/// Gets field OtherFee02 
			/// </summary>
			public string OtherFee02 { 
				get { return GetValue("COL5638727013"); } 
				set { SetValue("COL5638727013", value); } 
			}

			/// <summary>
			/// Gets field PriceUSD 
			/// </summary>
			public string PriceUSD { 
				get { return GetValue("COL5638727010"); } 
				set { SetValue("COL5638727010", value); } 
			}

			/// <summary>
			/// Gets field VAT 
			/// </summary>
			public string VAT { 
				get { return GetValue("COL5638727011"); } 
				set { SetValue("COL5638727011", value); } 
			}

			/// <summary>
			/// Gets field ServiceDateTo 
			/// </summary>
			public string ServiceDateTo { 
				get { return GetValue("COL563872707"); } 
				set { SetValue("COL563872707", value); } 
			}


			/// <summary>
			/// Gets ServiceDateFrom attribute data 
			/// </summary>
			public AttributeData GetServiceDateFromAttributeData() { 
				return GetAttributeData("COL563872706"); 
			}

			/// <summary>
			/// Gets Unit attribute data 
			/// </summary>
			public AttributeData GetUnitAttributeData() { 
				return GetAttributeData("COL563872705"); 
			}

			/// <summary>
			/// Gets PriceVND attribute data 
			/// </summary>
			public AttributeData GetPriceVNDAttributeData() { 
				return GetAttributeData("COL563872709"); 
			}

			/// <summary>
			/// Gets Service attribute data 
			/// </summary>
			public AttributeData GetServiceAttributeData() { 
				return GetAttributeData("COL563872703"); 
			}

			/// <summary>
			/// Gets Mount attribute data 
			/// </summary>
			public AttributeData GetMountAttributeData() { 
				return GetAttributeData("COL563872704"); 
			}

			/// <summary>
			/// Gets CustomerId attribute data 
			/// </summary>
			public AttributeData GetCustomerIdAttributeData() { 
				return GetAttributeData("COL563872702"); 
			}

			/// <summary>
			/// Gets YearMonth attribute data 
			/// </summary>
			public AttributeData GetYearMonthAttributeData() { 
				return GetAttributeData("COL563872708"); 
			}

			/// <summary>
			/// Gets id attribute data 
			/// </summary>
			public AttributeData GetidAttributeData() { 
				return GetAttributeData("COL563872701"); 
			}

			/// <summary>
			/// Gets ModifiedBy attribute data 
			/// </summary>
			public AttributeData GetModifiedByAttributeData() { 
				return GetAttributeData("COL5638727018"); 
			}

			/// <summary>
			/// Gets DelFlag attribute data 
			/// </summary>
			public AttributeData GetDelFlagAttributeData() { 
				return GetAttributeData("COL5638727019"); 
			}

			/// <summary>
			/// Gets CreatedBy attribute data 
			/// </summary>
			public AttributeData GetCreatedByAttributeData() { 
				return GetAttributeData("COL5638727016"); 
			}

			/// <summary>
			/// Gets Modified attribute data 
			/// </summary>
			public AttributeData GetModifiedAttributeData() { 
				return GetAttributeData("COL5638727017"); 
			}

			/// <summary>
			/// Gets Comment attribute data 
			/// </summary>
			public AttributeData GetCommentAttributeData() { 
				return GetAttributeData("COL5638727014"); 
			}

			/// <summary>
			/// Gets Created attribute data 
			/// </summary>
			public AttributeData GetCreatedAttributeData() { 
				return GetAttributeData("COL5638727015"); 
			}

			/// <summary>
			/// Gets OtherFee01 attribute data 
			/// </summary>
			public AttributeData GetOtherFee01AttributeData() { 
				return GetAttributeData("COL5638727012"); 
			}

			/// <summary>
			/// Gets OtherFee02 attribute data 
			/// </summary>
			public AttributeData GetOtherFee02AttributeData() { 
				return GetAttributeData("COL5638727013"); 
			}

			/// <summary>
			/// Gets PriceUSD attribute data 
			/// </summary>
			public AttributeData GetPriceUSDAttributeData() { 
				return GetAttributeData("COL5638727010"); 
			}

			/// <summary>
			/// Gets VAT attribute data 
			/// </summary>
			public AttributeData GetVATAttributeData() { 
				return GetAttributeData("COL5638727011"); 
			}

			/// <summary>
			/// Gets ServiceDateTo attribute data 
			/// </summary>
			public AttributeData GetServiceDateToAttributeData() { 
				return GetAttributeData("COL563872707"); 
			}


			/// <summary>
			/// Gets column ServiceDateFrom with alias  
			/// </summary>
			public string ColServiceDateFrom { 
				get { return GetColumnName("COL563872706"); } 
			}

			/// <summary>
			/// Gets column Unit with alias  
			/// </summary>
			public string ColUnit { 
				get { return GetColumnName("COL563872705"); } 
			}

			/// <summary>
			/// Gets column PriceVND with alias  
			/// </summary>
			public string ColPriceVND { 
				get { return GetColumnName("COL563872709"); } 
			}

			/// <summary>
			/// Gets column Service with alias  
			/// </summary>
			public string ColService { 
				get { return GetColumnName("COL563872703"); } 
			}

			/// <summary>
			/// Gets column Mount with alias  
			/// </summary>
			public string ColMount { 
				get { return GetColumnName("COL563872704"); } 
			}

			/// <summary>
			/// Gets column CustomerId with alias  
			/// </summary>
			public string ColCustomerId { 
				get { return GetColumnName("COL563872702"); } 
			}

			/// <summary>
			/// Gets column YearMonth with alias  
			/// </summary>
			public string ColYearMonth { 
				get { return GetColumnName("COL563872708"); } 
			}

			/// <summary>
			/// Gets column id with alias  
			/// </summary>
			public string Colid { 
				get { return GetColumnName("COL563872701"); } 
			}

			/// <summary>
			/// Gets column ModifiedBy with alias  
			/// </summary>
			public string ColModifiedBy { 
				get { return GetColumnName("COL5638727018"); } 
			}

			/// <summary>
			/// Gets column DelFlag with alias  
			/// </summary>
			public string ColDelFlag { 
				get { return GetColumnName("COL5638727019"); } 
			}

			/// <summary>
			/// Gets column CreatedBy with alias  
			/// </summary>
			public string ColCreatedBy { 
				get { return GetColumnName("COL5638727016"); } 
			}

			/// <summary>
			/// Gets column Modified with alias  
			/// </summary>
			public string ColModified { 
				get { return GetColumnName("COL5638727017"); } 
			}

			/// <summary>
			/// Gets column Comment with alias  
			/// </summary>
			public string ColComment { 
				get { return GetColumnName("COL5638727014"); } 
			}

			/// <summary>
			/// Gets column Created with alias  
			/// </summary>
			public string ColCreated { 
				get { return GetColumnName("COL5638727015"); } 
			}

			/// <summary>
			/// Gets column OtherFee01 with alias  
			/// </summary>
			public string ColOtherFee01 { 
				get { return GetColumnName("COL5638727012"); } 
			}

			/// <summary>
			/// Gets column OtherFee02 with alias  
			/// </summary>
			public string ColOtherFee02 { 
				get { return GetColumnName("COL5638727013"); } 
			}

			/// <summary>
			/// Gets column PriceUSD with alias  
			/// </summary>
			public string ColPriceUSD { 
				get { return GetColumnName("COL5638727010"); } 
			}

			/// <summary>
			/// Gets column VAT with alias  
			/// </summary>
			public string ColVAT { 
				get { return GetColumnName("COL5638727011"); } 
			}

			/// <summary>
			/// Gets column ServiceDateTo with alias  
			/// </summary>
			public string ColServiceDateTo { 
				get { return GetColumnName("COL563872707"); } 
			}


			/// <summary>
			/// Checks whether column ServiceDateFrom is added in select statement 
			/// </summary>
			public bool IsSelectServiceDateFrom { 
				get { return IsSelect("COL563872706"); } 
				set { SetSelect("COL563872706", value); } 
			}

			/// <summary>
			/// Checks whether column Unit is added in select statement 
			/// </summary>
			public bool IsSelectUnit { 
				get { return IsSelect("COL563872705"); } 
				set { SetSelect("COL563872705", value); } 
			}

			/// <summary>
			/// Checks whether column PriceVND is added in select statement 
			/// </summary>
			public bool IsSelectPriceVND { 
				get { return IsSelect("COL563872709"); } 
				set { SetSelect("COL563872709", value); } 
			}

			/// <summary>
			/// Checks whether column Service is added in select statement 
			/// </summary>
			public bool IsSelectService { 
				get { return IsSelect("COL563872703"); } 
				set { SetSelect("COL563872703", value); } 
			}

			/// <summary>
			/// Checks whether column Mount is added in select statement 
			/// </summary>
			public bool IsSelectMount { 
				get { return IsSelect("COL563872704"); } 
				set { SetSelect("COL563872704", value); } 
			}

			/// <summary>
			/// Checks whether column CustomerId is added in select statement 
			/// </summary>
			public bool IsSelectCustomerId { 
				get { return IsSelect("COL563872702"); } 
				set { SetSelect("COL563872702", value); } 
			}

			/// <summary>
			/// Checks whether column YearMonth is added in select statement 
			/// </summary>
			public bool IsSelectYearMonth { 
				get { return IsSelect("COL563872708"); } 
				set { SetSelect("COL563872708", value); } 
			}

			/// <summary>
			/// Checks whether column id is added in select statement 
			/// </summary>
			public bool IsSelectid { 
				get { return IsSelect("COL563872701"); } 
				set { SetSelect("COL563872701", value); } 
			}

			/// <summary>
			/// Checks whether column ModifiedBy is added in select statement 
			/// </summary>
			public bool IsSelectModifiedBy { 
				get { return IsSelect("COL5638727018"); } 
				set { SetSelect("COL5638727018", value); } 
			}

			/// <summary>
			/// Checks whether column DelFlag is added in select statement 
			/// </summary>
			public bool IsSelectDelFlag { 
				get { return IsSelect("COL5638727019"); } 
				set { SetSelect("COL5638727019", value); } 
			}

			/// <summary>
			/// Checks whether column CreatedBy is added in select statement 
			/// </summary>
			public bool IsSelectCreatedBy { 
				get { return IsSelect("COL5638727016"); } 
				set { SetSelect("COL5638727016", value); } 
			}

			/// <summary>
			/// Checks whether column Modified is added in select statement 
			/// </summary>
			public bool IsSelectModified { 
				get { return IsSelect("COL5638727017"); } 
				set { SetSelect("COL5638727017", value); } 
			}

			/// <summary>
			/// Checks whether column Comment is added in select statement 
			/// </summary>
			public bool IsSelectComment { 
				get { return IsSelect("COL5638727014"); } 
				set { SetSelect("COL5638727014", value); } 
			}

			/// <summary>
			/// Checks whether column Created is added in select statement 
			/// </summary>
			public bool IsSelectCreated { 
				get { return IsSelect("COL5638727015"); } 
				set { SetSelect("COL5638727015", value); } 
			}

			/// <summary>
			/// Checks whether column OtherFee01 is added in select statement 
			/// </summary>
			public bool IsSelectOtherFee01 { 
				get { return IsSelect("COL5638727012"); } 
				set { SetSelect("COL5638727012", value); } 
			}

			/// <summary>
			/// Checks whether column OtherFee02 is added in select statement 
			/// </summary>
			public bool IsSelectOtherFee02 { 
				get { return IsSelect("COL5638727013"); } 
				set { SetSelect("COL5638727013", value); } 
			}

			/// <summary>
			/// Checks whether column PriceUSD is added in select statement 
			/// </summary>
			public bool IsSelectPriceUSD { 
				get { return IsSelect("COL5638727010"); } 
				set { SetSelect("COL5638727010", value); } 
			}

			/// <summary>
			/// Checks whether column VAT is added in select statement 
			/// </summary>
			public bool IsSelectVAT { 
				get { return IsSelect("COL5638727011"); } 
				set { SetSelect("COL5638727011", value); } 
			}

			/// <summary>
			/// Checks whether column ServiceDateTo is added in select statement 
			/// </summary>
			public bool IsSelectServiceDateTo { 
				get { return IsSelect("COL563872707"); } 
				set { SetSelect("COL563872707", value); } 
			}



	}
}