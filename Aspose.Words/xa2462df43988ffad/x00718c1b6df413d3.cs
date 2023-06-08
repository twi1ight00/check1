using System;
using System.Drawing;
using Aspose.Words;
using Aspose.Words.Drawing;
using x011d489fb9df7027;
using x6c95d9cf46ff5f25;
using xbe73d5820f7f4ae3;
using xf9a9481c3f63a419;

namespace xa2462df43988ffad;

internal class x00718c1b6df413d3
{
	private readonly xdb0bf9f81de4b38c x9b287b671d592594;

	private readonly x9884289168bac01e x12954a224495d3c0;

	private readonly x560f0e9efcf5b9b1 x6962cbeae4129aa3;

	private readonly xe4424b4bab7902c7 xcb336a75c6f3d024;

	internal x00718c1b6df413d3(xdb0bf9f81de4b38c writer)
	{
		x9b287b671d592594 = writer;
		x12954a224495d3c0 = new x9884289168bac01e(x9b287b671d592594);
		x6962cbeae4129aa3 = new x560f0e9efcf5b9b1(x9b287b671d592594);
		xcb336a75c6f3d024 = new xe4424b4bab7902c7(x9b287b671d592594);
	}

	internal VisitorAction x1f70c910ab814928(ShapeBase x8739b0dd3627f37e)
	{
		if (x9b287b671d592594.x05ee8ce4d7312eb5 == x14bf6f47128e4438.x62896619d90ad964)
		{
			return VisitorAction.Continue;
		}
		if (x901504524a3c48d7(x8739b0dd3627f37e))
		{
			return VisitorAction.SkipThisNode;
		}
		if (x57463b022af339cb(x8739b0dd3627f37e))
		{
			return VisitorAction.Continue;
		}
		if (x9b287b671d592594.xb872fbc83a2cb9a6)
		{
			if (xd63ad08213e4f0d0(x8739b0dd3627f37e))
			{
				x6962cbeae4129aa3.xaedce5725e456ac5(x8739b0dd3627f37e, x637e9fd1a4793118: true);
			}
			if (x57c6286d036794cb(x8739b0dd3627f37e))
			{
				x6962cbeae4129aa3.xaedce5725e456ac5(x8739b0dd3627f37e, x637e9fd1a4793118: false);
			}
		}
		else if (x9b287b671d592594.x05ee8ce4d7312eb5 == x14bf6f47128e4438.x3231bc142724c8b3)
		{
			xa3388c20c015dca4(x8739b0dd3627f37e);
		}
		else
		{
			x9c77c7e782b62883 xe1410f585439c7d = x9b287b671d592594.xe1410f585439c7d4;
			if (xd63ad08213e4f0d0(x8739b0dd3627f37e))
			{
				x12954a224495d3c0.xffb053d2a78c4e1b();
			}
			if (x8739b0dd3627f37e is GroupShape)
			{
				xa07aa514e9082b3a(x8739b0dd3627f37e);
			}
			else if (x8739b0dd3627f37e.ShapeType == ShapeType.Line)
			{
				x7e64784cc0e845d6((Shape)x8739b0dd3627f37e, "draw:line");
			}
			else if (x6dcbdae8b4f7f447(x8739b0dd3627f37e.ShapeType))
			{
				x7e64784cc0e845d6((Shape)x8739b0dd3627f37e, "draw:connector");
			}
			else if (x04c50ba5db2fd684(x8739b0dd3627f37e))
			{
				xc94f3fcfa470eabd((Shape)x8739b0dd3627f37e, "draw:rect");
			}
			else if (x8739b0dd3627f37e.ShapeType == ShapeType.Ellipse)
			{
				xc94f3fcfa470eabd((Shape)x8739b0dd3627f37e, "draw:ellipse");
			}
			else if (x5abc6039e2a71e21(x8739b0dd3627f37e))
			{
				x8a1c8f440adbd6d8((Shape)x8739b0dd3627f37e);
			}
			else if (x9a3452914bb9074d(x8739b0dd3627f37e))
			{
				if (x0d299f323d241756.x5959bccb67bbf051(x8739b0dd3627f37e.HRef) && !(x8739b0dd3627f37e.ParentNode is GroupShape))
				{
					xe1410f585439c7d.x5a3f5d78674f78e4("draw:a");
					xe1410f585439c7d.x19b0790c272bbe88("xlink:type", "simple");
					xe1410f585439c7d.x19b0790c272bbe88("xlink:href", x8739b0dd3627f37e.HRef);
					xe1410f585439c7d.x53e7651cce580e9f("office:target-frame-name", x8739b0dd3627f37e.Target);
				}
				xa9a6cebffd173ca3(x8739b0dd3627f37e, "draw:frame");
			}
			if (xeb03d37c2336a1d6(x8739b0dd3627f37e))
			{
				xe1410f585439c7d.x2307058321cdb62f("draw:text-box");
				if (x8739b0dd3627f37e.xf7125312c7ee115c.xf7866f89640a29a3(4132) == null)
				{
					xe1410f585439c7d.x943f6be3acf634db("fo:min-height", "2.54cm");
				}
			}
			if (x8739b0dd3627f37e is Shape && (x8739b0dd3627f37e.IsImage || x8739b0dd3627f37e.xa170cce2bc40bdf5 || (x8739b0dd3627f37e as Shape).x169baa05e57bf312))
			{
				xcb336a75c6f3d024.x56c6b9360de4fb23("draw:image", (Shape)x8739b0dd3627f37e);
			}
		}
		x858236d2fc2ab29b(x8739b0dd3627f37e);
		return VisitorAction.Continue;
	}

