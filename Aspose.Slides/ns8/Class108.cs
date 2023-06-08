using ns56;

namespace ns8;

internal class Class108 : Class103
{
	private Enum119 enum119_0;

	private Enum132 enum132_0;

	private Enum119 enum119_1;

	private Enum132 enum132_1;

	public Enum119 LinearDirection => enum119_0;

	public Enum132 ChildAlignment => enum132_0;

	public Enum119 SecondaryLinearDirection => enum119_1;

	public Enum132 SecondaryChildAlignment => enum132_1;

	public Class108(Class2146 algorithm)
	{
		enum119_0 = Enum119.const_2;
		enum132_0 = Enum132.const_3;
		enum119_1 = Enum119.const_0;
		enum132_1 = Enum132.const_0;
		base.VerticalAlignment = Enum121.const_2;
		base.HorizontalAlignment = Enum120.const_2;
		Class2177[] paramList = algorithm.ParamList;
		foreach (Class2177 @class in paramList)
		{
			if (@class.Type == Enum304.const_22)
			{
				enum119_0 = Class103.smethod_3(@class.Val);
			}
			else if (@class.Type == Enum304.const_8)
			{
				enum132_0 = method_0(@class.Val);
			}
			else if (@class.Type == Enum304.const_40)
			{
				enum119_1 = Class103.smethod_3(@class.Val);
			}
			else if (@class.Type == Enum304.const_39)
			{
				enum132_1 = method_0(@class.Val);
			}
			else if (@class.Type == Enum304.const_21)
			{
				base.HorizontalAlignment = Class103.smethod_1(@class.Val);
			}
			else if (@class.Type == Enum304.const_54)
			{
				base.VerticalAlignment = Class103.smethod_2(@class.Val);
			}
		}
	}

	private Enum132 method_0(string value)
	{
		return value switch
		{
			"l" => Enum132.const_3, 
			"r" => Enum132.const_4, 
			"b" => Enum132.const_2, 
			"t" => Enum132.const_1, 
			_ => Enum132.const_0, 
		};
	}
}
