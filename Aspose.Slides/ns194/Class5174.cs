using System;
using System.Collections;
using System.Text;
using System.Text.RegularExpressions;
using ns171;
using ns183;

namespace ns194;

internal class Class5174
{
	internal interface Interface167
	{
		object imethod_0(Hashtable @params);

		object imethod_1();
	}

	internal interface Interface164
	{
		void imethod_0(StringBuilder sb, Hashtable @params);

		bool imethod_1(Hashtable @params);
	}

	internal interface Interface165
	{
		Interface164 imethod_0(string fieldName, string values);

		string imethod_1();
	}

	internal interface Interface166
	{
		void imethod_0(StringBuilder sb, object obj);

		bool imethod_1(object obj);
	}

	private class Class5175 : Interface164
	{
		private string string_0;

		public Class5175(string text)
		{
			string_0 = text;
		}

		public void imethod_0(StringBuilder sb, Hashtable @params)
		{
			sb.Append(string_0);
		}

		public bool imethod_1(Hashtable @params)
		{
			return true;
		}

		public string method_0()
		{
			return string_0;
		}
	}

	private class Class5176 : Interface164
	{
		private string string_0;

		public Class5176(string fieldName)
		{
			string_0 = fieldName;
		}

		public void imethod_0(StringBuilder sb, Hashtable @params)
		{
			if (!@params.ContainsKey(string_0))
			{
				throw new ArgumentException("Message pattern contains unsupported field name: " + string_0);
			}
			object obj = @params[string_0];
			smethod_1(obj, sb);
		}

		public bool imethod_1(Hashtable @params)
		{
			object obj = @params[string_0];
			return obj != null;
		}

		public string method_0()
		{
			return "{" + string_0 + "}";
		}
	}

	private class Class5177 : Interface164
	{
		private Interface167 interface167_0;

		public Class5177(string functionName)
		{
			interface167_0 = smethod_0(functionName);
			if (interface167_0 == null)
			{
				throw new ArgumentException("Unknown function: " + functionName);
			}
		}

		public void imethod_0(StringBuilder sb, Hashtable @params)
		{
			object obj = interface167_0.imethod_0(@params);
			smethod_1(obj, sb);
		}

		public bool imethod_1(Hashtable @params)
		{
			object obj = interface167_0.imethod_0(@params);
			return obj != null;
		}

		public string method_0()
		{
			return string.Concat("{#", interface167_0.imethod_1(), "}");
		}
	}

	private class Class5178 : Interface164
	{
		private ArrayList arrayList_0 = new ArrayList();

		private bool bool_0;

		private bool bool_1;

		public Class5178(bool conditional)
		{
			bool_0 = conditional;
		}

		private Class5178(ArrayList parts)
		{
			arrayList_0.AddRange(parts);
			bool_0 = true;
		}

		public void method_0(Interface164 part)
		{
			if (part == null)
			{
				throw new NullReferenceException("part must not be null");
			}
			if (bool_1)
			{
				Class5178 @class = (Class5178)arrayList_0[arrayList_0.Count - 1];
				@class.method_0(part);
			}
			else
			{
				arrayList_0.Add(part);
			}
		}

		public void method_1()
		{
			if (!bool_1)
			{
				ArrayList parts = arrayList_0;
				arrayList_0 = new ArrayList();
				arrayList_0.Add(new Class5178(parts));
				bool_1 = true;
			}
			arrayList_0.Add(new Class5178(conditional: true));
		}

		public void imethod_0(StringBuilder sb, Hashtable @params)
		{
			if (bool_1)
			{
				Interface208 @interface = new Class5495(arrayList_0);
				Interface164 interface2;
				do
				{
					if (@interface.imethod_0())
					{
						interface2 = (Interface164)@interface.imethod_1();
						continue;
					}
					return;
				}
				while (!interface2.imethod_1(@params));
				interface2.imethod_0(sb, @params);
			}
			else if (imethod_1(@params))
			{
				Interface208 interface3 = new Class5495(arrayList_0);
				while (interface3.imethod_0())
				{
					Interface164 interface4 = (Interface164)interface3.imethod_1();
					interface4.imethod_0(sb, @params);
				}
			}
		}

		public bool imethod_1(Hashtable @params)
		{
			if (bool_1)
			{
				Interface208 @interface = new Class5495(arrayList_0);
				Interface164 interface2;
				do
				{
					if (@interface.imethod_0())
					{
						interface2 = (Interface164)@interface.imethod_1();
						continue;
					}
					return false;
				}
				while (!interface2.imethod_1(@params));
				return true;
			}
			if (bool_0)
			{
				Interface208 interface3 = new Class5495(arrayList_0);
				while (interface3.imethod_0())
				{
					Interface164 interface4 = (Interface164)interface3.imethod_1();
					if (!interface4.imethod_1(@params))
					{
						return false;
					}
				}
			}
			return true;
		}

