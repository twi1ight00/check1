using System;
using System.Collections;
using System.IO;
using System.Text;
using ns225;
using ns226;
using ns229;

namespace ns230;

internal class Class6028 : Class6027, Interface257
{
	internal class Class6069 : Class6068
	{
		private int int_0;

		private Hashtable hashtable_0;

		public static Class6069 smethod_1(Class6110 header, Class6017 data)
		{
			return new Class6069(header, data);
		}

		protected Class6069(Class6110 header, Class6017 data)
			: base(header, data)
		{
		}

		protected Class6069(Class6110 header, Class6016 data)
			: base(header, data)
		{
		}

		internal static Class6042.Class6074 smethod_2(Class6016 data, int index)
		{
			if (index < 0 || index > smethod_3(data))
			{
				throw new IndexOutOfRangeException("CMap table is outside the bounds of the known tables.");
			}
			int platformId = data.method_16(Class6028.smethod_0(index));
			int encodingId = data.method_16(2 + Class6028.smethod_0(index));
			int offset = data.method_20(4 + Class6028.smethod_0(index));
			Class6096 cmapId = Class6096.smethod_0(platformId, encodingId);
			return Class6042.Class6074.smethod_0(data, offset, cmapId);
		}

		protected override void vmethod_5()
		{
			hashtable_0 = null;
			method_14(changed: false);
		}

		private void Initialize(Class6016 data)
		{
			hashtable_0 = new Hashtable();
			int num = smethod_3(data);
			for (int i = 0; i < num; i++)
			{
				Class6042.Class6074 @class = smethod_2(data, i);
				hashtable_0.Add(@class.method_16(), @class);
			}
		}

		private Hashtable method_17()
		{
			if (hashtable_0 != null)
			{
				return hashtable_0;
			}
			Initialize(method_6());
			method_13();
			return hashtable_0;
		}

		private static int smethod_3(Class6016 data)
		{
			return data?.method_16(2) ?? 0;
		}

		public int method_18()
		{
			return method_17().Count;
		}

		internal override int vmethod_4()
		{
			if (hashtable_0 != null && hashtable_0.Count != 0)
			{
				bool flag = false;
				int num = 4 + hashtable_0.Count * 8;
				foreach (Class6042.Class6074 value in hashtable_0.Values)
				{
					int num2 = value.vmethod_4();
					num += Math.Abs(num2);
					flag = flag || num2 <= 0;
				}
				if (!flag)
				{
					return num;
				}
				return -num;
			}
			return 0;
		}

		internal override bool vmethod_3()
		{
			if (hashtable_0 == null)
			{
				return false;
			}
			foreach (Class6042.Class6074 value in hashtable_0.Values)
			{
				if (!value.vmethod_3())
				{
					return false;
				}
			}
			return true;
		}

		internal override int vmethod_2(Class6017 newData)
		{
			int num = newData.method_37(0, method_20());
			num += newData.method_37(2, hashtable_0.Count);
			int num2 = num;
			num += hashtable_0.Count * 8;
			foreach (Class6042.Class6074 value in hashtable_0.Values)
			{
				num2 += newData.method_37(num2, value.method_18());
				num2 += newData.method_37(num2, value.method_17());
				num2 += newData.method_41(num2, num);
				num += value.vmethod_2((Class6017)newData.vmethod_1(num));
			}
			return num;
		}

		protected override Class6025 vmethod_6(Class6016 data)
		{
			return new Class6028(method_16(), data);
		}

		public Interface256 method_19()
		{
			return new Class6011(method_17().Values);
		}

		public int method_20()
		{
			return int_0;
		}

		public void method_21(int version)
		{
			int_0 = version;
		}

		public Class6042.Class6074 method_22(Class6096 cmapId, Class6016 data)
		{
			Class6017 @class = Class6017.smethod_1(data.method_3());
			data.CopyTo(@class);
			Class6042.Class6074 class2 = Class6042.Class6074.smethod_0(@class, 0, cmapId);
			Hashtable hashtable = method_17();
			hashtable.Add(cmapId, class2);
			return class2;
		}

