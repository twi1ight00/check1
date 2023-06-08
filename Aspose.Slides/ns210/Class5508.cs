using System;
using System.Collections;
using System.Text;
using ns183;

namespace ns210;

internal class Class5508 : Class5496, Interface210
{
	private class Class5500 : Class5497, Interface210
	{
		public Class5500(ArrayList entries)
			: base(entries)
		{
		}

		public int imethod_0()
		{
			return 0;
		}

		public int imethod_1(int gid)
		{
			return -1;
		}
	}

	private class Class5503 : Class5501, Interface210
	{
		private int[] int_3;

		public Class5503(ArrayList entries)
		{
			method_0(entries);
		}

		public override ArrayList vmethod_1()
		{
			ArrayList arrayList = new ArrayList();
			if (int_3 != null)
			{
				int i = 0;
				for (int num = int_3.Length; i < num; i++)
				{
					arrayList.Add(int_3[i]);
				}
			}
			return arrayList;
		}

		public override int vmethod_2()
		{
			if (int_3 == null)
			{
				return 0;
			}
			return int_3.Length;
		}

		public override int vmethod_3(int gid)
		{
			int result;
			if ((result = Array.BinarySearch(int_3, gid)) >= 0)
			{
				return result;
			}
			return -1;
		}

		public int imethod_0()
		{
			return vmethod_2();
		}

		public int imethod_1(int gid)
		{
			return vmethod_3(gid);
		}

		private void method_0(ArrayList entries)
		{
			int num = 0;
			int num2 = 0;
			int count = entries.Count;
			int num3 = -1;
			int[] array = new int[count];
			Interface208 @interface = new Class5495(entries);
			while (@interface.imethod_0())
			{
				object obj = @interface.imethod_1();
				if (obj is int num4)
				{
					if (num4 >= 0 && num4 < 65536)
					{
						if (num4 > num3)
						{
							num3 = (array[num++] = num4);
						}
						else
						{
							num2++;
						}
						continue;
					}
					throw new Exception("illegal glyph index: " + num4);
				}
				throw new Exception("illegal coverage entry, must be Integer: " + obj);
			}
			int_3 = array;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append('{');
			int i = 0;
			for (int num = int_3.Length; i < num; i++)
			{
				if (i > 0)
				{
					stringBuilder.Append(',');
				}
				stringBuilder.Append(int_3[i]);
			}
			stringBuilder.Append('}');
			return stringBuilder.ToString();
		}
	}

	private class Class5506 : Class5504, Interface210
	{
		public Class5506(ArrayList entries)
			: base(entries)
		{
		}

		public override int vmethod_4(int gid, int s, int m)
		{
			return m + gid - s;
		}

		public int imethod_0()
		{
			return vmethod_2();
		}

		public int imethod_1(int gid)
		{
			return vmethod_3(gid);
		}
	}

	public static int int_3 = Class5496.int_0;

	public static int int_4 = Class5496.int_1;

	public static int int_5 = Class5496.int_2;

	private Interface210 interface210_0;

	private Class5508(Interface210 cm)
	{
		interface210_0 = cm;
	}

	public override int vmethod_0()
	{
		return ((Class5496)interface210_0).vmethod_0();
	}

	public override ArrayList vmethod_1()
	{
		return ((Class5496)interface210_0).vmethod_1();
	}

	public int imethod_0()
	{
		return interface210_0.imethod_0();
	}

	public int imethod_1(int gid)
	{
		return interface210_0.imethod_1(gid);
	}

	public static Class5508 smethod_0(ArrayList entries)
	{
		Interface210 cm = ((entries == null || entries.Count == 0) ? new Class5500(entries) : (smethod_1(entries) ? ((Interface210)new Class5503(entries)) : ((Interface210)((!smethod_2(entries)) ? null : new Class5506(entries)))));
		return new Class5508(cm);
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
}
