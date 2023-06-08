using System.Collections;
using System.Drawing;
using ns235;

namespace ns215;

internal class Class5912
{
	private ArrayList arrayList_0 = new ArrayList();

	private Stack stack_0 = new Stack();

	internal ArrayList Pages => arrayList_0;

	internal void method_0(SizeF size)
	{
		Class6216 @class = new Class6216(size.Width, size.Height);
		Class6213 class2 = new Class6213();
		@class.Add(class2);
		stack_0.Push(class2);
		Pages.Add(@class);
	}

	internal void method_1(Class6219 glyphs)
	{
		((Class6213)stack_0.Peek()).Add(glyphs);
	}

	internal void method_2(Class6205 field)
	{
		((Class6213)stack_0.Peek()).Add(field);
	}

	internal void method_3(Class6217 path)
	{
		((Class6213)stack_0.Peek()).Add(path);
	}

	internal void method_4(Class6220 image)
	{
		((Class6213)stack_0.Peek()).Add(image);
	}

	internal void method_5(Class6213 canvas)
	{
		((Class6213)stack_0.Peek()).Add(canvas);
	}

	internal void method_6(Class6213 canvas)
	{
		((Class6213)stack_0.Peek()).Add(canvas);
		stack_0.Push(canvas);
	}

	internal Class6213 method_7()
	{
		return (Class6213)stack_0.Pop();
	}

	internal void method_8()
	{
	}

	public void Save(string file)
	{
	}
}
