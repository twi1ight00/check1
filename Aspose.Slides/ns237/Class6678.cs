using System;
using System.Drawing;
using System.IO;
using System.Text;
using ns218;
using ns224;
using ns234;

namespace ns237;

internal class Class6678
{
	internal const float float_0 = 32767f;

	private readonly Stream stream_0;

	private Class6549 class6549_0;

	public Stream BaseStream => stream_0;

	public Class6678(Stream stream)
	{
		if (stream == null)
		{
			throw new ArgumentNullException("stream");
		}
		stream_0 = stream;
		class6549_0 = null;
	}

	public void Close()
	{
		stream_0.Close();
	}

	public void WriteByte(byte value)
	{
		stream_0.WriteByte(value);
	}

	public void Write(string text)
	{
		for (int i = 0; i < text.Length; i++)
		{
			stream_0.WriteByte((byte)text[i]);
		}
	}

	public void Write(string format, string arg0)
	{
		Write(string.Format(format, arg0));
	}

	public void Write(string format, string arg0, string arg1)
	{
		Write(string.Format(format, arg0, arg1));
	}

	public void Write(string format, string arg0, string arg1, string arg2)
	{
		Write(string.Format(format, arg0, arg1, arg2));
	}

	public void Write(byte[] buffer, int index, int count)
	{
		stream_0.Write(buffer, index, count);
	}

	public void method_0(string text)
	{
		Write(text);
		method_1();
	}

	public void method_1()
	{
		Write(" ");
	}

	public void Write(float value)
	{
		Write(smethod_2(value));
	}

	public void method_2()
	{
		Write("\r\n");
	}

	public void method_3(string text)
	{
		Write(text);
		method_2();
	}

	public void method_4(string format, string arg0)
	{
		method_3(string.Format(format, arg0));
	}

	public void method_5(string format, string arg0, string arg1)
	{
		method_3(string.Format(format, arg0, arg1));
	}

	public void method_6()
	{
		Write("<<");
	}

	public void method_7()
	{
		Write(">>");
	}

	public void method_8(string name, string value)
	{
		if (Class5964.smethod_20(value))
		{
			Write(name);
			method_1();
			Write(value);
		}
	}

	public void method_9(string name, bool value)
	{
		method_8(name, smethod_0(value));
	}

	private static string smethod_0(bool value)
	{
		if (!value)
		{
			return "false";
		}
		return "true";
	}

	public void method_10(string name, bool[] value)
	{
		Write(name);
		method_1();
		method_24(value);
	}

	public void method_11(string name, float[] value)
	{
		Write(name);
		method_1();
		method_25(value);
	}

	public void method_12(string name, int[] value)
	{
		Write(name);
		method_1();
		method_26(value);
	}

	public void method_13(string name, string value)
	{
		if (Class5964.smethod_20(value))
		{
			Write(name);
			method_15(value);
		}
	}

	public void method_14(string name, string value, bool isEscape)
	{
		if (!Class5964.smethod_20(value))
		{
			return;
		}
		Write(name);
		if (class6549_0 != null)
		{
			byte[] array = new byte[value.Length];
			Encoding.ASCII.GetBytes(value, 0, value.Length, array, 0);
			byte[] bytes = class6549_0.Encrypt(array);
			Write("<");
			Write(Class5964.smethod_41(bytes));
			Write(">");
		}
		else
		{
			Write("(");
			if (isEscape)
			{
				method_21(value);
			}
			else
			{
				Write(value);
			}
			Write(")");
		}
	}

	public void method_15(string value)
	{
		if (class6549_0 != null)
		{
			int num = value.Length * 2 + 2;
			byte[] array = new byte[num];
			array[0] = 254;
			array[1] = byte.MaxValue;
			Encoding.BigEndianUnicode.GetBytes(value, 0, value.Length, array, 2);
			byte[] bytes = class6549_0.Encrypt(array);
			Write("<");
			Write(Class5964.smethod_41(bytes));
			Write(">");
		}
		else
		{
			Write("(");
			WriteByte(254);
			WriteByte(byte.MaxValue);
			foreach (int value2 in value)
			{
				method_22(value2);
			}
			Write(")");
		}
	}

	public void method_16(string name, RectangleF value)
	{
		Write(name);
		method_1();
		Write("[");
		Write(value.Left);
		method_1();
		Write(value.Top);
		method_1();
		Write(value.Right);
		method_1();
		Write(value.Bottom);
		Write("]");
	}

	public void method_17(string name, DateTime value)
	{
		if (!(value == DateTime.MinValue))
		{
			string value2 = $"D:{Class6159.smethod_2(value)}";
			method_14(name, value2, isEscape: true);
		}
	}

	public void method_18(string name, int value)
	{
		method_8(name, Class6159.smethod_24(value));
	}

	public void method_19(string name, float value)
	{
		method_8(name, smethod_2(value));
	}

	public void method_20(string name, Class6002 matrix)
	{
		Write(name);
		method_1();
		Write("[");
		method_27(matrix);
		Write("]");
	}

	public void method_21(string text)
	{
		for (int i = 0; i < text.Length; i++)
		{
			method_23((byte)text[i]);
		}
	}

	public void method_22(int value)
	{
		method_23((byte)(value >> 8));
		method_23((byte)value);
	}

	public void method_23(byte value)
	{
		switch (value)
		{
		default:
			WriteByte(value);
			break;
		case 40:
		case 41:
		case 92:
			WriteByte(92);
			WriteByte(value);
			break;
		case 13:
			Write("\\015");
			break;
		}
	}

	public void method_24(bool[] values)
	{
		Write("[");
		for (int i = 0; i < values.Length; i++)
		{
			Write(smethod_0(values[i]));
			if (i < values.Length - 1)
			{
				method_1();
			}
		}
		Write("]");
	}

	public void method_25(float[] values)
	{
		Write("[");
		for (int i = 0; i < values.Length; i++)
		{
			Write(values[i]);
			if (i < values.Length - 1)
			{
				method_1();
			}
		}
		Write("]");
	}

	public void method_26(int[] values)
	{
		Write("[");
		for (int i = 0; i < values.Length; i++)
		{
			Write(Class6159.smethod_24(values[i]));
			if (i < values.Length - 1)
			{
				method_1();
			}
		}
		Write("]");
	}

	public void method_27(Class6002 matrix)
	{
		Write(matrix.M11);
		method_1();
		Write(matrix.M12);
		method_1();
		Write(matrix.M21);
		method_1();
		Write(matrix.M22);
		method_1();
		Write(matrix.M31);
		method_1();
		Write(matrix.M32);
	}

	internal void method_28(Class6549 encryptor)
	{
		class6549_0 = encryptor;
	}

	internal static string smethod_1(Class5998 value)
	{
		return $"{smethod_2((float)value.R / 255f)} {smethod_2((float)value.G / 255f)} {smethod_2((float)value.B / 255f)}";
	}

	internal static string smethod_2(float value)
	{
		return Class6159.smethod_42(value);
	}

	internal static int smethod_3(float x, float y)
	{
		return (int)(Math.Max(Math.Abs(x), Math.Abs(y)) / 32767f) + 1;
	}
}
