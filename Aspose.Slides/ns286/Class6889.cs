using System.Drawing;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using ns277;
using ns284;
using ns287;
using ns289;
using ns296;
using ns298;
using ns301;
using ns305;
using ns84;

namespace ns286;

internal class Class6889
{
	private const string string_0 = "http://www.w3.org/1999/XSL/Format";

	private const string string_1 = "fo";

	private const char char_0 = '<';

	private const char char_1 = '>';

	private const char char_2 = '&';

	private Class6890 class6890_0;

	private readonly Interface355 interface355_0;

	private static Regex regex_0 = new Regex("&#[xX][0-9a-fA-F]{2,6};");

	private static CultureInfo cultureInfo_0 = Class6872.HtmlCulture;

	private readonly int int_0 = Color.Transparent.ToArgb();

	private readonly int int_1 = Color.White.ToArgb();

	private Class6772 class6772_0;

	public Class6889(Class6772 builder, Class6890 writer, Interface355 settings)
	{
		class6890_0 = writer;
		interface355_0 = settings;
		class6772_0 = builder;
	}

	private Class6889 method_0()
	{
		class6890_0.method_0("fo:root", null, null, Class6880.Instance.method_0());
		return this;
	}

	public Class6889 method_1(Class6779 options, Class7015 page)
	{
		method_0();
		class6890_0.method_3("fo", "root", "http://www.w3.org/1999/XSL/Format");
		method_2(options, page);
		return this;
	}

	private Class6889 method_2(Class6779 options, Class7015 page)
	{
		Class6886 @class = new Class6886(class6772_0);
		int num = page.StyleDeclarationInternal.Background.Color.ToArgb();
		if (int_0 == num || int_1 == num)
		{
			Class7001 body = ((Class7047)page.OwnerDocument).Body;
			num = body.StyleDeclarationInternal.Background.Color.ToArgb();
		}
		if (int_0 != num && int_1 != num)
		{
			@class.BackgroundColor = $"#{num & 0xFFFFFF:x6}";
		}
		method_57("layout-master-set", "http://www.w3.org/1999/XSL/Format");
		if (options.PageSetup.AnyPage != null)
		{
			Class6886 properties = method_3("any_page", options.PageSetup.AnyPage);
			method_58("simple-page-master", "http://www.w3.org/1999/XSL/Format", properties).method_56("region-body", @class).method_7().method_7();
		}
		if (options.PageSetup.FirstPage != null)
		{
			Class6886 properties2 = method_3("first_page", options.PageSetup.FirstPage);
			method_58("simple-page-master", "http://www.w3.org/1999/XSL/Format", properties2).method_56("region-body", @class).method_7().method_7();
		}
		if (options.PageSetup.LastPage != null)
		{
			Class6886 properties3 = method_3("last_page", options.PageSetup.LastPage);
			method_58("simple-page-master", "http://www.w3.org/1999/XSL/Format", properties3).method_56("region-body", @class).method_7().method_7();
		}
		if (options.PageSetup.OddPage != null)
		{
			Class6886 properties4 = method_3("odd_page", options.PageSetup.OddPage);
			method_58("simple-page-master", "http://www.w3.org/1999/XSL/Format", properties4).method_56("region-body", @class).method_7().method_7();
		}
		if (options.PageSetup.EvenPage != null)
		{
			Class6886 properties5 = method_3("even_page", options.PageSetup.EvenPage);
			method_58("simple-page-master", "http://www.w3.org/1999/XSL/Format", properties5).method_56("region-body", @class).method_7().method_7();
		}
		Class6886 class2 = new Class6886(class6772_0);
		class2.MasterName = "page_layuot";
		method_58("page-sequence-master", "http://www.w3.org/1999/XSL/Format", class2);
		if (options.PageSetup.AnyPage != null && options.PageSetup.FirstPage == null && options.PageSetup.LastPage == null)
		{
			class2 = new Class6886(class6772_0);
			class2.MasterReference = "any_page";
			method_58("single-page-master-reference", "http://www.w3.org/1999/XSL/Format", class2).method_7();
		}
		else
		{
			method_58("repeatable-page-master-alternatives", "http://www.w3.org/1999/XSL/Format", class2);
			if (options.PageSetup.FirstPage != null)
			{
				class2 = new Class6886(class6772_0);
				class2.PagePosition = "first";
				class2.MasterReference = "first_page";
				method_58("conditional-page-master-reference", "http://www.w3.org/1999/XSL/Format", class2).method_7();
			}
			if (options.PageSetup.LastPage != null)
			{
				class2 = new Class6886(class6772_0);
				class2.PagePosition = "last";
				class2.MasterReference = "last_page";
				method_58("conditional-page-master-reference", "http://www.w3.org/1999/XSL/Format", class2).method_7();
			}
			if (options.PageSetup.AnyPage != null)
			{
				class2 = new Class6886(class6772_0);
				class2.PagePosition = "any";
				class2.MasterReference = "any_page";
				method_58("conditional-page-master-reference", "http://www.w3.org/1999/XSL/Format", class2).method_7();
			}
			if (options.PageSetup.OddPage != null)
			{
				class2 = new Class6886(class6772_0);
				class2.OddOrEven = "odd";
				class2.MasterReference = "odd_page";
				method_58("conditional-page-master-reference", "http://www.w3.org/1999/XSL/Format", class2).method_7();
			}
			if (options.PageSetup.EvenPage != null)
			{
				class2 = new Class6886(class6772_0);
				class2.OddOrEven = "even";
				class2.MasterReference = "even_page";
				method_58("conditional-page-master-reference", "http://www.w3.org/1999/XSL/Format", class2).method_7();
			}
			method_7();
		}
		method_7();
		method_7();
		return this;
	}

