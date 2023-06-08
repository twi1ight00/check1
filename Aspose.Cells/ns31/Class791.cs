using System.Runtime.CompilerServices;
using ns3;

namespace ns31;

internal class Class791 : Interface11
{
	private object object_0;

	private bool bool_0;

	private string string_0;

	private Class790 class790_0;

	private Class791 class791_0;

	private bool bool_1;

	private bool bool_2;

	internal Class791(Class791 class791_1, object object_1)
	{
		class791_0 = class791_1;
		object_0 = object_1;
		class790_0 = new Class790(this);
		bool_0 = true;
		string_0 = "";
		imethod_6(bool_3: false);
		imethod_8(bool_3: false);
	}

	[SpecialName]
	public object imethod_0()
	{
		return object_0;
	}

	[SpecialName]
	public bool imethod_1()
	{
		return bool_0;
	}

	[SpecialName]
	public void imethod_2(bool bool_3)
	{
		bool_0 = bool_3;
	}

	[SpecialName]
	public string imethod_3()
	{
		return string_0;
	}

	[SpecialName]
	public void imethod_4(string string_1)
	{
		string_0 = string_1;
	}

	[SpecialName]
	public Interface10 imethod_9()
	{
		return class790_0;
	}

	[SpecialName]
	public Interface11 imethod_10()
	{
		return class791_0;
	}

	[SpecialName]
	public bool imethod_5()
	{
		return bool_1;
	}

	[SpecialName]
	public void imethod_6(bool bool_3)
	{
		bool_1 = bool_3;
	}

	[SpecialName]
	public bool imethod_7()
	{
		return bool_2;
	}

	[SpecialName]
	public void imethod_8(bool bool_3)
	{
		bool_2 = bool_3;
	}
}
