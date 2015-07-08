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
	public class CustomerData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ856390120";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of Customer 
			/// </summary>
			public CustomerData(string objectID): base(objectID) {}  

			public CustomerData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field CustomerId 
			/// </summary>
			public string CustomerId { 
				get { return GetValue("COL8563901201"); } 
				set { SetValue("COL8563901201", value); } 
			}

			/// <summary>
			/// Gets field Name 
			/// </summary>
			public string Name { 
				get { return GetValue("COL8563901203"); } 
				set { SetValue("COL8563901203", value); } 
			}

			/// <summary>
			/// Gets field MonthPaymentType 
			/// </summary>
			public string MonthPaymentType { 
				get { return GetValue("COL85639012013"); } 
				set { SetValue("COL85639012013", value); } 
			}

			/// <summary>
			/// Gets field Email 
			/// </summary>
			public string Email { 
				get { return GetValue("COL8563901205"); } 
				set { SetValue("COL8563901205", value); } 
			}

			/// <summary>
			/// Gets field Phone 
			/// </summary>
			public string Phone { 
				get { return GetValue("COL8563901204"); } 
				set { SetValue("COL8563901204", value); } 
			}

			/// <summary>
			/// Gets field Comment 
			/// </summary>
			public string Comment { 
				get { return GetValue("COL8563901207"); } 
				set { SetValue("COL8563901207", value); } 
			}

			/// <summary>
			/// Gets field ContactName 
			/// </summary>
			public string ContactName { 
				get { return GetValue("COL8563901206"); } 
				set { SetValue("COL8563901206", value); } 
			}

			/// <summary>
			/// Gets field ModifiedBy 
			/// </summary>
			public string ModifiedBy { 
				get { return GetValue("COL85639012011"); } 
				set { SetValue("COL85639012011", value); } 
			}

			/// <summary>
			/// Gets field BuildingId 
			/// </summary>
			public string BuildingId { 
				get { return GetValue("COL8563901202"); } 
				set { SetValue("COL8563901202", value); } 
			}

			/// <summary>
			/// Gets field CreatedBy 
			/// </summary>
			public string CreatedBy { 
				get { return GetValue("COL8563901209"); } 
				set { SetValue("COL8563901209", value); } 
			}

			/// <summary>
			/// Gets field Created 
			/// </summary>
			public string Created { 
				get { return GetValue("COL8563901208"); } 
				set { SetValue("COL8563901208", value); } 
			}

			/// <summary>
			/// Gets field Modified 
			/// </summary>
			public string Modified { 
				get { return GetValue("COL85639012010"); } 
				set { SetValue("COL85639012010", value); } 
			}

			/// <summary>
			/// Gets field DelFlag 
			/// </summary>
			public string DelFlag { 
				get { return GetValue("COL85639012012"); } 
				set { SetValue("COL85639012012", value); } 
			}


			/// <summary>
			/// Gets CustomerId attribute data 
			/// </summary>
			public AttributeData GetCustomerIdAttributeData() { 
				return GetAttributeData("COL8563901201"); 
			}

			/// <summary>
			/// Gets Name attribute data 
			/// </summary>
			public AttributeData GetNameAttributeData() { 
				return GetAttributeData("COL8563901203"); 
			}

			/// <summary>
			/// Gets MonthPaymentType attribute data 
			/// </summary>
			public AttributeData GetMonthPaymentTypeAttributeData() { 
				return GetAttributeData("COL85639012013"); 
			}

			/// <summary>
			/// Gets Email attribute data 
			/// </summary>
			public AttributeData GetEmailAttributeData() { 
				return GetAttributeData("COL8563901205"); 
			}

			/// <summary>
			/// Gets Phone attribute data 
			/// </summary>
			public AttributeData GetPhoneAttributeData() { 
				return GetAttributeData("COL8563901204"); 
			}

			/// <summary>
			/// Gets Comment attribute data 
			/// </summary>
			public AttributeData GetCommentAttributeData() { 
				return GetAttributeData("COL8563901207"); 
			}

			/// <summary>
			/// Gets ContactName attribute data 
			/// </summary>
			public AttributeData GetContactNameAttributeData() { 
				return GetAttributeData("COL8563901206"); 
			}

			/// <summary>
			/// Gets ModifiedBy attribute data 
			/// </summary>
			public AttributeData GetModifiedByAttributeData() { 
				return GetAttributeData("COL85639012011"); 
			}

			/// <summary>
			/// Gets BuildingId attribute data 
			/// </summary>
			public AttributeData GetBuildingIdAttributeData() { 
				return GetAttributeData("COL8563901202"); 
			}

			/// <summary>
			/// Gets CreatedBy attribute data 
			/// </summary>
			public AttributeData GetCreatedByAttributeData() { 
				return GetAttributeData("COL8563901209"); 
			}

			/// <summary>
			/// Gets Created attribute data 
			/// </summary>
			public AttributeData GetCreatedAttributeData() { 
				return GetAttributeData("COL8563901208"); 
			}

			/// <summary>
			/// Gets Modified attribute data 
			/// </summary>
			public AttributeData GetModifiedAttributeData() { 
				return GetAttributeData("COL85639012010"); 
			}

			/// <summary>
			/// Gets DelFlag attribute data 
			/// </summary>
			public AttributeData GetDelFlagAttributeData() { 
				return GetAttributeData("COL85639012012"); 
			}


			/// <summary>
			/// Gets column CustomerId with alias  
			/// </summary>
			public string ColCustomerId { 
				get { return GetColumnName("COL8563901201"); } 
			}

			/// <summary>
			/// Gets column Name with alias  
			/// </summary>
			public string ColName { 
				get { return GetColumnName("COL8563901203"); } 
			}

			/// <summary>
			/// Gets column MonthPaymentType with alias  
			/// </summary>
			public string ColMonthPaymentType { 
				get { return GetColumnName("COL85639012013"); } 
			}

			/// <summary>
			/// Gets column Email with alias  
			/// </summary>
			public string ColEmail { 
				get { return GetColumnName("COL8563901205"); } 
			}

			/// <summary>
			/// Gets column Phone with alias  
			/// </summary>
			public string ColPhone { 
				get { return GetColumnName("COL8563901204"); } 
			}

			/// <summary>
			/// Gets column Comment with alias  
			/// </summary>
			public string ColComment { 
				get { return GetColumnName("COL8563901207"); } 
			}

			/// <summary>
			/// Gets column ContactName with alias  
			/// </summary>
			public string ColContactName { 
				get { return GetColumnName("COL8563901206"); } 
			}

			/// <summary>
			/// Gets column ModifiedBy with alias  
			/// </summary>
			public string ColModifiedBy { 
				get { return GetColumnName("COL85639012011"); } 
			}

			/// <summary>
			/// Gets column BuildingId with alias  
			/// </summary>
			public string ColBuildingId { 
				get { return GetColumnName("COL8563901202"); } 
			}

			/// <summary>
			/// Gets column CreatedBy with alias  
			/// </summary>
			public string ColCreatedBy { 
				get { return GetColumnName("COL8563901209"); } 
			}

			/// <summary>
			/// Gets column Created with alias  
			/// </summary>
			public string ColCreated { 
				get { return GetColumnName("COL8563901208"); } 
			}

			/// <summary>
			/// Gets column Modified with alias  
			/// </summary>
			public string ColModified { 
				get { return GetColumnName("COL85639012010"); } 
			}

			/// <summary>
			/// Gets column DelFlag with alias  
			/// </summary>
			public string ColDelFlag { 
				get { return GetColumnName("COL85639012012"); } 
			}


			/// <summary>
			/// Checks whether column CustomerId is added in select statement 
			/// </summary>
			public bool IsSelectCustomerId { 
				get { return IsSelect("COL8563901201"); } 
				set { SetSelect("COL8563901201", value); } 
			}

			/// <summary>
			/// Checks whether column Name is added in select statement 
			/// </summary>
			public bool IsSelectName { 
				get { return IsSelect("COL8563901203"); } 
				set { SetSelect("COL8563901203", value); } 
			}

			/// <summary>
			/// Checks whether column MonthPaymentType is added in select statement 
			/// </summary>
			public bool IsSelectMonthPaymentType { 
				get { return IsSelect("COL85639012013"); } 
				set { SetSelect("COL85639012013", value); } 
			}

			/// <summary>
			/// Checks whether column Email is added in select statement 
			/// </summary>
			public bool IsSelectEmail { 
				get { return IsSelect("COL8563901205"); } 
				set { SetSelect("COL8563901205", value); } 
			}

			/// <summary>
			/// Checks whether column Phone is added in select statement 
			/// </summary>
			public bool IsSelectPhone { 
				get { return IsSelect("COL8563901204"); } 
				set { SetSelect("COL8563901204", value); } 
			}

			/// <summary>
			/// Checks whether column Comment is added in select statement 
			/// </summary>
			public bool IsSelectComment { 
				get { return IsSelect("COL8563901207"); } 
				set { SetSelect("COL8563901207", value); } 
			}

			/// <summary>
			/// Checks whether column ContactName is added in select statement 
			/// </summary>
			public bool IsSelectContactName { 
				get { return IsSelect("COL8563901206"); } 
				set { SetSelect("COL8563901206", value); } 
			}

			/// <summary>
			/// Checks whether column ModifiedBy is added in select statement 
			/// </summary>
			public bool IsSelectModifiedBy { 
				get { return IsSelect("COL85639012011"); } 
				set { SetSelect("COL85639012011", value); } 
			}

			/// <summary>
			/// Checks whether column BuildingId is added in select statement 
			/// </summary>
			public bool IsSelectBuildingId { 
				get { return IsSelect("COL8563901202"); } 
				set { SetSelect("COL8563901202", value); } 
			}

			/// <summary>
			/// Checks whether column CreatedBy is added in select statement 
			/// </summary>
			public bool IsSelectCreatedBy { 
				get { return IsSelect("COL8563901209"); } 
				set { SetSelect("COL8563901209", value); } 
			}

			/// <summary>
			/// Checks whether column Created is added in select statement 
			/// </summary>
			public bool IsSelectCreated { 
				get { return IsSelect("COL8563901208"); } 
				set { SetSelect("COL8563901208", value); } 
			}

			/// <summary>
			/// Checks whether column Modified is added in select statement 
			/// </summary>
			public bool IsSelectModified { 
				get { return IsSelect("COL85639012010"); } 
				set { SetSelect("COL85639012010", value); } 
			}

			/// <summary>
			/// Checks whether column DelFlag is added in select statement 
			/// </summary>
			public bool IsSelectDelFlag { 
				get { return IsSelect("COL85639012012"); } 
				set { SetSelect("COL85639012012", value); } 
			}



	}
}