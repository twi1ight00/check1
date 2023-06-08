using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Runtime.CompilerServices;
using Aspose.Cells.Rendering;
using ns18;
using ns22;

namespace ns19;

internal abstract class Class1031 : Interface42
{
	protected readonly int int_0 = 1;

	protected Class1035 class1035_0;

	protected Stack stack_0;

	protected Stack stack_1;

	protected Class454 class454_0;

	protected Class454 class454_1;

	protected SmoothingMode smoothingMode_0;

	protected GraphicsUnit graphicsUnit_0;

	protected float float_0;

	protected int int_1;

	protected CompositingQuality compositingQuality_0;

	protected TextRenderingHint textRenderingHint_0;

	protected int int_2;

	protected int int_3;

	protected ImageFormat imageFormat_0;

	protected ImageOrPrintOptions imageOrPrintOptions_0;

	protected Stream stream_0;

	protected Interface6 interface6_0;

	protected float float_1 = 96f;

	protected float float_2 = 96f;

	protected Interface43 interface43_0;

	protected Interface44 interface44_0 = new Class1038();

	public int Width => int_2;

	public int Height => int_3;

	public Class1031(int int_4, int int_5, ImageFormat imageFormat_1, ImageOrPrintOptions imageOrPrintOptions_1, Stream stream_1, Interface6 interface6_1)
	{
		imageOrPrintOptions_0 = imageOrPrintOptions_1;
		if (imageOrPrintOptions_1 != null)
		{
			float_1 = imageOrPrintOptions_0.HorizontalResolution;
			float_2 = imageOrPrintOptions_0.VerticalResolution;
		}
		int_2 = int_4;
		int_3 = int_5;
		imageFormat_0 = imageFormat_1;
		stream_0 = stream_1;
		interface6_0 = interface6_1;
		textRenderingHint_0 = TextRenderingHint.SystemDefault;
		imethod_55(SmoothingMode.None);
		graphicsUnit_0 = GraphicsUnit.Pixel;
		float_0 = 1f;
		int_1 = 4;
		compositingQuality_0 = CompositingQuality.Default;
		stack_0 = new Stack();
		class1035_0 = new Class1035();
		method_0();
		if (interface6_0 != null)
		{
			interface6_0.imethod_1(this);
		}
	}

	private void method_0()
	{
		stack_1 = new Stack();
		class454_0 = new Class454();
		Matrix matrix = new Matrix();
		matrix.Scale((float)(1.0 / (double)int_0), (float)(1.0 / (double)int_0));
		class454_0.vmethod_1(matrix);
		class454_1 = new Class454();
		class454_0.Add(class454_1);
	}

	[SpecialName]
	public Interface43 imethod_0()
	{
		return interface43_0;
	}

	[SpecialName]
	public void imethod_1(Interface43 interface43_1)
	{
		interface43_0 = interface43_1;
	}

	[Attribute0(true)]
	public abstract void imethod_2();

	[Attribute0(true)]
	public abstract Bitmap imethod_3();

	public void vmethod_0()
	{
		interface43_0.Dispose();
	}

	public void Dispose()
	{
		vmethod_0();
	}

	public void imethod_4(Pen pen_0, RectangleF rectangleF_0, float float_3, float float_4)
	{
		imethod_5(pen_0, rectangleF_0.X, rectangleF_0.Y, rectangleF_0.Width, rectangleF_0.Height, float_3, float_4);
	}

	public void imethod_5(Pen pen_0, float float_3, float float_4, float float_5, float float_6, float float_7, float float_8)
	{
		if (method_10(pen_0))
		{
			Class1033 @class = method_11(pen_0);
			interface44_0.imethod_0(this, @class.method_0(), @class.method_2(), @class.method_4(), float_3, float_4, float_5, float_6, float_7, float_8);
		}
		else
		{
			method_1(pen_0, null, float_3, float_4, float_5, float_6, float_7, float_8);
		}
	}

