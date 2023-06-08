using ns147;
using ns149;

namespace ns143;

internal class Class4627 : Class4625
{
	private ushort[] ushort_2;

	private uint uint_0;

	private uint uint_1;

	internal Class4627(ushort platformID, ushort platformSpecificID, Class4657 baseTable)
		: base(platformID, platformSpecificID, baseTable)
	{
	}

	internal override void vmethod_0(Class4689 ttfReader)
	{
		ttfReader.method_19();
		ttfReader.method_19();
		uint_0 = ttfReader.method_19();
		uint_1 = ttfReader.method_19();
		ushort_2 = new ushort[uint_1];
		for (int i = 0; i < uint_1; i++)
		{
			ushort_2[i] = ttfReader.method_18();
		}
		base.vmethod_0(ttfReader);
	}

	public override int vmethod_2(char charCode)
	{
		if (charCode >= uint_0 && charCode < uint_0 + uint_1)
		{
			return ushort_2[charCode - uint_0];
		}
		return 0;
	}
}