	private Class6886 method_3(string pageName, Class6780 page)
	{
		Class6886 @class = new Class6886(class6772_0);
		@class.MasterName = pageName;
		@class.MarginTop = page.Margin.Top.ToString();
		@class.MarginRight = page.Margin.Right.ToString();
		@class.MarginBottom = page.Margin.Bottom.ToString();
		@class.MarginLeft = page.Margin.Left.ToString();
		@class.PageWidth = page.Size.Width.ToString();
		@class.PageHeight = page.Size.Height.ToString();
		return @class;
	}

	public Class6889 method_4(string localName, string value)
	{
		class6890_0.method_6(localName, value);
		return this;
	}

	private Class6889 method_5(Class6886 properties)
	{
		foreach (Class6886.Class6887 property in properties)
		{
			string value;
			switch (property.Name)
			{
			case "src":
			case "background-image":
				value = property.Value;
				break;
			default:
				value = property.Value.ToLower();
				break;
			}
			class6890_0.method_6(property.Name, value);
		}
		return this;
	}

	public Class6889 method_6()
	{
		Class6886 @class = new Class6886(class6772_0);
		@class.MasterReference = "page_layuot";
		Class6886 class2 = new Class6886(class6772_0);
		class2.FlowName = "xsl-region-body";
		return method_56("page-sequence", @class).method_56("flow", class2);
	}

	public Class6889 method_7()
	{
		class6890_0.method_4();
		return this;
	}

	public Class6889 method_8()
	{
		class6890_0.method_5();
		return this;
	}

	public Class6889 method_9()
	{
		return method_55("block-container");
	}

	public Class6889 method_10(Class6983 element)
	{
		return method_9().method_5(new Class6886(class6772_0, element, interface355_0));
	}

	public Class6889 method_11(Class6983 element, Class6886 properties)
	{
		properties = new Class6886(class6772_0, element, interface355_0).method_3(properties);
		return method_9().method_5(properties);
	}

	public Class6889 method_12(Class6886 properties)
	{
		return method_9().method_5(properties);
	}

	public Class6889 method_13()
	{
		return method_14(writeEndIndent: true);
	}

	public Class6889 method_14(bool writeEndIndent)
	{
		Class6886 @class = new Class6886(class6772_0);
		@class.StartIndent = "0";
		if (writeEndIndent)
		{
			@class.EndIndent = "0";
		}
		return method_55("block").method_5(@class);
	}

	public Class6889 method_15(Class6983 element)
	{
		return method_13().method_5(new Class6886(class6772_0, element, interface355_0));
	}

	public Class6889 method_16(Class6886 properties, bool writeEndIndent)
	{
		return method_14(writeEndIndent).method_5(properties);
	}

	public Class6889 method_17(Class6886 properties)
	{
		return method_13().method_5(properties);
	}

	public Class6889 method_18(Class6983 element, Class6886 properties)
	{
		properties = new Class6886(class6772_0, element, interface355_0).method_3(properties);
		return method_13().method_5(properties);
	}

