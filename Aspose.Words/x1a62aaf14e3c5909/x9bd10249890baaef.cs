using System;
using System.IO;
using System.Text;
using x13f1efc79617a47b;
using x6c95d9cf46ff5f25;
using xa604c4d210ae0581;

namespace x1a62aaf14e3c5909;

internal class x9bd10249890baaef : x47d90533fe3ed43a
{
	private string x8db51f27cf6e4cf1;

	private string xc4b2a12ce9be39d4;

	private string xbe39036341e55b02;

	private static readonly byte[] x2ed1835501e68b8a = new byte[16]
	{
		208, 201, 234, 121, 249, 186, 206, 17, 140, 130,
		0, 170, 0, 75, 169, 11
	};

	private static readonly byte[] xd9df057cde4ef9c5 = new byte[16]
	{
		224, 201, 234, 121, 249, 186, 206, 17, 140, 130,
		0, 170, 0, 75, 169, 11
	};

	private static readonly byte[] xccb0e70af441144e = new byte[16]
	{
		3, 3, 0, 0, 0, 0, 0, 0, 192, 0,
		0, 0, 0, 0, 0, 70
	};

	internal string x1d5cfa3bffdfb042 => x8db51f27cf6e4cf1;

	internal string x2141cbc5929f5173 => xc4b2a12ce9be39d4;

	internal string x42f4c234c9358072 => xbe39036341e55b02;

	internal x9bd10249890baaef(int id, int dataLength)
		: base(id, dataLength)
	{
	}

	internal x9bd10249890baaef(int id, string address, string subAddress, string target)
		: base(id, 0)
	{
		x8db51f27cf6e4cf1 = address;
		xc4b2a12ce9be39d4 = subAddress;
		xbe39036341e55b02 = target;
		base.x3719d1992877f6f9 = x951df08499971314();
	}

	private int x951df08499971314()
	{
		MemoryStream memoryStream = new MemoryStream();
		BinaryWriter xbdfb620b7167944b = new BinaryWriter(memoryStream);
		xc26afd5362f5c1ec(xbdfb620b7167944b);
		return (int)memoryStream.Position;
	}

	internal override void x855150d0664edd8d(BinaryReader xe134235b3526fa75)
	{
		int num = (int)xe134235b3526fa75.BaseStream.Position;
		try
		{
			xffa8c9a88ffd6b71(xe134235b3526fa75);
		}
		finally
		{
			int num2 = num + base.x3719d1992877f6f9;
			xe134235b3526fa75.BaseStream.Position = num2;
		}
	}

