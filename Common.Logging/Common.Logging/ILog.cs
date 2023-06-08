using System;

namespace Common.Logging;

/// <summary>
/// A simple logging interface abstracting logging APIs. 
/// </summary>
/// <remarks>
/// <para>
/// Implementations should defer calling a message's <see cref="M:System.Object.ToString" /> until the message really needs
/// to be logged to avoid performance penalties.
/// </para>
/// <para>
/// Each <see cref="T:Common.Logging.ILog" /> log method offers to pass in a <see cref="T:System.Action`1" /> instead of the actual message.
/// Using this style has the advantage to defer possibly expensive message argument evaluation and formatting (and formatting arguments!) until the message gets
/// actually logged. If the message is not logged at all (e.g. due to <see cref="T:Common.Logging.LogLevel" /> settings), 
/// you won't have to pay the peformance penalty of creating the message.
/// </para>
/// </remarks>
/// <example>
/// The example below demonstrates using callback style for creating the message, where the call to the 
/// <see cref="M:System.Random.NextDouble" /> and the underlying <see cref="M:System.String.Format(System.String,System.Object[])" /> only happens, if level <see cref="F:Common.Logging.LogLevel.Debug" /> is enabled:
/// <code>
/// Log.Debug( m=&gt;m("result is {0}", random.NextDouble()) );
/// Log.Debug(delegate(m) { m("result is {0}", random.NextDouble()); });
/// </code>
/// </example>
/// <seealso cref="T:System.Action`1" />
/// <author>Mark Pollack</author>
/// <author>Bruno Baia</author>
/// <author>Erich Eichinger</author>
public interface ILog
{
	/// <summary>
	/// Checks if this logger is enabled for the <see cref="F:Common.Logging.LogLevel.Trace" /> level.
	/// </summary>
	bool IsTraceEnabled { get; }

	/// <summary>
	/// Checks if this logger is enabled for the <see cref="F:Common.Logging.LogLevel.Debug" /> level.
	/// </summary>
	bool IsDebugEnabled { get; }

	/// <summary>
	/// Checks if this logger is enabled for the <see cref="F:Common.Logging.LogLevel.Error" /> level.
	/// </summary>
	bool IsErrorEnabled { get; }

	/// <summary>
	/// Checks if this logger is enabled for the <see cref="F:Common.Logging.LogLevel.Fatal" /> level.
	/// </summary>
	bool IsFatalEnabled { get; }

	/// <summary>
	/// Checks if this logger is enabled for the <see cref="F:Common.Logging.LogLevel.Info" /> level.
	/// </summary>
	bool IsInfoEnabled { get; }

	/// <summary>
	/// Checks if this logger is enabled for the <see cref="F:Common.Logging.LogLevel.Warn" /> level.
	/// </summary>
	bool IsWarnEnabled { get; }

	/// <summary>
	/// Log a message object with the <see cref="F:Common.Logging.LogLevel.Trace" /> level.
	/// </summary>
	/// <param name="message">The message object to log.</param>
	void Trace(object message);

	/// <summary>
	/// Log a message object with the <see cref="F:Common.Logging.LogLevel.Trace" /> level including
	/// the stack trace of the <see cref="T:System.Exception" /> passed
	/// as a parameter.
	/// </summary>
	/// <param name="message">The message object to log.</param>
	/// <param name="exception">The exception to log, including its stack trace.</param>
	void Trace(object message, Exception exception);

	/// <summary>
	/// Log a message with the <see cref="F:Common.Logging.LogLevel.Trace" /> level.
	/// </summary>
	/// <param name="format">The format of the message object to log.<see cref="M:System.String.Format(System.String,System.Object[])" /> </param>
	/// <param name="args">the list of format arguments</param>
	void TraceFormat(string format, params object[] args);

	/// <summary>
	/// Log a message with the <see cref="F:Common.Logging.LogLevel.Trace" /> level.
	/// </summary>
	/// <param name="format">The format of the message object to log.<see cref="M:System.String.Format(System.String,System.Object[])" /> </param>
	/// <param name="exception">The exception to log.</param>
	/// <param name="args">the list of format arguments</param>
	void TraceFormat(string format, Exception exception, params object[] args);

