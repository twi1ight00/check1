using System;
using System.IO;
using ns60;

namespace ns63;

internal class Class2772 : Class2623
{
	internal const int int_0 = 14101;

	private Class2939 class2939_0 = new Class2939();

	private Class2939 class2939_1 = new Class2939();

	public DateTime DateTimeModified
	{
		get
		{
			return class2939_0.DateTime;
		}
		set
		{
			class2939_0.DateTime = value;
		}
	}

	public DateTime DateTimeInserted
	{
		get
		{
			return class2939_1.DateTime;
		}
		set
		{
			class2939_1.DateTime = value;
		}
	}

	public Class2772()
	{
		base.Header.Type = 14101;
	}

	protected override void vmethod_0(BinaryReader reader)
	{
		class2939_0.method_0(reader);
		class2939_1.method_0(reader);
	}

	public override void vmethod_1(BinaryWriter writer)
	{
		class2939_0.method_1(writer);
		class2939_1.method_1(writer);
	}

	public override int vmethod_2()
	{
		return 32;
	}
}
