using System.Collections;
using System.Drawing;

namespace ns183;

internal class Class5741
{
	public static object object_0 = typeof(Image);

	public static object object_1 = "HAS_MORE_IMAGES";

	private string string_0;

	private string string_1;

	private Class5393 class5393_0;

	private Hashtable hashtable_0 = new Hashtable();

	public Class5741(string originalURI, string mimeType)
	{
		string_0 = originalURI;
		string_1 = mimeType;
	}

	public string method_0()
	{
		return string_0;
	}

	public string method_1()
	{
		return string_1;
	}

	public Class5393 method_2()
	{
		return class5393_0;
	}

	public void method_3(Class5393 sizE)
	{
		class5393_0 = sizE;
	}

	public Hashtable method_4()
	{
		return hashtable_0;
	}

	public Image method_5()
	{
		return (Image)hashtable_0[object_0];
	}

	public override string ToString()
	{
		return method_0() + " (" + method_1() + ")";
	}
}
