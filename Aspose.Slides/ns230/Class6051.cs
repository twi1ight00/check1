using System;
using ns225;
using ns226;
using ns229;

namespace ns230;

internal class Class6051 : Class6042
{
	internal class Class6083 : Class6074
	{
		internal Class6083(Class6017 data, int offset, Class6028.Class6096 cmapId)
			: base((data == null) ? null : ((Class6017)data.vmethod_0(offset, data.method_20(offset + 4))), Enum756.const_4, cmapId)
		{
		}

		internal Class6083(Class6016 data, int offset, Class6028.Class6096 cmapId)
			: base((data == null) ? null : ((Class6016)data.vmethod_0(offset, data.method_20(offset + 4))), Enum756.const_4, cmapId)
		{
		}

		protected override Class6025 vmethod_6(Class6016 data)
		{
			return new Class6051(data, method_16());
		}
	}

	private class Class6095 : Interface256
	{
		private int int_0;

		private int int_1;

		private int int_2;

		private int int_3;

		private bool bool_0;

		private Class6051 class6051_0;

		public Class6095(Class6051 owner)
		{
			int_0 = 0;
			int_1 = -1;
			class6051_0 = owner;
		}

		public bool imethod_0()
		{
			if (bool_0)
			{
				return true;
			}
			while (true)
			{
				if (int_0 < class6051_0.int_2)
				{
					if (int_1 >= 0)
					{
						if (int_3 < int_2)
						{
							break;
						}
						int_0++;
						int_1 = -1;
						continue;
					}
					int_1 = class6051_0.method_11(int_0);
					int_2 = class6051_0.method_12(int_0);
					int_3 = int_1;
					bool_0 = true;
					return true;
				}
				return false;
			}
			int_3++;
			bool_0 = true;
			return true;
		}

		public object imethod_1()
		{
			if (!bool_0 && !imethod_0())
			{
				throw new InvalidOperationException("No more characters to iterate.");
			}
			bool_0 = false;
			return int_3;
		}

		public void Remove()
		{
			throw new NotSupportedException("Unable to remove a character from cmap.");
		}
	}

	private int int_2;

	protected Class6051(Class6016 data, Class6028.Class6096 cmapId)
		: base(data, 8, cmapId)
	{
		int_2 = class6016_0.method_20(8204);
	}

	private int method_11(int groupIndex)
	{
		return method_0().method_20(8208 + groupIndex * 12);
	}

	private int method_12(int groupIndex)
	{
		return method_0().method_20(8208 + groupIndex * 12 + 4);
	}

	public override int vmethod_2(int character)
	{
		return method_0().method_29(8208, 12, 8212, 12, int_2, character);
	}

	public override int vmethod_1()
	{
		return class6016_0.method_20(8);
	}

	public override Interface256 imethod_0()
	{
		return new Class6095(this);
	}
}
