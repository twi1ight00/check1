using Aspose.Words;
using Aspose.Words.Drawing;
using Aspose.Words.Fields;
using x011d489fb9df7027;
using x38a89dee67fc7a16;
using x6c95d9cf46ff5f25;
using xfbd1009a0cbb9842;

namespace x28925c9b27b37a46;

internal class x3f78a18d30ea7a7f
{
	private x3f78a18d30ea7a7f()
	{
	}

	internal static void x55c809ab6c9605c7(x928b31adb20d5cc6 xe01ae93d9fe5a880, Shape x4d691c6466f15c8f, LoadOptions x27aceb70372bde46)
	{
		switch (xe01ae93d9fe5a880.x12cb12b5d2cad53d.FieldType)
		{
		case FieldType.FieldHyperlink:
			x3a0b4c515afb8140(xe01ae93d9fe5a880);
			break;
		case FieldType.FieldShape:
			xc862901c9e5ebfb5(xe01ae93d9fe5a880);
			break;
		case FieldType.FieldIncludePicture:
			if (!x27aceb70372bde46.PreserveIncludePictureField)
			{
				x5224beeb54ef7377(xe01ae93d9fe5a880);
			}
			break;
		case FieldType.FieldEmbed:
		case FieldType.FieldOcx:
			x46a8a663d7ae55ef(xe01ae93d9fe5a880, x4d691c6466f15c8f);
			break;
		case FieldType.FieldLink:
			xb9d12090261ba330(xe01ae93d9fe5a880, x4d691c6466f15c8f);
			break;
		case FieldType.FieldQuote:
			x7f83d3d2b88c65b3(xe01ae93d9fe5a880);
			break;
		}
	}

	private static void x3a0b4c515afb8140(x928b31adb20d5cc6 xe01ae93d9fe5a880)
	{
		if (xe01ae93d9fe5a880.x43604484a3deae4f == null)
		{
			return;
		}
		Node nextSibling = xe01ae93d9fe5a880.x43604484a3deae4f.NextSibling;
		if (nextSibling is ShapeBase && nextSibling.NextSibling == xe01ae93d9fe5a880.x9fd888e65466818c)
		{
			ShapeBase shapeBase = (ShapeBase)nextSibling;
			xdfac57ec3a49a3fc xdfac57ec3a49a3fc = xdfac57ec3a49a3fc.x1f490eac106aee12(xe01ae93d9fe5a880.x071b5fbe719eaec7());
			shapeBase.HRef = xdfac57ec3a49a3fc.x58c712b0d1d1c39b;
			if (x0d299f323d241756.x5959bccb67bbf051(xdfac57ec3a49a3fc.x3c9d02bc0fddd226))
			{
				shapeBase.ScreenTip = xdfac57ec3a49a3fc.x3c9d02bc0fddd226;
			}
			if (x0d299f323d241756.x5959bccb67bbf051(xdfac57ec3a49a3fc.x42f4c234c9358072))
			{
				shapeBase.Target = xdfac57ec3a49a3fc.x42f4c234c9358072;
			}
			x20669c7c6ab6ce7b(xe01ae93d9fe5a880);
		}
	}

	private static void x7f83d3d2b88c65b3(x928b31adb20d5cc6 xe01ae93d9fe5a880)
	{
		if (xe01ae93d9fe5a880.x43604484a3deae4f.NextSibling is ShapeBase shapeBase && shapeBase.xf7125312c7ee115c.x263d579af1d0d43f(780))
		{
			x692e7b2898e41653(xe01ae93d9fe5a880);
			x5699f8523a546a42.x52b190e626f65140(xe01ae93d9fe5a880.x12cb12b5d2cad53d, x4ec19a117bbb0963: true, xe01ae93d9fe5a880.x9fd888e65466818c, xead571f03cb4ee1d: true, xe1bd913bc72a8d58.x93e9ea6b6c905cc5);
		}
	}

