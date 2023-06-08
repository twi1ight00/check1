using System;
using System.IO;
using Aspose.Words;
using Aspose.Words.Drawing;
using x011d489fb9df7027;
using x1495530f35d79681;
using x5af3f327d745698a;
using x6c95d9cf46ff5f25;
using x79490184cecf12a1;
using xb92b7270f78a4e8d;
using xda075892eccab2ad;
using xf9a9481c3f63a419;
using xfc5388ad7dff404f;

namespace x7c7a1dceb600404e;

internal class xd344eb866bc83d16
{
	private const string xf340e6292967b718 = "Import of element '{0}' is not supported upon reading OLE specific elements by Aspose.Words.";

	private xd344eb866bc83d16()
	{
	}

	internal static Shape x2ec78d2303214266(x874ec168cb1feb74 x0f7b23d1c393aed9)
	{
		string text = "";
		xd8c3135513b9115b xd8c3135513b9115b = null;
		string xcd113e16773803b = "";
		string xc06e652f250a = "";
		x3c85359e1389ad43 x3bcd232d01c = x0f7b23d1c393aed9.x3bcd232d01c14846;
		while (x3bcd232d01c.x1ac1960adc8c4c39())
		{
			string xd2f68ee6f47e9dfb = x3bcd232d01c.xd2f68ee6f47e9dfb;
			switch (x3bcd232d01c.xa66385d80d4d296f)
			{
			case "id":
				xc06e652f250a = xd2f68ee6f47e9dfb;
				break;
			case "shapeid":
				xcd113e16773803b = xd2f68ee6f47e9dfb;
				break;
			case "name":
				text = xd2f68ee6f47e9dfb;
				break;
			}
		}
		Shape shape = (Shape)x0f7b23d1c393aed9.x5b35a0b873aef5ad(xcd113e16773803b);
		shape.x88d1b78392d1a0ab(ShapeType.OleControl);
		xa52ef41af20225f0 xa52ef41af20225f = (xa52ef41af20225f0)x0f7b23d1c393aed9;
		xa2f1c3dcbd86f20a xa2f1c3dcbd86f20a = xa52ef41af20225f.xd4e2719ccf56f4d7(x0f7b23d1c393aed9.x052a6c2e603b1662(xc06e652f250a));
		x3c85359e1389ad43 x3c85359e1389ad = new x3c85359e1389ad43(xa2f1c3dcbd86f20a.xb8a774e0111d0fbe);
		string text2 = x3c85359e1389ad.xd68abcd61e368af9("persistence", null);
		string g = x3c85359e1389ad.xd68abcd61e368af9("classid", null);
		switch (text2)
		{
		case "persistPropertyBag":
			shape.OleFormat.x58932c7e6fa3b905 = new xb7e718098524b76c(xa2f1c3dcbd86f20a.xb8a774e0111d0fbe, "application/vnd.ms-office.activeX+xml", text, new Guid(g));
			break;
		case "persistStorage":
		case "persistStream":
		{
			xa2f1c3dcbd86f20a xa2f1c3dcbd86f20a2 = xa52ef41af20225f.xd4e2719ccf56f4d7(xa2f1c3dcbd86f20a.x052a6c2e603b1662("rId1"));
			if (text2 == "persistStorage")
			{
				xd8c3135513b9115b = new xd8c3135513b9115b(xa2f1c3dcbd86f20a2.x108ab3c765e78082());
			}
			else
			{
				xd8c3135513b9115b = new xd8c3135513b9115b(new Guid(g));
				xd8c3135513b9115b.x29e7ace4c90f74cd.xd6b6ed77479ef68c("\u0003OCXDATA", xa2f1c3dcbd86f20a2.x108ab3c765e78082());
			}
			x9ac0da7388ceac43.x4123eb825f799ecb(xd8c3135513b9115b.x29e7ace4c90f74cd, new x432b11171adc04ec(text));
			x9ac0da7388ceac43.x4123eb825f799ecb(xd8c3135513b9115b.x29e7ace4c90f74cd, new x5a72a7bc4849e9de(x9db50866da3cf409.x456f0db0f2a0e28f | x9db50866da3cf409.x0ec1c233749a3d34, xb86dce4d7748d175.x839e3ee01eaf6c4d, x0c4de7b78d968e81.x5459fadea977d08d));
			shape.OleFormat.x58932c7e6fa3b905 = new x71d39fdf56861cca(shape.xea1e81378298fa81, xd8c3135513b9115b.x29e7ace4c90f74cd);
			break;
		}
		case "persistStreamInit":
			x3bcd232d01c.xbd5e5733680bbfc8(WarningType.DataLossCategory, WarningSource.Shapes, $"Import of element '{x3bcd232d01c.xa66385d80d4d296f}' is not supported upon reading OLE specific elements by Aspose.Words.");
			break;
		default:
			throw new InvalidOperationException("Invalid persistence value.");
		}
		return shape;
	}

