using System.Collections.Generic;
using System.IO;
using ns220;
using ns221;
using ns235;

namespace ns241;

internal class Class6691
{
	private int int_0 = 1;

	private readonly Class5947 class5947_0;

	private Class6694 class6694_0;

	private readonly Class6689 class6689_0;

	private readonly List<string> list_0 = new List<string>();

	public Class6694 PageWriter => class6694_0;

	public Class5956 Info => class6689_0.Info;

	public Class6691(Stream outputStream, string resourcesFolderPath, string resourcesFolderAlias)
	{
		class5947_0 = new Class5947(outputStream, isPrettyFormat: true);
		class6689_0 = new Class6689(resourcesFolderPath, resourcesFolderAlias);
		method_4();
	}

	public void method_0()
	{
		class5947_0.method_1();
		class6689_0.vmethod_1();
	}

	public void method_1(float width, float height)
	{
		class5947_0.method_2("PageContent");
		class6694_0 = new Class6694(class6689_0, class5947_0, isXps: false);
		class6694_0.method_0(int_0, width, height);
	}

	public void method_2()
	{
		class6694_0.method_1();
		class5947_0.method_3();
		int_0++;
	}

	public void method_3(Class6211 bookmark)
	{
		if (!list_0.Contains(bookmark.Name))
		{
			class6694_0.method_8(class6689_0.method_0(bookmark.Name), bookmark.Origin);
			list_0.Add(bookmark.Name);
		}
	}

	private void method_4()
	{
		class5947_0.method_0("FixedDocument");
		class5947_0.method_14("xmlns", "http://schemas.microsoft.com/winfx/2006/xaml/presentation");
	}
}
