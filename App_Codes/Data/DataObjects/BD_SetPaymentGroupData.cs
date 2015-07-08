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
	public class BD_SetPaymentGroupData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ703341570";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of BD_SetPaymentGroup 
			/// </summary>
			public BD_SetPaymentGroupData(string objectID): base(objectID) {}  

			public BD_SetPaymentGroupData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field DelFlag 
			/// </summary>
			public string DelFlag { 
				get { return GetValue("COL7033415708"); } 
				set { SetValue("COL7033415708", value); } 
			}

			/// <summary>
			/// Gets field CreatedBy 
			/// </summary>
			public string CreatedBy { 
				get { return GetValue("COL7033415705"); } 
				set { SetValue("COL7033415705", value); } 
			}

			/// <summary>
			/// Gets field Created 
			/// </summary>
			public string Created { 
				get { return GetValue("COL7033415704"); } 
				set { SetValue("COL7033415704", value); } 
			}

			/// <summary>
			/// Gets field ModifiedBy 
			/// </summary>
			public string ModifiedBy { 
				get { return GetValue("COL7033415707"); } 
				set { SetValue("COL7033415707", value); } 
			}

			/// <summary>
			/// Gets field Modified 
			/// </summary>
			public string Modified { 
				get { return GetValue("COL7033415706"); } 
				set { SetValue("COL7033415706", value); } 
			}

			/// <summary>
			/// Gets field id 
			/// </summary>
			public string id { 
				get { return GetValue("COL7033415701"); } 
				set { SetValue("COL7033415701", value); } 
			}

			/// <summary>
			/// Gets field PaymentGroupId 
			/// </summary>
			public string PaymentGroupId { 
				get { return GetValue("COL7033415703"); } 
				set { SetValue("COL7033415703", value); } 
			}

			/// <summary>
			/// Gets field PaymentTypeId 
			/// </summary>
			public string PaymentTypeId { 
				get { return GetValue("COL7033415702"); } 
				set { SetValue("COL7033415702", value); } 
			}


			/// <summary>
			/// Gets DelFlag attribute data 
			/// </summary>
			public AttributeData GetDelFlagAttributeData() { 
				return GetAttributeData("COL7033415708"); 
			}

			/// <summary>
			/// Gets CreatedBy attribute data 
			/// </summary>
			public AttributeData GetCreatedByAttributeData() { 
				return GetAttributeData("COL7033415705"); 
			}

			/// <summary>
			/// Gets Created attribute data 
			/// </summary>
			public AttributeData GetCreatedAttributeData() { 
				return GetAttributeData("COL7033415704"); 
			}

			/// <summary>
			/// Gets ModifiedBy attribute data 
			/// </summary>
			public AttributeData GetModifiedByAttributeData() { 
				return GetAttributeData("COL7033415707"); 
			}

			/// <summary>
			/// Gets Modified attribute data 
			/// </summary>
			public AttributeData GetModifiedAttributeData() { 
				return GetAttributeData("COL7033415706"); 
			}

			/// <summary>
			/// Gets id attribute data 
			/// </summary>
			public AttributeData GetidAttributeData() { 
				return GetAttributeData("COL7033415701"); 
			}

			/// <summary>
			/// Gets PaymentGroupId attribute data 
			/// </summary>
			public AttributeData GetPaymentGroupIdAttributeData() { 
				return GetAttributeData("COL7033415703"); 
			}

			/// <summary>
			/// Gets PaymentTypeId attribute data 
			/// </summary>
			public AttributeData GetPaymentTypeIdAttributeData() { 
				return GetAttributeData("COL7033415702"); 
			}


			/// <summary>
			/// Gets column DelFlag with alias  
			/// </summary>
			public string ColDelFlag { 
				get { return GetColumnName("COL7033415708"); } 
			}

			/// <summary>
			/// Gets column CreatedBy with alias  
			/// </summary>
			public string ColCreatedBy { 
				get { return GetColumnName("COL7033415705"); } 
			}

			/// <summary>
			/// Gets column Created with alias  
			/// </summary>
			public string ColCreated { 
				get { return GetColumnName("COL7033415704"); } 
			}

			/// <summary>
			/// Gets column ModifiedBy with alias  
			/// </summary>
			public string ColModifiedBy { 
				get { return GetColumnName("COL7033415707"); } 
			}

			/// <summary>
			/// Gets column Modified with alias  
			/// </summary>
			public string ColModified { 
				get { return GetColumnName("COL7033415706"); } 
			}

			/// <summary>
			/// Gets column id with alias  
			/// </summary>
			public string Colid { 
				get { return GetColumnName("COL7033415701"); } 
			}

			/// <summary>
			/// Gets column PaymentGroupId with alias  
			/// </summary>
			public string ColPaymentGroupId { 
				get { return GetColumnName("COL7033415703"); } 
			}

			/// <summary>
			/// Gets column PaymentTypeId with alias  
			/// </summary>
			public string ColPaymentTypeId { 
				get { return GetColumnName("COL7033415702"); } 
			}


			/// <summary>
			/// Checks whether column DelFlag is added in select statement 
			/// </summary>
			public bool IsSelectDelFlag { 
				get { return IsSelect("COL7033415708"); } 
				set { SetSelect("COL7033415708", value); } 
			}

			/// <summary>
			/// Checks whether column CreatedBy is added in select statement 
			/// </summary>
			public bool IsSelectCreatedBy { 
				get { return IsSelect("COL7033415705"); } 
				set { SetSelect("COL7033415705", value); } 
			}

			/// <summary>
			/// Checks whether column Created is added in select statement 
			/// </summary>
			public bool IsSelectCreated { 
				get { return IsSelect("COL7033415704"); } 
				set { SetSelect("COL7033415704", value); } 
			}

			/// <summary>
			/// Checks whether column ModifiedBy is added in select statement 
			/// </summary>
			public bool IsSelectModifiedBy { 
				get { return IsSelect("COL7033415707"); } 
				set { SetSelect("COL7033415707", value); } 
			}

			/// <summary>
			/// Checks whether column Modified is added in select statement 
			/// </summary>
			public bool IsSelectModified { 
				get { return IsSelect("COL7033415706"); } 
				set { SetSelect("COL7033415706", value); } 
			}

			/// <summary>
			/// Checks whether column id is added in select statement 
			/// </summary>
			public bool IsSelectid { 
				get { return IsSelect("COL7033415701"); } 
				set { SetSelect("COL7033415701", value); } 
			}

			/// <summary>
			/// Checks whether column PaymentGroupId is added in select statement 
			/// </summary>
			public bool IsSelectPaymentGroupId { 
				get { return IsSelect("COL7033415703"); } 
				set { SetSelect("COL7033415703", value); } 
			}

			/// <summary>
			/// Checks whether column PaymentTypeId is added in select statement 
			/// </summary>
			public bool IsSelectPaymentTypeId { 
				get { return IsSelect("COL7033415702"); } 
				set { SetSelect("COL7033415702", value); } 
			}



	}
}