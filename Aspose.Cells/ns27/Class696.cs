using System;
using Aspose.Cells.Charts;
using ns7;

namespace ns27;

internal class Class696 : Class538
{
	public Class696()
	{
		method_2(4187);
		method_0(14);
		byte_0 = new byte[14];
	}

	internal void method_4(ErrorBar errorBar_0)
	{
		if (errorBar_0.method_33())
		{
			if (errorBar_0.DisplayType == ErrorBarDisplayType.Plus)
			{
				byte_0[0] = 3;
			}
			else
			{
				byte_0[0] = 4;
			}
		}
		else if (errorBar_0.DisplayType == ErrorBarDisplayType.Plus)
		{
			byte_0[0] = 1;
		}
		else
		{
			byte_0[0] = 2;
		}
		switch (errorBar_0.Type)
		{
		case ErrorBarType.Custom:
			byte_0[1] = 4;
			break;
		case ErrorBarType.FixedValue:
			byte_0[1] = 2;
			break;
		case ErrorBarType.Percent:
			byte_0[1] = 1;
			break;
		case ErrorBarType.StDev:
			byte_0[1] = 3;
			break;
		case ErrorBarType.StError:
			byte_0[1] = 5;
			break;
		}
		if (errorBar_0.ShowMarkerTTop)
		{
			byte_0[2] = 1;
		}
		byte_0[3] = 1;
		Array.Copy(BitConverter.GetBytes(errorBar_0.Amount), 0, byte_0, 4, 8);
		if (errorBar_0.Type == ErrorBarType.Custom)
		{
			ushort num = 0;
			Interface45 @interface = null;
			@interface = ((errorBar_0.DisplayType != ErrorBarDisplayType.Plus) ? errorBar_0.method_37() : errorBar_0.method_35());
			if (@interface != null)
			{
				num = (ushort)@interface.imethod_11();
				Array.Copy(BitConverter.GetBytes(num), 0, byte_0, 12, 2);
			}
		}
		else
		{
			byte_0[12] = 1;
		}
	}
}
