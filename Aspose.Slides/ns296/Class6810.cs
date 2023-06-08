using ns277;
using ns284;
using ns286;

namespace ns296;

internal class Class6810 : Class6806
{
	public Class6810(Class6983 element, Interface355 settings, Class6772 builder)
		: base(element, settings, builder)
	{
	}

	public override string vmethod_0()
	{
		if (base.Element.StyleDeclarationInternal.Background.Image.None)
		{
			return "none";
		}
		return base.Builder.method_10(base.Element.StyleDeclarationInternal.Background.Image.Uri);
	}
}
