using System.Drawing;
using x1c8faa688b1f0b0c;
using x3d94286fe72124a8;
using x5794c252ba25e723;

namespace x7a30b7d81100c71a;

internal class x936595b14a7c5251 : xf51865b83a7a0b3b
{
	private x6fb6d1ef6127cf4e x62a6eaf179c89359;

	private xc7dff27f851c3f9b x6bc111765fea44a0;

	private xb8e7e788f6d59708 x410125e10be9ed99;

	private bool xa4ad571ac1761ba0;

	private readonly x31c19fcb724dfaf5 x2ec6eb08503d5e2c = new x31c19fcb724dfaf5(x26d9ecb4bdf0456d.x89fffa2751fdecbe, 0.15f);

	internal x936595b14a7c5251(xa37343ccb8cd8c70 context)
	{
		x62a6eaf179c89359 = new x6fb6d1ef6127cf4e(context);
	}

	internal xb8e7e788f6d59708 xeb004ce5b82b6491(xb8e7e788f6d59708 x08ce8f4769eb3234, bool x22db55b9a821a9ad)
	{
		xa4ad571ac1761ba0 = x22db55b9a821a9ad;
		x08ce8f4769eb3234.Accept(this);
		return x410125e10be9ed99;
	}

	public override void VisitCanvasStart(xb8e7e788f6d59708 canvas)
	{
		x410125e10be9ed99 = new xb8e7e788f6d59708();
		base.VisitCanvasStart(canvas);
	}

	public override void VisitPathStart(xab391c46ff9a0a38 path)
	{
		x6bc111765fea44a0 = new xc7dff27f851c3f9b();
		base.VisitPathStart(path);
	}

	public override void VisitPathEnd(xab391c46ff9a0a38 path)
	{
		xa638b217f99947ae();
		if (xa4ad571ac1761ba0)
		{
			x410125e10be9ed99.xd6b6ed77479ef68c(x3ac09a69ea0e857b());
		}
		else
		{
			x410125e10be9ed99.xd6b6ed77479ef68c(x48613e6d48ad951a());
		}
		base.VisitPathEnd(path);
	}

	private void xa638b217f99947ae()
	{
		x630b5fb239bb4657 x630b5fb239bb = new x630b5fb239bb4657();
		x630b5fb239bb.xc69dbc1adc53a5a8(0f - x62a6eaf179c89359.xc22eade24b085d91.X, 0f - x62a6eaf179c89359.xc22eade24b085d91.Y, 0f);
		x630b5fb239bb.x829c563f8b08f11b(x62a6eaf179c89359.xd090bae26b3195f2, x62a6eaf179c89359.x7f3207627e4dc2d3);
		x630b5fb239bb.xc69dbc1adc53a5a8(x62a6eaf179c89359.xc22eade24b085d91.X, x62a6eaf179c89359.xc22eade24b085d91.Y, 0f);
		x6bc111765fea44a0.x52dde376accdec7d = x630b5fb239bb;
	}

	public override void VisitPathFigureStart(x1cab6af0a41b70e2 pathFigure)
	{
		x6bc111765fea44a0.xd6b6ed77479ef68c(new xd2cff41fae766733());
		base.VisitPathFigureStart(pathFigure);
	}

	public override void VisitPathFigureEnd(x1cab6af0a41b70e2 pathFigure)
	{
		xd2cff41fae766733 xd2cff41fae = (xd2cff41fae766733)((xde467af50fb2242d)x6bc111765fea44a0).get_xe6d4b1b411ed94b5(x6bc111765fea44a0.xd44988f225497f3a - 1);
		xd2cff41fae766733 xd2cff41fae2 = (xd2cff41fae766733)xd2cff41fae.DeepCopy();
		x630b5fb239bb4657 x630b5fb239bb = new x630b5fb239bb4657();
		x630b5fb239bb.xc69dbc1adc53a5a8(0f, 0f, x62a6eaf179c89359.x7e86c3fa2794109e + x62a6eaf179c89359.x6959de09369b36e8);
		xd2cff41fae2.x52dde376accdec7d = x630b5fb239bb;
		x6bc111765fea44a0.xd6b6ed77479ef68c(xd2cff41fae2);
		for (int i = 0; i < xd2cff41fae.xd44988f225497f3a; i++)
		{
			xd2cff41fae766733 xd2cff41fae3 = new xd2cff41fae766733();
			xa010107c2168153f xa010107c2168153f = (xa010107c2168153f)((xde467af50fb2242d)xd2cff41fae).get_xe6d4b1b411ed94b5(i).DeepCopy();
			xa010107c2168153f xa010107c2168153f2 = (xa010107c2168153f)xa010107c2168153f.DeepCopy();
			xa010107c2168153f2.xe7189024fdf97d87 = x62a6eaf179c89359.x6959de09369b36e8;
			xd2cff41fae3.xd6b6ed77479ef68c(xa010107c2168153f);
			xd2cff41fae3.xd6b6ed77479ef68c(xa010107c2168153f2);
			x6bc111765fea44a0.xd6b6ed77479ef68c(xd2cff41fae3);
		}
		base.VisitPathFigureEnd(pathFigure);
	}

