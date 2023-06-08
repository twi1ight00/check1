using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns224;
using ns271;

namespace ns264;

internal class Class6490
{
	private readonly Class6485 class6485_0;

	private RectangleF rectangleF_0 = RectangleF.Empty;

	private Enum842 enum842_0;

	private Enum843 enum843_0;

	private Class5998 class5998_0;

	private Class5998 class5998_1;

	private Enum845 enum845_0;

	private int int_0;

	private Enum844 enum844_0;

	private Enum847 enum847_0;

	private Enum861 enum861_0;

	private Enum848 enum848_0;

	private Enum854 enum854_0;

	private Enum852 enum852_0;

	private Enum853 enum853_0;

	private Enum851 enum851_0;

	private Enum855 enum855_0;

	private int int_1;

	private int int_2;

	private Class6002 class6002_0;

	private Class6002 class6002_1;

	private Region region_0;

	private Class6495 class6495_0;

	private Class6491 class6491_0;

	private Class6493 class6493_0;

	private Class6003 class6003_0;

	private Class5990 class5990_0;

	private Class5999 class5999_0;

	private SizeF sizeF_0 = SizeF.Empty;

	private bool bool_0;

	internal Class6003 Pen
	{
		get
		{
			if (enum861_0 == Enum861.const_10)
			{
				return null;
			}
			if (class6003_0 == null)
			{
				class6003_0 = class6495_0.method_3(BackgroundColor);
			}
			return class6003_0;
		}
	}

	internal Class5990 Brush
	{
		get
		{
			if (class5990_0 == null)
			{
				class5990_0 = class6491_0.method_5(method_11());
			}
			return class5990_0;
		}
	}

	internal Class6493 LogFont => class6493_0;

	internal Class5999 Font
	{
		get
		{
			if (class5999_0 == null)
			{
				class5999_0 = class6493_0.method_2();
			}
			return class5999_0;
		}
	}

	internal RectangleF WindowRect => rectangleF_0;

	internal Class5998 BackgroundColor
	{
		get
		{
			if (enum842_0 == Enum842.const_0)
			{
				return new Class5998(0, class5998_0);
			}
			return class5998_0;
		}
		set
		{
			class5998_0 = value;
			method_9();
		}
	}

	internal Enum842 BackgroundMode
	{
		get
		{
			return enum842_0;
		}
		set
		{
			enum842_0 = value;
			method_9();
		}
	}

	internal Class5998 TextColor
	{
		get
		{
			return class5998_1;
		}
		set
		{
			class5998_1 = value;
		}
	}

	internal Enum845 TextAlign
	{
		get
		{
			return enum845_0;
		}
		set
		{
			enum845_0 = value;
		}
	}

	internal Enum843 MapMode
	{
		get
		{
			return enum843_0;
		}
		set
		{
			enum843_0 = value;
			sizeF_0 = Class6496.sizeF_0;
			bool_0 = false;
		}
	}

	internal Enum844 FillMode
	{
		get
		{
			return enum844_0;
		}
		set
		{
			enum844_0 = value;
		}
	}

	internal Enum847 IcmMode
	{
		get
		{
			return enum847_0;
		}
		set
		{
			enum847_0 = value;
		}
	}

	internal Enum861 BinaryRasterOperation
	{
		get
		{
			return enum861_0;
		}
		set
		{
			if (value != enum861_0)
			{
				enum861_0 = value;
				class6003_0 = null;
			}
		}
	}

	internal Enum848 StretchBltMode
	{
		get
		{
			return enum848_0;
		}
		set
		{
			enum848_0 = value;
		}
	}

