using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using ns301;

namespace ns302;

internal class Class6905
{
	private enum Enum942
	{
		const_0,
		const_1,
		const_2,
		const_3,
		const_4,
		const_5,
		const_6,
		const_7,
		const_8,
		const_9,
		const_10,
		const_11,
		const_12
	}

	private class Class6906
	{
		private bool bool_0;

		private int int_0;

		private bool bool_1;

		private bool bool_2;

		private bool bool_3;

		public bool IsNumericCharRef => bool_1;

		public bool IsValidEndChar => bool_2;

		public bool IsValidFormat => bool_3;

		public int Length => int_0;

		public void method_0(int c)
		{
			switch (Length)
			{
			default:
				if (c == 59)
				{
					bool_2 = true;
					return;
				}
				if (bool_0)
				{
					bool_3 = (c >= 48 && c <= 57) || (c >= 97 && c <= 102) || (c >= 65 && c <= 70);
				}
				else
				{
					bool_3 = c >= 48 && c <= 57;
				}
				if (!bool_3)
				{
					if ((bool_0 && Length == 3) || Length == 2)
					{
						bool_1 = false;
					}
					else
					{
						bool_2 = false;
					}
				}
				break;
			case 0:
				bool_1 = (bool_3 = 38 == c);
				break;
			case 1:
				bool_1 = 35 == c;
				break;
			case 2:
				if (88 != c && 120 != c)
				{
					bool_1 = c >= 48 && c <= 57;
					break;
				}
				bool_0 = true;
				bool_1 = true;
				break;
			}
			int_0 = Length + 1;
		}
	}

	private const string string_0 = "?xml";

	private const string string_1 = "End tag </{0}> was not found";

	private const string string_2 = "End tag </{0}> is not required";

	private const string string_3 = "Start tag <{0}> was not found";

	private const string string_4 = "End tag </{0}> invalid here";

	internal static readonly string string_5 = "Reference node must be a child of this node";

	internal Hashtable hashtable_0;

	internal Hashtable hashtable_1 = new Hashtable();

	internal Hashtable hashtable_2;

	private Class6908 class6908_0;

	internal StringBuilder stringBuilder_0;

	private string string_6;

	private int int_0;

	private Class6908 class6908_1;

	private Class6908 class6908_2;

	private Class6901 class6901_0;

	private int int_1;

	private int int_2;

	private int int_3;

	private int int_4;

	private int int_5;

	private bool bool_0;

	private Encoding encoding_0;

	private Encoding encoding_1;

	private List<Class6904> list_0 = new List<Class6904>();

	private Enum942 enum942_0;

	private Enum942 enum942_1;

	private bool bool_1;

	public bool bool_2 = true;

	public bool bool_3 = true;

	public bool bool_4 = true;

	public bool bool_5;

	public bool bool_6 = true;

	public bool bool_7;

	public bool bool_8;

	public bool bool_9;

	public bool bool_10;

	public bool bool_11;

	public bool bool_12;

	public int int_6 = 100;

	public Encoding encoding_2 = Encoding.Default;

	public string string_7;

	private Class6906 class6906_0;

	public Class6908 DocumentNode => class6908_0;

	public Class6905()
	{
		class6908_0 = method_6(Enum944.const_0, 0);
	}

	internal Class6908 method_0()
	{
		if (!class6908_0.HasChildNodes)
		{
			return null;
		}
		foreach (Class6908 item in class6908_0.class6911_0)
		{
			if (item.Name == "?xml")
			{
				return item;
			}
		}
		return null;
	}

	public static string smethod_0(string html)
	{
		Class6892.smethod_0(html, "html");
		Regex regex = new Regex("&(?!(amp;)|(lt;)|(gt;)|(quot;))", RegexOptions.IgnoreCase);
		return regex.Replace(html, "&amp;").Replace("<", "&lt;").Replace(">", "&gt;")
			.Replace("\"", "&quot;");
	}

	public void method_1(string html)
	{
		Class6892.smethod_0(html, "html");
		StringReader stringReader = new StringReader(html);
		method_2(stringReader);
		stringReader.Close();
	}

