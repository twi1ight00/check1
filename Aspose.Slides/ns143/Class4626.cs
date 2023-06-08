using ns147;
using ns149;

namespace ns143;

internal class Class4626 : Class4625
{
	private byte[] byte_0;

	internal Class4626(ushort platformID, ushort platformSpecificID, Class4657 baseTable)
		: base(platformID, platformSpecificID, baseTable)
	{
	}

	internal override void vmethod_0(Class4689 ttfReader)
	{
		ttfReader.method_18();
		ttfReader.method_18();
		byte_0 = new byte[256];
		for (int i = 0; i < byte_0.Length; i++)
		{
			byte_0[i] = ttfReader.method_17();
		}
		base.vmethod_0(ttfReader);
	}

	public override int vmethod_2(char charCode)
	{
		if (charCode >= '\0' && charCode <= 'ÿ')
		{
			return byte_0[(uint)charCode];
		}
		return 0;
	}
}
