using ns171;
using ns176;

namespace ns187;

internal class Class5718
{
	public Interface182 interface182_0;

	public Interface182 interface182_1;

	public Interface182 interface182_2;

	public Interface182 interface182_3;

	public Class5046 class5046_0;

	public Class5046 class5046_1;

	public Interface182 interface182_4;

	public Interface182 interface182_5;

	public Class5718(Class5634 pList)
	{
		interface182_0 = pList.method_5(151).vmethod_0();
		interface182_1 = pList.method_5(148).vmethod_0();
		interface182_2 = pList.method_5(149).vmethod_0();
		interface182_3 = pList.method_5(150).vmethod_0();
		class5046_0 = pList.method_5(223).vmethod_5();
		class5046_1 = pList.method_5(222).vmethod_5();
		interface182_4 = pList.method_5(233).vmethod_0();
		interface182_5 = pList.method_5(91).vmethod_0();
	}

	public override string ToString()
	{
		return string.Concat("CommonMarginBlock:\nMargins (top, bottom, left, right): (", interface182_0, ", ", interface182_1, ", ", interface182_2, ", ", interface182_3, ")\nSpace (before, after): (", class5046_0, ", ", class5046_1, ")\nIndents (start, end): (", interface182_4, ", ", interface182_5, ")\n");
	}
}
