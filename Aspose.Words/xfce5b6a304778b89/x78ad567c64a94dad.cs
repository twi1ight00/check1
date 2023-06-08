using Aspose.Words;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;
using xbe73d5820f7f4ae3;

namespace xfce5b6a304778b89;

internal class x78ad567c64a94dad
{
	private x78ad567c64a94dad()
	{
	}

	internal static void x06b0e25aa6ad68a9(xf871da68decec406 xe134235b3526fa75, string x65bb1537d51f4cd7, CompositeNode x8b2c3c076d5a7daf)
	{
		x06b0e25aa6ad68a9(xe134235b3526fa75, x65bb1537d51f4cd7, x8b2c3c076d5a7daf, null);
	}

	internal static void x06b0e25aa6ad68a9(xf871da68decec406 xe134235b3526fa75, string x65bb1537d51f4cd7, CompositeNode x8b2c3c076d5a7daf, xc559a3dd8354bcaa x13eeaa19b4289a25)
	{
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		while (xca994afbcb9073a.x152cbadbfa8061b1(x65bb1537d51f4cd7))
		{
			xe134235b3526fa75.xe5ffcf1e3f9bd387 = xca994afbcb9073a.xd68abcd61e368af9("style-name", "Standard");
			x899ab188166aec2d x0f4599bff013bd = x4098110b0f5e24b2(xe134235b3526fa75);
			x8b2c3c076d5a7daf = xe96f630c4a2ed468(xe134235b3526fa75, x0f4599bff013bd, x8b2c3c076d5a7daf);
			if (!x152cbadbfa8061b1(xe134235b3526fa75, x8b2c3c076d5a7daf, x13eeaa19b4289a25, x0f4599bff013bd))
			{
				xca994afbcb9073a.IgnoreElement();
			}
		}
	}

	internal static bool x152cbadbfa8061b1(xf871da68decec406 xe134235b3526fa75, CompositeNode x8b2c3c076d5a7daf, x899ab188166aec2d x0f4599bff013bd18)
	{
		return x152cbadbfa8061b1(xe134235b3526fa75, x8b2c3c076d5a7daf, null, x0f4599bff013bd18);
	}

	private static bool x152cbadbfa8061b1(xf871da68decec406 xe134235b3526fa75, CompositeNode x8b2c3c076d5a7daf, xc559a3dd8354bcaa x13eeaa19b4289a25, x899ab188166aec2d x0f4599bff013bd18)
	{
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		if (xf871da68decec406.xfe4f7dca36c0076c(xe134235b3526fa75, x8b2c3c076d5a7daf, null, null))
		{
			return true;
		}
		switch (xca994afbcb9073a.xa66385d80d4d296f)
		{
		case "p":
		case "h":
			xef3217fa00e6d2ba.x06b0e25aa6ad68a9(xe134235b3526fa75, xca994afbcb9073a.xa66385d80d4d296f, x8b2c3c076d5a7daf);
			return true;
		case "list":
			x51bdb35997d05bcf.x06b0e25aa6ad68a9(xe134235b3526fa75, x8b2c3c076d5a7daf, null);
			return true;
		case "table":
			xcf7a5dc1222c8f51.x06b0e25aa6ad68a9(xe134235b3526fa75, x8b2c3c076d5a7daf, x13eeaa19b4289a25);
			return true;
		case "table-of-content":
		case "table-index":
		case "bibliography":
			x86738d7528f4304b.x06b0e25aa6ad68a9(xe134235b3526fa75, x8b2c3c076d5a7daf, x0f4599bff013bd18);
			return true;
		case "index-title":
			x06b0e25aa6ad68a9(xe134235b3526fa75, "index-title", x8b2c3c076d5a7daf);
			return true;
		case "section":
			x65d2adf794d9cebc.x06b0e25aa6ad68a9(xe134235b3526fa75, x0f4599bff013bd18);
			return true;
		case "control":
			x96a5aac2efa9fd8a.x06b0e25aa6ad68a9(xe134235b3526fa75, x8b2c3c076d5a7daf, null, null);
			return true;
		default:
			return false;
		}
	}

