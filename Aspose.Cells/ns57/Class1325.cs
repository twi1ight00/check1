using System;
using System.Collections;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace ns57;

internal class Class1325
{
	private Guid guid_0;

	private Class1323 class1323_0 = new Class1323();

	internal static Guid guid_1 = new Guid("F29F85E0-4FF9-1068-AB91-08002B27B3D9");

	internal static Guid guid_2 = new Guid("D5CDD502-2E9C-101B-9397-08002B2CF9AE");

	internal static Guid guid_3 = new Guid("D5CDD505-2E9C-101B-9397-08002B2CF9AE");

	internal Class1323 Properties => class1323_0;

	internal Class1325(Guid guid_4)
	{
		guid_0 = guid_4;
	}

	internal Class1325(Guid guid_4, BinaryReader binaryReader_0)
	{
		guid_0 = guid_4;
		long position = binaryReader_0.BaseStream.Position;
		binaryReader_0.ReadInt32();
		int num = binaryReader_0.ReadInt32();
		Class1300 @class = new Class1300();
		for (int i = 0; i < num; i++)
		{
			@class.Add(new Class1326(binaryReader_0));
		}
		int int_ = 1252;
		int num2 = @class.method_0(1);
		if (num2 != -1)
		{
			binaryReader_0.BaseStream.Position = position + num2;
			short num3 = (short)smethod_2(binaryReader_0, 0);
			int_ = (ushort)num3;
		}
		Hashtable hashtable = new Hashtable();
		int num4 = @class.method_0(0);
		if (num4 != -1)
		{
			binaryReader_0.BaseStream.Position = position + num4;
			smethod_0(binaryReader_0, hashtable, int_);
		}
		for (int j = 0; j < @class.Count; j++)
		{
			int int_2 = @class[j].int_0;
			if (int_2 != 0 && int_2 != 1)
			{
				binaryReader_0.BaseStream.Position = position + @class[j].int_1;
				object obj = smethod_2(binaryReader_0, int_);
				if (obj != null)
				{
					string string_ = (string)hashtable[int_2];
					class1323_0.Add(new Class1322(int_2, string_, obj));
				}
			}
		}
	}

	internal byte[] method_0()
	{
		MemoryStream memoryStream = new MemoryStream();
		BinaryWriter binaryWriter = new BinaryWriter(memoryStream, Encoding.Unicode);
		int num = 8 + 8 * class1323_0.Count;
		if (class1323_0.method_0())
		{
			num += 8;
		}
		num += 8;
		memoryStream.Position = num;
		Class1300 @class = new Class1300();
		if (class1323_0.method_0())
		{
			@class.Add(new Class1326(0, (int)memoryStream.Position));
			smethod_1(binaryWriter, class1323_0);
		}
		@class.Add(new Class1326(1, (int)memoryStream.Position));
		smethod_3(binaryWriter, (short)1200);
		for (int i = 0; i < class1323_0.Count; i++)
		{
			Class1322 class2 = class1323_0[i];
			@class.Add(new Class1326(class2.int_0, (int)memoryStream.Position));
			smethod_3(binaryWriter, class2.object_0);
		}
		memoryStream.Position = 0L;
		binaryWriter.Write((int)memoryStream.Length);
		binaryWriter.Write(@class.Count);
		for (int j = 0; j < @class.Count; j++)
		{
			@class[j].Write(binaryWriter);
		}
		return memoryStream.ToArray();
	}

	[SpecialName]
	internal Guid method_1()
	{
		return guid_0;
	}

	private static void smethod_0(BinaryReader binaryReader_0, Hashtable hashtable_0, int int_0)
	{
		int num = binaryReader_0.ReadInt32();
		for (int i = 0; i < num; i++)
		{
			int num2 = binaryReader_0.ReadInt32();
			string value;
			if (int_0 == 1200)
			{
				value = smethod_5(binaryReader_0);
				Class1321.smethod_2(binaryReader_0.BaseStream, 4);
			}
			else
			{
				value = smethod_4(binaryReader_0, int_0);
			}
			if (hashtable_0[num2] == null)
			{
				hashtable_0.Add(num2, value);
			}
			else
			{
				hashtable_0[num2] = value;
			}
		}
	}

	private static void smethod_1(BinaryWriter binaryWriter_0, Class1323 class1323_1)
	{
		binaryWriter_0.Write(class1323_1.method_1());
		for (int i = 0; i < class1323_1.Count; i++)
		{
			Class1322 @class = class1323_1[i];
			if (@class.method_0())
			{
				binaryWriter_0.Write(@class.int_0);
				smethod_6(binaryWriter_0, @class.string_0);
				Class1321.smethod_2(binaryWriter_0.BaseStream, 4);
			}
		}
	}

