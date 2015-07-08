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
	public class PaymentYearMonthC0401201211Data : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ1032390747";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of PaymentYearMonthC0401201211 
			/// </summary>
			public PaymentYearMonthC0401201211Data(string objectID): base(objectID) {}  

			public PaymentYearMonthC0401201211Data() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field ElecPaidDate 
			/// </summary>
			public string ElecPaidDate { 
				get { return GetValue("COL103239074728"); } 
				set { SetValue("COL103239074728", value); } 
			}

			/// <summary>
			/// Gets field Creator 
			/// </summary>
			public string Creator { 
				get { return GetValue("COL103239074713"); } 
				set { SetValue("COL103239074713", value); } 
			}

			/// <summary>
			/// Gets field FlatID 
			/// </summary>
			public string FlatID { 
				get { return GetValue("COL10323907472"); } 
				set { SetValue("COL10323907472", value); } 
			}

			/// <summary>
			/// Gets field DelFlag 
			/// </summary>
			public string DelFlag { 
				get { return GetValue("COL103239074711"); } 
				set { SetValue("COL103239074711", value); } 
			}

			/// <summary>
			/// Gets field TenementID 
			/// </summary>
			public string TenementID { 
				get { return GetValue("COL103239074716"); } 
				set { SetValue("COL103239074716", value); } 
			}

			/// <summary>
			/// Gets field WaterFeePaid 
			/// </summary>
			public string WaterFeePaid { 
				get { return GetValue("COL103239074721"); } 
				set { SetValue("COL103239074721", value); } 
			}

			/// <summary>
			/// Gets field OtherFee 
			/// </summary>
			public string OtherFee { 
				get { return GetValue("COL10323907477"); } 
				set { SetValue("COL10323907477", value); } 
			}

			/// <summary>
			/// Gets field ElecFeePaid 
			/// </summary>
			public string ElecFeePaid { 
				get { return GetValue("COL103239074723"); } 
				set { SetValue("COL103239074723", value); } 
			}

			/// <summary>
			/// Gets field Created 
			/// </summary>
			public string Created { 
				get { return GetValue("COL103239074712"); } 
				set { SetValue("COL103239074712", value); } 
			}

			/// <summary>
			/// Gets field PayMoney 
			/// </summary>
			public string PayMoney { 
				get { return GetValue("COL10323907478"); } 
				set { SetValue("COL10323907478", value); } 
			}

			/// <summary>
			/// Gets field OtherFeePaid 
			/// </summary>
			public string OtherFeePaid { 
				get { return GetValue("COL103239074722"); } 
				set { SetValue("COL103239074722", value); } 
			}

			/// <summary>
			/// Gets field Updator 
			/// </summary>
			public string Updator { 
				get { return GetValue("COL103239074715"); } 
				set { SetValue("COL103239074715", value); } 
			}

			/// <summary>
			/// Gets field ManagerFeePaid 
			/// </summary>
			public string ManagerFeePaid { 
				get { return GetValue("COL103239074719"); } 
				set { SetValue("COL103239074719", value); } 
			}

			/// <summary>
			/// Gets field LossAvg 
			/// </summary>
			public string LossAvg { 
				get { return GetValue("COL103239074717"); } 
				set { SetValue("COL103239074717", value); } 
			}

			/// <summary>
			/// Gets field PackingFee 
			/// </summary>
			public string PackingFee { 
				get { return GetValue("COL10323907475"); } 
				set { SetValue("COL10323907475", value); } 
			}

			/// <summary>
			/// Gets field PackingPaidDate 
			/// </summary>
			public string PackingPaidDate { 
				get { return GetValue("COL103239074725"); } 
				set { SetValue("COL103239074725", value); } 
			}

			/// <summary>
			/// Gets field ManagerBillNo 
			/// </summary>
			public string ManagerBillNo { 
				get { return GetValue("COL103239074729"); } 
				set { SetValue("COL103239074729", value); } 
			}

			/// <summary>
			/// Gets field OtherPaidDate 
			/// </summary>
			public string OtherPaidDate { 
				get { return GetValue("COL103239074727"); } 
				set { SetValue("COL103239074727", value); } 
			}

			/// <summary>
			/// Gets field WaterFee 
			/// </summary>
			public string WaterFee { 
				get { return GetValue("COL10323907476"); } 
				set { SetValue("COL10323907476", value); } 
			}

			/// <summary>
			/// Gets field WaterPaidDate 
			/// </summary>
			public string WaterPaidDate { 
				get { return GetValue("COL103239074726"); } 
				set { SetValue("COL103239074726", value); } 
			}

			/// <summary>
			/// Gets field PackingFeePaid 
			/// </summary>
			public string PackingFeePaid { 
				get { return GetValue("COL103239074720"); } 
				set { SetValue("COL103239074720", value); } 
			}

			/// <summary>
			/// Gets field YearMonth 
			/// </summary>
			public string YearMonth { 
				get { return GetValue("COL10323907473"); } 
				set { SetValue("COL10323907473", value); } 
			}

			/// <summary>
			/// Gets field Comment 
			/// </summary>
			public string Comment { 
				get { return GetValue("COL103239074710"); } 
				set { SetValue("COL103239074710", value); } 
			}

			/// <summary>
			/// Gets field PackingBillNo 
			/// </summary>
			public string PackingBillNo { 
				get { return GetValue("COL103239074730"); } 
				set { SetValue("COL103239074730", value); } 
			}

			/// <summary>
			/// Gets field ManagerFee 
			/// </summary>
			public string ManagerFee { 
				get { return GetValue("COL10323907474"); } 
				set { SetValue("COL10323907474", value); } 
			}

			/// <summary>
			/// Gets field ElecBillNo 
			/// </summary>
			public string ElecBillNo { 
				get { return GetValue("COL103239074733"); } 
				set { SetValue("COL103239074733", value); } 
			}

			/// <summary>
			/// Gets field Updated 
			/// </summary>
			public string Updated { 
				get { return GetValue("COL103239074714"); } 
				set { SetValue("COL103239074714", value); } 
			}

			/// <summary>
			/// Gets field PaidMoney 
			/// </summary>
			public string PaidMoney { 
				get { return GetValue("COL10323907479"); } 
				set { SetValue("COL10323907479", value); } 
			}

			/// <summary>
			/// Gets field ElecFee 
			/// </summary>
			public string ElecFee { 
				get { return GetValue("COL103239074718"); } 
				set { SetValue("COL103239074718", value); } 
			}

			/// <summary>
			/// Gets field OtherBillNo 
			/// </summary>
			public string OtherBillNo { 
				get { return GetValue("COL103239074732"); } 
				set { SetValue("COL103239074732", value); } 
			}

			/// <summary>
			/// Gets field ID 
			/// </summary>
			public string ID { 
				get { return GetValue("COL10323907471"); } 
				set { SetValue("COL10323907471", value); } 
			}

			/// <summary>
			/// Gets field WaterBillNo 
			/// </summary>
			public string WaterBillNo { 
				get { return GetValue("COL103239074731"); } 
				set { SetValue("COL103239074731", value); } 
			}

			/// <summary>
			/// Gets field ManagerPaidDate 
			/// </summary>
			public string ManagerPaidDate { 
				get { return GetValue("COL103239074724"); } 
				set { SetValue("COL103239074724", value); } 
			}


			/// <summary>
			/// Gets ElecPaidDate attribute data 
			/// </summary>
			public AttributeData GetElecPaidDateAttributeData() { 
				return GetAttributeData("COL103239074728"); 
			}

			/// <summary>
			/// Gets Creator attribute data 
			/// </summary>
			public AttributeData GetCreatorAttributeData() { 
				return GetAttributeData("COL103239074713"); 
			}

			/// <summary>
			/// Gets FlatID attribute data 
			/// </summary>
			public AttributeData GetFlatIDAttributeData() { 
				return GetAttributeData("COL10323907472"); 
			}

			/// <summary>
			/// Gets DelFlag attribute data 
			/// </summary>
			public AttributeData GetDelFlagAttributeData() { 
				return GetAttributeData("COL103239074711"); 
			}

			/// <summary>
			/// Gets TenementID attribute data 
			/// </summary>
			public AttributeData GetTenementIDAttributeData() { 
				return GetAttributeData("COL103239074716"); 
			}

			/// <summary>
			/// Gets WaterFeePaid attribute data 
			/// </summary>
			public AttributeData GetWaterFeePaidAttributeData() { 
				return GetAttributeData("COL103239074721"); 
			}

			/// <summary>
			/// Gets OtherFee attribute data 
			/// </summary>
			public AttributeData GetOtherFeeAttributeData() { 
				return GetAttributeData("COL10323907477"); 
			}

			/// <summary>
			/// Gets ElecFeePaid attribute data 
			/// </summary>
			public AttributeData GetElecFeePaidAttributeData() { 
				return GetAttributeData("COL103239074723"); 
			}

			/// <summary>
			/// Gets Created attribute data 
			/// </summary>
			public AttributeData GetCreatedAttributeData() { 
				return GetAttributeData("COL103239074712"); 
			}

			/// <summary>
			/// Gets PayMoney attribute data 
			/// </summary>
			public AttributeData GetPayMoneyAttributeData() { 
				return GetAttributeData("COL10323907478"); 
			}

			/// <summary>
			/// Gets OtherFeePaid attribute data 
			/// </summary>
			public AttributeData GetOtherFeePaidAttributeData() { 
				return GetAttributeData("COL103239074722"); 
			}

			/// <summary>
			/// Gets Updator attribute data 
			/// </summary>
			public AttributeData GetUpdatorAttributeData() { 
				return GetAttributeData("COL103239074715"); 
			}

			/// <summary>
			/// Gets ManagerFeePaid attribute data 
			/// </summary>
			public AttributeData GetManagerFeePaidAttributeData() { 
				return GetAttributeData("COL103239074719"); 
			}

			/// <summary>
			/// Gets LossAvg attribute data 
			/// </summary>
			public AttributeData GetLossAvgAttributeData() { 
				return GetAttributeData("COL103239074717"); 
			}

			/// <summary>
			/// Gets PackingFee attribute data 
			/// </summary>
			public AttributeData GetPackingFeeAttributeData() { 
				return GetAttributeData("COL10323907475"); 
			}

			/// <summary>
			/// Gets PackingPaidDate attribute data 
			/// </summary>
			public AttributeData GetPackingPaidDateAttributeData() { 
				return GetAttributeData("COL103239074725"); 
			}

			/// <summary>
			/// Gets ManagerBillNo attribute data 
			/// </summary>
			public AttributeData GetManagerBillNoAttributeData() { 
				return GetAttributeData("COL103239074729"); 
			}

			/// <summary>
			/// Gets OtherPaidDate attribute data 
			/// </summary>
			public AttributeData GetOtherPaidDateAttributeData() { 
				return GetAttributeData("COL103239074727"); 
			}

			/// <summary>
			/// Gets WaterFee attribute data 
			/// </summary>
			public AttributeData GetWaterFeeAttributeData() { 
				return GetAttributeData("COL10323907476"); 
			}

			/// <summary>
			/// Gets WaterPaidDate attribute data 
			/// </summary>
			public AttributeData GetWaterPaidDateAttributeData() { 
				return GetAttributeData("COL103239074726"); 
			}

			/// <summary>
			/// Gets PackingFeePaid attribute data 
			/// </summary>
			public AttributeData GetPackingFeePaidAttributeData() { 
				return GetAttributeData("COL103239074720"); 
			}

			/// <summary>
			/// Gets YearMonth attribute data 
			/// </summary>
			public AttributeData GetYearMonthAttributeData() { 
				return GetAttributeData("COL10323907473"); 
			}

			/// <summary>
			/// Gets Comment attribute data 
			/// </summary>
			public AttributeData GetCommentAttributeData() { 
				return GetAttributeData("COL103239074710"); 
			}

			/// <summary>
			/// Gets PackingBillNo attribute data 
			/// </summary>
			public AttributeData GetPackingBillNoAttributeData() { 
				return GetAttributeData("COL103239074730"); 
			}

			/// <summary>
			/// Gets ManagerFee attribute data 
			/// </summary>
			public AttributeData GetManagerFeeAttributeData() { 
				return GetAttributeData("COL10323907474"); 
			}

			/// <summary>
			/// Gets ElecBillNo attribute data 
			/// </summary>
			public AttributeData GetElecBillNoAttributeData() { 
				return GetAttributeData("COL103239074733"); 
			}

			/// <summary>
			/// Gets Updated attribute data 
			/// </summary>
			public AttributeData GetUpdatedAttributeData() { 
				return GetAttributeData("COL103239074714"); 
			}

			/// <summary>
			/// Gets PaidMoney attribute data 
			/// </summary>
			public AttributeData GetPaidMoneyAttributeData() { 
				return GetAttributeData("COL10323907479"); 
			}

			/// <summary>
			/// Gets ElecFee attribute data 
			/// </summary>
			public AttributeData GetElecFeeAttributeData() { 
				return GetAttributeData("COL103239074718"); 
			}

			/// <summary>
			/// Gets OtherBillNo attribute data 
			/// </summary>
			public AttributeData GetOtherBillNoAttributeData() { 
				return GetAttributeData("COL103239074732"); 
			}

			/// <summary>
			/// Gets ID attribute data 
			/// </summary>
			public AttributeData GetIDAttributeData() { 
				return GetAttributeData("COL10323907471"); 
			}

			/// <summary>
			/// Gets WaterBillNo attribute data 
			/// </summary>
			public AttributeData GetWaterBillNoAttributeData() { 
				return GetAttributeData("COL103239074731"); 
			}

			/// <summary>
			/// Gets ManagerPaidDate attribute data 
			/// </summary>
			public AttributeData GetManagerPaidDateAttributeData() { 
				return GetAttributeData("COL103239074724"); 
			}


			/// <summary>
			/// Gets column ElecPaidDate with alias  
			/// </summary>
			public string ColElecPaidDate { 
				get { return GetColumnName("COL103239074728"); } 
			}

			/// <summary>
			/// Gets column Creator with alias  
			/// </summary>
			public string ColCreator { 
				get { return GetColumnName("COL103239074713"); } 
			}

			/// <summary>
			/// Gets column FlatID with alias  
			/// </summary>
			public string ColFlatID { 
				get { return GetColumnName("COL10323907472"); } 
			}

			/// <summary>
			/// Gets column DelFlag with alias  
			/// </summary>
			public string ColDelFlag { 
				get { return GetColumnName("COL103239074711"); } 
			}

			/// <summary>
			/// Gets column TenementID with alias  
			/// </summary>
			public string ColTenementID { 
				get { return GetColumnName("COL103239074716"); } 
			}

			/// <summary>
			/// Gets column WaterFeePaid with alias  
			/// </summary>
			public string ColWaterFeePaid { 
				get { return GetColumnName("COL103239074721"); } 
			}

			/// <summary>
			/// Gets column OtherFee with alias  
			/// </summary>
			public string ColOtherFee { 
				get { return GetColumnName("COL10323907477"); } 
			}

			/// <summary>
			/// Gets column ElecFeePaid with alias  
			/// </summary>
			public string ColElecFeePaid { 
				get { return GetColumnName("COL103239074723"); } 
			}

			/// <summary>
			/// Gets column Created with alias  
			/// </summary>
			public string ColCreated { 
				get { return GetColumnName("COL103239074712"); } 
			}

			/// <summary>
			/// Gets column PayMoney with alias  
			/// </summary>
			public string ColPayMoney { 
				get { return GetColumnName("COL10323907478"); } 
			}

			/// <summary>
			/// Gets column OtherFeePaid with alias  
			/// </summary>
			public string ColOtherFeePaid { 
				get { return GetColumnName("COL103239074722"); } 
			}

			/// <summary>
			/// Gets column Updator with alias  
			/// </summary>
			public string ColUpdator { 
				get { return GetColumnName("COL103239074715"); } 
			}

			/// <summary>
			/// Gets column ManagerFeePaid with alias  
			/// </summary>
			public string ColManagerFeePaid { 
				get { return GetColumnName("COL103239074719"); } 
			}

			/// <summary>
			/// Gets column LossAvg with alias  
			/// </summary>
			public string ColLossAvg { 
				get { return GetColumnName("COL103239074717"); } 
			}

			/// <summary>
			/// Gets column PackingFee with alias  
			/// </summary>
			public string ColPackingFee { 
				get { return GetColumnName("COL10323907475"); } 
			}

			/// <summary>
			/// Gets column PackingPaidDate with alias  
			/// </summary>
			public string ColPackingPaidDate { 
				get { return GetColumnName("COL103239074725"); } 
			}

			/// <summary>
			/// Gets column ManagerBillNo with alias  
			/// </summary>
			public string ColManagerBillNo { 
				get { return GetColumnName("COL103239074729"); } 
			}

			/// <summary>
			/// Gets column OtherPaidDate with alias  
			/// </summary>
			public string ColOtherPaidDate { 
				get { return GetColumnName("COL103239074727"); } 
			}

			/// <summary>
			/// Gets column WaterFee with alias  
			/// </summary>
			public string ColWaterFee { 
				get { return GetColumnName("COL10323907476"); } 
			}

			/// <summary>
			/// Gets column WaterPaidDate with alias  
			/// </summary>
			public string ColWaterPaidDate { 
				get { return GetColumnName("COL103239074726"); } 
			}

			/// <summary>
			/// Gets column PackingFeePaid with alias  
			/// </summary>
			public string ColPackingFeePaid { 
				get { return GetColumnName("COL103239074720"); } 
			}

			/// <summary>
			/// Gets column YearMonth with alias  
			/// </summary>
			public string ColYearMonth { 
				get { return GetColumnName("COL10323907473"); } 
			}

			/// <summary>
			/// Gets column Comment with alias  
			/// </summary>
			public string ColComment { 
				get { return GetColumnName("COL103239074710"); } 
			}

			/// <summary>
			/// Gets column PackingBillNo with alias  
			/// </summary>
			public string ColPackingBillNo { 
				get { return GetColumnName("COL103239074730"); } 
			}

			/// <summary>
			/// Gets column ManagerFee with alias  
			/// </summary>
			public string ColManagerFee { 
				get { return GetColumnName("COL10323907474"); } 
			}

			/// <summary>
			/// Gets column ElecBillNo with alias  
			/// </summary>
			public string ColElecBillNo { 
				get { return GetColumnName("COL103239074733"); } 
			}

			/// <summary>
			/// Gets column Updated with alias  
			/// </summary>
			public string ColUpdated { 
				get { return GetColumnName("COL103239074714"); } 
			}

			/// <summary>
			/// Gets column PaidMoney with alias  
			/// </summary>
			public string ColPaidMoney { 
				get { return GetColumnName("COL10323907479"); } 
			}

			/// <summary>
			/// Gets column ElecFee with alias  
			/// </summary>
			public string ColElecFee { 
				get { return GetColumnName("COL103239074718"); } 
			}

			/// <summary>
			/// Gets column OtherBillNo with alias  
			/// </summary>
			public string ColOtherBillNo { 
				get { return GetColumnName("COL103239074732"); } 
			}

			/// <summary>
			/// Gets column ID with alias  
			/// </summary>
			public string ColID { 
				get { return GetColumnName("COL10323907471"); } 
			}

			/// <summary>
			/// Gets column WaterBillNo with alias  
			/// </summary>
			public string ColWaterBillNo { 
				get { return GetColumnName("COL103239074731"); } 
			}

			/// <summary>
			/// Gets column ManagerPaidDate with alias  
			/// </summary>
			public string ColManagerPaidDate { 
				get { return GetColumnName("COL103239074724"); } 
			}


			/// <summary>
			/// Checks whether column ElecPaidDate is added in select statement 
			/// </summary>
			public bool IsSelectElecPaidDate { 
				get { return IsSelect("COL103239074728"); } 
				set { SetSelect("COL103239074728", value); } 
			}

			/// <summary>
			/// Checks whether column Creator is added in select statement 
			/// </summary>
			public bool IsSelectCreator { 
				get { return IsSelect("COL103239074713"); } 
				set { SetSelect("COL103239074713", value); } 
			}

			/// <summary>
			/// Checks whether column FlatID is added in select statement 
			/// </summary>
			public bool IsSelectFlatID { 
				get { return IsSelect("COL10323907472"); } 
				set { SetSelect("COL10323907472", value); } 
			}

			/// <summary>
			/// Checks whether column DelFlag is added in select statement 
			/// </summary>
			public bool IsSelectDelFlag { 
				get { return IsSelect("COL103239074711"); } 
				set { SetSelect("COL103239074711", value); } 
			}

			/// <summary>
			/// Checks whether column TenementID is added in select statement 
			/// </summary>
			public bool IsSelectTenementID { 
				get { return IsSelect("COL103239074716"); } 
				set { SetSelect("COL103239074716", value); } 
			}

			/// <summary>
			/// Checks whether column WaterFeePaid is added in select statement 
			/// </summary>
			public bool IsSelectWaterFeePaid { 
				get { return IsSelect("COL103239074721"); } 
				set { SetSelect("COL103239074721", value); } 
			}

			/// <summary>
			/// Checks whether column OtherFee is added in select statement 
			/// </summary>
			public bool IsSelectOtherFee { 
				get { return IsSelect("COL10323907477"); } 
				set { SetSelect("COL10323907477", value); } 
			}

			/// <summary>
			/// Checks whether column ElecFeePaid is added in select statement 
			/// </summary>
			public bool IsSelectElecFeePaid { 
				get { return IsSelect("COL103239074723"); } 
				set { SetSelect("COL103239074723", value); } 
			}

			/// <summary>
			/// Checks whether column Created is added in select statement 
			/// </summary>
			public bool IsSelectCreated { 
				get { return IsSelect("COL103239074712"); } 
				set { SetSelect("COL103239074712", value); } 
			}

			/// <summary>
			/// Checks whether column PayMoney is added in select statement 
			/// </summary>
			public bool IsSelectPayMoney { 
				get { return IsSelect("COL10323907478"); } 
				set { SetSelect("COL10323907478", value); } 
			}

			/// <summary>
			/// Checks whether column OtherFeePaid is added in select statement 
			/// </summary>
			public bool IsSelectOtherFeePaid { 
				get { return IsSelect("COL103239074722"); } 
				set { SetSelect("COL103239074722", value); } 
			}

			/// <summary>
			/// Checks whether column Updator is added in select statement 
			/// </summary>
			public bool IsSelectUpdator { 
				get { return IsSelect("COL103239074715"); } 
				set { SetSelect("COL103239074715", value); } 
			}

			/// <summary>
			/// Checks whether column ManagerFeePaid is added in select statement 
			/// </summary>
			public bool IsSelectManagerFeePaid { 
				get { return IsSelect("COL103239074719"); } 
				set { SetSelect("COL103239074719", value); } 
			}

			/// <summary>
			/// Checks whether column LossAvg is added in select statement 
			/// </summary>
			public bool IsSelectLossAvg { 
				get { return IsSelect("COL103239074717"); } 
				set { SetSelect("COL103239074717", value); } 
			}

			/// <summary>
			/// Checks whether column PackingFee is added in select statement 
			/// </summary>
			public bool IsSelectPackingFee { 
				get { return IsSelect("COL10323907475"); } 
				set { SetSelect("COL10323907475", value); } 
			}

			/// <summary>
			/// Checks whether column PackingPaidDate is added in select statement 
			/// </summary>
			public bool IsSelectPackingPaidDate { 
				get { return IsSelect("COL103239074725"); } 
				set { SetSelect("COL103239074725", value); } 
			}

			/// <summary>
			/// Checks whether column ManagerBillNo is added in select statement 
			/// </summary>
			public bool IsSelectManagerBillNo { 
				get { return IsSelect("COL103239074729"); } 
				set { SetSelect("COL103239074729", value); } 
			}

			/// <summary>
			/// Checks whether column OtherPaidDate is added in select statement 
			/// </summary>
			public bool IsSelectOtherPaidDate { 
				get { return IsSelect("COL103239074727"); } 
				set { SetSelect("COL103239074727", value); } 
			}

			/// <summary>
			/// Checks whether column WaterFee is added in select statement 
			/// </summary>
			public bool IsSelectWaterFee { 
				get { return IsSelect("COL10323907476"); } 
				set { SetSelect("COL10323907476", value); } 
			}

			/// <summary>
			/// Checks whether column WaterPaidDate is added in select statement 
			/// </summary>
			public bool IsSelectWaterPaidDate { 
				get { return IsSelect("COL103239074726"); } 
				set { SetSelect("COL103239074726", value); } 
			}

			/// <summary>
			/// Checks whether column PackingFeePaid is added in select statement 
			/// </summary>
			public bool IsSelectPackingFeePaid { 
				get { return IsSelect("COL103239074720"); } 
				set { SetSelect("COL103239074720", value); } 
			}

			/// <summary>
			/// Checks whether column YearMonth is added in select statement 
			/// </summary>
			public bool IsSelectYearMonth { 
				get { return IsSelect("COL10323907473"); } 
				set { SetSelect("COL10323907473", value); } 
			}

			/// <summary>
			/// Checks whether column Comment is added in select statement 
			/// </summary>
			public bool IsSelectComment { 
				get { return IsSelect("COL103239074710"); } 
				set { SetSelect("COL103239074710", value); } 
			}

			/// <summary>
			/// Checks whether column PackingBillNo is added in select statement 
			/// </summary>
			public bool IsSelectPackingBillNo { 
				get { return IsSelect("COL103239074730"); } 
				set { SetSelect("COL103239074730", value); } 
			}

			/// <summary>
			/// Checks whether column ManagerFee is added in select statement 
			/// </summary>
			public bool IsSelectManagerFee { 
				get { return IsSelect("COL10323907474"); } 
				set { SetSelect("COL10323907474", value); } 
			}

			/// <summary>
			/// Checks whether column ElecBillNo is added in select statement 
			/// </summary>
			public bool IsSelectElecBillNo { 
				get { return IsSelect("COL103239074733"); } 
				set { SetSelect("COL103239074733", value); } 
			}

			/// <summary>
			/// Checks whether column Updated is added in select statement 
			/// </summary>
			public bool IsSelectUpdated { 
				get { return IsSelect("COL103239074714"); } 
				set { SetSelect("COL103239074714", value); } 
			}

			/// <summary>
			/// Checks whether column PaidMoney is added in select statement 
			/// </summary>
			public bool IsSelectPaidMoney { 
				get { return IsSelect("COL10323907479"); } 
				set { SetSelect("COL10323907479", value); } 
			}

			/// <summary>
			/// Checks whether column ElecFee is added in select statement 
			/// </summary>
			public bool IsSelectElecFee { 
				get { return IsSelect("COL103239074718"); } 
				set { SetSelect("COL103239074718", value); } 
			}

			/// <summary>
			/// Checks whether column OtherBillNo is added in select statement 
			/// </summary>
			public bool IsSelectOtherBillNo { 
				get { return IsSelect("COL103239074732"); } 
				set { SetSelect("COL103239074732", value); } 
			}

			/// <summary>
			/// Checks whether column ID is added in select statement 
			/// </summary>
			public bool IsSelectID { 
				get { return IsSelect("COL10323907471"); } 
				set { SetSelect("COL10323907471", value); } 
			}

			/// <summary>
			/// Checks whether column WaterBillNo is added in select statement 
			/// </summary>
			public bool IsSelectWaterBillNo { 
				get { return IsSelect("COL103239074731"); } 
				set { SetSelect("COL103239074731", value); } 
			}

			/// <summary>
			/// Checks whether column ManagerPaidDate is added in select statement 
			/// </summary>
			public bool IsSelectManagerPaidDate { 
				get { return IsSelect("COL103239074724"); } 
				set { SetSelect("COL103239074724", value); } 
			}



	}
}