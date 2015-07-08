// ==========================================
//  Author : GNT Data Object Generator Tool
//  Created   : 2014-10-20 13:46:19
//  Copyright GNT INC.  All rights reserved.
// ==========================================
using System;
using System.Collections;
using Gnt.Data.Meta;
using Gnt.Data;

namespace BusinessObjects
{

	[Serializable]
	public class BD_TicketStubsPayData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ2114822596";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of BD_TicketStubsPay 
			/// </summary>
			public BD_TicketStubsPayData(string objectID): base(objectID) {}  

			public BD_TicketStubsPayData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field UsedPrice 
			/// </summary>
			public string UsedPrice { 
				get { return GetValue("COL21148225965"); } 
				set { SetValue("COL21148225965", value); } 
			}

			/// <summary>
			/// Gets field ModifiedBy 
			/// </summary>
			public string ModifiedBy { 
				get { return GetValue("COL211482259615"); } 
				set { SetValue("COL211482259615", value); } 
			}

			/// <summary>
			/// Gets field TicketStubsID 
			/// </summary>
			public string TicketStubsID { 
				get { return GetValue("COL211482259617"); } 
				set { SetValue("COL211482259617", value); } 
			}

			/// <summary>
			/// Gets field UsedSum 
			/// </summary>
			public string UsedSum { 
				get { return GetValue("COL21148225966"); } 
				set { SetValue("COL21148225966", value); } 
			}

			/// <summary>
			/// Gets field UsedDate 
			/// </summary>
			public string UsedDate { 
				get { return GetValue("COL211482259610"); } 
				set { SetValue("COL211482259610", value); } 
			}

			/// <summary>
			/// Gets field Created 
			/// </summary>
			public string Created { 
				get { return GetValue("COL211482259612"); } 
				set { SetValue("COL211482259612", value); } 
			}

			/// <summary>
			/// Gets field UsedMount 
			/// </summary>
			public string UsedMount { 
				get { return GetValue("COL21148225964"); } 
				set { SetValue("COL21148225964", value); } 
			}

			/// <summary>
			/// Gets field UsedComment 
			/// </summary>
			public string UsedComment { 
				get { return GetValue("COL21148225969"); } 
				set { SetValue("COL21148225969", value); } 
			}

			/// <summary>
			/// Gets field id 
			/// </summary>
			public string id { 
				get { return GetValue("COL21148225961"); } 
				set { SetValue("COL21148225961", value); } 
			}

			/// <summary>
			/// Gets field CreatedBy 
			/// </summary>
			public string CreatedBy { 
				get { return GetValue("COL211482259613"); } 
				set { SetValue("COL211482259613", value); } 
			}

			/// <summary>
			/// Gets field Modified 
			/// </summary>
			public string Modified { 
				get { return GetValue("COL211482259614"); } 
				set { SetValue("COL211482259614", value); } 
			}

			/// <summary>
			/// Gets field PaidSeriNumber 
			/// </summary>
			public string PaidSeriNumber { 
				get { return GetValue("COL211482259618"); } 
				set { SetValue("COL211482259618", value); } 
			}

			/// <summary>
			/// Gets field DelFlag 
			/// </summary>
			public string DelFlag { 
				get { return GetValue("COL211482259616"); } 
				set { SetValue("COL211482259616", value); } 
			}

			/// <summary>
			/// Gets field Comment 
			/// </summary>
			public string Comment { 
				get { return GetValue("COL211482259611"); } 
				set { SetValue("COL211482259611", value); } 
			}

			/// <summary>
			/// Gets field UsedReceiveFrom 
			/// </summary>
			public string UsedReceiveFrom { 
				get { return GetValue("COL21148225967"); } 
				set { SetValue("COL21148225967", value); } 
			}

			/// <summary>
			/// Gets field UsedReceiver 
			/// </summary>
			public string UsedReceiver { 
				get { return GetValue("COL21148225968"); } 
				set { SetValue("COL21148225968", value); } 
			}