	/// <summary>
	/// Log a message with the <see cref="F:Common.Logging.LogLevel.Trace" /> level.
	/// </summary>
	/// <param name="formatProvider">An <see cref="T:System.IFormatProvider" /> that supplies culture-specific formatting information.</param>
	/// <param name="format">The format of the message object to log.<see cref="M:System.String.Format(System.String,System.Object[])" /> </param>
	/// <param name="args"></param>
	void TraceFormat(IFormatProvider formatProvider, string format, params object[] args);

	/// <summary>
	/// Log a message with the <see cref="F:Common.Logging.LogLevel.Trace" /> level.
	/// </summary>
	/// <param name="formatProvider">An <see cref="T:System.IFormatProvider" /> that supplies culture-specific formatting information.</param>
	/// <param name="format">The format of the message object to log.<see cref="M:System.String.Format(System.String,System.Object[])" /> </param>
	/// <param name="exception">The exception to log.</param>
	/// <param name="args"></param>
	void TraceFormat(IFormatProvider formatProvider, string format, Exception exception, params object[] args);

	/// <summary>
	/// Log a message with the <see cref="F:Common.Logging.LogLevel.Trace" /> level using a callback to obtain the message
	/// </summary>
	/// <remarks>
	/// Using this method avoids the cost of creating a message and evaluating message arguments 
	/// that probably won't be logged due to loglevel settings.
	/// </remarks>
	/// <param name="formatMessageCallback">A callback used by the logger to obtain the message if log level is matched</param>
	void Trace(Action<FormatMessageHandler> formatMessageCallback);

	/// <summary>
	/// Log a message with the <see cref="F:Common.Logging.LogLevel.Trace" /> level using a callback to obtain the message
	/// </summary>
	/// <remarks>
	/// Using this method avoids the cost of creating a message and evaluating message arguments 
	/// that probably won't be logged due to loglevel settings.
	/// </remarks>
	/// <param name="formatMessageCallback">A callback used by the logger to obtain the message if log level is matched</param>
	/// <param name="exception">The exception to log, including its stack trace.</param>
	void Trace(Action<FormatMessageHandler> formatMessageCallback, Exception exception);

	/// <summary>
	/// Log a message with the <see cref="F:Common.Logging.LogLevel.Trace" /> level using a callback to obtain the message
	/// </summary>
	/// <remarks>
	/// Using this method avoids the cost of creating a message and evaluating message arguments 
	/// that probably won't be logged due to loglevel settings.
	/// </remarks>
	/// <param name="formatProvider">An <see cref="T:System.IFormatProvider" /> that supplies culture-specific formatting information.</param>
	/// <param name="formatMessageCallback">A callback used by the logger to obtain the message if log level is matched</param>
	void Trace(IFormatProvider formatProvider, Action<FormatMessageHandler> formatMessageCallback);

	/// <summary>
	/// Log a message with the <see cref="F:Common.Logging.LogLevel.Trace" /> level using a callback to obtain the message
	/// </summary>
	/// <remarks>
	/// Using this method avoids the cost of creating a message and evaluating message arguments 
	/// that probably won't be logged due to loglevel settings.
	/// </remarks>
	/// <param name="formatProvider">An <see cref="T:System.IFormatProvider" /> that supplies culture-specific formatting information.</param>
	/// <param name="formatMessageCallback">A callback used by the logger to obtain the message if log level is matched</param>
	/// <param name="exception">The exception to log, including its stack trace.</param>
	void Trace(IFormatProvider formatProvider, Action<FormatMessageHandler> formatMessageCallback, Exception exception);

	/// <summary>
	/// Log a message object with the <see cref="F:Common.Logging.LogLevel.Debug" /> level.
	/// </summary>
	/// <param name="message">The message object to log.</param>
	void Debug(object message);

