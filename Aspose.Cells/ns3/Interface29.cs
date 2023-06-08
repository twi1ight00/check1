using System;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace ns3;

internal interface Interface29 : IDisposable
{
	Font Font { get; set; }

	Color FontColor { set; }

	bool LinkedSource { set; }

	int Offset { get; set; }

	int Rotation { set; }

	[SpecialName]
	string imethod_0();

	[SpecialName]
	void imethod_1(string string_0);
}