	private static void xc862901c9e5ebfb5(x928b31adb20d5cc6 xe01ae93d9fe5a880)
	{
		ShapeBase shapeBase = x692e7b2898e41653(xe01ae93d9fe5a880);
		if (shapeBase != null && !shapeBase.IsImage)
		{
			shapeBase.WrapType = WrapType.Inline;
		}
		x5699f8523a546a42.x52b190e626f65140(xe01ae93d9fe5a880.x12cb12b5d2cad53d, x4ec19a117bbb0963: true, xe01ae93d9fe5a880.x9fd888e65466818c, xead571f03cb4ee1d: true, xe1bd913bc72a8d58.x93e9ea6b6c905cc5);
	}

	private static void x5224beeb54ef7377(x928b31adb20d5cc6 xe01ae93d9fe5a880)
	{
		xb7fab88ef0a63baf xb7fab88ef0a63baf = xb7fab88ef0a63baf.x1f490eac106aee12(xe01ae93d9fe5a880.x071b5fbe719eaec7());
		ShapeBase shapeBase = x692e7b2898e41653(xe01ae93d9fe5a880);
		if (shapeBase == null)
		{
			Shape shape = new Shape(xe01ae93d9fe5a880.x12cb12b5d2cad53d.Document, ShapeType.Image);
			xe01ae93d9fe5a880.x12cb12b5d2cad53d.ParentNode.InsertBefore(shape, xe01ae93d9fe5a880.x12cb12b5d2cad53d);
			shape.Width = 1.0;
			shape.Height = 1.0;
			shape.WrapType = WrapType.Inline;
			shape.ImageData.SourceFullName = xb7fab88ef0a63baf.x9f8e4dc805c6986e;
			byte[] array = shape.ImageData.x096dc407252fbea0();
			if (array != null)
			{
				xa2745adfabe0c674 xa2745adfabe0c = xdd1b8f14cc8ba86d.x16a7fb03c627ebfb(array);
				shape.Width = xa2745adfabe0c.xd0c3f0768d960161;
				shape.Height = xa2745adfabe0c.xeb129b9a992183c5;
			}
		}
		else if (shapeBase is Shape)
		{
			Shape shape2 = (Shape)shapeBase;
			shape2.WrapType = WrapType.Inline;
			if (!shape2.ImageData.IsLink && !x0d4d45882065c63e.xc327dd161360e68e(xb7fab88ef0a63baf.x9f8e4dc805c6986e))
			{
				shape2.ImageData.SourceFullName = xb7fab88ef0a63baf.x9f8e4dc805c6986e;
			}
		}
		x5699f8523a546a42.x52b190e626f65140(xe01ae93d9fe5a880.x12cb12b5d2cad53d, x4ec19a117bbb0963: true, xe01ae93d9fe5a880.x9fd888e65466818c, xead571f03cb4ee1d: true, xe1bd913bc72a8d58.x93e9ea6b6c905cc5);
	}

	private static void x46a8a663d7ae55ef(x928b31adb20d5cc6 xe01ae93d9fe5a880, Shape x4d691c6466f15c8f)
	{
		if (x4d691c6466f15c8f != null)
		{
			ShapeType x02f2ab213025de6d = ((xe01ae93d9fe5a880.x12cb12b5d2cad53d.FieldType == FieldType.FieldOcx) ? ShapeType.OleControl : ShapeType.OleObject);
			if (xe01ae93d9fe5a880.x43604484a3deae4f.x71d39fdf56861cca != null)
			{
				x4d691c6466f15c8f.x88d1b78392d1a0ab(x02f2ab213025de6d);
				x4d691c6466f15c8f.OleFormat.x58932c7e6fa3b905 = xe01ae93d9fe5a880.x43604484a3deae4f.x71d39fdf56861cca;
				x623dea19444a5371 x623dea19444a = x623dea19444a5371.x1f490eac106aee12(xe01ae93d9fe5a880.x071b5fbe719eaec7());
				x4d691c6466f15c8f.OleFormat.ProgId = x623dea19444a.xe5d13ccbc3df998a;
			}
			else
			{
				x4d691c6466f15c8f.x88d1b78392d1a0ab(ShapeType.Image);
			}
			x20669c7c6ab6ce7b(xe01ae93d9fe5a880);
		}
	}