	public void imethod_6(Pen pen_0, PointF[] pointF_0)
	{
		imethod_7(pen_0, pointF_0, 0.5f);
	}

	public void imethod_7(Pen pen_0, PointF[] pointF_0, float float_3)
	{
		imethod_8(pen_0, pointF_0, 0, pointF_0.Length - 1, float_3);
	}

	public void imethod_8(Pen pen_0, PointF[] pointF_0, int int_4, int int_5, float float_3)
	{
		if (method_10(pen_0))
		{
			Class1033 @class = method_11(pen_0);
			interface44_0.imethod_1(this, @class.method_0(), @class.method_2(), @class.method_4(), pointF_0, int_4, int_5, float_3);
		}
		else
		{
			method_8(pen_0, pointF_0, int_4, int_5, float_3, bool_0: false);
		}
	}

	public void imethod_9(Pen pen_0, RectangleF rectangleF_0)
	{
		method_4(pen_0, null, rectangleF_0.X, rectangleF_0.Y, rectangleF_0.Width, rectangleF_0.Height);
	}

	public void imethod_10(Pen pen_0, float float_3, float float_4, float float_5, float float_6)
	{
		method_4(pen_0, null, float_3, float_4, float_5, float_6);
	}

	public void imethod_13(Image image_0, Rectangle rectangle_0, float float_3, float float_4, float float_5, float float_6, GraphicsUnit graphicsUnit_1)
	{
		vmethod_1(image_0, rectangle_0, (int)float_3, (int)float_4, (int)float_5, (int)float_6, graphicsUnit_1);
	}

	public abstract void vmethod_1(Image image_0, Rectangle rectangle_0, int int_4, int int_5, int int_6, int int_7, GraphicsUnit graphicsUnit_1);

	public void imethod_14(Image image_0, RectangleF rectangleF_0, RectangleF rectangleF_1, GraphicsUnit graphicsUnit_1)
	{
		imethod_13(image_0, new Rectangle((int)rectangleF_0.X, (int)rectangleF_0.Y, (int)rectangleF_0.Width, (int)rectangleF_0.Height), rectangleF_1.X, rectangleF_1.Y, rectangleF_1.Width, rectangleF_1.Height, graphicsUnit_1);
	}

	public void imethod_11(Image image_0, int int_4, int int_5, int int_6, int int_7)
	{
		vmethod_11(int_4, int_5, int_6, int_7, image_0);
	}

	public void imethod_12(Image image_0, float float_3, float float_4, float float_5, float float_6)
	{
		vmethod_11(float_3, float_4, float_5, float_6, image_0);
	}

	public void imethod_15(Pen pen_0, PointF pointF_0, PointF pointF_1)
	{
		imethod_16(pen_0, pointF_0.X, pointF_0.Y, pointF_1.X, pointF_1.Y);
	}

	public void imethod_16(Pen pen_0, float float_3, float float_4, float float_5, float float_6)
	{
		if (method_10(pen_0))
		{
			Class1033 @class = method_11(pen_0);
			interface44_0.imethod_2(this, @class.method_0(), @class.method_2(), @class.method_4(), float_3, float_4, float_5, float_6);
		}
		else
		{
			method_3(pen_0, float_3, float_4, float_5, float_6);
		}
	}

	public void imethod_17(Pen pen_0, PointF[] pointF_0)
	{
		throw new NotSupportedException();
	}

	public void imethod_18(Pen pen_0, GraphicsPath graphicsPath_0)
	{
		if (method_10(pen_0))
		{
			Class1033 @class = method_11(pen_0);
			interface44_0.imethod_3(this, @class.method_0(), @class.method_2(), @class.method_4(), graphicsPath_0);
		}
		else
		{
			method_5(pen_0, null, graphicsPath_0);
		}
	}

