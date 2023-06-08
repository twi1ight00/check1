using System;
using System.Collections;
using System.Text;
using ns183;
using ns211;

namespace ns210;

internal class Class5566 : Class5563
{
	internal class Class5605
	{
		public static int int_0 = 1;

		public static int int_1 = 2;

		public static int int_2 = 4;

		public static int int_3 = 8;

		public static int int_4 = 16;

		public static int int_5 = 32;

		public static int int_6 = 64;

		public static int int_7 = 128;

		public static int int_8 = 0;

		public static int int_9 = 1;

		public static int int_10 = 2;

		public static int int_11 = 3;

		private int int_12;

		private int int_13;

		private int int_14;

		private int int_15;

		private Class5604 class5604_0;

		private Class5604 class5604_1;

		private Class5604 class5604_2;

		private Class5604 class5604_3;

		public Class5605(int xPlacement, int yPlacement, int xAdvance, int yAdvance, Class5604 xPlaDevice, Class5604 yPlaDevice, Class5604 xAdvDevice, Class5604 yAdvDevice)
		{
			int_12 = xPlacement;
			int_13 = yPlacement;
			int_14 = xAdvance;
			int_15 = yAdvance;
			class5604_0 = xPlaDevice;
			class5604_1 = yPlaDevice;
			class5604_2 = xAdvDevice;
			class5604_3 = yAdvDevice;
		}

		public int method_0()
		{
			return int_12;
		}

		public int method_1()
		{
			return int_13;
		}

		public int method_2()
		{
			return int_14;
		}

		public int method_3()
		{
			return int_15;
		}

		public Class5604 method_4()
		{
			return class5604_0;
		}

		public Class5604 method_5()
		{
			return class5604_1;
		}

		public Class5604 method_6()
		{
			return class5604_2;
		}

		public Class5604 method_7()
		{
			return class5604_3;
		}

		public void method_8(int xPlacement, int yPlacement, int xAdvance, int yAdvance)
		{
			int_12 += xPlacement;
			int_13 += yPlacement;
			int_14 += xAdvance;
			int_15 += yAdvance;
		}

		public bool method_9(int[] adjustments, int fontSize)
		{
			bool result = false;
			int num;
			if ((num = int_12) != 0)
			{
				adjustments[int_8] += num;
				result = true;
			}
			if ((num = int_13) != 0)
			{
				adjustments[int_9] += num;
				result = true;
			}
			if ((num = int_14) != 0)
			{
				adjustments[int_10] += num;
				result = true;
			}
			if ((num = int_15) != 0)
			{
				adjustments[int_11] += num;
				result = true;
			}
			if (fontSize != 0)
			{
				Class5604 @class;
				if ((@class = class5604_0) != null && (num = @class.method_3(fontSize)) != 0)
				{
					adjustments[int_8] += num;
					result = true;
				}
				if ((@class = class5604_1) != null && (num = @class.method_3(fontSize)) != 0)
				{
					adjustments[int_9] += num;
					result = true;
				}
				if ((@class = class5604_2) != null && (num = @class.method_3(fontSize)) != 0)
				{
					adjustments[int_10] += num;
					result = true;
				}
				if ((@class = class5604_3) != null && (num = @class.method_3(fontSize)) != 0)
				{
					adjustments[int_11] += num;
					result = true;
				}
			}
			return result;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			bool flag = true;
			stringBuilder.Append("{ ");
			if (int_12 != 0)
			{
				if (!flag)
				{
					stringBuilder.Append(", ");
				}
				else
				{
					flag = false;
				}
				stringBuilder.Append("xPlacement = " + int_12);
			}
			if (int_13 != 0)
			{
				if (!flag)
				{
					stringBuilder.Append(", ");
				}
				else
				{
					flag = false;
				}
				stringBuilder.Append("yPlacement = " + int_13);
			}
			if (int_14 != 0)
			{
				if (!flag)
				{
					stringBuilder.Append(", ");
				}
				else
				{
					flag = false;
				}
				stringBuilder.Append("xAdvance = " + int_14);
			}
			if (int_15 != 0)
			{
				if (!flag)
				{
					stringBuilder.Append(", ");
				}
				else
				{
					flag = false;
				}
				stringBuilder.Append("yAdvance = " + int_15);
			}
			if (class5604_0 != null)
			{
				if (!flag)
				{
					stringBuilder.Append(", ");
				}
				else
				{
					flag = false;
				}
				stringBuilder.Append("xPlaDevice = " + class5604_0);
			}
			if (class5604_1 != null)
			{
				if (!flag)
				{
					stringBuilder.Append(", ");
				}
				else
				{
					flag = false;
				}
				stringBuilder.Append("xPlaDevice = " + class5604_1);
			}
			if (class5604_2 != null)
			{
				if (!flag)
				{
					stringBuilder.Append(", ");
				}
				else
				{
					flag = false;
				}
				stringBuilder.Append("xAdvDevice = " + class5604_2);
			}
			if (class5604_3 != null)
			{
				if (!flag)
				{
					stringBuilder.Append(", ");
				}
				else
				{
					flag = false;
				}
				stringBuilder.Append("xAdvDevice = " + class5604_3);
			}
			stringBuilder.Append(" }");
			return stringBuilder.ToString();
		}
	}

	private abstract class Class5521 : Class5520
	{
		internal Class5521(string id, int sequence, int flags, int format, Class5508 coverage, ArrayList entries)
			: base(id, sequence, flags, format, coverage)
		{
		}

		public override int vmethod_1()
		{
			return 1;
		}

		public override bool vmethod_3(Class5510 subtable)
		{
			return subtable is Class5521;
		}

		public override bool imethod_0(Class5581 ps)
		{
			int num = ps.method_22();
			int ci;
			if ((ci = method_9(num)) < 0)
			{
				return false;
			}
			Class5605 @class = vmethod_7(ci, num);
			if (@class != null)
			{
				if (ps.method_59(@class))
				{
					ps.method_65(adjusted: true);
				}
				ps.method_18(1);
			}
			return true;
		}

		public abstract Class5605 vmethod_7(int ci, int gi);

		internal static Class5520 smethod_4(string id, int sequence, int flags, int format, Class5508 coverage, ArrayList entries)
		{
			return format switch
			{
				1 => new Class5522(id, sequence, flags, format, coverage, entries), 
				2 => new Class5523(id, sequence, flags, format, coverage, entries), 
				_ => throw new NotSupportedException(), 
			};
		}
	}

	private class Class5522 : Class5521
	{
		private Class5605 class5605_0;

		private int int_11;

		internal Class5522(string id, int sequence, int flags, int format, Class5508 coverage, ArrayList entries)
			: base(id, sequence, flags, format, coverage, entries)
		{
			method_13(entries);
		}

		public override ArrayList vmethod_5()
		{
			if (class5605_0 != null)
			{
				ArrayList arrayList = new ArrayList(1);
				arrayList.Add(class5605_0);
				return arrayList;
			}
			return null;
		}

		public override Class5605 vmethod_7(int ci, int gi)
		{
			if (class5605_0 != null && ci <= int_11)
			{
				return class5605_0;
			}
			return null;
		}

		private void method_13(ArrayList entries)
		{
			if (entries != null && entries.Count == 1)
			{
				object obj = entries[0];
				if (!(obj is Class5605))
				{
					throw new Exception("illegal entries entry, must be Value, but is: " + obj?.GetType());
				}
				Class5605 @class = (Class5605)obj;
				class5605_0 = @class;
				int_11 = method_10() - 1;
				return;
			}
			throw new Exception("illegal entries, must be non-null and contain exactly one entry");
		}
	}

