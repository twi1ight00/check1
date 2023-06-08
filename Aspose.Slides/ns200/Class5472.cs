using System;
using System.Collections;
using ns175;
using ns184;
using ns185;
using ns207;

namespace ns200;

internal class Class5472 : Class5471, Interface197, Interface202
{
	public Class5472(Class5738 userAgent)
		: base(userAgent)
	{
	}

	public void imethod_2(Interface177 renderer)
	{
		Interface201 @interface = method_1(renderer);
		if (@interface != null)
		{
			Class5360 @class = (Class5360)renderer;
			Interface193 fontResolver = @class.method_15();
			Interface218 listener = new Class5600(renderer.imethod_3().method_48());
			ArrayList fontList = method_3(fontResolver, listener);
			@class.method_9(fontList);
		}
	}

	protected ArrayList method_3(Interface193 fontResolver, Interface218 listener)
	{
		if (fontResolver == null)
		{
			fontResolver = Class5458.smethod_0(class5738_0.method_51());
		}
		throw new NotImplementedException();
	}

	public void imethod_0(Interface196 documentHandler)
	{
	}

	public void imethod_1(Interface196 documentHandler, Class5730 fontInfo)
	{
		Class5458 @class = class5738_0.method_0().method_51();
		ArrayList arrayList = new ArrayList();
		arrayList.Add(new Class5457(@class.method_1()));
		Interface201 @interface = method_2(documentHandler.imethod_9());
		if (@interface != null)
		{
			Interface193 fontResolver = new Class5461(class5738_0);
			Interface218 listener = new Class5600(class5738_0.method_48());
			method_3(fontResolver, listener);
			throw new NotImplementedException();
		}
		@class.method_11(fontInfo, (Interface195[])arrayList.ToArray(typeof(Interface195)));
		documentHandler.imethod_2(fontInfo);
	}
}