	public void imethod_19(Pen pen_0, float float_3, float float_4, float float_5, float float_6, float float_7, float float_8)
	{
		method_2(pen_0, null, float_3, float_4, float_5, float_6, float_7, float_8);
	}

	public void imethod_20(Pen pen_0, PointF[] pointF_0)
	{
		if (pointF_0 != null && pointF_0.Length != 0)
		{
			float[] array = new float[pointF_0.Length * 2];
			for (int i = 0; i < pointF_0.Length; i++)
			{
				array[i * 2] = pointF_0[i].X;
				array[i * 2 + 1] = pointF_0[i].Y;
			}
			method_6(pen_0, null, array, FillMode.Alternate);
		}
	}

	public void imethod_21(Pen pen_0, Rectangle rectangle_0)
	{
		method_7(pen_0, null, rectangle_0.X, rectangle_0.Y, rectangle_0.Width, rectangle_0.Height);
	}

	public void imethod_22(Pen pen_0, int int_4, int int_5, int int_6, int int_7)
	{
		method_7(pen_0, null, int_4, int_5, int_6, int_7);
	}

	public void imethod_23(Pen pen_0, float float_3, float float_4, float float_5, float float_6)
	{
		method_7(pen_0, null, float_3, float_4, float_5, float_6);
	}

	public void imethod_24(string string_0, Font font_0, Brush brush_0, PointF pointF_0)
	{
		vmethod_2(string_0, font_0, brush_0, pointF_0.X, pointF_0.Y, float.PositiveInfinity, float.PositiveInfinity, null);
	}

	public void imethod_25(string string_0, Font font_0, Brush brush_0, RectangleF rectangleF_0)
	{
		vmethod_2(string_0, font_0, brush_0, rectangleF_0.X, rectangleF_0.Y, rectangleF_0.Width, rectangleF_0.Height, null);
	}

	public void imethod_26(string string_0, Font font_0, Brush brush_0, PointF pointF_0, StringFormat stringFormat_0)
	{
		vmethod_2(string_0, font_0, brush_0, pointF_0.X, pointF_0.Y, float.PositiveInfinity, float.PositiveInfinity, stringFormat_0);
	}

	public void imethod_27(string string_0, Font font_0, Brush brush_0, RectangleF rectangleF_0, StringFormat stringFormat_0)
	{
		vmethod_2(string_0, font_0, brush_0, rectangleF_0.X, rectangleF_0.Y, rectangleF_0.Width, rectangleF_0.Height, stringFormat_0);
	}

	public void imethod_29(string string_0, Font font_0, Brush brush_0, float float_3, float float_4)
	{
		vmethod_2(string_0, font_0, brush_0, float_3, float_4, float.PositiveInfinity, float.PositiveInfinity, null);
	}

	public void imethod_30(string string_0, Font font_0, Brush brush_0, float float_3, float float_4, StringFormat stringFormat_0)
	{
		vmethod_2(string_0, font_0, brush_0, float_3, float_4, float.PositiveInfinity, float.PositiveInfinity, stringFormat_0);
	}

	public void imethod_28(string string_0, Font font_0, Brush brush_0, Rectangle rectangle_0, StringFormat stringFormat_0)
	{
		RectangleF rectangleF_ = new RectangleF(rectangle_0.X, rectangle_0.Y, rectangle_0.Width, rectangle_0.Height);
		imethod_27(string_0, font_0, brush_0, rectangleF_, stringFormat_0);
	}

	protected abstract void vmethod_2(string string_0, Font font_0, Brush brush_0, float float_3, float float_4, float float_5, float float_6, StringFormat stringFormat_0);

	public void imethod_31(Brush brush_0, RectangleF rectangleF_0)
	{
		method_4(null, brush_0, rectangleF_0.X, rectangleF_0.Y, rectangleF_0.Width, rectangleF_0.Height);
	}

	public void imethod_32(Brush brush_0, float float_3, float float_4, float float_5, float float_6)
	{
		method_4(null, brush_0, float_3, float_4, float_5, float_6);
	}