	private static void xb9d12090261ba330(x928b31adb20d5cc6 xe01ae93d9fe5a880, Shape x4d691c6466f15c8f)
	{
		if (x4d691c6466f15c8f == null)
		{
			return;
		}
		xcae1c68ad9da73de xcae1c68ad9da73de = xcae1c68ad9da73de.x1f490eac106aee12(xe01ae93d9fe5a880.x071b5fbe719eaec7());
		if (xcae1c68ad9da73de.x2e7d767f7d782a7a != x2e7d767f7d782a7a.x5896ed36f2cf9162)
		{
			x4d691c6466f15c8f.x88d1b78392d1a0ab(ShapeType.OleObject);
			if (xe01ae93d9fe5a880.x43604484a3deae4f.x71d39fdf56861cca != null)
			{
				x4d691c6466f15c8f.OleFormat.x58932c7e6fa3b905 = xe01ae93d9fe5a880.x43604484a3deae4f.x71d39fdf56861cca;
			}
			OleFormat oleFormat = x4d691c6466f15c8f.OleFormat;
			oleFormat.ProgId = xcae1c68ad9da73de.xe5d13ccbc3df998a;
			oleFormat.SourceFullName = xcae1c68ad9da73de.x9f8e4dc805c6986e;
			oleFormat.AutoUpdate = xcae1c68ad9da73de.xe8ae08e6819999f9;
			oleFormat.x577033bbed151076 = xcae1c68ad9da73de.x577033bbed151076;
			oleFormat.x2e7d767f7d782a7a = xcae1c68ad9da73de.x2e7d767f7d782a7a;
			if (x0d299f323d241756.x5959bccb67bbf051(xcae1c68ad9da73de.x336c298ccd00f056))
			{
				oleFormat.SourceItem = xcae1c68ad9da73de.x336c298ccd00f056;
			}
			x20669c7c6ab6ce7b(xe01ae93d9fe5a880);
		}
	}

	private static ShapeBase x692e7b2898e41653(x928b31adb20d5cc6 xe01ae93d9fe5a880)
	{
		Node node = xe01ae93d9fe5a880.x43604484a3deae4f.NextSibling;
		ShapeBase result = null;
		while (node != xe01ae93d9fe5a880.x9fd888e65466818c)
		{
			Node nextSibling = node.NextSibling;
			if (node.NodeType == NodeType.Shape || node.NodeType == NodeType.GroupShape)
			{
				result = (ShapeBase)node;
			}
			xe01ae93d9fe5a880.x12cb12b5d2cad53d.ParentNode.InsertBefore(node, xe01ae93d9fe5a880.x12cb12b5d2cad53d);
			node = nextSibling;
		}
		return result;
	}

	private static void x20669c7c6ab6ce7b(x928b31adb20d5cc6 xe01ae93d9fe5a880)
	{
		while (xe01ae93d9fe5a880.x43604484a3deae4f.NextSibling is ShapeBase newChild)
		{
			xe01ae93d9fe5a880.x12cb12b5d2cad53d.ParentNode.InsertBefore(newChild, xe01ae93d9fe5a880.x12cb12b5d2cad53d);
		}
		x5699f8523a546a42.x52b190e626f65140(xe01ae93d9fe5a880.x12cb12b5d2cad53d, x4ec19a117bbb0963: true, xe01ae93d9fe5a880.x9fd888e65466818c, xead571f03cb4ee1d: true, xe1bd913bc72a8d58.x93e9ea6b6c905cc5);
	}
}
