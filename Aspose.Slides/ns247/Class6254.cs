using System;
using System.Collections;
using System.IO;
using System.Text;
using ns218;
using ns221;

namespace ns247;

internal abstract class Class6254
{
	private const string string_0 = "/";

	private const string string_1 = "../";

	private readonly Class6263 class6263_0 = new Class6263("/");

	private readonly Class6261 class6261_0 = new Class6261();

	public Class6261 Parts => class6261_0;

	public Class6263 Rels => class6263_0;

	internal void method_0()
	{
		foreach (Class6260 item in (IEnumerable)class6261_0)
		{
			if (item.Extension == "rels")
			{
				string text = item.Name.Replace("/_rels", string.Empty).Replace(".rels", string.Empty);
				if (text == "/")
				{
					smethod_0(item, class6263_0);
				}
				else
				{
					smethod_0(item, method_2(text).Rels);
				}
			}
		}
	}

	private static void smethod_0(Class6260 part, Class6263 rels)
	{
		Class5944 @class = new Class5944(part.Stream);
		while (@class.method_0("Relationships"))
		{
			string localName;
			if ((localName = @class.LocalName) != null && localName == "Relationship")
			{
				string relId = null;
				string relType = null;
				string absoluteTarget = null;
				bool isExternal = false;
				while (@class.method_10())
				{
					switch (@class.LocalName)
					{
					case "TargetMode":
						isExternal = @class.Value == "External";
						break;
					case "Target":
						absoluteTarget = @class.Value;
						break;
					case "Type":
						relType = @class.Value;
						break;
					case "Id":
						relId = @class.Value;
						break;
					}
				}
				rels.Add(relId, relType, absoluteTarget, isExternal);
			}
			else
			{
				@class.method_2();
			}
		}
	}

	public Class6260 method_1(string name)
	{
		return class6261_0[name];
	}

	public Class6260 method_2(string name)
	{
		Class6260 @class = method_1(name);
		if (@class == null)
		{
			throw new InvalidOperationException($"Cannot find part '{name}'.");
		}
		return @class;
	}

	public Class6260 method_3(Class6260 parentPart, string relType)
	{
		Class6263 rels;
		string parentPartName;
		if (parentPart == null)
		{
			rels = class6263_0;
			parentPartName = "/";
		}
		else
		{
			rels = parentPart.Rels;
			parentPartName = parentPart.Name;
		}
		Class6262 @class = rels.method_1(relType);
		if (@class != null)
		{
			return method_2(smethod_2(parentPartName, @class.Target));
		}
		return null;
	}

	public Class6260 method_4(Class6260 parentPart, string relType)
	{
		Class6260 @class = method_3(parentPart, relType);
		if (@class == null)
		{
			throw new InvalidOperationException($"Cannot find target of relationship '{relType}'");
		}
		return @class;
	}

	public Class6260 method_5(Class6260 parentPart, string childPartName, string contentType, string relType)
	{
		string relId;
		return method_6(parentPart, childPartName, contentType, relType, out relId);
	}

	public Class6260 method_6(Class6260 parentPart, string childPartName, string contentType, string relType, out string relId)
	{
		if (parentPart != null)
		{
			childPartName = smethod_2(parentPart.Name, childPartName);
		}
		Class6260 @class = new Class6260(childPartName, contentType);
		class6261_0.Add(@class);
		Class6263 class2 = ((parentPart != null) ? parentPart.Rels : class6263_0);
		relId = class2.Add(relType, @class.Name, isExternal: false);
		return @class;
	}

	[Attribute7(true)]
	public virtual void Save(Stream stream)
	{
	}

	public static string smethod_1(string parentPartName, string targetName)
	{
		if (!targetName.StartsWith("/"))
		{
			return targetName;
		}
		int num = 0;
		int num2 = Math.Min(parentPartName.Length, targetName.Length);
		for (int i = 0; i < num2; i++)
		{
			if (parentPartName[i] == '/')
			{
				num = i;
			}
			if (parentPartName[i] != targetName[i])
			{
				break;
			}
		}
		int num3 = num + 1;
		StringBuilder stringBuilder = new StringBuilder();
		for (int j = num3; j < parentPartName.Length; j++)
		{
			if (parentPartName[j] == '/')
			{
				stringBuilder.Append("../");
			}
		}
		stringBuilder.Append(targetName, num3, targetName.Length - num3);
		return stringBuilder.ToString();
	}

	public static string smethod_2(string parentPartName, string targetName)
	{
		if (targetName.StartsWith("/"))
		{
			return targetName;
		}
		if (Class5964.smethod_42(targetName, "NULL"))
		{
			return string.Empty;
		}
		string text = smethod_3(parentPartName);
		int num = 0;
		while (true)
		{
			int num2 = targetName.IndexOf("../", num);
			if (num2 < num)
			{
				break;
			}
			if (num2 > num)
			{
				text += targetName.Substring(num, num2 - num);
			}
			text = smethod_3(text);
			num = num2 + "../".Length;
		}
		return text + targetName.Substring(num, targetName.Length - num);
	}

	private static string smethod_3(string s)
	{
		if (!Class5964.smethod_20(s))
		{
			return s;
		}
		if (s == "/")
		{
			return s;
		}
		int num = s.Length - 1;
		int num2 = num;
		while (true)
		{
			if (num2 >= 0)
			{
				if (s[num2] == '/' && num2 < num)
				{
					break;
				}
				num2--;
				continue;
			}
			return string.Empty;
		}
		return s.Substring(0, num2 + 1);
	}
}
