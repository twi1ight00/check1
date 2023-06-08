using System.Collections;
using System.Collections.Generic;

namespace ns73;

internal interface Interface79 : IEnumerable, IEnumerable<string>
{
	string MediaText { get; }

	long Length { get; }

	string this[int index] { get; }

	void imethod_0(string oldMedium);

	void imethod_1(string newMedium);
}
