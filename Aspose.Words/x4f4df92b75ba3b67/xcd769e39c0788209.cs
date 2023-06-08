using System;
using System.Drawing;
using System.IO;
using System.Text;
using x5794c252ba25e723;
using x6c95d9cf46ff5f25;
using xf9a9481c3f63a419;

namespace x4f4df92b75ba3b67;

internal class xcd769e39c0788209
{
	internal const float x7b0cd0435092cd3a = 32767f;

	private readonly Stream xa49cef274042e702;

	private x5babd393421dd91d x6e9a51819a170c0d;

	public Stream x9e418ad9a56d1cf5 => xa49cef274042e702;

	public xcd769e39c0788209(Stream stream)
	{
		if (stream == null)
		{
			throw new ArgumentNullException("stream");
		}
		xa49cef274042e702 = stream;
		x6e9a51819a170c0d = null;
	}

	public void x8ffe90e7fbccfccd()
	{
		xa49cef274042e702.Close();
	}

	public void xc351d479ff7ee789(byte xbcea506a33cf9111)
	{
		xa49cef274042e702.WriteByte(xbcea506a33cf9111);
	}

	public void x6210059f049f0d48(string xb41faee6912a2313)
	{
		for (int i = 0; i < xb41faee6912a2313.Length; i++)
		{
			xa49cef274042e702.WriteByte((byte)xb41faee6912a2313[i]);
		}
	}

	public void x6210059f049f0d48(string x5786461d089b10a0, string xec7dcb687e97a7d7)
	{
		x6210059f049f0d48(string.Format(x5786461d089b10a0, xec7dcb687e97a7d7));
	}

	public void x6210059f049f0d48(string x5786461d089b10a0, string xec7dcb687e97a7d7, string x6ffd1fa6ed343720)
	{
		x6210059f049f0d48(string.Format(x5786461d089b10a0, xec7dcb687e97a7d7, x6ffd1fa6ed343720));
	}

	public void x6210059f049f0d48(string x5786461d089b10a0, string xec7dcb687e97a7d7, string x6ffd1fa6ed343720, string x774d7397ced47445)
	{
		x6210059f049f0d48(string.Format(x5786461d089b10a0, xec7dcb687e97a7d7, x6ffd1fa6ed343720, x774d7397ced47445));
	}

	public void x6210059f049f0d48(byte[] x5cafa8d49ea71ea1, int xc0c4c459c6ccbd00, int x10f4d88af727adbc)
	{
		xa49cef274042e702.Write(x5cafa8d49ea71ea1, xc0c4c459c6ccbd00, x10f4d88af727adbc);
	}

	public void x241b3c2e8c3aaa86(string xb41faee6912a2313)
	{
		x6210059f049f0d48(xb41faee6912a2313);
		xe7b920de107da0c7();
	}

	public void xe7b920de107da0c7()
	{
		x6210059f049f0d48(" ");
	}

	public void x6210059f049f0d48(float xbcea506a33cf9111)
	{
		x6210059f049f0d48(x355581fe14891d82(xbcea506a33cf9111));
	}

	public void x25d0efbd7848eeb3()
	{
		x6210059f049f0d48("\r\n");
	}

	public void x25d0efbd7848eeb3(string xb41faee6912a2313)
	{
		x6210059f049f0d48(xb41faee6912a2313);
		x25d0efbd7848eeb3();
	}

	public void x25d0efbd7848eeb3(string x5786461d089b10a0, string xec7dcb687e97a7d7)
	{
		x25d0efbd7848eeb3(string.Format(x5786461d089b10a0, xec7dcb687e97a7d7));
	}

	public void x25d0efbd7848eeb3(string x5786461d089b10a0, string xec7dcb687e97a7d7, string x6ffd1fa6ed343720)
	{
		x25d0efbd7848eeb3(string.Format(x5786461d089b10a0, xec7dcb687e97a7d7, x6ffd1fa6ed343720));
	}

