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
	public class BD_ComplainData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ1282103608";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of BD_Complain 
			/// </summary>
			public BD_ComplainData(string objectID): base(objectID) {}  

			public BD_ComplainData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field Created 
			/// </summary>
			public string Created { 
				get { return GetValue("COL12821036089"); } 
				set { SetValue("COL12821036089", value); } 
			}

			/// <summary>
			/// Gets field Complainer 
			/// </summary>
			public string Complainer { 
				get { return GetValue("COL128210360814"); } 
				set { SetValue("COL128210360814", value); } 
			}

			/// <summary>
			/// Gets field ComplainContent 
			/// </summary>
			public string ComplainContent { 
				get { return GetValue("COL12821036084"); } 
				set { SetValue("COL12821036084", value); } 
			}

			/// <summary>
			/// Gets field id 
			/// </summary>
			public string id { 
				get { return GetValue("COL12821036081"); } 
				set { SetValue("COL12821036081", value); } 
			}

			/// <summary>
			/// Gets field Email 
			/// </summary>
			public string Email { 
				get { return GetValue("COL128210360817"); } 
				set { SetValue("COL128210360817", value); } 
			}

			/// <summary>
			/// Gets field Solution 
			/// </summary>
			public string Solution { 
				get { return GetValue("COL128210360818"); } 
				set { SetValue("COL128210360818", value); } 
			}

			/// <summary>
			/// Gets field BuildingId 
			/// </summary>
			public string BuildingId { 
				get { return GetValue("COL12821036082"); } 
				set { SetValue("COL12821036082", value); } 
			}

			/// <summary>
			/// Gets field ModifiedBy 
			/// </summary>
			public string ModifiedBy { 
				get { return GetValue("COL128210360812"); } 
				set { SetValue("COL128210360812", value); } 
			}

			/// <summary>
			/// Gets field Description 
			/// </summary>
			public string Description { 
				get { return GetValue("COL12821036087"); } 
				set { SetValue("COL12821036087", value); } 
			}

			/// <summary>
			/// Gets field Violator 
			/// </summary>
			public string Violator { 
				get { return GetValue("COL128210360815"); } 
				set { SetValue("COL128210360815", value); } 
			}

			/// <summary>
			/// Gets field Comment 
			/// </summary>
			public string Comment { 
				get { return GetValue("COL12821036088"); } 
				set { SetValue("COL12821036088", value); } 
			}

			/// <summary>
			/// Gets field Phone 
			/// </summary>
			public string Phone { 
				get { return GetValue("COL128210360816"); } 
				set { SetValue("COL128210360816", value); } 
			}

			/// <summary>
			/// Gets field ComplainDate 
			/// </summary>
			public string ComplainDate { 
				get { return GetValue("COL12821036085"); } 
				set { SetValue("COL12821036085", value); } 
			}

			/// <summary>
			/// Gets field CreatedBy 
			/// </summary>
			public string CreatedBy { 
				get { return GetValue("COL128210360810"); } 
				set { SetValue("COL128210360810", value); } 
			}

			/// <summary>
			/// Gets field Modified 
			/// </summary>
			public string Modified { 
				get { return GetValue("COL128210360811"); } 
				set { SetValue("COL128210360811", value); } 
			}

			/// <summary>
			/// Gets field Type 
			/// </summary>
			public string Type { 
				get { return GetValue("COL12821036086"); } 
				set { SetValue("COL12821036086", value); } 
			}

			/// <summary>
			/// Gets field DelFlag 
			/// </summary>
			public string DelFlag { 
				get { return GetValue("COL128210360813"); } 
				set { SetValue("COL128210360813", value); } 
			}

			/// <summary>
			/// Gets field CustomerId 
			/// </summary>
			public string CustomerId { 
				get { return GetValue("COL12821036083"); } 
				set { SetValue("COL12821036083", value); } 
			}


			/// <summary>
			/// Gets Created attribute data 
			/// </summary>
			public AttributeData GetCreatedAttributeData() { 
				return GetAttributeData("COL12821036089"); 
			}

			/// <summary>
			/// Gets Complainer attribute data 
			/// </summary>
			public AttributeData GetComplainerAttributeData() { 
				return GetAttributeData("COL128210360814"); 
			}

			/// <summary>
			/// Gets ComplainContent attribute data 
			/// </summary>
			public AttributeData GetComplainContentAttributeData() { 
				return GetAttributeData("COL12821036084"); 
			}

			/// <summary>
			/// Gets id attribute data 
			/// </summary>
			public AttributeData GetidAttributeData() { 
				return GetAttributeData("COL12821036081"); 
			}

			/// <summary>
			/// Gets Email attribute data 
			/// </summary>
			public AttributeData GetEmailAttributeData() { 
				return GetAttributeData("COL128210360817"); 
			}

			/// <summary>
			/// Gets Solution attribute data 
			/// </summary>
			public AttributeData GetSolutionAttributeData() { 
				return GetAttributeData("COL128210360818"); 
			}

			/// <summary>
			/// Gets BuildingId attribute data 
			/// </summary>
			public AttributeData GetBuildingIdAttributeData() { 
				return GetAttributeData("COL12821036082"); 
			}

			/// <summary>
			/// Gets ModifiedBy attribute data 
			/// </summary>
			public AttributeData GetModifiedByAttributeData() { 
				return GetAttributeData("COL128210360812"); 
			}

			/// <summary>
			/// Gets Description attribute data 
			/// </summary>
			public AttributeData GetDescriptionAttributeData() { 
				return GetAttributeData("COL12821036087"); 
			}

			/// <summary>
			/// Gets Violator attribute data 
			/// </summary>
			public AttributeData GetViolatorAttributeData() { 
				return GetAttributeData("COL128210360815"); 
			}

			/// <summary>
			/// Gets Comment attribute data 
			/// </summary>
			public AttributeData GetCommentAttributeData() { 
				return GetAttributeData("COL12821036088"); 
			}

			/// <summary>
			/// Gets Phone attribute data 
			/// </summary>
			public AttributeData GetPhoneAttributeData() { 
				return GetAttributeData("COL128210360816"); 
			}

			/// <summary>
			/// Gets ComplainDate attribute data 
			/// </summary>
			public AttributeData GetComplainDateAttributeData() { 
				return GetAttributeData("COL12821036085"); 
			}

			/// <summary>
			/// Gets CreatedBy attribute data 
			/// </summary>
			public AttributeData GetCreatedByAttributeData() { 
				return GetAttributeData("COL128210360810"); 
			}

			/// <summary>
			/// Gets Modified attribute data 
			/// </summary>
			public AttributeData GetModifiedAttributeData() { 
				return GetAttributeData("COL128210360811"); 
			}

			/// <summary>
			/// Gets Type attribute data 
			/// </summary>
			public AttributeData GetTypeAttributeData() { 
				return GetAttributeData("COL12821036086"); 
			}

			/// <summary>
			/// Gets DelFlag attribute data 
			/// </summary>
			public AttributeData GetDelFlagAttributeData() { 
				return GetAttributeData("COL128210360813"); 
			}

			/// <summary>
			/// Gets CustomerId attribute data 
			/// </summary>
			public AttributeData GetCustomerIdAttributeData() { 
				return GetAttributeData("COL12821036083"); 
			}


			/// <summary>
			/// Gets column Created with alias  
			/// </summary>
			public string ColCreated { 
				get { return GetColumnName("COL12821036089"); } 
			}

			/// <summary>
			/// Gets column Complainer with alias  
			/// </summary>
			public string ColComplainer { 
				get { return GetColumnName("COL128210360814"); } 
			}

			/// <summary>
			/// Gets column ComplainContent with alias  
			/// </summary>
			public string ColComplainContent { 
				get { return GetColumnName("COL12821036084"); } 
			}

			/// <summary>
			/// Gets column id with alias  
			/// </summary>
			public string Colid { 
				get { return GetColumnName("COL12821036081"); } 
			}

			/// <summary>
			/// Gets column Email with alias  
			/// </summary>
			public string ColEmail { 
				get { return GetColumnName("COL128210360817"); } 
			}

			/// <summary>
			/// Gets column Solution with alias  
			/// </summary>
			public string ColSolution { 
				get { return GetColumnName("COL128210360818"); } 
			}

			/// <summary>
			/// Gets column BuildingId with alias  
			/// </summary>
			public string ColBuildingId { 
				get { return GetColumnName("COL12821036082"); } 
			}

			/// <summary>
			/// Gets column ModifiedBy with alias  
			/// </summary>
			public string ColModifiedBy { 
				get { return GetColumnName("COL128210360812"); } 
			}

			/// <summary>
			/// Gets column Description with alias  
			/// </summary>
			public string ColDescription { 
				get { return GetColumnName("COL12821036087"); } 
			}

			/// <summary>
			/// Gets column Violator with alias  
			/// </summary>
			public string ColViolator { 
				get { return GetColumnName("COL128210360815"); } 
			}

			/// <summary>
			/// Gets column Comment with alias  
			/// </summary>
			public string ColComment { 
				get { return GetColumnName("COL12821036088"); } 
			}

			/// <summary>
			/// Gets column Phone with alias  
			/// </summary>
			public string ColPhone { 
				get { return GetColumnName("COL128210360816"); } 
			}

			/// <summary>
			/// Gets column ComplainDate with alias  
			/// </summary>
			public string ColComplainDate { 
				get { return GetColumnName("COL12821036085"); } 
			}

			/// <summary>
			/// Gets column CreatedBy with alias  
			/// </summary>
			public string ColCreatedBy { 
				get { return GetColumnName("COL128210360810"); } 
			}

			/// <summary>
			/// Gets column Modified with alias  
			/// </summary>
			public string ColModified { 
				get { return GetColumnName("COL128210360811"); } 
			}

			/// <summary>
			/// Gets column Type with alias  
			/// </summary>
			public string ColType { 
				get { return GetColumnName("COL12821036086"); } 
			}

			/// <summary>
			/// Gets column DelFlag with alias  
			/// </summary>
			public string ColDelFlag { 
				get { return GetColumnName("COL128210360813"); } 
			}

			/// <summary>
			/// Gets column CustomerId with alias  
			/// </summary>
			public string ColCustomerId { 
				get { return GetColumnName("COL12821036083"); } 
			}


			/// <summary>
			/// Checks whether column Created is added in select statement 
			/// </summary>
			public bool IsSelectCreated { 
				get { return IsSelect("COL12821036089"); } 
				set { SetSelect("COL12821036089", value); } 
			}

			/// <summary>
			/// Checks whether column Complainer is added in select statement 
			/// </summary>
			public bool IsSelectComplainer { 
				get { return IsSelect("COL128210360814"); } 
				set { SetSelect("COL128210360814", value); } 
			}

			/// <summary>
			/// Checks whether column ComplainContent is added in select statement 
			/// </summary>
			public bool IsSelectComplainContent { 
				get { return IsSelect("COL12821036084"); } 
				set { SetSelect("COL12821036084", value); } 
			}

			/// <summary>
			/// Checks whether column id is added in select statement 
			/// </summary>
			public bool IsSelectid { 
				get { return IsSelect("COL12821036081"); } 
				set { SetSelect("COL12821036081", value); } 
			}

			/// <summary>
			/// Checks whether column Email is added in select statement 
			/// </summary>
			public bool IsSelectEmail { 
				get { return IsSelect("COL128210360817"); } 
				set { SetSelect("COL128210360817", value); } 
			}

			/// <summary>
			/// Checks whether column Solution is added in select statement 
			/// </summary>
			public bool IsSelectSolution { 
				get { return IsSelect("COL128210360818"); } 
				set { SetSelect("COL128210360818", value); } 
			}

			/// <summary>
			/// Checks whether column BuildingId is added in select statement 
			/// </summary>
			public bool IsSelectBuildingId { 
				get { return IsSelect("COL12821036082"); } 
				set { SetSelect("COL12821036082", value); } 
			}

			/// <summary>
			/// Checks whether column ModifiedBy is added in select statement 
			/// </summary>
			public bool IsSelectModifiedBy { 
				get { return IsSelect("COL128210360812"); } 
				set { SetSelect("COL128210360812", value); } 
			}

			/// <summary>
			/// Checks whether column Description is added in select statement 
			/// </summary>
			public bool IsSelectDescription { 
				get { return IsSelect("COL12821036087"); } 
				set { SetSelect("COL12821036087", value); } 
			}

			/// <summary>
			/// Checks whether column Violator is added in select statement 
			/// </summary>
			public bool IsSelectViolator { 
				get { return IsSelect("COL128210360815"); } 
				set { SetSelect("COL128210360815", value); } 
			}

			/// <summary>
			/// Checks whether column Comment is added in select statement 
			/// </summary>
			public bool IsSelectComment { 
				get { return IsSelect("COL12821036088"); } 
				set { SetSelect("COL12821036088", value); } 
			}

			/// <summary>
			/// Checks whether column Phone is added in select statement 
			/// </summary>
			public bool IsSelectPhone { 
				get { return IsSelect("COL128210360816"); } 
				set { SetSelect("COL128210360816", value); } 
			}

			/// <summary>
			/// Checks whether column ComplainDate is added in select statement 
			/// </summary>
			public bool IsSelectComplainDate { 
				get { return IsSelect("COL12821036085"); } 
				set { SetSelect("COL12821036085", value); } 
			}

			/// <summary>
			/// Checks whether column CreatedBy is added in select statement 
			/// </summary>
			public bool IsSelectCreatedBy { 
				get { return IsSelect("COL128210360810"); } 
				set { SetSelect("COL128210360810", value); } 
			}

			/// <summary>
			/// Checks whether column Modified is added in select statement 
			/// </summary>
			public bool IsSelectModified { 
				get { return IsSelect("COL128210360811"); } 
				set { SetSelect("COL128210360811", value); } 
			}

			/// <summary>
			/// Checks whether column Type is added in select statement 
			/// </summary>
			public bool IsSelectType { 
				get { return IsSelect("COL12821036086"); } 
				set { SetSelect("COL12821036086", value); } 
			}

			/// <summary>
			/// Checks whether column DelFlag is added in select statement 
			/// </summary>
			public bool IsSelectDelFlag { 
				get { return IsSelect("COL128210360813"); } 
				set { SetSelect("COL128210360813", value); } 
			}

			/// <summary>
			/// Checks whether column CustomerId is added in select statement 
			/// </summary>
			public bool IsSelectCustomerId { 
				get { return IsSelect("COL12821036083"); } 
				set { SetSelect("COL12821036083", value); } 
			}



	}
}