	private bool x901504524a3c48d7(ShapeBase x8739b0dd3627f37e)
	{
		if (x8739b0dd3627f37e is Shape && !x9b287b671d592594.xb872fbc83a2cb9a6 && x9b287b671d592594.x05ee8ce4d7312eb5 != x14bf6f47128e4438.x3231bc142724c8b3)
		{
			Shape shape = (Shape)x8739b0dd3627f37e;
			object obj = x8739b0dd3627f37e.xf7125312c7ee115c.xf7866f89640a29a3(952);
			if (obj != null && (bool)obj && shape.x5e4f8afadf326191 == "text/javascript")
			{
				x9c77c7e782b62883 xe1410f585439c7d = x9b287b671d592594.xe1410f585439c7d4;
				xe1410f585439c7d.x5a3f5d78674f78e4("text:script");
				xe1410f585439c7d.x53e7651cce580e9f("script:language", "JavaScript");
				xe1410f585439c7d.x3d1be38abe5723e3(shape.xd402a2e9eed80360);
				xe1410f585439c7d.xf3cbeec41f083290("text:script");
				return true;
			}
		}
		return false;
	}

	private void x858236d2fc2ab29b(ShapeBase x8739b0dd3627f37e)
	{
		if (!(x8739b0dd3627f37e is Shape) || !x5abc6039e2a71e21(x8739b0dd3627f37e))
		{
			return;
		}
		Shape shape = (Shape)x8739b0dd3627f37e;
		if (shape.TextPath.On && x0d299f323d241756.x5959bccb67bbf051(shape.TextPath.Text))
		{
			string[] array = shape.TextPath.Text.Split('\n');
			string[] array2 = array;
			foreach (string text in array2)
			{
				Paragraph paragraph = new Paragraph(x9b287b671d592594.x2c8c6741422a1298);
				paragraph.xb2b69aae23a4ae6d(shape);
				paragraph.Runs.Add(new Run(x9b287b671d592594.x2c8c6741422a1298, text));
				paragraph.Accept(x9b287b671d592594);
			}
		}
	}

	private void x8a1c8f440adbd6d8(Shape x5770cdefd8931aa9)
	{
		x9b287b671d592594.x386588ea37d49369 = true;
		xa9a6cebffd173ca3(x5770cdefd8931aa9, "draw:custom-shape");
		xe33bcf5e8f34cfdf xe33bcf5e8f34cfdf2 = new xe33bcf5e8f34cfdf(x9b287b671d592594);
		xe33bcf5e8f34cfdf2.xb613ad2f230a7d2c(x5770cdefd8931aa9);
	}

