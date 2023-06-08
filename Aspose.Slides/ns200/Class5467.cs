using System.Collections;
using System.Text;
using ns175;

namespace ns200;

internal class Class5467
{
	internal class Class5468
	{
		protected Class5467 class5467_0;

		public Class5468(Class5467 context)
		{
			class5467_0 = context;
		}

		public Class5738 method_0()
		{
			return class5467_0.method_3();
		}

		public int method_1()
		{
			return (int)class5467_0.method_5("xpos");
		}

		public int method_2()
		{
			return (int)class5467_0.method_5("ypos");
		}

		public int method_3()
		{
			return (int)class5467_0.method_5("width");
		}

		public int method_4()
		{
			return (int)class5467_0.method_5("height");
		}

		public Hashtable method_5()
		{
			return (Hashtable)class5467_0.method_5("foreign-attributes");
		}

		public override string ToString()
		{
			return string.Concat("RendererContextWrapper{userAgent=", method_0(), "x=", method_1(), "y=", method_2(), "width=", method_3(), "height=", method_4(), "foreignAttributes=", method_5(), "}");
		}
	}

	private string string_0;

	private Class5359 class5359_0;

	private Class5738 class5738_0;

	private Hashtable hashtable_0 = new Hashtable();

	public Class5467(Class5359 renderer, string mime)
	{
		class5359_0 = renderer;
		string_0 = mime;
	}

	public Class5359 method_0()
	{
		return class5359_0;
	}

	public string method_1()
	{
		return string_0;
	}

	public void method_2(Class5738 ua)
	{
		class5738_0 = ua;
	}

	public Class5738 method_3()
	{
		return class5738_0;
	}

	public void method_4(string name, object val)
	{
		hashtable_0.Add(name, val);
	}

	public object method_5(string prop)
	{
		return hashtable_0[prop];
	}

	public static Class5468 smethod_0(Class5467 context)
	{
		return new Class5468(context);
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder("RendererContext{\n");
		foreach (string key in hashtable_0.Keys)
		{
			object obj = hashtable_0[key];
			stringBuilder.Append(string.Concat("\t", key, "=", obj, "\n"));
		}
		stringBuilder.Append("}");
		return stringBuilder.ToString();
	}
}
