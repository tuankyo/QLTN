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
	public class AddressBookData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ1336391830";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of AddressBook 
			/// </summary>
			public AddressBookData(string objectID): base(objectID) {}  

			public AddressBookData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field Contact 
			/// </summary>
			public string Contact { 
				get { return GetValue("COL13363918303"); } 
				set { SetValue("COL13363918303", value); } 
			}

			/// <summary>
			/// Gets field UserName 
			/// </summary>
			public string UserName { 
				get { return GetValue("COL13363918302"); } 
				set { SetValue("COL13363918302", value); } 
			}

			/// <summary>
			/// Gets field FullName 
			/// </summary>
			public string FullName { 
				get { return GetValue("COL13363918304"); } 
				set { SetValue("COL13363918304", value); } 
			}

			/// <summary>
			/// Gets field AddressBookId 
			/// </summary>
			public string AddressBookId { 
				get { return GetValue("COL13363918301"); } 
				set { SetValue("COL13363918301", value); } 
			}


			/// <summary>
			/// Gets Contact attribute data 
			/// </summary>
			public AttributeData GetContactAttributeData() { 
				return GetAttributeData("COL13363918303"); 
			}

			/// <summary>
			/// Gets UserName attribute data 
			/// </summary>
			public AttributeData GetUserNameAttributeData() { 
				return GetAttributeData("COL13363918302"); 
			}

			/// <summary>
			/// Gets FullName attribute data 
			/// </summary>
			public AttributeData GetFullNameAttributeData() { 
				return GetAttributeData("COL13363918304"); 
			}

			/// <summary>
			/// Gets AddressBookId attribute data 
			/// </summary>
			public AttributeData GetAddressBookIdAttributeData() { 
				return GetAttributeData("COL13363918301"); 
			}


			/// <summary>
			/// Gets column Contact with alias  
			/// </summary>
			public string ColContact { 
				get { return GetColumnName("COL13363918303"); } 
			}

			/// <summary>
			/// Gets column UserName with alias  
			/// </summary>
			public string ColUserName { 
				get { return GetColumnName("COL13363918302"); } 
			}

			/// <summary>
			/// Gets column FullName with alias  
			/// </summary>
			public string ColFullName { 
				get { return GetColumnName("COL13363918304"); } 
			}

			/// <summary>
			/// Gets column AddressBookId with alias  
			/// </summary>
			public string ColAddressBookId { 
				get { return GetColumnName("COL13363918301"); } 
			}


			/// <summary>
			/// Checks whether column Contact is added in select statement 
			/// </summary>
			public bool IsSelectContact { 
				get { return IsSelect("COL13363918303"); } 
				set { SetSelect("COL13363918303", value); } 
			}

			/// <summary>
			/// Checks whether column UserName is added in select statement 
			/// </summary>
			public bool IsSelectUserName { 
				get { return IsSelect("COL13363918302"); } 
				set { SetSelect("COL13363918302", value); } 
			}

			/// <summary>
			/// Checks whether column FullName is added in select statement 
			/// </summary>
			public bool IsSelectFullName { 
				get { return IsSelect("COL13363918304"); } 
				set { SetSelect("COL13363918304", value); } 
			}

			/// <summary>
			/// Checks whether column AddressBookId is added in select statement 
			/// </summary>
			public bool IsSelectAddressBookId { 
				get { return IsSelect("COL13363918301"); } 
				set { SetSelect("COL13363918301", value); } 
			}



	}
}