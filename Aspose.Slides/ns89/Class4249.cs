using System.Diagnostics;
using System.Text;
using ns90;

namespace ns89;

[DebuggerDisplay("{ExpressionText}")]
internal class Class4249
{
	private bool bool_0;

	private bool bool_1;

	private bool bool_2;

	private int int_0;

	private int int_1;

	public string ExpressionText
	{
		get
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (bool_0)
			{
				stringBuilder.Append(int_0);
			}
			if (bool_1)
			{
				stringBuilder.Append('N');
			}
			if (bool_2)
			{
				if (int_1 >= 0)
				{
					stringBuilder.Append("+");
				}
				stringBuilder.Append(int_1);
			}
			return stringBuilder.ToString();
		}
	}

	public static Class4249 smethod_0(string expression)
	{
		Class4249 @class = new Class4249();
		using Class4253 class2 = new Class4253(expression);
		int num = 0;
		bool flag = false;
		int num2 = 1;
		switch (num = class2.method_3())
		{
		case 1:
			flag = true;
			num2 = 1;
			num = class2.method_3();
			goto default;
		case 2:
			flag = true;
			num2 = -1;
			num = class2.method_3();
			goto default;
		default:
			if (num == 3)
			{
				flag = true;
				num2 *= int.Parse(class2.method_2());
				num = class2.method_3();
			}
			switch (num)
			{
			case -1:
				@class.int_1 = num2;
				@class.bool_2 = true;
				return @class;
			case 4:
				if (flag)
				{
					@class.int_0 = num2;
					@class.bool_0 = true;
				}
				@class.bool_1 = true;
				num = class2.method_3();
				break;
			}
			switch (num)
			{
			case -1:
				return @class;
			case 1:
				@class.bool_2 = true;
				class2.method_3();
				@class.int_1 = int.Parse(class2.method_2());
				break;
			case 2:
				@class.bool_2 = true;
				class2.method_3();
				@class.int_1 = -int.Parse(class2.method_2());
				break;
			}
			return @class;
		case 5:
			return smethod_0("2n+1");
		case 6:
			return smethod_0("2n");
		}
	}

	public bool method_0(int index)
	{
		if (!bool_1)
		{
			return index == int_1;
		}
		if (bool_0 && int_0 == 0)
		{
			if (bool_2)
			{
				return index == int_1;
			}
			return false;
		}
		float num = index;
		if (bool_2)
		{
			num -= (float)int_1;
		}
		if (bool_0)
		{
			num /= (float)int_0;
		}
		if (num < 0f)
		{
			return false;
		}
		return num - (float)(int)num == 0f;
	}
}
