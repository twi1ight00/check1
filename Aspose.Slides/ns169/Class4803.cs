using System;
using System.Collections;
using System.Drawing;
using ns166;
using ns167;

namespace ns169;

internal class Class4803
{
	private Class4786 class4786_0;

	internal Class4803()
	{
		class4786_0 = new Class4786();
	}

	internal Class4782 method_0(Class4786 sourceSpace)
	{
		if (sourceSpace == null)
		{
			return null;
		}
		class4786_0 = sourceSpace;
		Class4782 @class = new Class4782(isColumnwise: false);
		method_1(@class, class4786_0.method_2(Enum673.const_0, isReverse: false), goVertical: false);
		@class.Flush();
		method_2(@class);
		return @class;
	}

	internal void method_1(Class4782 parent, Class4846 allElements, bool goVertical)
	{
		if (allElements == null)
		{
			return;
		}
		foreach (Class4845 allElement in allElements)
		{
			Class4782 class2 = null;
			Class4846 class3 = method_4(allElement, allElements, goVertical);
			if (!class3.method_3() && (!(allElement.Value is Class4790) || !((Class4790)allElement.Value).IsBehindText))
			{
				class2 = new Class4782(!goVertical);
				method_1(class2, class3, !goVertical);
				parent.Add(class2);
			}
			else
			{
				parent.Add(allElement.Value);
				allElement.Remove();
			}
			if (!(allElement.Value is Class4789) && class2 != null)
			{
				class2.Add(allElement.Value);
				allElement.Remove();
			}
		}
	}

	internal void method_2(Class4782 node)
	{
		if (node == null)
		{
			return;
		}
		foreach (Class4845 item in node)
		{
			if (item.Value is Class4782)
			{
				method_2((Class4782)item.Value);
			}
		}
		method_3(node);
	}

	internal void method_3(Class4782 node)
	{
		if (node == null)
		{
			return;
		}
		ArrayList arrayList = new ArrayList();
		foreach (Class4845 item in node)
		{
			arrayList.Add(item.Value);
			item.Remove();
		}
		node.Flush();
		node.vmethod_2(arrayList);
	}

	internal Class4846 method_4(Class4845 elPtr, Class4846 allElements, bool goVertical)
	{
		Class4846 @class = method_5(elPtr, allElements, goVertical);
		if (goVertical)
		{
			return @class;
		}
		if (!@class.method_3())
		{
			bool flag;
			do
			{
				flag = false;
				RectangleF a = @class.method_5();
				a = RectangleF.Union(a, elPtr.Value.BoundingBox);
				Class4846 class2 = class4786_0.method_6(a);
				if (class2 == null)
				{
					break;
				}
				class2.method_8(allElements);
				if (@class.Count < class2.Count && class2.Count < allElements.Count)
				{
					flag = true;
					@class = class2;
				}
			}
			while (flag);
		}
		return @class;
	}

	internal Class4846 method_5(Class4845 elPtr, Class4846 allElements, bool goVertical)
	{
		Class4846 @class = new Class4846();
		for (int i = 0; i < 2; i++)
		{
			@class.method_9(method_7(elPtr, allElements, !goVertical, i));
		}
		return @class;
	}

	internal void method_6(Class4846 neighbors, bool goVertical, int direction)
	{
		if (neighbors != null)
		{
			bool isReverse = direction == 0;
			Enum673 dimension = ((!goVertical) ? ((direction != 0) ? Enum673.const_1 : Enum673.const_2) : ((direction == 0) ? Enum673.const_4 : Enum673.const_3));
			neighbors.method_11(dimension, isReverse);
		}
	}

	internal Class4846 method_7(Class4845 elPtr, Class4846 elementsInScope, bool goVertical, int direction)
	{
		if (elementsInScope != null && !(elPtr == null))
		{
			Class4846 @class;
			if (goVertical)
			{
				@class = ((direction != 0) ? class4786_0.method_19(elPtr, 0f, class4786_0.BoundingBox.Width) : class4786_0.method_18(elPtr, 0f, class4786_0.BoundingBox.Width));
			}
			else
			{
				RectangleF rectangleF = elementsInScope.method_5();
				@class = ((direction != 0) ? class4786_0.method_16(elPtr, Math.Abs(elPtr.Value.BoundingBox.Top - rectangleF.Bottom), 0f) : class4786_0.method_17(elPtr, Math.Abs(rectangleF.Bottom - elPtr.Value.BoundingBox.Bottom), 0f));
			}
			@class.Remove(smethod_0(elPtr, goVertical, @class));
			@class.method_8(elementsInScope);
			if (!@class.method_3())
			{
				method_6(@class, goVertical, direction);
			}
			return @class;
		}
		return null;
	}

	internal static Class4846 smethod_0(Class4845 elPtr, bool goVertical, Class4846 neighbors)
	{
		if (neighbors == null)
		{
			return null;
		}
		Class4846 @class = new Class4846();
		foreach (Class4845 neighbor in neighbors)
		{
			if (goVertical ? (!Class4778.smethod_23(neighbor.Value, elPtr.Value)) : (!Class4778.smethod_25(neighbor.Value, elPtr.Value)))
			{
				@class.Add(neighbor);
			}
		}
		return @class;
	}
}
