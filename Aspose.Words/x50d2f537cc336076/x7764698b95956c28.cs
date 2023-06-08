using System;
using System.Drawing;
using Aspose.Words.Math;
using x1c8faa688b1f0b0c;
using x5794c252ba25e723;
using xe5b37aee2c2a4d4e;

namespace x50d2f537cc336076;

internal class x7764698b95956c28 : x57df270da83ea6de
{
	private const float x73539c44b735b7aa = -2.6666667f;

	private x57df270da83ea6de x4010b8db9bd3d609;

	private x57df270da83ea6de xe74bb0675d504e53;

	private x77c73b53c376655e xacb754cba528838f => (x77c73b53c376655e)base.xc48e358ce4f81353.x52642f91ccdeeb35;

	private float x8adc33d784f634c6 => (float)base.xeedad81aaed42a76.x437e3b626c0fdd43 / 20f;

	internal x7764698b95956c28(OfficeMath officeMath)
		: base(officeMath)
	{
		x4010b8db9bd3d609 = new x57df270da83ea6de(officeMath);
		xe74bb0675d504e53 = new x57df270da83ea6de(officeMath);
	}

	internal override void x1fa9148f6731ff24(x57df270da83ea6de x4bbc2c453c470189)
	{
		switch (x4bbc2c453c470189.xc48e358ce4f81353.x52642f91ccdeeb35.x3e68720d12325f49)
		{
		case x3e68720d12325f49.x5ec114ef0df8072b:
			x4010b8db9bd3d609.x1fa9148f6731ff24(x4bbc2c453c470189);
			break;
		case x3e68720d12325f49.x194cb0ccf5358fec:
			xe74bb0675d504e53.x1fa9148f6731ff24(x4bbc2c453c470189);
			break;
		default:
			throw new ArgumentException("Fraction element can have only numerator and denominator parts.");
		}
	}

	internal override void xb7ae55095fddecd9()
	{
		switch (xacb754cba528838f.x4001c46e1a6e7522)
		{
		case x890a027c82a36a95.x7ccdf8314e1f1193:
			xfedfe98132ad63e8();
			break;
		case x890a027c82a36a95.x38d4db9419f3b510:
			xfd0a900b74d20538();
			break;
		case x890a027c82a36a95.xa1886b914486c170:
			xb3feb512fa95cddb(xe5b916abc4b3783d: false);
			break;
		default:
			xb3feb512fa95cddb(xe5b916abc4b3783d: true);
			break;
		}
	}

	private void xb3feb512fa95cddb(bool xe5b916abc4b3783d)
	{
		x3a383e6be139fbaa x3a383e6be139fbaa2 = new x3a383e6be139fbaa(base.xc48e358ce4f81353);
		base.x1fa9148f6731ff24(x3a383e6be139fbaa2);
		x3a383e6be139fbaa2.x1fa9148f6731ff24(x4010b8db9bd3d609);
		x3a383e6be139fbaa2.x1fa9148f6731ff24(xe74bb0675d504e53);
		base.xb7ae55095fddecd9();
		base.x43a729b39a97938d = x4010b8db9bd3d609.x6ae4612a8469678e.Height;
		if (xe5b916abc4b3783d)
		{
			xe19c733fa39dfd29(0f, base.x43a729b39a97938d + x8adc33d784f634c6, x6ae4612a8469678e.Width, base.x43a729b39a97938d + x8adc33d784f634c6);
		}
	}

	private void xfedfe98132ad63e8()
	{
		float num = (float)base.xeedad81aaed42a76.x437e3b626c0fdd43 / 2f;
		xe22a4a9a14e524d7 xe22a4a9a14e524d8 = new xe22a4a9a14e524d7(base.xc48e358ce4f81353, 2);
		xe22a4a9a14e524d8.x79e0368f9606a712 = num;
		base.x1fa9148f6731ff24(xe22a4a9a14e524d8);
		x1dfdb69b4a79e67d x1dfdb69b4a79e67d2 = new x1dfdb69b4a79e67d(xe22a4a9a14e524d8, base.xc48e358ce4f81353);
		xe22a4a9a14e524d8.x1fa9148f6731ff24(x1dfdb69b4a79e67d2);
		x1dfdb69b4a79e67d x1dfdb69b4a79e67d3 = new x1dfdb69b4a79e67d(xe22a4a9a14e524d8, base.xc48e358ce4f81353);
		xe22a4a9a14e524d8.x1fa9148f6731ff24(x1dfdb69b4a79e67d3);
		x1dfdb69b4a79e67d2.x1fa9148f6731ff24(x4010b8db9bd3d609);
		x1dfdb69b4a79e67d2.x1fa9148f6731ff24(new x57df270da83ea6de(base.xc48e358ce4f81353));
		x1dfdb69b4a79e67d3.x1fa9148f6731ff24(new x57df270da83ea6de(base.xc48e358ce4f81353));
		x1dfdb69b4a79e67d3.x1fa9148f6731ff24(xe74bb0675d504e53);
		base.xb7ae55095fddecd9();
		base.x43a729b39a97938d = x4010b8db9bd3d609.x6ae4612a8469678e.Height;
		float num2 = base.x43a729b39a97938d - (x4010b8db9bd3d609.x6ae4612a8469678e.Width + num / 2f) * -2.6666667f;
		float num3 = x4010b8db9bd3d609.x6ae4612a8469678e.Height + xe74bb0675d504e53.x6ae4612a8469678e.Height * 2f / 3f;
		float num4 = x4010b8db9bd3d609.x6ae4612a8469678e.Height * 1f / 3f;
		float x12c1d6cbe26bf48f = (num3 - num2) / -2.6666667f;
		float x6650a9a61c6142e = (num4 - num2) / -2.6666667f;
		xe19c733fa39dfd29(x12c1d6cbe26bf48f, num3, x6650a9a61c6142e, num4);
	}