	private class Class5523 : Class5521
	{
		private Class5605[] class5605_0;

		internal Class5523(string id, int sequence, int flags, int format, Class5508 coverage, ArrayList entries)
			: base(id, sequence, flags, format, coverage, entries)
		{
			method_13(entries);
		}

		public override ArrayList vmethod_5()
		{
			if (class5605_0 != null)
			{
				ArrayList arrayList = new ArrayList(class5605_0.Length);
				int i = 0;
				for (int num = class5605_0.Length; i < num; i++)
				{
					arrayList.Add(class5605_0[i]);
				}
				return arrayList;
			}
			return null;
		}

		public override Class5605 vmethod_7(int ci, int gi)
		{
			if (class5605_0 != null && ci < class5605_0.Length)
			{
				return class5605_0[ci];
			}
			return null;
		}

		private void method_13(ArrayList entries)
		{
			if (entries == null)
			{
				throw new Exception("illegal entries, must be non-null");
			}
			if (entries.Count != 1)
			{
				throw new Exception("illegal entries, " + entries.Count + " entries present, but requires 1 entry");
			}
			object obj;
			if ((obj = entries[0]) != null && obj is Class5605[])
			{
				Class5605[] array = (Class5605[])obj;
				if (array.Length != method_10())
				{
					throw new Exception("illegal values array, " + entries.Count + " values present, but requires " + method_10() + " values");
				}
				class5605_0 = array;
				return;
			}
			throw new Exception("illegal entries, single entry must be a Value[], but is: " + obj?.GetType());
		}
	}

	private abstract class Class5524 : Class5520
	{
		internal Class5524(string id, int sequence, int flags, int format, Class5508 coverage, ArrayList entries)
			: base(id, sequence, flags, format, coverage)
		{
		}

		public override int vmethod_1()
		{
			return 2;
		}

		public override bool vmethod_3(Class5510 subtable)
		{
			return subtable is Class5524;
		}

		public override bool imethod_0(Class5581 ps)
		{
			bool result = false;
			int gid = ps.method_21(0);
			int ci;
			if ((ci = method_9(gid)) >= 0)
			{
				int[] array = ps.method_37(0);
				int num = array[0];
				if (num > 1)
				{
					int[] array2 = ps.method_29(0, 2, null, array);
					if (array2 != null && array2.Length == 2)
					{
						Class5606 @class = vmethod_7(ci, array2[0], array2[1]);
						if (@class != null)
						{
							Class5605 class2 = @class.method_1();
							if (class2 != null && ps.method_60(class2, 0))
							{
								ps.method_65(adjusted: true);
							}
							Class5605 class3 = @class.method_2();
							if (class3 != null && ps.method_60(class3, 1))
							{
								ps.method_65(adjusted: true);
							}
							ps.method_18(array[0] + array[1]);
							result = true;
						}
					}
				}
			}
			return result;
		}

		public abstract Class5606 vmethod_7(int ci, int gi1, int gi2);

		internal static Class5520 smethod_4(string id, int sequence, int flags, int format, Class5508 coverage, ArrayList entries)
		{
			return format switch
			{
				1 => new Class5525(id, sequence, flags, format, coverage, entries), 
				2 => new Class5526(id, sequence, flags, format, coverage, entries), 
				_ => throw new Exception(), 
			};
		}
	}

	internal class Class5606
	{
		private int int_0;

		private Class5605 class5605_0;

		private Class5605 class5605_1;

		public Class5606(int glyph, Class5605 value1, Class5605 value2)
		{
			int_0 = glyph;
			class5605_0 = value1;
			class5605_1 = value2;
		}

		public int method_0()
		{
			return int_0;
		}

		public Class5605 method_1()
		{
			return class5605_0;
		}

		public Class5605 method_2()
		{
			return class5605_1;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			bool flag = true;
			stringBuilder.Append("{ ");
			if (int_0 != 0)
			{
				if (!flag)
				{
					stringBuilder.Append(", ");
				}
				else
				{
					flag = false;
				}
				stringBuilder.Append("glyph = " + int_0);
			}
			if (class5605_0 != null)
			{
				if (!flag)
				{
					stringBuilder.Append(", ");
				}
				else
				{
					flag = false;
				}
				stringBuilder.Append("value1 = " + class5605_0);
			}
			if (class5605_1 != null)
			{
				if (!flag)
				{
					stringBuilder.Append(", ");
				}
				else
				{
					flag = false;
				}
				stringBuilder.Append("value2 = " + class5605_1);
			}
			stringBuilder.Append(" }");
			return stringBuilder.ToString();
		}
	}

	private class Class5525 : Class5524
	{
		private Class5606[][] class5606_0;

		internal Class5525(string id, int sequence, int flags, int format, Class5508 coverage, ArrayList entries)
			: base(id, sequence, flags, format, coverage, entries)
		{
			method_13(entries);
		}

		public override ArrayList vmethod_5()
		{
			if (class5606_0 != null)
			{
				ArrayList arrayList = new ArrayList(1);
				arrayList.Add(class5606_0);
				return arrayList;
			}
			return null;
		}

		public override Class5606 vmethod_7(int ci, int gi1, int gi2)
		{
			if (class5606_0 != null && ci < class5606_0.Length)
			{
				Class5606[] array = class5606_0[ci];
				int i = 0;
				for (int num = array.Length; i < num; i++)
				{
					Class5606 @class = array[i];
					if (@class == null)
					{
						continue;
					}
					int num2 = @class.method_0();
					if (num2 >= gi2)
					{
						if (num2 != gi2)
						{
							break;
						}
						return @class;
					}
				}
			}
			return null;
		}

		private void method_13(ArrayList entries)
		{
			if (entries == null)
			{
				throw new Exception("illegal entries, must be non-null");
			}
			if (entries.Count != 1)
			{
				throw new Exception("illegal entries, " + entries.Count + " entries present, but requires 1 entry");
			}
			object obj;
			if ((obj = entries[0]) == null || !(obj is Class5606[][]))
			{
				throw new Exception("illegal entries, first (and only) entry must be a PairValues[][], but is: " + obj?.GetType());
			}
			class5606_0 = (Class5606[][])obj;
		}
	}

	private class Class5526 : Class5524
	{
		private Class5507 class5507_0;

		private Class5507 class5507_1;

		private int int_11;

		private int int_12;

		private Class5606[][] class5606_0;

		internal Class5526(string id, int sequence, int flags, int format, Class5508 coverage, ArrayList entries)
			: base(id, sequence, flags, format, coverage, entries)
		{
			method_13(entries);
		}

		public override ArrayList vmethod_5()
		{
			if (class5606_0 != null)
			{
				ArrayList arrayList = new ArrayList(5);
				arrayList.Add(class5507_0);
				arrayList.Add(class5507_1);
				arrayList.Add(int_11);
				arrayList.Add(int_12);
				arrayList.Add(class5606_0);
				return arrayList;
			}
			return null;
		}

		public override Class5606 vmethod_7(int ci, int gi1, int gi2)
		{
			if (class5606_0 != null)
			{
				int num = class5507_0.imethod_1(gi1, 0);
				if (num >= 0 && num < int_11 && num < class5606_0.Length)
				{
					Class5606[] array = class5606_0[num];
					if (array != null)
					{
						int num2 = class5507_1.imethod_1(gi2, 0);
						if (num2 >= 0 && num2 < int_12 && num2 < array.Length)
						{
							return array[num2];
						}
					}
				}
			}
			return null;
		}