	/// <summary>
	/// Log a message object with the <see cref="F:Common.Logging.LogLevel.Debug" /> level including
	/// the stack trace of the <see cref="T:System.Exception" /> passed
	/// as a parameter.
	/// </summary>
	/// <param name="message">The message object to log.</param>
	/// <param name="exception">The exception to log, including its stack trace.</param>
	void Debug(object message, Exception exception);

	/// <summary>
	/// Log a message with the <see cref="F:Common.Logging.LogLevel.Debug" /> level.
	/// </summary>
	/// <param name="format">The format of the message object to log.<see cref="M:System.String.Format(System.String,System.Object[])" /> </param>
	/// <param name="args">the list of format arguments</param>
	void DebugFormat(string format, params object[] args);

	/// <summary>
	/// Log a message with the <see cref="F:Common.Logging.LogLevel.Debug" /> level.
	/// </summary>
	/// <param name="format">The format of the message object to log.<see cref="M:System.String.Format(System.String,System.Object[])" /> </param>
	/// <param name="exception">The exception to log.</param>
	/// <param name="args">the list of format arguments</param>
	void DebugFormat(string format, Exception exception, params object[] args);

	/// <summary>
	/// Log a message with the <see cref="F:Common.Logging.LogLevel.Debug" /> level.
	/// </summary>
	/// <param name="formatProvider">An <see cref="T:System.IFormatProvider" /> that supplies culture-specific formatting information.</param>
	/// <param name="format">The format of the message object to log.<see cref="M:System.String.Format(System.String,System.Object[])" /> </param>
	/// <param name="args"></param>
	void DebugFormat(IFormatProvider formatProvider, string format, params object[] args);

	/// <summary>
	/// Log a message with the <see cref="F:Common.Logging.LogLevel.Debug" /> level.
	/// </summary>
	/// <param name="formatProvider">An <see cref="T:System.IFormatProvider" /> that supplies culture-specific formatting information.</param>
	/// <param name="format">The format of the message object to log.<see cref="M:System.String.Format(System.String,System.Object[])" /> </param>
	/// <param name="exception">The exception to log.</param>
	/// <param name="args"></param>
	void DebugFormat(IFormatProvider formatProvider, string format, Exception exception, params object[] args);

	/// <summary>
	/// Log a message with the <see cref="F:Common.Logging.LogLevel.Debug" /> level using a callback to obtain the message
	/// </summary>
	/// <remarks>
	/// Using this method avoids the cost of creating a message and evaluating message arguments 
	/// that probably won't be logged due to loglevel settings.
	/// </remarks>
	/// <param name="formatMessageCallback">A callback used by the logger to obtain the message if log level is matched</param>
	void Debug(Action<FormatMessageHandler> formatMessageCallback);

	/// <summary>
	/// Log a message with the <see cref="F:Common.Logging.LogLevel.Debug" /> level using a callback to obtain the message
	/// </summary>
	/// <remarks>
	/// Using this method avoids the cost of creating a message and evaluating message arguments 
	/// that probably won't be logged due to loglevel settings.
	/// </remarks>
	/// <param name="formatMessageCallback">A callback used by the logger to obtain the message if log level is matched</param>
	/// <param name="exception">The exception to log, including its stack trace.</param>
	void Debug(Action<FormatMessageHandler> formatMessageCallback, Exception exception);

	/// <summary>
	/// Log a message with the <see cref="F:Common.Logging.LogLevel.Debug" /> level using a callback to obtain the message
	/// </summary>
	/// <remarks>
	/// Using this method avoids the cost of creating a message and evaluating message arguments 
	/// that probably won't be logged due to loglevel settings.
	/// </remarks>
	/// <param name="formatProvider">An <see cref="T:System.IFormatProvider" /> that supplies culture-specific formatting information.</param>
	/// <param name="formatMessageCallback">A callback used by the logger to obtain the message if log level is matched</param>
	void Debug(IFormatProvider formatProvider, Action<FormatMessageHandler> formatMessageCallback);

