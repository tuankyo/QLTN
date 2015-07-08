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
	public class MessagesData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ1448392229";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of Messages 
			/// </summary>
			public MessagesData(string objectID): base(objectID) {}  

			public MessagesData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field Creator 
			/// </summary>
			public string Creator { 
				get { return GetValue("COL14483922297"); } 
				set { SetValue("COL14483922297", value); } 
			}

			/// <summary>
			/// Gets field BccUser 
			/// </summary>
			public string BccUser { 
				get { return GetValue("COL144839222910"); } 
				set { SetValue("COL144839222910", value); } 
			}

			/// <summary>
			/// Gets field FlagId 
			/// </summary>
			public string FlagId { 
				get { return GetValue("COL144839222912"); } 
				set { SetValue("COL144839222912", value); } 
			}

			/// <summary>
			/// Gets field CcUser 
			/// </summary>
			public string CcUser { 
				get { return GetValue("COL144839222911"); } 
				set { SetValue("COL144839222911", value); } 
			}

			/// <summary>
			/// Gets field DelFlag 
			/// </summary>
			public string DelFlag { 
				get { return GetValue("COL14483922295"); } 
				set { SetValue("COL14483922295", value); } 
			}

			/// <summary>
			/// Gets field Updated 
			/// </summary>
			public string Updated { 
				get { return GetValue("COL14483922298"); } 
				set { SetValue("COL14483922298", value); } 
			}

			/// <summary>
			/// Gets field Updator 
			/// </summary>
			public string Updator { 
				get { return GetValue("COL14483922299"); } 
				set { SetValue("COL14483922299", value); } 
			}

			/// <summary>
			/// Gets field Body 
			/// </summary>
			public string Body { 
				get { return GetValue("COL14483922293"); } 
				set { SetValue("COL14483922293", value); } 
			}

			/// <summary>
			/// Gets field Created 
			/// </summary>
			public string Created { 
				get { return GetValue("COL14483922296"); } 
				set { SetValue("COL14483922296", value); } 
			}

			/// <summary>
			/// Gets field Subject 
			/// </summary>
			public string Subject { 
				get { return GetValue("COL14483922292"); } 
				set { SetValue("COL14483922292", value); } 
			}

			/// <summary>
			/// Gets field MessageID 
			/// </summary>
			public string MessageID { 
				get { return GetValue("COL14483922291"); } 
				set { SetValue("COL14483922291", value); } 
			}

			/// <summary>
			/// Gets field UserName 
			/// </summary>
			public string UserName { 
				get { return GetValue("COL14483922294"); } 
				set { SetValue("COL14483922294", value); } 
			}

			/// <summary>
			/// Gets field BuildingId 
			/// </summary>
			public string BuildingId { 
				get { return GetValue("COL144839222913"); } 
				set { SetValue("COL144839222913", value); } 
			}


			/// <summary>
			/// Gets Creator attribute data 
			/// </summary>
			public AttributeData GetCreatorAttributeData() { 
				return GetAttributeData("COL14483922297"); 
			}

			/// <summary>
			/// Gets BccUser attribute data 
			/// </summary>
			public AttributeData GetBccUserAttributeData() { 
				return GetAttributeData("COL144839222910"); 
			}

			/// <summary>
			/// Gets FlagId attribute data 
			/// </summary>
			public AttributeData GetFlagIdAttributeData() { 
				return GetAttributeData("COL144839222912"); 
			}

			/// <summary>
			/// Gets CcUser attribute data 
			/// </summary>
			public AttributeData GetCcUserAttributeData() { 
				return GetAttributeData("COL144839222911"); 
			}

			/// <summary>
			/// Gets DelFlag attribute data 
			/// </summary>
			public AttributeData GetDelFlagAttributeData() { 
				return GetAttributeData("COL14483922295"); 
			}

			/// <summary>
			/// Gets Updated attribute data 
			/// </summary>
			public AttributeData GetUpdatedAttributeData() { 
				return GetAttributeData("COL14483922298"); 
			}

			/// <summary>
			/// Gets Updator attribute data 
			/// </summary>
			public AttributeData GetUpdatorAttributeData() { 
				return GetAttributeData("COL14483922299"); 
			}

			/// <summary>
			/// Gets Body attribute data 
			/// </summary>
			public AttributeData GetBodyAttributeData() { 
				return GetAttributeData("COL14483922293"); 
			}

			/// <summary>
			/// Gets Created attribute data 
			/// </summary>
			public AttributeData GetCreatedAttributeData() { 
				return GetAttributeData("COL14483922296"); 
			}

			/// <summary>
			/// Gets Subject attribute data 
			/// </summary>
			public AttributeData GetSubjectAttributeData() { 
				return GetAttributeData("COL14483922292"); 
			}

			/// <summary>
			/// Gets MessageID attribute data 
			/// </summary>
			public AttributeData GetMessageIDAttributeData() { 
				return GetAttributeData("COL14483922291"); 
			}

			/// <summary>
			/// Gets UserName attribute data 
			/// </summary>
			public AttributeData GetUserNameAttributeData() { 
				return GetAttributeData("COL14483922294"); 
			}

			/// <summary>
			/// Gets BuildingId attribute data 
			/// </summary>
			public AttributeData GetBuildingIdAttributeData() { 
				return GetAttributeData("COL144839222913"); 
			}


			/// <summary>
			/// Gets column Creator with alias  
			/// </summary>
			public string ColCreator { 
				get { return GetColumnName("COL14483922297"); } 
			}

			/// <summary>
			/// Gets column BccUser with alias  
			/// </summary>
			public string ColBccUser { 
				get { return GetColumnName("COL144839222910"); } 
			}

			/// <summary>
			/// Gets column FlagId with alias  
			/// </summary>
			public string ColFlagId { 
				get { return GetColumnName("COL144839222912"); } 
			}

			/// <summary>
			/// Gets column CcUser with alias  
			/// </summary>
			public string ColCcUser { 
				get { return GetColumnName("COL144839222911"); } 
			}

			/// <summary>
			/// Gets column DelFlag with alias  
			/// </summary>
			public string ColDelFlag { 
				get { return GetColumnName("COL14483922295"); } 
			}

			/// <summary>
			/// Gets column Updated with alias  
			/// </summary>
			public string ColUpdated { 
				get { return GetColumnName("COL14483922298"); } 
			}

			/// <summary>
			/// Gets column Updator with alias  
			/// </summary>
			public string ColUpdator { 
				get { return GetColumnName("COL14483922299"); } 
			}

			/// <summary>
			/// Gets column Body with alias  
			/// </summary>
			public string ColBody { 
				get { return GetColumnName("COL14483922293"); } 
			}

			/// <summary>
			/// Gets column Created with alias  
			/// </summary>
			public string ColCreated { 
				get { return GetColumnName("COL14483922296"); } 
			}

			/// <summary>
			/// Gets column Subject with alias  
			/// </summary>
			public string ColSubject { 
				get { return GetColumnName("COL14483922292"); } 
			}

			/// <summary>
			/// Gets column MessageID with alias  
			/// </summary>
			public string ColMessageID { 
				get { return GetColumnName("COL14483922291"); } 
			}

			/// <summary>
			/// Gets column UserName with alias  
			/// </summary>
			public string ColUserName { 
				get { return GetColumnName("COL14483922294"); } 
			}

			/// <summary>
			/// Gets column BuildingId with alias  
			/// </summary>
			public string ColBuildingId { 
				get { return GetColumnName("COL144839222913"); } 
			}


			/// <summary>
			/// Checks whether column Creator is added in select statement 
			/// </summary>
			public bool IsSelectCreator { 
				get { return IsSelect("COL14483922297"); } 
				set { SetSelect("COL14483922297", value); } 
			}

			/// <summary>
			/// Checks whether column BccUser is added in select statement 
			/// </summary>
			public bool IsSelectBccUser { 
				get { return IsSelect("COL144839222910"); } 
				set { SetSelect("COL144839222910", value); } 
			}

			/// <summary>
			/// Checks whether column FlagId is added in select statement 
			/// </summary>
			public bool IsSelectFlagId { 
				get { return IsSelect("COL144839222912"); } 
				set { SetSelect("COL144839222912", value); } 
			}

			/// <summary>
			/// Checks whether column CcUser is added in select statement 
			/// </summary>
			public bool IsSelectCcUser { 
				get { return IsSelect("COL144839222911"); } 
				set { SetSelect("COL144839222911", value); } 
			}

			/// <summary>
			/// Checks whether column DelFlag is added in select statement 
			/// </summary>
			public bool IsSelectDelFlag { 
				get { return IsSelect("COL14483922295"); } 
				set { SetSelect("COL14483922295", value); } 
			}

			/// <summary>
			/// Checks whether column Updated is added in select statement 
			/// </summary>
			public bool IsSelectUpdated { 
				get { return IsSelect("COL14483922298"); } 
				set { SetSelect("COL14483922298", value); } 
			}

			/// <summary>
			/// Checks whether column Updator is added in select statement 
			/// </summary>
			public bool IsSelectUpdator { 
				get { return IsSelect("COL14483922299"); } 
				set { SetSelect("COL14483922299", value); } 
			}

			/// <summary>
			/// Checks whether column Body is added in select statement 
			/// </summary>
			public bool IsSelectBody { 
				get { return IsSelect("COL14483922293"); } 
				set { SetSelect("COL14483922293", value); } 
			}

			/// <summary>
			/// Checks whether column Created is added in select statement 
			/// </summary>
			public bool IsSelectCreated { 
				get { return IsSelect("COL14483922296"); } 
				set { SetSelect("COL14483922296", value); } 
			}

			/// <summary>
			/// Checks whether column Subject is added in select statement 
			/// </summary>
			public bool IsSelectSubject { 
				get { return IsSelect("COL14483922292"); } 
				set { SetSelect("COL14483922292", value); } 
			}

			/// <summary>
			/// Checks whether column MessageID is added in select statement 
			/// </summary>
			public bool IsSelectMessageID { 
				get { return IsSelect("COL14483922291"); } 
				set { SetSelect("COL14483922291", value); } 
			}

			/// <summary>
			/// Checks whether column UserName is added in select statement 
			/// </summary>
			public bool IsSelectUserName { 
				get { return IsSelect("COL14483922294"); } 
				set { SetSelect("COL14483922294", value); } 
			}

			/// <summary>
			/// Checks whether column BuildingId is added in select statement 
			/// </summary>
			public bool IsSelectBuildingId { 
				get { return IsSelect("COL144839222913"); } 
				set { SetSelect("COL144839222913", value); } 
			}



	}
}