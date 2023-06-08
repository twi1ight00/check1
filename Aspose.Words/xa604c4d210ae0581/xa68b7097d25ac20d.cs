using System.IO;
using Aspose.Words;
using Aspose.Words.Fonts;
using x28925c9b27b37a46;
using x4b4f8b01ec4cb4b2;
using x6c95d9cf46ff5f25;

namespace xa604c4d210ae0581;

internal class xa68b7097d25ac20d
{
	private const string x24fe1274033c7866 = "Times New Roman";

	private static readonly byte[] x0c22535778bd4b01 = new byte[10];

	private static readonly byte[] xe1e1d98e2fe045ae = new byte[24];

	private xa68b7097d25ac20d()
	{
	}

	internal static void x06b0e25aa6ad68a9(FontInfoCollection x4ea5c100b613db8e, x8aeace2bf92692ab xf0c8411938a86cbf, BinaryReader xf0c2e784061f7f2c, BinaryReader x994e3cc0f99dd2dc, IWarningCallback x57fef5933b41d0c2)
	{
		xf0c2e784061f7f2c.BaseStream.Position = xf0c8411938a86cbf.x955a03f821588c52.x4eeef1441cb1f57f.xe53f0e68147463d1;
		xe4302869fd561934(x4ea5c100b613db8e, xf0c2e784061f7f2c, xf0c8411938a86cbf.x955a03f821588c52.x4eeef1441cb1f57f.x04c290dc4d04369c, x57fef5933b41d0c2);
		xf0c2e784061f7f2c.BaseStream.Position = xf0c8411938a86cbf.x955a03f821588c52.xe1603a253022f5eb.xe53f0e68147463d1;
		x976ddd849da38d74(x4ea5c100b613db8e, xf0c2e784061f7f2c, xf0c8411938a86cbf.x955a03f821588c52.xe1603a253022f5eb.x04c290dc4d04369c, x994e3cc0f99dd2dc);
	}

	private static void xe4302869fd561934(FontInfoCollection x4ea5c100b613db8e, BinaryReader xf0c2e784061f7f2c, int x7f6c4e8aaf0db1ab, IWarningCallback x57fef5933b41d0c2)
	{
		if (x7f6c4e8aaf0db1ab != 0)
		{
			int num = xf0c2e784061f7f2c.ReadInt32();
			for (int i = 0; i < num; i++)
			{
				x4ea5c100b613db8e.xd5da23b762ce52a2(x2f76136c0743bc5e(xf0c2e784061f7f2c, x57fef5933b41d0c2));
			}
		}
	}

	private static void x976ddd849da38d74(FontInfoCollection x4ea5c100b613db8e, BinaryReader xf0c2e784061f7f2c, int x7f6c4e8aaf0db1ab, BinaryReader x994e3cc0f99dd2dc)
	{
		if (x7f6c4e8aaf0db1ab != 0)
		{
			xf0c2e784061f7f2c.ReadInt16();
			int num = xf0c2e784061f7f2c.ReadInt16();
			xf0c2e784061f7f2c.ReadInt32();
			xf0c2e784061f7f2c.ReadInt16();
			for (int i = 0; i < num; i++)
			{
				int num2 = xf0c2e784061f7f2c.ReadInt32();
				int index = xf0c2e784061f7f2c.ReadInt16();
				EmbeddedFontStyle x768946a = (EmbeddedFontStyle)(xf0c2e784061f7f2c.ReadInt16() & 3);
				bool xa41bb3cedcce769d = xf0c2e784061f7f2c.ReadUInt32() != uint.MaxValue;
				x994e3cc0f99dd2dc.BaseStream.Position = num2;
				int count = x994e3cc0f99dd2dc.ReadInt32();
				x994e3cc0f99dd2dc.BaseStream.Position = num2;
				x4ea5c100b613db8e[index].x88b4954c294baf8f(x994e3cc0f99dd2dc.ReadBytes(count), EmbeddedFontFormat.EmbeddedOpenType, x768946a, xa41bb3cedcce769d);
			}
		}
	}