	internal static CompositeNode xe96f630c4a2ed468(xf871da68decec406 xe134235b3526fa75, x899ab188166aec2d x0f4599bff013bd18, CompositeNode x8b2c3c076d5a7daf)
	{
		if (!x2c44bc1cdff265cd(xe134235b3526fa75) || (x8b2c3c076d5a7daf != null && !(x8b2c3c076d5a7daf is Body)))
		{
			if (x8b2c3c076d5a7daf != null)
			{
				foreach (Paragraph item in xe134235b3526fa75.x6147b51b34c29eea)
				{
					if (item.ParentNode == null)
					{
						x8b2c3c076d5a7daf.AppendChild(item);
					}
				}
			}
			return x8b2c3c076d5a7daf;
		}
		Section section = xe134235b3526fa75.x2c8c6741422a1298.LastSection;
		bool flag = xb6b6249fbc7c578d(xe134235b3526fa75, x0f4599bff013bd18);
		bool flag2 = xe134235b3526fa75.x513275af5c756949 || xe134235b3526fa75.xed48a3fa9b038203 || flag || xe134235b3526fa75.x2c8c6741422a1298.Sections.Count == 0;
		if (flag2 || (x8b2c3c076d5a7daf == null && xe134235b3526fa75.x025b4232f6267898.Count == 0))
		{
			if (xe134235b3526fa75.x025b4232f6267898.Count == 0)
			{
				if (flag2)
				{
					section = x0f4599bff013bd18.x10d7a1cae426b158.Clone();
					section.AppendChild(new Body(xe134235b3526fa75.x2c8c6741422a1298));
				}
			}
			else
			{
				section = ((Section)xe134235b3526fa75.x025b4232f6267898.Peek()).Clone();
				xfc72d4c9b765cad7 xfc72d4c9b765cad = (xfc72d4c9b765cad7)section.xfc72d4c9b765cad7.x8b61531c8ea35b85();
				x0f4599bff013bd18.x10d7a1cae426b158.xfc72d4c9b765cad7.xab3af626b1405ee8(section.xfc72d4c9b765cad7);
				if (xfc72d4c9b765cad.x6e1eb96b81362ebc != 0)
				{
					section.xfc72d4c9b765cad7.x6e1eb96b81362ebc = xfc72d4c9b765cad.x6e1eb96b81362ebc;
					section.xfc72d4c9b765cad7.xbd7bb54d8760ed0a = xfc72d4c9b765cad.xbd7bb54d8760ed0a;
					section.xfc72d4c9b765cad7.x49ddd5238a18b5b1 = xfc72d4c9b765cad.x49ddd5238a18b5b1;
					section.xfc72d4c9b765cad7.xa7b942134f68467f = xfc72d4c9b765cad.xa7b942134f68467f;
					section.xfc72d4c9b765cad7.xa79be739e56e9dde = xfc72d4c9b765cad.xa79be739e56e9dde;
				}
			}
			xe134235b3526fa75.x2c8c6741422a1298.Sections.Add(section);
			section.xfc72d4c9b765cad7.xe95664527db59e6e = (flag ? SectionStart.NewPage : SectionStart.Continuous);
			x65b6166cadd33969(xe134235b3526fa75, x0f4599bff013bd18, section);
			x95973895507fea32 x95973895507fea = xe134235b3526fa75.x37eb83f4e2a8fe56.get_xe6d4b1b411ed94b5(xe134235b3526fa75.xe5ffcf1e3f9bd387, (string)null, xe134235b3526fa75.xb9e32c79bd755ad8, xafd04c36a00d5bcf: true);
			if (!(x95973895507fea is xb77bc1b681ac1354))
			{
				x39cd0691137f3b40 x39cd0691137f3b = (x39cd0691137f3b40)x95973895507fea;
				xe134235b3526fa75.xcf39848e8372bf94 = ((x39cd0691137f3b != null) ? x39cd0691137f3b.x80fcdfee081ea552 : "Standard");
				xe134235b3526fa75.x186e5825c720d6b2 = xe134235b3526fa75.xe5ffcf1e3f9bd387 != "Standard" && x39cd0691137f3b != null && x39cd0691137f3b is x38c672d671ef22c7 && x0d299f323d241756.x5959bccb67bbf051(x39cd0691137f3b.x80fcdfee081ea552);
			}
		}
		xe134235b3526fa75.x513275af5c756949 = false;
		xe134235b3526fa75.xed48a3fa9b038203 = false;
		foreach (Paragraph item2 in xe134235b3526fa75.x6147b51b34c29eea)
		{
			section.Body.AppendChild(item2);
		}
		xe134235b3526fa75.x6147b51b34c29eea.Clear();
		return section.Body;
	}

	private static bool xb6b6249fbc7c578d(xf871da68decec406 xe134235b3526fa75, x899ab188166aec2d x0f4599bff013bd18)
	{
		x899ab188166aec2d x899ab188166aec2d2 = null;
		x95973895507fea32 x95973895507fea = xe134235b3526fa75.x37eb83f4e2a8fe56.get_xe6d4b1b411ed94b5(xe134235b3526fa75.xe5ffcf1e3f9bd387, (string)null, xe134235b3526fa75.xb9e32c79bd755ad8, xafd04c36a00d5bcf: true);
		if (!(x95973895507fea is xb77bc1b681ac1354))
		{
			x899ab188166aec2d2 = x4098110b0f5e24b2(xe134235b3526fa75, xe134235b3526fa75.x071d9b5ee3757e23, xe134235b3526fa75.xcf39848e8372bf94);
		}
		bool flag = x95973895507fea != null && !(x95973895507fea is xb77bc1b681ac1354) && x0d299f323d241756.x5959bccb67bbf051(((x39cd0691137f3b40)x95973895507fea).x80fcdfee081ea552);
		bool flag2 = x0f4599bff013bd18.x759aa16c2016a289 != xe134235b3526fa75.xcf39848e8372bf94 && xe134235b3526fa75.xcf39848e8372bf94 != null;
		if (!flag)
		{
			return false;
		}
		if (flag2 || xe134235b3526fa75.x186e5825c720d6b2 || x899ab188166aec2d2 == null || !x0f4599bff013bd18.x10d7a1cae426b158.xfc72d4c9b765cad7.Equals(x899ab188166aec2d2.x10d7a1cae426b158.xfc72d4c9b765cad7) || (x95973895507fea is x38c672d671ef22c7 && ((x38c672d671ef22c7)x95973895507fea).xbed6d6330712f0f2))
		{
			return true;
		}
		return false;
	}

