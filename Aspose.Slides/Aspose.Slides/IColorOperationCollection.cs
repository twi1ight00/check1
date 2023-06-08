using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Aspose.Slides;

[Guid("4779f2ae-c224-41bc-8352-b6b324f271ee")]
[ComVisible(true)]
public interface IColorOperationCollection : ICollection, IEnumerable, ICloneable, IEnumerable<IColorOperation>
{
	IColorOperation this[int index] { get; set; }

	ICollection AsICollection { get; }

	IEnumerable AsIEnumerable { get; }

	ICloneable AsICloneable { get; }

	IColorOperation Add(ColorTransformOperation operation, float parameter);

	IColorOperation Add(ColorTransformOperation operation);

	IColorOperation Insert(int position, ColorTransformOperation operation, float parameter);

	IColorOperation Insert(int position, ColorTransformOperation operation);

	void RemoveAt(int index);

	void Clear();
}
