using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Text;

namespace Common.Logging.Simple;

/// <summary>
/// A <see cref="T:System.Diagnostics.TraceListener" /> implementation sending all <see cref="T:System.Diagnostics.Trace">System.Diagnostics.Trace</see> output to 
/// the Common.Logging infrastructure.
/// </summary>
/// <remarks>
/// This listener captures all output sent by calls to <see cref="T:System.Diagnostics.Trace">System.Diagnostics.Trace</see> and
/// and <see cref="T:System.Diagnostics.TraceSource" /> and sends it to an <see cref="T:Common.Logging.ILog" /> instance.<br />
/// The <see cref="T:Common.Logging.ILog" /> instance to be used is obtained by calling
/// <see cref="M:Common.Logging.LogManager.GetLogger(System.String)" />. The name of the logger is created by passing 
/// this listener's <see cref="P:System.Diagnostics.TraceListener.Name" /> and any <c>source</c> or <c>category</c> passed 
/// into this listener (see <see cref="M:System.Diagnostics.TraceListener.WriteLine(System.Object,System.String)" /> or <see cref="M:System.Diagnostics.TraceListener.TraceEvent(System.Diagnostics.TraceEventCache,System.String,System.Diagnostics.TraceEventType,System.Int32,System.String,System.Object[])" /> for example).
/// </remarks>
/// <example>
/// The snippet below shows how to add and configure this listener to your app.config:
/// <code lang="XML">
/// &lt;system.diagnostics&gt;
///   &lt;sharedListeners&gt;
///     &lt;add name="Diagnostics"
///          type="Common.Logging.Simple.CommonLoggingTraceListener, Common.Logging"
///          initializeData="DefaultTraceEventType=Information; LoggerNameFormat={listenerName}.{sourceName}"&gt;
///       &lt;filter type="System.Diagnostics.EventTypeFilter" initializeData="Information"/&gt;
///     &lt;/add&gt;
///   &lt;/sharedListeners&gt;
///   &lt;trace&gt;
///     &lt;listeners&gt;
///       &lt;add name="Diagnostics" /&gt;
///     &lt;/listeners&gt;
///   &lt;/trace&gt;
/// &lt;/system.diagnostics&gt;
/// </code>
/// </example>
/// <author>Erich Eichinger</author>
public class CommonLoggingTraceListener : TraceListener
{
	private TraceEventType _defaultTraceEventType = TraceEventType.Verbose;

	private string _loggerNameFormat = "{listenerName}.{sourceName}";

	/// <summary>
	/// Sets the default <see cref="T:System.Diagnostics.TraceEventType" /> to use for logging
	/// all events emitted by <see cref="T:System.Diagnostics.Trace" /><c>.Write(...)</c> and
	/// <see cref="T:System.Diagnostics.Trace" /><c>.WriteLine(...)</c> methods.
	/// </summary>
	/// <remarks>
	/// This listener captures all output sent by calls to <see cref="T:System.Diagnostics.Trace" /> and
	/// sends it to an <see cref="T:Common.Logging.ILog" /> instance using the <see cref="T:Common.Logging.LogLevel" /> specified
	/// on <see cref="T:Common.Logging.LogLevel" />.
	/// </remarks>
	public TraceEventType DefaultTraceEventType
	{
		get
		{
			return _defaultTraceEventType;
		}
		set
		{
			_defaultTraceEventType = value;
		}
	}

	/// <summary>
	/// Format to use for creating the logger name. Defaults to "{listenerName}.{sourceName}".
	/// </summary>
	/// <remarks>
	/// Available placeholders are:
	/// <list type="bullet">
	/// <item>{listenerName}: the configured name of this listener instance.</item>
	/// <item>{sourceName}: the trace source name an event originates from (see e.g. <see cref="M:System.Diagnostics.TraceListener.TraceEvent(System.Diagnostics.TraceEventCache,System.String,System.Diagnostics.TraceEventType,System.Int32,System.String,System.Object[])" />.</item>
	/// </list>
	/// </remarks>
	public string LoggerNameFormat
	{
		get
		{
			return _loggerNameFormat;
		}
		set
		{
			_loggerNameFormat = value;
		}
	}

	/// <summary>
	/// Creates a new instance with the default name "Diagnostics" and <see cref="T:Common.Logging.LogLevel" /> "Trace".
	/// </summary>
	public CommonLoggingTraceListener()
		: this(string.Empty)
	{
	}

	/// <summary>
	/// Creates a new instance initialized with properties from the <paramref name="initializeData" />. string.
	/// </summary>
	/// <remarks>
	/// <paramref name="initializeData" /> is a semicolon separated string of name/value pairs, where each pair has
	/// the form <c>key=value</c>. E.g.
	/// "<c>Name=MyLoggerName;LogLevel=Debug</c>"
	/// </remarks>
	/// <param name="initializeData">a semicolon separated list of name/value pairs.</param>
	public CommonLoggingTraceListener(string initializeData)
		: this(GetPropertiesFromInitString(initializeData))
	{
	}

