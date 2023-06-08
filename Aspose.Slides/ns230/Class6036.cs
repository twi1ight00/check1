using System;
using System.Collections;
using ns226;
using ns229;

namespace ns230;

internal class Class6036 : Class6026
{
	internal class Class6065 : Class6056
	{
		public static Class6065 smethod_1(Class6110 header, Class6017 data)
		{
			return new Class6065(header, data);
		}

		protected Class6065(Class6110 header, Class6017 data)
			: base(header, data)
		{
		}

		protected Class6065(Class6110 header, Class6016 data)
			: base(header, data)
		{
		}

		protected override Class6025 vmethod_6(Class6016 data)
		{
			return new Class6036(method_16(), data);
		}

		public int method_18()
		{
			return method_6().method_16(0);
		}

		public void method_19(int version)
		{
			method_7().method_37(0, version);
		}

		public int method_20()
		{
			return method_6().method_17(2);
		}

		public void method_21(int width)
		{
			method_7().method_39(2, width);
		}

		public int method_22()
		{
			return method_6().method_16(4);
		}

		public void method_23(int weight)
		{
			method_7().method_37(4, weight);
		}

		public int method_24()
		{
			return method_6().method_16(6);
		}

		public void method_25(int width)
		{
			method_7().method_37(6, width);
		}

		public Enum775[] method_26()
		{
			return Class6106.smethod_1(method_27());
		}

		public int method_27()
		{
			return method_6().method_16(8);
		}

		public void method_28(Enum775[] flagSet)
		{
			method_29(Class6106.smethod_2(flagSet));
		}

		public void method_29(int fsType)
		{
			method_7().method_37(8, fsType);
		}

		public int method_30()
		{
			return method_6().method_17(10);
		}

		public void method_31(int size)
		{
			method_7().method_39(10, size);
		}

		public int method_32()
		{
			return method_6().method_17(12);
		}

		public void method_33(int size)
		{
			method_7().method_39(12, size);
		}

		public int method_34()
		{
			return method_6().method_17(14);
		}

		public void method_35(int offset)
		{
			method_7().method_39(14, offset);
		}

		public int method_36()
		{
			return method_6().method_17(16);
		}

		public void method_37(int offset)
		{
			method_7().method_39(16, offset);
		}

		public int method_38()
		{
			return method_6().method_17(18);
		}

		public void method_39(int size)
		{
			method_7().method_39(18, size);
		}

		public int method_40()
		{
			return method_6().method_17(20);
		}

		public void method_41(int size)
		{
			method_7().method_39(20, size);
		}

		public int method_42()
		{
			return method_6().method_17(22);
		}

		public void method_43(int offset)
		{
			method_7().method_39(22, offset);
		}

		public int method_44()
		{
			return method_6().method_17(24);
		}

		public void method_45(int offset)
		{
			method_7().method_39(24, offset);
		}

		public int method_46()
		{
			return method_6().method_17(26);
		}

		public void method_47(int size)
		{
			method_7().method_39(26, size);
		}

		public int method_48()
		{
			return method_6().method_17(28);
		}

		public void method_49(int position)
		{
			method_7().method_39(28, position);
		}

		public int method_50()
		{
			return method_6().method_17(30);
		}

		public void method_51(int family)
		{
			method_7().method_39(30, family);
		}

		public byte[] method_52()
		{
			byte[] array = new byte[10];
			method_6().method_14(32, array, 0, array.Length);
			return array;
		}

		public void method_53(byte[] panose)
		{
			if (panose.Length != 10)
			{
				throw new InvalidOperationException("Panose bytes must be exactly 10 in length.");
			}
			method_7().method_31(32, panose, 0, panose.Length);
		}

		public long method_54()
		{
			return method_6().method_19(42);
		}

		public void method_55(long range)
		{
			method_7().method_41(42, range);
		}

		public long method_56()
		{
			return method_6().method_19(46);
		}

		public void method_57(long range)
		{
			method_7().method_41(46, range);
		}

		public long method_58()
		{
			return method_6().method_19(50);
		}

		public void method_59(long range)
		{
			method_7().method_41(50, range);
		}

		public long method_60()
		{
			return method_6().method_19(54);
		}

		public void method_61(long range)
		{
			method_7().method_41(54, range);
		}

		public Enum776[] method_62()
		{
			return Class6107.smethod_1(method_54(), method_56(), method_58(), method_60());
		}

