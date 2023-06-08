using System;
using System.Xml;
using Aspose.Words.Drawing;
using x011d489fb9df7027;
using x1a3e96f4b89a7a77;
using x4c895f6c49b1bff5;
using x6c95d9cf46ff5f25;
using xa8550ea6ae4a81a5;
using xf9a9481c3f63a419;
using xfc5388ad7dff404f;

namespace x7e88666148babfd9;

internal class x0a31990bebe3c214
{
	private readonly xdb4554d64207e940 xc96375eb06b33c8a = new xdb4554d64207e940();

	private DrawingML x61f18ca85b7c2226;

	private xaf66e8c590b2b553 x9b287b671d592594;

	internal void x6210059f049f0d48(DrawingML xb3c5925d90ebc5f0, xaf66e8c590b2b553 xbdfb620b7167944b)
	{
		x61f18ca85b7c2226 = xb3c5925d90ebc5f0;
		x9b287b671d592594 = xbdfb620b7167944b;
		x5188fe68817c1b1e(xb3c5925d90ebc5f0.x169b8a3bc8f77f64);
		x873451caae5ad4ae xca93abf9292cd4f = xbdfb620b7167944b.xca93abf9292cd4f1;
		xca93abf9292cd4f.x2307058321cdb62f("w:drawing");
		xc96375eb06b33c8a.x74f5a1ef3906e23c();
		xc96375eb06b33c8a.x6a81a30bcaf20a97(xb3c5925d90ebc5f0.xf7125312c7ee115c);
		xca93abf9292cd4f.x2307058321cdb62f(xb3c5925d90ebc5f0.xf7125312c7ee115c.xc5bb70cfaaae4a20 ? "wp:inline" : "wp:anchor");
		xca93abf9292cd4f.x943f6be3acf634db("distT", xc96375eb06b33c8a.x027754ea63804113);
		xca93abf9292cd4f.x943f6be3acf634db("distB", xc96375eb06b33c8a.x4dc0360afcf78834);
		xca93abf9292cd4f.x943f6be3acf634db("distL", xc96375eb06b33c8a.xc9ee264fd8d7484e);
		xca93abf9292cd4f.x943f6be3acf634db("distR", xc96375eb06b33c8a.xb5465b18223f6375);
		if (!xb3c5925d90ebc5f0.xf7125312c7ee115c.xc5bb70cfaaae4a20)
		{
			xca93abf9292cd4f.x943f6be3acf634db("simplePos", xbcea506a33cf9111: false);
			xca93abf9292cd4f.x943f6be3acf634db("relativeHeight", xc96375eb06b33c8a.x39043a80f49a07e2);
			xca93abf9292cd4f.x943f6be3acf634db("behindDoc", xc96375eb06b33c8a.x1242ade9edf65711, false);
			xca93abf9292cd4f.x943f6be3acf634db("locked", xc96375eb06b33c8a.xd150c96f113e4e19, false);
			xca93abf9292cd4f.x943f6be3acf634db("layoutInCell", xc96375eb06b33c8a.x87119342b85a2a43, true);
			xca93abf9292cd4f.x943f6be3acf634db("allowOverlap", xc96375eb06b33c8a.xed344a170caf7ac3, true);
			xca93abf9292cd4f.x943f6be3acf634db("hidden", xc96375eb06b33c8a.x96e55b5d052d1279);
			x0b1adbb14657e3d7.x0581c61af50dc3b0("wp:simplePos", 0, 0, xca93abf9292cd4f);
			xdccb4904ee141bc6();
			xa1595baad8e4072a();
		}
		x5b78c63537d478cc();
		x3abb2de974dbfeea();
		x5a37d8c6180b4c4e();
		xfce0d280725f4184();
		x7b9d466c0b98302b();
		x3289c08ab0e9b6f2();
		xca93abf9292cd4f.x2dfde153f4ef96d0();
		xca93abf9292cd4f.x2dfde153f4ef96d0();
	}

