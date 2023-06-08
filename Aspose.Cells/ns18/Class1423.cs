using System;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using ns22;

namespace ns18;

internal class Class1423
{
	private uint uint_0;

	private ushort ushort_0;

	private short short_0;

	private short short_1;

	private short short_2;

	private short short_3;

	private ushort ushort_1;

	private uint uint_1;

	private ushort ushort_2;

	internal Class1423()
	{
	}

	internal void Read(BinaryReader binaryReader_0)
	{
		uint_0 = binaryReader_0.ReadUInt32();
		ushort_0 = binaryReader_0.ReadUInt16();
		short_0 = binaryReader_0.ReadInt16();
		short_1 = binaryReader_0.ReadInt16();
		short_2 = binaryReader_0.ReadInt16();
		short_3 = binaryReader_0.ReadInt16();
		ushort_1 = binaryReader_0.ReadUInt16();
		uint_1 = binaryReader_0.ReadUInt32();
		ushort_2 = binaryReader_0.ReadUInt16();
		method_0();
	}

	[Attribute0(true)]
	private void method_0()
	{
		ushort num = 0;
		num = (ushort)(0u ^ (ushort)(uint_0 & 0xFFFFu));
		num = (ushort)(num ^ (ushort)((uint_0 & 0xFFFF0000u) >> 16));
		num = (ushort)(num ^ ushort_0);
		num = (ushort)(num ^ (ushort)short_0);
		num = (ushort)(num ^ (ushort)short_1);
		num = (ushort)(num ^ (ushort)short_2);
		num = (ushort)(num ^ (ushort)short_3);
		num = (ushort)(num ^ ushort_1);
		num = (ushort)(num ^ (ushort)(uint_1 & 0xFFFFu));
		num = (ushort)(num ^ (ushort)((uint_1 & 0xFFFF0000u) >> 16));
		if ((num & 0xFFFF) != ushort_2)
		{
			throw new Exception("Metafile checksum is invalid.");
		}
	}

	[SpecialName]
	internal bool method_1()
	{
		if (short_2 - short_0 > 0)
		{
			return short_3 - short_1 > 0;
		}
		return false;
	}

	[SpecialName]
	internal Rectangle method_2()
	{
		return new Rectangle(0, 0, short_2 - short_0, short_3 - short_1);
	}

	[SpecialName]
	internal int method_3()
	{
		return ushort_1;
	}
}
