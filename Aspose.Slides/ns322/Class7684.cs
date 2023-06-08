using System;
using System.Collections;

namespace ns322;

internal class Class7684 : IComparer
{
	private Interface396 interface396_0;

	private Class7400 class7400_0;

	public Interface396 Visitor => interface396_0;

	public Class7400 Function => class7400_0;

	public int Compare(object x, object y)
	{
		Visitor.Result = Function;
		IList list = new ArrayList();
		list.Add(new Class7378((Class7397)x, TypeCode.Object));
		list.Add(new Class7378((Class7397)y, TypeCode.Object));
		new Class7372(list).vmethod_0((Interface395)Visitor);
		return Math.Sign(Visitor.Result.vmethod_3());
	}

	public Class7684(Interface396 visitor, Class7400 function)
	{
		interface396_0 = visitor;
		class7400_0 = function;
	}
}
