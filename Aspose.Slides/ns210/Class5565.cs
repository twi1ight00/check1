using System;
using System.Collections;
using System.Text;
using ns183;
using ns211;

namespace ns210;

internal class Class5565 : Class5563
{
	private abstract class Class5544 : Class5543
	{
		internal Class5544(string id, int sequence, int flags, int format, Class5508 coverage, ArrayList entries)
			: base(id, sequence, flags, format, coverage)
		{
		}

		public override int vmethod_1()
		{
			return 1;
		}

		public override bool vmethod_3(Class5510 subtable)
		{
			return subtable is Class5544;
		}

		public override bool imethod_0(Class5582 ss)
		{
			int num = ss.method_22();
			int ci;
			if ((ci = method_9(num)) < 0)
			{
				return false;
			}
			int num2 = vmethod_7(ci, num);
			if (num2 < 0 || num2 > 65535)
			{
				num2 = 65535;
			}
			ss.method_60(num2, ss.method_25(), true);
			ss.method_18(1);
			return true;
		}

		public abstract int vmethod_7(int ci, int gi);

		internal static Class5543 smethod_4(string id, int sequence, int flags, int format, Class5508 coverage, ArrayList entries)
		{
			return format switch
			{
				1 => new Class5545(id, sequence, flags, format, coverage, entries), 
				2 => new Class5546(id, sequence, flags, format, coverage, entries), 
				_ => throw new NotSupportedException(), 
			};
		}
	}

	private class Class5545 : Class5544
	{
		private int int_11;

		private int int_12;

		internal Class5545(string id, int sequence, int flags, int format, Class5508 coverage, ArrayList entries)
			: base(id, sequence, flags, format, coverage, entries)
		{
			method_13(entries);
		}

		public override ArrayList vmethod_5()
		{
			ArrayList arrayList = new ArrayList(1);
			arrayList.Add(int_11);
			return arrayList;
		}

		public override int vmethod_7(int ci, int gi)
		{
			if (ci > int_12)
			{
				throw new ArgumentException("coverage index " + ci + " out of range, maximum coverage index is " + int_12);
			}
			return gi + int_11;
		}

		private void method_13(ArrayList entries)
		{
			if (entries != null && entries.Count == 1)
			{
				object obj = entries[0];
				int num = 0;
				if (!(obj is int num2))
				{
					throw new Exception("illegal entries entry, must be int, but is: " + obj);
				}
				int_11 = num2;
				int_12 = method_10() - 1;
				return;
			}
			throw new Exception("illegal entries, must be non-null and contain exactly one entry");
		}
	}

	private class Class5546 : Class5544
	{
		private int[] int_11;

		internal Class5546(string id, int sequence, int flags, int format, Class5508 coverage, ArrayList entries)
			: base(id, sequence, flags, format, coverage, entries)
		{
			method_13(entries);
		}

		public override ArrayList vmethod_5()
		{
			ArrayList arrayList = new ArrayList(int_11.Length);
			int i = 0;
			for (int num = int_11.Length; i < num; i++)
			{
				arrayList.Add(int_11[i]);
			}
			return arrayList;
		}

		public override int vmethod_7(int ci, int gi)
		{
			if (int_11 == null)
			{
				return -1;
			}
			if (ci >= int_11.Length)
			{
				throw new ArgumentException("coverage index " + ci + " out of range, maximum coverage index is " + int_11.Length);
			}
			return int_11[ci];
		}

		private void method_13(ArrayList entries)
		{
			int num = 0;
			int count = entries.Count;
			int[] array = new int[count];
			Interface208 @interface = new Class5495(entries);
			while (@interface.imethod_0())
			{
				object obj = @interface.imethod_1();
				if (obj is int num2)
				{
					if (num2 >= 0 && num2 < 65536)
					{
						array[num++] = num2;
						continue;
					}
					throw new Exception("illegal glyph index: " + num2);
				}
				throw new Exception("illegal entries entry, must be int: " + obj);
			}
			int_11 = array;
		}
	}

	private abstract class Class5547 : Class5543
	{
		public Class5547(string id, int sequence, int flags, int format, Class5508 coverage, ArrayList entries)
			: base(id, sequence, flags, format, coverage)
		{
		}