	/// <summary>
	/// Creates a new instance initialized with the specified properties.
	/// </summary>
	/// <param name="properties">name/value configuration properties.</param>
	public CommonLoggingTraceListener(NameValueCollection properties)
	{
		if (properties == null)
		{
			properties = new NameValueCollection();
		}
		ApplyProperties(properties);
	}

	private void ApplyProperties(NameValueCollection props)
	{
		if (props["defaultTraceEventType"] != null)
		{
			_defaultTraceEventType = (TraceEventType)Enum.Parse(typeof(TraceEventType), props["defaultTraceEventType"], ignoreCase: true);
		}
		else
		{
			_defaultTraceEventType = TraceEventType.Verbose;
		}
		if (props["name"] != null)
		{
			Name = props["name"];
		}
		else
		{
			Name = "Diagnostics";
		}
		if (props["loggerNameFormat"] != null)
		{
			LoggerNameFormat = props["loggerNameFormat"];
		}
		else
		{
			LoggerNameFormat = "{listenerName}.{sourceName}";
		}
	}

	/// <summary>
	/// Logs the given message to the Common.Logging infrastructure.
	/// </summary>
	/// <param name="eventType">the eventType</param>
	/// <param name="source">the <see cref="T:System.Diagnostics.TraceSource" /> name or category name passed into e.g. <see cref="M:System.Diagnostics.Trace.Write(System.Object,System.String)" />.</param>
	/// <param name="id">the id of this event</param>
	/// <param name="format">the message format</param>
	/// <param name="args">the message arguments</param>
	protected virtual void Log(TraceEventType eventType, string source, int id, string format, params object[] args)
	{
		source = LoggerNameFormat.Replace("{listenerName}", Name).Replace("{sourceName}", source ?? "");
		ILog log = LogManager.GetLogger(source);
		switch (MapLogLevel(eventType))
		{
		case LogLevel.Trace:
			log.TraceFormat(format, args);
			break;
		case LogLevel.Debug:
			log.DebugFormat(format, args);
			break;
		case LogLevel.Info:
			log.InfoFormat(format, args);
			break;
		case LogLevel.Warn:
			log.WarnFormat(format, args);
			break;
		case LogLevel.Error:
			log.ErrorFormat(format, args);
			break;
		case LogLevel.Fatal:
			log.FatalFormat(format, args);
			break;
		default:
			throw new ArgumentOutOfRangeException("eventType", eventType, "invalid TraceEventType value");
		case LogLevel.Off:
			break;
		}
	}

	private static NameValueCollection GetPropertiesFromInitString(string initializeData)
	{
		NameValueCollection props = new NameValueCollection();
		if (initializeData == null)
		{
			return props;
		}
		string[] parts = initializeData.Split(';');
		string[] array = parts;
		foreach (string s in array)
		{
			string part = s.Trim();
			if (part.Length != 0)
			{
				int ixEquals = part.IndexOf('=');
				if (ixEquals > -1)
				{
					string name = part.Substring(0, ixEquals).Trim();
					string value = ((ixEquals < part.Length - 1) ? part.Substring(ixEquals + 1) : string.Empty);
					props[name] = value.Trim();
				}
				else
				{
					props[part.Trim()] = null;
				}
			}
		}
		return props;
	}

	/// <summary>
	/// Writes message to logger provided by <see cref="M:Common.Logging.LogManager.GetLogger(System.String)" />.
	/// </summary>
	public override void Write(object o)
	{
		if (base.Filter == null || base.Filter.ShouldTrace(null, Name, DefaultTraceEventType, 0, null, null, o, null))
		{
			Log(DefaultTraceEventType, null, 0, "{0}", o);
		}
	}

	/// <summary>
	/// Writes message to logger provided by <see cref="M:Common.Logging.LogManager.GetLogger(System.String)" />.
	/// </summary>
	public override void Write(object o, string category)
	{
		if (base.Filter == null || base.Filter.ShouldTrace(null, Name, DefaultTraceEventType, 0, null, null, o, null))
		{
			Log(DefaultTraceEventType, category, 0, "{0}", o);
		}
	}

	/// <summary>
	/// Writes message to logger provided by <see cref="M:Common.Logging.LogManager.GetLogger(System.String)" />.
	/// </summary>
	public override void Write(string message)
	{
		if (base.Filter == null || base.Filter.ShouldTrace(null, Name, DefaultTraceEventType, 0, null, null, null, null))
		{
			Log(DefaultTraceEventType, null, 0, message);
		}
	}

	/// <summary>
	/// Writes message to logger provided by <see cref="M:Common.Logging.LogManager.GetLogger(System.String)" />.
	/// </summary>
	public override void Write(string message, string category)
	{
		if (base.Filter == null || base.Filter.ShouldTrace(null, Name, DefaultTraceEventType, 0, null, null, null, null))
		{
			Log(DefaultTraceEventType, category, 0, message);
		}
	}

