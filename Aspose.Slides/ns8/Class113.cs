using ns56;

namespace ns8;

internal class Class113 : Class103
{
	private Enum119 enum119_0;

	private Enum120 enum120_1;

	private Enum121 enum121_1;

	private Enum122 enum122_0;

	public Enum119 LinearDirection => enum119_0;

	public Enum120 NodeHorizontalAlignment => enum120_1;

	public Enum121 NodeVerticalAlignment => enum121_1;

	public Enum122 Fallback => enum122_0;

	public Class113(Class2146 algorithm)
	{
		enum119_0 = Enum119.const_2;
		enum120_1 = Enum120.const_2;
		enum121_1 = Enum121.const_2;
		base.HorizontalAlignment = Enum120.const_2;
		base.VerticalAlignment = Enum121.const_2;
		enum122_0 = Enum122.const_0;
		Class2177[] paramList = algorithm.ParamList;
		foreach (Class2177 @class in paramList)
		{
			if (@class.Type == Enum304.const_22)
			{
				enum119_0 = Class103.smethod_3(@class.Val);
			}
			else if (@class.Type == Enum304.const_27)
			{
				enum120_1 = Class103.smethod_1(@class.Val);
			}
			else if (@class.Type == Enum304.const_28)
			{
				enum121_1 = Class103.smethod_2(@class.Val);
			}
			else if (@class.Type == Enum304.const_21)
			{
				base.HorizontalAlignment = Class103.smethod_1(@class.Val);
			}
			else if (@class.Type == Enum304.const_54)
			{
				base.VerticalAlignment = Class103.smethod_2(@class.Val);
			}
			else if (@class.Type == Enum304.const_17)
			{
				enum122_0 = method_0(@class.Val);
			}
		}
	}

	private Enum122 method_0(string value)
	{
		return value switch
		{
			"2D" => Enum122.const_1, 
			"1D" => Enum122.const_0, 
			_ => Enum122.const_0, 
		};
	}
}
