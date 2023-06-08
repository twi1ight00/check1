using System.Drawing;
using System.Drawing.Drawing2D;
using ns224;

namespace ns234;

internal static class Class6162
{
	public static Pen smethod_0(Class6003 drPen)
	{
		Pen pen = new Pen(Class6151.smethod_0(drPen.Brush));
		pen.Width = drPen.Width;
		pen.StartCap = drPen.StartCap;
		pen.EndCap = drPen.EndCap;
		pen.LineJoin = drPen.LineJoin;
		pen.MiterLimit = drPen.MiterLimit;
		pen.DashOffset = drPen.DashOffset;
		pen.DashCap = drPen.DashCap;
		pen.Alignment = (PenAlignment)drPen.Alignment;
		pen.DashStyle = drPen.DashStyle;
		if (drPen.DashStyle == DashStyle.Custom)
		{
			pen.DashPattern = drPen.DashPattern;
		}
		if (drPen.CompoundArray.Length > 0 && pen.Alignment != PenAlignment.Inset)
		{
			pen.CompoundArray = drPen.CompoundArray;
		}
		return pen;
	}
}
