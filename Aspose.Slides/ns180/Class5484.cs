using System.Collections;

namespace ns180;

internal class Class5484 : Interface156
{
	private ArrayList arrayList_0 = new ArrayList();

	public void method_0(Interface156 listener)
	{
		arrayList_0.Add(listener);
	}

	public void method_1(Interface156 listener)
	{
		arrayList_0.Remove(listener);
	}

	private int method_2()
	{
		return arrayList_0.Count;
	}

	public bool method_3()
	{
		return method_2() > 0;
	}

	public void imethod_0(Class5596 @event)
	{
		int i = 0;
		for (int num = method_2(); i < num; i++)
		{
			Interface156 @interface = (Interface156)arrayList_0[i];
			@interface.imethod_0(@event);
		}
	}
}
