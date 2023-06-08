using System;
using ns105;
using ns139;
using ns145;
using ns146;
using ns99;

namespace ns144;

internal class Class4641
{
	internal enum Enum651
	{
		const_0,
		const_1,
		const_2,
		const_3,
		const_4,
		const_5,
		const_6,
		const_7
	}

	internal enum Enum652 : byte
	{
		const_0 = 0,
		const_1 = 1,
		const_2 = 6,
		const_3 = 7,
		const_4 = 10,
		const_5 = 12,
		const_6 = 14,
		const_7 = 16,
		const_8 = 17,
		const_9 = 18,
		const_10 = 24,
		const_11 = 27,
		const_12 = 29,
		const_13 = 137,
		const_14 = 32,
		const_15 = 33,
		const_16 = 35,
		const_17 = 37,
		const_18 = 43,
		const_19 = 46,
		const_20 = 47,
		const_21 = 44,
		const_22 = 45,
		const_23 = 48,
		const_24 = 49,
		const_25 = 57,
		const_26 = 58,
		const_27 = 59,
		const_28 = 60,
		const_29 = 62,
		const_30 = 63,
		const_31 = 64,
		const_32 = 65,
		const_33 = 66,
		const_34 = 67,
		const_35 = 68,
		const_36 = 69,
		const_37 = 72,
		const_38 = 73,
		const_39 = 74,
		const_40 = 75,
		const_41 = 80,
		const_42 = 81,
		const_43 = 82,
		const_44 = 83,
		const_45 = 84,
		const_46 = 85,
		const_47 = 86,
		const_48 = 87,
		const_49 = 88,
		const_50 = 89,
		const_51 = 96,
		const_52 = 97,
		const_53 = 98,
		const_54 = 99,
		const_55 = 100,
		const_56 = 101,
		const_57 = 104,
		const_58 = 105,
		const_59 = 106,
		const_60 = 107,
		const_61 = 112,
		const_62 = 133,
		const_63 = 138,
		const_64 = 141,
		const_65 = 176,
		const_66 = 177,
		const_67 = 178,
		const_68 = 179,
		const_69 = 180,
		const_70 = 181,
		const_71 = 182,
		const_72 = 183,
		const_73 = 184,
		const_74 = 185,
		const_75 = 186,
		const_76 = 187,
		const_77 = 188,
		const_78 = 189,
		const_79 = 190,
		const_80 = 191,
		const_81 = 192,
		const_82 = 193,
		const_83 = 194,
		const_84 = 195,
		const_85 = 196,
		const_86 = 197,
		const_87 = 198,
		const_88 = 199,
		const_89 = 200,
		const_90 = 201,
		const_91 = 202,
		const_92 = 203,
		const_93 = 204,
		const_94 = 205,
		const_95 = 206,
		const_96 = 207,
		const_97 = 208,
		const_98 = 209,
		const_99 = 210,
		const_100 = 211,
		const_101 = 212,
		const_102 = 213,
		const_103 = 214,
		const_104 = 215,
		const_105 = 216,
		const_106 = 217,
		const_107 = 218,
		const_108 = 219,
		const_109 = 220,
		const_110 = 221,
		const_111 = 222,
		const_112 = 223,
		const_113 = 224,
		const_114 = 225,
		const_115 = 226,
		const_116 = 227,
		const_117 = 228,
		const_118 = 229,
		const_119 = 230,
		const_120 = 231,
		const_121 = 232,
		const_122 = 233,
		const_123 = 234,
		const_124 = 235,
		const_125 = 236,
		const_126 = 237,
		const_127 = 238,
		const_128 = 239,
		const_129 = 240,
		const_130 = 241,
		const_131 = 242,
		const_132 = 243,
		const_133 = 244,
		const_134 = 245,
		const_135 = 246,
		const_136 = 247,
		const_137 = 248,
		const_138 = 249,
		const_139 = 250,
		const_140 = 251,
		const_141 = 252,
		const_142 = 253,
		const_143 = 254,
		const_144 = byte.MaxValue
	}

	private const int int_0 = 1;

	private const int int_1 = 0;

	internal Class4642 class4642_0;

	private Class4646 class4646_0;

	private int int_2;

	private Class4480 class4480_0;

	private Class4645 class4645_0 = new Class4645();

	private Class4651 class4651_0;

	internal Class4645 Subroutines => class4645_0;

	public Class4641(byte[] program, Class4651 context)
		: this(new Class4646(program), context)
	{
	}

	public Class4641(Class4646 program, Class4651 context)
		: this(program, context, new Class4642())
	{
	}

	public Class4641(Class4646 program, Class4651 context, Class4642 state)
	{
		class4646_0 = program;
		class4651_0 = context;
		class4642_0 = state;
	}

	public Class4641(Class4480 glyph, Class4651 context, Class4642 state)
		: this(new Class4646(((Class4616)glyph.PathDefinition).byte_1), context, state)
	{
		class4480_0 = glyph;
	}