	private void xdccb4904ee141bc6()
	{
		x873451caae5ad4ae xca93abf9292cd4f = x9b287b671d592594.xca93abf9292cd4f1;
		xca93abf9292cd4f.x2307058321cdb62f("wp:positionH");
		xca93abf9292cd4f.x943f6be3acf634db("relativeFrom", x97322ba304f17e30.xe1a8f48039e41d1b(xc96375eb06b33c8a.x06372ab09e719f75));
		if (xc96375eb06b33c8a.xab67cb9464a3325b != null && (HorizontalAlignment)xc96375eb06b33c8a.xab67cb9464a3325b != 0)
		{
			xca93abf9292cd4f.x6b73ce92fd8e3f2c("wp:align", x97322ba304f17e30.xe99e7ad311262770(xc96375eb06b33c8a.xab67cb9464a3325b));
		}
		else
		{
			int xbcea506a33cf = ((xc96375eb06b33c8a.x72d92bd1aff02e37 != null) ? x4574ea26106f0edb.x3aa08882c9feaf96((double)xc96375eb06b33c8a.x72d92bd1aff02e37) : 0);
			xca93abf9292cd4f.x6b73ce92fd8e3f2c("wp:posOffset", xca004f56614e2431.x754c3a5f03a2ce84(xbcea506a33cf));
		}
		xca93abf9292cd4f.x2dfde153f4ef96d0();
	}

	private void xa1595baad8e4072a()
	{
		x873451caae5ad4ae xca93abf9292cd4f = x9b287b671d592594.xca93abf9292cd4f1;
		xca93abf9292cd4f.x2307058321cdb62f("wp:positionV");
		xca93abf9292cd4f.x943f6be3acf634db("relativeFrom", x97322ba304f17e30.x4bb63be0c86abf95(xc96375eb06b33c8a.xb6a90a3cd96dc205));
		if (xc96375eb06b33c8a.xf6ce0e8106e6a1d8 != null && (VerticalAlignment)xc96375eb06b33c8a.xf6ce0e8106e6a1d8 != 0)
		{
			xca93abf9292cd4f.x6b73ce92fd8e3f2c("wp:align", x97322ba304f17e30.xc4d54fa68e330462(xc96375eb06b33c8a.xf6ce0e8106e6a1d8));
		}
		else
		{
			int xbcea506a33cf = ((xc96375eb06b33c8a.xe360b1885d8d4a41 != null) ? x4574ea26106f0edb.x3aa08882c9feaf96((double)xc96375eb06b33c8a.xe360b1885d8d4a41) : 0);
			xca93abf9292cd4f.x6b73ce92fd8e3f2c("wp:posOffset", xca004f56614e2431.x754c3a5f03a2ce84(xbcea506a33cf));
		}
		xca93abf9292cd4f.x2dfde153f4ef96d0();
	}

	private void x5a37d8c6180b4c4e()
	{
		x873451caae5ad4ae xca93abf9292cd4f = x9b287b671d592594.xca93abf9292cd4f1;
		switch ((WrapType)((xc96375eb06b33c8a.xab6edfb47ff0b74c != null) ? xc96375eb06b33c8a.xab6edfb47ff0b74c : ((object)WrapType.None)))
		{
		case WrapType.None:
			xca93abf9292cd4f.xf68f9c3818e1f4b1("wp:wrapNone");
			break;
		case WrapType.Square:
			xca93abf9292cd4f.x2307058321cdb62f("wp:wrapSquare");
			x2cfaae03a8baf417();
			xca93abf9292cd4f.x2dfde153f4ef96d0();
			break;
		case WrapType.Through:
			xca93abf9292cd4f.x2307058321cdb62f("wp:wrapThrough");
			x2cfaae03a8baf417();
			xf5127b8a4ff7a94e();
			xca93abf9292cd4f.x2dfde153f4ef96d0();
			break;
		case WrapType.Tight:
			xca93abf9292cd4f.x2307058321cdb62f("wp:wrapTight");
			x2cfaae03a8baf417();
			xf5127b8a4ff7a94e();
			xca93abf9292cd4f.x2dfde153f4ef96d0();
			break;
		case WrapType.TopBottom:
			xca93abf9292cd4f.x2307058321cdb62f("wp:wrapTopAndBottom");
			xca93abf9292cd4f.x2dfde153f4ef96d0();
			break;
		case WrapType.Inline:
			break;
		}
	}

