using System;
using System.IO;
using Aspose.Words;
using Aspose.Words.Drawing;
using Aspose.Words.Fields;
using x011d489fb9df7027;
using x13f1efc79617a47b;
using x1a62aaf14e3c5909;
using x28925c9b27b37a46;
using x884584cc69c5c378;
using xa604c4d210ae0581;
using xfbd1009a0cbb9842;

namespace x9e260ffa1ac41ffa;

internal class x8b8ab0cf32b35f3c
{
	private readonly x163859bfa28558c4 x80f57697b4c811e9;

	private readonly x7e738ecc9d58b06d x48d9a991d0b583f9;

	private static readonly xeedad81aaed42a76 x73b92b69a6ebbe12 = new xeedad81aaed42a76();

	internal x7e738ecc9d58b06d xbf993c53e1cbdfb1 => x48d9a991d0b583f9;

	internal x8b8ab0cf32b35f3c(x163859bfa28558c4 docWriter)
	{
		x80f57697b4c811e9 = docWriter;
		x48d9a991d0b583f9 = new x7e738ecc9d58b06d(docWriter.x2c8c6741422a1298, null);
	}

	internal VisitorAction xe158ae61ac75f37d(GroupShape x908338b83832d1aa)
	{
		x1a2622a1866b8f97(x908338b83832d1aa);
		return VisitorAction.Continue;
	}

	internal VisitorAction x964d9841100f787a(GroupShape x908338b83832d1aa)
	{
		return VisitorAction.Continue;
	}

	internal VisitorAction x1f70c910ab814928(Shape x5770cdefd8931aa9)
	{
		x1a2622a1866b8f97(x5770cdefd8931aa9);
		if (x5770cdefd8931aa9.HasChildNodes)
		{
			x772ab7293800e4d5(x5770cdefd8931aa9);
		}
		return VisitorAction.Continue;
	}

	internal VisitorAction xd96c4f9a469ee575(Shape x5770cdefd8931aa9)
	{
		if (x5770cdefd8931aa9.HasChildNodes)
		{
			x04fdae5454cacb40(x5770cdefd8931aa9);
		}
		return VisitorAction.Continue;
	}

	private void x772ab7293800e4d5(Shape x5770cdefd8931aa9)
	{
		x80f57697b4c811e9.xb264ad2ce3daa0a4(x93b05c1ad709a695.x991d17aba8ce15b3(x80f57697b4c811e9.x9e131021ba70185c));
		x10b00fc1d89e308c x10b00fc1d89e308c = new x10b00fc1d89e308c();
		x10b00fc1d89e308c.x5db45988d4e40802 = 1;
		x10b00fc1d89e308c.x1ef9a40b80c97477 = -1;
		x10b00fc1d89e308c.x835e4449b464b4ff = x5770cdefd8931aa9.xea1e81378298fa81;
		int num = x80f57697b4c811e9.x91774896a6f5023b(x10b00fc1d89e308c);
		x93bd964be1cf898b x93bd964be1cf898b = new x93bd964be1cf898b();
		x93bd964be1cf898b.xd81f84c63877d333 = num;
		x80f57697b4c811e9.x0f9832554a20d1bb(x93bd964be1cf898b);
		int x78871a21d651e = xed158952e6342987.x4961afe4ff4567c4(num);
		if (x5770cdefd8931aa9.xa170cce2bc40bdf5)
		{
			x5770cdefd8931aa9.OleFormat.x78871a21d651e673 = x78871a21d651e;
			return;
		}
		while (x5770cdefd8931aa9 != null)
		{
			x5770cdefd8931aa9.xc95ed8e8690eb564 = x78871a21d651e++;
			int xdf3d5f8941ea27a = x5770cdefd8931aa9.xdf3d5f8941ea27a6;
			x5770cdefd8931aa9 = ((xdf3d5f8941ea27a != 0) ? ((Shape)x80f57697b4c811e9.x8556eed81191af11.xe42bd130f1e95570[xdf3d5f8941ea27a]) : null);
		}
	}

