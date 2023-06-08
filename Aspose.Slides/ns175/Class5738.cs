using System;
using System.Collections;
using System.IO;
using ns171;
using ns174;
using ns180;
using ns183;
using ns200;
using ns207;

namespace ns175;

internal class Class5738
{
	private class Class5739 : Interface170
	{
		private Class5738 class5738_0;

		internal Class5739(Class5738 owner)
		{
			class5738_0 = owner;
		}

		public Interface152 imethod_0()
		{
			return class5738_0.method_0();
		}

		public float imethod_1()
		{
			return class5738_0.method_32();
		}

		public Stream imethod_2(string uri)
		{
			return class5738_0.method_27(uri);
		}
	}

	private class Class5489 : Class5488
	{
		private class Class5740 : Interface156
		{
			private Class5489 class5489_0;

			internal Class5740(Class5489 owner)
			{
				class5489_0 = owner;
			}

			public void imethod_0(Class5596 @event)
			{
				class5489_0.interface156_0 = new Class4936(class5489_0.class5484_0, class5489_0.class5738_0);
				class5489_0.interface156_0.imethod_0(@event);
			}
		}

		private Interface156 interface156_0;

		private Class5738 class5738_0;

		public Class5489(Class5738 owner)
		{
			interface156_0 = new Class5740(this);
			class5738_0 = owner;
		}

		public override void imethod_3(Class5596 @event)
		{
			interface156_0.imethod_0(@event);
		}
	}

	public static float float_0 = 72f;

	private Class5734 class5734_0;

	private bool bool_0;

	private string string_0;

	private Interface151 interface151_0;

	private float float_1 = 72f;

	private Hashtable hashtable_0 = new Hashtable();

	private Stream stream_0;

	private Interface196 interface196_0;

	private Interface177 interface177_0;

	private Class4866 class4866_0;

	private bool bool_1 = true;

	private bool bool_2;

	private Interface207 interface207_0;

	private Interface204 interface204_0;

	private string string_1;

	private bool bool_3;

	protected string string_2 = "Aspose";

	protected string string_3;

	protected DateTime dateTime_0 = DateTime.Now;

	protected string string_4;

	protected string string_5;

	protected string string_6;

	protected string string_7;

	internal object object_0;

	private bool bool_4;

	internal Hashtable hashtable_1;

	private string string_8;

	private Class5739 class5739_0;

	public bool UseHelvetica
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	public bool ForceAlignBreak
	{
		get
		{
			return bool_3;
		}
		set
		{
			bool_3 = value;
		}
	}

	public bool SplitPages
	{
		get
		{
			return bool_4;
		}
		set
		{
			bool_4 = value;
		}
	}

	public string SrcDir
	{
		get
		{
			return string_8;
		}
		set
		{
			string_8 = value;
		}
	}

	public string DefaultFontName
	{
		get
		{
			return string_1;
		}
		set
		{
			string_1 = value;
		}
	}

	public Class5738(Class5734 factory)
	{
		interface207_0 = new Class5489(this);
		class5739_0 = new Class5739(this);
		if (factory == null)
		{
			throw new NullReferenceException("The factory parameter must not be null");
		}
		class5734_0 = factory;
		method_22(factory.method_19());
		method_33(factory.method_37());
		method_53(factory.method_2());
	}

	public Class5734 method_0()
	{
		return class5734_0;
	}

	public void method_1(Interface196 documentHandler)
	{
		if (method_54())
		{
			method_55(documentHandler.imethod_6());
		}
		interface196_0 = documentHandler;
	}

	public Interface196 method_2()
	{
		return interface196_0;
	}

	public void method_3(Interface177 renderer)
	{
		interface177_0 = renderer;
	}

	public Interface177 method_4()
	{
		return interface177_0;
	}

	public void method_5(Class4866 handler)
	{
		class4866_0 = handler;
	}

	public Class4866 method_6()
	{
		return class4866_0;
	}

	public void method_7(string producer)
	{
		string_2 = producer;
	}

	public string method_8()
	{
		return string_2;
	}

	public void method_9(string creator)
	{
		string_3 = creator;
	}

