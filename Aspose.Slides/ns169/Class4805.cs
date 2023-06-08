using System;
using System.Collections;
using ns166;
using ns167;

namespace ns169;

internal class Class4805
{
	private const float float_0 = 1.1f;

	private const float float_1 = 0.15f;

	private const float float_2 = 1.5f;

	private const double double_0 = 0.65;

	private const float float_3 = 1.3f;

	internal static bool smethod_0(Class4780 sourceSpace, Class4846 visitedElements)
	{
		if (sourceSpace == null)
		{
			return false;
		}
		bool result = false;
		Class4780 @class = new Class4780();
		foreach (Class4845 item in sourceSpace)
		{
			if (!(item.Value is Class4785) || visitedElements.Contains(item))
			{
				continue;
			}
			Class4785 class3 = (Class4785)item.Value;
			class3.Flush();
			ArrayList arrayList = smethod_1(class3);
			foreach (Class4779 item2 in arrayList)
			{
				@class.Add(item2);
			}
			item.Remove();
			if (arrayList.Count > 1)
			{
				result = true;
			}
		}
		sourceSpace.CopyFrom(@class);
		return result;
	}

	internal static ArrayList smethod_1(Class4785 source)
	{
		return smethod_2(source, splitLargeInterval: false);
	}

	internal static ArrayList smethod_2(Class4785 source, bool splitLargeInterval)
	{
		if (source == null)
		{
			return null;
		}
		ArrayList arrayList = new ArrayList();
		if (source.ChildrenCount != 0)
		{
			ArrayList arrayList2 = smethod_7(source, 0, source.LineCount - 1);
			source.Flush();
			if (!source.method_21())
			{
				foreach (Class4845 item in source)
				{
					Class4785 class2 = new Class4785();
					class2.Add(item.Value);
					item.Remove();
					arrayList2.Add(class2);
				}
			}
			arrayList.AddRange(arrayList2);
		}
		smethod_4(arrayList);
		if (!splitLargeInterval)
		{
			return arrayList;
		}
		return smethod_3(arrayList, 1.3f);
	}

	internal static ArrayList smethod_3(ArrayList blocks, float maxInterval)
	{
		if (blocks == null)
		{
			return null;
		}
		ArrayList arrayList = new ArrayList(blocks.Count);
		foreach (Class4785 block in blocks)
		{
			if (block.LineCount != 1)
			{
				for (int i = 1; i < block.LineCount; i++)
				{
					Class4785 class2 = new Class4785();
					class2.Add(block[i - 1][0]);
					bool flag;
					while (flag = block[i].Origin.Y - block[i - 1].Origin.Y < maxInterval * block.FontSize)
					{
						class2.Add(block[i][0]);
						i++;
						if (i == block.LineCount || !flag)
						{
							break;
						}
					}
					arrayList.Add(class2);
					if (!flag && i == block.LineCount - 1)
					{
						class2 = new Class4785();
						class2.Add(block[i][0]);
						arrayList.Add(class2);
					}
				}
			}
			else
			{
				arrayList.Add(block);
			}
		}
		return arrayList;
	}

	internal static void smethod_4(ArrayList sources)
	{
		if (sources == null)
		{
			return;
		}
		ArrayList arrayList = new ArrayList();
		ArrayList arrayList2 = new ArrayList();
		for (int i = 0; i < sources.Count; i++)
		{
			Class4785 @class = (Class4785)sources[i];
			if (@class.LineCount == 1)
			{
				continue;
			}
			ArrayList arrayList3;
			if (@class.LineCount == 2)
			{
				arrayList3 = new ArrayList();
				if (smethod_5(@class))
				{
					Class4785 class2 = new Class4785();
					Class4802.smethod_6(@class, 0, class2);
					arrayList3.Add(class2);
					Class4785 class3 = new Class4785();
					Class4802.smethod_6(@class, 1, class3);
					arrayList3.Add(class3);
				}
				else
				{
					arrayList3.Add(@class);
				}
			}
			else
			{
				arrayList3 = smethod_6(@class);
			}
			arrayList2.Add(i);
			arrayList.AddRange(arrayList3);
		}
		for (int num = arrayList2.Count - 1; num >= 0; num--)
		{
			sources.RemoveAt((int)arrayList2[num]);
		}
		sources.AddRange(arrayList);
	}

