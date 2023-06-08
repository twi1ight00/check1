using System;
using ns225;
using ns226;
using ns229;

namespace ns230;

internal class Class6045 : Class6042
{
	internal class Class6077 : Class6074
	{
		internal Class6077(Class6017 data, int offset, Class6028.Class6096 cmapId)
			: base((data == null) ? null : ((Class6017)data.vmethod_0(offset, data.method_20(offset + 4))), Enum756.const_6, cmapId)
		{
		}

		internal Class6077(Class6016 data, int offset, Class6028.Class6096 cmapId)
			: base((data == null) ? null : ((Class6016)data.vmethod_0(offset, data.method_20(offset + 4))), Enum756.const_6, cmapId)
		{
		}

		protected override Class6025 vmethod_6(Class6016 data)
		{
			return new Class6045(data, method_16());
		}
	}

	private class Class6090 : Interface256
	{
		private int int_0;

		private int int_1;

		private bool bool_0;

		private int int_2;

		private Class6045 class6045_0;

		public Class6090(Class6045 owner)
		{
			class6045_0 = owner;
			int_2 = class6045_0.method_11(int_0);
			int_1 = class6045_0.method_12(int_0);
			bool_0 = true;
		}

		public bool imethod_0()
		{
			if (bool_0)
			{
				return true;
			}
			if (int_0 >= class6045_0.int_2)
			{
				return false;
			}
			if (int_2 < int_1)
			{
				int_2++;
				bool_0 = true;
				return true;
			}
			int_0++;
			if (int_0 < class6045_0.int_2)
			{
				bool_0 = true;
				int_2 = class6045_0.method_11(int_0);
				int_1 = class6045_0.method_12(int_0);
				return true;
			}
			return false;
		}

		public object imethod_1()
		{
			if (!bool_0 && !imethod_0())
			{
				throw new InvalidOperationException("No more characters to iterate.");
			}
			bool_0 = false;
			return int_2;
		}

		public void Remove()
		{
			throw new NotSupportedException("Unable to remove a character from cmap.");
		}
	}

	private int int_2;

	protected Class6045(Class6016 data, Class6028.Class6096 cmapId)
		: base(data, 12, cmapId)
	{
		int_2 = class6016_0.method_20(12);
	}

	private int method_11(int groupIndex)
	{
		return class6016_0.method_20(16 + groupIndex * 12);
	}

	private int method_12(int groupIndex)
	{
		return class6016_0.method_20(16 + groupIndex * 12 + 4);
	}

	private int method_13(int groupIndex)
	{
		return class6016_0.method_20(16 + groupIndex * 12 + 8);
	}

	public override int vmethod_2(int character)
	{
		int num = class6016_0.method_29(16, 12, 20, 12, int_2, character);
		if (num == -1)
		{
			return Class6028.int_0;
		}
		return method_13(num) + (character - method_11(num));
	}

	public override int vmethod_1()
	{
		return class6016_0.method_20(8);
	}

	public override Interface256 imethod_0()
	{
		return new Class6090(this);
	}
}
