using System;
using System.Collections.Specialized;
using System.IO;
using System.Text;
using Aspose.Words.Settings;
using x6c95d9cf46ff5f25;
using x79578da6a8a3ae37;
using xa604c4d210ae0581;
using xda075892eccab2ad;

namespace x16f9a31f749b8bb1;

internal class xc74d3b8b1891696d
{
	private BinaryReader x7450cc1e48712286;

	private x8aeace2bf92692ab xa6172040dc8d693f;

	private xb4278d25e0406614 x0055d03d8785e4bd;

	private MailMergeSettings x5dbb567a34673893;

	internal void x06b0e25aa6ad68a9(BinaryReader xf0c2e784061f7f2c, x8aeace2bf92692ab xf0c8411938a86cbf, xb4278d25e0406614 xec232eb93dd022a7, MailMergeSettings x9fc6d11f73f7c086)
	{
		x7450cc1e48712286 = xf0c2e784061f7f2c;
		xa6172040dc8d693f = xf0c8411938a86cbf;
		x0055d03d8785e4bd = xec232eb93dd022a7;
		x5dbb567a34673893 = x9fc6d11f73f7c086;
		if (xa6172040dc8d693f.x4605e55a1901024b.xeb0a4e0d8f6b5ba3.x04c290dc4d04369c > 0)
		{
			x5670ee82acf7039b(xa6172040dc8d693f.x4605e55a1901024b.xeb0a4e0d8f6b5ba3);
		}
		else if (xa6172040dc8d693f.x955a03f821588c52.xa0098896c0344197.x04c290dc4d04369c > 0)
		{
			x5670ee82acf7039b(xa6172040dc8d693f.x955a03f821588c52.xa0098896c0344197);
		}
		x9c538cea5cb30881();
	}

	private void x5670ee82acf7039b(x3fdb33c580a0bef3 x2e35a61e0b396eec)
	{
		int xe53f0e68147463d = x2e35a61e0b396eec.xe53f0e68147463d1;
		int x04c290dc4d04369c = x2e35a61e0b396eec.x04c290dc4d04369c;
		if (x04c290dc4d04369c == 0)
		{
			return;
		}
		x7450cc1e48712286.BaseStream.Position = xe53f0e68147463d;
		int num = xe53f0e68147463d + x04c290dc4d04369c;
		int num2 = x7450cc1e48712286.ReadInt16();
		bool flag = (num2 & 2) != 0;
		bool flag2 = (num2 & 4) != 0;
		x5dbb567a34673893.MainDocumentType = (MailMergeMainDocumentType)((num2 & 0x78) >> 3);
		x5dbb567a34673893.DoNotSupressBlankLines = (num2 & 0x400) == 0;
		x5dbb567a34673893.Destination = (MailMergeDestination)((num2 & 0xE000) >> 13);
		int num3 = x7450cc1e48712286.ReadByte();
		int num4 = x7450cc1e48712286.ReadByte();
		x5dbb567a34673893.ActiveRecord = x7450cc1e48712286.ReadInt32();
		x245cb6bf933aaf97[] array = new x245cb6bf933aaf97[2]
		{
			new x245cb6bf933aaf97(x7450cc1e48712286),
			new x245cb6bf933aaf97(x7450cc1e48712286)
		};
		if (flag)
		{
			x245cb6bf933aaf97 x245cb6bf933aaf = array[num4];
			x5dbb567a34673893.DataType = x245cb6bf933aaf.xabdd4c8efb3f2050;
			x5dbb567a34673893.DataSource = x0055d03d8785e4bd.x72bca3f242b46d61(x245cb6bf933aaf.x6f148b4649a10af0);
			x5dbb567a34673893.LinkToQuery = x245cb6bf933aaf.x3289a7dac77cb243;
			if (x5dbb567a34673893.DataType == MailMergeDataType.TextFile)
			{
				x5dbb567a34673893.x7bcd35f5ead5b5bf = x245cb6bf933aaf.x32158491f5e28d99;
				x5dbb567a34673893.xf8d8395bc4a715ea = x245cb6bf933aaf.xa0c0ceaacfcd0c83;
			}
		}
		if (flag2)
		{
			x245cb6bf933aaf97 x245cb6bf933aaf2 = array[num3];
			x5dbb567a34673893.HeaderSource = x0055d03d8785e4bd.x72bca3f242b46d61(x245cb6bf933aaf2.x6f148b4649a10af0);
			if (x5dbb567a34673893.DataType == MailMergeDataType.TextFile)
			{
				x5dbb567a34673893.x09a3beda84a8a23c = x245cb6bf933aaf2.x32158491f5e28d99;
				x5dbb567a34673893.x20f69eabf273199b = x245cb6bf933aaf2.xa0c0ceaacfcd0c83;
			}
		}
		int num5 = x7450cc1e48712286.ReadInt16();
		x5dbb567a34673893.ViewMergedData = (num5 & 1) != 0;
		x5dbb567a34673893.CheckErrors = (MailMergeCheckErrors)(((num5 & 6) >> 1) + 1);
		bool flag3 = (num5 & 0x10) != 0;
		bool flag4 = (num5 & 0x80) != 0;
		x5dbb567a34673893.MailAsAttachment = !flag3 && !flag4;
		int num6 = x7450cc1e48712286.ReadInt16();
		int xdd29aa438e247cc = x7450cc1e48712286.ReadInt16();
		x5dbb567a34673893.Query = x93b05c1ad709a695.x79739b9c4ddc2495(x7450cc1e48712286, xdd29aa438e247cc);
		if (num6 != 0)
		{
			StringCollection stringCollection = new StringCollection();
			int x7f6c4e8aaf0db1ab = num - (int)x7450cc1e48712286.BaseStream.Position;
			xaf807f6784ee1743.x06b0e25aa6ad68a9(x7450cc1e48712286, (int)x7450cc1e48712286.BaseStream.Position, x7f6c4e8aaf0db1ab, stringCollection);
			x5dbb567a34673893.ConnectString = stringCollection[0];
			_ = stringCollection[1];
			x5dbb567a34673893.MailSubject = stringCollection[2];
			x5dbb567a34673893.AddressFieldName = stringCollection[3];
		}
		if (x7450cc1e48712286.BaseStream.Position < num)
		{
			int mainDocumentType = x7450cc1e48712286.ReadInt32();
			x5dbb567a34673893.MainDocumentType = (MailMergeMainDocumentType)mainDocumentType;
		}
	}

