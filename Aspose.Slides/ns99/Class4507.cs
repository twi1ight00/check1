namespace ns99;

internal class Class4507 : Class4506
{
	private string string_0;

	public static Class4507 class4507_0 = new Class4507(".notdef");

	public string Value
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

	public Class4507(string value)
	{
		string_0 = value;
	}

	public override string ToString()
	{
		return string_0;
	}

	public override bool Equals(object obj)
	{
		Class4507 @class = obj as Class4507;
		if (@class != null)
		{
			return string_0 == @class.string_0;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return string_0.GetHashCode();
	}
}
