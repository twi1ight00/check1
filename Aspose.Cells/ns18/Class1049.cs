using System;
using System.Runtime.CompilerServices;
using System.Text;
using ns22;

namespace ns18;

internal abstract class Class1049
{
	private readonly Class1054 class1054_0 = new Class1054("/");

	protected Class1052 class1052_0;

	protected Class1030 class1030_0;

	[SpecialName]
	public Class1052 method_0()
	{
		return class1052_0;
	}

	[SpecialName]
	public void method_1(Class1052 class1052_1)
	{
		class1052_0 = class1052_1;
	}

	[SpecialName]
	public Class1054 method_2()
	{
		return class1054_0;
	}

	public static string smethod_0(string string_0, string string_1)
	{
		if (!string_1.StartsWith("/"))
		{
			return string_1;
		}
		int num = 0;
		int num2 = Math.Min(string_0.Length, string_1.Length);
		for (int i = 0; i < num2; i++)
		{
			if (string_0[i] == '/')
			{
				num = i;
			}
			if (string_0[i] != string_1[i])
			{
				break;
			}
		}
		int num3 = num + 1;
		StringBuilder stringBuilder = new StringBuilder();
		for (int j = num3; j < string_0.Length; j++)
		{
			if (string_0[j] == '/')
			{
				stringBuilder.Append("../");
			}
		}
		stringBuilder.Append(string_1, num3, string_1.Length - num3);
		return stringBuilder.ToString();
	}
}
