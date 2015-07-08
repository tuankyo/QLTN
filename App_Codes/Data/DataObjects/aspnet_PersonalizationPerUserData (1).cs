// ==========================================
//  Author : GNT Data Object Generator Tool
//  Created   : 2014-10-21 16:27:23
//  Copyright GNT INC.  All rights reserved.
// ==========================================
using System;
using System.Collections;
using Gnt.Data.Meta;
using Gnt.Data;

namespace BusinessObjects
{

	[Serializable]
	public class aspnet_PersonalizationPerUserData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ1669580986";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of aspnet_PersonalizationPerUser 
			/// </summary>
			public aspnet_PersonalizationPerUserData(string objectID): base(objectID) {}  

			public aspnet_PersonalizationPerUserData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field UserId 
			/// </summary>
			public string UserId { 
				get { return GetValue("COL16695809863"); } 
				set { SetValue("COL16695809863", value); } 
			}

			/// <summary>
			/// Gets field PathId 
			/// </summary>
			public string PathId { 
				get { return GetValue("COL16695809862"); } 
				set { SetValue("COL16695809862", value); } 
			}

			/// <summary>
			/// Gets field Id 
			/// </summary>
			public string Id { 
				get { return GetValue("COL16695809861"); } 
				set { SetValue("COL16695809861", value); } 
			}

			/// <summary>
			/// Gets field LastUpdatedDate 
			/// </summary>
			public string LastUpdatedDate { 
				get { return GetValue("COL16695809865"); } 
				set { SetValue("COL16695809865", value); } 
			}

			/// <summary>
			/// Gets field PageSettings 
			/// </summary>
			public string PageSettings { 
				get { return GetValue("COL16695809864"); } 
				set { SetValue("COL16695809864", value); } 
			}


			/// <summary>
			/// Gets UserId attribute data 
			/// </summary>
			public AttributeData GetUserIdAttributeData() { 
				return GetAttributeData("COL16695809863"); 
			}

			/// <summary>
			/// Gets PathId attribute data 
			/// </summary>
			public AttributeData GetPathIdAttributeData() { 
				return GetAttributeData("COL16695809862"); 
			}

			/// <summary>
			/// Gets Id attribute data 
			/// </summary>
			public AttributeData GetIdAttributeData() { 
				return GetAttributeData("COL16695809861"); 
			}

			/// <summary>
			/// Gets LastUpdatedDate attribute data 
			/// </summary>
			public AttributeData GetLastUpdatedDateAttributeData() { 
				return GetAttributeData("COL16695809865"); 
			}

			/// <summary>
			/// Gets PageSettings attribute data 
			/// </summary>
			public AttributeData GetPageSettingsAttributeData() { 
				return GetAttributeData("COL16695809864"); 
			}


			/// <summary>
			/// Gets column UserId with alias  
			/// </summary>
			public string ColUserId { 
				get { return GetColumnName("COL16695809863"); } 
			}

			/// <summary>
			/// Gets column PathId with alias  
			/// </summary>
			public string ColPathId { 
				get { return GetColumnName("COL16695809862"); } 
			}

			/// <summary>
			/// Gets column Id with alias  
			/// </summary>
			public string ColId { 
				get { return GetColumnName("COL16695809861"); } 
			}

			/// <summary>
			/// Gets column LastUpdatedDate with alias  
			/// </summary>
			public string ColLastUpdatedDate { 
				get { return GetColumnName("COL16695809865"); } 
			}

			/// <summary>
			/// Gets column PageSettings with alias  
			/// </summary>
			public string ColPageSettings { 
				get { return GetColumnName("COL16695809864"); } 
			}


			/// <summary>
			/// Checks whether column UserId is added in select statement 
			/// </summary>
			public bool IsSelectUserId { 
				get { return IsSelect("COL16695809863"); } 
				set { SetSelect("COL16695809863", value); } 
			}

			/// <summary>
			/// Checks whether column PathId is added in select statement 
			/// </summary>
			public bool IsSelectPathId { 
				get { return IsSelect("COL16695809862"); } 
				set { SetSelect("COL16695809862", value); } 
			}

			/// <summary>
			/// Checks whether column Id is added in select statement 
			/// </summary>
			public bool IsSelectId { 
				get { return IsSelect("COL16695809861"); } 
				set { SetSelect("COL16695809861", value); } 
			}

			/// <summary>
			/// Checks whether column LastUpdatedDate is added in select statement 
			/// </summary>
			public bool IsSelectLastUpdatedDate { 
				get { return IsSelect("COL16695809865"); } 
				set { SetSelect("COL16695809865", value); } 
			}

			/// <summary>
			/// Checks whether column PageSettings is added in select statement 
			/// </summary>
			public bool IsSelectPageSettings { 
				get { return IsSelect("COL16695809864"); } 
				set { SetSelect("COL16695809864", value); } 
			}



	}
}