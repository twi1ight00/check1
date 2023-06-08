using System.IO;
using ns101;
using ns146;
using ns149;

namespace ns147;

internal class Class4670 : Class4655
{
	public const string string_0 = "OS/2";

	internal const string string_1 = "os/2";

	private ushort ushort_0;

	private short short_0;

	private ushort ushort_1;

	private ushort ushort_2;

	private ushort ushort_3;

	private short short_1;

	private short short_2;

	private short short_3;

	private short short_4;

	private short short_5;

	private short short_6;

	private short short_7;

	private short short_8;

	private short short_9;

	private short short_10;

	private short short_11;

	private byte[] byte_0 = new byte[10];

	private uint[] uint_3 = new uint[4];

	private byte[] byte_1 = new byte[4];

	private ushort ushort_4;

	private ushort ushort_5;

	private ushort ushort_6;

	private short short_12;

	private short short_13;

	private short short_14;

	private ushort ushort_7;

	private ushort ushort_8;

	private uint[] uint_4 = new uint[2];

	private short short_15;

	private short short_16;

	private ushort ushort_9;

	private ushort ushort_10;

	private ushort ushort_11;

	public ushort Version => ushort_0;

	public int[] SupportedTableVersions => new int[1];

	public short XAvgCharWidth => short_0;

	public ushort UsWeightClass => ushort_1;

	public ushort UsWidthClass => ushort_2;

	public ushort FsType
	{
		get
		{
			return ushort_3;
		}
		set
		{
			ushort_3 = value;
		}
	}

	public short YSubscriptXSize => short_1;

	public short YSubscriptYSize => short_2;

	public short YSubscriptXOffset => short_3;

	public short YSubscriptYOffset => short_4;

	public short YSuperscriptXSize => short_5;

	public short YSuperscriptYSize => short_6;

	public short YSuperscriptXOffset => short_7;

	public short YSuperscriptYOffset => short_8;

	public short YStrikeoutSize => short_9;

	public short YStrikeoutPosition => short_10;

	public short SFamilyClass => short_11;

	public byte[] Panose => byte_0;

	public uint[] UlUnicodeRange => uint_3;

	public byte[] AchVendId => byte_1;

	public ushort FsSelection => ushort_4;

	public ushort UsFirstCharIndex => ushort_5;

	public ushort UsLastCharIndex => ushort_6;

	public short STypoAscender
	{
		get
		{
			return short_12;
		}
		set
		{
			short_12 = value;
		}
	}

	public short STypoDescender
	{
		get
		{
			return short_13;
		}
		set
		{
			short_13 = value;
		}
	}

	public short STypoLineGap => short_14;

	public ushort UsWinAscent
	{
		get
		{
			return ushort_7;
		}
		set
		{
			ushort_7 = value;
		}
	}

	public ushort UsWinDescent
	{
		get
		{
			return ushort_8;
		}
		set
		{
			ushort_8 = value;
		}
	}

	public uint[] UlCodePageRange => uint_4;

	public short SxHeight => short_15;

	public short SCapHeight => short_16;

	public ushort UsDefaultChar => ushort_9;

	public ushort UsBreakChar => ushort_10;

	public ushort UsMaxContext => ushort_11;

	internal Class4670(Class4681 ttfTables, Class4411 font)
		: base(ttfTables, font)
	{
		ushort_0 = 3;
		ushort_4 = 64;
		ushort_3 = 8;
		short_16 = 0;
		short_11 = 0;
		short_12 = 1434;
		short_13 = -410;
		short_14 = 205;
		short_15 = 1024;
		ushort_10 = 32;
		ushort_9 = 0;
		ushort_5 = 32;
		ushort_6 = 64258;
		ushort_11 = 0;
		ushort_1 = 400;
		ushort_2 = 5;
		ushort_7 = 1716;
		ushort_8 = 418;
		short_0 = 1072;
		short_10 = 530;
		short_9 = 102;
		short_3 = 0;
		short_1 = 1434;
		short_4 = 283;
		short_2 = 1331;
		short_7 = 0;
		short_5 = 1434;
		short_8 = 977;
		short_6 = 1331;
		uint_4[0] = 0u;
		uint_4[1] = 0u;
		uint_3[0] = 0u;
		uint_3[1] = 0u;
		byte_0[0] = 2;
		byte_0[2] = 5;
	}

	internal Class4670(Class4651 context, uint checkSum, uint offset, uint length)
		: base(context, checkSum, offset, length)
	{
	}