	public void method_2(TextReader reader)
	{
		Class6892.smethod_0(reader, "reader");
		bool_1 = false;
		if (bool_3)
		{
			hashtable_0 = new Hashtable();
		}
		else
		{
			hashtable_0 = null;
		}
		if (bool_4)
		{
			hashtable_2 = new Hashtable();
		}
		else
		{
			hashtable_2 = null;
		}
		if (reader is StreamReader streamReader)
		{
			try
			{
				streamReader.Peek();
			}
			catch
			{
			}
			encoding_0 = streamReader.CurrentEncoding;
		}
		else
		{
			encoding_0 = null;
		}
		encoding_1 = null;
		stringBuilder_0 = new StringBuilder(reader.ReadToEnd());
		class6908_0 = method_6(Enum944.const_0, 0);
		method_11();
		if (!bool_3)
		{
			return;
		}
		foreach (Class6908 value in hashtable_0.Values)
		{
			if (!value.bool_0)
			{
				continue;
			}
			string text;
			if (bool_10)
			{
				text = value.OuterHtml;
				if (text.Length > int_6)
				{
					text = text.Substring(0, int_6);
				}
			}
			else
			{
				text = string.Empty;
			}
			method_8(Enum941.const_0, value.int_0, value.int_1, value.int_2, text, string.Format(CultureInfo.InvariantCulture, "End tag </{0}> was not found", new object[1] { value.Name }));
		}
		hashtable_0.Clear();
	}

	internal Encoding method_3()
	{
		if (encoding_1 != null)
		{
			return encoding_1;
		}
		if (encoding_0 != null)
		{
			return encoding_0;
		}
		return encoding_2;
	}

	public static string smethod_1(string name)
	{
		StringBuilder stringBuilder = new StringBuilder();
		bool flag = true;
		for (int i = 0; i < name.Length; i++)
		{
			if ((name[i] < 'a' || name[i] > 'z') && (name[i] < '0' || name[i] > '9') && name[i] != '_' && name[i] != '-' && name[i] != '.')
			{
				flag = false;
				byte[] bytes = Encoding.UTF8.GetBytes(new char[1] { name[i] });
				for (int j = 0; j < bytes.Length; j++)
				{
					stringBuilder.Append(bytes[j].ToString("x2", CultureInfo.InvariantCulture));
				}
				stringBuilder.Append("_");
			}
			else
			{
				stringBuilder.Append(name[i]);
			}
		}
		if (flag)
		{
			return stringBuilder.ToString();
		}
		return string.Format(CultureInfo.InvariantCulture, "{0}{1}", new object[2] { "_", stringBuilder });
	}

	internal void method_4(Class6908 node, string id)
	{
		if (bool_4 && hashtable_2 != null && id != null)
		{
			if (node == null)
			{
				hashtable_2.Remove(id.ToLower(CultureInfo.InvariantCulture));
			}
			else
			{
				hashtable_2[id.ToLower(CultureInfo.InvariantCulture)] = node;
			}
		}
	}

	internal Class6908 method_5(Enum944 type)
	{
		return method_6(type, -1);
	}

	internal Class6908 method_6(Enum944 type, int index)
	{
		return type switch
		{
			Enum944.const_2 => new Class6910(this, index), 
			Enum944.const_3 => new Class6909(this, index), 
			_ => new Class6908(type, this, index), 
		};
	}

	internal Class6901 method_7()
	{
		return new Class6901(this);
	}

	private Class6904 method_8(Enum941 code, int line, int linePosition, int streamPosition, string sourceText, string reason)
	{
		Class6904 @class = new Class6904(code, line, linePosition, streamPosition, sourceText, reason);
		list_0.Add(@class);
		return @class;
	}

	private void method_9()
	{
		int_1++;
		int_4 = int_3;
		if (int_5 == 10)
		{
			int_3 = 1;
			int_2++;
		}
		else
		{
			int_3++;
		}
	}

	private void method_10()
	{
		int_1--;
		if (int_3 == 1)
		{
			int_3 = int_4;
			int_2--;
		}
		else
		{
			int_3--;
		}
	}

