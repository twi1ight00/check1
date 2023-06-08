using ns175;

namespace ns200;

internal abstract class Class5471 : Class5470
{
	private static string string_1 = "renderer";

	public Class5471(Class5738 userAgent)
		: base(userAgent)
	{
	}

	protected Interface201 method_1(Interface177 renderer)
	{
		return method_0(renderer.imethod_0());
	}

	protected Interface201 method_2(string mimeType)
	{
		return method_0(mimeType);
	}

	public override string vmethod_0()
	{
		return string_1;
	}
}
