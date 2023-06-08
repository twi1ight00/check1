using System.IO;
using System.Text;
using x5af3f327d745698a;
using x6c95d9cf46ff5f25;
using x909757d9fd2dd6ae;
using xb92b7270f78a4e8d;

namespace x011d489fb9df7027;

internal class x71d39fdf56861cca : xd142dcacd7ddc9dd
{
	private xe7be411416cfcd54 x73f065a6b420cfe1;

	internal MemoryStream x763bd29719f4b2e4 => (MemoryStream)x73f065a6b420cfe1["\u0003META"];

	internal MemoryStream x6a0060cc731d6605 => (MemoryStream)x73f065a6b420cfe1["\u0003PIC"];

	internal MemoryStream x465d916934467633 => (MemoryStream)x73f065a6b420cfe1["\u0001Ole10Native"];

	internal MemoryStream x70813fadbf467780 => (MemoryStream)x73f065a6b420cfe1["\u0001CompObj"];

	internal bool xe9996a8329ef750a => x465d916934467633 != null;

	internal xe7be411416cfcd54 x6b73aa01aa019d3a
	{
		get
		{
			return x73f065a6b420cfe1;
		}
		set
		{
			x73f065a6b420cfe1 = value;
		}
	}

	internal x71d39fdf56861cca(xe7be411416cfcd54 data)
		: this(0, data)
	{
	}

	internal x71d39fdf56861cca(int id, xe7be411416cfcd54 data)
	{
		x73f065a6b420cfe1 = data;
		base.xea1e81378298fa81 = id;
	}

	internal override string x1dcf998e2740773a(string x1fd8f5e5bbfdb602)
	{
		if (x1fd8f5e5bbfdb602.StartsWith("Excel.Sheet.8"))
		{
			return "application/vnd.ms-excel";
		}
		if (x1fd8f5e5bbfdb602.StartsWith("Word.Document.8"))
		{
			return "application/msword";
		}
		if (x1fd8f5e5bbfdb602.StartsWith("PowerPoint.Show.8"))
		{
			return "application/vnd.ms-powerpoint";
		}
		return "application/vnd.openxmlformats-officedocument.oleObject";
	}

	internal override string x42fe3274236becd5(string x1fd8f5e5bbfdb602)
	{
		string text = xc62574be95c1c918.x7cfd9d683a359925(x1dcf998e2740773a(x1fd8f5e5bbfdb602));
		if (text != ".bin")
		{
			return text;
		}
		if (x1fd8f5e5bbfdb602.StartsWith("Excel.Sheet.12"))
		{
			return ".xlsx";
		}
		if (x1fd8f5e5bbfdb602.StartsWith("Word.Document.12"))
		{
			return ".docx";
		}
		if (x1fd8f5e5bbfdb602.StartsWith("PowerPoint.Show.12"))
		{
			return ".pptx";
		}
		if (x1fd8f5e5bbfdb602.StartsWith("PowerPoint.Slide.12"))
		{
			return ".sldx";
		}
		if (x1fd8f5e5bbfdb602.StartsWith("Excel.OpenDocumentSpreadsheet"))
		{
			return ".ods";
		}
		if (x1fd8f5e5bbfdb602.StartsWith("Word.OpenDocumentText"))
		{
			return ".odt";
		}
		if (x1fd8f5e5bbfdb602.StartsWith("PowerPoint.OpenDocumentPresentation"))
		{
			return ".odp";
		}
		if (x1fd8f5e5bbfdb602.StartsWith("AcroExch.Document"))
		{
			return ".pdf";
		}
		if (x1fd8f5e5bbfdb602.StartsWith("MailMsgAtt") || x1fd8f5e5bbfdb602.StartsWith("Outlook.MsgAttach"))
		{
			return ".msg";
		}
		if (xe9996a8329ef750a)
		{
			return Path.GetExtension(x684dfe8d1a308be0()).ToLower();
		}
		return ".bin";
	}

	internal override void x2961bf88b232b7a8(Stream xcf18e5243f8d5fd3, string x1fd8f5e5bbfdb602)
	{
		if (xe9996a8329ef750a)
		{
			xfd91a4aed8109e9b(xcf18e5243f8d5fd3);
		}
		else
		{
			x8215414f9df662e2(xcf18e5243f8d5fd3, x1fd8f5e5bbfdb602);
		}
	}

	internal string x684dfe8d1a308be0()
	{
		BinaryReader binaryReader = x9c9a34dc0dea81dd();
		if (binaryReader != null)
		{
			xd11a6e043172eeb6 xd11a6e043172eeb7 = new xd11a6e043172eeb6(binaryReader);
			if (xd11a6e043172eeb7.x329e3c69afa4fbe7 == 2)
			{
				return xd11a6e043172eeb7.xba89ca2127612c56;
			}
		}
		return "";
	}

