using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns221;
using ns224;

namespace ns264;

internal abstract class Class6485
{
	private Class6496 class6496_0;

	protected Class6479 class6479_0;

	private Class6490 class6490_0;

	private Stack stack_0;

	private Class6489 class6489_0;

	private RectangleF rectangleF_0 = RectangleF.Empty;

	private PointF pointF_0 = PointF.Empty;

	protected bool bool_0;

	internal Class6496 MetafileInfo => class6496_0;

	internal Class6490 DC => class6490_0;

	internal RectangleF ViewportRect => rectangleF_0;

	internal PointF CurrentPosition
	{
		get
		{
			return pointF_0;
		}
		set
		{
			pointF_0 = value;
		}
	}

	internal Class6489 GdiObjects => class6489_0;

	internal bool IsUnsupportedRecordMet => bool_0;

	internal static Class6485 smethod_0(Enum868 metafileType)
	{
		switch (metafileType)
		{
		default:
			throw new InvalidOperationException("Unknown metafile type.");
		case Enum868.const_1:
		case Enum868.const_2:
			return new Class6486();
		case Enum868.const_3:
		case Enum868.const_4:
		case Enum868.const_5:
			return new Class6488();
		}
	}

	internal void method_0(Class6496 metafileInfo, Class6479 sink)
	{
		method_1(metafileInfo, sink, new Class6483());
	}

	internal void method_1(Class6496 metafileInfo, Class6479 sink, Class6483 context)
	{
		class6496_0 = metafileInfo;
		class6479_0 = sink;
		switch (class6496_0.MetafileType)
		{
		default:
			throw new InvalidOperationException("Unknown metafile type.");
		case Enum868.const_1:
		case Enum868.const_2:
			class6489_0 = new Class6489(isEmf: false);
			method_2();
			break;
		case Enum868.const_3:
		case Enum868.const_4:
		case Enum868.const_5:
			class6489_0 = new Class6489(isEmf: true);
			method_11();
			break;
		}
		class6490_0 = new Class6490(this);
		stack_0 = new Stack();
		rectangleF_0 = new RectangleF(PointF.Empty, Class6496.sizeF_0);
		if (class6479_0 != null)
		{
			class6479_0.vmethod_0();
		}
		vmethod_0();
		context.IsUnsupportedRecordMet = IsUnsupportedRecordMet;
	}

	private void method_2()
	{
		for (uint num = 0u; num < class6496_0.ObjectCount; num++)
		{
			class6489_0.Add(null);
		}
	}

	[Attribute7(true)]
	protected abstract void vmethod_0();

	internal void method_3()
	{
		stack_0.Push(rectangleF_0);
		stack_0.Push(class6490_0);
		class6490_0 = class6490_0.Clone();
		class6479_0.vmethod_1();
	}

	internal void method_4()
	{
		class6479_0.vmethod_4();
		class6490_0 = (Class6490)stack_0.Pop();
		rectangleF_0 = (RectangleF)stack_0.Pop();
	}

	internal void method_5(PointF value)
	{
		rectangleF_0 = new RectangleF(value.X, value.Y, rectangleF_0.Width, rectangleF_0.Height);
	}

	internal void method_6(SizeF value)
	{
		rectangleF_0 = new RectangleF(rectangleF_0.X, rectangleF_0.Y, value.Width, value.Height);
	}

	private void method_7(Class5998 color)
	{
		Class6491 @class = new Class6491();
		if (color == Class5998.class5998_141)
		{
			@class.Style = Enum840.const_1;
		}
		else
		{
			@class.ForeColor = color;
		}
		class6489_0.Add(@class);
	}

	private void method_8(Class5998 color)
	{
		Class6495 @class = new Class6495();
		if (color == Class5998.class5998_141)
		{
			@class.Style = Enum839.flag_5;
		}
		else
		{
			@class.Color = color;
		}
		class6489_0.Add(@class);
	}

