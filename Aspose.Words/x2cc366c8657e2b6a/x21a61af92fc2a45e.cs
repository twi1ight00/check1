using System;
using System.Collections;
using System.IO;
using Aspose;
using Aspose.Words;
using Aspose.Words.Drawing;
using x011d489fb9df7027;
using x1495530f35d79681;
using x28925c9b27b37a46;
using x452f379ec5921195;
using x650fee20d618512c;
using x6c95d9cf46ff5f25;
using x79490184cecf12a1;
using x7c7a1dceb600404e;
using xb92b7270f78a4e8d;
using xf9a9481c3f63a419;

namespace x2cc366c8657e2b6a;

internal class x21a61af92fc2a45e : xdfce7f4f687956d7
{
	private readonly x3c85359e1389ad43 xc3723d392789e04d;

	private readonly Hashtable x7056611584e138d9 = new Hashtable();

	private readonly Hashtable x0ce97460d0a35f4b = new Hashtable();

	private readonly Hashtable x7f535de8d2e8f623 = new Hashtable();

	private readonly Hashtable xfc3f6b8112d1b3d3 = new Hashtable();

	private readonly Hashtable xd50c3f65b71effd0 = new Hashtable();

	private readonly bool xb7e089ac91032c79;

	internal override bool x3ee7f4bad5fbb600
	{
		get
		{
			if (!x099487305e4675db)
			{
				return !xc3723d392789e04d.x57b319ed721a743d;
			}
			return false;
		}
	}

	public override x3c85359e1389ad43 x3bcd232d01c14846 => xc3723d392789e04d;

	internal override bool x099487305e4675db => xd50c3f65b71effd0.Contains(xc3723d392789e04d.x91d35d7dc070c876 + xc3723d392789e04d.xa66385d80d4d296f);

	internal override bool x325f1926b78ae5cd => false;

	internal Hashtable x5f4cb0a97aefda2b => x7f535de8d2e8f623;

	internal Hashtable x5f7e98a6a42dbe20 => xfc3f6b8112d1b3d3;

	internal bool xff407d097cedd1e6 => xb7e089ac91032c79;

	internal x21a61af92fc2a45e(Stream stream, Document doc, LoadOptions loadOptions)
		: base(doc, loadOptions, WarningSource.WordML)
	{
		xc3723d392789e04d = new x0272e69c04de50f9(stream, loadOptions.WarningCallback, WarningSource.WordML);
	}

	internal x21a61af92fc2a45e(Stream stream, Document doc, LoadOptions loadOptions, bool readEquationXml)
		: this(stream, doc, loadOptions)
	{
		xb7e089ac91032c79 = readEquationXml;
	}

	internal void x06b0e25aa6ad68a9()
	{
		base.x936e45dfa3e35eb8 = xc3723d392789e04d.xd68abcd61e368af9("space", "") == "preserve";
		while (xc3723d392789e04d.x152cbadbfa8061b1("wordDocument"))
		{
			switch (xc3723d392789e04d.xa66385d80d4d296f)
			{
			case "SmartTagType":
				xd655c5743da3ed45();
				break;
			case "DocumentProperties":
				x0dbd709f05f41c5c.xd40e142dfd23be4b(this);
				break;
			case "CustomDocumentProperties":
				x0dbd709f05f41c5c.x75b613efd8182791(this);
				break;
			case "fonts":
				x989f89f6aff238fe.x06b0e25aa6ad68a9(this);
				break;
			case "frameset":
			{
				x227665e444fb500a x227665e444fb500a = new x227665e444fb500a();
				x227665e444fb500a.x3650f9b73dc5111b = x3650f9b73dc5111b.xe74f26d8f4cfb63f;
				((Document)base.x2c8c6741422a1298).x227665e444fb500a = x227665e444fb500a;
				x8834ab836c23d666.x06b0e25aa6ad68a9(this, x227665e444fb500a, x5fbb1a9c98604ef5: false);
				break;
			}
			case "lists":
				x6fe86675ebd9ee90.x06b0e25aa6ad68a9(this);
				break;
			case "styles":
				x93675d61d5941ea0.x06b0e25aa6ad68a9(this);
				x6fe86675ebd9ee90.xb896cd5f5a33d897(this);
				break;
			case "docOleData":
				xb80d58867d2d12aa();
				break;
			case "docSuppData":
				x19a91600ee31f4a6();
				break;
			case "shapeDefaults":
				xc3723d392789e04d.IgnoreElement();
				break;
			case "bgPict":
				xcb00358ab5144003.x6ba34f1965cf9ac5(this);
				break;
			case "docPr":
				xf12e0633e78c468f.x06b0e25aa6ad68a9(this);
				break;
			case "body":
				x31635cdae45482fa.x06b0e25aa6ad68a9(this);
				break;
			default:
				xc3723d392789e04d.IgnoreElement();
				break;
			}
		}
		x7c0f41ccd8aba612();
	}

