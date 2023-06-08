using System;
using System.Globalization;
using System.Text;
using Common.Logging.Factory;

namespace Common.Logging.Simple;

/// <summary>
/// Abstract class providing a standard implementation of simple loggers.
/// </summary>
/// <author>Erich Eichinger</author>
[Serializable]
public abstract class AbstractSimpleLogger : AbstractLogger
{
	private readonly string _name;

	private readonly bool _showLevel;

	private readonly bool _showDateTime;

	private readonly bool _showLogName;

	private LogLevel _currentLogLevel;

	private readonly string _dateTimeFormat;

	private readonly bool _hasDateTimeFormat;

	/// <summary>
	/// The name of the logger.
	/// </summary>
	[CoverageExclude]
	public string Name => _name;

	/// <summary>
	/// Include the current log level in the log message.
	/// </summary>
	[CoverageExclude]
	public bool ShowLevel => _showLevel;

	/// <summary>
	/// Include the current time in the log message.
	/// </summary>
	[CoverageExclude]
	public bool ShowDateTime => _showDateTime;

	/// <summary>
	/// Include the instance name in the log message.
	/// </summary>
	[CoverageExclude]
	public bool ShowLogName => _showLogName;

	/// <summary>
	/// The current logging threshold. Messages recieved that are beneath this threshold will not be logged.
	/// </summary>
	[CoverageExclude]
	public LogLevel CurrentLogLevel
	{
		get
		{
			return _currentLogLevel;
		}
		set
		{
			_currentLogLevel = value;
		}
	}

	/// <summary>
	/// The date and time format to use in the log message.
	/// </summary>
	[CoverageExclude]
	public string DateTimeFormat => _dateTimeFormat;

	/// <summary>
	/// Determines Whether <see cref="P:Common.Logging.Simple.AbstractSimpleLogger.DateTimeFormat" /> is set.
	/// </summary>
	[CoverageExclude]
	public bool HasDateTimeFormat => _hasDateTimeFormat;

	/// <summary>
	/// Returns <see langword="true" /> if the current <see cref="T:Common.Logging.LogLevel" /> is greater than or
	/// equal to <see cref="F:Common.Logging.LogLevel.Trace" />. If it is, all messages will be sent to <see cref="P:System.Console.Out" />.
	/// </summary>
	public override bool IsTraceEnabled => IsLevelEnabled(LogLevel.Trace);

	/// <summary>
	/// Returns <see langword="true" /> if the current <see cref="T:Common.Logging.LogLevel" /> is greater than or
	/// equal to <see cref="F:Common.Logging.LogLevel.Debug" />. If it is, all messages will be sent to <see cref="P:System.Console.Out" />.
	/// </summary>
	public override bool IsDebugEnabled => IsLevelEnabled(LogLevel.Debug);

	/// <summary>
	/// Returns <see langword="true" /> if the current <see cref="T:Common.Logging.LogLevel" /> is greater than or
	/// equal to <see cref="F:Common.Logging.LogLevel.Info" />. If it is, only messages with a <see cref="T:Common.Logging.LogLevel" /> of
	/// <see cref="F:Common.Logging.LogLevel.Info" />, <see cref="F:Common.Logging.LogLevel.Warn" />, <see cref="F:Common.Logging.LogLevel.Error" />, and 
	/// <see cref="F:Common.Logging.LogLevel.Fatal" /> will be sent to <see cref="P:System.Console.Out" />.
	/// </summary>
	public override bool IsInfoEnabled => IsLevelEnabled(LogLevel.Info);

	/// <summary>
	/// Returns <see langword="true" /> if the current <see cref="T:Common.Logging.LogLevel" /> is greater than or
	/// equal to <see cref="F:Common.Logging.LogLevel.Warn" />. If it is, only messages with a <see cref="T:Common.Logging.LogLevel" /> of
	/// <see cref="F:Common.Logging.LogLevel.Warn" />, <see cref="F:Common.Logging.LogLevel.Error" />, and <see cref="F:Common.Logging.LogLevel.Fatal" /> 
	/// will be sent to <see cref="P:System.Console.Out" />.
	/// </summary>
	public override bool IsWarnEnabled => IsLevelEnabled(LogLevel.Warn);