			/// <summary>
			/// Gets field BuildingId 
			/// </summary>
			public string BuildingId { 
				get { return GetValue("COL21148225962"); } 
				set { SetValue("COL21148225962", value); } 
			}

			/// <summary>
			/// Gets field SeriNumber 
			/// </summary>
			public string SeriNumber { 
				get { return GetValue("COL21148225963"); } 
				set { SetValue("COL21148225963", value); } 
			}


			/// <summary>
			/// Gets UsedPrice attribute data 
			/// </summary>
			public AttributeData GetUsedPriceAttributeData() { 
				return GetAttributeData("COL21148225965"); 
			}

			/// <summary>
			/// Gets ModifiedBy attribute data 
			/// </summary>
			public AttributeData GetModifiedByAttributeData() { 
				return GetAttributeData("COL211482259615"); 
			}

			/// <summary>
			/// Gets TicketStubsID attribute data 
			/// </summary>
			public AttributeData GetTicketStubsIDAttributeData() { 
				return GetAttributeData("COL211482259617"); 
			}

			/// <summary>
			/// Gets UsedSum attribute data 
			/// </summary>
			public AttributeData GetUsedSumAttributeData() { 
				return GetAttributeData("COL21148225966"); 
			}

			/// <summary>
			/// Gets UsedDate attribute data 
			/// </summary>
			public AttributeData GetUsedDateAttributeData() { 
				return GetAttributeData("COL211482259610"); 
			}

			/// <summary>
			/// Gets Created attribute data 
			/// </summary>
			public AttributeData GetCreatedAttributeData() { 
				return GetAttributeData("COL211482259612"); 
			}

			/// <summary>
			/// Gets UsedMount attribute data 
			/// </summary>
			public AttributeData GetUsedMountAttributeData() { 
				return GetAttributeData("COL21148225964"); 
			}

			/// <summary>
			/// Gets UsedComment attribute data 
			/// </summary>
			public AttributeData GetUsedCommentAttributeData() { 
				return GetAttributeData("COL21148225969"); 
			}

			/// <summary>
			/// Gets id attribute data 
			/// </summary>
			public AttributeData GetidAttributeData() { 
				return GetAttributeData("COL21148225961"); 
			}

			/// <summary>
			/// Gets CreatedBy attribute data 
			/// </summary>
			public AttributeData GetCreatedByAttributeData() { 
				return GetAttributeData("COL211482259613"); 
			}

			/// <summary>
			/// Gets Modified attribute data 
			/// </summary>
			public AttributeData GetModifiedAttributeData() { 
				return GetAttributeData("COL211482259614"); 
			}

			/// <summary>
			/// Gets PaidSeriNumber attribute data 
			/// </summary>
			public AttributeData GetPaidSeriNumberAttributeData() { 
				return GetAttributeData("COL211482259618"); 
			}

			/// <summary>
			/// Gets DelFlag attribute data 
			/// </summary>
			public AttributeData GetDelFlagAttributeData() { 
				return GetAttributeData("COL211482259616"); 
			}

			/// <summary>
			/// Gets Comment attribute data 
			/// </summary>
			public AttributeData GetCommentAttributeData() { 
				return GetAttributeData("COL211482259611"); 
			}

			/// <summary>
			/// Gets UsedReceiveFrom attribute data 
			/// </summary>
			public AttributeData GetUsedReceiveFromAttributeData() { 
				return GetAttributeData("COL21148225967"); 
			}

			/// <summary>
			/// Gets UsedReceiver attribute data 
			/// </summary>
			public AttributeData GetUsedReceiverAttributeData() { 
				return GetAttributeData("COL21148225968"); 
			}

			/// <summary>
			/// Gets BuildingId attribute data 
			/// </summary>
			public AttributeData GetBuildingIdAttributeData() { 
				return GetAttributeData("COL21148225962"); 
			}

			/// <summary>
			/// Gets SeriNumber attribute data 
			/// </summary>
			public AttributeData GetSeriNumberAttributeData() { 
				return GetAttributeData("COL21148225963"); 
			}


