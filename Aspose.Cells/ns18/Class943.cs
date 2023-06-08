using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;

namespace ns18;

internal abstract class Class943 : Class939
{
	protected Class1451 class1451_0;

	protected Class1445 class1445_0;

	private Matrix matrix_0;

	internal Class943(Class1440 class1440_1)
		: base(class1440_1, bool_1: false)
	{
		class1451_0 = new Class1451(class1440_1);
		class1445_0 = new Class1445(class1440_0, class1451_0, this);
		matrix_0 = class1440_0.method_6().method_17().method_0()
			.Clone();
	}

	internal override void vmethod_3(Class1447 class1447_0)
	{
		class1447_0.method_11("/Type", "/Pattern");
		class1447_0.method_16("/PatternType", vmethod_5());
	}

	internal static Class943 smethod_0(Brush brush_0, Class1440 class1440_1)
	{
		if (brush_0 is TextureBrush textureBrush_)
		{
			return new Class944(class1440_1, textureBrush_);
		}
		if (brush_0 is HatchBrush hatchBrush_)
		{
			return new Class944(class1440_1, hatchBrush_);
		}
		return null;
	}

	protected void method_18(Class1447 class1447_0)
	{
		Matrix matrix;
		if (vmethod_6() == null)
		{
			float num = (float)Class1395.smethod_2(1.0);
			matrix = new Matrix(num, 0f, 0f, num, 0f, 0f);
		}
		else
		{
			matrix = vmethod_6().Clone();
			matrix.Multiply(matrix_0, MatrixOrder.Append);
		}
		class1447_0.Write("/Matrix[{0}]", Class1446.smethod_8(matrix.Elements));
	}

	[SpecialName]
	protected abstract int vmethod_5();

	[SpecialName]
	protected abstract Matrix vmethod_6();

	[SpecialName]
	internal override Enum209 vmethod_0()
	{
		return Enum209.const_2;
	}
}
