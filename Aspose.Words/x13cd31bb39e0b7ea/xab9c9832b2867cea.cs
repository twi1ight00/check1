using System.IO;
using Aspose.Words;
using Aspose.Words.Math;
using Aspose.Words.Saving;
using x28925c9b27b37a46;
using x2cc366c8657e2b6a;
using xbe829a00a7a86dc3;

namespace x13cd31bb39e0b7ea;

internal class xab9c9832b2867cea
{
	private xab9c9832b2867cea()
	{
	}

	internal static OfficeMath x30e76621c2448675(byte[] xde89b10d4ff89f23)
	{
		StreamReader streamReader = new StreamReader(new MemoryStream(xde89b10d4ff89f23));
		Document document = new Document(isLoadBlank: false);
		x21a61af92fc2a45e x21a61af92fc2a45e = new x21a61af92fc2a45e(streamReader.BaseStream, document, new LoadOptions(), readEquationXml: true);
		x21a61af92fc2a45e.x06b0e25aa6ad68a9();
		Paragraph firstParagraph = document.FirstSection.Body.FirstParagraph;
		return (OfficeMath)firstParagraph.FirstChild;
	}

	internal static byte[] xad06e5b7913f38fa(OfficeMath x203bd7b4a3be8d02)
	{
		Document document = new Document();
		Paragraph firstParagraph = document.FirstSection.Body.FirstParagraph;
		firstParagraph.xdf7453d9fdf3f262(x203bd7b4a3be8d02);
		MemoryStream memoryStream = new MemoryStream();
		x4f037d20d40d8390 x4f037d20d40d = new x4f037d20d40d8390();
		x4f037d20d40d.xbbb9faf31c170b64 = true;
		x3d2908992e1d1667 x3d2908992e1d = x4f037d20d40d;
		x8556eed81191af11 x5ac1382edb7bf2c = new x8556eed81191af11(document, memoryStream, string.Empty, SaveOptions.CreateSaveOptions(SaveFormat.WordML));
		x3d2908992e1d.xa2e0b7f7da663553(x5ac1382edb7bf2c);
		return memoryStream.ToArray();
	}
}
