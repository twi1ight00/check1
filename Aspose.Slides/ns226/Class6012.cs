using System;
using System.IO;
using System.Text;

namespace ns226;

internal abstract class Class6012
{
	private static int int_0 = 8192;

	private int int_1;

	private int int_2;

	private bool bool_0;

	protected Class6012(int filledLength, int storageLength, bool growable)
	{
		int_1 = storageLength;
		method_6(filledLength);
		bool_0 = growable;
	}

	protected Class6012(int filledLength, int storageLength)
		: this(filledLength, storageLength, growable: false)
	{
	}

	public int method_0(int index)
	{
		if (index >= 0 && index < int_2)
		{
			return vmethod_2(index) & 0xFF;
		}
		return -1;
	}

	public int method_1(int index, byte[] b)
	{
		return method_2(index, b, 0, b.Length);
	}

	public int method_2(int index, byte[] b, int offset, int length)
	{
		if (index >= 0 && index < int_2)
		{
			int length2 = Math.Min(length, int_2 - index);
			return vmethod_3(index, b, offset, length2);
		}
		return 0;
	}

	public int method_3()
	{
		return int_2;
	}

	public int method_4()
	{
		return int_1;
	}

	public bool method_5()
	{
		return bool_0;
	}

	public int method_6(int filledLength)
	{
		int_2 = Math.Min(filledLength, int_1);
		return int_2;
	}

	public void method_7(int index, byte b)
	{
		if (index < 0 || index >= method_4())
		{
			throw new IndexOutOfRangeException("Attempt to write outside the bounds of the data.");
		}
		vmethod_0(index, b);
		int_2 = Math.Max(int_2, index + 1);
	}

	public int method_8(int index, byte[] b)
	{
		return method_9(index, b, 0, b.Length);
	}

	public int method_9(int index, byte[] b, int offset, int length)
	{
		if (index < 0 || index >= method_4())
		{
			throw new IndexOutOfRangeException("Attempt to write outside the bounds of the data.");
		}
		int length2 = Math.Min(length, method_4() - index);
		int num = vmethod_1(index, b, offset, length2);
		int_2 = Math.Max(int_2, index + num);
		return num;
	}

	public int CopyTo(Class6012 array)
	{
		return CopyTo(array, 0, method_3());
	}

	public int CopyTo(Class6012 array, int offset, int length)
	{
		return CopyTo(0, array, offset, length);
	}

	public int CopyTo(int dstOffset, Class6012 array, int srcOffset, int length)
	{
		byte[] array2 = new byte[int_0];
		int num = 0;
		int num2 = 0;
		int length2 = Math.Min(array2.Length, length);
		while ((num = method_2(num2 + srcOffset, array2, 0, length2)) > 0)
		{
			array.method_9(num2 + dstOffset, array2, 0, num);
			num2 += num;
			length -= num;
			length2 = Math.Min(array2.Length, length);
		}
		return num2;
	}

	public int CopyTo(StreamWriter os)
	{
		return CopyTo(os, 0, method_3());
	}

	public virtual int CopyTo(StreamWriter os, int offset, int length)
	{
		byte[] array = new byte[int_0];
		int num = 0;
		int num2 = 0;
		int length2 = Math.Min(array.Length, length);
		while ((num = method_2(num2 + offset, array, 0, length2)) > 0)
		{
			os.BaseStream.Write(array, 0, num);
			num2 += num;
			length2 = Math.Min(array.Length, length - num2);
		}
		return num2;
	}

	public void CopyFrom(StreamReader @is, int length)
	{
		byte[] array = new byte[int_0];
		int num = 0;
		int num2 = 0;
		int count = Math.Min(array.Length, length);
		while (true)
		{
			if ((num = @is.BaseStream.Read(array, 0, count)) > 0)
			{
				if (method_9(num2, array, 0, num) != num)
				{
					break;
				}
				num2 += num;
				length -= num;
				count = Math.Min(array.Length, length);
				continue;
			}
			return;
		}
		throw new IOException("Error writing bytes.");
	}

	public void CopyFrom(StreamReader @is)
	{
		byte[] array = new byte[int_0];
		int num = 0;
		int num2 = 0;
		int count = array.Length;
		while (true)
		{
			if ((num = @is.BaseStream.Read(array, 0, count)) > 0)
			{
				if (method_9(num2, array, 0, num) != num)
				{
					break;
				}
				num2 += num;
				continue;
			}
			return;
		}
		throw new IOException("Error writing bytes.");
	}

	protected abstract void vmethod_0(int index, byte b);

	protected abstract int vmethod_1(int index, byte[] b, int offset, int length);

	protected abstract int vmethod_2(int index);

	protected abstract int vmethod_3(int index, byte[] b, int offset, int length);

	public abstract void Close();

	public string method_10(int offset, int length)
	{
		if (length == -1)
		{
			length = method_3();
		}
		length = Math.Min(length, method_3());
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("[l=" + int_2 + ", s=" + method_4() + "]");
		if (length > 0)
		{
			stringBuilder.Append("\n");
		}
		for (int i = 0; i < length; i++)
		{
			int num = method_0(i + offset);
			if (num < 16)
			{
				stringBuilder.Append("0");
			}
			stringBuilder.Append($"{num:x}");
			stringBuilder.Append(" ");
			if (i > 0 && (i + 1) % 16 == 0)
			{
				stringBuilder.Append("\n");
			}
		}
		return stringBuilder.ToString();
	}

	public string method_11()
	{
		return method_10(0, 0);
	}
}
