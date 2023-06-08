using System.IO;
using System.Text;
using Aspose;

namespace xe8730a664ff488a4;

[JavaDelete("Using java zip instead.")]
internal class x71e71339e29fbf2b
{
	public static int x708a60ec8cfa708b(int x78b0a0bc28459535, int x4b8b317913377903)
	{
		return (int)((uint)x78b0a0bc28459535 >> x4b8b317913377903);
	}

	public static long x708a60ec8cfa708b(long x78b0a0bc28459535, int x4b8b317913377903)
	{
		return (long)((ulong)x78b0a0bc28459535 >> x4b8b317913377903);
	}

	public static int xc58c2d1fb1b787ee(TextReader x6ef11962609eb469, byte[] x11d58b056c032b03, int x10aaa7cdfa38f254, int x10f4d88af727adbc)
	{
		if (x11d58b056c032b03.Length == 0)
		{
			return 0;
		}
		char[] array = new char[x11d58b056c032b03.Length];
		int num = x6ef11962609eb469.Read(array, x10aaa7cdfa38f254, x10f4d88af727adbc);
		if (num == 0)
		{
			return -1;
		}
		for (int i = x10aaa7cdfa38f254; i < x10aaa7cdfa38f254 + num; i++)
		{
			x11d58b056c032b03[i] = (byte)array[i];
		}
		return num;
	}

	internal static byte[] x2797b998ab68f4ab(string x27cc23924cff08a3)
	{
		return Encoding.UTF8.GetBytes(x27cc23924cff08a3);
	}

	internal static char[] xb0d64c5e913a48c0(byte[] xa7ea9ccafe3a3efa)
	{
		return Encoding.UTF8.GetChars(xa7ea9ccafe3a3efa);
	}
}
