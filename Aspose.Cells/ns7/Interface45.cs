using System.Collections;
using System.Runtime.CompilerServices;
using Aspose.Cells;

namespace ns7;

internal interface Interface45
{
	bool IsVisible { get; }

	string Values { get; }

	int StartRow { get; }

	int StartColumn { get; }

	int EndRow { get; }

	int EndColumn { get; }

	[SpecialName]
	bool imethod_0();

	[SpecialName]
	bool imethod_1();

	[SpecialName]
	ArrayList imethod_2();

	[SpecialName]
	void imethod_3(ArrayList arrayList_0);

	[SpecialName]
	byte[] imethod_4();

	[SpecialName]
	void imethod_5(byte[] byte_0);

	[SpecialName]
	bool imethod_6();

	ArrayList imethod_7(bool bool_0, bool bool_1, ref int int_0);

	ArrayList imethod_8(bool bool_0, bool bool_1, ref bool bool_2);

	string imethod_9();

	void imethod_10(out int supbook, out int sheetIndex);

	[SpecialName]
	int imethod_11();

	[SpecialName]
	Range imethod_12();

	[SpecialName]
	Enum126 imethod_13();

	[SpecialName]
	void imethod_14(Enum126 enum126_0);

	void Copy(Interface45 interface45_0, int int_0, CopyOptions copyOptions_0);

	void RemoveExternalLinks();
}
