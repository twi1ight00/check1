using System;
using System.Runtime.CompilerServices;
using ns60;
using ns63;

namespace ns62;

internal class Class2668 : Class2639
{
	public const int int_0 = 61445;

	[CompilerGenerated]
	private static Converter<Class2623, Class2624> converter_0;

	public Class2624[] Rgfb
	{
		get
		{
			if (base.Records.Count > 0)
			{
				return Array.ConvertAll(base.Records.ToArray(), (Class2623 obj) => (Class2624)obj);
			}
			return null;
		}
	}

	internal Class2668()
		: base(61445)
	{
	}

	[CompilerGenerated]
	private static Class2624 smethod_2(Class2623 obj)
	{
		return (Class2624)obj;
	}
}