	internal int CharacterExtra
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
		}
	}

	internal Enum854 InterpolationMode
	{
		get
		{
			return enum854_0;
		}
		set
		{
			enum854_0 = value;
		}
	}

	internal Enum852 CompositingMode
	{
		get
		{
			return enum852_0;
		}
		set
		{
			enum852_0 = value;
		}
	}

	internal Enum853 CompositingQuality
	{
		get
		{
			return enum853_0;
		}
		set
		{
			enum853_0 = value;
		}
	}

	internal Enum851 TextRenderingHint
	{
		get
		{
			return enum851_0;
		}
		set
		{
			enum851_0 = value;
		}
	}

	internal int TextContrast
	{
		get
		{
			return int_1;
		}
		set
		{
			int_1 = value;
		}
	}

	internal Enum855 PixelOffsetMode
	{
		get
		{
			return enum855_0;
		}
		set
		{
			enum855_0 = value;
		}
	}

	internal int AntiAlias
	{
		get
		{
			return int_2;
		}
		set
		{
			int_2 = value;
		}
	}

	private Class6002 PageToDeviceTransform
	{
		get
		{
			if (class6002_1 == null)
			{
				method_12();
			}
			return class6002_1;
		}
	}

	internal Class6002 Transform
	{
		get
		{
			Class6002 @class = PageToDeviceTransform.Clone();
			@class.method_9(class6002_0, MatrixOrder.Prepend);
			return @class;
		}
	}

	internal Region ClipRegion
	{
		get
		{
			if (region_0 == null)
			{
				region_0 = new Region();
			}
			return region_0;
		}
		set
		{
			region_0 = value;
		}
	}

	internal bool HasClipRegion => region_0 != null;

	internal Class6490(Class6485 context)
	{
		class6485_0 = context;
		method_8();
	}

	public SizeF method_0(string text)
	{
		SizeF sizeF = Font.method_4(text);
		return new SizeF(sizeF.Width + (float)(text.Length * int_0), sizeF.Height);
	}

	internal void method_1(int handle)
	{
		Interface318 @interface = class6485_0.GdiObjects[handle];
		if (@interface == null)
		{
			throw new InvalidOperationException($"No Gdi object for handle {handle}=0x{handle:x}.");
		}
		switch (@interface.Type)
		{
		case Enum866.const_1:
			class6491_0 = (Class6491)@interface;
			method_9();
			break;
		case Enum866.const_2:
			class6495_0 = (Class6495)@interface;
			class6003_0 = null;
			break;
		case Enum866.const_6:
			class6493_0 = (Class6493)@interface;
			class5999_0 = null;
			break;
		default:
			throw new InvalidOperationException("Unknown GDI object type.");
		case Enum866.const_4:
		case Enum866.const_10:
		case Enum866.const_11:
			break;
		}
	}

	internal void method_2(PointF value)
	{
		rectangleF_0 = new RectangleF(value.X, value.Y, rectangleF_0.Width, rectangleF_0.Height);
	}

	internal void method_3(SizeF value)
	{
		rectangleF_0 = new RectangleF(rectangleF_0.X, rectangleF_0.Y, value.Width, value.Height);
		bool_0 = true;
	}

	internal void method_4(SizeF value)
	{
		sizeF_0 = smethod_0(value);
	}

	internal Class6490 Clone()
	{
		Class6490 @class = (Class6490)MemberwiseClone();
		if (class6002_0 != null)
		{
			@class.class6002_0 = class6002_0.Clone();
		}
		if (class6002_1 != null)
		{
			@class.class6002_1 = class6002_1.Clone();
		}
		if (region_0 != null)
		{
			@class.region_0 = region_0.Clone();
		}
		return @class;
	}

	private float method_5(SizeF size)
	{
		return (Enum845.flag_4 & enum845_0) switch
		{
			Enum845.flag_4 => size.Width / 2f, 
			Enum845.flag_3 => size.Width, 
			_ => 0f, 
		};
	}

	private float method_6(Class5999 font)
	{
		return (Enum845.flag_7 & enum845_0) switch
		{
			Enum845.flag_6 => 0f - font.DescentPoints, 
			Enum845.flag_0 => font.AscentPoints, 
			_ => 0f, 
		};
	}

	internal Class6002 method_7(PointF[] origin, SizeF size, Class5999 font)
	{
		Class6002 @class = Transform.Clone();
		@class.method_7(0f - method_5(size), method_6(font), MatrixOrder.Prepend);
		float[] array = @class.method_0();
		float[] array2 = new float[4]
		{
			Math.Sign(array[0]),
			Math.Sign(array[3]),
			Math.Sign(array[4]),
			Math.Sign(array[5])
		};
		array2[2] = ((array2[0] < 0f) ? array2[2] : 1f);
		array2[3] = ((array2[1] < 0f) ? array2[3] : 1f);
		ref PointF reference = ref origin[0];
		reference = new PointF(array2[0] * origin[0].X, array2[1] * origin[0].Y);
		@class = new Class6002(array2[0] * array[0], array[1], array[2], array2[1] * array[3], array2[2] * array[4], array2[3] * array[5]);
		@class.method_13(0f - class6493_0.Escapement, new PointF(origin[0].X, origin[0].Y - method_6(font)), MatrixOrder.Prepend);
		return @class;
	}

	private void method_8()
	{
		rectangleF_0 = Class6496.rectangleF_1;
		enum842_0 = Enum842.const_1;
		enum843_0 = Enum843.const_7;
		class5998_0 = Class5998.class5998_136;
		class5998_1 = Class5998.class5998_7;
		enum845_0 = Enum845.flag_0;
		int_0 = 0;
		enum844_0 = Enum844.const_0;
		enum847_0 = Enum847.const_1;
		enum861_0 = Enum861.const_12;
		enum848_0 = Enum848.const_2;
		enum854_0 = Enum854.const_0;
		enum852_0 = Enum852.const_1;
		enum853_0 = Enum853.const_0;
		enum851_0 = Enum851.const_0;
		enum855_0 = Enum855.const_0;
		int_1 = 4;
		int_2 = 1;
		class6002_0 = new Class6002();
		region_0 = null;
		class6495_0 = new Class6495();
		class6491_0 = new Class6491();
		class6493_0 = new Class6493();
		class6003_0 = new Class6003(class5998_1);
		class6003_0.StartCap = LineCap.Round;
		class6003_0.EndCap = LineCap.Round;
		class6003_0.LineJoin = LineJoin.Round;
		class5990_0 = new Class5997(class5998_0);
		class5999_0 = Class6652.Instance.method_1("Microsoft Sans Serif", 12f, FontStyle.Regular);
		sizeF_0 = Class6496.sizeF_0;
		bool_0 = false;
	}

	private void method_9()
	{
		if (class6491_0 != null && class6491_0.Style == Enum840.const_3)
		{
			class6491_0.BackColor = ((BackgroundMode == Enum842.const_1) ? class5998_0 : Class5998.class5998_141);
		}
		class5990_0 = null;
	}

	internal Class5990 method_10(int handle)
	{
		Class6491 @class = (Class6491)class6485_0.GdiObjects[handle];
		return @class.method_5(method_11());
	}

	private Class6002 method_11()
	{
		Class6002 @class = new Class6002();
		Enum868 metafileType = class6485_0.MetafileInfo.MetafileType;
		if (metafileType == Enum868.const_2)
		{
			float num = class6485_0.MetafileInfo.HorizontalResolution / 96f;
			@class.method_5(num, num, MatrixOrder.Prepend);
		}
		else
		{
			@class.method_5(1f / Transform.M11, 1f / Transform.M22, MatrixOrder.Prepend);
		}
		return @class;
	}

	internal void method_12()
	{
		class6002_1 = new Class6002();
		switch (enum843_0)
		{
		default:
			throw new InvalidOperationException("Unknown mapping mode.");
		case Enum843.const_0:
			break;
		case Enum843.const_1:
			class6002_1.method_5(0.28346458f, -0.28346458f, MatrixOrder.Prepend);
			break;
		case Enum843.const_2:
			class6002_1.method_5(0.028346457f, -0.028346457f, MatrixOrder.Prepend);
			break;
		case Enum843.const_3:
			class6002_1.method_5(0.71999997f, -0.71999997f, MatrixOrder.Prepend);
			break;
		case Enum843.const_4:
			class6002_1.method_5(0.072000004f, -0.072000004f, MatrixOrder.Prepend);
			break;
		case Enum843.const_5:
			class6002_1.method_5(0.05f, -0.05f, MatrixOrder.Prepend);
			break;
		case Enum843.const_6:
			method_13();
			if (bool_0)
			{
				SizeF sizeF = smethod_0(rectangleF_0.Size);
				float num = ((sizeF.Width == 0f) ? 0f : (sizeF_0.Width / sizeF.Width));
				float num2 = ((sizeF.Height == 0f) ? 0f : (sizeF_0.Height / sizeF.Height));
				class6002_1.method_7((0f - WindowRect.X) * num + class6485_0.ViewportRect.X, (0f - WindowRect.Y) * num2 + class6485_0.ViewportRect.Y, MatrixOrder.Prepend);
				class6002_1.method_5(num, num2, MatrixOrder.Prepend);
			}
			else
			{
				class6002_1.method_5(0.28346458f, -0.28346458f, MatrixOrder.Prepend);
			}
			break;
		case Enum843.const_7:
		{
			method_13();
			float num = ((rectangleF_0.Width == 0f) ? 0f : (class6485_0.ViewportRect.Width / rectangleF_0.Width));
			float num2 = ((rectangleF_0.Height == 0f) ? 0f : (class6485_0.ViewportRect.Height / rectangleF_0.Height));
			class6002_1.method_7((0f - WindowRect.X) * num + class6485_0.ViewportRect.X, (0f - WindowRect.Y) * num2 + class6485_0.ViewportRect.Y, MatrixOrder.Prepend);
			class6002_1.method_5(num, num2, MatrixOrder.Prepend);
			break;
		}
		}
	}

	private void method_13()
	{
		if (class6485_0.ViewportRect.Width == 0f)
		{
			throw new InvalidOperationException("Viewport width is invalid.");
		}
		if (class6485_0.ViewportRect.Height == 0f)
		{
			throw new InvalidOperationException("Viewport height is invalid.");
		}
	}

	internal void method_14(Class6002 matrix)
	{
		class6002_0 = matrix;
	}

	internal void method_15(Class6002 matrix, Enum859 mode)
	{
		switch (mode)
		{
		case Enum859.const_0:
			class6002_0 = new Class6002();
			break;
		case Enum859.const_1:
			class6002_0.method_9(matrix, MatrixOrder.Prepend);
			break;
		case Enum859.const_2:
			class6002_0.method_9(matrix, MatrixOrder.Append);
			break;
		case Enum859.const_3:
			method_14(matrix);
			break;
		}
	}

	private static SizeF smethod_0(SizeF value)
	{
		float num = Math.Abs(value.Width);
		float num2 = Math.Abs(value.Height);
		float num3 = ((num < num2) ? num : num2);
		num = (float)Math.Sign(value.Width) * num3;
		num2 = (float)Math.Sign(value.Height) * num3;
		return new SizeF(num, num2);
	}
}
