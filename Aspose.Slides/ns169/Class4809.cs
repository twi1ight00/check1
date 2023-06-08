using System;
using System.Collections;
using System.Drawing;
using ns166;
using ns167;

namespace ns169;

internal class Class4809
{
	internal const float float_0 = 0.34f;

	internal const float float_1 = 1f;

	internal const int int_0 = 3;

	internal static void smethod_0(Class4786 textSpace)
	{
		if (textSpace != null)
		{
			bool flag;
			do
			{
				flag = false;
				flag = false | smethod_1(textSpace, 1f);
				textSpace.Flush();
				flag = (flag = (flag |= smethod_4(textSpace)) | smethod_5(textSpace)) | smethod_1(textSpace, 2f);
				textSpace.Flush();
			}
			while (flag);
		}
	}

	internal static bool smethod_1(Class4786 textSpace, float maxLookupRelativeDistance)
	{
		if (textSpace == null)
		{
			return false;
		}
		bool flag = false;
		Class4846 @class = new Class4846();
		Class4786 class2 = new Class4786();
		foreach (Class4845 item in textSpace)
		{
			@class.Clear();
			smethod_9(@class, item, textSpace, maxLookupRelativeDistance);
			if (!@class.method_3())
			{
				ArrayList oldOrigins = smethod_3(@class);
				@class.method_6(item);
				bool flag2;
				if (flag2 = smethod_10(@class))
				{
					smethod_2(class2, oldOrigins, @class);
				}
				flag = flag || flag2;
			}
		}
		if (!class2.method_21())
		{
			textSpace.Add(class2);
		}
		return flag;
	}

	internal static void smethod_2(Class4786 toReinsert, ArrayList oldOrigins, Class4846 mergedElements)
	{
		if (oldOrigins == null)
		{
			return;
		}
		for (int i = 0; i < oldOrigins.Count; i++)
		{
			Class4845 @class = mergedElements[i];
			if (!(@class.Value is Class4789) && @class.Value.Origin != (PointF)oldOrigins[i])
			{
				toReinsert.Add(@class.Value);
				@class.Remove();
			}
		}
	}

	internal static ArrayList smethod_3(Class4846 mergeCandidates)
	{
		if (mergeCandidates == null)
		{
			return null;
		}
		ArrayList arrayList = new ArrayList(mergeCandidates.Count);
		for (int i = 0; i < mergeCandidates.Count; i++)
		{
			arrayList.Add(mergeCandidates[i].Value.Origin);
		}
		return arrayList;
	}

	internal static bool smethod_4(Class4786 textSpace)
	{
		if (textSpace == null)
		{
			return false;
		}
		bool flag = false;
		Class4786 @class = new Class4786();
		foreach (Class4845 item in textSpace)
		{
			if (!(item.Value is Class4785))
			{
				continue;
			}
			Class4785 class3 = (Class4785)item.Value;
			bool flag2 = false;
			Class4846 class4 = textSpace.method_16(item, 0f, 0f);
			PointF origin = class3.Origin;
			foreach (Class4845 item2 in class4)
			{
				Class4779 value = item2.Value;
				if (Class4778.smethod_37(value, class3))
				{
					class3.Add(value);
					item2.Remove();
					flag2 = true;
				}
			}
			if (origin != class3.Origin)
			{
				@class.Add(class3);
				item.Remove();
			}
			flag = flag || flag2;
		}
		if (!@class.method_21())
		{
			textSpace.Add(@class);
		}
		return flag;
	}

	internal static bool smethod_5(Class4786 textSpace)
	{
		if (textSpace == null)
		{
			return false;
		}
		Class4786 @class = new Class4786();
		bool flag = false;
		foreach (Class4845 item in textSpace)
		{
			if (!(item.Value is Class4785))
			{
				continue;
			}
			Class4785 class3 = (Class4785)item.Value;
			PointF origin = class3.Origin;
			bool flag2 = false;
			Class4846 class4 = textSpace.method_16(item, 0f, 0f);
			foreach (Class4845 item2 in class4)
			{
				PointF origin2 = item2.Value.Origin;
				if (Class4778.smethod_15(item2.Value, class3))
				{
					flag2 = smethod_6(class3, item2);
				}
				if (item2.Value.Origin != origin2)
				{
					@class.Add(item2.Value);
					item2.Remove();
				}
			}
			if (item.Value.Origin != origin)
			{
				@class.Add(item.Value);
				item.Remove();
			}
			flag = flag || flag2;
		}
		if (!@class.method_21())
		{
			textSpace.Add(@class);
		}
		return flag;
	}

	internal static bool smethod_6(Class4785 primaryBlock, Class4845 testedEl)
	{
		if (testedEl == null)
		{
			return false;
		}
		bool result = false;
		if (testedEl.Value is Class4785)
		{
			Class4785 testedEl2 = (Class4785)testedEl.Value;
			result = smethod_7(primaryBlock, testedEl2);
		}
		else
		{
			if (!(testedEl.Value is Class4784) && !(testedEl.Value is Class4791))
			{
				throw new InvalidOperationException("Please report exception. Unknown PageElement found in FitLoosePageElementsTogether method.");
			}
			if (smethod_8(primaryBlock, testedEl.Value))
			{
				testedEl.Remove();
				result = true;
			}
		}
		return result;
	}

