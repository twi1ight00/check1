using System;
using System.Configuration;
using System.IO;

namespace Enyim.Caching;

public class DiagnosticsLogFactory : ILogFactory
{
	private TextWriter writer;

	public DiagnosticsLogFactory()
		: this(ConfigurationManager.AppSettings["Enyim.Caching.Diagnostics.LogPath"])
	{
	}

	public DiagnosticsLogFactory(string logPath)
	{
		if (string.IsNullOrEmpty(logPath))
		{
			throw new ArgumentNullException("Log path must be defined.  Add the following to configuration/appSettings: <add key=\"Enyim.Caching.Diagnostics.LogPath\" value=\"path to the log file\" /> or specify a valid path in in the constructor.");
		}
		writer = new StreamWriter(logPath, append: true);
	}

	ILog ILogFactory.GetLogger(string name)
	{
		return new TextWriterLog(name, writer);
	}

	ILog ILogFactory.GetLogger(Type type)
	{
		return new TextWriterLog(type.FullName, writer);
	}
}