	private void xfd0a900b74d20538()
	{
		x4010b8db9bd3d609.xb7ae55095fddecd9();
		xe74bb0675d504e53.xb7ae55095fddecd9();
		float num = x4010b8db9bd3d609.x43a729b39a97938d;
		float num2 = xe74bb0675d504e53.x6ae4612a8469678e.Height - xe74bb0675d504e53.x43a729b39a97938d;
		if (num > num2)
		{
			xe74bb0675d504e53.x6ae4612a8469678e = new RectangleF(0f, 0f, xe74bb0675d504e53.x6ae4612a8469678e.Width, xe74bb0675d504e53.x6ae4612a8469678e.Height + (num - num2));
		}
		else if (num < num2)
		{
			x4010b8db9bd3d609.x6ae4612a8469678e = new RectangleF(0f, 0f, x4010b8db9bd3d609.x6ae4612a8469678e.Width, x4010b8db9bd3d609.x6ae4612a8469678e.Height + (num2 - num));
			x4010b8db9bd3d609.x43a729b39a97938d += num2 - num;
		}
		float num3 = (x4010b8db9bd3d609.x43a729b39a97938d + (xe74bb0675d504e53.x6ae4612a8469678e.Height - xe74bb0675d504e53.x43a729b39a97938d)) * 5f / 6f;
		float num4 = (x4010b8db9bd3d609.x43a729b39a97938d + (xe74bb0675d504e53.x6ae4612a8469678e.Height - xe74bb0675d504e53.x43a729b39a97938d)) * 1f / 6f;
		float width = x4010b8db9bd3d609.x6ae4612a8469678e.Width;
		float num5 = num3 - x4010b8db9bd3d609.x6ae4612a8469678e.Width * -2.6666667f;
		float num6 = (num4 - num5) / -2.6666667f;
		xe22a4a9a14e524d7 xe22a4a9a14e524d8 = new xe22a4a9a14e524d7(base.xc48e358ce4f81353, 2);
		xe22a4a9a14e524d8.x79e0368f9606a712 = num6 - width;
		base.x1fa9148f6731ff24(xe22a4a9a14e524d8);
		x1dfdb69b4a79e67d x1dfdb69b4a79e67d2 = new x1dfdb69b4a79e67d(xe22a4a9a14e524d8, base.xc48e358ce4f81353);
		xe22a4a9a14e524d8.x1fa9148f6731ff24(x1dfdb69b4a79e67d2);
		x1dfdb69b4a79e67d2.x1fa9148f6731ff24(x4010b8db9bd3d609);
		x1dfdb69b4a79e67d2.x1fa9148f6731ff24(xe74bb0675d504e53);
		base.xb7ae55095fddecd9();
		base.x43a729b39a97938d = x4010b8db9bd3d609.x43a729b39a97938d;
		xe19c733fa39dfd29(width, num3, num6, num4);
	}

	private void xe19c733fa39dfd29(float x12c1d6cbe26bf48f, float xb2ba7d585620af25, float x6650a9a61c6142e3, float xaa76c33ed453ba57)
	{
		xab391c46ff9a0a38 xab391c46ff9a0a = new xab391c46ff9a0a38();
		xab391c46ff9a0a.x9e5d5f9128c69a8f = new x31c19fcb724dfaf5(new xc020fa2f5133cba8(base.xa1088ce63fcbe744), x8adc33d784f634c6);
		x1cab6af0a41b70e2 xda5bf54deb817e = x1cab6af0a41b70e2.xb471d14948c54f27(new PointF(x12c1d6cbe26bf48f, xb2ba7d585620af25), new PointF(x6650a9a61c6142e3, xaa76c33ed453ba57));
		xab391c46ff9a0a.xd6b6ed77479ef68c(xda5bf54deb817e);
		base.xefb7a8f84373ac04.xd6b6ed77479ef68c(xab391c46ff9a0a);
	}
}