	public void method_0()
	{
		try
		{
			int_2 = class4646_0.StartIndex;
			while (int_2 <= class4646_0.EndIndex)
			{
				Enum652 @enum = (Enum652)class4646_0[int_2++];
				switch (@enum)
				{
				case Enum652.const_0:
					method_37(0);
					break;
				case Enum652.const_1:
					method_37(1);
					break;
				case Enum652.const_2:
					method_38(0);
					break;
				case Enum652.const_3:
					method_38(1);
					break;
				case Enum652.const_4:
					method_60();
					break;
				case Enum652.const_5:
					method_59();
					break;
				case Enum652.const_6:
					method_39();
					break;
				case Enum652.const_7:
					method_42();
					break;
				case Enum652.const_8:
					method_43();
					break;
				case Enum652.const_9:
					method_44();
					break;
				case Enum652.const_10:
					method_54();
					break;
				case Enum652.const_11:
					method_13();
					break;
				case Enum652.const_12:
					method_27();
					break;
				case Enum652.const_14:
					method_29();
					break;
				case Enum652.const_15:
					method_32();
					break;
				case Enum652.const_16:
					method_36();
					break;
				case Enum652.const_17:
					method_53();
					break;
				case Enum652.const_18:
					method_2();
					break;
				case Enum652.const_21:
					method_15();
					break;
				case Enum652.const_19:
					method_48(0);
					break;
				case Enum652.const_20:
					method_48(1);
					break;
				case Enum652.const_23:
					method_47(0);
					break;
				case Enum652.const_24:
					method_47(1);
					break;
				case Enum652.const_25:
					method_46();
					break;
				case Enum652.const_26:
					method_52(0);
					break;
				case Enum652.const_27:
					method_52(1);
					break;
				case Enum652.const_28:
					method_41();
					break;
				case Enum652.const_29:
					method_51(0);
					break;
				case Enum652.const_30:
					method_51(1);
					break;
				case Enum652.const_31:
					method_18();
					break;
				case Enum652.const_32:
					method_19();
					break;
				case Enum652.const_33:
					method_3();
					break;
				case Enum652.const_34:
					method_4();
					break;
				case Enum652.const_35:
					method_35();
					break;
				case Enum652.const_36:
					method_28();
					break;
				case Enum652.const_37:
					method_45();
					break;
				case Enum652.const_38:
					method_58(0);
					break;
				case Enum652.const_39:
					method_58(1);
					break;
				case Enum652.const_40:
					method_5();
					break;
				case Enum652.const_41:
					method_6();
					break;
				case Enum652.const_42:
					method_7();
					break;
				case Enum652.const_43:
					method_8();
					break;
				case Enum652.const_44:
					method_9();
					break;
				case Enum652.const_45:
					method_10();
					break;
				case Enum652.const_46:
					method_11();
					break;
				case Enum652.const_47:
					method_30();
					break;
				case Enum652.const_48:
					method_31();
					break;
				case Enum652.const_49:
					method_12();
					break;
				case Enum652.const_50:
					method_14();
					break;
				case Enum652.const_51:
					method_55();
					break;
				case Enum652.const_52:
					method_56();
					break;
				case Enum652.const_53:
					method_24();
					break;
				case Enum652.const_54:
					method_25();
					break;
				case Enum652.const_55:
					method_57();
					break;
				case Enum652.const_56:
					method_26();
					break;
				case Enum652.const_57:
					method_34(1);
					break;
				case Enum652.const_58:
					method_34(2);
					break;
				case Enum652.const_59:
					method_34(3);
					break;
				case Enum652.const_60:
					method_34(4);
					break;
				case Enum652.const_61:
					method_33();
					break;
				case Enum652.const_62:
					method_23();
					break;
				case Enum652.const_63:
					method_40();
					break;
				case Enum652.const_64:
					method_22();
					break;
				case Enum652.const_65:
					method_20(0);
					break;
				case Enum652.const_66:
					method_20(1);
					break;
				case Enum652.const_67:
					method_20(2);
					break;
				case Enum652.const_68:
					method_20(3);
					break;
				case Enum652.const_69:
					method_20(4);
					break;
				case Enum652.const_70:
					method_20(5);
					break;
				case Enum652.const_71:
					method_20(6);
					break;
				case Enum652.const_72:
					method_20(7);
					break;
				case Enum652.const_73:
					method_21(0);
					break;
				case Enum652.const_74:
					method_21(1);
					break;
				case Enum652.const_75:
					method_21(2);
					break;
				case Enum652.const_76:
					method_21(3);
					break;
				case Enum652.const_77:
					method_21(4);
					break;
				case Enum652.const_78:
					method_21(5);
					break;
				case Enum652.const_79:
					method_21(6);
					break;
				case Enum652.const_80:
					method_21(7);
					break;
				case Enum652.const_81:
					method_50(0);
					break;
				case Enum652.const_82:
					method_50(1);
					break;
				case Enum652.const_83:
					method_50(2);
					break;
				case Enum652.const_84:
					method_50(3);
					break;
				case Enum652.const_85:
					method_50(4);
					break;
				case Enum652.const_86:
					method_50(5);
					break;
				case Enum652.const_87:
					method_50(6);
					break;
				case Enum652.const_88:
					method_50(7);
					break;
				case Enum652.const_89:
					method_50(8);
					break;
				case Enum652.const_90:
					method_50(9);
					break;
				case Enum652.const_91:
					method_50(10);
					break;
				case Enum652.const_92:
					method_50(11);
					break;
				case Enum652.const_93:
					method_50(12);
					break;
				case Enum652.const_94:
					method_50(13);
					break;
				case Enum652.const_95:
					method_50(14);
					break;
				case Enum652.const_96:
					method_50(15);
					break;
				case Enum652.const_97:
					method_50(16);
					break;
				case Enum652.const_98:
					method_50(17);
					break;
				case Enum652.const_99:
					method_50(18);
					break;
				case Enum652.const_100:
					method_50(19);
					break;
				case Enum652.const_101:
					method_50(20);
					break;
				case Enum652.const_102:
					method_50(21);
					break;
				case Enum652.const_103:
					method_50(22);
					break;
				case Enum652.const_104:
					method_50(23);
					break;
				case Enum652.const_105:
					method_50(24);
					break;
				case Enum652.const_106:
					method_50(25);
					break;
				case Enum652.const_107:
					method_50(26);
					break;
				case Enum652.const_108:
					method_50(27);
					break;
				case Enum652.const_109:
					method_50(28);
					break;
				case Enum652.const_110:
					method_50(29);
					break;
				case Enum652.const_111:
					method_50(30);
					break;
				case Enum652.const_112:
					method_50(31);
					break;
				case Enum652.const_113:
					method_49(0);
					break;
				case Enum652.const_114:
					method_49(1);
					break;
				case Enum652.const_115:
					method_49(2);
					break;
				case Enum652.const_116:
					method_49(3);
					break;
				case Enum652.const_117:
					method_49(4);
					break;
				case Enum652.const_118:
					method_49(5);
					break;
				case Enum652.const_119:
					method_49(6);
					break;
				case Enum652.const_120:
					method_49(7);
					break;
				case Enum652.const_121:
					method_49(8);
					break;
				case Enum652.const_122:
					method_49(9);
					break;
				case Enum652.const_123:
					method_49(10);
					break;
				case Enum652.const_124:
					method_49(11);
					break;
				case Enum652.const_125:
					method_49(12);
					break;
				case Enum652.const_126:
					method_49(13);
					break;
				case Enum652.const_127:
					method_49(14);
					break;
				case Enum652.const_128:
					method_49(15);
					break;
				case Enum652.const_129:
					method_49(16);
					break;
				case Enum652.const_130:
					method_49(17);
					break;
				case Enum652.const_131:
					method_49(18);
					break;
				case Enum652.const_132:
					method_49(19);
					break;
				case Enum652.const_133:
					method_49(20);
					break;
				case Enum652.const_134:
					method_49(21);
					break;
				case Enum652.const_135:
					method_49(22);
					break;
				case Enum652.const_136:
					method_49(23);
					break;
				case Enum652.const_137:
					method_49(24);
					break;
				case Enum652.const_138:
					method_49(25);
					break;
				case Enum652.const_139:
					method_49(26);
					break;
				case Enum652.const_140:
					method_49(27);
					break;
				case Enum652.const_141:
					method_49(28);
					break;
				case Enum652.const_142:
					method_49(29);
					break;
				case Enum652.const_143:
					method_49(30);
					break;
				case Enum652.const_144:
					method_49(31);
					break;
				default:
				{
					string message = $"operаtion 0x{@enum:x} is not supported";
					throw new NotSupportedException(message);
				}
				case Enum652.const_22:
					method_17();
					return;
				}
			}
		}
		catch (Exception40)
		{
		}
	}