		public override int vmethod_1()
		{
			return 2;
		}

		public override bool vmethod_3(Class5510 subtable)
		{
			return subtable is Class5547;
		}

		public override bool imethod_0(Class5582 ss)
		{
			int num = ss.method_22();
			int ci;
			if ((ci = method_9(num)) < 0)
			{
				return false;
			}
			int[] array = vmethod_7(ci, num);
			if (array != null)
			{
				ss.method_61(array, Class5591.Class5592.smethod_3(ss.method_25(), array.Length), true);
				ss.method_18(1);
			}
			return true;
		}

		public abstract int[] vmethod_7(int ci, int gi);

		internal static Class5543 smethod_4(string id, int sequence, int flags, int format, Class5508 coverage, ArrayList entries)
		{
			if (format != 1)
			{
				throw new NotSupportedException();
			}
			return new Class5548(id, sequence, flags, format, coverage, entries);
		}
	}

	private class Class5548 : Class5547
	{
		private int[][] int_11;

		internal Class5548(string id, int sequence, int flags, int format, Class5508 coverage, ArrayList entries)
			: base(id, sequence, flags, format, coverage, entries)
		{
			method_13(entries);
		}

		public override ArrayList vmethod_5()
		{
			if (int_11 != null)
			{
				ArrayList arrayList = new ArrayList(1);
				arrayList.Add(int_11);
				return arrayList;
			}
			return null;
		}

		public override int[] vmethod_7(int ci, int gi)
		{
			if (int_11 == null)
			{
				return null;
			}
			if (ci >= int_11.Length)
			{
				throw new ArgumentException("coverage index " + ci + " out of range, maximum coverage index is " + int_11.Length);
			}
			return int_11[ci];
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
			if ((obj = entries[0]) == null || !(obj is int[][]))
			{
				throw new Exception("illegal entries, first entry must be an int[][], but is: " + obj?.GetType());
			}
			int_11 = (int[][])obj;
		}
	}

	private abstract class Class5549 : Class5543
	{
		public Class5549(string id, int sequence, int flags, int format, Class5508 coverage, ArrayList entries)
			: base(id, sequence, flags, format, coverage)
		{
		}

		public override int vmethod_1()
		{
			return 3;
		}

		public override bool vmethod_3(Class5510 subtable)
		{
			return subtable is Class5549;
		}

		public override bool imethod_0(Class5582 ss)
		{
			int num = ss.method_22();
			int ci;
			if ((ci = method_9(num)) < 0)
			{
				return false;
			}
			int[] array = vmethod_7(ci, num);
			int num2 = ss.method_59(ci);
			int num3 = ((num2 < 0 || num2 >= array.Length) ? num : array[num2]);
			if (num3 < 0 || num3 > 65535)
			{
				num3 = 65535;
			}
			ss.method_60(num3, ss.method_25(), true);
			ss.method_18(1);
			return true;
		}

		public abstract int[] vmethod_7(int ci, int gi);

		internal static Class5543 smethod_4(string id, int sequence, int flags, int format, Class5508 coverage, ArrayList entries)
		{
			if (format != 1)
			{
				throw new NotSupportedException();
			}
			return new Class5550(id, sequence, flags, format, coverage, entries);
		}
	}

	private class Class5550 : Class5549
	{
		private int[][] int_11;

		internal Class5550(string id, int sequence, int flags, int format, Class5508 coverage, ArrayList entries)
			: base(id, sequence, flags, format, coverage, entries)
		{
			method_13(entries);
		}

		public override ArrayList vmethod_5()
		{
			ArrayList arrayList = new ArrayList(int_11.Length);
			int i = 0;
			for (int num = int_11.Length; i < num; i++)
			{
				arrayList.Add(int_11[i]);
			}
			return arrayList;
		}

		public override int[] vmethod_7(int ci, int gi)
		{
			if (int_11 == null)
			{
				return null;
			}
			if (ci >= int_11.Length)
			{
				throw new ArgumentException("coverage index " + ci + " out of range, maximum coverage index is " + int_11.Length);
			}
			return int_11[ci];
		}

