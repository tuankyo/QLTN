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
	public class BD_StaffData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ898102240";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of BD_Staff 
			/// </summary>
			public BD_StaffData(string objectID): base(objectID) {}  

			public BD_StaffData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field ModifiedBy 
			/// </summary>
			public string ModifiedBy { 
				get { return GetValue("COL89810224021"); } 
				set { SetValue("COL89810224021", value); } 
			}

			/// <summary>
			/// Gets field CreatedBy 
			/// </summary>
			public string CreatedBy { 
				get { return GetValue("COL89810224019"); } 
				set { SetValue("COL89810224019", value); } 
			}

			/// <summary>
			/// Gets field JobContent 
			/// </summary>
			public string JobContent { 
				get { return GetValue("COL89810224024"); } 
				set { SetValue("COL89810224024", value); } 
			}

			/// <summary>
			/// Gets field Name 
			/// </summary>
			public string Name { 
				get { return GetValue("COL8981022403"); } 
				set { SetValue("COL8981022403", value); } 
			}

			/// <summary>
			/// Gets field BuildingId 
			/// </summary>
			public string BuildingId { 
				get { return GetValue("COL8981022402"); } 
				set { SetValue("COL8981022402", value); } 
			}

			/// <summary>
			/// Gets field StaffId 
			/// </summary>
			public string StaffId { 
				get { return GetValue("COL8981022401"); } 
				set { SetValue("COL8981022401", value); } 
			}

			/// <summary>
			/// Gets field JobTypeId 
			/// </summary>
			public string JobTypeId { 
				get { return GetValue("COL8981022407"); } 
				set { SetValue("COL8981022407", value); } 
			}

			/// <summary>
			/// Gets field Mail 
			/// </summary>
			public string Mail { 
				get { return GetValue("COL8981022406"); } 
				set { SetValue("COL8981022406", value); } 
			}

			/// <summary>
			/// Gets field Address 
			/// </summary>
			public string Address { 
				get { return GetValue("COL8981022405"); } 
				set { SetValue("COL8981022405", value); } 
			}

			/// <summary>
			/// Gets field Phone 
			/// </summary>
			public string Phone { 
				get { return GetValue("COL8981022404"); } 
				set { SetValue("COL8981022404", value); } 
			}

			/// <summary>
			/// Gets field DelFlag 
			/// </summary>
			public string DelFlag { 
				get { return GetValue("COL89810224022"); } 
				set { SetValue("COL89810224022", value); } 
			}

			/// <summary>
			/// Gets field JobEnd 
			/// </summary>
			public string JobEnd { 
				get { return GetValue("COL8981022409"); } 
				set { SetValue("COL8981022409", value); } 
			}

			/// <summary>
			/// Gets field JobBegin 
			/// </summary>
			public string JobBegin { 
				get { return GetValue("COL8981022408"); } 
				set { SetValue("COL8981022408", value); } 
			}

			/// <summary>
			/// Gets field WorkingPlaceId 
			/// </summary>
			public string WorkingPlaceId { 
				get { return GetValue("COL89810224025"); } 
				set { SetValue("COL89810224025", value); } 
			}

			/// <summary>
			/// Gets field Modified 
			/// </summary>
			public string Modified { 
				get { return GetValue("COL89810224020"); } 
				set { SetValue("COL89810224020", value); } 
			}

			/// <summary>
			/// Gets field Created 
			/// </summary>
			public string Created { 
				get { return GetValue("COL89810224018"); } 
				set { SetValue("COL89810224018", value); } 
			}

			/// <summary>
			/// Gets field id 
			/// </summary>
			public string id { 
				get { return GetValue("COL89810224023"); } 
				set { SetValue("COL89810224023", value); } 
			}

			/// <summary>
			/// Gets field Comment 
			/// </summary>
			public string Comment { 
				get { return GetValue("COL89810224017"); } 
				set { SetValue("COL89810224017", value); } 
			}

			/// <summary>
			/// Gets field Position 
			/// </summary>
			public string Position { 
				get { return GetValue("COL89810224016"); } 
				set { SetValue("COL89810224016", value); } 
			}


			/// <summary>
			/// Gets ModifiedBy attribute data 
			/// </summary>
			public AttributeData GetModifiedByAttributeData() { 
				return GetAttributeData("COL89810224021"); 
			}

			/// <summary>
			/// Gets CreatedBy attribute data 
			/// </summary>
			public AttributeData GetCreatedByAttributeData() { 
				return GetAttributeData("COL89810224019"); 
			}

			/// <summary>
			/// Gets JobContent attribute data 
			/// </summary>
			public AttributeData GetJobContentAttributeData() { 
				return GetAttributeData("COL89810224024"); 
			}

			/// <summary>
			/// Gets Name attribute data 
			/// </summary>
			public AttributeData GetNameAttributeData() { 
				return GetAttributeData("COL8981022403"); 
			}

			/// <summary>
			/// Gets BuildingId attribute data 
			/// </summary>
			public AttributeData GetBuildingIdAttributeData() { 
				return GetAttributeData("COL8981022402"); 
			}

			/// <summary>
			/// Gets StaffId attribute data 
			/// </summary>
			public AttributeData GetStaffIdAttributeData() { 
				return GetAttributeData("COL8981022401"); 
			}

			/// <summary>
			/// Gets JobTypeId attribute data 
			/// </summary>
			public AttributeData GetJobTypeIdAttributeData() { 
				return GetAttributeData("COL8981022407"); 
			}

			/// <summary>
			/// Gets Mail attribute data 
			/// </summary>
			public AttributeData GetMailAttributeData() { 
				return GetAttributeData("COL8981022406"); 
			}

			/// <summary>
			/// Gets Address attribute data 
			/// </summary>
			public AttributeData GetAddressAttributeData() { 
				return GetAttributeData("COL8981022405"); 
			}

			/// <summary>
			/// Gets Phone attribute data 
			/// </summary>
			public AttributeData GetPhoneAttributeData() { 
				return GetAttributeData("COL8981022404"); 
			}

			/// <summary>
			/// Gets DelFlag attribute data 
			/// </summary>
			public AttributeData GetDelFlagAttributeData() { 
				return GetAttributeData("COL89810224022"); 
			}

			/// <summary>
			/// Gets JobEnd attribute data 
			/// </summary>
			public AttributeData GetJobEndAttributeData() { 
				return GetAttributeData("COL8981022409"); 
			}

			/// <summary>
			/// Gets JobBegin attribute data 
			/// </summary>
			public AttributeData GetJobBeginAttributeData() { 
				return GetAttributeData("COL8981022408"); 
			}

			/// <summary>
			/// Gets WorkingPlaceId attribute data 
			/// </summary>
			public AttributeData GetWorkingPlaceIdAttributeData() { 
				return GetAttributeData("COL89810224025"); 
			}

			/// <summary>
			/// Gets Modified attribute data 
			/// </summary>
			public AttributeData GetModifiedAttributeData() { 
				return GetAttributeData("COL89810224020"); 
			}

			/// <summary>
			/// Gets Created attribute data 
			/// </summary>
			public AttributeData GetCreatedAttributeData() { 
				return GetAttributeData("COL89810224018"); 
			}

			/// <summary>
			/// Gets id attribute data 
			/// </summary>
			public AttributeData GetidAttributeData() { 
				return GetAttributeData("COL89810224023"); 
			}

			/// <summary>
			/// Gets Comment attribute data 
			/// </summary>
			public AttributeData GetCommentAttributeData() { 
				return GetAttributeData("COL89810224017"); 
			}

			/// <summary>
			/// Gets Position attribute data 
			/// </summary>
			public AttributeData GetPositionAttributeData() { 
				return GetAttributeData("COL89810224016"); 
			}


			/// <summary>
			/// Gets column ModifiedBy with alias  
			/// </summary>
			public string ColModifiedBy { 
				get { return GetColumnName("COL89810224021"); } 
			}

			/// <summary>
			/// Gets column CreatedBy with alias  
			/// </summary>
			public string ColCreatedBy { 
				get { return GetColumnName("COL89810224019"); } 
			}

			/// <summary>
			/// Gets column JobContent with alias  
			/// </summary>
			public string ColJobContent { 
				get { return GetColumnName("COL89810224024"); } 
			}

			/// <summary>
			/// Gets column Name with alias  
			/// </summary>
			public string ColName { 
				get { return GetColumnName("COL8981022403"); } 
			}

			/// <summary>
			/// Gets column BuildingId with alias  
			/// </summary>
			public string ColBuildingId { 
				get { return GetColumnName("COL8981022402"); } 
			}

			/// <summary>
			/// Gets column StaffId with alias  
			/// </summary>
			public string ColStaffId { 
				get { return GetColumnName("COL8981022401"); } 
			}

			/// <summary>
			/// Gets column JobTypeId with alias  
			/// </summary>
			public string ColJobTypeId { 
				get { return GetColumnName("COL8981022407"); } 
			}

			/// <summary>
			/// Gets column Mail with alias  
			/// </summary>
			public string ColMail { 
				get { return GetColumnName("COL8981022406"); } 
			}

			/// <summary>
			/// Gets column Address with alias  
			/// </summary>
			public string ColAddress { 
				get { return GetColumnName("COL8981022405"); } 
			}

			/// <summary>
			/// Gets column Phone with alias  
			/// </summary>
			public string ColPhone { 
				get { return GetColumnName("COL8981022404"); } 
			}

			/// <summary>
			/// Gets column DelFlag with alias  
			/// </summary>
			public string ColDelFlag { 
				get { return GetColumnName("COL89810224022"); } 
			}

			/// <summary>
			/// Gets column JobEnd with alias  
			/// </summary>
			public string ColJobEnd { 
				get { return GetColumnName("COL8981022409"); } 
			}

			/// <summary>
			/// Gets column JobBegin with alias  
			/// </summary>
			public string ColJobBegin { 
				get { return GetColumnName("COL8981022408"); } 
			}

			/// <summary>
			/// Gets column WorkingPlaceId with alias  
			/// </summary>
			public string ColWorkingPlaceId { 
				get { return GetColumnName("COL89810224025"); } 
			}

			/// <summary>
			/// Gets column Modified with alias  
			/// </summary>
			public string ColModified { 
				get { return GetColumnName("COL89810224020"); } 
			}

			/// <summary>
			/// Gets column Created with alias  
			/// </summary>
			public string ColCreated { 
				get { return GetColumnName("COL89810224018"); } 
			}

			/// <summary>
			/// Gets column id with alias  
			/// </summary>
			public string Colid { 
				get { return GetColumnName("COL89810224023"); } 
			}

			/// <summary>
			/// Gets column Comment with alias  
			/// </summary>
			public string ColComment { 
				get { return GetColumnName("COL89810224017"); } 
			}

			/// <summary>
			/// Gets column Position with alias  
			/// </summary>
			public string ColPosition { 
				get { return GetColumnName("COL89810224016"); } 
			}


			/// <summary>
			/// Checks whether column ModifiedBy is added in select statement 
			/// </summary>
			public bool IsSelectModifiedBy { 
				get { return IsSelect("COL89810224021"); } 
				set { SetSelect("COL89810224021", value); } 
			}

			/// <summary>
			/// Checks whether column CreatedBy is added in select statement 
			/// </summary>
			public bool IsSelectCreatedBy { 
				get { return IsSelect("COL89810224019"); } 
				set { SetSelect("COL89810224019", value); } 
			}

			/// <summary>
			/// Checks whether column JobContent is added in select statement 
			/// </summary>
			public bool IsSelectJobContent { 
				get { return IsSelect("COL89810224024"); } 
				set { SetSelect("COL89810224024", value); } 
			}

			/// <summary>
			/// Checks whether column Name is added in select statement 
			/// </summary>
			public bool IsSelectName { 
				get { return IsSelect("COL8981022403"); } 
				set { SetSelect("COL8981022403", value); } 
			}

			/// <summary>
			/// Checks whether column BuildingId is added in select statement 
			/// </summary>
			public bool IsSelectBuildingId { 
				get { return IsSelect("COL8981022402"); } 
				set { SetSelect("COL8981022402", value); } 
			}

			/// <summary>
			/// Checks whether column StaffId is added in select statement 
			/// </summary>
			public bool IsSelectStaffId { 
				get { return IsSelect("COL8981022401"); } 
				set { SetSelect("COL8981022401", value); } 
			}

			/// <summary>
			/// Checks whether column JobTypeId is added in select statement 
			/// </summary>
			public bool IsSelectJobTypeId { 
				get { return IsSelect("COL8981022407"); } 
				set { SetSelect("COL8981022407", value); } 
			}

			/// <summary>
			/// Checks whether column Mail is added in select statement 
			/// </summary>
			public bool IsSelectMail { 
				get { return IsSelect("COL8981022406"); } 
				set { SetSelect("COL8981022406", value); } 
			}

			/// <summary>
			/// Checks whether column Address is added in select statement 
			/// </summary>
			public bool IsSelectAddress { 
				get { return IsSelect("COL8981022405"); } 
				set { SetSelect("COL8981022405", value); } 
			}

			/// <summary>
			/// Checks whether column Phone is added in select statement 
			/// </summary>
			public bool IsSelectPhone { 
				get { return IsSelect("COL8981022404"); } 
				set { SetSelect("COL8981022404", value); } 
			}

			/// <summary>
			/// Checks whether column DelFlag is added in select statement 
			/// </summary>
			public bool IsSelectDelFlag { 
				get { return IsSelect("COL89810224022"); } 
				set { SetSelect("COL89810224022", value); } 
			}

			/// <summary>
			/// Checks whether column JobEnd is added in select statement 
			/// </summary>
			public bool IsSelectJobEnd { 
				get { return IsSelect("COL8981022409"); } 
				set { SetSelect("COL8981022409", value); } 
			}

			/// <summary>
			/// Checks whether column JobBegin is added in select statement 
			/// </summary>
			public bool IsSelectJobBegin { 
				get { return IsSelect("COL8981022408"); } 
				set { SetSelect("COL8981022408", value); } 
			}

			/// <summary>
			/// Checks whether column WorkingPlaceId is added in select statement 
			/// </summary>
			public bool IsSelectWorkingPlaceId { 
				get { return IsSelect("COL89810224025"); } 
				set { SetSelect("COL89810224025", value); } 
			}

			/// <summary>
			/// Checks whether column Modified is added in select statement 
			/// </summary>
			public bool IsSelectModified { 
				get { return IsSelect("COL89810224020"); } 
				set { SetSelect("COL89810224020", value); } 
			}

			/// <summary>
			/// Checks whether column Created is added in select statement 
			/// </summary>
			public bool IsSelectCreated { 
				get { return IsSelect("COL89810224018"); } 
				set { SetSelect("COL89810224018", value); } 
			}

			/// <summary>
			/// Checks whether column id is added in select statement 
			/// </summary>
			public bool IsSelectid { 
				get { return IsSelect("COL89810224023"); } 
				set { SetSelect("COL89810224023", value); } 
			}

			/// <summary>
			/// Checks whether column Comment is added in select statement 
			/// </summary>
			public bool IsSelectComment { 
				get { return IsSelect("COL89810224017"); } 
				set { SetSelect("COL89810224017", value); } 
			}

			/// <summary>
			/// Checks whether column Position is added in select statement 
			/// </summary>
			public bool IsSelectPosition { 
				get { return IsSelect("COL89810224016"); } 
				set { SetSelect("COL89810224016", value); } 
			}



	}
}