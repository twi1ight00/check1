using System.Drawing;
using System.Runtime.CompilerServices;
using ns22;

namespace ns18;

internal abstract class Class1425
{
	protected bool bool_0;

	private readonly Class1416 class1416_0;

	internal Class1425(Class1416 class1416_1)
	{
		class1416_0 = class1416_1;
	}

	[Attribute0(true)]
	internal virtual void Initialize(PointF pointF_0, SizeF sizeF_0)
	{
	}

	[Attribute0(true)]
	internal abstract void vmethod_0(PointF pointF_0, string string_0);

	[Attribute0(true)]
	internal abstract void vmethod_1(PointF pointF_0, string string_0);

	[Attribute0(true)]
	internal abstract void vmethod_2(PointF pointF_0, Color color_0);

	[Attribute0(true)]
	internal abstract void vmethod_3(PointF pointF_0);

	[Attribute0(true)]
	internal abstract void vmethod_4(RectangleF rectangleF_0);

	[Attribute0(true)]
	internal abstract void vmethod_5(RectangleF rectangleF_0);

	[Attribute0(true)]
	internal abstract void vmethod_6(PointF[] pointF_0);

	[Attribute0(true)]
	internal abstract void vmethod_7(PointF[] pointF_0);

	[Attribute0(true)]
	internal abstract void vmethod_8(PointF[][] pointF_0);

	[Attribute0(true)]
	internal abstract void vmethod_9(PointF[] pointF_0);

	[Attribute0(true)]
	internal abstract void vmethod_10(PointF[][] pointF_0);

	[Attribute0(true)]
	internal abstract void vmethod_11(RectangleF rectangleF_0, PointF pointF_0, PointF pointF_1);

	[Attribute0(true)]
	internal abstract void vmethod_12(RectangleF rectangleF_0);

	[Attribute0(true)]
	internal abstract void vmethod_13(RectangleF rectangleF_0, PointF pointF_0, PointF pointF_1);

	[Attribute0(true)]
	internal abstract void vmethod_14(RectangleF rectangleF_0, PointF pointF_0, PointF pointF_1);

	[Attribute0(true)]
	internal abstract void vmethod_15(RectangleF rectangleF_0, SizeF sizeF_0);

	[Attribute0(true)]
	internal abstract void vmethod_16(RectangleF rectangleF_0, RectangleF rectangleF_1, byte[] byte_0);

	[Attribute0(true)]
	internal abstract void vmethod_17(RectangleF rectangleF_0);

	[SpecialName]
	internal Class1407 method_0()
	{
		return class1416_0.method_5();
	}

	[SpecialName]
	protected Class1414 method_1()
	{
		return class1416_0.method_4();
	}

	[SpecialName]
	protected PointF method_2()
	{
		return class1416_0.method_8();
	}

	[SpecialName]
	protected void method_3(PointF pointF_0)
	{
		class1416_0.method_9(pointF_0);
	}

	[SpecialName]
	internal bool method_4()
	{
		return bool_0;
	}
}
