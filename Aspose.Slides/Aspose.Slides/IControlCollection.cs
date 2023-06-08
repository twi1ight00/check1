using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Aspose.Slides;

[ComVisible(true)]
[Guid("e5b27e6d-62ba-4030-bac4-c0bddb749ac5")]
public interface IControlCollection : ICollection, IEnumerable, IEnumerable<IControl>
{
	IControl this[int index] { get; }

	ICollection AsICollection { get; }

	IEnumerable AsIEnumerable { get; }

	void Remove(IControl item);

	void RemoveAt(int index);

	void Clear();

	IControl AddControl(ControlType controlType, float x, float y, float width, float height);
}
