using System.Collections;
using ns205;

namespace ns196;

internal class Class5696
{
	private bool bool_0;

	private bool bool_1;

	private ArrayList arrayList_0 = new ArrayList();

	public Class5696(bool startsReferenceArea)
	{
		bool_0 = startsReferenceArea;
	}

	public object method_0()
	{
		Class5696 @class = new Class5696(bool_0);
		@class.bool_1 = bool_1;
		@class.arrayList_0 = new ArrayList();
		@class.arrayList_0 = new ArrayList(arrayList_0);
		return @class;
	}

	public void method_1()
	{
		bool_1 = false;
		arrayList_0.Clear();
	}

	public bool method_2()
	{
		return arrayList_0.Count != 0;
	}

	public void method_3(Class5697 space)
	{
		if (bool_0 && space.method_0() && !method_2())
		{
			return;
		}
		if (space.method_1())
		{
			if (!bool_1)
			{
				arrayList_0.Clear();
				bool_1 = true;
			}
			arrayList_0.Add(space);
		}
		else if (!bool_1 && space.method_3().method_16())
		{
			arrayList_0.Add(space);
		}
	}

	public Class5746 method_4(bool endsReferenceArea)
	{
		int num = arrayList_0.Count;
		if (endsReferenceArea)
		{
			while (num > 0)
			{
				Class5697 @class = (Class5697)arrayList_0[num - 1];
				if (!@class.method_0())
				{
					break;
				}
				num--;
			}
		}
		Class5746 class2 = Class5746.class5746_0;
		int num2 = -1;
		for (int i = 0; i < num; i++)
		{
			Class5697 class3 = (Class5697)arrayList_0[i];
			Class5746 class4 = class3.method_3();
			if (bool_1)
			{
				class2 = class2.method_6(class4);
				continue;
			}
			int num3 = class3.method_2();
			if (num3 > num2)
			{
				num2 = num3;
				class2 = class4;
			}
			else
			{
				if (num3 != num2)
				{
					continue;
				}
				if (class4.method_2() > class2.method_2())
				{
					class2 = class4;
				}
				else if (class4.method_2() == class2.method_2())
				{
					if (class2.method_1() < class4.method_1())
					{
						class2 = Class5746.smethod_0(class4.method_1(), class2.method_2(), class2.method_3());
					}
					if (class2.method_3() > class4.method_3())
					{
						class2 = Class5746.smethod_0(class2.method_1(), class2.method_2(), class4.method_3());
					}
				}
			}
		}
		return class2;
	}

	public override string ToString()
	{
		return string.Concat("Space Specifier (resolved at begin/end of ref. area:):\n", method_4(endsReferenceArea: false), "\n", method_4(endsReferenceArea: true));
	}
}
