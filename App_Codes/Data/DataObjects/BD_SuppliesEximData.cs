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
	public class BD_SuppliesEximData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ770101784";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of BD_SuppliesExim 
			/// </summary>
			public BD_SuppliesEximData(string objectID): base(objectID) {}  

			public BD_SuppliesEximData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field ProcessDate 
			/// </summary>
			public string ProcessDate { 
				get { return GetValue("COL7701017843"); } 
				set { SetValue("COL7701017843", value); } 
			}

			/// <summary>
			/// Gets field SuppliesId 
			/// </summary>
			public string SuppliesId { 
				get { return GetValue("COL7701017842"); } 
				set { SetValue("COL7701017842", value); } 
			}

			/// <summary>
			/// Gets field Comment 
			/// </summary>
			public string Comment { 
				get { return GetValue("COL77010178410"); } 
				set { SetValue("COL77010178410", value); } 
			}

			/// <summary>
			/// Gets field DelFlag 
			/// </summary>
			public string DelFlag { 
				get { return GetValue("COL77010178415"); } 
				set { SetValue("COL77010178415", value); } 
			}

			/// <summary>
			/// Gets field ProcessType 
			/// </summary>
			public string ProcessType { 
				get { return GetValue("COL77010178416"); } 
				set { SetValue("COL77010178416", value); } 
			}

			/// <summary>
			/// Gets field Price 
			/// </summary>
			public string Price { 
				get { return GetValue("COL7701017848"); } 
				set { SetValue("COL7701017848", value); } 
			}

			/// <summary>
			/// Gets field Modified 
			/// </summary>
			public string Modified { 
				get { return GetValue("COL77010178413"); } 
				set { SetValue("COL77010178413", value); } 
			}

			/// <summary>
			/// Gets field ModifiedBy 
			/// </summary>
			public string ModifiedBy { 
				get { return GetValue("COL77010178414"); } 
				set { SetValue("COL77010178414", value); } 
			}

			/// <summary>
			/// Gets field ProvideFrom 
			/// </summary>
			public string ProvideFrom { 
				get { return GetValue("COL7701017849"); } 
				set { SetValue("COL7701017849", value); } 
			}

			/// <summary>
			/// Gets field Importer 
			/// </summary>
			public string Importer { 
				get { return GetValue("COL7701017844"); } 
				set { SetValue("COL7701017844", value); } 
			}

			/// <summary>
			/// Gets field Exporter 
			/// </summary>
			public string Exporter { 
				get { return GetValue("COL7701017845"); } 
				set { SetValue("COL7701017845", value); } 
			}

			/// <summary>
			/// Gets field Created 
			/// </summary>
			public string Created { 
				get { return GetValue("COL77010178411"); } 
				set { SetValue("COL77010178411", value); } 
			}

			/// <summary>
			/// Gets field Mount 
			/// </summary>
			public string Mount { 
				get { return GetValue("COL7701017847"); } 
				set { SetValue("COL7701017847", value); } 
			}

			/// <summary>
			/// Gets field Approver 
			/// </summary>
			public string Approver { 
				get { return GetValue("COL7701017846"); } 
				set { SetValue("COL7701017846", value); } 
			}

			/// <summary>
			/// Gets field id 
			/// </summary>
			public string id { 
				get { return GetValue("COL7701017841"); } 
				set { SetValue("COL7701017841", value); } 
			}

			/// <summary>
			/// Gets field CreatedBy 
			/// </summary>
			public string CreatedBy { 
				get { return GetValue("COL77010178412"); } 
				set { SetValue("COL77010178412", value); } 
			}


			/// <summary>
			/// Gets ProcessDate attribute data 
			/// </summary>
			public AttributeData GetProcessDateAttributeData() { 
				return GetAttributeData("COL7701017843"); 
			}

			/// <summary>
			/// Gets SuppliesId attribute data 
			/// </summary>
			public AttributeData GetSuppliesIdAttributeData() { 
				return GetAttributeData("COL7701017842"); 
			}

			/// <summary>
			/// Gets Comment attribute data 
			/// </summary>
			public AttributeData GetCommentAttributeData() { 
				return GetAttributeData("COL77010178410"); 
			}

			/// <summary>
			/// Gets DelFlag attribute data 
			/// </summary>
			public AttributeData GetDelFlagAttributeData() { 
				return GetAttributeData("COL77010178415"); 
			}

			/// <summary>
			/// Gets ProcessType attribute data 
			/// </summary>
			public AttributeData GetProcessTypeAttributeData() { 
				return GetAttributeData("COL77010178416"); 
			}

			/// <summary>
			/// Gets Price attribute data 
			/// </summary>
			public AttributeData GetPriceAttributeData() { 
				return GetAttributeData("COL7701017848"); 
			}

			/// <summary>
			/// Gets Modified attribute data 
			/// </summary>
			public AttributeData GetModifiedAttributeData() { 
				return GetAttributeData("COL77010178413"); 
			}

			/// <summary>
			/// Gets ModifiedBy attribute data 
			/// </summary>
			public AttributeData GetModifiedByAttributeData() { 
				return GetAttributeData("COL77010178414"); 
			}

			/// <summary>
			/// Gets ProvideFrom attribute data 
			/// </summary>
			public AttributeData GetProvideFromAttributeData() { 
				return GetAttributeData("COL7701017849"); 
			}

			/// <summary>
			/// Gets Importer attribute data 
			/// </summary>
			public AttributeData GetImporterAttributeData() { 
				return GetAttributeData("COL7701017844"); 
			}

			/// <summary>
			/// Gets Exporter attribute data 
			/// </summary>
			public AttributeData GetExporterAttributeData() { 
				return GetAttributeData("COL7701017845"); 
			}

			/// <summary>
			/// Gets Created attribute data 
			/// </summary>
			public AttributeData GetCreatedAttributeData() { 
				return GetAttributeData("COL77010178411"); 
			}

			/// <summary>
			/// Gets Mount attribute data 
			/// </summary>
			public AttributeData GetMountAttributeData() { 
				return GetAttributeData("COL7701017847"); 
			}

			/// <summary>
			/// Gets Approver attribute data 
			/// </summary>
			public AttributeData GetApproverAttributeData() { 
				return GetAttributeData("COL7701017846"); 
			}

			/// <summary>
			/// Gets id attribute data 
			/// </summary>
			public AttributeData GetidAttributeData() { 
				return GetAttributeData("COL7701017841"); 
			}

			/// <summary>
			/// Gets CreatedBy attribute data 
			/// </summary>
			public AttributeData GetCreatedByAttributeData() { 
				return GetAttributeData("COL77010178412"); 
			}


			/// <summary>
			/// Gets column ProcessDate with alias  
			/// </summary>
			public string ColProcessDate { 
				get { return GetColumnName("COL7701017843"); } 
			}

			/// <summary>
			/// Gets column SuppliesId with alias  
			/// </summary>
			public string ColSuppliesId { 
				get { return GetColumnName("COL7701017842"); } 
			}

			/// <summary>
			/// Gets column Comment with alias  
			/// </summary>
			public string ColComment { 
				get { return GetColumnName("COL77010178410"); } 
			}

			/// <summary>
			/// Gets column DelFlag with alias  
			/// </summary>
			public string ColDelFlag { 
				get { return GetColumnName("COL77010178415"); } 
			}

			/// <summary>
			/// Gets column ProcessType with alias  
			/// </summary>
			public string ColProcessType { 
				get { return GetColumnName("COL77010178416"); } 
			}

			/// <summary>
			/// Gets column Price with alias  
			/// </summary>
			public string ColPrice { 
				get { return GetColumnName("COL7701017848"); } 
			}

			/// <summary>
			/// Gets column Modified with alias  
			/// </summary>
			public string ColModified { 
				get { return GetColumnName("COL77010178413"); } 
			}

			/// <summary>
			/// Gets column ModifiedBy with alias  
			/// </summary>
			public string ColModifiedBy { 
				get { return GetColumnName("COL77010178414"); } 
			}

			/// <summary>
			/// Gets column ProvideFrom with alias  
			/// </summary>
			public string ColProvideFrom { 
				get { return GetColumnName("COL7701017849"); } 
			}

			/// <summary>
			/// Gets column Importer with alias  
			/// </summary>
			public string ColImporter { 
				get { return GetColumnName("COL7701017844"); } 
			}

			/// <summary>
			/// Gets column Exporter with alias  
			/// </summary>
			public string ColExporter { 
				get { return GetColumnName("COL7701017845"); } 
			}

			/// <summary>
			/// Gets column Created with alias  
			/// </summary>
			public string ColCreated { 
				get { return GetColumnName("COL77010178411"); } 
			}

			/// <summary>
			/// Gets column Mount with alias  
			/// </summary>
			public string ColMount { 
				get { return GetColumnName("COL7701017847"); } 
			}

			/// <summary>
			/// Gets column Approver with alias  
			/// </summary>
			public string ColApprover { 
				get { return GetColumnName("COL7701017846"); } 
			}

			/// <summary>
			/// Gets column id with alias  
			/// </summary>
			public string Colid { 
				get { return GetColumnName("COL7701017841"); } 
			}

			/// <summary>
			/// Gets column CreatedBy with alias  
			/// </summary>
			public string ColCreatedBy { 
				get { return GetColumnName("COL77010178412"); } 
			}


			/// <summary>
			/// Checks whether column ProcessDate is added in select statement 
			/// </summary>
			public bool IsSelectProcessDate { 
				get { return IsSelect("COL7701017843"); } 
				set { SetSelect("COL7701017843", value); } 
			}

			/// <summary>
			/// Checks whether column SuppliesId is added in select statement 
			/// </summary>
			public bool IsSelectSuppliesId { 
				get { return IsSelect("COL7701017842"); } 
				set { SetSelect("COL7701017842", value); } 
			}

			/// <summary>
			/// Checks whether column Comment is added in select statement 
			/// </summary>
			public bool IsSelectComment { 
				get { return IsSelect("COL77010178410"); } 
				set { SetSelect("COL77010178410", value); } 
			}

			/// <summary>
			/// Checks whether column DelFlag is added in select statement 
			/// </summary>
			public bool IsSelectDelFlag { 
				get { return IsSelect("COL77010178415"); } 
				set { SetSelect("COL77010178415", value); } 
			}

			/// <summary>
			/// Checks whether column ProcessType is added in select statement 
			/// </summary>
			public bool IsSelectProcessType { 
				get { return IsSelect("COL77010178416"); } 
				set { SetSelect("COL77010178416", value); } 
			}

			/// <summary>
			/// Checks whether column Price is added in select statement 
			/// </summary>
			public bool IsSelectPrice { 
				get { return IsSelect("COL7701017848"); } 
				set { SetSelect("COL7701017848", value); } 
			}

			/// <summary>
			/// Checks whether column Modified is added in select statement 
			/// </summary>
			public bool IsSelectModified { 
				get { return IsSelect("COL77010178413"); } 
				set { SetSelect("COL77010178413", value); } 
			}

			/// <summary>
			/// Checks whether column ModifiedBy is added in select statement 
			/// </summary>
			public bool IsSelectModifiedBy { 
				get { return IsSelect("COL77010178414"); } 
				set { SetSelect("COL77010178414", value); } 
			}

			/// <summary>
			/// Checks whether column ProvideFrom is added in select statement 
			/// </summary>
			public bool IsSelectProvideFrom { 
				get { return IsSelect("COL7701017849"); } 
				set { SetSelect("COL7701017849", value); } 
			}

			/// <summary>
			/// Checks whether column Importer is added in select statement 
			/// </summary>
			public bool IsSelectImporter { 
				get { return IsSelect("COL7701017844"); } 
				set { SetSelect("COL7701017844", value); } 
			}

			/// <summary>
			/// Checks whether column Exporter is added in select statement 
			/// </summary>
			public bool IsSelectExporter { 
				get { return IsSelect("COL7701017845"); } 
				set { SetSelect("COL7701017845", value); } 
			}

			/// <summary>
			/// Checks whether column Created is added in select statement 
			/// </summary>
			public bool IsSelectCreated { 
				get { return IsSelect("COL77010178411"); } 
				set { SetSelect("COL77010178411", value); } 
			}

			/// <summary>
			/// Checks whether column Mount is added in select statement 
			/// </summary>
			public bool IsSelectMount { 
				get { return IsSelect("COL7701017847"); } 
				set { SetSelect("COL7701017847", value); } 
			}

			/// <summary>
			/// Checks whether column Approver is added in select statement 
			/// </summary>
			public bool IsSelectApprover { 
				get { return IsSelect("COL7701017846"); } 
				set { SetSelect("COL7701017846", value); } 
			}

			/// <summary>
			/// Checks whether column id is added in select statement 
			/// </summary>
			public bool IsSelectid { 
				get { return IsSelect("COL7701017841"); } 
				set { SetSelect("COL7701017841", value); } 
			}

			/// <summary>
			/// Checks whether column CreatedBy is added in select statement 
			/// </summary>
			public bool IsSelectCreatedBy { 
				get { return IsSelect("COL77010178412"); } 
				set { SetSelect("COL77010178412", value); } 
			}



	}
}