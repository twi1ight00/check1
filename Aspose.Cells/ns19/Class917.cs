using System.Drawing;

namespace ns19;

internal class Class917
{
	protected Interface41 interface41_0;

	protected Interface41 interface41_1;

	protected Interface41 interface41_2;

	protected Interface41 interface41_3;

	protected Point point_0;

	protected Color color_0;

	protected Bitmap bitmap_0;

	protected bool bool_0;

	protected bool bool_1;

	protected bool bool_2;

	protected int int_0;

	protected bool bool_3;

	public Class917()
	{
		interface41_0 = null;
		interface41_1 = null;
		interface41_2 = null;
		bitmap_0 = null;
		color_0 = Color.FromArgb(0, 0, 0);
		bool_0 = false;
		bool_1 = false;
		int_0 = 2;
	}

	public void vmethod_0(Color color_1, Color color_2, int int_1)
	{
		Class921 @class = new Class921();
		@class.method_0(color_1, color_2, int_1);
		interface41_0 = @class;
		Class918 class2 = new Class918();
		class2.method_0(color_1, color_2, int_1);
		interface41_3 = class2;
	}

	public void vmethod_1(Brush brush_0, Color color_1, int int_1)
	{
		Class921 @class = new Class921();
		@class.method_1(brush_0, color_1, int_1);
		interface41_0 = @class;
		Class918 class2 = new Class918();
		class2.method_1(brush_0, color_1, int_1);
		interface41_3 = class2;
	}

	public void vmethod_2()
	{
		interface41_2 = null;
		interface41_1 = null;
	}

	public void vmethod_3(bool bool_4)
	{
		bool_0 = bool_4;
	}

	public void method_0(Color color_1, int int_1, Point point_1)
	{
		Class915 @class = new Class915();
		@class.method_0(Color.FromArgb(0, 0, 0, 0), color_1, int_1, point_1.X, point_1.Y);
		color_0 = color_1;
		Class915 class2 = new Class915();
		class2.method_0(Color.FromArgb(color_1.A, 255, 255), Color.FromArgb(0, 0, 0, 0), 0, point_1.X, point_1.Y);
		interface41_2 = class2;
		point_0 = point_1;
		interface41_1 = @class;
		bool_3 = true;
		bool_1 = false;
		int_0 = int_1;
	}

	public bool vmethod_4(Interface42 interface42_0, FontFamily fontFamily_0, FontStyle fontStyle_0, int int_1, string string_0, Point point_1, StringFormat stringFormat_0)
	{
		if (bool_0 && interface41_1 != null)
		{
			interface41_1.imethod_0(interface42_0, fontFamily_0, fontStyle_0, int_1, string_0, new Point(point_1.X + point_0.X, point_1.Y + point_0.Y), stringFormat_0);
		}
		if (bool_2)
		{
			interface41_3.imethod_0(interface42_0, fontFamily_0, fontStyle_0, int_1, string_0, new Point(point_1.X + point_0.X, point_1.Y + point_0.Y), stringFormat_0);
		}
		if (interface41_0 != null)
		{
			return interface41_0.imethod_0(interface42_0, fontFamily_0, fontStyle_0, int_1, string_0, point_1, stringFormat_0);
		}
		return false;
	}

	public bool vmethod_5(Interface42 interface42_0, FontFamily fontFamily_0, FontStyle fontStyle_0, int int_1, string string_0, Point point_1, StringFormat stringFormat_0, ref float float_0, ref float float_1)
	{
		float float_2 = 0f;
		float float_3 = 0f;
		if (!interface41_0.imethod_1(interface42_0, fontFamily_0, fontStyle_0, int_1, string_0, point_1, stringFormat_0, ref float_2, ref float_3))
		{
			return false;
		}
		float float_4 = 0f;
		float float_5 = 0f;
		if (bool_0)
		{
			if (!interface41_1.imethod_1(interface42_0, fontFamily_0, fontStyle_0, int_1, string_0, point_1, stringFormat_0, ref float_4, ref float_5))
			{
				return false;
			}
			float float_6 = 0f;
			float float_7 = 0f;
			if (Class916.smethod_1(interface42_0, point_0.X, point_0.Y, ref float_6, ref float_7))
			{
				float_4 += float_6;
				float_5 += float_7;
			}
		}
		if (!(float_2 > float_4) && float_3 <= float_5)
		{
			float_0 = float_4;
			float_1 = float_5;
		}
		else
		{
			float_0 = float_2;
			float_1 = float_3;
		}
		return true;
	}
}
