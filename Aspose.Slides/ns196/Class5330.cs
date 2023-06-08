using System.Text;
using ns205;

namespace ns196;

internal abstract class Class5330 : Class5329
{
	private Class5746 class5746_0;

	private bool bool_0;

	private Class5695 class5695_0;

	private bool bool_1;

	private bool bool_2;

	public Class5330(Class5254 position, Class5746 length, Class5695 side, bool conditional, bool isFirst, bool isLast)
		: base(position)
	{
		class5746_0 = length;
		class5695_0 = side;
		bool_0 = conditional;
		bool_1 = isFirst;
		bool_2 = isLast;
	}

	public override bool vmethod_5()
	{
		return bool_0;
	}

	public Class5746 method_4()
	{
		return class5746_0;
	}

	public void method_5(Class5746 value)
	{
		class5746_0 = value;
	}

	public Class5695 method_6()
	{
		return class5695_0;
	}

	public bool method_7()
	{
		return bool_1;
	}

	public bool method_8()
	{
		return bool_2;
	}

	public abstract void vmethod_6(Class5746 effectiveLength);

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(method_6().method_0()).Append(", ");
		stringBuilder.Append(class5746_0.ToString());
		if (vmethod_5())
		{
			stringBuilder.Append("[discard]");
		}
		else
		{
			stringBuilder.Append("[RETAIN]");
		}
		if (method_7())
		{
			stringBuilder.Append("[first]");
		}
		if (method_8())
		{
			stringBuilder.Append("[last]");
		}
		return stringBuilder.ToString();
	}
}
