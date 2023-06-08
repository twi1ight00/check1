using System;
using System.Collections;
using ns161;
using ns167;

namespace ns169;

internal class Class4811
{
	internal static void smethod_0(Class4786 textSpace)
	{
		if (textSpace != null)
		{
			bool flag;
			do
			{
				flag = false;
				textSpace.method_5();
				flag = (flag = (flag = false | smethod_2(textSpace)) | smethod_7(textSpace)) | smethod_4(textSpace);
				textSpace.Flush();
			}
			while (flag);
		}
	}

	internal static void smethod_1(Class4786 textSpace, float relativeHorizontalProximity)
	{
		float relativeHorizontalProximity2 = Class4860.Instance.RelativeHorizontalProximity;
		Class4860.Instance.RelativeHorizontalProximity = relativeHorizontalProximity;
		smethod_0(textSpace);
		Class4860.Instance.RelativeHorizontalProximity = relativeHorizontalProximity2;
	}

	private static bool smethod_2(Class4786 textSpace)
	{
		bool flag = false;
		Interface147 @interface = textSpace.method_4();
		while (@interface.imethod_0())
		{
			bool flag2 = false;
			if (@interface.imethod_1())
			{
				Class4846 @class = new Class4846();
				Class4845 class2 = @interface.Current;
				if (Class4860.Instance.Options.RecognizeBullets && !smethod_3(class2.Value))
				{
					if (!@interface.imethod_1())
					{
						continue;
					}
					class2 = @interface.Current;
				}
				Class4845 class3 = class2;
				while (@interface.imethod_1())
				{
					Class4845 current = @interface.Current;
					if (Class4810.smethod_0(class3.Value, current.Value))
					{
						@class.Add(current);
						class3 = current;
						continue;
					}
					if (!@class.method_3())
					{
						flag2 = true;
						@class.method_6(class2);
						Class4784 value = new Class4784(@class);
						class2.Value = value;
						@class.Clear();
					}
					class2 = current;
					class3 = class2;
				}
				if (!@class.method_3())
				{
					flag2 = true;
					@class.method_6(class2);
					Class4784 value2 = new Class4784(@class);
					class2.Value = value2;
					@class.Clear();
				}
			}
			flag = flag || flag2;
		}
		textSpace.Flush();
		return flag;
	}

	private static bool smethod_3(Class4779 el)
	{
		if (el.Text.Length > 0 && char.IsLetter(el.Text[0]))
		{
			return true;
		}
		if (el.Text.Length > 1 && !char.IsLetter(el.Text[0]))
		{
			return char.IsLetter(el.Text[1]);
		}
		return false;
	}

	private static bool smethod_4(Class4786 textSpace)
	{
		bool flag = false;
		foreach (Class4845 item in textSpace)
		{
			bool flag2 = false;
			Class4779 value = item.Value;
			float num = 1f;
			for (int i = 0; i <= 1; i++)
			{
				Class4846 class2 = ((i == 0) ? textSpace.method_13(item, num, num) : textSpace.method_14(item, num, num));
				foreach (Class4845 item2 in class2)
				{
					if (item2.Value is Class4784 class4 && (!(value is Class4784 class5) || ((!class5.HasSubscript || i != 1) && (!class5.HasSuperscript || i != 0))) && smethod_5(value, class4, i == 1, textSpace))
					{
						flag2 = true;
						item2.Value = class4;
						item.Remove();
						break;
					}
				}
			}
			flag = flag || flag2;
		}
		return flag;
	}

	private static bool smethod_5(Class4779 possibleSubPart, Class4784 textLine, bool isSuperscriptCheck, Class4786 textSpace)
	{
		bool result = false;
		if (Class4810.smethod_1(possibleSubPart, textLine))
		{
			for (int i = 0; i < textLine.PageElementCount; i++)
			{
				Class4791 mainLineEl = (Class4791)textLine[i];
				if (Class4810.smethod_3(mainLineEl, possibleSubPart) && Class4810.smethod_2(mainLineEl, possibleSubPart, textSpace))
				{
					if (isSuperscriptCheck)
					{
						textLine.method_37(possibleSubPart);
					}
					else
					{
						textLine.method_38(possibleSubPart);
					}
					result = true;
					break;
				}
			}
		}
		return result;
	}

	private static ArrayList smethod_6(Class4786 textSpace)
	{
		ArrayList arrayList = new ArrayList();
		float[] array = new float[textSpace.LineCount];
		for (int i = 0; i < textSpace.LineCount; i++)
		{
			array[i] = textSpace[i].BoundingBox.Width;
		}
		int[] array2 = Class4817.smethod_3(array);
		for (int j = 0; j < textSpace.LineCount; j++)
		{
			int num = array2[textSpace.LineCount - 1 - j];
			for (int k = 0; k < textSpace[num].PageElementCount; k++)
			{
				arrayList.Add(textSpace.method_20(num, k));
			}
		}
		return arrayList;
	}

	private static bool smethod_7(Class4786 textSpace)
	{
		bool flag = false;
		foreach (Class4845 item in smethod_6(textSpace))
		{
			bool flag2 = false;
			Class4846 class2 = textSpace.method_13(item, 0.65f, 0.65f);
			foreach (Class4845 item2 in class2)
			{
				if (!Class4810.smethod_3(item.Value, item2.Value) || !Class4810.smethod_2(item.Value, item2.Value, textSpace))
				{
					continue;
				}
				if (item2.Value is Class4784)
				{
					Class4784 class4 = (Class4784)item2.Value;
					if (class4.HasSuperscript)
					{
						continue;
					}
				}
				if (smethod_8(item, item2))
				{
					item.Value = smethod_9(item2.Value, item.Value, isSuperscriptCheck: false);
				}
				else
				{
					item.Value = smethod_9(item.Value, item2.Value, isSuperscriptCheck: true);
				}
				item2.Remove();
			}
			Class4846 class5 = textSpace.method_14(item, 0.65f, 0.65f);
			foreach (Class4845 item3 in class5)
			{
				if (!Class4810.smethod_3(item.Value, item3.Value) || !Class4810.smethod_2(item.Value, item3.Value, textSpace))
				{
					continue;
				}
				if (item3.Value is Class4784)
				{
					Class4784 class7 = (Class4784)item3.Value;
					if (class7.HasSubscript)
					{
						continue;
					}
				}
				if (smethod_8(item, item3))
				{
					item.Value = smethod_9(item3.Value, item.Value, isSuperscriptCheck: true);
				}
				else
				{
					item.Value = smethod_9(item.Value, item3.Value, isSuperscriptCheck: false);
				}
				item3.Remove();
			}
			flag = flag || flag2;
		}
		return flag;
	}

	private static bool smethod_8(Class4845 curElement, Class4845 neighborPtr)
	{
		return curElement.ParentPlacementLine.BoundingBox.Width < neighborPtr.ParentPlacementLine.BoundingBox.Width;
	}

	private static Class4779 smethod_9(Class4779 curElement, Class4779 testedElement, bool isSuperscriptCheck)
	{
		if (curElement is Class4784 @class)
		{
			if (isSuperscriptCheck)
			{
				@class.method_37(testedElement);
			}
			else
			{
				@class.method_38(testedElement);
			}
			return curElement;
		}
		if (curElement is Class4791 element)
		{
			Class4784 class2 = new Class4784(element);
			if (isSuperscriptCheck)
			{
				class2.method_37(testedElement);
			}
			else
			{
				class2.method_38(testedElement);
			}
			return class2;
		}
		throw new InvalidOperationException("Line grouping must be conducted prior to other grouping operations.");
	}
}
