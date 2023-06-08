using System;
using System.Drawing;
using Aspose.Words.Math;
using x1c8faa688b1f0b0c;
using x5794c252ba25e723;
using xe5b37aee2c2a4d4e;
using xeb665d1aeef09d64;

namespace x50d2f537cc336076;

internal class x0efacd22ed3580e4 : x57df270da83ea6de
{
	private const char x6577331658ef8c5f = '√';

	private const float x6d45dfbb87a89673 = 0.5f;

	private x57df270da83ea6de x9ad25f7d48b48a7b;

	private x57df270da83ea6de xb058538a38b71129;

	private x57df270da83ea6de x5dc782d8a127c937;

	internal x0efacd22ed3580e4(OfficeMath officeMath)
		: base(officeMath)
	{
		x9ad25f7d48b48a7b = new x57df270da83ea6de(officeMath);
		xb058538a38b71129 = new x57df270da83ea6de(officeMath);
		x5dc782d8a127c937 = new x57df270da83ea6de(officeMath);
		base.x1fa9148f6731ff24(x9ad25f7d48b48a7b);
		base.x1fa9148f6731ff24(x5dc782d8a127c937);
		base.x1fa9148f6731ff24(xb058538a38b71129);
	}

	internal override void x1fa9148f6731ff24(x57df270da83ea6de x4bbc2c453c470189)
	{
		switch (x4bbc2c453c470189.xc48e358ce4f81353.x52642f91ccdeeb35.x3e68720d12325f49)
		{
		case x3e68720d12325f49.x1745ba6c6d5efbc4:
			xb058538a38b71129.x1fa9148f6731ff24(x4bbc2c453c470189);
			break;
		case x3e68720d12325f49.x2b691ff28e877ea4:
			x9ad25f7d48b48a7b.x1fa9148f6731ff24(x4bbc2c453c470189);
			break;
		default:
			throw new ArgumentException("Cannot add child of this type to the Radical element. Only Argument and Degree parts are allowed.");
		}
	}

	internal override void x62084450a0785b90()
	{
		x9ad25f7d48b48a7b.xb7ae55095fddecd9();
		xb058538a38b71129.xb7ae55095fddecd9();
		x5dc782d8a127c937.xb7ae55095fddecd9();
		xa0063806e60a428b();
		if (x9ad25f7d48b48a7b.x6ae4612a8469678e.Width > 0f)
		{
			RectangleF rectangleF = x9ad25f7d48b48a7b.x6ae4612a8469678e;
			float width = rectangleF.Width - (float)base.xeedad81aaed42a76.x437e3b626c0fdd43 / 2f;
			x9ad25f7d48b48a7b.x6ae4612a8469678e = new RectangleF(rectangleF.X, rectangleF.Y, width, rectangleF.Height);
			x9ad25f7d48b48a7b.x43a729b39a97938d = x9ad25f7d48b48a7b.x6ae4612a8469678e.Height;
			x9ad25f7d48b48a7b.x5152a5707921c783(0.5f, 0.5f);
		}
		xb058538a38b71129.x43a729b39a97938d = xb058538a38b71129.x6ae4612a8469678e.Height / 2f;
		base.x62084450a0785b90();
	}

	private void xa0063806e60a428b()
	{
		xe39d06eee35dd23d xe39d06eee35dd23d = x9d888f53892d94df.x9834ddb0e0bd5996.x491f5a7224612753(base.xeedad81aaed42a76.x759aa16c2016a289, base.xeedad81aaed42a76.x437e3b626c0fdd43, FontStyle.Regular);
		SizeF sizeF = xe39d06eee35dd23d.x6e21842ebf5f70df('√'.ToString());
		float num = (float)base.xeedad81aaed42a76.x437e3b626c0fdd43 / 30f;
		float num2 = xb058538a38b71129.x6ae4612a8469678e.Height * 1.1f;
		PointF x10aaa7cdfa38f = new PointF(xb058538a38b71129.x6ae4612a8469678e.Width + sizeF.Width, 0f);
		PointF pointF = new PointF(sizeF.Width, 0f);
		PointF pointF2 = new PointF(sizeF.Width * 0.6f, num2);
		PointF pointF3 = new PointF(sizeF.Width * 0.2f, num2 - xe39d06eee35dd23d.xad4d3652239d8aaa / 2f);
		PointF xca09b6c2b5b = new PointF(0f, num2 - xe39d06eee35dd23d.xad4d3652239d8aaa * 0.8f / 2f);
		xab391c46ff9a0a38 xab391c46ff9a0a = new xab391c46ff9a0a38();
		xab391c46ff9a0a.x9e5d5f9128c69a8f = new x31c19fcb724dfaf5(new xc020fa2f5133cba8(base.xa1088ce63fcbe744), num);
		x1cab6af0a41b70e2 xda5bf54deb817e = x1cab6af0a41b70e2.xb471d14948c54f27(x10aaa7cdfa38f, pointF);
		x1cab6af0a41b70e2 xda5bf54deb817e2 = x1cab6af0a41b70e2.xb471d14948c54f27(pointF, pointF2);
		x1cab6af0a41b70e2 x1cab6af0a41b70e = x1cab6af0a41b70e2.xb471d14948c54f27(pointF2, pointF3);
		x1cab6af0a41b70e2 xda5bf54deb817e3 = x1cab6af0a41b70e2.xb471d14948c54f27(pointF3, xca09b6c2b5b);
		xab391c46ff9a0a.xd6b6ed77479ef68c(xda5bf54deb817e);
		xab391c46ff9a0a.xd6b6ed77479ef68c(xda5bf54deb817e2);
		xab391c46ff9a0a.xd6b6ed77479ef68c(x1cab6af0a41b70e);
		xab391c46ff9a0a.xd6b6ed77479ef68c(xda5bf54deb817e3);
		xab391c46ff9a0a38 xab391c46ff9a0a2 = new xab391c46ff9a0a38();
		xab391c46ff9a0a2.x9e5d5f9128c69a8f = new x31c19fcb724dfaf5(new xc020fa2f5133cba8(base.xa1088ce63fcbe744), num * 2f);
		xab391c46ff9a0a2.xd6b6ed77479ef68c(x1cab6af0a41b70e.x8b61531c8ea35b85());
		x5dc782d8a127c937.xefb7a8f84373ac04.xd6b6ed77479ef68c(xab391c46ff9a0a);
		x5dc782d8a127c937.xefb7a8f84373ac04.xd6b6ed77479ef68c(xab391c46ff9a0a2);
		x5dc782d8a127c937.x6ae4612a8469678e = new RectangleF(x5dc782d8a127c937.x6ae4612a8469678e.X, x5dc782d8a127c937.x6ae4612a8469678e.Y, sizeF.Width, num2);
	}
}