	/// <summary>
	/// Log a message with the <see cref="F:Common.Logging.LogLevel.Debug" /> level using a callback to obtain the message
	/// </summary>
	/// <remarks>
	/// Using this method avoids the cost of creating a message and evaluating message arguments 
	/// that probably won't be logged due to loglevel settings.
	/// </remarks>
	/// <param name="formatProvider">An <see cref="T:System.IFormatProvider" /> that supplies culture-specific formatting information.</param>
	/// <param name="formatMessageCallback">A callback used by the logger to obtain the message if log level is matched</param>
	/// <param name="exception">The exception to log, including its stack Debug.</param>
	void Debug(IFormatProvider formatProvider, Action<FormatMessageHandler> formatMessageCallback, Exception exception);

	/// <summary>
	/// Log a message object with the <see cref="F:Common.Logging.LogLevel.Info" /> level.
	/// </summary>
	/// <param name="message">The message object to log.</param>
	void Info(object message);

	/// <summary>
	/// Log a message object with the <see cref="F:Common.Logging.LogLevel.Info" /> level including
	/// the stack trace of the <see cref="T:System.Exception" /> passed
	/// as a parameter.
	/// </summary>
	/// <param name="message">The message object to log.</param>
	/// <param name="exception">The exception to log, including its stack trace.</param>
	void Info(object message, Exception exception);

	/// <summary>
	/// Log a message with the <see cref="F:Common.Logging.LogLevel.Info" /> level.
	/// </summary>
	/// <param name="format">The format of the message object to log.<see cref="M:System.String.Format(System.String,System.Object[])" /> </param>
	/// <param name="args">the list of format arguments</param>
	void InfoFormat(string format, params object[] args);

	/// <summary>
	/// Log a message with the <see cref="F:Common.Logging.LogLevel.Info" /> level.
	/// </summary>
	/// <param name="format">The format of the message object to log.<see cref="M:System.String.Format(System.String,System.Object[])" /> </param>
	/// <param name="exception">The exception to log.</param>
	/// <param name="args">the list of format arguments</param>
	void InfoFormat(string format, Exception exception, params object[] args);

	/// <summary>
	/// Log a message with the <see cref="F:Common.Logging.LogLevel.Info" /> level.
	/// </summary>
	/// <param name="formatProvider">An <see cref="T:System.IFormatProvider" /> that supplies culture-specific formatting information.</param>
	/// <param name="format">The format of the message object to log.<see cref="M:System.String.Format(System.String,System.Object[])" /> </param>
	/// <param name="args"></param>
	void InfoFormat(IFormatProvider formatProvider, string format, params object[] args);

	/// <summary>
	/// Log a message with the <see cref="F:Common.Logging.LogLevel.Info" /> level.
	/// </summary>
	/// <param name="formatProvider">An <see cref="T:System.IFormatProvider" /> that supplies culture-specific formatting information.</param>
	/// <param name="format">The format of the message object to log.<see cref="M:System.String.Format(System.String,System.Object[])" /> </param>
	/// <param name="exception">The exception to log.</param>
	/// <param name="args"></param>
	void InfoFormat(IFormatProvider formatProvider, string format, Exception exception, params object[] args);

	/// <summary>
	/// Log a message with the <see cref="F:Common.Logging.LogLevel.Info" /> level using a callback to obtain the message
	/// </summary>
	/// <remarks>
	/// Using this method avoids the cost of creating a message and evaluating message arguments 
	/// that probably won't be logged due to loglevel settings.
	/// </remarks>
	/// <param name="formatMessageCallback">A callback used by the logger to obtain the message if log level is matched</param>
	void Info(Action<FormatMessageHandler> formatMessageCallback);

	/// <summary>
	/// Log a message with the <see cref="F:Common.Logging.LogLevel.Info" /> level using a callback to obtain the message
	/// </summary>
	/// <remarks>
	/// Using this method avoids the cost of creating a message and evaluating message arguments 
	/// that probably won't be logged due to loglevel settings.
	/// </remarks>
	/// <param name="formatMessageCallback">A callback used by the logger to obtain the message if log level is matched</param>
	/// <param name="exception">The exception to log, including its stack trace.</param>
	void Info(Action<FormatMessageHandler> formatMessageCallback, Exception exception);