	private void method_11()
	{
		int num = 0;
		hashtable_1 = new Hashtable();
		int_5 = 0;
		bool_0 = false;
		list_0 = new List<Class6904>();
		int_2 = 1;
		int_3 = 1;
		int_4 = 1;
		enum942_0 = Enum942.const_0;
		enum942_1 = enum942_0;
		class6908_0.int_4 = stringBuilder_0.Length;
		class6908_0.int_6 = stringBuilder_0.Length;
		int_0 = stringBuilder_0.Length;
		class6908_2 = class6908_0;
		class6908_1 = method_6(Enum944.const_3, 0);
		class6901_0 = null;
		int_1 = 0;
		method_18(Enum944.const_3, 0);
		while (int_1 < stringBuilder_0.Length)
		{
			int_5 = stringBuilder_0[int_1];
			if (class6906_0 != null)
			{
				class6906_0.method_0(int_5);
				if (class6906_0.IsNumericCharRef && !class6906_0.IsValidEndChar)
				{
					if (!class6906_0.IsValidFormat && !class6906_0.IsValidEndChar)
					{
						int_5 = 59;
						stringBuilder_0.Insert(int_1, (char)int_5);
						class6906_0 = null;
					}
				}
				else
				{
					class6906_0 = null;
				}
			}
			else if (int_5 == 38)
			{
				class6906_0 = new Class6906();
				class6906_0.method_0(int_5);
			}
			method_9();
			switch (enum942_0)
			{
			case Enum942.const_0:
				if (!method_12())
				{
				}
				break;
			case Enum942.const_1:
				if (!method_12())
				{
					if (int_5 == 47)
					{
						method_20(starttag: false, int_1);
					}
					else
					{
						method_20(starttag: true, int_1 - 1);
						method_10();
					}
					enum942_0 = Enum942.const_2;
				}
				break;
			case Enum942.const_2:
				if (method_12())
				{
					break;
				}
				if (smethod_3(int_5))
				{
					method_25(int_1 - 1);
					if (enum942_0 == Enum942.const_2)
					{
						enum942_0 = Enum942.const_3;
					}
				}
				else if (int_5 == 47)
				{
					method_25(int_1 - 1);
					if (enum942_0 == Enum942.const_2)
					{
						enum942_0 = Enum942.const_4;
					}
				}
				else
				{
					if (int_5 != 62)
					{
						break;
					}
					method_25(int_1 - 1);
					if (enum942_0 == Enum942.const_2)
					{
						if (!method_19(int_1, close: false, enum942_0))
						{
							int_1 = stringBuilder_0.Length;
						}
						else if (enum942_0 == Enum942.const_2)
						{
							enum942_0 = Enum942.const_0;
							method_18(Enum944.const_3, int_1);
						}
					}
				}
				break;
			case Enum942.const_3:
				if ((int_5 != 60 && method_12()) || smethod_3(int_5))
				{
					break;
				}
				if (int_5 != 47 && int_5 != 63)
				{
					if (int_5 == 62)
					{
						if (!method_19(int_1, close: false, enum942_0))
						{
							int_1 = stringBuilder_0.Length;
						}
						else if (enum942_0 == Enum942.const_3)
						{
							enum942_0 = Enum942.const_0;
							method_18(Enum944.const_3, int_1);
						}
					}
					else
					{
						method_14(int_1 - 1);
						enum942_0 = Enum942.const_5;
					}
				}
				else
				{
					enum942_0 = Enum942.const_4;
				}
				break;
			case Enum942.const_4:
				if (method_12())
				{
					break;
				}
				if (int_5 == 62)
				{
					if (!method_19(int_1, close: true, enum942_0))
					{
						int_1 = stringBuilder_0.Length;
					}
					else if (enum942_0 == Enum942.const_4)
					{
						enum942_0 = Enum942.const_0;
						method_18(Enum944.const_3, int_1);
					}
				}
				else
				{
					enum942_0 = Enum942.const_3;
				}
				break;
			case Enum942.const_5:
				if (method_12())
				{
					break;
				}
				if (smethod_3(int_5))
				{
					method_15(int_1 - 1);
					enum942_0 = Enum942.const_6;
				}
				else if (int_5 == 61)
				{
					method_15(int_1 - 1);
					enum942_0 = Enum942.const_7;
				}
				else if (int_5 == 62)
				{
					method_15(int_1 - 1);
					if (!method_19(int_1, close: false, enum942_0))
					{
						int_1 = stringBuilder_0.Length;
					}
					else if (enum942_0 == Enum942.const_5)
					{
						enum942_0 = Enum942.const_0;
						method_18(Enum944.const_3, int_1);
					}
				}
				break;
			case Enum942.const_6:
				if (method_12() || smethod_3(int_5))
				{
					break;
				}
				if (int_5 == 62)
				{
					if (!method_19(int_1, close: false, enum942_0))
					{
						int_1 = stringBuilder_0.Length;
					}
					else if (enum942_0 == Enum942.const_6)
					{
						enum942_0 = Enum942.const_0;
						method_18(Enum944.const_3, int_1);
					}
				}
				else if (int_5 == 61)
				{
					enum942_0 = Enum942.const_7;
				}
				else
				{
					enum942_0 = Enum942.const_3;
					method_10();
				}
				break;
			case Enum942.const_7:
				if (method_12() || smethod_3(int_5))
				{
					break;
				}
				if (int_5 != 39 && int_5 != 34)
				{
					if (int_5 == 62)
					{
						if (!method_19(int_1, close: false, enum942_0))
						{
							int_1 = stringBuilder_0.Length;
						}
						else if (enum942_0 == Enum942.const_7)
						{
							enum942_0 = Enum942.const_0;
							method_18(Enum944.const_3, int_1);
						}
					}
					else
					{
						method_16(int_1 - 1);
						enum942_0 = Enum942.const_8;
					}
				}
				else
				{
					enum942_0 = Enum942.const_10;
					method_16(int_1);
					num = int_5;
				}
				break;
			case Enum942.const_8:
				if (method_12())
				{
					break;
				}
				if (smethod_3(int_5))
				{
					method_17(int_1 - 1);
					enum942_0 = Enum942.const_3;
				}
				else if (int_5 == 62)
				{
					method_17(int_1 - 1);
					if (!method_19(int_1, close: false, enum942_0))
					{
						int_1 = stringBuilder_0.Length;
					}
					else if (enum942_0 == Enum942.const_8)
					{
						enum942_0 = Enum942.const_0;
						method_18(Enum944.const_3, int_1);
					}
				}
				break;
			case Enum942.const_9:
				if (int_5 == 62 && (!bool_0 || (stringBuilder_0[int_1 - 2] == '-' && stringBuilder_0[int_1 - 3] == '-')))
				{
					if (!method_19(int_1, close: false, enum942_0))
					{
						int_1 = stringBuilder_0.Length;
						break;
					}
					enum942_0 = Enum942.const_0;
					method_18(Enum944.const_3, int_1);
				}
				break;
			case Enum942.const_10:
				if (int_5 == num)
				{
					method_17(int_1 - 1);
					enum942_0 = Enum942.const_3;
				}
				else if (int_5 == 60 && int_1 < stringBuilder_0.Length && stringBuilder_0[int_1] == '%')
				{
					enum942_1 = enum942_0;
					enum942_0 = Enum942.const_11;
				}
				break;
			case Enum942.const_11:
				if (int_5 == 37 && int_1 < stringBuilder_0.Length && stringBuilder_0[int_1] == '>')
				{
					switch (enum942_1)
					{
					case Enum942.const_7:
						enum942_0 = Enum942.const_8;
						break;
					default:
						enum942_0 = enum942_1;
						break;
					case Enum942.const_3:
						method_15(int_1 + 1);
						enum942_0 = Enum942.const_3;
						break;
					}
					method_9();
				}
				break;
			case Enum942.const_12:
				if (class6908_1.int_8 + 3 <= stringBuilder_0.Length - (int_1 - 1) && string.Compare(stringBuilder_0.ToString(int_1 - 1, class6908_1.int_8 + 2), "</" + class6908_1.Name, StringComparison.OrdinalIgnoreCase) == 0)
				{
					int num2 = stringBuilder_0[int_1 - 1 + 2 + class6908_1.Name.Length];
					if (num2 == 62 || smethod_3(num2))
					{
						Class6908 @class = method_6(Enum944.const_3, class6908_1.int_5 + class6908_1.int_6);
						@class.int_6 = int_1 - 1 - @class.int_5;
						class6908_1.method_3(@class);
						method_18(Enum944.const_1, int_1 - 1);
						method_20(starttag: false, int_1 - 1 + 2);
						enum942_0 = Enum942.const_2;
						method_9();
					}
				}
				break;
			}
		}
		if (class6906_0 != null && class6906_0.Length > 3)
		{
			stringBuilder_0.Insert(int_1, ';');
			int_1++;
			class6906_0 = null;
		}
		if (class6908_1.int_7 > 0)
		{
			method_25(int_1);
		}
		method_19(int_1, close: false, enum942_0);
		hashtable_1.Clear();
	}

