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
	public class aspnet_MembershipData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ501576825";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of aspnet_Membership 
			/// </summary>
			public aspnet_MembershipData(string objectID): base(objectID) {}  

			public aspnet_MembershipData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field FailedPasswordAttemptWindowStart 
			/// </summary>
			public string FailedPasswordAttemptWindowStart { 
				get { return GetValue("COL50157682518"); } 
				set { SetValue("COL50157682518", value); } 
			}

			/// <summary>
			/// Gets field LastPasswordChangedDate 
			/// </summary>
			public string LastPasswordChangedDate { 
				get { return GetValue("COL50157682515"); } 
				set { SetValue("COL50157682515", value); } 
			}

			/// <summary>
			/// Gets field Comment 
			/// </summary>
			public string Comment { 
				get { return GetValue("COL50157682521"); } 
				set { SetValue("COL50157682521", value); } 
			}

			/// <summary>
			/// Gets field FullName 
			/// </summary>
			public string FullName { 
				get { return GetValue("COL50157682522"); } 
				set { SetValue("COL50157682522", value); } 
			}

			/// <summary>
			/// Gets field IsLockedOut 
			/// </summary>
			public string IsLockedOut { 
				get { return GetValue("COL50157682512"); } 
				set { SetValue("COL50157682512", value); } 
			}

			/// <summary>
			/// Gets field FailedPasswordAttemptCount 
			/// </summary>
			public string FailedPasswordAttemptCount { 
				get { return GetValue("COL50157682517"); } 
				set { SetValue("COL50157682517", value); } 
			}

			/// <summary>
			/// Gets field LoweredEmail 
			/// </summary>
			public string LoweredEmail { 
				get { return GetValue("COL5015768258"); } 
				set { SetValue("COL5015768258", value); } 
			}

			/// <summary>
			/// Gets field PasswordQuestion 
			/// </summary>
			public string PasswordQuestion { 
				get { return GetValue("COL5015768259"); } 
				set { SetValue("COL5015768259", value); } 
			}

			/// <summary>
			/// Gets field LastLoginDate 
			/// </summary>
			public string LastLoginDate { 
				get { return GetValue("COL50157682514"); } 
				set { SetValue("COL50157682514", value); } 
			}

			/// <summary>
			/// Gets field TenementUsed 
			/// </summary>
			public string TenementUsed { 
				get { return GetValue("COL50157682524"); } 
				set { SetValue("COL50157682524", value); } 
			}

			/// <summary>
			/// Gets field IsApproved 
			/// </summary>
			public string IsApproved { 
				get { return GetValue("COL50157682511"); } 
				set { SetValue("COL50157682511", value); } 
			}

			/// <summary>
			/// Gets field UserId 
			/// </summary>
			public string UserId { 
				get { return GetValue("COL5015768252"); } 
				set { SetValue("COL5015768252", value); } 
			}

			/// <summary>
			/// Gets field Password 
			/// </summary>
			public string Password { 
				get { return GetValue("COL5015768253"); } 
				set { SetValue("COL5015768253", value); } 
			}

			/// <summary>
			/// Gets field FailedPasswordAnswerAttemptCount 
			/// </summary>
			public string FailedPasswordAnswerAttemptCount { 
				get { return GetValue("COL50157682519"); } 
				set { SetValue("COL50157682519", value); } 
			}

			/// <summary>
			/// Gets field ApplicationId 
			/// </summary>
			public string ApplicationId { 
				get { return GetValue("COL5015768251"); } 
				set { SetValue("COL5015768251", value); } 
			}

			/// <summary>
			/// Gets field MobilePIN 
			/// </summary>
			public string MobilePIN { 
				get { return GetValue("COL5015768256"); } 
				set { SetValue("COL5015768256", value); } 
			}

			/// <summary>
			/// Gets field Email 
			/// </summary>
			public string Email { 
				get { return GetValue("COL5015768257"); } 
				set { SetValue("COL5015768257", value); } 
			}

			/// <summary>
			/// Gets field PasswordFormat 
			/// </summary>
			public string PasswordFormat { 
				get { return GetValue("COL5015768254"); } 
				set { SetValue("COL5015768254", value); } 
			}

			/// <summary>
			/// Gets field PasswordSalt 
			/// </summary>
			public string PasswordSalt { 
				get { return GetValue("COL5015768255"); } 
				set { SetValue("COL5015768255", value); } 
			}

			/// <summary>
			/// Gets field CreateDate 
			/// </summary>
			public string CreateDate { 
				get { return GetValue("COL50157682513"); } 
				set { SetValue("COL50157682513", value); } 
			}

			/// <summary>
			/// Gets field BuildingId 
			/// </summary>
			public string BuildingId { 
				get { return GetValue("COL50157682523"); } 
				set { SetValue("COL50157682523", value); } 
			}

			/// <summary>
			/// Gets field LastLockoutDate 
			/// </summary>
			public string LastLockoutDate { 
				get { return GetValue("COL50157682516"); } 
				set { SetValue("COL50157682516", value); } 
			}

			/// <summary>
			/// Gets field PasswordAnswer 
			/// </summary>
			public string PasswordAnswer { 
				get { return GetValue("COL50157682510"); } 
				set { SetValue("COL50157682510", value); } 
			}

			/// <summary>
			/// Gets field FailedPasswordAnswerAttemptWindowStart 
			/// </summary>
			public string FailedPasswordAnswerAttemptWindowStart { 
				get { return GetValue("COL50157682520"); } 
				set { SetValue("COL50157682520", value); } 
			}


			/// <summary>
			/// Gets FailedPasswordAttemptWindowStart attribute data 
			/// </summary>
			public AttributeData GetFailedPasswordAttemptWindowStartAttributeData() { 
				return GetAttributeData("COL50157682518"); 
			}

			/// <summary>
			/// Gets LastPasswordChangedDate attribute data 
			/// </summary>
			public AttributeData GetLastPasswordChangedDateAttributeData() { 
				return GetAttributeData("COL50157682515"); 
			}

			/// <summary>
			/// Gets Comment attribute data 
			/// </summary>
			public AttributeData GetCommentAttributeData() { 
				return GetAttributeData("COL50157682521"); 
			}

			/// <summary>
			/// Gets FullName attribute data 
			/// </summary>
			public AttributeData GetFullNameAttributeData() { 
				return GetAttributeData("COL50157682522"); 
			}

			/// <summary>
			/// Gets IsLockedOut attribute data 
			/// </summary>
			public AttributeData GetIsLockedOutAttributeData() { 
				return GetAttributeData("COL50157682512"); 
			}

			/// <summary>
			/// Gets FailedPasswordAttemptCount attribute data 
			/// </summary>
			public AttributeData GetFailedPasswordAttemptCountAttributeData() { 
				return GetAttributeData("COL50157682517"); 
			}

			/// <summary>
			/// Gets LoweredEmail attribute data 
			/// </summary>
			public AttributeData GetLoweredEmailAttributeData() { 
				return GetAttributeData("COL5015768258"); 
			}

			/// <summary>
			/// Gets PasswordQuestion attribute data 
			/// </summary>
			public AttributeData GetPasswordQuestionAttributeData() { 
				return GetAttributeData("COL5015768259"); 
			}

			/// <summary>
			/// Gets LastLoginDate attribute data 
			/// </summary>
			public AttributeData GetLastLoginDateAttributeData() { 
				return GetAttributeData("COL50157682514"); 
			}

			/// <summary>
			/// Gets TenementUsed attribute data 
			/// </summary>
			public AttributeData GetTenementUsedAttributeData() { 
				return GetAttributeData("COL50157682524"); 
			}

			/// <summary>
			/// Gets IsApproved attribute data 
			/// </summary>
			public AttributeData GetIsApprovedAttributeData() { 
				return GetAttributeData("COL50157682511"); 
			}

			/// <summary>
			/// Gets UserId attribute data 
			/// </summary>
			public AttributeData GetUserIdAttributeData() { 
				return GetAttributeData("COL5015768252"); 
			}

			/// <summary>
			/// Gets Password attribute data 
			/// </summary>
			public AttributeData GetPasswordAttributeData() { 
				return GetAttributeData("COL5015768253"); 
			}

			/// <summary>
			/// Gets FailedPasswordAnswerAttemptCount attribute data 
			/// </summary>
			public AttributeData GetFailedPasswordAnswerAttemptCountAttributeData() { 
				return GetAttributeData("COL50157682519"); 
			}

			/// <summary>
			/// Gets ApplicationId attribute data 
			/// </summary>
			public AttributeData GetApplicationIdAttributeData() { 
				return GetAttributeData("COL5015768251"); 
			}

			/// <summary>
			/// Gets MobilePIN attribute data 
			/// </summary>
			public AttributeData GetMobilePINAttributeData() { 
				return GetAttributeData("COL5015768256"); 
			}

			/// <summary>
			/// Gets Email attribute data 
			/// </summary>
			public AttributeData GetEmailAttributeData() { 
				return GetAttributeData("COL5015768257"); 
			}

			/// <summary>
			/// Gets PasswordFormat attribute data 
			/// </summary>
			public AttributeData GetPasswordFormatAttributeData() { 
				return GetAttributeData("COL5015768254"); 
			}

			/// <summary>
			/// Gets PasswordSalt attribute data 
			/// </summary>
			public AttributeData GetPasswordSaltAttributeData() { 
				return GetAttributeData("COL5015768255"); 
			}

			/// <summary>
			/// Gets CreateDate attribute data 
			/// </summary>
			public AttributeData GetCreateDateAttributeData() { 
				return GetAttributeData("COL50157682513"); 
			}

			/// <summary>
			/// Gets BuildingId attribute data 
			/// </summary>
			public AttributeData GetBuildingIdAttributeData() { 
				return GetAttributeData("COL50157682523"); 
			}

			/// <summary>
			/// Gets LastLockoutDate attribute data 
			/// </summary>
			public AttributeData GetLastLockoutDateAttributeData() { 
				return GetAttributeData("COL50157682516"); 
			}

			/// <summary>
			/// Gets PasswordAnswer attribute data 
			/// </summary>
			public AttributeData GetPasswordAnswerAttributeData() { 
				return GetAttributeData("COL50157682510"); 
			}

			/// <summary>
			/// Gets FailedPasswordAnswerAttemptWindowStart attribute data 
			/// </summary>
			public AttributeData GetFailedPasswordAnswerAttemptWindowStartAttributeData() { 
				return GetAttributeData("COL50157682520"); 
			}


			/// <summary>
			/// Gets column FailedPasswordAttemptWindowStart with alias  
			/// </summary>
			public string ColFailedPasswordAttemptWindowStart { 
				get { return GetColumnName("COL50157682518"); } 
			}

			/// <summary>
			/// Gets column LastPasswordChangedDate with alias  
			/// </summary>
			public string ColLastPasswordChangedDate { 
				get { return GetColumnName("COL50157682515"); } 
			}

			/// <summary>
			/// Gets column Comment with alias  
			/// </summary>
			public string ColComment { 
				get { return GetColumnName("COL50157682521"); } 
			}

			/// <summary>
			/// Gets column FullName with alias  
			/// </summary>
			public string ColFullName { 
				get { return GetColumnName("COL50157682522"); } 
			}

			/// <summary>
			/// Gets column IsLockedOut with alias  
			/// </summary>
			public string ColIsLockedOut { 
				get { return GetColumnName("COL50157682512"); } 
			}

			/// <summary>
			/// Gets column FailedPasswordAttemptCount with alias  
			/// </summary>
			public string ColFailedPasswordAttemptCount { 
				get { return GetColumnName("COL50157682517"); } 
			}

			/// <summary>
			/// Gets column LoweredEmail with alias  
			/// </summary>
			public string ColLoweredEmail { 
				get { return GetColumnName("COL5015768258"); } 
			}

			/// <summary>
			/// Gets column PasswordQuestion with alias  
			/// </summary>
			public string ColPasswordQuestion { 
				get { return GetColumnName("COL5015768259"); } 
			}

			/// <summary>
			/// Gets column LastLoginDate with alias  
			/// </summary>
			public string ColLastLoginDate { 
				get { return GetColumnName("COL50157682514"); } 
			}

			/// <summary>
			/// Gets column TenementUsed with alias  
			/// </summary>
			public string ColTenementUsed { 
				get { return GetColumnName("COL50157682524"); } 
			}

			/// <summary>
			/// Gets column IsApproved with alias  
			/// </summary>
			public string ColIsApproved { 
				get { return GetColumnName("COL50157682511"); } 
			}

			/// <summary>
			/// Gets column UserId with alias  
			/// </summary>
			public string ColUserId { 
				get { return GetColumnName("COL5015768252"); } 
			}

			/// <summary>
			/// Gets column Password with alias  
			/// </summary>
			public string ColPassword { 
				get { return GetColumnName("COL5015768253"); } 
			}

			/// <summary>
			/// Gets column FailedPasswordAnswerAttemptCount with alias  
			/// </summary>
			public string ColFailedPasswordAnswerAttemptCount { 
				get { return GetColumnName("COL50157682519"); } 
			}

			/// <summary>
			/// Gets column ApplicationId with alias  
			/// </summary>
			public string ColApplicationId { 
				get { return GetColumnName("COL5015768251"); } 
			}

			/// <summary>
			/// Gets column MobilePIN with alias  
			/// </summary>
			public string ColMobilePIN { 
				get { return GetColumnName("COL5015768256"); } 
			}

			/// <summary>
			/// Gets column Email with alias  
			/// </summary>
			public string ColEmail { 
				get { return GetColumnName("COL5015768257"); } 
			}

			/// <summary>
			/// Gets column PasswordFormat with alias  
			/// </summary>
			public string ColPasswordFormat { 
				get { return GetColumnName("COL5015768254"); } 
			}

			/// <summary>
			/// Gets column PasswordSalt with alias  
			/// </summary>
			public string ColPasswordSalt { 
				get { return GetColumnName("COL5015768255"); } 
			}

			/// <summary>
			/// Gets column CreateDate with alias  
			/// </summary>
			public string ColCreateDate { 
				get { return GetColumnName("COL50157682513"); } 
			}

			/// <summary>
			/// Gets column BuildingId with alias  
			/// </summary>
			public string ColBuildingId { 
				get { return GetColumnName("COL50157682523"); } 
			}

			/// <summary>
			/// Gets column LastLockoutDate with alias  
			/// </summary>
			public string ColLastLockoutDate { 
				get { return GetColumnName("COL50157682516"); } 
			}

			/// <summary>
			/// Gets column PasswordAnswer with alias  
			/// </summary>
			public string ColPasswordAnswer { 
				get { return GetColumnName("COL50157682510"); } 
			}

			/// <summary>
			/// Gets column FailedPasswordAnswerAttemptWindowStart with alias  
			/// </summary>
			public string ColFailedPasswordAnswerAttemptWindowStart { 
				get { return GetColumnName("COL50157682520"); } 
			}


			/// <summary>
			/// Checks whether column FailedPasswordAttemptWindowStart is added in select statement 
			/// </summary>
			public bool IsSelectFailedPasswordAttemptWindowStart { 
				get { return IsSelect("COL50157682518"); } 
				set { SetSelect("COL50157682518", value); } 
			}

			/// <summary>
			/// Checks whether column LastPasswordChangedDate is added in select statement 
			/// </summary>
			public bool IsSelectLastPasswordChangedDate { 
				get { return IsSelect("COL50157682515"); } 
				set { SetSelect("COL50157682515", value); } 
			}

			/// <summary>
			/// Checks whether column Comment is added in select statement 
			/// </summary>
			public bool IsSelectComment { 
				get { return IsSelect("COL50157682521"); } 
				set { SetSelect("COL50157682521", value); } 
			}

			/// <summary>
			/// Checks whether column FullName is added in select statement 
			/// </summary>
			public bool IsSelectFullName { 
				get { return IsSelect("COL50157682522"); } 
				set { SetSelect("COL50157682522", value); } 
			}

			/// <summary>
			/// Checks whether column IsLockedOut is added in select statement 
			/// </summary>
			public bool IsSelectIsLockedOut { 
				get { return IsSelect("COL50157682512"); } 
				set { SetSelect("COL50157682512", value); } 
			}

			/// <summary>
			/// Checks whether column FailedPasswordAttemptCount is added in select statement 
			/// </summary>
			public bool IsSelectFailedPasswordAttemptCount { 
				get { return IsSelect("COL50157682517"); } 
				set { SetSelect("COL50157682517", value); } 
			}

			/// <summary>
			/// Checks whether column LoweredEmail is added in select statement 
			/// </summary>
			public bool IsSelectLoweredEmail { 
				get { return IsSelect("COL5015768258"); } 
				set { SetSelect("COL5015768258", value); } 
			}

			/// <summary>
			/// Checks whether column PasswordQuestion is added in select statement 
			/// </summary>
			public bool IsSelectPasswordQuestion { 
				get { return IsSelect("COL5015768259"); } 
				set { SetSelect("COL5015768259", value); } 
			}

			/// <summary>
			/// Checks whether column LastLoginDate is added in select statement 
			/// </summary>
			public bool IsSelectLastLoginDate { 
				get { return IsSelect("COL50157682514"); } 
				set { SetSelect("COL50157682514", value); } 
			}

			/// <summary>
			/// Checks whether column TenementUsed is added in select statement 
			/// </summary>
			public bool IsSelectTenementUsed { 
				get { return IsSelect("COL50157682524"); } 
				set { SetSelect("COL50157682524", value); } 
			}

			/// <summary>
			/// Checks whether column IsApproved is added in select statement 
			/// </summary>
			public bool IsSelectIsApproved { 
				get { return IsSelect("COL50157682511"); } 
				set { SetSelect("COL50157682511", value); } 
			}

			/// <summary>
			/// Checks whether column UserId is added in select statement 
			/// </summary>
			public bool IsSelectUserId { 
				get { return IsSelect("COL5015768252"); } 
				set { SetSelect("COL5015768252", value); } 
			}

			/// <summary>
			/// Checks whether column Password is added in select statement 
			/// </summary>
			public bool IsSelectPassword { 
				get { return IsSelect("COL5015768253"); } 
				set { SetSelect("COL5015768253", value); } 
			}

			/// <summary>
			/// Checks whether column FailedPasswordAnswerAttemptCount is added in select statement 
			/// </summary>
			public bool IsSelectFailedPasswordAnswerAttemptCount { 
				get { return IsSelect("COL50157682519"); } 
				set { SetSelect("COL50157682519", value); } 
			}

			/// <summary>
			/// Checks whether column ApplicationId is added in select statement 
			/// </summary>
			public bool IsSelectApplicationId { 
				get { return IsSelect("COL5015768251"); } 
				set { SetSelect("COL5015768251", value); } 
			}

			/// <summary>
			/// Checks whether column MobilePIN is added in select statement 
			/// </summary>
			public bool IsSelectMobilePIN { 
				get { return IsSelect("COL5015768256"); } 
				set { SetSelect("COL5015768256", value); } 
			}

			/// <summary>
			/// Checks whether column Email is added in select statement 
			/// </summary>
			public bool IsSelectEmail { 
				get { return IsSelect("COL5015768257"); } 
				set { SetSelect("COL5015768257", value); } 
			}

			/// <summary>
			/// Checks whether column PasswordFormat is added in select statement 
			/// </summary>
			public bool IsSelectPasswordFormat { 
				get { return IsSelect("COL5015768254"); } 
				set { SetSelect("COL5015768254", value); } 
			}

			/// <summary>
			/// Checks whether column PasswordSalt is added in select statement 
			/// </summary>
			public bool IsSelectPasswordSalt { 
				get { return IsSelect("COL5015768255"); } 
				set { SetSelect("COL5015768255", value); } 
			}

			/// <summary>
			/// Checks whether column CreateDate is added in select statement 
			/// </summary>
			public bool IsSelectCreateDate { 
				get { return IsSelect("COL50157682513"); } 
				set { SetSelect("COL50157682513", value); } 
			}

			/// <summary>
			/// Checks whether column BuildingId is added in select statement 
			/// </summary>
			public bool IsSelectBuildingId { 
				get { return IsSelect("COL50157682523"); } 
				set { SetSelect("COL50157682523", value); } 
			}

			/// <summary>
			/// Checks whether column LastLockoutDate is added in select statement 
			/// </summary>
			public bool IsSelectLastLockoutDate { 
				get { return IsSelect("COL50157682516"); } 
				set { SetSelect("COL50157682516", value); } 
			}

			/// <summary>
			/// Checks whether column PasswordAnswer is added in select statement 
			/// </summary>
			public bool IsSelectPasswordAnswer { 
				get { return IsSelect("COL50157682510"); } 
				set { SetSelect("COL50157682510", value); } 
			}

			/// <summary>
			/// Checks whether column FailedPasswordAnswerAttemptWindowStart is added in select statement 
			/// </summary>
			public bool IsSelectFailedPasswordAnswerAttemptWindowStart { 
				get { return IsSelect("COL50157682520"); } 
				set { SetSelect("COL50157682520", value); } 
			}



	}
}