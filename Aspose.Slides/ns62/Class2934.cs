using System;
using System.IO;
using ns4;

namespace ns62;

internal class Class2934 : Class2930
{
	public const ushort ushort_0 = 65520;

	private const ushort ushort_1 = 6;

	private const ushort ushort_2 = 0;

	private const ushort ushort_3 = 2;

	private const ushort ushort_4 = 4;

	private const ushort ushort_5 = 4;

	private ushort ushort_6;

	private ushort ushort_7;

	public ushort NElems => ushort_6;

	public ushort CbElem => ushort_7;

	public ulong this[int index]
	{
		get
		{
			if (index >= 0 && index < NElems)
			{
				if ((CbElem < 1 || CbElem > 8) && CbElem != 65520)
				{
					throw new InvalidOperationException("Size of element is " + ushort_7 + ", but should be between 1 and 8 or 0xFFF0.");
				}
				ushort num = method_2();
				byte[] array = new byte[8];
				byte[] array2 = array;
				Array.Copy(Value, 6 + index * num, array2, 0, num);
				return (ulong)Class1162.smethod_11(array2);
			}
			throw new ArgumentOutOfRangeException("index");
		}
		set
		{
			if (index >= 0 && index < NElems)
			{
				if ((CbElem < 1 || CbElem > 8) && CbElem != 65520)
				{
					throw new InvalidOperationException("Size of element is " + ushort_7 + ", but should be between 1 and 8 or 0xFFF0.");
				}
				ushort num = method_2();
				byte[] array = new byte[8];
				byte[] array2 = array;
				Class1162.smethod_20(array2, 0, (long)value);
				Array.Copy(array2, 0, Value, 6 + index * num, num);
				return;
			}
			throw new ArgumentOutOfRangeException("index");
		}
	}

	public Class2934(Enum426 id, ushort nElems, ushort cbElem)
		: base(id, 6 + nElems * ((cbElem != 65520) ? cbElem : 4))
	{
		ushort_6 = nElems;
		ushort_7 = cbElem;
		Class1162.smethod_13(Value, 0, nElems);
		ushort num;
		for (num = 4; num < nElems; num = (ushort)(num * 2))
		{
		}
		Class1162.smethod_13(Value, 2, num);
		Class1162.smethod_13(Value, 4, cbElem);
	}

	public byte[] method_1(int index)
	{
		ushort num = method_2();
		byte[] array = new byte[num];
		Array.Copy(Value, 6 + index * num, array, 0, num);
		return array;
	}

	internal Class2934(Enum426 id, int size)
		: base(id, (size == 0) ? size : (size + 6))
	{
	}

	internal override void vmethod_1(BinaryReader reader)
	{
		if (base.Size != 0)
		{
			reader.Read(Value, 0, 6);
			ushort_6 = (ushort)Class1162.smethod_1(Value, 0);
			ushort_7 = (ushort)Class1162.smethod_1(Value, 4);
			method_0(6 + ushort_6 * method_2());
			reader.Read(Value, 6, ushort_6 * method_2());
		}
	}

	private ushort method_2()
	{
		if (CbElem == 65520)
		{
			return 4;
		}
		return CbElem;
	}
}
