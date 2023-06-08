using System;
using ns225;
using ns226;
using ns229;

namespace ns230;

internal class Class6050 : Class6042
{
	internal class Class6082 : Class6074
	{
		internal Class6082(Class6017 data, int offset, Class6028.Class6096 cmapId)
			: base((data == null) ? null : ((Class6017)data.vmethod_0(offset, data.method_16(offset + 2))), Enum756.const_3, cmapId)
		{
		}

		internal Class6082(Class6016 data, int offset, Class6028.Class6096 cmapId)
			: base((data == null) ? null : ((Class6016)data.vmethod_0(offset, data.method_16(offset + 2))), Enum756.const_3, cmapId)
		{
		}

		protected override Class6025 vmethod_6(Class6016 data)
		{
			return new Class6050(data, method_16());
		}
	}

	internal class Class6094 : Interface256
	{
		private int int_0;

		private Class6050 class6050_0;

		public Class6094(Class6050 owner)
		{
			int_0 = owner.int_2;
			class6050_0 = owner;
		}

		public bool imethod_0()
		{
			if (int_0 < class6050_0.int_2 + class6050_0.int_3)
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

	private int int_2;

	private int int_3;

	protected Class6050(Class6016 data, Class6028.Class6096 cmapId)
		: base(data, 6, cmapId)
	{
		int_2 = class6016_0.method_16(6);
		int_3 = class6016_0.method_16(8);
	}

	public override int vmethod_2(int character)
	{
		if (character >= int_2 && character < int_2 + int_3)
		{
			return class6016_0.method_16(10 + (character - int_2) * 2);
		}
		return Class6028.int_0;
	}

	public override int vmethod_1()
	{
		return class6016_0.method_16(4);
	}

	public override Interface256 imethod_0()
	{
		return new Class6094(this);
	}
}
