using ns196;

namespace ns198;

internal class Class5339 : Class5338
{
	private Class5294 class5294_0;

	private Class5282 class5282_0;

	private Class5684 class5684_0;

	public void method_6(Class5282 fblm)
	{
		class5282_0 = fblm;
	}

	public Class5282 method_7()
	{
		return class5282_0;
	}

	public Class5339(int width, Class5684 alignmentContext, Class5254 pos, bool auxiliary)
		: base(width, pos, auxiliary)
	{
		class5684_0 = alignmentContext;
	}

	public Class5684 method_8()
	{
		return class5684_0;
	}

	public void method_9(Class5294 fblm)
	{
		class5294_0 = fblm;
	}

	public Class5294 method_10()
	{
		return class5294_0;
	}

	public bool method_11()
	{
		if (class5294_0 == null)
		{
			return class5282_0 != null;
		}
		return true;
	}

	public bool method_12()
	{
		return class5294_0 != null;
	}

	public bool method_13()
	{
		return class5282_0 != null;
	}
}
