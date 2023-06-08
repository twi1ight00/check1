using ns119;
using ns146;
using ns149;

namespace ns147;

internal class Class4656 : Class4655
{
	public const string string_0 = "cff";

	internal const string string_1 = "cff";

	private Class4487 class4487_0;

	public Class4487 CFFSource
	{
		get
		{
			method_0();
			return class4487_0;
		}
	}

	internal Class4656(Class4651 context, uint checkSum, uint offset, uint length)
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
		ttfReader.Seek(base.Offset);
		class4487_0 = (Class4487)base.Context.vmethod_0().Clone();
		class4487_0.Offset = base.Offset;
	}
}
