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
	public class UsersMessagesMappedData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ1544392571";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of UsersMessagesMapped 
			/// </summary>
			public UsersMessagesMappedData(string objectID): base(objectID) {}  

			public UsersMessagesMappedData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field DelFlag 
			/// </summary>
			public string DelFlag { 
				get { return GetValue("COL15443925717"); } 
				set { SetValue("COL15443925717", value); } 
			}

			/// <summary>
			/// Gets field Updated 
			/// </summary>
			public string Updated { 
				get { return GetValue("COL154439257110"); } 
				set { SetValue("COL154439257110", value); } 
			}

			/// <summary>
			/// Gets field Updator 
			/// </summary>
			public string Updator { 
				get { return GetValue("COL154439257111"); } 
				set { SetValue("COL154439257111", value); } 
			}

			/// <summary>
			/// Gets field MessageID 
			/// </summary>
			public string MessageID { 
				get { return GetValue("COL15443925712"); } 
				set { SetValue("COL15443925712", value); } 
			}

			/// <summary>
			/// Gets field IsReply 
			/// </summary>
			public string IsReply { 
				get { return GetValue("COL15443925715"); } 
				set { SetValue("COL15443925715", value); } 
			}

			/// <summary>
			/// Gets field Created 
			/// </summary>
			public string Created { 
				get { return GetValue("COL15443925718"); } 
				set { SetValue("COL15443925718", value); } 
			}

			/// <summary>
			/// Gets field FlagId 
			/// </summary>
			public string FlagId { 
				get { return GetValue("COL154439257112"); } 
				set { SetValue("COL154439257112", value); } 
			}

			/// <summary>
			/// Gets field PlaceHolderID 
			/// </summary>
			public string PlaceHolderID { 
				get { return GetValue("COL15443925713"); } 
				set { SetValue("COL15443925713", value); } 
			}

			/// <summary>
			/// Gets field UserName 
			/// </summary>
			public string UserName { 
				get { return GetValue("COL15443925716"); } 
				set { SetValue("COL15443925716", value); } 
			}

			/// <summary>
			/// Gets field Creator 
			/// </summary>
			public string Creator { 
				get { return GetValue("COL15443925719"); } 
				set { SetValue("COL15443925719", value); } 
			}

			/// <summary>
			/// Gets field MessageMapId 
			/// </summary>
			public string MessageMapId { 
				get { return GetValue("COL15443925711"); } 
				set { SetValue("COL15443925711", value); } 
			}

			/// <summary>
			/// Gets field IsRead 
			/// </summary>
			public string IsRead { 
				get { return GetValue("COL15443925714"); } 
				set { SetValue("COL15443925714", value); } 
			}


			/// <summary>
			/// Gets DelFlag attribute data 
			/// </summary>
			public AttributeData GetDelFlagAttributeData() { 
				return GetAttributeData("COL15443925717"); 
			}

			/// <summary>
			/// Gets Updated attribute data 
			/// </summary>
			public AttributeData GetUpdatedAttributeData() { 
				return GetAttributeData("COL154439257110"); 
			}

			/// <summary>
			/// Gets Updator attribute data 
			/// </summary>
			public AttributeData GetUpdatorAttributeData() { 
				return GetAttributeData("COL154439257111"); 
			}

			/// <summary>
			/// Gets MessageID attribute data 
			/// </summary>
			public AttributeData GetMessageIDAttributeData() { 
				return GetAttributeData("COL15443925712"); 
			}

			/// <summary>
			/// Gets IsReply attribute data 
			/// </summary>
			public AttributeData GetIsReplyAttributeData() { 
				return GetAttributeData("COL15443925715"); 
			}

			/// <summary>
			/// Gets Created attribute data 
			/// </summary>
			public AttributeData GetCreatedAttributeData() { 
				return GetAttributeData("COL15443925718"); 
			}

			/// <summary>
			/// Gets FlagId attribute data 
			/// </summary>
			public AttributeData GetFlagIdAttributeData() { 
				return GetAttributeData("COL154439257112"); 
			}

			/// <summary>
			/// Gets PlaceHolderID attribute data 
			/// </summary>
			public AttributeData GetPlaceHolderIDAttributeData() { 
				return GetAttributeData("COL15443925713"); 
			}

			/// <summary>
			/// Gets UserName attribute data 
			/// </summary>
			public AttributeData GetUserNameAttributeData() { 
				return GetAttributeData("COL15443925716"); 
			}

			/// <summary>
			/// Gets Creator attribute data 
			/// </summary>
			public AttributeData GetCreatorAttributeData() { 
				return GetAttributeData("COL15443925719"); 
			}

			/// <summary>
			/// Gets MessageMapId attribute data 
			/// </summary>
			public AttributeData GetMessageMapIdAttributeData() { 
				return GetAttributeData("COL15443925711"); 
			}

			/// <summary>
			/// Gets IsRead attribute data 
			/// </summary>
			public AttributeData GetIsReadAttributeData() { 
				return GetAttributeData("COL15443925714"); 
			}


			/// <summary>
			/// Gets column DelFlag with alias  
			/// </summary>
			public string ColDelFlag { 
				get { return GetColumnName("COL15443925717"); } 
			}

			/// <summary>
			/// Gets column Updated with alias  
			/// </summary>
			public string ColUpdated { 
				get { return GetColumnName("COL154439257110"); } 
			}

			/// <summary>
			/// Gets column Updator with alias  
			/// </summary>
			public string ColUpdator { 
				get { return GetColumnName("COL154439257111"); } 
			}

			/// <summary>
			/// Gets column MessageID with alias  
			/// </summary>
			public string ColMessageID { 
				get { return GetColumnName("COL15443925712"); } 
			}

			/// <summary>
			/// Gets column IsReply with alias  
			/// </summary>
			public string ColIsReply { 
				get { return GetColumnName("COL15443925715"); } 
			}

			/// <summary>
			/// Gets column Created with alias  
			/// </summary>
			public string ColCreated { 
				get { return GetColumnName("COL15443925718"); } 
			}

			/// <summary>
			/// Gets column FlagId with alias  
			/// </summary>
			public string ColFlagId { 
				get { return GetColumnName("COL154439257112"); } 
			}

			/// <summary>
			/// Gets column PlaceHolderID with alias  
			/// </summary>
			public string ColPlaceHolderID { 
				get { return GetColumnName("COL15443925713"); } 
			}

			/// <summary>
			/// Gets column UserName with alias  
			/// </summary>
			public string ColUserName { 
				get { return GetColumnName("COL15443925716"); } 
			}

			/// <summary>
			/// Gets column Creator with alias  
			/// </summary>
			public string ColCreator { 
				get { return GetColumnName("COL15443925719"); } 
			}

			/// <summary>
			/// Gets column MessageMapId with alias  
			/// </summary>
			public string ColMessageMapId { 
				get { return GetColumnName("COL15443925711"); } 
			}

			/// <summary>
			/// Gets column IsRead with alias  
			/// </summary>
			public string ColIsRead { 
				get { return GetColumnName("COL15443925714"); } 
			}


			/// <summary>
			/// Checks whether column DelFlag is added in select statement 
			/// </summary>
			public bool IsSelectDelFlag { 
				get { return IsSelect("COL15443925717"); } 
				set { SetSelect("COL15443925717", value); } 
			}

			/// <summary>
			/// Checks whether column Updated is added in select statement 
			/// </summary>
			public bool IsSelectUpdated { 
				get { return IsSelect("COL154439257110"); } 
				set { SetSelect("COL154439257110", value); } 
			}

			/// <summary>
			/// Checks whether column Updator is added in select statement 
			/// </summary>
			public bool IsSelectUpdator { 
				get { return IsSelect("COL154439257111"); } 
				set { SetSelect("COL154439257111", value); } 
			}

			/// <summary>
			/// Checks whether column MessageID is added in select statement 
			/// </summary>
			public bool IsSelectMessageID { 
				get { return IsSelect("COL15443925712"); } 
				set { SetSelect("COL15443925712", value); } 
			}

			/// <summary>
			/// Checks whether column IsReply is added in select statement 
			/// </summary>
			public bool IsSelectIsReply { 
				get { return IsSelect("COL15443925715"); } 
				set { SetSelect("COL15443925715", value); } 
			}

			/// <summary>
			/// Checks whether column Created is added in select statement 
			/// </summary>
			public bool IsSelectCreated { 
				get { return IsSelect("COL15443925718"); } 
				set { SetSelect("COL15443925718", value); } 
			}

			/// <summary>
			/// Checks whether column FlagId is added in select statement 
			/// </summary>
			public bool IsSelectFlagId { 
				get { return IsSelect("COL154439257112"); } 
				set { SetSelect("COL154439257112", value); } 
			}

			/// <summary>
			/// Checks whether column PlaceHolderID is added in select statement 
			/// </summary>
			public bool IsSelectPlaceHolderID { 
				get { return IsSelect("COL15443925713"); } 
				set { SetSelect("COL15443925713", value); } 
			}

			/// <summary>
			/// Checks whether column UserName is added in select statement 
			/// </summary>
			public bool IsSelectUserName { 
				get { return IsSelect("COL15443925716"); } 
				set { SetSelect("COL15443925716", value); } 
			}

			/// <summary>
			/// Checks whether column Creator is added in select statement 
			/// </summary>
			public bool IsSelectCreator { 
				get { return IsSelect("COL15443925719"); } 
				set { SetSelect("COL15443925719", value); } 
			}

			/// <summary>
			/// Checks whether column MessageMapId is added in select statement 
			/// </summary>
			public bool IsSelectMessageMapId { 
				get { return IsSelect("COL15443925711"); } 
				set { SetSelect("COL15443925711", value); } 
			}

			/// <summary>
			/// Checks whether column IsRead is added in select statement 
			/// </summary>
			public bool IsSelectIsRead { 
				get { return IsSelect("COL15443925714"); } 
				set { SetSelect("COL15443925714", value); } 
			}



	}
}