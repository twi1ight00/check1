using ns16;
using ns4;
using ns56;

namespace ns18;

internal class Class996
{
	public static void smethod_0(Class139 backgroundStyle, Class1932 tblBg, Class1341 deserializationContext)
	{
		if (tblBg != null)
		{
			Class1005.smethod_0(backgroundStyle.FillFormat, tblBg.ThemeableFillStyle, deserializationContext);
			Class1004.smethod_0(backgroundStyle.EffectFormat, tblBg.ThemeableEffectStyle, deserializationContext);
		}
	}

	public static void smethod_1(Class139 backgroundStyle, Class1932.Delegate1663 addTblBg, Class1346 serializationContext)
	{
		if (backgroundStyle.FillFormat.Source != 0 || backgroundStyle.EffectFormat.Source != 0)
		{
			Class1932 @class = addTblBg();
			Class1005.smethod_1(backgroundStyle.FillFormat, @class.delegate2773_1, serializationContext);
			Class1004.smethod_1(backgroundStyle.EffectFormat, @class.delegate2773_0, serializationContext);
		}
	}
}
