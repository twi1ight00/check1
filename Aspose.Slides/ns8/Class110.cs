using ns56;

namespace ns8;

internal class Class110 : Class103
{
	private string string_0;

	private string string_1;

	private string string_2;

	private Enum119 enum119_0;

	private Enum119 enum119_1;

	private Enum127 enum127_0;

	private Enum128 enum128_0;

	public string LevelNode => string_0;

	public string ChildBackgroundNode => string_1;

	public string AccentBackgroundNode => string_2;

	public Enum119 Direction => enum119_0;

	public Enum119 TextDirection => enum119_1;

	public Enum127 AccentPosition => enum127_0;

	public Enum128 AccentTextMargin => enum128_0;

	public Class110(Class2146 algorithm)
	{
		enum119_0 = Enum119.const_4;
		enum119_1 = Enum119.const_4;
		enum127_0 = Enum127.const_0;
		enum128_0 = Enum128.const_0;
		Class2177[] paramList = algorithm.ParamList;
		foreach (Class2177 @class in paramList)
		{
			if (@class.Type == Enum304.const_22)
			{
				enum119_0 = Class103.smethod_3(@class.Val);
			}
			else if (@class.Type == Enum304.const_53)
			{
				enum119_1 = Class103.smethod_3(@class.Val);
			}
			else if (@class.Type == Enum304.const_33)
			{
				enum127_0 = ((@class.Val == "aft") ? Enum127.const_1 : Enum127.const_0);
			}
			else if (@class.Type == Enum304.const_34)
			{
				enum128_0 = ((!(@class.Val == "step")) ? Enum128.const_1 : Enum128.const_0);
			}
			else if (@class.Type == Enum304.const_36)
			{
				string_0 = @class.Val;
			}
			else if (@class.Type == Enum304.const_32)
			{
				string_2 = @class.Val;
			}
			else if (@class.Type == Enum304.const_35)
			{
				string_1 = @class.Val;
			}
		}
	}
}
