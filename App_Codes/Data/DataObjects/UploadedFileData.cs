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
	public class UploadedFileData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ1480392343";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of UploadedFile 
			/// </summary>
			public UploadedFileData(string objectID): base(objectID) {}  

			public UploadedFileData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field CreatedBy 
			/// </summary>
			public string CreatedBy { 
				get { return GetValue("COL14803923436"); } 
				set { SetValue("COL14803923436", value); } 
			}

			/// <summary>
			/// Gets field UploadFileId 
			/// </summary>
			public string UploadFileId { 
				get { return GetValue("COL14803923431"); } 
				set { SetValue("COL14803923431", value); } 
			}

			/// <summary>
			/// Gets field DelFlag 
			/// </summary>
			public string DelFlag { 
				get { return GetValue("COL14803923439"); } 
				set { SetValue("COL14803923439", value); } 
			}

			/// <summary>
			/// Gets field OrgFileName 
			/// </summary>
			public string OrgFileName { 
				get { return GetValue("COL14803923434"); } 
				set { SetValue("COL14803923434", value); } 
			}

			/// <summary>
			/// Gets field Modified 
			/// </summary>
			public string Modified { 
				get { return GetValue("COL14803923437"); } 
				set { SetValue("COL14803923437", value); } 
			}

			/// <summary>
			/// Gets field FileName 
			/// </summary>
			public string FileName { 
				get { return GetValue("COL14803923432"); } 
				set { SetValue("COL14803923432", value); } 
			}

			/// <summary>
			/// Gets field Created 
			/// </summary>
			public string Created { 
				get { return GetValue("COL14803923435"); } 
				set { SetValue("COL14803923435", value); } 
			}

			/// <summary>
			/// Gets field ModifiedBy 
			/// </summary>
			public string ModifiedBy { 
				get { return GetValue("COL14803923438"); } 
				set { SetValue("COL14803923438", value); } 
			}

			/// <summary>
			/// Gets field PathFile 
			/// </summary>
			public string PathFile { 
				get { return GetValue("COL14803923433"); } 
				set { SetValue("COL14803923433", value); } 
			}


			/// <summary>
			/// Gets CreatedBy attribute data 
			/// </summary>
			public AttributeData GetCreatedByAttributeData() { 
				return GetAttributeData("COL14803923436"); 
			}

			/// <summary>
			/// Gets UploadFileId attribute data 
			/// </summary>
			public AttributeData GetUploadFileIdAttributeData() { 
				return GetAttributeData("COL14803923431"); 
			}

			/// <summary>
			/// Gets DelFlag attribute data 
			/// </summary>
			public AttributeData GetDelFlagAttributeData() { 
				return GetAttributeData("COL14803923439"); 
			}

			/// <summary>
			/// Gets OrgFileName attribute data 
			/// </summary>
			public AttributeData GetOrgFileNameAttributeData() { 
				return GetAttributeData("COL14803923434"); 
			}

			/// <summary>
			/// Gets Modified attribute data 
			/// </summary>
			public AttributeData GetModifiedAttributeData() { 
				return GetAttributeData("COL14803923437"); 
			}

			/// <summary>
			/// Gets FileName attribute data 
			/// </summary>
			public AttributeData GetFileNameAttributeData() { 
				return GetAttributeData("COL14803923432"); 
			}

			/// <summary>
			/// Gets Created attribute data 
			/// </summary>
			public AttributeData GetCreatedAttributeData() { 
				return GetAttributeData("COL14803923435"); 
			}

			/// <summary>
			/// Gets ModifiedBy attribute data 
			/// </summary>
			public AttributeData GetModifiedByAttributeData() { 
				return GetAttributeData("COL14803923438"); 
			}

			/// <summary>
			/// Gets PathFile attribute data 
			/// </summary>
			public AttributeData GetPathFileAttributeData() { 
				return GetAttributeData("COL14803923433"); 
			}


			/// <summary>
			/// Gets column CreatedBy with alias  
			/// </summary>
			public string ColCreatedBy { 
				get { return GetColumnName("COL14803923436"); } 
			}

			/// <summary>
			/// Gets column UploadFileId with alias  
			/// </summary>
			public string ColUploadFileId { 
				get { return GetColumnName("COL14803923431"); } 
			}

			/// <summary>
			/// Gets column DelFlag with alias  
			/// </summary>
			public string ColDelFlag { 
				get { return GetColumnName("COL14803923439"); } 
			}

			/// <summary>
			/// Gets column OrgFileName with alias  
			/// </summary>
			public string ColOrgFileName { 
				get { return GetColumnName("COL14803923434"); } 
			}

			/// <summary>
			/// Gets column Modified with alias  
			/// </summary>
			public string ColModified { 
				get { return GetColumnName("COL14803923437"); } 
			}

			/// <summary>
			/// Gets column FileName with alias  
			/// </summary>
			public string ColFileName { 
				get { return GetColumnName("COL14803923432"); } 
			}

			/// <summary>
			/// Gets column Created with alias  
			/// </summary>
			public string ColCreated { 
				get { return GetColumnName("COL14803923435"); } 
			}

			/// <summary>
			/// Gets column ModifiedBy with alias  
			/// </summary>
			public string ColModifiedBy { 
				get { return GetColumnName("COL14803923438"); } 
			}

			/// <summary>
			/// Gets column PathFile with alias  
			/// </summary>
			public string ColPathFile { 
				get { return GetColumnName("COL14803923433"); } 
			}


			/// <summary>
			/// Checks whether column CreatedBy is added in select statement 
			/// </summary>
			public bool IsSelectCreatedBy { 
				get { return IsSelect("COL14803923436"); } 
				set { SetSelect("COL14803923436", value); } 
			}

			/// <summary>
			/// Checks whether column UploadFileId is added in select statement 
			/// </summary>
			public bool IsSelectUploadFileId { 
				get { return IsSelect("COL14803923431"); } 
				set { SetSelect("COL14803923431", value); } 
			}

			/// <summary>
			/// Checks whether column DelFlag is added in select statement 
			/// </summary>
			public bool IsSelectDelFlag { 
				get { return IsSelect("COL14803923439"); } 
				set { SetSelect("COL14803923439", value); } 
			}

			/// <summary>
			/// Checks whether column OrgFileName is added in select statement 
			/// </summary>
			public bool IsSelectOrgFileName { 
				get { return IsSelect("COL14803923434"); } 
				set { SetSelect("COL14803923434", value); } 
			}

			/// <summary>
			/// Checks whether column Modified is added in select statement 
			/// </summary>
			public bool IsSelectModified { 
				get { return IsSelect("COL14803923437"); } 
				set { SetSelect("COL14803923437", value); } 
			}

			/// <summary>
			/// Checks whether column FileName is added in select statement 
			/// </summary>
			public bool IsSelectFileName { 
				get { return IsSelect("COL14803923432"); } 
				set { SetSelect("COL14803923432", value); } 
			}

			/// <summary>
			/// Checks whether column Created is added in select statement 
			/// </summary>
			public bool IsSelectCreated { 
				get { return IsSelect("COL14803923435"); } 
				set { SetSelect("COL14803923435", value); } 
			}

			/// <summary>
			/// Checks whether column ModifiedBy is added in select statement 
			/// </summary>
			public bool IsSelectModifiedBy { 
				get { return IsSelect("COL14803923438"); } 
				set { SetSelect("COL14803923438", value); } 
			}

			/// <summary>
			/// Checks whether column PathFile is added in select statement 
			/// </summary>
			public bool IsSelectPathFile { 
				get { return IsSelect("COL14803923433"); } 
				set { SetSelect("COL14803923433", value); } 
			}



	}
}