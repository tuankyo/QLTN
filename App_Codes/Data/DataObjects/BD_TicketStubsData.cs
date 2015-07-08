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
	public class BD_TicketStubsData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ642101328";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of BD_TicketStubs 
			/// </summary>
			public BD_TicketStubsData(string objectID): base(objectID) {}  

			public BD_TicketStubsData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field Created 
			/// </summary>
			public string Created { 
				get { return GetValue("COL64210132814"); } 
				set { SetValue("COL64210132814", value); } 
			}

			/// <summary>
			/// Gets field BuildingId 
			/// </summary>
			public string BuildingId { 
				get { return GetValue("COL6421013282"); } 
				set { SetValue("COL6421013282", value); } 
			}

			/// <summary>
			/// Gets field UsedComment 
			/// </summary>
			public string UsedComment { 
				get { return GetValue("COL64210132819"); } 
				set { SetValue("COL64210132819", value); } 
			}

			/// <summary>
			/// Gets field UsedReceiveFrom 
			/// </summary>
			public string UsedReceiveFrom { 
				get { return GetValue("COL64210132811"); } 
				set { SetValue("COL64210132811", value); } 
			}

			/// <summary>
			/// Gets field Modified 
			/// </summary>
			public string Modified { 
				get { return GetValue("COL64210132816"); } 
				set { SetValue("COL64210132816", value); } 
			}

			/// <summary>
			/// Gets field Price 
			/// </summary>
			public string Price { 
				get { return GetValue("COL6421013288"); } 
				set { SetValue("COL6421013288", value); } 
			}

			/// <summary>
			/// Gets field UsedMount 
			/// </summary>
			public string UsedMount { 
				get { return GetValue("COL64210132810"); } 
				set { SetValue("COL64210132810", value); } 
			}

			/// <summary>
			/// Gets field Comment 
			/// </summary>
			public string Comment { 
				get { return GetValue("COL64210132813"); } 
				set { SetValue("COL64210132813", value); } 
			}

			/// <summary>
			/// Gets field id 
			/// </summary>
			public string id { 
				get { return GetValue("COL6421013281"); } 
				set { SetValue("COL6421013281", value); } 
			}

			/// <summary>
			/// Gets field SeriNumber 
			/// </summary>
			public string SeriNumber { 
				get { return GetValue("COL6421013283"); } 
				set { SetValue("COL6421013283", value); } 
			}

			/// <summary>
			/// Gets field DelFlag 
			/// </summary>
			public string DelFlag { 
				get { return GetValue("COL64210132818"); } 
				set { SetValue("COL64210132818", value); } 
			}

			/// <summary>
			/// Gets field ReceiveFrom 
			/// </summary>
			public string ReceiveFrom { 
				get { return GetValue("COL6421013285"); } 
				set { SetValue("COL6421013285", value); } 
			}

			/// <summary>
			/// Gets field ReceiveDate 
			/// </summary>
			public string ReceiveDate { 
				get { return GetValue("COL6421013284"); } 
				set { SetValue("COL6421013284", value); } 
			}

			/// <summary>
			/// Gets field Mount 
			/// </summary>
			public string Mount { 
				get { return GetValue("COL6421013287"); } 
				set { SetValue("COL6421013287", value); } 
			}

			/// <summary>
			/// Gets field Receiver 
			/// </summary>
			public string Receiver { 
				get { return GetValue("COL6421013286"); } 
				set { SetValue("COL6421013286", value); } 
			}

			/// <summary>
			/// Gets field UsedDate 
			/// </summary>
			public string UsedDate { 
				get { return GetValue("COL64210132820"); } 
				set { SetValue("COL64210132820", value); } 
			}

			/// <summary>
			/// Gets field CreatedBy 
			/// </summary>
			public string CreatedBy { 
				get { return GetValue("COL64210132815"); } 
				set { SetValue("COL64210132815", value); } 
			}

			/// <summary>
			/// Gets field Sum 
			/// </summary>
			public string Sum { 
				get { return GetValue("COL6421013289"); } 
				set { SetValue("COL6421013289", value); } 
			}

			/// <summary>
			/// Gets field UsedReceiver 
			/// </summary>
			public string UsedReceiver { 
				get { return GetValue("COL64210132812"); } 
				set { SetValue("COL64210132812", value); } 
			}

			/// <summary>
			/// Gets field ModifiedBy 
			/// </summary>
			public string ModifiedBy { 
				get { return GetValue("COL64210132817"); } 
				set { SetValue("COL64210132817", value); } 
			}


			/// <summary>
			/// Gets Created attribute data 
			/// </summary>
			public AttributeData GetCreatedAttributeData() { 
				return GetAttributeData("COL64210132814"); 
			}

			/// <summary>
			/// Gets BuildingId attribute data 
			/// </summary>
			public AttributeData GetBuildingIdAttributeData() { 
				return GetAttributeData("COL6421013282"); 
			}

			/// <summary>
			/// Gets UsedComment attribute data 
			/// </summary>
			public AttributeData GetUsedCommentAttributeData() { 
				return GetAttributeData("COL64210132819"); 
			}

			/// <summary>
			/// Gets UsedReceiveFrom attribute data 
			/// </summary>
			public AttributeData GetUsedReceiveFromAttributeData() { 
				return GetAttributeData("COL64210132811"); 
			}

			/// <summary>
			/// Gets Modified attribute data 
			/// </summary>
			public AttributeData GetModifiedAttributeData() { 
				return GetAttributeData("COL64210132816"); 
			}

			/// <summary>
			/// Gets Price attribute data 
			/// </summary>
			public AttributeData GetPriceAttributeData() { 
				return GetAttributeData("COL6421013288"); 
			}

			/// <summary>
			/// Gets UsedMount attribute data 
			/// </summary>
			public AttributeData GetUsedMountAttributeData() { 
				return GetAttributeData("COL64210132810"); 
			}

			/// <summary>
			/// Gets Comment attribute data 
			/// </summary>
			public AttributeData GetCommentAttributeData() { 
				return GetAttributeData("COL64210132813"); 
			}

			/// <summary>
			/// Gets id attribute data 
			/// </summary>
			public AttributeData GetidAttributeData() { 
				return GetAttributeData("COL6421013281"); 
			}

			/// <summary>
			/// Gets SeriNumber attribute data 
			/// </summary>
			public AttributeData GetSeriNumberAttributeData() { 
				return GetAttributeData("COL6421013283"); 
			}

			/// <summary>
			/// Gets DelFlag attribute data 
			/// </summary>
			public AttributeData GetDelFlagAttributeData() { 
				return GetAttributeData("COL64210132818"); 
			}

			/// <summary>
			/// Gets ReceiveFrom attribute data 
			/// </summary>
			public AttributeData GetReceiveFromAttributeData() { 
				return GetAttributeData("COL6421013285"); 
			}

			/// <summary>
			/// Gets ReceiveDate attribute data 
			/// </summary>
			public AttributeData GetReceiveDateAttributeData() { 
				return GetAttributeData("COL6421013284"); 
			}

			/// <summary>
			/// Gets Mount attribute data 
			/// </summary>
			public AttributeData GetMountAttributeData() { 
				return GetAttributeData("COL6421013287"); 
			}

			/// <summary>
			/// Gets Receiver attribute data 
			/// </summary>
			public AttributeData GetReceiverAttributeData() { 
				return GetAttributeData("COL6421013286"); 
			}

			/// <summary>
			/// Gets UsedDate attribute data 
			/// </summary>
			public AttributeData GetUsedDateAttributeData() { 
				return GetAttributeData("COL64210132820"); 
			}

			/// <summary>
			/// Gets CreatedBy attribute data 
			/// </summary>
			public AttributeData GetCreatedByAttributeData() { 
				return GetAttributeData("COL64210132815"); 
			}

			/// <summary>
			/// Gets Sum attribute data 
			/// </summary>
			public AttributeData GetSumAttributeData() { 
				return GetAttributeData("COL6421013289"); 
			}

			/// <summary>
			/// Gets UsedReceiver attribute data 
			/// </summary>
			public AttributeData GetUsedReceiverAttributeData() { 
				return GetAttributeData("COL64210132812"); 
			}

			/// <summary>
			/// Gets ModifiedBy attribute data 
			/// </summary>
			public AttributeData GetModifiedByAttributeData() { 
				return GetAttributeData("COL64210132817"); 
			}


			/// <summary>
			/// Gets column Created with alias  
			/// </summary>
			public string ColCreated { 
				get { return GetColumnName("COL64210132814"); } 
			}

			/// <summary>
			/// Gets column BuildingId with alias  
			/// </summary>
			public string ColBuildingId { 
				get { return GetColumnName("COL6421013282"); } 
			}

			/// <summary>
			/// Gets column UsedComment with alias  
			/// </summary>
			public string ColUsedComment { 
				get { return GetColumnName("COL64210132819"); } 
			}

			/// <summary>
			/// Gets column UsedReceiveFrom with alias  
			/// </summary>
			public string ColUsedReceiveFrom { 
				get { return GetColumnName("COL64210132811"); } 
			}

			/// <summary>
			/// Gets column Modified with alias  
			/// </summary>
			public string ColModified { 
				get { return GetColumnName("COL64210132816"); } 
			}

			/// <summary>
			/// Gets column Price with alias  
			/// </summary>
			public string ColPrice { 
				get { return GetColumnName("COL6421013288"); } 
			}

			/// <summary>
			/// Gets column UsedMount with alias  
			/// </summary>
			public string ColUsedMount { 
				get { return GetColumnName("COL64210132810"); } 
			}

			/// <summary>
			/// Gets column Comment with alias  
			/// </summary>
			public string ColComment { 
				get { return GetColumnName("COL64210132813"); } 
			}

			/// <summary>
			/// Gets column id with alias  
			/// </summary>
			public string Colid { 
				get { return GetColumnName("COL6421013281"); } 
			}

			/// <summary>
			/// Gets column SeriNumber with alias  
			/// </summary>
			public string ColSeriNumber { 
				get { return GetColumnName("COL6421013283"); } 
			}

			/// <summary>
			/// Gets column DelFlag with alias  
			/// </summary>
			public string ColDelFlag { 
				get { return GetColumnName("COL64210132818"); } 
			}

			/// <summary>
			/// Gets column ReceiveFrom with alias  
			/// </summary>
			public string ColReceiveFrom { 
				get { return GetColumnName("COL6421013285"); } 
			}

			/// <summary>
			/// Gets column ReceiveDate with alias  
			/// </summary>
			public string ColReceiveDate { 
				get { return GetColumnName("COL6421013284"); } 
			}

			/// <summary>
			/// Gets column Mount with alias  
			/// </summary>
			public string ColMount { 
				get { return GetColumnName("COL6421013287"); } 
			}

			/// <summary>
			/// Gets column Receiver with alias  
			/// </summary>
			public string ColReceiver { 
				get { return GetColumnName("COL6421013286"); } 
			}

			/// <summary>
			/// Gets column UsedDate with alias  
			/// </summary>
			public string ColUsedDate { 
				get { return GetColumnName("COL64210132820"); } 
			}

			/// <summary>
			/// Gets column CreatedBy with alias  
			/// </summary>
			public string ColCreatedBy { 
				get { return GetColumnName("COL64210132815"); } 
			}

			/// <summary>
			/// Gets column Sum with alias  
			/// </summary>
			public string ColSum { 
				get { return GetColumnName("COL6421013289"); } 
			}

			/// <summary>
			/// Gets column UsedReceiver with alias  
			/// </summary>
			public string ColUsedReceiver { 
				get { return GetColumnName("COL64210132812"); } 
			}

			/// <summary>
			/// Gets column ModifiedBy with alias  
			/// </summary>
			public string ColModifiedBy { 
				get { return GetColumnName("COL64210132817"); } 
			}


			/// <summary>
			/// Checks whether column Created is added in select statement 
			/// </summary>
			public bool IsSelectCreated { 
				get { return IsSelect("COL64210132814"); } 
				set { SetSelect("COL64210132814", value); } 
			}

			/// <summary>
			/// Checks whether column BuildingId is added in select statement 
			/// </summary>
			public bool IsSelectBuildingId { 
				get { return IsSelect("COL6421013282"); } 
				set { SetSelect("COL6421013282", value); } 
			}

			/// <summary>
			/// Checks whether column UsedComment is added in select statement 
			/// </summary>
			public bool IsSelectUsedComment { 
				get { return IsSelect("COL64210132819"); } 
				set { SetSelect("COL64210132819", value); } 
			}

			/// <summary>
			/// Checks whether column UsedReceiveFrom is added in select statement 
			/// </summary>
			public bool IsSelectUsedReceiveFrom { 
				get { return IsSelect("COL64210132811"); } 
				set { SetSelect("COL64210132811", value); } 
			}

			/// <summary>
			/// Checks whether column Modified is added in select statement 
			/// </summary>
			public bool IsSelectModified { 
				get { return IsSelect("COL64210132816"); } 
				set { SetSelect("COL64210132816", value); } 
			}

			/// <summary>
			/// Checks whether column Price is added in select statement 
			/// </summary>
			public bool IsSelectPrice { 
				get { return IsSelect("COL6421013288"); } 
				set { SetSelect("COL6421013288", value); } 
			}

			/// <summary>
			/// Checks whether column UsedMount is added in select statement 
			/// </summary>
			public bool IsSelectUsedMount { 
				get { return IsSelect("COL64210132810"); } 
				set { SetSelect("COL64210132810", value); } 
			}

			/// <summary>
			/// Checks whether column Comment is added in select statement 
			/// </summary>
			public bool IsSelectComment { 
				get { return IsSelect("COL64210132813"); } 
				set { SetSelect("COL64210132813", value); } 
			}

			/// <summary>
			/// Checks whether column id is added in select statement 
			/// </summary>
			public bool IsSelectid { 
				get { return IsSelect("COL6421013281"); } 
				set { SetSelect("COL6421013281", value); } 
			}

			/// <summary>
			/// Checks whether column SeriNumber is added in select statement 
			/// </summary>
			public bool IsSelectSeriNumber { 
				get { return IsSelect("COL6421013283"); } 
				set { SetSelect("COL6421013283", value); } 
			}

			/// <summary>
			/// Checks whether column DelFlag is added in select statement 
			/// </summary>
			public bool IsSelectDelFlag { 
				get { return IsSelect("COL64210132818"); } 
				set { SetSelect("COL64210132818", value); } 
			}

			/// <summary>
			/// Checks whether column ReceiveFrom is added in select statement 
			/// </summary>
			public bool IsSelectReceiveFrom { 
				get { return IsSelect("COL6421013285"); } 
				set { SetSelect("COL6421013285", value); } 
			}

			/// <summary>
			/// Checks whether column ReceiveDate is added in select statement 
			/// </summary>
			public bool IsSelectReceiveDate { 
				get { return IsSelect("COL6421013284"); } 
				set { SetSelect("COL6421013284", value); } 
			}

			/// <summary>
			/// Checks whether column Mount is added in select statement 
			/// </summary>
			public bool IsSelectMount { 
				get { return IsSelect("COL6421013287"); } 
				set { SetSelect("COL6421013287", value); } 
			}

			/// <summary>
			/// Checks whether column Receiver is added in select statement 
			/// </summary>
			public bool IsSelectReceiver { 
				get { return IsSelect("COL6421013286"); } 
				set { SetSelect("COL6421013286", value); } 
			}

			/// <summary>
			/// Checks whether column UsedDate is added in select statement 
			/// </summary>
			public bool IsSelectUsedDate { 
				get { return IsSelect("COL64210132820"); } 
				set { SetSelect("COL64210132820", value); } 
			}

			/// <summary>
			/// Checks whether column CreatedBy is added in select statement 
			/// </summary>
			public bool IsSelectCreatedBy { 
				get { return IsSelect("COL64210132815"); } 
				set { SetSelect("COL64210132815", value); } 
			}

			/// <summary>
			/// Checks whether column Sum is added in select statement 
			/// </summary>
			public bool IsSelectSum { 
				get { return IsSelect("COL6421013289"); } 
				set { SetSelect("COL6421013289", value); } 
			}

			/// <summary>
			/// Checks whether column UsedReceiver is added in select statement 
			/// </summary>
			public bool IsSelectUsedReceiver { 
				get { return IsSelect("COL64210132812"); } 
				set { SetSelect("COL64210132812", value); } 
			}

			/// <summary>
			/// Checks whether column ModifiedBy is added in select statement 
			/// </summary>
			public bool IsSelectModifiedBy { 
				get { return IsSelect("COL64210132817"); } 
				set { SetSelect("COL64210132817", value); } 
			}



	}
}