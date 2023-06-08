using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using ns218;

namespace ns274;

internal class Class6717
{
	private const short short_0 = 1252;

	private const short short_1 = 1200;

	private const int int_0 = 4;

	private const int int_1 = 0;

	private const int int_2 = 1;

	private const int int_3 = 2;

	private const int int_4 = int.MaxValue;

	private const int int_5 = int.MinValue;

	private const int int_6 = -2147483645;

	private Guid guid_0 = Guid.Empty;

	private readonly Class6715 class6715_0;

	private readonly int int_7;

	public static Guid guid_1 = new Guid("F29F85E0-4FF9-1068-AB91-08002B27B3D9");

	public static Guid guid_2 = new Guid("D5CDD502-2E9C-101B-9397-08002B2CF9AE");

	public static Guid guid_3 = new Guid("D5CDD505-2E9C-101B-9397-08002B2CF9AE");

	public Class6715 Properties => class6715_0;

	public Guid FmtId => guid_0;

	public int CodePage => int_7;

	private Class6717(Guid fmtId)
	{
		guid_0 = fmtId;
		class6715_0 = new Class6715();
	}

	public Class6717(Guid fmtId, int codePage)
		: this(fmtId)
	{
		if (codePage <= 0)
		{
			throw new ArgumentOutOfRangeException("codePage");
		}
		int_7 = codePage;
	}

	public Class6717(Guid fmtId, BinaryReader reader)
		: this(fmtId)
	{
		long position = reader.BaseStream.Position;
		reader.ReadInt32();
		int num = reader.ReadInt32();
		List<Class6718> list = new List<Class6718>();
		for (int i = 0; i < num; i++)
		{
			list.Add(new Class6718(reader));
		}
		int_7 = 1252;
		int num2 = smethod_0(list, 1);
		if (num2 != -1)
		{
			reader.BaseStream.Position = position + num2;
			if (smethod_3(reader, 0) is short num3)
			{
				int_7 = num3 & 0xFFFF;
			}
		}
		Hashtable hashtable = new Hashtable();
		int num4 = smethod_0(list, 0);
		if (num4 != -1)
		{
			reader.BaseStream.Position = position + num4;
			smethod_1(reader, hashtable, int_7);
		}
		for (int j = 0; j < list.Count; j++)
		{
			Class6718 @class = list[j];
			long num5 = @class.int_0 & 0xFFFFFFFL;
			if (num5 >= 2L && num5 <= 2147483647L)
			{
				reader.BaseStream.Position = position + @class.int_1;
				object obj = smethod_3(reader, int_7);
				if (obj != null)
				{
					string name = (string)hashtable[@class.int_0];
					class6715_0.Add(new Class6714(@class.int_0, name, obj));
				}
			}
		}
	}

	private static int smethod_0(List<Class6718> propIdOffsets, int propId)
	{
		int num = 0;
		Class6718 @class;
		while (true)
		{
			if (num < propIdOffsets.Count)
			{
				@class = propIdOffsets[num];
				if (@class.int_0 == propId)
				{
					break;
				}
				num++;
				continue;
			}
			return -1;
		}
		return @class.int_1;
	}

	public byte[] method_0()
	{
		MemoryStream memoryStream = new MemoryStream();
		BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
		int num = 16 + 8 * class6715_0.Count;
		bool flag;
		if (flag = class6715_0.HasNames || guid_0.Equals(guid_3))
		{
			num += 8;
		}
		memoryStream.Position = num;
		List<Class6718> list = new List<Class6718>();
		if (flag)
		{
			list.Add(new Class6718(0, (int)memoryStream.Position));
			smethod_2(binaryWriter, class6715_0, int_7);
		}
		list.Add(new Class6718(1, (int)memoryStream.Position));
		smethod_5(binaryWriter, (short)int_7, int_7, isAlignRequired: true);
		for (int i = 0; i < class6715_0.Count; i++)
		{
			Class6714 @class = class6715_0[i];
			list.Add(new Class6718(@class.int_0, (int)memoryStream.Position));
			smethod_5(binaryWriter, @class.object_0, int_7, isAlignRequired: true);
		}
		memoryStream.Position = 0L;
		binaryWriter.Write((int)memoryStream.Length);
		binaryWriter.Write(list.Count);
		for (int j = 0; j < list.Count; j++)
		{
			Class6718 class2 = list[j];
			class2.Write(binaryWriter);
		}
		return memoryStream.ToArray();
	}

	private static void smethod_1(BinaryReader reader, Hashtable propNames, int codePage)
	{
		int num = reader.ReadInt32();
		for (int i = 0; i < num; i++)
		{
			int num2 = reader.ReadInt32();
			string value = smethod_10(reader, codePage);
			if (Class5964.smethod_20(value))
			{
				propNames.Add(num2, value);
				continue;
			}
			break;
		}
	}

	private static void smethod_2(BinaryWriter writer, Class6715 props, int codePage)
	{
		writer.Write(props.CountOfPropertiesWithNames);
		for (int i = 0; i < props.Count; i++)
		{
			Class6714 @class = props[i];
			if (@class.HasName)
			{
				writer.Write(@class.int_0);
				smethod_11(writer, @class.string_0, codePage);
			}
		}
	}

