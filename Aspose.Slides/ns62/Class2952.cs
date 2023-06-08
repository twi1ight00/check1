using System;
using Aspose.Slides;
using ns4;

namespace ns62;

internal class Class2952
{
	public const ushort ushort_0 = 8192;

	public const ushort ushort_1 = 16384;

	public const ushort ushort_2 = 32768;

	public const ushort ushort_3 = 8;

	private readonly Enum429 enum429_0;

	private readonly bool bool_0;

	private readonly bool bool_1;

	private readonly bool bool_2;

	private readonly ushort ushort_4;

	private readonly ushort ushort_5;

	private readonly ushort ushort_6;

	public Enum429 Sgf => enum429_0;

	public bool CalculatedParam1 => bool_0;

	public bool CalculatedParam2 => bool_1;

	public bool CalculatedParam3 => bool_2;

	public ushort Param1 => ushort_4;

	public ushort Param2 => ushort_5;

	public ushort Param3 => ushort_6;

	public Class2952(byte[] data)
	{
		method_0(data, ref enum429_0, ref bool_0, ref bool_1, ref bool_2, ref ushort_4, ref ushort_5, ref ushort_6);
	}

	public Class2952(byte[] data, int offset)
	{
		if (data == null)
		{
			throw new ArgumentException("'Data' argument can't be null.", "data");
		}
		byte[] array = new byte[8];
		Array.Copy(data, offset, array, 0, 8);
		method_0(array, ref enum429_0, ref bool_0, ref bool_1, ref bool_2, ref ushort_4, ref ushort_5, ref ushort_6);
	}

	private void method_0(byte[] data, ref Enum429 sgf, ref bool calculatedParam1, ref bool calculatedParam2, ref bool calculatedParam3, ref ushort param1, ref ushort param2, ref ushort param3)
	{
		if (data != null && data.Length == 8)
		{
			int num = 0;
			ushort num2 = (ushort)Class1162.smethod_1(data, 0);
			num = 2;
			calculatedParam1 = (num2 & 0x2000) != 0;
			calculatedParam2 = (num2 & 0x4000) != 0;
			calculatedParam3 = (num2 & 0x8000) != 0;
			int num3 = num2 & 0xFF;
			if (!Enum.IsDefined(typeof(Enum429), num3))
			{
				throw new PptReadException("Wrong sgf value in [ms-odraw] 2.2.58 SG structure.");
			}
			sgf = (Enum429)num3;
			param1 = (ushort)Class1162.smethod_1(data, num);
			num += 2;
			param2 = (ushort)Class1162.smethod_1(data, num);
			num += 2;
			param3 = (ushort)Class1162.smethod_1(data, num);
			return;
		}
		throw new ArgumentException("The 'data' parameter should be byte[8] array.", "data");
	}
}
