using ns178;

namespace ns171;

internal class Class5090 : Class5089
{
	public Class5090(Class5088 parent)
		: base(parent)
	{
	}

	public override string vmethod_23()
	{
		return Class5181.string_2;
	}

	public override string vmethod_22()
	{
		return "svg";
	}

	internal override void vmethod_12(Class5088 child)
	{
		if (xmlDocument_0 == null)
		{
			method_29();
		}
		base.vmethod_12(child);
	}

	internal override void vmethod_9(char[] data, int start, int length, Class5634 pList, Interface243 locatoR)
	{
		if (xmlDocument_0 == null)
		{
			method_29();
		}
		base.vmethod_9(data, start, length, pList, locatoR);
	}
}
