using System;
using System.Collections;
using ns164;
using ns166;
using ns167;
using ns218;

namespace ns163;

internal class Class4746 : Class4744
{
	private Class4749 class4749_0;

	internal Class4746(Class4750 context)
		: base(context)
	{
		class4749_0 = new Class4749(context);
		class4749_0.IsRelativePositionForImages = true;
	}

	protected override bool vmethod_1(Class4782 root, Class4846 visitedElements)
	{
		bool result = true;
		smethod_3(root);
		foreach (Class4845 item in root)
		{
			if (!visitedElements.Contains(item))
			{
				if (item.Value is Class4785 block)
				{
					method_7(block);
				}
				if (item.Value is Class4790 picture)
				{
					method_6(picture);
				}
				if (item.Value is Class4787 graphicsArea)
				{
					method_8(graphicsArea);
				}
			}
		}
		return result;
	}

	private static void smethod_3(Class4782 root)
	{
		Class4786 @class = new Class4786();
		Class5971 class2 = new Class5971();
		foreach (Class4845 item in root)
		{
			if (!(item.Value is Class4785 class4) || class4.LineCount != 1 || !(class4[0][0] is Class4784 class5) || class5.PageElementCount == 1 || class5.method_3())
			{
				continue;
			}
			float num = class2.method_1(" ", ((Class4791)class5[0]).ApsGlyphFont).Width * class4.GetRealWidth;
			bool flag = false;
			for (int i = 1; i < class5.PageElementCount; i++)
			{
				Class4791 text = (Class4791)class5[i - 1];
				Class4791 text2 = (Class4791)class5[i];
				if (!(Class4778.smethod_7(text, text2) < (double)num))
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				continue;
			}
			foreach (Class4845 item2 in class5)
			{
				Class4785 class7 = new Class4785();
				class7.Add(item2.Value);
				@class.Add(class7);
			}
			foreach (Class4845 textSubSuperscriptPart in class5.TextSubSuperscriptParts)
			{
				Class4785 class9 = new Class4785();
				class9.Add(textSubSuperscriptPart.Value);
				@class.Add(class9);
			}
			item.Remove();
		}
		class2.Dispose();
		root.Flush();
		root.CopyFrom(@class);
	}

	private void method_7(Class4785 block)
	{
		Class4755 currentElement = class4750_0.CurrentElement;
		Class4767 @class = method_5(block);
		Class4764 class2 = new Class4764(@class);
		class4750_0.CurrentElement.Add(class2);
		class4750_0.CurrentElement = class2;
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < block.LineCount; i++)
		{
			Class4783 class3 = block[i];
			for (int j = 0; j < class3.PageElementCount; j++)
			{
				Class4779 class4 = class3[j];
				if (class4 is Class4790)
				{
					arrayList.Add(class4);
					continue;
				}
				Class4785 class5 = new Class4785();
				class5.Add(class4);
				class5.Parent = block;
				if (!class4749_0.vmethod_0(class5))
				{
					throw new InvalidOperationException("Please report exception.");
				}
			}
		}
		class4750_0.CurrentElement = currentElement;
		class4750_0.BottomOfLastElement = (float)@class[Enum670.const_7] + block.BoundingBox.Y;
		foreach (Class4790 item in arrayList)
		{
			method_6(item);
		}
	}

	private void method_8(Class4787 graphicsArea)
	{
		class4750_0.CurrentElement.Add(new Class4756(graphicsArea));
	}
}
