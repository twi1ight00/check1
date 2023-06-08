using System.Collections;
using ns205;

namespace ns173;

internal class Class4966 : Class4942
{
	private Class4965 class4965_0;

	private ArrayList arrayList_1 = new ArrayList();

	private bool bool_0 = true;

	public Class4966(Class4965 parent)
	{
		class4965_0 = parent;
		method_29(Class5757.int_24, true);
	}

	public Class4967 method_37(bool spanAll)
	{
		if (arrayList_1.Count > 0 && method_40().method_47())
		{
			arrayList_1.Remove(arrayList_1.Count - 1);
		}
		Class4971 @class = class4965_0.method_38();
		int ipd = class4965_0.method_12() - @class.method_21() - @class.method_22();
		Class4967 value = new Class4967(spanAll ? 1 : method_42(), method_43(), ipd);
		arrayList_1.Add(value);
		return method_40();
	}

	public ArrayList method_38()
	{
		return arrayList_1;
	}

	public void method_39(ArrayList spans)
	{
		arrayList_1 = new ArrayList(spans);
	}

	public Class4967 method_40()
	{
		return (Class4967)arrayList_1[arrayList_1.Count - 1];
	}

	public bool method_41()
	{
		if (bool_0 && arrayList_1 != null)
		{
			foreach (Class4967 item in arrayList_1)
			{
				if (!item.method_47())
				{
					bool_0 = false;
					break;
				}
			}
		}
		return bool_0;
	}

	public int method_42()
	{
		return class4965_0.method_45();
	}

	public int method_43()
	{
		return class4965_0.method_46();
	}

	public override void vmethod_4(Interface231 wmtg)
	{
		foreach (Class4967 item in method_38())
		{
			item.vmethod_4(wmtg);
		}
	}
}
