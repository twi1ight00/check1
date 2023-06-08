using System;
using Aspose.Words;
using Aspose.Words.Drawing;
using Aspose.Words.Fields;
using x28925c9b27b37a46;
using x79490184cecf12a1;
using xf989f31a236ff98c;
using xfbd1009a0cbb9842;

namespace x1495530f35d79681;

internal class xc1789523d0b1c8b2
{
	private xc1789523d0b1c8b2()
	{
	}

	internal static void x06b0e25aa6ad68a9(xdfce7f4f687956d7 xe134235b3526fa75, xeedad81aaed42a76 x789564759d365819)
	{
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		bool flag = false;
		while (x3bcd232d01c.x1ac1960adc8c4c39())
		{
			switch (x3bcd232d01c.xa66385d80d4d296f)
			{
			case "fldCharType":
				switch (x3bcd232d01c.xd2f68ee6f47e9dfb)
				{
				case "begin":
					xe5592f4992304bd5(xe134235b3526fa75, x789564759d365819);
					break;
				case "separate":
					xc5fb20c56596cd63(xe134235b3526fa75, x789564759d365819);
					break;
				case "end":
					flag = true;
					break;
				}
				break;
			case "dirty":
				if (xe134235b3526fa75.x3bcd232d01c14846.xa7799d48a3e6b897.Count > 0)
				{
					FieldChar fieldChar2 = (FieldChar)x3bcd232d01c.xa7799d48a3e6b897.Peek();
					fieldChar2.x6e94079169d5a06e = x3bcd232d01c.xc3be6b142c6aca84;
				}
				break;
			case "fldLock":
				if (xe134235b3526fa75.x3bcd232d01c14846.xa7799d48a3e6b897.Count > 0)
				{
					FieldChar fieldChar = (FieldChar)x3bcd232d01c.xa7799d48a3e6b897.Peek();
					fieldChar.IsLocked = x3bcd232d01c.xc3be6b142c6aca84;
				}
				break;
			}
		}
		if (flag)
		{
			xd464ae4d05dc89da(xe134235b3526fa75, x789564759d365819);
		}
		while (x3bcd232d01c.x152cbadbfa8061b1("fldChar"))
		{
			switch (x3bcd232d01c.xa66385d80d4d296f)
			{
			case "fldData":
				x3bcd232d01c.x303ddb1b000492b0 = Convert.FromBase64String(x3bcd232d01c.x2a1ea9d24e62bf84());
				break;
			case "ffData":
				xe04cfa8c632033b4.x06b0e25aa6ad68a9(x3bcd232d01c);
				break;
			default:
				x3bcd232d01c.IgnoreElement();
				break;
			}
		}
	}

	private static void xe5592f4992304bd5(xdfce7f4f687956d7 xe134235b3526fa75, xeedad81aaed42a76 x789564759d365819)
	{
		FieldStart fieldStart = new FieldStart(xe134235b3526fa75.x2c8c6741422a1298, x789564759d365819, FieldType.FieldNone);
		xe134235b3526fa75.x1fa9148f6731ff24(fieldStart);
		if (!x789564759d365819.x0392c0938d22c790)
		{
			xe134235b3526fa75.x3bcd232d01c14846.xa7799d48a3e6b897.Push(fieldStart);
		}
	}

	private static void xc5fb20c56596cd63(xdfce7f4f687956d7 xe134235b3526fa75, xeedad81aaed42a76 x789564759d365819)
	{
		if (xe134235b3526fa75.x3bcd232d01c14846.xa7799d48a3e6b897.Count <= 0 || !(xe134235b3526fa75.x3bcd232d01c14846.xa7799d48a3e6b897.Peek() is FieldSeparator))
		{
			FieldSeparator fieldSeparator = new FieldSeparator(xe134235b3526fa75.x2c8c6741422a1298, x789564759d365819, FieldType.FieldNone);
			xe134235b3526fa75.x1fa9148f6731ff24(fieldSeparator);
			if (!x789564759d365819.x0392c0938d22c790)
			{
				xe134235b3526fa75.x3bcd232d01c14846.xa7799d48a3e6b897.Push(fieldSeparator);
			}
		}
	}

