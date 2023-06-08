using ns147;
using ns149;

namespace ns143;

internal class Class4631 : Class4625
{
	private ushort ushort_2;

	private ushort ushort_3;

	private ushort[] ushort_4;

	internal Class4631(Class4657 baseTable)
		: base(3, 1, baseTable)
	{
	}

	internal Class4631(ushort platformID, ushort platformSpecificID, Class4657 baseTable)
		: base(platformID, platformSpecificID, baseTable)
	{
	}

	internal override void vmethod_0(Class4689 ttfReader)
	{
		ttfReader.method_18();
		ttfReader.method_18();
		ushort_2 = ttfReader.method_18();
		ushort_3 = ttfReader.method_18();
		ushort_4 = new ushort[ushort_3];
		for (int i = 0; i < ushort_3; i++)
		{
			ushort_4[i] = ttfReader.method_18();
		}
		base.vmethod_0(ttfReader);
	}

	public override int vmethod_2(char charCode)
	{
		if (charCode >= ushort_2 && charCode < ushort_2 + ushort_3)
		{
			return ushort_4[charCode - ushort_2];
		}
		return 0;
	}
}
