namespace ns62;

internal class Class2914 : Class2913
{
	public bool AfUsegtextFReverseRows
	{
		get
		{
			return (base.Value & 0x80000000u) == 2147483648u;
		}
		set
		{
			base.Value = (value ? (base.Value | 0x80000000u) : (base.Value & 0x7FFFFFFFu));
		}
	}

	public bool BfUsefGtext
	{
		get
		{
			return (base.Value & 0x40000000) == 1073741824;
		}
		set
		{
			base.Value = (value ? (base.Value | 0x40000000u) : (base.Value & 0xBFFFFFFFu));
		}
	}

	public bool CfUsegtextFVertical
	{
		get
		{
			return (base.Value & 0x20000000) == 536870912;
		}
		set
		{
			base.Value = (value ? (base.Value | 0x20000000u) : (base.Value & 0xDFFFFFFFu));
		}
	}

	public bool DfUsegtextFKern
	{
		get
		{
			return (base.Value & 0x10000000) == 268435456;
		}
		set
		{
			base.Value = (value ? (base.Value | 0x10000000u) : (base.Value & 0xEFFFFFFFu));
		}
	}

	public bool EfUsegtextFTight
	{
		get
		{
			return (base.Value & 0x8000000) == 134217728;
		}
		set
		{
			base.Value = (value ? (base.Value | 0x8000000u) : (base.Value & 0xF7FFFFFFu));
		}
	}

	public bool FfUsegtextFStretch
	{
		get
		{
			return (base.Value & 0x4000000) == 67108864;
		}
		set
		{
			base.Value = (value ? (base.Value | 0x4000000u) : (base.Value & 0xFBFFFFFFu));
		}
	}

	public bool GfUsegtextFShrinkFit
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

	public bool HfUsegtextFBestFit
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

	public bool IfUsegtextFNormalize
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

	public bool JfUsegtextFDxMeasure
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

	public bool KfUsegtextFBold
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

	public bool LfUsegtextFItalic
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

	public bool MfUsegtextFUnderline
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

	public bool NfUsegtextFShadow
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

	public bool OfUsegtextFSmallcaps
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

	public bool PfUsegtextFStrikethrough
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

	public bool QgtextFReverseRows
	{
		get
		{
			return (base.Value & 0x8000) == 32768;
		}
		set
		{
			base.Value = (value ? (base.Value | 0x8000u) : (base.Value & 0xFFFF7FFFu));
		}
	}

	public bool RfGtext
	{
		get
		{
			return (base.Value & 0x4000) == 16384;
		}
		set
		{
			base.Value = (value ? (base.Value | 0x4000u) : (base.Value & 0xFFFFBFFFu));
		}
	}

	public bool SgtextFVertical
	{
		get
		{
			return (base.Value & 0x2000) == 8192;
		}
		set
		{
			base.Value = (value ? (base.Value | 0x2000u) : (base.Value & 0xFFFFDFFFu));
		}
	}

	public bool TgtextFKern
	{
		get
		{
			return (base.Value & 0x1000) == 4096;
		}
		set
		{
			base.Value = (value ? (base.Value | 0x1000u) : (base.Value & 0xFFFFEFFFu));
		}
	}

	public bool UgtextFTight
	{
		get
		{
			return (base.Value & 0x800) == 2048;
		}
		set
		{
			base.Value = (value ? (base.Value | 0x800u) : (base.Value & 0xFFFFF7FFu));
		}
	}

	public bool VgtextFStretch
	{
		get
		{
			return (base.Value & 0x400) == 1024;
		}
		set
		{
			base.Value = (value ? (base.Value | 0x400u) : (base.Value & 0xFFFFFBFFu));
		}
	}

	public bool WgtextFShrinkFit
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

	public bool XgtextFBestFit
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

	public bool YgtextFNormalize
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

	public bool ZgtextFDxMeasure
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

	public bool agtextFBold
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

	public bool bgtextFItalic
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

	public bool cgtextFUnderline
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

	public bool dgtextFShadow
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

	public bool egtextFSmallcaps
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

	public bool fgtextFStrikethrough
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

	public Class2914(uint value)
		: base(Enum426.const_426, isBid: false, value)
	{
	}

	public Class2914()
		: base(Enum426.const_426, isBid: false, 0u)
	{
	}
}
