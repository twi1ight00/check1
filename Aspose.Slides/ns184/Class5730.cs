using System;
using System.Collections;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using ns183;
using ns218;
using ns224;
using ns234;
using ns271;

namespace ns184;

internal class Class5730
{
	private sealed class Class5731
	{
		private readonly int int_0;

		private readonly int int_1;

		public Class5731(int fontSize, int fontVariant)
		{
			int_0 = fontSize;
			int_1 = fontVariant;
		}

		public override bool Equals(object obj)
		{
			Class5731 @class = obj as Class5731;
			if (object.ReferenceEquals(null, @class))
			{
				return false;
			}
			if (object.ReferenceEquals(this, @class))
			{
				return true;
			}
			return @class.GetHashCode().Equals(GetHashCode());
		}

		public override int GetHashCode()
		{
			int num = 17;
			num = 629 + int_0.GetHashCode();
			return 37 * num + int_1.GetHashCode();
		}
	}

	private Hashtable hashtable_0;

	private Hashtable hashtable_1;

	private Hashtable hashtable_2;

	private Hashtable hashtable_3;

	private Hashtable hashtable_4;

	private Interface218 interface218_0;

	private Hashtable hashtable_5;

	public Class5730()
	{
		hashtable_1 = new Hashtable();
		hashtable_2 = new Hashtable();
		hashtable_3 = new Hashtable();
		hashtable_0 = new Hashtable();
		hashtable_5 = new Hashtable();
	}

	public void method_0(Interface218 listener)
	{
		interface218_0 = listener;
	}

	public bool method_1()
	{
		hashtable_2 = null;
		return hashtable_1.ContainsKey(Class5729.class5732_0);
	}

	public void method_2(string name, string family, string style, int weight)
	{
		method_4(name, smethod_0(family, style, weight, Class5729.int_6));
		method_4(name, smethod_0(family, style, weight, Class5729.int_5));
	}

	public void method_3(string name, string[] families, string style, int weight)
	{
		for (int i = 0; i < families.Length; i++)
		{
			method_2(name, families[i], style, weight);
		}
	}

	public void method_4(string internalFontKey, Class5732 triplet)
	{
		hashtable_1.Add(triplet, internalFontKey);
		if (hashtable_2 != null)
		{
			int num = triplet.method_3();
			hashtable_2.Add(triplet, num);
		}
	}

	public void method_5(string internalFontKey, Interface161 metrics)
	{
		if (metrics is Class4986)
		{
			((Class4986)metrics).method_3(interface218_0);
		}
		hashtable_3.Add(internalFontKey, (Class4986)metrics);
	}

	private Class5732 method_6(string family, string style, int weight, int variant, bool substitutable)
	{
		Class5732 @class = smethod_0(family, style, weight, variant);
		Class5732 class2 = @class;
		string text = method_21(class2);
		if (text == null)
		{
			if (hashtable_5.ContainsKey(class2))
			{
				return (Class5732)hashtable_5[class2];
			}
			text = method_8(class2);
		}
		if (text == null)
		{
			class2 = method_9(family, style, weight, variant, @class, substitutable);
		}
		if (class2 != null)
		{
			if (class2 != @class)
			{
				if (!hashtable_5.ContainsKey(@class))
				{
					hashtable_5.Add(@class, class2);
				}
				method_17(@class, class2);
			}
			return class2;
		}
		return null;
	}

	private string method_7(string fontName)
	{
		string result = null;
		fontName = fontName.ToLower(CultureInfo.InvariantCulture);
		if (fontName.StartsWith("arial"))
		{
			return null;
		}
		switch (fontName)
		{
		case "helvetica":
			result = "Arial";
			break;
		case "khmer":
			result = "Khmer UI";
			break;
		case "lao":
			result = "Lao UI";
			break;
		case "meiryo":
			result = "Meiryo UI";
			break;
		case "courier":
			result = "Courier New";
			break;
		case "segoe":
			result = "Segoe UI";
			break;
		default:
		{
			int num = fontName.LastIndexOf(' ');
			if (num >= 0)
			{
				result = fontName.Substring(0, num);
			}
			break;
		}
		}
		return result;
	}

