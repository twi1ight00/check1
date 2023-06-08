using System;
using System.Collections;
using System.Drawing;

namespace ns167;

internal class Class4851
{
	public class Class4856
	{
		public enum Enum675
		{
			const_0,
			const_1,
			const_2
		}

		private RectangleF rectangleF_0;

		private object object_0;

		private bool bool_0;

		private Enum675 enum675_0;

		internal Enum675 Ts
		{
			get
			{
				return enum675_0;
			}
			set
			{
				enum675_0 = value;
			}
		}

		public bool Processed
		{
			get
			{
				return bool_0;
			}
			set
			{
				bool_0 = value;
			}
		}

		public RectangleF Rect
		{
			get
			{
				return rectangleF_0;
			}
			set
			{
				rectangleF_0 = value;
			}
		}

		public object Element
		{
			get
			{
				return object_0;
			}
			set
			{
				object_0 = value;
			}
		}

		public Class4856(RectangleF rect, object element)
		{
			rectangleF_0 = rect;
			object_0 = element;
		}
	}

	public class Class4852
	{
		private ArrayList arrayList_0 = new ArrayList();

		private RectangleF rectangleF_0;

		private ArrayList arrayList_1 = new ArrayList();

		private RectangleF rectangleF_1;

		private ArrayList arrayList_2 = new ArrayList();

		private RectangleF rectangleF_2;

		private ArrayList arrayList_3 = new ArrayList();

		private RectangleF rectangleF_3;

		private Class4852 class4852_0;

		private Class4852 class4852_1;

		internal ArrayList VxMin
		{
			get
			{
				return arrayList_0;
			}
			set
			{
				arrayList_0 = value;
			}
		}

		internal ArrayList VyMin
		{
			get
			{
				return arrayList_1;
			}
			set
			{
				arrayList_1 = value;
			}
		}

		internal ArrayList VxMax
		{
			get
			{
				return arrayList_2;
			}
			set
			{
				arrayList_2 = value;
			}
		}

		internal ArrayList VyMax
		{
			get
			{
				return arrayList_3;
			}
			set
			{
				arrayList_3 = value;
			}
		}

		internal Class4852 TsL
		{
			get
			{
				return class4852_0;
			}
			set
			{
				class4852_0 = value;
			}
		}

		internal Class4852 TsR
		{
			get
			{
				return class4852_1;
			}
			set
			{
				class4852_1 = value;
			}
		}

		public RectangleF VxMinBb
		{
			get
			{
				return rectangleF_0;
			}
			set
			{
				rectangleF_0 = value;
			}
		}

		public RectangleF VyMinBb
		{
			get
			{
				return rectangleF_1;
			}
			set
			{
				rectangleF_1 = value;
			}
		}

		public RectangleF VxMaxBb
		{
			get
			{
				return rectangleF_2;
			}
			set
			{
				rectangleF_2 = value;
			}
		}

		public RectangleF VyMaxBb
		{
			get
			{
				return rectangleF_3;
			}
			set
			{
				rectangleF_3 = value;
			}
		}
	}

	private class Class4853 : IComparer
	{
		public int Compare(object x, object y)
		{
			return ((Class4856)x).Rect.Left.CompareTo(((Class4856)y).Rect.Left);
		}
	}

	private class Class4854 : IComparer
	{
		public int Compare(object x, object y)
		{
			return ((Class4856)x).Rect.Top.CompareTo(((Class4856)y).Rect.Top);
		}
	}

	private class Class4855
	{
		private ArrayList arrayList_0;

		private int int_0 = -1;

		private int int_1;

		internal Class4855(ArrayList elments, IComparer comparer)
		{
			arrayList_0 = elments;
			arrayList_0.Sort(comparer);
			int_1 = elments.Count;
		}

		internal Class4855(ArrayList elments)
		{
			arrayList_0 = elments;
			int_1 = elments.Count;
		}