	private void x9c538cea5cb30881()
	{
		if (xa6172040dc8d693f.x4605e55a1901024b.x6633cfa1b4898c8b.x04c290dc4d04369c != 0)
		{
			x7450cc1e48712286.BaseStream.Position = xa6172040dc8d693f.x4605e55a1901024b.x6633cfa1b4898c8b.xe53f0e68147463d1;
			int num = xa6172040dc8d693f.x4605e55a1901024b.x6633cfa1b4898c8b.xe53f0e68147463d1 + xa6172040dc8d693f.x4605e55a1901024b.x6633cfa1b4898c8b.x04c290dc4d04369c;
			while (x7450cc1e48712286.BaseStream.Position < num)
			{
				x85f345192dcd0145();
			}
		}
	}

	private void x85f345192dcd0145()
	{
		xfdb75d2da5baf247 xfdb75d2da5baf = (xfdb75d2da5baf247)x7450cc1e48712286.ReadInt16();
		int num = x7450cc1e48712286.ReadInt16();
		if (num == -1)
		{
			num = x7450cc1e48712286.ReadInt32();
		}
		_ = x7450cc1e48712286.BaseStream.Position;
		Odso odso = x5dbb567a34673893.Odso;
		switch (xfdb75d2da5baf)
		{
		case xfdb75d2da5baf247.x747ffe8b34fa9e43:
			odso.UdlConnectString = x00520580a1771bfe(num);
			break;
		case xfdb75d2da5baf247.x0e167222a6700ac9:
			odso.TableName = x00520580a1771bfe(num);
			break;
		case xfdb75d2da5baf247.x086f935af5565717:
			odso.DataSource = x00520580a1771bfe(num);
			break;
		case xfdb75d2da5baf247.xaeeb839b0bdea777:
			odso.DataSourceType = (OdsoDataSourceType)x7450cc1e48712286.ReadInt32();
			break;
		case xfdb75d2da5baf247.x36190d1079f287e4:
			odso.ColumnDelimiter = (char)x7450cc1e48712286.ReadInt16();
			break;
		case xfdb75d2da5baf247.xa7208c027f3b875a:
			odso.FirstRowContainsColumnNames = x7450cc1e48712286.ReadInt32() != 0;
			break;
		case xfdb75d2da5baf247.xb16033d14467fafc:
			x2f172bf524fcbb8a(num);
			break;
		case xfdb75d2da5baf247.xa5be5cfd9c5c8ff7:
			xbea1194266fd2950(num);
			break;
		default:
			x7450cc1e48712286.ReadBytes(num);
			break;
		}
	}