	private static object smethod_3(BinaryReader reader, int codePage)
	{
		switch ((VarEnum)reader.ReadInt32())
		{
		case VarEnum.VT_UI4:
			return reader.ReadUInt32();
		case VarEnum.VT_BOOL:
			return reader.ReadInt16() != 0;
		case VarEnum.VT_I2:
			return reader.ReadInt16();
		case VarEnum.VT_I4:
			return reader.ReadInt32();
		case VarEnum.VT_R8:
			return reader.ReadDouble();
		case VarEnum.VT_FILETIME:
		{
			long num2 = reader.ReadInt64();
			if (num2 > DateTime.MinValue.Ticks && num2 <= DateTime.MaxValue.Ticks)
			{
				return Class5964.smethod_17(num2, "ticks");
			}
			return DateTime.MinValue;
		}
		case VarEnum.VT_BLOB:
		{
			int count = reader.ReadInt32();
			return reader.ReadBytes(count);
		}
		case VarEnum.VT_LPSTR:
			return smethod_6(reader, codePage);
		case VarEnum.VT_LPWSTR:
		{
			string result = smethod_8(reader);
			Class5964.smethod_7(reader.BaseStream, 4);
			return result;
		}
		default:
			return null;
		case (VarEnum)4126:
		{
			int codePage2 = ((codePage != 1200) ? codePage : 1252);
			return smethod_4(reader, codePage2);
		}
		case (VarEnum)4127:
			return smethod_4(reader, codePage);
		case (VarEnum)4108:
		{
			int num = reader.ReadInt32();
			object[] array = new object[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = smethod_3(reader, codePage);
			}
			return array;
		}
		}
	}

	private static string[] smethod_4(BinaryReader reader, int codePage)
	{
		int num = reader.ReadInt32();
		string[] array = new string[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = smethod_10(reader, codePage);
		}
		return array;
	}

	private static void smethod_5(BinaryWriter writer, object value, int codePage, bool isAlignRequired)
	{
		bool flag = false;
		try
		{
			if (value is string s)
			{
				if (codePage == 1200)
				{
					writer.Write(31);
				}
				else
				{
					writer.Write(30);
				}
				smethod_11(writer, s, codePage);
				return;
			}
			if (value is short)
			{
				writer.Write(2);
				writer.Write((short)value);
				return;
			}
			if (value is int)
			{
				writer.Write(3);
				writer.Write((int)value);
				return;
			}
			if (value is uint)
			{
				writer.Write(19);
				writer.Write((uint)value);
				return;
			}
			if (value is double)
			{
				writer.Write(5);
				writer.Write((double)value);
				return;
			}
			if (value is bool)
			{
				writer.Write(11);
				bool flag2 = (bool)value;
				writer.Write((short)(flag2 ? (-1) : 0));
				return;
			}
			if (value is DateTime)
			{
				writer.Write(64);
				DateTime dateTime = (DateTime)value;
				if (dateTime != DateTime.MinValue)
				{
					writer.Write(Class5964.smethod_18(dateTime, "dateTime"));
				}
				else
				{
					writer.Write(0L);
				}
				return;
			}
			if (value is byte[] array)
			{
				writer.Write(65);
				writer.Write(array.Length);
				writer.Write(array);
				return;
			}
			if (value is string[] array2)
			{
				if (codePage == 1200)
				{
					writer.Write(4127);
				}
				else
				{
					writer.Write(4126);
				}
				writer.Write(array2.Length);
				string[] array3 = array2;
				foreach (string s2 in array3)
				{
					smethod_11(writer, s2, codePage);
				}
				return;
			}
			if (value is object[] array4)
			{
				writer.Write(4108);
				writer.Write(array4.Length);
				object[] array5 = array4;
				foreach (object value2 in array5)
				{
					smethod_5(writer, value2, codePage, isAlignRequired: false);
				}
				return;
			}
			throw new NotSupportedException("Do not know how to write a property value of this type.");
		}
		catch
		{
			flag = true;
			throw;
		}
		finally
		{
			if (!flag && isAlignRequired)
			{
				Class5964.smethod_7(writer.BaseStream, 4);
			}
		}
	}

	private static string smethod_6(BinaryReader reader, int codePage)
	{
		int num = reader.ReadInt32();
		if (!Class5964.smethod_47(reader, num))
		{
			num = 0;
		}
		byte[] bytes = reader.ReadBytes(num);
		string @string = Encoding.GetEncoding(codePage).GetString(bytes, 0, num);
		char[] trimChars = new char[1];
		return @string.TrimEnd(trimChars);
	}

	private static void smethod_7(BinaryWriter writer, string s, int codePage)
	{
		s += '\0';
		byte[] bytes = Encoding.GetEncoding(codePage).GetBytes(s);
		writer.Write(bytes.Length);
		writer.Write(bytes);
	}

	private static string smethod_8(BinaryReader reader)
	{
		int num = reader.ReadInt32() * 2;
		byte[] bytes = reader.ReadBytes(num);
		return Encoding.Unicode.GetString(bytes, 0, num - 2);
	}

	private static void smethod_9(BinaryWriter writer, string s)
	{
		writer.Write(s.Length + 1);
		writer.Write(Encoding.Unicode.GetBytes(s));
		writer.Write((short)0);
	}

	private static string smethod_10(BinaryReader reader, int codePage)
	{
		string result;
		if (codePage == 1200)
		{
			result = smethod_8(reader);
			Class5964.smethod_7(reader.BaseStream, 4);
		}
		else
		{
			result = smethod_6(reader, codePage);
		}
		return result;
	}

	private static void smethod_11(BinaryWriter writer, string s, int codePage)
	{
		if (codePage == 1200)
		{
			smethod_9(writer, s);
			Class5964.smethod_7(writer.BaseStream, 4);
		}
		else
		{
			smethod_7(writer, s, codePage);
		}
	}
}
