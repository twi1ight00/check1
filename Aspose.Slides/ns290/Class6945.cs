using System.Collections;
using System.Drawing;
using ns284;
using ns301;

namespace ns290;

internal class Class6945 : Interface353
{
	private PointF pointF_0;

	private readonly Stack stack_0;

	public Class6945()
	{
		stack_0 = new Stack();
		Reset();
	}

	public void Reset()
	{
		pointF_0 = new PointF(0f, 0f);
	}

	public void imethod_0(Class6844 box)
	{
		stack_0.Push(pointF_0);
		if (box.Style.Position == Enum956.const_3)
		{
			float num = pointF_0.X;
			float num2 = pointF_0.Y;
			if (!box.Style.Left.IsAuto && box.Style.Direction == Enum936.const_0)
			{
				num += Class6969.smethod_9(box.Style.Left, box.Parent.InnerBound.Width);
			}
			else if (!box.Style.Left.IsAuto && box.Style.Direction == Enum936.const_1)
			{
				num -= Class6969.smethod_9(box.Style.Left, box.Parent.InnerBound.Width);
				if (num < 0f)
				{
					num = 0f;
				}
			}
			if (!box.Style.Right.IsAuto && box.Style.Left.IsAuto && box.Style.Direction == Enum936.const_0)
			{
				num -= Class6969.smethod_9(box.Style.Right, box.Parent.InnerBound.Width);
			}
			else if (!box.Style.Right.IsAuto && box.Style.Left.IsAuto && box.Style.Direction == Enum936.const_1)
			{
				num += Class6969.smethod_9(box.Style.Right, box.Parent.InnerBound.Width);
			}
			if (!box.Style.Top.IsAuto)
			{
				num2 += Class6969.smethod_9(box.Style.Top, box.Parent.InnerBound.Height);
			}
			if (!box.Style.Bottom.IsAuto && box.Style.Top.IsAuto)
			{
				num2 -= Class6969.smethod_9(box.Style.Bottom, box.Parent.InnerBound.Height);
			}
			pointF_0 = new PointF(num, num2);
		}
		if (box.Style.Position == Enum956.const_1)
		{
			float num3 = pointF_0.X;
			float y = pointF_0.Y;
			if (!box.Style.Right.IsAuto && box.Style.Left.IsAuto)
			{
				num3 += box.Parent.InnerBound.Width - box.InnerBound.Width - Class6969.smethod_9(box.Style.Right, box.Parent.InnerBound.Width);
			}
			if (box.Style.Right.IsAuto && !box.Style.Left.IsAuto)
			{
				num3 += Class6969.smethod_9(box.Style.Right, box.Parent.InnerBound.Width);
			}
			pointF_0 = new PointF(num3, y);
		}
	}

	public void imethod_1(Class6844 container)
	{
		Class6892.smethod_0(container, "container");
		stack_0.Push(pointF_0);
		pointF_0 = container.InnerBound.Location + new SizeF(pointF_0.X, pointF_0.Y);
	}

	public PointF imethod_3()
	{
		return pointF_0;
	}

	public void imethod_4()
	{
		if (stack_0.Count > 0)
		{
			pointF_0 = (PointF)stack_0.Pop();
		}
	}

	public void imethod_2(Class6844 box)
	{
		Class6892.smethod_0(box, "box");
		float x = pointF_0.X;
		float num = pointF_0.Y - Class6969.smethod_10(box.Style.MarginTop) - Class6969.smethod_10(box.Style.PaddingTop);
		if (box.Style.BorderStyleTop != 0)
		{
			num -= box.Style.BorderWidthTop.Value;
		}
		PointF pointF = box.InnerBound.Location + new SizeF(x, num);
		PointF pointF2 = new PointF(pointF.X, pointF.Y + box.float_2 / 2f);
		stack_0.Push(pointF_0);
		pointF_0 = pointF2;
	}
}