			/// <summary>
			/// Gets column UsedPrice with alias  
			/// </summary>
			public string ColUsedPrice { 
				get { return GetColumnName("COL21148225965"); } 
			}

			/// <summary>
			/// Gets column ModifiedBy with alias  
			/// </summary>
			public string ColModifiedBy { 
				get { return GetColumnName("COL211482259615"); } 
			}

			/// <summary>
			/// Gets column TicketStubsID with alias  
			/// </summary>
			public string ColTicketStubsID { 
				get { return GetColumnName("COL211482259617"); } 
			}

			/// <summary>
			/// Gets column UsedSum with alias  
			/// </summary>
			public string ColUsedSum { 
				get { return GetColumnName("COL21148225966"); } 
			}

			/// <summary>
			/// Gets column UsedDate with alias  
			/// </summary>
			public string ColUsedDate { 
				get { return GetColumnName("COL211482259610"); } 
			}

			/// <summary>
			/// Gets column Created with alias  
			/// </summary>
			public string ColCreated { 
				get { return GetColumnName("COL211482259612"); } 
			}

			/// <summary>
			/// Gets column UsedMount with alias  
			/// </summary>
			public string ColUsedMount { 
				get { return GetColumnName("COL21148225964"); } 
			}

			/// <summary>
			/// Gets column UsedComment with alias  
			/// </summary>
			public string ColUsedComment { 
				get { return GetColumnName("COL21148225969"); } 
			}

			/// <summary>
			/// Gets column id with alias  
			/// </summary>
			public string Colid { 
				get { return GetColumnName("COL21148225961"); } 
			}

			/// <summary>
			/// Gets column CreatedBy with alias  
			/// </summary>
			public string ColCreatedBy { 
				get { return GetColumnName("COL211482259613"); } 
			}

			/// <summary>
			/// Gets column Modified with alias  
			/// </summary>
			public string ColModified { 
				get { return GetColumnName("COL211482259614"); } 
			}

			/// <summary>
			/// Gets column PaidSeriNumber with alias  
			/// </summary>
			public string ColPaidSeriNumber { 
				get { return GetColumnName("COL211482259618"); } 
			}

			/// <summary>
			/// Gets column DelFlag with alias  
			/// </summary>
			public string ColDelFlag { 
				get { return GetColumnName("COL211482259616"); } 
			}

			/// <summary>
			/// Gets column Comment with alias  
			/// </summary>
			public string ColComment { 
				get { return GetColumnName("COL211482259611"); } 
			}

			/// <summary>
			/// Gets column UsedReceiveFrom with alias  
			/// </summary>
			public string ColUsedReceiveFrom { 
				get { return GetColumnName("COL21148225967"); } 
			}

			/// <summary>
			/// Gets column UsedReceiver with alias  
			/// </summary>
			public string ColUsedReceiver { 
				get { return GetColumnName("COL21148225968"); } 
			}

			/// <summary>
			/// Gets column BuildingId with alias  
			/// </summary>
			public string ColBuildingId { 
				get { return GetColumnName("COL21148225962"); } 
			}

			/// <summary>
			/// Gets column SeriNumber with alias  
			/// </summary>
			public string ColSeriNumber { 
				get { return GetColumnName("COL21148225963"); } 
			}


			/// <summary>
			/// Checks whether column UsedPrice is added in select statement 
			/// </summary>
			public bool IsSelectUsedPrice { 
				get { return IsSelect("COL21148225965"); } 
				set { SetSelect("COL21148225965", value); } 
			}

			/// <summary>
			/// Checks whether column ModifiedBy is added in select statement 
			/// </summary>
			public bool IsSelectModifiedBy { 
				get { return IsSelect("COL211482259615"); } 
				set { SetSelect("COL211482259615", value); } 
			}

