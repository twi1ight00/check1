using System;
using System.Text;

namespace ns217;

internal class Class5780 : Class5779
{
	internal interface Interface247
	{
		bool imethod_0(Class5781 node);
	}

	private Class5781 class5781_0;

	private Class5908 class5908_0 = new Class5908();

	private string string_1;

	private string string_2 = string.Empty;

	internal int Index
	{
		get
		{
			if (class5781_0 != null)
			{
				int num = 0;
				foreach (Class5781 item in class5781_0.Nodes.List)
				{
					if ((!string.IsNullOrEmpty(Name) && item.Name == Name) || (string.IsNullOrEmpty(Name) && item.ClassName == base.ClassName))
					{
						if (item.Equals(this))
						{
							break;
						}
						num++;
					}
				}
				return num;
			}
			return 0;
		}
	}

	public string SomExpression
	{
		get
		{
			if (string_2.Length == 0)
			{
				StringBuilder stringBuilder = new StringBuilder();
				smethod_0((Class5781)this, stringBuilder);
				string_2 = stringBuilder.ToString();
			}
			return string_2;
		}
	}

	public string Name
	{
		get
		{
			return string_1;
		}
		set
		{
			string_1 = value;
		}
	}

	public Class5781 Parent
	{
		get
		{
			return class5781_0;
		}
		set
		{
			class5781_0 = value;
		}
	}

	public Class5908 Nodes => class5908_0;

	internal static void smethod_0(Class5781 node, StringBuilder some)
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (!string.IsNullOrEmpty(node.Name))
		{
			stringBuilder.Append(node.Name);
		}
		else
		{
			if (node.ClassName != "xfa" && node.ClassName != "template")
			{
				stringBuilder.Append('#');
			}
			stringBuilder.Append(node.ClassName);
		}
		if (node.Parent != null)
		{
			int num = 0;
			foreach (Class5781 item in node.class5781_0.Nodes.List)
			{
				if ((!string.IsNullOrEmpty(node.Name) && item.Name == node.Name) || (string.IsNullOrEmpty(node.Name) && item.ClassName == node.ClassName))
				{
					if (item.Equals(node))
					{
						break;
					}
					num++;
				}
			}
			stringBuilder.Append('[').Append(num).Append(']');
			if (some.Length != 0)
			{
				stringBuilder.Append(".");
			}
			some.Insert(0, stringBuilder.ToString());
			smethod_0(node.Parent, some);
		}
		else
		{
			some.Insert(0, stringBuilder.Append(".").ToString());
		}
	}

	internal static Class5908 smethod_1(Class5908 list, string name, bool isProperty, bool ignoreIndex, int index, bool isAnyDepth, Interface247 filter)
	{
		Class5908 @class = new Class5908();
		foreach (Class5781 item in list.List)
		{
			int num = index;
			foreach (Class5781 item2 in item.Nodes.List)
			{
				if (filter != null && !filter.imethod_0(item2))
				{
					continue;
				}
				if (name == "*")
				{
					@class.method_0(item2);
				}
				else
				{
					if ((!isProperty || !(item2.ClassName == name)) && (isProperty || !(item2.Name == name)) && !(item2.ClassName == name))
					{
						continue;
					}
					if (ignoreIndex)
					{
						@class.method_0(item2);
						continue;
					}
					if (num == 0)
					{
						@class.method_0(item2);
						break;
					}
					if (num < 0)
					{
						num++;
					}
					if (num > 0)
					{
						num--;
					}
				}
			}
			if (!isAnyDepth || @class.Length != 0)
			{
				continue;
			}
			foreach (Class5781 item3 in item.Nodes.List)
			{
				if (filter == null || filter.imethod_0(item3))
				{
					Class5908 class2 = new Class5908();
					class2.method_0(item3);
					class2 = smethod_1(class2, name, isProperty, ignoreIndex, index, isAnyDepth: true, filter);
					if (class2.Length > 0)
					{
						@class.List.AddRange(class2.List);
					}
				}
			}
		}
		return @class;
	}

	public Class5781 method_0(string somExpression)
	{
		return method_1(somExpression, null);
	}

	public Class5781 method_1(string somExpression, Interface247 filter)
	{
		Class5908 @class = method_4(somExpression, filter);
		if (@class.Length != 0)
		{
			return @class.List[0];
		}
		return null;
	}

	internal Class5781 method_2()
	{
		Class5781 @class = (Class5781)this;
		while (true)
		{
			if (@class != null)
			{
				if (@class.ClassName == "xfa")
				{
					break;
				}
				@class = @class.Parent;
				continue;
			}
			return null;
		}
		return @class;
	}

	public Class5908 method_3(string somExpression)
	{
		return method_4(somExpression, null);
	}

	public Class5908 method_4(string somExpression, Interface247 filter)
	{
		bool isProperty = false;
		bool flag = false;
		bool flag2 = false;
		bool ignoreIndex = false;
		int index = 0;
		StringBuilder stringBuilder = new StringBuilder();
		Class5908 @class = new Class5908();
		somExpression = somExpression.Trim();
		if (somExpression.StartsWith("xfa."))
		{
			Class5781 class2 = method_2();
			if (class2 == null || @class.Length > 0)
			{
				throw new ArgumentException($"Can't parse SOM expression {somExpression}");
			}
			@class.method_0(class2);
			somExpression = somExpression.Substring(3);
		}
		else
		{
			@class.method_0((Class5781)this);
		}
		for (int i = 0; i < somExpression.Length; i++)
		{
			switch (somExpression[i])
			{
			case '#':
				if (stringBuilder.Length == 0)
				{
					isProperty = true;
					break;
				}
				throw new ArgumentException($"Can't parse SOM expression {somExpression}");
			default:
				stringBuilder.Append(somExpression[i]);
				break;
			case '[':
			{
				int num = somExpression.IndexOf(']', i + 1);
				if (num != -1)
				{
					string text = somExpression.Substring(i + 1, num - i - 1).Trim();
					if (text == "*")
					{
						ignoreIndex = true;
					}
					else
					{
						index = int.Parse(text);
					}
					i = num;
					break;
				}
				throw new ArgumentException($"Can't parse SOM expression {somExpression}");
			}
			case '.':
				flag2 = flag;
				if (i + 1 < somExpression.Length && somExpression[i + 1] == '.')
				{
					flag = true;
					i++;
				}
				else
				{
					flag = false;
				}
				if (stringBuilder.Length != 0)
				{
					@class = smethod_1(@class, stringBuilder.ToString().Trim(), isProperty, ignoreIndex, index, flag2, filter);
					isProperty = false;
					ignoreIndex = false;
					index = 0;
					stringBuilder.Length = 0;
					stringBuilder.Capacity = 0;
				}
				break;
			case '*':
				break;
			}
		}
		if (stringBuilder.Length != 0)
		{
			@class = smethod_1(@class, stringBuilder.ToString().Trim(), isProperty, ignoreIndex, index, flag, filter);
		}
		return @class;
	}
}
