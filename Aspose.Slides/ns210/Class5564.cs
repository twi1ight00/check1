using System;
using System.Collections;
using ns183;
using ns211;

namespace ns210;

internal class Class5564 : Class5563
{
	internal abstract class Class5512 : Class5511
	{
		internal Class5512(string id, int sequence, int flags, int format, Class5496 mapping, ArrayList entries)
			: base(id, sequence, flags, format, mapping)
		{
		}

		public override int vmethod_1()
		{
			return 1;
		}

		public abstract bool vmethod_7(int gid, int gc);

		public abstract int vmethod_8(int gid);

		internal static Class5511 smethod_2(string id, int sequence, int flags, int format, Class5496 mapping, ArrayList entries)
		{
			if (format != 1)
			{
				throw new NotSupportedException();
			}
			return new Class5513(id, sequence, flags, format, mapping, entries);
		}
	}

	private class Class5513 : Class5512
	{
		internal Class5513(string id, int sequence, int flags, int format, Class5496 mapping, ArrayList entries)
			: base(id, sequence, flags, format, mapping, entries)
		{
		}

		public override ArrayList vmethod_5()
		{
			return null;
		}

		public override bool vmethod_3(Class5510 subtable)
		{
			return subtable is Class5512;
		}

		public override bool vmethod_7(int gid, int gc)
		{
			Interface209 @interface = method_6();
			if (@interface != null)
			{
				return @interface.imethod_1(gid, 0) == gc;
			}
			return false;
		}

		public override int vmethod_8(int gid)
		{
			return method_6()?.imethod_1(gid, 0) ?? (-1);
		}
	}

	private abstract class Class5514 : Class5511
	{
		internal Class5514(string id, int sequence, int flags, int format, Class5496 mapping, ArrayList entries)
			: base(id, sequence, flags, format, mapping)
		{
		}

		public override int vmethod_1()
		{
			return 2;
		}

		internal static Class5511 smethod_2(string id, int sequence, int flags, int format, Class5496 mapping, ArrayList entries)
		{
			if (format != 1)
			{
				throw new NotSupportedException();
			}
			return new Class5515(id, sequence, flags, format, mapping, entries);
		}
	}

	private class Class5515 : Class5514
	{
		internal Class5515(string id, int sequence, int flags, int format, Class5496 mapping, ArrayList entries)
			: base(id, sequence, flags, format, mapping, entries)
		{
		}

		public override ArrayList vmethod_5()
		{
			return null;
		}

		public override bool vmethod_3(Class5510 subtable)
		{
			return subtable is Class5514;
		}
	}

	private abstract class Class5516 : Class5511
	{
		internal Class5516(string id, int sequence, int flags, int format, Class5496 mapping, ArrayList entries)
			: base(id, sequence, flags, format, mapping)
		{
		}

		public override int vmethod_1()
		{
			return 3;
		}

		internal static Class5511 smethod_2(string id, int sequence, int flags, int format, Class5496 mapping, ArrayList entries)
		{
			if (format != 1)
			{
				throw new NotSupportedException();
			}
			return new Class5517(id, sequence, flags, format, mapping, entries);
		}
	}

	private class Class5517 : Class5516
	{
		internal Class5517(string id, int sequence, int flags, int format, Class5496 mapping, ArrayList entries)
			: base(id, sequence, flags, format, mapping, entries)
		{
		}

		public override ArrayList vmethod_5()
		{
			return null;
		}

		public override bool vmethod_3(Class5510 subtable)
		{
			return subtable is Class5516;
		}
	}

	private abstract class Class5518 : Class5511
	{
		internal Class5518(string id, int sequence, int flags, int format, Class5496 mapping, ArrayList entries)
			: base(id, sequence, flags, format, mapping)
		{
		}

		public override int vmethod_1()
		{
			return 4;
		}

		public abstract bool vmethod_7(int gid, int mac);

		public abstract int vmethod_8(int gid);

		internal static Class5511 smethod_2(string id, int sequence, int flags, int format, Class5496 mapping, ArrayList entries)
		{
			if (format != 1)
			{
				throw new NotSupportedException();
			}
			return new Class5519(id, sequence, flags, format, mapping, entries);
		}
	}