	/// <summary>
	/// Log a message with the <see cref="F:Common.Logging.LogLevel.Info" /> level using a callback to obtain the message
	/// </summary>
	/// <remarks>
	/// Using this method avoids the cost of creating a message and evaluating message arguments 
	/// that probably won't be logged due to loglevel settings.
	/// </remarks>
	/// <param name="formatProvider">An <see cref="T:System.IFormatProvider" /> that supplies culture-specific formatting information.</param>
	/// <param name="formatMessageCallback">A callback used by the logger to obtain the message if log level is matched</param>
	void Info(IFormatProvider formatProvider, Action<FormatMessageHandler> formatMessageCallback);

	/// <summary>
	/// Log a message with the <see cref="F:Common.Logging.LogLevel.Info" /> level using a callback to obtain the message
	/// </summary>
	/// <remarks>
	/// Using this method avoids the cost of creating a message and evaluating message arguments 
	/// that probably won't be logged due to loglevel settings.
	/// </remarks>
	/// <param name="formatProvider">An <see cref="T:System.IFormatProvider" /> that supplies culture-specific formatting information.</param>
	/// <param name="formatMessageCallback">A callback used by the logger to obtain the message if log level is matched</param>
	/// <param name="exception">The exception to log, including its stack Info.</param>
	void Info(IFormatProvider formatProvider, Action<FormatMessageHandler> formatMessageCallback, Exception exception);

	/// <summary>
	/// Log a message object with the <see cref="F:Common.Logging.LogLevel.Warn" /> level.
	/// </summary>
	/// <param name="message">The message object to log.</param>
	void Warn(object message);

	/// <summary>
	/// Log a message object with the <see cref="F:Common.Logging.LogLevel.Warn" /> level including
	/// the stack trace of the <see cref="T:System.Exception" /> passed
	/// as a parameter.
	/// </summary>
	/// <param name="message">The message object to log.</param>
	/// <param name="exception">The exception to log, including its stack trace.</param>
	void Warn(object message, Exception exception);

	/// <summary>
	/// Log a message with the <see cref="F:Common.Logging.LogLevel.Warn" /> level.
	/// </summary>
	/// <param name="format">The format of the message object to log.<see cref="M:System.String.Format(System.String,System.Object[])" /> </param>
	/// <param name="args">the list of format arguments</param>
	void WarnFormat(string format, params object[] args);

	/// <summary>
	/// Log a message with the <see cref="F:Common.Logging.LogLevel.Warn" /> level.
	/// </summary>
	/// <param name="format">The format of the message object to log.<see cref="M:System.String.Format(System.String,System.Object[])" /> </param>
	/// <param name="exception">The exception to log.</param>
	/// <param name="args">the list of format arguments</param>
	void WarnFormat(string format, Exception exception, params object[] args);

	/// <summary>
	/// Log a message with the <see cref="F:Common.Logging.LogLevel.Warn" /> level.
	/// </summary>
	/// <param name="formatProvider">An <see cref="T:System.IFormatProvider" /> that supplies culture-specific formatting information.</param>
	/// <param name="format">The format of the message object to log.<see cref="M:System.String.Format(System.String,System.Object[])" /> </param>
	/// <param name="args"></param>
	void WarnFormat(IFormatProvider formatProvider, string format, params object[] args);

	/// <summary>
	/// Log a message with the <see cref="F:Common.Logging.LogLevel.Warn" /> level.
	/// </summary>
	/// <param name="formatProvider">An <see cref="T:System.IFormatProvider" /> that supplies culture-specific formatting information.</param>
	/// <param name="format">The format of the message object to log.<see cref="M:System.String.Format(System.String,System.Object[])" /> </param>
	/// <param name="exception">The exception to log.</param>
	/// <param name="args"></param>
	void WarnFormat(IFormatProvider formatProvider, string format, Exception exception, params object[] args);

