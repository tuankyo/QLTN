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
	public class Mst_PaymentTypeData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ130099504";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of Mst_PaymentType 
			/// </summary>
			public Mst_PaymentTypeData(string objectID): base(objectID) {}  

			public Mst_PaymentTypeData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field specialPay 
			/// </summary>
			public string specialPay { 
				get { return GetValue("COL13009950411"); } 
				set { SetValue("COL13009950411", value); } 
			}

			/// <summary>
			/// Gets field id 
			/// </summary>
			public string id { 
				get { return GetValue("COL1300995041"); } 
				set { SetValue("COL1300995041", value); } 
			}

			/// <summary>
			/// Gets field Name 
			/// </summary>
			public string Name { 
				get { return GetValue("COL1300995042"); } 
				set { SetValue("COL1300995042", value); } 
			}

			/// <summary>
			/// Gets field Created 
			/// </summary>
			public string Created { 
				get { return GetValue("COL1300995043"); } 
				set { SetValue("COL1300995043", value); } 
			}

			/// <summary>
			/// Gets field DeleteAllowFlg 
			/// </summary>
			public string DeleteAllowFlg { 
				get { return GetValue("COL13009950410"); } 
				set { SetValue("COL13009950410", value); } 
			}

			/// <summary>
			/// Gets field Modified 
			/// </summary>
			public string Modified { 
				get { return GetValue("COL1300995045"); } 
				set { SetValue("COL1300995045", value); } 
			}

			/// <summary>
			/// Gets field ModifiedBy 
			/// </summary>
			public string ModifiedBy { 
				get { return GetValue("COL1300995046"); } 
				set { SetValue("COL1300995046", value); } 
			}

			/// <summary>
			/// Gets field DelFlag 
			/// </summary>
			public string DelFlag { 
				get { return GetValue("COL1300995047"); } 
				set { SetValue("COL1300995047", value); } 
			}

			/// <summary>
			/// Gets field PaidType 
			/// </summary>
			public string PaidType { 
				get { return GetValue("COL13009950412"); } 
				set { SetValue("COL13009950412", value); } 
			}

			/// <summary>
			/// Gets field CreatedBy 
			/// </summary>
			public string CreatedBy { 
				get { return GetValue("COL1300995044"); } 
				set { SetValue("COL1300995044", value); } 
			}

			/// <summary>
			/// Gets field ParentId 
			/// </summary>
			public string ParentId { 
				get { return GetValue("COL1300995048"); } 
				set { SetValue("COL1300995048", value); } 
			}

			/// <summary>
			/// Gets field ItemLevel 
			/// </summary>
			public string ItemLevel { 
				get { return GetValue("COL1300995049"); } 
				set { SetValue("COL1300995049", value); } 
			}


			/// <summary>
			/// Gets specialPay attribute data 
			/// </summary>
			public AttributeData GetspecialPayAttributeData() { 
				return GetAttributeData("COL13009950411"); 
			}

			/// <summary>
			/// Gets id attribute data 
			/// </summary>
			public AttributeData GetidAttributeData() { 
				return GetAttributeData("COL1300995041"); 
			}

			/// <summary>
			/// Gets Name attribute data 
			/// </summary>
			public AttributeData GetNameAttributeData() { 
				return GetAttributeData("COL1300995042"); 
			}

			/// <summary>
			/// Gets Created attribute data 
			/// </summary>
			public AttributeData GetCreatedAttributeData() { 
				return GetAttributeData("COL1300995043"); 
			}

			/// <summary>
			/// Gets DeleteAllowFlg attribute data 
			/// </summary>
			public AttributeData GetDeleteAllowFlgAttributeData() { 
				return GetAttributeData("COL13009950410"); 
			}

			/// <summary>
			/// Gets Modified attribute data 
			/// </summary>
			public AttributeData GetModifiedAttributeData() { 
				return GetAttributeData("COL1300995045"); 
			}

			/// <summary>
			/// Gets ModifiedBy attribute data 
			/// </summary>
			public AttributeData GetModifiedByAttributeData() { 
				return GetAttributeData("COL1300995046"); 
			}

			/// <summary>
			/// Gets DelFlag attribute data 
			/// </summary>
			public AttributeData GetDelFlagAttributeData() { 
				return GetAttributeData("COL1300995047"); 
			}

			/// <summary>
			/// Gets PaidType attribute data 
			/// </summary>
			public AttributeData GetPaidTypeAttributeData() { 
				return GetAttributeData("COL13009950412"); 
			}

			/// <summary>
			/// Gets CreatedBy attribute data 
			/// </summary>
			public AttributeData GetCreatedByAttributeData() { 
				return GetAttributeData("COL1300995044"); 
			}

			/// <summary>
			/// Gets ParentId attribute data 
			/// </summary>
			public AttributeData GetParentIdAttributeData() { 
				return GetAttributeData("COL1300995048"); 
			}

			/// <summary>
			/// Gets ItemLevel attribute data 
			/// </summary>
			public AttributeData GetItemLevelAttributeData() { 
				return GetAttributeData("COL1300995049"); 
			}


			/// <summary>
			/// Gets column specialPay with alias  
			/// </summary>
			public string ColspecialPay { 
				get { return GetColumnName("COL13009950411"); } 
			}

			/// <summary>
			/// Gets column id with alias  
			/// </summary>
			public string Colid { 
				get { return GetColumnName("COL1300995041"); } 
			}

			/// <summary>
			/// Gets column Name with alias  
			/// </summary>
			public string ColName { 
				get { return GetColumnName("COL1300995042"); } 
			}

			/// <summary>
			/// Gets column Created with alias  
			/// </summary>
			public string ColCreated { 
				get { return GetColumnName("COL1300995043"); } 
			}

			/// <summary>
			/// Gets column DeleteAllowFlg with alias  
			/// </summary>
			public string ColDeleteAllowFlg { 
				get { return GetColumnName("COL13009950410"); } 
			}

			/// <summary>
			/// Gets column Modified with alias  
			/// </summary>
			public string ColModified { 
				get { return GetColumnName("COL1300995045"); } 
			}

			/// <summary>
			/// Gets column ModifiedBy with alias  
			/// </summary>
			public string ColModifiedBy { 
				get { return GetColumnName("COL1300995046"); } 
			}

			/// <summary>
			/// Gets column DelFlag with alias  
			/// </summary>
			public string ColDelFlag { 
				get { return GetColumnName("COL1300995047"); } 
			}

			/// <summary>
			/// Gets column PaidType with alias  
			/// </summary>
			public string ColPaidType { 
				get { return GetColumnName("COL13009950412"); } 
			}

			/// <summary>
			/// Gets column CreatedBy with alias  
			/// </summary>
			public string ColCreatedBy { 
				get { return GetColumnName("COL1300995044"); } 
			}

			/// <summary>
			/// Gets column ParentId with alias  
			/// </summary>
			public string ColParentId { 
				get { return GetColumnName("COL1300995048"); } 
			}

			/// <summary>
			/// Gets column ItemLevel with alias  
			/// </summary>
			public string ColItemLevel { 
				get { return GetColumnName("COL1300995049"); } 
			}


			/// <summary>
			/// Checks whether column specialPay is added in select statement 
			/// </summary>
			public bool IsSelectspecialPay { 
				get { return IsSelect("COL13009950411"); } 
				set { SetSelect("COL13009950411", value); } 
			}

			/// <summary>
			/// Checks whether column id is added in select statement 
			/// </summary>
			public bool IsSelectid { 
				get { return IsSelect("COL1300995041"); } 
				set { SetSelect("COL1300995041", value); } 
			}

			/// <summary>
			/// Checks whether column Name is added in select statement 
			/// </summary>
			public bool IsSelectName { 
				get { return IsSelect("COL1300995042"); } 
				set { SetSelect("COL1300995042", value); } 
			}

			/// <summary>
			/// Checks whether column Created is added in select statement 
			/// </summary>
			public bool IsSelectCreated { 
				get { return IsSelect("COL1300995043"); } 
				set { SetSelect("COL1300995043", value); } 
			}

			/// <summary>
			/// Checks whether column DeleteAllowFlg is added in select statement 
			/// </summary>
			public bool IsSelectDeleteAllowFlg { 
				get { return IsSelect("COL13009950410"); } 
				set { SetSelect("COL13009950410", value); } 
			}

			/// <summary>
			/// Checks whether column Modified is added in select statement 
			/// </summary>
			public bool IsSelectModified { 
				get { return IsSelect("COL1300995045"); } 
				set { SetSelect("COL1300995045", value); } 
			}

			/// <summary>
			/// Checks whether column ModifiedBy is added in select statement 
			/// </summary>
			public bool IsSelectModifiedBy { 
				get { return IsSelect("COL1300995046"); } 
				set { SetSelect("COL1300995046", value); } 
			}

			/// <summary>
			/// Checks whether column DelFlag is added in select statement 
			/// </summary>
			public bool IsSelectDelFlag { 
				get { return IsSelect("COL1300995047"); } 
				set { SetSelect("COL1300995047", value); } 
			}

			/// <summary>
			/// Checks whether column PaidType is added in select statement 
			/// </summary>
			public bool IsSelectPaidType { 
				get { return IsSelect("COL13009950412"); } 
				set { SetSelect("COL13009950412", value); } 
			}

			/// <summary>
			/// Checks whether column CreatedBy is added in select statement 
			/// </summary>
			public bool IsSelectCreatedBy { 
				get { return IsSelect("COL1300995044"); } 
				set { SetSelect("COL1300995044", value); } 
			}

			/// <summary>
			/// Checks whether column ParentId is added in select statement 
			/// </summary>
			public bool IsSelectParentId { 
				get { return IsSelect("COL1300995048"); } 
				set { SetSelect("COL1300995048", value); } 
			}

			/// <summary>
			/// Checks whether column ItemLevel is added in select statement 
			/// </summary>
			public bool IsSelectItemLevel { 
				get { return IsSelect("COL1300995049"); } 
				set { SetSelect("COL1300995049", value); } 
			}



	}
}