using ns174;
using ns177;
using ns178;

namespace ns179;

internal abstract class Class5349 : Interface155
{
	private string string_0;

	private Interface244 interface244_0;

	public void method_0(string id)
	{
		string_0 = id;
	}

	public string method_1()
	{
		return string_0;
	}

	public void method_2(Interface244 structureTreeElement)
	{
		interface244_0 = structureTreeElement;
	}

	public Interface244 method_3()
	{
		return interface244_0;
	}

	public bool method_4()
	{
		return string_0 != null;
	}

	public abstract bool vmethod_0(Class5349 other);

	public bool method_5()
	{
		return true;
	}

	public virtual string vmethod_1()
	{
		return null;
	}

	public abstract void imethod_0(Interface153 ch);
}