	/// <summary>
	/// Log a message with the <see cref="F:Common.Logging.LogLevel.Warn" /> level using a callback to obtain the message
	/// </summary>
	/// <remarks>
	/// Using this method avoids the cost of creating a message and evaluating message arguments 
	/// that probably won't be logged due to loglevel settings.
	/// </remarks>
	/// <param name="formatMessageCallback">A callback used by the logger to obtain the message if log level is matched</param>
	void Warn(Action<FormatMessageHandler> formatMessageCallback);

	/// <summary>
	/// Log a message with the <see cref="F:Common.Logging.LogLevel.Warn" /> level using a callback to obtain the message
	/// </summary>
	/// <remarks>
	/// Using this method avoids the cost of creating a message and evaluating message arguments 
	/// that probably won't be logged due to loglevel settings.
	/// </remarks>
	/// <param name="formatMessageCallback">A callback used by the logger to obtain the message if log level is matched</param>
	/// <param name="exception">The exception to log, including its stack trace.</param>
	void Warn(Action<FormatMessageHandler> formatMessageCallback, Exception exception);

	/// <summary>
	/// Log a message with the <see cref="F:Common.Logging.LogLevel.Warn" /> level using a callback to obtain the message
	/// </summary>
	/// <remarks>
	/// Using this method avoids the cost of creating a message and evaluating message arguments 
	/// that probably won't be logged due to loglevel settings.
	/// </remarks>
	/// <param name="formatProvider">An <see cref="T:System.IFormatProvider" /> that supplies culture-specific formatting information.</param>
	/// <param name="formatMessageCallback">A callback used by the logger to obtain the message if log level is matched</param>
	void Warn(IFormatProvider formatProvider, Action<FormatMessageHandler> formatMessageCallback);

	/// <summary>
	/// Log a message with the <see cref="F:Common.Logging.LogLevel.Warn" /> level using a callback to obtain the message
	/// </summary>
	/// <remarks>
	/// Using this method avoids the cost of creating a message and evaluating message arguments 
	/// that probably won't be logged due to loglevel settings.
	/// </remarks>
	/// <param name="formatProvider">An <see cref="T:System.IFormatProvider" /> that supplies culture-specific formatting information.</param>
	/// <param name="formatMessageCallback">A callback used by the logger to obtain the message if log level is matched</param>
	/// <param name="exception">The exception to log, including its stack Warn.</param>
	void Warn(IFormatProvider formatProvider, Action<FormatMessageHandler> formatMessageCallback, Exception exception);

	/// <summary>
	/// Log a message object with the <see cref="F:Common.Logging.LogLevel.Error" /> level.
	/// </summary>
	/// <param name="message">The message object to log.</param>
	void Error(object message);

	/// <summary>
	/// Log a message object with the <see cref="F:Common.Logging.LogLevel.Error" /> level including
	/// the stack trace of the <see cref="T:System.Exception" /> passed
	/// as a parameter.
	/// </summary>
	/// <param name="message">The message object to log.</param>
	/// <param name="exception">The exception to log, including its stack trace.</param>
	void Error(object message, Exception exception);

	/// <summary>
	/// Log a message with the <see cref="F:Common.Logging.LogLevel.Error" /> level.
	/// </summary>
	/// <param name="format">The format of the message object to log.<see cref="M:System.String.Format(System.String,System.Object[])" /> </param>
	/// <param name="args">the list of format arguments</param>
	void ErrorFormat(string format, params object[] args);

	/// <summary>
	/// Log a message with the <see cref="F:Common.Logging.LogLevel.Error" /> level.
	/// </summary>
	/// <param name="format">The format of the message object to log.<see cref="M:System.String.Format(System.String,System.Object[])" /> </param>
	/// <param name="exception">The exception to log.</param>
	/// <param name="args">the list of format arguments</param>
	void ErrorFormat(string format, Exception exception, params object[] args);

	/// <summary>
	/// Log a message with the <see cref="F:Common.Logging.LogLevel.Error" /> level.
	/// </summary>
	/// <param name="formatProvider">An <see cref="T:System.IFormatProvider" /> that supplies culture-specific formatting information.</param>
	/// <param name="format">The format of the message object to log.<see cref="M:System.String.Format(System.String,System.Object[])" /> </param>
	/// <param name="args"></param>
	void ErrorFormat(IFormatProvider formatProvider, string format, params object[] args);

