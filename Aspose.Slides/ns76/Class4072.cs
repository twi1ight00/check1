using System.Text.RegularExpressions;
using ns305;
using ns73;
using ns88;

namespace ns76;

internal class Class4072
{
	private Class3726 class3726_0;

	private static Regex regex_0;

	private static Regex HexColor
	{
		get
		{
			if (regex_0 == null)
			{
				regex_0 = new Regex("(?<HEX>[0-9A-Fa-f]{6})|(?<HEXS>[0-9A-Fa-f]{3})\\s*", RegexOptions.Compiled);
			}
			return regex_0;
		}
	}

	public Class4072(Class3726 engine)
	{
		class3726_0 = engine;
	}

	public Class3717 method_0(Class6981 element)
	{
		Class3717 @class = new Class3717(class3726_0);
		switch (element.TagName)
		{
		case "FONT":
		case "BASEFONT":
			method_1(element, @class);
			break;
		case "TABLE":
			method_2(element, @class);
			break;
		case "TD":
		case "TH":
			method_3(element, @class);
			break;
		case "TR":
			method_4(element, @class);
			break;
		case "P":
			method_5(element, @class);
			break;
		}
		return @class;
	}

	private void method_1(Class6981 element, Class3717 declaration)
	{
		if (element.method_34("color"))
		{
			string text = element.method_20("color");
			if (!string.IsNullOrEmpty(text))
			{
				Match match = HexColor.Match(text);
				if (match.Success)
				{
					text = "#" + match.Value;
				}
				declaration.imethod_248("color", text, null);
			}
		}
		if (element.method_34("size"))
		{
			string text2 = element.method_20("size");
			if (!string.IsNullOrEmpty(text2))
			{
				try
				{
					Class4247 @class = new Class4247();
					Class3680 class2 = (Class3680)@class.method_0(text2);
					text2 = ((text2[0] != '-' && text2[0] != '+') ? smethod_1((int)class2.vmethod_1(1)) : smethod_1(3 + (int)class2.vmethod_1(1)));
				}
				catch (Exception11)
				{
				}
				declaration.imethod_248("font-size", text2, null);
			}
		}
		if (element.method_34("face"))
		{
			string value = element.method_20("face");
			if (!string.IsNullOrEmpty(value))
			{
				declaration.imethod_248("font-family", value, null);
			}
		}
	}

	private void method_2(Class6981 element, Class3717 declaration)
	{
		if (element.method_34("width"))
		{
			string value = element.method_20("width");
			if (!string.IsNullOrEmpty(value))
			{
				declaration.imethod_248("width", value, null);
			}
		}
		if (element.method_34("border"))
		{
			string text = element.method_20("border");
			if (!string.IsNullOrEmpty(text))
			{
				if (!int.TryParse(text, out var result))
				{
					result = 1;
				}
				text = result + "px";
				declaration.imethod_248("border-width", text, null);
				declaration.imethod_248("border-style", "outset", null);
			}
		}
		if (element.method_34("bgcolor"))
		{
			string text2 = element.method_20("bgcolor");
			if (!string.IsNullOrEmpty(text2))
			{
				Match match = HexColor.Match(text2);
				if (match.Success)
				{
					text2 = "#" + match.Value;
				}
				declaration.imethod_248("background-color", text2, null);
			}
		}
		if (element.method_34("bordercolor"))
		{
			string text3 = element.method_20("bordercolor");
			if (!string.IsNullOrEmpty(text3))
			{
				Match match2 = HexColor.Match(text3);
				if (match2.Success)
				{
					text3 = "#" + match2.Value;
				}
				declaration.imethod_248("border-color", text3, null);
				declaration.imethod_248("border-style", "solid", null);
			}
		}
		if (element.method_34("align"))
		{
			string text4 = element.method_20("align");
			if (!string.IsNullOrEmpty(text4))
			{
				text4 = text4.ToLower();
				if (text4 == "center")
				{
					declaration.imethod_248("margin", "0px auto", null);
				}
			}
		}
		if (element.method_34("cellspacing"))
		{
			string value2 = element.method_20("cellspacing");
			if (!string.IsNullOrEmpty(value2))
			{
				declaration.imethod_248("border-spacing", value2, null);
			}
		}
		if (element.ParentNode != null && element.ParentNode.NodeType == Enum969.const_0)
		{
			Class6981 @class = (Class6981)element.ParentNode;
			if (@class.TagName == "DIV" && @class.method_34("align"))
			{
				string text5 = @class.method_20("align");
				if (!string.IsNullOrEmpty(text5) && "center" == text5.ToLower())
				{
					declaration.imethod_248("margin-left", "auto", null);
					declaration.imethod_248("margin-right", "auto", null);
				}
			}
		}
		if (element.method_34("dir"))
		{
			string text6 = element.method_20("dir");
			if (!string.IsNullOrEmpty(text6) && ("rtl" == text6 || "ltr" == text6))
			{
				declaration.imethod_248("direction", text6, null);
			}
		}
	}

