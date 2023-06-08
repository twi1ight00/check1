using System.Drawing;

namespace ns15;

internal class Class203
{
	public struct Struct15
	{
		public ushort ushort_0;

		public short short_0;

		public short short_1;

		public short short_2;

		public Struct15(ushort flags, short data1, short data2, short data3)
		{
			ushort_0 = flags;
			short_0 = data1;
			short_1 = data2;
			short_2 = data3;
		}
	}

	public struct Struct16
	{
		public Point point_0;

		public Point point_1;

		public Struct16(Point orig, int width, int height)
		{
			point_0 = orig;
			point_1 = new Point(orig.X + width, orig.Y + height);
		}

		public Struct16(Point p1, Point p2)
		{
			point_0 = p1;
			point_1 = p2;
		}

		public Struct16(int x1, int y1, int x2, int y2)
		{
			point_0 = new Point(x1, y1);
			point_1 = new Point(x2, y2);
		}
	}

	protected enum Enum19 : short
	{
		const_0 = 320,
		const_1 = 321,
		const_2 = 322,
		const_3 = 323,
		const_4 = 327,
		const_5 = 328,
		const_6 = 329,
		const_7 = 330,
		const_8 = 331,
		const_9 = 332,
		const_10 = 333,
		const_11 = 334,
		const_12 = 335,
		const_13 = 336
	}

	internal const int int_0 = int.MinValue;

	protected static Struct16[] struct16_0 = new Struct16[1]
	{
		new Struct16(0, 0, 21600, 21600)
	};

	private int int_1;

	private int int_2;

	private int[] int_3;

	public Point[] point_0;

	public ushort[] ushort_0;

	public Struct15[] struct15_0;

	public Struct16[] struct16_1;

	public Point[] point_1;

	public Enum17[] enum17_0;

	protected static readonly int[] int_4;

	protected static readonly int[] int_5;

	protected static readonly int[] int_6;

	protected static readonly int[] int_7;

	protected static readonly int[] int_8;

	protected static readonly int[] int_9;

	protected static readonly int[] int_10;

	protected static readonly int[] int_11;

	protected static readonly int[] int_12;

	protected static readonly int[] int_13;

	protected static readonly int[] int_14;

	protected static readonly int[] int_15;

	protected static readonly Point[] point_2;

	protected static readonly Point[] point_3;

	protected static readonly Point[] point_4;

	protected static readonly ushort[] ushort_1;

	protected static readonly Struct16[] struct16_2;

	protected static readonly Struct15[] struct15_1;

	protected static readonly Point[] point_5;

	protected static readonly Class204 class204_0;

	protected static readonly Class204 class204_1;

	protected static readonly Struct15[] struct15_2;

	protected static readonly Point[] point_6;

	protected static readonly ushort[] ushort_2;

	protected static readonly Struct16[] struct16_3;

	protected static readonly Class204 class204_2;

	protected static readonly Point[] point_7;

	protected static readonly ushort[] ushort_3;

	protected static readonly Struct16[] struct16_4;

	protected static readonly Point[] point_8;

	protected static readonly Class204 class204_3;

	protected static readonly Struct16[] struct16_5;

	protected static readonly Point[] point_9;

	protected static readonly Class204 class204_4;

	protected static readonly Point[] point_10;

	protected static readonly ushort[] ushort_4;

	protected static readonly Struct15[] struct15_3;

	protected static readonly Struct16[] struct16_6;

	protected static readonly Point[] point_11;

	protected static readonly Class204 class204_5;

	protected static readonly Point[] point_12;

	protected static readonly ushort[] ushort_5;

	protected static readonly Struct16[] struct16_7;

	protected static readonly Class204 class204_6;

	protected static readonly Point[] point_13;

	protected static readonly ushort[] ushort_6;

	protected static readonly Struct15[] struct15_4;

	protected static readonly Struct16[] struct16_8;

	protected static readonly Point[] point_14;

	protected static readonly Class204 class204_7;

	protected static readonly Point[] point_15;

	protected static readonly ushort[] ushort_7;

	protected static readonly Struct15[] struct15_5;

	protected static readonly int[] int_16;

	protected static readonly Struct16[] struct16_9;

	protected static readonly Class204 class204_8;

	protected static readonly Point[] point_16;

	protected static readonly ushort[] ushort_8;

	protected static readonly Struct15[] struct15_6;

	protected static readonly Struct16[] struct16_10;

	protected static readonly Point[] point_17;

	protected static readonly Class204 class204_9;

	protected static readonly Point[] point_18;

	protected static readonly ushort[] ushort_9;

	protected static readonly Struct15[] struct15_7;

	protected static readonly int[] int_17;

	protected static readonly Struct16[] struct16_11;

	protected static readonly Class204 class204_10;

	protected static readonly Point[] point_19;

	protected static readonly ushort[] ushort_10;

	protected static readonly Struct16[] struct16_12;

	protected static readonly Point[] point_20;

	protected static readonly Class204 class204_11;

	protected static readonly Point[] point_21;

	protected static readonly ushort[] ushort_11;

	protected static readonly Struct15[] struct15_8;

	protected static readonly Struct16[] struct16_13;

	protected static readonly Class204 class204_12;

	protected static readonly Point[] point_22;

	protected static readonly ushort[] ushort_12;

	protected static readonly Struct15[] struct15_9;

	protected static readonly int[] int_18;

	protected static readonly Struct16[] struct16_14;

	protected static readonly Point[] point_23;

	protected static readonly Class204 class204_13;

	protected static readonly Point[] point_24;

	protected static readonly ushort[] ushort_13;

	protected static readonly Struct15[] struct15_10;

	protected static readonly Struct16[] struct16_15;

	protected static readonly Point[] point_25;

	protected static readonly Class204 class204_14;

	protected static readonly Point[] point_26;

	protected static readonly ushort[] ushort_14;

	protected static readonly int[] int_19;

	protected static readonly Struct16[] struct16_16;

	protected static readonly Class204 class204_15;

	protected static readonly Point[] point_27;

	protected static readonly ushort[] ushort_15;

	protected static readonly Struct16[] struct16_17;

	protected static readonly Point[] point_28;

	protected static readonly Class204 class204_16;

	protected static readonly Point[] point_29;

	protected static readonly ushort[] ushort_16;

	protected static readonly int[] int_20;

	protected static readonly Struct16[] struct16_18;

	protected static readonly Class204 class204_17;

	protected static readonly Point[] point_30;

	protected static readonly ushort[] ushort_17;

	protected static readonly Struct15[] struct15_11;

	protected static readonly int[] int_21;

	protected static readonly Struct16[] struct16_19;

	protected static readonly Point[] point_31;

	protected static readonly Class204 class204_18;

	protected static readonly Point[] point_32;

	protected static readonly ushort[] ushort_18;

	protected static readonly int[] int_22;

	protected static readonly Struct16[] struct16_20;

	protected static readonly Point[] point_33;

	protected static readonly Class204 class204_19;

	protected static readonly Point[] point_34;

	protected static readonly ushort[] ushort_19;

	protected static readonly Struct15[] struct15_12;

	protected static readonly int[] int_23;

	protected static readonly Struct16[] struct16_21;

	protected static readonly Class204 class204_20;

	protected static readonly Point[] point_35;

	protected static readonly ushort[] ushort_20;

	protected static readonly Struct15[] struct15_13;

	protected static readonly int[] int_24;

	protected static readonly Struct16[] struct16_22;

	protected static readonly Point[] point_36;

	protected static readonly Class204 class204_21;

	protected static readonly Point[] point_37;

	protected static readonly ushort[] ushort_21;

	protected static readonly Struct15[] struct15_14;

	protected static readonly int[] int_25;

	protected static readonly Struct16[] struct16_23;

	protected static readonly Point[] point_38;

	protected static readonly Enum17[] enum17_1;

	protected static readonly Class204 class204_22;

	protected static readonly Point[] point_39;

	protected static readonly ushort[] ushort_22;

	protected static readonly Struct16[] struct16_24;

	protected static readonly Point[] point_40;

	protected static readonly Enum17[] enum17_2;

	protected static readonly Class204 class204_23;

	protected static readonly Point[] point_41;

	protected static readonly ushort[] ushort_23;

	protected static readonly Struct15[] struct15_15;

	protected static readonly int[] int_26;

	protected static readonly Struct16[] struct16_25;

	protected static readonly Point[] point_42;

	protected static readonly Enum17[] enum17_3;

	protected static readonly Class204 class204_24;

	protected static readonly Point[] point_43;

	protected static readonly ushort[] ushort_24;

	protected static readonly Struct15[] struct15_16;

	protected static readonly int[] int_27;

	protected static readonly Struct16[] struct16_26;

	protected static readonly Point[] point_44;

	protected static readonly Enum17[] enum17_4;

	protected static readonly Class204 class204_25;

	protected static readonly Point[] point_45;

	protected static readonly ushort[] ushort_25;

	protected static readonly Struct15[] struct15_17;

	protected static readonly int[] int_28;

	protected static readonly Struct16[] struct16_27;

	protected static readonly Point[] point_46;

	protected static readonly Class204 class204_26;

	protected static readonly Point[] point_47;

	protected static readonly ushort[] ushort_26;

	protected static readonly Struct15[] struct15_18;

	protected static readonly int[] int_29;

	protected static readonly Point[] point_48;

	protected static readonly Class204 class204_27;

	protected static readonly Point[] point_49;

	protected static readonly ushort[] ushort_27;

	protected static readonly Struct16[] struct16_28;

	protected static readonly Point[] point_50;

	protected static readonly Class204 class204_28;

	protected static readonly Point[] point_51;

	protected static readonly ushort[] ushort_28;

	protected static readonly Point[] point_52;

	protected static readonly Class204 class204_29;

	protected static readonly Point[] point_53;

	protected static readonly ushort[] ushort_29;

	protected static readonly Struct15[] struct15_19;

	protected static readonly Struct16[] struct16_29;

	protected static readonly Point[] point_54;

	internal static readonly Class204 class204_30;

	protected static readonly Point[] point_55;

	protected static readonly ushort[] ushort_30;

	protected static readonly Struct15[] struct15_20;

	protected static readonly Struct16[] struct16_30;

	protected static readonly Point[] point_56;

	protected static readonly Class204 class204_31;

	protected static readonly Point[] point_57;

	protected static readonly ushort[] ushort_31;

	protected static readonly Struct15[] struct15_21;

	protected static readonly int[] int_30;

	protected static readonly Struct16[] struct16_31;

	protected static readonly Point[] point_58;

	protected static readonly Class204 class204_32;

	protected static readonly Point[] point_59;

	protected static readonly ushort[] ushort_32;

	protected static readonly Struct15[] struct15_22;

	protected static readonly int[] int_31;

	protected static readonly Struct16[] struct16_32;

	protected static readonly Point[] point_60;

	protected static readonly Class204 class204_33;

	protected static readonly Point[] point_61;

	protected static readonly ushort[] ushort_33;

	protected static readonly Struct15[] struct15_23;

	protected static readonly int[] int_32;

	protected static readonly Struct16[] struct16_33;

	protected static readonly Point[] point_62;

	protected static readonly Class204 class204_34;

	protected static readonly Point[] point_63;

	protected static readonly ushort[] ushort_34;

	protected static readonly Struct15[] struct15_24;

	protected static readonly Struct16[] struct16_34;

	protected static readonly Class204 class204_35;

	protected static readonly Point[] point_64;

	protected static readonly ushort[] ushort_35;

	protected static readonly Struct15[] struct15_25;

	protected static readonly Struct16[] struct16_35;

	protected static readonly Class204 class204_36;

	protected static readonly Point[] point_65;

	protected static readonly ushort[] ushort_36;

	protected static readonly Struct15[] struct15_26;

	protected static readonly int[] int_33;

	protected static readonly Struct16[] struct16_36;

	protected static readonly Class204 class204_37;

	protected static readonly Point[] point_66;

	protected static readonly ushort[] ushort_37;

	protected static readonly Struct15[] struct15_27;

	protected static readonly Class204 class204_38;

	protected static readonly Struct16[] struct16_37;

	protected static readonly Point[] point_67;

	protected static readonly ushort[] ushort_38;

	protected static readonly Struct15[] struct15_28;

	protected static readonly Class204 class204_39;

	protected static readonly Point[] point_68;

	protected static readonly ushort[] ushort_39;

	protected static readonly Struct15[] struct15_29;

	protected static readonly Class204 class204_40;

	protected static readonly Point[] point_69;

	protected static readonly ushort[] ushort_40;

	protected static readonly Struct15[] struct15_30;

	protected static readonly Class204 class204_41;

	protected static readonly Point[] point_70;

	protected static readonly ushort[] ushort_41;

	protected static readonly Struct15[] struct15_31;

	protected static readonly Class204 class204_42;

	protected static readonly Point[] point_71;

	protected static readonly Class204 class204_43;

	protected static readonly Point[] point_72;

	protected static readonly ushort[] ushort_42;

	protected static readonly Struct15[] struct15_32;

	protected static readonly Class204 class204_44;

	protected static readonly Point[] point_73;

	protected static readonly Class204 class204_45;

	protected static readonly Point[] point_74;

	protected static readonly ushort[] ushort_43;

	protected static readonly Struct15[] struct15_33;

	protected static readonly Class204 class204_46;

	protected static readonly Point[] point_75;

	protected static readonly ushort[] ushort_44;

	protected static readonly Struct15[] struct15_34;

	protected static readonly Class204 class204_47;

	protected static readonly Point[] point_76;

	protected static readonly ushort[] ushort_45;

	protected static readonly Struct15[] struct15_35;

	protected static readonly Class204 class204_48;

	protected static readonly Point[] point_77;

	protected static readonly ushort[] ushort_46;

