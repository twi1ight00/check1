using System;
using System.Collections.Generic;
using System.IO;
using Common.Logging.Configuration;
using log4net.Appender;
using log4net.Core;
using log4net.Layout;

namespace Common.Logging.Log4Net;

/// <summary>
/// Routes log events to Common.Logging infrastructure.
/// </summary>
/// <example>
/// To route all events logged using log4net to Common.Logging, you need to configure this appender as shown below:
/// <code>
/// &lt;log4net&gt;
///     &lt;appender name="CommonLoggingAppender" 
///               type="Common.Logging.Log4Net.CommonLoggingAppender, Common.Logging.Log4Net129"&gt;
///         &lt;layout type="log4net.Layout.PatternLayout, log4net"&gt;
///             &lt;param name="ConversionPattern" value="%level - %class.%method: %message" /&gt;
///         &lt;/layout&gt;
///     &lt;/appender&gt;
///
///     &lt;root&gt;
///         &lt;level value="ALL" /&gt;
///         &lt;appender-ref ref="CommonLoggingAppender" /&gt;
///     &lt;/root&gt;
/// &lt;/log4net&gt;
/// </code>
/// </example>
/// <author>Erich Eichinger</author>
public class CommonLoggingAppender : AppenderSkeleton
{
	/// <summary>
	/// Wrapper class that prevents exceptions from being rendered in the message
	/// </summary>
	private class ExceptionAwareLayout : ILayout
	{
		public readonly ILayout InnerLayout;

		public string ContentType => InnerLayout.ContentType;

		public string Header => InnerLayout.Header;

		public string Footer => InnerLayout.Footer;

		public bool IgnoresException => false;

		public ExceptionAwareLayout(ILayout inner)
		{
			InnerLayout = inner;
		}

		public void Format(TextWriter writer, LoggingEvent loggingEvent)
		{
			InnerLayout.Format(writer, loggingEvent);
		}
	}

	private delegate string MessageFormatter();

	private delegate void LogMethod(ILog logger, MessageFormatter fmtr, Exception exception);

	private static readonly Dictionary<Level, LogMethod> logMethods;

	/// <summary>
	///  Get or set the layout for this appender
	/// </summary>
	public override ILayout Layout
	{
		get
		{
			if (!(base.Layout is ExceptionAwareLayout))
			{
				return base.Layout;
			}
			return ((ExceptionAwareLayout)base.Layout).InnerLayout;
		}
		set
		{
			ArgUtils.AssertNotNull("Layout", value);
			if (!(value is ExceptionAwareLayout))
			{
				value = new ExceptionAwareLayout(value);
			}
			base.Layout = value;
		}
	}

	static CommonLoggingAppender()
	{
		logMethods = new Dictionary<Level, LogMethod>();
		logMethods[Level.Trace] = delegate(ILog log, MessageFormatter msg, Exception ex)
		{
			log.Trace(delegate(FormatMessageHandler m)
			{
				m(msg());
			}, ex);
		};
		logMethods[Level.Debug] = delegate(ILog log, MessageFormatter msg, Exception ex)
		{
			log.Debug(delegate(FormatMessageHandler m)
			{
				m(msg());
			}, ex);
		};
		logMethods[Level.Info] = delegate(ILog log, MessageFormatter msg, Exception ex)
		{
			log.Info(delegate(FormatMessageHandler m)
			{
				m(msg());
			}, ex);
		};
		logMethods[Level.Warn] = delegate(ILog log, MessageFormatter msg, Exception ex)
		{
			log.Warn(delegate(FormatMessageHandler m)
			{
				m(msg());
			}, ex);
		};
		logMethods[Level.Error] = delegate(ILog log, MessageFormatter msg, Exception ex)
		{
			log.Error(delegate(FormatMessageHandler m)
			{
				m(msg());
			}, ex);
		};
		logMethods[Level.Fatal] = delegate(ILog log, MessageFormatter msg, Exception ex)
		{
			log.Fatal(delegate(FormatMessageHandler m)
			{
				m(msg());
			}, ex);
		};
		logMethods[Level.All] = logMethods[Level.Trace];
		logMethods[Level.Off] = delegate
		{
		};
	}

	/// <summary>
	/// Gets the closest level supported by Common.Logging of the given log4net level
	/// </summary>
	protected static Level GetClosestLevel(Level currentLevel)
	{
		if (currentLevel.Equals(Level.Off))
		{
			return Level.Off;
		}
		if (currentLevel.Equals(Level.All))
		{
			return Level.All;
		}
		if (currentLevel >= Level.Fatal)
		{
			return Level.Fatal;
		}
		if (currentLevel >= Level.Error)
		{
			return Level.Error;
		}
		if (currentLevel >= Level.Warn)
		{
			return Level.Warn;
		}
		if (currentLevel >= Level.Info)
		{
			return Level.Info;
		}
		if (currentLevel >= Level.Debug)
		{
			return Level.Debug;
		}
		if (currentLevel >= Level.Trace)
		{
			return Level.Trace;
		}
		return Level.All;
	}

	/// <summary>
	/// Sends the given log event to Common.Logging
	/// </summary>
	protected override void Append(LoggingEvent loggingEvent)
	{
		ILog logger = LogManager.GetLogger(loggingEvent.LoggerName);
		Level logLevel = GetClosestLevel(loggingEvent.Level);
		LogMethod log = logMethods[logLevel];
		loggingEvent.Fix = FixFlags.LocationInfo;
		log(logger, () => RenderLoggingEvent(loggingEvent), loggingEvent.ExceptionObject);
	}
}
