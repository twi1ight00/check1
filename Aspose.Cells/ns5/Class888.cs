using System.Drawing;
using System.Drawing.Drawing2D;

namespace ns5;

internal class Class888
{
	private Color color_0;

	private Color color_1;

	private Enum110 enum110_0;

	private Enum109 enum109_0;

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
			if (bool_0)
			{
				LinearGradientBrush linearGradientBrush = null;
				linearGradientBrush = new LinearGradientBrush(rectangleF_0, color, color2, int_0, isAngleScaleable: false);
				linearGradientBrush.WrapMode = WrapMode.TileFlipXY;
				linearGradientBrush.SetSigmaBellShape(float_0, float_1);
				return linearGradientBrush;
			}
			if (enum110_0 != 0 && enum110_0 != Enum110.const_1 && enum110_0 != Enum110.const_4 && enum110_0 != Enum110.const_5)
			{
				if (enum110_0 == Enum110.const_2)
				{
					if (enum109_0 == Enum109.const_1)
					{
						Color color3 = color2;
						color2 = color;
						color = color3;
					}
					GraphicsPath graphicsPath = new GraphicsPath();
					graphicsPath.AddRectangle(rectangleF_0);
					PointF[] pathPoints = graphicsPath.PathPoints;
					PathGradientBrush pathGradientBrush = new PathGradientBrush(pathPoints);
					pathGradientBrush.CenterColor = color;
					Color[] surroundColors = new Color[1] { color2 };
					pathGradientBrush.SurroundColors = surroundColors;
					return pathGradientBrush;
				}
				if (enum110_0 == Enum110.const_3)
				{
					switch (enum109_0)
					{
					case Enum109.const_0:
						rectangleF_0.X -= rectangleF_0.Width;
						rectangleF_0.Y -= rectangleF_0.Height;
						rectangleF_0.Width *= 2f;
						rectangleF_0.Height *= 2f;
						break;
					case Enum109.const_1:
						rectangleF_0.Y -= rectangleF_0.Height;
						rectangleF_0.Width *= 2f;
						rectangleF_0.Height *= 2f;
						break;
					case Enum109.const_2:
						rectangleF_0.X -= rectangleF_0.Width;
						rectangleF_0.Width *= 2f;
						rectangleF_0.Height *= 2f;
						break;
					case Enum109.const_3:
						rectangleF_0.Width *= 2f;
						rectangleF_0.Height *= 2f;
						break;
					}
					GraphicsPath graphicsPath2 = new GraphicsPath();
					graphicsPath2.AddRectangle(rectangleF_0);
					PointF[] pathPoints2 = graphicsPath2.PathPoints;
					PathGradientBrush pathGradientBrush2 = new PathGradientBrush(pathPoints2);
					pathGradientBrush2.CenterColor = color;
					Color[] surroundColors2 = new Color[1] { color2 };
					pathGradientBrush2.SurroundColors = surroundColors2;
					return pathGradientBrush2;
				}
				return new SolidBrush(color);
			}
			LinearGradientBrush linearGradientBrush2 = null;
			switch (enum110_0)
			{
			case Enum110.const_0:
				switch (enum109_0)
				{
				case Enum109.const_0:
					linearGradientBrush2 = new LinearGradientBrush(rectangleF_0, color2, color, -45f, isAngleScaleable: true);
					linearGradientBrush2.WrapMode = WrapMode.TileFlipXY;
					linearGradientBrush2.SetSigmaBellShape(1f, 1f);
					break;
				case Enum109.const_1:
					linearGradientBrush2 = new LinearGradientBrush(rectangleF_0, color, color2, -45f, isAngleScaleable: true);
					linearGradientBrush2.WrapMode = WrapMode.TileFlipXY;
					linearGradientBrush2.SetSigmaBellShape(1f, 1f);
					break;
				case Enum109.const_2:
					linearGradientBrush2 = new LinearGradientBrush(rectangleF_0, color2, color, -45f, isAngleScaleable: true);
					linearGradientBrush2.WrapMode = WrapMode.TileFlipXY;
					linearGradientBrush2.SetSigmaBellShape(0.5f, 1f);
					break;
				case Enum109.const_3:
					linearGradientBrush2 = new LinearGradientBrush(rectangleF_0, color, color2, -45f, isAngleScaleable: true);
					linearGradientBrush2.WrapMode = WrapMode.TileFlipXY;
					linearGradientBrush2.SetSigmaBellShape(0.5f, 1f);
					break;
				}
				break;
			case Enum110.const_1:
				switch (enum109_0)
				{
				case Enum109.const_0:
					linearGradientBrush2 = new LinearGradientBrush(rectangleF_0, color, color2, 45f, isAngleScaleable: true);
					linearGradientBrush2.WrapMode = WrapMode.TileFlipXY;
					linearGradientBrush2.SetSigmaBellShape(1f, 1f);
					break;
				case Enum109.const_1:
					linearGradientBrush2 = new LinearGradientBrush(rectangleF_0, color2, color, 45f, isAngleScaleable: true);
					linearGradientBrush2.WrapMode = WrapMode.TileFlipXY;
					linearGradientBrush2.SetSigmaBellShape(1f, 1f);
					break;
				case Enum109.const_2:
					linearGradientBrush2 = new LinearGradientBrush(rectangleF_0, color, color2, 45f, isAngleScaleable: true);
					linearGradientBrush2.WrapMode = WrapMode.TileFlipXY;
					linearGradientBrush2.SetSigmaBellShape(0.5f, 1f);
					break;
				case Enum109.const_3:
					linearGradientBrush2 = new LinearGradientBrush(rectangleF_0, color2, color, 45f, isAngleScaleable: true);
					linearGradientBrush2.WrapMode = WrapMode.TileFlipXY;
					linearGradientBrush2.SetSigmaBellShape(0.5f, 1f);
					break;
				}
				break;
			case Enum110.const_4:
				switch (enum109_0)
				{
				case Enum109.const_0:
					linearGradientBrush2 = new LinearGradientBrush(rectangleF_0, color, color2, 90f, isAngleScaleable: true);
					linearGradientBrush2.WrapMode = WrapMode.TileFlipXY;
					linearGradientBrush2.SetSigmaBellShape(1f, 1f);
					break;
				case Enum109.const_1:
					linearGradientBrush2 = new LinearGradientBrush(rectangleF_0, color2, color, 90f, isAngleScaleable: true);
					linearGradientBrush2.WrapMode = WrapMode.TileFlipXY;
					linearGradientBrush2.SetSigmaBellShape(1f, 1f);
					break;
				case Enum109.const_2:
					linearGradientBrush2 = new LinearGradientBrush(rectangleF_0, color, color2, 90f, isAngleScaleable: true);
					linearGradientBrush2.WrapMode = WrapMode.TileFlipXY;
					linearGradientBrush2.SetSigmaBellShape(0.5f, 1f);
					break;
				case Enum109.const_3:
					linearGradientBrush2 = new LinearGradientBrush(rectangleF_0, color2, color, 90f, isAngleScaleable: true);
					linearGradientBrush2.WrapMode = WrapMode.TileFlipXY;
					linearGradientBrush2.SetSigmaBellShape(0.5f, 1f);
					break;
				}
				break;
			case Enum110.const_5:
				switch (enum109_0)
				{
				case Enum109.const_0:
					linearGradientBrush2 = new LinearGradientBrush(rectangleF_0, color, color2, 0f, isAngleScaleable: true);
					linearGradientBrush2.WrapMode = WrapMode.TileFlipXY;
					linearGradientBrush2.SetSigmaBellShape(1f, 1f);
					break;
				case Enum109.const_1:
					linearGradientBrush2 = new LinearGradientBrush(rectangleF_0, color2, color, 0f, isAngleScaleable: true);
					linearGradientBrush2.WrapMode = WrapMode.TileFlipXY;
					linearGradientBrush2.SetSigmaBellShape(1f, 1f);
					break;
				case Enum109.const_2:
					linearGradientBrush2 = new LinearGradientBrush(rectangleF_0, color, color2, 0f, isAngleScaleable: true);
					linearGradientBrush2.SetSigmaBellShape(0.5f, 1f);
					break;
				case Enum109.const_3:
					linearGradientBrush2 = new LinearGradientBrush(rectangleF_0, color2, color, 0f, isAngleScaleable: true);
					linearGradientBrush2.WrapMode = WrapMode.TileFlipXY;
					linearGradientBrush2.SetSigmaBellShape(0.5f, 1f);
					break;
				}
				break;
			}
			if (linearGradientBrush2 != null)
			{
				if (colorBlend_0 != null)
				{
					linearGradientBrush2.InterpolationColors = colorBlend_0;
				}
				return linearGradientBrush2;
			}
			return new SolidBrush(color);
		}
		return new SolidBrush(Color.White);
	}
}
