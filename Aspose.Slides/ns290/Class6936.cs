using System;
using System.Drawing;
using System.Globalization;
using ns284;
using ns301;

namespace ns290;

internal class Class6936 : Interface348
{
	private readonly Interface351 interface351_0;

	public Class6936()
	{
		interface351_0 = new Class6942();
	}

	public float imethod_0(Class6844 box, Class6845 container)
	{
		Class6892.smethod_0(box, "box");
		Class6892.smethod_0(container, "container");
		return box.Style.Align switch
		{
			Enum948.const_1 => (container.InnerBound.Width - box.OuterBound.Width) / 2f, 
			Enum948.const_2 => container.InnerBound.Width - box.OuterBound.Width, 
			_ => 0f, 
		};
	}

	public float imethod_1(Class6850 line, Class6845 container, bool isFirstLine, bool isLastLine)
	{
		float num = 0f;
		if (isFirstLine && container.Style.TextIndent.Value != 0f)
		{
			Class6845 @class = interface351_0.imethod_3(container);
			float num2 = Class6969.smethod_9(container.Style.TextIndent, @class.InnerBound.Width);
			num = num2;
		}
		switch (container.Style.TextAlign)
		{
		default:
			throw new ArgumentOutOfRangeException(string.Format(CultureInfo.InvariantCulture, "The container.Style.TextAlign is out of range: {0}", new object[1] { container.Style.TextAlign }));
		case Enum957.const_1:
		case Enum957.const_2:
			num = (container.InnerBound.Width - line.Size.Width) / 2f;
			break;
		case Enum957.const_3:
		{
			float num3 = container.InnerBound.Width - num - line.Size.Width;
			int num4 = smethod_3(line);
			float dSpace = num3 / (float)num4;
			if (!isLastLine || !(num3 / container.InnerBound.Width * 100f > 30f))
			{
				smethod_0(line, dSpace);
			}
			break;
		}
		case Enum957.const_4:
			num = container.InnerBound.Width - line.Size.Width;
			break;
		case Enum957.const_0:
			break;
		}
		return num;
	}

	private static void smethod_0(Class6845 container, float dSpace)
	{
		if (dSpace <= 0f)
		{
			return;
		}
		int num = smethod_3(container);
		if (num == 0)
		{
			return;
		}
		float dWidth = (float)num * dSpace;
		smethod_2(container, dWidth);
		int num2 = 0;
		for (int i = 0; i < container.InnerBoxes.Count; i++)
		{
			Class6844 @class = container.InnerBoxes[i];
			smethod_1(@class, (float)num2 * dSpace);
			Class6855 class2 = @class as Class6855;
			Class6845 class3 = @class as Class6845;
			if (class2 != null && class2.IsSpaceBox)
			{
				smethod_2(@class, dSpace);
				num2++;
			}
			else if (class3 != null)
			{
				smethod_0(class3, dSpace);
			}
		}
	}

	private static void smethod_1(Class6844 box, float delta)
	{
		box.Location = new PointF(box.Location.X + delta, box.Location.Y);
	}

	private static void smethod_2(Class6844 box, float dWidth)
	{
		box.Size = new SizeF(box.Size.Width + dWidth, box.Size.Height);
	}

	private static int smethod_3(Class6845 container)
	{
		int num = 0;
		for (int i = 0; i < container.InnerBoxes.Count; i++)
		{
			Class6844 @class = container.InnerBoxes[i];
			if (@class is Class6845 container2)
			{
				num += smethod_3(container2);
			}
			if (@class is Class6855 class2 && class2.IsSpaceBox)
			{
				num++;
			}
		}
		return num;
	}
}
