using System;
using ns171;

namespace ns187;

internal class Class5724 : Class5723
{
	private int[][] int_4;

	public Class5724(Class5052 baseMaker)
		: base(baseMaker)
	{
	}

	public void method_4(int[][] extraCorresponding)
	{
		if (extraCorresponding == null)
		{
			throw new NullReferenceException();
		}
		for (int i = 0; i < extraCorresponding.Length; i++)
		{
			int[] array = extraCorresponding[i];
			if (array == null || array.Length != 4)
			{
				throw new ArgumentException("bad sub-array @ [" + i + "]");
			}
		}
		int_4 = extraCorresponding;
	}

	public override bool vmethod_0(Class5634 propertyList)
	{
		if (base.vmethod_0(propertyList))
		{
			return true;
		}
		int num = 0;
		while (true)
		{
			if (num < int_4.Length)
			{
				int propId = int_4[num][0];
				if (propertyList.vmethod_0(propId) != null)
				{
					break;
				}
				num++;
				continue;
			}
			return false;
		}
		return true;
	}

	public override Class5024 vmethod_1(Class5634 propertyList)
	{
		Class5024 @class = base.vmethod_1(propertyList);
		if (@class == null)
		{
			@class = class5052_0.vmethod_7(propertyList);
		}
		int propId = propertyList.method_9(int_4[0][0], int_4[0][1], int_4[0][2], int_4[0][3]);
		Class5024 class2 = propertyList.method_3(propId);
		if (class2 != null)
		{
			class5052_0.vmethod_6(@class, 3072, class2);
		}
		propId = propertyList.method_9(int_4[1][0], int_4[1][1], int_4[1][2], int_4[1][3]);
		class2 = propertyList.method_3(propId);
		if (class2 != null)
		{
			class5052_0.vmethod_6(@class, 2560, class2);
		}
		return @class;
	}
}
