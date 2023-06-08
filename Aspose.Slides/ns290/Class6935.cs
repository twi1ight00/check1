using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using ns284;
using ns301;

namespace ns290;

internal class Class6935 : Interface347
{
	private readonly SizeF sizeF_0;

	private readonly Interface345 interface345_0;

	private readonly Interface344 interface344_0;

	private readonly Interface351 interface351_0;

	private Class6786 class6786_0;

	private IList ilist_0;

	public Class6935(SizeF pageSize, Interface345 formattingContextFactory, Class6786 renderContext)
	{
		Class6892.smethod_0(formattingContextFactory, "formattingContextFactory");
		Class6892.smethod_0(renderContext, "renderContext");
		sizeF_0 = pageSize;
		interface345_0 = formattingContextFactory;
		ilist_0 = new List<Class6849>();
		interface344_0 = new Class6925(renderContext);
		interface351_0 = new Class6942();
	}

	public IList imethod_0(Class6844 boxModel)
	{
		Class6892.smethod_0(boxModel, "boxModel");
		SizeF size = new SizeF(sizeF_0.Width, sizeF_0.Height);
		boxModel.Style.Display = Enum952.const_1;
		method_2(boxModel);
		method_3(boxModel, size);
		if (boxModel.Size.Height < size.Height)
		{
			boxModel.Size = new SizeF(boxModel.Size.Width, size.Height);
		}
		method_0(boxModel, interface351_0);
		Interface341 blockSplitter = new Class6920(interface351_0);
		Class6919 blockBoxPlacer = new Class6919(interface351_0, blockSplitter);
		Class6938 @class = new Class6938(blockBoxPlacer, new Class6925(class6786_0), sizeF_0);
		@class.method_1(boxModel);
		ilist_0 = @class.method_0();
		return ilist_0;
	}

	private void method_0(Class6844 box, Interface351 boxInfo)
	{
		if (!(box is Class6849 @class))
		{
			return;
		}
		foreach (DictionaryEntry absoluteBox in @class.AbsoluteBoxes)
		{
			if (absoluteBox.Value is IList list && list.Count > 0)
			{
				for (int i = 0; i < list.Count; i++)
				{
					Class6844 class2 = (Class6844)list[i];
					method_1(class2 as Class6845, boxInfo);
					method_0(class2, boxInfo);
				}
			}
		}
	}

	private void method_1(Class6845 absoluteBox, Interface351 boxInfo)
	{
		Class6939 @class = new Class6939(boxInfo);
		absoluteBox.Style.Display = Enum952.const_1;
		method_2(absoluteBox);
		float width = @class.method_0(absoluteBox, absoluteBox.Parent.PaddingBound.Size);
		method_2(absoluteBox);
		float num = Class6939.smethod_0(absoluteBox, absoluteBox.Parent.PaddingBound.Size);
		absoluteBox.Location = new PointF(num, absoluteBox.Location.Y);
		float height = @class.method_1(absoluteBox, absoluteBox.Parent.PaddingBound.Size);
		absoluteBox.Size = new SizeF(width, height);
		float height2 = Class6939.smethod_1(absoluteBox, absoluteBox.Parent.PaddingBound.Size);
		Class6845 class2 = boxInfo.imethod_5(absoluteBox);
		absoluteBox.Location = class2.PaddingBound.Location + new SizeF(num, height2);
	}

	private void method_2(Class6844 box)
	{
		if (!(box is Class6845 @class))
		{
			Interface354 @interface = smethod_0(box);
			@interface.imethod_1(box);
			return;
		}
		for (int i = 0; i < @class.InnerBoxes.Count; i++)
		{
			method_2(@class.InnerBoxes[i]);
		}
		if (interface351_0.imethod_1(@class) == Enum946.const_0)
		{
			Interface346 interface2 = interface345_0.imethod_0(box);
			interface2.imethod_0(box);
			return;
		}
		if (interface351_0.imethod_0(@class) == Enum946.const_0)
		{
			@class.InnerBoxes = method_4(@class);
		}
		Interface354 interface3 = smethod_0(@class);
		interface3.imethod_3(@class);
	}

	private void method_3(Class6844 box, SizeF size)
	{
		if (box is Class6855)
		{
			return;
		}
		Interface354 @interface = smethod_0(box);
		if (box.Parent != null && box.Style.Position != Enum956.const_1)
		{
			@interface.imethod_1(box);
		}
		else
		{
			@interface.imethod_2(box, size);
		}
		if (box is Class6845 @class)
		{
			for (int i = 0; i < @class.InnerBoxes.Count; i++)
			{
				Class6844 box2 = @class.InnerBoxes[i];
				method_3(box2, box.InnerBound.Size);
			}
		}
		interface345_0.imethod_0(box)?.imethod_0(box);
	}

	private List<Class6844> method_4(Class6845 container)
	{
		List<Class6844> list = new List<Class6844>();
		Class6850 @class = interface344_0.imethod_6(container);
		for (int i = 0; i < container.InnerBoxes.Count; i++)
		{
			Class6844 class2 = container.InnerBoxes[i];
			method_5(class2, @class);
			if (class2 is Class6856 class3 && class3.IsNewLine)
			{
				Class6931 class4 = new Class6931();
				class4.imethod_0(@class);
				list.Add(@class);
				@class = interface344_0.imethod_6(container);
			}
			else
			{
				class2.Parent = @class;
				@class.InnerBoxes.Add(class2);
			}
		}
		if (@class.InnerBoxes.Count > 0)
		{
			Class6931 class5 = new Class6931();
			class5.imethod_0(@class);
			list.Add(@class);
		}
		return list;
	}

	private void method_5(Class6844 innerBox, Class6850 line)
	{
		float num = ((!(innerBox is Class6845 container)) ? innerBox.OuterBound.Width : interface351_0.imethod_12(container));
		if (num > line.MinWidth)
		{
			line.MinWidth = num;
		}
	}

	private static Interface354 smethod_0(Class6844 box)
	{
		Interface351 @interface = new Class6942();
		Enum946 @enum = @interface.imethod_1(box);
		if (box is Class6845)
		{
			if (box is Class6853)
			{
				return new Class6948();
			}
			if (box is Class6854)
			{
				return new Class6949();
			}
			if (box is Class6852)
			{
				return new Class6950();
			}
			return @enum switch
			{
				Enum946.const_1 => new Class6946(), 
				Enum946.const_0 => new Class6947(), 
				Enum946.const_2 => new Class6946(), 
				_ => throw new Exception("strange box"), 
			};
		}
		return new Class6951();
	}
}