	private bool x57463b022af339cb(ShapeBase x8739b0dd3627f37e)
	{
		if (x8739b0dd3627f37e is GroupShape)
		{
			if (x8739b0dd3627f37e.ChildNodes.Count == 0)
			{
				return true;
			}
			bool flag = true;
			foreach (Node childNode in x8739b0dd3627f37e.ChildNodes)
			{
				if (childNode is ShapeBase && !x57463b022af339cb(childNode as ShapeBase))
				{
					flag = false;
					break;
				}
			}
			if (flag)
			{
				return true;
			}
		}
		if ((x8739b0dd3627f37e is Shape && x08842fb60625980f((Shape)x8739b0dd3627f37e)) || x9b287b671d592594.x1c807e6130619b41)
		{
			return true;
		}
		bool flag2 = x8739b0dd3627f37e.GetAncestor(NodeType.Comment) != null;
		if ((!xdb0bf9f81de4b38c.xc8d1bb1390d5266d(x8739b0dd3627f37e) && x9b287b671d592594.x68e1404b914783c1) || flag2)
		{
			return true;
		}
		if (x8739b0dd3627f37e is Shape)
		{
			ImageData imageData = (x8739b0dd3627f37e as Shape).ImageData;
			if ((x8739b0dd3627f37e.IsImage || x8739b0dd3627f37e.xa170cce2bc40bdf5) && !imageData.x169baa05e57bf312 && !imageData.IsLink)
			{
				return true;
			}
		}
		return false;
	}

	private void xa3388c20c015dca4(ShapeBase x5770cdefd8931aa9)
	{
		xf7125312c7ee115c xf7125312c7ee115c = x5770cdefd8931aa9.xf7125312c7ee115c;
		for (int i = 0; i < xf7125312c7ee115c.xd44988f225497f3a; i++)
		{
			int num = xf7125312c7ee115c.xf15263674eb297bb(i);
			object obj = xf7125312c7ee115c.x6d3720b962bd3112(i);
			if (obj == null)
			{
				continue;
			}
			switch (num)
			{
			case 462:
			{
				DashStyle dashStyle = (DashStyle)obj;
				xf2c5ad4b4d2975c8 xf2c5ad4b4d2975c = x0eb9a864413f34de.x50ae2fd3acc88b8b(x5770cdefd8931aa9, x9b287b671d592594.xa74e18b54d0273fb.xcf2fd36bc07b78ec);
				if (dashStyle != 0 && dashStyle != 0 && x9b287b671d592594.xa74e18b54d0273fb.get_xe6d4b1b411ed94b5(xf2c5ad4b4d2975c.x759aa16c2016a289, (string)null, x0bfe184ad871a4c2: false, xafd04c36a00d5bcf: false) == null)
				{
					x9b287b671d592594.xa74e18b54d0273fb.xd6b6ed77479ef68c(xf2c5ad4b4d2975c, x0bfe184ad871a4c2: false, xafd04c36a00d5bcf: false);
				}
				break;
			}
			case 464:
				x9b287b671d592594.xd402537927b451df(xf7125312c7ee115c, (ArrowType)obj, xa59013d234619c58: true);
				break;
			case 465:
				x9b287b671d592594.xd402537927b451df(xf7125312c7ee115c, (ArrowType)obj, xa59013d234619c58: false);
				break;
			}
		}
	}

	private static bool x6dcbdae8b4f7f447(ShapeType x02f2ab213025de6d)
	{
		return x02f2ab213025de6d == ShapeType.StraightConnector1;
	}

	private static bool x08842fb60625980f(Shape x5770cdefd8931aa9)
	{
		ShapeType shapeType = x5770cdefd8931aa9.ShapeType;
		if (!x11261683cd6f7013(x5770cdefd8931aa9) && (!x5770cdefd8931aa9.IsImage || (!x5770cdefd8931aa9.ImageData.IsLink && !x5770cdefd8931aa9.ImageData.x169baa05e57bf312)) && !x5770cdefd8931aa9.x169baa05e57bf312 && !x5770cdefd8931aa9.xa170cce2bc40bdf5 && shapeType != ShapeType.Line && shapeType != ShapeType.Rectangle && shapeType != ShapeType.Ellipse && !x6dcbdae8b4f7f447(shapeType))
		{
			return !x5abc6039e2a71e21(x5770cdefd8931aa9);
		}
		return false;
	}

