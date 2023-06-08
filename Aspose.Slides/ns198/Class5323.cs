using System;
using System.Collections;
using ns173;
using ns176;
using ns181;
using ns183;
using ns190;
using ns196;

namespace ns198;

internal class Class5323 : Class5279, Interface172, Interface173, Interface175
{
	private Class4942 class4942_0;

	private int int_0;

	private Interface173 interface173_0;

	private Interface175 interface175_0;

	public Class5323(Class4942 area, Interface173 parentLM)
	{
		class4942_0 = area;
		interface173_0 = parentLM;
	}

	public Class5323(Class5322 pslm, Class5099 foTitle)
	{
		interface173_0 = pslm;
		class4942_0 = new Class4972();
		try
		{
			Interface173 @interface = pslm.method_24().imethod_1(foTitle);
			imethod_12(@interface);
			method_9(@interface);
		}
		catch (InvalidOperationException ex)
		{
			throw ex;
		}
	}

	public override void imethod_3()
	{
	}

	private void method_9(Interface173 curLM)
	{
		Class5687 @class = new Class5687(2);
		@class.method_18(new Class5696(startsReferenceArea: false));
		@class.method_21(new Class5696(startsReferenceArea: false));
		@class.method_30(1000000);
		int_0 = 0;
		ArrayList arrayList = imethod_14(@class, 135);
		Class5687 class2 = new Class5687(0);
		class2.method_2(256, bSet: true);
		class2.method_18(new Class5696(startsReferenceArea: false));
		class2.method_21(new Class5696(startsReferenceArea: false));
		Class5653 posIter = new Class5653(arrayList, 0, arrayList.Count);
		curLM.imethod_9(posIter, class2);
	}

	public override void imethod_9(Class5652 posIter, Class5687 context)
	{
		int ipD = ((Class4943)class4942_0).method_12();
		Class5687 @class = new Class5687(context);
		@class.method_39(0.0);
		interface175_0.imethod_9(posIter, @class);
		((Class4943)class4942_0).method_11(ipD);
	}

	public int method_10()
	{
		return int_0;
	}

	public override Class4942 imethod_7(Class4942 childArea)
	{
		return class4942_0;
	}

	public override void imethod_8(Class4942 childArea)
	{
		class4942_0.vmethod_2(childArea);
	}

	public override void imethod_1(Interface173 lm)
	{
		interface173_0 = lm;
	}

	public override Interface173 imethod_2()
	{
		return interface173_0;
	}

	public override bool imethod_5()
	{
		return false;
	}

	public override void imethod_6(bool isFinished)
	{
	}

	public override bool imethod_10(int pos)
	{
		return false;
	}

	public override ArrayList imethod_11()
	{
		ArrayList arrayList = new ArrayList(1);
		arrayList.Add(interface175_0);
		return arrayList;
	}

	public override void imethod_12(Interface173 lm)
	{
		if (lm != null)
		{
			lm.imethod_1(this);
			interface175_0 = (Interface175)lm;
		}
	}

	public override void imethod_13(ArrayList newLMs)
	{
		if (newLMs != null && newLMs.Count != 0)
		{
			Interface168 @interface = new Class5495(newLMs);
			while (@interface.imethod_0())
			{
				Interface173 lm = (Interface173)@interface.imethod_1();
				imethod_12(lm);
			}
		}
	}

	public override ArrayList imethod_14(Class5687 context, int alignment)
	{
		ArrayList arrayList = new ArrayList();
		interface175_0.imethod_3();
		while (!interface175_0.imethod_5())
		{
			ArrayList arrayList2 = interface175_0.imethod_14(context, alignment);
			if (arrayList2 == null)
			{
				continue;
			}
			while (arrayList2.Count > 0)
			{
				object obj = arrayList2[0];
				arrayList2.Remove(0);
				if (obj is Class5274)
				{
					Class5274 arrayList3 = (Class5274)obj;
					Interface208 @interface = new Class5495(arrayList3);
					while (@interface.imethod_0())
					{
						Class5337 @class = (Class5337)@interface.imethod_1();
						int_0 += @class.method_4();
						arrayList.Add(@class);
					}
				}
				else
				{
					Class5337 @class = (Class5337)obj;
					int_0 += @class.method_4();
					arrayList.Add(@class);
				}
			}
		}
		imethod_6(isFinished: true);
		return arrayList;
	}

	public ArrayList imethod_27(ArrayList oldList)
	{
		return oldList;
	}

	public ArrayList imethod_28(ArrayList oldList, int depth)
	{
		return imethod_27(oldList);
	}

	public string imethod_29(Class5254 pos)
	{
		return string.Empty;
	}

	public void imethod_30(Class5254 pos, Class5685 hc)
	{
	}

	public bool imethod_31(ArrayList oldList)
	{
		return false;
	}

	public bool imethod_32(ArrayList oldList, int depth)
	{
		return imethod_31(oldList);
	}

	public override ArrayList imethod_15(ArrayList oldList, int alignment)
	{
		return null;
	}

	public ArrayList imethod_38(ArrayList oldList, int alignment, int depth)
	{
		return imethod_15(oldList, alignment);
	}

	public override Class5322 imethod_4()
	{
		return interface173_0.imethod_4();
	}

	public override int imethod_16()
	{
		return class4942_0.method_12();
	}

	public override int imethod_17()
	{
		return class4942_0.vmethod_1();
	}

	public override bool imethod_18()
	{
		return false;
	}

	public override bool imethod_19()
	{
		if (!imethod_20())
		{
			return class4942_0 is Class4962;
		}
		return true;
	}

	public override bool imethod_20()
	{
		return class4942_0 is Class4972;
	}

	public override Class5254 imethod_22(Class5254 pos)
	{
		return pos;
	}
}
