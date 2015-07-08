namespace Man
{
	using System;
	using System.Configuration;
	using System.Diagnostics;
	using System.IO;
	using System.Text;
	using System.Threading;
    
	/// <summary>
	///     Logging class to provide tracing and logging support. 
	///     <remarks>
	///         There are four different logging levels (error, warning, info, trace) 
	///         that produce output to either the system event log or a tracing 
	///         file as specified in the current ApplicationConfiguration settings.
	///     </remarks>
	/// </summary>
	public class ApplicationLog
	{
    
		//
		// Shared member variables
		//
        
		//     TraceSwitch for changing which values are actually written to the
		//     trace output file.
		private static TraceSwitch debugSwitch;

		//This object is added as a debug listener.
		private static StreamWriter debugWriter;
        
		//EventLog variables used for the trace level if the event log is specified.
		//private static TraceLevel eventLogTraceLevel;
        
		/// <summary>
		///     Write at the Error level to the event log and/or tracing file.
		///     <param name="message">The text to write to the log file or event log.</param>
		/// </summary>
		public static void WriteError(String message)
		{
			//Defer to the helper function to log the message.
			WriteLog(TraceLevel.Error, message);
		}

		/// <summary>
		/// Write log based on exception information
		/// </summary>
		/// <param name="ex"></param>
		/// <param name="catchInfo"></param>
		public static void WriteError(Exception ex, string catchInfo)
		{
			WriteLog(TraceLevel.Error, FormatException(ex, catchInfo));
		}
				
		/// <summary>
		/// Write log based on exception information
		/// </summary>
		/// <param name="ex"></param>
		public static void WriteError(Exception ex)
		{
			WriteLog(TraceLevel.Error, FormatException(ex, string.Empty));
		}
        
		/// <summary>
		///     Write at the Warning level to the event log and/or tracing file.
		///     <param name="message">The text to write to the log file or event log.</param>
		/// </summary>
		public static void WriteWarning(String message)
		{
			//Defer to the helper function to log the message.
			WriteLog(TraceLevel.Warning, message);
		}
        
		/// <summary>
		///     Write at the Info level to the event log and/or tracing file.
		///     <param name="message">The text to write to the log file or event log.</param>
		/// </summary>
		public static void WriteInfo(String message)
		{
			//Defer to the helper function to log the message.
			WriteLog(TraceLevel.Info, message);
		}
        
		/// <summary>
		///     Write at the Verbose level to the event log and/or tracing file.
		///     <param name="message">The text to write to the log file or event log.</param>
		/// </summary>
		public static void WriteTrace(String message)
		{
			//Defer to the helper function to log the message.
			WriteLog(TraceLevel.Verbose, message);
		}
        
		/// <summary>
		///     Write at the Verbose level to the event log and/or tracing file.
		///     <param name="ex">The Exception object to format</param>
		///     <param name="catchInfo">The string to prepend to the exception information.</param>
		///     <retvalue>
		///         <para>A nicely format exception string, including message and StackTrace information.</para>
		///     </retvalue>
		/// </summary>
		public static String FormatException(Exception e, String catchInfo)
		{
			StackTrace stacktrace = new StackTrace(e, true);
			if ( stacktrace.FrameCount <= 0 )
				return string.Empty;

			string logline = "{0} : {1} : {2} : {3} : {4} : {5}";
			StackFrame stackframe = stacktrace.GetFrame(0);

			StringBuilder summaryError = new StringBuilder();

			if (catchInfo != String.Empty)
			{
				summaryError.Append(catchInfo).Append("\r\n");
			}
			summaryError.Append("\r\n");
			summaryError.Append(e.Message);
			summaryError.Append("\r\n");
			summaryError.Append("[BeginLogEx] \r\n");
			summaryError.AppendFormat(logline, DateTime.Now.ToString("t"), stackframe.GetFileName(), stackframe.GetMethod().Name, stackframe.GetFileLineNumber(), e.Message, "");
			summaryError.Append("\r\n");
			summaryError.Append("[Exceptions] \r\n");
			string exceptionLineFormat = "{0}: {1} \r\n";
			Exception tempE = e;
			while ( tempE != null ) 
			{
				summaryError.AppendFormat(exceptionLineFormat, tempE.GetType().Name, tempE.Message);
				tempE = tempE.InnerException;
			}
			summaryError.Append("[BeginStackTrace]\r\n");
			summaryError.Append(e.StackTrace);
			summaryError.Append("\r\n");
			summaryError.Append("[EndStackTrace]\r\n");
			summaryError.Append("[EndLogEx] \r\n");
			summaryError.Append("-----------------------------");

			return summaryError.ToString();
		}
        
		/// <summary>
		///     Determine where a string needs to be written based on the
		///     configuration settings and the error level.
		///     <param name="level">The severity of the information to be logged.</param>
		///     <param name="messageText">The string to be logged.</param>
		/// </summary>
		private static void WriteLog(TraceLevel level, String messageText)
		{
			//
			// Be very careful by putting a Try/Catch around the entire routine.
			//   We should never throw an exception while logging.
			//
			try
			{
				//
				// Write the message to the trace file
				//
        
				//Make sure a tracing file is specified.
				if (debugWriter != null)
				{
					//Log based on switch level.
					if (level <= debugSwitch.Level)
					{
						lock(debugWriter)
						{
							Debug.WriteLine(messageText);
							debugWriter.Flush();
						}
					}
				}
        
				//
				// Write the message to the system event log. We only write the message
				//   if the configuration settings say it is severe enough to warrant
				//   an entry in the event log.
				//
				//Thao  if (level <= eventLogTraceLevel)
			{
				//
				// Map the trace level to the corresponding event log attribute.
				//   Note that EventLogEntryType = 2 ^ (level - 1), but it is generally not
				//   considered good style to apply arithmetic operations to enum values.
				EventLogEntryType LogEntryType;
				switch (level)
				{
					case TraceLevel.Error:
						LogEntryType = EventLogEntryType.Error;
						break;
					case TraceLevel.Warning:
						LogEntryType = EventLogEntryType.Warning;
						break;
					case TraceLevel.Info:
						LogEntryType = EventLogEntryType.Information;
						break;
					case TraceLevel.Verbose:
						LogEntryType = EventLogEntryType.SuccessAudit;
						break;
					default:
						LogEntryType = EventLogEntryType.SuccessAudit;
						break;
				}
                string sourceName = "MoneSource";
                //create source if not exists
                if (!EventLog.SourceExists(sourceName))
                {
                    EventLog.CreateEventSource(sourceName, "Application");
                }
            
				EventLog eventLog = new EventLog("Application", ".", sourceName);
				//Write the entry to the event log
				eventLog.WriteEntry(messageText, LogEntryType);
			}
			}
			catch {} //Ignore any exceptions.
		}
        
		/// <summary>
		///     Constructor for ApplicationLog.  
		///     <remarks>Initialize all shared variables based on the ApplicationConfigurationsettings. 
		///         Called when this class is first loaded.
		///     </remarks>
		/// </summary>
		static ApplicationLog()
		{
			//
			// Read the current settings from the configuration file to determine
			//   whether we need trace file support, event logging, or both.
			//
        
			//Get the class object in order to take the initialization lock
			Type myType = typeof(ApplicationLog);
        
			//Protect thread locks with Try/Catch to guarantee that we let go of the lock.
			try
			{
				//See if anyone else is using the lock, grab it if they//re not
				if (!Monitor.TryEnter(myType))
				{
					//Just wait until the other thread finishes processing, then leave if
					//  the lock was already in use.
					Monitor.Enter(myType);
					return;
				}
        
				//See if there is a debug configuration file specified and set up the
				//  tracing variables.
				bool clearSettings = true;
				try
				{
					//Thao, always check trace enable
					//Make sure we have a TraceSettings file.
					String tracingFile = string.Format("{0}{1}{2}.{3}", Gnt.Configuration.ApplicationConfiguration.LogPath, Path.DirectorySeparatorChar, System.DateTime.Today.ToString("yyyyMMdd"), "log");

					if (tracingFile != String.Empty)
					{
    
						//Read in the tracing switch name and create the switch.
						String switchName = "GNTSwitch";
    
						//Create the new switch
						if (switchName != String.Empty)
						{
							//Create a debug listener and add it as a debug listener
							FileInfo file = new FileInfo(tracingFile);
							debugWriter = new StreamWriter(file.Open(FileMode.Append, FileAccess.Write, FileShare.ReadWrite));
							Debug.Listeners.Add(new TextWriterTraceListener(debugWriter));
        
							debugSwitch = new TraceSwitch(switchName, "Switch description");
							debugSwitch.Level = TraceLevel.Error;
						}
						clearSettings = false;
					}						
				}
				catch
				{
					//Ignore the error
				}
            
				//Use default (empty) values if something went wrong
				if (clearSettings)
				{
					//Tracing information is off or not properly specified, clear it
					debugSwitch = null;
					debugWriter = null;
				}
				//
				//				if(ApplicationConfiguration.TracingEnabled)
				//					//eventLogTraceLevel = ApplicationConfiguration.EventLogTraceLevel;
				//				else 
				//					eventLogTraceLevel = TraceLevel.Off;
			}
			finally
			{
				//Remove the lock from the class object
				Monitor.Exit(myType);
			}
		}
    
	} //class ApplicationLog
} 