		public void method_63(Enum776[] rangeSet)
		{
			long[] array = Class6107.smethod_2(rangeSet);
			method_55(array[0]);
			method_57(array[1]);
			method_59(array[2]);
			method_61(array[3]);
		}

		public byte[] method_64()
		{
			byte[] array = new byte[4];
			method_6().method_14(58, array, 0, array.Length);
			return array;
		}

		public void method_65(byte[] b)
		{
			method_7().method_32(58, b, 0, 4, 32);
		}

		public int method_66()
		{
			return method_6().method_16(62);
		}

		public void method_67(int fsSelection)
		{
			method_7().method_37(62, fsSelection);
		}

		public void method_68(Enum777[] fsSelection)
		{
			method_67(Class6108.smethod_2(fsSelection));
		}

		public int method_69()
		{
			return method_6().method_16(64);
		}

		public void method_70(int firstIndex)
		{
			method_7().method_37(64, firstIndex);
		}

		public int method_71()
		{
			return method_6().method_16(66);
		}

		public void method_72(int lastIndex)
		{
			method_7().method_37(64, lastIndex);
		}

		public int method_73()
		{
			return method_6().method_17(68);
		}

		public void method_74(int ascender)
		{
			method_7().method_39(68, ascender);
		}

		public int method_75()
		{
			return method_6().method_17(70);
		}

		public void method_76(int descender)
		{
			method_7().method_39(70, descender);
		}

		public int method_77()
		{
			return method_6().method_17(72);
		}

		public void method_78(int lineGap)
		{
			method_7().method_39(72, lineGap);
		}

		public int method_79()
		{
			return method_6().method_16(74);
		}

		public void method_80(int ascent)
		{
			method_7().method_37(74, ascent);
		}

		public int method_81()
		{
			return method_6().method_16(76);
		}

		public void method_82(int descent)
		{
			method_7().method_37(74, descent);
		}

		public long method_83()
		{
			return method_6().method_19(78);
		}

		public void method_84(long range)
		{
			method_7().method_41(78, range);
		}

		public long method_85()
		{
			return method_6().method_19(82);
		}

		public void method_86(long range)
		{
			method_7().method_41(82, range);
		}

		public Enum778[] method_87()
		{
			return Class6109.smethod_1(method_83(), method_85());
		}

		public void method_88(Enum778[] rangeSet)
		{
			long[] array = Class6109.smethod_2(rangeSet);
			method_84(array[0]);
			method_86(array[1]);
		}

		public int method_89()
		{
			return method_6().method_17(86);
		}

		public void method_90(int height)
		{
			method_7().method_39(86, height);
		}

		public int method_91()
		{
			return method_6().method_17(88);
		}

		public void method_92(int height)
		{
			method_7().method_39(88, height);
		}

		public int method_93()
		{
			return method_6().method_16(90);
		}

		public void method_94(int defaultChar)
		{
			method_7().method_37(90, defaultChar);
		}

		public int method_95()
		{
			return method_6().method_16(92);
		}

		public void method_96(int breakChar)
		{
			method_7().method_37(92, breakChar);
		}

		public int method_97()
		{
			return method_6().method_16(94);
		}

		public void method_98(int maxContext)
		{
			method_7().method_37(94, maxContext);
		}
	}

	private enum Enum772
	{
		const_0 = 0,
		const_1 = 2,
		const_2 = 4,
		const_3 = 6,
		const_4 = 8,
		const_5 = 10,
		const_6 = 12,
		const_7 = 14,
		const_8 = 16,
		const_9 = 18,
		const_10 = 20,
		const_11 = 22,
		const_12 = 24,
		const_13 = 26,
		const_14 = 28,
		const_15 = 30,
		const_16 = 32,
		const_17 = 10,
		const_18 = 42,
		const_19 = 46,
		const_20 = 50,
		const_21 = 54,
		const_22 = 58,
		const_23 = 4,
		const_24 = 62,
		const_25 = 64,
		const_26 = 66,
		const_27 = 68,
		const_28 = 70,
		const_29 = 72,
		const_30 = 74,
		const_31 = 76,
		const_32 = 78,
		const_33 = 82,
		const_34 = 86,
		const_35 = 88,
		const_36 = 90,
		const_37 = 92,
		const_38 = 94
	}