	public string method_10()
	{
		return string_3;
	}

	public void method_11(DateTime creationDate)
	{
		dateTime_0 = creationDate;
	}

	public DateTime method_12()
	{
		return dateTime_0;
	}

	public void method_13(string author)
	{
		string_4 = author;
	}

	public string method_14()
	{
		return string_4;
	}

	public void method_15(string title)
	{
		string_5 = title;
	}

	public string method_16()
	{
		return string_5;
	}

	public void method_17(string subject)
	{
		string_6 = subject;
	}

	public string method_18()
	{
		return string_6;
	}

	public void method_19(string keywords)
	{
		string_7 = keywords;
	}

	public string method_20()
	{
		return string_7;
	}

	public Hashtable method_21()
	{
		return hashtable_0;
	}

	public void method_22(string baseUrl)
	{
		string_0 = baseUrl;
	}

	public void method_23(string fontBaseUrl)
	{
		method_0().method_51().vmethod_0(fontBaseUrl);
	}

	public string method_24()
	{
		return string_0;
	}

	public void method_25(Interface151 resolver)
	{
		interface151_0 = resolver;
	}

	public Interface151 method_26()
	{
		return interface151_0;
	}

	public Stream method_27(string uri)
	{
		return method_28(uri, method_24());
	}

	public Stream method_28(string href, string @base)
	{
		Stream stream = null;
		if (!href.StartsWith("data:") && interface151_0 != null)
		{
			try
			{
				stream = interface151_0.imethod_1(href, @base, null);
			}
			catch (Exception)
			{
				throw;
			}
		}
		if (stream == null)
		{
			stream = method_0().method_52(href, @base, string_8);
		}
		return stream;
	}

	public void method_29(Stream f)
	{
		stream_0 = f;
	}

	public Stream method_30()
	{
		return stream_0;
	}

	public float method_31()
	{
		return 25.4f / float_1;
	}

	public float method_32()
	{
		return float_1;
	}

	public void method_33(float dpi)
	{
		method_0().method_36(dpi);
		float_1 = dpi;
	}

	public void method_34(int dpi)
	{
		method_33(dpi);
	}

	public Interface170 method_35()
	{
		return class5739_0;
	}

	public string method_36()
	{
		string text = method_0().method_51().method_0();
		if (text == null)
		{
			return method_24();
		}
		return text;
	}

	public float method_37()
	{
		return method_0().method_35();
	}

	public float method_38()
	{
		return method_0().imethod_0();
	}

	public void method_39(float dpi)
	{
		method_0().method_36(dpi);
	}

	public string method_40()
	{
		return method_0().method_41();
	}

	public string method_41()
	{
		return method_0().method_43();
	}

	public bool method_42()
	{
		return method_0().method_30();
	}

	public bool method_43()
	{
		return method_0().method_31();
	}

	public Class5751 method_44()
	{
		return method_0().method_10();
	}

	public Class5446 method_45()
	{
		return method_0().method_11();
	}

	public void method_46(bool enableLocator)
	{
		bool_1 = enableLocator;
	}

	public bool method_47()
	{
		return bool_1;
	}

	public Interface207 method_48()
	{
		return interface207_0;
	}

	public bool method_49()
	{
		return bool_2;
	}

	public void method_50(bool conserveMemoryPolicy)
	{
		bool_2 = conserveMemoryPolicy;
	}

	public bool method_51()
	{
		return class5734_0.method_4();
	}

	public void method_52(bool useComplexScriptFeatures)
	{
		class5734_0.method_3(useComplexScriptFeatures);
	}

	public void method_53(bool accessibility)
	{
		if (accessibility)
		{
			method_21().Add(Class4922.string_0, true);
		}
	}

	public bool method_54()
	{
		object obj = method_21()[Class4922.string_0];
		if (obj != null)
		{
			return (bool)obj;
		}
		return false;
	}

	public void method_55(Interface204 structureTreeEventHandler)
	{
		interface204_0 = structureTreeEventHandler;
	}

	public Interface204 method_56()
	{
		return interface204_0;
	}
}
