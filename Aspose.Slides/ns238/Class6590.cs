using System.Collections.Generic;
using ns218;

namespace ns238;

internal class Class6590
{
	private List<Class6590> list_0;

	private int int_0;

	private string string_0;

	private string string_1;

	private Class6590 class6590_0;

	public int Level => int_0;

	public string Title => string_0;

	public string NavigationUrl => string_1;

	public Class6590 Parent
	{
		get
		{
			return class6590_0;
		}
		set
		{
			class6590_0 = value;
		}
	}

	public Class6590(int level, string title, string navigationUrl)
	{
		int_0 = level;
		string_0 = title;
		string_1 = navigationUrl;
		list_0 = new List<Class6590>();
	}

	public void method_0(Class6590 item)
	{
		item.Parent = this;
		list_0.Add(item);
	}

	public void method_1(Class5946 builder)
	{
		for (int i = 0; i < list_0.Count; i++)
		{
			Class6590 @class = list_0[i];
			@class.method_2(builder);
		}
	}

	private void method_2(Class5946 builder)
	{
		builder.method_2("outline");
		builder.method_14("title", string_0);
		builder.method_14("url", string_1);
		method_1(builder);
		builder.method_3();
	}
}
