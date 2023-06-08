using System.Collections;
using ns205;

namespace ns196;

internal class Class5341 : Class5338
{
	private Class5746 class5746_0;

	private int int_2;

	private ArrayList arrayList_0;

	private ArrayList arrayList_1;

	private ArrayList arrayList_2;

	private ArrayList arrayList_3;

	public Class5341(int width, Class5746 range, int bpdim, Class5254 pos, bool auxiliary)
		: base(width, pos, auxiliary)
	{
		class5746_0 = range;
		int_2 = bpdim;
		arrayList_0 = new ArrayList();
		arrayList_1 = new ArrayList();
	}

	public Class5341(int width, ArrayList footnoteLMList, ArrayList floatLMList, Class5254 pos, bool auxiliary)
		: base(width, pos, auxiliary)
	{
		class5746_0 = Class5746.class5746_0;
		int_2 = 0;
		arrayList_0 = new ArrayList(footnoteLMList);
		arrayList_1 = new ArrayList(floatLMList);
	}

	public ArrayList method_6()
	{
		return arrayList_0;
	}

	public ArrayList method_7()
	{
		return arrayList_1;
	}

	public bool method_8()
	{
		return arrayList_0.Count > 0;
	}

	public bool method_9()
	{
		return arrayList_1.Count > 0;
	}

	public void method_10(ArrayList list)
	{
		if (arrayList_2 == null)
		{
			arrayList_2 = new ArrayList();
		}
		arrayList_2.Add(list);
	}

	public ArrayList method_11()
	{
		return arrayList_2;
	}

	public void method_12(ArrayList list)
	{
		if (arrayList_3 == null)
		{
			arrayList_3 = new ArrayList();
		}
		arrayList_3.Add(list);
	}

	public ArrayList method_13()
	{
		return arrayList_3;
	}

	public Class5746 method_14()
	{
		return class5746_0;
	}

	public void method_15(Class5746 ipd)
	{
		class5746_0 = ipd;
	}

	public int method_16()
	{
		return int_2;
	}
}
