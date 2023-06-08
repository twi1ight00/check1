using System;
using System.Runtime.InteropServices;

namespace Aspose.Slides;

[ComVisible(true)]
[Guid("f35f4dfa-9d67-47c9-9d4d-ec9bee3ef33e")]
public interface ITab : IComparable
{
	double Position { get; set; }

	TabAlignment Alignment { get; set; }

	IComparable AsIComparable { get; }
}
