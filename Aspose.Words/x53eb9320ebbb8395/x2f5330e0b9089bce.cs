using System;
using System.Collections;
using Aspose.Words;
using Aspose.Words.BuildingBlocks;
using Aspose.Words.Markup;
using x5794c252ba25e723;
using x6c95d9cf46ff5f25;

namespace x53eb9320ebbb8395;

internal class x2f5330e0b9089bce
{
	internal const string x1c33ce3f46fa62fa = "General";

	internal const string x25dd1b1ac410a330 = "DefaultPlaceholder_22675703";

	internal const string xefd022cb54ebd34b = "DefaultPlaceholder_22675704";

	internal const string x8c761f355ace4fd3 = "DefaultPlaceholder_22675705";

	internal const string x1318b2f052b97f72 = "DefaultPlaceholder_22675706";

	private Style x5d9fbd9603e9dee5;

	private GlossaryDocument x8c14d55e2e8c412a;

	private readonly Document xf9bfe19a8c50a52f;

	private readonly Hashtable x6783db0a573726e8 = new Hashtable();

	private readonly Hashtable xf88212883b4b00c7 = new Hashtable();

	private readonly xdafb1884dd39ffcb x85084d21f6a794cc = new xdafb1884dd39ffcb();

	internal IEnumerable x411de88df75af925 => x85084d21f6a794cc.x68bd1387be2e3e2d;

	internal bool x38921fc0c986c5d7 => x8c14d55e2e8c412a == null;

	private GlossaryDocument xa3a532ea68c248c5
	{
		get
		{
			if (x8c14d55e2e8c412a == null)
			{
				if (xf9bfe19a8c50a52f == null)
				{
					throw new InvalidOperationException("Please report exception.");
				}
				if (xf9bfe19a8c50a52f.GlossaryDocument == null)
				{
					xf9bfe19a8c50a52f.GlossaryDocument = new GlossaryDocument();
				}
				x8c14d55e2e8c412a = xf9bfe19a8c50a52f.GlossaryDocument;
			}
			return x8c14d55e2e8c412a;
		}
	}

	internal x2f5330e0b9089bce(DocumentBase doc)
	{
		if (doc is Document)
		{
			xf9bfe19a8c50a52f = (Document)doc;
			x8c14d55e2e8c412a = xf9bfe19a8c50a52f.GlossaryDocument;
		}
		else
		{
			x8c14d55e2e8c412a = (GlossaryDocument)doc;
			xf9bfe19a8c50a52f = null;
		}
		if (!x38921fc0c986c5d7)
		{
			xd157f58df9dc3948();
		}
	}

	internal BuildingBlock xd6c4b819de3488c3(SdtType x43163d22e8cd5a71)
	{
		if (!x6783db0a573726e8.ContainsKey(x43163d22e8cd5a71))
		{
			return x512069c1b0823a19(x43163d22e8cd5a71);
		}
		return (BuildingBlock)x6783db0a573726e8[x43163d22e8cd5a71];
	}

	internal BuildingBlock xe25c33c4a4a5dd49(StructuredDocumentTag xffe521cc76054baf, bool x4a492b36640fb263)
	{
		BuildingBlock buildingBlock = null;
		if (xffe521cc76054baf.PlaceholderName != "")
		{
			buildingBlock = x7cd498eec241bbf0(xffe521cc76054baf);
		}
		if (x4a492b36640fb263 && buildingBlock == null)
		{
			buildingBlock = xd6c4b819de3488c3(xffe521cc76054baf.SdtType);
		}
		return buildingBlock;
	}

	internal void x19ea552051b359a3()
	{
		x85084d21f6a794cc.x74f5a1ef3906e23c();
	}

	internal void xdad4105ec91aae57(StructuredDocumentTag xabd8f8a3b7f099d3)
	{
		if (xabd8f8a3b7f099d3.Placeholder != null)
		{
			x85084d21f6a794cc.xdad4105ec91aae57(xabd8f8a3b7f099d3.Placeholder.Name);
		}
	}

	internal void xc36ccefedcea4870(IEnumerable xa418ac99acabdf89)
	{
		foreach (object item in xa418ac99acabdf89)
		{
			x85084d21f6a794cc.xdad4105ec91aae57(item);
		}
	}

