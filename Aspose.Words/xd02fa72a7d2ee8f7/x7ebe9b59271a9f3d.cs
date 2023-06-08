using System.IO;
using System.Text;
using Aspose.Words;
using xb92b7270f78a4e8d;
using xcf014befd8b52c3b;

namespace xd02fa72a7d2ee8f7;

internal class x7ebe9b59271a9f3d
{
	private x7ebe9b59271a9f3d()
	{
	}

	internal static void x06b0e25aa6ad68a9(xd8c3135513b9115b x84378c276c4cd7e2, DigitalSignatureCollection x35a024439e5c0797, IWarningCallback x57fef5933b41d0c2)
	{
		x039b35280f373ae2(x84378c276c4cd7e2, x35a024439e5c0797, x57fef5933b41d0c2);
		x1b6ebea37fffe224(x84378c276c4cd7e2, x35a024439e5c0797, x57fef5933b41d0c2);
	}

	private static void x039b35280f373ae2(xd8c3135513b9115b x84378c276c4cd7e2, DigitalSignatureCollection x35a024439e5c0797, IWarningCallback x57fef5933b41d0c2)
	{
		xe7be411416cfcd54 xe7be411416cfcd = x84378c276c4cd7e2.x29e7ace4c90f74cd.x03c5de1b1357f136("_xmlsignatures");
		if (xe7be411416cfcd == null)
		{
			return;
		}
		foreach (string key in xe7be411416cfcd.GetKeyList())
		{
			x616fc5ae23ca7e6e.x06b0e25aa6ad68a9(xe7be411416cfcd.x3e19bf48aeaa5779(key), new x974943b359b002f5(x84378c276c4cd7e2), x35a024439e5c0797, x57fef5933b41d0c2);
		}
	}

	private static void x1b6ebea37fffe224(xd8c3135513b9115b x84378c276c4cd7e2, DigitalSignatureCollection x35a024439e5c0797, IWarningCallback x57fef5933b41d0c2)
	{
		Stream stream = x84378c276c4cd7e2.x29e7ace4c90f74cd.x3e19bf48aeaa5779("_signatures");
		if (stream != null)
		{
			BinaryReader binaryReader = new BinaryReader(stream, Encoding.Unicode);
			int x9addc7c14afef58b = binaryReader.ReadInt32();
			x57620b146205362d(binaryReader, x9addc7c14afef58b);
			binaryReader.ReadInt32();
			xcefb6cf5f6f098f3 xcefb6cf5f6f098f4 = new xcefb6cf5f6f098f3(x84378c276c4cd7e2.x29e7ace4c90f74cd);
			x304554ec6deff1cb(binaryReader, x35a024439e5c0797, xcefb6cf5f6f098f4.xf35aae0fa4a217a4, x57fef5933b41d0c2);
		}
	}

	private static void x57620b146205362d(BinaryReader xe134235b3526fa75, int x9addc7c14afef58b)
	{
		if (x9addc7c14afef58b > 0)
		{
			xe134235b3526fa75.ReadInt32();
			xe134235b3526fa75.ReadInt32();
			while (xe134235b3526fa75.ReadInt32() != 0)
			{
				xe134235b3526fa75.ReadInt32();
				int count = xe134235b3526fa75.ReadInt32();
				xe134235b3526fa75.ReadBytes(count);
			}
			xe134235b3526fa75.ReadBytes(8);
		}
	}

	private static void x304554ec6deff1cb(BinaryReader xe134235b3526fa75, DigitalSignatureCollection x35a024439e5c0797, byte[] xb42db422810fc3a2, IWarningCallback x57fef5933b41d0c2)
	{
		for (int num = xe134235b3526fa75.ReadInt32(); num != 0; num = xe134235b3526fa75.ReadInt32())
		{
			DigitalSignature digitalSignature = x458361e51fba4475.x06b0e25aa6ad68a9(xe134235b3526fa75, xb42db422810fc3a2);
			x35a024439e5c0797.xd6b6ed77479ef68c(digitalSignature);
			if (!digitalSignature.IsValid)
			{
				x57fef5933b41d0c2?.Warning(new WarningInfo(WarningType.UnexpectedContent, WarningSource.Doc, "Digital signature is invalid, document content was tampered."));
			}
		}
	}
}
