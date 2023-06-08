using System.Collections;
using System.Collections.Generic;
using ns301;

namespace ns290;

internal class Class6849 : Class6845
{
	private SortedList sortedList_0;

	public SortedList AbsoluteBoxes => sortedList_0;

	public Class6849(Class6844 parent)
		: base(parent)
	{
		sortedList_0 = new SortedList();
	}

	public void method_0(Class6844 box)
	{
		Class6892.smethod_0(box, "box");
		if (AbsoluteBoxes.ContainsKey(box.Style.ZIndex))
		{
			IList list = (IList)AbsoluteBoxes[box.Style.ZIndex];
			list.Add(box);
		}
		else
		{
			IList list2 = new List<Class6844>();
			list2.Add(box);
			AbsoluteBoxes.Add(box.Style.ZIndex, list2);
		}
	}

	public override void vmethod_0(Interface332 visitor, bool isAps, ref Hashtable pageSet)
	{
		visitor.imethod_0(this, isAps, ref pageSet);
		foreach (DictionaryEntry absoluteBox in AbsoluteBoxes)
		{
			if ((int)absoluteBox.Key == 0)
			{
				break;
			}
			if (absoluteBox.Value is IList list && list.Count > 0)
			{
				for (int i = 0; i < list.Count; i++)
				{
					Class6844 @class = (Class6844)list[i];
					@class.vmethod_0(visitor, isAps, ref pageSet);
				}
			}
		}
		for (int j = 0; j < base.InnerBoxes.Count; j++)
		{
			Class6844 class2 = base.InnerBoxes[j];
			class2.vmethod_0(visitor, isAps, ref pageSet);
		}
		foreach (DictionaryEntry absoluteBox2 in AbsoluteBoxes)
		{
			if ((int)absoluteBox2.Key >= 0 && absoluteBox2.Value is IList list2 && list2.Count > 0)
			{
				for (int k = 0; k < list2.Count; k++)
				{
					Class6844 class3 = (Class6844)list2[k];
					class3.vmethod_0(visitor, isAps, ref pageSet);
				}
			}
		}
		visitor.imethod_1(this, isAps, ref pageSet);
	}
}
