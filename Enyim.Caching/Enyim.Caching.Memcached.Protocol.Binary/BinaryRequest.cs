using System;
using System.Collections.Generic;
using System.Threading;

namespace Enyim.Caching.Memcached.Protocol.Binary;

public class BinaryRequest
{
	private static readonly ILog log = LogManager.GetLogger(typeof(BinaryRequest));

	private static int InstanceCounter;

	public byte Operation;

	public readonly int CorrelationId;

	public string Key;

	public ulong Cas;

	public ushort Reserved;

	public ArraySegment<byte> Extra;

	public ArraySegment<byte> Data;

	public BinaryRequest(OpCode operation)
		: this((byte)operation)
	{
	}

	public BinaryRequest(byte commandCode)
	{
		Operation = commandCode;
		CorrelationId = Interlocked.Increment(ref InstanceCounter);
	}

	public IList<ArraySegment<byte>> CreateBuffer()
	{
		return CreateBuffer(null);
	}

	public unsafe IList<ArraySegment<byte>> CreateBuffer(IList<ArraySegment<byte>> appendTo)
	{
		byte[] keyData = BinaryConverter.EncodeKey(Key);
		int keyLength = ((keyData != null) ? keyData.Length : 0);
		if (keyLength > 65535)
		{
			throw new InvalidOperationException("KeyTooLong");
		}
		ArraySegment<byte> extras = Extra;
		int extraLength = ((extras.Array != null) ? extras.Count : 0);
		if (extraLength > 255)
		{
			throw new InvalidOperationException("ExtraTooLong");
		}
		ArraySegment<byte> body = Data;
		int bodyLength = ((body.Array != null) ? body.Count : 0);
		int totalLength = extraLength + keyLength + bodyLength;
		byte[] header = new byte[24];
		fixed (byte* buffer = header)
		{
			*buffer = 128;
			buffer[1] = Operation;
			buffer[2] = (byte)(keyLength >> 8);
			buffer[3] = (byte)((uint)keyLength & 0xFFu);
			buffer[4] = (byte)extraLength;
			buffer[6] = (byte)(Reserved >> 8);
			buffer[7] = (byte)(Reserved & 0xFFu);
			buffer[8] = (byte)(totalLength >> 24);
			buffer[9] = (byte)(totalLength >> 16);
			buffer[10] = (byte)(totalLength >> 8);
			buffer[11] = (byte)((uint)totalLength & 0xFFu);
			buffer[12] = (byte)(CorrelationId >> 24);
			buffer[13] = (byte)(CorrelationId >> 16);
			buffer[14] = (byte)(CorrelationId >> 8);
			buffer[15] = (byte)((uint)CorrelationId & 0xFFu);
			ulong cas = Cas;
			if (cas != 0)
			{
				buffer[16] = (byte)(cas >> 56);
				buffer[17] = (byte)(cas >> 48);
				buffer[18] = (byte)(cas >> 40);
				buffer[19] = (byte)(cas >> 32);
				buffer[20] = (byte)(cas >> 24);
				buffer[21] = (byte)(cas >> 16);
				buffer[22] = (byte)(cas >> 8);
				buffer[23] = (byte)(cas & 0xFF);
			}
		}
		IList<ArraySegment<byte>> retval = appendTo ?? new List<ArraySegment<byte>>(4);
		retval.Add(new ArraySegment<byte>(header));
		if (extraLength > 0)
		{
			retval.Add(extras);
		}
		if (keyLength > 0)
		{
			retval.Add(new ArraySegment<byte>(keyData));
		}
		if (bodyLength > 0)
		{
			retval.Add(body);
		}
		return retval;
	}
}
