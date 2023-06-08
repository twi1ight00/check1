using System;
using System.Collections;
using System.Drawing;
using ns166;
using ns167;

namespace ns169;

internal class Class4802
{
	private const float float_0 = 2.5f;

	private const int int_0 = 5;

	internal static int MaxNumberOfPasses => 5;

	internal static bool smethod_0(Class4780 sourceSpace)
	{
		return smethod_1(sourceSpace, new Class4846());
	}

	internal static bool smethod_1(Class4780 sourceSpace, Class4846 visitedElements)
	{
		if (sourceSpace == null)
		{
			return false;
		}
		bool flag = false;
		Class4786 @class = new Class4786();
		Class4846 class2 = sourceSpace.method_2(Enum673.const_1, isReverse: false);
		foreach (Class4845 item in class2)
		{
			if (!visitedElements.Contains(item))
			{
				PointF origin = item.Value.Origin;
				bool flag2 = smethod_7(item, sourceSpace, @class, visitedElements, lookUp: false) || smethod_7(item, sourceSpace, @class, visitedElements, lookUp: true);
				if (origin != item.Value.Origin)
				{
					@class.Add(item.Value);
					item.Remove();
				}
				flag = flag || flag2;
			}
		}
		sourceSpace.CopyFrom(@class);
		sourceSpace.Flush();
		return flag;
	}

	internal static bool smethod_2(Class4780 sourceSpace)
	{
		return Class4805.smethod_0(sourceSpace, new Class4846());
	}

	internal static bool smethod_3(Class4780 sourceSpace)
	{
		return smethod_4(sourceSpace, new Class4846());
	}

	internal static bool smethod_4(Class4780 sourceSpace, Class4846 visitedElements)
	{
		if (sourceSpace == null)
		{
			return false;
		}
		bool flag = false;
		Class4846 @class = sourceSpace.method_2(Enum673.const_9, isReverse: true);
		Class4786 class2 = new Class4786();
		foreach (Class4845 item in @class)
		{
			if (item.Value is Class4782 || visitedElements.Contains(item) || !item.Value.CanBeOptimized || item.Value.BoundingBox.IsEmpty)
			{
				continue;
			}
			Class4846 class4 = sourceSpace.method_8(item.Value.BoundingBox, checkForLooseOverlap: false);
			class4.Remove(item);
			smethod_8(class4);
			class4.Remove(visitedElements);
			bool flag2;
			if (flag2 = smethod_17(item, class4))
			{
				foreach (Class4845 item2 in class4)
				{
					if (!smethod_5(item2, class2))
					{
						if (item2.Value is Class4780)
						{
							Class4780 class6 = (Class4780)item2.Value;
							class6.Flush();
						}
						if (!(item2.Value is Class4789))
						{
							class2.Add(item2.Value);
						}
						if (item.Value is Class4780)
						{
							Class4780 class7 = (Class4780)item.Value;
							class7.Flush();
						}
						if (!(item.Value is Class4789))
						{
							class2.Add(item.Value);
						}
					}
					item2.Remove();
					item.Remove();
				}
			}
			flag = flag || flag2;
		}
		sourceSpace.CopyFrom(class2);
		sourceSpace.Flush();
		return flag;
	}

	private static bool smethod_5(Class4845 elPtr, Class4786 newElements)
	{
		bool result = false;
		if (elPtr.Value is Class4784 @class && @class.LineCount == 0)
		{
			Class4846 textSubSuperscriptParts = @class.TextSubSuperscriptParts;
			foreach (Class4845 item in textSubSuperscriptParts)
			{
				result = true;
				newElements.Add(item.Value);
				item.Remove();
			}
		}
		return result;
	}

	internal static void smethod_6(Class4785 source, int index, Class4785 target)
	{
		Class4845 @class = source[index].method_33(0);
		target.Add(@class.Value);
		@class.Remove();
	}