	internal static bool smethod_5(Class4785 el)
	{
		if (el == null)
		{
			throw new ArgumentException();
		}
		bool flag;
		if (!(flag = el[1].BoundingBox.Width / el[0].BoundingBox.Width > 1.1f))
		{
			flag |= Math.Abs(el[0].FontSize - el[1].FontSize) >= 1.5f || el[0].FontFace != el[1].FontFace;
		}
		return flag;
	}

	internal static ArrayList smethod_6(Class4785 source)
	{
		if (source == null)
		{
			return null;
		}
		ArrayList arrayList = new ArrayList();
		ArrayList arrayList2 = new ArrayList();
		for (int i = 0; i < source.LineCount; i++)
		{
			arrayList2.Add((double)source[i].BoundingBox.Width / (double)source.BoundingBox.Width);
		}
		float num = source[0].BoundingBox.Left - source.BoundingBox.Left;
		arrayList2[0] = (double)arrayList2[0] + (double)(num / source.BoundingBox.Width);
		double mean;
		double std;
		double num2 = Class4816.smethod_2(arrayList2, out mean, out std);
		if (num2 > 0.65)
		{
			Class4785 @class = new Class4785();
			Class4802.smethod_6(source, 0, @class);
			arrayList.Add(@class);
			source.Flush();
			ArrayList arrayList3 = new ArrayList(1);
			arrayList3.Add(source);
			smethod_4(arrayList3);
			arrayList.AddRange(arrayList3);
		}
		else
		{
			double num3 = mean / 1.100000023841858;
			int num4 = 0;
			for (int j = 0; j < source.LineCount; j++)
			{
				if ((double)arrayList2[j] < num3)
				{
					Class4785 class2 = new Class4785();
					for (int k = num4; k < j + 1; k++)
					{
						Class4802.smethod_6(source, k, class2);
					}
					num4 = j + 1;
					arrayList.Add(class2);
				}
			}
			source.Flush();
			if (source.ChildrenCount != 0)
			{
				arrayList.Add(source);
			}
		}
		return arrayList;
	}

	internal static ArrayList smethod_7(Class4785 source, int subblockStartIndex, int subblockEndIndex)
	{
		if (source == null)
		{
			return null;
		}
		ArrayList arrayList = new ArrayList();
		if (subblockEndIndex - subblockStartIndex <= 1)
		{
			Class4785 @class = new Class4785();
			Class4802.smethod_6(source, subblockStartIndex, @class);
			if (subblockEndIndex - subblockStartIndex == 1)
			{
				Class4802.smethod_6(source, subblockEndIndex, @class);
			}
			arrayList.Add(@class);
		}
		else
		{
			ArrayList arrayList2 = source.method_33(subblockStartIndex, subblockEndIndex + 1);
			int index;
			double y = Class4812.smethod_4(arrayList2, out index);
			Class4785 class2 = new Class4785();
			Class4802.smethod_6(source, subblockStartIndex + index, class2);
			Class4802.smethod_6(source, subblockStartIndex + index + 1, class2);
			arrayList.Add(class2);
			double num = class2.FontSize;
			int num2 = 0;
			int num3 = 0;
			for (int i = 0; i < 2; i++)
			{
				int num4 = 0;
				bool flag;
				do
				{
					num4++;
					int num5 = ((i != 0) ? (subblockStartIndex + index + num4) : (subblockStartIndex + index - num4));
					if (flag = num5 >= subblockStartIndex && num5 < subblockEndIndex)
					{
						if (i == 0)
						{
							num2 = num4;
						}
						else
						{
							num3 = num4;
						}
						if (!Class4778.smethod_1((double)arrayList2[num5 - subblockStartIndex], y, 0.15000000596046448 * num) && !(source[num5][0] is Class4790) && !(source[subblockStartIndex][0] is Class4790))
						{
							break;
						}
						Class4802.smethod_6(source, num5 + i, class2);
					}
				}
				while (flag);
			}
			int num6 = subblockStartIndex + index - num2;
			if (num6 > subblockStartIndex)
			{
				arrayList.AddRange(smethod_7(source, subblockStartIndex, num6));
			}
			int num7 = subblockStartIndex + index + num3 + 1;
			if (num7 < subblockEndIndex)
			{
				arrayList.AddRange(smethod_7(source, num7, subblockEndIndex));
			}
		}
		return arrayList;
	}
}
