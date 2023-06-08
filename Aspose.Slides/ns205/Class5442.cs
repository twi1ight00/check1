using System;
using System.Text;
using ns171;

namespace ns205;

internal class Class5442 : Class5440
{
	private static string[] string_1 = new string[3] { "visible", "hidden", "collapse" };

	private static Enum679[] enum679_0 = new Enum679[3]
	{
		Enum679.const_246,
		Enum679.const_58,
		Enum679.const_27
	};

	public int int_1;

	public Class5442(int visibility)
		: base(smethod_0(visibility), visibility)
	{
		int_1 = visibility;
	}

	public override int GetHashCode()
	{
		return ToString().GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (obj == this)
		{
			return true;
		}
		if (obj is Class5442)
		{
			Class5442 @class = (Class5442)obj;
			return int_1 == @class.int_1;
		}
		return false;
	}

	public static string smethod_0(int enumValue)
	{
		int num = 0;
		while (true)
		{
			if (num < enum679_0.Length)
			{
				if (enum679_0[num] == (Enum679)enumValue)
				{
					break;
				}
				num++;
				continue;
			}
			throw new ArgumentException("Illegal visibility: " + enumValue);
		}
		return string_1[num];
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append('(');
		stringBuilder.Append(method_0());
		stringBuilder.Append(')');
		return stringBuilder.ToString();
	}
}