	public void method_1()
	{
	}

	private void method_2()
	{
		int subroutineIndex = (int)class4642_0.class4707_0.method_3();
		Class4646 @class = class4651_0.TTFTables.FpgmTable.Subroutines[subroutineIndex];
		if (@class != null)
		{
			Class4641 class2 = new Class4641(@class, class4651_0, class4642_0);
			class2.method_0();
		}
	}

	private void method_3()
	{
		int num = (int)class4642_0.class4707_0.method_3();
		int num2 = (int)class4642_0.class4707_0.method_3();
		class4642_0.hashtable_0[num2] = num;
	}

	private void method_4()
	{
		int num = (int)class4642_0.class4707_0.method_3();
		class4642_0.class4707_0.method_0((int)class4642_0.hashtable_0[num]);
	}

	private void method_5()
	{
		class4642_0.class4707_0.method_0((int)(class4651_0.TTFTables.HeadTable.UnitsPerEm * 64));
	}

	private void method_6()
	{
		int num = (int)class4642_0.class4707_0.method_3();
		int num2 = (int)class4642_0.class4707_0.method_3();
		if (num2 < num)
		{
			class4642_0.class4707_0.method_0(1.0);
		}
		else
		{
			class4642_0.class4707_0.method_0(0.0);
		}
	}

	private void method_7()
	{
		int num = (int)class4642_0.class4707_0.method_3();
		int num2 = (int)class4642_0.class4707_0.method_3();
		if (num2 <= num)
		{
			class4642_0.class4707_0.method_0(1.0);
		}
		else
		{
			class4642_0.class4707_0.method_0(0.0);
		}
	}

	private void method_8()
	{
		int num = (int)class4642_0.class4707_0.method_3();
		int num2 = (int)class4642_0.class4707_0.method_3();
		if (num2 > num)
		{
			class4642_0.class4707_0.method_0(1.0);
		}
		else
		{
			class4642_0.class4707_0.method_0(0.0);
		}
	}

	private void method_9()
	{
		int num = (int)class4642_0.class4707_0.method_3();
		int num2 = (int)class4642_0.class4707_0.method_3();
		if (num2 >= num)
		{
			class4642_0.class4707_0.method_0(1.0);
		}
		else
		{
			class4642_0.class4707_0.method_0(0.0);
		}
	}

	private void method_10()
	{
		int num = (int)class4642_0.class4707_0.method_3();
		int num2 = (int)class4642_0.class4707_0.method_3();
		if (num2 == num)
		{
			class4642_0.class4707_0.method_0(1.0);
		}
		else
		{
			class4642_0.class4707_0.method_0(0.0);
		}
	}

	private void method_11()
	{
		int num = (int)class4642_0.class4707_0.method_3();
		int num2 = (int)class4642_0.class4707_0.method_3();
		if (num2 != num)
		{
			class4642_0.class4707_0.method_0(1.0);
		}
		else
		{
			class4642_0.class4707_0.method_0(0.0);
		}
	}

