using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using ns22;
using ns47;

namespace ns18;

internal class Class1426 : Class1425
{
	private Class458 class458_0;

	private Class459 class459_0;

	private bool bool_1;

	internal Stack stack_0 = new Stack();

	internal Class454 class454_0 = new Class454();

	private Class454 class454_1 = new Class454();

	internal RectangleF rectangleF_0 = default(RectangleF);

	internal Class1426(Class1416 class1416_1)
		: base(class1416_1)
	{
		bool_0 = true;
	}

	internal override void Initialize(PointF pointF_0, SizeF sizeF_0)
	{
		method_9(pointF_0, sizeF_0);
	}

	internal override void vmethod_0(PointF pointF_0, string string_0)
	{
		method_5(pointF_0, string_0);
	}

	internal override void vmethod_1(PointF pointF_0, string string_0)
	{
		method_5(pointF_0, string_0);
	}

	private void method_5(PointF pointF_0, string string_0)
	{
		method_10(pointF_0, string_0);
		if ((method_0().method_15() & Enum161.flag_1) == Enum161.flag_1)
		{
			method_3(pointF_0);
		}
	}

	internal override void vmethod_2(PointF pointF_0, Color color_0)
	{
		Class458 @class = Class458.smethod_3(pointF_0, pointF_0);
		@class.class770_0 = new Class770(color_0);
		method_8(@class, bool_2: false, bool_3: false);
	}

	internal override void vmethod_3(PointF pointF_0)
	{
		if (bool_1)
		{
			method_13();
			Class459.AddLine(pointF_1: new PointF[2]
			{
				method_2(),
				pointF_0
			}, class459_0: ref class459_0);
		}
		else
		{
			Class458 class458_ = Class458.smethod_3(method_2(), pointF_0);
			method_8(class458_, bool_2: true, bool_3: false);
		}
	}

	internal override void vmethod_4(RectangleF rectangleF_1)
	{
		Class458 class458_ = Class458.smethod_2(rectangleF_1);
		method_8(class458_, bool_2: true, bool_3: true);
	}

	internal override void vmethod_5(RectangleF rectangleF_1)
	{
		Class458 class458_ = Class458.smethod_2(rectangleF_1);
		method_8(class458_, bool_2: false, bool_3: true);
	}

	internal void method_6(RectangleF rectangleF_1, Brush brush_0)
	{
		Class458 @class = Class458.smethod_2(rectangleF_1);
		@class.method_3(brush_0);
		if (@class.method_2() != null)
		{
			@class.method_5(smethod_0(method_0().method_18()));
			@class.vmethod_1(method_0().method_29());
			class454_0.Add(@class);
		}
	}

	internal override void vmethod_6(PointF[] pointF_0)
	{
		if (bool_1)
		{
			method_13();
			Class459.AddLine(ref class459_0, pointF_0);
		}
		else
		{
			Class458 class458_ = Class1421.smethod_0(pointF_0, bool_0: false);
			method_8(class458_, bool_2: true, bool_3: false);
		}
	}

	internal override void vmethod_7(PointF[] pointF_0)
	{
		if (bool_1)
		{
			if (pointF_0.Length > 0)
			{
				method_3(pointF_0[0]);
			}
			method_13();
			Class459.smethod_2(ref class459_0, pointF_0);
		}
		else
		{
			Class458 class458_ = Class1421.smethod_2(pointF_0);
			method_8(class458_, bool_2: true, bool_3: false);
			class458_0 = class458_;
		}
	}

	internal override void vmethod_8(PointF[][] pointF_0)
	{
		if (bool_1)
		{
			method_13();
			for (int i = 0; i < pointF_0.GetLength(0); i++)
			{
				Class459.AddLine(ref class459_0, pointF_0[i]);
			}
		}
		else
		{
			Class458 class458_ = Class1421.smethod_1(pointF_0, bool_0: false);
			method_8(class458_, bool_2: true, bool_3: false);
			class458_0 = class458_;
		}
	}

	internal override void vmethod_9(PointF[] pointF_0)
	{
		Class458 @class = Class1421.smethod_0(pointF_0, bool_0: true);
		class459_0 = (Class459)@class[0];
		method_8(@class, bool_2: true, bool_3: true);
		class458_0 = @class;
	}

	internal override void vmethod_10(PointF[][] pointF_0)
	{
		Class458 class458_ = Class1421.smethod_1(pointF_0, bool_0: true);
		method_8(class458_, bool_2: true, bool_3: true);
		class458_0 = class458_;
	}