		private void method_13(ArrayList entries)
		{
			int num = 0;
			int count = entries.Count;
			int[][] array = new int[count][];
			Interface208 @interface = new Class5495(entries);
			while (@interface.imethod_0())
			{
				object obj = @interface.imethod_1();
				if (obj is int[])
				{
					array[num++] = (int[])obj;
					continue;
				}
				throw new Exception("illegal entries entry, must be int[]: " + obj);
			}
			int_11 = array;
		}
	}

	private abstract class Class5551 : Class5543
	{
		public Class5551(string id, int sequence, int flags, int format, Class5508 coverage, ArrayList entries)
			: base(id, sequence, flags, format, coverage)
		{
		}

		public override int vmethod_1()
		{
			return 4;
		}

		public override bool vmethod_3(Class5510 subtable)
		{
			return subtable is Class5551;
		}

		public override bool imethod_0(Class5582 ss)
		{
			int num = ss.method_22();
			int ci;
			if ((ci = method_9(num)) < 0)
			{
				return false;
			}
			Class5590 @class = vmethod_7(ci, num);
			if (@class != null)
			{
				bool reverseOrder = false;
				Interface213 ignoreTester = ss.method_6();
				int[] array = ss.method_33(0, reverseOrder: false, ignoreTester);
				int num2 = array[0];
				if (num2 > 1)
				{
					int[] glyphs = ss.method_26(0, num2, reverseOrder, ignoreTester, null, array);
					Class5589 class2 = smethod_4(@class, glyphs);
					if (class2 != null)
					{
						int num3 = class2.method_0();
						if (num3 < 0 || num3 > 65535)
						{
							num3 = 65535;
						}
						int count = 1 + class2.method_2();
						ss.method_26(0, count, reverseOrder, ignoreTester, null, array);
						num2 = array[0];
						int num4 = array[1];
						Class5591.Class5592[] aa = ss.method_41(0, num2);
						ss.method_60(num3, Class5591.Class5592.smethod_4(aa), true);
						if (num4 > 0)
						{
							ss.method_61(ss.method_32(0, num4), ss.method_43(0, num4), null);
						}
						ss.method_18(num2 + num4);
					}
				}
			}
			return true;
		}

		private static Class5589 smethod_4(Class5590 ls, int[] glyphs)
		{
			Class5589[] array = ls.method_0();
			int num = -1;
			int num2 = -1;
			int i = 0;
			for (int num3 = array.Length; i < num3; i++)
			{
				Class5589 @class = array[i];
				if (@class.method_3(glyphs))
				{
					int num4 = @class.method_2();
					if (num4 > num2)
					{
						num2 = num4;
						num = i;
					}
				}
			}
			if (num >= 0)
			{
				return array[num];
			}
			return null;
		}

		public abstract Class5590 vmethod_7(int ci, int gi);

		internal static Class5543 smethod_5(string id, int sequence, int flags, int format, Class5508 coverage, ArrayList entries)
		{
			if (format != 1)
			{
				throw new NotSupportedException();
			}
			return new Class5552(id, sequence, flags, format, coverage, entries);
		}
	}

	internal class Class5590
	{
		private Class5589[] class5589_0;

		private int int_0;

		public Class5590(ArrayList ligatures)
			: this((Class5589[])ligatures.ToArray(typeof(Class5589)))
		{
		}

		public Class5590(Class5589[] ligatures)
		{
			if (ligatures == null)
			{
				throw new Exception("invalid ligatures, must be non-null array");
			}
			class5589_0 = ligatures;
			int num = -1;
			int i = 0;
			for (int num2 = ligatures.Length; i < num2; i++)
			{
				Class5589 @class = ligatures[i];
				int num3 = @class.method_2() + 1;
				if (num3 > num)
				{
					num = num3;
				}
			}
			int_0 = num;
		}

		public Class5589[] method_0()
		{
			return class5589_0;
		}

		public int method_1()
		{
			return class5589_0.Length;
		}

		public int method_2()
		{
			return int_0;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("{ligs={");
			int i = 0;
			for (int num = class5589_0.Length; i < num; i++)
			{
				if (i > 0)
				{
					stringBuilder.Append(',');
				}
				stringBuilder.Append(class5589_0[i]);
			}
			stringBuilder.Append("}}");
			return stringBuilder.ToString();
		}
	}

