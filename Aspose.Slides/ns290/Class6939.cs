using System.Drawing;
using ns301;

namespace ns290;

internal class Class6939
{
	private readonly Interface351 interface351_0;

	public Class6939(Interface351 boxInfo)
	{
		Class6892.smethod_0(boxInfo, "boxInfo");
		interface351_0 = boxInfo;
	}

	public float method_0(Class6845 box, SizeF parentSize)
	{
		Class6892.smethod_0(box, "box");
		float num;
		if (!box.Style.Width.IsAuto)
		{
			num = Class6969.smethod_9(box.Style.Width, parentSize.Width);
		}
		else if (!box.Style.Left.IsAuto && !box.Style.Right.IsAuto)
		{
			num = parentSize.Width - Class6969.smethod_9(box.Style.Left, parentSize.Width) - Class6969.smethod_9(box.Style.Right, parentSize.Width) - interface351_0.imethod_16(box) - interface351_0.imethod_15(box);
		}
		else
		{
			float num2 = box.Location.X;
			if (!box.Style.Left.IsAuto)
			{
				num2 = Class6969.smethod_9(box.Style.Left, parentSize.Width);
			}
			else if (!box.Style.Right.IsAuto)
			{
				num2 = Class6969.smethod_9(box.Style.Right, parentSize.Width);
			}
			float num3 = parentSize.Width - num2 - interface351_0.imethod_16(box) - interface351_0.imethod_15(box);
			num = interface351_0.imethod_11(box);
			if (num > num3)
			{
				num = num3;
			}
		}
		return num;
	}

	public static float smethod_0(Class6845 box, SizeF parentSize)
	{
		Class6892.smethod_0(box, "box");
		float result = box.Location.X;
		if (!box.Style.Left.IsAuto)
		{
			result = Class6969.smethod_9(box.Style.Left, parentSize.Width);
		}
		else if (!box.Style.Right.IsAuto)
		{
			result = parentSize.Width - box.OuterBound.Width - Class6969.smethod_9(box.Style.Right, parentSize.Width);
		}
		return result;
	}

	public float method_1(Class6845 box, SizeF parentSize)
	{
		Class6892.smethod_0(box, "box");
		float num = box.Size.Height;
		if (!box.Style.Height.IsAuto)
		{
			num = Class6969.smethod_9(box.Style.Height, parentSize.Height);
		}
		else if (!box.Style.Top.IsAuto && !box.Style.Bottom.IsAuto)
		{
			num = parentSize.Height - Class6969.smethod_9(box.Style.Top, parentSize.Height) - Class6969.smethod_9(box.Style.Bottom, parentSize.Height) - interface351_0.imethod_18(box) - interface351_0.imethod_17(box);
		}
		else
		{
			float num2 = box.Location.Y;
			if (!box.Style.Top.IsAuto)
			{
				num2 = Class6969.smethod_9(box.Style.Top, parentSize.Height);
			}
			else if (!box.Style.Bottom.IsAuto)
			{
				num2 = Class6969.smethod_9(box.Style.Bottom, parentSize.Height);
			}
			float num3 = parentSize.Height - num2 - interface351_0.imethod_18(box) - interface351_0.imethod_17(box);
			if (num > num3)
			{
				num = num3;
			}
		}
		return num;
	}

	public static float smethod_1(Class6845 box, SizeF parentSize)
	{
		Class6892.smethod_0(box, "box");
		float result = box.Location.Y;
		if (!box.Style.Top.IsAuto)
		{
			result = Class6969.smethod_9(box.Style.Top, parentSize.Height);
		}
		else if (!box.Style.Bottom.IsAuto)
		{
			result = parentSize.Height - box.OuterBound.Height - Class6969.smethod_9(box.Style.Bottom, parentSize.Height);
		}
		return result;
	}
}
