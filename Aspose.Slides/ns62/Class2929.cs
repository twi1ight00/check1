namespace ns62;

internal class Class2929 : Class2911
{
	public bool AfIsTable
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

	public bool BfIsTablePlaceholder
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

	public bool CfIsTableRTL
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

	public Class2929(uint value)
		: base(Enum426.const_45, isBid: false, value)
	{
	}

	public Class2929()
		: base(Enum426.const_45, isBid: false, 0u)
	{
		AfIsTable = false;
		BfIsTablePlaceholder = false;
		CfIsTableRTL = false;
	}
}
