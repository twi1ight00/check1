using System;
using System.Collections.Generic;
using System.Text;
using ns73;

namespace ns76;

internal class Class3709 : Class3707, Interface59, Interface68
{
	private string string_2;

	private string string_3;

	private string string_4;

	private string string_5;

	private string string_6;

	private List<string> list_0 = new List<string>();

	public override string CSSText
	{
		get
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendFormat("{0} {1} {{", "@counter-style", string_2);
			if (!string.IsNullOrEmpty(CounterType))
			{
				stringBuilder.AppendFormat(" type: {0};", CounterType);
			}
			if (Glyphs.Count != 0)
			{
				stringBuilder.AppendFormat(" glyphs: {0};", ((Interface68)this).Glyphs);
			}
			if (!string.IsNullOrEmpty(Prefix))
			{
				stringBuilder.AppendFormat(" prefix: {0};", Prefix);
			}
			if (!string.IsNullOrEmpty(Suffix))
			{
				stringBuilder.AppendFormat(" suffix: {0};", Suffix);
			}
			if (!string.IsNullOrEmpty(Fallback))
			{
				stringBuilder.AppendFormat(" fallback: {0};", Fallback);
			}
			stringBuilder.Append("}");
			return stringBuilder.ToString();
		}
		set
		{
			throw new NotImplementedException();
		}
	}

	public string Name
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

	public string CounterType
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

	string Interface68.Glyphs
	{
		get
		{
			if (list_0.Count == 0)
			{
				return string.Empty;
			}
			StringBuilder stringBuilder = new StringBuilder();
			IEnumerator<string> enumerator = list_0.GetEnumerator();
			enumerator.MoveNext();
			stringBuilder.AppendFormat("'{0}'", enumerator.Current);
			while (enumerator.MoveNext())
			{
				stringBuilder.AppendFormat(" '{0}'", enumerator.Current);
			}
			return stringBuilder.ToString();
		}
	}

	public string Prefix
	{
		get
		{
			return string_4;
		}
		set
		{
			string_4 = value;
		}
	}

	public string Suffix
	{
		get
		{
			return string_5;
		}
		set
		{
			string_5 = value;
		}
	}

	public string Fallback
	{
		get
		{
			return string_6;
		}
		set
		{
			string_6 = value;
		}
	}

	public List<string> Glyphs => list_0;

	public Class3709(Class3735 styleSheet, Interface59 parentRule)
		: base(styleSheet, parentRule, 11)
	{
	}
}
