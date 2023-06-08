using System.Collections;
using ns226;
using ns229;

namespace ns230;

internal class Class6031 : Class6026
{
	internal class Class6060 : Class6056
	{
		private bool bool_3;

		private long long_0;

		public static Class6060 smethod_1(Class6110 header, Class6017 data)
		{
			return new Class6060(header, data);
		}

		protected Class6060(Class6110 header, Class6017 data)
			: base(header, data)
		{
			data.method_11(new int[3] { 0, 8, 12 });
		}

		protected Class6060(Class6110 header, Class6016 data)
			: base(header, data)
		{
			data.method_11(int_0);
		}

		internal override bool vmethod_3()
		{
			if (method_9())
			{
				Class6016 @class = method_6();
				@class.method_11(int_0);
			}
			if (bool_3)
			{
				Class6016 class2 = method_6();
				class2.method_11(int_0);
				long adjustment = Class6031.long_0 - (long_0 + class2.method_8());
				method_25(adjustment);
			}
			return base.vmethod_3();
		}

		protected override Class6025 vmethod_6(Class6016 data)
		{
			return new Class6031(method_16(), data);
		}

		public void method_18(long checksum)
		{
			if (!bool_3)
			{
				bool_3 = true;
				long_0 = checksum;
			}
		}

		public void method_19()
		{
			bool_3 = false;
		}

		public int method_20()
		{
			return ((Class6031)method_17()).method_12();
		}

		public void method_21(int version)
		{
			method_7().method_44(0, version);
		}

		public int method_22()
		{
			return ((Class6031)method_17()).method_13();
		}

		public void method_23(int revision)
		{
			method_7().method_44(4, revision);
		}

		public long method_24()
		{
			return ((Class6031)method_17()).method_14();
		}

		public void method_25(long adjustment)
		{
			method_7().method_41(8, adjustment);
		}

		public long method_26()
		{
			return ((Class6031)method_17()).method_15();
		}

		public void method_27(long magicNumber)
		{
			method_7().method_41(12, magicNumber);
		}

		public int method_28()
		{
			return ((Class6031)method_17()).method_16();
		}

		public Enum759[] method_29()
		{
			return ((Class6031)method_17()).method_17();
		}

		public void method_30(int flags)
		{
			method_7().method_37(16, flags);
		}

		public void method_31(Enum759[] flags)
		{
			method_30(Class6099.smethod_3(flags));
		}

		public int method_32()
		{
			return ((Class6031)method_17()).method_18();
		}

		public void method_33(int units)
		{
			method_7().method_37(18, units);
		}

		public long method_34()
		{
			return ((Class6031)method_17()).method_19();
		}

		public void method_35(long date)
		{
			method_7().method_45(20, date);
		}

		public long method_36()
		{
			return ((Class6031)method_17()).method_20();
		}

		public void method_37(long date)
		{
			method_7().method_45(28, date);
		}

		public int method_38()
		{
			return ((Class6031)method_17()).method_21();
		}

		public void method_39(int xmin)
		{
			method_7().method_39(36, xmin);
		}

		public int method_40()
		{
			return ((Class6031)method_17()).method_22();
		}

		public void method_41(int ymin)
		{
			method_7().method_39(38, ymin);
		}

		public int method_42()
		{
			return ((Class6031)method_17()).method_23();
		}

		public void method_43(int xmax)
		{
			method_7().method_39(40, xmax);
		}

		public int method_44()
		{
			return ((Class6031)method_17()).method_24();
		}

		public void method_45(int ymax)
		{
			method_7().method_39(42, ymax);
		}

		public int method_46()
		{
			return ((Class6031)method_17()).method_25();
		}

		public void method_47(int style)
		{
			method_7().method_37(44, style);
		}

		public Enum760[] method_48()
		{
			return ((Class6031)method_17()).method_26();
		}

		public void method_49(Enum760[] style)
		{
			method_47(Class6100.smethod_3(style));
		}

		public int method_50()
		{
			return ((Class6031)method_17()).method_27();
		}

		public void method_51(int size)
		{
			method_7().method_37(46, size);
		}

		public int method_52()
		{
			return ((Class6031)method_17()).method_28();
		}

		public void method_53(int hint)
		{
			method_7().method_39(48, hint);
		}

		public Enum761 method_54()
		{
			return ((Class6031)method_17()).method_29();
		}

		public void method_55(Enum761 hint)
		{
			method_53((int)hint);
		}

		public int method_56()
		{
			return ((Class6031)method_17()).method_30();
		}

		public void method_57(int format)
		{
			method_7().method_39(50, format);
		}

		public Enum762 method_58()
		{
			return ((Class6031)method_17()).method_31();
		}

		public void method_59(Enum762 format)
		{
			method_57((int)format);
		}

		public int method_60()
		{
			return ((Class6031)method_17()).method_32();
		}

		public void method_61(int format)
		{
			method_7().method_39(52, format);
		}
	}

	public enum Enum762
	{
		const_0,
		const_1
	}

	private enum Enum758
	{
		const_0 = 0,
		const_1 = 4,
		const_2 = 8,
		const_3 = 12,
		const_4 = 16,
		const_5 = 18,
		const_6 = 20,
		const_7 = 28,
		const_8 = 36,
		const_9 = 38,
		const_10 = 40,
		const_11 = 42,
		const_12 = 44,
		const_13 = 46,
		const_14 = 48,
		const_15 = 50,
		const_16 = 52
	}

