using System.Drawing;
using System.Drawing.Drawing2D;
using Aspose;
using x5794c252ba25e723;

namespace xf9a9481c3f63a419;

[JavaManual("Manual porting by design.")]
internal class xf7979838286d056a
{
	private xf7979838286d056a()
	{
	}

	internal static Pen x81a1520efea3239d(x31c19fcb724dfaf5 x94f6590bafb8c2ff)
	{
		using Brush brush = x6fb77f4cc018ceba.x495baeffa83ca947(x94f6590bafb8c2ff.x60465f602599d327);
		Pen pen = new Pen(brush);
		pen.Width = x94f6590bafb8c2ff.xdc1bf80853046136;
		pen.StartCap = x94f6590bafb8c2ff.x1e0dcb2cdd562cb2;
		pen.EndCap = x94f6590bafb8c2ff.xec7c14446b693774;
		pen.LineJoin = x94f6590bafb8c2ff.x03a8df074279275f;
		pen.MiterLimit = x94f6590bafb8c2ff.x3372c2e5fab45e9a;
		pen.DashOffset = x94f6590bafb8c2ff.xc19b368b60309472;
		pen.DashCap = x94f6590bafb8c2ff.x9526ba50e2183e01;
		pen.Alignment = x94f6590bafb8c2ff.x9ba359ff37a3a63b;
		pen.DashStyle = x94f6590bafb8c2ff.xca08e8eb525b8a1a;
		if (x94f6590bafb8c2ff.xca08e8eb525b8a1a == DashStyle.Custom)
		{
			pen.DashPattern = x94f6590bafb8c2ff.x358988d12e56bf69;
		}
		if (x94f6590bafb8c2ff.x6fd1e71abf8b8121.Length > 0 && pen.Alignment != PenAlignment.Inset)
		{
			pen.CompoundArray = x94f6590bafb8c2ff.x6fd1e71abf8b8121;
		}
		return pen;
	}
}
