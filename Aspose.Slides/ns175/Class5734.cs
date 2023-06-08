using System;
using System.Collections;
using System.IO;
using ns171;
using ns183;
using ns184;
using ns196;
using ns200;

namespace ns175;

internal class Class5734 : IDisposable, Interface152
{
	private class Class5459 : Class5458
	{
		public override void vmethod_0(string fontBase)
		{
			throw new NotImplementedException();
		}
	}

	private Class5751 class5751_0;

	private Class5446 class5446_0;

	private Class5439 class5439_0;

	private Class5599 class5599_0;

	private Class5253 class5253_0;

	private Class5458 class5458_0;

	private string string_0;

	private bool bool_0;

	private string string_1;

	private Hashtable hashtable_0;

	private bool bool_1 = true;

	private bool bool_2 = true;

	private float float_0 = 96f;

	private float float_1 = 96f;

	private string string_2 = "11in";

	private string string_3 = "8.26in";

	private bool bool_3 = true;

	private bool bool_4;

	private Interface186 interface186_0;

	private Class4924 class4924_0;

	protected Class5734()
	{
		class5599_0 = new Class5599(this);
		class4924_0 = new Class4924(method_48());
		class5458_0 = new Class5459();
		class5253_0 = new Class5253(this);
		class5751_0 = new Class5751();
		class5446_0 = new Class5446();
		class5439_0 = new Class5439();
	}

	public static Class5734 smethod_0()
	{
		return new Class5734();
	}

	public Class5738 method_0()
	{
		return new Class5738(this);
	}

	private void method_1(bool value)
	{
		bool_0 = value;
	}

	internal bool method_2()
	{
		return bool_0;
	}

	internal void method_3(bool value)
	{
		bool_3 = value;
	}

	internal bool method_4()
	{
		return bool_3;
	}

	public Class4923 method_5(string outputFormat)
	{
		return method_6(outputFormat, method_0());
	}

	public Class4923 method_6(string outputFormat, Class5738 userAgent)
	{
		return method_8(outputFormat, userAgent, null);
	}

	public Class4923 method_7(string outputFormat, Stream stream)
	{
		return method_8(outputFormat, method_0(), stream);
	}

	public Class4923 method_8(string outputFormat, Class5738 userAgent, Stream stream)
	{
		if (userAgent == null)
		{
			throw new NullReferenceException("The userAgent parameter must not be null!");
		}
		return new Class4923(outputFormat, userAgent, stream);
	}

	public Class4923 method_9(Class5738 userAgent)
	{
		if (userAgent.method_4() == null && userAgent.method_6() == null && userAgent.method_2() == null)
		{
			throw new InvalidOperationException("An overriding renderer, FOEventHandler or IFDocumentHandler must be set on the user agent when this factory method is used!");
		}
		return method_6(null, userAgent);
	}

	public Class5751 method_10()
	{
		return class5751_0;
	}

	public Class5446 method_11()
	{
		return class5446_0;
	}

	public Class5439 method_12()
	{
		return class5439_0;
	}

	public Class5599 method_13()
	{
		return class5599_0;
	}

	public Class5253 method_14()
	{
		return class5253_0;
	}

	public void method_15(Class5180 elementMapping)
	{
		class5599_0.method_1(elementMapping);
	}

	public void method_16(Interface186 lmMaker)
	{
		interface186_0 = lmMaker;
	}

	public Interface186 method_17()
	{
		return interface186_0;
	}

	public void method_18(string @base)
	{
	}

	public string method_19()
	{
		return string_0;
	}

	public void method_20(Interface171 callback)
	{
		class4924_0.imethod_0(callback);
	}

	public void method_21(string fontBase)
	{
		method_51().vmethod_0(fontBase);
	}

	public string method_22()
	{
		return method_51().method_0();
	}

	public string method_23()
	{
		return string_1;
	}

	public void method_24(string hyphenBase)
	{
		throw new NotImplementedException();
	}

	public Hashtable method_25()
	{
		return hashtable_0;
	}

	public void method_26(Hashtable hyphPatNames)
	{
		if (hyphPatNames == null)
		{
			hyphPatNames = new Hashtable();
		}
		hashtable_0 = hyphPatNames;
	}

	public Interface151 method_27()
	{
		return class4924_0;
	}

	public Class4924 method_28()
	{
		return class4924_0;
	}

	public void method_29(bool validateStrictly)
	{
		bool_1 = validateStrictly;
	}

	public bool method_30()
	{
		return bool_1;
	}

	public bool method_31()
	{
		return bool_4;
	}

	public void method_32(bool value)
	{
		bool_4 = value;
	}

	public bool method_33()
	{
		return method_51().method_1();
	}

	public void method_34(bool value)
	{
		method_51().method_2(value);
	}

	public float imethod_0()
	{
		return float_0;
	}

	public float method_35()
	{
		return 25.4f / imethod_0();
	}

	public void method_36(float dpi)
	{
		float_0 = dpi;
	}

	public float method_37()
	{
		return float_1;
	}

	public float method_38()
	{
		return 25.4f / float_1;
	}

	public void method_39(float dpi)
	{
		float_1 = dpi;
	}

	public void method_40(int dpi)
	{
		method_36(dpi);
	}

	public string method_41()
	{
		return string_2;
	}

	public void method_42(string pageHeight)
	{
		string_2 = pageHeight;
	}

	public string method_43()
	{
		return string_3;
	}

	public void method_44(string pageWidth)
	{
		string_3 = pageWidth;
	}

	public void method_45(string namespaceURI)
	{
	}

	public bool method_46(string namespaceURI)
	{
		return false;
	}

	public Interface201 method_47()
	{
		return null;
	}

	public bool method_48()
	{
		return bool_2;
	}

	public void method_49(bool useCache)
	{
		method_51().method_7(useCache);
	}

	public bool method_50()
	{
		return method_51().method_8();
	}

	public Class5458 method_51()
	{
		return class5458_0;
	}

	public Stream method_52(string href, string baseUri, string srcDir)
	{
		Stream result = null;
		try
		{
			result = class4924_0.imethod_1(href, baseUri, srcDir);
		}
		catch (Exception)
		{
			Console.Out.WriteLine("Attempt to resolve URI '" + href + "' failed: ");
		}
		return result;
	}

	public void Dispose()
	{
		if (class5253_0 != null)
		{
			class5253_0.Dispose();
			class5253_0 = null;
		}
	}
}