	public void imethod_33(Brush brush_0, GraphicsPath graphicsPath_0)
	{
		method_5(null, brush_0, graphicsPath_0);
	}

	public void imethod_34(Brush brush_0, float float_3, float float_4, float float_5, float float_6, float float_7, float float_8)
	{
		method_2(null, brush_0, float_3, float_4, float_5, float_6, float_7, float_8);
	}

	public void imethod_35(Brush brush_0, PointF[] pointF_0)
	{
		vmethod_3(brush_0, pointF_0, FillMode.Alternate);
	}

	public void vmethod_3(Brush brush_0, PointF[] pointF_0, FillMode fillMode_0)
	{
		if (pointF_0 != null && pointF_0.Length != 0)
		{
			float[] array = new float[pointF_0.Length * 2];
			for (int i = 0; i < pointF_0.Length; i++)
			{
				array[i * 2] = pointF_0[i].X;
				array[i * 2 + 1] = pointF_0[i].Y;
			}
			method_6(null, brush_0, array, fillMode_0);
		}
	}

	public void imethod_36(Brush brush_0, Rectangle rectangle_0)
	{
		method_7(null, brush_0, rectangle_0.X, rectangle_0.Y, rectangle_0.Width, rectangle_0.Height);
	}

	public void imethod_37(Brush brush_0, RectangleF rectangleF_0)
	{
		method_7(null, brush_0, rectangleF_0.X, rectangleF_0.Y, rectangleF_0.Width, rectangleF_0.Height);
	}

	public void imethod_38(Brush brush_0, float float_3, float float_4, float float_5, float float_6)
	{
		method_7(null, brush_0, float_3, float_4, float_5, float_6);
	}

	public SizeF imethod_39(string string_0, Font font_0)
	{
		return interface43_0.imethod_3(string_0, font_0);
	}

	public SizeF imethod_40(string string_0, Font font_0, SizeF sizeF_0)
	{
		return interface43_0.imethod_4(string_0, font_0, sizeF_0);
	}

	public SizeF imethod_41(string string_0, Font font_0, PointF pointF_0, StringFormat stringFormat_0)
	{
		return interface43_0.imethod_5(string_0, font_0, pointF_0, stringFormat_0);
	}

	public SizeF imethod_42(string string_0, Font font_0, SizeF sizeF_0, StringFormat stringFormat_0)
	{
		return interface43_0.imethod_6(string_0, font_0, sizeF_0, stringFormat_0);
	}

	public SizeF imethod_43(string string_0, Font font_0, int int_4, StringFormat stringFormat_0)
	{
		return interface43_0.imethod_7(string_0, font_0, int_4, stringFormat_0);
	}

	public void ResetClip()
	{
		throw new NotSupportedException();
	}

	public void ResetTransform()
	{
		class1035_0.method_0().Reset();
	}

	public void imethod_44(GraphicsState graphicsState_0)
	{
		if (stack_0.Count == 0)
		{
			throw new InvalidOperationException();
		}
		Class1035 @class = (Class1035)stack_0.Pop();
		class1035_0.Reset(@class);
	}

	public void imethod_45(float float_3)
	{
		vmethod_4(float_3, MatrixOrder.Prepend);
	}

	public void vmethod_4(float float_3, MatrixOrder matrixOrder_0)
	{
		class1035_0.method_0().Rotate(float_3, matrixOrder_0);
	}

	public GraphicsState Save()
	{
		stack_0.Push(class1035_0.Clone());
		return null;
	}

	public void imethod_46(float float_3, float float_4)
	{
		class1035_0.method_0().Scale(float_3, float_4);
	}

	public void imethod_47(Rectangle rectangle_0)
	{
		vmethod_5(new Region(rectangle_0), CombineMode.Replace);
	}

