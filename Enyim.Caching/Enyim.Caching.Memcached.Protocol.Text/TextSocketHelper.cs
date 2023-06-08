using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Enyim.Caching.Memcached.Protocol.Text;

internal static class TextSocketHelper
{
	private const string GenericErrorResponse = "ERROR";

	private const string ClientErrorResponse = "CLIENT_ERROR ";

	private const string ServerErrorResponse = "SERVER_ERROR ";

	private const int ErrorResponseLength = 13;

	public const string CommandTerminator = "\r\n";

	private static readonly ILog log = LogManager.GetLogger(typeof(TextSocketHelper));

	/// <summary>
	/// Reads the response of the server.
	/// </summary>
	/// <returns>The data sent by the memcached server.</returns>
	/// <exception cref="T:System.InvalidOperationException">The server did not sent a response or an empty line was returned.</exception>
	/// <exception cref="T:Enyim.Caching.Memcached.MemcachedException">The server did not specified any reason just returned the string ERROR. - or - The server returned a SERVER_ERROR, in this case the Message of the exception is the message returned by the server.</exception>
	/// <exception cref="T:Enyim.Caching.Memcached.MemcachedClientException">The server did not recognize the request sent by the client. The Message of the exception is the message returned by the server.</exception>
	public static string ReadResponse(PooledSocket socket)
	{
		string response = ReadLine(socket);
		if (log.IsDebugEnabled)
		{
			log.Debug("Received response: " + response);
		}
		if (string.IsNullOrEmpty(response))
		{
			throw new MemcachedClientException("Empty response received.");
		}
		if (string.Compare(response, "ERROR", StringComparison.Ordinal) == 0)
		{
			throw new NotSupportedException("Operation is not supported by the server or the request was malformed. If the latter please report the bug to the developers.");
		}
		if (response.Length >= 13)
		{
			if (string.Compare(response, 0, "CLIENT_ERROR ", 0, 13, StringComparison.Ordinal) == 0)
			{
				throw new MemcachedClientException(response.Remove(0, 13));
			}
			if (string.Compare(response, 0, "SERVER_ERROR ", 0, 13, StringComparison.Ordinal) == 0)
			{
				throw new MemcachedException(response.Remove(0, 13));
			}
		}
		return response;
	}

	/// <summary>
	/// Reads a line from the socket. A line is terninated by \r\n.
	/// </summary>
	/// <returns></returns>
	private static string ReadLine(PooledSocket socket)
	{
		MemoryStream ms = new MemoryStream(50);
		bool gotR = false;
		while (true)
		{
			int data = socket.ReadByte();
			if (data == 13)
			{
				gotR = true;
				continue;
			}
			if (gotR)
			{
				if (data == 10)
				{
					break;
				}
				ms.WriteByte(13);
				gotR = false;
			}
			ms.WriteByte((byte)data);
		}
		string retval = Encoding.ASCII.GetString(ms.GetBuffer(), 0, (int)ms.Length);
		if (log.IsDebugEnabled)
		{
			log.Debug("ReadLine: " + retval);
		}
		return retval;
	}

	/// <summary>
	/// Gets the bytes representing the specified command. returned buffer can be used to streamline multiple writes into one Write on the Socket
	/// using the <see cref="M:Enyim.Caching.Memcached.PooledSocket.Write(IList&lt;ArraySegment&lt;byte&gt;&gt;)" />
	/// </summary>
	/// <param name="value">The command to be converted.</param>
	/// <returns>The buffer containing the bytes representing the command. The command must be terminated by \r\n.</returns>
	/// <remarks>The Nagle algorithm is disabled on the socket to speed things up, so it's recommended to convert a command into a buffer
	/// and use the <see cref="M:Enyim.Caching.Memcached.PooledSocket.Write(IList&lt;ArraySegment&lt;byte&gt;&gt;)" /> to send the command and the additional buffers in one transaction.</remarks>
	public static IList<ArraySegment<byte>> GetCommandBuffer(string value)
	{
		ArraySegment<byte> data = new ArraySegment<byte>(Encoding.ASCII.GetBytes(value));
		return new ArraySegment<byte>[1] { data };
	}

	public static IList<ArraySegment<byte>> GetCommandBuffer(string value, IList<ArraySegment<byte>> list)
	{
		ArraySegment<byte> data = new ArraySegment<byte>(Encoding.ASCII.GetBytes(value));
		list.Add(data);
		return list;
	}
}