	internal class Class5589
	{
		private int int_0;

		private int[] int_1;

		public Class5589(int ligature, int[] components)
		{
			if (ligature >= 0 && ligature <= 65535)
			{
				if (components == null)
				{
					throw new Exception("invalid ligature components, must be non-null array");
				}
				int i = 0;
				for (int num = components.Length; i < num; i++)
				{
					int num2 = components[i];
					if (num2 < 0 || num2 > 65535)
					{
						throw new Exception("invalid component glyph index: " + num2);
					}
				}
				int_0 = ligature;
				int_1 = components;
				return;
			}
			throw new Exception("invalid ligature glyph index: " + ligature);
		}

		public int method_0()
		{
			return int_0;
		}

		public int[] method_1()
		{
			return int_1;
		}

		public int method_2()
		{
			return int_1.Length;
		}

		public bool method_3(int[] glyphs)
		{
			if (glyphs.Length < int_1.Length + 1)
			{
				return false;
			}
			int num = 0;
			int num2 = int_1.Length;
			while (true)
			{
				if (num < num2)
				{
					if (glyphs[num + 1] != int_1[num])
					{
						break;
					}
					num++;
					continue;
				}
				return true;
			}
			return false;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("{components={");
			int i = 0;
			for (int num = int_1.Length; i < num; i++)
			{
				if (i > 0)
				{
					stringBuilder.Append(',');
				}
				stringBuilder.Append(int_1[i]);
			}
			stringBuilder.Append("},ligature=");
			stringBuilder.Append(int_0);
			stringBuilder.Append("}");
			return stringBuilder.ToString();
		}
	}

	private class Class5552 : Class5551
	{
		private Class5590[] class5590_0;

		public Class5552(string id, int sequence, int flags, int format, Class5508 coverage, ArrayList entries)
			: base(id, sequence, flags, format, coverage, entries)
		{
			method_13(entries);
		}

		public override ArrayList vmethod_5()
		{
			ArrayList arrayList = new ArrayList(class5590_0.Length);
			int i = 0;
			for (int num = class5590_0.Length; i < num; i++)
			{
				arrayList.Add(class5590_0[i]);
			}
			return arrayList;
		}

		public override Class5590 vmethod_7(int ci, int gi)
		{
			if (class5590_0 == null)
			{
				return null;
			}
			if (ci >= class5590_0.Length)
			{
				throw new ArgumentException("coverage index " + ci + " out of range, maximum coverage index is " + class5590_0.Length);
			}
			return class5590_0[ci];
		}

		private void method_13(ArrayList entries)
		{
			int num = 0;
			int count = entries.Count;
			Class5590[] array = new Class5590[count];
			Interface208 @interface = new Class5495(entries);
			while (@interface.imethod_0())
			{
				object obj = @interface.imethod_1();
				if (obj is Class5590)
				{
					array[num++] = (Class5590)obj;
					continue;
				}
				throw new Exception("illegal ligatures entry, must be LigatureSet: " + obj);
			}
			class5590_0 = array;
		}
	}

	private abstract class Class5553 : Class5543
	{
		public Class5553(string id, int sequence, int flags, int format, Class5508 coverage, ArrayList entries)
			: base(id, sequence, flags, format, coverage)
		{
		}

		public override int vmethod_1()
		{
			return 5;
		}

		public override bool vmethod_3(Class5510 subtable)
		{
			return subtable is Class5553;
		}

		public override bool imethod_0(Class5582 ss)
		{
			int num = ss.method_22();
			int ci;
			if ((ci = method_9(num)) < 0)
			{
				return false;
			}
			int[] array = new int[1];
			Class5570[] array2 = vmethod_7(ci, num, ss, array);
			if (array2 != null)
			{
				ss.method_64(array2, array[0]);
			}
			return true;
		}

		public abstract Class5570[] vmethod_7(int ci, int gi, Class5582 ss, int[] rv);

		internal static Class5543 smethod_4(string id, int sequence, int flags, int format, Class5508 coverage, ArrayList entries)
		{
			return format switch
			{
				1 => new Class5554(id, sequence, flags, format, coverage, entries), 
				2 => new Class5555(id, sequence, flags, format, coverage, entries), 
				3 => new Class5556(id, sequence, flags, format, coverage, entries), 
				_ => throw new NotSupportedException(), 
			};
		}
	}

