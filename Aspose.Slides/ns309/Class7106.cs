using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;

namespace ns309;

internal class Class7106
{
	internal PointF pointF_0;

	internal PointF pointF_1;

	internal string string_0;

	public string string_1;

	internal PointF pointF_2;

	internal Class7118 class7118_0;

	internal Class7118 class7118_1;

	public string string_2;

	internal Interface377 interface377_0;

	internal Class7114 class7114_0;

	internal ArrayList arrayList_0;

	internal string string_3;

	internal float float_0;

	internal GraphicsPath graphicsPath_0;

	internal RectangleF rectangleF_0;

	internal float float_1;

	internal int int_0;

	internal Matrix matrix_0;

	public virtual string Unicode => string_1;

	public virtual ArrayList Names => arrayList_0;

	public virtual string Orientation => string_3;

	public virtual int GlyphCode => int_0;

	public virtual Matrix Transformation
	{
		get
		{
			return matrix_0;
		}
		set
		{
			matrix_0 = value;
			graphicsPath_0 = null;
			rectangleF_0 = default(RectangleF);
		}
	}

	public virtual PointF Position
	{
		get
		{
			return pointF_2;
		}
		set
		{
			pointF_2.X = value.X;
			pointF_2.Y = value.Y;
			graphicsPath_0 = null;
			rectangleF_0 = default(RectangleF);
		}
	}

	public virtual string Language => string_0;

	public virtual PointF HorizontalLevel => pointF_0;

	public virtual PointF VerticalLevel => pointF_1;

	public virtual float HorizontalX => float_0;

	public virtual float VerticalY => float_1;

	public Class7106(string unicode, IList names, string orientation, string lang, PointF horizontalLevel, PointF verticalLevel, float horizontalX, float verticalY, int glyphCode, Class7118 paintInfo, string shape, Interface377 childNode)
	{
		pointF_2 = new PointF(0f, 0f);
		graphicsPath_0 = null;
		rectangleF_0 = default(RectangleF);
		string_1 = unicode;
		string_0 = lang;
		pointF_0 = horizontalLevel;
		pointF_1 = verticalLevel;
		float_0 = horizontalX;
		float_1 = verticalY;
		int_0 = glyphCode;
		class7118_0 = paintInfo;
		string_2 = shape;
		interface377_0 = childNode;
		arrayList_0 = new ArrayList(names);
		string_3 = orientation;
		class7118_1 = new Class7118();
	}

	public Class7106(string unicode, float horizX, string shape)
	{
		pointF_2 = new PointF(0f, 0f);
		graphicsPath_0 = null;
		rectangleF_0 = default(RectangleF);
		string_1 = unicode;
		string_0 = string.Empty;
		float_0 = horizX;
		if (unicode.StartsWith("&#x"))
		{
			int_0 = int.Parse(unicode.Replace("&#x", string.Empty).Replace(";", string.Empty), NumberStyles.AllowHexSpecifier);
		}
		string_2 = shape;
		interface377_0 = null;
	}

	public Class7114 method_0(float hkern, float vkern)
	{
		return null;
	}
}