	internal static void x6210059f049f0d48(FontInfoCollection x4ea5c100b613db8e, x8aeace2bf92692ab xf0c8411938a86cbf, BinaryWriter xa105646ef35ed10a, BinaryWriter x6db9c3d7ab3266a4)
	{
		xf0c8411938a86cbf.x955a03f821588c52.x4eeef1441cb1f57f.xe53f0e68147463d1 = (int)xa105646ef35ed10a.BaseStream.Position;
		xf0c8411938a86cbf.x955a03f821588c52.x4eeef1441cb1f57f.x04c290dc4d04369c = xfbe110e3dc77533d(x4ea5c100b613db8e, xa105646ef35ed10a);
		xf0c8411938a86cbf.x955a03f821588c52.xe1603a253022f5eb.xe53f0e68147463d1 = (int)xa105646ef35ed10a.BaseStream.Position;
		xf0c8411938a86cbf.x955a03f821588c52.xe1603a253022f5eb.x04c290dc4d04369c = x74e3273210558a30(x4ea5c100b613db8e, xa105646ef35ed10a, x6db9c3d7ab3266a4);
	}

	private static int xfbe110e3dc77533d(FontInfoCollection x4ea5c100b613db8e, BinaryWriter xa105646ef35ed10a)
	{
		int num = (int)xa105646ef35ed10a.BaseStream.Position;
		xa105646ef35ed10a.Write(x4ea5c100b613db8e.Count);
		foreach (FontInfo item in x4ea5c100b613db8e)
		{
			x91fcb0533d14f71a(item, xa105646ef35ed10a);
		}
		return (int)xa105646ef35ed10a.BaseStream.Position - num;
	}

	private static int x74e3273210558a30(FontInfoCollection x4ea5c100b613db8e, BinaryWriter xa105646ef35ed10a, BinaryWriter x6db9c3d7ab3266a4)
	{
		int num = (int)xa105646ef35ed10a.BaseStream.Position;
		xa105646ef35ed10a.Write((short)0);
		xa105646ef35ed10a.Write((short)xc2ae733c9e58c391(x4ea5c100b613db8e));
		xa105646ef35ed10a.Write(64);
		xa105646ef35ed10a.Write((short)26);
		int num2 = 0;
		for (int i = 0; i < x4ea5c100b613db8e.Count; i++)
		{
			x393d198b88cf5ed5[] array = x4ea5c100b613db8e[i].xf24d2f6e3cbd9dd5(EmbeddedFontFormat.EmbeddedOpenType);
			if (array == null)
			{
				continue;
			}
			x393d198b88cf5ed5[] array2 = array;
			foreach (x393d198b88cf5ed5 x393d198b88cf5ed in array2)
			{
				if (x393d198b88cf5ed != null)
				{
					x682e95b934c8a7ad(x393d198b88cf5ed, i, num2, xa105646ef35ed10a, x6db9c3d7ab3266a4);
					num2++;
				}
			}
		}
		return (int)xa105646ef35ed10a.BaseStream.Position - num;
	}

	private static void x682e95b934c8a7ad(x393d198b88cf5ed5 x18c8cfcf0ea5f3c7, int x3d2dde7c72e020a4, int x194361882453860e, BinaryWriter xa105646ef35ed10a, BinaryWriter x6db9c3d7ab3266a4)
	{
		xa105646ef35ed10a.Write((int)x6db9c3d7ab3266a4.BaseStream.Position);
		xa105646ef35ed10a.Write((short)x3d2dde7c72e020a4);
		xa105646ef35ed10a.Write((short)x18c8cfcf0ea5f3c7.xfe2178c1f916f36c);
		xa105646ef35ed10a.Write(x18c8cfcf0ea5f3c7.xf485d4dac21a6985 ? ((uint)x194361882453860e) : uint.MaxValue);
		x6db9c3d7ab3266a4.Write(x18c8cfcf0ea5f3c7.x6b73aa01aa019d3a);
	}

	private static int xc2ae733c9e58c391(FontInfoCollection x4ea5c100b613db8e)
	{
		int num = 0;
		foreach (FontInfo item in x4ea5c100b613db8e)
		{
			x393d198b88cf5ed5[] array = item.xf24d2f6e3cbd9dd5(EmbeddedFontFormat.EmbeddedOpenType);
			if (array == null)
			{
				continue;
			}
			x393d198b88cf5ed5[] array2 = array;
			foreach (x393d198b88cf5ed5 x393d198b88cf5ed in array2)
			{
				if (x393d198b88cf5ed != null)
				{
					num++;
				}
			}
		}
		return num;
	}

