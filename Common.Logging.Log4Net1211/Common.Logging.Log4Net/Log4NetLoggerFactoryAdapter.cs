using System;
using System.Collections.Specialized;
using System.IO;
using Common.Logging.Configuration;
using Common.Logging.Factory;
using log4net;
using log4net.Config;

namespace Common.Logging.Log4Net;

/// <summary>
/// Concrete subclass of ILoggerFactoryAdapter specific to log4net 1.2.9-1.2.11.
/// </summary>
/// <remarks>
/// The following configuration property values may be configured:
/// <list type="bullet">
///     <item><c>configType</c>: <c>INLINE|FILE|FILE-WATCH|EXTERNAL</c></item>
///     <item><c>configFile</c>: log4net configuration file path in case of FILE or FILE-WATCH</item>
/// </list>
/// The configType values have the following implications:
/// <list type="bullet">
///     <item>INLINE: simply calls <c>XmlConfigurator.Configure()</c></item>
///     <item>FILE: calls <c>XmlConfigurator.Configure(System.IO.FileInfo)</c> using <c>configFile</c>.</item>
///     <item>FILE-WATCH: calls <c>XmlConfigurator.ConfigureAndWatch(System.IO.FileInfo)</c> using <c>configFile</c>.</item>
///     <item>EXTERNAL: does nothing and expects log4net to be configured elsewhere.</item>
///     <item>&lt;any&gt;: calls <c>BasicConfigurator.Configure()</c></item>
/// </list>
/// </remarks>
/// <example>
/// The following snippet shows an example of how to configure log4net with Common.Logging:
/// <code>
/// &lt;configuration&gt;
///   &lt;configSections&gt;
///     &lt;sectionGroup name="common"&gt;
///       &lt;section name="logging"
///                type="Common.Logging.ConfigurationSectionHandler, Common.Logging"
///                requirePermission="false" /&gt;
///     &lt;/sectionGroup&gt;
///     &lt;section name="log4net"
///              type="log4net.Config.Log4NetConfigurationSectionHandler"
///              requirePermission="false" /&gt;
///   &lt;/configSections&gt;
///
///   &lt;common&gt;
///     &lt;logging&gt;
///       &lt;factoryAdapter type="Common.Logging.Log4Net.Log4NetLoggerFactoryAdapter, Common.Logging.Log4Net129"&gt;
///         &lt;arg key="level" value="ALL" /&gt;
///         &lt;arg key="configType" value="INLINE" /&gt;
///       &lt;/factoryAdapter&gt;
///     &lt;/logging&gt;
///   &lt;/common&gt;
///
///   &lt;log4net debug="false"&gt;
///
///     &lt;appender name="RollingLogFileAppender" type="log4net.Appender.RollingFileAppender, log4net"&gt;
///       &lt;param name="File" value="./Web.log" /&gt;
///       &lt;param name="AppendToFile" value="true" /&gt;
///       &lt;param name="MaxSizeRollBackups" value="1" /&gt;
///       &lt;param name="MaximumFileSize" value="1GB" /&gt;
///       &lt;param name="RollingStyle" value="Date" /&gt;
///       &lt;param name="StaticLogFileName" value="false" /&gt;
///
///       &lt;layout type="log4net.Layout.PatternLayout, log4net"&gt;
///         &lt;param name="ConversionPattern" value="%d [%t] %-5p %c - %m%n" /&gt;
///       &lt;/layout&gt;
///
///     &lt;/appender&gt;
///
///     &lt;appender name="TraceAppender" type="log4net.Appender.TraceAppender"&gt;
///       &lt;layout type="log4net.Layout.PatternLayout"&gt;
///         &lt;param name="ConversionPattern" value="%-5p: %m" /&gt;
///       &lt;/layout&gt;
///     &lt;/appender&gt;
///
///     &lt;root&gt;
///       &lt;level value="ALL" /&gt;
///       &lt;appender-ref ref="TraceAppender" /&gt;
///       &lt;appender-ref ref="RollingLogFileAppender" /&gt;
///     &lt;/root&gt;
///
///   &lt;/log4net&gt;
/// &lt;/configuration&gt;
/// </code>
/// </example>
/// <author>Gilles Bayon</author>
/// <author>Erich Eichinger</author>
public class Log4NetLoggerFactoryAdapter : AbstractCachingLoggerFactoryAdapter
{
	/// <summary>
	/// Abstract interface to the underlying log4net runtime
	/// </summary>
	public interface ILog4NetRuntime
	{
		/// <summary>Calls <see cref="M:log4net.Config.XmlConfigurator.Configure" /></summary>
		void XmlConfiguratorConfigure();