	private void x2cfaae03a8baf417()
	{
		x873451caae5ad4ae xca93abf9292cd4f = x9b287b671d592594.xca93abf9292cd4f1;
		if (xc96375eb06b33c8a.x400dff62c6cef57f != null)
		{
			xca93abf9292cd4f.x943f6be3acf634db("wrapText", x97322ba304f17e30.x68262c1f753d1cd0((WrapSide)xc96375eb06b33c8a.x400dff62c6cef57f));
		}
	}

	private void xf5127b8a4ff7a94e()
	{
		x873451caae5ad4ae xca93abf9292cd4f = x9b287b671d592594.xca93abf9292cd4f1;
		xca93abf9292cd4f.x2307058321cdb62f("wp:wrapPolygon");
		xca93abf9292cd4f.x943f6be3acf634db("edited", xc96375eb06b33c8a.xc3b7c4367b13f52c);
		if (xc96375eb06b33c8a.xb8caa80a8d3a7399 != null)
		{
			x08d932077485c285[] array = (x08d932077485c285[])xc96375eb06b33c8a.xb8caa80a8d3a7399;
			xdf56f39be8098f72(array[0]);
			for (int i = 1; i < array.Length; i++)
			{
				x159e884571bb3fe1(array[i]);
			}
			x159e884571bb3fe1(array[0]);
		}
		else
		{
			x0b1adbb14657e3d7.x0581c61af50dc3b0("wp:start", -389, 0, xca93abf9292cd4f);
			x0b1adbb14657e3d7.x0581c61af50dc3b0("wp:lineTo", -389, 21340, xca93abf9292cd4f);
			x0b1adbb14657e3d7.x0581c61af50dc3b0("wp:lineTo", 21795, 21340, xca93abf9292cd4f);
			x0b1adbb14657e3d7.x0581c61af50dc3b0("wp:lineTo", 21795, 0, xca93abf9292cd4f);
			x0b1adbb14657e3d7.x0581c61af50dc3b0("wp:lineTo", -389, 0, xca93abf9292cd4f);
		}
		xca93abf9292cd4f.x2dfde153f4ef96d0();
	}

	private void xdf56f39be8098f72(x08d932077485c285 x0b433f30d6157b49)
	{
		x873451caae5ad4ae xca93abf9292cd4f = x9b287b671d592594.xca93abf9292cd4f1;
		x0b1adbb14657e3d7.x0581c61af50dc3b0("wp:start", x0b433f30d6157b49.x8df91a2f90079e88.xd2f68ee6f47e9dfb, x0b433f30d6157b49.xc821290d7ecc08bf.xd2f68ee6f47e9dfb, xca93abf9292cd4f);
	}

	private void x159e884571bb3fe1(x08d932077485c285 x0b433f30d6157b49)
	{
		x873451caae5ad4ae xca93abf9292cd4f = x9b287b671d592594.xca93abf9292cd4f1;
		x0b1adbb14657e3d7.x0581c61af50dc3b0("wp:lineTo", x0b433f30d6157b49.x8df91a2f90079e88.xd2f68ee6f47e9dfb, x0b433f30d6157b49.xc821290d7ecc08bf.xd2f68ee6f47e9dfb, xca93abf9292cd4f);
	}

	private void xfce0d280725f4184()
	{
		x873451caae5ad4ae xca93abf9292cd4f = x9b287b671d592594.xca93abf9292cd4f1;
		xca93abf9292cd4f.x2307058321cdb62f("wp:docPr");
		xca93abf9292cd4f.x943f6be3acf634db("id", xc96375eb06b33c8a.xdd2aea3eb7514107, 0);
		xca93abf9292cd4f.xff520a0047c27122("name", (xc96375eb06b33c8a.x9d1669c11ed30adc != null) ? ((string)xc96375eb06b33c8a.x9d1669c11ed30adc) : "");
		xca93abf9292cd4f.x943f6be3acf634db("descr", xc96375eb06b33c8a.xd93bb9e671681a1d);
		xca93abf9292cd4f.x943f6be3acf634db("hidden", xc96375eb06b33c8a.x96e55b5d052d1279);
		x04b026f218103aa7();
		xca93abf9292cd4f.x2dfde153f4ef96d0();
	}

