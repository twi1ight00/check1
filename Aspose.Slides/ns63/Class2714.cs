using System;
using System.IO;
using ns60;
using ns62;

namespace ns63;

internal class Class2714 : Class2639
{
	public const int int_0 = 1036;

	private Class2643 class2643_0;

	private static readonly int[] int_1 = new int[2] { 61442, 2147483647 };

	public Class2643 OfficeArtDg
	{
		get
		{
			if (class2643_0 != null)
			{
				return class2643_0;
			}
			class2643_0 = (Class2643)method_1(61442);
			return class2643_0;
		}
	}

	public Class2714()
	{
		base.Header.Type = 1036;
	}

	internal void method_5(Enum452 queryType)
	{
		Class2643 @class = new Class2643();
		@class.method_5(queryType);
		@class.Header.Version = 15;
		@class.Header.Instance = 0;
		base.Records.Add(@class);
	}

	protected override void vmethod_0(BinaryReader _reader)
	{
		int num = (int)(_reader.BaseStream.Position + base.Header.Length);
		if (!(Class2950.smethod_0(_reader) is Class2643 item))
		{
			throw new Exception("First Escher record is not DgContainer.");
		}
		base.Records.Add(item);
		if (_reader.BaseStream.Position < num)
		{
			throw new Exception("Probably DrawingContainer contains more DgContainer records.");
		}
	}

	protected override int[] vmethod_6()
	{
		return int_1;
	}
}
