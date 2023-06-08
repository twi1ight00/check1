namespace ns16;

internal class Class1230
{
	internal Class1234 class1234_0;

	internal string string_0;

	internal string string_1;

	internal string string_2;

	private long long_0;

	internal Class1230()
	{
		if (class1234_0 == null)
		{
			class1234_0 = new Class1234();
		}
	}

	internal bool method_0(Enum169 enum169_0)
	{
		return ((ulong)long_0 & (ulong)enum169_0) != 0;
	}

	internal void method_1(Enum169 enum169_0)
	{
		long_0 |= (long)enum169_0;
	}

	internal void method_2()
	{
		long_0 = 0L;
	}

	internal string method_3(Enum169 enum169_0)
	{
		if (class1234_0 == null)
		{
			return null;
		}
		switch (enum169_0)
		{
		case Enum169.const_3:
			if (!method_0(Enum169.const_3))
			{
				return class1234_0.string_1;
			}
			break;
		case Enum169.const_5:
			if (!method_0(Enum169.const_5))
			{
				return class1234_0.string_3;
			}
			break;
		case Enum169.const_2:
			if (!method_0(Enum169.const_2))
			{
				return class1234_0.string_0;
			}
			break;
		case Enum169.const_4:
			if (!method_0(Enum169.const_4))
			{
				return class1234_0.string_2;
			}
			break;
		case Enum169.const_6:
			if (!method_0(Enum169.const_6))
			{
				return class1234_0.string_4;
			}
			break;
		case Enum169.const_7:
			if (!method_0(Enum169.const_7))
			{
				return class1234_0.string_5;
			}
			break;
		case Enum169.const_8:
			if (class1234_0.class1233_0 != null && !method_0(Enum169.const_8))
			{
				return class1234_0.class1233_0.string_0;
			}
			break;
		case Enum169.const_47:
			if (class1234_0.class1233_0 != null && class1234_0.class1233_0.class1231_0 != null && !method_0(Enum169.const_47))
			{
				return class1234_0.class1233_0.class1231_0.string_3;
			}
			break;
		case Enum169.const_13:
			if (class1234_0.class1233_0 != null && class1234_0.class1233_0.class1231_0 != null && !method_0(Enum169.const_13))
			{
				return class1234_0.class1233_0.class1231_0.string_1;
			}
			break;
		case Enum169.const_14:
			if (class1234_0.class1233_0 != null && class1234_0.class1233_0.class1231_0 != null && !method_0(Enum169.const_14))
			{
				return class1234_0.class1233_0.class1231_0.string_2;
			}
			break;
		case Enum169.const_9:
			if (class1234_0.class1233_0 != null && class1234_0.class1233_0.class1231_0 != null && !method_0(Enum169.const_9))
			{
				return class1234_0.class1233_0.class1231_0.string_0;
			}
			break;
		case Enum169.const_33:
			if (class1234_0.class1235_0 != null && class1234_0.class1235_0.class1232_0 != null && !method_0(Enum169.const_33))
			{
				return class1234_0.class1235_0.class1232_0.string_3;
			}
			break;
		case Enum169.const_42:
			if (class1234_0.class1235_0 != null && class1234_0.class1235_0.class1232_0 != null && !method_0(Enum169.const_42))
			{
				return class1234_0.class1235_0.class1232_0.string_12;
			}
			break;
		case Enum169.const_31:
			if (class1234_0.class1235_0 != null && class1234_0.class1235_0.class1232_0 != null && !method_0(Enum169.const_31))
			{
				return class1234_0.class1235_0.class1232_0.string_1;
			}
			break;
		case Enum169.const_32:
			if (class1234_0.class1235_0 != null && class1234_0.class1235_0.class1232_0 != null && !method_0(Enum169.const_32))
			{
				return class1234_0.class1235_0.class1232_0.string_2;
			}
			break;
		case Enum169.const_38:
			if (class1234_0.class1235_0 != null && class1234_0.class1235_0.class1232_0 != null && !method_0(Enum169.const_38))
			{
				return class1234_0.class1235_0.class1232_0.string_8;
			}
			break;
		case Enum169.const_45:
			if (class1234_0.class1235_0 != null && class1234_0.class1235_0.class1232_0 != null && !method_0(Enum169.const_45))
			{
				return class1234_0.class1235_0.class1232_0.string_15;
			}
			break;
		case Enum169.const_36:
			if (class1234_0.class1235_0 != null && class1234_0.class1235_0.class1232_0 != null && !method_0(Enum169.const_36))
			{
				return class1234_0.class1235_0.class1232_0.string_6;
			}
			break;
		case Enum169.const_43:
			if (class1234_0.class1235_0 != null && class1234_0.class1235_0.class1232_0 != null && !method_0(Enum169.const_43))
			{
				return class1234_0.class1235_0.class1232_0.string_13;
			}
			break;
		case Enum169.const_40:
			if (class1234_0.class1235_0 != null && class1234_0.class1235_0.class1232_0 != null && !method_0(Enum169.const_40))
			{
				return class1234_0.class1235_0.class1232_0.string_10;
			}
			break;
		case Enum169.const_34:
			if (class1234_0.class1235_0 != null && class1234_0.class1235_0.class1232_0 != null && !method_0(Enum169.const_34))
			{
				return class1234_0.class1235_0.class1232_0.string_4;
			}
			break;
		case Enum169.const_37:
			if (class1234_0.class1235_0 != null && class1234_0.class1235_0.class1232_0 != null && !method_0(Enum169.const_37))
			{
				return class1234_0.class1235_0.class1232_0.string_7;
			}
			break;
		case Enum169.const_39:
			if (class1234_0.class1235_0 != null && class1234_0.class1235_0.class1232_0 != null && !method_0(Enum169.const_39))
			{
				return class1234_0.class1235_0.class1232_0.string_9;
			}
			break;
		case Enum169.const_41:
			if (class1234_0.class1235_0 != null && class1234_0.class1235_0.class1232_0 != null && !method_0(Enum169.const_41))
			{
				return class1234_0.class1235_0.class1232_0.string_11;
			}
			break;
		case Enum169.const_35:
			if (class1234_0.class1235_0 != null && class1234_0.class1235_0.class1232_0 != null && !method_0(Enum169.const_35))
			{
				return class1234_0.class1235_0.class1232_0.string_5;
			}
			break;
		case Enum169.const_44:
			if (class1234_0.class1235_0 != null && class1234_0.class1235_0.class1232_0 != null && !method_0(Enum169.const_44))
			{
				return class1234_0.class1235_0.class1232_0.string_14;
			}
			break;
		case Enum169.const_30:
			if (class1234_0.class1235_0 != null && class1234_0.class1235_0.class1232_0 != null && !method_0(Enum169.const_30))
			{
				return class1234_0.class1235_0.class1232_0.string_0;
			}
			break;
		case Enum169.const_23:
			if (class1234_0.class1235_0 != null && !method_0(Enum169.const_23))
			{
				return class1234_0.class1235_0.string_8;
			}
			break;
		case Enum169.const_15:
			if (class1234_0.class1235_0 != null && !method_0(Enum169.const_15))
			{
				return class1234_0.class1235_0.string_0;
			}
			break;
		case Enum169.const_17:
			if (class1234_0.class1235_0 != null && !method_0(Enum169.const_17))
			{
				return class1234_0.class1235_0.string_2;
			}
			break;
		case Enum169.const_26:
			if (class1234_0.class1235_0 != null && !method_0(Enum169.const_26))
			{
				return class1234_0.class1235_0.string_11;
			}
			break;
		case Enum169.const_27:
			if (class1234_0.class1235_0 != null && !method_0(Enum169.const_27))
			{
				return class1234_0.class1235_0.string_12;
			}
			break;
		case Enum169.const_29:
			if (class1234_0.class1235_0 != null && !method_0(Enum169.const_29))
			{
				return class1234_0.class1235_0.string_14;
			}
			break;
		case Enum169.const_21:
			if (class1234_0.class1235_0 != null && !method_0(Enum169.const_21))
			{
				return class1234_0.class1235_0.string_6;
			}
			break;
		case Enum169.const_24:
			if (class1234_0.class1235_0 != null && !method_0(Enum169.const_24))
			{
				return class1234_0.class1235_0.string_9;
			}
			break;
		case Enum169.const_19:
			if (class1234_0.class1235_0 != null && !method_0(Enum169.const_19))
			{
				return class1234_0.class1235_0.string_4;
			}
			break;
		case Enum169.const_22:
			if (class1234_0.class1235_0 != null && !method_0(Enum169.const_22))
			{
				return class1234_0.class1235_0.string_7;
			}
			break;
		case Enum169.const_18:
			if (class1234_0.class1235_0 != null && !method_0(Enum169.const_18))
			{
				return class1234_0.class1235_0.string_3;
			}
			break;
		case Enum169.const_25:
			if (class1234_0.class1235_0 != null && !method_0(Enum169.const_25))
			{
				return class1234_0.class1235_0.string_10;
			}
			break;
		case Enum169.const_20:
			if (class1234_0.class1235_0 != null && !method_0(Enum169.const_20))
			{
				return class1234_0.class1235_0.string_5;
			}
			break;
		case Enum169.const_28:
			if (class1234_0.class1235_0 != null && !method_0(Enum169.const_28))
			{
				return class1234_0.class1235_0.string_13;
			}
			break;
		case Enum169.const_16:
			if (class1234_0.class1235_0 != null && !method_0(Enum169.const_16))
			{
				return class1234_0.class1235_0.string_1;
			}
			break;
		}
		return null;
	}
}