	public Class6889 method_19(Enum627 @float)
	{
		Class6886 @class = new Class6886(class6772_0);
		@class.Float = ((@float == Enum627.const_0) ? "left" : "right");
		return method_55("float").method_5(@class);
	}

	public Class6889 method_20()
	{
		return method_55("basic-link");
	}

	public Class6889 method_21(Class6983 element, Class6886 properties)
	{
		properties = new Class6886(model: element.method_34("href") ? (element.StyleDeclarationInternal.Link ?? element.StyleDeclarationInternal) : element.StyleDeclarationInternal, builder: class6772_0, element: element, settings: interface355_0).method_3(properties);
		if (!element.method_34("href") && element.StyleDeclarationInternal.Color.ToArgb() == Color.Blue.ToArgb())
		{
			properties.TextDecoration = null;
			Class6983 parentElement = element.ParentElement;
			if (parentElement != null && parentElement.NodeType == Enum969.const_0)
			{
				properties.Color = new Class6809(parentElement, parentElement.StyleDeclarationInternal.Color).vmethod_0();
			}
		}
		return method_20().method_5(properties);
	}

	public Class6889 method_22()
	{
		return method_55("external-graphic");
	}

	public Class6889 method_23(Class6983 element, Class6886 properties)
	{
		Class4347 model = element.StyleDeclarationInternal.Link ?? element.StyleDeclarationInternal;
		properties = new Class6886(class6772_0, element, model, interface355_0).method_3(properties);
		return method_22().method_5(properties);
	}

	public Class6889 method_24()
	{
		return method_55("list-block");
	}

	public Class6889 method_25(Class6983 element)
	{
		return method_24().method_5(new Class6886(class6772_0, element, interface355_0));
	}

	public Class6889 method_26()
	{
		return method_55("list-item");
	}

	public Class6889 method_27(Class6886 properties)
	{
		return method_26().method_5(properties);
	}

	public Class6889 method_28()
	{
		return method_55("list-item-label");
	}

	public Class6889 method_29(Class6886 properties)
	{
		return method_28().method_5(properties);
	}

	public Class6889 method_30()
	{
		return method_55("list-item-body");
	}

	public Class6889 method_31(Class6886 properties)
	{
		return method_30().method_5(properties);
	}

	public Class6889 method_32()
	{
		return method_55("inline-container");
	}

	public Class6889 method_33(Class6983 element)
	{
		return method_34(new Class6886(class6772_0, element, interface355_0));
	}

	public Class6889 method_34(Class6886 properties)
	{
		return method_32().method_5(properties);
	}

	public Class6889 method_35()
	{
		return method_55("inline");
	}

	public Class6889 method_36(Class6886 properties)
	{
		return method_35().method_5(properties);
	}

	public Class6889 method_37(Class6983 element)
	{
		return method_36(new Class6886(class6772_0, element, interface355_0));
	}

	public Class6889 method_38(Class6983 element, Class6886 properties)
	{
		return method_36(new Class6886(class6772_0, element, interface355_0).method_3(properties));
	}

	public Class6889 method_39(Class4337 value)
	{
		Class6886 @class = new Class6886(class6772_0);
		@class.Width = value.ToString();
		method_34(@class).method_13().method_59("&nbsp;").method_7()
			.method_7();
		return this;
	}

	public Class6889 method_40()
	{
		return method_55("instream-foreign-object");
	}

	public Class6889 method_41()
	{
		return method_55("leader");
	}

	public Class6889 method_42(Class6886 properties)
	{
		return method_41().method_5(properties);
	}

	public Class6889 method_43()
	{
		return method_55("table");
	}

	public Class6889 method_44(Class6886 properties)
	{
		return method_43().method_5(properties);
	}

	public Class6889 method_45(Class6983 element, Class6886 properties)
	{
		properties = new Class6886(class6772_0, element, interface355_0).method_3(properties);
		return method_43().method_5(properties);
	}

	public Class6889 method_46()
	{
		return method_55("table-body");
	}

	public Class6889 method_47()
	{
		return method_55("table-row");
	}

	public Class6889 method_48(Class6983 element)
	{
		return method_47().method_5(new Class6886(class6772_0, element, interface355_0));
	}

	public Class6889 method_49(Class6886 properties)
	{
		return method_47().method_5(properties);
	}

