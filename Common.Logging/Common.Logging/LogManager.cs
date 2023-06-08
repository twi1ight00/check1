#define TRACE
using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using Common.Logging.Configuration;
using Common.Logging.Simple;

namespace Common.Logging;

/// <summary>
/// Use the LogManager's <see cref="M:Common.Logging.LogManager.GetLogger(System.String)" /> or <see cref="M:Common.Logging.LogManager.GetLogger(System.Type)" /> 
/// methods to obtain <see cref="T:Common.Logging.ILog" /> instances for logging.
/// </summary>
/// <remarks>
/// For configuring the underlying log system using application configuration, see the example 
/// at <see cref="T:Common.Logging.ConfigurationSectionHandler" />. 
/// For configuring programmatically, see the example section below.
/// </remarks>
/// <example>
/// The example below shows the typical use of LogManager to obtain a reference to a logger
/// and log an exception:
/// <code>
///
/// ILog log = LogManager.GetLogger(this.GetType());
/// ...
/// try 
/// { 
///   /* .... */ 
/// }
/// catch(Exception ex)
/// {
///   log.ErrorFormat("Hi {0}", ex, "dude");
/// }
///
/// </code>
/// The example below shows programmatic configuration of the underlying log system:
/// <code>
///
/// // create properties
/// NameValueCollection properties = new NameValueCollection();
/// properties["showDateTime"] = "true";
///
/// // set Adapter
/// Common.Logging.LogManager.Adapter = new 
/// Common.Logging.Simple.ConsoleOutLoggerFactoryAdapter(properties);
///
/// </code>
/// </example>
/// <seealso cref="T:Common.Logging.ILog" />
/// <seealso cref="P:Common.Logging.LogManager.Adapter" />
/// <seealso cref="T:Common.Logging.ILoggerFactoryAdapter" />
/// <seealso cref="T:Common.Logging.ConfigurationSectionHandler" />
/// <author>Gilles Bayon</author>
public static class LogManager
{
	/// <summary>
	/// The name of the default configuration section to read settings from.
	/// </summary>
	/// <remarks>
	/// You can always change the source of your configuration settings by setting another <see cref="T:Common.Logging.IConfigurationReader" /> instance
	/// on <see cref="P:Common.Logging.LogManager.ConfigurationReader" />.
	/// </remarks>
	public static readonly string COMMON_LOGGING_SECTION;

	private static IConfigurationReader _configurationReader;

	private static ILoggerFactoryAdapter _adapter;

	private static readonly object _loadLock;

	/// <summary>
	/// Gets the configuration reader used to initialize the LogManager.
	/// </summary>
	/// <remarks>Primarily used for testing purposes but maybe useful to obtain configuration
	/// information from some place other than the .NET application configuration file.</remarks>
	/// <value>The configuration reader.</value>
	public static IConfigurationReader ConfigurationReader => _configurationReader;

