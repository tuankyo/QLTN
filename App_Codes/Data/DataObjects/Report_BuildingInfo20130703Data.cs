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
	public class Report_BuildingInfo20130703Data : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ1800393483";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of Report_BuildingInfo20130703 
			/// </summary>
			public Report_BuildingInfo20130703Data(string objectID): base(objectID) {}  

			public Report_BuildingInfo20130703Data() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field Name 
			/// </summary>
			public string Name { 
				get { return GetValue("COL18003934832"); } 
				set { SetValue("COL18003934832", value); } 
			}

			/// <summary>
			/// Gets field delflag 
			/// </summary>
			public string delflag { 
				get { return GetValue("COL18003934838"); } 
				set { SetValue("COL18003934838", value); } 
			}

			/// <summary>
			/// Gets field CellBeginX 
			/// </summary>
			public string CellBeginX { 
				get { return GetValue("COL18003934837"); } 
				set { SetValue("COL18003934837", value); } 
			}

			/// <summary>
			/// Gets field SqlSelect 
			/// </summary>
			public string SqlSelect { 
				get { return GetValue("COL18003934835"); } 
				set { SetValue("COL18003934835", value); } 
			}

			/// <summary>
			/// Gets field CellBeginY 
			/// </summary>
			public string CellBeginY { 
				get { return GetValue("COL18003934836"); } 
				set { SetValue("COL18003934836", value); } 
			}

			/// <summary>
			/// Gets field Sheet 
			/// </summary>
			public string Sheet { 
				get { return GetValue("COL18003934833"); } 
				set { SetValue("COL18003934833", value); } 
			}

			/// <summary>
			/// Gets field SumCol 
			/// </summary>
			public string SumCol { 
				get { return GetValue("COL18003934839"); } 
				set { SetValue("COL18003934839", value); } 
			}

			/// <summary>
			/// Gets field NoOfColumn 
			/// </summary>
			public string NoOfColumn { 
				get { return GetValue("COL18003934834"); } 
				set { SetValue("COL18003934834", value); } 
			}

			/// <summary>
			/// Gets field id 
			/// </summary>
			public string id { 
				get { return GetValue("COL18003934831"); } 
				set { SetValue("COL18003934831", value); } 
			}


			/// <summary>
			/// Gets Name attribute data 
			/// </summary>
			public AttributeData GetNameAttributeData() { 
				return GetAttributeData("COL18003934832"); 
			}

			/// <summary>
			/// Gets delflag attribute data 
			/// </summary>
			public AttributeData GetdelflagAttributeData() { 
				return GetAttributeData("COL18003934838"); 
			}

			/// <summary>
			/// Gets CellBeginX attribute data 
			/// </summary>
			public AttributeData GetCellBeginXAttributeData() { 
				return GetAttributeData("COL18003934837"); 
			}

			/// <summary>
			/// Gets SqlSelect attribute data 
			/// </summary>
			public AttributeData GetSqlSelectAttributeData() { 
				return GetAttributeData("COL18003934835"); 
			}

			/// <summary>
			/// Gets CellBeginY attribute data 
			/// </summary>
			public AttributeData GetCellBeginYAttributeData() { 
				return GetAttributeData("COL18003934836"); 
			}

			/// <summary>
			/// Gets Sheet attribute data 
			/// </summary>
			public AttributeData GetSheetAttributeData() { 
				return GetAttributeData("COL18003934833"); 
			}

			/// <summary>
			/// Gets SumCol attribute data 
			/// </summary>
			public AttributeData GetSumColAttributeData() { 
				return GetAttributeData("COL18003934839"); 
			}

			/// <summary>
			/// Gets NoOfColumn attribute data 
			/// </summary>
			public AttributeData GetNoOfColumnAttributeData() { 
				return GetAttributeData("COL18003934834"); 
			}

			/// <summary>
			/// Gets id attribute data 
			/// </summary>
			public AttributeData GetidAttributeData() { 
				return GetAttributeData("COL18003934831"); 
			}


			/// <summary>
			/// Gets column Name with alias  
			/// </summary>
			public string ColName { 
				get { return GetColumnName("COL18003934832"); } 
			}

			/// <summary>
			/// Gets column delflag with alias  
			/// </summary>
			public string Coldelflag { 
				get { return GetColumnName("COL18003934838"); } 
			}

			/// <summary>
			/// Gets column CellBeginX with alias  
			/// </summary>
			public string ColCellBeginX { 
				get { return GetColumnName("COL18003934837"); } 
			}

			/// <summary>
			/// Gets column SqlSelect with alias  
			/// </summary>
			public string ColSqlSelect { 
				get { return GetColumnName("COL18003934835"); } 
			}

			/// <summary>
			/// Gets column CellBeginY with alias  
			/// </summary>
			public string ColCellBeginY { 
				get { return GetColumnName("COL18003934836"); } 
			}

			/// <summary>
			/// Gets column Sheet with alias  
			/// </summary>
			public string ColSheet { 
				get { return GetColumnName("COL18003934833"); } 
			}

			/// <summary>
			/// Gets column SumCol with alias  
			/// </summary>
			public string ColSumCol { 
				get { return GetColumnName("COL18003934839"); } 
			}

			/// <summary>
			/// Gets column NoOfColumn with alias  
			/// </summary>
			public string ColNoOfColumn { 
				get { return GetColumnName("COL18003934834"); } 
			}

			/// <summary>
			/// Gets column id with alias  
			/// </summary>
			public string Colid { 
				get { return GetColumnName("COL18003934831"); } 
			}


			/// <summary>
			/// Checks whether column Name is added in select statement 
			/// </summary>
			public bool IsSelectName { 
				get { return IsSelect("COL18003934832"); } 
				set { SetSelect("COL18003934832", value); } 
			}

			/// <summary>
			/// Checks whether column delflag is added in select statement 
			/// </summary>
			public bool IsSelectdelflag { 
				get { return IsSelect("COL18003934838"); } 
				set { SetSelect("COL18003934838", value); } 
			}

			/// <summary>
			/// Checks whether column CellBeginX is added in select statement 
			/// </summary>
			public bool IsSelectCellBeginX { 
				get { return IsSelect("COL18003934837"); } 
				set { SetSelect("COL18003934837", value); } 
			}

			/// <summary>
			/// Checks whether column SqlSelect is added in select statement 
			/// </summary>
			public bool IsSelectSqlSelect { 
				get { return IsSelect("COL18003934835"); } 
				set { SetSelect("COL18003934835", value); } 
			}

			/// <summary>
			/// Checks whether column CellBeginY is added in select statement 
			/// </summary>
			public bool IsSelectCellBeginY { 
				get { return IsSelect("COL18003934836"); } 
				set { SetSelect("COL18003934836", value); } 
			}

			/// <summary>
			/// Checks whether column Sheet is added in select statement 
			/// </summary>
			public bool IsSelectSheet { 
				get { return IsSelect("COL18003934833"); } 
				set { SetSelect("COL18003934833", value); } 
			}

			/// <summary>
			/// Checks whether column SumCol is added in select statement 
			/// </summary>
			public bool IsSelectSumCol { 
				get { return IsSelect("COL18003934839"); } 
				set { SetSelect("COL18003934839", value); } 
			}

			/// <summary>
			/// Checks whether column NoOfColumn is added in select statement 
			/// </summary>
			public bool IsSelectNoOfColumn { 
				get { return IsSelect("COL18003934834"); } 
				set { SetSelect("COL18003934834", value); } 
			}

			/// <summary>
			/// Checks whether column id is added in select statement 
			/// </summary>
			public bool IsSelectid { 
				get { return IsSelect("COL18003934831"); } 
				set { SetSelect("COL18003934831", value); } 
			}



	}
}