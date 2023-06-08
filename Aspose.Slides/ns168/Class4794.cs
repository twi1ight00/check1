using System;
using System.Collections;
using System.Drawing;
using ns161;
using ns235;

namespace ns168;

internal class Class4794 : Class4793
{
	private readonly ArrayList arrayList_0 = new ArrayList();

	internal Class4793 this[int index]
	{
		get
		{
			if (index >= arrayList_0.Count || arrayList_0.Count == 0 || index < 0)
			{
				throw new ArgumentOutOfRangeException("Please report exception");
			}
			return (Class4793)arrayList_0[index];
		}
		set
		{
			if (index >= arrayList_0.Count || index < 0)
			{
				throw new ArgumentOutOfRangeException("Please report exception");
			}
			arrayList_0[index] = value;
		}
	}

	internal override bool IsComposite => true;

	internal int Count => arrayList_0.Count;

	internal Class4794(Class6217 source)
		: base(source)
	{
	}

	internal Class4794(Class4793 source)
		: base(source)
	{
	}

	public override void vmethod_0(Graphics canvas, PointF topLeft)
	{
		base.vmethod_0(canvas, topLeft);
		for (int i = 0; i < Count; i++)
		{
			this[i].vmethod_0(canvas, topLeft);
		}
	}

	internal bool method_10(Class4793 node)
	{
		return smethod_22(node, this);
	}

	internal Class4795 method_11()
	{
		Class4795 @class = new Class4795();
		smethod_20(this, @class);
		return @class;
	}

	internal static void smethod_20(Class4793 rootNode, Class4795 results)
	{
		Class4793 box;
		if (rootNode.IsComposite)
		{
			Class4794 @class = (Class4794)rootNode;
			for (int i = 0; i < @class.Count; i++)
			{
				smethod_20(@class[i], results);
			}
		}
		else if (rootNode.method_1(out box))
		{
			box.PageOrder = rootNode.Parent.PageOrder;
			results.Add(box);
		}
	}

	internal Class4798 method_12()
	{
		Class4798 result = new Class4798();
		smethod_21(this, result);
		return result;
	}

	private static void smethod_21(Class4793 rootNode, Class4798 result)
	{
		if (rootNode.IsComposite)
		{
			Class4794 @class = (Class4794)rootNode;
			for (int i = 0; i < @class.Count; i++)
			{
				smethod_21(@class[i], result);
			}
		}
		else if (rootNode.CanConstructSegment)
		{
			result.Add(rootNode.AsSegment);
		}
	}

	private static bool smethod_22(Class4793 box, Class4793 rootNode)
	{
		bool flag = false;
		if (box.method_2(rootNode))
		{
			if (rootNode.IsComposite)
			{
				Class4794 @class = (Class4794)rootNode;
				Class4795 class2 = new Class4795();
				Class4795 class3 = new Class4795();
				for (int i = 0; i < @class.Count; i++)
				{
					if (!(@class[i].BoundingBox.Width < 1f) && @class[i].BoundingBox.Height >= 1f)
					{
						if (smethod_22(box, @class[i]))
						{
							flag = true;
							break;
						}
						if (@class[i].method_2(box))
						{
							if (Class4817.smethod_5(box.BackgroundColor, @class.BackgroundColor))
							{
								class2.Add(@class[i]);
							}
							else
							{
								@class[i] = box;
							}
							flag = true;
						}
						else
						{
							smethod_24(box, @class[i], class3, class2);
						}
					}
					else
					{
						class2.Add(@class[i]);
					}
				}
				@class.method_13(class3);
				@class.method_14(class2);
				smethod_23(@class);
				if (!flag && !Class4817.smethod_5(box.BackgroundColor, @class.BackgroundColor))
				{
					@class.Add(box);
					flag = true;
				}
			}
			else
			{
				if (!Class4817.smethod_5(box.BackgroundColor, rootNode.BackgroundColor))
				{
					Class4794 class4 = smethod_27(rootNode);
					class4.Add(box);
				}
				flag = true;
			}
		}
		return flag;
	}

	private static void smethod_23(Class4794 curNode)
	{
		for (int num = curNode.Count - 1; num >= 0; num--)
		{
			if (Class4817.smethod_5(curNode.BackgroundColor, curNode[num].BackgroundColor))
			{
				curNode.RemoveAt(num);
			}
		}
	}

	private static void smethod_24(Class4793 top, Class4793 bottom, Class4795 toInsert, Class4795 toRemove)
	{
		if (bottom.IsComposite)
		{
			Class4794 @class = (Class4794)bottom;
			Class4795 class2 = new Class4795();
			Class4795 class3 = new Class4795();
			for (int num = @class.Count - 1; num >= 0; num--)
			{
				smethod_24(top, @class[num], class3, class2);
			}
			@class.method_13(class3);
			@class.method_14(class2);
			smethod_25(top, bottom, toInsert, toRemove);
		}
		else
		{
			smethod_25(top, bottom, toInsert, toRemove);
		}
	}

	private static void smethod_25(Class4793 top, Class4793 bottom, Class4795 toInsert, Class4795 toRemove)
	{
		Class4795 @class = Class4793.smethod_0(top, bottom);
		if (@class == null)
		{
			return;
		}
		if (@class.Count == 0)
		{
			toRemove.Add(bottom);
			return;
		}
		if (bottom.IsComposite)
		{
			smethod_26(@class, (Class4794)bottom);
		}
		toInsert.method_0(@class);
		toRemove.Add(bottom);
	}

	private static void smethod_26(Class4795 splits, Class4794 origin)
	{
		for (int i = 0; i < origin.Count; i++)
		{
			for (int j = 0; j < splits.Count; j++)
			{
				if (origin[i].method_2(splits[j]))
				{
					Class4794 class2 = (Class4794)(splits[j] = new Class4794(splits[j]));
					class2.Add(origin[i]);
					break;
				}
			}
		}
	}

	private static Class4794 smethod_27(Class4793 node)
	{
		Class4794 @class = new Class4794(node);
		if (node.Parent != null)
		{
			node.Parent.Remove(node);
			node.Parent.Add(@class);
		}
		return @class;
	}

	private void Add(Class4793 child)
	{
		arrayList_0.Add(child);
		child.Parent = this;
	}

	private void method_13(Class4795 collection)
	{
		for (int i = 0; i < collection.Count; i++)
		{
			Add(collection[i]);
		}
	}

	private void Remove(Class4793 child)
	{
		arrayList_0.Remove(child);
	}

	private void RemoveAt(int index)
	{
		arrayList_0.RemoveAt(index);
	}

	private void method_14(Class4795 collection)
	{
		for (int i = 0; i < collection.Count; i++)
		{
			Remove(collection[i]);
		}
	}
}