	public Class6889 method_50()
	{
		return method_55("table-column");
	}

	public Class6889 method_51(Class6886 properties)
	{
		return method_50().method_5(properties);
	}

	public Class6889 method_52()
	{
		return method_55("table-cell");
	}

	public Class6889 method_53(Class6886 properties)
	{
		return method_52().method_5(properties);
	}

	public Class6889 method_54(Class6983 element, Class6886 properties)
	{
		properties = new Class6886(class6772_0, element, interface355_0).method_3(properties);
		if (element is Class7038 @class)
		{
			Class7040 class2 = @class.method_49<Class7040>();
			Class6993 class3 = @class.method_49<Class6993>();
			if (class2 != null && class3 != null && class3.FirstRow == class2)
			{
				Class7075 class4 = class3.method_26("COL");
				if (class4.Length != 0 && @class.CellIndex < class4.Length)
				{
					Class7039 class5 = (Class7039)class4[@class.CellIndex];
					float result = 0f;
					if (!string.IsNullOrEmpty(class5.Width) && char.IsNumber(class5.Width[0]))
					{
						if (Class6969.smethod_2(class5.Width, ref result))
						{
							Class6886 class6 = new Class6886(class6772_0);
							class6.Width = new Class4337(result, Enum634.const_8).ToString();
							properties.method_3(class6);
						}
					}
					else if (!class5.StyleDeclarationInternal.Width.IsAuto)
					{
						Class6886 class7 = new Class6886(class6772_0);
						class7.Width = class5.StyleDeclarationInternal.Width.ToString();
						properties.method_3(class7);
					}
				}
			}
		}
		return method_52().method_5(properties);
	}

	private Class6889 method_55(string name)
	{
		class6890_0.method_2(name, "http://www.w3.org/1999/XSL/Format");
		return this;
	}

	private Class6889 method_56(string name, Class6886 properties)
	{
		return method_58(name, "http://www.w3.org/1999/XSL/Format", properties);
	}

	private Class6889 method_57(string name, string ns)
	{
		class6890_0.method_2(name, ns);
		return this;
	}

	private Class6889 method_58(string name, string prefix, Class6886 properties)
	{
		return method_57(name, prefix).method_5(properties);
	}

	public Class6889 method_59(string text)
	{
		class6890_0.method_8(smethod_1(text));
		return this;
	}

	public Class6889 method_60(string text)
	{
		class6890_0.method_8(text);
		return this;
	}

	private static string smethod_0(Match m)
	{
		if (!int.TryParse(m.Value.Substring(3, m.Value.Length - 4), NumberStyles.HexNumber, cultureInfo_0, out var result))
		{
			return m.Value;
		}
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("&#").Append(result).Append(";");
		return stringBuilder.ToString();
	}

	private static string smethod_1(string text)
	{
		if (text.Length == 0)
		{
			return text;
		}
		int num = text.IndexOf('&');
		if (num != -1)
		{
			string text2 = text.ToLowerInvariant();
			while (num != -1)
			{
				if (!Class6880.Instance.method_1(text2, num, out var entry))
				{
					text = text.Remove(num, 1);
					text = text.Insert(num, "&amp;");
				}
				if (entry != null)
				{
					int num2 = num + entry.Entity.Length + 1;
					if (num2 >= text.Length)
					{
						text = text.Remove(num, 1);
						text = text.Insert(num, "&amp;");
					}
					else if (text[num2] != ';')
					{
						text = text.Insert(num2, ";");
					}
					for (int i = num; i < num2; i++)
					{
						if (!char.IsUpper(text[i]))
						{
							text = text.Remove(num + 1, entry.Entity.Length);
							text = text.Insert(num + 1, entry.Entity);
							break;
						}
					}
				}
				num = text.IndexOf('&', num + 1);
			}
		}
		num = text.IndexOf('<');
		if (num != -1)
		{
			while (num != -1)
			{
				text = text.Remove(num, 1);
				text = text.Insert(num, "&lt;");
				num = text.IndexOf('<', num + 1);
			}
		}
		num = text.IndexOf('>');
		if (num != -1)
		{
			while (num != -1)
			{
				text = text.Remove(num, 1);
				text = text.Insert(num, "&gt;");
				num = text.IndexOf('>', num + 1);
			}
		}
		text = regex_0.Replace(text, smethod_0);
		return text;
	}
}
