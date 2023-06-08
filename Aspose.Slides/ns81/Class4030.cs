using ns305;
using ns88;

namespace ns81;

internal class Class4030 : Class4029
{
	private string string_28;

	public override string ConditionText => string.Format(":{0}{1})", "dir(", string_28);

	public Class4030(string directional)
		: base("dir(")
	{
		if ("ltr" != directional && "rtl" != directional && "auto" != directional)
		{
			throw new Exception12(directional);
		}
		string_28 = directional;
	}

	public override bool imethod_0(Class6981 e, string pseudoElement)
	{
		string text = smethod_2(e);
		if (text.Equals(string_28))
		{
			return true;
		}
		if (text.Equals("auto") && string_28.Equals("ltr"))
		{
			return true;
		}
		return false;
	}

	private static string smethod_2(Class6981 element)
	{
		if (element.method_34("dir"))
		{
			string text = element.method_20("dir");
			if ("ltr" != text || "rtl" != text || "auto" != text)
			{
				return text;
			}
		}
		if (element.ParentNode != null && element.ParentNode.NodeType == Enum969.const_0)
		{
			return smethod_2(element.ParentNode as Class6981);
		}
		return "auto";
	}
}
