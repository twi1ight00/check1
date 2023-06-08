using Aspose.Slides;
using Aspose.Slides.Warnings;
using ns62;

namespace ns15;

internal class Class1056
{
	internal static void smethod_0(ILineFormat targetformat, Class2670 frame, Class854 slideDeserializationContext, LineJoinStyle defaultJoin, bool flipLineStyle)
	{
		Class2834 shapePrimaryOptions = frame.ShapePrimaryOptions;
		Class2670 @class = null;
		Class2911 class2 = ((shapePrimaryOptions != null) ? (shapePrimaryOptions.Properties[Enum426.const_0] as Class2911) : null);
		if (class2 != null && slideDeserializationContext.DeserializationContext.ShapeIdToFrame.ContainsKey(class2.Value))
		{
			@class = slideDeserializationContext.DeserializationContext.ShapeIdToFrame[class2.Value] as Class2670;
		}
		Class2834 masterOptions = @class?.ShapePrimaryOptions;
		Class2923 class3 = ((shapePrimaryOptions != null) ? ((Class2923)shapePrimaryOptions.Properties[Enum426.const_154]) : null);
		if (class3 == null)
		{
			class3 = new Class2923();
		}
		Class879.smethod_0(targetformat.FillFormat, frame, slideDeserializationContext);
		Class2911 class4 = smethod_1(shapePrimaryOptions, masterOptions, Enum426.const_134) as Class2911;
		targetformat.DashStyle = ((class4 != null) ? Class232.smethod_14((Enum393)class4.Value) : LineDashStyle.NotDefined);
		class4 = smethod_1(shapePrimaryOptions, masterOptions, Enum426.const_131) as Class2911;
		targetformat.Width = ((class4 != null) ? ((double)class4.Value / 12700.0) : 0.75);
		class4 = smethod_1(shapePrimaryOptions, masterOptions, Enum426.const_143) as Class2911;
		targetformat.CapStyle = ((class4 != null) ? ((LineCapStyle)class4.Value) : LineCapStyle.NotDefined);
		class4 = smethod_1(shapePrimaryOptions, masterOptions, Enum426.const_133) as Class2911;
		targetformat.Style = ((class4 != null) ? ((LineStyle)class4.Value) : LineStyle.NotDefined);
		if (flipLineStyle)
		{
			switch (targetformat.Style)
			{
			case LineStyle.ThickThin:
				targetformat.Style = LineStyle.ThinThick;
				break;
			case LineStyle.ThinThick:
				targetformat.Style = LineStyle.ThickThin;
				break;
			}
		}
		targetformat.Alignment = ((class3.Folded_fInsetPen && class3.Folded_fInsetPenOK) ? LineAlignment.Inset : LineAlignment.NotDefined);
		class4 = smethod_1(shapePrimaryOptions, masterOptions, Enum426.const_132) as Class2911;
		targetformat.MiterLimit = ((class4 != null) ? ((float)class4.Value / 65536f) : 8f);
		class4 = smethod_1(shapePrimaryOptions, masterOptions, Enum426.const_142) as Class2911;
		targetformat.JoinStyle = ((class4 != null) ? Class232.smethod_16((Enum392)class4.Value) : defaultJoin);
		class4 = smethod_1(shapePrimaryOptions, masterOptions, Enum426.const_136) as Class2911;
		targetformat.BeginArrowheadStyle = ((class4 == null) ? LineArrowheadStyle.NotDefined : ((LineArrowheadStyle)class4.Value));
		class4 = smethod_1(shapePrimaryOptions, masterOptions, Enum426.const_137) as Class2911;
		targetformat.EndArrowheadStyle = ((class4 == null) ? LineArrowheadStyle.NotDefined : ((LineArrowheadStyle)class4.Value));
		class4 = smethod_1(shapePrimaryOptions, masterOptions, Enum426.const_138) as Class2911;
		targetformat.BeginArrowheadWidth = ((class4 == null) ? LineArrowheadWidth.NotDefined : ((LineArrowheadWidth)class4.Value));
		class4 = smethod_1(shapePrimaryOptions, masterOptions, Enum426.const_139) as Class2911;
		targetformat.BeginArrowheadLength = ((class4 == null) ? LineArrowheadLength.NotDefined : ((LineArrowheadLength)class4.Value));
		class4 = smethod_1(shapePrimaryOptions, masterOptions, Enum426.const_140) as Class2911;
		targetformat.EndArrowheadWidth = ((class4 == null) ? LineArrowheadWidth.NotDefined : ((LineArrowheadWidth)class4.Value));
		class4 = smethod_1(shapePrimaryOptions, masterOptions, Enum426.const_141) as Class2911;
		targetformat.EndArrowheadLength = ((class4 == null) ? LineArrowheadLength.NotDefined : ((LineArrowheadLength)class4.Value));
	}