		private void method_13(ArrayList entries)
		{
			if (entries == null)
			{
				throw new Exception("illegal entries, must be non-null");
			}
			if (entries.Count != 5)
			{
				throw new Exception("illegal entries, " + entries.Count + " entries present, but requires 5 entries");
			}
			object obj;
			if ((obj = entries[0]) != null && obj is Class5507)
			{
				class5507_0 = (Class5507)obj;
				if ((obj = entries[1]) != null && obj is Class5507)
				{
					class5507_1 = (Class5507)obj;
					if ((obj = entries[2]) != null && obj is int)
					{
						int_11 = (int)obj;
						if ((obj = entries[3]) != null && obj is int)
						{
							int_12 = (int)obj;
							if ((obj = entries[4]) == null || !(obj is Class5606[][]))
							{
								throw new Exception("illegal entries, fifth entry must be a PairValues[][], but is: " + obj?.GetType());
							}
							class5606_0 = (Class5606[][])obj;
							return;
						}
						throw new Exception("illegal entries, fourth entry must be an Integer, but is: " + obj?.GetType());
					}
					throw new Exception("illegal entries, third entry must be an Integer, but is: " + obj?.GetType());
				}
				throw new Exception("illegal entries, second entry must be an GlyphClassTable, but is: " + obj?.GetType());
			}
			throw new Exception("illegal entries, first entry must be an GlyphClassTable, but is: " + obj?.GetType());
		}
	}

	private abstract class Class5527 : Class5520
	{
		internal Class5527(string id, int sequence, int flags, int format, Class5508 coverage, ArrayList entries)
			: base(id, sequence, flags, format, coverage)
		{
		}

		public override int vmethod_1()
		{
			return 3;
		}

		public override bool vmethod_3(Class5510 subtable)
		{
			return subtable is Class5527;
		}

		public override bool imethod_0(Class5581 ps)
		{
			bool result = false;
			int gid = ps.method_21(0);
			int num;
			if ((num = method_9(gid)) >= 0)
			{
				int[] array = ps.method_37(0);
				int num2 = array[0];
				if (num2 > 1)
				{
					int[] array2 = ps.method_29(0, 2, null, array);
					if (array2 != null && array2.Length == 2)
					{
						int ci = num;
						int num3 = array2[1];
						int ci2 = method_9(num3);
						Class5607[] array3 = vmethod_7(ci, ci2);
						if (array3 != null)
						{
							Class5607 @class = array3[0];
							Class5607 class2 = array3[1];
							int num4 = ps.method_58(num3);
							if (@class != null && class2 != null)
							{
								Class5605 class3 = class2.method_5(@class);
								class3.method_8(-num4, 0, 0, 0);
								if (ps.method_59(class3))
								{
									ps.method_65(adjusted: true);
								}
							}
							ps.method_18(1);
							result = true;
						}
					}
				}
			}
			return result;
		}

		public abstract Class5607[] vmethod_7(int ci1, int ci2);

		internal static Class5520 smethod_4(string id, int sequence, int flags, int format, Class5508 coverage, ArrayList entries)
		{
			if (format != 1)
			{
				throw new NotSupportedException();
			}
			return new Class5528(id, sequence, flags, format, coverage, entries);
		}
	}

	internal class Class5607
	{
		private int int_0;

		private int int_1;

		private int int_2;

		private Class5604 class5604_0;

		private Class5604 class5604_1;

		public Class5607(int x, int y)
			: this(x, y, -1, null, null)
		{
		}

		public Class5607(int x, int y, int anchorPoint)
			: this(x, y, anchorPoint, null, null)
		{
		}

		public Class5607(int x, int y, Class5604 xDevice, Class5604 yDevice)
			: this(x, y, -1, xDevice, yDevice)
		{
		}

		protected Class5607(Class5607 a)
			: this(a.int_0, a.int_1, a.int_2, a.class5604_0, a.class5604_1)
		{
		}

		private Class5607(int x, int y, int anchorPoint, Class5604 xDevice, Class5604 yDevice)
		{
			int_0 = x;
			int_1 = y;
			int_2 = anchorPoint;
			class5604_0 = xDevice;
			class5604_1 = yDevice;
		}

		public int method_0()
		{
			return int_0;
		}

		public int method_1()
		{
			return int_1;
		}

		public int method_2()
		{
			return int_2;
		}

		public Class5604 method_3()
		{
			return class5604_0;
		}

		public Class5604 method_4()
		{
			return class5604_1;
		}

		public Class5605 method_5(Class5607 a)
		{
			return new Class5605(int_0 - a.int_0, int_1 - a.int_1, 0, 0, null, null, null, null);
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("{ [" + int_0 + "," + int_1 + "]");
			if (int_2 != -1)
			{
				stringBuilder.Append(", anchorPoint = " + int_2);
			}
			if (class5604_0 != null)
			{
				stringBuilder.Append(", xDevice = " + class5604_0);
			}
			if (class5604_1 != null)
			{
				stringBuilder.Append(", yDevice = " + class5604_1);
			}
			stringBuilder.Append(" }");
			return stringBuilder.ToString();
		}
	}

	private class Class5528 : Class5527
	{
		private Class5607[] class5607_0;

		internal Class5528(string id, int sequence, int flags, int format, Class5508 coverage, ArrayList entries)
			: base(id, sequence, flags, format, coverage, entries)
		{
			method_13(entries);
		}

		public override ArrayList vmethod_5()
		{
			if (class5607_0 != null)
			{
				ArrayList arrayList = new ArrayList(1);
				arrayList.Add(class5607_0);
				return arrayList;
			}
			return null;
		}

		public override Class5607[] vmethod_7(int ci1, int ci2)
		{
			if (ci1 >= 0 && ci2 >= 0)
			{
				int num = ci1 * 2 + 1;
				int num2 = ci2 * 2;
				if (class5607_0 != null && num < class5607_0.Length && num2 < class5607_0.Length)
				{
					Class5607 @class = class5607_0[num];
					Class5607 class2 = class5607_0[num2];
					if (@class != null && class2 != null)
					{
						return new Class5607[2] { @class, class2 };
					}
				}
			}
			return null;
		}

		private void method_13(ArrayList entries)
		{
			if (entries == null)
			{
				throw new Exception("illegal entries, must be non-null");
			}
			if (entries.Count != 1)
			{
				throw new Exception("illegal entries, " + entries.Count + " entries present, but requires 1 entry");
			}
			object obj;
			if ((obj = entries[0]) != null && obj is Class5607[])
			{
				if (((Class5607[])obj).Length % 2 != 0)
				{
					throw new Exception("illegal entries, Anchor[] array must have an even number of entries, but has: " + ((Class5607[])obj).Length);
				}
				class5607_0 = (Class5607[])obj;
				return;
			}
			throw new Exception("illegal entries, first (and only) entry must be a Anchor[], but is: " + obj?.GetType());
		}
	}

	private abstract class Class5529 : Class5520
	{
		internal Class5529(string id, int sequence, int flags, int format, Class5508 coverage, ArrayList entries)
			: base(id, sequence, flags, format, coverage)
		{
		}

		public override int vmethod_1()
		{
			return 4;
		}

		public override bool vmethod_3(Class5510 subtable)
		{
			return subtable is Class5529;
		}

