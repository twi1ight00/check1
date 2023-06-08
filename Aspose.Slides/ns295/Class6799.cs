using ns306;

namespace ns295;

internal class Class6799 : Interface327
{
	private const string string_0 = "{0}_{1}";

	private int int_0;

	public string imethod_0(Class6982 element)
	{
		return $"{element.TagName}_{++int_0}";
	}
}
