using System;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace ns3;

internal interface Interface40 : IDisposable
{
	int Transparency { set; }

	double OffsetX { set; }

	double OffsetY { set; }

	double ScaleX { set; }

	double ScaleY { set; }

	Enum86 MirrorType { set; }

	[SpecialName]
	void imethod_0(Image image_0);

	[SpecialName]
	void imethod_1(bool bool_0);

	[SpecialName]
	void imethod_2(Enum85 enum85_0);

	[SpecialName]
	void imethod_3(Enum70 enum70_0);

	[SpecialName]
	void imethod_4(double double_0);

	[SpecialName]
	void imethod_5(double double_0);

	[SpecialName]
	void imethod_6(double double_0);

	[SpecialName]
	void imethod_7(double double_0);

	[SpecialName]
	void imethod_8(double double_0);
}
