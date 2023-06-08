using System;
using Aspose.Slides;

namespace ns24;

internal class Class341 : Class278
{
	private string string_0;

	private long long_0;

	private bool bool_0;

	public long RawValue
	{
		get
		{
			return long_0;
		}
		set
		{
			long_0 = value;
			bool_0 = false;
		}
	}

	public float AngleValue
	{
		get
		{
			return (float)((double)long_0 / 60000.0);
		}
		set
		{
			RawValue = (long)Math.Round((double)value * 60000.0);
		}
	}

	public string Name
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	public bool Copy
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	public void method_0(string formula)
	{
		if (formula[0] != 'v' && formula[1] != 'a' && formula[2] != 'l' && formula[3] != ' ')
		{
			throw new PptxReadException($"Error reading adjustment value: {string_0} = \"{formula}\"");
		}
		int i;
		for (i = 4; i < formula.Length && formula[i] == ' '; i++)
		{
		}
		long_0 = long.Parse(formula.Substring(i));
	}

	public Class341(string name, long value)
	{
		string_0 = name;
		long_0 = value;
	}

	public Class341(Class341 value)
	{
		string_0 = value.Name;
		long_0 = value.RawValue;
		bool_0 = true;
	}

	public Class341(string name, string formula)
	{
		string_0 = name;
		method_0(formula);
	}
}
