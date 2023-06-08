using System.Globalization;

namespace ns213;

internal class Class5613
{
	public const byte byte_0 = 0;

	public const byte byte_1 = 1;

	public const byte byte_2 = 2;

	public const byte byte_3 = 3;

	public const byte byte_4 = 4;

	public const byte byte_5 = 5;

	private byte byte_6;

	private bool bool_0;

	public Class5613()
	{
		method_0();
	}

	public void method_0()
	{
		byte_6 = byte.MaxValue;
		bool_0 = false;
	}

	public byte method_1(char c)
	{
		byte b = Class5618.smethod_4(c);
		switch (b)
		{
		case 31:
			switch (char.GetUnicodeCategory(c))
			{
			default:
				b = 2;
				break;
			case UnicodeCategory.NonSpacingMark:
			case UnicodeCategory.SpacingCombiningMark:
				b = 9;
				break;
			}
			break;
		case 0:
		case 1:
		case 32:
		case 36:
			b = 2;
			break;
		}
		switch (byte_6)
		{
		case 11:
			if (b != 23)
			{
				method_0();
				byte_6 = b;
				return 5;
			}
			goto default;
		case byte.MaxValue:
			byte_6 = b;
			if (byte_6 == 9)
			{
				byte_6 = 2;
			}
			return 4;
		default:
			switch (b)
			{
			default:
			{
				bool flag = bool_0;
				bool_0 = false;
				byte b2 = Class5618.smethod_5(byte_6, b);
				switch (b2)
				{
				default:
					return b2;
				case 1:
					byte_6 = b;
					if (flag)
					{
						return 1;
					}
					return 4;
				case 2:
					if (flag)
					{
						byte_6 = b;
						return 2;
					}
					return 4;
				case 3:
					if (flag)
					{
						byte_6 = b;
					}
					return 3;
				case 0:
				case 4:
					byte_6 = b;
					return b2;
				}
			}
			case 33:
				bool_0 = true;
				return 4;
			case 6:
			case 11:
			case 23:
			case 24:
				byte_6 = b;
				return 4;
			}
		case 6:
		case 23:
		case 24:
			method_0();
			byte_6 = b;
			return 5;
		}
	}
}
