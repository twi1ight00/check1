using ns171;
using ns176;

namespace ns190;

internal abstract class Class5125 : Class5094
{
	protected Interface181 interface181_0;

	protected int int_1;

	private string string_3;

	private int int_2;

	private char char_0;

	private int int_3;

	private Interface181 interface181_1;

	private string string_4;

	private string string_5;

	private string string_6;

	private Class5672 class5672_0;

	protected int int_4;

	public Class5125(Class5088 parent)
		: base(parent)
	{
	}

	public override void vmethod_2(Class5634 pList)
	{
		base.vmethod_2(pList);
		interface181_0 = pList.method_6(Enum679.const_213).vmethod_10();
		int_1 = pList.method_6(Enum679.const_196).imethod_0();
		string_3 = pList.method_6(Enum679.const_197).vmethod_13();
		int_2 = pList.method_6(Enum679.const_229).imethod_0();
		char_0 = pList.method_6(Enum679.const_200).vmethod_7();
		int_3 = (int)pList.method_6(Enum679.const_201).vmethod_9();
		interface181_1 = pList.method_6(Enum679.const_284).vmethod_10();
		string_4 = pList.method_6(Enum679.const_221).vmethod_13();
		string_5 = pList.method_6(Enum679.const_82).vmethod_13();
		string_6 = pList.method_6(Enum679.const_363).vmethod_13();
	}

	internal override void vmethod_10()
	{
		class5672_0 = new Class5672(string_3, char_0, int_3, int_2, string_6, string_4, string_5);
	}

	public void method_48()
	{
		int num = 0;
		if (interface181_0.imethod_0() != 0)
		{
			int_4 = vmethod_20().method_52() + 1;
			switch (interface181_0.imethod_0())
			{
			case 11:
				if (int_4 % 2 == 0)
				{
					int_4++;
				}
				break;
			case 10:
				if (int_4 % 2 == 1)
				{
					int_4++;
				}
				break;
			}
		}
		else
		{
			int num2 = interface181_0.imethod_5();
			int_4 = ((num2 <= 0) ? 1 : num2);
		}
	}

	public int method_49()
	{
		return int_4;
	}

	public string method_50(int pageNumber)
	{
		return class5672_0.method_0(pageNumber);
	}

	public override Class5170 vmethod_20()
	{
		return (Class5170)method_4();
	}

	public int method_51()
	{
		return int_1;
	}

	public Interface181 method_52()
	{
		return interface181_0;
	}

	public virtual int vmethod_32()
	{
		return interface181_1.imethod_5();
	}
}
