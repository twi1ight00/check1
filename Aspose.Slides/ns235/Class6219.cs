using System;
using System.Drawing;
using ns224;

namespace ns235;

internal class Class6219 : Class6204, Interface261
{
	private const float float_0 = 0.5f;

	private object object_0;

	private readonly Class5999 class5999_0;

	private Class5998 class5998_0;

	private Class5990 class5990_0;

	private Class5998 class5998_1;

	private Class6003 class6003_0;

	private float float_1;

	private PointF pointF_0 = PointF.Empty;

	private SizeF sizeF_0 = SizeF.Empty;

	private string string_1;

	private Class6002 class6002_0;

	private Class6217 class6217_0;

	private Class6270 class6270_0;

	private readonly float float_2;

	private Class6265 class6265_0;

	public Class5999 Font => class5999_0;

	public Class5998 Color => class5998_0;

	public Class5990 Brush
	{
		get
		{
			return class5990_0;
		}
		set
		{
			class5990_0 = value;
			if (class5990_0 != null)
			{
				class5998_0 = ((class5990_0.BrushType == Enum746.const_0) ? ((Class5997)class5990_0).Color : Class5998.class5998_141);
			}
			else
			{
				class5998_0 = Class5998.class5998_141;
			}
		}
	}

	public Class5998 OutlineColor => class5998_1;

	public Class6003 Outline
	{
		get
		{
			return class6003_0;
		}
		set
		{
			class6003_0 = value;
			if (class6003_0 == null)
			{
				class5998_1 = Class5998.class5998_141;
			}
			else if (class6003_0.Brush != null)
			{
				class5998_1 = ((class6003_0.Brush.BrushType == Enum746.const_0) ? ((Class5997)class6003_0.Brush).Color : Class5998.class5998_141);
			}
		}
	}

	public float OutlineWidth => float_1;

	public PointF Origin
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

	public virtual string Text => string_1;

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

	public PointF Location => new PointF(Left, Top);

	public SizeF Size
	{
		get
		{
			return sizeF_0;
		}
		set
		{
			sizeF_0 = value;
		}
	}

	public float Top => pointF_0.Y - class5999_0.AscentPoints;

	public float Bottom => pointF_0.Y + class5999_0.DescentPoints;

	public float Left => pointF_0.X;

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

	public float CharSpace => float_2;

	public RectangleF Bounds => new RectangleF(Left, Top, Size.Width, Size.Height);

	public object Tag
	{
		get
		{
			return object_0;
		}
		set
		{
			object_0 = value;
		}
	}

	public Class6265 Indices
	{
		get
		{
			return class6265_0;
		}
		set
		{
			class6265_0 = value;
		}
	}

	public Class6219(Class5999 font, Class5998 color, Class5998 outlineColor, PointF origin, string text, SizeF size, float charSpace)
		: this(font, color, outlineColor, 0.5f, origin, text, size, charSpace)
	{
	}

	public Class6219(Class5999 font, Class5990 brush, Class6003 outline, PointF origin, string text, SizeF size, float charSpace)
		: this(font, brush, outline, 0.5f, origin, text, size, charSpace)
	{
	}

	public Class6219(Class5999 font, Class5990 brush, Class6003 outline, float outlineWidth, PointF origin, string text, SizeF size, float charSpace)
	{
		if (font == null)
		{
			throw new ArgumentNullException("font");
		}
		if (text == null)
		{
			throw new ArgumentNullException("text");
		}
		class5999_0 = font;
		Brush = brush;
		Outline = outline;
		float_1 = outlineWidth;
		pointF_0 = origin;
		string_1 = text;
		sizeF_0 = size;
		float_2 = charSpace;
	}

	public Class6219(Class5999 font, Class5998 color, Class5998 outlineColor, float outlineWidth, PointF origin, string text, SizeF size, float charSpace)
		: this(font, new Class5997(color), new Class6003(outlineColor), outlineWidth, origin, text, size, charSpace)
	{
	}

	public override void vmethod_0(Class6176 visitor)
	{
		visitor.vmethod_4(this);
	}

	public void AddText(string text, float width)
	{
		string_1 += text;
		sizeF_0 = new SizeF(sizeF_0.Width + width, sizeF_0.Height);
	}

	public void method_2()
	{
		string_1 = string.Empty;
		sizeF_0 = SizeF.Empty;
	}
}