	private void x04b026f218103aa7()
	{
		if (xc96375eb06b33c8a.x8edafc3cf6e5431a != null)
		{
			x873451caae5ad4ae xca93abf9292cd4f = x9b287b671d592594.xca93abf9292cd4f1;
			xca93abf9292cd4f.x2307058321cdb62f("a:hlinkClick");
			xca93abf9292cd4f.x943f6be3acf634db("xmlns:a", "http://schemas.openxmlformats.org/drawingml/2006/main");
			string text = (string)xc96375eb06b33c8a.x8edafc3cf6e5431a;
			xca93abf9292cd4f.xff520a0047c27122("r:id", x0d299f323d241756.x5959bccb67bbf051(text) ? x9b287b671d592594.xfa224738036f0894(text) : "");
			xca93abf9292cd4f.x943f6be3acf634db("tgtFrame", xc96375eb06b33c8a.xc9344daa192a416a);
			xca93abf9292cd4f.x943f6be3acf634db("tooltip", xc96375eb06b33c8a.x3c9d02bc0fddd226);
			xca93abf9292cd4f.x2dfde153f4ef96d0();
		}
	}

	private void x5b78c63537d478cc()
	{
		x873451caae5ad4ae xca93abf9292cd4f = x9b287b671d592594.xca93abf9292cd4f1;
		x0b1adbb14657e3d7.x1cc570011777c911("wp:extent", x4574ea26106f0edb.x3aa08882c9feaf96((double)xc96375eb06b33c8a.xdc1bf80853046136), x4574ea26106f0edb.x3aa08882c9feaf96((double)xc96375eb06b33c8a.xb0f146032f47c24e), xca93abf9292cd4f);
	}

	private void x3abb2de974dbfeea()
	{
		if (xc96375eb06b33c8a.x7ffffbe9720a313f != null || xc96375eb06b33c8a.x84c93532f2f7213f != null || xc96375eb06b33c8a.x8a3594a045e50190 != null || xc96375eb06b33c8a.x55f86fe145bd4148 != null)
		{
			x873451caae5ad4ae xca93abf9292cd4f = x9b287b671d592594.xca93abf9292cd4f1;
			xca93abf9292cd4f.x2307058321cdb62f("wp:effectExtent");
			xca93abf9292cd4f.x943f6be3acf634db("l", xc96375eb06b33c8a.x7ffffbe9720a313f, 0);
			xca93abf9292cd4f.x943f6be3acf634db("t", xc96375eb06b33c8a.x84c93532f2f7213f, 0);
			xca93abf9292cd4f.x943f6be3acf634db("r", xc96375eb06b33c8a.x8a3594a045e50190, 0);
			xca93abf9292cd4f.x943f6be3acf634db("b", xc96375eb06b33c8a.x55f86fe145bd4148, 0);
			xca93abf9292cd4f.x2dfde153f4ef96d0();
		}
	}

	private void x7b9d466c0b98302b()
	{
		x873451caae5ad4ae xca93abf9292cd4f = x9b287b671d592594.xca93abf9292cd4f1;
		xca93abf9292cd4f.x2307058321cdb62f("wp:cNvGraphicFramePr");
		xb4e1091e21037094();
		xca93abf9292cd4f.x2dfde153f4ef96d0();
	}

	private void xb4e1091e21037094()
	{
		if (xc96375eb06b33c8a.xc9cb2de01432549c != null || xc96375eb06b33c8a.x546e5c81a980b540 != null || xc96375eb06b33c8a.x4c2536d07870ef18 != null || xc96375eb06b33c8a.x8f16da6f9e04205e != null || xc96375eb06b33c8a.xec19c61833ecca8a != null || xc96375eb06b33c8a.x204b9904d9061a73 != null)
		{
			x873451caae5ad4ae xca93abf9292cd4f = x9b287b671d592594.xca93abf9292cd4f1;
			xca93abf9292cd4f.x2307058321cdb62f("a:graphicFrameLocks");
			xca93abf9292cd4f.x943f6be3acf634db("xmlns:a", "http://schemas.openxmlformats.org/drawingml/2006/main");
			xca93abf9292cd4f.x943f6be3acf634db("noChangeAspect", xc96375eb06b33c8a.xc9cb2de01432549c);
			xca93abf9292cd4f.x943f6be3acf634db("noGrp", xc96375eb06b33c8a.x546e5c81a980b540);
			xca93abf9292cd4f.x943f6be3acf634db("noMove", xc96375eb06b33c8a.x4c2536d07870ef18);
			xca93abf9292cd4f.x943f6be3acf634db("noSelect", xc96375eb06b33c8a.x8f16da6f9e04205e);
			xca93abf9292cd4f.x943f6be3acf634db("noDrilldown", xc96375eb06b33c8a.xec19c61833ecca8a);
			xca93abf9292cd4f.x943f6be3acf634db("noResize", xc96375eb06b33c8a.x204b9904d9061a73);
			xca93abf9292cd4f.x2dfde153f4ef96d0();
		}
	}

