using ns171;

namespace ns205;

internal class Class5678 : Interface231, Interface234
{
	private Class5444 class5444_0;

	private Class5444 class5444_1;

	private Class5444 class5444_2;

	private Class5444 class5444_3;

	private Class5444 class5444_4;

	private Class5445 class5445_0;

	public Class5678()
		: this(Class5445.class5445_0)
	{
	}

	public Class5678(Class5445 writingMode)
	{
		imethod_12(writingMode);
	}

	public Class5444 imethod_0()
	{
		return class5444_0;
	}

	public void imethod_1(Class5444 direction)
	{
		class5444_0 = direction;
	}

	public Class5444 imethod_3()
	{
		return class5444_1;
	}

	public void imethod_2(Class5444 direction)
	{
		class5444_1 = direction;
	}

	public Class5444 imethod_4()
	{
		return class5444_2;
	}

	public void imethod_8(Class5444 direction)
	{
		class5444_2 = direction;
	}

	public Class5444 imethod_5()
	{
		return class5444_3;
	}

	public void imethod_9(Class5444 direction)
	{
		class5444_3 = direction;
	}

	public Class5444 imethod_6()
	{
		return class5444_4;
	}

	public void imethod_10(Class5444 direction)
	{
		class5444_4 = direction;
	}

	public Class5445 imethod_7()
	{
		return class5445_0;
	}

	public void imethod_11(Class5445 writingModE)
	{
		class5445_0 = writingModE;
	}

	public void imethod_12(Class5445 writingModE)
	{
		writingModE.method_2(this);
	}

	public static Interface231 smethod_0(Class5088 fn)
	{
		Class5088 @class = fn;
		while (true)
		{
			if (@class != null)
			{
				if (@class is Interface231)
				{
					break;
				}
				@class = @class.method_4();
				continue;
			}
			return null;
		}
		return (Interface231)@class;
	}
}
