using System.Collections;
using ns284;
using ns301;

namespace ns290;

internal class Class6944
{
	private readonly Interface351 interface351_0;

	private Class6845 class6845_0;

	private readonly Stack stack_0;

	private Stack stack_1;

	public Class6944(Class6849 mainContainer, Interface351 boxInfo)
	{
		Class6892.smethod_0(mainContainer, "mainContainer");
		Class6892.smethod_0(boxInfo, "boxInfo");
		interface351_0 = boxInfo;
		class6845_0 = mainContainer;
		stack_0 = new Stack();
	}

	public Class6845 method_0(Class6844 box)
	{
		Class6892.smethod_0(box, "box");
		if (box is Class6856 @class && @class.IsNewLine && @class.IsBr)
		{
			Class6845 class2 = method_1();
			class2.InnerBoxes.Add(box);
			Class6845 class3 = class2;
			if (stack_1 != null)
			{
				while (stack_1.Count > 0)
				{
					Class6845 class4 = stack_1.Pop() as Class6845;
					Class6845 class5 = class4.Clone() as Class6845;
					if (stack_1.Count != 0)
					{
						class3.InnerBoxes.Add(class5);
						stack_0.Push(class5);
						class3 = class5;
					}
					else
					{
						class6845_0 = class5;
						class3.InnerBoxes.Add(class6845_0);
					}
				}
			}
			return class2;
		}
		if (class6845_0 == null)
		{
			class6845_0 = (Class6845)stack_0.Pop();
		}
		if (class6845_0.GetType() == typeof(Class6848) && interface351_0.imethod_1(box) == Enum946.const_1)
		{
			class6845_0 = (Class6845)stack_0.Pop();
		}
		if (class6845_0 is Class6854 && box is Class6854)
		{
			class6845_0 = (Class6845)stack_0.Pop();
		}
		return class6845_0;
	}

	private Class6845 method_1()
	{
		if (class6845_0 == null)
		{
			class6845_0 = (Class6845)stack_0.Pop();
		}
		if (interface351_0.imethod_1(class6845_0) == Enum946.const_1)
		{
			return class6845_0;
		}
		Class6845 @class = class6845_0;
		stack_1 = new Stack();
		stack_1.Push(@class);
		while (stack_0.Count > 0 && interface351_0.imethod_1(stack_0.Peek() as Class6844) != Enum946.const_1)
		{
			@class = stack_0.Pop() as Class6845;
			stack_1.Push(@class);
		}
		if (stack_0.Count > 0)
		{
			@class = stack_0.Peek() as Class6845;
		}
		return @class;
	}

	public void method_2(Class6845 container)
	{
		Class6892.smethod_0(container, "container");
		if (class6845_0 != null)
		{
			stack_0.Push(class6845_0);
		}
		else if (stack_0.Count > 0)
		{
			Class6845 @class = (Class6845)stack_0.Peek();
			if (@class == container)
			{
				stack_0.Pop();
			}
		}
		class6845_0 = container;
	}

	public void method_3(Interface329 style)
	{
		if (stack_0.Count < 1)
		{
			return;
		}
		if (class6845_0 == null)
		{
			class6845_0 = (Class6845)stack_0.Pop();
		}
		if (class6845_0.GetType() == typeof(Class6848))
		{
			Enum946 @enum = interface351_0.imethod_2(style);
			if (@enum == Enum946.const_1)
			{
				stack_0.Pop();
				class6845_0 = (Class6845)stack_0.Pop();
			}
		}
		else
		{
			class6845_0 = (Class6845)stack_0.Pop();
		}
	}

	public void method_4(Class6845 container)
	{
		Class6892.smethod_0(container, "container");
		while (!(container is Class6848) && container.Parent != null && container.Parent is Class6845)
		{
			container = (Class6845)container.Parent;
		}
		stack_0.Push(container.Parent);
		stack_0.Push(container);
		while (container.InnerBoxes.Count > 0 && container.InnerBoxes[0] is Class6845)
		{
			container = (Class6845)container.InnerBoxes[0];
			stack_0.Push(container);
		}
		class6845_0 = null;
	}
}
