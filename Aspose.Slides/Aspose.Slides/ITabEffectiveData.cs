using System;
using System.Runtime.InteropServices;

namespace Aspose.Slides;

[ComVisible(true)]
[Guid("211f70bc-7f75-450f-aea2-5b316878d75f")]
public interface ITabEffectiveData : IComparable
{
	double Position { get; }

	TabAlignment Alignment { get; }

	IComparable AsIComparable { get; }
}
