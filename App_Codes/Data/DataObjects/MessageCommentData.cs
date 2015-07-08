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
	public class MessageCommentData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ1672393027";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of MessageComment 
			/// </summary>
			public MessageCommentData(string objectID): base(objectID) {}  

			public MessageCommentData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field Created 
			/// </summary>
			public string Created { 
				get { return GetValue("COL16723930276"); } 
				set { SetValue("COL16723930276", value); } 
			}

			/// <summary>
			/// Gets field DelFlag 
			/// </summary>
			public string DelFlag { 
				get { return GetValue("COL16723930275"); } 
				set { SetValue("COL16723930275", value); } 
			}

			/// <summary>
			/// Gets field Updated 
			/// </summary>
			public string Updated { 
				get { return GetValue("COL16723930278"); } 
				set { SetValue("COL16723930278", value); } 
			}

			/// <summary>
			/// Gets field Creator 
			/// </summary>
			public string Creator { 
				get { return GetValue("COL16723930277"); } 
				set { SetValue("COL16723930277", value); } 
			}

			/// <summary>
			/// Gets field MessageID 
			/// </summary>
			public string MessageID { 
				get { return GetValue("COL16723930272"); } 
				set { SetValue("COL16723930272", value); } 
			}

			/// <summary>
			/// Gets field MessageCommentId 
			/// </summary>
			public string MessageCommentId { 
				get { return GetValue("COL16723930271"); } 
				set { SetValue("COL16723930271", value); } 
			}

			/// <summary>
			/// Gets field Updator 
			/// </summary>
			public string Updator { 
				get { return GetValue("COL16723930279"); } 
				set { SetValue("COL16723930279", value); } 
			}

			/// <summary>
			/// Gets field UserName 
			/// </summary>
			public string UserName { 
				get { return GetValue("COL16723930274"); } 
				set { SetValue("COL16723930274", value); } 
			}

			/// <summary>
			/// Gets field Body 
			/// </summary>
			public string Body { 
				get { return GetValue("COL16723930273"); } 
				set { SetValue("COL16723930273", value); } 
			}


			/// <summary>
			/// Gets Created attribute data 
			/// </summary>
			public AttributeData GetCreatedAttributeData() { 
				return GetAttributeData("COL16723930276"); 
			}

			/// <summary>
			/// Gets DelFlag attribute data 
			/// </summary>
			public AttributeData GetDelFlagAttributeData() { 
				return GetAttributeData("COL16723930275"); 
			}

			/// <summary>
			/// Gets Updated attribute data 
			/// </summary>
			public AttributeData GetUpdatedAttributeData() { 
				return GetAttributeData("COL16723930278"); 
			}

			/// <summary>
			/// Gets Creator attribute data 
			/// </summary>
			public AttributeData GetCreatorAttributeData() { 
				return GetAttributeData("COL16723930277"); 
			}

			/// <summary>
			/// Gets MessageID attribute data 
			/// </summary>
			public AttributeData GetMessageIDAttributeData() { 
				return GetAttributeData("COL16723930272"); 
			}

			/// <summary>
			/// Gets MessageCommentId attribute data 
			/// </summary>
			public AttributeData GetMessageCommentIdAttributeData() { 
				return GetAttributeData("COL16723930271"); 
			}

			/// <summary>
			/// Gets Updator attribute data 
			/// </summary>
			public AttributeData GetUpdatorAttributeData() { 
				return GetAttributeData("COL16723930279"); 
			}

			/// <summary>
			/// Gets UserName attribute data 
			/// </summary>
			public AttributeData GetUserNameAttributeData() { 
				return GetAttributeData("COL16723930274"); 
			}

			/// <summary>
			/// Gets Body attribute data 
			/// </summary>
			public AttributeData GetBodyAttributeData() { 
				return GetAttributeData("COL16723930273"); 
			}


			/// <summary>
			/// Gets column Created with alias  
			/// </summary>
			public string ColCreated { 
				get { return GetColumnName("COL16723930276"); } 
			}

			/// <summary>
			/// Gets column DelFlag with alias  
			/// </summary>
			public string ColDelFlag { 
				get { return GetColumnName("COL16723930275"); } 
			}

			/// <summary>
			/// Gets column Updated with alias  
			/// </summary>
			public string ColUpdated { 
				get { return GetColumnName("COL16723930278"); } 
			}

			/// <summary>
			/// Gets column Creator with alias  
			/// </summary>
			public string ColCreator { 
				get { return GetColumnName("COL16723930277"); } 
			}

			/// <summary>
			/// Gets column MessageID with alias  
			/// </summary>
			public string ColMessageID { 
				get { return GetColumnName("COL16723930272"); } 
			}

			/// <summary>
			/// Gets column MessageCommentId with alias  
			/// </summary>
			public string ColMessageCommentId { 
				get { return GetColumnName("COL16723930271"); } 
			}

			/// <summary>
			/// Gets column Updator with alias  
			/// </summary>
			public string ColUpdator { 
				get { return GetColumnName("COL16723930279"); } 
			}

			/// <summary>
			/// Gets column UserName with alias  
			/// </summary>
			public string ColUserName { 
				get { return GetColumnName("COL16723930274"); } 
			}

			/// <summary>
			/// Gets column Body with alias  
			/// </summary>
			public string ColBody { 
				get { return GetColumnName("COL16723930273"); } 
			}


			/// <summary>
			/// Checks whether column Created is added in select statement 
			/// </summary>
			public bool IsSelectCreated { 
				get { return IsSelect("COL16723930276"); } 
				set { SetSelect("COL16723930276", value); } 
			}

			/// <summary>
			/// Checks whether column DelFlag is added in select statement 
			/// </summary>
			public bool IsSelectDelFlag { 
				get { return IsSelect("COL16723930275"); } 
				set { SetSelect("COL16723930275", value); } 
			}

			/// <summary>
			/// Checks whether column Updated is added in select statement 
			/// </summary>
			public bool IsSelectUpdated { 
				get { return IsSelect("COL16723930278"); } 
				set { SetSelect("COL16723930278", value); } 
			}

			/// <summary>
			/// Checks whether column Creator is added in select statement 
			/// </summary>
			public bool IsSelectCreator { 
				get { return IsSelect("COL16723930277"); } 
				set { SetSelect("COL16723930277", value); } 
			}

			/// <summary>
			/// Checks whether column MessageID is added in select statement 
			/// </summary>
			public bool IsSelectMessageID { 
				get { return IsSelect("COL16723930272"); } 
				set { SetSelect("COL16723930272", value); } 
			}

			/// <summary>
			/// Checks whether column MessageCommentId is added in select statement 
			/// </summary>
			public bool IsSelectMessageCommentId { 
				get { return IsSelect("COL16723930271"); } 
				set { SetSelect("COL16723930271", value); } 
			}

			/// <summary>
			/// Checks whether column Updator is added in select statement 
			/// </summary>
			public bool IsSelectUpdator { 
				get { return IsSelect("COL16723930279"); } 
				set { SetSelect("COL16723930279", value); } 
			}

			/// <summary>
			/// Checks whether column UserName is added in select statement 
			/// </summary>
			public bool IsSelectUserName { 
				get { return IsSelect("COL16723930274"); } 
				set { SetSelect("COL16723930274", value); } 
			}

			/// <summary>
			/// Checks whether column Body is added in select statement 
			/// </summary>
			public bool IsSelectBody { 
				get { return IsSelect("COL16723930273"); } 
				set { SetSelect("COL16723930273", value); } 
			}



	}
}