	private static bool smethod_7(Class4845 elPtr, Class4780 sourceSpace, Class4786 decomposedElements, Class4846 visitedElements, bool lookUp)
	{
		bool result = false;
		Class4846 @class = (lookUp ? sourceSpace.method_17(elPtr, 0.3f, 0f) : sourceSpace.method_16(elPtr, 0.3f, 0f));
		smethod_8(@class);
		@class.Remove(visitedElements);
		if (smethod_16(@class, elPtr))
		{
			if (!(elPtr.Value is Class4785 class2))
			{
				throw new InvalidOperationException("Please report exception.");
			}
			Class4779 element = (lookUp ? class2[0][0] : class2[class2.LineCount - 1][0]);
			if (smethod_9(element, @class, out var adjacentBlock, sourceSpace, lookUp))
			{
				class2.Add(adjacentBlock);
				result = true;
				foreach (Class4845 item in @class)
				{
					decomposedElements.Add(item.Value);
					item.Remove();
				}
			}
		}
		return result;
	}

	private static void smethod_8(Class4846 targetCollection)
	{
		Class4846 @class = new Class4846();
		foreach (Class4845 item in targetCollection)
		{
			if (item.Value is Class4782)
			{
				@class.Add(item);
			}
		}
		targetCollection.Remove(@class);
	}

	private static bool smethod_9(Class4779 element, Class4846 sourceBlocks, out Class4785 adjacentBlock, Class4780 sourceSpace, bool lookUp)
	{
		bool result = false;
		adjacentBlock = null;
		ArrayList arrayList = new ArrayList();
		arrayList.Add(element);
		bool flag;
		do
		{
			Class4846 @class = smethod_15(sourceBlocks, lookUp, prevNextFlag: false);
			Class4846 priorNextLine = smethod_15(sourceBlocks, lookUp, prevNextFlag: true);
			if (!(flag = (flag = smethod_12(arrayList, @class)) & ((smethod_13(arrayList, @class) & smethod_11(element, @class, sourceSpace)) | smethod_10(@class, priorNextLine, element))))
			{
				continue;
			}
			result = true;
			if (adjacentBlock == null)
			{
				adjacentBlock = new Class4785();
			}
			arrayList.Clear();
			foreach (Class4845 item in @class)
			{
				arrayList.Add(item.Value);
				item.Remove();
			}
			adjacentBlock.vmethod_2(arrayList);
			smethod_14(sourceBlocks);
		}
		while (flag &= !sourceBlocks.method_3());
		if (adjacentBlock != null)
		{
			adjacentBlock.Remove(element);
		}
		return result;
	}

	private static bool smethod_10(Class4846 nextLine, Class4846 priorNextLine, Class4779 element)
	{
		float num = 0f;
		int num2 = 0;
		float num3 = 0f;
		for (int i = 0; i < nextLine.Count; i++)
		{
			for (int j = 0; j < priorNextLine.Count; j++)
			{
				num2++;
				num += (float)Class4778.smethod_9(nextLine[i].Value, priorNextLine[j].Value);
			}
			num3 += (float)Class4778.smethod_9(nextLine[i].Value, element);
		}
		num3 /= (float)nextLine.Count;
		num /= (float)num2;
		if (num > 1f)
		{
			return num3 < num;
		}
		return false;
	}

	private static bool smethod_11(Class4779 element, Class4846 nextLine, Class4780 sourceSpace)
	{
		bool result = true;
		RectangleF rectangleF = element.BoundingBox;
		foreach (Class4845 item in nextLine)
		{
			rectangleF = RectangleF.Union(rectangleF, item.Value.Parent.BoundingBox);
		}
		Class4846 class2 = sourceSpace.method_9(rectangleF, 0.001f);
		foreach (Class4845 item2 in class2)
		{
			if (!(item2.Value is Class4780))
			{
				continue;
			}
			Class4780 class4 = (Class4780)item2.Value;
			if (Class4778.smethod_30(item2.Value))
			{
				if (class4.ChildrenCount >= 2)
				{
					result = false;
					break;
				}
			}
			else if (class4.LineCount >= 3)
			{
				result = false;
				break;
			}
		}
		return result;
	}