	public enum Enum773
	{
		const_0 = 100,
		const_1 = 200,
		const_2 = 200,
		const_3 = 300,
		const_4 = 400,
		const_5 = 400,
		const_6 = 500,
		const_7 = 600,
		const_8 = 600,
		const_9 = 700,
		const_10 = 800,
		const_11 = 800,
		const_12 = 900,
		const_13 = 900
	}

	public enum Enum774
	{
		const_0 = 1,
		const_1 = 2,
		const_2 = 3,
		const_3 = 4,
		const_4 = 5,
		const_5 = 5,
		const_6 = 6,
		const_7 = 7,
		const_8 = 8,
		const_9 = 9
	}

	internal class Class6106
	{
		private static Enum775[] enum775_0 = new Enum775[16]
		{
			Enum775.const_0,
			Enum775.const_1,
			Enum775.const_2,
			Enum775.const_3,
			Enum775.const_4,
			Enum775.const_5,
			Enum775.const_6,
			Enum775.const_7,
			Enum775.const_8,
			Enum775.const_9,
			Enum775.const_10,
			Enum775.const_11,
			Enum775.const_12,
			Enum775.const_13,
			Enum775.const_14,
			Enum775.const_15
		};

		public static int smethod_0(Enum775 flag)
		{
			return 1 << (int)flag;
		}

		public static Enum775[] smethod_1(int value)
		{
			ArrayList arrayList = new ArrayList();
			Enum775[] array = enum775_0;
			foreach (Enum775 @enum in array)
			{
				if ((value & smethod_0(@enum)) == smethod_0(@enum))
				{
					arrayList.Add(@enum);
				}
			}
			return (Enum775[])arrayList.ToArray(typeof(Enum775));
		}

		public static int smethod_2(Enum775[] flagSet)
		{
			int num = 0;
			foreach (Enum775 flag in flagSet)
			{
				num |= smethod_0(flag);
			}
			return num;
		}

		public static bool smethod_3(Enum775[] flagSet)
		{
			return flagSet.Length == 0;
		}

		public static bool smethod_4(int value)
		{
			return value == 0;
		}
	}

	public enum Enum775
	{
		const_0,
		const_1,
		const_2,
		const_3,
		const_4,
		const_5,
		const_6,
		const_7,
		const_8,
		const_9,
		const_10,
		const_11,
		const_12,
		const_13,
		const_14,
		const_15
	}

	internal class Class6107
	{
		private static Enum776[] enum776_0 = new Enum776[126]
		{
			Enum776.const_0,
			Enum776.const_1,
			Enum776.const_2,
			Enum776.const_3,
			Enum776.const_4,
			Enum776.const_5,
			Enum776.const_6,
			Enum776.const_7,
			Enum776.const_8,
			Enum776.const_9,
			Enum776.const_10,
			Enum776.const_11,
			Enum776.const_12,
			Enum776.const_13,
			Enum776.const_14,
			Enum776.const_15,
			Enum776.const_16,
			Enum776.const_17,
			Enum776.const_18,
			Enum776.const_19,
			Enum776.const_20,
			Enum776.const_21,
			Enum776.const_22,
			Enum776.const_23,
			Enum776.const_24,
			Enum776.const_25,
			Enum776.const_26,
			Enum776.const_27,
			Enum776.const_28,
			Enum776.const_29,
			Enum776.const_30,
			Enum776.const_31,
			Enum776.const_32,
			Enum776.const_33,
			Enum776.const_34,
			Enum776.const_35,
			Enum776.const_36,
			Enum776.const_37,
			Enum776.const_38,
			Enum776.const_39,
			Enum776.const_40,
			Enum776.const_41,
			Enum776.const_42,
			Enum776.const_43,
			Enum776.const_44,
			Enum776.const_45,
			Enum776.const_46,
			Enum776.const_47,
			Enum776.const_48,
			Enum776.const_49,
			Enum776.const_50,
			Enum776.const_51,
			Enum776.const_52,
			Enum776.const_53,
			Enum776.const_54,
			Enum776.const_55,
			Enum776.const_56,
			Enum776.const_57,
			Enum776.const_58,
			Enum776.const_59,
			Enum776.const_60,
			Enum776.const_61,
			Enum776.const_62,
			Enum776.const_63,
			Enum776.const_64,
			Enum776.const_65,
			Enum776.const_66,
			Enum776.const_67,
			Enum776.const_68,
			Enum776.const_69,
			Enum776.const_70,
			Enum776.const_71,
			Enum776.const_72,
			Enum776.const_73,
			Enum776.const_74,
			Enum776.const_75,
			Enum776.const_76,
			Enum776.const_77,
			Enum776.const_78,
			Enum776.const_79,
			Enum776.const_80,
			Enum776.const_81,
			Enum776.const_82,
			Enum776.const_83,
			Enum776.const_84,
			Enum776.const_85,
			Enum776.const_86,
			Enum776.const_87,
			Enum776.const_88,
			Enum776.const_89,
			Enum776.const_90,
			Enum776.const_91,
			Enum776.const_92,
			Enum776.const_93,
			Enum776.const_94,
			Enum776.const_95,
			Enum776.const_96,
			Enum776.const_97,
			Enum776.const_98,
			Enum776.const_99,
			Enum776.const_100,
			Enum776.const_101,
			Enum776.const_102,
			Enum776.const_103,
			Enum776.const_104,
			Enum776.const_105,
			Enum776.const_106,
			Enum776.const_107,
			Enum776.const_108,
			Enum776.const_109,
			Enum776.const_110,
			Enum776.const_111,
			Enum776.const_112,
			Enum776.const_113,
			Enum776.const_114,
			Enum776.const_115,
			Enum776.const_116,
			Enum776.const_117,
			Enum776.const_118,
			Enum776.const_119,
			Enum776.const_120,
			Enum776.const_121,
			Enum776.const_122,
			Enum776.const_123,
			Enum776.const_124,
			Enum776.const_125
		};