		public override bool imethod_0(Class5581 ps)
		{
			bool result = false;
			int num = ps.method_22();
			int ciMark;
			if ((ciMark = method_9(num)) >= 0)
			{
				Class5608 @class = vmethod_7(ciMark, num);
				if (@class != null)
				{
					int i = 0;
					for (int num2 = ps.method_9(); i < num2; i++)
					{
						int num3 = ps.method_21(-(i + 1));
						if (ps.method_52(num3))
						{
							continue;
						}
						Class5607 class2 = vmethod_8(num3, @class.method_6());
						if (class2 != null)
						{
							Class5605 class3 = class2.method_5(@class);
							int[] array = ps.method_61();
							if (array[2] == 0)
							{
								class3.method_8(0, 0, -ps.method_58(num), 0);
							}
							if (ps.method_59(class3))
							{
								ps.method_65(adjusted: true);
							}
						}
						ps.method_18(1);
						result = true;
						break;
					}
				}
			}
			return result;
		}

		public abstract Class5608 vmethod_7(int ciMark, int giMark);

		public abstract Class5607 vmethod_8(int giBase, int markClass);

		internal static Class5520 smethod_4(string id, int sequence, int flags, int format, Class5508 coverage, ArrayList entries)
		{
			if (format != 1)
			{
				throw new NotSupportedException();
			}
			return new Class5530(id, sequence, flags, format, coverage, entries);
		}
	}

	internal class Class5608 : Class5607
	{
		private int int_3;

		public Class5608(int markClass, Class5607 a)
			: base(a)
		{
			int_3 = markClass;
		}

		public int method_6()
		{
			return int_3;
		}

		public override string ToString()
		{
			return "{ markClass = " + int_3 + ", anchor = " + base.ToString() + " }";
		}
	}

	private class Class5530 : Class5529
	{
		private Class5508 class5508_0;

		private int int_11;

		private Class5608[] class5608_0;

		private Class5607[][] class5607_0;

		internal Class5530(string id, int sequence, int flags, int format, Class5508 coverage, ArrayList entries)
			: base(id, sequence, flags, format, coverage, entries)
		{
			method_13(entries);
		}

		public override ArrayList vmethod_5()
		{
			if (class5508_0 != null && class5608_0 != null && int_11 > 0 && class5607_0 != null)
			{
				ArrayList arrayList = new ArrayList(4);
				arrayList.Add(class5508_0);
				arrayList.Add(int_11);
				arrayList.Add(class5608_0);
				arrayList.Add(class5607_0);
				return arrayList;
			}
			return null;
		}

		public override Class5608 vmethod_7(int ciMark, int giMark)
		{
			if (class5608_0 != null && ciMark < class5608_0.Length)
			{
				return class5608_0[ciMark];
			}
			return null;
		}

		public override Class5607 vmethod_8(int giBase, int markClass)
		{
			int num;
			if (class5508_0 != null && (num = class5508_0.imethod_1(giBase)) >= 0 && class5607_0 != null && num < class5607_0.Length)
			{
				Class5607[] array = class5607_0[num];
				if (array != null && markClass < array.Length)
				{
					return array[markClass];
				}
			}
			return null;
		}

		private void method_13(ArrayList entries)
		{
			if (entries == null)
			{
				throw new Exception("illegal entries, must be non-null");
			}
			if (entries.Count != 4)
			{
				throw new Exception("illegal entries, " + entries.Count + " entries present, but requires 4 entries");
			}
			object obj;
			if ((obj = entries[0]) != null && obj is Class5508)
			{
				class5508_0 = (Class5508)obj;
				if ((obj = entries[1]) != null && obj is int)
				{
					int_11 = (int)obj;
					if ((obj = entries[2]) != null && obj is Class5608[])
					{
						class5608_0 = (Class5608[])obj;
						if ((obj = entries[3]) == null || !(obj is Class5607[][]))
						{
							throw new Exception("illegal entries, fourth entry must be a Anchor[][], but is: " + obj?.GetType());
						}
						class5607_0 = (Class5607[][])obj;
						return;
					}
					throw new Exception("illegal entries, third entry must be a MarkAnchor[], but is: " + obj?.GetType());
				}
				throw new Exception("illegal entries, second entry must be an Integer, but is: " + obj?.GetType());
			}
			throw new Exception("illegal entries, first entry must be an GlyphCoverageTable, but is: " + obj?.GetType());
		}
	}

	private abstract class Class5531 : Class5520
	{
		internal Class5531(string id, int sequence, int flags, int format, Class5508 coverage, ArrayList entries)
			: base(id, sequence, flags, format, coverage)
		{
		}

		public override int vmethod_1()
		{
			return 5;
		}

		public override bool vmethod_3(Class5510 subtable)
		{
			return subtable is Class5531;
		}

		public override bool imethod_0(Class5581 ps)
		{
			bool result = false;
			int num = ps.method_22();
			int ciMark;
			if ((ciMark = method_9(num)) >= 0)
			{
				Class5608 @class = vmethod_7(ciMark, num);
				int maxComponents = vmethod_8();
				if (@class != null)
				{
					int i = 0;
					for (int num2 = ps.method_9(); i < num2; i++)
					{
						int num3 = ps.method_21(-(i + 1));
						if (!ps.method_52(num3))
						{
							Class5607 class2 = vmethod_9(num3, maxComponents, i, @class.method_6());
							if (class2 != null && ps.method_59(class2.method_5(@class)))
							{
								ps.method_65(adjusted: true);
							}
							ps.method_18(1);
							result = true;
							break;
						}
					}
				}
			}
			return result;
		}

		public abstract Class5608 vmethod_7(int ciMark, int giMark);

		public abstract int vmethod_8();

		public abstract Class5607 vmethod_9(int giLig, int maxComponents, int component, int markClass);

		internal static Class5520 smethod_4(string id, int sequence, int flags, int format, Class5508 coverage, ArrayList entries)
		{
			if (format != 1)
			{
				throw new NotSupportedException();
			}
			return new Class5532(id, sequence, flags, format, coverage, entries);
		}
	}

	private class Class5532 : Class5531
	{
		private Class5508 class5508_0;

		private int int_11;

		private int int_12;

		private Class5608[] class5608_0;

		private Class5607[][][] class5607_0;

		internal Class5532(string id, int sequence, int flags, int format, Class5508 coverage, ArrayList entries)
			: base(id, sequence, flags, format, coverage, entries)
		{
			method_13(entries);
		}

		public override ArrayList vmethod_5()
		{
			if (class5607_0 != null)
			{
				ArrayList arrayList = new ArrayList(5);
				arrayList.Add(class5508_0);
				arrayList.Add(int_11);
				arrayList.Add(int_12);
				arrayList.Add(class5608_0);
				arrayList.Add(class5607_0);
				return arrayList;
			}
			return null;
		}

		public override Class5608 vmethod_7(int ciMark, int giMark)
		{
			if (class5608_0 != null && ciMark < class5608_0.Length)
			{
				return class5608_0[ciMark];
			}
			return null;
		}

		public override int vmethod_8()
		{
			return int_12;
		}

		public override Class5607 vmethod_9(int giLig, int maxComponents, int component, int markClass)
		{
			int num;
			if (class5508_0 != null && (num = class5508_0.imethod_1(giLig)) >= 0 && class5607_0 != null && num < class5607_0.Length)
			{
				Class5607[][] array = class5607_0[num];
				if (component < maxComponents)
				{
					Class5607[] array2 = array[component];
					if (array2 != null && markClass < array2.Length)
					{
						return array2[markClass];
					}
				}
			}
			return null;
		}

