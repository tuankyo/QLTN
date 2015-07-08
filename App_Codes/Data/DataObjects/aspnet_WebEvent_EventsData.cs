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
	public class aspnet_WebEvent_EventsData : AbstractDataObject
	{
			#region Fields 

			private static string objectID = "OBJ2005582183";

			#endregion Fields 

			#region Constructors 

			/// <summary>
			/// Construction of aspnet_WebEvent_Events 
			/// </summary>
			public aspnet_WebEvent_EventsData(string objectID): base(objectID) {}  

			public aspnet_WebEvent_EventsData() : base(objectID) {} 

			#endregion Constructors 

			/// <summary>
			/// Gets field EventSequence 
			/// </summary>
			public string EventSequence { 
				get { return GetValue("COL20055821835"); } 
				set { SetValue("COL20055821835", value); } 
			}

			/// <summary>
			/// Gets field ApplicationVirtualPath 
			/// </summary>
			public string ApplicationVirtualPath { 
				get { return GetValue("COL200558218311"); } 
				set { SetValue("COL200558218311", value); } 
			}

			/// <summary>
			/// Gets field ExceptionType 
			/// </summary>
			public string ExceptionType { 
				get { return GetValue("COL200558218314"); } 
				set { SetValue("COL200558218314", value); } 
			}

			/// <summary>
			/// Gets field EventTime 
			/// </summary>
			public string EventTime { 
				get { return GetValue("COL20055821833"); } 
				set { SetValue("COL20055821833", value); } 
			}

			/// <summary>
			/// Gets field Message 
			/// </summary>
			public string Message { 
				get { return GetValue("COL20055821839"); } 
				set { SetValue("COL20055821839", value); } 
			}

			/// <summary>
			/// Gets field MachineName 
			/// </summary>
			public string MachineName { 
				get { return GetValue("COL200558218312"); } 
				set { SetValue("COL200558218312", value); } 
			}

			/// <summary>
			/// Gets field EventId 
			/// </summary>
			public string EventId { 
				get { return GetValue("COL20055821831"); } 
				set { SetValue("COL20055821831", value); } 
			}

			/// <summary>
			/// Gets field EventOccurrence 
			/// </summary>
			public string EventOccurrence { 
				get { return GetValue("COL20055821836"); } 
				set { SetValue("COL20055821836", value); } 
			}

			/// <summary>
			/// Gets field ApplicationPath 
			/// </summary>
			public string ApplicationPath { 
				get { return GetValue("COL200558218310"); } 
				set { SetValue("COL200558218310", value); } 
			}

			/// <summary>
			/// Gets field EventType 
			/// </summary>
			public string EventType { 
				get { return GetValue("COL20055821834"); } 
				set { SetValue("COL20055821834", value); } 
			}

			/// <summary>
			/// Gets field Details 
			/// </summary>
			public string Details { 
				get { return GetValue("COL200558218315"); } 
				set { SetValue("COL200558218315", value); } 
			}

			/// <summary>
			/// Gets field RequestUrl 
			/// </summary>
			public string RequestUrl { 
				get { return GetValue("COL200558218313"); } 
				set { SetValue("COL200558218313", value); } 
			}

			/// <summary>
			/// Gets field EventCode 
			/// </summary>
			public string EventCode { 
				get { return GetValue("COL20055821837"); } 
				set { SetValue("COL20055821837", value); } 
			}

			/// <summary>
			/// Gets field EventTimeUtc 
			/// </summary>
			public string EventTimeUtc { 
				get { return GetValue("COL20055821832"); } 
				set { SetValue("COL20055821832", value); } 
			}

			/// <summary>
			/// Gets field EventDetailCode 
			/// </summary>
			public string EventDetailCode { 
				get { return GetValue("COL20055821838"); } 
				set { SetValue("COL20055821838", value); } 
			}


			/// <summary>
			/// Gets EventSequence attribute data 
			/// </summary>
			public AttributeData GetEventSequenceAttributeData() { 
				return GetAttributeData("COL20055821835"); 
			}

			/// <summary>
			/// Gets ApplicationVirtualPath attribute data 
			/// </summary>
			public AttributeData GetApplicationVirtualPathAttributeData() { 
				return GetAttributeData("COL200558218311"); 
			}

			/// <summary>
			/// Gets ExceptionType attribute data 
			/// </summary>
			public AttributeData GetExceptionTypeAttributeData() { 
				return GetAttributeData("COL200558218314"); 
			}

			/// <summary>
			/// Gets EventTime attribute data 
			/// </summary>
			public AttributeData GetEventTimeAttributeData() { 
				return GetAttributeData("COL20055821833"); 
			}

			/// <summary>
			/// Gets Message attribute data 
			/// </summary>
			public AttributeData GetMessageAttributeData() { 
				return GetAttributeData("COL20055821839"); 
			}

			/// <summary>
			/// Gets MachineName attribute data 
			/// </summary>
			public AttributeData GetMachineNameAttributeData() { 
				return GetAttributeData("COL200558218312"); 
			}

			/// <summary>
			/// Gets EventId attribute data 
			/// </summary>
			public AttributeData GetEventIdAttributeData() { 
				return GetAttributeData("COL20055821831"); 
			}

			/// <summary>
			/// Gets EventOccurrence attribute data 
			/// </summary>
			public AttributeData GetEventOccurrenceAttributeData() { 
				return GetAttributeData("COL20055821836"); 
			}

			/// <summary>
			/// Gets ApplicationPath attribute data 
			/// </summary>
			public AttributeData GetApplicationPathAttributeData() { 
				return GetAttributeData("COL200558218310"); 
			}

			/// <summary>
			/// Gets EventType attribute data 
			/// </summary>
			public AttributeData GetEventTypeAttributeData() { 
				return GetAttributeData("COL20055821834"); 
			}

			/// <summary>
			/// Gets Details attribute data 
			/// </summary>
			public AttributeData GetDetailsAttributeData() { 
				return GetAttributeData("COL200558218315"); 
			}

			/// <summary>
			/// Gets RequestUrl attribute data 
			/// </summary>
			public AttributeData GetRequestUrlAttributeData() { 
				return GetAttributeData("COL200558218313"); 
			}

			/// <summary>
			/// Gets EventCode attribute data 
			/// </summary>
			public AttributeData GetEventCodeAttributeData() { 
				return GetAttributeData("COL20055821837"); 
			}

			/// <summary>
			/// Gets EventTimeUtc attribute data 
			/// </summary>
			public AttributeData GetEventTimeUtcAttributeData() { 
				return GetAttributeData("COL20055821832"); 
			}

			/// <summary>
			/// Gets EventDetailCode attribute data 
			/// </summary>
			public AttributeData GetEventDetailCodeAttributeData() { 
				return GetAttributeData("COL20055821838"); 
			}


			/// <summary>
			/// Gets column EventSequence with alias  
			/// </summary>
			public string ColEventSequence { 
				get { return GetColumnName("COL20055821835"); } 
			}

			/// <summary>
			/// Gets column ApplicationVirtualPath with alias  
			/// </summary>
			public string ColApplicationVirtualPath { 
				get { return GetColumnName("COL200558218311"); } 
			}

			/// <summary>
			/// Gets column ExceptionType with alias  
			/// </summary>
			public string ColExceptionType { 
				get { return GetColumnName("COL200558218314"); } 
			}

			/// <summary>
			/// Gets column EventTime with alias  
			/// </summary>
			public string ColEventTime { 
				get { return GetColumnName("COL20055821833"); } 
			}

			/// <summary>
			/// Gets column Message with alias  
			/// </summary>
			public string ColMessage { 
				get { return GetColumnName("COL20055821839"); } 
			}

			/// <summary>
			/// Gets column MachineName with alias  
			/// </summary>
			public string ColMachineName { 
				get { return GetColumnName("COL200558218312"); } 
			}

			/// <summary>
			/// Gets column EventId with alias  
			/// </summary>
			public string ColEventId { 
				get { return GetColumnName("COL20055821831"); } 
			}

			/// <summary>
			/// Gets column EventOccurrence with alias  
			/// </summary>
			public string ColEventOccurrence { 
				get { return GetColumnName("COL20055821836"); } 
			}

			/// <summary>
			/// Gets column ApplicationPath with alias  
			/// </summary>
			public string ColApplicationPath { 
				get { return GetColumnName("COL200558218310"); } 
			}

			/// <summary>
			/// Gets column EventType with alias  
			/// </summary>
			public string ColEventType { 
				get { return GetColumnName("COL20055821834"); } 
			}

			/// <summary>
			/// Gets column Details with alias  
			/// </summary>
			public string ColDetails { 
				get { return GetColumnName("COL200558218315"); } 
			}

			/// <summary>
			/// Gets column RequestUrl with alias  
			/// </summary>
			public string ColRequestUrl { 
				get { return GetColumnName("COL200558218313"); } 
			}

			/// <summary>
			/// Gets column EventCode with alias  
			/// </summary>
			public string ColEventCode { 
				get { return GetColumnName("COL20055821837"); } 
			}

			/// <summary>
			/// Gets column EventTimeUtc with alias  
			/// </summary>
			public string ColEventTimeUtc { 
				get { return GetColumnName("COL20055821832"); } 
			}

			/// <summary>
			/// Gets column EventDetailCode with alias  
			/// </summary>
			public string ColEventDetailCode { 
				get { return GetColumnName("COL20055821838"); } 
			}


			/// <summary>
			/// Checks whether column EventSequence is added in select statement 
			/// </summary>
			public bool IsSelectEventSequence { 
				get { return IsSelect("COL20055821835"); } 
				set { SetSelect("COL20055821835", value); } 
			}

			/// <summary>
			/// Checks whether column ApplicationVirtualPath is added in select statement 
			/// </summary>
			public bool IsSelectApplicationVirtualPath { 
				get { return IsSelect("COL200558218311"); } 
				set { SetSelect("COL200558218311", value); } 
			}

			/// <summary>
			/// Checks whether column ExceptionType is added in select statement 
			/// </summary>
			public bool IsSelectExceptionType { 
				get { return IsSelect("COL200558218314"); } 
				set { SetSelect("COL200558218314", value); } 
			}

			/// <summary>
			/// Checks whether column EventTime is added in select statement 
			/// </summary>
			public bool IsSelectEventTime { 
				get { return IsSelect("COL20055821833"); } 
				set { SetSelect("COL20055821833", value); } 
			}

			/// <summary>
			/// Checks whether column Message is added in select statement 
			/// </summary>
			public bool IsSelectMessage { 
				get { return IsSelect("COL20055821839"); } 
				set { SetSelect("COL20055821839", value); } 
			}

			/// <summary>
			/// Checks whether column MachineName is added in select statement 
			/// </summary>
			public bool IsSelectMachineName { 
				get { return IsSelect("COL200558218312"); } 
				set { SetSelect("COL200558218312", value); } 
			}

			/// <summary>
			/// Checks whether column EventId is added in select statement 
			/// </summary>
			public bool IsSelectEventId { 
				get { return IsSelect("COL20055821831"); } 
				set { SetSelect("COL20055821831", value); } 
			}

			/// <summary>
			/// Checks whether column EventOccurrence is added in select statement 
			/// </summary>
			public bool IsSelectEventOccurrence { 
				get { return IsSelect("COL20055821836"); } 
				set { SetSelect("COL20055821836", value); } 
			}

			/// <summary>
			/// Checks whether column ApplicationPath is added in select statement 
			/// </summary>
			public bool IsSelectApplicationPath { 
				get { return IsSelect("COL200558218310"); } 
				set { SetSelect("COL200558218310", value); } 
			}

			/// <summary>
			/// Checks whether column EventType is added in select statement 
			/// </summary>
			public bool IsSelectEventType { 
				get { return IsSelect("COL20055821834"); } 
				set { SetSelect("COL20055821834", value); } 
			}

			/// <summary>
			/// Checks whether column Details is added in select statement 
			/// </summary>
			public bool IsSelectDetails { 
				get { return IsSelect("COL200558218315"); } 
				set { SetSelect("COL200558218315", value); } 
			}

			/// <summary>
			/// Checks whether column RequestUrl is added in select statement 
			/// </summary>
			public bool IsSelectRequestUrl { 
				get { return IsSelect("COL200558218313"); } 
				set { SetSelect("COL200558218313", value); } 
			}

			/// <summary>
			/// Checks whether column EventCode is added in select statement 
			/// </summary>
			public bool IsSelectEventCode { 
				get { return IsSelect("COL20055821837"); } 
				set { SetSelect("COL20055821837", value); } 
			}

			/// <summary>
			/// Checks whether column EventTimeUtc is added in select statement 
			/// </summary>
			public bool IsSelectEventTimeUtc { 
				get { return IsSelect("COL20055821832"); } 
				set { SetSelect("COL20055821832", value); } 
			}

			/// <summary>
			/// Checks whether column EventDetailCode is added in select statement 
			/// </summary>
			public bool IsSelectEventDetailCode { 
				get { return IsSelect("COL20055821838"); } 
				set { SetSelect("COL20055821838", value); } 
			}



	}
}