using System;
using System.IO;
using System.Text;

namespace ns57;

internal class Class1313
{
	internal string string_0;

	internal Enum191 enum191_0;

	internal Enum190 enum190_0;

	internal uint uint_0;

	internal uint uint_1;

	internal uint uint_2;

	internal Guid guid_0;

	internal uint uint_3;

	internal long long_0;

	internal long long_1;

	internal uint uint_4;

	internal long long_2;

	internal bool bool_0;

	internal Class1313()
	{
		enum191_0 = Enum191.const_0;
		enum190_0 = Enum190.const_1;
		uint_0 = uint.MaxValue;
		uint_1 = uint.MaxValue;
		uint_2 = uint.MaxValue;
		guid_0 = Guid.Empty;
	}

	internal Class1313(string string_1, bool bool_1, Guid guid_1)
		: this()
	{
		string_0 = string_1;
		enum191_0 = ((!bool_1) ? Enum191.const_1 : Enum191.const_5);
		guid_0 = guid_1;
		uint_4 = (bool_1 ? uint.MaxValue : 0u);
	}

	internal Class1313(string string_1, Enum191 enum191_1, long long_3)
		: this()
	{
		string_0 = string_1;
		enum191_0 = enum191_1;
		long_2 = long_3;
		uint_4 = uint.MaxValue;
	}

	internal Class1313(BinaryReader binaryReader_0)
	{
		int num = (int)binaryReader_0.BaseStream.Position;
		byte[] array = binaryReader_0.ReadBytes(64);
		if (array.Length < 64)
		{
			return;
		}
		int num2 = binaryReader_0.ReadUInt16();
		if (num2 > 0)
		{
			if (num2 > array.Length)
			{
				throw new InvalidOperationException("The structured storage seems to be corrupt.");
			}
			string_0 = Encoding.Unicode.GetString(array, 0, num2 - 2);
		}
		else
		{
			string_0 = null;
		}
		enum191_0 = (Enum191)binaryReader_0.ReadByte();
		if (enum191_0 == Enum191.const_0)
		{
			binaryReader_0.BaseStream.Position = num + 128;
			return;
		}
		enum190_0 = (Enum190)binaryReader_0.ReadByte();
		uint_0 = binaryReader_0.ReadUInt32();
		uint_1 = binaryReader_0.ReadUInt32();
		uint_2 = binaryReader_0.ReadUInt32();
		guid_0 = new Guid(binaryReader_0.ReadBytes(16));
		uint_3 = binaryReader_0.ReadUInt32();
		long_0 = binaryReader_0.ReadInt64();
		long_1 = binaryReader_0.ReadInt64();
		uint_4 = binaryReader_0.ReadUInt32();
		long_2 = binaryReader_0.ReadUInt32();
		binaryReader_0.ReadInt32();
	}

	internal void Write(BinaryWriter binaryWriter_0)
	{
		byte[] array = new byte[64];
		int num;
		if (Class1321.smethod_6(string_0))
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
		binaryWriter_0.Write(array);
		binaryWriter_0.Write((ushort)num);
		binaryWriter_0.Write((byte)enum191_0);
		binaryWriter_0.Write((byte)enum190_0);
		binaryWriter_0.Write(uint_0);
		binaryWriter_0.Write(uint_1);
		binaryWriter_0.Write(uint_2);
		binaryWriter_0.Write(guid_0.ToByteArray());
		binaryWriter_0.Write(uint_3);
		binaryWriter_0.Write(long_0);
		binaryWriter_0.Write(long_1);
		binaryWriter_0.Write(uint_4);
		binaryWriter_0.Write((uint)long_2);
		binaryWriter_0.Write(0);
	}
}