	private static bool x5abc6039e2a71e21(ShapeBase x8739b0dd3627f37e)
	{
		ShapeType shapeType = x8739b0dd3627f37e.ShapeType;
		if ((!(x8739b0dd3627f37e is Shape) || !(x8739b0dd3627f37e as Shape).x169baa05e57bf312) && shapeType != ShapeType.Image && shapeType != ShapeType.TextBox && shapeType != ShapeType.Group && shapeType != ShapeType.OleObject && shapeType != ShapeType.OleControl && shapeType != ShapeType.Rectangle && shapeType != ShapeType.Ellipse && shapeType != ShapeType.Line && shapeType != ShapeType.CurvedConnector2 && shapeType != ShapeType.ActionButtonBlank && shapeType != ShapeType.ActionButtonHome && shapeType != ShapeType.ActionButtonHelp && shapeType != ShapeType.ActionButtonInformation && shapeType != ShapeType.ActionButtonForwardNext && shapeType != ShapeType.ActionButtonBackPrevious && shapeType != ShapeType.ActionButtonEnd && shapeType != ShapeType.ActionButtonBeginning && shapeType != ShapeType.ActionButtonReturn && shapeType != ShapeType.ActionButtonDocument && shapeType != ShapeType.ActionButtonSound && shapeType != ShapeType.ActionButtonMovie && shapeType != ShapeType.TextSimple && shapeType != ShapeType.TextOctagon && shapeType != ShapeType.TextHexagon && shapeType != ShapeType.TextCurve && shapeType != ShapeType.TextWave && shapeType != ShapeType.TextRing && shapeType != ShapeType.TextOnCurve)
		{
			return shapeType != ShapeType.TextOnRing;
		}
		return false;
	}

	internal static bool xa3bfa3d00a716e76(Shape x5770cdefd8931aa9)
	{
		ShapeType shapeType = x5770cdefd8931aa9.ShapeType;
		if (!x5770cdefd8931aa9.IsImage && !x5770cdefd8931aa9.x6dcbdae8b4f7f447 && shapeType != ShapeType.Line && shapeType != ShapeType.Ellipse)
		{
			return x5abc6039e2a71e21(x5770cdefd8931aa9);
		}
		return true;
	}

	private static bool x11261683cd6f7013(Shape x5770cdefd8931aa9)
	{
		if (x5770cdefd8931aa9.ShapeType != ShapeType.TextBox)
		{
			if (x5770cdefd8931aa9.TextBox != null && !xa3bfa3d00a716e76(x5770cdefd8931aa9))
			{
				return x5770cdefd8931aa9.HasChildNodes;
			}
			return false;
		}
		return true;
	}

	private void xf5839392122362e4(ShapeBase x8739b0dd3627f37e)
	{
		x9c77c7e782b62883 xe1410f585439c7d = x9b287b671d592594.xe1410f585439c7d4;
		if (x8739b0dd3627f37e.IsInline)
		{
			xe1410f585439c7d.x19b0790c272bbe88("text:anchor-type", "as-char");
		}
		else if (x8739b0dd3627f37e.IsImage || x8739b0dd3627f37e.xa170cce2bc40bdf5 || (x8739b0dd3627f37e is Shape && x11261683cd6f7013(x8739b0dd3627f37e as Shape)))
		{
			xe1410f585439c7d.x19b0790c272bbe88("text:anchor-type", "char");
		}
		else if (x8739b0dd3627f37e.RelativeVerticalPosition == RelativeVerticalPosition.Page && x8739b0dd3627f37e.RelativeHorizontalPosition == RelativeHorizontalPosition.Page)
		{
			xe1410f585439c7d.x19b0790c272bbe88("text:anchor-type", "page");
		}
	}

