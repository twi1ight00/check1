using System;
using System.Collections;
using System.Drawing;
using ns166;
using ns167;

namespace ns169;

internal class Class4804
{
	private const float float_0 = 0.25f;

	internal static void smethod_0(Class4782 node)
	{
		Class4846 visitedElements = new Class4846();
		smethod_1(node, visitedElements);
	}

	internal static void smethod_1(Class4782 node, Class4846 visitedElements)
	{
		if (node == null)
		{
			return;
		}
		foreach (Class4845 item in node)
		{
			if (!visitedElements.Contains(item) && item.Value.CanBeOptimized && item.Value is Class4782)
			{
				smethod_0((Class4782)item.Value);
			}
		}
		if (node.CanBeOptimized)
		{
			smethod_5(node, visitedElements);
		}
	}

	internal static void smethod_2(Class4782 node)
	{
		if (node == null)
		{
			return;
		}
		Class4846 @class = new Class4846();
		foreach (Class4845 item in node)
		{
			if (!@class.Contains(item) && item.Value.CanBeOptimized && item.Value is Class4782)
			{
				smethod_2((Class4782)item.Value);
			}
		}
		if (!node.CanBeOptimized)
		{
			return;
		}
		bool flag;
		do
		{
			flag = false;
			if (flag = false | smethod_6(node, @class, simple: true))
			{
				node.Flush();
			}
		}
		while (flag);
		smethod_10(node, @class);
		smethod_11(node, @class);
	}

	internal static Class4779 smethod_3(Class4779 node, ref bool found)
	{
		if (node == null)
		{
			return null;
		}
		Class4779 result = null;
		while (node.Parent != null && !found)
		{
			if (!(node.Parent is Class4782))
			{
				result = smethod_3(node.Parent, ref found);
				continue;
			}
			found = true;
			result = node.Parent;
			break;
		}
		return result;
	}

	internal static Class4785 smethod_4(Class4782 node)
	{
		if (node == null)
		{
			return null;
		}
		Class4785 @class = new Class4785();
		foreach (Class4845 item in node)
		{
			if (item.Value is Class4782)
			{
				Class4782 node2 = (Class4782)item.Value;
				Class4785 element = smethod_4(node2);
				@class.Add(element);
			}
			else
			{
				@class.Add(item.Value);
			}
		}
		return @class;
	}

	private static void smethod_5(Class4782 node, Class4846 visitedElements)
	{
		bool flag;
		do
		{
			flag = false;
			if (flag = (flag = (flag = (flag = (flag = (flag = false | smethod_23(node, visitedElements)) | smethod_6(node, visitedElements, simple: false)) | smethod_21(node, visitedElements)) | smethod_8(node, visitedElements)) | smethod_12(node, visitedElements)) | smethod_13(node, visitedElements))
			{
				node.Flush();
			}
		}
		while (flag);
		smethod_10(node, visitedElements);
		smethod_11(node, visitedElements);
	}

	private static bool smethod_6(Class4782 node, Class4846 visitedElements, bool simple)
	{
		bool result = false;
		foreach (Class4845 item in node)
		{
			if (visitedElements.Contains(item) || item.Value is Class4782 || !item.Value.CanBeOptimized)
			{
				continue;
			}
			Class4780 class2 = item.Value as Class4780;
			if (class2 == null)
			{
				continue;
			}
			Class4846 class3 = node.method_16(item, 0.25f, 0f);
			if (class3.Count != 1 || class3[0].Value is Class4782 || class3[0].Value is Class4784 || !class3[0].Value.CanBeOptimized)
			{
				continue;
			}
			Class4846 class4 = node.method_6(RectangleF.Union(class2.BoundingBox, class3[0].Value.BoundingBox));
			if (class4.Count > 2)
			{
				continue;
			}
			float num = Math.Max(class4[0].Value.BoundingBox.Height, class4[1].Value.BoundingBox.Height);
			float num2 = Math.Min(class4[0].Value.BoundingBox.Height, class4[1].Value.BoundingBox.Height);
			if (!simple || (double)(num / num2) < 2.5)
			{
				if (class2 is Class4784)
				{
					class2 = smethod_7(class2, item, node);
				}
				result = true;
				class2.Add(class3[0].Value);
				class3[0].Remove();
			}
		}
		return result;
	}

	private static Class4780 smethod_7(Class4780 el, Class4845 elPtr, Class4782 node)
	{
		Class4779 element = el;
		Class4785 @class = new Class4785();
		@class.Parent = node;
		@class.Add(element);
		elPtr.Value = @class;
		el = (Class4780)elPtr.Value;
		return el;
	}

