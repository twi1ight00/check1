using System;
using System.Text;

namespace Common.Logging.Simple;

/// <summary>
/// Sends log messages to <see cref="P:System.Console.Out" />.
/// </summary>
/// <author>Gilles Bayon</author>
[Serializable]
public class ConsoleOutLogger : AbstractSimpleLogger
{
	/// <summary>
	/// Creates and initializes a logger that writes messages to <see cref="P:System.Console.Out" />.
	/// </summary>
	/// <param name="logName">The name, usually type name of the calling class, of the logger.</param>
	/// <param name="logLevel">The current logging threshold. Messages recieved that are beneath this threshold will not be logged.</param>
	/// <param name="showLevel">Include the current log level in the log message.</param>
	/// <param name="showDateTime">Include the current time in the log message.</param>
	/// <param name="showLogName">Include the instance name in the log message.</param>
	/// <param name="dateTimeFormat">The date and time format to use in the log message.</param>
	public ConsoleOutLogger(string logName, LogLevel logLevel, bool showLevel, bool showDateTime, bool showLogName, string dateTimeFormat)
		: base(logName, logLevel, showLevel, showDateTime, showLogName, dateTimeFormat)
	{
	}

	/// <summary>
	/// Do the actual logging by constructing the log message using a <see cref="T:System.Text.StringBuilder" /> then
	/// sending the output to <see cref="P:System.Console.Out" />.
	/// </summary>
	/// <param name="level">The <see cref="T:Common.Logging.LogLevel" /> of the message.</param>
	/// <param name="message">The log message.</param>
	/// <param name="e">An optional <see cref="T:System.Exception" /> associated with the message.</param>
	protected override void WriteInternal(LogLevel level, object message, Exception e)
	{
		StringBuilder sb = new StringBuilder();
		FormatOutput(sb, level, message, e);
		Console.Out.WriteLine(sb.ToString());
	}
}
