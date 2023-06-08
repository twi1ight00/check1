using System.IO;
using ns101;
using ns146;
using ns149;

namespace ns147;

internal class Class4668 : Class4655
{
	public const string string_0 = "maxp";

	internal const string string_1 = "maxp";

	private float float_0;

	private ushort ushort_0;

	private ushort ushort_1;

	private ushort ushort_2;

	private ushort ushort_3;

	private ushort ushort_4;

	private ushort ushort_5;

	private ushort ushort_6;

	private ushort ushort_7;

	private ushort ushort_8;

	private ushort ushort_9;

	private ushort ushort_10;

	private ushort ushort_11;

	private ushort ushort_12;

	private ushort ushort_13;

	public float Version => float_0;

	public ushort NumGlyphs
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

	public ushort MaxPoints => ushort_1;

	public ushort MaxContours => ushort_2;

	public ushort MaxComponentPoints => ushort_3;

	public ushort MaxComponentContours => ushort_4;

	public ushort MaxZones => ushort_5;

	public ushort MaxTwilightPoints
	{
		get
		{
			return ushort_6;
		}
		set
		{
			ushort_6 = value;
		}
	}

	public ushort MaxStorage
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

	public ushort MaxFunctionDefs
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

	public ushort MaxInstructionDefs
	{
		get
		{
			return ushort_9;
		}
		set
		{
			ushort_9 = value;
		}
	}

	public ushort MaxStackElements
	{
		get
		{
			return ushort_10;
		}
		set
		{
			ushort_10 = value;
		}
	}

	public ushort MaxSizeOfInstructions
	{
		get
		{
			return ushort_11;
		}
		set
		{
			ushort_11 = value;
		}
	}

	public ushort MaxComponentElements
	{
		get
		{
			return ushort_12;
		}
		set
		{
			ushort_12 = value;
		}
	}

	public ushort MaxComponentDepth => ushort_13;

	internal Class4668(Class4681 ttfTables, Class4411 font)
		: base(ttfTables, font)
	{
		float_0 = 1f;
		ushort_5 = 2;
		ushort_2 = 1024;
		ushort_1 = 4096;
		ushort_8 = 255;
		ushort_9 = 255;
		ushort_11 = 8192;
		ushort_6 = 16;
		ushort_10 = 4096;
		ushort_7 = 255;
		ushort_3 = 255;
		ushort_4 = 255;
		ushort_12 = 255;
		ushort_13 = 30;
	}

	internal Class4668(Class4651 context, uint checkSum, uint offset, uint length)
		: base(context, checkSum, offset, length)
	{
	}

	internal override void vmethod_2(Class4689 ttfReader)
	{
		ttfReader.Seek(base.Offset);
		float_0 = ttfReader.method_8();
		ushort_0 = ttfReader.method_18();
		ushort_1 = ttfReader.method_18();
		ushort_2 = ttfReader.method_18();
		ushort_3 = ttfReader.method_18();
		ushort_4 = ttfReader.method_18();
		ushort_5 = ttfReader.method_18();
		ushort_6 = ttfReader.method_18();
		ushort_7 = ttfReader.method_18();
		ushort_8 = ttfReader.method_18();
		ushort_9 = ttfReader.method_18();
		ushort_10 = ttfReader.method_18();
		ushort_11 = ttfReader.method_18();
		ushort_12 = ttfReader.method_18();
		ushort_13 = ttfReader.method_18();
		base.vmethod_2(ttfReader);
	}

	internal override void Save(out byte[] tableBytes, out uint length, out uint checksum)
	{
		if (base.IsNewFont)
		{
			using (MemoryStream stream = new MemoryStream())
			{
				using Class4685 @class = new Class4685(stream, closeStreamOnDispose: true);
				@class.method_11(float_0);
				@class.method_6(ushort_0);
				@class.method_6(ushort_1);
				@class.method_6(ushort_2);
				@class.method_6(ushort_3);
				@class.method_6(ushort_4);
				@class.method_6(ushort_5);
				@class.method_6(ushort_6);
				@class.method_6(ushort_7);
				@class.method_6(ushort_8);
				@class.method_6(ushort_9);
				@class.method_6(ushort_10);
				@class.method_6(ushort_11);
				@class.method_6(ushort_12);
				@class.method_6(ushort_13);
				method_1(@class, stream, out tableBytes, out length, out checksum);
				return;
			}
		}
		base.Save(out tableBytes, out length, out checksum);
	}
}