	private bool method_12()
	{
		if (int_5 != 60)
		{
			return false;
		}
		if (int_1 < stringBuilder_0.Length && stringBuilder_0[int_1] == '%')
		{
			switch (enum942_0)
			{
			case Enum942.const_7:
				method_16(int_1 - 1);
				break;
			case Enum942.const_1:
				method_20(starttag: true, int_1 - 1);
				enum942_0 = Enum942.const_2;
				break;
			case Enum942.const_3:
				method_14(int_1 - 1);
				break;
			}
			enum942_1 = enum942_0;
			enum942_0 = Enum942.const_11;
			return true;
		}
		char c = stringBuilder_0[int_1];
		if ((c < 'a' || c > 'z') && (c < 'A' || c > 'Z') && c != '!' && c != '/' && c != '?')
		{
			return false;
		}
		if (!method_19(int_1 - 1, close: true, enum942_0))
		{
			int_1 = stringBuilder_0.Length;
			return true;
		}
		enum942_0 = Enum942.const_1;
		if (int_1 - 1 <= stringBuilder_0.Length - 2 && stringBuilder_0[int_1] == '!')
		{
			method_18(Enum944.const_2, int_1 - 1);
			method_20(starttag: true, int_1);
			method_25(int_1 + 1);
			enum942_0 = Enum942.const_9;
			if (int_1 < stringBuilder_0.Length - 2)
			{
				if (stringBuilder_0[int_1 + 1] == '-' && stringBuilder_0[int_1 + 2] == '-')
				{
					bool_0 = true;
				}
				else
				{
					bool_0 = false;
				}
			}
			return true;
		}
		method_18(Enum944.const_1, int_1 - 1);
		return true;
	}