	private class Class5554 : Class5553
	{
		private Class5578[] class5578_0;

		internal Class5554(string id, int sequence, int flags, int format, Class5508 coverage, ArrayList entries)
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

		public override Class5570[] vmethod_7(int ci, int gi, Class5582 ss, int[] rv)
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
							if (smethod_5(ss, glyphs, 0, rv))
							{
								return class2.method_0();
							}
						}
					}
				}
			}
			return null;
		}

		internal static bool smethod_5(Class5582 ss, int[] glyphs, int offset, int[] rv)
		{
			if (glyphs != null && glyphs.Length != 0)
			{
				bool reverseOrder = offset < 0;
				Interface213 ignoreTester = ss.method_6();
				int[] array = ss.method_33(offset, reverseOrder, ignoreTester);
				int num = array[0];
				int num2 = glyphs.Length;
				if (num < num2)
				{
					return false;
				}
				int[] array2 = ss.method_26(offset, num2, reverseOrder, ignoreTester, null, array);
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

	private class Class5555 : Class5553
	{
		private Class5507 class5507_0;

		private int int_11;

		private Class5578[] class5578_0;

		internal Class5555(string id, int sequence, int flags, int format, Class5508 coverage, ArrayList entries)
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

		public override Class5570[] vmethod_7(int ci, int gi, Class5582 ss, int[] rv)
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
							int[] classes = class3.method_4(class5507_0.imethod_1(gi, ss.method_4(gi)));
							if (smethod_5(ss, class5507_0, classes, 0, rv))
							{
								return class2.method_0();
							}
						}
					}
				}
			}
			return null;
		}

		internal static bool smethod_5(Class5582 ss, Class5507 cdt, int[] classes, int offset, int[] rv)
		{
			if (cdt != null && classes != null && classes.Length != 0)
			{
				bool reverseOrder = offset < 0;
				Interface213 ignoreTester = ss.method_6();
				int[] array = ss.method_33(offset, reverseOrder, ignoreTester);
				int num = array[0];
				int num2 = classes.Length;
				if (num < num2)
				{
					return false;
				}
				int[] array2 = ss.method_26(offset, num2, reverseOrder, ignoreTester, null, array);
				int num3 = 0;
				while (true)
				{
					if (num3 < num2)
					{
						int num4 = array2[num3];
						int set = ss.method_4(num4);
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
				throw new Exception("illegal entries, second entry must be an int, but is: " + obj?.GetType());
			}
			throw new Exception("illegal entries, first entry must be an GlyphClassTable, but is: " + obj?.GetType());
		}
	}

	private class Class5556 : Class5553
	{
		private Class5578[] class5578_0;

		internal Class5556(string id, int sequence, int flags, int format, Class5508 coverage, ArrayList entries)
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

		public override Class5570[] vmethod_7(int ci, int gi, Class5582 ss, int[] rv)
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
							if (smethod_5(ss, gca, 0, rv))
							{
								return class2.method_0();
							}
						}
					}
				}
			}
			return null;
		}

		internal static bool smethod_5(Class5582 ss, Class5508[] gca, int offset, int[] rv)
		{
			if (gca != null && gca.Length != 0)
			{
				bool reverseOrder = offset < 0;
				Interface213 ignoreTester = ss.method_6();
				int[] array = ss.method_33(offset, reverseOrder, ignoreTester);
				int num = array[0];
				int num2 = gca.Length;
				if (num < num2)
				{
					return false;
				}
				int[] array2 = ss.method_26(offset, num2, reverseOrder, ignoreTester, null, array);
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

	private abstract class Class5557 : Class5543
	{
		public Class5557(string id, int sequence, int flags, int format, Class5508 coverage, ArrayList entries)
			: base(id, sequence, flags, format, coverage)
		{
		}

		public override int vmethod_1()
		{
			return 6;
		}

		public override bool vmethod_3(Class5510 subtable)
		{
			return subtable is Class5557;
		}

		public override bool imethod_0(Class5582 ss)
		{
			int num = ss.method_22();
			int ci;
			if ((ci = method_9(num)) < 0)
			{
				return false;
			}
			int[] array = new int[1];
			Class5570[] array2 = vmethod_7(ci, num, ss, array);
			if (array2 != null)
			{
				ss.method_64(array2, array[0]);
				return true;
			}
			return false;
		}

		public abstract Class5570[] vmethod_7(int ci, int gi, Class5582 ss, int[] rv);

		internal static Class5543 smethod_4(string id, int sequence, int flags, int format, Class5508 coverage, ArrayList entries)
		{
			return format switch
			{
				1 => new Class5558(id, sequence, flags, format, coverage, entries), 
				2 => new Class5559(id, sequence, flags, format, coverage, entries), 
				3 => new Class5560(id, sequence, flags, format, coverage, entries), 
				_ => throw new NotSupportedException(), 
			};
		}
	}

	private class Class5558 : Class5557
	{
		private Class5578[] class5578_0;

		internal Class5558(string id, int sequence, int flags, int format, Class5508 coverage, ArrayList entries)
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

		public override Class5570[] vmethod_7(int ci, int gi, Class5582 ss, int[] rv)
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
						if (!(array[i] is Class5573 class2))
						{
							continue;
						}
						int[] glyphs = class2.method_4(gi);
						if (!smethod_5(ss, glyphs, 0, rv))
						{
							continue;
						}
						int[] glyphs2 = class2.method_5();
						if (smethod_5(ss, glyphs2, -1, null))
						{
							int[] glyphs3 = class2.method_6();
							if (smethod_5(ss, glyphs3, rv[0], null))
							{
								return class2.method_0();
							}
						}
					}
				}
			}
			return null;
		}

		private static bool smethod_5(Class5582 ss, int[] glyphs, int offset, int[] rv)
		{
			return Class5554.smethod_5(ss, glyphs, offset, rv);
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

	private class Class5559 : Class5557
	{
		private Class5507 class5507_0;

		private Class5507 class5507_1;

		private Class5507 class5507_2;

		private int int_11;

		private Class5578[] class5578_0;

		internal Class5559(string id, int sequence, int flags, int format, Class5508 coverage, ArrayList entries)
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

		public override Class5570[] vmethod_7(int ci, int gi, Class5582 ss, int[] rv)
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
						if (class2 == null || !(class2 is Class5575))
						{
							continue;
						}
						Class5575 class3 = (Class5575)class2;
						int[] classes = class3.method_4(class5507_0.imethod_1(gi, ss.method_4(gi)));
						if (!smethod_5(ss, class5507_0, classes, 0, rv))
						{
							continue;
						}
						int[] classes2 = class3.method_5();
						if (smethod_5(ss, class5507_1, classes2, -1, null))
						{
							int[] classes3 = class3.method_6();
							if (smethod_5(ss, class5507_2, classes3, rv[0], null))
							{
								return class2.method_0();
							}
						}
					}
				}
			}
			return null;
		}

		private static bool smethod_5(Class5582 ss, Class5507 cdt, int[] classes, int offset, int[] rv)
		{
			return Class5555.smethod_5(ss, cdt, classes, offset, rv);
		}

		public override void vmethod_6(Hashtable lookupTables)
		{
			Class5563.smethod_1(class5578_0, lookupTables);
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
				throw new Exception("illegal entries, fourth entry must be an int, but is: " + obj?.GetType());
			}
			throw new Exception("illegal entries, first entry must be an GlyphClassTable, but is: " + obj?.GetType());
		}
	}

	private class Class5560 : Class5557
	{
		private Class5578[] class5578_0;

		internal Class5560(string id, int sequence, int flags, int format, Class5508 coverage, ArrayList entries)
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

		public override Class5570[] vmethod_7(int ci, int gi, Class5582 ss, int[] rv)
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
						if (!smethod_5(ss, gca, 0, rv))
						{
							continue;
						}
						Class5508[] gca2 = class3.method_4();
						if (smethod_5(ss, gca2, -1, null))
						{
							Class5508[] gca3 = class3.method_5();
							if (smethod_5(ss, gca3, rv[0], null))
							{
								return class2.method_0();
							}
						}
					}
				}
			}
			return null;
		}

		private static bool smethod_5(Class5582 ss, Class5508[] gca, int offset, int[] rv)
		{
			return Class5556.smethod_5(ss, gca, offset, rv);
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

	private abstract class Class5561 : Class5543
	{
		public Class5561(string id, int sequence, int flags, int format, Class5508 coverage, ArrayList entries)
			: base(id, sequence, flags, format, coverage)
		{
		}

		public override int vmethod_1()
		{
			return 8;
		}

		public override bool vmethod_3(Class5510 subtable)
		{
			return subtable is Class5561;
		}

		public override bool vmethod_4()
		{
			return true;
		}

		internal static Class5543 smethod_4(string id, int sequence, int flags, int format, Class5508 coverage, ArrayList entries)
		{
			if (format != 1)
			{
				throw new NotSupportedException();
			}
			return new Class5562(id, sequence, flags, format, coverage, entries);
		}
	}

	private class Class5562 : Class5561
	{
		internal Class5562(string id, int sequence, int flags, int format, Class5508 coverage, ArrayList entries)
			: base(id, sequence, flags, format, coverage, entries)
		{
			smethod_5(entries);
		}

		public override ArrayList vmethod_5()
		{
			return null;
		}

		private static void smethod_5(ArrayList entries)
		{
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

	public Class5565(Class5564 gdef, Hashtable lookups, ArrayList subtables)
		: base(gdef, lookups)
	{
		if (subtables != null && subtables.Count != 0)
		{
			Interface208 @interface = new Class5495(subtables);
			while (@interface.imethod_0())
			{
				object obj = @interface.imethod_1();
				if (obj is Class5543)
				{
					vmethod_0((Class5510)obj);
					continue;
				}
				throw new Exception("subtable must be a glyph substitution subtable");
			}
			method_4();
			return;
		}
		throw new Exception("subtables must be non-empty");
	}

	public Class5591 method_9(Class5591 gs, string script, string language)
	{
		throw new NotImplementedException();
	}

	public static int smethod_2(string name)
	{
		string value = name.ToLower();
		if ("single".Equals(value))
		{
			return 1;
		}
		if ("multiple".Equals(value))
		{
			return 2;
		}
		if ("alternate".Equals(value))
		{
			return 3;
		}
		if ("ligature".Equals(value))
		{
			return 4;
		}
		if ("contextual".Equals(value))
		{
			return 5;
		}
		if ("chainedcontextual".Equals(value))
		{
			return 6;
		}
		if ("extensionsubstitution".Equals(value))
		{
			return 7;
		}
		if ("reversechainiingcontextualsingle".Equals(value))
		{
			return 8;
		}
		return -1;
	}

	public static string smethod_3(int type)
	{
		string text = null;
		return type switch
		{
			1 => "single", 
			2 => "multiple", 
			3 => "alternate", 
			4 => "ligature", 
			5 => "contextual", 
			6 => "chainedcontextual", 
			7 => "extensionsubstitution", 
			8 => "reversechainiingcontextualsingle", 
			_ => "unknown", 
		};
	}

	public static Class5510 smethod_4(int type, string id, int sequence, int flags, int format, Class5508 coverage, ArrayList entries)
	{
		Class5510 result = null;
		switch (type)
		{
		case 1:
			result = Class5544.smethod_4(id, sequence, flags, format, coverage, entries);
			break;
		case 2:
			result = Class5547.smethod_4(id, sequence, flags, format, coverage, entries);
			break;
		case 3:
			result = Class5549.smethod_4(id, sequence, flags, format, coverage, entries);
			break;
		case 4:
			result = Class5551.smethod_5(id, sequence, flags, format, coverage, entries);
			break;
		case 5:
			result = Class5553.smethod_4(id, sequence, flags, format, coverage, entries);
			break;
		case 6:
			result = Class5557.smethod_4(id, sequence, flags, format, coverage, entries);
			break;
		case 8:
			result = Class5561.smethod_4(id, sequence, flags, format, coverage, entries);
			break;
		}
		return result;
	}

	public static Class5510 smethod_5(int type, string id, int sequence, int flags, int format, ArrayList coverage, ArrayList entries)
	{
		return smethod_4(type, id, sequence, flags, format, Class5508.smethod_0(coverage), entries);
	}
}