	private void x2f172bf524fcbb8a(int x961016a387451f05)
	{
		_ = x7450cc1e48712286.BaseStream.Position;
		x7450cc1e48712286.ReadInt16();
		x7450cc1e48712286.ReadInt16();
		int num = x7450cc1e48712286.ReadInt32();
		x7450cc1e48712286.ReadInt16();
		int num2 = x7450cc1e48712286.ReadInt16();
		if (num2 == -1)
		{
			num2 = x7450cc1e48712286.ReadInt32();
		}
		for (int i = 0; i < num; i++)
		{
			x5b729310d5104536();
		}
	}

	private void x5b729310d5104536()
	{
		OdsoRecipientData odsoRecipientData = new OdsoRecipientData();
		while (true)
		{
			int num = x7450cc1e48712286.ReadInt16();
			int num2 = x7450cc1e48712286.ReadInt16();
			switch (num)
			{
			case 0:
				if (odsoRecipientData.Hash != 0 || odsoRecipientData.UniqueTag != null)
				{
					x5dbb567a34673893.Odso.RecipientDatas.Add(odsoRecipientData);
				}
				return;
			case 1:
				odsoRecipientData.Active = xe5d393f0d1706f47(num2) != 0;
				break;
			case 2:
				odsoRecipientData.Column = xe5d393f0d1706f47(num2);
				break;
			case 3:
				odsoRecipientData.Hash = x7450cc1e48712286.ReadInt32();
				break;
			case 4:
				odsoRecipientData.UniqueTag = x7450cc1e48712286.ReadBytes(num2);
				break;
			default:
				x7450cc1e48712286.ReadBytes(num2);
				break;
			}
		}
	}

	private void xbea1194266fd2950(int x961016a387451f05)
	{
		_ = x7450cc1e48712286.BaseStream.Position;
		x7450cc1e48712286.ReadInt16();
		x7450cc1e48712286.ReadInt16();
		int num = x7450cc1e48712286.ReadInt32();
		x7450cc1e48712286.ReadInt16();
		int num2 = x7450cc1e48712286.ReadInt16();
		if (num2 == -1)
		{
			num2 = x7450cc1e48712286.ReadInt32();
		}
		for (int i = 0; i < num; i++)
		{
			x54b25e88f94cc6b4(i);
		}
	}

	private void x54b25e88f94cc6b4(int xc0c4c459c6ccbd00)
	{
		OdsoFieldMapData odsoFieldMapData = new OdsoFieldMapData();
		while (true)
		{
			int num = x7450cc1e48712286.ReadInt16();
			int num2 = x7450cc1e48712286.ReadInt16();
			switch (num)
			{
			case 0:
				if (x0d299f323d241756.x5959bccb67bbf051(odsoFieldMapData.Name))
				{
					odsoFieldMapData.Type = OdsoFieldMappingType.Column;
				}
				x5dbb567a34673893.Odso.FieldMapDatas.Add(odsoFieldMapData);
				return;
			case 1:
			{
				int num3 = xe5d393f0d1706f47(num2);
				if (num3 != 1)
				{
					throw new InvalidOperationException("xxx");
				}
				break;
			}
			case 2:
				odsoFieldMapData.Name = x00520580a1771bfe(num2);
				break;
			case 3:
				x00520580a1771bfe(num2);
				odsoFieldMapData.MappedName = xca039bdabeb3e5dc.x80b5093594360ff6((x7108b36f9eb19d89)xc0c4c459c6ccbd00);
				break;
			case 4:
				odsoFieldMapData.xc68740e2faa12e13(xe5d393f0d1706f47(num2));
				break;
			default:
				x7450cc1e48712286.ReadBytes(num2);
				break;
			}
		}
	}

	private string x00520580a1771bfe(int xdd29aa438e247cc8)
	{
		return Encoding.Unicode.GetString(x7450cc1e48712286.ReadBytes(xdd29aa438e247cc8));
	}

	private int xe5d393f0d1706f47(int x0ceec69a97f73617)
	{
		return x0ceec69a97f73617 switch
		{
			1 => x7450cc1e48712286.ReadByte(), 
			2 => x7450cc1e48712286.ReadInt16(), 
			4 => x7450cc1e48712286.ReadInt32(), 
			_ => throw new InvalidOperationException("Unexpected integer size."), 
		};
	}
}
