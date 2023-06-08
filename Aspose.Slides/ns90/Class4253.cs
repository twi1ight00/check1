using ns88;

namespace ns90;

internal class Class4253 : Class4251
{
	public const int int_6 = -1;

	public const int int_7 = 0;

	public const int int_8 = 1;

	public const int int_9 = 2;

	public const int int_10 = 3;

	public const int int_11 = 4;

	public const int int_12 = 5;

	public const int int_13 = 6;

	public Class4253(string text)
		: base(text, skipWhitespace: true)
	{
	}

	protected override void vmethod_0()
	{
		switch (int_1)
		{
		case 43:
			int_3 = 1;
			method_1();
			return;
		case 45:
			int_3 = 2;
			method_1();
			return;
		case 48:
		case 49:
		case 50:
		case 51:
		case 52:
		case 53:
		case 54:
		case 55:
		case 56:
		case 57:
			method_5();
			return;
		case 32:
			vmethod_0();
			return;
		case -1:
			int_3 = -1;
			return;
		case 78:
		case 110:
			int_3 = 4;
			method_1();
			return;
		case 79:
		case 111:
		{
			int num4 = method_1();
			if (num4 == 68 || num4 == 100)
			{
				int num5 = method_1();
				if (num5 == 68 || num5 == 100)
				{
					method_1();
					if (int_1 == -1)
					{
						int_3 = 5;
					}
					return;
				}
			}
			goto default;
		}
		case 69:
		case 101:
		{
			int num = method_1();
			if (num == 86 || num == 118)
			{
				int num2 = method_1();
				if (num2 == 69 || num2 == 101)
				{
					int num3 = method_1();
					if (num3 == 78 || num3 == 110)
					{
						break;
					}
				}
			}
			goto default;
		}
		default:
			int_3 = 0;
			return;
		}
		method_1();
		if (int_1 == -1)
		{
			int_3 = 6;
		}
	}

	private void method_5()
	{
		bool flag;
		do
		{
			flag = false;
			switch (method_1())
			{
			case 48:
			case 49:
			case 50:
			case 51:
			case 52:
			case 53:
			case 54:
			case 55:
			case 56:
			case 57:
				continue;
			}
			flag = true;
		}
		while (!flag);
		int_3 = 3;
	}

	protected override int vmethod_1()
	{
		if (int_1 == -1)
		{
			return 0;
		}
		switch (int_3)
		{
		default:
			return base.vmethod_1();
		case 1:
		case 2:
		case 3:
		case 4:
			return 1;
		case 5:
			return 3;
		case 6:
			return 4;
		}
	}
}