	public void xafb7e6f79ed43681()
	{
		x6210059f049f0d48("<<");
	}

	public void x693a8d6d020474f2()
	{
		x6210059f049f0d48(">>");
	}

	public void xa4dc0ad8886e23a2(string xc15bd84e01929885, string xbcea506a33cf9111)
	{
		if (x0d299f323d241756.x5959bccb67bbf051(xbcea506a33cf9111))
		{
			x6210059f049f0d48(xc15bd84e01929885);
			xe7b920de107da0c7();
			x6210059f049f0d48(xbcea506a33cf9111);
		}
	}

	public void xa4dc0ad8886e23a2(string xc15bd84e01929885, bool xbcea506a33cf9111)
	{
		xa4dc0ad8886e23a2(xc15bd84e01929885, x6edd579ceedb10c3(xbcea506a33cf9111));
	}

	private static string x6edd579ceedb10c3(bool xbcea506a33cf9111)
	{
		if (!xbcea506a33cf9111)
		{
			return "false";
		}
		return "true";
	}

	public void xa4dc0ad8886e23a2(string xc15bd84e01929885, bool[] xbcea506a33cf9111)
	{
		x6210059f049f0d48(xc15bd84e01929885);
		xe7b920de107da0c7();
		x4713a06fb6044742(xbcea506a33cf9111);
	}

	public void xa4dc0ad8886e23a2(string xc15bd84e01929885, float[] xbcea506a33cf9111)
	{
		x6210059f049f0d48(xc15bd84e01929885);
		xe7b920de107da0c7();
		xdfffe8e2cf9a7455(xbcea506a33cf9111);
	}

	public void xa4dc0ad8886e23a2(string xc15bd84e01929885, int[] xbcea506a33cf9111)
	{
		x6210059f049f0d48(xc15bd84e01929885);
		xe7b920de107da0c7();
		xcdbe544a109ed59e(xbcea506a33cf9111);
	}

	public void x94aba205302527e1(string xc15bd84e01929885, string xbcea506a33cf9111)
	{
		if (x0d299f323d241756.x5959bccb67bbf051(xbcea506a33cf9111))
		{
			x6210059f049f0d48(xc15bd84e01929885);
			x50f5dc167b3269a7(xbcea506a33cf9111);
		}
	}

	public void xe8d35135edabe74c(string xc15bd84e01929885, string xbcea506a33cf9111, bool xf9aaf5b23109516c)
	{
		if (!x0d299f323d241756.x5959bccb67bbf051(xbcea506a33cf9111))
		{
			return;
		}
		x6210059f049f0d48(xc15bd84e01929885);
		if (x6e9a51819a170c0d != null)
		{
			byte[] array = new byte[xbcea506a33cf9111.Length];
			Encoding.ASCII.GetBytes(xbcea506a33cf9111, 0, xbcea506a33cf9111.Length, array, 0);
			byte[] xf9a0d04800d = x6e9a51819a170c0d.x246b032720dd4c0d(array);
			x6210059f049f0d48("<");
			x6210059f049f0d48(x0d299f323d241756.x482624a13e9e9d98(xf9a0d04800d));
			x6210059f049f0d48(">");
		}
		else
		{
			x6210059f049f0d48("(");
			if (xf9aaf5b23109516c)
			{
				x66c39d9ce45dda34(xbcea506a33cf9111);
			}
			else
			{
				x6210059f049f0d48(xbcea506a33cf9111);
			}
			x6210059f049f0d48(")");
		}
	}

