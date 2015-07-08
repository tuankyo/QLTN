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
	public class RC_HandoverData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ63339290";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of RC_Handover 
			/// </summary>
			public RC_HandoverData(string objectID): base(objectID) {}  

			public RC_HandoverData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field Mount 
			/// </summary>
			public string Mount { 
				get { return GetValue("COL6333929017"); } 
				set { SetValue("COL6333929017", value); } 
			}

			/// <summary>
			/// Gets field ReceiveDate 
			/// </summary>
			public string ReceiveDate { 
				get { return GetValue("COL6333929016"); } 
				set { SetValue("COL6333929016", value); } 
			}

			/// <summary>
			/// Gets field PriceUSD 
			/// </summary>
			public string PriceUSD { 
				get { return GetValue("COL6333929019"); } 
				set { SetValue("COL6333929019", value); } 
			}

			/// <summary>
			/// Gets field Handover 
			/// </summary>
			public string Handover { 
				get { return GetValue("COL633392904"); } 
				set { SetValue("COL633392904", value); } 
			}

			/// <summary>
			/// Gets field PriceVND 
			/// </summary>
			public string PriceVND { 
				get { return GetValue("COL6333929018"); } 
				set { SetValue("COL6333929018", value); } 
			}

			/// <summary>
			/// Gets field Description 
			/// </summary>
			public string Description { 
				get { return GetValue("COL6333929020"); } 
				set { SetValue("COL6333929020", value); } 
			}

			/// <summary>
			/// Gets field ContractId 
			/// </summary>
			public string ContractId { 
				get { return GetValue("COL633392902"); } 
				set { SetValue("COL633392902", value); } 
			}

			/// <summary>
			/// Gets field Created 
			/// </summary>
			public string Created { 
				get { return GetValue("COL6333929022"); } 
				set { SetValue("COL6333929022", value); } 
			}

			/// <summary>
			/// Gets field ModifiedBy 
			/// </summary>
			public string ModifiedBy { 
				get { return GetValue("COL6333929025"); } 
				set { SetValue("COL6333929025", value); } 
			}

			/// <summary>
			/// Gets field Comment 
			/// </summary>
			public string Comment { 
				get { return GetValue("COL6333929021"); } 
				set { SetValue("COL6333929021", value); } 
			}

			/// <summary>
			/// Gets field CreatedBy 
			/// </summary>
			public string CreatedBy { 
				get { return GetValue("COL6333929023"); } 
				set { SetValue("COL6333929023", value); } 
			}

			/// <summary>
			/// Gets field Receiver 
			/// </summary>
			public string Receiver { 
				get { return GetValue("COL633392905"); } 
				set { SetValue("COL633392905", value); } 
			}

			/// <summary>
			/// Gets field Modified 
			/// </summary>
			public string Modified { 
				get { return GetValue("COL6333929024"); } 
				set { SetValue("COL6333929024", value); } 
			}

			/// <summary>
			/// Gets field Item 
			/// </summary>
			public string Item { 
				get { return GetValue("COL633392903"); } 
				set { SetValue("COL633392903", value); } 
			}

			/// <summary>
			/// Gets field id 
			/// </summary>
			public string id { 
				get { return GetValue("COL633392901"); } 
				set { SetValue("COL633392901", value); } 
			}

			/// <summary>
			/// Gets field DelFlag 
			/// </summary>
			public string DelFlag { 
				get { return GetValue("COL6333929026"); } 
				set { SetValue("COL6333929026", value); } 
			}


			/// <summary>
			/// Gets Mount attribute data 
			/// </summary>
			public AttributeData GetMountAttributeData() { 
				return GetAttributeData("COL6333929017"); 
			}

			/// <summary>
			/// Gets ReceiveDate attribute data 
			/// </summary>
			public AttributeData GetReceiveDateAttributeData() { 
				return GetAttributeData("COL6333929016"); 
			}

			/// <summary>
			/// Gets PriceUSD attribute data 
			/// </summary>
			public AttributeData GetPriceUSDAttributeData() { 
				return GetAttributeData("COL6333929019"); 
			}

			/// <summary>
			/// Gets Handover attribute data 
			/// </summary>
			public AttributeData GetHandoverAttributeData() { 
				return GetAttributeData("COL633392904"); 
			}

			/// <summary>
			/// Gets PriceVND attribute data 
			/// </summary>
			public AttributeData GetPriceVNDAttributeData() { 
				return GetAttributeData("COL6333929018"); 
			}

			/// <summary>
			/// Gets Description attribute data 
			/// </summary>
			public AttributeData GetDescriptionAttributeData() { 
				return GetAttributeData("COL6333929020"); 
			}

			/// <summary>
			/// Gets ContractId attribute data 
			/// </summary>
			public AttributeData GetContractIdAttributeData() { 
				return GetAttributeData("COL633392902"); 
			}

			/// <summary>
			/// Gets Created attribute data 
			/// </summary>
			public AttributeData GetCreatedAttributeData() { 
				return GetAttributeData("COL6333929022"); 
			}

			/// <summary>
			/// Gets ModifiedBy attribute data 
			/// </summary>
			public AttributeData GetModifiedByAttributeData() { 
				return GetAttributeData("COL6333929025"); 
			}

			/// <summary>
			/// Gets Comment attribute data 
			/// </summary>
			public AttributeData GetCommentAttributeData() { 
				return GetAttributeData("COL6333929021"); 
			}

			/// <summary>
			/// Gets CreatedBy attribute data 
			/// </summary>
			public AttributeData GetCreatedByAttributeData() { 
				return GetAttributeData("COL6333929023"); 
			}

			/// <summary>
			/// Gets Receiver attribute data 
			/// </summary>
			public AttributeData GetReceiverAttributeData() { 
				return GetAttributeData("COL633392905"); 
			}

			/// <summary>
			/// Gets Modified attribute data 
			/// </summary>
			public AttributeData GetModifiedAttributeData() { 
				return GetAttributeData("COL6333929024"); 
			}

			/// <summary>
			/// Gets Item attribute data 
			/// </summary>
			public AttributeData GetItemAttributeData() { 
				return GetAttributeData("COL633392903"); 
			}

			/// <summary>
			/// Gets id attribute data 
			/// </summary>
			public AttributeData GetidAttributeData() { 
				return GetAttributeData("COL633392901"); 
			}

			/// <summary>
			/// Gets DelFlag attribute data 
			/// </summary>
			public AttributeData GetDelFlagAttributeData() { 
				return GetAttributeData("COL6333929026"); 
			}


			/// <summary>
			/// Gets column Mount with alias  
			/// </summary>
			public string ColMount { 
				get { return GetColumnName("COL6333929017"); } 
			}

			/// <summary>
			/// Gets column ReceiveDate with alias  
			/// </summary>
			public string ColReceiveDate { 
				get { return GetColumnName("COL6333929016"); } 
			}

			/// <summary>
			/// Gets column PriceUSD with alias  
			/// </summary>
			public string ColPriceUSD { 
				get { return GetColumnName("COL6333929019"); } 
			}

			/// <summary>
			/// Gets column Handover with alias  
			/// </summary>
			public string ColHandover { 
				get { return GetColumnName("COL633392904"); } 
			}

			/// <summary>
			/// Gets column PriceVND with alias  
			/// </summary>
			public string ColPriceVND { 
				get { return GetColumnName("COL6333929018"); } 
			}

			/// <summary>
			/// Gets column Description with alias  
			/// </summary>
			public string ColDescription { 
				get { return GetColumnName("COL6333929020"); } 
			}

			/// <summary>
			/// Gets column ContractId with alias  
			/// </summary>
			public string ColContractId { 
				get { return GetColumnName("COL633392902"); } 
			}

			/// <summary>
			/// Gets column Created with alias  
			/// </summary>
			public string ColCreated { 
				get { return GetColumnName("COL6333929022"); } 
			}

			/// <summary>
			/// Gets column ModifiedBy with alias  
			/// </summary>
			public string ColModifiedBy { 
				get { return GetColumnName("COL6333929025"); } 
			}

			/// <summary>
			/// Gets column Comment with alias  
			/// </summary>
			public string ColComment { 
				get { return GetColumnName("COL6333929021"); } 
			}

			/// <summary>
			/// Gets column CreatedBy with alias  
			/// </summary>
			public string ColCreatedBy { 
				get { return GetColumnName("COL6333929023"); } 
			}

			/// <summary>
			/// Gets column Receiver with alias  
			/// </summary>
			public string ColReceiver { 
				get { return GetColumnName("COL633392905"); } 
			}

			/// <summary>
			/// Gets column Modified with alias  
			/// </summary>
			public string ColModified { 
				get { return GetColumnName("COL6333929024"); } 
			}

			/// <summary>
			/// Gets column Item with alias  
			/// </summary>
			public string ColItem { 
				get { return GetColumnName("COL633392903"); } 
			}

			/// <summary>
			/// Gets column id with alias  
			/// </summary>
			public string Colid { 
				get { return GetColumnName("COL633392901"); } 
			}

			/// <summary>
			/// Gets column DelFlag with alias  
			/// </summary>
			public string ColDelFlag { 
				get { return GetColumnName("COL6333929026"); } 
			}


			/// <summary>
			/// Checks whether column Mount is added in select statement 
			/// </summary>
			public bool IsSelectMount { 
				get { return IsSelect("COL6333929017"); } 
				set { SetSelect("COL6333929017", value); } 
			}

			/// <summary>
			/// Checks whether column ReceiveDate is added in select statement 
			/// </summary>
			public bool IsSelectReceiveDate { 
				get { return IsSelect("COL6333929016"); } 
				set { SetSelect("COL6333929016", value); } 
			}

			/// <summary>
			/// Checks whether column PriceUSD is added in select statement 
			/// </summary>
			public bool IsSelectPriceUSD { 
				get { return IsSelect("COL6333929019"); } 
				set { SetSelect("COL6333929019", value); } 
			}

			/// <summary>
			/// Checks whether column Handover is added in select statement 
			/// </summary>
			public bool IsSelectHandover { 
				get { return IsSelect("COL633392904"); } 
				set { SetSelect("COL633392904", value); } 
			}

			/// <summary>
			/// Checks whether column PriceVND is added in select statement 
			/// </summary>
			public bool IsSelectPriceVND { 
				get { return IsSelect("COL6333929018"); } 
				set { SetSelect("COL6333929018", value); } 
			}

			/// <summary>
			/// Checks whether column Description is added in select statement 
			/// </summary>
			public bool IsSelectDescription { 
				get { return IsSelect("COL6333929020"); } 
				set { SetSelect("COL6333929020", value); } 
			}

			/// <summary>
			/// Checks whether column ContractId is added in select statement 
			/// </summary>
			public bool IsSelectContractId { 
				get { return IsSelect("COL633392902"); } 
				set { SetSelect("COL633392902", value); } 
			}

			/// <summary>
			/// Checks whether column Created is added in select statement 
			/// </summary>
			public bool IsSelectCreated { 
				get { return IsSelect("COL6333929022"); } 
				set { SetSelect("COL6333929022", value); } 
			}

			/// <summary>
			/// Checks whether column ModifiedBy is added in select statement 
			/// </summary>
			public bool IsSelectModifiedBy { 
				get { return IsSelect("COL6333929025"); } 
				set { SetSelect("COL6333929025", value); } 
			}

			/// <summary>
			/// Checks whether column Comment is added in select statement 
			/// </summary>
			public bool IsSelectComment { 
				get { return IsSelect("COL6333929021"); } 
				set { SetSelect("COL6333929021", value); } 
			}

			/// <summary>
			/// Checks whether column CreatedBy is added in select statement 
			/// </summary>
			public bool IsSelectCreatedBy { 
				get { return IsSelect("COL6333929023"); } 
				set { SetSelect("COL6333929023", value); } 
			}

			/// <summary>
			/// Checks whether column Receiver is added in select statement 
			/// </summary>
			public bool IsSelectReceiver { 
				get { return IsSelect("COL633392905"); } 
				set { SetSelect("COL633392905", value); } 
			}

			/// <summary>
			/// Checks whether column Modified is added in select statement 
			/// </summary>
			public bool IsSelectModified { 
				get { return IsSelect("COL6333929024"); } 
				set { SetSelect("COL6333929024", value); } 
			}

			/// <summary>
			/// Checks whether column Item is added in select statement 
			/// </summary>
			public bool IsSelectItem { 
				get { return IsSelect("COL633392903"); } 
				set { SetSelect("COL633392903", value); } 
			}

			/// <summary>
			/// Checks whether column id is added in select statement 
			/// </summary>
			public bool IsSelectid { 
				get { return IsSelect("COL633392901"); } 
				set { SetSelect("COL633392901", value); } 
			}

			/// <summary>
			/// Checks whether column DelFlag is added in select statement 
			/// </summary>
			public bool IsSelectDelFlag { 
				get { return IsSelect("COL6333929026"); } 
				set { SetSelect("COL6333929026", value); } 
			}



	}
}