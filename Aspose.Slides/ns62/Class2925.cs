namespace ns62;

internal class Class2925 : Class2913
{
	public bool CfUsefPolicyLabel
	{
		get
		{
			return method_0(Enum437.const_0);
		}
		set
		{
			method_1(Enum437.const_0, value);
		}
	}

	public bool DfUsefPolicyBarcode
	{
		get
		{
			return method_0(Enum437.const_1);
		}
		set
		{
			method_1(Enum437.const_1, value);
		}
	}

	public bool EfUsefFlipHOverride
	{
		get
		{
			return method_0(Enum437.const_2);
		}
		set
		{
			method_1(Enum437.const_2, value);
		}
	}

	public bool FfUsefFlipVOverride
	{
		get
		{
			return method_0(Enum437.const_3);
		}
		set
		{
			method_1(Enum437.const_3, value);
		}
	}

	public bool GfUsefOleIcon
	{
		get
		{
			return method_0(Enum437.const_4);
		}
		set
		{
			method_1(Enum437.const_4, value);
		}
	}

	public bool HfUsefPreferRelativeResize
	{
		get
		{
			return method_0(Enum437.const_5);
		}
		set
		{
			method_1(Enum437.const_5, value);
		}
	}

	public bool IfUsefLockShapeType
	{
		get
		{
			return method_0(Enum437.const_6);
		}
		set
		{
			method_1(Enum437.const_6, value);
		}
	}

	public bool JfUsefInitiator
	{
		get
		{
			return method_0(Enum437.const_7);
		}
		set
		{
			method_1(Enum437.const_7, value);
		}
	}

	public bool LfUsefBackground
	{
		get
		{
			return method_0(Enum437.const_8);
		}
		set
		{
			method_1(Enum437.const_8, value);
		}
	}

	public bool OfPolicyLabel
	{
		get
		{
			return method_0(Enum437.const_9);
		}
		set
		{
			method_1(Enum437.const_9, value);
		}
	}

	public bool PfPolicyBarcode
	{
		get
		{
			return method_0(Enum437.const_10);
		}
		set
		{
			method_1(Enum437.const_10, value);
		}
	}

	public bool QfFlipHOverride
	{
		get
		{
			return method_0(Enum437.const_11);
		}
		set
		{
			method_1(Enum437.const_11, value);
		}
	}

	public bool RfFlipVOverride
	{
		get
		{
			return method_0(Enum437.const_12);
		}
		set
		{
			method_1(Enum437.const_12, value);
		}
	}

	public bool SfOleIcon
	{
		get
		{
			return method_0(Enum437.const_13);
		}
		set
		{
			method_1(Enum437.const_13, value);
		}
	}

	public bool TfPreferRelativeResize
	{
		get
		{
			return method_0(Enum437.const_14);
		}
		set
		{
			method_1(Enum437.const_14, value);
		}
	}

	public bool UfLockShapeType
	{
		get
		{
			return method_0(Enum437.const_15);
		}
		set
		{
			method_1(Enum437.const_15, value);
		}
	}

	public bool VfInitiator
	{
		get
		{
			return method_0(Enum437.const_16);
		}
		set
		{
			method_1(Enum437.const_16, value);
		}
	}

	public bool XfBackground
	{
		get
		{
			return method_0(Enum437.const_17);
		}
		set
		{
			method_1(Enum437.const_17, value);
		}
	}

	public bool Folded_fPolicyLabel
	{
		get
		{
			if (CfUsefPolicyLabel)
			{
				return OfPolicyLabel;
			}
			return false;
		}
		set
		{
			CfUsefPolicyLabel = true;
			OfPolicyLabel = value;
		}
	}

	public bool Folded_fPolicyBarcode
	{
		get
		{
			if (DfUsefPolicyBarcode)
			{
				return PfPolicyBarcode;
			}
			return false;
		}
		set
		{
			DfUsefPolicyBarcode = true;
			PfPolicyBarcode = value;
		}
	}

	public bool Folded_fFlipHOverride
	{
		get
		{
			if (EfUsefFlipHOverride)
			{
				return QfFlipHOverride;
			}
			return false;
		}
		set
		{
			EfUsefFlipHOverride = true;
			QfFlipHOverride = value;
		}
	}

	public bool Folded_fFlipVOverride
	{
		get
		{
			if (FfUsefFlipVOverride)
			{
				return RfFlipVOverride;
			}
			return false;
		}
		set
		{
			FfUsefFlipVOverride = true;
			RfFlipVOverride = value;
		}
	}

	public bool Folded_fOleIcon
	{
		get
		{
			if (GfUsefOleIcon)
			{
				return SfOleIcon;
			}
			return false;
		}
		set
		{
			GfUsefOleIcon = true;
			SfOleIcon = value;
		}
	}

	public bool Folded_fPreferRelativeResize
	{
		get
		{
			if (HfUsefPreferRelativeResize)
			{
				return TfPreferRelativeResize;
			}
			return false;
		}
		set
		{
			HfUsefPreferRelativeResize = true;
			TfPreferRelativeResize = value;
		}
	}

	public bool Folded_fLockShapeType
	{
		get
		{
			if (IfUsefLockShapeType)
			{
				return UfLockShapeType;
			}
			return false;
		}
		set
		{
			IfUsefLockShapeType = true;
			UfLockShapeType = value;
		}
	}

	public bool Folded_fInitiator
	{
		get
		{
			if (JfUsefInitiator)
			{
				return VfInitiator;
			}
			return false;
		}
		set
		{
			JfUsefInitiator = true;
			VfInitiator = value;
		}
	}

	public bool Folded_fBackground
	{
		get
		{
			if (LfUsefBackground)
			{
				return XfBackground;
			}
			return false;
		}
		set
		{
			LfUsefBackground = true;
			XfBackground = value;
		}
	}

	public Class2925(uint value)
		: base(Enum426.const_10, isBid: false, value)
	{
	}

	public Class2925()
		: base(Enum426.const_10, isBid: false, 0u)
	{
	}

	protected override bool vmethod_1(Class2913 flags)
	{
		if (GetType() != flags.GetType())
		{
			return false;
		}
		Class2925 @class = (Class2925)flags;
		if (Folded_fPolicyLabel == @class.Folded_fPolicyLabel && Folded_fPolicyBarcode == @class.Folded_fPolicyBarcode && Folded_fFlipHOverride == @class.Folded_fFlipHOverride && Folded_fFlipVOverride == @class.Folded_fFlipVOverride && Folded_fOleIcon == @class.Folded_fOleIcon && Folded_fPreferRelativeResize == @class.Folded_fPreferRelativeResize && Folded_fLockShapeType == @class.Folded_fLockShapeType && Folded_fInitiator == @class.Folded_fInitiator)
		{
			return Folded_fBackground == @class.Folded_fBackground;
		}
		return false;
	}

	private bool method_0(Enum437 bit)
	{
		return (base.Value & (uint)bit) != 0;
	}

	private void method_1(Enum437 bit, bool value)
	{
		base.Value = (value ? (base.Value | (uint)bit) : (base.Value & (uint)(~bit)));
	}
}