	protected static readonly Struct15[] struct15_36;

	protected static readonly Class204 class204_49;

	public int Width
	{
		get
		{
			return int_1;
		}
		set
		{
			int_1 = value;
		}
	}

	public int Height
	{
		get
		{
			return int_2;
		}
		set
		{
			int_2 = value;
		}
	}

	public int[] DefData
	{
		get
		{
			return int_3;
		}
		set
		{
			int_3 = value;
		}
	}

	static Class203()
	{
		int[] array = new int[1];
		int_4 = array;
		int_5 = new int[1] { 1400 };
		int_6 = new int[1] { 1800 };
		int_7 = new int[1] { 2500 };
		int_8 = new int[1] { 2700 };
		int_9 = new int[1] { 3600 };
		int_10 = new int[1] { 3700 };
		int_11 = new int[1] { 5400 };
		int_12 = new int[1] { 8100 };
		int_13 = new int[1] { 10800 };
		int_14 = new int[2] { 16200, 5400 };
		int_15 = new int[2] { 17694720, 0 };
		point_2 = new Point[4]
		{
			new Point(10800, 0),
			new Point(0, 10800),
			new Point(10800, 21600),
			new Point(21600, 10800)
		};
		point_3 = new Point[0];
		point_4 = new Point[10]
		{
			new Point(0, 0),
			new Point(21600, 21600),
			new Point(int.MinValue, -2147483647),
			new Point(-2147483646, -2147483645),
			new Point(10800, 10800),
			new Point(int.MinValue, -2147483647),
			new Point(0, 0),
			new Point(21600, 21600),
			new Point(int.MinValue, -2147483647),
			new Point(-2147483646, -2147483645)
		};
		ushort_1 = new ushort[6] { 42244, 2, 24576, 32788, 42244, 32768 };
		struct16_2 = new Struct16[1]
		{
			new Struct16(-2147483632, -2147483632, -2147483631, -2147483630)
		};
		struct15_1 = new Struct15[8]
		{
			new Struct15(16384, 10800, 1028, 0),
			new Struct15(16384, 10800, 1029, 0),
			new Struct15(16384, 10800, 1030, 0),
			new Struct15(16384, 10800, 1031, 0),
			new Struct15(16394, 10800, 327, 0),
			new Struct15(16393, 10800, 327, 0),
			new Struct15(16394, 10800, 328, 0),
			new Struct15(16393, 10800, 328, 0)
		};
		point_5 = new Point[3]
		{
			new Point(int.MinValue, -2147483647),
			new Point(-2147483646, -2147483645),
			new Point(10800, 10800)
		};
		class204_0 = new Class204(point_4, ushort_1, struct15_1, int_15, null, 21600, 21600, int.MinValue, int.MinValue, point_5);
		class204_1 = new Class204(null, null, null, null, null, 21600, 21600, int.MinValue, int.MinValue, point_2);
		struct15_2 = new Struct15[21]
		{
			new Struct15(24576, 320, 327, 0),
			new Struct15(24576, 321, 327, 0),
			new Struct15(40960, 323, 0, 327),
			new Struct15(40960, 322, 0, 327),
			new Struct15(8322, 327, 0, 450),
			new Struct15(8192, 1028, 0, 10800),
			new Struct15(32768, 0, 0, 327),
			new Struct15(40960, 1030, 0, 1029),
			new Struct15(40960, 320, 0, 1031),
			new Struct15(40960, 321, 0, 1031),
			new Struct15(24576, 322, 1031, 0),
			new Struct15(24576, 323, 1031, 0),
			new Struct15(40960, 320, 0, 1029),
			new Struct15(40960, 321, 0, 1029),
			new Struct15(24576, 322, 1029, 0),
			new Struct15(24576, 323, 1029, 0),
			new Struct15(8193, 327, 3, 10),
			new Struct15(24576, 320, 1040, 0),
			new Struct15(24576, 321, 1040, 0),
			new Struct15(40960, 322, 0, 1040),
			new Struct15(40960, 323, 0, 1040)
		};
		point_6 = new Point[8]
		{
			new Point(int.MinValue, 0),
			new Point(0, -2147483647),
			new Point(0, -2147483646),
			new Point(int.MinValue, 21600),
			new Point(-2147483645, 21600),
			new Point(21600, -2147483646),
			new Point(21600, -2147483647),
			new Point(-2147483645, 0)
		};
		ushort_2 = new ushort[9] { 42753, 1, 43009, 1, 42753, 1, 43009, 24576, 32772 };
		struct16_3 = new Struct16[1]
		{
			new Struct16(-2147483631, -2147483630, -2147483629, -2147483628)
		};
		class204_2 = new Class204(point_6, ushort_2, struct15_2, int_9, struct16_3, 21600, 21600, int.MinValue, int.MinValue, point_2);
		point_7 = new Point[4]
		{
			new Point(0, 0),
			new Point(21600, 21600),
			new Point(0, 21600),
			new Point(0, 0)
		};
		ushort_3 = new ushort[3] { 3, 24576, 32772 };
		struct16_4 = new Struct16[1]
		{
			new Struct16(1900, 12700, 12700, 19700)
		};
		point_8 = new Point[6]
		{
			new Point(0, 0),
			new Point(0, 10800),
			new Point(0, 21600),
			new Point(10800, 21600),
			new Point(21600, 21600),
			new Point(10800, 10800)
		};
		class204_3 = new Class204(point_7, ushort_3, null, null, struct16_4, 21600, 21600, int.MinValue, int.MinValue, point_8);
		struct16_5 = new Struct16[1]
		{
			new Struct16(3200, 3200, 18400, 18400)
		};
		point_9 = new Point[8]
		{
			new Point(10800, 0),
			new Point(3160, 3160),
			new Point(0, 10800),
			new Point(3160, 18440),
			new Point(10800, 21600),
			new Point(18440, 18440),
			new Point(21600, 10800),
			new Point(18440, 3160)
		};
		class204_4 = new Class204(null, null, null, null, struct16_5, 21600, 21600, int.MinValue, int.MinValue, point_9);
		point_10 = new Point[4]
		{
			new Point(int.MinValue, 0),
			new Point(21600, 0),
			new Point(-2147483647, 21600),
			new Point(0, 21600)
		};
		ushort_4 = new ushort[3] { 3, 24576, 32772 };
		struct15_3 = new Struct15[14]
		{
			new Struct15(16384, 0, 327, 0),
			new Struct15(32768, 0, 21600, 327),
			new Struct15(8193, 327, 10, 24),
			new Struct15(8192, 1026, 1750, 0),
			new Struct15(32768, 21600, 0, 1027),
			new Struct15(8193, 1024, 1, 2),
			new Struct15(16384, 10800, 1029, 0),
			new Struct15(8192, 1024, 0, 10800),
			new Struct15(24582, 1031, 1037, 0),
			new Struct15(32768, 10800, 0, 1029),
			new Struct15(24582, 1031, 1036, 21600),
			new Struct15(32768, 21600, 0, 1029),
			new Struct15(32769, 21600, 10800, 1024),
			new Struct15(32768, 21600, 0, 1036)
		};
		struct16_6 = new Struct16[1]
		{
			new Struct16(-2147483645, -2147483645, -2147483644, -2147483644)
		};
		point_11 = new Point[6]
		{
			new Point(-2147483642, 0),
			new Point(10800, -2147483640),
			new Point(-2147483637, 10800),
			new Point(-2147483639, 21600),
			new Point(10800, -2147483638),
			new Point(-2147483643, 10800)
		};
		class204_5 = new Class204(point_10, ushort_4, struct15_3, int_11, struct16_6, 21600, 21600, int.MinValue, int.MinValue, point_11);
		point_12 = new Point[5]
		{
			new Point(10800, 0),
			new Point(21600, 10800),
			new Point(10800, 21600),
			new Point(0, 10800),
			new Point(10800, 0)
		};
		ushort_5 = new ushort[3] { 5, 24576, 32772 };
		struct16_7 = new Struct16[1]
		{
			new Struct16(5400, 5400, 16200, 16200)
		};
		class204_6 = new Class204(point_12, ushort_5, null, null, struct16_7, 21600, 21600, int.MinValue, int.MinValue, point_2);
		point_13 = new Point[4]
		{
			new Point(0, 0),
			new Point(21600, 0),
			new Point(int.MinValue, 21600),
			new Point(-2147483647, 21600)
		};
		ushort_6 = new ushort[3] { 3, 24576, 32772 };
		struct15_4 = new Struct15[7]
		{
			new Struct15(32768, 21600, 0, 327),
			new Struct15(8192, 327, 0, 0),
			new Struct15(8193, 327, 10, 18),
			new Struct15(8192, 1026, 1750, 0),
			new Struct15(32768, 21600, 0, 1027),
			new Struct15(8193, 327, 1, 2),
			new Struct15(32768, 21600, 0, 1029)
		};
		struct16_8 = new Struct16[1]
		{
			new Struct16(new Point(-2147483645, -2147483645), new Point(-2147483644, -2147483644))
		};
		point_14 = new Point[4]
		{
			new Point(-2147483642, 10800),
			new Point(10800, 21600),
			new Point(-2147483643, 10800),
			new Point(10800, 0)
		};
		class204_7 = new Class204(point_13, ushort_6, struct15_4, int_11, struct16_8, 21600, 21600, int.MinValue, int.MinValue, point_14);
		point_15 = new Point[8]
		{
			new Point(int.MinValue, 0),
			new Point(-2147483646, 0),
			new Point(21600, -2147483647),
			new Point(21600, -2147483645),
			new Point(-2147483646, 21600),
			new Point(int.MinValue, 21600),
			new Point(0, -2147483645),
			new Point(0, -2147483647)
		};
		ushort_7 = new ushort[3] { 7, 24576, 32772 };
		struct15_5 = new Struct15[9]
		{
			new Struct15(24576, 320, 327, 0),
			new Struct15(24576, 321, 327, 0),
			new Struct15(40960, 322, 0, 327),
			new Struct15(40960, 323, 0, 327),
			new Struct15(8193, 327, 1, 2),
			new Struct15(24576, 320, 1028, 0),
			new Struct15(24576, 321, 1028, 0),
			new Struct15(40960, 322, 0, 1028),
			new Struct15(40960, 323, 0, 1028)
		};
		int_16 = new int[1] { 6326 };
		struct16_9 = new Struct16[1]
		{
			new Struct16(new Point(-2147483643, -2147483642), new Point(-2147483641, -2147483640))
		};
		class204_8 = new Class204(point_15, ushort_7, struct15_5, int_16, struct16_9, 21600, 21600, int.MinValue, int.MinValue, point_2);
		point_16 = new Point[3]
		{
			new Point(int.MinValue, 0),
			new Point(21600, 21600),
			new Point(0, 21600)
		};
		ushort_8 = new ushort[3] { 2, 24576, 32772 };
		struct15_6 = new Struct15[8]
		{
			new Struct15(16384, 0, 327, 0),
			new Struct15(8193, 327, 1, 2),
			new Struct15(8192, 1025, 10800, 0),
			new Struct15(8193, 327, 2, 3),
			new Struct15(8192, 1027, 7200, 0),
			new Struct15(32768, 21600, 0, 1024),
			new Struct15(8193, 1029, 1, 2),
			new Struct15(32768, 21600, 0, 1030)
		};
		struct16_10 = new Struct16[2]
		{
			new Struct16(new Point(-2147483647, 10800), new Point(-2147483646, 18000)),
			new Struct16(new Point(-2147483645, 7200), new Point(-2147483644, 21600))
		};
		point_17 = new Point[6]
		{
			new Point(int.MinValue, 0),
			new Point(-2147483647, 10800),
			new Point(0, 21600),
			new Point(10800, 21600),
			new Point(21600, 21600),
			new Point(-2147483641, 10800)
		};
		class204_9 = new Class204(point_16, ushort_8, struct15_6, int_13, struct16_10, 21600, 21600, int.MinValue, int.MinValue, point_17);
		point_18 = new Point[6]
		{
			new Point(int.MinValue, 0),
			new Point(-2147483647, 0),
			new Point(21600, 10800),
			new Point(-2147483647, 21600),
			new Point(int.MinValue, 21600),
			new Point(0, 10800)
		};
		ushort_9 = new ushort[3] { 5, 24576, 32772 };
		struct15_7 = new Struct15[5]
		{
			new Struct15(8192, 327, 0, 0),
			new Struct15(32768, 21600, 0, 327),
			new Struct15(8193, 327, 100, 234),
			new Struct15(8192, 1026, 1700, 0),
			new Struct15(32768, 21600, 0, 1027)
		};
		int_17 = new int[2] { 6244, 24942 };
		struct16_11 = new Struct16[1]
		{
			new Struct16(new Point(-2147483645, -2147483645), new Point(-2147483644, -2147483644))
		};
		class204_10 = new Class204(point_18, ushort_9, struct15_7, int_17, struct16_11, 21600, 21600, int.MinValue, int.MinValue, point_2);
		point_19 = new Point[6]
		{
			new Point(10800, 0),
			new Point(0, 8260),
			new Point(4230, 21600),
			new Point(17370, 21600),
			new Point(21600, 8260),
			new Point(10800, 0)
		};
		ushort_10 = new ushort[3] { 5, 24576, 32772 };
		struct16_12 = new Struct16[1]
		{
			new Struct16(new Point(4230, 5080), new Point(17370, 21600))
		};
		point_20 = new Point[6]
		{
			new Point(10800, 0),
			new Point(0, 8260),
			new Point(4230, 21600),
			new Point(10800, 21600),
			new Point(17370, 21600),
			new Point(21600, 8260)
		};
		class204_11 = new Class204(point_19, ushort_10, null, null, struct16_12, 21600, 21600, int.MinValue, int.MinValue, point_20);
		point_21 = new Point[13]
		{
			new Point(-2147483647, 0),
			new Point(-2147483646, 0),
			new Point(-2147483646, -2147483647),
			new Point(21600, -2147483647),
			new Point(21600, -2147483646),
			new Point(-2147483646, -2147483646),
			new Point(-2147483646, 21600),
			new Point(-2147483647, 21600),
			new Point(-2147483647, -2147483646),
			new Point(0, -2147483646),
			new Point(0, -2147483647),
			new Point(-2147483647, -2147483647),
			new Point(-2147483647, 0)
		};
		ushort_11 = new ushort[3] { 12, 24576, 32772 };
		struct15_8 = new Struct15[3]
		{
			new Struct15(8193, 327, 10799, 10800),
			new Struct15(8192, 1024, 0, 0),
			new Struct15(32768, 21600, 0, 1024)
		};
		struct16_13 = new Struct16[1]
		{
			new Struct16(new Point(-2147483647, -2147483647), new Point(-2147483646, -2147483646))
		};
		class204_12 = new Class204(point_21, ushort_11, struct15_8, int_11, struct16_13, 21600, 21600, 10800, 10800, point_2);
		point_22 = new Point[28]
		{
			new Point(44, 0),
			new Point(20, 0),
			new Point(0, -2147483646),
			new Point(0, int.MinValue),
			new Point(0, -2147483645),
			new Point(0, -2147483644),
			new Point(20, 10800),
			new Point(44, 10800),
			new Point(68, 10800),
			new Point(88, -2147483644),
			new Point(88, -2147483645),
			new Point(88, int.MinValue),
			new Point(88, -2147483646),
			new Point(68, 0),
			new Point(44, 0),
			new Point(44, 0),
			new Point(20, 0),
			new Point(0, -2147483646),
			new Point(0, int.MinValue),
			new Point(0, -2147483643),
			new Point(20, -2147483642),
			new Point(44, -2147483642),
			new Point(68, -2147483642),
			new Point(88, -2147483643),
			new Point(88, int.MinValue),
			new Point(88, -2147483646),
			new Point(68, 0),
			new Point(44, 0)
		};
		ushort_12 = new ushort[10] { 8193, 1, 8194, 1, 8193, 24576, 32768, 8196, 24576, 33025 };
		struct15_9 = new Struct15[7]
		{
			new Struct15(8193, 327, 1, 4),
			new Struct15(8193, 1024, 6, 11),
			new Struct15(40960, 1024, 0, 1025),
			new Struct15(32768, 10800, 0, 1024),
			new Struct15(24576, 1027, 1025, 0),
			new Struct15(24576, 1024, 1025, 0),
			new Struct15(8193, 327, 1, 2)
		};
		int_18 = new int[1] { 7172 };
		struct16_14 = new Struct16[1]
		{
			new Struct16(new Point(0, -2147483642), new Point(88, -2147483645))
		};
		point_23 = new Point[5]
		{
			new Point(44, -2147483642),
			new Point(44, 0),
			new Point(0, 5400),
			new Point(44, 10800),
			new Point(88, 5400)
		};
		class204_13 = new Class204(point_22, ushort_12, struct15_9, int_18, struct16_14, 88, 10800, int.MinValue, int.MinValue, point_23);
		point_24 = new Point[7]
		{
			new Point(0, int.MinValue),
			new Point(-2147483647, int.MinValue),
			new Point(-2147483647, 0),
			new Point(21600, 10800),
			new Point(-2147483647, 21600),
			new Point(-2147483647, -2147483646),
			new Point(0, -2147483646)
		};
		ushort_13 = new ushort[3] { 6, 24576, 32768 };
		struct15_10 = new Struct15[13]
		{
			new Struct15(8192, 328, 0, 0),
			new Struct15(8192, 327, 0, 0),
			new Struct15(32768, 21600, 0, 328),
			new Struct15(32768, 21600, 0, 1025),
			new Struct15(24576, 1027, 1024, 10800),
			new Struct15(24576, 1025, 1028, 0),
			new Struct15(24576, 1025, 1024, 10800),
			new Struct15(40960, 1025, 0, 1030),
			new Struct15(24577, 1027, 1033, 10800),
			new Struct15(32768, 10800, 0, 1024),
			new Struct15(32768, 21600, 0, 1032),
			new Struct15(24577, 1024, 1025, 10800),
			new Struct15(40960, 1025, 0, 1035)
		};
		struct16_15 = new Struct16[1]
		{
			new Struct16(new Point(0, int.MinValue), new Point(-2147483638, -2147483646))
		};
		point_25 = new Point[4]
		{
			new Point(-2147483647, 0),
			new Point(0, 10800),
			new Point(-2147483647, 21600),
			new Point(21600, 10800)
		};
		class204_14 = new Class204(point_24, ushort_13, struct15_10, int_14, struct16_15, 21600, 21600, int.MinValue, int.MinValue, point_25);
		point_26 = new Point[7]
		{
			new Point(21600, int.MinValue),
			new Point(-2147483647, int.MinValue),
			new Point(-2147483647, 0),
			new Point(0, 10800),
			new Point(-2147483647, 21600),
			new Point(-2147483647, -2147483646),
			new Point(21600, -2147483646)
		};
		ushort_14 = new ushort[3] { 6, 24576, 32768 };
		int_19 = new int[2] { 5400, 5400 };
		struct16_16 = new Struct16[1]
		{
			new Struct16(new Point(-2147483636, int.MinValue), new Point(21600, -2147483646))
		};
		class204_15 = new Class204(point_26, ushort_14, struct15_10, int_19, struct16_16, 21600, 21600, int.MinValue, int.MinValue, point_25);
		point_27 = new Point[7]
		{
			new Point(int.MinValue, 0),
			new Point(int.MinValue, -2147483647),
			new Point(0, -2147483647),
			new Point(10800, 21600),
			new Point(21600, -2147483647),
			new Point(-2147483646, -2147483647),
			new Point(-2147483646, 0)
		};
		ushort_15 = new ushort[3] { 6, 24576, 32768 };
		struct16_17 = new Struct16[1]
		{
			new Struct16(new Point(int.MinValue, 0), new Point(-2147483646, -2147483638))
		};
		point_28 = new Point[4]
		{
			new Point(10800, 0),
			new Point(0, -2147483647),
			new Point(10800, 21600),
			new Point(21600, -2147483647)
		};
		class204_16 = new Class204(point_27, ushort_15, struct15_10, int_14, struct16_17, 21600, 21600, int.MinValue, int.MinValue, point_28);
		point_29 = new Point[7]
		{
			new Point(int.MinValue, 21600),
			new Point(int.MinValue, -2147483647),
			new Point(0, -2147483647),
			new Point(10800, 0),
			new Point(21600, -2147483647),
			new Point(-2147483646, -2147483647),
			new Point(-2147483646, 21600)
		};
		ushort_16 = new ushort[3] { 6, 24576, 32768 };
		int_20 = new int[2] { 5400, 5400 };
		struct16_18 = new Struct16[1]
		{
			new Struct16(new Point(int.MinValue, -2147483636), new Point(-2147483646, 21600))
		};
		class204_17 = new Class204(point_29, ushort_16, struct15_10, int_20, struct16_18, 21600, 21600, int.MinValue, int.MinValue, point_28);
		point_30 = new Point[10]
		{
			new Point(0, 10800),
			new Point(int.MinValue, 0),
			new Point(int.MinValue, -2147483647),
			new Point(-2147483646, -2147483647),
			new Point(-2147483646, 0),
			new Point(21600, 10800),
			new Point(-2147483646, 21600),
			new Point(-2147483646, -2147483645),
			new Point(int.MinValue, -2147483645),
			new Point(int.MinValue, 21600)
		};
		ushort_17 = new ushort[3] { 9, 24576, 32768 };
		struct15_11 = new Struct15[10]
		{
			new Struct15(8192, 327, 0, 0),
			new Struct15(8192, 328, 0, 0),
			new Struct15(32768, 21600, 0, 327),
			new Struct15(32768, 21600, 0, 328),
			new Struct15(32768, 10800, 0, 328),
			new Struct15(24576, 327, 1028, 10800),
			new Struct15(32768, 21600, 0, 1029),
			new Struct15(32768, 10800, 0, 327),
			new Struct15(24576, 328, 1031, 10800),
			new Struct15(32768, 21600, 0, 1032)
		};
		int_21 = new int[2] { 4300, 5400 };
		struct16_19 = new Struct16[1]
		{
			new Struct16(new Point(-2147483643, -2147483647), new Point(-2147483642, -2147483645))
		};
		point_31 = new Point[8]
		{
			new Point(-2147483646, 0),
			new Point(10800, -2147483647),
			new Point(int.MinValue, 0),
			new Point(0, 10800),
			new Point(int.MinValue, 21600),
			new Point(10800, -2147483645),
			new Point(-2147483646, 21600),
			new Point(21600, 10800)
		};
		class204_18 = new Class204(point_30, ushort_17, struct15_11, int_21, struct16_19, 21600, 21600, int.MinValue, int.MinValue, point_31);
		point_32 = new Point[10]
		{
			new Point(0, -2147483647),
			new Point(10800, 0),
			new Point(21600, -2147483647),
			new Point(-2147483646, -2147483647),
			new Point(-2147483646, -2147483645),
			new Point(21600, -2147483645),
			new Point(10800, 21600),
			new Point(0, -2147483645),
			new Point(int.MinValue, -2147483645),
			new Point(int.MinValue, -2147483647)
		};
		ushort_18 = new ushort[3] { 9, 24576, 32768 };
		int_22 = new int[2] { 5400, 4300 };
		struct16_20 = new Struct16[1]
		{
			new Struct16(new Point(int.MinValue, -2147483640), new Point(-2147483646, -2147483639))
		};
		point_33 = new Point[8]
		{
			new Point(10800, 0),
			new Point(0, -2147483647),
			new Point(int.MinValue, 10800),
			new Point(0, -2147483645),
			new Point(10800, 21600),
			new Point(21600, -2147483645),
			new Point(-2147483646, 10800),
			new Point(21600, -2147483647)
		};
		class204_19 = new Class204(point_32, ushort_18, struct15_11, int_22, struct16_20, 21600, 21600, int.MinValue, int.MinValue, point_33);
		point_34 = new Point[24]
		{
			new Point(0, 10800),
			new Point(int.MinValue, -2147483647),
			new Point(int.MinValue, -2147483646),
			new Point(-2147483646, -2147483646),
			new Point(-2147483646, int.MinValue),
			new Point(-2147483647, int.MinValue),
			new Point(10800, 0),
			new Point(-2147483645, int.MinValue),
			new Point(-2147483644, int.MinValue),
			new Point(-2147483644, -2147483646),
			new Point(-2147483643, -2147483646),
			new Point(-2147483643, -2147483647),
			new Point(21600, 10800),
			new Point(-2147483643, -2147483645),
			new Point(-2147483643, -2147483644),
			new Point(-2147483644, -2147483644),
			new Point(-2147483644, -2147483643),
			new Point(-2147483645, -2147483643),
			new Point(10800, 21600),
			new Point(-2147483647, -2147483643),
			new Point(-2147483646, -2147483643),
			new Point(-2147483646, -2147483644),
			new Point(int.MinValue, -2147483644),
			new Point(int.MinValue, -2147483645)
		};
		ushort_19 = new ushort[3] { 23, 24576, 32768 };
		struct15_12 = new Struct15[6]
		{
			new Struct15(8192, 329, 0, 0),
			new Struct15(8192, 327, 0, 0),
			new Struct15(8192, 328, 0, 0),
			new Struct15(32768, 21600, 0, 327),
			new Struct15(32768, 21600, 0, 328),
			new Struct15(32768, 21600, 0, 329)
		};
		int_23 = new int[3] { 6500, 8600, 4300 };
		struct16_21 = new Struct16[1]
		{
			new Struct16(int.MinValue, int.MinValue, -2147483643, -2147483643)
		};
		class204_20 = new Class204(point_34, ushort_19, struct15_12, int_23, struct16_21, 21600, 21600, int.MinValue, int.MinValue, point_2);
		point_35 = new Point[17]
		{
			new Point(0, 10800),
			new Point(int.MinValue, -2147483647),
			new Point(int.MinValue, -2147483646),
			new Point(-2147483646, -2147483646),
			new Point(-2147483646, int.MinValue),
			new Point(-2147483647, int.MinValue),
			new Point(10800, 0),
			new Point(-2147483645, int.MinValue),
			new Point(-2147483644, int.MinValue),
			new Point(-2147483644, -2147483646),
			new Point(-2147483643, -2147483646),
			new Point(-2147483643, -2147483647),
			new Point(21600, 10800),
			new Point(-2147483643, -2147483645),
			new Point(-2147483643, -2147483644),
			new Point(int.MinValue, -2147483644),
			new Point(int.MinValue, -2147483645)
		};
		ushort_20 = new ushort[3] { 16, 24576, 32768 };
		struct15_13 = new Struct15[6]
		{
			new Struct15(24577, 329, 1027, 21600),
			new Struct15(8192, 327, 0, 0),
			new Struct15(8192, 328, 0, 0),
			new Struct15(32768, 21600, 0, 327),
			new Struct15(32768, 21600, 0, 328),
			new Struct15(32768, 21600, 0, 1024)
		};
		int_24 = new int[3] { 6500, 8600, 6200 };
		struct16_22 = new Struct16[1]
		{
			new Struct16(int.MinValue, int.MinValue, -2147483643, -2147483644)
		};
		point_36 = new Point[4]
		{
			new Point(10800, 0),
			new Point(0, 10800),
			new Point(10800, -2147483644),
			new Point(21600, 10800)
		};
		class204_21 = new Class204(point_35, ushort_20, struct15_13, int_24, struct16_22, 21600, -2147483645, int.MinValue, int.MinValue, point_36);
		point_37 = new Point[11]
		{
			new Point(0, 21600),
			new Point(0, 12160),
			new Point(12427, -2147483647),
			new Point(int.MinValue, -2147483647),
			new Point(int.MinValue, 0),
			new Point(21600, 6079),
			new Point(int.MinValue, 12158),
			new Point(int.MinValue, -2147483646),
			new Point(12427, -2147483646),
			new Point(-2147483644, 12160),
			new Point(-2147483644, 21600)
		};
		ushort_21 = new ushort[7] { 1, 43009, 6, 42753, 1, 24576, 32768 };
		struct15_14 = new Struct15[9]
		{
			new Struct15(8192, 327, 0, 0),
			new Struct15(8192, 328, 0, 0),
			new Struct15(32768, 12158, 0, 328),
			new Struct15(32768, 6079, 0, 328),
			new Struct15(8193, 1027, 2, 1),
			new Struct15(32768, 21600, 0, 1030),
			new Struct15(24576, 1032, 1031, 6079),
			new Struct15(32768, 6079, 0, 328),
			new Struct15(32768, 21600, 0, 327)
		};
		int_25 = new int[2] { 15100, 2900 };
		struct16_23 = new Struct16[1]
		{
			new Struct16(12427, -2147483647, -2147483643, -2147483646)
		};
		point_38 = new Point[4]
		{
			new Point(int.MinValue, 0),
			new Point(int.MinValue, 12158),
			new Point(-2147483645, 21600),
			new Point(21600, 6079)
		};
		enum17_1 = new Enum17[4]
		{
			Enum17.const_2,
			Enum17.const_4,
			Enum17.const_4,
			Enum17.const_1
		};
		class204_22 = new Class204(point_37, ushort_21, struct15_14, int_25, struct16_23, 21600, 21600, int.MinValue, int.MinValue, point_38, enum17_1);
		point_39 = new Point[19]
		{
			new Point(0, 21600),
			new Point(0, 8550),
			new Point(0, 3540),
			new Point(4370, 0),
			new Point(9270, 0),
			new Point(13890, 0),
			new Point(18570, 3230),
			new Point(18600, 8300),
			new Point(21600, 8300),
			new Point(15680, 14260),
			new Point(9700, 8300),
			new Point(12500, 8300),
			new Point(12320, 6380),
			new Point(10870, 5850),
			new Point(9320, 5850),
			new Point(7770, 5850),
			new Point(6040, 6410),
			new Point(6110, 8520),
			new Point(6110, 21600)
		};
		ushort_22 = new ushort[7] { 1, 8194, 4, 8194, 1, 24576, 32768 };
		struct16_24 = new Struct16[1]
		{
			new Struct16(new Point(0, 8280), new Point(6110, 21600))
		};
		point_40 = new Point[5]
		{
			new Point(9270, 0),
			new Point(3055, 21600),
			new Point(9700, 8300),
			new Point(15680, 14260),
			new Point(21600, 8300)
		};
		enum17_2 = new Enum17[5]
		{
			Enum17.const_2,
			Enum17.const_4,
			Enum17.const_4,
			Enum17.const_4,
			Enum17.const_1
		};
		class204_23 = new Class204(point_39, ushort_22, null, null, struct16_24, 21600, 21600, int.MinValue, int.MinValue, point_40, enum17_2);
		point_41 = new Point[12]
		{
			new Point(0, -2147483643),
			new Point(-2147483646, int.MinValue),
			new Point(-2147483646, -2147483641),
			new Point(-2147483641, -2147483641),
			new Point(-2147483641, -2147483646),
			new Point(int.MinValue, -2147483646),
			new Point(-2147483643, 0),
			new Point(21600, -2147483646),
			new Point(-2147483647, -2147483646),
			new Point(-2147483647, -2147483647),
			new Point(-2147483646, -2147483647),
			new Point(-2147483646, 21600)
		};
		ushort_23 = new ushort[3] { 11, 24576, 32768 };
		struct15_15 = new Struct15[9]
		{
			new Struct15(8192, 327, 0, 0),
			new Struct15(8192, 328, 0, 0),
			new Struct15(8192, 329, 0, 0),
			new Struct15(32768, 21600, 0, 327),
			new Struct15(8193, 1027, 1, 2),
			new Struct15(24576, 327, 1028, 0),
			new Struct15(32768, 21600, 0, 328),
			new Struct15(24576, 327, 1030, 0),
			new Struct15(24578, 1025, 1026, 0)
		};
		int_26 = new int[3] { 9340, 18500, 6200 };
		struct16_25 = new Struct16[2]
		{
			new Struct16(new Point(-2147483646, -2147483641), new Point(-2147483647, -2147483647)),
			new Struct16(new Point(-2147483641, -2147483646), new Point(-2147483647, -2147483647))
		};
		point_42 = new Point[8]
		{
			new Point(-2147483643, 0),
			new Point(int.MinValue, -2147483646),
			new Point(-2147483646, int.MinValue),
			new Point(0, -2147483643),
			new Point(-2147483646, 21600),
			new Point(-2147483640, -2147483647),
			new Point(-2147483647, -2147483640),
			new Point(21600, -2147483646)
		};
		enum17_3 = new Enum17[8]
		{
			Enum17.const_2,
			Enum17.const_3,
			Enum17.const_2,
			Enum17.const_3,
			Enum17.const_4,
			Enum17.const_4,
			Enum17.const_1,
			Enum17.const_1
		};
		class204_24 = new Class204(point_41, ushort_23, struct15_15, int_26, struct16_25, 21600, 21600, int.MinValue, int.MinValue, point_42, enum17_3);
		point_43 = new Point[9]
		{
			new Point(0, -2147483640),
			new Point(-2147483641, -2147483640),
			new Point(-2147483641, -2147483646),
			new Point(int.MinValue, -2147483646),
			new Point(-2147483643, 0),
			new Point(21600, -2147483646),
			new Point(-2147483647, -2147483646),
			new Point(-2147483647, 21600),
			new Point(0, 21600)
		};
		ushort_24 = new ushort[3] { 8, 24576, 32768 };
		struct15_16 = new Struct15[12]
		{
			new Struct15(8192, 327, 0, 0),
			new Struct15(8192, 328, 0, 0),
			new Struct15(8192, 329, 0, 0),
			new Struct15(32768, 21600, 0, 327),
			new Struct15(8193, 1027, 1, 2),
			new Struct15(24576, 327, 1028, 0),
			new Struct15(32768, 21600, 0, 328),
			new Struct15(24576, 327, 1030, 0),
			new Struct15(24576, 1031, 1030, 0),
			new Struct15(8194, 1032, 21600, 0),
			new Struct15(8193, 328, 1, 2),
			new Struct15(8194, 329, 21600, 0)
		};
		int_27 = new int[3] { 9340, 18500, 7200 };
		struct16_26 = new Struct16[2]
		{
			new Struct16(new Point(-2147483646, -2147483641), new Point(-2147483647, -2147483647)),
			new Struct16(new Point(-2147483641, -2147483646), new Point(-2147483647, -2147483647))
		};
		point_44 = new Point[6]
		{
			new Point(-2147483643, 0),
			new Point(int.MinValue, -2147483646),
			new Point(0, -2147483639),
			new Point(-2147483638, 21600),
			new Point(-2147483647, -2147483637),
			new Point(21600, -2147483646)
		};
		enum17_4 = new Enum17[6]
		{
			Enum17.const_2,
			Enum17.const_3,
			Enum17.const_3,
			Enum17.const_4,
			Enum17.const_1,
			Enum17.const_1
		};
		class204_25 = new Class204(point_43, ushort_24, struct15_16, int_27, struct16_26, 21600, 21600, int.MinValue, int.MinValue, point_44, enum17_4);
		point_45 = new Point[22]
		{
			new Point(-21600, 0),
			new Point(21600, -2147483643),
			new Point(0, 0),
			new Point(21600, -2147483639),
			new Point(21600, -2147483640),
			new Point(-21600, -2147483642),
			new Point(21600, -2147483634),
			new Point(21600, -2147483640),
			new Point(0, -2147483642),
			new Point(0, 0),
			new Point(-21600, 0),
			new Point(21600, -2147483643),
			new Point(-2147483636, -2147483633),
			new Point(-2147483646, -2147483637),
			new Point(-2147483646, -2147483631),
			new Point(0, -2147483629),
			new Point(-2147483646, -2147483630),
			new Point(-2147483646, -2147483632),
			new Point(-21600, -2147483642),
			new Point(21600, -2147483634),
			new Point(-2147483646, -2147483632),
			new Point(-2147483636, -2147483633)
		};
		ushort_25 = new ushort[11]
		{
			42244, 1, 41732, 1, 24576, 32770, 42244, 4, 41732, 24576,
			32768
		};
		struct15_17 = new Struct15[23]
		{
			new Struct15(8192, 327, 0, 0),
			new Struct15(8192, 328, 0, 0),
			new Struct15(8192, 329, 0, 0),
			new Struct15(32768, 21600, 0, 328),
			new Struct15(8192, 329, 0, 0),
			new Struct15(24576, 327, 1027, 0),
			new Struct15(57344, 328, 328, 1031),
			new Struct15(8192, 327, 21600, 0),
			new Struct15(24576, 1033, 1030, 0),
			new Struct15(8193, 1029, 1, 2),
			new Struct15(40975, 1028, 21600, 1033),
			new Struct15(24576, 1034, 1033, 0),
			new Struct15(24591, 1030, 1029, 21600),
			new Struct15(32768, 21600, 0, 1036),
			new Struct15(24576, 1029, 1030, 0),
			new Struct15(8193, 1038, 1, 2),
			new Struct15(24576, 1035, 1030, 0),
			new Struct15(40960, 1035, 0, 1027),
			new Struct15(24576, 1040, 1027, 0),
			new Struct15(24576, 1039, 1033, 0),
			new Struct15(8193, 327, 2, 7),
			new Struct15(40960, 328, 0, 1044),
			new Struct15(8193, 1030, 1, 2)
		};
		int_28 = new int[3] { 13000, 19400, 7200 };
		struct16_27 = new Struct16[1]
		{
			new Struct16(2900, -2147483628, 18700, -2147483627)
		};
		point_46 = new Point[5]
		{
			new Point(0, -2147483626),
			new Point(-2147483646, -2147483631),
			new Point(0, -2147483629),
			new Point(-2147483646, -2147483630),
			new Point(21600, -2147483633)
		};
		class204_26 = new Class204(point_45, ushort_25, struct15_17, int_28, struct16_27, 21600, 21600, int.MinValue, int.MinValue, point_46);
		point_47 = new Point[22]
		{
			new Point(0, 0),
			new Point(43200, -2147483643),
			new Point(21600, 0),
			new Point(-2147483635, -2147483633),
			new Point(0, -2147483642),
			new Point(43200, -2147483634),
			new Point(-2147483635, -2147483633),
			new Point(21600, -2147483642),
			new Point(21600, 0),
			new Point(0, 0),
			new Point(43200, -2147483643),
			new Point(0, -2147483639),
			new Point(-2147483646, -2147483637),
			new Point(-2147483646, -2147483631),
			new Point(21600, -2147483629),
			new Point(-2147483646, -2147483630),
			new Point(-2147483646, -2147483632),
			new Point(0, -2147483642),
			new Point(43200, -2147483634),
			new Point(-2147483646, -2147483632),
			new Point(0, -2147483640),
			new Point(0, -2147483639)
		};
		ushort_26 = new ushort[11]
		{
			41732, 42244, 1, 24576, 32770, 41732, 4, 42244, 1, 24576,
			32768
		};
		struct15_18 = new Struct15[23]
		{
			new Struct15(8192, 327, 0, 0),
			new Struct15(8192, 328, 0, 0),
			new Struct15(8192, 329, 0, 0),
			new Struct15(32768, 21600, 0, 328),
			new Struct15(32768, 21600, 0, 329),
			new Struct15(24576, 327, 1027, 0),
			new Struct15(57344, 328, 328, 1031),
			new Struct15(8192, 327, 21600, 0),
			new Struct15(24576, 1033, 1030, 0),
			new Struct15(8193, 1029, 1, 2),
			new Struct15(40975, 1028, 21600, 1033),
			new Struct15(24576, 1034, 1033, 0),
			new Struct15(24591, 1030, 1029, 21600),
			new Struct15(32768, 21600, 0, 1036),
			new Struct15(24576, 1029, 1030, 0),
			new Struct15(8193, 1038, 1, 2),
			new Struct15(24576, 1035, 1030, 0),
			new Struct15(40960, 1035, 0, 1027),
			new Struct15(24576, 1040, 1027, 0),
			new Struct15(24576, 1039, 1033, 0),
			new Struct15(8193, 327, 2, 7),
			new Struct15(40960, 328, 0, 1044),
			new Struct15(8193, 1030, 1, 2)
		};
		int_29 = new int[3] { 13000, 19400, 14400 };
		point_48 = new Point[5]
		{
			new Point(0, -2147483633),
			new Point(-2147483646, -2147483630),
			new Point(21600, -2147483629),
			new Point(-2147483646, -2147483631),
			new Point(21600, -2147483626)
		};
		class204_27 = new Class204(point_47, ushort_26, struct15_18, int_29, struct16_27, 21600, 21600, int.MinValue, int.MinValue, point_48);
		point_49 = new Point[22]
		{
			new Point(0, -21600),
			new Point(-2147483643, 21600),
			new Point(0, 0),
			new Point(-2147483639, 21600),
			new Point(-2147483640, 21600),
			new Point(-2147483642, -21600),
			new Point(-2147483634, 21600),
			new Point(-2147483640, 21600),
			new Point(-2147483642, 0),
			new Point(0, 0),
			new Point(0, -21600),
			new Point(-2147483643, 21600),
			new Point(-2147483633, -2147483636),
			new Point(-2147483637, -2147483646),
			new Point(-2147483631, -2147483646),
			new Point(-2147483629, 0),
			new Point(-2147483630, -2147483646),
			new Point(-2147483632, -2147483646),
			new Point(-2147483642, -21600),
			new Point(-2147483634, 21600),
			new Point(-2147483632, -2147483646),
			new Point(-2147483633, -2147483636)
		};
		ushort_27 = new ushort[11]
		{
			41732, 1, 42244, 1, 24576, 32770, 41732, 4, 42244, 24576,
			32768
		};
		struct16_28 = new Struct16[1]
		{
			new Struct16(-2147483628, 2900, -2147483627, 18700)
		};
		point_50 = new Point[5]
		{
			new Point(-2147483629, 0),
			new Point(-2147483631, -2147483646),
			new Point(-2147483626, 0),
			new Point(-2147483633, 21600),
			new Point(-2147483630, -2147483646)
		};
		class204_28 = new Class204(point_49, ushort_27, struct15_17, int_28, struct16_28, 21600, 21600, int.MinValue, int.MinValue, point_50);
		point_51 = new Point[22]
		{
			new Point(0, 0),
			new Point(-2147483643, 43200),
			new Point(0, 21600),
			new Point(-2147483633, -2147483635),
			new Point(-2147483642, 0),
			new Point(-2147483634, 43200),
			new Point(-2147483633, -2147483635),
			new Point(-2147483642, 21600),
			new Point(0, 21600),
			new Point(0, 0),
			new Point(-2147483643, 43200),
			new Point(-2147483639, 0),
			new Point(-2147483637, -2147483646),
			new Point(-2147483631, -2147483646),
			new Point(-2147483629, 21600),
			new Point(-2147483630, -2147483646),
			new Point(-2147483632, -2147483646),
			new Point(-2147483642, 0),
			new Point(-2147483634, 43200),
			new Point(-2147483632, -2147483646),
			new Point(-2147483640, 0),
			new Point(-2147483639, 0)
		};
		ushort_28 = new ushort[11]
		{
			42244, 41732, 1, 24576, 32770, 42244, 4, 41732, 1, 24576,
			32768
		};
		point_52 = new Point[5]
		{
			new Point(-2147483633, 0),
			new Point(-2147483626, 21600),
			new Point(-2147483631, -2147483646),
			new Point(-2147483629, 21600),
			new Point(-2147483630, -2147483646)
		};
		class204_29 = new Class204(point_51, ushort_28, struct15_18, int_29, struct16_28, 21600, 21600, int.MinValue, int.MinValue, point_52);
		point_53 = new Point[15]
		{
			new Point(3375, int.MinValue),
			new Point(-2147483647, int.MinValue),
			new Point(-2147483647, 0),
			new Point(21600, 10800),
			new Point(-2147483647, 21600),
			new Point(-2147483647, -2147483646),
			new Point(3375, -2147483646),
			new Point(0, int.MinValue),
			new Point(675, int.MinValue),
			new Point(675, -2147483646),
			new Point(0, -2147483646),
			new Point(1350, int.MinValue),
			new Point(2700, int.MinValue),
			new Point(2700, -2147483646),
			new Point(1350, -2147483646)
		};
		ushort_29 = new ushort[9] { 6, 24576, 32768, 3, 24576, 32768, 3, 24576, 32768 };
		struct15_19 = new Struct15[6]
		{
			new Struct15(8192, 328, 0, 0),
			new Struct15(8192, 327, 0, 0),
			new Struct15(32768, 21600, 0, 328),
			new Struct15(32768, 21600, 0, 1025),
			new Struct15(24576, 1027, 1024, 10800),
			new Struct15(24576, 1025, 1028, 0)
		};
		struct16_29 = new Struct16[1]
		{
			new Struct16(new Point(3375, int.MinValue), new Point(-2147483643, -2147483646))
		};
		point_54 = new Point[4]
		{
			new Point(-2147483647, 0),
			new Point(0, 10800),
			new Point(-2147483647, 21600),
			new Point(21600, 10800)
		};
		class204_30 = new Class204(point_53, ushort_29, struct15_19, int_14, struct16_29, 21600, 21600, int.MinValue, int.MinValue, point_54);
		point_55 = new Point[9]
		{
			new Point(0, -2147483647),
			new Point(int.MinValue, -2147483647),
			new Point(int.MinValue, 0),
			new Point(21600, 10800),
			new Point(int.MinValue, 21600),
			new Point(int.MinValue, -2147483646),
			new Point(0, -2147483646),
			new Point(-2147483643, 10800),
			new Point(0, -2147483647)
		};
		ushort_30 = new ushort[3] { 24576, 8, 32768 };
		struct15_20 = new Struct15[8]
		{
			new Struct15(8192, 327, 0, 0),
			new Struct15(8192, 328, 0, 0),
			new Struct15(32768, 21600, 0, 328),
			new Struct15(32768, 21600, 0, 327),
			new Struct15(32768, 10800, 0, 328),
			new Struct15(24577, 1027, 1028, 10800),
			new Struct15(32768, 21600, 0, 1031),
			new Struct15(24577, 1027, 328, 10800)
		};
		struct16_30 = new Struct16[1]
		{
			new Struct16(-2147483643, -2147483647, -2147483642, -2147483646)
		};
		point_56 = new Point[4]
		{
			new Point(int.MinValue, 0),
			new Point(-2147483643, 10800),
			new Point(int.MinValue, 21600),
			new Point(21600, 10800)
		};
		class204_31 = new Class204(point_55, ushort_30, struct15_20, int_14, struct16_30, 21600, 21600, int.MinValue, int.MinValue, point_56);
		point_57 = new Point[5]
		{
			new Point(0, 0),
			new Point(int.MinValue, 0),
			new Point(21600, 10800),
			new Point(int.MinValue, 21600),
			new Point(0, 21600)
		};
		ushort_31 = new ushort[3] { 4, 24576, 32772 };
		struct15_21 = new Struct15[3]
		{
			new Struct15(8192, 327, 0, 0),
			new Struct15(8192, 1026, 10800, 0),
			new Struct15(8193, 327, 1, 2)
		};
		int_30 = new int[1] { 16200 };
		struct16_31 = new Struct16[1]
		{
			new Struct16(0, 0, -2147483647, 21600)
		};
		point_58 = new Point[4]
		{
			new Point(-2147483646, 0),
			new Point(0, 10800),
			new Point(-2147483646, 21600),
			new Point(21600, 10800)
		};
		class204_32 = new Class204(point_57, ushort_31, struct15_21, int_30, struct16_31, 21600, 21600, int.MinValue, int.MinValue, point_58);
		point_59 = new Point[6]
		{
			new Point(0, 0),
			new Point(int.MinValue, 0),
			new Point(21600, 10800),
			new Point(int.MinValue, 21600),
			new Point(0, 21600),
			new Point(-2147483647, 10800)
		};
		ushort_32 = new ushort[3] { 5, 24576, 32768 };
		struct15_22 = new Struct15[4]
		{
			new Struct15(8192, 327, 0, 0),
			new Struct15(32768, 21600, 0, 1024),
			new Struct15(8192, 1027, 10800, 0),
			new Struct15(8193, 327, 1, 2)
		};
		int_31 = new int[1] { 16200 };
		struct16_32 = new Struct16[1]
		{
			new Struct16(0, 0, -2147483646, 21600)
		};
		point_60 = new Point[4]
		{
			new Point(-2147483645, 0),
			new Point(-2147483647, 10800),
			new Point(-2147483645, 21600),
			new Point(21600, 10800)
		};
		class204_33 = new Class204(point_59, ushort_32, struct15_22, int_31, struct16_32, 21600, 21600, int.MinValue, int.MinValue, point_60);
		point_61 = new Point[11]
		{
			new Point(-2147483645, -2147483645),
			new Point(-2147483628, -2147483628),
			new Point(-2147483629, -2147483630),
			new Point(-2147483631, -2147483632),
			new Point(0, 0),
			new Point(21600, 21600),
			new Point(-2147483639, -2147483640),
			new Point(-2147483637, -2147483638),
			new Point(-2147483624, -2147483625),
			new Point(-2147483617, -2147483618),
			new Point(-2147483619, -2147483620)
		};
		ushort_33 = new ushort[5] { 41988, 42244, 3, 24576, 32768 };
		struct15_23 = new Struct15[57]
		{
			new Struct15(8192, 327, 0, 0),
			new Struct15(8192, 328, 0, 0),
			new Struct15(8192, 329, 0, 0),
			new Struct15(32768, 10800, 0, 329),
			new Struct15(16393, 10800, 327, 0),
			new Struct15(16394, 10800, 327, 0),
			new Struct15(16393, 10800, 328, 0),
			new Struct15(16394, 10800, 328, 0),
			new Struct15(8192, 1028, 10800, 0),
			new Struct15(8192, 1029, 10800, 0),
			new Struct15(8192, 1030, 10800, 0),
			new Struct15(8192, 1031, 10800, 0),
			new Struct15(24585, 1026, 327, 0),
			new Struct15(24586, 1026, 327, 0),
			new Struct15(24585, 1026, 328, 0),
			new Struct15(24586, 1026, 328, 0),
			new Struct15(8192, 1036, 10800, 0),
			new Struct15(8192, 1037, 10800, 0),
			new Struct15(8192, 1038, 10800, 0),
			new Struct15(8192, 1039, 10800, 0),
			new Struct15(32768, 21600, 0, 1027),
			new Struct15(16393, 13500, 328, 0),
			new Struct15(16394, 13500, 328, 0),
			new Struct15(8192, 1045, 10800, 0),
			new Struct15(8192, 1046, 10800, 0),
			new Struct15(8192, 329, 0, 2700),
			new Struct15(24585, 1049, 328, 0),
			new Struct15(24586, 1049, 328, 0),
			new Struct15(8192, 1050, 10800, 0),
			new Struct15(8192, 1051, 10800, 0),
			new Struct15(24576, 1058, 1060, 0),
			new Struct15(24576, 1059, 1061, 0),
			new Struct15(24585, 1063, 328, 0),
			new Struct15(24586, 1063, 328, 0),
			new Struct15(8192, 1056, 10800, 0),
			new Struct15(8192, 1057, 10800, 0),
			new Struct15(24585, 1065, 1062, 0),
			new Struct15(24586, 1065, 1062, 0),
			new Struct15(8206, 328, 90, 0),
			new Struct15(32768, 10800, 0, 1064),
			new Struct15(8193, 1027, 1, 2),
			new Struct15(8192, 1064, 2700, 0),
			new Struct15(24578, 1041, 1033, 0),
			new Struct15(24578, 1040, 1032, 0),
			new Struct15(24578, 1024, 1080, 0),
			new Struct15(16393, 10800, 1068, 0),
			new Struct15(16394, 10800, 1068, 0),
			new Struct15(24585, 1026, 1068, 0),
			new Struct15(24586, 1026, 1068, 0),
			new Struct15(8192, 1069, 10800, 0),
			new Struct15(8192, 1070, 10800, 0),
			new Struct15(8192, 1071, 10800, 0),
			new Struct15(8192, 1072, 10800, 0),
			new Struct15(40960, 1025, 0, 1024),
			new Struct15(8206, 0, 360, 0),
			new Struct15(40966, 1077, 0, 1078),
			new Struct15(24576, 1025, 1079, 0)
		};
		int_32 = new int[3] { 11796480, 0, 5500 };
		struct16_33 = new Struct16[1]
		{
			new Struct16(3200, 3200, 18400, 18400)
		};
		point_62 = new Point[6]
		{
			new Point(-2147483598, -2147483599),
			new Point(-2147483606, -2147483605),
			new Point(-2147483596, -2147483597),
			new Point(-2147483624, -2147483625),
			new Point(-2147483617, -2147483618),
			new Point(-2147483619, -2147483620)
		};
		class204_34 = new Class204(point_61, ushort_33, struct15_23, int_32, struct16_33, 21600, 21600, int.MinValue, int.MinValue, point_62);
		point_63 = new Point[14]
		{
			new Point(0, 21600),
			new Point(0, -2147483647),
			new Point(-2147483646, 0),
			new Point(21600, 0),
			new Point(21600, -2147483645),
			new Point(-2147483644, 21600),
			new Point(0, -2147483647),
			new Point(-2147483646, 0),
			new Point(21600, 0),
			new Point(-2147483644, -2147483647),
			new Point(-2147483644, 21600),
			new Point(-2147483644, -2147483647),
			new Point(21600, 0),
			new Point(21600, -2147483645)
		};
		ushort_34 = new ushort[9] { 5, 24576, 32768, 3, 24576, 33025, 3, 24576, 33026 };
		struct15_24 = new Struct15[9]
		{
			new Struct15(8192, 327, 0, 0),
			new Struct15(24576, 321, 1024, 0),
			new Struct15(24576, 320, 1024, 0),
			new Struct15(40960, 323, 0, 1024),
			new Struct15(40960, 322, 0, 1024),
			new Struct15(32768, 21600, 0, 1026),
			new Struct15(8193, 1029, 1, 2),
			new Struct15(24576, 1026, 1030, 0),
			new Struct15(8193, 1028, 1, 2)
		};
		struct16_34 = new Struct16[1]
		{
			new Struct16(new Point(0, -2147483647), new Point(-2147483644, 21600))
		};
		class204_35 = new Class204(point_63, ushort_34, struct15_24, int_11, struct16_34, 21600, 21600, 10800, 10800, point_2);
		point_64 = new Point[20]
		{
			new Point(0, 0),
			new Point(21600, 0),
			new Point(21600, 21600),
			new Point(0, 21600),
			new Point(0, 0),
			new Point(21600, 0),
			new Point(-2147483647, -2147483646),
			new Point(int.MinValue, -2147483646),
			new Point(21600, 0),
			new Point(21600, 21600),
			new Point(-2147483647, -2147483645),
			new Point(-2147483647, -2147483646),
			new Point(21600, 21600),
			new Point(0, 21600),
			new Point(int.MinValue, -2147483645),
			new Point(-2147483647, -2147483645),
			new Point(0, 21600),
			new Point(0, 0),
			new Point(int.MinValue, -2147483646),
			new Point(int.MinValue, -2147483645)
		};
		ushort_35 = new ushort[15]
		{
			3, 24576, 32768, 3, 24576, 33025, 3, 24576, 33030, 3,
			24576, 33026, 3, 24576, 33029
		};
		struct15_25 = new Struct15[4]
		{
			new Struct15(24576, 327, 320, 0),
			new Struct15(40960, 322, 0, 327),
			new Struct15(24576, 327, 321, 0),
			new Struct15(40960, 323, 0, 327)
		};
		struct16_35 = new Struct16[1]
		{
			new Struct16(new Point(int.MinValue, -2147483646), new Point(-2147483647, -2147483645))
		};
		class204_36 = new Class204(point_64, ushort_35, struct15_25, int_8, struct16_35, 21600, 21600, 10800, 10800, point_2);
		point_65 = new Point[10]
		{
			new Point(0, 0),
			new Point(21600, 0),
			new Point(21600, int.MinValue),
			new Point(int.MinValue, 21600),
			new Point(0, 21600),
			new Point(int.MinValue, 21600),
			new Point(-2147483645, int.MinValue),
			new Point(-2147483640, -2147483639),
			new Point(-2147483638, -2147483637),
			new Point(21600, int.MinValue)
		};
		ushort_36 = new ushort[7] { 4, 24576, 32768, 1, 8193, 24576, 33026 };
		struct15_26 = new Struct15[12]
		{
			new Struct15(8192, 327, 0, 0),
			new Struct15(32768, 21600, 0, 1024),
			new Struct15(8193, 1025, 8000, 10800),
			new Struct15(32768, 21600, 0, 1026),
			new Struct15(8193, 1025, 1, 2),
			new Struct15(8193, 1025, 1, 4),
			new Struct15(8193, 1025, 1, 7),
			new Struct15(8193, 1025, 1, 16),
			new Struct15(24576, 1027, 1029, 0),
			new Struct15(24576, 1024, 1030, 0),
			new Struct15(32768, 21600, 0, 1028),
			new Struct15(24576, 1024, 1031, 0)
		};
		int_33 = new int[1] { 18900 };
		struct16_36 = new Struct16[1]
		{
			new Struct16(new Point(0, 0), new Point(21600, -2147483637))
		};
		class204_37 = new Class204(point_65, ushort_36, struct15_26, int_33, struct16_36, 21600, 21600, int.MinValue, int.MinValue, point_2);
		point_66 = new Point[20]
		{
			new Point(0, 0),
			new Point(21600, 0),
			new Point(21600, 21600),
			new Point(0, 21600),
			new Point(0, 0),
			new Point(21600, 0),
			new Point(-2147483645, -2147483646),
			new Point(-2147483647, -2147483646),
			new Point(21600, 0),
			new Point(21600, 21600),
			new Point(-2147483645, -2147483644),
			new Point(-2147483645, -2147483646),
			new Point(21600, 21600),
			new Point(0, 21600),
			new Point(-2147483647, -2147483644),
			new Point(-2147483645, -2147483644),
			new Point(0, 21600),
			new Point(0, 0),
			new Point(-2147483647, -2147483646),
			new Point(-2147483647, -2147483644)
		};
		ushort_37 = new ushort[15]
		{
			3, 24576, 32768, 3, 24576, 33025, 3, 24576, 33030, 3,
			24576, 33026, 3, 24576, 33029
		};
		struct15_27 = new Struct15[5]
		{
			new Struct15(8192, 327, 0, 0),
			new Struct15(24576, 320, 327, 0),
			new Struct15(24576, 321, 327, 0),
			new Struct15(40960, 322, 0, 327),
			new Struct15(40960, 323, 0, 327)
		};
		class204_38 = new Class204(point_66, ushort_37, struct15_27, int_5, struct16_37, 21600, 21600, 10800, 10800, point_2);
		struct16_37 = new Struct16[1]
		{
			new Struct16(new Point(-2147483647, -2147483646), new Point(-2147483645, -2147483644))
		};
		point_67 = new Point[43]
		{
			new Point(0, 0),
			new Point(21600, 0),
			new Point(21600, 21600),
			new Point(0, 21600),
			new Point(0, 0),
			new Point(21600, 0),
			new Point(-2147483645, -2147483646),
			new Point(-2147483647, -2147483646),
			new Point(21600, 0),
			new Point(21600, 21600),
			new Point(-2147483645, -2147483644),
			new Point(-2147483645, -2147483646),
			new Point(21600, 21600),
			new Point(0, 21600),
			new Point(-2147483647, -2147483644),
			new Point(-2147483645, -2147483644),
			new Point(0, 21600),
			new Point(0, 0),
			new Point(-2147483647, -2147483646),
			new Point(-2147483647, -2147483644),
			new Point(10800, -2147483638),
			new Point(-2147483636, -2147483634),
			new Point(-2147483636, -2147483632),
			new Point(-2147483630, -2147483632),
			new Point(-2147483630, -2147483628),
			new Point(-2147483626, 10800),
			new Point(-2147483624, 10800),
			new Point(-2147483624, -2147483622),
			new Point(-2147483620, -2147483622),
			new Point(-2147483620, 10800),
			new Point(-2147483618, 10800),
			new Point(-2147483636, -2147483634),
			new Point(-2147483636, -2147483632),
			new Point(-2147483630, -2147483632),
			new Point(-2147483630, -2147483628),
			new Point(-2147483616, -2147483612),
			new Point(-2147483614, -2147483612),
			new Point(-2147483614, -2147483622),
			new Point(-2147483624, -2147483622),
			new Point(-2147483624, 10800),
			new Point(-2147483620, 10800),
			new Point(-2147483620, -2147483622),
			new Point(-2147483616, -2147483622)
		};
		ushort_38 = new ushort[24]
		{
			3, 24576, 32768, 3, 24576, 33025, 3, 24576, 33030, 3,
			24576, 33026, 3, 24576, 33029, 10, 24576, 33030, 3, 24576,
			33026, 7, 24576, 33026
		};
		struct15_28 = new Struct15[37]
		{
			new Struct15(8192, 327, 0, 0),
			new Struct15(24576, 320, 327, 0),
			new Struct15(24576, 321, 327, 0),
			new Struct15(40960, 322, 0, 327),
			new Struct15(40960, 323, 0, 327),
			new Struct15(32768, 8000, 0, 327),
			new Struct15(8193, 1029, 1, 8000),
			new Struct15(24576, 322, 320, 10800),
			new Struct15(24576, 323, 321, 10800),
			new Struct15(16385, -8000, 1030, 1),
			new Struct15(24576, 1033, 1032, 0),
			new Struct15(16385, 2960, 1030, 1),
			new Struct15(24576, 1035, 1031, 0),
			new Struct15(16385, -5000, 1030, 1),
			new Struct15(24576, 1037, 1032, 0),
			new Struct15(16385, -7000, 1030, 1),
			new Struct15(24576, 1039, 1032, 0),
			new Struct15(16385, 5000, 1030, 1),
			new Struct15(24576, 1041, 1031, 0),
			new Struct15(16385, -2960, 1030, 1),
			new Struct15(24576, 1043, 1032, 0),
			new Struct15(16385, 8000, 1030, 1),
			new Struct15(24576, 1045, 1031, 0),
			new Struct15(16385, 6100, 1030, 1),
			new Struct15(24576, 1047, 1031, 0),
			new Struct15(16385, 8260, 1030, 1),
			new Struct15(24576, 1049, 1032, 0),
			new Struct15(16385, -6100, 1030, 1),
			new Struct15(24576, 1051, 1031, 0),
			new Struct15(16385, -8000, 1030, 1),
			new Struct15(24576, 1053, 1031, 0),
			new Struct15(16385, -1060, 1030, 1),
			new Struct15(24576, 1055, 1031, 0),
			new Struct15(16385, 1060, 1030, 1),
			new Struct15(24576, 1057, 1031, 0),
			new Struct15(16385, 4020, 1030, 1),
			new Struct15(24576, 1059, 1032, 0)
		};
		class204_39 = new Class204(point_67, ushort_38, struct15_28, int_5, struct16_37, 21600, 21600, int.MinValue, int.MinValue, point_2);
		point_68 = new Point[50]
		{
			new Point(0, 0),
			new Point(21600, 0),
			new Point(21600, 21600),
			new Point(0, 21600),
			new Point(0, 0),
			new Point(21600, 0),
			new Point(-2147483645, -2147483646),
			new Point(-2147483647, -2147483646),
			new Point(21600, 0),
			new Point(21600, 21600),
			new Point(-2147483645, -2147483644),
			new Point(-2147483645, -2147483646),
			new Point(21600, 21600),
			new Point(0, 21600),
			new Point(-2147483647, -2147483644),
			new Point(-2147483645, -2147483644),
			new Point(0, 21600),
			new Point(0, 0),
			new Point(-2147483647, -2147483646),
			new Point(-2147483647, -2147483644),
			new Point(-2147483638, -2147483636),
			new Point(-2147483634, -2147483632),
			new Point(-2147483630, -2147483628),
			new Point(-2147483630, -2147483626),
			new Point(-2147483630, -2147483624),
			new Point(-2147483622, 10800),
			new Point(-2147483620, 10800),
			new Point(-2147483618, 10800),
			new Point(-2147483616, -2147483614),
			new Point(-2147483616, -2147483612),
			new Point(-2147483616, -2147483610),
			new Point(-2147483608, -2147483606),
			new Point(10800, -2147483606),
			new Point(-2147483604, -2147483606),
			new Point(-2147483602, -2147483610),
			new Point(-2147483602, -2147483612),
			new Point(-2147483600, -2147483612),
			new Point(-2147483600, -2147483598),
			new Point(-2147483596, -2147483594),
			new Point(10800, -2147483594),
			new Point(-2147483630, -2147483594),
			new Point(-2147483620, -2147483598),
			new Point(-2147483620, -2147483612),
			new Point(-2147483620, -2147483592),
			new Point(-2147483590, -2147483588),
			new Point(-2147483630, -2147483588),
			new Point(10800, -2147483588),
			new Point(-2147483596, 10800),
			new Point(-2147483596, -2147483626),
			new Point(-2147483596, -2147483628)
		};
		ushort_39 = new ushort[25]
		{
			3, 24576, 32768, 3, 24576, 33025, 3, 24576, 33030, 3,
			24576, 33026, 3, 24576, 33029, 41730, 24576, 33030, 1, 8196,
			1, 8196, 1, 24576, 33030
		};
		struct15_29 = new Struct15[61]
		{
			new Struct15(8192, 327, 0, 0),
			new Struct15(24576, 320, 327, 0),
			new Struct15(24576, 321, 327, 0),
			new Struct15(40960, 322, 0, 327),
			new Struct15(40960, 323, 0, 327),
			new Struct15(32768, 8000, 0, 327),
			new Struct15(8193, 1029, 1, 8000),
			new Struct15(24576, 322, 320, 10800),
			new Struct15(24576, 323, 321, 10800),
			new Struct15(16385, -1690, 1030, 1),
			new Struct15(24576, 1033, 1031, 0),
			new Struct15(16385, 4600, 1030, 1),
			new Struct15(24576, 1035, 1032, 0),
			new Struct15(16385, 1690, 1030, 1),
			new Struct15(24576, 1037, 1031, 0),
			new Struct15(16385, 7980, 1030, 1),
			new Struct15(24576, 1039, 1032, 0),
			new Struct15(16385, 1270, 1030, 1),
			new Struct15(24576, 1041, 1031, 0),
			new Struct15(16385, 4000, 1030, 1),
			new Struct15(24576, 1043, 1032, 0),
			new Struct15(16385, 1750, 1030, 1),
			new Struct15(24576, 1045, 1032, 0),
			new Struct15(16385, 800, 1030, 1),
			new Struct15(24576, 1047, 1032, 0),
			new Struct15(16385, 1650, 1030, 1),
			new Struct15(24576, 1049, 1031, 0),
			new Struct15(16385, 2340, 1030, 1),
			new Struct15(24576, 1051, 1031, 0),
			new Struct15(16385, 3640, 1030, 1),
			new Struct15(24576, 1053, 1031, 0),
			new Struct15(16385, 4670, 1030, 1),
			new Struct15(24576, 1055, 1031, 0),
			new Struct15(16385, -1570, 1030, 1),
			new Struct15(24576, 1057, 1032, 0),
			new Struct15(16385, -3390, 1030, 1),
			new Struct15(24576, 1059, 1032, 0),
			new Struct15(16385, -6050, 1030, 1),
			new Struct15(24576, 1061, 1032, 0),
			new Struct15(16385, 2540, 1030, 1),
			new Struct15(24576, 1063, 1031, 0),
			new Struct15(16385, -8050, 1030, 1),
			new Struct15(24576, 1065, 1032, 0),
			new Struct15(16385, -2540, 1030, 1),
			new Struct15(24576, 1067, 1031, 0),
			new Struct15(16385, -4460, 1030, 1),
			new Struct15(24576, 1069, 1031, 0),
			new Struct15(16385, -2330, 1030, 1),
			new Struct15(24576, 1071, 1031, 0),
			new Struct15(16385, -4700, 1030, 1),
			new Struct15(24576, 1073, 1032, 0),
			new Struct15(16385, -1270, 1030, 1),
			new Struct15(24576, 1075, 1031, 0),
			new Struct15(16385, -5720, 1030, 1),
			new Struct15(24576, 1077, 1032, 0),
			new Struct15(16385, -2540, 1030, 1),
			new Struct15(24576, 1079, 1032, 0),
			new Struct15(16385, 1800, 1030, 1),
			new Struct15(24576, 1081, 1031, 0),
			new Struct15(16385, -1700, 1030, 1),
			new Struct15(24576, 1083, 1032, 0)
		};
		class204_40 = new Class204(point_68, ushort_39, struct15_29, int_5, struct16_37, 21600, 21600, int.MinValue, int.MinValue, point_2);
		point_69 = new Point[34]
		{
			new Point(0, 0),
			new Point(21600, 0),
			new Point(21600, 21600),
			new Point(0, 21600),
			new Point(0, 0),
			new Point(21600, 0),
			new Point(-2147483645, -2147483646),
			new Point(-2147483647, -2147483646),
			new Point(21600, 0),
			new Point(21600, 21600),
			new Point(-2147483645, -2147483644),
			new Point(-2147483645, -2147483646),
			new Point(21600, 21600),
			new Point(0, 21600),
			new Point(-2147483647, -2147483644),
			new Point(-2147483645, -2147483644),
			new Point(0, 21600),
			new Point(0, 0),
			new Point(-2147483647, -2147483646),
			new Point(-2147483647, -2147483644),
			new Point(-2147483638, -2147483636),
			new Point(-2147483634, -2147483632),
			new Point(-2147483630, -2147483628),
			new Point(-2147483626, -2147483624),
			new Point(-2147483622, -2147483620),
			new Point(-2147483618, -2147483620),
			new Point(-2147483618, -2147483616),
			new Point(-2147483614, -2147483616),
			new Point(-2147483614, -2147483612),
			new Point(-2147483622, -2147483612),
			new Point(-2147483622, -2147483616),
			new Point(-2147483610, -2147483616),
			new Point(-2147483610, -2147483608),
			new Point(-2147483622, -2147483608)
		};
		ushort_40 = new ushort[24]
		{
			3, 24576, 32768, 3, 24576, 33025, 3, 24576, 33030, 3,
			24576, 33026, 3, 24576, 33029, 41730, 24576, 33030, 41730, 24576,
			33029, 9, 24576, 33029
		};
		struct15_30 = new Struct15[41]
		{
			new Struct15(8192, 327, 0, 0),
			new Struct15(24576, 320, 327, 0),
			new Struct15(24576, 321, 327, 0),
			new Struct15(40960, 322, 0, 327),
			new Struct15(40960, 323, 0, 327),
			new Struct15(32768, 8000, 0, 327),
			new Struct15(8193, 1029, 1, 8000),
			new Struct15(24576, 322, 320, 10800),
			new Struct15(24576, 323, 321, 10800),
			new Struct15(16385, -8050, 1030, 1),
			new Struct15(24576, 1033, 1031, 0),
			new Struct15(16385, -8050, 1030, 1),
			new Struct15(24576, 1035, 1032, 0),
			new Struct15(16385, 8050, 1030, 1),
			new Struct15(24576, 1037, 1031, 0),
			new Struct15(16385, 8050, 1030, 1),
			new Struct15(24576, 1039, 1032, 0),
			new Struct15(16385, -2060, 1030, 1),
			new Struct15(24576, 1041, 1031, 0),
			new Struct15(16385, -7620, 1030, 1),
			new Struct15(24576, 1043, 1032, 0),
			new Struct15(16385, 2060, 1030, 1),
			new Struct15(24576, 1045, 1031, 0),
			new Struct15(16385, -3500, 1030, 1),
			new Struct15(24576, 1047, 1032, 0),
			new Struct15(16385, -2960, 1030, 1),
			new Struct15(24576, 1049, 1031, 0),
			new Struct15(16385, -2960, 1030, 1),
			new Struct15(24576, 1051, 1032, 0),
			new Struct15(16385, 1480, 1030, 1),
			new Struct15(24576, 1053, 1031, 0),
			new Struct15(16385, 5080, 1030, 1),
			new Struct15(24576, 1055, 1032, 0),
			new Struct15(16385, 2960, 1030, 1),
			new Struct15(24576, 1057, 1031, 0),
			new Struct15(16385, 6140, 1030, 1),
			new Struct15(24576, 1059, 1032, 0),
			new Struct15(16385, -1480, 1030, 1),
			new Struct15(24576, 1061, 1031, 0),
			new Struct15(16385, -1920, 1030, 1),
			new Struct15(24576, 1063, 1032, 0)
		};
		class204_41 = new Class204(point_69, ushort_40, struct15_30, int_5, struct16_37, 21600, 21600, int.MinValue, int.MinValue, point_2);
		point_70 = new Point[23]
		{
			new Point(0, 0),
			new Point(21600, 0),
			new Point(21600, 21600),
			new Point(0, 21600),
			new Point(0, 0),
			new Point(21600, 0),
			new Point(-2147483645, -2147483646),
			new Point(-2147483647, -2147483646),
			new Point(21600, 0),
			new Point(21600, 21600),
			new Point(-2147483645, -2147483644),
			new Point(-2147483645, -2147483646),
			new Point(21600, 21600),
			new Point(0, 21600),
			new Point(-2147483647, -2147483644),
			new Point(-2147483645, -2147483644),
			new Point(0, 21600),
			new Point(0, 0),
			new Point(-2147483647, -2147483646),
			new Point(-2147483647, -2147483644),
			new Point(-2147483638, 10800),
			new Point(-2147483634, -2147483636),
			new Point(-2147483634, -2147483632)
		};
		ushort_41 = new ushort[18]
		{
			3, 24576, 32768, 3, 24576, 33025, 3, 24576, 33030, 3,
			24576, 33026, 3, 24576, 33029, 2, 24576, 33030
		};
		struct15_31 = new Struct15[17]
		{
			new Struct15(8192, 327, 0, 0),
			new Struct15(24576, 320, 327, 0),
			new Struct15(24576, 321, 327, 0),
			new Struct15(40960, 322, 0, 327),
			new Struct15(40960, 323, 0, 327),
			new Struct15(32768, 8000, 0, 327),
			new Struct15(8193, 1029, 1, 8000),
			new Struct15(24576, 322, 320, 10800),
			new Struct15(24576, 323, 321, 10800),
			new Struct15(16385, -8050, 1030, 1),
			new Struct15(24576, 1033, 1031, 0),
			new Struct15(16385, -8050, 1030, 1),
			new Struct15(24576, 1035, 1032, 0),
			new Struct15(16385, 8050, 1030, 1),
			new Struct15(24576, 1037, 1031, 0),
			new Struct15(16385, 8050, 1030, 1),
			new Struct15(24576, 1039, 1032, 0)
		};
		class204_42 = new Class204(point_70, ushort_41, struct15_31, int_5, struct16_37, 21600, 21600, int.MinValue, int.MinValue, point_2);
		point_71 = new Point[23]
		{
			new Point(0, 0),
			new Point(21600, 0),
			new Point(21600, 21600),
			new Point(0, 21600),
			new Point(0, 0),
			new Point(21600, 0),
			new Point(-2147483645, -2147483646),
			new Point(-2147483647, -2147483646),
			new Point(21600, 0),
			new Point(21600, 21600),
			new Point(-2147483645, -2147483644),
			new Point(-2147483645, -2147483646),
			new Point(21600, 21600),
			new Point(0, 21600),
			new Point(-2147483647, -2147483644),
			new Point(-2147483645, -2147483644),
			new Point(0, 21600),
			new Point(0, 0),
			new Point(-2147483647, -2147483646),
			new Point(-2147483647, -2147483644),
			new Point(-2147483638, -2147483636),
			new Point(-2147483634, 10800),
			new Point(-2147483638, -2147483632)
		};
		class204_43 = new Class204(point_71, ushort_41, struct15_31, int_5, struct16_37, 21600, 21600, int.MinValue, int.MinValue, point_2);
		point_72 = new Point[27]
		{
			new Point(0, 0),
			new Point(21600, 0),
			new Point(21600, 21600),
			new Point(0, 21600),
			new Point(0, 0),
			new Point(21600, 0),
			new Point(-2147483645, -2147483646),
			new Point(-2147483647, -2147483646),
			new Point(21600, 0),
			new Point(21600, 21600),
			new Point(-2147483645, -2147483644),
			new Point(-2147483645, -2147483646),
			new Point(21600, 21600),
			new Point(0, 21600),
			new Point(-2147483647, -2147483644),
			new Point(-2147483645, -2147483644),
			new Point(0, 21600),
			new Point(0, 0),
			new Point(-2147483647, -2147483646),
			new Point(-2147483647, -2147483644),
			new Point(-2147483638, 10800),
			new Point(-2147483634, -2147483636),
			new Point(-2147483634, -2147483632),
			new Point(-2147483630, -2147483636),
			new Point(-2147483628, -2147483636),
			new Point(-2147483628, -2147483632),
			new Point(-2147483630, -2147483632)
		};
		ushort_42 = new ushort[21]
		{
			3, 24576, 32768, 3, 24576, 33025, 3, 24576, 33030, 3,
			24576, 33026, 3, 24576, 33029, 2, 24576, 32774, 3, 24576,
			32774
		};
		struct15_32 = new Struct15[25]
		{
			new Struct15(8192, 327, 0, 0),
			new Struct15(24576, 320, 327, 0),
			new Struct15(24576, 321, 327, 0),
			new Struct15(40960, 322, 0, 327),
			new Struct15(40960, 323, 0, 327),
			new Struct15(32768, 8000, 0, 327),
			new Struct15(8193, 1029, 1, 8000),
			new Struct15(24576, 322, 320, 10800),
			new Struct15(24576, 323, 321, 10800),
			new Struct15(16385, -4020, 1030, 1),
			new Struct15(24576, 1033, 1031, 0),
			new Struct15(16385, -8050, 1030, 1),
			new Struct15(24576, 1035, 1032, 0),
			new Struct15(16385, 8050, 1030, 1),
			new Struct15(24576, 1037, 1031, 0),
			new Struct15(16385, 8050, 1030, 1),
			new Struct15(24576, 1039, 1032, 0),
			new Struct15(16385, -8050, 1030, 1),
			new Struct15(24576, 1041, 1031, 0),
			new Struct15(16385, -6100, 1030, 1),
			new Struct15(24576, 1043, 1031, 0),
			new Struct15(16385, 4020, 1030, 1),
			new Struct15(24576, 1045, 1031, 0),
			new Struct15(16385, 6100, 1030, 1),
			new Struct15(24576, 1047, 1031, 0)
		};
		class204_44 = new Class204(point_72, ushort_42, struct15_32, int_5, struct16_37, 21600, 21600, int.MinValue, int.MinValue, point_2);
		point_73 = new Point[27]
		{
			new Point(0, 0),
			new Point(21600, 0),
			new Point(21600, 21600),
			new Point(0, 21600),
			new Point(0, 0),
			new Point(21600, 0),
			new Point(-2147483645, -2147483646),
			new Point(-2147483647, -2147483646),
			new Point(21600, 0),
			new Point(21600, 21600),
			new Point(-2147483645, -2147483644),
			new Point(-2147483645, -2147483646),
			new Point(21600, 21600),
			new Point(0, 21600),
			new Point(-2147483647, -2147483644),
			new Point(-2147483645, -2147483644),
			new Point(0, 21600),
			new Point(0, 0),
			new Point(-2147483647, -2147483646),
			new Point(-2147483647, -2147483644),
			new Point(-2147483626, 10800),
			new Point(-2147483630, -2147483632),
			new Point(-2147483630, -2147483636),
			new Point(-2147483624, -2147483636),
			new Point(-2147483624, -2147483632),
			new Point(-2147483634, -2147483632),
			new Point(-2147483634, -2147483636)
		};
		class204_45 = new Class204(point_73, ushort_42, struct15_32, int_5, struct16_37, 21600, 21600, int.MinValue, int.MinValue, point_2);
		point_74 = new Point[43]
		{
			new Point(0, 0),
			new Point(21600, 0),
			new Point(21600, 21600),
			new Point(0, 21600),
			new Point(0, 0),
			new Point(21600, 0),
			new Point(-2147483645, -2147483646),
			new Point(-2147483647, -2147483646),
			new Point(21600, 0),
			new Point(21600, 21600),
			new Point(-2147483645, -2147483644),
			new Point(-2147483645, -2147483646),
			new Point(21600, 21600),
			new Point(0, 21600),
			new Point(-2147483647, -2147483644),
			new Point(-2147483645, -2147483644),
			new Point(0, 21600),
			new Point(0, 0),
			new Point(-2147483647, -2147483646),
			new Point(-2147483647, -2147483644),
			new Point(-2147483638, -2147483636),
			new Point(-2147483634, -2147483636),
			new Point(-2147483634, -2147483632),
			new Point(-2147483634, -2147483630),
			new Point(-2147483628, -2147483626),
			new Point(-2147483624, -2147483626),
			new Point(10800, -2147483626),
			new Point(-2147483622, -2147483626),
			new Point(-2147483620, -2147483630),
			new Point(-2147483620, -2147483632),
			new Point(-2147483620, -2147483636),
			new Point(10800, -2147483636),
			new Point(-2147483618, -2147483616),
			new Point(-2147483614, -2147483636),
			new Point(-2147483612, -2147483636),
			new Point(-2147483612, -2147483632),
			new Point(-2147483612, -2147483610),
			new Point(-2147483608, -2147483606),
			new Point(10800, -2147483606),
			new Point(-2147483624, -2147483606),
			new Point(-2147483604, -2147483606),
			new Point(-2147483638, -2147483610),
			new Point(-2147483638, -2147483632)
		};
		ushort_43 = new ushort[25]
		{
			3, 24576, 32768, 3, 24576, 33025, 3, 24576, 33030, 3,
			24576, 33026, 3, 24576, 33029, 2, 8193, 1, 8193, 6,
			8193, 1, 8193, 24576, 33030
		};
		struct15_33 = new Struct15[45]
		{
			new Struct15(8192, 327, 0, 0),
			new Struct15(24576, 320, 327, 0),
			new Struct15(24576, 321, 327, 0),
			new Struct15(40960, 322, 0, 327),
			new Struct15(40960, 323, 0, 327),
			new Struct15(32768, 8000, 0, 327),
			new Struct15(8193, 1029, 1, 8000),
			new Struct15(24576, 322, 320, 10800),
			new Struct15(24576, 323, 321, 10800),
			new Struct15(16385, -8050, 1030, 1),
			new Struct15(24576, 1033, 1031, 0),
			new Struct15(16385, -3800, 1030, 1),
			new Struct15(24576, 1035, 1032, 0),
			new Struct15(16385, -4020, 1030, 1),
			new Struct15(24576, 1037, 1031, 0),
			new Struct15(16385, 2330, 1030, 1),
			new Struct15(24576, 1039, 1032, 0),
			new Struct15(16385, 3390, 1030, 1),
			new Struct15(24576, 1041, 1032, 0),
			new Struct15(16385, -3100, 1030, 1),
			new Struct15(24576, 1043, 1031, 0),
			new Struct15(16385, 4230, 1030, 1),
			new Struct15(24576, 1045, 1032, 0),
			new Struct15(16385, -1910, 1030, 1),
			new Struct15(24576, 1047, 1031, 0),
			new Struct15(16385, 1190, 1030, 1),
			new Struct15(24576, 1049, 1031, 0),
			new Struct15(16385, 2110, 1030, 1),
			new Struct15(24576, 1051, 1031, 0),
			new Struct15(16385, 4030, 1030, 1),
			new Struct15(24576, 1053, 1031, 0),
			new Struct15(16385, -7830, 1030, 1),
			new Struct15(24576, 1055, 1032, 0),
			new Struct15(16385, 8250, 1030, 1),
			new Struct15(24576, 1057, 1031, 0),
			new Struct15(16385, 6140, 1030, 1),
			new Struct15(24576, 1059, 1031, 0),
			new Struct15(16385, 5510, 1030, 1),
			new Struct15(24576, 1061, 1032, 0),
			new Struct15(16385, 3180, 1030, 1),
			new Struct15(24576, 1063, 1031, 0),
			new Struct15(16385, 8450, 1030, 1),
			new Struct15(24576, 1065, 1032, 0),
			new Struct15(16385, -5090, 1030, 1),
			new Struct15(24576, 1067, 1031, 0)
		};
		class204_46 = new Class204(point_74, ushort_43, struct15_33, int_5, struct16_37, 21600, 21600, int.MinValue, int.MinValue, point_2);
		point_75 = new Point[28]
		{
			new Point(0, 0),
			new Point(21600, 0),
			new Point(21600, 21600),
			new Point(0, 21600),
			new Point(0, 0),
			new Point(21600, 0),
			new Point(-2147483645, -2147483646),
			new Point(-2147483647, -2147483646),
			new Point(21600, 0),
			new Point(21600, 21600),
			new Point(-2147483645, -2147483644),
			new Point(-2147483645, -2147483646),
			new Point(21600, 21600),
			new Point(0, 21600),
			new Point(-2147483647, -2147483644),
			new Point(-2147483645, -2147483644),
			new Point(0, 21600),
			new Point(0, 0),
			new Point(-2147483647, -2147483646),
			new Point(-2147483647, -2147483644),
			new Point(-2147483638, -2147483636),
			new Point(-2147483634, -2147483636),
			new Point(-2147483632, -2147483630),
			new Point(-2147483632, -2147483628),
			new Point(-2147483638, -2147483628),
			new Point(-2147483634, -2147483636),
			new Point(-2147483632, -2147483630),
			new Point(-2147483634, -2147483630)
		};
		ushort_44 = new ushort[21]
		{
			3, 24576, 32768, 3, 24576, 33025, 3, 24576, 33030, 3,
			24576, 33026, 3, 24576, 33029, 4, 24576, 33026, 2, 24576,
			33030
		};
		struct15_34 = new Struct15[21]
		{
			new Struct15(8192, 327, 0, 0),
			new Struct15(24576, 320, 327, 0),
			new Struct15(24576, 321, 327, 0),
			new Struct15(40960, 322, 0, 327),
			new Struct15(40960, 323, 0, 327),
			new Struct15(32768, 8000, 0, 327),
			new Struct15(8193, 1029, 1, 8000),
			new Struct15(24576, 322, 320, 10800),
			new Struct15(24576, 323, 321, 10800),
			new Struct15(16385, -6350, 1030, 1),
			new Struct15(24576, 1033, 1031, 0),
			new Struct15(16385, -7830, 1030, 1),
			new Struct15(24576, 1035, 1032, 0),
			new Struct15(16385, 1690, 1030, 1),
			new Struct15(24576, 1037, 1031, 0),
			new Struct15(16385, 6350, 1030, 1),
			new Struct15(24576, 1039, 1031, 0),
			new Struct15(16385, -3810, 1030, 1),
			new Struct15(24576, 1041, 1032, 0),
			new Struct15(16385, 7830, 1030, 1),
			new Struct15(24576, 1043, 1032, 0)
		};
		class204_47 = new Class204(point_75, ushort_44, struct15_34, int_5, struct16_37, 21600, 21600, int.MinValue, int.MinValue, point_2);
		point_76 = new Point[32]
		{
			new Point(0, 0),
			new Point(21600, 0),
			new Point(21600, 21600),
			new Point(0, 21600),
			new Point(0, 0),
			new Point(21600, 0),
			new Point(-2147483645, -2147483646),
			new Point(-2147483647, -2147483646),
			new Point(21600, 0),
			new Point(21600, 21600),
			new Point(-2147483645, -2147483644),
			new Point(-2147483645, -2147483646),
			new Point(21600, 21600),
			new Point(0, 21600),
			new Point(-2147483647, -2147483644),
			new Point(-2147483645, -2147483644),
			new Point(0, 21600),
			new Point(0, 0),
			new Point(-2147483647, -2147483646),
			new Point(-2147483647, -2147483644),
			new Point(-2147483638, -2147483636),
			new Point(-2147483634, -2147483636),
			new Point(-2147483632, -2147483630),
			new Point(-2147483632, -2147483628),
			new Point(-2147483634, -2147483626),
			new Point(-2147483638, -2147483626),
			new Point(-2147483624, 10800),
			new Point(-2147483622, 10800),
			new Point(-2147483624, -2147483636),
			new Point(-2147483622, -2147483620),
			new Point(-2147483624, -2147483626),
			new Point(-2147483622, -2147483618)
		};
		ushort_45 = new ushort[24]
		{
			3, 24576, 32768, 3, 24576, 33025, 3, 24576, 33030, 3,
			24576, 33026, 3, 24576, 33029, 5, 24576, 33030, 1, 33030,
			1, 33030, 1, 33030
		};
		struct15_35 = new Struct15[31]
		{
			new Struct15(8192, 327, 0, 0),
			new Struct15(24576, 320, 327, 0),
			new Struct15(24576, 321, 327, 0),
			new Struct15(40960, 322, 0, 327),
			new Struct15(40960, 323, 0, 327),
			new Struct15(32768, 8000, 0, 327),
			new Struct15(8193, 1029, 1, 8000),
			new Struct15(24576, 322, 320, 10800),
			new Struct15(24576, 323, 321, 10800),
			new Struct15(16385, -8050, 1030, 1),
			new Struct15(24576, 1033, 1031, 0),
			new Struct15(16385, -2750, 1030, 1),
			new Struct15(24576, 1035, 1032, 0),
			new Struct15(16385, -2960, 1030, 1),
			new Struct15(24576, 1037, 1031, 0),
			new Struct15(16385, 2120, 1030, 1),
			new Struct15(24576, 1039, 1031, 0),
			new Struct15(16385, -8050, 1030, 1),
			new Struct15(24576, 1041, 1032, 0),
			new Struct15(16385, 8050, 1030, 1),
			new Struct15(24576, 1043, 1032, 0),
			new Struct15(16385, 2750, 1030, 1),
			new Struct15(24576, 1045, 1032, 0),
			new Struct15(16385, 4020, 1030, 1),
			new Struct15(24576, 1047, 1031, 0),
			new Struct15(16385, 8050, 1030, 1),
			new Struct15(24576, 1049, 1031, 0),
			new Struct15(16385, -5930, 1030, 1),
			new Struct15(24576, 1051, 1032, 0),
			new Struct15(16385, 5930, 1030, 1),
			new Struct15(24576, 1053, 1032, 0)
		};
		class204_48 = new Class204(point_76, ushort_45, struct15_35, int_5, struct16_37, 21600, 21600, int.MinValue, int.MinValue, point_2);
		point_77 = new Point[39]
		{
			new Point(0, 0),
			new Point(21600, 0),
			new Point(21600, 21600),
			new Point(0, 21600),
			new Point(0, 0),
			new Point(21600, 0),
			new Point(-2147483645, -2147483646),
			new Point(-2147483647, -2147483646),
			new Point(21600, 0),
			new Point(21600, 21600),
			new Point(-2147483645, -2147483644),
			new Point(-2147483645, -2147483646),
			new Point(21600, 21600),
			new Point(0, 21600),
			new Point(-2147483647, -2147483644),
			new Point(-2147483645, -2147483644),
			new Point(0, 21600),
			new Point(0, 0),
			new Point(-2147483647, -2147483646),
			new Point(-2147483647, -2147483644),
			new Point(-2147483638, -2147483636),
			new Point(-2147483634, -2147483636),
			new Point(-2147483632, -2147483630),
			new Point(-2147483628, -2147483630),
			new Point(-2147483626, -2147483624),
			new Point(-2147483626, -2147483622),
			new Point(-2147483620, -2147483622),
			new Point(-2147483618, -2147483624),
			new Point(-2147483616, -2147483624),
			new Point(-2147483616, -2147483614),
			new Point(-2147483618, -2147483614),
			new Point(-2147483620, -2147483612),
			new Point(-2147483626, -2147483612),
			new Point(-2147483626, -2147483610),
			new Point(-2147483606, -2147483610),
			new Point(-2147483606, -2147483608),
			new Point(-2147483632, -2147483608),
			new Point(-2147483634, -2147483604),
			new Point(-2147483638, -2147483604)
		};
		ushort_46 = new ushort[18]
		{
			3, 24576, 32768, 3, 24576, 33025, 3, 24576, 33030, 3,
			24576, 33026, 3, 24576, 33029, 18, 24576, 33030
		};
		struct15_36 = new Struct15[45]
		{
			new Struct15(8192, 327, 0, 0),
			new Struct15(24576, 320, 327, 0),
			new Struct15(24576, 321, 327, 0),
			new Struct15(40960, 322, 0, 327),
			new Struct15(40960, 323, 0, 327),
			new Struct15(32768, 8000, 0, 327),
			new Struct15(8193, 1029, 1, 8000),
			new Struct15(24576, 322, 320, 10800),
			new Struct15(24576, 323, 321, 10800),
			new Struct15(16385, -8050, 1030, 1),
			new Struct15(24576, 1033, 1031, 0),
			new Struct15(16385, -4020, 1030, 1),
			new Struct15(24576, 1035, 1032, 0),
			new Struct15(16385, -7000, 1030, 1),
			new Struct15(24576, 1037, 1031, 0),
			new Struct15(16385, -6560, 1030, 1),
			new Struct15(24576, 1039, 1031, 0),
			new Struct15(16385, -3600, 1030, 1),
			new Struct15(24576, 1041, 1032, 0),
			new Struct15(16385, 4020, 1030, 1),
			new Struct15(24576, 1043, 1031, 0),
			new Struct15(16385, 4660, 1030, 1),
			new Struct15(24576, 1045, 1031, 0),
			new Struct15(16385, -2960, 1030, 1),
			new Struct15(24576, 1047, 1032, 0),
			new Struct15(16385, -2330, 1030, 1),
			new Struct15(24576, 1049, 1032, 0),
			new Struct15(16385, 6780, 1030, 1),
			new Struct15(24576, 1051, 1031, 0),
			new Struct15(16385, 7200, 1030, 1),
			new Struct15(24576, 1053, 1031, 0),
			new Struct15(16385, 8050, 1030, 1),
			new Struct15(24576, 1055, 1031, 0),
			new Struct15(16385, 2960, 1030, 1),
			new Struct15(24576, 1057, 1032, 0),
			new Struct15(16385, 2330, 1030, 1),
			new Struct15(24576, 1059, 1032, 0),
			new Struct15(16385, 3800, 1030, 1),
			new Struct15(24576, 1061, 1032, 0),
			new Struct15(16385, -1060, 1030, 1),
			new Struct15(24576, 1063, 1032, 0),
			new Struct15(16385, -6350, 1030, 1),
			new Struct15(24576, 1065, 1031, 0),
			new Struct15(16385, -640, 1030, 1),
			new Struct15(24576, 1067, 1032, 0)
		};
		class204_49 = new Class204(point_77, ushort_46, struct15_36, int_5, struct16_37, 21600, 21600, int.MinValue, int.MinValue, point_2);
	}
}
