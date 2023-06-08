using System;
using System.Drawing;
using ns161;
using ns164;
using ns166;
using ns167;
using ns169;

namespace ns163;

internal abstract class Class4744 : Class4743
{
	private const float float_0 = 1.5f;

	private const float float_1 = 1.5f;

	private const float float_2 = 0.25f;

	private const float float_3 = 30f;

	private bool bool_0;

	internal bool ForcePageBreaks
	{
		set
		{
			bool_0 = value;
		}
	}

	internal Class4744(Class4750 context)
		: base(null, context)
	{
	}

	internal void method_0(SizeF pageSize, RectangleF rootMargins)
	{
		method_3(pageSize, rootMargins);
		class4750_0.BottomOfLastElement = 0f;
		class4750_0.VerticalExpansion = 0f;
		method_1();
		method_4(pageSize, rootMargins, writeMarginsToSection: true);
	}

	private void method_1()
	{
		if (class4750_0.Document.Count != 0 && class4750_0.LastSection.Count != 0 && class4750_0.LastElement is Class4762 @class && @class.Count != 0 && @class[@class.Count - 1] is Class4765)
		{
			Class4765 class2 = (Class4765)@class[@class.Count - 1];
			if (class2.Text.Length > 1 && class2.Text[class2.Text.Length - 1] != '\r')
			{
				Class4762 class3 = new Class4762(new Class4767());
				class3.Add(new Class4765("\r", new Class4767(), null));
				class4750_0.LastSection.Add(class3);
			}
		}
	}

	internal override bool vmethod_0(Class4779 node)
	{
		Class4782 root = node as Class4782;
		if (node == null)
		{
			throw new ArgumentException("Please report exception. Invalid root element in" + ToString());
		}
		Class4846 visitedElements = new Class4846();
		return true & vmethod_1(root, visitedElements);
	}

	private bool method_2(SizeF pageSize)
	{
		float x = (float)class4750_0.LastSection.Attributes[Enum670.const_6];
		float x2 = (float)class4750_0.LastSection.Attributes[Enum670.const_7];
		if (Class4778.smethod_0(x, pageSize.Width))
		{
			return !Class4778.smethod_0(x2, pageSize.Height);
		}
		return true;
	}

	private bool method_3(SizeF pageSize, RectangleF pageMargins)
	{
		bool result = false;
		if (class4750_0.Document.Count != 0)
		{
			if (class4750_0.LastSection.Attributes.method_0(Enum670.const_4))
			{
				float num = (float)class4750_0.LastSection.Attributes[Enum670.const_4];
				result = !Class4778.smethod_1(num, pageMargins.Top, 30.0);
				float num2 = (float)class4750_0.LastSection.Attributes[Enum670.const_2];
				result |= !Class4778.smethod_1(num2, pageMargins.Left, 30.0);
			}
			else if (!class4750_0.LastSection.Attributes.method_0(Enum670.const_4))
			{
				result = true;
			}
		}
		else
		{
			result = true;
		}
		return result;
	}

	private void method_4(SizeF pageSize, RectangleF pageMargins, bool writeMarginsToSection)
	{
		Class4767 @class = new Class4767();
		@class.Add(Enum670.const_6, pageSize.Width);
		@class.Add(Enum670.const_7, pageSize.Height);
		if (writeMarginsToSection)
		{
			@class.Add(Enum670.const_4, Class4817.smethod_1(pageMargins.Top, 0f));
			@class.Add(Enum670.const_5, Class4817.smethod_1(pageSize.Height - pageMargins.Bottom, 0f));
			class4750_0.LeftMargin = Class4817.smethod_1(pageMargins.Left, 0f);
			@class.Add(Enum670.const_2, class4750_0.LeftMargin);
			@class.Add(Enum670.const_3, Class4817.smethod_1(pageSize.Width - pageMargins.Right, 0f));
		}
		Class4763 class2 = new Class4763(@class);
		class4750_0.Document.Add(class2);
		class4750_0.CurrentElement = class2;
	}

	protected abstract bool vmethod_1(Class4782 root, Class4846 visitedElements);

	internal static void smethod_2(Class4780 root, Class4846 visitedElements)
	{
		bool flag = false;
		for (int i = 0; i < Class4802.MaxNumberOfPasses; i++)
		{
			if (!(flag = (flag = (flag |= Class4802.smethod_1(root, visitedElements)) | Class4805.smethod_0(root, visitedElements)) | Class4802.smethod_4(root, visitedElements)))
			{
				break;
			}
			root.Flush();
		}
	}

	protected Class4767 method_5(Class4779 el)
	{
		Class4785 @class = el as Class4785;
		float num = 0f;
		if (Class4860.Instance.Options.UseNewTextBoxRecognitionAlgorithm && @class != null)
		{
			Class4779 value = @class.method_20(0, 0).Value;
			if (value is Class4784 class2)
			{
				num = class2.method_36();
			}
		}
		Class4767 class3 = new Class4767();
		class3.Add(Enum670.const_1, el.BoundingBox.Y - num);
		class3.Add(Enum670.const_7, el.BoundingBox.Height + el.FontSize * 1.5f);
		class3.Add(Enum670.const_0, el.BoundingBox.X);
		float num2 = Math.Max(el.GetRealWidth, el.BoundingBox.Width);
		class3.Add(Enum670.const_6, num2 + Math.Max(el.FontSize * 1.5f, num2 * 0.15f));
		return class3;
	}

	protected void method_6(Class4790 picture)
	{
		Class4767 format = method_5(picture);
		class4750_0.CurrentElement.Add(new Class4761(picture, warpTextAround: false, isRelativePosition: true, picture.IsBehindText, format));
		class4750_0.BottomOfLastElement = picture.BoundingBox.Bottom;
	}
}