	private static object smethod_1(Class2834 options, Class2834 masterOptions, Enum426 key)
	{
		object obj = options?.Properties[key];
		if (obj == null && masterOptions != null)
		{
			return masterOptions.Properties[key];
		}
		return obj;
	}

	public static void smethod_2(ILineFormat lineFormat, Class2670 odrawShape, LineJoinStyle defaultJoin, Class856 serializationContext)
	{
		Class2944 properties = odrawShape.ShapePrimaryOptions.Properties;
		Class2923 @class = (Class2923)properties[Enum426.const_154];
		if (@class == null)
		{
			@class = new Class2923();
			properties.method_0(@class);
		}
		Class879.smethod_1(lineFormat.FillFormat, odrawShape, serializationContext);
		properties.Remove(Enum426.const_134);
		if (lineFormat.DashStyle != LineDashStyle.NotDefined)
		{
			if (lineFormat.DashStyle != LineDashStyle.Custom)
			{
				Class2911 property = new Class2911(Enum426.const_134, (uint)Class232.smethod_15(lineFormat.DashStyle));
				properties.Add(property);
			}
			else
			{
				serializationContext.method_15("Line format dash style LineDashStyle.Custom PPT serialization is not implemented yet.", WarningType.MinorFormattingLoss);
			}
		}
		properties.Remove(Enum426.const_131);
		if (!double.IsNaN(lineFormat.Width) && lineFormat.Width - 0.75 > 1E-06)
		{
			Class2911 property2 = new Class2911(Enum426.const_131, (uint)(lineFormat.Width * 12700.0));
			properties.Add(property2);
		}
		properties.Remove(Enum426.const_143);
		if (lineFormat.CapStyle != LineCapStyle.NotDefined && lineFormat.CapStyle != LineCapStyle.Square)
		{
			Class2911 property3 = new Class2911(Enum426.const_143, (uint)lineFormat.CapStyle);
			properties.Add(property3);
		}
		properties.Remove(Enum426.const_133);
		if (lineFormat.Style != LineStyle.NotDefined && lineFormat.Style != 0)
		{
			Class2911 property4 = new Class2911(Enum426.const_133, (uint)lineFormat.Style);
			properties.Add(property4);
		}
		@class.Folded_fInsetPen = lineFormat.Alignment == LineAlignment.Inset;
		properties.Remove(Enum426.const_142);
		if (lineFormat.JoinStyle != LineJoinStyle.NotDefined && lineFormat.JoinStyle != defaultJoin)
		{
			Class2911 property5 = new Class2911(Enum426.const_142, (uint)Class232.smethod_17(lineFormat.JoinStyle));
			properties.Add(property5);
		}
		properties.Remove(Enum426.const_132);
		if (!float.IsNaN(lineFormat.MiterLimit) && lineFormat.MiterLimit != 8f)
		{
			Class2911 property6 = new Class2911(Enum426.const_132, (uint)(lineFormat.MiterLimit * 65536f));
			properties.Add(property6);
		}
		@class.Folded_fArrowheadsOK = odrawShape.ShapeProp.ShapeType == Enum425.const_20 || odrawShape.ShapeProp.ShapeType == Enum425.const_0;
		properties.Remove(Enum426.const_136);
		if (lineFormat.BeginArrowheadStyle != LineArrowheadStyle.NotDefined)
		{
			Class2911 property7 = new Class2911(Enum426.const_136, (uint)lineFormat.BeginArrowheadStyle);
			properties.Add(property7);
		}
		properties.Remove(Enum426.const_138);
		if (lineFormat.BeginArrowheadWidth != LineArrowheadWidth.NotDefined)
		{
			Class2911 property8 = new Class2911(Enum426.const_138, (uint)lineFormat.BeginArrowheadWidth);
			properties.Add(property8);
		}
		properties.Remove(Enum426.const_139);
		if (lineFormat.BeginArrowheadLength != LineArrowheadLength.NotDefined)
		{
			Class2911 property9 = new Class2911(Enum426.const_139, (uint)lineFormat.BeginArrowheadLength);
			properties.Add(property9);
		}
		properties.Remove(Enum426.const_137);
		if (lineFormat.EndArrowheadStyle != LineArrowheadStyle.NotDefined)
		{
			Class2911 property10 = new Class2911(Enum426.const_137, (uint)lineFormat.EndArrowheadStyle);
			properties.Add(property10);
		}
		properties.Remove(Enum426.const_140);
		if (lineFormat.EndArrowheadWidth != LineArrowheadWidth.NotDefined)
		{
			Class2911 property11 = new Class2911(Enum426.const_140, (uint)lineFormat.EndArrowheadWidth);
			properties.Add(property11);
		}
		properties.Remove(Enum426.const_141);
		if (lineFormat.EndArrowheadLength != LineArrowheadLength.NotDefined)
		{
			Class2911 property12 = new Class2911(Enum426.const_141, (uint)lineFormat.EndArrowheadLength);
			properties.Add(property12);
		}
	}
}