		private void method_13(ArrayList entries)
		{
			if (entries == null)
			{
				throw new Exception("illegal entries, must be non-null");
			}
			if (entries.Count != 5)
			{
				throw new Exception("illegal entries, " + entries.Count + " entries present, but requires 5 entries");
			}
			object obj;
			if ((obj = entries[0]) != null && obj is Class5508)
			{
				class5508_0 = (Class5508)obj;
				if ((obj = entries[1]) != null && obj is int)
				{
					int_11 = (int)obj;
					if ((obj = entries[2]) != null && obj is int)
					{
						int_12 = (int)obj;
						if ((obj = entries[3]) != null && obj is Class5608[])
						{
							class5608_0 = (Class5608[])obj;
							if ((obj = entries[4]) == null || !(obj is Class5607[][][]))
							{
								throw new Exception("illegal entries, fifth entry must be a Anchor[][][], but is: " + obj?.GetType());
							}
							class5607_0 = (Class5607[][][])obj;
							return;
						}
						throw new Exception("illegal entries, fourth entry must be a MarkAnchor[], but is: " + obj?.GetType());
					}
					throw new Exception("illegal entries, third entry must be an Integer, but is: " + obj?.GetType());
				}
				throw new Exception("illegal entries, second entry must be an Integer, but is: " + obj?.GetType());
			}
			throw new Exception("illegal entries, first entry must be an GlyphCoverageTable, but is: " + obj?.GetType());
		}
	}

	private abstract class Class5533 : Class5520
	{
		internal Class5533(string id, int sequence, int flags, int format, Class5508 coverage, ArrayList entries)
			: base(id, sequence, flags, format, coverage)
		{
		}

		public override int vmethod_1()
		{
			return 6;
		}

		public override bool vmethod_3(Class5510 subtable)
		{
			return subtable is Class5533;
		}

		public override bool imethod_0(Class5581 ps)
		{
			bool result = false;
			int num = ps.method_22();
			int ciMark;
			if ((ciMark = method_9(num)) >= 0)
			{
				Class5608 @class = vmethod_7(ciMark, num);
				if (@class != null && ps.method_15())
				{
					Class5607 class2 = vmethod_8(ps.method_21(-1), @class.method_6());
					if (class2 != null && ps.method_59(class2.method_5(@class)))
					{
						ps.method_65(adjusted: true);
					}
					ps.method_18(1);
					result = true;
				}
			}
			return result;
		}

		public abstract Class5608 vmethod_7(int ciMark1, int giMark1);

		public abstract Class5607 vmethod_8(int giBase, int markClass);

		internal static Class5520 smethod_4(string id, int sequence, int flags, int format, Class5508 coverage, ArrayList entries)
		{
			if (format != 1)
			{
				throw new NotSupportedException();
			}
			return new Class5534(id, sequence, flags, format, coverage, entries);
		}
	}

	private class Class5534 : Class5533
	{
		private Class5508 class5508_0;

		private int int_11;

		private Class5608[] class5608_0;

		private Class5607[][] class5607_0;

		internal Class5534(string id, int sequence, int flags, int format, Class5508 coverage, ArrayList entries)
			: base(id, sequence, flags, format, coverage, entries)
		{
			method_13(entries);
		}

		public override ArrayList vmethod_5()
		{
			if (class5508_0 != null && class5608_0 != null && int_11 > 0 && class5607_0 != null)
			{
				ArrayList arrayList = new ArrayList(4);
				arrayList.Add(class5508_0);
				arrayList.Add(int_11);
				arrayList.Add(class5608_0);
				arrayList.Add(class5607_0);
				return arrayList;
			}
			return null;
		}

		public override Class5608 vmethod_7(int ciMark1, int giMark1)
		{
			if (class5608_0 != null && ciMark1 < class5608_0.Length)
			{
				return class5608_0[ciMark1];
			}
			return null;
		}

		public override Class5607 vmethod_8(int giMark2, int markClass)
		{
			int num;
			if (class5508_0 != null && (num = class5508_0.imethod_1(giMark2)) >= 0 && class5607_0 != null && num < class5607_0.Length)
			{
				Class5607[] array = class5607_0[num];
				if (array != null && markClass < array.Length)
				{
					return array[markClass];
				}
			}
			return null;
		}

		private void method_13(ArrayList entries)
		{
			if (entries == null)
			{
				throw new Exception("illegal entries, must be non-null");
			}
			if (entries.Count != 4)
			{
				throw new Exception("illegal entries, " + entries.Count + " entries present, but requires 4 entries");
			}
			object obj;
			if ((obj = entries[0]) != null && obj is Class5508)
			{
				class5508_0 = (Class5508)obj;
				if ((obj = entries[1]) != null && obj is int)
				{
					int_11 = (int)obj;
					if ((obj = entries[2]) != null && obj is Class5608[])
					{
						class5608_0 = (Class5608[])obj;
						if ((obj = entries[3]) == null || !(obj is Class5607[][]))
						{
							throw new Exception("illegal entries, fourth entry must be a Anchor[][], but is: " + obj?.GetType());
						}
						class5607_0 = (Class5607[][])obj;
						return;
					}
					throw new Exception("illegal entries, third entry must be a MarkAnchor[], but is: " + obj?.GetType());
				}
				throw new Exception("illegal entries, second entry must be an Integer, but is: " + obj?.GetType());
			}
			throw new Exception("illegal entries, first entry must be an GlyphCoverageTable, but is: " + obj?.GetType());
		}
	}

	private abstract class Class5535 : Class5520
	{
		internal Class5535(string id, int sequence, int flags, int format, Class5508 coverage, ArrayList entries)
			: base(id, sequence, flags, format, coverage)
		{
		}

		public override int vmethod_1()
		{
			return 7;
		}

		public override bool vmethod_3(Class5510 subtable)
		{
			return subtable is Class5535;
		}

		public override bool imethod_0(Class5581 ps)
		{
			bool result = false;
			int num = ps.method_22();
			int ci;
			if ((ci = method_9(num)) >= 0)
			{
				int[] array = new int[1];
				Class5570[] array2 = vmethod_7(ci, num, ps, array);
				if (array2 != null)
				{
					ps.method_64(array2, array[0]);
					result = true;
				}
			}
			return result;
		}

		public abstract Class5570[] vmethod_7(int ci, int gi, Class5581 ps, int[] rv);

		internal static Class5520 smethod_4(string id, int sequence, int flags, int format, Class5508 coverage, ArrayList entries)
		{
			return format switch
			{
				1 => new Class5536(id, sequence, flags, format, coverage, entries), 
				2 => new Class5537(id, sequence, flags, format, coverage, entries), 
				3 => new Class5538(id, sequence, flags, format, coverage, entries), 
				_ => throw new NotSupportedException(), 
			};
		}
	}

	private class Class5536 : Class5535
	{
		private Class5578[] class5578_0;

		internal Class5536(string id, int sequence, int flags, int format, Class5508 coverage, ArrayList entries)
			: base(id, sequence, flags, format, coverage, entries)
		{
			method_13(entries);
		}

		public override ArrayList vmethod_5()
		{
			if (class5578_0 != null)
			{
				ArrayList arrayList = new ArrayList(1);
				arrayList.Add(class5578_0);
				return arrayList;
			}
			return null;
		}

		public override void vmethod_6(Hashtable lookupTables)
		{
			Class5563.smethod_1(class5578_0, lookupTables);
		}

