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
	public class RentContractData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ760389778";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of RentContract 
			/// </summary>
			public RentContractData(string objectID): base(objectID) {}  

			public RentContractData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field BycParkingMount 
			/// </summary>
			public string BycParkingMount { 
				get { return GetValue("COL76038977816"); } 
				set { SetValue("COL76038977816", value); } 
			}

			/// <summary>
			/// Gets field DelFlag 
			/// </summary>
			public string DelFlag { 
				get { return GetValue("COL76038977813"); } 
				set { SetValue("COL76038977813", value); } 
			}

			/// <summary>
			/// Gets field CarParkingMount 
			/// </summary>
			public string CarParkingMount { 
				get { return GetValue("COL76038977814"); } 
				set { SetValue("COL76038977814", value); } 
			}

			/// <summary>
			/// Gets field Modified 
			/// </summary>
			public string Modified { 
				get { return GetValue("COL76038977811"); } 
				set { SetValue("COL76038977811", value); } 
			}

			/// <summary>
			/// Gets field ModifiedBy 
			/// </summary>
			public string ModifiedBy { 
				get { return GetValue("COL76038977812"); } 
				set { SetValue("COL76038977812", value); } 
			}

			/// <summary>
			/// Gets field CustomerId 
			/// </summary>
			public string CustomerId { 
				get { return GetValue("COL7603897783"); } 
				set { SetValue("COL7603897783", value); } 
			}

			/// <summary>
			/// Gets field BuildingId 
			/// </summary>
			public string BuildingId { 
				get { return GetValue("COL7603897782"); } 
				set { SetValue("COL7603897782", value); } 
			}

			/// <summary>
			/// Gets field ContractId 
			/// </summary>
			public string ContractId { 
				get { return GetValue("COL7603897781"); } 
				set { SetValue("COL7603897781", value); } 
			}

			/// <summary>
			/// Gets field StaffMount 
			/// </summary>
			public string StaffMount { 
				get { return GetValue("COL7603897787"); } 
				set { SetValue("COL7603897787", value); } 
			}

			/// <summary>
			/// Gets field ReceiveDate 
			/// </summary>
			public string ReceiveDate { 
				get { return GetValue("COL7603897786"); } 
				set { SetValue("COL7603897786", value); } 
			}

			/// <summary>
			/// Gets field ContractEndDate 
			/// </summary>
			public string ContractEndDate { 
				get { return GetValue("COL7603897785"); } 
				set { SetValue("COL7603897785", value); } 
			}

			/// <summary>
			/// Gets field ContractDate 
			/// </summary>
			public string ContractDate { 
				get { return GetValue("COL7603897784"); } 
				set { SetValue("COL7603897784", value); } 
			}

			/// <summary>
			/// Gets field CreatedBy 
			/// </summary>
			public string CreatedBy { 
				get { return GetValue("COL76038977810"); } 
				set { SetValue("COL76038977810", value); } 
			}

			/// <summary>
			/// Gets field Created 
			/// </summary>
			public string Created { 
				get { return GetValue("COL7603897789"); } 
				set { SetValue("COL7603897789", value); } 
			}

			/// <summary>
			/// Gets field Comment 
			/// </summary>
			public string Comment { 
				get { return GetValue("COL7603897788"); } 
				set { SetValue("COL7603897788", value); } 
			}

			/// <summary>
			/// Gets field MotorParkingMount 
			/// </summary>
			public string MotorParkingMount { 
				get { return GetValue("COL76038977815"); } 
				set { SetValue("COL76038977815", value); } 
			}

			/// <summary>
			/// Gets field ContractNo 
			/// </summary>
			public string ContractNo { 
				get { return GetValue("COL76038977817"); } 
				set { SetValue("COL76038977817", value); } 
			}


			/// <summary>
			/// Gets BycParkingMount attribute data 
			/// </summary>
			public AttributeData GetBycParkingMountAttributeData() { 
				return GetAttributeData("COL76038977816"); 
			}

			/// <summary>
			/// Gets DelFlag attribute data 
			/// </summary>
			public AttributeData GetDelFlagAttributeData() { 
				return GetAttributeData("COL76038977813"); 
			}

			/// <summary>
			/// Gets CarParkingMount attribute data 
			/// </summary>
			public AttributeData GetCarParkingMountAttributeData() { 
				return GetAttributeData("COL76038977814"); 
			}

			/// <summary>
			/// Gets Modified attribute data 
			/// </summary>
			public AttributeData GetModifiedAttributeData() { 
				return GetAttributeData("COL76038977811"); 
			}

			/// <summary>
			/// Gets ModifiedBy attribute data 
			/// </summary>
			public AttributeData GetModifiedByAttributeData() { 
				return GetAttributeData("COL76038977812"); 
			}

			/// <summary>
			/// Gets CustomerId attribute data 
			/// </summary>
			public AttributeData GetCustomerIdAttributeData() { 
				return GetAttributeData("COL7603897783"); 
			}

			/// <summary>
			/// Gets BuildingId attribute data 
			/// </summary>
			public AttributeData GetBuildingIdAttributeData() { 
				return GetAttributeData("COL7603897782"); 
			}

			/// <summary>
			/// Gets ContractId attribute data 
			/// </summary>
			public AttributeData GetContractIdAttributeData() { 
				return GetAttributeData("COL7603897781"); 
			}

			/// <summary>
			/// Gets StaffMount attribute data 
			/// </summary>
			public AttributeData GetStaffMountAttributeData() { 
				return GetAttributeData("COL7603897787"); 
			}

			/// <summary>
			/// Gets ReceiveDate attribute data 
			/// </summary>
			public AttributeData GetReceiveDateAttributeData() { 
				return GetAttributeData("COL7603897786"); 
			}

			/// <summary>
			/// Gets ContractEndDate attribute data 
			/// </summary>
			public AttributeData GetContractEndDateAttributeData() { 
				return GetAttributeData("COL7603897785"); 
			}

			/// <summary>
			/// Gets ContractDate attribute data 
			/// </summary>
			public AttributeData GetContractDateAttributeData() { 
				return GetAttributeData("COL7603897784"); 
			}

			/// <summary>
			/// Gets CreatedBy attribute data 
			/// </summary>
			public AttributeData GetCreatedByAttributeData() { 
				return GetAttributeData("COL76038977810"); 
			}

			/// <summary>
			/// Gets Created attribute data 
			/// </summary>
			public AttributeData GetCreatedAttributeData() { 
				return GetAttributeData("COL7603897789"); 
			}

			/// <summary>
			/// Gets Comment attribute data 
			/// </summary>
			public AttributeData GetCommentAttributeData() { 
				return GetAttributeData("COL7603897788"); 
			}

			/// <summary>
			/// Gets MotorParkingMount attribute data 
			/// </summary>
			public AttributeData GetMotorParkingMountAttributeData() { 
				return GetAttributeData("COL76038977815"); 
			}

			/// <summary>
			/// Gets ContractNo attribute data 
			/// </summary>
			public AttributeData GetContractNoAttributeData() { 
				return GetAttributeData("COL76038977817"); 
			}


			/// <summary>
			/// Gets column BycParkingMount with alias  
			/// </summary>
			public string ColBycParkingMount { 
				get { return GetColumnName("COL76038977816"); } 
			}

			/// <summary>
			/// Gets column DelFlag with alias  
			/// </summary>
			public string ColDelFlag { 
				get { return GetColumnName("COL76038977813"); } 
			}

			/// <summary>
			/// Gets column CarParkingMount with alias  
			/// </summary>
			public string ColCarParkingMount { 
				get { return GetColumnName("COL76038977814"); } 
			}

			/// <summary>
			/// Gets column Modified with alias  
			/// </summary>
			public string ColModified { 
				get { return GetColumnName("COL76038977811"); } 
			}

			/// <summary>
			/// Gets column ModifiedBy with alias  
			/// </summary>
			public string ColModifiedBy { 
				get { return GetColumnName("COL76038977812"); } 
			}

			/// <summary>
			/// Gets column CustomerId with alias  
			/// </summary>
			public string ColCustomerId { 
				get { return GetColumnName("COL7603897783"); } 
			}

			/// <summary>
			/// Gets column BuildingId with alias  
			/// </summary>
			public string ColBuildingId { 
				get { return GetColumnName("COL7603897782"); } 
			}

			/// <summary>
			/// Gets column ContractId with alias  
			/// </summary>
			public string ColContractId { 
				get { return GetColumnName("COL7603897781"); } 
			}

			/// <summary>
			/// Gets column StaffMount with alias  
			/// </summary>
			public string ColStaffMount { 
				get { return GetColumnName("COL7603897787"); } 
			}

			/// <summary>
			/// Gets column ReceiveDate with alias  
			/// </summary>
			public string ColReceiveDate { 
				get { return GetColumnName("COL7603897786"); } 
			}

			/// <summary>
			/// Gets column ContractEndDate with alias  
			/// </summary>
			public string ColContractEndDate { 
				get { return GetColumnName("COL7603897785"); } 
			}

			/// <summary>
			/// Gets column ContractDate with alias  
			/// </summary>
			public string ColContractDate { 
				get { return GetColumnName("COL7603897784"); } 
			}

			/// <summary>
			/// Gets column CreatedBy with alias  
			/// </summary>
			public string ColCreatedBy { 
				get { return GetColumnName("COL76038977810"); } 
			}

			/// <summary>
			/// Gets column Created with alias  
			/// </summary>
			public string ColCreated { 
				get { return GetColumnName("COL7603897789"); } 
			}

			/// <summary>
			/// Gets column Comment with alias  
			/// </summary>
			public string ColComment { 
				get { return GetColumnName("COL7603897788"); } 
			}

			/// <summary>
			/// Gets column MotorParkingMount with alias  
			/// </summary>
			public string ColMotorParkingMount { 
				get { return GetColumnName("COL76038977815"); } 
			}

			/// <summary>
			/// Gets column ContractNo with alias  
			/// </summary>
			public string ColContractNo { 
				get { return GetColumnName("COL76038977817"); } 
			}


			/// <summary>
			/// Checks whether column BycParkingMount is added in select statement 
			/// </summary>
			public bool IsSelectBycParkingMount { 
				get { return IsSelect("COL76038977816"); } 
				set { SetSelect("COL76038977816", value); } 
			}

			/// <summary>
			/// Checks whether column DelFlag is added in select statement 
			/// </summary>
			public bool IsSelectDelFlag { 
				get { return IsSelect("COL76038977813"); } 
				set { SetSelect("COL76038977813", value); } 
			}

			/// <summary>
			/// Checks whether column CarParkingMount is added in select statement 
			/// </summary>
			public bool IsSelectCarParkingMount { 
				get { return IsSelect("COL76038977814"); } 
				set { SetSelect("COL76038977814", value); } 
			}

			/// <summary>
			/// Checks whether column Modified is added in select statement 
			/// </summary>
			public bool IsSelectModified { 
				get { return IsSelect("COL76038977811"); } 
				set { SetSelect("COL76038977811", value); } 
			}

			/// <summary>
			/// Checks whether column ModifiedBy is added in select statement 
			/// </summary>
			public bool IsSelectModifiedBy { 
				get { return IsSelect("COL76038977812"); } 
				set { SetSelect("COL76038977812", value); } 
			}

			/// <summary>
			/// Checks whether column CustomerId is added in select statement 
			/// </summary>
			public bool IsSelectCustomerId { 
				get { return IsSelect("COL7603897783"); } 
				set { SetSelect("COL7603897783", value); } 
			}

			/// <summary>
			/// Checks whether column BuildingId is added in select statement 
			/// </summary>
			public bool IsSelectBuildingId { 
				get { return IsSelect("COL7603897782"); } 
				set { SetSelect("COL7603897782", value); } 
			}

			/// <summary>
			/// Checks whether column ContractId is added in select statement 
			/// </summary>
			public bool IsSelectContractId { 
				get { return IsSelect("COL7603897781"); } 
				set { SetSelect("COL7603897781", value); } 
			}

			/// <summary>
			/// Checks whether column StaffMount is added in select statement 
			/// </summary>
			public bool IsSelectStaffMount { 
				get { return IsSelect("COL7603897787"); } 
				set { SetSelect("COL7603897787", value); } 
			}

			/// <summary>
			/// Checks whether column ReceiveDate is added in select statement 
			/// </summary>
			public bool IsSelectReceiveDate { 
				get { return IsSelect("COL7603897786"); } 
				set { SetSelect("COL7603897786", value); } 
			}

			/// <summary>
			/// Checks whether column ContractEndDate is added in select statement 
			/// </summary>
			public bool IsSelectContractEndDate { 
				get { return IsSelect("COL7603897785"); } 
				set { SetSelect("COL7603897785", value); } 
			}

			/// <summary>
			/// Checks whether column ContractDate is added in select statement 
			/// </summary>
			public bool IsSelectContractDate { 
				get { return IsSelect("COL7603897784"); } 
				set { SetSelect("COL7603897784", value); } 
			}

			/// <summary>
			/// Checks whether column CreatedBy is added in select statement 
			/// </summary>
			public bool IsSelectCreatedBy { 
				get { return IsSelect("COL76038977810"); } 
				set { SetSelect("COL76038977810", value); } 
			}

			/// <summary>
			/// Checks whether column Created is added in select statement 
			/// </summary>
			public bool IsSelectCreated { 
				get { return IsSelect("COL7603897789"); } 
				set { SetSelect("COL7603897789", value); } 
			}

			/// <summary>
			/// Checks whether column Comment is added in select statement 
			/// </summary>
			public bool IsSelectComment { 
				get { return IsSelect("COL7603897788"); } 
				set { SetSelect("COL7603897788", value); } 
			}

			/// <summary>
			/// Checks whether column MotorParkingMount is added in select statement 
			/// </summary>
			public bool IsSelectMotorParkingMount { 
				get { return IsSelect("COL76038977815"); } 
				set { SetSelect("COL76038977815", value); } 
			}

			/// <summary>
			/// Checks whether column ContractNo is added in select statement 
			/// </summary>
			public bool IsSelectContractNo { 
				get { return IsSelect("COL76038977817"); } 
				set { SetSelect("COL76038977817", value); } 
			}



	}
}