	private void xd655c5743da3ed45()
	{
		string text = "";
		string text2 = "";
		while (xc3723d392789e04d.x1ac1960adc8c4c39())
		{
			switch (xc3723d392789e04d.xa66385d80d4d296f)
			{
			case "namespaceuri":
				text = xc3723d392789e04d.xd2f68ee6f47e9dfb;
				break;
			case "name":
				text2 = xc3723d392789e04d.xd2f68ee6f47e9dfb;
				break;
			}
		}
		string text3 = text + text2;
		xd50c3f65b71effd0[text3] = text3;
	}

	private void xb80d58867d2d12aa()
	{
		xbe9dfc31fc9d0c49();
		byte[] buffer = x7b29fad09d9101c5("oledata.mso");
		MemoryStream stream = new MemoryStream(buffer);
		xd8c3135513b9115b xd8c3135513b9115b = new xd8c3135513b9115b(stream);
		foreach (DictionaryEntry item in xd8c3135513b9115b.x29e7ace4c90f74cd)
		{
			xe7be411416cfcd54 value = x2fcdffade411c226((MemoryStream)item.Value);
			x0ce97460d0a35f4b[item.Key] = value;
		}
	}

	private static xe7be411416cfcd54 x2fcdffade411c226(Stream x78fc7573bdcacc84)
	{
		x78fc7573bdcacc84.Position = 4L;
		byte[] buffer = xf1da3993f05a75b7.x4671919d08389f8e(x78fc7573bdcacc84, 0, x2e6ebe7013ab34b9.x1455a9a8b1cd9f39);
		xd8c3135513b9115b xd8c3135513b9115b = new xd8c3135513b9115b(new MemoryStream(buffer));
		return xd8c3135513b9115b.x29e7ace4c90f74cd;
	}

	private void x19a91600ee31f4a6()
	{
		Document document = (Document)base.x2c8c6741422a1298;
		xbe9dfc31fc9d0c49();
		MemoryStream memoryStream = new MemoryStream(x7b29fad09d9101c5("editdata.mso"));
		BinaryReader binaryReader = new BinaryReader(memoryStream);
		binaryReader.ReadBytes(10);
		while (memoryStream.Position < memoryStream.Length)
		{
			switch (binaryReader.ReadInt32())
			{
			case -268369920:
				binaryReader.ReadInt32();
				binaryReader.ReadInt32();
				break;
			case -267976704:
			{
				int num = binaryReader.ReadInt32();
				binaryReader.ReadBytes(8);
				int num2 = binaryReader.ReadInt32();
				document.xa0a845678e16cf58 = (xa0a845678e16cf58)binaryReader.ReadInt32();
				if (num2 > 0)
				{
					document.xd7b817e9f42390ee = binaryReader.ReadBytes(num2);
				}
				int x584b67d526f6b9d = binaryReader.ReadInt32();
				int num3 = num - num2 - 20;
				if (num3 > 0)
				{
					byte[] x3b4efd51efae57c = binaryReader.ReadBytes(num3);
					byte[] buffer = xf1da3993f05a75b7.x4671919d08389f8e(x3b4efd51efae57c, x584b67d526f6b9d, x2e6ebe7013ab34b9.x1455a9a8b1cd9f39);
					MemoryStream stream = new MemoryStream(buffer);
					xd8c3135513b9115b xd8c3135513b9115b = new xd8c3135513b9115b(stream);
					document.x92e2e3377da135e8 = xd8c3135513b9115b.x29e7ace4c90f74cd;
				}
				break;
			}
			case -267583488:
			{
				int count = binaryReader.ReadInt32();
				byte[] x4a3f0a05c02f235f = binaryReader.ReadBytes(count);
				xc8c3723db99028f4(x4a3f0a05c02f235f);
				break;
			}
			case -267714560:
				binaryReader.ReadInt32();
				binaryReader.ReadInt32();
				break;
			}
		}
	}

