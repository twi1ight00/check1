using Aspose.Cells;
using Aspose.Cells.Drawing;
using ns16;
using ns44;

namespace ns21;

internal class Class1110
{
	internal Class1111 class1111_0;

	internal Class1111 class1111_1;

	internal Class1111 class1111_2;

	internal Class1111 class1111_3;

	internal int method_0(Shape shape_0)
	{
		int num = Class1618.smethod_87(class1111_0.string_0);
		if (num == 0)
		{
			return 0;
		}
		if (num > 1)
		{
			return 25400;
		}
		return 9525;
	}

	internal Class1110(AutoShapeType autoShapeType_0)
	{
		switch (autoShapeType_0)
		{
		default:
			class1111_0 = new Class1111("2");
			class1111_0.internalColor_0.SetColor(ColorType.Theme, 4);
			class1111_0.internalColor_0.method_18().Add(new Class1331(Enum196.const_1, 50000));
			class1111_2 = new Class1111("1");
			class1111_2.internalColor_0.SetColor(ColorType.Theme, 4);
			class1111_3 = new Class1111("0");
			class1111_3.internalColor_0.SetColor(ColorType.Theme, 4);
			class1111_1 = new Class1111("minor");
			class1111_1.internalColor_0.SetColor(ColorType.Theme, 1);
			break;
		case AutoShapeType.Arc:
		case AutoShapeType.Line:
		case AutoShapeType.StraightConnector:
		case AutoShapeType.LeftBracket:
		case AutoShapeType.RightBracket:
		case AutoShapeType.LeftBrace:
		case AutoShapeType.RightBrace:
		case AutoShapeType.DoubleBracket:
		case AutoShapeType.DoubleBrace:
			class1111_0 = new Class1111("1");
			class1111_0.internalColor_0.SetColor(ColorType.Theme, 4);
			class1111_2 = new Class1111("0");
			class1111_2.internalColor_0.SetColor(ColorType.Theme, 4);
			class1111_3 = new Class1111("0");
			class1111_3.internalColor_0.SetColor(ColorType.Theme, 4);
			class1111_1 = new Class1111("minor");
			class1111_1.internalColor_0.SetColor(ColorType.Theme, 1);
			break;
		}
	}

	internal void Copy(Class1110 class1110_0)
	{
		class1111_0.Copy(class1110_0.class1111_0);
		class1111_1.Copy(class1110_0.class1111_1);
		class1111_2.Copy(class1110_0.class1111_2);
		class1111_3.Copy(class1110_0.class1111_3);
	}
}