	private void method_13(Class6908 node)
	{
		if (!bool_2 || node.int_8 != 4 || !(node.Name == "meta"))
		{
			return;
		}
		Class6901 @class = node.Attributes["http-equiv"];
		if (@class == null || string.Compare(@class.Value, "content-type", StringComparison.OrdinalIgnoreCase) != 0)
		{
			return;
		}
		Class6901 class2 = node.Attributes["content"];
		if (class2 == null)
		{
			return;
		}
		string text = Class6900.smethod_0(class2.Value, "charset");
		if (!string.IsNullOrEmpty(text))
		{
			try
			{
				encoding_1 = Encoding.GetEncoding(text);
			}
			catch (ArgumentException)
			{
				return;
			}
			if (bool_1)
			{
				throw new Exception68(encoding_1);
			}
			if (encoding_0 != null && encoding_1.WindowsCodePage != encoding_0.WindowsCodePage)
			{
				method_8(Enum941.const_2, int_2, int_3, int_1, node.OuterHtml, string.Format(CultureInfo.InvariantCulture, "Encoding mismatch between StreamEncoding: {0} and DeclaredEncoding: {1}", new object[2] { encoding_0.WebName, encoding_1.WebName }));
				throw new Exception68(encoding_1);
			}
		}
	}

	private void method_14(int index)
	{
		class6901_0 = method_7();
		class6901_0.int_3 = index;
		class6901_0.int_0 = int_2;
		class6901_0.int_1 = int_3;
		class6901_0.int_2 = index;
	}

