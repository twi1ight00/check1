namespace ns62;

internal class Class2919 : Class2913
{
	public bool AfUsefPicturePreserveGrays
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

	public bool BfUsefRewind
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

	public bool CfUsefLooping
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

	public bool DfUsefNoHitTestPicture
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

	public bool EfUsefPictureGray
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

	public bool FfUsefPictureBiLevel
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

	public bool GfUsefPictureActive
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

	public bool HfPicturePreserveGrays
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

	public bool IfRewind
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

	public bool JfLooping
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

	public bool KfNoHitTestPicture
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

	public bool LfPictureGray
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

	public bool MfPictureBiLevel
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

	public bool NfPictureActive
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

	public bool Folded_fPicturePreserveGrays
	{
		get
		{
			if (AfUsefPicturePreserveGrays)
			{
				return HfPicturePreserveGrays;
			}
			return false;
		}
		set
		{
			AfUsefPicturePreserveGrays = true;
			HfPicturePreserveGrays = value;
		}
	}

	public bool Folded_fRewind
	{
		get
		{
			if (BfUsefRewind)
			{
				return IfRewind;
			}
			return false;
		}
		set
		{
			BfUsefRewind = true;
			IfRewind = value;
		}
	}

	public bool Folded_fLooping
	{
		get
		{
			if (CfUsefLooping)
			{
				return JfLooping;
			}
			return false;
		}
		set
		{
			CfUsefLooping = true;
			JfLooping = value;
		}
	}

	public bool Folded_fNoHitTestPicture
	{
		get
		{
			if (DfUsefNoHitTestPicture)
			{
				return KfNoHitTestPicture;
			}
			return false;
		}
		set
		{
			DfUsefNoHitTestPicture = true;
			KfNoHitTestPicture = value;
		}
	}

	public bool Folded_fPictureGray
	{
		get
		{
			if (EfUsefPictureGray)
			{
				return LfPictureGray;
			}
			return false;
		}
		set
		{
			EfUsefPictureGray = true;
			LfPictureGray = value;
		}
	}

	public bool Folded_fPictureBiLevel
	{
		get
		{
			if (FfUsefPictureBiLevel)
			{
				return MfPictureBiLevel;
			}
			return false;
		}
		set
		{
			FfUsefPictureBiLevel = true;
			MfPictureBiLevel = value;
		}
	}

	public bool Folded_fPictureActive
	{
		get
		{
			if (GfUsefPictureActive)
			{
				return NfPictureActive;
			}
			return false;
		}
		set
		{
			GfUsefPictureActive = true;
			NfPictureActive = value;
		}
	}

	public Class2919(uint value)
		: base(Enum426.const_456, isBid: false, value)
	{
	}

	public Class2919()
		: base(Enum426.const_456, isBid: false, 0u)
	{
	}

	protected override bool vmethod_1(Class2913 flags)
	{
		if (GetType() != flags.GetType())
		{
			return false;
		}
		Class2919 @class = (Class2919)flags;
		if (Folded_fPicturePreserveGrays == @class.Folded_fPicturePreserveGrays && Folded_fRewind == @class.Folded_fRewind && Folded_fLooping == @class.Folded_fLooping && Folded_fNoHitTestPicture == @class.Folded_fNoHitTestPicture && Folded_fPictureGray == @class.Folded_fPictureGray && Folded_fPictureBiLevel == @class.Folded_fPictureBiLevel)
		{
			return Folded_fPictureActive == @class.Folded_fPictureActive;
		}
		return false;
	}
}
