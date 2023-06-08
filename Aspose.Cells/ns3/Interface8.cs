using System;
using System.Drawing;

namespace ns3;

internal interface Interface8 : IDisposable
{
	bool InvertIfNegative { set; }

	Color BackgroundColor { set; }

	Interface34 FillFormat { get; }

	Color ForegroundColor { get; set; }

	Enum71 Formatting { get; set; }
}