	private void method_15(int index)
	{
		class6901_0.int_4 = index - class6901_0.int_3;
		class6908_1.Attributes.method_0(class6901_0);
	}

	private void method_16(int index)
	{
		class6901_0.int_5 = index;
	}

	private void method_17(int index)
	{
		class6901_0.int_6 = index - class6901_0.int_5;
	}

	private void method_18(Enum944 type, int index)
	{
		class6908_1 = method_6(type, index);
		class6908_1.int_0 = int_2;
		class6908_1.int_1 = int_3;
		if (type == Enum944.const_1)
		{
			class6908_1.int_1--;
		}
		class6908_1.int_2 = index;
	}

	private bool method_19(int index, bool close, Enum942 state)
	{
		class6908_1.int_6 = index - class6908_1.int_5;
		if (class6908_1.enum944_0 != Enum944.const_3 && class6908_1.enum944_0 != Enum944.const_2)
		{
			if (class6908_1.bool_0 && class6908_2 != class6908_1)
			{
				if (class6908_2 != null)
				{
					class6908_2.method_3(class6908_1);
				}
				method_13(class6908_1);
				Class6908 class6908_ = (Class6908)hashtable_1[class6908_1.Name];
				class6908_1.class6908_3 = class6908_;
				hashtable_1[class6908_1.Name] = class6908_1;
				if (class6908_1.NodeType == Enum944.const_0 || class6908_1.NodeType == Enum944.const_1)
				{
					class6908_2 = class6908_1;
				}
				if (Class6908.smethod_3(method_28()))
				{
					enum942_0 = Enum942.const_12;
					return true;
				}
				if (Class6908.smethod_0(class6908_1.Name) || Class6908.smethod_4(class6908_1.Name))
				{
					close = true;
				}
			}
		}
		else if (class6908_1.int_6 > 0)
		{
			class6908_1.int_4 = class6908_1.int_6;
			class6908_1.int_3 = class6908_1.int_5;
			if (class6908_2 != null)
			{
				class6908_2.method_3(class6908_1);
			}
		}
		if ((Enum942.const_4 != state || !class6908_1.Name.Equals("font", StringComparison.OrdinalIgnoreCase)) && (close || !class6908_1.bool_0))
		{
			if (string_7 != null && string_6 == null && string.Compare(class6908_1.Name, string_7, StringComparison.OrdinalIgnoreCase) == 0)
			{
				int_0 = index;
				string_6 = stringBuilder_0.ToString(int_0, stringBuilder_0.Length - int_0);
				method_26();
				return false;
			}
			method_26();
		}
		return true;
	}

	private void method_20(bool starttag, int index)
	{
		class6908_1.bool_0 = starttag;
		class6908_1.int_7 = index;
	}

	private static string[] smethod_2(string name)
	{
		switch (name)
		{
		case "th":
		case "td":
			return new string[2] { "tr", "table" };
		case "tr":
			return new string[1] { "table" };
		case "li":
			return new string[1] { "ul" };
		default:
			return null;
		}
	}

	private void method_21()
	{
		if (class6908_1.bool_0)
		{
			string name = method_28().ToLower(CultureInfo.InvariantCulture);
			method_22(name, smethod_2(name));
		}
	}

	private void method_22(string name, string[] resetters)
	{
		if (resetters != null)
		{
			Class6908 @class = (Class6908)hashtable_1[name];
			if (@class != null && !@class.Closed && !method_23(@class, resetters))
			{
				Class6908 class2 = new Class6908(@class.NodeType, this, -1);
				class2.class6908_4 = class2;
				@class.method_0(class2);
			}
		}
	}

	private bool method_23(Class6908 node, string[] names)
	{
		if (names == null)
		{
			return false;
		}
		int num = 0;
		while (true)
		{
			if (num < names.Length)
			{
				if (method_24(node, names[num]) != null)
				{
					break;
				}
				num++;
				continue;
			}
			return false;
		}
		return true;
	}

