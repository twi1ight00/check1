using System;
using System.Text;
using Aspose.Cells.Tables;

namespace ns27;

internal class Class547 : Class538
{
	internal Class547(TableStyleCollection tableStyleCollection_0)
	{
		method_2(2190);
		method_0(20);
		if (tableStyleCollection_0.method_0() != null)
		{
			method_0((short)(base.Length + (short)(tableStyleCollection_0.method_0().Length * 2)));
		}
		if (tableStyleCollection_0.method_2() != null)
		{
			method_0((short)(base.Length + (short)(tableStyleCollection_0.method_2().Length * 2)));
		}
		byte_0 = new byte[base.Length];
		byte_0[0] = 142;
		byte_0[1] = 8;
		byte_0[12] = 145;
		int num = 20;
		if (tableStyleCollection_0.method_0() != null)
		{
			byte_0[16] = (byte)tableStyleCollection_0.method_0().Length;
			byte[] bytes = Encoding.Unicode.GetBytes(tableStyleCollection_0.method_0());
			Array.Copy(bytes, 0, byte_0, num, bytes.Length);
			num += bytes.Length;
		}
		if (tableStyleCollection_0.method_2() != null)
		{
			byte_0[18] = (byte)tableStyleCollection_0.method_2().Length;
			byte[] bytes2 = Encoding.Unicode.GetBytes(tableStyleCollection_0.method_2());
			Array.Copy(bytes2, 0, byte_0, num, bytes2.Length);
			num += bytes2.Length;
		}
	}
}