	private void method_12()
	{
		int num = 0;
		if ((int)class4642_0.class4707_0.method_3() != 0)
		{
			return;
		}
		num++;
		bool flag = false;
		while (int_2 <= class4646_0.EndIndex && !flag)
		{
			method_16(class4646_0, out var opcode);
			switch (opcode)
			{
			case Enum652.const_49:
				num++;
				break;
			case Enum652.const_50:
				num--;
				if (num == 0)
				{
					flag = true;
				}
				break;
			case Enum652.const_11:
				if (num == 1)
				{
					flag = true;
				}
				break;
			}
		}
	}

	private void method_13()
	{
		int num = 0;
		num = 1;
		bool flag = false;
		while (int_2 <= class4646_0.EndIndex && !flag)
		{
			method_16(class4646_0, out var opcode);
			switch (opcode)
			{
			case Enum652.const_49:
				num++;
				break;
			case Enum652.const_50:
				num--;
				if (num == 0)
				{
					flag = true;
				}
				break;
			}
		}
	}

	private void method_14()
	{
	}

	private void method_15()
	{
		int subroutineIndex = (int)class4642_0.class4707_0.method_3();
		int num = int_2;
		int endIndex = num;
		bool flag = false;
		while (int_2 <= class4646_0.EndIndex && !flag)
		{
			method_16(class4646_0, out var opcode);
			switch (opcode)
			{
			case Enum652.const_22:
				Subroutines.Add(subroutineIndex, new Class4646(class4646_0.Program, num, endIndex));
				flag = true;
				break;
			case Enum652.const_21:
			case Enum652.const_13:
				throw new Exception40();
			}
			endIndex = int_2;
		}
	}

	private void method_16(Class4646 program, out Enum652 opcode)
	{
		opcode = (Enum652)program[int_2++];
		switch (opcode)
		{
		case Enum652.const_65:
			int_2++;
			break;
		case Enum652.const_66:
			int_2 += 2;
			break;
		case Enum652.const_67:
			int_2 += 3;
			break;
		case Enum652.const_68:
			int_2 += 4;
			break;
		case Enum652.const_69:
			int_2 += 5;
			break;
		case Enum652.const_70:
			int_2 += 6;
			break;
		case Enum652.const_71:
			int_2 += 7;
			break;
		case Enum652.const_72:
			int_2 += 8;
			break;
		case Enum652.const_73:
			int_2 += 2;
			break;
		case Enum652.const_74:
			int_2 += 4;
			break;
		case Enum652.const_75:
			int_2 += 6;
			break;
		case Enum652.const_76:
			int_2 += 8;
			break;
		case Enum652.const_77:
			int_2 += 10;
			break;
		case Enum652.const_78:
			int_2 += 12;
			break;
		case Enum652.const_79:
			int_2 += 14;
			break;
		case Enum652.const_80:
			int_2 += 16;
			break;
		case Enum652.const_31:
		{
			byte b2 = class4646_0[int_2++];
			int_2 += b2;
			break;
		}
		case Enum652.const_32:
		{
			byte b = class4646_0[int_2++];
			int_2 += b * 2;
			break;
		}
		}
	}

	private void method_17()
	{
	}

	private void method_18()
	{
		byte b = class4646_0[int_2++];
		while (b > 0 && int_2 <= class4646_0.EndIndex)
		{
			class4642_0.class4707_0.method_0((int)class4646_0[int_2++]);
			b = (byte)(b - 1);
		}
	}

	private void method_19()
	{
		byte b = class4646_0[int_2++];
		while (b > 0 && int_2 <= class4646_0.EndIndex - 2)
		{
			class4642_0.class4707_0.method_0((class4646_0[int_2++] << 8) + class4646_0[int_2++]);
			b = (byte)(b - 1);
		}
	}

	private void method_20(int opNum)
	{
		int num = opNum + 1;
		while (num > 0 && int_2 <= class4646_0.EndIndex)
		{
			class4642_0.class4707_0.method_0((int)class4646_0[int_2++]);
			num--;
		}
	}

	private void method_21(int opNum)
	{
		int num = (opNum + 1) * 2;
		while (num > 0 && int_2 <= class4646_0.EndIndex)
		{
			class4642_0.class4707_0.method_0((class4646_0[int_2++] << 8) + class4646_0[int_2++]);
			num -= 2;
		}
	}

	private void method_22()
	{
		class4642_0.int_0 = (int)class4642_0.class4707_0.method_3();
	}

	private void method_23()
	{
		int num = (int)class4642_0.class4707_0.method_3();
		switch (num & 0xFF)
		{
		case 255:
			class4642_0.bool_0 = true;
			break;
		case 0:
			class4642_0.bool_0 = false;
			break;
		}
	}

	private void method_24()
	{
		double num = class4642_0.class4707_0.method_3();
		double num2 = class4642_0.class4707_0.method_3();
		class4642_0.class4707_0.method_0(num2 / num * 64.0);
	}

	private void method_25()
	{
		double num = class4642_0.class4707_0.method_3();
		double num2 = class4642_0.class4707_0.method_3();
		class4642_0.class4707_0.method_0(num2 * num / 64.0);
	}

	private void method_26()
	{
		double num = class4642_0.class4707_0.method_3();
		class4642_0.class4707_0.method_0(0.0 - num);
	}

	private void method_27()
	{
		class4642_0.double_0 = class4642_0.class4707_0.method_3();
	}

