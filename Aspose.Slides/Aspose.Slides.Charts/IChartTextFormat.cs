using System.Runtime.InteropServices;

namespace Aspose.Slides.Charts;

[ComVisible(true)]
[Guid("6a75cc1b-92a5-4650-9496-335c89c41170")]
public interface IChartTextFormat
{
	IChartTextBlockFormat TextBlockFormat { get; }

	IChartParagraphFormat ParagraphFormat { get; }

	IChartPortionFormat PortionFormat { get; }

	void CopyTo(ITextFrame destTextFrame);

	void CopyFrom(ITextFrame sourceTextFrame);
}
