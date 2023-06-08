using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using ns22;

namespace ns18;

internal class Class1407
{
	private readonly Class1416 class1416_0;

	private RectangleF rectangleF_0;

	private Enum145 enum145_0;

	private Enum154 enum154_0;

	private Color color_0;

	private Color color_1;

	private Enum161 enum161_0;

	private int int_0;

	private Enum150 enum150_0;

	private Enum152 enum152_0;

	private Enum160 enum160_0;

	private Enum153 enum153_0;

	private Enum147 enum147_0;

	private Enum148 enum148_0;

	private Enum162 enum162_0;

	private Enum157 enum157_0;

	private Enum149 enum149_0;

	private int int_1;

	private int int_2;

	internal Matrix matrix_0;

	private Matrix matrix_1;

	private Class1413 class1413_0;

	private Class1409 class1409_0;

	private Class1411 class1411_0;

	private Pen pen_0;

	private Brush brush_0;

	private Class1396 class1396_0;

	private SizeF sizeF_0;

	private bool bool_0;

	internal Color BackgroundColor
	{
		get
		{
			if (enum145_0 == Enum145.const_0)
			{
				return Color.FromArgb(0, color_0);
			}
			return color_0;
		}
		set
		{
			color_0 = value;
			method_8();
		}
	}

	internal Enum145 BackgroundMode
	{
		get
		{
			return enum145_0;
		}
		set
		{
			enum145_0 = value;
			method_8();
		}
	}

	internal Class1407(Class1416 class1416_1)
	{
		class1416_0 = class1416_1;
		method_7();
	}

	[Attribute0(true)]
	internal void method_0(uint uint_0)
	{
		Interface46 @interface = class1416_0.method_10()[uint_0];
		if (@interface == null)
		{
			throw new Exception($"No Gdi object for handle {uint_0}=0x{uint_0:x}");
		}
		switch (@interface.Type)
		{
		default:
			throw new InvalidOperationException("Unknown GDI object type.");
		case Enum203.const_10:
		case Enum203.const_11:
			break;
		case Enum203.const_6:
			class1411_0 = @interface as Class1411;
			class1396_0 = null;
			break;
		case Enum203.const_1:
			class1409_0 = @interface as Class1409;
			method_8();
			break;
		case Enum203.const_2:
			class1413_0 = @interface as Class1413;
			pen_0 = null;
			break;
		}
	}

	internal void method_1(PointF pointF_0)
	{
		rectangleF_0.Location = pointF_0;
	}

	internal void method_2(SizeF sizeF_1)
	{
		rectangleF_0.Size = sizeF_1;
		bool_0 = true;
	}

	internal void method_3(SizeF sizeF_1)
	{
		sizeF_0 = smethod_0(sizeF_1);
	}

	internal Class1407 Clone()
	{
		Class1407 @class = (Class1407)MemberwiseClone();
		if (matrix_0 != null)
		{
			@class.matrix_0 = matrix_0.Clone();
		}
		if (matrix_1 != null)
		{
			@class.matrix_1 = matrix_1.Clone();
		}
		return @class;
	}

	private float method_4(SizeF sizeF_1)
	{
		return (Enum161.flag_4 & enum161_0) switch
		{
			Enum161.flag_4 => sizeF_1.Width / 2f, 
			Enum161.flag_3 => sizeF_1.Width, 
			_ => 0f, 
		};
	}

	private float method_5(Class1396 class1396_1)
	{
		return (Enum161.flag_7 & enum161_0) switch
		{
			Enum161.flag_6 => 0f - class1396_1.method_2(), 
			Enum161.flag_0 => class1396_1.method_1(), 
			_ => 0f, 
		};
	}

	internal Matrix method_6(ref PointF pointF_0, SizeF sizeF_1, Class1396 class1396_1)
	{
		Matrix matrix = new Matrix();
		matrix.Translate(0f - method_4(sizeF_1), method_5(class1396_1));
		float[] elements = matrix.Elements;
		float[] array = new float[4]
		{
			Math.Sign(elements[0]),
			Math.Sign(elements[3]),
			Math.Sign(elements[4]),
			Math.Sign(elements[5])
		};
		array[2] = ((array[0] < 0f) ? array[2] : 1f);
		array[3] = ((array[1] < 0f) ? array[3] : 1f);
		pointF_0 = new PointF(array[0] * pointF_0.X, array[1] * pointF_0.Y);
		matrix = new Matrix(array[0] * elements[0], elements[1], elements[2], array[1] * elements[3], array[2] * elements[4], array[3] * elements[5]);
		matrix.RotateAt(0f - class1411_0.method_5(), new PointF(pointF_0.X, pointF_0.Y));
		return matrix;
	}