	internal static Shape xda2e825e9f754413(x874ec168cb1feb74 x0f7b23d1c393aed9)
	{
		string text = "";
		string ocxName = "";
		string xcd113e16773803b = "";
		string text2 = "";
		string text3 = "";
		string text4 = "";
		x3c85359e1389ad43 x3bcd232d01c = x0f7b23d1c393aed9.x3bcd232d01c14846;
		while (x3bcd232d01c.x1ac1960adc8c4c39())
		{
			string xd2f68ee6f47e9dfb = x3bcd232d01c.xd2f68ee6f47e9dfb;
			switch (x3bcd232d01c.xa66385d80d4d296f)
			{
			case "data":
				text = xd2f68ee6f47e9dfb;
				break;
			case "name":
				ocxName = xd2f68ee6f47e9dfb;
				break;
			case "classid":
				text4 = xd2f68ee6f47e9dfb;
				break;
			case "shapeid":
				xcd113e16773803b = xd2f68ee6f47e9dfb;
				break;
			case "w":
				text2 = xd2f68ee6f47e9dfb;
				break;
			case "h":
				text3 = xd2f68ee6f47e9dfb;
				break;
			case "align":
				x3bcd232d01c.xbbf9a1ead81dd3a1(WarningType.MinorFormattingLossCategory, WarningSource.Shapes, $"Import of element '{x3bcd232d01c.xa66385d80d4d296f}' is not supported upon reading OLE specific elements by Aspose.Words.");
				break;
			case "iPersistPropertyBag":
				x3bcd232d01c.xbbf9a1ead81dd3a1(WarningType.MinorFormattingLossCategory, WarningSource.Shapes, $"Import of element '{x3bcd232d01c.xa66385d80d4d296f}' is not supported upon reading OLE specific elements by Aspose.Words.");
				break;
			default:
				x3bcd232d01c.xbbf9a1ead81dd3a1(WarningType.MinorFormattingLossCategory, WarningSource.Shapes, $"Import of element '{x3bcd232d01c.xa66385d80d4d296f}' is not supported upon reading OLE specific elements by Aspose.Words.");
				break;
			case "id":
			case "class":
				break;
			}
		}
		Shape shape = (Shape)x0f7b23d1c393aed9.x5b35a0b873aef5ad(xcd113e16773803b);
		if (shape == null)
		{
			shape = new Shape(x0f7b23d1c393aed9.x2c8c6741422a1298);
			shape.x88d1b78392d1a0ab(ShapeType.OleControl);
			shape.WrapType = WrapType.Inline;
		}
		if (x0d299f323d241756.x5959bccb67bbf051(text2))
		{
			shape.xf524ccc95fe8e714(ConvertUtil.PixelToPoint(xca004f56614e2431.xec25d08a2af152f0(text2)));
		}
		if (x0d299f323d241756.x5959bccb67bbf051(text3))
		{
			shape.x404ab2fc377ad1ed(ConvertUtil.PixelToPoint(xca004f56614e2431.xec25d08a2af152f0(text3)));
		}
		xd8c3135513b9115b xd8c3135513b9115b = null;
		if (text.StartsWith("DATA:application/x-oleobject;BASE64,"))
		{
			text = text.Substring("DATA:application/x-oleobject;BASE64,".Length);
			byte[] buffer = Convert.FromBase64String(text);
			if (text4.StartsWith("CLSID:"))
			{
				text4 = text4.Substring("CLSID:".Length);
			}
			Guid clsid = (x0d299f323d241756.x5959bccb67bbf051(text4) ? new Guid(text4) : Guid.Empty);
			xd8c3135513b9115b = new xd8c3135513b9115b(new xe7be411416cfcd54(clsid));
			xd8c3135513b9115b.x29e7ace4c90f74cd.xd6b6ed77479ef68c("\u0003OCXDATA", new MemoryStream(buffer));
		}
		else
		{
			byte[] array = x0f7b23d1c393aed9.x7b29fad09d9101c5(text);
			if (array != null)
			{
				xd8c3135513b9115b = new xd8c3135513b9115b(new MemoryStream(array));
			}
		}
		if (xd8c3135513b9115b != null)
		{
			x9ac0da7388ceac43.x4123eb825f799ecb(xd8c3135513b9115b.x29e7ace4c90f74cd, new x432b11171adc04ec(ocxName));
			x9ac0da7388ceac43.x4123eb825f799ecb(xd8c3135513b9115b.x29e7ace4c90f74cd, new x5a72a7bc4849e9de(x9db50866da3cf409.x456f0db0f2a0e28f | x9db50866da3cf409.x0ec1c233749a3d34, xb86dce4d7748d175.x839e3ee01eaf6c4d, x0c4de7b78d968e81.x5459fadea977d08d));
			shape.OleFormat.x58932c7e6fa3b905 = new x71d39fdf56861cca(shape.xea1e81378298fa81, xd8c3135513b9115b.x29e7ace4c90f74cd);
		}
		return shape;
	}

