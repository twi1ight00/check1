using System;
using ns83;
using ns88;

namespace ns90;

internal class Class4252 : Class4251
{
	public Class4252(Interface105 node)
		: base(node)
	{
	}

	protected override void vmethod_0()
	{
		try
		{
			switch (int_1)
			{
			case 43:
				int_3 = 1;
				method_1();
				break;
			case 45:
				int_3 = 2;
				method_1();
				break;
			case 46:
				switch (method_1())
				{
				default:
					int_3 = 43;
					method_1();
					break;
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
					int_3 = method_6();
					break;
				}
				break;
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
				int_3 = method_5();
				break;
			case -1:
				int_3 = -1;
				break;
			}
		}
		catch (Exception e)
		{
			throw Class4246.smethod_4(e);
		}
	}

	private int method_5()
	{
		while (true)
		{
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
				break;
			case 46:
				switch (method_1())
				{
				default:
					throw Class4246.smethod_5(base.Content);
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
					return method_6();
				}
			default:
				return method_7(integer: true);
			}
		}
	}

	private int method_6()
	{
		while (true)
		{
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
			return method_7(integer: false);
		}
	}

	private int method_7(bool integer)
	{
		switch (int_1)
		{
		case 67:
		case 99:
		{
			int num9 = method_1();
			if (num9 == 77 || num9 == 109)
			{
				method_1();
				if (int_1 == -1)
				{
					return 19;
				}
			}
			break;
		}
		case 68:
		case 100:
			switch (method_1())
			{
			case 80:
			case 112:
				switch (method_1())
				{
				case 80:
				case 112:
				{
					int num5 = method_1();
					if (num5 == 88 || num5 == 120)
					{
						method_1();
						if (int_1 == -1)
						{
							return 46;
						}
					}
					break;
				}
				case 73:
				case 105:
					method_1();
					if (int_1 == -1)
					{
						return 44;
					}
					break;
				case 67:
				case 99:
				{
					int num4 = method_1();
					if (num4 == 77 || num4 == 109)
					{
						method_1();
						if (int_1 == -1)
						{
							return 45;
						}
					}
					break;
				}
				}
				break;
			case 69:
			case 101:
			{
				int num3 = method_1();
				if (num3 == 71 || num3 == 103)
				{
					method_1();
					if (int_1 == -1)
					{
						return 28;
					}
				}
				break;
			}
			}
			break;
		case 69:
		case 101:
			switch (method_1())
			{
			case 88:
			case 120:
				method_1();
				if (int_1 == -1)
				{
					return 16;
				}
				break;
			case 77:
			case 109:
				method_1();
				if (int_1 == -1)
				{
					return 15;
				}
				break;
			}
			break;
		case 71:
		case 103:
		{
			int num10 = method_1();
			if (num10 != 82 && num10 != 114)
			{
				break;
			}
			int num11 = method_1();
			if (num11 != 65 && num11 != 97)
			{
				break;
			}
			int num12 = method_1();
			if (num12 == 68 || num12 == 100)
			{
				method_1();
				if (int_1 == -1)
				{
					return 29;
				}
			}
			break;
		}
		case 72:
		case 104:
		{
			int num8 = method_1();
			if (num8 == 90 || num8 == 122)
			{
				method_1();
				if (int_1 == -1)
				{
					return 33;
				}
			}
			break;
		}
		case 73:
		case 105:
		{
			int num13 = method_1();
			if (num13 == 78 || num13 == 110)
			{
				method_1();
				if (int_1 == -1)
				{
					return 18;
				}
			}
			break;
		}
		case 75:
		case 107:
		{
			int num = method_1();
			if (num != 72 && num != 104)
			{
				break;
			}
			int num2 = method_1();
			if (num2 == 90 || num2 == 122)
			{
				method_1();
				if (int_1 == -1)
				{
					return 34;
				}
			}
			break;
		}
		case 77:
		case 109:
			switch (method_1())
			{
			case 83:
			case 115:
				method_1();
				if (int_1 == -1)
				{
					return 31;
				}
				break;
			case 77:
			case 109:
				method_1();
				if (int_1 == -1)
				{
					return 20;
				}
				break;
			}
			break;
		case 80:
		case 112:
			switch (method_1())
			{
			case 88:
			case 120:
				method_1();
				if (int_1 == -1)
				{
					return 17;
				}
				break;
			case 84:
			case 116:
				method_1();
				if (int_1 == -1)
				{
					return 21;
				}
				break;
			case 67:
			case 99:
				method_1();
				if (int_1 == -1)
				{
					return 22;
				}
				break;
			}
			break;
		case 82:
		case 114:
		{
			int num6 = method_1();
			if (num6 != 65 && num6 != 97)
			{
				break;
			}
			int num7 = method_1();
			if (num7 == 68 || num7 == 100)
			{
				method_1();
				if (int_1 == -1)
				{
					return 30;
				}
			}
			break;
		}
		case 83:
		case 115:
			method_1();
			if (int_1 == -1)
			{
				return 32;
			}
			break;
		case 37:
			method_1();
			if (int_1 == -1)
			{
				return 23;
			}
			break;
		}
		if (int_1 == -1)
		{
			if (!integer)
			{
				return 14;
			}
			return 13;
		}
		method_4();
		return 42;
	}

	protected override int vmethod_1()
	{
		int num = 0;
		switch (int_3)
		{
		case 29:
		case 45:
		case 46:
			num += 4;
			break;
		case 1:
		case 2:
		case 23:
		case 32:
			num++;
			break;
		case 15:
		case 16:
		case 17:
		case 18:
		case 19:
		case 20:
		case 21:
		case 22:
		case 31:
		case 33:
			num += 2;
			break;
		case 28:
		case 30:
		case 34:
		case 44:
			num += 3;
			break;
		}
		return num;
	}
}
