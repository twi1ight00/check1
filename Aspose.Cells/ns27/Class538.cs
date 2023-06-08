using System;
using System.Runtime.CompilerServices;
using Aspose.Cells;
using ns59;

namespace ns27;

internal abstract class Class538
{
	protected FileFormatType fileFormatType_0 = FileFormatType.Default;

	protected byte[] byte_0;

	private short short_0;

	private short short_1;

	internal short Length => short_0;

	internal byte[] Data => byte_0;

	[SpecialName]
	internal void method_0(short short_2)
	{
		short_0 = short_2;
	}

	[SpecialName]
	internal short method_1()
	{
		return short_1;
	}

	[SpecialName]
	internal void method_2(short short_2)
	{
		short_1 = short_2;
	}

	internal virtual void vmethod_0(Class1725 class1725_0)
	{
		byte[] array;
		if (byte_0 != null && byte_0.Length != 0)
		{
			array = new byte[byte_0.Length + 4];
			Array.Copy(BitConverter.GetBytes(short_1), 0, array, 0, 2);
			Array.Copy(BitConverter.GetBytes(short_0), 0, array, 2, 2);
			Array.Copy(byte_0, 0, array, 4, byte_0.Length);
		}
		else
		{
			array = new byte[4];
			Array.Copy(BitConverter.GetBytes(short_1), 0, array, 0, 2);
			Array.Copy(BitConverter.GetBytes(short_0), 0, array, 2, 2);
		}
		class1725_0.method_3(array);
	}

	internal void method_3(byte[] byte_1)
	{
		byte_0 = byte_1;
		if (byte_1 != null)
		{
			short_0 = (short)byte_1.Length;
		}
		else
		{
			short_0 = 0;
		}
	}

	internal void Copy(Class538 class538_0)
	{
		method_0(class538_0.Length);
		byte_0 = new byte[Length];
		Array.Copy(class538_0.byte_0, byte_0, Length);
	}
}
