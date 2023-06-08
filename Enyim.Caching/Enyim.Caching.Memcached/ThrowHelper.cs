using System.IO;
using System.Net;
using System.Net.Sockets;

namespace Enyim.Caching.Memcached;

internal static class ThrowHelper
{
	public static void ThrowSocketWriteError(IPEndPoint endpoint, SocketError error)
	{
		throw new IOException($"Failed to write to the socket '{endpoint}'. Error: {error}");
	}
}
