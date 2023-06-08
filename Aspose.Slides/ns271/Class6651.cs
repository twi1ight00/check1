using System.Drawing;

namespace ns271;

internal class Class6651 : Class6650
{
	private readonly Class6657 class6657_0;

	public Class6651(Class6654[] fontsData)
	{
		class6657_0 = new Class6657(fontsData);
	}

	public override Class6730 vmethod_0(string familyName, FontStyle style)
	{
		Class6730 @class = class6657_0.method_0(familyName, style);
		if (@class == null)
		{
			@class = Class6652.Instance.vmethod_0(familyName, style);
		}
		return @class;
	}

	internal override Class6730 vmethod_1(FontStyle style)
	{
		Class6730 @class = class6657_0.method_1(style);
		if (@class == null)
		{
			@class = Class6652.Instance.vmethod_1(style);
		}
		return @class;
	}

	internal override Class6730 vmethod_2()
	{
		Class6730 @class = class6657_0.method_2();
		if (@class == null)
		{
			@class = Class6652.Instance.vmethod_2();
		}
		return @class;
	}
}
