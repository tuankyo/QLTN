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
	public class BD_DocumentData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ2015346244";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of BD_Document 
			/// </summary>
			public BD_DocumentData(string objectID): base(objectID) {}  

			public BD_DocumentData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field InOutDoc 
			/// </summary>
			public string InOutDoc { 
				get { return GetValue("COL201534624419"); } 
				set { SetValue("COL201534624419", value); } 
			}

			/// <summary>
			/// Gets field CustomerId 
			/// </summary>
			public string CustomerId { 
				get { return GetValue("COL20153462448"); } 
				set { SetValue("COL20153462448", value); } 
			}

			/// <summary>
			/// Gets field EquipmentId 
			/// </summary>
			public string EquipmentId { 
				get { return GetValue("COL20153462445"); } 
				set { SetValue("COL20153462445", value); } 
			}

			/// <summary>
			/// Gets field FileNamePath 
			/// </summary>
			public string FileNamePath { 
				get { return GetValue("COL201534624411"); } 
				set { SetValue("COL201534624411", value); } 
			}

			/// <summary>
			/// Gets field Modified 
			/// </summary>
			public string Modified { 
				get { return GetValue("COL201534624415"); } 
				set { SetValue("COL201534624415", value); } 
			}

			/// <summary>
			/// Gets field Appeal 
			/// </summary>
			public string Appeal { 
				get { return GetValue("COL201534624420"); } 
				set { SetValue("COL201534624420", value); } 
			}

			/// <summary>
			/// Gets field ModifiedBy 
			/// </summary>
			public string ModifiedBy { 
				get { return GetValue("COL201534624416"); } 
				set { SetValue("COL201534624416", value); } 
			}

			/// <summary>
			/// Gets field SuppliesId 
			/// </summary>
			public string SuppliesId { 
				get { return GetValue("COL20153462446"); } 
				set { SetValue("COL20153462446", value); } 
			}

			/// <summary>
			/// Gets field DelFlag 
			/// </summary>
			public string DelFlag { 
				get { return GetValue("COL201534624417"); } 
				set { SetValue("COL201534624417", value); } 
			}

			/// <summary>
			/// Gets field ContractId 
			/// </summary>
			public string ContractId { 
				get { return GetValue("COL20153462449"); } 
				set { SetValue("COL20153462449", value); } 
			}

			/// <summary>
			/// Gets field DocType 
			/// </summary>
			public string DocType { 
				get { return GetValue("COL20153462443"); } 
				set { SetValue("COL20153462443", value); } 
			}

			/// <summary>
			/// Gets field Comment 
			/// </summary>
			public string Comment { 
				get { return GetValue("COL201534624412"); } 
				set { SetValue("COL201534624412", value); } 
			}

			/// <summary>
			/// Gets field Dept 
			/// </summary>
			public string Dept { 
				get { return GetValue("COL20153462444"); } 
				set { SetValue("COL20153462444", value); } 
			}

			/// <summary>
			/// Gets field Created 
			/// </summary>
			public string Created { 
				get { return GetValue("COL201534624413"); } 
				set { SetValue("COL201534624413", value); } 
			}

			/// <summary>
			/// Gets field DocSubject 
			/// </summary>
			public string DocSubject { 
				get { return GetValue("COL201534624422"); } 
				set { SetValue("COL201534624422", value); } 
			}

			/// <summary>
			/// Gets field id 
			/// </summary>
			public string id { 
				get { return GetValue("COL20153462441"); } 
				set { SetValue("COL20153462441", value); } 
			}

			/// <summary>
			/// Gets field DocDate 
			/// </summary>
			public string DocDate { 
				get { return GetValue("COL201534624423"); } 
				set { SetValue("COL201534624423", value); } 
			}

			/// <summary>
			/// Gets field StaffId 
			/// </summary>
			public string StaffId { 
				get { return GetValue("COL20153462447"); } 
				set { SetValue("COL20153462447", value); } 
			}

			/// <summary>
			/// Gets field DocFrom 
			/// </summary>
			public string DocFrom { 
				get { return GetValue("COL201534624421"); } 
				set { SetValue("COL201534624421", value); } 
			}

			/// <summary>
			/// Gets field CreatedBy 
			/// </summary>
			public string CreatedBy { 
				get { return GetValue("COL201534624414"); } 
				set { SetValue("COL201534624414", value); } 
			}

			/// <summary>
			/// Gets field BuildingId 
			/// </summary>
			public string BuildingId { 
				get { return GetValue("COL20153462442"); } 
				set { SetValue("COL20153462442", value); } 
			}

			/// <summary>
			/// Gets field Name 
			/// </summary>
			public string Name { 
				get { return GetValue("COL201534624410"); } 
				set { SetValue("COL201534624410", value); } 
			}

			/// <summary>
			/// Gets field DocTypeId 
			/// </summary>
			public string DocTypeId { 
				get { return GetValue("COL201534624418"); } 
				set { SetValue("COL201534624418", value); } 
			}


			/// <summary>
			/// Gets InOutDoc attribute data 
			/// </summary>
			public AttributeData GetInOutDocAttributeData() { 
				return GetAttributeData("COL201534624419"); 
			}

			/// <summary>
			/// Gets CustomerId attribute data 
			/// </summary>
			public AttributeData GetCustomerIdAttributeData() { 
				return GetAttributeData("COL20153462448"); 
			}

			/// <summary>
			/// Gets EquipmentId attribute data 
			/// </summary>
			public AttributeData GetEquipmentIdAttributeData() { 
				return GetAttributeData("COL20153462445"); 
			}

			/// <summary>
			/// Gets FileNamePath attribute data 
			/// </summary>
			public AttributeData GetFileNamePathAttributeData() { 
				return GetAttributeData("COL201534624411"); 
			}

			/// <summary>
			/// Gets Modified attribute data 
			/// </summary>
			public AttributeData GetModifiedAttributeData() { 
				return GetAttributeData("COL201534624415"); 
			}

			/// <summary>
			/// Gets Appeal attribute data 
			/// </summary>
			public AttributeData GetAppealAttributeData() { 
				return GetAttributeData("COL201534624420"); 
			}

			/// <summary>
			/// Gets ModifiedBy attribute data 
			/// </summary>
			public AttributeData GetModifiedByAttributeData() { 
				return GetAttributeData("COL201534624416"); 
			}

			/// <summary>
			/// Gets SuppliesId attribute data 
			/// </summary>
			public AttributeData GetSuppliesIdAttributeData() { 
				return GetAttributeData("COL20153462446"); 
			}

			/// <summary>
			/// Gets DelFlag attribute data 
			/// </summary>
			public AttributeData GetDelFlagAttributeData() { 
				return GetAttributeData("COL201534624417"); 
			}

			/// <summary>
			/// Gets ContractId attribute data 
			/// </summary>
			public AttributeData GetContractIdAttributeData() { 
				return GetAttributeData("COL20153462449"); 
			}

			/// <summary>
			/// Gets DocType attribute data 
			/// </summary>
			public AttributeData GetDocTypeAttributeData() { 
				return GetAttributeData("COL20153462443"); 
			}

			/// <summary>
			/// Gets Comment attribute data 
			/// </summary>
			public AttributeData GetCommentAttributeData() { 
				return GetAttributeData("COL201534624412"); 
			}

			/// <summary>
			/// Gets Dept attribute data 
			/// </summary>
			public AttributeData GetDeptAttributeData() { 
				return GetAttributeData("COL20153462444"); 
			}

			/// <summary>
			/// Gets Created attribute data 
			/// </summary>
			public AttributeData GetCreatedAttributeData() { 
				return GetAttributeData("COL201534624413"); 
			}

			/// <summary>
			/// Gets DocSubject attribute data 
			/// </summary>
			public AttributeData GetDocSubjectAttributeData() { 
				return GetAttributeData("COL201534624422"); 
			}

			/// <summary>
			/// Gets id attribute data 
			/// </summary>
			public AttributeData GetidAttributeData() { 
				return GetAttributeData("COL20153462441"); 
			}

			/// <summary>
			/// Gets DocDate attribute data 
			/// </summary>
			public AttributeData GetDocDateAttributeData() { 
				return GetAttributeData("COL201534624423"); 
			}

			/// <summary>
			/// Gets StaffId attribute data 
			/// </summary>
			public AttributeData GetStaffIdAttributeData() { 
				return GetAttributeData("COL20153462447"); 
			}

			/// <summary>
			/// Gets DocFrom attribute data 
			/// </summary>
			public AttributeData GetDocFromAttributeData() { 
				return GetAttributeData("COL201534624421"); 
			}

			/// <summary>
			/// Gets CreatedBy attribute data 
			/// </summary>
			public AttributeData GetCreatedByAttributeData() { 
				return GetAttributeData("COL201534624414"); 
			}

			/// <summary>
			/// Gets BuildingId attribute data 
			/// </summary>
			public AttributeData GetBuildingIdAttributeData() { 
				return GetAttributeData("COL20153462442"); 
			}

			/// <summary>
			/// Gets Name attribute data 
			/// </summary>
			public AttributeData GetNameAttributeData() { 
				return GetAttributeData("COL201534624410"); 
			}

			/// <summary>
			/// Gets DocTypeId attribute data 
			/// </summary>
			public AttributeData GetDocTypeIdAttributeData() { 
				return GetAttributeData("COL201534624418"); 
			}


			/// <summary>
			/// Gets column InOutDoc with alias  
			/// </summary>
			public string ColInOutDoc { 
				get { return GetColumnName("COL201534624419"); } 
			}

			/// <summary>
			/// Gets column CustomerId with alias  
			/// </summary>
			public string ColCustomerId { 
				get { return GetColumnName("COL20153462448"); } 
			}

			/// <summary>
			/// Gets column EquipmentId with alias  
			/// </summary>
			public string ColEquipmentId { 
				get { return GetColumnName("COL20153462445"); } 
			}

			/// <summary>
			/// Gets column FileNamePath with alias  
			/// </summary>
			public string ColFileNamePath { 
				get { return GetColumnName("COL201534624411"); } 
			}

			/// <summary>
			/// Gets column Modified with alias  
			/// </summary>
			public string ColModified { 
				get { return GetColumnName("COL201534624415"); } 
			}

			/// <summary>
			/// Gets column Appeal with alias  
			/// </summary>
			public string ColAppeal { 
				get { return GetColumnName("COL201534624420"); } 
			}

			/// <summary>
			/// Gets column ModifiedBy with alias  
			/// </summary>
			public string ColModifiedBy { 
				get { return GetColumnName("COL201534624416"); } 
			}

			/// <summary>
			/// Gets column SuppliesId with alias  
			/// </summary>
			public string ColSuppliesId { 
				get { return GetColumnName("COL20153462446"); } 
			}

			/// <summary>
			/// Gets column DelFlag with alias  
			/// </summary>
			public string ColDelFlag { 
				get { return GetColumnName("COL201534624417"); } 
			}

			/// <summary>
			/// Gets column ContractId with alias  
			/// </summary>
			public string ColContractId { 
				get { return GetColumnName("COL20153462449"); } 
			}

			/// <summary>
			/// Gets column DocType with alias  
			/// </summary>
			public string ColDocType { 
				get { return GetColumnName("COL20153462443"); } 
			}

			/// <summary>
			/// Gets column Comment with alias  
			/// </summary>
			public string ColComment { 
				get { return GetColumnName("COL201534624412"); } 
			}

			/// <summary>
			/// Gets column Dept with alias  
			/// </summary>
			public string ColDept { 
				get { return GetColumnName("COL20153462444"); } 
			}

			/// <summary>
			/// Gets column Created with alias  
			/// </summary>
			public string ColCreated { 
				get { return GetColumnName("COL201534624413"); } 
			}

			/// <summary>
			/// Gets column DocSubject with alias  
			/// </summary>
			public string ColDocSubject { 
				get { return GetColumnName("COL201534624422"); } 
			}

			/// <summary>
			/// Gets column id with alias  
			/// </summary>
			public string Colid { 
				get { return GetColumnName("COL20153462441"); } 
			}

			/// <summary>
			/// Gets column DocDate with alias  
			/// </summary>
			public string ColDocDate { 
				get { return GetColumnName("COL201534624423"); } 
			}

			/// <summary>
			/// Gets column StaffId with alias  
			/// </summary>
			public string ColStaffId { 
				get { return GetColumnName("COL20153462447"); } 
			}

			/// <summary>
			/// Gets column DocFrom with alias  
			/// </summary>
			public string ColDocFrom { 
				get { return GetColumnName("COL201534624421"); } 
			}

			/// <summary>
			/// Gets column CreatedBy with alias  
			/// </summary>
			public string ColCreatedBy { 
				get { return GetColumnName("COL201534624414"); } 
			}

			/// <summary>
			/// Gets column BuildingId with alias  
			/// </summary>
			public string ColBuildingId { 
				get { return GetColumnName("COL20153462442"); } 
			}

			/// <summary>
			/// Gets column Name with alias  
			/// </summary>
			public string ColName { 
				get { return GetColumnName("COL201534624410"); } 
			}

			/// <summary>
			/// Gets column DocTypeId with alias  
			/// </summary>
			public string ColDocTypeId { 
				get { return GetColumnName("COL201534624418"); } 
			}


			/// <summary>
			/// Checks whether column InOutDoc is added in select statement 
			/// </summary>
			public bool IsSelectInOutDoc { 
				get { return IsSelect("COL201534624419"); } 
				set { SetSelect("COL201534624419", value); } 
			}

			/// <summary>
			/// Checks whether column CustomerId is added in select statement 
			/// </summary>
			public bool IsSelectCustomerId { 
				get { return IsSelect("COL20153462448"); } 
				set { SetSelect("COL20153462448", value); } 
			}

			/// <summary>
			/// Checks whether column EquipmentId is added in select statement 
			/// </summary>
			public bool IsSelectEquipmentId { 
				get { return IsSelect("COL20153462445"); } 
				set { SetSelect("COL20153462445", value); } 
			}

			/// <summary>
			/// Checks whether column FileNamePath is added in select statement 
			/// </summary>
			public bool IsSelectFileNamePath { 
				get { return IsSelect("COL201534624411"); } 
				set { SetSelect("COL201534624411", value); } 
			}

			/// <summary>
			/// Checks whether column Modified is added in select statement 
			/// </summary>
			public bool IsSelectModified { 
				get { return IsSelect("COL201534624415"); } 
				set { SetSelect("COL201534624415", value); } 
			}

			/// <summary>
			/// Checks whether column Appeal is added in select statement 
			/// </summary>
			public bool IsSelectAppeal { 
				get { return IsSelect("COL201534624420"); } 
				set { SetSelect("COL201534624420", value); } 
			}

			/// <summary>
			/// Checks whether column ModifiedBy is added in select statement 
			/// </summary>
			public bool IsSelectModifiedBy { 
				get { return IsSelect("COL201534624416"); } 
				set { SetSelect("COL201534624416", value); } 
			}

			/// <summary>
			/// Checks whether column SuppliesId is added in select statement 
			/// </summary>
			public bool IsSelectSuppliesId { 
				get { return IsSelect("COL20153462446"); } 
				set { SetSelect("COL20153462446", value); } 
			}

			/// <summary>
			/// Checks whether column DelFlag is added in select statement 
			/// </summary>
			public bool IsSelectDelFlag { 
				get { return IsSelect("COL201534624417"); } 
				set { SetSelect("COL201534624417", value); } 
			}

			/// <summary>
			/// Checks whether column ContractId is added in select statement 
			/// </summary>
			public bool IsSelectContractId { 
				get { return IsSelect("COL20153462449"); } 
				set { SetSelect("COL20153462449", value); } 
			}

			/// <summary>
			/// Checks whether column DocType is added in select statement 
			/// </summary>
			public bool IsSelectDocType { 
				get { return IsSelect("COL20153462443"); } 
				set { SetSelect("COL20153462443", value); } 
			}

			/// <summary>
			/// Checks whether column Comment is added in select statement 
			/// </summary>
			public bool IsSelectComment { 
				get { return IsSelect("COL201534624412"); } 
				set { SetSelect("COL201534624412", value); } 
			}

			/// <summary>
			/// Checks whether column Dept is added in select statement 
			/// </summary>
			public bool IsSelectDept { 
				get { return IsSelect("COL20153462444"); } 
				set { SetSelect("COL20153462444", value); } 
			}

			/// <summary>
			/// Checks whether column Created is added in select statement 
			/// </summary>
			public bool IsSelectCreated { 
				get { return IsSelect("COL201534624413"); } 
				set { SetSelect("COL201534624413", value); } 
			}

			/// <summary>
			/// Checks whether column DocSubject is added in select statement 
			/// </summary>
			public bool IsSelectDocSubject { 
				get { return IsSelect("COL201534624422"); } 
				set { SetSelect("COL201534624422", value); } 
			}

			/// <summary>
			/// Checks whether column id is added in select statement 
			/// </summary>
			public bool IsSelectid { 
				get { return IsSelect("COL20153462441"); } 
				set { SetSelect("COL20153462441", value); } 
			}

			/// <summary>
			/// Checks whether column DocDate is added in select statement 
			/// </summary>
			public bool IsSelectDocDate { 
				get { return IsSelect("COL201534624423"); } 
				set { SetSelect("COL201534624423", value); } 
			}

			/// <summary>
			/// Checks whether column StaffId is added in select statement 
			/// </summary>
			public bool IsSelectStaffId { 
				get { return IsSelect("COL20153462447"); } 
				set { SetSelect("COL20153462447", value); } 
			}

			/// <summary>
			/// Checks whether column DocFrom is added in select statement 
			/// </summary>
			public bool IsSelectDocFrom { 
				get { return IsSelect("COL201534624421"); } 
				set { SetSelect("COL201534624421", value); } 
			}

			/// <summary>
			/// Checks whether column CreatedBy is added in select statement 
			/// </summary>
			public bool IsSelectCreatedBy { 
				get { return IsSelect("COL201534624414"); } 
				set { SetSelect("COL201534624414", value); } 
			}

			/// <summary>
			/// Checks whether column BuildingId is added in select statement 
			/// </summary>
			public bool IsSelectBuildingId { 
				get { return IsSelect("COL20153462442"); } 
				set { SetSelect("COL20153462442", value); } 
			}

			/// <summary>
			/// Checks whether column Name is added in select statement 
			/// </summary>
			public bool IsSelectName { 
				get { return IsSelect("COL201534624410"); } 
				set { SetSelect("COL201534624410", value); } 
			}

			/// <summary>
			/// Checks whether column DocTypeId is added in select statement 
			/// </summary>
			public bool IsSelectDocTypeId { 
				get { return IsSelect("COL201534624418"); } 
				set { SetSelect("COL201534624418", value); } 
			}



	}
}