using ns161;
using ns166;
using ns167;

namespace ns169;

internal class Class4806
{
	internal static void smethod_0(Class4786 sourceSpace)
	{
		Class4811.smethod_1(sourceSpace, Class4860.Instance.RelativeHorizontalProximity);
	}

	internal static void smethod_1(Class4786 sourceSpace)
	{
		if (sourceSpace != null)
		{
			float relativeHorizontalProximity = (float)sourceSpace.OptimalGroupingDistance;
			Class4811.smethod_1(sourceSpace, relativeHorizontalProximity);
		}
	}

	internal static void smethod_2(Class4786 sourceSpace)
	{
		Class4807 @class = new Class4807(sourceSpace);
		sourceSpace.Add(@class.TargetSpace);
		Class4809.smethod_0(sourceSpace);
	}

	internal static void smethod_3(Class4786 sourceSpace)
	{
		smethod_5(sourceSpace);
		for (int i = 0; i < Class4802.MaxNumberOfPasses; i++)
		{
			if (!Class4802.smethod_3(sourceSpace))
			{
				break;
			}
			sourceSpace.Flush();
		}
		smethod_4(sourceSpace);
		smethod_8(sourceSpace);
		for (int j = 0; j < Class4802.MaxNumberOfPasses; j++)
		{
			if ((0u | (Class4802.smethod_0(sourceSpace) ? 1u : 0u) | (Class4802.smethod_3(sourceSpace) ? 1u : 0u)) == 0)
			{
				break;
			}
		}
	}

	internal static bool smethod_4(Class4786 sourceSpace)
	{
		if (sourceSpace == null)
		{
			return false;
		}
		Class4786 @class = new Class4786();
		foreach (Class4845 item in sourceSpace)
		{
			Class4785 class3 = item.Value as Class4785;
			bool flag = false;
			if (class3 != null && class3.LineCount == 2)
			{
				float num = (float)Class4778.smethod_9(class3[0], class3[1]);
				Class4846 class4 = sourceSpace.method_17(item, num, 0f);
				if (!(flag = !class4.method_3() && (double)num / class4.method_1(class3) > 2.0))
				{
					Class4846 class5 = sourceSpace.method_16(item, num, 0f);
					flag = !class4.method_3() && (double)num / class5.method_1(class3) > 2.0;
				}
			}
			if (!flag)
			{
				continue;
			}
			foreach (Class4845 item2 in class3)
			{
				@class.Add(item2.Value);
			}
			item.Remove();
		}
		sourceSpace.Add(@class);
		return !@class.method_21();
	}

	internal static bool smethod_5(Class4786 sourceSpace)
	{
		if (sourceSpace == null)
		{
			return false;
		}
		bool result = false;
		Class4786 @class = new Class4786();
		for (int i = 0; i < sourceSpace.LineCount; i++)
		{
			Class4783 class2 = sourceSpace[i];
			Class4846 class3 = new Class4846();
			bool flag = false;
			for (int j = 1; j < class2.PageElementCount; j++)
			{
				if (class2[j] is Class4791 || class2[j] is Class4784)
				{
					if (!class3.Contains(sourceSpace.method_20(i, j)))
					{
						class3.Clear();
						flag = false;
					}
					if (j != 1)
					{
						flag &= smethod_6(j, i, class3, sourceSpace, goLeft: true);
					}
					flag = (flag &= smethod_6(j, i, class3, sourceSpace, goLeft: false)) | (j == class2.PageElementCount - 1);
					if (!class3.method_3())
					{
						class3.method_10(sourceSpace.method_20(i, j));
					}
				}
				if (flag && !class3.method_3())
				{
					smethod_7(class3, @class, sourceSpace);
				}
			}
		}
		sourceSpace.Add(@class);
		return result;
	}

	internal static bool smethod_6(int elIdx, int lineIdx, Class4846 mergeList, Class4786 sourceSpace, bool goLeft)
	{
		if (sourceSpace == null)
		{
			return false;
		}
		Class4846 @class = (goLeft ? sourceSpace.method_18(sourceSpace.method_20(lineIdx, elIdx), 0f, 1f) : sourceSpace.method_19(sourceSpace.method_20(lineIdx, elIdx), 0f, 1f));
		for (int num = @class.Count - 1; num >= 0; num--)
		{
			if (@class[num].Value is Class4785 && Class4778.smethod_30(@class[num].Value))
			{
				@class.RemoveAt(num);
			}
		}
		return !mergeList.method_9(@class);
	}

	internal static void smethod_7(Class4846 mergeList, Class4786 newElements, Class4786 sourceSpace)
	{
		if (mergeList == null || sourceSpace == null)
		{
			return;
		}
		Class4846 @class = sourceSpace.method_6(mergeList.method_5());
		if (@class == null)
		{
			return;
		}
		@class.Remove(mergeList);
		bool flag = false;
		foreach (Class4845 item in @class)
		{
			if (item.Value is Class4785 && Class4778.smethod_30(item.Value))
			{
				flag = true;
				break;
			}
		}
		if (flag)
		{
			return;
		}
		Class4785 class3 = new Class4785();
		foreach (Class4845 merge in mergeList)
		{
			class3.Add(merge.Value);
			merge.Remove();
		}
		newElements.Add(class3);
	}

	internal static void smethod_8(Class4786 sourceSpace)
	{
		if (sourceSpace == null)
		{
			return;
		}
		foreach (Class4845 item in sourceSpace)
		{
			if (!(item.Value is Class4785) && !(item.Value is Class4790))
			{
				Class4785 class2 = new Class4785();
				class2.Add(item.Value);
				item.Value = class2;
			}
		}
	}
}
