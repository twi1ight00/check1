using System;
using System.Collections;
using System.Text;
using ns122;
using ns157;

namespace ns123;

internal class Class4541 : Class4521
{
	private Class4728 class4728_0;

	private Class4551 class4551_0;

	private byte[] byte_3;

	private int int_1;

	private ArrayList arrayList_0;

	private byte[] byte_4 = new byte[2];

	private int int_2;

	public byte[] DecryptedBytes => byte_3;

	public Class4541(Class4700 context, Class4521 parent)
		: base(context, parent)
	{
		byte_1 = new byte[3][]
		{
			Encoding.ASCII.GetBytes("currentfile eexec\n"),
			Encoding.ASCII.GetBytes("currentfile eexec\r\n"),
			Encoding.ASCII.GetBytes("currentfile eexec\r")
		};
		byte_0 = new byte[1][] { Encoding.ASCII.GetBytes("0000000000000000000") };
		arrayList_0 = new ArrayList(6);
	}

	public override void vmethod_1()
	{
		class4728_0 = new Class4728(Class4728.Enum667.const_0);
		int_1 = 0;
		class4551_0 = null;
		base.vmethod_1();
	}

	protected override void vmethod_5()
	{
		byte_3 = new byte[class4551_0.DataBytesCount];
		Array.Copy(class4551_0.Buffer, 0, byte_3, 0, class4551_0.DataBytesCount);
		class4551_0 = null;
		base.vmethod_5();
	}

	protected override void vmethod_6(int currentPosition)
	{
		bool flag = false;
		byte cipher = byte_2[currentPosition];
		if (class4551_0 == null)
		{
			if (base.Context.IsPFA)
			{
				class4551_0 = new Class4551(byte_2.Length - currentPosition / 2);
			}
			else
			{
				class4551_0 = new Class4551(byte_2.Length - currentPosition);
			}
		}
		if (base.Context.IsPFA)
		{
			if (smethod_0(byte_2[currentPosition], out var revVal))
			{
				byte_4[int_2++] = revVal;
				if (int_2 >= 2)
				{
					cipher = (byte)(16 * byte_4[0] + byte_4[1]);
					flag = true;
					int_2 = 0;
				}
			}
		}
		else if (int_1 <= 0)
		{
			if ((arrayList_0.Count == 0 && byte_2[currentPosition] != 128) || (arrayList_0.Count == 1 && byte_2[currentPosition] != 2 && byte_2[currentPosition] != 1))
			{
				int_1 = int.MaxValue;
				flag = true;
			}
			arrayList_0.Add(byte_2[currentPosition]);
			if (arrayList_0.Count == 6)
			{
				int_1 = (byte)arrayList_0[5] << 24;
				int_1 += (byte)arrayList_0[4] << 16;
				int_1 += (byte)arrayList_0[3] << 8;
				int_1 += (byte)arrayList_0[2];
				arrayList_0.Clear();
			}
		}
		else
		{
			flag = true;
		}
		if (flag)
		{
			class4551_0.method_0(class4728_0.method_0(cipher));
			if (!base.Context.IsPFA)
			{
				int_1--;
			}
		}
		base.vmethod_6(currentPosition);
	}

	private static bool smethod_0(byte symbol, out byte revVal)
	{
		revVal = symbol;
		if (revVal >= 48 && revVal <= 57)
		{
			revVal -= 48;
			return true;
		}
		if (revVal >= 65 && revVal <= 70)
		{
			revVal -= 55;
			return true;
		}
		if (revVal >= 97 && revVal <= 102)
		{
			revVal -= 87;
			return true;
		}
		return false;
	}
}