	private void method_28()
	{
		int entryIndex = (int)class4642_0.class4707_0.method_3();
		class4642_0.class4707_0.method_0((double)class4651_0.TTFTables.CvtTable.method_2(entryIndex) * 64.0);
	}

	private void method_29()
	{
		double operand = class4642_0.class4707_0.method_3();
		class4642_0.class4707_0.method_0(operand);
		class4642_0.class4707_0.method_0(operand);
	}

	private void method_30()
	{
		double num = class4642_0.class4707_0.method_3();
		int num2 = method_63(num / 64.0, 0.0);
		if (num2 % 2 == 0)
		{
			class4642_0.class4707_0.method_0(0.0);
		}
		else
		{
			class4642_0.class4707_0.method_0(1.0);
		}
	}

	private void method_31()
	{
		double num = class4642_0.class4707_0.method_3();
		int num2 = method_63(num / 64.0, 0.0);
		if (num2 % 2 == 0)
		{
			class4642_0.class4707_0.method_0(1.0);
		}
		else
		{
			class4642_0.class4707_0.method_0(0.0);
		}
	}

	private void method_32()
	{
		class4642_0.class4707_0.method_3();
	}

	private void method_33()
	{
		double num = class4642_0.class4707_0.method_3();
		int entryIndex = (int)class4642_0.class4707_0.method_3();
		class4651_0.TTFTables.CvtTable.method_3(entryIndex, (short)num);
	}

	private void method_34(int opNum)
	{
		double val = class4642_0.class4707_0.method_3();
		int num = method_63(val, class4642_0.double_1[opNum]);
		class4642_0.class4707_0.method_0(num);
	}

	private void method_35()
	{
		double num = class4642_0.class4707_0.method_3();
		int entryIndex = (int)class4642_0.class4707_0.method_3();
		class4651_0.TTFTables.CvtTable.method_3(entryIndex, (short)(num / 64.0));
	}

	private void method_36()
	{
		double operand = class4642_0.class4707_0.method_3();
		double operand2 = class4642_0.class4707_0.method_3();
		class4642_0.class4707_0.method_0(operand);
		class4642_0.class4707_0.method_0(operand2);
	}

	private void method_37(int opNum)
	{
		switch (opNum)
		{
		case 0:
			class4642_0.class4644_0.method_1(0.0, 1.0);
			class4642_0.class4644_1.method_1(0.0, 1.0);
			class4642_0.class4644_2.method_1(0.0, 1.0);
			class4642_0.class4647_0 = new Class4649();
			class4642_0.class4647_1 = new Class4649();
			break;
		case 1:
			class4642_0.class4644_0.method_1(1.0, 0.0);
			class4642_0.class4644_1.method_1(1.0, 0.0);
			class4642_0.class4644_2.method_1(1.0, 0.0);
			class4642_0.class4647_0 = new Class4650();
			class4642_0.class4647_1 = new Class4650();
			break;
		}
	}

	private void method_38(int opNum)
	{
		int num = (int)class4642_0.class4707_0.method_3();
		int num2 = (int)class4642_0.class4707_0.method_3();
		double num3 = class4642_0.class4643_4.PathDefinition.double_0[num2] - class4642_0.class4643_3.PathDefinition.double_0[num];
		double y = class4642_0.class4643_4.PathDefinition.double_1[num2] - class4642_0.class4643_3.PathDefinition.double_1[num];
		switch (opNum)
		{
		case 0:
			class4642_0.class4644_1.method_1(num3, y);
			class4642_0.class4644_2.method_1(num3, y);
			class4642_0.class4647_0 = new Class4648(class4642_0.class4644_1);
			break;
		case 1:
			y = 0.0 - num3;
			num3 = y;
			class4642_0.class4644_1.method_1(num3, y);
			class4642_0.class4644_2.method_1(num3, y);
			class4642_0.class4647_0 = new Class4648(class4642_0.class4644_1);
			break;
		}
	}

	private void method_39()
	{
		class4642_0.class4644_0.method_1(class4642_0.class4644_1.X, class4642_0.class4644_1.Y);
		if (class4642_0.class4644_0.X != 0.0 && class4642_0.class4644_0.Y != 0.0)
		{
			class4642_0.class4647_1 = new Class4648(class4642_0.class4644_0);
		}
		else if (class4642_0.class4644_0.Y != 0.0)
		{
			class4642_0.class4647_1 = new Class4649();
		}
		else
		{
			class4642_0.class4647_1 = new Class4650();
		}
	}

	private void method_40()
	{
		double operand = class4642_0.class4707_0.method_3();
		double operand2 = class4642_0.class4707_0.method_3();
		double operand3 = class4642_0.class4707_0.method_3();
		class4642_0.class4707_0.method_0(operand2);
		class4642_0.class4707_0.method_0(operand);
		class4642_0.class4707_0.method_0(operand3);
	}

	private void method_41()
	{
		while (class4642_0.int_1 > 0)
		{
			int num = (int)class4642_0.class4707_0.method_3();
			double num2 = class4642_0.class4647_0.vmethod_0(class4642_0.class4643_3.PathDefinition.double_0[num] - class4642_0.class4643_2.PathDefinition.double_0[class4642_0.int_3], class4642_0.class4643_3.PathDefinition.double_1[num] - class4642_0.class4643_2.PathDefinition.double_1[class4642_0.int_3]);
			class4642_0.class4647_1.vmethod_1(class4642_0.class4643_3.PathDefinition, num, 0.0 - num2);
			class4642_0.int_1--;
		}
		class4642_0.int_1 = 1;
	}