	private static void xd464ae4d05dc89da(xdfce7f4f687956d7 xe134235b3526fa75, xeedad81aaed42a76 x789564759d365819)
	{
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		FieldEnd fieldEnd = new FieldEnd(xe134235b3526fa75.x2c8c6741422a1298, x789564759d365819, FieldType.FieldNone, hasSeparator: false);
		xe134235b3526fa75.x1fa9148f6731ff24(fieldEnd);
		if (x789564759d365819.x0392c0938d22c790 || x3bcd232d01c.xa7799d48a3e6b897.Count == 0)
		{
			return;
		}
		x928b31adb20d5cc6 xe01ae93d9fe5a = default(x928b31adb20d5cc6);
		xe01ae93d9fe5a.x9fd888e65466818c = fieldEnd;
		if (x3bcd232d01c.xa7799d48a3e6b897.Peek() is FieldSeparator)
		{
			xe01ae93d9fe5a.x43604484a3deae4f = (FieldSeparator)x3bcd232d01c.xa7799d48a3e6b897.Pop();
		}
		if (x3bcd232d01c.xa7799d48a3e6b897.Count == 0)
		{
			xe01ae93d9fe5a.x45aed43ab4f2045c();
			return;
		}
		xe01ae93d9fe5a.x12cb12b5d2cad53d = (FieldStart)x3bcd232d01c.xa7799d48a3e6b897.Pop();
		FieldType fieldType = x5c29822913be33c1.x338a5159d9aa7162(xe01ae93d9fe5a.x29815ca66d57cfae());
		xe01ae93d9fe5a.x8fdbe5468986594f(fieldType);
		if (xe01ae93d9fe5a.x43604484a3deae4f == null && x5c29822913be33c1.xd668adf9377c05ee(fieldType) == x5576a2206c3fc746.xd4d82c4665f71358)
		{
			xe01ae93d9fe5a.x43604484a3deae4f = new FieldSeparator(xe134235b3526fa75.x2c8c6741422a1298, x789564759d365819, fieldType);
			xe134235b3526fa75.xbe11e60379d74111(xe134235b3526fa75.x0547ea8ef1ef19b1, xe01ae93d9fe5a.x43604484a3deae4f, xe01ae93d9fe5a.x9fd888e65466818c);
		}
		xe01ae93d9fe5a.x9fd888e65466818c.x254cab982e9946b2(xe01ae93d9fe5a.x43604484a3deae4f != null);
		xe01ae93d9fe5a.x6e0f5b69ee5c3db9();
		x55c809ab6c9605c7(xe134235b3526fa75, xe01ae93d9fe5a);
	}

	private static void x55c809ab6c9605c7(xdfce7f4f687956d7 xe134235b3526fa75, x928b31adb20d5cc6 xe01ae93d9fe5a880)
	{
		switch (xe01ae93d9fe5a880.x12cb12b5d2cad53d.FieldType)
		{
		case FieldType.FieldFormTextInput:
		case FieldType.FieldFormCheckBox:
		case FieldType.FieldFormDropDown:
			x9f08f6a069f66488(xe134235b3526fa75, xe01ae93d9fe5a880);
			break;
		case FieldType.FieldIncludePicture:
			if (!xe134235b3526fa75.x1e4394fcb6d34948.PreserveIncludePictureField)
			{
				x5224beeb54ef7377(xe134235b3526fa75, xe01ae93d9fe5a880);
			}
			break;
		}
	}

