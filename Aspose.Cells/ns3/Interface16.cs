using System;
using System.Runtime.CompilerServices;

namespace ns3;

internal interface Interface16 : IDisposable
{
	Interface8 Area { get; }

	Interface25 Border { get; }

	Interface26 Marker { get; }

	Interface17 DataLabels { get; }

	double XValue { get; set; }

	double YValue { get; }

	float Explosion { get; set; }

	[SpecialName]
	bool imethod_0();

	[SpecialName]
	void imethod_1(bool bool_0);

	[SpecialName]
	bool imethod_2();

	[SpecialName]
	void imethod_3(bool bool_0);

	[SpecialName]
	void imethod_4(bool bool_0);

	[SpecialName]
	void imethod_5(bool bool_0);

	[SpecialName]
	bool imethod_6();

	[SpecialName]
	void imethod_7(bool bool_0);

	[SpecialName]
	void imethod_8(Enum1 enum1_0);

	[SpecialName]
	void imethod_9(object object_0);

	[SpecialName]
	string imethod_10();

	[SpecialName]
	void imethod_11(string string_0);

	[SpecialName]
	bool imethod_12();

	[SpecialName]
	void imethod_13(bool bool_0);

	[SpecialName]
	void imethod_14(Enum1 enum1_0);

	[SpecialName]
	void imethod_15(object object_0);

	[SpecialName]
	void imethod_16(string string_0);

	[SpecialName]
	void imethod_17(bool bool_0);

	[SpecialName]
	void imethod_18(double double_0);

	[SpecialName]
	void imethod_19(string string_0);

	[SpecialName]
	void imethod_20(bool bool_0);

	[SpecialName]
	void imethod_21(bool bool_0);
}
