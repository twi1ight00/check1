using System.Collections.Specialized;
using System.IO;
using System.Text;
using Aspose.Words.Settings;
using x6c95d9cf46ff5f25;
using xa604c4d210ae0581;

namespace x9e260ffa1ac41ffa;

internal class x0bd8cf7f8e7e6606
{
	private const int x4126fef4c1354fbb = 3;

	private const int xb86fae26e8ac0f81 = 65523;

	private const int x3846a5bdddb20639 = 255;

	private MailMergeSettings x5dbb567a34673893;

	private x8aeace2bf92692ab xa6172040dc8d693f;

	private xb4278d25e0406614 x0055d03d8785e4bd;

	private BinaryWriter x9b287b671d592594;

	internal void x6210059f049f0d48(MailMergeSettings x9fc6d11f73f7c086, x8aeace2bf92692ab xf0c8411938a86cbf, xb4278d25e0406614 xec232eb93dd022a7, BinaryWriter xbdfb620b7167944b)
	{
		if (!x9fc6d11f73f7c086.x7149c962c02931b3)
		{
			x5dbb567a34673893 = x9fc6d11f73f7c086;
			xa6172040dc8d693f = xf0c8411938a86cbf;
			x0055d03d8785e4bd = xec232eb93dd022a7;
			x9b287b671d592594 = xbdfb620b7167944b;
			xa6172040dc8d693f.x4605e55a1901024b.xeb0a4e0d8f6b5ba3.xe53f0e68147463d1 = (int)x9b287b671d592594.BaseStream.Position;
			xa6172040dc8d693f.x4605e55a1901024b.xeb0a4e0d8f6b5ba3.x04c290dc4d04369c = xc45415f52c9f6a9b(xd8475b2033e0b923: true);
			xc7f45f1cf1a88832();
		}
	}

