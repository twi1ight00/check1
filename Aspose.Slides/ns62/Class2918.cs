namespace ns62;

internal class Class2918 : Class2913
{
	public bool AfUsefSelectText
	{
		get
		{
			return method_0(Enum418.const_0);
		}
		set
		{
			method_1(Enum418.const_0, value);
		}
	}

	public bool BfUsefAutoTextMargin
	{
		get
		{
			return method_0(Enum418.const_1);
		}
		set
		{
			method_1(Enum418.const_1, value);
		}
	}

	public bool DfUsefFitShapeToText
	{
		get
		{
			return method_0(Enum418.const_2);
		}
		set
		{
			method_1(Enum418.const_2, value);
		}
	}

	public bool FfSelectText
	{
		get
		{
			return method_0(Enum418.const_3);
		}
		set
		{
			method_1(Enum418.const_3, value);
		}
	}

	public bool GfAutoTextMargin
	{
		get
		{
			return method_0(Enum418.const_4);
		}
		set
		{
			method_1(Enum418.const_4, value);
		}
	}

	public bool IfFitShapeToText
	{
		get
		{
			return method_0(Enum418.const_5);
		}
		set
		{
			method_1(Enum418.const_5, value);
		}
	}

	public bool Folded_fSelectText
	{
		get
		{
			if (AfUsefSelectText)
			{
				return FfSelectText;
			}
			return true;
		}
		set
		{
			AfUsefSelectText = true;
			FfSelectText = value;
		}
	}

	public bool Folded_fAutoTextMargin
	{
		get
		{
			if (BfUsefAutoTextMargin)
			{
				return GfAutoTextMargin;
			}
			return false;
		}
		set
		{
			BfUsefAutoTextMargin = true;
			GfAutoTextMargin = value;
		}
	}

	public bool Folded_fFitShapeToText
	{
		get
		{
			if (DfUsefFitShapeToText)
			{
				return IfFitShapeToText;
			}
			return false;
		}
		set
		{
			DfUsefFitShapeToText = true;
			IfFitShapeToText = value;
		}
	}

	public Class2918(uint value)
		: base(Enum426.const_419, value)
	{
	}

	public Class2918()
		: base(Enum426.const_419, 0u)
	{
	}

	protected override bool vmethod_1(Class2913 flags)
	{
		if (GetType() != flags.GetType())
		{
			return false;
		}
		Class2918 @class = (Class2918)flags;
		if (Folded_fSelectText == @class.Folded_fSelectText && Folded_fAutoTextMargin == @class.Folded_fAutoTextMargin)
		{
			return Folded_fFitShapeToText == @class.Folded_fFitShapeToText;
		}
		return false;
	}

	private bool method_0(Enum418 bit)
	{
		return (base.Value & (uint)bit) != 0;
	}

	private void method_1(Enum418 bit, bool value)
	{
		base.Value = (value ? (base.Value | (uint)bit) : (base.Value & (uint)(~bit)));
	}
}
