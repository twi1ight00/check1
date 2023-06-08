using System;
using System.Drawing.Drawing2D;
using ns224;

namespace ns258;

internal class Class6395 : Class6393
{
	private static readonly float[] float_0 = new float[4] { 4f, 3f, 1f, 3f };

	private static readonly float[] float_1 = new float[2] { 4f, 3f };

	private static readonly float[] float_2 = new float[2] { 1f, 3f };

	private static readonly float[] float_3 = new float[6] { 8f, 3f, 1f, 3f, 1f, 3f };

	private static readonly float[] float_4 = new float[4] { 8f, 3f, 1f, 3f };

	private static readonly float[] float_5 = new float[2] { 8f, 3f };

	private Enum816 enum816_0;

	public Enum816 Preset
	{
		get
		{
			return enum816_0;
		}
		set
		{
			enum816_0 = value;
		}
	}

	public override void vmethod_0(Class6003 pen)
	{
		switch (Preset)
		{
		default:
			throw new ArgumentOutOfRangeException();
		case Enum816.const_0:
			pen.DashStyle = DashStyle.Solid;
			break;
		case Enum816.const_1:
			pen.DashPattern = float_1;
			break;
		case Enum816.const_2:
			pen.DashPattern = float_0;
			break;
		case Enum816.const_3:
			pen.DashPattern = float_2;
			break;
		case Enum816.const_4:
			pen.DashPattern = float_5;
			break;
		case Enum816.const_5:
			pen.DashPattern = float_4;
			break;
		case Enum816.const_6:
			pen.DashPattern = float_3;
			break;
		case Enum816.const_7:
			pen.DashStyle = DashStyle.Dash;
			break;
		case Enum816.const_8:
			pen.DashStyle = DashStyle.DashDot;
			break;
		case Enum816.const_9:
			pen.DashStyle = DashStyle.DashDotDot;
			break;
		case Enum816.const_10:
			pen.DashStyle = DashStyle.Dot;
			break;
		}
	}

	public override Class6393 Clone()
	{
		Class6395 @class = new Class6395();
		@class.Preset = Preset;
		return @class;
	}
}
