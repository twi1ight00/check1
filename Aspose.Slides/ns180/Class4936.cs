using ns171;
using ns175;
using ns177;
using ns196;

namespace ns180;

internal class Class4936 : Interface156
{
	private static string string_0 = typeof(Interface191).FullName;

	private static string string_1 = typeof(Interface206).FullName;

	private Interface156 interface156_0;

	private Class5738 class5738_0;

	public Class4936(Interface156 @delegate, Class5738 userAgent)
	{
		interface156_0 = @delegate;
		class5738_0 = userAgent;
	}

	public void imethod_0(Class5596 @event)
	{
		if (@event.method_1().StartsWith(string_0))
		{
			if ((bool)@event.method_7("canRecover") && !class5738_0.method_42())
			{
				@event.method_5(Class5598.class5598_1);
			}
		}
		else if (@event.method_1().StartsWith(string_1) && (bool)@event.method_7("canRecover"))
		{
			@event.method_5(Class5598.class5598_1);
		}
		interface156_0.imethod_0(@event);
	}
}
