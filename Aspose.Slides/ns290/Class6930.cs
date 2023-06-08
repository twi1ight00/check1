using System;
using System.Collections.Generic;
using System.Drawing;
using ns284;
using ns301;

namespace ns290;

internal class Class6930 : Class6927
{
	private readonly Interface348 interface348_0;

	private readonly Interface344 interface344_0;

	private readonly Class6921 class6921_0;

	public Class6930(Interface344 boxFactory, Interface348 aligner)
	{
		Class6892.smethod_0(aligner, "aligner");
		interface344_0 = boxFactory;
		interface348_0 = aligner;
		class6921_0 = new Class6921(base.BoxInfo);
	}

	public override void imethod_0(Class6844 box)
	{
		Class6892.smethod_0(box, "box");
		if (!(box is Class6845 @class))
		{
			throw new ArgumentException("box should be a container");
		}
		method_2(@class.InnerBoxes, @class);
		Class6931 class2 = new Class6931();
		float num = 0f;
		for (int i = 0; i < @class.InnerBoxes.Count; i++)
		{
			Class6850 class3 = (Class6850)@class.InnerBoxes[i];
			class2.imethod_0(class3);
			smethod_1(class3, out var highestEdgeYPos, out var lowestEdgeYPos);
			class3.Style.MarginTop = new Class6959(highestEdgeYPos);
			class3.Style.MarginBottom = new Class6959(lowestEdgeYPos);
			float num2 = class3.Size.Height * box.Style.LineHeight;
			float num3 = 0f;
			if (num2 > class3.OuterBound.Height)
			{
				num3 = (num2 - class3.OuterBound.Height - class3.float_2) / 2f;
			}
			float x = interface348_0.imethod_1(class3, @class, i == 0, i == @class.InnerBoxes.Count - 1);
			num += num3;
			class3.Location = new PointF(x, num);
			num += class3.OuterBound.Height + num3;
		}
		Interface354 @interface = Class6927.smethod_0(this);
		@interface.imethod_0(@class);
	}

	private static void smethod_1(Class6845 container, out float highestEdgeYPos, out float lowestEdgeYPos)
	{
		lowestEdgeYPos = 0f;
		highestEdgeYPos = 0f;
		for (int i = 0; i < container.InnerBoxes.Count; i++)
		{
			Class6844 @class = container.InnerBoxes[i];
			float num = @class.Size.Height - container.Size.Height + @class.InnerBound.Y;
			float num2 = 0f - @class.InnerBound.Y;
			if (@class is Class6845 container2)
			{
				smethod_1(container2, out var highestEdgeYPos2, out var lowestEdgeYPos2);
				num2 += highestEdgeYPos2;
				num += lowestEdgeYPos2;
				if (num > lowestEdgeYPos)
				{
					lowestEdgeYPos = num;
				}
				if (num2 > highestEdgeYPos)
				{
					highestEdgeYPos = num2;
				}
			}
		}
	}

	private void method_2(IList<Class6844> longLines, Class6845 container)
	{
		IList<Class6844> list = new List<Class6844>();
		Class6850 line = interface344_0.imethod_6(container);
		if (container.Style.TextIndent.Value != 0f)
		{
			float num = Class6969.smethod_9(container.Style.TextIndent, container.OuterBound.Width);
			line.Size = new SizeF(line.Size.Width - num, line.Size.Height);
		}
		for (int i = 0; i < longLines.Count; i++)
		{
			Class6845 longLine = (Class6845)longLines[i];
			method_3(longLine, ref line, list, container);
			if (line.InnerBoxes.Count != 0)
			{
				smethod_2(line, list, container);
				line = interface344_0.imethod_6(container);
			}
		}
		container.InnerBoxes = list;
	}

	private void method_3(Class6844 longLine, ref Class6850 line, IList<Class6844> lines, Class6845 container)
	{
		if (longLine is Class6856 @class && @class.IsNewLine)
		{
			lines.Add(line);
			line = interface344_0.imethod_6(container);
		}
		else if (container.Style.WhiteSpace != Enum959.const_4 && container.Style.WhiteSpace != Enum959.const_1)
		{
			if (longLine is Class6855 class2 && class2.IsSpaceBox && line.InnerBoxes.Count == 0 && container.Style.WhiteSpace != Enum959.const_3)
			{
				return;
			}
			if (!method_0(longLine))
			{
				method_1(longLine, container);
				return;
			}
			Class6844 class3 = class6921_0.method_0(longLine, line);
			if (class3 != null)
			{
				if (line.InnerBoxes.Count != 0)
				{
					Class6845 class4 = (Class6845)line.InnerBoxes[0];
					line.InnerBoxes = class4.InnerBoxes;
					smethod_2(line, lines, container);
				}
				line = interface344_0.imethod_6(container);
				method_3(class3, ref line, lines, container);
			}
		}
		else
		{
			if (longLine is Class6845 class5)
			{
				line.InnerBoxes = class5.InnerBoxes;
			}
			lines.Add(line);
			line = interface344_0.imethod_6(container);
		}
	}

	private static void smethod_2(Class6850 line, IList<Class6844> lines, Class6845 container)
	{
		smethod_3(line, container);
		if (line.InnerBoxes.Count > 0)
		{
			lines.Add(line);
		}
	}

	private static void smethod_3(Class6850 line, Class6845 container)
	{
		smethod_6(line);
		if (container.Style.WhiteSpace != Enum959.const_3)
		{
			smethod_5(line);
		}
		smethod_4(line);
		Interface354 @interface = new Class6947();
		@interface.imethod_1(line);
	}

	private static void smethod_4(Class6844 box)
	{
		if (box is Class6845 @class)
		{
			for (int i = 0; i < @class.InnerBoxes.Count; i++)
			{
				smethod_4(@class.InnerBoxes[i]);
			}
			Class6929 class2 = new Class6929();
			class2.imethod_0(box);
		}
	}

	private static void smethod_5(Class6845 container)
	{
		int index = 0;
		while (true)
		{
			if (container.InnerBoxes.Count > 0)
			{
				if (!(container.InnerBoxes[index] is Class6855 @class) || !@class.IsSpaceBox)
				{
					break;
				}
				container.InnerBoxes.RemoveAt(index);
				continue;
			}
			return;
		}
		if (container.InnerBoxes[index] is Class6845)
		{
			smethod_5(container.InnerBoxes[index] as Class6845);
		}
	}

	private static void smethod_6(Class6845 container)
	{
		if (container.InnerBoxes.Count == 0)
		{
			return;
		}
		int num = container.InnerBoxes.Count - 1;
		while (true)
		{
			if (num >= 0)
			{
				if (!(container.InnerBoxes[num] is Class6855 @class) || !@class.IsSpaceBox)
				{
					break;
				}
				container.InnerBoxes.RemoveAt(num);
				num--;
				continue;
			}
			return;
		}
		if (container.InnerBoxes[num] is Class6845)
		{
			smethod_6(container.InnerBoxes[num] as Class6845);
		}
	}
}
