using System;
using System.Text;
using Aspose.Cells;
using ns22;

namespace ns27;

internal class Class689 : Class538
{
	public Class689()
	{
		method_2(2152);
	}

	[Attribute0(true)]
	internal void method_4(ProtectedRange protectedRange_0)
	{
		method_0((short)(27 + protectedRange_0.method_0().Count * 8 + 8 + 3 + protectedRange_0.Name.Length * 2));
		if (protectedRange_0.byte_0 != null)
		{
			method_0((short)(base.Length + (short)protectedRange_0.byte_0.Length));
		}
		byte_0 = new byte[base.Length];
		byte_0[0] = 104;
		byte_0[1] = 8;
		byte_0[12] = 2;
		int num = 19;
		Array.Copy(BitConverter.GetBytes((ushort)protectedRange_0.method_0().Count), 0, byte_0, 19, 2);
		num = 19 + 8;
		for (int i = 0; i < protectedRange_0.method_0().Count; i++)
		{
			CellArea cellArea = (CellArea)protectedRange_0.method_0()[i];
			Array.Copy(BitConverter.GetBytes((ushort)cellArea.StartRow), 0, byte_0, num, 2);
			Array.Copy(BitConverter.GetBytes((ushort)cellArea.EndRow), 0, byte_0, num + 2, 2);
			Array.Copy(BitConverter.GetBytes((ushort)cellArea.StartColumn), 0, byte_0, num + 4, 2);
			Array.Copy(BitConverter.GetBytes((ushort)cellArea.EndColumn), 0, byte_0, num + 6, 2);
			num += 8;
		}
		if (protectedRange_0.byte_0 != null)
		{
			byte_0[num] = 1;
		}
		num += 4;
		Array.Copy(BitConverter.GetBytes(protectedRange_0.method_1()), 0, byte_0, num, 2);
		num += 4;
		Array.Copy(BitConverter.GetBytes((ushort)protectedRange_0.Name.Length), 0, byte_0, num, 2);
		byte_0[num + 2] = 1;
		num += 3;
		Array.Copy(Encoding.Unicode.GetBytes(protectedRange_0.Name), 0, byte_0, num, protectedRange_0.Name.Length * 2);
		num += protectedRange_0.Name.Length * 2;
		if (protectedRange_0.byte_0 != null)
		{
			Array.Copy(protectedRange_0.byte_0, 0, byte_0, num, protectedRange_0.byte_0.Length);
		}
	}
}
