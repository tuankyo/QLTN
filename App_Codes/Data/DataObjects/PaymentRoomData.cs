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
	public class PaymentRoomData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ603865218";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of PaymentRoom 
			/// </summary>
			public PaymentRoomData(string objectID): base(objectID) {}  

			public PaymentRoomData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field ContractId 
			/// </summary>
			public string ContractId { 
				get { return GetValue("COL6038652185"); } 
				set { SetValue("COL6038652185", value); } 
			}

			/// <summary>
			/// Gets field CustomerId 
			/// </summary>
			public string CustomerId { 
				get { return GetValue("COL6038652184"); } 
				set { SetValue("COL6038652184", value); } 
			}

			/// <summary>
			/// Gets field Area 
			/// </summary>
			public string Area { 
				get { return GetValue("COL6038652187"); } 
				set { SetValue("COL6038652187", value); } 
			}

			/// <summary>
			/// Gets field RoomId 
			/// </summary>
			public string RoomId { 
				get { return GetValue("COL6038652186"); } 
				set { SetValue("COL6038652186", value); } 
			}

			/// <summary>
			/// Gets field MonthManagerSumUSD 
			/// </summary>
			public string MonthManagerSumUSD { 
				get { return GetValue("COL60386521823"); } 
				set { SetValue("COL60386521823", value); } 
			}

			/// <summary>
			/// Gets field ToDate 
			/// </summary>
			public string ToDate { 
				get { return GetValue("COL60386521843"); } 
				set { SetValue("COL60386521843", value); } 
			}

			/// <summary>
			/// Gets field Name 
			/// </summary>
			public string Name { 
				get { return GetValue("COL6038652188"); } 
				set { SetValue("COL6038652188", value); } 
			}

			/// <summary>
			/// Gets field BeginContract 
			/// </summary>
			public string BeginContract { 
				get { return GetValue("COL60386521811"); } 
				set { SetValue("COL60386521811", value); } 
			}

			/// <summary>
			/// Gets field MonthManagerPriceUSD 
			/// </summary>
			public string MonthManagerPriceUSD { 
				get { return GetValue("COL60386521831"); } 
				set { SetValue("COL60386521831", value); } 
			}

			/// <summary>
			/// Gets field VAT 
			/// </summary>
			public string VAT { 
				get { return GetValue("COL60386521813"); } 
				set { SetValue("COL60386521813", value); } 
			}

			/// <summary>
			/// Gets field MonthRentSumVND 
			/// </summary>
			public string MonthRentSumVND { 
				get { return GetValue("COL60386521821"); } 
				set { SetValue("COL60386521821", value); } 
			}

			/// <summary>
			/// Gets field Created 
			/// </summary>
			public string Created { 
				get { return GetValue("COL60386521833"); } 
				set { SetValue("COL60386521833", value); } 
			}

			/// <summary>
			/// Gets field OtherFee02 
			/// </summary>
			public string OtherFee02 { 
				get { return GetValue("COL60386521815"); } 
				set { SetValue("COL60386521815", value); } 
			}

			/// <summary>
			/// Gets field Modified 
			/// </summary>
			public string Modified { 
				get { return GetValue("COL60386521835"); } 
				set { SetValue("COL60386521835", value); } 
			}

			/// <summary>
			/// Gets field LastRentSumVND 
			/// </summary>
			public string LastRentSumVND { 
				get { return GetValue("COL60386521825"); } 
				set { SetValue("COL60386521825", value); } 
			}

			/// <summary>
			/// Gets field DelFlag 
			/// </summary>
			public string DelFlag { 
				get { return GetValue("COL60386521837"); } 
				set { SetValue("COL60386521837", value); } 
			}

			/// <summary>
			/// Gets field VatManagerPriceUSD 
			/// </summary>
			public string VatManagerPriceUSD { 
				get { return GetValue("COL60386521819"); } 
				set { SetValue("COL60386521819", value); } 
			}

			/// <summary>
			/// Gets field VatManagerPriceVND 
			/// </summary>
			public string VatManagerPriceVND { 
				get { return GetValue("COL60386521818"); } 
				set { SetValue("COL60386521818", value); } 
			}

			/// <summary>
			/// Gets field ContractNo 
			/// </summary>
			public string ContractNo { 
				get { return GetValue("COL60386521839"); } 
				set { SetValue("COL60386521839", value); } 
			}

			/// <summary>
			/// Gets field MonthRentPriceUSD 
			/// </summary>
			public string MonthRentPriceUSD { 
				get { return GetValue("COL60386521829"); } 
				set { SetValue("COL60386521829", value); } 
			}

			/// <summary>
			/// Gets field MonthRentSumUSD 
			/// </summary>
			public string MonthRentSumUSD { 
				get { return GetValue("COL60386521820"); } 
				set { SetValue("COL60386521820", value); } 
			}

			/// <summary>
			/// Gets field Floor 
			/// </summary>
			public string Floor { 
				get { return GetValue("COL60386521810"); } 
				set { SetValue("COL60386521810", value); } 
			}

			/// <summary>
			/// Gets field MonthManagerPriceVND 
			/// </summary>
			public string MonthManagerPriceVND { 
				get { return GetValue("COL60386521830"); } 
				set { SetValue("COL60386521830", value); } 
			}

			/// <summary>
			/// Gets field EndContract 
			/// </summary>
			public string EndContract { 
				get { return GetValue("COL60386521812"); } 
				set { SetValue("COL60386521812", value); } 
			}

			/// <summary>
			/// Gets field RentType 
			/// </summary>
			public string RentType { 
				get { return GetValue("COL60386521840"); } 
				set { SetValue("COL60386521840", value); } 
			}

			/// <summary>
			/// Gets field OtherFee01 
			/// </summary>
			public string OtherFee01 { 
				get { return GetValue("COL60386521814"); } 
				set { SetValue("COL60386521814", value); } 
			}

			/// <summary>
			/// Gets field ManagerType 
			/// </summary>
			public string ManagerType { 
				get { return GetValue("COL60386521841"); } 
				set { SetValue("COL60386521841", value); } 
			}

			/// <summary>
			/// Gets field CreatedBy 
			/// </summary>
			public string CreatedBy { 
				get { return GetValue("COL60386521834"); } 
				set { SetValue("COL60386521834", value); } 
			}

			/// <summary>
			/// Gets field VatRentPriceVND 
			/// </summary>
			public string VatRentPriceVND { 
				get { return GetValue("COL60386521816"); } 
				set { SetValue("COL60386521816", value); } 
			}

			/// <summary>
			/// Gets field ModifiedBy 
			/// </summary>
			public string ModifiedBy { 
				get { return GetValue("COL60386521836"); } 
				set { SetValue("COL60386521836", value); } 
			}

			/// <summary>
			/// Gets field LastManagerSumVND 
			/// </summary>
			public string LastManagerSumVND { 
				get { return GetValue("COL60386521826"); } 
				set { SetValue("COL60386521826", value); } 
			}

			/// <summary>
			/// Gets field days 
			/// </summary>
			public string days { 
				get { return GetValue("COL60386521838"); } 
				set { SetValue("COL60386521838", value); } 
			}

			/// <summary>
			/// Gets field MonthRentPriceVND 
			/// </summary>
			public string MonthRentPriceVND { 
				get { return GetValue("COL60386521828"); } 
				set { SetValue("COL60386521828", value); } 
			}

			/// <summary>
			/// Gets field LastRentSumUSD 
			/// </summary>
			public string LastRentSumUSD { 
				get { return GetValue("COL60386521824"); } 
				set { SetValue("COL60386521824", value); } 
			}

			/// <summary>
			/// Gets field VatRentPriceUSD 
			/// </summary>
			public string VatRentPriceUSD { 
				get { return GetValue("COL60386521817"); } 
				set { SetValue("COL60386521817", value); } 
			}

			/// <summary>
			/// Gets field RealYearMonth 
			/// </summary>
			public string RealYearMonth { 
				get { return GetValue("COL60386521844"); } 
				set { SetValue("COL60386521844", value); } 
			}

			/// <summary>
			/// Gets field LastManagerSumUSD 
			/// </summary>
			public string LastManagerSumUSD { 
				get { return GetValue("COL60386521827"); } 
				set { SetValue("COL60386521827", value); } 
			}

			/// <summary>
			/// Gets field Comment 
			/// </summary>
			public string Comment { 
				get { return GetValue("COL60386521832"); } 
				set { SetValue("COL60386521832", value); } 
			}

			/// <summary>
			/// Gets field MonthManagerSumVND 
			/// </summary>
			public string MonthManagerSumVND { 
				get { return GetValue("COL60386521822"); } 
				set { SetValue("COL60386521822", value); } 
			}

			/// <summary>
			/// Gets field Regional 
			/// </summary>
			public string Regional { 
				get { return GetValue("COL6038652189"); } 
				set { SetValue("COL6038652189", value); } 
			}

			/// <summary>
			/// Gets field FromDate 
			/// </summary>
			public string FromDate { 
				get { return GetValue("COL60386521842"); } 
				set { SetValue("COL60386521842", value); } 
			}

			/// <summary>
			/// Gets field id 
			/// </summary>
			public string id { 
				get { return GetValue("COL6038652181"); } 
				set { SetValue("COL6038652181", value); } 
			}

			/// <summary>
			/// Gets field BuildingId 
			/// </summary>
			public string BuildingId { 
				get { return GetValue("COL6038652183"); } 
				set { SetValue("COL6038652183", value); } 
			}

			/// <summary>
			/// Gets field YearMonth 
			/// </summary>
			public string YearMonth { 
				get { return GetValue("COL6038652182"); } 
				set { SetValue("COL6038652182", value); } 
			}


			/// <summary>
			/// Gets ContractId attribute data 
			/// </summary>
			public AttributeData GetContractIdAttributeData() { 
				return GetAttributeData("COL6038652185"); 
			}

			/// <summary>
			/// Gets CustomerId attribute data 
			/// </summary>
			public AttributeData GetCustomerIdAttributeData() { 
				return GetAttributeData("COL6038652184"); 
			}

			/// <summary>
			/// Gets Area attribute data 
			/// </summary>
			public AttributeData GetAreaAttributeData() { 
				return GetAttributeData("COL6038652187"); 
			}

			/// <summary>
			/// Gets RoomId attribute data 
			/// </summary>
			public AttributeData GetRoomIdAttributeData() { 
				return GetAttributeData("COL6038652186"); 
			}

			/// <summary>
			/// Gets MonthManagerSumUSD attribute data 
			/// </summary>
			public AttributeData GetMonthManagerSumUSDAttributeData() { 
				return GetAttributeData("COL60386521823"); 
			}

			/// <summary>
			/// Gets ToDate attribute data 
			/// </summary>
			public AttributeData GetToDateAttributeData() { 
				return GetAttributeData("COL60386521843"); 
			}

			/// <summary>
			/// Gets Name attribute data 
			/// </summary>
			public AttributeData GetNameAttributeData() { 
				return GetAttributeData("COL6038652188"); 
			}

			/// <summary>
			/// Gets BeginContract attribute data 
			/// </summary>
			public AttributeData GetBeginContractAttributeData() { 
				return GetAttributeData("COL60386521811"); 
			}

			/// <summary>
			/// Gets MonthManagerPriceUSD attribute data 
			/// </summary>
			public AttributeData GetMonthManagerPriceUSDAttributeData() { 
				return GetAttributeData("COL60386521831"); 
			}

			/// <summary>
			/// Gets VAT attribute data 
			/// </summary>
			public AttributeData GetVATAttributeData() { 
				return GetAttributeData("COL60386521813"); 
			}

			/// <summary>
			/// Gets MonthRentSumVND attribute data 
			/// </summary>
			public AttributeData GetMonthRentSumVNDAttributeData() { 
				return GetAttributeData("COL60386521821"); 
			}

			/// <summary>
			/// Gets Created attribute data 
			/// </summary>
			public AttributeData GetCreatedAttributeData() { 
				return GetAttributeData("COL60386521833"); 
			}

			/// <summary>
			/// Gets OtherFee02 attribute data 
			/// </summary>
			public AttributeData GetOtherFee02AttributeData() { 
				return GetAttributeData("COL60386521815"); 
			}

			/// <summary>
			/// Gets Modified attribute data 
			/// </summary>
			public AttributeData GetModifiedAttributeData() { 
				return GetAttributeData("COL60386521835"); 
			}

			/// <summary>
			/// Gets LastRentSumVND attribute data 
			/// </summary>
			public AttributeData GetLastRentSumVNDAttributeData() { 
				return GetAttributeData("COL60386521825"); 
			}

			/// <summary>
			/// Gets DelFlag attribute data 
			/// </summary>
			public AttributeData GetDelFlagAttributeData() { 
				return GetAttributeData("COL60386521837"); 
			}

			/// <summary>
			/// Gets VatManagerPriceUSD attribute data 
			/// </summary>
			public AttributeData GetVatManagerPriceUSDAttributeData() { 
				return GetAttributeData("COL60386521819"); 
			}

			/// <summary>
			/// Gets VatManagerPriceVND attribute data 
			/// </summary>
			public AttributeData GetVatManagerPriceVNDAttributeData() { 
				return GetAttributeData("COL60386521818"); 
			}

			/// <summary>
			/// Gets ContractNo attribute data 
			/// </summary>
			public AttributeData GetContractNoAttributeData() { 
				return GetAttributeData("COL60386521839"); 
			}

			/// <summary>
			/// Gets MonthRentPriceUSD attribute data 
			/// </summary>
			public AttributeData GetMonthRentPriceUSDAttributeData() { 
				return GetAttributeData("COL60386521829"); 
			}

			/// <summary>
			/// Gets MonthRentSumUSD attribute data 
			/// </summary>
			public AttributeData GetMonthRentSumUSDAttributeData() { 
				return GetAttributeData("COL60386521820"); 
			}

			/// <summary>
			/// Gets Floor attribute data 
			/// </summary>
			public AttributeData GetFloorAttributeData() { 
				return GetAttributeData("COL60386521810"); 
			}

			/// <summary>
			/// Gets MonthManagerPriceVND attribute data 
			/// </summary>
			public AttributeData GetMonthManagerPriceVNDAttributeData() { 
				return GetAttributeData("COL60386521830"); 
			}

			/// <summary>
			/// Gets EndContract attribute data 
			/// </summary>
			public AttributeData GetEndContractAttributeData() { 
				return GetAttributeData("COL60386521812"); 
			}

			/// <summary>
			/// Gets RentType attribute data 
			/// </summary>
			public AttributeData GetRentTypeAttributeData() { 
				return GetAttributeData("COL60386521840"); 
			}

			/// <summary>
			/// Gets OtherFee01 attribute data 
			/// </summary>
			public AttributeData GetOtherFee01AttributeData() { 
				return GetAttributeData("COL60386521814"); 
			}

			/// <summary>
			/// Gets ManagerType attribute data 
			/// </summary>
			public AttributeData GetManagerTypeAttributeData() { 
				return GetAttributeData("COL60386521841"); 
			}

			/// <summary>
			/// Gets CreatedBy attribute data 
			/// </summary>
			public AttributeData GetCreatedByAttributeData() { 
				return GetAttributeData("COL60386521834"); 
			}

			/// <summary>
			/// Gets VatRentPriceVND attribute data 
			/// </summary>
			public AttributeData GetVatRentPriceVNDAttributeData() { 
				return GetAttributeData("COL60386521816"); 
			}

			/// <summary>
			/// Gets ModifiedBy attribute data 
			/// </summary>
			public AttributeData GetModifiedByAttributeData() { 
				return GetAttributeData("COL60386521836"); 
			}

			/// <summary>
			/// Gets LastManagerSumVND attribute data 
			/// </summary>
			public AttributeData GetLastManagerSumVNDAttributeData() { 
				return GetAttributeData("COL60386521826"); 
			}

			/// <summary>
			/// Gets days attribute data 
			/// </summary>
			public AttributeData GetdaysAttributeData() { 
				return GetAttributeData("COL60386521838"); 
			}

			/// <summary>
			/// Gets MonthRentPriceVND attribute data 
			/// </summary>
			public AttributeData GetMonthRentPriceVNDAttributeData() { 
				return GetAttributeData("COL60386521828"); 
			}

			/// <summary>
			/// Gets LastRentSumUSD attribute data 
			/// </summary>
			public AttributeData GetLastRentSumUSDAttributeData() { 
				return GetAttributeData("COL60386521824"); 
			}

			/// <summary>
			/// Gets VatRentPriceUSD attribute data 
			/// </summary>
			public AttributeData GetVatRentPriceUSDAttributeData() { 
				return GetAttributeData("COL60386521817"); 
			}

			/// <summary>
			/// Gets RealYearMonth attribute data 
			/// </summary>
			public AttributeData GetRealYearMonthAttributeData() { 
				return GetAttributeData("COL60386521844"); 
			}

			/// <summary>
			/// Gets LastManagerSumUSD attribute data 
			/// </summary>
			public AttributeData GetLastManagerSumUSDAttributeData() { 
				return GetAttributeData("COL60386521827"); 
			}

			/// <summary>
			/// Gets Comment attribute data 
			/// </summary>
			public AttributeData GetCommentAttributeData() { 
				return GetAttributeData("COL60386521832"); 
			}

			/// <summary>
			/// Gets MonthManagerSumVND attribute data 
			/// </summary>
			public AttributeData GetMonthManagerSumVNDAttributeData() { 
				return GetAttributeData("COL60386521822"); 
			}

			/// <summary>
			/// Gets Regional attribute data 
			/// </summary>
			public AttributeData GetRegionalAttributeData() { 
				return GetAttributeData("COL6038652189"); 
			}

			/// <summary>
			/// Gets FromDate attribute data 
			/// </summary>
			public AttributeData GetFromDateAttributeData() { 
				return GetAttributeData("COL60386521842"); 
			}

			/// <summary>
			/// Gets id attribute data 
			/// </summary>
			public AttributeData GetidAttributeData() { 
				return GetAttributeData("COL6038652181"); 
			}

			/// <summary>
			/// Gets BuildingId attribute data 
			/// </summary>
			public AttributeData GetBuildingIdAttributeData() { 
				return GetAttributeData("COL6038652183"); 
			}

			/// <summary>
			/// Gets YearMonth attribute data 
			/// </summary>
			public AttributeData GetYearMonthAttributeData() { 
				return GetAttributeData("COL6038652182"); 
			}


			/// <summary>
			/// Gets column ContractId with alias  
			/// </summary>
			public string ColContractId { 
				get { return GetColumnName("COL6038652185"); } 
			}

			/// <summary>
			/// Gets column CustomerId with alias  
			/// </summary>
			public string ColCustomerId { 
				get { return GetColumnName("COL6038652184"); } 
			}

			/// <summary>
			/// Gets column Area with alias  
			/// </summary>
			public string ColArea { 
				get { return GetColumnName("COL6038652187"); } 
			}

			/// <summary>
			/// Gets column RoomId with alias  
			/// </summary>
			public string ColRoomId { 
				get { return GetColumnName("COL6038652186"); } 
			}

			/// <summary>
			/// Gets column MonthManagerSumUSD with alias  
			/// </summary>
			public string ColMonthManagerSumUSD { 
				get { return GetColumnName("COL60386521823"); } 
			}

			/// <summary>
			/// Gets column ToDate with alias  
			/// </summary>
			public string ColToDate { 
				get { return GetColumnName("COL60386521843"); } 
			}

			/// <summary>
			/// Gets column Name with alias  
			/// </summary>
			public string ColName { 
				get { return GetColumnName("COL6038652188"); } 
			}

			/// <summary>
			/// Gets column BeginContract with alias  
			/// </summary>
			public string ColBeginContract { 
				get { return GetColumnName("COL60386521811"); } 
			}

			/// <summary>
			/// Gets column MonthManagerPriceUSD with alias  
			/// </summary>
			public string ColMonthManagerPriceUSD { 
				get { return GetColumnName("COL60386521831"); } 
			}

			/// <summary>
			/// Gets column VAT with alias  
			/// </summary>
			public string ColVAT { 
				get { return GetColumnName("COL60386521813"); } 
			}

			/// <summary>
			/// Gets column MonthRentSumVND with alias  
			/// </summary>
			public string ColMonthRentSumVND { 
				get { return GetColumnName("COL60386521821"); } 
			}

			/// <summary>
			/// Gets column Created with alias  
			/// </summary>
			public string ColCreated { 
				get { return GetColumnName("COL60386521833"); } 
			}

			/// <summary>
			/// Gets column OtherFee02 with alias  
			/// </summary>
			public string ColOtherFee02 { 
				get { return GetColumnName("COL60386521815"); } 
			}

			/// <summary>
			/// Gets column Modified with alias  
			/// </summary>
			public string ColModified { 
				get { return GetColumnName("COL60386521835"); } 
			}

			/// <summary>
			/// Gets column LastRentSumVND with alias  
			/// </summary>
			public string ColLastRentSumVND { 
				get { return GetColumnName("COL60386521825"); } 
			}

			/// <summary>
			/// Gets column DelFlag with alias  
			/// </summary>
			public string ColDelFlag { 
				get { return GetColumnName("COL60386521837"); } 
			}

			/// <summary>
			/// Gets column VatManagerPriceUSD with alias  
			/// </summary>
			public string ColVatManagerPriceUSD { 
				get { return GetColumnName("COL60386521819"); } 
			}

			/// <summary>
			/// Gets column VatManagerPriceVND with alias  
			/// </summary>
			public string ColVatManagerPriceVND { 
				get { return GetColumnName("COL60386521818"); } 
			}

			/// <summary>
			/// Gets column ContractNo with alias  
			/// </summary>
			public string ColContractNo { 
				get { return GetColumnName("COL60386521839"); } 
			}

			/// <summary>
			/// Gets column MonthRentPriceUSD with alias  
			/// </summary>
			public string ColMonthRentPriceUSD { 
				get { return GetColumnName("COL60386521829"); } 
			}

			/// <summary>
			/// Gets column MonthRentSumUSD with alias  
			/// </summary>
			public string ColMonthRentSumUSD { 
				get { return GetColumnName("COL60386521820"); } 
			}

			/// <summary>
			/// Gets column Floor with alias  
			/// </summary>
			public string ColFloor { 
				get { return GetColumnName("COL60386521810"); } 
			}

			/// <summary>
			/// Gets column MonthManagerPriceVND with alias  
			/// </summary>
			public string ColMonthManagerPriceVND { 
				get { return GetColumnName("COL60386521830"); } 
			}

			/// <summary>
			/// Gets column EndContract with alias  
			/// </summary>
			public string ColEndContract { 
				get { return GetColumnName("COL60386521812"); } 
			}

			/// <summary>
			/// Gets column RentType with alias  
			/// </summary>
			public string ColRentType { 
				get { return GetColumnName("COL60386521840"); } 
			}

			/// <summary>
			/// Gets column OtherFee01 with alias  
			/// </summary>
			public string ColOtherFee01 { 
				get { return GetColumnName("COL60386521814"); } 
			}

			/// <summary>
			/// Gets column ManagerType with alias  
			/// </summary>
			public string ColManagerType { 
				get { return GetColumnName("COL60386521841"); } 
			}

			/// <summary>
			/// Gets column CreatedBy with alias  
			/// </summary>
			public string ColCreatedBy { 
				get { return GetColumnName("COL60386521834"); } 
			}

			/// <summary>
			/// Gets column VatRentPriceVND with alias  
			/// </summary>
			public string ColVatRentPriceVND { 
				get { return GetColumnName("COL60386521816"); } 
			}

			/// <summary>
			/// Gets column ModifiedBy with alias  
			/// </summary>
			public string ColModifiedBy { 
				get { return GetColumnName("COL60386521836"); } 
			}

			/// <summary>
			/// Gets column LastManagerSumVND with alias  
			/// </summary>
			public string ColLastManagerSumVND { 
				get { return GetColumnName("COL60386521826"); } 
			}

			/// <summary>
			/// Gets column days with alias  
			/// </summary>
			public string Coldays { 
				get { return GetColumnName("COL60386521838"); } 
			}

			/// <summary>
			/// Gets column MonthRentPriceVND with alias  
			/// </summary>
			public string ColMonthRentPriceVND { 
				get { return GetColumnName("COL60386521828"); } 
			}

			/// <summary>
			/// Gets column LastRentSumUSD with alias  
			/// </summary>
			public string ColLastRentSumUSD { 
				get { return GetColumnName("COL60386521824"); } 
			}

			/// <summary>
			/// Gets column VatRentPriceUSD with alias  
			/// </summary>
			public string ColVatRentPriceUSD { 
				get { return GetColumnName("COL60386521817"); } 
			}

			/// <summary>
			/// Gets column RealYearMonth with alias  
			/// </summary>
			public string ColRealYearMonth { 
				get { return GetColumnName("COL60386521844"); } 
			}

			/// <summary>
			/// Gets column LastManagerSumUSD with alias  
			/// </summary>
			public string ColLastManagerSumUSD { 
				get { return GetColumnName("COL60386521827"); } 
			}

			/// <summary>
			/// Gets column Comment with alias  
			/// </summary>
			public string ColComment { 
				get { return GetColumnName("COL60386521832"); } 
			}

			/// <summary>
			/// Gets column MonthManagerSumVND with alias  
			/// </summary>
			public string ColMonthManagerSumVND { 
				get { return GetColumnName("COL60386521822"); } 
			}

			/// <summary>
			/// Gets column Regional with alias  
			/// </summary>
			public string ColRegional { 
				get { return GetColumnName("COL6038652189"); } 
			}

			/// <summary>
			/// Gets column FromDate with alias  
			/// </summary>
			public string ColFromDate { 
				get { return GetColumnName("COL60386521842"); } 
			}

			/// <summary>
			/// Gets column id with alias  
			/// </summary>
			public string Colid { 
				get { return GetColumnName("COL6038652181"); } 
			}

			/// <summary>
			/// Gets column BuildingId with alias  
			/// </summary>
			public string ColBuildingId { 
				get { return GetColumnName("COL6038652183"); } 
			}

			/// <summary>
			/// Gets column YearMonth with alias  
			/// </summary>
			public string ColYearMonth { 
				get { return GetColumnName("COL6038652182"); } 
			}


			/// <summary>
			/// Checks whether column ContractId is added in select statement 
			/// </summary>
			public bool IsSelectContractId { 
				get { return IsSelect("COL6038652185"); } 
				set { SetSelect("COL6038652185", value); } 
			}

			/// <summary>
			/// Checks whether column CustomerId is added in select statement 
			/// </summary>
			public bool IsSelectCustomerId { 
				get { return IsSelect("COL6038652184"); } 
				set { SetSelect("COL6038652184", value); } 
			}

			/// <summary>
			/// Checks whether column Area is added in select statement 
			/// </summary>
			public bool IsSelectArea { 
				get { return IsSelect("COL6038652187"); } 
				set { SetSelect("COL6038652187", value); } 
			}

			/// <summary>
			/// Checks whether column RoomId is added in select statement 
			/// </summary>
			public bool IsSelectRoomId { 
				get { return IsSelect("COL6038652186"); } 
				set { SetSelect("COL6038652186", value); } 
			}

			/// <summary>
			/// Checks whether column MonthManagerSumUSD is added in select statement 
			/// </summary>
			public bool IsSelectMonthManagerSumUSD { 
				get { return IsSelect("COL60386521823"); } 
				set { SetSelect("COL60386521823", value); } 
			}

			/// <summary>
			/// Checks whether column ToDate is added in select statement 
			/// </summary>
			public bool IsSelectToDate { 
				get { return IsSelect("COL60386521843"); } 
				set { SetSelect("COL60386521843", value); } 
			}

			/// <summary>
			/// Checks whether column Name is added in select statement 
			/// </summary>
			public bool IsSelectName { 
				get { return IsSelect("COL6038652188"); } 
				set { SetSelect("COL6038652188", value); } 
			}

			/// <summary>
			/// Checks whether column BeginContract is added in select statement 
			/// </summary>
			public bool IsSelectBeginContract { 
				get { return IsSelect("COL60386521811"); } 
				set { SetSelect("COL60386521811", value); } 
			}

			/// <summary>
			/// Checks whether column MonthManagerPriceUSD is added in select statement 
			/// </summary>
			public bool IsSelectMonthManagerPriceUSD { 
				get { return IsSelect("COL60386521831"); } 
				set { SetSelect("COL60386521831", value); } 
			}

			/// <summary>
			/// Checks whether column VAT is added in select statement 
			/// </summary>
			public bool IsSelectVAT { 
				get { return IsSelect("COL60386521813"); } 
				set { SetSelect("COL60386521813", value); } 
			}

			/// <summary>
			/// Checks whether column MonthRentSumVND is added in select statement 
			/// </summary>
			public bool IsSelectMonthRentSumVND { 
				get { return IsSelect("COL60386521821"); } 
				set { SetSelect("COL60386521821", value); } 
			}

			/// <summary>
			/// Checks whether column Created is added in select statement 
			/// </summary>
			public bool IsSelectCreated { 
				get { return IsSelect("COL60386521833"); } 
				set { SetSelect("COL60386521833", value); } 
			}

			/// <summary>
			/// Checks whether column OtherFee02 is added in select statement 
			/// </summary>
			public bool IsSelectOtherFee02 { 
				get { return IsSelect("COL60386521815"); } 
				set { SetSelect("COL60386521815", value); } 
			}

			/// <summary>
			/// Checks whether column Modified is added in select statement 
			/// </summary>
			public bool IsSelectModified { 
				get { return IsSelect("COL60386521835"); } 
				set { SetSelect("COL60386521835", value); } 
			}

			/// <summary>
			/// Checks whether column LastRentSumVND is added in select statement 
			/// </summary>
			public bool IsSelectLastRentSumVND { 
				get { return IsSelect("COL60386521825"); } 
				set { SetSelect("COL60386521825", value); } 
			}

			/// <summary>
			/// Checks whether column DelFlag is added in select statement 
			/// </summary>
			public bool IsSelectDelFlag { 
				get { return IsSelect("COL60386521837"); } 
				set { SetSelect("COL60386521837", value); } 
			}

			/// <summary>
			/// Checks whether column VatManagerPriceUSD is added in select statement 
			/// </summary>
			public bool IsSelectVatManagerPriceUSD { 
				get { return IsSelect("COL60386521819"); } 
				set { SetSelect("COL60386521819", value); } 
			}

			/// <summary>
			/// Checks whether column VatManagerPriceVND is added in select statement 
			/// </summary>
			public bool IsSelectVatManagerPriceVND { 
				get { return IsSelect("COL60386521818"); } 
				set { SetSelect("COL60386521818", value); } 
			}

			/// <summary>
			/// Checks whether column ContractNo is added in select statement 
			/// </summary>
			public bool IsSelectContractNo { 
				get { return IsSelect("COL60386521839"); } 
				set { SetSelect("COL60386521839", value); } 
			}

			/// <summary>
			/// Checks whether column MonthRentPriceUSD is added in select statement 
			/// </summary>
			public bool IsSelectMonthRentPriceUSD { 
				get { return IsSelect("COL60386521829"); } 
				set { SetSelect("COL60386521829", value); } 
			}

			/// <summary>
			/// Checks whether column MonthRentSumUSD is added in select statement 
			/// </summary>
			public bool IsSelectMonthRentSumUSD { 
				get { return IsSelect("COL60386521820"); } 
				set { SetSelect("COL60386521820", value); } 
			}

			/// <summary>
			/// Checks whether column Floor is added in select statement 
			/// </summary>
			public bool IsSelectFloor { 
				get { return IsSelect("COL60386521810"); } 
				set { SetSelect("COL60386521810", value); } 
			}

			/// <summary>
			/// Checks whether column MonthManagerPriceVND is added in select statement 
			/// </summary>
			public bool IsSelectMonthManagerPriceVND { 
				get { return IsSelect("COL60386521830"); } 
				set { SetSelect("COL60386521830", value); } 
			}

			/// <summary>
			/// Checks whether column EndContract is added in select statement 
			/// </summary>
			public bool IsSelectEndContract { 
				get { return IsSelect("COL60386521812"); } 
				set { SetSelect("COL60386521812", value); } 
			}

			/// <summary>
			/// Checks whether column RentType is added in select statement 
			/// </summary>
			public bool IsSelectRentType { 
				get { return IsSelect("COL60386521840"); } 
				set { SetSelect("COL60386521840", value); } 
			}

			/// <summary>
			/// Checks whether column OtherFee01 is added in select statement 
			/// </summary>
			public bool IsSelectOtherFee01 { 
				get { return IsSelect("COL60386521814"); } 
				set { SetSelect("COL60386521814", value); } 
			}

			/// <summary>
			/// Checks whether column ManagerType is added in select statement 
			/// </summary>
			public bool IsSelectManagerType { 
				get { return IsSelect("COL60386521841"); } 
				set { SetSelect("COL60386521841", value); } 
			}

			/// <summary>
			/// Checks whether column CreatedBy is added in select statement 
			/// </summary>
			public bool IsSelectCreatedBy { 
				get { return IsSelect("COL60386521834"); } 
				set { SetSelect("COL60386521834", value); } 
			}

			/// <summary>
			/// Checks whether column VatRentPriceVND is added in select statement 
			/// </summary>
			public bool IsSelectVatRentPriceVND { 
				get { return IsSelect("COL60386521816"); } 
				set { SetSelect("COL60386521816", value); } 
			}

			/// <summary>
			/// Checks whether column ModifiedBy is added in select statement 
			/// </summary>
			public bool IsSelectModifiedBy { 
				get { return IsSelect("COL60386521836"); } 
				set { SetSelect("COL60386521836", value); } 
			}

			/// <summary>
			/// Checks whether column LastManagerSumVND is added in select statement 
			/// </summary>
			public bool IsSelectLastManagerSumVND { 
				get { return IsSelect("COL60386521826"); } 
				set { SetSelect("COL60386521826", value); } 
			}

			/// <summary>
			/// Checks whether column days is added in select statement 
			/// </summary>
			public bool IsSelectdays { 
				get { return IsSelect("COL60386521838"); } 
				set { SetSelect("COL60386521838", value); } 
			}

			/// <summary>
			/// Checks whether column MonthRentPriceVND is added in select statement 
			/// </summary>
			public bool IsSelectMonthRentPriceVND { 
				get { return IsSelect("COL60386521828"); } 
				set { SetSelect("COL60386521828", value); } 
			}

			/// <summary>
			/// Checks whether column LastRentSumUSD is added in select statement 
			/// </summary>
			public bool IsSelectLastRentSumUSD { 
				get { return IsSelect("COL60386521824"); } 
				set { SetSelect("COL60386521824", value); } 
			}

			/// <summary>
			/// Checks whether column VatRentPriceUSD is added in select statement 
			/// </summary>
			public bool IsSelectVatRentPriceUSD { 
				get { return IsSelect("COL60386521817"); } 
				set { SetSelect("COL60386521817", value); } 
			}

			/// <summary>
			/// Checks whether column RealYearMonth is added in select statement 
			/// </summary>
			public bool IsSelectRealYearMonth { 
				get { return IsSelect("COL60386521844"); } 
				set { SetSelect("COL60386521844", value); } 
			}

			/// <summary>
			/// Checks whether column LastManagerSumUSD is added in select statement 
			/// </summary>
			public bool IsSelectLastManagerSumUSD { 
				get { return IsSelect("COL60386521827"); } 
				set { SetSelect("COL60386521827", value); } 
			}

			/// <summary>
			/// Checks whether column Comment is added in select statement 
			/// </summary>
			public bool IsSelectComment { 
				get { return IsSelect("COL60386521832"); } 
				set { SetSelect("COL60386521832", value); } 
			}

			/// <summary>
			/// Checks whether column MonthManagerSumVND is added in select statement 
			/// </summary>
			public bool IsSelectMonthManagerSumVND { 
				get { return IsSelect("COL60386521822"); } 
				set { SetSelect("COL60386521822", value); } 
			}

			/// <summary>
			/// Checks whether column Regional is added in select statement 
			/// </summary>
			public bool IsSelectRegional { 
				get { return IsSelect("COL6038652189"); } 
				set { SetSelect("COL6038652189", value); } 
			}

			/// <summary>
			/// Checks whether column FromDate is added in select statement 
			/// </summary>
			public bool IsSelectFromDate { 
				get { return IsSelect("COL60386521842"); } 
				set { SetSelect("COL60386521842", value); } 
			}

			/// <summary>
			/// Checks whether column id is added in select statement 
			/// </summary>
			public bool IsSelectid { 
				get { return IsSelect("COL6038652181"); } 
				set { SetSelect("COL6038652181", value); } 
			}

			/// <summary>
			/// Checks whether column BuildingId is added in select statement 
			/// </summary>
			public bool IsSelectBuildingId { 
				get { return IsSelect("COL6038652183"); } 
				set { SetSelect("COL6038652183", value); } 
			}

			/// <summary>
			/// Checks whether column YearMonth is added in select statement 
			/// </summary>
			public bool IsSelectYearMonth { 
				get { return IsSelect("COL6038652182"); } 
				set { SetSelect("COL6038652182", value); } 
			}



	}
}