	private void xfd91a4aed8109e9b(Stream xedc894794186020d)
	{
		BinaryReader binaryReader = x9c9a34dc0dea81dd();
		if (binaryReader == null)
		{
			return;
		}
		xd11a6e043172eeb6 xd11a6e043172eeb7 = new xd11a6e043172eeb6(binaryReader);
		if (xd11a6e043172eeb7.x329e3c69afa4fbe7 == 2)
		{
			switch (xd11a6e043172eeb7.xf9ae63fc557debf2)
			{
			case 3:
			{
				byte[] array = new byte[xd11a6e043172eeb7.x00917a4a76319d76];
				binaryReader.Read(array, 0, array.Length);
				xedc894794186020d.Write(array, 0, array.Length);
				break;
			}
			case 1:
			case 2:
				break;
			}
		}
		else
		{
			x465d916934467633.Position = 4L;
			x0d299f323d241756.x3ad8e53785c39acd(x465d916934467633, xedc894794186020d);
		}
	}

	private BinaryReader x9c9a34dc0dea81dd()
	{
		if (x465d916934467633.Length == 0)
		{
			return null;
		}
		x465d916934467633.Position = 0L;
		return new BinaryReader(x465d916934467633, Encoding.ASCII);
	}

	private void x8215414f9df662e2(Stream xcf18e5243f8d5fd3, string x1fd8f5e5bbfdb602)
	{
		MemoryStream memoryStream = null;
		xe7be411416cfcd54 xe7be411416cfcd = null;
		if (x1fd8f5e5bbfdb602.StartsWith("Excel.Sheet.8"))
		{
			Stream xcf18e5243f8d5fd4 = x73f065a6b420cfe1["Workbook"] as MemoryStream;
			x9ac0da7388ceac43.x8d6e3a377c80585e(xcf18e5243f8d5fd4);
		}
		else if (x1fd8f5e5bbfdb602.StartsWith("Excel.Sheet.12"))
		{
			memoryStream = new MemoryStream();
			x9ac0da7388ceac43.x8ba9ac9a5f4440e2(x73f065a6b420cfe1["Package"] as MemoryStream, memoryStream);
		}
		else if (x1fd8f5e5bbfdb602.StartsWith("Word.Document.12") || x1fd8f5e5bbfdb602.StartsWith("PowerPoint.Show.12"))
		{
			memoryStream = x73f065a6b420cfe1["Package"] as MemoryStream;
		}
		else if (x1fd8f5e5bbfdb602.StartsWith("Excel.OpenDocumentSpreadsheet") || x1fd8f5e5bbfdb602.StartsWith("Word.OpenDocumentText") || x1fd8f5e5bbfdb602.StartsWith("PowerPoint.OpenDocumentPresentation"))
		{
			memoryStream = x73f065a6b420cfe1["EmbeddedOdf"] as MemoryStream;
		}
		else if (x1fd8f5e5bbfdb602.StartsWith("Outlook.FileAttach"))
		{
			memoryStream = x73f065a6b420cfe1["AttachContents"] as MemoryStream;
		}
		else if (x1fd8f5e5bbfdb602.StartsWith("AcroExch.Document"))
		{
			memoryStream = x73f065a6b420cfe1["CONTENTS"] as MemoryStream;
		}
		else if (x1fd8f5e5bbfdb602.StartsWith("MailMsgAtt") || x1fd8f5e5bbfdb602.StartsWith("Outlook.MsgAttach"))
		{
			xe7be411416cfcd = x73f065a6b420cfe1["MAPIMessage"] as xe7be411416cfcd54;
		}
		if (memoryStream != null)
		{
			memoryStream.Position = 0L;
			x0d299f323d241756.x3ad8e53785c39acd(memoryStream, xcf18e5243f8d5fd3);
		}
		else
		{
			x0c8db7c25ea9c4a1(xcf18e5243f8d5fd3, (xe7be411416cfcd != null) ? xe7be411416cfcd : x73f065a6b420cfe1);
		}
	}

	private static void x0c8db7c25ea9c4a1(Stream xcf18e5243f8d5fd3, xe7be411416cfcd54 x92ce2735a79dd7d7)
	{
		xd8c3135513b9115b xd8c3135513b9115b = new xd8c3135513b9115b(x92ce2735a79dd7d7);
		xd8c3135513b9115b.x0acd3c2012ea2ee8(xcf18e5243f8d5fd3);
	}
}
