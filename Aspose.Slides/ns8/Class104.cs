using ns56;

namespace ns8;

internal class Class104 : Class103
{
	public Class104(Class2146 algorithm)
	{
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
		}
	}
}
