namespace ns62;

internal class Class2916 : Class2913
{
	public bool BfUsefShadow
	{
		get
		{
			return (base.Value & 0x20000) == 131072;
		}
		set
		{
			base.Value = (value ? (base.Value | 0x20000u) : (base.Value & 0xFFFDFFFFu));
		}
	}

	public bool CfUsefshadowObscured
	{
		get
		{
			return (base.Value & 0x10000) == 65536;
		}
		set
		{
			base.Value = (value ? (base.Value | 0x10000u) : (base.Value & 0xFFFEFFFFu));
		}
	}

	public bool EfShadow
	{
		get
		{
			return (base.Value & 2) == 2;
		}
		set
		{
			base.Value = (value ? (base.Value | 2u) : (base.Value & 0xFFFFFFFDu));
		}
	}

	public bool FfshadowObscured
	{
		get
		{
			return (base.Value & 1) == 1;
		}
		set
		{
			base.Value = (value ? (base.Value | 1u) : (base.Value & 0xFFFFFFFEu));
		}
	}

	public bool Folded_fShadow
	{
		get
		{
			if (BfUsefShadow)
			{
				return EfShadow;
			}
			return false;
		}
		set
		{
			BfUsefShadow = true;
			EfShadow = value;
		}
	}

	public bool Folded_fshadowObscured
	{
		get
		{
			if (CfUsefshadowObscured)
			{
				return FfshadowObscured;
			}
			return false;
		}
		set
		{
			CfUsefshadowObscured = true;
			FfshadowObscured = value;
		}
	}

	public Class2916(uint value)
		: base(Enum426.const_324, isBid: false, value)
	{
	}

	public Class2916()
		: base(Enum426.const_324, isBid: false, 0u)
	{
	}

	protected override bool vmethod_1(Class2913 flags)
	{
		if (GetType() != flags.GetType())
		{
			return false;
		}
		Class2916 @class = (Class2916)flags;
		if (Folded_fShadow == @class.Folded_fShadow)
		{
			return Folded_fshadowObscured == @class.Folded_fshadowObscured;
		}
		return false;
	}
}