	public void method_7()
	{
		rectangleF_0 = Class1406.smethod_0();
		enum145_0 = Enum145.const_1;
		enum154_0 = Enum154.const_7;
		color_0 = Color.White;
		color_1 = Color.Black;
		enum161_0 = Enum161.flag_0;
		int_0 = 0;
		enum150_0 = Enum150.const_0;
		enum152_0 = Enum152.const_1;
		enum160_0 = Enum160.const_2;
		enum153_0 = Enum153.const_0;
		enum147_0 = Enum147.const_1;
		enum148_0 = Enum148.const_0;
		enum162_0 = Enum162.const_0;
		enum157_0 = Enum157.const_0;
		int_1 = 4;
		int_2 = 1;
		matrix_0 = new Matrix();
		class1413_0 = new Class1413();
		class1409_0 = new Class1409();
		class1411_0 = new Class1411();
		pen_0 = new Pen(color_1);
		pen_0.StartCap = LineCap.Round;
		pen_0.EndCap = LineCap.Round;
		pen_0.LineJoin = LineJoin.Round;
		brush_0 = new SolidBrush(color_0);
		class1396_0 = Class1396.smethod_1("Microsoft Sans Serif", 12f, FontStyle.Regular);
		sizeF_0 = Class1406.smethod_1();
		bool_0 = false;
	}

	private void method_8()
	{
		if ((class1409_0 != null && class1409_0.Style == Enum146.const_3) || class1409_0.Style == Enum146.const_11)
		{
			class1409_0.BackColor = ((BackgroundMode == Enum145.const_1) ? color_0 : Color.Empty);
		}
		brush_0 = null;
	}

	[SpecialName]
	internal Pen method_9()
	{
		if (pen_0 == null)
		{
			pen_0 = class1413_0.method_3(BackgroundColor);
		}
		return pen_0;
	}

	[SpecialName]
	internal Brush method_10()
	{
		if (brush_0 == null)
		{
			Matrix matrix = new Matrix();
			Enum202 imageType = class1416_0.method_4().ImageType;
			if (imageType == Enum202.const_2)
			{
				float num = class1416_0.method_4().HorizontalResolution / 96f;
				matrix.Scale(num, num);
				brush_0 = class1409_0.method_5(matrix);
			}
			else
			{
				matrix.Scale(1f / method_29().Elements[0], 1f / method_29().Elements[3]);
			}
			brush_0 = class1409_0.method_5(matrix);
		}
		return brush_0;
	}

	[SpecialName]
	internal Class1396 method_11()
	{
		if (class1396_0 == null)
		{
			class1396_0 = class1411_0.method_2();
		}
		return class1396_0;
	}

	[SpecialName]
	internal RectangleF method_12()
	{
		return rectangleF_0;
	}

	[SpecialName]
	internal Color method_13()
	{
		return color_1;
	}

	[SpecialName]
	internal void method_14(Color color_2)
	{
		color_1 = color_2;
	}

	[SpecialName]
	internal Enum161 method_15()
	{
		return enum161_0;
	}

	[SpecialName]
	internal void method_16(Enum161 enum161_1)
	{
		enum161_0 = enum161_1;
	}

	[SpecialName]
	internal void method_17(Enum154 enum154_1)
	{
		enum154_0 = enum154_1;
		sizeF_0 = Class1406.smethod_1();
		bool_0 = false;
	}

	[SpecialName]
	internal Enum150 method_18()
	{
		return enum150_0;
	}

	[SpecialName]
	internal void method_19(Enum150 enum150_1)
	{
		enum150_0 = enum150_1;
	}

	[SpecialName]
	internal void method_20(Enum152 enum152_1)
	{
		enum152_0 = enum152_1;
	}

