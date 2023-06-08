using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Enyim.Caching.Memcached;

/// <summary>
/// Default <see cref="T:Enyim.Caching.Memcached.ITranscoder" /> implementation. Primitive types are manually serialized, the rest is serialized using <see cref="T:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter" />.
/// </summary>
public class DefaultTranscoder : ITranscoder
{
	public const uint RawDataFlag = 64082u;

	private static readonly ArraySegment<byte> NullArray = new ArraySegment<byte>(new byte[0]);

	CacheItem ITranscoder.Serialize(object value)
	{
		return Serialize(value);
	}

	object ITranscoder.Deserialize(CacheItem item)
	{
		return Deserialize(item);
	}

	protected virtual CacheItem Serialize(object value)
	{
		if (value is ArraySegment<byte>)
		{
			return new CacheItem(64082u, (ArraySegment<byte>)value);
		}
		if (value is byte[] tmpByteArray)
		{
			return new CacheItem(64082u, new ArraySegment<byte>(tmpByteArray));
		}
		TypeCode code = ((value == null) ? TypeCode.DBNull : Type.GetTypeCode(value.GetType()));
		ArraySegment<byte> data;
		switch (code)
		{
		case TypeCode.DBNull:
			data = SerializeNull();
			break;
		case TypeCode.String:
			data = SerializeString((string)value);
			break;
		case TypeCode.Boolean:
			data = SerializeBoolean((bool)value);
			break;
		case TypeCode.SByte:
			data = SerializeSByte((sbyte)value);
			break;
		case TypeCode.Byte:
			data = SerializeByte((byte)value);
			break;
		case TypeCode.Int16:
			data = SerializeInt16((short)value);
			break;
		case TypeCode.Int32:
			data = SerializeInt32((int)value);
			break;
		case TypeCode.Int64:
			data = SerializeInt64((long)value);
			break;
		case TypeCode.UInt16:
			data = SerializeUInt16((ushort)value);
			break;
		case TypeCode.UInt32:
			data = SerializeUInt32((uint)value);
			break;
		case TypeCode.UInt64:
			data = SerializeUInt64((ulong)value);
			break;
		case TypeCode.Char:
			data = SerializeChar((char)value);
			break;
		case TypeCode.DateTime:
			data = SerializeDateTime((DateTime)value);
			break;
		case TypeCode.Double:
			data = SerializeDouble((double)value);
			break;
		case TypeCode.Single:
			data = SerializeSingle((float)value);
			break;
		default:
			code = TypeCode.Object;
			data = SerializeObject(value);
			break;
		}
		return new CacheItem(TypeCodeToFlag(code), data);
	}

	public static uint TypeCodeToFlag(TypeCode code)
	{
		return (uint)(code | (TypeCode)256);
	}

	public static bool IsFlagHandled(uint flag)
	{
		return (flag & 0x100) == 256;
	}

	protected virtual object Deserialize(CacheItem item)
	{
		if (item.Data.Array == null)
		{
			return null;
		}
		if (item.Flags == 64082)
		{
			ArraySegment<byte> tmp = item.Data;
			if (tmp.Count == tmp.Array.Length)
			{
				return tmp.Array;
			}
			byte[] retval = new byte[tmp.Count];
			Array.Copy(tmp.Array, tmp.Offset, retval, 0, tmp.Count);
			return retval;
		}
		TypeCode code = (TypeCode)((int)item.Flags & 0xFF);
		ArraySegment<byte> data = item.Data;
		switch (code)
		{
		case TypeCode.Empty:
			if (data.Array != null && data.Count != 0)
			{
				return DeserializeString(data);
			}
			return null;
		case TypeCode.DBNull:
			return null;
		case TypeCode.String:
			return DeserializeString(data);
		case TypeCode.Boolean:
			return DeserializeBoolean(data);
		case TypeCode.Int16:
			return DeserializeInt16(data);
		case TypeCode.Int32:
			return DeserializeInt32(data);
		case TypeCode.Int64:
			return DeserializeInt64(data);
		case TypeCode.UInt16:
			return DeserializeUInt16(data);
		case TypeCode.UInt32:
			return DeserializeUInt32(data);
		case TypeCode.UInt64:
			return DeserializeUInt64(data);
		case TypeCode.Char:
			return DeserializeChar(data);
		case TypeCode.DateTime:
			return DeserializeDateTime(data);
		case TypeCode.Double:
			return DeserializeDouble(data);
		case TypeCode.Single:
			return DeserializeSingle(data);
		case TypeCode.Byte:
			return DeserializeByte(data);
		case TypeCode.SByte:
			return DeserializeSByte(data);
		case TypeCode.Object:
		case TypeCode.Decimal:
			return DeserializeObject(data);
		default:
			throw new InvalidOperationException("Unknown TypeCode was returned: " + code);
		}
	}

	protected virtual ArraySegment<byte> SerializeNull()
	{
		return NullArray;
	}

