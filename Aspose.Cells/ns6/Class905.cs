using System.Drawing;
using System.Drawing.Drawing2D;

namespace ns6;

internal class Class905
{
	private Color color_0;

	private Color color_1;

	private Enum124 enum124_0;

	private Enum123 enum123_0;

	private ColorBlend colorBlend_0;

	private int int_0;

	private float float_0;

	private float float_1;

	private bool bool_0;

	public Brush method_0(RectangleF rectangleF_0, bool bool_1)
	{
		if (!(rectangleF_0.Width <= 0f) && rectangleF_0.Height > 0f)
		{
			Color color = color_0;
			Color color2 = color_1;
			if (bool_1)
			{
				color = color_1;
				color2 = color_0;
			}
			LinearGradientBrush linearGradientBrush = null;
			if (bool_0)
			{
				linearGradientBrush = new LinearGradientBrush(rectangleF_0, color, color2, int_0, isAngleScaleable: false);
				linearGradientBrush.WrapMode = WrapMode.TileFlipXY;
				linearGradientBrush.SetSigmaBellShape(float_0, float_1);
			}
			else
			{
				switch (enum124_0)
				{
				case Enum124.const_0:
					switch (enum123_0)
					{
					case Enum123.const_0:
						linearGradientBrush = new LinearGradientBrush(rectangleF_0, color2, color, -45f, isAngleScaleable: true);
						linearGradientBrush.WrapMode = WrapMode.TileFlipXY;
						linearGradientBrush.SetSigmaBellShape(1f, 1f);
						break;
					case Enum123.const_1:
						linearGradientBrush = new LinearGradientBrush(rectangleF_0, color, color2, -45f, isAngleScaleable: true);
						linearGradientBrush.WrapMode = WrapMode.TileFlipXY;
						linearGradientBrush.SetSigmaBellShape(1f, 1f);
						break;
					case Enum123.const_2:
						linearGradientBrush = new LinearGradientBrush(rectangleF_0, color2, color, -45f, isAngleScaleable: true);
						linearGradientBrush.WrapMode = WrapMode.TileFlipXY;
						linearGradientBrush.SetSigmaBellShape(0.5f, 1f);
						break;
					case Enum123.const_3:
						linearGradientBrush = new LinearGradientBrush(rectangleF_0, color, color2, -45f, isAngleScaleable: true);
						linearGradientBrush.WrapMode = WrapMode.TileFlipXY;
						linearGradientBrush.SetSigmaBellShape(0.5f, 1f);
						break;
					}
					break;
				case Enum124.const_1:
					switch (enum123_0)
					{
					case Enum123.const_0:
						linearGradientBrush = new LinearGradientBrush(rectangleF_0, color, color2, 45f, isAngleScaleable: true);
						linearGradientBrush.WrapMode = WrapMode.TileFlipXY;
						linearGradientBrush.SetSigmaBellShape(1f, 1f);
						break;
					case Enum123.const_1:
						linearGradientBrush = new LinearGradientBrush(rectangleF_0, color2, color, 45f, isAngleScaleable: true);
						linearGradientBrush.WrapMode = WrapMode.TileFlipXY;
						linearGradientBrush.SetSigmaBellShape(1f, 1f);
						break;
					case Enum123.const_2:
						linearGradientBrush = new LinearGradientBrush(rectangleF_0, color, color2, 45f, isAngleScaleable: true);
						linearGradientBrush.WrapMode = WrapMode.TileFlipXY;
						linearGradientBrush.SetSigmaBellShape(0.5f, 1f);
						break;
					case Enum123.const_3:
						linearGradientBrush = new LinearGradientBrush(rectangleF_0, color2, color, 45f, isAngleScaleable: true);
						linearGradientBrush.WrapMode = WrapMode.TileFlipXY;
						linearGradientBrush.SetSigmaBellShape(0.5f, 1f);
						break;
					}
					break;
				case Enum124.const_4:
					switch (enum123_0)
					{
					case Enum123.const_0:
						linearGradientBrush = new LinearGradientBrush(rectangleF_0, color, color2, 90f, isAngleScaleable: true);
						linearGradientBrush.WrapMode = WrapMode.TileFlipXY;
						linearGradientBrush.SetSigmaBellShape(1f, 1f);
						break;
					case Enum123.const_1:
						linearGradientBrush = new LinearGradientBrush(rectangleF_0, color2, color, 90f, isAngleScaleable: true);
						linearGradientBrush.WrapMode = WrapMode.TileFlipXY;
						linearGradientBrush.SetSigmaBellShape(1f, 1f);
						break;
					case Enum123.const_2:
						linearGradientBrush = new LinearGradientBrush(rectangleF_0, color, color2, 90f, isAngleScaleable: true);
						linearGradientBrush.WrapMode = WrapMode.TileFlipXY;
						linearGradientBrush.SetSigmaBellShape(0.5f, 1f);
						break;
					case Enum123.const_3:
						linearGradientBrush = new LinearGradientBrush(rectangleF_0, color2, color, 90f, isAngleScaleable: true);
						linearGradientBrush.WrapMode = WrapMode.TileFlipXY;
						linearGradientBrush.SetSigmaBellShape(0.5f, 1f);
						break;
					}
					break;
				case Enum124.const_5:
					switch (enum123_0)
					{
					case Enum123.const_0:
						linearGradientBrush = new LinearGradientBrush(rectangleF_0, color, color2, 0f, isAngleScaleable: true);
						linearGradientBrush.WrapMode = WrapMode.TileFlipXY;
						linearGradientBrush.SetSigmaBellShape(1f, 1f);
						break;
					case Enum123.const_1:
						linearGradientBrush = new LinearGradientBrush(rectangleF_0, color2, color, 0f, isAngleScaleable: true);
						linearGradientBrush.WrapMode = WrapMode.TileFlipXY;
						linearGradientBrush.SetSigmaBellShape(1f, 1f);
						break;
					case Enum123.const_2:
						linearGradientBrush = new LinearGradientBrush(rectangleF_0, color, color2, 0f, isAngleScaleable: true);
						linearGradientBrush.WrapMode = WrapMode.TileFlipXY;
						linearGradientBrush.SetSigmaBellShape(0.5f, 1f);
						break;
					case Enum123.const_3:
						linearGradientBrush = new LinearGradientBrush(rectangleF_0, color2, color, 0f, isAngleScaleable: true);
						linearGradientBrush.WrapMode = WrapMode.TileFlipXY;
						linearGradientBrush.SetSigmaBellShape(0.5f, 1f);
						break;
					}
					break;
				}
			}
			if (linearGradientBrush != null)
			{
				if (colorBlend_0 != null)
				{
					linearGradientBrush.InterpolationColors = colorBlend_0;
				}
				return linearGradientBrush;
			}
			return new SolidBrush(color);
		}
		return new SolidBrush(Color.White);
	}
}