	/// <summary>
	/// Returns <see langword="true" /> if the current <see cref="T:Common.Logging.LogLevel" /> is greater than or
	/// equal to <see cref="F:Common.Logging.LogLevel.Error" />. If it is, only messages with a <see cref="T:Common.Logging.LogLevel" /> of
	/// <see cref="F:Common.Logging.LogLevel.Error" /> and <see cref="F:Common.Logging.LogLevel.Fatal" /> will be sent to <see cref="P:System.Console.Out" />.
	/// </summary>
	public override bool IsErrorEnabled => IsLevelEnabled(LogLevel.Error);

	/// <summary>
	/// Returns <see langword="true" /> if the current <see cref="T:Common.Logging.LogLevel" /> is greater than or
	/// equal to <see cref="F:Common.Logging.LogLevel.Fatal" />. If it is, only messages with a <see cref="T:Common.Logging.LogLevel" /> of
	/// <see cref="F:Common.Logging.LogLevel.Fatal" /> will be sent to <see cref="P:System.Console.Out" />.
	/// </summary>
	public override bool IsFatalEnabled => IsLevelEnabled(LogLevel.Fatal);

	/// <summary>
	/// Creates and initializes a the simple logger.
	/// </summary>
	/// <param name="logName">The name, usually type name of the calling class, of the logger.</param>
	/// <param name="logLevel">The current logging threshold. Messages recieved that are beneath this threshold will not be logged.</param>
	/// <param name="showlevel">Include level in the log message.</param>
	/// <param name="showDateTime">Include the current time in the log message.</param>
	/// <param name="showLogName">Include the instance name in the log message.</param>
	/// <param name="dateTimeFormat">The date and time format to use in the log message.</param>
	public AbstractSimpleLogger(string logName, LogLevel logLevel, bool showlevel, bool showDateTime, bool showLogName, string dateTimeFormat)
	{
		_name = logName;
		_currentLogLevel = logLevel;
		_showLevel = showlevel;
		_showDateTime = showDateTime;
		_showLogName = showLogName;
		_dateTimeFormat = dateTimeFormat;
		_hasDateTimeFormat = !string.IsNullOrEmpty(_dateTimeFormat);
	}

	/// <summary>
	/// Appends the formatted message to the specified <see cref="T:System.Text.StringBuilder" />.
	/// </summary>
	/// <param name="stringBuilder">the <see cref="T:System.Text.StringBuilder" /> that receíves the formatted message.</param>
	/// <param name="level"></param>
	/// <param name="message"></param>
	/// <param name="e"></param>
	protected virtual void FormatOutput(StringBuilder stringBuilder, LogLevel level, object message, Exception e)
	{
		if (stringBuilder == null)
		{
			throw new ArgumentNullException("stringBuilder");
		}
		if (_showDateTime)
		{
			if (_hasDateTimeFormat)
			{
				stringBuilder.Append(DateTime.Now.ToString(_dateTimeFormat, CultureInfo.InvariantCulture));
			}
			else
			{
				stringBuilder.Append(DateTime.Now);
			}
			stringBuilder.Append(" ");
		}
		if (_showLevel)
		{
			stringBuilder.Append(("[" + level.ToString().ToUpper() + "]").PadRight(8));
		}
		if (_showLogName)
		{
			stringBuilder.Append(_name).Append(" - ");
		}
		stringBuilder.Append(message);
		if (e != null)
		{
			stringBuilder.Append(Environment.NewLine).Append(e.ToString());
		}
	}

	/// <summary>
	/// Determines if the given log level is currently enabled.
	/// </summary>
	/// <param name="level"></param>
	/// <returns></returns>
	protected virtual bool IsLevelEnabled(LogLevel level)
	{
		int iCurrentLogLevel = (int)_currentLogLevel;
		return (int)level >= iCurrentLogLevel;
	}
}