	protected virtual ArraySegment<byte> SerializeString(string value)
	{
		return new ArraySegment<byte>(Encoding.UTF8.GetBytes(value));
	}

	protected virtual ArraySegment<byte> SerializeByte(byte value)
	{
		return new ArraySegment<byte>(new byte[1] { value });
	}

	protected virtual ArraySegment<byte> SerializeSByte(sbyte value)
	{
		return new ArraySegment<byte>(new byte[1] { (byte)value });
	}

	protected virtual ArraySegment<byte> SerializeBoolean(bool value)
	{
		return new ArraySegment<byte>(BitConverter.GetBytes(value));
	}

	protected virtual ArraySegment<byte> SerializeInt16(short value)
	{
		return new ArraySegment<byte>(BitConverter.GetBytes(value));
	}

	protected virtual ArraySegment<byte> SerializeInt32(int value)
	{
		return new ArraySegment<byte>(BitConverter.GetBytes(value));
	}

	protected virtual ArraySegment<byte> SerializeInt64(long value)
	{
		return new ArraySegment<byte>(BitConverter.GetBytes(value));
	}

	protected virtual ArraySegment<byte> SerializeUInt16(ushort value)
	{
		return new ArraySegment<byte>(BitConverter.GetBytes(value));
	}

	protected virtual ArraySegment<byte> SerializeUInt32(uint value)
	{
		return new ArraySegment<byte>(BitConverter.GetBytes(value));
	}

	protected virtual ArraySegment<byte> SerializeUInt64(ulong value)
	{
		return new ArraySegment<byte>(BitConverter.GetBytes(value));
	}

	protected virtual ArraySegment<byte> SerializeChar(char value)
	{
		return new ArraySegment<byte>(BitConverter.GetBytes(value));
	}

	protected virtual ArraySegment<byte> SerializeDateTime(DateTime value)
	{
		return new ArraySegment<byte>(BitConverter.GetBytes(value.ToBinary()));
	}

	protected virtual ArraySegment<byte> SerializeDouble(double value)
	{
		return new ArraySegment<byte>(BitConverter.GetBytes(value));
	}

	protected virtual ArraySegment<byte> SerializeSingle(float value)
	{
		return new ArraySegment<byte>(BitConverter.GetBytes(value));
	}

	protected virtual ArraySegment<byte> SerializeObject(object value)
	{
		using MemoryStream ms = new MemoryStream();
		new BinaryFormatter().Serialize(ms, value);
		return new ArraySegment<byte>(ms.GetBuffer(), 0, (int)ms.Length);
	}

	protected virtual string DeserializeString(ArraySegment<byte> value)
	{
		return Encoding.UTF8.GetString(value.Array, value.Offset, value.Count);
	}

	protected virtual bool DeserializeBoolean(ArraySegment<byte> value)
	{
		return BitConverter.ToBoolean(value.Array, value.Offset);
	}

	protected virtual short DeserializeInt16(ArraySegment<byte> value)
	{
		return BitConverter.ToInt16(value.Array, value.Offset);
	}

	protected virtual int DeserializeInt32(ArraySegment<byte> value)
	{
		return BitConverter.ToInt32(value.Array, value.Offset);
	}

	protected virtual long DeserializeInt64(ArraySegment<byte> value)
	{
		return BitConverter.ToInt64(value.Array, value.Offset);
	}

	protected virtual ushort DeserializeUInt16(ArraySegment<byte> value)
	{
		return BitConverter.ToUInt16(value.Array, value.Offset);
	}

	protected virtual uint DeserializeUInt32(ArraySegment<byte> value)
	{
		return BitConverter.ToUInt32(value.Array, value.Offset);
	}

	protected virtual ulong DeserializeUInt64(ArraySegment<byte> value)
	{
		return BitConverter.ToUInt64(value.Array, value.Offset);
	}

	protected virtual char DeserializeChar(ArraySegment<byte> value)
	{
		return BitConverter.ToChar(value.Array, value.Offset);
	}

	protected virtual DateTime DeserializeDateTime(ArraySegment<byte> value)
	{
		return DateTime.FromBinary(BitConverter.ToInt64(value.Array, value.Offset));
	}

	protected virtual double DeserializeDouble(ArraySegment<byte> value)
	{
		return BitConverter.ToDouble(value.Array, value.Offset);
	}

	protected virtual float DeserializeSingle(ArraySegment<byte> value)
	{
		return BitConverter.ToSingle(value.Array, value.Offset);
	}

	protected virtual byte DeserializeByte(ArraySegment<byte> data)
	{
		return data.Array[data.Offset];
	}

	protected virtual sbyte DeserializeSByte(ArraySegment<byte> data)
	{
		return (sbyte)data.Array[data.Offset];
	}

	protected virtual object DeserializeObject(ArraySegment<byte> value)
	{
		using MemoryStream ms = new MemoryStream(value.Array, value.Offset, value.Count);
		return new BinaryFormatter().Deserialize(ms);
	}
}