	private static bool smethod_8(Class4782 node, Class4846 visitedElements)
	{
		node.Flush();
		bool result = false;
		Enum673 dimension = ((!node.IsColumnwise) ? Enum673.const_1 : Enum673.const_3);
		Class4846 @class = node.method_2(dimension, isReverse: false);
		foreach (Class4845 item in @class)
		{
			if (!item.Value.CanBeOptimized || visitedElements.Contains(item))
			{
				continue;
			}
			Class4846 class3;
			if (node.IsColumnwise)
			{
				class3 = node.method_18(item, node.BoundingBox.Width, 0f);
				class3.method_9(node.method_19(item, node.BoundingBox.Width, 0f));
			}
			else
			{
				class3 = node.method_17(item, 0f, node.BoundingBox.Height);
				class3.method_9(node.method_16(item, 0f, node.BoundingBox.Height));
			}
			class3.Remove(visitedElements);
			foreach (Class4845 item2 in class3)
			{
				if (item2.Value.CanBeOptimized && smethod_9(item2, item, node.IsColumnwise))
				{
					result = true;
					break;
				}
			}
		}
		return result;
	}

	private static bool smethod_9(Class4845 sourcePtr, Class4845 targetPtr, bool goVertical)
	{
		bool result = false;
		if (targetPtr.Value is Class4782 && (goVertical ? Class4778.smethod_17(targetPtr.Value, sourcePtr.Value) : Class4778.smethod_21(targetPtr.Value, sourcePtr.Value)))
		{
			((Class4782)targetPtr.Value).Add(sourcePtr.Value);
			sourcePtr.Remove();
			result = true;
		}
		return result;
	}

	private static void smethod_10(Class4782 node, Class4846 visitedElements)
	{
		Class4846 @class = node.method_2(Enum673.const_1, isReverse: false);
		foreach (Class4845 item in @class)
		{
			if (visitedElements.Contains(item) || !item.Value.CanBeOptimized)
			{
				continue;
			}
			Class4846 class3 = node.method_18(item, 0f, node.BoundingBox.Width);
			class3.Remove(visitedElements);
			foreach (Class4845 item2 in class3)
			{
				if (item2.Value.CanBeOptimized && item.Value is Class4782 && item2.Value is Class4785)
				{
					Class4782 class5 = (Class4782)item.Value;
					if (class5.IsColumnwise)
					{
						class5.Add(item2.Value);
						item2.Remove();
					}
				}
			}
		}
	}

	private static void smethod_11(Class4782 node, Class4846 visitedElements)
	{
		Class4846 @class = node.method_2(Enum673.const_3, isReverse: false);
		foreach (Class4845 item in @class)
		{
			if (visitedElements.Contains(item) || !item.Value.CanBeOptimized)
			{
				continue;
			}
			Class4846 class3 = node.method_19(item, 0f, node.BoundingBox.Width);
			class3.Remove(visitedElements);
			foreach (Class4845 item2 in class3)
			{
				if (!item2.Value.CanBeOptimized || !(item.Value is Class4782) || !(item2.Value is Class4782))
				{
					continue;
				}
				Class4782 class5 = (Class4782)item.Value;
				Class4782 class6 = (Class4782)item2.Value;
				if (!class5.IsColumnwise || !class6.IsColumnwise)
				{
					continue;
				}
				foreach (Class4845 item3 in class6)
				{
					class5.Add(item3.Value);
					item3.Remove();
				}
				item2.Remove();
			}
		}
	}

	private static bool smethod_12(Class4782 node, Class4846 visitedElements)
	{
		bool result = false;
		Enum673 dimension = ((!node.IsColumnwise) ? Enum673.const_1 : Enum673.const_3);
		Class4846 @class = node.method_2(dimension, isReverse: false);
		foreach (Class4845 item in @class)
		{
			if (visitedElements.Contains(item) || !item.Value.CanBeOptimized)
			{
				continue;
			}
			Class4846 class3 = (node.IsColumnwise ? node.method_19(item, 0f, node.BoundingBox.Width) : node.method_16(item, node.BoundingBox.Height, 0f));
			class3.Remove(visitedElements);
			foreach (Class4845 item2 in class3)
			{
				if (item2.Value.CanBeOptimized)
				{
					bool flag = false;
					if (item.Value is Class4782 && item2.Value is Class4782)
					{
						result = smethod_15(item, item2, node);
					}
					else if (!(item.Value is Class4782) && !(item2.Value is Class4782) && !node.IsColumnwise)
					{
						flag = Class4778.smethod_34(item.Value, item2.Value) || smethod_20(item.Value, item2.Value);
					}
					if (flag)
					{
						result = smethod_19(item, item2);
					}
				}
			}
		}
		return result;
	}

