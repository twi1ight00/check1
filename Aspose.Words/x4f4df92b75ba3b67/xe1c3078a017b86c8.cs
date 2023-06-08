using System;
using System.IO;
using x13f1efc79617a47b;

namespace x4f4df92b75ba3b67;

internal class xe1c3078a017b86c8 : x8fbf0a5e230a8cae
{
	private enum xee2dcce2d4d9a065
	{
		x05df1daf36918cac,
		xe5b12026d3ec9d64,
		xa3d5222f0ca75bbf,
		x3da62c615f6e57ef
	}

	private const int x7e9904b269e29b39 = 128;

	private const int x9128741dd92648ce = 129;

	internal xe1c3078a017b86c8(Stream outputStream)
		: base(outputStream)
	{
	}

	public override void Write(byte[] srcBuffer, int srcOffset, int srcCount)
	{
		byte[] array = new byte[128];
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		xee2dcce2d4d9a065 xee2dcce2d4d9a = xee2dcce2d4d9a065.x05df1daf36918cac;
		for (int i = 0; i < srcCount; i++)
		{
			int num4 = srcOffset + i;
			if (xee2dcce2d4d9a != 0)
			{
				num2 = srcBuffer[num4];
				num3 = srcBuffer[num4 - 1];
			}
			switch (xee2dcce2d4d9a)
			{
			case xee2dcce2d4d9a065.x05df1daf36918cac:
				xee2dcce2d4d9a = xee2dcce2d4d9a065.xe5b12026d3ec9d64;
				num = 0;
				break;
			case xee2dcce2d4d9a065.xe5b12026d3ec9d64:
				if (num2 == num3)
				{
					xee2dcce2d4d9a = xee2dcce2d4d9a065.x3da62c615f6e57ef;
					num = 2;
				}
				else
				{
					xee2dcce2d4d9a = xee2dcce2d4d9a065.xa3d5222f0ca75bbf;
					array[0] = (byte)num3;
					num = 1;
				}
				break;
			case xee2dcce2d4d9a065.xa3d5222f0ca75bbf:
				if (num2 == num3)
				{
					x6336365b7b2af5bd(array, num);
					xee2dcce2d4d9a = xee2dcce2d4d9a065.x3da62c615f6e57ef;
					num = 2;
					break;
				}
				array[num] = (byte)num3;
				num++;
				if (num == 128)
				{
					x6336365b7b2af5bd(array, num);
					xee2dcce2d4d9a = xee2dcce2d4d9a065.xe5b12026d3ec9d64;
					num = 0;
				}
				break;
			case xee2dcce2d4d9a065.x3da62c615f6e57ef:
				if (num2 != num3)
				{
					xb8b74ad6e2360bb5(num3, num);
					xee2dcce2d4d9a = xee2dcce2d4d9a065.xe5b12026d3ec9d64;
					num = 0;
					break;
				}
				num++;
				if (num == 128)
				{
					xb8b74ad6e2360bb5(num2, num);
					xee2dcce2d4d9a = xee2dcce2d4d9a065.x05df1daf36918cac;
				}
				break;
			default:
				throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("cpcgiakgcabhcaihaaphfagijpmiikdjhnkjombkemikmjpkmoglkonlenemeolmcncnijjn", 2098750109)));
			}
		}
		switch (xee2dcce2d4d9a)
		{
		case xee2dcce2d4d9a065.xe5b12026d3ec9d64:
		case xee2dcce2d4d9a065.xa3d5222f0ca75bbf:
			array[num] = (byte)num2;
			num++;
			x6336365b7b2af5bd(array, num);
			break;
		case xee2dcce2d4d9a065.x3da62c615f6e57ef:
			xb8b74ad6e2360bb5(num2, num);
			break;
		default:
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("klkdanbekmiekmpeimgfnmnfbmegahlgpjchgjjhmiaieghieloiclfjmjmjmkdkkjkkagbl", 409811557)));
		}
		x6169576fb3c218d3.WriteByte(129);
	}

	private void x6336365b7b2af5bd(byte[] x2ae6dc61baa71888, int xfd7d9762a674c69e)
	{
		x6169576fb3c218d3.WriteByte((byte)(xfd7d9762a674c69e - 1));
		x6169576fb3c218d3.Write(x2ae6dc61baa71888, 0, xfd7d9762a674c69e);
	}

	private void xb8b74ad6e2360bb5(int xdcfaa20633a00dc2, int x10f4d88af727adbc)
	{
		x6169576fb3c218d3.WriteByte((byte)(257 - x10f4d88af727adbc));
		x6169576fb3c218d3.WriteByte((byte)xdcfaa20633a00dc2);
	}
}
