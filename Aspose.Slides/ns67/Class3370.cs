using System;

namespace ns67;

internal sealed class Class3370 : ICloneable
{
	private Struct157 struct157_0;

	public Struct157 FillRectangle
	{
		get
		{
			return struct157_0;
		}
		set
		{
			struct157_0 = value;
		}
	}

	public Class3370(Struct157 fillRectangle)
	{
		struct157_0 = fillRectangle;
	}

	public object Clone()
	{
		return method_0();
	}

	public Class3370 method_0()
	{
		return new Class3370(struct157_0);
	}
}
