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
	public class CustomerCommingDocData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ1048390804";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of CustomerCommingDoc 
			/// </summary>
			public CustomerCommingDocData(string objectID): base(objectID) {}  

			public CustomerCommingDocData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field CommingDocName 
			/// </summary>
			public string CommingDocName { 
				get { return GetValue("COL10483908044"); } 
				set { SetValue("COL10483908044", value); } 
			}

			/// <summary>
			/// Gets field Modified 
			/// </summary>
			public string Modified { 
				get { return GetValue("COL104839080410"); } 
				set { SetValue("COL104839080410", value); } 
			}

			/// <summary>
			/// Gets field CustomerId 
			/// </summary>
			public string CustomerId { 
				get { return GetValue("COL10483908043"); } 
				set { SetValue("COL10483908043", value); } 
			}

			/// <summary>
			/// Gets field CommingDate 
			/// </summary>
			public string CommingDate { 
				get { return GetValue("COL10483908046"); } 
				set { SetValue("COL10483908046", value); } 
			}

			/// <summary>
			/// Gets field BuildingId 
			/// </summary>
			public string BuildingId { 
				get { return GetValue("COL10483908042"); } 
				set { SetValue("COL10483908042", value); } 
			}

			/// <summary>
			/// Gets field CommingDocMount 
			/// </summary>
			public string CommingDocMount { 
				get { return GetValue("COL10483908045"); } 
				set { SetValue("COL10483908045", value); } 
			}

			/// <summary>
			/// Gets field Created 
			/// </summary>
			public string Created { 
				get { return GetValue("COL10483908048"); } 
				set { SetValue("COL10483908048", value); } 
			}

			/// <summary>
			/// Gets field Comment 
			/// </summary>
			public string Comment { 
				get { return GetValue("COL10483908047"); } 
				set { SetValue("COL10483908047", value); } 
			}

			/// <summary>
			/// Gets field DelFlag 
			/// </summary>
			public string DelFlag { 
				get { return GetValue("COL104839080412"); } 
				set { SetValue("COL104839080412", value); } 
			}

			/// <summary>
			/// Gets field CreatedBy 
			/// </summary>
			public string CreatedBy { 
				get { return GetValue("COL10483908049"); } 
				set { SetValue("COL10483908049", value); } 
			}

			/// <summary>
			/// Gets field ModifiedBy 
			/// </summary>
			public string ModifiedBy { 
				get { return GetValue("COL104839080411"); } 
				set { SetValue("COL104839080411", value); } 
			}

			/// <summary>
			/// Gets field id 
			/// </summary>
			public string id { 
				get { return GetValue("COL10483908041"); } 
				set { SetValue("COL10483908041", value); } 
			}


			/// <summary>
			/// Gets CommingDocName attribute data 
			/// </summary>
			public AttributeData GetCommingDocNameAttributeData() { 
				return GetAttributeData("COL10483908044"); 
			}

			/// <summary>
			/// Gets Modified attribute data 
			/// </summary>
			public AttributeData GetModifiedAttributeData() { 
				return GetAttributeData("COL104839080410"); 
			}

			/// <summary>
			/// Gets CustomerId attribute data 
			/// </summary>
			public AttributeData GetCustomerIdAttributeData() { 
				return GetAttributeData("COL10483908043"); 
			}

			/// <summary>
			/// Gets CommingDate attribute data 
			/// </summary>
			public AttributeData GetCommingDateAttributeData() { 
				return GetAttributeData("COL10483908046"); 
			}

			/// <summary>
			/// Gets BuildingId attribute data 
			/// </summary>
			public AttributeData GetBuildingIdAttributeData() { 
				return GetAttributeData("COL10483908042"); 
			}

			/// <summary>
			/// Gets CommingDocMount attribute data 
			/// </summary>
			public AttributeData GetCommingDocMountAttributeData() { 
				return GetAttributeData("COL10483908045"); 
			}

			/// <summary>
			/// Gets Created attribute data 
			/// </summary>
			public AttributeData GetCreatedAttributeData() { 
				return GetAttributeData("COL10483908048"); 
			}

			/// <summary>
			/// Gets Comment attribute data 
			/// </summary>
			public AttributeData GetCommentAttributeData() { 
				return GetAttributeData("COL10483908047"); 
			}

			/// <summary>
			/// Gets DelFlag attribute data 
			/// </summary>
			public AttributeData GetDelFlagAttributeData() { 
				return GetAttributeData("COL104839080412"); 
			}

			/// <summary>
			/// Gets CreatedBy attribute data 
			/// </summary>
			public AttributeData GetCreatedByAttributeData() { 
				return GetAttributeData("COL10483908049"); 
			}

			/// <summary>
			/// Gets ModifiedBy attribute data 
			/// </summary>
			public AttributeData GetModifiedByAttributeData() { 
				return GetAttributeData("COL104839080411"); 
			}

			/// <summary>
			/// Gets id attribute data 
			/// </summary>
			public AttributeData GetidAttributeData() { 
				return GetAttributeData("COL10483908041"); 
			}


			/// <summary>
			/// Gets column CommingDocName with alias  
			/// </summary>
			public string ColCommingDocName { 
				get { return GetColumnName("COL10483908044"); } 
			}

			/// <summary>
			/// Gets column Modified with alias  
			/// </summary>
			public string ColModified { 
				get { return GetColumnName("COL104839080410"); } 
			}

			/// <summary>
			/// Gets column CustomerId with alias  
			/// </summary>
			public string ColCustomerId { 
				get { return GetColumnName("COL10483908043"); } 
			}

			/// <summary>
			/// Gets column CommingDate with alias  
			/// </summary>
			public string ColCommingDate { 
				get { return GetColumnName("COL10483908046"); } 
			}

			/// <summary>
			/// Gets column BuildingId with alias  
			/// </summary>
			public string ColBuildingId { 
				get { return GetColumnName("COL10483908042"); } 
			}

			/// <summary>
			/// Gets column CommingDocMount with alias  
			/// </summary>
			public string ColCommingDocMount { 
				get { return GetColumnName("COL10483908045"); } 
			}

			/// <summary>
			/// Gets column Created with alias  
			/// </summary>
			public string ColCreated { 
				get { return GetColumnName("COL10483908048"); } 
			}

			/// <summary>
			/// Gets column Comment with alias  
			/// </summary>
			public string ColComment { 
				get { return GetColumnName("COL10483908047"); } 
			}

			/// <summary>
			/// Gets column DelFlag with alias  
			/// </summary>
			public string ColDelFlag { 
				get { return GetColumnName("COL104839080412"); } 
			}

			/// <summary>
			/// Gets column CreatedBy with alias  
			/// </summary>
			public string ColCreatedBy { 
				get { return GetColumnName("COL10483908049"); } 
			}

			/// <summary>
			/// Gets column ModifiedBy with alias  
			/// </summary>
			public string ColModifiedBy { 
				get { return GetColumnName("COL104839080411"); } 
			}

			/// <summary>
			/// Gets column id with alias  
			/// </summary>
			public string Colid { 
				get { return GetColumnName("COL10483908041"); } 
			}


			/// <summary>
			/// Checks whether column CommingDocName is added in select statement 
			/// </summary>
			public bool IsSelectCommingDocName { 
				get { return IsSelect("COL10483908044"); } 
				set { SetSelect("COL10483908044", value); } 
			}

			/// <summary>
			/// Checks whether column Modified is added in select statement 
			/// </summary>
			public bool IsSelectModified { 
				get { return IsSelect("COL104839080410"); } 
				set { SetSelect("COL104839080410", value); } 
			}

			/// <summary>
			/// Checks whether column CustomerId is added in select statement 
			/// </summary>
			public bool IsSelectCustomerId { 
				get { return IsSelect("COL10483908043"); } 
				set { SetSelect("COL10483908043", value); } 
			}

			/// <summary>
			/// Checks whether column CommingDate is added in select statement 
			/// </summary>
			public bool IsSelectCommingDate { 
				get { return IsSelect("COL10483908046"); } 
				set { SetSelect("COL10483908046", value); } 
			}

			/// <summary>
			/// Checks whether column BuildingId is added in select statement 
			/// </summary>
			public bool IsSelectBuildingId { 
				get { return IsSelect("COL10483908042"); } 
				set { SetSelect("COL10483908042", value); } 
			}

			/// <summary>
			/// Checks whether column CommingDocMount is added in select statement 
			/// </summary>
			public bool IsSelectCommingDocMount { 
				get { return IsSelect("COL10483908045"); } 
				set { SetSelect("COL10483908045", value); } 
			}

			/// <summary>
			/// Checks whether column Created is added in select statement 
			/// </summary>
			public bool IsSelectCreated { 
				get { return IsSelect("COL10483908048"); } 
				set { SetSelect("COL10483908048", value); } 
			}

			/// <summary>
			/// Checks whether column Comment is added in select statement 
			/// </summary>
			public bool IsSelectComment { 
				get { return IsSelect("COL10483908047"); } 
				set { SetSelect("COL10483908047", value); } 
			}

			/// <summary>
			/// Checks whether column DelFlag is added in select statement 
			/// </summary>
			public bool IsSelectDelFlag { 
				get { return IsSelect("COL104839080412"); } 
				set { SetSelect("COL104839080412", value); } 
			}

			/// <summary>
			/// Checks whether column CreatedBy is added in select statement 
			/// </summary>
			public bool IsSelectCreatedBy { 
				get { return IsSelect("COL10483908049"); } 
				set { SetSelect("COL10483908049", value); } 
			}

			/// <summary>
			/// Checks whether column ModifiedBy is added in select statement 
			/// </summary>
			public bool IsSelectModifiedBy { 
				get { return IsSelect("COL104839080411"); } 
				set { SetSelect("COL104839080411", value); } 
			}

			/// <summary>
			/// Checks whether column id is added in select statement 
			/// </summary>
			public bool IsSelectid { 
				get { return IsSelect("COL10483908041"); } 
				set { SetSelect("COL10483908041", value); } 
			}



	}
}