using System;
using System.Collections;

namespace ns210;

internal abstract class Class5510
{
	public static int int_0 = 1;

	public static int int_1 = 2;

	public static int int_2 = 4;

	public static int int_3 = 8;

	public static int int_4 = 16;

	public static int int_5 = 3584;

	public static int int_6 = 65280;

	public static int int_7 = 65536;

	private string string_0;

	private int int_8;

	private int int_9;

	private int int_10;

	private Class5496 class5496_0;

	private WeakReference weakReference_0;

	protected Class5510(string lookupId, int sequence, int flags, int format, Class5496 mapping)
	{
		if (lookupId != null && lookupId.Length != 0)
		{
			if (mapping == null)
			{
				throw new Exception("invalid mapping table, must not be null");
			}
			string_0 = lookupId;
			int_8 = sequence;
			int_9 = flags;
			int_10 = format;
			class5496_0 = mapping;
			return;
		}
		throw new Exception("invalid lookup identifier, must be non-empty string");
	}

	public string method_0()
	{
		return string_0;
	}

	public abstract int vmethod_0();

	public abstract int vmethod_1();

	public abstract string vmethod_2();

	public abstract bool vmethod_3(Class5510 subtable);

	public abstract bool vmethod_4();

	public int method_1()
	{
		return int_8;
	}

	public int method_2()
	{
		return int_9;
	}

	public int method_3()
	{
		return int_10;
	}

	public Class5564 method_4()
	{
		return method_7()?.method_0();
	}

	public Interface210 method_5()
	{
		if (class5496_0 is Interface210)
		{
			return (Interface210)class5496_0;
		}
		return null;
	}

	public Interface209 method_6()
	{
		if (class5496_0 is Interface209)
		{
			return (Interface209)class5496_0;
		}
		return null;
	}

	public abstract ArrayList vmethod_5();

	public Class5563 method_7()
	{
		WeakReference weakReference = weakReference_0;
		if (weakReference == null)
		{
			return null;
		}
		return (Class5563)weakReference_0.Target;
	}

	public void method_8(Class5563 table)
	{
		WeakReference weakReference = weakReference_0;
		if (table == null)
		{
			weakReference_0 = null;
			return;
		}
		if (weakReference != null)
		{
			throw new InvalidOperationException("table already set");
		}
		weakReference_0 = new WeakReference(table);
	}

	public virtual void vmethod_6(Hashtable lookupTables)
	{
	}

	public int method_9(int gid)
	{
		if (class5496_0 is Interface210)
		{
			return ((Interface210)class5496_0).imethod_1(gid);
		}
		return -1;
	}

	public int method_10()
	{
		if (class5496_0 is Interface210)
		{
			return ((Interface210)class5496_0).imethod_0();
		}
		return 0;
	}

	public override int GetHashCode()
	{
		int num = int_8;
		return num * 3 + (string_0.GetHashCode() ^ num);
	}

	public bool method_11(object o)
	{
		if (o is Class5510 @class && string_0.Equals(@class.string_0))
		{
			return int_8 == @class.int_8;
		}
		return false;
	}

	public int method_12(object o)
	{
		int result;
		if (o is Class5510 @class)
		{
			if ((result = string_0.CompareTo(@class.string_0)) == 0)
			{
				if (int_8 < @class.int_8)
				{
					result = -1;
				}
				else if (int_8 > @class.int_8)
				{
					result = 1;
				}
			}
		}
		else
		{
			result = -1;
		}
		return result;
	}

	public static bool smethod_0(Class5510[] subtables)
	{
		if (subtables != null && subtables.Length != 0)
		{
			int num = 0;
			int num2 = subtables.Length;
			while (true)
			{
				if (num < num2)
				{
					if (subtables[num].vmethod_4())
					{
						break;
					}
					num++;
					continue;
				}
				return false;
			}
			return true;
		}
		return false;
	}

	public static int smethod_1(Class5510[] subtables)
	{
		if (subtables != null && subtables.Length != 0)
		{
			int num = 0;
			int i = 0;
			for (int num2 = subtables.Length; i < num2; i++)
			{
				int num3 = subtables[i].method_2();
				if (num == 0)
				{
					num = num3;
					break;
				}
			}
			int num4 = 0;
			int num5 = subtables.Length;
			int num6;
			while (true)
			{
				if (num4 < num5)
				{
					num6 = subtables[num4].method_2();
					if (num6 != num)
					{
						break;
					}
					num4++;
					continue;
				}
				return num | (smethod_0(subtables) ? int_7 : 0);
			}
			throw new InvalidOperationException("inconsistent lookup flags " + num6 + ", expected " + num);
		}
		return 0;
	}
}
