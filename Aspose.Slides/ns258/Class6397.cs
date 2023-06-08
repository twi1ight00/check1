using System;
using System.Drawing.Drawing2D;
using ns224;

namespace ns258;

internal abstract class Class6397
{
	private Enum813 enum813_0;

	private Enum814 enum814_0;

	private Enum813 enum813_1;

	public Enum813 Length
	{
		get
		{
			return enum813_0;
		}
		set
		{
			enum813_0 = value;
		}
	}

	public Enum813 Width
	{
		get
		{
			return enum813_1;
		}
		set
		{
			enum813_1 = value;
		}
	}

	public Enum814 Type
	{
		get
		{
			return enum814_0;
		}
		set
		{
			enum814_0 = value;
		}
	}

	public abstract void vmethod_0(Class6003 pen);

	public abstract Class6397 Clone();

	protected void CopyTo(Class6397 target)
	{
		target.Length = Length;
		target.Width = Width;
		target.Type = Type;
	}

	protected LineCap method_0()
	{
		switch (Type)
		{
		default:
			throw new ArgumentOutOfRangeException();
		case Enum814.const_0:
			return LineCap.Flat;
		case Enum814.const_2:
			return LineCap.DiamondAnchor;
		case Enum814.const_3:
			return LineCap.RoundAnchor;
		case Enum814.const_1:
		case Enum814.const_4:
		case Enum814.const_5:
			return LineCap.ArrowAnchor;
		}
	}
}
