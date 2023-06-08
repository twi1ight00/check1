using System.Drawing;
using ns235;

namespace ns219;

internal class Class6342
{
	private RectangleF rectangleF_0;

	private Class6213 class6213_0;

	public Class6213 Canvas
	{
		get
		{
			return class6213_0;
		}
		set
		{
			class6213_0 = value;
		}
	}

	public RectangleF BoundingBox
	{
		get
		{
			return rectangleF_0;
		}
		set
		{
			rectangleF_0 = value;
		}
	}

	internal Class6342(Class6213 canvas, RectangleF boundingBox)
	{
		class6213_0 = canvas;
		rectangleF_0 = boundingBox;
	}
}
