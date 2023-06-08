using System;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace ns3;

internal interface Interface14 : IDisposable
{
	Interface8 Area { get; }

	Interface25 Border { get; }

	Font Font { get; set; }

	Color FontColor { get; set; }

	int Width { get; set; }

	int Height { get; set; }

	int X { set; }

	int Y { set; }

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
	void imethod_5(bool bool_0);

	[SpecialName]
	void imethod_6(bool bool_0);
}
