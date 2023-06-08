using System.Collections;
using Aspose.Slides.Export;
using ns276;
using ns43;

namespace ns42;

internal class Class1087
{
	internal enum Enum170
	{
		const_0,
		const_1,
		const_2
	}

	internal Hashtable hashtable_0;

	internal Hashtable hashtable_1;

	internal bool bool_0;

	internal Enum170 enum170_0;

	internal PptxOptions pptxOptions_0;

	internal int int_0 = 1038;

	private readonly Class6752 class6752_0;

	internal Class6752 ZipFile => class6752_0;

	public Class1087(Class6752 zipFile, PptxOptions options)
	{
		class6752_0 = zipFile;
		hashtable_0 = new Hashtable();
		hashtable_1 = new Hashtable();
		pptxOptions_0 = ((options != null) ? options.Clone() : new PptxOptions());
	}

	public void method_0(string name, bool save)
	{
		hashtable_0[name] = save;
	}

	public void method_1(string name, string newName)
	{
		hashtable_0[name] = newName;
		hashtable_0[Class834.smethod_4(name)] = Class834.smethod_4(newName);
	}

	public bool method_2(string name)
	{
		object obj = hashtable_0[name];
		if (obj == null)
		{
			return true;
		}
		if (obj is bool)
		{
			return (bool)obj;
		}
		return true;
	}

	public string method_3(string name)
	{
		object obj = hashtable_0[name];
		if (obj == null)
		{
			return name;
		}
		if (obj is bool)
		{
			if (!(bool)obj)
			{
				return null;
			}
			return name;
		}
		return (string)obj;
	}
}
