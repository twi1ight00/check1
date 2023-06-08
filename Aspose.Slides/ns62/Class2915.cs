namespace ns62;

internal class Class2915 : Class2913
{
	public bool AfUsef3D
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

	public bool BfUsefc3DMetallic
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

	public bool CfUsefc3DUseExtrusionColor
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

	public bool DfUsefc3DLightFace
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

	public bool Ef3D
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

	public bool Ffc3DMetallic
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

	public bool Gfc3DUseExtrusionColor
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

	public bool Hfc3DLightFace
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

	public bool Folded_f3D
	{
		get
		{
			if (AfUsef3D)
			{
				return Ef3D;
			}
			return false;
		}
		set
		{
			AfUsef3D = true;
			Ef3D = value;
		}
	}

	public bool Folded_fc3DMetallic
	{
		get
		{
			if (BfUsefc3DMetallic)
			{
				return Ffc3DMetallic;
			}
			return false;
		}
		set
		{
			BfUsefc3DMetallic = true;
			Ffc3DMetallic = value;
		}
	}

	public bool Folded_fc3DUseExtrusionColor
	{
		get
		{
			if (CfUsefc3DUseExtrusionColor)
			{
				return Gfc3DUseExtrusionColor;
			}
			return false;
		}
		set
		{
			CfUsefc3DUseExtrusionColor = true;
			Gfc3DUseExtrusionColor = value;
		}
	}

	public bool Folded_fc3DLightFace
	{
		get
		{
			if (DfUsefc3DLightFace)
			{
				return Hfc3DLightFace;
			}
			return true;
		}
		set
		{
			DfUsefc3DLightFace = true;
			Hfc3DLightFace = value;
		}
	}

	public Class2915(uint value)
		: base(Enum426.const_352, isBid: false, value)
	{
	}

	public Class2915()
		: base(Enum426.const_352, isBid: false, 0u)
	{
	}

	protected override bool vmethod_1(Class2913 flags)
	{
		if (GetType() != flags.GetType())
		{
			return false;
		}
		Class2915 @class = (Class2915)flags;
		if (Folded_f3D == @class.Folded_f3D && Folded_fc3DMetallic == @class.Folded_fc3DMetallic && Folded_fc3DUseExtrusionColor == @class.Folded_fc3DUseExtrusionColor)
		{
			return Folded_fc3DLightFace == @class.Folded_fc3DLightFace;
		}
		return false;
	}
}
