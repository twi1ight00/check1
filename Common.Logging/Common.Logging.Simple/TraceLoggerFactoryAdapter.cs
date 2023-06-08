using System.Collections.Specialized;
using Common.Logging.Configuration;

namespace Common.Logging.Simple;

/// <summary>
/// Factory for creating <see cref="T:Common.Logging.ILog" /> instances that send 
/// everything to the <see cref="T:System.Diagnostics.Trace" /> output stream.
/// </summary>
/// <remarks>
/// Beware not to use <see cref="T:Common.Logging.Simple.CommonLoggingTraceListener" /> in combination with this logger factory
/// as this would result in an endless loop for obvious reasons!
/// <example>
/// Below is an example how to configure this adapter:
/// <code>
/// &lt;configuration&gt;
///
///   &lt;configSections&gt;
///     &lt;sectionGroup name="common"&gt;
///       &lt;section name="logging"
///                type="Common.Logging.ConfigurationSectionHandler, Common.Logging"
///                requirePermission="false" /&gt;
///     &lt;/sectionGroup&gt;
///   &lt;/configSections&gt;
///
///   &lt;common&gt;
///     &lt;logging&gt;
///       &lt;factoryAdapter type="Common.Logging.Simple.TraceLoggerFactoryAdapter, Common.Logging"&gt;
///         &lt;arg key="level" value="ALL" /&gt;
///       &lt;/factoryAdapter&gt;
///     &lt;/logging&gt;
///   &lt;/common&gt;
///
/// &lt;/configuration&gt;
/// </code>
/// </example>
/// </remarks>
/// <seealso cref="T:Common.Logging.Simple.AbstractSimpleLoggerFactoryAdapter" />
/// <seealso cref="P:Common.Logging.LogManager.Adapter" />
/// <seealso cref="T:Common.Logging.ConfigurationSectionHandler" />
/// <author>Gilles Bayon</author>
/// <author>Mark Pollack</author>
/// <author>Erich Eichinger</author>
public class TraceLoggerFactoryAdapter : AbstractSimpleLoggerFactoryAdapter
{
	private bool _useTraceSource;

	/// <summary>
	/// Whether to use <see cref="T:System.Diagnostics.Trace" />.<c>TraceXXXX(string,object[])</c> methods for logging
	/// or <see cref="T:System.Diagnostics.TraceSource" />.
	/// </summary>
	[CoverageExclude]
	public bool UseTraceSource
	{
		get
		{
			return _useTraceSource;
		}
		set
		{
			_useTraceSource = value;
		}
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="T:Common.Logging.Simple.TraceLoggerFactoryAdapter" /> class using default settings.
	/// </summary>
	public TraceLoggerFactoryAdapter()
		: base(null)
	{
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="T:Common.Logging.Simple.TraceLoggerFactoryAdapter" /> class.
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
	public TraceLoggerFactoryAdapter(NameValueCollection properties)
		: base(properties)
	{
		_useTraceSource = ArgUtils.TryParse(defaultValue: false, properties["useTraceSource"]);
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="T:Common.Logging.Simple.AbstractSimpleLoggerFactoryAdapter" /> class with 
	/// default settings for the loggers created by this factory.
	/// </summary>
	public TraceLoggerFactoryAdapter(LogLevel level, bool showDateTime, bool showLogName, bool showLevel, string dateTimeFormat, bool useTraceSource)
		: base(level, showDateTime, showLogName, showLevel, dateTimeFormat)
	{
		_useTraceSource = useTraceSource;
	}

	/// <summary>
	/// Creates a new <see cref="T:Common.Logging.Simple.TraceLogger" /> instance.
	/// </summary>
	protected override ILog CreateLogger(string name, LogLevel level, bool showLevel, bool showDateTime, bool showLogName, string dateTimeFormat)
	{
		return new TraceLogger(_useTraceSource, name, level, showLevel, showDateTime, showLogName, dateTimeFormat);
	}
}