	private void x3289c08ab0e9b6f2()
	{
		x873451caae5ad4ae xca93abf9292cd4f = x9b287b671d592594.xca93abf9292cd4f1;
		xca93abf9292cd4f.x5222f4285e37d66b.WriteRaw(xd165c26d81eb4a1e.x0c9679d333729bc5(x61f18ca85b7c2226.xb327816528e8798b));
	}

	private void x5188fe68817c1b1e(x40136e0b18d3d4d5 x1dc2f2327607c9b8)
	{
		foreach (x5645a78cb658cd2d item in x1dc2f2327607c9b8)
		{
			switch (item.xdb0ebfc0d169741e.LocalName)
			{
			case "embed":
			case "blip":
				item.xdb0ebfc0d169741e.Value = x9b287b671d592594.x2f696e6403c110df((byte[])item.xd2f68ee6f47e9dfb);
				break;
			case "link":
				item.xdb0ebfc0d169741e.Value = x9b287b671d592594.xf1b629587cb7c15e((string)item.xd2f68ee6f47e9dfb);
				break;
			case "id":
				switch (item.xdb0ebfc0d169741e.OwnerElement.LocalName)
				{
				case "hlinkHover":
				case "hlinkClick":
				case "hlickMouseOver":
					item.xdb0ebfc0d169741e.Value = x9b287b671d592594.xfa224738036f0894((string)item.xd2f68ee6f47e9dfb);
					break;
				case "chart":
					x7a0e5394c997ea5e(item, "/word/charts/chart{0}.xml", "application/vnd.openxmlformats-officedocument.drawingml.chart+xml", "http://schemas.openxmlformats.org/officeDocument/2006/relationships/chart");
					break;
				case "externalData":
					x0135b496e6871967(item);
					break;
				case "userShapes":
					x7a0e5394c997ea5e(item, "/word/drawings/drawing{0}.xml", "application/vnd.openxmlformats-officedocument.drawingml.chartshapes+xml", "http://schemas.openxmlformats.org/officeDocument/2006/relationships/chartUserShapes");
					break;
				default:
					throw new InvalidOperationException("Unexpected parent of the id attribute.");
				}
				break;
			case "dm":
				x7a0e5394c997ea5e(item, "/word/diagrams/data{0}.xml", "application/vnd.openxmlformats-officedocument.drawingml.diagramData+xml", "http://schemas.openxmlformats.org/officeDocument/2006/relationships/diagramData");
				break;
			case "lo":
				x7a0e5394c997ea5e(item, "/word/diagrams/layout{0}.xml", "application/vnd.openxmlformats-officedocument.drawingml.diagramLayout+xml", "http://schemas.openxmlformats.org/officeDocument/2006/relationships/diagramLayout");
				break;
			case "qs":
				x7a0e5394c997ea5e(item, "/word/diagrams/quickStyle{0}.xml", "application/vnd.openxmlformats-officedocument.drawingml.diagramStyle+xml", "http://schemas.openxmlformats.org/officeDocument/2006/relationships/diagramQuickStyle");
				break;
			case "cs":
				x7a0e5394c997ea5e(item, "/word/diagrams/colors{0}.xml", "application/vnd.openxmlformats-officedocument.drawingml.diagramColors+xml", "http://schemas.openxmlformats.org/officeDocument/2006/relationships/diagramColors");
				break;
			case "relId":
				x7a0e5394c997ea5e(item, "/word/diagrams/drawing{0}.xml", "application/vnd.ms-office.drawingml.diagramDrawing+xml", "http://schemas.microsoft.com/office/2007/relationships/diagramDrawing");
				break;
			default:
				throw new InvalidOperationException("Unexpected attribute name.");
			}
		}
	}