	private int xc45415f52c9f6a9b(bool xd8475b2033e0b923)
	{
		int num = (int)x9b287b671d592594.BaseStream.Position;
		bool flag = x0d299f323d241756.x5959bccb67bbf051(x5dbb567a34673893.DataSource);
		bool flag2 = x0d299f323d241756.x5959bccb67bbf051(x5dbb567a34673893.HeaderSource);
		int num2 = 0;
		num2 |= 1;
		num2 |= (flag ? 2 : 0);
		num2 |= (flag2 ? 4 : 0);
		num2 |= (int)(x5dbb567a34673893.MainDocumentType & (MailMergeMainDocumentType)15) << 3;
		num2 |= ((!x5dbb567a34673893.DoNotSupressBlankLines) ? 1024 : 0);
		num2 |= (int)x5dbb567a34673893.Destination << 13;
		x9b287b671d592594.Write((short)num2);
		x9b287b671d592594.Write((byte)(flag2 ? 1u : 0u));
		x9b287b671d592594.Write((byte)0);
		x9b287b671d592594.Write(x5dbb567a34673893.ActiveRecord);
		x245cb6bf933aaf97 x245cb6bf933aaf = new x245cb6bf933aaf97();
		x245cb6bf933aaf.xabdd4c8efb3f2050 = MailMergeDataType.None;
		x245cb6bf933aaf.x6f148b4649a10af0 = 65523;
		if (flag)
		{
			x245cb6bf933aaf.xabdd4c8efb3f2050 = x5dbb567a34673893.DataType;
			x245cb6bf933aaf.x6f148b4649a10af0 = x0055d03d8785e4bd.x3710c228da65de24(3, x5dbb567a34673893.DataSource);
			x245cb6bf933aaf.x3289a7dac77cb243 = x5dbb567a34673893.LinkToQuery;
			if (x245cb6bf933aaf.xabdd4c8efb3f2050 == MailMergeDataType.TextFile)
			{
				x245cb6bf933aaf.x32158491f5e28d99 = x5dbb567a34673893.x7bcd35f5ead5b5bf;
				x245cb6bf933aaf.xa0c0ceaacfcd0c83 = x5dbb567a34673893.xf8d8395bc4a715ea;
			}
		}
		x245cb6bf933aaf.x6210059f049f0d48(x9b287b671d592594);
		x245cb6bf933aaf97 x245cb6bf933aaf2 = new x245cb6bf933aaf97();
		x245cb6bf933aaf2.xabdd4c8efb3f2050 = MailMergeDataType.TextFile;
		x245cb6bf933aaf2.x6f148b4649a10af0 = 65523;
		if (flag2)
		{
			x245cb6bf933aaf2.xabdd4c8efb3f2050 = x5dbb567a34673893.DataType;
			x245cb6bf933aaf2.x6f148b4649a10af0 = x0055d03d8785e4bd.x3710c228da65de24(3, x5dbb567a34673893.HeaderSource);
			x245cb6bf933aaf2.x3289a7dac77cb243 = x5dbb567a34673893.LinkToQuery;
			if (x245cb6bf933aaf2.xabdd4c8efb3f2050 == MailMergeDataType.TextFile)
			{
				x245cb6bf933aaf2.x32158491f5e28d99 = x5dbb567a34673893.x09a3beda84a8a23c;
				x245cb6bf933aaf2.xa0c0ceaacfcd0c83 = x5dbb567a34673893.x20f69eabf273199b;
			}
		}
		x245cb6bf933aaf2.x6210059f049f0d48(x9b287b671d592594);
		int num3 = 0;
		num3 |= (x5dbb567a34673893.ViewMergedData ? 1 : 0);
		num3 |= (int)(x5dbb567a34673893.CheckErrors - 1) << 1;
		num3 |= ((!x5dbb567a34673893.MailAsAttachment) ? 128 : 0);
		x9b287b671d592594.Write((short)num3);
		x9b287b671d592594.Write((short)18080);
		string xbcea506a33cf = xb6ae7a4796fce1ec(x5dbb567a34673893.Query);
		x9b287b671d592594.Write((short)x93b05c1ad709a695.x10e05a5c8b6822db(xbcea506a33cf));
		x93b05c1ad709a695.x535736a60cc73a33(xbcea506a33cf, x9b287b671d592594);
		StringCollection stringCollection = new StringCollection();
		stringCollection.Add(x5dbb567a34673893.ConnectString);
		stringCollection.Add("");
		stringCollection.Add(x5dbb567a34673893.MailSubject);
		stringCollection.Add(x5dbb567a34673893.AddressFieldName);
		if (xd8475b2033e0b923)
		{
			stringCollection.Add("");
		}
		xaf807f6784ee1743.x6210059f049f0d48(x9b287b671d592594, stringCollection);
		if (xd8475b2033e0b923)
		{
			x9b287b671d592594.Write((int)x5dbb567a34673893.MainDocumentType);
		}
		return (int)x9b287b671d592594.BaseStream.Position - num;
	}

	private void xc7f45f1cf1a88832()
	{
		xa6172040dc8d693f.x4605e55a1901024b.x6633cfa1b4898c8b.xe53f0e68147463d1 = (int)x9b287b671d592594.BaseStream.Position;
		Odso odso = x5dbb567a34673893.Odso;
		xb4140354836d96f6(0, odso.UdlConnectString);
		xb4140354836d96f6(1, odso.TableName);
		xb4140354836d96f6(2, odso.DataSource);
		xe81ce6875c4b595b(16, (int)odso.DataSourceType);
		x92eeadf8cacc5bd4(17, (short)odso.ColumnDelimiter);
		xe81ce6875c4b595b(18, odso.FirstRowContainsColumnNames ? 1 : 0);
		xe1e6ba3f9b1d4bee();
		x9f824eea8de9ae2e();
		xa6172040dc8d693f.x4605e55a1901024b.x6633cfa1b4898c8b.x04c290dc4d04369c = (int)x9b287b671d592594.BaseStream.Position - xa6172040dc8d693f.x4605e55a1901024b.x6633cfa1b4898c8b.xe53f0e68147463d1;
	}

