using System.Runtime.InteropServices;

namespace Aspose.Slides;

[Guid("9e47eddb-fd3d-4ea1-b08f-8f2973b64b38")]
[ComVisible(true)]
public interface ILineFormat
{
	bool IsFormatNotDefined { get; }

	ILineFillFormat FillFormat { get; }

	double Width { get; set; }

	LineDashStyle DashStyle { get; set; }

	float[] CustomDashPattern { get; set; }

	LineCapStyle CapStyle { get; set; }

	LineStyle Style { get; set; }

	LineAlignment Alignment { get; set; }

	LineJoinStyle JoinStyle { get; set; }

	float MiterLimit { get; set; }

	LineArrowheadStyle BeginArrowheadStyle { get; set; }

	LineArrowheadStyle EndArrowheadStyle { get; set; }

	LineArrowheadWidth BeginArrowheadWidth { get; set; }

	LineArrowheadWidth EndArrowheadWidth { get; set; }

	LineArrowheadLength BeginArrowheadLength { get; set; }

	LineArrowheadLength EndArrowheadLength { get; set; }

	bool Equals(ILineFormat lineFormat);
}
