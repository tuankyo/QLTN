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
	public class aspnet_SchemaVersionsData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ293576084";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of aspnet_SchemaVersions 
			/// </summary>
			public aspnet_SchemaVersionsData(string objectID): base(objectID) {}  

			public aspnet_SchemaVersionsData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field CompatibleSchemaVersion 
			/// </summary>
			public string CompatibleSchemaVersion { 
				get { return GetValue("COL2935760842"); } 
				set { SetValue("COL2935760842", value); } 
			}

			/// <summary>
			/// Gets field Feature 
			/// </summary>
			public string Feature { 
				get { return GetValue("COL2935760841"); } 
				set { SetValue("COL2935760841", value); } 
			}

			/// <summary>
			/// Gets field IsCurrentVersion 
			/// </summary>
			public string IsCurrentVersion { 
				get { return GetValue("COL2935760843"); } 
				set { SetValue("COL2935760843", value); } 
			}


			/// <summary>
			/// Gets CompatibleSchemaVersion attribute data 
			/// </summary>
			public AttributeData GetCompatibleSchemaVersionAttributeData() { 
				return GetAttributeData("COL2935760842"); 
			}

			/// <summary>
			/// Gets Feature attribute data 
			/// </summary>
			public AttributeData GetFeatureAttributeData() { 
				return GetAttributeData("COL2935760841"); 
			}

			/// <summary>
			/// Gets IsCurrentVersion attribute data 
			/// </summary>
			public AttributeData GetIsCurrentVersionAttributeData() { 
				return GetAttributeData("COL2935760843"); 
			}


			/// <summary>
			/// Gets column CompatibleSchemaVersion with alias  
			/// </summary>
			public string ColCompatibleSchemaVersion { 
				get { return GetColumnName("COL2935760842"); } 
			}

			/// <summary>
			/// Gets column Feature with alias  
			/// </summary>
			public string ColFeature { 
				get { return GetColumnName("COL2935760841"); } 
			}

			/// <summary>
			/// Gets column IsCurrentVersion with alias  
			/// </summary>
			public string ColIsCurrentVersion { 
				get { return GetColumnName("COL2935760843"); } 
			}


			/// <summary>
			/// Checks whether column CompatibleSchemaVersion is added in select statement 
			/// </summary>
			public bool IsSelectCompatibleSchemaVersion { 
				get { return IsSelect("COL2935760842"); } 
				set { SetSelect("COL2935760842", value); } 
			}

			/// <summary>
			/// Checks whether column Feature is added in select statement 
			/// </summary>
			public bool IsSelectFeature { 
				get { return IsSelect("COL2935760841"); } 
				set { SetSelect("COL2935760841", value); } 
			}

			/// <summary>
			/// Checks whether column IsCurrentVersion is added in select statement 
			/// </summary>
			public bool IsSelectIsCurrentVersion { 
				get { return IsSelect("COL2935760843"); } 
				set { SetSelect("COL2935760843", value); } 
			}



	}
}