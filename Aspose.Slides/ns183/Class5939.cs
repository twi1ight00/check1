using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using ns223;
using ns271;

namespace ns183;

internal class Class5939
{
	private class Class5940
	{
		private Class6730 class6730_0;

		private int int_0;

		private string string_0;

		private byte[] byte_0;

		public Class6730 Font => class6730_0;

		public int Weight => int_0;

		public string Style => string_0;

		public Class5940(Class6730 font, int weight, string style, byte[] sha)
		{
			class6730_0 = font;
			int_0 = weight;
			string_0 = style;
			byte_0 = sha;
		}

		internal bool method_0(byte[] sha)
		{
			if (sha.Length != byte_0.Length)
			{
				return false;
			}
			int num = 0;
			while (true)
			{
				if (num < sha.Length)
				{
					if (sha[num] != byte_0[num])
					{
						break;
					}
					num++;
					continue;
				}
				return true;
			}
			return false;
		}
	}

	[ThreadStatic]
	private static Class5939 class5939_0;

	private Dictionary<string, List<Class5940>> dictionary_0 = new Dictionary<string, List<Class5940>>();

	public static Class5939 Instance
	{
		get
		{
			if (class5939_0 == null)
			{
				class5939_0 = new Class5939();
			}
			return class5939_0;
		}
	}

	internal static Class5939 smethod_0(out bool exist)
	{
		exist = true;
		if (class5939_0 == null)
		{
			class5939_0 = new Class5939();
			exist = false;
		}
		return class5939_0;
	}

	private Class5939()
	{
	}

	private static byte[] smethod_1(byte[] data)
	{
		Class5988 @class = new Class5988();
		return @class.ComputeHash(data);
	}

	private static byte[] smethod_2(Class6730 font)
	{
		using Stream inputStream = font.Data.vmethod_0();
		Class5988 @class = new Class5988();
		return @class.ComputeHash(inputStream);
	}

	public void method_0(string name, string style, int weight, byte[] ttfFontData)
	{
		method_1(name, style, weight, smethod_3(name, ttfFontData));
	}

	internal void method_1(string name, string style, int weight, Class6730 font)
	{
		name = name.ToLower(CultureInfo.InvariantCulture);
		List<Class5940> list = (dictionary_0.ContainsKey(name) ? dictionary_0[name] : null);
		if (list == null)
		{
			List<Class5940> list2 = new List<Class5940>();
			list2.Add(new Class5940(font, weight, style, smethod_2(font)));
			dictionary_0[name] = list2;
			return;
		}
		int num = smethod_4(list, style, weight);
		if (num == -1 || !list[num].method_0(smethod_2(font)))
		{
			list.Add(new Class5940(font, weight, style, smethod_2(font)));
		}
	}

	public void method_2(string name, string style, int weight, byte[] ttfFontData)
	{
		name = name.ToLower(CultureInfo.InvariantCulture);
		Class5940 @class = new Class5940(smethod_3(name, ttfFontData), weight, style, smethod_1(ttfFontData));
		List<Class5940> list = (dictionary_0.ContainsKey(name) ? dictionary_0[name] : null);
		if (list == null)
		{
			List<Class5940> list2 = new List<Class5940>();
			list2.Add(@class);
			dictionary_0[name] = list2;
			return;
		}
		int num = smethod_4(list, style, weight);
		if (num != -1)
		{
			list[num] = @class;
		}
		list.Add(@class);
	}

	private static Class6730 smethod_3(string name, byte[] ttfFontStream)
	{
		Class6654 fontData = new Class6656(ttfFontStream);
		Class6732 @class = new Class6732();
		return @class.Read(fontData, name);
	}

	private static int smethod_4(List<Class5940> fonts, string style, int weight)
	{
		int num = 0;
		while (true)
		{
			if (num < fonts.Count)
			{
				Class5940 @class = fonts[num];
				if (@class.Style == style && @class.Weight == weight)
				{
					break;
				}
				num++;
				continue;
			}
			return -1;
		}
		return num;
	}

	public Class6730 method_3(string name, string style, int weight)
	{
		name = name.ToLower(CultureInfo.InvariantCulture);
		List<Class5940> list = (dictionary_0.ContainsKey(name) ? dictionary_0[name] : null);
		if (list == null)
		{
			return null;
		}
		int num = smethod_4(list, style, weight);
		if (num != -1)
		{
			return list[num].Font;
		}
		return null;
	}

	internal Class6730 method_4(string name, string style, int weight, FontStyle fontStyle)
	{
		name = name.ToLower(CultureInfo.InvariantCulture);
		foreach (KeyValuePair<string, List<Class5940>> item in dictionary_0)
		{
			if (!(item.Key == name))
			{
				continue;
			}
			List<Class5940> value = item.Value;
			foreach (Class5940 item2 in value)
			{
				if ((!item2.Font.FullFontName.EndsWith("regular", StringComparison.CurrentCultureIgnoreCase) || fontStyle == FontStyle.Regular) && (!item2.Font.FullFontName.EndsWith("bold", StringComparison.CurrentCultureIgnoreCase) || fontStyle == FontStyle.Bold) && (!item2.Font.FullFontName.EndsWith("italic", StringComparison.CurrentCultureIgnoreCase) || fontStyle == FontStyle.Italic) && item2.Style == style && item2.Weight == weight)
				{
					return item2.Font;
				}
			}
		}
		return null;
	}

	public void Clear()
	{
		dictionary_0.Clear();
	}

	public void Dispose()
	{
		class5939_0 = null;
	}
}
