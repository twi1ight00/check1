using System;
using Aspose.Words;
using Aspose.Words.Properties;
using x13f1efc79617a47b;
using x1a3e96f4b89a7a77;
using xf989f31a236ff98c;
using xf9a9481c3f63a419;

namespace xa8550ea6ae4a81a5;

internal class x88b616adafef1fe9
{
	private x88b616adafef1fe9()
	{
	}

	internal static void x6210059f049f0d48(xe41cdb7a2a4611b4 xbdfb620b7167944b)
	{
		Document x2c8c6741422a = xbdfb620b7167944b.x2c8c6741422a1298;
		if (!x311bb10d5871a09f.xe8be26df1e9a02d5(x2c8c6741422a.CustomDocumentProperties))
		{
			return;
		}
		x8f3af96aa56f1e32 x8f3af96aa56f1e33 = xbdfb620b7167944b.x082c3925d43afdad("/docProps/custom.xml", "application/vnd.openxmlformats-officedocument.custom-properties+xml", "http://schemas.openxmlformats.org/officeDocument/2006/relationships/custom-properties");
		x8f3af96aa56f1e33.x9b9ed0109b743e3b("Properties");
		x8f3af96aa56f1e33.xff520a0047c27122("xmlns", "http://schemas.openxmlformats.org/officeDocument/2006/custom-properties");
		x8f3af96aa56f1e33.xff520a0047c27122("xmlns:vt", "http://schemas.openxmlformats.org/officeDocument/2006/docPropsVTypes");
		int num = 2;
		foreach (DocumentProperty customDocumentProperty in x2c8c6741422a.CustomDocumentProperties)
		{
			if (x311bb10d5871a09f.xbf999c8ebd28bbaf(customDocumentProperty))
			{
				x8f3af96aa56f1e33.x2307058321cdb62f("property");
				x8f3af96aa56f1e33.xff520a0047c27122("fmtid", "{D5CDD505-2E9C-101B-9397-08002B2CF9AE}");
				x8f3af96aa56f1e33.xff520a0047c27122("pid", xca004f56614e2431.x754c3a5f03a2ce84(num));
				x8f3af96aa56f1e33.xff520a0047c27122("name", customDocumentProperty.Name);
				x8f3af96aa56f1e33.x943f6be3acf634db("linkTarget", customDocumentProperty.x1321c7b28b151682);
				x51ac21c72cbb553a(customDocumentProperty, x8f3af96aa56f1e33);
				x8f3af96aa56f1e33.x2dfde153f4ef96d0();
				num++;
			}
		}
		x8f3af96aa56f1e33.xa0dfc102c691b11f();
	}

	private static void x51ac21c72cbb553a(DocumentProperty x5ca6b6e12a4d9043, x873451caae5ad4ae xd07ce4b74c5774a7)
	{
		switch (x5ca6b6e12a4d9043.Type)
		{
		case PropertyType.Boolean:
			xd07ce4b74c5774a7.x2307058321cdb62f("vt:bool");
			xd07ce4b74c5774a7.x3d1be38abe5723e3(x5ca6b6e12a4d9043.ToBool() ? "true" : "false");
			xd07ce4b74c5774a7.x2dfde153f4ef96d0();
			break;
		case PropertyType.Number:
			xd07ce4b74c5774a7.x2307058321cdb62f("vt:i4");
			xd07ce4b74c5774a7.x3d1be38abe5723e3(xca004f56614e2431.x754c3a5f03a2ce84(x5ca6b6e12a4d9043.ToInt()));
			xd07ce4b74c5774a7.x2dfde153f4ef96d0();
			break;
		case PropertyType.Double:
			xd07ce4b74c5774a7.x2307058321cdb62f("vt:r8");
			xd07ce4b74c5774a7.x3d1be38abe5723e3(xca004f56614e2431.xcaaeec2e96b2cecc(x5ca6b6e12a4d9043.ToDouble()));
			xd07ce4b74c5774a7.x2dfde153f4ef96d0();
			break;
		case PropertyType.String:
			xd07ce4b74c5774a7.x2307058321cdb62f("vt:lpwstr");
			xd07ce4b74c5774a7.x3d1be38abe5723e3(x5ca6b6e12a4d9043.ToString());
			xd07ce4b74c5774a7.x2dfde153f4ef96d0();
			break;
		case PropertyType.DateTime:
			xd07ce4b74c5774a7.x2307058321cdb62f("vt:filetime");
			xd07ce4b74c5774a7.x3d1be38abe5723e3(xca004f56614e2431.x6efbf9d15154c80d(x5ca6b6e12a4d9043.ToDateTime()));
			xd07ce4b74c5774a7.x2dfde153f4ef96d0();
			break;
		default:
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("mhdpcjkpgibagjialipanhgbihnbgiecehlcahcdjcjdghaefhhepgoengffpfmfjgdgigkgkgbhoaihpfphbggiffniheejnalj", 1402073895)));
		}
	}
}
