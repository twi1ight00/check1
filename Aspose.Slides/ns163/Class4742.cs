using System;
using System.Drawing;
using ns161;
using ns164;
using ns167;
using ns169;
using ns235;

namespace ns163;

internal class Class4742
{
	private Class4750 class4750_0;

	private Class4744 class4744_0;

	private Class4859 class4859_0;

	internal Class4760 Document => class4750_0.Document;

	internal Class4742(Class4859 options)
	{
		class4859_0 = options;
		Class4860.Instance.RelativeHorizontalProximity = class4859_0.RelativeHorizontalProximity;
		if (class4859_0.Mode != Enum676.const_1)
		{
			class4859_0.ForcePageBreaks = true;
		}
		Class4760 doc = new Class4760();
		class4750_0 = new Class4750(doc);
		class4750_0.bool_0 = class4859_0.AddReturnToLineEnd;
		class4750_0.enum676_0 = class4859_0.Mode;
		method_0();
	}

	internal static Class4782 smethod_0(Class6216 curFixedPage, Enum676 mode, bool recognizeUnderlineAndStrikeout)
	{
		Class4786.Class6179 @class = Class4786.smethod_7(curFixedPage);
		if (@class.TextSpace.ChildrenCount > 500)
		{
			Class4752.smethod_0(@class.TextSpace);
		}
		Class4786 class2 = new Class4786(curFixedPage, mode, @class.TextSpace.Lines, @class.TextSpace.ImgesRects, recognizeUnderlineAndStrikeout);
		Class4806.smethod_0(class2);
		Class4782 class4;
		if (mode == Enum676.const_1)
		{
			Class4806.smethod_1(class2);
			smethod_2(@class.TextSpace, class2);
			Class4806.smethod_2(class2);
			Class4806.smethod_3(class2);
			Class4803 class3 = new Class4803();
			class4 = class3.method_0(class2);
			Class4804.smethod_0(class4);
			class4.Images = @class.TextSpace;
			class4.Add(@class.GraphicArea);
		}
		else
		{
			Class4806.smethod_1(class2);
			class4 = smethod_4(class2, @class.TextSpace);
			class4 = smethod_5(class4);
			class4.Add(@class.GraphicArea);
		}
		return class4;
	}

	private static Class4782 smethod_1(Class4786 text, Class4786 images, Class4786 tables)
	{
		smethod_2(images, text);
		text.Add(images);
		Class4806.smethod_2(text);
		Class4806.smethod_3(text);
		smethod_3(text, tables);
		text.Add(tables);
		Class4803 @class = new Class4803();
		Class4782 class2 = @class.method_0(text);
		Class4804.smethod_2(class2);
		return class2;
	}

	private static void smethod_2(Class4786 images, Class4786 text)
	{
		foreach (Class4845 image in images)
		{
			if (image.Value is Class4790 class2 && !class2.BoundingBox.IsEmpty)
			{
				Class4846 class3 = text.method_10(class2.BoundingBox, 0.75f);
				if (!class3.method_3())
				{
					class2.IsBehindText = true;
				}
			}
		}
	}

	private static void smethod_3(Class4786 container, Class4786 tables)
	{
		Class4786 @class = new Class4786();
		foreach (Class4845 table in tables)
		{
			Class4846 class3 = container.method_6(table.Value.BoundingBox);
			foreach (Class4845 item in class3)
			{
				if (!(item.Value is Class4780 class5))
				{
					continue;
				}
				foreach (Class4845 item2 in class5)
				{
					@class.Add(item2.Value);
				}
				item.Remove();
			}
		}
		container.Add(@class);
	}

	private static Class4782 smethod_4(Class4786 text, Class4786 images)
	{
		return smethod_1(text, images, new Class4786());
	}

	private void method_0()
	{
		switch (class4859_0.Mode)
		{
		default:
			throw new InvalidOperationException("Please report exception.");
		case Enum676.const_0:
			class4744_0 = new Class4746(class4750_0);
			break;
		case Enum676.const_1:
			class4744_0 = new Class4745(class4750_0);
			break;
		}
		class4744_0.ForcePageBreaks = class4859_0.ForcePageBreaks;
	}

	private Class4782 method_1(Class6216 curFixedPage)
	{
		return smethod_0(curFixedPage, class4859_0.Mode, class4859_0.RecognizeUnderlineAndStrikeout);
	}

	private static Class4782 smethod_5(Class4782 root)
	{
		Class4782 @class = new Class4782(isColumnwise: false);
		foreach (Class4845 item in root)
		{
			if (item.Value is Class4782)
			{
				@class.CopyFrom(smethod_5((Class4782)item.Value));
			}
			else
			{
				@class.Add(item.Value);
			}
		}
		smethod_6(@class);
		return @class;
	}

	private static void smethod_6(Class4782 root)
	{
		Class4786 @class = new Class4786();
		foreach (Class4845 item in root)
		{
			if (!(item.Value is Class4785 class3))
			{
				continue;
			}
			bool flag = false;
			foreach (Class4845 item2 in (Class4785)item.Value)
			{
				if (item2.Value is Class4790)
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				continue;
			}
			Class4785 class5 = new Class4785();
			for (int i = 0; i < class3.LineCount; i++)
			{
				Class4783 class6 = class3[i];
				for (int j = 0; j < class6.PageElementCount; j++)
				{
					Class4779 class7 = class6[j];
					if (class7 is Class4790)
					{
						if (class5.ChildrenCount != 0)
						{
							@class.Add(class5);
							class5 = new Class4785();
						}
						@class.Add(class7);
					}
					else
					{
						class5.Add(class7);
					}
				}
			}
			if (class5.ChildrenCount != 0)
			{
				@class.Add(class5);
			}
			class3.Clear();
		}
		root.Flush();
		root.CopyFrom(@class);
	}

	internal void method_2(Class6216 curFixedPage)
	{
		Class4782 @class = method_1(curFixedPage);
		RectangleF boundingBox = @class.BoundingBox;
		class4744_0.method_0(curFixedPage.Size, boundingBox);
		if (!class4744_0.vmethod_0(@class))
		{
			throw new InvalidOperationException("Please report exception. Page recognition failed.");
		}
	}
}
