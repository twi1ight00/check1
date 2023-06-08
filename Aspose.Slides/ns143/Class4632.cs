using ns147;
using ns149;

namespace ns143;

internal class Class4632 : Class4625
{
	private class Class4634
	{
		public uint uint_0;

		public uint uint_1;

		public uint uint_2;
	}

	private byte[] byte_0;

	private Class4634[] class4634_0;

	internal Class4632(Class4657 baseTable)
		: base(3, 1, baseTable)
	{
	}

	internal Class4632(ushort platformID, ushort platformSpecificID, Class4657 baseTable)
		: base(platformID, platformSpecificID, baseTable)
	{
	}

	internal override void vmethod_0(Class4689 ttfReader)
	{
		ttfReader.method_19();
		ttfReader.method_19();
		byte_0 = new byte[8192];
		for (int i = 0; i < byte_0.Length; i++)
		{
			byte_0[i] = ttfReader.method_17();
		}
		uint num = ttfReader.method_19();
		class4634_0 = new Class4634[num];
		for (int j = 0; j < num; j++)
		{
			class4634_0[j] = new Class4634();
			class4634_0[j].uint_0 = ttfReader.method_19();
			class4634_0[j].uint_1 = ttfReader.method_19();
			class4634_0[j].uint_2 = ttfReader.method_19();
		}
		base.vmethod_0(ttfReader);
	}

	public override int vmethod_2(char charCode)
	{
		for (int i = 0; i < class4634_0.Length; i++)
		{
			if (charCode < class4634_0[i].uint_0 || charCode > class4634_0[i].uint_1)
			{
				if (charCode < class4634_0[i].uint_1 && charCode < class4634_0[i].uint_0)
				{
					break;
				}
				continue;
			}
			return (int)(class4634_0[i].uint_2 + charCode - class4634_0[i].uint_0);
		}
		return 0;
	}
}
