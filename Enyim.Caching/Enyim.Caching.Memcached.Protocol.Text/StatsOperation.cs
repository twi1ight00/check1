using System;
using System.Collections.Generic;
using Enyim.Caching.Memcached.Results;
using Enyim.Caching.Memcached.Results.Extensions;

namespace Enyim.Caching.Memcached.Protocol.Text;

public class StatsOperation : Operation, IStatsOperation, IOperation
{
	private static ILog log = LogManager.GetLogger(typeof(StatsOperation));

	private string type;

	private Dictionary<string, string> result;

	Dictionary<string, string> IStatsOperation.Result => result;

	public StatsOperation(string type)
	{
		this.type = type;
	}

	protected internal override IList<ArraySegment<byte>> GetBuffer()
	{
		string command = (string.IsNullOrEmpty(type) ? "stats\r\n" : ("stats " + type + "\r\n"));
		return TextSocketHelper.GetCommandBuffer(command);
	}

	protected internal override IOperationResult ReadResponse(PooledSocket socket)
	{
		Dictionary<string, string> serverData = new Dictionary<string, string>();
		while (true)
		{
			string line = TextSocketHelper.ReadResponse(socket);
			if (string.Compare(line, "END", StringComparison.Ordinal) == 0)
			{
				break;
			}
			if (line.Length < 6 || string.Compare(line, 0, "STAT ", 0, 5, StringComparison.Ordinal) != 0)
			{
				if (log.IsWarnEnabled)
				{
					log.Warn("Unknow response: " + line);
				}
				continue;
			}
			string[] parts = line.Remove(0, 5).Split(' ');
			if (parts.Length != 2)
			{
				if (log.IsWarnEnabled)
				{
					log.Warn("Unknow response: " + line);
				}
			}
			else
			{
				serverData[parts[0]] = parts[1];
			}
		}
		result = serverData;
		return new TextOperationResult().Pass();
	}

	protected internal override bool ReadResponseAsync(PooledSocket socket, Action<bool> next)
	{
		throw new NotSupportedException();
	}
}
