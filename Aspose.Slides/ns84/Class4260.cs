using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using ns92;

namespace ns84;

internal class Class4260
{
	public enum Enum500
	{
		const_0,
		const_1,
		const_2,
		const_3,
		const_4,
		const_5,
		const_6
	}

	public class Class4261
	{
		private int int_0;

		private string string_0;

		public int Weight => int_0;

		public string Glyph => string_0;

		public Class4261(int weight, string glyph)
		{
			int_0 = weight;
			string_0 = glyph;
		}
	}

	private string string_0;

	private Enum500 enum500_0;

	private int int_0;

	private List<string> list_0;

	private string string_1;

	private string string_2;

	private float float_0;

	private float float_1;

	private List<Class4261> list_1;

	private string string_3;

	private Interface96 interface96_0;

	private static Regex regex_0 = new Regex("\\\\([\\n\\r\\f0-9a-fA-F]{2,6})", RegexOptions.Compiled);

	public string StyleName => string_0;

	internal Interface96 CounterStyles => interface96_0;

	public Enum500 Type
	{
		get
		{
			return enum500_0;
		}
		set
		{
			enum500_0 = value;
		}
	}

	public int FirstGlyphValue
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
		}
	}

	public List<string> Glyphs => list_0;

	public string Suffix
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

	public string Prefix
	{
		get
		{
			return string_2;
		}
		set
		{
			string_2 = value;
		}
	}

	public float RangeFrom
	{
		get
		{
			return float_0;
		}
		set
		{
			float_0 = value;
		}
	}

	public float RangeTo
	{
		get
		{
			return float_1;
		}
		set
		{
			float_1 = value;
		}
	}

	public List<Class4261> AdditiveGlyphs => list_1;

	public string Fallback
	{
		get
		{
			return string_3;
		}
		set
		{
			string_3 = value;
		}
	}

	public Class4262 Converter => Class4262.smethod_0(this);

	public Class4262 FallbackConverter
	{
		get
		{
			if (string.IsNullOrEmpty(string_3))
			{
				return interface96_0["decimal"].Converter;
			}
			return interface96_0[string_3].Converter;
		}
	}

	public Class4260(string styleName)
	{
		string_0 = styleName;
		int_0 = 1;
		list_0 = new List<string>();
		float_0 = float.NegativeInfinity;
		float_1 = float.PositiveInfinity;
		list_1 = new List<Class4261>();
	}

	internal void method_0(Interface96 counterStyles)
	{
		interface96_0 = counterStyles;
	}

	internal void method_1(params string[] glyphs)
	{
		foreach (string value in glyphs)
		{
			list_0.Add(method_2(value));
		}
	}

	private string method_2(string value)
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (Match item in regex_0.Matches(value))
		{
			stringBuilder.Append((char)int.Parse(item.Value.Substring(1), NumberStyles.HexNumber));
		}
		return stringBuilder.ToString();
	}

	internal void method_3(params object[] glyphs)
	{
		IEnumerator enumerator = glyphs.GetEnumerator();
		while (enumerator.MoveNext())
		{
			int weight = (int)enumerator.Current;
			enumerator.MoveNext();
			string glyph = method_2((string)enumerator.Current);
			list_1.Add(new Class4261(weight, glyph));
		}
	}
}