	private static bool smethod_13(Class4782 node, Class4846 visitedElements)
	{
		bool result = false;
		foreach (Class4845 item in node)
		{
			if (visitedElements.Contains(item) || !(item.Value is Class4782))
			{
				continue;
			}
			Class4780 class2 = null;
			Class4846 class3 = node.method_16(item, 0.5f, 0f);
			if (class3.Count == 1 && class3[0].Value is Class4785)
			{
				foreach (Class4845 item2 in (Class4782)item.Value)
				{
					if (Class4778.smethod_17(item2.Value, class3[0].Value))
					{
						class2 = item2.Value as Class4780;
						break;
					}
				}
			}
			if (class2 == null)
			{
				continue;
			}
			foreach (Class4845 item3 in (Class4785)class3[0].Value)
			{
				if (Class4778.smethod_10(item3.Value, class2))
				{
					class2.Add(item3.Value);
					item3.Remove();
					result = true;
				}
			}
		}
		return result;
	}

	private static bool smethod_14(Class4782 el1, Class4782 el2)
	{
		bool result = true;
		Class4846 @class = el1.method_2(Enum673.const_3, isReverse: false);
		Class4846 class2 = el2.method_2(Enum673.const_3, isReverse: false);
		int num = 0;
		foreach (Class4845 item in @class)
		{
			if (!Class4778.smethod_27(item.Value, class2[num++].Value))
			{
				result = false;
				break;
			}
		}
		return result;
	}

