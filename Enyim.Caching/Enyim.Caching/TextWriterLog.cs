using System;
using System.IO;
using System.Threading;

namespace Enyim.Caching;

internal class TextWriterLog : ILog
{
	private const string PrefixDebug = "DEBUG";

	private const string PrefixInfo = "INFO";

	private const string PrefixWarn = "WARN";

	private const string PrefixError = "ERROR";

	private const string PrefixFatal = "FATAL";

	private TextWriter writer;

	private string name;

	bool ILog.IsDebugEnabled => true;

	bool ILog.IsInfoEnabled => true;

	bool ILog.IsWarnEnabled => true;

	bool ILog.IsErrorEnabled => true;

	bool ILog.IsFatalEnabled => true;

	public TextWriterLog(string name, TextWriter writer)
	{
		this.name = name;
		this.writer = writer;
	}

	private void Dump(string prefix, string message, params object[] args)
	{
		string line = $"{DateTime.Now:yyyy-MM-dd' 'HH:mm:ss} [{prefix}] {Thread.CurrentThread.ManagedThreadId} {name} - " + string.Format(message, args);
		lock (writer)
		{
			writer.WriteLine(line);
			writer.Flush();
		}
	}

	private void Dump(string prefix, object message)
	{
		string line = $"{DateTime.Now:yyyy-MM-dd' 'HH:mm:ss} [{prefix}] {Thread.CurrentThread.ManagedThreadId} {name} - {message}";
		lock (writer)
		{
			writer.WriteLine(line);
			writer.Flush();
		}
	}

	void ILog.Debug(object message)
	{
		Dump("DEBUG", message);
	}

	void ILog.Debug(object message, Exception exception)
	{
		Dump("DEBUG", string.Concat(message, " - ", exception));
	}

	void ILog.DebugFormat(string format, object arg0)
	{
		Dump("DEBUG", format, arg0);
	}

	void ILog.DebugFormat(string format, object arg0, object arg1)
	{
		Dump("DEBUG", format, arg0, arg1);
	}

	void ILog.DebugFormat(string format, object arg0, object arg1, object arg2)
	{
		Dump("DEBUG", format, arg0, arg1, arg2);
	}

	void ILog.DebugFormat(string format, params object[] args)
	{
		Dump("DEBUG", format, args);
	}

	void ILog.DebugFormat(IFormatProvider provider, string format, params object[] args)
	{
		Dump("DEBUG", string.Format(provider, format, args));
	}

	void ILog.Info(object message)
	{
		Dump("INFO", message);
	}

	void ILog.Info(object message, Exception exception)
	{
		Dump("INFO", string.Concat(message, " - ", exception));
	}

	void ILog.InfoFormat(string format, object arg0)
	{
		Dump("INFO", format, arg0);
	}

	void ILog.InfoFormat(string format, object arg0, object arg1)
	{
		Dump("INFO", format, arg0, arg1);
	}

	void ILog.InfoFormat(string format, object arg0, object arg1, object arg2)
	{
		Dump("INFO", format, arg0, arg1, arg2);
	}

	void ILog.InfoFormat(string format, params object[] args)
	{
		Dump("INFO", format, args);
	}

	void ILog.InfoFormat(IFormatProvider provider, string format, params object[] args)
	{
		Dump("INFO", string.Format(provider, format, args));
	}

	void ILog.Warn(object message)
	{
		Dump("WARN", message);
	}

	void ILog.Warn(object message, Exception exception)
	{
		Dump("WARN", string.Concat(message, " - ", exception));
	}

	void ILog.WarnFormat(string format, object arg0)
	{
		Dump("WARN", format, arg0);
	}

	void ILog.WarnFormat(string format, object arg0, object arg1)
	{
		Dump("WARN", format, arg0, arg1);
	}

	void ILog.WarnFormat(string format, object arg0, object arg1, object arg2)
	{
		Dump("WARN", format, arg0, arg1, arg2);
	}

	void ILog.WarnFormat(string format, params object[] args)
	{
		Dump("WARN", format, args);
	}

	void ILog.WarnFormat(IFormatProvider provider, string format, params object[] args)
	{
		Dump("WARN", string.Format(provider, format, args));
	}

	void ILog.Error(object message)
	{
		Dump("ERROR", message);
	}

	void ILog.Error(object message, Exception exception)
	{
		Dump("ERROR", string.Concat(message, " - ", exception));
	}

	void ILog.ErrorFormat(string format, object arg0)
	{
		Dump("ERROR", format, arg0);
	}

	void ILog.ErrorFormat(string format, object arg0, object arg1)
	{
		Dump("ERROR", format, arg0, arg1);
	}

	void ILog.ErrorFormat(string format, object arg0, object arg1, object arg2)
	{
		Dump("ERROR", format, arg0, arg1, arg2);
	}

	void ILog.ErrorFormat(string format, params object[] args)
	{
		Dump("ERROR", format, args);
	}

	void ILog.ErrorFormat(IFormatProvider provider, string format, params object[] args)
	{
		Dump("ERROR", string.Format(provider, format, args));
	}

	void ILog.Fatal(object message)
	{
		Dump("FATAL", message);
	}

	void ILog.Fatal(object message, Exception exception)
	{
		Dump("FATAL", string.Concat(message, " - ", exception));
	}

	void ILog.FatalFormat(string format, object arg0)
	{
		Dump("FATAL", format, arg0);
	}

	void ILog.FatalFormat(string format, object arg0, object arg1)
	{
		Dump("FATAL", format, arg0, arg1);
	}

	void ILog.FatalFormat(string format, object arg0, object arg1, object arg2)
	{
		Dump("FATAL", format, arg0, arg1, arg2);
	}

	void ILog.FatalFormat(string format, params object[] args)
	{
		Dump("FATAL", format, args);
	}

	void ILog.FatalFormat(IFormatProvider provider, string format, params object[] args)
	{
		Dump("FATAL", string.Format(provider, format, args));
	}
}
