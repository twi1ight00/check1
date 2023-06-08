using System;
using System.IO;
using System.Text;
using Aspose;
using Aspose.Words;
using x0a300997a0b66409;
using x1a3e96f4b89a7a77;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;
using xda075892eccab2ad;
using xf9a9481c3f63a419;

namespace xbe829a00a7a86dc3;

internal class xf7173b82df2a4de7 : x873451caae5ad4ae
{
	internal xf7173b82df2a4de7(Stream stream, bool isPrettyFormat)
		: base(stream, new UTF8Encoding(encoderShouldEmitUTF8Identifier: false), isPrettyFormat, useOnOff: true)
	{
	}

	[JavaThrows(true)]
	internal void x9b9ed0109b743e3b()
	{
		base.x5222f4285e37d66b.WriteStartDocument(standalone: true);
		base.x5222f4285e37d66b.WriteProcessingInstruction("mso-application", "progid=\"Word.Document\"");
		base.x5222f4285e37d66b.WriteStartElement("w:wordDocument");
	}

	protected override void WriteBorderCore(string elementName, Border border)
	{
		xc049ea80ee267201(elementName, "w:val", x0beb84bbfae8adcf.x5f971baf7ffd94ad(border.LineStyle), "w:sz", border.xab266ea415f07c09, "wx:bdrwidth", x4574ea26106f0edb.x88bf16f2386d633e(border.xeae235558dc44397), "w:space", border.x1f2d5df87a5c4f81, "w:color", border.x63b1a7c31a962459, "w:shadow", x873451caae5ad4ae.xee995edcf4ac3ea8(border.Shadow), "w:frame", x873451caae5ad4ae.xee995edcf4ac3ea8(border.x227665e444fb500a));
	}

	internal override void xbcea76c28b5e9461(Shading x12b7f8e5698b30a6)
	{
		if (x12b7f8e5698b30a6 != null && !x12b7f8e5698b30a6.xa157de8185757b11)
		{
			xc049ea80ee267201("w:shd", "w:val", x72a0c846678ecaf9.xb621a7efbad8540c(x12b7f8e5698b30a6.Texture, x5fbb1a9c98604ef5: false), "w:color", x12b7f8e5698b30a6.xc290f60df004e384, "w:fill", x12b7f8e5698b30a6.x0e18178ac4b2272f);
		}
	}

	internal override void xd0c5f01ab55153ce(x5fb16e270c21db2e xde2016e90885f436, string x121383aa64985888, int xeaf1b27180c0557b)
	{
		x92efd0e1687d8546(xeaf1b27180c0557b, xde2016e90885f436.xb063bbfcfeade526, xde2016e90885f436.x242851e6278ed355, "Word.Formatting");
		x2307058321cdb62f("aml:content");
	}

	internal override void xd0c5f01ab55153ce(xc1b2bac943a0f541 xde2016e90885f436, int xeaf1b27180c0557b)
	{
		string x43163d22e8cd5a = ((xde2016e90885f436.x3146d638ec378671 == x91bb72ac77aa7230.xf059562f878b500e) ? "Word.Insertion" : "Word.Deletion");
		x92efd0e1687d8546(xeaf1b27180c0557b, xde2016e90885f436.xb063bbfcfeade526, xde2016e90885f436.x242851e6278ed355, x43163d22e8cd5a);
		x2307058321cdb62f("aml:content");
	}

	internal override void x44d8d13f25d44840()
	{
		x2dfde153f4ef96d0("aml:content");
		x2dfde153f4ef96d0("aml:annotation");
	}

	internal override void xb24134df8aeb5772(x978620a99b6d5014 xde2016e90885f436, int xeaf1b27180c0557b)
	{
		string x43163d22e8cd5a = (xde2016e90885f436.x55e2dcfc986cb10b ? "Word.Insertion" : "Word.Numbering");
		x92efd0e1687d8546(xeaf1b27180c0557b, xde2016e90885f436.xb063bbfcfeade526, xde2016e90885f436.x242851e6278ed355, x43163d22e8cd5a);
		if (xde2016e90885f436.x22f16e8bb3c02a0b)
		{
			xff520a0047c27122("w:original", xc1b08afa36bf580c.xd304ca41be063396(xde2016e90885f436));
		}
		x2dfde153f4ef96d0("aml:annotation");
	}

	internal override void xb24134df8aeb5772(xc1b2bac943a0f541 xde2016e90885f436, int xeaf1b27180c0557b)
	{
		string x43163d22e8cd5a = ((xde2016e90885f436.x3146d638ec378671 == x91bb72ac77aa7230.xf059562f878b500e) ? "Word.Insertion" : "Word.Deletion");
		x92efd0e1687d8546(xeaf1b27180c0557b, xde2016e90885f436.xb063bbfcfeade526, xde2016e90885f436.x242851e6278ed355, x43163d22e8cd5a);
		x2dfde153f4ef96d0("aml:annotation");
	}

	private void x92efd0e1687d8546(int xeaf1b27180c0557b, string x984160c7f0248924, DateTime xb21f13a9707ad954, string x43163d22e8cd5a71)
	{
		x2307058321cdb62f("aml:annotation");
		x943f6be3acf634db("aml:id", xeaf1b27180c0557b);
		x943f6be3acf634db("aml:author", x984160c7f0248924);
		x943f6be3acf634db("aml:createdate", xca004f56614e2431.x6efbf9d15154c80d(xb21f13a9707ad954));
		x943f6be3acf634db("w:type", x43163d22e8cd5a71);
	}
}