	internal override void vmethod_11(RectangleF rectangleF_1, PointF pointF_0, PointF pointF_1)
	{
		Class458 class458_ = Class1421.smethod_3(rectangleF_1, pointF_0, pointF_1);
		method_8(class458_, bool_2: true, bool_3: false);
		class458_0 = class458_;
	}

	internal override void vmethod_12(RectangleF rectangleF_1)
	{
		Class458 class458_ = Class1421.smethod_4(rectangleF_1);
		method_8(class458_, bool_2: true, bool_3: true);
		class458_0 = class458_;
	}

	internal override void vmethod_13(RectangleF rectangleF_1, PointF pointF_0, PointF pointF_1)
	{
		Class458 class458_ = Class1421.smethod_5(rectangleF_1, pointF_0, pointF_1);
		method_8(class458_, bool_2: true, bool_3: true);
		class458_0 = class458_;
	}

	internal override void vmethod_14(RectangleF rectangleF_1, PointF pointF_0, PointF pointF_1)
	{
		Class458 class458_ = Class1421.smethod_6(rectangleF_1, pointF_0, pointF_1);
		method_8(class458_, bool_2: true, bool_3: true);
	}

	internal override void vmethod_15(RectangleF rectangleF_1, SizeF sizeF_0)
	{
		Class458 class458_ = Class1421.smethod_7(rectangleF_1, sizeF_0);
		method_8(class458_, bool_2: true, bool_3: true);
	}

	internal override void vmethod_16(RectangleF rectangleF_1, RectangleF rectangleF_2, byte[] byte_0)
	{
		Class454 @class = new Class454();
		PointF pointF_ = new PointF(rectangleF_2.Left, rectangleF_2.Top);
		SizeF sizeF_ = new SizeF(rectangleF_2.Width, rectangleF_2.Height);
		Class465 class452_ = new Class465(pointF_, sizeF_, byte_0);
		@class.Add(class452_);
		@class.vmethod_1(method_0().method_29());
		class454_0.Add(@class);
	}

	internal void method_7(RectangleF rectangleF_1, RectangleF rectangleF_2, Matrix matrix_0, Color color_0, Enum158 enum158_0, byte[] byte_0)
	{
		Class454 @class = new Class454();
		PointF pointF_ = new PointF(rectangleF_2.Left, rectangleF_2.Top);
		SizeF sizeF_ = new SizeF(rectangleF_2.Width, rectangleF_2.Height);
		Class465 class2 = new Class465(pointF_, sizeF_, byte_0);
		class2.method_6(enum158_0);
		@class.Add(class2);
		@class.vmethod_1(method_0().method_29());
		@class.imethod_0().Multiply(matrix_0);
		class454_0.Add(@class);
	}

	internal override void vmethod_17(RectangleF rectangleF_1)
	{
		Class458 class458_ = new Class458(rectangleF_1);
		Class454 @class = new Class454();
		@class.vmethod_2(class458_);
		class454_0.Add(@class);
		class454_0 = @class;
	}

	private void method_8(Class458 class458_1, bool bool_2, bool bool_3)
	{
		if (bool_2)
		{
			class458_1.class770_0 = Class770.smethod_1(method_0().method_9());
		}
		if (bool_3)
		{
			class458_1.method_3(method_0().method_10());
		}
		if (class458_1.class770_0 != null || class458_1.method_2() != null)
		{
			switch (method_0().method_24())
			{
			case Enum149.const_10:
				return;
			}
			class458_1.method_5(smethod_0(method_0().method_18()));
			class458_1.vmethod_1(method_0().method_29());
			class454_0.Add(class458_1);
		}
	}

	[Attribute0(true)]
	internal static FillMode smethod_0(Enum150 enum150_0)
	{
		return enum150_0 switch
		{
			Enum150.const_0 => FillMode.Alternate, 
			Enum150.const_1 => FillMode.Winding, 
			_ => throw new Exception($"Unknown GDI fill mode[{enum150_0}]."), 
		};
	}

	private void method_9(PointF pointF_0, SizeF sizeF_0)
	{
		SizeF size = method_1().Size;
		float m = sizeF_0.Width / size.Width;
		float m2 = sizeF_0.Height / size.Height;
		if (size.Width * size.Height <= 0f || sizeF_0.Width * sizeF_0.Height <= 0f)
		{
			m = 0.0001f;
			m2 = 0.0001f;
		}
		class454_1.vmethod_1(new Matrix(m, 0f, 0f, m2, pointF_0.X, pointF_0.Y));
		class454_1.imethod_0().Translate(0f - method_1().method_6().X, 0f - method_1().method_6().Y);
		class454_1.Add(class454_0);
	}

