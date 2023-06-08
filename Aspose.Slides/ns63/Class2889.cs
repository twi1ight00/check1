using System;
using System.IO;
using ns33;
using ns60;

namespace ns63;

internal class Class2889 : Class2623
{
	internal const int int_0 = 12011;

	private DateTime dateTime_0;

	public DateTime FileTime
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

	public Class2889()
	{
		base.Header.Type = 12011;
		dateTime_0 = DateTime.Now;
	}

	protected override void vmethod_0(BinaryReader reader)
	{
		try
		{
			dateTime_0 = Class1165.smethod_11(reader.ReadInt64());
		}
		catch (Exception ex)
		{
			Class1165.smethod_28(ex);
			dateTime_0 = DateTime.FromFileTimeUtc(0L);
		}
	}

	public override void vmethod_1(BinaryWriter writer)
	{
		writer.Write(Class1165.smethod_10(dateTime_0));
	}

	public override int vmethod_2()
	{
		return 8;
	}
}