	private static bool x2c44bc1cdff265cd(xf871da68decec406 xe134235b3526fa75)
	{
		string xa66385d80d4d296f = xe134235b3526fa75.xca994afbcb9073a2.xa66385d80d4d296f;
		string xd8a1c7c41bfbcde = xe134235b3526fa75.xca994afbcb9073a2.xd8a1c7c41bfbcde0;
		if (!(xd8a1c7c41bfbcde == "draw") || !(xa66385d80d4d296f == "a"))
		{
			switch (xa66385d80d4d296f)
			{
			default:
				return xa66385d80d4d296f == "line";
			case "g":
			case "line":
			case "connector":
			case "rect":
			case "circle":
			case "ellipse":
			case "polyline":
			case "polygon":
			case "regular-polygon":
			case "path":
			case "page-thumbnail":
			case "measure":
			case "caption":
			case "scene":
			case "custom-shape":
			case "p":
			case "h":
			case "table":
			case "list":
				break;
			}
		}
		return true;
	}

	private static void x65b6166cadd33969(xf871da68decec406 xe134235b3526fa75, x899ab188166aec2d x0f4599bff013bd18, Section xb32f8dd719a105db)
	{
		xb77bc1b681ac1354 xb77bc1b681ac1355 = xe134235b3526fa75.x37eb83f4e2a8fe56.get_xe6d4b1b411ed94b5(x0f4599bff013bd18.x4fc90f517816f531, (string)null, xe134235b3526fa75.xb9e32c79bd755ad8, xafd04c36a00d5bcf: true) as xb77bc1b681ac1354;
		xb32f8dd719a105db.PageSetup.HeaderDistance = xb32f8dd719a105db.PageSetup.TopMargin;
		xb32f8dd719a105db.PageSetup.FooterDistance = xb32f8dd719a105db.PageSetup.BottomMargin;
		if (xb77bc1b681ac1355 != null)
		{
			if (xb77bc1b681ac1355.xd9d19e4aaaecdf95 != null)
			{
				xb32f8dd719a105db.xfc72d4c9b765cad7.xc07fe3840d9e6d76 = xb32f8dd719a105db.xfc72d4c9b765cad7.xc07fe3840d9e6d76 + xb77bc1b681ac1355.xd9d19e4aaaecdf95.xe25531d244b2cd51;
			}
			if (xb77bc1b681ac1355.xcba1c710c374f14e != null)
			{
				xb32f8dd719a105db.xfc72d4c9b765cad7.x65011a5ae8c64a43 = xb32f8dd719a105db.xfc72d4c9b765cad7.x65011a5ae8c64a43 + xb77bc1b681ac1355.xcba1c710c374f14e.xe25531d244b2cd51;
			}
		}
	}

	internal static x899ab188166aec2d x4098110b0f5e24b2(xf871da68decec406 xe134235b3526fa75)
	{
		x95973895507fea32 x95973895507fea = xe134235b3526fa75.x37eb83f4e2a8fe56.get_xe6d4b1b411ed94b5(xe134235b3526fa75.xe5ffcf1e3f9bd387, (string)null, xe134235b3526fa75.xb9e32c79bd755ad8, xafd04c36a00d5bcf: true);
		if (!(x95973895507fea is xb77bc1b681ac1354))
		{
			x39cd0691137f3b40 x39cd0691137f3b = (x39cd0691137f3b40)x95973895507fea;
			string x9ab710a9fedb5a = ((x39cd0691137f3b != null) ? x39cd0691137f3b.x80fcdfee081ea552 : xe134235b3526fa75.xcf39848e8372bf94);
			return x4098110b0f5e24b2(xe134235b3526fa75, xe134235b3526fa75.x071d9b5ee3757e23, x9ab710a9fedb5a);
		}
		return xe134235b3526fa75.x071d9b5ee3757e23.get_xe6d4b1b411ed94b5("Standard");
	}

	internal static x899ab188166aec2d x4098110b0f5e24b2(xf871da68decec406 xe134235b3526fa75, xb129d89e9ebefa31 x2322f9a9544d0a88, string x9ab710a9fedb5a47)
	{
		x899ab188166aec2d x899ab188166aec2d2 = x2322f9a9544d0a88.get_xe6d4b1b411ed94b5(x9ab710a9fedb5a47);
		if (x899ab188166aec2d2 != null)
		{
			return x899ab188166aec2d2;
		}
		return x2322f9a9544d0a88.get_xe6d4b1b411ed94b5("Standard");
	}
}