		public Class6042.Class6074 method_23(Class6096 cmapId, Class6042.Enum756 cmapFormat)
		{
			Class6042.Class6074 @class = Class6042.Class6074.smethod_1(cmapFormat, cmapId);
			Hashtable hashtable = method_17();
			hashtable.Add(cmapId, @class);
			return @class;
		}

		public Class6042.Class6074 method_24(Class6096 cmapId)
		{
			Hashtable hashtable = method_17();
			return (Class6042.Class6074)hashtable[cmapId];
		}
	}

	internal class Class6096 : IComparable
	{
		public static Class6096 class6096_0 = smethod_0(3, 1);

		public static Class6096 class6096_1 = smethod_0(3, 10);

		public static Class6096 class6096_2 = smethod_0(1, 0);

		private int int_0;

		private int int_1;

		public static Class6096 smethod_0(int platformId, int encodingId)
		{
			return new Class6096(platformId, encodingId);
		}

		private Class6096(int platformId, int encodingId)
		{
			int_0 = platformId;
			int_1 = encodingId;
		}

		public int method_0()
		{
			return int_0;
		}

		public int method_1()
		{
			return int_1;
		}

		public int CompareTo(object obj)
		{
			return GetHashCode() - obj.GetHashCode();
		}

		public bool Equals(Class6096 other)
		{
			if (object.ReferenceEquals(null, other))
			{
				return false;
			}
			if (object.ReferenceEquals(this, other))
			{
				return true;
			}
			if (other.int_0 == int_0)
			{
				return other.int_1 == int_1;
			}
			return false;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("pid = ");
			stringBuilder.Append(int_0);
			stringBuilder.Append(", eid = ");
			stringBuilder.Append(int_1);
			return stringBuilder.ToString();
		}

		public override bool Equals(object obj)
		{
			if (object.ReferenceEquals(null, obj))
			{
				return false;
			}
			if (object.ReferenceEquals(this, obj))
			{
				return true;
			}
			if (obj.GetType() != typeof(Class6096))
			{
				return false;
			}
			return Equals((Class6096)obj);
		}

		public override int GetHashCode()
		{
			return (int_0 << 8) | int_1;
		}

		int IComparable.CompareTo(object obj)
		{
			return CompareTo(obj);
		}

		public static bool operator ==(Class6096 left, Class6096 right)
		{
			return object.Equals(left, right);
		}

		public static bool operator !=(Class6096 left, Class6096 right)
		{
			return !object.Equals(left, right);
		}
	}

	public enum Enum757
	{
		const_0 = 0,
		const_1 = 2,
		const_2 = 4,
		const_3 = 0,
		const_4 = 2,
		const_5 = 4,
		const_6 = 8,
		const_7 = 0,
		const_8 = 0,
		const_9 = 2,
		const_10 = 4,
		const_11 = 6,
		const_12 = 0,
		const_13 = 2,
		const_14 = 4,
		const_15 = 6,
		const_16 = 518,
		const_17 = 0,
		const_18 = 2,
		const_19 = 4,
		const_20 = 6,
		const_21 = 8,
		const_22 = 0,
		const_23 = 2,
		const_24 = 4,
		const_25 = 6,
		const_26 = 8,
		const_27 = 10,
		const_28 = 12,
		const_29 = 14,
		const_30 = 16,
		const_31 = 0,
		const_32 = 2,
		const_33 = 4,
		const_34 = 6,
		const_35 = 8,
		const_36 = 10,
		const_37 = 0,
		const_38 = 4,
		const_39 = 8,
		const_40 = 12,
		const_41 = 8204,
		const_42 = 8208,
		const_43 = 0,
		const_44 = 4,
		const_45 = 8,
		const_46 = 12,
		const_47 = 0,
		const_48 = 4,
		const_49 = 8,
		const_50 = 12,
		const_51 = 16,
		const_52 = 20,
		const_53 = 0,
		const_54 = 4,
		const_55 = 8,
		const_56 = 12,
		const_57 = 16,
		const_58 = 12,
		const_59 = 0,
		const_60 = 4,
		const_61 = 8,
		const_62 = 0,
		const_63 = 4,
		const_64 = 8,
		const_65 = 12,
		const_66 = 16,
		const_67 = 12,
		const_68 = 0,
		const_69 = 4,
		const_70 = 8,
		const_71 = 0,
		const_72 = 2
	}