	internal bool x01c46e4ecd96057e()
	{
		bool result = false;
		foreach (BuildingBlock buildingBlock in xa3a532ea68c248c5.BuildingBlocks)
		{
			if (buildingBlock.ParentNode != null && xf96aa276334b9ece(buildingBlock) && !x85084d21f6a794cc.xdbf8965584c07a90(buildingBlock.Name))
			{
				buildingBlock.Remove();
				result = true;
			}
		}
		return result;
	}

	private BuildingBlock x7cd498eec241bbf0(StructuredDocumentTag xffe521cc76054baf)
	{
		string placeholderName = xffe521cc76054baf.PlaceholderName;
		BuildingBlock buildingBlock = (xf88212883b4b00c7.ContainsKey(placeholderName) ? ((BuildingBlock)xf88212883b4b00c7[placeholderName]) : null);
		if (buildingBlock == null)
		{
			buildingBlock = xa3a532ea68c248c5.GetBuildingBlock(BuildingBlockGallery.StructuredDocumentTagPlaceholderText, null, placeholderName);
			if (buildingBlock != null)
			{
				x459a1cb81a936519(xf88212883b4b00c7, placeholderName, buildingBlock);
				x459a1cb81a936519(x6783db0a573726e8, xffe521cc76054baf.SdtType, buildingBlock);
			}
		}
		return buildingBlock;
	}

	private void xd157f58df9dc3948()
	{
		foreach (BuildingBlock item in xa3a532ea68c248c5)
		{
			if (item.Gallery == BuildingBlockGallery.StructuredDocumentTagPlaceholderText)
			{
				switch (item.Name)
				{
				case "DefaultPlaceholder_22675703":
					x8545a688b9c797c8(item);
					break;
				case "DefaultPlaceholder_22675705":
					xc448fbc8a6be9ef9(item);
					break;
				case "DefaultPlaceholder_22675704":
					xd037d1236745c49d(item);
					break;
				case "DefaultPlaceholder_22675706":
					x9b6b16ddd1618de0(item);
					break;
				}
			}
		}
	}

	private void x8545a688b9c797c8(BuildingBlock x37f3a555926e71c4)
	{
		x459a1cb81a936519(x6783db0a573726e8, SdtType.RichText, x37f3a555926e71c4);
		x459a1cb81a936519(x6783db0a573726e8, SdtType.PlainText, x37f3a555926e71c4);
		x459a1cb81a936519(x6783db0a573726e8, SdtType.Group, x37f3a555926e71c4);
		x459a1cb81a936519(xf88212883b4b00c7, "DefaultPlaceholder_22675703", x37f3a555926e71c4);
	}

	private void xd037d1236745c49d(BuildingBlock x37f3a555926e71c4)
	{
		x459a1cb81a936519(x6783db0a573726e8, SdtType.ComboBox, x37f3a555926e71c4);
		x459a1cb81a936519(x6783db0a573726e8, SdtType.DropDownList, x37f3a555926e71c4);
		x459a1cb81a936519(xf88212883b4b00c7, "DefaultPlaceholder_22675704", x37f3a555926e71c4);
	}

	private void xc448fbc8a6be9ef9(BuildingBlock x37f3a555926e71c4)
	{
		x6783db0a573726e8.Add(SdtType.Date, x37f3a555926e71c4);
		xf88212883b4b00c7.Add("DefaultPlaceholder_22675705", x37f3a555926e71c4);
	}

	private void x9b6b16ddd1618de0(BuildingBlock x37f3a555926e71c4)
	{
		x6783db0a573726e8.Add(SdtType.BuildingBlockGallery, x37f3a555926e71c4);
		xf88212883b4b00c7.Add("DefaultPlaceholder_22675706", x37f3a555926e71c4);
	}

