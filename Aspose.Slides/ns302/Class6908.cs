using System;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Xml;
using ns301;

namespace ns302;

internal class Class6908
{
	private const char char_0 = '<';

	private const char char_1 = '>';

	private const char char_2 = '/';

	private const string string_0 = " {0}=\"{1}\"";

	private const string string_1 = " {0}";

	private const string string_2 = " {0}={1}";

	private const string string_3 = "_child_{0}";

	private const char char_3 = '%';

	private const char char_4 = ' ';

	private const string string_4 = "--";

	private const string string_5 = " - -";

	private const string string_6 = "<!--{0} -->";

	private const string string_7 = "<?xml version=\"1.0\" encoding=\"{0}\"?>";

	private const string string_8 = "version=\"1.0\" encoding=\"{0}\"";

	private const string string_9 = "xml";

	private const string string_10 = "<span>";

	private const string string_11 = "</span>";

	private const char char_5 = '?';

	private const string string_12 = "<{0}";

	private const string string_13 = " />";

	private const string string_14 = "</{0}";

	private const string string_15 = "></{0}>";

	private const string string_16 = "\r\n//<![CDATA[\r\n";

	private const string string_17 = "\r\n//]]>//\r\n";

	public static readonly string string_18;

	public static readonly string string_19;

	public static readonly string string_20;

	public static Hashtable hashtable_0;

	internal Enum944 enum944_0;

	internal Class6908 class6908_0;

	internal Class6908 class6908_1;

	internal Class6908 class6908_2;

	internal Class6905 class6905_0;

	internal Class6911 class6911_0;

	internal Class6902 class6902_0;

	internal int int_0;

	internal int int_1;

	internal int int_2;

	internal int int_3;

	internal int int_4;

	internal int int_5;

	internal int int_6;

	internal int int_7;

	internal int int_8;

	internal bool bool_0;

	internal string string_21;

	internal Class6908 class6908_3;

	internal Class6908 class6908_4;

	internal bool bool_1;

	internal bool bool_2;

	internal string string_22;

	internal string string_23;

	public int Line => int_0;

	public int LinePosition => int_1;

	public bool Closed => class6908_4 != null;

	public string Name
	{
		get
		{
			if (string_21 == null)
			{
				string_21 = class6905_0.stringBuilder_0.ToString(int_7, int_8).ToLower(CultureInfo.InvariantCulture);
			}
			return string_21;
		}
		set
		{
			string_21 = value;
		}
	}

	public virtual string InnerText
	{
		get
		{
			if (enum944_0 == Enum944.const_3)
			{
				return ((Class6909)this).Text;
			}
			if (enum944_0 == Enum944.const_2)
			{
				return ((Class6910)this).Comment;
			}
			if (!HasChildNodes)
			{
				return string.Empty;
			}
			string text = null;
			foreach (Class6908 childNode in ChildNodes)
			{
				text += childNode.InnerText;
			}
			return text;
		}
	}

	public virtual string InnerHtml
	{
		get
		{
			if (bool_1)
			{
				string_22 = method_9();
				bool_1 = false;
				return string_22;
			}
			if (string_22 != null)
			{
				return string_22;
			}
			if (int_3 < 0)
			{
				return string.Empty;
			}
			try
			{
				return class6905_0.stringBuilder_0.ToString(int_3, int_4);
			}
			catch (Exception)
			{
				return string.Empty;
			}
		}
	}

	public virtual string OuterHtml
	{
		get
		{
			if (bool_2)
			{
				string_23 = method_8();
				bool_2 = false;
				return string_23;
			}
			if (string_23 != null)
			{
				return string_23;
			}
			if (int_5 < 0)
			{
				return string.Empty;
			}
			return class6905_0.stringBuilder_0.ToString(int_5, int_6);
		}
	}

	public Class6908 NextSibling => class6908_0;

	public Class6908 PreviousSibling => class6908_1;

	public Class6908 FirstChild
	{
		get
		{
			if (!HasChildNodes)
			{
				return null;
			}
			return class6911_0[0];
		}
	}

	public Class6908 LastChild
	{
		get
		{
			if (!HasChildNodes)
			{
				return null;
			}
			return class6911_0[class6911_0.Count - 1];
		}
	}

	public Enum944 NodeType => enum944_0;

	public Class6908 ParentNode => class6908_2;

	public Class6905 OwnerDocument => class6905_0;

	public Class6911 ChildNodes
	{
		get
		{
			if (class6911_0 == null)
			{
				class6911_0 = new Class6911(this);
			}
			return class6911_0;
		}
	}

	public bool HasAttributes
	{
		get
		{
			if (class6902_0 == null)
			{
				return false;
			}
			if (class6902_0.Count <= 0)
			{
				return false;
			}
			return true;
		}
	}

	public bool HasChildNodes
	{
		get
		{
			if (class6911_0 == null)
			{
				return false;
			}
			if (class6911_0.Count <= 0)
			{
				return false;
			}
			return true;
		}
	}

	public bool HasParentNode
	{
		get
		{
			if (class6908_2 == null)
			{
				return false;
			}
			return true;
		}
	}

