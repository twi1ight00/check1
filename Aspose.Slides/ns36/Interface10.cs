using System.Drawing;

namespace ns36;

internal interface Interface10
{
	Interface6 Area { get; }

	Interface18 Border { get; }

	Font TextFont { get; set; }

	Color FontColor { get; set; }

	int Width { get; set; }

	int Height { get; set; }

	int X { get; set; }

	int Y { get; set; }

	Rectangle Rectangle { get; set; }

	bool IsXAuto { get; set; }

	bool IsYAuto { get; set; }

	bool IsSizeAuto { get; set; }

	bool IsBoundAuto { get; set; }

	bool IsEdge { get; set; }
}