		public override string ToString()
		{
			return arrayList_0.ToString();
		}
	}

	internal static string string_0;

	private static Hashtable hashtable_0;

	private static ArrayList arrayList_0;

	private static Hashtable hashtable_1;

	private Class5178 class5178_0;

	static Class5174()
	{
		string_0 = "(?<!\\\\),";
		hashtable_0 = new Hashtable();
		arrayList_0 = new ArrayList();
		hashtable_1 = new Hashtable();
		Interface165 @interface = new Class5769.Class5771();
		hashtable_0.Add(@interface.imethod_1(), @interface);
		@interface = new Class5772.Class5773();
		hashtable_0.Add(@interface.imethod_1(), @interface);
		@interface = new Class5775.Class5776();
		hashtable_0.Add(@interface.imethod_1(), @interface);
		@interface = new Class5768.Class5770();
		hashtable_0.Add(@interface.imethod_1(), @interface);
		arrayList_0.Add(new Class5777());
		Interface167 interface2 = new Class5088.Class5173();
		hashtable_1.Add(interface2.imethod_1(), interface2);
	}

	public Class5174(Interface238 pattern)
	{
		method_0(pattern);
	}

	private void method_0(Interface238 pattern)
	{
		class5178_0 = new Class5178(conditional: false);
		StringBuilder sb = new StringBuilder();
		method_1(pattern, class5178_0, sb, 0);
	}

	private int method_1(Interface238 pattern, Class5178 parent, StringBuilder sb, int start)
	{
		int i = start;
		int num = pattern.imethod_0();
		bool flag = true;
		while (i < num && flag)
		{
			char c = pattern.imethod_1(i);
			switch (c)
			{
			default:
				sb.Append(c);
				i++;
				break;
			case '{':
			{
				if (sb.Length > 0)
				{
					parent.method_0(new Class5175(sb.ToString()));
					sb.Length = 0;
				}
				i++;
				int num2 = 1;
				for (; i < num; sb.Append(c), i++)
				{
					c = pattern.imethod_1(i);
					switch (c)
					{
					case '{':
						num2++;
						continue;
					case '}':
						num2--;
						if (num2 != 0)
						{
							continue;
						}
						break;
					default:
						continue;
					}
					i++;
					break;
				}
				parent.method_0(method_2(sb.ToString()));
				sb.Length = 0;
				break;
			}
			case '|':
				if (sb.Length > 0)
				{
					parent.method_0(new Class5175(sb.ToString()));
					sb.Length = 0;
				}
				parent.method_1();
				i++;
				break;
			case '[':
			{
				if (sb.Length > 0)
				{
					parent.method_0(new Class5175(sb.ToString()));
					sb.Length = 0;
				}
				i++;
				Class5178 @class = new Class5178(conditional: true);
				parent.method_0(@class);
				i += method_1(pattern, @class, sb, i);
				break;
			}
			case '\\':
				if (i < num - 1)
				{
					i++;
					c = pattern.imethod_1(i);
				}
				sb.Append(c);
				i++;
				break;
			case ']':
				i++;
				flag = false;
				break;
			}
		}
		if (sb.Length > 0)
		{
			parent.method_0(new Class5175(sb.ToString()));
			sb.Length = 0;
		}
		return i - start;
	}

	private Interface164 method_2(string field)
	{
		string[] array = Regex.Split(field, string_0);
		string text = array[0];
		if (array.Length == 1)
		{
			if (text.StartsWith("#"))
			{
				return new Class5177(text.Substring(1));
			}
			return new Class5176(text);
		}
		string text2 = array[1];
		Interface165 @interface = (Interface165)hashtable_0[text2];
		if (@interface == null)
		{
			throw new ArgumentException("No IPartFactory available under the name: " + text2);
		}
		if (array.Length == 2)
		{
			return @interface.imethod_0(text, null);
		}
		return @interface.imethod_0(text, array[2]);
	}

	private static Interface167 smethod_0(string functionName)
	{
		return (Interface167)hashtable_1[functionName];
	}

	public string method_3(Hashtable @params)
	{
		StringBuilder stringBuilder = new StringBuilder();
		method_4(@params, stringBuilder);
		return stringBuilder.ToString();
	}

	public void method_4(Hashtable @params, StringBuilder target)
	{
		class5178_0.imethod_0(target, @params);
	}

	public static void smethod_1(object obj, StringBuilder target)
	{
		if (obj is string)
		{
			target.Append(obj);
			return;
		}
		bool flag = false;
		Interface208 @interface = new Class5495(arrayList_0);
		while (@interface.imethod_0())
		{
			Interface166 interface2 = (Interface166)@interface.imethod_1();
			if (interface2.imethod_1(obj))
			{
				interface2.imethod_0(target, obj);
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			target.Append(obj);
		}
	}

	internal static string smethod_2(string @string)
	{
		return @string.Replace("\\\\,", ",");
	}
}
