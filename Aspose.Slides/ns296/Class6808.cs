using ns284;
using ns84;

namespace ns296;

internal class Class6808 : Class6806
{
	public Class6808(Class6983 element)
		: base(element)
	{
	}

	public override string vmethod_0()
	{
		if (base.Element.StyleDeclarationInternal.Font.Size.IsAbsoluteSize && base.Element.StyleDeclarationInternal.Font.Size.AbsoluteSize == Enum610.const_7)
		{
			return "36";
		}
		return base.Element.StyleDeclarationInternal.Font.Size.ToString();
	}
}
