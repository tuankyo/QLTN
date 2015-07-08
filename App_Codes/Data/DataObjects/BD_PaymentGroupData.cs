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
	public class BD_PaymentGroupData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ767341798";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of BD_PaymentGroup 
			/// </summary>
			public BD_PaymentGroupData(string objectID): base(objectID) {}  

			public BD_PaymentGroupData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field BuildingId 
			/// </summary>
			public string BuildingId { 
				get { return GetValue("COL7673417983"); } 
				set { SetValue("COL7673417983", value); } 
			}

			/// <summary>
			/// Gets field PaymentGroupName 
			/// </summary>
			public string PaymentGroupName { 
				get { return GetValue("COL7673417982"); } 
				set { SetValue("COL7673417982", value); } 
			}

			/// <summary>
			/// Gets field id 
			/// </summary>
			public string id { 
				get { return GetValue("COL7673417981"); } 
				set { SetValue("COL7673417981", value); } 
			}


			/// <summary>
			/// Gets BuildingId attribute data 
			/// </summary>
			public AttributeData GetBuildingIdAttributeData() { 
				return GetAttributeData("COL7673417983"); 
			}

			/// <summary>
			/// Gets PaymentGroupName attribute data 
			/// </summary>
			public AttributeData GetPaymentGroupNameAttributeData() { 
				return GetAttributeData("COL7673417982"); 
			}

			/// <summary>
			/// Gets id attribute data 
			/// </summary>
			public AttributeData GetidAttributeData() { 
				return GetAttributeData("COL7673417981"); 
			}


			/// <summary>
			/// Gets column BuildingId with alias  
			/// </summary>
			public string ColBuildingId { 
				get { return GetColumnName("COL7673417983"); } 
			}

			/// <summary>
			/// Gets column PaymentGroupName with alias  
			/// </summary>
			public string ColPaymentGroupName { 
				get { return GetColumnName("COL7673417982"); } 
			}

			/// <summary>
			/// Gets column id with alias  
			/// </summary>
			public string Colid { 
				get { return GetColumnName("COL7673417981"); } 
			}


			/// <summary>
			/// Checks whether column BuildingId is added in select statement 
			/// </summary>
			public bool IsSelectBuildingId { 
				get { return IsSelect("COL7673417983"); } 
				set { SetSelect("COL7673417983", value); } 
			}

			/// <summary>
			/// Checks whether column PaymentGroupName is added in select statement 
			/// </summary>
			public bool IsSelectPaymentGroupName { 
				get { return IsSelect("COL7673417982"); } 
				set { SetSelect("COL7673417982", value); } 
			}

			/// <summary>
			/// Checks whether column id is added in select statement 
			/// </summary>
			public bool IsSelectid { 
				get { return IsSelect("COL7673417981"); } 
				set { SetSelect("COL7673417981", value); } 
			}



	}
}