		public static Enum776[] AllFlags => enum776_0;

		public static Enum776 smethod_0(int bit)
		{
			if (bit > enum776_0.Length)
			{
				return Enum776.const_125;
			}
			return enum776_0[bit];
		}

		public static Enum776[] smethod_1(long range1, long range2, long range3, long range4)
		{
			ArrayList arrayList = new ArrayList();
			long[] array = new long[4] { range1, range2, range3, range4 };
			int num = 0;
			int num2 = -1;
			Enum776[] array2 = enum776_0;
			foreach (Enum776 @enum in array2)
			{
				if ((int)@enum % 32 == 0)
				{
					num = 0;
					num2++;
				}
				else
				{
					num++;
				}
				if ((array[num2] & (1 << num)) == 1 << num)
				{
					arrayList.Add(@enum);
				}
			}
			return (Enum776[])arrayList.ToArray(typeof(Enum776));
		}

		public static long[] smethod_2(Enum776[] rangeSet)
		{
			long[] array = new long[4];
			foreach (Enum776 @enum in rangeSet)
			{
				int num = (int)@enum / 32;
				long num2 = 1 << (int)@enum % 32;
				array[num] |= num2;
			}
			return array;
		}
	}

	public enum Enum776
	{
		const_0,
		const_1,
		const_2,
		const_3,
		const_4,
		const_5,
		const_6,
		const_7,
		const_8,
		const_9,
		const_10,
		const_11,
		const_12,
		const_13,
		const_14,
		const_15,
		const_16,
		const_17,
		const_18,
		const_19,
		const_20,
		const_21,
		const_22,
		const_23,
		const_24,
		const_25,
		const_26,
		const_27,
		const_28,
		const_29,
		const_30,
		const_31,
		const_32,
		const_33,
		const_34,
		const_35,
		const_36,
		const_37,
		const_38,
		const_39,
		const_40,
		const_41,
		const_42,
		const_43,
		const_44,
		const_45,
		const_46,
		const_47,
		const_48,
		const_49,
		const_50,
		const_51,
		const_52,
		const_53,
		const_54,
		const_55,
		const_56,
		const_57,
		const_58,
		const_59,
		const_60,
		const_61,
		const_62,
		const_63,
		const_64,
		const_65,
		const_66,
		const_67,
		const_68,
		const_69,
		const_70,
		const_71,
		const_72,
		const_73,
		const_74,
		const_75,
		const_76,
		const_77,
		const_78,
		const_79,
		const_80,
		const_81,
		const_82,
		const_83,
		const_84,
		const_85,
		const_86,
		const_87,
		const_88,
		const_89,
		const_90,
		const_91,
		const_92,
		const_93,
		const_94,
		const_95,
		const_96,
		const_97,
		const_98,
		const_99,
		const_100,
		const_101,
		const_102,
		const_103,
		const_104,
		const_105,
		const_106,
		const_107,
		const_108,
		const_109,
		const_110,
		const_111,
		const_112,
		const_113,
		const_114,
		const_115,
		const_116,
		const_117,
		const_118,
		const_119,
		const_120,
		const_121,
		const_122,
		const_123,
		const_124,
		const_125
	}

