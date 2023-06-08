using System.Collections.Generic;

namespace ns253;

internal class Class6447
{
	private List<Class6434> list_0;

	private Class6448 class6448_0;

	private Class6450 class6450_0;

	public Class6450 TextListStyles
	{
		get
		{
			if (class6450_0 == null)
			{
				class6450_0 = new Class6450();
			}
			return class6450_0;
		}
	}

	public Class6448 Properties
	{
		get
		{
			if (class6448_0 == null)
			{
				class6448_0 = new Class6448();
			}
			return class6448_0;
		}
	}

	public List<Class6434> Paragraphs
	{
		get
		{
			if (list_0 == null)
			{
				list_0 = new List<Class6434>();
			}
			return list_0;
		}
	}

	public void method_0(Class6434 paragraph)
	{
		paragraph.method_1(this);
		Paragraphs.Add(paragraph);
	}
}