	private void method_42()
	{
		class4642_0.int_3 = (int)class4642_0.class4707_0.method_3();
	}

	private void method_43()
	{
		class4642_0.int_4 = (int)class4642_0.class4707_0.method_3();
	}

	private void method_44()
	{
		class4642_0.int_5 = (int)class4642_0.class4707_0.method_3();
	}

	private void method_45()
	{
		double num = class4642_0.class4707_0.method_3();
		int num2 = (int)class4642_0.class4707_0.method_3();
		double num3 = class4642_0.class4647_0.vmethod_0(class4642_0.class4643_4.OriginalPathDefinition.double_0[num2], class4642_0.class4643_4.OriginalPathDefinition.double_1[num2]);
		class4642_0.class4647_1.vmethod_1(class4642_0.class4643_4.PathDefinition, num2, num / 64.0 - num3);
	}

	private void method_46()
	{
		while (class4642_0.int_1 > 0)
		{
			int num = (int)class4642_0.class4707_0.method_3();
			double num2 = class4642_0.class4647_0.vmethod_0(class4642_0.class4643_4.OriginalPathDefinition.double_0[num], class4642_0.class4643_4.OriginalPathDefinition.double_1[num]);
			double num3 = class4642_0.class4647_0.vmethod_0(class4642_0.class4643_2.OriginalPathDefinition.double_0[class4642_0.int_4], class4642_0.class4643_2.OriginalPathDefinition.double_1[class4642_0.int_4]);
			double num4 = class4642_0.class4647_0.vmethod_0(class4642_0.class4643_3.OriginalPathDefinition.double_0[class4642_0.int_5], class4642_0.class4643_3.OriginalPathDefinition.double_1[class4642_0.int_5]);
			double num5 = class4642_0.class4647_0.vmethod_0(class4642_0.class4643_4.PathDefinition.double_0[num], class4642_0.class4643_4.PathDefinition.double_1[num]);
			double num6 = class4642_0.class4647_0.vmethod_0(class4642_0.class4643_2.PathDefinition.double_0[class4642_0.int_4], class4642_0.class4643_2.PathDefinition.double_1[class4642_0.int_4]);
			double num7 = class4642_0.class4647_0.vmethod_0(class4642_0.class4643_3.PathDefinition.double_0[class4642_0.int_5], class4642_0.class4643_3.PathDefinition.double_1[class4642_0.int_5]);
			if (num3 != num4)
			{
				double num8 = num3;
				double num9 = num4;
				double num10 = num6;
				double num11 = num7;
				double num12 = num2;
				double num13 = num5;
				double num14 = num9 - num8;
				double num15 = (num12 - num8) / num14;
				double num16 = num10 + (num11 - num10) * num15;
				class4642_0.class4647_1.vmethod_1(class4642_0.class4643_4.PathDefinition, num, num16 - num13);
			}
			class4642_0.int_1--;
		}
		class4642_0.int_1 = 1;
	}

	private void method_47(int opNum)
	{
		Class4616 pathDefinition = class4642_0.class4643_4.PathDefinition;
		Class4616 originalPathDefinition = class4642_0.class4643_4.OriginalPathDefinition;
		bool[] touched = ((opNum == 1) ? pathDefinition.bool_1 : pathDefinition.bool_0);
		int num = 0;
		for (int i = 0; i < class4642_0.class4643_4.PathDefinition.int_0; i++)
		{
			int num2 = pathDefinition.ushort_0[i];
			int num3 = -1;
			int searchFromPoint = num;
			int num4 = -1;
			int num5 = -1;
			bool flag = true;
			do
			{
				if (flag = smethod_1(searchFromPoint, num2, touched, out var nextTouchedPoint))
				{
					if (num4 == -1)
					{
						num4 = nextTouchedPoint;
					}
					num5 = nextTouchedPoint;
					if (num3 != -1 && nextTouchedPoint - num3 - 1 > 0)
					{
						smethod_0(opNum, originalPathDefinition, pathDefinition, num3, nextTouchedPoint, num3 + 1, nextTouchedPoint - 1);
					}
					num3 = nextTouchedPoint;
					searchFromPoint = num3 + 1;
				}
			}
			while (flag);
			if (num4 != -1 && num5 != -1)
			{
				if (num4 != num5)
				{
					if (num != num4)
					{
						smethod_0(opNum, originalPathDefinition, pathDefinition, num4, num5, num, num4 - 1);
					}
					if (num2 != num5)
					{
						smethod_0(opNum, originalPathDefinition, pathDefinition, num4, num5, num5 + 1, num2);
					}
				}
				else
				{
					double num6 = ((opNum == 1) ? originalPathDefinition.double_0[num3] : originalPathDefinition.double_1[num3]);
					double num7 = ((opNum == 1) ? pathDefinition.double_0[num3] : pathDefinition.double_1[num3]);
					double num8 = num7 - num6;
					for (int j = num; j <= num2; j++)
					{
						if (j != num3)
						{
							switch (opNum)
							{
							case 0:
								pathDefinition.double_1[j] += num8;
								break;
							case 1:
								pathDefinition.double_0[j] += num8;
								break;
							}
						}
					}
				}
			}
			num = num2 + 1;
		}
	}

	private void method_48(int opNum)
	{
		int num = (int)class4642_0.class4707_0.method_3();
		double distance = 0.0;
		switch (opNum)
		{
		case 1:
			distance = class4642_0.class4647_0.vmethod_0(class4642_0.class4643_2.PathDefinition.double_0[num], class4642_0.class4643_2.PathDefinition.double_1[num]);
			distance = (double)method_63(distance, class4642_0.double_1[0]) - distance;
			break;
		}
		class4642_0.class4647_1.vmethod_1(class4642_0.class4643_2.PathDefinition, num, distance);
		class4642_0.int_3 = num;
		class4642_0.int_4 = num;
	}

