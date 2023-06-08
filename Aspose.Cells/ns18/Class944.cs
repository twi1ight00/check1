using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;

namespace ns18;

internal class Class944 : Class943
{
	private readonly Class1201 class1201_0;

	private readonly Matrix matrix_1;

	internal Class944(Class1440 class1440_1, TextureBrush textureBrush_0)
		: base(class1440_1)
	{
		class1201_0 = new Class1203((Bitmap)textureBrush_0.Image);
		matrix_1 = textureBrush_0.Transform;
	}

	internal Class944(Class1440 class1440_1, HatchBrush hatchBrush_0)
		: base(class1440_1)
	{
		class1201_0 = new Class1204(hatchBrush_0);
	}

	internal override void vmethod_3(Class1447 class1447_0)
	{
		base.vmethod_3(class1447_0);
		class1447_0.method_16("/PaintType", 1);
		class1447_0.method_16("/TilingType", 2);
		class1447_0.method_14("/BBox", new RectangleF(0f, 0f, class1201_0.Width, class1201_0.Height));
		class1447_0.method_16("/XStep", class1201_0.Width);
		class1447_0.method_16("/YStep", class1201_0.Height);
		class1447_0.Write("/Resources");
		class1447_0.method_9();
		class1451_0.method_7(class1447_0);
		class1447_0.method_10();
		method_18(class1447_0);
	}

	public override void vmethod_1(Class1447 class1447_0)
	{
		Enum208 enum208_ = class1440_0.method_1().method_1();
		class1440_0.method_1().method_2(Enum208.const_0);
		class1445_0.method_4(class1201_0, PointF.Empty, new SizeF(class1201_0.Width, class1201_0.Height));
		base.vmethod_1(class1447_0);
		class1451_0.method_8(class1447_0);
		class1440_0.method_1().method_2(enum208_);
	}

	[SpecialName]
	protected override int vmethod_5()
	{
		return 1;
	}

	[SpecialName]
	protected override Matrix vmethod_6()
	{
		return matrix_1;
	}
}
