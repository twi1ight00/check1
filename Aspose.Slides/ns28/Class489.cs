using System;

namespace ns28;

internal class Class489
{
	protected int int_0;

	protected int int_1;

	protected int int_2;

	protected int int_3;

	protected string string_0 = "viewBox";

	protected string string_1 = "urn:oasis:names:tc:opendocument:xmlns:svg-compatible:1.0";

	public int Left
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

	public int Top
	{
		get
		{
			return int_1;
		}
		set
		{
			int_1 = value;
		}
	}

	public int Right
	{
		get
		{
			return int_2;
		}
		set
		{
			int_2 = value;
		}
	}

	public int Bottom
	{
		get
		{
			return int_3;
		}
		set
		{
			int_3 = value;
		}
	}

	public Class489()
	{
	}

	public Class489(Class369 source)
	{
		if (source != null)
		{
			method_0(source);
		}
	}

	internal void method_0(Class369 source)
	{
		if (source != null)
		{
			string text = source.method_0(string_0, string_1, "");
			if (text != "")
			{
				string[] array = text.Split(' ');
				int_0 = Convert.ToInt32(array[0]);
				int_1 = Convert.ToInt32(array[1]);
				int_2 = Convert.ToInt32(array[2]);
				int_3 = Convert.ToInt32(array[3]);
			}
		}
	}

	internal void Write(Class369 target)
	{
		if (int_0.ToString() != "" && int_1.ToString() != "" && int_2.ToString() != "" && int_3.ToString() != "")
		{
			string value = $"{int_0} {int_1} {int_2} {int_3}";
			target.SetAttribute(string_0, string_1, value);
		}
	}
}
