using System;
using System.IO;
using System.Text;
using x13f1efc79617a47b;

namespace x2182451cabb5c30d;

internal class xc2ede0fa9eb3936b : xa373bfe0feb3bdb4
{
	private enum xffb3238a8fd59aa7
	{
		x4d0b9d4447ba7566,
		x08c5d9f4b0653c8d,
		xab1d7d764c44c6c5
	}

	private xffb3238a8fd59aa7 x9b529da35d1032aa;

	private x03f56b37a0050a82 x2b9c3f93d8888ad2;

	private readonly x03f56b37a0050a82 x6381445d0f5e75e5 = new x03f56b37a0050a82();

	private x03f56b37a0050a82 xa1ec1dcbe989fc9c;

	internal override x03f56b37a0050a82 xd420ac3415caa02b => x2b9c3f93d8888ad2;

	internal xc2ede0fa9eb3936b(Stream stream)
		: base(stream)
	{
	}

	internal xc2ede0fa9eb3936b(string s)
		: this(x077607ab3e81f586(s, 1252))
	{
	}

	internal static Stream x077607ab3e81f586(string xe4115acdf4fbfccc, int xc1690d3515e1ed6c)
	{
		Encoding encoding = Encoding.GetEncoding(xc1690d3515e1ed6c);
		return new MemoryStream(encoding.GetBytes(xe4115acdf4fbfccc));
	}

	internal override void xd3d72812bb7aaf65()
	{
		switch (x9b529da35d1032aa)
		{
		case xffb3238a8fd59aa7.x4d0b9d4447ba7566:
		case xffb3238a8fd59aa7.x08c5d9f4b0653c8d:
			x29ae36937470d5c4();
			break;
		case xffb3238a8fd59aa7.xab1d7d764c44c6c5:
			x2b9c3f93d8888ad2 = xa1ec1dcbe989fc9c;
			xa1ec1dcbe989fc9c = null;
			x9b529da35d1032aa = xffb3238a8fd59aa7.x4d0b9d4447ba7566;
			break;
		default:
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("bmbehniebnpebngfpmnfenegimlghhchhmjhfmaipkhiploinkfjdhmj", 393888108)));
		}
	}

	private void x29ae36937470d5c4()
	{
		while (true)
		{
			base.xd3d72812bb7aaf65();
			x2b9c3f93d8888ad2 = base.xd420ac3415caa02b;
			if (x2b9c3f93d8888ad2.x77dc43988eaceb1c != xe47a4d4f9d1aa906.x08c5d9f4b0653c8d)
			{
				break;
			}
			xbd6083b329527c4e();
		}
		x2abe3e8dd67a3129();
	}

	private void xbd6083b329527c4e()
	{
		switch (x9b529da35d1032aa)
		{
		case xffb3238a8fd59aa7.x4d0b9d4447ba7566:
			x6381445d0f5e75e5.x74f5a1ef3906e23c(xe47a4d4f9d1aa906.x08c5d9f4b0653c8d);
			x6381445d0f5e75e5.xd373314879c5ac75(x2b9c3f93d8888ad2.x9f1a6a3451a38d10());
			x9b529da35d1032aa = xffb3238a8fd59aa7.x08c5d9f4b0653c8d;
			break;
		case xffb3238a8fd59aa7.x08c5d9f4b0653c8d:
			x6381445d0f5e75e5.xd373314879c5ac75(x2b9c3f93d8888ad2.x9f1a6a3451a38d10());
			break;
		default:
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("jmpjpngkdnnkdoelinllkmcmfmjmdnanbmhnnlonghfogmmoemdpokkpolbamkiachpa", 1028169588)));
		}
	}

	private void x2abe3e8dd67a3129()
	{
		switch (x9b529da35d1032aa)
		{
		case xffb3238a8fd59aa7.x08c5d9f4b0653c8d:
			xa1ec1dcbe989fc9c = x2b9c3f93d8888ad2;
			x2b9c3f93d8888ad2 = x6381445d0f5e75e5;
			x9b529da35d1032aa = xffb3238a8fd59aa7.xab1d7d764c44c6c5;
			break;
		default:
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("onnhepeiioliipcjnojjpnakknhkiookgnflcnmllidmlnkmjnbndmindnpnbmgohino", 1390378377)));
		case xffb3238a8fd59aa7.x4d0b9d4447ba7566:
			break;
		}
	}
}
