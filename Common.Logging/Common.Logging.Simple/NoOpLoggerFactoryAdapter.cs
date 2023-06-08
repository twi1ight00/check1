using System;
using System.Collections.Specialized;

namespace Common.Logging.Simple;

/// <summary>
/// Factory for creating <see cref="T:Common.Logging.ILog" /> instances that silently ignores
/// logging requests.
/// </summary>
/// <remarks>
/// This logger adapter is the default used by Common.Logging if unconfigured. Using this logger adapter is the most efficient
/// way to suppress any logging output.
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
///       &lt;factoryAdapter type="Common.Logging.Simple.NoOpLoggerFactoryAdapter, Common.Logging"&gt;
///         &lt;arg key="level" value="ALL" /&gt;
///       &lt;/factoryAdapter&gt;
///     &lt;/logging&gt;
///   &lt;/common&gt;
///
/// &lt;/configuration&gt;
/// </code>
/// </example>
/// </remarks>
/// <seealso cref="P:Common.Logging.LogManager.Adapter" />
/// <seealso cref="T:Common.Logging.ConfigurationSectionHandler" />
/// <author>Gilles Bayon</author>
public sealed class NoOpLoggerFactoryAdapter : ILoggerFactoryAdapter
{
	private static readonly ILog s_nopLogger = new NoOpLogger();

	/// <summary>
	/// Constructor
	/// </summary>
	public NoOpLoggerFactoryAdapter()
	{
	}

	/// <summary>
	/// Constructor
	/// </summary>
	public NoOpLoggerFactoryAdapter(NameValueCollection properties)
	{
	}

	/// <summary>
	/// Get a ILog instance by type 
	/// </summary>
	/// <param name="type"></param>
	/// <returns></returns>
	public ILog GetLogger(Type type)
	{
		return s_nopLogger;
	}

	/// <summary>
	/// Get a ILog instance by type name 
	/// </summary>
	/// <param name="name"></param>
	/// <returns></returns>
	ILog ILoggerFactoryAdapter.GetLogger(string name)
	{
		return s_nopLogger;
	}
}