	public void imethod_48(RectangleF rectangleF_0)
	{
		vmethod_5(new Region(rectangleF_0), CombineMode.Replace);
	}

	public void vmethod_5(Region region_0, CombineMode combineMode_0)
	{
		vmethod_10(region_0, combineMode_0);
	}

	public void imethod_49(float float_3, float float_4)
	{
		vmethod_6(float_3, float_4, MatrixOrder.Prepend);
	}

	public void vmethod_6(float float_3, float float_4, MatrixOrder matrixOrder_0)
	{
		class1035_0.method_0().Translate(vmethod_12(float_3, imethod_51()), vmethod_12(float_4, imethod_52()), matrixOrder_0);
	}

	[SpecialName]
	public RectangleF imethod_50()
	{
		return interface43_0.imethod_0(class1035_0.method_2());
	}

	[SpecialName]
	public float imethod_51()
	{
		return float_1;
	}

	[SpecialName]
	public float imethod_52()
	{
		return float_2;
	}

	[SpecialName]
	public GraphicsUnit imethod_53()
	{
		return graphicsUnit_0;
	}

	[SpecialName]
	public float vmethod_7()
	{
		return float_0;
	}

	[SpecialName]
	public SmoothingMode imethod_54()
	{
		return smoothingMode_0;
	}

	[SpecialName]
	public void imethod_55(SmoothingMode smoothingMode_1)
	{
		smoothingMode_0 = smoothingMode_1;
	}

	[SpecialName]
	public TextRenderingHint imethod_56()
	{
		return textRenderingHint_0;
	}

	[SpecialName]
	public void imethod_57(TextRenderingHint textRenderingHint_1)
	{
		textRenderingHint_0 = textRenderingHint_1;
	}

	[SpecialName]
	public Matrix vmethod_8()
	{
		return class1035_0.method_0().Clone();
	}

	[SpecialName]
	public void imethod_58(Matrix matrix_0)
	{
		class1035_0.method_1(matrix_0);
	}

	[SpecialName]
	public CompositingQuality imethod_59()
	{
		return compositingQuality_0;
	}

	[SpecialName]
	public void imethod_60(CompositingQuality compositingQuality_1)
	{
		compositingQuality_0 = compositingQuality_1;
	}

	[SpecialName]
	public int imethod_61()
	{
		return int_1;
	}

	[SpecialName]
	public void imethod_62(int int_4)
	{
		int_1 = int_4;
	}

	[Attribute0(true)]
	public abstract Class454 vmethod_9();

	private void method_1(Pen pen_0, Brush brush_0, float float_3, float float_4, float float_5, float float_6, float float_7, float float_8)
	{
		Class458 @class = new Class458();
		@class.vmethod_1(class1035_0.method_0().Clone());
		Class459 class2 = new Class459();
		Class462 class3 = new Class462();
		class3.method_8(new PointF(vmethod_13(float_3), vmethod_13(float_4)));
		class3.Size = new SizeF(vmethod_13(float_5), vmethod_13(float_6));
		class3.method_10(float_7);
		class3.method_12(float_8);
		class2.method_3(class3.method_1());
		class2.Add(class3);
		@class.Add(class2);
		if (pen_0 != null)
		{
			@class.class770_0 = Class770.smethod_1(pen_0);
		}
		if (brush_0 != null)
		{
			@class.method_3((Brush)brush_0.Clone());
		}
		class454_1.Add(@class);
	}

