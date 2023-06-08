using System;
using System.IO;

namespace ns71;

internal class Class3513 : Class3473
{
	private readonly int int_0;

	private Class3507 class3507_0;

	private Class3473 class3473_0;

	public Class3507 ReferenceName
	{
		get
		{
			return class3507_0;
		}
		set
		{
			class3507_0 = value;
		}
	}

	public Class3473 ReferenceRecord
	{
		get
		{
			return class3473_0;
		}
		set
		{
			class3473_0 = value;
		}
	}

	internal Class3513(int codePage)
	{
		int_0 = codePage;
	}

	internal override void vmethod_0(BinaryReader reader)
	{
		if (Class3522.smethod_0(reader) == 22)
		{
			class3507_0 = new Class3507(int_0);
			class3507_0.vmethod_0(reader);
		}
		switch (Class3522.smethod_0(reader))
		{
		default:
			throw new InvalidOperationException();
		case 47:
		case 51:
			class3473_0 = new Class3514(int_0);
			break;
		case 13:
			class3473_0 = new Class3510(int_0);
			break;
		case 14:
			class3473_0 = new Class3509();
			break;
		}
		class3473_0.vmethod_0(reader);
	}

	internal override void vmethod_1(BinaryWriter writer)
	{
		if (class3507_0 != null)
		{
			class3507_0.vmethod_1(writer);
		}
		class3473_0.vmethod_1(writer);
	}
}
