using System;
using System.Collections;
using System.Drawing;
using ns235;

namespace ns168;

internal class Class4799
{
	private readonly ArrayList arrayList_0 = new ArrayList();

	private Class4794 class4794_0;

	private Class4795 class4795_0;

	private ArrayList arrayList_1;

	internal Class4794 RootBox => class4794_0;

	internal Class4795 TrueBoxes
	{
		get
		{
			if (class4795_0 == null)
			{
				if (!(RootBox != null))
				{
					throw new InvalidOperationException("Please report exception.");
				}
				class4795_0 = RootBox.method_11();
			}
			return class4795_0;
		}
	}

	internal int Count => arrayList_0.Count;

	internal Class4796 this[int index] => (Class4796)arrayList_0[index];

	internal ArrayList SourceApsGraphics => arrayList_1;

	internal Class4799(Class6216 source)
	{
		class4794_0 = new Class4794(new Class4793(source));
		class4794_0.PageOrder = -1;
		method_7(source);
	}

	internal void method_0(Class4798 c)
	{
		for (int i = 0; i < c.Count; i++)
		{
			method_1(c[i]);
		}
	}

	internal void method_1(Class4797 s)
	{
		int num = method_5(s);
		if (num != -1)
		{
			this[num].Add(s);
			return;
		}
		Class4796 @class = new Class4796();
		@class.Add(s);
		method_6(@class);
	}

	internal void method_2()
	{
		bool[] array = new bool[Count];
		bool flag;
		do
		{
			flag = false;
			for (int num = Count - 1; num >= 0; num--)
			{
				if (!array[num])
				{
					for (int num2 = num - 1; num2 >= 0; num2--)
					{
						if (!array[num2])
						{
							RectangleF rectangleF = RectangleF.Intersect(this[num].BoundingBox, this[num2].BoundingBox);
							if (rectangleF.Width != 0f || rectangleF.Height != 0f)
							{
								this[num].method_0(this[num2]);
								array[num2] = true;
								flag = true;
							}
						}
					}
				}
			}
		}
		while (flag);
		for (int num3 = Count - 1; num3 >= 0; num3--)
		{
			if (array[num3])
			{
				arrayList_0.RemoveAt(num3);
			}
		}
	}

	internal void method_3()
	{
		for (int i = 0; i < Count; i++)
		{
			this[i].method_5();
		}
	}

	internal void method_4()
	{
		for (int i = 0; i < Count; i++)
		{
			this[i].method_4();
		}
	}

	private int method_5(Class4797 s)
	{
		int result = -1;
		for (int i = 0; i < Count; i++)
		{
			if (this[i].method_2(s))
			{
				result = i;
				break;
			}
		}
		return result;
	}

	private void method_6(Class4796 ga)
	{
		arrayList_0.Add(ga);
	}

	private void method_7(Class6216 source)
	{
		arrayList_1 = new ArrayList();
		Class6212 @class = source;
		if (@class.Count > 0 && @class[0] is Class6213)
		{
			@class = @class[0] as Class6212;
		}
		for (int i = 0; i < @class.Count; i++)
		{
			if (@class[i] is Class6217 value)
			{
				arrayList_1.Add(value);
			}
		}
	}
}
