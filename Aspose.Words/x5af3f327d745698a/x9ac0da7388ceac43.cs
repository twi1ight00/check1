using System;
using System.Collections;
using System.IO;
using System.Text;
using x011d489fb9df7027;
using x6c95d9cf46ff5f25;
using xb92b7270f78a4e8d;
using xfc5388ad7dff404f;

namespace x5af3f327d745698a;

internal class x9ac0da7388ceac43
{
	internal const string xdbfa5c6b25e04900 = "\u0001Ole10Native";

	internal const string xce29c4e66e204afd = "\u0003OCXNAME";

	internal const string xaa29b7c677c59f7e = "\u0003ObjInfo";

	internal const string xda019890dfa8c9c9 = "\u0003PRINT";

	internal const string xaab968b210f9d6e5 = "\u0003OCXDATA";

	internal const string xcffc253d2c11386b = "\u0001CompObj";

	internal const string x4eb8bf22a7273290 = "\u0003LinkInfo";

	internal const int x9fe22a5433833ed6 = 1281;

	private static readonly Hashtable x2b9f1ca7c209fa8d;

	internal static MemoryStream x0c9f09d67b375fe9(string x1fd8f5e5bbfdb602, byte[] x4635127e4d02b0c3)
	{
		xd8c3135513b9115b xd8c3135513b9115b = new xd8c3135513b9115b(x38fd54ed55196575(x1fd8f5e5bbfdb602));
		BinaryWriter binaryWriter = new BinaryWriter(new MemoryStream(x4635127e4d02b0c3.Length + 4));
		binaryWriter.Write(x4635127e4d02b0c3.Length);
		binaryWriter.Write(x4635127e4d02b0c3);
		xd8c3135513b9115b.x29e7ace4c90f74cd.Add("\u0001Ole10Native", binaryWriter.BaseStream);
		MemoryStream memoryStream = new MemoryStream();
		xd8c3135513b9115b.x0acd3c2012ea2ee8(memoryStream);
		return memoryStream;
	}

	internal static xe7be411416cfcd54 xf89ebf883c1c9c6d(Guid x9cd86cf00158857b, string x1fd8f5e5bbfdb602, xb7e718098524b76c x648e6e09d03a446a, bool xa3c32c64cb78d128)
	{
		xe7be411416cfcd54 xe7be411416cfcd = new xe7be411416cfcd54(x9cd86cf00158857b);
		xe7be411416cfcd.Add("Package", x648e6e09d03a446a.xb8a774e0111d0fbe);
		x4123eb825f799ecb(xe7be411416cfcd, new x5a72a7bc4849e9de(xa3c32c64cb78d128 ? x9db50866da3cf409.xb96cc45c13ecd384 : x9db50866da3cf409.x4d0b9d4447ba7566, xb86dce4d7748d175.xd69df86e2a88ddb2, x0c4de7b78d968e81.x5459fadea977d08d));
		x4123eb825f799ecb(xe7be411416cfcd, new xc869805892681306(x1fd8f5e5bbfdb602));
		return xe7be411416cfcd;
	}

	internal static string x58db9aaa4a730e59(BinaryReader xe134235b3526fa75)
	{
		return x58db9aaa4a730e59(xe134235b3526fa75, xe134235b3526fa75.ReadInt32());
	}

	internal static string x58db9aaa4a730e59(BinaryReader xe134235b3526fa75, int x961016a387451f05)
	{
		string result = "";
		if (x961016a387451f05 > 0)
		{
			byte[] bytes = xe134235b3526fa75.ReadBytes(x961016a387451f05 - 1);
			xe134235b3526fa75.ReadByte();
			result = Encoding.GetEncoding(1251).GetString(bytes);
		}
		return result;
	}

	internal static void xf6c2f11ceec579ae(BinaryWriter xbdfb620b7167944b, string xb41faee6912a2313)
	{
		xb41faee6912a2313 = ((xb41faee6912a2313 == null) ? "" : xb41faee6912a2313);
		xbdfb620b7167944b.Write(xb41faee6912a2313.Length + 1);
		xbdfb620b7167944b.Write(Encoding.GetEncoding(1251).GetBytes(xb41faee6912a2313));
		xbdfb620b7167944b.Write((byte)0);
	}

	internal static void x41d7feb042ee43f7(BinaryWriter xbdfb620b7167944b, string xb41faee6912a2313)
	{
		if (x0d299f323d241756.x5959bccb67bbf051(xb41faee6912a2313))
		{
			xf6c2f11ceec579ae(xbdfb620b7167944b, xb41faee6912a2313);
		}
		else
		{
			xbdfb620b7167944b.Write(0);
		}
	}

	internal static void x4123eb825f799ecb(xe7be411416cfcd54 x630baaeb4d769680, x8761581bef471ee5 x78fc7573bdcacc84)
	{
		MemoryStream memoryStream = new MemoryStream();
		x78fc7573bdcacc84.x6210059f049f0d48(new BinaryWriter(memoryStream));
		x630baaeb4d769680[x78fc7573bdcacc84.x759aa16c2016a289] = memoryStream;
	}

