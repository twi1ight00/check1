using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using ns22;
using ns40;

namespace ns18;

internal class Class1446
{
	private Stream stream_0;

	private Class945 class945_0;

	public Class1446(Stream stream_1)
	{
		if (stream_1 == null)
		{
			throw new ArgumentNullException("stream");
		}
		stream_0 = stream_1;
	}

	[SpecialName]
	public Stream method_0()
	{
		return stream_0;
	}

	public void Close()
	{
		stream_0.Close();
	}

	public void Write(byte byte_0)
	{
		stream_0.WriteByte(byte_0);
	}

	public void Write(string string_0)
	{
		for (int i = 0; i < string_0.Length; i++)
		{
			stream_0.WriteByte((byte)string_0[i]);
		}
	}

	public void method_1(byte[] byte_0)
	{
		foreach (byte int_ in byte_0)
		{
			Write(Class1025.smethod_5(int_));
		}
	}

	public void Write(string string_0, object object_0)
	{
		Write(string.Format(string_0, object_0));
	}

	public void Write(string string_0, object object_0, object object_1)
	{
		Write(string.Format(string_0, object_0, object_1));
	}

	public void Write(byte[] byte_0, int int_0, int int_1)
	{
		stream_0.Write(byte_0, int_0, int_1);
	}

	public void method_2(string string_0)
	{
		Write(string_0);
		Write(" ");
	}

	public void method_3(string string_0, object object_0)
	{
		Write(string_0, object_0);
		Write(" ");
	}

	public void method_4(string string_0, object object_0, object object_1)
	{
		Write(string_0, object_0, object_1);
		Write(" ");
	}

	public void method_5()
	{
		Write("\r\n");
	}

	public void method_6(string string_0)
	{
		Write(string_0);
		method_5();
	}

	public void method_7(string string_0, object object_0)
	{
		method_6(string.Format(string_0, object_0));
	}

	public void method_8(string string_0, object object_0, object object_1)
	{
		method_6(string.Format(string_0, object_0, object_1));
	}

	public void method_9()
	{
		Write("<<");
	}

	public void method_10()
	{
		Write(">>");
	}

	public void method_11(string string_0, string string_1)
	{
		if (string_1 != null && !(string_1 == string.Empty))
		{
			Write(string_0);
			Write(" ");
			Write(string_1);
			Write(" ");
		}
	}

	public void method_12(string string_0, string string_1)
	{
		if (string_1 != null && !(string_1 == string.Empty))
		{
			Write(string_0);
			if (method_21() == null)
			{
				Write("(");
				Write(string_1);
				Write(")");
			}
			else
			{
				Write("<");
				byte[] byte_ = method_21().method_7(string_1);
				method_1(byte_);
				Write(">");
			}
		}
	}

	public void method_13(string string_0, string string_1)
	{
		if (string_1 == null || string_1 == string.Empty)
		{
			return;
		}
		Write(string_0);
		if (method_21() == null)
		{
			Write("(");
			Write(254);
			Write(byte.MaxValue);
			foreach (int num in string_1)
			{
				method_20((byte)((uint)(num >> 8) & 0xFFu));
				method_20((byte)((uint)num & 0xFFu));
			}
			Write(")");
		}
		else
		{
			Write("<");
			byte[] byte_ = method_21().method_6(string_1);
			method_1(byte_);
			Write(">");
		}
	}

	public void method_14(string string_0, RectangleF rectangleF_0)
	{
		method_11(string_0, smethod_4(rectangleF_0));
	}

	public void method_15(string string_0, DateTime dateTime_0)
	{
		if (!(dateTime_0 == DateTime.MinValue))
		{
			if (method_21() == null)
			{
				string string_ = smethod_0(dateTime_0);
				method_11(string_0, string_);
				return;
			}
			string string_2 = smethod_1(dateTime_0);
			Write(string_0);
			Write("<");
			byte[] byte_ = method_21().method_7(string_2);
			method_1(byte_);
			Write(">");
		}
	}

	public void method_16(string string_0, int int_0)
	{
		method_11(string_0, int_0.ToString());
	}

	public void method_17(string string_0, float float_0)
	{
		method_11(string_0, smethod_5(float_0));
	}

	public void method_18(string string_0)
	{
		for (int i = 0; i < string_0.Length; i++)
		{
			method_20((byte)string_0[i]);
		}
	}

	public void method_19(byte[] byte_0)
	{
		for (int i = 0; i < byte_0.Length; i++)
		{
			method_20(byte_0[i]);
		}
	}

	public void method_20(byte byte_0)
	{
		switch (byte_0)
		{
		default:
			Write(byte_0);
			break;
		case 40:
		case 41:
		case 92:
			Write(92);
			Write(byte_0);
			break;
		case 13:
			Write("\\015");
			break;
		}
	}

	public static string smethod_0(DateTime dateTime_0)
	{
		return $"(D:{dateTime_0:yyyyMMddHHmmss}Z)";
	}

	public static string smethod_1(DateTime dateTime_0)
	{
		return $"D:{dateTime_0:yyyyMMddHHmmss}Z";
	}

	public static string smethod_2(PointF pointF_0)
	{
		return $"{smethod_5(pointF_0.X)} {smethod_5(pointF_0.Y)}";
	}

	public static string smethod_3(PointF[] pointF_0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < pointF_0.Length; i++)
		{
			stringBuilder.Append(smethod_2(pointF_0[i]));
			if (i < pointF_0.Length - 1)
			{
				stringBuilder.Append(" ");
			}
		}
		return stringBuilder.ToString();
	}

	public static string smethod_4(RectangleF rectangleF_0)
	{
		return $"[{smethod_5(rectangleF_0.Left)} {smethod_5(rectangleF_0.Top)} {smethod_5(rectangleF_0.Right)} {smethod_5(rectangleF_0.Bottom)}]";
	}

	public static string smethod_5(float float_0)
	{
		return float_0.ToString("0.####", CultureInfo.InvariantCulture);
	}

	public static string smethod_6(int int_0)
	{
		return int_0.ToString("G", CultureInfo.InvariantCulture);
	}

	public static string smethod_7(DateTime dateTime_0)
	{
		return $"{dateTime_0:yyyy-MM-ddTHH:mm:ssZ}";
	}

	public static string smethod_8(float[] float_0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < float_0.Length; i++)
		{
			stringBuilder.Append(smethod_5(float_0[i]));
			if (i < float_0.Length - 1)
			{
				stringBuilder.Append(" ");
			}
		}
		return stringBuilder.ToString();
	}

	public static string smethod_9(Color color_0)
	{
		return $"{smethod_5((float)(int)color_0.R / 255f)} {smethod_5((float)(int)color_0.G / 255f)} {smethod_5((float)(int)color_0.B / 255f)}";
	}

	[SpecialName]
	internal Class945 method_21()
	{
		return class945_0;
	}

	[SpecialName]
	internal void method_22(Class945 class945_1)
	{
		class945_0 = class945_1;
	}
}