	public override void VisitPolyLineSegment(x60c040f35bb272aa segment)
	{
		for (int i = 0; i < segment.x4d7474e8f1849803.Count; i++)
		{
			PointF pointF = (PointF)segment.x4d7474e8f1849803[i];
			xa010107c2168153f x4bbc2c453c = new xa010107c2168153f(pointF.X, pointF.Y, 0f - x62a6eaf179c89359.x7e86c3fa2794109e);
			((xd2cff41fae766733)((xde467af50fb2242d)x6bc111765fea44a0).get_xe6d4b1b411ed94b5(x6bc111765fea44a0.xd44988f225497f3a - 1)).xd6b6ed77479ef68c(x4bbc2c453c);
		}
		base.VisitPolyLineSegment(segment);
	}

	public override void VisitBezierSegment(x519b1bd0625473ff segment)
	{
		float num = 0.25f / (float)((int)((x558a6a0d6c7e9c59.xc4e956a5affaf561(segment.x56b911bdb6515aed) - 5.0) / 10.0) + 1);
		if (num < 0.05f)
		{
			num = 0.05f;
		}
		float num2 = 0.25f;
		for (float num3 = 0f; num3 <= 1f; num3 += num)
		{
			double num4 = x558a6a0d6c7e9c59.xbd53fd6731398f37(segment.x56b911bdb6515aed, num3);
			num2 += num;
			if (num4 > 0.005 || num2 >= 0.25f || num3 == 1f)
			{
				PointF pointF = x558a6a0d6c7e9c59.x1966e8937604bce4(segment.x56b911bdb6515aed, num3);
				xa010107c2168153f x4bbc2c453c = new xa010107c2168153f(pointF.X, pointF.Y, 0f - x62a6eaf179c89359.x7e86c3fa2794109e);
				((xd2cff41fae766733)((xde467af50fb2242d)x6bc111765fea44a0).get_xe6d4b1b411ed94b5(x6bc111765fea44a0.xd44988f225497f3a - 1)).xd6b6ed77479ef68c(x4bbc2c453c);
				num2 = 0f;
			}
		}
		base.VisitBezierSegment(segment);
	}

	private xab391c46ff9a0a38 x3ac09a69ea0e857b()
	{
		x630b5fb239bb4657 x2c28a8fdcf5cf = x630b5fb239bb4657.xd0795197ba2ca48c(x62a6eaf179c89359.xca52773d6ece7450);
		return x715f1810cad5f47f(x2c28a8fdcf5cf);
	}

	private xab391c46ff9a0a38 x48613e6d48ad951a()
	{
		x630b5fb239bb4657 x2c28a8fdcf5cf = x630b5fb239bb4657.x33ef65dee21ac642(new xa010107c2168153f(x62a6eaf179c89359.x165d00c485a7b2c9, x62a6eaf179c89359.x1bfd866a2c8f48ad, x62a6eaf179c89359.xce70ad8fb60f0bb3), x62a6eaf179c89359.x7082012b76e7b7f3);
		return x715f1810cad5f47f(x2c28a8fdcf5cf);
	}

	private xab391c46ff9a0a38 x715f1810cad5f47f(x630b5fb239bb4657 x2c28a8fdcf5cf148)
	{
		x05ce44fc24c6c129 x05ce44fc24c6c = new x05ce44fc24c6c129(x2c28a8fdcf5cf148);
		x6bc111765fea44a0.Accept(x05ce44fc24c6c);
		x05ce44fc24c6c.x0fafce58eb0494ae.x9e5d5f9128c69a8f = x2ec6eb08503d5e2c;
		return x05ce44fc24c6c.x0fafce58eb0494ae;
	}
}
