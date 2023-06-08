using System;
using System.Runtime.CompilerServices;
using ns60;

namespace ns63;

internal class Class2684 : Class2639
{
	internal const int int_0 = 11010;

	[CompilerGenerated]
	private static Converter<Class2623, Class2645> converter_0;

	public Class2645[] RgChildRec
	{
		get
		{
			if (base.Records.Count > 0)
			{
				return Array.ConvertAll(base.Records.ToArray(), (Class2623 obj) => (Class2645)obj);
			}
			return null;
		}
	}

	public Class2684()
	{
		base.Header.Type = 11010;
		base.Header.Version = 15;
	}

	[CompilerGenerated]
	private static Class2645 smethod_2(Class2623 obj)
	{
		return (Class2645)obj;
	}
}
