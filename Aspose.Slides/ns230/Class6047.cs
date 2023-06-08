using ns225;
using ns226;
using ns229;

namespace ns230;

internal class Class6047 : Class6042
{
	internal class Class6079 : Class6074
	{
		internal Class6079(Class6017 data, int offset, Class6028.Class6096 cmapId)
			: base((data == null) ? null : ((Class6017)data.vmethod_0(offset, data.method_20(offset + 2))), Enum756.const_8, cmapId)
		{
		}

		internal Class6079(Class6016 data, int offset, Class6028.Class6096 cmapId)
			: base((data == null) ? null : ((Class6016)data.vmethod_0(offset, data.method_20(offset + 2))), Enum756.const_8, cmapId)
		{
		}

		protected override Class6025 vmethod_6(Class6016 data)
		{
			return new Class6047(data, method_16());
		}
	}

	protected Class6047(Class6016 data, Class6028.Class6096 cmapId)
		: base(data, 14, cmapId)
	{
	}

	public override int vmethod_2(int character)
	{
		return Class6028.int_0;
	}

	public override int vmethod_1()
	{
		return 0;
	}

	public override Interface256 imethod_0()
	{
		return null;
	}
}