	internal class Class6108
	{
		private static Enum777[] enum777_0 = new Enum777[10]
		{
			Enum777.const_0,
			Enum777.const_1,
			Enum777.const_2,
			Enum777.const_3,
			Enum777.const_4,
			Enum777.const_5,
			Enum777.const_6,
			Enum777.const_7,
			Enum777.const_8,
			Enum777.const_9
		};

		public static int smethod_0(Enum777 flag)
		{
			return 1 << (int)flag;
		}

		public static Enum777[] smethod_1(int value)
		{
			ArrayList arrayList = new ArrayList();
			Enum777[] array = enum777_0;
			foreach (Enum777 @enum in array)
			{
				if ((value & smethod_0(@enum)) == smethod_0(@enum))
				{
					arrayList.Add(@enum);
				}
			}
			return (Enum777[])arrayList.ToArray(typeof(Enum777));
		}

		public static int smethod_2(Enum777[] fsSelectionSet)
		{
			int num = 0;
			foreach (Enum777 flag in fsSelectionSet)
			{
				num |= smethod_0(flag);
			}
			return num;
		}
	}

	public enum Enum777
	{
		const_0,
		const_1,
		const_2,
		const_3,
		const_4,
		const_5,
		const_6,
		const_7,
		const_8,
		const_9
	}

	internal class Class6109
	{
		private static Enum778[] enum778_0 = new Enum778[64]
		{
			Enum778.const_0,
			Enum778.const_1,
			Enum778.const_2,
			Enum778.const_3,
			Enum778.const_4,
			Enum778.const_5,
			Enum778.const_6,
			Enum778.const_7,
			Enum778.const_8,
			Enum778.const_9,
			Enum778.const_10,
			Enum778.const_11,
			Enum778.const_12,
			Enum778.const_13,
			Enum778.const_14,
			Enum778.const_15,
			Enum778.const_16,
			Enum778.const_17,
			Enum778.const_18,
			Enum778.const_19,
			Enum778.const_20,
			Enum778.const_21,
			Enum778.const_22,
			Enum778.const_23,
			Enum778.const_24,
			Enum778.const_25,
			Enum778.const_26,
			Enum778.const_27,
			Enum778.const_28,
			Enum778.const_29,
			Enum778.const_30,
			Enum778.const_31,
			Enum778.const_32,
			Enum778.const_33,
			Enum778.const_34,
			Enum778.const_35,
			Enum778.const_36,
			Enum778.const_37,
			Enum778.const_38,
			Enum778.const_39,
			Enum778.const_40,
			Enum778.const_41,
			Enum778.const_42,
			Enum778.const_43,
			Enum778.const_44,
			Enum778.const_45,
			Enum778.const_46,
			Enum778.const_47,
			Enum778.const_48,
			Enum778.const_49,
			Enum778.const_50,
			Enum778.const_51,
			Enum778.const_52,
			Enum778.const_53,
			Enum778.const_54,
			Enum778.const_55,
			Enum778.const_56,
			Enum778.const_57,
			Enum778.const_58,
			Enum778.const_59,
			Enum778.const_60,
			Enum778.const_61,
			Enum778.const_62,
			Enum778.const_63
		};

		public static Enum778[] AllFlags => enum778_0;

		public static Enum778 smethod_0(int bit)
		{
			if (bit > enum778_0.Length)
			{
				return Enum778.const_63;
			}
			return enum778_0[bit];
		}

		public static Enum778[] smethod_1(long range1, long range2)
		{
			ArrayList arrayList = new ArrayList();
			long[] array = new long[2] { range1, range2 };
			int num = 0;
			int num2 = -1;
			Enum778[] array2 = enum778_0;
			foreach (Enum778 @enum in array2)
			{
				if ((int)@enum % 32 == 0)
				{
					num = 0;
					num2++;
				}
				else
				{
					num++;
				}
				if ((array[num2] & (1 << num)) == 1 << num)
				{
					arrayList.Add(@enum);
				}
			}
			return (Enum778[])arrayList.ToArray(typeof(Enum778));
		}

		public static long[] smethod_2(Enum778[] rangeSet)
		{
			long[] array = new long[4];
			foreach (Enum778 @enum in rangeSet)
			{
				int num = (int)@enum / 32;
				long num2 = 1 << (int)@enum % 32;
				array[num] |= num2;
			}
			return array;
		}
	}