	internal class Class6099
	{
		private static Enum759[] enum759_0 = new Enum759[16]
		{
			Enum759.const_0,
			Enum759.const_1,
			Enum759.const_2,
			Enum759.const_3,
			Enum759.const_4,
			Enum759.const_5,
			Enum759.const_6,
			Enum759.const_7,
			Enum759.const_8,
			Enum759.const_9,
			Enum759.const_10,
			Enum759.const_11,
			Enum759.const_12,
			Enum759.const_13,
			Enum759.const_14,
			Enum759.const_15
		};

		public static int smethod_0(Enum759 flag)
		{
			return 1 << (int)flag;
		}

		public static Enum759[] smethod_1(int value)
		{
			ArrayList arrayList = new ArrayList();
			Enum759[] array = enum759_0;
			foreach (Enum759 @enum in array)
			{
				if ((value & smethod_0(@enum)) == smethod_0(@enum))
				{
					arrayList.Add(@enum);
				}
			}
			return (Enum759[])arrayList.ToArray(typeof(Enum759));
		}

		public static int smethod_2(Enum759[] set)
		{
			int num = 0;
			foreach (Enum759 flag in set)
			{
				num |= smethod_0(flag);
			}
			return num;
		}

		public static int smethod_3(Enum759[] set)
		{
			ArrayList arrayList = new ArrayList();
			foreach (Enum759 @enum in set)
			{
				arrayList.Add(@enum);
			}
			arrayList.Remove(Enum759.const_14);
			arrayList.Remove(Enum759.const_15);
			return smethod_2((Enum759[])arrayList.ToArray(typeof(Enum759)));
		}
	}

	public enum Enum759
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

	internal class Class6100
	{
		private static Enum760[] enum760_0 = new Enum760[16]
		{
			Enum760.const_0,
			Enum760.const_1,
			Enum760.const_2,
			Enum760.const_3,
			Enum760.const_4,
			Enum760.const_5,
			Enum760.const_6,
			Enum760.const_7,
			Enum760.const_8,
			Enum760.const_9,
			Enum760.const_10,
			Enum760.const_11,
			Enum760.const_12,
			Enum760.const_13,
			Enum760.const_14,
			Enum760.const_15
		};

		public static int smethod_0(Enum760 flag)
		{
			return 1 << (int)flag;
		}

		public static Enum760[] smethod_1(int value)
		{
			ArrayList arrayList = new ArrayList();
			Enum760[] array = enum760_0;
			foreach (Enum760 @enum in array)
			{
				if ((value & smethod_0(@enum)) == smethod_0(@enum))
				{
					arrayList.Add(@enum);
				}
			}
			return (Enum760[])arrayList.ToArray(typeof(Enum760));
		}

		public static int smethod_2(Enum760[] set)
		{
			int num = 0;
			foreach (Enum760 flag in set)
			{
				num |= smethod_0(flag);
			}
			return num;
		}

		public static int smethod_3(Enum760[] set)
		{
			ArrayList arrayList = new ArrayList();
			foreach (Enum760 @enum in set)
			{
				arrayList.Add(@enum);
			}
			for (int j = 7; j < enum760_0.Length; j++)
			{
				arrayList.Remove(enum760_0[j]);
			}
			return smethod_2((Enum760[])arrayList.ToArray(typeof(Enum760)));
		}
	}

	public enum Enum760
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

	public enum Enum761
	{
		const_0 = 0,
		const_1 = 1,
		const_2 = 2,
		const_3 = -1,
		const_4 = -2
	}

	public static long long_0 = 2981146554L;

	public static long long_1 = 1594834165L;

	private static int[] int_0 = new int[3] { 0, 8, 12 };

	private Class6031(Class6110 header, Class6016 data)
		: base(header, data)
	{
		data.method_11(new int[3] { 0, 8, 12 });
	}

	public int method_12()
	{
		return class6016_0.method_23(0);
	}

	public int method_13()
	{
		return class6016_0.method_23(4);
	}

	public long method_14()
	{
		return class6016_0.method_19(8);
	}

	public long method_15()
	{
		return class6016_0.method_19(12);
	}

	public int method_16()
	{
		return class6016_0.method_16(16);
	}

	public Enum759[] method_17()
	{
		return Class6099.smethod_1(method_16());
	}

	public int method_18()
	{
		return class6016_0.method_16(18);
	}

	public long method_19()
	{
		return class6016_0.method_24(20);
	}

	public long method_20()
	{
		return class6016_0.method_24(28);
	}

	public int method_21()
	{
		return class6016_0.method_16(36);
	}

	public int method_22()
	{
		return class6016_0.method_16(38);
	}

	public int method_23()
	{
		return class6016_0.method_16(40);
	}

	public int method_24()
	{
		return class6016_0.method_16(42);
	}

	public int method_25()
	{
		return class6016_0.method_16(44);
	}

	public Enum760[] method_26()
	{
		return Class6100.smethod_1(method_25());
	}

	public int method_27()
	{
		return class6016_0.method_16(46);
	}

	public int method_28()
	{
		return class6016_0.method_17(48);
	}

	public Enum761 method_29()
	{
		return (Enum761)method_28();
	}

	public int method_30()
	{
		return class6016_0.method_17(50);
	}

	public Enum762 method_31()
	{
		return (Enum762)method_30();
	}

	public int method_32()
	{
		return class6016_0.method_17(52);
	}
}
