using System;
using System.Runtime.CompilerServices;

namespace ns3;

internal interface Interface9 : IDisposable
{
	bool AxisBetweenCategories { get; set; }

	Interface25 AxisLine { get; }

	Enum87 BaseUnitScale { get; set; }

	Enum64 CategoryType { get; set; }

	double CrossAt { set; }

	Enum66 CrossType { set; }

	bool IsLogarithmic { set; }

	double LogBase { set; }

	bool IsPlotOrderReversed { get; set; }

	bool IsVisible { get; set; }

	Interface25 MajorGridLines { get; }

	Interface25 MinorGridLines { get; }

	Enum84 MajorTickMark { set; }

	double MajorUnit { get; set; }

	Enum87 MajorUnitScale { get; set; }

	double MaxValue { get; set; }

	Enum84 MinorTickMark { set; }

	double MinorUnit { get; set; }

	Enum87 MinorUnitScale { get; set; }

	double MinValue { get; set; }

	Enum83 TickLabelPosition { set; }

	Interface29 TickLabels { get; }

	int TickLabelSpacing { get; set; }

	int TickMarkSpacing { set; }

	Interface30 Title { get; }

	Interface18 DisplayUnit { get; }

	[SpecialName]
	bool imethod_0();

	[SpecialName]
	void imethod_1(bool bool_0);

	[SpecialName]
	void imethod_2(bool bool_0);

	[SpecialName]
	bool imethod_3();

	[SpecialName]
	void imethod_4(bool bool_0);

	[SpecialName]
	bool imethod_5();

	[SpecialName]
	void imethod_6(bool bool_0);

	[SpecialName]
	bool imethod_7();

	[SpecialName]
	void imethod_8(bool bool_0);

	[SpecialName]
	bool imethod_9();

	[SpecialName]
	void imethod_10(bool bool_0);

	[SpecialName]
	void imethod_11(string string_0);
}