	private static FontInfo x2f76136c0743bc5e(BinaryReader xf0c2e784061f7f2c, IWarningCallback x57fef5933b41d0c2)
	{
		FontInfo fontInfo = new FontInfo();
		int num = (int)xf0c2e784061f7f2c.BaseStream.Position;
		int num2 = xf0c2e784061f7f2c.ReadByte();
		int num3 = xf0c2e784061f7f2c.ReadByte();
		fontInfo.Pitch = (FontPitch)(num3 & 3);
		fontInfo.IsTrueType = (num3 & 4) != 0;
		fontInfo.Family = (FontFamily)((num3 & 0x70) >> 4);
		fontInfo.x64e2a404bc6b1659 = xf0c2e784061f7f2c.ReadInt16();
		fontInfo.Charset = xf0c2e784061f7f2c.ReadByte();
		xf0c2e784061f7f2c.ReadByte();
		fontInfo.Panose = new byte[10];
		xf0c2e784061f7f2c.Read(fontInfo.Panose, 0, fontInfo.Panose.Length);
		fontInfo.x9df4cc3a14431dcc = new byte[24];
		xf0c2e784061f7f2c.Read(fontInfo.x9df4cc3a14431dcc, 0, fontInfo.x9df4cc3a14431dcc.Length);
		int num4 = (int)xf0c2e784061f7f2c.BaseStream.Position - num;
		string text;
		if (num2 > 41)
		{
			int xdd29aa438e247cc = num2 - num4 + 1;
			text = x93b05c1ad709a695.x79739b9c4ddc2495(xf0c2e784061f7f2c, xdd29aa438e247cc);
		}
		else
		{
			text = "";
		}
		int num5 = text.IndexOf('\0');
		if (num5 < 0)
		{
			if (!x0d299f323d241756.x5959bccb67bbf051(text))
			{
				x98b0e09ccece0a5a.x3dc950453374051a(x57fef5933b41d0c2, WarningSource.Doc, "Invalid font name, replaced with '{0}'.", "Times New Roman");
				text = "Times New Roman";
			}
			fontInfo.x54f99ef1e934e59c(text);
		}
		else
		{
			string text2 = text.Substring(0, num5);
			string text3 = text.Substring(num5 + 1);
			if (!x0d299f323d241756.x5959bccb67bbf051(text2))
			{
				x98b0e09ccece0a5a.x3dc950453374051a(x57fef5933b41d0c2, WarningSource.Doc, "Invalid font name, replaced with '{0}'.", x0d299f323d241756.x5959bccb67bbf051(text3) ? text3 : "Times New Roman");
				text2 = (x0d299f323d241756.x5959bccb67bbf051(text3) ? text3 : "Times New Roman");
			}
			fontInfo.x54f99ef1e934e59c(text2);
			fontInfo.AltName = text3;
		}
		return fontInfo;
	}

	private static void x91fcb0533d14f71a(FontInfo xfa5e135bae569bda, BinaryWriter xa105646ef35ed10a)
	{
		int num = (int)xa105646ef35ed10a.BaseStream.Position;
		xa105646ef35ed10a.Write((byte)0);
		int num2 = 0;
		num2 |= (int)xfa5e135bae569bda.Pitch;
		num2 |= (xfa5e135bae569bda.IsTrueType ? 4 : 0);
		num2 |= (int)xfa5e135bae569bda.Family << 4;
		xa105646ef35ed10a.Write((byte)num2);
		xa105646ef35ed10a.Write((short)xfa5e135bae569bda.x64e2a404bc6b1659);
		xa105646ef35ed10a.Write((byte)xfa5e135bae569bda.Charset);
		int num3 = (x0d299f323d241756.x5959bccb67bbf051(xfa5e135bae569bda.AltName) ? (xfa5e135bae569bda.Name.Length + 1) : 0);
		xa105646ef35ed10a.Write((byte)num3);
		xa105646ef35ed10a.Write((xfa5e135bae569bda.Panose != null) ? xfa5e135bae569bda.Panose : x0c22535778bd4b01);
		xa105646ef35ed10a.Write((xfa5e135bae569bda.x9df4cc3a14431dcc != null) ? xfa5e135bae569bda.x9df4cc3a14431dcc : xe1e1d98e2fe045ae);
		x93b05c1ad709a695.x535736a60cc73a33(xfa5e135bae569bda.Name, xa105646ef35ed10a);
		if (x0d299f323d241756.x5959bccb67bbf051(xfa5e135bae569bda.AltName))
		{
			x93b05c1ad709a695.x535736a60cc73a33(xfa5e135bae569bda.AltName, xa105646ef35ed10a);
		}
		int num4 = (int)xa105646ef35ed10a.BaseStream.Position;
		int num5 = num4 - num - 1;
		xa105646ef35ed10a.BaseStream.Seek(num, SeekOrigin.Begin);
		xa105646ef35ed10a.Write((byte)num5);
		xa105646ef35ed10a.BaseStream.Seek(num4, SeekOrigin.Begin);
	}
}
