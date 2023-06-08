using System;
using System.Collections;
using System.Globalization;
using System.IO;
using ns175;
using ns178;
using ns183;
using ns184;
using ns200;

namespace ns173;

internal class Class4980 : Class4979
{
	protected Interface177 interface177_0;

	protected ArrayList arrayList_1 = new ArrayList();

	private ArrayList arrayList_2 = new ArrayList();

	private ArrayList arrayList_3 = new ArrayList();

	public Class4980(Class5738 userAgent, string outputFormat, Class5730 fontInfo, Stream stream)
	{
		interface177_0 = userAgent.method_44().method_11(userAgent, outputFormat);
		try
		{
			interface177_0.imethod_4(fontInfo);
			if (!fontInfo.method_1())
			{
				throw new Exception53("No default font defined by OutputConverter");
			}
			interface177_0.imethod_1(stream);
		}
		catch (IOException ex)
		{
			throw new Exception53(ex.Message);
		}
	}

	public override void vmethod_4(CultureInfo locale)
	{
		interface177_0.imethod_6(locale);
	}

	public override void vmethod_0(Class4975 pageSequence)
	{
		base.vmethod_0(pageSequence);
		if (interface177_0.imethod_5())
		{
			interface177_0.imethod_10(method_0());
		}
	}

	public override void vmethod_1(Class4974 page)
	{
		base.vmethod_1(page);
		if (interface177_0.imethod_5() && page.imethod_2())
		{
			if (!interface177_0.imethod_5() && page.method_10().method_14(page))
			{
				interface177_0.imethod_10(method_0());
			}
			try
			{
				interface177_0.imethod_11(page);
			}
			catch (IOException ioe)
			{
				Interface200 @interface = Class5466.smethod_0(interface177_0.imethod_3().method_48());
				@interface.imethod_0(this, ioe);
			}
			catch (Exception53 exception)
			{
				string text = "Error while rendering page " + page.method_15();
				throw new InvalidOperationException("Fatal error occurred. Cannot continue. " + exception.GetType().Name + ": " + text);
			}
			page.method_29();
		}
		else
		{
			method_6(page);
		}
		if (method_4(page, renderUnresolved: false))
		{
			method_7(arrayList_2);
			arrayList_2.Clear();
		}
	}

	protected bool method_4(Class4974 newPageViewport, bool renderUnresolved)
	{
		Interface208 @interface = new Class5495(arrayList_1);
		while (@interface.imethod_0())
		{
			Class4974 @class = (Class4974)@interface.imethod_1();
			if (!@class.imethod_2() && !renderUnresolved)
			{
				if (!interface177_0.imethod_5())
				{
					break;
				}
				continue;
			}
			if (!interface177_0.imethod_5() && @class.method_10().method_14(@class))
			{
				interface177_0.imethod_10(@class.method_10());
			}
			method_5(@class);
			@class.method_29();
			@interface.imethod_6();
		}
		if (!interface177_0.imethod_5())
		{
			return arrayList_1.Count == 0;
		}
		return true;
	}

	protected void method_5(Class4974 pageViewport)
	{
		interface177_0.imethod_11(pageViewport);
		if (!pageViewport.imethod_2())
		{
			string[] array = pageViewport.imethod_3();
			string[] array2 = array;
			foreach (string id in array2)
			{
				Interface159 @interface = Class4940.smethod_0(interface177_0.imethod_3().method_48());
				@interface.imethod_1(this, pageViewport.method_15(), id);
			}
		}
	}

	protected void method_6(Class4974 page)
	{
		if (interface177_0.imethod_5())
		{
			interface177_0.imethod_8(page);
		}
		arrayList_1.Add(page);
	}

	public override void vmethod_2(Interface157 oDI)
	{
		switch (oDI.imethod_0())
		{
		default:
			throw new Exception();
		case 0:
			interface177_0.imethod_7(oDI);
			break;
		case 1:
			arrayList_2.Add(oDI);
			break;
		case 2:
			arrayList_3.Add(oDI);
			break;
		}
	}

	private void method_7(ArrayList list)
	{
		foreach (Interface157 item in list)
		{
			interface177_0.imethod_7(item);
		}
	}

	public override void vmethod_3()
	{
		method_4(null, renderUnresolved: true);
		method_7(arrayList_2);
		arrayList_2.Clear();
		method_7(arrayList_3);
		try
		{
			interface177_0.imethod_2();
		}
		catch (IOException ex)
		{
			throw new Exception51(ex.Message);
		}
	}
}
