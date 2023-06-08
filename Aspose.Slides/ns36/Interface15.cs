using System.Collections;
using Aspose.Slides.Charts;

namespace ns36;

internal interface Interface15
{
	Interface18 Border { get; }

	Interface21 Parent { get; }

	double Amount { get; set; }

	ErrorBarType DisplayType { get; set; }

	IList MinusValue { get; set; }

	IList PlusValue { get; set; }

	ErrorBarValueType Type { get; set; }

	bool YDirection { get; set; }

	bool ShowMarkerTTop { get; set; }

	void imethod_0(params object[] vals);

	void imethod_1(params object[] vals);
}