	private void x04fdae5454cacb40(Shape x5770cdefd8931aa9)
	{
		Paragraph paragraph = new Paragraph(x5770cdefd8931aa9.Document);
		paragraph.Accept(x80f57697b4c811e9);
		x80f57697b4c811e9.xc4104b442b4f6eb6();
	}

	private void x1a2622a1866b8f97(ShapeBase x5770cdefd8931aa9)
	{
		if (x5770cdefd8931aa9.IsInline)
		{
			x84e71ff4edf2ec72(x5770cdefd8931aa9);
		}
		else
		{
			x2018d6badf068c86(x5770cdefd8931aa9);
		}
	}

	private void x84e71ff4edf2ec72(ShapeBase x5770cdefd8931aa9)
	{
		switch (x5770cdefd8931aa9.ShapeType)
		{
		case ShapeType.OleObject:
		case ShapeType.Image:
			x3ddd53fd6407e2d3((Shape)x5770cdefd8931aa9);
			return;
		case ShapeType.OleControl:
			x32fef8d2e27f6f68((Shape)x5770cdefd8931aa9);
			return;
		}
		if (x5770cdefd8931aa9.x3d318285d887cd3a)
		{
			x7ab5ac84420414e0(x5770cdefd8931aa9);
		}
		else
		{
			xd997354a8434b235(x5770cdefd8931aa9);
		}
	}

	private void x3ddd53fd6407e2d3(Shape x5770cdefd8931aa9)
	{
		if (x5770cdefd8931aa9.xbfc952aeef7fd0d5)
		{
			x80f57697b4c811e9.x544c864b2d73388d(FieldType.FieldHyperlink, x73b92b69a6ebbe12);
			xdfac57ec3a49a3fc xdfac57ec3a49a3fc = new xdfac57ec3a49a3fc(x5770cdefd8931aa9.x8edafc3cf6e5431a, x5770cdefd8931aa9.xffd5ab6c569c488d, x5770cdefd8931aa9.ScreenTip, x5770cdefd8931aa9.Target);
			x80f57697b4c811e9.x811fbd3fde91eb05(xdfac57ec3a49a3fc.ToString(), x73b92b69a6ebbe12);
			x80f57697b4c811e9.x2e2bbf4db242427d(x73b92b69a6ebbe12);
		}
		if (x5770cdefd8931aa9.ShapeType == ShapeType.Image)
		{
			x20db457a8342c28f(x5770cdefd8931aa9);
		}
		else
		{
			x32fef8d2e27f6f68(x5770cdefd8931aa9);
		}
		if (x5770cdefd8931aa9.xbfc952aeef7fd0d5)
		{
			x80f57697b4c811e9.xfc282418f4ca7fa7(FieldType.FieldHyperlink, x73b92b69a6ebbe12, x4797cf69c5ec19ff: true);
		}
	}

	private void x20db457a8342c28f(Shape x5770cdefd8931aa9)
	{
		if (x5770cdefd8931aa9.ImageData.IsLink)
		{
			x5907707870dfe8ca(x5770cdefd8931aa9);
		}
		else
		{
			xd997354a8434b235(x5770cdefd8931aa9);
		}
	}

	private void x5907707870dfe8ca(Shape x5770cdefd8931aa9)
	{
		if (!x80f57697b4c811e9.x5124b2bcc12d5218)
		{
			x80f57697b4c811e9.x544c864b2d73388d(FieldType.FieldIncludePicture, x73b92b69a6ebbe12);
			string text = $" INCLUDEPICTURE {xb7dbd7bb3ed97d5b.x0b0647af7a5ab290(x5770cdefd8931aa9.ImageData.SourceFullName)} \\* MERGEFORMAT ";
			if (x5770cdefd8931aa9.ImageData.IsLinkOnly)
			{
				text += "\\d ";
			}
			x80f57697b4c811e9.x811fbd3fde91eb05(text, x73b92b69a6ebbe12);
			x80f57697b4c811e9.x2e2bbf4db242427d(x73b92b69a6ebbe12);
		}
		xd997354a8434b235(x5770cdefd8931aa9);
		if (!x80f57697b4c811e9.x5124b2bcc12d5218)
		{
			x80f57697b4c811e9.xfc282418f4ca7fa7(FieldType.FieldIncludePicture, x73b92b69a6ebbe12, x4797cf69c5ec19ff: true);
		}
	}

