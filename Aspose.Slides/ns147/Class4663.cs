using System.IO;
using ns101;
using ns146;
using ns149;
using ns99;

namespace ns147;

internal class Class4663 : Class4655
{
	public const string string_0 = "hhea";

	internal const string string_1 = "hhea";

	private float float_0;

	private ushort ushort_0;

	private ushort ushort_1;

	private short short_0;

	private short short_1;

	private short short_2;

	private short short_3;

	private short short_4;

	private short short_5;

	private short short_6;

	private short short_7;

	private short short_8;

	private short short_9;

	public ushort NumOfLongHorMetrics
	{
		get
		{
			return ushort_0;
		}
		set
		{
			ushort_0 = value;
		}
	}

	public ushort AdvanceWidthMax => ushort_1;

	public short MinRightSideBearing
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

	public short MinLeftSideBearing
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

	public short XMaxExtent
	{
		get
		{
			return short_6;
		}
		set
		{
			short_6 = value;
		}
	}

	public short Ascent
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

	public short Descent
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

	public short LineGap => short_3;

	internal Class4663(Class4681 ttfTables, Class4411 font)
		: base(ttfTables, font)
	{
		float_0 = 1f;
	}

	internal Class4663(Class4651 context, uint checkSum, uint offset, uint length)
		: base(context, checkSum, offset, length)
	{
	}

	internal override void vmethod_2(Class4689 ttfReader)
	{
		ttfReader.Seek(base.Offset);
		float_0 = ttfReader.method_8();
		short_1 = ttfReader.method_10();
		short_2 = ttfReader.method_10();
		short_3 = ttfReader.method_10();
		ushort_1 = ttfReader.method_9();
		short_0 = ttfReader.method_10();
		short_5 = ttfReader.method_10();
		short_6 = ttfReader.method_10();
		short_7 = ttfReader.method_14();
		short_8 = ttfReader.method_14();
		short_9 = ttfReader.method_14();
		ttfReader.method_14();
		ttfReader.method_14();
		ttfReader.method_14();
		ttfReader.method_14();
		short_4 = ttfReader.method_14();
		ushort_0 = ttfReader.method_18();
		base.vmethod_2(ttfReader);
	}

	internal override void Save(out byte[] tableBytes, out uint length, out uint checksum)
	{
		if (base.IsNewFont)
		{
			using (MemoryStream stream = new MemoryStream())
			{
				using Class4685 @class = new Class4685(stream, closeStreamOnDispose: true);
				method_2();
				@class.method_11(float_0);
				@class.method_15(short_1);
				@class.method_15(short_2);
				@class.method_15(short_3);
				@class.method_16(ushort_1);
				@class.method_15(short_0);
				@class.method_15(short_5);
				@class.method_15(short_6);
				@class.method_5(short_7);
				@class.method_5(short_8);
				@class.method_5(short_9);
				@class.method_5(0);
				@class.method_5(0);
				@class.method_5(0);
				@class.method_5(0);
				@class.method_5(short_4);
				@class.method_6(ushort_0);
				method_1(@class, stream, out tableBytes, out length, out checksum);
				return;
			}
		}
		base.Save(out tableBytes, out length, out checksum);
	}

	private void method_2()
	{
		ushort_1 = 0;
		short_6 = 0;
		short_0 = short.MaxValue;
		short_5 = short.MaxValue;
		try
		{
			if (base.TTFTables.HmtxTable == null)
			{
				return;
			}
			if (base.TTFTables.HmtxTable.Hmetrics.Count == 1)
			{
				ushort_1 = base.TTFTables.HmtxTable.Hmetrics[0].ushort_0;
				if (base.TTFTables.HmtxTable.LeftSidebearings.Length > 0)
				{
					if (base.TTFTables.HmtxTable.LeftSidebearings[0] < short_0)
					{
						short_0 = base.TTFTables.HmtxTable.LeftSidebearings[0];
					}
					short_5 = (short)(ushort_1 - short_0);
				}
				return;
			}
			for (int i = 0; i < base.TTFTables.MaxpTable.NumGlyphs; i++)
			{
				Class4480 @class = base.Context.Font.method_3(i);
				if (i <= base.TTFTables.HmtxTable.Hmetrics.Count - 1)
				{
					ushort num = base.TTFTables.HmtxTable.Hmetrics[i].ushort_0;
					short num2 = base.TTFTables.HmtxTable.Hmetrics[i].short_0;
					if (base.TTFTables.HmtxTable.Hmetrics[i].ushort_0 > ushort_1)
					{
						ushort_1 = num;
					}
					if (num2 < short_0)
					{
						short_0 = num2;
					}
					double num3 = (double)(num - num2) - (@class.GlyphBBox.double_2 - @class.GlyphBBox.double_0);
					if (num3 < (double)short_5)
					{
						short_5 = (short)num3;
					}
					double num4 = (double)num2 + (@class.GlyphBBox.double_2 - @class.GlyphBBox.double_0);
					if (num4 > (double)short_6)
					{
						short_6 = (short)num4;
					}
				}
				else
				{
					int num5 = i - base.TTFTables.HmtxTable.Hmetrics.Count;
					if (num5 >= 0 && num5 < base.TTFTables.HmtxTable.LeftSidebearings.Length && base.TTFTables.HmtxTable.LeftSidebearings[num5] < short_0)
					{
						short_0 = base.TTFTables.HmtxTable.LeftSidebearings[num5];
					}
				}
			}
		}
		finally
		{
			if (short_0 == short.MaxValue)
			{
				short_0 = 0;
			}
			if (short_5 == short.MaxValue)
			{
				short_5 = 0;
			}
		}
	}
}