	public void x50f5dc167b3269a7(string xbcea506a33cf9111)
	{
		if (x6e9a51819a170c0d != null)
		{
			int num = xbcea506a33cf9111.Length * 2 + 2;
			byte[] array = new byte[num];
			array[0] = 254;
			array[1] = byte.MaxValue;
			Encoding.BigEndianUnicode.GetBytes(xbcea506a33cf9111, 0, xbcea506a33cf9111.Length, array, 2);
			byte[] xf9a0d04800d = x6e9a51819a170c0d.x246b032720dd4c0d(array);
			x6210059f049f0d48("<");
			x6210059f049f0d48(x0d299f323d241756.x482624a13e9e9d98(xf9a0d04800d));
			x6210059f049f0d48(">");
		}
		else
		{
			x6210059f049f0d48("(");
			xc351d479ff7ee789(254);
			xc351d479ff7ee789(byte.MaxValue);
			foreach (char xbcea506a33cf9112 in xbcea506a33cf9111)
			{
				x3612a596c28e1b59(xbcea506a33cf9112);
			}
			x6210059f049f0d48(")");
		}
	}

	public void xa4dc0ad8886e23a2(string xc15bd84e01929885, RectangleF xbcea506a33cf9111)
	{
		x6210059f049f0d48(xc15bd84e01929885);
		xe7b920de107da0c7();
		x6210059f049f0d48("[");
		x6210059f049f0d48(xbcea506a33cf9111.Left);
		xe7b920de107da0c7();
		x6210059f049f0d48(xbcea506a33cf9111.Top);
		xe7b920de107da0c7();
		x6210059f049f0d48(xbcea506a33cf9111.Right);
		xe7b920de107da0c7();
		x6210059f049f0d48(xbcea506a33cf9111.Bottom);
		x6210059f049f0d48("]");
	}

	public void xa4dc0ad8886e23a2(string xc15bd84e01929885, DateTime xbcea506a33cf9111)
	{
		if (!(xbcea506a33cf9111 == DateTime.MinValue))
		{
			string xbcea506a33cf9112 = $"D:{xca004f56614e2431.x94736217485981d7(xbcea506a33cf9111)}";
			xe8d35135edabe74c(xc15bd84e01929885, xbcea506a33cf9112, xf9aaf5b23109516c: true);
		}
	}

	public void xa4dc0ad8886e23a2(string xc15bd84e01929885, int xbcea506a33cf9111)
	{
		xa4dc0ad8886e23a2(xc15bd84e01929885, xca004f56614e2431.xc8ba948e0d631490(xbcea506a33cf9111));
	}

	public void xa4dc0ad8886e23a2(string xc15bd84e01929885, float xbcea506a33cf9111)
	{
		xa4dc0ad8886e23a2(xc15bd84e01929885, x355581fe14891d82(xbcea506a33cf9111));
	}

	public void xa4dc0ad8886e23a2(string xc15bd84e01929885, x54366fa5f75a02f7 xa801ccff44b0c7eb)
	{
		x6210059f049f0d48(xc15bd84e01929885);
		xe7b920de107da0c7();
		x6210059f049f0d48("[");
		xd2768134348972b1(xa801ccff44b0c7eb);
		x6210059f049f0d48("]");
	}

	public void x94d9025f53df9132(byte[] x4b696a8ebe1f485a)
	{
		x6210059f049f0d48("<");
		x6210059f049f0d48(x0d299f323d241756.x482624a13e9e9d98(x4b696a8ebe1f485a));
		x6210059f049f0d48(">");
	}

	public void x66c39d9ce45dda34(string xb41faee6912a2313)
	{
		for (int i = 0; i < xb41faee6912a2313.Length; i++)
		{
			x66c39d9ce45dda34((byte)xb41faee6912a2313[i]);
		}
	}

	public void x3612a596c28e1b59(int xbcea506a33cf9111)
	{
		x66c39d9ce45dda34((byte)(xbcea506a33cf9111 >> 8));
		x66c39d9ce45dda34((byte)xbcea506a33cf9111);
	}

	public void x66c39d9ce45dda34(byte xbcea506a33cf9111)
	{
		switch (xbcea506a33cf9111)
		{
		case 40:
		case 41:
		case 92:
			xc351d479ff7ee789(92);
			xc351d479ff7ee789(xbcea506a33cf9111);
			break;
		case 13:
			x6210059f049f0d48("\\015");
			break;
		default:
			xc351d479ff7ee789(xbcea506a33cf9111);
			break;
		}
	}