	private void x7ab5ac84420414e0(ShapeBase x5770cdefd8931aa9)
	{
		x80f57697b4c811e9.x544c864b2d73388d(FieldType.FieldShape, x73b92b69a6ebbe12);
		x80f57697b4c811e9.x811fbd3fde91eb05(" SHAPE  \\* MERGEFORMAT ", x73b92b69a6ebbe12);
		x80f57697b4c811e9.x2e2bbf4db242427d(x73b92b69a6ebbe12);
		x4d04bff8a4c56cac(x5770cdefd8931aa9);
		xd997354a8434b235(x5770cdefd8931aa9);
		x80f57697b4c811e9.xfc282418f4ca7fa7(FieldType.FieldShape, x73b92b69a6ebbe12, x4797cf69c5ec19ff: true);
	}

	private void x32fef8d2e27f6f68(Shape x5770cdefd8931aa9)
	{
		FieldType x77ce91e5324df;
		string xb41faee6912a;
		switch (x5770cdefd8931aa9.ShapeType)
		{
		case ShapeType.OleObject:
			if (x5770cdefd8931aa9.OleFormat.IsLink)
			{
				x77ce91e5324df = FieldType.FieldLink;
				xb41faee6912a = xcae1c68ad9da73de.xda09af88ab899a50(x5770cdefd8931aa9.OleFormat);
			}
			else
			{
				x77ce91e5324df = FieldType.FieldEmbed;
				xb41faee6912a = x623dea19444a5371.xda09af88ab899a50(x5770cdefd8931aa9.OleFormat.ProgId);
			}
			break;
		case ShapeType.OleControl:
			x77ce91e5324df = FieldType.FieldOcx;
			xb41faee6912a = x7ada41eb09239afd.xda09af88ab899a50(x5770cdefd8931aa9.OleFormat.ProgId);
			break;
		default:
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("emklknbmomimonpmdngnfmnnameoomlomlcpiljpbhaabmhadloajkfbflmbhkdcpfkcalbdclidgkpdijgeofne", 1222097519)));
		}
		x80f57697b4c811e9.x544c864b2d73388d(x77ce91e5324df, x73b92b69a6ebbe12);
		x80f57697b4c811e9.x811fbd3fde91eb05(xb41faee6912a, x73b92b69a6ebbe12);
		if (x5770cdefd8931aa9.OleFormat.x58932c7e6fa3b905 != null)
		{
			x80f57697b4c811e9.xf1f82fcde3b22573(x73b92b69a6ebbe12, x5770cdefd8931aa9.OleFormat.x58932c7e6fa3b905.xea1e81378298fa81);
			x71d39fdf56861cca x71d39fdf56861cca = x5770cdefd8931aa9.OleFormat.x71d39fdf56861cca;
			if (x71d39fdf56861cca != null && x71d39fdf56861cca.xe9996a8329ef750a && x71d39fdf56861cca.x763bd29719f4b2e4 != null)
			{
				x36dd3edbb5b1c80f(x71d39fdf56861cca);
			}
			else
			{
				xd997354a8434b235(x5770cdefd8931aa9);
			}
		}
		else
		{
			x80f57697b4c811e9.xf1f82fcde3b22573(x73b92b69a6ebbe12, 0);
			xd997354a8434b235(x5770cdefd8931aa9);
		}
		x80f57697b4c811e9.xfc282418f4ca7fa7(x77ce91e5324df, x73b92b69a6ebbe12, x4797cf69c5ec19ff: true);
	}

	private void xd997354a8434b235(ShapeBase x5770cdefd8931aa9)
	{
		Stream baseStream = x80f57697b4c811e9.xbb10bb9e03e33a16.BaseStream;
		BinaryWriter xbb10bb9e03e33a = x80f57697b4c811e9.xbb10bb9e03e33a16;
		int num = (int)baseStream.Position;
		xa52f2632c0ffdfaf xa52f2632c0ffdfaf = new xa52f2632c0ffdfaf();
		xa52f2632c0ffdfaf.xa1a25be53d0a44c8 = true;
		xa52f2632c0ffdfaf.xf1d9b91c9700c401 = num;
		xeedad81aaed42a76 x789564759d = (x5770cdefd8931aa9.x3d318285d887cd3a ? x73b92b69a6ebbe12 : x5770cdefd8931aa9.xeedad81aaed42a76);
		x80f57697b4c811e9.x811fbd3fde91eb05(ControlChar.x7f4d496937f8c24c, x789564759d, xa52f2632c0ffdfaf);
		x409512556c3f2a9a x409512556c3f2a9a = new x409512556c3f2a9a(x5770cdefd8931aa9);
		x409512556c3f2a9a.x6210059f049f0d48(xbb10bb9e03e33a);
		if (x5770cdefd8931aa9.CanHaveImage)
		{
			Shape shape = (Shape)x5770cdefd8931aa9;
			if (shape.ImageData.IsLinkOnly)
			{
				x93b05c1ad709a695.x4a3c44ae9b1cf5ab(shape.ImageData.SourceFullName, int.MaxValue, xbb10bb9e03e33a, x5be1cad1d00af914: false, xac1baf51b3e43d13: false);
			}
		}
		x821732b125012c9e.x84e71ff4edf2ec72(x5770cdefd8931aa9, xbb10bb9e03e33a);
		int num2 = (int)baseStream.Position;
		x409512556c3f2a9a.xf280755e03a40325 = num2 - num;
		baseStream.Position = num;
		x409512556c3f2a9a.x6210059f049f0d48(xbb10bb9e03e33a);
		baseStream.Position = num2;
	}

	private void x36dd3edbb5b1c80f(x71d39fdf56861cca xb7b1409b12ce2ee3)
	{
		xa52f2632c0ffdfaf xa52f2632c0ffdfaf = new xa52f2632c0ffdfaf();
		xa52f2632c0ffdfaf.xa1a25be53d0a44c8 = true;
		xa52f2632c0ffdfaf.xc26441db92a14e8e = true;
		xa52f2632c0ffdfaf.xf1d9b91c9700c401 = xb7b1409b12ce2ee3.xea1e81378298fa81;
		x80f57697b4c811e9.x811fbd3fde91eb05(ControlChar.x7f4d496937f8c24c, x73b92b69a6ebbe12, xa52f2632c0ffdfaf);
	}

	private void x2018d6badf068c86(ShapeBase x5770cdefd8931aa9)
	{
		if (x5770cdefd8931aa9.IsTopLevel)
		{
			x4d04bff8a4c56cac(x5770cdefd8931aa9);
		}
		if (x5770cdefd8931aa9.xa170cce2bc40bdf5)
		{
			Shape shape = (Shape)x5770cdefd8931aa9;
			x772ab7293800e4d5(shape);
			Paragraph paragraph = new Paragraph(x5770cdefd8931aa9.Document);
			x80f57697b4c811e9.VisitParagraphStart(paragraph);
			WrapType wrapType = shape.WrapType;
			shape.WrapType = WrapType.Inline;
			x32fef8d2e27f6f68(shape);
			shape.WrapType = wrapType;
			x80f57697b4c811e9.VisitParagraphEnd(paragraph);
			x04fdae5454cacb40(shape);
		}
	}

	private void x4d04bff8a4c56cac(ShapeBase x5770cdefd8931aa9)
	{
		x48d9a991d0b583f9.xa8a795be8f94b493(x5770cdefd8931aa9, x93b05c1ad709a695.x7625b7f02c65c1cd(x80f57697b4c811e9.x9e131021ba70185c));
		xac083244a6c1aa10 x88b222290ee177b = new xac083244a6c1aa10(x5770cdefd8931aa9);
		x80f57697b4c811e9.x51bc52e131b1c9e3(x88b222290ee177b);
		x80f57697b4c811e9.x811fbd3fde91eb05(x6fdf2cb781297060.xacef394f1c66cfd7, x5770cdefd8931aa9.xeedad81aaed42a76, x163859bfa28558c4.x70f4aa19e59d65fd);
	}
}
