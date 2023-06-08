using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using ns73;
using ns74;
using ns76;

namespace ns87;

internal class Class4223 : Class4154
{
	public enum Enum602
	{
		const_0,
		const_1,
		const_2,
		const_3,
		const_4,
		const_5,
		const_6,
		const_7
	}

	public class Class4353
	{
		private const char char_0 = '\\';

		private const string string_0 = "\\";

		private Enum602 enum602_0;

		private Class3679 class3679_0;

		private string string_1;

		private static readonly Regex regex_0 = new Regex("\\\\([\\n\\r\\f0-9a-fA-F]{1,6})\\s*", RegexOptions.Compiled);

		private static readonly Regex regex_1 = new Regex("[ ]{2,}", RegexOptions.Compiled);

		public Enum602 Type => enum602_0;

		public Class3679 Value => class3679_0;

		internal Class4353(Enum602 type)
		{
			enum602_0 = type;
		}

		internal Class4353(Enum602 type, string stringValue)
		{
			enum602_0 = type;
			string_1 = stringValue;
		}

		internal Class4353(Enum602 type, Class3679 value)
			: this(type)
		{
			class3679_0 = value;
		}

		public string method_0()
		{
			if (Enum602.const_3 != enum602_0 && Enum602.const_2 != enum602_0)
			{
				if (enum602_0 == Enum602.const_0)
				{
					string text = ((Class3680)Value).vmethod_3();
					if (text.IndexOf('\\') != -1)
					{
						text = regex_0.Replace(text, smethod_0).Replace("\\", string.Empty);
					}
					return regex_1.Replace(text, " ");
				}
				if (Enum602.const_4 == enum602_0)
				{
					return string_1;
				}
				if (Enum602.const_5 == enum602_0)
				{
					return string_1;
				}
				return null;
			}
			return ((Class3680)Value).vmethod_3();
		}

		private static string smethod_0(Match match)
		{
			if (int.TryParse(match.Value.Substring(1), NumberStyles.HexNumber, Class3726.cultureInfo_0, out var result))
			{
				return new string((char)result, 1);
			}
			return string.Empty;
		}
	}

	private Enum602 enum602_0;

	private bool bool_0;

	private bool bool_1;

	private List<Class4353> list_0;

	public bool IsNone => bool_0;

	public bool IsNormal => bool_1;

	public IList<Class4353> Segments => list_0;

	internal Class4223(Class3679 value, Class3679 quotes)
		: base(value)
	{
		Class3691 @class = null;
		@class = ((quotes != Class3700.Class3702.class3689_4) ? (quotes as Class3691) : new Class3691(new Class3689(string.Empty), new Class3689(string.Empty)));
		if (Class3700.Class3702.class3689_4 == value)
		{
			bool_0 = true;
			return;
		}
		if (Class3700.Class3702.class3689_5 == value)
		{
			bool_1 = true;
			return;
		}
		int num = 0;
		int num2 = 0;
		list_0 = new List<Class4353>();
		IEnumerator<Class3679> enumerator = ((Class3691)value).GetEnumerator();
		while (enumerator.MoveNext())
		{
			Class3679 current = enumerator.Current;
			if (Class3700.Class3702.class3689_240 == current)
			{
				Segments.Add(new Class4353(Enum602.const_4, method_4(@class, num++)));
				continue;
			}
			if (Class3700.Class3702.class3689_241 == current)
			{
				Segments.Add(new Class4353(Enum602.const_5, method_5(@class, num2++)));
				continue;
			}
			if (Class3700.Class3702.class3689_242 == current)
			{
				Segments.Add(new Class4353(Enum602.const_6));
				continue;
			}
			if (Class3700.Class3702.class3689_243 == current)
			{
				Segments.Add(new Class4353(Enum602.const_7));
				continue;
			}
			Class3680 class2 = (Class3680)current;
			switch (class2.PrimitiveType)
			{
			case 19:
				Segments.Add(new Class4353(Enum602.const_0, current));
				break;
			case 20:
				Segments.Add(new Class4353(Enum602.const_1, current));
				break;
			case 22:
				Segments.Add(new Class4353(Enum602.const_3, current));
				break;
			case 23:
				Segments.Add(new Class4353(Enum602.const_2, current));
				break;
			}
		}
	}

	public string method_3()
	{
		if (!IsNone && !IsNormal)
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < list_0.Count; i++)
			{
				stringBuilder.Append(list_0[i].method_0());
			}
			return stringBuilder.ToString();
		}
		return string.Empty;
	}

	private string method_4(Class3691 quotes, int index)
	{
		if (index > quotes.Length)
		{
			return quotes[0].CSSText;
		}
		return quotes[index * 2].CSSText;
	}

	private string method_5(Class3691 quotes, int index)
	{
		if (index > quotes.Length)
		{
			return quotes[1].CSSText;
		}
		return quotes[quotes.Length - 1 - index * 2].CSSText;
	}
}