	private static bool smethod_15(Class4845 elPtr, Class4845 neighborPtr, Class4782 node)
	{
		bool result = false;
		Class4782 @class = (Class4782)elPtr.Value;
		Class4782 class2 = (Class4782)neighborPtr.Value;
		if (@class.IsColumnwise && class2.IsColumnwise && @class.ChildrenCount == class2.ChildrenCount && smethod_14(@class, class2))
		{
			Class4782 class3 = new Class4782(isColumnwise: true);
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < @class.ChildrenCount; i++)
			{
				Class4782 value = new Class4782(isColumnwise: false);
				arrayList.Add(value);
			}
			smethod_16(@class, arrayList);
			smethod_16(class2, arrayList);
			foreach (Class4782 item in arrayList)
			{
				class3.Add(item);
			}
			if (!smethod_17(class3) && !smethod_18(class3, node, elPtr, neighborPtr))
			{
				neighborPtr.Remove();
				elPtr.Value = class3;
				result = true;
			}
		}
		return result;
	}

	private static void smethod_16(Class4782 element, ArrayList composites)
	{
		int num = -1;
		Class4846 @class = element.method_2(Enum673.const_3, isReverse: false);
		foreach (Class4845 item in @class)
		{
			num++;
			Class4782 class3 = (Class4782)composites[num];
			class3.Add(item.Value);
		}
	}

	private static bool smethod_17(Class4782 el)
	{
		bool result = false;
		Class4846 @class = el.method_2(Enum673.const_3, isReverse: false);
		Class4845 class2 = null;
		foreach (Class4845 item in @class)
		{
			if (class2 == null)
			{
				class2 = item;
			}
			else if (Class4778.smethod_33(class2.Value, item.Value))
			{
				result = true;
				break;
			}
		}
		return result;
	}

	private static bool smethod_18(Class4782 el, Class4782 parent, Class4845 elPtr, Class4845 neighborPtr)
	{
		Class4846 @class = parent.method_6(el.BoundingBox);
		@class.Remove(elPtr);
		@class.Remove(neighborPtr);
		return !@class.method_3();
	}

	private static bool smethod_19(Class4845 elPtr, Class4845 neighborPtr)
	{
		bool result = false;
		Class4785 @class;
		if (elPtr.Value is Class4785)
		{
			@class = (Class4785)elPtr.Value;
		}
		else
		{
			@class = new Class4785();
			Class4779 parent = elPtr.Value.Parent;
			if (@class.Add(elPtr.Value))
			{
				elPtr.Value = @class;
				@class.Parent = parent;
				result = true;
			}
		}
		if (@class.Add(neighborPtr.Value))
		{
			neighborPtr.Remove();
			result = true;
		}
		return result;
	}

	private static bool smethod_20(Class4779 el, Class4779 neighbor)
	{
		bool flag = false;
		if (neighbor is Class4785 @class)
		{
			if (el is Class4785)
			{
				float meanLineSpacing = @class.MeanLineSpacing;
				flag = meanLineSpacing != 0f && (double)meanLineSpacing >= Class4778.smethod_9(el, neighbor);
			}
			else if (el is Class4784)
			{
				float meanLineSpacing2 = @class.MeanLineSpacing;
				flag = (double)meanLineSpacing2 >= Class4778.smethod_9(el, neighbor) && Class4778.smethod_28(el, neighbor);
			}
		}
		return flag & (neighbor.FontSize == el.FontSize);
	}

	private static bool smethod_21(Class4782 node, Class4846 visitedElements)
	{
		bool result = false;
		foreach (Class4845 item in node)
		{
			if (!visitedElements.Contains(item) && item.Value is Class4782)
			{
				Class4782 class2 = (Class4782)item.Value;
				if (class2.ChildrenCount == 1)
				{
					item.Value = class2[0][0];
					item.Value.Parent = node;
					result = true;
				}
			}
		}
		return result;
	}

	private static void smethod_22(Class4782 node)
	{
		ArrayList arrayList = new ArrayList();
		ArrayList arrayList2 = new ArrayList();
		foreach (Class4845 item in node)
		{
			if (item.Value is Class4784)
			{
				arrayList.Add(item);
				continue;
			}
			if (item.Value is Class4785 class2 && class2.ChildrenCount == 1)
			{
				bool flag = false;
				foreach (Class4845 item2 in class2)
				{
					if (item2.Value is Class4784)
					{
						arrayList.Add(item);
						flag = true;
						break;
					}
				}
				if (flag)
				{
					continue;
				}
			}
			arrayList2.Add(item);
		}
		ArrayList arrayList3 = new ArrayList();
		for (int i = 0; i < arrayList.Count; i++)
		{
			Class4845 class4 = (Class4845)arrayList[i];
			if (i == 0)
			{
				ArrayList arrayList4 = new ArrayList();
				arrayList4.Add(class4);
				arrayList3.Add(arrayList4);
				continue;
			}
			bool flag2 = false;
			foreach (ArrayList item3 in arrayList3)
			{
				Class4779 value = ((Class4845)item3[0]).Value;
				Class4779 value2 = class4.Value;
				if (Class4778.smethod_0(value.Origin.Y, value2.Origin.Y))
				{
					flag2 = true;
					item3.Add(class4);
					break;
				}
			}
			if (!flag2)
			{
				ArrayList arrayList6 = new ArrayList();
				arrayList6.Add(class4);
				arrayList3.Add(arrayList6);
			}
		}
		foreach (ArrayList item4 in arrayList3)
		{
			if (item4.Count < 2)
			{
				continue;
			}
			Class4785 class5 = new Class4785();
			for (int j = 0; j < item4.Count; j++)
			{
				Class4845 class6 = (Class4845)item4[j];
				if (j == 0)
				{
					class5.Add(class6.Value);
					class6.Remove();
					continue;
				}
				RectangleF rectangleF = RectangleF.Union(class5.BoundingBox, class6.Value.BoundingBox);
				foreach (Class4845 item5 in arrayList2)
				{
					if (rectangleF.IntersectsWith(item5.Value.BoundingBox))
					{
						node.Add(class5);
						class5 = new Class4785();
						break;
					}
				}
				class5.Add(class6.Value);
				class6.Remove();
			}
			if (class5.ChildrenCount > 0)
			{
				node.Add(class5);
			}
		}
	}

	private static bool smethod_23(Class4782 node, Class4846 visitedElements)
	{
		bool result = false;
		foreach (Class4845 item in node)
		{
			if (visitedElements.Contains(item) || !(item.Value is Class4782) || !item.Value.CanBeOptimized)
			{
				continue;
			}
			Class4782 class2 = (Class4782)item.Value;
			if (smethod_25(class2))
			{
				Class4785 class3 = new Class4785();
				class3.Parent = class2.Parent;
				foreach (Class4845 item2 in class2)
				{
					class3.Add(item2.Value);
					item2.Remove();
				}
				item.Value = class3;
				result = true;
			}
			else
			{
				smethod_22(class2);
			}
		}
		return result;
	}

	private static bool smethod_24(Class4782 node)
	{
		foreach (Class4845 item in node)
		{
			if (item.Value is Class4790)
			{
				continue;
			}
			if (item.Value is Class4785 class2 && class2.ChildrenCount > 0)
			{
				foreach (Class4845 item2 in class2)
				{
					if (!(item2.Value is Class4790))
					{
						return false;
					}
				}
				continue;
			}
			return false;
		}
		return true;
	}

	private static bool smethod_25(Class4782 node)
	{
		bool flag = node.IsColumnwise && Class4778.smethod_40(node[0][0]) && node.method_38();
		foreach (Class4845 item in node)
		{
			if (item.Value is Class4785 || item.Value is Class4782 || !((double)Class4778.smethod_31(item.Value) < 3.5))
			{
				flag = false;
				break;
			}
		}
		if (!flag)
		{
			flag = node.ChildrenCount >= 2 && node.method_39() && !smethod_24(node);
		}
		return flag;
	}
}
