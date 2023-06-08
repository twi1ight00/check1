using ns56;

namespace ns8;

internal class Class109 : Class103
{
	private Enum132 enum132_0;

	private Enum131 enum131_0;

	public Enum132 HierarchyAlignment => enum132_0;

	public Enum131 HierarchySecondAlignment => enum131_0;

	public Class109(Class2146 algorithm)
	{
		base.VerticalAlignment = Enum121.const_2;
		base.HorizontalAlignment = Enum120.const_2;
		enum132_0 = Enum132.const_1;
		enum131_0 = Enum131.const_4;
		Class2177[] paramList = algorithm.ParamList;
		foreach (Class2177 @class in paramList)
		{
			if (@class.Type == Enum304.const_21)
			{
				base.HorizontalAlignment = Class103.smethod_1(@class.Val);
			}
			else if (@class.Type == Enum304.const_54)
			{
				base.VerticalAlignment = Class103.smethod_2(@class.Val);
			}
			else if (@class.Type == Enum304.const_20)
			{
				method_0(@class.Val);
			}
		}
	}

	private void method_0(string value)
	{
		if (value.Length > 1)
		{
			switch (value[0])
			{
			case 't':
				enum132_0 = Enum132.const_1;
				break;
			case 'l':
				enum132_0 = Enum132.const_3;
				break;
			case 'b':
				enum132_0 = Enum132.const_2;
				break;
			case 'r':
				enum132_0 = Enum132.const_4;
				break;
			}
			switch (value.Substring(1))
			{
			case "L":
				enum131_0 = Enum131.const_2;
				break;
			case "R":
				enum131_0 = Enum131.const_3;
				break;
			case "T":
				enum131_0 = Enum131.const_0;
				break;
			case "B":
				enum131_0 = Enum131.const_1;
				break;
			case "CtrCh":
				enum131_0 = Enum131.const_4;
				break;
			case "CtrDes":
				enum131_0 = Enum131.const_5;
				break;
			}
		}
	}
}
