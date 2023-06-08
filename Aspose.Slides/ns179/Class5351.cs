using System;
using ns178;

namespace ns179;

internal class Class5351 : Class5349
{
	private string string_1;

	private bool bool_0;

	public Class5351(string uri, bool newWindow)
	{
		if (uri == null)
		{
			throw new NullReferenceException("uri must not be null");
		}
		string_1 = uri;
		bool_0 = newWindow;
	}

	public string method_6()
	{
		return string_1;
	}

	public bool method_7()
	{
		return bool_0;
	}

	public override bool vmethod_0(Class5349 other)
	{
		if (other == null)
		{
			throw new NullReferenceException("other must not be null");
		}
		if (!(other is Class5351))
		{
			return false;
		}
		Class5351 @class = (Class5351)other;
		if (!method_6().Equals(@class.method_6()))
		{
			return false;
		}
		if (method_7() != @class.method_7())
		{
			return false;
		}
		return true;
	}

	public override string vmethod_1()
	{
		return "aps-" + Class5355.class5619_5.method_2();
	}

	public override void imethod_0(Interface153 handler)
	{
		Class5699 @class = new Class5699();
		if (method_4())
		{
			@class.method_1(null, "id", "id", "CDATA", method_1());
		}
		@class.method_1(null, "uri", "uri", "CDATA", method_6());
		if (method_7())
		{
			@class.method_1(null, "show-destination", "show-destination", "CDATA", "new");
		}
		handler.imethod_6(Class5355.class5619_5.method_0(), Class5355.class5619_5.method_2(), Class5355.class5619_5.method_3(), @class);
		handler.imethod_7(Class5355.class5619_5.method_0(), Class5355.class5619_5.method_2(), Class5355.class5619_5.method_3());
	}
}