	private void method_2(Pen pen_0, Brush brush_0, float float_3, float float_4, float float_5, float float_6, float float_7, float float_8)
	{
		Class458 @class = new Class458();
		@class.vmethod_1(class1035_0.method_0().Clone());
		Class459 class2 = new Class459();
		Class462 class3 = new Class462();
		class3.method_8(new PointF(vmethod_13(float_3), vmethod_13(float_4)));
		class3.Size = new SizeF(vmethod_13(float_5), vmethod_13(float_6));
		class3.method_10(float_7);
		class3.method_12(float_8);
		class2.Add(class3);
		Class467 class452_ = new Class467(new float[4]
		{
			class3.method_2().X,
			class3.method_2().Y,
			class3.method_14().X,
			class3.method_14().Y
		});
		class2.Add(class452_);
		class2.method_3(class3.method_1());
		@class.Add(class2);
		if (pen_0 != null)
		{
			@class.class770_0 = Class770.smethod_1(pen_0);
		}
		if (brush_0 != null)
		{
			@class.method_3((Brush)brush_0.Clone());
		}
		class454_1.Add(@class);
	}

	private void method_3(Pen pen_0, float float_3, float float_4, float float_5, float float_6)
	{
		Class458 @class = Class458.smethod_3(new PointF(vmethod_13(float_3), vmethod_13(float_4)), new PointF(vmethod_13(float_5), vmethod_13(float_6)));
		@class.vmethod_1(class1035_0.method_0().Clone());
		@class.class770_0 = Class770.smethod_1(pen_0);
		class454_1.Add(@class);
	}

	private void method_4(Pen pen_0, Brush brush_0, float float_3, float float_4, float float_5, float float_6)
	{
		Class458 @class = Class458.smethod_1(new RectangleF(vmethod_13(float_3), vmethod_13(float_4), vmethod_13(float_5), vmethod_13(float_6)));
		@class.vmethod_1(class1035_0.method_0().Clone());
		if (pen_0 != null)
		{
			@class.class770_0 = Class770.smethod_1(pen_0);
		}
		if (brush_0 != null)
		{
			@class.method_3((Brush)brush_0.Clone());
		}
		class454_1.Add(@class);
	}

	private void method_5(Pen pen_0, Brush brush_0, GraphicsPath graphicsPath_0)
	{
		Class458 @class = Class1037.smethod_0(graphicsPath_0, this);
		@class.vmethod_1(class1035_0.method_0().Clone());
		if (pen_0 != null)
		{
			@class.class770_0 = Class770.smethod_1(pen_0);
		}
		if (brush_0 != null)
		{
			@class.method_3((Brush)brush_0.Clone());
		}
		class454_1.Add(@class);
	}

	private void method_6(Pen pen_0, Brush brush_0, float[] float_3, FillMode fillMode_0)
	{
		if (float_3 != null && float_3.Length >= 2)
		{
			for (int i = 0; i < float_3.Length; i++)
			{
				float_3[i] = vmethod_13(float_3[i]);
			}
			Class458 @class = new Class458();
			@class.vmethod_1(class1035_0.method_0().Clone());
			if (pen_0 != null)
			{
				@class.class770_0 = Class770.smethod_1(pen_0);
			}
			if (brush_0 != null)
			{
				@class.method_3((Brush)brush_0.Clone());
				@class.method_5(fillMode_0);
			}
			Class459 class2 = new Class459();
			class2.method_3(new PointF(float_3[0], float_3[1]));
			class2.method_5(bool_1: true);
			Class467 class452_ = new Class467(float_3);
			class2.Add(class452_);
			@class.Add(class2);
			class454_1.Add(@class);
		}
	}

	private void method_7(Pen pen_0, Brush brush_0, float float_3, float float_4, float float_5, float float_6)
	{
		Class458 @class = Class458.smethod_2(new RectangleF(vmethod_13(float_3), vmethod_13(float_4), vmethod_13(float_5), vmethod_13(float_6)));
		@class.vmethod_1(class1035_0.method_0().Clone());
		if (pen_0 != null)
		{
			@class.class770_0 = Class770.smethod_1(pen_0);
		}
		if (brush_0 != null)
		{
			@class.method_3((Brush)brush_0.Clone());
		}
		class454_1.Add(@class);
	}

