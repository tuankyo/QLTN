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
	public class MessagePlaceHoldersData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ1432392172";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of MessagePlaceHolders 
			/// </summary>
			public MessagePlaceHoldersData(string objectID): base(objectID) {}  

			public MessagePlaceHoldersData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field PlaceHolderID 
			/// </summary>
			public string PlaceHolderID { 
				get { return GetValue("COL14323921721"); } 
				set { SetValue("COL14323921721", value); } 
			}

			/// <summary>
			/// Gets field PlaceHolder 
			/// </summary>
			public string PlaceHolder { 
				get { return GetValue("COL14323921722"); } 
				set { SetValue("COL14323921722", value); } 
			}


			/// <summary>
			/// Gets PlaceHolderID attribute data 
			/// </summary>
			public AttributeData GetPlaceHolderIDAttributeData() { 
				return GetAttributeData("COL14323921721"); 
			}

			/// <summary>
			/// Gets PlaceHolder attribute data 
			/// </summary>
			public AttributeData GetPlaceHolderAttributeData() { 
				return GetAttributeData("COL14323921722"); 
			}


			/// <summary>
			/// Gets column PlaceHolderID with alias  
			/// </summary>
			public string ColPlaceHolderID { 
				get { return GetColumnName("COL14323921721"); } 
			}

			/// <summary>
			/// Gets column PlaceHolder with alias  
			/// </summary>
			public string ColPlaceHolder { 
				get { return GetColumnName("COL14323921722"); } 
			}


			/// <summary>
			/// Checks whether column PlaceHolderID is added in select statement 
			/// </summary>
			public bool IsSelectPlaceHolderID { 
				get { return IsSelect("COL14323921721"); } 
				set { SetSelect("COL14323921721", value); } 
			}

			/// <summary>
			/// Checks whether column PlaceHolder is added in select statement 
			/// </summary>
			public bool IsSelectPlaceHolder { 
				get { return IsSelect("COL14323921722"); } 
				set { SetSelect("COL14323921722", value); } 
			}



	}
}