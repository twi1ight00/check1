using ns183;
using ns277;

namespace ns280;

internal class Class6763 : Interface171
{
	private Interface322 interface322_0;

	public Class6763(Interface322 callback)
	{
		interface322_0 = callback;
	}

	public Class5371 imethod_0(object sender, EventArgs6 e)
	{
		Class6814 obj = interface322_0.imethod_0(sender, smethod_0(e));
		return smethod_1(obj);
	}

	private static EventArgs13 smethod_0(EventArgs6 obj)
	{
		return new EventArgs13(obj.Uri);
	}

	private static Class5371 smethod_1(Class6814 obj)
	{
		Class5371 @class = new Class5371(obj.Data, obj.EncodingIfKnown);
		@class.Exception = obj.ExceptionIfAny;
		@class.MIMEType = obj.MIMEIfKnown;
		return @class;
	}
}
