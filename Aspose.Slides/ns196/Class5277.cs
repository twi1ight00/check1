using System.Collections;
using ns198;

namespace ns196;

internal class Class5277 : Class5274
{
	private bool bool_0;

	public Class5277()
	{
	}

	public Class5277(ArrayList list)
		: base(list)
	{
	}

	public override bool vmethod_5()
	{
		return true;
	}

	public override bool vmethod_2(Class5274 sequence)
	{
		if (sequence.vmethod_5())
		{
			return !bool_0;
		}
		return false;
	}

	public override bool vmethod_4(Class5274 sequence)
	{
		if (!vmethod_2(sequence))
		{
			return false;
		}
		Class5328 @class = method_3();
		Class5328 class2 = sequence.method_5(0);
		if (class2.vmethod_0() && !((Class5337)class2).method_3() && @class.vmethod_0() && ((Class5337)@class).method_4() != 0)
		{
			method_8();
		}
		AddRange(sequence);
		return true;
	}

	public override bool vmethod_3(Class5274 sequence, bool keepTogether, Class5336 breakElement)
	{
		return vmethod_4(sequence);
	}

	public override Class5274 vmethod_1()
	{
		if (!bool_0)
		{
			Add(new Class5342(0, -Class5337.int_0, penaltyFlagged: false, null, auxiliary: false));
			bool_0 = true;
		}
		return this;
	}

	public void method_8()
	{
		Class5338 @class = (Class5338)method_3();
		if (!@class.method_3() || (Count >= 4 && method_5(Count - 2).vmethod_1() && method_5(Count - 3).vmethod_2() && method_5(Count - 4).vmethod_0()))
		{
			method_4();
			ArrayList arrayList = new ArrayList();
			if (!@class.method_3())
			{
				arrayList.Add(@class);
			}
			else
			{
				arrayList.Add(@class);
				arrayList.Insert(0, (Class5344)method_4());
				arrayList.Insert(0, (Class5342)method_4());
				arrayList.Insert(0, (Class5338)method_4());
			}
			AddRange(((Interface175)@class.method_2()).imethod_27(arrayList));
			if (@class is Class5339 && ((Class5339)@class).method_11())
			{
				Class5339 class2 = (Class5339)method_3();
				class2.method_9(((Class5339)@class).method_10());
				class2.method_6(((Class5339)@class).method_7());
			}
		}
	}
}