	internal static Guid x38fd54ed55196575(string x1fd8f5e5bbfdb602)
	{
		object obj = x2b9f1ca7c209fa8d[x1fd8f5e5bbfdb602];
		if (obj == null)
		{
			return Guid.Empty;
		}
		return new Guid((string)obj);
	}

	static x9ac0da7388ceac43()
	{
		x2b9f1ca7c209fa8d = new Hashtable();
		x2b9f1ca7c209fa8d.Add("MSDraw", "{00030007-0000-0000-C000-000000000046}");
		x2b9f1ca7c209fa8d.Add("PBrush", "{0003000a-0000-0000-C000-000000000046}");
		x2b9f1ca7c209fa8d.Add("Equation", "{0003000B-0000-0000-C000-000000000046}");
		x2b9f1ca7c209fa8d.Add("Package", "{0003000C-0000-0000-C000-000000000046}");
		x2b9f1ca7c209fa8d.Add("SoundRec", "{0003000D-0000-0000-C000-000000000046}");
		x2b9f1ca7c209fa8d.Add("MPlayer", "{0003000E-0000-0000-C000-000000000046}");
		x2b9f1ca7c209fa8d.Add("WPGraphic21", "{0004c8d8-0000-0000-c000-000000000046}");
		x2b9f1ca7c209fa8d.Add("PowerPoint.Show.12", "{CF4F55F4-8F87-4D47-80BB-5808164BB3F8}");
		x2b9f1ca7c209fa8d.Add("PowerPoint.Show.7", "{EA7BAE70-FB3B-11CD-A903-00AA00510EA3}");
		x2b9f1ca7c209fa8d.Add("PowerPoint.Show.8", "{64818D10-4F9B-11CF-86EA-00AA00B929E8}");
		x2b9f1ca7c209fa8d.Add("PowerPoint.ShowMacroEnabled.12", "{DC020317-E6E2-4A62-B9FA-B3EFE16626F4}");
		x2b9f1ca7c209fa8d.Add("PowerPoint.Slide.12", "{048EB43E-2059-422F-95E0-557DA96038AF}");
		x2b9f1ca7c209fa8d.Add("PowerPoint.Slide.7", "{EA7BAE71-FB3B-11CD-A903-00AA00510EA3}");
		x2b9f1ca7c209fa8d.Add("PowerPoint.Slide.8", "{64818D11-4F9B-11CF-86EA-00AA00B929E8}");
		x2b9f1ca7c209fa8d.Add("PowerPoint.SlideMacroEnabled.12", "{3C18EAE4-BC25-4134-B7DF-1ECA1337DDDC}");
		x2b9f1ca7c209fa8d.Add("PowerPoint.SlideShow.12", "{CF4F55F4-8F87-4D47-80BB-5808164BB3F8}");
		x2b9f1ca7c209fa8d.Add("PowerPoint.SlideShow.8", "{64818D10-4F9B-11CF-86EA-00AA00B929E8}");
		x2b9f1ca7c209fa8d.Add("PowerPoint.SlideShowMacroEnabled.12", "{DC020317-E6E2-4A62-B9FA-B3EFE16626F4}");
		x2b9f1ca7c209fa8d.Add("PowerPoint.Template.12", "{75D01070-1234-44E9-82F6-DB5B39A47C13}");
		x2b9f1ca7c209fa8d.Add("PowerPoint.Template.8", "{64818D11-4F9B-11CF-86EA-00AA00B929E8}");
		x2b9f1ca7c209fa8d.Add("PowerPoint.TemplateMacroEnabled.12", "{AA14F9C9-62B5-4637-8AC4-8F25BF29D5A7}");
		x2b9f1ca7c209fa8d.Add("PowerPoint.Wizard.8", "{64818D10-4F9B-11CF-86EA-00AA00B929E8}");
		x2b9f1ca7c209fa8d.Add("Word.Document.12", "{F4754C9B-64F5-4B40-8AF4-679732AC0607}");
		x2b9f1ca7c209fa8d.Add("Word.Document.6", "{00020900-0000-0000-C000-000000000046}");
		x2b9f1ca7c209fa8d.Add("Word.Document.8", "{00020906-0000-0000-C000-000000000046}");
		x2b9f1ca7c209fa8d.Add("Word.DocumentMacroEnabled.12", "{18A06B6B-2F3F-4E2B-A611-52BE631B2D22}");
		x2b9f1ca7c209fa8d.Add("Word.OpenDocumentText.12", "{1B261B22-AC6A-4E68-A870-AB5080E8687B}");
		x2b9f1ca7c209fa8d.Add("Word.Picture.6", "{00020901-0000-0000-C000-000000000046}");
		x2b9f1ca7c209fa8d.Add("Word.Picture.8", "{00020907-0000-0000-C000-000000000046}");
		x2b9f1ca7c209fa8d.Add("Word.RTF.8", "{00020906-0000-0000-C000-000000000046}");
		x2b9f1ca7c209fa8d.Add("Word.Template.12", "{912ABC52-36E2-4714-8E62-A8B73CA5E390}");
		x2b9f1ca7c209fa8d.Add("Word.Template.8", "{00020906-0000-0000-C000-000000000046}");
		x2b9f1ca7c209fa8d.Add("Word.TemplateMacroEnabled.12", "{8A624388-AA27-43E0-89F8-2A12BFF7BCCD}");
		x2b9f1ca7c209fa8d.Add("Excel.Application.12", "{00024500-0000-0000-C000-000000000046}");
		x2b9f1ca7c209fa8d.Add("Excel.Chart.5", "{00020811-0000-0000-C000-000000000046}");
		x2b9f1ca7c209fa8d.Add("Excel.Chart.8", "{00020821-0000-0000-C000-000000000046}");
		x2b9f1ca7c209fa8d.Add("Excel.CSV", "{00020832-0000-0000-C000-000000000046}");
		x2b9f1ca7c209fa8d.Add("Excel.OpenDocumentSpreadsheet.12", "{EABCECDB-CC1C-4A6F-B4E3-7F888A5ADFC8}");
		x2b9f1ca7c209fa8d.Add("Excel.Sheet.12", "{00020830-0000-0000-C000-000000000046}");
		x2b9f1ca7c209fa8d.Add("Excel.Sheet.5", "{00020810-0000-0000-C000-000000000046}");
		x2b9f1ca7c209fa8d.Add("Excel.Sheet.8", "{00020820-0000-0000-C000-000000000046}");
		x2b9f1ca7c209fa8d.Add("Excel.SheetBinaryMacroEnabled.12", "{00020833-0000-0000-C000-000000000046}");
		x2b9f1ca7c209fa8d.Add("Excel.SheetMacroEnabled.12", "{00020832-0000-0000-C000-000000000046}");
		x2b9f1ca7c209fa8d.Add("Excel.Template.8", "{00020820-0000-0000-C000-000000000046}");
		x2b9f1ca7c209fa8d.Add("Excel.TemplateMacroEnabled", "{00020832-0000-0000-C000-000000000046}");
		x2b9f1ca7c209fa8d.Add("Paint.Picture", "{D3E34B21-9D75-101A-8C3D-00AA001A1652}");
	}

