namespace ns62;

internal class Class2920 : Class2913
{
	public bool AfUsefRecolorFillAsPicture
	{
		get
		{
			return (base.Value & 0x400000) == 4194304;
		}
		set
		{
			base.Value = (value ? (base.Value | 0x400000u) : (base.Value & 0xFFBFFFFFu));
		}
	}

	public bool BfUsefUseShapeAnchor
	{
		get
		{
			return (base.Value & 0x200000) == 2097152;
		}
		set
		{
			base.Value = (value ? (base.Value | 0x200000u) : (base.Value & 0xFFDFFFFFu));
		}
	}

	public bool CfUsefFilled
	{
		get
		{
			return (base.Value & 0x100000) == 1048576;
		}
		set
		{
			base.Value = (value ? (base.Value | 0x100000u) : (base.Value & 0xFFEFFFFFu));
		}
	}

	public bool DfUsefHitTestFill
	{
		get
		{
			return (base.Value & 0x80000) == 524288;
		}
		set
		{
			base.Value = (value ? (base.Value | 0x80000u) : (base.Value & 0xFFF7FFFFu));
		}
	}

	public bool EfUsefillShape
	{
		get
		{
			return (base.Value & 0x40000) == 262144;
		}
		set
		{
			base.Value = (value ? (base.Value | 0x40000u) : (base.Value & 0xFFFBFFFFu));
		}
	}

	public bool FfUsefillUseRect
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

	public bool GfUsefNoFillHitTest
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

	public bool HfRecolorFillAsPicture
	{
		get
		{
			return (base.Value & 0x40) == 64;
		}
		set
		{
			base.Value = (value ? (base.Value | 0x40u) : (base.Value & 0xFFFFFFBFu));
		}
	}

	public bool IfUseShapeAnchor
	{
		get
		{
			return (base.Value & 0x20) == 32;
		}
		set
		{
			base.Value = (value ? (base.Value | 0x20u) : (base.Value & 0xFFFFFFDFu));
		}
	}

	public bool JfFilled
	{
		get
		{
			return (base.Value & 0x10) == 16;
		}
		set
		{
			base.Value = (value ? (base.Value | 0x10u) : (base.Value & 0xFFFFFFEFu));
		}
	}

	public bool KfHitTestFill
	{
		get
		{
			return (base.Value & 8) == 8;
		}
		set
		{
			base.Value = (value ? (base.Value | 8u) : (base.Value & 0xFFFFFFF7u));
		}
	}

	public bool LfillShape
	{
		get
		{
			return (base.Value & 4) == 4;
		}
		set
		{
			base.Value = (value ? (base.Value | 4u) : (base.Value & 0xFFFFFFFBu));
		}
	}

	public bool MfillUseRect
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

	public bool NfNoFillHitTest
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

	public bool Folded_fRecolorFillAsPicture
	{
		get
		{
			if (AfUsefRecolorFillAsPicture)
			{
				return HfRecolorFillAsPicture;
			}
			return false;
		}
		set
		{
			AfUsefRecolorFillAsPicture = true;
			HfRecolorFillAsPicture = value;
		}
	}

	public bool Folded_fUseShapeAnchor
	{
		get
		{
			if (BfUsefUseShapeAnchor)
			{
				return IfUseShapeAnchor;
			}
			return false;
		}
		set
		{
			BfUsefUseShapeAnchor = true;
			IfUseShapeAnchor = value;
		}
	}

	public bool Folded_fFilled
	{
		get
		{
			if (CfUsefFilled)
			{
				return JfFilled;
			}
			return true;
		}
		set
		{
			CfUsefFilled = true;
			JfFilled = value;
		}
	}

	public bool Folded_fHitTestFill
	{
		get
		{
			if (DfUsefHitTestFill)
			{
				return KfHitTestFill;
			}
			return true;
		}
		set
		{
			DfUsefHitTestFill = true;
			KfHitTestFill = value;
		}
	}

	public bool Folded_fillShape
	{
		get
		{
			if (EfUsefillShape)
			{
				return LfillShape;
			}
			return true;
		}
		set
		{
			EfUsefillShape = true;
			LfillShape = value;
		}
	}

	public bool Folded_fillUseRect
	{
		get
		{
			if (FfUsefillUseRect)
			{
				return MfillUseRect;
			}
			return false;
		}
		set
		{
			FfUsefillUseRect = true;
			MfillUseRect = value;
		}
	}

	public bool Folded_fNoFillHitTest
	{
		get
		{
			if (GfUsefNoFillHitTest)
			{
				return NfNoFillHitTest;
			}
			return false;
		}
		set
		{
			GfUsefNoFillHitTest = true;
			NfNoFillHitTest = value;
		}
	}

	public Class2920(uint value)
		: base(Enum426.const_119, isBid: false, value)
	{
	}

	public Class2920()
		: base(Enum426.const_119, isBid: false, 0u)
	{
	}

	protected override bool vmethod_1(Class2913 flags)
	{
		if (GetType() != flags.GetType())
		{
			return false;
		}
		Class2920 @class = (Class2920)flags;
		if (Folded_fRecolorFillAsPicture == @class.Folded_fRecolorFillAsPicture && Folded_fUseShapeAnchor == @class.Folded_fUseShapeAnchor && Folded_fFilled == @class.Folded_fFilled && Folded_fHitTestFill == @class.Folded_fHitTestFill && Folded_fillShape == @class.Folded_fillShape && Folded_fillUseRect == @class.Folded_fillUseRect)
		{
			return Folded_fNoFillHitTest == @class.Folded_fNoFillHitTest;
		}
		return false;
	}
}
