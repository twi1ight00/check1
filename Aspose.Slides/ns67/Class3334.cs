using System;

namespace ns67;

internal sealed class Class3334 : Class3332
{
	private Class3459 class3459_1;

	private Enum460 enum460_0;

	public Class3459 FillToRectangle
	{
		get
		{
			return class3459_1;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			class3459_1 = value;
		}
	}

	public Enum460 Path
	{
		get
		{
			return enum460_0;
		}
		set
		{
			enum460_0 = value;
		}
	}

	public Class3334()
		: base(Enum459.const_1)
	{
		FillToRectangle = new Class3459(50.0, 50.0, 50.0, 50.0);
		Path = Enum460.const_2;
	}

	public Class3334(Class3459 filltoRectangle, Enum460 path)
		: base(Enum459.const_1)
	{
		FillToRectangle = filltoRectangle;
		Path = path;
	}

	public override Class3331 vmethod_0()
	{
		Class3334 @class = new Class3334(FillToRectangle.method_0(), Path);
		method_0(@class);
		return @class;
	}
}