	internal static bool smethod_7(Class4785 primaryBlock, Class4785 testedEl)
	{
		if (primaryBlock == null)
		{
			return false;
		}
		bool flag = false;
		double num = primaryBlock.BoundingBox.Height * primaryBlock.BoundingBox.Width;
		double num2 = testedEl.BoundingBox.Height * testedEl.BoundingBox.Width;
		Class4785 targetEl;
		Class4785 @class;
		if (num2 > num)
		{
			targetEl = testedEl;
			@class = primaryBlock;
		}
		else
		{
			targetEl = primaryBlock;
			@class = testedEl;
		}
		foreach (Class4845 item in @class)
		{
			if (smethod_8(targetEl, item.Value))
			{
				item.Remove();
				flag = true;
			}
		}
		if (flag)
		{
			@class.Flush();
		}
		return flag;
	}

	internal static bool smethod_8(Class4785 targetEl, Class4779 testedEl)
	{
		if (targetEl == null)
		{
			return false;
		}
		bool result = false;
		foreach (Class4845 item in targetEl)
		{
			Class4779 value = item.Value;
			if (Class4778.smethod_0(testedEl.Origin.Y, value.Origin.Y) && Class4778.smethod_17(targetEl, testedEl))
			{
				targetEl.Add(testedEl);
				result = true;
				break;
			}
		}
		return result;
	}

	internal static void smethod_9(Class4846 planePointers, Class4845 linePointer, Class4786 textSpace, float maxLookupRelativeDistance)
	{
		if (linePointer == null || !(linePointer.Value is Class4784 @class) || @class.PageElementCount == 0)
		{
			return;
		}
		Class4846 class2 = textSpace.method_15(linePointer, maxLookupRelativeDistance, 1f);
		foreach (Class4845 item in class2)
		{
			if (!(item.Value is Class4784 el) || !Class4808.smethod_0(@class, el, textSpace))
			{
				continue;
			}
			bool flag = true;
			foreach (Class4845 planePointer in planePointers)
			{
				if (planePointer.Value == item.Value)
				{
					flag = false;
					break;
				}
			}
			if (flag)
			{
				planePointers.Add(item);
				smethod_9(planePointers, item, textSpace, maxLookupRelativeDistance);
			}
		}
	}

	internal static bool smethod_10(Class4846 planePointers)
	{
		if (planePointers == null)
		{
			return false;
		}
		bool result = false;
		ArrayList arrayList = smethod_11(planePointers);
		IEnumerator enumerator = planePointers.GetEnumerator();
		for (int i = 0; i < arrayList.Count; i++)
		{
			Class4846 @class = new Class4846();
			enumerator.MoveNext();
			@class.Add((Class4845)enumerator.Current);
			float num = (float)arrayList[i];
			Class4845 class2 = (Class4845)enumerator.Current;
			int num2 = 1;
			bool flag;
			do
			{
				flag = smethod_13(i, num, arrayList);
				num2++;
				enumerator.MoveNext();
				@class.Add((Class4845)enumerator.Current);
				i++;
			}
			while (flag);
			if (smethod_12(num2, i, num, arrayList))
			{
				Class4785 class3 = new Class4785();
				IEnumerator enumerator2 = @class.GetEnumerator();
				while (enumerator2.MoveNext())
				{
					class3.Add(((Class4845)enumerator2.Current).Value);
					((Class4845)enumerator2.Current).Remove();
				}
				class2.Value = class3;
				result = true;
			}
		}
		return result;
	}

	internal static ArrayList smethod_11(Class4846 planePointers)
	{
		if (planePointers == null)
		{
			return null;
		}
		ArrayList arrayList = new ArrayList();
		Class4845 @class = null;
		Class4845 class2 = null;
		Interface147 @interface = planePointers.method_2();
		while (@interface.imethod_0())
		{
			if (@class == null)
			{
				@interface.imethod_1();
				@class = @interface.Current;
				@interface.imethod_0();
			}
			else
			{
				@class = class2;
			}
			while (@interface.imethod_1())
			{
				class2 = @interface.Current;
				arrayList.Add(class2.Value.Origin.Y - @class.Value.Origin.Y);
			}
		}
		return arrayList;
	}

	internal static bool smethod_12(int preliminaryGroupSize, int curDistanceIndex, float candidateLineDistance, ArrayList verticalLineDistance)
	{
		if (verticalLineDistance == null)
		{
			return false;
		}
		bool result = false;
		if (preliminaryGroupSize >= 3)
		{
			result = true;
		}
		else if (curDistanceIndex + 1 < verticalLineDistance.Count)
		{
			float num = (float)verticalLineDistance[curDistanceIndex + 1];
			if (num > candidateLineDistance)
			{
				result = true;
			}
		}
		else
		{
			result = true;
		}
		return result;
	}

	internal static bool smethod_13(int curDistanceIndex, float curDistance, ArrayList verticalLineDistance)
	{
		if (verticalLineDistance == null)
		{
			return false;
		}
		bool result = false;
		if (curDistanceIndex + 1 < verticalLineDistance.Count)
		{
			float num = (float)verticalLineDistance[curDistanceIndex + 1];
			float num2 = Math.Abs(curDistance - num) / curDistance;
			if (num2 < 0.34f)
			{
				result = true;
			}
		}
		return result;
	}
}
