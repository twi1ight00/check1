using System.Collections.Generic;
using System.Drawing.Drawing2D;
using ns224;

namespace ns258;

internal class Class6394 : Class6393
{
	private List<Class6396> list_0;

	public List<Class6396> DashStops
	{
		get
		{
			if (list_0 == null)
			{
				list_0 = new List<Class6396>();
			}
			return list_0;
		}
		set
		{
			list_0 = value;
		}
	}

	public override void vmethod_0(Class6003 pen)
	{
		float[] array = new float[DashStops.Count * 2];
		for (int i = 0; i < DashStops.Count; i++)
		{
			Class6396 @class = DashStops[i];
			array[i * 2] = (float)@class.DashLength.Fraction;
			array[i * 2 + 1] = (float)@class.SpaceLength.Fraction;
		}
		pen.DashStyle = DashStyle.Custom;
		pen.DashPattern = array;
	}

	public override Class6393 Clone()
	{
		Class6394 @class = new Class6394();
		@class.DashStops = new List<Class6396>(DashStops.Count);
		for (int i = 0; i < DashStops.Count; i++)
		{
			@class.DashStops[i] = DashStops[i].Clone();
		}
		return @class;
	}
}