	internal VisitorAction xd96c4f9a469ee575(ShapeBase x8739b0dd3627f37e)
	{
		if (x9b287b671d592594.x05ee8ce4d7312eb5 == x14bf6f47128e4438.x62896619d90ad964)
		{
			return VisitorAction.Continue;
		}
		if (x57463b022af339cb(x8739b0dd3627f37e))
		{
			return VisitorAction.Continue;
		}
		x9c77c7e782b62883 xe1410f585439c7d = x9b287b671d592594.xe1410f585439c7d4;
		if (!x9b287b671d592594.xb872fbc83a2cb9a6 && x9b287b671d592594.x05ee8ce4d7312eb5 != x14bf6f47128e4438.x3231bc142724c8b3)
		{
			if (xeb03d37c2336a1d6(x8739b0dd3627f37e))
			{
				xe1410f585439c7d.x2dfde153f4ef96d0("draw:text-box");
			}
			if (x0d299f323d241756.x5959bccb67bbf051(x8739b0dd3627f37e.AlternativeText))
			{
				xe1410f585439c7d.x6b73ce92fd8e3f2c("svg:desc", x8739b0dd3627f37e.AlternativeText);
			}
			if (x8739b0dd3627f37e is GroupShape)
			{
				xe1410f585439c7d.xf3cbeec41f083290("draw:g");
			}
			else if (x8739b0dd3627f37e.ShapeType == ShapeType.Line)
			{
				xe1410f585439c7d.xf3cbeec41f083290("draw:line");
			}
			else if (x6dcbdae8b4f7f447(x8739b0dd3627f37e.ShapeType))
			{
				xe1410f585439c7d.xf3cbeec41f083290("draw:connector");
			}
			else if (x04c50ba5db2fd684(x8739b0dd3627f37e))
			{
				xe1410f585439c7d.xf3cbeec41f083290("draw:rect");
			}
			else if (x8739b0dd3627f37e.ShapeType == ShapeType.Ellipse)
			{
				xe1410f585439c7d.xf3cbeec41f083290("draw:ellipse");
			}
			else if (x5abc6039e2a71e21(x8739b0dd3627f37e))
			{
				xe1410f585439c7d.xf3cbeec41f083290("draw:custom-shape");
				x9b287b671d592594.x386588ea37d49369 = false;
			}
			else if (x9a3452914bb9074d(x8739b0dd3627f37e))
			{
				xe1410f585439c7d.xf3cbeec41f083290("draw:frame");
				if (x0d299f323d241756.x5959bccb67bbf051(x8739b0dd3627f37e.HRef) && !(x8739b0dd3627f37e.ParentNode is GroupShape))
				{
					xe1410f585439c7d.xf3cbeec41f083290("draw:a");
				}
			}
			if (xd63ad08213e4f0d0(x8739b0dd3627f37e))
			{
				x12954a224495d3c0.x81ddb41fb70cbf68();
			}
		}
		return VisitorAction.Continue;
	}

	private void x972da593ed2a0323(ShapeBase x8739b0dd3627f37e)
	{
		x9c77c7e782b62883 xe1410f585439c7d = x9b287b671d592594.xe1410f585439c7d4;
		xe1410f585439c7d.x19b0790c272bbe88("draw:style-name", x6962cbeae4129aa3.x455e44058f4e8da3());
		xf5839392122362e4(x8739b0dd3627f37e);
		if (x8739b0dd3627f37e.Rotation != 0.0)
		{
			PointF pointF = x8739b0dd3627f37e.x19cd1409c300dd76(new PointF((float)x8739b0dd3627f37e.Left, (float)x8739b0dd3627f37e.Top));
			xe1410f585439c7d.x19b0790c272bbe88("draw:transform", $"translate({xbb857c9fc36f5054.x34bdf37bc4f6368b(xbb857c9fc36f5054.x6a2cd7b6d4dbe0bb(0f - x8739b0dd3627f37e.SizeInPoints.Width) / 2.0)} {xbb857c9fc36f5054.x34bdf37bc4f6368b(xbb857c9fc36f5054.x6a2cd7b6d4dbe0bb(0f - x8739b0dd3627f37e.SizeInPoints.Height) / 2.0)}) rotate ({xca004f56614e2431.xcadee4aea45827c2(Math.PI * (0.0 - x8739b0dd3627f37e.Rotation) / 180.0)}) translate({xbb857c9fc36f5054.x34bdf37bc4f6368b(xbb857c9fc36f5054.x6a2cd7b6d4dbe0bb(pointF.X) + xbb857c9fc36f5054.x6a2cd7b6d4dbe0bb(x8739b0dd3627f37e.SizeInPoints.Width) / 2.0)} {xbb857c9fc36f5054.x34bdf37bc4f6368b(xbb857c9fc36f5054.x6a2cd7b6d4dbe0bb(pointF.Y) + xbb857c9fc36f5054.x6a2cd7b6d4dbe0bb(x8739b0dd3627f37e.SizeInPoints.Height) / 2.0)})");
		}
		xe1410f585439c7d.x53e7651cce580e9f("draw:z-index", ((x8739b0dd3627f37e.ZOrder >= 0) ? x8739b0dd3627f37e.ZOrder : 0).ToString());
	}