	internal void CopyFrom(Class4670 otherTable)
	{
		short_0 = otherTable.short_0;
		ushort_1 = otherTable.ushort_1;
		ushort_2 = otherTable.ushort_2;
		ushort_3 = otherTable.ushort_3;
		short_1 = otherTable.short_1;
		short_2 = otherTable.short_2;
		short_3 = otherTable.short_3;
		short_4 = otherTable.short_4;
		short_5 = otherTable.short_5;
		short_6 = otherTable.short_6;
		short_7 = otherTable.short_7;
		short_8 = otherTable.short_8;
		short_9 = otherTable.short_9;
		short_10 = otherTable.short_10;
		short_11 = otherTable.short_11;
		byte_0 = otherTable.byte_0;
		uint_3[0] = otherTable.uint_3[0];
		uint_3[1] = otherTable.uint_3[1];
		uint_3[2] = otherTable.uint_3[2];
		uint_3[3] = otherTable.uint_3[3];
		byte_1 = otherTable.byte_1;
		ushort_4 = otherTable.ushort_4;
		ushort_5 = otherTable.ushort_5;
		ushort_6 = otherTable.ushort_6;
		short_12 = otherTable.short_12;
		short_13 = otherTable.short_13;
		short_14 = otherTable.short_14;
		ushort_7 = otherTable.ushort_7;
		ushort_8 = otherTable.ushort_8;
		uint_4[0] = otherTable.uint_4[0];
		uint_4[1] = otherTable.uint_4[1];
		uint_4[0] = otherTable.uint_4[0];
		uint_4[1] = otherTable.uint_4[1];
		short_15 = otherTable.short_15;
		short_16 = otherTable.short_16;
		ushort_9 = otherTable.ushort_9;
		ushort_10 = otherTable.ushort_10;
		ushort_11 = otherTable.ushort_11;
	}

	internal override void vmethod_2(Class4689 ttfReader)
	{
		ttfReader.Seek(base.Offset);
		ushort_0 = ttfReader.method_18();
		if (ushort_0 >= 0)
		{
			short_0 = ttfReader.method_14();
			ushort_1 = ttfReader.method_18();
			ushort_2 = ttfReader.method_18();
			ushort_3 = ttfReader.method_18();
			short_1 = ttfReader.method_14();
			short_2 = ttfReader.method_14();
			short_3 = ttfReader.method_14();
			short_4 = ttfReader.method_14();
			short_5 = ttfReader.method_14();
			short_6 = ttfReader.method_14();
			short_7 = ttfReader.method_14();
			short_8 = ttfReader.method_14();
			short_9 = ttfReader.method_14();
			short_10 = ttfReader.method_14();
			short_11 = ttfReader.method_14();
			ttfReader.method_2(10, byte_0, 0);
			uint_3[0] = ttfReader.method_19();
			uint_3[1] = ttfReader.method_19();
			uint_3[2] = ttfReader.method_19();
			uint_3[3] = ttfReader.method_19();
			ttfReader.method_2(4, byte_1, 0);
			ushort_4 = ttfReader.method_18();
			ushort_5 = ttfReader.method_18();
			ushort_6 = ttfReader.method_18();
			short_12 = ttfReader.method_14();
			short_13 = ttfReader.method_14();
			short_14 = ttfReader.method_14();
			ushort_7 = ttfReader.method_18();
			ushort_8 = ttfReader.method_18();
		}
		if (ushort_0 >= 1)
		{
			uint_4[0] = ttfReader.method_19();
			uint_4[1] = ttfReader.method_19();
		}
		else
		{
			uint_4[0] = 0u;
			uint_4[1] = 0u;
		}
		if (ushort_0 >= 2)
		{
			short_15 = ttfReader.method_14();
			short_16 = ttfReader.method_14();
			ushort_9 = ttfReader.method_18();
			ushort_10 = ttfReader.method_18();
			ushort_11 = ttfReader.method_18();
		}
		base.vmethod_2(ttfReader);
	}

	internal override void Save(out byte[] tableBytes, out uint length, out uint checksum)
	{
		if (base.IsNewFont)
		{
			if (ushort_0 >= 0)
			{
				MemoryStream stream = new MemoryStream();
				using Class4685 @class = new Class4685(stream, closeStreamOnDispose: true);
				@class.method_6(ushort_0);
				@class.method_5(short_0);
				@class.method_6(ushort_1);
				@class.method_6(ushort_2);
				@class.method_6(ushort_3);
				@class.method_5(short_1);
				@class.method_5(short_2);
				@class.method_5(short_3);
				@class.method_5(short_4);
				@class.method_5(short_5);
				@class.method_5(short_6);
				@class.method_5(short_7);
				@class.method_5(short_8);
				@class.method_5(short_9);
				@class.method_5(short_10);
				@class.method_5(short_11);
				@class.method_1(byte_0);
				@class.method_9(uint_3[0]);
				@class.method_9(uint_3[1]);
				@class.method_9(uint_3[2]);
				@class.method_9(uint_3[3]);
				@class.method_1(byte_1);
				@class.method_6(ushort_4);
				@class.method_6(ushort_5);
				@class.method_6(ushort_6);
				@class.method_5(short_12);
				@class.method_5(short_13);
				@class.method_5(short_14);
				@class.method_6(ushort_7);
				@class.method_6(ushort_8);
				if (ushort_0 >= 1)
				{
					@class.method_9(uint_4[0]);
					@class.method_9(uint_4[1]);
				}
				if (ushort_0 >= 2)
				{
					@class.method_5(short_15);
					@class.method_5(short_16);
					@class.method_6(ushort_9);
					@class.method_6(ushort_10);
					@class.method_6(ushort_11);
				}
				method_1(@class, stream, out tableBytes, out length, out checksum);
				return;
			}
			base.Save(out tableBytes, out length, out checksum);
		}
		else
		{
			base.Save(out tableBytes, out length, out checksum);
		}
	}
}
