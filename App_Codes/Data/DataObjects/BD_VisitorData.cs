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
	public class BD_VisitorData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ1240391488";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of BD_Visitor 
			/// </summary>
			public BD_VisitorData(string objectID): base(objectID) {}  

			public BD_VisitorData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field id 
			/// </summary>
			public string id { 
				get { return GetValue("COL12403914881"); } 
				set { SetValue("COL12403914881", value); } 
			}

			/// <summary>
			/// Gets field Phone 
			/// </summary>
			public string Phone { 
				get { return GetValue("COL12403914886"); } 
				set { SetValue("COL12403914886", value); } 
			}

			/// <summary>
			/// Gets field RequiredFloor 
			/// </summary>
			public string RequiredFloor { 
				get { return GetValue("COL124039148810"); } 
				set { SetValue("COL124039148810", value); } 
			}

			/// <summary>
			/// Gets field Name 
			/// </summary>
			public string Name { 
				get { return GetValue("COL12403914883"); } 
				set { SetValue("COL12403914883", value); } 
			}

			/// <summary>
			/// Gets field CreatedBy 
			/// </summary>
			public string CreatedBy { 
				get { return GetValue("COL124039148813"); } 
				set { SetValue("COL124039148813", value); } 
			}

			/// <summary>
			/// Gets field RequiredArea 
			/// </summary>
			public string RequiredArea { 
				get { return GetValue("COL12403914888"); } 
				set { SetValue("COL12403914888", value); } 
			}

			/// <summary>
			/// Gets field ModifiedBy 
			/// </summary>
			public string ModifiedBy { 
				get { return GetValue("COL124039148815"); } 
				set { SetValue("COL124039148815", value); } 
			}

			/// <summary>
			/// Gets field DelFlag 
			/// </summary>
			public string DelFlag { 
				get { return GetValue("COL124039148816"); } 
				set { SetValue("COL124039148816", value); } 
			}

			/// <summary>
			/// Gets field Contact 
			/// </summary>
			public string Contact { 
				get { return GetValue("COL12403914885"); } 
				set { SetValue("COL12403914885", value); } 
			}

			/// <summary>
			/// Gets field BuildingId 
			/// </summary>
			public string BuildingId { 
				get { return GetValue("COL12403914882"); } 
				set { SetValue("COL12403914882", value); } 
			}

			/// <summary>
			/// Gets field Comment 
			/// </summary>
			public string Comment { 
				get { return GetValue("COL124039148811"); } 
				set { SetValue("COL124039148811", value); } 
			}

			/// <summary>
			/// Gets field VisitDate 
			/// </summary>
			public string VisitDate { 
				get { return GetValue("COL12403914887"); } 
				set { SetValue("COL12403914887", value); } 
			}

			/// <summary>
			/// Gets field Created 
			/// </summary>
			public string Created { 
				get { return GetValue("COL124039148812"); } 
				set { SetValue("COL124039148812", value); } 
			}

			/// <summary>
			/// Gets field Modified 
			/// </summary>
			public string Modified { 
				get { return GetValue("COL124039148814"); } 
				set { SetValue("COL124039148814", value); } 
			}

			/// <summary>
			/// Gets field Address 
			/// </summary>
			public string Address { 
				get { return GetValue("COL12403914884"); } 
				set { SetValue("COL12403914884", value); } 
			}

			/// <summary>
			/// Gets field RequiredRegion 
			/// </summary>
			public string RequiredRegion { 
				get { return GetValue("COL12403914889"); } 
				set { SetValue("COL12403914889", value); } 
			}

			/// <summary>
			/// Gets field Broker 
			/// </summary>
			public string Broker { 
				get { return GetValue("COL124039148817"); } 
				set { SetValue("COL124039148817", value); } 
			}


			/// <summary>
			/// Gets id attribute data 
			/// </summary>
			public AttributeData GetidAttributeData() { 
				return GetAttributeData("COL12403914881"); 
			}

			/// <summary>
			/// Gets Phone attribute data 
			/// </summary>
			public AttributeData GetPhoneAttributeData() { 
				return GetAttributeData("COL12403914886"); 
			}

			/// <summary>
			/// Gets RequiredFloor attribute data 
			/// </summary>
			public AttributeData GetRequiredFloorAttributeData() { 
				return GetAttributeData("COL124039148810"); 
			}

			/// <summary>
			/// Gets Name attribute data 
			/// </summary>
			public AttributeData GetNameAttributeData() { 
				return GetAttributeData("COL12403914883"); 
			}

			/// <summary>
			/// Gets CreatedBy attribute data 
			/// </summary>
			public AttributeData GetCreatedByAttributeData() { 
				return GetAttributeData("COL124039148813"); 
			}

			/// <summary>
			/// Gets RequiredArea attribute data 
			/// </summary>
			public AttributeData GetRequiredAreaAttributeData() { 
				return GetAttributeData("COL12403914888"); 
			}

			/// <summary>
			/// Gets ModifiedBy attribute data 
			/// </summary>
			public AttributeData GetModifiedByAttributeData() { 
				return GetAttributeData("COL124039148815"); 
			}

			/// <summary>
			/// Gets DelFlag attribute data 
			/// </summary>
			public AttributeData GetDelFlagAttributeData() { 
				return GetAttributeData("COL124039148816"); 
			}

			/// <summary>
			/// Gets Contact attribute data 
			/// </summary>
			public AttributeData GetContactAttributeData() { 
				return GetAttributeData("COL12403914885"); 
			}

			/// <summary>
			/// Gets BuildingId attribute data 
			/// </summary>
			public AttributeData GetBuildingIdAttributeData() { 
				return GetAttributeData("COL12403914882"); 
			}

			/// <summary>
			/// Gets Comment attribute data 
			/// </summary>
			public AttributeData GetCommentAttributeData() { 
				return GetAttributeData("COL124039148811"); 
			}

			/// <summary>
			/// Gets VisitDate attribute data 
			/// </summary>
			public AttributeData GetVisitDateAttributeData() { 
				return GetAttributeData("COL12403914887"); 
			}

			/// <summary>
			/// Gets Created attribute data 
			/// </summary>
			public AttributeData GetCreatedAttributeData() { 
				return GetAttributeData("COL124039148812"); 
			}

			/// <summary>
			/// Gets Modified attribute data 
			/// </summary>
			public AttributeData GetModifiedAttributeData() { 
				return GetAttributeData("COL124039148814"); 
			}

			/// <summary>
			/// Gets Address attribute data 
			/// </summary>
			public AttributeData GetAddressAttributeData() { 
				return GetAttributeData("COL12403914884"); 
			}

			/// <summary>
			/// Gets RequiredRegion attribute data 
			/// </summary>
			public AttributeData GetRequiredRegionAttributeData() { 
				return GetAttributeData("COL12403914889"); 
			}

			/// <summary>
			/// Gets Broker attribute data 
			/// </summary>
			public AttributeData GetBrokerAttributeData() { 
				return GetAttributeData("COL124039148817"); 
			}


			/// <summary>
			/// Gets column id with alias  
			/// </summary>
			public string Colid { 
				get { return GetColumnName("COL12403914881"); } 
			}

			/// <summary>
			/// Gets column Phone with alias  
			/// </summary>
			public string ColPhone { 
				get { return GetColumnName("COL12403914886"); } 
			}

			/// <summary>
			/// Gets column RequiredFloor with alias  
			/// </summary>
			public string ColRequiredFloor { 
				get { return GetColumnName("COL124039148810"); } 
			}

			/// <summary>
			/// Gets column Name with alias  
			/// </summary>
			public string ColName { 
				get { return GetColumnName("COL12403914883"); } 
			}

			/// <summary>
			/// Gets column CreatedBy with alias  
			/// </summary>
			public string ColCreatedBy { 
				get { return GetColumnName("COL124039148813"); } 
			}

			/// <summary>
			/// Gets column RequiredArea with alias  
			/// </summary>
			public string ColRequiredArea { 
				get { return GetColumnName("COL12403914888"); } 
			}

			/// <summary>
			/// Gets column ModifiedBy with alias  
			/// </summary>
			public string ColModifiedBy { 
				get { return GetColumnName("COL124039148815"); } 
			}

			/// <summary>
			/// Gets column DelFlag with alias  
			/// </summary>
			public string ColDelFlag { 
				get { return GetColumnName("COL124039148816"); } 
			}

			/// <summary>
			/// Gets column Contact with alias  
			/// </summary>
			public string ColContact { 
				get { return GetColumnName("COL12403914885"); } 
			}

			/// <summary>
			/// Gets column BuildingId with alias  
			/// </summary>
			public string ColBuildingId { 
				get { return GetColumnName("COL12403914882"); } 
			}

			/// <summary>
			/// Gets column Comment with alias  
			/// </summary>
			public string ColComment { 
				get { return GetColumnName("COL124039148811"); } 
			}

			/// <summary>
			/// Gets column VisitDate with alias  
			/// </summary>
			public string ColVisitDate { 
				get { return GetColumnName("COL12403914887"); } 
			}

			/// <summary>
			/// Gets column Created with alias  
			/// </summary>
			public string ColCreated { 
				get { return GetColumnName("COL124039148812"); } 
			}

			/// <summary>
			/// Gets column Modified with alias  
			/// </summary>
			public string ColModified { 
				get { return GetColumnName("COL124039148814"); } 
			}

			/// <summary>
			/// Gets column Address with alias  
			/// </summary>
			public string ColAddress { 
				get { return GetColumnName("COL12403914884"); } 
			}

			/// <summary>
			/// Gets column RequiredRegion with alias  
			/// </summary>
			public string ColRequiredRegion { 
				get { return GetColumnName("COL12403914889"); } 
			}

			/// <summary>
			/// Gets column Broker with alias  
			/// </summary>
			public string ColBroker { 
				get { return GetColumnName("COL124039148817"); } 
			}


			/// <summary>
			/// Checks whether column id is added in select statement 
			/// </summary>
			public bool IsSelectid { 
				get { return IsSelect("COL12403914881"); } 
				set { SetSelect("COL12403914881", value); } 
			}

			/// <summary>
			/// Checks whether column Phone is added in select statement 
			/// </summary>
			public bool IsSelectPhone { 
				get { return IsSelect("COL12403914886"); } 
				set { SetSelect("COL12403914886", value); } 
			}

			/// <summary>
			/// Checks whether column RequiredFloor is added in select statement 
			/// </summary>
			public bool IsSelectRequiredFloor { 
				get { return IsSelect("COL124039148810"); } 
				set { SetSelect("COL124039148810", value); } 
			}

			/// <summary>
			/// Checks whether column Name is added in select statement 
			/// </summary>
			public bool IsSelectName { 
				get { return IsSelect("COL12403914883"); } 
				set { SetSelect("COL12403914883", value); } 
			}

			/// <summary>
			/// Checks whether column CreatedBy is added in select statement 
			/// </summary>
			public bool IsSelectCreatedBy { 
				get { return IsSelect("COL124039148813"); } 
				set { SetSelect("COL124039148813", value); } 
			}

			/// <summary>
			/// Checks whether column RequiredArea is added in select statement 
			/// </summary>
			public bool IsSelectRequiredArea { 
				get { return IsSelect("COL12403914888"); } 
				set { SetSelect("COL12403914888", value); } 
			}

			/// <summary>
			/// Checks whether column ModifiedBy is added in select statement 
			/// </summary>
			public bool IsSelectModifiedBy { 
				get { return IsSelect("COL124039148815"); } 
				set { SetSelect("COL124039148815", value); } 
			}

			/// <summary>
			/// Checks whether column DelFlag is added in select statement 
			/// </summary>
			public bool IsSelectDelFlag { 
				get { return IsSelect("COL124039148816"); } 
				set { SetSelect("COL124039148816", value); } 
			}

			/// <summary>
			/// Checks whether column Contact is added in select statement 
			/// </summary>
			public bool IsSelectContact { 
				get { return IsSelect("COL12403914885"); } 
				set { SetSelect("COL12403914885", value); } 
			}

			/// <summary>
			/// Checks whether column BuildingId is added in select statement 
			/// </summary>
			public bool IsSelectBuildingId { 
				get { return IsSelect("COL12403914882"); } 
				set { SetSelect("COL12403914882", value); } 
			}

			/// <summary>
			/// Checks whether column Comment is added in select statement 
			/// </summary>
			public bool IsSelectComment { 
				get { return IsSelect("COL124039148811"); } 
				set { SetSelect("COL124039148811", value); } 
			}

			/// <summary>
			/// Checks whether column VisitDate is added in select statement 
			/// </summary>
			public bool IsSelectVisitDate { 
				get { return IsSelect("COL12403914887"); } 
				set { SetSelect("COL12403914887", value); } 
			}

			/// <summary>
			/// Checks whether column Created is added in select statement 
			/// </summary>
			public bool IsSelectCreated { 
				get { return IsSelect("COL124039148812"); } 
				set { SetSelect("COL124039148812", value); } 
			}

			/// <summary>
			/// Checks whether column Modified is added in select statement 
			/// </summary>
			public bool IsSelectModified { 
				get { return IsSelect("COL124039148814"); } 
				set { SetSelect("COL124039148814", value); } 
			}

			/// <summary>
			/// Checks whether column Address is added in select statement 
			/// </summary>
			public bool IsSelectAddress { 
				get { return IsSelect("COL12403914884"); } 
				set { SetSelect("COL12403914884", value); } 
			}

			/// <summary>
			/// Checks whether column RequiredRegion is added in select statement 
			/// </summary>
			public bool IsSelectRequiredRegion { 
				get { return IsSelect("COL12403914889"); } 
				set { SetSelect("COL12403914889", value); } 
			}

			/// <summary>
			/// Checks whether column Broker is added in select statement 
			/// </summary>
			public bool IsSelectBroker { 
				get { return IsSelect("COL124039148817"); } 
				set { SetSelect("COL124039148817", value); } 
			}



	}
}