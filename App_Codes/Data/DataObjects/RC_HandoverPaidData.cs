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
	public class RC_HandoverPaidData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ95339404";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of RC_HandoverPaid 
			/// </summary>
			public RC_HandoverPaidData(string objectID): base(objectID) {}  

			public RC_HandoverPaidData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field Comment 
			/// </summary>
			public string Comment { 
				get { return GetValue("COL9533940417"); } 
				set { SetValue("COL9533940417", value); } 
			}

			/// <summary>
			/// Gets field Description 
			/// </summary>
			public string Description { 
				get { return GetValue("COL9533940416"); } 
				set { SetValue("COL9533940416", value); } 
			}

			/// <summary>
			/// Gets field Receiver 
			/// </summary>
			public string Receiver { 
				get { return GetValue("COL953394044"); } 
				set { SetValue("COL953394044", value); } 
			}

			/// <summary>
			/// Gets field PriceVND 
			/// </summary>
			public string PriceVND { 
				get { return GetValue("COL953394046"); } 
				set { SetValue("COL953394046", value); } 
			}

			/// <summary>
			/// Gets field Mount 
			/// </summary>
			public string Mount { 
				get { return GetValue("COL953394045"); } 
				set { SetValue("COL953394045", value); } 
			}

			/// <summary>
			/// Gets field ModifiedBy 
			/// </summary>
			public string ModifiedBy { 
				get { return GetValue("COL9533940421"); } 
				set { SetValue("COL9533940421", value); } 
			}

			/// <summary>
			/// Gets field Modified 
			/// </summary>
			public string Modified { 
				get { return GetValue("COL9533940420"); } 
				set { SetValue("COL9533940420", value); } 
			}

			/// <summary>
			/// Gets field DelFlag 
			/// </summary>
			public string DelFlag { 
				get { return GetValue("COL9533940422"); } 
				set { SetValue("COL9533940422", value); } 
			}

			/// <summary>
			/// Gets field Payer 
			/// </summary>
			public string Payer { 
				get { return GetValue("COL953394043"); } 
				set { SetValue("COL953394043", value); } 
			}

			/// <summary>
			/// Gets field HandoverId 
			/// </summary>
			public string HandoverId { 
				get { return GetValue("COL953394042"); } 
				set { SetValue("COL953394042", value); } 
			}

			/// <summary>
			/// Gets field id 
			/// </summary>
			public string id { 
				get { return GetValue("COL953394041"); } 
				set { SetValue("COL953394041", value); } 
			}

			/// <summary>
			/// Gets field CreatedBy 
			/// </summary>
			public string CreatedBy { 
				get { return GetValue("COL9533940419"); } 
				set { SetValue("COL9533940419", value); } 
			}

			/// <summary>
			/// Gets field Created 
			/// </summary>
			public string Created { 
				get { return GetValue("COL9533940418"); } 
				set { SetValue("COL9533940418", value); } 
			}

			/// <summary>
			/// Gets field PriceUSD 
			/// </summary>
			public string PriceUSD { 
				get { return GetValue("COL953394047"); } 
				set { SetValue("COL953394047", value); } 
			}

			/// <summary>
			/// Gets field PaidDate 
			/// </summary>
			public string PaidDate { 
				get { return GetValue("COL9533940415"); } 
				set { SetValue("COL9533940415", value); } 
			}


			/// <summary>
			/// Gets Comment attribute data 
			/// </summary>
			public AttributeData GetCommentAttributeData() { 
				return GetAttributeData("COL9533940417"); 
			}

			/// <summary>
			/// Gets Description attribute data 
			/// </summary>
			public AttributeData GetDescriptionAttributeData() { 
				return GetAttributeData("COL9533940416"); 
			}

			/// <summary>
			/// Gets Receiver attribute data 
			/// </summary>
			public AttributeData GetReceiverAttributeData() { 
				return GetAttributeData("COL953394044"); 
			}

			/// <summary>
			/// Gets PriceVND attribute data 
			/// </summary>
			public AttributeData GetPriceVNDAttributeData() { 
				return GetAttributeData("COL953394046"); 
			}

			/// <summary>
			/// Gets Mount attribute data 
			/// </summary>
			public AttributeData GetMountAttributeData() { 
				return GetAttributeData("COL953394045"); 
			}

			/// <summary>
			/// Gets ModifiedBy attribute data 
			/// </summary>
			public AttributeData GetModifiedByAttributeData() { 
				return GetAttributeData("COL9533940421"); 
			}

			/// <summary>
			/// Gets Modified attribute data 
			/// </summary>
			public AttributeData GetModifiedAttributeData() { 
				return GetAttributeData("COL9533940420"); 
			}

			/// <summary>
			/// Gets DelFlag attribute data 
			/// </summary>
			public AttributeData GetDelFlagAttributeData() { 
				return GetAttributeData("COL9533940422"); 
			}

			/// <summary>
			/// Gets Payer attribute data 
			/// </summary>
			public AttributeData GetPayerAttributeData() { 
				return GetAttributeData("COL953394043"); 
			}

			/// <summary>
			/// Gets HandoverId attribute data 
			/// </summary>
			public AttributeData GetHandoverIdAttributeData() { 
				return GetAttributeData("COL953394042"); 
			}

			/// <summary>
			/// Gets id attribute data 
			/// </summary>
			public AttributeData GetidAttributeData() { 
				return GetAttributeData("COL953394041"); 
			}

			/// <summary>
			/// Gets CreatedBy attribute data 
			/// </summary>
			public AttributeData GetCreatedByAttributeData() { 
				return GetAttributeData("COL9533940419"); 
			}

			/// <summary>
			/// Gets Created attribute data 
			/// </summary>
			public AttributeData GetCreatedAttributeData() { 
				return GetAttributeData("COL9533940418"); 
			}

			/// <summary>
			/// Gets PriceUSD attribute data 
			/// </summary>
			public AttributeData GetPriceUSDAttributeData() { 
				return GetAttributeData("COL953394047"); 
			}

			/// <summary>
			/// Gets PaidDate attribute data 
			/// </summary>
			public AttributeData GetPaidDateAttributeData() { 
				return GetAttributeData("COL9533940415"); 
			}


			/// <summary>
			/// Gets column Comment with alias  
			/// </summary>
			public string ColComment { 
				get { return GetColumnName("COL9533940417"); } 
			}

			/// <summary>
			/// Gets column Description with alias  
			/// </summary>
			public string ColDescription { 
				get { return GetColumnName("COL9533940416"); } 
			}

			/// <summary>
			/// Gets column Receiver with alias  
			/// </summary>
			public string ColReceiver { 
				get { return GetColumnName("COL953394044"); } 
			}

			/// <summary>
			/// Gets column PriceVND with alias  
			/// </summary>
			public string ColPriceVND { 
				get { return GetColumnName("COL953394046"); } 
			}

			/// <summary>
			/// Gets column Mount with alias  
			/// </summary>
			public string ColMount { 
				get { return GetColumnName("COL953394045"); } 
			}

			/// <summary>
			/// Gets column ModifiedBy with alias  
			/// </summary>
			public string ColModifiedBy { 
				get { return GetColumnName("COL9533940421"); } 
			}

			/// <summary>
			/// Gets column Modified with alias  
			/// </summary>
			public string ColModified { 
				get { return GetColumnName("COL9533940420"); } 
			}

			/// <summary>
			/// Gets column DelFlag with alias  
			/// </summary>
			public string ColDelFlag { 
				get { return GetColumnName("COL9533940422"); } 
			}

			/// <summary>
			/// Gets column Payer with alias  
			/// </summary>
			public string ColPayer { 
				get { return GetColumnName("COL953394043"); } 
			}

			/// <summary>
			/// Gets column HandoverId with alias  
			/// </summary>
			public string ColHandoverId { 
				get { return GetColumnName("COL953394042"); } 
			}

			/// <summary>
			/// Gets column id with alias  
			/// </summary>
			public string Colid { 
				get { return GetColumnName("COL953394041"); } 
			}

			/// <summary>
			/// Gets column CreatedBy with alias  
			/// </summary>
			public string ColCreatedBy { 
				get { return GetColumnName("COL9533940419"); } 
			}

			/// <summary>
			/// Gets column Created with alias  
			/// </summary>
			public string ColCreated { 
				get { return GetColumnName("COL9533940418"); } 
			}

			/// <summary>
			/// Gets column PriceUSD with alias  
			/// </summary>
			public string ColPriceUSD { 
				get { return GetColumnName("COL953394047"); } 
			}

			/// <summary>
			/// Gets column PaidDate with alias  
			/// </summary>
			public string ColPaidDate { 
				get { return GetColumnName("COL9533940415"); } 
			}


			/// <summary>
			/// Checks whether column Comment is added in select statement 
			/// </summary>
			public bool IsSelectComment { 
				get { return IsSelect("COL9533940417"); } 
				set { SetSelect("COL9533940417", value); } 
			}

			/// <summary>
			/// Checks whether column Description is added in select statement 
			/// </summary>
			public bool IsSelectDescription { 
				get { return IsSelect("COL9533940416"); } 
				set { SetSelect("COL9533940416", value); } 
			}

			/// <summary>
			/// Checks whether column Receiver is added in select statement 
			/// </summary>
			public bool IsSelectReceiver { 
				get { return IsSelect("COL953394044"); } 
				set { SetSelect("COL953394044", value); } 
			}

			/// <summary>
			/// Checks whether column PriceVND is added in select statement 
			/// </summary>
			public bool IsSelectPriceVND { 
				get { return IsSelect("COL953394046"); } 
				set { SetSelect("COL953394046", value); } 
			}

			/// <summary>
			/// Checks whether column Mount is added in select statement 
			/// </summary>
			public bool IsSelectMount { 
				get { return IsSelect("COL953394045"); } 
				set { SetSelect("COL953394045", value); } 
			}

			/// <summary>
			/// Checks whether column ModifiedBy is added in select statement 
			/// </summary>
			public bool IsSelectModifiedBy { 
				get { return IsSelect("COL9533940421"); } 
				set { SetSelect("COL9533940421", value); } 
			}

			/// <summary>
			/// Checks whether column Modified is added in select statement 
			/// </summary>
			public bool IsSelectModified { 
				get { return IsSelect("COL9533940420"); } 
				set { SetSelect("COL9533940420", value); } 
			}

			/// <summary>
			/// Checks whether column DelFlag is added in select statement 
			/// </summary>
			public bool IsSelectDelFlag { 
				get { return IsSelect("COL9533940422"); } 
				set { SetSelect("COL9533940422", value); } 
			}

			/// <summary>
			/// Checks whether column Payer is added in select statement 
			/// </summary>
			public bool IsSelectPayer { 
				get { return IsSelect("COL953394043"); } 
				set { SetSelect("COL953394043", value); } 
			}

			/// <summary>
			/// Checks whether column HandoverId is added in select statement 
			/// </summary>
			public bool IsSelectHandoverId { 
				get { return IsSelect("COL953394042"); } 
				set { SetSelect("COL953394042", value); } 
			}

			/// <summary>
			/// Checks whether column id is added in select statement 
			/// </summary>
			public bool IsSelectid { 
				get { return IsSelect("COL953394041"); } 
				set { SetSelect("COL953394041", value); } 
			}

			/// <summary>
			/// Checks whether column CreatedBy is added in select statement 
			/// </summary>
			public bool IsSelectCreatedBy { 
				get { return IsSelect("COL9533940419"); } 
				set { SetSelect("COL9533940419", value); } 
			}

			/// <summary>
			/// Checks whether column Created is added in select statement 
			/// </summary>
			public bool IsSelectCreated { 
				get { return IsSelect("COL9533940418"); } 
				set { SetSelect("COL9533940418", value); } 
			}

			/// <summary>
			/// Checks whether column PriceUSD is added in select statement 
			/// </summary>
			public bool IsSelectPriceUSD { 
				get { return IsSelect("COL953394047"); } 
				set { SetSelect("COL953394047", value); } 
			}

			/// <summary>
			/// Checks whether column PaidDate is added in select statement 
			/// </summary>
			public bool IsSelectPaidDate { 
				get { return IsSelect("COL9533940415"); } 
				set { SetSelect("COL9533940415", value); } 
			}



	}
}