	private void method_49(int opNum)
	{
		int entryIndex = (int)class4642_0.class4707_0.method_3();
		int num = (int)class4642_0.class4707_0.method_3();
		double num2 = class4651_0.TTFTables.CvtTable.method_2(entryIndex);
		if (method_62(num2))
		{
			num2 = ((!(num2 >= 0.0)) ? (0.0 - class4642_0.double_2) : class4642_0.double_2);
		}
		double num3 = class4642_0.class4647_0.vmethod_0(class4642_0.class4643_3.PathDefinition.double_0[num] - class4642_0.class4643_2.PathDefinition.double_0[class4642_0.int_3], class4642_0.class4643_3.PathDefinition.double_1[num] - class4642_0.class4643_2.PathDefinition.double_1[class4642_0.int_3]);
		double num4 = class4642_0.class4647_0.vmethod_0(class4642_0.class4643_3.OriginalPathDefinition.double_0[num] - class4642_0.class4643_2.OriginalPathDefinition.double_0[class4642_0.int_3], class4642_0.class4643_3.OriginalPathDefinition.double_1[num] - class4642_0.class4643_2.OriginalPathDefinition.double_1[class4642_0.int_3]);
		if (class4642_0.bool_1 && num4 != 0.0 && ((num4 < 0.0 && num2 > 0.0) || (num4 > 0.0 && num2 < 0.0)))
		{
			num2 = 0.0 - num2;
		}
		double num5 = (((opNum & 4) == 0) ? smethod_2(num2, class4642_0.double_1[opNum & 3]) : ((double)method_63(num2, class4642_0.double_1[opNum & 3])));
		if (((uint)opNum & 8u) != 0)
		{
			if (num4 >= 0.0)
			{
				if (num5 < (double)class4642_0.int_2)
				{
					num5 = class4642_0.int_2;
				}
			}
			else if (num5 > (double)(-class4642_0.int_2))
			{
				num5 = -class4642_0.int_2;
			}
		}
		class4642_0.class4647_1.vmethod_1(class4642_0.class4643_3.PathDefinition, num, num5 - num3);
		class4642_0.int_4 = class4642_0.int_3;
		if (((uint)opNum & 0x10u) != 0)
		{
			class4642_0.int_3 = num;
		}
		class4642_0.int_5 = num;
	}

	private void method_50(int opNum)
	{
		int num = (int)class4642_0.class4707_0.method_3();
		double outX = class4642_0.class4647_0.vmethod_0(class4642_0.class4643_3.OriginalPathDefinition.double_0[num] - class4642_0.class4643_2.OriginalPathDefinition.double_0[class4642_0.int_3], class4642_0.class4643_3.OriginalPathDefinition.double_1[num] - class4642_0.class4643_2.OriginalPathDefinition.double_1[class4642_0.int_3]);
		method_61(ref outX);
		double num2 = (((opNum & 4) == 0) ? smethod_2(outX, class4642_0.double_1[opNum & 3]) : ((double)method_63(outX, class4642_0.double_1[opNum & 3])));
		if (((uint)opNum & 8u) != 0)
		{
			if (outX >= 0.0)
			{
				if (num2 < (double)class4642_0.int_2)
				{
					num2 = class4642_0.int_2;
				}
			}
			else if (num2 > (double)(-class4642_0.int_2))
			{
				num2 = -class4642_0.int_2;
			}
		}
		double num3 = class4642_0.class4647_0.vmethod_0(class4642_0.class4643_3.PathDefinition.double_0[num] - class4642_0.class4643_2.PathDefinition.double_0[class4642_0.int_3], class4642_0.class4643_3.PathDefinition.double_1[num] - class4642_0.class4643_2.PathDefinition.double_1[class4642_0.int_3]);
		class4642_0.class4647_1.vmethod_1(class4642_0.class4643_3.PathDefinition, num, num2 - num3);
		class4642_0.int_4 = class4642_0.int_3;
		class4642_0.int_5 = num;
		if (((uint)opNum & 0x10u) != 0)
		{
			class4642_0.int_3 = num;
		}
	}

	private void method_51(int opNum)
	{
		int entryIndex = (int)class4642_0.class4707_0.method_3();
		int num = (int)class4642_0.class4707_0.method_3();
		int num2 = class4651_0.TTFTables.CvtTable.method_2(entryIndex);
		double num3 = class4642_0.class4647_0.vmethod_0(class4642_0.class4643_2.PathDefinition.double_0[num], class4642_0.class4643_2.PathDefinition.double_1[num]);
		if (opNum == 1)
		{
			num2 = method_63(num2, class4642_0.double_1[0]);
		}
		class4642_0.class4647_1.vmethod_1(class4642_0.class4643_2.PathDefinition, num, (double)num2 - num3);
		class4642_0.int_3 = num;
		class4642_0.int_4 = num;
	}

	private void method_52(int opNum)
	{
		int num = (int)class4642_0.class4707_0.method_3();
		int num2 = (int)class4642_0.class4707_0.method_3();
		double num3 = class4642_0.class4647_0.vmethod_0(class4642_0.class4643_3.PathDefinition.double_0[num2] - class4642_0.class4643_2.PathDefinition.double_0[class4642_0.int_3], class4642_0.class4643_3.PathDefinition.double_1[num2] - class4642_0.class4643_2.PathDefinition.double_1[class4642_0.int_3]);
		class4642_0.class4647_1.vmethod_1(class4642_0.class4643_3.PathDefinition, num2, (double)(num / 64) - num3);
		class4642_0.int_4 = class4642_0.int_3;
		class4642_0.int_5 = num2;
		if (((uint)opNum & (true ? 1u : 0u)) != 0)
		{
			class4642_0.int_3 = num2;
		}
	}

