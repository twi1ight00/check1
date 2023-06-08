using ns175;

namespace ns186;

internal class Exception55 : Exception53
{
	private string string_2;

	public Exception55(string detail)
		: base(detail)
	{
	}

	public void method_5(Class5750 propInfo)
	{
		method_0(propInfo.method_3().method_0().method_1());
		string_2 = propInfo.method_4().method_17();
	}

	public void method_6(string propertyNamE)
	{
		string_2 = propertyNamE;
	}

	public override string vmethod_0()
	{
		if (string_2 != null)
		{
			return base.vmethod_0() + "; property:'" + string_2 + "'";
		}
		return base.vmethod_0();
	}
}
