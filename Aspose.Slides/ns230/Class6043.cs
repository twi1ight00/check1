using System;
using ns225;
using ns226;
using ns229;

namespace ns230;

internal class Class6043 : Class6042
{
	internal class Class6075 : Class6074
	{
		internal Class6075(Class6017 data, int offset, Class6028.Class6096 cmapId)
			: base((data == null) ? null : ((Class6017)data.vmethod_0(offset, data.method_16(offset + 2))), Enum756.const_0, cmapId)
		{
		}

		internal Class6075(Class6016 data, int offset, Class6028.Class6096 cmapId)
			: base((data == null) ? null : ((Class6016)data.vmethod_0(offset, data.method_16(offset + 2))), Enum756.const_0, cmapId)
		{
		}

		protected override Class6025 vmethod_6(Class6016 data)
		{
			return new Class6043(data, method_16());
		}
	}

	internal class Class6088 : Interface256
	{
		private int int_0;

		protected static int int_1 = 255;

		public bool imethod_0()
		{
			if (int_0 <= int_1)
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

	protected Class6043(Class6016 data, Class6028.Class6096 cmapId)
		: base(data, 0, cmapId)
	{
	}

	public override int vmethod_2(int character)
	{
		if (character >= 0 && character <= 255)
		{
			return class6016_0.method_13(character + 6);
		}
		return Class6028.int_0;
	}

	public override int vmethod_1()
	{
		return class6016_0.method_16(4);
	}

	public override Interface256 imethod_0()
	{
		return new Class6088();
	}
}