	private void method_53()
	{
		int num = (int)class4642_0.class4707_0.method_3();
		class4642_0.class4707_0.method_0(class4642_0.class4707_0.Peek(num - 1));
	}

	private void method_54()
	{
		class4642_0.enum651_0 = Enum651.const_1;
	}

	private void method_55()
	{
		double num = class4642_0.class4707_0.method_3();
		double num2 = class4642_0.class4707_0.method_3();
		class4642_0.class4707_0.method_0(num2 + num);
	}

	private void method_56()
	{
		double num = class4642_0.class4707_0.method_3();
		double num2 = class4642_0.class4707_0.method_3();
		class4642_0.class4707_0.method_0(num2 - num);
	}

	private void method_57()
	{
		double value = class4642_0.class4707_0.method_3();
		class4642_0.class4707_0.method_0(Math.Abs(value));
	}

	private void method_58(int opNum)
	{
		int num = (int)class4642_0.class4707_0.method_3();
		int num2 = (int)class4642_0.class4707_0.method_3();
		double num3 = opNum switch
		{
			0 => class4642_0.class4647_0.vmethod_0(class4642_0.class4643_3.PathDefinition.double_0[num2] - class4642_0.class4643_2.PathDefinition.double_0[num], class4642_0.class4643_3.PathDefinition.double_1[num2] - class4642_0.class4643_2.PathDefinition.double_1[num]), 
			_ => class4642_0.class4647_0.vmethod_0(class4642_0.class4643_3.OriginalPathDefinition.double_0[num2] - class4642_0.class4643_2.OriginalPathDefinition.double_0[num], class4642_0.class4643_3.OriginalPathDefinition.double_1[num2] - class4642_0.class4643_2.OriginalPathDefinition.double_1[num]), 
		};
		class4642_0.class4707_0.method_0(num3 * 64.0);
	}

	private void method_59()
	{
		class4642_0.class4707_0.method_0(class4642_0.class4644_1.X);
		class4642_0.class4707_0.method_0(class4642_0.class4644_1.Y);
	}

	private void method_60()
	{
		double y = class4642_0.class4707_0.method_3();
		double x = class4642_0.class4707_0.method_3();
		class4642_0.class4644_1.method_1(x, y);
		class4642_0.class4644_2.method_1(x, y);
	}

	private static void smethod_0(int opNum, Class4616 origPath, Class4616 currentPath, int firstTouchedPoint, int nextTouchedPoint, int firstSequencePoint, int lastSequencePoint)
	{
		double num = ((opNum == 1) ? origPath.double_0[firstTouchedPoint] : origPath.double_1[firstTouchedPoint]);
		double num2 = ((opNum == 1) ? origPath.double_0[nextTouchedPoint] : origPath.double_1[nextTouchedPoint]);
		double num3 = ((opNum == 1) ? currentPath.double_0[firstTouchedPoint] : currentPath.double_1[firstTouchedPoint]);
		double num4 = ((opNum == 1) ? currentPath.double_0[nextTouchedPoint] : currentPath.double_1[nextTouchedPoint]);
		for (int i = firstSequencePoint; i <= lastSequencePoint; i++)
		{
			double num5 = ((opNum == 1) ? origPath.double_0[i] : origPath.double_1[i]);
			double num6 = 0.0;
			if ((num2 > num && num5 > num && num5 < num2) || (num2 < num && num5 > num2 && num5 < num))
			{
				double num7 = num2 - num;
				double num8 = (num5 - num) / num7;
				num6 = num3 + (num4 - num3) * num8;
			}
			else
			{
				double num9 = Math.Abs(num5 - num);
				double num10 = Math.Abs(num2 - num5);
				double num11 = ((num9 < num10) ? (num3 - num) : (num4 - num2));
				num6 = num5 + num11;
			}
			switch (opNum)
			{
			case 0:
				currentPath.double_1[i] = num6;
				break;
			case 1:
				currentPath.double_0[i] = num6;
				break;
			}
		}
	}

	private static bool smethod_1(int searchFromPoint, int searchToPoint, bool[] touched, out int nextTouchedPoint)
	{
		int num = searchFromPoint;
		while (true)
		{
			if (num <= searchToPoint)
			{
				if (touched[num])
				{
					break;
				}
				num++;
				continue;
			}
			nextTouchedPoint = -1;
			return false;
		}
		nextTouchedPoint = num;
		return true;
	}

	private void method_61(ref double outX)
	{
		if (method_62(outX))
		{
			if (outX >= 0.0)
			{
				outX = class4642_0.double_2;
			}
			else
			{
				outX = 0.0 - class4642_0.double_2;
			}
		}
	}

	private bool method_62(double cvt_dist)
	{
		return Math.Abs(cvt_dist - class4642_0.double_2) < class4642_0.double_3;
	}

	private int method_63(double val, double compensation)
	{
		Enum651 enum651_ = class4642_0.enum651_0;
		if (enum651_ == Enum651.const_1)
		{
			return (int)Math.Round(val + compensation);
		}
		return (int)Math.Round(val);
	}

	private static double smethod_2(double distance, double compensation)
	{
		return (int)distance;
	}
}
