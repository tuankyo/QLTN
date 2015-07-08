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
	public class StaffOfCustomerData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ127339518";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of StaffOfCustomer 
			/// </summary>
			public StaffOfCustomerData(string objectID): base(objectID) {}  

			public StaffOfCustomerData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field Position 
			/// </summary>
			public string Position { 
				get { return GetValue("COL12733951814"); } 
				set { SetValue("COL12733951814", value); } 
			}

			/// <summary>
			/// Gets field Comment 
			/// </summary>
			public string Comment { 
				get { return GetValue("COL1273395187"); } 
				set { SetValue("COL1273395187", value); } 
			}

			/// <summary>
			/// Gets field Mail 
			/// </summary>
			public string Mail { 
				get { return GetValue("COL1273395186"); } 
				set { SetValue("COL1273395186", value); } 
			}

			/// <summary>
			/// Gets field Phone 
			/// </summary>
			public string Phone { 
				get { return GetValue("COL1273395184"); } 
				set { SetValue("COL1273395184", value); } 
			}

			/// <summary>
			/// Gets field Address 
			/// </summary>
			public string Address { 
				get { return GetValue("COL12733951813"); } 
				set { SetValue("COL12733951813", value); } 
			}

			/// <summary>
			/// Gets field CustomerId 
			/// </summary>
			public string CustomerId { 
				get { return GetValue("COL1273395182"); } 
				set { SetValue("COL1273395182", value); } 
			}

			/// <summary>
			/// Gets field id 
			/// </summary>
			public string id { 
				get { return GetValue("COL1273395181"); } 
				set { SetValue("COL1273395181", value); } 
			}

			/// <summary>
			/// Gets field ModifiedBy 
			/// </summary>
			public string ModifiedBy { 
				get { return GetValue("COL12733951811"); } 
				set { SetValue("COL12733951811", value); } 
			}

			/// <summary>
			/// Gets field Name 
			/// </summary>
			public string Name { 
				get { return GetValue("COL1273395183"); } 
				set { SetValue("COL1273395183", value); } 
			}

			/// <summary>
			/// Gets field CreatedBy 
			/// </summary>
			public string CreatedBy { 
				get { return GetValue("COL1273395189"); } 
				set { SetValue("COL1273395189", value); } 
			}

			/// <summary>
			/// Gets field Created 
			/// </summary>
			public string Created { 
				get { return GetValue("COL1273395188"); } 
				set { SetValue("COL1273395188", value); } 
			}

			/// <summary>
			/// Gets field DelFlag 
			/// </summary>
			public string DelFlag { 
				get { return GetValue("COL12733951812"); } 
				set { SetValue("COL12733951812", value); } 
			}

			/// <summary>
			/// Gets field Modified 
			/// </summary>
			public string Modified { 
				get { return GetValue("COL12733951810"); } 
				set { SetValue("COL12733951810", value); } 
			}


			/// <summary>
			/// Gets Position attribute data 
			/// </summary>
			public AttributeData GetPositionAttributeData() { 
				return GetAttributeData("COL12733951814"); 
			}

			/// <summary>
			/// Gets Comment attribute data 
			/// </summary>
			public AttributeData GetCommentAttributeData() { 
				return GetAttributeData("COL1273395187"); 
			}

			/// <summary>
			/// Gets Mail attribute data 
			/// </summary>
			public AttributeData GetMailAttributeData() { 
				return GetAttributeData("COL1273395186"); 
			}

			/// <summary>
			/// Gets Phone attribute data 
			/// </summary>
			public AttributeData GetPhoneAttributeData() { 
				return GetAttributeData("COL1273395184"); 
			}

			/// <summary>
			/// Gets Address attribute data 
			/// </summary>
			public AttributeData GetAddressAttributeData() { 
				return GetAttributeData("COL12733951813"); 
			}

			/// <summary>
			/// Gets CustomerId attribute data 
			/// </summary>
			public AttributeData GetCustomerIdAttributeData() { 
				return GetAttributeData("COL1273395182"); 
			}

			/// <summary>
			/// Gets id attribute data 
			/// </summary>
			public AttributeData GetidAttributeData() { 
				return GetAttributeData("COL1273395181"); 
			}

			/// <summary>
			/// Gets ModifiedBy attribute data 
			/// </summary>
			public AttributeData GetModifiedByAttributeData() { 
				return GetAttributeData("COL12733951811"); 
			}

			/// <summary>
			/// Gets Name attribute data 
			/// </summary>
			public AttributeData GetNameAttributeData() { 
				return GetAttributeData("COL1273395183"); 
			}

			/// <summary>
			/// Gets CreatedBy attribute data 
			/// </summary>
			public AttributeData GetCreatedByAttributeData() { 
				return GetAttributeData("COL1273395189"); 
			}

			/// <summary>
			/// Gets Created attribute data 
			/// </summary>
			public AttributeData GetCreatedAttributeData() { 
				return GetAttributeData("COL1273395188"); 
			}

			/// <summary>
			/// Gets DelFlag attribute data 
			/// </summary>
			public AttributeData GetDelFlagAttributeData() { 
				return GetAttributeData("COL12733951812"); 
			}

			/// <summary>
			/// Gets Modified attribute data 
			/// </summary>
			public AttributeData GetModifiedAttributeData() { 
				return GetAttributeData("COL12733951810"); 
			}


			/// <summary>
			/// Gets column Position with alias  
			/// </summary>
			public string ColPosition { 
				get { return GetColumnName("COL12733951814"); } 
			}

			/// <summary>
			/// Gets column Comment with alias  
			/// </summary>
			public string ColComment { 
				get { return GetColumnName("COL1273395187"); } 
			}

			/// <summary>
			/// Gets column Mail with alias  
			/// </summary>
			public string ColMail { 
				get { return GetColumnName("COL1273395186"); } 
			}

			/// <summary>
			/// Gets column Phone with alias  
			/// </summary>
			public string ColPhone { 
				get { return GetColumnName("COL1273395184"); } 
			}

			/// <summary>
			/// Gets column Address with alias  
			/// </summary>
			public string ColAddress { 
				get { return GetColumnName("COL12733951813"); } 
			}

			/// <summary>
			/// Gets column CustomerId with alias  
			/// </summary>
			public string ColCustomerId { 
				get { return GetColumnName("COL1273395182"); } 
			}

			/// <summary>
			/// Gets column id with alias  
			/// </summary>
			public string Colid { 
				get { return GetColumnName("COL1273395181"); } 
			}

			/// <summary>
			/// Gets column ModifiedBy with alias  
			/// </summary>
			public string ColModifiedBy { 
				get { return GetColumnName("COL12733951811"); } 
			}

			/// <summary>
			/// Gets column Name with alias  
			/// </summary>
			public string ColName { 
				get { return GetColumnName("COL1273395183"); } 
			}

			/// <summary>
			/// Gets column CreatedBy with alias  
			/// </summary>
			public string ColCreatedBy { 
				get { return GetColumnName("COL1273395189"); } 
			}

			/// <summary>
			/// Gets column Created with alias  
			/// </summary>
			public string ColCreated { 
				get { return GetColumnName("COL1273395188"); } 
			}

			/// <summary>
			/// Gets column DelFlag with alias  
			/// </summary>
			public string ColDelFlag { 
				get { return GetColumnName("COL12733951812"); } 
			}

			/// <summary>
			/// Gets column Modified with alias  
			/// </summary>
			public string ColModified { 
				get { return GetColumnName("COL12733951810"); } 
			}


			/// <summary>
			/// Checks whether column Position is added in select statement 
			/// </summary>
			public bool IsSelectPosition { 
				get { return IsSelect("COL12733951814"); } 
				set { SetSelect("COL12733951814", value); } 
			}

			/// <summary>
			/// Checks whether column Comment is added in select statement 
			/// </summary>
			public bool IsSelectComment { 
				get { return IsSelect("COL1273395187"); } 
				set { SetSelect("COL1273395187", value); } 
			}

			/// <summary>
			/// Checks whether column Mail is added in select statement 
			/// </summary>
			public bool IsSelectMail { 
				get { return IsSelect("COL1273395186"); } 
				set { SetSelect("COL1273395186", value); } 
			}

			/// <summary>
			/// Checks whether column Phone is added in select statement 
			/// </summary>
			public bool IsSelectPhone { 
				get { return IsSelect("COL1273395184"); } 
				set { SetSelect("COL1273395184", value); } 
			}

			/// <summary>
			/// Checks whether column Address is added in select statement 
			/// </summary>
			public bool IsSelectAddress { 
				get { return IsSelect("COL12733951813"); } 
				set { SetSelect("COL12733951813", value); } 
			}

			/// <summary>
			/// Checks whether column CustomerId is added in select statement 
			/// </summary>
			public bool IsSelectCustomerId { 
				get { return IsSelect("COL1273395182"); } 
				set { SetSelect("COL1273395182", value); } 
			}

			/// <summary>
			/// Checks whether column id is added in select statement 
			/// </summary>
			public bool IsSelectid { 
				get { return IsSelect("COL1273395181"); } 
				set { SetSelect("COL1273395181", value); } 
			}

			/// <summary>
			/// Checks whether column ModifiedBy is added in select statement 
			/// </summary>
			public bool IsSelectModifiedBy { 
				get { return IsSelect("COL12733951811"); } 
				set { SetSelect("COL12733951811", value); } 
			}

			/// <summary>
			/// Checks whether column Name is added in select statement 
			/// </summary>
			public bool IsSelectName { 
				get { return IsSelect("COL1273395183"); } 
				set { SetSelect("COL1273395183", value); } 
			}

			/// <summary>
			/// Checks whether column CreatedBy is added in select statement 
			/// </summary>
			public bool IsSelectCreatedBy { 
				get { return IsSelect("COL1273395189"); } 
				set { SetSelect("COL1273395189", value); } 
			}

			/// <summary>
			/// Checks whether column Created is added in select statement 
			/// </summary>
			public bool IsSelectCreated { 
				get { return IsSelect("COL1273395188"); } 
				set { SetSelect("COL1273395188", value); } 
			}

			/// <summary>
			/// Checks whether column DelFlag is added in select statement 
			/// </summary>
			public bool IsSelectDelFlag { 
				get { return IsSelect("COL12733951812"); } 
				set { SetSelect("COL12733951812", value); } 
			}

			/// <summary>
			/// Checks whether column Modified is added in select statement 
			/// </summary>
			public bool IsSelectModified { 
				get { return IsSelect("COL12733951810"); } 
				set { SetSelect("COL12733951810", value); } 
			}



	}
}