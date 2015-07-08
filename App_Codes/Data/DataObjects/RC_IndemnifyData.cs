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
	public class RC_IndemnifyData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ2146822710";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of RC_Indemnify 
			/// </summary>
			public RC_IndemnifyData(string objectID): base(objectID) {}  

			public RC_IndemnifyData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field ContractId 
			/// </summary>
			public string ContractId { 
				get { return GetValue("COL21468227102"); } 
				set { SetValue("COL21468227102", value); } 
			}

			/// <summary>
			/// Gets field Created 
			/// </summary>
			public string Created { 
				get { return GetValue("COL214682271012"); } 
				set { SetValue("COL214682271012", value); } 
			}

			/// <summary>
			/// Gets field Mount 
			/// </summary>
			public string Mount { 
				get { return GetValue("COL21468227108"); } 
				set { SetValue("COL21468227108", value); } 
			}

			/// <summary>
			/// Gets field Item 
			/// </summary>
			public string Item { 
				get { return GetValue("COL21468227103"); } 
				set { SetValue("COL21468227103", value); } 
			}

			/// <summary>
			/// Gets field Indemnifier 
			/// </summary>
			public string Indemnifier { 
				get { return GetValue("COL21468227105"); } 
				set { SetValue("COL21468227105", value); } 
			}

			/// <summary>
			/// Gets field PriceUSD 
			/// </summary>
			public string PriceUSD { 
				get { return GetValue("COL214682271010"); } 
				set { SetValue("COL214682271010", value); } 
			}

			/// <summary>
			/// Gets field Receiver 
			/// </summary>
			public string Receiver { 
				get { return GetValue("COL21468227106"); } 
				set { SetValue("COL21468227106", value); } 
			}

			/// <summary>
			/// Gets field PriceVND 
			/// </summary>
			public string PriceVND { 
				get { return GetValue("COL21468227109"); } 
				set { SetValue("COL21468227109", value); } 
			}

			/// <summary>
			/// Gets field Comment 
			/// </summary>
			public string Comment { 
				get { return GetValue("COL214682271011"); } 
				set { SetValue("COL214682271011", value); } 
			}

			/// <summary>
			/// Gets field CreatedBy 
			/// </summary>
			public string CreatedBy { 
				get { return GetValue("COL214682271013"); } 
				set { SetValue("COL214682271013", value); } 
			}

			/// <summary>
			/// Gets field id 
			/// </summary>
			public string id { 
				get { return GetValue("COL21468227101"); } 
				set { SetValue("COL21468227101", value); } 
			}

			/// <summary>
			/// Gets field ReceiveDate 
			/// </summary>
			public string ReceiveDate { 
				get { return GetValue("COL21468227104"); } 
				set { SetValue("COL21468227104", value); } 
			}

			/// <summary>
			/// Gets field ModifiedBy 
			/// </summary>
			public string ModifiedBy { 
				get { return GetValue("COL214682271015"); } 
				set { SetValue("COL214682271015", value); } 
			}

			/// <summary>
			/// Gets field Description 
			/// </summary>
			public string Description { 
				get { return GetValue("COL21468227107"); } 
				set { SetValue("COL21468227107", value); } 
			}

			/// <summary>
			/// Gets field Modified 
			/// </summary>
			public string Modified { 
				get { return GetValue("COL214682271014"); } 
				set { SetValue("COL214682271014", value); } 
			}

			/// <summary>
			/// Gets field DelFlag 
			/// </summary>
			public string DelFlag { 
				get { return GetValue("COL214682271016"); } 
				set { SetValue("COL214682271016", value); } 
			}


			/// <summary>
			/// Gets ContractId attribute data 
			/// </summary>
			public AttributeData GetContractIdAttributeData() { 
				return GetAttributeData("COL21468227102"); 
			}

			/// <summary>
			/// Gets Created attribute data 
			/// </summary>
			public AttributeData GetCreatedAttributeData() { 
				return GetAttributeData("COL214682271012"); 
			}

			/// <summary>
			/// Gets Mount attribute data 
			/// </summary>
			public AttributeData GetMountAttributeData() { 
				return GetAttributeData("COL21468227108"); 
			}

			/// <summary>
			/// Gets Item attribute data 
			/// </summary>
			public AttributeData GetItemAttributeData() { 
				return GetAttributeData("COL21468227103"); 
			}

			/// <summary>
			/// Gets Indemnifier attribute data 
			/// </summary>
			public AttributeData GetIndemnifierAttributeData() { 
				return GetAttributeData("COL21468227105"); 
			}

			/// <summary>
			/// Gets PriceUSD attribute data 
			/// </summary>
			public AttributeData GetPriceUSDAttributeData() { 
				return GetAttributeData("COL214682271010"); 
			}

			/// <summary>
			/// Gets Receiver attribute data 
			/// </summary>
			public AttributeData GetReceiverAttributeData() { 
				return GetAttributeData("COL21468227106"); 
			}

			/// <summary>
			/// Gets PriceVND attribute data 
			/// </summary>
			public AttributeData GetPriceVNDAttributeData() { 
				return GetAttributeData("COL21468227109"); 
			}

			/// <summary>
			/// Gets Comment attribute data 
			/// </summary>
			public AttributeData GetCommentAttributeData() { 
				return GetAttributeData("COL214682271011"); 
			}

			/// <summary>
			/// Gets CreatedBy attribute data 
			/// </summary>
			public AttributeData GetCreatedByAttributeData() { 
				return GetAttributeData("COL214682271013"); 
			}

			/// <summary>
			/// Gets id attribute data 
			/// </summary>
			public AttributeData GetidAttributeData() { 
				return GetAttributeData("COL21468227101"); 
			}

			/// <summary>
			/// Gets ReceiveDate attribute data 
			/// </summary>
			public AttributeData GetReceiveDateAttributeData() { 
				return GetAttributeData("COL21468227104"); 
			}

			/// <summary>
			/// Gets ModifiedBy attribute data 
			/// </summary>
			public AttributeData GetModifiedByAttributeData() { 
				return GetAttributeData("COL214682271015"); 
			}

			/// <summary>
			/// Gets Description attribute data 
			/// </summary>
			public AttributeData GetDescriptionAttributeData() { 
				return GetAttributeData("COL21468227107"); 
			}

			/// <summary>
			/// Gets Modified attribute data 
			/// </summary>
			public AttributeData GetModifiedAttributeData() { 
				return GetAttributeData("COL214682271014"); 
			}

			/// <summary>
			/// Gets DelFlag attribute data 
			/// </summary>
			public AttributeData GetDelFlagAttributeData() { 
				return GetAttributeData("COL214682271016"); 
			}


			/// <summary>
			/// Gets column ContractId with alias  
			/// </summary>
			public string ColContractId { 
				get { return GetColumnName("COL21468227102"); } 
			}

			/// <summary>
			/// Gets column Created with alias  
			/// </summary>
			public string ColCreated { 
				get { return GetColumnName("COL214682271012"); } 
			}

			/// <summary>
			/// Gets column Mount with alias  
			/// </summary>
			public string ColMount { 
				get { return GetColumnName("COL21468227108"); } 
			}

			/// <summary>
			/// Gets column Item with alias  
			/// </summary>
			public string ColItem { 
				get { return GetColumnName("COL21468227103"); } 
			}

			/// <summary>
			/// Gets column Indemnifier with alias  
			/// </summary>
			public string ColIndemnifier { 
				get { return GetColumnName("COL21468227105"); } 
			}

			/// <summary>
			/// Gets column PriceUSD with alias  
			/// </summary>
			public string ColPriceUSD { 
				get { return GetColumnName("COL214682271010"); } 
			}

			/// <summary>
			/// Gets column Receiver with alias  
			/// </summary>
			public string ColReceiver { 
				get { return GetColumnName("COL21468227106"); } 
			}

			/// <summary>
			/// Gets column PriceVND with alias  
			/// </summary>
			public string ColPriceVND { 
				get { return GetColumnName("COL21468227109"); } 
			}

			/// <summary>
			/// Gets column Comment with alias  
			/// </summary>
			public string ColComment { 
				get { return GetColumnName("COL214682271011"); } 
			}

			/// <summary>
			/// Gets column CreatedBy with alias  
			/// </summary>
			public string ColCreatedBy { 
				get { return GetColumnName("COL214682271013"); } 
			}

			/// <summary>
			/// Gets column id with alias  
			/// </summary>
			public string Colid { 
				get { return GetColumnName("COL21468227101"); } 
			}

			/// <summary>
			/// Gets column ReceiveDate with alias  
			/// </summary>
			public string ColReceiveDate { 
				get { return GetColumnName("COL21468227104"); } 
			}

			/// <summary>
			/// Gets column ModifiedBy with alias  
			/// </summary>
			public string ColModifiedBy { 
				get { return GetColumnName("COL214682271015"); } 
			}

			/// <summary>
			/// Gets column Description with alias  
			/// </summary>
			public string ColDescription { 
				get { return GetColumnName("COL21468227107"); } 
			}

			/// <summary>
			/// Gets column Modified with alias  
			/// </summary>
			public string ColModified { 
				get { return GetColumnName("COL214682271014"); } 
			}

			/// <summary>
			/// Gets column DelFlag with alias  
			/// </summary>
			public string ColDelFlag { 
				get { return GetColumnName("COL214682271016"); } 
			}


			/// <summary>
			/// Checks whether column ContractId is added in select statement 
			/// </summary>
			public bool IsSelectContractId { 
				get { return IsSelect("COL21468227102"); } 
				set { SetSelect("COL21468227102", value); } 
			}

			/// <summary>
			/// Checks whether column Created is added in select statement 
			/// </summary>
			public bool IsSelectCreated { 
				get { return IsSelect("COL214682271012"); } 
				set { SetSelect("COL214682271012", value); } 
			}

			/// <summary>
			/// Checks whether column Mount is added in select statement 
			/// </summary>
			public bool IsSelectMount { 
				get { return IsSelect("COL21468227108"); } 
				set { SetSelect("COL21468227108", value); } 
			}

			/// <summary>
			/// Checks whether column Item is added in select statement 
			/// </summary>
			public bool IsSelectItem { 
				get { return IsSelect("COL21468227103"); } 
				set { SetSelect("COL21468227103", value); } 
			}

			/// <summary>
			/// Checks whether column Indemnifier is added in select statement 
			/// </summary>
			public bool IsSelectIndemnifier { 
				get { return IsSelect("COL21468227105"); } 
				set { SetSelect("COL21468227105", value); } 
			}

			/// <summary>
			/// Checks whether column PriceUSD is added in select statement 
			/// </summary>
			public bool IsSelectPriceUSD { 
				get { return IsSelect("COL214682271010"); } 
				set { SetSelect("COL214682271010", value); } 
			}

			/// <summary>
			/// Checks whether column Receiver is added in select statement 
			/// </summary>
			public bool IsSelectReceiver { 
				get { return IsSelect("COL21468227106"); } 
				set { SetSelect("COL21468227106", value); } 
			}

			/// <summary>
			/// Checks whether column PriceVND is added in select statement 
			/// </summary>
			public bool IsSelectPriceVND { 
				get { return IsSelect("COL21468227109"); } 
				set { SetSelect("COL21468227109", value); } 
			}

			/// <summary>
			/// Checks whether column Comment is added in select statement 
			/// </summary>
			public bool IsSelectComment { 
				get { return IsSelect("COL214682271011"); } 
				set { SetSelect("COL214682271011", value); } 
			}

			/// <summary>
			/// Checks whether column CreatedBy is added in select statement 
			/// </summary>
			public bool IsSelectCreatedBy { 
				get { return IsSelect("COL214682271013"); } 
				set { SetSelect("COL214682271013", value); } 
			}

			/// <summary>
			/// Checks whether column id is added in select statement 
			/// </summary>
			public bool IsSelectid { 
				get { return IsSelect("COL21468227101"); } 
				set { SetSelect("COL21468227101", value); } 
			}

			/// <summary>
			/// Checks whether column ReceiveDate is added in select statement 
			/// </summary>
			public bool IsSelectReceiveDate { 
				get { return IsSelect("COL21468227104"); } 
				set { SetSelect("COL21468227104", value); } 
			}

			/// <summary>
			/// Checks whether column ModifiedBy is added in select statement 
			/// </summary>
			public bool IsSelectModifiedBy { 
				get { return IsSelect("COL214682271015"); } 
				set { SetSelect("COL214682271015", value); } 
			}

			/// <summary>
			/// Checks whether column Description is added in select statement 
			/// </summary>
			public bool IsSelectDescription { 
				get { return IsSelect("COL21468227107"); } 
				set { SetSelect("COL21468227107", value); } 
			}

			/// <summary>
			/// Checks whether column Modified is added in select statement 
			/// </summary>
			public bool IsSelectModified { 
				get { return IsSelect("COL214682271014"); } 
				set { SetSelect("COL214682271014", value); } 
			}

			/// <summary>
			/// Checks whether column DelFlag is added in select statement 
			/// </summary>
			public bool IsSelectDelFlag { 
				get { return IsSelect("COL214682271016"); } 
				set { SetSelect("COL214682271016", value); } 
			}



	}
}