	private BuildingBlock x512069c1b0823a19(SdtType x43163d22e8cd5a71)
	{
		BuildingBlock buildingBlock;
		switch (x43163d22e8cd5a71)
		{
		case SdtType.Group:
		case SdtType.RichText:
		case SdtType.PlainText:
			buildingBlock = x126d44570ae94bed("DefaultPlaceholder_22675703", "Click here to enter text.");
			x8545a688b9c797c8(buildingBlock);
			break;
		case SdtType.DropDownList:
		case SdtType.ComboBox:
			buildingBlock = x126d44570ae94bed("DefaultPlaceholder_22675704", "Choose an item.");
			xd037d1236745c49d(buildingBlock);
			break;
		case SdtType.Date:
			buildingBlock = x126d44570ae94bed("DefaultPlaceholder_22675705", "Click here to enter a date.");
			xc448fbc8a6be9ef9(buildingBlock);
			break;
		case SdtType.BuildingBlockGallery:
			buildingBlock = x126d44570ae94bed("DefaultPlaceholder_22675706", "Choose a building block.");
			x9b6b16ddd1618de0(buildingBlock);
			break;
		default:
			buildingBlock = null;
			break;
		}
		return buildingBlock;
	}

	private BuildingBlock x126d44570ae94bed(string x0577d13c29e74939, string xa051d70166ebfb67)
	{
		BuildingBlock buildingBlock = x6ed0a4bb22ad647b(x0577d13c29e74939);
		xa3a532ea68c248c5.AppendChild(buildingBlock);
		Section section = new Section(xa3a532ea68c248c5);
		buildingBlock.AppendChild(section);
		Body body = new Body(xa3a532ea68c248c5);
		section.AppendChild(body);
		Paragraph paragraph = new Paragraph(xa3a532ea68c248c5);
		body.AppendChild(paragraph);
		Run run = new Run(xa3a532ea68c248c5, xa051d70166ebfb67);
		run.xeedad81aaed42a76.xae20093bed1e48a8(50, x5d9fbd9603e9dee5.x8301ab10c226b0c2);
		paragraph.AppendChild(run);
		return buildingBlock;
	}

	private BuildingBlock x6ed0a4bb22ad647b(string x9c1807bfd4ceaac0)
	{
		x8ba15b8d22678685();
		BuildingBlock buildingBlock = new BuildingBlock(xa3a532ea68c248c5);
		buildingBlock.Category = "General";
		buildingBlock.Gallery = BuildingBlockGallery.StructuredDocumentTagPlaceholderText;
		buildingBlock.Type = BuildingBlockType.StructuredDocumentTagPlaceholderText;
		buildingBlock.Behavior = BuildingBlockBehavior.Content;
		buildingBlock.Guid = xa19c1513d8b80a8b.xdf7c5a607de91fb9(x9c1807bfd4ceaac0);
		buildingBlock.Name = x9c1807bfd4ceaac0;
		return buildingBlock;
	}

	private void x8ba15b8d22678685()
	{
		if (x5d9fbd9603e9dee5 == null)
		{
			x5d9fbd9603e9dee5 = xa3a532ea68c248c5.Styles.xe931c242f6b9055f("Placeholder Text", x988fcf605f8efa7e: false);
			if (x5d9fbd9603e9dee5 == null)
			{
				x5d9fbd9603e9dee5 = xa3a532ea68c248c5.Styles.Add(StyleType.Character, "Placeholder Text");
				x5d9fbd9603e9dee5.xe709b224f455b863 = 10;
				x5d9fbd9603e9dee5.x9eb07da9aa5bbf9e = 99;
				x5d9fbd9603e9dee5.x45101ac87546632f = true;
				x5d9fbd9603e9dee5.xeedad81aaed42a76.x9b41425268471380 = x26d9ecb4bdf0456d.xd378227c730f388c(0, 128, 128, 128);
			}
		}
	}

	private static void x459a1cb81a936519(Hashtable x11d58b056c032b03, object xba08ce632055a1d9, BuildingBlock x37f3a555926e71c4)
	{
		if (!x11d58b056c032b03.ContainsKey(xba08ce632055a1d9))
		{
			x11d58b056c032b03.Add(xba08ce632055a1d9, x37f3a555926e71c4);
		}
	}

	private static bool xf96aa276334b9ece(BuildingBlock xe413319369b234aa)
	{
		if (xe413319369b234aa.Gallery == BuildingBlockGallery.StructuredDocumentTagPlaceholderText)
		{
			return xe413319369b234aa.Type == BuildingBlockType.StructuredDocumentTagPlaceholderText;
		}
		return false;
	}
}
