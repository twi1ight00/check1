using System;
using System.Collections;
using System.IO;
using ns173;
using ns175;
using ns178;
using ns191;
using ns200;

namespace ns202;

internal abstract class Class5364 : Class5360
{
	protected Interface153 interface153_0;

	protected Stream stream_0;

	protected ArrayList arrayList_1;

	public Class5364(Class5738 userAgent)
		: base(userAgent)
	{
	}

	protected void method_17(Exception51 saxe)
	{
		throw new Exception(saxe.Message);
	}

	public override void imethod_1(Stream outputStream)
	{
		if (interface153_0 == null)
		{
			interface153_0 = new Class4930(outputStream);
			stream_0 = outputStream;
		}
		try
		{
			interface153_0.imethod_1();
		}
		catch (Exception51 saxe)
		{
			method_17(saxe);
		}
	}

	public override void imethod_2()
	{
		try
		{
			interface153_0.imethod_2();
		}
		catch (Exception51 saxe)
		{
			method_17(saxe);
		}
		if (stream_0 != null)
		{
			stream_0.Flush();
		}
	}

	public override void imethod_7(Interface157 oDI)
	{
		if (oDI is Class4938)
		{
			vmethod_30((Class4938)oDI);
		}
		else if (oDI is Class4978)
		{
			Interface239 value = ((Class4978)oDI).method_0();
			if (arrayList_1 == null)
			{
				arrayList_1 = new ArrayList();
			}
			arrayList_1.Add(value);
		}
	}

	public void method_18(Interface153 handler)
	{
		interface153_0 = handler;
	}

	protected abstract void vmethod_29(ArrayList attachments);

	protected abstract void vmethod_30(Class4938 odi);
}
