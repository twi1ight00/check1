using System;
using System.Runtime.CompilerServices;

namespace ns3;

internal interface Interface32 : IDisposable
{
	Interface25 Border { get; }

	double Backward { set; }

	bool DisplayEquation { set; }

	bool DisplayRSquared { set; }

	double Forward { set; }

	double Intercept { set; }

	bool IsNameAuto { set; }

	string Name { set; }

	int Order { set; }

	int Period { set; }

	Interface17 DataLabels { get; }

	[SpecialName]
	void imethod_0(int int_0);
}