	private static void x9f08f6a069f66488(xdfce7f4f687956d7 xe134235b3526fa75, x928b31adb20d5cc6 xe01ae93d9fe5a880)
	{
		bool x325f1926b78ae5cd = xe134235b3526fa75.x325f1926b78ae5cd;
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		if ((x3bcd232d01c.x58bf2a36f9adf9a9 != null || !x325f1926b78ae5cd) && (x3bcd232d01c.x303ddb1b000492b0 != null || x325f1926b78ae5cd))
		{
			xeedad81aaed42a76 runPr = (xeedad81aaed42a76)xe01ae93d9fe5a880.x12cb12b5d2cad53d.xeedad81aaed42a76.x8b61531c8ea35b85();
			x58bf2a36f9adf9a9 formFieldPr = (x325f1926b78ae5cd ? x3bcd232d01c.x58bf2a36f9adf9a9 : xf2b9ab75a7571713.xded02c37c7e1688e(x3bcd232d01c.x303ddb1b000492b0));
			FormField x40e458b3a58f = new FormField(xe134235b3526fa75.x2c8c6741422a1298, formFieldPr, runPr);
			Node xb29355c4bafca5da = xe01ae93d9fe5a880.xb29355c4bafca5da;
			xe134235b3526fa75.xbe11e60379d74111(xb29355c4bafca5da.ParentNode, x40e458b3a58f, xb29355c4bafca5da);
			x3bcd232d01c.x58bf2a36f9adf9a9 = null;
		}
	}

	private static void x5224beeb54ef7377(xdfce7f4f687956d7 xe134235b3526fa75, x928b31adb20d5cc6 xe01ae93d9fe5a880)
	{
		Node nextSibling = xe01ae93d9fe5a880.x43604484a3deae4f.NextSibling;
		Shape shape;
		switch (nextSibling.NodeType)
		{
		case NodeType.Shape:
			shape = (Shape)nextSibling;
			break;
		case NodeType.GroupShape:
			shape = (Shape)nextSibling.NextSibling;
			break;
		case NodeType.FieldEnd:
			shape = new Shape(xe134235b3526fa75.x2c8c6741422a1298, ShapeType.Image);
			shape.Width = 1.0;
			shape.Height = 1.0;
			shape.WrapType = WrapType.Inline;
			xe134235b3526fa75.x4a3d790f43378811(xe01ae93d9fe5a880.x43604484a3deae4f.ParentNode, shape, xe01ae93d9fe5a880.x43604484a3deae4f);
			break;
		case NodeType.BookmarkStart:
		{
			shape = (Shape)nextSibling.NextSibling;
			BookmarkStart x40e458b3a58f = (BookmarkStart)nextSibling;
			xe134235b3526fa75.xbe11e60379d74111(xe01ae93d9fe5a880.x12cb12b5d2cad53d.ParentNode, x40e458b3a58f, xe01ae93d9fe5a880.x12cb12b5d2cad53d);
			break;
		}
		default:
			return;
		}
		shape.WrapType = WrapType.Inline;
		if (!shape.ImageData.IsLink)
		{
			xb7fab88ef0a63baf xb7fab88ef0a63baf = xb7fab88ef0a63baf.x1f490eac106aee12(xe01ae93d9fe5a880.x071b5fbe719eaec7());
			shape.ImageData.SourceFullName = xb7fab88ef0a63baf.x9f8e4dc805c6986e;
		}
		x20669c7c6ab6ce7b(xe01ae93d9fe5a880);
	}

	private static void x20669c7c6ab6ce7b(x928b31adb20d5cc6 xe01ae93d9fe5a880)
	{
		Node node = xe01ae93d9fe5a880.x12cb12b5d2cad53d;
		while (node != xe01ae93d9fe5a880.x9fd888e65466818c.NextSibling)
		{
			Node nextSibling = node.NextSibling;
			switch (node.NodeType)
			{
			default:
				node.Remove();
				break;
			case NodeType.GroupShape:
			case NodeType.Shape:
				break;
			}
			node = nextSibling;
		}
	}
}