	private void xe1e6ba3f9b1d4bee()
	{
		OdsoRecipientDataCollection recipientDatas = x5dbb567a34673893.Odso.RecipientDatas;
		if (recipientDatas.Count == 0)
		{
			return;
		}
		int xc76ba2ce54256c9c = x55b040230632ef78(xfdb75d2da5baf247.xb16033d14467fafc);
		int x10aaa7cdfa38f = (int)x9b287b671d592594.BaseStream.Position;
		int xc76ba2ce54256c9c2 = xa82a6b2368a1046f(recipientDatas.Count);
		int x10aaa7cdfa38f2 = (int)x9b287b671d592594.BaseStream.Position;
		foreach (OdsoRecipientData item in recipientDatas)
		{
			x854db80dc54b9623(item);
		}
		x1c00c16d37373ea8(xc76ba2ce54256c9c, x10aaa7cdfa38f);
		x1c00c16d37373ea8(xc76ba2ce54256c9c2, x10aaa7cdfa38f2);
	}

	private void x854db80dc54b9623(OdsoRecipientData xcbf4234228f3077c)
	{
		if (!xcbf4234228f3077c.Active)
		{
			x3fd577ea703bd3b3(1, 0);
		}
		xe81ce6875c4b595b(2, xcbf4234228f3077c.Column);
		if (xcbf4234228f3077c.Hash != 0)
		{
			xe81ce6875c4b595b(3, xcbf4234228f3077c.Hash);
		}
		if (xcbf4234228f3077c.UniqueTag != null)
		{
			x30b16c1797593c58(4, xcbf4234228f3077c.UniqueTag);
		}
		x74f95d100c7143bb();
	}

	private void x9f824eea8de9ae2e()
	{
		OdsoFieldMapDataCollection fieldMapDatas = x5dbb567a34673893.Odso.FieldMapDatas;
		if (fieldMapDatas.Count == 0)
		{
			return;
		}
		int xc76ba2ce54256c9c = x9fe4ba8424673024(xfdb75d2da5baf247.xa5be5cfd9c5c8ff7);
		int x10aaa7cdfa38f = (int)x9b287b671d592594.BaseStream.Position;
		int xc76ba2ce54256c9c2 = xa91effea2f0f9196(fieldMapDatas.Count);
		int x10aaa7cdfa38f2 = (int)x9b287b671d592594.BaseStream.Position;
		foreach (OdsoFieldMapData item in fieldMapDatas)
		{
			x029be9ce86c864d3(item);
		}
		x7f54878bbf220713(xc76ba2ce54256c9c, x10aaa7cdfa38f);
		x7f54878bbf220713(xc76ba2ce54256c9c2, x10aaa7cdfa38f2);
	}

	private void x029be9ce86c864d3(OdsoFieldMapData x89850a4a3a38732e)
	{
		switch (x89850a4a3a38732e.Type)
		{
		case OdsoFieldMappingType.Column:
			xe81ce6875c4b595b(1, 1);
			xb4140354836d96f6(2, x89850a4a3a38732e.Name);
			xb4140354836d96f6(3, x89850a4a3a38732e.MappedName);
			xe81ce6875c4b595b(4, x89850a4a3a38732e.Column);
			x74f95d100c7143bb();
			break;
		default:
			x74f95d100c7143bb();
			break;
		}
	}

	private int x55b040230632ef78(xfdb75d2da5baf247 xeaf1b27180c0557b)
	{
		x9b287b671d592594.Write((short)xeaf1b27180c0557b);
		x9b287b671d592594.Write((short)(-1));
		int result = (int)x9b287b671d592594.BaseStream.Position;
		x9b287b671d592594.Write(0);
		return result;
	}

	private int x9fe4ba8424673024(xfdb75d2da5baf247 xeaf1b27180c0557b)
	{
		x9b287b671d592594.Write((short)xeaf1b27180c0557b);
		int result = (int)x9b287b671d592594.BaseStream.Position;
		x9b287b671d592594.Write((short)0);
		return result;
	}

