using System.Drawing;

namespace ns18;

internal class Class461 : Class452
{
	internal RectangleF rectangleF_0;

	internal int int_0;

	internal int int_1 = -1;

	internal Class461(float float_0, float float_1, float float_2, float float_3)
	{
		rectangleF_0.X = float_0;
		rectangleF_0.Y = float_1;
		rectangleF_0.Width = float_2;
		rectangleF_0.Height = float_3;
	}

	internal Class461(RectangleF rectangleF_1)
	{
		rectangleF_0 = rectangleF_1;
	}

	public bool method_1(Class461 class461_0)
	{
		RectangleF rectangleF = class461_0.rectangleF_0;
		if (rectangleF_0.X >= rectangleF.X && rectangleF_0.Y >= rectangleF.Y && rectangleF_0.Right <= rectangleF.Right && rectangleF_0.Bottom <= rectangleF.Bottom)
		{
			return true;
		}
		return false;
	}

	public int method_2(Class461 class461_0)
	{
		RectangleF rectangleF = class461_0.rectangleF_0;
		RectangleF rectangleF_ = default(RectangleF);
		int num = 0;
		for (int i = 0; (float)i < rectangleF_0.Width / rectangleF.Width + 2f; i++)
		{
			for (int j = 0; (float)j < rectangleF_0.Height / rectangleF.Height + 2f; j++)
			{
				rectangleF_.X = rectangleF.X + rectangleF.Width * (float)i;
				rectangleF_.Y = rectangleF.Y + rectangleF.Height * (float)j;
				rectangleF_.Width = rectangleF.Width;
				rectangleF_.Height = rectangleF.Height;
				if (IsIntersect(rectangleF_, rectangleF_0))
				{
					num++;
				}
				if (rectangleF_.Left > rectangleF_0.Right && !(rectangleF_.Top <= rectangleF_0.Bottom))
				{
					return num;
				}
			}
		}
		return 1;
	}

	private static bool IsIntersect(RectangleF rectangleF_1, RectangleF rectangleF_2)
	{
		RectangleF rectangleF = new RectangleF(rectangleF_1.Location, rectangleF_1.Size);
		rectangleF.Intersect(rectangleF_2);
		if (rectangleF.Size.Height > 1f && rectangleF.Size.Width > 1f)
		{
			return true;
		}
		return false;
	}

	public bool method_3(Class461 class461_0)
	{
		RectangleF rectangleF = new RectangleF(class461_0.rectangleF_0.Location, class461_0.rectangleF_0.Size);
		rectangleF.Intersect(rectangleF_0);
		if (rectangleF.Size.Height > 1f && rectangleF.Size.Width > 1f)
		{
			return true;
		}
		return false;
	}

	public override void vmethod_0(Class468 class468_0)
	{
	}
}
