using System.IO;
using x1c8faa688b1f0b0c;
using x6c95d9cf46ff5f25;
using xa7850104c8d8c135;

namespace x4f4df92b75ba3b67;

internal class x92faf2a956f0f5a7 : xf51865b83a7a0b3b, x2da3d38c09108f49
{
	private readonly x0d8cdce10fda1cfd xd52a5856a86c36e0;

	private readonly x48cb59b8ec3b78c9 xc1a30145b295d273;

	public x0d8cdce10fda1cfd x0d8cdce10fda1cfd => xd52a5856a86c36e0;

	public x92faf2a956f0f5a7(Stream stream)
		: this(stream, new xd0e7b6ac3d6a3950())
	{
	}

	public x92faf2a956f0f5a7(Stream stream, xd0e7b6ac3d6a3950 options)
		: this(new x0d8cdce10fda1cfd(stream, options))
	{
	}

	public x92faf2a956f0f5a7(x0d8cdce10fda1cfd pdfDoc)
	{
		xd52a5856a86c36e0 = pdfDoc;
		xc1a30145b295d273 = new x48cb59b8ec3b78c9(pdfDoc.x28fcdc775a1d069c.x73979cef1002ed01.xafc42de38a25321a);
	}

	public void xe406325e56f74b46(x4fdf549af9de6b97 xda5bf54deb817e37)
	{
		xda5bf54deb817e37.Accept(this);
	}

	public void xa0dfc102c691b11f()
	{
		xd52a5856a86c36e0.xa0dfc102c691b11f();
	}

	public override void VisitPageStart(xc67adcdbca121a26 page)
	{
		xd52a5856a86c36e0.x804b2039ae4e9b33(page.x437e3b626c0fdd43);
	}

	public override void VisitPageEnd(xc67adcdbca121a26 page)
	{
		xd52a5856a86c36e0.xa0cf4a18229be519();
	}

	public override void VisitCanvasStart(xb8e7e788f6d59708 canvas)
	{
		xd52a5856a86c36e0.xa65184d44a47025b.x93764b3608d338a4(canvas);
	}

	public override void VisitCanvasEnd(xb8e7e788f6d59708 canvas)
	{
		xd52a5856a86c36e0.xa65184d44a47025b.xd23c6c9fd3a6fa74(canvas);
	}

	public override void VisitGlyphs(xcc8c7739d82c63ba glyphs)
	{
		xd52a5856a86c36e0.xa65184d44a47025b.xc7234004e9b72a7e(glyphs);
	}

	public override void VisitPathStart(xab391c46ff9a0a38 path)
	{
		xd52a5856a86c36e0.xa65184d44a47025b.x4f6d0716f281880f(path);
	}

	public override void VisitPathEnd(xab391c46ff9a0a38 path)
	{
		xd52a5856a86c36e0.xa65184d44a47025b.x8e20e5f3afd31049(path);
	}

	public override void VisitPathFigureStart(x1cab6af0a41b70e2 pathFigure)
	{
		xd52a5856a86c36e0.xa65184d44a47025b.xe7593051eba00f64(pathFigure);
	}

	public override void VisitPathFigureEnd(x1cab6af0a41b70e2 pathFigure)
	{
		xd52a5856a86c36e0.xa65184d44a47025b.x6cd18ff4b66042fc(pathFigure);
	}

	public override void VisitPolyLineSegment(x60c040f35bb272aa segment)
	{
		xd52a5856a86c36e0.xa65184d44a47025b.xa991bd0d9c80557e(segment);
	}

	public override void VisitBezierSegment(x519b1bd0625473ff segment)
	{
		xd52a5856a86c36e0.xa65184d44a47025b.x23e7297287797971(segment);
	}

	public override void VisitImage(x72c34b8dbaec3734 image)
	{
		image = image.x9214b18190604b0d(this, xc1a30145b295d273, x0d8cdce10fda1cfd.x28fcdc775a1d069c.x73979cef1002ed01.x5ba9693d4c3c102e);
		if (image != null)
		{
			xd52a5856a86c36e0.xa65184d44a47025b.x558cc83610335d8b(image);
		}
	}

	public override void VisitBookmark(x9a66d03de2ff27e1 bookmark)
	{
		xd52a5856a86c36e0.xa65184d44a47025b.x94f739530d38cc0a(bookmark);
	}

	public override void VisitOutlineItem(x2e5b68a308682b82 outlineItem)
	{
		xd52a5856a86c36e0.xa65184d44a47025b.xdac50776b1d359d8(outlineItem);
	}

	public override void VisitFormFieldText(x8fd773b74dcec1bc field)
	{
		xd52a5856a86c36e0.x3a60bb04bce53320.xd6b6ed77479ef68c(field, xd52a5856a86c36e0.xa65184d44a47025b);
	}

	public override void VisitFormComboBox(x3a68442d168cdd44 field)
	{
		xd52a5856a86c36e0.x3a60bb04bce53320.xd6b6ed77479ef68c(field, xd52a5856a86c36e0.xa65184d44a47025b);
	}

	public override void VisitFormFieldCheckbox(xf8b7d3491a4bc1b0 field)
	{
		xd52a5856a86c36e0.x3a60bb04bce53320.xd6b6ed77479ef68c(field, xd52a5856a86c36e0.xa65184d44a47025b);
	}

	public x54b98d0096d7251a x4d2cf6c77ee521cd()
	{
		if (x0d8cdce10fda1cfd.x28fcdc775a1d069c.x73979cef1002ed01 == null)
		{
			return x8694a2e0856b3478.x9834ddb0e0bd5996;
		}
		return x0d8cdce10fda1cfd.x28fcdc775a1d069c.x73979cef1002ed01.x4d2cf6c77ee521cd();
	}
}