	private int xa82a6b2368a1046f(int x10f4d88af727adbc)
	{
		x9b287b671d592594.Write((short)0);
		x9b287b671d592594.Write((short)4);
		x9b287b671d592594.Write(x10f4d88af727adbc);
		x9b287b671d592594.Write((short)1);
		x9b287b671d592594.Write((short)(-1));
		int result = (int)x9b287b671d592594.BaseStream.Position;
		x9b287b671d592594.Write(0);
		return result;
	}

	private int xa91effea2f0f9196(int x10f4d88af727adbc)
	{
		x9b287b671d592594.Write((short)0);
		x9b287b671d592594.Write((short)4);
		x9b287b671d592594.Write(x10f4d88af727adbc);
		x9b287b671d592594.Write((short)1);
		int result = (int)x9b287b671d592594.BaseStream.Position;
		x9b287b671d592594.Write((short)0);
		return result;
	}

	private void x1c00c16d37373ea8(int xc76ba2ce54256c9c, int x10aaa7cdfa38f254)
	{
		int num = (int)x9b287b671d592594.BaseStream.Position;
		int value = num - x10aaa7cdfa38f254;
		x9b287b671d592594.BaseStream.Position = xc76ba2ce54256c9c;
		x9b287b671d592594.Write(value);
		x9b287b671d592594.BaseStream.Position = num;
	}

	private void x7f54878bbf220713(int xc76ba2ce54256c9c, int x10aaa7cdfa38f254)
	{
		int num = (int)x9b287b671d592594.BaseStream.Position;
		short value = (short)(num - x10aaa7cdfa38f254);
		x9b287b671d592594.BaseStream.Position = xc76ba2ce54256c9c;
		x9b287b671d592594.Write(value);
		x9b287b671d592594.BaseStream.Position = num;
	}

	private void xb4140354836d96f6(int xeaf1b27180c0557b, string xbcea506a33cf9111)
	{
		if (x0d299f323d241756.x5959bccb67bbf051(xbcea506a33cf9111))
		{
			x9b287b671d592594.Write((short)xeaf1b27180c0557b);
			xbcea506a33cf9111 = xb6ae7a4796fce1ec(xbcea506a33cf9111);
			byte[] bytes = Encoding.Unicode.GetBytes(xbcea506a33cf9111);
			x9b287b671d592594.Write((short)bytes.Length);
			x9b287b671d592594.Write(bytes);
		}
	}

	private void xe81ce6875c4b595b(int xeaf1b27180c0557b, int xbcea506a33cf9111)
	{
		x9b287b671d592594.Write((short)xeaf1b27180c0557b);
		x9b287b671d592594.Write((short)4);
		x9b287b671d592594.Write(xbcea506a33cf9111);
	}

	private void x92eeadf8cacc5bd4(int xeaf1b27180c0557b, short xbcea506a33cf9111)
	{
		x9b287b671d592594.Write((short)xeaf1b27180c0557b);
		x9b287b671d592594.Write((short)2);
		x9b287b671d592594.Write(xbcea506a33cf9111);
	}

	private void x3fd577ea703bd3b3(int xeaf1b27180c0557b, byte xbcea506a33cf9111)
	{
		x9b287b671d592594.Write((short)xeaf1b27180c0557b);
		x9b287b671d592594.Write((short)1);
		x9b287b671d592594.Write(xbcea506a33cf9111);
	}

	private void x30b16c1797593c58(int xeaf1b27180c0557b, byte[] x4a3f0a05c02f235f)
	{
		x9b287b671d592594.Write((short)xeaf1b27180c0557b);
		x9b287b671d592594.Write((short)x4a3f0a05c02f235f.Length);
		x9b287b671d592594.Write(x4a3f0a05c02f235f);
	}

	private void x74f95d100c7143bb()
	{
		x9b287b671d592594.Write((short)0);
		x9b287b671d592594.Write((short)0);
	}

	private static string xb6ae7a4796fce1ec(string xbcea506a33cf9111)
	{
		if (xbcea506a33cf9111.Length <= 255)
		{
			return xbcea506a33cf9111;
		}
		return xbcea506a33cf9111.Substring(0, 255);
	}
}