		public override Class5570[] vmethod_7(int ci, int gi, Class5581 ps, int[] rv)
		{
			if (class5578_0.Length > 0)
			{
				Class5578 @class = class5578_0[0];
				if (@class != null)
				{
					Class5571[] array = @class.method_0();
					int i = 0;
					for (int num = array.Length; i < num; i++)
					{
						Class5571 class2 = array[i];
						if (class2 != null && class2 is Class5573)
						{
							Class5573 class3 = (Class5573)class2;
							int[] glyphs = class3.method_4(gi);
							if (smethod_5(ps, glyphs, 0, rv))
							{
								return class2.method_0();
							}
						}
					}
				}
			}
			return null;
		}

		internal static bool smethod_5(Class5581 ps, int[] glyphs, int offset, int[] rv)
		{
			if (glyphs != null && glyphs.Length != 0)
			{
				bool reverseOrder = offset < 0;
				Interface213 ignoreTester = ps.method_6();
				int[] array = ps.method_33(offset, reverseOrder, ignoreTester);
				int num = array[0];
				int num2 = glyphs.Length;
				if (num < num2)
				{
					return false;
				}
				int[] array2 = ps.method_26(offset, num2, reverseOrder, ignoreTester, null, array);
				int num3 = 0;
				while (true)
				{
					if (num3 < num2)
					{
						if (array2[num3] != glyphs[num3])
						{
							break;
						}
						num3++;
						continue;
					}
					if (rv != null)
					{
						rv[0] = array[0] + array[1];
					}
					return true;
				}
				return false;
			}
			return true;
		}

		private void method_13(ArrayList entries)
		{
			if (entries == null)
			{
				throw new Exception("illegal entries, must be non-null");
			}
			if (entries.Count != 1)
			{
				throw new Exception("illegal entries, " + entries.Count + " entries present, but requires 1 entry");
			}
			object obj;
			if ((obj = entries[0]) == null || !(obj is Class5578[]))
			{
				throw new Exception("illegal entries, first entry must be an RuleSet[], but is: " + obj?.GetType());
			}
			class5578_0 = (Class5578[])obj;
		}
	}

	private class Class5537 : Class5535
	{
		private Class5507 class5507_0;

		private int int_11;

		private Class5578[] class5578_0;

		internal Class5537(string id, int sequence, int flags, int format, Class5508 coverage, ArrayList entries)
			: base(id, sequence, flags, format, coverage, entries)
		{
			method_13(entries);
		}

		public override ArrayList vmethod_5()
		{
			if (class5578_0 != null)
			{
				ArrayList arrayList = new ArrayList(3);
				arrayList.Add(class5507_0);
				arrayList.Add(int_11);
				arrayList.Add(class5578_0);
				return arrayList;
			}
			return null;
		}

		public override void vmethod_6(Hashtable lookupTables)
		{
			Class5563.smethod_1(class5578_0, lookupTables);
		}

		public override Class5570[] vmethod_7(int ci, int gi, Class5581 ps, int[] rv)
		{
			if (class5578_0.Length > 0)
			{
				Class5578 @class = class5578_0[0];
				if (@class != null)
				{
					Class5571[] array = @class.method_0();
					int i = 0;
					for (int num = array.Length; i < num; i++)
					{
						Class5571 class2 = array[i];
						if (class2 != null && class2 is Class5575)
						{
							Class5575 class3 = (Class5575)class2;
							int[] classes = class3.method_4(class5507_0.imethod_1(gi, ps.method_4(gi)));
							if (smethod_5(ps, class5507_0, classes, 0, rv))
							{
								return class2.method_0();
							}
						}
					}
				}
			}
			return null;
		}

		internal static bool smethod_5(Class5581 ps, Class5507 cdt, int[] classes, int offset, int[] rv)
		{
			if (cdt != null && classes != null && classes.Length != 0)
			{
				bool reverseOrder = offset < 0;
				Interface213 ignoreTester = ps.method_6();
				int[] array = ps.method_33(offset, reverseOrder, ignoreTester);
				int num = array[0];
				int num2 = classes.Length;
				if (num < num2)
				{
					return false;
				}
				int[] array2 = ps.method_26(offset, num2, reverseOrder, ignoreTester, null, array);
				int num3 = 0;
				while (true)
				{
					if (num3 < num2)
					{
						int num4 = array2[num3];
						int set = ps.method_4(num4);
						int num5 = cdt.imethod_1(num4, set);
						if (num5 < 0 || num5 >= cdt.imethod_0(set))
						{
							break;
						}
						if (num5 == classes[num3])
						{
							num3++;
							continue;
						}
						return false;
					}
					if (rv != null)
					{
						rv[0] = array[0] + array[1];
					}
					return true;
				}
				return false;
			}
			return true;
		}

		private void method_13(ArrayList entries)
		{
			if (entries == null)
			{
				throw new Exception("illegal entries, must be non-null");
			}
			if (entries.Count != 3)
			{
				throw new Exception("illegal entries, " + entries.Count + " entries present, but requires 3 entries");
			}
			object obj;
			if ((obj = entries[0]) != null && obj is Class5507)
			{
				class5507_0 = (Class5507)obj;
				if ((obj = entries[1]) != null && obj is int)
				{
					int_11 = (int)obj;
					if ((obj = entries[2]) != null && obj is Class5578[])
					{
						class5578_0 = (Class5578[])obj;
						if (class5578_0.Length != int_11)
						{
							throw new Exception("illegal entries, RuleSet[] length is " + class5578_0.Length + ", but expected " + int_11 + " glyph classes");
						}
						return;
					}
					throw new Exception("illegal entries, third entry must be an RuleSet[], but is: " + obj?.GetType());
				}
				throw new Exception("illegal entries, second entry must be an Integer, but is: " + obj?.GetType());
			}
			throw new Exception("illegal entries, first entry must be an GlyphClassTable, but is: " + obj?.GetType());
		}
	}

	private class Class5538 : Class5535
	{
		private Class5578[] class5578_0;

		internal Class5538(string id, int sequence, int flags, int format, Class5508 coverage, ArrayList entries)
			: base(id, sequence, flags, format, coverage, entries)
		{
			method_13(entries);
		}

		public override ArrayList vmethod_5()
		{
			if (class5578_0 != null)
			{
				ArrayList arrayList = new ArrayList(1);
				arrayList.Add(class5578_0);
				return arrayList;
			}
			return null;
		}

		public override void vmethod_6(Hashtable lookupTables)
		{
			Class5563.smethod_1(class5578_0, lookupTables);
		}

		public override Class5570[] vmethod_7(int ci, int gi, Class5581 ps, int[] rv)
		{
			if (class5578_0.Length > 0)
			{
				Class5578 @class = class5578_0[0];
				if (@class != null)
				{
					Class5571[] array = @class.method_0();
					int i = 0;
					for (int num = array.Length; i < num; i++)
					{
						Class5571 class2 = array[i];
						if (class2 != null && class2 is Class5577)
						{
							Class5577 class3 = (Class5577)class2;
							Class5508[] gca = class3.method_3();
							if (smethod_5(ps, gca, 0, rv))
							{
								return class2.method_0();
							}
						}
					}
				}
			}
			return null;
		}