	public Class6902 Attributes
	{
		get
		{
			if (!HasAttributes)
			{
				class6902_0 = new Class6902(this);
			}
			return class6902_0;
		}
	}

	static Class6908()
	{
		string_18 = "#comment";
		string_19 = "#document";
		string_20 = "#text";
		hashtable_0 = new Hashtable();
		hashtable_0.Add("script", Enum943.flag_0);
		hashtable_0.Add("style", Enum943.flag_0);
		hashtable_0.Add("noxhtml", Enum943.flag_0);
		hashtable_0.Add("base", Enum943.flag_1);
		hashtable_0.Add("link", Enum943.flag_1);
		hashtable_0.Add("meta", Enum943.flag_1);
		hashtable_0.Add("isindex", Enum943.flag_1);
		hashtable_0.Add("hr", Enum943.flag_1);
		hashtable_0.Add("col", Enum943.flag_1);
		hashtable_0.Add("img", Enum943.flag_1);
		hashtable_0.Add("param", Enum943.flag_1);
		hashtable_0.Add("embed", Enum943.flag_1);
		hashtable_0.Add("frame", Enum943.flag_1);
		hashtable_0.Add("wbr", Enum943.flag_1);
		hashtable_0.Add("bgsound", Enum943.flag_1);
		hashtable_0.Add("spacer", Enum943.flag_1);
		hashtable_0.Add("keygen", Enum943.flag_1);
		hashtable_0.Add("area", Enum943.flag_1);
		hashtable_0.Add("input", Enum943.flag_1);
		hashtable_0.Add("form", Enum943.flag_3);
		hashtable_0.Add("option", Enum943.flag_1);
		hashtable_0.Add("br", Enum943.flag_1 | Enum943.flag_2 | Enum943.flag_4);
		hashtable_0.Add("p", Enum943.flag_1 | Enum943.flag_2);
	}

	public static bool smethod_0(string name)
	{
		return smethod_1(name, Enum943.flag_2);
	}

	public static bool smethod_1(string name, Enum943 flags)
	{
		Class6892.smethod_0(name, "name");
		object obj = hashtable_0[name.ToLower(CultureInfo.InvariantCulture)];
		if (obj == null)
		{
			return false;
		}
		return ((Enum943)obj & flags) != 0;
	}

	public static bool smethod_2(string name)
	{
		Class6892.smethod_0(name, "name");
		object obj = hashtable_0[name.ToLower(CultureInfo.InvariantCulture)];
		if (obj == null)
		{
			return false;
		}
		return ((Enum943)obj & Enum943.flag_3) != 0;
	}

	public static bool smethod_3(string name)
	{
		Class6892.smethod_0(name, "name");
		object obj = hashtable_0[name.ToLower(CultureInfo.InvariantCulture)];
		if (obj == null)
		{
			return false;
		}
		return ((Enum943)obj & Enum943.flag_0) != 0;
	}

	public static bool smethod_4(string name)
	{
		Class6892.smethod_0(name, "name");
		if (name.Length == 0)
		{
			return true;
		}
		if ('!' == name[0])
		{
			return true;
		}
		if ('?' == name[0])
		{
			return true;
		}
		object obj = hashtable_0[name.ToLower(CultureInfo.InvariantCulture)];
		if (obj == null)
		{
			return false;
		}
		return ((Enum943)obj & Enum943.flag_1) != 0;
	}

	public static Class6908 smethod_5(string html)
	{
		Class6905 @class = new Class6905();
		@class.bool_12 = true;
		@class.method_1(html);
		return @class.DocumentNode;
	}

	internal Class6908(Enum944 type, Class6905 ownerdocument, int index)
	{
		enum944_0 = type;
		class6905_0 = ownerdocument;
		int_5 = index;
		switch (type)
		{
		case Enum944.const_0:
			string_21 = string_19;
			class6908_4 = this;
			break;
		case Enum944.const_2:
			string_21 = string_18;
			class6908_4 = this;
			break;
		case Enum944.const_3:
			string_21 = string_20;
			class6908_4 = this;
			break;
		}
		if (class6905_0.hashtable_0 != null && !Closed && -1 != index)
		{
			class6905_0.hashtable_0.Add(index, this);
		}
		if (-1 == index && type != Enum944.const_2 && type != Enum944.const_3)
		{
			bool_2 = true;
			bool_1 = true;
		}
	}

	internal void method_0(Class6908 endnode)
	{
		if (!class6905_0.bool_11 && class6911_0 != null)
		{
			foreach (Class6908 item in class6911_0)
			{
				if (!item.Closed)
				{
					Class6908 class2 = new Class6908(NodeType, class6905_0, -1);
					class2.class6908_4 = class2;
					item.method_0(class2);
				}
			}
		}
		if (!Closed)
		{
			class6908_4 = endnode;
			if (class6905_0.hashtable_0 != null)
			{
				class6905_0.hashtable_0.Remove(int_5);
			}
			Class6908 class3 = class6905_0.hashtable_1[Name] as Class6908;
			if (class3 == this)
			{
				class6905_0.hashtable_1.Remove(Name);
				class6905_0.method_27();
			}
			if (endnode != this)
			{
				int_3 = int_5 + int_6;
				int_4 = endnode.int_5 - int_3;
				int_6 = endnode.int_5 + endnode.int_6 - int_5;
			}
		}
	}

