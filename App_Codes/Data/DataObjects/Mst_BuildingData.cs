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
	public class Mst_BuildingData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ1752393312";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of Mst_Building 
			/// </summary>
			public Mst_BuildingData(string objectID): base(objectID) {}  

			public Mst_BuildingData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field BillingPeriod 
			/// </summary>
			public string BillingPeriod { 
				get { return GetValue("COL175239331224"); } 
				set { SetValue("COL175239331224", value); } 
			}

			/// <summary>
			/// Gets field DepositVND 
			/// </summary>
			public string DepositVND { 
				get { return GetValue("COL175239331222"); } 
				set { SetValue("COL175239331222", value); } 
			}

			/// <summary>
			/// Gets field Created 
			/// </summary>
			public string Created { 
				get { return GetValue("COL175239331211"); } 
				set { SetValue("COL175239331211", value); } 
			}

			/// <summary>
			/// Gets field Modified 
			/// </summary>
			public string Modified { 
				get { return GetValue("COL175239331213"); } 
				set { SetValue("COL175239331213", value); } 
			}

			/// <summary>
			/// Gets field ManagerCompanyAgent 
			/// </summary>
			public string ManagerCompanyAgent { 
				get { return GetValue("COL17523933128"); } 
				set { SetValue("COL17523933128", value); } 
			}

			/// <summary>
			/// Gets field Investor 
			/// </summary>
			public string Investor { 
				get { return GetValue("COL17523933123"); } 
				set { SetValue("COL17523933123", value); } 
			}

			/// <summary>
			/// Gets field ModifiedBy 
			/// </summary>
			public string ModifiedBy { 
				get { return GetValue("COL175239331214"); } 
				set { SetValue("COL175239331214", value); } 
			}

			/// <summary>
			/// Gets field Owner 
			/// </summary>
			public string Owner { 
				get { return GetValue("COL17523933126"); } 
				set { SetValue("COL17523933126", value); } 
			}

			/// <summary>
			/// Gets field Bank 
			/// </summary>
			public string Bank { 
				get { return GetValue("COL175239331216"); } 
				set { SetValue("COL175239331216", value); } 
			}

			/// <summary>
			/// Gets field ManagerCompanyPhone 
			/// </summary>
			public string ManagerCompanyPhone { 
				get { return GetValue("COL17523933129"); } 
				set { SetValue("COL17523933129", value); } 
			}

			/// <summary>
			/// Gets field Office 
			/// </summary>
			public string Office { 
				get { return GetValue("COL175239331219"); } 
				set { SetValue("COL175239331219", value); } 
			}

			/// <summary>
			/// Gets field OfficePhone 
			/// </summary>
			public string OfficePhone { 
				get { return GetValue("COL175239331221"); } 
				set { SetValue("COL175239331221", value); } 
			}

			/// <summary>
			/// Gets field BuildingId 
			/// </summary>
			public string BuildingId { 
				get { return GetValue("COL17523933121"); } 
				set { SetValue("COL17523933121", value); } 
			}

			/// <summary>
			/// Gets field DepositUSD 
			/// </summary>
			public string DepositUSD { 
				get { return GetValue("COL175239331223"); } 
				set { SetValue("COL175239331223", value); } 
			}

			/// <summary>
			/// Gets field Address 
			/// </summary>
			public string Address { 
				get { return GetValue("COL17523933124"); } 
				set { SetValue("COL17523933124", value); } 
			}

			/// <summary>
			/// Gets field Comment 
			/// </summary>
			public string Comment { 
				get { return GetValue("COL175239331210"); } 
				set { SetValue("COL175239331210", value); } 
			}

			/// <summary>
			/// Gets field Name 
			/// </summary>
			public string Name { 
				get { return GetValue("COL17523933122"); } 
				set { SetValue("COL17523933122", value); } 
			}

			/// <summary>
			/// Gets field CreatedBy 
			/// </summary>
			public string CreatedBy { 
				get { return GetValue("COL175239331212"); } 
				set { SetValue("COL175239331212", value); } 
			}

			/// <summary>
			/// Gets field ManagerCompany 
			/// </summary>
			public string ManagerCompany { 
				get { return GetValue("COL17523933127"); } 
				set { SetValue("COL17523933127", value); } 
			}

			/// <summary>
			/// Gets field ServiceProvide 
			/// </summary>
			public string ServiceProvide { 
				get { return GetValue("COL175239331226"); } 
				set { SetValue("COL175239331226", value); } 
			}

			/// <summary>
			/// Gets field DelFlag 
			/// </summary>
			public string DelFlag { 
				get { return GetValue("COL175239331215"); } 
				set { SetValue("COL175239331215", value); } 
			}

			/// <summary>
			/// Gets field Account 
			/// </summary>
			public string Account { 
				get { return GetValue("COL175239331217"); } 
				set { SetValue("COL175239331217", value); } 
			}

			/// <summary>
			/// Gets field InterestPenalize 
			/// </summary>
			public string InterestPenalize { 
				get { return GetValue("COL175239331225"); } 
				set { SetValue("COL175239331225", value); } 
			}

			/// <summary>
			/// Gets field Phone 
			/// </summary>
			public string Phone { 
				get { return GetValue("COL17523933125"); } 
				set { SetValue("COL17523933125", value); } 
			}

			/// <summary>
			/// Gets field AccountName 
			/// </summary>
			public string AccountName { 
				get { return GetValue("COL175239331218"); } 
				set { SetValue("COL175239331218", value); } 
			}

			/// <summary>
			/// Gets field OfficeAddress 
			/// </summary>
			public string OfficeAddress { 
				get { return GetValue("COL175239331220"); } 
				set { SetValue("COL175239331220", value); } 
			}


			/// <summary>
			/// Gets BillingPeriod attribute data 
			/// </summary>
			public AttributeData GetBillingPeriodAttributeData() { 
				return GetAttributeData("COL175239331224"); 
			}

			/// <summary>
			/// Gets DepositVND attribute data 
			/// </summary>
			public AttributeData GetDepositVNDAttributeData() { 
				return GetAttributeData("COL175239331222"); 
			}

			/// <summary>
			/// Gets Created attribute data 
			/// </summary>
			public AttributeData GetCreatedAttributeData() { 
				return GetAttributeData("COL175239331211"); 
			}

			/// <summary>
			/// Gets Modified attribute data 
			/// </summary>
			public AttributeData GetModifiedAttributeData() { 
				return GetAttributeData("COL175239331213"); 
			}

			/// <summary>
			/// Gets ManagerCompanyAgent attribute data 
			/// </summary>
			public AttributeData GetManagerCompanyAgentAttributeData() { 
				return GetAttributeData("COL17523933128"); 
			}

			/// <summary>
			/// Gets Investor attribute data 
			/// </summary>
			public AttributeData GetInvestorAttributeData() { 
				return GetAttributeData("COL17523933123"); 
			}

			/// <summary>
			/// Gets ModifiedBy attribute data 
			/// </summary>
			public AttributeData GetModifiedByAttributeData() { 
				return GetAttributeData("COL175239331214"); 
			}

			/// <summary>
			/// Gets Owner attribute data 
			/// </summary>
			public AttributeData GetOwnerAttributeData() { 
				return GetAttributeData("COL17523933126"); 
			}

			/// <summary>
			/// Gets Bank attribute data 
			/// </summary>
			public AttributeData GetBankAttributeData() { 
				return GetAttributeData("COL175239331216"); 
			}

			/// <summary>
			/// Gets ManagerCompanyPhone attribute data 
			/// </summary>
			public AttributeData GetManagerCompanyPhoneAttributeData() { 
				return GetAttributeData("COL17523933129"); 
			}

			/// <summary>
			/// Gets Office attribute data 
			/// </summary>
			public AttributeData GetOfficeAttributeData() { 
				return GetAttributeData("COL175239331219"); 
			}

			/// <summary>
			/// Gets OfficePhone attribute data 
			/// </summary>
			public AttributeData GetOfficePhoneAttributeData() { 
				return GetAttributeData("COL175239331221"); 
			}

			/// <summary>
			/// Gets BuildingId attribute data 
			/// </summary>
			public AttributeData GetBuildingIdAttributeData() { 
				return GetAttributeData("COL17523933121"); 
			}

			/// <summary>
			/// Gets DepositUSD attribute data 
			/// </summary>
			public AttributeData GetDepositUSDAttributeData() { 
				return GetAttributeData("COL175239331223"); 
			}

			/// <summary>
			/// Gets Address attribute data 
			/// </summary>
			public AttributeData GetAddressAttributeData() { 
				return GetAttributeData("COL17523933124"); 
			}

			/// <summary>
			/// Gets Comment attribute data 
			/// </summary>
			public AttributeData GetCommentAttributeData() { 
				return GetAttributeData("COL175239331210"); 
			}

			/// <summary>
			/// Gets Name attribute data 
			/// </summary>
			public AttributeData GetNameAttributeData() { 
				return GetAttributeData("COL17523933122"); 
			}

			/// <summary>
			/// Gets CreatedBy attribute data 
			/// </summary>
			public AttributeData GetCreatedByAttributeData() { 
				return GetAttributeData("COL175239331212"); 
			}

			/// <summary>
			/// Gets ManagerCompany attribute data 
			/// </summary>
			public AttributeData GetManagerCompanyAttributeData() { 
				return GetAttributeData("COL17523933127"); 
			}

			/// <summary>
			/// Gets ServiceProvide attribute data 
			/// </summary>
			public AttributeData GetServiceProvideAttributeData() { 
				return GetAttributeData("COL175239331226"); 
			}

			/// <summary>
			/// Gets DelFlag attribute data 
			/// </summary>
			public AttributeData GetDelFlagAttributeData() { 
				return GetAttributeData("COL175239331215"); 
			}

			/// <summary>
			/// Gets Account attribute data 
			/// </summary>
			public AttributeData GetAccountAttributeData() { 
				return GetAttributeData("COL175239331217"); 
			}

			/// <summary>
			/// Gets InterestPenalize attribute data 
			/// </summary>
			public AttributeData GetInterestPenalizeAttributeData() { 
				return GetAttributeData("COL175239331225"); 
			}

			/// <summary>
			/// Gets Phone attribute data 
			/// </summary>
			public AttributeData GetPhoneAttributeData() { 
				return GetAttributeData("COL17523933125"); 
			}

			/// <summary>
			/// Gets AccountName attribute data 
			/// </summary>
			public AttributeData GetAccountNameAttributeData() { 
				return GetAttributeData("COL175239331218"); 
			}

			/// <summary>
			/// Gets OfficeAddress attribute data 
			/// </summary>
			public AttributeData GetOfficeAddressAttributeData() { 
				return GetAttributeData("COL175239331220"); 
			}


			/// <summary>
			/// Gets column BillingPeriod with alias  
			/// </summary>
			public string ColBillingPeriod { 
				get { return GetColumnName("COL175239331224"); } 
			}

			/// <summary>
			/// Gets column DepositVND with alias  
			/// </summary>
			public string ColDepositVND { 
				get { return GetColumnName("COL175239331222"); } 
			}

			/// <summary>
			/// Gets column Created with alias  
			/// </summary>
			public string ColCreated { 
				get { return GetColumnName("COL175239331211"); } 
			}

			/// <summary>
			/// Gets column Modified with alias  
			/// </summary>
			public string ColModified { 
				get { return GetColumnName("COL175239331213"); } 
			}

			/// <summary>
			/// Gets column ManagerCompanyAgent with alias  
			/// </summary>
			public string ColManagerCompanyAgent { 
				get { return GetColumnName("COL17523933128"); } 
			}

			/// <summary>
			/// Gets column Investor with alias  
			/// </summary>
			public string ColInvestor { 
				get { return GetColumnName("COL17523933123"); } 
			}

			/// <summary>
			/// Gets column ModifiedBy with alias  
			/// </summary>
			public string ColModifiedBy { 
				get { return GetColumnName("COL175239331214"); } 
			}

			/// <summary>
			/// Gets column Owner with alias  
			/// </summary>
			public string ColOwner { 
				get { return GetColumnName("COL17523933126"); } 
			}

			/// <summary>
			/// Gets column Bank with alias  
			/// </summary>
			public string ColBank { 
				get { return GetColumnName("COL175239331216"); } 
			}

			/// <summary>
			/// Gets column ManagerCompanyPhone with alias  
			/// </summary>
			public string ColManagerCompanyPhone { 
				get { return GetColumnName("COL17523933129"); } 
			}

			/// <summary>
			/// Gets column Office with alias  
			/// </summary>
			public string ColOffice { 
				get { return GetColumnName("COL175239331219"); } 
			}

			/// <summary>
			/// Gets column OfficePhone with alias  
			/// </summary>
			public string ColOfficePhone { 
				get { return GetColumnName("COL175239331221"); } 
			}

			/// <summary>
			/// Gets column BuildingId with alias  
			/// </summary>
			public string ColBuildingId { 
				get { return GetColumnName("COL17523933121"); } 
			}

			/// <summary>
			/// Gets column DepositUSD with alias  
			/// </summary>
			public string ColDepositUSD { 
				get { return GetColumnName("COL175239331223"); } 
			}

			/// <summary>
			/// Gets column Address with alias  
			/// </summary>
			public string ColAddress { 
				get { return GetColumnName("COL17523933124"); } 
			}

			/// <summary>
			/// Gets column Comment with alias  
			/// </summary>
			public string ColComment { 
				get { return GetColumnName("COL175239331210"); } 
			}

			/// <summary>
			/// Gets column Name with alias  
			/// </summary>
			public string ColName { 
				get { return GetColumnName("COL17523933122"); } 
			}

			/// <summary>
			/// Gets column CreatedBy with alias  
			/// </summary>
			public string ColCreatedBy { 
				get { return GetColumnName("COL175239331212"); } 
			}

			/// <summary>
			/// Gets column ManagerCompany with alias  
			/// </summary>
			public string ColManagerCompany { 
				get { return GetColumnName("COL17523933127"); } 
			}

			/// <summary>
			/// Gets column ServiceProvide with alias  
			/// </summary>
			public string ColServiceProvide { 
				get { return GetColumnName("COL175239331226"); } 
			}

			/// <summary>
			/// Gets column DelFlag with alias  
			/// </summary>
			public string ColDelFlag { 
				get { return GetColumnName("COL175239331215"); } 
			}

			/// <summary>
			/// Gets column Account with alias  
			/// </summary>
			public string ColAccount { 
				get { return GetColumnName("COL175239331217"); } 
			}

			/// <summary>
			/// Gets column InterestPenalize with alias  
			/// </summary>
			public string ColInterestPenalize { 
				get { return GetColumnName("COL175239331225"); } 
			}

			/// <summary>
			/// Gets column Phone with alias  
			/// </summary>
			public string ColPhone { 
				get { return GetColumnName("COL17523933125"); } 
			}

			/// <summary>
			/// Gets column AccountName with alias  
			/// </summary>
			public string ColAccountName { 
				get { return GetColumnName("COL175239331218"); } 
			}

			/// <summary>
			/// Gets column OfficeAddress with alias  
			/// </summary>
			public string ColOfficeAddress { 
				get { return GetColumnName("COL175239331220"); } 
			}


			/// <summary>
			/// Checks whether column BillingPeriod is added in select statement 
			/// </summary>
			public bool IsSelectBillingPeriod { 
				get { return IsSelect("COL175239331224"); } 
				set { SetSelect("COL175239331224", value); } 
			}

			/// <summary>
			/// Checks whether column DepositVND is added in select statement 
			/// </summary>
			public bool IsSelectDepositVND { 
				get { return IsSelect("COL175239331222"); } 
				set { SetSelect("COL175239331222", value); } 
			}

			/// <summary>
			/// Checks whether column Created is added in select statement 
			/// </summary>
			public bool IsSelectCreated { 
				get { return IsSelect("COL175239331211"); } 
				set { SetSelect("COL175239331211", value); } 
			}

			/// <summary>
			/// Checks whether column Modified is added in select statement 
			/// </summary>
			public bool IsSelectModified { 
				get { return IsSelect("COL175239331213"); } 
				set { SetSelect("COL175239331213", value); } 
			}

			/// <summary>
			/// Checks whether column ManagerCompanyAgent is added in select statement 
			/// </summary>
			public bool IsSelectManagerCompanyAgent { 
				get { return IsSelect("COL17523933128"); } 
				set { SetSelect("COL17523933128", value); } 
			}

			/// <summary>
			/// Checks whether column Investor is added in select statement 
			/// </summary>
			public bool IsSelectInvestor { 
				get { return IsSelect("COL17523933123"); } 
				set { SetSelect("COL17523933123", value); } 
			}

			/// <summary>
			/// Checks whether column ModifiedBy is added in select statement 
			/// </summary>
			public bool IsSelectModifiedBy { 
				get { return IsSelect("COL175239331214"); } 
				set { SetSelect("COL175239331214", value); } 
			}

			/// <summary>
			/// Checks whether column Owner is added in select statement 
			/// </summary>
			public bool IsSelectOwner { 
				get { return IsSelect("COL17523933126"); } 
				set { SetSelect("COL17523933126", value); } 
			}

			/// <summary>
			/// Checks whether column Bank is added in select statement 
			/// </summary>
			public bool IsSelectBank { 
				get { return IsSelect("COL175239331216"); } 
				set { SetSelect("COL175239331216", value); } 
			}

			/// <summary>
			/// Checks whether column ManagerCompanyPhone is added in select statement 
			/// </summary>
			public bool IsSelectManagerCompanyPhone { 
				get { return IsSelect("COL17523933129"); } 
				set { SetSelect("COL17523933129", value); } 
			}

			/// <summary>
			/// Checks whether column Office is added in select statement 
			/// </summary>
			public bool IsSelectOffice { 
				get { return IsSelect("COL175239331219"); } 
				set { SetSelect("COL175239331219", value); } 
			}

			/// <summary>
			/// Checks whether column OfficePhone is added in select statement 
			/// </summary>
			public bool IsSelectOfficePhone { 
				get { return IsSelect("COL175239331221"); } 
				set { SetSelect("COL175239331221", value); } 
			}

			/// <summary>
			/// Checks whether column BuildingId is added in select statement 
			/// </summary>
			public bool IsSelectBuildingId { 
				get { return IsSelect("COL17523933121"); } 
				set { SetSelect("COL17523933121", value); } 
			}

			/// <summary>
			/// Checks whether column DepositUSD is added in select statement 
			/// </summary>
			public bool IsSelectDepositUSD { 
				get { return IsSelect("COL175239331223"); } 
				set { SetSelect("COL175239331223", value); } 
			}

			/// <summary>
			/// Checks whether column Address is added in select statement 
			/// </summary>
			public bool IsSelectAddress { 
				get { return IsSelect("COL17523933124"); } 
				set { SetSelect("COL17523933124", value); } 
			}

			/// <summary>
			/// Checks whether column Comment is added in select statement 
			/// </summary>
			public bool IsSelectComment { 
				get { return IsSelect("COL175239331210"); } 
				set { SetSelect("COL175239331210", value); } 
			}

			/// <summary>
			/// Checks whether column Name is added in select statement 
			/// </summary>
			public bool IsSelectName { 
				get { return IsSelect("COL17523933122"); } 
				set { SetSelect("COL17523933122", value); } 
			}

			/// <summary>
			/// Checks whether column CreatedBy is added in select statement 
			/// </summary>
			public bool IsSelectCreatedBy { 
				get { return IsSelect("COL175239331212"); } 
				set { SetSelect("COL175239331212", value); } 
			}

			/// <summary>
			/// Checks whether column ManagerCompany is added in select statement 
			/// </summary>
			public bool IsSelectManagerCompany { 
				get { return IsSelect("COL17523933127"); } 
				set { SetSelect("COL17523933127", value); } 
			}

			/// <summary>
			/// Checks whether column ServiceProvide is added in select statement 
			/// </summary>
			public bool IsSelectServiceProvide { 
				get { return IsSelect("COL175239331226"); } 
				set { SetSelect("COL175239331226", value); } 
			}

			/// <summary>
			/// Checks whether column DelFlag is added in select statement 
			/// </summary>
			public bool IsSelectDelFlag { 
				get { return IsSelect("COL175239331215"); } 
				set { SetSelect("COL175239331215", value); } 
			}

			/// <summary>
			/// Checks whether column Account is added in select statement 
			/// </summary>
			public bool IsSelectAccount { 
				get { return IsSelect("COL175239331217"); } 
				set { SetSelect("COL175239331217", value); } 
			}

			/// <summary>
			/// Checks whether column InterestPenalize is added in select statement 
			/// </summary>
			public bool IsSelectInterestPenalize { 
				get { return IsSelect("COL175239331225"); } 
				set { SetSelect("COL175239331225", value); } 
			}

			/// <summary>
			/// Checks whether column Phone is added in select statement 
			/// </summary>
			public bool IsSelectPhone { 
				get { return IsSelect("COL17523933125"); } 
				set { SetSelect("COL17523933125", value); } 
			}

			/// <summary>
			/// Checks whether column AccountName is added in select statement 
			/// </summary>
			public bool IsSelectAccountName { 
				get { return IsSelect("COL175239331218"); } 
				set { SetSelect("COL175239331218", value); } 
			}

			/// <summary>
			/// Checks whether column OfficeAddress is added in select statement 
			/// </summary>
			public bool IsSelectOfficeAddress { 
				get { return IsSelect("COL175239331220"); } 
				set { SetSelect("COL175239331220", value); } 
			}



	}
}