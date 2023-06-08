using System;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace ns3;

internal interface Interface13 : IDisposable
{
	Font Font { set; }

	Color FontColor { set; }

	Interface25 Border { get; }

	bool IsOutlineShown { set; }

	[SpecialName]
	void imethod_0(bool bool_0);

	[SpecialName]
	bool imethod_1();

	[SpecialName]
	void imethod_2(bool bool_0);

	[SpecialName]
	void imethod_3(bool bool_0);
}
