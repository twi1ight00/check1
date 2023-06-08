using System;
using System.IO;
using System.Runtime.CompilerServices;
using ns60;
using ns63;

namespace ns62;

internal class Class2640 : Class2639
{
	internal const int int_0 = 61441;

	[CompilerGenerated]
	private static Converter<Class2623, Class2628> converter_0;

	public Class2628[] Rgfb
	{
		get
		{
			if (base.Records.Count > 0)
			{
				return Array.ConvertAll(base.Records.ToArray(), (Class2623 obj) => (Class2628)obj);
			}
			return null;
		}
	}

	public Class2640()
		: base(61441)
	{
	}

	public override void vmethod_1(BinaryWriter writer)
	{
		base.Header.Instance = (short)base.Records.Count;
		base.vmethod_1(writer);
	}

	[CompilerGenerated]
	private static Class2628 smethod_2(Class2623 obj)
	{
		return (Class2628)obj;
	}
}
