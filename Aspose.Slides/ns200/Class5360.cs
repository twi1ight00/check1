using System.Collections;
using System.Drawing;
using System.Xml;
using ns173;
using ns175;
using ns184;
using ns185;

namespace ns200;

internal abstract class Class5360 : Class5359
{
	protected Class5730 class5730_0;

	protected Interface193 interface193_0;

	protected ArrayList arrayList_0;

	public Class5360(Class5738 userAgent)
		: base(userAgent)
	{
	}

	public void method_9(ArrayList fontList)
	{
		if (arrayList_0 == null)
		{
			method_10(fontList);
		}
		else
		{
			arrayList_0.AddRange(fontList);
		}
	}

	public void method_10(ArrayList embedFontInfoLisT)
	{
		arrayList_0 = embedFontInfoLisT;
	}

	public ArrayList method_11()
	{
		return arrayList_0;
	}

	public override void imethod_4(Class5730 inFontInfo)
	{
		class5730_0 = inFontInfo;
		Class5458 @class = class5738_0.method_0().method_51();
		Interface195[] fontCollections = new Interface195[1]
		{
			new Class5457(@class.method_1())
		};
		@class.method_11(method_16(), fontCollections);
	}

	protected Class5729 method_12(Class4942 area)
	{
		Class5732 @class = (Class5732)area.method_33(Class5757.int_2);
		int fontSize = (int)area.method_33(Class5757.int_3);
		return class5730_0.method_12(@class, fontSize, @class.method_4());
	}

	protected Class5467 method_13()
	{
		return new Class5467(this, imethod_0());
	}

	protected virtual Class5467 vmethod_28(int x, int y, int width, int height, Hashtable foreignAttributes)
	{
		Class5467 @class = method_13();
		@class.method_2(class5738_0);
		@class.method_4("width", width);
		@class.method_4("height", height);
		@class.method_4("xpos", x);
		@class.method_4("ypos", y);
		@class.method_4("pageViewport", method_0());
		if (foreignAttributes != null)
		{
			@class.method_4("foreign-attributes", foreignAttributes);
		}
		return @class;
	}

	public void method_14(XmlDocument doc, string ns, RectangleF pos, Hashtable foreignAttributes)
	{
		int x = int_0 + (int)pos.X;
		int y = class5358_0.Value + (int)pos.Y;
		int width = (int)pos.Width;
		int height = (int)pos.Height;
		Class5467 ctx = vmethod_28(x, y, width, height, foreignAttributes);
		method_6(ctx, doc, ns);
	}

	public Interface193 method_15()
	{
		if (interface193_0 == null)
		{
			interface193_0 = new Class5461(class5738_0);
		}
		return interface193_0;
	}

	public Class5730 method_16()
	{
		return class5730_0;
	}
}
