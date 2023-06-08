namespace ns184;

internal class Class5732
{
	internal interface Interface242
	{
		bool imethod_0(Class5732 triplet);
	}

	private const string string_0 = "{0},{1},{2},{3}";

	private string string_1;

	private string string_2;

	private int int_0;

	private int int_1;

	private int int_2;

	private string string_3;

	private bool bool_0;

	private int int_3;

	public Class5732(string name)
	{
		string_1 = name;
	}

	public Class5732(string name, string style, int weight, int variant)
		: this(name, style, weight, variant, Class5729.int_4)
	{
	}

	public Class5732(string name, string style, int weight, int variant, int priority)
		: this(name)
	{
		string_2 = style;
		int_0 = weight;
		int_1 = variant;
		int_2 = priority;
	}

	public string method_0()
	{
		return string_1;
	}

	public string method_1()
	{
		return string_2;
	}

	public int method_2()
	{
		return int_0;
	}

	public int method_3()
	{
		return int_2;
	}

	public int method_4()
	{
		return int_1;
	}

	private string method_5()
	{
		if (string_3 == null)
		{
			string_3 = $"{method_0()},{method_1()},{method_2()},{method_4()}";
		}
		return string_3;
	}

	public int method_6(Class5732 o)
	{
		return method_5().CompareTo(o.method_5());
	}

	public override int GetHashCode()
	{
		if (!bool_0)
		{
			int_3 = method_5().GetHashCode();
			bool_0 = true;
		}
		return int_3;
	}

	public override bool Equals(object obj)
	{
		Class5732 @class = obj as Class5732;
		if (object.ReferenceEquals(null, @class))
		{
			return false;
		}
		if (object.ReferenceEquals(this, @class))
		{
			return true;
		}
		return GetHashCode().Equals(@class.GetHashCode());
	}

	public override string ToString()
	{
		return method_5();
	}
}
