using System.Collections;

namespace ns196;

internal class Class5275 : Class5274
{
	private bool bool_0;

	public Class5275()
	{
	}

	public Class5275(ArrayList list)
		: base(list)
	{
	}

	public override bool vmethod_5()
	{
		return false;
	}

	public override bool vmethod_2(Class5274 sequence)
	{
		if (!sequence.vmethod_5())
		{
			return !bool_0;
		}
		return false;
	}

	public override bool vmethod_4(Class5274 sequence)
	{
		return false;
	}

	public override bool vmethod_3(Class5274 sequence, bool keepTogether, Class5336 breakElement)
	{
		if (!vmethod_2(sequence))
		{
			return false;
		}
		if (keepTogether)
		{
			breakElement.method_6(Class5337.int_0);
			Add(breakElement);
		}
		else if (!method_3().vmethod_1())
		{
			breakElement.method_6(0);
			Add(breakElement);
		}
		foreach (object item in sequence)
		{
			Add(item);
		}
		return true;
	}

	public override Class5274 vmethod_1()
	{
		bool_0 = true;
		return this;
	}
}
