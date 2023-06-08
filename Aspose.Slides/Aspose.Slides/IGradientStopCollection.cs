using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Aspose.Slides;

[Guid("5c20ee95-8aed-43b7-86e9-ab2339fa932a")]
[ComVisible(true)]
public interface IGradientStopCollection : ICollection, IEnumerable, IEnumerable<IGradientStop>
{
	IGradientStop this[int index] { get; }

	ICollection AsICollection { get; }

	IEnumerable AsIEnumerable { get; }

	IGradientStop Add(float position, Color color);

	IGradientStop Add(float position, PresetColor presetColor);

	IGradientStop Add(float position, SchemeColor schemeColor);

	void Insert(int index, float position, Color color);

	void Insert(int index, float position, PresetColor presetColor);

	void Insert(int index, float position, SchemeColor schemeColor);

	void RemoveAt(int index);

	void Clear();
}