	private void x7a0e5394c997ea5e(x5645a78cb658cd2d x4a3f0a05c02f235f, string xdac7996c6b0ef794, string xe1d3286d17e44a37, string x061610664b4c984f)
	{
		string x69cb5ff2e6c23f = string.Format(xdac7996c6b0ef794, x9b287b671d592594.x15789b8c2554f92e(x061610664b4c984f));
		xa2f1c3dcbd86f20a x398b3bd0acd94b;
		if (xe1d3286d17e44a37 == "application/vnd.ms-office.drawingml.diagramDrawing+xml")
		{
			x8f3af96aa56f1e32 xca93abf9292cd4f = x9b287b671d592594.xca93abf9292cd4f1;
			x9b287b671d592594.xa493f0b03338ab7a();
			x398b3bd0acd94b = x9b287b671d592594.xca93abf9292cd4f1.x398b3bd0acd94b61;
			x9b287b671d592594.xefc309b2831366cb(xca93abf9292cd4f);
		}
		else
		{
			x398b3bd0acd94b = x9b287b671d592594.xca93abf9292cd4f1.x398b3bd0acd94b61;
		}
		x2d7edda38059e30a(x4a3f0a05c02f235f, x398b3bd0acd94b, x69cb5ff2e6c23f, xe1d3286d17e44a37, x061610664b4c984f);
	}

	private void x2d7edda38059e30a(x5645a78cb658cd2d x4a3f0a05c02f235f, xa2f1c3dcbd86f20a x660bfbc29977d3c8, string x69cb5ff2e6c23f47, string xe1d3286d17e44a37, string x061610664b4c984f)
	{
		string xc06e652f250a;
		x8f3af96aa56f1e32 x8f3af96aa56f1e = x9b287b671d592594.xa24813b526772a3b(x660bfbc29977d3c8, x69cb5ff2e6c23f47, xe1d3286d17e44a37, x061610664b4c984f, out xc06e652f250a);
		x4a3f0a05c02f235f.xdb0ebfc0d169741e.Value = xc06e652f250a;
		x9b287b671d592594.xefc309b2831366cb(x8f3af96aa56f1e);
		x5188fe68817c1b1e(x4a3f0a05c02f235f.x169b8a3bc8f77f64);
		x9b287b671d592594.xa493f0b03338ab7a();
		XmlDocument x6beba47238e0ade = (XmlDocument)x4a3f0a05c02f235f.xd2f68ee6f47e9dfb;
		xd165c26d81eb4a1e.x8ebf37a8980eb562(x6beba47238e0ade, x8f3af96aa56f1e.x398b3bd0acd94b61.xb8a774e0111d0fbe);
	}

	private void x0135b496e6871967(x5645a78cb658cd2d x4a3f0a05c02f235f)
	{
		if (x4a3f0a05c02f235f.x9a6a8577ab0646a4)
		{
			x4a3f0a05c02f235f.xdb0ebfc0d169741e.Value = x9b287b671d592594.xd7fff6bb685052ae((string)x4a3f0a05c02f235f.xd2f68ee6f47e9dfb);
			return;
		}
		string x95fb8866691eb6f = string.Format("/word/embeddings/Microsoft_Office_Excel_Worksheet{0}.xlsx", x9b287b671d592594.x15789b8c2554f92e("http://schemas.openxmlformats.org/officeDocument/2006/relationships/package"));
		string xc06e652f250a;
		xa2f1c3dcbd86f20a xa2f1c3dcbd86f20a = x9b287b671d592594.x39c7aeeec1af9dd0.x42c5f80e2ed823ff(x9b287b671d592594.xca93abf9292cd4f1.x398b3bd0acd94b61, x95fb8866691eb6f, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "http://schemas.openxmlformats.org/officeDocument/2006/relationships/package", out xc06e652f250a);
		x4a3f0a05c02f235f.xdb0ebfc0d169741e.Value = xc06e652f250a;
		byte[] array = (byte[])x4a3f0a05c02f235f.xd2f68ee6f47e9dfb;
		xa2f1c3dcbd86f20a.xb8a774e0111d0fbe.Write(array, 0, array.Length);
	}
}
