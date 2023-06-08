using ns101;
using ns146;
using ns149;
using ns99;

namespace ns147;

internal class Class4665 : Class4655
{
	public const string string_0 = "kern";

	internal const string string_1 = "kern";

	private Class4467 class4467_0;

	public Class4467 Metrics
	{
		get
		{
			method_0();
			return class4467_0;
		}
	}

	internal Class4665(Class4651 context, uint checkSum, uint offset, uint length)
		: base(context, checkSum, offset, length)
	{
	}

	internal override void vmethod_2(Class4689 ttfReader)
	{
		base.vmethod_2(ttfReader);
	}

	internal override void vmethod_0(Class4689 ttfReader)
	{
		base.vmethod_0(ttfReader);
		class4467_0 = new Class4467(base.Context.TTFTables);
		ttfReader.Seek(base.Offset);
		ttfReader.method_18();
		ushort num = ttfReader.method_18();
		for (int i = 0; i < num; i++)
		{
			ttfReader.method_18();
			ttfReader.method_18();
			ushort num2 = ttfReader.method_18();
			if ((num2 & 0xFF00) >> 8 == 0)
			{
				ushort num3 = ttfReader.method_18();
				ttfReader.method_18();
				ttfReader.method_18();
				ttfReader.method_18();
				for (int j = 0; j < num3; j++)
				{
					ushort value = ttfReader.method_18();
					ushort value2 = ttfReader.method_18();
					short num4 = ttfReader.method_10();
					class4467_0.vmethod_3(new Class4508(value), new Class4508(value2), num4);
				}
			}
		}
	}
}