	internal interface Interface258
	{
		bool imethod_0(Class6096 cmapId);
	}

	private class Class6097 : Interface256
	{
		private int int_0;

		private Interface258 interface258_0;

		private Class6028 class6028_0;

		internal Class6097(Class6028 owner)
		{
			class6028_0 = owner;
		}

		internal Class6097(Class6028 owner, Interface258 filter)
		{
			interface258_0 = filter;
			class6028_0 = owner;
		}

		public bool imethod_0()
		{
			if (interface258_0 == null)
			{
				if (int_0 < class6028_0.method_13())
				{
					return true;
				}
				return false;
			}
			while (true)
			{
				if (int_0 < class6028_0.method_13())
				{
					if (interface258_0.imethod_0(class6028_0.method_14(int_0)))
					{
						break;
					}
					int_0++;
					continue;
				}
				return false;
			}
			return true;
		}

		public object imethod_1()
		{
			if (!imethod_0())
			{
				throw new InvalidOperationException();
			}
			try
			{
				return class6028_0.method_20(int_0++);
			}
			catch (IOException)
			{
				throw new InvalidOperationException("Error during the creation of the CMap.");
			}
		}

		public void Remove()
		{
			throw new NotSupportedException("Cannot remove a CMap table from an existing font.");
		}
	}

	internal class Class6098 : Interface258
	{
		private Class6096 class6096_0;

		public Class6098(Class6096 cmapId)
		{
			class6096_0 = cmapId;
		}

		public bool imethod_0(Class6096 foundCMapId)
		{
			if (class6096_0.Equals(foundCMapId))
			{
				return true;
			}
			return false;
		}
	}

	public static int int_0;

	private Class6028(Class6110 header, Class6016 data)
		: base(header, data)
	{
	}

	public int method_12()
	{
		return class6016_0.method_16(0);
	}

	public int method_13()
	{
		return class6016_0.method_16(2);
	}

	private static int smethod_0(int index)
	{
		return 4 + index * 8;
	}

	public Class6096 method_14(int index)
	{
		return Class6096.smethod_0(method_15(index), method_16(index));
	}

	public int method_15(int index)
	{
		return class6016_0.method_16(smethod_0(index));
	}

	public int method_16(int index)
	{
		return class6016_0.method_16(2 + smethod_0(index));
	}

	public int method_17(int index)
	{
		return class6016_0.method_20(4 + smethod_0(index));
	}

	public Interface256 imethod_0()
	{
		return new Class6097(this);
	}

	public Interface256 method_18(Interface258 filter)
	{
		return new Class6097(this, filter);
	}

	public string method_19()
	{
		StringBuilder stringBuilder = new StringBuilder(method_11());
		stringBuilder.Append(" = { ");
		for (int i = 0; i < method_13(); i++)
		{
			Class6042 value;
			try
			{
				value = method_20(i);
			}
			catch (IOException)
			{
				continue;
			}
			stringBuilder.Append("[0x");
			stringBuilder.Append($"{method_17(i):x}");
			stringBuilder.Append(" = ");
			stringBuilder.Append(value);
			if (i < method_13() - 1)
			{
				stringBuilder.Append("], ");
			}
			else
			{
				stringBuilder.Append("]");
			}
		}
		stringBuilder.Append(" }");
		return stringBuilder.ToString();
	}

	public Class6042 method_20(int index)
	{
		Class6042.Class6074 @class = Class6069.smethod_2(method_0(), index);
		return (Class6042)@class.vmethod_0();
	}

	public Class6042 method_21(int platformId, int encodingId)
	{
		return method_22(Class6096.smethod_0(platformId, encodingId));
	}

	public Class6042 method_22(Class6096 cmapId)
	{
		Interface256 @interface = method_18(new Class6098(cmapId));
		if (@interface.imethod_0())
		{
			return (Class6042)@interface.imethod_1();
		}
		return null;
	}
}
