using ns99;

namespace ns119;

internal class Class4494 : Interface124
{
	private string string_0;

	private bool bool_0;

	private int int_0;

	private bool bool_1;

	public string FontName
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
			bool_0 = true;
		}
	}

	public int FontIndex
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
			bool_1 = true;
		}
	}

	public Class4494()
	{
	}

	public Class4494(string fontName)
	{
		FontName = fontName;
	}

	public Class4494(int fontIndex)
	{
		FontIndex = fontIndex;
	}

	public Class4490 imethod_0(Interface125 fontSource)
	{
		int num = 0;
		Class4490[] array = fontSource.imethod_0();
		int num2 = 0;
		Class4490 @class;
		while (true)
		{
			if (num2 < array.Length)
			{
				@class = array[num2];
				if (!bool_0 || !(@class.FontName == string_0))
				{
					if (bool_1 && num == int_0)
					{
						break;
					}
					num++;
					num2++;
					continue;
				}
				return @class;
			}
			return null;
		}
		return @class;
	}
}