	[SpecialName]
	internal void method_21(Enum160 enum160_1)
	{
		enum160_0 = enum160_1;
	}

	[SpecialName]
	internal int method_22()
	{
		return int_0;
	}

	[SpecialName]
	internal void method_23(int int_3)
	{
		int_0 = int_3;
	}

	[SpecialName]
	internal Enum149 method_24()
	{
		return enum149_0;
	}

	[SpecialName]
	internal void method_25(Enum149 enum149_1)
	{
		enum149_0 = enum149_1;
	}

	[SpecialName]
	internal Matrix method_26()
	{
		if (matrix_1 == null)
		{
			method_27();
		}
		return matrix_1;
	}

	internal void method_27()
	{
		matrix_1 = new Matrix();
		switch (enum154_0)
		{
		default:
			throw new InvalidOperationException("Unknown mapping mode.");
		case Enum154.const_0:
			break;
		case Enum154.const_1:
			matrix_1.Scale(0.28346458f, -0.28346458f);
			break;
		case Enum154.const_2:
			matrix_1.Scale(0.028346457f, -0.028346457f);
			break;
		case Enum154.const_3:
			matrix_1.Scale(0.71999997f, -0.71999997f);
			break;
		case Enum154.const_4:
			matrix_1.Scale(0.072000004f, -0.072000004f);
			break;
		case Enum154.const_5:
			matrix_1.Scale(0.05f, -0.05f);
			break;
		case Enum154.const_6:
			method_28();
			if (bool_0)
			{
				SizeF sizeF = smethod_0(rectangleF_0.Size);
				float num = sizeF_0.Width / sizeF.Width;
				float num2 = sizeF_0.Height / sizeF.Height;
				matrix_1.Translate((0f - method_12().X) * num + class1416_0.method_6().X, (0f - method_12().Y) * num2 + class1416_0.method_6().Y);
				matrix_1.Scale(num, num2);
			}
			else
			{
				matrix_1.Scale(0.28346458f, -0.28346458f);
			}
			break;
		case Enum154.const_7:
		{
			method_28();
			float num = Math.Max(class1416_0.method_6().Width, 1f) / rectangleF_0.Width;
			float num2 = Math.Max(class1416_0.method_6().Height, 1f) / rectangleF_0.Height;
			matrix_1.Translate((0f - method_12().X) * num + class1416_0.method_6().X, (0f - method_12().Y) * num2 + class1416_0.method_6().Y);
			matrix_1.Scale(num, num2);
			break;
		}
		}
	}

	private void method_28()
	{
		if (rectangleF_0.Width == 0f)
		{
			rectangleF_0.Width = 1f;
		}
		if (rectangleF_0.Height == 0f)
		{
			rectangleF_0.Height = 1f;
		}
		if (class1416_0.method_6().Height == 0f)
		{
			class1416_0.method_7(new RectangleF(class1416_0.method_6().Location, new SizeF(class1416_0.method_6().Width, 1f)));
		}
	}

	[SpecialName]
	internal Matrix method_29()
	{
		Matrix matrix = method_26().Clone();
		matrix.Multiply(matrix_0);
		return matrix;
	}

	internal void method_30(Matrix matrix_2)
	{
		matrix_0 = matrix_2;
	}

	internal void method_31(Matrix matrix_2, Enum163 enum163_0)
	{
		switch (enum163_0)
		{
		case Enum163.const_0:
			matrix_0 = new Matrix();
			break;
		case Enum163.const_1:
			matrix_0.Multiply(matrix_2, MatrixOrder.Prepend);
			break;
		case Enum163.const_2:
			matrix_0.Multiply(matrix_2, MatrixOrder.Append);
			break;
		case Enum163.const_3:
			method_30(matrix_2);
			break;
		}
	}

	private static SizeF smethod_0(SizeF sizeF_1)
	{
		float num = Math.Abs(sizeF_1.Width);
		float num2 = Math.Abs(sizeF_1.Height);
		float num3 = ((num < num2) ? num : num2);
		num = (float)Math.Sign(sizeF_1.Width) * num3;
		num2 = (float)Math.Sign(sizeF_1.Height) * num3;
		return new SizeF(num, num2);
	}
}
