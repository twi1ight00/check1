using System.Collections;
using System.Collections.Generic;
using System.Drawing;

namespace ns36;

internal class Class778 : CollectionBase, IEnumerable, IEnumerable<Interface30>, Interface29
{
	public Interface30 this[int index] => (Interface30)base.InnerList[index];

	public Interface30 Add(string text, Font font, Color fontColor, Enum156 textType)
	{
		Class779 @class = new Class779(text, font, fontColor, textType);
		base.InnerList.Add(@class);
		return @class;
	}

	public new IEnumerator<Interface30> GetEnumerator()
	{
		return GetEnumerator();
	}
}
