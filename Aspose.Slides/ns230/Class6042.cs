using System;
using System.Text;
using ns225;
using ns226;
using ns229;

namespace ns230;

internal abstract class Class6042 : Class6041, Interface257
{
	public enum Enum756
	{
		const_0 = 0,
		const_1 = 2,
		const_2 = 4,
		const_3 = 6,
		const_4 = 8,
		const_5 = 10,
		const_6 = 12,
		const_7 = 13,
		const_8 = 14
	}

	protected class Class6087 : Interface256
	{
		private int int_0;

		private int int_1;

		public Class6087(int start, int end)
		{
			int_0 = start;
			int_1 = end;
		}

		public bool imethod_0()
		{
			if (int_0 < int_1)
			{
				return true;
			}
			return false;
		}

		public object imethod_1()
		{
			if (!imethod_0())
			{
				throw new InvalidOperationException("No more characters to iterate.");
			}
			return int_0++;
		}

		public void Remove()
		{
			throw new NotSupportedException("Unable to remove a character from cmap.");
		}
	}

	internal abstract class Class6074 : Class6073
	{
		private Enum756 enum756_0;

		private Class6028.Class6096 class6096_0;

		private int int_0;

		protected Class6074(Class6016 data, Enum756 format, Class6028.Class6096 cmapId)
			: base(data)
		{
			enum756_0 = format;
			class6096_0 = cmapId;
		}

		public Class6028.Class6096 method_16()
		{
			return class6096_0;
		}

		public int method_17()
		{
			return method_16().method_1();
		}

		public int method_18()
		{
			return method_16().method_0();
		}

		public Enum756 method_19()
		{
			return enum756_0;
		}

		public int method_20()
		{
			return int_0;
		}

		public void method_21(int language)
		{
			int_0 = language;
		}

		protected Class6074(Class6017 data, Enum756 format, Class6028.Class6096 cmapId)
			: base(data)
		{
			enum756_0 = format;
			class6096_0 = cmapId;
		}

		protected override void vmethod_5()
		{
		}

		internal override int vmethod_4()
		{
			return method_6().method_2();
		}

		internal override bool vmethod_3()
		{
			return true;
		}

		internal override int vmethod_2(Class6017 newData)
		{
			return method_6().CopyTo(newData);
		}

		internal static Class6074 smethod_0(Class6016 data, int offset, Class6028.Class6096 cmapId)
		{
			return (Enum756)data.method_16(offset) switch
			{
				Enum756.const_0 => new Class6043.Class6075(data, offset, cmapId), 
				Enum756.const_1 => new Class6048.Class6080(data, offset, cmapId), 
				Enum756.const_2 => new Class6049.Class6081(data, offset, cmapId), 
				Enum756.const_3 => new Class6050.Class6082(data, offset, cmapId), 
				Enum756.const_4 => new Class6051.Class6083(data, offset, cmapId), 
				Enum756.const_5 => new Class6044.Class6076(data, offset, cmapId), 
				Enum756.const_6 => new Class6045.Class6077(data, offset, cmapId), 
				Enum756.const_7 => new Class6046.Class6078(data, offset, cmapId), 
				Enum756.const_8 => new Class6047.Class6079(data, offset, cmapId), 
				_ => null, 
			};
		}

		internal static Class6074 smethod_1(Enum756 cmapFormat, Class6028.Class6096 cmapId)
		{
			return cmapFormat switch
			{
				Enum756.const_2 => new Class6049.Class6081(null, 0, cmapId), 
				Enum756.const_0 => new Class6043.Class6075(null, 0, cmapId), 
				_ => null, 
			};
		}

		public string method_22()
		{
			return $"{method_16()}, format = {method_19()}";
		}
	}

	protected int int_1;

	protected Class6028.Class6096 class6096_0;

	protected Class6042(Class6016 data, int format, Class6028.Class6096 cmapId)
		: base(data)
	{
		int_1 = format;
		class6096_0 = cmapId;
	}

	public int method_7()
	{
		return int_1;
	}

	public Class6028.Class6096 method_8()
	{
		return class6096_0;
	}

	public int method_9()
	{
		return method_8().method_0();
	}

	public int method_10()
	{
		return method_8().method_1();
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("cmap: ");
		stringBuilder.Append(method_8());
		stringBuilder.Append(", ");
		stringBuilder.Append((Enum756)method_7());
		stringBuilder.Append(", Data Size=0x");
		stringBuilder.Append($"{class6016_0.method_2():x}");
		return stringBuilder.ToString();
	}

	public bool Equals(Class6042 other)
	{
		if (object.ReferenceEquals(null, other))
		{
			return false;
		}
		if (object.ReferenceEquals(this, other))
		{
			return true;
		}
		return object.Equals(other.class6096_0, class6096_0);
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
		if (obj.GetType() != typeof(Class6042))
		{
			return false;
		}
		return Equals((Class6042)obj);
	}

	public override int GetHashCode()
	{
		if (!(class6096_0 != null))
		{
			return 0;
		}
		return class6096_0.GetHashCode();
	}

	public abstract Interface256 imethod_0();

	public static bool operator ==(Class6042 left, Class6042 right)
	{
		return object.Equals(left, right);
	}

	public static bool operator !=(Class6042 left, Class6042 right)
	{
		return !object.Equals(left, right);
	}

	public abstract int vmethod_1();

	public abstract int vmethod_2(int character);
}