		internal static bool smethod_5(Class5581 ps, Class5508[] gca, int offset, int[] rv)
		{
			if (gca != null && gca.Length != 0)
			{
				bool reverseOrder = offset < 0;
				Interface213 ignoreTester = ps.method_6();
				int[] array = ps.method_33(offset, reverseOrder, ignoreTester);
				int num = array[0];
				int num2 = gca.Length;
				if (num < num2)
				{
					return false;
				}
				int[] array2 = ps.method_26(offset, num2, reverseOrder, ignoreTester, null, array);
				int num3 = 0;
				while (true)
				{
					if (num3 < num2)
					{
						Class5508 @class = gca[num3];
						if (@class != null && @class.imethod_1(array2[num3]) < 0)
						{
							break;
						}
						num3++;
						continue;
					}
					if (rv != null)
					{
						rv[0] = array[0] + array[1];
					}
					return true;
				}
				return false;
			}
			return true;
		}

		private void method_13(ArrayList entries)
		{
			if (entries == null)
			{
				throw new Exception("illegal entries, must be non-null");
			}
			if (entries.Count != 1)
			{
				throw new Exception("illegal entries, " + entries.Count + " entries present, but requires 1 entry");
			}
			object obj;
			if ((obj = entries[0]) == null || !(obj is Class5578[]))
			{
				throw new Exception("illegal entries, first entry must be an RuleSet[], but is: " + obj?.GetType());
			}
			class5578_0 = (Class5578[])obj;
		}
	}

	private abstract class Class5539 : Class5520
	{
		internal Class5539(string id, int sequence, int flags, int format, Class5508 coverage, ArrayList entries)
			: base(id, sequence, flags, format, coverage)
		{
		}

		public override int vmethod_1()
		{
			return 8;
		}

		public override bool vmethod_3(Class5510 subtable)
		{
			return subtable is Class5539;
		}

		public override bool imethod_0(Class5581 ps)
		{
			bool result = false;
			int num = ps.method_22();
			int ci;
			if ((ci = method_9(num)) >= 0)
			{
				int[] array = new int[1];
				Class5570[] array2 = vmethod_7(ci, num, ps, array);
				if (array2 != null)
				{
					ps.method_64(array2, array[0]);
					result = true;
				}
			}
			return result;
		}

		public abstract Class5570[] vmethod_7(int ci, int gi, Class5581 ps, int[] rv);

		internal static Class5520 smethod_4(string id, int sequence, int flags, int format, Class5508 coverage, ArrayList entries)
		{
			return format switch
			{
				1 => new Class5540(id, sequence, flags, format, coverage, entries), 
				2 => new Class5541(id, sequence, flags, format, coverage, entries), 
				3 => new Class5542(id, sequence, flags, format, coverage, entries), 
				_ => throw new NotSupportedException(), 
			};
		}
	}

	private class Class5540 : Class5539
	{
		private Class5578[] class5578_0;

		internal Class5540(string id, int sequence, int flags, int format, Class5508 coverage, ArrayList entries)
			: base(id, sequence, flags, format, coverage, entries)
		{
			method_13(entries);
		}

		public override ArrayList vmethod_5()
		{
			if (class5578_0 != null)
			{
				ArrayList arrayList = new ArrayList(1);
				arrayList.Add(class5578_0);
				return arrayList;
			}
			return null;
		}

		public override void vmethod_6(Hashtable lookupTables)
		{
			Class5563.smethod_1(class5578_0, lookupTables);
		}

		public override Class5570[] vmethod_7(int ci, int gi, Class5581 ps, int[] rv)
		{
			if (class5578_0.Length > 0)
			{
				Class5578 @class = class5578_0[0];
				if (@class != null)
				{
					Class5571[] array = @class.method_0();
					int i = 0;
					for (int num = array.Length; i < num; i++)
					{
						Class5571 class2 = array[i];
						if (class2 == null || !(class2 is Class5573))
						{
							continue;
						}
						Class5573 class3 = (Class5573)class2;
						int[] glyphs = class3.method_4(gi);
						if (!smethod_5(ps, glyphs, 0, rv))
						{
							continue;
						}
						int[] glyphs2 = class3.method_5();
						if (smethod_5(ps, glyphs2, -1, null))
						{
							int[] glyphs3 = class3.method_6();
							if (smethod_5(ps, glyphs3, rv[0], null))
							{
								return class2.method_0();
							}
						}
					}
				}
			}
			return null;
		}

		private static bool smethod_5(Class5581 ps, int[] glyphs, int offset, int[] rv)
		{
			return Class5536.smethod_5(ps, glyphs, offset, rv);
		}

		private void method_13(ArrayList entries)
		{
			if (entries == null)
			{
				throw new Exception("illegal entries, must be non-null");
			}
			if (entries.Count != 1)
			{
				throw new Exception("illegal entries, " + entries.Count + " entries present, but requires 1 entry");
			}
			object obj;
			if ((obj = entries[0]) == null || !(obj is Class5578[]))
			{
				throw new Exception("illegal entries, first entry must be an RuleSet[], but is: " + obj?.GetType());
			}
			class5578_0 = (Class5578[])obj;
		}
	}

	private class Class5541 : Class5539
	{
		private Class5507 class5507_0;

		private Class5507 class5507_1;

		private Class5507 class5507_2;

		private int int_11;

		private Class5578[] class5578_0;

		internal Class5541(string id, int sequence, int flags, int format, Class5508 coverage, ArrayList entries)
			: base(id, sequence, flags, format, coverage, entries)
		{
			method_13(entries);
		}

		public override ArrayList vmethod_5()
		{
			if (class5578_0 != null)
			{
				ArrayList arrayList = new ArrayList(5);
				arrayList.Add(class5507_0);
				arrayList.Add(class5507_1);
				arrayList.Add(class5507_2);
				arrayList.Add(int_11);
				arrayList.Add(class5578_0);
				return arrayList;
			}
			return null;
		}

		public override void vmethod_6(Hashtable lookupTables)
		{
			Class5563.smethod_1(class5578_0, lookupTables);
		}

		public override Class5570[] vmethod_7(int ci, int gi, Class5581 ps, int[] rv)
		{
			if (class5578_0.Length > 0)
			{
				Class5578 @class = class5578_0[0];
				if (@class != null)
				{
					Class5571[] array = @class.method_0();
					int i = 0;
					for (int num = array.Length; i < num; i++)
					{
						if (!(array[i] is Class5575 class2))
						{
							continue;
						}
						int[] classes = class2.method_4(class5507_0.imethod_1(gi, ps.method_4(gi)));
						if (!smethod_5(ps, class5507_0, classes, 0, rv))
						{
							continue;
						}
						int[] classes2 = class2.method_5();
						if (smethod_5(ps, class5507_1, classes2, -1, null))
						{
							int[] classes3 = class2.method_6();
							if (smethod_5(ps, class5507_2, classes3, rv[0], null))
							{
								return class2.method_0();
							}
						}
					}
				}
			}
			return null;
		}

		private static bool smethod_5(Class5581 ps, Class5507 cdt, int[] classes, int offset, int[] rv)
		{
			return Class5537.smethod_5(ps, cdt, classes, offset, rv);
		}

