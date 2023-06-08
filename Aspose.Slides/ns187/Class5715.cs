using ns171;

namespace ns187;

internal class Class5715
{
	private static Class5715 class5715_0 = new Class5715(null, null);

	private string string_0;

	private string string_1;

	private Class5715(string sourceDocument, string role)
	{
		string_0 = sourceDocument;
		string_1 = role;
	}

	public static Class5715 smethod_0(Class5634 propertyList)
	{
		string text = propertyList.method_5(221).vmethod_13();
		if ("none".Equals(text))
		{
			text = null;
		}
		string text2 = propertyList.method_5(212).vmethod_13();
		if ("none".Equals(text2))
		{
			text2 = null;
		}
		if (text == null && text2 == null)
		{
			return class5715_0;
		}
		return new Class5715(text, text2);
	}

	public string method_0()
	{
		return string_0;
	}

	public string method_1()
	{
		return string_1;
	}
}