	public enum Enum778
	{
		const_0,
		const_1,
		const_2,
		const_3,
		const_4,
		const_5,
		const_6,
		const_7,
		const_8,
		const_9,
		const_10,
		const_11,
		const_12,
		const_13,
		const_14,
		const_15,
		const_16,
		const_17,
		const_18,
		const_19,
		const_20,
		const_21,
		const_22,
		const_23,
		const_24,
		const_25,
		const_26,
		const_27,
		const_28,
		const_29,
		const_30,
		const_31,
		const_32,
		const_33,
		const_34,
		const_35,
		const_36,
		const_37,
		const_38,
		const_39,
		const_40,
		const_41,
		const_42,
		const_43,
		const_44,
		const_45,
		const_46,
		const_47,
		const_48,
		const_49,
		const_50,
		const_51,
		const_52,
		const_53,
		const_54,
		const_55,
		const_56,
		const_57,
		const_58,
		const_59,
		const_60,
		const_61,
		const_62,
		const_63
	}

	private Class6036(Class6110 header, Class6016 data)
		: base(header, data)
	{
	}

	public int method_12()
	{
		return class6016_0.method_16(0);
	}

	public int method_13()
	{
		return class6016_0.method_17(2);
	}

	public int method_14()
	{
		return class6016_0.method_16(4);
	}

	public int method_15()
	{
		return class6016_0.method_16(6);
	}

	public Enum775[] method_16()
	{
		return Class6106.smethod_1(method_17());
	}

	public int method_17()
	{
		return class6016_0.method_16(8);
	}

	public int method_18()
	{
		return class6016_0.method_17(10);
	}

	public int method_19()
	{
		return class6016_0.method_17(12);
	}

	public int method_20()
	{
		return class6016_0.method_17(14);
	}

	public int method_21()
	{
		return class6016_0.method_17(16);
	}

	public int method_22()
	{
		return class6016_0.method_17(18);
	}

	public int method_23()
	{
		return class6016_0.method_17(20);
	}

	public int method_24()
	{
		return class6016_0.method_17(22);
	}

	public int method_25()
	{
		return class6016_0.method_17(24);
	}

	public int method_26()
	{
		return class6016_0.method_17(26);
	}

	public int method_27()
	{
		return class6016_0.method_17(28);
	}

	public int method_28()
	{
		return class6016_0.method_17(30);
	}

	public byte[] method_29()
	{
		byte[] array = new byte[10];
		class6016_0.method_14(32, array, 0, array.Length);
		return array;
	}

	public long method_30()
	{
		return class6016_0.method_19(42);
	}

	public long method_31()
	{
		return class6016_0.method_19(46);
	}

	public long method_32()
	{
		return class6016_0.method_19(50);
	}

	public long method_33()
	{
		return class6016_0.method_19(54);
	}

	public Enum776[] method_34()
	{
		return Class6107.smethod_1(method_30(), method_31(), method_32(), method_33());
	}

	public byte[] method_35()
	{
		byte[] array = new byte[4];
		class6016_0.method_14(58, array, 0, array.Length);
		return array;
	}

	public int method_36()
	{
		return class6016_0.method_16(62);
	}

	public Enum777[] method_37()
	{
		return Class6108.smethod_1(method_36());
	}

	public int method_38()
	{
		return class6016_0.method_16(64);
	}

	public int method_39()
	{
		return class6016_0.method_16(66);
	}

	public int method_40()
	{
		return class6016_0.method_17(68);
	}

	public int method_41()
	{
		return class6016_0.method_17(70);
	}

	public int method_42()
	{
		return class6016_0.method_17(72);
	}

	public int method_43()
	{
		return class6016_0.method_16(74);
	}

	public int method_44()
	{
		return class6016_0.method_16(76);
	}

	public long method_45()
	{
		return class6016_0.method_19(78);
	}

	public long method_46()
	{
		return class6016_0.method_19(82);
	}

	public Enum778[] method_47()
	{
		return Class6109.smethod_1(method_45(), method_45());
	}

	public int method_48()
	{
		return class6016_0.method_17(86);
	}

	public int method_49()
	{
		return class6016_0.method_17(88);
	}

	public int method_50()
	{
		return class6016_0.method_16(90);
	}

	public int method_51()
	{
		return class6016_0.method_16(92);
	}

	public int method_52()
	{
		return class6016_0.method_16(94);
	}
}
