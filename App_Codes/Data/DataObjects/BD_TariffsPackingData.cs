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
	public class BD_TariffsPackingData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ2075870462";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of BD_TariffsPacking 
			/// </summary>
			public BD_TariffsPackingData(string objectID): base(objectID) {}  

			public BD_TariffsPackingData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field OtherFee02 
			/// </summary>
			public string OtherFee02 { 
				get { return GetValue("COL20758704629"); } 
				set { SetValue("COL20758704629", value); } 
			}

			/// <summary>
			/// Gets field Name 
			/// </summary>
			public string Name { 
				get { return GetValue("COL20758704622"); } 
				set { SetValue("COL20758704622", value); } 
			}

			/// <summary>
			/// Gets field Created 
			/// </summary>
			public string Created { 
				get { return GetValue("COL207587046211"); } 
				set { SetValue("COL207587046211", value); } 
			}

			/// <summary>
			/// Gets field Comment 
			/// </summary>
			public string Comment { 
				get { return GetValue("COL207587046210"); } 
				set { SetValue("COL207587046210", value); } 
			}

			/// <summary>
			/// Gets field DelFlag 
			/// </summary>
			public string DelFlag { 
				get { return GetValue("COL207587046215"); } 
				set { SetValue("COL207587046215", value); } 
			}

			/// <summary>
			/// Gets field OtherFee01 
			/// </summary>
			public string OtherFee01 { 
				get { return GetValue("COL20758704628"); } 
				set { SetValue("COL20758704628", value); } 
			}

			/// <summary>
			/// Gets field PriceVND 
			/// </summary>
			public string PriceVND { 
				get { return GetValue("COL20758704625"); } 
				set { SetValue("COL20758704625", value); } 
			}

			/// <summary>
			/// Gets field ModifiedBy 
			/// </summary>
			public string ModifiedBy { 
				get { return GetValue("COL207587046214"); } 
				set { SetValue("COL207587046214", value); } 
			}

			/// <summary>
			/// Gets field Vat 
			/// </summary>
			public string Vat { 
				get { return GetValue("COL20758704627"); } 
				set { SetValue("COL20758704627", value); } 
			}

			/// <summary>
			/// Gets field PriceUSD 
			/// </summary>
			public string PriceUSD { 
				get { return GetValue("COL20758704626"); } 
				set { SetValue("COL20758704626", value); } 
			}

			/// <summary>
			/// Gets field VehicleTypeId 
			/// </summary>
			public string VehicleTypeId { 
				get { return GetValue("COL20758704623"); } 
				set { SetValue("COL20758704623", value); } 
			}

			/// <summary>
			/// Gets field Modified 
			/// </summary>
			public string Modified { 
				get { return GetValue("COL207587046213"); } 
				set { SetValue("COL207587046213", value); } 
			}

			/// <summary>
			/// Gets field BuildingId 
			/// </summary>
			public string BuildingId { 
				get { return GetValue("COL20758704624"); } 
				set { SetValue("COL20758704624", value); } 
			}

			/// <summary>
			/// Gets field id 
			/// </summary>
			public string id { 
				get { return GetValue("COL20758704621"); } 
				set { SetValue("COL20758704621", value); } 
			}

			/// <summary>
			/// Gets field CreatedBy 
			/// </summary>
			public string CreatedBy { 
				get { return GetValue("COL207587046212"); } 
				set { SetValue("COL207587046212", value); } 
			}


			/// <summary>
			/// Gets OtherFee02 attribute data 
			/// </summary>
			public AttributeData GetOtherFee02AttributeData() { 
				return GetAttributeData("COL20758704629"); 
			}

			/// <summary>
			/// Gets Name attribute data 
			/// </summary>
			public AttributeData GetNameAttributeData() { 
				return GetAttributeData("COL20758704622"); 
			}

			/// <summary>
			/// Gets Created attribute data 
			/// </summary>
			public AttributeData GetCreatedAttributeData() { 
				return GetAttributeData("COL207587046211"); 
			}

			/// <summary>
			/// Gets Comment attribute data 
			/// </summary>
			public AttributeData GetCommentAttributeData() { 
				return GetAttributeData("COL207587046210"); 
			}

			/// <summary>
			/// Gets DelFlag attribute data 
			/// </summary>
			public AttributeData GetDelFlagAttributeData() { 
				return GetAttributeData("COL207587046215"); 
			}

			/// <summary>
			/// Gets OtherFee01 attribute data 
			/// </summary>
			public AttributeData GetOtherFee01AttributeData() { 
				return GetAttributeData("COL20758704628"); 
			}

			/// <summary>
			/// Gets PriceVND attribute data 
			/// </summary>
			public AttributeData GetPriceVNDAttributeData() { 
				return GetAttributeData("COL20758704625"); 
			}

			/// <summary>
			/// Gets ModifiedBy attribute data 
			/// </summary>
			public AttributeData GetModifiedByAttributeData() { 
				return GetAttributeData("COL207587046214"); 
			}

			/// <summary>
			/// Gets Vat attribute data 
			/// </summary>
			public AttributeData GetVatAttributeData() { 
				return GetAttributeData("COL20758704627"); 
			}

			/// <summary>
			/// Gets PriceUSD attribute data 
			/// </summary>
			public AttributeData GetPriceUSDAttributeData() { 
				return GetAttributeData("COL20758704626"); 
			}

			/// <summary>
			/// Gets VehicleTypeId attribute data 
			/// </summary>
			public AttributeData GetVehicleTypeIdAttributeData() { 
				return GetAttributeData("COL20758704623"); 
			}

			/// <summary>
			/// Gets Modified attribute data 
			/// </summary>
			public AttributeData GetModifiedAttributeData() { 
				return GetAttributeData("COL207587046213"); 
			}

			/// <summary>
			/// Gets BuildingId attribute data 
			/// </summary>
			public AttributeData GetBuildingIdAttributeData() { 
				return GetAttributeData("COL20758704624"); 
			}

			/// <summary>
			/// Gets id attribute data 
			/// </summary>
			public AttributeData GetidAttributeData() { 
				return GetAttributeData("COL20758704621"); 
			}

			/// <summary>
			/// Gets CreatedBy attribute data 
			/// </summary>
			public AttributeData GetCreatedByAttributeData() { 
				return GetAttributeData("COL207587046212"); 
			}


			/// <summary>
			/// Gets column OtherFee02 with alias  
			/// </summary>
			public string ColOtherFee02 { 
				get { return GetColumnName("COL20758704629"); } 
			}

			/// <summary>
			/// Gets column Name with alias  
			/// </summary>
			public string ColName { 
				get { return GetColumnName("COL20758704622"); } 
			}

			/// <summary>
			/// Gets column Created with alias  
			/// </summary>
			public string ColCreated { 
				get { return GetColumnName("COL207587046211"); } 
			}

			/// <summary>
			/// Gets column Comment with alias  
			/// </summary>
			public string ColComment { 
				get { return GetColumnName("COL207587046210"); } 
			}

			/// <summary>
			/// Gets column DelFlag with alias  
			/// </summary>
			public string ColDelFlag { 
				get { return GetColumnName("COL207587046215"); } 
			}

			/// <summary>
			/// Gets column OtherFee01 with alias  
			/// </summary>
			public string ColOtherFee01 { 
				get { return GetColumnName("COL20758704628"); } 
			}

			/// <summary>
			/// Gets column PriceVND with alias  
			/// </summary>
			public string ColPriceVND { 
				get { return GetColumnName("COL20758704625"); } 
			}

			/// <summary>
			/// Gets column ModifiedBy with alias  
			/// </summary>
			public string ColModifiedBy { 
				get { return GetColumnName("COL207587046214"); } 
			}

			/// <summary>
			/// Gets column Vat with alias  
			/// </summary>
			public string ColVat { 
				get { return GetColumnName("COL20758704627"); } 
			}

			/// <summary>
			/// Gets column PriceUSD with alias  
			/// </summary>
			public string ColPriceUSD { 
				get { return GetColumnName("COL20758704626"); } 
			}

			/// <summary>
			/// Gets column VehicleTypeId with alias  
			/// </summary>
			public string ColVehicleTypeId { 
				get { return GetColumnName("COL20758704623"); } 
			}

			/// <summary>
			/// Gets column Modified with alias  
			/// </summary>
			public string ColModified { 
				get { return GetColumnName("COL207587046213"); } 
			}

			/// <summary>
			/// Gets column BuildingId with alias  
			/// </summary>
			public string ColBuildingId { 
				get { return GetColumnName("COL20758704624"); } 
			}

			/// <summary>
			/// Gets column id with alias  
			/// </summary>
			public string Colid { 
				get { return GetColumnName("COL20758704621"); } 
			}

			/// <summary>
			/// Gets column CreatedBy with alias  
			/// </summary>
			public string ColCreatedBy { 
				get { return GetColumnName("COL207587046212"); } 
			}


			/// <summary>
			/// Checks whether column OtherFee02 is added in select statement 
			/// </summary>
			public bool IsSelectOtherFee02 { 
				get { return IsSelect("COL20758704629"); } 
				set { SetSelect("COL20758704629", value); } 
			}

			/// <summary>
			/// Checks whether column Name is added in select statement 
			/// </summary>
			public bool IsSelectName { 
				get { return IsSelect("COL20758704622"); } 
				set { SetSelect("COL20758704622", value); } 
			}

			/// <summary>
			/// Checks whether column Created is added in select statement 
			/// </summary>
			public bool IsSelectCreated { 
				get { return IsSelect("COL207587046211"); } 
				set { SetSelect("COL207587046211", value); } 
			}

			/// <summary>
			/// Checks whether column Comment is added in select statement 
			/// </summary>
			public bool IsSelectComment { 
				get { return IsSelect("COL207587046210"); } 
				set { SetSelect("COL207587046210", value); } 
			}

			/// <summary>
			/// Checks whether column DelFlag is added in select statement 
			/// </summary>
			public bool IsSelectDelFlag { 
				get { return IsSelect("COL207587046215"); } 
				set { SetSelect("COL207587046215", value); } 
			}

			/// <summary>
			/// Checks whether column OtherFee01 is added in select statement 
			/// </summary>
			public bool IsSelectOtherFee01 { 
				get { return IsSelect("COL20758704628"); } 
				set { SetSelect("COL20758704628", value); } 
			}

			/// <summary>
			/// Checks whether column PriceVND is added in select statement 
			/// </summary>
			public bool IsSelectPriceVND { 
				get { return IsSelect("COL20758704625"); } 
				set { SetSelect("COL20758704625", value); } 
			}

			/// <summary>
			/// Checks whether column ModifiedBy is added in select statement 
			/// </summary>
			public bool IsSelectModifiedBy { 
				get { return IsSelect("COL207587046214"); } 
				set { SetSelect("COL207587046214", value); } 
			}

			/// <summary>
			/// Checks whether column Vat is added in select statement 
			/// </summary>
			public bool IsSelectVat { 
				get { return IsSelect("COL20758704627"); } 
				set { SetSelect("COL20758704627", value); } 
			}

			/// <summary>
			/// Checks whether column PriceUSD is added in select statement 
			/// </summary>
			public bool IsSelectPriceUSD { 
				get { return IsSelect("COL20758704626"); } 
				set { SetSelect("COL20758704626", value); } 
			}

			/// <summary>
			/// Checks whether column VehicleTypeId is added in select statement 
			/// </summary>
			public bool IsSelectVehicleTypeId { 
				get { return IsSelect("COL20758704623"); } 
				set { SetSelect("COL20758704623", value); } 
			}

			/// <summary>
			/// Checks whether column Modified is added in select statement 
			/// </summary>
			public bool IsSelectModified { 
				get { return IsSelect("COL207587046213"); } 
				set { SetSelect("COL207587046213", value); } 
			}

			/// <summary>
			/// Checks whether column BuildingId is added in select statement 
			/// </summary>
			public bool IsSelectBuildingId { 
				get { return IsSelect("COL20758704624"); } 
				set { SetSelect("COL20758704624", value); } 
			}

			/// <summary>
			/// Checks whether column id is added in select statement 
			/// </summary>
			public bool IsSelectid { 
				get { return IsSelect("COL20758704621"); } 
				set { SetSelect("COL20758704621", value); } 
			}

			/// <summary>
			/// Checks whether column CreatedBy is added in select statement 
			/// </summary>
			public bool IsSelectCreatedBy { 
				get { return IsSelect("COL207587046212"); } 
				set { SetSelect("COL207587046212", value); } 
			}



	}
}