using System;
using Aspose.Slides;
using Aspose.Slides.Warnings;
using ns62;

namespace ns15;

internal class Class879
{
	internal static void smethod_0(ILineFillFormat lineFillFormat, Class2670 odrawShape, Class854 slideDeserializationContext)
	{
		Class2944 @class = ((odrawShape.ShapePrimaryOptions != null) ? odrawShape.ShapePrimaryOptions.Properties : null);
		if (@class == null)
		{
			@class = new Class2944();
		}
		Class2923 class2 = ((Class2923)@class[Enum426.const_154]) ?? new Class2923();
		Class2670 class3 = null;
		if (@class[Enum426.const_0] is Class2911 class4 && slideDeserializationContext.DeserializationContext.ShapeIdToFrame.ContainsKey(class4.Value))
		{
			class3 = slideDeserializationContext.DeserializationContext.ShapeIdToFrame[class4.Value] as Class2670;
		}
		_ = class2.Value;
		if (class3 != null && class3.ShapePrimaryOptions.Properties[Enum426.const_154] is Class2911 class5)
		{
			_ = class2.Value >> 16;
			_ = class5.Value;
			_ = class2.Value;
		}
		if (class2.GfUsefLine)
		{
			lineFillFormat.FillType = (class2.QfLine ? FillType.Solid : FillType.NoFill);
		}
		if (@class[Enum426.const_120] != null)
		{
			Class1049.smethod_3((ColorFormat)lineFillFormat.SolidFillColor, odrawShape, class3, Enum426.const_120, Enum426.const_121, 0u);
		}
	}

	internal static void smethod_1(ILineFillFormat lineFillFormat, Class2670 odrawShape, Class856 serializationContext)
	{
		Class2944 properties = odrawShape.ShapePrimaryOptions.Properties;
		Class2923 @class = properties[Enum426.const_154] as Class2923;
		properties.Remove(Enum426.const_296);
		properties.Remove(Enum426.const_120);
		properties.Remove(Enum426.const_121);
		switch (lineFillFormat.FillType)
		{
		default:
			throw new NotImplementedException();
		case FillType.NotDefined:
			@class.Folded_fLine = false;
			break;
		case FillType.NoFill:
		{
			@class.Folded_fLine = false;
			Class2911 property = new Class2911(Enum426.const_296, isBid: false, 134217730u);
			properties.Add(property);
			break;
		}
		case FillType.Solid:
			@class.Folded_fLine = true;
			Class1049.smethod_8(lineFillFormat.SolidFillColor, properties, Enum426.const_120, Enum426.const_121, serializationContext);
			break;
		case FillType.Gradient:
			serializationContext.method_15("Line fill type FillType.Gradient PPT serialization is not implemented yet.", WarningType.MinorFormattingLoss);
			break;
		case FillType.Pattern:
			serializationContext.method_15("Line fill type FillType.Pattern PPT serialization is not implemented yet.", WarningType.MinorFormattingLoss);
			break;
		}
	}
}
