using System.Text;
using ns171;
using ns176;

namespace ns187;

internal class Class5673
{
	public int int_0;

	public Interface182 interface182_0;

	public Interface182 interface182_1;

	public Interface182 interface182_2;

	public Interface182 interface182_3;

	public Class5673(Class5634 pList)
	{
		int_0 = pList.method_6(Enum679.const_2).imethod_0();
		interface182_0 = pList.method_6(Enum679.const_340).vmethod_0();
		interface182_2 = pList.method_6(Enum679.const_58).vmethod_0();
		interface182_3 = pList.method_6(Enum679.const_227).vmethod_0();
		interface182_1 = pList.method_6(Enum679.const_298).vmethod_0();
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder("CommonAbsolutePosition{");
		stringBuilder.Append(" absPos=");
		stringBuilder.Append(int_0);
		stringBuilder.Append(" top=");
		stringBuilder.Append(interface182_0);
		stringBuilder.Append(" bottom=");
		stringBuilder.Append(interface182_2);
		stringBuilder.Append(" left=");
		stringBuilder.Append(interface182_3);
		stringBuilder.Append(" right=");
		stringBuilder.Append(interface182_1);
		stringBuilder.Append("}");
		return stringBuilder.ToString();
	}
}