	/// <summary>
	/// Writes message to logger provided by <see cref="M:Common.Logging.LogManager.GetLogger(System.String)" />.
	/// </summary>
	public override void WriteLine(object o)
	{
		if (base.Filter == null || base.Filter.ShouldTrace(null, Name, DefaultTraceEventType, 0, null, null, o, null))
		{
			Log(DefaultTraceEventType, null, 0, "{0}", o);
		}
	}

	/// <summary>
	/// Writes message to logger provided by <see cref="M:Common.Logging.LogManager.GetLogger(System.String)" />.
	/// </summary>
	public override void WriteLine(object o, string category)
	{
		if (base.Filter == null || base.Filter.ShouldTrace(null, Name, DefaultTraceEventType, 0, null, null, o, null))
		{
			Log(DefaultTraceEventType, category, 0, "{0}", o);
		}
	}

	/// <summary>
	/// Writes message to logger provided by <see cref="M:Common.Logging.LogManager.GetLogger(System.String)" />.
	/// </summary>
	public override void WriteLine(string message)
	{
		if (base.Filter == null || base.Filter.ShouldTrace(null, Name, DefaultTraceEventType, 0, null, null, null, null))
		{
			Log(DefaultTraceEventType, null, 0, message);
		}
	}

	/// <summary>
	/// Writes message to logger provided by <see cref="M:Common.Logging.LogManager.GetLogger(System.String)" />
	/// </summary>
	public override void WriteLine(string message, string category)
	{
		if (base.Filter == null || base.Filter.ShouldTrace(null, Name, DefaultTraceEventType, 0, null, null, null, null))
		{
			Log(DefaultTraceEventType, category, 0, message);
		}
	}

	/// <summary>
	/// Writes message to logger provided by <see cref="M:Common.Logging.LogManager.GetLogger(System.String)" />
	/// </summary>
	public override void TraceEvent(TraceEventCache eventCache, string source, TraceEventType eventType, int id)
	{
		if (base.Filter == null || base.Filter.ShouldTrace(eventCache, source, eventType, id, null, null, null, null))
		{
			Log(eventType, source, id, "Event Id {0}", id);
		}
	}

	/// <summary>
	/// Writes message to logger provided by <see cref="M:Common.Logging.LogManager.GetLogger(System.String)" />
	/// </summary>
	public override void TraceEvent(TraceEventCache eventCache, string source, TraceEventType eventType, int id, string message)
	{
		if (base.Filter == null || base.Filter.ShouldTrace(eventCache, source, eventType, id, message, null, null, null))
		{
			Log(eventType, source, id, message);
		}
	}

	/// <summary>
	/// Writes message to logger provided by <see cref="M:Common.Logging.LogManager.GetLogger(System.String)" />
	/// </summary>
	public override void TraceEvent(TraceEventCache eventCache, string source, TraceEventType eventType, int id, string message, params object[] args)
	{
		if (base.Filter == null || base.Filter.ShouldTrace(eventCache, source, eventType, id, message, args, null, null))
		{
			Log(eventType, source, id, message, args);
		}
	}

	/// <summary>
	/// Writes message to logger provided by <see cref="M:Common.Logging.LogManager.GetLogger(System.String)" />
	/// </summary>
	public override void TraceData(TraceEventCache eventCache, string source, TraceEventType eventType, int id, params object[] data)
	{
		if (base.Filter == null || base.Filter.ShouldTrace(eventCache, source, eventType, id, null, null, null, data))
		{
			string fmt = GetFormat(data);
			Log(eventType, source, id, fmt, data);
		}
	}

	/// <summary>
	/// Writes message to logger provided by <see cref="M:Common.Logging.LogManager.GetLogger(System.String)" />
	/// </summary>
	public override void TraceData(TraceEventCache eventCache, string source, TraceEventType eventType, int id, object data)
	{
		if (base.Filter == null || base.Filter.ShouldTrace(eventCache, source, eventType, id, null, null, data, null))
		{
			string fmt = GetFormat(data);
			Log(eventType, source, id, fmt, data);
		}
	}

	private string GetFormat(params object[] data)
	{
		if (data == null || data.Length == 0)
		{
			return null;
		}
		StringBuilder fmt = new StringBuilder();
		for (int i = 0; i < data.Length; i++)
		{
			fmt.Append('{').Append(i).Append('}');
			if (i < data.Length - 1)
			{
				fmt.Append(',');
			}
		}
		return fmt.ToString();
	}

	private LogLevel MapLogLevel(TraceEventType eventType)
	{
		switch (eventType)
		{
		case TraceEventType.Start:
		case TraceEventType.Stop:
		case TraceEventType.Suspend:
		case TraceEventType.Resume:
		case TraceEventType.Transfer:
			return LogLevel.Trace;
		case TraceEventType.Verbose:
			return LogLevel.Debug;
		case TraceEventType.Information:
			return LogLevel.Info;
		case TraceEventType.Warning:
			return LogLevel.Warn;
		case TraceEventType.Error:
			return LogLevel.Error;
		case TraceEventType.Critical:
			return LogLevel.Fatal;
		default:
			return LogLevel.Trace;
		}
	}
}
