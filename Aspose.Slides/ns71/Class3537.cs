using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;

namespace ns71;

internal class Class3537
{
	[CompilerGenerated]
	private sealed class Class3538
	{
		public string string_0;

		public bool method_0(Class3527 e)
		{
			if (e.Key == "Module")
			{
				return e.Value == string_0;
			}
			return false;
		}
	}

	private List<Class3527> list_0 = new List<Class3527>();

	[CompilerGenerated]
	private static Predicate<Class3527> predicate_0;

	[CompilerGenerated]
	private static Predicate<Class3527> predicate_1;

	internal void method_0(StringReader reader)
	{
		KeyValuePair<string, string> keyValuePair = Class3525.smethod_0(reader);
		if (keyValuePair.Key != "ID")
		{
			throw new Exception10();
		}
		Class3529 item = new Class3529(keyValuePair.Value);
		list_0.Add(item);
		do
		{
			keyValuePair = Class3525.smethod_0(reader);
			switch (keyValuePair.Key)
			{
			default:
			{
				Class3535 item9 = new Class3535(keyValuePair.Value, keyValuePair.Key);
				list_0.Add(item9);
				break;
			}
			case "ID":
			{
				Class3529 item8 = new Class3529(keyValuePair.Value);
				list_0.Add(item8);
				break;
			}
			case "Module":
			{
				Class3533 item7 = new Class3533(keyValuePair.Value);
				list_0.Add(item7);
				break;
			}
			case "Name":
			{
				Class3530 item6 = new Class3530(keyValuePair.Value);
				list_0.Add(item6);
				break;
			}
			case "HelpContextID":
			{
				Class3528 item5 = new Class3528(keyValuePair.Value);
				list_0.Add(item5);
				break;
			}
			case "CMG":
			{
				Class3532 item4 = new Class3532(keyValuePair.Value);
				list_0.Add(item4);
				break;
			}
			case "DPB":
			{
				Class3531 item3 = new Class3531(keyValuePair.Value);
				list_0.Add(item3);
				break;
			}
			case "GC":
			{
				Class3534 item2 = new Class3534(keyValuePair.Value);
				list_0.Add(item2);
				break;
			}
			}
		}
		while (!method_5(keyValuePair.Key));
	}

	internal void method_1(StringWriter writer)
	{
		foreach (Class3527 item in list_0)
		{
			item.method_0(writer);
		}
	}

	internal void method_2(string projectName)
	{
		Guid guid = Guid.NewGuid();
		Class3529 item = new Class3529(guid.ToString("B").ToUpper());
		list_0.Add(item);
		Class3530 item2 = new Class3530(projectName);
		list_0.Add(item2);
		Class3528 item3 = new Class3528("0");
		list_0.Add(item3);
		Guid projectId = guid;
		byte[] data = new byte[4];
		Class3472 @class = new Class3472(projectId, 4u, data);
		Class3532 item4 = new Class3532(@class.ToString());
		list_0.Add(item4);
		Guid projectId2 = guid;
		byte[] data2 = new byte[1];
		Class3472 class2 = new Class3472(projectId2, 1u, data2);
		Class3531 item5 = new Class3531(class2.ToString());
		list_0.Add(item5);
		Class3472 class3 = new Class3472(guid, 1u, new byte[1] { 255 });
		Class3534 item6 = new Class3534(class3.ToString());
		list_0.Add(item6);
	}

	internal void method_3(string name)
	{
		Class3533 item = new Class3533(name);
		list_0.Insert(method_6(), item);
	}

	internal void method_4(string name)
	{
		Class3527 @class = list_0.Find((Class3527 e) => e.Key == "Module" && e.Value == name);
		if (@class == null)
		{
			throw new ArgumentException($"Property for module with name {name} is not exists");
		}
		list_0.Remove(@class);
	}

	private bool method_5(string key)
	{
		return key == "GC";
	}

	private int method_6()
	{
		Class3527 @class = list_0.FindLast((Class3527 e) => e.Key == "Module");
		if (@class != null)
		{
			list_0.IndexOf(@class);
			return list_0.IndexOf(@class) + 1;
		}
		Class3527 class2 = list_0.FindLast((Class3527 e) => e.Key == "ID");
		if (class2 == null)
		{
			throw new InvalidOperationException();
		}
		int num = list_0.IndexOf(class2);
		return num + 1;
	}

	[CompilerGenerated]
	private static bool smethod_0(Class3527 e)
	{
		return e.Key == "Module";
	}

	[CompilerGenerated]
	private static bool smethod_1(Class3527 e)
	{
		return e.Key == "ID";
	}
}