		internal bool method_0()
		{
			bool result = false;
			while (int_0 < arrayList_0.Count - 1)
			{
				int_0++;
				if (!((Class4856)arrayList_0[int_0]).Processed)
				{
					result = true;
					break;
				}
			}
			return result;
		}

		internal Class4856 method_1()
		{
			return (Class4856)arrayList_0[int_0];
		}

		internal bool method_2()
		{
			bool result = false;
			while (int_1 > 0)
			{
				int_1--;
				if (!((Class4856)arrayList_0[int_1]).Processed)
				{
					result = true;
					break;
				}
			}
			return result;
		}

		internal Class4856 method_3()
		{
			return (Class4856)arrayList_0[int_1];
		}

		internal ArrayList method_4(int diskBlock)
		{
			ArrayList arrayList = new ArrayList();
			ArrayList arrayList2 = new ArrayList();
			int num = (arrayList_0.Count - 4 * diskBlock) / 2;
			for (int i = int_0 + 1; i < int_1; i++)
			{
				Class4856 @class = (Class4856)arrayList_0[i];
				if (!@class.Processed)
				{
					if (num > 0)
					{
						@class.Ts = Class4856.Enum675.const_1;
						arrayList.Add(arrayList_0[i]);
						num--;
					}
					else
					{
						@class.Ts = Class4856.Enum675.const_2;
						arrayList2.Add(arrayList_0[i]);
					}
				}
			}
			ArrayList arrayList3 = new ArrayList();
			arrayList3.Add(arrayList);
			arrayList3.Add(arrayList2);
			return arrayList3;
		}

		internal ArrayList method_5()
		{
			ArrayList arrayList = new ArrayList();
			ArrayList arrayList2 = new ArrayList();
			for (int i = int_0 + 1; i < int_1; i++)
			{
				Class4856 @class = (Class4856)arrayList_0[i];
				if (!@class.Processed)
				{
					if (@class.Ts == Class4856.Enum675.const_1)
					{
						arrayList.Add(arrayList_0[i]);
					}
					else
					{
						arrayList2.Add(arrayList_0[i]);
					}
					@class.Ts = Class4856.Enum675.const_0;
				}
			}
			ArrayList arrayList3 = new ArrayList();
			arrayList3.Add(arrayList);
			arrayList3.Add(arrayList2);
			return arrayList3;
		}

		internal void Clear()
		{
			arrayList_0.Clear();
		}

		internal int method_6()
		{
			return arrayList_0.Count;
		}
	}

	private int int_0 = 4;

	private Class4852 class4852_0;