	private void x7e64784cc0e845d6(Shape x5770cdefd8931aa9, string x121383aa64985888)
	{
		PointF pointF = x5770cdefd8931aa9.x19cd1409c300dd76(new PointF((float)x5770cdefd8931aa9.Left, (float)x5770cdefd8931aa9.Top));
		double num = pointF.X;
		double num2 = pointF.X;
		double num3 = pointF.Y;
		double num4 = pointF.Y;
		double num5 = xd9b1cefbf06a8e29(x5770cdefd8931aa9, x5770cdefd8931aa9.SizeInPoints.Width);
		double num6 = xd9b1cefbf06a8e29(x5770cdefd8931aa9, x5770cdefd8931aa9.SizeInPoints.Height);
		switch (x5770cdefd8931aa9.FlipOrientation)
		{
		case FlipOrientation.Horizontal:
			num += num5;
			num4 += num6;
			break;
		case FlipOrientation.Vertical:
			num2 += num5;
			num3 += num6;
			break;
		case FlipOrientation.Both:
			num += num5;
			num3 += num6;
			break;
		default:
			num2 += num5;
			num4 += num6;
			break;
		}
		x9c77c7e782b62883 xe1410f585439c7d = x9b287b671d592594.xe1410f585439c7d4;
		xe1410f585439c7d.x5a3f5d78674f78e4(x121383aa64985888);
		xe1410f585439c7d.x19b0790c272bbe88("draw:type", x0eb9a864413f34de.x50ac76da81079195(x5770cdefd8931aa9.x5b865d49b2c8440d));
		xe1410f585439c7d.x19b0790c272bbe88("svg:x1", xbb857c9fc36f5054.x96d7e563211411f6(num));
		xe1410f585439c7d.x19b0790c272bbe88("svg:y1", xbb857c9fc36f5054.x96d7e563211411f6(num3));
		xe1410f585439c7d.x19b0790c272bbe88("svg:x2", xbb857c9fc36f5054.x96d7e563211411f6(num2));
		xe1410f585439c7d.x19b0790c272bbe88("svg:y2", xbb857c9fc36f5054.x96d7e563211411f6(num4));
		x972da593ed2a0323(x5770cdefd8931aa9);
	}

	private void xc94f3fcfa470eabd(Shape x5770cdefd8931aa9, string x121383aa64985888)
	{
		x9c77c7e782b62883 xe1410f585439c7d = x9b287b671d592594.xe1410f585439c7d4;
		xe1410f585439c7d.x5a3f5d78674f78e4(x121383aa64985888);
		if (x5770cdefd8931aa9.Rotation == 0.0)
		{
			PointF pointF = x5770cdefd8931aa9.x19cd1409c300dd76(new PointF((float)x5770cdefd8931aa9.Left, (float)x5770cdefd8931aa9.Top));
			xe1410f585439c7d.x19b0790c272bbe88("svg:x", xbb857c9fc36f5054.x96d7e563211411f6(pointF.X));
			xe1410f585439c7d.x19b0790c272bbe88("svg:y", xbb857c9fc36f5054.x96d7e563211411f6(pointF.Y));
		}
		else
		{
			xe1410f585439c7d.x19b0790c272bbe88("svg:x", "0cm");
			xe1410f585439c7d.x19b0790c272bbe88("svg:y", "0cm");
		}
		xe1410f585439c7d.x19b0790c272bbe88("svg:width", xbb857c9fc36f5054.x96d7e563211411f6(xd9b1cefbf06a8e29(x5770cdefd8931aa9, x5770cdefd8931aa9.SizeInPoints.Width)));
		xe1410f585439c7d.x19b0790c272bbe88("svg:height", xbb857c9fc36f5054.x96d7e563211411f6(xd9b1cefbf06a8e29(x5770cdefd8931aa9, x5770cdefd8931aa9.SizeInPoints.Height)));
		x972da593ed2a0323(x5770cdefd8931aa9);
	}

