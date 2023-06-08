using System.Drawing;
using Aspose.Words;
using x1c8faa688b1f0b0c;

namespace x3d94286fe72124a8;

internal class x0f224afd6fa95c60
{
	internal static void xfea4fd3f1633453a(xa37343ccb8cd8c70 x0f7b23d1c393aed9, PointF x10aaa7cdfa38f254, PointF xca09b6c2b5b18485)
	{
		xab391c46ff9a0a38 xab391c46ff9a0a = new xab391c46ff9a0a38(x0f7b23d1c393aed9.xa0640346645809ad);
		xab391c46ff9a0a.x60465f602599d327 = x0f7b23d1c393aed9.x8dc20c37aa4b28ef;
		x1cab6af0a41b70e2 x1cab6af0a41b70e = new x1cab6af0a41b70e2();
		xab391c46ff9a0a.xd6b6ed77479ef68c(x1cab6af0a41b70e);
		x1cab6af0a41b70e.x49babf6761229eb5(x10aaa7cdfa38f254, xca09b6c2b5b18485);
		x0f7b23d1c393aed9.xa1eafe7821eb4aab.xd6b6ed77479ef68c(xab391c46ff9a0a);
	}

	internal static float xa5e94e2f197837cf(Border x14cf9593b86ecbaa)
	{
		switch (x14cf9593b86ecbaa.LineStyle)
		{
		case LineStyle.Single:
		case LineStyle.Dot:
		case LineStyle.DashLargeGap:
		case LineStyle.DotDash:
		case LineStyle.DotDotDash:
		case LineStyle.Wave:
		case LineStyle.DoubleWave:
		case LineStyle.DashSmallGap:
		case LineStyle.DashDotStroker:
			return x14cf9593b86ecbaa.xeae235558dc44397;
		case LineStyle.Double:
		case LineStyle.Triple:
		case LineStyle.ThinThickSmallGap:
		case LineStyle.ThickThinSmallGap:
		case LineStyle.ThinThickThinSmallGap:
		case LineStyle.ThinThickMediumGap:
		case LineStyle.ThickThinMediumGap:
		case LineStyle.ThinThickThinMediumGap:
		case LineStyle.ThinThickLargeGap:
		case LineStyle.ThickThinLargeGap:
		case LineStyle.ThinThickThinLargeGap:
		case LineStyle.Emboss3D:
		case LineStyle.Engrave3D:
			return (float)x14cf9593b86ecbaa.LineWidth;
		case LineStyle.Thick:
		case LineStyle.Hairline:
			return 1f;
		case LineStyle.Outset:
		case LineStyle.Inset:
			return 1f;
		default:
			return x14cf9593b86ecbaa.xeae235558dc44397;
		}
	}
}
