using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using Aspose.Cells;

namespace ns18;

internal class Class463 : Class452, Interface5
{
	private Class1396 class1396_0;

	private Color color_0;

	private Color color_1;

	private PointF pointF_0;

	private string string_0;

	private Matrix matrix_0;

	private Class458 class458_0;

	private Class464 class464_0;

	private float float_0;

	public bool bool_0;

	public bool bool_1;

	public FontUnderlineType fontUnderlineType_0;

	public virtual string Text
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	public virtual SizeF Size
	{
		get
		{
			SizeF sizeF = Class1396.smethod_0(string_0, class1396_0);
			return new SizeF(sizeF.Width + float_0 * (float)Text.Length, sizeF.Height);
		}
	}

	public Color Color
	{
		get
		{
			return color_0;
		}
		set
		{
			color_0 = value;
		}
	}

	public float Bottom => pointF_0.Y + class1396_0.method_2();

	public float Left => pointF_0.X;

	public Class464 Hyperlink => class464_0;

	public Class463()
	{
	}

	public Class463(Class1396 class1396_1, Color color_2, PointF pointF_1, string string_1, bool bool_2, bool bool_3)
		: this(class1396_1, color_2, Color.Empty, pointF_1, string_1)
	{
		bool_1 = bool_3;
		bool_0 = bool_2;
	}

	public Class463(Class1396 class1396_1, Color color_2, PointF pointF_1, float float_1, string string_1)
	{
		class1396_0 = class1396_1;
		color_0 = color_2;
		color_1 = Color.Empty;
		pointF_0 = pointF_1;
		string_0 = string_1;
		float_0 = float_1;
	}

	public Class463(Class1396 class1396_1, Color color_2, Color color_3, PointF pointF_1, string string_1)
	{
		class1396_0 = class1396_1;
		color_0 = color_2;
		color_1 = color_3;
		pointF_0 = pointF_1;
		string_0 = string_1;
	}

	public Class463(Class1396 class1396_1, Color color_2, PointF pointF_1, string string_1)
	{
		class1396_0 = class1396_1;
		color_0 = color_2;
		color_1 = Color.Empty;
		pointF_0 = pointF_1;
		string_0 = string_1;
	}

	public override void vmethod_0(Class468 class468_0)
	{
		class468_0.vmethod_5(this);
		if (fontUnderlineType_0 == FontUnderlineType.None)
		{
			return;
		}
		Class458 @class = null;
		switch (fontUnderlineType_0)
		{
		case FontUnderlineType.Single:
		case FontUnderlineType.Accounting:
			if (!(class468_0 is Class472))
			{
				float num = method_1().method_4().Size / 25.4f;
				if (method_1().IsBold)
				{
					num *= 1.65f;
				}
				@class = Class458.smethod_3(new PointF(Left, Bottom - method_1().method_4().Size / 50.8f), new PointF(Left + Size.Width, Bottom - method_1().method_4().Size / 50.8f));
				@class.class770_0 = new Class770(Color);
				@class.vmethod_1(imethod_0());
				@class.class770_0.float_0 = num;
				@class.vmethod_0(class468_0);
				@class = null;
			}
			break;
		case FontUnderlineType.Double:
		case FontUnderlineType.DoubleAccounting:
		{
			float num = method_1().method_4().Size / 10f;
			if (method_1().IsBold)
			{
				num *= 1.65f;
			}
			@class = Class458.smethod_3(new PointF(Left, Bottom - 0.5f * num), new PointF(Left + Size.Width, Bottom - 0.5f * num));
			Class770 class770_ = (@class.class770_0 = new Class770(Color));
			@class.vmethod_1(imethod_0());
			@class.class770_0.float_0 = num;
			@class.vmethod_0(class468_0);
			@class = Class458.smethod_3(new PointF(Left, Bottom + 0.5f * num), new PointF(Left + Size.Width, Bottom + 0.5f * num));
			@class.vmethod_1(imethod_0());
			@class.class770_0 = class770_;
			@class.class770_0.float_0 = num;
			@class.vmethod_0(class468_0);
			break;
		}
		}
	}

	[SpecialName]
	public Class1396 method_1()
	{
		return class1396_0;
	}

	[SpecialName]
	public void method_2(Class1396 class1396_1)
	{
		class1396_0 = class1396_1;
	}

	[SpecialName]
	public Color method_3()
	{
		return color_1;
	}

	[SpecialName]
	public PointF method_4()
	{
		return pointF_0;
	}

	[SpecialName]
	public void method_5(PointF pointF_1)
	{
		pointF_0 = pointF_1;
	}

	[SpecialName]
	public Matrix imethod_0()
	{
		return matrix_0;
	}

	[SpecialName]
	public void vmethod_1(Matrix matrix_1)
	{
		matrix_0 = matrix_1;
	}

	[SpecialName]
	public Class458 imethod_1()
	{
		return class458_0;
	}

	[SpecialName]
	public bool imethod_2()
	{
		return false;
	}

	[SpecialName]
	public float method_6()
	{
		return float_0;
	}

	[SpecialName]
	public void method_7(float float_1)
	{
		float_0 = float_1;
	}
}
