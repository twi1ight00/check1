using System.Collections;
using ns36;

namespace ns37;

internal class Class742 : CollectionBase, Interface7
{
	private Class743 class743_0;

	public Interface8 this[int i] => (Interface8)base.InnerList[i];

	internal Class742(Class743 parent)
	{
		class743_0 = parent;
	}

	internal Class743 method_0(int i)
	{
		return (Class743)base.InnerList[i];
	}

	public Interface8 imethod_0(object labelValue)
	{
		Class743 @class = new Class743(class743_0, labelValue);
		base.InnerList.Add(@class);
		return @class;
	}

	public void imethod_1(params object[] labels)
	{
		for (int i = 0; i < labels.Length; i++)
		{
			imethod_0(labels[i]);
		}
	}
}
