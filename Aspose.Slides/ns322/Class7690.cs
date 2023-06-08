using System.Collections;

namespace ns322;

internal class Class7690 : IEnumerable, Interface397
{
	private Interface397 interface397_0;

	private Class7352 class7352_0;

	public int Count => interface397_0.Count;

	public IEnumerable Values => interface397_0.Values;

	public Class7690()
	{
		interface397_0 = new Class7677();
	}

	public Class7352 imethod_0(string name, Class7352 descriptor)
	{
		interface397_0.imethod_0(name, descriptor);
		return class7352_0 = descriptor;
	}

	public void imethod_1(string name)
	{
		interface397_0.imethod_1(name);
		if (class7352_0 != null && class7352_0.Name == name)
		{
			class7352_0 = null;
		}
	}

	public Class7352 imethod_2(string name)
	{
		if (class7352_0 != null && class7352_0.Name == name)
		{
			return class7352_0;
		}
		Class7352 @class = interface397_0.imethod_2(name);
		if (@class != null)
		{
			class7352_0 = @class;
		}
		return @class;
	}

	public bool imethod_3(string name, out Class7352 descriptor)
	{
		if (class7352_0 != null && class7352_0.Name == name)
		{
			descriptor = class7352_0;
			return true;
		}
		bool result;
		if (result = interface397_0.imethod_3(name, out descriptor))
		{
			class7352_0 = descriptor;
		}
		return result;
	}

	public IEnumerator GetEnumerator()
	{
		return interface397_0.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}
