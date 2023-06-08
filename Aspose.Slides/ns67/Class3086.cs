using System;
using System.Collections.Generic;
using System.IO;
using ns99;

namespace ns67;

internal sealed class Class3086
{
	private static Class3086 class3086_0;

	private static readonly object object_0 = new object();

	private List<Class3388> list_0;

	private List<Interface113> list_1;

	public static Class3086 Instance
	{
		get
		{
			if (class3086_0 == null)
			{
				lock (object_0)
				{
					if (class3086_0 == null)
					{
						class3086_0 = new Class3086();
					}
				}
			}
			return class3086_0;
		}
	}

	private Class3086()
	{
		list_0 = new List<Class3388>();
		list_1 = new List<Interface113>();
	}

	public void method_0(string directory)
	{
		if (!Directory.Exists(directory))
		{
			throw new ArgumentException("Source directory must exist");
		}
		method_1(new Class4498(directory));
	}

	public void method_1(Interface125 source)
	{
		if (source == null)
		{
			throw new ArgumentNullException("source");
		}
		list_0.Add(new Class3388(source));
	}

	public void method_2(Interface113 font)
	{
		if (font == null)
		{
			throw new ArgumentNullException("font");
		}
		list_1.Add(font);
	}

	public void method_3()
	{
		list_0.Clear();
		list_1.Clear();
	}

	internal Interface113 method_4(string name, bool bold, bool italic)
	{
		if (list_0.Count == 0)
		{
			DirectoryInfo parent = Directory.GetParent(Environment.GetFolderPath(Environment.SpecialFolder.System));
			string directory = Path.Combine(parent.FullName, "Fonts");
			method_0(directory);
		}
		string text = string.Format("{0}{1}{2}", name, bold ? " Bold" : string.Empty, italic ? " Italic" : string.Empty);
		Interface113 @interface = null;
		foreach (Class3388 item in list_0)
		{
			@interface = item.method_0(text);
			if (@interface != null)
			{
				break;
			}
		}
		if (@interface == null)
		{
			foreach (Interface113 item2 in list_1)
			{
				if (item2.FontName.ToLower() == text.ToLower())
				{
					return item2;
				}
			}
		}
		if (@interface == null)
		{
			foreach (Class3388 item3 in list_0)
			{
				@interface = item3.method_0("Arial");
				if (@interface != null)
				{
					break;
				}
			}
		}
		return @interface;
	}
}
