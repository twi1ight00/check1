using System;
using System.IO;
using ns60;

namespace ns63;

internal class Class2939 : Interface40
{
	private DateTime dateTime_0;

	public DateTime DateTime
	{
		get
		{
			return dateTime_0;
		}
		set
		{
			dateTime_0 = value;
		}
	}

	internal void method_0(BinaryReader reader)
	{
		short year = reader.ReadInt16();
		short month = reader.ReadInt16();
		reader.ReadInt16();
		short day = reader.ReadInt16();
		short hour = reader.ReadInt16();
		short minute = reader.ReadInt16();
		short second = reader.ReadInt16();
		short millisecond = reader.ReadInt16();
		dateTime_0 = new DateTime(year, month, day, hour, minute, second, millisecond);
	}

	internal void method_1(BinaryWriter writer)
	{
		writer.Write((short)dateTime_0.Year);
		writer.Write((short)dateTime_0.Month);
		writer.Write((short)dateTime_0.DayOfWeek);
		writer.Write((short)dateTime_0.Day);
		writer.Write((short)dateTime_0.Hour);
		writer.Write((short)dateTime_0.Minute);
		writer.Write((short)dateTime_0.Second);
		writer.Write((short)dateTime_0.Millisecond);
	}

	internal int method_2()
	{
		return 16;
	}
}
