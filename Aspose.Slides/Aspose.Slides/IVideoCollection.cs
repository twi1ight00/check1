using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

namespace Aspose.Slides;

[ComVisible(true)]
[Guid("e77746a2-e55f-487f-a4b0-589345a78e3a")]
public interface IVideoCollection : ICollection, IEnumerable, IEnumerable<IVideo>
{
	IVideo this[int index] { get; }

	ICollection AsICollection { get; }

	IEnumerable AsIEnumerable { get; }

	IVideo AddVideo(IVideo video);

	IVideo AddVideo(Stream stream);

	IVideo AddVideo(byte[] videoData);
}