	private static object smethod_2(BinaryReader binaryReader_0, int int_0)
	{
		switch ((VarEnum)binaryReader_0.ReadInt32())
		{
		case VarEnum.VT_BOOL:
			return binaryReader_0.ReadInt16() != 0;
		case VarEnum.VT_I2:
			return binaryReader_0.ReadInt16();
		case VarEnum.VT_I4:
			return binaryReader_0.ReadInt32();
		case VarEnum.VT_R8:
			return binaryReader_0.ReadDouble();
		default:
			return null;
		case VarEnum.VT_FILETIME:
			try
			{
				long num = binaryReader_0.ReadInt64();
				if (num == 0)
				{
					return DateTime.MinValue;
				}
				return Class1321.smethod_4(num, "FileTime");
			}
			catch (Exception)
			{
				return DateTime.Now;
			}
		case VarEnum.VT_BLOB:
		{
			int count = binaryReader_0.ReadInt32();
			return binaryReader_0.ReadBytes(count);
		}
		case VarEnum.VT_LPSTR:
			return smethod_4(binaryReader_0, int_0);
		case VarEnum.VT_LPWSTR:
			return smethod_5(binaryReader_0);
		case VarEnum.VT_UI4:
			return binaryReader_0.ReadUInt32();
		}
	}

	private static void smethod_3(BinaryWriter binaryWriter_0, object object_0)
	{
		if (object_0 is string)
		{
			binaryWriter_0.Write(31);
			smethod_6(binaryWriter_0, Convert.ToString(object_0));
		}
		else if (object_0 is short)
		{
			binaryWriter_0.Write(2);
			binaryWriter_0.Write(Convert.ToInt16(object_0));
		}
		else if (object_0 is int)
		{
			binaryWriter_0.Write(3);
			binaryWriter_0.Write(Convert.ToInt32(object_0));
		}
		else if (object_0 is uint)
		{
			binaryWriter_0.Write(19);
			binaryWriter_0.Write(Convert.ToUInt32(object_0));
		}
		else if (object_0 is double)
		{
			binaryWriter_0.Write(5);
			binaryWriter_0.Write(Convert.ToDouble(object_0));
		}
		else if (object_0 is bool)
		{
			binaryWriter_0.Write(11);
			bool flag = (bool)object_0;
			binaryWriter_0.Write((short)(flag ? (-1) : 0));
		}
		else if (object_0 is DateTime)
		{
			binaryWriter_0.Write(64);
			DateTime dateTime = Convert.ToDateTime(object_0);
			if (dateTime != DateTime.MinValue)
			{
				binaryWriter_0.Write(Class1321.smethod_5(dateTime, "FileTime"));
			}
			else
			{
				binaryWriter_0.Write(0L);
			}
		}
		else
		{
			if (!(object_0 is byte[]))
			{
				throw new NotSupportedException("Do not know how to write a property value of this type.");
			}
			binaryWriter_0.Write(65);
			byte[] array = (byte[])object_0;
			binaryWriter_0.Write(array.Length);
			binaryWriter_0.Write(array);
		}
		Class1321.smethod_2(binaryWriter_0.BaseStream, 4);
	}

	private static string smethod_4(BinaryReader binaryReader_0, int int_0)
	{
		int num = binaryReader_0.ReadInt32();
		Stream baseStream = binaryReader_0.BaseStream;
		if (num + baseStream.Position > baseStream.Length)
		{
			num = (int)(baseStream.Length - baseStream.Position);
		}
		byte[] bytes = binaryReader_0.ReadBytes(num);
		return Encoding.GetEncoding(int_0).GetString(bytes, 0, num).Replace("\0", "");
	}

	private static string smethod_5(BinaryReader binaryReader_0)
	{
		int num = binaryReader_0.ReadInt32() * 2;
		byte[] bytes = binaryReader_0.ReadBytes(num);
		return Encoding.Unicode.GetString(bytes, 0, num - 2);
	}

	private static void smethod_6(BinaryWriter binaryWriter_0, string string_0)
	{
		binaryWriter_0.Write(string_0.Length + 1);
		binaryWriter_0.Write(Encoding.Unicode.GetBytes(string_0));
		binaryWriter_0.Write((short)0);
	}
}