	public void x4713a06fb6044742(bool[] x0788cd5a9865fc16)
	{
		x6210059f049f0d48("[");
		for (int i = 0; i < x0788cd5a9865fc16.Length; i++)
		{
			x6210059f049f0d48(x6edd579ceedb10c3(x0788cd5a9865fc16[i]));
			if (i < x0788cd5a9865fc16.Length - 1)
			{
				xe7b920de107da0c7();
			}
		}
		x6210059f049f0d48("]");
	}

	public void xdfffe8e2cf9a7455(float[] x0788cd5a9865fc16)
	{
		x6210059f049f0d48("[");
		for (int i = 0; i < x0788cd5a9865fc16.Length; i++)
		{
			x6210059f049f0d48(x0788cd5a9865fc16[i]);
			if (i < x0788cd5a9865fc16.Length - 1)
			{
				xe7b920de107da0c7();
			}
		}
		x6210059f049f0d48("]");
	}

	public void xcdbe544a109ed59e(int[] x0788cd5a9865fc16)
	{
		x6210059f049f0d48("[");
		for (int i = 0; i < x0788cd5a9865fc16.Length; i++)
		{
			x6210059f049f0d48(xca004f56614e2431.xc8ba948e0d631490(x0788cd5a9865fc16[i]));
			if (i < x0788cd5a9865fc16.Length - 1)
			{
				xe7b920de107da0c7();
			}
		}
		x6210059f049f0d48("]");
	}

	public void xd2768134348972b1(x54366fa5f75a02f7 xa801ccff44b0c7eb)
	{
		x6210059f049f0d48(xa801ccff44b0c7eb.xb4f54e8f080ddae5);
		xe7b920de107da0c7();
		x6210059f049f0d48(xa801ccff44b0c7eb.xdde8182ef4f9942b);
		xe7b920de107da0c7();
		x6210059f049f0d48(xa801ccff44b0c7eb.xa71255917a9143ca);
		xe7b920de107da0c7();
		x6210059f049f0d48(xa801ccff44b0c7eb.xcd7062a84a8f3162);
		xe7b920de107da0c7();
		x6210059f049f0d48(xa801ccff44b0c7eb.x35fa2f38e277fdee);
		xe7b920de107da0c7();
		x6210059f049f0d48(xa801ccff44b0c7eb.x93f6f49bd53e2628);
	}

	internal void x1c638d277561c422(x5babd393421dd91d x0935153e868dee25)
	{
		x6e9a51819a170c0d = x0935153e868dee25;
	}

	internal static string x9aa2167736c37c5a(x26d9ecb4bdf0456d xbcea506a33cf9111)
	{
		return $"{x355581fe14891d82((float)xbcea506a33cf9111.xc613adc4330033f3 / 255f)} {x355581fe14891d82((float)xbcea506a33cf9111.x26463655896fd90a / 255f)} {x355581fe14891d82((float)xbcea506a33cf9111.x8e8f6cc6a0756b05 / 255f)}";
	}

	internal static string x33f484a2a7742f9e(x26d9ecb4bdf0456d xbcea506a33cf9111)
	{
		double num = (0.3 * (double)xbcea506a33cf9111.xc613adc4330033f3 + 0.59 * (double)xbcea506a33cf9111.x26463655896fd90a + 0.11 * (double)xbcea506a33cf9111.x8e8f6cc6a0756b05) / 255.0;
		return $"{x355581fe14891d82((float)num)}";
	}

	internal static string x355581fe14891d82(float xbcea506a33cf9111)
	{
		return xca004f56614e2431.x05bb6454cb109fa9(xbcea506a33cf9111);
	}

	internal static int x56f8e216f636bee6(float x08db3aeabb253cb1, float x1e218ceaee1bb583)
	{
		return (int)(Math.Max(Math.Abs(x08db3aeabb253cb1), Math.Abs(x1e218ceaee1bb583)) / 32767f) + 1;
	}
}
