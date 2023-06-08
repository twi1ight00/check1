using ns226;

namespace ns229;

internal abstract class Class6041 : Class6025
{
	internal abstract class Class6073 : Class6054
	{
		private Class6016 class6016_1;

		protected Class6073(Class6017 data, Class6016 masterData)
			: base(data)
		{
			class6016_1 = masterData;
		}

		protected Class6073(Class6016 data, Class6016 masterData)
			: base(data)
		{
			class6016_1 = masterData;
		}

		protected Class6073(Class6017 data)
			: base(data)
		{
		}

		protected Class6073(Class6016 data)
			: base(data)
		{
		}

		protected Class6073(int dataSize)
			: base(dataSize)
		{
		}

		protected Class6016 method_15()
		{
			return class6016_1;
		}
	}

	private Class6016 class6016_1;

	private int int_0;

	protected Class6041(Class6016 data, Class6016 masterData)
		: base(data)
	{
		class6016_1 = masterData;
	}

	protected Class6041(Class6016 data)
		: this(data, null)
	{
	}

	protected Class6041(Class6016 data, int offset, int length)
		: this((Class6016)data.vmethod_0(offset, length))
	{
	}

	protected Class6016 method_5()
	{
		return class6016_1;
	}

	public virtual int vmethod_0()
	{
		return int_0;
	}

	protected void method_6(int padding)
	{
		int_0 = padding;
	}
}
