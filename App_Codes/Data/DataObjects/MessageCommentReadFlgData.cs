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
	public class MessageCommentReadFlgData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ1720393198";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of MessageCommentReadFlg 
			/// </summary>
			public MessageCommentReadFlgData(string objectID): base(objectID) {}  

			public MessageCommentReadFlgData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field UserName 
			/// </summary>
			public string UserName { 
				get { return GetValue("COL17203931983"); } 
				set { SetValue("COL17203931983", value); } 
			}

			/// <summary>
			/// Gets field Updated 
			/// </summary>
			public string Updated { 
				get { return GetValue("COL17203931988"); } 
				set { SetValue("COL17203931988", value); } 
			}

			/// <summary>
			/// Gets field DelFlag 
			/// </summary>
			public string DelFlag { 
				get { return GetValue("COL17203931985"); } 
				set { SetValue("COL17203931985", value); } 
			}

			/// <summary>
			/// Gets field MessageCommentId 
			/// </summary>
			public string MessageCommentId { 
				get { return GetValue("COL17203931982"); } 
				set { SetValue("COL17203931982", value); } 
			}

			/// <summary>
			/// Gets field Creator 
			/// </summary>
			public string Creator { 
				get { return GetValue("COL17203931987"); } 
				set { SetValue("COL17203931987", value); } 
			}

			/// <summary>
			/// Gets field ReadFlag 
			/// </summary>
			public string ReadFlag { 
				get { return GetValue("COL17203931984"); } 
				set { SetValue("COL17203931984", value); } 
			}

			/// <summary>
			/// Gets field Updator 
			/// </summary>
			public string Updator { 
				get { return GetValue("COL17203931989"); } 
				set { SetValue("COL17203931989", value); } 
			}

			/// <summary>
			/// Gets field id 
			/// </summary>
			public string id { 
				get { return GetValue("COL17203931981"); } 
				set { SetValue("COL17203931981", value); } 
			}

			/// <summary>
			/// Gets field Created 
			/// </summary>
			public string Created { 
				get { return GetValue("COL17203931986"); } 
				set { SetValue("COL17203931986", value); } 
			}


			/// <summary>
			/// Gets UserName attribute data 
			/// </summary>
			public AttributeData GetUserNameAttributeData() { 
				return GetAttributeData("COL17203931983"); 
			}

			/// <summary>
			/// Gets Updated attribute data 
			/// </summary>
			public AttributeData GetUpdatedAttributeData() { 
				return GetAttributeData("COL17203931988"); 
			}

			/// <summary>
			/// Gets DelFlag attribute data 
			/// </summary>
			public AttributeData GetDelFlagAttributeData() { 
				return GetAttributeData("COL17203931985"); 
			}

			/// <summary>
			/// Gets MessageCommentId attribute data 
			/// </summary>
			public AttributeData GetMessageCommentIdAttributeData() { 
				return GetAttributeData("COL17203931982"); 
			}

			/// <summary>
			/// Gets Creator attribute data 
			/// </summary>
			public AttributeData GetCreatorAttributeData() { 
				return GetAttributeData("COL17203931987"); 
			}

			/// <summary>
			/// Gets ReadFlag attribute data 
			/// </summary>
			public AttributeData GetReadFlagAttributeData() { 
				return GetAttributeData("COL17203931984"); 
			}

			/// <summary>
			/// Gets Updator attribute data 
			/// </summary>
			public AttributeData GetUpdatorAttributeData() { 
				return GetAttributeData("COL17203931989"); 
			}

			/// <summary>
			/// Gets id attribute data 
			/// </summary>
			public AttributeData GetidAttributeData() { 
				return GetAttributeData("COL17203931981"); 
			}

			/// <summary>
			/// Gets Created attribute data 
			/// </summary>
			public AttributeData GetCreatedAttributeData() { 
				return GetAttributeData("COL17203931986"); 
			}


			/// <summary>
			/// Gets column UserName with alias  
			/// </summary>
			public string ColUserName { 
				get { return GetColumnName("COL17203931983"); } 
			}

			/// <summary>
			/// Gets column Updated with alias  
			/// </summary>
			public string ColUpdated { 
				get { return GetColumnName("COL17203931988"); } 
			}

			/// <summary>
			/// Gets column DelFlag with alias  
			/// </summary>
			public string ColDelFlag { 
				get { return GetColumnName("COL17203931985"); } 
			}

			/// <summary>
			/// Gets column MessageCommentId with alias  
			/// </summary>
			public string ColMessageCommentId { 
				get { return GetColumnName("COL17203931982"); } 
			}

			/// <summary>
			/// Gets column Creator with alias  
			/// </summary>
			public string ColCreator { 
				get { return GetColumnName("COL17203931987"); } 
			}

			/// <summary>
			/// Gets column ReadFlag with alias  
			/// </summary>
			public string ColReadFlag { 
				get { return GetColumnName("COL17203931984"); } 
			}

			/// <summary>
			/// Gets column Updator with alias  
			/// </summary>
			public string ColUpdator { 
				get { return GetColumnName("COL17203931989"); } 
			}

			/// <summary>
			/// Gets column id with alias  
			/// </summary>
			public string Colid { 
				get { return GetColumnName("COL17203931981"); } 
			}

			/// <summary>
			/// Gets column Created with alias  
			/// </summary>
			public string ColCreated { 
				get { return GetColumnName("COL17203931986"); } 
			}


			/// <summary>
			/// Checks whether column UserName is added in select statement 
			/// </summary>
			public bool IsSelectUserName { 
				get { return IsSelect("COL17203931983"); } 
				set { SetSelect("COL17203931983", value); } 
			}

			/// <summary>
			/// Checks whether column Updated is added in select statement 
			/// </summary>
			public bool IsSelectUpdated { 
				get { return IsSelect("COL17203931988"); } 
				set { SetSelect("COL17203931988", value); } 
			}

			/// <summary>
			/// Checks whether column DelFlag is added in select statement 
			/// </summary>
			public bool IsSelectDelFlag { 
				get { return IsSelect("COL17203931985"); } 
				set { SetSelect("COL17203931985", value); } 
			}

			/// <summary>
			/// Checks whether column MessageCommentId is added in select statement 
			/// </summary>
			public bool IsSelectMessageCommentId { 
				get { return IsSelect("COL17203931982"); } 
				set { SetSelect("COL17203931982", value); } 
			}

			/// <summary>
			/// Checks whether column Creator is added in select statement 
			/// </summary>
			public bool IsSelectCreator { 
				get { return IsSelect("COL17203931987"); } 
				set { SetSelect("COL17203931987", value); } 
			}

			/// <summary>
			/// Checks whether column ReadFlag is added in select statement 
			/// </summary>
			public bool IsSelectReadFlag { 
				get { return IsSelect("COL17203931984"); } 
				set { SetSelect("COL17203931984", value); } 
			}

			/// <summary>
			/// Checks whether column Updator is added in select statement 
			/// </summary>
			public bool IsSelectUpdator { 
				get { return IsSelect("COL17203931989"); } 
				set { SetSelect("COL17203931989", value); } 
			}

			/// <summary>
			/// Checks whether column id is added in select statement 
			/// </summary>
			public bool IsSelectid { 
				get { return IsSelect("COL17203931981"); } 
				set { SetSelect("COL17203931981", value); } 
			}

			/// <summary>
			/// Checks whether column Created is added in select statement 
			/// </summary>
			public bool IsSelectCreated { 
				get { return IsSelect("COL17203931986"); } 
				set { SetSelect("COL17203931986", value); } 
			}



	}
}