	internal static void x9df59a055a98eb39(x874ec168cb1feb74 x0f7b23d1c393aed9)
	{
		bool flag = false;
		string text = null;
		string xcd113e16773803b = null;
		string text2 = null;
		string text3 = "";
		bool autoUpdate = false;
		bool xa3c32c64cb78d = false;
		string text4 = null;
		x3c85359e1389ad43 x3bcd232d01c = x0f7b23d1c393aed9.x3bcd232d01c14846;
		while (x3bcd232d01c.x1ac1960adc8c4c39())
		{
			switch (x3bcd232d01c.xa66385d80d4d296f)
			{
			case "Type":
				flag = x0d299f323d241756.x90637a473b1ceaaa(x3bcd232d01c.xd2f68ee6f47e9dfb, "Link");
				break;
			case "ProgID":
				text = x3bcd232d01c.xd2f68ee6f47e9dfb;
				break;
			case "ShapeID":
				xcd113e16773803b = x3bcd232d01c.xd2f68ee6f47e9dfb;
				break;
			case "DrawAspect":
				xa3c32c64cb78d = x0d299f323d241756.x90637a473b1ceaaa(x3bcd232d01c.xd2f68ee6f47e9dfb, "Icon");
				break;
			case "ObjectID":
				text2 = x3bcd232d01c.xd2f68ee6f47e9dfb;
				break;
			case "Moniker":
				text3 = x3bcd232d01c.xd2f68ee6f47e9dfb;
				break;
			case "UpdateMode":
				autoUpdate = x0d299f323d241756.x90637a473b1ceaaa(x3bcd232d01c.xd2f68ee6f47e9dfb, "Always");
				break;
			case "id":
				text4 = x3bcd232d01c.xd2f68ee6f47e9dfb;
				break;
			default:
				x3bcd232d01c.xbbf9a1ead81dd3a1(WarningType.MinorFormattingLossCategory, WarningSource.Shapes, $"Import of element '{x3bcd232d01c.xa66385d80d4d296f}' is not supported upon reading OLE specific elements by Aspose.Words.");
				break;
			}
		}
		Shape shape = (Shape)x0f7b23d1c393aed9.x5b35a0b873aef5ad(xcd113e16773803b);
		if (shape == null)
		{
			return;
		}
		shape.x88d1b78392d1a0ab(ShapeType.OleObject);
		OleFormat oleFormat = shape.OleFormat;
		oleFormat.AutoUpdate = autoUpdate;
		oleFormat.xf3959158bd894c23(xa3c32c64cb78d);
		if (text != null)
		{
			oleFormat.ProgId = text;
		}
		if (flag)
		{
			if (x0d299f323d241756.x5959bccb67bbf051(text4))
			{
				text3 = x0f7b23d1c393aed9.x052a6c2e603b1662(text4);
			}
			if (x0d299f323d241756.x5959bccb67bbf051(text3))
			{
				string[] array = text3.Split(new char[1] { '!' }, 2);
				oleFormat.SourceFullName = array[0];
				if (array.Length > 1)
				{
					oleFormat.SourceItem = array[1];
				}
			}
		}
		else
		{
			string xeaf1b27180c0557b = (x0d299f323d241756.x5959bccb67bbf051(text4) ? text4 : text2);
			xd142dcacd7ddc9dd xd142dcacd7ddc9dd = x0f7b23d1c393aed9.x36eb835297f7b346(xeaf1b27180c0557b);
			if (xd142dcacd7ddc9dd != null)
			{
				int num = xc1b08afa36bf580c.xe46f9c7779fac076(text2);
				if (num != int.MinValue)
				{
					xd142dcacd7ddc9dd.xea1e81378298fa81 = num;
				}
				oleFormat.x58932c7e6fa3b905 = xd142dcacd7ddc9dd;
			}
		}
		while (x3bcd232d01c.x152cbadbfa8061b1("OLEObject"))
		{
			switch (x3bcd232d01c.xa66385d80d4d296f)
			{
			case "LinkType":
				oleFormat.x2e7d767f7d782a7a = xf4107e64edda7fac.x1b81fec65ccf8c20(x3bcd232d01c.x2a1ea9d24e62bf84());
				break;
			case "LockedField":
				oleFormat.IsLocked = x3bcd232d01c.xe90b56390d1b0697(xc6e85c82d0d89508: true);
				break;
			case "WordFieldCodes":
			case "FieldCodes":
			{
				string text5 = x3bcd232d01c.x2a1ea9d24e62bf84();
				if (text5.Length > 0)
				{
					char c = text5[text5.Length - 1];
					if (c >= '0' && c <= '5')
					{
						oleFormat.x577033bbed151076 = c - 48;
					}
				}
				else
				{
					oleFormat.x577033bbed151076 = 0;
				}
				break;
			}
			default:
				x3bcd232d01c.xbd5e5733680bbfc8(WarningType.MinorFormattingLossCategory, WarningSource.Shapes, $"Import of element '{x3bcd232d01c.xa66385d80d4d296f}' is not supported upon reading OLE specific elements by Aspose.Words.");
				break;
			}
		}
	}
}
