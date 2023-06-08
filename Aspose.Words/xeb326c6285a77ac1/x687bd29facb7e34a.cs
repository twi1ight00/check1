using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using x1c8faa688b1f0b0c;
using x24ed092a62874e86;
using x5794c252ba25e723;
using x8b1f7613579e78d0;
using xa769c310fbec8a5a;
using xeadd538cc90d42ab;

namespace xeb326c6285a77ac1;

internal class x687bd29facb7e34a : x9118c2b63bc20309
{
	private x8b545195dd56c1c7 x964d61c24f7bb519;

	private PointF x8fed193eb72fd802 = PointF.Empty;

	private x48d7478d49393961 xc67007a9d484cbb0;

	private x97e2c177c8bba32e xf4e0cd2951f9bdfa;

	private x36c3925dc7ec8012 xf946812819fdb8f4;

	private double x1cd4a554f4a3b5c0;

	private double xa31a7328614367cd;

	private bool x5f4e27d68ca33052;

	private double x0953b3fa82e477e6;

	private double xbc2b7597d1642ad4;

	private double x7cdd8acdd864b784;

	private double xf3d5bf848ed5857f;

	public double xa932600d61ea7dd8 => xbc2b7597d1642ad4;

	public double x204414017cf54f95 => x0953b3fa82e477e6;

	public double x75a8ab952bace694 => xa31a7328614367cd;

	public double x2356df27f1f9cd99 => x1cd4a554f4a3b5c0;

	public PointF x06d6c4b9ca4d75f0
	{
		get
		{
			return x8fed193eb72fd802;
		}
		set
		{
			x8fed193eb72fd802 = value;
		}
	}

	public x97e2c177c8bba32e x2d4e614b9aa850f8 => xf4e0cd2951f9bdfa;

	public x8b545195dd56c1c7 x2c8538c67f1d80e5 => x964d61c24f7bb519;

	public bool x17b2b93b89a6dd3c
	{
		get
		{
			return x5f4e27d68ca33052;
		}
		set
		{
			x5f4e27d68ca33052 = value;
		}
	}

	public x687bd29facb7e34a(double shapeWidth, double shapeHeight, x36c3925dc7ec8012 outline, x48d7478d49393961 fill, x8b545195dd56c1c7 brushRenderingContext, x97e2c177c8bba32e guideValueProvider)
	{
		xbc2b7597d1642ad4 = shapeWidth;
		x0953b3fa82e477e6 = shapeHeight;
		xf946812819fdb8f4 = outline;
		xc67007a9d484cbb0 = fill;
		x964d61c24f7bb519 = brushRenderingContext;
		xf4e0cd2951f9bdfa = guideValueProvider;
	}

	public void x146e38eb2843246e(double x078bfb7b19668a22, double x3dca28569283fa55)
	{
		xa31a7328614367cd = ((x078bfb7b19668a22 == -1.0) ? xbc2b7597d1642ad4 : x078bfb7b19668a22);
		x1cd4a554f4a3b5c0 = ((x3dca28569283fa55 == -1.0) ? x0953b3fa82e477e6 : x3dca28569283fa55);
		if (x75a8ab952bace694 > 0.0)
		{
			x7cdd8acdd864b784 = xa932600d61ea7dd8 / x75a8ab952bace694;
		}
		else
		{
			x7cdd8acdd864b784 = 0.0;
		}
		if (x2356df27f1f9cd99 > 0.0)
		{
			xf3d5bf848ed5857f = x204414017cf54f95 / x2356df27f1f9cd99;
		}
		else
		{
			xf3d5bf848ed5857f = 0.0;
		}
		x06d6c4b9ca4d75f0 = PointF.Empty;
	}

	public PointF x704d4080dede6a41(x1ca435fe7d1dbc75 x2f7096dac971d6ec)
	{
		return new PointF((float)x704d4080dede6a41(x2f7096dac971d6ec.x8df91a2f90079e88, x8a45f1122e39b31b: true), (float)x704d4080dede6a41(x2f7096dac971d6ec.xc821290d7ecc08bf, x8a45f1122e39b31b: false));
	}

	public double x704d4080dede6a41(xb8ea2c3b3cf649a4 xe955eedb8e354613, bool x8a45f1122e39b31b)
	{
		return Math.Round(xe955eedb8e354613.x3f88a25febd23896(x2d4e614b9aa850f8) * (x8a45f1122e39b31b ? x7cdd8acdd864b784 : xf3d5bf848ed5857f));
	}

	public x31c19fcb724dfaf5 x2f0c16e51db81725()
	{
		x31c19fcb724dfaf5 x31c19fcb724dfaf = xf946812819fdb8f4.x2f0c16e51db81725(x2c8538c67f1d80e5);
		if (x17b2b93b89a6dd3c && x31c19fcb724dfaf != null)
		{
			x31c19fcb724dfaf.x9ba359ff37a3a63b = PenAlignment.Outset;
		}
		return x31c19fcb724dfaf;
	}

	public x845d6a068e0b03c5 xa3fa1ce4ffca3dc3(xda4dde4038ab80db xcbf24c118ac8aa0b, xab391c46ff9a0a38 xe125219852864557)
	{
		xda4dde4038ab80db x4b34cc8966adf8f = x2c8538c67f1d80e5.x4b34cc8966adf8f7;
		xab391c46ff9a0a38 x6cd7659ca = x2c8538c67f1d80e5.x6cd7659ca2021746;
		try
		{
			x2c8538c67f1d80e5.x4b34cc8966adf8f7 = xcbf24c118ac8aa0b;
			x2c8538c67f1d80e5.x6cd7659ca2021746 = xe125219852864557;
			return xc67007a9d484cbb0.CreateBrush(x2c8538c67f1d80e5);
		}
		finally
		{
			x2c8538c67f1d80e5.x4b34cc8966adf8f7 = x4b34cc8966adf8f;
			x2c8538c67f1d80e5.x6cd7659ca2021746 = x6cd7659ca;
		}
	}
}