	private static bool smethod_12(ArrayList adjacentElements, Class4846 nextLine)
	{
		bool result = !nextLine.method_3();
		foreach (Class4779 adjacentElement in adjacentElements)
		{
			foreach (Class4845 item in nextLine)
			{
				if (!Class4778.smethod_32(adjacentElement, item.Value))
				{
					result = false;
					break;
				}
			}
		}
		return result;
	}

	private static bool smethod_13(ArrayList adjacentElements, Class4846 nextLine)
	{
		bool result;
		if (result = !nextLine.method_3() && adjacentElements.Count != 0)
		{
			Class4845 @class = null;
			ArrayList arrayList = new ArrayList();
			foreach (Class4845 item in nextLine)
			{
				if (@class != null)
				{
					double num = Class4778.smethod_7(item.Value, @class.Value);
					arrayList.Add(num);
				}
				@class = item;
			}
			if (arrayList.Count != 0)
			{
				double num2 = Class4816.smethod_0(arrayList);
				result = num2 == 0.0 || num2 / 0.30000001192092896 <= 2.5;
			}
		}
		return result;
	}

	private static void smethod_14(Class4846 sourceBlocks)
	{
		Class4846 @class = new Class4846();
		foreach (Class4845 sourceBlock in sourceBlocks)
		{
			if (sourceBlock.Value is Class4785 class3)
			{
				class3.Flush();
				if (class3.method_21())
				{
					sourceBlock.Remove();
					@class.Add(sourceBlock);
				}
			}
		}
		sourceBlocks.Remove(@class);
	}

	private static Class4846 smethod_15(Class4846 sourceBlocks, bool lookUp, bool prevNextFlag)
	{
		Class4846 @class = new Class4846();
		foreach (Class4845 sourceBlock in sourceBlocks)
		{
			if (sourceBlock.Value is Class4785 class3)
			{
				if (class3.ChildrenCount == 0)
				{
					sourceBlock.Remove();
					continue;
				}
				if (prevNextFlag)
				{
					if (lookUp)
					{
						if (class3.LineCount - 2 >= 0)
						{
							@class.Add(class3[class3.LineCount - 2].method_33(0));
						}
					}
					else if (class3.LineCount > 1)
					{
						@class.Add(class3[1].method_33(0));
					}
				}
				else if (lookUp)
				{
					@class.Add(class3[class3.LineCount - 1].method_33(0));
				}
				else
				{
					@class.Add(class3[0].method_33(0));
				}
			}
			if (sourceBlock.Value is Class4790)
			{
				@class.Add(sourceBlock);
			}
		}
		return @class;
	}

	private static bool smethod_16(Class4846 neighbors, Class4845 elPtr)
	{
		bool flag = true;
		RectangleF rectangleF = neighbors.method_5();
		foreach (Class4845 neighbor in neighbors)
		{
			if (Class4778.smethod_30(neighbor.Value) || !(Class4778.smethod_31(neighbor.Value) <= 1f))
			{
				flag = false;
				break;
			}
		}
		if (flag)
		{
			if (elPtr.Value is Class4785)
			{
				if (!Class4778.smethod_20(elPtr.Value.BoundingBox, rectangleF))
				{
					return Class4778.smethod_20(rectangleF, elPtr.Value.BoundingBox);
				}
				return true;
			}
			return false;
		}
		return false;
	}

	private static bool smethod_17(Class4845 elPtr, Class4846 neighbors)
	{
		bool result = false;
		foreach (Class4845 neighbor in neighbors)
		{
			if (!neighbor.Value.CanBeOptimized)
			{
				continue;
			}
			RectangleF region = RectangleF.Intersect(elPtr.Value.BoundingBox, neighbor.Value.BoundingBox);
			if (!region.IsEmpty && neighbor.Value is Class4780)
			{
				Class4780 class2 = (Class4780)neighbor.Value;
				Class4846 neighbors2 = class2.method_6(region);
				if (result = smethod_17(elPtr, neighbors2))
				{
					class2.Flush();
					neighbor.Value = class2;
				}
			}
		}
		return result;
	}
}
