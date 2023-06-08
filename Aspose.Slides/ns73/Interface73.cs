using System.Collections;
using System.Collections.Generic;

namespace ns73;

internal interface Interface73 : IEnumerable, IEnumerable<Interface59>
{
	long Length { get; }

	Interface59 this[int index] { get; }
}
