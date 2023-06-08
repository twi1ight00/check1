using System;
using System.Drawing;

namespace ns3;

internal interface Interface22 : IDisposable
{
	bool IsDeleted { set; }

	Font Font { set; }

	Color FontColor { set; }
}
