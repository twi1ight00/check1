using System;
using System.Runtime.CompilerServices;

namespace ns3;

internal interface Interface30 : IDisposable
{
	int Rotation { set; }

	string Text { get; set; }

	Enum82 TextHorizontalAlignment { set; }

	Enum82 TextVerticalAlignment { set; }

	[SpecialName]
	Interface14 imethod_0();

	[SpecialName]
	Interface38 imethod_1();
}