	public int B
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
		}
	}

	public void method_0(ArrayList elements)
	{
		class4852_0 = new Class4852();
		method_4(class4852_0, new Class4855(elements, new Class4853()), new Class4855((ArrayList)elements.Clone(), new Class4854()));
		while (class4852_0.TsL != null || class4852_0.TsR != null)
		{
			elements = new ArrayList();
			smethod_0(class4852_0, elements);
			class4852_0 = new Class4852();
			method_4(class4852_0, new Class4855(elements, new Class4853()), new Class4855((ArrayList)elements.Clone(), new Class4854()));
		}
	}

	public void method_1(RectangleF rect, ArrayList elements)
	{
		method_3(class4852_0, rect, elements);
	}

	private void method_2(RectangleF rect, ArrayList elements, ArrayList children, RectangleF minBb)
	{
		if (RectangleF.Intersect(minBb, rect).IsEmpty)
		{
			return;
		}
		foreach (Class4856 child in children)
		{
			if (!RectangleF.Intersect(child.Rect, rect).IsEmpty)
			{
				if (child.Element is Class4852 node)
				{
					method_3(node, rect, elements);
				}
				else if (child.Element is ArrayList children2)
				{
					method_2(rect, elements, children2, child.Rect);
				}
				else
				{
					elements.Add(child.Element);
				}
			}
		}
	}

	private void method_3(Class4852 node, RectangleF rect, ArrayList elements)
	{
		method_2(rect, elements, node.VxMin, node.VxMinBb);
		method_2(rect, elements, node.VyMin, node.VyMinBb);
		method_2(rect, elements, node.VxMax, node.VxMaxBb);
		method_2(rect, elements, node.VyMax, node.VyMaxBb);
		if (node.TsL != null)
		{
			method_3(node.TsL, rect, elements);
		}
		if (node.TsR != null)
		{
			method_3(node.TsR, rect, elements);
		}
	}

	private static void smethod_0(Class4852 node, ArrayList elements)
	{
		if (!node.VxMinBb.IsEmpty)
		{
			elements.Add(new Class4856(node.VxMinBb, node.VxMin));
		}
		if (!node.VyMinBb.IsEmpty)
		{
			elements.Add(new Class4856(node.VyMinBb, node.VyMin));
		}
		if (!node.VxMaxBb.IsEmpty)
		{
			elements.Add(new Class4856(node.VxMaxBb, node.VxMax));
		}
		if (!node.VyMaxBb.IsEmpty)
		{
			elements.Add(new Class4856(node.VyMaxBb, node.VyMax));
		}
		if (node.TsL != null)
		{
			smethod_0(node.TsL, elements);
		}
		if (node.TsR != null)
		{
			smethod_0(node.TsR, elements);
		}
	}

	private static RectangleF smethod_1(ArrayList list)
	{
		if (list.Count == 0)
		{
			return RectangleF.Empty;
		}
		Class4856 @class = (Class4856)list[0];
		float num = @class.Rect.Left;
		float num2 = @class.Rect.Top;
		float num3 = @class.Rect.Right;
		float num4 = @class.Rect.Bottom;
		for (int i = 1; i < list.Count; i++)
		{
			Class4856 class2 = (Class4856)list[i];
			num = Math.Min(num, class2.Rect.Left);
			num2 = Math.Min(num2, class2.Rect.Top);
			num3 = Math.Max(num3, class2.Rect.Right);
			num4 = Math.Max(num4, class2.Rect.Bottom);
		}
		return RectangleF.FromLTRB(num, num2, num3, num4);
	}

	private void method_4(Class4852 node, Class4855 xSortedElements, Class4855 ySortedElements)
	{
		int num = Math.Min(int_0, (int)Math.Ceiling((float)xSortedElements.method_6() / 4f));
		while (node.VxMin.Count < num && xSortedElements.method_0())
		{
			Class4856 @class = xSortedElements.method_1();
			@class.Processed = true;
			node.VxMin.Add(@class);
		}
		node.VxMinBb = smethod_1(node.VxMin);
		while (node.VyMin.Count < num && ySortedElements.method_2())
		{
			Class4856 class2 = ySortedElements.method_3();
			class2.Processed = true;
			node.VyMin.Add(class2);
		}
		node.VyMinBb = smethod_1(node.VyMin);
		while (node.VxMax.Count < num && xSortedElements.method_2())
		{
			Class4856 class3 = xSortedElements.method_3();
			class3.Processed = true;
			node.VxMax.Add(class3);
		}
		node.VxMaxBb = smethod_1(node.VxMax);
		while (node.VyMax.Count < num && ySortedElements.method_0())
		{
			Class4856 class4 = ySortedElements.method_1();
			class4.Processed = true;
			node.VyMax.Add(class4);
		}
		node.VyMaxBb = smethod_1(node.VyMax);
		ArrayList arrayList = xSortedElements.method_4(num);
		ArrayList arrayList2 = ySortedElements.method_5();
		xSortedElements.Clear();
		ySortedElements.Clear();
		if (((ArrayList)arrayList[0]).Count > 0)
		{
			node.TsL = new Class4852();
			method_4(node.TsL, new Class4855((ArrayList)arrayList[0]), new Class4855((ArrayList)arrayList2[0]));
		}
		if (((ArrayList)arrayList[1]).Count > 0)
		{
			node.TsR = new Class4852();
			method_4(node.TsR, new Class4855((ArrayList)arrayList[1]), new Class4855((ArrayList)arrayList2[1]));
		}
	}
}
