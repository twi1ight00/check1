using System;
using System.IO;
using ns101;
using ns146;
using ns149;

namespace ns147;

internal class Class4662 : Class4655
{
	[Flags]
	public enum Enum655 : ushort
	{

	}

	[Flags]
	public enum Enum656 : ushort
	{

	}

	public const string string_0 = "head";

	internal const string string_1 = "head";

	private float float_0;

	private Enum655 enum655_0;

	private float float_1;

	private uint uint_3;

	private uint uint_4;

	private uint uint_5;

	private DateTime dateTime_0;

	private DateTime dateTime_1;

	private short short_0;

	private short short_1;

	private short short_2;

	private short short_3;

	private Enum656 enum656_0;

	private ushort ushort_0;

	private short short_4;

	private short short_5;

	private short short_6;

	internal long long_0;

	public float Version => float_0;

	public Enum655 Flags
	{
		get
		{
			return enum655_0;
		}
		set
		{
			enum655_0 = value;
		}
	}

	public float FontRevision => float_1;

	public uint CheckSumAdjustment => uint_3;

	public uint MagicNumber => uint_4;

	public uint UnitsPerEm
	{
		get
		{
			return uint_5;
		}
		set
		{
			uint_5 = value;
		}
	}

	public DateTime Created => dateTime_0;

	public DateTime Modified => dateTime_1;

	public short XMin
	{
		get
		{
			return short_0;
		}
		set
		{
			short_0 = value;
		}
	}

	public short YMin
	{
		get
		{
			return short_1;
		}
		set
		{
			short_1 = value;
		}
	}

	public short XMax
	{
		get
		{
			return short_2;
		}
		set
		{
			short_2 = value;
		}
	}

	public short YMax
	{
		get
		{
			return short_3;
		}
		set
		{
			short_3 = value;
		}
	}

	public Enum656 MacStyle
	{
		get
		{
			return enum656_0;
		}
		set
		{
			enum656_0 = value;
		}
	}

	public ushort LowestRecPPEM => ushort_0;

	public short FontDirectionHint
	{
		get
		{
			return short_4;
		}
		set
		{
			short_4 = value;
		}
	}

	public short IndexToLocFormat
	{
		get
		{
			return short_5;
		}
		set
		{
			short_5 = value;
		}
	}

	public short GlyphDataFormat => short_6;

	internal Class4662(Class4681 ttfTables, Class4411 font)
		: base(ttfTables, font)
	{
		float_0 = 1f;
		enum655_0 = (Enum655)0;
		float_1 = 0f;
		uint_3 = 0u;
		uint_4 = 1594834165u;
		uint_5 = 2048u;
		dateTime_0 = DateTime.Now;
		dateTime_1 = DateTime.Now;
		short_0 = 0;
		short_1 = 0;
		short_2 = (short)uint_5;
		short_3 = (short)uint_5;
		enum656_0 = (Enum656)0;
		ushort_0 = 6;
		short_4 = 0;
		short_5 = 1;
		short_6 = 0;
	}

	internal Class4662(Class4651 context, uint checkSum, uint offset, uint length)
		: base(context, checkSum, offset, length)
	{
	}

	internal override void vmethod_2(Class4689 ttfReader)
	{
		ttfReader.Seek(base.Offset);
		float_0 = ttfReader.method_8();
		float_1 = ttfReader.method_8();
		uint_3 = ttfReader.method_19();
		uint_4 = ttfReader.method_19();
		enum655_0 = (Enum655)ttfReader.method_18();
		uint_5 = ttfReader.method_18();
		dateTime_0 = ttfReader.method_7(useDefaultOnFail: true);
		dateTime_1 = ttfReader.method_7(useDefaultOnFail: true);
		short_0 = ttfReader.method_10();
		short_1 = ttfReader.method_10();
		short_2 = ttfReader.method_10();
		short_3 = ttfReader.method_10();
		enum656_0 = (Enum656)ttfReader.method_18();
		ushort_0 = ttfReader.method_18();
		short_4 = ttfReader.method_14();
		short_5 = ttfReader.method_14();
		short_6 = ttfReader.method_14();
		base.vmethod_2(ttfReader);
	}

	internal override void Save(out byte[] tableBytes, out uint length, out uint checksum)
	{
		long_0 = 8L;
		if (base.IsNewFont && float_0 == 1f)
		{
			using (MemoryStream stream = new MemoryStream())
			{
				using Class4685 @class = new Class4685(stream, closeStreamOnDispose: true);
				@class.method_11(float_0);
				@class.method_11(float_1);
				@class.method_9(uint_3);
				@class.method_9(uint_4);
				@class.method_6((ushort)enum655_0);
				@class.method_6((ushort)uint_5);
				@class.method_14(dateTime_0);
				@class.method_14(dateTime_1);
				@class.method_15(short_0);
				@class.method_15(short_1);
				@class.method_15(short_2);
				@class.method_15(short_3);
				@class.method_6((ushort)enum656_0);
				@class.method_6(ushort_0);
				@class.method_5(short_4);
				@class.method_5(short_5);
				@class.method_5(short_6);
				method_1(@class, stream, out tableBytes, out length, out checksum);
				return;
			}
		}
		base.Save(out tableBytes, out length, out checksum);
	}
}