	private void method_3(Class6981 element, Class3717 declaration)
	{
		Class6981 @class = smethod_0(element, "TABLE", 3);
		if (@class != null)
		{
			if (@class.method_34("border"))
			{
				string text = @class.method_20("border");
				if (!string.IsNullOrEmpty(text))
				{
					if (!int.TryParse(text, out var result))
					{
						result = 1;
					}
					if (result == 0)
					{
						declaration.imethod_248("border-width", "0", null);
						declaration.imethod_248("border-style", "none", null);
					}
					else
					{
						declaration.imethod_248("border-width", "1px", null);
						declaration.imethod_248("border-style", "inset", null);
					}
				}
			}
			if (@class.method_34("bordercolor"))
			{
				string text2 = @class.method_20("bordercolor");
				if (!string.IsNullOrEmpty(text2))
				{
					Match match = HexColor.Match(text2);
					if (match.Success)
					{
						text2 = "#" + match.Value;
					}
					declaration.imethod_248("border-color", text2, null);
					declaration.imethod_248("border-style", "solid", null);
				}
			}
		}
		if (element.method_34("align"))
		{
			string value = element.method_20("align");
			if (!string.IsNullOrEmpty(value))
			{
				declaration.imethod_248("text-align", value, null);
			}
		}
		if (element.method_34("valign"))
		{
			string value2 = element.method_20("valign");
			if (!string.IsNullOrEmpty(value2))
			{
				declaration.imethod_248("vertical-align", value2, null);
			}
		}
		if (element.method_34("width"))
		{
			string value3 = element.method_20("width");
			if (!string.IsNullOrEmpty(value3))
			{
				declaration.imethod_248("width", value3, null);
			}
		}
		if (element.method_34("height"))
		{
			string value4 = element.method_20("height");
			if (!string.IsNullOrEmpty(value4))
			{
				declaration.imethod_248("height", value4, null);
			}
		}
		if (!element.method_34("bgcolor"))
		{
			return;
		}
		string text3 = element.method_20("bgcolor");
		if (!string.IsNullOrEmpty(text3))
		{
			Match match2 = HexColor.Match(text3);
			if (match2.Success)
			{
				text3 = "#" + match2.Value;
			}
			declaration.imethod_248("background-color", text3, null);
		}
	}

	private void method_4(Class6981 element, Class3717 declaration)
	{
		if (!element.method_34("bgcolor"))
		{
			return;
		}
		string text = element.method_20("bgcolor");
		if (!string.IsNullOrEmpty(text))
		{
			Match match = HexColor.Match(text);
			if (match.Success)
			{
				text = "#" + match.Value;
			}
			declaration.imethod_248("background-color", text, null);
		}
	}

	private void method_5(Class6981 element, Class3717 declaration)
	{
		if (element.method_34("align"))
		{
			string value = element.method_20("align");
			if (!string.IsNullOrEmpty(value))
			{
				declaration.imethod_248("text-align", value, null);
			}
		}
	}

	private static Class6981 smethod_0(Class6981 element, string tagName, int maxLevel)
	{
		Class6981 @class = element;
		while (maxLevel > 0 && @class.ParentNode != null && @class.ParentNode.NodeType == Enum969.const_0)
		{
			@class = (Class6981)@class.ParentNode;
			if (!string.Equals(@class.TagName, tagName))
			{
				maxLevel--;
				continue;
			}
			return @class;
		}
		return null;
	}

	private static string smethod_1(int value)
	{
		switch (value)
		{
		default:
			if (value < 1)
			{
				return "small";
			}
			return "xxx-large";
		case 1:
			return "xx-small";
		case 2:
			return "small";
		case 3:
			return "medium";
		case 4:
			return "large";
		case 5:
			return "x-large";
		case 6:
			return "xx-large";
		case 7:
			return "xxx-large";
		}
	}
}
