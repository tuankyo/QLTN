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
	public class BD_ProviderEvalData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ1090102924";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of BD_ProviderEval 
			/// </summary>
			public BD_ProviderEvalData(string objectID): base(objectID) {}  

			public BD_ProviderEvalData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field CreatedBy 
			/// </summary>
			public string CreatedBy { 
				get { return GetValue("COL10901029247"); } 
				set { SetValue("COL10901029247", value); } 
			}

			/// <summary>
			/// Gets field Modified 
			/// </summary>
			public string Modified { 
				get { return GetValue("COL10901029248"); } 
				set { SetValue("COL10901029248", value); } 
			}

			/// <summary>
			/// Gets field Comment 
			/// </summary>
			public string Comment { 
				get { return GetValue("COL10901029245"); } 
				set { SetValue("COL10901029245", value); } 
			}

			/// <summary>
			/// Gets field DelFlag 
			/// </summary>
			public string DelFlag { 
				get { return GetValue("COL109010292410"); } 
				set { SetValue("COL109010292410", value); } 
			}

			/// <summary>
			/// Gets field Created 
			/// </summary>
			public string Created { 
				get { return GetValue("COL10901029246"); } 
				set { SetValue("COL10901029246", value); } 
			}

			/// <summary>
			/// Gets field EvalDate 
			/// </summary>
			public string EvalDate { 
				get { return GetValue("COL10901029243"); } 
				set { SetValue("COL10901029243", value); } 
			}

			/// <summary>
			/// Gets field ContentEval 
			/// </summary>
			public string ContentEval { 
				get { return GetValue("COL10901029244"); } 
				set { SetValue("COL10901029244", value); } 
			}

			/// <summary>
			/// Gets field id 
			/// </summary>
			public string id { 
				get { return GetValue("COL10901029241"); } 
				set { SetValue("COL10901029241", value); } 
			}

			/// <summary>
			/// Gets field ModifiedBy 
			/// </summary>
			public string ModifiedBy { 
				get { return GetValue("COL10901029249"); } 
				set { SetValue("COL10901029249", value); } 
			}

			/// <summary>
			/// Gets field ProviderId 
			/// </summary>
			public string ProviderId { 
				get { return GetValue("COL10901029242"); } 
				set { SetValue("COL10901029242", value); } 
			}


			/// <summary>
			/// Gets CreatedBy attribute data 
			/// </summary>
			public AttributeData GetCreatedByAttributeData() { 
				return GetAttributeData("COL10901029247"); 
			}

			/// <summary>
			/// Gets Modified attribute data 
			/// </summary>
			public AttributeData GetModifiedAttributeData() { 
				return GetAttributeData("COL10901029248"); 
			}

			/// <summary>
			/// Gets Comment attribute data 
			/// </summary>
			public AttributeData GetCommentAttributeData() { 
				return GetAttributeData("COL10901029245"); 
			}

			/// <summary>
			/// Gets DelFlag attribute data 
			/// </summary>
			public AttributeData GetDelFlagAttributeData() { 
				return GetAttributeData("COL109010292410"); 
			}

			/// <summary>
			/// Gets Created attribute data 
			/// </summary>
			public AttributeData GetCreatedAttributeData() { 
				return GetAttributeData("COL10901029246"); 
			}

			/// <summary>
			/// Gets EvalDate attribute data 
			/// </summary>
			public AttributeData GetEvalDateAttributeData() { 
				return GetAttributeData("COL10901029243"); 
			}

			/// <summary>
			/// Gets ContentEval attribute data 
			/// </summary>
			public AttributeData GetContentEvalAttributeData() { 
				return GetAttributeData("COL10901029244"); 
			}

			/// <summary>
			/// Gets id attribute data 
			/// </summary>
			public AttributeData GetidAttributeData() { 
				return GetAttributeData("COL10901029241"); 
			}

			/// <summary>
			/// Gets ModifiedBy attribute data 
			/// </summary>
			public AttributeData GetModifiedByAttributeData() { 
				return GetAttributeData("COL10901029249"); 
			}

			/// <summary>
			/// Gets ProviderId attribute data 
			/// </summary>
			public AttributeData GetProviderIdAttributeData() { 
				return GetAttributeData("COL10901029242"); 
			}


			/// <summary>
			/// Gets column CreatedBy with alias  
			/// </summary>
			public string ColCreatedBy { 
				get { return GetColumnName("COL10901029247"); } 
			}

			/// <summary>
			/// Gets column Modified with alias  
			/// </summary>
			public string ColModified { 
				get { return GetColumnName("COL10901029248"); } 
			}

			/// <summary>
			/// Gets column Comment with alias  
			/// </summary>
			public string ColComment { 
				get { return GetColumnName("COL10901029245"); } 
			}

			/// <summary>
			/// Gets column DelFlag with alias  
			/// </summary>
			public string ColDelFlag { 
				get { return GetColumnName("COL109010292410"); } 
			}

			/// <summary>
			/// Gets column Created with alias  
			/// </summary>
			public string ColCreated { 
				get { return GetColumnName("COL10901029246"); } 
			}

			/// <summary>
			/// Gets column EvalDate with alias  
			/// </summary>
			public string ColEvalDate { 
				get { return GetColumnName("COL10901029243"); } 
			}

			/// <summary>
			/// Gets column ContentEval with alias  
			/// </summary>
			public string ColContentEval { 
				get { return GetColumnName("COL10901029244"); } 
			}

			/// <summary>
			/// Gets column id with alias  
			/// </summary>
			public string Colid { 
				get { return GetColumnName("COL10901029241"); } 
			}

			/// <summary>
			/// Gets column ModifiedBy with alias  
			/// </summary>
			public string ColModifiedBy { 
				get { return GetColumnName("COL10901029249"); } 
			}

			/// <summary>
			/// Gets column ProviderId with alias  
			/// </summary>
			public string ColProviderId { 
				get { return GetColumnName("COL10901029242"); } 
			}


			/// <summary>
			/// Checks whether column CreatedBy is added in select statement 
			/// </summary>
			public bool IsSelectCreatedBy { 
				get { return IsSelect("COL10901029247"); } 
				set { SetSelect("COL10901029247", value); } 
			}

			/// <summary>
			/// Checks whether column Modified is added in select statement 
			/// </summary>
			public bool IsSelectModified { 
				get { return IsSelect("COL10901029248"); } 
				set { SetSelect("COL10901029248", value); } 
			}

			/// <summary>
			/// Checks whether column Comment is added in select statement 
			/// </summary>
			public bool IsSelectComment { 
				get { return IsSelect("COL10901029245"); } 
				set { SetSelect("COL10901029245", value); } 
			}

			/// <summary>
			/// Checks whether column DelFlag is added in select statement 
			/// </summary>
			public bool IsSelectDelFlag { 
				get { return IsSelect("COL109010292410"); } 
				set { SetSelect("COL109010292410", value); } 
			}

			/// <summary>
			/// Checks whether column Created is added in select statement 
			/// </summary>
			public bool IsSelectCreated { 
				get { return IsSelect("COL10901029246"); } 
				set { SetSelect("COL10901029246", value); } 
			}

			/// <summary>
			/// Checks whether column EvalDate is added in select statement 
			/// </summary>
			public bool IsSelectEvalDate { 
				get { return IsSelect("COL10901029243"); } 
				set { SetSelect("COL10901029243", value); } 
			}

			/// <summary>
			/// Checks whether column ContentEval is added in select statement 
			/// </summary>
			public bool IsSelectContentEval { 
				get { return IsSelect("COL10901029244"); } 
				set { SetSelect("COL10901029244", value); } 
			}

			/// <summary>
			/// Checks whether column id is added in select statement 
			/// </summary>
			public bool IsSelectid { 
				get { return IsSelect("COL10901029241"); } 
				set { SetSelect("COL10901029241", value); } 
			}

			/// <summary>
			/// Checks whether column ModifiedBy is added in select statement 
			/// </summary>
			public bool IsSelectModifiedBy { 
				get { return IsSelect("COL10901029249"); } 
				set { SetSelect("COL10901029249", value); } 
			}

			/// <summary>
			/// Checks whether column ProviderId is added in select statement 
			/// </summary>
			public bool IsSelectProviderId { 
				get { return IsSelect("COL10901029242"); } 
				set { SetSelect("COL10901029242", value); } 
			}



	}
}