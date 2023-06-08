using System.Runtime.InteropServices;

namespace Aspose.Slides;

[ComVisible(true)]
[Guid("82175fe4-0bde-4ab9-8c6c-c17469b6d197")]
public interface ILineFormatEffectiveData
{
	ILineFillFormatEffectiveData FillFormat { get; }

	double Width { get; }

	LineDashStyle DashStyle { get; }

	float[] CustomDashPattern { get; }

	LineCapStyle CapStyle { get; }

	LineStyle Style { get; }

	LineAlignment Alignment { get; }

	LineJoinStyle JoinStyle { get; }

	float MiterLimit { get; }

	LineArrowheadStyle BeginArrowheadStyle { get; }

	LineArrowheadStyle EndArrowheadStyle { get; }

	LineArrowheadWidth BeginArrowheadWidth { get; }

	LineArrowheadWidth EndArrowheadWidth { get; }

	LineArrowheadLength BeginArrowheadLength { get; }

	LineArrowheadLength EndArrowheadLength { get; }

	bool Equals(ILineFormatEffectiveData lf);
}
