using ns277;
using ns73;

namespace ns288;

internal class Class6777 : Interface104
{
	private Interface322 interface322_0;

	public Class6777(Interface322 resourceLoadingCallback)
	{
		interface322_0 = resourceLoadingCallback;
	}

	public Class4258 imethod_0(object sender, EventArgs1 e)
	{
		Class6814 obj = interface322_0.imethod_0(sender, smethod_0(e));
		return smethod_1(obj);
	}

	private static EventArgs13 smethod_0(EventArgs1 obj)
	{
		return new EventArgs13(obj.Uri);
	}

	private static Class4258 smethod_1(Class6814 obj)
	{
		return new Class4258(obj.Data, obj.EncodingIfKnown);
	}
}