	private void xa9a6cebffd173ca3(ShapeBase x8739b0dd3627f37e, string x121383aa64985888)
	{
		x9c77c7e782b62883 xe1410f585439c7d = x9b287b671d592594.xe1410f585439c7d4;
		xe1410f585439c7d.x5a3f5d78674f78e4(x121383aa64985888);
		bool flag = x8739b0dd3627f37e.Rotation != 0.0;
		if (!flag)
		{
			PointF pointF = x8739b0dd3627f37e.x19cd1409c300dd76(new PointF((float)x8739b0dd3627f37e.Left, (float)x8739b0dd3627f37e.Top));
			xe1410f585439c7d.x19b0790c272bbe88("svg:x", xbb857c9fc36f5054.x96d7e563211411f6((double)pointF.X - ((x8739b0dd3627f37e is Shape && ((Shape)x8739b0dd3627f37e).Stroked) ? ((Shape)x8739b0dd3627f37e).StrokeWeight : 0.0)));
			bool flag2 = x8739b0dd3627f37e.xf7125312c7ee115c.xbc5dc59d0d9b620d(914) && (RelativeVerticalPosition)x8739b0dd3627f37e.xf7125312c7ee115c.xf7866f89640a29a3(914) == RelativeVerticalPosition.Line;
			double num = (double)pointF.Y - ((x8739b0dd3627f37e is Shape && ((Shape)x8739b0dd3627f37e).Stroked) ? ((Shape)x8739b0dd3627f37e).StrokeWeight : 0.0);
			if (flag2)
			{
				num = 0.0 - num;
			}
			xe1410f585439c7d.x19b0790c272bbe88("svg:y", xbb857c9fc36f5054.x96d7e563211411f6(num));
		}
		else
		{
			xe1410f585439c7d.x19b0790c272bbe88("svg:x", "0cm");
			xe1410f585439c7d.x19b0790c272bbe88("svg:y", "0cm");
		}
		if (x8739b0dd3627f37e.SizeInPoints.Width != 0f)
		{
			xe1410f585439c7d.x19b0790c272bbe88("svg:width", xbb857c9fc36f5054.x96d7e563211411f6((double)x8739b0dd3627f37e.SizeInPoints.Width + ((x8739b0dd3627f37e is Shape && ((Shape)x8739b0dd3627f37e).Stroked && !flag) ? (((Shape)x8739b0dd3627f37e).StrokeWeight * 2.0) : 0.0)));
		}
		else
		{
			xe1410f585439c7d.x19b0790c272bbe88("svg:width", "0cm");
		}
		if (x8739b0dd3627f37e.SizeInPoints.Height != 0f)
		{
			xe1410f585439c7d.x19b0790c272bbe88("svg:height", xbb857c9fc36f5054.x96d7e563211411f6((double)x8739b0dd3627f37e.SizeInPoints.Height + ((x8739b0dd3627f37e is Shape && ((Shape)x8739b0dd3627f37e).Stroked && !flag) ? (((Shape)x8739b0dd3627f37e).StrokeWeight * 2.0) : 0.0)));
		}
		else
		{
			xe1410f585439c7d.x19b0790c272bbe88("svg:height", "0cm");
		}
		x972da593ed2a0323(x8739b0dd3627f37e);
	}

	private void xa07aa514e9082b3a(ShapeBase x8739b0dd3627f37e)
	{
		x9b287b671d592594.xe1410f585439c7d4.x5a3f5d78674f78e4("draw:g");
		x972da593ed2a0323(x8739b0dd3627f37e);
	}

