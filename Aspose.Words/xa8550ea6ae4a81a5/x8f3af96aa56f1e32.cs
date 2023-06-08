using System;
using System.Collections;
using System.Text;
using Aspose.Words;
using Aspose.Words.Saving;
using x1a3e96f4b89a7a77;
using x28925c9b27b37a46;
using x5794c252ba25e723;
using x909757d9fd2dd6ae;
using xda075892eccab2ad;
using xf9a9481c3f63a419;
using xfc5388ad7dff404f;

namespace xa8550ea6ae4a81a5;

internal class x8f3af96aa56f1e32 : x873451caae5ad4ae
{
	private readonly xa2f1c3dcbd86f20a x9fb0e9c0b1bdc4b3;

	private ArrayList x59fc0436dd9fe5df;

	private string x10bde6ac368e0f3f;

	private readonly OoxmlCompliance x38f73f642a5eb695;

	internal override bool xa35b0cf71c822836 => x9fb0e9c0b1bdc4b3.x0b93856f95be30d0 == "application/vnd.openxmlformats-officedocument.wordprocessingml.styles+xml";

	internal xa2f1c3dcbd86f20a x398b3bd0acd94b61 => x9fb0e9c0b1bdc4b3;

	internal ArrayList xa5a04b025492f124
	{
		get
		{
			if (x59fc0436dd9fe5df == null)
			{
				x59fc0436dd9fe5df = new ArrayList();
			}
			return x59fc0436dd9fe5df;
		}
	}

	internal string xb673df6aa8c79149
	{
		get
		{
			return x10bde6ac368e0f3f;
		}
		set
		{
			x10bde6ac368e0f3f = value;
		}
	}

	internal OoxmlCompliance xd115f8f0cdf9cf2f => x38f73f642a5eb695;

	internal x8f3af96aa56f1e32(xa2f1c3dcbd86f20a part, bool isPrettyFormat, OoxmlCompliance compliance)
		: base(part.xb8a774e0111d0fbe, Encoding.UTF8, isPrettyFormat, compliance == OoxmlCompliance.Ecma376_2006)
	{
		x9fb0e9c0b1bdc4b3 = part;
		x38f73f642a5eb695 = compliance;
	}

