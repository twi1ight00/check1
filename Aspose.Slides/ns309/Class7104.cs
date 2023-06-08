using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ns309;

internal class Class7104 : Interface375
{
	public const float float_0 = 8f;

	public Hashtable hashtable_0 = new Hashtable();

	public Hashtable hashtable_1 = new Hashtable();

	internal Hashtable hashtable_2 = new Hashtable();

	internal Hashtable hashtable_3 = new Hashtable();

	internal float float_1 = -1f;

	internal float float_2 = -1f;

	public string string_0 = string.Empty;

	public string string_1 = string.Empty;

	internal static readonly IDictionary idictionary_0 = new Hashtable();

	public virtual string FamilyName => string.Empty;

	public virtual float Size => float_1;

	public virtual Interface375 imethod_0(float size)
	{
		return new Class7104();
	}

	public virtual float imethod_2(int glyphFirst, int glyphSecond)
	{
		return 0f;
	}

	public virtual float imethod_1(int glyphFirst, int glyphSecond)
	{
		return 0f;
	}

	public static Class7110.Class7111 smethod_0(Class7104 font, char charCode, Class7117 glyphVector, int index, PointF position)
	{
		Class7110 @class = (Class7110)idictionary_0[0];
		Class7110.Class7111 class2 = null;
		if (@class != null)
		{
			class2 = @class.vmethod_1(charCode);
		}
		if (class2 == null)
		{
			GraphicsPath graphicsPath = glyphVector.imethod_1(index);
			Class7114 class3 = glyphVector.method_1(index);
			if (class3 != null)
			{
				RectangleF bounds = class3.Bounds;
				if (Class7105.smethod_0())
				{
					Matrix matrix = new Matrix();
					matrix.Translate(0f - position.X, 0f - position.Y);
					graphicsPath.Transform(matrix);
				}
				class2 = new Class7110.Class7111(graphicsPath, bounds);
				@class.vmethod_2(charCode, class2);
			}
		}
		return class2;
	}
}
