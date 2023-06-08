using System;
using System.Diagnostics;
using Common.Logging.Factory;
using log4net.Core;

namespace Common.Logging.Log4Net;

/// <summary>
/// Concrete implementation of <see cref="T:Common.Logging.ILog" /> interface specific to log4net 1.2.9-1.2.11.
/// </summary>
/// <remarks>
/// Log4net is capable of outputting extended debug information about where the current 
/// message was generated: class name, method name, file, line, etc. Log4net assumes that the location
/// information should be gathered relative to where Debug() was called. 
/// When using Common.Logging, Debug() is called in Common.Logging.Log4Net.Log4NetLogger. This means that
/// the location information will indicate that Common.Logging.Log4Net.Log4NetLogger always made
/// the call to Debug(). We need to know where Common.Logging.ILog.Debug()
/// was called. To do this we need to use the log4net.ILog.Logger.Log method and pass in a Type telling
/// log4net where in the stack to begin looking for location information.
/// </remarks>
/// <author>Gilles Bayon</author>
/// <author>Erich Eichinger</author>
[Serializable]
public class Log4NetLogger : AbstractLogger
{
	private readonly ILogger _logger;

	private static Type callerStackBoundaryType;

	/// <summary>
	///
	/// </summary>
	public override bool IsTraceEnabled => _logger.IsEnabledFor(Level.Trace);

	/// <summary>
	///
	/// </summary>
	public override bool IsDebugEnabled => _logger.IsEnabledFor(Level.Debug);

	/// <summary>
	///
	/// </summary>
	public override bool IsInfoEnabled => _logger.IsEnabledFor(Level.Info);

	/// <summary>
	///
	/// </summary>
	public override bool IsWarnEnabled => _logger.IsEnabledFor(Level.Warn);

	/// <summary>
	///
	/// </summary>
	public override bool IsErrorEnabled => _logger.IsEnabledFor(Level.Error);

	/// <summary>
	///
	/// </summary>
	public override bool IsFatalEnabled => _logger.IsEnabledFor(Level.Fatal);

	/// <summary>
	/// Constructor
	/// </summary>
	/// <param name="log"></param>
	protected internal Log4NetLogger(ILoggerWrapper log)
	{
		_logger = log.Logger;
	}

	/// <summary>
	/// Actually sends the message to the underlying log system.
	/// </summary>
	/// <param name="logLevel">the level of this log event.</param>
	/// <param name="message">the message to log</param>
	/// <param name="exception">the exception to log (may be null)</param>
	protected override void WriteInternal(LogLevel logLevel, object message, Exception exception)
	{
		if (callerStackBoundaryType == null)
		{
			lock (GetType())
			{
				StackTrace stack = new StackTrace();
				Type thisType = GetType();
				callerStackBoundaryType = typeof(AbstractLogger);
				for (int i = 1; i < stack.FrameCount; i++)
				{
					if (!IsInTypeHierarchy(thisType, stack.GetFrame(i).GetMethod().DeclaringType))
					{
						callerStackBoundaryType = stack.GetFrame(i - 1).GetMethod().DeclaringType;
						break;
					}
				}
			}
		}
		Level level = GetLevel(logLevel);
		_logger.Log(callerStackBoundaryType, level, message, exception);
	}

	private bool IsInTypeHierarchy(Type currentType, Type checkType)
	{
		while (currentType != null && currentType != typeof(object))
		{
			if (currentType == checkType)
			{
				return true;
			}
			currentType = currentType.BaseType;
		}
		return false;
	}

	/// <summary>
	/// Maps <see cref="T:Common.Logging.LogLevel" /> to log4net's <see cref="T:log4net.Core.Level" />
	/// </summary>
	/// <param name="logLevel"></param>
	public static Level GetLevel(LogLevel logLevel)
	{
		return logLevel switch
		{
			LogLevel.All => Level.All, 
			LogLevel.Trace => Level.Trace, 
			LogLevel.Debug => Level.Debug, 
			LogLevel.Info => Level.Info, 
			LogLevel.Warn => Level.Warn, 
			LogLevel.Error => Level.Error, 
			LogLevel.Fatal => Level.Fatal, 
			_ => throw new ArgumentOutOfRangeException("logLevel", logLevel, "unknown log level"), 
		};
	}
}
