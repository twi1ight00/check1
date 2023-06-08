namespace ns237;

internal class Class6542 : Class6511
{
	private float float_0 = 1f;

	private float float_1 = 1f;

	internal override Enum892 ResourceType => Enum892.const_3;

	internal float StrokingAlpha
	{
		get
		{
			return float_0;
		}
		set
		{
			float_0 = value;
		}
	}

	internal float NonstrokingAlpha
	{
		get
		{
			return float_1;
		}
		set
		{
			float_1 = value;
		}
	}

	internal Class6542(Class6672 context)
		: base(context)
	{
	}

	public override void vmethod_0(Class6679 writer)
	{
		writer.method_29(this);
		writer.method_6();
		writer.method_8("/Type", "/ExtGState");
		if (class6672_0.PdfaCompliant)
		{
			writer.method_8("/CA", "1.0");
			writer.method_8("/ca", "1.0");
		}
		else
		{
			writer.method_19("/CA", float_0);
			writer.method_19("/ca", float_1);
		}
		writer.method_7();
		writer.method_30();
	}

	internal bool Equals(Class6542 rhs)
	{
		if (rhs != null && float_0 == rhs.float_0)
		{
			return float_1 == rhs.float_1;
		}
		return false;
	}
}
