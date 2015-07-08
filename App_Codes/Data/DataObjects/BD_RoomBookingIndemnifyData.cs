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
	public class BD_RoomBookingIndemnifyData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ31339176";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of BD_RoomBookingIndemnify 
			/// </summary>
			public BD_RoomBookingIndemnifyData(string objectID): base(objectID) {}  

			public BD_RoomBookingIndemnifyData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field Created 
			/// </summary>
			public string Created { 
				get { return GetValue("COL3133917612"); } 
				set { SetValue("COL3133917612", value); } 
			}

			/// <summary>
			/// Gets field CreatedBy 
			/// </summary>
			public string CreatedBy { 
				get { return GetValue("COL3133917613"); } 
				set { SetValue("COL3133917613", value); } 
			}

			/// <summary>
			/// Gets field Item 
			/// </summary>
			public string Item { 
				get { return GetValue("COL313391763"); } 
				set { SetValue("COL313391763", value); } 
			}

			/// <summary>
			/// Gets field Comment 
			/// </summary>
			public string Comment { 
				get { return GetValue("COL3133917611"); } 
				set { SetValue("COL3133917611", value); } 
			}

			/// <summary>
			/// Gets field Modified 
			/// </summary>
			public string Modified { 
				get { return GetValue("COL3133917614"); } 
				set { SetValue("COL3133917614", value); } 
			}

			/// <summary>
			/// Gets field Indemnifier 
			/// </summary>
			public string Indemnifier { 
				get { return GetValue("COL313391765"); } 
				set { SetValue("COL313391765", value); } 
			}

			/// <summary>
			/// Gets field Description 
			/// </summary>
			public string Description { 
				get { return GetValue("COL313391767"); } 
				set { SetValue("COL313391767", value); } 
			}

			/// <summary>
			/// Gets field PriceUSD 
			/// </summary>
			public string PriceUSD { 
				get { return GetValue("COL3133917610"); } 
				set { SetValue("COL3133917610", value); } 
			}

			/// <summary>
			/// Gets field PriceVND 
			/// </summary>
			public string PriceVND { 
				get { return GetValue("COL313391769"); } 
				set { SetValue("COL313391769", value); } 
			}

			/// <summary>
			/// Gets field BookingtId 
			/// </summary>
			public string BookingtId { 
				get { return GetValue("COL313391762"); } 
				set { SetValue("COL313391762", value); } 
			}

			/// <summary>
			/// Gets field ReceiveDate 
			/// </summary>
			public string ReceiveDate { 
				get { return GetValue("COL313391764"); } 
				set { SetValue("COL313391764", value); } 
			}

			/// <summary>
			/// Gets field ModifiedBy 
			/// </summary>
			public string ModifiedBy { 
				get { return GetValue("COL3133917615"); } 
				set { SetValue("COL3133917615", value); } 
			}

			/// <summary>
			/// Gets field Receiver 
			/// </summary>
			public string Receiver { 
				get { return GetValue("COL313391766"); } 
				set { SetValue("COL313391766", value); } 
			}

			/// <summary>
			/// Gets field DelFlag 
			/// </summary>
			public string DelFlag { 
				get { return GetValue("COL3133917616"); } 
				set { SetValue("COL3133917616", value); } 
			}

			/// <summary>
			/// Gets field Mount 
			/// </summary>
			public string Mount { 
				get { return GetValue("COL313391768"); } 
				set { SetValue("COL313391768", value); } 
			}

			/// <summary>
			/// Gets field id 
			/// </summary>
			public string id { 
				get { return GetValue("COL313391761"); } 
				set { SetValue("COL313391761", value); } 
			}


			/// <summary>
			/// Gets Created attribute data 
			/// </summary>
			public AttributeData GetCreatedAttributeData() { 
				return GetAttributeData("COL3133917612"); 
			}

			/// <summary>
			/// Gets CreatedBy attribute data 
			/// </summary>
			public AttributeData GetCreatedByAttributeData() { 
				return GetAttributeData("COL3133917613"); 
			}

			/// <summary>
			/// Gets Item attribute data 
			/// </summary>
			public AttributeData GetItemAttributeData() { 
				return GetAttributeData("COL313391763"); 
			}

			/// <summary>
			/// Gets Comment attribute data 
			/// </summary>
			public AttributeData GetCommentAttributeData() { 
				return GetAttributeData("COL3133917611"); 
			}

			/// <summary>
			/// Gets Modified attribute data 
			/// </summary>
			public AttributeData GetModifiedAttributeData() { 
				return GetAttributeData("COL3133917614"); 
			}

			/// <summary>
			/// Gets Indemnifier attribute data 
			/// </summary>
			public AttributeData GetIndemnifierAttributeData() { 
				return GetAttributeData("COL313391765"); 
			}

			/// <summary>
			/// Gets Description attribute data 
			/// </summary>
			public AttributeData GetDescriptionAttributeData() { 
				return GetAttributeData("COL313391767"); 
			}

			/// <summary>
			/// Gets PriceUSD attribute data 
			/// </summary>
			public AttributeData GetPriceUSDAttributeData() { 
				return GetAttributeData("COL3133917610"); 
			}

			/// <summary>
			/// Gets PriceVND attribute data 
			/// </summary>
			public AttributeData GetPriceVNDAttributeData() { 
				return GetAttributeData("COL313391769"); 
			}

			/// <summary>
			/// Gets BookingtId attribute data 
			/// </summary>
			public AttributeData GetBookingtIdAttributeData() { 
				return GetAttributeData("COL313391762"); 
			}

			/// <summary>
			/// Gets ReceiveDate attribute data 
			/// </summary>
			public AttributeData GetReceiveDateAttributeData() { 
				return GetAttributeData("COL313391764"); 
			}

			/// <summary>
			/// Gets ModifiedBy attribute data 
			/// </summary>
			public AttributeData GetModifiedByAttributeData() { 
				return GetAttributeData("COL3133917615"); 
			}

			/// <summary>
			/// Gets Receiver attribute data 
			/// </summary>
			public AttributeData GetReceiverAttributeData() { 
				return GetAttributeData("COL313391766"); 
			}

			/// <summary>
			/// Gets DelFlag attribute data 
			/// </summary>
			public AttributeData GetDelFlagAttributeData() { 
				return GetAttributeData("COL3133917616"); 
			}

			/// <summary>
			/// Gets Mount attribute data 
			/// </summary>
			public AttributeData GetMountAttributeData() { 
				return GetAttributeData("COL313391768"); 
			}

			/// <summary>
			/// Gets id attribute data 
			/// </summary>
			public AttributeData GetidAttributeData() { 
				return GetAttributeData("COL313391761"); 
			}


			/// <summary>
			/// Gets column Created with alias  
			/// </summary>
			public string ColCreated { 
				get { return GetColumnName("COL3133917612"); } 
			}

			/// <summary>
			/// Gets column CreatedBy with alias  
			/// </summary>
			public string ColCreatedBy { 
				get { return GetColumnName("COL3133917613"); } 
			}

			/// <summary>
			/// Gets column Item with alias  
			/// </summary>
			public string ColItem { 
				get { return GetColumnName("COL313391763"); } 
			}

			/// <summary>
			/// Gets column Comment with alias  
			/// </summary>
			public string ColComment { 
				get { return GetColumnName("COL3133917611"); } 
			}

			/// <summary>
			/// Gets column Modified with alias  
			/// </summary>
			public string ColModified { 
				get { return GetColumnName("COL3133917614"); } 
			}

			/// <summary>
			/// Gets column Indemnifier with alias  
			/// </summary>
			public string ColIndemnifier { 
				get { return GetColumnName("COL313391765"); } 
			}

			/// <summary>
			/// Gets column Description with alias  
			/// </summary>
			public string ColDescription { 
				get { return GetColumnName("COL313391767"); } 
			}

			/// <summary>
			/// Gets column PriceUSD with alias  
			/// </summary>
			public string ColPriceUSD { 
				get { return GetColumnName("COL3133917610"); } 
			}

			/// <summary>
			/// Gets column PriceVND with alias  
			/// </summary>
			public string ColPriceVND { 
				get { return GetColumnName("COL313391769"); } 
			}

			/// <summary>
			/// Gets column BookingtId with alias  
			/// </summary>
			public string ColBookingtId { 
				get { return GetColumnName("COL313391762"); } 
			}

			/// <summary>
			/// Gets column ReceiveDate with alias  
			/// </summary>
			public string ColReceiveDate { 
				get { return GetColumnName("COL313391764"); } 
			}

			/// <summary>
			/// Gets column ModifiedBy with alias  
			/// </summary>
			public string ColModifiedBy { 
				get { return GetColumnName("COL3133917615"); } 
			}

			/// <summary>
			/// Gets column Receiver with alias  
			/// </summary>
			public string ColReceiver { 
				get { return GetColumnName("COL313391766"); } 
			}

			/// <summary>
			/// Gets column DelFlag with alias  
			/// </summary>
			public string ColDelFlag { 
				get { return GetColumnName("COL3133917616"); } 
			}

			/// <summary>
			/// Gets column Mount with alias  
			/// </summary>
			public string ColMount { 
				get { return GetColumnName("COL313391768"); } 
			}

			/// <summary>
			/// Gets column id with alias  
			/// </summary>
			public string Colid { 
				get { return GetColumnName("COL313391761"); } 
			}


			/// <summary>
			/// Checks whether column Created is added in select statement 
			/// </summary>
			public bool IsSelectCreated { 
				get { return IsSelect("COL3133917612"); } 
				set { SetSelect("COL3133917612", value); } 
			}

			/// <summary>
			/// Checks whether column CreatedBy is added in select statement 
			/// </summary>
			public bool IsSelectCreatedBy { 
				get { return IsSelect("COL3133917613"); } 
				set { SetSelect("COL3133917613", value); } 
			}

			/// <summary>
			/// Checks whether column Item is added in select statement 
			/// </summary>
			public bool IsSelectItem { 
				get { return IsSelect("COL313391763"); } 
				set { SetSelect("COL313391763", value); } 
			}

			/// <summary>
			/// Checks whether column Comment is added in select statement 
			/// </summary>
			public bool IsSelectComment { 
				get { return IsSelect("COL3133917611"); } 
				set { SetSelect("COL3133917611", value); } 
			}

			/// <summary>
			/// Checks whether column Modified is added in select statement 
			/// </summary>
			public bool IsSelectModified { 
				get { return IsSelect("COL3133917614"); } 
				set { SetSelect("COL3133917614", value); } 
			}

			/// <summary>
			/// Checks whether column Indemnifier is added in select statement 
			/// </summary>
			public bool IsSelectIndemnifier { 
				get { return IsSelect("COL313391765"); } 
				set { SetSelect("COL313391765", value); } 
			}

			/// <summary>
			/// Checks whether column Description is added in select statement 
			/// </summary>
			public bool IsSelectDescription { 
				get { return IsSelect("COL313391767"); } 
				set { SetSelect("COL313391767", value); } 
			}

			/// <summary>
			/// Checks whether column PriceUSD is added in select statement 
			/// </summary>
			public bool IsSelectPriceUSD { 
				get { return IsSelect("COL3133917610"); } 
				set { SetSelect("COL3133917610", value); } 
			}

			/// <summary>
			/// Checks whether column PriceVND is added in select statement 
			/// </summary>
			public bool IsSelectPriceVND { 
				get { return IsSelect("COL313391769"); } 
				set { SetSelect("COL313391769", value); } 
			}

			/// <summary>
			/// Checks whether column BookingtId is added in select statement 
			/// </summary>
			public bool IsSelectBookingtId { 
				get { return IsSelect("COL313391762"); } 
				set { SetSelect("COL313391762", value); } 
			}

			/// <summary>
			/// Checks whether column ReceiveDate is added in select statement 
			/// </summary>
			public bool IsSelectReceiveDate { 
				get { return IsSelect("COL313391764"); } 
				set { SetSelect("COL313391764", value); } 
			}

			/// <summary>
			/// Checks whether column ModifiedBy is added in select statement 
			/// </summary>
			public bool IsSelectModifiedBy { 
				get { return IsSelect("COL3133917615"); } 
				set { SetSelect("COL3133917615", value); } 
			}

			/// <summary>
			/// Checks whether column Receiver is added in select statement 
			/// </summary>
			public bool IsSelectReceiver { 
				get { return IsSelect("COL313391766"); } 
				set { SetSelect("COL313391766", value); } 
			}

			/// <summary>
			/// Checks whether column DelFlag is added in select statement 
			/// </summary>
			public bool IsSelectDelFlag { 
				get { return IsSelect("COL3133917616"); } 
				set { SetSelect("COL3133917616", value); } 
			}

			/// <summary>
			/// Checks whether column Mount is added in select statement 
			/// </summary>
			public bool IsSelectMount { 
				get { return IsSelect("COL313391768"); } 
				set { SetSelect("COL313391768", value); } 
			}

			/// <summary>
			/// Checks whether column id is added in select statement 
			/// </summary>
			public bool IsSelectid { 
				get { return IsSelect("COL313391761"); } 
				set { SetSelect("COL313391761", value); } 
			}



	}
}