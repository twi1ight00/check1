using ns226;
using ns229;

namespace ns231;

internal class Class6039 : Class6026
{
	internal class Class6059 : Class6057
	{
		public static Class6059 smethod_1(Class6110 header, Class6017 data)
		{
			return new Class6059(header, data);
		}

		protected Class6059(Class6110 header, Class6017 data)
			: base(header, data)
		{
		}

		protected Class6059(Class6110 header, Class6016 data)
			: base(header, data)
		{
		}

		protected override Class6025 vmethod_6(Class6016 data)
		{
			return new Class6039(method_16(), data);
		}
	}

	protected Class6039(Class6110 header, Class6016 data)
		: base(header, data)
	{
	}

	public int method_12(int index)
	{
		return class6016_0.method_26(index);
	}

	public int method_13()
	{
		return method_2() / 2;
	}
}
