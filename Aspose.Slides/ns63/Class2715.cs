using System;
using System.IO;
using ns62;

namespace ns63;

internal class Class2715 : Class2639
{
	public const int int_0 = 1035;

	private Class2644 class2644_0;

	private static readonly int[] int_1 = new int[2] { 61440, 2147483647 };

	public Class2644 OfficeArtDgg
	{
		get
		{
			if (class2644_0 != null)
			{
				return class2644_0;
			}
			class2644_0 = (Class2644)method_1(61440);
			if (class2644_0 == null && base.AutoInit)
			{
				class2644_0 = new Class2644();
				class2644_0.AutoInit = true;
				base.Records.Add(class2644_0);
			}
			return class2644_0;
		}
	}

	public Class2715()
	{
		base.Header.Version = 15;
		base.Header.Instance = 0;
		base.Header.Type = 1035;
	}

	internal void method_5()
	{
		Class2644 @class = new Class2644();
		@class.method_5();
		@class.Header.Version = 15;
		@class.Header.Instance = 0;
		base.Records.Add(@class);
	}

	protected override void vmethod_0(BinaryReader _reader)
	{
		int num = Convert.ToInt32(_reader.BaseStream.Position + base.Header.Length);
		Class2644 @class = Class2950.smethod_0(_reader) as Class2644;
		base.Records.Add(@class);
		if (@class == null)
		{
			throw new Exception("First Escher record is not DggContainer.");
		}
		if (_reader.BaseStream.Position < num)
		{
			throw new Exception("Probably DrawingGroupContainer contains more DggContainer records.");
		}
	}

	protected override int[] vmethod_6()
	{
		return int_1;
	}
}