			/// <summary>
			/// Checks whether column TicketStubsID is added in select statement 
			/// </summary>
			public bool IsSelectTicketStubsID { 
				get { return IsSelect("COL211482259617"); } 
				set { SetSelect("COL211482259617", value); } 
			}

			/// <summary>
			/// Checks whether column UsedSum is added in select statement 
			/// </summary>
			public bool IsSelectUsedSum { 
				get { return IsSelect("COL21148225966"); } 
				set { SetSelect("COL21148225966", value); } 
			}

			/// <summary>
			/// Checks whether column UsedDate is added in select statement 
			/// </summary>
			public bool IsSelectUsedDate { 
				get { return IsSelect("COL211482259610"); } 
				set { SetSelect("COL211482259610", value); } 
			}

			/// <summary>
			/// Checks whether column Created is added in select statement 
			/// </summary>
			public bool IsSelectCreated { 
				get { return IsSelect("COL211482259612"); } 
				set { SetSelect("COL211482259612", value); } 
			}

			/// <summary>
			/// Checks whether column UsedMount is added in select statement 
			/// </summary>
			public bool IsSelectUsedMount { 
				get { return IsSelect("COL21148225964"); } 
				set { SetSelect("COL21148225964", value); } 
			}

			/// <summary>
			/// Checks whether column UsedComment is added in select statement 
			/// </summary>
			public bool IsSelectUsedComment { 
				get { return IsSelect("COL21148225969"); } 
				set { SetSelect("COL21148225969", value); } 
			}

			/// <summary>
			/// Checks whether column id is added in select statement 
			/// </summary>
			public bool IsSelectid { 
				get { return IsSelect("COL21148225961"); } 
				set { SetSelect("COL21148225961", value); } 
			}

			/// <summary>
			/// Checks whether column CreatedBy is added in select statement 
			/// </summary>
			public bool IsSelectCreatedBy { 
				get { return IsSelect("COL211482259613"); } 
				set { SetSelect("COL211482259613", value); } 
			}

			/// <summary>
			/// Checks whether column Modified is added in select statement 
			/// </summary>
			public bool IsSelectModified { 
				get { return IsSelect("COL211482259614"); } 
				set { SetSelect("COL211482259614", value); } 
			}

			/// <summary>
			/// Checks whether column PaidSeriNumber is added in select statement 
			/// </summary>
			public bool IsSelectPaidSeriNumber { 
				get { return IsSelect("COL211482259618"); } 
				set { SetSelect("COL211482259618", value); } 
			}

			/// <summary>
			/// Checks whether column DelFlag is added in select statement 
			/// </summary>
			public bool IsSelectDelFlag { 
				get { return IsSelect("COL211482259616"); } 
				set { SetSelect("COL211482259616", value); } 
			}

			/// <summary>
			/// Checks whether column Comment is added in select statement 
			/// </summary>
			public bool IsSelectComment { 
				get { return IsSelect("COL211482259611"); } 
				set { SetSelect("COL211482259611", value); } 
			}

			/// <summary>
			/// Checks whether column UsedReceiveFrom is added in select statement 
			/// </summary>
			public bool IsSelectUsedReceiveFrom { 
				get { return IsSelect("COL21148225967"); } 
				set { SetSelect("COL21148225967", value); } 
			}

			/// <summary>
			/// Checks whether column UsedReceiver is added in select statement 
			/// </summary>
			public bool IsSelectUsedReceiver { 
				get { return IsSelect("COL21148225968"); } 
				set { SetSelect("COL21148225968", value); } 
			}

			/// <summary>
			/// Checks whether column BuildingId is added in select statement 
			/// </summary>
			public bool IsSelectBuildingId { 
				get { return IsSelect("COL21148225962"); } 
				set { SetSelect("COL21148225962", value); } 
			}

			/// <summary>
			/// Checks whether column SeriNumber is added in select statement 
			/// </summary>
			public bool IsSelectSeriNumber { 
				get { return IsSelect("COL21148225963"); } 
				set { SetSelect("COL21148225963", value); } 
			}



	}
}