	private void xffa8c9a88ffd6b71(BinaryReader xe134235b3526fa75)
	{
		if (base.x3719d1992877f6f9 == 0)
		{
			return;
		}
		xe134235b3526fa75.ReadBytes(16);
		int num = xe134235b3526fa75.ReadInt32();
		if (num != 2)
		{
			return;
		}
		x31aea4f873b7eff9 x31aea4f873b7eff10 = (x31aea4f873b7eff9)xe134235b3526fa75.ReadInt32();
		if ((x31aea4f873b7eff10 & x31aea4f873b7eff9.xd83422eec2a31138) != 0)
		{
			x93b05c1ad709a695.xb22524c2ced95a77(xe134235b3526fa75);
		}
		if ((x31aea4f873b7eff10 & x31aea4f873b7eff9.x98bbb1fe2dc7b9f2) != 0)
		{
			xbe39036341e55b02 = x93b05c1ad709a695.xb22524c2ced95a77(xe134235b3526fa75);
		}
		if ((x31aea4f873b7eff10 & x31aea4f873b7eff9.x7eab10b6da296a7e) != 0)
		{
			if ((x31aea4f873b7eff10 & x31aea4f873b7eff9.x6545a0cdf3bb812a) != 0)
			{
				x8db51f27cf6e4cf1 = x93b05c1ad709a695.xb22524c2ced95a77(xe134235b3526fa75);
			}
			else
			{
				byte[] array = xe134235b3526fa75.ReadBytes(16);
				if (xcd4bd3abd72ff2da.xf920f15ca6067ada(array, xd9df057cde4ef9c5))
				{
					x8db51f27cf6e4cf1 = x064f79e2e62c8743(xe134235b3526fa75);
				}
				else
				{
					if (!xcd4bd3abd72ff2da.xf920f15ca6067ada(array, xccb0e70af441144e))
					{
						throw new InvalidOperationException(string.Format(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("cjnmikencklnckcoakjofkapjjhpieopnifaljmapidbbikblibcciicmhpcohgdihndkceengledhcfdhjflgagmfhgmgogdcfhcbmhmddilfkihfbjpeijoepjfegkpenkkpdloblljccmkbjmcbanlognbdonidfocolokddpmojpgdbaeoha", 1840041277)), new Guid(array).ToString()));
					}
					x8db51f27cf6e4cf1 = x1f3b0c06ced33df3(xe134235b3526fa75);
				}
			}
		}
		if ((x31aea4f873b7eff10 & x31aea4f873b7eff9.x934235a09a29793c) != 0)
		{
			xc4b2a12ce9be39d4 = x93b05c1ad709a695.xb22524c2ced95a77(xe134235b3526fa75);
		}
		if ((x31aea4f873b7eff10 & x31aea4f873b7eff9.x764248ad95e58bdc) != 0)
		{
			xe134235b3526fa75.ReadBytes(16);
		}
		if ((x31aea4f873b7eff10 & x31aea4f873b7eff9.x4d66b0d02ea21fab) != 0)
		{
			xe134235b3526fa75.ReadBytes(8);
		}
	}

	private static string x064f79e2e62c8743(BinaryReader xe134235b3526fa75)
	{
		string text = x93b05c1ad709a695.xf30570713d4bb9fe(xe134235b3526fa75);
		int num = text.IndexOf('\0');
		if (num >= 0)
		{
			return text.Substring(0, num);
		}
		return text;
	}

	private static string x1f3b0c06ced33df3(BinaryReader xe134235b3526fa75)
	{
		xe134235b3526fa75.ReadUInt16();
		string result = x93b05c1ad709a695.xc2f73d64c3b147ae(xe134235b3526fa75);
		xe134235b3526fa75.ReadUInt16();
		xe134235b3526fa75.ReadUInt16();
		for (int i = 0; i < 5; i++)
		{
			xe134235b3526fa75.ReadInt32();
		}
		int num = xe134235b3526fa75.ReadInt32();
		if (num > 0)
		{
			int count = xe134235b3526fa75.ReadInt32();
			xe134235b3526fa75.ReadInt16();
			byte[] bytes = xe134235b3526fa75.ReadBytes(count);
			return Encoding.Unicode.GetString(bytes);
		}
		return result;
	}

	internal override void xc26afd5362f5c1ec(BinaryWriter xbdfb620b7167944b)
	{
		xbdfb620b7167944b.Write(x2ed1835501e68b8a);
		xbdfb620b7167944b.Write(2);
		int num = (int)xbdfb620b7167944b.BaseStream.Position;
		int num2 = 0;
		xbdfb620b7167944b.Write(num2);
		if (x0d299f323d241756.x5959bccb67bbf051(xbe39036341e55b02))
		{
			x93b05c1ad709a695.x81fe2fd2de403f38(xbe39036341e55b02, xbdfb620b7167944b);
			num2 |= 0x80;
		}
		if (x0d299f323d241756.x5959bccb67bbf051(x8db51f27cf6e4cf1))
		{
			xbdfb620b7167944b.Write(xd9df057cde4ef9c5);
			x93b05c1ad709a695.x6cb8814ac91c34fd(x8db51f27cf6e4cf1, xbdfb620b7167944b);
			num2 |= 1;
			num2 |= 2;
		}
		if (x0d299f323d241756.x5959bccb67bbf051(xc4b2a12ce9be39d4))
		{
			x93b05c1ad709a695.x81fe2fd2de403f38(xc4b2a12ce9be39d4, xbdfb620b7167944b);
			num2 |= 8;
		}
		int num3 = (int)xbdfb620b7167944b.BaseStream.Position;
		xbdfb620b7167944b.BaseStream.Position = num;
		xbdfb620b7167944b.Write(num2);
		xbdfb620b7167944b.BaseStream.Position = num3;
	}
}