	private void xc8c3723db99028f4(byte[] x4a3f0a05c02f235f)
	{
		MemoryStream memoryStream = new MemoryStream(x4a3f0a05c02f235f);
		memoryStream.Position = 16L;
		x82218fbaaecee34a x82218fbaaecee34a = new x82218fbaaecee34a();
		int x961016a387451f = (int)(memoryStream.Length - memoryStream.Position);
		x82218fbaaecee34a.x06b0e25aa6ad68a9(new BinaryReader(memoryStream), x961016a387451f, (Document)base.x2c8c6741422a1298);
	}

	[JavaThrows(true)]
	private void xbe9dfc31fc9d0c49()
	{
		xc3723d392789e04d.x99f8cdb2827fa686();
		string xa66385d80d4d296f = xc3723d392789e04d.xa66385d80d4d296f;
		while (xc3723d392789e04d.x152cbadbfa8061b1(xa66385d80d4d296f))
		{
			string xa66385d80d4d296f2;
			if ((xa66385d80d4d296f2 = xc3723d392789e04d.xa66385d80d4d296f) != null && xa66385d80d4d296f2 == "binData")
			{
				x2b6e606d842be5f3();
			}
		}
	}

	public override xd142dcacd7ddc9dd x36eb835297f7b346(string xeaf1b27180c0557b)
	{
		xe7be411416cfcd54 xe7be411416cfcd = (xe7be411416cfcd54)x0ce97460d0a35f4b[xeaf1b27180c0557b];
		if (xe7be411416cfcd == null)
		{
			return null;
		}
		return new x71d39fdf56861cca(xe7be411416cfcd);
	}

	public override byte[] x7b29fad09d9101c5(string xc15bd84e01929885)
	{
		return (byte[])x7056611584e138d9[xc15bd84e01929885];
	}

	public override string x052a6c2e603b1662(string xc06e652f250a3786)
	{
		return xc06e652f250a3786;
	}

	public override bool x3d21050b1e731250(string x50a18ad2656e7181)
	{
		return !x50a18ad2656e7181.StartsWith("wordml://");
	}

	public override void x2b6e606d842be5f3()
	{
		string text = xc3723d392789e04d.xd68abcd61e368af9("name", "");
		if (x0d299f323d241756.x5959bccb67bbf051(text))
		{
			string s = xc3723d392789e04d.x2a1ea9d24e62bf84();
			byte[] array = Convert.FromBase64String(s);
			switch (Path.GetExtension(text).ToLower())
			{
			case ".emz":
			case ".wmz":
				array = x64893267b789fd52.x8724fdc4dc7fc92f(array);
				break;
			case ".pcz":
				array = x64893267b789fd52.x0824a1a655b79c17(array);
				break;
			}
			x7056611584e138d9[text] = x622213a14a0645f2(array);
		}
	}

	public override void x7a60e084fa9fb0e3(ShapeBase x5770cdefd8931aa9)
	{
		x38ecd42e68717d79.x06b0e25aa6ad68a9(this, x5770cdefd8931aa9);
	}

	internal override Footnote x3e5f4bed8c6ef7e6(FootnoteType xd3526c7313d75391, int xeaf1b27180c0557b)
	{
		throw new InvalidOperationException("Not supposed to call this.");
	}

	internal override void x2587cb0fe9d7f086(Comment x77c5a31ec0891f38)
	{
		throw new InvalidOperationException("Not supposed to call this.");
	}

	internal override Comment x8acb911280b864de(int xeaf1b27180c0557b)
	{
		throw new InvalidOperationException("Not supposed to call this.");
	}

	internal override x9ea8b270a83f04a0 x663a863d790eefe8(string xc06e652f250a3786)
	{
		throw new InvalidOperationException("Not supposed to call this.");
	}

	internal override x9ea8b270a83f04a0 xc8ab4e294c74831b()
	{
		throw new InvalidOperationException("Not supposed to call this.");
	}

	internal override x9ea8b270a83f04a0 x5f81a20b8dd0c3a7(x9ea8b270a83f04a0 xe134235b3526fa75)
	{
		throw new InvalidOperationException("Not supposed to call this.");
	}
}
