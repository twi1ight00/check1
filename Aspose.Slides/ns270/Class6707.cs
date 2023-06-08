using System;
using System.IO;
using System.Text;
using ns218;

namespace ns270;

internal class Class6707
{
	internal const int int_0 = 128;

	internal const uint uint_0 = uint.MaxValue;

	private const int int_1 = 64;

	private const int int_2 = 16;

	private const int int_3 = 20;

	internal string string_0;

	internal Enum893 enum893_0;

	internal Enum894 enum894_0;

	internal uint uint_1;

	internal uint uint_2;

	internal uint uint_3;

	internal Guid guid_0;

	internal uint uint_4;

	internal long long_0;

	internal long long_1;

	internal uint uint_5;

	internal long long_2;

	internal bool bool_0;

	internal Class6707()
	{
		enum893_0 = Enum893.const_0;
		enum894_0 = Enum894.const_1;
		uint_1 = uint.MaxValue;
		uint_2 = uint.MaxValue;
		uint_3 = uint.MaxValue;
		guid_0 = Guid.Empty;
	}

	internal Class6707(string name, bool isRoot, Guid clsid)
		: this()
	{
		string_0 = name;
		enum893_0 = ((!isRoot) ? Enum893.const_1 : Enum893.const_5);
		guid_0 = clsid;
		uint_5 = (isRoot ? uint.MaxValue : 0u);
	}

	internal Class6707(string name, Enum893 entryType, long size)
		: this()
	{
		string_0 = name;
		enum893_0 = entryType;
		long_2 = size;
		uint_5 = uint.MaxValue;
	}

	internal Class6707(BinaryReader reader)
	{
		int num = (int)reader.BaseStream.Position;
		byte[] array = reader.ReadBytes(64);
		if (array.Length < 64)
		{
			return;
		}
		int num2 = reader.ReadUInt16();
		if (num2 > 0)
		{
			if (num2 > array.Length)
			{
				return;
			}
			string_0 = Encoding.Unicode.GetString(array, 0, num2 - 2);
		}
		else
		{
			string_0 = null;
		}
		enum893_0 = (Enum893)reader.ReadByte();
		if (enum893_0 == Enum893.const_0)
		{
			reader.BaseStream.Position = num + 128;
			return;
		}
		enum894_0 = (Enum894)reader.ReadByte();
		uint_1 = reader.ReadUInt32();
		uint_2 = reader.ReadUInt32();
		uint_3 = reader.ReadUInt32();
		guid_0 = new Guid(reader.ReadBytes(16));
		uint_4 = reader.ReadUInt32();
		long_0 = reader.ReadInt64();
		if (Class5964.smethod_47(reader, 20))
		{
			long_1 = reader.ReadInt64();
			uint_5 = reader.ReadUInt32();
			long_2 = reader.ReadUInt32();
			reader.ReadInt32();
		}
	}

	internal void Write(BinaryWriter writer)
	{
		byte[] array = new byte[64];
		int num;
		if (Class5964.smethod_20(string_0))
		{
			byte[] bytes = Encoding.Unicode.GetBytes(string_0);
			if (bytes.Length > 62)
			{
				throw new InvalidOperationException($"The name '{string_0}' is too long for writing to structured storage.");
			}
			Array.Copy(bytes, 0, array, 0, bytes.Length);
			num = bytes.Length + 2;
		}
		else
		{
			num = 0;
		}
		writer.Write(array);
		writer.Write((ushort)num);
		writer.Write((byte)enum893_0);
		writer.Write((byte)enum894_0);
		writer.Write(uint_1);
		writer.Write(uint_2);
		writer.Write(uint_3);
		writer.Write(guid_0.ToByteArray());
		writer.Write(uint_4);
		writer.Write(long_0);
		writer.Write(long_1);
		writer.Write(uint_5);
		writer.Write((uint)long_2);
		writer.Write(0);
	}
}
