using System.Runtime.InteropServices;

namespace Aspose.Slides;

[ComVisible(true)]
[Guid("f62ae20a-e3fe-4e8e-8e0c-f5e1c8e2f35b")]
public interface ITextFrameFormat
{
	ITextStyle TextStyle { get; }

	double MarginLeft { get; set; }

	double MarginRight { get; set; }

	double MarginTop { get; set; }

	double MarginBottom { get; set; }

	NullableBool WrapText { get; set; }

	TextAnchorType AnchoringType { get; set; }

	NullableBool CenterText { get; set; }

	TextVerticalType TextVerticalType { get; set; }

	TextAutofitType AutofitType { get; set; }
}