	private Class6908 method_24(Class6908 node, string name)
	{
		Class6908 @class = (Class6908)hashtable_1[name];
		if (@class == null)
		{
			return null;
		}
		if (@class.Closed)
		{
			return null;
		}
		if (@class.int_2 < node.int_2)
		{
			return null;
		}
		return @class;
	}

	private void method_25(int index)
	{
		class6908_1.int_8 = index - class6908_1.int_7;
		if (bool_12)
		{
			method_21();
		}
	}

	private void method_26()
	{
		if (class6908_1.Closed)
		{
			return;
		}
		bool flag = false;
		Class6908 @class = (Class6908)hashtable_1[class6908_1.Name];
		if (@class == null)
		{
			if (Class6908.smethod_0(class6908_1.Name))
			{
				class6908_1.method_0(class6908_1);
				if (class6908_2 != null)
				{
					if (!Class6908.smethod_1(class6908_1.Name, Enum943.flag_4))
					{
						Class6908 class2 = null;
						Stack stack = new Stack();
						Class6908 class3 = class6908_2.LastChild;
						while (class3 != null)
						{
							if (!(class3.Name == class6908_1.Name) || class3.HasChildNodes)
							{
								stack.Push(class3);
								class3 = class3.PreviousSibling;
								continue;
							}
							class2 = class3;
							break;
						}
						if (class2 != null)
						{
							Class6908 class4 = null;
							while (stack.Count != 0)
							{
								class4 = (Class6908)stack.Pop();
								class6908_2.method_2(class4);
								class2.method_3(class4);
							}
						}
						else
						{
							class6908_2.method_3(class6908_1);
						}
					}
					else
					{
						class6908_2.method_3(class6908_1);
					}
				}
			}
			else if (Class6908.smethod_2(class6908_1.Name))
			{
				Class6908 class5 = method_6(Enum944.const_3, class6908_1.int_5);
				class5.int_6 = class6908_1.int_6;
				((Class6909)class5).Text = ((Class6909)class5).Text.ToLower(CultureInfo.InvariantCulture);
				if (class6908_2 != null)
				{
					class6908_2.method_3(class5);
				}
			}
			else if (Class6908.smethod_4(class6908_1.Name))
			{
				method_8(Enum941.const_3, class6908_1.int_0, class6908_1.int_1, class6908_1.int_2, class6908_1.OuterHtml, string.Format(CultureInfo.InvariantCulture, "End tag </{0}> is not required", new object[1] { class6908_1.Name }));
			}
			else
			{
				method_8(Enum941.const_1, class6908_1.int_0, class6908_1.int_1, class6908_1.int_2, class6908_1.OuterHtml, string.Format(CultureInfo.InvariantCulture, "Start tag <{0}> was not found", new object[1] { class6908_1.Name }));
				flag = true;
			}
		}
		else
		{
			if (bool_12 && method_23(@class, smethod_2(class6908_1.Name)))
			{
				method_8(Enum941.const_4, class6908_1.int_0, class6908_1.int_1, class6908_1.int_2, class6908_1.OuterHtml, string.Format(CultureInfo.InvariantCulture, "End tag </{0}> invalid here", new object[1] { class6908_1.Name }));
				flag = true;
			}
			if (!flag)
			{
				hashtable_1[class6908_1.Name] = @class.class6908_3;
				@class.method_0(class6908_1);
			}
		}
		if (!flag && class6908_2 != null && (!Class6908.smethod_0(class6908_1.Name) || class6908_1.bool_0))
		{
			method_27();
		}
	}

	internal void method_27()
	{
		do
		{
			if (class6908_2.Closed)
			{
				class6908_2 = class6908_2.ParentNode;
			}
		}
		while (class6908_2 != null && class6908_2.Closed);
		if (class6908_2 == null)
		{
			class6908_2 = class6908_0;
		}
	}

	private string method_28()
	{
		return stringBuilder_0.ToString(class6908_1.int_7, class6908_1.int_8);
	}

	public static bool smethod_3(int c)
	{
		if (c != 10 && c != 13 && c != 32 && c != 9)
		{
			return false;
		}
		return true;
	}
}
