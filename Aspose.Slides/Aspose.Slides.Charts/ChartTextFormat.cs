using ns2;

namespace Aspose.Slides.Charts;

public class ChartTextFormat : IChartTextFormat
{
	private Class17 class17_0;

	private TextFrameFormat textFrameFormat_0;

	private ParagraphFormat paragraphFormat_0;

	private ChartPortionFormat chartPortionFormat_0;

	public IChartTextBlockFormat TextBlockFormat => textFrameFormat_0;

	public IChartParagraphFormat ParagraphFormat => paragraphFormat_0;

	public IChartPortionFormat PortionFormat => chartPortionFormat_0;

	internal Class17 ParentTextFormatManager => class17_0;

	internal uint Version => textFrameFormat_0.Version + paragraphFormat_0.Version + chartPortionFormat_0.Version;

	public void CopyTo(ITextFrame destTextFrame)
	{
		if (destTextFrame != null)
		{
			((TextFrameFormat)destTextFrame.TextFrameFormat).method_3(textFrameFormat_0);
			if (destTextFrame.Paragraphs.Count == 0)
			{
				destTextFrame.Paragraphs.Add(new Paragraph());
			}
			ParagraphFormat paragraphFormat = (ParagraphFormat)destTextFrame.Paragraphs[0].ParagraphFormat;
			paragraphFormat.method_0(paragraphFormat_0);
			BasePortionFormat basePortionFormat = (BasePortionFormat)destTextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
			basePortionFormat.vmethod_1(chartPortionFormat_0);
		}
	}

	public void CopyFrom(ITextFrame sourceTextFrame)
	{
		if (sourceTextFrame != null)
		{
			textFrameFormat_0.method_3((TextFrameFormat)sourceTextFrame.TextFrameFormat);
			if (sourceTextFrame.Paragraphs.Count > 0)
			{
				paragraphFormat_0.method_0((ParagraphFormat)sourceTextFrame.Paragraphs[0].ParagraphFormat);
				chartPortionFormat_0.vmethod_1((PortionFormat)sourceTextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat);
			}
		}
	}

	internal ChartTextFormat(IFormattedTextContainer parent, Class17 parentTextFormatManager)
	{
		class17_0 = parentTextFormatManager;
		textFrameFormat_0 = new TextFrameFormat(parent);
		paragraphFormat_0 = new ParagraphFormat(parent);
		chartPortionFormat_0 = new ChartPortionFormat(parent);
	}
}
