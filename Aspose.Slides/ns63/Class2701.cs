using System;
using System.Runtime.CompilerServices;
using ns60;

namespace ns63;

internal class Class2701 : Class2639
{
	public const int int_0 = 2040;

	private static readonly int[] int_1 = new int[2] { 2041, 2147483647 };

	[CompilerGenerated]
	private static Converter<Class2623, Class2876> converter_0;

	public Class2876[] RgBlipEntityAtom
	{
		get
		{
			if (base.Records.Count > 0)
			{
				return Array.ConvertAll(base.Records.ToArray(), (Class2623 obj) => (Class2876)obj);
			}
			return null;
		}
	}

	public Class2701()
	{
		base.Header.Type = 2040;
	}

	protected override int[] vmethod_6()
	{
		return int_1;
	}

	[CompilerGenerated]
	private static Class2876 smethod_2(Class2623 obj)
	{
		return (Class2876)obj;
	}
}
