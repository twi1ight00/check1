namespace ns62;

internal class Class2921 : Class2913
{
	public bool EfUsefShadowOK
	{
		get
		{
			return method_0(Enum428.const_0);
		}
		set
		{
			method_1(Enum428.const_0, value);
		}
	}

	public bool FfUsef3DOK
	{
		get
		{
			return method_0(Enum428.const_1);
		}
		set
		{
			method_1(Enum428.const_1, value);
		}
	}

	public bool GfUsefLineOK
	{
		get
		{
			return method_0(Enum428.const_2);
		}
		set
		{
			method_1(Enum428.const_2, value);
		}
	}

	public bool HfUsefGtextOK
	{
		get
		{
			return method_0(Enum428.const_3);
		}
		set
		{
			method_1(Enum428.const_3, value);
		}
	}

	public bool IfUsefFillShadeShapeOK
	{
		get
		{
			return method_0(Enum428.const_4);
		}
		set
		{
			method_1(Enum428.const_4, value);
		}
	}

	public bool JfUsefFillOK
	{
		get
		{
			return method_0(Enum428.const_5);
		}
		set
		{
			method_1(Enum428.const_5, value);
		}
	}

	public bool OfShadowOK
	{
		get
		{
			return method_0(Enum428.const_6);
		}
		set
		{
			method_1(Enum428.const_6, value);
		}
	}

	public bool Pf3DOK
	{
		get
		{
			return method_0(Enum428.const_7);
		}
		set
		{
			method_1(Enum428.const_7, value);
		}
	}

	public bool QfLineOK
	{
		get
		{
			return method_0(Enum428.const_8);
		}
		set
		{
			method_1(Enum428.const_8, value);
		}
	}

	public bool RfGtextOK
	{
		get
		{
			return method_0(Enum428.const_9);
		}
		set
		{
			method_1(Enum428.const_9, value);
		}
	}

	public bool SfFillShadeShapeOK
	{
		get
		{
			return method_0(Enum428.const_10);
		}
		set
		{
			method_1(Enum428.const_10, value);
		}
	}

	public bool TfFillOK
	{
		get
		{
			return method_0(Enum428.const_11);
		}
		set
		{
			method_1(Enum428.const_11, value);
		}
	}

	public bool Folded_fShadowOK
	{
		get
		{
			if (EfUsefShadowOK)
			{
				return OfShadowOK;
			}
			return true;
		}
		set
		{
			EfUsefShadowOK = true;
			OfShadowOK = value;
		}
	}

	public bool Folded_f3DOK
	{
		get
		{
			if (FfUsef3DOK)
			{
				return Pf3DOK;
			}
			return true;
		}
		set
		{
			FfUsef3DOK = true;
			Pf3DOK = value;
		}
	}

	public bool Folded_fLineOK
	{
		get
		{
			if (GfUsefLineOK)
			{
				return QfLineOK;
			}
			return true;
		}
		set
		{
			GfUsefLineOK = true;
			QfLineOK = value;
		}
	}

	public bool Folded_fGtextOK
	{
		get
		{
			if (HfUsefGtextOK)
			{
				return RfGtextOK;
			}
			return false;
		}
		set
		{
			HfUsefGtextOK = true;
			RfGtextOK = value;
		}
	}

	public bool Folded_fFillShadeShapeOK
	{
		get
		{
			if (IfUsefFillShadeShapeOK)
			{
				return SfFillShadeShapeOK;
			}
			return false;
		}
		set
		{
			IfUsefFillShadeShapeOK = true;
			SfFillShadeShapeOK = value;
		}
	}

	public bool Folded_fFillOK
	{
		get
		{
			if (JfUsefFillOK)
			{
				return TfFillOK;
			}
			return true;
		}
		set
		{
			JfUsefFillOK = true;
			TfFillOK = value;
		}
	}

	public Class2921(uint value)
		: base(Enum426.const_80, value)
	{
	}

	public Class2921()
		: base(Enum426.const_80, 0u)
	{
	}

	protected override bool vmethod_1(Class2913 flags)
	{
		if (GetType() != flags.GetType())
		{
			return false;
		}
		Class2921 @class = (Class2921)flags;
		if (Folded_fShadowOK == @class.Folded_fShadowOK && Folded_f3DOK == @class.Folded_f3DOK && Folded_fLineOK == @class.Folded_fLineOK && Folded_fGtextOK == @class.Folded_fGtextOK && Folded_fFillShadeShapeOK == @class.Folded_fFillShadeShapeOK)
		{
			return Folded_fFillOK == @class.Folded_fFillOK;
		}
		return false;
	}

	private bool method_0(Enum428 bit)
	{
		return (base.Value & (uint)bit) != 0;
	}

	private void method_1(Enum428 bit, bool value)
	{
		base.Value = (value ? (base.Value | (uint)bit) : (base.Value & (uint)(~bit)));
	}
}
