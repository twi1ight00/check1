using System;
using System.IO;
using System.Text;
using ns33;
using ns4;

namespace ns47;

internal class Class1147 : Interface37
{
	private Enum174 enum174_0;

	private byte[] byte_0;

	public Enum174 Type
	{
		get
		{
			return enum174_0;
		}
		set
		{
			enum174_0 = value;
		}
	}

	internal byte[] Data
	{
		get
		{
			return byte_0;
		}
		set
		{
			byte_0 = value;
		}
	}

	public Class1147(short i)
	{
		enum174_0 = Enum174.const_2;
		byte_0 = new byte[4];
		Class1162.smethod_15(byte_0, i);
	}

	public Class1147(int i)
	{
		enum174_0 = Enum174.const_3;
		byte_0 = new byte[4];
		Class1162.smethod_17(byte_0, i);
	}

	public Class1147(DateTime date)
	{
		enum174_0 = Enum174.const_31;
		byte_0 = new byte[8];
		DateTime dateTime = date;
		if (date < DateTime.FromFileTimeUtc(0L))
		{
			dateTime = DateTime.FromFileTimeUtc(0L);
		}
		Class1162.smethod_21(byte_0, dateTime.ToFileTimeUtc());
	}

	public Class1147(bool b)
	{
		enum174_0 = Enum174.const_11;
		byte_0 = new byte[4];
		Class1162.smethod_17(byte_0, b ? 65535 : 0);
	}

	public Class1147(string str)
		: this(str, unicode: true)
	{
	}

	public Class1147(string str, bool unicode)
	{
		int num = str.Length + 1;
		MemoryStream memoryStream = new MemoryStream();
		BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
		binaryWriter.Write((uint)num);
		if (num % 2 == 1)
		{
			num++;
		}
		byte[] array;
		if (unicode)
		{
			enum174_0 = Enum174.const_30;
			array = new byte[num * 2];
			byte[] bytes = Encoding.GetEncoding(1200).GetBytes(str);
			Array.Copy(bytes, array, bytes.Length);
		}
		else
		{
			enum174_0 = Enum174.const_29;
			array = new byte[num];
			byte[] bytes2 = Encoding.GetEncoding(1251).GetBytes(str);
			Array.Copy(bytes2, array, bytes2.Length);
		}
		binaryWriter.Write(array);
		binaryWriter.Close();
		byte_0 = memoryStream.ToArray();
	}

	internal Class1147(byte[] bytes)
	{
		enum174_0 = (Enum174)Class1162.smethod_1(bytes, 0);
		byte_0 = Class1162.smethod_34(bytes, 4, bytes.Length - 4);
	}

	public Class1147(Class1142 blob)
	{
		enum174_0 = Enum174.const_32;
		byte[] rawData = blob.RawData;
		byte_0 = Class1162.smethod_34(rawData, 0, rawData.Length);
	}

	public byte[] Write()
	{
		MemoryStream memoryStream = new MemoryStream();
		BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
		binaryWriter.Write((ushort)enum174_0);
		binaryWriter.Write((ushort)0);
		binaryWriter.Write(byte_0);
		int num = (int)memoryStream.Length % 4;
		if (num > 0)
		{
			binaryWriter.Write(new byte[num]);
		}
		binaryWriter.Close();
		return memoryStream.ToArray();
	}

	internal static object smethod_0(Class1147 prop, int codepage)
	{
		switch (prop.Type)
		{
		case Enum174.const_29:
		case Enum174.const_30:
			if (prop.Type == Enum174.const_30)
			{
				codepage = 1200;
			}
			try
			{
				string @string = Encoding.GetEncoding(codepage).GetString(prop.Data, 4, prop.Data.Length - 4);
				int length = @string.Length;
				int num3 = @string.IndexOf('\0');
				return (num3 < 0) ? @string : @string.Remove(num3, length - num3);
			}
			catch (Exception ex2)
			{
				Class1165.smethod_28(ex2);
				return "";
			}
		case Enum174.const_0:
		case Enum174.const_1:
			return null;
		case Enum174.const_2:
			return Class1162.smethod_0(prop.Data, 0);
		case Enum174.const_3:
			return Class1162.smethod_6(prop.Data, 0);
		case Enum174.const_4:
			return BitConverter.ToSingle(prop.Data, 0);
		case Enum174.const_5:
			return BitConverter.ToDouble(prop.Data, 0);
		case Enum174.const_11:
			return Class1162.smethod_8(prop.Data, 0) != 0L;
		default:
		{
			byte[] array = new byte[prop.Data.Length];
			Array.Copy(prop.Data, array, array.Length);
			return array;
		}
		case Enum174.const_31:
		{
			long num = Class1162.smethod_8(prop.Data, 0);
			long num2 = Class1162.smethod_8(prop.Data, 4);
			try
			{
				return DateTime.FromFileTimeUtc((num2 << 32) | (num & 0xFFFFFFFFL));
			}
			catch (Exception ex)
			{
				Class1165.smethod_28(ex);
				return DateTime.FromFileTimeUtc(0L);
			}
		}
		}
	}
}
