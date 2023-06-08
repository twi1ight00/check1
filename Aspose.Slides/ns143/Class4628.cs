using ns147;
using ns149;

namespace ns143;

internal class Class4628 : Class4625
{
	private class Class4633
	{
		public uint uint_0;

		public uint uint_1;

		public uint uint_2;
	}

	private Class4633[] class4633_0;

	internal Class4628(ushort platformID, ushort platformSpecificID, Class4657 baseTable)
		: base(platformID, platformSpecificID, baseTable)
	{
	}

	internal override void vmethod_0(Class4689 ttfReader)
	{
		ttfReader.method_19();
		ttfReader.method_19();
		uint num = ttfReader.method_19();
		class4633_0 = new Class4633[num];
		for (int i = 0; i < num; i++)
		{
			class4633_0[i] = new Class4633();
			class4633_0[i].uint_0 = ttfReader.method_19();
			class4633_0[i].uint_1 = ttfReader.method_19();
			class4633_0[i].uint_2 = ttfReader.method_19();
		}
		base.vmethod_0(ttfReader);
	}

	public override int vmethod_2(char charCode)
	{
		for (int i = 0; i < class4633_0.Length; i++)
		{
			if (charCode < class4633_0[i].uint_0 || charCode > class4633_0[i].uint_1)
			{
				if (charCode < class4633_0[i].uint_1 && charCode < class4633_0[i].uint_0)
				{
					break;
				}
				continue;
			}
			return (int)(class4633_0[i].uint_2 + charCode - class4633_0[i].uint_0);
		}
		return 0;
	}
}
