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
	public class aspnet_PersonalizationAllUsersData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ1589580701";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of aspnet_PersonalizationAllUsers 
			/// </summary>
			public aspnet_PersonalizationAllUsersData(string objectID): base(objectID) {}  

			public aspnet_PersonalizationAllUsersData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field LastUpdatedDate 
			/// </summary>
			public string LastUpdatedDate { 
				get { return GetValue("COL15895807013"); } 
				set { SetValue("COL15895807013", value); } 
			}

			/// <summary>
			/// Gets field PageSettings 
			/// </summary>
			public string PageSettings { 
				get { return GetValue("COL15895807012"); } 
				set { SetValue("COL15895807012", value); } 
			}

			/// <summary>
			/// Gets field PathId 
			/// </summary>
			public string PathId { 
				get { return GetValue("COL15895807011"); } 
				set { SetValue("COL15895807011", value); } 
			}


			/// <summary>
			/// Gets LastUpdatedDate attribute data 
			/// </summary>
			public AttributeData GetLastUpdatedDateAttributeData() { 
				return GetAttributeData("COL15895807013"); 
			}

			/// <summary>
			/// Gets PageSettings attribute data 
			/// </summary>
			public AttributeData GetPageSettingsAttributeData() { 
				return GetAttributeData("COL15895807012"); 
			}

			/// <summary>
			/// Gets PathId attribute data 
			/// </summary>
			public AttributeData GetPathIdAttributeData() { 
				return GetAttributeData("COL15895807011"); 
			}


			/// <summary>
			/// Gets column LastUpdatedDate with alias  
			/// </summary>
			public string ColLastUpdatedDate { 
				get { return GetColumnName("COL15895807013"); } 
			}

			/// <summary>
			/// Gets column PageSettings with alias  
			/// </summary>
			public string ColPageSettings { 
				get { return GetColumnName("COL15895807012"); } 
			}

			/// <summary>
			/// Gets column PathId with alias  
			/// </summary>
			public string ColPathId { 
				get { return GetColumnName("COL15895807011"); } 
			}


			/// <summary>
			/// Checks whether column LastUpdatedDate is added in select statement 
			/// </summary>
			public bool IsSelectLastUpdatedDate { 
				get { return IsSelect("COL15895807013"); } 
				set { SetSelect("COL15895807013", value); } 
			}

			/// <summary>
			/// Checks whether column PageSettings is added in select statement 
			/// </summary>
			public bool IsSelectPageSettings { 
				get { return IsSelect("COL15895807012"); } 
				set { SetSelect("COL15895807012", value); } 
			}

			/// <summary>
			/// Checks whether column PathId is added in select statement 
			/// </summary>
			public bool IsSelectPathId { 
				get { return IsSelect("COL15895807011"); } 
				set { SetSelect("COL15895807011", value); } 
			}



	}
}