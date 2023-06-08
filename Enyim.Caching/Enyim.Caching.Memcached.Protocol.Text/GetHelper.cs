using System;
using System.Globalization;

namespace Enyim.Caching.Memcached.Protocol.Text;

internal static class GetHelper
{
	private static readonly ILog log = LogManager.GetLogger(typeof(GetHelper));

	public static void FinishCurrent(PooledSocket socket)
	{
		string response = TextSocketHelper.ReadResponse(socket);
		if (string.Compare(response, "END", StringComparison.Ordinal) != 0)
		{
			throw new MemcachedClientException("No END was received.");
		}
	}

	public static GetResponse ReadItem(PooledSocket socket)
	{
		string description = TextSocketHelper.ReadResponse(socket);
		if (string.Compare(description, "END", StringComparison.Ordinal) == 0)
		{
			return null;
		}
		if (description.Length < 6 || string.Compare(description, 0, "VALUE ", 0, 6, StringComparison.Ordinal) != 0)
		{
			throw new MemcachedClientException("No VALUE response received.\r\n" + description);
		}
		ulong cas = 0uL;
		string[] parts = description.Split(' ');
		if (parts.Length == 5)
		{
			if (!ulong.TryParse(parts[4], out cas))
			{
				throw new MemcachedClientException("Invalid CAS VALUE received.");
			}
		}
		else if (parts.Length < 4)
		{
			throw new MemcachedClientException("Invalid VALUE response received: " + description);
		}
		ushort flags = ushort.Parse(parts[2], CultureInfo.InvariantCulture);
		int length = int.Parse(parts[3], CultureInfo.InvariantCulture);
		byte[] allData = new byte[length];
		byte[] eod = new byte[2];
		socket.Read(allData, 0, length);
		socket.Read(eod, 0, 2);
		GetResponse retval = new GetResponse(parts[1], flags, cas, allData);
		if (log.IsDebugEnabled)
		{
			log.DebugFormat("Received value. Data type: {0}, size: {1}.", retval.Item.Flags, retval.Item.Data.Count);
		}
		return retval;
	}
}
