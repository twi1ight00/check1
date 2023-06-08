using System;
using System.IO;
using System.Text;
using ns223;

namespace ns161;

internal class Class4775
{
	private const int int_0 = 8;

	private int int_1;

	private string string_0;

	private Stream stream_0;

	public bool Equals(Class4775 other)
	{
		if (object.ReferenceEquals(null, other))
		{
			return false;
		}
		if (object.ReferenceEquals(this, other))
		{
			return true;
		}
		if (object.Equals(other.string_0, string_0) && other.int_1 == int_1)
		{
			return method_1(other.stream_0, stream_0);
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (object.ReferenceEquals(null, obj))
		{
			return false;
		}
		if (object.ReferenceEquals(this, obj))
		{
			return true;
		}
		if (obj.GetType() != typeof(Class4775))
		{
			return false;
		}
		return Equals((Class4775)obj);
	}

	public override int GetHashCode()
	{
		return (((string_0 != null) ? string_0.GetHashCode() : 0) * 397) ^ int_1;
	}

	public static bool operator ==(Class4775 left, Class4775 right)
	{
		return object.Equals(left, right);
	}

	public static bool operator !=(Class4775 left, Class4775 right)
	{
		return !object.Equals(left, right);
	}

	public Class4775(Stream stream)
	{
		stream.Seek(0L, SeekOrigin.Begin);
		int_1 = (int)stream.Length;
		string_0 = method_0(stream);
		stream_0 = stream;
	}

	protected string method_0(Stream stream)
	{
		Class5983 @class = new Class5983();
		byte[] array = @class.ComputeHash(stream);
		stream.Seek(0L, SeekOrigin.Begin);
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < array.Length; i++)
		{
			stringBuilder.Append(array[i].ToString("x2"));
		}
		return stringBuilder.ToString();
	}

	protected bool method_1(Stream first, Stream second)
	{
		first.Seek(0L, SeekOrigin.Begin);
		second.Seek(0L, SeekOrigin.Begin);
		int num = (int)Math.Ceiling((double)first.Length / 8.0);
		byte[] array = new byte[8];
		byte[] array2 = new byte[8];
		int num2 = 0;
		while (true)
		{
			if (num2 < num)
			{
				first.Read(array, 0, 8);
				second.Read(array2, 0, 8);
				if (BitConverter.ToInt64(array, 0) != BitConverter.ToInt64(array2, 0))
				{
					break;
				}
				num2++;
				continue;
			}
			while (true)
			{
				if (num2 < first.Length)
				{
					if (first.ReadByte() != second.ReadByte())
					{
						break;
					}
					num2++;
					continue;
				}
				return true;
			}
			return false;
		}
		return false;
	}
}