		private void method_13(ArrayList entries)
		{
			if (entries == null)
			{
				throw new Exception("illegal entries, must be non-null");
			}
			if (entries.Count != 5)
			{
				throw new Exception("illegal entries, " + entries.Count + " entries present, but requires 5 entries");
			}
			object obj;
			if ((obj = entries[0]) != null && obj is Class5507)
			{
				class5507_0 = (Class5507)obj;
				if ((obj = entries[1]) != null && !(obj is Class5507))
				{
					throw new Exception("illegal entries, second entry must be an GlyphClassTable, but is: " + obj.GetType());
				}
				class5507_1 = (Class5507)obj;
				if ((obj = entries[2]) != null && !(obj is Class5507))
				{
					throw new Exception("illegal entries, third entry must be an GlyphClassTable, but is: " + obj.GetType());
				}
				class5507_2 = (Class5507)obj;
				if ((obj = entries[3]) != null && obj is int)
				{
					int_11 = (int)obj;
					if ((obj = entries[4]) != null && obj is Class5578[])
					{
						class5578_0 = (Class5578[])obj;
						if (class5578_0.Length != int_11)
						{
							throw new Exception("illegal entries, RuleSet[] length is " + class5578_0.Length + ", but expected " + int_11 + " glyph classes");
						}
						return;
					}
					throw new Exception("illegal entries, fifth entry must be an RuleSet[], but is: " + obj?.GetType());
				}
				throw new Exception("illegal entries, fourth entry must be an Integer, but is: " + obj?.GetType());
			}
			throw new Exception("illegal entries, first entry must be an GlyphClassTable, but is: " + obj?.GetType());
		}
	}

	private class Class5542 : Class5539
	{
		private Class5578[] class5578_0;

		internal Class5542(string id, int sequence, int flags, int format, Class5508 coverage, ArrayList entries)
			: base(id, sequence, flags, format, coverage, entries)
		{
			method_14(entries);
		}

		public override ArrayList vmethod_5()
		{
			if (class5578_0 != null)
			{
				ArrayList arrayList = new ArrayList(1);
				arrayList.Add(class5578_0);
				return arrayList;
			}
			return null;
		}

		public override void vmethod_6(Hashtable lookupTables)
		{
			Class5563.smethod_1(class5578_0, lookupTables);
		}

		public override Class5570[] vmethod_7(int ci, int gi, Class5581 ps, int[] rv)
		{
			if (class5578_0.Length > 0)
			{
				Class5578 @class = class5578_0[0];
				if (@class != null)
				{
					Class5571[] array = @class.method_0();
					int i = 0;
					for (int num = array.Length; i < num; i++)
					{
						Class5571 class2 = array[i];
						if (class2 == null || !(class2 is Class5577))
						{
							continue;
						}
						Class5577 class3 = (Class5577)class2;
						Class5508[] gca = class3.method_3();
						if (!method_13(ps, gca, 0, rv))
						{
							continue;
						}
						Class5508[] gca2 = class3.method_4();
						if (method_13(ps, gca2, -1, null))
						{
							Class5508[] gca3 = class3.method_5();
							if (method_13(ps, gca3, rv[0], null))
							{
								return class2.method_0();
							}
						}
					}
				}
			}
			return null;
		}

		internal bool method_13(Class5581 ps, Class5508[] gca, int offset, int[] rv)
		{
			return Class5538.smethod_5(ps, gca, offset, rv);
		}

		private void method_14(ArrayList entries)
		{
			if (entries == null)
			{
				throw new Exception("illegal entries, must be non-null");
			}
			if (entries.Count != 1)
			{
				throw new Exception("illegal entries, " + entries.Count + " entries present, but requires 1 entry");
			}
			object obj;
			if ((obj = entries[0]) == null || !(obj is Class5578[]))
			{
				throw new Exception("illegal entries, first entry must be an RuleSet[], but is: " + obj?.GetType());
			}
			class5578_0 = (Class5578[])obj;
		}
	}

	internal class Class5604
	{
		private int int_0;

		private int int_1;

		private int[] int_2;

		public Class5604(int startSize, int endSize, int[] deltas)
		{
			int_0 = startSize;
			int_1 = endSize;
			int_2 = deltas;
		}

		public int method_0()
		{
			return int_0;
		}

		public int method_1()
		{
			return int_1;
		}

		public int[] method_2()
		{
			return int_2;
		}

		public int method_3(int fontSize)
		{
			int num = fontSize / 1000;
			if (num < int_0)
			{
				return 0;
			}
			if (num <= int_1)
			{
				return int_2[num - int_0] * 1000;
			}
			return 0;
		}

		public override string ToString()
		{
			return string.Concat("{ start = ", int_0, ", end = ", int_1, ", deltas = ", int_2, "}");
		}
	}

	public const int int_5 = 1;

	public const int int_6 = 2;

	public const int int_7 = 3;

	public const int int_8 = 4;

	public const int int_9 = 5;

	public const int int_10 = 6;

	public const int int_11 = 7;

	public const int int_12 = 8;

	public const int int_13 = 9;

	public Class5566(Class5564 gdef, Hashtable lookups, ArrayList subtables)
		: base(gdef, lookups)
	{
		if (subtables != null && subtables.Count != 0)
		{
			Interface208 @interface = new Class5495(subtables);
			while (@interface.imethod_0())
			{
				object obj = @interface.imethod_1();
				if (obj is Class5520)
				{
					vmethod_0((Class5510)obj);
					continue;
				}
				throw new Exception("subtable must be a glyph positioning subtable");
			}
			method_4();
			return;
		}
		throw new Exception("subtables must be non-empty");
	}

	public static int smethod_2(string name)
	{
		string value = name.ToLower();
		if ("single".Equals(value))
		{
			return 1;
		}
		if ("pair".Equals(value))
		{
			return 2;
		}
		if ("cursive".Equals(value))
		{
			return 3;
		}
		if ("marktobase".Equals(value))
		{
			return 4;
		}
		if ("marktoligature".Equals(value))
		{
			return 5;
		}
		if ("marktomark".Equals(value))
		{
			return 6;
		}
		if ("contextual".Equals(value))
		{
			return 7;
		}
		if ("chainedcontextual".Equals(value))
		{
			return 8;
		}
		if ("extensionpositioning".Equals(value))
		{
			return 9;
		}
		return -1;
	}

	public static string smethod_3(int type)
	{
		return type switch
		{
			1 => "single", 
			2 => "pair", 
			3 => "cursive", 
			4 => "marktobase", 
			5 => "marktoligature", 
			6 => "marktomark", 
			7 => "contextual", 
			8 => "chainedcontextual", 
			9 => "extensionpositioning", 
			_ => "unknown", 
		};
	}

	public static Class5510 smethod_4(int type, string id, int sequence, int flags, int format, Class5508 coverage, ArrayList entries)
	{
		Class5510 result = null;
		switch (type)
		{
		case 1:
			result = Class5521.smethod_4(id, sequence, flags, format, coverage, entries);
			break;
		case 2:
			result = Class5524.smethod_4(id, sequence, flags, format, coverage, entries);
			break;
		case 3:
			result = Class5527.smethod_4(id, sequence, flags, format, coverage, entries);
			break;
		case 4:
			result = Class5529.smethod_4(id, sequence, flags, format, coverage, entries);
			break;
		case 5:
			result = Class5531.smethod_4(id, sequence, flags, format, coverage, entries);
			break;
		case 6:
			result = Class5533.smethod_4(id, sequence, flags, format, coverage, entries);
			break;
		case 7:
			result = Class5535.smethod_4(id, sequence, flags, format, coverage, entries);
			break;
		case 8:
			result = Class5539.smethod_4(id, sequence, flags, format, coverage, entries);
			break;
		}
		return result;
	}

	public static Class5510 smethod_5(int type, string id, int sequence, int flags, int format, ArrayList coverage, ArrayList entries)
	{
		return smethod_4(type, id, sequence, flags, format, Class5508.smethod_0(coverage), entries);
	}

	public bool method_9(Class5591 gs, string script, string language, int fontSize, int[] widths, int[][] adjustments)
	{
		throw new NotImplementedException();
	}
}
