using ns171;

namespace ns176;

internal class Class5753 : Interface172
{
	private Interface172 interface172_0;

	private int int_0;

	private int int_1;

	public Class5753(Interface172 parentContext, int lengthBase, int lengthBaseValue)
	{
		interface172_0 = parentContext;
		int_0 = lengthBase;
		int_1 = lengthBaseValue;
	}

	public int imethod_0(int lengthBasE, Class5094 fobj)
	{
		if (lengthBasE == int_0)
		{
			return int_1;
		}
		if (interface172_0 != null)
		{
			return interface172_0.imethod_0(lengthBasE, fobj);
		}
		return -1;
	}
}