	private string method_8(Class5732 triplet)
	{
		string text = triplet.method_0();
		FontStyle fontStyle = FontStyle.Regular;
		int num = triplet.method_2();
		string text2 = triplet.method_1();
		if (num >= 700)
		{
			fontStyle |= FontStyle.Bold;
		}
		if (text2 == "italic")
		{
			fontStyle |= FontStyle.Italic;
		}
		Class6730 @class = Class5939.Instance.method_3(text, text2, num);
		Class5999 class2;
		if (@class != null)
		{
			class2 = new Class5999(1f, fontStyle, @class);
		}
		else
		{
			string text3 = method_7(text);
			class2 = Class6652.Instance.method_3(text, 1f, fontStyle, text3);
			if (!Class6165.smethod_0(class2.FamilyName, text) && (text3 == null || !Class6165.smethod_0(class2.FamilyName, text3)))
			{
				return null;
			}
			Stream stream = class2.TrueTypeFont.Data.vmethod_0();
			byte[] ttfFontData;
			if (stream is FileStream fileStream)
			{
				fileStream.Seek(0L, SeekOrigin.Begin);
				ttfFontData = Class5964.smethod_11(fileStream);
			}
			else
			{
				ttfFontData = ((MemoryStream)stream).ToArray();
			}
			try
			{
				Class5939.Instance.method_2(text, text2, num, ttfFontData);
			}
			catch
			{
			}
		}
		string text4 = "F" + (hashtable_3.Count + 1);
		method_5(text4, new Class4987(class2, text));
		method_4(text4, triplet);
		return text4;
	}

	private Class5732 method_9(string family, string style, int weight, int variant, Class5732 startKey, bool substitutable)
	{
		string text = null;
		Class5732 @class;
		if (!family.Equals(startKey.method_0()))
		{
			@class = smethod_0(family, style, weight, variant);
			text = method_21(@class);
			if (text != null)
			{
				return @class;
			}
		}
		@class = method_19(family, style, weight, variant);
		if (@class != null)
		{
			text = method_21(@class);
		}
		if (!substitutable && text == null)
		{
			return null;
		}
		if (text == null && style != Class5729.string_0)
		{
			@class = smethod_0(family, Class5729.string_0, weight, variant);
			text = method_21(@class);
		}
		if (text == null && style != Class5729.string_0)
		{
			@class = method_19(family, Class5729.string_0, weight, variant);
			if (@class != null)
			{
				text = method_21(@class);
			}
		}
		if (text == null)
		{
			return method_9("any", style, weight, variant, startKey, substitutable: false);
		}
		if (@class == null && text == null)
		{
			@class = Class5729.class5732_0;
			text = method_21(@class);
		}
		if (text != null)
		{
			return @class;
		}
		return null;
	}

	public void method_10(string internalName)
	{
		hashtable_0[internalName] = hashtable_3[internalName];
	}

	private Hashtable method_11()
	{
		if (hashtable_4 == null)
		{
			hashtable_4 = new Hashtable();
		}
		return hashtable_4;
	}

	public Class5729 method_12(Class5732 triplet, int fontSize, int fontVariant)
	{
		Hashtable hashtable = (Hashtable)method_11()[triplet];
		if (hashtable == null)
		{
			hashtable = new Hashtable();
			method_11().Add(triplet, hashtable);
		}
		Class5731 key = new Class5731(fontSize, fontVariant);
		Class5729 @class = (Class5729)hashtable[key];
		if (@class == null)
		{
			string text = method_21(triplet);
			method_10(text);
			Interface161 met = method_25(text);
			@class = new Class5729(text, triplet, met, fontSize, fontVariant);
			hashtable.Add(key, @class);
		}
		return @class;
	}

	private ArrayList method_13(string fontName)
	{
		ArrayList arrayList = new ArrayList();
		foreach (Class5732 key in hashtable_1.Keys)
		{
			string text = key.method_0();
			if (text.ToLower().Equals(fontName.ToLower()))
			{
				arrayList.Add(key);
			}
		}
		return arrayList;
	}

	public Class5732 method_14(string family, string style, int weight, int variant, int fontVariant)
	{
		return method_6(family, style, weight, variant, substitutable: true);
	}

	private ArrayList method_15(string[] families, string style, int weight, int variant, bool substitutable)
	{
		ArrayList arrayList = new ArrayList();
		Class5732 @class = null;
		for (int i = 0; i < families.Length; i++)
		{
			@class = method_6(families[i], style, weight, variant, substitutable);
			if (@class != null)
			{
				arrayList.Add(@class);
			}
		}
		return arrayList;
	}