	private static bool xd5dab45b5fc4d64a(ShapeBase x8739b0dd3627f37e)
	{
		if (x8739b0dd3627f37e.ChildNodes.Count == 1 && x8739b0dd3627f37e.ChildNodes[0] is Paragraph && ((Paragraph)x8739b0dd3627f37e.ChildNodes[0]).ChildNodes.Count == 1 && ((Paragraph)x8739b0dd3627f37e.ChildNodes[0]).ChildNodes[0] is Shape && ((Shape)((Paragraph)x8739b0dd3627f37e.ChildNodes[0]).ChildNodes[0]).IsImage)
		{
			return x8739b0dd3627f37e.ParentNode is GroupShape;
		}
		return false;
	}

	private static bool x9a3452914bb9074d(ShapeBase x8739b0dd3627f37e)
	{
		Paragraph parentParagraph = x8739b0dd3627f37e.ParentParagraph;
		if (parentParagraph != null && parentParagraph.ChildNodes.Count == 1 && parentParagraph.ParentNode is Shape && x11261683cd6f7013((Shape)parentParagraph.ParentNode) && x8739b0dd3627f37e.IsImage)
		{
			if (x8739b0dd3627f37e.IsImage)
			{
				if (parentParagraph.ParentNode.ChildNodes.Count <= 1)
				{
					return !(parentParagraph.ParentNode.ParentNode is GroupShape);
				}
				return true;
			}
			return false;
		}
		return true;
	}

	private static bool xd63ad08213e4f0d0(ShapeBase x8739b0dd3627f37e)
	{
		Paragraph parentParagraph = x8739b0dd3627f37e.ParentParagraph;
		if (x8739b0dd3627f37e.IsInline && x8739b0dd3627f37e.IsTopLevel)
		{
			if (x8739b0dd3627f37e.IsImage || x8739b0dd3627f37e.xa170cce2bc40bdf5 || (x8739b0dd3627f37e is Shape && (x8739b0dd3627f37e as Shape).x169baa05e57bf312))
			{
				if (parentParagraph != null && parentParagraph.ParentNode != null && parentParagraph.ParentNode.ChildNodes.Count > 1)
				{
					return parentParagraph.ParentNode.ParentNode is GroupShape;
				}
				return false;
			}
			return true;
		}
		return false;
	}

	private static bool xeb03d37c2336a1d6(ShapeBase x8739b0dd3627f37e)
	{
		if (x8739b0dd3627f37e is Shape && x11261683cd6f7013((Shape)x8739b0dd3627f37e))
		{
			return !xd5dab45b5fc4d64a(x8739b0dd3627f37e);
		}
		return false;
	}

	private static bool x57c6286d036794cb(ShapeBase x8739b0dd3627f37e)
	{
		if (!(x8739b0dd3627f37e is GroupShape) && x8739b0dd3627f37e.ShapeType != ShapeType.Line && x8739b0dd3627f37e.ShapeType != ShapeType.Ellipse && (x8739b0dd3627f37e.ShapeType != ShapeType.Rectangle || (((Shape)x8739b0dd3627f37e).TextBox != null && x8739b0dd3627f37e.HasChildNodes)))
		{
			return x9a3452914bb9074d(x8739b0dd3627f37e);
		}
		return true;
	}

	private static bool x04c50ba5db2fd684(ShapeBase x8739b0dd3627f37e)
	{
		if (x8739b0dd3627f37e.ShapeType == ShapeType.Rectangle)
		{
			if (((Shape)x8739b0dd3627f37e).TextBox != null)
			{
				return !x8739b0dd3627f37e.HasChildNodes;
			}
			return true;
		}
		return false;
	}

	private static double xd9b1cefbf06a8e29(Shape x5770cdefd8931aa9, double xbcea506a33cf9111)
	{
		if (xbcea506a33cf9111 > ShapeBase.x006c15aca3bb2b06)
		{
			if (x5770cdefd8931aa9.ParentNode == null)
			{
				return xbcea506a33cf9111;
			}
			return ShapeBase.x006c15aca3bb2b06;
		}
		return xbcea506a33cf9111;
	}
}