	internal string method_1()
	{
		return Attributes["id"]?.Value;
	}

	public Class6908 method_2(Class6908 oldChild)
	{
		Class6892.smethod_0(oldChild, "oldChild");
		int num = -1;
		if (class6911_0 != null)
		{
			num = class6911_0[oldChild];
		}
		if (num == -1)
		{
			throw new ArgumentException(Class6905.string_5);
		}
		class6911_0.Remove(num);
		class6905_0.method_4(null, oldChild.method_1());
		bool_2 = true;
		bool_1 = true;
		return oldChild;
	}

	public Class6908 method_3(Class6908 newChild)
	{
		Class6892.smethod_0(newChild, "newChild");
		ChildNodes.method_0(newChild);
		class6905_0.method_4(newChild, newChild.method_1());
		bool_2 = true;
		bool_1 = true;
		return newChild;
	}

	public void method_4(Class6911 newChildren)
	{
		Class6892.smethod_0(newChildren, "newChildren");
		foreach (Class6908 newChild in newChildren)
		{
			method_3(newChild);
		}
	}

	internal static string smethod_6(Class6910 comment)
	{
		string comment2 = comment.Comment;
		return comment2.Substring(4, comment2.Length - 7).Replace("--", " - -");
	}

	public void method_5(TextWriter outText)
	{
		switch (enum944_0)
		{
		case Enum944.const_1:
		{
			string text2 = ((!class6905_0.bool_7) ? Name : Name.ToUpper(CultureInfo.InvariantCulture));
			if (class6905_0.bool_6)
			{
				if (text2.Length <= 0 || text2[0] == '?' || text2.Trim().Length == 0)
				{
					break;
				}
				text2 = Class6905.smethod_1(text2);
			}
			outText.Write("<{0}", text2);
			if (!HasChildNodes)
			{
				if (smethod_4(Name))
				{
					if (!class6905_0.bool_5 && !class6905_0.bool_6)
					{
						if (Name.Length > 0 && Name[0] == '?')
						{
							outText.Write('?'.ToString(CultureInfo.InvariantCulture));
						}
						outText.Write('>'.ToString(CultureInfo.InvariantCulture));
					}
					else
					{
						outText.Write(" />");
					}
				}
				else
				{
					outText.Write("></{0}>", text2);
				}
				break;
			}
			outText.Write('>'.ToString(CultureInfo.InvariantCulture));
			bool flag = false;
			if (class6905_0.bool_6 && smethod_3(Name))
			{
				flag = true;
				outText.Write("\r\n//<![CDATA[\r\n");
			}
			if (flag)
			{
				if (HasChildNodes)
				{
					ChildNodes[0].method_5(outText);
				}
				outText.Write("\r\n//]]>//\r\n");
			}
			else
			{
				method_7(outText);
			}
			outText.Write("</{0}", text2);
			outText.Write('>'.ToString(CultureInfo.InvariantCulture));
			break;
		}
		case Enum944.const_2:
		{
			string text = ((Class6910)this).Comment;
			if (class6905_0.bool_6)
			{
				outText.Write("<!--{0} -->", smethod_6((Class6910)this));
			}
			else
			{
				outText.Write(text);
			}
			break;
		}
		case Enum944.const_3:
		{
			string text = ((Class6909)this).Text;
			if (class6905_0.bool_6)
			{
				outText.Write(Class6905.smethod_0(text));
			}
			else
			{
				outText.Write(text);
			}
			break;
		}
		}
	}

	public void method_6(XmlWriter writer)
	{
		switch (enum944_0)
		{
		case Enum944.const_1:
		{
			string localName = ((!class6905_0.bool_7) ? Name : Name.ToUpper(CultureInfo.InvariantCulture));
			writer.WriteStartElement(localName);
			if (HasChildNodes)
			{
				foreach (Class6908 childNode in ChildNodes)
				{
					childNode.method_6(writer);
				}
			}
			writer.WriteEndElement();
			break;
		}
		case Enum944.const_2:
			writer.WriteComment(smethod_6((Class6910)this));
			break;
		case Enum944.const_3:
		{
			string text = ((Class6909)this).Text;
			writer.WriteString(text);
			break;
		}
		}
	}

	public void method_7(TextWriter outText)
	{
		if (class6911_0 == null)
		{
			return;
		}
		foreach (Class6908 item in class6911_0)
		{
			item.method_5(outText);
		}
	}

	public string method_8()
	{
		StringWriter stringWriter = new StringWriter(CultureInfo.InvariantCulture);
		method_5(stringWriter);
		stringWriter.Flush();
		return stringWriter.ToString();
	}

	public string method_9()
	{
		StringWriter stringWriter = new StringWriter(CultureInfo.InvariantCulture);
		method_7(stringWriter);
		stringWriter.Flush();
		return stringWriter.ToString();
	}
}