	internal static void x8ba9ac9a5f4440e2(Stream xcf18e5243f8d5fd3, Stream xedc894794186020d)
	{
		if (xcf18e5243f8d5fd3 != null)
		{
			xcf18e5243f8d5fd3.Position = 0L;
			xe965bada78e2d6b1 xe965bada78e2d6b = new xe965bada78e2d6b1(xcf18e5243f8d5fd3);
			xa2f1c3dcbd86f20a xa2f1c3dcbd86f20a = xe965bada78e2d6b.x4bfdbcbc6a51d705(null, "http://schemas.openxmlformats.org/officeDocument/2006/relationships/officeDocument");
			StreamReader streamReader = new StreamReader(xa2f1c3dcbd86f20a.xb8a774e0111d0fbe);
			string text = streamReader.ReadToEnd();
			text = text.Replace("visibility=\"hidden\"", "");
			xa2f1c3dcbd86f20a.xb8a774e0111d0fbe = new MemoryStream();
			StreamWriter streamWriter = new StreamWriter(xa2f1c3dcbd86f20a.xb8a774e0111d0fbe, streamReader.CurrentEncoding);
			streamWriter.Write(text);
			streamWriter.Flush();
			xe965bada78e2d6b.Save(xedc894794186020d);
		}
	}

	internal static void x8d6e3a377c80585e(Stream xcf18e5243f8d5fd3)
	{
		if (xcf18e5243f8d5fd3 == null)
		{
			return;
		}
		xcf18e5243f8d5fd3.Position = 0L;
		BinaryReader binaryReader = new BinaryReader(xcf18e5243f8d5fd3);
		while (xcf18e5243f8d5fd3.Position < xcf18e5243f8d5fd3.Length)
		{
			int num = binaryReader.ReadInt16();
			int num2 = binaryReader.ReadInt16();
			if (num == 61)
			{
				binaryReader.ReadInt16();
				binaryReader.ReadInt16();
				binaryReader.ReadInt16();
				binaryReader.ReadInt16();
				int xbf5a7e14ee8e42b = binaryReader.ReadByte();
				xbf5a7e14ee8e42b = x26000ce44ebda9ea.x5ef51986c8da8183(xbf5a7e14ee8e42b, 1, xed7e1b20b1a14b86: false);
				xcf18e5243f8d5fd3.Position--;
				xcf18e5243f8d5fd3.WriteByte((byte)xbf5a7e14ee8e42b);
				break;
			}
			xcf18e5243f8d5fd3.Position += num2;
		}
	}
}
