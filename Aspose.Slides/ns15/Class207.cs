using Aspose.Slides;
using ns4;
using ns62;

namespace ns15;

internal static class Class207
{
	internal static void smethod_0(IPortionFormat portionFormat, Class2670 shapeContainer, Class854 slideDeserializationContext)
	{
		Class1056.smethod_0(portionFormat.LineFormat, shapeContainer, slideDeserializationContext, LineJoinStyle.NotDefined, flipLineStyle: false);
		Class1052.smethod_0((FillFormat)portionFormat.FillFormat, shapeContainer, slideDeserializationContext);
		Class875.smethod_0(portionFormat.EffectFormat, shapeContainer, slideDeserializationContext);
		Class2944 properties = shapeContainer.ShapePrimaryOptions.Properties;
		if (properties[Enum426.const_422] is Class2926 @class)
		{
			portionFormat.FontHeight = @class.TextSize.Value;
		}
		if (properties[Enum426.const_423] is Class2927 class2)
		{
			portionFormat.Spacing = 0f - class2.TextSpacing.Value;
		}
		Class2914 class3 = properties[Enum426.const_426] as Class2914;
		if (class3 != null)
		{
			if (class3.DfUsegtextFKern && class3.TgtextFKern)
			{
				portionFormat.KerningMinimalSize = 0.1f;
			}
			if (class3.KfUsegtextFBold && class3.agtextFBold)
			{
				portionFormat.FontBold = NullableBool.True;
			}
			if (class3.LfUsegtextFItalic && class3.bgtextFItalic)
			{
				portionFormat.FontItalic = NullableBool.True;
			}
			if (class3.MfUsegtextFUnderline && class3.cgtextFUnderline)
			{
				portionFormat.FontUnderline = TextUnderlineType.Single;
			}
		}
		if (properties[Enum426.const_424] is Class2932 class4)
		{
			Class53.smethod_0(portionFormat);
			IFontData fontData = new FontData();
			((FontData)fontData).FontName = Class1036.smethod_8(class4.Value);
			portionFormat.LatinFont = fontData;
		}
	}
}
