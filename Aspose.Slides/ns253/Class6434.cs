using System.Collections.Generic;

namespace ns253;

internal class Class6434
{
	private List<Interface298> list_0 = new List<Interface298>();

	private Class6445 class6445_0;

	private Class6435 class6435_0;

	private Class6447 class6447_0;

	public List<Interface298> Elements => list_0;

	public Class6435 Properties
	{
		get
		{
			if (class6435_0 == null)
			{
				class6435_0 = new Class6435();
			}
			return class6435_0;
		}
	}

	public Class6445 EndParagraphRunProperties
	{
		get
		{
			if (class6445_0 == null)
			{
				class6445_0 = new Class6445();
			}
			return class6445_0;
		}
	}

	public Class6447 TextBody => class6447_0;

	public void method_0(Interface298 element)
	{
		element.imethod_0(this);
		list_0.Add(element);
	}

	internal void method_1(Class6447 textBody)
	{
		class6447_0 = textBody;
		Properties.method_0(textBody.TextListStyles);
		Properties.DefaultRunProperties.method_4(this, textBody.TextListStyles);
		EndParagraphRunProperties.method_4(this, textBody.TextListStyles);
	}
}