	private void method_8(Pen pen_0, PointF[] pointF_0, int int_4, int int_5, float float_3, bool bool_0)
	{
		int num = int_5 + 1;
		int num2 = num * 2 + 4;
		float[] array = new float[num2];
		int num3 = int_4 + num;
		if (num3 == pointF_0.Length)
		{
			num3--;
			array[--num2] = pointF_0[num3].Y;
			array[--num2] = pointF_0[num3].X;
		}
		while (num2 > 0 && num3 >= 0)
		{
			array[--num2] = pointF_0[num3].Y;
			array[--num2] = pointF_0[num3].X;
			num3--;
		}
		if (num2 > 0)
		{
			array[1] = pointF_0[0].Y;
			array[0] = pointF_0[0].X;
		}
		method_9(pen_0, array, float_3, bool_0);
	}

	protected void method_9(Pen pen_0, float[] float_3, float float_4, bool bool_0)
	{
		Class458 @class = new Class458();
		@class.vmethod_1(class1035_0.method_0().Clone());
		if (pen_0 != null)
		{
			@class.class770_0 = Class770.smethod_1(pen_0);
		}
		class454_1.Add(@class);
		Class459 class2 = new Class459();
		class2.method_5(bool_0);
		class2.method_3(new PointF(vmethod_13(float_3[2]), vmethod_13(float_3[3])));
		@class.Add(class2);
		Class466 class3 = new Class466();
		class2.Add(class3);
		float float_5 = float_3[2];
		float float_6 = float_3[3];
		float_4 /= 3f;
		float num = float_3[4] - float_3[0];
		float num2 = float_3[5] - float_3[1];
		float float_7 = float_3[2] + float_4 * num;
		float float_8 = float_3[3] + float_4 * num2;
		int i = 2;
		for (int num3 = float_3.Length - 4; i < num3; i += 2)
		{
			int num4 = i;
			int num5 = num4++;
			int num6 = num4++;
			int num7 = num4++;
			int num8 = num4++;
			int num9 = num4++;
			int num10 = num4++;
			num = float_3[num9] - float_3[num5];
			num2 = float_3[num10] - float_3[num6];
			float float_9 = float_3[num7] - float_4 * num;
			float float_10 = float_3[num8] - float_4 * num2;
			Struct89 struct89_ = default(Struct89);
			struct89_.method_1(new PointF(vmethod_13(float_5), vmethod_13(float_6)));
			struct89_.method_3(new PointF(vmethod_13(float_7), vmethod_13(float_8)));
			struct89_.method_5(new PointF(vmethod_13(float_9), vmethod_13(float_10)));
			struct89_.method_7(new PointF(vmethod_13(float_3[num7]), vmethod_13(float_3[num8])));
			class3.method_1(struct89_);
			float_5 = float_3[num7];
			float_6 = float_3[num8];
			float_7 = float_3[num7] + float_4 * num;
			float_8 = float_3[num8] + float_4 * num2;
		}
	}

	protected abstract void vmethod_10(Region region_0, CombineMode combineMode_0);

	protected abstract void vmethod_11(float float_3, float float_4, float float_5, float float_6, Image image_0);

	internal abstract float vmethod_12(float float_3, float float_4);

	internal abstract float vmethod_13(float float_3);

	private bool method_10(Pen pen_0)
	{
		if (pen_0.StartCap != LineCap.Custom && pen_0.EndCap != LineCap.Custom)
		{
			return false;
		}
		return true;
	}

	private Class1033 method_11(Pen pen_0)
	{
		Class1033 @class = new Class1033();
		if (pen_0.StartCap == LineCap.Custom)
		{
			@class.method_3(pen_0.CustomStartCap);
			pen_0.StartCap = LineCap.Flat;
		}
		if (pen_0.EndCap == LineCap.Custom)
		{
			@class.method_5(pen_0.CustomEndCap);
			pen_0.EndCap = LineCap.Flat;
		}
		@class.method_1((Pen)pen_0.Clone());
		return @class;
	}
}
