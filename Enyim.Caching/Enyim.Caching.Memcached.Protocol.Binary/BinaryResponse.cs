using System;
using System.Text;

namespace Enyim.Caching.Memcached.Protocol.Binary;

public class BinaryResponse
{
	private const byte MAGIC_VALUE = 129;

	private const int HeaderLength = 24;

	private const int HEADER_OPCODE = 1;

	private const int HEADER_KEY = 2;

	private const int HEADER_EXTRA = 4;

	private const int HEADER_DATATYPE = 5;

	private const int HEADER_STATUS = 6;

	private const int HEADER_BODY = 8;

	private const int HEADER_OPAQUE = 12;

	private const int HEADER_CAS = 16;

	private static readonly ILog log = LogManager.GetLogger(typeof(BinaryResponse));

	public byte Opcode;

	public int KeyLength;

	public byte DataType;

	public int StatusCode;

	public int CorrelationId;

	public ulong CAS;

	public ArraySegment<byte> Extra;

	public ArraySegment<byte> Data;

	private string responseMessage;

	private PooledSocket currentSocket;

	private int dataLength;

	private int extraLength;

	private bool shouldCallNext;

	private Action<bool> next;

	public BinaryResponse()
	{
		StatusCode = -1;
	}

	public string GetStatusMessage()
	{
		object obj;
		if (Data.Array != null)
		{
			obj = responseMessage;
			if (obj == null)
			{
				return responseMessage = Encoding.ASCII.GetString(Data.Array, Data.Offset, Data.Count);
			}
		}
		else
		{
			obj = null;
		}
		return (string)obj;
	}

	public bool Read(PooledSocket socket)
	{
		StatusCode = -1;
		if (!socket.IsAlive)
		{
			return false;
		}
		byte[] header = new byte[24];
		socket.Read(header, 0, header.Length);
		DeserializeHeader(header, out var dataLength, out var extraLength);
		if (dataLength > 0)
		{
			byte[] data = new byte[dataLength];
			socket.Read(data, 0, dataLength);
			Extra = new ArraySegment<byte>(data, 0, extraLength);
			Data = new ArraySegment<byte>(data, extraLength, data.Length - extraLength);
		}
		return StatusCode == 0;
	}

	/// <summary>
	/// Reads the response from the socket asynchronously.
	/// </summary>
	/// <param name="socket">The socket to read from.</param>
	/// <param name="next">The delegate whihc will continue processing the response. This is only called if the read completes asynchronoulsy.</param>
	/// <param name="ioPending">Set totrue if the read is still pending when ReadASync returns. In this case 'next' will be called when the read is finished.</param>
	/// <returns>
	/// If the socket is already dead, ReadAsync returns false, next is not called, ioPending = false
	/// If the read completes synchronously (e.g. data is received from the buffer), it returns true/false depending on the StatusCode, and ioPending is set to true, 'next' will not be called.
	/// It returns true if it has to read from the socket, so the operation will complate asynchronously at a later time. ioPending will be true, and 'next' will be called to handle the data
	/// </returns>
	public bool ReadAsync(PooledSocket socket, Action<bool> next, out bool ioPending)
	{
		StatusCode = -1;
		currentSocket = socket;
		this.next = next;
		AsyncIOArgs asyncEvent = new AsyncIOArgs();
		asyncEvent.Count = 24;
		asyncEvent.Next = DoDecodeHeaderAsync;
		shouldCallNext = true;
		if (socket.ReceiveAsync(asyncEvent))
		{
			ioPending = true;
			return true;
		}
		ioPending = false;
		shouldCallNext = false;
		if (!asyncEvent.Fail)
		{
			return DoDecodeHeader(asyncEvent, out ioPending);
		}
		return false;
	}

	private void DoDecodeHeaderAsync(AsyncIOArgs asyncEvent)
	{
		shouldCallNext = true;
		DoDecodeHeader(asyncEvent, out var _);
	}

	private bool DoDecodeHeader(AsyncIOArgs asyncEvent, out bool pendingIO)
	{
		pendingIO = false;
		if (asyncEvent.Fail)
		{
			if (shouldCallNext)
			{
				next(obj: false);
			}
			return false;
		}
		DeserializeHeader(asyncEvent.Result, out dataLength, out extraLength);
		bool retval = StatusCode == 0;
		if (dataLength == 0)
		{
			if (shouldCallNext)
			{
				next(retval);
			}
		}
		else
		{
			asyncEvent.Count = dataLength;
			asyncEvent.Next = DoDecodeBodyAsync;
			if (currentSocket.ReceiveAsync(asyncEvent))
			{
				pendingIO = true;
			}
			else
			{
				if (asyncEvent.Fail)
				{
					return false;
				}
				DoDecodeBody(asyncEvent);
			}
		}
		return retval;
	}

	private void DoDecodeBodyAsync(AsyncIOArgs asyncEvent)
	{
		shouldCallNext = true;
		DoDecodeBody(asyncEvent);
	}

	private void DoDecodeBody(AsyncIOArgs asyncEvent)
	{
		if (asyncEvent.Fail)
		{
			if (shouldCallNext)
			{
				next(obj: false);
			}
			return;
		}
		Extra = new ArraySegment<byte>(asyncEvent.Result, 0, extraLength);
		Data = new ArraySegment<byte>(asyncEvent.Result, extraLength, dataLength - extraLength);
		if (shouldCallNext)
		{
			next(obj: true);
		}
	}

	private unsafe void DeserializeHeader(byte[] header, out int dataLength, out int extraLength)
	{
		fixed (byte* buffer = header)
		{
			if (*buffer != 129)
			{
				throw new InvalidOperationException("Expected magic value " + (byte)129 + ", received: " + *buffer);
			}
			DataType = buffer[5];
			Opcode = buffer[1];
			StatusCode = BinaryConverter.DecodeUInt16(buffer, 6);
			KeyLength = BinaryConverter.DecodeUInt16(buffer, 2);
			CorrelationId = BinaryConverter.DecodeInt32(buffer, 12);
			CAS = BinaryConverter.DecodeUInt64(buffer, 16);
			dataLength = BinaryConverter.DecodeInt32(buffer, 8);
			extraLength = buffer[4];
		}
	}
}
