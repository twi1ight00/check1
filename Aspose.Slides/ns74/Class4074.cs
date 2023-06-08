using System.Text;
using ns73;
using ns76;

namespace ns74;

internal sealed class Class4074
{
	private const short short_0 = 1;

	private const short short_1 = 2;

	private const short short_2 = 4;

	private Class3679[] class3679_0;

	private short[] short_3;

	private Class3726 class3726_0;

	internal Class4074(Class3726 engine)
	{
		class3726_0 = engine;
		int num = engine.method_3() + 1;
		class3679_0 = new Class3679[num];
		short_3 = new short[num];
	}

	public Class3679 method_0(int i)
	{
		return class3679_0[i];
	}

	public void method_1(int i, Class3679 value)
	{
		class3679_0[i] = value;
	}

	public bool method_2(int i)
	{
		return (short_3[i] & 1) != 0;
	}

	public void method_3(int i, bool value)
	{
		if (value)
		{
			short_3[i] |= 1;
		}
		else
		{
			short_3[i] &= -2;
		}
	}

	public bool method_4(int i)
	{
		return (short_3[i] & 2) != 0;
	}

	public void method_5(int i, bool value)
	{
		if (value)
		{
			short_3[i] |= 2;
		}
		else
		{
			short_3[i] &= -3;
		}
	}

	public bool method_6(int i)
	{
		return (short_3[i] & 4) != 0;
	}

	public void method_7(int i, bool value)
	{
		if (value)
		{
			short_3[i] |= 4;
		}
		else
		{
			short_3[i] &= -5;
		}
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < class3679_0.Length; i++)
		{
			Class3679 @class = class3679_0[i];
			if (@class != null)
			{
				stringBuilder.Append(class3726_0.GetPropertyName(i));
				stringBuilder.Append(": ");
				stringBuilder.Append(@class);
				if (method_2(i))
				{
					stringBuilder.Append(" !important");
				}
				stringBuilder.Append(";\n");
			}
		}
		return stringBuilder.ToString();
	}
}
