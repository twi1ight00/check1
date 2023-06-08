using System;
using System.Runtime.CompilerServices;

namespace ns3;

internal interface Interface17 : IDisposable
{
	bool IsCategoryNameShown { set; }

	bool IsLegendKeyShown { set; }

	bool IsPercentageShown { set; }

	bool IsValueShown { set; }

	bool IsSeriesNameShown { set; }

	bool IsBubbleSizeShown { set; }

	Enum75 Separator { set; }

	int Rotation { set; }

	Enum82 TextHorizontalAlignment { set; }

	Enum82 TextVerticalAlignment { set; }

	bool LinkedSource { set; }

	string Text { get; set; }

	[SpecialName]
	Interface14 imethod_0();

	[SpecialName]
	void imethod_1(Enum74 enum74_0);

	[SpecialName]
	string imethod_2();

	[SpecialName]
	void imethod_3(string string_0);

	[SpecialName]
	Interface38 imethod_4();
}
