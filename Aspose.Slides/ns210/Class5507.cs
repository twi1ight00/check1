using System;
using System.Collections;
using System.Text;
using ns183;

namespace ns210;

internal class Class5507 : Class5496, Interface209
{
	private class Class5498 : Class5497, Interface209
	{
		public Class5498(ArrayList entries)
			: base(entries)
		{
		}

		public int imethod_0(int set)
		{
			return 0;
		}

		public int imethod_1(int gid, int set)
		{
			return -1;
		}
	}

	private class Class5502 : Class5501, Interface209
	{
		private int int_3;

		private int[] int_4;

		private int int_5 = -1;

		public Class5502(ArrayList entries)
		{
			method_0(entries);
		}

		public override ArrayList vmethod_1()
		{
			ArrayList arrayList = new ArrayList();
			arrayList.Add(int_3);
			if (int_4 != null)
			{
				int i = 0;
				for (int num = int_4.Length; i < num; i++)
				{
					arrayList.Add(int_4[i]);
				}
			}
			return arrayList;
		}

		public override int vmethod_2()
		{
			return int_5 + 1;
		}

		public override int vmethod_3(int gid)
		{
			int num = gid - int_3;
			if (num >= 0 && num < int_4.Length)
			{
				return int_4[num];
			}
			return -1;
		}

		public int imethod_0(int set)
		{
			return vmethod_2();
		}

		public int imethod_1(int gid, int set)
		{
			return vmethod_3(gid);
		}

		private void method_0(ArrayList entries)
		{
			Interface208 @interface = new Class5495(entries);
			int num = 0;
			if (@interface.imethod_0())
			{
				object obj = @interface.imethod_1();
				if (!(obj is int))
				{
					throw new Exception("illegal entry, first entry must be int denoting first glyph value, but is: " + obj);
				}
				num = (int)obj;
			}
			int num2 = 0;
			int num3 = entries.Count - 1;
			int num4 = -1;
			int[] array = new int[num3];
			while (@interface.imethod_0())
			{
				object obj2 = @interface.imethod_1();
				if (obj2 is int num5)
				{
					array[num2++] = num5;
					if (num5 > num4)
					{
						num4 = num5;
					}
					continue;
				}
				throw new Exception("illegal mapping entry, must be int: " + obj2);
			}
			int_3 = num;
			int_4 = array;
			int_5 = num4;
		}

		public string method_1()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("{ firstGlyph = " + int_3 + ", classes = {");
			int i = 0;
			for (int num = int_4.Length; i < num; i++)
			{
				if (i > 0)
				{
					stringBuilder.Append(',');
				}
				stringBuilder.Append(int_4[i]);
			}
			stringBuilder.Append("} }");
			return stringBuilder.ToString();
		}
	}

	private class Class5505 : Class5504, Interface209
	{
		public Class5505(ArrayList entries)
			: base(entries)
		{
		}

		public override int vmethod_4(int gid, int s, int m)
		{
			return m;
		}

		public int imethod_0(int set)
		{
			return vmethod_2();
		}

		public int imethod_1(int gid, int set)
		{
			return vmethod_3(gid);
		}
	}

	private class Class5499 : Class5497, Interface209
	{
		public Class5499(ArrayList entries)
		{
			throw new NotSupportedException("coverage set class table not yet supported");
		}

		public override int vmethod_0()
		{
			return int_6;
		}

		public int imethod_0(int set)
		{
			return 0;
		}

		public int imethod_1(int gid, int set)
		{
			return -1;
		}
	}

	public static int int_3 = Class5496.int_0;

	public static int int_4 = Class5496.int_1;

	public static int int_5 = Class5496.int_2;

	public static int int_6 = 3;

	private Interface209 interface209_0;

	private Class5507(Interface209 cm)
	{
		interface209_0 = cm;
	}

	public override int vmethod_0()
	{
		return ((Class5496)interface209_0).vmethod_0();
	}

	public override ArrayList vmethod_1()
	{
		return ((Class5496)interface209_0).vmethod_1();
	}

	public int imethod_0(int set)
	{
		return interface209_0.imethod_0(set);
	}

	public int imethod_1(int gid, int set)
	{
		return interface209_0.imethod_1(gid, set);
	}

	public static Class5507 smethod_0(ArrayList entries)
	{
		Interface209 cm = ((entries == null || entries.Count == 0) ? new Class5498(entries) : (smethod_1(entries) ? new Class5502(entries) : (smethod_2(entries) ? ((Interface209)new Class5505(entries)) : ((Interface209)((!smethod_3(entries)) ? null : new Class5499(entries))))));
		return new Class5507(cm);
	}

	private static bool smethod_1(ArrayList entries)
	{
		if (entries != null && entries.Count != 0)
		{
			Interface208 @interface = new Class5495(entries);
			object obj;
			do
			{
				if (@interface.imethod_0())
				{
					obj = @interface.imethod_1();
					continue;
				}
				return true;
			}
			while (obj is int);
			return false;
		}
		return false;
	}

	private static bool smethod_2(ArrayList entries)
	{
		if (entries != null && entries.Count != 0)
		{
			Interface208 @interface = new Class5495(entries);
			object obj;
			do
			{
				if (@interface.imethod_0())
				{
					obj = @interface.imethod_1();
					continue;
				}
				return true;
			}
			while (obj is Class5509);
			return false;
		}
		return false;
	}

	private static bool smethod_3(ArrayList entries)
	{
		if (entries != null && entries.Count != 0)
		{
			Interface208 @interface = new Class5495(entries);
			object obj;
			do
			{
				if (@interface.imethod_0())
				{
					obj = @interface.imethod_1();
					continue;
				}
				return true;
			}
			while (obj is Class5508);
			return false;
		}
		return false;
	}
}
