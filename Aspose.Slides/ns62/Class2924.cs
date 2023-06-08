namespace ns62;

internal class Class2924 : Class2913
{
	public bool AfUsefLockAgainstUngrouping
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

	public bool BfUsefLockRotation
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

	public bool CfUsefLockAspectRatio
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

	public bool DfUsefLockPosition
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

	public bool EfUsefLockAgainstSelect
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

	public bool FfUsefLockCropping
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

	public bool GfUsefLockVertices
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

	public bool HfUsefLockText
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

	public bool IfUsefLockAdjustHandles
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

	public bool JfUsefLockAgainstGrouping
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

	public bool KfLockAgainstUngrouping
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

	public bool LfLockRotation
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

	public bool MfLockAspectRatio
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

	public bool NfLockPosition
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

	public bool OfLockAgainstSelect
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

	public bool PfLockCropping
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

	public bool QfLockVertices
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

	public bool RfLockText
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

	public bool SfLockAdjustHandles
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

	public bool TfLockAgainstGrouping
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

	public bool Folded_fLockAgainstUngrouping
	{
		get
		{
			if (AfUsefLockAgainstUngrouping)
			{
				return KfLockAgainstUngrouping;
			}
			return false;
		}
		set
		{
			AfUsefLockAgainstUngrouping = true;
			KfLockAgainstUngrouping = value;
		}
	}

	public bool Folded_fLockRotation
	{
		get
		{
			if (BfUsefLockRotation)
			{
				return LfLockRotation;
			}
			return false;
		}
		set
		{
			BfUsefLockRotation = true;
			LfLockRotation = value;
		}
	}

	public bool Folded_fLockAspectRatio
	{
		get
		{
			if (CfUsefLockAspectRatio)
			{
				return MfLockAspectRatio;
			}
			return false;
		}
		set
		{
			CfUsefLockAspectRatio = true;
			MfLockAspectRatio = value;
		}
	}

	public bool Folded_fLockPosition
	{
		get
		{
			if (DfUsefLockPosition)
			{
				return NfLockPosition;
			}
			return false;
		}
		set
		{
			DfUsefLockPosition = true;
			NfLockPosition = value;
		}
	}

	public bool Folded_fLockAgainstSelect
	{
		get
		{
			if (EfUsefLockAgainstSelect)
			{
				return OfLockAgainstSelect;
			}
			return false;
		}
		set
		{
			EfUsefLockAgainstSelect = true;
			OfLockAgainstSelect = value;
		}
	}

	public bool Folded_fLockCropping
	{
		get
		{
			if (FfUsefLockCropping)
			{
				return PfLockCropping;
			}
			return false;
		}
		set
		{
			FfUsefLockCropping = true;
			PfLockCropping = value;
		}
	}

	public bool Folded_fLockVertices
	{
		get
		{
			if (GfUsefLockVertices)
			{
				return QfLockVertices;
			}
			return false;
		}
		set
		{
			GfUsefLockVertices = true;
			QfLockVertices = value;
		}
	}

	public bool Folded_fLockText
	{
		get
		{
			if (HfUsefLockText)
			{
				return RfLockText;
			}
			return false;
		}
		set
		{
			HfUsefLockText = true;
			RfLockText = value;
		}
	}

	public bool Folded_fLockAdjustHandles
	{
		get
		{
			if (IfUsefLockAdjustHandles)
			{
				return SfLockAdjustHandles;
			}
			return false;
		}
		set
		{
			IfUsefLockAdjustHandles = true;
			SfLockAdjustHandles = value;
		}
	}

	public bool Folded_fLockAgainstGrouping
	{
		get
		{
			if (JfUsefLockAgainstGrouping)
			{
				return TfLockAgainstGrouping;
			}
			return false;
		}
		set
		{
			JfUsefLockAgainstGrouping = true;
			TfLockAgainstGrouping = value;
		}
	}

	public Class2924(uint value)
		: base(Enum426.const_404, isBid: false, value)
	{
	}

	public Class2924()
		: base(Enum426.const_404, isBid: false, 0u)
	{
	}

	protected override bool vmethod_1(Class2913 flags)
	{
		if (GetType() != flags.GetType())
		{
			return false;
		}
		Class2924 @class = (Class2924)flags;
		if (Folded_fLockAgainstUngrouping == @class.Folded_fLockAgainstUngrouping && Folded_fLockRotation == @class.Folded_fLockRotation && Folded_fLockAspectRatio == @class.Folded_fLockAspectRatio && Folded_fLockPosition == @class.Folded_fLockPosition && Folded_fLockAgainstSelect == @class.Folded_fLockAgainstSelect && Folded_fLockCropping == @class.Folded_fLockCropping && Folded_fLockVertices == @class.Folded_fLockVertices && Folded_fLockText == @class.Folded_fLockText && Folded_fLockAdjustHandles == @class.Folded_fLockAdjustHandles)
		{
			return Folded_fLockAgainstGrouping == @class.Folded_fLockAgainstGrouping;
		}
		return false;
	}
}
