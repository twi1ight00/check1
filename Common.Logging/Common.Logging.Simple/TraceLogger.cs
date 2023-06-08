#define TRACE
using System;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Text;

namespace Common.Logging.Simple;

/// <summary>
/// Logger sending everything to the trace output stream using <see cref="T:System.Diagnostics.Trace" />.
/// </summary>
/// <remarks>
/// Beware not to use <see cref="T:Common.Logging.Simple.CommonLoggingTraceListener" /> in combination with this logger as 
/// this would result in an endless loop for obvious reasons!
/// </remarks>
/// <seealso cref="P:Common.Logging.LogManager.Adapter" />
/// <seealso cref="T:Common.Logging.ConfigurationSectionHandler" />
/// <author>Gilles Bayon</author>
/// <author>Erich Eichinger</author>
[Serializable]
public class TraceLogger : AbstractSimpleLogger, IDeserializationCallback
{
	/// <summary>
	/// Used to defer message formatting until it is really needed.
	/// </summary>
	/// <remarks>
	/// This class also improves performance when multiple 
	/// <see cref="T:System.Diagnostics.TraceListener" />s are configured.
	/// </remarks>
	private class FormatOutputMessage
	{
		private readonly TraceLogger outer;

		private readonly LogLevel level;

		private readonly object message;

		private readonly Exception ex;

		public FormatOutputMessage(TraceLogger outer, LogLevel level, object message, Exception ex)
		{
			this.outer = outer;
			this.level = level;
			this.message = message;
			this.ex = ex;
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			outer.FormatOutput(sb, level, message, ex);
			return sb.ToString();
		}
	}

	private readonly bool _useTraceSource;

	[NonSerialized]
	private TraceSource _traceSource;

	/// <summary>
	/// Creates a new TraceLogger instance.
	/// </summary>
	/// <param name="useTraceSource">whether to use <see cref="T:System.Diagnostics.TraceSource" /> or <see cref="T:System.Diagnostics.Trace" /> for logging.</param>
	/// <param name="logName">the name of this logger</param>
	/// <param name="logLevel">the default log level to use</param>
	/// <param name="showLevel">Include the current log level in the log message.</param>
	/// <param name="showDateTime">Include the current time in the log message.</param>
	/// <param name="showLogName">Include the instance name in the log message.</param>
	/// <param name="dateTimeFormat">The date and time format to use in the log message.</param>
	public TraceLogger(bool useTraceSource, string logName, LogLevel logLevel, bool showLevel, bool showDateTime, bool showLogName, string dateTimeFormat)
		: base(logName, logLevel, showLevel, showDateTime, showLogName, dateTimeFormat)
	{
		_useTraceSource = useTraceSource;
		if (_useTraceSource)
		{
			_traceSource = new TraceSource(logName, Map2SourceLevel(logLevel));
		}
	}

	/// <summary>
	/// Determines if the given log level is currently enabled.
	/// checks <see cref="P:System.Diagnostics.TraceSource.Switch" /> if <see cref="P:Common.Logging.Simple.TraceLoggerFactoryAdapter.UseTraceSource" /> is true.
	/// </summary>
	protected override bool IsLevelEnabled(LogLevel level)
	{
		if (!_useTraceSource)
		{
			return base.IsLevelEnabled(level);
		}
		return _traceSource.Switch.ShouldTrace(Map2TraceEventType(level));
	}

	/// <summary>
	/// Do the actual logging.
	/// </summary>
	/// <param name="level"></param>
	/// <param name="message"></param>
	/// <param name="e"></param>
	protected override void WriteInternal(LogLevel level, object message, Exception e)
	{
		FormatOutputMessage msg = new FormatOutputMessage(this, level, message, e);
		if (_traceSource != null)
		{
			_traceSource.TraceEvent(Map2TraceEventType(level), 0, "{0}", msg);
			return;
		}
		switch (level)
		{
		case LogLevel.Info:
			System.Diagnostics.Trace.TraceInformation("{0}", msg);
			break;
		case LogLevel.Warn:
			System.Diagnostics.Trace.TraceWarning("{0}", msg);
			break;
		case LogLevel.Error:
		case LogLevel.Fatal:
			System.Diagnostics.Trace.TraceError("{0}", msg);
			break;
		default:
			System.Diagnostics.Trace.WriteLine(msg);
			break;
		}
	}

	private TraceEventType Map2TraceEventType(LogLevel logLevel)
	{
		return logLevel switch
		{
			LogLevel.Trace => TraceEventType.Verbose, 
			LogLevel.Debug => TraceEventType.Verbose, 
			LogLevel.Info => TraceEventType.Information, 
			LogLevel.Warn => TraceEventType.Warning, 
			LogLevel.Error => TraceEventType.Error, 
			LogLevel.Fatal => TraceEventType.Critical, 
			_ => (TraceEventType)0, 
		};
	}

	private SourceLevels Map2SourceLevel(LogLevel logLevel)
	{
		switch (logLevel)
		{
		case LogLevel.All:
		case LogLevel.Trace:
			return SourceLevels.All;
		case LogLevel.Debug:
			return SourceLevels.Verbose;
		case LogLevel.Info:
			return SourceLevels.Information;
		case LogLevel.Warn:
			return SourceLevels.Warning;
		case LogLevel.Error:
			return SourceLevels.Error;
		case LogLevel.Fatal:
			return SourceLevels.Critical;
		default:
			return SourceLevels.Off;
		}
	}

	/// <summary>
	/// Called after deserialization completed.
	/// </summary>
	public virtual void OnDeserialization(object sender)
	{
		if (_useTraceSource)
		{
			_traceSource = new TraceSource(base.Name, Map2SourceLevel(base.CurrentLogLevel));
		}
	}
}
