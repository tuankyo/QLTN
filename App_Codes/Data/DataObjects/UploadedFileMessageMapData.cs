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
	public class UploadedFileMessageMapData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ1512392457";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of UploadedFileMessageMap 
			/// </summary>
			public UploadedFileMessageMapData(string objectID): base(objectID) {}  

			public UploadedFileMessageMapData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field UploadFileID 
			/// </summary>
			public string UploadFileID { 
				get { return GetValue("COL15123924573"); } 
				set { SetValue("COL15123924573", value); } 
			}

			/// <summary>
			/// Gets field UploadedFileMessageMapId 
			/// </summary>
			public string UploadedFileMessageMapId { 
				get { return GetValue("COL15123924571"); } 
				set { SetValue("COL15123924571", value); } 
			}

			/// <summary>
			/// Gets field MessageID 
			/// </summary>
			public string MessageID { 
				get { return GetValue("COL15123924572"); } 
				set { SetValue("COL15123924572", value); } 
			}


			/// <summary>
			/// Gets UploadFileID attribute data 
			/// </summary>
			public AttributeData GetUploadFileIDAttributeData() { 
				return GetAttributeData("COL15123924573"); 
			}

			/// <summary>
			/// Gets UploadedFileMessageMapId attribute data 
			/// </summary>
			public AttributeData GetUploadedFileMessageMapIdAttributeData() { 
				return GetAttributeData("COL15123924571"); 
			}

			/// <summary>
			/// Gets MessageID attribute data 
			/// </summary>
			public AttributeData GetMessageIDAttributeData() { 
				return GetAttributeData("COL15123924572"); 
			}


			/// <summary>
			/// Gets column UploadFileID with alias  
			/// </summary>
			public string ColUploadFileID { 
				get { return GetColumnName("COL15123924573"); } 
			}

			/// <summary>
			/// Gets column UploadedFileMessageMapId with alias  
			/// </summary>
			public string ColUploadedFileMessageMapId { 
				get { return GetColumnName("COL15123924571"); } 
			}

			/// <summary>
			/// Gets column MessageID with alias  
			/// </summary>
			public string ColMessageID { 
				get { return GetColumnName("COL15123924572"); } 
			}


			/// <summary>
			/// Checks whether column UploadFileID is added in select statement 
			/// </summary>
			public bool IsSelectUploadFileID { 
				get { return IsSelect("COL15123924573"); } 
				set { SetSelect("COL15123924573", value); } 
			}

			/// <summary>
			/// Checks whether column UploadedFileMessageMapId is added in select statement 
			/// </summary>
			public bool IsSelectUploadedFileMessageMapId { 
				get { return IsSelect("COL15123924571"); } 
				set { SetSelect("COL15123924571", value); } 
			}

			/// <summary>
			/// Checks whether column MessageID is added in select statement 
			/// </summary>
			public bool IsSelectMessageID { 
				get { return IsSelect("COL15123924572"); } 
				set { SetSelect("COL15123924572", value); } 
			}



	}
}