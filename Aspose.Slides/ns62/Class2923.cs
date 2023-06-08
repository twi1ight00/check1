namespace ns62;

internal class Class2923 : Class2913
{
	public bool AfUsefLineOpaqueBackColor
	{
		get
		{
			return (base.Value & 0x2000000) == 33554432;
		}
		set
		{
			base.Value = (value ? (base.Value | 0x2000000u) : (base.Value & 0xFDFFFFFFu));
		}
	}

	public bool BUnused2
	{
		get
		{
			return (base.Value & 0x1000000) == 16777216;
		}
		set
		{
			base.Value = (value ? (base.Value | 0x1000000u) : (base.Value & 0xFEFFFFFFu));
		}
	}

	public bool CUnused3
	{
		get
		{
			return (base.Value & 0x800000) == 8388608;
		}
		set
		{
			base.Value = (value ? (base.Value | 0x800000u) : (base.Value & 0xFF7FFFFFu));
		}
	}

	public bool DfUsefInsetPen
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

	public bool EfUsefInsetPenOK
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

	public bool FfUsefArrowheadsOK
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

	public bool GfUsefLine
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

	public bool HfUsefHitTestLine
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

	public bool IfUsefLineFillShape
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

	public bool JfUsefNoLineDrawDash
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

	public bool KfLineOpaqueBackColor
	{
		get
		{
			return (base.Value & 0x200) == 512;
		}
		set
		{
			base.Value = (value ? (base.Value | 0x200u) : (base.Value & 0xFFFFFDFFu));
		}
	}

	public bool LReserved1
	{
		get
		{
			return (base.Value & 0x100) == 256;
		}
		set
		{
			base.Value = (value ? (base.Value | 0x100u) : (base.Value & 0xFFFFFEFFu));
		}
	}

	public bool MReserved2
	{
		get
		{
			return (base.Value & 0x80) == 128;
		}
		set
		{
			base.Value = (value ? (base.Value | 0x80u) : (base.Value & 0xFFFFFF7Fu));
		}
	}

	public bool NfInsetPen
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

	public bool OfInsetPenOK
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

	public bool PfArrowheadsOK
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

	public bool QfLine
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

	public bool RfHitTestLine
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

	public bool SfLineFillShape
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

	public bool TfNoLineDrawDash
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

	public bool Folded_fLineOpaqueBackColor
	{
		get
		{
			if (AfUsefLineOpaqueBackColor)
			{
				return KfLineOpaqueBackColor;
			}
			return false;
		}
		set
		{
			AfUsefLineOpaqueBackColor = true;
			KfLineOpaqueBackColor = value;
		}
	}

	public bool Folded_fInsetPen
	{
		get
		{
			if (DfUsefInsetPen)
			{
				return NfInsetPen;
			}
			return false;
		}
		set
		{
			DfUsefInsetPen = true;
			NfInsetPen = value;
		}
	}

	public bool Folded_fInsetPenOK
	{
		get
		{
			if (EfUsefInsetPenOK)
			{
				return OfInsetPenOK;
			}
			return true;
		}
		set
		{
			EfUsefInsetPenOK = true;
			OfInsetPenOK = value;
		}
	}

	public bool Folded_fArrowheadsOK
	{
		get
		{
			if (FfUsefArrowheadsOK)
			{
				return PfArrowheadsOK;
			}
			return false;
		}
		set
		{
			FfUsefArrowheadsOK = true;
			PfArrowheadsOK = value;
		}
	}

	public bool Folded_fLine
	{
		get
		{
			if (GfUsefLine)
			{
				return QfLine;
			}
			return false;
		}
		set
		{
			GfUsefLine = true;
			QfLine = value;
		}
	}

	public bool Folded_fHitTestLine
	{
		get
		{
			if (HfUsefHitTestLine)
			{
				return RfHitTestLine;
			}
			return true;
		}
		set
		{
			HfUsefHitTestLine = true;
			RfHitTestLine = value;
		}
	}

	public bool Folded_fLineFillShape
	{
		get
		{
			if (IfUsefLineFillShape)
			{
				return SfLineFillShape;
			}
			return true;
		}
		set
		{
			IfUsefLineFillShape = true;
			SfLineFillShape = value;
		}
	}

	public bool Folded_fNoLineDrawDash
	{
		get
		{
			if (JfUsefNoLineDrawDash)
			{
				return TfNoLineDrawDash;
			}
			return false;
		}
		set
		{
			JfUsefNoLineDrawDash = true;
			TfNoLineDrawDash = value;
		}
	}

	public Class2923(uint value)
		: base(Enum426.const_154, isBid: false, value)
	{
	}

	public Class2923()
		: base(Enum426.const_154, isBid: false, 0u)
	{
	}

	protected override bool vmethod_1(Class2913 flags)
	{
		if (GetType() != flags.GetType())
		{
			return false;
		}
		Class2923 @class = (Class2923)flags;
		if (Folded_fLineOpaqueBackColor == @class.Folded_fLineOpaqueBackColor && Folded_fInsetPen == @class.Folded_fInsetPen && Folded_fInsetPenOK == @class.Folded_fInsetPenOK && Folded_fArrowheadsOK == @class.Folded_fArrowheadsOK && Folded_fLine == @class.Folded_fLine && Folded_fHitTestLine == @class.Folded_fHitTestLine && Folded_fLineFillShape == @class.Folded_fLineFillShape)
		{
			return Folded_fNoLineDrawDash == @class.Folded_fNoLineDrawDash;
		}
		return false;
	}
}
