using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Aspose.Slides.SmartArt;

[ComVisible(true)]
[Guid("875ecf0d-327e-41c5-b697-c9da54b5b8e0")]
public interface ISmartArtNodeCollection : ICollection, IEnumerable, IEnumerable<ISmartArtNode>
{
	ISmartArtNode this[int index] { get; }

	ICollection AsICollection { get; }

	IEnumerable AsIEnumerable { get; }

	ISmartArtNode GetNodeByPosition(int position);

	ISmartArtNode AddNode();

	void RemoveNode(int index);

	void RemoveNode(ISmartArtNode nodeObj);

	bool RemoveNodeByPosition(int position);

	ISmartArtNode AddNodeByPosition(int position);
}
