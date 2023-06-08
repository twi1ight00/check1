using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns218;
using ns224;
using ns271;

namespace ns235;

internal class Class6217 : Class6212, Interface261
{
	private Class6003 class6003_0;

	private Class5990 class5990_0;

	private Class6217 class6217_0;

	private Class6002 class6002_0;

	private FillMode fillMode_0;

	private Class6270 class6270_0;

	public Class6003 Pen
	{
		get
		{
			return class6003_0;
		}
		set
		{
			class6003_0 = value;
		}
	}

	public Class5990 Brush
	{
		get
		{
			return class5990_0;
		}
		set
		{
			class5990_0 = value;
		}
	}

	public Class6217 Clip
	{
		get
		{
			return class6217_0;
		}
		set
		{
			class6217_0 = value;
		}
	}

	public Class6002 RenderTransform
	{
		get
		{
			return class6002_0;
		}
		set
		{
			class6002_0 = value;
		}
	}

	public FillMode FillMode
	{
		get
		{
			return fillMode_0;
		}
		set
		{
			fillMode_0 = value;
		}
	}

	public bool IsLastFigureClosed
	{
		get
		{
			if (base.Count == 0)
			{
				return false;
			}
			Class6204 @class = base[base.Count - 1];
			if (@class is Class6218 class2)
			{
				return class2.IsClosed;
			}
			if (@class is Class6217 class3)
			{
				return class3.IsLastFigureClosed;
			}
			return false;
		}
	}

	public Class6270 Hyperlink
	{
		get
		{
			return class6270_0;
		}
		set
		{
			class6270_0 = value;
		}
	}

	public Class6217()
	{
	}

	public Class6217(Class6003 pen)
	{
		class6003_0 = pen;
	}

	public override void vmethod_0(Class6176 visitor)
	{
		visitor.vmethod_5(this);
		base.vmethod_0(visitor);
		visitor.vmethod_6(this);
	}

	public static Class6217 smethod_0(PointF[] points, bool isClosed)
	{
		Class6217 @class = new Class6217();
		@class.Add(Class6218.smethod_0(points, isClosed));
		return @class;
	}

	public static Class6217 smethod_1(RectangleF rect)
	{
		Class6217 @class = new Class6217();
		@class.Add(Class6218.smethod_2(rect));
		return @class;
	}

	public static Class6217 smethod_2(RectangleF rect, Class6003 pen)
	{
		Class6217 @class = smethod_1(rect);
		@class.Pen = pen;
		return @class;
	}

	public static Class6217 smethod_3(PointF start, PointF end)
	{
		Class6217 @class = new Class6217();
		@class.Add(Class6218.smethod_1(start, end));
		return @class;
	}

	public static Class6217 smethod_4(PointF pt, Class6003 pen)
	{
		Class6217 @class = smethod_1(new RectangleF(pt.X - 1f, pt.Y - 1f, 2f, 2f));
		@class.Pen = pen;
		return @class;
	}

	public static Class6217 smethod_5(Class6219 glyphs)
	{
		return smethod_7(glyphs.Text, glyphs.Font);
	}

	public static Class6217 smethod_6(string text, Class5999 font, Class5990 brush, Class6003 pen)
	{
		float num = font.SizePoints / 20480f;
		Class6730 trueTypeFont = font.TrueTypeFont;
		Class6733 @class = new Class6733(trueTypeFont, isFullEmbedding: false);
		foreach (char c in text)
		{
			@class.method_0(c);
		}
		Hashtable hashtable = @class.method_3();
		Class6217 class2 = new Class6217();
		float num2 = 0f;
		foreach (char c2 in text)
		{
			if (c2 != ' ')
			{
				int num3 = @class.method_0(c2);
				Class6217 class3 = ((Class6658)hashtable[num3]).method_0();
				class3.Brush = brush;
				class3.Pen = pen;
				class3.RenderTransform = new Class6002();
				class3.RenderTransform.method_5(num, num, MatrixOrder.Prepend);
				class3.RenderTransform.method_7(num2, 20480f, MatrixOrder.Prepend);
				class2.Add(class3);
			}
			num2 += (float)Class5955.smethod_29(trueTypeFont.Glyphs.method_0(c2).AdvanceWidth * 1024 / trueTypeFont.EmHeight);
		}
		class2.Brush = brush;
		class2.Pen = pen;
		return class2;
	}

	public static Class6217 smethod_7(string text, Class5999 font)
	{
		return smethod_6(text, font, null, null);
	}

	public void method_3(Class6002 matrix)
	{
		for (int i = 0; i < base.Count; i++)
		{
			Class6218 @class = (Class6218)base[i];
			@class.method_6(matrix);
		}
	}

	public Class6217 Clone()
	{
		Class6217 @class = new Class6217();
		@class.class6003_0 = class6003_0;
		@class.class5990_0 = class5990_0;
		@class.class6217_0 = class6217_0;
		@class.class6002_0 = class6002_0;
		@class.FillMode = fillMode_0;
		for (int i = 0; i < base.Count; i++)
		{
			Class6218 class2 = (Class6218)base[i];
			@class.Add(class2.Clone());
		}
		return @class;
	}
}