	private class Class5519 : Class5518
	{
		internal Class5519(string id, int sequence, int flags, int format, Class5496 mapping, ArrayList entries)
			: base(id, sequence, flags, format, mapping, entries)
		{
		}

		public override ArrayList vmethod_5()
		{
			return null;
		}

		public override bool vmethod_3(Class5510 subtable)
		{
			return subtable is Class5518;
		}

		public override bool vmethod_7(int gid, int mac)
		{
			Interface209 @interface = method_6();
			if (@interface != null)
			{
				return @interface.imethod_1(gid, 0) == mac;
			}
			return false;
		}

		public override int vmethod_8(int gid)
		{
			return method_6()?.imethod_1(gid, 0) ?? (-1);
		}
	}

	public const int int_5 = 1;

	public const int int_6 = 2;

	public const int int_7 = 3;

	public const int int_8 = 4;

	public const int int_9 = 1;

	public const int int_10 = 2;

	public const int int_11 = 3;

	public const int int_12 = 4;

	private Class5512 class5512_0;

	private Class5518 class5518_0;

	public Class5564(ArrayList subtables)
		: base(null, new Hashtable(0))
	{
		if (subtables != null && subtables.Count != 0)
		{
			Interface208 @interface = new Class5495(subtables);
			while (@interface.imethod_0())
			{
				object obj = @interface.imethod_1();
				if (obj is Class5511)
				{
					vmethod_0((Class5510)obj);
					continue;
				}
				throw new Exception("subtable must be a glyph definition subtable");
			}
			method_4();
			return;
		}
		throw new Exception("subtables must be non-empty");
	}

	public Class5591 method_9(Class5591 gs, int[][] gpa, string script, string language)
	{
		throw new NotImplementedException();
	}

	protected override void vmethod_0(Class5510 subtable)
	{
		if (subtable is Class5512)
		{
			class5512_0 = (Class5512)subtable;
		}
		else if (!(subtable is Class5514) && !(subtable is Class5516))
		{
			if (!(subtable is Class5518))
			{
				throw new NotSupportedException("unsupported glyph definition subtable type: " + subtable);
			}
			class5518_0 = (Class5518)subtable;
		}
	}

	public bool method_10(int gid, int gc)
	{
		if (class5512_0 != null)
		{
			return class5512_0.vmethod_7(gid, gc);
		}
		return false;
	}

	public int method_11(int gid)
	{
		if (class5512_0 != null)
		{
			return class5512_0.vmethod_8(gid);
		}
		return -1;
	}

	public bool method_12(int gid, int mac)
	{
		if (class5518_0 != null)
		{
			return class5518_0.vmethod_7(gid, mac);
		}
		return false;
	}

	public int method_13(int gid)
	{
		if (class5518_0 != null)
		{
			return class5518_0.vmethod_8(gid);
		}
		return -1;
	}

	public static int smethod_2(string name)
	{
		string value = name.ToLower();
		if ("glyphclass".Equals(value))
		{
			return 1;
		}
		if ("attachmentpoint".Equals(value))
		{
			return 2;
		}
		if ("ligaturecaret".Equals(value))
		{
			return 3;
		}
		if ("markattachment".Equals(value))
		{
			return 4;
		}
		return -1;
	}

	public static string smethod_3(int type)
	{
		string text = null;
		return type switch
		{
			1 => "glyphclass", 
			2 => "attachmentpoint", 
			3 => "ligaturecaret", 
			4 => "markattachment", 
			_ => "unknown", 
		};
	}

	public static Class5510 smethod_4(int type, string id, int sequence, int flags, int format, Class5496 mapping, ArrayList entries)
	{
		Class5510 result = null;
		switch (type)
		{
		case 1:
			result = Class5512.smethod_2(id, sequence, flags, format, mapping, entries);
			break;
		case 2:
			result = Class5514.smethod_2(id, sequence, flags, format, mapping, entries);
			break;
		case 3:
			result = Class5516.smethod_2(id, sequence, flags, format, mapping, entries);
			break;
		case 4:
			result = Class5518.smethod_2(id, sequence, flags, format, mapping, entries);
			break;
		}
		return result;
	}
}