		/// <summary>Calls <see cref="M:log4net.Config.XmlConfigurator.Configure(System.IO.FileInfo)" /></summary>
		void XmlConfiguratorConfigure(string configFile);

		/// <summary>Calls <see cref="M:log4net.Config.XmlConfigurator.ConfigureAndWatch(System.IO.FileInfo)" /></summary>
		void XmlConfiguratorConfigureAndWatch(string configFile);

		/// <summary>Calls <see cref="M:log4net.Config.BasicConfigurator.Configure" /></summary>
		void BasicConfiguratorConfigure();

		/// <summary>Calls <see cref="M:Common.Logging.LogManager.GetLogger(System.String)" /></summary>
		log4net.ILog GetLogger(string name);
	}

	private class Log4NetRuntime : ILog4NetRuntime
	{
		public void XmlConfiguratorConfigure()
		{
			XmlConfigurator.Configure();
		}

		public void XmlConfiguratorConfigure(string configFile)
		{
			XmlConfigurator.Configure(new FileInfo(configFile));
		}

		public void XmlConfiguratorConfigureAndWatch(string configFile)
		{
			XmlConfigurator.ConfigureAndWatch(new FileInfo(configFile));
		}

		public void BasicConfiguratorConfigure()
		{
			BasicConfigurator.Configure();
		}

		public log4net.ILog GetLogger(string name)
		{
			return log4net.LogManager.GetLogger(name);
		}
	}

	private readonly ILog4NetRuntime _runtime;

	/// <summary>
	/// Constructor
	/// </summary>
	/// <param name="properties">configuration properties, see <see cref="T:Common.Logging.Log4Net.Log4NetLoggerFactoryAdapter" /> for more.</param>
	public Log4NetLoggerFactoryAdapter(NameValueCollection properties)
		: this(properties, new Log4NetRuntime())
	{
	}

	/// <summary>
	/// Constructor accepting configuration properties and an arbitrary 
	/// <see cref="T:Common.Logging.Log4Net.Log4NetLoggerFactoryAdapter.ILog4NetRuntime" /> instance.
	/// </summary>
	/// <param name="properties">configuration properties, see <see cref="T:Common.Logging.Log4Net.Log4NetLoggerFactoryAdapter" /> for more.</param>
	/// <param name="runtime">a log4net runtime adapter</param>
	protected Log4NetLoggerFactoryAdapter(NameValueCollection properties, ILog4NetRuntime runtime)
		: base(caseSensitiveLoggerCache: true)
	{
		if (runtime == null)
		{
			throw new ArgumentNullException("runtime");
		}
		_runtime = runtime;
		string configType = ArgUtils.GetValue(properties, "configType", string.Empty).ToUpper();
		string configFile = ArgUtils.GetValue(properties, "configFile", string.Empty);
		if (configFile.StartsWith("~/") || configFile.StartsWith("~\\"))
		{
			configFile = $"{AppDomain.CurrentDomain.BaseDirectory.TrimEnd('/', '\\')}/{configFile.Substring(2)}";
		}
		if (configType == "FILE" || configType == "FILE-WATCH")
		{
			if (configFile == string.Empty)
			{
				throw new ConfigurationException("Configuration property 'configFile' must be set for log4Net configuration of type 'FILE' or 'FILE-WATCH'.");
			}
			if (!File.Exists(configFile))
			{
				throw new ConfigurationException("log4net configuration file '" + configFile + "' does not exists");
			}
		}
		switch (configType)
		{
		case "INLINE":
			_runtime.XmlConfiguratorConfigure();
			break;
		case "FILE":
			_runtime.XmlConfiguratorConfigure(configFile);
			break;
		case "FILE-WATCH":
			_runtime.XmlConfiguratorConfigureAndWatch(configFile);
			break;
		default:
			_runtime.BasicConfiguratorConfigure();
			break;
		case "EXTERNAL":
			break;
		}
	}

	/// <summary>
	/// Create a ILog instance by name 
	/// </summary>
	/// <param name="name"></param>
	/// <returns></returns>
	protected override ILog CreateLogger(string name)
	{
		return new Log4NetLogger(_runtime.GetLogger(name));
	}
}
