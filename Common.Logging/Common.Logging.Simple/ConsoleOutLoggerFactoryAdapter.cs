using System.Collections.Specialized;

namespace Common.Logging.Simple;

/// <summary>
/// Factory for creating <see cref="T:Common.Logging.ILog" /> instances that write data to <see cref="P:System.Console.Out" />.
/// </summary>
/// <remarks>
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
///       &lt;factoryAdapter type="Common.Logging.Simple.ConsoleOutLoggerFactoryAdapter, Common.Logging"&gt;
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
public class ConsoleOutLoggerFactoryAdapter : AbstractSimpleLoggerFactoryAdapter
{
	/// <summary>
	/// Initializes a new instance of the <see cref="T:Common.Logging.Simple.ConsoleOutLoggerFactoryAdapter" /> class using default 
	/// settings.
	/// </summary>
	public ConsoleOutLoggerFactoryAdapter()
		: base(null)
	{
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="T:Common.Logging.Simple.ConsoleOutLoggerFactoryAdapter" /> class.
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
	public ConsoleOutLoggerFactoryAdapter(NameValueCollection properties)
		: base(properties)
	{
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="T:Common.Logging.Simple.AbstractSimpleLoggerFactoryAdapter" /> class with 
	/// default settings for the loggers created by this factory.
	/// </summary>
	public ConsoleOutLoggerFactoryAdapter(LogLevel level, bool showDateTime, bool showLogName, bool showLevel, string dateTimeFormat)
		: base(level, showDateTime, showLogName, showLevel, dateTimeFormat)
	{
	}

	/// <summary>
	/// Creates a new <see cref="T:Common.Logging.Simple.ConsoleOutLogger" /> instance.
	/// </summary>
	protected override ILog CreateLogger(string name, LogLevel level, bool showLevel, bool showDateTime, bool showLogName, string dateTimeFormat)
	{
		return new ConsoleOutLogger(name, level, showLevel, showDateTime, showLogName, dateTimeFormat);
	}
}
