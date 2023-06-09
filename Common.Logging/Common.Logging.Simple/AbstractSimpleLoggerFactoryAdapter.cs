using System.Collections.Specialized;
using Common.Logging.Configuration;
using Common.Logging.Factory;

namespace Common.Logging.Simple;

/// <summary>
/// Base factory implementation for creating simple <see cref="T:Common.Logging.ILog" /> instances.
/// </summary>
/// <remarks>Default settings are LogLevel.All, showDateTime = true, showLogName = true, and no DateTimeFormat.
/// The keys in the NameValueCollection to configure this adapter are the following
/// <list type="bullet">
///     <item>level</item>
///     <item>showDateTime</item>
///     <item>showLogName</item>
///     <item>dateTimeFormat</item>
/// </list>
/// <example>
/// Here is an example how to implement your own logging adapter:
/// <code>
/// public class ConsoleOutLogger : AbstractSimpleLogger
/// {
///   public ConsoleOutLogger(string logName, LogLevel logLevel, bool showLevel, bool showDateTime, 
/// bool showLogName, string dateTimeFormat)
///       : base(logName, logLevel, showLevel, showDateTime, showLogName, dateTimeFormat)
///   {
///   }
///
///   protected override void WriteInternal(LogLevel level, object message, Exception e)
///   {
///       // Use a StringBuilder for better performance
///       StringBuilder sb = new StringBuilder();
///       FormatOutput(sb, level, message, e);
///
///       // Print to the appropriate destination
///       Console.Out.WriteLine(sb.ToString());
///   }
/// }
///
/// public class ConsoleOutLoggerFactoryAdapter : AbstractSimpleLoggerFactoryAdapter
/// {
///   public ConsoleOutLoggerFactoryAdapter(NameValueCollection properties)
///       : base(properties)
///   { }
///
///   protected override ILog CreateLogger(string name, LogLevel level, bool showLevel, bool 
/// showDateTime, bool showLogName, string dateTimeFormat)
///   {
///       ILog log = new ConsoleOutLogger(name, level, showLevel, showDateTime, showLogName, 
/// dateTimeFormat);
///       return log;
///   }
/// }
/// </code>
/// </example>
/// </remarks>
/// <seealso cref="P:Common.Logging.LogManager.Adapter" />
/// <seealso cref="T:Common.Logging.ConfigurationSectionHandler" />
/// <author>Gilles Bayon</author>
/// <author>Mark Pollack</author>
/// <author>Erich Eichinger</author>
public abstract class AbstractSimpleLoggerFactoryAdapter : AbstractCachingLoggerFactoryAdapter
{
	private LogLevel _level;

	private bool _showLevel;

	private bool _showDateTime;

	private bool _showLogName;

	private string _dateTimeFormat;

	/// <summary>
	/// The default <see cref="T:Common.Logging.LogLevel" /> to use when creating new <see cref="T:Common.Logging.ILog" /> instances.
	/// </summary>
	[CoverageExclude]
	public LogLevel Level
	{
		get
		{
			return _level;
		}
		set
		{
			_level = value;
		}
	}

	/// <summary>
	/// The default setting to use when creating new <see cref="T:Common.Logging.ILog" /> instances.
	/// </summary>
	[CoverageExclude]
	public bool ShowLevel
	{
		get
		{
			return _showLevel;
		}
		set
		{
			_showLevel = value;
		}
	}

	/// <summary>
	/// The default setting to use when creating new <see cref="T:Common.Logging.ILog" /> instances.
	/// </summary>
	[CoverageExclude]
	public bool ShowDateTime
	{
		get
		{
			return _showDateTime;
		}
		set
		{
			_showDateTime = value;
		}
	}

	/// <summary>
	/// The default setting to use when creating new <see cref="T:Common.Logging.ILog" /> instances.
	/// </summary>
	[CoverageExclude]
	public bool ShowLogName
	{
		get
		{
			return _showLogName;
		}
		set
		{
			_showLogName = value;
		}
	}

	/// <summary>
	/// The default setting to use when creating new <see cref="T:Common.Logging.ILog" /> instances.
	/// </summary>
	[CoverageExclude]
	public string DateTimeFormat
	{
		get
		{
			return _dateTimeFormat;
		}
		set
		{
			_dateTimeFormat = value;
		}
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="T:Common.Logging.Simple.AbstractSimpleLoggerFactoryAdapter" /> class.
	/// </summary>
	/// <remarks>
	/// Looks for level, showDateTime, showLogName, dateTimeFormat items from 
	/// <paramref name="properties" /> for use when the GetLogger methods are called.
	/// <see cref="T:Common.Logging.ConfigurationSectionHandler" /> for more information on how to use the 
	/// standard .NET application configuraiton file (App.config/Web.config) 
	/// to configure this adapter.
	/// </remarks>
	/// <param name="properties">The name value collection, typically specified by the user in 
	/// a configuration section named common/logging.</param>
	protected AbstractSimpleLoggerFactoryAdapter(NameValueCollection properties)
		: this(ArgUtils.TryParseEnum(LogLevel.All, ArgUtils.GetValue(properties, "level")), ArgUtils.TryParse(defaultValue: true, ArgUtils.GetValue(properties, "showDateTime")), ArgUtils.TryParse(defaultValue: true, ArgUtils.GetValue(properties, "showLogName")), ArgUtils.TryParse(defaultValue: true, ArgUtils.GetValue(properties, "showLevel")), ArgUtils.GetValue(properties, "dateTimeFormat", string.Empty))
	{
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="T:Common.Logging.Simple.AbstractSimpleLoggerFactoryAdapter" /> class with 
	/// default settings for the loggers created by this factory.
	/// </summary>
	protected AbstractSimpleLoggerFactoryAdapter(LogLevel level, bool showDateTime, bool showLogName, bool showLevel, string dateTimeFormat)
		: base(caseSensitiveLoggerCache: true)
	{
		_level = level;
		_showDateTime = showDateTime;
		_showLogName = showLogName;
		_showLevel = showLevel;
		_dateTimeFormat = dateTimeFormat ?? string.Empty;
	}

	/// <summary>
	/// Create the specified logger instance
	/// </summary>
	protected override ILog CreateLogger(string name)
	{
		return CreateLogger(name, _level, _showLevel, _showDateTime, _showLogName, _dateTimeFormat);
	}

	/// <summary>
	/// Derived factories need to implement this method to create the
	/// actual logger instance.
	/// </summary>
	/// <returns>a new logger instance. Must never be <c>null</c>!</returns>
	protected abstract ILog CreateLogger(string name, LogLevel level, bool showLevel, bool showDateTime, bool showLogName, string dateTimeFormat);
}
