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
	public class BD_StaffEvalInfoData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ866102126";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of BD_StaffEvalInfo 
			/// </summary>
			public BD_StaffEvalInfoData(string objectID): base(objectID) {}  

			public BD_StaffEvalInfoData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field DelFlag 
			/// </summary>
			public string DelFlag { 
				get { return GetValue("COL86610212610"); } 
				set { SetValue("COL86610212610", value); } 
			}

			/// <summary>
			/// Gets field Modified 
			/// </summary>
			public string Modified { 
				get { return GetValue("COL8661021268"); } 
				set { SetValue("COL8661021268", value); } 
			}

			/// <summary>
			/// Gets field ModifiedBy 
			/// </summary>
			public string ModifiedBy { 
				get { return GetValue("COL8661021269"); } 
				set { SetValue("COL8661021269", value); } 
			}

			/// <summary>
			/// Gets field Created 
			/// </summary>
			public string Created { 
				get { return GetValue("COL8661021266"); } 
				set { SetValue("COL8661021266", value); } 
			}

			/// <summary>
			/// Gets field CreatedBy 
			/// </summary>
			public string CreatedBy { 
				get { return GetValue("COL8661021267"); } 
				set { SetValue("COL8661021267", value); } 
			}

			/// <summary>
			/// Gets field ContentEval 
			/// </summary>
			public string ContentEval { 
				get { return GetValue("COL8661021264"); } 
				set { SetValue("COL8661021264", value); } 
			}

			/// <summary>
			/// Gets field Comment 
			/// </summary>
			public string Comment { 
				get { return GetValue("COL8661021265"); } 
				set { SetValue("COL8661021265", value); } 
			}

			/// <summary>
			/// Gets field StaffId 
			/// </summary>
			public string StaffId { 
				get { return GetValue("COL8661021262"); } 
				set { SetValue("COL8661021262", value); } 
			}

			/// <summary>
			/// Gets field EvalDate 
			/// </summary>
			public string EvalDate { 
				get { return GetValue("COL8661021263"); } 
				set { SetValue("COL8661021263", value); } 
			}

			/// <summary>
			/// Gets field id 
			/// </summary>
			public string id { 
				get { return GetValue("COL8661021261"); } 
				set { SetValue("COL8661021261", value); } 
			}


			/// <summary>
			/// Gets DelFlag attribute data 
			/// </summary>
			public AttributeData GetDelFlagAttributeData() { 
				return GetAttributeData("COL86610212610"); 
			}

			/// <summary>
			/// Gets Modified attribute data 
			/// </summary>
			public AttributeData GetModifiedAttributeData() { 
				return GetAttributeData("COL8661021268"); 
			}

			/// <summary>
			/// Gets ModifiedBy attribute data 
			/// </summary>
			public AttributeData GetModifiedByAttributeData() { 
				return GetAttributeData("COL8661021269"); 
			}

			/// <summary>
			/// Gets Created attribute data 
			/// </summary>
			public AttributeData GetCreatedAttributeData() { 
				return GetAttributeData("COL8661021266"); 
			}

			/// <summary>
			/// Gets CreatedBy attribute data 
			/// </summary>
			public AttributeData GetCreatedByAttributeData() { 
				return GetAttributeData("COL8661021267"); 
			}

			/// <summary>
			/// Gets ContentEval attribute data 
			/// </summary>
			public AttributeData GetContentEvalAttributeData() { 
				return GetAttributeData("COL8661021264"); 
			}

			/// <summary>
			/// Gets Comment attribute data 
			/// </summary>
			public AttributeData GetCommentAttributeData() { 
				return GetAttributeData("COL8661021265"); 
			}

			/// <summary>
			/// Gets StaffId attribute data 
			/// </summary>
			public AttributeData GetStaffIdAttributeData() { 
				return GetAttributeData("COL8661021262"); 
			}

			/// <summary>
			/// Gets EvalDate attribute data 
			/// </summary>
			public AttributeData GetEvalDateAttributeData() { 
				return GetAttributeData("COL8661021263"); 
			}

			/// <summary>
			/// Gets id attribute data 
			/// </summary>
			public AttributeData GetidAttributeData() { 
				return GetAttributeData("COL8661021261"); 
			}


			/// <summary>
			/// Gets column DelFlag with alias  
			/// </summary>
			public string ColDelFlag { 
				get { return GetColumnName("COL86610212610"); } 
			}

			/// <summary>
			/// Gets column Modified with alias  
			/// </summary>
			public string ColModified { 
				get { return GetColumnName("COL8661021268"); } 
			}

			/// <summary>
			/// Gets column ModifiedBy with alias  
			/// </summary>
			public string ColModifiedBy { 
				get { return GetColumnName("COL8661021269"); } 
			}

			/// <summary>
			/// Gets column Created with alias  
			/// </summary>
			public string ColCreated { 
				get { return GetColumnName("COL8661021266"); } 
			}

			/// <summary>
			/// Gets column CreatedBy with alias  
			/// </summary>
			public string ColCreatedBy { 
				get { return GetColumnName("COL8661021267"); } 
			}

			/// <summary>
			/// Gets column ContentEval with alias  
			/// </summary>
			public string ColContentEval { 
				get { return GetColumnName("COL8661021264"); } 
			}

			/// <summary>
			/// Gets column Comment with alias  
			/// </summary>
			public string ColComment { 
				get { return GetColumnName("COL8661021265"); } 
			}

			/// <summary>
			/// Gets column StaffId with alias  
			/// </summary>
			public string ColStaffId { 
				get { return GetColumnName("COL8661021262"); } 
			}

			/// <summary>
			/// Gets column EvalDate with alias  
			/// </summary>
			public string ColEvalDate { 
				get { return GetColumnName("COL8661021263"); } 
			}

			/// <summary>
			/// Gets column id with alias  
			/// </summary>
			public string Colid { 
				get { return GetColumnName("COL8661021261"); } 
			}


			/// <summary>
			/// Checks whether column DelFlag is added in select statement 
			/// </summary>
			public bool IsSelectDelFlag { 
				get { return IsSelect("COL86610212610"); } 
				set { SetSelect("COL86610212610", value); } 
			}

			/// <summary>
			/// Checks whether column Modified is added in select statement 
			/// </summary>
			public bool IsSelectModified { 
				get { return IsSelect("COL8661021268"); } 
				set { SetSelect("COL8661021268", value); } 
			}

			/// <summary>
			/// Checks whether column ModifiedBy is added in select statement 
			/// </summary>
			public bool IsSelectModifiedBy { 
				get { return IsSelect("COL8661021269"); } 
				set { SetSelect("COL8661021269", value); } 
			}

			/// <summary>
			/// Checks whether column Created is added in select statement 
			/// </summary>
			public bool IsSelectCreated { 
				get { return IsSelect("COL8661021266"); } 
				set { SetSelect("COL8661021266", value); } 
			}

			/// <summary>
			/// Checks whether column CreatedBy is added in select statement 
			/// </summary>
			public bool IsSelectCreatedBy { 
				get { return IsSelect("COL8661021267"); } 
				set { SetSelect("COL8661021267", value); } 
			}

			/// <summary>
			/// Checks whether column ContentEval is added in select statement 
			/// </summary>
			public bool IsSelectContentEval { 
				get { return IsSelect("COL8661021264"); } 
				set { SetSelect("COL8661021264", value); } 
			}

			/// <summary>
			/// Checks whether column Comment is added in select statement 
			/// </summary>
			public bool IsSelectComment { 
				get { return IsSelect("COL8661021265"); } 
				set { SetSelect("COL8661021265", value); } 
			}

			/// <summary>
			/// Checks whether column StaffId is added in select statement 
			/// </summary>
			public bool IsSelectStaffId { 
				get { return IsSelect("COL8661021262"); } 
				set { SetSelect("COL8661021262", value); } 
			}

			/// <summary>
			/// Checks whether column EvalDate is added in select statement 
			/// </summary>
			public bool IsSelectEvalDate { 
				get { return IsSelect("COL8661021263"); } 
				set { SetSelect("COL8661021263", value); } 
			}

			/// <summary>
			/// Checks whether column id is added in select statement 
			/// </summary>
			public bool IsSelectid { 
				get { return IsSelect("COL8661021261"); } 
				set { SetSelect("COL8661021261", value); } 
			}



	}
}