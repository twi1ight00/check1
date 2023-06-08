using System;
using Aspose.Cells;
using Aspose.Cells.Charts;

namespace ns27;

internal class Class599 : Class538
{
	internal Class599(Axis axis_0)
	{
		method_2(4194);
		method_0(18);
		byte_0 = new byte[18];
		byte_0[4] = 1;
		byte_0[8] = 1;
		byte_0[16] = 239;
		bool date = axis_0.Chart.method_14().Workbook.Settings.Date1904;
		bool bool_ = false;
		if (axis_0.CategoryType == CategoryType.TimeScale)
		{
			byte_0[16] |= 16;
			if (!axis_0.method_22())
			{
				byte_0[16] &= 223;
				bool_ = axis_0.BaseUnitScale != TimeUnit.Days;
			}
			switch (axis_0.BaseUnitScale)
			{
			case TimeUnit.Months:
				byte_0[12] = 1;
				break;
			case TimeUnit.Years:
				byte_0[12] = 2;
				break;
			}
		}
		if (!axis_0.method_7())
		{
			byte_0[16] &= 251;
			if (axis_0.CategoryType == CategoryType.TimeScale || axis_0.CategoryType == CategoryType.AutomaticScale)
			{
				switch (axis_0.MajorUnitScale)
				{
				case TimeUnit.Months:
					byte_0[6] = 1;
					break;
				case TimeUnit.Years:
					byte_0[6] = 2;
					break;
				}
			}
			Array.Copy(BitConverter.GetBytes((ushort)axis_0.MajorUnit), 0, byte_0, 4, 2);
		}
		if (!axis_0.method_9())
		{
			byte_0[16] &= 247;
			if (axis_0.CategoryType == CategoryType.TimeScale || axis_0.CategoryType == CategoryType.AutomaticScale)
			{
				switch (axis_0.MinorUnitScale)
				{
				case TimeUnit.Months:
					byte_0[10] = 1;
					break;
				case TimeUnit.Years:
					byte_0[10] = 2;
					break;
				}
			}
			Array.Copy(BitConverter.GetBytes((ushort)axis_0.MinorUnit), 0, byte_0, 8, 2);
		}
		if (!axis_0.method_3())
		{
			byte_0[16] &= 254;
			double num = method_4(axis_0.MinValue, bool_, axis_0.BaseUnitScale, date);
			Array.Copy(BitConverter.GetBytes((ushort)num), 0, byte_0, 0, 2);
		}
		if (!axis_0.method_6())
		{
			byte_0[16] &= 253;
			double num2 = method_4(axis_0.MaxValue, bool_, axis_0.BaseUnitScale, date);
			Array.Copy(BitConverter.GetBytes((ushort)num2), 0, byte_0, 2, 2);
		}
		if (axis_0.CategoryType != 0)
		{
			byte_0[16] &= 127;
		}
		if (axis_0.CrossType == CrossType.Custom)
		{
			byte_0[16] &= 191;
			Array.Copy(BitConverter.GetBytes((ushort)axis_0.CrossAt), 0, byte_0, 14, 2);
		}
		if (axis_0.bool_4)
		{
			byte_0[16] |= 64;
		}
	}

	internal double method_4(object object_0, bool bool_0, TimeUnit timeUnit_0, bool bool_1)
	{
		double num = 0.0;
		if (bool_0)
		{
			if (object_0 is double)
			{
				return method_6((double)object_0, timeUnit_0, bool_1);
			}
			return method_5((DateTime)object_0, timeUnit_0, bool_1);
		}
		if (!(object_0 is double result))
		{
			return CellsHelper.GetDoubleFromDateTime((DateTime)object_0, bool_1);
		}
		return result;
	}

	internal double method_5(DateTime dateTime_0, TimeUnit timeUnit_0, bool bool_0)
	{
		return timeUnit_0 switch
		{
			TimeUnit.Months => (dateTime_0.Year - (bool_0 ? 1904 : 1900)) * 12 + dateTime_0.Month - 1, 
			TimeUnit.Years => dateTime_0.Year - (bool_0 ? 1904 : 1900), 
			_ => CellsHelper.GetDoubleFromDateTime(dateTime_0, bool_0), 
		};
	}

	internal double method_6(double double_0, TimeUnit timeUnit_0, bool bool_0)
	{
		switch (timeUnit_0)
		{
		default:
			return double_0;
		case TimeUnit.Months:
		{
			DateTime dateTimeFromDouble = CellsHelper.GetDateTimeFromDouble(double_0, bool_0);
			return (dateTimeFromDouble.Year - (bool_0 ? 1904 : 1900)) * 12 + dateTimeFromDouble.Month - 1;
		}
		case TimeUnit.Years:
			return CellsHelper.GetDateTimeFromDouble(double_0, bool_0).Year - (bool_0 ? 1904 : 1900);
		}
	}
}
