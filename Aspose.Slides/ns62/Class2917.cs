namespace ns62;

internal class Class2917 : Class2913
{
	public bool AfUsefc3DConstrainRotation
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

	public bool BfUsefc3DRotationCenterAuto
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

	public bool CfUsefc3DParallel
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

	public bool DfUsefc3DKeyHarsh
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

	public bool EfUsefc3DFillHarsh
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

	public bool Ffc3DConstrainRotation
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

	public bool Gfc3DRotationCenterAuto
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

	public bool Hfc3DParallel
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

	public bool Ifc3DKeyHarsh
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

	public bool Jfc3DFillHarsh
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

	public bool Folded_fc3DConstrainRotation
	{
		get
		{
			if (AfUsefc3DConstrainRotation)
			{
				return Ffc3DConstrainRotation;
			}
			return true;
		}
		set
		{
			AfUsefc3DConstrainRotation = true;
			Ffc3DConstrainRotation = value;
		}
	}

	public bool Folded_fc3DRotationCenterAuto
	{
		get
		{
			if (BfUsefc3DRotationCenterAuto)
			{
				return Gfc3DRotationCenterAuto;
			}
			return false;
		}
		set
		{
			BfUsefc3DRotationCenterAuto = true;
			Gfc3DRotationCenterAuto = value;
		}
	}

	public bool Folded_fc3DParallel
	{
		get
		{
			if (CfUsefc3DParallel)
			{
				return Hfc3DParallel;
			}
			return true;
		}
		set
		{
			CfUsefc3DParallel = true;
			Hfc3DParallel = value;
		}
	}

	public bool Folded_fc3DKeyHarsh
	{
		get
		{
			if (DfUsefc3DKeyHarsh)
			{
				return Ifc3DKeyHarsh;
			}
			return true;
		}
		set
		{
			DfUsefc3DKeyHarsh = true;
			Ifc3DKeyHarsh = value;
		}
	}

	public bool Folded_fc3DFillHarsh
	{
		get
		{
			if (EfUsefc3DFillHarsh)
			{
				return Jfc3DFillHarsh;
			}
			return false;
		}
		set
		{
			EfUsefc3DFillHarsh = true;
			Jfc3DFillHarsh = value;
		}
	}

	public Class2917(uint value)
		: base(Enum426.const_380, isBid: false, value)
	{
	}

	public Class2917()
		: base(Enum426.const_380, isBid: false, 0u)
	{
	}

	protected override bool vmethod_1(Class2913 flags)
	{
		if (GetType() != flags.GetType())
		{
			return false;
		}
		Class2917 @class = (Class2917)flags;
		if (Folded_fc3DConstrainRotation == @class.Folded_fc3DConstrainRotation && Folded_fc3DRotationCenterAuto == @class.Folded_fc3DRotationCenterAuto && Folded_fc3DParallel == @class.Folded_fc3DParallel && Folded_fc3DKeyHarsh == @class.Folded_fc3DKeyHarsh)
		{
			return Folded_fc3DFillHarsh == @class.Folded_fc3DFillHarsh;
		}
		return false;
	}
}
