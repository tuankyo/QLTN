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
	public class Mst_VehicleTypeData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ2043870348";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of Mst_VehicleType 
			/// </summary>
			public Mst_VehicleTypeData(string objectID): base(objectID) {}  

			public Mst_VehicleTypeData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field DelFlag 
			/// </summary>
			public string DelFlag { 
				get { return GetValue("COL20438703483"); } 
				set { SetValue("COL20438703483", value); } 
			}

			/// <summary>
			/// Gets field VehicleType 
			/// </summary>
			public string VehicleType { 
				get { return GetValue("COL20438703482"); } 
				set { SetValue("COL20438703482", value); } 
			}

			/// <summary>
			/// Gets field Id 
			/// </summary>
			public string Id { 
				get { return GetValue("COL20438703481"); } 
				set { SetValue("COL20438703481", value); } 
			}


			/// <summary>
			/// Gets DelFlag attribute data 
			/// </summary>
			public AttributeData GetDelFlagAttributeData() { 
				return GetAttributeData("COL20438703483"); 
			}

			/// <summary>
			/// Gets VehicleType attribute data 
			/// </summary>
			public AttributeData GetVehicleTypeAttributeData() { 
				return GetAttributeData("COL20438703482"); 
			}

			/// <summary>
			/// Gets Id attribute data 
			/// </summary>
			public AttributeData GetIdAttributeData() { 
				return GetAttributeData("COL20438703481"); 
			}


			/// <summary>
			/// Gets column DelFlag with alias  
			/// </summary>
			public string ColDelFlag { 
				get { return GetColumnName("COL20438703483"); } 
			}

			/// <summary>
			/// Gets column VehicleType with alias  
			/// </summary>
			public string ColVehicleType { 
				get { return GetColumnName("COL20438703482"); } 
			}

			/// <summary>
			/// Gets column Id with alias  
			/// </summary>
			public string ColId { 
				get { return GetColumnName("COL20438703481"); } 
			}


			/// <summary>
			/// Checks whether column DelFlag is added in select statement 
			/// </summary>
			public bool IsSelectDelFlag { 
				get { return IsSelect("COL20438703483"); } 
				set { SetSelect("COL20438703483", value); } 
			}

			/// <summary>
			/// Checks whether column VehicleType is added in select statement 
			/// </summary>
			public bool IsSelectVehicleType { 
				get { return IsSelect("COL20438703482"); } 
				set { SetSelect("COL20438703482", value); } 
			}

			/// <summary>
			/// Checks whether column Id is added in select statement 
			/// </summary>
			public bool IsSelectId { 
				get { return IsSelect("COL20438703481"); } 
				set { SetSelect("COL20438703481", value); } 
			}



	}
}