	private void method_10(PointF pointF_0, string string_0)
	{
		Class1396 @class = method_0().method_11();
		if (!Class1462.smethod_6(@class.Name, @class.Style, string_0))
		{
			@class = new Class1396(Struct78.string_0, @class.Size, @class.Style);
		}
		Class463 class2 = new Class463(@class, method_0().method_13(), pointF_0, method_0().method_22(), string_0);
		class2.vmethod_1(method_0().method_29());
		class2.imethod_0().Multiply(method_0().method_6(ref pointF_0, class2.Size, class2.method_1()));
		class2.method_5(new PointF(pointF_0.X, pointF_0.Y));
		method_11(class2);
		class454_0.Add(class2);
	}

	private void method_11(Class463 class463_0)
	{
		RectangleF rectangleF = new RectangleF(class463_0.method_4(), class463_0.Size);
		Class458 @class = Class458.smethod_2(rectangleF);
		@class.method_3(new SolidBrush(method_0().BackgroundColor));
		if (method_0().BackgroundMode != Enum145.const_0 || method_0().BackgroundColor.R != byte.MaxValue || method_0().BackgroundColor.G != byte.MaxValue || method_0().BackgroundColor.B != byte.MaxValue)
		{
			@class.vmethod_1(class463_0.imethod_0().Clone());
			@class.imethod_0().Translate(0f, 0f - class463_0.method_1().method_1());
			class454_0.Add(@class);
		}
	}

	[SpecialName]
	internal Class454 method_12()
	{
		return class454_1;
	}

	private void method_13()
	{
		if (class459_0 == null)
		{
			class459_0 = new Class459(method_2());
		}
	}

	internal void method_14()
	{
		method_17(bool_2: true);
	}

	internal void method_15()
	{
		bool_1 = true;
		class458_0 = new Class458();
		class459_0 = null;
	}

	internal void method_16()
	{
		method_17(bool_2: false);
		bool_1 = false;
	}

	private void method_17(bool bool_2)
	{
		if (class459_0 != null)
		{
			class459_0.method_5(bool_2);
			if (class458_0 == null)
			{
				class458_0 = new Class458();
			}
			class458_0.vmethod_1(method_0().method_29());
			class458_0.method_5(smethod_0(method_0().method_18()));
			class458_0.Add(class459_0);
			class459_0 = null;
		}
	}

	internal void method_18()
	{
		if (class458_0 != null && method_0().method_10() != null)
		{
			method_17(bool_2: true);
			class458_0.method_3(method_0().method_10());
			method_23();
		}
	}

	internal void method_19()
	{
		if (class458_0 != null && method_0().method_9() != null)
		{
			method_17(bool_2: false);
			class458_0.class770_0 = Class770.smethod_1(method_0().method_9());
			method_23();
		}
	}

	internal void method_20()
	{
		if (class458_0 != null && (method_0().method_10() != null || method_0().method_9() != null))
		{
			method_17(bool_2: false);
			class458_0.method_3(method_0().method_10());
			class458_0.class770_0 = Class770.smethod_1(method_0().method_9());
			method_23();
		}
	}

	internal void method_21()
	{
		Class454 class452_ = new Class454();
		class454_0.Add(class452_);
		stack_0.Push(class454_0);
		class454_0 = class452_;
		class458_0 = null;
		class459_0 = null;
	}

	internal void method_22()
	{
		class454_0 = (Class454)stack_0.Pop();
		class458_0 = null;
		class459_0 = null;
	}

	private void method_23()
	{
		class458_0.method_5(smethod_0(method_0().method_18()));
		class454_0.Add(class458_0);
		class458_0 = null;
	}

	internal void method_24(Enum159 enum159_0)
	{
		method_17(bool_2: true);
		Class454 @class = new Class454();
		switch (enum159_0)
		{
		default:
			@class.vmethod_2(class458_0);
			class454_1.Add(@class);
			class454_0 = @class;
			class458_0 = null;
			break;
		case Enum159.const_4:
			class454_1.Add(@class);
			class454_0 = @class;
			class458_0 = null;
			break;
		case Enum159.const_0:
			@class.vmethod_2(class458_0);
			class454_0.Add(@class);
			class454_0.method_1().Remove(class458_0);
			class454_0 = @class;
			class458_0 = null;
			break;
		}
	}
}
