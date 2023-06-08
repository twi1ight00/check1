using System.Drawing;

namespace ns36;

internal interface Interface31
{
	Image Image { get; set; }

	int Transparency { get; set; }

	bool IsTiling { get; set; }

	double OffsetX { get; set; }

	double OffsetY { get; set; }

	double ScaleX { get; set; }

	double ScaleY { get; set; }

	Enum158 Alignment { get; set; }

	Enum159 MirrorType { get; set; }

	Enum151 FillPictrueType { get; set; }

	double OffsetsLeft { get; set; }

	double OffsetsRight { get; set; }

	double OffsetsTop { get; set; }

	double OffsetsBottom { get; set; }

	double StackAndScaleWithValue { get; set; }
}
