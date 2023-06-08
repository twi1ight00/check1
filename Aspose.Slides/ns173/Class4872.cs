using System.Collections;
using System.Globalization;
using System.IO;
using ns171;
using ns175;
using ns176;
using ns188;
using ns190;
using ns191;
using ns193;
using ns196;
using ns198;

namespace ns173;

internal class Class4872 : Class4866
{
	private Interface186 interface186_0;

	protected Class4979 class4979_0;

	private bool bool_0 = true;

	private Class5494 class5494_0;

	private Class5170 class5170_0;

	private Class5493 class5493_0 = new Class5493();

	private Interface227 interface227_0;

	private int int_0;

	public Class4872(Class5738 userAgent, string outputFormat, Stream stream)
		: base(userAgent)
	{
		method_0(userAgent, outputFormat, stream);
		interface186_0 = userAgent.method_0().method_17();
		if (interface186_0 == null)
		{
			interface186_0 = new Class5410();
		}
		class5494_0 = new Class5494();
		bool_0 = userAgent.method_51();
	}

	protected void method_0(Class5738 userAgent, string outputFormat, Stream stream)
	{
		class4979_0 = new Class4980(userAgent, outputFormat, class5730_0, stream);
	}

	public Class4979 method_1()
	{
		return class4979_0;
	}

	public Interface186 method_2()
	{
		return interface186_0;
	}

	public Class5494 method_3()
	{
		return class5494_0;
	}

	public override Class5493 vmethod_66()
	{
		return class5493_0;
	}

	public bool method_4()
	{
		return bool_0;
	}

	public override void vmethod_2()
	{
	}

	public override void vmethod_4(Class5170 root)
	{
		CultureInfo cultureInfo = root.method_65();
		if (cultureInfo != null)
		{
			class4979_0.vmethod_4(cultureInfo);
		}
	}

	private void method_5(Interface181 initialPageNumber)
	{
		if (interface227_0 != null)
		{
			interface227_0.imethod_28(initialPageNumber);
			interface227_0.imethod_29();
			interface227_0 = null;
		}
	}

	public override void vmethod_6(Class5127 pageSequence)
	{
		method_6(pageSequence);
	}

	private void method_6(Class5125 pageSequence)
	{
		class5170_0 = pageSequence.vmethod_20();
		if (interface227_0 == null)
		{
			method_7(class5170_0.method_44());
			if (class5170_0.method_59() != null)
			{
				method_7(class5170_0.method_59().method_44());
			}
		}
		method_5(pageSequence.method_52());
		pageSequence.method_48();
	}

	private void method_7(ArrayList list)
	{
		foreach (Interface239 item in list)
		{
			method_9(new Class4978(item));
		}
	}

	public override void vmethod_7(Class5127 pageSequence)
	{
		try
		{
			if (pageSequence.method_56() != null)
			{
				Class5322 @class = method_2().imethod_2(this, pageSequence);
				@class.imethod_27();
				interface227_0 = @class;
			}
		}
		finally
		{
			Class5326.Instance.Dispose();
		}
	}

	public override void vmethod_64(Class5126 document)
	{
		method_6(document);
	}

	public override void vmethod_65(Class5126 document)
	{
		Class5321 @class = method_2().imethod_3(this, document);
		@class.imethod_27();
		interface227_0 = @class;
	}

	public void method_8(Class5125 pageSequence, int pageCount)
	{
		class5493_0.method_3(pageSequence, pageCount);
	}

	public override void vmethod_3()
	{
		method_5(null);
		if (class5170_0 != null)
		{
			ArrayList arrayList = class5170_0.method_63();
			if (arrayList != null)
			{
				while (arrayList.Count > 0)
				{
					Class5093 destination = (Class5093)arrayList[0];
					arrayList.Remove(0);
					Class4939 odi = new Class4939(destination);
					method_9(odi);
				}
			}
			Class5164 @class = class5170_0.method_64();
			if (@class != null)
			{
				Class4938 class2 = new Class4938(@class);
				method_9(class2);
				if (!class2.imethod_2())
				{
					class4979_0.vmethod_2(class2);
				}
			}
			class5494_0.method_2(class5170_0.vmethod_31());
		}
		class4979_0.vmethod_3();
	}

	private void method_9(Interface157 odi)
	{
		if (odi is Interface160)
		{
			Interface160 @interface = (Interface160)odi;
			string[] array = @interface.imethod_3();
			string[] array2 = array;
			foreach (string text in array2)
			{
				ArrayList arrayList = class5494_0.method_6(text);
				if (arrayList != null && arrayList.Count != 0)
				{
					@interface.imethod_4(text, arrayList);
					continue;
				}
				Interface159 interface2 = Class4940.smethod_0(vmethod_0().method_48());
				interface2.imethod_0(this, odi.imethod_1(), text);
				class5494_0.method_9(text, @interface);
			}
			if (@interface.imethod_2())
			{
				class4979_0.vmethod_2(odi);
			}
		}
		else
		{
			class4979_0.vmethod_2(odi);
		}
	}

	public string method_10()
	{
		int_0++;
		return "P" + int_0;
	}

	public void method_11(string id, Class4974 pv)
	{
		class5494_0.method_0(id, pv);
	}

	public void method_12(string id)
	{
		class5494_0.method_1(id);
	}

	public void method_13(string id)
	{
		class5494_0.method_2(id);
	}

	public bool method_14(string id)
	{
		return class5494_0.method_3(id);
	}

	public void method_15(Class4974 pv)
	{
		class5494_0.method_5(pv);
	}

	public ArrayList method_16(string id)
	{
		return class5494_0.method_6(id);
	}

	public void method_17(string idref, Interface160 res)
	{
		class5494_0.method_9(idref, res);
	}
}
