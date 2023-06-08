using Aspose.Cells;

namespace ns8;

internal class Class1474
{
	internal Font font_0;

	internal string string_0;

	internal int int_0;

	internal Class1474(Font font_1, string string_1)
	{
		font_0 = font_1;
		string_0 = string_1;
	}

	internal Class1474(Font font_1, string string_1, int int_1)
	{
		font_0 = font_1;
		string_0 = string_1;
		int_0 = int_1;
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (!(obj is Class1474 class1474_))
		{
			return false;
		}
		return Equals(class1474_);
	}

	public bool Equals(Class1474 class1474_0)
	{
		if (class1474_0 == null)
		{
			return false;
		}
		bool flag = false;
		if (font_0 == null && class1474_0.font_0 == null)
		{
			flag = true;
		}
		else if (font_0 != null && class1474_0.font_0 != null && font_0.Equals(class1474_0.font_0))
		{
			flag = true;
		}
		if (!flag)
		{
			return false;
		}
		if (string_0.Equals(class1474_0.string_0) && int_0 == class1474_0.int_0)
		{
			return true;
		}
		return false;
	}

	public override int GetHashCode()
	{
		int num = ((font_0 != null) ? font_0.GetHashCode() : 0);
		int num2 = ((string_0 != null) ? string_0.GetHashCode() : 0);
		return num + num2 + int_0;
	}
}
