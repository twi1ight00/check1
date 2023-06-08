using System.Collections;
using System.Collections.Generic;

namespace ns73;

internal interface Interface95 : IEnumerable, IEnumerable<Interface75>
{
	long Length { get; }

	Interface76 this[int index] { get; set; }

	void Add(Interface76 styleSheet);
}
