using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using ns218;
using ns221;
using ns234;

namespace ns271;

internal class Class6652 : Class6650
{
	private static readonly string[] string_0 = new string[4] { "/usr/share/fonts", "~/.fonts", "/usr/local/share/fonts", "/usr/X11R6/lib/X11/fonts" };

	private readonly object object_0 = new object();

	private string[] string_1;

	private bool bool_0;

	private Class6730 class6730_0;

	private Class6657 class6657_0;

	private static readonly Class6652 class6652_0 = new Class6652();

	private Class6657 FontCache
	{
		get
		{
			if (class6657_0 == null)
			{
				lock (object_0)
				{
					if (class6657_0 == null)
					{
						class6657_0 = method_8();
					}
				}
			}
			return class6657_0;
		}
	}

	private Class6730 EmbeddedResourceFont
	{
		get
		{
			if (class6730_0 == null)
			{
				lock (object_0)
				{
					if (class6730_0 == null)
					{
						class6730_0 = smethod_1();
					}
				}
			}
			return class6730_0;
		}
	}

	public static Class6652 Instance => class6652_0;

	[Attribute7(false)]
	private Class6652()
	{
		try
		{
			Reset();
		}
		catch (Exception)
		{
		}
	}

	[Attribute7(false)]
	public static string[] smethod_0()
	{
		switch (Class6166.smethod_2())
		{
		default:
			throw new InvalidOperationException("Unknown operating system.");
		case Enum742.const_0:
			return new string[1] { Class6166.smethod_4() };
		case Enum742.const_1:
		{
			List<string> list = new List<string>();
			string[] array = string_0;
			foreach (string text in array)
			{
				if (Directory.Exists(text))
				{
					list.Add(text);
				}
			}
			return list.ToArray();
		}
		case Enum742.const_2:
			return new string[1] { "/Library/Fonts" };
		}
	}

	public void method_5(string fontFolder)
	{
		method_6(new string[1] { fontFolder }, recursive: false);
	}

	public void method_6(string[] fontsFolders, bool recursive)
	{
		if (fontsFolders == null)
		{
			throw new ArgumentNullException("fontsFolders");
		}
		lock (object_0)
		{
			string_1 = fontsFolders;
			bool_0 = recursive;
			class6657_0 = null;
		}
	}

	public string[] method_7()
	{
		return (string[])string_1.Clone();
	}

	public void Reset()
	{
		method_6(smethod_0(), recursive: true);
	}

	public override Class6730 vmethod_0(string familyName, FontStyle style)
	{
		return FontCache.method_0(familyName, style);
	}

	internal override Class6730 vmethod_1(FontStyle style)
	{
		return FontCache.method_1(style);
	}

	internal override Class6730 vmethod_2()
	{
		Class6730 @class = FontCache.method_2();
		if (@class == null)
		{
			return EmbeddedResourceFont;
		}
		return @class;
	}

	[Attribute7(false)]
	private Class6657 method_8()
	{
		string[] array;
		bool recursive;
		lock (object_0)
		{
			array = method_7();
			recursive = bool_0;
		}
		IDictionary dictionary = Class6152.smethod_0();
		string[] array2 = array;
		foreach (string text in array2)
		{
			if (!Class5964.smethod_20(text))
			{
				continue;
			}
			smethod_2(text, recursive, dictionary);
			if (Class6166.smethod_2() != 0)
			{
				continue;
			}
			string[] array3 = smethod_0();
			foreach (string text2 in array3)
			{
				if (text2 == text)
				{
					Class6166.smethod_3(dictionary);
					break;
				}
			}
		}
		List<Class6654> list = new List<Class6654>();
		foreach (string key in dictionary.Keys)
		{
			list.Add(new Class6655(key));
		}
		return new Class6657(list.ToArray());
	}

	[Attribute1]
	private static Class6730 smethod_1()
	{
		using Stream srcStream = Class6166.smethod_0("Aspose.Resources.GenBasR.ttf");
		byte[] fontData = Class5964.smethod_11(srcStream);
		Class6732 @class = new Class6732();
		return @class.Read(fontData, null);
	}

	[Attribute7(false)]
	private static void smethod_2(string fontsFolder, bool recursive, IDictionary dstFileNames)
	{
		try
		{
			string[] files = Directory.GetFiles(fontsFolder);
			string[] array = files;
			foreach (string text in array)
			{
				dstFileNames[text] = text;
			}
			if (recursive)
			{
				string[] directories = Directory.GetDirectories(fontsFolder);
				string[] array2 = directories;
				foreach (string fontsFolder2 in array2)
				{
					smethod_2(fontsFolder2, recursive: true, dstFileNames);
				}
			}
		}
		catch (Exception)
		{
		}
	}
}