	public Class5732[] method_16(string[] families, string style, int weight, int fontVariant)
	{
		if (families.Length == 0)
		{
			families = new string[1] { "Helvetica" };
		}
		ArrayList arrayList = method_15(families, style, weight, fontVariant, substitutable: false);
		if (arrayList.Count == 0)
		{
			arrayList = method_15(families, style, weight, fontVariant, substitutable: true);
		}
		if (arrayList.Count == 0)
		{
			StringBuilder stringBuilder = new StringBuilder();
			int i = 0;
			for (int num = families.Length; i < num; i++)
			{
				if (i > 0)
				{
					stringBuilder.Append(", ");
				}
				stringBuilder.Append(families[i]);
			}
			throw new InvalidOperationException("fontLookup must return an array with at least one FontTriplet on the last call. Lookup: " + stringBuilder.ToString());
		}
		return (Class5732[])arrayList.ToArray(typeof(Class5732));
	}

	private void method_17(Class5732 replacedKey, Class5732 newKey)
	{
		if (interface218_0 != null)
		{
			interface218_0.imethod_0(this, replacedKey, newKey);
		}
	}

	public void method_18(string fontFamily)
	{
		if (interface218_0 != null)
		{
			interface218_0.imethod_4(this, fontFamily);
		}
	}

	public Class5732 method_19(string family, string style, int weight, int variant)
	{
		Class5732 @class = null;
		string text = null;
		int num = weight;
		if (num < 400)
		{
			while (text == null && num > 100)
			{
				num -= 100;
				@class = smethod_0(family, style, num, variant);
				text = method_21(@class);
			}
			num = weight;
			while (text == null && num < 400)
			{
				num += 100;
				@class = smethod_0(family, style, num, variant);
				text = method_21(@class);
			}
		}
		else if (num != 400 && num != 500)
		{
			if (num > 500)
			{
				while (text == null && num < 1000)
				{
					num += 100;
					@class = smethod_0(family, style, num, variant);
					text = method_21(@class);
				}
				num = weight;
				while (text == null && num > 400)
				{
					num -= 100;
					@class = smethod_0(family, style, num, variant);
					text = method_21(@class);
				}
			}
		}
		else
		{
			@class = smethod_0(family, style, 400, variant);
			text = method_21(@class);
		}
		if (text == null && weight != 400)
		{
			@class = smethod_0(family, style, 400, variant);
			text = method_21(@class);
		}
		if (text != null)
		{
			return @class;
		}
		return null;
	}

	public bool method_20(string family, string style, int weight, int variant)
	{
		Class5732 key = smethod_0(family, style, weight, variant);
		return hashtable_1.ContainsKey(key);
	}

	public string method_21(Class5732 triplet)
	{
		return (string)hashtable_1[triplet];
	}

	public static Class5732 smethod_0(string family, string style, int weight, int variant)
	{
		return new Class5732(family, style, weight, variant);
	}

	public Hashtable method_22()
	{
		return hashtable_3;
	}

	public Hashtable method_23()
	{
		return hashtable_1;
	}

	public Hashtable method_24()
	{
		return hashtable_0;
	}

	public Interface161 method_25(string fontName)
	{
		Class4986 @class = (Class4986)hashtable_3[fontName];
		hashtable_0[fontName] = @class;
		return @class;
	}

	public ArrayList method_26(string fontName)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in hashtable_1)
		{
			if (fontName.Equals(item.Value))
			{
				arrayList.Add(item.Key);
			}
		}
		return arrayList;
	}

	public Class5732 method_27(string fontName)
	{
		ArrayList arrayList = method_26(fontName);
		if (arrayList.Count > 0)
		{
			arrayList.Sort();
			return (Class5732)arrayList[0];
		}
		return null;
	}

	public string method_28(string fontName)
	{
		Class5732 @class = method_27(fontName);
		if (@class != null)
		{
			return @class.method_1();
		}
		return string.Empty;
	}

	public int method_29(string fontName)
	{
		return method_27(fontName)?.method_2() ?? 0;
	}

	public void method_30()
	{
		Console.Out.WriteLine(ToString());
	}

	public override string ToString()
	{
		ArrayList arrayList = new ArrayList();
		foreach (Class5732 key in hashtable_1.Keys)
		{
			string text = method_21(key);
			Interface161 @interface = method_25(text);
			arrayList.Add(key.ToString() + " -> " + text + " -> " + @interface.imethod_0() + "\n");
		}
		arrayList.Sort();
		StringBuilder stringBuilder = new StringBuilder();
		foreach (string item in arrayList)
		{
			stringBuilder.Append(item);
		}
		return stringBuilder.ToString();
	}
}
