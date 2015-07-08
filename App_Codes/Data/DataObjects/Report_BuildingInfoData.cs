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
	public class Report_BuildingInfoData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ1816393540";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of Report_BuildingInfo 
			/// </summary>
			public Report_BuildingInfoData(string objectID): base(objectID) {}  

			public Report_BuildingInfoData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field CellBeginX 
			/// </summary>
			public string CellBeginX { 
				get { return GetValue("COL18163935407"); } 
				set { SetValue("COL18163935407", value); } 
			}

			/// <summary>
			/// Gets field Name 
			/// </summary>
			public string Name { 
				get { return GetValue("COL18163935402"); } 
				set { SetValue("COL18163935402", value); } 
			}

			/// <summary>
			/// Gets field delflag 
			/// </summary>
			public string delflag { 
				get { return GetValue("COL18163935408"); } 
				set { SetValue("COL18163935408", value); } 
			}

			/// <summary>
			/// Gets field SqlSelect 
			/// </summary>
			public string SqlSelect { 
				get { return GetValue("COL18163935405"); } 
				set { SetValue("COL18163935405", value); } 
			}

			/// <summary>
			/// Gets field Sheet 
			/// </summary>
			public string Sheet { 
				get { return GetValue("COL18163935403"); } 
				set { SetValue("COL18163935403", value); } 
			}

			/// <summary>
			/// Gets field SumCol 
			/// </summary>
			public string SumCol { 
				get { return GetValue("COL18163935409"); } 
				set { SetValue("COL18163935409", value); } 
			}

			/// <summary>
			/// Gets field CellBeginY 
			/// </summary>
			public string CellBeginY { 
				get { return GetValue("COL18163935406"); } 
				set { SetValue("COL18163935406", value); } 
			}

			/// <summary>
			/// Gets field id 
			/// </summary>
			public string id { 
				get { return GetValue("COL18163935401"); } 
				set { SetValue("COL18163935401", value); } 
			}

			/// <summary>
			/// Gets field NoOfColumn 
			/// </summary>
			public string NoOfColumn { 
				get { return GetValue("COL18163935404"); } 
				set { SetValue("COL18163935404", value); } 
			}


			/// <summary>
			/// Gets CellBeginX attribute data 
			/// </summary>
			public AttributeData GetCellBeginXAttributeData() { 
				return GetAttributeData("COL18163935407"); 
			}

			/// <summary>
			/// Gets Name attribute data 
			/// </summary>
			public AttributeData GetNameAttributeData() { 
				return GetAttributeData("COL18163935402"); 
			}

			/// <summary>
			/// Gets delflag attribute data 
			/// </summary>
			public AttributeData GetdelflagAttributeData() { 
				return GetAttributeData("COL18163935408"); 
			}

			/// <summary>
			/// Gets SqlSelect attribute data 
			/// </summary>
			public AttributeData GetSqlSelectAttributeData() { 
				return GetAttributeData("COL18163935405"); 
			}

			/// <summary>
			/// Gets Sheet attribute data 
			/// </summary>
			public AttributeData GetSheetAttributeData() { 
				return GetAttributeData("COL18163935403"); 
			}

			/// <summary>
			/// Gets SumCol attribute data 
			/// </summary>
			public AttributeData GetSumColAttributeData() { 
				return GetAttributeData("COL18163935409"); 
			}

			/// <summary>
			/// Gets CellBeginY attribute data 
			/// </summary>
			public AttributeData GetCellBeginYAttributeData() { 
				return GetAttributeData("COL18163935406"); 
			}

			/// <summary>
			/// Gets id attribute data 
			/// </summary>
			public AttributeData GetidAttributeData() { 
				return GetAttributeData("COL18163935401"); 
			}

			/// <summary>
			/// Gets NoOfColumn attribute data 
			/// </summary>
			public AttributeData GetNoOfColumnAttributeData() { 
				return GetAttributeData("COL18163935404"); 
			}


			/// <summary>
			/// Gets column CellBeginX with alias  
			/// </summary>
			public string ColCellBeginX { 
				get { return GetColumnName("COL18163935407"); } 
			}

			/// <summary>
			/// Gets column Name with alias  
			/// </summary>
			public string ColName { 
				get { return GetColumnName("COL18163935402"); } 
			}

			/// <summary>
			/// Gets column delflag with alias  
			/// </summary>
			public string Coldelflag { 
				get { return GetColumnName("COL18163935408"); } 
			}

			/// <summary>
			/// Gets column SqlSelect with alias  
			/// </summary>
			public string ColSqlSelect { 
				get { return GetColumnName("COL18163935405"); } 
			}

			/// <summary>
			/// Gets column Sheet with alias  
			/// </summary>
			public string ColSheet { 
				get { return GetColumnName("COL18163935403"); } 
			}

			/// <summary>
			/// Gets column SumCol with alias  
			/// </summary>
			public string ColSumCol { 
				get { return GetColumnName("COL18163935409"); } 
			}

			/// <summary>
			/// Gets column CellBeginY with alias  
			/// </summary>
			public string ColCellBeginY { 
				get { return GetColumnName("COL18163935406"); } 
			}

			/// <summary>
			/// Gets column id with alias  
			/// </summary>
			public string Colid { 
				get { return GetColumnName("COL18163935401"); } 
			}

			/// <summary>
			/// Gets column NoOfColumn with alias  
			/// </summary>
			public string ColNoOfColumn { 
				get { return GetColumnName("COL18163935404"); } 
			}


			/// <summary>
			/// Checks whether column CellBeginX is added in select statement 
			/// </summary>
			public bool IsSelectCellBeginX { 
				get { return IsSelect("COL18163935407"); } 
				set { SetSelect("COL18163935407", value); } 
			}

			/// <summary>
			/// Checks whether column Name is added in select statement 
			/// </summary>
			public bool IsSelectName { 
				get { return IsSelect("COL18163935402"); } 
				set { SetSelect("COL18163935402", value); } 
			}

			/// <summary>
			/// Checks whether column delflag is added in select statement 
			/// </summary>
			public bool IsSelectdelflag { 
				get { return IsSelect("COL18163935408"); } 
				set { SetSelect("COL18163935408", value); } 
			}

			/// <summary>
			/// Checks whether column SqlSelect is added in select statement 
			/// </summary>
			public bool IsSelectSqlSelect { 
				get { return IsSelect("COL18163935405"); } 
				set { SetSelect("COL18163935405", value); } 
			}

			/// <summary>
			/// Checks whether column Sheet is added in select statement 
			/// </summary>
			public bool IsSelectSheet { 
				get { return IsSelect("COL18163935403"); } 
				set { SetSelect("COL18163935403", value); } 
			}

			/// <summary>
			/// Checks whether column SumCol is added in select statement 
			/// </summary>
			public bool IsSelectSumCol { 
				get { return IsSelect("COL18163935409"); } 
				set { SetSelect("COL18163935409", value); } 
			}

			/// <summary>
			/// Checks whether column CellBeginY is added in select statement 
			/// </summary>
			public bool IsSelectCellBeginY { 
				get { return IsSelect("COL18163935406"); } 
				set { SetSelect("COL18163935406", value); } 
			}

			/// <summary>
			/// Checks whether column id is added in select statement 
			/// </summary>
			public bool IsSelectid { 
				get { return IsSelect("COL18163935401"); } 
				set { SetSelect("COL18163935401", value); } 
			}

			/// <summary>
			/// Checks whether column NoOfColumn is added in select statement 
			/// </summary>
			public bool IsSelectNoOfColumn { 
				get { return IsSelect("COL18163935404"); } 
				set { SetSelect("COL18163935404", value); } 
			}



	}
}