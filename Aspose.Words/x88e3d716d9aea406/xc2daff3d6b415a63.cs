using System.IO;
using System.Text;
using Aspose;

namespace x88e3d716d9aea406;

[JavaDelete("This is antihacking code, not yet ported to Java. Maybe in the future.")]
internal class xc2daff3d6b415a63
{
	private MemoryStream xd749382ab0504c8c = new MemoryStream();

	private byte x0d6acb71d4570d92;

	private byte x723bd7c019444336 = byte.MaxValue;

	private byte[] xf27ba8b7a39be7cd;

	private int xd7edf0363fb4b430;

	private MemoryStream x946c9f8facd5fb6b = new MemoryStream();

	private x2025b81d9343aee4 x08af7b2ab6b34dbe;

	private x2025b81d9343aee4 x5a34d0505c78f78b;

	internal MemoryStream xc945ba8006f88a6a => xd749382ab0504c8c;

	internal byte x06142cd0912898c6 => x0d6acb71d4570d92;

	internal byte xda4d904918caea37 => x723bd7c019444336;

	internal MemoryStream x062d8fb39fa49ad6 => x946c9f8facd5fb6b;

	internal x2025b81d9343aee4 xd94a4a4f097bd6fa => x08af7b2ab6b34dbe;

	internal x2025b81d9343aee4 x23db847ad278ab22 => x5a34d0505c78f78b;

	internal xc2daff3d6b415a63(x2025b81d9343aee4 dummyParam1, byte[] buffer2, bool dummyParam2, bool dummyParam3)
	{
		if (dummyParam2 != dummyParam3)
		{
			x0d6acb71d4570d92 = buffer2[0];
			x723bd7c019444336 = buffer2[1];
		}
		xd749382ab0504c8c.Write(buffer2, 0, buffer2.Length);
		if (x938a7a6f8392b250(buffer2))
		{
			xd7edf0363fb4b430 = 10;
		}
		if (!dummyParam1.x957a9b2db4bbd52f)
		{
			dummyParam1.x216052479859c96a(0);
		}
		x08af7b2ab6b34dbe = dummyParam1;
	}

	internal bool x938a7a6f8392b250(byte[] xd0a397c1f04ae76e)
	{
		xf27ba8b7a39be7cd = new byte[xd0a397c1f04ae76e.Length];
		for (int i = 0; i < xd0a397c1f04ae76e.Length; i++)
		{
			xf27ba8b7a39be7cd[i] = (byte)(xd0a397c1f04ae76e[i] & 0x80u);
			xf27ba8b7a39be7cd[i] |= 2;
		}
		return (xf27ba8b7a39be7cd[0] & 8) == 8;
	}

	internal bool x216052479859c96a(byte[] xd0a397c1f04ae76e, string x29c798cf917086fe)
	{
		xd0a397c1f04ae76e = Encoding.Unicode.GetBytes(x29c798cf917086fe);
		x946c9f8facd5fb6b.Write(xd0a397c1f04ae76e, 0, xd0a397c1f04ae76e.Length);
		x443c43b34bfce8f8();
		if (x946c9f8facd5fb6b.Length < 16)
		{
			return true;
		}
		return false;
	}

	internal x2025b81d9343aee4 x182c6bcb7141d988(int[] xd0a397c1f04ae76e, x2025b81d9343aee4 x0dd0dfbd7a3e4f46)
	{
		x5a34d0505c78f78b = x0dd0dfbd7a3e4f46;
		return x08af7b2ab6b34dbe;
	}

	internal void xd050c99e95ccff3a(bool xd0a397c1f04ae76e)
	{
		if (xd0a397c1f04ae76e)
		{
			x0d6acb71d4570d92 = 0;
		}
		if (xd749382ab0504c8c.Length <= 0)
		{
			return;
		}
		int num = (int)xd749382ab0504c8c.Length / 2 + 1;
		byte[] array = xd749382ab0504c8c.ToArray();
		if (x653127678ccafb25.x796372356a5001dc == 255)
		{
			x653127678ccafb25.x796372356a5001dc = 128;
		}
		int num2 = array.Length - 1;
		for (int i = 0; i < num; i++)
		{
			if (array[num2] == byte.MaxValue)
			{
				xd7edf0363fb4b430++;
			}
			if (array[num2] != (byte)x5a34d0505c78f78b.x5159913dbc6120fd[num2])
			{
				x653127678ccafb25.xd3d1e0b7118994e1 = 128;
			}
			num2--;
		}
	}

	internal void xb1b48efc4b4a3e62(string xd0a397c1f04ae76e, bool xaf63715de47092c6)
	{
		xecbfc47ffb141197 xecbfc47ffb141198 = new xecbfc47ffb141197(this);
		int[] array = xecbfc47ffb141198.x45c3b2969fd3bc0e(5u, 5u);
		if (array.Length >= 10)
		{
			x723bd7c019444336 = (byte)array[9];
		}
	}

	private void x443c43b34bfce8f8()
	{
		if (xd7edf0363fb4b430 != 10)
		{
			xd7edf0363fb4b430 += 5;
		}
		x0d6acb71d4570d92--;
	}
}
