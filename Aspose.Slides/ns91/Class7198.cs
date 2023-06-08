using System.Drawing;
using ns235;

namespace ns91;

internal class Class7198
{
	internal class Class7199
	{
		internal float float_0;

		internal float float_1;

		internal float float_2;

		internal float float_3;

		internal bool bool_0;

		internal bool bool_1;

		internal bool bool_2;

		internal float[] float_4;

		public Class7199(float x, float y, float rWidth, float rHeight)
		{
			float_0 = x;
			float_1 = y;
			float_2 = rWidth;
			float_3 = rHeight;
		}
	}

	internal class Class7200
	{
		internal float float_0;

		internal float float_1;

		internal float float_2;

		internal float float_3;

		public Class7200(float left, float bottom, float width, float height)
		{
			float_0 = left;
			float_1 = bottom;
			float_2 = width;
			float_3 = height;
		}
	}

	internal class Class7201
	{
		internal Class6216 class6216_0;
	}

	private static float smethod_0(float centimeter)
	{
		float num;
		using (Graphics graphics = Graphics.FromImage(new Bitmap(10, 10)))
		{
			num = centimeter * graphics.DpiY / 2.54f;
		}
		return num;
	}

	internal static float smethod_1(string cssSize, float fontSize)
	{
		return cssSize switch
		{
			"normal" => 0f, 
			"narrower" => fontSize * 0.05f * -1f, 
			"semi-condensed" => fontSize * 0.1f * -1f, 
			"condensed" => fontSize * 0.2f * -1f, 
			"ultra-condensed" => fontSize * 0.3f * -1f, 
			"extra-condensed" => fontSize * 0.3f * -1f, 
			"wider" => fontSize * 0.05f, 
			"semi-expanded" => fontSize * 0.1f, 
			"expanded" => fontSize * 0.2f, 
			"extra-expanded" => fontSize * 0.3f, 
			"ultra-expanded" => fontSize * 0.4f, 
			_ => 0f, 
		};
	}
}