	/// <summary>
	/// Log a message with the <see cref="F:Common.Logging.LogLevel.Error" /> level.
	/// </summary>
	/// <param name="formatProvider">An <see cref="T:System.IFormatProvider" /> that supplies culture-specific formatting information.</param>
	/// <param name="format">The format of the message object to log.<see cref="M:System.String.Format(System.String,System.Object[])" /> </param>
	/// <param name="exception">The exception to log.</param>
	/// <param name="args"></param>
	void ErrorFormat(IFormatProvider formatProvider, string format, Exception exception, params object[] args);

	/// <summary>
	/// Log a message with the <see cref="F:Common.Logging.LogLevel.Error" /> level using a callback to obtain the message
	/// </summary>
	/// <remarks>
	/// Using this method avoids the cost of creating a message and evaluating message arguments 
	/// that probably won't be logged due to loglevel settings.
	/// </remarks>
	/// <param name="formatMessageCallback">A callback used by the logger to obtain the message if log level is matched</param>
	void Error(Action<FormatMessageHandler> formatMessageCallback);

	/// <summary>
	/// Log a message with the <see cref="F:Common.Logging.LogLevel.Error" /> level using a callback to obtain the message
	/// </summary>
	/// <remarks>
	/// Using this method avoids the cost of creating a message and evaluating message arguments 
	/// that probably won't be logged due to loglevel settings.
	/// </remarks>
	/// <param name="formatMessageCallback">A callback used by the logger to obtain the message if log level is matched</param>
	/// <param name="exception">The exception to log, including its stack trace.</param>
	void Error(Action<FormatMessageHandler> formatMessageCallback, Exception exception);

	/// <summary>
	/// Log a message with the <see cref="F:Common.Logging.LogLevel.Error" /> level using a callback to obtain the message
	/// </summary>
	/// <remarks>
	/// Using this method avoids the cost of creating a message and evaluating message arguments 
	/// that probably won't be logged due to loglevel settings.
	/// </remarks>
	/// <param name="formatProvider">An <see cref="T:System.IFormatProvider" /> that supplies culture-specific formatting information.</param>
	/// <param name="formatMessageCallback">A callback used by the logger to obtain the message if log level is matched</param>
	void Error(IFormatProvider formatProvider, Action<FormatMessageHandler> formatMessageCallback);

	/// <summary>
	/// Log a message with the <see cref="F:Common.Logging.LogLevel.Error" /> level using a callback to obtain the message
	/// </summary>
	/// <remarks>
	/// Using this method avoids the cost of creating a message and evaluating message arguments 
	/// that probably won't be logged due to loglevel settings.
	/// </remarks>
	/// <param name="formatProvider">An <see cref="T:System.IFormatProvider" /> that supplies culture-specific formatting information.</param>
	/// <param name="formatMessageCallback">A callback used by the logger to obtain the message if log level is matched</param>
	/// <param name="exception">The exception to log, including its stack Error.</param>
	void Error(IFormatProvider formatProvider, Action<FormatMessageHandler> formatMessageCallback, Exception exception);

	/// <summary>
	/// Log a message object with the <see cref="F:Common.Logging.LogLevel.Fatal" /> level.
	/// </summary>
	/// <param name="message">The message object to log.</param>
	void Fatal(object message);

	/// <summary>
	/// Log a message object with the <see cref="F:Common.Logging.LogLevel.Fatal" /> level including
	/// the stack trace of the <see cref="T:System.Exception" /> passed
	/// as a parameter.
	/// </summary>
	/// <param name="message">The message object to log.</param>
	/// <param name="exception">The exception to log, including its stack trace.</param>
	void Fatal(object message, Exception exception);

	/// <summary>
	/// Log a message with the <see cref="F:Common.Logging.LogLevel.Fatal" /> level.
	/// </summary>
	/// <param name="format">The format of the message object to log.<see cref="M:System.String.Format(System.String,System.Object[])" /> </param>
	/// <param name="args">the list of format arguments</param>
	void FatalFormat(string format, params object[] args);

