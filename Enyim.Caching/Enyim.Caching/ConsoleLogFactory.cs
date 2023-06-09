using System;

namespace Enyim.Caching;

public class ConsoleLogFactory : ILogFactory
{
	ILog ILogFactory.GetLogger(string name)
	{
		return new TextWriterLog(name, Console.Out);
	}

	ILog ILogFactory.GetLogger(Type type)
	{
		return new TextWriterLog(type.FullName, Console.Out);
	}
}
