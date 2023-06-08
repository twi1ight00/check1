using System.Collections;
using System.Drawing;
using xa7850104c8d8c135;
using xf269d97e8a02e911;

namespace x74500b509de15565;

internal class xccda0a22f396cc5f
{
	private x620a827d91bf9cfe x4c79a02a813629f0;

	private readonly Stack x8085e5606203577e = new Stack();

	private readonly xcf56b3bea2f7249b x27f03a3af2be4e9f;

	private readonly x9bef3b1e893f7f2e xea288d4121bac055;

	private PointF xc83d0e6d4611cafd = PointF.Empty;

	public PointF x180f9c8380162d4e
	{
		get
		{
			return xc83d0e6d4611cafd;
		}
		set
		{
			xc83d0e6d4611cafd = value;
		}
	}

	public x620a827d91bf9cfe x145e3af29556cafe => x4c79a02a813629f0;

	public xcf56b3bea2f7249b x9992adc923692d1d => x27f03a3af2be4e9f;

	public xccda0a22f396cc5f(x3fa09e8d7b952fbc metafileInfo, x9bef3b1e893f7f2e sink, bool isEmf)
	{
		x27f03a3af2be4e9f = new xcf56b3bea2f7249b(isEmf);
		if (isEmf)
		{
			x9992adc923692d1d.x4bff4a77ade69aa8();
		}
		else
		{
			x9992adc923692d1d.x7580f567d0f62e46(metafileInfo.x1140b8d044d38bb6);
		}
		x4c79a02a813629f0 = new x620a827d91bf9cfe(x9992adc923692d1d, metafileInfo, isEmf);
		xea288d4121bac055 = sink;
	}

	public void x99324070390852e2()
	{
		x8085e5606203577e.Push(x4c79a02a813629f0);
		x4c79a02a813629f0 = x4c79a02a813629f0.x8b61531c8ea35b85();
	}

	public void x0619fa143f5de07c()
	{
		x4c79a02a813629f0 = (x620a827d91bf9cfe)x8085e5606203577e.Pop();
	}

	public void x01b2723108ff3dfe(PointF x2f7096dac971d6ec)
	{
		x180f9c8380162d4e = x2f7096dac971d6ec;
		xea288d4121bac055.AddCurrentFigure(closed: false);
	}

	public void xd0baff30d99dc152(PointF x2f7096dac971d6ec)
	{
		xea288d4121bac055.xd0baff30d99dc152(x2f7096dac971d6ec);
		x180f9c8380162d4e = x2f7096dac971d6ec;
	}
}