	/// <summary>
	/// Log a message with the <see cref="F:Common.Logging.LogLevel.Fatal" /> level.
	/// </summary>
	/// <param name="format">The format of the message object to log.<see cref="M:System.String.Format(System.String,System.Object[])" /> </param>
	/// <param name="exception">The exception to log.</param>
	/// <param name="args">the list of format arguments</param>
	void FatalFormat(string format, Exception exception, params object[] args);

	/// <summary>
	/// Log a message with the <see cref="F:Common.Logging.LogLevel.Fatal" /> level.
	/// </summary>
	/// <param name="formatProvider">An <see cref="T:System.IFormatProvider" /> that supplies culture-specific formatting information.</param>
	/// <param name="format">The format of the message object to log.<see cref="M:System.String.Format(System.String,System.Object[])" /> </param>
	/// <param name="args"></param>
	void FatalFormat(IFormatProvider formatProvider, string format, params object[] args);

	/// <summary>
	/// Log a message with the <see cref="F:Common.Logging.LogLevel.Fatal" /> level.
	/// </summary>
	/// <param name="formatProvider">An <see cref="T:System.IFormatProvider" /> that supplies culture-specific formatting information.</param>
	/// <param name="format">The format of the message object to log.<see cref="M:System.String.Format(System.String,System.Object[])" /> </param>
	/// <param name="exception">The exception to log.</param>
	/// <param name="args"></param>
	void FatalFormat(IFormatProvider formatProvider, string format, Exception exception, params object[] args);

	/// <summary>
	/// Log a message with the <see cref="F:Common.Logging.LogLevel.Fatal" /> level using a callback to obtain the message
	/// </summary>
	/// <remarks>
	/// Using this method avoids the cost of creating a message and evaluating message arguments 
	/// that probably won't be logged due to loglevel settings.
	/// </remarks>
	/// <param name="formatMessageCallback">A callback used by the logger to obtain the message if log level is matched</param>
	void Fatal(Action<FormatMessageHandler> formatMessageCallback);

	/// <summary>
	/// Log a message with the <see cref="F:Common.Logging.LogLevel.Fatal" /> level using a callback to obtain the message
	/// </summary>
	/// <remarks>
	/// Using this method avoids the cost of creating a message and evaluating message arguments 
	/// that probably won't be logged due to loglevel settings.
	/// </remarks>
	/// <param name="formatMessageCallback">A callback used by the logger to obtain the message if log level is matched</param>
	/// <param name="exception">The exception to log, including its stack trace.</param>
	void Fatal(Action<FormatMessageHandler> formatMessageCallback, Exception exception);

	/// <summary>
	/// Log a message with the <see cref="F:Common.Logging.LogLevel.Fatal" /> level using a callback to obtain the message
	/// </summary>
	/// <remarks>
	/// Using this method avoids the cost of creating a message and evaluating message arguments 
	/// that probably won't be logged due to loglevel settings.
	/// </remarks>
	/// <param name="formatProvider">An <see cref="T:System.IFormatProvider" /> that supplies culture-specific formatting information.</param>
	/// <param name="formatMessageCallback">A callback used by the logger to obtain the message if log level is matched</param>
	void Fatal(IFormatProvider formatProvider, Action<FormatMessageHandler> formatMessageCallback);

	/// <summary>
	/// Log a message with the <see cref="F:Common.Logging.LogLevel.Fatal" /> level using a callback to obtain the message
	/// </summary>
	/// <remarks>
	/// Using this method avoids the cost of creating a message and evaluating message arguments 
	/// that probably won't be logged due to loglevel settings.
	/// </remarks>
	/// <param name="formatProvider">An <see cref="T:System.IFormatProvider" /> that supplies culture-specific formatting information.</param>
	/// <param name="formatMessageCallback">A callback used by the logger to obtain the message if log level is matched</param>
	/// <param name="exception">The exception to log, including its stack Fatal.</param>
	void Fatal(IFormatProvider formatProvider, Action<FormatMessageHandler> formatMessageCallback, Exception exception);
}