	internal void x454da6e050647673(string x766ce0458c714584)
	{
		x9b9ed0109b743e3b(x766ce0458c714584);
		xff520a0047c27122("xmlns:ve", "http://schemas.openxmlformats.org/markup-compatibility/2006");
		xff520a0047c27122("xmlns:o", "urn:schemas-microsoft-com:office:office");
		xff520a0047c27122("xmlns:r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
		xff520a0047c27122("xmlns:m", "http://schemas.openxmlformats.org/officeDocument/2006/math");
		xff520a0047c27122("xmlns:v", "urn:schemas-microsoft-com:vml");
		xff520a0047c27122("xmlns:wp", "http://schemas.openxmlformats.org/drawingml/2006/wordprocessingDrawing");
		xff520a0047c27122("xmlns:w10", "urn:schemas-microsoft-com:office:word");
		xff520a0047c27122("xmlns:w", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
		xff520a0047c27122("xmlns:wne", "http://schemas.microsoft.com/office/word/2006/wordml");
	}

	internal void x17784f246e4754b0(string x766ce0458c714584)
	{
		x454da6e050647673(x766ce0458c714584);
		xff520a0047c27122("xmlns:mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
		xff520a0047c27122("xmlns:wpc", "http://schemas.microsoft.com/office/word/2010/wordprocessingCanvas");
		xff520a0047c27122("xmlns:wp14", "http://schemas.microsoft.com/office/word/2010/wordprocessingDrawing");
		xff520a0047c27122("xmlns:w14", "http://schemas.microsoft.com/office/word/2010/wordml");
		xff520a0047c27122("xmlns:wpg", "http://schemas.microsoft.com/office/word/2010/wordprocessingGroup");
		xff520a0047c27122("xmlns:wpi", "http://schemas.microsoft.com/office/word/2010/wordprocessingInk");
		xff520a0047c27122("xmlns:wps", "http://schemas.microsoft.com/office/word/2010/wordprocessingShape");
	}

	protected override void WriteBorderCore(string elementName, Border border)
	{
		xc049ea80ee267201(elementName, "w:val", xc62574be95c1c918.x95c1627f7e5c3be9(border.LineStyle), "w:sz", border.xab266ea415f07c09, "w:space", border.x1f2d5df87a5c4f81, "w:color", border.x63b1a7c31a962459, "w:themeColor", border.x19119439284aead2, "w:themeShade", border.x545df332a972f97f, "w:themeTint", border.xc7a5a1bef7198132, "w:shadow", x873451caae5ad4ae.xee995edcf4ac3ea8(border.Shadow), "w:frame", x873451caae5ad4ae.xee995edcf4ac3ea8(border.x227665e444fb500a));
	}

	internal override void xbcea76c28b5e9461(Shading x12b7f8e5698b30a6)
	{
		if (x12b7f8e5698b30a6 != null && !x12b7f8e5698b30a6.xa157de8185757b11)
		{
			xc049ea80ee267201("w:shd", "w:val", x72a0c846678ecaf9.xb621a7efbad8540c(x12b7f8e5698b30a6.Texture, x5fbb1a9c98604ef5: true), "w:color", x12b7f8e5698b30a6.xc290f60df004e384, "w:fill", x12b7f8e5698b30a6.x0e18178ac4b2272f, "w:themeColor", x12b7f8e5698b30a6.x19119439284aead2, "w:themeShade", x12b7f8e5698b30a6.x545df332a972f97f, "w:themeTint", x12b7f8e5698b30a6.xc7a5a1bef7198132, "w:themeFill", x12b7f8e5698b30a6.xdb84466ee4f5c751, "w:themeFillShade", x12b7f8e5698b30a6.x3799d35904b4df9e, "w:themeFillTint", x12b7f8e5698b30a6.x32bc86f72d097c5d);
		}
	}

	internal void x2023716b7b909631(string x121383aa64985888, bool xbcea506a33cf9111)
	{
		x547195bcc386fe66(x121383aa64985888, xbcea506a33cf9111 ? "1" : "0");
	}

	internal override void x547195bcc386fe66(string x121383aa64985888, bool xbcea506a33cf9111)
	{
		if (xbcea506a33cf9111)
		{
			xf68f9c3818e1f4b1(x121383aa64985888);
		}
		else
		{
			x547195bcc386fe66(x121383aa64985888, "0");
		}
	}

	internal override void x943f6be3acf634db(string x9e89cc6e6284edf4, bool xbcea506a33cf9111)
	{
		xff520a0047c27122(x9e89cc6e6284edf4, xbcea506a33cf9111 ? "1" : "0");
	}

	internal override void x0ea3ef8dd3ae2f3f(string x9e89cc6e6284edf4, bool xbcea506a33cf9111)
	{
		if (xbcea506a33cf9111)
		{
			xff520a0047c27122(x9e89cc6e6284edf4, "1");
		}
	}

	internal override void xd0c5f01ab55153ce(x5fb16e270c21db2e xde2016e90885f436, string x121383aa64985888, int xeaf1b27180c0557b)
	{
		x92efd0e1687d8546(x121383aa64985888, xeaf1b27180c0557b, xde2016e90885f436.xb063bbfcfeade526, xde2016e90885f436.x242851e6278ed355);
	}

	internal override void xd0c5f01ab55153ce(xc1b2bac943a0f541 xde2016e90885f436, int xeaf1b27180c0557b)
	{
		string x121383aa = ((xde2016e90885f436.x3146d638ec378671 == x91bb72ac77aa7230.xf059562f878b500e) ? "w:ins" : "w:del");
		x92efd0e1687d8546(x121383aa, xeaf1b27180c0557b, xde2016e90885f436.xb063bbfcfeade526, xde2016e90885f436.x242851e6278ed355);
	}

	internal override void x44d8d13f25d44840()
	{
		x2dfde153f4ef96d0();
	}

	internal override void xb24134df8aeb5772(x978620a99b6d5014 xde2016e90885f436, int xeaf1b27180c0557b)
	{
		string x121383aa = (xde2016e90885f436.x55e2dcfc986cb10b ? "w:ins" : "w:numberingChange");
		x92efd0e1687d8546(x121383aa, xeaf1b27180c0557b, xde2016e90885f436.xb063bbfcfeade526, xde2016e90885f436.x242851e6278ed355);
		if (xde2016e90885f436.x22f16e8bb3c02a0b)
		{
			xff520a0047c27122("w:original", xc1b08afa36bf580c.xd304ca41be063396(xde2016e90885f436));
		}
		x2dfde153f4ef96d0(x121383aa);
	}

	internal override void xb24134df8aeb5772(xc1b2bac943a0f541 xde2016e90885f436, int xeaf1b27180c0557b)
	{
		string x121383aa = ((xde2016e90885f436.x3146d638ec378671 == x91bb72ac77aa7230.xf059562f878b500e) ? "w:ins" : "w:del");
		x92efd0e1687d8546(x121383aa, xeaf1b27180c0557b, xde2016e90885f436.xb063bbfcfeade526, xde2016e90885f436.x242851e6278ed355);
		x2dfde153f4ef96d0(x121383aa);
	}

	private void x92efd0e1687d8546(string x121383aa64985888, int xeaf1b27180c0557b, string x984160c7f0248924, DateTime xb21f13a9707ad954)
	{
		x2307058321cdb62f(x121383aa64985888);
		x943f6be3acf634db("w:id", xeaf1b27180c0557b);
		x943f6be3acf634db("w:author", x984160c7f0248924);
		x943f6be3acf634db("w:date", xca004f56614e2431.x6efbf9d15154c80d(xb21f13a9707ad954));
	}

	internal void x942df950ff3fdafd(string x4c12babe29167a55, string xc06e652f250a3786)
	{
		x2307058321cdb62f(x4c12babe29167a55);
		xff520a0047c27122("r:id", xc06e652f250a3786);
		x2dfde153f4ef96d0();
	}

	internal string xb12f52d1ec4f4369(x26d9ecb4bdf0456d x6c50a99faab7d741)
	{
		return $"{xca004f56614e2431.x06423d8cf62a0672(x6c50a99faab7d741.xc613adc4330033f3)}{xca004f56614e2431.x06423d8cf62a0672(x6c50a99faab7d741.x26463655896fd90a)}{xca004f56614e2431.x06423d8cf62a0672(x6c50a99faab7d741.x8e8f6cc6a0756b05)}";
	}
}