	private void method_9(string faceName)
	{
		Class6493 @class = new Class6493();
		@class.FaceName = faceName;
		class6489_0.Add(@class);
	}

	private void method_10()
	{
		Class6492 value = new Class6492();
		class6489_0.Add(value);
	}

	private void method_11()
	{
		method_7(Class5998.class5998_136);
		method_7(Class5998.class5998_7);
		method_7(Class5998.class5998_49);
		method_7(new Class5998(64, 64, 64));
		method_7(Class5998.class5998_7);
		method_7(Class5998.class5998_141);
		method_8(Class5998.class5998_136);
		method_8(Class5998.class5998_7);
		method_8(Class5998.class5998_141);
		method_8(Class5998.class5998_141);
		method_9("Microsoft Sans Serif");
		method_9("Courier New");
		method_9("Microsoft Sans Serif");
		method_9("Tahoma");
		method_9("Microsoft Sans Serif");
		class6489_0.Add(new Class6494());
		method_9("Microsoft Sans Serif");
		method_9("Microsoft Sans Serif");
		method_10();
		method_10();
	}

	protected void method_12(RectangleF rect)
	{
		class6479_0.vmethod_2(method_30(rect));
	}

	protected void method_13(RectangleF rect)
	{
		class6479_0.vmethod_3(method_30(rect));
	}

	protected void method_14(SizeF size)
	{
		DC.ClipRegion.Translate(size.Width * DC.Transform.M11, size.Height * DC.Transform.M22);
	}

	protected void method_15(Class5998 color)
	{
		DC.BackgroundColor = color;
	}

	protected void method_16(Enum843 mapMode)
	{
		DC.MapMode = mapMode;
		DC.method_12();
	}

	protected void method_17(PointF point)
	{
		DC.method_2(point);
		DC.method_12();
	}

	protected void method_18(SizeF size)
	{
		DC.method_3(size);
		DC.method_12();
	}

	protected void method_19(PointF point)
	{
		method_5(point);
		DC.method_12();
	}

	protected void method_20(SizeF size)
	{
		method_6(size);
		DC.method_12();
	}

	protected void method_21(Interface318 gdiObject)
	{
		GdiObjects.Add(gdiObject);
	}

	protected void method_22(int handle)
	{
		DC.method_1(handle);
	}

	protected void method_23(int handle)
	{
		GdiObjects.method_0(handle);
	}

	protected void method_24(Enum842 bkMode)
	{
		DC.BackgroundMode = bkMode;
	}

	protected void method_25(Class5998 color)
	{
		DC.TextColor = color;
	}

	protected void method_26(Enum845 textAlign)
	{
		DC.TextAlign = textAlign;
	}

	protected void method_27(PointF point)
	{
		CurrentPosition = point;
		class6479_0.vmethod_35(closed: false);
	}

	protected void method_28(PointF point)
	{
		class6479_0.vmethod_12(point);
		CurrentPosition = point;
	}

	protected void method_29(RectangleF rectf)
	{
		class6479_0.vmethod_19(rectf);
	}

	internal static FillMode smethod_1(Enum844 mode)
	{
		return mode switch
		{
			Enum844.const_0 => FillMode.Alternate, 
			Enum844.const_1 => FillMode.Winding, 
			_ => throw new InvalidOperationException($"Unknown GDI fill mode[{mode}]."), 
		};
	}

	private RectangleF method_30(RectangleF rect)
	{
		PointF[] array = new PointF[2]
		{
			new PointF(rect.X, rect.Y),
			new PointF(rect.X + rect.Width, rect.Y + rect.Height)
		};
		DC.Transform.method_3(array);
		return RectangleF.FromLTRB(array[0].X, array[0].Y, array[1].X, array[1].Y);
	}

	protected void method_31(SizeF size)
	{
		method_6(size);
		DC.method_4(size);
		DC.method_12();
	}
}
