using System.Collections;
using System.Collections.Generic;
using System.Drawing;

namespace ns36;

internal interface Interface29 : IEnumerable, IEnumerable<Interface30>
{
	int Count { get; }

	Interface30 this[int index] { get; }

	Interface30 Add(string text, Font font, Color fontColor, Enum156 textType);
}
