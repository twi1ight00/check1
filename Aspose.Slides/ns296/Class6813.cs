using ns284;

namespace ns296;

internal class Class6813 : Class6806
{
	public Class6813(Class6983 element)
		: base(element)
	{
	}

	public override string vmethod_0()
	{
		return smethod_0(base.Element).ToString();
	}

	private static int smethod_0(Class6983 element)
	{
		return element.StyleDeclarationInternal.Font.Weight.Value;
	}
}
