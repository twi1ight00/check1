using System.Runtime.CompilerServices;

namespace Aspose.Cells.Drawing;

public class PicFormatOption
{
	private ushort ushort_0 = 3584;

	private FillPictureType fillPictureType_0;

	private double double_0 = 1.0;

	private int int_0;

	private int int_1;

	private int int_2;

	private int int_3;

	internal ushort ushort_1 = 19;

	public FillPictureType Type
	{
		get
		{
			return fillPictureType_0;
		}
		set
		{
			fillPictureType_0 = value;
		}
	}

	public double Scale
	{
		get
		{
			return double_0;
		}
		set
		{
			double_0 = value;
		}
	}

	public double Left
	{
		get
		{
			return (double)int_0 / 1000.0;
		}
		set
		{
			int_0 = (int)(value * 1000.0 + 0.5);
		}
	}

	public double Top
	{
		get
		{
			return (double)int_1 / 1000.0;
		}
		set
		{
			int_1 = (int)(value * 1000.0 + 0.5);
		}
	}

	public double Bottom
	{
		get
		{
			return (double)int_3 / 1000.0;
		}
		set
		{
			int_3 = (int)(value * 1000.0 + 0.5);
		}
	}

	public double Right
	{
		get
		{
			return (double)int_2 / 1000.0;
		}
		set
		{
			int_2 = (int)(value * 1000.0 + 0.5);
		}
	}

	[SpecialName]
	internal ushort method_0()
	{
		return ushort_0;
	}

	[SpecialName]
	internal void method_1(ushort ushort_2)
	{
		ushort_0 = ushort_2;
	}

	[SpecialName]
	internal bool method_2()
	{
		return (method_0() & 0x800) != 0;
	}

	[SpecialName]
	internal void method_3(bool bool_0)
	{
		if (bool_0)
		{
			method_1((ushort)(method_0() | 0x800u));
		}
		else
		{
			method_1((ushort)(method_0() & 0xF7FFu));
		}
	}

	[SpecialName]
	internal bool method_4()
	{
		return (method_0() & 0x400) != 0;
	}

	[SpecialName]
	internal void method_5(bool bool_0)
	{
		if (bool_0)
		{
			method_1((ushort)(method_0() | 0x800u));
		}
		else
		{
			method_1((ushort)(method_0() & 0xFBFFu));
		}
	}

	[SpecialName]
	internal bool method_6()
	{
		return (method_0() & 0x200) != 0;
	}

	[SpecialName]
	internal void method_7(bool bool_0)
	{
		if (bool_0)
		{
			method_1((ushort)(method_0() | 0x800u));
		}
		else
		{
			method_1((ushort)(method_0() & 0xFDFFu));
		}
	}

	internal void Copy(PicFormatOption picFormatOption_0)
	{
		ushort_0 = picFormatOption_0.ushort_0;
		fillPictureType_0 = picFormatOption_0.fillPictureType_0;
		double_0 = picFormatOption_0.double_0;
		ushort_1 = picFormatOption_0.ushort_1;
		int_0 = picFormatOption_0.int_0;
		int_1 = picFormatOption_0.int_1;
		int_3 = picFormatOption_0.int_3;
		int_2 = picFormatOption_0.int_2;
	}
}
