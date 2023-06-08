using System;
using System.Collections;
using System.Text;
using ns190;

namespace ns173;

internal class Class4964 : Class4942
{
	private int int_15;

	private string string_0;

	private Class5492 class5492_0;

	private ArrayList arrayList_1 = new ArrayList();

	protected Class4971 class4971_0;

	public Class4964(Class5135 regionFO, Class4971 parent)
		: this(regionFO.vmethod_24(), regionFO.method_53(), parent)
	{
	}

	public Class4964(int regionClass, string regionName, Class4971 parent)
	{
		int_15 = regionClass;
		string_0 = regionName;
		method_29(Class5757.int_24, true);
		class4971_0 = parent;
	}

	public override void vmethod_2(Class4942 child)
	{
		arrayList_1.Add(child);
	}

	public void method_37(Class5492 ctM)
	{
		class5492_0 = ctM;
	}

	public Class4971 method_38()
	{
		return class4971_0;
	}

	public Class5492 method_39()
	{
		return class5492_0;
	}

	public ArrayList method_40()
	{
		return arrayList_1;
	}

	public int method_41()
	{
		return int_15;
	}

	public string method_42()
	{
		return string_0;
	}

	public void method_43(Class4962 block)
	{
		vmethod_2(block);
	}

	public virtual object vmethod_5()
	{
		throw new NotImplementedException();
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder(base.ToString());
		stringBuilder.Append(" {regionName=").Append(string_0);
		stringBuilder.Append(", regionClass=").Append(int_15);
		stringBuilder.Append(", ctm=").Append(class5492_0);
		stringBuilder.Append("}");
		return stringBuilder.ToString();
	}
}
