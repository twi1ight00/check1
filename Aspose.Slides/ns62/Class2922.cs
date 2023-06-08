namespace ns62;

internal class Class2922 : Class2913
{
	public bool AfUsefLayoutInCell
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

	public bool BfUsefIsBullet
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

	public bool CfUsefStandardHR
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

	public bool DfUsefNoshadeHR
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

	public bool EfUsefHorizRule
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

	public bool FfUsefUserDrawn
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

	public bool GfUsefAllowOverlap
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

	public bool HfUsefReallyHidden
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

	public bool IfUsefScriptAnchor
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

	public bool JfUsefEditedWrap
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

	public bool KfUsefBehindDocument
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

	public bool LfUsefOnDblClickNotify
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

	public bool MfUsefIsButton
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

	public bool NfUsefOneD
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

	public bool OfUsefHidden
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

	public bool PfUsefPrint
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

	public bool QfLayoutInCell
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

	public bool RfIsBullet
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

	public bool SfStandardHR
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

	public bool TfNoshadeHR
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

	public bool UfHorizRule
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

	public bool VfUserDrawn
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

	public bool WfAllowOverlap
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

	public bool XfReallyHidden
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

	public bool YfScriptAnchor
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

	public bool ZfEditedWrap
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

	public bool afBehindDocument
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

	public bool bfOnDblClickNotify
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

	public bool cfIsButton
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

	public bool dfOneD
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

	public bool efHidden
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

	public bool ffPrint
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

	public bool Folded_fLayoutInCell
	{
		get
		{
			if (AfUsefLayoutInCell)
			{
				return QfLayoutInCell;
			}
			return true;
		}
		set
		{
			AfUsefLayoutInCell = true;
			QfLayoutInCell = value;
		}
	}

	public bool Folded_fIsBullet
	{
		get
		{
			if (BfUsefIsBullet)
			{
				return RfIsBullet;
			}
			return false;
		}
		set
		{
			BfUsefIsBullet = true;
			RfIsBullet = value;
		}
	}

	public bool Folded_fStandardHR
	{
		get
		{
			if (CfUsefStandardHR)
			{
				return SfStandardHR;
			}
			return false;
		}
		set
		{
			CfUsefStandardHR = true;
			SfStandardHR = value;
		}
	}

	public bool Folded_fNoshadeHR
	{
		get
		{
			if (DfUsefNoshadeHR)
			{
				return TfNoshadeHR;
			}
			return false;
		}
		set
		{
			DfUsefNoshadeHR = true;
			TfNoshadeHR = value;
		}
	}

	public bool Folded_fHorizRule
	{
		get
		{
			if (EfUsefHorizRule)
			{
				return UfHorizRule;
			}
			return false;
		}
		set
		{
			EfUsefHorizRule = true;
			UfHorizRule = value;
		}
	}

	public bool Folded_fUserDrawn
	{
		get
		{
			if (FfUsefUserDrawn)
			{
				return VfUserDrawn;
			}
			return false;
		}
		set
		{
			FfUsefUserDrawn = true;
			VfUserDrawn = value;
		}
	}

	public bool Folded_fAllowOverlap
	{
		get
		{
			if (GfUsefAllowOverlap)
			{
				return WfAllowOverlap;
			}
			return true;
		}
		set
		{
			GfUsefAllowOverlap = true;
			WfAllowOverlap = value;
		}
	}

	public bool Folded_fReallyHidden
	{
		get
		{
			if (HfUsefReallyHidden)
			{
				return XfReallyHidden;
			}
			return false;
		}
		set
		{
			HfUsefReallyHidden = true;
			XfReallyHidden = value;
		}
	}

	public bool Folded_fScriptAnchor
	{
		get
		{
			if (IfUsefScriptAnchor)
			{
				return YfScriptAnchor;
			}
			return false;
		}
		set
		{
			IfUsefScriptAnchor = true;
			YfScriptAnchor = value;
		}
	}

	public bool Folded_fEditedWrap
	{
		get
		{
			if (JfUsefEditedWrap)
			{
				return ZfEditedWrap;
			}
			return false;
		}
		set
		{
			JfUsefEditedWrap = true;
			ZfEditedWrap = value;
		}
	}

	public bool Folded_fBehindDocument
	{
		get
		{
			if (KfUsefBehindDocument)
			{
				return afBehindDocument;
			}
			return false;
		}
		set
		{
			KfUsefBehindDocument = true;
			afBehindDocument = value;
		}
	}

	public bool Folded_fOnDblClickNotify
	{
		get
		{
			if (LfUsefOnDblClickNotify)
			{
				return bfOnDblClickNotify;
			}
			return false;
		}
		set
		{
			LfUsefOnDblClickNotify = true;
			bfOnDblClickNotify = value;
		}
	}

	public bool Folded_fIsButton
	{
		get
		{
			if (MfUsefIsButton)
			{
				return cfIsButton;
			}
			return false;
		}
		set
		{
			MfUsefIsButton = true;
			cfIsButton = value;
		}
	}

	public bool Folded_fOneD
	{
		get
		{
			if (NfUsefOneD)
			{
				return dfOneD;
			}
			return false;
		}
		set
		{
			NfUsefOneD = true;
			dfOneD = value;
		}
	}

	public bool Folded_fHidden
	{
		get
		{
			if (OfUsefHidden)
			{
				return efHidden;
			}
			return false;
		}
		set
		{
			OfUsefHidden = true;
			efHidden = value;
		}
	}

	public bool Folded_fPrint
	{
		get
		{
			if (PfUsefPrint)
			{
				return ffPrint;
			}
			return true;
		}
		set
		{
			PfUsefPrint = true;
			ffPrint = value;
		}
	}

	public Class2922(uint value)
		: base(Enum426.const_50, isBid: false, value)
	{
	}

	public Class2922()
		: base(Enum426.const_50, isBid: false, 0u)
	{
	}

	protected override bool vmethod_1(Class2913 flags)
	{
		if (GetType() != flags.GetType())
		{
			return false;
		}
		Class2922 @class = (Class2922)flags;
		if (Folded_fLayoutInCell == @class.Folded_fLayoutInCell && Folded_fIsBullet == @class.Folded_fIsBullet && Folded_fStandardHR == @class.Folded_fStandardHR && Folded_fNoshadeHR == @class.Folded_fNoshadeHR && Folded_fHorizRule == @class.Folded_fHorizRule && Folded_fUserDrawn == @class.Folded_fUserDrawn && Folded_fAllowOverlap == @class.Folded_fAllowOverlap && Folded_fReallyHidden == @class.Folded_fReallyHidden && Folded_fScriptAnchor == @class.Folded_fScriptAnchor && Folded_fEditedWrap == @class.Folded_fEditedWrap && Folded_fBehindDocument == @class.Folded_fBehindDocument && Folded_fOnDblClickNotify == @class.Folded_fOnDblClickNotify && Folded_fIsButton == @class.Folded_fIsButton && Folded_fOneD == @class.Folded_fOneD && Folded_fHidden == @class.Folded_fHidden)
		{
			return Folded_fPrint == @class.Folded_fPrint;
		}
		return false;
	}
}
