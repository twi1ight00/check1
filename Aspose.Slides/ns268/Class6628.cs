using System;
using ns267;

namespace ns268;

internal class Class6628<T> : Class6625 where T : struct
{
	private readonly Type type_0 = typeof(T);

	protected override Enum vmethod_0(string value)
	{
		return (Enum)Enum.Parse(type_0, value, ignoreCase: true);
	}

	protected override string vmethod_1(Enum value)
	{
		return value.ToString();
	}
}