	/// <summary>
	/// Gets or sets the adapter.
	/// </summary>
	/// <value>The adapter.</value>
	public static ILoggerFactoryAdapter Adapter
	{
		get
		{
			if (_adapter == null)
			{
				lock (_loadLock)
				{
					if (_adapter == null)
					{
						_adapter = BuildLoggerFactoryAdapter();
					}
				}
			}
			return _adapter;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("Adapter");
			}
			lock (_loadLock)
			{
				_adapter = value;
			}
		}
	}

	/// <summary>
	/// Performs static 1-time init of LogManager by calling <see cref="M:Common.Logging.LogManager.Reset" />
	/// </summary>
	static LogManager()
	{
		COMMON_LOGGING_SECTION = "common/logging";
		_loadLock = new object();
		Reset();
	}

	/// <summary>
	/// Reset the <see cref="N:Common.Logging" /> infrastructure to its default settings. This means, that configuration settings
	/// will be re-read from section <c>&lt;common/logging&gt;</c> of your <c>app.config</c>.
	/// </summary>
	/// <remarks>
	/// This is mainly used for unit testing, you wouldn't normally use this in your applications.<br />
	/// <b>Note:</b><see cref="T:Common.Logging.ILog" /> instances already handed out from this LogManager are not(!) affected. 
	/// Resetting LogManager only affects new instances being handed out.
	/// </remarks>
	public static void Reset()
	{
		Reset(new DefaultConfigurationReader());
	}

	/// <summary>
	/// Reset the <see cref="N:Common.Logging" /> infrastructure to its default settings. This means, that configuration settings
	/// will be re-read from section <c>&lt;common/logging&gt;</c> of your <c>app.config</c>.
	/// </summary>
	/// <remarks>
	/// This is mainly used for unit testing, you wouldn't normally use this in your applications.<br />
	/// <b>Note:</b><see cref="T:Common.Logging.ILog" /> instances already handed out from this LogManager are not(!) affected. 
	/// Resetting LogManager only affects new instances being handed out.
	/// </remarks>
	/// <param name="reader">
	/// the <see cref="T:Common.Logging.IConfigurationReader" /> instance to obtain settings for 
	/// re-initializing the LogManager.
	/// </param>
	public static void Reset(IConfigurationReader reader)
	{
		lock (_loadLock)
		{
			if (reader == null)
			{
				throw new ArgumentNullException("reader");
			}
			_configurationReader = reader;
			_adapter = null;
		}
	}

	/// <summary>
	/// Gets the logger by calling <see cref="M:Common.Logging.ILoggerFactoryAdapter.GetLogger(System.Type)" />
	/// on the currently configured <see cref="P:Common.Logging.LogManager.Adapter" /> using the type of the calling class.
	/// </summary>
	/// <remarks>
	/// This method needs to inspect the <see cref="T:System.Diagnostics.StackTrace" /> in order to determine the calling 
	/// class. This of course comes with a performance penalty, thus you shouldn't call it too
	/// often in your application.
	/// </remarks>
	/// <seealso cref="M:Common.Logging.LogManager.GetLogger(System.Type)" />
	/// <returns>the logger instance obtained from the current <see cref="P:Common.Logging.LogManager.Adapter" /></returns>
	[MethodImpl(MethodImplOptions.NoInlining)]
	public static ILog GetCurrentClassLogger()
	{
		StackFrame frame = new StackFrame(1, fNeedFileInfo: false);
		ILoggerFactoryAdapter adapter = Adapter;
		MethodBase method = frame.GetMethod();
		Type declaringType = method.DeclaringType;
		return adapter.GetLogger(declaringType);
	}

	/// <summary>
	/// Gets the logger by calling <see cref="M:Common.Logging.ILoggerFactoryAdapter.GetLogger(System.Type)" />
	/// on the currently configured <see cref="P:Common.Logging.LogManager.Adapter" /> using the specified type.
	/// </summary>
	/// <returns>the logger instance obtained from the current <see cref="P:Common.Logging.LogManager.Adapter" /></returns>
	public static ILog GetLogger<T>()
	{
		return Adapter.GetLogger(typeof(T));
	}

	/// <summary>
	/// Gets the logger by calling <see cref="M:Common.Logging.ILoggerFactoryAdapter.GetLogger(System.Type)" />
	/// on the currently configured <see cref="P:Common.Logging.LogManager.Adapter" /> using the specified type.
	/// </summary>
	/// <param name="type">The type.</param>
	/// <returns>the logger instance obtained from the current <see cref="P:Common.Logging.LogManager.Adapter" /></returns>
	public static ILog GetLogger(Type type)
	{
		return Adapter.GetLogger(type);
	}

	/// <summary>
	/// Gets the logger by calling <see cref="M:Common.Logging.ILoggerFactoryAdapter.GetLogger(System.String)" />
	/// on the currently configured <see cref="P:Common.Logging.LogManager.Adapter" /> using the specified name.
	/// </summary>
	/// <param name="name">The name.</param>
	/// <returns>the logger instance obtained from the current <see cref="P:Common.Logging.LogManager.Adapter" /></returns>
	public static ILog GetLogger(string name)
	{
		return Adapter.GetLogger(name);
	}

	/// <summary>
	/// Builds the logger factory adapter.
	/// </summary>
	/// <returns>a factory adapter instance. Is never <c>null</c>.</returns>
	private static ILoggerFactoryAdapter BuildLoggerFactoryAdapter()
	{
		object sectionResult = null;
		ArgUtils.Guard(delegate
		{
			sectionResult = ConfigurationReader.GetSection(COMMON_LOGGING_SECTION);
		}, "Failed obtaining configuration for Common.Logging from configuration section 'common/logging'.");
		if (sectionResult == null)
		{
			string message = ((ConfigurationReader.GetType() == typeof(DefaultConfigurationReader)) ? $"no configuration section <{COMMON_LOGGING_SECTION}> found - suppressing logging output" : $"Custom ConfigurationReader '{ConfigurationReader.GetType().FullName}' returned <null> - suppressing logging output");
			Trace.WriteLine(message);
			return new NoOpLoggerFactoryAdapter();
		}
		if (sectionResult is ILoggerFactoryAdapter)
		{
			Trace.WriteLine($"Using ILoggerFactoryAdapter returned from custom ConfigurationReader '{ConfigurationReader.GetType().FullName}'");
			return (ILoggerFactoryAdapter)sectionResult;
		}
		ArgUtils.Guard(delegate
		{
			ArgUtils.AssertIsAssignable<LogSetting>("sectionResult", sectionResult.GetType());
		}, "ConfigurationReader {0} returned unknown settings instance of type {1}", ConfigurationReader.GetType().FullName, sectionResult.GetType().FullName);
		ILoggerFactoryAdapter adapter = null;
		ArgUtils.Guard(delegate
		{
			adapter = BuildLoggerFactoryAdapterFromLogSettings((LogSetting)sectionResult);
		}, "Failed creating LoggerFactoryAdapter from settings");
		return adapter;
	}

	/// <summary>
	/// Builds a <see cref="T:Common.Logging.ILoggerFactoryAdapter" /> instance from the given <see cref="T:Common.Logging.Configuration.LogSetting" />
	/// using <see cref="T:System.Activator" />.
	/// </summary>
	/// <param name="setting"></param>
	/// <returns>the <see cref="T:Common.Logging.ILoggerFactoryAdapter" /> instance. Is never <c>null</c></returns>
	private static ILoggerFactoryAdapter BuildLoggerFactoryAdapterFromLogSettings(LogSetting setting)
	{
		ArgUtils.AssertNotNull("setting", setting);
		ILoggerFactoryAdapter adapter = null;
		ArgUtils.Guard(delegate
		{
			if (setting.Properties != null && setting.Properties.Count > 0)
			{
				object[] args = new object[1] { setting.Properties };
				adapter = (ILoggerFactoryAdapter)Activator.CreateInstance(setting.FactoryAdapterType, args);
			}
			else
			{
				adapter = (ILoggerFactoryAdapter)Activator.CreateInstance(setting.FactoryAdapterType);
			}
		}, "Unable to create instance of type {0}. Possible explanation is lack of zero arg and single arg NameValueCollection constructors", setting.FactoryAdapterType.FullName);
		ArgUtils.AssertNotNull("adapter", adapter, "Activator.CreateInstance() returned <null>");
		return adapter;
	}
}
